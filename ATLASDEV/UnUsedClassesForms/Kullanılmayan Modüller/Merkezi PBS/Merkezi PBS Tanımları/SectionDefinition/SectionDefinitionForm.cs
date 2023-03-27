
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
    public partial class SectionDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            OfficeId.SelectedObjectChanged += new TTControlEventDelegate(OfficeId_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OfficeId.SelectedObjectChanged -= new TTControlEventDelegate(OfficeId_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void OfficeId_SelectedObjectChanged()
        {
#region SectionDefinitionForm_OfficeId_SelectedObjectChanged
   if (_SectionDefinition.OfficeId != null)
                _SectionDefinition.UnitId = _SectionDefinition.OfficeId.UnitId;
#endregion SectionDefinitionForm_OfficeId_SelectedObjectChanged
        }
    }
}