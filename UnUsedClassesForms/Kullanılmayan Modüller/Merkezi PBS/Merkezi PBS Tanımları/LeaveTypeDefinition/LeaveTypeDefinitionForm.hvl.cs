
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
    public partial class LeaveTypeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.LeaveTypeDefinition _LeaveTypeDefinition
        {
            get { return (TTObjectClasses.LeaveTypeDefinition)_ttObject; }
        }

        protected ITTTextBox SEQUENCE;
        protected ITTTextBox SHORT_NAME;
        protected ITTTextBox NAME;
        protected ITTLabel labelSEQUENCE;
        protected ITTLabel labelSHORT_NAME;
        protected ITTLabel labelNAME;
        protected ITTCheckBox ttcheckboxActive;
        override protected void InitializeControls()
        {
            SEQUENCE = (ITTTextBox)AddControl(new Guid("7563fd50-1ced-4c14-a46b-8a9791c0bba8"));
            SHORT_NAME = (ITTTextBox)AddControl(new Guid("12cb4c06-b37e-49d6-8c32-d362dbc235fd"));
            NAME = (ITTTextBox)AddControl(new Guid("34b963b3-7606-4334-b482-9d20d6271535"));
            labelSEQUENCE = (ITTLabel)AddControl(new Guid("b04dccfd-24b9-4d77-84ba-61b0e24e65e7"));
            labelSHORT_NAME = (ITTLabel)AddControl(new Guid("d7266064-7fb4-47e4-add8-1de1020ec969"));
            labelNAME = (ITTLabel)AddControl(new Guid("52a84e2a-558a-47c8-a093-8ce9f47033ee"));
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("bc98cde2-7cee-4a80-b4a2-9491f0d1b06e"));
            base.InitializeControls();
        }

        public LeaveTypeDefinitionForm() : base("LEAVETYPEDEFINITION", "LeaveTypeDefinitionForm")
        {
        }

        protected LeaveTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}