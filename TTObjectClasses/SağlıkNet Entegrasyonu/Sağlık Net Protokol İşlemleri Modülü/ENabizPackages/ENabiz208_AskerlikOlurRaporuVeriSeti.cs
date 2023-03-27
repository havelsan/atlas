using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz208_XXXXXXlikOlurRaporuVeriSeti
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
                messageType.code = "208";
                messageType.value = "XXXXXXlik Olur Raporu Veri Seti";
            }

        }
        public class recordData
        {

            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public XXXXXXLIK_OLUR_RAPORU XXXXXXLIK_OLUR_RAPORU = new XXXXXXLIK_OLUR_RAPORU();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();

        }

        public class XXXXXXLIK_OLUR_RAPORU
        {
            public ACIKLAMA ACIKLAMA;
            public ALKOL_MADDE_BAGIMLILIGI ALKOL_MADDE_BAGIMLILIGI;
            public BEDENSEL_RUHSAL_ILERI_TETKIK_BULGUSU BEDENSEL_RUHSAL_ILERI_TETKIK_BULGUSU;
            public GECMIS_HASTALIGA_DAIR_KAYIT GECMIS_HASTALIGA_DAIR_KAYIT;
            public GORME_ISITME_KAYBI GORME_ISITME_KAYBI;
            public KAN_GRUBU KAN_GRUBU;
            public PSIKIYATRIK_RAHATSIZLIK PSIKIYATRIK_RAHATSIZLIK;
            public UZUV_KAYBI_ORTOPEDIK_RAHATSIZLIK UZUV_KAYBI_ORTOPEDIK_RAHATSIZLIK;
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI;
            [System.Xml.Serialization.XmlElement("HASTALIK_BILGISI", Type = typeof(HASTALIK_BILGISI))]
            public List<HASTALIK_BILGISI> HASTALIK_BILGISI = new List<HASTALIK_BILGISI>();
        }

        public class HASTALIK_BILGISI
        {
            public ASAL_HASTALIK ASAL_HASTALIK;
            public ASAL_HASTALIK_TIPI ASAL_HASTALIK_TIPI;
        }

        public class BOY_KILO_BILGILERI
        {
            public BOY BOY;
            public KILO KILO;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.XXXXXXLIK_OLUR_RAPORU.UZUV_KAYBI_ORTOPEDIK_RAHATSIZLIK = new UZUV_KAYBI_ORTOPEDIK_RAHATSIZLIK("2","HAYIR");
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
