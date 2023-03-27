
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
    /// Saymanlık Tanımı
    /// </summary>
    public partial class AccountancyDefinitionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region AccountancyDefinitionForm_PreScript
    base.PreScript();
            
            this._ResAccountancy.EnabledType = ResourceEnableType.BothInpatientAndOutPatient;
#endregion AccountancyDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AccountancyDefinitionForm_PostScript
    base.PostScript(transDef);
            
            if (this._ResAccountancy.EnabledType != ResourceEnableType.BothInpatientAndOutPatient && this._ResAccountancy.EnabledType != ResourceEnableType.InPatient)
                throw new TTException(SystemMessage.GetMessage(1246));
#endregion AccountancyDefinitionForm_PostScript

            }
                }
}