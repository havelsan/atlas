using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz224_GebelikSonucuVeriSeti
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
                messageType.code = "224";
                messageType.value = "Gebelik Sonucu Veri Seti";
            }
        }
        public class recordData
        {
            public GEBELIK_SONUCU_VERI_SETI GEBELIK_SONUCU_VERI_SETI = new GEBELIK_SONUCU_VERI_SETI();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class GEBELIK_SONUCU_VERI_SETI
        {
            public CANLI_DOGAN_BEBEK_SAYISI CANLI_DOGAN_BEBEK_SAYISI;
            public DOGUMA_YARDIM_EDEN DOGUMA_YARDIM_EDEN;
            public DOGUMUN_GERCEKLESTIGI_YER DOGUMUN_GERCEKLESTIGI_YER;
            public DOGUM_YONTEMI DOGUM_YONTEMI;
            public GEBELIK_SONLANMA_TARIHI GEBELIK_SONLANMA_TARIHI = new GEBELIK_SONLANMA_TARIHI();
            public GEBELIK_SONUCU GEBELIK_SONUCU = new GEBELIK_SONUCU();
            public OLU_DOGAN_BEBEK_SAYISI OLU_DOGAN_BEBEK_SAYISI;
            public SEZARYAN_ENDIKASYON SEZERYAN_ENDIKASYON;

            [System.Xml.Serialization.XmlElement("ENDIKASYON_NEDENLERI_BILGISI", Type = typeof(ENDIKASYON_NEDENLERI_BILGISI))]
            public List<ENDIKASYON_NEDENLERI_BILGISI> ENDIKASYON_NEDENLERI_BILGISI;
        }
        public class ENDIKASYON_NEDENLERI_BILGISI
        {
            public ENDIKASYON_NEDENLERI ENDIKASYON_NEDENLERI;
        }

        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            recordData _recordData = new recordData();
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            if (myTesisSKRSKurumlarDefinition == null)
                throw new Exception(TTUtils.CultureService.GetText("M26897", "SKRS Kurum Bilgisi bulunamadı lütfen ilgili sistem parametresini düzeltin"));

            Pregnancy pregnancyObject = (Pregnancy)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);

            if (pregnancyObject.StarterWomanSpecialityObject.PhysicianApplication.SubEpisode.SYSTakipNo == null)      //SYSTakipNo
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = pregnancyObject.StarterWomanSpecialityObject.PhysicianApplication.SubEpisode.SYSTakipNo;

            int livingBabies = 0, deadBabies = 0;
            foreach (PregnancyResult pregnancyResult in pregnancyObject.PregnancyResults)
            {
                if (Int32.Parse(pregnancyResult.BabyStatus.Value.ToString()) == 1)
                    livingBabies++;
                else
                    deadBabies++;
            }

            _recordData.GEBELIK_SONUCU_VERI_SETI.CANLI_DOGAN_BEBEK_SAYISI.value = livingBabies.ToString();
            _recordData.GEBELIK_SONUCU_VERI_SETI.OLU_DOGAN_BEBEK_SAYISI.value = livingBabies.ToString();

            if (pregnancyObject.PregnancyResults[0].BirthResult != null)
            {
                _recordData.GEBELIK_SONUCU_VERI_SETI.GEBELIK_SONUCU = new GEBELIK_SONUCU(pregnancyObject.PregnancyResults[0].BirthResult.KODU, pregnancyObject.PregnancyResults[0].BirthResult.ADI);
            }

            if (pregnancyObject.BirthTerminationDate != null)
            {
                _recordData.GEBELIK_SONUCU_VERI_SETI.GEBELIK_SONLANMA_TARIHI.value = pregnancyObject.BirthTerminationDate.Value.ToString("yyyyMMddHHmm");
            }
            if (pregnancyObject.BirthLocation != null)
            {
                _recordData.GEBELIK_SONUCU_VERI_SETI.DOGUMUN_GERCEKLESTIGI_YER = new DOGUMUN_GERCEKLESTIGI_YER(pregnancyObject.BirthLocation.KODU, pregnancyObject.BirthLocation.ADI);
            }
            if (pregnancyObject.BirthHelper != null)
            {
                _recordData.GEBELIK_SONUCU_VERI_SETI.DOGUMA_YARDIM_EDEN = new DOGUMA_YARDIM_EDEN(pregnancyObject.BirthHelper.KODU, pregnancyObject.BirthHelper.ADI);
            }
            if (pregnancyObject.BirthType != null)
            {
                _recordData.GEBELIK_SONUCU_VERI_SETI.DOGUM_YONTEMI = new DOGUM_YONTEMI(pregnancyObject.BirthType.KODU, pregnancyObject.BirthType.ADI);
            }
            if (pregnancyObject.CesareanIndication != null)
            {
                _recordData.GEBELIK_SONUCU_VERI_SETI.SEZERYAN_ENDIKASYON = new SEZARYAN_ENDIKASYON(pregnancyObject.CesareanIndication.KODU, pregnancyObject.CesareanIndication.ADI);
            }
            if (pregnancyObject.IndicationReasons != null)
            {
                _recordData.GEBELIK_SONUCU_VERI_SETI.ENDIKASYON_NEDENLERI_BILGISI = new List<ENDIKASYON_NEDENLERI_BILGISI>();
                foreach (IndicationReason indication in pregnancyObject.IndicationReasons)
                {
                    ENDIKASYON_NEDENLERI_BILGISI ENDIKASYON_NEDENLERI_BILGISI = new ENDIKASYON_NEDENLERI_BILGISI();
                    ENDIKASYON_NEDENLERI_BILGISI.ENDIKASYON_NEDENLERI = new ENDIKASYON_NEDENLERI(indication.Indications.KODU, indication.Indications.ADI);
                    _recordData.GEBELIK_SONUCU_VERI_SETI.ENDIKASYON_NEDENLERI_BILGISI.Add(ENDIKASYON_NEDENLERI_BILGISI);
                }
            }



            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.GEBELIK_SONUCU_VERI_SETI.GEBELIK_SONLANMA_TARIHI.value = "201801010000";

            _recordData.GEBELIK_SONUCU_VERI_SETI.GEBELIK_SONUCU = new GEBELIK_SONUCU("1", "DOĞUM");
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
