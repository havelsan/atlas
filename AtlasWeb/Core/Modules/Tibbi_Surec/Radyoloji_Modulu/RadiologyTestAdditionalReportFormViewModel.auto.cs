//$648E9BF6
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
    public partial class RadiologyAdditionalReportServiceController : Controller
    {
  

        [HttpGet]
        public RadiologyTestAdditionalReportFormViewModel RadiologyTestAdditionalReportForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return RadiologyTestAdditionalReportFormLoadInternal(input);
        }

        [HttpPost]
        public RadiologyTestAdditionalReportFormViewModel RadiologyTestAdditionalReportFormLoad(FormLoadInput input)
        {
            return RadiologyTestAdditionalReportFormLoadInternal(input);
        }
        public RadiologyTestAdditionalReportFormViewModel RadiologyTestAdditionalReportFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("381b6c0a-76ef-4166-9316-0a5624375bb8");
            var objectDefID = Guid.Parse("cf39835e-a17a-4a1d-971d-72be8c80ec08");
            var viewModel = new RadiologyTestAdditionalReportFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._RadiologyAdditionalReport = objectContext.GetObject(id.Value, objectDefID) as RadiologyAdditionalReport;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RadiologyAdditionalReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyAdditionalReport, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._RadiologyAdditionalReport);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._RadiologyAdditionalReport);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_RadiologyTestAdditionalReportForm(viewModel, viewModel._RadiologyAdditionalReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._RadiologyAdditionalReport = new RadiologyAdditionalReport(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RadiologyAdditionalReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyAdditionalReport, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._RadiologyAdditionalReport);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._RadiologyAdditionalReport);
                    PreScript_RadiologyTestAdditionalReportForm(viewModel, viewModel._RadiologyAdditionalReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel RadiologyTestAdditionalReportForm(RadiologyTestAdditionalReportFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return RadiologyTestAdditionalReportFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel RadiologyTestAdditionalReportFormInternal(RadiologyTestAdditionalReportFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("381b6c0a-76ef-4166-9316-0a5624375bb8");
            objectContext.AddToRawObjectList(viewModel._RadiologyAdditionalReport);
            objectContext.ProcessRawObjects();

            var radiologyAdditionalReport = (RadiologyAdditionalReport)objectContext.GetLoadedObject(viewModel._RadiologyAdditionalReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(radiologyAdditionalReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RadiologyAdditionalReport, formDefID);
            var transDef = radiologyAdditionalReport.TransDef;
            PostScript_RadiologyTestAdditionalReportForm(viewModel, radiologyAdditionalReport, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(radiologyAdditionalReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(radiologyAdditionalReport);
            AfterContextSaveScript_RadiologyTestAdditionalReportForm(viewModel, radiologyAdditionalReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_RadiologyTestAdditionalReportForm(RadiologyTestAdditionalReportFormViewModel viewModel, RadiologyAdditionalReport radiologyAdditionalReport, TTObjectContext objectContext);
        partial void PostScript_RadiologyTestAdditionalReportForm(RadiologyTestAdditionalReportFormViewModel viewModel, RadiologyAdditionalReport radiologyAdditionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_RadiologyTestAdditionalReportForm(RadiologyTestAdditionalReportFormViewModel viewModel, RadiologyAdditionalReport radiologyAdditionalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(RadiologyTestAdditionalReportFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class RadiologyTestAdditionalReportFormViewModel
    {
        public TTObjectClasses.RadiologyAdditionalReport _RadiologyAdditionalReport
        {
            get;
            set;
        }
    }
}
