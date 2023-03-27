
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
    /// Devir Teslim Belgesi
    /// </summary>
    public partial class BaseHandoverDocumentForm : StockActionBaseForm
    {
    /// <summary>
    /// Devir Teslim Belgesi
    /// </summary>
        protected TTObjectClasses.HandoverDocument _HandoverDocument
        {
            get { return (TTObjectClasses.HandoverDocument)_ttObject; }
        }

        protected ITTLabel labelCensusOrderType;
        protected ITTEnumComboBox CensusOrderType;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelCardDrawer;
        protected ITTObjectListBox CardDrawer;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid CensusOrderDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn StockCard;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn Inheld;
        protected ITTTextBoxColumn UsedInheld;
        protected ITTTextBoxColumn Remant;
        protected ITTTextBoxColumn Absent;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            labelCensusOrderType = (ITTLabel)AddControl(new Guid("8985c49d-1840-4a7a-b575-5c80afbd6631"));
            CensusOrderType = (ITTEnumComboBox)AddControl(new Guid("159b638b-24e6-4c49-aeff-9ca22beea92b"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("b2513f86-e474-4b51-b0a7-744707b0c3d8"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("7facdd70-41ef-4706-8254-58ab1dd9b5b8"));
            labelStore = (ITTLabel)AddControl(new Guid("f40a1f23-e1c0-465f-8c67-471af2381374"));
            Store = (ITTObjectListBox)AddControl(new Guid("e1c113c0-4a87-4dfc-aaca-94fee49c0cfe"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("62f687ef-5777-41df-873d-87f0e942773f"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("1d21cd27-205a-4396-8ad1-256ec15362be"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("321eeab8-2a02-4410-8afb-202aa7659590"));
            StockActionID = (ITTTextBox)AddControl(new Guid("e4b27b78-2b0f-4ba6-8ebd-98fe116f63b5"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("de4cc558-4f63-4069-9756-51518a73892a"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("ef0a0f4a-d2e0-4552-bfbb-779c9f6632e7"));
            CensusOrderDetails = (ITTGrid)AddControl(new Guid("bce7c08e-8c8a-4462-be03-4cbf7eb66665"));
            Material = (ITTListBoxColumn)AddControl(new Guid("f896d779-254c-4e0c-a061-7f5153c60362"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("8009f8b3-6b6b-4f68-bef8-fe7a32f2faf9"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("232ba5a8-c388-4547-82f3-0a2360f9be79"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("3e441f56-bd23-41aa-bd43-654afdce6d11"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("c1de0a77-1e5e-4e73-b566-53958afb57ac"));
            UsedInheld = (ITTTextBoxColumn)AddControl(new Guid("fb4473f9-eda6-4362-8201-932a71e87100"));
            Remant = (ITTTextBoxColumn)AddControl(new Guid("be997252-5047-4e44-aaf7-21da3f8f33b7"));
            Absent = (ITTTextBoxColumn)AddControl(new Guid("f2d211c3-ecd1-4e0f-9701-b39da8b68e6a"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("1210559a-5e20-4cd9-8d80-ea5fffd19c16"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("2bd9f836-07cf-45bc-8222-8854aa4ea16a"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("a9248e8d-98ba-4500-b0af-8b9338cc3a33"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("bc833f21-646d-4d49-9d68-2bbddd3fcb90"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("8634da82-7e3b-437f-a838-74df3647bb6a"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("e21e0da7-cbbe-4ad1-acc3-c52dc6b5edb6"));
            Description = (ITTTextBox)AddControl(new Guid("28a4a390-382e-4ff1-a411-9a02c1bfe77e"));
            base.InitializeControls();
        }

        public BaseHandoverDocumentForm() : base("HANDOVERDOCUMENT", "BaseHandoverDocumentForm")
        {
        }

        protected BaseHandoverDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}