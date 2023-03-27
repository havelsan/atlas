//$990EA70B
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class NursingOrderDetailServiceController
    {
        partial void PreScript_NursingOrderDetailForm(NursingOrderDetailFormViewModel viewModel, NursingOrderDetail nursingOrderDetail, TTObjectContext objectContext)
        {
            if (((ITTObject)nursingOrderDetail).IsNew == false)
            {
                viewModel.VitalSignAndNursingValueDefinitionListCount = GetVitalSignAndNursingValueDefListCount(nursingOrderDetail.ProcedureObject.ObjectID);
                viewModel.PatientFullName = nursingOrderDetail.Episode.Patient.FullName;
                viewModel.VitalSignsValues = nursingOrderDetail.EpisodeAction.SetVitalSignValues(objectContext);
            }
            else
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    viewModel._NursingOrderDetail.SetMyPropertiesByMasterAction(episodeAction);
                    viewModel._NursingOrderDetail.SecondaryMasterResource = episodeAction.SecondaryMasterResource;
                    viewModel.PatientFullName = episodeAction.Episode.Patient.FullName;
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingOrderDetail);
                    //Ekran yeni açılıyorsa vital değerlerin set edilmesi gerekiyor.
                    viewModel.VitalSignsValues = episodeAction.SetVitalSignValues(objectContext);
                }



            }


            viewModel.NursingApplicationCurrentState = viewModel._NursingOrderDetail.NursingApplication.CurrentStateDefID.Value;
        }

        partial void PostScript_NursingOrderDetailForm(NursingOrderDetailFormViewModel viewModel, NursingOrderDetail nursingOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //if ((VitalSignAndNursingDefinition)nursingOrderDetail.PeriodicOrder. == VitalSignType.BloodPressure)
            //    BloodPressure bp = new BloodPressure();
            if (nursingOrderDetail.NursingApplication != null && nursingOrderDetail.NursingApplication.CurrentStateDefID == NursingApplication.States.PreDischarged )
            {
                if (nursingOrderDetail.NursingApplication.InPatientTreatmentClinicApp != null && nursingOrderDetail.NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate.HasValue && nursingOrderDetail.WorkListDate > nursingOrderDetail.NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate)
                {
                    throw new Exception("Ön Taburcusu Yapılmış Hastalara Taburcu Tarihinden Daha İleriye Order Eklenemez. Taburcu Tarihi =" + nursingOrderDetail.NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate);
                }
                else if (nursingOrderDetail.NursingApplication.EmergencyIntervention != null && nursingOrderDetail.NursingApplication.EmergencyIntervention.DischargeTime.HasValue && nursingOrderDetail.WorkListDate > nursingOrderDetail.NursingApplication.EmergencyIntervention.DischargeTime)
                    throw new Exception("Ön Taburcusu Yapılmış Hastalara Taburcu Tarihinden Daha İleriye Order Eklenemez. Taburcu Tarihi =" + nursingOrderDetail.NursingApplication.EmergencyIntervention.DischargeTime);

            }

            if (nursingOrderDetail.ProcedureByUser == null && transDef.ToStateDefID == NursingOrderDetail.States.Completed)
            {
                nursingOrderDetail.ProcedureByUser = Common.CurrentResource;
            }
            if (nursingOrderDetail.CurrentStateDefID != NursingOrderDetail.States.Cancelled)
            {
                nursingOrderDetail.CreateMyVitalSign();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public int GetVitalSignAndNursingValueDefListCount(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return VitalSignAndNursingValueDefinition.GetAllVitalSignDefValueList(objectContext, ObjectID.ToString()).Count;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hemsirelik_Hizmetleri_Direktif_Geri_Alma)]
        public EpisodeActionData[] UndoNursingOrderDetail(string ObjectId)
        {
            MainPatientFolderServiceController mpfsc = new MainPatientFolderServiceController();
            return mpfsc.UndoLastTransitionEAorSPFlowableByObjectId(ObjectId);
        }
    }
}

namespace Core.Models
{
    public partial class NursingOrderDetailFormViewModel
    {
        public int VitalSignAndNursingValueDefinitionListCount
        {
            get;
            set;
        } //procedureonject ile ilişkili tanımlı sonuç var mı

        public string PatientFullName { get; set; }

        public Guid NursingApplicationCurrentState { get; set; }
        public EpisodeAction.VitalSignsValues VitalSignsValues;
       

    }
}