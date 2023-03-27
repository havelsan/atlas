
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
    /// Kontrol Muayenesi
    /// </summary>
    public partial class FollowUpExaminationCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FollowUpExamination _FollowUpExamination
        {
            get { return (TTObjectClasses.FollowUpExamination)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTTabControl TabPatientInfo;
        protected ITTTabPage PatientInfo;
        protected ITTRichTextBoxControl PatientHistory;
        protected ITTRichTextBoxControl PatientFolder;
        protected ITTRichTextBoxControl PhysicalExamination;
        protected ITTRichTextBoxControl Complaint;
        protected ITTTabPage AdditionalApplications;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn aProcessDate;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTabPage PatientImage;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTTabPage TreatmentMaterials;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn mActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn mAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn mNotes;
        protected ITTTabPage NursingOrders;
        protected ITTGrid GridNursingOrders;
        protected ITTDateTimePickerColumn OrderActionDate;
        protected ITTListBoxColumn OrderProcedureObject;
        protected ITTTextBoxColumn PeriodStartTime;
        protected ITTTabPage NursingOrderDetails;
        protected ITTGrid GridNursingOrderDetails;
        protected ITTDateTimePickerColumn OrderDetailActionDate;
        protected ITTListBoxColumn OrderDetailProcedureObject;
        protected ITTTextBoxColumn NursingApplicationNurseNotes;
        protected ITTTextBoxColumn NursingApplicationResult;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage DiagnosisEntry;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox ProtocolNo;
        protected ITTCheckBox IsTreatmentMaterialEmpty;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTLabel labelReasonOfCancel;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("8ae73a57-acb6-4994-a839-a459dc323ebf"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("106706f0-8f30-4ca9-bdfd-34d5c0334663"));
            TabPatientInfo = (ITTTabControl)AddControl(new Guid("dfa43c36-2c2a-4153-8ebf-955145201f58"));
            PatientInfo = (ITTTabPage)AddControl(new Guid("e5a1144a-d1f1-412b-ad5f-a045c2877d4c"));
            PatientHistory = (ITTRichTextBoxControl)AddControl(new Guid("471ffde2-a7fd-41e2-866f-048cbff6dd01"));
            PatientFolder = (ITTRichTextBoxControl)AddControl(new Guid("31dfd025-eab0-4cf6-92ea-8d6557d547d7"));
            PhysicalExamination = (ITTRichTextBoxControl)AddControl(new Guid("34ab3971-050f-4ef7-81e2-8bf188f41630"));
            Complaint = (ITTRichTextBoxControl)AddControl(new Guid("9a11c4d4-d663-42bf-a5cc-f76cdc924ce1"));
            AdditionalApplications = (ITTTabPage)AddControl(new Guid("93b773a1-b667-4552-8dfe-ee45ca324b71"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("a67af8ae-352c-4033-99e5-735833b06fcd"));
            aProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("fe998960-43ea-475c-925b-b62425537a3b"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("be39dbe8-2072-49de-b22e-1109c82431e7"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("fa50dacb-2400-429d-b492-ed5486b013b3"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("19bb9379-5d26-443c-8c49-2de5f008f138"));
            PatientImage = (ITTTabPage)AddControl(new Guid("3c939022-49ac-42c1-b6c7-4a54fe9b2f5e"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("3004d687-51bc-48f2-943f-dbd1bafd78d3"));
            TreatmentMaterials = (ITTTabPage)AddControl(new Guid("b69f7362-e2da-4c5d-af86-8f8750c91a53"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("b41e552f-aa11-49d6-b99c-384edce3d28e"));
            mActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("6918a120-b6d1-48b1-939d-e3eeb29f9c4f"));
            Material = (ITTListBoxColumn)AddControl(new Guid("93660088-1f18-41f8-be28-b9ff04718121"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("72150a4a-c739-44fe-91c8-aa37c0da51ba"));
            mAmount = (ITTTextBoxColumn)AddControl(new Guid("44f34c25-e171-4004-a029-85e00513a00b"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("f7c26b87-9313-4a34-9494-602c7e7c872b"));
            mNotes = (ITTTextBoxColumn)AddControl(new Guid("b9bb940a-dc16-4605-ad7b-35f1aa32dec6"));
            NursingOrders = (ITTTabPage)AddControl(new Guid("14257477-cdfd-4b10-80c9-abffa6f32389"));
            GridNursingOrders = (ITTGrid)AddControl(new Guid("8ba1306b-8b81-4ea6-9016-d3d9bf9f2722"));
            OrderActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("eb7526ff-26c5-42c1-aa2f-9835b1225855"));
            OrderProcedureObject = (ITTListBoxColumn)AddControl(new Guid("5bc1ad27-ceef-43bb-a7d9-7544b918bab9"));
            PeriodStartTime = (ITTTextBoxColumn)AddControl(new Guid("ba0ed548-86ab-47b5-a967-744074677da3"));
            NursingOrderDetails = (ITTTabPage)AddControl(new Guid("f1fa0856-2940-465e-a4cd-8349fd201212"));
            GridNursingOrderDetails = (ITTGrid)AddControl(new Guid("74e2ecc1-007f-4f7e-a534-ca26674f29b8"));
            OrderDetailActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("0db3d0ab-a91b-4aef-b2e2-37e624084496"));
            OrderDetailProcedureObject = (ITTListBoxColumn)AddControl(new Guid("4c61a670-eb23-4fef-b0ae-22e1f2084308"));
            NursingApplicationNurseNotes = (ITTTextBoxColumn)AddControl(new Guid("cde1c3e9-b980-4eed-8dc0-86ac050fda4c"));
            NursingApplicationResult = (ITTTextBoxColumn)AddControl(new Guid("114d0e34-c458-472f-b0e0-da6e5f339576"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("f326c52f-ce17-4ad4-9731-bd94ec9e4c75"));
            DiagnosisEntry = (ITTTabPage)AddControl(new Guid("fac1c0db-cb1c-4626-aaa1-000f22ce1e5d"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("f308d68f-4dba-4d4b-8b91-447efe784bb5"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("155e245d-2eee-4a91-8ffb-f6261115362a"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("d25bd231-7131-424b-abc6-6369b4db8352"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("eda8c3d6-32dd-4896-96a9-c0c59633a0f5"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("01d37644-67db-4526-835e-11fb88e36fa4"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8b268cd5-5b66-45c4-8b41-1300f4b7de1e"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("90a11052-cd38-45ed-a38e-262d3148e313"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("d7206ca2-81ff-4274-b569-99bdb0124086"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("05f3a2dd-0435-4d8e-96fa-3e0d40f67f8b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d6238c14-6730-4fb8-bc0c-572f6408d985"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("3b693c76-22a3-4f4b-9899-cec2a36629bd"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("83be8a0c-829d-4c49-baff-bff621293cc8"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d29da13e-5e0f-4687-8473-d03fe3871f8a"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1b1bdadc-5493-4df6-9b67-39993ab51917"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("3751c422-95b1-4060-a20c-d8c01b8e7a4a"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("477bdd05-e518-4b68-8394-e20ac8635d79"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("9b2e7519-6cf0-49c9-b2e3-fa72021dc538"));
            IsTreatmentMaterialEmpty = (ITTCheckBox)AddControl(new Guid("994ee2ff-cfea-410b-a8e2-d887c9a5762a"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("4a5077e4-694d-4dde-83f9-33c01b8c15a9"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("be193e24-8020-473a-9f38-dc453ef25c06"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("d68d207b-e531-4b2b-9990-283808173673"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("ab08a9d4-3807-437b-a926-de03b557f841"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("a7fcb6ba-2937-478a-b0ca-eb8047ecf73f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cde58c28-e5c6-483e-baad-42563d3ebfa9"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("f38a0c9f-1eec-427e-bd07-f9509c408a55"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2a7e9093-8bcc-432f-a934-a5b06784fd78"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("362520a0-eabd-47c1-94e8-44b1cb5d9842"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("8d4e214f-aea6-4457-b607-258eedc43f04"));
            base.InitializeControls();
        }

        public FollowUpExaminationCancelledForm() : base("FOLLOWUPEXAMINATION", "FollowUpExaminationCancelledForm")
        {
        }

        protected FollowUpExaminationCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}