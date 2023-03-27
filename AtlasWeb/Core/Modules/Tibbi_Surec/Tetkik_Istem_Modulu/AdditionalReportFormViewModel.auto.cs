//$27075201
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
    public partial class AdditionalReportServiceController : Controller
    {

        [HttpGet]
        public AdditionalReportFormViewModel AdditionalReportForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return AdditionalReportFormLoadInternal(input);
        }

        [HttpPost]
        public AdditionalReportFormViewModel AdditionalReportFormLoad(FormLoadInput input)
        {
            return AdditionalReportFormLoadInternal(input);
        }


        [HttpGet]
        public AdditionalReportFormViewModel AdditionalReportFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("2cb6838a-76c0-43bf-b884-03a593e45e9a");
            var objectDefID = Guid.Parse("6e0a84a4-7f45-4f0a-8cb2-29c179283203");
            var viewModel = new AdditionalReportFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._AdditionalReport = objectContext.GetObject(id.Value, objectDefID) as AdditionalReport;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AdditionalReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AdditionalReport, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AdditionalReport);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AdditionalReport);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_AdditionalReportForm(viewModel, viewModel._AdditionalReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._AdditionalReport = new AdditionalReport(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AdditionalReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AdditionalReport, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AdditionalReport);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AdditionalReport);
                    PreScript_AdditionalReportForm(viewModel, viewModel._AdditionalReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel AdditionalReportForm(AdditionalReportFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return AdditionalReportFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel AdditionalReportFormInternal(AdditionalReportFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("2cb6838a-76c0-43bf-b884-03a593e45e9a");
            objectContext.AddToRawObjectList(viewModel._AdditionalReport);
            objectContext.ProcessRawObjects();

            var additionalReport = (AdditionalReport)objectContext.GetLoadedObject(viewModel._AdditionalReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(additionalReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AdditionalReport, formDefID);
            var transDef = additionalReport.TransDef;
            PostScript_AdditionalReportForm(viewModel, additionalReport, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(additionalReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(additionalReport);
            AfterContextSaveScript_AdditionalReportForm(viewModel, additionalReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_AdditionalReportForm(AdditionalReportFormViewModel viewModel, AdditionalReport additionalReport, TTObjectContext objectContext);
        partial void PostScript_AdditionalReportForm(AdditionalReportFormViewModel viewModel, AdditionalReport additionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_AdditionalReportForm(AdditionalReportFormViewModel viewModel, AdditionalReport additionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(AdditionalReportFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class AdditionalReportFormViewModel
    {
        public TTObjectClasses.AdditionalReport _AdditionalReport
        {
            get;
            set;
        }
    }
}
