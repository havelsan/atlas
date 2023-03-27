//$B3493A3C
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using static TTObjectClasses.LaboratoryProcedure;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class DietOrderDetailServiceController
    {
        partial void PreScript_DietOrderDetailForm(DietOrderDetailFormViewModel viewModel, DietOrderDetail dietOrderDetail, TTObjectContext objectContext)
        {
            if (dietOrderDetail != null && dietOrderDetail.Episode != null)
            {
                viewModel._inpatientExtraInfo = new InpatientExtraInfo();
                viewModel._DietLabTestResultList = new List<DietLabTestResultList>();
                viewModel._inpatientExtraInfo.BedName = dietOrderDetail.Episode.InpatientAdmissions[0].Bed.Name;
                viewModel._inpatientExtraInfo.RoomName = dietOrderDetail.Episode.InpatientAdmissions[0].Room.Name;
                viewModel._inpatientExtraInfo.RoomGroupName = dietOrderDetail.Episode.InpatientAdmissions[0].RoomGroup.Name;
                viewModel._inpatientExtraInfo.ResponsibleDoctor = dietOrderDetail.Episode.InpatientAdmissions[0].ActiveInPatientTrtmentClcApp.ProcedureDoctor.Name;
                System.ComponentModel.BindingList<GetLabProcedureForDietByEpisodeId_Class> labProcedureList = LaboratoryProcedure.GetLabProcedureForDietByEpisodeId(dietOrderDetail.Episode.ObjectID, " ORDER BY THIS.LaboratoryTestProcedureObject.Name ASC,THIS.ResultDate DESC ");
                foreach (GetLabProcedureForDietByEpisodeId_Class item in labProcedureList)
                {
                    DietLabTestResultList dtrl = new DietLabTestResultList();
                    dtrl.Reference = item.Reference;
                    dtrl.Result = item.Result;
                    dtrl.ResultDate = item.ResultDate.HasValue ? item.ResultDate.Value.ToString("dd.MM.yyyy") : "";
                    dtrl.TestName = item.Name;
                    dtrl.ObjectID = item.ObjectID.ToString();
                    if (viewModel._DietLabTestResultList.Count == 0 || !viewModel._DietLabTestResultList.Any(c => c.ObjectID == item.ObjectID.ToString()))
                    {
                        viewModel._DietLabTestResultList.Add(dtrl);
                    }
                }
            //viewModel._DietLabTestResultList = LaboratoryProcedure.GetLabProcedureForDietByEpisodeId
            }
            //  var a = viewModel._DietOrderDetail.Episode.EpisodeActions;
            // viewModel.EpisodeActions = objectContext.LocalQuery<EpisodeAction>().ToArray();
            DietOrder action = (DietOrder)viewModel._DietOrderDetail.EpisodeAction;
            viewModel.InPatientPhyApp = action.InpatientPhysicianApplication;
            viewModel.Episode = action.InpatientPhysicianApplication.Episode;
            viewModel.SubEpisode = action.InpatientPhysicianApplication.SubEpisode;
            viewModel.MasterResource = action.InpatientPhysicianApplication.MasterResource;
            viewModel.SecondaryMasterResource = action.InpatientPhysicianApplication.SecondaryMasterResource;

            BindingList<DietOrderDetail.GetOldInfoForDietOrder_Class> dietList = DietOrderDetail.GetOldInfoForDietOrder(viewModel.Episode.Patient.ObjectID, null);
            viewModel.DietOrderList = new List<DietOrderData>();
            foreach (var item in dietList)
            {
                DietOrderData diet = new DietOrderData
                {
                    CurrentStateName = item.Currentstatename.ToString(),
                    PeriodStartTime = item.PeriodStartTime.Value.ToString("dd/MM/yyyy"),
                    PeriodEndTime = item.PeriodEndTime.Value.ToString("dd/MM/yyyy"),
                    DietName = item.Name,
                    MasterResource = item.Tedaviklinikadi,
                    OrderDescription = item.OrderDescription,
                    DoctorName = item.Doctorname,
                    WhichMeal = (item.Breakfast == true ? "Kahvaltı, " : "") +
                    (item.Lunch == true ? "Öğlen, " : "") +
                    (item.Dinner == true ? "Akşam, " : "") +
                    (item.NightBreakfast == true ? "Gece Kahvaltısı, " : "") +
                    (item.Snack1 == true ? "Ara 1, " : "") +
                    (item.Snack2 == true ? "Ara 2, " : "") +
                    (item.Snack3 == true ? "Ara 3, " : "")
                };
                viewModel.DietOrderList.Add(diet);
            }

        }

        partial void PostScript_DietOrderDetailForm(DietOrderDetailFormViewModel viewModel, DietOrderDetail dietOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (dietOrderDetail.ProcedureByUser == null && dietOrderDetail.CurrentStateDefID == DietOrderDetail.States.Completed)
            {
                dietOrderDetail.ProcedureByUser = Common.CurrentResource;
            }
        }

        [HttpGet]
        public DietBarcodeInfo GetDietCaloriInfo(Guid PeriodicOrder,Guid ObjectID)
        {
            DietBarcodeInfo dietBarcodeInfo = new DietBarcodeInfo();

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                DietOrderDetail orderDetail = objectContext.GetObject<DietOrderDetail>(ObjectID);

                //babyMotherMatchBarcodeInfo.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));

                dietBarcodeInfo.PatientName = orderDetail.Episode.Patient.Name + " " + orderDetail.Episode.Patient.Surname;
                dietBarcodeInfo.PatientIdentifier = orderDetail.Episode.Patient.ID != null ? orderDetail.Episode.Patient.ID.ToString() : "";
                dietBarcodeInfo.ProtocolNumber = orderDetail.SubEpisode.ProtocolNo;

                DietOrder.GetTotalCaloriByOrder_Class totalCalori= DietOrder.GetTotalCaloriByOrder(PeriodicOrder).FirstOrDefault();
                dietBarcodeInfo.TotalCalori = totalCalori == null || totalCalori.Nqlcolumn == null ? "0" : totalCalori.Nqlcolumn.ToString();

                InPatientPhysicianApplication inpatient = ((DietOrder)orderDetail.PeriodicOrder).InpatientPhysicianApplication;
                if (inpatient != null && inpatient.InPatientTreatmentClinicApp != null)
                {
                    dietBarcodeInfo.ServiceName = inpatient.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic.Name;

                    dietBarcodeInfo.Room = inpatient.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room.Name + " / "
                                         + inpatient.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.Name;
                }

            }
            return dietBarcodeInfo;
        }
    }
}

