using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz225_GenclikSagligiIzlemVeriSeti
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
                messageType.code = "225";
                messageType.value = "Genclik Sagligi Izlem Veri Seti";
            }
        }
        public class recordData
        {
            public GENCLIK_SAGLIG_IZLEM GENCLIK_SAGLIG_IZLEM = new GENCLIK_SAGLIG_IZLEM();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class GENCLIK_SAGLIG_IZLEM
        {
            [System.Xml.Serialization.XmlElement("GENCLIK_SAGLIGI_ISLEMLERI_BILGISI", Type = typeof(GENCLIK_SAGLIGI_ISLEMLERI_BILGISI))]
            public List<GENCLIK_SAGLIGI_ISLEMLERI_BILGISI> GENCLIK_SAGLIGI_ISLEMLERI_BILGISI = new List<GENCLIK_SAGLIGI_ISLEMLERI_BILGISI>();
        }

        public class GENCLIK_SAGLIGI_ISLEMLERI_BILGISI
        {
            public GENCLIK_SAGLIGI_ISLEMLERI GENCLIK_SAGLIGI_ISLEMLERI;
        }


        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();


            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }
    }
}
