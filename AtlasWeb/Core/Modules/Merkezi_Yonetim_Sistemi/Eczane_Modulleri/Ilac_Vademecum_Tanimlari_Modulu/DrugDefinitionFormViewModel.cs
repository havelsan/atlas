//$7B1326C0
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using System.ComponentModel;
using static Core.Controllers.DrugDefinitionServiceController;
using Core.Controllers;

namespace Core.Controllers
{
    public partial class DrugDefinitionServiceController
    {
        partial void PreScript_DrugDefinitionForm(DrugDefinitionFormViewModel viewModel, DrugDefinition drugDefinition, TTObjectContext objectContext)
        {
            // viewModel.ActiveIngredientList = objectContext.QueryObjects<ActiveIngredientDefinition>().ToList();
        }

        partial void AfterContextSaveScript_DrugDefinitionForm(DrugDefinitionFormViewModel viewModel, DrugDefinition drugDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            TTObjectContext contect = new TTObjectContext(false);
            if (drugDefinition.CreationDate == null || ((DateTime)drugDefinition.CreationDate).ToShortDateString() == Common.RecTime().ToShortDateString())
            {
                if (!(drugDefinition.MaterialPrices.Count > 0))
                    updateGetMaterialPriceByIlacAra(drugDefinition, contect);
            }

            foreach (var item in drugDefinition.DrugDrugInteractions.Select(string.Empty))
            {
                var drugdrugInts = DrugDrugInteraction.DrugDrugIntegrationRQ(item.InteractionDrug.ObjectID.ToString(), item.DrugDefinition.ObjectID.ToString()).ToArray();
                if ((drugdrugInts.Length == 0))
                {
                    DrugDrugInteraction otherDrug = new DrugDrugInteraction(contect);
                    otherDrug.DrugDefinition = item.InteractionDrug;
                    otherDrug.InteractionLevelType = item.InteractionLevelType;
                    otherDrug.InteractionDrug = item.DrugDefinition;
                    otherDrug.Message = item.Message;
                }
            }


      


            contect.Save();
        }


