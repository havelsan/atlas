
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
    public partial class BaseStockActionDetailOutForm : BaseStockActionDetailForm
    {
    /// <summary>
    /// Stok hareketlerinde çıkış detaylarını barındıran sınıftır. Stok modüllerindeki çıkış tipindeki detay sınıfları bu sınıftan türer
    /// </summary>
        protected TTObjectClasses.StockActionDetailOut _StockActionDetailOut
        {
            get { return (TTObjectClasses.StockActionDetailOut)_ttObject; }
        }

        protected ITTCheckBox IsZeroUnitPrice;
        protected ITTButton cmdGetStockLocations;
        protected ITTButton cmdGetInTransaction;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage FixedAssetTabPage;
        protected ITTGrid FixedAssetDetails;
        protected ITTListBoxColumn FixedAssetMaterialDefinition;
        protected ITTListBoxColumn ToResource;
        protected ITTTextBoxColumn FixedAssetNO;
        protected ITTTextBoxColumn Mark;
        protected ITTTextBoxColumn Model;
        protected ITTTextBoxColumn SerialNumber;
        protected ITTEnumComboBoxColumn FixedAssetStatus;
        protected ITTListBoxColumn FromResource;
        protected ITTTabPage QRCodeTabPage;
        protected ITTGrid QRCodeOutDetails;
        protected ITTListBoxColumn QRCodeTransactionQRCodeOutDetail;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn LotNo;
        protected ITTTextBoxColumn OrderNo;
        protected ITTDateTimePickerColumn ExpireDate;
        protected ITTTextBoxColumn PalletNo;
        protected ITTTextBoxColumn PackageNo;
        protected ITTTextBoxColumn BoxNo;
        protected ITTTextBoxColumn BunchNo;
        protected ITTTextBoxColumn SmallBunchNo;
        protected ITTTabControl DetailTabPage;
        protected ITTTabPage tttabpage1;
        protected ITTGrid OuttableLots;
        protected ITTTextBoxColumn LotNoOuttableLot;
        protected ITTDateTimePickerColumn ExpirationDateOuttableLot;
        protected ITTTextBoxColumn RestAmountOuttableLot;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTCheckBoxColumn isUseOuttableLot;
        protected ITTTabPage tttabpage2;
        protected ITTGrid StockStoreLocations;
        protected ITTListBoxColumn StockLocationStoreLocation;
        protected ITTLabel QRCodeCountLabel;
        protected ITTLabel labelQRCodeCount;
        override protected void InitializeControls()
        {
            IsZeroUnitPrice = (ITTCheckBox)AddControl(new Guid("8dc6f81d-c03d-4e46-b1f8-a5938f8745ce"));
            cmdGetStockLocations = (ITTButton)AddControl(new Guid("95226b5a-74b6-4f9f-aec2-86860522ed04"));
            cmdGetInTransaction = (ITTButton)AddControl(new Guid("6a5c0be0-56cb-4938-9f21-37b2ca2fb94d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("23a70bcd-9137-40e0-ab57-d9cfc79c6a0d"));
            FixedAssetTabPage = (ITTTabPage)AddControl(new Guid("435b6d18-49a9-4f56-8437-467f74ddace4"));
            FixedAssetDetails = (ITTGrid)AddControl(new Guid("a0ab6662-790b-4441-9b9d-1c8443553b9b"));
            FixedAssetMaterialDefinition = (ITTListBoxColumn)AddControl(new Guid("453ad3a3-60bd-406f-a859-1cf70e96a2fa"));
            ToResource = (ITTListBoxColumn)AddControl(new Guid("0d1920d7-880f-4ff9-a52d-85b4e0cf8bb2"));
            FixedAssetNO = (ITTTextBoxColumn)AddControl(new Guid("aab68ea9-4850-4610-83b2-49f13cb7398c"));
            Mark = (ITTTextBoxColumn)AddControl(new Guid("884f2c26-40dd-4535-bb85-e45ab84348e2"));
            Model = (ITTTextBoxColumn)AddControl(new Guid("5b52e756-e016-43f6-bc40-ab43b71726d6"));
            SerialNumber = (ITTTextBoxColumn)AddControl(new Guid("c3922b69-b062-475d-87b4-c19241dde71d"));
            FixedAssetStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("27309103-6f96-43de-b5f2-58257aa98a91"));
            FromResource = (ITTListBoxColumn)AddControl(new Guid("5bc05b9d-d5bf-4a07-911f-da8f82aa2d2f"));
            QRCodeTabPage = (ITTTabPage)AddControl(new Guid("38128c28-f521-4545-bb07-bb278664b3e5"));
            QRCodeOutDetails = (ITTGrid)AddControl(new Guid("07222d5a-dfba-47f2-87ff-0d181f95c35a"));
            QRCodeTransactionQRCodeOutDetail = (ITTListBoxColumn)AddControl(new Guid("f715b975-c68a-4c76-bade-874ceee4c7e4"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("1f9cd213-3e61-490c-b19a-b990cc963a77"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("9300e19c-a0ee-4dab-9415-53f527f3408a"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("02e708e6-f61b-471f-af95-fdee9282ebb0"));
            ExpireDate = (ITTDateTimePickerColumn)AddControl(new Guid("6cbe2b66-2229-4cd3-94a0-45d8d282cf20"));
            PalletNo = (ITTTextBoxColumn)AddControl(new Guid("3f736208-eeb4-46bf-8fe5-11ebd5ea4fe1"));
            PackageNo = (ITTTextBoxColumn)AddControl(new Guid("bdbccf39-513c-474d-b5d0-5c8a414fbe23"));
            BoxNo = (ITTTextBoxColumn)AddControl(new Guid("657f1c77-fbb1-49e2-baac-0b84a0f60206"));
            BunchNo = (ITTTextBoxColumn)AddControl(new Guid("1852bd7b-d69f-4b34-b926-dd3a858be1b7"));
            SmallBunchNo = (ITTTextBoxColumn)AddControl(new Guid("8c6fb3e5-5187-43c5-b9d9-4b397bf637b6"));
            DetailTabPage = (ITTTabControl)AddControl(new Guid("2952d930-89d6-40ae-a90a-7cbe62bd00a7"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("db33e15d-4e17-4a4b-98ac-c4890c12a352"));
            OuttableLots = (ITTGrid)AddControl(new Guid("af2a80bd-a8d4-4562-977f-5a988f83f232"));
            LotNoOuttableLot = (ITTTextBoxColumn)AddControl(new Guid("cbcce12e-af13-46fd-8629-10826e99bf06"));
            ExpirationDateOuttableLot = (ITTDateTimePickerColumn)AddControl(new Guid("46804305-7fda-4e6c-81a3-a56fd283b21b"));
            RestAmountOuttableLot = (ITTTextBoxColumn)AddControl(new Guid("d4ce8dd2-6f2d-40b9-a8a6-0b5187b90612"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("283aa600-0cfa-48c8-ab60-14d3ec1f5695"));
            isUseOuttableLot = (ITTCheckBoxColumn)AddControl(new Guid("516562ac-1146-4d40-9dd0-002225aafaeb"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("5942b898-54c8-45f7-9c48-5a021dfde4f2"));
            StockStoreLocations = (ITTGrid)AddControl(new Guid("28f92779-4420-48e8-a553-96830d2173fb"));
            StockLocationStoreLocation = (ITTListBoxColumn)AddControl(new Guid("08161f1e-e973-47c8-8684-5119bd0201dd"));
            QRCodeCountLabel = (ITTLabel)AddControl(new Guid("279ae8d1-9b2e-49d4-b4f1-2f1128fe96f3"));
            labelQRCodeCount = (ITTLabel)AddControl(new Guid("682b456f-a158-43b4-a57c-3abfb8810d9f"));
            base.InitializeControls();
        }

        public BaseStockActionDetailOutForm() : base("STOCKACTIONDETAILOUT", "BaseStockActionDetailOutForm")
        {
        }

        protected BaseStockActionDetailOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}