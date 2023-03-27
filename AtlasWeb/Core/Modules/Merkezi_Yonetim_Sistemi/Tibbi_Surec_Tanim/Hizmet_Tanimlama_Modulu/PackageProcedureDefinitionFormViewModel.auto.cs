//$6A24F040
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
    public partial class PackageProcedureDefinitionServiceController : Controller
    {
        [HttpGet]
        public PackageProcedureDefinitionFormViewModel PackageProcedureDefinitionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PackageProcedureDefinitionFormInternal(input);
        }

        [HttpPost]
        public PackageProcedureDefinitionFormViewModel PackageProcedureDefinitionFormLoad(FormLoadInput input)
        {
            return PackageProcedureDefinitionFormInternal(input);
        }

        private PackageProcedureDefinitionFormViewModel PackageProcedureDefinitionFormInternal(FormLoadInput input)
        {

            Guid? id = input.Id;
            var formDefID = Guid.Parse("6316174e-59bf-4ad5-8295-e18fa4a58d6d");
            var objectDefID = Guid.Parse("46e9b3a5-7d1a-4e2b-9151-18851c490082");
            var viewModel = new PackageProcedureDefinitionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;

            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PackageProcedureDefinition = objectContext.GetObject(id.Value, objectDefID) as PackageProcedureDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PackageProcedureDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PackageProcedureDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PackageProcedureDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PackageProcedureDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_PackageProcedureDefinitionForm(viewModel, viewModel._PackageProcedureDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PackageProcedureDefinition = new PackageProcedureDefinition(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PackageProcedureDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PackageProcedureDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PackageProcedureDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PackageProcedureDefinition);
                    PreScript_PackageProcedureDefinitionForm(viewModel, viewModel._PackageProcedureDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel PackageProcedureDefinitionForm(PackageProcedureDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return PackageProcedureDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel PackageProcedureDefinitionFormInternal(PackageProcedureDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("6316174e-59bf-4ad5-8295-e18fa4a58d6d");
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel._PackageProcedureDefinition);
            objectContext.ProcessRawObjects();

            var packageProcedureDefinition = (PackageProcedureDefinition)objectContext.GetLoadedObject(viewModel._PackageProcedureDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(packageProcedureDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PackageProcedureDefinition, formDefID);
            var transDef = packageProcedureDefinition.TransDef;
            PostScript_PackageProcedureDefinitionForm(viewModel, packageProcedureDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(packageProcedureDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(packageProcedureDefinition);
            AfterContextSaveScript_PackageProcedureDefinitionForm(viewModel, packageProcedureDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_PackageProcedureDefinitionForm(PackageProcedureDefinitionFormViewModel viewModel, PackageProcedureDefinition packageProcedureDefinition, TTObjectContext objectContext);
        partial void PostScript_PackageProcedureDefinitionForm(PackageProcedureDefinitionFormViewModel viewModel, PackageProcedureDefinition packageProcedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PackageProcedureDefinitionForm(PackageProcedureDefinitionFormViewModel viewModel, PackageProcedureDefinition packageProcedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(PackageProcedureDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class PackageProcedureDefinitionFormViewModel
    {
        public TTObjectClasses.PackageProcedureDefinition _PackageProcedureDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }
    }
}
