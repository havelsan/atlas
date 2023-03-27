
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
    /// Klinik Şefi Onay
    /// </summary>
    public partial class CMRActionClinicAppForm : CMRActionBaseForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
        protected TTObjectClasses.CMRActionRequest _CMRActionRequest
        {
            get { return (TTObjectClasses.CMRActionRequest)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage UserParameterTabPage;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn Parameter;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage ContentsTabPage;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn ContentDistType;
        protected ITTTextBoxColumn Comments;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelSenderSection;
        protected ITTEnumComboBox RequestType;
        protected ITTLabel ttlabel1;
        protected ITTLabel GuaranyStatuslabel;
        protected ITTTabControl fixedAssetTypeTab;
        protected ITTTabPage SerialTab;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTLabel labelDescription;
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
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox FixedAssetType;
        protected ITTLabel labelFixedAssetType;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4c7c6f48-df2a-491e-87f5-72d6d0a93460"));
            UserParameterTabPage = (ITTTabPage)AddControl(new Guid("9249b561-f6f8-45bc-ba85-5628ec3faa39"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("ba3d5d71-5055-4f0b-bada-be1d8f457758"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("22e2760c-4edb-4d73-af76-b78314668756"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("ed7aadfc-2b07-4118-acaf-85d860c9f17d"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("67a86b35-e301-499d-b746-dd753988d9f7"));
            ContentsTabPage = (ITTTabPage)AddControl(new Guid("2bb516f4-0139-4d89-9244-906135642c61"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("6125f317-93e8-4cff-b2d9-edce2344d649"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("3c1c0c96-c44c-4cce-8f07-8a7ccf0b27f1"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("bb0ee4fa-d47f-457c-8785-81d67d5c533f"));
            ContentDistType = (ITTListBoxColumn)AddControl(new Guid("dbbc7931-f4b0-4a78-aa92-88699a21c38b"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("b9aab88a-de5c-4157-9636-7ebecfe5a18a"));
            RequestNO = (ITTTextBox)AddControl(new Guid("8f18b2ce-4af2-4544-8150-a496cb27bff4"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("b914b4ec-d406-4180-8ebc-fd5456eab5dc"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("fdfc7ced-2dda-43ce-b0fd-11fa0e81315a"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("d9c59636-a79b-47cb-bff6-f97e5382aa13"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("0ef7f292-7843-4102-b861-c4f180a80e4f"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("9b82f781-a580-4ce2-961c-d591fafaf9b4"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("1ce08ac5-fdc4-4362-bfaa-525a8f8069bc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0c0bf092-1fb2-46b3-9869-f17778072bed"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("a69dc6ae-6322-41f6-9642-e2d3d2521597"));
            fixedAssetTypeTab = (ITTTabControl)AddControl(new Guid("820d3ea9-0849-4c24-86ef-19ed006fd865"));
            SerialTab = (ITTTabPage)AddControl(new Guid("7a8db276-77d1-4548-ae3e-730bc5178dc3"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("0daeb5e7-4e94-4a09-adaf-08c193c0d5a3"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("12cd2a2d-6aa7-4a64-a2a2-919d0a4fc576"));
            labelDescription = (ITTLabel)AddControl(new Guid("22440c2e-289e-4730-a322-da5b2f655f2e"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("75c2ce12-34b1-4150-9e63-337b35a5d6a5"));
            UserTel = (ITTTextBox)AddControl(new Guid("569061f3-3900-4c2a-8240-41236663b29f"));
            labelUserTel = (ITTLabel)AddControl(new Guid("f0410e8d-1950-49ec-b7a1-e6497dc5cf4a"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("1b7bcb39-0fde-49d7-9020-7466ebc733f8"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("e783d4d0-3deb-4d41-9cc0-400298ffdb5a"));
            StockTab = (ITTTabPage)AddControl(new Guid("00cf8d32-5553-46d4-bd1b-2693c484e0fb"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("5c51f33e-71a6-4eff-9a35-58d8f0dc249e"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("be0d1b58-6851-4b63-be39-802052217e3d"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("3349f8de-0eb7-43bf-9272-c4a3a85757d4"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("4877ca79-dfdd-4e97-baac-2744d87cea3b"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("47e94696-7c5e-4223-b09f-b093da7b2e17"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("042794dd-4856-4009-a4b4-0477eb192996"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("fc1c0159-d374-4db2-b49b-d9e86e0119e9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f4b13920-c96e-4302-911a-102ca925628a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("bb50651d-2542-49ca-adcf-5029d15f1637"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c3481094-e978-43fd-ad46-30794fbf3283"));
            FixedAssetType = (ITTEnumComboBox)AddControl(new Guid("bcb5b1c9-a4ae-4c67-a7bf-78eddc32cd5c"));
            labelFixedAssetType = (ITTLabel)AddControl(new Guid("3af4342c-dde1-44b5-97dd-d67bf5ba5930"));
            base.InitializeControls();
        }

        public CMRActionClinicAppForm() : base("CMRACTIONREQUEST", "CMRActionClinicAppForm")
        {
        }

        protected CMRActionClinicAppForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}