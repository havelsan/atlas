
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
    /// İlk Giriş
    /// </summary>
    public partial class StockFirstInForm : StockActionBaseForm
    {
    /// <summary>
    /// İlk Giriş işlemi için kullanılan ana sınıftır
    /// </summary>
        protected TTObjectClasses.StockFirstIn _StockFirstIn
        {
            get { return (TTObjectClasses.StockFirstIn)_ttObject; }
        }

        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTGrid StockActionInDetails;
        protected ITTListBoxColumn Material;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn StockLevelType;
        protected ITTEnumComboBoxColumn Status;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            StockActionID = (ITTTextBox)AddControl(new Guid("018cdae1-53c2-4b17-8149-853b2fd63191"));
            Description = (ITTTextBox)AddControl(new Guid("138f06fb-7893-43e3-982f-42d2b98e4077"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("81155b8c-10b9-4240-b827-aa8556f5d603"));
            Material = (ITTListBoxColumn)AddControl(new Guid("66f36ecf-d624-47d3-afa0-c07e80c6922b"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("073848e0-e389-45ed-aa2c-f01b3a597691"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("f41545ab-bf87-4223-ad31-20e822f1eedd"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("94dcf7d3-b4fa-4d91-9228-fb8155a3bec5"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("bde44576-2d39-495b-9d73-babc76cd104d"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("892991fb-d3b5-47c9-ac9d-ab98093d5d8f"));
            labelStore = (ITTLabel)AddControl(new Guid("ab8cef65-9632-4d57-b3de-d05ef596bc59"));
            Store = (ITTObjectListBox)AddControl(new Guid("3c23796a-ba1b-46b6-9c27-2b4f508a03fc"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("f90d58cb-749b-4c56-bbe6-69b770a59514"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("b7c78142-6a23-454f-bde6-0a506f7bd9fa"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("9c6051f3-54c8-4ce3-ae0e-130682631d09"));
            labelDescription = (ITTLabel)AddControl(new Guid("cbaa39c8-34f2-4b02-ba78-4a4b822931be"));
            base.InitializeControls();
        }

        public StockFirstInForm() : base("STOCKFIRSTIN", "StockFirstInForm")
        {
        }

        protected StockFirstInForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}