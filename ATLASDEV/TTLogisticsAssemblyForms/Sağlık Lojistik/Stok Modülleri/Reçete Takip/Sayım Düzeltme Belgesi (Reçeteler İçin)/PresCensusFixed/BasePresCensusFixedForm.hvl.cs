
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
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresCensusFixedForm : StockActionBaseForm
    {
    /// <summary>
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresCensusFixed _PresCensusFixed
        {
            get { return (TTObjectClasses.PresCensusFixed)_ttObject; }
        }

        protected ITTObjectListBox ChattelInventoryObjectID;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelChattelInventoryObjectID;
        protected ITTGroupBox InMaterialsGroupBox;
        protected ITTGrid PresCensusFixedInMaterials;
        protected ITTButtonColumn InDetail;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn BarcodeA;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn OrderSequenceNumber;
        protected ITTTextBoxColumn CardAmount;
        protected ITTTextBoxColumn CensusAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn LotNo;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTGroupBox OutMaterialsGroupBox;
        protected ITTGrid PresCensusFixedOutMaterials;
        protected ITTButtonColumn OutDetail;
        protected ITTListBoxColumn MaterialOut;
        protected ITTTextBoxColumn BarcodeE;
        protected ITTTextBoxColumn DistributionTypeOut;
        protected ITTTextBoxColumn StoreStockOut;
        protected ITTTextBoxColumn OrderSequenceNumberOut;
        protected ITTTextBoxColumn CardAmountOut;
        protected ITTTextBoxColumn CensusAmountOut;
        protected ITTTextBoxColumn AmountlOut;
        protected ITTListDefComboBoxColumn StockLevelTypeOut;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            ChattelInventoryObjectID = (ITTObjectListBox)AddControl(new Guid("e6052402-3409-4651-bb64-76fc5d31d9d1"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("ee48f9c1-6f70-4d9f-9292-6cf81cf017f0"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("ef5a4da3-8390-4027-a2d1-195b94ec0e84"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("6b731463-fe0f-4abf-9428-7bf592472684"));
            StockActionID = (ITTTextBox)AddControl(new Guid("425f0da1-09a4-41d1-9379-713442b4ddf5"));
            labelChattelInventoryObjectID = (ITTLabel)AddControl(new Guid("c71fd712-56cc-4e71-9468-047c19a48fbf"));
            InMaterialsGroupBox = (ITTGroupBox)AddControl(new Guid("01208a4f-cf23-4d46-94b7-65f45f2a7634"));
            PresCensusFixedInMaterials = (ITTGrid)AddControl(new Guid("b6319cac-30e3-4c26-b594-78e4388e91e2"));
            InDetail = (ITTButtonColumn)AddControl(new Guid("c196faba-2cbe-408d-920d-7d9de7b30e8b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("7d9998cd-4b86-474f-9b9b-782a48e9227b"));
            BarcodeA = (ITTTextBoxColumn)AddControl(new Guid("6389bd4a-3bb6-4091-9c3d-a6469c230af2"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("5ea1e046-ef8c-477f-83ab-c84e4fda0b8a"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("a08a1737-3776-42f1-9102-bfaf0c93b369"));
            OrderSequenceNumber = (ITTTextBoxColumn)AddControl(new Guid("eb81f829-64af-4d25-866f-13607745c825"));
            CardAmount = (ITTTextBoxColumn)AddControl(new Guid("e06b9fab-8052-49f2-b49e-b22757533ce1"));
            CensusAmount = (ITTTextBoxColumn)AddControl(new Guid("4391b7b6-be98-49e2-a052-130ae2a4dfa6"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("12bd1f89-8ad3-4e2e-affa-ce4d33564b01"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("393565f6-4be7-4492-9949-c789e6197da4"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("e4001bb4-cec2-4b71-a46a-659ed705ff95"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("1eed51ce-1e17-481e-804d-a1bbd6815cd3"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("eef9a2f3-230f-43b7-965d-30a6993fe532"));
            OutMaterialsGroupBox = (ITTGroupBox)AddControl(new Guid("18edc260-a695-43b1-ae3e-c5bdf3e10d0d"));
            PresCensusFixedOutMaterials = (ITTGrid)AddControl(new Guid("12acb154-4251-409f-b600-bb016afbf85f"));
            OutDetail = (ITTButtonColumn)AddControl(new Guid("face4536-38df-432a-8f1e-c2393d874743"));
            MaterialOut = (ITTListBoxColumn)AddControl(new Guid("d5d7e180-4fb7-4f96-a417-936aef8b8875"));
            BarcodeE = (ITTTextBoxColumn)AddControl(new Guid("d3e7d39f-3a16-4dc0-ae69-f507bc40796d"));
            DistributionTypeOut = (ITTTextBoxColumn)AddControl(new Guid("0ba7640d-ffbc-4e64-9b9f-085d487b1d67"));
            StoreStockOut = (ITTTextBoxColumn)AddControl(new Guid("f88e84f2-2d73-4df7-a6fe-dd7a971f6dd8"));
            OrderSequenceNumberOut = (ITTTextBoxColumn)AddControl(new Guid("b1004896-0410-4226-8ebc-bd357c2c1dc1"));
            CardAmountOut = (ITTTextBoxColumn)AddControl(new Guid("ff8b1caa-3561-468a-b525-28bfeb4a3841"));
            CensusAmountOut = (ITTTextBoxColumn)AddControl(new Guid("7474ee44-8941-4280-90dc-a4144a4265d4"));
            AmountlOut = (ITTTextBoxColumn)AddControl(new Guid("110fae95-ed1c-4265-8074-50429736f887"));
            StockLevelTypeOut = (ITTListDefComboBoxColumn)AddControl(new Guid("3db7c546-ddc3-4f53-b8c2-40b5afd6573a"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("5a61b331-071a-4ce1-9fa9-a4aff61054ee"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("f80feda2-98a6-4ec8-ab64-0f8e03598fe2"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("4efdea6b-a721-4363-859c-f1bc37acc5ee"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("59e835f6-9dd0-4145-afd1-b3ad34cfb75a"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("9c7d5517-63c0-4b0c-892e-8129762c42b7"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("8a39499f-47c3-4950-a8b4-ae3d3452f7ee"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("cb4dc370-7154-40d0-b389-6f27dd91e23b"));
            Description = (ITTTextBox)AddControl(new Guid("81fbf877-7d2e-4abf-ac2b-0653b9a1da09"));
            base.InitializeControls();
        }

        public BasePresCensusFixedForm() : base("PRESCENSUSFIXED", "BasePresCensusFixedForm")
        {
        }

        protected BasePresCensusFixedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}