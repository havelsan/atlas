
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
    /// Hiperbarik Oksijen Tedavisi İstek
    /// </summary>
    public partial class HyperbarikOxygenTreatmentForm : EpisodeActionForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavisi İstek
    /// </summary>
        protected TTObjectClasses.HyperbarikOxygenTreatmentRequest _HyperbarikOxygenTreatmentRequest
        {
            get { return (TTObjectClasses.HyperbarikOxygenTreatmentRequest)_ttObject; }
        }

        protected ITTCheckBox IsForensic;
        protected ITTRichTextBoxControl PyhsicalExamination;
        protected ITTRichTextBoxControl Complaint;
        protected ITTLabel labelComplaint;
        protected ITTLabel labelOzelDurum;
        protected ITTObjectListBox OzelDurum;
        protected ITTTextBox CameHospital;
        protected ITTTextBox MedulaRaporBilgileri;
        protected ITTTextBox MedulaRaporTakipNo;
        protected ITTTextBox Note;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel lblRaporBilgileri;
        protected ITTLabel labelMedulaRaporTakipNo;
        protected ITTCheckBox chkDisXXXXXXRaporu;
        protected ITTLabel labelTreatment;
        protected ITTGrid HyperbaricOxygenTreatmentOrders;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTTextBoxColumn TreatmentPeriod;
        protected ITTTextBoxColumn ProcedureAmount;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn TreatmentDepth;
        protected ITTTextBoxColumn TreatmentProperties;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelNote;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage tttabpage3;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTextBox History;
        protected ITTTextBox Decision;
        protected ITTObjectListBox ProcedureDoctorApproved;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel LabelHistory;
        protected ITTLabel LabelPyhsicalExamination;
        protected ITTLabel CameHospitalLabel;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            IsForensic = (ITTCheckBox)AddControl(new Guid("18d30dc3-34a9-40ad-9992-169c75b7849e"));
            PyhsicalExamination = (ITTRichTextBoxControl)AddControl(new Guid("e22d027f-e726-49d1-a54d-ffb578d71b26"));
            Complaint = (ITTRichTextBoxControl)AddControl(new Guid("a2e73f8e-5e3b-4873-9888-de6eb990d3a1"));
            labelComplaint = (ITTLabel)AddControl(new Guid("ebeccab9-3d9f-4cd4-bfdf-2bb9fd9d2568"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("8cb6d92e-d716-4ce1-81ee-8bb2011c1383"));
            OzelDurum = (ITTObjectListBox)AddControl(new Guid("9fb272e5-f1b1-48be-b05d-2d6fbfb27f70"));
            CameHospital = (ITTTextBox)AddControl(new Guid("09822e86-2312-4d62-9bbd-aa4c06751034"));
            MedulaRaporBilgileri = (ITTTextBox)AddControl(new Guid("d99a99c3-b880-4469-8980-09f061c2c847"));
            MedulaRaporTakipNo = (ITTTextBox)AddControl(new Guid("b8790dda-eebc-46a0-b8a0-47f456a98fc4"));
            Note = (ITTTextBox)AddControl(new Guid("9a2ac113-658a-4462-bd7b-888cfbdebf00"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("f616c964-bd60-475b-8f60-f310f48c6a20"));
            lblRaporBilgileri = (ITTLabel)AddControl(new Guid("c6416fa1-ac94-4d85-acac-6bc8d7f87a1c"));
            labelMedulaRaporTakipNo = (ITTLabel)AddControl(new Guid("0929829f-9937-4c15-a64a-bdb000bd06bd"));
            chkDisXXXXXXRaporu = (ITTCheckBox)AddControl(new Guid("9de51c0b-1049-488b-8aa5-d5795176c712"));
            labelTreatment = (ITTLabel)AddControl(new Guid("ab246c81-5d25-45ec-a294-d13cf58cb62d"));
            HyperbaricOxygenTreatmentOrders = (ITTGrid)AddControl(new Guid("0f9814f7-b456-4245-9a6b-45201f4a1afb"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("ebd5a76a-7d5a-41fd-a6c3-3dbc959d68e5"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("09e5fc50-1ab1-48da-9dff-efaa5675bf2f"));
            TreatmentPeriod = (ITTTextBoxColumn)AddControl(new Guid("642932b0-26a2-4ff4-bee7-dd90ebf989fc"));
            ProcedureAmount = (ITTTextBoxColumn)AddControl(new Guid("4269c0de-71ed-4280-8780-4e4a252b9b53"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("c2fdaaca-acba-4b63-aad0-4e47f1952116"));
            TreatmentDepth = (ITTTextBoxColumn)AddControl(new Guid("dadc5608-c3c4-4108-be0d-059fa4fed5e4"));
            TreatmentProperties = (ITTTextBoxColumn)AddControl(new Guid("e6bf66a5-74fb-4dad-902c-42daecedf1fe"));
            Emergency = (ITTCheckBox)AddControl(new Guid("16e37f66-e0a2-46c7-ad2d-9ded9674e0a3"));
            labelNote = (ITTLabel)AddControl(new Guid("9905668a-19fe-4446-a1ba-28b13945133e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("58acc868-5d22-4271-81bb-d77f69039c04"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ccc75f6d-223f-4cea-b1f6-dd0f5bb2da96"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("86b2332e-01e7-4474-b9b2-eb256160acfa"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("3891d213-5fc0-4a71-85ea-b8aa80956c0a"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("889dfdf4-2371-4e79-a2d4-9de0e9f885ae"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("f4038bc6-4c2a-4185-b547-8bb978bd6194"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("78a6e85e-a0c4-4c24-a223-2d56077688a4"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("96e2ca3f-a29f-471a-931d-560052b5de5e"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("2208f332-c517-4f41-8430-919c32c18e12"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("7e9c20b3-eabe-4194-8faf-afa02d59e23b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("3828e747-2394-4997-9f8d-bd90b9803b4c"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("842f0cab-7e0e-4181-814c-539b770c3c06"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("729182b6-cf53-4ebf-abde-3e36ade9d13f"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8657e1b1-3e82-405b-b1d0-01181854853b"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("d844846c-d801-4770-af18-1d4845349b02"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("8dd88936-e8fb-4977-a7c6-d3ffe509b555"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("c7868372-a61f-404e-b2ff-ef1527572ea9"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("11c9018a-19f2-4b49-82fa-6805ca0e6696"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("a2715d47-0b96-4a31-a092-c9f69cf0eb68"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a1635e65-e266-4222-a07b-77665c9e6035"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("36bc9bc0-fa69-4968-bf4f-a06ecd97178c"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e70ed508-34a7-453d-bf9a-97f20d68d08d"));
            History = (ITTTextBox)AddControl(new Guid("258112cb-d718-46ca-b889-a3c1ef224411"));
            Decision = (ITTTextBox)AddControl(new Guid("c3abb76c-381d-4ed8-bd7f-8b90422883c9"));
            ProcedureDoctorApproved = (ITTObjectListBox)AddControl(new Guid("a733bcd1-62ed-471a-95c0-af54f1ada52d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e4da327d-5457-4152-9db2-ddc404f431ff"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("373af791-67e2-45a6-81f2-9eae8e857679"));
            LabelHistory = (ITTLabel)AddControl(new Guid("60bc2bb3-7f83-4e66-a9b2-412dedcd43c4"));
            LabelPyhsicalExamination = (ITTLabel)AddControl(new Guid("b5b41c20-209a-4cb2-8105-a1acb396acae"));
            CameHospitalLabel = (ITTLabel)AddControl(new Guid("f266aba7-ba3e-4f45-bec3-c55705a703f4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b3c4bbe6-be36-4628-8ba7-d7ca9f70e124"));
            base.InitializeControls();
        }

        public HyperbarikOxygenTreatmentForm() : base("HYPERBARIKOXYGENTREATMENTREQUEST", "HyperbarikOxygenTreatmentForm")
        {
        }

        protected HyperbarikOxygenTreatmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}