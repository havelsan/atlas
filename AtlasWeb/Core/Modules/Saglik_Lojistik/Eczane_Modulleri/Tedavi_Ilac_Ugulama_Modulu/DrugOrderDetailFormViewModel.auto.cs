//$4A07F765
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class DrugOrderDetailServiceController : Controller
{
    [HttpGet]
    public DrugOrderDetailFormViewModel DrugOrderDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DrugOrderDetailFormLoadInternal(input);
    }

    [HttpPost]
    public DrugOrderDetailFormViewModel DrugOrderDetailFormLoad(FormLoadInput input)
    {
        return DrugOrderDetailFormLoadInternal(input);
    }

    private DrugOrderDetailFormViewModel DrugOrderDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7babaae4-6ba7-47f0-a38a-e9b5c63b269b");
        var objectDefID = Guid.Parse("5beac21d-06b6-4d8f-a574-ff1ea8af3ce8");
        var viewModel = new DrugOrderDetailFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DrugOrderDetail = objectContext.GetObject(id.Value, objectDefID) as DrugOrderDetail;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugOrderDetail, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DrugOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DrugOrderDetail);
                PreScript_DrugOrderDetailForm(viewModel, viewModel._DrugOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DrugOrderDetail = new DrugOrderDetail(objectContext);
                var entryStateID = Guid.Parse("cb22e74b-a2be-456f-8680-660d0b21dc24");
                viewModel._DrugOrderDetail.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugOrderDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DrugOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DrugOrderDetail);
                PreScript_DrugOrderDetailForm(viewModel, viewModel._DrugOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void DrugOrderDetailForm(DrugOrderDetailFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("7babaae4-6ba7-47f0-a38a-e9b5c63b269b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            var entryStateID = Guid.Parse("cb22e74b-a2be-456f-8680-660d0b21dc24");
            objectContext.AddToRawObjectList(viewModel._DrugOrderDetail, entryStateID);
            objectContext.ProcessRawObjects(false);
            var drugOrderDetail = (DrugOrderDetail)objectContext.GetLoadedObject(viewModel._DrugOrderDetail.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(drugOrderDetail, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugOrderDetail, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(drugOrderDetail);
            PostScript_DrugOrderDetailForm(viewModel, drugOrderDetail, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            objectContext.Save();
            AfterContextSaveScript_DrugOrderDetailForm(viewModel, drugOrderDetail, transDef, objectContext);
        }
    }

    partial void PreScript_DrugOrderDetailForm(DrugOrderDetailFormViewModel viewModel, DrugOrderDetail drugOrderDetail, TTObjectContext objectContext);
    partial void PostScript_DrugOrderDetailForm(DrugOrderDetailFormViewModel viewModel, DrugOrderDetail drugOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DrugOrderDetailForm(DrugOrderDetailFormViewModel viewModel, DrugOrderDetail drugOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DrugOrderDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
    }
}
}

namespace Core.Models
{
    public partial class DrugOrderDetailFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DrugOrderDetail _DrugOrderDetail
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }
    }
}