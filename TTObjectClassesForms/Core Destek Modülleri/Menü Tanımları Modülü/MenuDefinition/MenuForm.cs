
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
    /// Menü Tanımlama
    /// </summary>
    public partial class MenuForm : TTForm
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
#region MenuForm_PreScript
    base.PreScript();
            if(this._MenuDefinition.MenuDefinitionNo.Value.HasValue)
                textboxMenuDefNo.Text = "MD_" + this._MenuDefinition.MenuDefinitionNo.Value.ToString();
#endregion MenuForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MenuForm_PostScript
    base.PostScript(transDef);
            if(((ITTObject)this._ttObject).IsNew)
                this._MenuDefinition.MenuDefinitionNo.GetNextValue();
#endregion MenuForm_PostScript

            }
                }
}