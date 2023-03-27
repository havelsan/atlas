
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
    /// Ürün Ağacı Tanımları
    /// </summary>
    public partial class ProductTreeDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ürün Ağacı Tanımları
    /// </summary>
        protected TTObjectClasses.ProductTreeDefinition _ProductTreeDefinition
        {
            get { return (TTObjectClasses.ProductTreeDefinition)_ttObject; }
        }

        protected ITTLabel labelSampleAmount;
        protected ITTTextBox SampleAmount;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialComponentTabPage;
        protected ITTGrid ConsumableMaterialDefinitions;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn StockCardDistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage ProductAnnualReqDetTabpage;
        protected ITTGrid ProductAnnualReqDets;
        protected ITTTextBoxColumn IBFYear;
        protected ITTTextBoxColumn RequirementAmount;
        protected ITTTextBoxColumn LossPercentage;
        protected ITTButtonColumn cmdRefresh;
        protected ITTButtonColumn Calculating;
        protected ITTTabPage AnalysesTestDefTab;
        protected ITTGrid AnalyseTestsGrid;
        protected ITTListBoxColumn AnalyseTestDef;
        protected ITTTextBox NATOStockNO;
        protected ITTLabel labelConsumableMaterialDefinition;
        protected ITTObjectListBox ConsumableMaterialListBox;
        protected ITTLabel labelNATOStockNO;
        protected ITTLabel labelDistributionType;
        protected ITTObjectListBox DistributionType;
        protected ITTObjectListBox ProductionService;
        protected ITTLabel labelProductionService;
        override protected void InitializeControls()
        {
            labelSampleAmount = (ITTLabel)AddControl(new Guid("8308c9fc-7061-42b2-82cf-056b3dcf0c82"));
            SampleAmount = (ITTTextBox)AddControl(new Guid("b0ec8719-8f9b-4ba9-a9ba-35ba6d14f8ca"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1eb41784-a54f-4519-8daf-7440e0bf88ce"));
            MaterialComponentTabPage = (ITTTabPage)AddControl(new Guid("d4531d8b-26ca-44ba-834c-00fcd9954713"));
            ConsumableMaterialDefinitions = (ITTGrid)AddControl(new Guid("a0d2edb9-9f30-4e97-81f8-f97ed51a4d45"));
            Material = (ITTListBoxColumn)AddControl(new Guid("bccbb575-67cc-4771-ac90-d3bce03c1ac3"));
            StockCardDistributionType = (ITTListBoxColumn)AddControl(new Guid("6d564190-34a5-4a75-b4bb-7ccc26a55e71"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b2366f6a-0633-4257-9018-404b286103c9"));
            ProductAnnualReqDetTabpage = (ITTTabPage)AddControl(new Guid("b1511d99-39a3-481a-bd5a-1a720e045cc9"));
            ProductAnnualReqDets = (ITTGrid)AddControl(new Guid("d7b3f3c5-a89f-4d6f-a1ab-a384e35706c4"));
            IBFYear = (ITTTextBoxColumn)AddControl(new Guid("e3f12f0a-56bf-46c1-a681-1409980657d8"));
            RequirementAmount = (ITTTextBoxColumn)AddControl(new Guid("9e690ca4-d92f-48fc-9139-6d5583b75b0f"));
            LossPercentage = (ITTTextBoxColumn)AddControl(new Guid("342383f0-ecd5-4ea3-b138-3092634fde27"));
            cmdRefresh = (ITTButtonColumn)AddControl(new Guid("435b0878-c57b-40ef-ada9-213aaf3f4d64"));
            Calculating = (ITTButtonColumn)AddControl(new Guid("3ccecf52-5bb5-4912-a6b3-10584ce57621"));
            AnalysesTestDefTab = (ITTTabPage)AddControl(new Guid("62e767cd-8a12-45ac-86a7-d9ac639f1ad1"));
            AnalyseTestsGrid = (ITTGrid)AddControl(new Guid("fbd375e7-0c09-408f-a0ec-e7381711b9a1"));
            AnalyseTestDef = (ITTListBoxColumn)AddControl(new Guid("bfe79777-a093-4b8e-b5c2-ea0e41d1ebcf"));
            NATOStockNO = (ITTTextBox)AddControl(new Guid("d2a1e726-a0ad-4711-a60f-9887d0d0b0a2"));
            labelConsumableMaterialDefinition = (ITTLabel)AddControl(new Guid("45a03510-e27b-4784-b81e-f77ea5cd5bc6"));
            ConsumableMaterialListBox = (ITTObjectListBox)AddControl(new Guid("976869d7-e9d5-4059-b9b6-76e0b25ef4d0"));
            labelNATOStockNO = (ITTLabel)AddControl(new Guid("80ef79d1-7bdf-482d-9500-83e24635f003"));
            labelDistributionType = (ITTLabel)AddControl(new Guid("8e8ce64c-8d59-44da-ad4a-47f9e47bf154"));
            DistributionType = (ITTObjectListBox)AddControl(new Guid("78aa0a79-58a4-42bf-89c5-653887d5e94b"));
            ProductionService = (ITTObjectListBox)AddControl(new Guid("3183e876-8ea8-4926-acba-44bbdd24d385"));
            labelProductionService = (ITTLabel)AddControl(new Guid("26411ac2-007f-4794-9c3d-1865c7578e3b"));
            base.InitializeControls();
        }

        public ProductTreeDefinitionForm() : base("PRODUCTTREEDEFINITION", "ProductTreeDefinitionForm")
        {
        }

        protected ProductTreeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}