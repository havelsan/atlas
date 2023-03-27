
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
    /// Stok Kartı Masa Değiştirme
    /// </summary>
    public partial class ChangeStockCardDrawerForm : TTForm
    {
        override protected void BindControlEvents()
        {
            StockCard.SelectedObjectChanged += new TTControlEventDelegate(StockCard_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockCard.SelectedObjectChanged -= new TTControlEventDelegate(StockCard_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void StockCard_SelectedObjectChanged()
        {
#region ChangeStockCardDrawerForm_StockCard_SelectedObjectChanged
   if (this._ChangeStockCardDrawer.StockCard != null)
            {
                AccountancyStockCard accountancyStockCard = this._ChangeStockCardDrawer.StockCard.GetAccountancyStockCard(this._ChangeStockCardDrawer.AccountingTerm.Accountancy);
                if (accountancyStockCard != null)
                {
                    this._ChangeStockCardDrawer.OldResCardDrawer = accountancyStockCard.CardDrawer;
                }
                if (this._ChangeStockCardDrawer.OldResCardDrawer != null)
                {
                    IList resCardDrawers = this._ChangeStockCardDrawer.ObjectContext.QueryObjects("RESCARDDRAWER", "STORE = " + ConnectionManager.GuidToString(this._ChangeStockCardDrawer.AccountingTerm.Accountancy.MainStores[0].ObjectID));
                    string cardDrawerObjectIDs = string.Empty;
                    foreach (Resource resource in resCardDrawers)
                    {
                        if (resource.ObjectID.Equals(this._ChangeStockCardDrawer.OldResCardDrawer.ObjectID) == false )
                            cardDrawerObjectIDs += ConnectionManager.GuidToString(resource.ObjectID) + ",";
                    }
                    if (cardDrawerObjectIDs != string.Empty)
                    {
                        string filter = cardDrawerObjectIDs.Substring(0, cardDrawerObjectIDs.Length - 1);
                        this.NewResCardDrawer.ListFilterExpression = "OBJECTID IN ( " + filter + ")";
                    }
                }
                else
                {
                    ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                    string cardDrawerObjectIDs = string.Empty;
                    foreach (Resource resource in resUser.SecMasterUserResources)
                    {
                        if (resource is ResCardDrawer && resource.Store.ObjectID == this._ChangeStockCardDrawer.AccountingTerm.Accountancy.MainStores[0].ObjectID )
                            cardDrawerObjectIDs += ConnectionManager.GuidToString(resource.ObjectID) + ",";
                    }
                    if (cardDrawerObjectIDs != string.Empty)
                    {
                        string filter = cardDrawerObjectIDs.Substring(0, cardDrawerObjectIDs.Length - 1);
                        this.NewResCardDrawer.ListFilterExpression = "OBJECTID IN ( " + filter + ")";
                    }
                }
                
                
                
            }
#endregion ChangeStockCardDrawerForm_StockCard_SelectedObjectChanged
        }

        protected override void ClientSidePreScript()
        {
#region ChangeStockCardDrawerForm_ClientSidePreScript
    base.ClientSidePreScript();
                MainStoreDefinition mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);
            if (mainStore == null)
                throw new Exception(SystemMessage.GetMessage(713));
            _ChangeStockCardDrawer.AccountingTerm = mainStore.Accountancy.GetOpenAccountingTerm();
#endregion ChangeStockCardDrawerForm_ClientSidePreScript

        }
    }
}