
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
    /// Hasta Yatış
    /// </summary>
    public partial class InpatientAdmissionQuarantineForm : InPatientAdmissionBaseForm
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
#region InpatientAdmissionQuarantineForm_PreScript
    base.PreScript();

            if (this._InpatientAdmission.DischargeNumber != null)
            {
                this.lblDischargeNumber.Visible = true;
                this.DischargeNumber.Visible = true;
            }
            else
            {
                this.lblDischargeNumber.Visible = false;
                this.DischargeNumber.Visible = false;
            }



            this.DischargedConclusion.Rtf = InpatientAdmission.GetDischargedConclusion(this._InpatientAdmission);

            //if ( this._InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ReadyToDischarge)
            //    this.SetFormReadOnly();


            if (this._InpatientAdmission.SubEpisode.PatientAdmission != null && this._InpatientAdmission.SubEpisode.PatientAdmission.Sevkli != null && this._InpatientAdmission.SubEpisode.PatientAdmission.Sevkli == true)
                this.tttabcontrol1.ShowTabPage(MedulaSevkliHastaSevkBilgileri);
            else
            {
                this.tttabcontrol1.HideTabPage(MedulaSevkliHastaSevkBilgileri);
                this.TTListBoxMedulaSevkVasitasi.Required = false;
                this.medulaRefakatciDurumu.Required = false;
            }
            
           
#endregion InpatientAdmissionQuarantineForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientAdmissionQuarantineForm_PostScript
    base.PostScript(transDef);

            //TODO ServerSidePost Scripte taşınmalı!
            //if (Episode.IsMedulaEpisode(_InpatientAdmission.Episode) == true)
            //{
            //    if (this._InpatientAdmission.TransDef != null && this._InpatientAdmission.TransDef.ToStateDefID == InpatientAdmission.States.Discharged)
            //    {
            //        if (this._InpatientAdmission.Episode != null && this._InpatientAdmission.SubEpisode.PatientAdmission != null && this._InpatientAdmission.SubEpisode.PatientAdmission.Sevkli != null && this._InpatientAdmission.SubEpisode.PatientAdmission.Sevkli == true)
            //        {
            //            if (this._InpatientAdmission.MutatDisiAracRaporId.Value == null)
            //                this._InpatientAdmission.MutatDisiAracRaporId.GetNextValueFromDatabase(null, 0);
            //            if (MedulaSevkKayitSync())
            //                InfoBox.Alert("Sevkli hastanın kaydi medulaya bildirildi.", MessageIconEnum.InformationMessage);
            //            else
            //                throw new Exception("Sevkli hastanın bilgilerinin medulaya kaydı sırasında hata oluştu!");
            //        }
            //    }
            //}
            var a = 1;
#endregion InpatientAdmissionQuarantineForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientAdmissionQuarantineForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            //if (transDef.FromStateDefID == InpatientAdmission.States.FinancialDepartmentControl && transDef.ToStateDefID == InpatientAdmission.States.ReadyToDischarge )
            //{
            //    // Yatış gün sayısı ile oluşmuş yatak hizmeti sayısını karşılaştırır, eşit değilse uyarı verir
            //    this.ControlBedProcedureCount();
            //}
