
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
    /// Karantina Tanımı
    /// </summary>
    public partial class QuarantineDefinitionForm : TTForm
    {
    /// <summary>
    /// Karantina
    /// </summary>
        protected TTObjectClasses.ResQuarantine _ResQuarantine
        {
            get { return (TTObjectClasses.ResQuarantine)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelStore;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("1e51487b-d88d-4ca7-8cbd-3af50fb1e505"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("94da49d6-12d6-41bb-8e86-3684b81a8a66"));
            Location = (ITTTextBox)AddControl(new Guid("f7c25c2c-32c7-4905-a13c-f24413676b26"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("f4c682c5-9d0d-4c42-ba58-16aac8128695"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("30a6f113-fab3-48f0-beba-d324f079a7ee"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9b7859e4-9788-4e7f-a340-08c6cc1c00be"));
            labelStore = (ITTLabel)AddControl(new Guid("3f032c97-a861-4391-ad7f-634d1b936cc5"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("a82432d8-54dd-4ac3-8cac-91d5ece17cda"));
            Store = (ITTObjectListBox)AddControl(new Guid("b989ce6b-dc8a-41ad-a5ac-13e556362e58"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("4881ac5f-76c9-47bd-b393-d2e36c3a3f56"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("9e3fcd7a-d36e-448d-97e1-b6e9ec5bb241"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c8004beb-41c9-4665-a994-690aee8e1852"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("da7f84c3-a687-4f40-a654-b88c3b3ae336"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("7280fdad-3a93-4474-b43e-68672bf27595"));
            labelLocation = (ITTLabel)AddControl(new Guid("7a438f78-534a-4250-a837-c366375a0395"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("e1969700-7158-401f-b813-f4cdfd2fcea8"));
            base.InitializeControls();
        }

        public QuarantineDefinitionForm() : base("RESQUARANTINE", "QuarantineDefinitionForm")
        {
        }

        protected QuarantineDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}