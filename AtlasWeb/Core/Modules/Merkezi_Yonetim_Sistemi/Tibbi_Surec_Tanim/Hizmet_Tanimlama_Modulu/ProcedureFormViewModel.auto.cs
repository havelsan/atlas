//$B686DB50
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
    public partial class ProcedureDefinitionServiceController : Controller
{
    [HttpGet]
    public ProcedureFormViewModel ProcedureForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ProcedureFormLoadInternal(input);
    }

    [HttpPost]
    public ProcedureFormViewModel ProcedureFormLoad(FormLoadInput input)
    {
        return ProcedureFormLoadInternal(input);
    }

    private ProcedureFormViewModel ProcedureFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("77d576d2-5ef5-4462-a9ea-da15c2c35966");
        var objectDefID = Guid.Parse("3d2f1e54-0d74-468f-b931-4c51ac60b090");
        var viewModel = new ProcedureFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ProcedureDefinition = objectContext.GetObject(id.Value, objectDefID) as ProcedureDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ProcedureDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProcedureDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ProcedureDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ProcedureDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ProcedureForm(viewModel, viewModel._ProcedureDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ProcedureDefinition = new ProcedureDefinition(objectContext);
                viewModel.GridSubProceduresGridList = new TTObjectClasses.SubProcedureDefinition[]{};
                viewModel.GridRequiredDiagnosisGridList = new TTObjectClasses.RequiredDiagnoseProcedure[] { };
                viewModel.grdPricesGridList = new TTObjectClasses.ProcedurePriceDefinition[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ProcedureDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProcedureDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ProcedureDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ProcedureDefinition);
                PreScript_ProcedureForm(viewModel, viewModel._ProcedureDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ProcedureForm(ProcedureFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ProcedureFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ProcedureFormInternal(ProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("77d576d2-5ef5-4462-a9ea-da15c2c35966");
        objectContext.AddToRawObjectList(viewModel.GILDefinitions);
        objectContext.AddToRawObjectList(viewModel.PackageProcedureDefinitions);
        objectContext.AddToRawObjectList(viewModel.RevenueSubAccountCodeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
        objectContext.AddToRawObjectList(viewModel.TedaviTipis);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.TakipTipis);
        objectContext.AddToRawObjectList(viewModel.ProvizyonTipis);
        objectContext.AddToRawObjectList(viewModel.OzelDurums);
        objectContext.AddToRawObjectList(viewModel.PricingDetailDefinitions);
        objectContext.AddToRawObjectList(viewModel.PricingListDefinitions);
        objectContext.AddToRawObjectList(viewModel.GridSubProceduresGridList);
        objectContext.AddToRawObjectList(viewModel.grdPricesGridList);
        objectContext.AddToRawObjectList(viewModel._ProcedureDefinition);
         objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
         objectContext.AddToRawObjectList(viewModel.GridRequiredDiagnosisGridList);
            objectContext.ProcessRawObjects();
        var procedureDefinition = (ProcedureDefinition)objectContext.GetLoadedObject(viewModel._ProcedureDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(procedureDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProcedureDefinition, formDefID);

            if (viewModel.GridRequiredDiagnosisGridList != null)
            {
                foreach (var item in viewModel.GridRequiredDiagnosisGridList)
                {
                    var requiredDiagnoseProceduresImported = (RequiredDiagnoseProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)requiredDiagnoseProceduresImported).IsDeleted)
                        continue;
                    requiredDiagnoseProceduresImported.ProcedureDefinition = procedureDefinition;
                }
            }
            if (viewModel.GridSubProceduresGridList != null)
        {
            foreach (var item in viewModel.GridSubProceduresGridList)
            {
                var subProcedureDefinitionsImported = (SubProcedureDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)subProcedureDefinitionsImported).IsDeleted)
                    continue;
                subProcedureDefinitionsImported.ParentProcedureDefinition = procedureDefinition;
            }
        }

        if (viewModel.grdPricesGridList != null)
        {
            foreach (var item in viewModel.grdPricesGridList)
            {
                var procedurePriceImported = (ProcedurePriceDefinition)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)procedurePriceImported).IsDeleted)
                    continue;
                procedurePriceImported.ProcedureObject = procedureDefinition;
            }
        }

        var transDef = procedureDefinition.TransDef;
        PostScript_ProcedureForm(viewModel, procedureDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(procedureDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(procedureDefinition);
        AfterContextSaveScript_ProcedureForm(viewModel, procedureDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ProcedureForm(ProcedureFormViewModel viewModel, ProcedureDefinition procedureDefinition, TTObjectContext objectContext);
    partial void PostScript_ProcedureForm(ProcedureFormViewModel viewModel, ProcedureDefinition procedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ProcedureForm(ProcedureFormViewModel viewModel, ProcedureDefinition procedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ProcedureFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GridSubProceduresGridList = viewModel._ProcedureDefinition.SubProcedureDefinitions.OfType<SubProcedureDefinition>().ToArray();
        viewModel.grdPricesGridList = viewModel._ProcedureDefinition.ProcedurePrice.OfType<ProcedurePriceDefinition>().ToArray();
        viewModel.GILDefinitions = objectContext.LocalQuery<GILDefinition>().ToArray();
        viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
        viewModel.RevenueSubAccountCodeDefinitions = objectContext.LocalQuery<RevenueSubAccountCodeDefinition>().ToArray();
        viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.TedaviTipis = objectContext.LocalQuery<TedaviTipi>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.TakipTipis = objectContext.LocalQuery<TakipTipi>().ToArray();
        viewModel.ProvizyonTipis = objectContext.LocalQuery<ProvizyonTipi>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.PricingDetailDefinitions = objectContext.LocalQuery<PricingDetailDefinition>().ToArray();
        viewModel.PricingListDefinitions = objectContext.LocalQuery<PricingListDefinition>().ToArray();

        viewModel.GridRequiredDiagnosisGridList = viewModel._ProcedureDefinition.RequiredDiagnoseProcedures.OfType<RequiredDiagnoseProcedure>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GILListDefinition", viewModel.GILDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PackageProcedureListDefinition", viewModel.PackageProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RevenueSubAccountCodeDefList", viewModel.RevenueSubAccountCodeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TedaviTipiListDefinition", viewModel.TedaviTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TakipTipiListDefinition", viewModel.TakipTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProvizyonTipiListDefinition", viewModel.ProvizyonTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PricingDetailListDefinition", viewModel.PricingDetailDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PricingListListDefinition", viewModel.PricingListDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        }
}
}


namespace Core.Models
{
    public partial class ProcedureFormViewModel
    {
        public TTObjectClasses.ProcedureDefinition _ProcedureDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.SubProcedureDefinition[] GridSubProceduresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedurePriceDefinition[] grdPricesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.GILDefinition[] GILDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.PackageProcedureDefinition[] PackageProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RevenueSubAccountCodeDefinition[] RevenueSubAccountCodeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.TedaviTipi[] TedaviTipis
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.TakipTipi[] TakipTipis
        {
            get;
            set;
        }

        public TTObjectClasses.ProvizyonTipi[] ProvizyonTipis
        {
            get;
            set;
        }

        public TTObjectClasses.OzelDurum[] OzelDurums
        {
            get;
            set;
        }

        public TTObjectClasses.PricingDetailDefinition[] PricingDetailDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.PricingListDefinition[] PricingListDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.RequiredDiagnoseProcedure[] GridRequiredDiagnosisGridList
        {
            get;
            set;
        }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }

    }
}
