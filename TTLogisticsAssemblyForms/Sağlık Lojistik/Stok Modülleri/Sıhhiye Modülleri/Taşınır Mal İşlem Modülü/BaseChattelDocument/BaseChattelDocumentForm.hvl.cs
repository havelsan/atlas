
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
    public partial class BaseChattelDocumentForm : StockActionBaseForm
    {
        protected TTObjectClasses.BaseChattelDocument _BaseChattelDocument
        {
            get { return (TTObjectClasses.BaseChattelDocument)_ttObject; }
        }

        protected ITTButton TTTeslimEdenButon;
        protected ITTButton TTTeslimAlanButon;
        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("d51188e6-cffd-4d11-a4c9-b536ceb68402"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("3ffa78ad-0d9e-44d2-bc37-a793ffa6e799"));
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("2ac6b8d6-f9f0-41b4-a984-4880736f9d71"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("f289e7cf-dc09-44e3-b43c-8d95bc13df23"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("92110068-364b-4cee-872a-95bbf6ab6846"));
            Description = (ITTTextBox)AddControl(new Guid("5a8ffd5c-b794-4773-ac5d-09bdc114d7a8"));
            StockActionID = (ITTTextBox)AddControl(new Guid("72bc8edd-e358-4c85-89ff-7c377edef05a"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("ddb40773-8a99-4adc-a3d9-fe36cf230103"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("163f38e4-7a16-41e2-bfeb-6ffe5756f2bb"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("894e7d45-2f78-43e0-bf6f-b2964a6a501f"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("4885a95b-8bb6-4b76-ad6c-e18d5d4148ce"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("119191fe-ce4d-4952-8bb7-ae1ee60eb8fe"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("1badfeba-f502-4dde-99bb-7e9151dd57af"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("6610a017-bfeb-480a-a11c-d0af1e3d98db"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("795eb8d8-7e95-430b-a69b-7bc02ee8e549"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("47bbd0e5-519b-4001-8450-44bcf9bd186c"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("163b757b-017f-435e-af25-bf8c86574cd7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fea7391f-251e-412f-ac5f-49bdc4a3344e"));
            base.InitializeControls();
        }

        public BaseChattelDocumentForm() : base("BASECHATTELDOCUMENT", "BaseChattelDocumentForm")
        {
        }

        protected BaseChattelDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}