
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Hastaya Ait Diyabet Takip Formları
    /// </summary>
    public  partial class DiyabetTakip : EpisodeAction
    {
#region Methods
        // Diabet Takip Formu Kaydet

       public void MedulaDiabetTakipFormuKaydet()
        {

            try
            {
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());

                TakipFormuIslemleri.takipFormuKaydetCevapDVO takipFormuKaydetCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuKaydet(siteID, GetTakipFormuKaydetGirisDVO());
                if (takipFormuKaydetCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(takipFormuKaydetCevapDVO.sonucKodu) == false)
                    {
                        if (takipFormuKaydetCevapDVO.sonucKodu.Equals("0000"))
                        {
                            if (takipFormuKaydetCevapDVO.diabetTakipFormu != null && !string.IsNullOrEmpty(takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo))
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage("Diabet Takip Formu kaydetme işlemi başarılı şekilde yapıldı. Takip Form Numarası: " + takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo);
                                DiabetesMellitusPursuit.takipFormuNo = takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(takipFormuKaydetCevapDVO.sonucMesaji) == false)
                                throw new Exception(TTUtils.CultureService.GetText("M25480", "Diabet Takip Formu Medulaya kaydedilmesi işleminde hata var. Sonuç Mesajı :")+ takipFormuKaydetCevapDVO.sonucMesaji);
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M25479", "Diabet Takip Formu Medulaya kaydedilmesi işleminde hata var."));
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(takipFormuKaydetCevapDVO.sonucMesaji) == false)
                            throw new Exception("Diabet Takip Formunun Medulaya kaydedilmesi işleminde hata var: " + takipFormuKaydetCevapDVO.sonucMesaji);
                        else
                            throw new Exception(TTUtils.CultureService.GetText("M25483", "Diabet Takip Formunun Medulaya kaydedilmesi sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!"));
                    }

                }
                else
                    throw new Exception(TTUtils.CultureService.GetText("M25481", "Diabet Takip Formunun Medulaya kaydedilemedi!"));

            }
            catch (Exception e)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(e.Message);
            }
        }

        /*
         * MEDULA Takip Formu Kaydet Giriş DVO Hazırlanması
         * */

        public TakipFormuIslemleri.takipFormuKaydetGirisDVO GetTakipFormuKaydetGirisDVO()
        {

            TakipFormuIslemleri.takipFormuKaydetGirisDVO takipFormuKaydetGirisDVO = new TakipFormuIslemleri.takipFormuKaydetGirisDVO();

            TakipFormuIslemleri.diabetTakipFormuKayitDVO diabetTakipFormuKayitDVO = new TakipFormuIslemleri.diabetTakipFormuKayitDVO();


            //Hastanın Bilgileri
            // TC Kimlik No
            if (Episode.Patient != null && Episode.Patient.UniqueRefNo != null)
                diabetTakipFormuKayitDVO.tcKimlikNo = Episode.Patient.UniqueRefNo.ToString();
            else
                throw new Exception(TTUtils.CultureService.GetText("M25458", "Diabet Takip Formu Kaydı için hasta kimlik numarası alanı dolu olmalıdır!"));

            // Ad
            if (Episode.Patient != null && !string.IsNullOrEmpty(Episode.Patient.Name))
                diabetTakipFormuKayitDVO.ad = Episode.Patient.Name;
            else
                throw new Exception(TTUtils.CultureService.GetText("M25460", "Diabet Takip Formu Kaydı için hastanın adı dolu olmalıdır!"));

            // Soyad
            if (Episode.Patient != null && !string.IsNullOrEmpty(Episode.Patient.Surname))
                diabetTakipFormuKayitDVO.soyad = Episode.Patient.Surname;
            else
                throw new Exception(TTUtils.CultureService.GetText("M25463", "Diabet Takip Formu Kaydı için hastanın soyadı dolu olmalıdır!"));

            // Cep Telefonu
            String mobilePhone = "";
      
            if (Episode.Patient != null && !string.IsNullOrEmpty(Episode.Patient.PatientAddress.MobilePhone))
            {

                mobilePhone = Episode.Patient.PatientAddress.MobilePhone.Replace('(', ' ');
                mobilePhone = mobilePhone.Replace(')', ' ');
                mobilePhone = mobilePhone.Remove(4, 1);
                diabetTakipFormuKayitDVO.cepTel = mobilePhone.Trim();
            }
            else if (Episode.Patient != null && !string.IsNullOrEmpty(Episode.Patient.PatientAddress.HomePhone))
            {
                mobilePhone = Episode.Patient.PatientAddress.HomePhone.Replace('(', ' ');
                mobilePhone = mobilePhone.Replace(')', ' ');
                mobilePhone = mobilePhone.Remove(4, 1);
                diabetTakipFormuKayitDVO.cepTel = mobilePhone.Trim();
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25461", "Diabet Takip Formu Kaydı için hastanın cep telefonu bilgisi olmalıdır!"));

            // protokol No
            if (DiabetesMellitusPursuit != null && !string.IsNullOrEmpty(DiabetesMellitusPursuit.protokolNo))
                diabetTakipFormuKayitDVO.protokolNo = DiabetesMellitusPursuit.protokolNo;
            else
                throw new Exception(TTUtils.CultureService.GetText("M25473", "Diabet Takip Formu Kaydı için protokol numarası bilgisi olmalıdır!"));

            // vizit tarihi
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.vizitTarihi != null && DiabetesMellitusPursuit.vizitTarihi.Value != null)
                diabetTakipFormuKayitDVO.vizitTarihi = DiabetesMellitusPursuit.vizitTarihi.Value.ToShortDateString();
            else
                throw new Exception(TTUtils.CultureService.GetText("M25477", "Diabet Takip Formu Kaydı için vizit tarihi bilgisi olmalıdır!"));

            // sağlık tesis kodu
            diabetTakipFormuKayitDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            // Cinsiyet
            //if (this.Episode.Patient != null && this.Episode.Patient.Sex != null && this.Episode.Patient.Sex.Value != null)
            if (Episode.Patient != null && Episode.Patient.Sex != null )
            {
                //if (this.Episode.Patient.Sex.Value == SexEnum.Female)
                //    diabetTakipFormuKayitDVO.cinsiyet = "K";
                //else if (this.Episode.Patient.Sex.Value == SexEnum.Male)
                //    diabetTakipFormuKayitDVO.cinsiyet = "E";
                //else
                //    throw new Exception("Diabet Takip Formu Kaydı için hastanın cinsiyet bilgisi  belirlenmiş olmalıdır!");
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25462", "Diabet Takip Formu Kaydı için hastanın cinsiyet bilgisi dolu olmalıdır!"));


            // ikamet Türü
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.ikametTuru != null && this.DiabetesMellitusPursuit.ikametTuru.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.ikametTuru != null)
                diabetTakipFormuKayitDVO.ikametTuru = DiabetesMellitusPursuit.ikametTuru.GetHashCode();  //TODO:NİDA  BU ve aşağıdaki GetHashCode ler niye var anlamadım. 
            else
                throw new Exception(TTUtils.CultureService.GetText("M25465", "Diabet Takip Formu Kaydı için ikamet türü bilgisi dolu olmalıdır!"));

            // TODO Doktor Bilgileri
            diabetTakipFormuKayitDVO.doktorBilgileri = getTakipFormuDoktorBilgisiDVOList();

            // Tanı
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.HastaTanisi != null && DiabetesMellitusPursuit.HastaTanisi.Code != null)
                diabetTakipFormuKayitDVO.taniKodu = DiabetesMellitusPursuit.HastaTanisi.Code;
            else
                throw new Exception(TTUtils.CultureService.GetText("M25475", "Diabet Takip Formu Kaydı için tanı bilgisi dolu olmalıdır!"));

            // Tanı Tarihi
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.taniTarihi != null && DiabetesMellitusPursuit.taniTarihi.Value != null)
                diabetTakipFormuKayitDVO.taniTarihi = DiabetesMellitusPursuit.taniTarihi.Value.ToShortDateString();
            else
                throw new Exception(TTUtils.CultureService.GetText("M25464", "Diabet Takip Formu Kaydı için hastanın tanıyı aldığı ilk tarih bilgisi dolu olmalıdır!"));

            // TODO Diabet Eğitimi
            diabetTakipFormuKayitDVO.diabetEgitimi = getTakipFormuDiabetEgitimiDVO();

            //Tıbbı Beslenme Tedavisi
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.tibbiBeslenmeTedavisi != null && this.DiabetesMellitusPursuit.tibbiBeslenmeTedavisi.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.tibbiBeslenmeTedavisi != null)
                diabetTakipFormuKayitDVO.tibbiBeslenmeTedavisi = Convert.ToInt32(DiabetesMellitusPursuit.tibbiBeslenmeTedavisi.GetHashCode().ToString());
            else
                throw new Exception(TTUtils.CultureService.GetText("M25476", "Diabet Takip Formu Kaydı için tıbbi beslenme tedavisi bilgisi dolu olmalıdır!"));

            //Egzersiz
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.egzersiz != null && this.DiabetesMellitusPursuit.egzersiz.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.egzersiz != null)
                diabetTakipFormuKayitDVO.egzersiz = Convert.ToInt32(DiabetesMellitusPursuit.egzersiz.GetHashCode().ToString());
            else
                throw new Exception(TTUtils.CultureService.GetText("M25443", "Diabet Takip Formu Kaydı için egzersiz bilgisi dolu olmalıdır!"));

            //TODO Hastalıklar Zorunlu değil
            diabetTakipFormuKayitDVO.hastaliklar = getTakipFormuHastalikDVOList();

            //Başvuru Nedeni
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.basvuruNedeni != null && this.DiabetesMellitusPursuit.basvuruNedeni.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.basvuruNedeni != null )
                diabetTakipFormuKayitDVO.basvuruNedeni = Convert.ToInt32(DiabetesMellitusPursuit.basvuruNedeni.GetHashCode().ToString());
            else
                throw new Exception(TTUtils.CultureService.GetText("M25439", "Diabet Takip Formu Kaydı için başvuru nedeni bilgisi dolu olmalıdır!"));

            //TODO ALışkanlıklar zorunlu değil
            diabetTakipFormuKayitDVO.aliskanliklar = getTakipFormuAliskanlikDVOList();

            // Glukometre
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.glukoMetre != null && this.DiabetesMellitusPursuit.glukoMetre.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.glukoMetre != null )
                diabetTakipFormuKayitDVO.glukoMetre = getMedulaCode(DiabetesMellitusPursuit.glukoMetre.Value);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25456", "Diabet Takip Formu Kaydı için gluko metre bilgisi dolu olmalıdır!"));

            //Kan Şekeri takip sayısı
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.kanSekeriTakipSayisi != null)
                diabetTakipFormuKayitDVO.kanSekeriTakipSayisi = Convert.ToInt32(DiabetesMellitusPursuit.kanSekeriTakipSayisi);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25468", "Diabet Takip Formu Kaydı için Kan Şekeri takip sayısı bilgisi dolu olmalıdır!"));

            //TODO Kullanılan İlaçlar zorunlu değil
            diabetTakipFormuKayitDVO.kullanilanIlaclar = getTakipFormuKullanilanIlacDVOList();

            //Sistolik Kan Basıncı zorunlu değil
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.sistolikKanBasinci != null)
                diabetTakipFormuKayitDVO.sistolikKanBasinci = Convert.ToInt32(DiabetesMellitusPursuit.sistolikKanBasinci);

            //Diyastolik Kan Basıncı zorunlu değil
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.diyastolikKanBasinci != null)
                diabetTakipFormuKayitDVO.diyastolikKanBasinci = Convert.ToInt32(DiabetesMellitusPursuit.diyastolikKanBasinci);

            //Boy
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.boy != null)
                diabetTakipFormuKayitDVO.boy = Convert.ToDouble(DiabetesMellitusPursuit.boy);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25440", "Diabet Takip Formu Kaydı için boy bilgisi dolu olmalıdır!"));

            //Kilo
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.kilo != null)
                diabetTakipFormuKayitDVO.kilo = Convert.ToDouble(DiabetesMellitusPursuit.kilo);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25469", "Diabet Takip Formu Kaydı için Kilo bilgisi dolu olmalıdır!"));

            //VKİ
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.vki != null)
                diabetTakipFormuKayitDVO.vki =Convert.ToDouble( DiabetesMellitusPursuit.vki);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25478", "Diabet Takip Formu Kaydı için VKİ bilgisi dolu olmalıdır!"));

            // APG
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.apg != null)
                diabetTakipFormuKayitDVO.apg = Convert.ToDouble(DiabetesMellitusPursuit.apg);
            else
                diabetTakipFormuKayitDVO.apg = Convert.ToDouble("0");

            // TPG
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.tpg != null)
                diabetTakipFormuKayitDVO.tpg = Convert.ToDouble(DiabetesMellitusPursuit.tpg);
            else
                diabetTakipFormuKayitDVO.tpg = Convert.ToDouble("0");

            //HbA1c
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.hbA1c != null)
                diabetTakipFormuKayitDVO.hbA1c = Convert.ToDouble(DiabetesMellitusPursuit.hbA1c);
            else
                diabetTakipFormuKayitDVO.hbA1c = Convert.ToDouble("0");

            //Kreatinin
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.kreatinin != null)
                diabetTakipFormuKayitDVO.kreatinin = Convert.ToDouble(DiabetesMellitusPursuit.kreatinin);
            else
                diabetTakipFormuKayitDVO.kreatinin = Convert.ToDouble("0");

            //Trigliserid
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.trigliserid != null)
                diabetTakipFormuKayitDVO.trigliserid = Convert.ToDouble(DiabetesMellitusPursuit.trigliserid);
            else
                diabetTakipFormuKayitDVO.trigliserid = Convert.ToDouble("0");

            //LDL-Kol
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.ldlKol != null)
                diabetTakipFormuKayitDVO.ldlKol = Convert.ToDouble(DiabetesMellitusPursuit.ldlKol);
            else
                diabetTakipFormuKayitDVO.ldlKol = Convert.ToDouble("0");

            //HDL-Kol
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.hdlKol != null)
                diabetTakipFormuKayitDVO.hdlKol = Convert.ToDouble(DiabetesMellitusPursuit.hdlKol);
            else
                diabetTakipFormuKayitDVO.hdlKol = Convert.ToDouble("0");

            //ALT
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.alt != null)
                diabetTakipFormuKayitDVO.alt = Convert.ToDouble(DiabetesMellitusPursuit.alt);
            else
                diabetTakipFormuKayitDVO.alt = Convert.ToDouble("0");

            //AntiGAD
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.antiGAD != null && this.DiabetesMellitusPursuit.antiGAD.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.antiGAD != null )
            {
                if (DiabetesMellitusPursuit.antiGAD.Value == AntiGADEnum.B)
                    diabetTakipFormuKayitDVO.antiGAD = "B";
                else if (DiabetesMellitusPursuit.antiGAD.Value == AntiGADEnum.N)
                    diabetTakipFormuKayitDVO.antiGAD = "N";
                else if (DiabetesMellitusPursuit.antiGAD.Value == AntiGADEnum.P)
                    diabetTakipFormuKayitDVO.antiGAD = "P";
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25437", "Diabet Takip Formu Kaydı için antiGAD bilgisi dolu olmalıdır!"));

            //EKG
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.ekg != null && this.DiabetesMellitusPursuit.ekg.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.ekg != null )
                diabetTakipFormuKayitDVO.ekg = Convert.ToInt32(DiabetesMellitusPursuit.ekg.GetHashCode().ToString());
            else
                throw new Exception(TTUtils.CultureService.GetText("M25444", "Diabet Takip Formu Kaydı için EKG bilgisi dolu olmalıdır!"));

            //Mikroalbuminüri
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.mikroalbuminuri != null && this.DiabetesMellitusPursuit.mikroalbuminuri.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.mikroalbuminuri != null )
                diabetTakipFormuKayitDVO.mikroalbuminuri = getMedulaCode(DiabetesMellitusPursuit.mikroalbuminuri.Value);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25470", "Diabet Takip Formu Kaydı için mikroalbuminuri bilgisi dolu olmalıdır!"));

            //gozMuayenesi
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.gozMuayenesi != null && this.DiabetesMellitusPursuit.gozMuayenesi.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.gozMuayenesi != null )
                diabetTakipFormuKayitDVO.gozMuayenesi = Convert.ToInt32(DiabetesMellitusPursuit.gozMuayenesi.GetHashCode().ToString());
            else
                throw new Exception(TTUtils.CultureService.GetText("M25457", "Diabet Takip Formu Kaydı için göz muayene bilgisi dolu olmalıdır!"));

            //Periferik Sensoryal Nöropati
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.periferikSensoryal != null && this.DiabetesMellitusPursuit.periferikSensoryal.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.periferikSensoryal != null )
                diabetTakipFormuKayitDVO.periferikSensoryal = getMedulaCode(DiabetesMellitusPursuit.periferikSensoryal.Value);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25472", "Diabet Takip Formu Kaydı için Periferik Sensoryal Nöropati bilgisi dolu olmalıdır!"));

            //Koroner Arter H zorunlu değil
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.koronerArterH != null && this.DiabetesMellitusPursuit.koronerArterH.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.koronerArterH != null )
                diabetTakipFormuKayitDVO.koronerArterH = getMedulaCode(DiabetesMellitusPursuit.koronerArterH.Value);


            //Serebrovasküler H
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.serebrovaskulerH != null && this.DiabetesMellitusPursuit.serebrovaskulerH.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.serebrovaskulerH != null )
                diabetTakipFormuKayitDVO.serebrovaskulerH = getMedulaCode(DiabetesMellitusPursuit.serebrovaskulerH.Value);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25474", "Diabet Takip Formu Kaydı için Serebrovasküler H bilgisi dolu olmalıdır!"));

            //Ayak Muayenesi
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.ayakMuayenesi != null && this.DiabetesMellitusPursuit.ayakMuayenesi.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.ayakMuayenesi != null )
            {
                if (DiabetesMellitusPursuit.ayakMuayenesi.Value == AyakMuayenesiEnum.B)
                    diabetTakipFormuKayitDVO.ayakMuayenesi = "B";
                else if (DiabetesMellitusPursuit.ayakMuayenesi.Value == AyakMuayenesiEnum.V)
                    diabetTakipFormuKayitDVO.ayakMuayenesi = "V";
                else if (DiabetesMellitusPursuit.ayakMuayenesi.Value == AyakMuayenesiEnum.Y)
                    diabetTakipFormuKayitDVO.ayakMuayenesi = "Y";
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25438", "Diabet Takip Formu Kaydı için Ayak Muayenesi bilgisi dolu olmalıdır!"));

            //Akut komplikasyonu
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.akutKomplikasyon != null && this.DiabetesMellitusPursuit.akutKomplikasyon.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.akutKomplikasyon != null )
                diabetTakipFormuKayitDVO.akutKomplikasyon = Convert.ToInt32(DiabetesMellitusPursuit.akutKomplikasyon.GetHashCode().ToString());
            else
                throw new Exception(TTUtils.CultureService.GetText("M25436", "Diabet Takip Formu Kaydı için Akut komplikasyonu bilgisi dolu olmalıdır!"));


            //Hasta Yatış Gün
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.yatisGun != null)
                diabetTakipFormuKayitDVO.yatisGun = Convert.ToInt32(DiabetesMellitusPursuit.yatisGun);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25459", "Diabet Takip Formu Kaydı için Hasta Yatış Gün bilgisi dolu olmalıdır!"));

            //İnsulinPompasi
            //if (this.DiabetesMellitusPursuit != null && this.DiabetesMellitusPursuit.insulinPompasi != null && this.DiabetesMellitusPursuit.insulinPompasi.Value != null)
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.insulinPompasi != null )
                diabetTakipFormuKayitDVO.insulinPompasi = getMedulaCode(DiabetesMellitusPursuit.insulinPompasi.Value);
            else
                throw new Exception(TTUtils.CultureService.GetText("M25467", "Diabet Takip Formu Kaydı için insülin pompasının var olup olmadığı bilgisi dolu olmalıdır!"));


            //insulinPompasiVerTarihi
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.insulinPompasiVerTarihi != null && DiabetesMellitusPursuit.insulinPompasiVerTarihi.Value != null)
                diabetTakipFormuKayitDVO.insulinPompasiVerTarihi = DiabetesMellitusPursuit.insulinPompasiVerTarihi.Value.ToShortDateString();
            else
            {
                if (diabetTakipFormuKayitDVO.insulinPompasi == "V")
                    throw new Exception(TTUtils.CultureService.GetText("M25466", "Diabet Takip Formu Kaydı için insülin pompası verilmiş ise insülin Pompası Veriliş tarihi bilgisi dolu olmalıdır!"));
                diabetTakipFormuKayitDVO.insulinPompasiVerTarihi = "";
            }
            //insulinPompasiDegTarihi
            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.insulinPompasiDegTarihi != null && DiabetesMellitusPursuit.insulinPompasiDegTarihi.Value != null)
                diabetTakipFormuKayitDVO.insulinPompasiDegTarihi = DiabetesMellitusPursuit.insulinPompasiDegTarihi.Value.ToShortDateString();
            else
            {
                if (diabetTakipFormuKayitDVO.insulinPompasi == "V")
                    throw new Exception(TTUtils.CultureService.GetText("M25471", "Diabet Takip Formu Kaydı için nsülin pompası verilmiş ise insülin Pompası Değiştirme tarihi bilgisi dolu olmalıdır!"));
                diabetTakipFormuKayitDVO.insulinPompasiDegTarihi = "";
            }
            takipFormuKaydetGirisDVO.diabetTakipFormu = diabetTakipFormuKayitDVO;

            // kullanıcı tesis kodu
            takipFormuKaydetGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            return takipFormuKaydetGirisDVO;
        }

        public String getMedulaCode(VarYokEnum varYokEnum)
        {
            if (varYokEnum == VarYokEnum.B)
                return "B";
            else if (varYokEnum == VarYokEnum.V)
                return "V";
            else if (varYokEnum == VarYokEnum.Y)
                return "Y";
            else
                return "";
        }

        public TakipFormuIslemleri.takipFormuDoktorBilgisiDVO[] getTakipFormuDoktorBilgisiDVOList()
        {
            List<TakipFormuIslemleri.takipFormuDoktorBilgisiDVO> doktorBilgisiDVOList = new List<TakipFormuIslemleri.takipFormuDoktorBilgisiDVO>();

            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor.Count > 0)
            {
                foreach (DiabetesMellitusPursuitDoctor doctor in DiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor)
                {
                    TakipFormuIslemleri.takipFormuDoktorBilgisiDVO doktorBilgisi = new TakipFormuIslemleri.takipFormuDoktorBilgisiDVO();
                    if (doctor.Doktor != null && !string.IsNullOrEmpty(doctor.Doktor.DiplomaRegisterNo))
                        doktorBilgisi.drTescilNo = doctor.Doktor.DiplomaRegisterNo;
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25450", "Diabet Takip Formu Kaydı için girilen doktorun dr tescil no alanı dolu olmalıdır!"));
                    if (doctor.BransKodu != null && doctor.BransKodu.Code != null)
                        doktorBilgisi.drBransKodu = doctor.BransKodu.Code;
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25449", "Diabet Takip Formu Kaydı için girilen doktorun dr branş kodu alanı dolu olmalıdır!"));

                    //if (doctor.dmEgitimiAlmisMi != null && doctor.dmEgitimiAlmisMi.Value != null)
                    if (doctor.dmEgitimiAlmisMi != null)
                    {
                        if (doctor.dmEgitimiAlmisMi.Value == EvetHayirDurumEnum.E)
                            doktorBilgisi.dmEgitimiAlmisMi = "E";
                        else
                            doktorBilgisi.dmEgitimiAlmisMi = "H";
                    }
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25448", "Diabet Takip Formu Kaydı için girilen doktorun diabet eğitimi alıp/almamış olma durumu dolu olmalıdır!"));
                    doktorBilgisiDVOList.Add(doktorBilgisi);
                }

            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25442", "Diabet Takip Formu Kaydı için doktor bilgileri gönderimi zorunludur."));
            return doktorBilgisiDVOList.ToArray();
        }


        public TakipFormuIslemleri.takipFormuHastalikDVO[] getTakipFormuHastalikDVOList()
        {
            List<TakipFormuIslemleri.takipFormuHastalikDVO> hastalikDVOList = new List<TakipFormuIslemleri.takipFormuHastalikDVO>();

            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitDisease != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitDisease.Count > 0)
            {
                foreach (DiabetesMellitusPursuitDisease disease in DiabetesMellitusPursuit.DiabetesMellitusPursuitDisease)
                {
                    TakipFormuIslemleri.takipFormuHastalikDVO hastalik = new TakipFormuIslemleri.takipFormuHastalikDVO();
                    //if (disease.hastalikKodu != null && disease.hastalikKodu.Value != null)
                    if (disease.hastalikKodu != null )
                    {
                        hastalik.hastalikKodu = Convert.ToInt32(disease.hastalikKodu.GetHashCode().ToString());
                        if (disease.hastalikKodu.Value == HastalikKoduEnum.Diger)
                        {
                            if (disease.digerHastalikTaniKodu != null)
                                hastalik.digerHastalikTaniKodu = disease.digerHastalikTaniKodu;
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M25451", "Diabet Takip Formu Kaydı için girilen hastalığın kodu diğer seçildiğinden diğer hastalık kodu alanı dolu olmalıdır!"));
                        }
                    }
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25452", "Diabet Takip Formu Kaydı için girilen hastalığın kodu dolu olmalıdır!"));

                    hastalikDVOList.Add(hastalik);
                }
            }
            return hastalikDVOList.ToArray();
        }

        public TakipFormuIslemleri.takipFormuDiabetEgitimiDVO getTakipFormuDiabetEgitimiDVO()
        {

            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction.Count > 0)
            {
                foreach (DiabetesMellitusPursuitInstruction instruction in DiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction)
                {
                    TakipFormuIslemleri.takipFormuDiabetEgitimiDVO diabetEgitimi = new TakipFormuIslemleri.takipFormuDiabetEgitimiDVO();
                    if (instruction.bireyselEgitimSayisi != null)
                        diabetEgitimi.bireyselEgitimSayisi = Convert.ToInt32(instruction.bireyselEgitimSayisi);
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25446", "Diabet Takip Formu Kaydı için girilen diabet eğitiminin bireysel eğitim sayısı bilgisi dolu olmalıdır!"));
                    if (instruction.grupEgitimiSayisi != null)
                        diabetEgitimi.grupEgitimiSayisi = Convert.ToInt32(instruction.grupEgitimiSayisi);
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25447", "Diabet Takip Formu Kaydı için girilen diabet eğitiminin grup eğitimi sayısı bilgisi dolu olmalıdır!"));

                    //if (instruction.dmEgitimiAlmisMi != null && instruction.dmEgitimiAlmisMi.Value != null)
                    if (instruction.dmEgitimiAlmisMi != null )
                    {
                        if (instruction.dmEgitimiAlmisMi.Value == EvetHayirDurumEnum.E)
                            diabetEgitimi.dmEgitimiAlmisMi = "E";
                        else
                            diabetEgitimi.dmEgitimiAlmisMi = "H";
                    }
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25445", "Diabet Takip Formu Kaydı için girilen diabet eğitim bilgilerindeki diabet eğitimi alıp/almamış olma durumu dolu olmalıdır!"));
                    return diabetEgitimi;
                }
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25441", "Diabet Takip Formu Kaydı için diyabet eğitim bilgileri zorunludur."));
            return null;
        }

        public TakipFormuIslemleri.takipFormuAliskanlikDVO[] getTakipFormuAliskanlikDVOList()
        {
            List<TakipFormuIslemleri.takipFormuAliskanlikDVO> aliskanlikDVOList = new List<TakipFormuIslemleri.takipFormuAliskanlikDVO>();

            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitHabit != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitHabit.Count > 0)
            {
                foreach (DiabetesMellitusPursuitHabit habit in DiabetesMellitusPursuit.DiabetesMellitusPursuitHabit)
                {
                    TakipFormuIslemleri.takipFormuAliskanlikDVO aliskanlik = new TakipFormuIslemleri.takipFormuAliskanlikDVO();
                    //if (habit.aliskanlik != null && habit.aliskanlik.Value != null)
                    if (habit.aliskanlik != null)
                        aliskanlik.aliskanlik = Convert.ToInt32(habit.aliskanlik.GetHashCode().ToString());
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25453", "Diabet Takip Formu Kaydı için girilen hastaya ait alışkanlık bilgilerinden alışkanlık bilgisi dolu olmalıdır!"));
                    aliskanlikDVOList.Add(aliskanlik);
                }
            }
            return aliskanlikDVOList.ToArray();
        }

        public TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO[] getTakipFormuKullanilanIlacDVOList()
        {
            List<TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO> kullanilanIlacDVOList = new List<TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO>();

            if (DiabetesMellitusPursuit != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug != null && DiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug.Count > 0)
            {
                foreach (DiabetesMellitusPursuitUsedDrug usedDrug in DiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug)
                {
                    TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO kullanilanIlac = new TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO();

                    if (usedDrug.barkod != null)
                        kullanilanIlac.barkod = usedDrug.barkod;
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25454", "Diabet Takip Formu Kaydı için girilen kullanılan ilac bilgilerinden barkod bilgisi dolu olmalıdır!"));
                    if (usedDrug.gunlukDoz != null)
                        kullanilanIlac.gunlukDoz = usedDrug.gunlukDoz;
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25455", "Diabet Takip Formu Kaydı için girilen kullanılan ilac bilgilerinden günlük doz bilgisi dolu olmalıdır!"));
                    kullanilanIlacDVOList.Add(kullanilanIlac);
                }
            }
            return kullanilanIlacDVOList.ToArray();
        }
        
#endregion Methods

    }
}