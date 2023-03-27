//$BF882FDB
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
    public partial class HemodialysisOrderDetailServiceController : Controller
{
    [HttpGet]
    public HemodialysisOrderDetailFormViewModel HemodialysisOrderDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return HemodialysisOrderDetailFormLoadInternal(input);
    }

    [HttpPost]
    public HemodialysisOrderDetailFormViewModel HemodialysisOrderDetailFormLoad(FormLoadInput input)
    {
        return HemodialysisOrderDetailFormLoadInternal(input);
    }

    private HemodialysisOrderDetailFormViewModel HemodialysisOrderDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2cd32cd4-8596-4ed6-81a8-4d54b5f6d9b0");
        var objectDefID = Guid.Parse("b6c035d6-0fc5-4343-9075-589ebb038bf7");
        var viewModel = new HemodialysisOrderDetailFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._HemodialysisOrderDetail = objectContext.GetObject(id.Value, objectDefID) as HemodialysisOrderDetail;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisOrderDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HemodialysisOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HemodialysisOrderDetail);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_HemodialysisOrderDetailForm(viewModel, viewModel._HemodialysisOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._HemodialysisOrderDetail = new HemodialysisOrderDetail(objectContext);
                var entryStateID = Guid.Parse("ee2557f6-5ada-4df9-a705-000dcc9c10ab");
                viewModel._HemodialysisOrderDetail.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisOrderDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisOrderDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._HemodialysisOrderDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._HemodialysisOrderDetail);
                PreScript_HemodialysisOrderDetailForm(viewModel, viewModel._HemodialysisOrderDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel HemodialysisOrderDetailForm(HemodialysisOrderDetailFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return HemodialysisOrderDetailFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel HemodialysisOrderDetailFormInternal(HemodialysisOrderDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2cd32cd4-8596-4ed6-81a8-4d54b5f6d9b0");
        objectContext.AddToRawObjectList(viewModel.SKRSAntihipertansifIlacKullanimDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSPeritonDiyaliziKomplikasyons);
        objectContext.AddToRawObjectList(viewModel.SKRSPeritonDiyalizTunelYonus);
        objectContext.AddToRawObjectList(viewModel.SKRSPeritonDiyalizKateterYerlestirmeYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSPeritonDiyaliziKateterTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSKullanilanDiyalizTedavisis);
        objectContext.AddToRawObjectList(viewModel.SKRSKATATERs);
        objectContext.AddToRawObjectList(viewModel.SKRSPeritonealGecirgenlikPETs);
        objectContext.AddToRawObjectList(viewModel.SKRSSinekalsets);
        objectContext.AddToRawObjectList(viewModel.SKRSOncekiRRTYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSFosforBaglayiciAjans);
        objectContext.AddToRawObjectList(viewModel.SKRSDiyalizeGirmeSikligis);
        objectContext.AddToRawObjectList(viewModel.SKRSKanAkimHizis);
        objectContext.AddToRawObjectList(viewModel.SKRSDiyalizorAlanis);
        objectContext.AddToRawObjectList(viewModel.SKRSDiyalizorTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSDamarErisimYolus);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.SKRSDiyalizTedavisiYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSTedavininSeyris);
        objectContext.AddToRawObjectList(viewModel.SKRSAktifVitaminDKullanimis);
        objectContext.AddToRawObjectList(viewModel.SKRSAnemiTedavisiYontemis);
        var entryStateID = Guid.Parse("ee2557f6-5ada-4df9-a705-000dcc9c10ab");
        objectContext.AddToRawObjectList(viewModel._HemodialysisOrderDetail, entryStateID);
        objectContext.ProcessRawObjects(false);
        var hemodialysisOrderDetail = (HemodialysisOrderDetail)objectContext.GetLoadedObject(viewModel._HemodialysisOrderDetail.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(hemodialysisOrderDetail, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisOrderDetail, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(hemodialysisOrderDetail);
        PostScript_HemodialysisOrderDetailForm(viewModel, hemodialysisOrderDetail, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hemodialysisOrderDetail);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hemodialysisOrderDetail);
        AfterContextSaveScript_HemodialysisOrderDetailForm(viewModel, hemodialysisOrderDetail, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_HemodialysisOrderDetailForm(HemodialysisOrderDetailFormViewModel viewModel, HemodialysisOrderDetail hemodialysisOrderDetail, TTObjectContext objectContext);
    partial void PostScript_HemodialysisOrderDetailForm(HemodialysisOrderDetailFormViewModel viewModel, HemodialysisOrderDetail hemodialysisOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_HemodialysisOrderDetailForm(HemodialysisOrderDetailFormViewModel viewModel, HemodialysisOrderDetail hemodialysisOrderDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(HemodialysisOrderDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSAntihipertansifIlacKullanimDurumus = objectContext.LocalQuery<SKRSAntihipertansifIlacKullanimDurumu>().ToArray();
        viewModel.SKRSPeritonDiyaliziKomplikasyons = objectContext.LocalQuery<SKRSPeritonDiyaliziKomplikasyon>().ToArray();
        viewModel.SKRSPeritonDiyalizTunelYonus = objectContext.LocalQuery<SKRSPeritonDiyalizTunelYonu>().ToArray();
        viewModel.SKRSPeritonDiyalizKateterYerlestirmeYontemis = objectContext.LocalQuery<SKRSPeritonDiyalizKateterYerlestirmeYontemi>().ToArray();
        viewModel.SKRSPeritonDiyaliziKateterTipis = objectContext.LocalQuery<SKRSPeritonDiyaliziKateterTipi>().ToArray();
        viewModel.SKRSKullanilanDiyalizTedavisis = objectContext.LocalQuery<SKRSKullanilanDiyalizTedavisi>().ToArray();
        viewModel.SKRSKATATERs = objectContext.LocalQuery<SKRSKATATER>().ToArray();
        viewModel.SKRSPeritonealGecirgenlikPETs = objectContext.LocalQuery<SKRSPeritonealGecirgenlikPET>().ToArray();
        viewModel.SKRSSinekalsets = objectContext.LocalQuery<SKRSSinekalset>().ToArray();
        viewModel.SKRSOncekiRRTYontemis = objectContext.LocalQuery<SKRSOncekiRRTYontemi>().ToArray();
        viewModel.SKRSFosforBaglayiciAjans = objectContext.LocalQuery<SKRSFosforBaglayiciAjan>().ToArray();
        viewModel.SKRSDiyalizeGirmeSikligis = objectContext.LocalQuery<SKRSDiyalizeGirmeSikligi>().ToArray();
        viewModel.SKRSKanAkimHizis = objectContext.LocalQuery<SKRSKanAkimHizi>().ToArray();
        viewModel.SKRSDiyalizorAlanis = objectContext.LocalQuery<SKRSDiyalizorAlani>().ToArray();
        viewModel.SKRSDiyalizorTipis = objectContext.LocalQuery<SKRSDiyalizorTipi>().ToArray();
        viewModel.SKRSDamarErisimYolus = objectContext.LocalQuery<SKRSDamarErisimYolu>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSDiyalizTedavisiYontemis = objectContext.LocalQuery<SKRSDiyalizTedavisiYontemi>().ToArray();
        viewModel.SKRSTedavininSeyris = objectContext.LocalQuery<SKRSTedavininSeyri>().ToArray();
        viewModel.SKRSAktifVitaminDKullanimis = objectContext.LocalQuery<SKRSAktifVitaminDKullanimi>().ToArray();
        viewModel.SKRSAnemiTedavisiYontemis = objectContext.LocalQuery<SKRSAnemiTedavisiYontemi>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPeritonDiyaliziKomplikasyonList", viewModel.SKRSPeritonDiyaliziKomplikasyons);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPeritonDiyalizTunelYonuList", viewModel.SKRSPeritonDiyalizTunelYonus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPeritonDiyalizKateterYerlestirmeYontemiList", viewModel.SKRSPeritonDiyalizKateterYerlestirmeYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPeritonDiyaliziKateterTipiList", viewModel.SKRSPeritonDiyaliziKateterTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKullanilanDiyalizTedavisiList", viewModel.SKRSKullanilanDiyalizTedavisis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKATATERList", viewModel.SKRSKATATERs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPeritonealGecirgenlikPETList", viewModel.SKRSPeritonealGecirgenlikPETs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSinekalsetList", viewModel.SKRSSinekalsets);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOncekiRRTYontemiList", viewModel.SKRSOncekiRRTYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSFosforBaglayiciAjanList", viewModel.SKRSFosforBaglayiciAjans);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyalizeGirmeSikligiList", viewModel.SKRSDiyalizeGirmeSikligis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKanAkimHiziList", viewModel.SKRSKanAkimHizis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyalizorAlaniList", viewModel.SKRSDiyalizorAlanis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyalizorTipiList", viewModel.SKRSDiyalizorTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDamarErisimYoluList", viewModel.SKRSDamarErisimYolus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorAndNurseList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoktorDefinitionList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDiyalizTedavisiYontemiList", viewModel.SKRSDiyalizTedavisiYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTedavininSeyriList", viewModel.SKRSTedavininSeyris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAktifVitaminDKullanimiList", viewModel.SKRSAktifVitaminDKullanimis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAnemiTedavisiYontemiList", viewModel.SKRSAnemiTedavisiYontemis);
    }
}
}


namespace Core.Models
{
    public partial class HemodialysisOrderDetailFormViewModel
    {
        public TTObjectClasses.HemodialysisOrderDetail _HemodialysisOrderDetail
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAntihipertansifIlacKullanimDurumu[] SKRSAntihipertansifIlacKullanimDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPeritonDiyaliziKomplikasyon[] SKRSPeritonDiyaliziKomplikasyons
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPeritonDiyalizTunelYonu[] SKRSPeritonDiyalizTunelYonus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPeritonDiyalizKateterYerlestirmeYontemi[] SKRSPeritonDiyalizKateterYerlestirmeYontemis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPeritonDiyaliziKateterTipi[] SKRSPeritonDiyaliziKateterTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKullanilanDiyalizTedavisi[] SKRSKullanilanDiyalizTedavisis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKATATER[] SKRSKATATERs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPeritonealGecirgenlikPET[] SKRSPeritonealGecirgenlikPETs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSSinekalset[] SKRSSinekalsets
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSOncekiRRTYontemi[] SKRSOncekiRRTYontemis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSFosforBaglayiciAjan[] SKRSFosforBaglayiciAjans
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDiyalizeGirmeSikligi[] SKRSDiyalizeGirmeSikligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKanAkimHizi[] SKRSKanAkimHizis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDiyalizorAlani[] SKRSDiyalizorAlanis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDiyalizorTipi[] SKRSDiyalizorTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDamarErisimYolu[] SKRSDamarErisimYolus
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDiyalizTedavisiYontemi[] SKRSDiyalizTedavisiYontemis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTedavininSeyri[] SKRSTedavininSeyris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAktifVitaminDKullanimi[] SKRSAktifVitaminDKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAnemiTedavisiYontemi[] SKRSAnemiTedavisiYontemis
        {
            get;
            set;
        }
    }
}
