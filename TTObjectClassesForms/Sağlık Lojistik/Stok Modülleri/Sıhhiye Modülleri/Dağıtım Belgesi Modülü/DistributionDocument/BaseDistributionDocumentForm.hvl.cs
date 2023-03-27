
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
    /// Dağıtım Belgesi
    /// </summary>
    public partial class BaseDistributionDocumentForm : StockActionBaseForm
    {
    /// <summary>
    /// Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DistributionDocument _DistributionDocument
        {
            get { return (TTObjectClasses.DistributionDocument)_ttObject; }
        }

        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox Description;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTTabControl DistributionDocumentMaterialsTabcontrol;
        protected ITTTabPage DistributionDocumentMaterialsTabpage;
        protected ITTGrid DistributionDocumentMaterials;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialDistributionDocumentMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn AcceptedAmountDistributionDocumentMaterial;
        protected ITTTextBoxColumn AmountDistributionDocumentMaterial;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTListBoxColumn StockLevelTypeDistributionDocumentMaterial;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Price;
        protected ITTEnumComboBoxColumn StatusDistributionDocumentMaterial;
        protected ITTTextBox StockActionID;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelTransactionDate;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTEnumComboBox MKYS_CikisStokHareketTuru;
        protected ITTEnumComboBox MKYS_CikisIslemTuru;
        protected ITTLabel lblMKYS_CikisIslemTuru;
        protected ITTLabel lblMKYS_CikisStokHareketTuru;
        protected ITTLabel ttlabel1;
        protected ITTButton TTTeslimAlanButon;
        protected ITTButton TTTeslimEdenButon;
        override protected void InitializeControls()
        {
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("dbd19a39-579f-44ab-bcd7-720e840d73f1"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("cd99e2ae-544e-4340-a8ca-88d4256153ed"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("34f21ee5-a60d-46e6-aca9-67a6fcf86308"));
            Description = (ITTTextBox)AddControl(new Guid("51d8f77a-151a-43ca-9525-2807a41d3047"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("f336488d-168b-4f70-ad85-05ee262ec9cd"));
            labelStore = (ITTLabel)AddControl(new Guid("1d34eba4-3d09-445e-b123-8dc84b1b78f2"));
            Store = (ITTObjectListBox)AddControl(new Guid("fd24ab01-1cc0-4dc0-878c-1b54c112b0dd"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("409e7517-c76e-439f-8796-ebf259bfa8bc"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("241d28a0-2e9b-4a50-b15d-c55166328ecb"));
            DistributionDocumentMaterialsTabcontrol = (ITTTabControl)AddControl(new Guid("124d6df0-7b94-45d0-ba85-57e9229147f8"));
            DistributionDocumentMaterialsTabpage = (ITTTabPage)AddControl(new Guid("40089f6a-1a05-4fc5-b56e-1960423ddf52"));
            DistributionDocumentMaterials = (ITTGrid)AddControl(new Guid("cb4b4d87-7aac-48f3-b423-08bd657b0bbc"));
            Detail = (ITTButtonColumn)AddControl(new Guid("e03757b2-8d11-4887-98e5-84eb1879c7f6"));
            MaterialDistributionDocumentMaterial = (ITTListBoxColumn)AddControl(new Guid("b2c04fa2-e277-4903-aa9e-da653a9ee406"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("791e2d90-6c47-40d5-a095-144d36a9a32a"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("375d7638-fc3d-42c8-b5b9-0887a9b09253"));
            AcceptedAmountDistributionDocumentMaterial = (ITTTextBoxColumn)AddControl(new Guid("e7971707-d976-4262-bb72-202abfc481bc"));
            AmountDistributionDocumentMaterial = (ITTTextBoxColumn)AddControl(new Guid("160ef5ac-17da-4c33-8d65-2ddf99af467d"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("efeeebe2-ab2b-4eb6-961f-c3a403303cb6"));
            StockLevelTypeDistributionDocumentMaterial = (ITTListBoxColumn)AddControl(new Guid("18911238-d9f0-4f09-afb3-99796b2be23e"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("35acb6f0-ac7b-4bae-ba7a-079465735e33"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("47168085-3d73-4f70-9658-83e637d6670e"));
            StatusDistributionDocumentMaterial = (ITTEnumComboBoxColumn)AddControl(new Guid("3e824c8d-8b91-43ff-a2cb-0a3418880203"));
            StockActionID = (ITTTextBox)AddControl(new Guid("140c6c96-9764-4b47-bea9-b017c7ed2199"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("6c169279-8bee-4baa-9435-4cd699972181"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("a3682c5b-e17e-4103-ac7d-6c93c67bdade"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("b4e97ab1-3fc5-4dfe-8bde-5b89bfb69cde"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("43e8a13c-6950-41cb-aa2c-8e7c1833299e"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("92d2a17e-af10-44ab-9277-53142e3a59e7"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("699d787d-9b5a-4cc2-8de9-92b1a46904c7"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("8716dc2b-b52e-4b20-9bc2-9607554f89ee"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("c114b412-def2-4be9-a970-0f0a5eed2b9d"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("a1ec0143-2317-4ac0-a2d2-d6e069c68ff5"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("f46c7b12-983a-4564-b815-bdc39c6e632b"));
            MKYS_CikisStokHareketTuru = (ITTEnumComboBox)AddControl(new Guid("58198a72-4ea4-42af-adfb-41de519dc660"));
            MKYS_CikisIslemTuru = (ITTEnumComboBox)AddControl(new Guid("c4bfd2a4-e056-45e2-8335-a543f78e8093"));
            lblMKYS_CikisIslemTuru = (ITTLabel)AddControl(new Guid("7c3b3352-2fcb-4d74-91de-ebb9b3a845ca"));
            lblMKYS_CikisStokHareketTuru = (ITTLabel)AddControl(new Guid("87da741f-597a-40c7-8bdb-7870ffc8b4ca"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b165bdfa-946d-4a03-a834-53f5faf4f401"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("5fa1ab88-b648-46e3-a9ad-e7b174bea376"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("2fd22af5-a065-46fe-bd07-8e9bc6aa1e93"));
            base.InitializeControls();
        }

        public BaseDistributionDocumentForm() : base("DISTRIBUTIONDOCUMENT", "BaseDistributionDocumentForm")
        {
        }

        protected BaseDistributionDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}