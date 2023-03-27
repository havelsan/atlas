
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
    /// Kayıt Silme Belgesi - Hek Edilen
    /// </summary>
    public partial class BaseDeleteRecordDocumentWasteForm : BaseDeleteRecordDocumentForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi - Hek Edilen için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DeleteRecordDocumentWaste _DeleteRecordDocumentWaste
        {
            get { return (TTObjectClasses.DeleteRecordDocumentWaste)_ttObject; }
        }

        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Price;
        protected ITTDateTimePickerColumn Startdate;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn1;
        protected ITTEnumComboBoxColumn DeleteRecordReason;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTextBoxColumn Opinions;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("115d91ed-20e0-4e5a-9300-c2f8756c618b"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("a9a351ae-a032-4634-8268-bad51ed56bc0"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("d3751704-6813-4eab-97bb-61f0b1533836"));
            Detail = (ITTButtonColumn)AddControl(new Guid("3b18baef-bf79-4593-8721-bc51c20030fb"));
            Material = (ITTListBoxColumn)AddControl(new Guid("2c2b8fc6-5084-44e1-8fad-219d39951a73"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("3a077fbe-5d0f-48e8-99f8-d392c643b131"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("05488839-5c9c-4c6d-bc3d-0dad9e2e07d5"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("69016cf9-25e3-46e4-abf3-4a8c19db98a9"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b882ca77-d274-4830-ac41-e94d96e62d33"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("3faa8807-b322-4b50-9226-4758eff8d89f"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("6f9c294e-99bd-498d-b3de-115208ecb37e"));
            Startdate = (ITTDateTimePickerColumn)AddControl(new Guid("f12a272f-e4d5-4a2a-9295-12699167acf1"));
            ttenumcomboboxcolumn1 = (ITTEnumComboBoxColumn)AddControl(new Guid("fe3176e4-8cfd-4a25-8ec8-d0ff1c3ce41d"));
            DeleteRecordReason = (ITTEnumComboBoxColumn)AddControl(new Guid("a6ca3457-5152-4f1d-9aa2-8be32ee50322"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("800ed398-e332-41a3-927d-a567684a3c4b"));
            Opinions = (ITTTextBoxColumn)AddControl(new Guid("3e922d8f-2cd4-4351-876f-d851eb6acfd6"));
            base.InitializeControls();
        }

        public BaseDeleteRecordDocumentWasteForm() : base("DELETERECORDDOCUMENTWASTE", "BaseDeleteRecordDocumentWasteForm")
        {
        }

        protected BaseDeleteRecordDocumentWasteForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}