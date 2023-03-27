
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
    /// Kayıt
    /// </summary>
    public partial class UpperLevelRegistryForm : TTForm
    {
        override protected void BindControlEvents()
        {
            FixedAsset.SelectedObjectChanged += new TTControlEventDelegate(FixedAsset_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FixedAsset.SelectedObjectChanged -= new TTControlEventDelegate(FixedAsset_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void FixedAsset_SelectedObjectChanged()
        {
#region UpperLevelRegistryForm_FixedAsset_SelectedObjectChanged
   _ReferToUpperLevel.FillEquipments();
            if (this.FixedAsset != null)
            {
                _ReferToUpperLevel.SenderAccountancy = ((FixedAssetMaterialDefinition)this.FixedAsset.SelectedObject).Accountancy;

                if (((FixedAssetMaterialDefinition)this.FixedAsset.SelectedObject).Accountancy.AccountancyMilitaryUnit != null)
                {
                    _ReferToUpperLevel.OwnerMilitaryUnit = ((FixedAssetMaterialDefinition)this.FixedAsset.SelectedObject).Accountancy.AccountancyMilitaryUnit;
                }
            }
#endregion UpperLevelRegistryForm_FixedAsset_SelectedObjectChanged
        }
    }
}