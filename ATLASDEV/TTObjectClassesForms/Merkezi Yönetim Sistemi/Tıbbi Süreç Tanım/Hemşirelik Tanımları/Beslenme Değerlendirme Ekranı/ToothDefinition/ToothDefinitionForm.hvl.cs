
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
    public partial class ToothDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ToothDefinition _ToothDefinition
        {
            get { return (TTObjectClasses.ToothDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("c074aa6e-308a-4e36-83b9-f49730b1c778"));
            Name = (ITTTextBox)AddControl(new Guid("1d604e9d-4d4f-4069-8202-441b3dd31f53"));
            Aktif = (ITTCheckBox)AddControl(new Guid("fdd440ea-7a01-49e3-82aa-b9238b0ea3e3"));
            base.InitializeControls();
        }

        public ToothDefinitionForm() : base("TOOTHDEFINITION", "ToothDefinitionForm")
        {
        }

        protected ToothDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}