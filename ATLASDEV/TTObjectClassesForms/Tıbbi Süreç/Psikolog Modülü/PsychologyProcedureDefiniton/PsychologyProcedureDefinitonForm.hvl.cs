
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
    public partial class PsychologyProcedureDefinitonForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PsychologyProcedureDefiniton _PsychologyProcedureDefiniton
        {
            get { return (TTObjectClasses.PsychologyProcedureDefiniton)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel labelPsychologyProcedureType;
        protected ITTEnumComboBox PsychologyProcedureType;
        protected ITTLabel labelProcedureTree;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("0f0c26fd-beb5-4b22-b3dd-cb66ad957048"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("c863fd3b-6ef3-4576-b82e-1525e63130c6"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("ef8599f6-8290-4c84-a257-ceee14802c4e"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("1a50b9ce-ade4-4cdd-9ce4-50109d4652ca"));
            labelPsychologyProcedureType = (ITTLabel)AddControl(new Guid("5ac0d112-4dab-4e9d-9352-0a8ec5b48a9c"));
            PsychologyProcedureType = (ITTEnumComboBox)AddControl(new Guid("4b0dbde7-355a-4a5e-ad96-6e6e5a3e3bc4"));
            labelProcedureTree = (ITTLabel)AddControl(new Guid("47b74cf2-da0d-4081-9152-2f63b8d1e37b"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("a075ff17-470e-45c1-ab5a-7dadf3cecc5e"));
            labelName = (ITTLabel)AddControl(new Guid("96b53ce5-6b63-422d-a499-6b20c93b97e4"));
            Name = (ITTTextBox)AddControl(new Guid("c34157d8-15c2-4f81-b4b2-3391c149fc5a"));
            Code = (ITTTextBox)AddControl(new Guid("e5988ef6-b7f1-4f04-8478-88fe61a8657a"));
            labelCode = (ITTLabel)AddControl(new Guid("d9cc369a-e10f-4417-a89b-2259d26fceb6"));
            IsActive = (ITTCheckBox)AddControl(new Guid("1da5d513-510a-4c3c-8c47-6590d003b700"));
            base.InitializeControls();
        }

        public PsychologyProcedureDefinitonForm() : base("PSYCHOLOGYPROCEDUREDEFINITON", "PsychologyProcedureDefinitonForm")
        {
        }

        protected PsychologyProcedureDefinitonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}