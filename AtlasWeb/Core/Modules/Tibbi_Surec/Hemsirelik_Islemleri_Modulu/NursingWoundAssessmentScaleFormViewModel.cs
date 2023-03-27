//$CA67DF44
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class NursingWoundAssessmentScaleServiceController
    {
        partial void PreScript_NursingWoundAssessmentScaleForm(NursingWoundAssessmentScaleFormViewModel viewModel, NursingWoundAssessmentScale nursingWoundAssessmentScale, TTObjectContext objectContext)
        {
            if (nursingWoundAssessmentScale.ApplicationUser == null)
                nursingWoundAssessmentScale.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingWoundAssessmentScale).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingWoundAssessmentScale);
                }
            }
            Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
            if (selectedEpisodeObjectID.HasValue)
            {
                Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                if (episode.Patient.Age != null)
                    viewModel.PatientAge = episode.Patient.Age;
                if (episode.Patient.Sex != null)
                    viewModel.PatientSex = episode.Patient.Sex.ADI;

            }
        }

        partial void PostScript_NursingWoundAssessmentScaleForm(NursingWoundAssessmentScaleFormViewModel viewModel, NursingWoundAssessmentScale nursingWoundAssessmentScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
            if (selectedEpisodeObjectID.HasValue)
            {
                Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                if (episode.Patient != null)
                    nursingWoundAssessmentScale.TotalRisk = NursingWoundAssessmentScale.CalcNursingWoundAssessmentScaleTotalRisk(nursingWoundAssessmentScale, episode.Patient);
            }
        }
    }
}

namespace Core.Models
{
    public partial class NursingWoundAssessmentScaleFormViewModel
    {
        public int? PatientAge
        {
            get;
            set;
        }
        public string PatientSex
        {
            get;
            set;
        }
    }
}
