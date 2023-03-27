
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
    /// Ameliyat
    /// </summary>
    public partial class SurgeryReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker PlannedSurgeryDate;
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
        protected ITTRichTextBoxControl TabSubaction;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage MainSurgeryProcedures;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn1;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn2;
        protected ITTListBoxColumn ProcedureDoctor1;
        protected ITTListBoxColumn ProcedureDoctor2;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTRichTextBoxControlColumn DescriptionOfProcedureObject;
        protected ITTTextBoxColumn SutPoint;
        protected ITTTextBoxColumn GilPoint;
        protected ITTButtonColumn EuroScoreButton;
        protected ITTTabPage SurgeryProcedures;
        protected ITTGrid GridSurgeryProcedures;
        protected ITTDateTimePickerColumn CAActionDate;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTEnumComboBoxColumn IncisionType;
        protected ITTEnumComboBoxColumn Position;
        protected ITTRichTextBoxControlColumn CADescriptionOfObj;
        protected ITTListBoxColumn EntryDepartment;
        protected ITTListBoxColumn ProcedreDoctor1;
        protected ITTTabPage SurgeryTeam;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn CARole;
        protected ITTTabPage SurgeryExpend;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTListBoxColumn CAStore;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn DonorID;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTabPage DirectPurchase;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTDateTimePicker SurgeryReportDate;
        protected ITTLabel ttlabel3;
        protected ITTTabPage PreOperativeInfo;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTRichTextBoxControl PreOpDescriptions;
        protected ITTTextBox ComplicationDescription;
        protected ITTTextBox EpisodeId;
        protected ITTObjectListBox MasterResource;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        protected ITTLabel labelComplicationDescription;
        protected ITTCheckBox IsComplicationSurgery;
        override protected void InitializeControls()
        {
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("598cd4fc-2cc6-4f79-a344-e87dfd4d3c5d"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9343b0d8-c1c3-475a-b657-c639cd4ce8c8"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("465cbc42-2b6b-4478-bfb7-0fb9fe084207"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("3b7c26ca-41c3-4205-a275-3819401077c1"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4d548854-4224-447e-ba72-f2d7d1713545"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("197ca673-0c89-4376-b56f-98d915231660"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("2c17e140-3adc-44b5-9f89-67844b9092a3"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("f7e5dfc9-8d06-47f6-a2c7-5140d3f297a6"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("c113ae97-cab1-4118-88b8-4fb219b56240"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("e09ac310-8157-40da-b381-f1ff4b229bf2"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("18bff36b-3f0d-41ba-8bba-2934a24f8605"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("0a569954-db75-459a-afbe-a86ec6e25b18"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("cd1a327e-76d8-4a4d-b0f5-f235325b09e1"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("df86212e-7e6c-44fd-b387-d3f9972e9717"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a3c43025-1b41-4653-9196-4da8f4a57265"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("fc51b1aa-ad89-4909-ba73-ce2395163a18"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("a83c69cc-5a1c-4089-a2d4-99df5122db86"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("2d6cb3f8-f891-491e-afc3-e4172f963b09"));
            Emergency = (ITTCheckBox)AddControl(new Guid("a62258dd-4f3d-4599-9a47-91fbc7e870b2"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("9b93d2bf-f740-412d-8203-20a2de401776"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("e3c0dd37-f5ea-495a-a9ae-0345f9ccdda6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8a6bcf01-618d-465f-86e7-361abacd7de4"));
            labelRoom = (ITTLabel)AddControl(new Guid("9933b3fc-46fe-4c4e-8de4-42d15def18e1"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("9d35d536-4de3-4338-bed0-3d7b7b0d5d28"));
            TabOperative = (ITTTabControl)AddControl(new Guid("1a1f0c77-f5e6-44c0-8cee-69b79cdfe529"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("9bc68051-df87-45eb-a2b1-e2f3092e0e20"));
            TabSubaction = (ITTRichTextBoxControl)AddControl(new Guid("768608a3-69d4-41ea-8051-1af5b0812e45"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("f03bcb17-dc0c-42e0-bbb3-1c2d8d285672"));
            MainSurgeryProcedures = (ITTTabPage)AddControl(new Guid("b353531b-77f1-49b8-aedc-7e639b1610eb"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("b3bd8e3e-dfb9-4c9a-8654-296dc82a234a"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("60ba02f2-84b7-447f-8e0c-40ca2f81fb37"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("2fd185b9-a689-4294-bf4d-fa2547a789d4"));
            ttenumcomboboxcolumn1 = (ITTEnumComboBoxColumn)AddControl(new Guid("98e4ae85-e36e-4476-9bbc-cc716952a70f"));
            ttenumcomboboxcolumn2 = (ITTEnumComboBoxColumn)AddControl(new Guid("16f49a92-eda8-4c65-91b6-83117bbd86c6"));
            ProcedureDoctor1 = (ITTListBoxColumn)AddControl(new Guid("5d8b4f43-ffde-45f2-a760-383b458c75c9"));
            ProcedureDoctor2 = (ITTListBoxColumn)AddControl(new Guid("5ca6e42f-04ad-4a0a-90e9-40cc764ae432"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("31152046-4092-405b-b6a8-ccad4cb44610"));
            DescriptionOfProcedureObject = (ITTRichTextBoxControlColumn)AddControl(new Guid("fddd20bf-3a26-496a-b57c-1a1c709ee276"));
            SutPoint = (ITTTextBoxColumn)AddControl(new Guid("be6cf794-40bf-4475-a266-46120b8d7d32"));
            GilPoint = (ITTTextBoxColumn)AddControl(new Guid("9c29018a-188f-46fb-abb5-348e8a6ef66c"));
            EuroScoreButton = (ITTButtonColumn)AddControl(new Guid("80f75786-22ab-49ee-9c4b-0933df2f05b8"));
            SurgeryProcedures = (ITTTabPage)AddControl(new Guid("4035fcdc-5067-47b7-8a8b-d4e26e600ae9"));
            GridSurgeryProcedures = (ITTGrid)AddControl(new Guid("058bd264-b3b9-49f7-bbe6-96876b87e58e"));
            CAActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("37750632-c793-418c-9064-9b21dc64f37a"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("940ae855-1cc4-4da8-a070-5018014a898d"));
            IncisionType = (ITTEnumComboBoxColumn)AddControl(new Guid("4ace2d51-bba7-40b4-a3d2-b3aacd58a647"));
            Position = (ITTEnumComboBoxColumn)AddControl(new Guid("8356fefb-7f83-43c6-ba24-189371914490"));
            CADescriptionOfObj = (ITTRichTextBoxControlColumn)AddControl(new Guid("538ee6eb-170e-4bdb-979c-cdffda990215"));
            EntryDepartment = (ITTListBoxColumn)AddControl(new Guid("0a255877-0acb-4f5e-84e9-ea1f10ac4bf9"));
            ProcedreDoctor1 = (ITTListBoxColumn)AddControl(new Guid("3f634fb3-eebf-49e4-98ee-8c9911a75df4"));
            SurgeryTeam = (ITTTabPage)AddControl(new Guid("b0b725ad-42fc-44f4-8a00-574ef3d227ee"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("4c7f1425-29eb-4653-85ea-ab6172d4e128"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("0130a0dc-bcfc-4034-a945-349deb1e0492"));
            CARole = (ITTEnumComboBoxColumn)AddControl(new Guid("930d79c0-7a8c-4fc4-8b77-3c71486ad423"));
            SurgeryExpend = (ITTTabPage)AddControl(new Guid("90a7bc9b-432f-4c54-8b48-80c59af21598"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("7cc7092a-edda-40fd-90da-26e2b4dd5bb8"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("43ad3052-b7df-41f9-96f5-c05135c6bd5d"));
            CAStore = (ITTListBoxColumn)AddControl(new Guid("b04b9b20-fc45-4aa3-ab0f-dd44d7ee40ea"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("267e4336-1f0a-4889-9772-7ebd2aa3f5ce"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("127d6021-45e6-4621-959e-623ea3ef5f33"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("7ec2e02f-b630-41b9-9e0e-f26729c81077"));
            DonorID = (ITTTextBoxColumn)AddControl(new Guid("cd8ba2ff-a7f7-4d3d-aa3d-7a3ae5161bc5"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("6738e92c-8b3b-4563-882d-acd812c86446"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("c76a511c-6d55-4486-b0f6-ac1535f0483b"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("b95b23e5-d3dd-4f4c-9f9f-a9d9222d6402"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("c87a47c9-ed20-4a80-9eea-044643ba6467"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("5844e9b8-e3f1-41ca-90c5-b90cf1c68b9b"));
            SurgeryReportDate = (ITTDateTimePicker)AddControl(new Guid("734c4d8f-a828-4d88-bfb2-6b2bf597705c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b3cedc2a-a647-4a6b-84fd-b0c958971cbb"));
            PreOperativeInfo = (ITTTabPage)AddControl(new Guid("9454f9b0-fafe-4080-b54a-5fa3ba5d88a8"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("32eb1d22-a0b9-4a19-b285-e0d43610f68d"));
            PreOpDescriptions = (ITTRichTextBoxControl)AddControl(new Guid("af411269-0f98-4309-a1fe-b8d57db4dbac"));
            ComplicationDescription = (ITTTextBox)AddControl(new Guid("000f3da0-69e8-43e3-a636-aa6c20c3cbee"));
            EpisodeId = (ITTTextBox)AddControl(new Guid("d11b22f7-27b5-4687-bcbe-2f86e404104e"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("ab39685e-ad1c-4dad-8b40-959be682e77a"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("46955f98-cbe5-4117-b2dd-b1272e0396de"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("6b056f43-0354-4ab4-8cde-18be3f315302"));
            labelComplicationDescription = (ITTLabel)AddControl(new Guid("1b036039-1524-4168-b11a-6cd941489ee6"));
            IsComplicationSurgery = (ITTCheckBox)AddControl(new Guid("25cfc88c-c4db-4a03-b639-d2126cc8cebb"));
            base.InitializeControls();
        }

        public SurgeryReportForm() : base("SURGERY", "SurgeryReportForm")
        {
        }

        protected SurgeryReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}