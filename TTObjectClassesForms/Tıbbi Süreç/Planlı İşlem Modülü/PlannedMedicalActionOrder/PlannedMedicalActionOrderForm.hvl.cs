
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
    public partial class PlannedMedicalActionOrderForm : BasePlannedMedicalActionOrderForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem Emri
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionOrder _PlannedMedicalActionOrder
        {
            get { return (TTObjectClasses.PlannedMedicalActionOrder)_ttObject; }
        }

        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Amount;
        protected ITTTextBox ApplicationArea;
        protected ITTTextBox Duration;
        protected ITTTextBox OrderNote;
        protected ITTTextBox TreatmentProperties;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelProtocolNo;
        protected ITTLabel labelAbortRequestDescription;
        protected ITTRichTextBoxControl AbortRequestDescription;
        protected ITTRichTextBoxControl DoctorReturnDescription;
        protected ITTLabel labelDoctorReturnDescription;
        protected ITTRichTextBoxControl templateRTF;
        protected ITTButton btnContinue;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTLabel labelOrderNote;
        protected ITTLabel labelTreatmentProperties;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelDuration;
        protected ITTObjectListBox ProcedureObject;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProcedureObject;
        protected ITTGrid OrderDetails;
        protected ITTCheckBoxColumn DEmergency;
        protected ITTDateTimePickerColumn DWorkListDate;
        protected ITTDateTimePickerColumn DActionDate;
        protected ITTListBoxColumn DProcedureObject;
        protected ITTRichTextBoxControlColumn DNote;
        protected ITTListBoxColumn DProcedureDoctor;
        protected ITTStateComboBoxColumn CState;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTListBoxColumn DrAnesteziTescilNo;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentUnit;
        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTLabel labelOrderUser;
        protected ITTObjectListBox OrderProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        override protected void InitializeControls()
        {
            ProtocolNo = (ITTTextBox)AddControl(new Guid("2d702be0-2d94-4f99-bf32-11c02a9fed33"));
            Amount = (ITTTextBox)AddControl(new Guid("7c33fd0a-74d2-4c02-8f51-37448bc2efb8"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("98a84600-5b5b-48be-95c4-bbe322a5676d"));
            Duration = (ITTTextBox)AddControl(new Guid("600bea94-e357-4784-9420-2aa1e4393415"));
            OrderNote = (ITTTextBox)AddControl(new Guid("2a988b91-bbc2-44fb-a49f-0fee6d5f8bd7"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("34f61890-0ec0-459c-9bcd-914314f68a59"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6ff42df7-7086-4294-996d-07a7cac35118"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("fa295702-b25a-487d-91fa-28ea09c8cddb"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("da320a8e-5d07-4873-a409-cb89b54d96f3"));
            labelAbortRequestDescription = (ITTLabel)AddControl(new Guid("30d0bd80-0077-44cc-87aa-b1b5f8d6c359"));
            AbortRequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("20085f53-5e65-4099-a5ee-d1276f2d9ef0"));
            DoctorReturnDescription = (ITTRichTextBoxControl)AddControl(new Guid("92506d75-777b-4051-8f53-391150dbc1b3"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("5aaaa453-6cfa-4c5a-a130-063631941f2f"));
            templateRTF = (ITTRichTextBoxControl)AddControl(new Guid("73d48f4e-c57c-4329-9832-dd77f7438676"));
            btnContinue = (ITTButton)AddControl(new Guid("192bde74-ad70-45df-a0c7-dfbfdb304591"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("dbec6141-0de4-45f9-8a3a-acc2e3b8f766"));
            labelOrderNote = (ITTLabel)AddControl(new Guid("9675c715-b9a7-43a3-9f08-f965cac218b4"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("ce7ad403-b689-4eb5-963c-4960ab3af4bb"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("a23614c2-3f64-4ad8-a061-936a30d5f904"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f4fd907f-c25b-44a4-b0db-63bd508dd7f6"));
            labelDuration = (ITTLabel)AddControl(new Guid("e29e94cc-5e3b-40ec-a902-bca936184ab0"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("bab28f7a-419a-49c5-97f7-24bbb356bc04"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("b9f92739-ea88-47f5-935d-1178a819f98f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c6882a11-c1f3-43c3-b355-e434287b6362"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("be598b3a-b469-4f97-93aa-27c95dc70929"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("bb56a7a4-065c-4a4e-9287-397bcad6ff3a"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("143f4713-a556-4faf-beeb-b20cd9d7893e"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c898d3ac-c5e6-46c8-868a-98510e365962"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5e25d9ad-39a9-42f2-83ae-1c01d9662c4f"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("97fa23da-adf0-4c23-835f-07e91133b361"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("9855186d-ec3a-4c9b-9d34-5e4875931b46"));
            OrderDetails = (ITTGrid)AddControl(new Guid("64c212cb-10f8-459d-be59-578daaebe628"));
            DEmergency = (ITTCheckBoxColumn)AddControl(new Guid("85e234bb-47d7-4cb7-88ac-64a9555b687d"));
            DWorkListDate = (ITTDateTimePickerColumn)AddControl(new Guid("2acd5de0-66f0-4759-94b6-7bb4024760b7"));
            DActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("f17db5f8-f1a6-4237-950c-218c99007739"));
            DProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0967d458-3bd3-4191-a5cb-bb704da8ed8b"));
            DNote = (ITTRichTextBoxControlColumn)AddControl(new Guid("aea34bf6-8ee4-4369-bc2a-935c609e87b8"));
            DProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("8a7c02fa-184c-4628-a3fb-3021815168c2"));
            CState = (ITTStateComboBoxColumn)AddControl(new Guid("82349fa9-7603-41dc-b5a6-d5e976fb101b"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("20f59763-b09e-458e-905c-505529981f08"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("7a054d86-05c7-4ddf-8d7c-59ceaac00c65"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("33601aa3-f325-410b-81a1-45579cfcf38d"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("ca14285b-1db7-4b86-81ce-434a502031f4"));
            DrAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("6912ac8b-d934-46d2-8af6-ba1766469134"));
            labelActionDate = (ITTLabel)AddControl(new Guid("048105bc-374d-48aa-bc15-0dc165447dc9"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b80c4195-49a4-47e5-a7eb-ec1199013065"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("364fd9d9-1203-4bbe-a08f-36c2f952d7ea"));
            TreatmentUnit = (ITTObjectListBox)AddControl(new Guid("7203079c-183d-447c-9751-c2df7133d614"));
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("2d9ef1c9-b232-47eb-b81a-5d2fa1a404a1"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("5065baeb-2601-4bf2-8a21-c9a36616103d"));
            labelOrderUser = (ITTLabel)AddControl(new Guid("a030d72e-8078-41fe-a3aa-ef5534f27afb"));
            OrderProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("0069d86e-d96b-478c-80c5-695c34d618f9"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("90914a1c-9bae-4ed7-aaf3-0b957d60da87"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("31e972e9-6957-410c-a205-0733430428ff"));
            base.InitializeControls();
        }

        public PlannedMedicalActionOrderForm() : base("PLANNEDMEDICALACTIONORDER", "PlannedMedicalActionOrderForm")
        {
        }

        protected PlannedMedicalActionOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}