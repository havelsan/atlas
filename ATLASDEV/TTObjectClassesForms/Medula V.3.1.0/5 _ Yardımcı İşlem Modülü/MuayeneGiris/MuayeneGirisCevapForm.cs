
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
    public partial class MuayeneGirisCevapForm : BaseMuayeneGirisForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region MuayeneGirisCevapForm_PreScript
    base.PreScript();

            if (hastaTCKimlikNo.Text.Length == 11)
            {

                IList hastaBilgileriList = HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery(this._MuayeneGiris.ObjectContext, hastaTCKimlikNo.Text);
                if (hastaBilgileriList.Count > 0)
                {
                    HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class hastaBilgisi = (HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class)hastaBilgileriList[0];
                    HastaAd.Text = hastaBilgisi.ad;
                    HastaSoyad.Text = hastaBilgisi.soyad;
                    HastaCinsiyet.ControlValue = hastaBilgisi.cinsiyet;
                    HastaSigortaliTuru.ControlValue = hastaBilgisi.sigortaliTuru;
                    if (string.IsNullOrEmpty(hastaBilgisi.dogumTarihi) == false && Globals.IsDate(hastaBilgisi.dogumTarihi))
                    {
                        DateTime dateTime = Convert.ToDateTime(hastaBilgisi.dogumTarihi);
                        ((ITTDateTimePicker)HastaDogumTarihi).ControlValue = dateTime;
                    }
                }
            }
#endregion MuayeneGirisCevapForm_PreScript

            }
                }
}