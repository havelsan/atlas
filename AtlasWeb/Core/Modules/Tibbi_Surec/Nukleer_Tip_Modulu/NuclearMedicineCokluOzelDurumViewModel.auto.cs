//$F8E808B4
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
    public partial class NuclearMedicineServiceController : Controller
{
    [HttpGet]
    public NuclearMedicineCokluOzelDurumViewModel NuclearMedicineCokluOzelDurum(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NuclearMedicineCokluOzelDurumLoadInternal(input);
    }

    [HttpPost]
    public NuclearMedicineCokluOzelDurumViewModel NuclearMedicineCokluOzelDurumLoad(FormLoadInput input)
    {
        return NuclearMedicineCokluOzelDurumLoadInternal(input);
    }

    private NuclearMedicineCokluOzelDurumViewModel NuclearMedicineCokluOzelDurumLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7951828e-b2fc-4165-a740-37d6d694b703");
        var objectDefID = Guid.Parse("ffb5f11a-93ec-4b54-881c-57ca00f26f63");
        var viewModel = new NuclearMedicineCokluOzelDurumViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NuclearMedicine = objectContext.GetObject(id.Value, objectDefID) as NuclearMedicine;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NuclearMedicine, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NuclearMedicine);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NuclearMedicine);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NuclearMedicineCokluOzelDurum(viewModel, viewModel._NuclearMedicine, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NuclearMedicineCokluOzelDurum(NuclearMedicineCokluOzelDurumViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NuclearMedicineCokluOzelDurumInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NuclearMedicineCokluOzelDurumInternal(NuclearMedicineCokluOzelDurumViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("7951828e-b2fc-4165-a740-37d6d694b703");
        objectContext.AddToRawObjectList(viewModel.OzelDurums);
        objectContext.AddToRawObjectList(viewModel.ttgridCokluOzelDurumGridList);
        objectContext.AddToRawObjectList(viewModel._NuclearMedicine);
        objectContext.ProcessRawObjects();
        var nuclearMedicine = (NuclearMedicine)objectContext.GetLoadedObject(viewModel._NuclearMedicine.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nuclearMedicine, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NuclearMedicine, formDefID);
        if (viewModel.ttgridCokluOzelDurumGridList != null)
        {
            foreach (var item in viewModel.ttgridCokluOzelDurumGridList)
            {
                var cokluOzelDurumImported = (CokluOzelDurum)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)cokluOzelDurumImported).IsDeleted)
                    continue;
                cokluOzelDurumImported.NuclearMedicine = nuclearMedicine;
            }
        }

        var transDef = nuclearMedicine.TransDef;
        PostScript_NuclearMedicineCokluOzelDurum(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nuclearMedicine);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nuclearMedicine);
        AfterContextSaveScript_NuclearMedicineCokluOzelDurum(viewModel, nuclearMedicine, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NuclearMedicineCokluOzelDurum(NuclearMedicineCokluOzelDurumViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext);
    partial void PostScript_NuclearMedicineCokluOzelDurum(NuclearMedicineCokluOzelDurumViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NuclearMedicineCokluOzelDurum(NuclearMedicineCokluOzelDurumViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NuclearMedicineCokluOzelDurumViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ttgridCokluOzelDurumGridList = viewModel._NuclearMedicine.CokluOzelDurum.OfType<CokluOzelDurum>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
    }
}
}


namespace Core.Models
{
    public partial class NuclearMedicineCokluOzelDurumViewModel
    {
        public TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get;
            set;
        }

        public TTObjectClasses.CokluOzelDurum[] ttgridCokluOzelDurumGridList
        {
            get;
            set;
        }

        public TTObjectClasses.OzelDurum[] OzelDurums
        {
            get;
            set;
        }
    }
}
