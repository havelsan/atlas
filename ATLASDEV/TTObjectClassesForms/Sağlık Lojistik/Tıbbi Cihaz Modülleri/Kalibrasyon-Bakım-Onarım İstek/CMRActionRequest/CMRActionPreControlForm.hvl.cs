
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
    /// Ön Kontrol
    /// </summary>
    public partial class CMRActionPreControlForm : CMRActionBaseForm
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
        protected ITTTextBox PreControlNotes;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTObjectListBox Stage;
        protected ITTLabel labelPreControlNotes;
        protected ITTTabControl fixedAssetTypeTab;
        protected ITTTabPage SerialTab;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTButton cmdUpdate;
        protected ITTTextBox UserTel;
        protected ITTLabel labelDeviceUser;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox DeviceUser;
        protected ITTLabel labelUserTel;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTTextBox FaultDescription;
        protected ITTTabPage StockTab;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox FixedAssetType;
        protected ITTLabel labelFixedAssetType;
        override protected void InitializeControls()
        {
            labelSenderSection = (ITTLabel)AddControl(new Guid("0906ecb8-0191-4220-b81e-96710e3ae57d"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("4c9852d3-c616-4781-9c3a-ec2d13491812"));
            labelSection = (ITTLabel)AddControl(new Guid("c7b1629e-6fde-4e54-b3a6-7ce019f03cd3"));
            Section = (ITTObjectListBox)AddControl(new Guid("a98def5c-8a10-4f85-8349-4dc59474a418"));
            labelWorkShop = (ITTLabel)AddControl(new Guid("5a8d6b36-adbb-41c5-92f2-42e5e3f7a3e8"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("8fece22f-45a6-489e-bf41-502c9db53970"));
            labelResponsibleWorkShopUser = (ITTLabel)AddControl(new Guid("c57bd35b-2a0a-4d84-b9dc-5bac89673003"));
            ResponsibleWorkShopUser = (ITTObjectListBox)AddControl(new Guid("92090345-cf73-42a3-ad8b-7f7d12da02ee"));
            labelDescription = (ITTLabel)AddControl(new Guid("a17d2f05-4c92-45a4-85c1-daed9ace07d7"));
            Description = (ITTTextBox)AddControl(new Guid("25bfb70e-7f81-45d0-9d07-bda8b7009772"));
            RequestNo = (ITTTextBox)AddControl(new Guid("a8709e83-3af8-48d1-86fe-a8a177625d49"));
            labelRequestType = (ITTLabel)AddControl(new Guid("c0b52520-fed7-4624-a06f-d2829fe0a9f9"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("17444f2e-6bdf-4360-a5e1-5a946c71c8d7"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("b502d2f8-754f-443d-b7e4-2044cb4f3e79"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("7e3bff4e-577e-40ce-bee3-9b395214b46d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3ea2c3a1-aca3-4760-b357-e4f030548724"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("2e5cf928-5d89-433a-9b7f-1e25844fc256"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ce99fd26-fd9a-41fc-99e0-31bceca78568"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("c055e757-a87f-4904-83d2-e1218656c796"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4a98795c-fedb-457a-8b11-853da19ba9c8"));
            UserParameterTabPage = (ITTTabPage)AddControl(new Guid("092baffb-6229-4f0f-9c37-207bc614730e"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("aad48aeb-71a6-477a-a491-d98c755d74cd"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("83946e1e-7d7a-4367-bbcb-a909b80e4535"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("d12326fc-978b-40fb-9d72-ce27624d81c6"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("e5b90434-1121-4c87-baa0-8267cea62bb1"));
            ContentsTabPage = (ITTTabPage)AddControl(new Guid("9d843b5c-f553-4157-81ee-600dea023adf"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("7f45f713-2fa0-403d-9ccd-4cb270074b16"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("2da68577-ccf2-4373-868f-013dee64019c"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("ede2de41-367f-43a2-bb56-f8cf9e9ccc9c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("71ee0c8e-6f98-4f16-abb0-9d6cae39c58e"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("48772c8c-2c0a-44c8-b109-82d2f76d3f0f"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("acf6309e-3d1c-4fd5-82f0-119cd3496cc0"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("cd6244a7-eb66-404c-84d4-9ad61ef480a4"));
            IsNormal = (ITTCheckBoxColumn)AddControl(new Guid("be1329fc-3cf8-489e-bd07-1c0604f83dc4"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("13da23a0-249f-4b3c-85f9-42631ba98eb1"));
            PreControlNotes = (ITTTextBox)AddControl(new Guid("1a7f7e48-6af1-4af9-937c-8e3a13619785"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("1785be51-f939-4d9c-b9c9-7ffbbf8ecc1d"));
            Stage = (ITTObjectListBox)AddControl(new Guid("90953070-03de-4fc2-b04a-5d7fcec557dc"));
            labelPreControlNotes = (ITTLabel)AddControl(new Guid("f50e588b-7a20-415e-bc71-5770e416962d"));
            fixedAssetTypeTab = (ITTTabControl)AddControl(new Guid("5d843330-f5a4-4a2f-aaed-7f0d8e353b14"));
            SerialTab = (ITTTabPage)AddControl(new Guid("ab06170f-7ab2-4b31-9edd-92d65d31f10c"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("841be7af-c419-4c43-8e34-382318e3c416"));
            cmdUpdate = (ITTButton)AddControl(new Guid("f4dae4a0-cbf9-40c3-849b-8bf2ad78660d"));
            UserTel = (ITTTextBox)AddControl(new Guid("a54fba07-f830-4801-b493-ae818e4a2e68"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("724941c9-a384-4ce2-be49-e642c7034ac9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("096b6237-15e4-4f48-9a8c-9b354dcbded3"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("5b5bb520-1b48-428c-bd22-2e6a0947d122"));
            labelUserTel = (ITTLabel)AddControl(new Guid("49a91090-ed44-4fc9-aeb4-056560b611c0"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("f29c966c-d8eb-439d-8e19-7b44fd6f3662"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("02c8067d-cf5c-4153-b9df-d0c7c933b130"));
            StockTab = (ITTTabPage)AddControl(new Guid("962afd0c-3639-4f48-b139-09d3b2a0012f"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("387bf058-28fb-4149-8584-b67d92573b3b"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("dddddfdf-49aa-4a4a-960e-79af5e5832e3"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("a6730ccd-854d-4899-b3d0-77d7f4bbcd9f"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("007db652-3b38-4a6c-9570-cfa9900fbedd"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("447cb71d-7102-41ae-81fb-b1bbf61f1ee2"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("83be6263-d593-4238-8367-6180308c38eb"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("64378e7c-5127-4653-91ea-613f08bf7202"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cf8bac06-53a2-42b3-a766-690dd92eec70"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("927dea03-d2d4-480e-a337-28dabe786b6f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e768d823-f849-4c53-958e-f8c708b3414f"));
            FixedAssetType = (ITTEnumComboBox)AddControl(new Guid("dc2532e8-bd54-4516-867a-1728702944de"));
            labelFixedAssetType = (ITTLabel)AddControl(new Guid("36d61e52-5010-4279-888e-8cfd6e8b0866"));
            base.InitializeControls();
        }

        public CMRActionPreControlForm() : base("CMRACTIONREQUEST", "CMRActionPreControlForm")
        {
        }

        protected CMRActionPreControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}