
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
    /// Stok Kartı Arama Formu
    /// </summary>
    public partial class SearchStockCardForm : TTListForm
    {
        override protected void BindControlEvents()
        {
            cmdChangeStore.Click += new TTControlEventDelegate(cmdChangeStore_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdChangeStore.Click -= new TTControlEventDelegate(cmdChangeStore_Click);
            base.UnBindControlEvents();
        }

        private void cmdChangeStore_Click()
        {
#region SearchStockCardForm_cmdChangeStore_Click
   ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
            List<Store> selectableStores = new List<Store>();
            if (TTUser.CurrentUser.IsSuperUser)
            {
                TTObjectContext ctx = new TTObjectContext(true);
                IList stores = Store.GetAllStores(ctx);
                foreach (Store store in stores)
                    if (store.IsActive.HasValue && store.IsActive.Value)
                        selectableStores.Add(store);
            }
            else
            {
                if (resUser != null)
                {
                    if (resUser.SelectedStores.Count == 1)
                    {
                        this.SelectedStore.SelectedObject = (TTObject)resUser.SelectedStores[0];
                        //return;
                    }
                    else
                    {
                        foreach (Store store in resUser.SelectedStores)
                            selectableStores.Add(store);
                    }
                }

            }

            if (selectableStores.Count > 0)
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();

                foreach (Store store in selectableStores)
                    multiSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);
                multiSelectForm.GetMSItem(this, "Depo seçiniz.", false, true, false, false, true, true);
                this.SelectedStore.SelectedObject = (Store)multiSelectForm.MSSelectedItemObject;
                this._ttList.GetListExpression("STORE = '" + this.SelectedStore.SelectedObjectID + "'");
                dataGrid.DataSource = null;
            }
#endregion SearchStockCardForm_cmdChangeStore_Click
        }

        protected override void PreScript()
        {
#region SearchStockCardForm_PreScript
    base.PreScript();
#endregion SearchStockCardForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region SearchStockCardForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            this.IsIncludedDoubleZeroCard.Value = false;

            ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
            List<Store> selectableStores = new List<Store>();
            if (TTUser.CurrentUser.IsSuperUser)
            {
                TTObjectContext ctx = new TTObjectContext(true);
                IList stores = Store.GetAllStores(ctx);
                foreach (Store store in stores)
                    if (store.IsActive.HasValue && store.IsActive.Value)
                    selectableStores.Add(store);
            }
            else
            {
                if (resUser != null)
                {
                    if (resUser.SelectedStores.Count == 1)
                    {
                        this.SelectedStore.SelectedObject = (TTObject)resUser.SelectedStores[0];
                        this.cmdChangeStore.Enabled = false;
                        //return;
                    }
                    else
                    {
                        foreach (Store store in resUser.SelectedStores)
                            selectableStores.Add(store);
                    }
                }

            }

            if (selectableStores.Count > 0)
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();

                foreach (Store store in selectableStores)
                    multiSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);
                multiSelectForm.GetMSItem(this, "Depo seçiniz.", false, true, false, false, true, true);
                this.SelectedStore.SelectedObject = (Store)multiSelectForm.MSSelectedItemObject;
                this._ttList.GetListExpression("STORE = '" + this.SelectedStore.SelectedObjectID + "'");
            }

            if (resUser != null)
            {
                if (resUser.SelectedSecMasterResource != null && resUser.SelectedSecMasterResource is ResCardDrawer)
                    this.CardDrawer.SelectedObject = resUser.SelectedSecMasterResource;
                string cardDrawerObjectIDs = string.Empty;
                foreach (Resource resource in resUser.SecMasterUserResources)
                {
                    if (resource is ResCardDrawer)
                        if (this.SelectedStore.SelectedObject.ObjectID == resource.Store.ObjectID)
                        cardDrawerObjectIDs += ConnectionManager.GuidToString(resource.ObjectID) + ",";
                }
                if (cardDrawerObjectIDs != string.Empty)
                {
                    string filter = cardDrawerObjectIDs.Substring(0, cardDrawerObjectIDs.Length - 1);
                    this.CardDrawer.ListFilterExpression = "OBJECTID IN ( " + filter + ")";
                }
            }
#endregion SearchStockCardForm_ClientSidePreScript

        }

