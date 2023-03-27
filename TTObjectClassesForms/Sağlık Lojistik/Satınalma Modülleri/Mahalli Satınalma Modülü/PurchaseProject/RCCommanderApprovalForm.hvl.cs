
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
    public partial class RCCommanderApprovalForm : TTForm
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
        protected ITTLabel ttlabel2;
        protected ITTLabel labelDemandType;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTEnumComboBox DemandType;
        protected ITTEnumComboBox ProcurementType;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid PurchaseProjectDetailsGrid;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTRichTextBoxControlColumn Isayf;
        protected ITTButtonColumn Details;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("dab5092a-a7fa-4c74-a3b7-4512e83baf55"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("257bd9f1-34bf-4a51-ac8a-8a01ccf2b83b"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("1cc50bda-3cbc-4db3-b3c1-416b27b3eb5f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4e3423cb-3513-4754-87d0-93b5cf9df036"));
            labelDemandType = (ITTLabel)AddControl(new Guid("4bfd7292-805e-433d-b3fe-0c1555c20ffd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f5d3367c-215f-4bc0-9bca-9893aa92a988"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2f86e811-b707-42c2-b6ca-2bb859bd609d"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("0c2bde2e-f9d7-441b-92b9-adc16fad6ab6"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("fed10ad0-c112-46c5-a40a-98cf273cd486"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("52248d56-12a0-4e7b-8ff4-e6826516440b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("91046afd-1a1a-48bf-a03c-a5b2edfd8ad7"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("4ac55471-2c2f-4103-a7d6-af427346bfe1"));
            PurchaseProjectDetailsGrid = (ITTGrid)AddControl(new Guid("59889224-202d-4eeb-b65d-cfb3cf09bf26"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("2b11d718-fd90-4424-aa11-dd9d50aadd4b"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("ca74fc8e-48bb-45b4-bd32-0e65b4d8a253"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("1c045e08-e3df-40e6-82c8-69aa06fd86b5"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("62b31f87-016c-4639-9db2-e6e4ebef8978"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("66c24806-2b38-47c7-85e3-6a41da26b901"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("8ff45d89-8d57-4fc4-81aa-e0d590d7f311"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("4f56cd0a-f176-461d-bd40-b237a2c3b5b1"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("c5929bc5-2a1d-46d3-80ca-2e27d94d9aae"));
            Details = (ITTButtonColumn)AddControl(new Guid("fb1ef73b-0f5c-4d99-855e-42906e3f3627"));
            base.InitializeControls();
        }

        public RCCommanderApprovalForm() : base("PURCHASEPROJECT", "RCCommanderApprovalForm")
        {
        }

        protected RCCommanderApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}