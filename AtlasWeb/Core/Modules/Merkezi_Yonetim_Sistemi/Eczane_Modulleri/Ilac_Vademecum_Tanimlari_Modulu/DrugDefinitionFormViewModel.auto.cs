//$C753758D
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class DrugDefinitionServiceController : Controller
    {
        [HttpGet]
        public DrugDefinitionFormViewModel DrugDefinitionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return DrugDefinitionFormLoadInternal(input);
        }

        [HttpPost]
        public DrugDefinitionFormViewModel DrugDefinitionFormLoad(FormLoadInput input)
        {
            return DrugDefinitionFormLoadInternal(input);
        }

        private DrugDefinitionFormViewModel DrugDefinitionFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("8c7cc7e1-765b-4db2-ac74-b2a01d273780");
            var objectDefID = Guid.Parse("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89");
            var viewModel = new DrugDefinitionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._DrugDefinition = objectContext.GetObject(id.Value, objectDefID) as DrugDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DrugDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DrugDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    var materialDocumentations = GetMaterialDocumentationDetails(viewModel._DrugDefinition);
                    if (materialDocumentations.Count > 0)
                    {
                        viewModel.MaterialDocumentations = materialDocumentations;
                    }

                    viewModel.DrugDrugInteractionsGridList = viewModel._DrugDefinition.DrugDrugInteractions.Select(string.Empty).ToArray();
                    List<DrugDrugInteraction> drugDrugInteractions = new List<DrugDrugInteraction>();
                    viewModel.interactionDrugs = new List<DrugDefinition>();
                    foreach (var item in viewModel._DrugDefinition.DrugDrugInteractions.Select(string.Empty))
                    {
                        drugDrugInteractions.Add(item);
                        viewModel.interactionDrugs.Add(item.InteractionDrug);
                    }
                    viewModel.DrugDrugInteractions = drugDrugInteractions.ToArray();


                    viewModel.DrugFoodInteractionsGridList = viewModel._DrugDefinition.DrugFoodInteractions.Select(string.Empty).ToArray();
                    List<DrugFoodInteraction> drugFoodInteractions = new List<DrugFoodInteraction>();
                    viewModel.dietMaterialDefinitions = new List<DietMaterialDefinition>();
                    foreach (var item in viewModel._DrugDefinition.DrugFoodInteractions.Select(string.Empty))
                    {
                        drugFoodInteractions.Add(item);
                        viewModel.dietMaterialDefinitions.Add(item.DietMaterialDefinition);
                    }
                    viewModel.DrugFoodInteractions = drugFoodInteractions.ToArray();

                    viewModel.RevenueSubAccountCodeDef = viewModel._DrugDefinition.RevenueSubAccountCode;

                    PreScript_DrugDefinitionForm(viewModel, viewModel._DrugDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._DrugDefinition = new DrugDefinition(objectContext);
                    viewModel.DrugATCsGridList = new TTObjectClasses.DrugATC[] { };
                    viewModel.DrugActiveIngredientsGridList = new TTObjectClasses.DrugActiveIngredient[] { };
                    viewModel.MaterialVatRatesGridList = new TTObjectClasses.MaterialVatRate[] { };
                    viewModel.DrugRelationsGridList = new TTObjectClasses.DrugRelation[] { };
                    viewModel.ManuelEquivalentDrugsGridList = new TTObjectClasses.ManuelEquivalentDrug[] { };
                    viewModel.DrugLabProcInteractionsGridList = new TTObjectClasses.DrugLabProcInteraction[] { };
                    viewModel.DrugDrugInteractionsGridList = new TTObjectClasses.DrugDrugInteraction[] { };
                    viewModel.DrugFoodInteractionsGridList = new TTObjectClasses.DrugFoodInteraction[] { };
                    //viewModel.grdDrugSpecificationGridList = new TTObjectClasses.DrugSpecifications[] { };
                    viewModel.grdMaterialProceduresGridList = new TTObjectClasses.MaterialProcedures[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DrugDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DrugDefinition);
                    PreScript_DrugDefinitionForm(viewModel, viewModel._DrugDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            //viewModel.DrugSpecs = viewModel.grdDrugSpecificationGridList.Select(p => (int)p.DrugSpecification.Value).ToArray();
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel DrugDefinitionForm(DrugDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return DrugDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel DrugDefinitionFormInternal(DrugDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("8c7cc7e1-765b-4db2-ac74-b2a01d273780");
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.EtkinMaddes);
            objectContext.AddToRawObjectList(viewModel.ATCs);
            objectContext.AddToRawObjectList(viewModel.UnitDefinitions);
            objectContext.AddToRawObjectList(viewModel.RouteOfAdmins);
            objectContext.AddToRawObjectList(viewModel.GenericDrugs);
            objectContext.AddToRawObjectList(viewModel.NFCs);
            objectContext.AddToRawObjectList(viewModel.ActiveIngredientDefinitions);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.Producers);
            objectContext.AddToRawObjectList(viewModel.GMDNDefinitions);
            objectContext.AddToRawObjectList(viewModel.LaboratoryTestDefinitions);
            objectContext.AddToRawObjectList(viewModel.MaterialTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.DrugATCsGridList);
            objectContext.AddToRawObjectList(viewModel.DrugActiveIngredientsGridList);
            //objectContext.AddToRawObjectList(viewModel.MaterialVatRatesGridList);
            objectContext.AddToRawObjectList(viewModel.DrugRelationsGridList);
            objectContext.AddToRawObjectList(viewModel.ManuelEquivalentDrugsGridList);
            objectContext.AddToRawObjectList(viewModel.DrugLabProcInteractionsGridList);
            objectContext.AddToRawObjectList(viewModel.DrugDrugInteractionsGridList);
            objectContext.AddToRawObjectList(viewModel.DrugDrugInteractions);
            objectContext.AddToRawObjectList(viewModel.DrugFoodInteractions);
            objectContext.AddToRawObjectList(viewModel.DrugFoodInteractionsGridList);
            //objectContext.AddToRawObjectList(viewModel.grdDrugSpecificationGridList);
            objectContext.AddToRawObjectList(viewModel.grdMaterialProceduresGridList);
            objectContext.AddToRawObjectList(viewModel._DrugDefinition);
            objectContext.ProcessRawObjects();
            var drugDefinition = (DrugDefinition)objectContext.GetLoadedObject(viewModel._DrugDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(drugDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugDefinition, formDefID);
            if (viewModel.DrugATCsGridList != null)
            {
                foreach (var item in viewModel.DrugATCsGridList)
                {
                    var drugATCsImported = (DrugATC)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugATCsImported).IsDeleted)
                        continue;
                    drugATCsImported.DrugDefinition = drugDefinition;
                }
            }

            if (viewModel.DrugActiveIngredientsGridList != null)
            {
                foreach (var item in viewModel.DrugActiveIngredientsGridList)
                {
                    var drugActiveIngredientsImported = (DrugActiveIngredient)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugActiveIngredientsImported).IsDeleted)
                        continue;
                    drugActiveIngredientsImported.DrugDefinition = drugDefinition;
                }
            }

          

            if (viewModel.DrugRelationsGridList != null)
            {
                foreach (var item in viewModel.DrugRelationsGridList)
                {
                    var drugRelationsImported = (DrugRelation)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugRelationsImported).IsDeleted)
                        continue;
                    drugRelationsImported.DrugDefinition = drugDefinition;
                }
            }


            if (viewModel.ManuelEquivalentDrugsGridList != null)
            {
                foreach (var item in viewModel.ManuelEquivalentDrugsGridList.Where(x => x.IsActive == true))
                {
                    var manuelEquivalentDrugsImported = (ManuelEquivalentDrug)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)manuelEquivalentDrugsImported).IsDeleted)
                        continue;
                    manuelEquivalentDrugsImported.DrugDefinition = drugDefinition;
                }
            }

            if (viewModel.DrugLabProcInteractionsGridList != null)
            {
                foreach (var item in viewModel.DrugLabProcInteractionsGridList)
                {
                    var drugLabProcInteractionsImported = (DrugLabProcInteraction)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugLabProcInteractionsImported).IsDeleted)
                        continue;
                    drugLabProcInteractionsImported.DrugDefinition = drugDefinition;
                }
            }

            if (viewModel.DrugDrugInteractionsGridList != null)
            {
                foreach (var item in viewModel.DrugDrugInteractionsGridList)
                {
                    var drugDrugInteractionsImported = (DrugDrugInteraction)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugDrugInteractionsImported).IsDeleted)
                        continue;
                    drugDrugInteractionsImported.DrugDefinition = drugDefinition;
                }
            }

            if (viewModel.DrugFoodInteractionsGridList != null)
            {
                foreach (var item in viewModel.DrugFoodInteractionsGridList)
                {
                    var drugFoodInteractionsImported = (DrugFoodInteraction)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugFoodInteractionsImported).IsDeleted)
                        continue;
                    drugFoodInteractionsImported.DrugDefinition = drugDefinition;
                }
            }


            if (viewModel.grdDrugSpecificationGridList != null)
            {
                foreach (var item in viewModel.grdDrugSpecificationGridList)
                {
                    var drugSpecificationsImported = (DrugSpecifications)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugSpecificationsImported).IsDeleted)
                        continue;
                    drugSpecificationsImported.DrugDefinition = drugDefinition;
                }
            }

            List<DrugSpecifications> drugSpecifications = objectContext.QueryObjects<DrugSpecifications>("DRUGDEFINITION = " + TTConnectionManager.ConnectionManager.GuidToString(drugDefinition.ObjectID)).ToList();
            foreach (DrugSpecifications item in drugSpecifications)
            {
                ((ITTObject)item).Delete();
            }
            if (viewModel.DrugSpecs != null && viewModel.DrugSpecs.Any())
            {
                foreach (var item in viewModel.DrugSpecs)
                {
                    var drugSpecification = new DrugSpecifications(objectContext);
                    drugSpecification.DrugSpecification = (DrugSpecificationEnum)item;
                    drugSpecification.DrugDefinition = objectContext.GetObject<DrugDefinition>(viewModel._DrugDefinition.ObjectID);
                }
            }

            if (viewModel._DrugDefinition.MaxPatientAge != null)
            {
                drugDefinition.MaxPatientAge = viewModel._DrugDefinition.MaxPatientAge;
            }

            if (viewModel._DrugDefinition.MinPatientAge != null)
            {
                drugDefinition.MinPatientAge = viewModel._DrugDefinition.MinPatientAge;
            }

            if (viewModel._DrugDefinition.SEX != null)
            {
                drugDefinition.SEX = viewModel._DrugDefinition.SEX;
            }

            if (viewModel._DrugDefinition.OrderRPTDay != null)
            {
                drugDefinition.OrderRPTDay = viewModel._DrugDefinition.OrderRPTDay;
            }


            if (viewModel._DrugDefinition.PatientMaxDayOut != null)
            {
                drugDefinition.PatientMaxDayOut = viewModel._DrugDefinition.PatientMaxDayOut;
            }

            if (viewModel._DrugDefinition.MaterialPatientType != null)
            {
                drugDefinition.MaterialPatientType = viewModel._DrugDefinition.MaterialPatientType;
            }

            if (viewModel._DrugDefinition.AllowToGivePatient != null)
            {
                drugDefinition.AllowToGivePatient = viewModel._DrugDefinition.AllowToGivePatient;
            }
            else
            {
                drugDefinition.AllowToGivePatient = false;//Zorunlu Alan Hastaya verilir verilmez.!
            }

            if (viewModel.StockCards.Length > 0)
            {
                foreach (StockCard item in viewModel.StockCards)
                {
                    var stockCard = objectContext.GetObject<StockCard>(item.ObjectID);
                    if (stockCard.MalzemeGetData != null)
                    {
                        drugDefinition.MkysMalzemeKodu = stockCard.MalzemeGetData.malzemeKayitID;
                        drugDefinition.StockCard = stockCard;
                    }
                    else
                    {
                        IBindingList malzemegetdata = objectContext.QueryObjects(typeof(MalzemeGetData).Name, "MALZEMEKODU ='" + item.NATOStockNO + "'");
                        if (malzemegetdata.Count > 0)
                        {
                            drugDefinition.MkysMalzemeKodu = ((MalzemeGetData)malzemegetdata[0]).malzemeKayitID;
                            drugDefinition.StockCard = stockCard;
                        }
                    }
                }
            }


            List<MaterialProcedures> drugMaterialProdureList = objectContext.QueryObjects<MaterialProcedures>("MATERIAL = " + TTConnectionManager.ConnectionManager.GuidToString(drugDefinition.ObjectID)).ToList();
            foreach (MaterialProcedures item in drugMaterialProdureList)
            {
                ((ITTObject)item).Delete();
            }

            if (viewModel.ProdureDefs.Length > 0)
            {
                foreach (var item in viewModel.ProdureDefs)
                {
                    MaterialProcedures materialProcedures = new MaterialProcedures(objectContext);
                    materialProcedures.Material = objectContext.GetObject<DrugDefinition>(viewModel._DrugDefinition.ObjectID);
                    materialProcedures.ProcedureDefinition = objectContext.GetObject<ProcedureDefinition>(item);
                }
            }

            if (drugDefinition.AntibioticType != null)
            {
                drugDefinition.InfectionApproval = true;
            }

            if (viewModel.EtkinMaddeObjectID != Guid.Empty)
            {
                drugDefinition.EtkinMadde = objectContext.GetObject<EtkinMadde>(viewModel.EtkinMaddeObjectID);
            }

            List<MaterialSpecialty> drugMaterialSpList = objectContext.QueryObjects<MaterialSpecialty>("MATERIAL = " + TTConnectionManager.ConnectionManager.GuidToString(drugDefinition.ObjectID)).ToList();
            foreach (MaterialSpecialty item in drugMaterialSpList)
            {
                ((ITTObject)item).Delete();
            }

            if (viewModel.MaterialSpecialtysList.Length > 0)
            {
                foreach (var item in viewModel.MaterialSpecialtysList)
                {
                    MaterialSpecialty materialSpecialty = new MaterialSpecialty(objectContext);
                    materialSpecialty.Material = objectContext.GetObject<ConsumableMaterialDefinition>(viewModel._DrugDefinition.ObjectID);
                    materialSpecialty.MaterialSpecialtyDefinition = objectContext.GetObject<MaterialSpecialtyDef>(item);
                }
            }

            if(viewModel.MaxDoseByDrugDef != null)
            {
                drugDefinition.InpatientMaxDoseOne = viewModel.MaxDoseByDrugDef.InpatientMaxDoseOne;
                drugDefinition.InpatientMaxDoseTwo = viewModel.MaxDoseByDrugDef.InpatientMaxDoseTwo;
                drugDefinition.OutpatientMaxDoseOne = viewModel.MaxDoseByDrugDef.OutpatientMaxDoseOne;
                drugDefinition.OutpatientMaxDoseTwo = viewModel.MaxDoseByDrugDef.OutpatientMaxDoseTwo;
            }


            if (viewModel.MaterialVatRatesGridList.Length == 1)
            {
                foreach (var item in viewModel.MaterialVatRatesGridList)
                {
                    List<MaterialVatRate> materialVatRates = drugDefinition.MaterialVatRates.Select(string.Empty, "ENDDATE").ToList();
                    if (materialVatRates.Count > 0)
                    {
                        MaterialVatRate materialVatRate = objectContext.GetObject<MaterialVatRate>(materialVatRates[0].ObjectID);
                        if (materialVatRate.VatRate != item.VatRate)
                        {
                            materialVatRate.EndDate = Common.RecTime().AddDays(-1);

                            MaterialVatRate newMaterialVatRate = new MaterialVatRate(objectContext);
                            newMaterialVatRate.StartDate = Common.RecTime();
                            newMaterialVatRate.EndDate = Common.RecTime().AddYears(100);
                            newMaterialVatRate.VatRate = item.VatRate;
                            drugDefinition.MaterialVatRates.Add(materialVatRate);
                        }
                    }
                    else
                    {
                        MaterialVatRate materialVatRate = new MaterialVatRate(objectContext);
                        materialVatRate.StartDate = Common.RecTime();
                        materialVatRate.EndDate = Common.RecTime().AddYears(100);
                        materialVatRate.VatRate = item.VatRate;
                        drugDefinition.MaterialVatRates.Add(materialVatRate);
                    }
                }
            }


            if (viewModel.RouteOfAdmins.Length > 0)
                drugDefinition.RouteOfAdmin = viewModel.RouteOfAdmins[0];

            if (viewModel.NFCs.Length > 0)
                drugDefinition.NFC = viewModel.NFCs[0];


            var transDef = drugDefinition.TransDef;
            PostScript_DrugDefinitionForm(viewModel, drugDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(drugDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(drugDefinition);
            AfterContextSaveScript_DrugDefinitionForm(viewModel, drugDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_DrugDefinitionForm(DrugDefinitionFormViewModel viewModel, DrugDefinition drugDefinition, TTObjectContext objectContext);
        partial void PostScript_DrugDefinitionForm(DrugDefinitionFormViewModel viewModel, DrugDefinition drugDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_DrugDefinitionForm(DrugDefinitionFormViewModel viewModel, DrugDefinition drugDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(DrugDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.DrugATCsGridList = viewModel._DrugDefinition.DrugATCs.OfType<DrugATC>().ToArray();
            viewModel.DrugActiveIngredientsGridList = viewModel._DrugDefinition.DrugActiveIngredients.OfType<DrugActiveIngredient>().ToArray();
            viewModel.MaterialVatRatesGridList = viewModel._DrugDefinition.MaterialVatRates.OfType<MaterialVatRate>().ToArray();
            viewModel.DrugRelationsGridList = viewModel._DrugDefinition.DrugRelations.OfType<DrugRelation>().ToArray();
            viewModel.ManuelEquivalentDrugsGridList = viewModel._DrugDefinition.ManuelEquivalentDrugs.OfType<ManuelEquivalentDrug>().ToArray();
            viewModel.DrugLabProcInteractionsGridList = viewModel._DrugDefinition.DrugLabProcInteractions.OfType<DrugLabProcInteraction>().ToArray();
            viewModel.DrugDrugInteractionsGridList = viewModel._DrugDefinition.DrugDrugInteractions.OfType<DrugDrugInteraction>().ToArray();
            viewModel.DrugFoodInteractionsGridList = viewModel._DrugDefinition.DrugFoodInteractions.OfType<DrugFoodInteraction>().ToArray();
            //viewModel.grdDrugSpecificationGridList = viewModel._DrugDefinition.DrugSpecifications.OfType<DrugSpecifications>().ToArray();
            viewModel.grdMaterialProceduresGridList = viewModel._DrugDefinition.MaterialProcedures.OfType<MaterialProcedures>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.EtkinMaddes = objectContext.LocalQuery<EtkinMadde>().ToArray();
            viewModel.ATCs = objectContext.LocalQuery<ATC>().ToArray();
            viewModel.UnitDefinitions = objectContext.QueryObjects<UnitDefinition>().ToArray();
            viewModel.RouteOfAdmins = objectContext.LocalQuery<RouteOfAdmin>().ToArray();
            viewModel.GenericDrugs = objectContext.LocalQuery<GenericDrug>().ToArray();
            viewModel.NFCs = objectContext.LocalQuery<NFC>().ToArray();
            viewModel.ActiveIngredientDefinitions = objectContext.LocalQuery<ActiveIngredientDefinition>().ToArray();
            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            viewModel.Producers = objectContext.LocalQuery<Producer>().ToArray();
            viewModel.GMDNDefinitions = objectContext.LocalQuery<GMDNDefinition>().ToArray();
            viewModel.DrugDefinitions = objectContext.LocalQuery<DrugDefinition>().ToArray();
            viewModel.LaboratoryTestDefinitions = objectContext.LocalQuery<LaboratoryTestDefinition>().ToArray();
            viewModel.DrugDrugInteractions = objectContext.LocalQuery<DrugDrugInteraction>().ToArray();
            viewModel.MaterialTreeDefinitions = objectContext.LocalQuery<MaterialTreeDefinition>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();

            // viewModel.DrugLastCost = MaterialPrice.MaterialPriceByMaterialForDefinition(viewModel._DrugDefinition.ObjectID.ToString()).ToList(); 
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "EtkinMaddeListDefinition", viewModel.EtkinMaddes);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ATCList", viewModel.ATCs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UnitListDefinition", viewModel.UnitDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RouteOfAdminListDefinition", viewModel.RouteOfAdmins);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugGenericList", viewModel.GenericDrugs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NFCList", viewModel.NFCs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ActiveIngredientList", viewModel.ActiveIngredientDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProducerListDefinition", viewModel.Producers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GMDNCodeListDefinition", viewModel.GMDNDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.DrugDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "LaboratoryTestListDefinition", viewModel.LaboratoryTestDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialTreeList", viewModel.MaterialTreeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);

            if (viewModel.EtkinMaddes.Length > 0)
            {
                viewModel.EtkinMaddeObjectID = viewModel.EtkinMaddes[0].ObjectID;
                viewModel.EtkinMaddeName = viewModel.EtkinMaddes[0].etkinMaddeAdi;
            }
        }
    }
}


namespace Core.Models
{
    public partial class DrugDefinitionFormViewModel
    {
        //   public List<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> DrugLastCost;
        public int[] DrugSpecs
        {
            get;
            set;
        }

        public Guid[] ProdureDefs { get; set; }

        public TTObjectClasses.DrugDefinition _DrugDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.DrugATC[] DrugATCsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DrugActiveIngredient[] DrugActiveIngredientsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialVatRate[] MaterialVatRatesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DrugRelation[] DrugRelationsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ManuelEquivalentDrug[] ManuelEquivalentDrugsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DrugLabProcInteraction[] DrugLabProcInteractionsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DrugDrugInteraction[] DrugDrugInteractionsGridList
        {
            get;
            set;
        }
        public TTObjectClasses.DrugFoodInteraction[] DrugFoodInteractionsGridList
        {
            get;
            set;
        }



        

        public TTObjectClasses.DrugSpecifications[] grdDrugSpecificationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialProcedures[] grdMaterialProceduresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.EtkinMadde[] EtkinMaddes
        {
            get;
            set;
        }

        public TTObjectClasses.ATC[] ATCs
        {
            get;
            set;
        }

        public TTObjectClasses.UnitDefinition[] UnitDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RouteOfAdmin[] RouteOfAdmins
        {
            get;
            set;
        }

        public TTObjectClasses.GenericDrug[] GenericDrugs
        {
            get;
            set;
        }

        public TTObjectClasses.NFC[] NFCs
        {
            get;
            set;
        }

        public TTObjectClasses.ActiveIngredientDefinition[] ActiveIngredientDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Producer[] Producers
        {
            get;
            set;
        }

        public TTObjectClasses.GMDNDefinition[] GMDNDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.DrugDefinition[] DrugDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryTestDefinition[] LaboratoryTestDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.DrugDrugInteraction[] DrugDrugInteractions
        {
            get;
            set;
        }

        public TTObjectClasses.DrugFoodInteraction[] DrugFoodInteractions
        {
            get;
            set;
        }
        
        public TTObjectClasses.MaterialTreeDefinition[] MaterialTreeDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }
        public Guid EtkinMaddeObjectID { get; set; }
        public string EtkinMaddeName { get; set; }

        public Guid[] MaterialSpecialtysList { get; set; }

        public MaxDoseByDrugDef MaxDoseByDrugDef { get; set; }

    }
}
