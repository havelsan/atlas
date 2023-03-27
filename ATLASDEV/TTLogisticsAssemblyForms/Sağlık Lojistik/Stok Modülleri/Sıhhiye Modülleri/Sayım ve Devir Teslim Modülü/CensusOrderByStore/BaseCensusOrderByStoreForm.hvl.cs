
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
    /// Depoya Göre Sayım Emri Belgesi
    /// </summary>
    public partial class BaseCensusOrderByStoreForm : StockActionBaseForm
    {
    /// <summary>
    /// Sayım işlemi depo seçilerek
    /// </summary>
        protected TTObjectClasses.CensusOrderByStore _CensusOrderByStore
        {
            get { return (TTObjectClasses.CensusOrderByStore)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid CensusOrderDetails;
        protected ITTTextBoxColumn OrderSequenceNumberCensusOrderDetail;
        protected ITTListBoxColumn MaterialCensusOrderDetail;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn StockCard;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn NewInheldCensusOrderDetail;
        protected ITTTextBoxColumn UsedInheldCensusOrderDetail;
        protected ITTTextBoxColumn ConsignedCensusOrderDetail;
        protected ITTTextBoxColumn CensusNewInheldCensusOrderDetail;
        protected ITTTextBoxColumn CensusUsedInheldCensusOrderDetail;
        protected ITTTextBoxColumn DescriptionCensusOrderDetail;
        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox Store;
        protected ITTEnumComboBox CensusOrderType;
        protected ITTLabel labelCensusOrderType;
        protected ITTLabel labelStore;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage SingTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        protected ITTDateTimePicker TransactionDate;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("45d3af55-c8da-4792-9d3c-9aff794ee137"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("676239dd-5145-4afb-a5fd-1e472524f4b9"));
            CensusOrderDetails = (ITTGrid)AddControl(new Guid("dc6f9578-e2a0-4232-b128-952bf3812c1d"));
            OrderSequenceNumberCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("c1a80dba-1900-454f-9cf0-7a41f0c34dde"));
            MaterialCensusOrderDetail = (ITTListBoxColumn)AddControl(new Guid("5795985d-2f5c-48ea-8560-3db71b32bef8"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("21799a73-d067-4c03-b2c2-0043f824f09f"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("fa86e7a9-9d85-45e1-b353-9b75e98677df"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("4ec313b6-34e3-4304-8d77-09ebbd5b860e"));
            NewInheldCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("cefc5900-3137-4c15-8681-df3a09f58f87"));
            UsedInheldCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("794d159a-1dbb-4975-8a27-4d6def901c44"));
            ConsignedCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("d530a72c-b7bf-4d7f-beaa-5f60bb3e0c13"));
            CensusNewInheldCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("030f4cf7-a924-4b93-868e-0e740f40dbf1"));
            CensusUsedInheldCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("ca12b52f-a7db-436c-9cbb-9a0ccfce893d"));
            DescriptionCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("6cea861f-9ea0-4fe2-b980-0f5250bec8e6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("fe14bb48-7f64-4aff-8f15-cb6ac425ccaa"));
            Store = (ITTObjectListBox)AddControl(new Guid("60fd79ad-a22d-4136-9688-871a17abf081"));
            CensusOrderType = (ITTEnumComboBox)AddControl(new Guid("a35b67b5-98b7-4f20-97b7-0b0aa9fd2a89"));
            labelCensusOrderType = (ITTLabel)AddControl(new Guid("326e2738-fbf0-4ad7-93c8-464fafb34af8"));
            labelStore = (ITTLabel)AddControl(new Guid("4762cb60-3bf2-48d3-9527-a546c3bce201"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("4f08b3b8-ee86-475f-a1aa-13b13dd33259"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("e8c2be2b-03c9-4347-a813-79f0503bff29"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("4fd5e888-5a67-43e6-a3c7-ad90030bbb5e"));
            SingTabpage = (ITTTabPage)AddControl(new Guid("0e3ef114-0d1b-41c6-a3c8-7335ba03bde0"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("f2e48267-334f-4ecc-8af9-e15b2a3898bd"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("fb3e148d-8b26-4dcb-9722-390969186828"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("d3b29bbc-b3e0-43df-80aa-6d760fb62edd"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("d53f4195-5492-44b4-89ae-df8c35ed4f1f"));
            Description = (ITTTextBox)AddControl(new Guid("d9b15c30-4bba-4fd1-bb6f-c3c29e743651"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("0a2c5a9c-d16f-4334-8f10-41c481742395"));
            base.InitializeControls();
        }

        public BaseCensusOrderByStoreForm() : base("CENSUSORDERBYSTORE", "BaseCensusOrderByStoreForm")
        {
        }

        protected BaseCensusOrderByStoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}