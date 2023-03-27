
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
    /// Liste
    /// </summary>
    public partial class MSItemForm : TTUnboundForm
    {
        protected ITTButton OkButton;
        protected ITTListView lvwMSitem;
        protected ITTButton Cancelbutton;
        override protected void InitializeControls()
        {
            OkButton = (ITTButton)AddControl(new Guid("be784068-95c7-4a67-9056-1d0875b92063"));
            lvwMSitem = (ITTListView)AddControl(new Guid("abf56772-4e03-4fac-84d9-272b1962847c"));
            Cancelbutton = (ITTButton)AddControl(new Guid("a8ef44f4-f062-4bcc-9624-ac9a6e26e211"));
            base.InitializeControls();
        }

        public MSItemForm() : base("MSItemForm")
        {
        }

        protected MSItemForm(string formDefName) : base(formDefName)
        {
        }
    }
}