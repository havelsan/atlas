
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
    public partial class FollowUpExaminationNursingForm : EpisodeActionForm
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
        protected ITTTextBox ProtocolNo;
        protected ITTCheckBox IsTreatmentMaterialEmpty;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("be036d71-f24c-49a5-b0ba-219184a92d83"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("2f03f6a9-49b4-40c4-92e6-3afa6b7af743"));
            TabPatientInfo = (ITTTabControl)AddControl(new Guid("1908d48e-33be-451f-98ba-09f25f44b3ef"));
            PatientInfo = (ITTTabPage)AddControl(new Guid("0f4de46e-d006-411f-82dc-517d614ca932"));
            PatientHistory = (ITTRichTextBoxControl)AddControl(new Guid("1f194581-0ca2-4deb-8671-b3645f078e5b"));
            PatientFolder = (ITTRichTextBoxControl)AddControl(new Guid("1232a193-fbfa-4c59-bad1-9e9f9dee719a"));
            PhysicalExamination = (ITTRichTextBoxControl)AddControl(new Guid("3c163e2f-3984-41e1-9f7c-2569ea48835d"));
            Complaint = (ITTRichTextBoxControl)AddControl(new Guid("fdba6748-c2ba-4a14-8945-1cdc0520dce1"));
            AdditionalApplications = (ITTTabPage)AddControl(new Guid("8762b202-90ef-4254-9d05-55d98dd6f7a2"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("c241fe70-5a9d-4035-b56c-d9f2494a74a2"));
            aProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("c7901e76-44f8-41c9-b285-cdd30422c2a4"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("71065c03-a3c7-48fa-bd55-ff32f6f899cb"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("81b213df-16bf-4c98-982b-70c6245ff57e"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("b2c77dc7-823d-416d-bfe9-a3bc72a6bab3"));
            PatientImage = (ITTTabPage)AddControl(new Guid("a6407d70-199e-4ef9-a9b5-4e3000fdcc10"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("5ba5d028-bdc5-47e7-99c8-34a9dffea0c2"));
            TreatmentMaterials = (ITTTabPage)AddControl(new Guid("0631265a-5ef5-4121-be21-ce630a2dfcfc"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("5805355a-fc5b-414a-83f6-9299060fd922"));
            mActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("862eafae-b0e9-4e20-a643-a94108776164"));
            Material = (ITTListBoxColumn)AddControl(new Guid("0c096518-8366-42c1-817a-4cf9bf0ca1bc"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("320ad14b-5f04-45ae-85d0-b8ab8fc5a201"));
            mAmount = (ITTTextBoxColumn)AddControl(new Guid("9b0a4073-1150-4fc2-8f33-131b296f046c"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("99183a4e-1d57-411f-81c8-95ef8542ffd2"));
            mNotes = (ITTTextBoxColumn)AddControl(new Guid("142fbf43-005e-4e68-a5c2-e0947ab7cf0a"));
            NursingOrders = (ITTTabPage)AddControl(new Guid("b2bfc02b-6854-4d4c-a1de-8fc518d832f2"));
            GridNursingOrders = (ITTGrid)AddControl(new Guid("813985ff-5c0c-4375-a5fe-5f20da961615"));
            OrderActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("81c2a87f-8592-4fb2-a6b1-ced55c8e80de"));
            OrderProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e60293c3-c13a-4a4f-9c17-1dc19ae4f1ec"));
            PeriodStartTime = (ITTTextBoxColumn)AddControl(new Guid("6a0c5039-5848-4e0c-8e85-ba4f4054f0aa"));
            NursingOrderDetails = (ITTTabPage)AddControl(new Guid("d3e50df7-23f8-4287-b4e8-a0e2d3c57840"));
            GridNursingOrderDetails = (ITTGrid)AddControl(new Guid("e8ba0dc0-eb9a-42cb-aba9-1463b5a0ff11"));
            OrderDetailActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("a71fd889-8cf3-49fb-8988-0f2905f5e44d"));
            OrderDetailProcedureObject = (ITTListBoxColumn)AddControl(new Guid("cbb68532-0e5f-4483-9433-3794642e9e52"));
            NursingApplicationNurseNotes = (ITTTextBoxColumn)AddControl(new Guid("7741598e-a965-4cf6-94c0-4a4ca9f81cce"));
            NursingApplicationResult = (ITTTextBoxColumn)AddControl(new Guid("2bbf0e60-a89a-4b04-b845-be90bbea295d"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("179c4bdc-cc1e-4d6b-a526-53e1b87c3220"));
            DiagnosisEntry = (ITTTabPage)AddControl(new Guid("709b329e-f4d5-4791-828c-a710228f5dbe"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("8da8c688-9836-4f75-b672-99f98d80f027"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("25bf2832-f9dd-4ca0-b6ed-0eceeb3f905f"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("695af170-0694-498a-ab96-7aee067e75c3"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("0e2d277b-0776-4406-a975-f98e884f21a7"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("68e4f53b-49d1-4016-ab0d-950075a3ecdb"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("73b3108b-a0d2-48ed-8f2e-73fd5a3cc858"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("4f33faee-8eff-4fd4-a60a-165fc8da3964"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("f1598a15-ba9f-4537-a6b4-4f26fc3004b1"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("bcc507df-bdef-48ac-9977-3a4d5d4e53ba"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("e71183bf-b5a7-4a31-9cad-63053b29d648"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("cb76da4c-0e28-491e-b026-4d504b0cf87b"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a9949253-edb7-47e1-b044-77a1e155674b"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f9885003-64c5-4c79-99b1-50c11df1d54b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("09bfee5d-a835-4ec7-9200-783c41ed19a6"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("4f8a6c74-cb79-4c77-8d6c-23f0105d27a7"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("b5f10831-c992-40ae-b20f-4a824e3a838c"));
            IsTreatmentMaterialEmpty = (ITTCheckBox)AddControl(new Guid("7f984191-6154-4d6e-bc95-9d06506218bd"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("7efbefef-3ad1-4808-87e7-18fbf0f125af"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("83bf3586-e78c-4e17-921f-f5319ab8fce4"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("5580c0fc-a6a6-4e08-8746-fe36d60cf287"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("d0f8890f-4ed3-4f52-bf90-df49ba0ac512"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("8cc19ea1-35c8-439b-9d97-dcdd700f5074"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("e2618aa7-b2bc-4aeb-9ec1-67d475ed586e"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("c04cece3-8157-4917-b70d-cddabd8ebf51"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("161c8655-288f-4d17-a37f-3a3a349d1cca"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("839d2e41-02fc-4e00-a274-d01b65f83239"));
            base.InitializeControls();
        }

        public FollowUpExaminationNursingForm() : base("FOLLOWUPEXAMINATION", "FollowUpExaminationNursingForm")
        {
        }

        protected FollowUpExaminationNursingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}