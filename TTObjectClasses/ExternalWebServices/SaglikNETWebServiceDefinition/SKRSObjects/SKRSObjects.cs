
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class SKRSObjects : TTObject
    {
#region Methods
        public class ValueBase
        {
            [System.Xml.Serialization.XmlAttribute("value")]
            public string value { get; set; }

            public ValueBase()
            {
                value = "";
            }
        }

        public class CodeBase
        {
            [System.Xml.Serialization.XmlAttribute("version")]
            public string version { get; set; }

            [System.Xml.Serialization.XmlAttribute("codeSystemGuid")]
            public string codeSystemGuid { get; set; }

            [System.Xml.Serialization.XmlAttribute("code")]
            public string code { get; set; }

            [System.Xml.Serialization.XmlAttribute("value")]
            public string value { get; set; }
        }


        public class SYSSendMessage
        {
            public input input = new input();
        }

        public class input
        {
            public SYSMessage SYSMessage = new SYSMessage();
        }

        public class messageGuid : ValueBase
        {
        }

        public class messageType : CodeBase
        {
            public messageType()
            {
                codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
                version = "1";
            }
            public messageType(int Code, string Value)
            {
                codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
                version = "1";
                code = Code.ToString();
                value = Value;

            }
        }

        public class documentGenerationTime : ValueBase
        {
            public documentGenerationTime()
            {
                value = DateTime.Now.ToString("yyyyMMddHHmm");
            }
        }

        public class healthcareProvider : CodeBase
        {
            public healthcareProvider()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }

            public healthcareProvider(int Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code.ToString();
                value = Value;

            }
        }

        public class author
        {
            public healthcareProvider healthcareProvider = new healthcareProvider(999997, "TEST DEVLET XXXXXXSİ");
        }

        public class firmaKodu : ValueBase
        {
            public firmaKodu()
            {
                value = "C740D0288F1DC45FE0407C0A04162BDD";
                //value = "2792D444BCC85596E05307167C0A6340";
            }
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
                messageType.code = "101";
                messageType.value = "Hasta Kayıt";
            }
        }

        public class AMBULANS_TAKIP_NUMARASI : ValueBase { }
        public class KAYIT_YERI : CodeBase
        {
            public KAYIT_YERI()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }
            public KAYIT_YERI(int Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class HIZMET_SUNUCU : CodeBase
        {
            public HIZMET_SUNUCU()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }
            public HIZMET_SUNUCU(int Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class PROTOKOL_NUMARASI : ValueBase { }

        public class XXXXXX_REFERANS_NUMARASI : ValueBase
        {
            public XXXXXX_REFERANS_NUMARASI()
            {
                value = "0";
            }
        }

        public class SGK_TAKIP_NUMARASI : ValueBase { }

        public class KABUL_ZAMANI : ValueBase
        {
            public KABUL_ZAMANI()
            {
                value = DateTime.Now.AddDays(-1).ToString("yyyyMMddHHmm");
            }
        }

        public class KLINIK_KODU : CodeBase
        {
            public KLINIK_KODU()
            {
                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
                version = "1";


            }
            public KLINIK_KODU(int Code, string Value)
            {
                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class SOSYAL_GUVENCE_DURUMU : CodeBase
        {
            public SOSYAL_GUVENCE_DURUMU()
            {
                codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
                version = "1";

            }
            public SOSYAL_GUVENCE_DURUMU(int Code, string Value)
            {
                codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class HEKIM_KIMLIK_NUMARASI : ValueBase { }

        public class VAKA_TURU : CodeBase
        {
            public VAKA_TURU()
            {
                codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
                version = "1";

            }
            public VAKA_TURU(int Code, string Value)
            {
                codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class MHRS_RANDEVU_NUMARASI : ValueBase { }
        public class TRIAJ : ValueBase { }
        public class YATIS_KABUL_ZAMANI : ValueBase { }
        public class YATAK_NO : ValueBase { }
        public class YATIS_GUNUBIRLIK_MI : ValueBase { }

        public class YATISIN_ACILIYETI : CodeBase
        {
            public YATISIN_ACILIYETI()
            {
                codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
                version = "1";

            }
            public YATISIN_ACILIYETI(int Code, string Value)
            {
                codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
                version = "1";
                code = Code.ToString();
                value = Value;

            }

        }

        public class YATIS_BILGISI
        {
            public YATIS_KABUL_ZAMANI YATIS_KABUL_ZAMANI = new YATIS_KABUL_ZAMANI();
            public YATAK_NO YATAK_NO = new YATAK_NO();
            public YATIS_GUNUBIRLIK_MI YATIS_GUNUBIRLIK_MI = new YATIS_GUNUBIRLIK_MI();
            public YATISIN_ACILIYETI YATISIN_ACILIYETI = new YATISIN_ACILIYETI();
        }

        public class SYSTakipNo : ValueBase { }

        public class HASTA_BASVURU_BILGILERI
        {

            public AMBULANS_TAKIP_NUMARASI AMBULANS_TAKIP_NUMARASI = new AMBULANS_TAKIP_NUMARASI();
            public KAYIT_YERI KAYIT_YERI = new KAYIT_YERI();
            public HIZMET_SUNUCU HIZMET_SUNUCU = new HIZMET_SUNUCU();
            public PROTOKOL_NUMARASI PROTOKOL_NUMARASI = new PROTOKOL_NUMARASI();
            public XXXXXX_REFERANS_NUMARASI XXXXXX_REFERANS_NUMARASI = new XXXXXX_REFERANS_NUMARASI();
            public SGK_TAKIP_NUMARASI SGK_TAKIP_NUMARASI = new SGK_TAKIP_NUMARASI();
            public KABUL_ZAMANI KABUL_ZAMANI = new KABUL_ZAMANI();
            public KLINIK_KODU KLINIK_KODU = new KLINIK_KODU();
            public SOSYAL_GUVENCE_DURUMU SOSYAL_GUVENCE_DURUMU = new SOSYAL_GUVENCE_DURUMU();
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
            public VAKA_TURU VAKA_TURU = new VAKA_TURU();
            public MHRS_RANDEVU_NUMARASI MHRS_RANDEVU_NUMARASI = new MHRS_RANDEVU_NUMARASI();
            public TRIAJ TRIAJ = new TRIAJ();
            public YATIS_BILGISI YATIS_BILGISI = new YATIS_BILGISI();
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        
        public class HASTA_KIMLIK_NUMARASI : ValueBase { }
        public class AD : ValueBase { }
        public class SOYAD : ValueBase { }
        public class DOGUM_TARIHI : ValueBase { }
        public class CINSIYET : CodeBase
        {
            public CINSIYET()
            {
                codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
                version = "1";
            }
            public CINSIYET(int Code, string Value)
            {
                codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
                version = "1";
                code = Code.ToString();
                value = Value;

            }
        }
        public class UYRUK : CodeBase
        {
            public UYRUK()
            {
                codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
                version = "1";

            }

            public UYRUK(int Code, string Value)
            {
                codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
                version = "1";
                code = Code.ToString();
                value = Value;

            }
        }
        public class ANNE_KIMLIK_NUMARASI : ValueBase { }
        public class DOGUM_SIRASI : ValueBase { }
        public class YABANCI_HASTA_KIMLIK_NUMARASI : ValueBase { }
        public class PASAPORT_NO : ValueBase { }
        public class KIMLIKSIZ_HASTA_BILGISI : ValueBase { }

        public class ADRES_KODU_SEVIYESI : CodeBase
        {
            public ADRES_KODU_SEVIYESI()
            {
                codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
                version = "1";

            }

            public ADRES_KODU_SEVIYESI(int Code, string Value)
            {
                codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
                version = "1";
                code = Code.ToString();
                value = Value;
            }

        }

        public class ADRES_KODU : ValueBase { }
        public class ACIK_ADRES : ValueBase { }
        public class ACIK_ADRES_IL : ValueBase { }
        public class ACIK_ADRES_ILCE : ValueBase { }

        public class ADRES_BILGISI
        {
            public ADRES_KODU_SEVIYESI ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI();
            public ADRES_KODU ADRES_KODU = new ADRES_KODU();
            public ACIK_ADRES ACIK_ADRES = new ACIK_ADRES();
            public ACIK_ADRES_IL ACIK_ADRES_IL = new ACIK_ADRES_IL();
            public ACIK_ADRES_ILCE ACIK_ADRES_ILCE = new ACIK_ADRES_ILCE();
        }


        public class HASTA_KIMLIK_BILGILERI
        {

            public HASTA_KIMLIK_NUMARASI HASTA_KIMLIK_NUMARASI = new HASTA_KIMLIK_NUMARASI();
            public AD AD = new AD();
            public SOYAD SOYAD = new SOYAD();
            public DOGUM_TARIHI DOGUM_TARIHI = new DOGUM_TARIHI();
            public CINSIYET CINSIYET = new CINSIYET();
            public UYRUK UYRUK = new UYRUK();
            public ANNE_KIMLIK_NUMARASI ANNE_KIMLIK_NUMARASI = new ANNE_KIMLIK_NUMARASI();
            public DOGUM_SIRASI DOGUM_SIRASI = new DOGUM_SIRASI();
            public YABANCI_HASTA_KIMLIK_NUMARASI YABANCI_HASTA_KIMLIK_NUMARASI = new YABANCI_HASTA_KIMLIK_NUMARASI();
            public PASAPORT_NO PASAPORT_NO = new PASAPORT_NO();
            public KIMLIKSIZ_HASTA_BILGISI KIMLIKSIZ_HASTA_BILGISI = new KIMLIKSIZ_HASTA_BILGISI();
            public ADRES_BILGISI ADRES_BILGISI = new ADRES_BILGISI();


        }

        public class recordData
        {
            public HASTA_KIMLIK_BILGILERI HASTA_KIMLIK_BILGILERI = new HASTA_KIMLIK_BILGILERI();
            public HASTA_BASVURU_BILGILERI HASTA_BASVURU_BILGILERI = new HASTA_BASVURU_BILGILERI();
        }
        
#endregion Methods

    }
}