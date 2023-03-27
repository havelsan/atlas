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
    public partial class GlaskowScoreServiceController : Controller
    {
        [HttpGet]
        public GlaskowScoreFormViewModel GlaskowScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return GlaskowScoreFormLoadInternal(input);
        }

        [HttpPost]
        public GlaskowScoreFormViewModel GlaskowScoreFormLoad(FormLoadInput input)
        {
            return GlaskowScoreFormLoadInternal(input);
        }

        private GlaskowScoreFormViewModel GlaskowScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("fd736b74-7edd-440c-8991-801ba662da66");
            var objectDefID = Guid.Parse("91018112-36f0-4661-8535-22ba41cd0e83");
            var viewModel = new GlaskowScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._GlaskowScore = objectContext.GetObject(id.Value, objectDefID) as GlaskowScore;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GlaskowScore, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GlaskowScore, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._GlaskowScore);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._GlaskowScore);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_GlaskowScoreForm(viewModel, viewModel._GlaskowScore, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._GlaskowScore = new GlaskowScore(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GlaskowScore, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GlaskowScore, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._GlaskowScore);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._GlaskowScore);
                    PreScript_GlaskowScoreForm(viewModel, viewModel._GlaskowScore, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel GlaskowScoreForm(GlaskowScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return GlaskowScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel GlaskowScoreFormInternal(GlaskowScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("fd736b74-7edd-440c-8991-801ba662da66");
            objectContext.AddToRawObjectList(viewModel.GlaskowComaScaleDefinitions);
            objectContext.AddToRawObjectList(viewModel._GlaskowScore);
            objectContext.ProcessRawObjects();

            var glaskowScore = (GlaskowScore)objectContext.GetLoadedObject(viewModel._GlaskowScore.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(glaskowScore, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GlaskowScore, formDefID);
            var transDef = glaskowScore.TransDef;
            PostScript_GlaskowScoreForm(viewModel, glaskowScore, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(glaskowScore);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(glaskowScore);
            AfterContextSaveScript_GlaskowScoreForm(viewModel, glaskowScore, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }
        

        partial void PreScript_GlaskowScoreForm(GlaskowScoreFormViewModel viewModel, GlaskowScore glaskowScore, TTObjectContext objectContext);
        partial void PostScript_GlaskowScoreForm(GlaskowScoreFormViewModel viewModel, GlaskowScore glaskowScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_GlaskowScoreForm(GlaskowScoreFormViewModel viewModel, GlaskowScore glaskowScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(GlaskowScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.GlaskowComaScaleDefinitions = objectContext.LocalQuery<GlaskowComaScaleDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GKSOralAnswerListDefinition", viewModel.GlaskowComaScaleDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GKSMotorAnswerListDefinition", viewModel.GlaskowComaScaleDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GKSEyesListDefinition", viewModel.GlaskowComaScaleDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class GlaskowScoreFormViewModel
    {
        public TTObjectClasses.GlaskowScore _GlaskowScore
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowComaScaleDefinitions
        {
            get;
            set;
        }
    }
}
