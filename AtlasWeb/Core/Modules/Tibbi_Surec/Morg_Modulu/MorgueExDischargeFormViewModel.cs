//$173CAF5C
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class MorgueServiceController
    {
        partial void PreScript_MorgueExDischargeForm(MorgueExDischargeFormViewModel viewModel, Morgue morgue, TTObjectContext objectContext)
        {
            if (Common.CurrentResource.TakesPerformanceScore == true)
            {
                viewModel._Morgue.DoctorFixed = Common.CurrentResource;
            }
            if (morgue.CurrentStateDefID == Morgue.States.Request)
            {
                if (morgue.DiedClinic == null)
                {
                    Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                    var episodeAction = objectContext.GetObject<EpisodeAction>((Guid)selectedEpisodeActionObjectID);
                    if (episodeAction != null)
                    {
                        morgue.DiedClinic = episodeAction.MasterResource;
                        viewModel._Morgue.DiedClinic = episodeAction.MasterResource;
                    }
                }
            }

            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_MorgueExDischargeForm(MorgueExDischargeFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            morgue.Episode.Patient.DeathReportNo = viewModel._Morgue.DeathReportNo;
            morgue.Episode.Patient.ExDate = viewModel._Morgue.DateTimeOfDeath;
        }

        [HttpGet]
        public SKRSOlumSekli[] GetSKRSOlumSekli()
        {
            SKRSOlumSekli[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<SKRSOlumSekli>().ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        public SKRSICD[] GetSKRSICDO()
        {
            SKRSICD[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<SKRSICD>().ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        public SKRSOlumNedeniTuru[] GetSKRSOlumNedeni()
        {
            SKRSOlumNedeniTuru[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<SKRSOlumNedeniTuru>().ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

    }
}

namespace Core.Models
{
    public partial class MorgueExDischargeFormViewModel
    {
        public object _selectedDeathType
        {
            get;
            set;
        }
        public object _selectedDeathReason
        {
            get;
            set;
        }

        public void AddMorgueViewModelToContext(TTObjectContext objectContext, EpisodeAction masterAction)
        {

            var morgueImported = (Morgue)objectContext.AddObject(this._Morgue);
            morgueImported.FromResource = masterAction.MasterResource;
            morgueImported.MasterAction = masterAction;// Linkactions için set edildi
            morgueImported.Episode = masterAction.Episode;
            morgueImported.CurrentStateDefID = Morgue.States.Request;
            morgueImported.SenderDoctor = masterAction.ProcedureDoctor;
            if (masterAction is TreatmentDischarge)
                morgueImported.ActionDate = ((TreatmentDischarge)masterAction).DischargeDate;
            else
                morgueImported.ActionDate = masterAction.ActionDate;
            morgueImported.RequestDate = DateTime.Now;



            if (this.MorgueDeathTypeGridList != null)
            {
                foreach (var item in this.MorgueDeathTypeGridList)
                {
                    var deathTypeImported = (MorgueDeathType)objectContext.AddObject(item);
                    deathTypeImported.Morgue = morgueImported;
                }
            }

            if (this.DeathReasonDiagnosisGridList != null)
            {
                foreach (var item in this.DeathReasonDiagnosisGridList)
                {
                    var deathReasonImported = (DeathReasonDiagnosis)objectContext.AddObject(item);
                    deathReasonImported.Morgue = morgueImported;
                }
            }


        }
    }
}
