
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
    public partial class RegistryForm : RUL_BaseForm
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
#region RegistryForm_FixedAsset_SelectedObjectChanged
   _ReferToUpperLevel.FillEquipments();
            if (this.FixedAsset != null)
            {
                _ReferToUpperLevel.SenderAccountancy = ((FixedAssetMaterialDefinition)this.FixedAsset.SelectedObject).Accountancy;

                if (((FixedAssetMaterialDefinition)this.FixedAsset.SelectedObject).Accountancy.AccountancyMilitaryUnit != null)
                {
                    _ReferToUpperLevel.OwnerMilitaryUnit = ((FixedAssetMaterialDefinition)this.FixedAsset.SelectedObject).Accountancy.AccountancyMilitaryUnit;
                }
            }
#endregion RegistryForm_FixedAsset_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region RegistryForm_PreScript
    base.PreScript();
            _ReferToUpperLevel.RequestNo = DateTime.Now.Year.ToString() + "-" + "####" ;
            if (_ReferToUpperLevel.RepairObjectID == null)
            {
                this.SenderAccountancy.ReadOnly = false;
                this.OwnerMilitaryUnit.ReadOnly = false;
                this.ToMilitaryUnit.ReadOnly = false;
                this.Stage.ReadOnly = false;
            }
            else
            {
                this.SenderAccountancy.ReadOnly = true;
                this.OwnerMilitaryUnit.ReadOnly = true;
                this.ToMilitaryUnit.ReadOnly = true;
                this.Stage.ReadOnly = true;
            }
#endregion RegistryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RegistryForm_PostScript
    base.PostScript(transDef);
            
            if (_ReferToUpperLevel.ReferType == ReferTypeEnum.Repair)
            {
                if (BreakDown.Text == "")
                {
                    string message = SystemMessage.GetMessage(72);
                    throw new TTUtils.TTException(message);
                }
            }
            else
            {
                if (Desc.Text == "")
                {
                    string message = SystemMessage.GetMessage(73);
                    throw new TTUtils.TTException(message);
                }
            }
#endregion RegistryForm_PostScript

            }
                }
}