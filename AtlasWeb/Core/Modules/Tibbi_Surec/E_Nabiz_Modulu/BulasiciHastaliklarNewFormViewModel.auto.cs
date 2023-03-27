//$887D3069
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
    public partial class BulasiciHastalikVeriSetiServiceController : Controller
{
    [HttpGet]
    public BulasiciHastaliklarNewFormViewModel BulasiciHastaliklarNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BulasiciHastaliklarNewFormLoadInternal(input);
    }

    [HttpPost]
    public BulasiciHastaliklarNewFormViewModel BulasiciHastaliklarNewFormLoad(FormLoadInput input)
    {
        return BulasiciHastaliklarNewFormLoadInternal(input);
    }

    private BulasiciHastaliklarNewFormViewModel BulasiciHastaliklarNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("32669a14-3fb4-4300-aff4-83395b9d94ac");
        var objectDefID = Guid.Parse("b57252e3-eaf6-4000-9990-d7d116aed67a");
        var viewModel = new BulasiciHastaliklarNewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BulasiciHastalikVeriSeti = objectContext.GetObject(id.Value, objectDefID) as BulasiciHastalikVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BulasiciHastalikVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulasiciHastalikVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BulasiciHastalikVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BulasiciHastalikVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BulasiciHastaliklarNewForm(viewModel, viewModel._BulasiciHastalikVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BulasiciHastalikVeriSeti = new BulasiciHastalikVeriSeti(objectContext);
                viewModel.BulasiciHastalikTelefonGridList = new TTObjectClasses.BulasiciHastalikTelefon[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BulasiciHastalikVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulasiciHastalikVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BulasiciHastalikVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BulasiciHastalikVeriSeti);
                PreScript_BulasiciHastaliklarNewForm(viewModel, viewModel._BulasiciHastalikVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BulasiciHastaliklarNewForm(BulasiciHastaliklarNewFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BulasiciHastaliklarNewFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BulasiciHastaliklarNewFormInternal(BulasiciHastaliklarNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("32669a14-3fb4-4300-aff4-83395b9d94ac");
        objectContext.AddToRawObjectList(viewModel.SKRSTelefonTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSCSBMTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSMahalleKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSKoyKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSBucakKodlaris);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.SKRSICDs);
        objectContext.AddToRawObjectList(viewModel.SKRSVakaTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSIlceKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
        objectContext.AddToRawObjectList(viewModel.BulasiciHastalikTelefonGridList);
        objectContext.AddToRawObjectList(viewModel._BulasiciHastalikVeriSeti);
        objectContext.ProcessRawObjects();
        var bulasiciHastalikVeriSeti = (BulasiciHastalikVeriSeti)objectContext.GetLoadedObject(viewModel._BulasiciHastalikVeriSeti.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(bulasiciHastalikVeriSeti, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulasiciHastalikVeriSeti, formDefID);
        if (viewModel.BulasiciHastalikTelefonGridList != null)
        {
            foreach (var item in viewModel.BulasiciHastalikTelefonGridList)
            {
                var bulasiciHastalikTelefonImported = (BulasiciHastalikTelefon)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)bulasiciHastalikTelefonImported).IsDeleted)
                    continue;
                bulasiciHastalikTelefonImported.BulasiciHastalikVeriSeti = bulasiciHastalikVeriSeti;
            }
        }

        var transDef = bulasiciHastalikVeriSeti.TransDef;
        PostScript_BulasiciHastaliklarNewForm(viewModel, bulasiciHastalikVeriSeti, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bulasiciHastalikVeriSeti);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bulasiciHastalikVeriSeti);
        AfterContextSaveScript_BulasiciHastaliklarNewForm(viewModel, bulasiciHastalikVeriSeti, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BulasiciHastaliklarNewForm(BulasiciHastaliklarNewFormViewModel viewModel, BulasiciHastalikVeriSeti bulasiciHastalikVeriSeti, TTObjectContext objectContext);
    partial void PostScript_BulasiciHastaliklarNewForm(BulasiciHastaliklarNewFormViewModel viewModel, BulasiciHastalikVeriSeti bulasiciHastalikVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BulasiciHastaliklarNewForm(BulasiciHastaliklarNewFormViewModel viewModel, BulasiciHastalikVeriSeti bulasiciHastalikVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BulasiciHastaliklarNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.BulasiciHastalikTelefonGridList = viewModel._BulasiciHastalikVeriSeti.BulasiciHastalikTelefon.OfType<BulasiciHastalikTelefon>().ToArray();
        viewModel.SKRSTelefonTipis = objectContext.LocalQuery<SKRSTelefonTipi>().ToArray();
        viewModel.SKRSCSBMTipis = objectContext.LocalQuery<SKRSCSBMTipi>().ToArray();
        viewModel.SKRSMahalleKodlaris = objectContext.LocalQuery<SKRSMahalleKodlari>().ToArray();
        viewModel.SKRSKoyKodlaris = objectContext.LocalQuery<SKRSKoyKodlari>().ToArray();
        viewModel.SKRSBucakKodlaris = objectContext.LocalQuery<SKRSBucakKodlari>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSVakaTipis = objectContext.LocalQuery<SKRSVakaTipi>().ToArray();
        viewModel.SKRSIlceKodlaris = objectContext.LocalQuery<SKRSIlceKodlari>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTelefonTipiList", viewModel.SKRSTelefonTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCSBMTipiList", viewModel.SKRSCSBMTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMahalleKodlariList", viewModel.SKRSMahalleKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKoyKodlariList", viewModel.SKRSKoyKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBucakKodlariList", viewModel.SKRSBucakKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSVakaTipiList", viewModel.SKRSVakaTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlceKodlariList", viewModel.SKRSIlceKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSILKodlariList", viewModel.SKRSILKodlaris);
    }
}
}


namespace Core.Models
{
    public partial class BulasiciHastaliklarNewFormViewModel
    {
        public TTObjectClasses.BulasiciHastalikVeriSeti _BulasiciHastalikVeriSeti
        {
            get;
            set;
        }

        public TTObjectClasses.BulasiciHastalikTelefon[] BulasiciHastalikTelefonGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTelefonTipi[] SKRSTelefonTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCSBMTipi[] SKRSCSBMTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMahalleKodlari[] SKRSMahalleKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKoyKodlari[] SKRSKoyKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBucakKodlari[] SKRSBucakKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSICD[] SKRSICDs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSVakaTipi[] SKRSVakaTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIlceKodlari[] SKRSIlceKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris
        {
            get;
            set;
        }
    }
}
