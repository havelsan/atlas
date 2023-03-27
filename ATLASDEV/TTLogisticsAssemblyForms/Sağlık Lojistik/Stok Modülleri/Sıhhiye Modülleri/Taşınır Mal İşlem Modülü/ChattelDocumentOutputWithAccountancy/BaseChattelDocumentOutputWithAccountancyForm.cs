
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
    public partial class BaseChattelDocumentOutputWithAccountancy : BaseChattelDocumentForm
    {
        override protected void BindControlEvents()
        {
            ChattelDocumentDetailsWithAccountancy.CellDoubleClick += new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellDoubleClick);
            ChattelDocumentDetailsWithAccountancy.CellValueChanged += new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellValueChanged);
            ChattelDocumentDetailsWithAccountancy.CellContentClick += new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellContentClick);
            Accountancy.SelectedObjectChanged += new TTControlEventDelegate(Accountancy_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ChattelDocumentDetailsWithAccountancy.CellDoubleClick -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellDoubleClick);
            ChattelDocumentDetailsWithAccountancy.CellValueChanged -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellValueChanged);
            ChattelDocumentDetailsWithAccountancy.CellContentClick -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellContentClick);
            Accountancy.SelectedObjectChanged -= new TTControlEventDelegate(Accountancy_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void ChattelDocumentDetailsWithAccountancy_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseChattelDocumentOutputWithAccountancy_ChattelDocumentDetailsWithAccountancy_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, ChattelDocumentDetailsWithAccountancy);
#endregion BaseChattelDocumentOutputWithAccountancy_ChattelDocumentDetailsWithAccountancy_CellDoubleClick
        }

        private void ChattelDocumentDetailsWithAccountancy_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseChattelDocumentOutputWithAccountancy_ChattelDocumentDetailsWithAccountancy_CellValueChanged
   if (_ChattelDocumentOutputWithAccountancy.Accountancy == null)
            {
                _ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.DeleteChildren();
                InfoBox.Show("Önce Saymanlık Seçiniz");
            }


//            if (_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit != null)
//            {
//                if ((bool)_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.IsSupported && _ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.Site != null)
//                {
//                    if (ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name == "MaterialChattelDocumentDetailWithAccountancy")
//                    {
//                        if (ChattelDocumentDetailsWithAccountancy.Rows[rowIndex].Cells["MaterialChattelDocumentDetailWithAccountancy"].Value != null)
//                        {
//                            Material material = (Material)_ChattelDocumentOutputWithAccountancy.ObjectContext.GetObject(new Guid(ChattelDocumentDetailsWithAccountancy.Rows[rowIndex].Cells["MaterialChattelDocumentDetailWithAccountancy"].Value.ToString()), typeof(Material));
//                            if ((bool)material.IsOldMaterial)
//                            {
//                                ITTGridCell cell = ChattelDocumentDetailsWithAccountancy.CurrentCell;
//                                cell.SetErrorText("Eski malzeme seçemezsiniz");
//                            }
//                        }
//                    }
//                }
//            }
#endregion BaseChattelDocumentOutputWithAccountancy_ChattelDocumentDetailsWithAccountancy_CellValueChanged
        }

        private void ChattelDocumentDetailsWithAccountancy_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseChattelDocumentOutputWithAccountancy_ChattelDocumentDetailsWithAccountancy_CellContentClick
   if(ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningRow.TTObject);
#endregion BaseChattelDocumentOutputWithAccountancy_ChattelDocumentDetailsWithAccountancy_CellContentClick
        }

        private void Accountancy_SelectedObjectChanged()
        {
#region BaseChattelDocumentOutputWithAccountancy_Accountancy_SelectedObjectChanged
   _ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.DeleteChildren();
            
            /*
            if (((Accountancy)Accountancy.SelectedObject).AccountancyMilitaryUnit == null)
                ((ITTListBoxColumn)((ITTGridColumn)this.ChattelDocumentDetailsWithAccountancy.Columns["MaterialChattelDocumentDetailWithAccountancy"])).ListFilterExpression = "STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom) + "AND STOCKS.STORE = " + ConnectionManager.GuidToString(_ChattelDocumentOutputWithAccountancy.Store.ObjectID) + " AND STOCKS.INHELD > 0";
            else
            {
                if (((Accountancy)Accountancy.SelectedObject).AccountancyMilitaryUnit.IsSupported != null)
                {
                    //Eski Malzeme Çıkış işlemi için değiştirildi.
                    //if (((Accountancy)Accountancy.SelectedObject).AccountancyMilitaryUnit.IsSupported == false)
                    //    ((ITTListBoxColumn)((ITTGridColumn)this.ChattelDocumentDetailsWithAccountancy.Columns["MaterialChattelDocumentDetailWithAccountancy"])).ListFilterExpression = "STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom) + "AND STOCKS.STORE = " + ConnectionManager.GuidToString(_ChattelDocumentOutputWithAccountancy.Store.ObjectID) + " AND STOCKS.INHELD > 0 ";
                    //else
                    //    ((ITTListBoxColumn)((ITTGridColumn)this.ChattelDocumentDetailsWithAccountancy.Columns["MaterialChattelDocumentDetailWithAccountancy"])).ListFilterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(_ChattelDocumentOutputWithAccountancy.Store.ObjectID) + " AND STOCKS.INHELD > 0 AND ISOLDMATERIAL = 0";
                    ((ITTListBoxColumn)((ITTGridColumn)this.ChattelDocumentDetailsWithAccountancy.Columns["MaterialChattelDocumentDetailWithAccountancy"])).ListFilterExpression = "STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom) + "AND STOCKS.STORE = " + ConnectionManager.GuidToString(_ChattelDocumentOutputWithAccountancy.Store.ObjectID) + " AND STOCKS.INHELD > 0";
                }
                else
                    ((ITTListBoxColumn)((ITTGridColumn)this.ChattelDocumentDetailsWithAccountancy.Columns["MaterialChattelDocumentDetailWithAccountancy"])).ListFilterExpression = "STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom) + "AND STOCKS.STORE = " + ConnectionManager.GuidToString(_ChattelDocumentOutputWithAccountancy.Store.ObjectID) + " AND STOCKS.INHELD > 0";
            }
            */
#endregion BaseChattelDocumentOutputWithAccountancy_Accountancy_SelectedObjectChanged
        }
    }
}