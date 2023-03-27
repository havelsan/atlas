
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
    public partial class StockCardIntegrationForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            createButton.Click += new TTControlEventDelegate(createButton_Click);
            findButton.Click += new TTControlEventDelegate(findButton_Click);
            EscButton.Click += new TTControlEventDelegate(EscButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            createButton.Click -= new TTControlEventDelegate(createButton_Click);
            findButton.Click -= new TTControlEventDelegate(findButton_Click);
            EscButton.Click -= new TTControlEventDelegate(EscButton_Click);
            base.UnBindControlEvents();
        }

        private void createButton_Click()
        {
#region StockCardIntegrationForm_createButton_Click
   //   try
            //            {
            //                Store selectedStore = SelectedStore.SelectedObject as Store;
            //                if (selectedStore == null)
            //                    throw new TTException("Depo seçili değil işleme devam edilemez.");
//
            //                if (stockCardsListView.SelectedItems.Count == 0)
            //                    throw new TTException("Herhangi bir kart seçmediniz!");
//
            //                ITTListViewItem listViewItem = stockCardsListView.SelectedItems[0];
//
            //                bool stockCardIsExists = Convert.ToBoolean(listViewItem.SubItems[7].Text);
            //                bool stockIsExists = Convert.ToBoolean(listViewItem.SubItems[8].Text);
//
            //                if (stockCardIsExists && stockIsExists)
            //                    throw new TTException("Seçmiş olduğunuz stok kartı saymanlığınız tarafından kullanılmaktadır.");
//
            //                RemotingInfoClass.StockCardInfo stockCardInfo = StockCard.RemoteMethods.GetStockCardInfo(Sites.SiteMerkezSagKom, ((RemotingInfoClass.StockCardCentralInfo)listViewItem.Tag).stockCard.ObjectID);
            //                if (stockCardInfo != null)
            //                {
            //                    NewStockCardDefinitionForm newStockCardDefinitionForm = NewStockCardDefinitionForm.ShowNewStockCardDefinitionForm(stockCardInfo, selectedStore);
            //                    DialogResult dialogResult = newStockCardDefinitionForm.ShowDialog(this);
            //                    if (dialogResult == DialogResult.OK)
            //                    {
            //                        string result = stockCardInfo.Save(newStockCardDefinitionForm.NewStockCardDefinition);
            //                        InfoBox.Show(result, MessageIconEnum.InformationMessage);
            //                        stockCardsListView.Items.Remove(listViewItem);
            //                        return;
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                InfoBox.Show(ex);
            //            }
#endregion StockCardIntegrationForm_createButton_Click
        }

        private void findButton_Click()
        {
#region StockCardIntegrationForm_findButton_Click
   //            if(string.IsNullOrEmpty(barcodNoTextBox.Text))
//            {
//                if(stockCardClassCombobox.SelectedItem == null && string.IsNullOrEmpty(stockNoTextBox.Text) && string.IsNullOrEmpty(stockCardNameTextBox.Text) && string.IsNullOrEmpty(stockCardEnglishNameTextBox.Text))
//                {
//                    InfoBox.Show(this,"Arama yapmak için Barkod Nu veya Stok Nu., Stok Kart Adı, Orjinal Adı veya Stok Kart Sınıfı alanlarından bir veya birden fazlası dolu olmalıdır.", MessageIconEnum.WarningMessage);
//                    return;
//                }
//            }
//           
//            
//
//            stockCardsListView.Items.Clear();
//            string stockCardClassIDs = string.Empty;
//            if (stockCardClassCombobox.SelectedItem != null)
//            {
//                StockCardClass selectedStockCardClass = stockCardClassCombobox.SelectedItem.Value as StockCardClass;
//                if (selectedStockCardClass != null)
//                {
//                    List<string> stockCardClassObjectIDs = new List<string>();
//                    selectedStockCardClass.GetSubStockCardClassObjectIDs(ref stockCardClassObjectIDs);
//                    for (int i = 0; i < stockCardClassObjectIDs.Count; i++)
//                    {
//                        stockCardClassIDs += stockCardClassObjectIDs[i];
//                        if (i != stockCardClassObjectIDs.Count - 1)
//                            stockCardClassIDs += ",";
//                    }
//                }
//            }
//            
//            
//
//            List<RemotingInfoClass.StockCardCentralInfo> stockCardCentralInfos = StockCard.RemoteMethods.GetStockCards(Sites.SiteMerkezSagKom, stockNoTextBox.Text, stockCardNameTextBox.Text, stockCardClassIDs, stockCardEnglishNameTextBox.Text, barcodNoTextBox.Text);
//            if (stockCardCentralInfos != null && stockCardCentralInfos.Count > 0)
//            {
//                foreach (RemotingInfoClass.StockCardCentralInfo stockCardCentralInfo in stockCardCentralInfos)
//                {
//                    ITTListViewItem listViewItem = stockCardsListView.Items.Add(stockCardCentralInfo.stockCard.NATOStockNO);
//                    listViewItem.Tag = stockCardCentralInfo;
//                    listViewItem.SubItems.Add(stockCardCentralInfo.stockCard.Name);
//                    listViewItem.SubItems.Add(stockCardCentralInfo.stockCard.EnglishName);
//
//                    if (stockCardCentralInfo.distributionTypeDefinition != null)
//                        listViewItem.SubItems.Add(stockCardCentralInfo.distributionTypeDefinition.DistributionType);
//                    else
//                        listViewItem.SubItems.Add(string.Empty);
//
//                    if (stockCardCentralInfo.stockCardClass != null)
//                        listViewItem.SubItems.Add(stockCardCentralInfo.stockCardClass.Name);
//                    else
//                        listViewItem.SubItems.Add(string.Empty);
//
//                    if (stockCardCentralInfo.stockCard.StockMethod.HasValue)
//                    {
//                        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(StockMethodEnum).Name];
//                        listViewItem.SubItems.Add(dataType.EnumValueDefs[(int)stockCardCentralInfo.stockCard.StockMethod.Value].DisplayText);
//                    }
//                    else
//                    {
//                        listViewItem.SubItems.Add(string.Empty);
//                    }
//
//                    bool stockCardIsExists = false;
//                    bool stockIsExists = false;
//                    bool cardDrawerIsExists = false;
//                    string status = string.Empty;
//                    if (SelectedStore.SelectedObject != null && SelectedStore.SelectedObject is Store)
//                    {
//                        Store store = (Store)SelectedStore.SelectedObject;
//                        TTObjectContext readonlyObjectContext = new TTObjectContext(true);
//                        StockCard stockCard = null;
//                        try
//                        {
//                            stockCard = (StockCard)readonlyObjectContext.GetObject(stockCardCentralInfo.stockCard.ObjectID, stockCardCentralInfo.stockCard.ObjectDef);
//                        }
//                        catch { }
//                        if (stockCard != null)
//                        {
//                            stockCardIsExists = true;
//                            if (stockCard.AccountancyStockCards.Count  > 0)
//                            {
//                                foreach (AccountancyStockCard accountancyStockCard in stockCard.AccountancyStockCards)
//                                {
//                                    if (((MainStoreDefinition)store).Accountancy == accountancyStockCard.Accountancy)
//                                    {
//                                        stockIsExists = true;
//                                        cardDrawerIsExists = true;
//                                        break;
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                foreach (Material material in stockCard.Materials)
//                                {
//                                    if (material.Stocks.Count > 0)
//                                    {
//                                        stockIsExists = true;
//                                        break;
//                                    }
//                                }
//                            }
//                        }
//                        if (stockCardIsExists)
//                        {
//                            status += "Tanımlı Stok Kartı";
//                            if (stockIsExists)
//                                status += ", Tanımlı Stok";
//                            else
//                                status += ", Tanımsız Stok";
//                            if (cardDrawerIsExists)
//                                status += ", Masası Var";
//                            else
//                                status += ", Masası Yok";
//                        }
//                        else
//                        {
//                            status += "Tanımsız Stok Kartı";
//                        }
//
//                    }
//                    listViewItem.SubItems.Add(status);
//                    listViewItem.SubItems.Add(stockCardIsExists.ToString());
//                    listViewItem.SubItems.Add(stockIsExists.ToString());
//                }
//            }
#endregion StockCardIntegrationForm_findButton_Click
        }

        private void EscButton_Click()
        {
#region StockCardIntegrationForm_EscButton_Click
   this.DialogResult = DialogResult.Cancel;
#endregion StockCardIntegrationForm_EscButton_Click
        }

