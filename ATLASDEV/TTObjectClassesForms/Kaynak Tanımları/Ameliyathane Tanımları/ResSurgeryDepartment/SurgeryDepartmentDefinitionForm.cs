
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
    /// Ameliyathane Tanımı
    /// </summary>
    public partial class SurgeryDepartmentDefinitionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryDepartmentDefinitionForm_PostScript
    base.PostScript(transDef);
            
            if (this._ResSurgeryDepartment.EnabledType==null)
            {
                this._ResSurgeryDepartment.EnabledType=ResourceEnableType.BothInpatientAndOutPatient;
            }
#endregion SurgeryDepartmentDefinitionForm_PostScript

            }
                }
}