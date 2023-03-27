//$82E2AB55
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
    public partial class BallardNeuromuscularServiceController : Controller
    {
        [HttpGet]
        public BallardNeuromuscularScoreFormViewModel BallardNeuromuscularScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return BallardNeuromuscularScoreFormLoadInternal(input);
        }

        [HttpPost]
        public BallardNeuromuscularScoreFormViewModel BallardNeuromuscularScoreFormLoad(FormLoadInput input)
        {
            return BallardNeuromuscularScoreFormLoadInternal(input);
        }

        private BallardNeuromuscularScoreFormViewModel BallardNeuromuscularScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("a0a5fd54-01a7-4283-9080-bc2df8adc3ce");
            var objectDefID = Guid.Parse("1b3e273e-d8a5-4748-99ad-4211a05de5d0");
            var viewModel = new BallardNeuromuscularScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BallardNeuromuscular = objectContext.GetObject(id.Value, objectDefID) as BallardNeuromuscular;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BallardNeuromuscular, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BallardNeuromuscular, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BallardNeuromuscular);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BallardNeuromuscular);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_BallardNeuromuscularScoreForm(viewModel, viewModel._BallardNeuromuscular, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BallardNeuromuscular = new BallardNeuromuscular(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BallardNeuromuscular, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BallardNeuromuscular, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BallardNeuromuscular);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BallardNeuromuscular);
                    PreScript_BallardNeuromuscularScoreForm(viewModel, viewModel._BallardNeuromuscular, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel BallardNeuromuscularScoreForm(BallardNeuromuscularScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return BallardNeuromuscularScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel BallardNeuromuscularScoreFormInternal(BallardNeuromuscularScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("a0a5fd54-01a7-4283-9080-bc2df8adc3ce");
            objectContext.AddToRawObjectList(viewModel._BallardNeuromuscular);
            objectContext.ProcessRawObjects();

            var ballardNeuromuscular = (BallardNeuromuscular)objectContext.GetLoadedObject(viewModel._BallardNeuromuscular.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(ballardNeuromuscular, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BallardNeuromuscular, formDefID);
            var transDef = ballardNeuromuscular.TransDef;
            PostScript_BallardNeuromuscularScoreForm(viewModel, ballardNeuromuscular, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(ballardNeuromuscular);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(ballardNeuromuscular);
            AfterContextSaveScript_BallardNeuromuscularScoreForm(viewModel, ballardNeuromuscular, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_BallardNeuromuscularScoreForm(BallardNeuromuscularScoreFormViewModel viewModel, BallardNeuromuscular ballardNeuromuscular, TTObjectContext objectContext);
        partial void PostScript_BallardNeuromuscularScoreForm(BallardNeuromuscularScoreFormViewModel viewModel, BallardNeuromuscular ballardNeuromuscular, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_BallardNeuromuscularScoreForm(BallardNeuromuscularScoreFormViewModel viewModel, BallardNeuromuscular ballardNeuromuscular, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(BallardNeuromuscularScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class BallardNeuromuscularScoreFormViewModel
    {
        public TTObjectClasses.BallardNeuromuscular _BallardNeuromuscular
        {
            get;
            set;
        }
    }
}
