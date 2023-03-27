
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Malzeme Detayları
    /// </summary>
    public partial class BaseStockActionDetailOutForm : BaseStockActionDetailForm
    {
        override protected void BindControlEvents()
        {
            cmdGetStockLocations.Click += new TTControlEventDelegate(cmdGetStockLocations_Click);
            cmdGetInTransaction.Click += new TTControlEventDelegate(cmdGetInTransaction_Click);
            FixedAssetDetails.CellValueChanged += new TTGridCellEventDelegate(FixedAssetDetails_CellValueChanged);
            OuttableLots.CellValueChanged += new TTGridCellEventDelegate(OuttableLots_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetStockLocations.Click -= new TTControlEventDelegate(cmdGetStockLocations_Click);
            cmdGetInTransaction.Click -= new TTControlEventDelegate(cmdGetInTransaction_Click);
            FixedAssetDetails.CellValueChanged -= new TTGridCellEventDelegate(FixedAssetDetails_CellValueChanged);
            OuttableLots.CellValueChanged -= new TTGridCellEventDelegate(OuttableLots_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void cmdGetStockLocations_Click()
        {
#region BaseStockActionDetailOutForm_cmdGetStockLocations_Click
   Stock stock = _StockActionDetailOut.StockAction.Store.GetStock(_StockActionDetailOut.Material);
            foreach (StoreLocation location in stock.StoreLocations)
            {
                ITTGridRow addedRow = this.StockStoreLocations.Rows.Add();
                addedRow.Cells["StockLocationStoreLocation"].Value = location.StockLocation.ObjectID;
            }
#endregion BaseStockActionDetailOutForm_cmdGetStockLocations_Click
        }

        private void cmdGetInTransaction_Click()
        {
#region BaseStockActionDetailOutForm_cmdGetInTransaction_Click
   Stock stock = _StockActionDetailOut.StockAction.Store.GetStock(_StockActionDetailOut.Material);
            if (_StockActionDetail.StockAction.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                _StockActionDetailOut.OuttableLots.DeleteChildren();

                if (_StockActionDetailOut.IsZeroUnitPrice.HasValue && (bool)_StockActionDetailOut.IsZeroUnitPrice)
                {
                    BindingList<StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class> outableZeroUnitPriceStockTransactions = StockTransaction.LOTOutableStockTransactionsWithZeroPrice(stock.ObjectID);
                    foreach (StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class outableStockTransaction in outableZeroUnitPriceStockTransactions)
                    {
                        OuttableLot outtableLot = new OuttableLot(_StockActionDetail.ObjectContext);
                        outtableLot.LotNo = outableStockTransaction.LotNo;
                        if (outableStockTransaction.ExpirationDate == null)
                            outtableLot.ExpirationDate = DateTime.MinValue;
                        else
                            outtableLot.ExpirationDate = outableStockTransaction.ExpirationDate;
                        outtableLot.RestAmount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                        outtableLot.Amount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                        outtableLot.isUse = false;
                        outtableLot.StockActionDetailOut = _StockActionDetailOut;
                    }
                }
                else
                {
                    BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                    foreach (StockTransaction.LOTOutableStockTransactions_Class outableStockTransaction in outableStockTransactions)
                    {
                        OuttableLot outtableLot = new OuttableLot(_StockActionDetail.ObjectContext);
                        outtableLot.LotNo = outableStockTransaction.LotNo;
                        if (outableStockTransaction.ExpirationDate == null)
                            outtableLot.ExpirationDate = DateTime.MinValue;
                        else
                            outtableLot.ExpirationDate = outableStockTransaction.ExpirationDate;
                        outtableLot.RestAmount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                        outtableLot.Amount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                        outtableLot.isUse = false;
                        outtableLot.StockActionDetailOut = _StockActionDetailOut;
                    }
                }
                if (_StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated || _StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.LotUsed)
                {
                    foreach (ITTGridRow row in this.OuttableLots.Rows)
                    {
                        row.Cells["RequestAmount"].ReadOnly = false;
                        row.Cells["RequestAmount"].Required = true;
                    }
                }
                else
                {
                    foreach (ITTGridRow row in this.OuttableLots.Rows)
                        row.Cells["RequestAmount"].ReadOnly = true;
                }
            }



            //if (stock.OutableStockTransactions != null)
            //    stock.OutableStockTransactions.Clear();

            //stock.PrepareOutableStockTransactions(_StockActionDetailOut);

            //if (_StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.LotUsed || _StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
            //{
            //    Dictionary<string, Currency> stockTransactionLot = new Dictionary<string, Currency>();
            //    string lot = string.Empty;
            //    foreach (Stock.OutableStockTransaction outableStockTransaction in stock.OutableStockTransactions)
            //    {
            //        if (string.IsNullOrEmpty(outableStockTransaction.StockTransaction.LotNo))
            //            lot = string.Empty;
            //        else
            //            lot = outableStockTransaction.StockTransaction.LotNo;

            //        if (stockTransactionLot.ContainsKey(lot) == false)
            //            stockTransactionLot.Add(lot, (Currency)outableStockTransaction.RestAmount);
            //        else
            //            stockTransactionLot[lot] = stockTransactionLot[lot] + (Currency)outableStockTransaction.RestAmount;
            //    }

            //    if(stockTransactionLot.Count>0)
            //    {
            //        foreach (KeyValuePair<string, Currency> groupLot in stockTransactionLot)
            //        {
            //            OuttableLot outtableLot = new OuttableLot(_StockActionDetail.ObjectContext);
            //            outtableLot.LotNo = groupLot.Key;
            //            outtableLot.RestAmount = groupLot.Value;
            //            outtableLot.isUse = false;
            //            outtableLot.StockActionDetailOut = _StockActionDetailOut;
            //        }
            //    }
            //}
            //else if (_StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated)
            //{
            //    Dictionary<DateTime, Currency> stockTransactionExpiration = new Dictionary<DateTime, Currency>();
            //    foreach (Stock.OutableStockTransaction outableStockTransaction in stock.OutableStockTransactions)
            //    {
            //        DateTime expirationDate;
            //        if (outableStockTransaction.StockTransaction.ExpirationDate != null)
            //            expirationDate = ((DateTime)outableStockTransaction.StockTransaction.ExpirationDate);
            //        else
            //            expirationDate = DateTime.MinValue;

            //        if (stockTransactionExpiration.ContainsKey(expirationDate) == false)
            //            stockTransactionExpiration.Add(expirationDate, (Currency)outableStockTransaction.RestAmount);
            //        else
            //            stockTransactionExpiration[expirationDate] = stockTransactionExpiration[expirationDate] + (Currency)outableStockTransaction.RestAmount;
            //    }
            //    if (stockTransactionExpiration.Count > 0)
            //    {
            //        foreach (KeyValuePair<DateTime, Currency> expiration in stockTransactionExpiration)
            //        {
            //            OuttableLot outtableLot = new OuttableLot(_StockActionDetail.ObjectContext);
            //            outtableLot.ExpirationDate = expiration.Key;
            //            outtableLot.RestAmount = expiration.Value;
            //            outtableLot.isUse = false;
            //            outtableLot.StockActionDetailOut = _StockActionDetailOut;
            //        }
            //    }
            //}
            //else
            //{
            //    Dictionary<StockTransaction, Currency> stockTransaction = new Dictionary<StockTransaction, Currency>();
            //    foreach (Stock.OutableStockTransaction outableStockTransaction in stock.OutableStockTransactions)
            //    {
            //        if (stockTransaction.ContainsKey(outableStockTransaction.StockTransaction) == false)
            //            stockTransaction.Add(outableStockTransaction.StockTransaction, (Currency)outableStockTransaction.RestAmount);
            //        else
            //            stockTransaction[outableStockTransaction.StockTransaction] = stockTransaction[outableStockTransaction.StockTransaction] + (Currency)outableStockTransaction.RestAmount;
            //    }
            //    if (stockTransaction.Count > 0)
            //    {
            //        foreach (KeyValuePair<StockTransaction, Currency> transaction in stockTransaction)
            //        {
            //            OuttableLot outtableLot = new OuttableLot(_StockActionDetail.ObjectContext);
            //            outtableLot.LotNo = transaction.Key.LotNo;
            //            outtableLot.ExpirationDate = transaction.Key.ExpirationDate;
            //            outtableLot.RestAmount = transaction.Value;
            //            outtableLot.isUse = false;
            //            outtableLot.StockActionDetailOut = _StockActionDetailOut;
            //        }
            //    }
            //}
#endregion BaseStockActionDetailOutForm_cmdGetInTransaction_Click
        }

        private void FixedAssetDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseStockActionDetailOutForm_FixedAssetDetails_CellValueChanged
   if (columnIndex >= 0)
            {
                if(this.FixedAssetDetails.Rows[rowIndex].Cells[0].OwningColumn.DataMember == "ACCOUNTANCY")
                {
                    this.FixedAssetDetails.Rows[rowIndex].Cells[0].Value = this._StockActionDetailOut.setaccountancy.ObjectID;
                }
            }
#endregion BaseStockActionDetailOutForm_FixedAssetDetails_CellValueChanged
        }

        private void OuttableLots_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseStockActionDetailOutForm_OuttableLots_CellValueChanged
   OuttableLot outtableLot = (OuttableLot)OuttableLots.CurrentCell.OwningRow.TTObject;
            if (OuttableLots.CurrentCell.OwningColumn.Name == "RequestAmount")
            {
                if (outtableLot.Amount > outtableLot.RestAmount)
                    throw new TTException("Kalan miktardan fazla kullanılacak miktar yazamazsınız");
            }
#endregion BaseStockActionDetailOutForm_OuttableLots_CellValueChanged
        }

        protected override void PreScript()
        {
#region BaseStockActionDetailOutForm_PreScript
    base.PreScript();

            double amount = 0;
            Material material = this._StockActionDetailOut.Material;
            if (this._StockActionDetailOut is ReturningDocumentMaterial)
            {
                ReturningDocumentMaterial returningDocumentMaterial = (ReturningDocumentMaterial)this._StockActionDetail;
                if (returningDocumentMaterial.RequireAmount.HasValue)
                    amount = returningDocumentMaterial.RequireAmount.Value;
            }
            else
            {
                amount = this._StockActionDetailOut.Amount.HasValue ? (double)this._StockActionDetailOut.Amount.Value : 0;
            }

            if (this._StockActionDetailOut is IVoucherDistributingDocumentMaterial)
            {
                IVoucherDistributingDocumentMaterial voucherDistributingDocumentMaterial = (IVoucherDistributingDocumentMaterial)this._StockActionDetailOut;
                if (voucherDistributingDocumentMaterial.GetRequireMaterial().HasValue)
                    amount = voucherDistributingDocumentMaterial.GetRequireMaterial().Value;
            }

            if (material == null || amount == 0)
                throw new TTException("Detayları girmeden önce Miktar girmeniz Malzeme seçmeniz gerekmektedir.\r\nMiktar : " + this._StockActionDetailOut.Amount);

            switch (this._StockActionDetail.Material.StockCard.StockMethod)
            {
                case StockMethodEnum.QRCodeUsed:
                    tttabcontrol1.HideTabPage(FixedAssetTabPage);
                    if (this._StockActionDetailOut.QRCodeOutDetails.Count == 0)
                    {
                        double packageAmount = 0;
                        if (_StockActionDetailOut.Material.PackageAmount == null || _StockActionDetailOut.Material.PackageAmount == 0)
                            packageAmount = 1;
                        else
                            packageAmount = (double)_StockActionDetail.Material.PackageAmount;

                        Currency availAmount = (Currency)_StockActionDetail.Amount % packageAmount;
                        double qrCodeCount = Math.Floor((double)_StockActionDetail.Amount / packageAmount);

                        if (availAmount > 0)
                        {
                            double stockInheld = _StockActionDetail.Material.StockInheld(_StockActionDetail.StockAction.Store, _StockActionDetail.StockLevelType);
                            if (stockInheld % packageAmount == 0)
                                qrCodeCount = qrCodeCount + 1;
                        }

                        labelQRCodeCount.Visible = true;
                        QRCodeCountLabel.Visible = true;
                        QRCodeCountLabel.Text = qrCodeCount.ToString();

                        //Detay yaratılmayacak karekod dan okununca girilecek. SS
                        //for (int i = 0; i < qrCodeCount; i++)
                        //{
                        //    QRCodeOutDetail qRCodeOutDetail = new QRCodeOutDetail(this._StockActionDetailOut.ObjectContext);
                        //    qRCodeOutDetail.QRCodeTransaction = null;
                        //    this._StockActionDetailOut.QRCodeOutDetails.Add(qRCodeOutDetail);
                        //}
                    }
                    break;
                case StockMethodEnum.SerialNumbered:
                    tttabcontrol1.HideTabPage(QRCodeTabPage);
                    if (this._StockActionDetailOut.FixedAssetOutDetails.Count == 0)
                    {
                        for (int i = 0; i < amount; i++)
                        {
                            FixedAssetOutDetail fixedAssetOutDetail = new FixedAssetOutDetail(this._StockActionDetailOut.ObjectContext);
                            fixedAssetOutDetail.FixedAssetMaterialDefinition = null;
                            fixedAssetOutDetail.Resource = null;
                            this._StockActionDetailOut.FixedAssetOutDetails.Add(fixedAssetOutDetail);
                        }
                        this.FixedAssetMaterialDefinition.ListFilterExpression = " STOCK.STORE = " + ConnectionManager.GuidToString(this._StockActionDetailOut.StockAction.Store.ObjectID);
                        this.FixedAssetMaterialDefinition.ListFilterExpression += " AND FIXEDASSETDEFINITION = " + ConnectionManager.GuidToString(material.ObjectID);
                        if (this._StockActionDetailOut.StockLevelType != null)
                            this.FixedAssetMaterialDefinition.ListFilterExpression += " AND STOCK.STOCKLEVELS.STOCKLEVELTYPE = " + ConnectionManager.GuidToString(this._StockActionDetailOut.StockLevelType.ObjectID);

                        if (TTObjectClasses.SystemParameter.GetParameterValue("FIXEDASSETMATERIALDEFINITIONDETAIL", "FALSE") == "TRUE")
                        {
                            if (this._StockActionDetailOut.StockAction is IChattelDocumentOutputWithAccountancy)
                            {
                                IChattelDocumentOutputWithAccountancy outDocument = this._StockActionDetailOut.StockAction as IChattelDocumentOutputWithAccountancy;
                                if (outDocument.GetAccountancy() != null)
                                {
                                   /* if (outDocument.Accountancy.AccountancyMilitaryUnit != null)
                                    {
                                        MilitaryUnit militaryUnit = (MilitaryUnit)this._StockActionDetailOut.ObjectContext.GetObject(outDocument.Accountancy.AccountancyMilitaryUnit.ObjectID, "MILITARYUNIT");
                                        if (militaryUnit.IsSupported.HasValue && militaryUnit.IsSupported.Value)
                                            this.FixedAssetMaterialDefinition.ListFilterExpression += " AND ISAPPROVALFIXEDASSET = 1";
                                    }*/
                                }
                            }
                            else
                                this.FixedAssetMaterialDefinition.ListFilterExpression += " AND ISAPPROVALFIXEDASSET = 1";
                        }
                    }
                    break;
                case StockMethodEnum.StockNumbered:
                    tttabcontrol1.TabPages["FixedAssetTabPage"].ReadOnly = true;
                    tttabcontrol1.TabPages["QRCodeTabPage"].ReadOnly = true;
                    //this.cmdGetInTransaction.Enabled = false;
                    break;
                case StockMethodEnum.ExpirationDated:
                case StockMethodEnum.LotUsed:
                    tttabcontrol1.TabPages["FixedAssetTabPage"].ReadOnly = true;
                    tttabcontrol1.TabPages["QRCodeTabPage"].ReadOnly = true;
                    break;
                default:
                    throw new TTException("Tanımsız Stok Methodu");
            }
#endregion BaseStockActionDetailOutForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseStockActionDetailOutForm_PostScript
    base.PostScript(transDef);

            switch ((StockMethodEnum)_StockActionDetailOut.Material.StockCard.StockMethod)
            {
                case StockMethodEnum.ExpirationDated:
                case StockMethodEnum.LotUsed:
                    Currency requestAmount = 0;
                    foreach (OuttableLot outtableLot in _StockActionDetailOut.OuttableLots)
                    {
                        if ((bool)outtableLot.isUse)
                            requestAmount = requestAmount + (Currency)outtableLot.Amount;
                    }
                    if (requestAmount < _StockActionDetailOut.Amount)
                        throw new TTException(_StockActionDetailOut.Material.Name + " isimli malzeme için yeterli kullanılacak miktar seçmediniz");
                    break;
                case StockMethodEnum.QRCodeUsed:
                    double packageAmount = (double)_StockActionDetailOut.Material.PackageAmount;
                    Currency availAmount = (Currency)_StockActionDetailOut.Amount % packageAmount;
                    double qrCodeCount = Math.Floor((double)_StockActionDetailOut.Amount / packageAmount);
                    if (availAmount > 0)
                    {
                        double stockInheld = _StockActionDetailOut.Material.StockInheld(_StockActionDetailOut.StockAction.Store, _StockActionDetailOut.StockLevelType);
                        if (stockInheld % packageAmount == 0)
                            qrCodeCount = qrCodeCount + 1;
                    }

                    if (qrCodeCount != _StockActionDetailOut.QRCodeOutDetails.Count || _StockActionDetailOut.QRCodeOutDetails.Count == 0)
                        throw new TTException(_StockActionDetailOut.Material.Name + " isimli malzemenin kare kod detayları eksik girilmiş veya girilmemiştir. Tekrar Seçiniz.");
                    _StockActionDetailOut.ReadQRCode = true;
                    break;
                case StockMethodEnum.SerialNumbered:
                    if (_StockActionDetailOut.Amount > _StockActionDetailOut.FixedAssetOutDetails.Count || _StockActionDetailOut.FixedAssetOutDetails.Count == 0)
                        throw new TTException(_StockActionDetailOut.Material.Name + " isimli malzemenin demirbaş detayları eksik girilmiş veya girilmemiştir. Tekrar Seçiniz.");
                    break;
                case StockMethodEnum.StockNumbered:
                default:
                    break;
            }
#endregion BaseStockActionDetailOutForm_PostScript

            }
            
#region BaseStockActionDetailOutForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            if (_StockActionDetailOut.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
            {
                bool addableBarcode = false;
                bool addableOrderNo = true;

                Code2D qrCode = new Code2D(value);
                Dictionary<string, DateTime> outtable = new Dictionary<string, DateTime>();
                foreach (OuttableLot lot in _StockActionDetailOut.OuttableLots)
                {
                    if ((bool)lot.isUse)
                        outtable.Add(lot.LotNo, (DateTime)lot.ExpirationDate);
                }

                if (_StockActionDetailOut.Material.Barcode.Equals(qrCode.Barcode.ToString()))
                    addableBarcode = true;
                else
                {
                    InfoBox.Show("Okuttuğunuz karekod ile seçmiş olduğunuz malzeme aynı değil.", MessageIconEnum.ErrorMessage);
                    return;
                }

                foreach (QRCodeOutDetail outDetail in _StockActionDetailOut.QRCodeOutDetails)
                {
                    if (outDetail.QRCodeTransaction != null)
                    {
                        if (outDetail.QRCodeTransaction.OrderNo.Equals(qrCode.PackageCode))
                        {
                            addableOrderNo = false;
                            InfoBox.Show("Okutmuş olduğunuz karekodu daha öncede okutmuştunuz.", MessageIconEnum.ErrorMessage);
                            return;
                        }
                    }
                }

                if (addableBarcode && addableOrderNo)
                {
                    IBindingList stock = Stock.GetStoreMaterial(_StockActionDetailOut.ObjectContext, _StockActionDetailOut.StockAction.Store.ObjectID, _StockActionDetailOut.Material.ObjectID);
                    if (stock.Count == 1)
                    {
                        IList qrCodes = QRCodeTransaction.GetQRCodeTransactionByQRCode(_StockActionDetailOut.ObjectContext, ((Stock)stock[0]).ObjectID, qrCode.Barcode.ToString(), qrCode.BatchNo, qrCode.PackageCode);
                        if (qrCodes.Count == 1)
                        {
                            QRCodeOutDetail qRCodeOutDetail = _StockActionDetailOut.QRCodeOutDetails.AddNew();
                            qRCodeOutDetail.QRCodeTransaction = (QRCodeTransaction)qrCodes[0];
                        }
                        else if (qrCodes.Count == 0)
                        {
                            InfoBox.Show("Okuttuğunuz karekod mevcudu bulunmamaktadır.", MessageIconEnum.WarningMessage);
                            return;
                        }
                        else
                        {
                            InfoBox.Show("Okuttuğunuz karekod dan birden fazla bulunmuştur.", MessageIconEnum.WarningMessage);
                            return;
                        }
                    }
                }
            }
        }
        
#endregion BaseStockActionDetailOutForm_ClientSideMethods
    }
}