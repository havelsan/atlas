//$1B300C18
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
    public partial class BallardPhysicalServiceController : Controller
    {
        [HttpGet]
        public BallardPhysicalScoreFormViewModel BallardPhysicalScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return BallardPhysicalScoreFormLoadInternal(input);
        }

        [HttpPost]
        public BallardPhysicalScoreFormViewModel BallardPhysicalScoreFormLoad(FormLoadInput input)
        {
            return BallardPhysicalScoreFormLoadInternal(input);
        }

        private BallardPhysicalScoreFormViewModel BallardPhysicalScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("e034bdb8-353d-4d46-acc7-718ca115d0a0");
            var objectDefID = Guid.Parse("4ddb18d9-91cf-4eb4-a043-ff17383cf88a");
            var viewModel = new BallardPhysicalScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BallardPhysical = objectContext.GetObject(id.Value, objectDefID) as BallardPhysical;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BallardPhysical, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BallardPhysical, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BallardPhysical);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BallardPhysical);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_BallardPhysicalScoreForm(viewModel, viewModel._BallardPhysical, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BallardPhysical = new BallardPhysical(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BallardPhysical, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BallardPhysical, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BallardPhysical);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BallardPhysical);
                    PreScript_BallardPhysicalScoreForm(viewModel, viewModel._BallardPhysical, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel BallardPhysicalScoreForm(BallardPhysicalScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return BallardPhysicalScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel BallardPhysicalScoreFormInternal(BallardPhysicalScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("e034bdb8-353d-4d46-acc7-718ca115d0a0");
            objectContext.AddToRawObjectList(viewModel._BallardPhysical);
            objectContext.ProcessRawObjects();

            var ballardPhysical = (BallardPhysical)objectContext.GetLoadedObject(viewModel._BallardPhysical.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(ballardPhysical, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BallardPhysical, formDefID);
            var transDef = ballardPhysical.TransDef;
            PostScript_BallardPhysicalScoreForm(viewModel, ballardPhysical, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(ballardPhysical);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(ballardPhysical);
            AfterContextSaveScript_BallardPhysicalScoreForm(viewModel, ballardPhysical, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_BallardPhysicalScoreForm(BallardPhysicalScoreFormViewModel viewModel, BallardPhysical ballardPhysical, TTObjectContext objectContext);
        partial void PostScript_BallardPhysicalScoreForm(BallardPhysicalScoreFormViewModel viewModel, BallardPhysical ballardPhysical, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_BallardPhysicalScoreForm(BallardPhysicalScoreFormViewModel viewModel, BallardPhysical ballardPhysical, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(BallardPhysicalScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class BallardPhysicalScoreFormViewModel
    {
        public TTObjectClasses.BallardPhysical _BallardPhysical
        {
            get;
            set;
        }
    }
}
