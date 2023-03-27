
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


using static TTObjectClasses.SubActionMaterial;

namespace TTObjectClasses
{
    /// <summary>
    /// Bir deponun bir stok kartı ile ilgili mevcut, kritik seviye, maksimum seviye ve benzeri bilgilerini tutan sınıftır
    /// </summary>
    public partial class Stock : TTDefinitionSet
    {
        public partial class GetTotalInHeldByYear_Class : TTReportNqlObject
        {
        }

        public partial class GetStockForStore_Class : TTReportNqlObject
        {
        }

        public partial class SearchStocks_Class : TTReportNqlObject
        {
        }

        public partial class GetStockForStockCard_Class : TTReportNqlObject
        {
        }

        public partial class MinMaxForStockCardQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetStockDefinitions_Class : TTReportNqlObject
        {
        }

        public partial class GetTotalInOutStockByYear_Class : TTReportNqlObject
        {
        }

        public partial class GetTotalInOutStock_Class : TTReportNqlObject
        {
        }

        public partial class GetStockFromStoreAndMaterial_Class : TTReportNqlObject
        {
        }

        public partial class GetStockForStoreByTree_Class : TTReportNqlObject
        {
        }

        public partial class GetStockForStoreByCardDrawer_Class : TTReportNqlObject
        {
        }

        public partial class GetStockForStoreByCardDrawerGMDNGroup_Class : TTReportNqlObject
        {
        }

        public partial class GetStockForStoreByCardDrawerNSNGroup_Class : TTReportNqlObject
        {
        }

        public partial class UnitePriceOfReportQueryNew_Class : TTReportNqlObject
        {
        }

        public partial class GetStockForStoreByCardDrawerWithLevel_Class : TTReportNqlObject
        {
        }

        public partial class NoMatchOldMaterailQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialDistributeReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class VEM_STOK_DURUM_Class : TTReportNqlObject
        {
        }



        public Currency? ReservedAmount
        {
            get
            {
                try
                {
                    #region ReservedAmount_GetScript                    
                    Currency reservedAmount = 0;
                    IList stockReservations = StockReservations.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(StockReservation.States.Reserved));
                    foreach (StockReservation stockReservation in stockReservations)
                        reservedAmount += (Currency)stockReservation.Amount;
                    return reservedAmount;
                    #endregion ReservedAmount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ReservedAmount") + " : " + ex.Message, ex);
                }
            }
        }

        public Currency? NewLevelAmount
        {
            get
            {
                try
                {
                    #region NewLevelAmount_GetScript                    
                    Currency retvalue = 0;
                    StockLevel stockLevel = NewStockLevel;
                    if (stockLevel != null)
                        retvalue = stockLevel.Amount.Value;
                    return retvalue;
                    #endregion NewLevelAmount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "NewLevelAmount") + " : " + ex.Message, ex);
                }
            }
        }

        public Currency? UsedLevelAmount
        {
            get
            {
                try
                {
                    #region UsedLevelAmount_GetScript                    
                    Currency retvalue = 0;
                    StockLevel stockLevel = UsedStockLevel;
                    if (stockLevel != null)
                        retvalue = stockLevel.Amount.Value;
                    return retvalue;
                    #endregion UsedLevelAmount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "UsedLevelAmount") + " : " + ex.Message, ex);
                }
            }
        }

        public Currency? HEKLevelAmount
        {
            get
            {
                try
                {
                    #region HEKLevelAmount_GetScript                    
                    Currency retvalue = 0;
                    StockLevel stockLevel = HEKStockLevel;
                    if (stockLevel != null)
                        retvalue = stockLevel.Amount.Value;
                    return retvalue;
                    #endregion HEKLevelAmount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "HEKLevelAmount") + " : " + ex.Message, ex);
                }
            }
        }


        public override void OnContextDispose()
        {
            base.OnContextDispose();
            _calculatedInheld = CalculatedInheld;
            _calculatedDistributionType = CalculatedDistributionType;
        }

        /// <summary>
        /// Hesaplana Depo Mevcudu
        /// </summary>
        private Currency? _calculatedInheld = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public Currency CalculatedInheld
        {
            get
            {
                try
                {
                    if (_calculatedInheld.HasValue)
                        return _calculatedInheld.Value;

                    #region CalculatedInheld_GetScript              

                    if (Store is SubStoreDefinition)
                    {
                        if (Material.DivideAmountToPatient == true)
                            return Inheld.Value * Material.DivideTotalAmount.Value;
                        else
                            return Inheld.Value;
                    }
                    else
                        return Inheld.Value;
                    #endregion CalculatedInheld_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CalculatedInheld") + " : " + ex.Message, ex);
                }
            }
        }


