//$F39B9945
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
    public partial class BloodProductRequestServiceController : Controller
{
    [HttpGet]
    public BloodProductPreparationFormViewModel BloodProductPreparationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BloodProductPreparationFormLoadInternal(input);
    }

    [HttpPost]
    public BloodProductPreparationFormViewModel BloodProductPreparationFormLoad(FormLoadInput input)
    {
        return BloodProductPreparationFormLoadInternal(input);
    }

    private BloodProductPreparationFormViewModel BloodProductPreparationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7bb22e34-8bb1-41f5-878b-bf1f32100e60");
        var objectDefID = Guid.Parse("335964a9-0a5a-4a7a-9b4e-e47097c0e13b");
        var viewModel = new BloodProductPreparationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BloodProductRequest = objectContext.GetObject(id.Value, objectDefID) as BloodProductRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BloodProductRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodProductRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BloodProductRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BloodProductRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BloodProductPreparationForm(viewModel, viewModel._BloodProductRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BloodProductPreparationForm(BloodProductPreparationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("7bb22e34-8bb1-41f5-878b-bf1f32100e60");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
            objectContext.AddToRawObjectList(viewModel._BloodProductRequest);
            objectContext.ProcessRawObjects();
            var bloodProductRequest = (BloodProductRequest)objectContext.GetLoadedObject(viewModel._BloodProductRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(bloodProductRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodProductRequest, formDefID);
            if (viewModel.ttgrid1GridList != null)
            {
                foreach (var item in viewModel.ttgrid1GridList)
                {
                    var bloodProductsImported = (BloodBankBloodProducts)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)bloodProductsImported).IsDeleted)
                        continue;
                    bloodProductsImported.BloodProductRequest = bloodProductRequest;
                }
            }

            var transDef = bloodProductRequest.TransDef;
            PostScript_BloodProductPreparationForm(viewModel, bloodProductRequest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bloodProductRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bloodProductRequest);
            AfterContextSaveScript_BloodProductPreparationForm(viewModel, bloodProductRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BloodProductPreparationForm(BloodProductPreparationFormViewModel viewModel, BloodProductRequest bloodProductRequest, TTObjectContext objectContext);
    partial void PostScript_BloodProductPreparationForm(BloodProductPreparationFormViewModel viewModel, BloodProductRequest bloodProductRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BloodProductPreparationForm(BloodProductPreparationFormViewModel viewModel, BloodProductRequest bloodProductRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BloodProductPreparationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ttgrid1GridList = viewModel._BloodProductRequest.BloodProducts.OfType<BloodBankBloodProducts>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BloodBankBloodProductsList", viewModel.ProcedureDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class BloodProductPreparationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BloodProductRequest _BloodProductRequest { get; set; }
        public TTObjectClasses.BloodBankBloodProducts[] ttgrid1GridList { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
    }
}
