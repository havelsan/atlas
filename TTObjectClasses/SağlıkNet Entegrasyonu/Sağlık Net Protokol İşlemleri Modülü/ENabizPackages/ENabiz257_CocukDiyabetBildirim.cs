using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz257_CocukDiyabetBildirim
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
                messageType.code = "257";
                messageType.value = "Çocuk Diyabet Bildirim";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public COCUK_DIYABET_BILDIRIM COCUK_DIYABET_BILDIRIM = new COCUK_DIYABET_BILDIRIM();

        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class COCUK_DIYABET_BILDIRIM
        {
            public ILK_TANI_TARIHI ILK_TANI_TARIHI;
            public DIYABET_TIPI DIYABET_TIPI;
            public KIZ_COCUKLARDA_MENARS_YASI KIZ_COCUKLARDA_MENARS_YASI;
            public BEYIN_ODEMI BEYIN_ODEMI;
            public DIYABET_ILAC_TEDAVI_SEKLI DIYABET_ILAC_TEDAVI_SEKLI;
            public KETOASIDOZ_SON_3_AY KETOASIDOZ_SON_3_AY;
            public DIYABET_EGITIMI DIYABET_EGITIMI;
            public TIROID_MUAYENESI TIROID_MUAYENESI;
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI;
            public KILLANMA_DURUM_BILGILERI KILLANMA_DURUM_BILGILERI;
            public DIYABET_EVRE_BILGILERI DIYABET_EVRE_BILGILERI;
            public TESTIS_VOLUM_BILGILERI TESTIS_VOLUM_BILGILERI;

            [System.Xml.Serialization.XmlElement("DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI", Type = typeof(DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI))]
            public List<DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI> DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI = new List<DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI>();
            [System.Xml.Serialization.XmlElement("DIYABETLI_HASTA_AILE_OYKUSU", Type = typeof(DIYABETLI_HASTA_AILE_OYKUSU))]
            public List<DIYABETLI_HASTA_AILE_OYKUSU> DIYABETLI_HASTA_AILE_OYKUSU = new List<DIYABETLI_HASTA_AILE_OYKUSU>();
            [System.Xml.Serialization.XmlElement("DIYABET_SIKAYET_BILGISI", Type = typeof(DIYABET_SIKAYET_BILGISI))]
            public List<DIYABET_SIKAYET_BILGISI> DIYABET_SIKAYET_BILGISI;
            [System.Xml.Serialization.XmlElement("ESLIK_EDEN_HASTALIK_BILGILERI", Type = typeof(ESLIK_EDEN_HASTALIK_BILGILERI))]
            public List<ESLIK_EDEN_HASTALIK_BILGILERI> ESLIK_EDEN_HASTALIK_BILGILERI;

        }

        public class DIYABET_SIKAYET_BILGISI
        {
            public SIKAYET SIKAYET;
            public SIKAYETIN_SURESI SIKAYETIN_SURESI;
        }

        public class KILLANMA_DURUM_BILGILERI
        {
            public AXILLER_KILLANMA AXILLER_KILLANMA;
            public PUBIK_KILLANMA PUBIK_KILLANMA;
        }

        public class DIYABET_EVRE_BILGILERI
        {
            public TANNER_EVRE TANNER_EVRE;
            public MEME_EVRE MEME_EVRE;
        }

        public class TESTIS_VOLUM_BILGILERI
        {
            public TESTIS_VOLUM_SAG TESTIS_VOLUM_SAG;
            public TESTIS_VOLUM_SOL TESTIS_VOLUM_SOL;
        }

        public class ESLIK_EDEN_HASTALIK_BILGILERI
        {
            public ESLIK_EDEN_BASKA_HASTALIK ESLIK_EDEN_BASKA_HASTALIK;
            public ESLIK_EDEN_BASKA_HASTALIK_TANI_TARIHI ESLIK_EDEN_BASKA_HASTALIK_TANI_TARIHI;
        }

        public class BOY_KILO_BILGILERI
        {
            public BOY BOY;
            public KILO KILO;   
        }


        public static SYSMessage GetDummy()
        {

            recordData _recordData = new recordData();
            _recordData.COCUK_DIYABET_BILDIRIM.ILK_TANI_TARIHI = new ILK_TANI_TARIHI();
            _recordData.COCUK_DIYABET_BILDIRIM.ILK_TANI_TARIHI.value = "201801010000";
            _recordData.COCUK_DIYABET_BILDIRIM.DIYABET_TIPI = new DIYABET_TIPI("4", "DIĞER");
            _recordData.COCUK_DIYABET_BILDIRIM.BEYIN_ODEMI = new BEYIN_ODEMI("2","YOK");
            _recordData.COCUK_DIYABET_BILDIRIM.DIYABET_ILAC_TEDAVI_SEKLI = new DIYABET_ILAC_TEDAVI_SEKLI("1", "İNSÜLİN");
            _recordData.COCUK_DIYABET_BILDIRIM.KETOASIDOZ_SON_3_AY = new KETOASIDOZ_SON_3_AY("2", "YOK");
            _recordData.COCUK_DIYABET_BILDIRIM.TIROID_MUAYENESI = new TIROID_MUAYENESI("99", "BELİRTİLMEDİ");
            DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI tedavi = new DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI("97", "YOK");
            _recordData.COCUK_DIYABET_BILDIRIM.DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI.Add(tedavi);
            DIYABETLI_HASTA_AILE_OYKUSU oyku = new DIYABETLI_HASTA_AILE_OYKUSU("97", "YOK");
            _recordData.COCUK_DIYABET_BILDIRIM.DIYABETLI_HASTA_AILE_OYKUSU.Add(oyku);
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
