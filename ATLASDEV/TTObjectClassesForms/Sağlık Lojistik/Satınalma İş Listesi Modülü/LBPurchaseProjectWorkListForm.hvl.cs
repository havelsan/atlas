
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
    public partial class LBPurchaseProjectWorkListForm : BaseCriteriaForm
    {
        protected ITTTextBox txtProjectNo;
        protected ITTLabel ttlabel1;
        protected ITTComboBox StatusBox;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            txtProjectNo = (ITTTextBox)AddControl(new Guid("db105e68-53d5-4c38-b61e-7da00b6eeb2c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f20cb74d-1497-4510-b605-46e4ead755b2"));
            StatusBox = (ITTComboBox)AddControl(new Guid("0d24ac4f-d1e5-4ec3-a761-2fe72a93ac41"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d1a27eb5-d01c-44ca-bf4a-3976abc650b6"));
            base.InitializeControls();
        }

        public LBPurchaseProjectWorkListForm() : base("LBPurchaseProjectWorkListForm")
        {
        }

        protected LBPurchaseProjectWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}