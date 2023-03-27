
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
    public partial class BaseGrantMaterialForm : BaseChattelDocumentForm
    {
        override protected void BindControlEvents()
        {
            this.TTFirma.Click += new TTControlEventDelegate(TTFirma_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            this.TTFirma.Click += new TTControlEventDelegate(TTFirma_Click);
            base.UnBindControlEvents();
        }
        private void TTFirma_Click()
        {
            #region TTFirma_Click
            TTObjectContext context = new TTObjectContext(false);
            BindingList<Supplier.SupplierDefFormNQL_Class> suppliers = Supplier.SupplierDefFormNQL(string.Empty);
            Supplier supplier = null;

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (Supplier.SupplierDefFormNQL_Class sp in suppliers)
            {
                multiSelectForm.AddMSItem(sp.Name, sp.Name, sp);
            }
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Tedarikçi Seçin");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Tedarikçi Seçilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                supplier = multiSelectForm.MSSelectedItemObject as Supplier;
                this.MaterialGranttedBy.Text = supplier.Name.ToString();
                this.GranttedByUniqNo.Text = supplier.TaxNo.ToString();
            }
            #endregion TTFirma_Click
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
                _GrantMaterial.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }



        private void GrantMaterialDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseGrantMaterialDetailsForm_DistributionDocumentMaterials_CellValueChanged
            if (GrantMaterialDetails.CurrentCell.OwningColumn.Name == "MaterialGrantMaterialDetail")
            {
                GrantMaterialDetails.CurrentCell.OwningRow.Cells["UnitPrice"].Value = "1";
                GrantMaterialDetails.CurrentCell.OwningRow.Cells["NotDiscountedUnitPrice"].Value = "1";

            }
            #endregion BaseGrantMaterialDetailsForm_DistributionDocumentMaterials_CellValueChanged
        }




    }
}