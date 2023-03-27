using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz214_BulasiciHastalikBildirimVeriSeti
    {
        public class SYSSendMessage
        {
            public input input = new input();
        }
        public class input
        {
            public SYSMessage SYSMessage = new SYSMessage();
        }
        public class SYSMessage
        {
            public messageGuid messageGuid = new messageGuid();
            public messageType messageType = new messageType();
            public documentGenerationTime documentGenerationTime = new documentGenerationTime();
            public author author = new author();
            public firmaKodu firmaKodu = new firmaKodu();

            public recordData recordData = new recordData();

            public SYSMessage()
            {
                messageType.code = "214";
                messageType.value = "Bulasici Hastalik Bildirim Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public BULASICI_HASTALIK_BILDIRIM BULASICI_HASTALIK_BILDIRIM = new BULASICI_HASTALIK_BILDIRIM();
 
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class BULASICI_HASTALIK_BILDIRIM
        {
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI();
            public VAKA_TIPI VAKA_TIPI = new VAKA_TIPI();
            public KLINIK_BELIRTILERIN_BASLADIGI_TARIH KLINIK_BELIRTILERIN_BASLADIGI_TARIH = new KLINIK_BELIRTILERIN_BASLADIGI_TARIH();
            [System.Xml.Serialization.XmlElement("TELEFON_BILGISI", Type = typeof(TELEFON_BILGISI))]
            public List<TELEFON_BILGISI> TELEFON_BILGISI;
            public TANI_BILGISI TANI_BILGISI = new TANI_BILGISI();
            public BILDIRIM_KIMLIK_BILGISI BILDIRIM_KIMLIK_BILGISI;
            public MERNIS_ADRESI MERNIS_ADRESI ;
            public BEYAN_ADRESI BEYAN_ADRESI ;
      

        }

        public class BEYAN_ADRESI
        {
            public IL_KODU IL_KODU = new IL_KODU();
            public ILCE_KODU ILCE_KODU = new ILCE_KODU();
            public BUCAK_KODU BUCAK_KODU = new BUCAK_KODU();
            public KOY_KODU KOY_KODU = new KOY_KODU();
            public MAHALLE_KODU MAHALLE_KODU = new MAHALLE_KODU();
            public CSBM_KODU CSBM_KODU = new CSBM_KODU();
            public DIS_KAPI DIS_KAPI = new DIS_KAPI();
            public IC_KAPI IC_KAPI = new IC_KAPI();
        }
        public class MERNIS_ADRESI
        {
            public IL_KODU IL_KODU = new IL_KODU();
            public ILCE_KODU ILCE_KODU = new ILCE_KODU();
            public BUCAK_KODU BUCAK_KODU = new BUCAK_KODU();
            public KOY_KODU KOY_KODU = new KOY_KODU();
            public MAHALLE_KODU MAHALLE_KODU = new MAHALLE_KODU();
            public CSBM_KODU CSBM_KODU = new CSBM_KODU();
            public DIS_KAPI DIS_KAPI = new DIS_KAPI();
            public IC_KAPI IC_KAPI = new IC_KAPI();
        }

        public class TANI_BILGISI
        {
            public TANI_TURU TANI_TURU = new TANI_TURU();
            public ICD10 ICD10 = new ICD10();
        }
        public class TELEFON_BILGISI
        {
            public TELEFON_NUMARASI TELEFON_NUMARASI;
            public TELEFON_TIPI TELEFON_TIPI;
        }
        public class BILDIRIM_KIMLIK_BILGISI
        {
            public HASTA_KIMLIK_NUMARASI HASTA_KIMLIK_NUMARASI = new HASTA_KIMLIK_NUMARASI();
            public AD AD = new AD();
            public SOYAD SOYAD = new SOYAD();
            public DOGUM_TARIHI DOGUM_TARIHI = new DOGUM_TARIHI();
            public CINSIYET CINSIYET = new CINSIYET();
            public UYRUK UYRUK = new UYRUK();
            public ANNE_KIMLIK_NUMARASI ANNE_KIMLIK_NUMARASI = new ANNE_KIMLIK_NUMARASI();
            public DOGUM_SIRASI DOGUM_SIRASI = new DOGUM_SIRASI();
            public YABANCI_HASTA_KIMLIK_NUMARASI YABANCI_HASTA_KIMLIK_NUMARASI = new YABANCI_HASTA_KIMLIK_NUMARASI();
            public PASAPORT_NO PASAPORT_NO = new PASAPORT_NO();
            public KIMLIKSIZ_HASTA_BILGISI KIMLIKSIZ_HASTA_BILGISI = new KIMLIKSIZ_HASTA_BILGISI();
        }
        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //InternalObjectGuid bu objec için BulasiciHastaliklarEA
            TTObjectContext objectContext = new TTObjectContext(true);
            BulasiciHastaliklarEA bulasiciHastalik = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as BulasiciHastaliklarEA;
            if (bulasiciHastalik == null)
                throw new Exception("'214' paketini göndermek için " + InternalObjectId + " ObjectId'li BulasiciHastaliklarEA Objesi bulunamadı");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            Patient patient = bulasiciHastalik.Episode.Patient;

            //BULASICI_HASTALIK_BILDIRIM
            _recordData.BULASICI_HASTALIK_BILDIRIM.PAKETE_AIT_ISLEM_ZAMANI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.PaketeAitIslemZamani.HasValue ? bulasiciHastalik.BulasiciHastalikVeriSeti.PaketeAitIslemZamani.Value.ToString("yyyyMMddHHmm"):string.Empty;
            if (bulasiciHastalik.BulasiciHastalikVeriSeti.SKRSVakaTipi != null)
                _recordData.BULASICI_HASTALIK_BILDIRIM.VAKA_TIPI = new TTObjectClasses.VAKA_TIPI(bulasiciHastalik.BulasiciHastalikVeriSeti.SKRSVakaTipi.KODU, bulasiciHastalik.BulasiciHastalikVeriSeti.SKRSVakaTipi.ADI);
            _recordData.BULASICI_HASTALIK_BILDIRIM.KLINIK_BELIRTILERIN_BASLADIGI_TARIH.value = bulasiciHastalik.BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi.HasValue ? bulasiciHastalik.BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi.Value.ToString("yyyyMMddHHmm") : string.Empty;

            TELEFON_BILGISI telefonBilgisi = new TELEFON_BILGISI();

            if (bulasiciHastalik.BulasiciHastalikVeriSeti.BulasiciHastalikTelefon.Count > 0)
                _recordData.BULASICI_HASTALIK_BILDIRIM.TELEFON_BILGISI = new List<TELEFON_BILGISI>();

            foreach (BulasiciHastalikTelefon phone in bulasiciHastalik.BulasiciHastalikVeriSeti.BulasiciHastalikTelefon)
            {
                telefonBilgisi = new TELEFON_BILGISI();
                if(phone.SKRSTelefonTipi != null)
                telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI(phone.SKRSTelefonTipi.KODU,phone.SKRSTelefonTipi.ADI);
                else
                    telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI("1", "CEP TELEFONU");

                telefonBilgisi.TELEFON_NUMARASI = new TELEFON_NUMARASI();
                telefonBilgisi.TELEFON_NUMARASI.value = phone.TelefonNumarasi == null ? string.Empty : phone.TelefonNumarasi.ToString();

                _recordData.BULASICI_HASTALIK_BILDIRIM.TELEFON_BILGISI.Add(telefonBilgisi);
            }

            BILDIRIM_KIMLIK_BILGISI bildirimKimlikBilgisi = new BILDIRIM_KIMLIK_BILGISI();

            bildirimKimlikBilgisi.HASTA_KIMLIK_NUMARASI.value = patient.UniqueRefNo != null ? patient.UniqueRefNo.ToString() : string.Empty;// Boş olursa karşısı hata verir
            bildirimKimlikBilgisi.AD.value = patient.Name;
            bildirimKimlikBilgisi.SOYAD.value = patient.Surname;
            bildirimKimlikBilgisi.DOGUM_TARIHI.value = patient.BirthDate.HasValue ? patient.BirthDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

            if (patient.Sex != null)
            {
               
                    bildirimKimlikBilgisi.CINSIYET = new CINSIYET(patient.Sex.KODU,patient.Sex.ADI );
            }
            if (patient.Nationality != null)
            {
                bildirimKimlikBilgisi.UYRUK = new UYRUK(patient.Nationality.MernisKodu, patient.Nationality.Adi);
            }
            else// eski hastalarda Nationality yoksa diye
            {
                if (patient.CountryOfBirth != null)
                {
                    var sKRSUlkeKodlari = patient.CountryOfBirth.GetSKRSDefinition();
                    if (sKRSUlkeKodlari != null)
                        bildirimKimlikBilgisi.UYRUK = new UYRUK(((SKRSUlkeKodlari)sKRSUlkeKodlari).Kodu, (((SKRSUlkeKodlari)sKRSUlkeKodlari)).Adi);
                }
            }


            if (patient.Foreign == true || patient.UnIdentified == true)
            {
                bool found = false;
                if (patient.UniqueRefNo != null)// Yabacı Hasta No yoksa
                {
                    bildirimKimlikBilgisi.YABANCI_HASTA_KIMLIK_NUMARASI.value = patient.UniqueRefNo.ToString();
                    found = true;
                }
                if (patient.PassportNo != null)
                {
                    bildirimKimlikBilgisi.PASAPORT_NO.value = patient.PassportNo.ToString();
                    found = true;
                }
                if (!found)
                {
                    if (myTesisSKRSKurumlarDefinition != null)
                        bildirimKimlikBilgisi.KIMLIKSIZ_HASTA_BILGISI.value = myTesisSKRSKurumlarDefinition.KODU + "_" + patient.ID.ToString();
                }
            }

            if (bulasiciHastalik.Episode.IsNewBorn == true) // yeni doğanın adresi annesinden alınır
            {
                bildirimKimlikBilgisi.DOGUM_SIRASI.value = patient.BirthOrder != null ? Convert.ToInt32(patient.BirthOrder.ADI).ToString() : string.Empty;
                var mother = patient.Mother;
                if (mother != null)
                {
                    bildirimKimlikBilgisi.ANNE_KIMLIK_NUMARASI.value = mother.UniqueRefNo != null ? mother.UniqueRefNo.ToString() : string.Empty;
                }
            }

            _recordData.BULASICI_HASTALIK_BILDIRIM.BILDIRIM_KIMLIK_BILGISI = bildirimKimlikBilgisi;


            bool isMainDiagnose = false; //Pakette tek tanı var. Ana tanı mı, ek tanı mı ona bakılıyor.
            BindingList<DiagnosisGrid> subEpisodeDiagnosisList = DiagnosisGrid.GetDiagnosisBySubEpisode_OQ(objectContext, bulasiciHastalik.SubEpisode.ObjectID.ToString());
            if (subEpisodeDiagnosisList.Count > 0)
            {
                foreach (DiagnosisGrid dg in subEpisodeDiagnosisList)
                {
   
                    TerminologyManagerDef skrsDiagnose = dg.Diagnose.GetSKRSDefinition();
                    if (skrsDiagnose != null)
                    {
                        if (((SKRSICD)skrsDiagnose).KODU == bulasiciHastalik.BulasiciHastalikVeriSeti.SKRSICD.KODU)
                        {
                            if (dg.IsMainDiagnose == true)
                                isMainDiagnose = true;
                            break;
                        }
                    }
                }
            }


            if (isMainDiagnose)
                _recordData.BULASICI_HASTALIK_BILDIRIM.TANI_BILGISI.TANI_TURU = new TANI_TURU("1", "ANA TANI");
            else
                _recordData.BULASICI_HASTALIK_BILDIRIM.TANI_BILGISI.TANI_TURU = new TANI_TURU("2", "EK TANI");

            _recordData.BULASICI_HASTALIK_BILDIRIM.TANI_BILGISI.ICD10 = new ICD10(bulasiciHastalik.BulasiciHastalikVeriSeti.SKRSICD.KODU, bulasiciHastalik.BulasiciHastalikVeriSeti.SKRSICD.ADI);




            if (bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Il !=null)
            {
                MERNIS_ADRESI mernisAdresi = new MERNIS_ADRESI();
                mernisAdresi.IL_KODU = new IL_KODU(bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Il.KODU.ToString(), bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Il.ADI);
                mernisAdresi.ILCE_KODU = new ILCE_KODU(bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Ilce.KODU.ToString(), bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Ilce.ADI);

                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Bucak != null)
                //{
                //    mernisAdresi.BUCAK_KODU = new BUCAK_KODU();
                //    mernisAdresi.BUCAK_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Bucak.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Koy != null)
                //{
                //    mernisAdresi.KOY_KODU = new KOY_KODU();
                //    mernisAdresi.KOY_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Koy.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Mahalle != null)
                //{
                //    mernisAdresi.MAHALLE_KODU = new MAHALLE_KODU();
                //    mernisAdresi.MAHALLE_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Mahalle.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_CSBM != null)
                //{
                //    mernisAdresi.CSBM_KODU = new CSBM_KODU();
                //    mernisAdresi.CSBM_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_CSBM.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoIkamet != null)
                //{
                //    mernisAdresi.DIS_KAPI = new DIS_KAPI();
                //    mernisAdresi.DIS_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoIkamet.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoIkamet != null)
                //{
                //    mernisAdresi.IC_KAPI = new IC_KAPI();
                //    mernisAdresi.IC_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoIkamet.ToString();
                //}

                mernisAdresi.BUCAK_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Bucak == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Bucak.KODU.ToString();
                mernisAdresi.KOY_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Koy == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Koy.KODU.ToString();
                mernisAdresi.MAHALLE_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Mahalle == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_Mahalle.KODU.ToString();
                mernisAdresi.CSBM_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_CSBM == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Ikamet_CSBM.KODU.ToString();
                mernisAdresi.DIS_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoIkamet == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoIkamet.ToString();
                mernisAdresi.IC_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoIkamet == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoIkamet.ToString();

                _recordData.BULASICI_HASTALIK_BILDIRIM.MERNIS_ADRESI = new MERNIS_ADRESI();
                _recordData.BULASICI_HASTALIK_BILDIRIM.MERNIS_ADRESI = mernisAdresi;
            }


            if (bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Il != null)
            {
                BEYAN_ADRESI beyanAdresi = new BEYAN_ADRESI();
                beyanAdresi.IL_KODU = new IL_KODU(bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Il.KODU.ToString(), bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Il.ADI);
                beyanAdresi.ILCE_KODU = new ILCE_KODU(bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Ilce.KODU.ToString(), bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Ilce.ADI);

                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Bucak != null)
                //{
                //    beyanAdresi.BUCAK_KODU = new BUCAK_KODU();
                //    beyanAdresi.BUCAK_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Bucak.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Koy != null)
                //{
                //    beyanAdresi.KOY_KODU = new KOY_KODU();
                //    beyanAdresi.KOY_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Koy.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Mahalle != null)
                //{
                //    beyanAdresi.MAHALLE_KODU = new MAHALLE_KODU();
                //    beyanAdresi.MAHALLE_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Mahalle.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_CSBM != null)
                //{
                //    beyanAdresi.CSBM_KODU = new CSBM_KODU();
                //    beyanAdresi.CSBM_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_CSBM.KODU.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoBeyan != null)
                //{
                //    beyanAdresi.DIS_KAPI = new DIS_KAPI();
                //    beyanAdresi.DIS_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoBeyan.ToString();
                //}
                //if (bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoBeyan != null)
                //{
                //    beyanAdresi.IC_KAPI = new IC_KAPI();
                //    beyanAdresi.IC_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoBeyan.ToString();
                //}

                beyanAdresi.BUCAK_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Bucak == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Bucak.KODU.ToString();
                beyanAdresi.KOY_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Koy == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Koy.KODU.ToString();
                beyanAdresi.MAHALLE_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Mahalle == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_Mahalle.KODU.ToString();
                beyanAdresi.CSBM_KODU.value = bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_CSBM == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.Beyan_CSBM.KODU.ToString();
                beyanAdresi.DIS_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoBeyan == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.DisKapiNoBeyan.ToString();
                beyanAdresi.IC_KAPI.value = bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoBeyan == null ? string.Empty : bulasiciHastalik.BulasiciHastalikVeriSeti.IcKapiNoBeyan.ToString();

                _recordData.BULASICI_HASTALIK_BILDIRIM.BEYAN_ADRESI = new BEYAN_ADRESI();
                _recordData.BULASICI_HASTALIK_BILDIRIM.BEYAN_ADRESI = beyanAdresi;
            }
           

            if (bulasiciHastalik.BulasiciHastalikVeriSeti.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = bulasiciHastalik.BulasiciHastalikVeriSeti.SubEpisode.SYSTakipNo;

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
