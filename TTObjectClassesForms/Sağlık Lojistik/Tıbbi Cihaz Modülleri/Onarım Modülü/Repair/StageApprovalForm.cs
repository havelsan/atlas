
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
    /// İlk Değerlendirme
    /// </summary>
    public partial class StageApprovalForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            RepairPlace.SelectedIndexChanged += new TTControlEventDelegate(RepairPlace_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RepairPlace.SelectedIndexChanged -= new TTControlEventDelegate(RepairPlace_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void RepairPlace_SelectedIndexChanged()
        {
#region StageApprovalForm_RepairPlace_SelectedIndexChanged
   if (this.RepairPlace.SelectedIndex == 0)
            {
                deliveryDate.ReadOnly = true;
            }
            else
            {
                deliveryDate.ReadOnly = false;
            }
#endregion StageApprovalForm_RepairPlace_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region StageApprovalForm_PreScript
    if ((bool)_Repair.IsUnderGuaranty())
            {
                GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + _Repair.FixedAssetMaterialDefinition.GuarantyEndDate.Value.ToString();
            }
            else
            {
                GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                GuaranyStatuslabel.Text = "GARANTİ DIŞI";
            }

            this.MilitaryUnit.SelectedObject = Common.GetCurrentMilitaryUnit(_Repair.ObjectContext);
#endregion StageApprovalForm_PreScript

            }
                }
}