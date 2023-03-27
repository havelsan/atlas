
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
    /// Garanti Onarım Onay
    /// </summary>
    public partial class CMRActionGuarantyAppForm : CMRActionBaseForm
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
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("f0b2cd07-490c-45bd-ad81-79c6262be203"));
            RequestNO = (ITTTextBox)AddControl(new Guid("9c916964-f313-47aa-a2ed-870e42330d76"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("9dc820b0-26f7-4066-b5d1-bd4713c7850c"));
            GuarantyPenalTime = (ITTTextBox)AddControl(new Guid("907a5414-4c14-45fb-a8ae-d172d253ed0a"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("0a87adbd-1174-4b2d-86dd-73dd949264cf"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("fb9d7ead-9ad4-4636-8d51-fef4aa4a76b8"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("f2fbfce8-028f-498f-8b5e-15bc1ebf35df"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("c5fd7d1e-b8f7-41af-9b0d-8daf7187a78b"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("dd9b9507-830f-4455-b46c-313b1fc0403c"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("9cab3ee9-94e8-4ad2-906e-deea28eae224"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bdd4471a-a853-4e62-bc71-df165ac67ec0"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("062b5d55-67e1-4e7a-be4d-3199967f62b0"));
            labelDescription = (ITTLabel)AddControl(new Guid("f371e701-670e-4c7d-9f35-f1e7d6732e72"));
            labelUserTel = (ITTLabel)AddControl(new Guid("a80309eb-545c-4607-83ca-5e84e5e9cb94"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("523b13a5-e837-4ca6-b913-b30a1d9764c1"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("0bcee6b1-e26f-48b2-a106-9322aaf4fd39"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("b266624a-8a4d-46ff-a943-285bee562556"));
            FirmNotificationDate = (ITTDateTimePicker)AddControl(new Guid("0ac81a2e-18fe-4036-82b2-f50052082d41"));
            labelFirmSubmissionDate = (ITTLabel)AddControl(new Guid("320b308c-2ed0-48f2-8849-11d1162e9489"));
            FirmDeliveryDate = (ITTDateTimePicker)AddControl(new Guid("df48e4e7-f8dd-4122-9754-954a9ed560d5"));
            labelFirmDeliveryDate = (ITTLabel)AddControl(new Guid("49e84b40-505f-4209-94cb-92a198501bf8"));
            FirmSubmissionDate = (ITTDateTimePicker)AddControl(new Guid("283c1626-8043-4c2c-813b-55cb215c9a7b"));
            labelFirmNotificationDate = (ITTLabel)AddControl(new Guid("894f3334-6e63-4b1b-81b4-a14ee6f94a83"));
            OnSiteRepair = (ITTCheckBox)AddControl(new Guid("69846b6c-b28a-4a99-b318-956021389214"));
            labelGuarantyPenalTime = (ITTLabel)AddControl(new Guid("d79ba94b-6271-466f-8073-e4805d5e3644"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("e7d8c3b2-83c5-405e-824a-d321bc190b66"));
            labelSupplier = (ITTLabel)AddControl(new Guid("2c290f15-e518-4309-a100-855117bd0f79"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("add13d78-0996-4c4e-ac47-9f0606496788"));
            UserParameterTabPage = (ITTTabPage)AddControl(new Guid("9c96cbca-9d44-4328-a3d2-74e0c03e876e"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("f2e8c92d-5548-4933-a24d-b524f48e7139"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("40104ed3-0bb9-4a00-8af7-75a672945b79"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("bc8d12a5-63ea-4fc3-b5f5-8e8f96cd45a4"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("b5795fc7-2314-423c-a2c9-79b2a5f13f28"));
            ContentsTabPage = (ITTTabPage)AddControl(new Guid("40a5e400-e9f3-466b-ad19-4a761f3c9fc1"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("f56a566c-b8f7-448c-a407-0449155f1656"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("bfc7dd8c-41ab-40ae-807b-443e259e7e0f"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("47861dca-d492-4370-a6d3-39bf7f8d1311"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("50227070-3561-4702-9f76-63a82a11359c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4b252833-0994-4da7-a6b8-6e1a309f3020"));
            base.InitializeControls();
        }

        public CMRActionGuarantyAppForm() : base("CMRACTIONREQUEST", "CMRActionGuarantyAppForm")
        {
        }

        protected CMRActionGuarantyAppForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}