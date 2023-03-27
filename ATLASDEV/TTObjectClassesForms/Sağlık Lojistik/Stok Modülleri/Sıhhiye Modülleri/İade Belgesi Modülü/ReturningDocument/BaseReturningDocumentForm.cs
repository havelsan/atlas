
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
    /// İade Belgesi
    /// </summary>
    public partial class BaseReturningDocumentForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdHEKReport.Click += new TTControlEventDelegate(cmdHEKReport_Click);
            ChooseProductsFromTheTree.Click += new TTControlEventDelegate(ChooseProductsFromTheTree_Click);
            StockActionOutDetails.CellContentClick += new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            StockActionOutDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdHEKReport.Click -= new TTControlEventDelegate(cmdHEKReport_Click);
            ChooseProductsFromTheTree.Click -= new TTControlEventDelegate(ChooseProductsFromTheTree_Click);
            StockActionOutDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            StockActionOutDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            TTTeslimAlanButon.Click -= new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click -= new TTControlEventDelegate(TTTeslimEdenButon_Click);
            base.UnBindControlEvents();
        }

        private void TTTeslimAlanButon_Click()
        {
            #region TTTeslimAlanButon_Click
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ResUser> resUser = ResUser.GetAllUser(context, "WHERE ISACTIVE = 1 ");
            ResUser selectedPersonel = null;

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (ResUser user in resUser)
            {
                multiSelectForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);
            }
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Alan Personel Seçin");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Seçilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimAlan.Text = selectedPersonel.Name.ToString();
                _ReturningDocument.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimAlanButon_Click
        }
        private void TTTeslimEdenButon_Click()
        {
            #region TTTeslimEdenButon_Click
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ResUser> resUser = ResUser.GetAllUser(context, "WHERE ISACTIVE = 1 ");
            ResUser selectedPersonel = null;

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (ResUser user in resUser)
            {
                multiSelectForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);
            }
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Eden Personeli Seçin");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Seçilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimEden.Text = selectedPersonel.Name.ToString();
                _ReturningDocument.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }


        private void cmdHEKReport_Click()
        {
#region BaseReturningDocumentForm_cmdHEKReport_Click
   if (_ReturningDocument.RepairObjectID != null)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _ReturningDocument.RepairObjectID.ToString());
                parameters.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KayitSilmeyeEsasTeknikRapor), true, 1, parameters);
            }
            if (_ReturningDocument.MaterialRepairObjectID != null)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _ReturningDocument.MaterialRepairObjectID.ToString());
                parameters.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KayitSilmeyeEsasTeknikRapor), true, 1, parameters);
            }
#endregion BaseReturningDocumentForm_cmdHEKReport_Click
        }

        private void ChooseProductsFromTheTree_Click()
        {
#region BaseReturningDocumentForm_ChooseProductsFromTheTree_Click
   MultiSelectForm multiSelectForm = new MultiSelectForm();
            IList productTreeDefinitions = this._ReturningDocument.ObjectContext.QueryObjects(typeof(ProductTreeDefinition).Name, "");
            foreach (ProductTreeDefinition productTreeDefinition in productTreeDefinitions)
                multiSelectForm.AddMSItem(productTreeDefinition.Material.Name, productTreeDefinition.ObjectID.ToString(), productTreeDefinition);

            multiSelectForm.GetMSItem(this, "Ürünü Seçiniz...");
            if (multiSelectForm.MSSelectedItemObject != null)
            {
                ProductTreeDefinition productTreeDefinition = multiSelectForm.MSSelectedItemObject as ProductTreeDefinition;
                if (productTreeDefinition != null)
                {
                    foreach (ProductTreeDetail productTreeDetail in productTreeDefinition.ProductTreeDetails)
                    {
                        ReturningDocumentMaterial returningDocumentMaterial = this._ReturningDocument.ReturningDocumentMaterials.AddNew();
                        returningDocumentMaterial.Material = productTreeDetail.ConsumableMaterial;
                        returningDocumentMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                    }
                    ChooseProductsFromTheTree.Enabled = false;
                }
            }
#endregion BaseReturningDocumentForm_ChooseProductsFromTheTree_Click
        }

        private void StockActionOutDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseReturningDocumentForm_StockActionOutDetails_CellContentClick
   if(StockActionOutDetails.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)StockActionOutDetails.CurrentCell.OwningRow.TTObject);
#endregion BaseReturningDocumentForm_StockActionOutDetails_CellContentClick
        }

        private void StockActionOutDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseReturningDocumentForm_StockActionOutDetails_CellValueChanged
   if(StockActionOutDetails.CurrentCell.OwningColumn.Name == "RequireAmount")
            {
                if (StockActionOutDetails.Rows[rowIndex].Cells["RequireAmount"].Value != null)
                {
                    ITTGridRow returningDocumentMaterialRow = StockActionOutDetails.Rows[StockActionOutDetails.CurrentCell.RowIndex];
                    ReturningDocumentMaterial returningDocumentMaterial = ((ReturningDocumentMaterial)returningDocumentMaterialRow.TTObject);
                    returningDocumentMaterial.Amount = returningDocumentMaterial.RequireAmount;
                }
            }
#endregion BaseReturningDocumentForm_StockActionOutDetails_CellValueChanged
        }

        protected override void PreScript()
        {
#region BaseReturningDocumentForm_PreScript
    if (_ReturningDocument.MaterialRepairObjectID == null && _ReturningDocument.RepairObjectID == null)
                this.cmdHEKReport.ReadOnly = true;
#endregion BaseReturningDocumentForm_PreScript

            }
                }
}