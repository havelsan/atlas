
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
    public partial class ChangeStockLevelTypeForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            MaterialDetails.CellValueChanged += new TTGridCellEventDelegate(MaterialDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MaterialDetails.CellValueChanged -= new TTGridCellEventDelegate(MaterialDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void MaterialDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ChangeStockLevelTypeForm_MaterialDetails_CellValueChanged
            if (columnIndex == 0)
            {
                //ChangeStockLevelTypeDetail changeStockLevelTypeDetail = (ChangeStockLevelTypeDetail)MaterialDetails.CurrentCell.OwningRow.TTObject;
                //Stock stock = changeStockLevelTypeDetail.StockAction.Store.GetStock(changeStockLevelTypeDetail.Material);
                //BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);

                //MultiSelectForm multiSelectForm = new MultiSelectForm();
                //foreach (StockTransaction.LOTOutableStockTransactions_Class outableStockTransaction in outableStockTransactions)
                //{
                //    OuttableLot outtableLot = new OuttableLot(_ChangeStockLevelType.ObjectContext);
                //    outtableLot.LotNo = outableStockTransaction.LotNo;
                //    if (outableStockTransaction.ExpirationDate == null)
                //        outtableLot.ExpirationDate = DateTime.MinValue;
                //    else
                //        outtableLot.ExpirationDate = outableStockTransaction.ExpirationDate;
                //    outtableLot.RestAmount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                //    outtableLot.Amount = CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                //    outtableLot.isUse = false;

                //    outtableLot.StockActionDetailOut = changeStockLevelTypeDetail;

                //    multiSelectForm.AddMSItem("Lot No : " + outtableLot.LotNo + "MIAD : " + outtableLot.ExpirationDate.Value.ToString("M/yyyy") + " || " + "Miktar : "
                //        + outtableLot.RestAmount.ToString(), outtableLot.ObjectID.ToString(), outtableLot);
                //}


                //string mlotKey = multiSelectForm.GetMSItem(null, " Lot No /  Son Kullanma Tarihi / Mevcut Miktar", true);


                //if (multiSelectForm.MSSelectedItemObject != null)
                //{
                //    OuttableLot lotSelected = multiSelectForm.MSSelectedItemObject as OuttableLot;
                //    MaterialDetails.CurrentCell.OwningRow.Cells["StoreStock"].Value = lotSelected.RestAmount.Value.ToString();

                //    MaterialDetails.CurrentCell.OwningRow.Cells["AmountStockActionDetailIn"].Value = lotSelected.RestAmount.Value.ToString();

                //    lotSelected.isUse = true;
                //}

                if (MaterialDetails.CurrentCell.OwningColumn.Name != "MaterialStockActionDetail")
                    return;
                Guid guid = new Guid("6a7ca758-6899-45bd-a4a2-ad4cf23bf301");
                StockLevelType level = (StockLevelType)_ChangeStockLevelType.ObjectContext.GetObject(guid, typeof(StockLevelType).Name);
                ((StockActionDetail)MaterialDetails.CurrentCell.OwningRow.TTObject).StockLevelType = level;

            }

            #endregion ChangeStockLevelTypeForm_MaterialDetails_CellValueChanged
        }
        

        protected override void PreScript()
        {
            #region ChangeStockLevelTypeForm_PreScript
            base.PreScript();
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);

            ((ITTListBoxColumn)((ITTGridColumn)this.MaterialDetails.Columns["MaterialStockActionDetail"])).ListFilterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(_ChangeStockLevelType.Store.ObjectID) + " AND STOCKS.INHELD > 0 ";

            this._ChangeStockLevelType.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.ihtiyacFazlasi;
            this._ChangeStockLevelType.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckIhtiyacFazlasi;
            this._ChangeStockLevelType.MKYS_EButceTur = ((MainStoreDefinition)(this._ChangeStockLevelType.Store)).MKYS_ButceTuru;




            #endregion ChangeStockLevelTypeForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ChangeStockLevelTypeForm_PostScript
            base.PostScript(transDef);

            //            string errors = string.Empty;
            //            
            //            foreach(ChangeStockLevelTypeDetail detail in _ChangeStockLevelType.ChangeStockLevelTypeDetails)
            //            {
            //                if(detail.StockLevelType.ObjectID.ToString() != "6a7ca758-6899-45bd-a4a2-ad4cf23bf301")
            //                    errors += "\r\n" + detail.Material.Name;
            //            }
            //            
            //            if(errors != null)
            //                throw new TTUtils.TTException("Bu işlem sadece yeni durumundaki malzemeleri kullanılmışa çekmek için kullanılır." + errors);
            #endregion ChangeStockLevelTypeForm_PostScript

        }


        #region ChangeStockLevelTypeForm_MKYSMethods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef.ToStateDefID == ChangeStockLevelType.States.Completed)
            {
             
                _ChangeStockLevelType.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
            }
        }

        #endregion ChangeStockLevelTypeForm_MKYSMethods





    }
}