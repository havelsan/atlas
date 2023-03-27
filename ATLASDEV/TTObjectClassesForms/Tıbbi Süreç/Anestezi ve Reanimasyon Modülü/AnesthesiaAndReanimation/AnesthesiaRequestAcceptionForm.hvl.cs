
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
    /// Anestezi ve Reanimasyon
    /// </summary>
    public partial class AnesthesiaRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation
        {
            get { return (TTObjectClasses.AnesthesiaAndReanimation)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel1;
        protected ITTRichTextBoxControl ttrichtextboxcontrolConsultationNote;
        protected ITTGrid RequestedProcedure;
        protected ITTListBoxColumn Procedure;
        protected ITTLabel LabelRequest;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox RequestNote;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelRequestNote;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelASAType;
        protected ITTEnumComboBox ASAType;
        protected ITTCheckBox ApprovalFormGiven;
        protected ITTGrid GridSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTRichTextBoxControlColumn DescriptionOfObj;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("d9c336a3-8081-4ca7-9928-2913402c89a2"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("9ff3fa50-0d93-4cc5-bda3-e2ea37eec211"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a99f9dae-58ef-487d-8bf2-0e2e110ee875"));
            ttrichtextboxcontrolConsultationNote = (ITTRichTextBoxControl)AddControl(new Guid("f56d05b8-a9aa-4bc7-9a62-638580c7192f"));
            RequestedProcedure = (ITTGrid)AddControl(new Guid("da939e39-cf54-42fd-8a77-edad1b75ff9d"));
            Procedure = (ITTListBoxColumn)AddControl(new Guid("ec841db8-3e0a-4b12-acdb-223858fee3cd"));
            LabelRequest = (ITTLabel)AddControl(new Guid("0453c6eb-3226-45a2-9f27-7f976f4ba982"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("aef0ea62-8360-48e8-a5a6-44337681266f"));
            RequestNote = (ITTTextBox)AddControl(new Guid("a3fcfda1-7655-4a08-b2a5-e674033bcc59"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c12b6992-c926-496d-8394-e2335a8e35cd"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("7eb6690f-38b3-4c3b-bc1c-d20f51536c05"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("fe771ffe-269b-40a1-8403-017f83be7d25"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e7dfe5c4-7e9c-41fc-a2e5-6374ffeaeb25"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f9eb90d6-eb4d-4265-bb56-117432c3c553"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("4ffda8df-0237-48b3-a306-7db784aaa809"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d16fac5a-0dd8-48df-a939-0a5b8a74af5b"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("004abc29-a058-47f0-bc08-731444a97241"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e64b0f90-2c2a-4aed-b6a9-8cc74285112a"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("b07f0478-80ac-4288-b392-244422730bde"));
            labelRequestNote = (ITTLabel)AddControl(new Guid("27851f06-3f77-49db-9b2b-ba73a03b5ebb"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("e96188c0-be05-41d4-82c4-272254baf1c6"));
            labelASAType = (ITTLabel)AddControl(new Guid("7d3bd04d-bac3-4461-9ec3-0234efc0254c"));
            ASAType = (ITTEnumComboBox)AddControl(new Guid("b315df92-0406-4d5f-a628-2407e5d28957"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("8acad6ff-52cc-4dfe-8768-21a0b2f8950d"));
            GridSurgeryProcedures = (ITTGrid)AddControl(new Guid("4f9e4a6f-28f4-4b03-b5c9-03807992682f"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("8b2d0938-bda2-40e5-b589-d6ca059b849e"));
            DescriptionOfObj = (ITTRichTextBoxControlColumn)AddControl(new Guid("f752f4f6-8b23-44ae-8dbc-0a788520e118"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("312fa3ba-5992-4294-b5b6-44d48651a20e"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("e89eca0d-3a8a-4b69-ad2e-0c031c375ecf"));
            base.InitializeControls();
        }

        public AnesthesiaRequestAcceptionForm() : base("ANESTHESIAANDREANIMATION", "AnesthesiaRequestAcceptionForm")
        {
        }

        protected AnesthesiaRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}