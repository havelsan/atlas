
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
    /// Sipariş Sürecinde
    /// </summary>
    public partial class InOrderProgressForm : RUL_BaseForm
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
#region InOrderProgressForm_PreScript
    base.PreScript();
            
            bool completed = false;
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            IList maintenanceOrders = readOnlyContext.QueryObjects("MAINTENANCEORDER", "RELATEDREFERTOUPPERLEVEL =" + ConnectionManager.GuidToString(_ReferToUpperLevel.ObjectID));
            if (maintenanceOrders.Count > 0)
            {
                MaintenanceOrder maintenanceOrder = (MaintenanceOrder)maintenanceOrders[0];
                if (maintenanceOrder.CurrentStateDefID == MaintenanceOrder.States.Completed || maintenanceOrder.CurrentStateDefID == MaintenanceOrder.States.Cancelled)
                {
                    completed = true;
                }
            }
            if (completed == false)
            {
                this.DropStateButton(ReferToUpperLevel.States.Completed);
            }
#endregion InOrderProgressForm_PreScript

            }
                }
}