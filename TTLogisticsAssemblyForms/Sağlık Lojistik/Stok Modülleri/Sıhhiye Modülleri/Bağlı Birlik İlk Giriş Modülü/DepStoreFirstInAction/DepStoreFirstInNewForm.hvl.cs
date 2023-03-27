
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
    /// Bağlı Birlik İlk Giriş
    /// </summary>
    public partial class DepStoreFirstInNewForm : TTForm
    {
    /// <summary>
    /// Bağlı Birlik İlk Giriş İşlemi
    /// </summary>
        protected TTObjectClasses.DepStoreFirstInAction _DepStoreFirstInAction
        {
            get { return (TTObjectClasses.DepStoreFirstInAction)_ttObject; }
        }

        protected ITTButton cmdGetDepStock;
        protected ITTGrid DepStoreFirstInActionDetails;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn MaterialDepStoreFirstInActionDet;
        protected ITTDateTimePickerColumn ExpirationDateDepStoreFirstInActionDet;
        protected ITTTextBoxColumn UnitPriceDepStoreFirstInActionDet;
        protected ITTTextBoxColumn AmountDepStoreFirstInActionDet;
        protected ITTListBoxColumn StockLevelTypeDepStoreFirstInActionDet;
        protected ITTLabel labelDependentStore;
        protected ITTObjectListBox DependentStore;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            cmdGetDepStock = (ITTButton)AddControl(new Guid("c1302d80-e782-4811-a1c1-40f13f337d7d"));
            DepStoreFirstInActionDetails = (ITTGrid)AddControl(new Guid("e55d89a0-74d5-43cd-9250-8981786e0014"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("7b82cf30-1da4-4443-840b-6c6084c55f22"));
            MaterialDepStoreFirstInActionDet = (ITTListBoxColumn)AddControl(new Guid("2c11c101-09cf-4253-b092-80a28f1406ad"));
            ExpirationDateDepStoreFirstInActionDet = (ITTDateTimePickerColumn)AddControl(new Guid("aef70fcb-9440-45c9-8b15-59f62ba227db"));
            UnitPriceDepStoreFirstInActionDet = (ITTTextBoxColumn)AddControl(new Guid("98ef62d5-dbcc-43bd-8d25-0d61e44364ad"));
            AmountDepStoreFirstInActionDet = (ITTTextBoxColumn)AddControl(new Guid("08bedd9d-55ed-46f9-8fbc-6301fb764b34"));
            StockLevelTypeDepStoreFirstInActionDet = (ITTListBoxColumn)AddControl(new Guid("e0bc56da-59db-4882-a9ef-a0c41ba1e915"));
            labelDependentStore = (ITTLabel)AddControl(new Guid("c92245b7-fdd7-4c89-89dc-75bc369caea4"));
            DependentStore = (ITTObjectListBox)AddControl(new Guid("dac584e0-bb58-41f1-8b7e-b06265d3474f"));
            labelID = (ITTLabel)AddControl(new Guid("b5484471-5eda-4ab3-8884-f8003a310fa8"));
            ID = (ITTTextBox)AddControl(new Guid("0df41507-a708-4e35-a592-1fa9c895496e"));
            labelActionDate = (ITTLabel)AddControl(new Guid("97d0965f-9ffc-467b-b172-00d8d2392f8a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4891f73c-8466-47ac-9301-96e408abdf65"));
            base.InitializeControls();
        }

        public DepStoreFirstInNewForm() : base("DEPSTOREFIRSTINACTION", "DepStoreFirstInNewForm")
        {
        }

        protected DepStoreFirstInNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}