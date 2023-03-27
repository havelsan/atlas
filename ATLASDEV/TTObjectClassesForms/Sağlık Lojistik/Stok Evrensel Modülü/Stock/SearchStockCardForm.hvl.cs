
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
    /// Stok Kartı Arama Formu
    /// </summary>
    public partial class SearchStockCardForm : TTListForm
    {
        protected ITTLabel labelGMDNCodeMaterial;
        protected ITTObjectListBox GMDNCodeMaterial;
        protected ITTCheckBox IsIncludedDoubleZeroCard;
        protected ITTButton cmdChangeStore;
        protected ITTLabel labelBarcodeMaterial;
        protected ITTTextBox BarcodeMaterial;
        protected ITTTextBox NatoStockNo;
        protected ITTTextBox Name;
        protected ITTEnumComboBox StockCardStatus;
        protected ITTObjectListBox SelectedStockCardClass;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox SelectedStore;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox CardDrawer;
        protected ITTLabel labelCardDrawer;
        protected ITTEnumComboBox StockLevel;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelStockCardCount;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox PricingDetailDefinitionList;
        override protected void InitializeControls()
        {
            labelGMDNCodeMaterial = (ITTLabel)AddControl(new Guid("82d47f1f-3c8a-4acd-a2d7-fc22789bc2ab"));
            GMDNCodeMaterial = (ITTObjectListBox)AddControl(new Guid("a8e014f7-7701-4d92-a6c7-ed322b6cfa2a"));
            IsIncludedDoubleZeroCard = (ITTCheckBox)AddControl(new Guid("aeaa6f07-075d-4124-9f70-9ce7605a51aa"));
            cmdChangeStore = (ITTButton)AddControl(new Guid("b3709ab4-9023-4b75-9119-e7d6aa6ce55f"));
            labelBarcodeMaterial = (ITTLabel)AddControl(new Guid("2c993a3b-8aab-43f0-8840-a5dd076d3e39"));
            BarcodeMaterial = (ITTTextBox)AddControl(new Guid("a5c26a69-01b2-4911-896a-41ab1841dbd0"));
            NatoStockNo = (ITTTextBox)AddControl(new Guid("68ad758e-a422-40d6-815c-817557adfa99"));
            Name = (ITTTextBox)AddControl(new Guid("661c8f7c-cfc5-484d-8f8d-6fa9de9fb6e2"));
            StockCardStatus = (ITTEnumComboBox)AddControl(new Guid("e58950b5-98d0-4492-83fa-834a36540c9e"));
            SelectedStockCardClass = (ITTObjectListBox)AddControl(new Guid("bde6972a-42e2-4eac-9a42-8f1f4334bea1"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("65a81ef8-1c56-4980-bc6c-a59019125932"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("198f02d1-700b-4855-9001-01357800a3da"));
            SelectedStore = (ITTObjectListBox)AddControl(new Guid("0e6761f7-e6c5-4aee-a0f3-e77994487942"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("37641b6e-0e9b-4b25-88cb-cd3fb424cb1d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("36e1d27c-9585-4d88-98e2-2239c12894f0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("43832a2b-4876-4a1e-9ca0-a19e235c1cdf"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("84822e0e-7be6-4863-891f-9e4b7fb1b9a4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("bbdb2010-5f36-4e95-b8d3-affcaab7659a"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("77b893b1-27d8-4ca8-ad7b-1f5448be7589"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("c3d27ce7-720e-42d9-bc4f-22b3b41a27eb"));
            StockLevel = (ITTEnumComboBox)AddControl(new Guid("9cc025fd-caae-4667-929d-dc4b3590bfb5"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("bc934c23-5573-44e0-a0c6-dd8c1c84bb4d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("def880a9-fad2-4d3b-a0ca-9984bd41fdde"));
            labelStockCardCount = (ITTLabel)AddControl(new Guid("a6a7fef6-1f6e-4272-92f1-b2ecd69abfb2"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cbf27a82-a900-4d62-97ae-eb2933834c8e"));
            PricingDetailDefinitionList = (ITTObjectListBox)AddControl(new Guid("1550ac98-c8be-4e38-a3b5-e13fef1c1ab1"));
            base.InitializeControls();
        }

        public SearchStockCardForm(TTList ttList) : base(ttList, "STOCK", "SearchStockCardForm")
        {
        }
    }
}