//$7FC67708
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
    public partial class EvdeSaglikIzlemVeriSetiServiceController : Controller
{
    [HttpGet]
    public EvdeSaglikIzlemFormViewModel EvdeSaglikIzlemForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return EvdeSaglikIzlemFormLoadInternal(input);
    }

    [HttpPost]
    public EvdeSaglikIzlemFormViewModel EvdeSaglikIzlemFormLoad(FormLoadInput input)
    {
        return EvdeSaglikIzlemFormLoadInternal(input);
    }

    private EvdeSaglikIzlemFormViewModel EvdeSaglikIzlemFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("aef95818-eb2f-4d21-9e08-51d1c5379fe3");
        var objectDefID = Guid.Parse("5905ebe5-f6d2-4ccb-9a78-d6bfc9834b77");
        var viewModel = new EvdeSaglikIzlemFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EvdeSaglikIzlemVeriSeti = objectContext.GetObject(id.Value, objectDefID) as EvdeSaglikIzlemVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EvdeSaglikIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EvdeSaglikIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._EvdeSaglikIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._EvdeSaglikIzlemVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_EvdeSaglikIzlemForm(viewModel, viewModel._EvdeSaglikIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EvdeSaglikIzlemVeriSeti = new EvdeSaglikIzlemVeriSeti(objectContext);
                viewModel.BirSonrakiHizmetIhtiyaciGridList = new TTObjectClasses.BirSonrakiHizmetIhtiyaci[]{};
                viewModel.VerilenEgitimlerGridList = new TTObjectClasses.VerilenEgitimler[]{};
                viewModel.PsikolojikDurumGridList = new TTObjectClasses.PsikolojikDurum[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EvdeSaglikIzlemVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EvdeSaglikIzlemVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EvdeSaglikIzlemVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EvdeSaglikIzlemVeriSeti);
                PreScript_EvdeSaglikIzlemForm(viewModel, viewModel._EvdeSaglikIzlemVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel EvdeSaglikIzlemForm(EvdeSaglikIzlemFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("aef95818-eb2f-4d21-9e08-51d1c5379fe3");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSBirSonrakiHizmetIhtiyacis);
            objectContext.AddToRawObjectList(viewModel.SKRSVerilenEgitimlers);
            objectContext.AddToRawObjectList(viewModel.SKRSPsikolojikDurumDegerlendirmesis);
            objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
            objectContext.AddToRawObjectList(viewModel.SKRSEvdeSaglikHizmetleriHastaNaklis);
            objectContext.AddToRawObjectList(viewModel.SKRSEvdeSaglikHizmetininSonlandirilmasis);
            objectContext.AddToRawObjectList(viewModel.SKRSBeslenmes);
            objectContext.AddToRawObjectList(viewModel.SKRSBasiDegerlendirmesis);
            objectContext.AddToRawObjectList(viewModel.SKRSAgris);
            objectContext.AddToRawObjectList(viewModel.BirSonrakiHizmetIhtiyaciGridList);
            objectContext.AddToRawObjectList(viewModel.VerilenEgitimlerGridList);
            objectContext.AddToRawObjectList(viewModel.PsikolojikDurumGridList);
            objectContext.AddToRawObjectList(viewModel._EvdeSaglikIzlemVeriSeti);
            objectContext.ProcessRawObjects();
            var evdeSaglikIzlemVeriSeti = (EvdeSaglikIzlemVeriSeti)objectContext.GetLoadedObject(viewModel._EvdeSaglikIzlemVeriSeti.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(evdeSaglikIzlemVeriSeti, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EvdeSaglikIzlemVeriSeti, formDefID);
            if (viewModel.BirSonrakiHizmetIhtiyaciGridList != null)
            {
                foreach (var item in viewModel.BirSonrakiHizmetIhtiyaciGridList)
                {
                    var birSonrakiHizmetIhtiyaciImported = (BirSonrakiHizmetIhtiyaci)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)birSonrakiHizmetIhtiyaciImported).IsDeleted)
                        continue;
                    birSonrakiHizmetIhtiyaciImported.EvdeSaglikIzlemVeriSeti = evdeSaglikIzlemVeriSeti;
                }
            }

            if (viewModel.VerilenEgitimlerGridList != null)
            {
                foreach (var item in viewModel.VerilenEgitimlerGridList)
                {
                    var verilenEgitimlerImported = (VerilenEgitimler)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)verilenEgitimlerImported).IsDeleted)
                        continue;
                    verilenEgitimlerImported.EvdeSaglikIzlemVeriSeti = evdeSaglikIzlemVeriSeti;
                }
            }

            if (viewModel.PsikolojikDurumGridList != null)
            {
                foreach (var item in viewModel.PsikolojikDurumGridList)
                {
                    var psikolojikDurumImported = (PsikolojikDurum)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)psikolojikDurumImported).IsDeleted)
                        continue;
                    psikolojikDurumImported.EvdeSaglikIzlemVeriSeti = evdeSaglikIzlemVeriSeti;
                }
            }

            var transDef = evdeSaglikIzlemVeriSeti.TransDef;
            PostScript_EvdeSaglikIzlemForm(viewModel, evdeSaglikIzlemVeriSeti, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(evdeSaglikIzlemVeriSeti);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(evdeSaglikIzlemVeriSeti);
            AfterContextSaveScript_EvdeSaglikIzlemForm(viewModel, evdeSaglikIzlemVeriSeti, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_EvdeSaglikIzlemForm(EvdeSaglikIzlemFormViewModel viewModel, EvdeSaglikIzlemVeriSeti evdeSaglikIzlemVeriSeti, TTObjectContext objectContext);
    partial void PostScript_EvdeSaglikIzlemForm(EvdeSaglikIzlemFormViewModel viewModel, EvdeSaglikIzlemVeriSeti evdeSaglikIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_EvdeSaglikIzlemForm(EvdeSaglikIzlemFormViewModel viewModel, EvdeSaglikIzlemVeriSeti evdeSaglikIzlemVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(EvdeSaglikIzlemFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.BirSonrakiHizmetIhtiyaciGridList = viewModel._EvdeSaglikIzlemVeriSeti.BirSonrakiHizmetIhtiyaci.OfType<BirSonrakiHizmetIhtiyaci>().ToArray();
        viewModel.VerilenEgitimlerGridList = viewModel._EvdeSaglikIzlemVeriSeti.VerilenEgitimler.OfType<VerilenEgitimler>().ToArray();
        viewModel.PsikolojikDurumGridList = viewModel._EvdeSaglikIzlemVeriSeti.PsikolojikDurum.OfType<PsikolojikDurum>().ToArray();
        viewModel.SKRSBirSonrakiHizmetIhtiyacis = objectContext.LocalQuery<SKRSBirSonrakiHizmetIhtiyaci>().ToArray();
        viewModel.SKRSVerilenEgitimlers = objectContext.LocalQuery<SKRSVerilenEgitimler>().ToArray();
        viewModel.SKRSPsikolojikDurumDegerlendirmesis = objectContext.LocalQuery<SKRSPsikolojikDurumDegerlendirmesi>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.SKRSEvdeSaglikHizmetleriHastaNaklis = objectContext.LocalQuery<SKRSEvdeSaglikHizmetleriHastaNakli>().ToArray();
        viewModel.SKRSEvdeSaglikHizmetininSonlandirilmasis = objectContext.LocalQuery<SKRSEvdeSaglikHizmetininSonlandirilmasi>().ToArray();
        viewModel.SKRSBeslenmes = objectContext.LocalQuery<SKRSBeslenme>().ToArray();
        viewModel.SKRSBasiDegerlendirmesis = objectContext.LocalQuery<SKRSBasiDegerlendirmesi>().ToArray();
        viewModel.SKRSAgris = objectContext.LocalQuery<SKRSAgri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBirSonrakiHizmetIhtiyaciList", viewModel.SKRSBirSonrakiHizmetIhtiyacis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVerilenEgitimlerList", viewModel.SKRSVerilenEgitimlers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPsikolojikDurumDegerlendirmesiList", viewModel.SKRSPsikolojikDurumDegerlendirmesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlList", viewModel.SKRSILKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEvdeSaglikHizmetleriHastaNakliList", viewModel.SKRSEvdeSaglikHizmetleriHastaNaklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEvdeSaglikHizmetininSonlandirilmasiList", viewModel.SKRSEvdeSaglikHizmetininSonlandirilmasis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBeslenmeList", viewModel.SKRSBeslenmes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBasiDegerlendirmesiList", viewModel.SKRSBasiDegerlendirmesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAgriList", viewModel.SKRSAgris);
    }
}
}


namespace Core.Models
{
    public partial class EvdeSaglikIzlemFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EvdeSaglikIzlemVeriSeti _EvdeSaglikIzlemVeriSeti { get; set; }
        public TTObjectClasses.BirSonrakiHizmetIhtiyaci[] BirSonrakiHizmetIhtiyaciGridList { get; set; }
        public TTObjectClasses.VerilenEgitimler[] VerilenEgitimlerGridList { get; set; }
        public TTObjectClasses.PsikolojikDurum[] PsikolojikDurumGridList { get; set; }
        public TTObjectClasses.SKRSBirSonrakiHizmetIhtiyaci[] SKRSBirSonrakiHizmetIhtiyacis { get; set; }
        public TTObjectClasses.SKRSVerilenEgitimler[] SKRSVerilenEgitimlers { get; set; }
        public TTObjectClasses.SKRSPsikolojikDurumDegerlendirmesi[] SKRSPsikolojikDurumDegerlendirmesis { get; set; }
        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris { get; set; }
        public TTObjectClasses.SKRSEvdeSaglikHizmetleriHastaNakli[] SKRSEvdeSaglikHizmetleriHastaNaklis { get; set; }
        public TTObjectClasses.SKRSEvdeSaglikHizmetininSonlandirilmasi[] SKRSEvdeSaglikHizmetininSonlandirilmasis { get; set; }
        public TTObjectClasses.SKRSBeslenme[] SKRSBeslenmes { get; set; }
        public TTObjectClasses.SKRSBasiDegerlendirmesi[] SKRSBasiDegerlendirmesis { get; set; }
        public TTObjectClasses.SKRSAgri[] SKRSAgris { get; set; }
    }
}
