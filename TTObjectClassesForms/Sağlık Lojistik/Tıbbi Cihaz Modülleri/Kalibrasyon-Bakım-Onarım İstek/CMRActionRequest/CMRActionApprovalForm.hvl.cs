
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
    /// Kademe Onay
    /// </summary>
    public partial class CMRActionApprovalForm : CMRActionBaseForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
        protected TTObjectClasses.CMRActionRequest _CMRActionRequest
        {
            get { return (TTObjectClasses.CMRActionRequest)_ttObject; }
        }

        protected ITTLabel labelSenderSection;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelSection;
        protected ITTObjectListBox Section;
        protected ITTLabel labelWorkShop;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelResponsibleWorkShopUser;
        protected ITTObjectListBox ResponsibleWorkShopUser;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelRequestType;
        protected ITTEnumComboBox RequestType;
        protected ITTLabel labelRequestNo;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel2;
        protected ITTLabel GuaranyStatuslabel;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage UserParameterTabPage;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn Parameter;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTabPage ContentsTabPage;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTListBoxColumn DistType;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn IsNormal;
        protected ITTTextBoxColumn Comments;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTObjectListBox Stage;
        protected ITTTabControl fixedAssetTypeTab;
        protected ITTTabPage SerialTab;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTLabel ttlabel3;
        protected ITTTextBox FaultDescription;
        protected ITTTextBox UserTel;
        protected ITTLabel labelUserTel;
        protected ITTObjectListBox DeviceUser;
        protected ITTLabel labelDeviceUser;
        protected ITTTabPage StockTab;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTEnumComboBox FixedAssetType;
        protected ITTLabel labelFixedAssetType;
        override protected void InitializeControls()
        {
            labelSenderSection = (ITTLabel)AddControl(new Guid("6d1d30f0-e33b-47a3-b78b-af4eca01c3f2"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("8a1fee0e-3c22-4b10-aa30-d3aa1e9bce50"));
            labelSection = (ITTLabel)AddControl(new Guid("8a4e9842-56e0-420b-8a21-d279c9045854"));
            Section = (ITTObjectListBox)AddControl(new Guid("8f885b95-938f-48b8-984f-c9e1920408cb"));
            labelWorkShop = (ITTLabel)AddControl(new Guid("d9542490-6311-469d-9142-9912c3da7d91"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("0aa534f2-9e7c-4012-ab76-4e3879b7bae4"));
            labelResponsibleWorkShopUser = (ITTLabel)AddControl(new Guid("5557eb34-770f-4cd4-b8e8-bd3f55ad6cd9"));
            ResponsibleWorkShopUser = (ITTObjectListBox)AddControl(new Guid("69224fbd-e441-4f56-bd6b-c77debe0b982"));
            labelDescription = (ITTLabel)AddControl(new Guid("570d1df1-b23f-43ea-aef0-bfb5902c2601"));
            Description = (ITTTextBox)AddControl(new Guid("3185d13d-2b1e-411f-9284-9444442e6a7e"));
            RequestNo = (ITTTextBox)AddControl(new Guid("c8f3404f-e4c1-4d35-9c92-dbf619fddd80"));
            labelRequestType = (ITTLabel)AddControl(new Guid("e9a2a2ec-42f9-49f9-a5ef-5bf8fa9ffd77"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("8e10d20e-0d03-4085-90c2-af3f5d01d5c3"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("7020094a-1077-45a2-948c-52747f33ad17"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b8c26540-f3e9-472d-80c8-803073426f68"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("d6321587-59af-4875-baaf-653e2e894f97"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("115b6a9f-6fa6-4758-8b88-89670ae3ab03"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("33c35fb2-033f-49de-bfbc-5c21d05e093f"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("2702a1d8-5d5f-4f6e-8496-e1a8a6c1ff68"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("16e0738c-25f7-4f9e-9f52-3b8489f237ef"));
            UserParameterTabPage = (ITTTabPage)AddControl(new Guid("b28d6521-8fc3-47ff-8f8d-090145fad1cf"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("56f513ff-748d-4d3b-b5cb-26d50b6bbd88"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("ac515cf8-33bf-4a10-9860-87e684779f4a"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("aa77f7a4-85d3-47fe-868a-b49873a5a4cd"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("4bf83314-9dc6-473e-9e1b-8dd9ee4e6340"));
            ContentsTabPage = (ITTTabPage)AddControl(new Guid("c2026cc4-76f4-4ab5-8288-1bcdec72b311"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("f0bad403-ad9e-4e34-ae5e-10ed254bd689"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("7bc0ea48-e37f-434f-ad14-2a99b5cb8833"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("16e65c71-812d-4ffa-94cc-295076344823"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6665cb0b-a314-4268-ad66-404044b52596"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("2534e1dc-a5a5-4c6b-8d31-d32b5d913136"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("9c660c21-8726-419c-84ca-c3745368575d"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("542cfe1a-d917-45eb-b54e-6c0e6bfc7b9c"));
            IsNormal = (ITTCheckBoxColumn)AddControl(new Guid("fba4b846-83bb-460c-87cd-43734cbee308"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("e140a63d-69d5-43dc-91a1-31466e6354f4"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("bc56f727-0e5b-4aaf-bdf7-3c1685b18d17"));
            Stage = (ITTObjectListBox)AddControl(new Guid("7a7645d0-1192-4e6a-bce3-ea9310d795d3"));
            fixedAssetTypeTab = (ITTTabControl)AddControl(new Guid("0f59df1d-5fc1-426d-ac8a-ab7733b899d2"));
            SerialTab = (ITTTabPage)AddControl(new Guid("12f14e39-8f42-44d9-8c2a-30bbb7357d63"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("cd4e6bef-9507-411a-8e2d-d434b92ebcb8"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("5c338d64-82a4-48db-b32b-4e698745242b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3c30498c-418c-4370-a4d1-b8e71c7d296d"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("7a39ae43-d46a-49f8-bc56-325da6daf196"));
            UserTel = (ITTTextBox)AddControl(new Guid("c72cba9e-4059-4302-9e09-705c38bf4885"));
            labelUserTel = (ITTLabel)AddControl(new Guid("944c0c50-2dab-4d60-97f1-7a2a7cdf2342"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("bae9eb5a-f8f8-4012-badd-ccafc2fa8ef0"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("23661376-1cc3-4e81-9d9e-45766bb4fd8c"));
            StockTab = (ITTTabPage)AddControl(new Guid("f07be606-0688-464a-adbc-72b7947a379c"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("326a4502-2766-4e22-a5ef-5c022d98bbc4"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("84bf5305-0fbc-4f7e-a205-a44a39ac7081"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("24b10c0a-5680-492f-bcab-7d9bc7daaa49"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("a23d6280-17de-4146-b49d-091729e13ae8"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("e1b974dc-8925-466b-8cf8-584fd27adbd4"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("6aed16f1-cda5-4084-acc4-5a479b0c2d0e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("79539249-a1df-4278-a03b-6d79f82c3f34"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ba6c381b-f2eb-41c8-9bfd-fedc78242c57"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0a8e6e9a-06f3-4818-8cc3-992e23082312"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("9f76c87b-900f-4e29-849a-49d7ef0b08b5"));
            FixedAssetType = (ITTEnumComboBox)AddControl(new Guid("6a31ffd6-268c-4569-b725-f4eca39b366a"));
            labelFixedAssetType = (ITTLabel)AddControl(new Guid("839d2c48-4ea2-4397-b733-81e6146e57a6"));
            base.InitializeControls();
        }

        public CMRActionApprovalForm() : base("CMRACTIONREQUEST", "CMRActionApprovalForm")
        {
        }

        protected CMRActionApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}