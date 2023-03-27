
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
    /// Sahalara Malzeme Yollama
    /// </summary>
    public partial class AllSiteSendMaterial : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            sendMatbutton.Click += new TTControlEventDelegate(sendMatbutton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            sendMatbutton.Click -= new TTControlEventDelegate(sendMatbutton_Click);
            base.UnBindControlEvents();
        }

        private void sendMatbutton_Click()
        {
#region AllSiteSendMaterial_sendMatbutton_Click
   TTObjectContext context = new TTObjectContext(false);
            Material mat = (Material)context.GetObject(this.MaterialListBox.SelectedObject.ObjectID, typeof(Material).Name);
            
            List<Sites> targetSites = new List<Sites>();
            foreach (KeyValuePair<Guid, Sites> site in Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST)
                targetSites.Add(site.Value);
            
            if (this.MaterialListBox.SelectedObject != null)
            {
                TerminologyManagerDef.RunSendWithTerminologyManagerDefV3(mat,targetSites,false);
                InfoBox.Show("Tüm Sahalara Yollandı.",MessageIconEnum.InformationMessage);
            }
            else
            {
                InfoBox.Show("Malzeme seçmelisiniz.",MessageIconEnum.ErrorMessage);
            }
            
            context.Dispose();
#endregion AllSiteSendMaterial_sendMatbutton_Click
        }
    }
}