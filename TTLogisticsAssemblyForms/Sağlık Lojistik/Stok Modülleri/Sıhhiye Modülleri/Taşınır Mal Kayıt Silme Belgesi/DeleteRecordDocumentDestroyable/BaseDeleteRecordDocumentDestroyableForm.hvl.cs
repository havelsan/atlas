
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
    /// Kayıt Silme Belgesi - Yok Edilen
    /// </summary>
    public partial class BaseDeleteRecordDocumentDestroyableForm : BaseDeleteRecordDocumentForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi - Yok Edilen için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DeleteRecordDocumentDestroyable _DeleteRecordDocumentDestroyable
        {
            get { return (TTObjectClasses.DeleteRecordDocumentDestroyable)_ttObject; }
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
        protected ITTTextBoxColumn DestroyLocation;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("205f0aeb-c9b7-43fc-a8f8-3e4f73f7c182"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("dca5643d-66d2-45cf-9a8f-2886bc4c8b0c"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("acbef13d-ef7c-4b30-b9be-d44e253cad00"));
            Detail = (ITTButtonColumn)AddControl(new Guid("f7d231b6-fe74-4b56-8455-c39e87f51d73"));
            Material = (ITTListBoxColumn)AddControl(new Guid("2be27f10-ff79-41f4-9019-7300cb69c1bb"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("11034147-6820-44d3-9806-466ff64bbaa7"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("726f7a6e-26fa-4b94-895d-ebd84408f076"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("d36c681d-4874-4b88-ba83-2af09a3675b6"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("33ddd2d0-4e7c-4d1b-9be2-4a91e22abf09"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("fc30e80b-6f92-40e8-9adc-08ad3d9399a3"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("b51195cf-76b0-42e0-9a54-644a8b8e7d33"));
            Startdate = (ITTDateTimePickerColumn)AddControl(new Guid("cf499104-972e-4e87-8084-5d12f0aa1ce2"));
            ttenumcomboboxcolumn1 = (ITTEnumComboBoxColumn)AddControl(new Guid("421f1bca-116d-491f-ab36-f31ed4752207"));
            DeleteRecordReason = (ITTEnumComboBoxColumn)AddControl(new Guid("2f2af882-f6b2-4164-9f30-8b5ac36bf047"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("95952627-eae4-4db6-b24e-cf749ec3fda4"));
            Opinions = (ITTTextBoxColumn)AddControl(new Guid("e8a00bbb-889a-4629-9a5e-9809bdc08c67"));
            DestroyLocation = (ITTTextBoxColumn)AddControl(new Guid("076474cf-025f-4513-8a69-effae45a7acc"));
            base.InitializeControls();
        }

        public BaseDeleteRecordDocumentDestroyableForm() : base("DELETERECORDDOCUMENTDESTROYABLE", "BaseDeleteRecordDocumentDestroyableForm")
        {
        }

        protected BaseDeleteRecordDocumentDestroyableForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}