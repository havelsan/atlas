
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
    public partial class CommonSKRStest : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton101.Click += new TTControlEventDelegate(ttbutton101_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttbutton103.Click += new TTControlEventDelegate(ttbutton103_Click);
            btn105.Click += new TTControlEventDelegate(btn105_Click);
            btn106.Click += new TTControlEventDelegate(btn106_Click);
            btn901.Click += new TTControlEventDelegate(btn901_Click);
            ttbutton252.Click += new TTControlEventDelegate(ttbutton252_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton101.Click -= new TTControlEventDelegate(ttbutton101_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttbutton103.Click -= new TTControlEventDelegate(ttbutton103_Click);
            btn105.Click -= new TTControlEventDelegate(btn105_Click);
            btn106.Click -= new TTControlEventDelegate(btn106_Click);
            btn901.Click -= new TTControlEventDelegate(btn901_Click);
            ttbutton252.Click -= new TTControlEventDelegate(ttbutton252_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton101_Click()
        {
            #region CommonSKRStest_ttbutton101_Click
            ENabiz101_HastaKayit.SYSMessage _sYSMessage = ENabiz101_HastaKayit.Get(new Guid(ttObjectGuid.Text),"SubEpisode");
            
            RichText.Text =  _sYSMessage.ToString();
#endregion CommonSKRStest_ttbutton101_Click
        }

        private void ttbutton1_Click()
        {
            #region CommonSKRStest_ttbutton1_Click
            ENabiz102_HizmetIlacMalzemeBilgisiKayit.SYSMessage _sysMessage = ENabiz102_HizmetIlacMalzemeBilgisiKayit.Get(new Guid(ttObjectGuid.Text),ttSubEpisode.Text.ToString());
          RichText.Text =  _sysMessage.ToString();
#endregion CommonSKRStest_ttbutton1_Click
        }

        private void ttbutton103_Click()
        {
            #region CommonSKRStest_ttbutton103_Click
            ENabiz103_MuayeneBilgisiKayit.SYSMessage _sYSMessage = ENabiz103_MuayeneBilgisiKayit.Get(new Guid(ttObjectGuid.Text),"SubEpisode");
            
            RichText.Text =  _sYSMessage.ToString();
#endregion CommonSKRStest_ttbutton103_Click
        }

        private void btn105_Click()
        {
            #region CommonSKRStest_btn105_Click
            ENabiz105_LaboratuvarSonucKayit.SYSMessage _sysMessage = ENabiz105_LaboratuvarSonucKayit.Get(new Guid(ttObjectGuid.Text),ttSubEpisode.Text.ToString());
          RichText.Text =  _sysMessage.ToString();
#endregion CommonSKRStest_btn105_Click
        }

        private void btn106_Click()
        {
            #region CommonSKRStest_btn106_Click
            ENabiz106_CikisBilgisiKayit.SYSMessage _sYSMessage = ENabiz106_CikisBilgisiKayit.Get(new Guid(ttObjectGuid.Text),"SubEpisode");
            
            RichText.Text =  _sYSMessage.ToString();
#endregion CommonSKRStest_btn106_Click
        }

        private void btn901_Click()
        {
            #region CommonSKRStest_btn901_Click
            ENabiz901_YatakBilgisiKayit.SYSMessage _sYSMessage = ENabiz901_YatakBilgisiKayit.Get(); //new Guid(ttObjectGuid.Text),"SubEpisode"

            RichText.Text =  _sYSMessage.ToString();
#endregion CommonSKRStest_btn901_Click
        }

        private void ttbutton252_Click()
        {
            #region CommonSKRStest_ttbutton252_Click
            ENabiz252_KonsultasyonKayit.SYSMessage _sYSMessage = ENabiz252_KonsultasyonKayit.Get(new Guid(ttObjectGuid.Text),"SubEpisode");
            
            RichText.Text =  _sYSMessage.ToString();
#endregion CommonSKRStest_ttbutton252_Click
        }
    }
}