using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz238_LohusaIzlemVeriSeti
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
                messageType.code = "238";
                messageType.value = "Lohusa Izlem Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public LOHUSA_IZLEM LOHUSA_IZLEM = new LOHUSA_IZLEM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class LOHUSA_IZLEM
        {
            public IZLEMIN_YAPILDIGI_YER IZLEMIN_YAPILDIGI_YER = new IZLEMIN_YAPILDIGI_YER();//Zorunlu
            public KACINCI_LOHUSA_IZLEM KACINCI_LOHUSA_IZLEM = new KACINCI_LOHUSA_IZLEM();//Zorunlu
            public DEMIR_LOJISTIGI_VE_DESTEGI DEMIR_LOJISTIGI_VE_DESTEGI = new DEMIR_LOJISTIGI_VE_DESTEGI();//Zorunlu
            public D_VITAMINI_LOJISTIGI_VE_DESTEGI D_VITAMINI_LOJISTIGI_VE_DESTEGI = new D_VITAMINI_LOJISTIGI_VE_DESTEGI();//Zorunlu
            public GEBELIK_SONLANMA_TARIHI GEBELIK_SONLANMA_TARIHI = new GEBELIK_SONLANMA_TARIHI();//Zorunlu Format : ToString("yyyyMMddHHmm")
            public POSTPARTUM_DEPRESYON POSTPARTUM_DEPRESYON = new POSTPARTUM_DEPRESYON();//Zorunlu
            public UTERUS_INVOLUSYON UTERUS_INVOLUSYON = new UTERUS_INVOLUSYON();//Zorunlu
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI; //Format : ToString("yyyyMMddHHmm")
            public ISLEM_YAPAN ISLEM_YAPAN; //TC
            public BILGI_ALINAN_KISI_ADI_SOYADI BILGI_ALINAN_KISI_ADI_SOYADI; 
            public BILGI_ALINAN_KISI_TEL BILGI_ALINAN_KISI_TEL;
            public KONJENITAL_ANOMALILI_DOGUM_VARLIGI KONJENITAL_ANOMALILI_DOGUM_VARLIGI;
            public HEMOGLOBIN HEMOGLOBIN;
            public KOMPLIKASYON_TANISI_BILGISI KOMPLIKASYON_TANISI_BILGISI; //ICD Kodu
            public GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI_BILGISI GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI_BILGISI;
            [System.Xml.Serialization.XmlElement("KADIN_SAGLIGI_ISLEMLERI_BILGISI", Type = typeof(KADIN_SAGLIGI_ISLEMLERI_BILGISI))]
            public List<KADIN_SAGLIGI_ISLEMLERI_BILGISI> KADIN_SAGLIGI_ISLEMLERI_BILGISI; 

        }
        public class KOMPLIKASYON_TANISI_BILGISI
        {
            public KOMPLIKASYON_TANISI KOMPLIKASYON_TANISI; //Dökuman onlineda üç tane aynı alandan var denenmesi gerekiyor.

        }
        public class GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI_BILGISI
        {
            public GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI; //Dökuman onlineda üç tane aynı alandan var denenmesi gerekiyor.

        }

        public class KADIN_SAGLIGI_ISLEMLERI_BILGISI
        {
            public KADIN_SAGLIGI_ISLEMLERI KADIN_SAGLIGI_ISLEMLERI;//Dökuman onlineda üç tane aynı alandan var denenmesi gerekiyor.
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {

            recordData _recordData = new recordData();

            using (var objectContext = new TTObjectContext(false))
            {

                /*DUMMY*/
                
            }


            //TODO Lohusa ekranları yapıldıktan sonra eklenecek

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.LOHUSA_IZLEM.KACINCI_LOHUSA_IZLEM = new KACINCI_LOHUSA_IZLEM("4", "4. IZLEM (EV / SAĞLIK MERKEZI) (GÜN)");

            _recordData.LOHUSA_IZLEM.DEMIR_LOJISTIGI_VE_DESTEGI = new DEMIR_LOJISTIGI_VE_DESTEGI("6", "DEVAM EDILIYOR (REÇETE ILE)");
            _recordData.LOHUSA_IZLEM.D_VITAMINI_LOJISTIGI_VE_DESTEGI = new D_VITAMINI_LOJISTIGI_VE_DESTEGI("7", "YENI BAŞLANDI (REÇETE ILE)");
            _recordData.LOHUSA_IZLEM.GEBELIK_SONLANMA_TARIHI = new GEBELIK_SONLANMA_TARIHI();
            _recordData.LOHUSA_IZLEM.GEBELIK_SONLANMA_TARIHI.value = "201801010000";
            _recordData.LOHUSA_IZLEM.POSTPARTUM_DEPRESYON = new POSTPARTUM_DEPRESYON("1", "1-12 NORMAL");
            _recordData.LOHUSA_IZLEM.UTERUS_INVOLUSYON = new UTERUS_INVOLUSYON("2", "UTERUS İNVOLÜSYON TAKİBİ YAPİLMADİ.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            _recordData.LOHUSA_IZLEM.IZLEMIN_YAPILDIGI_YER = myTesisSKRSKurumlarDefinition != null ? new IZLEMIN_YAPILDIGI_YER(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI) : null;

            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
