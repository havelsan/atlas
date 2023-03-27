
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
    /// Malzeme Detayları
    /// </summary>
    public partial class BaseStockActionDetailInForm : BaseStockActionDetailForm
    {
    /// <summary>
    /// Stok hareketlerinde giriş detaylarını barındıran sınıftır. Stok modüllerindeki giriş tipindeki detay sınıfları bu sınıftan türer
    /// </summary>
        protected TTObjectClasses.StockActionDetailIn _StockActionDetailIn
        {
            get { return (TTObjectClasses.StockActionDetailIn)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage FixedAssetTabPage;
        protected ITTGrid FixedAssetDetails;
        protected ITTTextBoxColumn Description;
        protected ITTTextBoxColumn FixedAssetNO;
        protected ITTDateTimePickerColumn GuarantyStartDate;
        protected ITTDateTimePickerColumn GuarantyEndDate;
        protected ITTTextBoxColumn Mark;
        protected ITTTextBoxColumn Model;
        protected ITTTextBoxColumn SerialNumber;
        protected ITTDateTimePickerColumn ProductionDate;
        protected ITTTextBoxColumn Power;
        protected ITTTextBoxColumn Voltage;
        protected ITTTextBoxColumn Frequency;
        protected ITTListBoxColumn Resource;
        protected ITTEnumComboBoxColumn FixedAssetStatus;
        protected ITTTextBox MarkTemp;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTButton UpdateButton;
        protected ITTDateTimePicker ProductionDateTemp;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker GuarantyStartDateTemp;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox ModelTemp;
        protected ITTLabel ttlabel1;
        protected ITTTextBox PowerTemp;
        protected ITTDateTimePicker GuarantyEndDateTemp;
        protected ITTTextBox VoltageTemp;
        protected ITTTextBox FrequencyTemp;
        protected ITTTabPage QRCodeTabPage;
        protected ITTLabel labelExpirationDate;
        protected ITTLabel labelLotNo;
        protected ITTDateTimePicker ExpirationDate;
        protected ITTLabel labelBarcodeMaterial;
        protected ITTTextBox LotNo;
        protected ITTLabel QRCodeCountLabel;
        protected ITTTextBox BarcodeMaterial;
        protected ITTLabel labelQRCodeCount;
        protected ITTGrid QRCodeInDetails;
        protected ITTTextBoxColumn BarcodeQRCodeInDetail;
        protected ITTTextBoxColumn LotNoQRCodeInDetail;
        protected ITTDateTimePickerColumn ExpireDateQRCodeInDetail;
        protected ITTTextBoxColumn OrderNoQRCodeInDetail;
        protected ITTTextBoxColumn PalletNoQRCodeInDetail;
        protected ITTTextBoxColumn PackageNoQRCodeInDetail;
        protected ITTTextBoxColumn BunchNoQRCodeInDetail;
        protected ITTTextBoxColumn BoxNoQRCodeInDetail;
        protected ITTTextBoxColumn SmallBunchNoQRCodeInDetail;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3a73fd14-c22e-4ffa-9acb-4df0325a0394"));
            FixedAssetTabPage = (ITTTabPage)AddControl(new Guid("1df28451-ba5d-4ec8-9eea-76de2d6b0614"));
            FixedAssetDetails = (ITTGrid)AddControl(new Guid("447f3d11-fe0c-4406-8580-67b2f7350615"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("a86ac76f-6d7b-413c-af20-fbe1d5d31b23"));
            FixedAssetNO = (ITTTextBoxColumn)AddControl(new Guid("bfa72eeb-80a3-40cd-b97a-15eaa0f6431c"));
            GuarantyStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("2c1c4896-fc3a-45ba-a106-7ec2292999a7"));
            GuarantyEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("0c2296a4-886a-423b-ad09-4d74480c44fd"));
            Mark = (ITTTextBoxColumn)AddControl(new Guid("963c0c03-5177-4f0b-b331-8dac8437fba4"));
            Model = (ITTTextBoxColumn)AddControl(new Guid("1e54fb64-d03f-422f-a1f6-16a37c1acc6c"));
            SerialNumber = (ITTTextBoxColumn)AddControl(new Guid("0d74e71f-d42d-488c-b2a8-7a4d003eca80"));
            ProductionDate = (ITTDateTimePickerColumn)AddControl(new Guid("8edef879-03b7-4fdb-b726-834e7f7a98f3"));
            Power = (ITTTextBoxColumn)AddControl(new Guid("c843b246-90fc-4367-88e3-5d3d32aea91b"));
            Voltage = (ITTTextBoxColumn)AddControl(new Guid("b731874d-1365-464b-8fdc-44c5ce99a148"));
            Frequency = (ITTTextBoxColumn)AddControl(new Guid("672f4bdd-deb3-4a87-9792-0a4c30c3b408"));
            Resource = (ITTListBoxColumn)AddControl(new Guid("cc1f8db4-238a-4618-b1c8-1bdaabb9ebf2"));
            FixedAssetStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("c7e615d1-4802-4ffe-b67d-3f4c761e03ae"));
            MarkTemp = (ITTTextBox)AddControl(new Guid("aa5283d5-1b69-4753-b158-b2247cc18e5d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("dafade68-8361-44d2-8531-08e9e42f5fc1"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("3fc5e075-ad79-477e-9344-9bc305578c58"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("23458c8d-3290-487c-9e0e-b8eb88a0edfd"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("bdd3e529-0f25-46e9-a18c-0fc94e8a7be1"));
            UpdateButton = (ITTButton)AddControl(new Guid("a7fb0f31-2283-47e4-88b9-0e6c0e573326"));
            ProductionDateTemp = (ITTDateTimePicker)AddControl(new Guid("0b5b0280-96d4-477a-b03b-e0f506d5f2a0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b602ab9e-35cd-4fcd-9774-b217f7eec4ba"));
            GuarantyStartDateTemp = (ITTDateTimePicker)AddControl(new Guid("28a7383c-df61-4ce1-b5c0-ee217c2d34b0"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5e4f9fe7-b431-4879-a5f8-2b07b58fbdf3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fed9ed67-538f-4533-a161-7b3a2d8ab361"));
            ModelTemp = (ITTTextBox)AddControl(new Guid("58500302-29c6-4e28-9ed1-7d7d19a6a329"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fa723416-6133-404e-bc26-5bcbf69a82ee"));
            PowerTemp = (ITTTextBox)AddControl(new Guid("ada412ad-ccf7-4004-be45-bde6cedf6fdd"));
            GuarantyEndDateTemp = (ITTDateTimePicker)AddControl(new Guid("066bf960-fa07-46cd-82d1-99cf57987dbe"));
            VoltageTemp = (ITTTextBox)AddControl(new Guid("f4497c55-0780-4db2-8bad-2740cc2a00a0"));
            FrequencyTemp = (ITTTextBox)AddControl(new Guid("801e4b3c-9f01-481b-b7c3-e851abf03196"));
            QRCodeTabPage = (ITTTabPage)AddControl(new Guid("15922229-f927-4bc1-b38b-5192b36fc3e0"));
            labelExpirationDate = (ITTLabel)AddControl(new Guid("ec38b114-d85c-4e65-970e-b0a10bebd2e7"));
            labelLotNo = (ITTLabel)AddControl(new Guid("7c4eb897-135f-48fb-ba75-8eaeb8667952"));
            ExpirationDate = (ITTDateTimePicker)AddControl(new Guid("bedc1872-1efb-4f9f-b207-cd4b957c95d7"));
            labelBarcodeMaterial = (ITTLabel)AddControl(new Guid("24f5e442-02df-4531-a354-210a6e23079c"));
            LotNo = (ITTTextBox)AddControl(new Guid("aa097706-982f-4c59-bcfa-fe843c54cfac"));
            QRCodeCountLabel = (ITTLabel)AddControl(new Guid("25e10bbf-17b9-41bd-91ee-556801160959"));
            BarcodeMaterial = (ITTTextBox)AddControl(new Guid("5145f6da-841e-40d2-a5bb-a1b4b15758a8"));
            labelQRCodeCount = (ITTLabel)AddControl(new Guid("7868eab3-f626-49f7-8971-6b3d857bb9ae"));
            QRCodeInDetails = (ITTGrid)AddControl(new Guid("47c87684-d2b2-4c98-8768-e3bb655b8eac"));
            BarcodeQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("a8e84b10-1eaa-4d27-8a94-afd1a4c6fcee"));
            LotNoQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("8392c5ac-661b-415c-9a75-2afb4d1e35d7"));
            ExpireDateQRCodeInDetail = (ITTDateTimePickerColumn)AddControl(new Guid("2076c1c8-ca42-4fb7-b29a-2f3f764fdd82"));
            OrderNoQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("e40ad4db-ede7-415b-bfd4-aa20dc0814f4"));
            PalletNoQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("4662d0b9-8abc-439c-b6de-7d318b555b62"));
            PackageNoQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("3fcd4e10-1bfe-4b7c-a38d-898ddd1fd753"));
            BunchNoQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("21ee78ad-10dd-48e6-aa2a-bf8df5e08a02"));
            BoxNoQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("ae457cc3-7f07-4ab2-9928-b4b8b849a9e9"));
            SmallBunchNoQRCodeInDetail = (ITTTextBoxColumn)AddControl(new Guid("c454aa07-c866-4ea0-810f-8113f09bbbee"));
            base.InitializeControls();
        }

        public BaseStockActionDetailInForm() : base("STOCKACTIONDETAILIN", "BaseStockActionDetailInForm")
        {
        }

        protected BaseStockActionDetailInForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}