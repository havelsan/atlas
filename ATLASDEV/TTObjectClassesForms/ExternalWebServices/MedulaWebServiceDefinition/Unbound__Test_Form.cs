
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
    public partial class Unbound__Test_Form : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region Unbound__Test_Form_ttbutton1_Click
   TTObjectClasses.MernisServis.SorguPaket sorguPaket = new TTObjectClasses.MernisServis.SorguPaket();
            sorguPaket.TcNo=10000000000;
            sorguPaket.TcNoSpecified = false;
   

           /*  TTObjectClasses.MernisServis.KPSServisSonucuKisiTemelBilgisi cevap = TTObjectClasses.MernisServis.RemoteMethods.TCKimlikNoDogrulaSync(Sites.SiteLocalHost, sorguPaket);
           */ //bool c= TTObjectClasses.MernisServis.RemoteMethods.TCKimlikNoDogrula(Sites.SiteLocalHost, istek2);
#endregion Unbound__Test_Form_ttbutton1_Click
        }
    }
}