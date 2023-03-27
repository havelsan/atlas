
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
    public partial class SwallowDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SwallowDefinition _SwallowDefinition
        {
            get { return (TTObjectClasses.SwallowDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("d6a4aa57-cbc0-458f-a430-204e51d696a3"));
            Name = (ITTTextBox)AddControl(new Guid("90b43c6c-3721-44b0-a0f6-3b0eddc59eb1"));
            Aktif = (ITTCheckBox)AddControl(new Guid("7782ef5c-6838-45bc-a8c2-eaef102583ad"));
            base.InitializeControls();
        }

        public SwallowDefinitionForm() : base("SWALLOWDEFINITION", "SwallowDefinitionForm")
        {
        }

        protected SwallowDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}