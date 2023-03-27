
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
    /// Stok Kart Tanımları
    /// </summary>
    public partial class StockCardForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Stok Kart Tanımları
    /// </summary>
        protected TTObjectClasses.StockCard _StockCard
        {
            get { return (TTObjectClasses.StockCard)_ttObject; }
        }

        protected ITTObjectListBox PurchaseGroup;
        protected ITTLabel labelBaseMaterialGroup;
        protected ITTTextBox CardOrderNO;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox NATOStockNO;
        protected ITTTextBox CardAmount;
        protected ITTLabel labelStatus;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelCardAmount;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTButton ttbutton1;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCreationDate;
        protected ITTCheckBox SortType;
        protected ITTLabel labelDistributionType;
        protected ITTLabel labelCardOrderNO;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelName;
        protected ITTObjectListBox DistributionType;
        protected ITTLabel labelNATOStockNO;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage DependencyMaterialTabPage;
        protected ITTButton cmdDrugDefinition;
        protected ITTButton AddMaterialButton;
        protected ITTGrid Materials;
        protected ITTTextBoxColumn MaterialName;
        protected ITTButton RemoveMaterialButton;
        protected ITTButton cmdConsumableDefinition;
        protected ITTButton cmdFixedAssetDefinition;
        protected ITTTabPage AccountancyStockCardTabPage;
        protected ITTGrid AccountancyStockCards;
        protected ITTListBoxColumn AccountancyAccountancyStockCard;
        protected ITTListBoxColumn CardDrawerAccountancyStockCard;
        protected ITTTextBoxColumn CardOrderNOAccountancyStockCard;
        protected ITTTextBoxColumn CardAmountAccountancyStockCard;
        protected ITTEnumComboBoxColumn StatusAccountancyStockCard;
        protected ITTDateTimePickerColumn CreationDateAccountancyStockCard;
        protected ITTTextBoxColumn DescriptionAccountancyStockCard;
        protected ITTTabPage RENTabPage;
        protected ITTCheckBox MainStoreCheckbox;
        protected ITTCheckBox RepairCheckbox;
        protected ITTCheckBox ProductionCheckbox;
        protected ITTCheckBox AllowLevelUpdateCheckbox;
        protected ITTTabPage MaterialStocksTabPage;
        protected ITTGrid MaterialStocksGrid;
        protected ITTListBoxColumn Material2;
        protected ITTTextBoxColumn Store;
        protected ITTTextBoxColumn Inheld;
        protected ITTTabPage DescriptionTabPage;
        protected ITTRichTextBoxControl Description;
        protected ITTTabPage PictureTabPage;
        protected ITTPictureBoxControl CardPicture;
        protected ITTTabPage ETKMDescriptionTabPage;
        protected ITTTextBox ETKMDescription;
        protected ITTLabel labelStockCardClass;
        protected ITTObjectListBox StockCardClass;
        protected ITTLabel labelNATOGroupCode;
        protected ITTObjectListBox NATOGroupCode;
        protected ITTLabel labelGMDNCode;
        protected ITTObjectListBox GMDNCode;
        protected ITTObjectListBox CardDrawer;
        protected ITTLabel labelCardDrawer;
        protected ITTEnumComboBox StockMethod;
        protected ITTLabel labelStockMethod;
        override protected void InitializeControls()
        {
            PurchaseGroup = (ITTObjectListBox)AddControl(new Guid("0b54dc1b-ab3e-4c10-a822-363bdbaa6d3b"));
            labelBaseMaterialGroup = (ITTLabel)AddControl(new Guid("a9d775f5-ad9f-430a-b886-68901803adfc"));
            CardOrderNO = (ITTTextBox)AddControl(new Guid("633adc88-6aff-472d-a45e-0887816ef2e9"));
            Name = (ITTTextBox)AddControl(new Guid("e6dfa940-38d5-4649-9d6b-5fb5be032fa8"));
            EnglishName = (ITTTextBox)AddControl(new Guid("03397d5e-b04a-4dd3-a0b4-6f95739f5adf"));
            NATOStockNO = (ITTTextBox)AddControl(new Guid("6747f448-01ca-4eec-9b94-75c854ccee1a"));
            CardAmount = (ITTTextBox)AddControl(new Guid("a6c59e7f-862f-4d11-8918-911bfd25f47a"));
            labelStatus = (ITTLabel)AddControl(new Guid("929c66d5-b609-4595-83f0-2e537e716c5e"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("7e6c8a66-a6dc-4465-bf1f-2f2a139c9d2c"));
            labelCardAmount = (ITTLabel)AddControl(new Guid("1aeb9314-1427-46ea-8ddf-320af5ea3eed"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("2b24897e-8948-403e-87b0-367fc39809a0"));
            ttbutton1 = (ITTButton)AddControl(new Guid("8c40a223-9298-408d-99ce-58a3b5d0d70e"));
            IsActive = (ITTCheckBox)AddControl(new Guid("a9ecc399-815c-4c6f-8c0a-6bbdc742e32f"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("8e40daf4-cc72-488d-a92a-6e859c733e8e"));
            SortType = (ITTCheckBox)AddControl(new Guid("b49b1645-f724-4809-9512-7443a2484f0a"));
            labelDistributionType = (ITTLabel)AddControl(new Guid("9e18e98b-6c55-498b-b73c-97586d63ca89"));
            labelCardOrderNO = (ITTLabel)AddControl(new Guid("70680e17-aaee-403e-b4c9-c1421b06e70e"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("a331bdc9-54fd-47cf-9bb2-c462edf181c9"));
            labelName = (ITTLabel)AddControl(new Guid("cd101d2a-699b-4199-bef0-cd02b30197f1"));
            DistributionType = (ITTObjectListBox)AddControl(new Guid("8d81585c-88ce-4a19-a069-d6c10264a25d"));
            labelNATOStockNO = (ITTLabel)AddControl(new Guid("846f2d17-97cc-4a2d-a6fc-da77d217cf04"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("88fd5e87-b132-4793-8eab-dfd1a0d344d4"));
            DependencyMaterialTabPage = (ITTTabPage)AddControl(new Guid("e532df2b-3d46-4151-8cc2-0c759d59364c"));
            cmdDrugDefinition = (ITTButton)AddControl(new Guid("d7e97fe5-7296-4fd8-85b9-5c651daf96fc"));
            AddMaterialButton = (ITTButton)AddControl(new Guid("404a6f3f-aea7-42f0-abb9-12401b3fad0b"));
            Materials = (ITTGrid)AddControl(new Guid("d2b5c030-7c24-4c21-b77b-c4f6b95a8be1"));
            MaterialName = (ITTTextBoxColumn)AddControl(new Guid("302c24ef-814a-439e-a902-de53065ddf51"));
            RemoveMaterialButton = (ITTButton)AddControl(new Guid("8181c9d6-1ae1-4ccb-98d3-fecc4dcdf1a2"));
            cmdConsumableDefinition = (ITTButton)AddControl(new Guid("f880f748-2823-4947-a1f0-49af09cb901d"));
            cmdFixedAssetDefinition = (ITTButton)AddControl(new Guid("0c251f46-38ca-459e-a3b0-cc01e1197e8a"));
            AccountancyStockCardTabPage = (ITTTabPage)AddControl(new Guid("c198c8a7-9e27-4f87-8b83-987f8e2e5acb"));
            AccountancyStockCards = (ITTGrid)AddControl(new Guid("63bd103d-ccf0-44c3-b8b8-174ded8b3d55"));
            AccountancyAccountancyStockCard = (ITTListBoxColumn)AddControl(new Guid("122c47b2-5163-4cf9-981a-21d06c6b8bad"));
            CardDrawerAccountancyStockCard = (ITTListBoxColumn)AddControl(new Guid("5b92e3bd-0f93-4a0a-9fb9-cee4d1f207c4"));
            CardOrderNOAccountancyStockCard = (ITTTextBoxColumn)AddControl(new Guid("674be297-6941-44ea-8147-24bef718ff26"));
            CardAmountAccountancyStockCard = (ITTTextBoxColumn)AddControl(new Guid("914c5651-c6fc-4a77-940b-8ce63fefebe7"));
            StatusAccountancyStockCard = (ITTEnumComboBoxColumn)AddControl(new Guid("3ef3c3fd-8485-499f-8f2f-d7134b7f08bf"));
            CreationDateAccountancyStockCard = (ITTDateTimePickerColumn)AddControl(new Guid("391d1cb0-a438-48dd-a0d3-53e81beef862"));
            DescriptionAccountancyStockCard = (ITTTextBoxColumn)AddControl(new Guid("13a488cd-b08b-450c-a83b-5ef6285ac569"));
            RENTabPage = (ITTTabPage)AddControl(new Guid("4cdce5f1-948f-4133-8026-e25392ac3174"));
            MainStoreCheckbox = (ITTCheckBox)AddControl(new Guid("e00d6305-5fe2-4771-973d-c73c86c9b3f9"));
            RepairCheckbox = (ITTCheckBox)AddControl(new Guid("f9f2e33a-f665-4d9c-b9c7-5773a46e193c"));
            ProductionCheckbox = (ITTCheckBox)AddControl(new Guid("af2d2f0d-82ad-43c8-934d-ef383bfe5caa"));
            AllowLevelUpdateCheckbox = (ITTCheckBox)AddControl(new Guid("d198a058-dab8-43af-a992-738b7b240ed8"));
            MaterialStocksTabPage = (ITTTabPage)AddControl(new Guid("36c6f18c-1d50-4eda-bf57-3553314a4406"));
            MaterialStocksGrid = (ITTGrid)AddControl(new Guid("e96f65c0-fdcf-492e-9b32-c75169273ba6"));
            Material2 = (ITTListBoxColumn)AddControl(new Guid("57a811d7-1d64-4bb2-b39e-a021a6dceaef"));
            Store = (ITTTextBoxColumn)AddControl(new Guid("f6e4f96b-8dca-4a3d-8c3d-e9d59195d70b"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("942aa1b6-5634-4f8c-89aa-ddcf218b2bf6"));
            DescriptionTabPage = (ITTTabPage)AddControl(new Guid("e50889ca-ae09-4fda-a502-b36693cfcbea"));
            Description = (ITTRichTextBoxControl)AddControl(new Guid("d11ee86d-192b-46eb-91d6-3284a6466293"));
            PictureTabPage = (ITTTabPage)AddControl(new Guid("189cf92a-f686-4f55-81a0-4c332181867e"));
            CardPicture = (ITTPictureBoxControl)AddControl(new Guid("4502bdd6-fe73-499d-919d-772307834657"));
            ETKMDescriptionTabPage = (ITTTabPage)AddControl(new Guid("d58af531-a8dc-4179-90ef-16f1d62f054a"));
            ETKMDescription = (ITTTextBox)AddControl(new Guid("74e451bf-078a-4ac9-a1d1-11bb8ad84e50"));
            labelStockCardClass = (ITTLabel)AddControl(new Guid("3ecf7fc0-afbb-4810-900f-edd5fff66088"));
            StockCardClass = (ITTObjectListBox)AddControl(new Guid("20494ea0-5942-4f5e-aaa0-fb521d0a95f4"));
            labelNATOGroupCode = (ITTLabel)AddControl(new Guid("75a97ebb-7721-4830-8bb3-996d9645ff89"));
            NATOGroupCode = (ITTObjectListBox)AddControl(new Guid("f14aecc9-b903-4b57-8b43-ae8d3ce894e3"));
            labelGMDNCode = (ITTLabel)AddControl(new Guid("9e38c47d-f496-46c4-834d-5d8311185629"));
            GMDNCode = (ITTObjectListBox)AddControl(new Guid("50c2fb3d-5252-47be-b3e2-d70cd403fcaf"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("ea779b4f-4f61-41a6-b0c6-a0192621c8c6"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("e1547e4a-162f-4194-a4f9-022b4a63cf40"));
            StockMethod = (ITTEnumComboBox)AddControl(new Guid("e229c359-f9a1-43ea-aa53-71ed5e9c80b0"));
            labelStockMethod = (ITTLabel)AddControl(new Guid("291dc4a4-8a66-403b-a3d2-b67864afc283"));
            base.InitializeControls();
        }

        public StockCardForm() : base("STOCKCARD", "StockCardForm")
        {
        }

        protected StockCardForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}