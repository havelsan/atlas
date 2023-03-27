//$9AB7DFB2
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
    public partial class DentalProsthesisDefinitionServiceController : Controller
    {
        [HttpGet]
        public DentalProsthesisDefinitionFormViewModel DentalProsthesisDefinitionForm(Guid? id)
        {
            var formDefID = Guid.Parse("9eb50b4a-74b4-4739-878c-445e40a6221a");
            var objectDefID = Guid.Parse("b0733993-3025-400b-a831-229cc7e45684");
            var viewModel = new DentalProsthesisDefinitionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._DentalProsthesisDefinition = objectContext.GetObject(id.Value, objectDefID) as DentalProsthesisDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalProsthesisDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalProsthesisDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DentalProsthesisDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DentalProsthesisDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_DentalProsthesisDefinitionForm(viewModel, viewModel._DentalProsthesisDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._DentalProsthesisDefinition = new DentalProsthesisDefinition(objectContext);
                    viewModel.DepartmentsGridList = new TTObjectClasses.DentalProsthesisDepartmentGrid[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalProsthesisDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalProsthesisDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DentalProsthesisDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DentalProsthesisDefinition);
                    PreScript_DentalProsthesisDefinitionForm(viewModel, viewModel._DentalProsthesisDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel DentalProsthesisDefinitionForm(DentalProsthesisDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return DentalProsthesisDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel DentalProsthesisDefinitionFormInternal(DentalProsthesisDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("9eb50b4a-74b4-4739-878c-445e40a6221a");
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.DepartmentsGridList);
            objectContext.AddToRawObjectList(viewModel._DentalProsthesisDefinition);
            objectContext.ProcessRawObjects();

            var dentalProsthesisDefinition = (DentalProsthesisDefinition)objectContext.GetLoadedObject(viewModel._DentalProsthesisDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(dentalProsthesisDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalProsthesisDefinition, formDefID);

            if (viewModel.DepartmentsGridList != null)
            {
                foreach (var item in viewModel.DepartmentsGridList)
                {
                    var departmentsImported = (DentalProsthesisDepartmentGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)departmentsImported).IsDeleted)
                        continue;
                    departmentsImported.DentalProsthesisDefinition = dentalProsthesisDefinition;
                }
            }
            var transDef = dentalProsthesisDefinition.TransDef;
            PostScript_DentalProsthesisDefinitionForm(viewModel, dentalProsthesisDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dentalProsthesisDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dentalProsthesisDefinition);
            AfterContextSaveScript_DentalProsthesisDefinitionForm(viewModel, dentalProsthesisDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_DentalProsthesisDefinitionForm(DentalProsthesisDefinitionFormViewModel viewModel, DentalProsthesisDefinition dentalProsthesisDefinition, TTObjectContext objectContext);
        partial void PostScript_DentalProsthesisDefinitionForm(DentalProsthesisDefinitionFormViewModel viewModel, DentalProsthesisDefinition dentalProsthesisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_DentalProsthesisDefinitionForm(DentalProsthesisDefinitionFormViewModel viewModel, DentalProsthesisDefinition dentalProsthesisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(DentalProsthesisDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.DepartmentsGridList = viewModel._DentalProsthesisDefinition.Departments.OfType<DentalProsthesisDepartmentGrid>().ToArray();
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        }
    }
}


namespace Core.Models
{
    public partial class DentalProsthesisDefinitionFormViewModel
    {
        public TTObjectClasses.DentalProsthesisDefinition _DentalProsthesisDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.DentalProsthesisDepartmentGrid[] DepartmentsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }
    }
}
