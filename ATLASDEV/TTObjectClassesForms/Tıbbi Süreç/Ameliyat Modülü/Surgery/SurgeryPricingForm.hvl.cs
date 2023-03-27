
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
    /// Ameliyat Ücretlendirme 
    /// </summary>
    public partial class SurgeryPricingForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTLabel labelMedulaAciklamasi;
        protected ITTTextBox MedulaAciklamasi;
        protected ITTTextBox SurgeryTotalPoint;
        protected ITTTextBox AnesthesiaPoint;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel3;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage SurgeryProcedures;
        protected ITTGrid GridSurgeryProcedures;
        protected ITTDateTimePickerColumn CAActionDate;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTEnumComboBoxColumn IncisionType;
        protected ITTEnumComboBoxColumn Position;
        protected ITTListBoxColumn PackageProcedureObject;
        protected ITTListBoxColumn PackageSubEpisode;
        protected ITTDateTimePickerColumn PackageStartDate;
        protected ITTDateTimePickerColumn PackageEndDate;
        protected ITTRichTextBoxControlColumn DescriptionOfObj;
        protected ITTListBoxColumn EntryDepartment;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTEnumComboBoxColumn Euroscore;
        protected ITTListBoxColumn OzelDurum;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTextBoxColumn Aciklama;
        protected ITTListBoxColumn DrAnesteziTescilNo;
        protected ITTButtonColumn ToothSchema;
        protected ITTTextBoxColumn ToothNumber;
        protected ITTCheckBoxColumn ToothAnomaly;
        protected ITTTextBoxColumn ToothCommitmentNumber;
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
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox AnesteziTeknigi;
        protected ITTTabPage SurgeryTeam;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn CARole;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker3;
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
        override protected void InitializeControls()
        {
            labelMedulaAciklamasi = (ITTLabel)AddControl(new Guid("60a47e19-1c25-4929-b295-0854681be53c"));
            MedulaAciklamasi = (ITTTextBox)AddControl(new Guid("29b689e2-0c6f-42f0-9dab-882cebf91012"));
            SurgeryTotalPoint = (ITTTextBox)AddControl(new Guid("ec9f347e-26c8-4e05-bf66-0561d100e8b7"));
            AnesthesiaPoint = (ITTTextBox)AddControl(new Guid("e36a622c-d239-44d9-a97a-bd293782d907"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f4398695-d9ea-4d30-ab04-21d844c126dc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("66d9f371-6f86-428c-aada-196d0c695256"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("5cbf36f2-0b39-4f9f-b41b-b033455b3bfb"));
            SurgeryProcedures = (ITTTabPage)AddControl(new Guid("c3ef5134-f7c8-4022-9232-a5eccf0c8f2f"));
            GridSurgeryProcedures = (ITTGrid)AddControl(new Guid("ec1ffe07-8ca7-47b5-bdc7-82fcdcc37d8c"));
            CAActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("6d55845d-d36d-474e-9b39-22c8a4a9a815"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("bc30a491-975c-4c2f-8cc0-d2f16537eeba"));
            IncisionType = (ITTEnumComboBoxColumn)AddControl(new Guid("8cd42f44-4f23-41d2-9e0e-f8f1d779f7ec"));
            Position = (ITTEnumComboBoxColumn)AddControl(new Guid("e3ee333e-1efa-4b06-8885-59aab76f412e"));
            PackageProcedureObject = (ITTListBoxColumn)AddControl(new Guid("7e762d6a-b532-4587-a76c-41c6b9b175ef"));
            PackageSubEpisode = (ITTListBoxColumn)AddControl(new Guid("27dd5303-7b8c-462c-975e-332200ed2adb"));
            PackageStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("27216ec8-77ab-45b6-9d82-d43d691c6d9e"));
            PackageEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("5a03b44f-d8a0-471a-8264-e40d7b283939"));
            DescriptionOfObj = (ITTRichTextBoxControlColumn)AddControl(new Guid("06c60ee9-e3aa-4a43-bbff-568cbb0b2cb8"));
            EntryDepartment = (ITTListBoxColumn)AddControl(new Guid("6bf2bb0a-31cf-40a8-9f39-235d14c335b2"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("26013611-d836-4da4-8453-19b6b83b55a9"));
            Euroscore = (ITTEnumComboBoxColumn)AddControl(new Guid("c26fc9c6-2f82-41f6-89d6-12de1323c0b1"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("9b6e5846-cc80-4912-a6fd-747eac8e0e64"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("73a288b0-5026-4335-9dd7-63b715430fe8"));
            Aciklama = (ITTTextBoxColumn)AddControl(new Guid("c39af859-6412-49e1-b62c-944586529dbb"));
            DrAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("7cd74837-9f67-4bc1-8d1a-9ca565d52b31"));
            ToothSchema = (ITTButtonColumn)AddControl(new Guid("78095643-2c73-4d3b-a690-66a78c0d7854"));
            ToothNumber = (ITTTextBoxColumn)AddControl(new Guid("336dc02a-bdac-4dc0-a69f-5d41e53f29d6"));
            ToothAnomaly = (ITTCheckBoxColumn)AddControl(new Guid("52765896-4990-4b28-aa3b-2d69234cf260"));
            ToothCommitmentNumber = (ITTTextBoxColumn)AddControl(new Guid("444fcfc1-a918-4d2a-a97a-2b3fe46ed0fe"));
            AllSurgeryReports = (ITTTabPage)AddControl(new Guid("92994ffb-37c4-42db-a61d-b9c5e1a95076"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("7520fc52-4938-438a-afd7-3b7cf15863ef"));
            GridSurgeryReports = (ITTGrid)AddControl(new Guid("db18862c-fe93-4aa2-8fbc-671f649a2afc"));
            Department = (ITTListBoxColumn)AddControl(new Guid("8377f2bc-313a-478f-a559-23939386801b"));
            SubSurgeryProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("f599e123-4f26-4d30-80f3-64bfe0540734"));
            SubSurgeryReports = (ITTRichTextBoxControlColumn)AddControl(new Guid("c37882c3-f60b-4f8f-be2c-f1b8f3ed79a9"));
            AnesthesiaInfo = (ITTTabPage)AddControl(new Guid("2f41d31d-306f-4b1d-a6b6-024f0bf5328d"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("62909ca3-73df-4d3f-9563-e43dc8497130"));
            GridAnesthesiaProcedures = (ITTGrid)AddControl(new Guid("b12fdc5a-f2c0-47e6-96f7-fbd6bac5820b"));
            ACActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("79113414-afa9-4fe2-85f0-162f26a09d69"));
            ACProcedureObject = (ITTListBoxColumn)AddControl(new Guid("c9be3334-6dd9-4da8-8290-df511c11b82d"));
            ACProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("700f28fa-e847-44f8-a910-10904df4fe0c"));
            ACNote = (ITTTextBoxColumn)AddControl(new Guid("588d3113-7282-4d52-97ac-93730c577741"));
            labelAnesthesiaStartDateTime = (ITTLabel)AddControl(new Guid("2fc36dd1-07a6-4fd8-986e-64d1f536ea51"));
            AnesthesiaEndDateTime = (ITTDateTimePicker)AddControl(new Guid("fa2fbfe9-27f4-4c67-8df9-b43f2ddf5e6d"));
            labelAnesthesiaEndDateTime = (ITTLabel)AddControl(new Guid("999566eb-c3d4-490b-baec-9065e7c4cf02"));
            AnesthesiaStartDateTime = (ITTDateTimePicker)AddControl(new Guid("0e930482-8038-43ed-a241-a1f7f9234452"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("fb484f27-c00d-4e7d-97f6-6f96adbef8a8"));
            AnesteziTeknigi = (ITTEnumComboBox)AddControl(new Guid("d647fcdc-7eb7-406b-b637-5316f9d10e42"));
            SurgeryTeam = (ITTTabPage)AddControl(new Guid("30f09e23-42d1-4cda-8a3d-fb23b7a50ccb"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("d8c78628-2b73-4bbd-8cf5-f25553ea2c40"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("bdc71d87-85c0-4efc-8a8a-d34d7f8e8b56"));
            CARole = (ITTEnumComboBoxColumn)AddControl(new Guid("8376b0c4-0881-457c-bc83-6e63c931dcf6"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("5c8c41a7-606e-4a7f-b886-605146f937ec"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("fa625258-9352-47ec-8c75-cf6b6825d8f9"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("fcc413d3-82ce-4f1e-bad4-4a16f57b63fe"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("dd2671c0-c3b9-4839-97ea-b9c4d68d57f7"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("74da96a0-8310-4a67-91f7-196251ceeb49"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("e501d076-f576-4973-bb33-e72e15826cbf"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("0068ace4-2ef5-4a7d-8042-933649bf6a39"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("42f4f125-2c03-4b07-9f2a-e9ca5e596938"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("230a3477-31be-446b-8a91-7acaae078b9b"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("b6c92ecc-f279-47e9-a568-749a2ffee7f9"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("fd6db9fa-b519-4ad4-839f-b9fa6a5ffc0d"));
            Emergency = (ITTCheckBox)AddControl(new Guid("cd305b42-b423-44a6-b130-1e5effd1ca2d"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("9f4c5ab3-1b57-4381-881d-e49dfe33f50e"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("f3d85958-b3ba-4769-837f-39be5f7b48c4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("07e98dfd-97c3-4496-aa5f-dd04c6567d3f"));
            labelRoom = (ITTLabel)AddControl(new Guid("bd6e130b-3fed-4532-8d0c-b5c441a16216"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("2d375048-365f-4c9b-b7b6-74178caf4bce"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("e9764588-2bbe-4546-80a3-fe2a8c438dc6"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("36d2d443-ad8d-4331-a04c-a1b0968c6711"));
            base.InitializeControls();
        }

        public SurgeryPricingForm() : base("SURGERY", "SurgeryPricingForm")
        {
        }

        protected SurgeryPricingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}