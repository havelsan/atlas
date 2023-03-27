
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
    public partial class BaseNursingDischargingInstructionPlanForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Hasta Taburculuk Planlama
    /// </summary>
        protected TTObjectClasses.BaseNursingDischargingInstructionPlan _BaseNursingDischargingInstructionPlan
        {
            get { return (TTObjectClasses.BaseNursingDischargingInstructionPlan)_ttObject; }
        }

        protected ITTGrid NursingDischargingInstructionPlans;
        protected ITTListBoxColumn DischargingInstructionPlanNursingDischargingInstructionPlan;
        protected ITTCheckBoxColumn PatientGetInstructionNursingDischargingInstructionPlan;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        override protected void InitializeControls()
        {
            NursingDischargingInstructionPlans = (ITTGrid)AddControl(new Guid("54bebeb2-4762-41aa-90a9-538c5b429cc4"));
            DischargingInstructionPlanNursingDischargingInstructionPlan = (ITTListBoxColumn)AddControl(new Guid("f9486126-850c-493f-8812-3dcf7522e5cb"));
            PatientGetInstructionNursingDischargingInstructionPlan = (ITTCheckBoxColumn)AddControl(new Guid("866e5835-676e-49c5-a3f3-e5bd66dcf328"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("001c0f30-01e1-4fab-8b8f-558f29c069a8"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("732f7148-415a-4620-9e3b-466121f4f38c"));
            base.InitializeControls();
        }

        public BaseNursingDischargingInstructionPlanForm() : base("BASENURSINGDISCHARGINGINSTRUCTIONPLAN", "BaseNursingDischargingInstructionPlanForm")
        {
        }

        protected BaseNursingDischargingInstructionPlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}