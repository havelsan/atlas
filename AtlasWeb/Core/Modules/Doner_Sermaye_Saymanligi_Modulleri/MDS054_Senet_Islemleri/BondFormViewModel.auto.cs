//$C7C0B9B0
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
    public partial class BondServiceController : Controller
{
    [HttpGet]
    public BondFormViewModel BondForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BondFormLoadInternal(input);
    }

    [HttpPost]
    public BondFormViewModel BondFormLoad(FormLoadInput input)
    {
        return BondFormLoadInternal(input);
    }

    private BondFormViewModel BondFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("b524ffab-b6b7-4904-8361-a1545eaba352");
        var objectDefID = Guid.Parse("f2beef18-02b8-455d-9346-bfee74bc507c");
        var viewModel = new BondFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Bond = objectContext.GetObject(id.Value, objectDefID) as Bond;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Bond, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Bond, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Bond);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Bond);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BondForm(viewModel, viewModel._Bond, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Bond = new Bond(objectContext);
                var entryStateID = Guid.Parse("9fa90413-e8c9-4f04-8f8a-3462b7ee02a5");
                viewModel._Bond.CurrentStateDefID = entryStateID;
                viewModel.GrdBondDetailsGridList = new TTObjectClasses.BondDetail[]{};
                viewModel.GrdBondProcedureGridList = new TTObjectClasses.BondProcedure[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Bond, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Bond, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Bond);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Bond);
                PreScript_BondForm(viewModel, viewModel._Bond, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BondForm(BondFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("b524ffab-b6b7-4904-8361-a1545eaba352");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BondPersons);
            objectContext.AddToRawObjectList(viewModel.SKRSIlceKodlaris);
            objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
            objectContext.AddToRawObjectList(viewModel.BondDocuments);
            objectContext.AddToRawObjectList(viewModel.GrdBondDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.GrdBondProcedureGridList);
            var entryStateID = Guid.Parse("9fa90413-e8c9-4f04-8f8a-3462b7ee02a5");
            objectContext.AddToRawObjectList(viewModel._Bond, entryStateID);
            objectContext.ProcessRawObjects(false);
            var bond = (Bond)objectContext.GetLoadedObject(viewModel._Bond.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(bond, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Bond, formDefID);
            if (viewModel.GrdBondDetailsGridList != null)
            {
                foreach (var item in viewModel.GrdBondDetailsGridList)
                {
                    var bondDetailsImported = (BondDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)bondDetailsImported).IsDeleted)
                        continue;
                    bondDetailsImported.Bond = bond;
                }
            }

            if (viewModel.GrdBondProcedureGridList != null)
            {
                foreach (var item in viewModel.GrdBondProcedureGridList)
                {
                    var bONDPROCEDURESImported = (BondProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)bONDPROCEDURESImported).IsDeleted)
                        continue;
                    bONDPROCEDURESImported.Bond = bond;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(bond);
            PostScript_BondForm(viewModel, bond, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bond);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bond);
            AfterContextSaveScript_BondForm(viewModel, bond, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BondForm(BondFormViewModel viewModel, Bond bond, TTObjectContext objectContext);
    partial void PostScript_BondForm(BondFormViewModel viewModel, Bond bond, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BondForm(BondFormViewModel viewModel, Bond bond, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BondFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GrdBondDetailsGridList = viewModel._Bond.BondDetails.OfType<BondDetail>().ToArray();
        viewModel.GrdBondProcedureGridList = viewModel._Bond.BondProcedures.OfType<BondProcedure>().ToArray();
        viewModel.BondPersons = objectContext.LocalQuery<BondPerson>().ToArray();
        viewModel.SKRSIlceKodlaris = objectContext.LocalQuery<SKRSIlceKodlari>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.Bonds = objectContext.LocalQuery<Bond>().ToArray();
        viewModel.BondDocuments = objectContext.LocalQuery<BondDocument>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlceKodlariList", viewModel.SKRSIlceKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSILKodlariList", viewModel.SKRSILKodlaris);
    }
}
}


namespace Core.Models
{
    public partial class BondFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Bond _Bond { get; set; }
        public TTObjectClasses.BondDetail[] GrdBondDetailsGridList { get; set; }
        public TTObjectClasses.BondProcedure[] GrdBondProcedureGridList { get; set; }
        public TTObjectClasses.BondPerson[] BondPersons { get; set; }
        public TTObjectClasses.SKRSIlceKodlari[] SKRSIlceKodlaris { get; set; }
        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris { get; set; }
        public TTObjectClasses.Bond[] Bonds { get; set; }
        public TTObjectClasses.BondDocument[] BondDocuments { get; set; }
    }
}
