
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
    /// Stok Kartı Sınıfı Tanımları
    /// </summary>
    public partial class StockCardClassForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Stok Kartı Sınıfı Tanımları
    /// </summary>
        protected TTObjectClasses.StockCardClass _StockCardClass
        {
            get { return (TTObjectClasses.StockCardClass)_ttObject; }
        }

        protected ITTLabel labelParentStockCardClass;
        protected ITTObjectListBox ParentStockCardClass;
        protected ITTCheckBox IsGroup;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox QREF;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTLabel labelQREF;
        override protected void InitializeControls()
        {
            labelParentStockCardClass = (ITTLabel)AddControl(new Guid("ef4bb41c-c96f-4ee9-9fc8-13a180cf7212"));
            ParentStockCardClass = (ITTObjectListBox)AddControl(new Guid("2e49f8ca-75c9-455e-9514-5b45e42bf7d2"));
            IsGroup = (ITTCheckBox)AddControl(new Guid("339a3c11-3df7-4e98-8cae-9ca6bbcdcad5"));
            Name = (ITTTextBox)AddControl(new Guid("3a7bd222-9ce8-49cc-b9c0-9f360fbc946d"));
            Code = (ITTTextBox)AddControl(new Guid("2bdb6ac9-0405-4b2c-b03e-b980e8556d17"));
            QREF = (ITTTextBox)AddControl(new Guid("9c810ab6-78c9-4a4e-b370-b06713c2e1e7"));
            labelName = (ITTLabel)AddControl(new Guid("7690f030-9a3e-4573-9424-e485b0d3bce0"));
            labelCode = (ITTLabel)AddControl(new Guid("983f3aea-1407-48f1-a20d-469161080d91"));
            labelQREF = (ITTLabel)AddControl(new Guid("da6be38d-1c25-439f-be0a-599c60b08967"));
            base.InitializeControls();
        }

        public StockCardClassForm() : base("STOCKCARDCLASS", "StockCardClassForm")
        {
        }

        protected StockCardClassForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}