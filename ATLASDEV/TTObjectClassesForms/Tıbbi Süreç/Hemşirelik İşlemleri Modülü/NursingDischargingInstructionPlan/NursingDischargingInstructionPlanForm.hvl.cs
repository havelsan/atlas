
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
    /// Eğitim
    /// </summary>
    public partial class NursingDischargingInstructionPlanForm : TTForm
    {
        protected TTObjectClasses.NursingDischargingInstructionPlan _NursingDischargingInstructionPlan
        {
            get { return (TTObjectClasses.NursingDischargingInstructionPlan)_ttObject; }
        }

        protected ITTCheckBox PatientGetInstruction;
        protected ITTLabel labelDischargingInstructionPlan;
        protected ITTObjectListBox DischargingInstructionPlan;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            PatientGetInstruction = (ITTCheckBox)AddControl(new Guid("35163ed7-d6f2-493c-b156-0a7ffb85fc20"));
            labelDischargingInstructionPlan = (ITTLabel)AddControl(new Guid("4a521a0b-30f9-40f0-b635-847f067ccada"));
            DischargingInstructionPlan = (ITTObjectListBox)AddControl(new Guid("2635ce82-4f2d-463d-8980-71ee256879a8"));
            labelNote = (ITTLabel)AddControl(new Guid("85e8d9aa-f836-4a1c-8b12-4f995d801b19"));
            Note = (ITTTextBox)AddControl(new Guid("7a183e9c-ed8f-4c62-91c1-89fd464eda09"));
            labelActionDate = (ITTLabel)AddControl(new Guid("60449a1c-19e9-4170-9f59-5f4668368448"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ec23bbe2-03fb-4d88-a2c5-cf71cddeb23b"));
            base.InitializeControls();
        }

        public NursingDischargingInstructionPlanForm() : base("NURSINGDISCHARGINGINSTRUCTIONPLAN", "NursingDischargingInstructionPlanForm")
        {
        }

        protected NursingDischargingInstructionPlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}