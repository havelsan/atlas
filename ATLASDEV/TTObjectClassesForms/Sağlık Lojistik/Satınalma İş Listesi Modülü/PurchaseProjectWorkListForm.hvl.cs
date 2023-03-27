
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
    public partial class PurchaseProjectWorkListForm : BaseCriteriaForm
    {
        protected ITTTextBox txtProjectNo;
        protected ITTLabel ttlabel1;
        protected ITTTextBox txtConfirmNo;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            txtProjectNo = (ITTTextBox)AddControl(new Guid("7924679c-a765-4d17-a9eb-aecffb6e4ecd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2689410d-5743-4c1c-9de8-f11a29f62284"));
            txtConfirmNo = (ITTTextBox)AddControl(new Guid("6f22df56-ed09-48f0-8806-b4a9368f3beb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cee1b33b-2593-4c3a-813a-0e57daacf6fb"));
            base.InitializeControls();
        }

        public PurchaseProjectWorkListForm() : base("PurchaseProjectWorkListForm")
        {
        }

        protected PurchaseProjectWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}