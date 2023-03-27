//$1E6B29BD
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
    public partial class ApacheScoreServiceController : Controller
    {
        [HttpGet]
        public ApacheScoreFormViewModel ApacheScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ApacheScoreFormLoadInternal(input);
        }

        [HttpPost]
        public ApacheScoreFormViewModel ApacheScoreFormLoad(FormLoadInput input)
        {
            return ApacheScoreFormLoadInternal(input);
        }

        private ApacheScoreFormViewModel ApacheScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("b3c128db-9e82-4496-af79-184b33eaa4b8");
            var objectDefID = Guid.Parse("d01cb516-1582-4209-8b2c-28b8c7feb469");
            var viewModel = new ApacheScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ApacheScore = objectContext.GetObject(id.Value, objectDefID) as ApacheScore;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ApacheScore, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ApacheScore, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ApacheScore);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ApacheScore);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_ApacheScoreForm(viewModel, viewModel._ApacheScore, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ApacheScore = new ApacheScore(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ApacheScore, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ApacheScore, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ApacheScore);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ApacheScore);
                    PreScript_ApacheScoreForm(viewModel, viewModel._ApacheScore, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ApacheScoreForm(ApacheScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ApacheScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ApacheScoreFormInternal(ApacheScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("b3c128db-9e82-4496-af79-184b33eaa4b8");
            objectContext.AddToRawObjectList(viewModel._ApacheScore);
            objectContext.ProcessRawObjects();
            var apacheScore = (ApacheScore)objectContext.GetLoadedObject(viewModel._ApacheScore.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(apacheScore, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ApacheScore, formDefID);
            var transDef = apacheScore.TransDef;
            PostScript_ApacheScoreForm(viewModel, apacheScore, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(apacheScore);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(apacheScore);
            AfterContextSaveScript_ApacheScoreForm(viewModel, apacheScore, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_ApacheScoreForm(ApacheScoreFormViewModel viewModel, ApacheScore apacheScore, TTObjectContext objectContext);
        partial void PostScript_ApacheScoreForm(ApacheScoreFormViewModel viewModel, ApacheScore apacheScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ApacheScoreForm(ApacheScoreFormViewModel viewModel, ApacheScore apacheScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ApacheScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class ApacheScoreFormViewModel
    {
        public TTObjectClasses.ApacheScore _ApacheScore
        {
            get;
            set;
        }
    }
}
