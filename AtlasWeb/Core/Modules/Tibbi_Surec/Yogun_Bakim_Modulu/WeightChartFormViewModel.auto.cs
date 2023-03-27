//$DD3F0759
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
    public partial class WeightChartServiceController : Controller
    {
        [HttpGet]
        public WeightChartFormViewModel WeightChartForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return WeightChartFormLoadInternal(input);
        }

        [HttpPost]
        public WeightChartFormViewModel WeightChartFormLoad(FormLoadInput input)
        {
            return WeightChartFormLoadInternal(input);
        }

        private WeightChartFormViewModel WeightChartFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("863d0d01-310e-4189-b489-b5072fc1423d");
            var objectDefID = Guid.Parse("a567ad3c-edc1-4b3d-a9e7-ee0c2ea54bd7");
            var viewModel = new WeightChartFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._WeightChart = objectContext.GetObject(id.Value, objectDefID) as WeightChart;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._WeightChart, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WeightChart, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._WeightChart);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._WeightChart);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_WeightChartForm(viewModel, viewModel._WeightChart, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._WeightChart = new WeightChart(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._WeightChart, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WeightChart, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._WeightChart);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._WeightChart);
                    PreScript_WeightChartForm(viewModel, viewModel._WeightChart, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel WeightChartForm(WeightChartFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return WeightChartFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel WeightChartFormInternal(WeightChartFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("863d0d01-310e-4189-b489-b5072fc1423d");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._WeightChart);
            objectContext.ProcessRawObjects();

            var weightChart = (WeightChart)objectContext.GetLoadedObject(viewModel._WeightChart.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(weightChart, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WeightChart, formDefID);
            var transDef = weightChart.TransDef;
            PostScript_WeightChartForm(viewModel, weightChart, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(weightChart);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(weightChart);
            AfterContextSaveScript_WeightChartForm(viewModel, weightChart, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_WeightChartForm(WeightChartFormViewModel viewModel, WeightChart weightChart, TTObjectContext objectContext);
        partial void PostScript_WeightChartForm(WeightChartFormViewModel viewModel, WeightChart weightChart, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_WeightChartForm(WeightChartFormViewModel viewModel, WeightChart weightChart, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(WeightChartFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorAndNurseList", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class WeightChartFormViewModel
    {
        public TTObjectClasses.WeightChart _WeightChart
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}
