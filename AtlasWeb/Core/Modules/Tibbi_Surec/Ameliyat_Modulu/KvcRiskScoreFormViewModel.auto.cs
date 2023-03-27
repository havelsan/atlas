//$747B5D41
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
    public partial class KvcRiskScoreServiceController : Controller
    {
        [HttpGet]
        public KvcRiskScoreFormViewModel KvcRiskScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return KvcRiskScoreFormLoadInternal(input);
        }

        [HttpPost]
        public KvcRiskScoreFormViewModel KvcRiskScoreFormLoad(FormLoadInput input)
        {
            return KvcRiskScoreFormLoadInternal(input);
        }

        private KvcRiskScoreFormViewModel KvcRiskScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("31c5d712-a848-4159-a208-793bb980b5e8");
            var objectDefID = Guid.Parse("2b357bca-5382-4277-95ff-5d527b96249b");
            var viewModel = new KvcRiskScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._KvcRiskScore = objectContext.GetObject(id.Value, objectDefID) as KvcRiskScore;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KvcRiskScore, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KvcRiskScore, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._KvcRiskScore);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._KvcRiskScore);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_KvcRiskScoreForm(viewModel, viewModel._KvcRiskScore, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._KvcRiskScore = new KvcRiskScore(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KvcRiskScore, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KvcRiskScore, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._KvcRiskScore);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._KvcRiskScore);
                    PreScript_KvcRiskScoreForm(viewModel, viewModel._KvcRiskScore, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel KvcRiskScoreForm(KvcRiskScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return KvcRiskScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel KvcRiskScoreFormInternal(KvcRiskScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("31c5d712-a848-4159-a208-793bb980b5e8");
            objectContext.AddToRawObjectList(viewModel._KvcRiskScore);
            objectContext.ProcessRawObjects();

            var kvcRiskScore = (KvcRiskScore)objectContext.GetLoadedObject(viewModel._KvcRiskScore.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(kvcRiskScore, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KvcRiskScore, formDefID);
            var transDef = kvcRiskScore.TransDef;
            PostScript_KvcRiskScoreForm(viewModel, kvcRiskScore, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(kvcRiskScore);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(kvcRiskScore);
            AfterContextSaveScript_KvcRiskScoreForm(viewModel, kvcRiskScore, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_KvcRiskScoreForm(KvcRiskScoreFormViewModel viewModel, KvcRiskScore kvcRiskScore, TTObjectContext objectContext);
        partial void PostScript_KvcRiskScoreForm(KvcRiskScoreFormViewModel viewModel, KvcRiskScore kvcRiskScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_KvcRiskScoreForm(KvcRiskScoreFormViewModel viewModel, KvcRiskScore kvcRiskScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(KvcRiskScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class KvcRiskScoreFormViewModel
    {
        public TTObjectClasses.KvcRiskScore _KvcRiskScore
        {
            get;
            set;
        }
    }
}
