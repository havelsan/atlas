
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
    /// Dağıtım Belgesi
    /// </summary>
    public partial class BaseDistributionDocumentForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            DistributionDocumentMaterials.CellDoubleClick += new TTGridCellEventDelegate(DistributionDocumentMaterials_CellDoubleClick);
            DistributionDocumentMaterials.CellContentClick += new TTGridCellEventDelegate(DistributionDocumentMaterials_CellContentClick);
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
           
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DistributionDocumentMaterials.CellDoubleClick -= new TTGridCellEventDelegate(DistributionDocumentMaterials_CellDoubleClick);
            DistributionDocumentMaterials.CellContentClick -= new TTGridCellEventDelegate(DistributionDocumentMaterials_CellContentClick);
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
                _DistributionDocument.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
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
                _DistributionDocument.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }


        private void DistributionDocumentMaterials_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseDistributionDocumentForm_DistributionDocumentMaterials_CellDoubleClick
            if (this is DistributionDocumentRequestForm)
                CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, DistributionDocumentMaterials);
            #endregion BaseDistributionDocumentForm_DistributionDocumentMaterials_CellDoubleClick
        }

        private void DistributionDocumentMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseDistributionDocumentForm_DistributionDocumentMaterials_CellContentClick
            if (DistributionDocumentMaterials.CurrentCell.OwningColumn.Name == "Detail")
                this.ShowStockActionDetailForm((StockActionDetail)DistributionDocumentMaterials.CurrentCell.OwningRow.TTObject);
            #endregion BaseDistributionDocumentForm_DistributionDocumentMaterials_CellContentClick
        }

        protected override void PreScript()
        {
            #region BaseDistributionDocumentForm_PreScript
            base.PreScript();
            #endregion BaseDistributionDocumentForm_PreScript

        }

       
    }
}