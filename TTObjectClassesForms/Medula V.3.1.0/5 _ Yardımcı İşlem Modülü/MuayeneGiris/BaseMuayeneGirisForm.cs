
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
    public partial class BaseMuayeneGirisForm : BaseMedulaActionForm
    {
        override protected void BindControlEvents()
        {
            YeniReferansNumarasiAl.Click += new TTControlEventDelegate(YeniReferansNumarasiAl_Click);
            hastaTCKimlikNo.TextChanged += new TTControlEventDelegate(hastaTCKimlikNo_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            YeniReferansNumarasiAl.Click -= new TTControlEventDelegate(YeniReferansNumarasiAl_Click);
            hastaTCKimlikNo.TextChanged -= new TTControlEventDelegate(hastaTCKimlikNo_TextChanged);
            base.UnBindControlEvents();
        }

        private void YeniReferansNumarasiAl_Click()
        {
#region BaseMuayeneGirisForm_YeniReferansNumarasiAl_Click
   this.YeniReferansNumarasiAl.ReadOnly = true;
//#if MEDULA
            TTObjectContext referansObjectContext = new TTObjectContext(false);
            try
            {
                MuayeneGirisReferansNo muayeneGirisReferansNo = new MuayeneGirisReferansNo(referansObjectContext, _MuayeneGiris.HealthFacilityID.Value);
                referansObjectContext.Save();

                if (_MuayeneGiris.HealthFacility.IsXXXXXXExist.HasValue && _MuayeneGiris.HealthFacility.IsXXXXXXExist.Value && TTUser.CurrentUser.HasRole(new Guid("da93c0e5-d591-4b56-bf28-1bd6e6bba838")))
                {
                    _MuayeneGiris.muayeneGirisDVO.referansNo = 900000000000000 + muayeneGirisReferansNo.referansNoSEQ.Value.Value;
                }
                else
                {
                    _MuayeneGiris.muayeneGirisDVO.referansNo = muayeneGirisReferansNo.referansNoSEQ.Value.Value;
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
                _MuayeneGiris.muayeneGirisDVO.referansNo = null;
                this.YeniReferansNumarasiAl.ReadOnly = false;
            }
            finally
            {
                referansObjectContext.Dispose();
            }
//#endif
#endregion BaseMuayeneGirisForm_YeniReferansNumarasiAl_Click
        }

        private void hastaTCKimlikNo_TextChanged()
        {
#region BaseMuayeneGirisForm_hastaTCKimlikNo_TextChanged
   if (hastaTCKimlikNo.Text.Length == 11)
            {

                IList hastaBilgileriList = HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery(this._MuayeneGiris.ObjectContext, hastaTCKimlikNo.Text);
                if (hastaBilgileriList.Count > 0)
                {
                    filledExistingPatientInformation = true;
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
                else
                {
                    if (filledExistingPatientInformation)
                    {
                        HastaAd.Text = string.Empty;
                        HastaSoyad.Text = string.Empty;
                        HastaCinsiyet.SelectedItem = null;
                        HastaSigortaliTuru.SelectedItem = null;
                        ((ITTDateTimePicker)HastaDogumTarihi).ControlValue = null;
                        filledExistingPatientInformation = false;
                    }
                }
            }
#endregion BaseMuayeneGirisForm_hastaTCKimlikNo_TextChanged
        }

        protected override void PreScript()
        {
#region BaseMuayeneGirisForm_PreScript
    base.PreScript();

            ITTObject iTTobject = (ITTObject)this._MuayeneGiris;
//#if MEDULA
            bool isAccess = false;
            if (_MuayeneGiris.HealthFacility.IsXXXXXXExist.HasValue == false || _MuayeneGiris.HealthFacility.IsXXXXXXExist.Value == false)
            {
                isAccess = true;
            }
            else
            {
                if (iTTobject.IsNew == false)
                    isAccess = true;

                if (TTUser.CurrentUser.IsPowerUser == false && TTUser.CurrentUser.IsSuperUser == false && TTUser.CurrentUser.HasRole(new Guid("da93c0e5-d591-4b56-bf28-1bd6e6bba838"))) // Muayene Giriş (Özel Yetki)
                    isAccess = true;
            }

            if (isAccess == false)
                throw new TTException("Bu işlem XXXXXX kullanan sahalarda başlatılamaz.\r\n\r\nXXXXXX kullanan sahalar XXXXXX'dan \"Disket Hazırlama\" yöntemi ile aktarma yapmaları gerekmektedir.");
//#endif

            if (iTTobject.IsNew)
                _MuayeneGiris.muayeneGirisDVO.saglikTesisKodu = _MuayeneGiris.HealthFacilityID.Value;

            this.drTescilNoMuayeneGirisDVO.ListFilterExpression = " SAGLIKTESISI = " + ConnectionManager.GuidToString(SaglikTesisi.GetSaglikTesisi(_MuayeneGiris.HealthFacilityID.Value).ObjectID);

//#if MEDULA
            if (_MuayeneGiris.muayeneGirisDVO.referansNo.HasValue)
            {
                this.YeniReferansNumarasiAl.ReadOnly = true;
            }
            else
            {
                if (_MuayeneGiris.HealthFacility.IsXXXXXXExist.HasValue && _MuayeneGiris.HealthFacility.IsXXXXXXExist.Value && TTUser.CurrentUser.HasRole(new Guid("da93c0e5-d591-4b56-bf28-1bd6e6bba838")))
                    this.YeniReferansNumarasiAl.ReadOnly = false;
                else
                    this.YeniReferansNumarasiAl.ReadOnly = false;
            }
//#endif
#endregion BaseMuayeneGirisForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseMuayeneGirisForm_PostScript
    base.PostScript(transDef);
            CheckTheIdentificationNumber(hastaTCKimlikNo.Text);
#endregion BaseMuayeneGirisForm_PostScript

            }
            
#region BaseMuayeneGirisForm_Methods
        protected bool filledExistingPatientInformation = false;
        
#endregion BaseMuayeneGirisForm_Methods
    }
}