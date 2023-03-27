
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
    /// Detaylar
    /// </summary>
    public partial class BaseStockActionDetailForm : TTForm
    {
    /// <summary>
    /// Stok Hareket Detaylarının temel detaylarını barındırır.
    /// </summary>
        protected TTObjectClasses.StockActionDetail _StockActionDetail
        {
            get { return (TTObjectClasses.StockActionDetail)_ttObject; }
        }

        protected ITTListDefComboBox StockLevelType;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTLabel labelStockLevelType;
        override protected void InitializeControls()
        {
            StockLevelType = (ITTListDefComboBox)AddControl(new Guid("b5aaac8d-44c6-4d4a-b551-d5589d597953"));
            labelMaterial = (ITTLabel)AddControl(new Guid("9b2c65de-9116-4bd9-b0ee-c9f621644409"));
            Material = (ITTObjectListBox)AddControl(new Guid("d0c263fa-fe86-4439-9e8e-9762cf7c87d9"));
            labelAmount = (ITTLabel)AddControl(new Guid("2a8cc010-b161-4ad8-8cb7-01cf2614a157"));
            Amount = (ITTTextBox)AddControl(new Guid("54613ff1-5e35-477c-bf3c-1181a830558b"));
            labelStockLevelType = (ITTLabel)AddControl(new Guid("300b46f0-a671-4fb4-ad1b-1c3cbeb5abb0"));
            base.InitializeControls();
        }

        public BaseStockActionDetailForm() : base("STOCKACTIONDETAIL", "BaseStockActionDetailForm")
        {
        }

        protected BaseStockActionDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}