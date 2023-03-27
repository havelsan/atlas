
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
    /// Stok Hareket Detaylarının temel detaylarını barındırır.
    /// </summary>
    public abstract partial class StockActionDetail : TTObject, IStockActionDetail
    {
        public partial class GetActionDetailsForCensus_InventoryAccountReport_Class : TTReportNqlObject
        {
        }

        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion



        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            if (Amount < 0)
            {
                throw new Exception(Material.Name + " isimli malzemeye 0 dan düşük değer girilemez!");
            }
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            if (Amount < 0)
            {
                throw new Exception(Material.Name + " isimli malzemeye 0 dan düşük değer girilemez!");
            }

            #endregion PreUpdate
        }

        public override void OnContextDispose()
        {
            base.OnContextDispose();
            _storeStock = StoreStock;
            _destinationStoreStock = DestinationStoreStock;
            _destinationStoreMaxLevel = DestinationStoreMaxLevel;
        }
        /// <summary>
        /// Depo Mevcudu
        /// </summary>
        private double? _storeStock = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public double StoreStock
        {
            get
            {
                try
                {
                    if (_storeStock.HasValue)
                        return _storeStock.Value;

                    #region StoreStock_GetScript              

                    if (((ITTObject)this).IsDeleted == false)
                    {
                        if (StockAction != null)
                        {
                            if (Material != null && StockAction.Store != null && StockLevelType != null)
                            {
                                if (Material.DividePriceToVolume.HasValue && Material.DividePriceToVolume.Value)
                                {
                                    return Math.Floor(Material.StockInheld(StockAction.Store, StockLevelType));
                                }
                                else
                                {
                                    return Material.StockInheld(StockAction.Store, StockLevelType);
                                }
                            }
                                
                            if (Material != null && StockAction.Store != null)
                            {
                                if (Material.DividePriceToVolume.HasValue && Material.DividePriceToVolume.Value)
                                {
                                    return Math.Floor(Material.StockInheld(StockAction.Store));
                                }
                                else
                                {
                                    return Material.StockInheld(StockAction.Store);
                                }
                            }
                        }
                    }
                    return 0;
                    #endregion StoreStock_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "StoreStock") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Depo Mevcudu
        /// </summary>
        /// 
        private double? _destinationStoreStock = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public double DestinationStoreStock
        {
            get
            {
                try
                {
                    if (_destinationStoreStock.HasValue)
                        return _destinationStoreStock.Value;

                    #region DestinationStoreStock_GetScript          
                    if (((ITTObject)this).IsDeleted == false)
                    {
                        if (StockAction != null)
                        {
                            if (Material != null && StockAction.DestinationStore != null && StockLevelType != null)
                            {
                                if (Material.DividePriceToVolume.HasValue && Material.DividePriceToVolume.Value)
                                {
                                    return Math.Floor(Material.StockInheld(StockAction.DestinationStore, StockLevelType));
                                }
                                else
                                {
                                    return Material.StockInheld(StockAction.DestinationStore, StockLevelType);
                                }
                            }

                            if (Material != null && StockAction.DestinationStore != null)
                            {
                                if (Material.DividePriceToVolume.HasValue && Material.DividePriceToVolume.Value)
                                {
                                    return Math.Floor(Material.StockInheld(StockAction.DestinationStore));
                                }
                                else
                                {
                                    return Material.StockInheld(StockAction.DestinationStore);
                                }
                            }
                        }
                    }
                    return 0;
                    #endregion DestinationStoreStock_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DestinationStoreStock") + " : " + ex.Message, ex);
                }
            }
        }

        private double? _destinationStoreMaxLevel = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public double DestinationStoreMaxLevel
        {
            get
            {
                try
                {
                    if (_destinationStoreMaxLevel.HasValue)
                        return _destinationStoreMaxLevel.Value;

                    #region DestinationStoreMaxLevel_GetScript          
                    if (((ITTObject)this).IsDeleted == false)
                    {
                        if (StockAction != null)
                        {
                            if (Material != null && StockAction.DestinationStore != null)
                                return Material.StockMaxLevel(StockAction.DestinationStore);
                        }
                    }
                    return 0;
                    #endregion DestinationStoreMaxLevel_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DestinationStoreMaxLevel") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "STOCKLEVELTYPE":
                    {
                        StockLevelType value = (StockLevelType)newValue;
                        #region STOCKLEVELTYPE_SetParentScript
                        if (value != null && Material != null)
                            CheckStockLevel(Material, value);
                        #endregion STOCKLEVELTYPE_SetParentScript
                    }
                    break;
                case "MATERIAL":
                    {
                        Material value = (Material)newValue;
                        #region MATERIAL_SetParentScript
                        if (value != null)
                        {

                            if (SystemParameter.GetParameterValue("PRESCRIPTIONPAPERUSE", "TRUE") == "TRUE")
                            {
                                TTObjectContext readOnlyContex = new TTObjectContext(true);
                                IList pres = readOnlyContex.QueryObjects("PRESTYPEMATERIALMATCHDEF", "MATERIAL =" + ConnectionManager.GuidToString(value.ObjectID));
                                if (pres.Count > 0 && StockAction is IBasePrescriptionTransaction == false)
                                    throw new Exception(value.Name + " malzemesi Reçete olduğu için bu işlemde seçemezsiniz");
                                readOnlyContex.Dispose();
                            }

                            if (StockLevelType != null)
                                CheckStockLevel(value, StockLevelType);

                            if (this is StockActionDetailIn)
                            {
                                if (((StockActionDetailIn)this).VatRate == null)
                                {
                                    ((StockActionDetailIn)this).VatRate = value.CurrentVatRate;
                                }
                                if (StockAction != null)
                                {
                                    if (StockAction.IsEntryOldMaterial.HasValue)
                                    {
                                        if (StockAction.IsEntryOldMaterial == false)
                                        {
                                            if (value.IsOldMaterial != null)
                                            {
                                                if ((bool)value.IsOldMaterial)
                                                    throw new Exception(TTUtils.CultureService.GetText("M25616", "Eski malzemelere giriş yapamazsınız!"));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (value.IsOldMaterial != null)
                                        {
                                            if ((bool)value.IsOldMaterial)
                                                throw new Exception(TTUtils.CultureService.GetText("M25616", "Eski malzemelere giriş yapamazsınız!"));
                                        }
                                    }
                                }
                                else
                                {
                                    if (value.IsOldMaterial != null)
                                    {
                                        if ((bool)value.IsOldMaterial)
                                            throw new Exception(TTUtils.CultureService.GetText("M25616", "Eski malzemelere giriş yapamazsınız!"));
                                    }
                                }
                            }
                            else
                            {
                                if (StockAction is IChattelDocumentOutputWithAccountancy)
                                {
                                    IChattelDocumentOutputWithAccountancy outDocument = StockAction as IChattelDocumentOutputWithAccountancy;

                                    bool nonBarcode = false;
                                    if (outDocument.GetAccountancy() != null)
                                    {
                                        Accountancy acc = (Accountancy)ObjectContext.GetObject(outDocument.GetAccountancy().GetObjectID(), "ACCOUNTANCY");
                                        if (acc.IsNonBarcode.HasValue)
                                        {
                                            if ((bool)acc.IsNonBarcode)
                                                nonBarcode = true;
                                        }
                                    }

                                    if (nonBarcode == false)
                                    {
                                        if (outDocument.GetAccountancy() != null)
                                        {
                                            if (outDocument.GetAccountancy().GetAccountancyMilitaryUnit() != null)
                                            {
                                                MilitaryUnit militaryUnit = (MilitaryUnit)ObjectContext.GetObject(outDocument.GetAccountancy().GetAccountancyMilitaryUnit().GetObjectID(), "MILITARYUNIT");
                                                if (militaryUnit.IsSupported.HasValue && militaryUnit.IsSupported.Value)
                                                {
                                                    if (string.IsNullOrEmpty(value.Barcode))
                                                        throw new Exception(TTUtils.CultureService.GetText("M25192", "XXXXXX içi saymanlıklara barkodsuz malzeme gönderemezsiniz."));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //TODO: Ana Malzeme Detaylandırılması sonucunda kapatılmıştır
                        //                        if (value is FixedAssetDefinition && (this is ChequeDocumentMaterial == false) && (this is StockFirstTransferDetail == false) && (this is StockActionDetailIn == false))
                        //                        {
                        //                            foreach (FixedAssetMaterialDefinition fixmat in ((FixedAssetDefinition)value).FixedAssetMaterialDefinitions)
                        //                            {
                        //                                if (fixmat.Stock != null)
                        //                                {
                        //                                    if (fixmat.Stock.Store.ObjectID == this.StockAction.Store.ObjectID)
                        //                                    {
                        //                                        if (fixmat.SerialNumber == null || fixmat.Model == null)
                        //                                            throw new Exception(SystemMessage.GetMessage(1045));
                        //                                    }
                        //                                }
                        //                            }
                        //                        }
                        #endregion MATERIAL_SetParentScript
                    }
                    break;

            }
        }

        #region Methods
        protected bool _priceCalculated = false;
        protected BigCurrency _outPrice;
        protected BigCurrency _outUnitPrice;
        protected void CalculatePrice()
        {
            CalculatePrice(true);
        }

        protected void CalculatePrice(bool isCompleted) //isCompleted true ise çıkışı tamamlanmış hareketlerin ortalamasını
                                                        //false ise çıkmaya hazır transaction'ların ortalamasını getirir MC
        {
            BigCurrency totalPrice = 0;
            BindingList<StockTransaction> stockTransactions = new BindingList<StockTransaction>();

            if (isCompleted)
            {
                if (_priceCalculated)
                    return;
                _priceCalculated = true;

                stockTransactions = StockTransaction.GetCompletedOUTStockTransactionsByStockActionDet(ObjectContext, ObjectID, string.Empty);

                if (stockTransactions.Count > 0)
                {
                    foreach (StockTransaction stockTransaction in stockTransactions)
                    {
                        if (stockTransaction.StockTransactionDefinition.TransactionType == TransactionTypeEnum.MergeStock && stockTransaction.MaintainLevelCode == MaintainLevelCodeEnum.DecreaseInheld)
                            continue;
                        if (stockTransaction.Price.HasValue && stockTransaction.UnitPrice.Value > 0 && stockTransaction.Amount.HasValue && stockTransaction.Amount.Value > 0)
                            totalPrice += stockTransaction.UnitPrice.Value * (BigCurrency)stockTransaction.Amount.Value;
                    }
                    if (Amount > 0)
                    {
                        _outUnitPrice = (double)totalPrice / (double)Amount;
                        _outPrice = (double)totalPrice;
                    }
                    else
                    {
                        _outPrice = 0;
                        _outUnitPrice = 0;
                    }
                }
            }
            else
            {
                if (Amount != null && Amount > 0)
                {
                    BindingList<Stock> stocks = Stock.GetStoreMaterial(ObjectContext, StockAction.Store.ObjectID, Material.ObjectID);
                    if (stocks.Count == 0)
                        throw new Exception(SystemMessage.GetMessage(1046));
                    if (stocks.Count == 0)
                        throw new Exception(SystemMessage.GetMessage(1047));

                    Stock stock = stocks[0];
                    stock.PrepareOutableStockTransactions(this);
                    List<Stock.OutableStockTransaction> outableTransactions = stock.OutableStockTransactions;
                    if (outableTransactions == null)
                        return;

                    List<Currency> amounts = new List<Currency>();
                    List<BigCurrency> prices = new List<BigCurrency>();
                    double neededAmount = (double)Amount;
                    foreach (Stock.OutableStockTransaction stockOutableTransaction in outableTransactions)
                    {
                        stockTransactions.Add(stockOutableTransaction.StockTransaction);
                        if (neededAmount - Convert.ToDouble(stockOutableTransaction.Amount) <= 0)
                        {
                            amounts.Add(neededAmount);
                            prices.Add((double)stockOutableTransaction.StockTransaction.UnitPrice);
                            break;
                        }
                        else
                        {
                            neededAmount -= Convert.ToDouble(stockOutableTransaction.Amount);
                            amounts.Add((double)stockOutableTransaction.Amount);
                            prices.Add((double)stockOutableTransaction.StockTransaction.UnitPrice);
                        }
                    }

                    if (amounts.Count != prices.Count)
                        throw new TTCallAdminException();

                    for (int i = 0; i < amounts.Count; i++)
                    {
                        totalPrice += (BigCurrency)amounts[i] * prices[i];
                    }
                    if (Amount > 0 && totalPrice > 0)
                        _outUnitPrice = (double)totalPrice / (double)Amount;
                    _outPrice = (double)totalPrice;
                }
                else
                {
                    _outPrice = 0;
                    _outUnitPrice = 0;
                }
            }
        }

        public void ResetPrice()
        {
            _priceCalculated = false;
        }

        public bool AddInvoiceDetails()
        {
            bool add = false;
            foreach (StockTransaction trx in StockTransactions)
            {
                StockTransaction firstTRX = trx.GetFirstInTransaction();
                if (firstTRX.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
                {
                    InvoiceDetail invoiceDetail = InvoiceDetails.AddNew();
                    invoiceDetail.InvoicePicture = firstTRX.StockActionDetail.StockAction.InvoicePicture;
                    invoiceDetail.InvoiceDate = ((IChattelDocumentWithPurchase)firstTRX.StockActionDetail.StockAction).GetBaseDateTime();
                    invoiceDetail.AuctionDate = ((IChattelDocumentWithPurchase)firstTRX.StockActionDetail.StockAction).GetAuctionDate();
                    invoiceDetail.RegistrationAuctionNo = ((IChattelDocumentWithPurchase)firstTRX.StockActionDetail.StockAction).GetRegistrationAuctionNo();
                    add = true;
                }

                if (firstTRX.StockActionDetail.InvoiceDetails.Count == 1)
                {
                    InvoiceDetail invoiceDetail = InvoiceDetails.AddNew();
                    invoiceDetail.InvoicePicture = firstTRX.StockActionDetail.InvoiceDetails[0].InvoicePicture;
                    invoiceDetail.InvoiceDate = firstTRX.StockActionDetail.InvoiceDetails[0].InvoiceDate;
                    invoiceDetail.AuctionDate = firstTRX.StockActionDetail.InvoiceDetails[0].AuctionDate;
                    invoiceDetail.RegistrationAuctionNo = firstTRX.StockActionDetail.InvoiceDetails[0].RegistrationAuctionNo;
                    add = true;
                }
            }
            return add;
        }



        private void CheckStockLevel(Material material, StockLevelType stockLevelType)
        {
            //Parametrede verilen malzeme ve seviyeye göre çeşitli kontroller burada yapılır
            if (stockLevelType.ObjectID.Equals(StockLevelType.NewStockLevel.ObjectID) == false)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(StockLevelTypeEnum).Name];
                if (material.StockCard.ProductionCheckbox.HasValue && material.StockCard.ProductionCheckbox.Value == true)
                    throw new Exception(SystemMessage.GetMessageV3(1048, new string[] { dataType.EnumValueDefs[(int)stockLevelType.StockLevelTypeStatus].DisplayText.ToString() }));
            }
        }


        //protected override bool IsReadOnly()
        //{
        //    if (base.IsReadOnly())
        //        return true;

        //    if (this.Status == StockActionDetailStatusEnum.New)
        //        return false;
        //    else
        //        return true;
        //}

        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
                Status = StockActionDetailStatusEnum.New;
        }

        #region IStockActionDetail Members
        public StockActionDetailStatusEnum? GetStatus()
        {
            return Status;
        }

        public void SetStatus(StockActionDetailStatusEnum? value)
        {
            Status = value;
        }

        public Material GetMaterial()
        {
            return Material;
        }

        public StockAction GetStockAction()
        {
            return StockAction;
        }

        public StockLevelType GetStockLevelType()
        {
            return StockLevelType;
        }

        public Currency? GetAmount()
        {
            return Amount;
        }

        public void SetAmount(Currency? value)
        {
            Amount = value;
        }
        #endregion
        #endregion Methods

    }
}