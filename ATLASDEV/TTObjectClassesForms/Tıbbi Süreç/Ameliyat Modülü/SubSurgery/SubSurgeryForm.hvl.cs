
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
    /// Ek Ameliyat
    /// </summary>
    public partial class SubSurgeryForm : EpisodeActionForm
    {
    /// <summary>
    /// Aynı Seansda Birden Fazla Bölüm Ameliyat Gerçekleştirdiğinde Diğer Bölümler İçin Kullanılan Nesnedir 
    /// </summary>
        protected TTObjectClasses.SubSurgery _SubSurgery
        {
            get { return (TTObjectClasses.SubSurgery)_ttObject; }
        }

        protected ITTLabel labelSurgeryStatus;
        protected ITTEnumComboBox SurgeryStatus;
        protected ITTLabel labelSurgeryShift;
        protected ITTEnumComboBox SurgeryShift;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn CARole;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage SurgeryExpend;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn CMActionDate;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn CAAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage DirectPurchase;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTTextBox ProtocolNo;
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
        protected ITTCheckBox Emergency;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRoom;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl TabOperative;
        protected ITTTabPage SurgeryInfo;
        protected ITTRichTextBoxControl SubSurgeryReport;
        protected ITTDateTimePicker SurgeryReportDate;
        protected ITTLabel ttlabel3;
        protected ITTTabPage PreOperativeInfo;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTRichTextBoxControl PreOpDescriptions;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTObjectListBox MasterResource;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        protected ITTLabel lebalReasonOfCancel;
        protected ITTLabel labelPlannedSurgeryDescription;
        override protected void InitializeControls()
        {
            labelSurgeryStatus = (ITTLabel)AddControl(new Guid("854df339-3171-4fec-a764-5e03e194acf4"));
            SurgeryStatus = (ITTEnumComboBox)AddControl(new Guid("25b94b49-e7c6-4b24-8428-e4e7f7a43911"));
            labelSurgeryShift = (ITTLabel)AddControl(new Guid("26693980-df61-4868-ae29-f4ca3f443b08"));
            SurgeryShift = (ITTEnumComboBox)AddControl(new Guid("ec0f66cd-b677-4531-9c5d-1142bc2d5272"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("7115a87a-d738-49b5-913a-97899c006f0e"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("dc2863bf-cb20-4188-8e5f-518bcd2f6b50"));
            CARole = (ITTEnumComboBoxColumn)AddControl(new Guid("bc56cdf9-e685-4780-a848-711210d24f5a"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("3cf2013e-cd9b-457c-a5a7-0cbf8be1598d"));
            SurgeryExpend = (ITTTabPage)AddControl(new Guid("1060fe0f-ae44-46bf-85ec-28870cd61fd5"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("590d35bb-0c33-44fc-baee-ec99ffcb6fc0"));
            CMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("fee8fddc-bfe7-4420-aa86-ec824df8f28a"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("dc3b562e-4cda-4165-a490-5501eda76752"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("9bd67a76-0276-483f-b4e2-9e58c984970b"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("9af4bc05-3bd9-43e6-8b96-32fb10f61d71"));
            CAAmount = (ITTTextBoxColumn)AddControl(new Guid("582be0d3-a39b-42d8-9b1d-0ecb25f75297"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("be31fb17-95dd-4e78-9400-d709abf68355"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("015f9c03-52f6-49ca-9b7f-07f5581dfccd"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("5012365e-e90e-4ad8-a2ee-3940e0128ba4"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("eff19042-9bdd-4ba0-abcf-4de0c1044a20"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("a1caedf2-4dde-4040-a370-3f53807a9a90"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("a14a9e51-d201-4cee-ab38-401d82ada90c"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("4003cbab-eac0-456f-9d7c-8309e6f87ea8"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e1382bff-7460-4484-a203-94690bf30273"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("5b6b9ce2-c43e-4896-b22b-618a7336ee37"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a84c71ab-f4d1-4496-8634-52f55878ed15"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d37467bd-30b3-4892-a76f-92ffb4c95aa6"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("51a143c2-e460-4e4e-958e-3cca76a0b827"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("0ede4713-437e-432b-a3b6-783fdac2593b"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ee2ba6c8-4cfa-450e-ac6b-e81af4a9f15b"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("16a618b4-2f29-49c4-a10d-a39233ff80ce"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("f0525f63-50b2-458c-9226-de244ce9f091"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e631556a-87b8-4d11-b6fe-cc1be2115b08"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("2782a935-27ce-43ac-bd0d-a6a542fd2edc"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("5cf5c6ae-1681-4d4c-9608-275425c5f6f5"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("f6d06e86-a25b-4939-ac7a-0462ac0f573e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("93645a69-eac7-467d-980c-5acbab15dd5c"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("648ab01b-ca7d-4eb4-a304-23eea9bb08bb"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("29792c28-7e06-47ab-a23d-46e139493795"));
            Emergency = (ITTCheckBox)AddControl(new Guid("e615ecfd-9236-4ef3-a8b2-7d4670a9d2a8"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("a02b4ef3-5f38-418b-b7a3-b1e8ad29d82e"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("830dec53-0a19-4596-97f7-042f1820695b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c809f0f9-61e5-4fba-bcc7-715193fc678c"));
            labelRoom = (ITTLabel)AddControl(new Guid("1b2b67f1-f31d-4a09-bc5d-711b4bc79f40"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("9d7a9596-99d7-4d3a-99fa-27c357a053e1"));
            TabOperative = (ITTTabControl)AddControl(new Guid("b7e2ffce-3501-4b96-88a0-5483efa9c533"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("b5a0db6c-ce7c-4696-8365-081e34b6d125"));
            SubSurgeryReport = (ITTRichTextBoxControl)AddControl(new Guid("c8b114ec-63b2-4b4a-9b31-0e738c06c63b"));
            SurgeryReportDate = (ITTDateTimePicker)AddControl(new Guid("04269a8b-75b0-42b7-a3d0-08c725bc586e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b7eeb9bb-2675-4768-9971-c7f904e4ab1f"));
            PreOperativeInfo = (ITTTabPage)AddControl(new Guid("d4c63bad-076a-45a9-8e08-e75b2ed5c3db"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("f33c5811-6b7b-43d8-98d5-e19973a1a274"));
            PreOpDescriptions = (ITTRichTextBoxControl)AddControl(new Guid("ea79d4d9-357c-483f-90f0-e99410e0a3b9"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("3c2571cb-4a93-47a7-85d3-1cfeccda6270"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("1a7ef873-6966-4a2c-98e9-76a30d895fcf"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("42551ff3-5ca9-45da-b39f-3456f16aefba"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("deea2e79-cf7e-44df-839d-762c54d3aeeb"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("0fe086a2-3cc8-417a-82de-3bc74ec9902b"));
            lebalReasonOfCancel = (ITTLabel)AddControl(new Guid("ca8d93b7-08ad-4654-9d46-b58b6f92203e"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("f21ef4b5-a8e3-481a-86cc-d45643059244"));
            base.InitializeControls();
        }

        public SubSurgeryForm() : base("SUBSURGERY", "SubSurgeryForm")
        {
        }

        protected SubSurgeryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}