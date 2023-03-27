
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
    /// Diğer XXXXXXlerden Konsültasyon 
    /// </summary>
    public partial class ConsultationFromOtherHospitalForm : EpisodeActionForm
    {
    /// <summary>
    /// Dış XXXXXXlerden Konsültasyon
    /// </summary>
        protected TTObjectClasses.ConsultationFromOtherHospital _ConsultationFromOtherHospital
        {
            get { return (TTObjectClasses.ConsultationFromOtherHospital)_ttObject; }
        }

        protected ITTButton btnPrescription;
        protected ITTTabControl tttabInfo;
        protected ITTTabPage TabConsultationResultsOffers;
        protected ITTTextBox ConsultationResultAndOffers;
        protected ITTTabPage TabTreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDateBaseTreatmentMaterial;
        protected ITTListBoxColumn MaterialBaseTreatmentMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn AmountBaseTreatmentMaterial;
        protected ITTTextBoxColumn UBBCodeBaseTreatmentMaterial;
        protected ITTTextBoxColumn NoteBaseTreatmentMaterial;
        protected ITTTabPage TabTreatmentMaterialShadow;
        protected ITTGrid TreamentsMaterialShadowsGrid;
        protected ITTTextBoxColumn TreatmentMaterialNameTreatmentMaterial;
        protected ITTTextBoxColumn TreatmentMaterialAmountTreatmentMaterial;
        protected ITTTabPage TabPrescription;
        protected ITTRichTextBoxControl OutPatientPrescriptionInfo;
        protected ITTTextBox RequesterDoctorName;
        protected ITTButton ShowMessageStatus;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage GridDiagnosisEntry;
        protected ITTGrid SecDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid DiagnosisGrid;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox Symptom;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox RequestDescription;
        protected ITTTextBox ProcedureDoctorName;
        protected ITTTextBox RequesterResourceName;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelRequestDescription;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox RequesterHospital;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox RequestedDepartment;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelSymptom;
        protected ITTLabel ttlabel13;
        protected ITTObjectListBox RequestedHospital;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelRequestedExternalDepartment;
        protected ITTObjectListBox RequestedExternalHospital;
        protected ITTLabel labelRequestedExternalHospital;
        protected ITTObjectListBox RequestedExternalDepartment;
        override protected void InitializeControls()
        {
            btnPrescription = (ITTButton)AddControl(new Guid("ba13cc4b-461b-4270-8c6b-4b7674fbd754"));
            tttabInfo = (ITTTabControl)AddControl(new Guid("77d8e3ac-1cc8-4d93-b8d4-97d53b0d7435"));
            TabConsultationResultsOffers = (ITTTabPage)AddControl(new Guid("858c9238-d10b-4b90-acee-151930e0b5ef"));
            ConsultationResultAndOffers = (ITTTextBox)AddControl(new Guid("33d6b521-443a-4a1e-8db4-8f461032aa3e"));
            TabTreatmentMaterial = (ITTTabPage)AddControl(new Guid("a0352380-139c-4598-b48a-03247ae5b96c"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("06c9f068-5682-4f27-b5dd-1af00e60b955"));
            ActionDateBaseTreatmentMaterial = (ITTDateTimePickerColumn)AddControl(new Guid("499e8cd6-bb3c-4680-a893-53022b185206"));
            MaterialBaseTreatmentMaterial = (ITTListBoxColumn)AddControl(new Guid("9953d6db-1c5a-478a-804e-9f7416a21bd0"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("2be9a5e5-9622-4122-8be1-8fafe00b4f85"));
            AmountBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("e4d6e087-0dfd-4a18-8cf7-22839613fae3"));
            UBBCodeBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("5da3b36c-e66c-4e8e-90d9-db1bb0cb5fbb"));
            NoteBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("c2be6573-b31a-4561-92c3-85fbbaef2284"));
            TabTreatmentMaterialShadow = (ITTTabPage)AddControl(new Guid("a4ec4082-fd84-4c8c-ae9d-953a1911593a"));
            TreamentsMaterialShadowsGrid = (ITTGrid)AddControl(new Guid("032ee8cb-e6c6-476c-8b8f-e2aa1b1ed101"));
            TreatmentMaterialNameTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("8cfbedb5-812f-470d-850b-4624795ce6a4"));
            TreatmentMaterialAmountTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("297324cf-7560-4162-a742-3ea246e728f7"));
            TabPrescription = (ITTTabPage)AddControl(new Guid("88de125a-e3d1-4f50-823d-9ef1eabac604"));
            OutPatientPrescriptionInfo = (ITTRichTextBoxControl)AddControl(new Guid("316fc129-e23e-4451-98ce-1e93b91a8d0e"));
            RequesterDoctorName = (ITTTextBox)AddControl(new Guid("bf7cb643-894b-453a-a679-678a35337d11"));
            ShowMessageStatus = (ITTButton)AddControl(new Guid("23fe1193-a3ea-49e9-ae28-7bf3d9c8f3b5"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("d1df4e43-fdac-43ff-a341-281557c79931"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("cb056ab7-9cba-4fa5-8b8a-8a6495b23909"));
            SecDiagnosisGrid = (ITTGrid)AddControl(new Guid("e5099dec-a185-426d-ad8f-19111cc2c289"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("dd7588a1-9e93-40b3-be7e-8f48e1527285"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("9a4aabb9-71e1-42f9-be45-9280c439d386"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("2cee82f2-3424-4f92-9961-853d8ef1d430"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0055fca0-b8d2-4d67-9915-7d2b5d41e678"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("dbef67de-a0ba-4aef-b1be-ee7943c13b96"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("2cf0c27f-9e38-4b2f-ba6c-d52b81434c5b"));
            DiagnosisGrid = (ITTGrid)AddControl(new Guid("077bfe6b-abae-4aee-be12-461636154d76"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("51e2cf61-dd73-4095-a6da-b05cb1d3a1d2"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f0d79519-a43c-42f3-b034-c274a8f0e780"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("1fe58bd7-1be6-4f56-8237-71c8deeabd43"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("070abded-3cb9-45f9-9c89-e261163bc9da"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("60a88759-7c93-4452-91b2-6f94365dd159"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("41acb642-553b-45e2-832b-52826727a9de"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("b9a8613a-d81f-424c-8dcd-9e0dd0da6a90"));
            Symptom = (ITTTextBox)AddControl(new Guid("23ca7489-78eb-4428-9efb-3ff4158a0d07"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("25752df3-31fd-49f0-a22e-c9ed4a730329"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("57c82500-cf29-4d85-80fc-fe381999ddc9"));
            ProcedureDoctorName = (ITTTextBox)AddControl(new Guid("dc99133c-ffb8-4181-a60c-6f239489de55"));
            RequesterResourceName = (ITTTextBox)AddControl(new Guid("63c94bf4-5a4f-4cd4-b4b2-7c81a0349416"));
            labelActionDate = (ITTLabel)AddControl(new Guid("5f32e74d-91fc-49f9-959f-3680ae329cad"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("f9b1944a-1624-482c-907e-6b38ac899a90"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cf0590c7-a7a8-4b6e-9e55-6da81c8a3592"));
            RequesterHospital = (ITTObjectListBox)AddControl(new Guid("88bd4560-02c7-41cc-a13c-79c3ed8a5a9a"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("7325ccab-e3a9-46b9-91e9-7a3e53a5fb2d"));
            RequestedDepartment = (ITTObjectListBox)AddControl(new Guid("c34098b2-e89c-436a-aa79-7d1e6424ba7e"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("223e05b4-94f0-45d6-b486-9518548e1308"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ad055fab-0e75-4b2d-adca-a0a0a36a2193"));
            labelSymptom = (ITTLabel)AddControl(new Guid("bf996881-b927-4051-8dea-c9bac3c7dec9"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("8e84b928-121f-400b-a8e8-cd2c29fe9e9e"));
            RequestedHospital = (ITTObjectListBox)AddControl(new Guid("182d31b7-1ff8-4388-bb65-df3011e85cd8"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0f86045b-c283-493d-8a67-dff49abe929c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("eed7861a-4ce0-45fe-9195-4ef0a779cb9e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6975c482-323c-47b2-a445-0f251873a84f"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("8c7e5a43-9404-4a60-823c-305991bab164"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ef33a444-c402-4136-816d-4b1cc728dba1"));
            labelRequestedExternalDepartment = (ITTLabel)AddControl(new Guid("27fe9456-7ec3-4536-9814-c5e74a1177b1"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("29a658f7-9925-491d-bb09-646e31acd704"));
            labelRequestedExternalHospital = (ITTLabel)AddControl(new Guid("7b9865db-7697-4dad-8db6-967edfc39461"));
            RequestedExternalDepartment = (ITTObjectListBox)AddControl(new Guid("a7dc4e5c-6b0f-46f0-bbb1-d37b53cc1477"));
            base.InitializeControls();
        }

        public ConsultationFromOtherHospitalForm() : base("CONSULTATIONFROMOTHERHOSPITAL", "ConsultationFromOtherHospitalForm")
        {
        }

        protected ConsultationFromOtherHospitalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}