#region SearchStockCardForm_Methods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            string barcode = Common.PrepareBarcode(value);

            Material material = null;
            IBindingList materials = _ttList.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
            if (materials.Count == 0)
                InfoBox.Alert(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
                material = null;

            if (material == null)
            {
                this.OnClear();
                dataGrid.DataSource = null;
                return;
            }

            BarcodeMaterial.Text = material.Barcode;

            this.OnSearch();
        }

        public SearchStockCardForm()
            : this(TTList.NewList("StockSearchList", null))
        {
        }

        protected override void OnDrawForm()
        {
            base.OnDrawForm();

            this.cmdSearch.Text = "Ara";
            this.cmdOK.Text = "Seç";
            this.Refresh();
        }

        protected override void OnClear()
        {
            StockCardStatus.SelectedItem = null;
            SelectedStockCardClass.SelectedObject = null;
            CreationDate.NullableValue = null;
            NatoStockNo.Text = string.Empty;
            BarcodeMaterial.Text = string.Empty;
            Name.Text = string.Empty;
            CardDrawer.SelectedObject = null;
            StockLevel.SelectedItem = null;
            labelStockCardCount.Text = "0";
        }

        protected override void OnSearch()
        {
            //Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (Common.CurrentUser.IsSuperUser == false)
                    if (Common.CurrentUser.HasRole(Common.SearchStockCardRoleID) == false)
                        throw new Exception(SystemMessage.GetMessage(1247));
                IList list = _ttList.GetObjectListByExpression(GetFilterExpression());
                dataGrid.DataSource = list;
                if (list.Count > 0)
                    dataGrid.Focus();
                labelStockCardCount.Text = list.Count.ToString();
            }
            catch (Exception ex)
            {
                InfoBox.Alert(ex);
            }
            finally
            {
               // Cursor.Current = Cursors.Default;
            }
        }

        protected override string GetFilterExpression()
        {
            List<string> filters = new List<string>();

            Store selectedStore = SelectedStore.SelectedObject as Store;


            if (selectedStore != null)
                filters.Add("STORE = " + ConnectionManager.GuidToString(selectedStore.ObjectID));

            if (string.IsNullOrEmpty(NatoStockNo.Text) == false)
                filters.Add("MATERIAL.STOCKCARD.NATOSTOCKNO = '" + NatoStockNo.Text + "'");

            //ERDAL
            if (string.IsNullOrEmpty(BarcodeMaterial.Text) == false)
                filters.Add("MATERIAL.BARCODE = '" + BarcodeMaterial.Text + "'");

            if (string.IsNullOrEmpty(Name.Text) == false)
                filters.Add("MATERIAL.STOCKCARD.NAME_SHADOW LIKE '%" + TTUtils.Globals.CUCase(Name.Text, false, false) + "%'");

            StockCardClass selectedStockCardClass = SelectedStockCardClass.SelectedObject as StockCardClass;
            if (selectedStockCardClass != null)
            {
                List<string> stockCardClassObjectIDs = new List<string>();
                selectedStockCardClass.GetSubStockCardClassObjectIDs(ref stockCardClassObjectIDs);
                string filter = string.Empty;
                for (int i = 0; i < stockCardClassObjectIDs.Count; i++)
                {
                    filter += stockCardClassObjectIDs[i];
                    if (i != stockCardClassObjectIDs.Count - 1)
                        filter += ",";

                }
                filters.Add("MATERIAL.STOCKCARD.STOCKCARDCLASS.OBJECTID IN(" + filter + ")");
            }

            if (CreationDate.NullableValue != null)
            {
                DateTime creationDate = (DateTime)CreationDate.NullableValue;
                filters.Add("YEAR(MATERIAL.STOCKCARD.CREATIONDATE) = " + creationDate.Year);
                filters.Add("MONTH(MATERIAL.STOCKCARD.CREATIONDATE) = " + creationDate.Month);
                filters.Add("DAY(MATERIAL.STOCKCARD.CREATIONDATE) = " + creationDate.Day);
            }

            if (StockCardStatus.SelectedItem != null)
            {
                if (StockCardStatus.SelectedItem.Value != null)
                    filters.Add("MATERIAL.STOCKCARD.ACCOUNTANCYSTOCKCARDS.STATUS = " + StockCardStatus.SelectedItem.Value + "");
            }

            if (StockLevel.SelectedItem != null)
                filters.Add("STOCKLEVELS.STOCKLEVELTYPE.STOCKLEVELTYPESTATUS = " + StockLevel.SelectedItem.Value + "");

            ResCardDrawer selectedCardDrawer = CardDrawer.SelectedObject as ResCardDrawer;
            if (selectedCardDrawer != null)
                filters.Add("MATERIAL.STOCKCARD.ACCOUNTANCYSTOCKCARDS.CARDDRAWER = " + ConnectionManager.GuidToString(selectedCardDrawer.ObjectID));
            else
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                filters.Add(resUser.GetCardDrawerFilter("MATERIAL.STOCKCARD.ACCOUNTANCYSTOCKCARDS.CARDDRAWER IN"));
            }

            if (IsIncludedDoubleZeroCard.Value == false)
                filters.Add("MATERIAL.STOCKCARD.ACCOUNTANCYSTOCKCARDS.STATUS <> 3");


            if (GMDNCodeMaterial.SelectedValue != null)
                filters.Add("MATERIAL.GMDNCODE = '" + GMDNCodeMaterial.SelectedObjectID.ToString() + "'");

            if (PricingDetailDefinitionList.SelectedValue != null)
                filters.Add("MATERIAL.MATERIALPRICES(PRICINGDETAIL = " + ConnectionManager.GuidToString(PricingDetailDefinitionList.SelectedObject.ObjectID) + ").EXISTS");


            string filterExpression = null;
            if (filters.Count > 0)
            {
                int i = 0;
                foreach (string filter in filters)
                {
                    i++;
                    filterExpression += " " + filter;
                    if (filters.Count != i)
                        filterExpression += " AND ";
                }
            }

            return filterExpression;
        }
        
#endregion SearchStockCardForm_Methods
    }
}