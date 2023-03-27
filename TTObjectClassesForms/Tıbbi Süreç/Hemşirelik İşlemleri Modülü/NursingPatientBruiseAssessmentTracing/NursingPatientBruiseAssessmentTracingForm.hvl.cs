
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
    /// Hasta Yara Değerlendirme Takip Formu
    /// </summary>
    public partial class NursingPatientBruiseAssessmentTracingForm : TTForm
    {
        protected TTObjectClasses.NursingPatientBruiseAssessmentTracing _NursingPatientBruiseAssessmentTracing
        {
            get { return (TTObjectClasses.NursingPatientBruiseAssessmentTracing)_ttObject; }
        }

        protected ITTLabel labelPatientBruiseAssessmentTracing;
        protected ITTObjectListBox PatientBruiseAssessmentTracing;
        protected ITTLabel labelYellow;
        protected ITTTextBox Yellow;
        protected ITTLabel labelWideness;
        protected ITTTextBox Wideness;
        protected ITTLabel labelStreamQuantitative;
        protected ITTEnumComboBox StreamQuantitative;
        protected ITTLabel labelStreamColour;
        protected ITTTextBox StreamColour;
        protected ITTLabel labelSmell;
        protected ITTEnumComboBox Smell;
        protected ITTLabel labelRed;
        protected ITTTextBox Red;
        protected ITTLabel labelOther;
        protected ITTTextBox Other;
        protected ITTLabel labelLengthiness;
        protected ITTTextBox Lengthiness;
        protected ITTLabel labelDegree;
        protected ITTTextBox Degree;
        protected ITTLabel labelDeepness;
        protected ITTTextBox Deepness;
        protected ITTLabel labelCavity;
        protected ITTTextBox Cavity;
        protected ITTLabel labelBruiseBorders;
        protected ITTEnumComboBox BruiseBorders;
        protected ITTLabel labelBlack;
        protected ITTTextBox Black;
        protected ITTLabel labelAssessment;
        protected ITTTextBox Assessment;
        protected ITTLabel labelActiondate;
        protected ITTDateTimePicker Actiondate;
        override protected void InitializeControls()
        {
            labelPatientBruiseAssessmentTracing = (ITTLabel)AddControl(new Guid("581ec2bd-03d6-4060-bdfc-4837ca754c44"));
            PatientBruiseAssessmentTracing = (ITTObjectListBox)AddControl(new Guid("d9af581f-c9ff-4d7e-8814-c6d411dbc607"));
            labelYellow = (ITTLabel)AddControl(new Guid("2f9e1d3a-d9ee-41f2-bfce-d1446494fe4f"));
            Yellow = (ITTTextBox)AddControl(new Guid("54f329d1-6bef-4a3d-89d6-919de100369a"));
            labelWideness = (ITTLabel)AddControl(new Guid("39b7d080-735a-423c-86b9-9d3cd2a03afc"));
            Wideness = (ITTTextBox)AddControl(new Guid("8924c1da-2b29-4047-a638-565289b887c5"));
            labelStreamQuantitative = (ITTLabel)AddControl(new Guid("3c377277-ac08-4c0f-9f29-6dda41b184d0"));
            StreamQuantitative = (ITTEnumComboBox)AddControl(new Guid("fcdd9c97-a005-40fc-b236-ef01c8b59ed9"));
            labelStreamColour = (ITTLabel)AddControl(new Guid("5c8d623b-c29f-48d1-a50e-237bdf3b54de"));
            StreamColour = (ITTTextBox)AddControl(new Guid("899e63c2-50b9-4599-9896-19a890695ad0"));
            labelSmell = (ITTLabel)AddControl(new Guid("f7a7c1ef-5ed1-477d-b4fc-971cdad2d116"));
            Smell = (ITTEnumComboBox)AddControl(new Guid("24fac2d7-5ce0-41cd-8689-ff4ef2638b72"));
            labelRed = (ITTLabel)AddControl(new Guid("7532263e-e906-45ee-ac84-faf87be590ee"));
            Red = (ITTTextBox)AddControl(new Guid("3548b283-c15c-4765-96ee-8696f9d13cc9"));
            labelOther = (ITTLabel)AddControl(new Guid("040fc7cb-d3a5-4c24-b88b-4437afcad48e"));
            Other = (ITTTextBox)AddControl(new Guid("11b91388-e780-4501-8929-18484a69e2fc"));
            labelLengthiness = (ITTLabel)AddControl(new Guid("8c86d271-5e88-4df0-8d47-5d0de9a3c20a"));
            Lengthiness = (ITTTextBox)AddControl(new Guid("364dcfc2-dc47-4b2d-b445-3260d4807fab"));
            labelDegree = (ITTLabel)AddControl(new Guid("139d9b94-11a9-4dac-a301-22d4a6d52d3d"));
            Degree = (ITTTextBox)AddControl(new Guid("cced8893-9452-416c-99b5-8e306aa5113a"));
            labelDeepness = (ITTLabel)AddControl(new Guid("3f5288b6-1569-4422-aabf-1e8591a71baf"));
            Deepness = (ITTTextBox)AddControl(new Guid("04d967f7-f4a4-49de-ac8b-fc9e114ac956"));
            labelCavity = (ITTLabel)AddControl(new Guid("63a9b252-aa3f-43f5-add1-b70aefe1d3fb"));
            Cavity = (ITTTextBox)AddControl(new Guid("42cf22c1-5681-455e-8132-ef7be71aa653"));
            labelBruiseBorders = (ITTLabel)AddControl(new Guid("a46c7204-b3f1-4040-a64f-74ce45a9cd05"));
            BruiseBorders = (ITTEnumComboBox)AddControl(new Guid("3e55aaf1-a06e-467d-b59f-946c65614173"));
            labelBlack = (ITTLabel)AddControl(new Guid("1bebc33c-9e92-44b2-aca3-74fe0f60ddf0"));
            Black = (ITTTextBox)AddControl(new Guid("1019bd11-1276-42a6-af9d-f9fdb1883a86"));
            labelAssessment = (ITTLabel)AddControl(new Guid("be109b6e-8adf-4fca-95ae-9abe3840dcc4"));
            Assessment = (ITTTextBox)AddControl(new Guid("2c60c005-0419-4ca5-8aa0-6f9a24ec328b"));
            labelActiondate = (ITTLabel)AddControl(new Guid("8ad89f22-80ff-4d08-90c2-d32dc08d19d6"));
            Actiondate = (ITTDateTimePicker)AddControl(new Guid("1ec00856-a940-492e-abaf-28c1b3b91d39"));
            base.InitializeControls();
        }

        public NursingPatientBruiseAssessmentTracingForm() : base("NURSINGPATIENTBRUISEASSESSMENTTRACING", "NursingPatientBruiseAssessmentTracingForm")
        {
        }

        protected NursingPatientBruiseAssessmentTracingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}