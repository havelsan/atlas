
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
    public partial class BaseMainStoreStockTransferForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            DestinationStore.SelectedObjectChanged += new TTControlEventDelegate(DestinationStore_SelectedObjectChanged);
            MainStoreStockTransferMaterials.CellContentClick += new TTGridCellEventDelegate(MainStoreStockTransferMaterials_CellContentClick);
            MainStoreStockTransferMaterials.CellDoubleClick += new TTGridCellEventDelegate(MainStoreStockTransferMaterials_CellDoubleClick);
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DestinationStore.SelectedObjectChanged -= new TTControlEventDelegate(DestinationStore_SelectedObjectChanged);
            MainStoreStockTransferMaterials.CellContentClick -= new TTGridCellEventDelegate(MainStoreStockTransferMaterials_CellContentClick);
            MainStoreStockTransferMaterials.CellDoubleClick -= new TTGridCellEventDelegate(MainStoreStockTransferMaterials_CellDoubleClick);
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
                _MainStoreStockTransfer.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
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
                _MainStoreStockTransfer.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }



        private void DestinationStore_SelectedObjectChanged()
        {
            #region BaseMainStoreStockTransferForm_DestinationStore_SelectedObjectChanged
            //if (DestinationStore.SelectedObjectID == Store.SelectedObjectID)
            //    throw new Exception("Aynı Depoya İşlem Başlatılamaz!");
          
            #endregion BaseMainStoreStockTransferForm_DestinationStore_SelectedObjectChanged
        }

        private void MainStoreStockTransferMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseMainStoreStockTransferForm_MainStoreStockTransferMaterials_CellContentClick
            if (MainStoreStockTransferMaterials.CurrentCell.OwningColumn.Name == "Detail")
                this.ShowStockActionDetailForm((StockActionDetail)MainStoreStockTransferMaterials.CurrentCell.OwningRow.TTObject);
            #endregion BaseMainStoreStockTransferForm_MainStoreStockTransferMaterials_CellContentClick
        }

        private void MainStoreStockTransferMaterials_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseMainStoreStockTransferForm_MainStoreStockTransferMaterials_CellDoubleClick
            if (this is MainStoreStockTransferApprovalForm)
                CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, MainStoreStockTransferMaterials);
            #endregion BaseMainStoreStockTransferForm_MainStoreStockTransferMaterials_CellDoubleClick
        }

        protected override void PreScript()
        {
            #region BaseMainStoreStockTransferForm_PreScript
            base.PreScript();

          // DestinationStore.ListFilterExpression = "MKYS_BUTCETURU = "+ (int)((MKYS_EButceTurEnum)((MainStoreDefinition)this.Store.SelectedObject).MKYS_ButceTuru.Value) + " AND ISACTIVE = 1 AND OBJECTID <> "+ ConnectionManager.GuidToString(this._MainStoreStockTransfer.Store.ObjectID);

            if (this._MainStoreStockTransfer.CurrentStateDefID == MainStoreStockTransfer.States.New)
                MaterialMainStoreStockTransferMat.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(this._MainStoreStockTransfer.Store.ObjectID) + " AND STOCKS.INHELD > 0";
            #endregion BaseMainStoreStockTransferForm_PreScript

        }
    }
}