#endregion InpatientAdmissionQuarantineForm_ClientSidePostScript

        }

        #region InpatientAdmissionQuarantineForm_Methods
        /*
         * MEDULA SEVK KAYIT METODU
         * */
        //TODO ServerSidePost Scripte taşınmalı!
        //public bool MedulaSevkKayitSync()
        //{

        //    try
        //    {
        //        SevkIslemleri.sevkCevapDVO sevkCevapDVO = SevkIslemleri.WebMethods.sevkKayitSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkKayitDVO());
        //        if (sevkCevapDVO != null)
        //        {
        //            if (string.IsNullOrEmpty(sevkCevapDVO.sonucKodu) == false)
        //            {
        //                if (sevkCevapDVO.sonucKodu.Equals("0000"))
        //                {
        //                    InfoBox.Alert("E-sevk kayıt işlemi başarı ile sonuçlandı.  Sevk Takip No: " + sevkCevapDVO.sevkTakipNo + "  E-Sevk No: " + sevkCevapDVO.esevkNo.ToString(), MessageIconEnum.InformationMessage);
        //                    this._InpatientAdmission.MedulaESevkNo = sevkCevapDVO.esevkNo.ToString();
        //                    return true;
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
        //                        throw new Exception("E-sevk kayıt işleminde hata var: Sonuç Mesajı :" + sevkCevapDVO.sonucMesaji);
        //                    else
        //                        throw new Exception("E-sevk kayıt işleminde hata var");
        //                }
        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
        //                    throw new Exception("E-sevk kayıt işleminde hata var:Sonuç Mesajı :" + sevkCevapDVO.sonucMesaji);
        //                else
        //                    throw new Exception("E-sevk kayıt işleminde hata var");
        //            }
        //        }
        //        else
        //            throw new Exception("Medulaya e-sevk kayıt işlemi yapılamadı!");

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Medulaya e-sevk kayıt işlemi sırasında sistem hatası oluştu! Hata: " + e.Message);
        //    }
        //    //return false;
        //}


        ///*
        // * MEDULA SEVK KAYIT DVO HAZIRLANMASI
        // * */

        //public SevkIslemleri.sevkKayitDVO GetSevkKayitDVO()
        //{

        //    SevkIslemleri.sevkKayitDVO sevkKayitDVO = new SevkIslemleri.sevkKayitDVO();

        //    // *kabulTakipNo : Sevkin kabulünün yapıldığı takip numarası

        //    if (this._InpatientAdmission.Episode != null && this._InpatientAdmission.SubEpisode.PatientAdmission != null && this._InpatientAdmission.SubEpisode.PatientAdmission.MedulaProvision != null && this._InpatientAdmission.SubEpisode.PatientAdmission.MedulaProvision.ProvisionNo != null)
        //        sevkKayitDVO.kabulTakipNo = this._InpatientAdmission.SubEpisode.PatientAdmission.MedulaProvision.ProvisionNo;
        //    else
        //        throw new Exception("Medulaya e-sevk  kayıt işleminde kabul takip no alanı dolu olmalıdır!");

        //    // donusVasitasi
        //    if (this._InpatientAdmission.MedulaSevkDonusVasitasi != null && this._InpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
        //        sevkKayitDVO.donusVasitasi = Convert.ToInt32(this._InpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu);
        //    else
        //        throw new Exception("Medulaya e-sevk kayıt işleminde dönüş vasıtası alanı dolu olmalıdır!");

        //    if (this._InpatientAdmission.MedulaRefakatciDurumu != null)
        //    {
        //        if (this._InpatientAdmission.MedulaRefakatciDurumu.Value == true)
        //            sevkKayitDVO.refakatci = "E";
        //        else
        //            sevkKayitDVO.refakatci = "H";
        //    }
        //    else
        //        throw new Exception("Medulaya e-sevk kayıt işleminde refakatçi durumu alanı dolu olmalıdır!");

        //    //* ayrilisTarihi
        //    String ayrilisTarihi = InpatientAdmission.GetLatestDischargeDate(this._InpatientAdmission);
        //    if (string.IsNullOrEmpty(ayrilisTarihi) == false)
        //        sevkKayitDVO.ayrilisTarihi = ayrilisTarihi;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydı yapılabilmesi için; XXXXXXden ayrılış tarihi dolu olmalıdır!");

        //    //raporId : Mutat dışı araç rapor numarası. Mutat dışı araç değilse 0 yollanacaktır.
        //    if (this._InpatientAdmission.MedulaSevkDonusVasitasi != null && this._InpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
        //    {
        //        if (!this._InpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu.Equals("1") && !this._InpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu.Equals("12"))
        //        {
        //            if (MutatDisiAracRaporKaydetSync())
        //            {
        //                if (this._InpatientAdmission.MedulaMutatDisiAracRaporNo != null)
        //                    sevkKayitDVO.raporId = Convert.ToInt64(this._InpatientAdmission.MedulaMutatDisiAracRaporNo);
        //                else
        //                    throw new Exception("Medulaya e-sevk kaydında öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
        //            }
        //            else
        //            {
        //                throw new Exception("Medulaya e-sevk kaydında öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
        //            }
        //        }
        //        else
        //        {
        //            this._InpatientAdmission.MedulaMutatDisiAracRaporNo = "0";
        //            sevkKayitDVO.raporId = Convert.ToInt64(this._InpatientAdmission.MedulaMutatDisiAracRaporNo);
        //        }
        //    }

        //    //*tedaviTani -> SevkTaniDVO[]
        //    SevkIslemleri.sevkTaniDVO[] sevkTaniList = GetSevkTaniDVOList("Medulaya e-sevk kaydında");
        //    if (sevkTaniList != null)
        //        sevkKayitDVO.tedaviTani = sevkTaniList;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydında hastaya ait tanı girilmiş olmalıdır!");

        //    // *sevkEdenDoktor   -> SevkDoktorDVO[]
        //    SevkIslemleri.sevkDoktorDVO[] sevkDoktorList = GetSevkMutatDisiDoktorDVOList("Medulaya e-sevk kaydında");
        //    if (sevkDoktorList != null)
        //        sevkKayitDVO.tedaviEdenDoktor = sevkDoktorList;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydında tedavi eden doktorların bilgileri girilmiş olmalıdır!");

        //    // *sevkTedavi: SevkTedaviDVO[]
        //    SevkIslemleri.sevkTedaviDVO[] sevkTedaviList = GetSevkTedaviDVOList();
        //    if (sevkTedaviList != null)
        //        sevkKayitDVO.sevkTedavi = sevkTedaviList;
        //    else
        //        throw new Exception("Medulaya e-sevk kaydında sevk tedavi bilgileri girilmiş olmalıdır!");


        //    // *kullaniciTesisKodu
        //    sevkKayitDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

        //    return sevkKayitDVO;
        //}

        //public SevkIslemleri.sevkTaniDVO[] GetSevkTaniDVOList(string type)
        //{
        //    List<SevkIslemleri.sevkTaniDVO> sevkTaniDVOList = null;
        //    if (this._InpatientAdmission.Episode != null)
        //    {
        //        sevkTaniDVOList = new List<SevkIslemleri.sevkTaniDVO>();

        //        foreach (String diagnose in Episode.GetMyMedulaDiagnosisDefinitionICDCodes(_InpatientAdmission.Episode))
        //        {
        //            SevkIslemleri.sevkTaniDVO sevkTaniDVO = new SevkIslemleri.sevkTaniDVO();
        //            sevkTaniDVO.sevkTaniKodu = diagnose;
        //            sevkTaniDVOList.Add(sevkTaniDVO);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(type + " hastaya ait tanı girilmiş olmalıdır!");
        //    }
        //    return sevkTaniDVOList.ToArray();
        //}

        //public SevkIslemleri.sevkTedaviDVO[] GetSevkTedaviDVOList()
        //{
        //    List<SevkIslemleri.sevkTedaviDVO> sevkTedaviDVOList = null;

        //    if (this._InpatientAdmission.InPatientTreatmentClinicApplications != null)
        //    {
        //        sevkTedaviDVOList = new List<SevkIslemleri.sevkTedaviDVO>();
        //        foreach (InPatientTreatmentClinicApplication inPtntTrtmntClncApp in this._InpatientAdmission.InPatientTreatmentClinicApplications)
        //        {
        //            if (inPtntTrtmntClncApp != null)
        //            {
        //                SevkIslemleri.sevkTedaviDVO sevkTedaviDVO = new SevkIslemleri.sevkTedaviDVO();

        //                //baslangicTarihi
        //                if (inPtntTrtmntClncApp.ClinicInpatientDate != null && inPtntTrtmntClncApp.ClinicInpatientDate.Value != null)
        //                    sevkTedaviDVO.baslangicTarihi = inPtntTrtmntClncApp.ClinicInpatientDate.Value.ToShortDateString();

        //                //bitisTarihi
        //                if (inPtntTrtmntClncApp.ClinicDischargeDate != null && inPtntTrtmntClncApp.ClinicDischargeDate.Value != null)
        //                    sevkTedaviDVO.bitisTarihi = inPtntTrtmntClncApp.ClinicDischargeDate.Value.ToShortDateString();

        //                //tedavi türü
        //                // her klinikte farklı bir tedavi türü olabilir mi? Ayaktan yada yatan olarak?????
        //                if (this._InpatientAdmission.Episode != null && this._InpatientAdmission.Episode.PatientStatus != null )
        //                {

        //                    if (this._InpatientAdmission.Episode.PatientStatus.Value == PatientStatusEnum.Inpatient)
        //                        sevkTedaviDVO.tedaviTuru = "Y";
        //                    else if (this._InpatientAdmission.Episode.PatientStatus.Value == PatientStatusEnum.Outpatient)
        //                        sevkTedaviDVO.tedaviTuru = "A";
        //                    else if (this._InpatientAdmission.Episode.PatientStatus.Value == PatientStatusEnum.Discharge)
        //                        sevkTedaviDVO.tedaviTuru = "S";
        //                    else
        //                        throw new Exception("Sevkte yapılan tedavi türü dolu olmalıdır!");

        //                }
        //                sevkTedaviDVOList.Add(sevkTedaviDVO);
        //            }

        //        }
        //    }
        //    else
        //        throw new Exception("Sevkte yapılan tedaviler dolu olmalıdır!");

        //    if (sevkTedaviDVOList.Count <= 0)
        //        throw new Exception("Sevkte yapılan tedaviler dolu olmalıdır!");

        //    return sevkTedaviDVOList.ToArray();
        //}


        //public SevkIslemleri.sevkDoktorDVO[] GetSevkDoktorDVOList(string type)
        //{
        //    List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = null;
        //    if (this._InpatientAdmission.InPatientTreatmentClinicApplications != null)
        //    {
        //        sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
        //        foreach (InPatientTreatmentClinicApplication inPtntTrtmntClncApp in this._InpatientAdmission.InPatientTreatmentClinicApplications)
        //        {
        //            if (inPtntTrtmntClncApp != null && inPtntTrtmntClncApp.ResponsibleDoctor != null)
        //            {

        //                SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
        //                // *doktorTescilNo
        //                if (inPtntTrtmntClncApp.ResponsibleDoctor.DiplomaRegisterNo != null)
        //                    sevkDoktorDVO.doktorTescilNo = inPtntTrtmntClncApp.ResponsibleDoctor.DiplomaRegisterNo;
        //                else
        //                    throw new Exception(type + " hastaya tedavi yapan doktorun tescil numarası dolu olmalıdır!");

        //                // *doktorTipi
        //                if (inPtntTrtmntClncApp.ResponsibleDoctor.Title != null )
        //                {
        //                    if (inPtntTrtmntClncApp.ResponsibleDoctor.Title.Value.Equals(UserTitleEnum.DisDoctor) || inPtntTrtmntClncApp.ResponsibleDoctor.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || inPtntTrtmntClncApp.ResponsibleDoctor.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || inPtntTrtmntClncApp.ResponsibleDoctor.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
        //                        sevkDoktorDVO.doktorTipi = "2";
        //                    else
        //                        sevkDoktorDVO.doktorTipi = "1";
        //                }
        //                else
        //                {
        //                    throw new Exception(type + " sevk eden doktorun tipi dolu olmalıdır!");

        //                }

        //                // *bransKodu
        //                if (inPtntTrtmntClncApp.ResponsibleDoctor.ResourceSpecialities != null)
        //                {
        //                    String brans = ResUser.GetAnaUzmanlikBrans(inPtntTrtmntClncApp.ResponsibleDoctor, type);
        //                    if (brans != null)
        //                        sevkDoktorDVO.bransKodu = brans;
        //                }
        //                else
        //                    throw new Exception(type + " sevkli hastaya tedavi yapan doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");

        //                sevkDoktorDVOList.Add(sevkDoktorDVO);
        //            }
        //            else
        //                throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //        }
        //    }
        //    else
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    if (sevkDoktorDVOList.Count <= 0)
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    return sevkDoktorDVOList.ToArray();
        //}

        //public SevkIslemleri.sevkDoktorDVO[] GetSevkMutatDisiDoktorDVOList(string type)
        //{
        //    List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = null;
        //    if (this._InpatientAdmission.InPatientTreatmentClinicApplications != null)
        //    {
        //        sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
        //        foreach (DoctorGrid doctorGrid in _InpatientAdmission.DoctorsGrid)
        //        {
        //            SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
        //            // *doktorTescilNo
        //            if (doctorGrid.ResUser.DiplomaRegisterNo != null)
        //                sevkDoktorDVO.doktorTescilNo = doctorGrid.ResUser.DiplomaRegisterNo;
        //            else
        //                throw new Exception(type + " hastaya tedavi yapan doktorun tescil numarası dolu olmalıdır!");

        //            // *doktorTipi
        //            if (doctorGrid.ResUser.Title != null )
        //            {
        //                if (doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.DisDoctor) || doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || doctorGrid.ResUser.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
        //                    sevkDoktorDVO.doktorTipi = "2";
        //                else
        //                    sevkDoktorDVO.doktorTipi = "1";
        //            }
        //            else
        //            {
        //                throw new Exception(type + " sevk eden doktorun tipi dolu olmalıdır!");

        //            }

        //            // *bransKodu
        //            if (doctorGrid.ResUser.ResourceSpecialities != null)
        //            {
        //                String brans = ResUser.GetAnaUzmanlikBrans(doctorGrid.ResUser, type);
        //                if (brans != null)
        //                    sevkDoktorDVO.bransKodu = brans;
        //            }
        //            else
        //                throw new Exception(type + " sevkli hastaya tedavi yapan doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");

        //            sevkDoktorDVOList.Add(sevkDoktorDVO);
        //        }
        //    }
        //    else
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    if (sevkDoktorDVOList.Count <= 0)
        //        throw new Exception("Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!");

        //    return sevkDoktorDVOList.ToArray();
        //}



        ///*
        // * MEDULA MUTAT DIŞI ARAÇ RAPOR KAYDET METODU
        // * */

        //public bool MutatDisiAracRaporKaydetSync()
        //{

        //    try
        //    {
        //        SevkIslemleri.mutatDisiRaporCevapDVO mutatDisiRaporCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporKaydetSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporDVO());
        //        if (mutatDisiRaporCevapDVO != null)
        //        {
        //            if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucKodu) == false)
        //            {
        //                if (mutatDisiRaporCevapDVO.sonucKodu.Equals("0000"))
        //                {
        //                    InfoBox.Alert("Mutat dışı araç rapor bildirim işlemi başarı ile sonuçlandı. Rapor id: " + mutatDisiRaporCevapDVO.raporId, MessageIconEnum.InformationMessage);
        //                    this._InpatientAdmission.MedulaMutatDisiAracRaporNo = mutatDisiRaporCevapDVO.raporId.ToString();
        //                    return true;
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
        //                        throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :" + mutatDisiRaporCevapDVO.sonucMesaji);
        //                    else
        //                        throw new Exception("Mutat dışı araç rapor bildiriminde hata var.Sonuç mesajı alanı boş.Sonuç Kodu: " + mutatDisiRaporCevapDVO.sonucKodu);
        //                }
        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
        //                    throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :" + mutatDisiRaporCevapDVO.sonucMesaji);
        //                else
        //                    throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılması sırasında hata oluştu! Sonuç Kodu alanı boş!");
        //            }

        //        }
        //        else
        //            throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılamadı.Cevap dönmedi!");

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    //return false;
        //}


        ///*
        // * MEDULA MUTAT DIŞI RAPOR DVO HAZIRLANMASI
        // * */

        //public SevkIslemleri.mutatDisiRaporDVO GetMutatDisiRaporDVO()
        //{

        //    SevkIslemleri.mutatDisiRaporDVO mutatDisiRaporDVO = new SevkIslemleri.mutatDisiRaporDVO();
        //    // *haksahibiTCNO
        //    if (this._InpatientAdmission.Episode != null && this._InpatientAdmission.Episode.Patient != null && this._InpatientAdmission.Episode.Patient.UniqueRefNo != null)
        //        mutatDisiRaporDVO.haksahibiTCNO = Convert.ToInt64(this._InpatientAdmission.Episode.Patient.UniqueRefNo);
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk edilen hasta TC kimlik no alanı dolu olmalıdır!");

        //    // XXXXXX tarafından verilen rapor no
        //    // *raporNo
        //    //            TTObjectContext context= new TTObjectContext(true);
        //    //            InpatientAdmission inpAdd = (InpatientAdmission)context.GetObject(this._InpatientAdmission.ObjectID, typeof(InpatientAdmission).Name);
        //    if (this._InpatientAdmission.MutatDisiAracRaporId.Value != null)
        //        mutatDisiRaporDVO.raporNo = this._InpatientAdmission.MutatDisiAracRaporId.Value.ToString();
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken XXXXXX tarafından üretilen rapor ID gönderilmelidir!");


        //    // *protokolNo
        //    if (this._InpatientAdmission.Episode != null && this._InpatientAdmission.Episode.HospitalProtocolNo != null && this._InpatientAdmission.Episode.HospitalProtocolNo.Value != null)
        //        mutatDisiRaporDVO.protokolNo = this._InpatientAdmission.Episode.HospitalProtocolNo.Value.ToString();
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken protokol numarası alanı dolu olmalıdır!");

        //    // *sevkVasitasi
        //    if (this._InpatientAdmission.MedulaSevkDonusVasitasi != null && this._InpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
        //        mutatDisiRaporDVO.sevkVasitasi = Convert.ToInt32(this._InpatientAdmission.MedulaSevkDonusVasitasi.sevkVasitasiKodu);
        //    else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk vasıtası alanı dolu olmalıdır!");

        //    // raporTarihi
        //    if (this._InpatientAdmission.MutatDisiAracRaporTarihi != null)
        //        mutatDisiRaporDVO.raporTarihi = this._InpatientAdmission.MutatDisiAracRaporTarihi.Value.ToShortDateString().ToString();
        //     else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken rapor tarihi alanı dolu olmalıdır!");

        //    // baslangicTarihi
        //    if (this._InpatientAdmission.MutatDisiAracBaslangicTarihi != null)
        //        mutatDisiRaporDVO.baslangicTarihi = this._InpatientAdmission.MutatDisiAracBaslangicTarihi.Value.ToShortDateString().ToString();
        //     else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken başlangıç tarihi alanı dolu olmalıdır!");

        //    // bitisTarihi
        //    if (this._InpatientAdmission.MutatDisiAracBitisTarihi != null)
        //        mutatDisiRaporDVO.bitisTarihi = this._InpatientAdmission.MutatDisiAracBitisTarihi.Value.ToShortDateString().ToString();
        //     else
        //        throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken bitiş tarihi alanı dolu olmalıdır!");

        //    // refakatciGerekcesi
        //    if (this._InpatientAdmission.MedulaRefakatciGerekcesi != null)
        //        mutatDisiRaporDVO.refakatciGerekcesi = this._InpatientAdmission.MedulaRefakatciGerekcesi;

        //    //Mutat Dışı Araç Rapor Gerekçesi
        //    // mutatDisiGerekcesi
        //    if (this._InpatientAdmission.MutatDisiGerekcesi != null)
        //        mutatDisiRaporDVO.mutatDisiGerekcesi = this._InpatientAdmission.MutatDisiGerekcesi;

        //    // *sevkTani
        //    SevkIslemleri.sevkTaniDVO[] sevkTaniList = GetSevkTaniDVOList("Medulaya mutat dışı araç rapor bildiriminde");
        //    if (sevkTaniList != null)
        //        mutatDisiRaporDVO.sevkTani = sevkTaniList;
        //    else
        //        throw new Exception("Medulaya mutat dışı araç rapor bildiriminde hastaya ait tanı girilmiş olmalıdır!");

        //    // sevkEdenDoktor
        //    SevkIslemleri.sevkDoktorDVO[] sevkDoktorList = GetSevkMutatDisiDoktorDVOList("Medulaya mutat dışı araç rapor bildiriminde");
        //    if (sevkDoktorList != null)
        //        mutatDisiRaporDVO.sevkEdenDoktor = sevkDoktorList;
        //    else
        //        throw new Exception("Medulaya mutat dışı araç rapor bildiriminde sevk eden doktorların bilgileri girilmiş olmalıdır!");

        //    // *kullaniciTesisKodu
        //    mutatDisiRaporDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

        //    return mutatDisiRaporDVO;
        //}
        public void Func()
        {
            var a = 1;
        }
#endregion InpatientAdmissionQuarantineForm_Methods
    }
}