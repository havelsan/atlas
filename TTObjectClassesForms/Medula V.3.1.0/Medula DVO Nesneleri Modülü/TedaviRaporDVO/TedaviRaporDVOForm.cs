
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
    public partial class TedaviRaporDVOForm : BaseMedulaObjectForm
    {
        override protected void BindControlEvents()
        {
            tedaviRaporuYaz.Click += new TTControlEventDelegate(tedaviRaporuYaz_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tedaviRaporuYaz.Click -= new TTControlEventDelegate(tedaviRaporuYaz_Click);
            base.UnBindControlEvents();
        }

        private void tedaviRaporuYaz_Click()
        {
#region TedaviRaporDVOForm_tedaviRaporuYaz_Click
   //MedulaGlobals.ShowTedaviIslemBilgisi(this, _TedaviRaporDVO.tedaviRaporTuru.Value, _TedaviRaporDVO.islemler[0], true);
#endregion TedaviRaporDVOForm_tedaviRaporuYaz_Click
        }
    }
}