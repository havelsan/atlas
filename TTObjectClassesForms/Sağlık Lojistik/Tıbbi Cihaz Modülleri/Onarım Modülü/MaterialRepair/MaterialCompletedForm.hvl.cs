
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
    /// Tamamlanan Onarım[Stok Numaralı]
    /// </summary>
    public partial class MaterialCompletedForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTTextBox Result;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelResult;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelEndDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox2;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTabPage tttabpage3;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTabPage tttabpage4;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("aa24218d-35fa-4fab-a08d-117e8b86c66e"));
            Result = (ITTTextBox)AddControl(new Guid("23b50036-056b-4202-a2c0-8057a44363ca"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("9955bec6-d907-4ee8-8dc8-769f68c534a0"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("7a1b82ff-b968-4d81-a690-01b1fa0306f3"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("96fb0ef0-0a23-4162-8384-91fae2e3e904"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("5828aee5-e140-4988-9c2d-deb636c5b2b7"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("b9c437f9-3a4a-4b80-989b-7dded3321d30"));
            labelFromResource = (ITTLabel)AddControl(new Guid("e6f85d81-273a-4e77-8460-6301ef2952eb"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("64266ca2-fc13-49e0-acc2-d32d92e4a829"));
            labelToResource = (ITTLabel)AddControl(new Guid("c15dd593-3352-4084-9654-a5d326e11c6b"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("eeae5622-4e2d-4a24-9e5d-5e3d03bbde40"));
            labelResult = (ITTLabel)AddControl(new Guid("a2aa1b30-e2b0-48bc-916a-c6796c7abe22"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("d1b0a1f5-60a0-4dc6-9d37-02869c9f6d24"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("c01d3845-3039-434b-9bd9-598c168b2bf8"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("5925e961-cd14-4093-a921-de8d82750927"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1cf2e874-2369-4a97-a55f-cb16fdf62a00"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("99ded6da-7850-4322-8c28-d66f982b5473"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("49f64ddd-4aa9-4c8a-81f5-0bc80ef3750c"));
            labelStartDate = (ITTLabel)AddControl(new Guid("1172cad4-7c3f-451d-9239-10c00ad62e9e"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("a315024c-9812-4ccb-af35-ed819eceb36d"));
            labelEndDate = (ITTLabel)AddControl(new Guid("b7eafa2a-f583-4c5e-af24-6b190d9b5e6c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4ae404fc-49f5-42ac-9ab2-ef3f07e7b0a7"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("3ac1cb58-c4d7-4bc7-aedc-b0a12f2c836f"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("c7e7dc0e-6b1f-42ed-bc20-19b9a991c2eb"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("956a3072-33f9-4119-bf4b-0e1c7f9743ab"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a2e418fb-7303-4ef3-8ad0-8557d61b9f49"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("239c56ab-d4d3-4328-b339-1a01ba920159"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9733deca-1a4a-49f3-be87-8d51dce137cb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b2386474-5646-48b3-9705-7248d81d53db"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("1f980aa4-3b7d-4c9e-b454-95427a338d57"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ac3160d1-7390-442b-9606-0a2090e8bb8b"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("d726b7cb-a43d-4f62-8670-4db3526f3db1"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("68105a60-a3a1-4dbb-abff-520879aaaf4b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("b817e8f0-a9a0-4757-b564-566b3d0292d0"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("065b7695-8b0a-4d4a-8a0d-6a0be1870392"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("335e6f83-48cf-48a4-a16f-8537bdf1ac38"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("87b54c53-e049-4e28-b056-ceb9a2875fa1"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("0977824a-ecbf-4003-a598-843e90a3e5e9"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("72b3f8de-2e29-41c5-9134-e5bbe1053e0f"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("bd01be56-4707-4c8c-a801-9c9803f7635a"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("f7f0337a-4667-4a66-a34e-018946f902dc"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("a829f855-7a5b-4967-950c-70fb6ac8b729"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("76405054-7807-4f87-8ef5-1682eae86ddc"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("d4038cab-01cf-48ce-a2aa-10f9e23b118f"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("0698c881-23e1-4566-853c-96a5af0b8754"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("d389e5af-bc51-443d-af30-1c5ebf3b8bcf"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("df39c75a-b44c-49c2-a803-ddf7a65d6f3d"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("b7414e3f-1dec-41b4-a95e-be4f9a6db556"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("af93f440-f568-4268-872c-35f2e376964b"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("83627290-adb7-4031-afc8-c50fc55d35e1"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("2cdc3d14-4b62-4108-9281-ebfe2916bcba"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("3e4a1136-3cf3-440b-b57c-84a6239a389e"));
            base.InitializeControls();
        }

        public MaterialCompletedForm() : base("MATERIALREPAIR", "MaterialCompletedForm")
        {
        }

        protected MaterialCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}