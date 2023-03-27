
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
    public partial class BaseSubStoreStockTransferForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            DestinationStore.SelectedObjectChanged += new TTControlEventDelegate(DestinationStore_SelectedObjectChanged);
            SubStoreStockTransferMaterials.CellContentClick += new TTGridCellEventDelegate(SubStoreStockTransferMaterials_CellContentClick);
            SubStoreStockTransferMaterials.CellDoubleClick += new TTGridCellEventDelegate(SubStoreStockTransferMaterials_CellDoubleClick);
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DestinationStore.SelectedObjectChanged -= new TTControlEventDelegate(DestinationStore_SelectedObjectChanged);
            SubStoreStockTransferMaterials.CellContentClick -= new TTGridCellEventDelegate(SubStoreStockTransferMaterials_CellContentClick);
            SubStoreStockTransferMaterials.CellDoubleClick -= new TTGridCellEventDelegate(SubStoreStockTransferMaterials_CellDoubleClick);
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
                _SubStoreStockTransfer.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
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
                _SubStoreStockTransfer.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }



        private void DestinationStore_SelectedObjectChanged()
        {
#region BaseSubStoreStockTransferForm_DestinationStore_SelectedObjectChanged
   if(DestinationStore.SelectedObjectID  == Store.SelectedObjectID)
                throw new Exception("Aynı Depoya İşlem Başlatılamaz!");
#endregion BaseSubStoreStockTransferForm_DestinationStore_SelectedObjectChanged
        }

        private void SubStoreStockTransferMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseSubStoreStockTransferForm_SubStoreStockTransferMaterials_CellContentClick
   if (SubStoreStockTransferMaterials.CurrentCell.OwningColumn.Name == "Detail")
                this.ShowStockActionDetailForm((StockActionDetail)SubStoreStockTransferMaterials.CurrentCell.OwningRow.TTObject);
#endregion BaseSubStoreStockTransferForm_SubStoreStockTransferMaterials_CellContentClick
        }

        private void SubStoreStockTransferMaterials_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseSubStoreStockTransferForm_SubStoreStockTransferMaterials_CellDoubleClick
   if(this is SubStoreStockTransferApprovalForm)
                CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, SubStoreStockTransferMaterials);
#endregion BaseSubStoreStockTransferForm_SubStoreStockTransferMaterials_CellDoubleClick
        }

        protected override void PreScript()
        {
#region BaseSubStoreStockTransferForm_PreScript
    base.PreScript();


            DestinationStore.ListFilterExpression = " AND ISACTIVE = 1 AND OBJECTID <> " + ConnectionManager.GuidToString(this._SubStoreStockTransfer.Store.ObjectID);


            if (this._SubStoreStockTransfer.CurrentStateDefID == SubStoreStockTransfer.States.New)
                MaterialSubStoreStockTransferMat.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(this._SubStoreStockTransfer.Store.ObjectID) + " AND STOCKS.INHELD > 0";
#endregion BaseSubStoreStockTransferForm_PreScript

            }
                }
}