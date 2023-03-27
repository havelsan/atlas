
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
    /// İade Belgesi
    /// </summary>
    public partial class BaseReturningDocumentForm : StockActionBaseForm
    {
    /// <summary>
    /// İade Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ReturningDocument _ReturningDocument
        {
            get { return (TTObjectClasses.ReturningDocument)_ttObject; }
        }

        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTButton cmdHEKReport;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Existing;
        protected ITTTextBoxColumn RequireAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTButton ChooseProductsFromTheTree;
        protected ITTEnumComboBox MKYS_EMalzemeGrup;
        protected ITTLabel labelMKYS_EMalzemeGrup;
        protected ITTLabel ttlabel1;
        protected ITTButton TTTeslimAlanButon;
        protected ITTButton TTTeslimEdenButon;
        override protected void InitializeControls()
        {
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("99ec79a4-610b-494b-a498-2e46b6ec1228"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("04480527-6965-4679-b073-4bc1a1f107b6"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("8c638633-c56e-4ebc-84f0-4f65a34b8270"));
            Description = (ITTTextBox)AddControl(new Guid("7f14d94a-07be-4cea-a093-57c53b8583c2"));
            StockActionID = (ITTTextBox)AddControl(new Guid("38855e41-1cc1-4072-932f-df058213ae1c"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("6de0f47c-7ccd-4215-8194-008dbf707ee0"));
            labelStore = (ITTLabel)AddControl(new Guid("77c90670-b9e6-4a3e-ab40-420cbd798f1e"));
            Store = (ITTObjectListBox)AddControl(new Guid("90f73d2e-e746-4908-98f6-78cfa99e897f"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("fb4f2708-c09a-4fd4-b13a-853113c07712"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("97d93d4f-0c48-4362-a042-035f4a32feb4"));
            cmdHEKReport = (ITTButton)AddControl(new Guid("ea240b6c-05bf-44ac-8467-b3ba2b654448"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("b793f52f-6dd4-4770-bd82-8d3fcf68d42f"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("5e64c88a-8a92-4747-b023-c6e93d0b7eb4"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("6388fc1c-3da3-4c6b-9200-2edf994d4d9b"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("759113ef-49aa-4fd5-b954-29020c69b38b"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("86d4c32b-5052-48e3-82fc-11c32ac48fde"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("721d6602-9e98-410d-8589-2cef1ac9f4a9"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("fa8bbcb6-ad55-4a32-a561-bb919e34e679"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("ea1d71f5-beed-4c2c-97d9-bd3343e6b8f0"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("28a090c8-a141-407b-9905-5aaee2920650"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("157dec54-7cb0-4853-94fd-41608e46062d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a4c27e82-2e75-40a0-a914-2cc9d934e3a3"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("b37b5efb-f8c4-4576-9a20-7144cfd154ae"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("07d159d8-947b-441a-83c5-2bbcd06de66e"));
            Detail = (ITTButtonColumn)AddControl(new Guid("3edb06ec-2015-45cd-986f-e5f380a7700d"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a1f078fb-1e9e-49db-944c-a59b56dc535b"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("07c335ae-cd36-4a82-b3da-fc623d931c20"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("3ef7ab89-7138-4365-a63d-4c0a78e77da9"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("16d6d018-4492-4084-831d-3d91eb3b2a52"));
            RequireAmount = (ITTTextBoxColumn)AddControl(new Guid("199fda1d-38d6-45f5-b00c-9c93c48257ab"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("53c798f8-57ce-4ebc-aad8-2848bc287639"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("80f9c3f3-2f20-42d9-868a-2a722fd7ac4d"));
            ChooseProductsFromTheTree = (ITTButton)AddControl(new Guid("bed39a6e-86bd-468d-9b23-19bb19c5f971"));
            MKYS_EMalzemeGrup = (ITTEnumComboBox)AddControl(new Guid("f2b04d0c-7b24-46ed-a6b9-1f3efe39fa8e"));
            labelMKYS_EMalzemeGrup = (ITTLabel)AddControl(new Guid("edc2a1e7-7402-4d65-8ea8-a8aea16967bf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e2da0a17-9866-4553-8dfd-82faf38d3435"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("0bd92ca5-1e34-4046-a0f1-95b3de05b0dc"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("f016cf6a-616a-4519-9f92-ce70383f9c66"));
            base.InitializeControls();
        }

        public BaseReturningDocumentForm() : base("RETURNINGDOCUMENT", "BaseReturningDocumentForm")
        {
        }

        protected BaseReturningDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}