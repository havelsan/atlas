
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
    /// <summary>
    /// New Unbound Form
    /// </summary>
    public partial class SPTSEntegrasyonDenemeFormu : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton2_Click()
        {
#region SPTSEntegrasyonDenemeFormu_ttbutton2_Click
   TTMessage message = TTMessageFactory.GetMessage(new Guid(tttextbox1.Text));
            
            XXXXXXSptsClasses.ProvReturn provReturn = (XXXXXXSptsClasses.ProvReturn)message.ReturnValue;
            
            tttextbox2.Text = provReturn.ilac.name.ToString();
#endregion SPTSEntegrasyonDenemeFormu_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region SPTSEntegrasyonDenemeFormu_ttbutton1_Click
   //string barcode = "8699690600328";
   //         TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority ,"XXXXXXDLL","XXXXXXDLL","IlacBilgi", null, barcode);
   //         tttextbox1.Text = message.MessageID.ToString();
#endregion SPTSEntegrasyonDenemeFormu_ttbutton1_Click
        }
    }
}