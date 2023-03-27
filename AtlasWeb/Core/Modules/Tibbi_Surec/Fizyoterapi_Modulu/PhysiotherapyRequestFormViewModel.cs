//$37A3C095
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

namespace Core.Controllers
{
    public partial class PhysiotherapyRequestServiceController
    {
        partial void PreScript_PhysiotherapyRequestForm(PhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext)
        {

            MedicalInformation MedicalInfo = physiotherapyRequest.Episode.Patient.MedicalInformation;
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

            viewModel.PatientObjectId = physiotherapyRequest.Episode.Patient.ObjectID.ToString();


            //viewModel.PhysiotherapyOrderList = new List<OrderInfo>();/*&& c.CurrentStateDefID != PhysiotherapyOrder.States.Completed*/
            //foreach (var order in physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled))
            //{
            //    OrderInfo _orderInfo = new OrderInfo
            //    {
            //        ApplicationArea = order?.FTRApplicationAreaDef?.ftrVucutBolgesiAdi,
            //        ApplicationAreaInfo = order.ApplicationArea != null ? order.ApplicationArea : "",
            //        Dose = order.Dose,
            //        Duration = order.Duration.ToString(),
            //        CurrentStateDefID = order.CurrentStateDefID.Value,
            //        ProcedureObject = order.ProcedureObject.Name,
            //        SessionCount = order.SessionCount.Value,
            //        TreatmentDiagnosisUnit = order.TreatmentDiagnosisUnit.Name,
            //        TreatmentProperties = order.TreatmentProperties,
            //        IsPlannedBefore = order.PhysiotherapyOrderDetails.Count() > 0 ? true : false,
            //        OrderObjectId = order.ObjectID,
            //        OrderObjectDefId = order.ObjectDef.ID
            //    };
            //    viewModel.PhysiotherapyOrderList.Add(_orderInfo);
            //}


        }

        public void PhysiotherapyOrderChanged(int? SessionCount, int? Duration, string Dose, Guid ObjectID, Guid ObjectDef)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrder order = objectContext.GetObject(ObjectID, ObjectDef) as PhysiotherapyOrder;
                if (SessionCount != null)
                    order.SessionCount = SessionCount;

                if (Duration != null)
                    order.Duration = Duration;

                if (Dose != null)
                    order.Dose = Dose;

                objectContext.Save();
            }
        }

        public void PhysiotherapyOrderDeleted(Guid ObjectID, Guid ObjectDef)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrder order = objectContext.GetObject(ObjectID, ObjectDef) as PhysiotherapyOrder;
                order.CurrentStateDefID = PhysiotherapyOrder.States.Cancelled;

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class PhysiotherapyRequestFormViewModel
    {
        public string MedicalInfo { get; set; }
        public string PatientObjectId { get; set; }
        //public List<OrderInfo> PhysiotherapyOrderList { get; set; }
    }
}
