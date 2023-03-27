
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
    public partial class TenderCommisionForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid PurchaseProjectDetailItems;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTEnumComboBoxColumn TenderCommisionStatus;
        protected ITTCheckBoxColumn Purchased;
        protected ITTButtonColumn Details;
        protected ITTGroupBox ttgroupbox3;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox PurchaseType;
        protected ITTLabel labelConfirmNO;
        protected ITTEnumComboBox PurchaseMainType;
        protected ITTTextBox ConfirmNO;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("7ba4c3ed-fc09-400c-9840-295fd07f505b"));
            PurchaseProjectDetailItems = (ITTGrid)AddControl(new Guid("2a59449b-db4d-4d82-8922-49f603d324bc"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("795f1764-8793-46b2-9106-8b40ca0eeaac"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("f744ab36-5204-4ce4-8b5f-bd81b1f6b46d"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("ab7eda83-59d8-4429-9197-db6c8766d4e7"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("b787e84a-dc0b-4016-b2fd-b09b2b7b525a"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("2e6a391f-0616-49ba-b070-b4f1947f5c99"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3cf7ed30-a348-4687-8078-ba8766b2226a"));
            TenderCommisionStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("5d4be1e0-8d00-4d09-8ea8-1c0abe767dac"));
            Purchased = (ITTCheckBoxColumn)AddControl(new Guid("a98042be-301f-4099-b7df-0f91a1074ada"));
            Details = (ITTButtonColumn)AddControl(new Guid("ebfc0aaa-34f0-4cec-8634-f4a942e8f4a1"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("1a2ed880-9edc-4abf-9a1e-1cc48a6c8d55"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("e5d328a1-0711-497a-b122-e91050f816c7"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("3dc3ef6b-e533-4ce6-9cb6-983c6dfd0d09"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6c5276bb-8bbc-4e44-9b92-ff252cf23156"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c50de368-3859-4c05-83e4-e1066384d3a4"));
            PurchaseType = (ITTObjectListBox)AddControl(new Guid("2ef07c59-7f11-4afa-969b-541b7fcda3b5"));
            labelConfirmNO = (ITTLabel)AddControl(new Guid("6dca5426-20ee-44bc-bfbe-e22b2548ac2e"));
            PurchaseMainType = (ITTEnumComboBox)AddControl(new Guid("8ac22861-7f78-4456-b461-615e30fb20e0"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("4d14302d-5fae-48af-a20e-183cf6e25acf"));
            base.InitializeControls();
        }

        public TenderCommisionForm() : base("PURCHASEPROJECT", "TenderCommisionForm")
        {
        }

        protected TenderCommisionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}