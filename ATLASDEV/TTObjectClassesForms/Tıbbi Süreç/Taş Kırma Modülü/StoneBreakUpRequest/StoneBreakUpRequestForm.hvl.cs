
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
    public partial class StoneBreakUpRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Taş Kırma
    /// </summary>
        protected TTObjectClasses.StoneBreakUpRequest _StoneBreakUpRequest
        {
            get { return (TTObjectClasses.StoneBreakUpRequest)_ttObject; }
        }

        protected ITTLabel lblRaporBilgileri;
        protected ITTTextBox MedulaRaporBilgileri;
        protected ITTTextBox MedulaRaporTakipNo;
        protected ITTLabel labelMedulaRaporTakipNo;
        protected ITTCheckBox chkRaporuVar;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTRichTextBoxControl Note;
        protected ITTRichTextBoxControl Symptom;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage StoneBreakUp;
        protected ITTGrid StoneBreakUpProcedures;
        protected ITTListBoxColumn PartOfStone;
        protected ITTTextBoxColumn StoneDimension;
        protected ITTTextBoxColumn NumberOfStone;
        protected ITTEnumComboBoxColumn ZoneOfStone;
        protected ITTListBoxColumn Performer;
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
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox Sex;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox ApprovalFormGiven;
        override protected void InitializeControls()
        {
            lblRaporBilgileri = (ITTLabel)AddControl(new Guid("cdc55627-74e1-4fcd-908b-fc0413e690a0"));
            MedulaRaporBilgileri = (ITTTextBox)AddControl(new Guid("1e2a2cef-2f8b-4862-bd79-bcf03cb6e60f"));
            MedulaRaporTakipNo = (ITTTextBox)AddControl(new Guid("3b23338b-cf80-4dda-ad24-14258ed1c11a"));
            labelMedulaRaporTakipNo = (ITTLabel)AddControl(new Guid("129c43a7-4c90-4f0d-9e86-edbaaaa62979"));
            chkRaporuVar = (ITTCheckBox)AddControl(new Guid("97a23832-83fe-4980-a420-966cff3ed0d2"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("57f4ce4f-5ec9-4cdd-a219-f5e7b7291a42"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("8d891834-8781-42ba-86a3-c154240b8ed3"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("b6050397-a5f2-414d-88ad-60cded1d07e9"));
            Symptom = (ITTRichTextBoxControl)AddControl(new Guid("a6fb67b4-0d68-4558-bac7-346b73307dce"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("d6abe0c6-81be-4ba8-9419-0054a4563527"));
            StoneBreakUp = (ITTTabPage)AddControl(new Guid("a5b00cfc-63f1-4509-a15b-c57343140c98"));
            StoneBreakUpProcedures = (ITTGrid)AddControl(new Guid("20b8ba03-ee83-478a-aa83-2ca88c6e5ee9"));
            PartOfStone = (ITTListBoxColumn)AddControl(new Guid("aa430c81-1c5b-42c8-9314-cbad5ff2da7f"));
            StoneDimension = (ITTTextBoxColumn)AddControl(new Guid("e6a85731-d298-4a0f-be60-df29c5caa6a4"));
            NumberOfStone = (ITTTextBoxColumn)AddControl(new Guid("886af25e-f763-4813-a1b0-b011b21f862e"));
            ZoneOfStone = (ITTEnumComboBoxColumn)AddControl(new Guid("32ac73f8-6566-4428-a94e-27794271c30c"));
            Performer = (ITTListBoxColumn)AddControl(new Guid("329d14a3-f2d8-4b71-809f-90d935b0eb3e"));
            Age = (ITTTextBox)AddControl(new Guid("320eaeb6-765b-46b5-ae4e-d5a5a8da3c4f"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("7b16f1b8-dac7-416c-b017-4c20518a45fc"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("5f9a5b9e-0452-4cc7-8f0e-0accfded28ad"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("771f6a67-c023-4269-9c70-45a6b79dd179"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("8cdaa158-2f13-4a36-a58f-0beb1fa084cf"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b121d18e-daaa-4264-9dba-8c35e90d2681"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f7b00d55-c54d-409c-a10d-c96bb3f30d34"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("756abe20-a946-4727-aabe-c4422d2891b0"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("89e9c37c-0b0c-48ad-bb57-1fff35aa75e1"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ea543ac2-86b7-4b46-80ac-a8c34677a52a"));
            Urgent = (ITTCheckBox)AddControl(new Guid("a7997de6-aa26-40bf-a2e7-9c2c38f3ba8d"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("56c4f1e6-045d-4001-96f6-59ea8c4f853c"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("a80b7c61-eefa-4b14-8e0a-7299135c1b43"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("85787a93-1715-4740-b618-42423ad3587d"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("6543591e-bdb4-485c-adc2-e36e92ee4865"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("661e8f90-975d-49d3-a198-29e7aa861468"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bc9bf31c-604e-4e7f-bb02-868bf282dd56"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("ac42e1f7-7035-4480-835c-f4b46af75e04"));
            base.InitializeControls();
        }

        public StoneBreakUpRequestForm() : base("STONEBREAKUPREQUEST", "StoneBreakUpRequestForm")
        {
        }

        protected StoneBreakUpRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}