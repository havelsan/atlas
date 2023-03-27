using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz258_CocukDiyabetIzlem
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
                messageType.code = "258";
                messageType.value = "Çocuk Diyabet İzlem";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public COCUK_DIYABET_IZLEM COCUK_DIYABET_IZLEM = new COCUK_DIYABET_IZLEM();

        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class COCUK_DIYABET_IZLEM
        {
            public TANNER_EVRE TANNER_EVRE;
            public TIROID_MUAYENESI TIROID_MUAYENESI;
            public DIYABET_TIPI DIYABET_TIPI;
            public DIYABET_ILAC_TEDAVI_SEKLI DIYABET_ILAC_TEDAVI_SEKLI;
            public DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI;
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI;

            [System.Xml.Serialization.XmlElement("DIYABET_KOMPLIKASYONLARI", Type = typeof(DIYABET_KOMPLIKASYONLARI))]
            public List<DIYABET_KOMPLIKASYONLARI> DIYABET_KOMPLIKASYONLARI = new List<DIYABET_KOMPLIKASYONLARI>();
            [System.Xml.Serialization.XmlElement("ESLIK_EDEN_BASKA_HASTALIK", Type = typeof(ESLIK_EDEN_BASKA_HASTALIK))]
            public List<ESLIK_EDEN_BASKA_HASTALIK> ESLIK_EDEN_BASKA_HASTALIK = new List<ESLIK_EDEN_BASKA_HASTALIK>();
        }

        public class BOY_KILO_BILGILERI
        {
            public BOY BOY;
            public KILO KILO;
        }

        public static SYSMessage GetDummy()
        {

            recordData _recordData = new recordData();
            _recordData.COCUK_DIYABET_IZLEM.TIROID_MUAYENESI = new TIROID_MUAYENESI("99", "BELİRTİLMEDİ");
            _recordData.COCUK_DIYABET_IZLEM.DIYABET_TIPI = new DIYABET_TIPI("4", "DIĞER");
            _recordData.COCUK_DIYABET_IZLEM.DIYABET_ILAC_TEDAVI_SEKLI = new DIYABET_ILAC_TEDAVI_SEKLI("1", "İNSÜLİN");

            
            ESLIK_EDEN_BASKA_HASTALIK hastalik = new ESLIK_EDEN_BASKA_HASTALIK("9", "YOK");
            _recordData.COCUK_DIYABET_IZLEM.ESLIK_EDEN_BASKA_HASTALIK.Add(hastalik);
           
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
