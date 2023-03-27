//$87A8D1BC
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
    public partial class DiyabetVeriSetiServiceController : Controller
{
    [HttpGet]
    public DiyabetFormViewModel DiyabetForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DiyabetFormLoadInternal(input);
    }

    [HttpPost]
    public DiyabetFormViewModel DiyabetFormLoad(FormLoadInput input)
    {
        return DiyabetFormLoadInternal(input);
    }

    private DiyabetFormViewModel DiyabetFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("8307516d-cb3d-4e5a-8765-33cead9e4505");
        var objectDefID = Guid.Parse("16edb390-b369-4e46-b59f-a30471bf3d90");
        var viewModel = new DiyabetFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DiyabetVeriSeti = objectContext.GetObject(id.Value, objectDefID) as DiyabetVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DiyabetVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DiyabetVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DiyabetVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DiyabetVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DiyabetForm(viewModel, viewModel._DiyabetVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DiyabetVeriSeti = new DiyabetVeriSeti(objectContext);
                viewModel.DiyabetKompBilgisiGridList = new TTObjectClasses.DiyabetKompBilgisi[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DiyabetVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DiyabetVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DiyabetVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DiyabetVeriSeti);
                PreScript_DiyabetForm(viewModel, viewModel._DiyabetVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DiyabetForm(DiyabetFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("8307516d-cb3d-4e5a-8765-33cead9e4505");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSDiyabetEgitimis);
            objectContext.AddToRawObjectList(viewModel.SKRSDiyabetKomplikasyonlaris);
            objectContext.AddToRawObjectList(viewModel.DiyabetKompBilgisiGridList);
            objectContext.AddToRawObjectList(viewModel._DiyabetVeriSeti);
            objectContext.ProcessRawObjects();
            var diyabetVeriSeti = (DiyabetVeriSeti)objectContext.GetLoadedObject(viewModel._DiyabetVeriSeti.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(diyabetVeriSeti, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DiyabetVeriSeti, formDefID);
            if (viewModel.DiyabetKompBilgisiGridList != null)
            {
                foreach (var item in viewModel.DiyabetKompBilgisiGridList)
                {
                    var diyabetKompBilgisiImported = (DiyabetKompBilgisi)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diyabetKompBilgisiImported).IsDeleted)
                        continue;
                    diyabetKompBilgisiImported.DiyabetVeriSeti = diyabetVeriSeti;
                }
            }

            var transDef = diyabetVeriSeti.TransDef;
            PostScript_DiyabetForm(viewModel, diyabetVeriSeti, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(diyabetVeriSeti);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(diyabetVeriSeti);
            AfterContextSaveScript_DiyabetForm(viewModel, diyabetVeriSeti, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DiyabetForm(DiyabetFormViewModel viewModel, DiyabetVeriSeti diyabetVeriSeti, TTObjectContext objectContext);
    partial void PostScript_DiyabetForm(DiyabetFormViewModel viewModel, DiyabetVeriSeti diyabetVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DiyabetForm(DiyabetFormViewModel viewModel, DiyabetVeriSeti diyabetVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DiyabetFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DiyabetKompBilgisiGridList = viewModel._DiyabetVeriSeti.DiyabetKompBilgisi.OfType<DiyabetKompBilgisi>().ToArray();
        viewModel.SKRSDiyabetEgitimis = objectContext.LocalQuery<SKRSDiyabetEgitimi>().ToArray();
        viewModel.SKRSDiyabetKomplikasyonlaris = objectContext.LocalQuery<SKRSDiyabetKomplikasyonlari>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyabetEgitimiList", viewModel.SKRSDiyabetEgitimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyabetKomplikasyonlariList", viewModel.SKRSDiyabetKomplikasyonlaris);
    }
}
}


namespace Core.Models
{
    public partial class DiyabetFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DiyabetVeriSeti _DiyabetVeriSeti { get; set; }
        public TTObjectClasses.DiyabetKompBilgisi[] DiyabetKompBilgisiGridList { get; set; }
        public TTObjectClasses.SKRSDiyabetEgitimi[] SKRSDiyabetEgitimis { get; set; }
        public TTObjectClasses.SKRSDiyabetKomplikasyonlari[] SKRSDiyabetKomplikasyonlaris { get; set; }
    }
}
