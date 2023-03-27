
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
    /// Taş Kırma
    /// </summary>
    public partial class StoneBreakUpResultEntryForm : EpisodeActionForm
    {
    /// <summary>
    /// Taş Kırma
    /// </summary>
        protected TTObjectClasses.StoneBreakUpRequest _StoneBreakUpRequest
        {
            get { return (TTObjectClasses.StoneBreakUpRequest)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTRichTextBoxControl Note;
        protected ITTRichTextBoxControl Symptom;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage StoneBreakUp;
        protected ITTGrid StoneBreakUpProcedures;
        protected ITTDateTimePickerColumn ProcedureActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn PartOfStone;
        protected ITTTextBoxColumn StoneDimension;
        protected ITTTextBoxColumn NumberOfProcedure;
        protected ITTEnumComboBoxColumn ZoneOfStone;
        protected ITTListBoxColumn Performer;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Age;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelProcedureDate;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox Urgent;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox Sex;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel1;
        protected ITTRichTextBoxControl RadiologyInformation;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("e48b6bcb-f13b-4274-a9a6-fcbb31d04f27"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("4c570863-faa0-41cf-a55e-e90a0b6578b0"));
            Symptom = (ITTRichTextBoxControl)AddControl(new Guid("deaf982e-a2cf-428a-af43-1ef2e0760806"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("a16a2a9e-18f3-443a-8166-f6aa4f887d34"));
            StoneBreakUp = (ITTTabPage)AddControl(new Guid("0ebc7915-f2cf-4a48-bd81-0192d8cac175"));
            StoneBreakUpProcedures = (ITTGrid)AddControl(new Guid("80868fa2-73a4-4bdf-8535-326863ddc6d4"));
            ProcedureActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("def0317a-5d8b-41a9-98f3-2bfdfa9a9b3a"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e3a35181-ef59-456f-90de-6c1b46ab1023"));
            PartOfStone = (ITTListBoxColumn)AddControl(new Guid("15fee0f2-3ebf-4928-ac06-5a86bea44094"));
            StoneDimension = (ITTTextBoxColumn)AddControl(new Guid("eccd7159-cf54-42b3-82ff-fac4cfb82975"));
            NumberOfProcedure = (ITTTextBoxColumn)AddControl(new Guid("482aefb2-a837-497d-81f5-8b09f93f6487"));
            ZoneOfStone = (ITTEnumComboBoxColumn)AddControl(new Guid("241462cf-0878-45b1-b573-cef66f84ef2a"));
            Performer = (ITTListBoxColumn)AddControl(new Guid("5499e68f-678b-4fdb-b544-d68649657b31"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("3f71de2a-ffd1-4dc4-8830-02a61be26120"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("d4bdce06-22d8-41df-b4c1-fcd874b4562b"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("6de4b4ce-f53c-4410-a185-d1757c9b2095"));
            Material = (ITTListBoxColumn)AddControl(new Guid("4c407886-7180-4fb8-a000-a5a2c01ac7b2"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("0953934a-2f87-45b0-bb7e-e3fd3d3881c2"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("41d40bbc-8ad5-4e7b-85ad-9d52135fed46"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("30d44d66-2c41-40d7-a09d-257dbcb2dc40"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("892e3733-8c58-48ee-9e18-20b4d174606d"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("7f9a4ea8-f473-4957-8357-dee58f604ddb"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("4915c4d7-8540-4a31-a108-62793116e0f0"));
            Age = (ITTTextBox)AddControl(new Guid("ccc2f50a-c716-4107-82b9-b093f67c541a"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("0a9c0a45-a86d-479a-9aa9-b3151b5cd202"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("652e6026-618a-43f7-9b0b-1070055b71a1"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("22650c71-7808-44da-80de-f4d7dea265e7"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("7794305c-47e4-44fd-9a1b-a666a3a71288"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8dc901c3-2b3e-4f72-9510-a91b19884456"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("542b1d5c-3019-41d0-a844-5b896d03856b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4a69a4e7-757a-4dac-b367-8ec6a3a45b28"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("70375326-051e-4274-b63a-c5d14bf16a0c"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("b46cf835-3f3b-4d5d-95ec-b77c430bc78c"));
            labelProcedureDate = (ITTLabel)AddControl(new Guid("3e87b940-d638-426c-a477-e798d245b5cc"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("bb22150a-dbb8-4c69-a97d-3f367bd3e75b"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("443aaebc-0a9b-445a-9423-97103c18ee0f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ac82cf96-dabb-4c2d-b199-155c1aaf148f"));
            Urgent = (ITTCheckBox)AddControl(new Guid("b49bcacc-a094-4d68-a0df-104e41c8240b"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("8c1490bc-db62-4d7a-8489-6abd1a638725"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("2dba0ab6-699b-4c43-9f75-caebcc82c7cf"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("582f308c-3310-4828-aeb3-7976674c2813"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cc283cb5-3549-4eaa-b309-6d92c3ffd0fd"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("7de21446-1879-421a-88bb-608f40786d6a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3c302a1d-1817-4d61-a6d4-6adf42aadd86"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("789b76ea-3b9c-4b70-95d6-96407073486b"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("bd1509f2-af45-49d8-9643-8d8ea6f06950"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d5589af7-3674-4340-a2ae-c722fdf17097"));
            RadiologyInformation = (ITTRichTextBoxControl)AddControl(new Guid("368b94ef-6756-42b7-9085-c89c14a2a411"));
            base.InitializeControls();
        }

        public StoneBreakUpResultEntryForm() : base("STONEBREAKUPREQUEST", "StoneBreakUpResultEntryForm")
        {
        }

        protected StoneBreakUpResultEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}