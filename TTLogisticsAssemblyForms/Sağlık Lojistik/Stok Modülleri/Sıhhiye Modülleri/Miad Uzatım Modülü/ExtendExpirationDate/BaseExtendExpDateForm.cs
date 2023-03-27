
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
    public partial class BaseExtendExpDateForm : BaseChattelDocumentForm
    {
        override protected void BindControlEvents()
        {
            ExtendExpirationDateDetails.CellValueChanged += new TTGridCellEventDelegate(ExtendExpirationDateDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ExtendExpirationDateDetails.CellValueChanged -= new TTGridCellEventDelegate(ExtendExpirationDateDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        protected override void ClientSidePreScript()
        {
            #region BaseExtendExpDateForm_ClientSidePreScript
            base.ClientSidePreScript();

            //if (ExtendExpirationDateDetails.Rows.Count > 0)
            //{
            //    foreach (ITTGridRow row in ExtendExpirationDateDetails.Rows)
            //    {
            //        if (((StockActionDetailOut)row.TTObject).OuttableLots.Count > 0)
            //        {
            //            row.Cells["CurrentExpirationDate"].Value = (DateTime)((StockActionDetailOut)row.TTObject).OuttableLots[0].ExpirationDate.Value;

            //            row.Cells["RestAmount"].Value = ((StockActionDetailOut)row.TTObject).OuttableLots[0].RestAmount.Value.ToString();
            //        }
            //    }

            //}

            this._ExtendExpirationDate.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
            this._ExtendExpirationDate.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.MiadUzatimi;
            this._ExtendExpirationDate.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckMiadUzatimiCikis;
            


            #endregion BaseExtendExpDateForm_ClientSidePreScript

        }




        private void ExtendExpirationDateDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseExtendExpDateForm_ExtendExpirationDateDetails_CellValueChanged

            if (columnIndex == 0)
            {
                ExtendExpirationDateDetail extendExpirationDateDetail = (ExtendExpirationDateDetail)ExtendExpirationDateDetails.CurrentCell.OwningRow.TTObject;

                Stock stock = extendExpirationDateDetail.StockAction.Store.GetStock(extendExpirationDateDetail.Material);

                BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);

                MultiSelectForm multiSelectForm = new MultiSelectForm();

                foreach (StockTransaction.LOTOutableStockTransactions_Class outableStockTransaction in outableStockTransactions)
                {
                    OuttableLot outtableLot = new OuttableLot(_ExtendExpirationDate.ObjectContext);
                    outtableLot.LotNo = outableStockTransaction.LotNo;
                    if (outableStockTransaction.ExpirationDate == null)
                        outtableLot.ExpirationDate = DateTime.MinValue;
                    else
                        outtableLot.ExpirationDate = outableStockTransaction.ExpirationDate;
                    outtableLot.RestAmount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                    outtableLot.Amount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                    outtableLot.isUse = false;

                    outtableLot.StockActionDetailOut = extendExpirationDateDetail;

                    multiSelectForm.AddMSItem("MIAD : " + outtableLot.ExpirationDate.Value.ToString("M/yyyy") + " || " + "Miktar : "
                        + outtableLot.RestAmount.ToString(), outtableLot.ObjectID.ToString(), outtableLot);
                }


                string mlotKey = multiSelectForm.GetMSItem(null, "Son Kullanma Tarihi / Mevcut Miktar", true);


                if (multiSelectForm.MSSelectedItemObject != null)
                {
                    OuttableLot lotSelected = multiSelectForm.MSSelectedItemObject as OuttableLot;

                    ExtendExpirationDateDetails.CurrentCell.OwningRow.Cells["CurrentExpirationDate"].Value = (DateTime)lotSelected.ExpirationDate.Value;

                    ExtendExpirationDateDetails.CurrentCell.OwningRow.Cells["RestAmount"].Value = lotSelected.RestAmount.Value.ToString();

                    ExtendExpirationDateDetails.CurrentCell.OwningRow.Cells["Amount"].Value = lotSelected.RestAmount.Value.ToString();

                    lotSelected.isUse = true;
                }

                if (ExtendExpirationDateDetails.CurrentCell.OwningColumn.Name != "MaterialExtendExpirationDateDetail")
                    return;
                Guid guid = new Guid("6a7ca758-6899-45bd-a4a2-ad4cf23bf301");
                StockLevelType level = (StockLevelType)_ExtendExpirationDate.ObjectContext.GetObject(guid, typeof(StockLevelType).Name);
                ((StockActionDetail)ExtendExpirationDateDetails.CurrentCell.OwningRow.TTObject).StockLevelType = level;

            }

            #endregion BaseExtendExpDateForm_ExtendExpirationDateDetails_CellValueChanged
        }

    }
}