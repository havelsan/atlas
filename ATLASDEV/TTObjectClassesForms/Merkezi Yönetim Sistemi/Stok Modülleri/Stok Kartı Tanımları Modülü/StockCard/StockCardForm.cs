
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
    /// Stok Kart Tanımları
    /// </summary>
    public partial class StockCardForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            cmdDrugDefinition.Click += new TTControlEventDelegate(cmdDrugDefinition_Click);
            AddMaterialButton.Click += new TTControlEventDelegate(AddMaterialButton_Click);
            Materials.CellContentClick += new TTGridCellEventDelegate(Materials_CellContentClick);
            RemoveMaterialButton.Click += new TTControlEventDelegate(RemoveMaterialButton_Click);
            cmdConsumableDefinition.Click += new TTControlEventDelegate(cmdConsumableDefinition_Click);
            cmdFixedAssetDefinition.Click += new TTControlEventDelegate(cmdFixedAssetDefinition_Click);
            MainStoreCheckbox.CheckedChanged += new TTControlEventDelegate(MainStoreCheckbox_CheckedChanged);
            RepairCheckbox.CheckedChanged += new TTControlEventDelegate(RepairCheckbox_CheckedChanged);
            ProductionCheckbox.CheckedChanged += new TTControlEventDelegate(ProductionCheckbox_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            cmdDrugDefinition.Click -= new TTControlEventDelegate(cmdDrugDefinition_Click);
            AddMaterialButton.Click -= new TTControlEventDelegate(AddMaterialButton_Click);
            Materials.CellContentClick -= new TTGridCellEventDelegate(Materials_CellContentClick);
            RemoveMaterialButton.Click -= new TTControlEventDelegate(RemoveMaterialButton_Click);
            cmdConsumableDefinition.Click -= new TTControlEventDelegate(cmdConsumableDefinition_Click);
            cmdFixedAssetDefinition.Click -= new TTControlEventDelegate(cmdFixedAssetDefinition_Click);
            MainStoreCheckbox.CheckedChanged -= new TTControlEventDelegate(MainStoreCheckbox_CheckedChanged);
            RepairCheckbox.CheckedChanged -= new TTControlEventDelegate(RepairCheckbox_CheckedChanged);
            ProductionCheckbox.CheckedChanged -= new TTControlEventDelegate(ProductionCheckbox_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region StockCardForm_ttbutton1_Click
   //  System.Diagnostics.Debugger.Break();

            //MessageBox.Show("Stok kartları yeniden sıralanıyor...Bu işlem stok kartlarını alfabetik olarak sıralayarak yeniden numara verilmesini sağlar.");
            //MessageBox.Show("Şu anki sıra numaraları eski sıra numarası olarak aktarılıyor....Eğer daha önce aktarmışsanız şu an aktaracaklarınız hatalı olabilir...");
            //MessageBox.Show("Kart sayıları olmayan kartların, kart sayıları 1 olarak düzeltiliyor");

            StockCard stockCard = _StockCard;
            Guid guidMainStore = new Guid("6ff551e9-453d-4c81-bb69-ffae3a8df568");
            Hashtable unSortedStockCardList = new Hashtable();
            string message = "";
            IList stockCardClasses = stockCard.ObjectContext.QueryObjects("STOCKCARDCLASS", "ISGROUP = 1");

            foreach (StockCardClass stockCardClass in stockCardClasses)
            {
                IList stockCards = stockCard.ObjectContext.QueryObjects("STOCKCARD", "STOCKCARDCLASS = " + ConnectionManager.GuidToString(stockCardClass.ObjectID));
                foreach (StockCard sc in stockCards)
                {
                    foreach (Material material in sc.Materials)
                    {
                        if (material.ObjectDef.Name.ToString() != "MATERIAL")
                        {
                            IList stocks = stockCard.ObjectContext.QueryObjects("STOCK", "MATERIAL = " + ConnectionManager.GuidToString(material.ObjectID) + " AND STORE =" + ConnectionManager.GuidToString(guidMainStore));
                            foreach (Stock stock in stocks)
                            {
                                // MessageBox.Show(stock.Material.StockCard.Name);
                                Common.TTStringSortableList stockCardNameListItem = new Common.TTStringSortableList();
                                stockCardNameListItem.ID = stock.Material.StockCard.ObjectID;
                                stockCardNameListItem.Value = stock.Material.StockCard.Name;
                                unSortedStockCardList.Add(stockCardNameListItem.ID, stockCardNameListItem);
                            }
                        }
                    }
                }
            }

            List<Common.TTStringSortableList> stockCardNameList = Common.SortedStringItems(unSortedStockCardList);
            if (this.SortType.Value == true)
                stockCardNameList.Reverse();
            for (int i = 0; i < stockCardNameList.Count; i++)
                message = message + stockCardNameList[i].Value + "\n";

            InfoBox.Show(message);
#endregion StockCardForm_ttbutton1_Click
        }

        private void cmdDrugDefinition_Click()
        {
#region StockCardForm_cmdDrugDefinition_Click
   //string filtre = "NO = '" + ItemsGrid.CurrentCell.Value + "'";
            TTListDef listDef = TTObjectDefManager.Instance.ListDefs["DrugListDefinition"];
            TTDefinitionForm df = TTDefinitionForm.GetEditForm(listDef);
            df.ShowEdit(this.FindForm(), listDef);
#endregion StockCardForm_cmdDrugDefinition_Click
        }

        private void AddMaterialButton_Click()
        {
#region StockCardForm_AddMaterialButton_Click
   IList materials = Material.GetMaterialWithoutStockCard(_StockCard.ObjectContext);

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (Material material in materials)
                multiSelectForm.AddMSItem(material.Name, material.ObjectID.ToString(), material);
            string key = multiSelectForm.GetMSItem(ParentForm, "Stokkartına bağlamak istediğiniz malzemeyi seçiniz");

            if (string.IsNullOrEmpty(key) == false)
                _StockCard.Materials.Add(multiSelectForm.MSSelectedItemObject as Material);
#endregion StockCardForm_AddMaterialButton_Click
        }

        private void Materials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
        }

        private void RemoveMaterialButton_Click()
        {
#region StockCardForm_RemoveMaterialButton_Click
   if (this.Materials.CurrentCell != null)
            {
                ITTGridRow row = this.Materials.CurrentCell.OwningRow;
                Material material = row.TTObject as Material;
                if (material != null)
                    _StockCard.Materials.Remove(material);
            }
#endregion StockCardForm_RemoveMaterialButton_Click
        }

        private void cmdConsumableDefinition_Click()
        {
#region StockCardForm_cmdConsumableDefinition_Click
   //string filtre = "NO = '" + ItemsGrid.CurrentCell.Value + "'";
            TTListDef listDef = TTObjectDefManager.Instance.ListDefs["ConsumableMaterialDefinitionList"];
            TTDefinitionForm df = TTDefinitionForm.GetEditForm(listDef);
            df.ShowEdit(this.FindForm(), listDef);
#endregion StockCardForm_cmdConsumableDefinition_Click
        }

        private void cmdFixedAssetDefinition_Click()
        {
#region StockCardForm_cmdFixedAssetDefinition_Click
   //string filtre = "NO = '" + ItemsGrid.CurrentCell.Value + "'";
            TTListDef listDef = TTObjectDefManager.Instance.ListDefs["FixedAssetDefFormList"];
            TTDefinitionForm df = TTDefinitionForm.GetEditForm(listDef);
            df.ShowEdit(this.FindForm(), listDef);
#endregion StockCardForm_cmdFixedAssetDefinition_Click
        }

        private void MainStoreCheckbox_CheckedChanged()
        {
#region StockCardForm_MainStoreCheckbox_CheckedChanged
   if ((bool)this.MainStoreCheckbox.Value)
            {
                if ((bool)this.RepairCheckbox.Value)
                    this.RepairCheckbox.Value = false;
            }
#endregion StockCardForm_MainStoreCheckbox_CheckedChanged
        }

        private void RepairCheckbox_CheckedChanged()
        {
#region StockCardForm_RepairCheckbox_CheckedChanged
   if ((bool)this.RepairCheckbox.Value)
            {
                if ((bool)this.ProductionCheckbox.Value)
                    this.ProductionCheckbox.Value = false;
                if ((bool)this.MainStoreCheckbox.Value)
                    this.MainStoreCheckbox.Value = false;
            }
#endregion StockCardForm_RepairCheckbox_CheckedChanged
        }

        private void ProductionCheckbox_CheckedChanged()
        {
#region StockCardForm_ProductionCheckbox_CheckedChanged
   if ((bool)this.ProductionCheckbox.Value)
            {
                if ((bool)this.RepairCheckbox.Value)
                    this.RepairCheckbox.Value = false;
            }
#endregion StockCardForm_ProductionCheckbox_CheckedChanged
        }

        protected override void PreScript()
        {
#region StockCardForm_PreScript
    base.PreScript();

            ((TTGrid)this.MaterialStocksGrid).VirtualMode = false;
            ((TTGrid)this.MaterialStocksGrid).Rows.Clear();
            foreach (Material material in _StockCard.Materials)
            {
                if (material.Stocks.Count != 0)
                    ((TTGrid)this.MaterialStocksGrid).Rows.Add(new object[] { material.Name.ToString(), ((Stock)material.Stocks[0]).Store.Name.ToString(), ((Stock)material.Stocks[0]).Inheld });
            }

            //NATOStockNO.ReadOnly = true;
           /* DistributionType.ReadOnly = true;
            StockMethod.ReadOnly = true;
            Materials.ReadOnly = true;
            MaterialStocksGrid.ReadOnly = true;*/
#endregion StockCardForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region StockCardForm_PostScript
    base.PostScript(transDef);
            if (((ITTObject)_StockCard).IsNew == false)
            {
                ResCardDrawer oldValue = ((StockCard)((ITTObject)_StockCard).Original).CardDrawer;
                if (oldValue != null)
                    if (oldValue.ObjectID.Equals(_StockCard.CardDrawer.ObjectID) == false)
                        throw new TTException("Stok Kartının Bağlı Bulunduğu Masa sadece Masa Değiştirme İşlemi ile yapılabilir.");
            }
#endregion StockCardForm_PostScript

            }
                }
}