        public void updateGetMaterialPriceByIlacAra(DrugDefinition drugDefinition, TTObjectContext context)
        {
            try
            {
                MedulaYardimciIslemler.ilacAraGirisDVO ilacAraGirisDVO = new MedulaYardimciIslemler.ilacAraGirisDVO();
                ilacAraGirisDVO.saglikTesisKodu = Int32.Parse(TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME", "XXXXXX"));
                ilacAraGirisDVO.barkod = drugDefinition.Barcode;
                MedulaYardimciIslemler.ilacAraCevapDVO ilacAraCevapDVO = MedulaYardimciIslemler.WebMethods.ilacAraSync(Sites.SiteLocalHost, ilacAraGirisDVO);
                if (ilacAraCevapDVO.sonucKodu == "0000")
                {

                    if (ilacAraCevapDVO.ilaclar.Length > 0)
                    {
                        //doz birimleri
                        drugDefinition.OutpatientMaxDoseOne = ilacAraCevapDVO.ilaclar[0].ayaktanMaksimumKullanimDoz1;
                        drugDefinition.OutpatientMaxDoseTwo = ilacAraCevapDVO.ilaclar[0].ayaktanMaksimumKullanimDoz2;
                        drugDefinition.InpatientMaxDoseOne = ilacAraCevapDVO.ilaclar[0].yatanMaksimumKullanimDoz1;
                        drugDefinition.InpatientMaxDoseTwo = ilacAraCevapDVO.ilaclar[0].yatanMaksimumKullanimDoz2;
                    }


                    List<PricingDetailDVO> pricingDetailDefinitions = new List<PricingDetailDVO>();
                    pricingDetailDefinitions = PricingDetailDefinitionForMedicine(context, ilacAraCevapDVO.ilaclar[0], drugDefinition);

                    string ayaktanOdeme = ilacAraCevapDVO.ilaclar[0].ayaktanOdenme;
                    string yatanOdeme = ilacAraCevapDVO.ilaclar[0].yatanOdenme;

                    if (string.IsNullOrEmpty(ayaktanOdeme) != true)
                    {
                        if (ayaktanOdeme == "1")
                            drugDefinition.OutpatientReportType = DrugReportType.Odenir;
                        else if (ayaktanOdeme == "2")
                            drugDefinition.OutpatientReportType = DrugReportType.RaporlaOdenir;
                        else
                            drugDefinition.OutpatientReportType = DrugReportType.Odenmez;
                    }
                    if (string.IsNullOrEmpty(yatanOdeme) != true)
                    {
                        if (yatanOdeme == "1")
                            drugDefinition.InpatientReportType = DrugReportType.Odenir;
                        else if (yatanOdeme == "2")
                            drugDefinition.InpatientReportType = DrugReportType.RaporlaOdenir;
                        else
                            drugDefinition.InpatientReportType = DrugReportType.Odenmez;
                    }

                    drugDefinition.AntibioticType = AntibioticTypeEnum.KY;

                    IBindingList SkrsIlac = context.QueryObjects(typeof(SKRSIlac).Name, "BARKODU ='" + drugDefinition.Barcode + "'");
                    foreach (SKRSIlac item in SkrsIlac)
                    {
                        if (String.IsNullOrEmpty(item.ATCKODU) != true)
                        {
                            IBindingList ATCList = context.QueryObjects(typeof(ATC).Name, "CODE ='" + item.ATCKODU + "'");
                            foreach (ATC atcItem in ATCList)
                            {
                                DrugATC drugATC = new DrugATC(context);
                                drugATC.ATC = atcItem;
                                drugATC.DrugDefinition = drugDefinition;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        [HttpGet]
        public GetCriticalStockLevels_Class GetCriticalStockLevels(string StoreID, string MaterialObjectID)
        {

            List<Stock.GetCriticalStockLevelsNQL_Class> list = Stock.GetCriticalStockLevelsNQL(new Guid(StoreID), " AND MATERIAL =" + "'" + MaterialObjectID + "'", null).ToList();
            GetCriticalStockLevels_Class output;
            if (list.Count > 0)
            {
                output = new GetCriticalStockLevels_Class
                {

                    Inheld = list[list.Count - 1].Inheld,
                    MinimumLevel = list[list.Count - 1].MinimumLevel,
                    MaximumLevel = list[list.Count - 1].MaximumLevel,
                    CriticalLevel = list[list.Count - 1].CriticalLevel
                };
            }
            else
            {
                output = new GetCriticalStockLevels_Class
                {
                    Inheld = 0,
                    MinimumLevel = 0,
                    MaximumLevel = 0,
                    CriticalLevel = 0
                };
            }

            return output;

        }

        public class FirstInStockUnitePriceDrugDefinition
        {
            public Guid stockActionObjectid { get; set; }
            public Guid ObjectDefID { get; set; }
            public DateTime? ExpirationDate { get; set; }
            public DateTime? TransactionDate { get; set; }
            public string Tif { get; set; }
            public string UnitePrice { get; set; }
        }

        public class FirstIN_Input
        {
            public Guid MaterialObjectID { get; set; }
            public Guid StoreObjcetID { get; set; }
        }

        public List<FirstInStockUnitePriceDrugDefinition> GetMaterialInStock(LoadModelComponent_Input inputDVO)
        {
            List<FirstInStockUnitePriceDrugDefinition> list = new List<FirstInStockUnitePriceDrugDefinition>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                BindingList<Stock.GetStockFromStoreAndMaterial_Class> stocks = Stock.GetStockFromStoreAndMaterial(inputDVO.MaterialID, inputDVO.StoreID);
                if (stocks.Count > 0)
                {
                    IBindingList stockTransactions = objectContext.QueryObjects(typeof(StockTransaction).Name, " INOUT = 1 AND STOCK =" + TTConnectionManager.ConnectionManager.GuidToString((Guid)(stocks[0].ObjectID)) + " AND CURRENTSTATEDEFID =" + TTConnectionManager.ConnectionManager.GuidToString(StockTransaction.States.Completed));
                    foreach (StockTransaction item in stockTransactions)
                    {
                        if (item.StockActionDetail.StockAction != null)
                        {
                            FirstInStockUnitePriceDrugDefinition firtIn = new FirstInStockUnitePriceDrugDefinition();
                            firtIn.stockActionObjectid = item.StockActionDetail.StockAction.ObjectID;
                            firtIn.ObjectDefID = item.StockActionDetail.StockAction.ObjectDef.ID;
                            firtIn.ExpirationDate = item.ExpirationDate;
                            firtIn.TransactionDate = item.StockActionDetail.StockAction.TransactionDate;
                            firtIn.UnitePrice = item.UnitPrice.ToString();

                            IBindingList documentRecordLogs = objectContext.QueryObjects(typeof(DocumentRecordLog).Name, " STOCKACTION = '" + item.StockActionDetail.StockAction.ObjectID + "'");
                            foreach (DocumentRecordLog log in documentRecordLogs)
                            {
                                firtIn.Tif = log.DocumentRecordLogNumber.ToString();
                            }

                            list.Add(firtIn);
                        }
                    }
                }
            }
            list = list.OrderByDescending(x => x.TransactionDate).ToList();
            return list;
        }
    }
}


namespace Core.Models
{
    public partial class DrugDefinitionFormViewModel : BaseViewModel
    {

        public List<ActiveIngredientDefinition> ActiveIngredientList
        {
            get;
            set;
        }
        public List<MaterialDocumentation> MaterialDocumentations { get; set; }
        public List<DrugDefinition> interactionDrugs { get; set; }
        public List<DietMaterialDefinition> dietMaterialDefinitions { get; set; }

        public RevenueSubAccountCodeDefinition RevenueSubAccountCodeDef { get; set; }
    }
    public class GetCriticalStockLevels_Class
    {
        public TTDataDictionary.Currency? Inheld
        {
            get;
            set;
        }
        public TTDataDictionary.Currency? MinimumLevel
        {
            get;
            set;
        }
        public TTDataDictionary.Currency? CriticalLevel
        {
            get;
            set;
        }
        public TTDataDictionary.Currency? MaximumLevel
        {
            get;
            set;
        }
    }
    public class GetStockLocation_Class
    {
        public string ParentstockLocation
        {
            get;
            set;
        }
        public string StockLocation
        {
            get;
            set;
        }


    }
    public class DrugDefinitionSelectBoxItem
    {
        public string DisplayText
        {
            get;
            set;
        }
        public Guid Objectid
        {
            get;
            set;
        }
    }
    public class GetStockLocation_Input
    {
        public string StockLocationName
        {
            get;
            set;
        }


    }

    public class MaterialModelForMovableTransactionInput
    {

        public Guid StockTransactionID { get; set; }
        public Guid StockActionObjectID { get; set; }
        public int StockActionID { get; set; }
        public List<StockAction> VoucherList { get; set; }
        public Guid MaterialObjectID { get; set; }

    }
    public class DrugSpecification_Input
    {
        public DrugDefinition drugDefinitionObjectid { get; set; }
        public List<DrugSpecificationEnum> drugSpecificationNewArray { get; set; }
    }


    public class DrugsFormViewModel
    {
        public string accountingTermObjId { get; set; }
        public Guid StoreID { get; set; }
        public Guid BudgetType { get; set; }
        public Guid MaterialID { get; set; }
        public bool isZeroAmount { get; set; }


    }
    public class DrugDefinitionByEquivalentFormViewModel
    {
        public Guid MaterialID { get; set; }

    }
    public class DrugDefinitionByEquivalentDVO
    {
        public string barcode { get; set; }
        public Guid MaterialID { get; set; }
        public int restAmount { get; set; }
    }

    public class DrugsInFormViewModel
    {
        public string accountingTermObjId { get; set; }
        public Guid MaterialID { get; set; }
    }
    public class EquivalentMaterialFormViewModel
    {
        public string Equivalent { get; set; }
        public Guid Drug { get; set; }
    }
    public class EquivalentMaterial
    {
        public string Equivalent { get; set; }
        public Guid DrugObjectid { get; set; }
        public Guid ManuelDrugObjectid { get; set; }
        public Guid SelectedDrugObjectID { get; set; }


    }
    public class DrugsInDVO
    {
        public string accountingTermObjId { get; set; }
        public Guid MaterialID { get; set; }
        public int InAmount { get; set; }
    }

    public class AmaountTotal
    {
        public string Month { get; set; }
        public int InAmount { get; set; }
        public int OutAmount { get; set; }
    }
    public class DrugsOutFormViewModel
    {
        public string accountingTermObjId { get; set; }
        public Guid MaterialID { get; set; }
    }
    public class DrugsOutDVO
    {
        public string accountingTermObjId { get; set; }
        public Guid MaterialID { get; set; }
        public int InAmount { get; set; }
    }

    public class EquivalentObjectID_Input
    {
        public Guid SelectedDrugObjectID { get; set; }
        public Guid? DrugObjectid { get; set; }
        public Guid? ManuelDrugObjectid { get; set; }
    }

    public class LoadModelComponent
    {
        public ShelfAndRowOnStock shelfAndRowOnStock { get; set; }

        public MaxDoseByDrugDef getMaxDoseByDrugDef { get; set; }
        public BindingList<StockLocation.GetStockLocation_Class> getStockLocationClasses { get; set; }

        public BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> materialPrices { get; set; }

        public List<EquivalentMaterial> getEquivalents { get; set; }

        public GetCriticalStockLevels_Class getCritical { get; set; }

        public List<ProcedureDefinition_Output> materialProcedures { get; set; }
        public List<FirstInStockUnitePriceDrugDefinition> firstInStockUnitePrices { get; set; }

        public List<LogDataSource> logDataSources { get; set; }

        public LogisticDashboardViewModel doSearchaccountingTerm { get; set; }

        public List<DrugSpecificationEnum> drugSpecifications { get; set; }

        public List<RouteOfAdmin> routeOfAdminDataSource { get; set; }
        public List<NFC> nfcDataSource { get; set; }


    }


    public class LoadModelComponent_Input
    {
        public Guid MaterialID { get; set; }
        public Guid StoreID { get; set; }
        public int? Shelf { get; set; }
        public int? Row { get; set; }
        public string Equivalent { get; set; }
    }

    public class ShelfAndRowOnStock
    {
        public int? Shelf { get; set; }
        public int? Row { get; set; }
        public Guid? StockLocationID { get; set; }
        public StockLocation StockLocation { get; set; }

    }

    public class MaxDoseByDrugDef
    {
        public double? InpatientMaxDoseOne { get; set; }
        public double? InpatientMaxDoseTwo { get; set; }
        public double? OutpatientMaxDoseOne { get; set; }
        public double? OutpatientMaxDoseTwo { get; set; }

    }

}
