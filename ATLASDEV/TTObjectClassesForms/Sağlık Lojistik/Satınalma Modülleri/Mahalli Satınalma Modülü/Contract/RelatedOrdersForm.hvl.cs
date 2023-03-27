
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
    /// Eski Siparişler
    /// </summary>
    public partial class RelatedOrdersForm : TTForm
    {
    /// <summary>
    /// İhalede Sözleşme Yapılan Her Firma İçin Sözleşme Bilgilerinin Tutulduğu Sınıftır.
    /// </summary>
        protected TTObjectClasses.Contract _Contract
        {
            get { return (TTObjectClasses.Contract)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox4;
        protected ITTGrid PurchaseOrderDetailsGrid;
        protected ITTListBoxColumn PurchaseItemDef;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTObjectListBox Supplier;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid PurchaseOrdersGrid;
        protected ITTTextBoxColumn OrderNO;
        protected ITTDateTimePickerColumn OrderDate;
        protected ITTDateTimePickerColumn DueDate;
        protected ITTTextBoxColumn State;
        protected ITTLabel labelSupplier;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ContractDetailsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn Description;
        override protected void InitializeControls()
        {
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("5c8458ae-da85-4a79-80c8-4e079d293120"));
            PurchaseOrderDetailsGrid = (ITTGrid)AddControl(new Guid("0e4d9e43-0493-4a91-a199-b22517181dea"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("f57b5f1f-0a9e-4794-aed6-674a9ef9a83a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("04b7c8e9-68d6-487b-aa85-cbd7f639400d"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("aee0e988-76c6-4fc5-ad8c-75bb7c7a3180"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("89305fdb-fa29-4708-81a5-502bfdbf5edb"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("a770e431-e53c-4366-84d6-5669b73d100d"));
            PurchaseOrdersGrid = (ITTGrid)AddControl(new Guid("9091c4f8-2509-4afb-9d1d-e5f975272e59"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("ff020195-0fb2-42e1-a73a-64608ef62a79"));
            OrderDate = (ITTDateTimePickerColumn)AddControl(new Guid("c0915709-c934-4e87-b729-a4d688af79a0"));
            DueDate = (ITTDateTimePickerColumn)AddControl(new Guid("219f7f43-3890-43cd-bc65-a0c18d57b809"));
            State = (ITTTextBoxColumn)AddControl(new Guid("4870207b-be05-4bb2-8622-94b45af53494"));
            labelSupplier = (ITTLabel)AddControl(new Guid("57144c96-a8d9-4ee8-ac98-99055c5aff62"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e0bcb4e4-54e0-404f-b5fa-f3a3aa3a55bc"));
            ContractDetailsGrid = (ITTGrid)AddControl(new Guid("6269f0db-f049-4573-9ed0-df422fd261b2"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("03204795-24df-4059-8006-882ead4f735f"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("d5f00cc5-e99d-4ab7-a5a3-fedc6bc4c1c4"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("e467503a-8e2a-4732-87cc-dc4403ee611d"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("35b1242c-ba03-41e7-9c94-e4298b1ac3d0"));
            base.InitializeControls();
        }

        public RelatedOrdersForm() : base("CONTRACT", "RelatedOrdersForm")
        {
        }

        protected RelatedOrdersForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}