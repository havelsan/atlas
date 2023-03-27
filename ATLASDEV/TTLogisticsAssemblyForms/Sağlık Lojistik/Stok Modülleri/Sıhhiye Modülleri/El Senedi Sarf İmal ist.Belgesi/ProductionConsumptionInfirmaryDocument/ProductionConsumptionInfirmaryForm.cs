
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
    /// El Senedi Sarf İmal İstihsal Belgesi
    /// </summary>
    public partial class ProductionConsumptionInfirmaryForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionOutDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionOutDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void StockActionOutDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ProductionConsumptionInfirmaryForm_StockActionOutDetails_CellValueChanged
   ITTGridCell changedCell = StockActionOutDetails.Rows[rowIndex].Cells[columnIndex];
            ITTGridRow changedRow = StockActionOutDetails.Rows[rowIndex];
            if (changedCell.OwningColumn.Name == "Material")
            {
                if (changedCell.Value != null)
                {
                    //Deponun seçilip seçilmediği kontrolü yapılacak
                    Guid materialGuid = new Guid(changedCell.Value.ToString());
                    IList stockList = _ProductionConsumptionInfirmaryDocument.Store.Stocks.Select("MATERIAL = " + ConnectionManager.GuidToString(materialGuid));
                    if (stockList.Count > 1)
                        throw new TTUtils.TTException("Birden fazla stok olamaz");
                    if (stockList.Count == 0)
                    {
                        changedRow.Cells["Existing"].Value = 0;
                    }
                    else
                    {
                        Stock stock = (Stock)stockList[0];
                        changedRow.Cells["Existing"].Value = stock.Inheld;
                    }
                }

            }
            if (changedRow.Cells["Amount"].Value != null)
            {
                if (Convert.ToDouble(changedRow.Cells["Amount"].Value) > Convert.ToDouble(changedRow.Cells["Existing"].Value))
                    throw new TTUtils.TTException("Seçilen depoda yeterli mevcut bulunmamaktadır.Yazdığınız miktar toplam mevcuttan küçük ya da eşit olmalıdır.");
            }
#endregion ProductionConsumptionInfirmaryForm_StockActionOutDetails_CellValueChanged
        }

        protected override void PreScript()
        {
#region ProductionConsumptionInfirmaryForm_PreScript
    base.PreScript();
#endregion ProductionConsumptionInfirmaryForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region ProductionConsumptionInfirmaryForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (this._ProductionConsumptionInfirmaryDocument.CurrentStateDefID == ProductionConsumptionInfirmaryDocument.States.New)
            {
                ProductionConsumptionInfirmaryDateForm productionConsumptionInfirmaryDateForm = new ProductionConsumptionInfirmaryDateForm();
                DialogResult dialogResult = productionConsumptionInfirmaryDateForm.ShowEdit(this, this._ProductionConsumptionInfirmaryDocument, true);

                if (dialogResult == DialogResult.OK)
                {

                    StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)_ProductionConsumptionInfirmaryDocument.ObjectContext.GetObject(new Guid(_ProductionConsumptionInfirmaryDocument.ObjectDef.Attributes["STOCKCONSUMPTIONTRANSACTIONATTRIBUTE"].Parameters["stockTransactionDef"].Value.ToString()), "STOCKTRANSACTIONDEFINITION");
                    int rowCount = 0;
                    bool calcnew = false;
                    List<StockTransaction> stockTransactions = stockTransactionDefinition.CollectStockTransactions((DateTime)_ProductionConsumptionInfirmaryDocument.StartDate, (DateTime)_ProductionConsumptionInfirmaryDocument.EndDate, _ProductionConsumptionInfirmaryDocument.Store);
                    if (stockTransactions != null)
                    {
                        foreach (StockTransaction stockTransaction in stockTransactions)
                        {
                            IList existDetails = this._ProductionConsumptionInfirmaryDocument.ProductionConsumptionInfirmaryDocumentOutMaterials.Select("MATERIAL = " + ConnectionManager.GuidToString(stockTransaction.Stock.Material.ObjectID));
                            ProductionConsumptionInfirmaryDocumentMaterialOut productionConsumptionInfirmaryDocumentMaterialOut;
                            if (existDetails.Count > 0)
                            {
                                productionConsumptionInfirmaryDocumentMaterialOut = (ProductionConsumptionInfirmaryDocumentMaterialOut)existDetails[0];
                                productionConsumptionInfirmaryDocumentMaterialOut.Amount += stockTransaction.Amount;
                                
                                
                                StockCollectedTrx stockCollectedTrx = productionConsumptionInfirmaryDocumentMaterialOut.StockCollectedTrxs.AddNew();
                                stockCollectedTrx.StockTransaction = stockTransaction;
                                
                            }
                            else
                            {
                                if (rowCount >= 50)
                                {
                                    calcnew = true;
                                }
                                else
                                {
                                    productionConsumptionInfirmaryDocumentMaterialOut = this._ProductionConsumptionInfirmaryDocument.ProductionConsumptionInfirmaryDocumentOutMaterials.AddNew();
                                    productionConsumptionInfirmaryDocumentMaterialOut.Amount = stockTransaction.Amount;
                                    productionConsumptionInfirmaryDocumentMaterialOut.Material = stockTransaction.Stock.Material;
                                    productionConsumptionInfirmaryDocumentMaterialOut.StockLevelType = stockTransaction.StockLevelType;
                                    productionConsumptionInfirmaryDocumentMaterialOut.Material.StockCard.DistributionType = stockTransaction.Stock.Material.StockCard.DistributionType;

                                    if (productionConsumptionInfirmaryDocumentMaterialOut == null)
                                        throw new TTException("Detay boş olamaz.");

                                    StockCollectedTrx stockCollectedTrx = productionConsumptionInfirmaryDocumentMaterialOut.StockCollectedTrxs.AddNew();
                                    stockCollectedTrx.StockTransaction = stockTransaction;

                                    rowCount++;
                                }
                            }
                        }
                    }
                    if (calcnew)
                    {
                        TTVisual.InfoBox.Show(((DateTime)_ProductionConsumptionInfirmaryDocument.StartDate).ToShortDateString() + " " + ((DateTime)_ProductionConsumptionInfirmaryDocument.EndDate).ToShortDateString() + " tarihleri arasında bu işlemi bir daha çalıştırmanız gerekmektedir.", MessageIconEnum.InformationMessage);
                    }
                }
            }
#endregion ProductionConsumptionInfirmaryForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProductionConsumptionInfirmaryForm_PostScript
    base.PostScript(transDef);
               //   this._ProductionConsumptionDocument.SetStockLevelType();
#endregion ProductionConsumptionInfirmaryForm_PostScript

            }
            
#region ProductionConsumptionInfirmaryForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _ProductionConsumptionInfirmaryDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
            if (materials.Count == 0)
                InfoBox.Show(value + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name, m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                //Sarf edilecek miktar giri?i
                string retAmount = InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                ProductionConsumptionInfirmaryDocumentMaterialOut returningDocument = _ProductionConsumptionInfirmaryDocument.ProductionConsumptionInfirmaryDocumentOutMaterials.AddNew();
                returningDocument.Material = material;
                returningDocument.Amount = amount;

                //Malzeme durumu giri?i
                List<ComboListItem> stockLevelList = new List<ComboListItem>();
                IBindingList stockLevels = _ProductionConsumptionInfirmaryDocument.ObjectContext.QueryObjects("STOCKLEVELTYPE", "", "STOCKLEVELTYPESTATUS");
                
                foreach (StockLevelType item in stockLevels)
                {
                    stockLevelList.Add(new ComboListItem(item.StockLevelTypeStatus, item.Description));
                }
                ComboListItem retStockLevelType = InputForm.GetValueListItem("Malın Durumunu Seçiniz.", stockLevelList.ToArray());
  
                if (retStockLevelType != null)
                {
                    returningDocument.StockLevelType = (StockLevelType)retStockLevelType.DataValue;

                    int deger = Convert.ToInt32(retStockLevelType.DataValue);
                    switch ((StockLevelTypeEnum)retStockLevelType.DataValue)
                    {
                        case StockLevelTypeEnum.Hek:
                            returningDocument.StockLevelType = TTObjectClasses.StockLevelType.HekStockLevel;
                            break;
                        case StockLevelTypeEnum.New:
                            returningDocument.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                            break;
                        case StockLevelTypeEnum.Used:
                            returningDocument.StockLevelType = TTObjectClasses.StockLevelType.UsedStockLevel;
                            break;
                        default:
                            InfoBox.Show("Malın Durumunu Doldurunuz.", MessageIconEnum.ErrorMessage);
                            break;
                    }
                }
                else
                {
                   InfoBox.Show("Malın Durumunu Doldurunuz.", MessageIconEnum.ErrorMessage);
                }
            }
        }
        
#endregion ProductionConsumptionInfirmaryForm_ClientSideMethods
    }
}