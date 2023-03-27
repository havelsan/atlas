
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
    public partial class PainFrequencyDefinitonForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PainFrequencyDefiniton _PainFrequencyDefiniton
        {
            get { return (TTObjectClasses.PainFrequencyDefiniton)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("a15d4a0d-891d-4994-8bf9-96a177287e4d"));
            Name = (ITTTextBox)AddControl(new Guid("690ba26e-8784-4d01-9aa7-9235aad8bdc4"));
            Aktif = (ITTCheckBox)AddControl(new Guid("9581fffe-19b2-4f99-b4d2-a012a5ccc652"));
            base.InitializeControls();
        }

        public PainFrequencyDefinitonForm() : base("PAINFREQUENCYDEFINITON", "PainFrequencyDefinitonForm")
        {
        }

        protected PainFrequencyDefinitonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}