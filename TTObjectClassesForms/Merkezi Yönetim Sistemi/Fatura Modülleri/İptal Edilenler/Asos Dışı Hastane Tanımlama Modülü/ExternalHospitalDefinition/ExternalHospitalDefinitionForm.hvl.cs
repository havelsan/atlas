
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
    /// XXXXXX Dışı XXXXXX Tanımlama
    /// </summary>
    public partial class ExternalHospitalDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Dış XXXXXX Tanımlama
    /// </summary>
        protected TTObjectClasses.ExternalHospitalDefinition _ExternalHospitalDefinition
        {
            get { return (TTObjectClasses.ExternalHospitalDefinition)_ttObject; }
        }

        protected ITTLabel labelLinkedCity;
        protected ITTObjectListBox LinkedCity;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox HOSPITALID;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelID;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            labelLinkedCity = (ITTLabel)AddControl(new Guid("ccf267e3-8c25-465f-a6b9-248f101ca4e9"));
            LinkedCity = (ITTObjectListBox)AddControl(new Guid("57ba8d04-2284-49a5-aa63-77749bb3e3a3"));
            IsActive = (ITTCheckBox)AddControl(new Guid("d2e29e4c-dd56-41d1-91ef-12a57e2a6e81"));
            labelName = (ITTLabel)AddControl(new Guid("c229647b-9ffc-4689-87a6-dd2b515dda27"));
            Name = (ITTTextBox)AddControl(new Guid("e3bd7b02-10c9-40e1-bc6c-275e38c88ce3"));
            HOSPITALID = (ITTTextBox)AddControl(new Guid("30f73143-8852-4bb9-a8ef-09a69e091f1a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0fc9f7c1-4f8c-453b-8d40-abe4055bc16a"));
            labelID = (ITTLabel)AddControl(new Guid("fb48061f-918f-45bf-b738-71653dbf7323"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b9649ed6-ee6b-4543-b420-fe43f58117a8"));
            base.InitializeControls();
        }

        public ExternalHospitalDefinitionForm() : base("EXTERNALHOSPITALDEFINITION", "ExternalHospitalDefinitionForm")
        {
        }

        protected ExternalHospitalDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}