
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
    public partial class BaseDeleteAnimalRecordForm : BaseDeleteRecordDocumentForm
    {
    /// <summary>
    /// Taşınır Mal Kayıt Silme Belgesi
    /// </summary>
        protected TTObjectClasses.DeleteAnimalRecordDocument _DeleteAnimalRecordDocument
        {
            get { return (TTObjectClasses.DeleteAnimalRecordDocument)_ttObject; }
        }

        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn StockLevelType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Kind;
        protected ITTTextBoxColumn Specie;
        protected ITTEnumComboBoxColumn Sex;
        protected ITTTextBoxColumn No;
        protected ITTDateTimePickerColumn BirthDate;
        protected ITTTextBoxColumn Duty;
        protected ITTTextBoxColumn View;
        protected ITTEnumComboBoxColumn DeleteRecordReason;
        protected ITTTextBoxColumn Opinions;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("f3864679-d247-47b2-a58b-2066e12f4470"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("4cce792b-1514-41a0-92d5-84a6bf5c3445"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("7a337da2-4ce4-4aaa-aadb-3fba3556121a"));
            Detail = (ITTButtonColumn)AddControl(new Guid("a10d957e-1d29-4e5f-b714-433c9e5f4395"));
            Material = (ITTListBoxColumn)AddControl(new Guid("7f2d014a-9d45-41bd-9d51-0d50ea1d5bd0"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("656c671c-0831-4422-9ef4-4d62c2d20ff5"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("18bfb442-664f-45d6-981d-ff7d44db5df1"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6b935382-af15-411c-ba57-3fa0e30f5d2c"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("fc2d3424-171d-46bb-8785-cc47efa09e31"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("7645c1af-8098-4902-b8ee-36da30f466c5"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("b466cfec-10a2-447a-a955-a2a7f32cead7"));
            Kind = (ITTTextBoxColumn)AddControl(new Guid("a136fd28-cf7b-4d93-a455-e2b12175bedd"));
            Specie = (ITTTextBoxColumn)AddControl(new Guid("d664ce3b-d8cb-4cb6-a71b-f42c3834a4e5"));
            Sex = (ITTEnumComboBoxColumn)AddControl(new Guid("e00cde93-c4a3-4dee-8c0a-dcfecbf86cf4"));
            No = (ITTTextBoxColumn)AddControl(new Guid("86817b08-691d-491d-92cf-b144b0b34904"));
            BirthDate = (ITTDateTimePickerColumn)AddControl(new Guid("45eaa80a-d3d6-4917-bee5-88ab13a3ae9f"));
            Duty = (ITTTextBoxColumn)AddControl(new Guid("a436cb1d-24c7-4004-9060-e9c12c96ea92"));
            View = (ITTTextBoxColumn)AddControl(new Guid("f3a9993f-84ac-4bf2-a18e-d885a0193b86"));
            DeleteRecordReason = (ITTEnumComboBoxColumn)AddControl(new Guid("0472f0cf-2efa-4df8-8924-3d45746ab0f0"));
            Opinions = (ITTTextBoxColumn)AddControl(new Guid("9c510816-f5a0-4f1a-a365-ef92994e2ecd"));
            base.InitializeControls();
        }

        public BaseDeleteAnimalRecordForm() : base("DELETEANIMALRECORDDOCUMENT", "BaseDeleteAnimalRecordForm")
        {
        }

        protected BaseDeleteAnimalRecordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}