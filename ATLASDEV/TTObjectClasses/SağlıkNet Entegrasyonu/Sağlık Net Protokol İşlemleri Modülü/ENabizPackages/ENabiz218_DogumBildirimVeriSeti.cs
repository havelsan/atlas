using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz218_DogumBildirimVeriSeti
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
                messageType.code = "218";
                messageType.value = "Dogum Bildirim Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public DOGUM_BILDIRIM DOGUM_BILDIRIM = new DOGUM_BILDIRIM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class DOGUM_BILDIRIM
        {
            public AGIRLIK AGIRLIK = new AGIRLIK();//Zorunlu
            public APGAR_1 APGAR_1;
            public APGAR_5 APGAR_5;
            public BAS_CEVRESI BAS_CEVRESI = new BAS_CEVRESI();//Zorunlu
            public DOGUM_SIRASI DOGUM_SIRASI = new DOGUM_SIRASI();//Zorunlu
            public DOGUM_YONTEMI DOGUM_YONTEMI = new DOGUM_YONTEMI();//Zorunlu
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI; //Format : ToString("yyyyMMddHHmm")
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI;
            [System.Xml.Serialization.XmlElement("KOMPLIKASYON_TANISI_BILGISI", Type = typeof(KOMPLIKASYON_TANISI_BILGISI))]
            public List<KOMPLIKASYON_TANISI_BILGISI> KOMPLIKASYON_TANISI_BILGISI; //ICD Kodu
        }

        public class KOMPLIKASYON_TANISI_BILGISI
        {
            public KOMPLIKASYON_TANISI KOMPLIKASYON_TANISI; //Dökuman onlineda üç tane aynı alandan var denenmesi gerekiyor.
       
        }
        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //TODO Doğum bildirim yapıldıktan sonra eklenecek
            recordData _recordData = new recordData();

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.DOGUM_BILDIRIM.AGIRLIK.value = "100";
            _recordData.DOGUM_BILDIRIM.BAS_CEVRESI.value = "100";
            _recordData.DOGUM_BILDIRIM.DOGUM_SIRASI.value = "1";
            _recordData.DOGUM_BILDIRIM.DOGUM_YONTEMI = new DOGUM_YONTEMI("1", "NORMAL DOĞUM");
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }
    }
}
