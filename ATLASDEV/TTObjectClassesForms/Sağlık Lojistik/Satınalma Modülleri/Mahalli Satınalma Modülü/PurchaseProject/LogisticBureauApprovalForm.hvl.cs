
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
    public partial class LogisticBureauApprovalForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
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
        protected ITTTabPage tttabpage2;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn datagridviewcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTGrid TransferItemsGrid;
        protected ITTListBoxColumn datagridviewcolumn1;
        protected ITTButtonColumn cmdDetail;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdPrintTransferOrders;
        protected ITTButton cmdPrepareTransferOrder;
        protected ITTButton cmdApproveAll;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox ConfirmNO;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelConfirmDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelConfirmNO;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTEnumComboBox ProcurementType;
        protected ITTDateTimePicker ConfirmDate;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox PurchaseProjectNO;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("63d93977-1005-421f-bbf1-3b88bb1b408e"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("e39f66e6-584c-4046-ad9d-e993fdbf6f70"));
            PurchaseProjectDetailsGrid = (ITTGrid)AddControl(new Guid("495bee27-e8c5-4695-b8d1-0f3b6f1aa938"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("64cad794-e1f7-4216-8b94-c77dd2da49d1"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("92f90f2f-c317-45e6-9a29-ae9bafd1d5a0"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("dcc16eb6-0a5d-412b-b474-32aa09b530e4"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("84e06746-3dc5-400d-96d6-13cc4379eebe"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("4787c358-7dd7-4999-b719-2d07498dd59c"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("a8e7f481-dcc9-4dd5-b088-a60da885e291"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("7b177b89-8e66-4382-9e9a-f4e346226bb7"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("a094ce07-fed7-48d4-bb00-7c983c970fd9"));
            Details = (ITTButtonColumn)AddControl(new Guid("af6aac7e-ebd6-4f34-8157-78b6d851263c"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("bb2926a4-32f6-49d6-a087-4ce6b5908ea5"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("4f1cdf9e-4d36-47ef-9a05-485f85198c55"));
            datagridviewcolumn2 = (ITTListBoxColumn)AddControl(new Guid("8d42bbb7-0569-4924-b20a-238cc1f0624a"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("251ce5c6-a56e-4260-97b4-6c1a1f67ce14"));
            TransferItemsGrid = (ITTGrid)AddControl(new Guid("531c74e4-6c80-46be-99f7-67b7d004920c"));
            datagridviewcolumn1 = (ITTListBoxColumn)AddControl(new Guid("10ffb3df-e96c-416c-af27-356ea6dfc6cd"));
            cmdDetail = (ITTButtonColumn)AddControl(new Guid("c39b66ff-b409-46fc-ae43-0d1e1cd94476"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("6e48e896-d00e-49a4-9f72-de4a26d2672c"));
            cmdPrintTransferOrders = (ITTButton)AddControl(new Guid("28319383-ac82-43c6-8282-3d20ef6c19ef"));
            cmdPrepareTransferOrder = (ITTButton)AddControl(new Guid("c5517eae-a7b0-4150-9d68-284bc1e9e468"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("bb6dea33-6160-4f54-b342-4663211c9d85"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("96bb3bbd-0366-4b6c-8ca5-e0318c6274ef"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("13b1a9b8-1c3b-458d-a6c8-ec15336fca86"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("00bffe7b-46e2-48e6-a2f0-aae04930f4eb"));
            labelConfirmDate = (ITTLabel)AddControl(new Guid("d634212e-bdb0-4107-a590-0db6591bfcc7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cd8b1921-635a-46e6-b16b-4e857803993b"));
            labelConfirmNO = (ITTLabel)AddControl(new Guid("64c363d1-7e8c-42ba-9de4-1bf3d8718974"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("60e05a19-9f59-4e85-9874-264b7586af80"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("563cc2a9-0c5b-4fe0-bd46-3e42f5c48504"));
            ConfirmDate = (ITTDateTimePicker)AddControl(new Guid("2825fc5f-d76f-470d-a2c7-611ca176e0a2"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("b1e37931-9802-47e4-9e6d-6df3eec28b82"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ea990bcc-496c-43a7-9f30-8a2a3ebc09ec"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1f122e38-c898-4134-9ea1-96cd47eb8687"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e705206b-d41d-4ccf-8e7d-a2daa9d1a7de"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("5daec080-b0af-4096-bec2-ca8cdeb99dce"));
            base.InitializeControls();
        }

        public LogisticBureauApprovalForm() : base("PURCHASEPROJECT", "LogisticBureauApprovalForm")
        {
        }

        protected LogisticBureauApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}