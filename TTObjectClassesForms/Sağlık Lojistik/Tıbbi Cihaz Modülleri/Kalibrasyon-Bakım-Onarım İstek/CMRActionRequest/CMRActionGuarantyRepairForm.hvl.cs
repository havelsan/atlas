
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
    /// Garanti Onarım
    /// </summary>
    public partial class CMRActionGuarantyRepairForm : CMRActionBaseForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
        protected TTObjectClasses.CMRActionRequest _CMRActionRequest
        {
            get { return (TTObjectClasses.CMRActionRequest)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTTextBox RequestNO;
        protected ITTTextBox FaultDescription;
        protected ITTTextBox GuarantyPenalTime;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelSenderSection;
        protected ITTEnumComboBox RequestType;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelDescription;
        protected ITTLabel labelUserTel;
        protected ITTObjectListBox DeviceUser;
        protected ITTLabel labelDeviceUser;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTDateTimePicker FirmNotificationDate;
        protected ITTLabel labelFirmSubmissionDate;
        protected ITTDateTimePicker FirmDeliveryDate;
        protected ITTLabel labelFirmDeliveryDate;
        protected ITTDateTimePicker FirmSubmissionDate;
        protected ITTLabel labelFirmNotificationDate;
        protected ITTCheckBox OnSiteRepair;
        protected ITTLabel labelGuarantyPenalTime;
        protected ITTObjectListBox Supplier;
        protected ITTLabel labelSupplier;
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
        protected ITTTextBoxColumn Comments;
        protected ITTTextBox UserTel;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("87ed415e-0b42-4415-9651-b8ec030326f7"));
            RequestNO = (ITTTextBox)AddControl(new Guid("6d90edbe-381a-44f2-8965-d40df3268430"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("e744a4ee-8fc7-4321-827f-7b2912737962"));
            GuarantyPenalTime = (ITTTextBox)AddControl(new Guid("adbad09f-14aa-43e3-80d0-647d6a756f03"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("3f27e6db-b3ec-43ff-a3c2-e6f6fba56d49"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("a4d1571c-c504-4f5f-a003-c2c9095b903c"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("a799b5de-70ba-4a39-9bdc-61d163426968"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("088139d9-b4cb-4fdc-bab5-07e852903219"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("6bc63dfb-85e3-4721-901b-b74adfd32ea6"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("4f54deed-f7a6-405f-a469-cbfb5f0b8e63"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7fb97244-308a-4a2e-a0f4-8f2671b734aa"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("1fdd3b15-6121-4b51-8037-9375ebc23119"));
            labelDescription = (ITTLabel)AddControl(new Guid("2ce38e13-1fc3-4ace-8e35-c66f2b7d8139"));
            labelUserTel = (ITTLabel)AddControl(new Guid("10d3e0ef-355d-4e21-9aa4-c2152853cab6"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("eab01b9c-1969-4361-a12d-df6b818e3dbc"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("3654d49b-f852-4b32-9bd6-1547d26d8297"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("cc572431-5f76-43d0-8198-59d4961f6b5d"));
            FirmNotificationDate = (ITTDateTimePicker)AddControl(new Guid("0623e13e-6219-41c9-958d-548cf3a0b106"));
            labelFirmSubmissionDate = (ITTLabel)AddControl(new Guid("b8fcfe30-781c-415a-833d-399d344b83ae"));
            FirmDeliveryDate = (ITTDateTimePicker)AddControl(new Guid("55de7e8d-bf6b-41bc-a12c-8cdc1929ecd5"));
            labelFirmDeliveryDate = (ITTLabel)AddControl(new Guid("c2cdb300-1b0a-499d-bc8d-3debb1effcc2"));
            FirmSubmissionDate = (ITTDateTimePicker)AddControl(new Guid("dd73cb2c-9ef8-4cff-b2ca-94b3d3f35c8a"));
            labelFirmNotificationDate = (ITTLabel)AddControl(new Guid("66cf6644-7160-4fb0-bd3a-017757508c2e"));
            OnSiteRepair = (ITTCheckBox)AddControl(new Guid("038905f3-569a-4739-af58-11cc3cab0dbd"));
            labelGuarantyPenalTime = (ITTLabel)AddControl(new Guid("63d8e053-01c6-4955-8e45-f7ee202577b2"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("8dab106f-f543-4a48-a32a-881b6e1cf786"));
            labelSupplier = (ITTLabel)AddControl(new Guid("b0bb6a82-14fc-401b-a16f-85836b87560b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("81a5dc49-5a24-4ccb-8ea7-6495a56e2636"));
            UserParameterTabPage = (ITTTabPage)AddControl(new Guid("6578959f-a54b-4fa2-a966-f075fe727a83"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("ea9ac241-9db6-48eb-b0c6-97d6ca2deb28"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("9d49ec4a-51b1-4d93-acdc-f7db7872f1f2"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("bbbac197-a486-4ce8-99cf-732412019b0b"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("e6d7b99d-0c3c-44b8-85a1-57c93652285b"));
            ContentsTabPage = (ITTTabPage)AddControl(new Guid("4db21b16-12c1-4dae-931b-42ac59e54a98"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("57ee8a29-964b-4527-a3b1-0bced5e9056f"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("c4b28bd1-80c8-4fa0-b127-5f353d058d38"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("35c89ec8-0aa4-46a3-9b00-1c2490cb3a27"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("eb6d70ce-c43d-48a1-9162-6cf95704ce1f"));
            UserTel = (ITTTextBox)AddControl(new Guid("67017f59-78a9-4121-a088-6bbeeb1ed044"));
            base.InitializeControls();
        }

        public CMRActionGuarantyRepairForm() : base("CMRACTIONREQUEST", "CMRActionGuarantyRepairForm")
        {
        }

        protected CMRActionGuarantyRepairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}