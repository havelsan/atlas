
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
    /// Birim Fiyat Değiştirme
    /// </summary>
    public partial class StockTrxUpdateActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdUpdatePrice.Click += new TTControlEventDelegate(cmdUpdatePrice_Click);
            cmdGetInTrx.Click += new TTControlEventDelegate(cmdGetInTrx_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUpdatePrice.Click -= new TTControlEventDelegate(cmdUpdatePrice_Click);
            cmdGetInTrx.Click -= new TTControlEventDelegate(cmdGetInTrx_Click);
            base.UnBindControlEvents();
        }

        private void cmdUpdatePrice_Click()
        {
#region StockTrxUpdateActionForm_cmdUpdatePrice_Click
   if(this.NewUnitPrice.Text != "")
            {
                if(_StockTrxUpdateAction.StockTrxUpdateActionDetails.Count > 0)
                {
                    foreach(StockTrxUpdateActionDetail stockTrxUpdateActionDetail in _StockTrxUpdateAction.StockTrxUpdateActionDetails)
                    {
                        stockTrxUpdateActionDetail.NewUnitPrice = _StockTrxUpdateAction.NewUnitPrice ;
                    }
                    this.cmdUpdatePrice.Enabled = false;
                    this.NewUnitPrice.ReadOnly = true;
                    this.AddStateButton(StockTrxUpdateAction.States.Approval);
                }
            }
#endregion StockTrxUpdateActionForm_cmdUpdatePrice_Click
        }

        private void cmdGetInTrx_Click()
        {
#region StockTrxUpdateActionForm_cmdGetInTrx_Click
   foreach (Material material in _StockTrxUpdateAction.StockCard.Materials)
            {
                Stock mainStoreStock = _StockTrxUpdateAction.MainStoreDefinition.GetStock(material);
                Dictionary<Guid, StockTransaction> inTransactions = new Dictionary<Guid,StockTransaction>();
                foreach (StockTransaction trx in mainStoreStock.StockTransactions.Select(string.Empty))
                {
                    if (trx.StockTransactionDefinition.TransactionType == TransactionTypeEnum.In || trx.StockTransactionDefinition.TransactionType == TransactionTypeEnum.Production || trx.StockTransactionDefinition.TransactionType == TransactionTypeEnum.MergeStock)
                    {
                        if (trx.UnitPrice == 0 && trx.CurrentStateDefID != StockTransaction.States.Cancelled)
                        {
                            inTransactions = StockTrxUpdateAction.FindAllIntransaction(trx, inTransactions);
                        }
                    }
                }
                if(inTransactions.Count > 0 )
                {
                    foreach (KeyValuePair<Guid, StockTransaction> inTrx in inTransactions)
                    {
                        StockTrxUpdateActionDetail stockTrxUpdateActionDetail = new StockTrxUpdateActionDetail(_StockTrxUpdateAction.ObjectContext);
                        stockTrxUpdateActionDetail.StockActionName = inTrx.Value.StockActionDetail.StockAction.ObjectDef.DisplayText;
                        stockTrxUpdateActionDetail.StockTransaction = inTrx.Value ;
                        stockTrxUpdateActionDetail.OldUnitPrice = inTrx.Value.UnitPrice;
                        stockTrxUpdateActionDetail.StockTrxUpdateAction = _StockTrxUpdateAction;
                    }
                }
            }
            this.cmdGetInTrx.Enabled = false ;
            this.StockCard.ReadOnly = true;
#endregion StockTrxUpdateActionForm_cmdGetInTrx_Click
        }

        protected override void PreScript()
        {
#region StockTrxUpdateActionForm_PreScript
    base.PreScript();
#endregion StockTrxUpdateActionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region StockTrxUpdateActionForm_ClientSidePreScript
    base.ClientSidePreScript();
            if (_StockTrxUpdateAction.CurrentStateDefID == StockTrxUpdateAction.States.New)
            {
                MainStoreDefinition mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);
                if (mainStore == null)
                    throw new Exception("Kaynaklarınızın arasında Ana Deposu olan bir kaynak olmadığından işleme devam edemezsiniz.");
                _StockTrxUpdateAction.MainStoreDefinition = mainStore;
                this.DropStateButton(StockTrxUpdateAction.States.Approval);
            }
            else
            {
                this.cmdGetInTrx.Enabled = false;
                this.cmdUpdatePrice.Enabled = false;
                this.StockCard.ReadOnly = true;
                this.NewUnitPrice.ReadOnly = true;
            }
#endregion StockTrxUpdateActionForm_ClientSidePreScript

        }
    }
}