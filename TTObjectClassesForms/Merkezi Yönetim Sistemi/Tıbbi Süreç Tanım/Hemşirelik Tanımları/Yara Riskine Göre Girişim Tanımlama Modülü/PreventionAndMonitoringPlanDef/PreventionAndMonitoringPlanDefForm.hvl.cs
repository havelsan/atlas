
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
    public partial class PreventionAndMonitoringPlanDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PreventionAndMonitoringPlanDef _PreventionAndMonitoringPlanDef
        {
            get { return (TTObjectClasses.PreventionAndMonitoringPlanDef)_ttObject; }
        }

        protected ITTCheckBox PlusTwentyRiskChecked;
        protected ITTCheckBox PlusFifteenRiskChecked;
        protected ITTCheckBox PlusTenRiskChecked;
        protected ITTLabel PlanDefinition;
        protected ITTTextBox Definition;
        override protected void InitializeControls()
        {
            PlusTwentyRiskChecked = (ITTCheckBox)AddControl(new Guid("5488fe60-444e-448b-b740-420db97855e7"));
            PlusFifteenRiskChecked = (ITTCheckBox)AddControl(new Guid("996328d4-c130-45c0-9160-27103e78da98"));
            PlusTenRiskChecked = (ITTCheckBox)AddControl(new Guid("dad573a6-f18e-4883-93c0-fbe541b38fb9"));
            PlanDefinition = (ITTLabel)AddControl(new Guid("5f90e6cc-ee28-44ca-8430-283ab2206e1f"));
            Definition = (ITTTextBox)AddControl(new Guid("1b497654-3f7c-4ca7-b874-a795bfaa85c8"));
            base.InitializeControls();
        }

        public PreventionAndMonitoringPlanDefForm() : base("PREVENTIONANDMONITORINGPLANDEF", "PreventionAndMonitoringPlanDefForm")
        {
        }

        protected PreventionAndMonitoringPlanDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}