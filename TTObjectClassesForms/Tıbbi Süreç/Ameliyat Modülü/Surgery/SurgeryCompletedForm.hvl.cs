
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
    /// Tamamlandı
    /// </summary>
    public partial class SurgeryCompletedForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker SurgeryEndTime;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTTextBox ProtocolNo;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRoom;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl TabOperative;
        protected ITTTabPage SurgeryInfo;
        protected ITTGrid GridParticipantDepartmants;
        protected ITTListBoxColumn Department;
        protected ITTListBoxColumn ResponsibleDoctor;
        protected ITTRichTextBoxControl SurgeryReport;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage SurgeryCategory;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTDateTimePickerColumn CAActionDate;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTEnumComboBoxColumn IncisionType;
        protected ITTEnumComboBoxColumn Position;
        protected ITTListDefComboBoxColumn PackageProcedureObject;
        protected ITTRichTextBoxControlColumn DescriptionOfObj;
        protected ITTButtonColumn EnterSurgeryPersonel;
        protected ITTListBoxColumn ProcedureDoctor1;
        protected ITTTextBoxColumn ToothNumber;
        protected ITTCheckBoxColumn ToothAnomaly;
        protected ITTTextBoxColumn ToothCommitmentNumber;
        protected ITTTabPage SurgeryTeam;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn Role;
        protected ITTTabPage PreOperativeInfo;
        protected ITTGrid GridPreOpApplications;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTRichTextBoxControl PreOpDescriptions;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox SurgeryTotalPoint;
        protected ITTTextBox AnesthesiaPoint;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("01a5c191-8944-4bf2-bf3e-fae67df8d834"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("4e244f41-d4b5-478d-b293-ceae0495c300"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("289fa6ce-984c-49dc-b9e4-acf896cd73fd"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("ea591e05-95de-424c-a813-4a1a2e0a4c3a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("728767b8-b378-4512-865f-fce362a21f16"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("f6ffb59d-fd30-4fe4-8fde-b1de81dcb32b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c3d769b3-e812-4ce7-b6c4-bd4aeaf94598"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("37e3f0ed-c7ba-48aa-a66c-2014850753b1"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("8ef12ded-df95-4635-9939-f501a055003c"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("53a04ee1-b612-42c0-ab19-be047c6b21be"));
            Emergency = (ITTCheckBox)AddControl(new Guid("5a451e7c-bef7-4f9a-95e8-cf901af02e0d"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("302dd10c-28e8-4195-9d4f-fff04917d7f7"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("3d3b19bc-8758-4d55-8eb3-5e526dadc3d9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("62f83761-dca5-463f-8f5a-0e2c8856aaf1"));
            labelRoom = (ITTLabel)AddControl(new Guid("8df300ba-e50b-468f-8b94-c74524cc275a"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("0856a74c-4c2a-48c8-8b18-631bafe6c355"));
            TabOperative = (ITTTabControl)AddControl(new Guid("1d8cfc75-e730-4d09-b634-2092f8a8f74e"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("38b076d5-e797-4dda-98bf-7c71f12b0238"));
            GridParticipantDepartmants = (ITTGrid)AddControl(new Guid("792f37a6-7168-4e83-8f10-1be5786b20fe"));
            Department = (ITTListBoxColumn)AddControl(new Guid("b368deef-e1ba-42b7-9dc2-4b7a875ad3d3"));
            ResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("f1507957-2815-4ccf-9c00-a02afd65320e"));
            SurgeryReport = (ITTRichTextBoxControl)AddControl(new Guid("1166d9b2-c866-41ca-b953-7b66127b5954"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("9d2d8fc3-e155-404b-a994-f589ff32af95"));
            SurgeryCategory = (ITTTabPage)AddControl(new Guid("464bf474-d46f-4f8d-a2e7-d1f0f21ddf1c"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("11d1c186-940e-4878-9026-664940f90a6a"));
            CAActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("e4a744bb-6fae-48a7-91d1-227ab97ed51b"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("24d4a3dc-0b33-4b6a-ad54-74c340b42867"));
            IncisionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ebd08ecd-1f63-4bc9-9319-57caca0399db"));
            Position = (ITTEnumComboBoxColumn)AddControl(new Guid("80dc6487-8a4e-4b62-9240-abe153a42cdf"));
            PackageProcedureObject = (ITTListDefComboBoxColumn)AddControl(new Guid("d00d6865-2b15-4e44-86cc-618f303749b2"));
            DescriptionOfObj = (ITTRichTextBoxControlColumn)AddControl(new Guid("9d0e1ebf-6d32-4ad6-b0c1-2396d005d145"));
            EnterSurgeryPersonel = (ITTButtonColumn)AddControl(new Guid("9fe1c42f-363c-4753-b12d-910569c5bb9d"));
            ProcedureDoctor1 = (ITTListBoxColumn)AddControl(new Guid("e455592c-9558-4265-8431-ccda6591ba13"));
            ToothNumber = (ITTTextBoxColumn)AddControl(new Guid("76d86ece-bfe3-4640-9a2c-c0148f18d223"));
            ToothAnomaly = (ITTCheckBoxColumn)AddControl(new Guid("c8f262f4-2b18-470a-8521-e29cc4988f67"));
            ToothCommitmentNumber = (ITTTextBoxColumn)AddControl(new Guid("22d96483-82fa-45cf-a008-981322aa2467"));
            SurgeryTeam = (ITTTabPage)AddControl(new Guid("2fd68b20-71cf-467e-8b7a-cc67c5780a0b"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("a73b9b30-0cd6-4cad-896f-b1fb4e72bed0"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("f2a062b0-a00e-4d5e-91a1-98294eee05cb"));
            Role = (ITTEnumComboBoxColumn)AddControl(new Guid("bfa404b8-8c28-428a-9c8b-3d34714c9f3a"));
            PreOperativeInfo = (ITTTabPage)AddControl(new Guid("ad47ee15-832c-42a3-b647-41ef4d43897f"));
            GridPreOpApplications = (ITTGrid)AddControl(new Guid("b09db83c-7121-49ae-b706-4d19cb17056b"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("f1fe373f-9af6-4f19-a3a5-d68f39b726c1"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e5eb4410-8efc-46b0-93f4-4fef30199d99"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("7a7d6a0f-60c0-450a-be8b-a7674795c5a8"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("d2e8ac84-3d50-4936-872c-cc1be7552bb5"));
            PreOpDescriptions = (ITTRichTextBoxControl)AddControl(new Guid("f791b333-07fa-4b52-80a8-90d2baf9e280"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("b984a2e3-2047-4ab5-b9c0-e21cf682a78d"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("d7314519-e3bc-4e7d-bfa9-342c0a698335"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e0042682-c6ce-42e8-8f9a-5befa69edb40"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("289801f3-cd01-445d-b71c-48eb3eec7935"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("f922b82e-0193-4f24-b1a4-bb6b8337b5a7"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("7771d02c-8bf9-4f46-afab-f25392d2adb1"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ae283821-658e-44e6-bdcd-fa156e8d5784"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f3c0a74e-9180-4b76-a78e-9ed4bf43340c"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("8a500623-e532-4f55-b01a-eef1f1484bf8"));
            SurgeryTotalPoint = (ITTTextBox)AddControl(new Guid("f001639e-1951-4099-af26-d549184d960e"));
            AnesthesiaPoint = (ITTTextBox)AddControl(new Guid("03514a92-6921-40ba-85df-825a85d9cf30"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("9b865f8e-aad3-47b7-b2cb-5300be7effe3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5513201c-4c66-4324-b9b2-1305e18b5fe4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9f9871b0-127e-40d1-b6cc-94a2caf7ebab"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("b887e1ba-2829-4da2-9d2e-f0b827c50b1c"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("c88554de-3e40-4163-9aec-0c08074eb53e"));
            base.InitializeControls();
        }

        public SurgeryCompletedForm() : base("SURGERY", "SurgeryCompletedForm")
        {
        }

        protected SurgeryCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}