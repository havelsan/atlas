
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
    public partial class SharedMissionDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SharedMissionDefinition _SharedMissionDefinition
        {
            get { return (TTObjectClasses.SharedMissionDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelNAME;
        protected ITTTextBox NAME;
        override protected void InitializeControls()
        {
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("c8ce52c7-5e3a-4d18-aa73-6bd4485c6b38"));
            labelNAME = (ITTLabel)AddControl(new Guid("8862964b-9e49-4e01-8608-58a8165940d0"));
            NAME = (ITTTextBox)AddControl(new Guid("c87af6b0-8fd8-435f-9435-3c27f7f60ad7"));
            base.InitializeControls();
        }

        public SharedMissionDefinitionForm() : base("SHAREDMISSIONDEFINITION", "SharedMissionDefinitionForm")
        {
        }

        protected SharedMissionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}