#region StockCardIntegrationForm_Methods
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AcceptButton = (IButtonControl)findButton;
            this.CancelButton = (IButtonControl)EscButton;
            TTObjectContext context = new TTObjectContext(true);
            IList parentStockCardClass = context.QueryObjects("STOCKCARDCLASS", "PARENTSTOCKCARDCLASS IS NULL");
            stockCardClassCombobox.Items.Add(new TTComboBoxItem("", null));
            foreach (StockCardClass stockCardClassItem in parentStockCardClass)
                stockCardClassCombobox.Items.Add(new TTComboBoxItem(stockCardClassItem.Name.ToString(), stockCardClassItem));
        }


        public static void OpenStockCardIntegrationForm()
        {
            try
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                List<MainStoreDefinition> selectableStores = new List<MainStoreDefinition>();
                if (TTUser.CurrentUser.IsSuperUser)
                {
                    TTObjectContext ctx = new TTObjectContext(true);
                    IList mainStores = ctx.QueryObjects<MainStoreDefinition>();
                    foreach (MainStoreDefinition mainStoreDefinition in mainStores)
                        if (mainStoreDefinition.IsActive.HasValue && mainStoreDefinition.IsActive.Value)
                            selectableStores.Add(mainStoreDefinition);
                }
                else
                {
                    if (resUser != null)
                    {
                        foreach (Store store in resUser.SelectedStores)
                            if (store is MainStoreDefinition)
                                selectableStores.Add((MainStoreDefinition)store);
                    }

                }
                MainStoreDefinition selectedMainStoreDefinition = null;
                if (selectableStores.Count > 0)
                {
                    if (selectableStores.Count == 1)
                    {
                        selectedMainStoreDefinition = selectableStores[0];
                    }
                    else
                    {
                        MultiSelectForm multiSelectForm = new MultiSelectForm();

                        foreach (MainStoreDefinition mainStoreDefinition in selectableStores)
                            multiSelectForm.AddMSItem(mainStoreDefinition.Name, mainStoreDefinition.ObjectID.ToString(), mainStoreDefinition);
                        multiSelectForm.GetMSItem(null, "Saymanlık Deposu seçiniz.", false, true, false, false, true, true);
                        selectedMainStoreDefinition = (MainStoreDefinition)multiSelectForm.MSSelectedItemObject;
                    }
                }


                if (selectedMainStoreDefinition != null)
                {
                    StockCardIntegrationForm stockCardIntegrationForm = new StockCardIntegrationForm();
                    stockCardIntegrationForm.SelectedStore.SelectedObject = selectedMainStoreDefinition;
                    InfoBox.Show("stockCardIntegrationForm.ShowDialog(parentForm);");
                }
                else
                {
                    throw new TTException("Bu işlemi sadece Saymanlık Depolarına bağlı kullanıcılar kullanabilir.");
                }
            }
            catch
            {
                throw;
            }
        }
        
#endregion StockCardIntegrationForm_Methods
    }
}