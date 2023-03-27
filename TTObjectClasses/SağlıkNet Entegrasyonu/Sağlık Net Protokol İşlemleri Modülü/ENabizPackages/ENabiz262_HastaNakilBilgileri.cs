using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz262_HastaNakilBilgileri
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
                messageType.code = "262";
                messageType.value = TTUtils.CultureService.GetText("M25795", "Hasta Nakil Bilgileri");
            }

        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public ERISKIN_HASTA_NAKIL_BILGILERI ERISKIN_HASTA_NAKIL_BILGILERI = new ERISKIN_HASTA_NAKIL_BILGILERI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class ERISKIN_HASTA_NAKIL_BILGILERI
        {
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI(); //Zorunlu
            public HASTA_HUKUMLU_MU HASTA_HUKUMLU_MU;
            public HASTA_ADLI_VAKA_MI HASTA_ADLI_VAKA_MI;
            public KAN_GRUBU KAN_GRUBU;
            public NAKLIN_TALEP_EDILDIGI_ZAMAN NAKLIN_TALEP_EDILDIGI_ZAMAN = new NAKLIN_TALEP_EDILDIGI_ZAMAN(); //Zorunlu
            public NAKIL_TALEP_EDEN_KURUM NAKIL_TALEP_EDEN_KURUM = new NAKIL_TALEP_EDEN_KURUM();//Zorunlu
            public NAKIL_TALEP_EDEN_KURUM_TELEFON NAKIL_TALEP_EDEN_KURUM_TELEFON = new NAKIL_TALEP_EDEN_KURUM_TELEFON();//Zorunlu
            public NAKIL_TALEP_EDEN_KLINIK NAKIL_TALEP_EDEN_KLINIK = new NAKIL_TALEP_EDEN_KLINIK(); //Zorunlu
            public HASTANIN_BULUNDUGU_KLINIK HASTANIN_BULUNDUGU_KLINIK = new HASTANIN_BULUNDUGU_KLINIK();//Zorunlu
            public NAKIL_EDILMEK_ISTENDIGI_KLINIK NAKIL_EDILMEK_ISTENDIGI_KLINIK = new NAKIL_EDILMEK_ISTENDIGI_KLINIK();//Zorunlu
            public HASTA_NAKIL_TIPI HASTA_NAKIL_TIPI = new HASTA_NAKIL_TIPI();//Zorunlu
            public GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI = new GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI();//Zorunlu
            public HASTA_YAKINI_BILGILERI HASTA_YAKINI_BILGILERI;
            public HASTA_KLINIK_BILGILERI HASTA_KLINIK_BILGILERI = new HASTA_KLINIK_BILGILERI();
            public NAKIL_BILGILERI NAKIL_BILGILERI;
            [System.Xml.Serialization.XmlElement("TRANSPORT_SIRASINDA_GEREKSINIMLER", Type = typeof(TRANSPORT_SIRASINDA_GEREKSINIMLER))]
            public List<TRANSPORT_SIRASINDA_GEREKSINIMLER> TRANSPORT_SIRASINDA_GEREKSINIMLER;
            public SEVK_HEKIM_BILGILERI SEVK_HEKIM_BILGILERI;
            [System.Xml.Serialization.XmlElement("TRANSFER_NEDENLERI", Type = typeof(TRANSFER_NEDENLERI))]
            public List<TRANSFER_NEDENLERI> TRANSFER_NEDENLERI;
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI;
            public KABUL_EDEN_KURUM_BILGILERI KABUL_EDEN_KURUM_BILGILERI;

        }

        public class KABUL_EDEN_KURUM_BILGILERI
        {
            public IL IL = new IL();
            public KABUL_EDEN_KURUM KABUL_EDEN_KURUM = new KABUL_EDEN_KURUM();
            public KABUL_EDEN_KLINIK KABUL_EDEN_KLINIK = new KABUL_EDEN_KLINIK();
            public KABUL_EDEN_PERSONEL_ADI KABUL_EDEN_PERSONEL_ADI = new KABUL_EDEN_PERSONEL_ADI();
            public KABUL_EDEN_PERSONEL_SOYADI KABUL_EDEN_PERSONEL_SOYADI = new KABUL_EDEN_PERSONEL_SOYADI();
            public KABUL_EDEN_PERSONEL_TELEFON KABUL_EDEN_PERSONEL_TELEFON = new KABUL_EDEN_PERSONEL_TELEFON() ;
        }
        public class BOY_KILO_BILGILERI
        {
            public BOY BOY;
            public KILO KILO;
        }
        public class HASTA_YAKINI_BILGILERI
        {
            public AD AD = new AD();
            public SOYAD SOYAD = new SOYAD();
            public TELEFON_NUMARASI TELEFON_NUMARASI = new TELEFON_NUMARASI();
            public ACIK_ADRES ACIK_ADRES = new ACIK_ADRES();
        }

        public class HASTA_KLINIK_BILGILERI
        {
            public PATOLOJIK_MUAYENE_BILGILERI PATOLOJIK_MUAYENE_BILGILERI;
            public TETKIK_BILGILERI TETKIK_BILGILERI = new TETKIK_BILGILERI();
            public YAPILAN_MEDIKAL_ISLEMLER YAPILAN_MEDIKAL_ISLEMLER = new YAPILAN_MEDIKAL_ISLEMLER();
            public ISTENEN_MEDIKAL_ISLEMLER ISTENEN_MEDIKAL_ISLEMLER = new ISTENEN_MEDIKAL_ISLEMLER();
            public SEVK_EDILEN_KURUMDAN_YAPILMASI_ISTENEN_MEDIKAL_ISLEMLER SEVK_EDILEN_KURUMDAN_YAPILMASI_ISTENEN_MEDIKAL_ISLEMLER = new SEVK_EDILEN_KURUMDAN_YAPILMASI_ISTENEN_MEDIKAL_ISLEMLER();
            public TRIAJ TRIAJ;
            [System.Xml.Serialization.XmlElement("VITAL_BULGULAR", Type = typeof(VITAL_BULGULAR))]
            public List<VITAL_BULGULAR> VITAL_BULGULAR;
            [System.Xml.Serialization.XmlElement("GLASGOW_SKALASI", Type = typeof(GLASGOW_SKALASI))]
            public List<GLASGOW_SKALASI> GLASKOW_SKALASI;
            [System.Xml.Serialization.XmlElement("SEVKE_ESAS_TANI_BILGILERI", Type = typeof(SEVKE_ESAS_TANI_BILGILERI))]
            public List<SEVKE_ESAS_TANI_BILGILERI> SEVKE_ESAS_TANI_BILGILERI;
            [System.Xml.Serialization.XmlElement("NAKIL_LAB_BILGILERI", Type = typeof(NAKIL_LAB_BILGILERI))]
            public List<NAKIL_LAB_BILGILERI> NAKIL_LAB_BILGILERI;

            [System.Xml.Serialization.XmlElement("EPIKRIZ_BILGISI", Type = typeof(EPIKRIZ_BILGISI))]
            public List<EPIKRIZ_BILGISI> EPIKRIZ_BILGISI;

            [System.Xml.Serialization.XmlElement("YENIDOGAN_BILGILERI", Type = typeof(YENIDOGAN_BILGILERI))]
            public List<YENIDOGAN_BILGILERI> YENIDOGAN_BILGILERI;
        }

        public class YENIDOGAN_BILGILERI
        {
            public GESTASYON_HAFTASI GESTASYON_HAFTASI;
            public DOGUM_AGIRLIGI DOGUM_AGIRLIGI;
            public MEVCUT_AGIRLIGI MEVCUT_AGIRLIGI;
            public DOGUM_YONTEMI DOGUM_YONTEMI;
            public APGAR_1 APGAR_1;
            public APGAR_5 APGAR_5;

        }

        public class EPIKRIZ_BILGISI
        {
            public EPIKRIZ_BILGISI_BASLIK EPIKRIZ_BILGISI_BASLIK = new EPIKRIZ_BILGISI_BASLIK();
            public EPIKRIZ_BILGISI_ACIKLAMA EPIKRIZ_BILGISI_ACIKLAMA = new EPIKRIZ_BILGISI_ACIKLAMA();
        }
        public class SEVKE_ESAS_TANI_BILGILERI
        {
            public ICD10 ICD10 = new ICD10();
        }

        public class NAKIL_LAB_BILGILERI
        {
            public PO2 PO2;
            public SPO2_NABIZ SPO2;
            public ETCO2 ETCO2;
            public CRP CRP;
            public PH PH;
            public FIO2 FIO2;
            public CO2 CO2;
            public HCO3 HCO3;
            public K K;
            public CA CA;
            public NA NA;

        }
        public class VITAL_BULGULAR
        {
            public NABIZ_SAYISI NABIZ_SAYISI;
            public SISTOLIK_KAN_BASINCI_DEGERI SISTOLIK_KAN_BASINCI_DEGERI;
            public DIASTOLIK_KAN_BASINCI_DEGERI DIASTOLIK_KAN_BASINCI_DEGERI;
            public BILINC BILINC;
            public ATES ATES;
            public SOLUNUM SOLUNUM;
            public SOLUNUM_SAYISI SOLUNUM_SAYISI;
            public KAN_SEKERI KAN_SEKERI;
            public SOLUNUM_ISLEMI SOLUNUM_ISLEMI;
        }

        public class GLASGOW_SKALASI
        {
            public GOZLER GOZLER;
            public SOZEL SOZEL;
            public MOTOR MOTOR;
        }

        public class NAKIL_BILGILERI
        {
         
            public DOKTOR_IHTIYACI DOKTOR_IHTIYACI;
            public BRANS_IHTIYACI BRANS_IHTIYACI;
            public TEYITLI_VAKA_MI TEYITLI_VAKA_MI;
            public NAKIL_YOLU NAKIL_YOLU;
        }

        public class TRANSPORT_SIRASINDA_GEREKSINIMLER
        {
            public MALZEME MALZEME;
            public MALZEME_SAYISI MALZEME_SAYISI;
        }

        public class SEVK_HEKIM_BILGILERI
        {
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI;
            public TELEFON_NUMARASI TELEFON_NUMARASI;
            public AD AD;
            public SOYAD SOYAD;
        }

        public class TRANSFER_NEDENLERI
        {
            public SEVK_NEDENI SEVK_NEDENI;
            public ACIKLAMA ACIKLAMA;
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {

            using (var objectContext = new TTObjectContext(false))
            {
                HastaNakilFormu nakilFormu = (HastaNakilFormu)objectContext.GetObject(InternalObjectId, InternalObjectDefName);
                SubEpisode subEpisode = nakilFormu.SubEpisode;
                if (nakilFormu == null)
                    throw new Exception("'262' paketini göndermek için '" + InternalObjectId + "' ObjectId'li " + InternalObjectDefName + " Objesi bulunamadı");

                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

                if (myTesisSKRSKurumlarDefinition == null)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
                }

                recordData _recordData = new recordData();
                //HASTA_TAKIP_BILGISI
                _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = nakilFormu.SubEpisode.SYSTakipNo;

                //ERISKIN_HASTA_NAKIL_BILGILERI
                ERISKIN_HASTA_NAKIL_BILGILERI ERISKIN_HASTA_NAKIL_BILGILERI = new ERISKIN_HASTA_NAKIL_BILGILERI();
                if (nakilFormu.HastaHukumDurum != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_HUKUMLU_MU = new HASTA_HUKUMLU_MU(nakilFormu.HastaHukumDurum.KODU, nakilFormu.HastaHukumDurum.ADI);
                }
                if (nakilFormu.AdliVakaDurum != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_ADLI_VAKA_MI = new HASTA_ADLI_VAKA_MI(nakilFormu.AdliVakaDurum.KODU, nakilFormu.AdliVakaDurum.ADI);
                }
                if (nakilFormu.KabnGrubu != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.KAN_GRUBU = new KAN_GRUBU(nakilFormu.KabnGrubu.KODU, nakilFormu.KabnGrubu.ADI);
                }
                ERISKIN_HASTA_NAKIL_BILGILERI.PAKETE_AIT_ISLEM_ZAMANI.value = DateTime.Now.ToString("yyyyMMddHHmm");
                ERISKIN_HASTA_NAKIL_BILGILERI.NAKLIN_TALEP_EDILDIGI_ZAMAN.value = nakilFormu.TalepEdildigiZaman.HasValue? nakilFormu.TalepEdildigiZaman.Value.ToString("yyyyMMddHHmm"):string.Empty;
                ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_TALEP_EDEN_KURUM = new NAKIL_TALEP_EDEN_KURUM(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
                ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_TALEP_EDEN_KURUM_TELEFON.value = String.Empty; //Zorunlu alan doldurulacak. Parametre?
                ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_TALEP_EDEN_KLINIK = new NAKIL_TALEP_EDEN_KLINIK(nakilFormu.TalepEdenKlinik.KODU, nakilFormu.TalepEdenKlinik.ADI);
                ERISKIN_HASTA_NAKIL_BILGILERI.HASTANIN_BULUNDUGU_KLINIK = new HASTANIN_BULUNDUGU_KLINIK(nakilFormu.HastaninBulunduguKlinik.KODU, nakilFormu.HastaninBulunduguKlinik.ADI);
                ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_EDILMEK_ISTENDIGI_KLINIK = new NAKIL_EDILMEK_ISTENDIGI_KLINIK(nakilFormu.NakilEdilmekIstenilenKlinik.KODU, nakilFormu.NakilEdilmekIstenilenKlinik.ADI);
                ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_NAKIL_TIPI = new HASTA_NAKIL_TIPI(nakilFormu.HastaNakilTipi.KODU, nakilFormu.HastaNakilTipi.ADI);
                ERISKIN_HASTA_NAKIL_BILGILERI.GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI = new GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI(nakilFormu.KomutaKontrolMerkezi.KODU.ToString(),nakilFormu.KomutaKontrolMerkezi.ADI);
                //HASTA_YAKINI_BILGILERI
                if (nakilFormu.HastaYakiniAdi != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI = new HASTA_YAKINI_BILGILERI();
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.AD.value = nakilFormu.HastaYakiniAdi;
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.SOYAD.value = nakilFormu.HastaYakiniSoyadi;
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.TELEFON_NUMARASI.value = nakilFormu.HastaYakiniTel;
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.ACIK_ADRES.value = nakilFormu.HastaYakiniAdresi;
                }
                //HASTA_KLINIK_BILGILERI
                ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI = new HASTA_KLINIK_BILGILERI();
                if (nakilFormu.PatolojikMuayeneBilgileri != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.PATOLOJIK_MUAYENE_BILGILERI = new PATOLOJIK_MUAYENE_BILGILERI();
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.PATOLOJIK_MUAYENE_BILGILERI.value = nakilFormu.PatolojikMuayeneBilgileri.ToString();
                }

                if (nakilFormu.TetkikBilgileri != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.TETKIK_BILGILERI = new TETKIK_BILGILERI();
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.TETKIK_BILGILERI.value = nakilFormu.TetkikBilgileri.ToString();
                }

                if (nakilFormu.YapilanMedikalIslemler != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.YAPILAN_MEDIKAL_ISLEMLER = new YAPILAN_MEDIKAL_ISLEMLER();
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.YAPILAN_MEDIKAL_ISLEMLER.value = nakilFormu.YapilanMedikalIslemler.ToString();
                }

                if (nakilFormu.IstenilenMedikalIslemler != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.ISTENEN_MEDIKAL_ISLEMLER = new ISTENEN_MEDIKAL_ISLEMLER();
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.ISTENEN_MEDIKAL_ISLEMLER.value = nakilFormu.IstenilenMedikalIslemler.ToString();
                }

                if (nakilFormu.YapilacakMedikalIslemler != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.SEVK_EDILEN_KURUMDAN_YAPILMASI_ISTENEN_MEDIKAL_ISLEMLER = new SEVK_EDILEN_KURUMDAN_YAPILMASI_ISTENEN_MEDIKAL_ISLEMLER();
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.SEVK_EDILEN_KURUMDAN_YAPILMASI_ISTENEN_MEDIKAL_ISLEMLER.value = nakilFormu.YapilacakMedikalIslemler.ToString();
                }

                if(nakilFormu.TriajKodu != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.TRIAJ = new TRIAJ(nakilFormu.TriajKodu.KODU, nakilFormu.TriajKodu.ADI);
                }

                ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.VITAL_BULGULAR = new List<VITAL_BULGULAR>();
                VITAL_BULGULAR VITAL_BULGULAR = new VITAL_BULGULAR();
                if (nakilFormu.NabizSayisi != null) {
                    VITAL_BULGULAR.NABIZ_SAYISI = new NABIZ_SAYISI();
                    VITAL_BULGULAR.NABIZ_SAYISI.value = nakilFormu.NabizSayisi.ToString();
                }

                if (nakilFormu.SistolikKanBasinci != null)
                {
                    VITAL_BULGULAR.SISTOLIK_KAN_BASINCI_DEGERI = new SISTOLIK_KAN_BASINCI_DEGERI();
                    VITAL_BULGULAR.SISTOLIK_KAN_BASINCI_DEGERI.value = nakilFormu.SistolikKanBasinci.ToString();
                }

                if (nakilFormu.DiastolikKanBasinci != null)
                {
                    VITAL_BULGULAR.DIASTOLIK_KAN_BASINCI_DEGERI = new DIASTOLIK_KAN_BASINCI_DEGERI();
                    VITAL_BULGULAR.DIASTOLIK_KAN_BASINCI_DEGERI.value = nakilFormu.DiastolikKanBasinci.ToString();
                }

                if (nakilFormu.Bilinc != null) //Düzeltilecek
                {
                    VITAL_BULGULAR.BILINC = new BILINC(nakilFormu.Bilinc.KODU,nakilFormu.Bilinc.ADI);
                 
                }

                if (nakilFormu.Ates != null)
                {
                    VITAL_BULGULAR.ATES = new ATES();
                    VITAL_BULGULAR.ATES.value = nakilFormu.Ates.ToString();
                }
                
                if (nakilFormu.Solunum != null)
                {
                    VITAL_BULGULAR.SOLUNUM = new SOLUNUM(nakilFormu.Solunum.KODU, nakilFormu.Solunum.ADI);
                
                }

                if (nakilFormu.SolunumSayisi != null)
                {
                    VITAL_BULGULAR.SOLUNUM_SAYISI = new SOLUNUM_SAYISI();
                    VITAL_BULGULAR.SOLUNUM_SAYISI.value = nakilFormu.SolunumSayisi.ToString();
                }

                if (nakilFormu.KanSekeri != null)
                {
                    VITAL_BULGULAR.KAN_SEKERI = new KAN_SEKERI();
                    VITAL_BULGULAR.KAN_SEKERI.value = nakilFormu.KanSekeri.ToString();
                }

                //Solunum işlemi eklenecek
                //VITAL_BULGULAR.SOLUNUM_ISLEMI = new SOLUNUM_ISLEMI("3", "SPONTAN");
                if(nakilFormu.SolunumIslemi == "1")
                {
                    VITAL_BULGULAR.SOLUNUM_ISLEMI = new SOLUNUM_ISLEMI("1", "ENTÜBE");
                }else if(nakilFormu.SolunumIslemi == "2")
                    VITAL_BULGULAR.SOLUNUM_ISLEMI = new SOLUNUM_ISLEMI("2", "NON-INVASIVE");
                else
                    VITAL_BULGULAR.SOLUNUM_ISLEMI = new SOLUNUM_ISLEMI("3", "SPONTAN");

                


                ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.VITAL_BULGULAR.Add(VITAL_BULGULAR);
                
                if(nakilFormu.Gozler != null || nakilFormu.Sozel != null || nakilFormu.Motor != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.GLASKOW_SKALASI = new List<GLASGOW_SKALASI>();
                    GLASGOW_SKALASI GLASGOW_SKALASI = new GLASGOW_SKALASI();
                    if(nakilFormu.Gozler != null)
                    {
                        GLASGOW_SKALASI.GOZLER = new GOZLER();
                        GLASGOW_SKALASI.GOZLER.value = nakilFormu.Gozler.ToString();
                    }
                    if (nakilFormu.Sozel != null)
                    {
                        GLASGOW_SKALASI.SOZEL = new SOZEL();
                        GLASGOW_SKALASI.SOZEL.value = nakilFormu.Sozel.ToString();
                    }

                    if (nakilFormu.Motor != null)
                    {
                        GLASGOW_SKALASI.MOTOR = new MOTOR();
                        GLASGOW_SKALASI.MOTOR.value = nakilFormu.Motor.ToString();
                    }
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.GLASKOW_SKALASI.Add(GLASGOW_SKALASI);
                }

                ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.SEVKE_ESAS_TANI_BILGILERI = new List<SEVKE_ESAS_TANI_BILGILERI>();
                foreach (HastaNakilTanilar tani in nakilFormu.HastaNakilTanilar)
                {
                    SEVKE_ESAS_TANI_BILGILERI SEVKE_ESAS_TANI_BILGILERI = new SEVKE_ESAS_TANI_BILGILERI();
                    SEVKE_ESAS_TANI_BILGILERI.ICD10 = new ICD10(tani.SKRSICD.KODU, tani.SKRSICD.ADI);
                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.SEVKE_ESAS_TANI_BILGILERI.Add(SEVKE_ESAS_TANI_BILGILERI);
                }

                if (nakilFormu.HastaNakilTanilar.Count == 0)
                {
                    var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, nakilFormu.SubEpisode.ObjectID.ToString());
                    foreach (var diagnose in diagnosisList)
                    {
                        SEVKE_ESAS_TANI_BILGILERI SEVKE_ESAS_TANI_BILGILERI = new SEVKE_ESAS_TANI_BILGILERI();
                        SKRSICD skrsDiagnose = diagnose.Diagnose.GetSKRSDefinition() as SKRSICD;
                        SEVKE_ESAS_TANI_BILGILERI.ICD10 = new ICD10(skrsDiagnose.KODU, skrsDiagnose.ADI);
                        ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.SEVKE_ESAS_TANI_BILGILERI.Add(SEVKE_ESAS_TANI_BILGILERI);

                    }
                }



                //NAKIL_LAB_BILGILERI Ekranda Olmadığı İçin XML e eklemedik, bu şekilde gönderim denenecek.

                //EPIKRIZ_BILGISI Zorunlu değil istenirse eklenecek
                if (subEpisode.Episode.PatientHistory != null || subEpisode.Episode.Complaint != null || subEpisode.Episode.PhysicalExamination != null || subEpisode.InPatientPhysicianProgresses.Count > 0 || nakilFormu.EkAciklama !=null)
                {


                    ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.EPIKRIZ_BILGISI = new List<EPIKRIZ_BILGISI>();
    
                    if (subEpisode.Episode.PatientHistory != null)
                    {
                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "HİKAYESİ";
                        if (Common.GetTextOfRTFString(subEpisode.Episode.PatientHistory.ToString()).Length > 1000)
                            EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.PatientHistory.ToString()).Substring(0, 1000);
                        else
                            EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.PatientHistory.ToString());
                        ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                    }
                    if (subEpisode.Episode.Complaint != null)
                    {
                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "ŞİKAYETİ";
                        if (subEpisode.Episode.Complaint.ToString().Length > 1000)
                            EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = subEpisode.Episode.Complaint.ToString().Substring(0, 1000);
                        else
                            EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = subEpisode.Episode.Complaint.ToString();
                        ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                    }
                    if (subEpisode.Episode.PhysicalExamination != null)
                    {
                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "FİZİK MUAYENESİ";
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = subEpisode.Episode.PhysicalExamination.ToString().Length > 1000 ? subEpisode.Episode.PhysicalExamination.ToString().Substring(0, 1000): subEpisode.Episode.PhysicalExamination.ToString();
                        ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                    }

                    foreach (var inPatientPhysicianProgress in subEpisode.InPatientPhysicianProgresses)
                    {
                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "KLİNİK SEYİR";
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = inPatientPhysicianProgress.Description.ToString().Length > 1000 ? inPatientPhysicianProgress.Description.ToString().Substring(0, 1000) : inPatientPhysicianProgress.Description.ToString(); 
                        ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                    }

                    if (nakilFormu.EkAciklama != null)
                    {
                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "EPIKRIZ EK ACIKLAMA";
                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = nakilFormu.EkAciklama.ToString().Length > 1000 ? nakilFormu.EkAciklama.ToString().Substring(0, 1000) : nakilFormu.EkAciklama.ToString();
                        ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                    }

                }



                    //YENIDOGAN_BILGILERI 

                    //NAKIL_BILGILERI 
                    ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI = new NAKIL_BILGILERI();
                if (nakilFormu.DoktorIhtiyacDurumu != null)
                    ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI.DOKTOR_IHTIYACI = new DOKTOR_IHTIYACI(nakilFormu.DoktorIhtiyacDurumu.KODU,nakilFormu.DoktorIhtiyacDurumu.ADI);
                if(nakilFormu.BransIhtiyaci != null)
                     ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI.BRANS_IHTIYACI = new BRANS_IHTIYACI(nakilFormu.BransIhtiyaci.KODU, nakilFormu.BransIhtiyaci.ADI);
                if (nakilFormu.TeyitliVakaDurumu != null)
                    ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI.TEYITLI_VAKA_MI = new TEYITLI_VAKA_MI(nakilFormu.TeyitliVakaDurumu.KODU, nakilFormu.TeyitliVakaDurumu.ADI);
                if (nakilFormu.NakilGerceklestirmeYolu != null)
                    ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI.NAKIL_YOLU = new NAKIL_YOLU(nakilFormu.NakilGerceklestirmeYolu.KODU, nakilFormu.NakilGerceklestirmeYolu.ADI);

                //TRANSPORT_SIRASINDA_GEREKSINIMLER
                if (nakilFormu.TransportMalzemesi != null || nakilFormu.MalzemeSayisi != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.TRANSPORT_SIRASINDA_GEREKSINIMLER = new List<TRANSPORT_SIRASINDA_GEREKSINIMLER>();
                    TRANSPORT_SIRASINDA_GEREKSINIMLER TRANSPORT_SIRASINDA_GEREKSINIMLER = new TRANSPORT_SIRASINDA_GEREKSINIMLER();
                    if (nakilFormu.TransportMalzemesi != null)
                        TRANSPORT_SIRASINDA_GEREKSINIMLER.MALZEME = new MALZEME(nakilFormu.TransportMalzemesi.KODU, nakilFormu.TransportMalzemesi.ADI);
                    if (nakilFormu.MalzemeSayisi != null)
                    {
                        TRANSPORT_SIRASINDA_GEREKSINIMLER.MALZEME_SAYISI = new MALZEME_SAYISI();
                        TRANSPORT_SIRASINDA_GEREKSINIMLER.MALZEME_SAYISI.value = nakilFormu.MalzemeSayisi.ToString();
                    }
                    ERISKIN_HASTA_NAKIL_BILGILERI.TRANSPORT_SIRASINDA_GEREKSINIMLER.Add(TRANSPORT_SIRASINDA_GEREKSINIMLER);
                }

                //SEVK_HEKIM_BILGILERI
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI = new SEVK_HEKIM_BILGILERI();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.HEKIM_KIMLIK_NUMARASI.value = nakilFormu.HekimTC.ToString();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.TELEFON_NUMARASI = new TELEFON_NUMARASI();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.TELEFON_NUMARASI.value = nakilFormu.HekimTel.ToString();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.AD = new AD();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.AD.value = nakilFormu.HekimAdi.ToString();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.SOYAD = new SOYAD();
                ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.SOYAD.value = nakilFormu.HekimSoyadi.ToString();

                //TRANSFER_NEDENLERI
                if (nakilFormu.SevkNedeniAciklama != null || nakilFormu.SevkNedeni != null)
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.TRANSFER_NEDENLERI = new List<TRANSFER_NEDENLERI>();
                    TRANSFER_NEDENLERI TRANSFER_NEDENLERI = new TRANSFER_NEDENLERI();
                    if(nakilFormu.SevkNedeniAciklama != null)
                    {
                        TRANSFER_NEDENLERI.ACIKLAMA = new ACIKLAMA();
                        TRANSFER_NEDENLERI.ACIKLAMA.value = nakilFormu.SevkNedeniAciklama.ToString();
                            
                    }
                    if (nakilFormu.SevkNedeni != null)
                    {
                        TRANSFER_NEDENLERI.SEVK_NEDENI = new SEVK_NEDENI(nakilFormu.SevkNedeni.KODU,nakilFormu.SevkNedeni.ADI);
                       

                    }
                    ERISKIN_HASTA_NAKIL_BILGILERI.TRANSFER_NEDENLERI.Add(TRANSFER_NEDENLERI);
                }
                //BOY_KILO_BILGILERI Ekranda olmadığı için eklenmedi

                //KABUL_EDEN_KURUM_BILGILERI Teyitli vaka evet ise zorunlu
                if(nakilFormu.TeyitliVakaDurumu != null && nakilFormu.TeyitliVakaDurumu.KODU == "1")
                {
                    ERISKIN_HASTA_NAKIL_BILGILERI.KABUL_EDEN_KURUM_BILGILERI = new KABUL_EDEN_KURUM_BILGILERI();
                    ERISKIN_HASTA_NAKIL_BILGILERI.KABUL_EDEN_KURUM_BILGILERI.IL = new IL(nakilFormu.KabulEdenKurumIli.KODU.ToString(), nakilFormu.KabulEdenKurumIli.ADI);
                    ERISKIN_HASTA_NAKIL_BILGILERI.KABUL_EDEN_KURUM_BILGILERI.KABUL_EDEN_KURUM = new KABUL_EDEN_KURUM(nakilFormu.KabulEdenKurum.KODU.ToString(), nakilFormu.KabulEdenKurum.ADI);
                    ERISKIN_HASTA_NAKIL_BILGILERI.KABUL_EDEN_KURUM_BILGILERI.KABUL_EDEN_KLINIK = new KABUL_EDEN_KLINIK(nakilFormu.NakilKabulEdenKlinik.KODU.ToString(), nakilFormu.NakilKabulEdenKlinik.ADI);
                    ERISKIN_HASTA_NAKIL_BILGILERI.KABUL_EDEN_KURUM_BILGILERI.KABUL_EDEN_PERSONEL_ADI.value = nakilFormu.PersonelAdi;
                    ERISKIN_HASTA_NAKIL_BILGILERI.KABUL_EDEN_KURUM_BILGILERI.KABUL_EDEN_PERSONEL_SOYADI.value = nakilFormu.PersonelSoyad;
                    ERISKIN_HASTA_NAKIL_BILGILERI.KABUL_EDEN_KURUM_BILGILERI.KABUL_EDEN_PERSONEL_TELEFON.value = nakilFormu.PersonelTel;
                }

                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI = new ERISKIN_HASTA_NAKIL_BILGILERI();
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI = ERISKIN_HASTA_NAKIL_BILGILERI;


              SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        }
        public static SYSMessage GetDummy()
        {

                //Burası Doldurulacak
                //Zorunlu Alanlar için http://xxxxxx.com/dokumanonline/ adresinden 262 Hasta Nakil Bilgileri paketini inceleyin.


                /*GlassesReport gozlukRecetesi = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as GlassesReport;
                if (gozlukRecetesi == null)
                    throw new Exception("'226' paketini göndermek için " + InternalObjectId + " ObjectId'li GlassesReport Objesi bulunamadı.");*/

                recordData _recordData = new recordData();
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.PAKETE_AIT_ISLEM_ZAMANI.value = "201801010000";
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI = new HASTA_KLINIK_BILGILERI();
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.PATOLOJIK_MUAYENE_BILGILERI = new PATOLOJIK_MUAYENE_BILGILERI();
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.PATOLOJIK_MUAYENE_BILGILERI.value = "test";
                //_recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.ICD10 = new ICD10("J98.9", "SOLUNUM BOZUKLUKLARI, TANIMLANMAMIŞ");
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI = new HASTA_YAKINI_BILGILERI();
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.AD.value = "denemeAd";
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.SOYAD.value = "denemeSoyad";
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.TELEFON_NUMARASI.value = "053211255668";
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_YAKINI_BILGILERI.ACIK_ADRES.value = "adres deneme";
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.TRANSFER_NEDENLERI = new List<TRANSFER_NEDENLERI>();
                TRANSFER_NEDENLERI transferNedeni = new TRANSFER_NEDENLERI();
                transferNedeni.ACIKLAMA = new ACIKLAMA();
                transferNedeni.ACIKLAMA.value = "test";
                transferNedeni.SEVK_NEDENI = new SEVK_NEDENI("3", "DIĞER");
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.TRANSFER_NEDENLERI.Add(transferNedeni);

                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.VITAL_BULGULAR = new List<VITAL_BULGULAR>();
                VITAL_BULGULAR vitalBulgu = new VITAL_BULGULAR();
                vitalBulgu.DIASTOLIK_KAN_BASINCI_DEGERI = new DIASTOLIK_KAN_BASINCI_DEGERI();
                vitalBulgu.DIASTOLIK_KAN_BASINCI_DEGERI.value = "80";
                vitalBulgu.SISTOLIK_KAN_BASINCI_DEGERI = new SISTOLIK_KAN_BASINCI_DEGERI();
                vitalBulgu.SISTOLIK_KAN_BASINCI_DEGERI.value = "120";
                vitalBulgu.NABIZ_SAYISI = new NABIZ_SAYISI();
                vitalBulgu.NABIZ_SAYISI.value = "100";
                vitalBulgu.ATES = new ATES();
                vitalBulgu.ATES.value = "38.0";
                vitalBulgu.BILINC = new BILINC("1", "AÇIK");
                vitalBulgu.SOLUNUM = new SOLUNUM("1", "DÜZENLI");
                vitalBulgu.SOLUNUM_SAYISI = new SOLUNUM_SAYISI();
                vitalBulgu.SOLUNUM_SAYISI.value = "100";
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.VITAL_BULGULAR.Add(vitalBulgu);
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.GLASKOW_SKALASI = new List<GLASGOW_SKALASI>();
                GLASGOW_SKALASI glaskowSkalasi = new GLASGOW_SKALASI();
                glaskowSkalasi.GOZLER = new GOZLER();
                glaskowSkalasi.GOZLER.value = "1";
                glaskowSkalasi.MOTOR = new MOTOR();
                glaskowSkalasi.MOTOR.value = "1";
                glaskowSkalasi.SOZEL = new SOZEL();
                glaskowSkalasi.SOZEL.value = "1";
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.GLASKOW_SKALASI.Add(glaskowSkalasi);
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI = new NAKIL_BILGILERI();
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI.DOKTOR_IHTIYACI = new DOKTOR_IHTIYACI("1", "EVET");
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.NAKIL_BILGILERI.NAKIL_YOLU = new NAKIL_YOLU("1", "HAVAYOLU");
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.TRANSPORT_SIRASINDA_GEREKSINIMLER = new List<TRANSPORT_SIRASINDA_GEREKSINIMLER>();
                TRANSPORT_SIRASINDA_GEREKSINIMLER gereksinim = new TRANSPORT_SIRASINDA_GEREKSINIMLER();
                gereksinim.MALZEME = new MALZEME();
                gereksinim.MALZEME_SAYISI = new MALZEME_SAYISI();
                gereksinim.MALZEME_SAYISI.value = "1";
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI = new SEVK_HEKIM_BILGILERI();
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.HEKIM_KIMLIK_NUMARASI.value = "10000000000";
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.AD = new AD();
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.AD.value = "denemeDoktor";
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.SOYAD = new SOYAD();
            _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.SOYAD.value = "denemeDoktorSoyad"; 
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.TELEFON_NUMARASI = new TELEFON_NUMARASI();
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.SEVK_HEKIM_BILGILERI.TELEFON_NUMARASI.value = "5553221585";
                _recordData.ERISKIN_HASTA_NAKIL_BILGILERI.HASTA_KLINIK_BILGILERI.TRIAJ = new TRIAJ("1", "YEŞİL");




                /* if (gozlukRecetesi.SubEpisode.SYSTakipNo == null)
                     throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                 else
                     _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = gozlukRecetesi.SubEpisode.SYSTakipNo;*/

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            
        }
        }
}
