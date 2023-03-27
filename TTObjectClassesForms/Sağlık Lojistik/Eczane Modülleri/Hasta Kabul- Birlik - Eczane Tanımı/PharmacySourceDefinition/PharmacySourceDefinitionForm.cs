
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
    /// Hasta Kabul- Birlik - Eczane Tanımı
    /// </summary>
    public partial class PharmacySourceDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            AllMilitaryUnit.CheckedChanged += new TTControlEventDelegate(AllMilitaryUnit_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AllMilitaryUnit.CheckedChanged -= new TTControlEventDelegate(AllMilitaryUnit_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void AllMilitaryUnit_CheckedChanged()
        {
#region PharmacySourceDefinitionForm_AllMilitaryUnit_CheckedChanged
   if (this.AllMilitaryUnit.Value == true)
            {
                this.PharmacySourceMilitaryUnits.ReadOnly = true;
                this.PharmacySourceMilitaryUnits.Required = false;
            }
            else if(this.AllMilitaryUnit.Value == false)
            {
                this.PharmacySourceMilitaryUnits.ReadOnly = false;
                this.PharmacySourceMilitaryUnits.Required = true;
            }
#endregion PharmacySourceDefinitionForm_AllMilitaryUnit_CheckedChanged
        }

        protected override void PreScript()
        {
#region PharmacySourceDefinitionForm_PreScript
    base.PreScript();
    if (_PharmacySourceDefinition.AllMilitaryUnit == null)
    {
        this.AllMilitaryUnit.Value = false;
    }
    if(_PharmacySourceDefinition.AllMilitaryUnit == true )
    {
        this.PharmacySourceMilitaryUnits.ReadOnly = true;
    }
#endregion PharmacySourceDefinitionForm_PreScript

            }
                }
}