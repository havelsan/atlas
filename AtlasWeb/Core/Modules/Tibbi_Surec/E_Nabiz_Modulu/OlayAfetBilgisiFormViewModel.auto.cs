//$30E3E45D
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
    public partial class OlayAfetBilgisiServiceController : Controller
{
    [HttpGet]
    public OlayAfetBilgisiFormViewModel OlayAfetBilgisiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OlayAfetBilgisiFormLoadInternal(input);
    }

    [HttpPost]
    public OlayAfetBilgisiFormViewModel OlayAfetBilgisiFormLoad(FormLoadInput input)
    {
        return OlayAfetBilgisiFormLoadInternal(input);
    }

    private OlayAfetBilgisiFormViewModel OlayAfetBilgisiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("11fa5a8c-1c49-42cc-82e4-b6f1017ba594");
        var objectDefID = Guid.Parse("c5723c21-6c40-4290-ab44-55c5bf6f92d6");
        var viewModel = new OlayAfetBilgisiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OlayAfetBilgisi = objectContext.GetObject(id.Value, objectDefID) as OlayAfetBilgisi;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OlayAfetBilgisi, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OlayAfetBilgisi, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._OlayAfetBilgisi);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._OlayAfetBilgisi);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OlayAfetBilgisiForm(viewModel, viewModel._OlayAfetBilgisi, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OlayAfetBilgisi = new OlayAfetBilgisi(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OlayAfetBilgisi, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OlayAfetBilgisi, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._OlayAfetBilgisi);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._OlayAfetBilgisi);
                PreScript_OlayAfetBilgisiForm(viewModel, viewModel._OlayAfetBilgisi, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OlayAfetBilgisiForm(OlayAfetBilgisiFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("11fa5a8c-1c49-42cc-82e4-b6f1017ba594");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSHayatiTehlikeDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSOlayAfetBilgisis);
            objectContext.AddToRawObjectList(viewModel.SKRSAFETOLAYVATANDASTIPIs);
            objectContext.AddToRawObjectList(viewModel._OlayAfetBilgisi);
            objectContext.ProcessRawObjects();
            var olayAfetBilgisi = (OlayAfetBilgisi)objectContext.GetLoadedObject(viewModel._OlayAfetBilgisi.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(olayAfetBilgisi, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OlayAfetBilgisi, formDefID);
            var transDef = olayAfetBilgisi.TransDef;
            PostScript_OlayAfetBilgisiForm(viewModel, olayAfetBilgisi, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(olayAfetBilgisi);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(olayAfetBilgisi);
            AfterContextSaveScript_OlayAfetBilgisiForm(viewModel, olayAfetBilgisi, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OlayAfetBilgisiForm(OlayAfetBilgisiFormViewModel viewModel, OlayAfetBilgisi olayAfetBilgisi, TTObjectContext objectContext);
    partial void PostScript_OlayAfetBilgisiForm(OlayAfetBilgisiFormViewModel viewModel, OlayAfetBilgisi olayAfetBilgisi, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OlayAfetBilgisiForm(OlayAfetBilgisiFormViewModel viewModel, OlayAfetBilgisi olayAfetBilgisi, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OlayAfetBilgisiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSHayatiTehlikeDurumus = objectContext.LocalQuery<SKRSHayatiTehlikeDurumu>().ToArray();
        viewModel.SKRSOlayAfetBilgisis = objectContext.LocalQuery<SKRSOlayAfetBilgisi>().ToArray();
        viewModel.SKRSAFETOLAYVATANDASTIPIs = objectContext.LocalQuery<SKRSAFETOLAYVATANDASTIPI>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSHayatiTehlikeDurumuList", viewModel.SKRSHayatiTehlikeDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlayAfetBilgisiList", viewModel.SKRSOlayAfetBilgisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAFETOLAYVATANDASTIPIList", viewModel.SKRSAFETOLAYVATANDASTIPIs);
    }
}
}


namespace Core.Models
{
    public partial class OlayAfetBilgisiFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OlayAfetBilgisi _OlayAfetBilgisi { get; set; }
        public TTObjectClasses.SKRSHayatiTehlikeDurumu[] SKRSHayatiTehlikeDurumus { get; set; }
        public TTObjectClasses.SKRSOlayAfetBilgisi[] SKRSOlayAfetBilgisis { get; set; }
        public TTObjectClasses.SKRSAFETOLAYVATANDASTIPI[] SKRSAFETOLAYVATANDASTIPIs { get; set; }
    }
}
