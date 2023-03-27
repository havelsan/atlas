
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
    public partial class SystemInterrogationDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SystemInterrogationDefinition _SystemInterrogationDefinition
        {
            get { return (TTObjectClasses.SystemInterrogationDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelActivityGroup;
        protected ITTEnumComboBox ActivityGroup;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("399947a4-5cb3-4d71-9355-8b2da41174e7"));
            Name = (ITTTextBox)AddControl(new Guid("69f1c098-62de-4ad6-adef-ad4dc5fea48b"));
            labelActivityGroup = (ITTLabel)AddControl(new Guid("0d651ad1-55e0-484b-8075-991cf2705d23"));
            ActivityGroup = (ITTEnumComboBox)AddControl(new Guid("297e7262-9395-4286-97ae-72b9aeffc833"));
            Aktif = (ITTCheckBox)AddControl(new Guid("14f9dd08-e580-4e65-9f75-929397b3e52d"));
            base.InitializeControls();
        }

        public SystemInterrogationDefinitionForm() : base("SYSTEMINTERROGATIONDEFINITION", "SystemInterrogationDefinitionForm")
        {
        }

        protected SystemInterrogationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}