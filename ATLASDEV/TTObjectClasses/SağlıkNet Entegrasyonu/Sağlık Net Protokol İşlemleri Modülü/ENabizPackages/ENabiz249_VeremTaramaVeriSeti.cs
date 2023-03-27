using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz249_VeremTaramaVeriSeti
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
                messageType.code = "249";
                messageType.value = "Verem Tarama Veri Seti";
            }

        }
        public class recordData
        {

            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public VEREM_TARAMA VEREM_TARAMA = new VEREM_TARAMA();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();

        }

        public class VEREM_TARAMA
        {
            public VEREM_TARAMA_SONUCU VEREM_TARAMA_SONUCU;
            public HASTA_KIMLIK_NUMARASI HASTA_KIMLIK_NUMARASI = new HASTA_KIMLIK_NUMARASI();
            public TARAMA_TURU TARAMA_TURU;
        }


        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.VEREM_TARAMA.VEREM_TARAMA_SONUCU = new VEREM_TARAMA_SONUCU("4", "DİĞER");
            _recordData.VEREM_TARAMA.TARAMA_TURU = new TARAMA_TURU("1", "EV (TEMASLI)");
            _recordData.VEREM_TARAMA.HASTA_KIMLIK_NUMARASI.value = "10000000000";
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
