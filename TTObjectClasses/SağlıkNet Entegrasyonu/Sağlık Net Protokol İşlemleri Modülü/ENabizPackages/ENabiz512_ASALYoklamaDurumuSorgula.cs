using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz512_ASALYoklamaDurumuSorgula
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
                messageType.code = "512";
                messageType.value = "ASAL Yoklama Durumu Sorgula";
            }

        }
        public class recordData
        {
            public ASAL_YOKLAMA_DURUM_SORGULAMA ASAL_YOKLAMA_DURUM_SORGULAMA = new ASAL_YOKLAMA_DURUM_SORGULAMA();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class ASAL_YOKLAMA_DURUM_SORGULAMA
        {
            public HASTA_KIMLIK_NUMARASI HASTA_KIMLIK_NUMARASI = new HASTA_KIMLIK_NUMARASI();
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.ASAL_YOKLAMA_DURUM_SORGULAMA.HASTA_KIMLIK_NUMARASI.value = "10000000000";
            _recordData.ASAL_YOKLAMA_DURUM_SORGULAMA.HEKIM_KIMLIK_NUMARASI.value = "10000000000";
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
