
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
    /// Bütce Tipi Tanımı
    /// </summary>
    public partial class BudgetTypeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.BudgetTypeDefinition _BudgetTypeDefinition
        {
            get { return (TTObjectClasses.BudgetTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelMKYS_Butce;
        protected ITTEnumComboBox MKYS_Butce;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelMKYS_Butce = (ITTLabel)AddControl(new Guid("cb46eeb5-c92e-4dae-80a4-a20b4149997e"));
            MKYS_Butce = (ITTEnumComboBox)AddControl(new Guid("e1ba447e-60d1-4097-a544-c243826d04fb"));
            labelName = (ITTLabel)AddControl(new Guid("182a4f9b-f0ff-47b8-b70c-1aaddcf3d901"));
            Name = (ITTTextBox)AddControl(new Guid("6e8eb02a-ed6d-42b0-aed2-173549d52ccc"));
            Code = (ITTTextBox)AddControl(new Guid("92a62df4-7424-40b2-9257-6283179e8e35"));
            labelCode = (ITTLabel)AddControl(new Guid("ca4cfb37-4c7c-4516-bb43-980ec76bdc0c"));
            base.InitializeControls();
        }

        public BudgetTypeDefinitionForm() : base("BUDGETTYPEDEFINITION", "BudgetTypeDefinitionForm")
        {
        }

        protected BudgetTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}