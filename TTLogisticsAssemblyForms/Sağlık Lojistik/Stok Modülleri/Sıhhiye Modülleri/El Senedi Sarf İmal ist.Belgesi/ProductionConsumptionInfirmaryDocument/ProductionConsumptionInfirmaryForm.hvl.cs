
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
    /// El Senedi Sarf İmal İstihsal Belgesi
    /// </summary>
    public partial class ProductionConsumptionInfirmaryForm : StockActionBaseForm
    {
    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi
    /// </summary>
        protected TTObjectClasses.ProductionConsumptionInfirmaryDocument _ProductionConsumptionInfirmaryDocument
        {
            get { return (TTObjectClasses.ProductionConsumptionInfirmaryDocument)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker TRANSACTIONDATE;
        protected ITTObjectListBox Store;
        protected ITTLabel LABELSTORE;
        protected ITTTextBox STOCKACTIONID;
        protected ITTTextBox Description;
        protected ITTDateTimePicker EndDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialOutTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn Existing;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTEnumComboBoxColumn Status;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel LABELSTOCKACTIONID;
        protected ITTLabel LABELTRANSACTIONDATE;
        protected ITTLabel LABELDESCRIPTION;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("fd357641-a245-460d-ab0a-4859d07c2b4a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4ac28c14-10a1-48eb-a472-f7f44166ae18"));
            TRANSACTIONDATE = (ITTDateTimePicker)AddControl(new Guid("b4b211df-e8e9-4305-bad5-ad43552be9fc"));
            Store = (ITTObjectListBox)AddControl(new Guid("a5ea2288-b8ed-4dcc-a7e5-730539ba1497"));
            LABELSTORE = (ITTLabel)AddControl(new Guid("32921f72-78de-4f25-9a78-45ab10585323"));
            STOCKACTIONID = (ITTTextBox)AddControl(new Guid("270358da-6cd4-44f7-82eb-a4c5d16d28eb"));
            Description = (ITTTextBox)AddControl(new Guid("1fcc650e-a44d-48ff-9c97-e2d83c32bff7"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("33323da6-70d3-4fdc-acc3-02efde0d5be9"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9d132ecb-b825-4a08-bd57-1472a3bee556"));
            MaterialOutTabPage = (ITTTabPage)AddControl(new Guid("7bc32ccc-1d25-46d1-9b34-b484ee9cb1a1"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("3603c07c-befb-401a-b0fe-c2bc2691d6ba"));
            Material = (ITTListBoxColumn)AddControl(new Guid("2e67da59-13a3-4e95-91f0-6d96afa33f75"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("4f3d2e6a-86d4-4a1e-a8bc-8ef81f1e1bf0"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("daad2a7c-9cff-41c7-a245-170b91789afa"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("380ee674-02d0-4580-9b6b-a8e282532ec6"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("50a3d475-6669-49d4-9111-247762970802"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("0b75c12c-09bc-4604-a4b0-59fe6c97992d"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("645ef53c-da72-42e6-a129-b1f84a8b9b91"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("b6a1621b-1ce4-4c40-88cb-3fd898955f50"));
            LABELSTOCKACTIONID = (ITTLabel)AddControl(new Guid("4d58d5fa-b2a5-42a8-8665-6e800c0cba6a"));
            LABELTRANSACTIONDATE = (ITTLabel)AddControl(new Guid("df13a5f7-aaa5-4a1d-bb6c-35aa1fa13c01"));
            LABELDESCRIPTION = (ITTLabel)AddControl(new Guid("6d7096ce-5160-430c-8c57-21eaf2de4dcf"));
            base.InitializeControls();
        }

        public ProductionConsumptionInfirmaryForm() : base("PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENT", "ProductionConsumptionInfirmaryForm")
        {
        }

        protected ProductionConsumptionInfirmaryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}