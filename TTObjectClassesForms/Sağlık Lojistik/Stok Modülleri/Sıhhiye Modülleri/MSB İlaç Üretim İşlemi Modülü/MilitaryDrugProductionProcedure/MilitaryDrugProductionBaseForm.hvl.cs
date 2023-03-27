
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
    /// MSB İlaç Üretim İşlemi
    /// </summary>
    public partial class MilitaryDrugProductionBaseForm : StockActionBaseForm
    {
    /// <summary>
    /// MSB İlaç Üretim İşlemi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.MilitaryDrugProductionProcedure _MilitaryDrugProductionProcedure
        {
            get { return (TTObjectClasses.MilitaryDrugProductionProcedure)_ttObject; }
        }

        protected ITTLabel labelExpirationDateOfProduction;
        protected ITTDateTimePicker ExpirationDateOfProduction;
        protected ITTLabel labelTransactionDate;
        protected ITTMaskedTextBox ttmaskedtextbox1;
        protected ITTObjectListBox DestinationStore;
        protected ITTTextBox ProductName;
        protected ITTLabel labelStore;
        protected ITTTabControl ProductionTabcontrol;
        protected ITTTabPage ProductionTabpage;
        protected ITTLabel labelRequirementAmount;
        protected ITTTextBox RequirementAmount;
        protected ITTTextBox ProducedMaterialAmount;
        protected ITTObjectListBox ProducedMaterial;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelOrderDecisionDate;
        protected ITTObjectListBox ProductAnnualReqDet;
        protected ITTTabPage ProductionDescriptionTabPage;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelOrderName;
        protected ITTLabel labelOrderNO;
        protected ITTDateTimePicker TransactionDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn SerialNumber;
        protected ITTTextBoxColumn Existing;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTextBoxColumn Description;
        protected ITTEnumComboBoxColumn Status;
        protected ITTTabPage CompletedAnalysisTestPage;
        protected ITTButton TestRequest;
        protected ITTGrid DrugProductionTests;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn AnalyseNo;
        protected ITTStateComboBoxColumn ObjectCurrentStateDef;
        protected ITTLabel labelRepeatCount;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelExpirationDateOfProduction = (ITTLabel)AddControl(new Guid("3fc17ad1-8c6b-4d3e-ab3d-0404720ffc54"));
            ExpirationDateOfProduction = (ITTDateTimePicker)AddControl(new Guid("b9aa9005-d029-4173-97b4-6308fc32d69f"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("d876a454-2ac1-4108-b96d-a3e16704197b"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("83f72ee8-07c6-4c09-8b3b-5d7e014ec5a9"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("e7d038d0-f443-4d4d-a0d6-a6a7d58e373f"));
            ProductName = (ITTTextBox)AddControl(new Guid("7a09e915-bc2a-4416-b7f8-059fefa58e34"));
            labelStore = (ITTLabel)AddControl(new Guid("a590054e-744d-47ec-a5dd-265cf81753e6"));
            ProductionTabcontrol = (ITTTabControl)AddControl(new Guid("fac1d43b-0454-4126-b948-4d213df5a73f"));
            ProductionTabpage = (ITTTabPage)AddControl(new Guid("ebb539cc-b1c2-4847-8da5-5ad8d74b47d5"));
            labelRequirementAmount = (ITTLabel)AddControl(new Guid("9b919d5a-c593-4d73-9a69-020e48b64280"));
            RequirementAmount = (ITTTextBox)AddControl(new Guid("25eaf4e4-fb0d-4ef1-b23d-fa85696bb392"));
            ProducedMaterialAmount = (ITTTextBox)AddControl(new Guid("4087d8b6-4dac-418c-9d6d-185611f118f2"));
            ProducedMaterial = (ITTObjectListBox)AddControl(new Guid("b8d19ebb-11eb-454d-87e4-9ffd8717de9a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cc9ccb4b-e28f-42ef-afb9-c9b0300dccd7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e5264ef0-315d-4224-89c4-6ec5198ab100"));
            labelOrderDecisionDate = (ITTLabel)AddControl(new Guid("98bd29e8-7375-4fc0-b118-8ed934ad58f9"));
            ProductAnnualReqDet = (ITTObjectListBox)AddControl(new Guid("5ab8fedd-e51e-442e-8189-7ea7ff9a2a55"));
            ProductionDescriptionTabPage = (ITTTabPage)AddControl(new Guid("3baff7ed-c316-4258-ae7f-6307baa4ab4c"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("4fc68c4d-0caa-416e-97dd-f7529134055f"));
            StockActionID = (ITTTextBox)AddControl(new Guid("ab6bed2c-6e59-406a-8319-3a23025477bd"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("238c020d-94df-4138-9687-d4484b885ee6"));
            labelOrderName = (ITTLabel)AddControl(new Guid("85731734-21d7-427f-ae43-bfe9a4c105b5"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("3aa3d47b-1c71-459d-b6eb-090582ea02fd"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("1e80d0f3-8b9f-4643-bed9-e6909f6d685e"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("b6e00730-08cd-4543-aabc-579156d1759b"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("f4aff22d-eb28-4656-992b-af949904fa33"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("d390dc48-ba7f-4a35-b7a4-2a144ad1f8c8"));
            Material = (ITTListBoxColumn)AddControl(new Guid("3ebde159-fae8-4902-afca-b5864d52bafb"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("455b58cb-340d-43fb-98dc-ac5ab4fddf2b"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("8a16776e-f0c4-4fb6-be68-6a536044bd13"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("defe68a9-d06a-450c-b32f-8b692fdef673"));
            SerialNumber = (ITTTextBoxColumn)AddControl(new Guid("f82b23b2-497e-434d-9217-f8ea528d03b6"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("9a72afc0-b7ca-4244-a86e-e0dbbaebd396"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("4ec38ba6-fbd7-436a-a995-f88d29bff3c9"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("92ed2752-0fe4-4b48-b4a5-dee2120323d6"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("7cf7ea97-167a-4ee4-bdf0-da12561ac0bb"));
            CompletedAnalysisTestPage = (ITTTabPage)AddControl(new Guid("645dae2b-e3b6-4f4a-9597-2c2baf923ba5"));
            TestRequest = (ITTButton)AddControl(new Guid("4cfdc34a-6aad-4dc7-bd0c-aa309c11294e"));
            DrugProductionTests = (ITTGrid)AddControl(new Guid("8f8a9c1e-452a-499e-aeb7-3ed77d57518c"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("dd89ce33-7089-4e3c-b9eb-138860f2b19a"));
            AnalyseNo = (ITTTextBoxColumn)AddControl(new Guid("1b1236c4-fce0-4a27-956d-d702cb8debb4"));
            ObjectCurrentStateDef = (ITTStateComboBoxColumn)AddControl(new Guid("49b3ab39-2297-46f1-82e4-3a4226721da6"));
            labelRepeatCount = (ITTLabel)AddControl(new Guid("ec22420d-b9e2-4ec0-b662-af93aac3e92a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7059ed4b-a134-4619-b2ac-2da5c7eed10c"));
            base.InitializeControls();
        }

        public MilitaryDrugProductionBaseForm() : base("MILITARYDRUGPRODUCTIONPROCEDURE", "MilitaryDrugProductionBaseForm")
        {
        }

        protected MilitaryDrugProductionBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}