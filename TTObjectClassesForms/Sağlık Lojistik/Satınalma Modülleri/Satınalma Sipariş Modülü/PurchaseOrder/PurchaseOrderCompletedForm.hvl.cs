
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
    /// Tamamlanmış Sipariş
    /// </summary>
    public partial class PurchaseOrderCompletedForm : TTForm
    {
    /// <summary>
    /// Firmaya verilen sipariş bilgilerinin tutuldufu sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseOrder _PurchaseOrder
        {
            get { return (TTObjectClasses.PurchaseOrder)_ttObject; }
        }

        protected ITTTextBox txtProjectNO;
        protected ITTTextBox txtTotalOrderPrice;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel3;
        protected ITTGrid PurchaseOrderDetailsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn PurchaseProjectAmount;
        protected ITTTextBoxColumn RestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn OrderPrice;
        protected ITTDateTimePickerColumn DeliveryDate;
        protected ITTEnumComboBoxColumn NotificationType;
        protected ITTTextBoxColumn AuthorizedFirmStaff;
        protected ITTTextBoxColumn Description;
        protected ITTButtonColumn OldOrders;
        protected ITTListBoxColumn StockCard;
        protected ITTObjectListBox txtSupplier;
        protected ITTTextBox txtRemainingOrderPrice;
        protected ITTDateTimePicker OrderDate;
        protected ITTDateTimePicker DueDate;
        protected ITTLabel labelOrderDate;
        protected ITTLabel labelDueDate;
        protected ITTTextBox OrderNO;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTTextBox txtOrderedPrice;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            txtProjectNO = (ITTTextBox)AddControl(new Guid("981859ab-e3d9-4e05-b3ba-f392f4e22b71"));
            txtTotalOrderPrice = (ITTTextBox)AddControl(new Guid("2c3429b5-75e4-4c50-8c17-54ce0aed6184"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("f0516d43-d85f-4de7-b0c8-c84fd5ba55c9"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a681fdb3-219d-4512-a230-290826fe1559"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("dd6dd2eb-7632-4a08-9d86-6d81e3e3f58e"));
            PurchaseOrderDetailsGrid = (ITTGrid)AddControl(new Guid("a9036b9a-da7b-45e4-b03f-55dbb88f9981"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("ba6eb477-1411-4ff9-ba58-7e87166fcb1b"));
            PurchaseProjectAmount = (ITTTextBoxColumn)AddControl(new Guid("54de51b6-5c29-4b61-b521-65e80063bc6f"));
            RestAmount = (ITTTextBoxColumn)AddControl(new Guid("e5a26d77-7cfb-48b5-af8e-ffcd45550a29"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("18779699-f61b-4024-87cf-b9d5aed7a004"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("b5e51367-8186-40b3-b4d7-b2b780b2f39b"));
            OrderPrice = (ITTTextBoxColumn)AddControl(new Guid("7b9bb415-2f5a-49ea-8905-dbce77ebd633"));
            DeliveryDate = (ITTDateTimePickerColumn)AddControl(new Guid("f82219be-54cc-4f30-9933-617c265257c9"));
            NotificationType = (ITTEnumComboBoxColumn)AddControl(new Guid("d9cb608b-4727-40cd-9a56-1119bfec24bc"));
            AuthorizedFirmStaff = (ITTTextBoxColumn)AddControl(new Guid("e387285d-19d7-435f-ae91-a9789c8971ca"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("f22815ea-bd79-41a4-86f5-53290c7203cf"));
            OldOrders = (ITTButtonColumn)AddControl(new Guid("0dea55ea-998f-4d87-88a8-ab15362af8a8"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("64b532db-9be2-4e92-9ce0-1e583ad5d0f8"));
            txtSupplier = (ITTObjectListBox)AddControl(new Guid("8537c5ca-1003-46c6-b406-a139d57c9098"));
            txtRemainingOrderPrice = (ITTTextBox)AddControl(new Guid("bf7f1bc6-a8d2-4246-ad76-ddadddd42e9b"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("ca58648c-3864-435f-a577-d99526ca4913"));
            DueDate = (ITTDateTimePicker)AddControl(new Guid("2cb63ed9-ac85-4fd8-a10f-44dfb197294c"));
            labelOrderDate = (ITTLabel)AddControl(new Guid("b9d3b7ee-6cbf-40c5-85cf-7a24d39d8d48"));
            labelDueDate = (ITTLabel)AddControl(new Guid("f550e77c-0395-40f6-be5f-d6d316acaf14"));
            OrderNO = (ITTTextBox)AddControl(new Guid("80e657ae-aaab-4a4b-88a0-553398f70c76"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8560dcc1-2d47-4203-91ae-81492e9c004c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("703e9685-83c1-435f-b3c7-d9374dcc0e5a"));
            txtOrderedPrice = (ITTTextBox)AddControl(new Guid("3f8117f4-ed37-4af4-b686-8cbf99051894"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("215e7902-29d2-4934-94c7-30eebf9f4108"));
            base.InitializeControls();
        }

        public PurchaseOrderCompletedForm() : base("PURCHASEORDER", "PurchaseOrderCompletedForm")
        {
        }

        protected PurchaseOrderCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}