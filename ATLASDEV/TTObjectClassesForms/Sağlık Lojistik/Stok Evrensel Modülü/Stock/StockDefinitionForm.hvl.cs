
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
    /// Stok Tanımı
    /// </summary>
    public partial class StockDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Bir deponun bir stok kartı ile ilgili mevcut, kritik seviye, maksimum seviye ve benzeri bilgilerini tutan sınıftır
    /// </summary>
        protected TTObjectClasses.Stock _Stock
        {
            get { return (TTObjectClasses.Stock)_ttObject; }
        }

        protected ITTCheckBox Expendable;
        protected ITTObjectListBox Material;
        protected ITTTextBox MinimumLevel;
        protected ITTTextBox SafetyLevel;
        protected ITTTextBox Consigned;
        protected ITTTextBox Inheld;
        protected ITTTextBox MaximumLevel;
        protected ITTLabel labelSafetyLevel;
        protected ITTLabel labelMaximumLevel;
        protected ITTLabel labelConsigned;
        protected ITTLabel labelStore;
        protected ITTLabel labelInheld;
        protected ITTObjectListBox Store;
        protected ITTLabel labelMaterial;
        protected ITTLabel labelMinimumLevel;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid StockLevels;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn StockLevelType;
        protected ITTTabPage tttabpage2;
        protected ITTGrid StockReservations;
        protected ITTTextBoxColumn ReservedAmount;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage tttabpage3;
        protected ITTGrid StoreLocations;
        protected ITTListBoxColumn StockLocationStoreLocation;
        protected ITTTabPage tttabpage4;
        protected ITTGrid StockExpendableDetails;
        protected ITTDateTimePickerColumn StartDateStockExpendableDetail;
        protected ITTDateTimePickerColumn EndDateStockExpendableDetail;
        protected ITTTextBoxColumn DescriptionStockExpendableDetail;
        override protected void InitializeControls()
        {
            Expendable = (ITTCheckBox)AddControl(new Guid("fec45e77-e8b7-4f00-b428-c3de79c803dd"));
            Material = (ITTObjectListBox)AddControl(new Guid("f68a3a4f-626b-4a68-aa01-b91137ff4980"));
            MinimumLevel = (ITTTextBox)AddControl(new Guid("34064539-c194-4e85-9457-d533ae659eb7"));
            SafetyLevel = (ITTTextBox)AddControl(new Guid("353ea4a9-75d4-4398-9cfa-e9d6c4704ada"));
            Consigned = (ITTTextBox)AddControl(new Guid("0fae8570-cde3-4d71-ae97-2c8e6163da16"));
            Inheld = (ITTTextBox)AddControl(new Guid("e87f370e-c01c-45ab-a8a2-6c0fa92789aa"));
            MaximumLevel = (ITTTextBox)AddControl(new Guid("9b31a945-86dc-4909-81b6-163c7742ee17"));
            labelSafetyLevel = (ITTLabel)AddControl(new Guid("66b5c155-4cd1-40aa-9bc7-7d491ed42bc1"));
            labelMaximumLevel = (ITTLabel)AddControl(new Guid("4b5e8b40-a50e-4ca1-ad35-7a970c15b4bf"));
            labelConsigned = (ITTLabel)AddControl(new Guid("3ce33384-0f77-43ff-afec-ee091f17f593"));
            labelStore = (ITTLabel)AddControl(new Guid("3ff4c077-2065-4efb-87eb-24a62e0345ca"));
            labelInheld = (ITTLabel)AddControl(new Guid("5281c886-3744-4c82-a286-7c000704562e"));
            Store = (ITTObjectListBox)AddControl(new Guid("1a467b9a-47c4-4640-b782-c209cc4d4069"));
            labelMaterial = (ITTLabel)AddControl(new Guid("3b830f31-333c-4b97-84fb-5ba0d2794b17"));
            labelMinimumLevel = (ITTLabel)AddControl(new Guid("13f69f46-7729-490c-b62b-0f4f3a311c71"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a1a14150-707a-476c-a0f6-33fd984281e5"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("069ed28e-1226-4880-bb0b-d2d3173f5b26"));
            StockLevels = (ITTGrid)AddControl(new Guid("e92acadf-0199-4de2-bef0-c34c2d77941d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("36307be5-0441-4762-b3b6-e56e8383d624"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("edd4deef-5cc4-4843-b36a-cf3369557106"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("d8e96c31-0199-4088-aa2f-a39d6df57e9f"));
            StockReservations = (ITTGrid)AddControl(new Guid("b655272b-8e7c-4942-ac16-7f563c2e6229"));
            ReservedAmount = (ITTTextBoxColumn)AddControl(new Guid("0a75c4a2-b79a-44e1-9640-39fb95ad8d98"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("537a6fbe-cf0a-484a-a835-f4d48d158713"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("66fc58af-3f30-485b-bc27-7e96d2c57e1d"));
            StoreLocations = (ITTGrid)AddControl(new Guid("8dc14056-c73f-4d36-8769-ce4b339f44ee"));
            StockLocationStoreLocation = (ITTListBoxColumn)AddControl(new Guid("0bc6d702-4c1b-4010-8f43-b28d0c1d199f"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("17231ee6-34cc-4cea-9d7b-18a6fa7df82e"));
            StockExpendableDetails = (ITTGrid)AddControl(new Guid("07be3ebf-5416-4f9d-a759-bfd27a101bbb"));
            StartDateStockExpendableDetail = (ITTDateTimePickerColumn)AddControl(new Guid("e3603383-3a9b-4bec-b10c-e88fc7fc2aaa"));
            EndDateStockExpendableDetail = (ITTDateTimePickerColumn)AddControl(new Guid("e7fd6f2b-eb5f-4566-a950-1d44cc6cb665"));
            DescriptionStockExpendableDetail = (ITTTextBoxColumn)AddControl(new Guid("cede185f-bb79-4729-8d47-f9cd066084ce"));
            base.InitializeControls();
        }

        public StockDefinitionForm() : base("STOCK", "StockDefinitionForm")
        {
        }

        protected StockDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}