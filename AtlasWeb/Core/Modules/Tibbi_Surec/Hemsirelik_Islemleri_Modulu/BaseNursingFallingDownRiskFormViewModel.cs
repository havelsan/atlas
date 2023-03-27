//$BE0E1942
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Core.Services;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class BaseNursingFallingDownRiskServiceController
    {
        partial void PreScript_BaseNursingFallingDownRiskForm(BaseNursingFallingDownRiskFormViewModel viewModel, BaseNursingFallingDownRisk baseNursingFallingDownRisk, TTObjectContext objectContext)
        {
            string whereClause = String.Empty;
            //TODO:ismail isteğin detayına göre açılacak
            //viewModel.ReadOnly = true;
            if (baseNursingFallingDownRisk.ApplicationUser == null)
                baseNursingFallingDownRisk.ApplicationUser = Common.CurrentResource;
            if (((ITTObject)baseNursingFallingDownRisk).IsNew == true)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    Patient p = episodeAction.Episode.Patient;
                    int _age = p.AgeBySpecificDate(episodeAction.SubEpisode.OpeningDate.Value); //kabulün alındığı zamanki yaşı
                    if (_age <= 16)
                        whereClause = " WHERE TYPE = " + (int)FallingDownRiskTypeEnum.Young;
                    else
                        whereClause = " WHERE TYPE = " + (int)FallingDownRiskTypeEnum.Adult;

                    if (_age >= 65)
                        baseNursingFallingDownRisk.TotalScore = 1;//65 yaş üstünde +1 puan eklenmesi gerekliyor. ilk açılışta ekledik 
                }
            }
            else
            {
                int _age = baseNursingFallingDownRisk.NursingApplication.Episode.Patient.AgeBySpecificDate(baseNursingFallingDownRisk.NursingApplication.SubEpisode.OpeningDate.Value); //kabulün alındığı zamanki yaşı
                if (_age <= 16)
                    whereClause = " WHERE TYPE = " + (int)FallingDownRiskTypeEnum.Young;
                else
                    whereClause = " WHERE TYPE = " + (int)FallingDownRiskTypeEnum.Adult;

                if (!viewModel.ReadOnly)
                {
                    using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                    {
                        viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)baseNursingFallingDownRisk);
                    }
                }
            }
            whereClause += " AND ISACTIVE = 1";

            viewModel.FallingDownRiskDefinitionList = FallingDownRiskDefinition.GetFallingDownRiskDefinition(whereClause).ToList();
        //LookupService ls = new LookupService();
        //viewModel.FallingRiskReasonList = ls.EnumList("FallingDownRiskReasonEnum");
        }
        partial void AfterContextSaveScript_BaseNursingFallingDownRiskForm(BaseNursingFallingDownRiskFormViewModel viewModel, BaseNursingFallingDownRisk baseNursingFallingDownRisk, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (baseNursingFallingDownRisk.NursingApplication.InPatientTreatmentClinicApp != null && baseNursingFallingDownRisk.TotalScore > 5) { 
                baseNursingFallingDownRisk.NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk = true;}
            else
                baseNursingFallingDownRisk.NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk = false;

            baseNursingFallingDownRisk.NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RiskWarningLastSeenDate = null;
            objectContext.Save();

        }
    }
}

namespace Core.Models
{
    public partial class BaseNursingFallingDownRiskFormViewModel
    {
        //public IList<EnumLookupItem> FallingRiskReasonList { get; set; }
        public List<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class> FallingDownRiskDefinitionList
        {
            get;
            set;
        }
    }
}