
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
    /// Yılsonu Devir İşlemi
    /// </summary>
    public partial class StockCensusForm : TTForm
    {
    /// <summary>
    /// Yılsonu Devir İşlemi
    /// </summary>
        protected TTObjectClasses.StockCensus _StockCensus
        {
            get { return (TTObjectClasses.StockCensus)_ttObject; }
        }

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
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6e83ad44-f4e6-4745-8c3d-3a2269209ee0"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("3644c499-6930-44a4-a8c5-831410cf270b"));
            StockCensusDetails = (ITTGrid)AddControl(new Guid("0bef9c77-afde-4639-b67c-8ddb23e532ce"));
            NatoStockNo = (ITTTextBoxColumn)AddControl(new Guid("6f3e41bb-d39f-4bd8-99ef-456484cca9e0"));
            Material = (ITTListBoxColumn)AddControl(new Guid("014ef0a6-c45c-4a6d-8669-5154c9721d16"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("ffe6aa13-a180-482f-9428-9d299b6a46c9"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("6b2df0f6-5c2c-4fbe-89ff-89741827e628"));
            BeforeOrderNo = (ITTTextBoxColumn)AddControl(new Guid("027f764c-147a-4a01-8061-c2cd57751f04"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("cda8fbe9-711c-4aa2-95cd-3f010fa5f9c5"));
            YearCensus = (ITTTextBoxColumn)AddControl(new Guid("49b51f6e-0be4-4806-8d2f-8f0931ea2dad"));
            TotalIn = (ITTTextBoxColumn)AddControl(new Guid("12b6d0a8-e454-4b05-b8ee-5be5ae2b3fbd"));
            TotalInPrice = (ITTTextBoxColumn)AddControl(new Guid("64bdf944-3689-4017-889d-7b847a1e806f"));
            TotalOut = (ITTTextBoxColumn)AddControl(new Guid("f1144ca0-48b7-449d-a05c-453e496c3e44"));
            TotalOutPrice = (ITTTextBoxColumn)AddControl(new Guid("66fd8d26-8ad2-46d5-8f57-7354a0723070"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("9f3c3be7-df8a-4566-8a8b-fe40043205b1"));
            Used = (ITTTextBoxColumn)AddControl(new Guid("d4b4e2e0-0bd8-4b9e-b1c2-a6854176826a"));
            Consigned = (ITTTextBoxColumn)AddControl(new Guid("9960fa33-8401-4cf1-b2dc-e674e7760f60"));
            TotalInheld = (ITTTextBoxColumn)AddControl(new Guid("acb15bb0-af7b-47e3-8d48-73a639d55533"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5578fbca-eeaa-4701-8dae-764015651eed"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("b62929eb-a7f7-43bb-b8ea-45d62fe5ba6e"));
            MaterialCensus = (ITTTextBox)AddControl(new Guid("49c17be1-9397-4125-9410-a1bf327a68d3"));
            OldMaterialCensus = (ITTTextBox)AddControl(new Guid("dd250b3d-16ae-4544-84a9-b35ce800f152"));
            NewMaterialCensus = (ITTTextBox)AddControl(new Guid("dc4c1004-826c-4007-bd73-3f472fc367c3"));
            TotalCardAmount = (ITTTextBox)AddControl(new Guid("85fb05c1-03e8-4577-a6af-ad6e4c53764e"));
            NormalCardAmount = (ITTTextBox)AddControl(new Guid("28922606-3272-4c9c-bfa9-9c2f5148a4ca"));
            NewCardAmount = (ITTTextBox)AddControl(new Guid("ae55efba-d7cd-4a35-9b91-1c54ea1b699e"));
            ZeroCensus = (ITTTextBox)AddControl(new Guid("73ea135a-3b90-4343-8cd2-7ddc6d74eee0"));
            OldZeroCensus = (ITTTextBox)AddControl(new Guid("223c3d85-bff3-4573-b91b-e735d659cf30"));
            NewZeroCensus = (ITTTextBox)AddControl(new Guid("fda2fe77-4666-4d6e-a070-36c5fae9f105"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("41a54190-1ae5-44c6-b4bd-f59ef51a3260"));
            label333 = (ITTDateTimePicker)AddControl(new Guid("ef6b843c-c6f6-408e-a63b-a341aa20ab64"));
            TTLabel2 = (ITTLabel)AddControl(new Guid("9173ed6f-b7b2-4bd2-bc8f-d2d79315091d"));
            TTLabel1 = (ITTLabel)AddControl(new Guid("037b1c3f-c268-4e41-b39d-d075919e3461"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("37ca7adf-1aa3-4e3e-b365-a3a7a8c55004"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8f732691-655a-4474-9e09-7be27e5d7b73"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d954159a-01f2-46ac-aebe-c547536ef23b"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("26b6ea6c-46db-4879-b4d0-380e219737d1"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1b45930f-185d-44e0-8407-5e7dbc47187c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("f7901de4-be27-41da-8f74-056ce39a3e1b"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("ce5322a0-b087-4f44-98a9-5d2a5d99ee92"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("64b17da2-de4c-43c0-8b0a-65afab4a7b79"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("12743271-9f21-4554-9d67-222adbd0e04a"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("a7dadb6a-d927-4c63-af42-b7a95e9acc70"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("5b8bedf4-d155-4b44-83dd-7a2759caf795"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("7ba343c5-5350-402a-8f91-9aa360f662ff"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("36f1f79b-2068-4093-9b8b-2e711f51ac1a"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("bc161424-3f77-45ce-ac73-bb67aa2a9fab"));
            Store = (ITTObjectListBox)AddControl(new Guid("b3995c98-6df9-4407-a7e0-357256797dbd"));
            base.InitializeControls();
        }

        public StockCensusForm() : base("STOCKCENSUS", "StockCensusForm")
        {
        }

        protected StockCensusForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}