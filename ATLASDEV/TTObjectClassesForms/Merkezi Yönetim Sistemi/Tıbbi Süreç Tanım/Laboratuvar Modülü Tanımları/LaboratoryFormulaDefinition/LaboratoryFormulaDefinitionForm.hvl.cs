
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
    /// Laboratuvar Formül Tanımları
    /// </summary>
    public partial class LaboratoryFormulaDefinitionForm : TTForm
    {
        protected TTObjectClasses.LaboratoryFormulaDefinition _LaboratoryFormulaDefinition
        {
            get { return (TTObjectClasses.LaboratoryFormulaDefinition)_ttObject; }
        }

        protected ITTCheckBox ISACTIVE;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn FormulaTest;
        protected ITTEnumComboBoxColumn FormulaVariable;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTValueListBox ttvaluelistbox1;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("7d3be38e-fece-4349-8e15-06749ab98693"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("b0ce2870-0601-4356-a3e0-32308f39c3f6"));
            FormulaTest = (ITTListBoxColumn)AddControl(new Guid("72c00fab-9eec-45a8-b896-a8c7585d5bc7"));
            FormulaVariable = (ITTEnumComboBoxColumn)AddControl(new Guid("0c4e75c0-c804-46fc-b4e5-a00da2a56f8c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3cfafb25-fa43-4d3c-8007-4109d61aec65"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("69a76e8b-5c84-40ef-b145-50788c404eb1"));
            ttvaluelistbox1 = (ITTValueListBox)AddControl(new Guid("4c63575c-85cb-45a6-a005-559640d98736"));
            labelName = (ITTLabel)AddControl(new Guid("99d099a4-7f64-47a0-affa-933254328430"));
            Name = (ITTTextBox)AddControl(new Guid("3b157b7c-e27b-434b-9bca-ff10b932ee37"));
            base.InitializeControls();
        }

        public LaboratoryFormulaDefinitionForm() : base("LABORATORYFORMULADEFINITION", "LaboratoryFormulaDefinitionForm")
        {
        }

        protected LaboratoryFormulaDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}