
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
    public partial class InformationForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region InformationForm_ttbutton1_Click
   this.Close();
#endregion InformationForm_ttbutton1_Click
        }

        private void ttbutton2_Click()
        {
#region InformationForm_ttbutton2_Click
   throw new TTException("İşlemin başlatılması durduruldu.");
#endregion InformationForm_ttbutton2_Click
        }
    }
}