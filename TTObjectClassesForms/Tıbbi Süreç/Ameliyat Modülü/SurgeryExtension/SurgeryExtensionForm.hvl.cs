
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
    public partial class SurgeryExtensionForm : EpisodeActionForm
    {
        protected TTObjectClasses.SurgeryExtension _SurgeryExtension
        {
            get { return (TTObjectClasses.SurgeryExtension)_ttObject; }
        }

        protected ITTGrid SurgeryExpendsSurgeryExpend;
        protected ITTDateTimePickerColumn MainSrgryActionDate;
        protected ITTListBoxColumn MainSrgryStore;
        protected ITTListBoxColumn MainSrgryMaterial;
        protected ITTTextBoxColumn MainSrgryBarcode;
        protected ITTTextBoxColumn MainSrgryAmount;
        protected ITTTextBoxColumn MainSrgryDonorID;
        protected ITTTextBoxColumn MainSrgryDistributionType;
        protected ITTGrid AllSurgeryPersonnelsSurgeryPersonnel;
        protected ITTListBoxColumn SurgerySurgeryPersonnel;
        protected ITTListBoxColumn PersonnelSurgeryPersonnel;
        protected ITTEnumComboBoxColumn RoleSurgeryPersonnel;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage SurgeryExpend;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn CMActionDate;
        protected ITTListBoxColumn CAStore;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn CAAmount;
        protected ITTTextBoxColumn DonorID;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTabPage DirectPurchaseTab;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker PlannedSurgeryDate;
        protected ITTLabel labelSurgeryEndTime;
        protected ITTDateTimePicker SurgeryEndTime;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            SurgeryExpendsSurgeryExpend = (ITTGrid)AddControl(new Guid("4ec8926b-6296-4da3-a0c7-c431861f5d06"));
            MainSrgryActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("2db83afe-9efa-4456-887f-efaf34829dfc"));
            MainSrgryStore = (ITTListBoxColumn)AddControl(new Guid("6e70edb5-69a0-455b-b72a-8e71cae78f50"));
            MainSrgryMaterial = (ITTListBoxColumn)AddControl(new Guid("7acbe019-406a-4240-a7df-a4afcd3a7be0"));
            MainSrgryBarcode = (ITTTextBoxColumn)AddControl(new Guid("9d521ffa-bb63-43b6-94e7-5658ae854225"));
            MainSrgryAmount = (ITTTextBoxColumn)AddControl(new Guid("9cb603da-7e47-4996-9a32-593555832bce"));
            MainSrgryDonorID = (ITTTextBoxColumn)AddControl(new Guid("27092cbd-c92a-42eb-af13-7d029c67d329"));
            MainSrgryDistributionType = (ITTTextBoxColumn)AddControl(new Guid("11e7dfe3-f862-4bd1-9bd4-e22afd061df6"));
            AllSurgeryPersonnelsSurgeryPersonnel = (ITTGrid)AddControl(new Guid("f25a371a-1bdf-4fd2-b964-1313200d4277"));
            SurgerySurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("ec04a17d-fe21-4513-87bf-9fa428f1b5d0"));
            PersonnelSurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("88240c38-eca0-4bfd-a270-4757bc91b531"));
            RoleSurgeryPersonnel = (ITTEnumComboBoxColumn)AddControl(new Guid("7b63d0fb-8cfd-4ed2-86c5-533b3dfa34a8"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("8d623234-973f-402f-9bfb-44623f1ec45e"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("862211d2-4b6c-4a13-a0f7-5fd74e2230a0"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("27f45931-c1f5-4877-9d7e-d702ddfd0c12"));
            SurgeryExpend = (ITTTabPage)AddControl(new Guid("aa020a88-7cd7-4651-a7eb-ee70a2cd9651"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("beee69d7-b25c-4a53-ba50-75f0b4a37c02"));
            CMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("21fbc4c5-d733-4410-a9b3-d4a0fb20659c"));
            CAStore = (ITTListBoxColumn)AddControl(new Guid("b5ac20c7-13e7-4f60-8007-371ef7112404"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("bfe72e93-e180-4b4c-9bba-a3ab5c915355"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("d721f98f-6fbb-4364-800b-0c51a39e0dff"));
            CAAmount = (ITTTextBoxColumn)AddControl(new Guid("cd328d66-725d-4e92-9bc2-8d7471331a2b"));
            DonorID = (ITTTextBoxColumn)AddControl(new Guid("5b1bb845-9fe1-42df-abc8-4cdace5e4182"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("4ce48f1e-dc55-4ee9-9377-db9b85bf8953"));
            DirectPurchaseTab = (ITTTabPage)AddControl(new Guid("7448e44b-7c9d-4ae8-a2da-70c16c245cd8"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("356e6f1b-e1a2-4719-90f3-d65133298e40"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("8e3c7218-9928-4877-8864-c931e4304d41"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("2faa6e82-48d4-4064-98e3-734c53a77d2a"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("cdbb4dc2-32e4-4cc5-9f05-a89bff814102"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("cfb60bb1-a3f5-4735-9a6f-3395f9d7d488"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("1e7133c3-3ae4-49fb-b3de-e548ca6e0f1b"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("a6b5c59d-0298-4eb9-b57f-b9ac674469f0"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("97e7b6fc-16d1-47fe-89fc-29ba560c17f9"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("0f2e11f8-23ae-43bd-b997-d8a469ce4b4f"));
            labelSurgeryEndTime = (ITTLabel)AddControl(new Guid("d332c4e6-b4e1-4991-854a-4360d041d37f"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("2f4073c2-2788-48e5-84f8-7b900fc68e28"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("ab20f1e8-d90e-4d91-a406-ea08e00ae303"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("28fd83b0-920a-49f8-9ba3-8bd46d3229ca"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("b9b5f3bd-42bc-45e4-a25f-e439cd6fe460"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("703d604a-043a-44e6-aad3-3efaaab0e551"));
            labelRoom = (ITTLabel)AddControl(new Guid("3c42b03d-e959-428d-aede-58eb677a9a0d"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("a1b520f8-4095-4b02-bb23-13b2c31baab2"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("55d54a5d-89ef-4744-af84-6a7cfb67f7c5"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("4ed7304c-9957-48ed-ad69-908e5ea99972"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("111c1f02-b8dc-4ab7-9f70-0425813d9bb1"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("10786ff4-cbc4-4028-b6c0-25390fec9d5a"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e0080f64-42a2-4d71-adfc-b8887024af43"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("185bba78-96a8-41d8-8bdb-3c95031dd098"));
            base.InitializeControls();
        }

        public SurgeryExtensionForm() : base("SURGERYEXTENSION", "SurgeryExtensionForm")
        {
        }

        protected SurgeryExtensionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}