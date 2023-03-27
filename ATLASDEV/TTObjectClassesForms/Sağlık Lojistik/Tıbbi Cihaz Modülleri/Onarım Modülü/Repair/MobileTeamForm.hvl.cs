
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
    /// Seyyar Ekip
    /// </summary>
    public partial class MobileTeamForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

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
        protected ITTToolStrip tttoolstrip2;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ToResource;
        protected ITTTextBox RequestNO;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelFixedAsset;
        protected ITTTextBox tttextbox5;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel2;
        protected ITTLabel GuaranyStatuslabel;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox RepairNotes;
        protected ITTTextBox Description;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTTextBox tttextbox3;
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
        protected ITTTextBox RulStatus;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4a730dc3-2e9b-4822-91fd-606dbf5c2886"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("e1df4fd2-63f1-4f8f-999b-db5892e70fb1"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("93a29e44-5ad9-4d95-9fb4-2a28c38777a9"));
            Material = (ITTListBoxColumn)AddControl(new Guid("e4d4c910-a9e8-4af3-b84a-c28c99e922ee"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("b80626a5-b6d6-40f4-8774-e3ac5f57f98d"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("25ad2d7a-55e9-4aa0-8ce2-488eeb758c3e"));
            Desc = (ITTTextBoxColumn)AddControl(new Guid("ba600269-bbc7-4fdc-914f-a5ceb6188703"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("c6f7df5b-2184-4143-ab3b-bb8780ef1557"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("21ff173a-3e16-4e27-b33f-e7581373747f"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("5cfb549c-bde8-4cff-861e-f064bd595ae7"));
            UsedRequestAmount = (ITTTextBoxColumn)AddControl(new Guid("35d7bb85-0050-40e1-a55f-c83361b39c94"));
            UsedSuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("c43cc871-b975-4e78-a1a2-43ca94c96665"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("679ae65b-a0f5-4ceb-bb4c-c7920898c9b7"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("e52358fd-4f32-4acb-a9bd-c01fa96a9698"));
            tttoolstrip2 = (ITTToolStrip)AddControl(new Guid("ee561ac2-cfbf-4676-a6ef-fff65f9e1022"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("5859a351-3ef2-4b3c-939a-06cb33a2732a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3132225a-3334-4e2c-a3cd-a0865fd85fbc"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("0e89ad76-cd25-4beb-8413-ddac2eeebb29"));
            labelToResource = (ITTLabel)AddControl(new Guid("7203ffbc-45ba-4ed2-bd15-6d84ef55eb1c"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("d8936cf9-3bff-48b4-bcf5-859b48d01856"));
            RequestNO = (ITTTextBox)AddControl(new Guid("6a014a08-3af9-4603-8023-52168f9ecb14"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8e3303ac-4537-4398-8474-beca83bbe334"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("97e20542-6ed1-4083-b4e0-981dc751fccb"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ef2ffa07-ac4a-4d90-85c2-cebd6b88c416"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("801e16c4-d8a5-43e2-8b1d-4a48c79379f4"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("8d0d856e-3d1e-43eb-81e4-fe77243a49a7"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("474d015d-d312-4a49-8279-0a58018e5337"));
            labelDescription = (ITTLabel)AddControl(new Guid("5dbfd6c5-48b5-411b-a700-4f52d9e92e74"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c1d40ede-3c6b-457b-b01d-d877f5ecd04c"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("605b7607-74a3-4c74-9ac9-f27f3cdaa986"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("54130768-53ef-43f0-811c-2a1e702c7d41"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("7e8a5b55-a534-4b2c-87ff-50bfff8a08cf"));
            RepairNotes = (ITTTextBox)AddControl(new Guid("ebd84fae-eba4-4c9a-ae1e-918e999098bc"));
            Description = (ITTTextBox)AddControl(new Guid("1f862c4f-1fa8-40cc-b4b0-662b08d5afd0"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3c8e9ad9-9702-40ca-85e6-7334980ea1a2"));
            labelStartDate = (ITTLabel)AddControl(new Guid("44c71833-f5f0-4035-8b14-f49c1946994d"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("00baef84-4fe9-42b9-ac92-5aa1152d6709"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("e7dcc569-3077-4c13-8400-14c02c309043"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("a579e2d4-3bef-4a0f-a7b6-15ec0fab4788"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e5eb20a7-e093-418b-a5a4-b97611e8e1c5"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("7acb5dfa-2f23-49fb-9f65-617d99ebf79c"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("08db2ffe-e459-4431-b533-856ade72e0a8"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("f680d5cc-cdb9-443e-8ebb-eabe3aaea754"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("af8e9f12-03f3-4a85-a768-43e7615b0132"));
            labelFromResource = (ITTLabel)AddControl(new Guid("f8bb8308-d685-491b-9ca5-a9710f2620b2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a8acbe4d-a7b2-4baf-b5d3-074b239987ff"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("a9172290-7d50-4ac1-b270-cbb0e789ee50"));
            labelFromMilitaryUnit = (ITTLabel)AddControl(new Guid("f603fa33-d2e8-4a76-8660-db84310d24bf"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("f520f365-91cc-405f-99df-887ed59d6548"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("3e9c1806-2010-4915-af89-beeeadc55834"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("08317d0c-01cc-4e97-9cf7-667c16f30aaa"));
            UpperStage = (ITTObjectListBox)AddControl(new Guid("e1cf0089-7aab-4a70-9750-ca54d39d7186"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("334566c0-d423-48d2-bc4c-475d62391f95"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("843b861b-49f5-4692-91cc-05787e2d9d22"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("63d2e286-f35b-4b4c-8800-730161b483b8"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("7c1be8ee-e8f2-4c10-a315-7cdd7c2bb310"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("a5919027-3c62-4124-a9b7-96a0c072ccf5"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("c9023ad3-ed3d-4c27-927e-f2794e54079f"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("2228c873-5ae6-40ba-b44c-5e8f8ca09576"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("8b728cf6-c448-47c8-9f9a-72f668d97d82"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("a19acfcc-fec7-43db-83b1-38366aa34e03"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("9adce6ca-ca3a-4a84-a111-e9670c43ed4c"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("06b75076-35a7-4b6b-bc83-c160d7d3431e"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("de9ae1f2-1cc1-4fd3-a1d4-b0c0062c9933"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("9e7a22de-9ead-4444-9762-2e63fdd52f27"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("1e0921fb-a6fe-4974-9611-64139b0d0102"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("0c74ef87-2bf6-4caa-a58f-4a8c4287c376"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("666690d5-ee63-4c18-8abf-cbb1d14ed774"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("f7188e1e-0853-436b-bc54-c910e3c417b5"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("558dea5c-6231-423e-bcb0-ee16dfbaff7f"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("a0e1a296-b96e-4d0f-ab33-b5202fcfe881"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("721e3aa9-70b0-4456-81ed-4307b87afa64"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("df0ae13f-c637-4430-bb1e-8a58cad3232a"));
            RulStatus = (ITTTextBox)AddControl(new Guid("88342a65-54e8-4a8b-8a19-a516fa0165b8"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("ddf7da77-b0be-4235-aae4-980d2513e33a"));
            base.InitializeControls();
        }

        public MobileTeamForm() : base("REPAIR", "MobileTeamForm")
        {
        }

        protected MobileTeamForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}