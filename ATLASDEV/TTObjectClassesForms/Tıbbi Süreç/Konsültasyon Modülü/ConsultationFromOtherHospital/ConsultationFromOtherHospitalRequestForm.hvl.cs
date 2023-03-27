
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
    public partial class ConsultationFromOtherHospitalRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Dış XXXXXXlerden Konsültasyon
    /// </summary>
        protected TTObjectClasses.ConsultationFromOtherHospital _ConsultationFromOtherHospital
        {
            get { return (TTObjectClasses.ConsultationFromOtherHospital)_ttObject; }
        }

        protected ITTRichTextBoxControl ReasonOfReject;
        protected ITTLabel labelReasonOfReject;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage GridDiagnosisEntry;
        protected ITTGrid SecDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid Diagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Symptom;
        protected ITTTextBox RequestDescription;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelRequesterHospital;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelRequestDescription;
        protected ITTLabel labelRequestedDepartment;
        protected ITTObjectListBox RequestedDepartment;
        protected ITTLabel labelSymptom;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox RequestedHospital;
        protected ITTObjectListBox RequesterHospital;
        protected ITTLabel labelRequestedHospital;
        protected ITTObjectListBox RequesterDepartment;
        protected ITTLabel labelRequesterDepatment;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox RequesterDoctor;
        protected ITTLabel labelRequestedExternalDepartment;
        protected ITTObjectListBox RequestedExternalHospital;
        protected ITTLabel labelRequestedExternalHospital;
        protected ITTObjectListBox RequestedExternalDepartment;
        override protected void InitializeControls()
        {
            ReasonOfReject = (ITTRichTextBoxControl)AddControl(new Guid("38a52df2-6f90-4207-a365-a54c48d1ce4d"));
            labelReasonOfReject = (ITTLabel)AddControl(new Guid("9bc32c69-ac05-4e95-aebb-214b3dcd19d6"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("a1d1459c-f375-42b1-9c0f-8ffef073176e"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("60edc728-cc46-4453-b3de-14e10cf8d10b"));
            SecDiagnosisGrid = (ITTGrid)AddControl(new Guid("6153eea2-a7ed-42ef-a83a-46b0afb4fc75"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("cd220e7a-7e50-48ad-aab9-01d041871e51"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("83e9c067-a93d-40b6-b565-0917c9e449fa"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("3db1db00-d35f-4d9c-bad1-301697fccaa3"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("649a27a0-e61e-4b2c-b8d4-d1b06d33fb86"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("b5db2bb4-b445-438b-aaea-d4b6c653f6a8"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("2bb422b7-944f-422d-a1d1-7c105ac13d36"));
            Diagnosis = (ITTGrid)AddControl(new Guid("0222301a-b170-4385-be2b-c7743cc1bb23"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("ba354cb9-551c-4f32-a741-79f43ef5593d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("db37ebca-54b4-4c83-89ba-d49e485bc86d"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0c8c63c3-269a-48b7-8053-58949bbf2456"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b10ad112-ee47-4bdb-b436-aa60f3e79011"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("77a45ffc-7b07-47ff-93cc-d233f1bf9d5b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("0c1e59c4-6cd3-4741-ac9b-a628cc24e848"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("e999a178-2ef5-4664-bef4-b4452b79d4ba"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("dd2ac362-3311-4ed1-b1c5-06c4bf05c4e0"));
            Symptom = (ITTTextBox)AddControl(new Guid("aecdba37-7fd6-4443-a158-7ea4d897e7fb"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("31db0484-20c7-42f1-b420-fb8c7ceb5028"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("6c00ff71-0a26-4084-9673-006268d153d7"));
            labelRequesterHospital = (ITTLabel)AddControl(new Guid("3ec0e114-723e-43c6-95a1-1344be862435"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e0eb6bed-4791-443a-86f4-237a76c451d1"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("66a83fac-c5f9-4ec1-8e0c-381f1d50ccb9"));
            labelRequestedDepartment = (ITTLabel)AddControl(new Guid("d2ef3538-edc5-4dd4-a6d3-3bce6073d450"));
            RequestedDepartment = (ITTObjectListBox)AddControl(new Guid("1df3e13e-a095-4d5f-8e18-47c5dda3467b"));
            labelSymptom = (ITTLabel)AddControl(new Guid("d8f2f699-9e5d-472a-8c7f-87a9e8462198"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("8125abbc-a69c-4dfb-a459-8ac8221b1c30"));
            RequestedHospital = (ITTObjectListBox)AddControl(new Guid("24251995-f70c-4766-81ae-b28e7dd43a47"));
            RequesterHospital = (ITTObjectListBox)AddControl(new Guid("659090d6-27aa-4297-a734-bafa0152c2a9"));
            labelRequestedHospital = (ITTLabel)AddControl(new Guid("b56ddd74-f933-455a-8d15-cdbba6672638"));
            RequesterDepartment = (ITTObjectListBox)AddControl(new Guid("ddd81a70-5a03-402f-8a08-e581119009e5"));
            labelRequesterDepatment = (ITTLabel)AddControl(new Guid("d46926fa-ad1c-4f30-8d13-f64bd072c252"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("766fedbc-38a4-4763-a711-77820a127e47"));
            RequesterDoctor = (ITTObjectListBox)AddControl(new Guid("c370c1da-ae6f-4ae3-a502-01cd2ca0446b"));
            labelRequestedExternalDepartment = (ITTLabel)AddControl(new Guid("fc3e0003-4af9-4773-a199-a2ca138c8bb0"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("803956f4-040c-47f6-ba7e-603803d45c16"));
            labelRequestedExternalHospital = (ITTLabel)AddControl(new Guid("61ddf135-5297-489c-bb34-40b74397c090"));
            RequestedExternalDepartment = (ITTObjectListBox)AddControl(new Guid("e0ad7eb4-0e18-4072-a0bc-fbc164a523c0"));
            base.InitializeControls();
        }

        public ConsultationFromOtherHospitalRequestForm() : base("CONSULTATIONFROMOTHERHOSPITAL", "ConsultationFromOtherHospitalRequestForm")
        {
        }

        protected ConsultationFromOtherHospitalRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}