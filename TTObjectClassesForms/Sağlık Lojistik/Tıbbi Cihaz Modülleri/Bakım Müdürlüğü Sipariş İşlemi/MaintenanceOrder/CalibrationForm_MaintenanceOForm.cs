
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
    /// Kalibrasyon
    /// </summary>
    public partial class CalibrationForm_MaintenanceO : TTForm
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
#region CalibrationForm_MaintenanceO_PreScript
    base.PreScript();
            this.DropStateButton(MaintenanceOrder.States.Cancelled);
            if(_MaintenanceOrder.MaintenanceOrderType.TypeCode == "KS")
            {
                this.DropStateButton(MaintenanceOrder.States.LastControl);
            }
            else
            {
                this.DropStateButton(MaintenanceOrder.States.CalibrationLastControl);
            }
#endregion CalibrationForm_MaintenanceO_PreScript

            }
                }
}