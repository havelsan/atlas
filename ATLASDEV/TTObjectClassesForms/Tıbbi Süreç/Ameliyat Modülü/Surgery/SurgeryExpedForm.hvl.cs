
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
    public partial class SurgeryExpedForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTCheckBox SurgeryTemplate;
        protected ITTButton getSurgerySablonButton;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage SurgeryExpend;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn CMActionDate;
        protected ITTListBoxColumn CAStore;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn CAAmount;
        protected ITTTextBoxColumn DonorID;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTabPage DirectPurchaseTab;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTTextBox EpisodeId;
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
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        override protected void InitializeControls()
        {
            SurgeryTemplate = (ITTCheckBox)AddControl(new Guid("1e139e14-3b16-4768-b0e9-8e985592ae5a"));
            getSurgerySablonButton = (ITTButton)AddControl(new Guid("0d4c5d99-0416-4dc7-8d51-6c79c9657a5d"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("aeac9944-0b66-4f54-acdc-2e9546635007"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("ba835e4c-7ce7-4f35-926b-0697628ae170"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("572b48d2-3fa9-4fca-946a-696cbf7e77bc"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("506c5dba-8911-4732-a24b-aee3ac7acf19"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("26d15f1d-22fa-49aa-9ec2-53f0515116b8"));
            SurgeryExpend = (ITTTabPage)AddControl(new Guid("23a07cc1-9990-44c0-95d4-860433ccc549"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("320721cf-9862-457b-8314-bbdb88d1d093"));
            CMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("c10156ad-6b38-4af8-98f6-d62900527b17"));
            CAStore = (ITTListBoxColumn)AddControl(new Guid("66db4cef-729a-4c4e-8777-93875f9e86ef"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("5dd8b128-e331-4d45-96f9-ed3693a76fa7"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("9f233218-7099-429a-8c29-1aea68b10e7f"));
            CAAmount = (ITTTextBoxColumn)AddControl(new Guid("2b300a85-29ea-48ad-ae7b-7e33bf3ab7d0"));
            DonorID = (ITTTextBoxColumn)AddControl(new Guid("d2f3ac58-621e-40ba-b103-6f6607ec0114"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("806027ef-5072-492b-890e-b16a187c1cda"));
            DirectPurchaseTab = (ITTTabPage)AddControl(new Guid("0dd1c6b4-453b-4164-b760-064f604819c6"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("61b4d159-ce26-400b-85d5-efd2574789e7"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("ff247c58-afd8-4590-9511-cf77af7d20aa"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("434acbdb-9af3-44ee-b8d0-2e6ae0ff7845"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("359c6d9b-9e9b-41a2-b5ec-33854db171dd"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("02750a3f-27ef-45d2-9981-99833efa15ae"));
            EpisodeId = (ITTTextBox)AddControl(new Guid("cade4c35-ebb9-4061-afe5-b727776a4326"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("bc3988c9-cac2-4950-9c90-7ecf7e684f63"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("6815f091-e0e6-4723-b412-46a721baf0c6"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("eacd6644-9980-4901-8a59-1c055101030c"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("de3551cb-7685-4afb-a929-b2b099c9e3ea"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("ba37fb82-551d-4897-85ec-59f8134107c2"));
            Emergency = (ITTCheckBox)AddControl(new Guid("ee8c693b-b36e-405f-a7bd-e4571cca61cd"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("028923d2-37c7-4dbe-8106-c6caf2f83d6c"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("b6221058-fe59-459f-8d78-ad0ee656df27"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8af12e51-4bff-416c-8bb9-4e27cc416440"));
            labelRoom = (ITTLabel)AddControl(new Guid("48e36f39-6c6e-4cac-a6b6-b55e4e7bc044"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("1f01694b-61c7-42f9-b957-18084fd20805"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("af6c4acd-50b2-419a-a3e0-7419342da4cd"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("2aac4882-3b8f-46aa-b100-c42a62175333"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("3f23dfff-84d1-4eb6-bb9d-d27df324edc7"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("a8fb8b10-bd7d-4f09-abe6-cbc17fda8dbf"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("f217ecbf-51af-4403-80ac-98f6e354fa95"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("78b9512b-042a-435d-941e-6de9afa37473"));
            base.InitializeControls();
        }

        public SurgeryExpedForm() : base("SURGERY", "SurgeryExpedForm")
        {
        }

        protected SurgeryExpedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}