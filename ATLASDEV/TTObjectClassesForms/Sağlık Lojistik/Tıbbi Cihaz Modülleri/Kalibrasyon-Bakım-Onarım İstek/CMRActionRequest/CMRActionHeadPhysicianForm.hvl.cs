
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
    /// Baş Tabip Onay
    /// </summary>
    public partial class CMRActionHeadPhysicianForm : CMRActionBaseForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
        protected TTObjectClasses.CMRActionRequest _CMRActionRequest
        {
            get { return (TTObjectClasses.CMRActionRequest)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelSenderSection;
        protected ITTEnumComboBox RequestType;
        protected ITTLabel ttlabel1;
        protected ITTLabel GuaranyStatuslabel;
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
            RequestNO = (ITTTextBox)AddControl(new Guid("c10cba02-f260-404b-a5ba-5e30354e9d1e"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("3ce17611-1450-44f5-bee5-785b066cd5fe"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("a611a1e9-0eaf-4bc5-b980-8afd5be1a0ed"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("9f94ab47-a0a5-4c35-be49-d90ab8018914"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("3f31095a-15cf-483c-97a1-db3a530faa77"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("63257c4f-fe5b-4a14-aaeb-9215245fef0a"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("28519808-4891-48fc-bcb4-22080793f127"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2fe91c40-87b4-4f7a-a873-0656953f1edf"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("99d53390-771d-41f4-88d3-c9e395296a45"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6a3c7e5f-7ec2-42b4-b5c2-ffb90e0b15e6"));
            UserParameterTabPage = (ITTTabPage)AddControl(new Guid("a1f98c1c-4539-4f3a-83c3-5c79054f3b4e"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("0c558b27-b305-443a-8833-c475933773f0"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("038a0f09-6fcf-4032-801a-e74e69cdb365"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("0eebc00d-5a7a-44e3-8ad9-9d9c0a2d7f3d"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("3751dcc0-5bd3-452e-99ef-8d7ecc1e43f8"));
            ContentsTabPage = (ITTTabPage)AddControl(new Guid("2f01eac7-82de-4c61-8f13-8afc3957c3e2"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("24a96853-2880-4427-b914-5483cb2f8ed1"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("036b4957-ee6f-4b20-a2f6-aeeb0c237136"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1e105294-5f29-442c-8b05-f12f81188b6f"));
            ContentDistType = (ITTListBoxColumn)AddControl(new Guid("f3941bbe-b605-41f6-b8f1-f569e1bc3427"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("68ea9d54-0230-4274-b470-7e17ec67604e"));
            fixedAssetTypeTab = (ITTTabControl)AddControl(new Guid("e3ffded3-baff-42fb-92f2-886821e475af"));
            SerialTab = (ITTTabPage)AddControl(new Guid("c165e147-2cbe-4f41-94f0-a473d2ddb57a"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("fc403563-dc8d-4f9c-8cd1-a37418d1ea81"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("5fccf14b-b028-458b-b018-46522df7c638"));
            labelDescription = (ITTLabel)AddControl(new Guid("ce71d0aa-34c6-4111-b7ad-461758240b4f"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("e484350e-86bb-4f78-a591-18d7c7759ac3"));
            UserTel = (ITTTextBox)AddControl(new Guid("86f10347-698c-4911-99b0-5fa0fcaf710f"));
            labelUserTel = (ITTLabel)AddControl(new Guid("3dc20c20-0724-4d6f-a16e-7d52fe9172e9"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("7542f5b7-9916-4830-8bae-771bcb069313"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("ba9bc46a-76e0-4ecf-9eef-64f020943cd6"));
            StockTab = (ITTTabPage)AddControl(new Guid("26e58a77-c28b-4854-8cb9-9995e6991368"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("2b801983-8adb-4d42-8466-50f6d83eae29"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("38d2e935-abb3-4fe9-9004-94daa8c0512b"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("197e9a36-03ed-4e19-864c-e176c3e80bf7"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("54f92a31-a427-48e1-b7f4-687709ea5b65"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("f0441b58-3998-41f5-9a10-18287f179d8a"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("f24c571a-9dd0-4276-a121-0f46f852d957"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("0f67e570-3820-4801-a99c-54d1ffcd60a7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("593a7119-215c-4eda-b59a-bca222fbcee9"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a2606426-159a-49e8-b95e-8925662e7077"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("dbb7587c-5922-4722-9dbc-0c9a781e562c"));
            FixedAssetType = (ITTEnumComboBox)AddControl(new Guid("d541762e-0b16-4ed6-979a-eb83e6a27975"));
            labelFixedAssetType = (ITTLabel)AddControl(new Guid("ac24620d-e2e7-43aa-90aa-e514996e9fe8"));
            base.InitializeControls();
        }

        public CMRActionHeadPhysicianForm() : base("CMRACTIONREQUEST", "CMRActionHeadPhysicianForm")
        {
        }

        protected CMRActionHeadPhysicianForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}