
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
    /// Patoloji Ek İşlem Tanım Ekranı
    /// </summary>
    public partial class PathologyAdditionalTestDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PathologyAdditionalTestDefinition _PathologyAdditionalTestDefinition
        {
            get { return (TTObjectClasses.PathologyAdditionalTestDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTCheckBox ChkChargable;
        protected ITTTextBox Name;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelName;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("a10c06dc-1edc-4c91-b0f8-b949d703e6d4"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("c4c87247-a44d-4b6b-bf7b-06ee0d300dec"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("e88881d2-8284-422f-990d-a79a072a992c"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("afea3a6a-7ed3-497f-9350-b2b806c753c6"));
            ChkChargable = (ITTCheckBox)AddControl(new Guid("652eef8c-ee46-492d-a84e-9e9c89f8293b"));
            Name = (ITTTextBox)AddControl(new Guid("ba72c551-69b1-42df-9449-5a646f7b2fa6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("1d0298c9-d168-47c8-8a3b-8b7f22ff7a52"));
            labelName = (ITTLabel)AddControl(new Guid("30713e84-5698-4bd2-b3ac-c361e2e40485"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("59353ce1-621a-486d-a71d-26c6662c251f"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("780d569e-4333-43b0-afea-38357f7bd5ce"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d3f66ae2-571c-4f64-9b82-4a3fc2971252"));
            base.InitializeControls();
        }

        public PathologyAdditionalTestDefinitionForm() : base("PATHOLOGYADDITIONALTESTDEFINITION", "PathologyAdditionalTestDefinitionForm")
        {
        }

        protected PathologyAdditionalTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}