
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
    /// Garanti Onarımı
    /// </summary>
    public partial class GuarantyRepairForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdSupplierDef.Click += new TTControlEventDelegate(cmdSupplierDef_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSupplierDef.Click -= new TTControlEventDelegate(cmdSupplierDef_Click);
            base.UnBindControlEvents();
        }

        private void cmdSupplierDef_Click()
        {
#region GuarantyRepairForm_cmdSupplierDef_Click
   if (_Repair.Supplier != null)
            {
                Supplier sup = (Supplier)_Repair.Supplier;
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SupplierDefFormList"];
                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef);
                frm.ShowReadOnly(this.FindForm(), listDef, sup);

            }
            else
            {
                InfoBox.Show("Firma Seçmediniz");
            }
#endregion GuarantyRepairForm_cmdSupplierDef_Click
        }
    }
}