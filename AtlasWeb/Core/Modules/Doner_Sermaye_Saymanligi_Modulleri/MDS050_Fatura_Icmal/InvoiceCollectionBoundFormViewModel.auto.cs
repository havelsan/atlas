//$3897B75D
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
    public partial class InvoiceCollectionServiceController : Controller
{
    [HttpGet]
    public InvoiceCollectionBoundFormViewModel InvoiceCollectionBoundForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InvoiceCollectionBoundFormLoadInternal(input);
    }

    [HttpPost]
    public InvoiceCollectionBoundFormViewModel InvoiceCollectionBoundFormLoad(FormLoadInput input)
    {
        return InvoiceCollectionBoundFormLoadInternal(input);
    }

    private InvoiceCollectionBoundFormViewModel InvoiceCollectionBoundFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("084dcb0d-4d0c-4c7f-965c-9a8613889f4b");
        var objectDefID = Guid.Parse("9d6ea7fd-a5b2-40f9-81fb-06f2dc01d3ca");
        var viewModel = new InvoiceCollectionBoundFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InvoiceCollection = objectContext.GetObject(id.Value, objectDefID) as InvoiceCollection;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InvoiceCollection, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InvoiceCollection, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InvoiceCollection);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InvoiceCollection);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InvoiceCollectionBoundForm(viewModel, viewModel._InvoiceCollection, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InvoiceCollection = new InvoiceCollection(objectContext);
                var entryStateID = Guid.Parse("b43f4bed-22bf-47f3-8e66-e27bf4104bba");
                viewModel._InvoiceCollection.CurrentStateDefID = entryStateID;
                viewModel.ttgrid1GridList = new TTObjectClasses.InvoiceCollectionDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InvoiceCollection, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InvoiceCollection, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InvoiceCollection);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InvoiceCollection);
                PreScript_InvoiceCollectionBoundForm(viewModel, viewModel._InvoiceCollection, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void InvoiceCollectionBoundForm(InvoiceCollectionBoundFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("084dcb0d-4d0c-4c7f-965c-9a8613889f4b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.PayerInvoiceDocuments);
            objectContext.AddToRawObjectList(viewModel.InvoiceTerms);
            objectContext.AddToRawObjectList(viewModel.ProvizyonTipis);
            objectContext.AddToRawObjectList(viewModel.TedaviTurus);
            objectContext.AddToRawObjectList(viewModel.TedaviTipis);
            objectContext.AddToRawObjectList(viewModel.PayerDefinitions);
            objectContext.AddToRawObjectList(viewModel.TakipTipis);
            objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
            var entryStateID = Guid.Parse("b43f4bed-22bf-47f3-8e66-e27bf4104bba");
            objectContext.AddToRawObjectList(viewModel._InvoiceCollection, entryStateID);
            objectContext.ProcessRawObjects(false);
            var invoiceCollection = (InvoiceCollection)objectContext.GetLoadedObject(viewModel._InvoiceCollection.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(invoiceCollection, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InvoiceCollection, formDefID);
            if (viewModel.ttgrid1GridList != null)
            {
                foreach (var item in viewModel.ttgrid1GridList)
                {
                    var iNVOICECOLLECTIONDETAILSImported = (InvoiceCollectionDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)iNVOICECOLLECTIONDETAILSImported).IsDeleted)
                        continue;
                    iNVOICECOLLECTIONDETAILSImported.InvoiceCollection = invoiceCollection;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(invoiceCollection);
            PostScript_InvoiceCollectionBoundForm(viewModel, invoiceCollection, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(invoiceCollection);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(invoiceCollection);
            AfterContextSaveScript_InvoiceCollectionBoundForm(viewModel, invoiceCollection, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }
    }

    partial void PreScript_InvoiceCollectionBoundForm(InvoiceCollectionBoundFormViewModel viewModel, InvoiceCollection invoiceCollection, TTObjectContext objectContext);
    partial void PostScript_InvoiceCollectionBoundForm(InvoiceCollectionBoundFormViewModel viewModel, InvoiceCollection invoiceCollection, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InvoiceCollectionBoundForm(InvoiceCollectionBoundFormViewModel viewModel, InvoiceCollection invoiceCollection, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InvoiceCollectionBoundFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ttgrid1GridList = viewModel._InvoiceCollection.InvoiceCollectionDetails.OfType<InvoiceCollectionDetail>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.PayerInvoiceDocuments = objectContext.LocalQuery<PayerInvoiceDocument>().ToArray();
        viewModel.InvoiceTerms = objectContext.LocalQuery<InvoiceTerm>().ToArray();
        //viewModel.ProvizyonTipis = objectContext.LocalQuery<ProvizyonTipi>().ToArray();
        viewModel.TedaviTurus = objectContext.LocalQuery<TedaviTuru>().ToArray();
        //viewModel.TedaviTipis = objectContext.LocalQuery<TedaviTipi>().ToArray();
        viewModel.PayerDefinitions = objectContext.LocalQuery<PayerDefinition>().ToArray();
        //viewModel.TakipTipis = objectContext.LocalQuery<TakipTipi>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "InvoiceTermList", viewModel.InvoiceTerms);
        // ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProvizyonTipiListDefinition", viewModel.ProvizyonTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TedaviTuruListDefinition", viewModel.TedaviTurus);
        //ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TedaviTipiListDefinition", viewModel.TedaviTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PayerListDefinition", viewModel.PayerDefinitions);
    //ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TakipTipiListDefinition", viewModel.TakipTipis);
    }
}
}


namespace Core.Models
{
    public partial class InvoiceCollectionBoundFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InvoiceCollection _InvoiceCollection { get; set; }
        public TTObjectClasses.InvoiceCollectionDetail[] ttgrid1GridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.PayerInvoiceDocument[] PayerInvoiceDocuments { get; set; }
        public TTObjectClasses.InvoiceTerm[] InvoiceTerms { get; set; }
        public TTObjectClasses.ProvizyonTipi[] ProvizyonTipis { get; set; }
        public TTObjectClasses.TedaviTuru[] TedaviTurus { get; set; }
        public TTObjectClasses.TedaviTipi[] TedaviTipis { get; set; }
        public TTObjectClasses.PayerDefinition[] PayerDefinitions { get; set; }
        public TTObjectClasses.TakipTipi[] TakipTipis { get; set; }
    }
}
