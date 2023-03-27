
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class ConvTestApprooveForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
        }

        private void ttbutton1_Click()
        {
            this.Telephone.Text += "!";
            if (string.IsNullOrEmpty(this.No.Text)==false)
                this.No.Text = ConvTest.NoyuBirArttir(ConvTest.NoyuBirArttir(Convert.ToInt32(this.No.Text))).ToString();
        }
    }
}