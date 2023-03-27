//$3ABE44B5
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
    public partial class PrismServiceController : Controller
    {
        [HttpGet]
        public PrismScoreFormViewModel PrismScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PrismScoreFormLoadInternal(input);
        }

        [HttpPost]
        public PrismScoreFormViewModel PrismScoreFormLoad(FormLoadInput input)
        {
            return PrismScoreFormLoadInternal(input);
        }

        private PrismScoreFormViewModel PrismScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("0cd5aa2d-ba1e-4e2b-82d6-866b026e03e5");
            var objectDefID = Guid.Parse("c40efcde-8a2a-4193-8f4b-415dfd561b99");
            var viewModel = new PrismScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Prism = objectContext.GetObject(id.Value, objectDefID) as Prism;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Prism, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Prism, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Prism);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Prism);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_PrismScoreForm(viewModel, viewModel._Prism, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Prism = new Prism(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Prism, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Prism, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Prism);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Prism);
                    PreScript_PrismScoreForm(viewModel, viewModel._Prism, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel PrismScoreForm(PrismScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return PrismScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel PrismScoreFormInternal(PrismScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("0cd5aa2d-ba1e-4e2b-82d6-866b026e03e5");
            objectContext.AddToRawObjectList(viewModel._Prism);
            objectContext.ProcessRawObjects();

            var prism = (Prism)objectContext.GetLoadedObject(viewModel._Prism.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(prism, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Prism, formDefID);
            var transDef = prism.TransDef;
            PostScript_PrismScoreForm(viewModel, prism, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(prism);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(prism);
            AfterContextSaveScript_PrismScoreForm(viewModel, prism, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_PrismScoreForm(PrismScoreFormViewModel viewModel, Prism prism, TTObjectContext objectContext);
        partial void PostScript_PrismScoreForm(PrismScoreFormViewModel viewModel, Prism prism, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PrismScoreForm(PrismScoreFormViewModel viewModel, Prism prism, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(PrismScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class PrismScoreFormViewModel
    {
        public TTObjectClasses.Prism _Prism
        {
            get;
            set;
        }
    }
}
