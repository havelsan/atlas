
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi
    /// </summary>
    public partial class BaseProductionConsumptionDocumentForm : StockActionBaseForm
    {
    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi  için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ProductionConsumptionDocument _ProductionConsumptionDocument
        {
            get { return (TTObjectClasses.ProductionConsumptionDocument)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker TRANSACTIONDATE;
        protected ITTObjectListBox Store;
        protected ITTLabel LABELSTORE;
        protected ITTTextBox STOCKACTIONID;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker EndDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel LABELSTOCKACTIONID;
        protected ITTLabel LABELTRANSACTIONDATE;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialOutTabpage;
        protected ITTGrid ProductionConsumptionDocumentOutMaterials;
        protected ITTListBoxColumn MaterialProductionConsumptionDocumentMaterialOut;
        protected ITTTextBoxColumn BarcodeT;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn AmountProductionConsumptionDocumentMaterialOut;
        protected ITTListBoxColumn StockLevelTypeProductionConsumptionDocumentMaterialOut;
        protected ITTEnumComboBoxColumn StatusProductionConsumptionDocumentMaterialOut;
        protected ITTTabPage MaterialInTabpage;
        protected ITTGrid ProductionConsumptionDocumentInMaterials;
        protected ITTListBoxColumn MaterialProductionConsumptionDocumentMaterialIn;
        protected ITTTextBoxColumn BarcodeU;
        protected ITTTextBoxColumn InDistributionType;
        protected ITTTextBoxColumn InStoreStock;
        protected ITTTextBoxColumn AmountProductionConsumptionDocumentMaterialIn;
        protected ITTTextBoxColumn UnitPriceProductionConsumptionDocumentMaterialIn;
        protected ITTDateTimePickerColumn ExpirationDateProductionConsumptionDocumentMaterialIn;
        protected ITTListBoxColumn StockLevelTypeProductionConsumptionDocumentMaterialIn;
        protected ITTEnumComboBoxColumn StatusProductionConsumptionDocumentMaterialIn;
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
            ttlabel1 = (ITTLabel)AddControl(new Guid("17770d60-3b19-4612-9ace-d3884d064368"));
            TRANSACTIONDATE = (ITTDateTimePicker)AddControl(new Guid("6deddf60-b9c1-492b-a281-e4c919a0d0a5"));
            Store = (ITTObjectListBox)AddControl(new Guid("6cf34447-e649-4b16-9b10-64562d1c1c8e"));
            LABELSTORE = (ITTLabel)AddControl(new Guid("8b36655a-c952-425e-8ea8-bf61dc956a5b"));
            STOCKACTIONID = (ITTTextBox)AddControl(new Guid("ccc40c43-7e19-412d-9def-472e79ece8c5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9095c24d-4986-40f5-bfe3-e8da970d8499"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("c9522bee-fef6-4f2d-8fb8-cca49ea80ff0"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("403a9f36-7eda-4445-babe-401ba26bd8ed"));
            LABELSTOCKACTIONID = (ITTLabel)AddControl(new Guid("71edd862-a311-40d1-8136-ad39eebe89b7"));
            LABELTRANSACTIONDATE = (ITTLabel)AddControl(new Guid("f4eae68e-dc5c-49bd-9027-2e185b7e88ed"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1da30609-c45e-486b-90e9-da28cc1eb064"));
            MaterialOutTabpage = (ITTTabPage)AddControl(new Guid("d0def51c-59d6-4d64-b187-db5706489e36"));
            ProductionConsumptionDocumentOutMaterials = (ITTGrid)AddControl(new Guid("454126c3-248a-48ca-84d5-93e539a0b684"));
            MaterialProductionConsumptionDocumentMaterialOut = (ITTListBoxColumn)AddControl(new Guid("5f6e8915-bfa3-4760-b434-ede4e23cacb6"));
            BarcodeT = (ITTTextBoxColumn)AddControl(new Guid("e406a8fc-afa9-48a0-8201-85cc231a448a"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("bc78079d-c1bf-4078-b23e-1c7bb78f24c3"));
            AmountProductionConsumptionDocumentMaterialOut = (ITTTextBoxColumn)AddControl(new Guid("56373da1-6d16-40b1-980c-fabb5b1979d7"));
            StockLevelTypeProductionConsumptionDocumentMaterialOut = (ITTListBoxColumn)AddControl(new Guid("6cf6e4a9-e18f-406f-b65a-dc96b643446d"));
            StatusProductionConsumptionDocumentMaterialOut = (ITTEnumComboBoxColumn)AddControl(new Guid("ea165da2-9745-488a-baba-9e3b222378ad"));
            MaterialInTabpage = (ITTTabPage)AddControl(new Guid("f4667b2d-2753-4da0-8059-6c5a28e70364"));
            ProductionConsumptionDocumentInMaterials = (ITTGrid)AddControl(new Guid("92db8f34-2b69-4788-8f3a-48150e248cd5"));
            MaterialProductionConsumptionDocumentMaterialIn = (ITTListBoxColumn)AddControl(new Guid("a1661a27-1ef2-4c27-b26a-0e3f03fc0e0b"));
            BarcodeU = (ITTTextBoxColumn)AddControl(new Guid("8d19173a-5248-4589-851f-b193da2d555e"));
            InDistributionType = (ITTTextBoxColumn)AddControl(new Guid("a9657ce1-82db-4167-9590-1befe65008b1"));
            InStoreStock = (ITTTextBoxColumn)AddControl(new Guid("223c37da-61be-41d6-87b7-79f1ba856617"));
            AmountProductionConsumptionDocumentMaterialIn = (ITTTextBoxColumn)AddControl(new Guid("9413b1f9-f180-4b16-be86-59fbd70e748d"));
            UnitPriceProductionConsumptionDocumentMaterialIn = (ITTTextBoxColumn)AddControl(new Guid("7414f9d2-638b-431e-a424-abc0bab492a9"));
            ExpirationDateProductionConsumptionDocumentMaterialIn = (ITTDateTimePickerColumn)AddControl(new Guid("248dff70-aea9-4572-a858-b032e595d027"));
            StockLevelTypeProductionConsumptionDocumentMaterialIn = (ITTListBoxColumn)AddControl(new Guid("b8fe73ca-38e0-4c6b-bf66-c469b26dc0ba"));
            StatusProductionConsumptionDocumentMaterialIn = (ITTEnumComboBoxColumn)AddControl(new Guid("a5733559-3714-44c7-89b7-bf6464b46663"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("e72ed549-5693-433d-869b-0184595552b6"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("45c89c74-af7a-4c44-b7cc-7848ed8280d9"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("4c460912-f6ed-4578-8dd1-41e4a814b7cf"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("a0d6b761-c79a-49f1-9a48-218dfdcaf30c"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("9dd2713f-a3a1-4f88-ad2e-f1ddd304bc81"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("fe0de3bc-cea8-42fe-85bd-7a114c0bffe5"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("2a4c2864-70da-4735-9f97-9ad83751793d"));
            Description = (ITTTextBox)AddControl(new Guid("705a4455-c3ff-45b7-83c8-e962dc7fac58"));
            base.InitializeControls();
        }

        public BaseProductionConsumptionDocumentForm() : base("PRODUCTIONCONSUMPTIONDOCUMENT", "BaseProductionConsumptionDocumentForm")
        {
        }

        protected BaseProductionConsumptionDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}