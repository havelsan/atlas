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
    public partial class ConvTestForm2 : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            No.TextChanged += new TTControlEventDelegate(No_TextChanged);
        }

        protected override void PreScript()
        {
            base.PreScript();
            this._ConvTest.No = 99;
            this.Telephone.Text += "(555)";
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            base.PostScript(transDef);
            if (transDef.ToStateDefID == ConvTest.States.Approove)
            {
                this._ConvTest.Description = "Onaylar mýsýnýz?";
            }
        }

        private void No_TextChanged()
        {
            this.ttbutton1.Text += ".";
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            No.TextChanged -= new TTControlEventDelegate(No_TextChanged);
        }

        private void ttbutton1_Click()
        {
            this.Telephone.Text += "1";

            if (this._ConvTest.No.HasValue)
                this.No.Text = ConvTest.NoyuBirArttir(Convert.ToInt32(this.No.Text)).ToString();

            this._ConvTest.Telephone += "2";
            if (this._ConvTest.No.HasValue)
                this._ConvTest.No += ConvTest.NoyuBirArttir(this._ConvTest.No.Value);

            this.cekbaks.Value = true;

            this.deyt.Text = "01.01.2000";

        }
    }
}