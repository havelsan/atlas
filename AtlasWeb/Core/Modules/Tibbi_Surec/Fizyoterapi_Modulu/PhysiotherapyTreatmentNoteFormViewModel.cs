//$0F290148
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class PhysiotherapyTreatmentNoteServiceController
    {
        partial void PreScript_PhysiotherapyTreatmentNoteForm(PhysiotherapyTreatmentNoteFormViewModel viewModel, PhysiotherapyTreatmentNote physiotherapyTreatmentNote, TTObjectContext objectContext)
        {
            Guid? activeEpisodeActionId = viewModel.GetSelectedEpisodeActionID();
            if (activeEpisodeActionId.HasValue && physiotherapyTreatmentNote.EpisodeAction == null)
            {
                EpisodeAction activeEpisodeAction = objectContext.GetObject<EpisodeAction>(activeEpisodeActionId.Value);
                physiotherapyTreatmentNote.EpisodeAction = activeEpisodeAction;
            }
            if (physiotherapyTreatmentNote.EpisodeAction != null)
            {
                var TreatmentNoteList = PhysiotherapyTreatmentNote.GetTreatmentNoteByEpisodeAction(objectContext, physiotherapyTreatmentNote.EpisodeAction.ObjectID);
                viewModel.PhyTreatmentNoteList = TreatmentNoteList.Where(x => x.TreatmentDiagnosisUnit == null && x.IsCompletedOrder == false && x.IsCompletedRequest == false).ToList();
                viewModel.PhyOrderTreatmentNoteList = TreatmentNoteList.Where(x => x.TreatmentDiagnosisUnit != null && x.IsCompletedOrder == true && x.IsCompletedRequest == false).ToList();
                viewModel.PhyRequestTreatmentNoteList = TreatmentNoteList.Where(x => x.TreatmentDiagnosisUnit == null && x.IsCompletedOrder == false && x.IsCompletedRequest == true).ToList();
            }
        }

        partial void PostScript_PhysiotherapyTreatmentNoteForm(PhysiotherapyTreatmentNoteFormViewModel viewModel, PhysiotherapyTreatmentNote physiotherapyTreatmentNote, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            physiotherapyTreatmentNote.EntryDate = Common.RecTime();
            physiotherapyTreatmentNote.EntryUser = Common.CurrentResource;
            physiotherapyTreatmentNote.IsCompletedOrder = false;
            physiotherapyTreatmentNote.IsCompletedRequest = false;
        }
    }
}

namespace Core.Models
{
    public partial class PhysiotherapyTreatmentNoteFormViewModel : BaseViewModel
    {
        public bool isNewTreatmentNote; // true-> Yeni tedavi notu ise form açýlacak deðilse sadece girilmiþ notlar gösterilecek. 

        public List<PhysiotherapyTreatmentNote> PhyTreatmentNoteList;
        public List<PhysiotherapyTreatmentNote> PhyRequestTreatmentNoteList;
        public List<PhysiotherapyTreatmentNote> PhyOrderTreatmentNoteList;
    }
}
