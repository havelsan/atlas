
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
    public partial class TitleDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.TitleDefinition _TitleDefinition
        {
            get { return (TTObjectClasses.TitleDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelDESCRIPTION;
        protected ITTTextBox DESCRIPTION;
        protected ITTTextBox SEQUENCE;
        protected ITTTextBox NAME;
        protected ITTLabel labelSEQUENCE;
        protected ITTLabel labelNAME;
        override protected void InitializeControls()
        {
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("31eee3b0-8293-4960-a681-c15e2a7c6228"));
            labelDESCRIPTION = (ITTLabel)AddControl(new Guid("235f0007-585d-42c9-a170-a20c58422e7f"));
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("73f20f40-c9ec-4acf-a251-146205dac4dd"));
            SEQUENCE = (ITTTextBox)AddControl(new Guid("984ebaf9-6f09-4ff0-9a16-67c84ca84a32"));
            NAME = (ITTTextBox)AddControl(new Guid("0aec5eba-5c0c-4d94-8e50-d50c4a83e6df"));
            labelSEQUENCE = (ITTLabel)AddControl(new Guid("8b4f3e67-6db5-4eef-905f-655db2b3a57a"));
            labelNAME = (ITTLabel)AddControl(new Guid("0e725f37-492a-4055-98bf-15c85387dd54"));
            base.InitializeControls();
        }

        public TitleDefinitionForm() : base("TITLEDEFINITION", "TitleDefinitionForm")
        {
        }

        protected TitleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}