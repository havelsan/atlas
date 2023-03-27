
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
    /// Onarım
    /// </summary>
    public partial class RepairForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTLabel labelUnitWorkLoadPrice;
        protected ITTTextBox UnitWorkLoadPrice;
        protected ITTTextBox TotalWorkLoad;
        protected ITTLabel labelTotalWorkLoad;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn Desc;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn UsedMaterial;
        protected ITTTextBoxColumn UsedRequestAmount;
        protected ITTTextBoxColumn UsedSuppliedAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTabPage tttabpage3;
        protected ITTGrid NeededMaterials;
        protected ITTTextBoxColumn MaterialNameNeededMaterials;
        protected ITTTextBoxColumn PartNumberNeededMaterials;
        protected ITTTextBoxColumn MaterialAmountNeededMaterials;
        protected ITTTextBoxColumn MaterialUnitPriceNeededMaterials;
        protected ITTTextBoxColumn MaterialTotalPriceNeededMaterials;
        protected ITTListBoxColumn UsedConsumedMaterailNeededMaterials;
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox RepairNotes;
        protected ITTTextBox Description;
        protected ITTTextBox tttextbox3;
        protected ITTToolStrip tttoolstrip2;
        protected ITTObjectListBox Stage;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelToResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTObjectListBox ToResource;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel2;
        protected ITTLabel GuaranyStatuslabel;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FixedAsset;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTLabel labelFromMilitaryUnit;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox UpperStage;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage UserMaintenanceTabPage;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn UserParameter;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn UserDescription;
        protected ITTTabPage UnitMaintenanceTabPage;
        protected ITTGrid UnitMaintenances;
        protected ITTListBoxColumn UnitParameter;
        protected ITTCheckBoxColumn UnitChecked;
        protected ITTTextBoxColumn UnitDescription;
        protected ITTTabPage ContensTabPage;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTabPage DemandTabPage;
        protected ITTButton cmdForkDemand;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox PurchaseItem;
        protected ITTRichTextBoxControl DetailDescription;
        override protected void InitializeControls()
        {
            labelUnitWorkLoadPrice = (ITTLabel)AddControl(new Guid("a401497f-b569-4d03-b2f4-1b96053a5fbc"));
            UnitWorkLoadPrice = (ITTTextBox)AddControl(new Guid("7852b401-5574-46f6-957f-67bb398c38ad"));
            TotalWorkLoad = (ITTTextBox)AddControl(new Guid("b1fba382-c1f7-4b48-9deb-93f09ffb199f"));
            labelTotalWorkLoad = (ITTLabel)AddControl(new Guid("82a802d3-67a7-4c00-9751-fe7300359cfe"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("43a9f147-8833-40c2-be88-0e64f02f6ebe"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("a11a4721-55d2-4211-a2f9-93d044e634ea"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("32c76265-2005-426a-878a-c5a0344ffa7b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("1f7cae38-5d3f-4c72-8ccf-024764680fcd"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("a308d385-6336-45da-a2c0-aa1ee5d43041"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("f415a5dc-df6a-4bfc-978d-de3db773b5a5"));
            Desc = (ITTTextBoxColumn)AddControl(new Guid("b0d22000-78cc-4bb3-86ab-48b5e406ad46"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("8a3a2a5f-a030-4078-8c05-78308d078554"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("490b5c55-86c7-4163-8628-c6e9c243e042"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("084b9c05-39c1-49bd-9dd7-a2da844733fc"));
            UsedRequestAmount = (ITTTextBoxColumn)AddControl(new Guid("ad1202c0-30b7-4177-9da9-a522b8b3c09b"));
            UsedSuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("03a11791-5ac6-4bc2-b1c1-7c4083116ebc"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("dd5ac1f5-6961-4055-b6f8-0bc8221e29e3"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("f5d0edd1-faa2-407d-9a2d-16301a697411"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("6922652f-7154-49b6-a554-ee0ef436f4d1"));
            NeededMaterials = (ITTGrid)AddControl(new Guid("c2ce28f3-5348-4fdc-b8e6-92c55781cb1c"));
            MaterialNameNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("c18bf7fe-c33c-470f-8d2f-b2b8817a3cf0"));
            PartNumberNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("8ea66a06-404e-4081-9a05-aa75a58725c6"));
            MaterialAmountNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("77af0e0f-a9e5-45c1-af83-ce4cb83fb6ab"));
            MaterialUnitPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("d4a0b3ca-653e-4fd0-831c-3fe41a20fdef"));
            MaterialTotalPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("9f0a5812-be11-4198-a161-09f0daf8c54a"));
            UsedConsumedMaterailNeededMaterials = (ITTListBoxColumn)AddControl(new Guid("6ee7273d-c2bb-4b68-9620-46402934b704"));
            RequestNO = (ITTTextBox)AddControl(new Guid("951273d5-74c3-417a-a864-1458bdbcd9a5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("b0e31efe-6342-40c3-a327-2fd71623ce47"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("08b5d79c-84d4-4aa3-8c2e-474b298a0765"));
            RepairNotes = (ITTTextBox)AddControl(new Guid("ef4a9fb6-897d-4073-a2fa-5974d7766f99"));
            Description = (ITTTextBox)AddControl(new Guid("240126b8-01a8-482e-a2c8-7143cf9b6458"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("442b4508-0660-4e3d-92d6-8cb2e8bc4879"));
            tttoolstrip2 = (ITTToolStrip)AddControl(new Guid("e22b98bc-9fcd-4ada-a2c0-0500e449a995"));
            Stage = (ITTObjectListBox)AddControl(new Guid("d9087cc0-905e-4416-8017-a6a3d193d09f"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("8676dde8-3c61-4bab-aaf2-02b7ba3d036f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("60df0884-fbf9-4ccd-99d6-f57fa34210b2"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("edd2b3c5-e814-407f-87a2-32bd083dc85b"));
            labelToResource = (ITTLabel)AddControl(new Guid("3c4dee56-bdc9-4aac-aa51-0b1bbca366dd"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("8bf4e358-889d-475d-8f09-0b7449f76854"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("337a0ca5-983a-450a-91dd-12df238f01f9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2fe78ccf-ba3c-48b7-a8a1-1a7e1f30bf9a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("584be9f9-330d-4fee-8a6d-37eedb037a9b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4994f13c-3ae7-4163-a0d4-3d7e47cbd11e"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("5dc90b2c-d800-4c92-8061-44970a6d6b9f"));
            labelDescription = (ITTLabel)AddControl(new Guid("f77a441e-7ea8-43b2-b31a-4e47c59db344"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f5dceef6-7a8d-4a20-aa3c-4ffddd446ffc"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("515a9ea7-e036-4a81-8ee4-51b0b2380515"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("b596e06a-bf51-4d6e-aa29-5311d4892b7b"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("3857d17d-49de-4dd9-a971-586ddd6abde4"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("46b28a3e-d7b9-49b1-9f21-79fdd286318a"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("19afd7fc-9e67-4771-b98f-7dfbada81ae0"));
            labelStartDate = (ITTLabel)AddControl(new Guid("dff7a291-ecef-4a7d-a702-811d8311a597"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("c2860c8d-8a7d-430b-921e-8acbf52f491d"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("52412930-a3a9-4695-b020-a451afc919c2"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8e23d9ed-f2fd-4571-a46d-af5cd1394705"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("e484cde0-e3b7-4f88-934c-af7ab944b886"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("7a62853d-40a1-48eb-8585-b2e1c46df910"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("036aa7be-a176-4d9e-8612-bfd10c191ada"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("318d49d6-a5de-4179-ad18-cfdbc0467ca9"));
            labelFromResource = (ITTLabel)AddControl(new Guid("b137a6ce-d10a-48f6-a04b-e29d708ac6ce"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d473c9fd-e275-48ce-a901-ea801b2697f5"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("4e6fc398-efc0-4806-ae7a-95c2817e0142"));
            labelFromMilitaryUnit = (ITTLabel)AddControl(new Guid("7d6945d4-d239-4d81-ad91-9cdd13b13764"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("bd702261-9c17-4aef-82b6-fe96d42e96fb"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("8cf001ca-4b33-46f9-b1f1-9aad1f98f2c4"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("e5f37962-555a-4856-b9c3-e609134d37ea"));
            UpperStage = (ITTObjectListBox)AddControl(new Guid("71a70470-ed67-4f02-94c0-b022a4b39d2a"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("f251736a-136b-4771-8bdb-2166cfa5a436"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("a1563490-92f7-4db6-b87c-8cf62404b734"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("c53c10b8-b438-4386-8e1f-595a61a814da"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("6db12f69-718e-4e61-b535-c7796ec7f640"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("346e47bf-c957-4026-a287-07c5f66b6815"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("7555f23e-3b57-4e2b-bffd-ec4abdd4c544"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("e08a41af-bda2-4838-a8a8-a37ba81d1830"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("e9cc7f2f-9714-4138-9e7d-cf6ed9ab3855"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("cdc3fa43-2636-429f-a8db-d3aa622864bd"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("4b079135-a5bb-4a14-ab4d-86696e96d10d"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("42a3c337-060d-4d31-b465-7d06690415c3"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("47fdf32d-9817-4ca7-a6aa-7d4662a507b9"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("e0395a06-c217-43a2-a4e1-0d2e58393343"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("adaed87c-5039-497b-9bb5-010d2441c7c2"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("a55d2a2c-a8ac-4c44-b39b-7466b703414c"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("79516984-22ef-4eb6-bd77-05d44bc4b26b"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("a05ac5fe-d619-411e-a4da-65e646f80093"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("f1a3f867-d6ed-459c-b6cb-ffa2a495ea89"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("4e7cc94e-b63d-4f49-904b-0f178c9670d4"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("463d9246-1c4d-471c-a2e8-4518210889f5"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("dc31a3cc-4640-4f82-b4d7-03673d1d4c42"));
            DemandTabPage = (ITTTabPage)AddControl(new Guid("0a624167-f35e-47da-af5c-b8b261ef5c12"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("6ee39c50-a032-4dd8-a0d1-2a42872f3c2e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("19aba8b1-5ea3-42ca-8106-e90111469397"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("595937ef-c425-45ed-a447-4eaf134efe56"));
            DetailDescription = (ITTRichTextBoxControl)AddControl(new Guid("eae4c1d4-698c-4f5d-acb5-a42fae69479c"));
            base.InitializeControls();
        }

        public RepairForm() : base("REPAIR", "RepairForm")
        {
        }

        protected RepairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}