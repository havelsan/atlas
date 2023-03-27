//$748F070B
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
    public partial class SurgeryDefinitionServiceController : Controller
{
    [HttpGet]
    public SurgeryDefinitionFormViewModel SurgeryDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SurgeryDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public SurgeryDefinitionFormViewModel SurgeryDefinitionFormLoad(FormLoadInput input)
    {
        return SurgeryDefinitionFormLoadInternal(input);
    }

    private SurgeryDefinitionFormViewModel SurgeryDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("beb48a1b-d639-4663-8b2d-e4c98b53992c");
        var objectDefID = Guid.Parse("3c01da70-344c-4f44-9dc5-8e936758499f");
        var viewModel = new SurgeryDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SurgeryDefinition = objectContext.GetObject(id.Value, objectDefID) as SurgeryDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SurgeryDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SurgeryDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SurgeryDefinitionForm(viewModel, viewModel._SurgeryDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SurgeryDefinition = new SurgeryDefinition(objectContext);
                viewModel.DefinitionConceptsGridList = new TTObjectClasses.DefinitionConcept[]{};
                viewModel.CodelessMaterialsGridGridList = new TTObjectClasses.SurgeryCodelessMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SurgeryDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SurgeryDefinition);
                PreScript_SurgeryDefinitionForm(viewModel, viewModel._SurgeryDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SurgeryDefinitionForm(SurgeryDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return SurgeryDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel SurgeryDefinitionFormInternal(SurgeryDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("beb48a1b-d639-4663-8b2d-e4c98b53992c");
        objectContext.AddToRawObjectList(viewModel.Resources);
        objectContext.AddToRawObjectList(viewModel.DPA22FCodelessMaterialDefs);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.DefinitionConceptsGridList);
        objectContext.AddToRawObjectList(viewModel.CodelessMaterialsGridGridList);
            objectContext.AddToRawObjectList(viewModel.BranchesGridList);
            objectContext.AddToRawObjectList(viewModel._SurgeryDefinition);
        objectContext.ProcessRawObjects();
        var surgeryDefinition = (SurgeryDefinition)objectContext.GetLoadedObject(viewModel._SurgeryDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgeryDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryDefinition, formDefID);
        if (viewModel.DefinitionConceptsGridList != null)
        {
            foreach (var item in viewModel.DefinitionConceptsGridList)
            {
                var definitionConceptsImported = (DefinitionConcept)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)definitionConceptsImported).IsDeleted)
                    continue;
                definitionConceptsImported.TerminologyManagerDef = surgeryDefinition;
            }
        }

        if (viewModel.CodelessMaterialsGridGridList != null)
        {
            foreach (var item in viewModel.CodelessMaterialsGridGridList)
            {
                var surgeryCodelessMaterialsImported = (SurgeryCodelessMaterial)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)surgeryCodelessMaterialsImported).IsDeleted)
                    continue;
                surgeryCodelessMaterialsImported.SurgeryDefinition = surgeryDefinition;
            }
        }

            if (viewModel.BranchesGridList != null)
            {
                foreach (var item in viewModel.BranchesGridList)
                {
                    var branchesImported = (SurgeryBranchDefinition)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)branchesImported).IsDeleted)
                        continue;
                    branchesImported.Surgery = surgeryDefinition;
                }
            }

            var transDef = surgeryDefinition.TransDef;
        PostScript_SurgeryDefinitionForm(viewModel, surgeryDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(surgeryDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(surgeryDefinition);
        AfterContextSaveScript_SurgeryDefinitionForm(viewModel, surgeryDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_SurgeryDefinitionForm(SurgeryDefinitionFormViewModel viewModel, SurgeryDefinition surgeryDefinition, TTObjectContext objectContext);
    partial void PostScript_SurgeryDefinitionForm(SurgeryDefinitionFormViewModel viewModel, SurgeryDefinition surgeryDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SurgeryDefinitionForm(SurgeryDefinitionFormViewModel viewModel, SurgeryDefinition surgeryDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SurgeryDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DefinitionConceptsGridList = viewModel._SurgeryDefinition.DefinitionConcepts.OfType<DefinitionConcept>().ToArray();
        viewModel.CodelessMaterialsGridGridList = viewModel._SurgeryDefinition.SurgeryCodelessMaterials.OfType<SurgeryCodelessMaterial>().ToArray();
            viewModel.BranchesGridList = viewModel._SurgeryDefinition.Branches.OfType<SurgeryBranchDefinition>().ToArray();

            viewModel.Resources = objectContext.LocalQuery<Resource>().ToArray();
        viewModel.DPA22FCodelessMaterialDefs = objectContext.LocalQuery<DPA22FCodelessMaterialDef>().ToArray();
            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.Resources);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DPA22FCodelessMaterialList", viewModel.DPA22FCodelessMaterialDefs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);

            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class SurgeryDefinitionFormViewModel
    {
        public TTObjectClasses.SurgeryDefinition _SurgeryDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.DefinitionConcept[] DefinitionConceptsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SurgeryCodelessMaterial[] CodelessMaterialsGridGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Resource[] Resources
        {
            get;
            set;
        }

        public TTObjectClasses.SurgeryBranchDefinition[] BranchesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DPA22FCodelessMaterialDef[] DPA22FCodelessMaterialDefs
        {
            get;
            set;
        }
        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
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
