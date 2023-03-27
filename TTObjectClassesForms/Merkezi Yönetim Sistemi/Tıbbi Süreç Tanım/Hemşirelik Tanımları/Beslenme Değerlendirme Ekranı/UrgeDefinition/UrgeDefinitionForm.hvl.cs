
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
    public partial class UrgeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.UrgeDefinition _UrgeDefinition
        {
            get { return (TTObjectClasses.UrgeDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("3559f30b-6f20-4ef4-adc2-1c3932ba4353"));
            Name = (ITTTextBox)AddControl(new Guid("b89f71ec-3a15-48ab-8298-3835c332c5ed"));
            Aktif = (ITTCheckBox)AddControl(new Guid("4fc0c5ac-aa41-4e74-9188-2ebc8c5f6c21"));
            base.InitializeControls();
        }

        public UrgeDefinitionForm() : base("URGEDEFINITION", "UrgeDefinitionForm")
        {
        }

        protected UrgeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}