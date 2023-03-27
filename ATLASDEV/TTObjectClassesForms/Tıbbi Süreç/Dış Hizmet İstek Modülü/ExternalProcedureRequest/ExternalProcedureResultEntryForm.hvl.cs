
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
    /// Dış XXXXXX Hizmet Sonuç Giriş
    /// </summary>
    public partial class ExternalProcedureResultEntryForm : TTForm
    {
    /// <summary>
    /// Dış Hizmet İstek
    /// </summary>
        protected TTObjectClasses.ExternalProcedureRequest _ExternalProcedureRequest
        {
            get { return (TTObjectClasses.ExternalProcedureRequest)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelPreInformation;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel4;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid ProcedureGrid;
        protected ITTListBoxColumn ProcedureDefinition;
        protected ITTTextBoxColumn AccessionNumber;
        protected ITTTextBoxColumn Unit;
        protected ITTTextBoxColumn Result;
        protected ITTEnumComboBoxColumn TreatmentToothPosition;
        protected ITTTextBoxColumn ISBTUnitNumber;
        protected ITTTextBoxColumn ISBTElementCode;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox RequestedExternalHospital;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("99478b7b-3c78-4e8b-936a-c562bc88bf18"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("dcf59736-4e27-4de0-8f85-0b980533f6c4"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("acaece4a-8400-4916-8e8a-17c8f91f683f"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("ab2380ad-85ea-4354-ad6e-5ee2e376ee7f"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("84fe75ea-458b-4237-b754-4f2a7538de23"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("36f5f1e0-55ae-4632-8575-c7d2182b6927"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("415f69af-31cb-4197-a599-40878fc38d29"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3e92dbf1-5f36-475c-bc7f-ddfda90689da"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2eaef5a3-c272-4e78-9f72-550db2aac9db"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("da5d4c4c-6dd8-4626-be38-cfe2c5d3358b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f81a47a9-cf16-4597-b017-db7ead203243"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("dd990a76-7043-4133-8172-8dc9b2b39351"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("d878c941-e7da-4f13-8590-1c18496282c6"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("a55930b0-d67d-4a75-9723-e478634be3c7"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("603d4a2f-2dd5-4554-86a6-8aa7d1434646"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4f058e85-30cd-4aa8-9492-2c84785bc4a4"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b5f49ec2-0328-4fbd-934d-aabb35498fbe"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("211207b4-b821-4458-ab81-cec7b6185d5b"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("f93ae9e3-9266-48b4-b23f-666adaeafd1f"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("68666e03-e79f-4626-a8f4-2af846226e4e"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("10250a61-e2c9-428a-8bc3-2765cf8d787d"));
            ProcedureGrid = (ITTGrid)AddControl(new Guid("a8c5d77c-3551-4de5-bfe3-8a951daab66a"));
            ProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("2f433ee4-f8b9-43c3-b86c-3c29cb00920d"));
            AccessionNumber = (ITTTextBoxColumn)AddControl(new Guid("ec26a0c4-7517-47df-b78f-1335f3ed5728"));
            Unit = (ITTTextBoxColumn)AddControl(new Guid("c2f4793a-75c9-4b37-8a6c-4cdc20f384b4"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("4f1c72e7-6620-4335-98e9-a95e0034c497"));
            TreatmentToothPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("73aae071-e979-48a8-8241-b697e7fc282b"));
            ISBTUnitNumber = (ITTTextBoxColumn)AddControl(new Guid("b97886eb-07ca-4a95-aebb-2b9e4c74705b"));
            ISBTElementCode = (ITTTextBoxColumn)AddControl(new Guid("f783e7f2-2c1a-4e3c-9ca3-afb70ce4b29b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b5883386-f9cc-4893-affc-cfbd4ad50841"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("a2cd5819-cd0f-469a-a7b5-6c8b7b5cfecb"));
            base.InitializeControls();
        }

        public ExternalProcedureResultEntryForm() : base("EXTERNALPROCEDUREREQUEST", "ExternalProcedureResultEntryForm")
        {
        }

        protected ExternalProcedureResultEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}