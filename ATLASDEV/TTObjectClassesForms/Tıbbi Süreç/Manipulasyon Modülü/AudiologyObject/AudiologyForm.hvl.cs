
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
    public partial class AudiologyForm : ManipulationFormBaseObjectForm
    {
    /// <summary>
    /// Odyoloji Türünde Manipulasyonların Ortak Objesi
    /// </summary>
        protected TTObjectClasses.AudiologyObject _AudiologyObject
        {
            get { return (TTObjectClasses.AudiologyObject)_ttObject; }
        }

        protected ITTGrid AudiologyDiagnosis;
        protected ITTListBoxColumn AudiologyDiagnosisDefAudiologyDiagnosis;
        protected ITTLabel labelTherapyNote;
        protected ITTTextBox TherapyNote;
        protected ITTTextBox ResultNote;
        protected ITTLabel labelResultNote;
        protected ITTLabel labelAudiologyReport;
        protected ITTRichTextBoxControl AudiologyReport;
        override protected void InitializeControls()
        {
            AudiologyDiagnosis = (ITTGrid)AddControl(new Guid("05aafa5a-34ee-452c-a526-6343fca60801"));
            AudiologyDiagnosisDefAudiologyDiagnosis = (ITTListBoxColumn)AddControl(new Guid("34197190-11e3-4951-ab89-d4439d887dfe"));
            labelTherapyNote = (ITTLabel)AddControl(new Guid("709b8820-1240-4a49-a5a4-38848332bd47"));
            TherapyNote = (ITTTextBox)AddControl(new Guid("22e4892e-07c5-4e60-bfa7-7380795cb26d"));
            ResultNote = (ITTTextBox)AddControl(new Guid("e80f4a5e-b4b6-4111-808f-98bf27e7e95a"));
            labelResultNote = (ITTLabel)AddControl(new Guid("477baaad-2af3-415d-b4bb-674a06641083"));
            labelAudiologyReport = (ITTLabel)AddControl(new Guid("3dda7c5e-ccd6-4ef4-8d48-9fa71a604f64"));
            AudiologyReport = (ITTRichTextBoxControl)AddControl(new Guid("c447e25f-c67c-48df-95d1-266a0011d58f"));
            base.InitializeControls();
        }

        public AudiologyForm() : base("AUDIOLOGYOBJECT", "AudiologyForm")
        {
        }

        protected AudiologyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}