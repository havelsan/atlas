
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
    /// Temel Hasta Kabul
    /// </summary>
    public partial class BaseHastaKabulForm : BaseMedulaActionForm
    {
        override protected void BindControlEvents()
        {
            provizyonTarihiDateTimePicker.ValueChanged += new TTControlEventDelegate(provizyonTarihiDateTimePicker_ValueChanged);
            hastaTCKimlikNo.TextChanged += new TTControlEventDelegate(hastaTCKimlikNo_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            provizyonTarihiDateTimePicker.ValueChanged -= new TTControlEventDelegate(provizyonTarihiDateTimePicker_ValueChanged);
            hastaTCKimlikNo.TextChanged -= new TTControlEventDelegate(hastaTCKimlikNo_TextChanged);
            base.UnBindControlEvents();
        }

        private void provizyonTarihiDateTimePicker_ValueChanged()
        {
#region BaseHastaKabulForm_provizyonTarihiDateTimePicker_ValueChanged
   string provizyonTarihiDateTime = provizyonTarihiDateTimePicker.Text;
            if (string.IsNullOrEmpty(provizyonTarihiDateTime) == false && provizyonTarihiDateTime.Length >= 10)
                provizyonTarihi.Text = provizyonTarihiDateTime.Substring(0, 10);
#endregion BaseHastaKabulForm_provizyonTarihiDateTimePicker_ValueChanged
        }

        private void hastaTCKimlikNo_TextChanged()
        {
#region BaseHastaKabulForm_hastaTCKimlikNo_TextChanged
   if (hastaTCKimlikNo.Text.Length == 11)
            {

                IList hastaBilgileriList = HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery(this._BaseHastaKabul.ObjectContext, hastaTCKimlikNo.Text);
                if (hastaBilgileriList.Count > 0)
                {
                    filledExistingPatientInformation = true;
                    HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class hastaBilgisi = (HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class)hastaBilgileriList[0];
                    HastaAd.Text = hastaBilgisi.ad;
                    HastaSoyad.Text = hastaBilgisi.soyad;
                    HastaCinsiyet.ControlValue = hastaBilgisi.cinsiyet;
                    HastaSigortaliTuru.ControlValue = hastaBilgisi.sigortaliTuru;
                    sigortaliTuru.ControlValue = hastaBilgisi.sigortaliTuru;
                    if (string.IsNullOrEmpty(hastaBilgisi.dogumTarihi) == false && Globals.IsDate(hastaBilgisi.dogumTarihi))
                    {
                        DateTime dateTime = Convert.ToDateTime(hastaBilgisi.dogumTarihi);
                        ((ITTDateTimePicker)HastaDogumTarihi).ControlValue = dateTime;
                    }
                }
                else
                {
                    if (filledExistingPatientInformation)
                    {
                        HastaAd.Text = string.Empty;
                        HastaSoyad.Text = string.Empty;
                        HastaCinsiyet.SelectedItem = null;
                        HastaSigortaliTuru.SelectedItem = null;
                        sigortaliTuru.SelectedItem = null;
                        ((ITTDateTimePicker)HastaDogumTarihi).ControlValue = null;
                        filledExistingPatientInformation = false;
                    }
                }
            }
#endregion BaseHastaKabulForm_hastaTCKimlikNo_TextChanged
        }

        protected override void PreScript()
        {
#region BaseHastaKabulForm_PreScript
    base.PreScript();

            ITTObject iTTObject = (ITTObject)_BaseHastaKabul;
            if (iTTObject.IsNew)
                _BaseHastaKabul.provizyonGirisDVO.saglikTesisKodu = _BaseHastaKabul.HealthFacilityID.Value;

            if (string.IsNullOrEmpty(provizyonTarihi.Text))
            {
                ((ITTDateTimePicker)provizyonTarihiDateTimePicker).ControlValue = TTObjectDefManager.ServerTime;
            }
            else
            {
                DateTime dateTime = Convert.ToDateTime(provizyonTarihi.Text);
                ((ITTDateTimePicker)provizyonTarihiDateTimePicker).ControlValue = dateTime;
            }

            if (((ITTObject)_BaseHastaKabul).IsNew == false)
            {

                if (hastaTCKimlikNo.Text.Length == 11)
                {

                    IList hastaBilgileriList = HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery(this._BaseHastaKabul.ObjectContext, hastaTCKimlikNo.Text);
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
            }
#endregion BaseHastaKabulForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseHastaKabulForm_PostScript
    base.PostScript(transDef);
            CheckTheIdentificationNumber(hastaTCKimlikNo.Text);
#endregion BaseHastaKabulForm_PostScript

            }
            
#region BaseHastaKabulForm_Methods
        protected bool filledExistingPatientInformation = false;

#if DEVELOPMENT
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyData)
            {
                case Keys.Control | Keys.F10:
                    this.hastaTCKimlikNo.Text = "10000000000";
                    this.provizyonTipi.ControlValue = "N";
                    this.tedaviTuru.ControlValue = "A";
                    this.bransKodu.ControlValue = "1000";
                    this.tedaviTipi.ControlValue = "0";
                    this.takipTipi.ControlValue = "N";
                    this.devredilenKurum.ControlValue = "1";
                    break;
            }
        }
#endif
        
#endregion BaseHastaKabulForm_Methods
    }
}