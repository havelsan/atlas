//$60C4A615
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
    public partial class PatientOwnDrugReturnServiceController : Controller
{
    [HttpGet]
    public PatientOwnDrugReturnCompFormViewModel PatientOwnDrugReturnCompForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PatientOwnDrugReturnCompFormLoadInternal(input);
    }

    [HttpPost]
    public PatientOwnDrugReturnCompFormViewModel PatientOwnDrugReturnCompFormLoad(FormLoadInput input)
    {
        return PatientOwnDrugReturnCompFormLoadInternal(input);
    }

    private PatientOwnDrugReturnCompFormViewModel PatientOwnDrugReturnCompFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6984b030-1288-4fe5-a814-ec38afa133a4");
        var objectDefID = Guid.Parse("fe88b005-e22f-4acb-b308-9717c5e4945a");
        var viewModel = new PatientOwnDrugReturnCompFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientOwnDrugReturn = objectContext.GetObject(id.Value, objectDefID) as PatientOwnDrugReturn;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientOwnDrugReturn, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugReturn, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PatientOwnDrugReturn);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PatientOwnDrugReturn);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PatientOwnDrugReturnCompForm(viewModel, viewModel._PatientOwnDrugReturn, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PatientOwnDrugReturnCompForm(PatientOwnDrugReturnCompFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PatientOwnDrugReturnCompFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PatientOwnDrugReturnCompFormInternal(PatientOwnDrugReturnCompFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6984b030-1288-4fe5-a814-ec38afa133a4");
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.PatientOwnDrugReturnDetailsGridList);
        objectContext.AddToRawObjectList(viewModel._PatientOwnDrugReturn);
        objectContext.ProcessRawObjects();
        var patientOwnDrugReturn = (PatientOwnDrugReturn)objectContext.GetLoadedObject(viewModel._PatientOwnDrugReturn.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientOwnDrugReturn, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientOwnDrugReturn, formDefID);
        if (viewModel.PatientOwnDrugReturnDetailsGridList != null)
        {
            foreach (var item in viewModel.PatientOwnDrugReturnDetailsGridList)
            {
                var patientOwnDrugReturnDetailsImported = (PatientOwnDrugReturnDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)patientOwnDrugReturnDetailsImported).IsDeleted)
                    continue;
                patientOwnDrugReturnDetailsImported.PatientOwnDrugReturn = patientOwnDrugReturn;
            }
        }

        var transDef = patientOwnDrugReturn.TransDef;
        PostScript_PatientOwnDrugReturnCompForm(viewModel, patientOwnDrugReturn, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patientOwnDrugReturn);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patientOwnDrugReturn);
        AfterContextSaveScript_PatientOwnDrugReturnCompForm(viewModel, patientOwnDrugReturn, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PatientOwnDrugReturnCompForm(PatientOwnDrugReturnCompFormViewModel viewModel, PatientOwnDrugReturn patientOwnDrugReturn, TTObjectContext objectContext);
    partial void PostScript_PatientOwnDrugReturnCompForm(PatientOwnDrugReturnCompFormViewModel viewModel, PatientOwnDrugReturn patientOwnDrugReturn, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PatientOwnDrugReturnCompForm(PatientOwnDrugReturnCompFormViewModel viewModel, PatientOwnDrugReturn patientOwnDrugReturn, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PatientOwnDrugReturnCompFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PatientOwnDrugReturnDetailsGridList = viewModel._PatientOwnDrugReturn.PatientOwnDrugReturnDetails.OfType<PatientOwnDrugReturnDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class PatientOwnDrugReturnCompFormViewModel
    {
        public TTObjectClasses.PatientOwnDrugReturn _PatientOwnDrugReturn
        {
            get;
            set;
        }

        public TTObjectClasses.PatientOwnDrugReturnDetail[] PatientOwnDrugReturnDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
    }
}
