//$1A4BBD84
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
    public partial class MedicalStuffReportServiceController : Controller
    {
        [HttpGet]
        public MedicalStuffReportFormViewModel MedicalStuffReportForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return MedicalStuffReportFormLoadInternal(input);
        }

        [HttpPost]
        public MedicalStuffReportFormViewModel MedicalStuffReportFormLoad(FormLoadInput input)
        {
            return MedicalStuffReportFormLoadInternal(input);
        }

        private MedicalStuffReportFormViewModel MedicalStuffReportFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("bf418289-5134-48ba-8d39-cc4a20dc24d4");
            var objectDefID = Guid.Parse("7e8b0668-9e8f-4075-8122-a829279a85d7");
            var viewModel = new MedicalStuffReportFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalStuffReport = objectContext.GetObject(id.Value, objectDefID) as MedicalStuffReport;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalStuffReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalStuffReport, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MedicalStuffReport);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MedicalStuffReport);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_MedicalStuffReportForm(viewModel, viewModel._MedicalStuffReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalStuffReport = new MedicalStuffReport(objectContext);
                    var entryStateID = Guid.Parse("48aeb9bf-72fc-4c93-8110-42c62ec1db57");
                    viewModel._MedicalStuffReport.CurrentStateDefID = entryStateID;
                    viewModel.MedicalStuffGridGridList = new TTObjectClasses.MedicalStuff[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalStuffReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalStuffReport, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedicalStuffReport);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedicalStuffReport);
                    PreScript_MedicalStuffReportForm(viewModel, viewModel._MedicalStuffReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        public class ResultSet : BaseViewModel
        {
            public Guid ObjectID
            {
                get;
                set;
            }

            public string Message
            {
                get;
                set;
            }

            public string MedulaErrorMessage
            {
                get;
                set;
            }
        }

        [HttpPost]
        public ResultSet MedicalStuffReportForm(MedicalStuffReportFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return MedicalStuffReportFormInternal(viewModel, objectContext);
            }
        }

        internal ResultSet MedicalStuffReportFormInternal(MedicalStuffReportFormViewModel viewModel, TTObjectContext objectContext)
        {
            var resultSet = new ResultSet();
            var formDefID = Guid.Parse("bf418289-5134-48ba-8d39-cc4a20dc24d4");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffDefinitions);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffGroups);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffPlaceOfUsages);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffUsageTypes);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffGridGridList);
            var entryStateID = Guid.Parse("48aeb9bf-72fc-4c93-8110-42c62ec1db57");
            objectContext.AddToRawObjectList(viewModel._MedicalStuffReport, entryStateID);
            objectContext.ProcessRawObjects(false);
            var medicalStuffReport = (MedicalStuffReport)objectContext.GetLoadedObject(viewModel._MedicalStuffReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(medicalStuffReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalStuffReport, formDefID);
            if (viewModel.MedicalStuffGridGridList != null)
            {
                foreach (var item in viewModel.MedicalStuffGridGridList)
                {
                    var medicalStuffsImported = (MedicalStuff)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)medicalStuffsImported).IsDeleted)
                        continue;
                    medicalStuffsImported.MedicalStuffReport = medicalStuffReport;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(medicalStuffReport);
            PostScript_MedicalStuffReportForm(viewModel, medicalStuffReport, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            resultSet.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(medicalStuffReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(medicalStuffReport);
            AfterContextSaveScript_MedicalStuffReportForm(viewModel, medicalStuffReport, transDef, objectContext);
            resultSet.OutgoingTransitions = viewModel.OutgoingTransitions;
            resultSet.CurrentStateReports = viewModel.CurrentStateReports;
            resultSet.ObjectID = viewModel._MedicalStuffReport.ObjectID;
            objectContext.FullPartialllyLoadedObjects();
            return resultSet;
        }

        partial void PreScript_MedicalStuffReportForm(MedicalStuffReportFormViewModel viewModel, MedicalStuffReport medicalStuffReport, TTObjectContext objectContext);
        partial void PostScript_MedicalStuffReportForm(MedicalStuffReportFormViewModel viewModel, MedicalStuffReport medicalStuffReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_MedicalStuffReportForm(MedicalStuffReportFormViewModel viewModel, MedicalStuffReport medicalStuffReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(MedicalStuffReportFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.MedicalStuffGridGridList = viewModel._MedicalStuffReport.MedicalStuff.OfType<MedicalStuff>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.MedicalStuffDefinitions = objectContext.LocalQuery<MedicalStuffDefinition>().ToArray();
            viewModel.MedicalStuffGroups = objectContext.LocalQuery<MedicalStuffGroup>().ToArray();
            viewModel.MedicalStuffPlaceOfUsages = objectContext.LocalQuery<MedicalStuffPlaceOfUsage>().ToArray();
            viewModel.MedicalStuffUsageTypes = objectContext.LocalQuery<MedicalStuffUsageType>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalStuffGroupListDef", viewModel.MedicalStuffGroups);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalStuffPlaceListDef", viewModel.MedicalStuffPlaceOfUsages);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalStuffDefinitionListDef", viewModel.MedicalStuffDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalStuffUsageTypeListDef", viewModel.MedicalStuffUsageTypes);
        }
    }
}


namespace Core.Models
{
    public partial class MedicalStuffReportFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MedicalStuffReport _MedicalStuffReport { get; set; }
        public TTObjectClasses.MedicalStuff[] MedicalStuffGridGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.MedicalStuffPlaceOfUsage[] MedicalStuffPlaceOfUsages { get; set; }
        public TTObjectClasses.MedicalStuffGroup[] MedicalStuffGroups { get; set; }
        public TTObjectClasses.MedicalStuffDefinition[] MedicalStuffDefinitions { get; set; }

        public TTObjectClasses.MedicalStuffUsageType[] MedicalStuffUsageTypes { get; set; }
    }
}
