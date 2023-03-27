
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
    public partial class PurchaseOrderWorkListForm : BaseCriteriaForm
    {
        protected ITTTextBox txtOrderNo;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            txtOrderNo = (ITTTextBox)AddControl(new Guid("e6ce5831-8f28-47b1-8ff3-2299c8d47c3d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bef882f3-8506-46af-bac6-9f61607db19e"));
            base.InitializeControls();
        }

        public PurchaseOrderWorkListForm() : base("PurchaseOrderWorkListForm")
        {
        }

        protected PurchaseOrderWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}