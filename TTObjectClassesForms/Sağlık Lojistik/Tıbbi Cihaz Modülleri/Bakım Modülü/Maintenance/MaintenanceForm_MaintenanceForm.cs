
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
    /// Bakım
    /// </summary>
    public partial class MaintenanceForm_Maintenance : MaintenanceBaseForm
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
#region MaintenanceForm_Maintenance_PreScript
    _Maintenance.FillMaintenanceParameters();
            //if (this.MaintenanceParameter.Rows.Count == 0)
            //    this.Check.ReadOnly = true;
#endregion MaintenanceForm_Maintenance_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MaintenanceForm_Maintenance_PostScript
    base.PostScript(transDef);
            
            if((bool)_Maintenance.AreAllMaintenanceParametersChecked() == false)
            {
                string message = SystemMessage.GetMessage(70);
                throw new TTUtils.TTException(message);
            }
#endregion MaintenanceForm_Maintenance_PostScript

            }
                }
}