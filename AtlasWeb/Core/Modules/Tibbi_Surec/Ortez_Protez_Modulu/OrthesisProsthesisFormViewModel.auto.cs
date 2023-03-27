//$3E271634
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
    public partial class OrthesisProsthesisRequestServiceController : Controller
{
    [HttpGet]
    public OrthesisProsthesisFormViewModel OrthesisProsthesisForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OrthesisProsthesisFormLoadInternal(input);
    }

    [HttpPost]
    public OrthesisProsthesisFormViewModel OrthesisProsthesisFormLoad(FormLoadInput input)
    {
        return OrthesisProsthesisFormLoadInternal(input);
    }

    private OrthesisProsthesisFormViewModel OrthesisProsthesisFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4c65c709-e360-4b44-8e13-bd02d7ed569f");
        var objectDefID = Guid.Parse("29f8be50-7930-426f-94f5-83536cc7a4c4");
        var viewModel = new OrthesisProsthesisFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OrthesisProsthesisRequest = objectContext.GetObject(id.Value, objectDefID) as OrthesisProsthesisRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._OrthesisProsthesisRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._OrthesisProsthesisRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OrthesisProsthesisForm(viewModel, viewModel._OrthesisProsthesisRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OrthesisProsthesisForm(OrthesisProsthesisFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4c65c709-e360-4b44-8e13-bd02d7ed569f");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.MalzemeTurus);
            objectContext.AddToRawObjectList(viewModel.DPADetailFirmPriceOffers);
            objectContext.AddToRawObjectList(viewModel.ProductDefinitions);
            objectContext.AddToRawObjectList(viewModel.DirectPurchaseActionDetails);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.OrthesisProsthesisProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.TreatmentMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.OPDirectPurchaseGridGridList);
            objectContext.AddToRawObjectList(viewModel.CodelessMaterialDirectPurchaseGridsGridList);
            objectContext.AddToRawObjectList(viewModel.ReturnDescriptionGridGridList);
            objectContext.AddToRawObjectList(viewModel._OrthesisProsthesisRequest);
            objectContext.ProcessRawObjects();
            var orthesisProsthesisRequest = (OrthesisProsthesisRequest)objectContext.GetLoadedObject(viewModel._OrthesisProsthesisRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(orthesisProsthesisRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OrthesisProsthesisRequest, formDefID);
            if (viewModel.OrthesisProsthesisProceduresGridList != null)
            {
                foreach (var item in viewModel.OrthesisProsthesisProceduresGridList)
                {
                    var orthesisProsthesisProceduresImported = (OrthesisProsthesisProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)orthesisProsthesisProceduresImported).IsDeleted)
                        continue;
                    orthesisProsthesisProceduresImported.OrthesisProsthesisRequest = orthesisProsthesisRequest;
                }
            }

            if (viewModel.TreatmentMaterialsGridList != null)
            {
                foreach (var item in viewModel.TreatmentMaterialsGridList)
                {
                    var orthesisProthesisReqTreatmentMaterialsImported = (OrthesisProthesisRequestTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)orthesisProthesisReqTreatmentMaterialsImported).IsDeleted)
                        continue;
                    orthesisProthesisReqTreatmentMaterialsImported.EpisodeAction = orthesisProsthesisRequest;
                }
            }

            if (viewModel.OPDirectPurchaseGridGridList != null)
            {
                foreach (var item in viewModel.OPDirectPurchaseGridGridList)
                {
                    var orthesisProsthesisRequest_OPDirectPurchaseGridsImported = (SurgeryDirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)orthesisProsthesisRequest_OPDirectPurchaseGridsImported).IsDeleted)
                        continue;
                    orthesisProsthesisRequest_OPDirectPurchaseGridsImported.EpisodeAction = orthesisProsthesisRequest;
                }
            }

            if (viewModel.CodelessMaterialDirectPurchaseGridsGridList != null)
            {
                foreach (var item in viewModel.CodelessMaterialDirectPurchaseGridsGridList)
                {
                    var oPRequest_CodelessMaterialDirectPurchaseGridsImported = (CodelessMaterialDirectPurchaseGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)oPRequest_CodelessMaterialDirectPurchaseGridsImported).IsDeleted)
                        continue;
                    oPRequest_CodelessMaterialDirectPurchaseGridsImported.EpisodeAction = orthesisProsthesisRequest;
                }
            }

            if (viewModel.ReturnDescriptionGridGridList != null)
            {
                foreach (var item in viewModel.ReturnDescriptionGridGridList)
                {
                    var returnDescriptionsImported = (OrthesisProsthesis_ReturnDescriptionsGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)returnDescriptionsImported).IsDeleted)
                        continue;
                    returnDescriptionsImported.OrthesisProsthesisRequest = orthesisProsthesisRequest;
                }
            }

            var transDef = orthesisProsthesisRequest.TransDef;
            PostScript_OrthesisProsthesisForm(viewModel, orthesisProsthesisRequest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(orthesisProsthesisRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(orthesisProsthesisRequest);
            AfterContextSaveScript_OrthesisProsthesisForm(viewModel, orthesisProsthesisRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OrthesisProsthesisForm(OrthesisProsthesisFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTObjectContext objectContext);
    partial void PostScript_OrthesisProsthesisForm(OrthesisProsthesisFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OrthesisProsthesisForm(OrthesisProsthesisFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OrthesisProsthesisFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.OrthesisProsthesisProceduresGridList = viewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.OfType<OrthesisProsthesisProcedure>().ToArray();
        viewModel.TreatmentMaterialsGridList = viewModel._OrthesisProsthesisRequest.OrthesisProthesisReqTreatmentMaterials.OfType<OrthesisProthesisRequestTreatmentMaterial>().ToArray();
        viewModel.OPDirectPurchaseGridGridList = viewModel._OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids.OfType<SurgeryDirectPurchaseGrid>().ToArray();
        viewModel.CodelessMaterialDirectPurchaseGridsGridList = viewModel._OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids.OfType<CodelessMaterialDirectPurchaseGrid>().ToArray();
        viewModel.ReturnDescriptionGridGridList = viewModel._OrthesisProsthesisRequest.ReturnDescriptions.OfType<OrthesisProsthesis_ReturnDescriptionsGrid>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.AyniFarkliKesis = objectContext.LocalQuery<AyniFarkliKesi>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.MalzemeTurus = objectContext.LocalQuery<MalzemeTuru>().ToArray();
        viewModel.DPADetailFirmPriceOffers = objectContext.LocalQuery<DPADetailFirmPriceOffer>().ToArray();
        viewModel.ProductDefinitions = objectContext.LocalQuery<ProductDefinition>().ToArray();
        viewModel.DirectPurchaseActionDetails = objectContext.LocalQuery<DirectPurchaseActionDetail>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OrtesisProsthesisListDefinition", viewModel.ProcedureDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TechnicianList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AyniFarkliKesiListDefinition", viewModel.AyniFarkliKesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MalzemeTuruListDefinition", viewModel.MalzemeTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DirectPurchaseActionDetailList", viewModel.DPADetailFirmPriceOffers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CodelessMaterialDPADetailList", viewModel.DPADetailFirmPriceOffers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class OrthesisProsthesisFormViewModel : BaseViewModel
    {
        public TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest { get; set; }
        public TTObjectClasses.OrthesisProsthesisProcedure[] OrthesisProsthesisProceduresGridList { get; set; }
        public TTObjectClasses.OrthesisProthesisRequestTreatmentMaterial[] TreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.SurgeryDirectPurchaseGrid[] OPDirectPurchaseGridGridList { get; set; }
        public TTObjectClasses.CodelessMaterialDirectPurchaseGrid[] CodelessMaterialDirectPurchaseGridsGridList { get; set; }
        public TTObjectClasses.OrthesisProsthesis_ReturnDescriptionsGrid[] ReturnDescriptionGridGridList { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.AyniFarkliKesi[] AyniFarkliKesis { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.MalzemeTuru[] MalzemeTurus { get; set; }
        public TTObjectClasses.DPADetailFirmPriceOffer[] DPADetailFirmPriceOffers { get; set; }
        public TTObjectClasses.ProductDefinition[] ProductDefinitions { get; set; }
        public TTObjectClasses.DirectPurchaseActionDetail[] DirectPurchaseActionDetails { get; set; }
        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions { get; set; }
    }
}