namespace Core.Models
{
    public partial class DietOrderDetailFormViewModel
    {
        public InpatientExtraInfo _inpatientExtraInfo
        {
            get;
            set;
        }

        public List<DietLabTestResultList> _DietLabTestResultList
        {
            get;
            set;
        }

        public InPatientPhysicianApplication InPatientPhyApp { get; set; }
        public Episode Episode { get; set; }
        public SubEpisode SubEpisode { get; set; }
        public ResSection MasterResource { get; set; }
        public ResSection SecondaryMasterResource { get; set; }
        public List<DietOrderData> DietOrderList { get; set; } //Geçmiş diyetler

    }

    public class InpatientExtraInfo
    {
        public string BedName
        {
            get;
            set;
        }

        public string RoomName
        {
            get;
            set;
        }

        public string RoomGroupName
        {
            get;
            set;
        }

        public string ResponsibleDoctor
        {
            get;
            set;
        }
    }

    public class DietLabTestResultList
    {
        public string ObjectID
        {
            get;
            set;
        }

        public string TestName
        {
            get;
            set;
        }

        public string ResultDate
        {
            get;
            set;
        }

        public string Reference
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }
    }

    public class DietBarcodeInfo
    {
        public string PatientName { get; set; }
        public string PatientIdentifier { get; set; }
        public string ProtocolNumber { get; set; }
        public string Room { get; set; }
        public string TotalCalori { get; set; }
        public string ServiceName { get; set; }
    }

}