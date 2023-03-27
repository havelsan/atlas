using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz202_15_49YasKadinIzlemVeriSeti
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
                messageType.code = "202";
                messageType.value = "15 - 49 Yas Kadin Izlem Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public KADIN_IZLEM_15_49_YAS KADIN_IZLEM_15_49_YAS = new KADIN_IZLEM_15_49_YAS();

        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class KADIN_IZLEM_15_49_YAS
        {
            public KONJENITAL_ANOMALILI_DOGUM_VARLIGI KONJENITAL_ANOMALILI_DOGUM_VARLIGI;
            public CANLI_DOGAN_BEBEK_SAYISI CANLI_DOGAN_BEBEK_SAYISI;
            public HEMOGLOBIN HEMOGLOBIN;
            public OLU_DOGAN_BEBEK_SAYISI OLU_DOGAN_BEBEK_SAYISI;
            public BIR_ONCEKI_DOGUM_DURUMU BIR_ONCEKI_DOGUM_DURUMU = new BIR_ONCEKI_DOGUM_DURUMU(); //Zorunlu
            public IZLEMIN_YAPILDIGI_YER IZLEMIN_YAPILDIGI_YER = new IZLEMIN_YAPILDIGI_YER(); //Zorunlu
            public KULLANILAN_AILE_PLANLAMASI_YONTEMI KULLANILAN_AILE_PLANLAMASI_YONTEMI;
            public AILE_PLANLAMASI_YONTEMI_LOJISTIGI AILE_PLANLAMASI_YONTEMI_LOJISTIGI;
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI;
            public ISLEM_YAPAN ISLEM_YAPAN;
            public BILGI_ALINAN_KISI_ADI_SOYADI BILGI_ALINAN_KISI_ADI_SOYADI;
            public BILGI_ALINAN_KISI_TEL BILGI_ALINAN_KISI_TEL;

            [System.Xml.Serialization.XmlElement("KADIN_SAGLIGI_ISLEMLERI_BILGISI", Type = typeof(KADIN_SAGLIGI_ISLEMLERI_BILGISI))]
            public List<KADIN_SAGLIGI_ISLEMLERI_BILGISI> KADIN_SAGLIGI_ISLEMLERI_BILGISI;

            [System.Xml.Serialization.XmlElement("AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI_BILGISI", Type = typeof(AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI_BILGISI))]
            public List<AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI_BILGISI> AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI_BILGISI;

            [System.Xml.Serialization.XmlElement("BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI_BILGISI", Type = typeof(BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI_BILGISI))]
            public List<BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI_BILGISI> BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI_BILGISI;

        }

        public class KADIN_SAGLIGI_ISLEMLERI_BILGISI
        {
            public KADIN_SAGLIGI_ISLEMLERI KADIN_SAGLIGI_ISLEMLERI;
        }
        public class AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI_BILGISI
        {
            public AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI;
        }
        public class BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI_BILGISI
        {
            public BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI;
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();

            using (var objectContext = new TTObjectContext(false))
            {
                
                /*DUMMY*/
               
            }

            




            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.KADIN_IZLEM_15_49_YAS.BIR_ONCEKI_DOGUM_DURUMU = new BIR_ONCEKI_DOGUM_DURUMU("2", "DAHA ÖNCE DOGUM YAPMAMİS");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            _recordData.KADIN_IZLEM_15_49_YAS.IZLEMIN_YAPILDIGI_YER = myTesisSKRSKurumlarDefinition != null ? new IZLEMIN_YAPILDIGI_YER(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI) : null;

            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }


    }
}


