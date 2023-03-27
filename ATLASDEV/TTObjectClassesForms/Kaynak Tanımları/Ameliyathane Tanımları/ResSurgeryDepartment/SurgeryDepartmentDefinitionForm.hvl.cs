
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
    /// Ameliyathane Tanımı
    /// </summary>
    public partial class SurgeryDepartmentDefinitionForm : TTForm
    {
    /// <summary>
    /// Ameliyathane
    /// </summary>
        protected TTObjectClasses.ResSurgeryDepartment _ResSurgeryDepartment
        {
            get { return (TTObjectClasses.ResSurgeryDepartment)_ttObject; }
        }

        protected ITTLabel labelStore;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            labelStore = (ITTLabel)AddControl(new Guid("996ca617-6a5c-4042-b7be-2d160955fb86"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e9198774-1a31-492a-bca7-5a74bcfec907"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("a382d565-cf83-4243-8c82-6a41378f4265"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8f87c3c4-af56-4fe8-93e5-42df5bc48d69"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f901f737-ce6c-42ec-a842-edc774b641ef"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("75b35094-b5a0-41ed-99f8-770d99b3b4c1"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("1ffb5488-52ec-4db9-ab18-aac83532954b"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("a58474d8-9d7f-4dfb-89b8-3efed9c0619f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2806bbba-0858-414c-8af0-56eb37b453e1"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("2f667e20-fba0-41be-9dea-e0378784f0c4"));
            Store = (ITTObjectListBox)AddControl(new Guid("c24e6437-de44-4fad-bed3-947a55a48643"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("ae192eb9-bc75-452c-9125-ee37e2514973"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("56a6237f-0f83-49eb-9266-af98878d499e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cf97bb49-3f13-46f0-b6b1-1d573e535fbc"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a341cca5-427d-4aa0-93b1-315e6372118b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d07b9334-1544-4c86-8d4f-cd909abde4ec"));
            base.InitializeControls();
        }

        public SurgeryDepartmentDefinitionForm() : base("RESSURGERYDEPARTMENT", "SurgeryDepartmentDefinitionForm")
        {
        }

        protected SurgeryDepartmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}