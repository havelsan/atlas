
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
    public partial class SendToENabizTestFormFromTextEditor : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            sysGonder.Click += new TTControlEventDelegate(sysGonder_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            sysGonder.Click -= new TTControlEventDelegate(sysGonder_Click);
            base.UnBindControlEvents();
        }

        private void sysGonder_Click()
        {
#region SendToENabizTestFormFromTextEditor_sysGonder_Click
   DateTime dt = DateTime.Now;
            var responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, txtSendXML.Text);

            txtResponceXML.Text = responce;

            TimeSpan ts = (DateTime.Now - dt);

            ttlabel3.Text = ts.TotalMilliseconds.ToString();
#endregion SendToENabizTestFormFromTextEditor_sysGonder_Click
        }
    }
}