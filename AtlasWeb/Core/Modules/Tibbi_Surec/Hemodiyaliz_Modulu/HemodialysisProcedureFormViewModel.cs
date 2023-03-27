//$BBC9116C
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class HemodialysisRequestServiceController
    {
        partial void PreScript_HemodialysisProcedureForm(HemodialysisProcedureFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTObjectContext objectContext)
        {

            #region Týbbi bilgiler
            MedicalInformation MedicalInfo = hemodialysisRequest.Episode.Patient.MedicalInformation;
            if (MedicalInfo != null)
            {
                StringBuilder medicalInfoStr = new StringBuilder();
                if (MedicalInfo.HeartFailure == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "HeartFailure").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Broken == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Broken").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Pregnancy == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Pregnancy").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Diabetes == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Diabetes").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Malignancy == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Malignancy").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.MetalImplant == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "MetalImplant").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.VascularDisorder == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "VascularDisorder").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Infection == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Infection").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Stent == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Stent").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Other == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Other").FirstOrDefault().Caption);
                }
                viewModel.MedicalInfo = medicalInfoStr.ToString();
            }
            #endregion

            #region Anamnez Bilgileri

            if (hemodialysisRequest.Episode.Complaint != null)
            {
                viewModel.AnamnesisComplaintInfo = hemodialysisRequest.Episode.Complaint.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (hemodialysisRequest.Episode.PatientHistory != null)
            {
                viewModel.AnamnesisPatientHistoryInfo = hemodialysisRequest.Episode.PatientHistory.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (hemodialysisRequest.Episode.PhysicalExamination != null)
            {
                viewModel.AnamnesisPhysicalExaminationInfo = hemodialysisRequest.Episode.PhysicalExamination.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (hemodialysisRequest.Episode.MTSConclusion != null)
            {
                viewModel.AnamnesisMTSConclusionInfo = hemodialysisRequest.Episode.MTSConclusion.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            #endregion

            #region Detail Bilgileri
            viewModel.HemodialysisOrderDetailInfoList = new List<HemodialysisOrderDetailInfo>();
            foreach (var orderItem in hemodialysisRequest.HemodialysisOrders.Where(c => c.CurrentStateDefID != HemodialysisOrder.States.Cancelled).OrderBy(x => x.TreatmentStartDateTime))
            {
                foreach (var orderDetailItem in orderItem.HemodialysisOrderDetails.Where(c => c.CurrentStateDefID != HemodialysisOrderDetail.States.Cancelled).OrderBy(x => x.SessionDate))
                {
                    HemodialysisOrderDetailInfo _hemodialysisOrderDetailInfo = new HemodialysisOrderDetailInfo
                    {
                        OrderDetailObjectID = orderDetailItem.ObjectID,
                        OrderDetailObjectDef = orderDetailItem.ObjectDef.Name,
                        SessionDate = orderDetailItem.SessionDate.Value,
                        StartTime = orderDetailItem.SessionStartTime != null ? orderDetailItem.SessionStartTime.Value.ToShortDateString() : "",
                        FinishTime = orderDetailItem.SessionFinishTime != null ? orderDetailItem.SessionFinishTime.Value.ToShortDateString() : "",
                        TreatmentEquipment = orderDetailItem.TreatmentEquipment.Name,
                        HemodialysisState = GetEnumItem(orderDetailItem.CurrentStateDefID.Value),
                        ProcedureDoctor = orderDetailItem.ProcedureDoctor.Name,
                        BloodFlow = orderDetailItem.BloodFlow != null ? orderDetailItem.BloodFlow.ADI : "",
                        Intravenous = orderDetailItem.Intravenous != null ? orderDetailItem.Intravenous.ADI : "",
                        Information = orderDetailItem.Information != null ? orderDetailItem.Information : ""
                    };
                    viewModel.HemodialysisOrderDetailInfoList.Add(_hemodialysisOrderDetailInfo);
                }
            }

            #endregion
        }

        public string GetEnumItem(Guid stateId)
        {
            if (stateId == HemodialysisOrderDetail.States.Request)
            {
                return Common.GetDescriptionOfDataTypeEnum(HemodialysisStateEnum.New);
            }
            else if (stateId == HemodialysisOrderDetail.States.Completed)
            {
                return Common.GetDescriptionOfDataTypeEnum(HemodialysisStateEnum.Complated);
            }
            else if (stateId == HemodialysisOrderDetail.States.Aborted)
            {
                return Common.GetDescriptionOfDataTypeEnum(HemodialysisStateEnum.Aborted);
            }
            else if (stateId == HemodialysisOrderDetail.States.Cancelled)
            {
                return Common.GetDescriptionOfDataTypeEnum(HemodialysisStateEnum.Cancel);
            }
            else
            {
                return Common.GetDescriptionOfDataTypeEnum(HemodialysisStateEnum.New);
            }
        }

        [HttpPost]
        public void CancelSelectedProcedures(List<HemodialysisOrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid requestId = new Guid();
                for (int i = 0; i < model.Count; i++)
                {
                    HemodialysisOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailObjectID, model[i].OrderDetailObjectDef) as HemodialysisOrderDetail;
                    HemodialysisRequest request = orderDetail.HemodialysisRequest != null ? orderDetail.HemodialysisRequest : orderDetail.HemodialysisOrder.HemodialysisRequest;
                    requestId = request.ObjectID;

                    orderDetail.CurrentStateDefID = HemodialysisOrderDetail.States.Aborted;
                }

                objectContext.Save();
            }
        }

        public void CloseHemodialysisRequest(Guid ObjectID, Guid ObjectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                HemodialysisRequest request = objectContext.GetObject(ObjectID, ObjectDefID) as HemodialysisRequest;
                foreach (var order in request.HemodialysisOrders.Where(x => x.CurrentStateDefID == HemodialysisOrder.States.Plan || x.CurrentStateDefID == HemodialysisOrder.States.Request || x.CurrentStateDefID == HemodialysisOrder.States.Therapy))
                {
                    foreach (var detail in order.HemodialysisOrderDetails.Where(c => c.CurrentStateDefID == HemodialysisOrderDetail.States.Request))
                    {
                        detail.CurrentStateDefID = HemodialysisOrderDetail.States.Aborted;
                    }
                    order.CurrentStateDefID = HemodialysisOrder.States.Completed;
                }
                request.CurrentStateDefID = HemodialysisRequest.States.Completed;
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class HemodialysisProcedureFormViewModel : BaseViewModel
    {
        public string MedicalInfo { get; set; }
        public string AnamnesisComplaintInfo { get; set; }
        public string AnamnesisPatientHistoryInfo { get; set; }
        public string AnamnesisPhysicalExaminationInfo { get; set; }
        public string AnamnesisMTSConclusionInfo { get; set; }
        public bool HideAnamnesisInfoButton = true;

        public List<HemodialysisOrderDetailInfo> HemodialysisOrderDetailInfoList { get; set; }

        public bool cancelAllOrderDetails { get; set; }//True ise tamamlanmamýþ tüm iþlemler iptal edilecek; false sadece þeçili iþlem iptal edilecek
    }

    public class HemodialysisOrderDetailInfo
    {
        public Guid OrderDetailObjectID { get; set; }
        public string OrderDetailObjectDef { get; set; }
        public DateTime SessionDate { get; set; }//Seans Planlanan Tarih
        public string StartTime { get; set; }//Baþlama Saati
        public string FinishTime { get; set; }//Bitiþ Saati 
        public string TreatmentEquipment { get; set; }//Cihaz
        public string HemodialysisState { get; set; }//Durum
        public string ProcedureDoctor { get; set; }//Doktor
        public string BloodFlow { get; set; }//Kan Akým Hýzý
        public string Intravenous { get; set; }//Damar Yolu
        public string Information { get; set; }//Açýklama
    }
}
