
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
    public partial class ComplaintDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ComplaintDefinition _ComplaintDefinition
        {
            get { return (TTObjectClasses.ComplaintDefinition)_ttObject; }
        }

        protected ITTLabel labelSpecialityDefinition;
        protected ITTObjectListBox SpecialityDefinition;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelSpecialityDefinition = (ITTLabel)AddControl(new Guid("795fcea5-7a58-47b1-b2db-77f487c65887"));
            SpecialityDefinition = (ITTObjectListBox)AddControl(new Guid("46cac3ce-1c78-4b1b-8322-fe6a49223366"));
            labelDescription = (ITTLabel)AddControl(new Guid("898333ec-2f56-4322-b080-7908102891da"));
            Description = (ITTTextBox)AddControl(new Guid("22dbe969-9175-49a4-9bdb-1ecf323176c4"));
            Name = (ITTTextBox)AddControl(new Guid("426c1714-4aa1-4181-9383-38de554ef53e"));
            labelName = (ITTLabel)AddControl(new Guid("f281e0c8-2ce1-4eac-8d43-6843003d7206"));
            base.InitializeControls();
        }

        public ComplaintDefinitionForm() : base("COMPLAINTDEFINITION", "ComplaintDefinitionForm")
        {
        }

        protected ComplaintDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}