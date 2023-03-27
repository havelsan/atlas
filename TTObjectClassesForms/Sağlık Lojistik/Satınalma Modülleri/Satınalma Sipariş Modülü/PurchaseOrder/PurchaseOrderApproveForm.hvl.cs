
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
    /// Sipariş Onay
    /// </summary>
    public partial class PurchaseOrderApproveForm : TTForm
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
        protected ITTListBoxColumn StockCard;
        protected ITTTextBoxColumn RestAmount;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn OrderPrice;
        protected ITTDateTimePickerColumn DeliveryDate;
        protected ITTEnumComboBoxColumn NotificationType;
        protected ITTTextBoxColumn AuthorizedFirmStaff;
        protected ITTTextBoxColumn Description;
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
            txtProjectNO = (ITTTextBox)AddControl(new Guid("b9d4ea82-f3e7-40d7-a529-1a642de0e252"));
            txtTotalOrderPrice = (ITTTextBox)AddControl(new Guid("27ec9163-4479-4b91-a5dc-313d79fcefba"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("8a81bb4b-4a6e-4cf1-94db-362270bdade3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5ee41156-3f9f-47ae-87e7-3d09cd8a6a51"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("97fe4b85-691e-46ae-a36d-635b2c8f9054"));
            PurchaseOrderDetailsGrid = (ITTGrid)AddControl(new Guid("b2fec7c1-1b25-4a44-ab26-79f6dfbc4ba5"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("02256242-75ee-4cd4-b139-fec5f8593efd"));
            PurchaseProjectAmount = (ITTTextBoxColumn)AddControl(new Guid("5bda0f7a-5d97-4e07-a8de-78b8253ba55b"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("8a6fd5c8-1952-4192-9f7b-37c05c607b42"));
            RestAmount = (ITTTextBoxColumn)AddControl(new Guid("d93bf571-0f13-4356-9e94-bb22f5999aac"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("bb8fe041-c97e-4645-bb9a-601d31c30c22"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("8b0f4cc2-1e2c-4641-8670-b85e2d133f4f"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("be1bb161-413d-4ad0-9aec-a8bac0aab9ea"));
            OrderPrice = (ITTTextBoxColumn)AddControl(new Guid("9961df65-3b4e-4b8c-89cf-82b75c937047"));
            DeliveryDate = (ITTDateTimePickerColumn)AddControl(new Guid("ee1bfffe-0713-4b2c-8a94-7cb714686dcf"));
            NotificationType = (ITTEnumComboBoxColumn)AddControl(new Guid("3bd66c7e-295f-41de-be84-1f9274c10670"));
            AuthorizedFirmStaff = (ITTTextBoxColumn)AddControl(new Guid("af7ff502-eb3c-4e57-bebc-9b2fdccae454"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("af3a377e-3420-46dc-84eb-cfcff48d124f"));
            txtSupplier = (ITTObjectListBox)AddControl(new Guid("328ea0e5-cdfa-44c0-814a-8d9e251d4bf7"));
            txtRemainingOrderPrice = (ITTTextBox)AddControl(new Guid("5d5761f0-43ac-4d8d-9dc7-9451070bec3e"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("a90290a3-6f9a-434d-8704-9a685fa6d6ee"));
            DueDate = (ITTDateTimePicker)AddControl(new Guid("cadf59ec-da71-4e8b-b36e-9c16ddc049fe"));
            labelOrderDate = (ITTLabel)AddControl(new Guid("f008833a-b46a-4712-845f-9e801d7ccf1c"));
            labelDueDate = (ITTLabel)AddControl(new Guid("49612f58-6f6b-4d9c-9120-b6cf2785f6d3"));
            OrderNO = (ITTTextBox)AddControl(new Guid("db350c16-649f-497a-aa67-bdff4b64d17f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("87261e1a-d3cf-43bb-94f0-ca8c9a220186"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("94ba092b-6c96-45e9-b0bb-eccb7a6849b8"));
            txtOrderedPrice = (ITTTextBox)AddControl(new Guid("72c8f3f7-ccc2-4922-a1bd-f0be2f7ba490"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("286cdeaf-0906-42e1-ae0f-f1be04d6d5dc"));
            base.InitializeControls();
        }

        public PurchaseOrderApproveForm() : base("PURCHASEORDER", "PurchaseOrderApproveForm")
        {
        }

        protected PurchaseOrderApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}