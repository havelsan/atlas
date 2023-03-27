//$8C0DA1F5
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
    public partial class ApgarServiceController : Controller
    {
        [HttpGet]
        public ApgarScoreFormViewModel ApgarScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ApgarScoreFormLoadInternal(input);
        }

        [HttpPost]
        public ApgarScoreFormViewModel ApgarScoreFormLoad(FormLoadInput input)
        {
            return ApgarScoreFormLoadInternal(input);
        }

        private ApgarScoreFormViewModel ApgarScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("a5b46756-c623-4bdf-805f-38607c08f753");
            var objectDefID = Guid.Parse("f814ad7b-9e98-4116-8180-189800b4becf");
            var viewModel = new ApgarScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Apgar = objectContext.GetObject(id.Value, objectDefID) as Apgar;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Apgar, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Apgar, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Apgar);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Apgar);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ApgarScoreForm(viewModel, viewModel._Apgar, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Apgar = new Apgar(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Apgar, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Apgar, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Apgar);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Apgar);
                    PreScript_ApgarScoreForm(viewModel, viewModel._Apgar, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ApgarScoreForm(ApgarScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ApgarScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ApgarScoreFormInternal(ApgarScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("a5b46756-c623-4bdf-805f-38607c08f753");
            objectContext.AddToRawObjectList(viewModel._Apgar);
            objectContext.ProcessRawObjects();

            var apgar = (Apgar)objectContext.GetLoadedObject(viewModel._Apgar.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(apgar, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Apgar, formDefID);
            var transDef = apgar.TransDef;
            PostScript_ApgarScoreForm(viewModel, apgar, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(apgar);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(apgar);
            AfterContextSaveScript_ApgarScoreForm(viewModel, apgar, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ApgarScoreForm(ApgarScoreFormViewModel viewModel, Apgar apgar, TTObjectContext objectContext);
        partial void PostScript_ApgarScoreForm(ApgarScoreFormViewModel viewModel, Apgar apgar, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ApgarScoreForm(ApgarScoreFormViewModel viewModel, Apgar apgar, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ApgarScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class ApgarScoreFormViewModel
    {
        public TTObjectClasses.Apgar _Apgar
        {
            get;
            set;
        }
    }
}
