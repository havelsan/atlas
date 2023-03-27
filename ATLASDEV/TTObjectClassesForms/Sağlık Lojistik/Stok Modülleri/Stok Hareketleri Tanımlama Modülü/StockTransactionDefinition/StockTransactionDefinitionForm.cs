
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
    /// Stok Hareket Tipi Tanımı
    /// </summary>
    public partial class StockTransactionDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            TransactionType.SelectedIndexChanged += new TTControlEventDelegate(TransactionType_SelectedIndexChanged);
            AskForDateTime.CheckedChanged += new TTControlEventDelegate(AskForDateTime_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TransactionType.SelectedIndexChanged -= new TTControlEventDelegate(TransactionType_SelectedIndexChanged);
            AskForDateTime.CheckedChanged -= new TTControlEventDelegate(AskForDateTime_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void TransactionType_SelectedIndexChanged()
        {
#region StockTransactionDefinitionForm_TransactionType_SelectedIndexChanged
   if (_StockTransactionDefinition.TransactionType.HasValue && _StockTransactionDefinition.TransactionType.Value == TransactionTypeEnum.ChangeStockLevel)
                this.ChangedStockLevelType.Enabled = true;
            else
                this.ChangedStockLevelType.Enabled = false;
#endregion StockTransactionDefinitionForm_TransactionType_SelectedIndexChanged
        }

        private void AskForDateTime_CheckedChanged()
        {
#region StockTransactionDefinitionForm_AskForDateTime_CheckedChanged
   if (this.AskForDateTime.Value == false)
            {
                this.StartDateTimeFormat.Text = "";
                this.EndDateTimeFormat.Text = "";
            }
#endregion StockTransactionDefinitionForm_AskForDateTime_CheckedChanged
        }

        protected override void PreScript()
        {
#region StockTransactionDefinitionForm_PreScript
    base.PreScript();

            if (TTObjectClasses.SystemParameter.GetSite().ObjectID.Equals(Sites.SiteMerkezSagKom))
                DocumentListView.ReadOnly = false;
            else
                DocumentListView.ReadOnly = true;

            DocumentListView.Items.Clear();

            BindingList<StockTransactionDefinition> stockTransactionDefinitions = StockTransactionDefinition.GetAllStockTransactionDefinitions(_StockTransactionDefinition.ObjectContext);

            if (stockTransactionDefinitions != null)
            {
                foreach (StockTransactionDefinition stockTransactionDefinition in stockTransactionDefinitions)
                {
                    if (this.Description.Text == "" && stockTransactionDefinition.Description != null)
                    {
                        ITTListViewItem listViewItem = DocumentListView.Items.Add(stockTransactionDefinition.Description);
                        listViewItem.Checked = this.ExistsStockTransactionDefinition(stockTransactionDefinition);
                        listViewItem.Tag = stockTransactionDefinition;
                    }

                    if (stockTransactionDefinition.Description != null)
                    {
                        if (this.Description.Text != stockTransactionDefinition.Description.ToString() && this.Description.Text != "")
                        {
                            if (stockTransactionDefinition.Description != null)
                            {
                                ITTListViewItem listViewItem = DocumentListView.Items.Add(stockTransactionDefinition.Description);
                                listViewItem.Checked = this.ExistsStockTransactionDefinition(stockTransactionDefinition);
                                listViewItem.Tag = stockTransactionDefinition;
                            }
                        }
                    }
                }
            }

            if (_StockTransactionDefinition.TransactionType == TransactionTypeEnum.ChangeStockLevel)
                ChangedStockLevelType.Enabled = true;
            else
                ChangedStockLevelType.Enabled = false;
#endregion StockTransactionDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region StockTransactionDefinitionForm_PostScript
    base.PostScript(transDef);

            this._StockTransactionDefinition.StockTransactionCollectedDefinitions.DeleteChildren();
            if (this.DocumentListView.Items.Count > 0)
            {
                foreach (ITTListViewItem listViewItem in this.DocumentListView.Items)
                {
                    if (listViewItem.Checked)
                    {
                        StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)listViewItem.Tag;
                        StockTransactionCollectedDefinition stockTransactionCollectedDefinition = new StockTransactionCollectedDefinition(_StockTransactionDefinition.ObjectContext);
                        stockTransactionCollectedDefinition.CheckedStockTransactionDef = stockTransactionDefinition;

                        this._StockTransactionDefinition.StockTransactionCollectedDefinitions.Add(stockTransactionCollectedDefinition);
                    }
                }
            }
#endregion StockTransactionDefinitionForm_PostScript

            }
            
#region StockTransactionDefinitionForm_Methods
        private bool ExistsStockTransactionDefinition(StockTransactionDefinition stockTransactionDefinition)
        {
            bool bFound = false;

            foreach (StockTransactionCollectedDefinition stockTransactionCollectedDefinition in this._StockTransactionDefinition.StockTransactionCollectedDefinitions)
            {
                if (stockTransactionCollectedDefinition.CheckedStockTransactionDef.ObjectID.Equals(stockTransactionDefinition.ObjectID))
                {
                    bFound = true;
                    break;
                }
            }

            return bFound;
        }
        
#endregion StockTransactionDefinitionForm_Methods
    }
}