using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz221_GebeIzlemVeriSeti
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
                messageType.code = "221";
                messageType.value = "Gebe Izlem Veri Seti";
            }
        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public GEBE_IZLEM GEBE_IZLEM = new GEBE_IZLEM();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class GEBE_IZLEM
        {
            public GESTASYONEL_DIYABET_TARAMASI GESTASYONEL_DIYABET_TARAMASI;
            public IDRARDA_PROTEIN IDRARDA_PROTEIN;
            public HEMOGLOBIN HEMOGLOBIN;
            public IZLEM_ISLEM_TURU IZLEM_ISLEM_TURU;
            public KACINCI_GEBE_IZLEM KACINCI_GEBE_IZLEM;
            public DEMIR_LOJISTIGI_VE_DESTEGI DEMIR_LOJISTIGI_VE_DESTEGI;
            public D_VITAMINI_LOJISTIGI_VE_DESTEGI D_VITAMINI_LOJISTIGI_VE_DESTEGI;
            public KONJENITAL_ANOMALILI_DOGUM_VARLIGI KONJENITAL_ANOMALILI_DOGUM_VARLIGI;

            [System.Xml.Serialization.XmlElement("FETUS_KALP_SESI_BILGISI", Type = typeof(FETUS_KALP_SESI_BILGISI))]
            public List<FETUS_KALP_SESI_BILGISI> FETUS_KALP_SESI_BILGISI;

            public TANSIYON_BILGISI TANSIYON_BILGISI;
            public GEBELIKTE_RISK_FAKTORLERI_BILGISI GEBELIKTE_RISK_FAKTORLERI_BILGISI;

            //public IZLEMIN_YAPILDIGI_YER IZLEMIN_YAPILDIGI_YER;
            //public ISLEM_YAPAN ISLEM_YAPAN;
            //public BILGI_ALINAN_KISI_ADI_SOYADI BILGI_ALINAN_KISI_ADI_SOYADI;
            //public BILGI_ALINAN_KISI_TEL BILGI_ALINAN_KISI_TEL;
            //public GEBELIKTE_RISK_DURUMU GEBELIKTE_RISK_DURUMU;
            //public KOMPLIKASYON_TANISI_BILGISI KOMPLIKASYON_TANISI_BILGISI;
            //public KADIN_SAGLIGI_ISLEMLERI_BILGISI KADIN_SAGLIGI_ISLEMLERI_BILGISI;

            //[System.Xml.Serialization.XmlElement("GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI", Type = typeof(GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI))]
            //public List<GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI> GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI;

            //[System.Xml.Serialization.XmlElement("GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI", Type = typeof(GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI))]
            //public List<GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI> GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI;

        }
        public class KOMPLIKASYON_TANISI_BILGISI
        {
            [System.Xml.Serialization.XmlElement("KOMPLIKASYON_TANISI", Type = typeof(KOMPLIKASYON_TANISI))]
            public List<KOMPLIKASYON_TANISI> KOMPLIKASYON_TANISI = new List<KOMPLIKASYON_TANISI>();
        }
        public class GEBELIKTE_RISK_FAKTORLERI_BILGISI
        {
            [System.Xml.Serialization.XmlElement("GEBELIKTE_RISK_FAKTORLERI", Type = typeof(GEBELIKTE_RISK_FAKTORLERI))]
            public List<GEBELIKTE_RISK_FAKTORLERI> GEBELIKTE_RISK_FAKTORLERI = new List<GEBELIKTE_RISK_FAKTORLERI>();
        }
        public class FETUS_KALP_SESI_BILGISI
        {
            public FETUS_KALP_SESI FETUS_KALP_SESI = new FETUS_KALP_SESI();
        }
        public class TANSIYON_BILGISI
        {
            public DIASTOLIK_KAN_BASINCI_DEGERI DIASTOLIK_KAN_BASINCI_DEGERI;
            public SISTOLIK_KAN_BASINCI_DEGERI SISTOLIK_KAN_BASINCI_DEGERI;
        }
        public class GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI
        {
            public GEBE_BILGILENDIRME_VE_DANISMANLIK GEBE_BILGILENDIRME_VE_DANISMANLIK = new GEBE_BILGILENDIRME_VE_DANISMANLIK();
        }
        public class KADIN_SAGLIGI_ISLEMLERI_BILGISI
        {
            public KADIN_SAGLIGI_ISLEMLERI KADIN_SAGLIGI_ISLEMLERI;
        }
        /*public class GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI {             TODO NABIZ
            TTObjectClasses.GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI;
        }*/
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            recordData _recordData = new recordData();
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            if (myTesisSKRSKurumlarDefinition == null)
                throw new Exception(TTUtils.CultureService.GetText("M26897", "SKRS Kurum Bilgisi bulunamadı lütfen ilgili sistem parametresini düzeltin"));

            PregnancyFollow pregnancyFollow = (PregnancyFollow)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);

            if (pregnancyFollow.WomanSpecialityObject[0].PhysicianApplication.SubEpisode.SYSTakipNo == null)      //SYSTakipNo
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = pregnancyFollow.WomanSpecialityObject[0].PhysicianApplication.SubEpisode.SYSTakipNo;

            _recordData.GEBE_IZLEM = new GEBE_IZLEM();

            _recordData.GEBE_IZLEM.IZLEM_ISLEM_TURU = new IZLEM_ISLEM_TURU("1", "GERÇEK ZAMANLI");//? beyana dayalı durumu nasıl kontrol edilecek?

            if (pregnancyFollow.WhichPregnancyFollow != null)
            {
                _recordData.GEBE_IZLEM.KACINCI_GEBE_IZLEM = new KACINCI_GEBE_IZLEM(pregnancyFollow.WhichPregnancyFollow.KODU, pregnancyFollow.WhichPregnancyFollow.ADI);
            }
            if (pregnancyFollow.IronSupplements != null)
            {
                _recordData.GEBE_IZLEM.DEMIR_LOJISTIGI_VE_DESTEGI = new DEMIR_LOJISTIGI_VE_DESTEGI(pregnancyFollow.IronSupplements.KODU, pregnancyFollow.IronSupplements.ADI);
            }
            if (pregnancyFollow.VitaminDSupplements != null)
            {
                _recordData.GEBE_IZLEM.D_VITAMINI_LOJISTIGI_VE_DESTEGI = new D_VITAMINI_LOJISTIGI_VE_DESTEGI(pregnancyFollow.VitaminDSupplements.KODU, pregnancyFollow.VitaminDSupplements.ADI);
            }
            if (pregnancyFollow.CongenitalAnomalies != null)
            {
                _recordData.GEBE_IZLEM.KONJENITAL_ANOMALILI_DOGUM_VARLIGI = new KONJENITAL_ANOMALILI_DOGUM_VARLIGI(pregnancyFollow.CongenitalAnomalies.KODU, pregnancyFollow.CongenitalAnomalies.ADI);
            }

            //_recordData.GEBE_IZLEM.IZLEMIN_YAPILDIGI_YER = new IZLEMIN_YAPILDIGI_YER(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
            //if (pregnancyFollow.WomanSpecialityObject[0].PhysicianApplication.ProcedureDoctor.UniqueNo != null)
            //{
            //    _recordData.GEBE_IZLEM.ISLEM_YAPAN = new ISLEM_YAPAN();
            //    _recordData.GEBE_IZLEM.ISLEM_YAPAN.value = pregnancyFollow.WomanSpecialityObject[0].PhysicianApplication.ProcedureDoctor.UniqueNo;
            //}
            /* if (true)
             {
                 _recordData.GEBE_IZLEM.BILGI_ALINAN_KISI_ADI_SOYADI = new BILGI_ALINAN_KISI_ADI_SOYADI();       
                //_recordData.GEBE_IZLEM.BILGI_ALINAN_KISI_ADI_SOYADI = 
             }
             if (true)
             {
                 _recordData.GEBE_IZLEM.BILGI_ALINAN_KISI_TEL = new BILGI_ALINAN_KISI_TEL();       
                 //_recordData.GEBE_IZLEM.BILGI_ALINAN_KISI_TEL = 
             }*/
            //if (pregnancyFollow.RiskSituation != null)
            //{
            //    _recordData.GEBE_IZLEM.GEBELIKTE_RISK_DURUMU = new GEBELIKTE_RISK_DURUMU(pregnancyFollow.RiskSituation.KODU, pregnancyFollow.RiskSituation.ADI);
            //}
            if (pregnancyFollow.GestationalDiabetes != null)
            {
                _recordData.GEBE_IZLEM.GESTASYONEL_DIYABET_TARAMASI = new GESTASYONEL_DIYABET_TARAMASI(pregnancyFollow.SkrsGestationalDiabetes.KODU, pregnancyFollow.SkrsGestationalDiabetes.ADI);
            }
            if (pregnancyFollow.UrinaryProtein != null)
            {
                _recordData.GEBE_IZLEM.IDRARDA_PROTEIN = new IDRARDA_PROTEIN(pregnancyFollow.UrinaryProtein.KODU, pregnancyFollow.UrinaryProtein.ADI);
            }
            if (pregnancyFollow.Hemoglobin != null)
            {
                _recordData.GEBE_IZLEM.HEMOGLOBIN.value = pregnancyFollow.Hemoglobin.Value.ToString();
            }
            /*if (true)//TODO sonradan eklenecek  Komplikasyon tanısı
            {
                KOMPLIKASYON_TANISI_BILGISI KOMPLIKASYON_TANISI_BILGISI = new KOMPLIKASYON_TANISI_BILGISI();        
                KOMPLIKASYON_TANISI KOMPLIKASYON_TANISI = new KOMPLIKASYON_TANISI(pregnancyFollow.Pregnancy.PregnancyComplications[0].Complication.KODU, pregnancyFollow.Pregnancy.PregnancyComplications[0].Complication.ADI);
                KOMPLIKASYON_TANISI_BILGISI.KOMPLIKASYON_TANISI.Add(KOMPLIKASYON_TANISI);
                _recordData.GEBE_IZLEM.KOMPLIKASYON_TANISI_BILGISI.Add(KOMPLIKASYON_TANISI_BILGISI);     
            }
            */
            if (pregnancyFollow.PregnancyComplications.Count > 0)
            {
                GEBELIKTE_RISK_FAKTORLERI_BILGISI GEBELIKTE_RISK_FAKTORLERI_BILGISI = new GEBELIKTE_RISK_FAKTORLERI_BILGISI();
                foreach (PregnancyComplications complication in pregnancyFollow.PregnancyComplications)
                {
                    GEBELIKTE_RISK_FAKTORLERI GEBELIKTE_RISK_FAKTORLERI = new GEBELIKTE_RISK_FAKTORLERI(complication.Complication.KODU, complication.Complication.ADI);
                    GEBELIKTE_RISK_FAKTORLERI_BILGISI.GEBELIKTE_RISK_FAKTORLERI.Add(GEBELIKTE_RISK_FAKTORLERI);
                }
                _recordData.GEBE_IZLEM.GEBELIKTE_RISK_FAKTORLERI_BILGISI = GEBELIKTE_RISK_FAKTORLERI_BILGISI;
            }
            //if (pregnancyFollow.WomansHealthOperations != null)
            //{
            //    KADIN_SAGLIGI_ISLEMLERI_BILGISI KADIN_SAGLIGI_ISLEMLERI_BILGISI = new KADIN_SAGLIGI_ISLEMLERI_BILGISI();
            //    KADIN_SAGLIGI_ISLEMLERI_BILGISI.KADIN_SAGLIGI_ISLEMLERI = new KADIN_SAGLIGI_ISLEMLERI(pregnancyFollow.WomansHealthOperations.KODU, pregnancyFollow.WomansHealthOperations.ADI);
            //    _recordData.GEBE_IZLEM.KADIN_SAGLIGI_ISLEMLERI_BILGISI = KADIN_SAGLIGI_ISLEMLERI_BILGISI;
            //}
            if (pregnancyFollow.FetusFollow.Count > 0)
            {
                _recordData.GEBE_IZLEM.FETUS_KALP_SESI_BILGISI = new List<FETUS_KALP_SESI_BILGISI>();
                foreach (FetusFollow fetus in pregnancyFollow.FetusFollow)
                {
                    FETUS_KALP_SESI_BILGISI FETUS_KALP_SESI_BILGISI = new FETUS_KALP_SESI_BILGISI();
                    FETUS_KALP_SESI_BILGISI.FETUS_KALP_SESI.value = fetus.FKA.ToString();
                    _recordData.GEBE_IZLEM.FETUS_KALP_SESI_BILGISI.Add(FETUS_KALP_SESI_BILGISI);
                }
            }


            /* if (pregnancyFollow.PregnancyDangerSign.Count > 0)         TODO Mert isim çakışması
              {
                  foreach(PregnancyDangerSign dangerSign in pregnancyFollow.PregnancyDangerSign)
                  {
                      GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI = new GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI();
                      GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI.
                  }
              }*/

            //if (pregnancyFollow.Pregnancy.PregnancyNotification.Count > 0)
            //{
            //    foreach (PregnancyNotification notification in pregnancyFollow.Pregnancy.PregnancyNotification)
            //    {
            //        GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI = new GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI();
            //        GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI.GEBE_BILGILENDIRME_VE_DANISMANLIK = new GEBE_BILGILENDIRME_VE_DANISMANLIK(notification.Notification.KODU, notification.Notification.ADI);
            //        _recordData.GEBE_IZLEM.GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI.Add(GEBE_BILGILENDIRME_VE_DANISMANLIK_BILGISI);
            //    }
            //}

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.GEBE_IZLEM.KACINCI_GEBE_IZLEM = new KACINCI_GEBE_IZLEM("1", "1.DÖNEM(0-14 HAFTA)");
            _recordData.GEBE_IZLEM.DEMIR_LOJISTIGI_VE_DESTEGI = new DEMIR_LOJISTIGI_VE_DESTEGI("4", "YENI BAŞLANDI (REÇETE ILE)");
            _recordData.GEBE_IZLEM.D_VITAMINI_LOJISTIGI_VE_DESTEGI = new D_VITAMINI_LOJISTIGI_VE_DESTEGI("7", "YENI BAŞLANDI (REÇETE ILE)");
            _recordData.GEBE_IZLEM.IZLEM_ISLEM_TURU = new IZLEM_ISLEM_TURU("1", "GERÇEK ZAMANLI");
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }

}
