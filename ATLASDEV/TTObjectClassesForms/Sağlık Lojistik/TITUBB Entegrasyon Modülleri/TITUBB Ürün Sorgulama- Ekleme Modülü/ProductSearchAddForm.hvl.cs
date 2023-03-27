
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
    /// TITUBB Ürün Sorgulama/ Ekleme
    /// </summary>
    public partial class ProductSearchAddForm : TTUnboundForm
    {
        protected ITTButton cmdCreate;
        protected ITTButton cmdSearch;
        protected ITTListView productListView;
        protected ITTTextBox barcodeTxt;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            cmdCreate = (ITTButton)AddControl(new Guid("4c564031-61ed-4d6d-a61d-6f6cd67e5e50"));
            cmdSearch = (ITTButton)AddControl(new Guid("9ff04bd3-30be-4de4-9cf9-a87ff41c4ddc"));
            productListView = (ITTListView)AddControl(new Guid("2f5e0388-7ceb-4748-aff2-49f12bca9462"));
            barcodeTxt = (ITTTextBox)AddControl(new Guid("3f247f7f-9241-4073-86ce-394eda7906d1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5b4dfe62-ac0a-4eac-ac7a-cf5b2e4d9ad4"));
            base.InitializeControls();
        }

        public ProductSearchAddForm() : base("ProductSearchAddForm")
        {
        }

        protected ProductSearchAddForm(string formDefName) : base(formDefName)
        {
        }
    }
}