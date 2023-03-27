
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
    public partial class StoneBreakUpRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Taş Kırma
    /// </summary>
        protected TTObjectClasses.StoneBreakUpRequest _StoneBreakUpRequest
        {
            get { return (TTObjectClasses.StoneBreakUpRequest)_ttObject; }
        }

        protected ITTLabel labelMedulaRaporTakipNo;
        protected ITTTextBox MedulaRaporTakipNo;
        protected ITTCheckBox chkDisXXXXXXRaporu;
        protected ITTLabel labelReportEndDate;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTLabel labelReportStartDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTRichTextBoxControl Note;
        protected ITTRichTextBoxControl Symptom;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage StoneBreakUp;
        protected ITTGrid StoneBreakUpProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn PartOfStone;
        protected ITTTextBoxColumn StoneDimension;
        protected ITTTextBoxColumn NumberOfStone;
        protected ITTTextBoxColumn NumberOfProcedure;
        protected ITTEnumComboBoxColumn ZoneOfStone;
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
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox Urgent;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox Sex;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelMedulaRaporTakipNo = (ITTLabel)AddControl(new Guid("a3a4837e-68c8-4be7-a8bf-64bee8103094"));
            MedulaRaporTakipNo = (ITTTextBox)AddControl(new Guid("ca8cac2b-5eb1-4a34-be2b-52017838895a"));
            chkDisXXXXXXRaporu = (ITTCheckBox)AddControl(new Guid("5c1581e0-7b18-4ec3-b25b-2a570e62c756"));
            labelReportEndDate = (ITTLabel)AddControl(new Guid("0a1bea9a-ea02-445f-8e75-3df83ad9397d"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("2471dc03-7768-48fb-9bea-572c81a19a17"));
            labelReportStartDate = (ITTLabel)AddControl(new Guid("7b07a829-abcd-482d-b2b7-73a4d082ae19"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("9051a67b-9e9f-4976-82c0-856a52c065f5"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("99a0f5e1-f628-44cc-adfd-b6d97eceeb8e"));
            Symptom = (ITTRichTextBoxControl)AddControl(new Guid("fab52044-9496-408f-b25d-e4b9759e882e"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("631a9dff-2da4-492e-9612-90d09d63dc67"));
            StoneBreakUp = (ITTTabPage)AddControl(new Guid("b8281807-7464-4dc2-b0fb-a8fe1e202481"));
            StoneBreakUpProcedures = (ITTGrid)AddControl(new Guid("bacad88a-5fe0-468e-a313-1373b12e0475"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("7fa0e1ee-839b-4fa0-bbf9-051928b92025"));
            PartOfStone = (ITTListBoxColumn)AddControl(new Guid("ca080557-38ea-4b21-a2d2-970d8f63734b"));
            StoneDimension = (ITTTextBoxColumn)AddControl(new Guid("56b0fe14-1832-462d-a146-22239d0827ae"));
            NumberOfStone = (ITTTextBoxColumn)AddControl(new Guid("41c1b870-6ba6-4d88-9d88-02a2056609a1"));
            NumberOfProcedure = (ITTTextBoxColumn)AddControl(new Guid("edde6164-b52b-42f1-8850-eef06819fc78"));
            ZoneOfStone = (ITTEnumComboBoxColumn)AddControl(new Guid("abf4b176-5c87-4be0-aa7a-1f922c50acec"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("7667016f-03c0-4c05-b6ba-d687833aaa00"));
            Age = (ITTTextBox)AddControl(new Guid("5e434ee0-b7a2-4411-9d36-3f01abaf9f1e"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("673955bb-776b-48df-8b24-64439047a524"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("28d14146-46f8-4536-84c6-a7cf170b8ccc"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("a6080720-0750-45c0-b268-715042047647"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("5ed0df7e-866f-48b0-a461-1c7897d23535"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9deb4935-ada0-463f-9247-5ee211386038"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f2f3800a-0a00-4eac-8a35-d783cfff48b5"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f4ea7f8f-eac5-4f9c-b772-58224cc0cb17"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("e94efec4-de90-4822-a1ee-5a292911da75"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("a2331ac5-d5ed-4839-9de6-4868cd7e874b"));
            Urgent = (ITTCheckBox)AddControl(new Guid("f67c96fe-ffa8-41ef-87b0-ada115599773"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("88e0fc37-7daa-42a5-bfa0-ff469419d9cc"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("96652693-81ee-4281-aaba-54911c4825fc"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("61b8e8d2-3ed0-4487-89a4-628d26c2c887"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("fcc25fa9-d4bc-45e2-8758-03cdeb00d31f"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("b487a5da-3158-45fc-8c65-e04d5562707a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("458a54bb-7890-43ff-a01e-519f4c40d43a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3091a69b-503c-42e0-b6b4-618946bced2e"));
            base.InitializeControls();
        }

        public StoneBreakUpRequestAcceptionForm() : base("STONEBREAKUPREQUEST", "StoneBreakUpRequestAcceptionForm")
        {
        }

        protected StoneBreakUpRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}