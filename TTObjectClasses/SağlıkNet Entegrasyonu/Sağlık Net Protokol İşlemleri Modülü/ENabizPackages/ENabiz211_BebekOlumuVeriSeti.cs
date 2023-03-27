using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;
namespace TTObjectClasses
{
    public class ENabiz211_BebekOlumuVeriSeti
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
                messageType.code = "211";
                messageType.value = TTUtils.CultureService.GetText("M25264", "Bebek Olumu Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public BEBEK_OLUMU BEBEK_OLUMU = new BEBEK_OLUMU();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class BEBEK_OLUMU
        {
            public AGIRLIK AGIRLIK = new AGIRLIK();//Zorunlu
            public BEBEK_OLUM_NEDENLERI BEBEK_OLUM_NEDENLERI = new BEBEK_OLUM_NEDENLERI();//Zorunlu
            public DOGUMUN_GERCEKLESTIGI_YER DOGUMUN_GERCEKLESTIGI_YER = new DOGUMUN_GERCEKLESTIGI_YER();//Zorunlu
            public DOGUM_AGIRLIGI DOGUM_AGIRLIGI = new DOGUM_AGIRLIGI();//Zorunlu
            public DOGUM_GEBELIK_SONLANMA_HAFTASI DOGUM_GEBELIK_SONLANMA_HAFTASI = new DOGUM_GEBELIK_SONLANMA_HAFTASI();//Zorunlu
            public DOGUM_YONTEMI DOGUM_YONTEMI = new DOGUM_YONTEMI();//Zorunlu
            public DOGUM_ZAMANI DOGUM_ZAMANI; //Format : ToString("yyyyMMddHHmm")
            public GEBELIK_ARALIGI GEBELIK_ARALIGI = new GEBELIK_ARALIGI();//Zorunlu
            public KACINCI_GEBELIK KACINCI_GEBELIK = new KACINCI_GEBELIK();//Zorunlu
            public OLUM_TARIHI OLUM_TARIHI = new OLUM_TARIHI();//Zorunlu Format : ToString("yyyyMMddHHmm")
        }
        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //TODO Bebek ekranları yapıldıktan sonra eklenecek
            recordData _recordData = new recordData();

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.BEBEK_OLUMU.AGIRLIK.value = "100";
            _recordData.BEBEK_OLUMU.BEBEK_OLUM_NEDENLERI = new BEBEK_OLUM_NEDENLERI("1", "ANEMİ");
            _recordData.BEBEK_OLUMU.DOGUMUN_GERCEKLESTIGI_YER = new DOGUMUN_GERCEKLESTIGI_YER("1", "EVDE");
            _recordData.BEBEK_OLUMU.DOGUM_AGIRLIGI.value = "100";
            _recordData.BEBEK_OLUMU.DOGUM_GEBELIK_SONLANMA_HAFTASI.value = "1";
            _recordData.BEBEK_OLUMU.DOGUM_YONTEMI = new DOGUM_YONTEMI("1", "NORMAL DOĞUM");
            _recordData.BEBEK_OLUMU.GEBELIK_ARALIGI = new GEBELIK_ARALIGI("5", "BİLİNMİYOR");
            _recordData.BEBEK_OLUMU.KACINCI_GEBELIK.value = "1";
            _recordData.BEBEK_OLUMU.OLUM_TARIHI.value = "201801010000";
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
