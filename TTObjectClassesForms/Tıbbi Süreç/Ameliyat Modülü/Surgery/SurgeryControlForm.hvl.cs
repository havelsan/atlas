
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
    public partial class SurgeryControlForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTTabControl Ameliyat;
        protected ITTTabPage SurgeryProcedures;
        protected ITTGrid GridSurgeryProcedures;
        protected ITTDateTimePickerColumn CAActionDate;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTEnumComboBoxColumn IncisionType;
        protected ITTEnumComboBoxColumn Position;
        protected ITTListBoxColumn EntryDepartment;
        protected ITTListBoxColumn ProceduerDoctor1;
        protected ITTListBoxColumn ProcedureDoctor2;
        protected ITTListBoxColumn PackageProcedureObject;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTRichTextBoxControlColumn DescriptionOfObj;
        protected ITTTextBoxColumn SutPoint;
        protected ITTTextBoxColumn GilPoint;
        protected ITTButtonColumn EuroScoreButton;
        protected ITTTabPage AllSurgeryReports;
        protected ITTRichTextBoxControl TTRichTextBoxUserControl;
        protected ITTGrid GridSurgeryReports;
        protected ITTListBoxColumn Department;
        protected ITTListBoxColumn SubSurgeryProcedureDoctor;
        protected ITTRichTextBoxControlColumn SubSurgeryReports;
        protected ITTTabPage AnesthesiaInfo;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGrid GridAnesthesiaProcedures;
        protected ITTDateTimePickerColumn ACActionDate;
        protected ITTListBoxColumn ACProcedureObject;
        protected ITTListBoxColumn ACProcedureDoctor;
        protected ITTTextBoxColumn ACNote;
        protected ITTLabel labelAnesthesiaStartDateTime;
        protected ITTDateTimePicker AnesthesiaEndDateTime;
        protected ITTLabel labelAnesthesiaEndDateTime;
        protected ITTDateTimePicker AnesthesiaStartDateTime;
        protected ITTEnumComboBox AnesteziTeknigi;
        protected ITTLabel ttlabel3;
        protected ITTTabPage SurgeryTeam;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn CARole;
        protected ITTTabPage SurgeryExpand;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn CMActionDate;
        protected ITTListBoxColumn CAStore;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn CAAmount;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTabPage DirectPurcahse;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTTextBox ComplicationDescription;
        protected ITTTextBox SurgeryTotalPoint;
        protected ITTTextBox AnesthesiaPoint;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox EpisodeId;
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
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        protected ITTLabel labelComplicationDescription;
        protected ITTCheckBox IsComplicationSurgery;
        protected ITTLabel labelSurgeryTotalPoint;
        protected ITTLabel lableAnesthesiaPoint;
        protected ITTLabel lebalReasonOfCancel;
        protected ITTGrid GridParticipantDepartmants;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTListBoxColumn ResponsibleDoctor;
        override protected void InitializeControls()
        {
            Ameliyat = (ITTTabControl)AddControl(new Guid("51ac1596-4a95-44f3-b4af-3e3c34ee1fda"));
            SurgeryProcedures = (ITTTabPage)AddControl(new Guid("0fb87337-eea8-4c67-b87f-0ed21ea81c4c"));
            GridSurgeryProcedures = (ITTGrid)AddControl(new Guid("1a94b6aa-5549-4393-be09-99e106decdca"));
            CAActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("6d4ec6ca-9586-47d0-b251-ff683026fee2"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("13cba8d0-2042-402f-bcd4-e1a0329309c9"));
            IncisionType = (ITTEnumComboBoxColumn)AddControl(new Guid("f9f37610-a63f-4cbe-b3ed-0858b8d1c0e8"));
            Position = (ITTEnumComboBoxColumn)AddControl(new Guid("20855b19-e288-4cb6-a05b-b7331ca4b557"));
            EntryDepartment = (ITTListBoxColumn)AddControl(new Guid("c2d5b9c4-6d5a-4abb-a518-d95479d743f9"));
            ProceduerDoctor1 = (ITTListBoxColumn)AddControl(new Guid("aedff611-2a86-4d22-bf11-a4a3858d8021"));
            ProcedureDoctor2 = (ITTListBoxColumn)AddControl(new Guid("81b53b5b-75dd-42e9-a386-c8e0540a7ccc"));
            PackageProcedureObject = (ITTListBoxColumn)AddControl(new Guid("43f0e1a7-6196-41b6-a1cc-bf27e027779d"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("7b921a01-22f9-4f17-8e70-586ea8fc0c05"));
            DescriptionOfObj = (ITTRichTextBoxControlColumn)AddControl(new Guid("9253a85a-f4e1-4a87-8ff4-e83f14260eec"));
            SutPoint = (ITTTextBoxColumn)AddControl(new Guid("dd1fa6af-cb6a-4366-83a4-fa98a4e29606"));
            GilPoint = (ITTTextBoxColumn)AddControl(new Guid("4408e6b1-8d45-4002-abdd-88268010e519"));
            EuroScoreButton = (ITTButtonColumn)AddControl(new Guid("5ba1df3f-884f-47e1-aacc-d90c3f0268d1"));
            AllSurgeryReports = (ITTTabPage)AddControl(new Guid("bb6f6bc2-1b58-44c7-bc49-cf375689611b"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("1cb335f8-06f4-414b-b8ac-057bcef25644"));
            GridSurgeryReports = (ITTGrid)AddControl(new Guid("f7dfa511-e53d-408e-858c-1d75d040579d"));
            Department = (ITTListBoxColumn)AddControl(new Guid("a2e02601-4974-49f2-ab66-2774ca2557ce"));
            SubSurgeryProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("aeb77a6c-e970-4113-9fcd-5094d14c8e93"));
            SubSurgeryReports = (ITTRichTextBoxControlColumn)AddControl(new Guid("ca5c1487-aaab-4458-99f9-d90170d8522a"));
            AnesthesiaInfo = (ITTTabPage)AddControl(new Guid("305ac183-4e51-43be-9456-4147ffaf9d26"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("c7f383c7-d674-404d-8f17-bea8b472631c"));
            GridAnesthesiaProcedures = (ITTGrid)AddControl(new Guid("6a8b1065-58cb-47da-ac24-4de9c03a8cd0"));
            ACActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("41729740-7415-4271-8ade-dd3b556e5bfd"));
            ACProcedureObject = (ITTListBoxColumn)AddControl(new Guid("78c264be-2528-46dd-9f08-ccb8801b7525"));
            ACProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("4dcc8d37-bc5f-486d-b738-91fd8c3ffbc5"));
            ACNote = (ITTTextBoxColumn)AddControl(new Guid("bbf6e918-e968-46a5-9797-71df7e578045"));
            labelAnesthesiaStartDateTime = (ITTLabel)AddControl(new Guid("0b3638f5-1e71-475d-b2cf-44fb5308633e"));
            AnesthesiaEndDateTime = (ITTDateTimePicker)AddControl(new Guid("41cfcd7a-c2fc-4549-9926-a8eb5aa40747"));
            labelAnesthesiaEndDateTime = (ITTLabel)AddControl(new Guid("4d913ae9-be7b-4bd0-966e-60ec067181b1"));
            AnesthesiaStartDateTime = (ITTDateTimePicker)AddControl(new Guid("16900fe7-6129-4b69-9cb9-f72c11385f08"));
            AnesteziTeknigi = (ITTEnumComboBox)AddControl(new Guid("6c5b6dcb-71b0-4a50-826b-c8cac69749c2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8e0a7eea-d39a-402c-b49e-ef1c25680a44"));
            SurgeryTeam = (ITTTabPage)AddControl(new Guid("e4d4132b-a1ae-4267-ae75-544444fc4b6a"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("6ea9ec31-af53-48fd-8433-98f60090ec65"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("12c08fb2-760e-4f28-be65-9e4d5d965491"));
            CARole = (ITTEnumComboBoxColumn)AddControl(new Guid("160c493b-1f91-4d61-9b3e-4aae9f0787f0"));
            SurgeryExpand = (ITTTabPage)AddControl(new Guid("8e1726a5-bc92-44a3-a1c2-321c416768cc"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("bc2481d3-ee7b-4282-b6a0-d21c398e6260"));
            CMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("5b56ef9b-5ac5-4ebf-8e45-3de151cc9574"));
            CAStore = (ITTListBoxColumn)AddControl(new Guid("92d70282-a768-477e-8309-aaf101a7373e"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("06a9c78b-f6d9-4966-84ee-2ca4ac7649ef"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("45bad92a-28e9-499a-8f68-bed6f46696f9"));
            CAAmount = (ITTTextBoxColumn)AddControl(new Guid("360c0594-05d3-4c7a-a4b4-cf270cd2f29a"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("3d8f36f6-3cc7-4373-8582-2afa2c41c50c"));
            DirectPurcahse = (ITTTabPage)AddControl(new Guid("2a4ae740-22ad-4b0f-b4a4-525ee0233e55"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("fbdeb8e0-7584-41af-ae0e-0ffd27231368"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("9275327d-4dd1-4d5d-a332-fa9a1e581e3b"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("2bcb9289-de2f-4a8b-81cd-3389623a565a"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("7ec32a19-377a-4a35-8e07-1f718e840b05"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("04dfadd8-d32b-41bf-82dd-e81187828c3d"));
            ComplicationDescription = (ITTTextBox)AddControl(new Guid("f8297292-7cca-48fc-b0aa-54b61a687221"));
            SurgeryTotalPoint = (ITTTextBox)AddControl(new Guid("0366e45c-de8c-446a-a7da-0bdf84b2a727"));
            AnesthesiaPoint = (ITTTextBox)AddControl(new Guid("ab1c8b4e-473b-40f1-b1d9-7beaf0e1acab"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("f78d4844-8b20-44b5-916e-f09b7d258761"));
            EpisodeId = (ITTTextBox)AddControl(new Guid("2f2b2291-aa9a-4bb6-abaf-5c8bb22ec0e9"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("0717bd87-bf94-4850-bdac-e93e11390a2b"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("7bba097a-4301-426d-aa57-31d37d51fe58"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("beb90be1-8134-4c22-b9e9-de3fd9efa87e"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("339a56e7-a159-4c22-b169-87accb4cd016"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a108d8a5-1be6-4144-9a2e-c2b73929f244"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("9d6da240-b546-4dcd-af92-76b88f5b7d74"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a7141ace-0b4f-450f-9b2c-15a17d0a424d"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("7c2a6224-6d86-4cc9-b587-c478f93ccba4"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("2c2d6ee0-feeb-4128-911f-60b57ec76b71"));
            Emergency = (ITTCheckBox)AddControl(new Guid("2e02abbb-b685-4965-aae6-31c74c9071f5"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("dde43707-ff32-4e3f-8465-dd3d0787d53c"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("473aa645-1e02-4e7e-adc2-9133d8fb21cc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2c7ef4fd-d8e9-46ec-9470-452ba7696c25"));
            labelRoom = (ITTLabel)AddControl(new Guid("4b7421f9-d4c1-40bf-8594-f9d3338fb3e7"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("fef898fc-acfb-492e-8bd5-9fec42b5b087"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("4c1d4c39-9c91-465d-b070-68a21867ce83"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("08119620-a0ac-4984-94ca-55a4336b388d"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("f7c16fc2-036a-4ba7-9e89-33262d96f83f"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("20a081c7-e7df-4d1a-88db-ff4fde881d1c"));
            labelComplicationDescription = (ITTLabel)AddControl(new Guid("b217bc27-3aab-4fc9-b3a0-018a8263d7b1"));
            IsComplicationSurgery = (ITTCheckBox)AddControl(new Guid("3907a3da-7041-46ba-95ab-11b42041e21b"));
            labelSurgeryTotalPoint = (ITTLabel)AddControl(new Guid("388ec927-7c50-48bc-b78f-02b2146d56b1"));
            lableAnesthesiaPoint = (ITTLabel)AddControl(new Guid("196f3cb6-9394-45f9-8756-8e7b740612a8"));
            lebalReasonOfCancel = (ITTLabel)AddControl(new Guid("08b833e8-8800-4f07-838d-479e2dfd09fe"));
            GridParticipantDepartmants = (ITTGrid)AddControl(new Guid("da7545de-5402-4c1a-b4c8-ffd84c11951f"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("f66d7eed-53d4-4f53-923b-79542d20c719"));
            ResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("b9c7bdcb-d268-4411-8471-fe98268b9174"));
            base.InitializeControls();
        }

        public SurgeryControlForm() : base("SURGERY", "SurgeryControlForm")
        {
        }

        protected SurgeryControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}