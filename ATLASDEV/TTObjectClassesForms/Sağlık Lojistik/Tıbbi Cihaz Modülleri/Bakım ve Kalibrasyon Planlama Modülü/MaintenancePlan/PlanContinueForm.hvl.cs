
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Bakım / Kalibrasyon Planlama
    /// </summary>
    public partial class PlanContinueForm : TTForm
    {
    /// <summary>
    /// Bakım ve Kalibrasyon Planlama
    /// </summary>
        protected TTObjectClasses.MaintenancePlan _MaintenancePlan
        {
            get { return (TTObjectClasses.MaintenancePlan)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("074e8a8b-7f81-4068-b100-6e3a1c5184ea"));
            base.InitializeControls();
        }

        public PlanContinueForm() : base("MAINTENANCEPLAN", "PlanContinueForm")
        {
        }

        protected PlanContinueForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}