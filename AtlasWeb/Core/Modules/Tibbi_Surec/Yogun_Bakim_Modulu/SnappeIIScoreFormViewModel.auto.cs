//$FAA1A920
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
    public partial class SnappeServiceController : Controller
    {
        [HttpGet]
        public SnappeIIScoreFormViewModel SnappeIIScoreForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SnappeIIScoreFormLoadInternal(input);
        }

        [HttpPost]
        public SnappeIIScoreFormViewModel SnappeIIScoreFormLoad(FormLoadInput input)
        {
            return SnappeIIScoreFormLoadInternal(input);
        }

        private SnappeIIScoreFormViewModel SnappeIIScoreFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("242eaf4f-6bfd-4503-933f-50f1e937668a");
            var objectDefID = Guid.Parse("e43af15d-b77e-4e5c-8f04-d505aabd1395");
            var viewModel = new SnappeIIScoreFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Snappe = objectContext.GetObject(id.Value, objectDefID) as Snappe;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Snappe, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Snappe, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Snappe);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Snappe);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_SnappeIIScoreForm(viewModel, viewModel._Snappe, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Snappe = new Snappe(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Snappe, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Snappe, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Snappe);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Snappe);
                    PreScript_SnappeIIScoreForm(viewModel, viewModel._Snappe, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SnappeIIScoreForm(SnappeIIScoreFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return SnappeIIScoreFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel SnappeIIScoreFormInternal(SnappeIIScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("242eaf4f-6bfd-4503-933f-50f1e937668a");
            objectContext.AddToRawObjectList(viewModel._Snappe);
            objectContext.ProcessRawObjects();

            var snappe = (Snappe)objectContext.GetLoadedObject(viewModel._Snappe.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(snappe, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Snappe, formDefID);
            var transDef = snappe.TransDef;
            PostScript_SnappeIIScoreForm(viewModel, snappe, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(snappe);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(snappe);
            AfterContextSaveScript_SnappeIIScoreForm(viewModel, snappe, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_SnappeIIScoreForm(SnappeIIScoreFormViewModel viewModel, Snappe snappe, TTObjectContext objectContext);
        partial void PostScript_SnappeIIScoreForm(SnappeIIScoreFormViewModel viewModel, Snappe snappe, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SnappeIIScoreForm(SnappeIIScoreFormViewModel viewModel, Snappe snappe, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(SnappeIIScoreFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class SnappeIIScoreFormViewModel
    {
        public TTObjectClasses.Snappe _Snappe
        {
            get;
            set;
        }
    }
}
