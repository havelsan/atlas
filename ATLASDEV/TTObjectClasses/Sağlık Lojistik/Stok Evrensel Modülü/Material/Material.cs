
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Stok kartına bağlı olan malzeme tanımları için kullanılan sınıftır
    /// </summary>
    public partial class Material : TerminologyManagerDef, ISUTRulableMaterial, ITTListObject
    {
        public partial class GetStockCardListReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialDependStockCardReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialListQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugAndMagistrals_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialDetail_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialPricingDetail_Class : TTReportNqlObject
        {
        }

        public partial class GetStockCardListByGroupReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_Material_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialInheldReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterials_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialWithNoEffectivePrice_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialBarcodeLevelDetail_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialNonDependStockCard_Class : TTReportNqlObject
        {
        }

        public partial class GetStockCardsToActReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialsWithPrice_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_Material_WithDate_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialWithMultiEffectivePriceByPriceList_Class : TTReportNqlObject
        {
        }

        public partial class GetOldMaterialListQuery_Class : TTReportNqlObject
        {
        }

        public partial class ProductMatchMaterialQuery_Class : TTReportNqlObject
        {
        }

        public partial class ProductNotMatchMaterialQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugAndMaterialListQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetPrescriptionMaterialListQuery_Class : TTReportNqlObject
        {
        }

        public partial class VEM_STOK_KART_Class : TTReportNqlObject
        {
        }



        public string MaterialType
        {
            get
            {
                try
                {
                    #region MaterialType_GetScript                    
                    string retValue = string.Empty;
                    if (this is ConsumableMaterialDefinition)
                        retValue = TTUtils.CultureService.GetText("M21326", "Sarf Malzeme");

                    if (this is DrugDefinition)
                        retValue = TTUtils.CultureService.GetText("M16287", "İlaç");

                    if (this is FixedAssetDefinition)
                        retValue = TTUtils.CultureService.GetText("M25404", "Demirbaş");
                    return retValue;
                    #endregion MaterialType_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MaterialType") + " : " + ex.Message, ex);
                }
            }
        }

        public long? CurrentVatRate
        {
            get
            {
                try
                {
                    #region CurrentVatRate_GetScript                    
                    long vatRate = 0;
                    if (MaterialVatRates.Count > 0)
                    {
                        IList vatRates = MaterialVatRates.Select("STARTDATE < '" + TTObjectDefManager.ServerTime + "' AND ENDDATE > '" + TTObjectDefManager.ServerTime + "'");
                        if (vatRates.Count > 0)
                            vatRate = ((MaterialVatRate)vatRates[0]).VatRate.Value;
                    }
                    return vatRate;
                    #endregion CurrentVatRate_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CurrentVatRate") + " : " + ex.Message, ex);
                }
            }
        }

        public string NATOStockNO
        {
            get
            {
                try
                {
                    #region NATOStockNO_GetScript                    
                    string retValue = "";
                    if (StockCard != null && string.IsNullOrEmpty(StockCard.NATOStockNO) == false)
                        retValue = StockCard.NATOStockNO;
                    return retValue;
                    #endregion NATOStockNO_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "NATOStockNO") + " : " + ex.Message, ex);
                }
            }
        }

        public override void OnContextDispose()
        {
            base.OnContextDispose();
            _distributionTypeName = DistributionTypeName;
        }

        private string _distributionTypeName = string.Empty;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public string DistributionTypeName
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_distributionTypeName) == false)
                        return _distributionTypeName;
                    #region DistributionTypeName_GetScript      

                    string retValue = "";
                    if (StockCard != null && string.IsNullOrEmpty(StockCard.DistributionType.DistributionType) == false)
                        retValue = StockCard.DistributionType.DistributionType;
                    return retValue;

                    #endregion DistributionTypeName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DistributionTypeName") + " : " + ex.Message, ex);
                }
            }
        }

        public string MaterialTreeName
        {
            get
            {
                try
                {
                    #region MaterialTreeName_GetScript                    
                    string retValue = "";
                    if (string.IsNullOrEmpty(MaterialTree.Name) == false)
                        retValue = MaterialTree.Name;
                    return retValue;
                    #endregion MaterialTreeName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MaterialTreeName") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Malzemenin Mevcut Durumu
        /// </summary>
        public string MaterialInheldStatus
        {
            get
            {
                try
                {
                    #region MaterialInheldStatus_GetScript                    
                    string inheldStatus = "";
                    foreach (Stock stock in Stocks)
                    {
                        if (stock.Inheld > 0)
                        {
                            inheldStatus = "Var";
                            break;
                        }
                        inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                    }
                    return inheldStatus;
                    #endregion MaterialInheldStatus_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MaterialInheldStatus") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            MaterialRepeatCheck();
            if (CreationDate == null)
                CreationDate = Common.RecTime();

            if (IsExpendableMaterial.HasValue)
                foreach (Stock stock in Stocks)
                    stock.Expendable = (bool)IsExpendableMaterial;

            if (this is DrugDefinition)
                MaterialTypeForInvoice = MaterialTypeForInvoiceEnum.Medicine;
            else if (this is ConsumableMaterialDefinition)
                MaterialTypeForInvoice = MaterialTypeForInvoiceEnum.Material;
            else if (this is FixedAssetDefinition)
                MaterialTypeForInvoice = MaterialTypeForInvoiceEnum.FixedAsset;

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            if (this is DrugDefinition)
            {
                this.MaterialCodeSequence.GetNextValue("ilac");
            }
            else if (this is ConsumableMaterialDefinition)
            {
                if (this.AllowToGivePatient == true)
                {
                    this.MaterialCodeSequence.GetNextValue("sarf");
                }
                else
                {
                    this.MaterialCodeSequence.GetNextValue("tuketilebilir");
                }
            }


            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            if (this is DrugDefinition == false)
            {
                if (StockCard == null)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M26951", "Stok Kartı olmayan malzemeye işlem yapamassınız !"));
                }
            }

            MaterialRepeatCheck();

            if (IsExpendableMaterial.HasValue)
                foreach (Stock stock in Stocks)
                    stock.Expendable = (bool)IsExpendableMaterial;

            if (this is DrugDefinition)
                MaterialTypeForInvoice = MaterialTypeForInvoiceEnum.Medicine;
            else if (this is ConsumableMaterialDefinition)
                MaterialTypeForInvoice = MaterialTypeForInvoiceEnum.Material;
            else if (this is FixedAssetDefinition)
                MaterialTypeForInvoice = MaterialTypeForInvoiceEnum.FixedAsset;

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (this is DrugDefinition == false)
            {
                if (StockCard == null)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M26951", "Stok Kartı olmayan malzemeye işlem yapamassınız !"));
                }
            }

            #endregion PostUpdate
        }

        #region Methods
        private PricingDetailDefinition _currentPricingDetailDefinition = null;
        public PricingDetailDefinition GetCurrentPricingDetailDefinition(PricingListDefinition pPricingList, DateTime? pDate)
        {
            if (_currentPricingDetailDefinition == null)
            {
                //TODO : query ile getirilecek mustafa
                _currentPricingDetailDefinition = MaterialPrices[0].PricingDetail;
            }
            return _currentPricingDetailDefinition;
        }

        public override string ToString()
        {
            if (StockCard != null && string.IsNullOrEmpty(StockCard.NATOStockNO) == false)
                return StockCard.NATOStockNO + " " + Name;
            else
                return Name;
        }

        bool ITTListObject.IsSelectable
        {
            get
            {
                return true;
            }
        }

        public override bool IsActiveLocal()
        {
            return false;
        }

        public ArrayList GetMaterialPricingDetail(PricingListDefinition pPricingList, DateTime? pDate)
        {
            // Bir malzemenin, parametrede verilen tarihte ve ilgili fiyat listesindeki fiyatını bulur
            // Eşleştiği birden çok fiyat varsa, en yüksek fiyatlıyı kullanır
            ArrayList materialPriceList = new ArrayList();
            PricingDetailDefinition price = null;
            if (pDate == null)
            {
                foreach (MaterialPrice mp in MaterialPrices)
                {
                    if (mp.PricingDetail.PricingList != null && mp.PricingDetail.PricingList.ObjectID == pPricingList.ObjectID)
                    {
                        if (price == null)
                            price = mp.PricingDetail;
                        else
                        {
                            if (mp.PricingDetail.Price > price.Price)
                                price = mp.PricingDetail;
                        }
                    }
                }
            }
            else
            {
                foreach (MaterialPrice mp in MaterialPrices)
                {
                    if (mp.PricingDetail.PricingList != null && mp.PricingDetail.PricingList.ObjectID == pPricingList.ObjectID && mp.PricingDetail.DateStart <= pDate && pDate <= mp.PricingDetail.DateEnd)
                    {
                        if (price == null)
                            price = mp.PricingDetail;
                        else
                        {
                            if (mp.PricingDetail.Price > price.Price)
                                price = mp.PricingDetail;
                        }
                    }
                }
            }

            if (price != null)
                materialPriceList.Add(price);

            return materialPriceList;
        }

        public ArrayList GetMaterialPricingDetail(PricingListDefinition pPricingList)
        {
            return GetMaterialPricingDetail(pPricingList, null);
        }


        public Currency? GetMaterialPrice(SubEpisodeProtocol sep, DateTime? processDate = null)
        {
            try
            {
                if (sep != null)
                {
                    DateTime? date;
                    if (processDate != null)
                        date = processDate;
                    else
                        date = Common.RecTime();

                    ArrayList col = new ArrayList();
                    col = sep.Protocol.CalculatePrice(this, sep.SubEpisode.Episode.PatientStatus, null, date, sep.SubEpisode.Episode.Patient.AgeCompleted);
                    foreach (ManipulatedPrice mpd in col)
                        return mpd.Price;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Benzer isimde malzemelerin daha önceden girilmesi durumunu kontrol etmektedir.
        /// </summary>

        private void MaterialRepeatCheck()
        {
            // Bu kontrol burada yapılmamalı, burada yapıldığında SPTSden ilaç atmak mümkün olmuyor.
            // Burada birebir aynı isimli malzeme kontrolü yapılmalı.
            // Bu kontrol form postta yapılarak kullanıcıya sadece uyarı verilmeli devam etmek isteyip istemediği sorulmalıdır.
            return;
            //
            //            string message = "", word = "";
            //            int count = 0;
            //            string words = this.Name;
            //
            //            string[] split = words.Split(new Char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            //
            //            foreach (string s in split)
            //            {
            //                if(count == split.GetUpperBound(0))
            //                {
            //                    word += "NAME LIKE " + "'%" + s + "%'" ;
            //                }
            //                else
            //                {
            //                    word += "NAME LIKE " + "'%" + s + "%'" + "AND ";
            //                    count++;
            //                }
            //            }
            //
            //            IList materialName = this.ObjectContext.QueryObjects("MATERIAL",word);
            //            ITTObject ttObject = (ITTObject)this;
            //            if(ttObject.IsNew){
            //                foreach (Material m in materialName)
            //                {
            //                    message = message +"\r\n" + m.Name;
            //                }
            //                if (message != "")
            //                    throw new Exception(message + " Malzemeleri daha önceden girilmiştir.");
            //            }
        }

        public bool ExistingInheld(Store store)
        {
            //Bir malzemenin verilen parametredeki depoda mevcudu olup olmadığını kontrol eder
            if (StockInheld(store) > 0)
                return true;
            return false;
        }

        public double StockMaxLevel(Store store)
        {
            BindingList<Stock> stocks = Stocks.Select("STORE = " + ConnectionManager.GuidToString(store.ObjectID));
            if (stocks.Count == 1)
            {
                if (stocks[0].MaximumLevel != null)
                    return stocks[0].MaximumLevel.Value;
                else
                    return 0;
            }
            return 0;
        }

        public double StockInheld(Store store)
        {
            //Bir malzemenin verilen parametredeki depodaki mevcudunu bulur
            BindingList<Stock> stocks = Stocks.Select("STORE = " + ConnectionManager.GuidToString(store.ObjectID));
            if (stocks.Count == 1 && stocks[0].Inheld.HasValue)
                return stocks[0].Inheld.Value;
            return 0;
        }

        public double StockInheld(Store store, StockLevelType stockLevelType)
        {
            //Bir malzemenin verilen parametredeki depodaki mevcudunu stok seviyesine göre bulur
            Guid budgetGuid = Guid.Empty;
            BindingList<Stock> stocks = Stocks.Select("STORE = " + ConnectionManager.GuidToString(store.ObjectID));

            if (store is MainStoreDefinition)
            {
                if (((MainStoreDefinition)store).MKYS_ButceTuru != null)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    List<BudgetTypeDefinition> budgetTypeDefList = context.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)(store)).MKYS_ButceTuru.Value).Value).ToList();
                    if (budgetTypeDefList.Count == 1)
                    {
                        budgetGuid = ((BudgetTypeDefinition)budgetTypeDefList[0]).ObjectID;
                    }
                    else if (budgetTypeDefList.Count > 1)
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25075", "1 den fazla bütçe tipi tanımlanmıştır. Bilgi işleme haber veriniz.!"));
                    }
                    else
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M27039", "Tanımlı bütçe tipi bulunamamıştır. Bilgi işleme haber veriniz.!"));
                    }
                }

            }
            Currency Amount = 0;
            if (budgetGuid != Guid.Empty)
            {
                if (stocks.Count == 1)
                {
                    BindingList<StockTransaction> transactionsIn = stocks[0].StockTransactions.Select(" INOUT = 1 AND BUDGETTYPEDEFINITION = " + ConnectionManager.GuidToString(budgetGuid) + " AND STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelType.ObjectID) + " AND CURRENTSTATEDEFID <> '41ef11f6-f61b-4292-a982-3eb2acd1dbb8'");
                    foreach (StockTransaction st in transactionsIn)
                    {
                        Amount += (Currency)st.Amount;
                    }
                    BindingList<StockTransaction> transactionsOut = stocks[0].StockTransactions.Select(" INOUT = 2 AND BUDGETTYPEDEFINITION = " + ConnectionManager.GuidToString(budgetGuid) + " AND STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelType.ObjectID) + " AND CURRENTSTATEDEFID <> '41ef11f6-f61b-4292-a982-3eb2acd1dbb8'");
                    foreach (StockTransaction st in transactionsOut)
                    {
                        Amount -= (Currency)st.Amount;
                    }
                    return Amount;
                }
            }

            else
            {
                if (stocks.Count == 1 && stocks[0].Inheld.HasValue)
                {
                    BindingList<StockLevel> stockLevels = stocks[0].StockLevels.Select("STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelType.ObjectID));
                    if (stockLevels.Count == 1 && stockLevels[0].Amount.HasValue)
                        return stockLevels[0].Amount.Value;
                }
            }
            return 0;
        }

        /* if (stocks.Count == 1 && stocks[0].Inheld.HasValue)
         {
             BindingList<StockLevel> stockLevels = stocks[0].StockLevels.Select("STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelType.ObjectID));
             if (stockLevels.Count == 1 && stockLevels[0].Amount.HasValue)
                 return stockLevels[0].Amount.Value;
         }*/



        public bool GetIsRuleExist()
        {
            if (MaterialRuleSets.Select(string.Empty).Count > 0)
                return true;
            else
                return false;
        }


        public List<RuleBase> GetSuitableRules(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase> retValue = new List<RuleBase>();
            foreach (RuleBase rule in GetAvailableRules(actionDate))
            {
                if (rule.IsActive.HasValue && rule.IsActive.Value)
                {
                    if (rule.IsSuitable(actionDate, currentInstance))
                        retValue.Add(rule);
                }
            }
            return retValue;
        }

        public OldMaterialTypeEnum GetOldMaterialType()
        {
            if (ObjectID.ToString().Equals(SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString())))
                return OldMaterialTypeEnum.TITUBBMaterial;

            if (MaterialProductLevels.Count == 0)
                return OldMaterialTypeEnum.NoMatchMaterial;
            else
            {
                if (MaterialProductLevels.Select("PRODUCT is not null").Count > 0)
                    return OldMaterialTypeEnum.TITUBBMaterial;
                else
                {
                    if (MaterialProductLevels.Select("BARCODE is not null").Count > 0)
                        return OldMaterialTypeEnum.MaterialWithBarcode;
                    else
                        return OldMaterialTypeEnum.MaterialWithoutBarcode;
                }
            }
        }

        public ProductDefinition GetCorrectProduct()
        {
            ProductDefinition productDefinition = null;
            List<ProductDefinition> productWithPrice = new List<ProductDefinition>();
            List<ProductDefinition> productWithoutPrice = new List<ProductDefinition>();
            if (MaterialProductLevels.Select("PRODUCT is not null").Count > 0)
            {
                foreach (MaterialProductLevel level in MaterialProductLevels.Select("PRODUCT is not null"))
                {
                    if (level.Product.ProductSUTMatchs.Count > 0)
                    {
                        if (productWithPrice.Contains(level.Product) == false)
                            productWithPrice.Add(level.Product);
                    }
                    else
                    {
                        if (productWithoutPrice.Contains(level.Product) == false)
                            productWithoutPrice.Add(level.Product);
                    }
                }
            }
            else
            {
                TTObjectContext readOnlyContext = new TTObjectContext(true);
                IList joinedMaterials = readOnlyContext.QueryObjects("MATERIAL", "JOINEDMATERIAL =" + ConnectionManager.GuidToString(ObjectID));
                if (joinedMaterials.Count > 0)
                {
                    Material joinedMaterial = (Material)joinedMaterials[0];

                    foreach (MaterialProductLevel level in joinedMaterial.MaterialProductLevels.Select("PRODUCT is not null"))
                    {
                        if (level.Product.ProductSUTMatchs.Count > 0)
                        {
                            if (productWithPrice.Contains(level.Product) == false)
                                productWithPrice.Add(level.Product);
                        }
                        else
                        {
                            if (productWithoutPrice.Contains(level.Product) == false)
                                productWithoutPrice.Add(level.Product);
                        }
                    }
                }
            }

            if (productWithPrice.Count > 0)
            {
                Hashtable unSortedProductList = new Hashtable();
                foreach (ProductDefinition product in productWithPrice)
                {
                    Common.TTDoubleSortableList productItem = new Common.TTDoubleSortableList();
                    productItem.ID = product;
                    productItem.Value = (double)product.ProductSUTMatchs[0].SUTPrice;
                    unSortedProductList.Add(productItem.ID, productItem);
                }
                List<Common.TTDoubleSortableList> productList = Common.SortedDoubleItems(unSortedProductList);
                productDefinition = (ProductDefinition)productList[0].ID;
            }
            else
            {
                if (productWithoutPrice.Count > 0)
                    productDefinition = productWithoutPrice[0];
            }
            return productDefinition;
        }

        public List<RuleBase> GetAvailableRules(DateTime actionDate)
        {
            List<RuleBase> retValue = new List<RuleBase>();
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            IList ruleObjectIDs = RuleBase.GetAvailableRules(readOnlyObjectContext, actionDate, " AND RULESETRULES.RULESET.MATERIALRULESETS.MATERIAL = " + ConnectionManager.GuidToString(ObjectID));
            if (ruleObjectIDs.Count > 0)
            {
                string filterExpression = string.Empty;
                filterExpression += " WHERE OBJECTID IN(";
                int i = 1;
                foreach (RuleBase.GetAvailableRules_Class o in ruleObjectIDs)
                {
                    if (o.Ruleobjectid.HasValue)
                    {
                        filterExpression += ConnectionManager.GuidToString(o.Ruleobjectid.Value);
                        if (i < ruleObjectIDs.Count)
                            filterExpression += ",";
                    }
                    i++;
                }
                filterExpression += ")";
                retValue.AddRange(RuleBase.GetRules(readOnlyObjectContext, filterExpression));
            }
            return retValue;
        }


        public List<RuleBase.RuleResult> RunRules(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase.RuleResult> ruleResults = new List<RuleBase.RuleResult>();

            if (GetIsRuleExist())
            {
                List<RuleBase> suitableRules = GetSuitableRules(actionDate, currentInstance);
                if (suitableRules.Count > 0)
                {
                    foreach (RuleBase ruleBase in suitableRules)
                        ruleResults.AddRange(ruleBase.RunRule(actionDate, currentInstance));
                }
                else
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    GlobalRule globalRule = new GlobalRule(objectContext);
                    globalRule.IsWarningOnly = false;
                    globalRule.Name = "İLAÇ / MALZEME BULUNAMAYAN UYGUN KURAL";
                    globalRule.Result = TTUtils.CultureService.GetText("M26058", "İlaç / Malzemeye ait ödemeye uygun kural bulunamadığından işleme devam edemezsiniz.");

                    foreach (RuleBase rule in GetAvailableRules(actionDate))
                        globalRule.Result += "\r\n" + rule.Result;

                    globalRule.IsActive = true;

                    ruleResults.Add(new RuleBase.RuleResult(this, globalRule, string.Empty));
                }
            }

            return ruleResults;
        }

        public static long GetVatrateFromMaterialTS(Material material, DateTime? date)
        {
            long vatRateReturn = 0;
            if (date != null)
            {
                vatRateReturn = material.GetVatrateFromMaterial(date);
            }
            return vatRateReturn;

        }


        public long GetVatrateFromMaterial(DateTime? date)
        {
            long vatRateReturn = 0;
            if (MaterialVatRates != null && MaterialVatRates.Count > 0)
            {
                foreach (MaterialVatRate vatRate in MaterialVatRates)
                {
                    if (vatRate.StartDate <= date && vatRate.EndDate >= date)
                    {
                        return (long)vatRate.VatRate;
                    }
                }
            }
            return vatRateReturn;
        }

        public string GetName()
        {
            return Name;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        #endregion Methods

    }
}