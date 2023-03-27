
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
    /// Hizmet Tanımı
    /// </summary>
    public partial class ProcedureForm : TerminologyManagerDefForm
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
            #region ProcedureForm_PreScript
            base.PreScript();
            this.ProcType.Text = this._ProcedureDefinition.ObjectDef.ToString();
            #endregion ProcedureForm_PreScript
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            // this._ProcedureDefinition.ControlGILProperties();
        }
    }
}