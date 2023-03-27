
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
    /// Teslimat Prodesürleri
    /// </summary>
    public partial class PurchaseOrderProceduresForm : TTForm
    {
    /// <summary>
    /// Firmaya verilen sipariş bilgilerinin tutuldufu sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseOrder _PurchaseOrder
        {
            get { return (TTObjectClasses.PurchaseOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid PurchaseOrderDetailsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn PurchaseProjectAmount;
        protected ITTListBoxColumn StockCard;
        protected ITTTextBoxColumn RestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn OrderPrice;
        protected ITTEnumComboBoxColumn Status;
        protected ITTDateTimePickerColumn DeliveryDate;
        protected ITTEnumComboBoxColumn NotificationType;
        protected ITTTextBoxColumn AuthorizedFirmStaff;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage tttabpage2;
        protected ITTGrid DocumentsGrid;
        protected ITTTextBoxColumn Subject;
        protected ITTTextBoxColumn DocumentDate;
        protected ITTButtonColumn Show;
        protected ITTButtonColumn Print;
        protected ITTButtonColumn Delete;
        protected ITTTabPage tttabpage3;
        protected ITTGrid InternalDocsGrid;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTButtonColumn Show2;
        protected ITTButtonColumn Print2;
        protected ITTButtonColumn Delete2;
        protected ITTTextBox txtProjectNO;
        protected ITTTextBox txtTotalOrderPrice;
        protected ITTTextBox txtRemainingOrderPrice;
        protected ITTTextBox OrderNO;
        protected ITTTextBox txtOrderedPrice;
        protected ITTButton cmdPrintReport;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox txtSupplier;
        protected ITTDateTimePicker OrderDate;
        protected ITTDateTimePicker DueDate;
        protected ITTLabel labelOrderDate;
        protected ITTLabel labelDueDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("0c6b00d3-a1b9-4e0b-8853-3b665e0b4c34"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("9cbd5da2-0889-4064-bc26-de9f6a3d8443"));
            PurchaseOrderDetailsGrid = (ITTGrid)AddControl(new Guid("92573917-1003-43bc-8ab2-f788dcfaabd4"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("61816e04-ac16-43b8-9765-b1f58cc7e895"));
            PurchaseProjectAmount = (ITTTextBoxColumn)AddControl(new Guid("3ada88da-ff78-40e3-9256-46349d4bd6f9"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("e646a4d3-771c-4829-90a0-a1521f4f5e05"));
            RestAmount = (ITTTextBoxColumn)AddControl(new Guid("14b631cd-bd7f-45db-bec7-e4e596da1f55"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("08d03b00-9ae9-4f08-8029-cb6bd29b2b2e"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("cad27f80-c00e-4dc7-ade9-e0b0cfe0293f"));
            OrderPrice = (ITTTextBoxColumn)AddControl(new Guid("4202d95b-711a-4f9f-bac7-b4265db3fc5e"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("acb5028a-6800-4731-afe2-efce57ac495d"));
            DeliveryDate = (ITTDateTimePickerColumn)AddControl(new Guid("e08f1ed2-7116-40a4-8242-0e406b05afff"));
            NotificationType = (ITTEnumComboBoxColumn)AddControl(new Guid("85c40a3b-e78c-4691-91aa-7a8790380005"));
            AuthorizedFirmStaff = (ITTTextBoxColumn)AddControl(new Guid("70d2f3be-0224-46bf-acc2-6312080050e8"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("6d0a3578-0b72-4845-9944-548d853503d2"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("d12b42c6-1247-4e36-896d-7b28b3b21124"));
            DocumentsGrid = (ITTGrid)AddControl(new Guid("ad460d78-ff83-40cd-8b0c-44a585ad3477"));
            Subject = (ITTTextBoxColumn)AddControl(new Guid("dbaedd16-3170-4c3e-8b88-88a057652308"));
            DocumentDate = (ITTTextBoxColumn)AddControl(new Guid("e114e1ff-cf0d-4aed-b64b-46ccf344f620"));
            Show = (ITTButtonColumn)AddControl(new Guid("c4a1620a-3591-4dec-b046-4cc238bf0823"));
            Print = (ITTButtonColumn)AddControl(new Guid("065a493c-5266-4c5a-95eb-78407ebf2a5a"));
            Delete = (ITTButtonColumn)AddControl(new Guid("48543db8-7f9f-48c9-b80d-658beb5321ee"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("1cd7d074-b618-4367-9578-f9ae1ca60ba3"));
            InternalDocsGrid = (ITTGrid)AddControl(new Guid("112f6192-0b20-4895-8f93-0551c36a54a1"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("6907b2f8-7917-4601-8532-6d9a6c3dbcbe"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("580ae648-3875-47ed-90fd-ca5741f4aa03"));
            Show2 = (ITTButtonColumn)AddControl(new Guid("81db1340-77eb-480e-a65a-22393825d3c7"));
            Print2 = (ITTButtonColumn)AddControl(new Guid("1c462aab-819f-4786-a776-4724cb02cc05"));
            Delete2 = (ITTButtonColumn)AddControl(new Guid("f7916e63-5b89-4f13-ba53-253482f2b766"));
            txtProjectNO = (ITTTextBox)AddControl(new Guid("06f01b67-2cfa-4bb1-9deb-eb33be3ebb8b"));
            txtTotalOrderPrice = (ITTTextBox)AddControl(new Guid("1e8428c3-152c-437d-8010-9de434eedf6c"));
            txtRemainingOrderPrice = (ITTTextBox)AddControl(new Guid("6d58958c-98bd-4040-8625-247c64689771"));
            OrderNO = (ITTTextBox)AddControl(new Guid("16091588-5fa8-46d4-8439-1695e9fc9d30"));
            txtOrderedPrice = (ITTTextBox)AddControl(new Guid("528f4de6-28fc-4409-9e6f-0faaea0043be"));
            cmdPrintReport = (ITTButton)AddControl(new Guid("18b14959-3eab-42fa-9928-ad7be68740c5"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("de43334d-613f-40b3-a6d4-dca5a074c297"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a4fd132a-567e-41de-bac5-2bad046f1ed9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("64c532ca-fc10-41b4-a6f5-bd72c740b3e2"));
            txtSupplier = (ITTObjectListBox)AddControl(new Guid("ee4130e4-0438-486e-a4ef-aa0fc5d64385"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("51047256-d5f2-4eba-9dc0-a78b1c30f282"));
            DueDate = (ITTDateTimePicker)AddControl(new Guid("591e247c-cecf-4f26-8b9d-5a3dfb345e04"));
            labelOrderDate = (ITTLabel)AddControl(new Guid("5e39e67e-2e39-4980-86dc-0cbe0bc1cb7e"));
            labelDueDate = (ITTLabel)AddControl(new Guid("794477a9-d8b2-4cad-9780-96cb4e0c1695"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ce1030fe-3f49-49c0-9c20-021ab9bbab01"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c9faa061-b1a5-4679-9abd-06328b466391"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c7cd2bd4-01c7-4a5b-a3a0-10a3aad20cf2"));
            base.InitializeControls();
        }

        public PurchaseOrderProceduresForm() : base("PURCHASEORDER", "PurchaseOrderProceduresForm")
        {
        }

        protected PurchaseOrderProceduresForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}