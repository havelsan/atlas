
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
    public partial class StoneBreakUpReturnToReqForm : EpisodeActionForm
    {
    /// <summary>
    /// Taş Kırma
    /// </summary>
        protected TTObjectClasses.StoneBreakUpRequest _StoneBreakUpRequest
        {
            get { return (TTObjectClasses.StoneBreakUpRequest)_ttObject; }
        }

        protected ITTRichTextBoxControl Note;
        protected ITTRichTextBoxControl Symptom;
        protected ITTDateTimePicker ProcessDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage StoneBreakUp;
        protected ITTGrid StoneBreakUpProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn PartOfStone;
        protected ITTTextBoxColumn StoneDimension;
        protected ITTTextBoxColumn NumberOfProcedure;
        protected ITTEnumComboBoxColumn ZoneOfStone;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Age;
        protected ITTTextBox ReasonOfReturn;
        protected ITTLabel labelProcedureDate;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox Urgent;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox Sex;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox Equipment;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelReasonOfReturn;
        override protected void InitializeControls()
        {
            Note = (ITTRichTextBoxControl)AddControl(new Guid("009eaf35-ddc8-407c-8370-da34bd03b207"));
            Symptom = (ITTRichTextBoxControl)AddControl(new Guid("edfb1eab-5630-48df-bcf9-39ae5efbadc6"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("ed13a51e-d219-4d57-b76b-ea56dfbcdf7a"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("3d6b1532-ad53-4f6d-8f34-2d77729f901a"));
            StoneBreakUp = (ITTTabPage)AddControl(new Guid("1495cd2b-2888-494a-a2dc-a31b52e7e254"));
            StoneBreakUpProcedures = (ITTGrid)AddControl(new Guid("5857439f-03f6-4618-9ff2-74e20ddd37b5"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("ff46d566-b547-46b6-b593-ff188d67408e"));
            PartOfStone = (ITTListBoxColumn)AddControl(new Guid("a9c78f03-1409-4d28-a737-c66c1e0809d9"));
            StoneDimension = (ITTTextBoxColumn)AddControl(new Guid("d3852eb0-6e4c-4799-80f3-f5250d423c75"));
            NumberOfProcedure = (ITTTextBoxColumn)AddControl(new Guid("d3af002b-9764-42ba-b1a5-bad74b2d5b85"));
            ZoneOfStone = (ITTEnumComboBoxColumn)AddControl(new Guid("9750308e-77ce-496d-97d9-6d907731ff36"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("8952f4d2-7fb8-45cc-adba-b5751b9cb07a"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("fc5f1a43-24d2-41d1-969c-bc0b1886029e"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("03f9fa08-6c27-4368-b750-7e2e6bf04d2c"));
            Material = (ITTListBoxColumn)AddControl(new Guid("fae9d4ee-29be-4566-9ae9-b6e74a1d357c"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("c9b71234-090f-485d-810d-db113e2dfdb4"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("eedab1a7-cdc3-44cf-b88c-97b2c150b61e"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("09d5d9b6-4a70-46b9-90d8-eff145d61d3f"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("5065bb41-afcd-45a6-8c09-d2ec8f3066cd"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("6bfdb6c1-bfd0-49d9-9745-c6cb775d8df7"));
            Age = (ITTTextBox)AddControl(new Guid("81cabab4-50df-4961-abbc-4fe637cc5f72"));
            ReasonOfReturn = (ITTTextBox)AddControl(new Guid("e1eeb5d8-9d20-4151-a9f0-9f58d143e75d"));
            labelProcedureDate = (ITTLabel)AddControl(new Guid("16efc21a-de16-42ac-b381-260ffc95919a"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("81d3c45c-699a-4530-9f75-e9030fe25397"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("616296e9-6d75-44d4-8ede-5b1312eb5b16"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("771a34dc-b56f-43e9-9bc8-9d6eb0f2bb94"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("6e1fe34a-0ec1-4a68-82c7-ea3df10612f6"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("60d05086-6851-49f3-9aa4-6b46ea69175a"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("58be4806-13fc-4c69-97da-1785e4554a30"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8cffb874-6a8e-4e69-a4da-1f87449f0b81"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("bf235aee-8099-47a2-aae2-7b8a4f6efcf6"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("9d3fc8b4-58e3-4a52-8e71-43d0464a514f"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ca04552e-f2e2-4251-ac76-ca8128e52dab"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("2d313c6c-b4d2-4604-976c-0fde127fcd06"));
            Urgent = (ITTCheckBox)AddControl(new Guid("4eacae9f-b8c8-4bc7-b1c3-cb8ff4dd52d5"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("4de6f7f2-70bd-4465-bd7c-72c3939cafd4"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("e50484c8-4139-4d5f-952c-d114abdd95e4"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("e49b361f-e5b3-45f2-9904-78777fdb448d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5726dcf3-6e9b-4431-83a5-c25e44e02833"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("7992b4a3-f716-494c-8420-73f78eb1a2dd"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4b0b1026-8318-42c4-b707-5b8f40eaf52e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d5bd1ff7-0932-40c8-9322-afaf9ac97823"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("4a2a7f9f-5c03-4cdd-9024-eb71e6ddf78b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("afb0ef8f-6a27-4b7e-9c18-bd0aeb6244d9"));
            labelReasonOfReturn = (ITTLabel)AddControl(new Guid("9918bb66-160d-4337-b369-e6520c4a1017"));
            base.InitializeControls();
        }

        public StoneBreakUpReturnToReqForm() : base("STONEBREAKUPREQUEST", "StoneBreakUpReturnToReqForm")
        {
        }

        protected StoneBreakUpReturnToReqForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}