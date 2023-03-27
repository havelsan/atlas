//$AB1C03F7
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class PhysiotherapyTreatmentNoteServiceController : Controller
    {
        [HttpGet]
        public PhysiotherapyTreatmentNoteFormViewModel PhysiotherapyTreatmentNoteForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PhysiotherapyTreatmentNoteFormLoadInternal(input);
        }

        [HttpPost]
        public PhysiotherapyTreatmentNoteFormViewModel PhysiotherapyTreatmentNoteFormLoad(FormLoadInput input)
        {
            return PhysiotherapyTreatmentNoteFormLoadInternal(input);
        }

        private PhysiotherapyTreatmentNoteFormViewModel PhysiotherapyTreatmentNoteFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("6efce320-a83a-4bf7-85ea-e16c324dba74");
            var objectDefID = Guid.Parse("96876532-654a-4e54-acbc-b3a7f6770b65");
            var viewModel = new PhysiotherapyTreatmentNoteFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PhysiotherapyTreatmentNote = objectContext.GetObject(id.Value, objectDefID) as PhysiotherapyTreatmentNote;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyTreatmentNote, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyTreatmentNote, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyTreatmentNote);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyTreatmentNote);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_PhysiotherapyTreatmentNoteForm(viewModel, viewModel._PhysiotherapyTreatmentNote, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PhysiotherapyTreatmentNote = new PhysiotherapyTreatmentNote(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyTreatmentNote, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyTreatmentNote, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PhysiotherapyTreatmentNote);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PhysiotherapyTreatmentNote);
                    PreScript_PhysiotherapyTreatmentNoteForm(viewModel, viewModel._PhysiotherapyTreatmentNote, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel PhysiotherapyTreatmentNoteForm(PhysiotherapyTreatmentNoteFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return PhysiotherapyTreatmentNoteFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel PhysiotherapyTreatmentNoteFormInternal(PhysiotherapyTreatmentNoteFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("6efce320-a83a-4bf7-85ea-e16c324dba74");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._PhysiotherapyTreatmentNote);
            objectContext.ProcessRawObjects();

            var physiotherapyTreatmentNote = (PhysiotherapyTreatmentNote)objectContext.GetLoadedObject(viewModel._PhysiotherapyTreatmentNote.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyTreatmentNote, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyTreatmentNote, formDefID);
            var transDef = physiotherapyTreatmentNote.TransDef;
            PostScript_PhysiotherapyTreatmentNoteForm(viewModel, physiotherapyTreatmentNote, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physiotherapyTreatmentNote);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physiotherapyTreatmentNote);
            AfterContextSaveScript_PhysiotherapyTreatmentNoteForm(viewModel, physiotherapyTreatmentNote, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_PhysiotherapyTreatmentNoteForm(PhysiotherapyTreatmentNoteFormViewModel viewModel, PhysiotherapyTreatmentNote physiotherapyTreatmentNote, TTObjectContext objectContext);
        partial void PostScript_PhysiotherapyTreatmentNoteForm(PhysiotherapyTreatmentNoteFormViewModel viewModel, PhysiotherapyTreatmentNote physiotherapyTreatmentNote, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PhysiotherapyTreatmentNoteForm(PhysiotherapyTreatmentNoteFormViewModel viewModel, PhysiotherapyTreatmentNote physiotherapyTreatmentNote, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(PhysiotherapyTreatmentNoteFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserDefinitionList", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class PhysiotherapyTreatmentNoteFormViewModel
    {
        public TTObjectClasses.PhysiotherapyTreatmentNote _PhysiotherapyTreatmentNote
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}
