
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
    public partial class DepStoreFirstInCompForm : TTForm
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
            cmdGetDepStock = (ITTButton)AddControl(new Guid("360aa46d-d28b-433e-9029-08c32739be25"));
            DepStoreFirstInActionDetails = (ITTGrid)AddControl(new Guid("489ea55d-8742-4986-b921-02e5468aef9e"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("77a32c1a-0edf-4acf-b9ca-fa91144cb157"));
            MaterialDepStoreFirstInActionDet = (ITTListBoxColumn)AddControl(new Guid("331c642b-af2f-4b0e-9b9f-d1c8ea290d72"));
            ExpirationDateDepStoreFirstInActionDet = (ITTDateTimePickerColumn)AddControl(new Guid("c64e3f79-dc91-452d-bd13-589767aa4669"));
            UnitPriceDepStoreFirstInActionDet = (ITTTextBoxColumn)AddControl(new Guid("8ccf8060-d75c-4106-a50a-02357d1b0417"));
            AmountDepStoreFirstInActionDet = (ITTTextBoxColumn)AddControl(new Guid("55024a0c-2ec5-4027-862a-57ef2e8e0dfc"));
            StockLevelTypeDepStoreFirstInActionDet = (ITTListBoxColumn)AddControl(new Guid("b4443804-6067-4554-b570-bd4163846aea"));
            labelDependentStore = (ITTLabel)AddControl(new Guid("ffdcfb67-d984-40d1-b00c-c7f79a3fded2"));
            DependentStore = (ITTObjectListBox)AddControl(new Guid("39d36382-bfb1-4ad0-bfb3-5191b2f881f1"));
            labelID = (ITTLabel)AddControl(new Guid("2be3942f-df0b-4331-b6c0-577aa4d3795c"));
            ID = (ITTTextBox)AddControl(new Guid("62100f3b-1a7a-4810-883a-57d5ecf434f5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("9e2d1097-fe1d-46d9-b394-14931e1855d0"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("14c2bd70-9c56-41fc-a2ed-026b7a9e933c"));
            base.InitializeControls();
        }

        public DepStoreFirstInCompForm() : base("DEPSTOREFIRSTINACTION", "DepStoreFirstInCompForm")
        {
        }

        protected DepStoreFirstInCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}