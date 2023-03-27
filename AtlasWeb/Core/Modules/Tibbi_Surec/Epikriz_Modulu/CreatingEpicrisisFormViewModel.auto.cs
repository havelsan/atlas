//$C5D71982
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
    public partial class CreatingEpicrisisServiceController : Controller
    {
        [HttpGet]
        public CreatingEpicrisisFormViewModel CreatingEpicrisisForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return CreatingEpicrisisFormLoadInternal(input);
        }

        [HttpPost]
        public CreatingEpicrisisFormViewModel CreatingEpicrisisFormLoad(FormLoadInput input)
        {
            return CreatingEpicrisisFormLoadInternal(input);
        }

        private CreatingEpicrisisFormViewModel CreatingEpicrisisFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("8c5df8fc-5b93-42c1-b7c6-77933e4bb2e7");
            var objectDefID = Guid.Parse("233d73fe-04b4-4ab2-beec-808a4dd30262");
            var viewModel = new CreatingEpicrisisFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._CreatingEpicrisis = objectContext.GetObject(id.Value, objectDefID) as CreatingEpicrisis;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CreatingEpicrisis, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CreatingEpicrisis, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CreatingEpicrisis);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CreatingEpicrisis);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_CreatingEpicrisisForm(viewModel, viewModel._CreatingEpicrisis, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._CreatingEpicrisis = new CreatingEpicrisis(objectContext);
                    var entryStateID = Guid.Parse("39eb95c9-5149-4a9a-a997-0d3c1225cc2c");
                    viewModel._CreatingEpicrisis.CurrentStateDefID = entryStateID;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CreatingEpicrisis, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CreatingEpicrisis, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._CreatingEpicrisis);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._CreatingEpicrisis);
                    PreScript_CreatingEpicrisisForm(viewModel, viewModel._CreatingEpicrisis, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel CreatingEpicrisisForm(CreatingEpicrisisFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return CreatingEpicrisisFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel CreatingEpicrisisFormInternal(CreatingEpicrisisFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("8c5df8fc-5b93-42c1-b7c6-77933e4bb2e7");
            objectContext.AddToRawObjectList(viewModel.Episodes);
            var entryStateID = Guid.Parse("39eb95c9-5149-4a9a-a997-0d3c1225cc2c");
            objectContext.AddToRawObjectList(viewModel._CreatingEpicrisis, entryStateID);
            objectContext.ProcessRawObjects(false);

            var creatingEpicrisis = (CreatingEpicrisis)objectContext.GetLoadedObject(viewModel._CreatingEpicrisis.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(creatingEpicrisis, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CreatingEpicrisis, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(creatingEpicrisis);
            PostScript_CreatingEpicrisisForm(viewModel, creatingEpicrisis, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(creatingEpicrisis);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(creatingEpicrisis);
            AfterContextSaveScript_CreatingEpicrisisForm(viewModel, creatingEpicrisis, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_CreatingEpicrisisForm(CreatingEpicrisisFormViewModel viewModel, CreatingEpicrisis creatingEpicrisis, TTObjectContext objectContext);
        partial void PostScript_CreatingEpicrisisForm(CreatingEpicrisisFormViewModel viewModel, CreatingEpicrisis creatingEpicrisis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_CreatingEpicrisisForm(CreatingEpicrisisFormViewModel viewModel, CreatingEpicrisis creatingEpicrisis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(CreatingEpicrisisFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        }
    }
}


namespace Core.Models
{
    public partial class CreatingEpicrisisFormViewModel
    {
        public TTObjectClasses.CreatingEpicrisis _CreatingEpicrisis
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }
    }
}
