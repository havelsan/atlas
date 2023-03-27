
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
    public partial class AudiologyDiagnosisForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.AudiologyDiagnosisDef _AudiologyDiagnosisDef
        {
            get { return (TTObjectClasses.AudiologyDiagnosisDef)_ttObject; }
        }

        protected ITTLabel labelDiagnosisName;
        protected ITTTextBox DiagnosisName;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelDiagnosisName = (ITTLabel)AddControl(new Guid("da404cda-ac39-4a44-9a12-8cf316c2cae6"));
            DiagnosisName = (ITTTextBox)AddControl(new Guid("fe6b41d5-cd92-4414-8919-03d97b0f7b3b"));
            Aktif = (ITTCheckBox)AddControl(new Guid("f81756da-5383-41fd-a501-710ffc212de2"));
            base.InitializeControls();
        }

        public AudiologyDiagnosisForm() : base("AUDIOLOGYDIAGNOSISDEF", "AudiologyDiagnosisForm")
        {
        }

        protected AudiologyDiagnosisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}