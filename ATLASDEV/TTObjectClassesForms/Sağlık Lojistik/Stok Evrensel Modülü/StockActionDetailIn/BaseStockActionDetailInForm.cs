
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
    public partial class BaseStockActionDetailInForm : BaseStockActionDetailForm
    {
        override protected void BindControlEvents()
        {
            UpdateButton.Click += new TTControlEventDelegate(UpdateButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            UpdateButton.Click -= new TTControlEventDelegate(UpdateButton_Click);
            base.UnBindControlEvents();
        }

        private void UpdateButton_Click()
        {
#region BaseStockActionDetailInForm_UpdateButton_Click
   if (FixedAssetDetails.Rows.Count > 0)
            {
                foreach (ITTGridRow row in FixedAssetDetails.Rows)
                {
                    row.Cells["GuarantyStartDate"].Value = GuarantyStartDateTemp.NullableValue;
                    row.Cells["GuarantyEndDate"].Value = GuarantyEndDateTemp.NullableValue;
                    row.Cells["Mark"].Value = MarkTemp.Text;
                    row.Cells["Model"].Value = ModelTemp.Text;
                    row.Cells["ProductionDate"].Value = ProductionDateTemp.NullableValue;
                    row.Cells["Power"].Value = PowerTemp.Text;
                    row.Cells["Voltage"].Value = VoltageTemp.Text;
                    row.Cells["Frequency"].Value = FrequencyTemp.Text;
                }
            }
#endregion BaseStockActionDetailInForm_UpdateButton_Click
        }

        protected override void PreScript()
        {
#region BaseStockActionDetailInForm_PreScript
    base.PreScript();

            TTObjectStateDef objectStateDef = _StockActionDetailIn.StockAction.CurrentStateDef;
            while (true)
            {
                if (objectStateDef.BaseStateDef == null)
                    break;
                objectStateDef = objectStateDef.BaseStateDef;
                if (objectStateDef.ObjectDef.CodeName.Equals(typeof(StockAction).Name))
                    break;
            }

            switch (this._StockActionDetail.Material.StockCard.StockMethod)
            {
                case StockMethodEnum.QRCodeUsed:
                    tttabcontrol1.HideTabPage(FixedAssetTabPage);
                    if (objectStateDef != null && objectStateDef.StateDefID == StockAction.States.New && this._StockActionDetailIn.QRCodeInDetails.Count == 0)
                    {
                        if (this._StockActionDetailIn.Material == null || this._StockActionDetailIn.Amount == 0)
                            throw new TTException("Karekod detayları girmeden önce Miktar girmeniz Malzeme seçmeniz gerekmektedir.\r\nMiktar : " + this._StockActionDetailIn.Amount);

                        double QRCodeAmount = 0;
                        if (_StockActionDetailIn.Material.PackageAmount == null || _StockActionDetailIn.Material.PackageAmount == 0)
                            QRCodeAmount = 1;
                        else
                            QRCodeAmount = Math.Floor(((double)_StockActionDetailIn.Amount) / ((double)_StockActionDetailIn.Material.PackageAmount));

                        this.QRCodeCountLabel.Text = QRCodeAmount.ToString();
                    }
                    break;
                case StockMethodEnum.SerialNumbered:
                    tttabcontrol1.HideTabPage(QRCodeTabPage);
                    if (this._StockActionDetailIn.Material is FixedAssetDefinition)
                    {
                        if (objectStateDef != null && objectStateDef.StateDefID == StockAction.States.New && this._StockActionDetailIn.FixedAssetInDetails.Count == 0)
                        {
                            if (this._StockActionDetailIn.Material == null || this._StockActionDetailIn.Amount == 0)
                                throw new TTException("Detayları girmeden önce Miktar girmeniz Malzeme seçmeniz gerekmektedir.\r\nMiktar : " + this._StockActionDetailIn.Amount);

                            for (int i = 0; i < this._StockActionDetailIn.Amount; i++)
                            {
                                FixedAssetInDetail fixedAssetInDetail = new FixedAssetInDetail(this._StockActionDetailIn.ObjectContext);
                                fixedAssetInDetail.StockActionDetail = this._StockActionDetailIn;
                                fixedAssetInDetail.SetNewFixedAssetSerialNumber();
                                fixedAssetInDetail.FixedAssetMaterialDefDetail = new FixedAssetMaterialDefinitionDetail(this._StockActionDetailIn.ObjectContext);
                            }
                        }
                    }
                    break;
                case StockMethodEnum.ExpirationDated:
                case StockMethodEnum.LotUsed:
                case StockMethodEnum.StockNumbered:
                    tttabcontrol1.TabPages["FixedAssetTabPage"].ReadOnly = true;
                    tttabcontrol1.TabPages["QRCodeTabPage"].ReadOnly = true;
                    break;
                default:
                    throw new TTException("Tanımsız Stok Methodu");
                    //break;
            }
#endregion BaseStockActionDetailInForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseStockActionDetailInForm_PostScript
    base.PostScript(transDef);
#endregion BaseStockActionDetailInForm_PostScript

            }
            
#region BaseStockActionDetailInForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            if (_StockActionDetailIn.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
            {
                bool addableBarcode = false;
                bool addableLotNo = false;
                bool addableExpDate = false;
                bool addableOrderNo = true;

                Code2D qrCode = new Code2D(value);
                if (_StockActionDetailIn.Material.Barcode.Equals(qrCode.Barcode.ToString()))
                    addableBarcode = true;
                else
                {
                    InfoBox.Show("Okuttuğunuz karekod ile seçmiş olduğunuz malzeme aynı değil.", MessageIconEnum.ErrorMessage);
                    return;
                }

                if (_StockActionDetailIn.LotNo == null)
                {
                    _StockActionDetailIn.LotNo = qrCode.BatchNo;
                    addableLotNo = true;
                }
                else
                {
                    if (_StockActionDetailIn.LotNo.Equals(qrCode.BatchNo))
                        addableLotNo = true;
                    else
                    {
                        InfoBox.Show("Okuttuğunuz karekod ile seçmiş olduğunuz malzemenin lotu aynı değil.", MessageIconEnum.ErrorMessage);
                        return;
                    }
                }

                if (_StockActionDetailIn.ExpirationDate == null)
                {
                    _StockActionDetailIn.ExpirationDate = qrCode.ExpirationDate;
                    addableExpDate = true;
                }
                else
                {
                    if (_StockActionDetailIn.ExpirationDate.Equals(qrCode.ExpirationDate))
                        addableExpDate = true;
                    else
                    {
                        InfoBox.Show("Okuttuğunuz karekod ile seçmiş olduğunuz malzemenin son kullanma tarihi aynı değil.", MessageIconEnum.ErrorMessage);
                        return;
                    }
                }

                foreach (QRCodeInDetail inDetail in _StockActionDetailIn.QRCodeInDetails)
                {
                    if (inDetail.OrderNo.Equals(qrCode.PackageCode))
                    {
                        addableOrderNo = false;
                        InfoBox.Show("Okutmuş olduğunuz karekodu daha öncede okutmuştunuz.",MessageIconEnum.ErrorMessage);
                        return;
                    }
                }

                if (addableBarcode && addableLotNo && addableExpDate && addableOrderNo)
                {
                    QRCodeInDetail qRCodeInDetail = _StockActionDetailIn.QRCodeInDetails.AddNew();
                    qRCodeInDetail.Barcode = qrCode.Barcode.ToString();
                    qRCodeInDetail.LotNo = qrCode.BatchNo;
                    qRCodeInDetail.ExpireDate = qrCode.ExpirationDate;
                    qRCodeInDetail.OrderNo = qrCode.PackageCode;
                }
            }
        }

        /*
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            if (_StockActionDetailIn.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
            {
                Code2D qrCode = new Code2D(value);
                
                IBindingList stock = Stock.GetStoreMaterial(_StockActionDetailIn.ObjectContext,_StockActionDetailIn.StockAction.Store.ObjectID,_StockActionDetailIn.Material.ObjectID);
                if (stock.Count == 1)
                {
                    IList qrCodes = QRCodeTransaction.GetQRCodeTransactionByQRCode(_StockActionDetailIn.ObjectContext, ((Stock)stock[0]).ObjectID, qrCode.Barcode.ToString(), qrCode.BatchNo, qrCode.PackageCode);
                    if (qrCodes.Count == 1)
                    {
                      InfoBox.Show("Okuttuğunuz karekod daha önce girilmiştir.",MessageIconEnum.WarningMessage);
                    }
                    else if (qrCodes.Count == 0)
                    {
                        QRCodeInDetail qRCodeInDetail = _StockActionDetailIn.QRCodeInDetails.AddNew();
                        qRCodeInDetail.Barcode = qrCode.Barcode.ToString();
                        qRCodeInDetail.LotNo = qrCode.BatchNo;
                        qRCodeInDetail.ExpireDate = qrCode.ExpirationDate;
                        qRCodeInDetail.OrderNo = qrCode.PackageCode;
                    }
                    else
                        InfoBox.Show("Okuttuğunuz karekodun birden fazla girişi bulunmuştur.",MessageIconEnum.WarningMessage);
                }
            }
        }
         */
        
#endregion BaseStockActionDetailInForm_ClientSideMethods
    }
}