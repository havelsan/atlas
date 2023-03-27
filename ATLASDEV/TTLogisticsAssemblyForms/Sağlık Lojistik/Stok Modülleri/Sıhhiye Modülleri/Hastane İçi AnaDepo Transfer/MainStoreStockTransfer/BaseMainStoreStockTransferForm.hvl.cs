
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
    public partial class BaseMainStoreStockTransferForm : StockActionBaseForm
    {
    /// <summary>
    /// Ana Depolar Arası Transfer
    /// </summary>
        protected TTObjectClasses.MainStoreStockTransfer _MainStoreStockTransfer
        {
            get { return (TTObjectClasses.MainStoreStockTransfer)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTextBox ID;
        protected ITTLabel labelMKYS_EMalzemeGrup;
        protected ITTEnumComboBox MKYS_EMalzemeGrup;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid MainStoreStockTransferMaterials;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialMainStoreStockTransferMat;
        protected ITTTextBoxColumn MaterialBarcode;
        protected ITTTextBoxColumn Distrubitontype;
        protected ITTTextBoxColumn RequestAmountSubStoreStockTransferMat;
        protected ITTTextBoxColumn AmountSubStoreStockTransferMat;
        protected ITTListBoxColumn StockLevelType;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTButton TTTeslimAlanButon;
        protected ITTButton TTTeslimEdenButon;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("c7486e52-8fb2-4d74-bd8a-a8347e5f26d0"));
            ID = (ITTTextBox)AddControl(new Guid("2d9de302-d5e8-433f-9c89-0be4cbc90b01"));
            labelMKYS_EMalzemeGrup = (ITTLabel)AddControl(new Guid("d0b0173f-da9a-479f-b7e0-78249408acc1"));
            MKYS_EMalzemeGrup = (ITTEnumComboBox)AddControl(new Guid("eb9f30f8-01ce-4b53-b371-8a2d6c64243a"));
            labelStore = (ITTLabel)AddControl(new Guid("9ab0dcf3-5dcb-444a-b3d6-4db76220312e"));
            Store = (ITTObjectListBox)AddControl(new Guid("34a564ee-5eaa-4167-b52f-0ea8a2286a37"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("0e5e7459-ef3d-4538-8980-069dbcc74d2b"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("4fb10e5d-70b4-4f92-be82-f1a9ed03cbf8"));
            labelActionDate = (ITTLabel)AddControl(new Guid("b0c465c8-717d-423e-8a3a-0b55f2efb798"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ea793368-ac4b-46eb-aa09-1dc15bb47b4e"));
            labelID = (ITTLabel)AddControl(new Guid("60b118db-aded-467b-bf5b-bdd5e8da2b2d"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("22553c22-8bc7-456d-8730-dcb20c958661"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("76cc63be-9f26-42e1-a87e-3ffe548b7c04"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("5562a53c-d21c-4ee0-aa9b-e67986209532"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("fcae0c3c-6769-4763-8ed6-5df3d7e26fc2"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("2aae582e-73b4-4a83-bb84-29a8e42f54be"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("9b3dd22f-1e37-424e-92b2-85196fe0887c"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("1fbb695e-9df9-478e-95e5-7aba7b2a5a9a"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("7f769daf-b3cc-4697-832c-430a74a08237"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("33a2b952-36e5-401b-aeec-9d7f94ef761c"));
            MainStoreStockTransferMaterials = (ITTGrid)AddControl(new Guid("d868edfd-bb8c-4aab-9e63-e776fa1a749e"));
            Detail = (ITTButtonColumn)AddControl(new Guid("19f0aa3a-71dc-47f7-bc5c-524d98a3b233"));
            MaterialMainStoreStockTransferMat = (ITTListBoxColumn)AddControl(new Guid("428c30cb-9f6e-41a6-a350-a8f71c52091e"));
            MaterialBarcode = (ITTTextBoxColumn)AddControl(new Guid("8e41e407-c84b-4fb5-962b-cb13fae3be5e"));
            Distrubitontype = (ITTTextBoxColumn)AddControl(new Guid("906c64a1-3795-4d47-bdcf-24c44875ca5d"));
            RequestAmountSubStoreStockTransferMat = (ITTTextBoxColumn)AddControl(new Guid("3f63391e-6946-48dc-a81b-61ec5f45ec35"));
            AmountSubStoreStockTransferMat = (ITTTextBoxColumn)AddControl(new Guid("d27ca6d2-4284-46a6-8967-c55e3b26e2e6"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("a30d4b25-396b-4dc6-8320-9132b6772815"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("4a3a43db-20fb-44e9-ac10-7604e76adee2"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("2079b7ce-4626-461c-a82f-25b94c9d792d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a1b1b85e-016d-4dce-b32c-18ba29b658ee"));
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("83aac89d-cdb5-4bcb-963f-c5f8f03f24ee"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("414afae6-96dd-4764-958f-6a46f295ad0a"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("bfad2a03-09fe-47d1-ac32-9f2cca1ca5a7"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("65436899-2e99-42eb-8559-22127be1bea0"));
            base.InitializeControls();
        }

        public BaseMainStoreStockTransferForm() : base("MAINSTORESTOCKTRANSFER", "BaseMainStoreStockTransferForm")
        {
        }

        protected BaseMainStoreStockTransferForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}