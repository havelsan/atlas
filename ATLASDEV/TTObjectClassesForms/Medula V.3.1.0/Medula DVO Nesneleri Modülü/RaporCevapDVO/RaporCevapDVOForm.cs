
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
    public partial class RaporCevapDVOForm : BaseMedulaRaporCevapForm
    {
        override protected void BindControlEvents()
        {
            buttonRaporCevapBilgileri.Click += new TTControlEventDelegate(buttonRaporCevapBilgileri_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            buttonRaporCevapBilgileri.Click -= new TTControlEventDelegate(buttonRaporCevapBilgileri_Click);
            base.UnBindControlEvents();
        }

        private void buttonRaporCevapBilgileri_Click()
        {
#region RaporCevapDVOForm_buttonRaporCevapBilgileri_Click
   //MedulaGlobals.ShowRaporCevap(this, _RaporCevapDVO);
#endregion RaporCevapDVOForm_buttonRaporCevapBilgileri_Click
        }
    }
}