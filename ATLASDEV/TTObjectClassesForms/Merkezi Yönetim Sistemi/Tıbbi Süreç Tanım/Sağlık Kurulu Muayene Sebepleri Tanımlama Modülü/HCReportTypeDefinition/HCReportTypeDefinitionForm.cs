
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
    public partial class HCReportTypeDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            IsDisabled.CheckedChanged += new TTControlEventDelegate(IsDisabled_CheckedChanged);
            IsStatusNotification.CheckedChanged += new TTControlEventDelegate(IsStatusNotification_CheckedChanged); 
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IsDisabled.CheckedChanged -= new TTControlEventDelegate(IsDisabled_CheckedChanged);
            IsStatusNotification.CheckedChanged -= new TTControlEventDelegate(IsStatusNotification_CheckedChanged);
            base.UnBindControlEvents();
        }
        private void IsDisabled_CheckedChanged()
        {
            #region HCReportTypeDefinitionForm_IsDisabled_CheckedChanged
            if (this.IsDisabled.Value == true)
                this.IsStatusNotification.Value = false;
            #endregion HCReportTypeDefinitionForm_IsDisabled_CheckedChanged
        }
        private void IsStatusNotification_CheckedChanged()
        {
            #region HCReportTypeDefinitionForm_IsStatusNotification_CheckedChanged
            if (this.IsStatusNotification.Value == true)
                this.IsDisabled.Value = false;
            #endregion HCReportTypeDefinitionForm_IsStatusNotification_CheckedChanged
        }
    }
}