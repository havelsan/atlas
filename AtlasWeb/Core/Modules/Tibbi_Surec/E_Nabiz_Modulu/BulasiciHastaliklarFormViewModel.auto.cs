//$22549724
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
    public partial class BulasiciHastaliklarEAServiceController : Controller
{
    [HttpGet]
    public BulasiciHastaliklarFormViewModel BulasiciHastaliklarForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BulasiciHastaliklarFormLoadInternal(input);
    }

    [HttpPost]
    public BulasiciHastaliklarFormViewModel BulasiciHastaliklarFormLoad(FormLoadInput input)
    {
        return BulasiciHastaliklarFormLoadInternal(input);
    }

    private BulasiciHastaliklarFormViewModel BulasiciHastaliklarFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a40e271a-87cd-4264-8daf-d68ba3f7c9a5");
        var objectDefID = Guid.Parse("9a07a961-db2d-41a6-b294-3b5e4b1f8f8d");
        var viewModel = new BulasiciHastaliklarFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BulasiciHastaliklarEA = objectContext.GetObject(id.Value, objectDefID) as BulasiciHastaliklarEA;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BulasiciHastaliklarEA, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulasiciHastaliklarEA, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BulasiciHastaliklarEA);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BulasiciHastaliklarEA);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BulasiciHastaliklarForm(viewModel, viewModel._BulasiciHastaliklarEA, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BulasiciHastaliklarEA = new BulasiciHastaliklarEA(objectContext);
                var entryStateID = Guid.Parse("1cd4c112-dec9-42b0-968e-db4ef94da338");
                viewModel._BulasiciHastaliklarEA.CurrentStateDefID = entryStateID;
                viewModel.BulasiciHastalikTelefonBulasiciHastalikTelefonGridList = new TTObjectClasses.BulasiciHastalikTelefon[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BulasiciHastaliklarEA, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulasiciHastaliklarEA, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BulasiciHastaliklarEA);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BulasiciHastaliklarEA);
                PreScript_BulasiciHastaliklarForm(viewModel, viewModel._BulasiciHastaliklarEA, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BulasiciHastaliklarForm(BulasiciHastaliklarFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BulasiciHastaliklarFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BulasiciHastaliklarFormInternal(BulasiciHastaliklarFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a40e271a-87cd-4264-8daf-d68ba3f7c9a5");
        objectContext.AddToRawObjectList(viewModel.BulasiciHastalikVeriSetis);
        objectContext.AddToRawObjectList(viewModel.SKRSCSBMTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSMahalleKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSKoyKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSBucakKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSTelefonTipis);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.SKRSICDs);
        objectContext.AddToRawObjectList(viewModel.SKRSVakaTipis);
        objectContext.AddToRawObjectList(viewModel.SKRSIlceKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
        objectContext.AddToRawObjectList(viewModel.BulasiciHastalikTelefonBulasiciHastalikTelefonGridList);
        var entryStateID = Guid.Parse("1cd4c112-dec9-42b0-968e-db4ef94da338");
        objectContext.AddToRawObjectList(viewModel._BulasiciHastaliklarEA, entryStateID);
        objectContext.ProcessRawObjects(false);
        var bulasiciHastaliklarEA = (BulasiciHastaliklarEA)objectContext.GetLoadedObject(viewModel._BulasiciHastaliklarEA.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(bulasiciHastaliklarEA, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulasiciHastaliklarEA, formDefID);
        var bulasiciHastalikVeriSetiImported = bulasiciHastaliklarEA.BulasiciHastalikVeriSeti;
        if (bulasiciHastalikVeriSetiImported != null)
        {
            if (viewModel.BulasiciHastalikTelefonBulasiciHastalikTelefonGridList != null)
            {
                foreach (var item in viewModel.BulasiciHastalikTelefonBulasiciHastalikTelefonGridList)
                {
                    var bulasiciHastalikTelefonImported = (BulasiciHastalikTelefon)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)bulasiciHastalikTelefonImported).IsDeleted)
                        continue;
                    bulasiciHastalikTelefonImported.BulasiciHastalikVeriSeti = bulasiciHastalikVeriSetiImported;
                }
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(bulasiciHastaliklarEA);
        PostScript_BulasiciHastaliklarForm(viewModel, bulasiciHastaliklarEA, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bulasiciHastaliklarEA);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bulasiciHastaliklarEA);
        AfterContextSaveScript_BulasiciHastaliklarForm(viewModel, bulasiciHastaliklarEA, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BulasiciHastaliklarForm(BulasiciHastaliklarFormViewModel viewModel, BulasiciHastaliklarEA bulasiciHastaliklarEA, TTObjectContext objectContext);
    partial void PostScript_BulasiciHastaliklarForm(BulasiciHastaliklarFormViewModel viewModel, BulasiciHastaliklarEA bulasiciHastaliklarEA, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BulasiciHastaliklarForm(BulasiciHastaliklarFormViewModel viewModel, BulasiciHastaliklarEA bulasiciHastaliklarEA, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BulasiciHastaliklarFormViewModel viewModel, TTObjectContext objectContext)
    {
        var bulasiciHastalikVeriSeti = viewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti;
        if (bulasiciHastalikVeriSeti != null)
        {
            viewModel.BulasiciHastalikTelefonBulasiciHastalikTelefonGridList = bulasiciHastalikVeriSeti.BulasiciHastalikTelefon.OfType<BulasiciHastalikTelefon>().ToArray();
        }

        viewModel.BulasiciHastalikVeriSetis = objectContext.LocalQuery<BulasiciHastalikVeriSeti>().ToArray();
        viewModel.SKRSCSBMTipis = objectContext.LocalQuery<SKRSCSBMTipi>().ToArray();
        viewModel.SKRSMahalleKodlaris = objectContext.LocalQuery<SKRSMahalleKodlari>().ToArray();
        viewModel.SKRSKoyKodlaris = objectContext.LocalQuery<SKRSKoyKodlari>().ToArray();
        viewModel.SKRSBucakKodlaris = objectContext.LocalQuery<SKRSBucakKodlari>().ToArray();
        viewModel.SKRSTelefonTipis = objectContext.LocalQuery<SKRSTelefonTipi>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSVakaTipis = objectContext.LocalQuery<SKRSVakaTipi>().ToArray();
        viewModel.SKRSIlceKodlaris = objectContext.LocalQuery<SKRSIlceKodlari>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCSBMTipiList", viewModel.SKRSCSBMTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMahalleKodlariList", viewModel.SKRSMahalleKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKoyKodlariList", viewModel.SKRSKoyKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBucakKodlariList", viewModel.SKRSBucakKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTelefonTipiList", viewModel.SKRSTelefonTipis);
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
    public partial class BulasiciHastaliklarFormViewModel
    {
        public TTObjectClasses.BulasiciHastaliklarEA _BulasiciHastaliklarEA
        {
            get;
            set;
        }

        public TTObjectClasses.BulasiciHastalikTelefon[] BulasiciHastalikTelefonBulasiciHastalikTelefonGridList
        {
            get;
            set;
        }

        public TTObjectClasses.BulasiciHastalikVeriSeti[] BulasiciHastalikVeriSetis
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

        public TTObjectClasses.SKRSTelefonTipi[] SKRSTelefonTipis
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