        /// <summary>
        /// Hesaplanmış Dağıtım Şekli
        /// </summary>
        private string _calculatedDistributionType = string.Empty;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public string CalculatedDistributionType
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_calculatedDistributionType) == false)
                        return _calculatedDistributionType;

                    #region CalculatedDistributionType_GetScript    
                    if (Store is SubStoreDefinition)
                    {
                        if (Material.DivideAmountToPatient == true)
                        {
                            if (Material.DivideUnitDefinition != null)
                                return Material.DivideUnitDefinition.Name;
                            else
                                return Material.StockCard.DistributionType.DistributionType;

                        }
                        else
                        {
                            if (Material.StockCard != null)
                                return Material.StockCard.DistributionType.DistributionType;
                            else
                                return string.Empty;
                        }
                    }
                    else
                    {
                        if (Material.StockCard != null)
                            return Material.StockCard.DistributionType.DistributionType;
                        else
                            return string.Empty;
                    }
                    #endregion CalculatedDistributionType_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CalculatedDistributionType") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "TOTALOUTPRICE":
                    {
                        BigCurrency? value = (BigCurrency?)newValue;
                        #region TOTALOUTPRICE_SetScript
                        if (value.HasValue && value.Value < 0 && _fieldNotGiveError == false)
                            throw new Exception(SystemMessage.GetMessageV3(1248, new string[] { Material.Name.ToString(), value.ToString() }));
                        #endregion TOTALOUTPRICE_SetScript
                    }
                    break;
                case "TOTALINPRICE":
                    {
                        BigCurrency? value = (BigCurrency?)newValue;
                        #region TOTALINPRICE_SetScript
                        if (value.HasValue && value.Value < 0)
                        {
                            if ((value.Value * -1) > 0.000099)
                                throw new Exception(SystemMessage.GetMessageV3(1250, new string[] { Material.Name.ToString(), value.ToString() }));
                        }
                        #endregion TOTALINPRICE_SetScript
                    }
                    break;
                case "TOTALOUT":
                    {
                        Currency? value = (Currency?)newValue;
                        #region TOTALOUT_SetScript
                        if (value.HasValue && value.Value < 0 && _fieldNotGiveError == false)
                            throw new Exception(SystemMessage.GetMessageV3(1248, new string[] { Material.Name.ToString(), value.ToString() }));
                        #endregion TOTALOUT_SetScript
                    }
                    break;
                case "CONSIGNED":
                    {
                        Currency? value = (Currency?)newValue;
                        #region CONSIGNED_SetScript
                        if (value.HasValue && value.Value < 0 && _fieldNotGiveError == false)
                            throw new Exception(SystemMessage.GetMessageV3(1251, new string[] { Material.Name.ToString(), value.ToString() }));
                        #endregion CONSIGNED_SetScript
                    }
                    break;
                case "INHELD":
                    {
                        Currency? value = (Currency?)newValue;
                        #region INHELD_SetScript
                        if (value.HasValue && value.Value < 0 && _fieldNotGiveError == false)
                            throw new Exception(SystemMessage.GetMessageV3(1249, new string[] { Material.Name.ToString(), value.ToString() }));
                        #endregion INHELD_SetScript
                    }
                    break;
                case "TOTALIN":
                    {
                        Currency? value = (Currency?)newValue;
                        #region TOTALIN_SetScript
                        if (value.HasValue && value.Value < 0 && _fieldNotGiveError == false)
                            throw new Exception(SystemMessage.GetMessageV3(1250, new string[] { Material.Name.ToString(), value.ToString() }));
                        #endregion TOTALIN_SetScript
                    }
                    break;

            }
        }

        #region Methods
        private bool _fieldNotGiveError;
        public bool FieldNotGiveError
        {
            get { return _fieldNotGiveError; }
        }

        public Stock(TTObjectContext ctx, Store store, Material material, double minimumLevel, double maximumLevel, double safetyLevel)
            : this(ctx)
        {
            Inheld = 0;
            Consigned = 0;
            TotalIn = 0;
            TotalInPrice = 0;
            TotalOut = 0;
            TotalOutPrice = 0;
            Store = store;
            Material = material;
            MinimumLevel = minimumLevel;
            MaximumLevel = maximumLevel;
            SafetyLevel = safetyLevel;
            LastUpdate = TTObjectDefManager.ServerTime;

            if (material.IsExpendableMaterial.HasValue)
                Expendable = material.IsExpendableMaterial;
        }

        public Stock(TTObjectContext ctx, Store store, Material material)
            : this(ctx, store, material, 0, 0, 0)
        {
        }

        public void SetFieldNotGiveError()
        {
            _fieldNotGiveError = true;
        }

        public void StockFieldsUpdate(StockTransaction stockTransaction, bool cancelled)
        {
            StockFieldsUpdate(stockTransaction, cancelled, false);
        }

        public void StockFieldsUpdate(StockTransaction stockTransaction, bool cancelled, bool forStockCensus)
        {
            if (stockTransaction.Amount.HasValue == false || stockTransaction.Amount.Value == 0)
            {
                if (_fieldNotGiveError == false)
                    throw new Exception(SystemMessage.GetMessage(528));
            }

            switch (stockTransaction.MaintainLevelCode)
            {
                case MaintainLevelCodeEnum.IncreaseInheld:
                    if (cancelled)
                    {
                        if (stockTransaction.StockTransactionDefinition.TransactionType != TransactionTypeEnum.ChangeStockLevel)
                        {
                            Inheld -= stockTransaction.Amount;
                            TotalIn -= stockTransaction.Amount;
                            TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                        }
                        SetStockLevel(stockTransaction, true);
                    }
                    else
                    {
                        if (stockTransaction.StockTransactionDefinition.TransactionType != TransactionTypeEnum.ChangeStockLevel)
                        {
                            Inheld += stockTransaction.Amount;
                            TotalIn += stockTransaction.Amount;
                            TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                        }
                        SetStockLevel(stockTransaction, false);
                    }
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld:
                    if (cancelled)
                    {
                        if (stockTransaction.StockTransactionDefinition.TransactionType != TransactionTypeEnum.ChangeStockLevel)
                        {
                            Inheld += stockTransaction.Amount;
                            TotalOut -= stockTransaction.Amount;
                            TotalOutPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                        }
                        SetStockLevel(stockTransaction, false);
                    }
                    else
                    {
                        if (stockTransaction.StockTransactionDefinition.TransactionType != TransactionTypeEnum.ChangeStockLevel)
                        {
                            Inheld -= stockTransaction.Amount;
                            TotalOut += stockTransaction.Amount;
                            TotalOutPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                        }
                        SetStockLevel(stockTransaction, true);
                    }
                    break;
                case MaintainLevelCodeEnum.IncreaseConsigned:
                    if (cancelled)
                    {
                        Consigned -= stockTransaction.Amount;
                        TotalIn -= stockTransaction.Amount;
                        TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        Consigned += stockTransaction.Amount;
                        TotalIn += stockTransaction.Amount;
                        TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.DecreaseConsigned:
                    if (cancelled)
                    {
                        Consigned += stockTransaction.Amount;
                        TotalOut -= stockTransaction.Amount;
                        TotalOutPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        Consigned -= stockTransaction.Amount;
                        TotalOut += stockTransaction.Amount;
                        TotalOutPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.IncreaseInheld__DecreaseConsigned:
                    if (cancelled)
                    {
                        Inheld -= stockTransaction.Amount;
                        Consigned += stockTransaction.Amount;
                        SetStockLevel(stockTransaction, true);
                    }
                    else
                    {
                        Inheld += stockTransaction.Amount;
                        Consigned -= stockTransaction.Amount;
                        SetStockLevel(stockTransaction, false);
                    }
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld__IncreaseConsigned:
                    if (cancelled)
                    {
                        Inheld += stockTransaction.Amount;
                        Consigned -= stockTransaction.Amount;
                        SetStockLevel(stockTransaction, false);
                    }
                    else
                    {
                        Inheld -= stockTransaction.Amount;
                        Consigned += stockTransaction.Amount;
                        SetStockLevel(stockTransaction, true);
                    }
                    break;
                case MaintainLevelCodeEnum.ReturnInheld:
                    if (cancelled)
                    {
                        Inheld += stockTransaction.Amount;
                        TotalIn += stockTransaction.Amount;
                        TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                        SetStockLevel(stockTransaction, false);
                    }
                    else
                    {
                        Inheld -= stockTransaction.Amount;
                        TotalIn -= stockTransaction.Amount;
                        TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                        SetStockLevel(stockTransaction, true);
                    }
                    break;
                default:
                    throw new Exception(SystemMessage.GetMessage(529));
            }
            if (forStockCensus == false)
                StockTransactions.Add(stockTransaction);

            LastUpdate = TTObjectDefManager.ServerTime;
        }




        public void StockFieldsUpdateForCostAction(StockTransaction stockTransaction)
        {
            if (stockTransaction.Amount.HasValue == false || stockTransaction.Amount.Value == 0)
            {
                if (_fieldNotGiveError == false)
                    throw new Exception(SystemMessage.GetMessage(528));
            }
            switch (stockTransaction.MaintainLevelCode)
            {
                case MaintainLevelCodeEnum.IncreaseInheld:
                    if (stockTransaction.StockTransactionDefinition.TransactionType != TransactionTypeEnum.ChangeStockLevel)
                    {
                        Inheld += stockTransaction.Amount;
                        TotalIn += stockTransaction.Amount;
                        TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    SetStockLevel(stockTransaction, false);
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld:
                    if (stockTransaction.StockTransactionDefinition.TransactionType != TransactionTypeEnum.ChangeStockLevel)
                    {
                        Inheld -= stockTransaction.Amount;
                        TotalOut += stockTransaction.Amount;
                        TotalOutPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    SetStockLevel(stockTransaction, true);
                    break;
                case MaintainLevelCodeEnum.ReturnInheld:
                    Inheld -= stockTransaction.Amount;
                    SetStockLevel(stockTransaction, true);
                    break;
                case MaintainLevelCodeEnum.IncreaseInheld__DecreaseConsigned:
                    Inheld += stockTransaction.Amount;
                    // Consigned -= stockTransaction.Amount;
                    SetStockLevel(stockTransaction, false);
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld__IncreaseConsigned:
                    Inheld -= stockTransaction.Amount;
                    // Consigned += stockTransaction.Amount;
                    SetStockLevel(stockTransaction, true);
                    break;
                default:
                    throw new Exception(SystemMessage.GetMessage(529));
            }

            //StockTransactions.Add(stockTransaction);
        }

        public class StockOutOperation_Sonuc
        {
            public bool sonuc { get; set; }
            public string sonucMesaji { get; set; }
        }

        public static Stock.StockOutOperation_Sonuc StockOutOperation(Guid storeID, Guid materialID, int amount, Guid integrationEpisodeActionID)
        {
            Stock.StockOutOperation_Sonuc sonuc = new Stock.StockOutOperation_Sonuc();
            sonuc.sonuc = true;
            sonuc.sonucMesaji = TTUtils.CultureService.GetText("M25244", "Başarılı");
            TTObjectContext context = new TTObjectContext(false);
            Store store = (Store)context.GetObject(storeID, typeof(Store));
            Material material = (Material)context.GetObject(materialID, typeof(Material));

            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            Guid setMalzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SETMATERIALOBJECTID", Guid.Empty.ToString()));
            if (material.ObjectID != malzemeObjectID && material.ObjectID != setMalzemeObjectID)
            {
                if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
                {
                    bool stockout = false;

                    Stock stock = store.GetStock(material);

                    if (stock.Inheld != null)
                    {
                        if (stock.Inheld > 0 && stock.Inheld >= amount)
                        {
                            StockOut stockOut = new StockOut(context);
                            stockOut.CurrentStateDefID = StockOut.States.New;
                            stockOut.Store = store;

                            StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockOutMaterials.AddNew();
                            stockActionDetailOut.Material = material;
                            stockActionDetailOut.Amount = amount;
                            stockActionDetailOut.StockLevelType = StockLevelType.NewStockLevel;
                            stockActionDetailOut.Status = StockActionDetailStatusEnum.New;
                            stockOut.Update();
                            stockOut.CurrentStateDefID = StockOut.States.Completed;

                            IntegrationEpisodeAction integrationEpisodeAction = (IntegrationEpisodeAction)context.GetObject(integrationEpisodeActionID, typeof(IntegrationEpisodeAction));
                            IntegrationTreatmentMaterial integrationTreatmentMaterial = new IntegrationTreatmentMaterial(context);
                            integrationTreatmentMaterial.Material = material;
                            integrationTreatmentMaterial.Amount = amount;
                            integrationTreatmentMaterial.StockActionDetail = stockActionDetailOut;
                            integrationTreatmentMaterial.Active = true;
                            integrationTreatmentMaterial.ActionDate = stockOut.TransactionDate;
                            integrationTreatmentMaterial.Eligible = true;
                            integrationTreatmentMaterial.Episode = integrationEpisodeAction.Episode;
                            //this.ObjectContext.Update();
                            //this.CurrentStateDefID = SubActionMaterial.States.Completed;
                        }
                        else
                        {
                            sonuc.sonuc = false;
                            sonuc.sonucMesaji = TTUtils.CultureService.GetText("M27254", "Yeterli Mevcut yoktur.") + " Malzeme : " + material.Name.ToString() + " " + material.NATOStockNO.ToString();
                        }
                    }
                }

            }
            try
            {
                context.Save();
            }
            catch (Exception ex)
            {
                sonuc.sonuc = false;
                sonuc.sonucMesaji = ex.ToString();
            }
            finally
            {
                context.Dispose();
            }
            return sonuc;
        }

        public static Stock.StockOutOperation_Sonuc StockOutOperationForSparePart(Guid storeID, Guid materialID, int amount, string description)
        {
            Stock.StockOutOperation_Sonuc sonuc = new Stock.StockOutOperation_Sonuc();
            sonuc.sonuc = true;
            sonuc.sonucMesaji = TTUtils.CultureService.GetText("M25244", "Başarılı");
            TTObjectContext context = new TTObjectContext(false);
            Store store = (Store)context.GetObject(storeID, typeof(Store));
            Material material = (Material)context.GetObject(materialID, typeof(Material));

            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            Guid setMalzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SETMATERIALOBJECTID", Guid.Empty.ToString()));
            if (material.ObjectID != malzemeObjectID && material.ObjectID != setMalzemeObjectID)
            {
                if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
                {
                    bool stockout = false;

                    Stock stock = store.GetStock(material);

                    if (stock.Inheld != null)
                    {
                        if (stock.Inheld > 0 && stock.Inheld >= amount)
                        {
                            StockOut stockOut = new StockOut(context);
                            stockOut.CurrentStateDefID = StockOut.States.New;
                            stockOut.Store = store;
                            stockOut.Description = description;

                            StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockOutMaterials.AddNew();
                            stockActionDetailOut.Material = material;
                            stockActionDetailOut.Amount = amount;
                            stockActionDetailOut.StockLevelType = StockLevelType.NewStockLevel;
                            stockActionDetailOut.Status = StockActionDetailStatusEnum.New;
                            stockOut.Update();
                            stockOut.CurrentStateDefID = StockOut.States.Completed;
                        }
                        else
                        {
                            sonuc.sonuc = false;
                            sonuc.sonucMesaji = TTUtils.CultureService.GetText("M27254", "Yeterli Mevcut yoktur.") + " Malzeme : " + material.Name.ToString() + " " + material.NATOStockNO.ToString();
                        }
                    }
                }
            }
            try
            {
                context.Save();
            }
            catch (Exception ex)
            {
                sonuc.sonuc = false;
                sonuc.sonucMesaji = ex.ToString();
            }
            finally
            {
                context.Dispose();
            }
            return sonuc;
        }

        public StockLevel NewStockLevel
        {
            get
            {
                return GetStockLevel(StockLevelType.NewStockLevel);
            }
        }

        public StockLevel UsedStockLevel
        {
            get
            {
                return GetStockLevel(StockLevelType.UsedStockLevel);
            }
        }

        public StockLevel HEKStockLevel
        {
            get
            {
                return GetStockLevel(StockLevelType.HekStockLevel);
            }
        }

        public StockLevel GetStockLevel(StockLevelType stockLevelType)
        {
            IList stockLevels = StockLevels.Select("STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelType.ObjectID));
            if (stockLevels.Count > 1)
                throw new Exception(SystemMessage.GetMessageV3(530, new string[] { Material.Name, stockLevelType.Description }));
            if (stockLevels.Count == 1)
                return (StockLevel)stockLevels[0];
            return null;
        }

        private void SetStockLevel(StockTransaction stockTransaction, bool decreaseLevel)
        {
            StockLevel stockLevel = GetStockLevel(stockTransaction.StockLevelType);
            if (stockLevel != null)
            {
                if (decreaseLevel)
                    stockLevel.Amount -= stockTransaction.Amount.Value;
                else
                    stockLevel.Amount += stockTransaction.Amount.Value;
            }
            else
            {
                if (_fieldNotGiveError)
                {
                    stockLevel = new StockLevel(ObjectContext);
                    if (decreaseLevel)
                        stockLevel.Amount -= stockTransaction.Amount.Value;
                    else
                        stockLevel.Amount += stockTransaction.Amount.Value;
                    stockLevel.StockLevelType = stockTransaction.StockLevelType;
                    StockLevels.Add(stockLevel);
                }
                else
                {
                    if (decreaseLevel)
                        throw new Exception(SystemMessage.GetMessageV3(531, new string[] { Material.Name, stockTransaction.StockLevelType.Description }));

                    stockLevel = new StockLevel(ObjectContext, stockTransaction);
                    StockLevels.Add(stockLevel);
                }
            }
        }

        public List<StockTransaction> GetRestFIFOTransactions()
        {
            List<StockTransaction> outableTransactions = new List<StockTransaction>();

            IList outableTRX = StockTransaction.RestFIFOStockTransactionsRQ(ObjectID);
            foreach (StockTransaction.RestFIFOStockTransactionsRQ_Class inStockTransaction in outableTRX)
                outableTransactions.Add((StockTransaction)ObjectContext.GetObject(inStockTransaction.ObjectID.Value, typeof(StockTransaction)));
            return outableTransactions;
        }

        public List<StockTransaction> GetRestLIFOTransactions()
        {
            List<StockTransaction> outableTransactions = new List<StockTransaction>();

            IList outableTRX = StockTransaction.RestLIFOStockTransactionsRQ(ObjectID);
            foreach (StockTransaction.RestLIFOStockTransactionsRQ_Class inStockTransaction in outableTRX)
                outableTransactions.Add((StockTransaction)ObjectContext.GetObject(inStockTransaction.ObjectID.Value, typeof(StockTransaction)));
            return outableTransactions;
        }

        public void ToReservation(StockActionDetailOut stockActionDetailOut)
        {
            double reservedAmount = Convert.ToDouble(ReservedAmount + stockActionDetailOut.Amount);
            if (reservedAmount > Inheld)
                throw new Exception(SystemMessage.GetMessageV3(532, new string[] { Material.Name, Inheld.ToString(), reservedAmount.ToString() }));

            string message = string.Empty;
            StockAction stockAction = stockActionDetailOut.StockAction;
            if (stockAction.Store != null && stockAction.DestinationStore == null)
                message = stockAction.Store.Name;

            if (stockAction.Store != null && stockAction.DestinationStore != null)
            {
                if (stockAction.Store is MainStoreDefinition)
                    message = stockAction.DestinationStore.Name;
                if (stockAction.DestinationStore is MainStoreDefinition)
                    message = stockAction.Store.Name;
            }

            StockReservation stockReservation = StockReservations.AddNew();
            stockReservation.Amount = stockActionDetailOut.Amount;
            stockReservation.CurrentStateDefID = StockReservation.States.Reserved;
            stockReservation.Description = stockActionDetailOut.Material.Name + "\r\n" + stockAction.StockActionID + " işlem numarası ile " + message + " için ayırtılmıştır.";
            stockActionDetailOut.StockReservation = stockReservation;

            foreach (QRCodeOutDetail qRCodeOutDetail in stockActionDetailOut.QRCodeOutDetails)
            {
                qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID = QRCodeTransaction.States.Reserved;
            }
        }

        public override string ToString()
        {
            return "Depo: " + Store.Name.ToString() + " Malzeme: " + Material.Name.ToString() + " Mevcut: " + Inheld.ToString();
        }

        public void PrepareOutableStockTransactions(StockActionDetail stockActionDetail)
        {
            if (_outableStockTransactions != null)
            {
                if (_outableStockTransactions.Count > 0)
                    return;
            }

            _outableStockTransactions = null;
            if (stockActionDetail.Amount.HasValue == false || stockActionDetail.StockLevelType == null)
                return;

            CostingMethodEnum costingMethodEnum = CostingMethodEnum.FIFO;
            if (stockActionDetail.StockAction.AccountingTerm != null)
                costingMethodEnum = stockActionDetail.StockAction.AccountingTerm.CostingMethod.Value;

            Guid budgetGuid = Guid.Empty;
            string filterExpression = string.Empty;
            if (((StockActionDetailOut)stockActionDetail).StockAction.DestinationStore is MainStoreDefinition)
            {
                if (((MainStoreDefinition)(((StockActionDetailOut)stockActionDetail).StockAction.DestinationStore)).MKYS_ButceTuru != null)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    List<BudgetTypeDefinition> budgetTypeDefList = context.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)(((StockActionDetailOut)stockActionDetail).StockAction.DestinationStore)).MKYS_ButceTuru.Value).Value).ToList();
                    if (budgetTypeDefList.Count == 1)
                    {
                        budgetGuid = ((BudgetTypeDefinition)budgetTypeDefList[0]).ObjectID;
                        filterExpression += " AND BUDGETTYPEDEFINITION =" + ConnectionManager.GuidToString(budgetGuid);
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

            // UTS için eklendi. Test ve takip gerektiriyor.
            /*if (stockActionDetail.StockTransactions[0].Patient != null)
                filterExpression += "AND PATIENT ='" + ((StockActionDetailOut)stockActionDetail).StockTransactions[0].Patient + "'";
            else
                filterExpression += "AND PATIENT IS NULL";*/


            IList outableTransactions = null;
            switch (costingMethodEnum)
            {
                case CostingMethodEnum.FIFO:
                    outableTransactions = StockTransaction.FIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                    break;
                case CostingMethodEnum.LIFO:
                    outableTransactions = StockTransaction.LIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);

                    break;
                default:
                    outableTransactions = StockTransaction.FIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                    break;
            }

            if (outableTransactions != null && outableTransactions.Count > 0)
            {
                _outableStockTransactions = new List<Stock.OutableStockTransaction>();
                foreach (TTReportNqlObject reportNqlObject in outableTransactions)
                {
                    Stock.OutableStockTransaction outableStockTransaction = new Stock.OutableStockTransaction(this, reportNqlObject);
                    _outableStockTransactions.Add(outableStockTransaction);
                }
            }
        }

        //ERDAL
        public IEnumerable<StockTransaction.LOTOutableStockTransactions_Class> LOTPrepareOutableStockTransactions(Stock stock)
        {
            IEnumerable<StockTransaction.LOTOutableStockTransactions_Class> sonucListesi = null;
            sonucListesi = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
            return sonucListesi;
        }

        //ERDAL
        public IEnumerable<QRCodeTransaction.QRCodeOutableQRCodeTransactions_Class> QRCodePrepareOutableQRCodeTransactions(Stock stock)
        {
            IEnumerable<QRCodeTransaction.QRCodeOutableQRCodeTransactions_Class> sonucListesi = null;
            sonucListesi = QRCodeTransaction.QRCodeOutableQRCodeTransactions(stock.ObjectID);
            return sonucListesi;
        }

        public void WantingQRCodeTransaction(StockActionDetail stockActionDetail, Currency packageAmount)
        {
            if (_outableStockTransactions != null)
            {
                if (_outableStockTransactions.Count > 0)
                    return;
            }

            _outableStockTransactions = null;
            if (stockActionDetail.Amount.HasValue == false || stockActionDetail.StockLevelType == null)
                return;

            CostingMethodEnum costingMethodEnum = CostingMethodEnum.FIFO;
            if (stockActionDetail.StockAction.AccountingTerm != null)
                costingMethodEnum = stockActionDetail.StockAction.AccountingTerm.CostingMethod.Value;

            IList outableTransactions = null;
            switch (costingMethodEnum)
            {
                case CostingMethodEnum.FIFO:
                    outableTransactions = StockTransaction.FIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, null);
                    break;
                case CostingMethodEnum.LIFO:
                    outableTransactions = StockTransaction.LIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, null);
                    break;
                default:
                    outableTransactions = StockTransaction.FIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, null);
                    break;
            }

            if (outableTransactions != null && outableTransactions.Count > 0)
            {
                Currency totalAmount = 0;
                _outableStockTransactions = new List<Stock.OutableStockTransaction>();
                foreach (TTReportNqlObject reportNqlObject in outableTransactions)
                {
                    Stock.OutableStockTransaction outableStockTransaction = new Stock.OutableStockTransaction(this, reportNqlObject);
                    if (outableStockTransaction.RestAmount % packageAmount != 0)
                    {
                        _outableStockTransactions.Add(outableStockTransaction);
                        totalAmount = totalAmount + (Currency)outableStockTransaction.RestAmount;
                    }
                    else
                        break;
                }
            }
        }

        public void UserSelectedOutableStockTransactions(StockActionDetail stockActionDetail)
        {
            List<Guid> selectedTrxObjectIDs = new List<Guid>();
            Dictionary<OuttableLot, Currency> detailOut = new Dictionary<OuttableLot, Currency>();
            foreach (OuttableLot outtableLot in ((StockActionDetailOut)stockActionDetail).OuttableLots)
            {
                if ((bool)outtableLot.isUse)
                {
                    detailOut.Add(outtableLot, (Currency)outtableLot.Amount);
                    if (selectedTrxObjectIDs.Contains(outtableLot.TrxObjectID.Value) == false)
                        selectedTrxObjectIDs.Add(outtableLot.TrxObjectID.Value);
                }
            }

            BindingList<StockTransaction.UserSelectedOutableTransactionRQ_Class> outableStockTransactions = StockTransaction.UserSelectedOutableTransactionRQ(ObjectID);

            if (_outableStockTransactions == null)
                _outableStockTransactions = new List<Stock.OutableStockTransaction>();

            foreach (StockTransaction.UserSelectedOutableTransactionRQ_Class trx in outableStockTransactions)
            {
                if (selectedTrxObjectIDs.Contains(trx.ObjectID.Value))
                {
                    OutableStockTransaction outableStockTransaction = new OutableStockTransaction(this, trx);
                    _outableStockTransactions.Add(outableStockTransaction);
                }
            }

            CheckOutableStockTransaction(detailOut, _outableStockTransactions);
            Currency outableAmount = 0;
            Currency requestAmount = 0;
            foreach (Stock.OutableStockTransaction trx in _outableStockTransactions)
            {
                outableAmount += (Currency)trx.RestAmount;
                requestAmount += (Currency)trx.RequestAmount;
            }
            if (outableAmount < requestAmount)
                throw new TTException(stockActionDetail.Material.Name + " isimli malzeme için seçmiş olduğunuz çıkış yapılabilecek girişlerde kalan miktardan fazla kullanılacak miktar yazılmış. Tekrar düzenleyin.");

            if (outableAmount < stockActionDetail.Amount)
                throw new TTException(stockActionDetail.Material.Name + " isimli malzeme için seçmiş olduğunuz çıkış yapılabilecek girişlerde yeterli mevcut bulunmamaktadır. Tekrar seçin.");

            if (requestAmount < stockActionDetail.Amount)
                throw new TTException(stockActionDetail.Material.Name + " isimli malzeme için seçmiş olduğunuz çıkış yapılabilecek girişlerden kullanılacak mevcut yeterli değildir. Tekrar seçin.");

        }

        public void CheckOutableStockTransaction(Dictionary<OuttableLot, Currency> detailOut, List<Stock.OutableStockTransaction> outableStockTransactions)
        {
            if (detailOut.Count > 0)
            {
                foreach (KeyValuePair<OuttableLot, Currency> det in detailOut)
                {
                    Currency requestRestAmount = (Currency)det.Key.Amount;
                    Stock.OutableStockTransaction trx = outableStockTransactions.Where(x => x.StockTransactionObjectID == det.Key.TrxObjectID).FirstOrDefault();
                    if (trx != null)
                    {
                        trx.UpdateRequestAmount(requestRestAmount);
                    }
                }
            }
            else
            {
                if (outableStockTransactions != null)
                {
                    foreach (Stock.OutableStockTransaction trx in outableStockTransactions)
                        trx.UpdateRequestAmount((Currency)trx.RestAmount);
                }
            }

        }


        public void PrepareOutableStockTransactions(StockActionDetail stockActionDetail, bool lotUse)
        {
            if (lotUse)
            {
                if (_outableStockTransactions != null)
                {
                    if (_outableStockTransactions.Count > 0)
                        return;
                }

                _outableStockTransactions = null;
                if (stockActionDetail.Amount.HasValue == false || stockActionDetail.StockLevelType == null)
                    return;

                CostingMethodEnum costingMethodEnum = CostingMethodEnum.FIFO;
                if (stockActionDetail.StockAction.AccountingTerm != null)
                    costingMethodEnum = stockActionDetail.StockAction.AccountingTerm.CostingMethod.Value;

                Guid budgetGuid = Guid.Empty;
                string filterExpression = string.Empty;
                Store mainstore = null;
                if (((StockActionDetailOut)stockActionDetail).StockAction.DestinationStore == null)
                {
                    if (((StockActionDetailOut)stockActionDetail).StockAction.Store is MainStoreDefinition)
                    {
                        mainstore = ((StockActionDetailOut)stockActionDetail).StockAction.Store;
                    }
                }
                else
                {
                    if (((StockActionDetailOut)stockActionDetail).StockAction.DestinationStore is MainStoreDefinition)
                    {
                        mainstore = ((StockActionDetailOut)stockActionDetail).StockAction.DestinationStore;
                    }
                }


                if (mainstore is MainStoreDefinition)
                {
                    if (((MainStoreDefinition)mainstore).MKYS_ButceTuru != null)
                    {
                        TTObjectContext context = new TTObjectContext(false);
                        List<BudgetTypeDefinition> budgetTypeDefList = context.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)mainstore).MKYS_ButceTuru.Value).Value).ToList();
                        if (budgetTypeDefList.Count == 1)
                        {
                            budgetGuid = ((BudgetTypeDefinition)budgetTypeDefList[0]).ObjectID;
                            if (budgetGuid != Guid.Empty)
                                filterExpression = " AND BUDGETTYPEDEFINITION =" + ConnectionManager.GuidToString(budgetGuid);
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


                Dictionary<OuttableLot, Currency> detailOut = new Dictionary<OuttableLot, Currency>();
                foreach (OuttableLot outtableLot in ((StockActionDetailOut)stockActionDetail).OuttableLots)
                {
                    if ((bool)outtableLot.isUse)
                        detailOut.Add(outtableLot, (Currency)outtableLot.Amount);
                }

                IList outableTransactions = null;
                if (stockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.LotUsed)
                {
                    IList<string> lots = new List<string>();

                    if (((StockActionDetailOut)stockActionDetail).OuttableLots.Count > 0)
                    {
                        foreach (OuttableLot outtableLot in ((StockActionDetailOut)stockActionDetail).OuttableLots)
                        {
                            if ((bool)outtableLot.isUse)
                                lots.Add(outtableLot.LotNo);
                        }
                    }
                    else
                    {
                        throw new TTException(stockActionDetail.Material.Name + " isimli malzemenin herhangibir lotlu girişi seçilmemiştir.");
                    }
                    if (lots.Count > 0)
                    {
                        switch (costingMethodEnum)
                        {
                            case CostingMethodEnum.FIFO:
                                outableTransactions = StockTransaction.FIFOLotOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, lots, filterExpression);
                                break;
                            case CostingMethodEnum.LIFO:
                                outableTransactions = StockTransaction.LIFOLotOutableStockTransactionsRQ(lots, ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                                break;
                            case CostingMethodEnum.EXPIREDATE:
                                outableTransactions = StockTransaction.ExpireDateLotOutableStockTransactionsRQ(lots, ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                                break;
                            default:
                                outableTransactions = StockTransaction.FIFOLotOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, lots, filterExpression);
                                break;
                        }
                    }
                    else
                    {
                        throw new TTException(stockActionDetail.Material.Name + " isimli malzemenin herhangibir lotlu girişi seçilmemiştir.");
                    }
                }
                else if (stockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                {
                    if (stockActionDetail.Material.PackageAmount == null)
                        throw new TTException(stockActionDetail.Material.Name + " isimli malzemenin ambalaj miktarı boş");

                    Currency amount = (Currency)stockActionDetail.Amount;
                    Currency packageAmount = (Currency)stockActionDetail.Material.PackageAmount;
                    Currency qrCodeAmount = ((StockActionDetailOut)stockActionDetail).QRCodeOutDetails.Count;
                    Currency availAmount = amount - (qrCodeAmount * packageAmount);

                    Currency stockInheld = stockActionDetail.Material.StockInheld(stockActionDetail.StockAction.Store, stockActionDetail.StockLevelType);
                    Dictionary<StockTransaction, Currency> inStockTransactions = new Dictionary<StockTransaction, Currency>();
                    if (stockInheld % packageAmount == 0)
                    {
                        if (((StockActionDetailOut)stockActionDetail).QRCodeOutDetails.Count > 0)
                        {
                            foreach (QRCodeOutDetail qrCode in ((StockActionDetailOut)stockActionDetail).QRCodeOutDetails)
                            {
                                if (inStockTransactions.ContainsKey(qrCode.QRCodeTransaction.StockTransaction) == false)
                                {
                                    inStockTransactions.Add(qrCode.QRCodeTransaction.StockTransaction, packageAmount);
                                }
                                else
                                {
                                    inStockTransactions[qrCode.QRCodeTransaction.StockTransaction] = inStockTransactions[qrCode.QRCodeTransaction.StockTransaction] + packageAmount;
                                }
                            }
                        }
                        else
                        {
                            throw new TTException(stockActionDetail.Material.Name + " isimli malzemesi için karekod seçilmemiştir.");
                        }
                    }
                    else
                    {
                        Currency wantingTotalAmout = 0;
                        WantingQRCodeTransaction(stockActionDetail, packageAmount);
                        foreach (Stock.OutableStockTransaction outTrx in _outableStockTransactions)
                        {
                            wantingTotalAmout = wantingTotalAmout + (Currency)outTrx.RestAmount;
                        }
                        if (amount > wantingTotalAmout)
                        {
                            if (((StockActionDetailOut)stockActionDetail).QRCodeOutDetails.Count > 0)
                            {
                                foreach (QRCodeOutDetail qrCode in ((StockActionDetailOut)stockActionDetail).QRCodeOutDetails)
                                {
                                    if (inStockTransactions.ContainsKey(qrCode.QRCodeTransaction.StockTransaction) == false)
                                    {
                                        inStockTransactions.Add(qrCode.QRCodeTransaction.StockTransaction, packageAmount);
                                    }
                                    else
                                    {
                                        inStockTransactions[qrCode.QRCodeTransaction.StockTransaction] = inStockTransactions[qrCode.QRCodeTransaction.StockTransaction] + packageAmount;
                                    }
                                }
                            }
                            else
                            {
                                throw new TTException(stockActionDetail.Material.Name + " isimli malzemesi için karekod seçilmemiştir.");
                            }
                        }
                    }


                    if (inStockTransactions.Count > 0)
                    {
                        _outableStockTransactions = new List<Stock.OutableStockTransaction>();
                        foreach (KeyValuePair<StockTransaction, Currency> trx in inStockTransactions)
                        {
                            Stock.OutableStockTransaction outableStockTransaction = new Stock.OutableStockTransaction(this, trx.Key, trx.Value);
                            _outableStockTransactions.Add(outableStockTransaction);
                        }

                    }
                    else
                    {
                        if (_outableStockTransactions == null)
                            throw new TTException(stockActionDetail.Material.Name + " isimli malzemesi için karekod seçilmemiştir.");
                    }
                }
                else if (stockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated)
                {
                    bool nullTime = false;
                    IList<DateTime> expirationDates = new List<DateTime>();
                    if (((StockActionDetailOut)stockActionDetail).OuttableLots.Count > 0)
                    {
                        foreach (OuttableLot outtableLot in ((StockActionDetailOut)stockActionDetail).OuttableLots)
                        {
                            if ((bool)outtableLot.isUse)
                            {
                                if (outtableLot.ExpirationDate == null)
                                {
                                    expirationDates.Add(DateTime.MinValue);
                                    nullTime = true;
                                }
                                else if (((DateTime)outtableLot.ExpirationDate).Date == DateTime.MinValue)
                                {
                                    expirationDates.Add((DateTime)outtableLot.ExpirationDate);
                                    nullTime = true;
                                }
                                else
                                    expirationDates.Add((DateTime)outtableLot.ExpirationDate);
                            }
                        }
                    }
                    else
                    {
                        throw new TTException(stockActionDetail.Material.Name + " isimli malzemenin herhangibir son kullanma tarihli girişi seçilmemiştir.");
                    }
                    if (expirationDates.Count > 0)
                    {
                        switch (costingMethodEnum)
                        {
                            case CostingMethodEnum.FIFO:
                                if (nullTime)
                                {
                                    outableTransactions = StockTransaction.FIFOExpirationOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, expirationDates, 1, filterExpression);
                                }
                                else
                                {
                                    outableTransactions = StockTransaction.FIFOExpirationOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, expirationDates, 0, filterExpression);
                                }
                                break;
                            case CostingMethodEnum.LIFO:
                                if (nullTime)
                                {
                                    outableTransactions = StockTransaction.LIFOExpirationOutableStockTransactionsRQ(expirationDates, ObjectID, stockActionDetail.StockLevelType.ObjectID, 1, filterExpression);
                                }
                                else
                                {
                                    outableTransactions = StockTransaction.LIFOExpirationOutableStockTransactionsRQ(expirationDates, ObjectID, stockActionDetail.StockLevelType.ObjectID, 0, filterExpression);
                                }
                                break;
                            case CostingMethodEnum.EXPIREDATE:
                                if (nullTime)
                                {
                                    outableTransactions = StockTransaction.ExpireDateExpirationOutableStockTransactionsRQ(expirationDates, 1, ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                                }
                                else
                                {
                                    outableTransactions = StockTransaction.ExpireDateExpirationOutableStockTransactionsRQ(expirationDates, 0, ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                                }
                                break;
                            default:
                                if (nullTime)
                                {
                                    outableTransactions = StockTransaction.FIFOExpirationOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, expirationDates, 1, filterExpression);
                                }
                                else
                                {
                                    outableTransactions = StockTransaction.FIFOExpirationOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, expirationDates, 0, filterExpression);
                                }
                                break;
                        }
                    }
                    else
                    {
                        throw new TTException(stockActionDetail.Material.Name + " isimli malzemenin herhangibir son kullanma tarihli girişi seçilmemiştir.");
                    }
                }
                else
                {
                    switch (costingMethodEnum)
                    {
                        case CostingMethodEnum.FIFO:
                            outableTransactions = StockTransaction.FIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                            break;
                        case CostingMethodEnum.LIFO:
                            outableTransactions = StockTransaction.LIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);

                            break;
                        case CostingMethodEnum.EXPIREDATE:
                            outableTransactions = StockTransaction.ExpireDateOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                            break;
                        default:
                            outableTransactions = StockTransaction.FIFOOutableStockTransactionsRQ(ObjectID, stockActionDetail.StockLevelType.ObjectID, filterExpression);
                            break;
                    }
                }

                if (_outableStockTransactions == null)
                {
                    if (outableTransactions != null && outableTransactions.Count > 0)
                    {
                        _outableStockTransactions = new List<Stock.OutableStockTransaction>();
                        foreach (TTReportNqlObject reportNqlObject in outableTransactions)
                        {
                            StockTransaction outTrx = ((StockTransaction)reportNqlObject.TTObject);
                            if (outTrx.InOut == TransactionTypeEnum.In && outTrx.Stock.Material.ObjectID.Equals(Material.ObjectID))
                            {
                                if (((StockActionDetailOut)stockActionDetail).IsZeroUnitPrice.HasValue && (bool)((StockActionDetailOut)stockActionDetail).IsZeroUnitPrice)
                                {
                                    if (outTrx.UnitPrice == 0)
                                    {
                                        Stock.OutableStockTransaction outableStockTransaction = new Stock.OutableStockTransaction(this, reportNqlObject);
                                        _outableStockTransactions.Add(outableStockTransaction);
                                    }
                                }
                                else
                                {
                                    Stock.OutableStockTransaction outableStockTransaction = new Stock.OutableStockTransaction(this, reportNqlObject);
                                    _outableStockTransactions.Add(outableStockTransaction);
                                }
                            }
                        }
                    }
                }

                UpdateOutableStockTransaction(detailOut, _outableStockTransactions);
                Currency outableAmount = 0;
                Currency reguestAmount = 0;
                foreach (Stock.OutableStockTransaction trx in _outableStockTransactions)
                {
                    outableAmount += (Currency)trx.RestAmount;
                    reguestAmount += (Currency)trx.RequestAmount;
                }
                if (outableAmount < reguestAmount)
                    throw new TTException(stockActionDetail.Material.Name + " isimli malzeme için seçmiş olduğunuz çıkış yapılabilecek girişlerde kalan miktardan fazla kullanılacak miktar yazılmış. Tekrar düzenleyin.");

                if (outableAmount < stockActionDetail.Amount)
                    throw new TTException(stockActionDetail.Material.Name + " isimli malzeme için seçmiş olduğunuz çıkış yapılabilecek girişlerde yeterli mevcut bulunmamaktadır. Tekrar seçin.");

                if (reguestAmount < stockActionDetail.Amount)
                    throw new TTException(stockActionDetail.Material.Name + " isimli malzeme için seçmiş olduğunuz çıkış yapılabilecek girişlerden kullanılacak mevcut yeterli değildir. Tekrar seçin.");

            }
            else
            {
                PrepareOutableStockTransactions(stockActionDetail);
            }
        }

        public void UpdateOutableStockTransaction(Dictionary<OuttableLot, Currency> detailOut, List<Stock.OutableStockTransaction> outableStockTransactions)
        {
            if (detailOut.Count > 0)
            {
                foreach (KeyValuePair<OuttableLot, Currency> det in detailOut)
                {
                    Currency requestRestAmount = (Currency)det.Key.Amount;
                    foreach (Stock.OutableStockTransaction trx in outableStockTransactions)
                    {
                        StockTransaction outTrx = ((StockTransaction)trx.StockTransaction);
                        DateTime expireDate;
                        if (outTrx.ExpirationDate != null)
                            expireDate = (DateTime)outTrx.ExpirationDate;
                        else
                            expireDate = DateTime.MinValue;
                        if (det.Key.LotNo == outTrx.LotNo && ((DateTime)det.Key.ExpirationDate).Date == expireDate.Date)
                        {
                            if (requestRestAmount > 0)
                            {
                                if (requestRestAmount >= trx.RestAmount)
                                    trx.UpdateRequestAmount((Currency)trx.RestAmount);
                                else
                                    trx.UpdateRequestAmount(requestRestAmount);

                                requestRestAmount -= (Currency)trx.RequestAmount;
                            }
                            else
                                trx.UpdateRequestAmount(0);
                        }
                    }
                }
            }
            else
            {
                if (outableStockTransactions != null)
                {
                    foreach (Stock.OutableStockTransaction trx in outableStockTransactions)
                        trx.UpdateRequestAmount((Currency)trx.RestAmount);
                }
            }

        }

        public List<Stock.OutableStockTransaction> _outableStockTransactions;
        public List<Stock.OutableStockTransaction> OutableStockTransactions
        {
            get { return _outableStockTransactions; }
        }

        public class OutableStockTransaction
        {
            private Stock _stock;
            public Stock Stock
            {
                get { return _stock; }
            }

            private Guid? _stockTransactionObjectID;
            public Guid? StockTransactionObjectID
            {
                get { return _stockTransactionObjectID; }
            }

            private DateTime? _transactionDate;
            public DateTime? TransactionDate
            {
                get { return _transactionDate; }
            }

            private Currency? _amount;
            public Currency? Amount
            {
                get { return _amount; }
            }

            private Currency? _usedAmount;
            public Currency? UsedAmount
            {
                get { return _usedAmount; }
            }

            private Currency? _restAmount;
            public Currency? RestAmount
            {
                get { return _restAmount; }
            }
            private Currency? _requestAmount;
            public Currency? RequestAmount
            {
                get { return _requestAmount; }
            }

            public StockTransaction StockTransaction
            {
                get
                {
                    return (StockTransaction)_stock.ObjectContext.GetObject(_stockTransactionObjectID.Value, typeof(StockTransaction));
                }
            }

            public void DescreaseRestAmount(Currency amount)
            {
                _restAmount -= amount;
            }

            public void DescreaseRequestAmount(Currency amount)
            {
                _requestAmount -= amount;
            }
            public void UpdateRequestAmount(Currency amount)
            {
                _requestAmount = amount;
            }


            public OutableStockTransaction(Stock stock, TTReportNqlObject reportNqlObject)
            {
                _stock = stock;

                object o;
                reportNqlObject.TryGetValue("OBJECTID", out o);
                _stockTransactionObjectID = new Guid((string)o);

                reportNqlObject.TryGetValue("TRANSACTIONDATE", out o);
                _transactionDate = (DateTime?)o;

                reportNqlObject.TryGetValue("AMOUNT", out o);
                _amount = CurrencyType.ConvertFrom(o);

                reportNqlObject.TryGetValue("USEDAMOUNT", out o);
                _usedAmount = CurrencyType.ConvertFrom(o);

                reportNqlObject.TryGetValue("RESTAMOUNT", out o);
                _restAmount = CurrencyType.ConvertFrom(o);

                _requestAmount = 0;

            }

            public OutableStockTransaction(Stock stock, TTReportNqlObject reportNqlObject, Currency requestAmount)
            {
                _stock = stock;

                object o;
                reportNqlObject.TryGetValue("OBJECTID", out o);
                _stockTransactionObjectID = new Guid((string)o);

                reportNqlObject.TryGetValue("TRANSACTIONDATE", out o);
                _transactionDate = (DateTime?)o;

                reportNqlObject.TryGetValue("AMOUNT", out o);
                _amount = CurrencyType.ConvertFrom(o);

                reportNqlObject.TryGetValue("USEDAMOUNT", out o);
                _usedAmount = CurrencyType.ConvertFrom(o);

                reportNqlObject.TryGetValue("RESTAMOUNT", out o);
                _restAmount = CurrencyType.ConvertFrom(o);

                _requestAmount = requestAmount;

            }

            public OutableStockTransaction(Stock stock, StockTransaction stocktransaction, Currency restAmount)
            {
                _stock = stock;
                _stockTransactionObjectID = stocktransaction.ObjectID;
                _transactionDate = stocktransaction.TransactionDate;
                _amount = stocktransaction.Amount;
                _usedAmount = 0;
                _restAmount = restAmount;
                _requestAmount = 0;

            }
        }

        #endregion Methods

    }
}