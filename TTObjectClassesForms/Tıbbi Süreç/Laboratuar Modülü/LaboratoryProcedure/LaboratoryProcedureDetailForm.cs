
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
    /// Laboratuvar Panel Detay Formu
    /// </summary>
    public partial class LaboratoryProcedureDetailForm : TTForm
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
#region LaboratoryProcedureDetailForm_PreScript
    base.PreScript();
            
            foreach(LaboratorySubProcedure subProcedure in this._LaboratoryProcedure.LaboratorySubProcedures)
            {
                string name = subProcedure.ProcedureObject.Name;
            }
#endregion LaboratoryProcedureDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region LaboratoryProcedureDetailForm_PostScript
    base.PostScript(transDef);
#endregion LaboratoryProcedureDetailForm_PostScript

            }
                }
}