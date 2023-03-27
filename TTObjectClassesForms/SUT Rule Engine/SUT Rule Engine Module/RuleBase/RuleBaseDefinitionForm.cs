
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
    /// RuleBaseDefinitionForm
    /// </summary>
    public partial class RuleBaseDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            IsWarningOnly.CheckedChanged += new TTControlEventDelegate(IsWarningOnly_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IsWarningOnly.CheckedChanged -= new TTControlEventDelegate(IsWarningOnly_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void IsWarningOnly_CheckedChanged()
        {
#region RuleBaseDefinitionForm_IsWarningOnly_CheckedChanged
   if (IsWarningOnly.Value.HasValue && IsWarningOnly.Value.Value == true)
            {
                WarningMessage.ReadOnly = false;
                WarningMessage.Required = true;
            }
            else
            {
                WarningMessage.ReadOnly = true;
                WarningMessage.Required = false;
            }
#endregion RuleBaseDefinitionForm_IsWarningOnly_CheckedChanged
        }

        protected override void PreScript()
        {
#region RuleBaseDefinitionForm_PreScript
    IsWarningOnly_CheckedChanged();
#endregion RuleBaseDefinitionForm_PreScript

            }
                }
}