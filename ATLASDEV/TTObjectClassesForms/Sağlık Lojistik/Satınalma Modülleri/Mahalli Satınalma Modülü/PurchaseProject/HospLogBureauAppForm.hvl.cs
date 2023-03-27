
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
    public partial class HospLogBureauAppForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTEnumComboBox PurchaseMainType;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelDemandType;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTEnumComboBox DemandType;
        protected ITTEnumComboBox ProcurementType;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ItemDetailsGrid;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTRichTextBoxControlColumn Isayf;
        protected ITTButtonColumn Details;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("293a9999-b73a-4dff-8ff7-bfcfb20670af"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("aa0b186c-b03a-462b-85b6-99adecde8e6c"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("6368abc0-6dcf-40cb-a677-c354adea6ccc"));
            PurchaseMainType = (ITTEnumComboBox)AddControl(new Guid("230882ed-d88b-4aea-a276-dbf8929ac010"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a09bc23c-60d9-4e22-af0c-1a32fc593d80"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("210799b2-6871-46f0-a435-6eb6219621b2"));
            labelDemandType = (ITTLabel)AddControl(new Guid("a38e2a84-3968-468c-b9bc-bb5c86142cd0"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8f04cd47-3f62-49e2-9455-fed3a9b333c9"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8afcd4be-e19f-4c44-81b7-52d914b91fc8"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("4522c288-1780-4470-b416-6a951ffce4dd"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("6bf7fecb-47c5-4a05-967e-6d649ae30605"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("ca5024f2-4116-4d27-83d8-5b1b5bc2bbcb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("23643a10-dcb0-45b1-aa32-509457d63537"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c9006b01-0bcf-4cc9-99f3-f0dcb86e1add"));
            ItemDetailsGrid = (ITTGrid)AddControl(new Guid("2086bfa4-0e35-4420-80c6-0b6a41d33cca"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("27c53cb7-e701-4e68-9649-610882a505ee"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("0323579a-cc9e-415d-9d6a-c0b0ff498b19"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("6b376e37-02a0-4149-b7aa-e8b99cd39fc5"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("54bbbc17-2c97-4edb-bafa-1a61552841eb"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("a70d7446-db00-4010-82f7-b077ebc61540"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("bd9a372c-44a1-4222-9c43-b35ae0fbaa2a"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("0d130b14-a7ec-4b35-ae56-31800679b890"));
            Details = (ITTButtonColumn)AddControl(new Guid("5629c339-3650-45ff-b537-b1ce6f560e4e"));
            base.InitializeControls();
        }

        public HospLogBureauAppForm() : base("PURCHASEPROJECT", "HospLogBureauAppForm")
        {
        }

        protected HospLogBureauAppForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}