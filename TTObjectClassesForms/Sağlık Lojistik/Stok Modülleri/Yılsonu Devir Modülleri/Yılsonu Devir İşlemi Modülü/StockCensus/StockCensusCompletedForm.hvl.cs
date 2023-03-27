
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
    /// Yıl Sonu Devri
    /// </summary>
    public partial class StockCensusCompletedForm : TTForm
    {
    /// <summary>
    /// Yılsonu Devir İşlemi
    /// </summary>
        protected TTObjectClasses.StockCensus _StockCensus
        {
            get { return (TTObjectClasses.StockCensus)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox MaterialCensus;
        protected ITTTextBox OldMaterialCensus;
        protected ITTTextBox NewMaterialCensus;
        protected ITTTextBox TotalCardAmount;
        protected ITTTextBox NormalCardAmount;
        protected ITTTextBox NewCardAmount;
        protected ITTTextBox ZeroCensus;
        protected ITTTextBox OldZeroCensus;
        protected ITTTextBox NewZeroCensus;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker label333;
        protected ITTLabel TTLabel2;
        protected ITTLabel TTLabel1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox AccountingTerm;
        protected ITTObjectListBox CardDrawer;
        protected ITTObjectListBox Store;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTGrid StockCensusDetails;
        protected ITTTextBoxColumn NatoStockNo;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn StockCard;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn BeforeOrderNo;
        protected ITTTextBoxColumn OrderNo;
        protected ITTTextBoxColumn YearCensus;
        protected ITTTextBoxColumn TotalIn;
        protected ITTTextBoxColumn TotalInPrice;
        protected ITTTextBoxColumn TotalOut;
        protected ITTTextBoxColumn TotalOutPrice;
        protected ITTTextBoxColumn Inheld;
        protected ITTTextBoxColumn Used;
        protected ITTTextBoxColumn Consigned;
        protected ITTTextBoxColumn TotalInheld;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2934ec0c-331b-4c2c-9552-f339b2b78849"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("17fd961e-5661-4e4c-9064-7a0c4d500563"));
            MaterialCensus = (ITTTextBox)AddControl(new Guid("5002cb52-840b-49f3-8e3f-3d773888b16e"));
            OldMaterialCensus = (ITTTextBox)AddControl(new Guid("51e3e596-5d65-4e27-af3f-d6772172dd12"));
            NewMaterialCensus = (ITTTextBox)AddControl(new Guid("bc050989-5153-4ab3-bc5b-85a63875492b"));
            TotalCardAmount = (ITTTextBox)AddControl(new Guid("af664141-466c-48ba-94cd-740e418c4e86"));
            NormalCardAmount = (ITTTextBox)AddControl(new Guid("e5955294-ed25-4f74-b056-c2edd8a07fb7"));
            NewCardAmount = (ITTTextBox)AddControl(new Guid("2a840d33-644b-4a47-8658-7d7b78c84705"));
            ZeroCensus = (ITTTextBox)AddControl(new Guid("a680a095-9b2c-48cc-b956-881ae382822c"));
            OldZeroCensus = (ITTTextBox)AddControl(new Guid("03e9c7be-0e7a-4ca6-b68f-251f5f3d5113"));
            NewZeroCensus = (ITTTextBox)AddControl(new Guid("7142b95e-f456-4bd4-a0f8-ec918052ff6c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b4723bf3-1a89-48b6-af88-1b4e39459200"));
            label333 = (ITTDateTimePicker)AddControl(new Guid("c538a943-eab3-4f39-bf66-1b5b5c42abba"));
            TTLabel2 = (ITTLabel)AddControl(new Guid("4567a85d-0412-4f5f-945b-851c8d67976c"));
            TTLabel1 = (ITTLabel)AddControl(new Guid("31afa177-fd6c-4ae2-b417-6b61a8310b46"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2ac17c23-f8e7-4e80-b07f-35f6b5e0de26"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4125dcf7-f6f3-4619-bc4d-c22abceb3127"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4e5793fb-b093-4b0a-b979-154b4b0eaada"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("a3fc2b64-3ccc-4632-9692-e34f7463eab8"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("48a24768-ceb5-4f53-96a2-b774e4ea1e71"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("11bf26e9-ad56-450f-aabf-a1d64a8699ca"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cd4e9d2b-8c90-4059-bb81-933ff0933108"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("5e2fdf1f-152b-4fbe-a17b-2f1a612a6719"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("23484994-1ce7-401d-926e-93c822845431"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("f8520f71-28e4-4cc3-ad3f-4df15ab5af9b"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("3e2c3e99-23ba-4443-bd47-52fcce802465"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("946aabf6-fbbb-482e-9214-b0edbd3cb3a4"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("f772d130-1648-49c8-be47-4fcf22509333"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("2f9e1f90-2d3d-4a3c-b4bd-46fc5dcacb32"));
            Store = (ITTObjectListBox)AddControl(new Guid("d28b39e4-34ca-45c5-8485-8c2962ad7d95"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("21a63010-c8f6-4134-9d26-494fb87267f8"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("f3ddb066-73b1-404d-bf8e-0901310266b3"));
            StockCensusDetails = (ITTGrid)AddControl(new Guid("b7b149d6-213d-498b-aaea-a354634329ca"));
            NatoStockNo = (ITTTextBoxColumn)AddControl(new Guid("958162c2-aa7d-47b4-b90c-a8be6f96f672"));
            Material = (ITTListBoxColumn)AddControl(new Guid("e71ab703-4e4f-48bf-b322-4eec5dca39e5"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("84d35b49-fd27-49c8-aebe-f7a3cfbf3f25"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("05aee533-df6f-436f-9326-dcfd5afe4126"));
            BeforeOrderNo = (ITTTextBoxColumn)AddControl(new Guid("6296ec0b-e62c-481d-8dd7-ba53e8ab272e"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("1e502da6-d554-4dca-bcbb-d8fe934df8bd"));
            YearCensus = (ITTTextBoxColumn)AddControl(new Guid("d3693c7e-a4ac-4f41-996b-32a0056870ac"));
            TotalIn = (ITTTextBoxColumn)AddControl(new Guid("9b266a16-1f40-4c16-b806-de96b43be735"));
            TotalInPrice = (ITTTextBoxColumn)AddControl(new Guid("4982723e-812e-499e-84bf-7fa0ad68e233"));
            TotalOut = (ITTTextBoxColumn)AddControl(new Guid("c61920d8-0c7d-49f2-abab-bd40eb6a30d8"));
            TotalOutPrice = (ITTTextBoxColumn)AddControl(new Guid("f1467126-7b5c-49e9-804d-9ae876c402af"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("41cd9c1d-91c4-4c6f-9fb0-e2e66e06e97e"));
            Used = (ITTTextBoxColumn)AddControl(new Guid("2cfd3a4a-ed4f-4f57-95be-3556c8ba4d94"));
            Consigned = (ITTTextBoxColumn)AddControl(new Guid("33677478-9c83-4654-a4df-715f4f5d9801"));
            TotalInheld = (ITTTextBoxColumn)AddControl(new Guid("2fbf8242-027d-4ed8-a4ed-5b2b1f8cdceb"));
            base.InitializeControls();
        }

        public StockCensusCompletedForm() : base("STOCKCENSUS", "StockCensusCompletedForm")
        {
        }

        protected StockCensusCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}