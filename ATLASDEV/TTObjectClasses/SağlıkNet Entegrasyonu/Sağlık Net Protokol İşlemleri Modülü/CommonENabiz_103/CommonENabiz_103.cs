
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
    public  partial class CommonENabiz_103 : TTObject
    {
//#region Methods
//        /// ClassHelper
//        public class Utf8StringWriter : System.IO.StringWriter
//        {
//            public override Encoding Encoding { get { return Encoding.UTF8; } }
//        }
//        public class messageGuid : ValueBase
//        {
//            public messageGuid()
//            {
//                value = Guid.NewGuid().ToString();
//            }
//        }
        
//        public class documentGenerationTime : ValueBase
//        {
//            public documentGenerationTime()
//            {
//                value = DateTime.Now.ToString("yyyyMMddHHmm");
//            }
//        }
//        public class author
//        {
//            public healthcareProvider healthcareProvider;
//            public author()
//            {
//                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
//                healthcareProvider = new healthcareProvider(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
//            }

//        }

//        public class firmaKodu : ValueBase
//        {
//            public firmaKodu()
//            {
//               value = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX").ToString(); //"C740D0288F1DC45FE0407C0A04162BDD" test XXXXXX
               
//            }
//        }
//        public class CodeBase
//        {
//            [System.Xml.Serialization.XmlAttribute("version")]
//            public string version { get; set; }

//            [System.Xml.Serialization.XmlAttribute("codeSystemGuid")]
//            public string codeSystemGuid { get; set; }

//            [System.Xml.Serialization.XmlAttribute("code")]
//            public string code { get; set; }

//            [System.Xml.Serialization.XmlAttribute("value")]
//            public string value { get; set; }
//        }

//        public class ValueBase
//        {
//            [System.Xml.Serialization.XmlAttribute("value")]
//            public string value { get; set; }

//            public ValueBase()
//            {
//                value = "";
//            }
//        }

//        public enum ISLEMTURU
//        {
//            ISLEM = 1,
//            ILAC = 2,
//            MALZEME = 3
//        }
//        /// ClassHelper

//        /// SKRSObject
//        public class messageType : CodeBase
//        {
//            public messageType()
//            {
//                codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
//                version = "1";
//            }
//            public messageType(int Code, string Value)
//            {
//                codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
//                version = "1";
//                code = Code.ToString();
//                value = Value;

//            }
//        }

//        public class healthcareProvider : CodeBase
//        {
//            public healthcareProvider()
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";

//            }

//            public healthcareProvider(string Code, string Value)
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";
//                code = Code;
//                value = Value;

//            }
//        }

//        public class SYSTakipNo : ValueBase
//        {
//            public SYSTakipNo()
//            {

//            }
//            public SYSTakipNo(string Value)
//            {
//                value = Value;
//            }
//        }



//        public class CINSIYET : CodeBase
//        {
//            public CINSIYET()
//            {
//                codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
//                version = "1";
//            }
//            public CINSIYET(string Code, string Value)
//            {
//                codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
//                version = "1";
//                code = Code.ToString();
//                value = Value;

//            }
//        }

//        public class YATISIN_ACILIYETI : CodeBase
//        {
//            public YATISIN_ACILIYETI()
//            {
//                codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
//                version = "1";
//                code = "99";
//                value = "BELİRTİLMEDİ";

//            }
//            public YATISIN_ACILIYETI(string Code, string Value)
//            {
//                codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
//                version = "1";
//                code = Code.ToString();
//                value = Value;

//            }

//        }

//        public class UYRUK : CodeBase
//        {
//            public UYRUK()
//            {
//                codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
//                version = "1";

//            }

//            public UYRUK(string Code, string Value)
//            {
//                codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
//                version = "1";
//                code = Code.ToString();
//                value = Value;

//            }
//        }

//        public class ADRES_KODU_SEVIYESI : CodeBase
//        {
//            public ADRES_KODU_SEVIYESI()
//            {
//                codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
//                version = "1";

//            }

//            public ADRES_KODU_SEVIYESI(string Code, string Value)
//            {
//                codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }

//        }

//        public class KAYIT_YERI : CodeBase
//        {
//            public KAYIT_YERI()
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";

//            }
//            public KAYIT_YERI(string Code, string Value)
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";
//                code = Code;
//                value = Value;
//            }
//        }
//        public class HIZMET_SUNUCU : CodeBase
//        {
//            public HIZMET_SUNUCU()
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";

//            }
//            public HIZMET_SUNUCU(string Code, string Value)
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";
//                code = Code;
//                value = Value;
//            }
//        }

//        public class KLINIK_KODU : CodeBase
//        {
//            public KLINIK_KODU()
//            {
//                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
//                version = "1";
//                code = string.Empty;
//                value = string.Empty;


//            }
//            public KLINIK_KODU(string Code, string Value)
//            {
//                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class SOSYAL_GUVENCE_DURUMU : CodeBase
//        {
//            public SOSYAL_GUVENCE_DURUMU()
//            {
//                codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
//                version = "1";

//            }
//            public SOSYAL_GUVENCE_DURUMU(string Code, string Value)
//            {
//                codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class VAKA_TURU : CodeBase
//        {
//            public VAKA_TURU()
//            {
//                codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
//                version = "1";

//            }
//            public VAKA_TURU(string Code, string Value)
//            {
//                codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class RECETE_TURU : CodeBase
//        {
//            public RECETE_TURU()
//            {
//                codeSystemGuid = "c2fbe9bb-f6b3-4cb5-8670-47890ed7ed4b";
//                version = "1";

//            }
//            public RECETE_TURU(string Code, string Value)
//            {
//                codeSystemGuid = "c2fbe9bb-f6b3-4cb5-8670-47890ed7ed4b";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }


//        public class ILAC_KULLANIM_SEKLI : CodeBase
//        {
//            public ILAC_KULLANIM_SEKLI()
//            {
//                codeSystemGuid = "32d57611-4928-46da-afac-624aaaa388d8";
//                version = "1";

//            }
//            public ILAC_KULLANIM_SEKLI(string Code, string Value)
//            {
//                codeSystemGuid = "32d57611-4928-46da-afac-624aaaa388d8";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class ISLEM_TURU : CodeBase
//        {
//            public ISLEM_TURU()
//            {
//                codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
//                version = "1";

//            }
//            public ISLEM_TURU(string Code, string Value)
//            {
//                codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }
//        public class ILAC_KULLANIM_PERIYODU_BIRIMI : CodeBase
//        {
//            public ILAC_KULLANIM_PERIYODU_BIRIMI()
//            {
//                codeSystemGuid = "64408499-b82a-4e64-805e-e821aa0c64c9";
//                version = "1";

//            }
//            public ILAC_KULLANIM_PERIYODU_BIRIMI(string Code, string Value)
//            {
//                codeSystemGuid = "64408499-b82a-4e64-805e-e821aa0c64c9";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }
//        public class RAPOR_TURU : CodeBase
//        {
//            public RAPOR_TURU()
//            {
//                codeSystemGuid = "3fb672ac-0675-44ef-9f91-86856dc79370";
//                version = "1";

//            }
//            public RAPOR_TURU(string Code, string Value)
//            {
//                codeSystemGuid = "3fb672ac-0675-44ef-9f91-86856dc79370";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }
//        public class ICD10 : CodeBase
//        {
//            public ICD10()
//            {
//                codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
//                version = "1";

//            }
//            public ICD10(string Code, string Value)
//            {
//                codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class CIKIS_SEKLI : CodeBase
//        {
//            public CIKIS_SEKLI()
//            {
//                codeSystemGuid = "e8fba324-ae10-49a9-9178-e2c5ad0b57e9";
//                version = "1";

//            }
//            public CIKIS_SEKLI(string Code, string Value)
//            {
//                codeSystemGuid = "e8fba324-ae10-49a9-9178-e2c5ad0b57e9";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class IZLEMIN_YAPILDIGI_YER : CodeBase
//        {
//            public IZLEMIN_YAPILDIGI_YER()
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";

//            }
//            public IZLEMIN_YAPILDIGI_YER(string Code, string Value)
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }


//        public class ASI : CodeBase
//        {
//            public ASI()
//            {
//                codeSystemGuid = "c3dbbb53-3b59-06e1-e043-14031b0a9fe6";
//                version = "1";

//            }
//            public ASI(string Code, string Value)
//            {
//                codeSystemGuid = "c3dbbb53-3b59-06e1-e043-14031b0a9fe6";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class ASI_DOZU : CodeBase
//        {
//            public ASI_DOZU()
//            {
//                codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
//                version = "1";

//            }
//            public ASI_DOZU(string Code, string Value)
//            {
//                codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }
//        public class ASININ_UYGULAMA_SEKLI : CodeBase
//        {
//            public ASININ_UYGULAMA_SEKLI()
//            {
//                codeSystemGuid = "f20210e0-d780-4961-87eb-3323000b7dbb";
//                version = "1";

//            }
//            public ASININ_UYGULAMA_SEKLI(string Code, string Value)
//            {
//                codeSystemGuid = "f20210e0-d780-4961-87eb-3323000b7dbb";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class ASININ_SAGLANDIGI_KAYNAK : CodeBase
//        {
//            public ASININ_SAGLANDIGI_KAYNAK()
//            {
//                codeSystemGuid = "15068142-6853-4dab-86e1-e45e6e93b150";
//                version = "1";

//            }
//            public ASININ_SAGLANDIGI_KAYNAK(string Code, string Value)
//            {
//                codeSystemGuid = "15068142-6853-4dab-86e1-e45e6e93b150";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class ASININ_UYGULAMA_YERI : CodeBase
//        {
//            public ASININ_UYGULAMA_YERI()
//            {
//                codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
//                version = "1";

//            }
//            public ASININ_UYGULAMA_YERI(string Code, string Value)
//            {
//                codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }
//        public class YatakTuru : CodeBase
//        {
//            public YatakTuru()
//            {
//                codeSystemGuid = "51c26737-62f1-4072-8ab8-41caa7bd11da";
//                version = "1";

//            }
//            public YatakTuru(string Code, string Value)
//            {
//                codeSystemGuid = "51c26737-62f1-4072-8ab8-41caa7bd11da";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }
        
//        /// SKRSObject
//        /// 
        
//        public class MuayeneBilgisiKayit
//        {
//            public class SYSSendMessage
//            {
//                public input input = new input();
//            }

//            public class input
//            {
//                public SYSMessage SYSMessage = new SYSMessage();
//            }

//            public class SYSMessage
//            {
//                public messageGuid messageGuid = new messageGuid();
//                public messageType messageType = new messageType();
//                public documentGenerationTime documentGenerationTime = new documentGenerationTime();
//                public author author = new author();
//                public firmaKodu firmaKodu = new firmaKodu();

//                public recordData recordData = new recordData();

//                public SYSMessage()
//                {
//                    messageType.code = "103";
//                    messageType.value = "Muayene Bilgisi Kayıt";
//                }

//            }

//            public class recordData
//            {
//                public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI;
//                public HASTA_RECETE_BILGILERI HASTA_RECETE_BILGILERI;
//                public HASTA_RAPOR_BILGILERI HASTA_RAPOR_BILGILERI;
//                public MUAYENE_BILGILERI MUAYENE_BILGILERI;

//            }

//            public class HASTA_TAKIP_BILGISI
//            {
//                public SYSTakipNo SYSTakipNo = new SYSTakipNo();

//            }

//            public class HASTA_RECETE_BILGILERI
//            {
//                [System.Xml.Serialization.XmlElement("RECETE_BILGISI", Type = typeof(RECETE_BILGISI))]
//                public List<RECETE_BILGISI> RECETE_BILGISI = new List<RECETE_BILGISI>();
                
//            }

//            public class RECETE_BILGISI
//            {
//                public RECETE_TARIHI RECETE_TARIHI = new RECETE_TARIHI();
//                public RECETE_NUMARASI RECETE_NUMARASI = new RECETE_NUMARASI();
//                public RECETE_TURU RECETE_TURU = new RECETE_TURU();
//                public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();

//                [System.Xml.Serialization.XmlElement("ILAC_BILGISI", Type = typeof(ILAC_BILGISI))]
//                public List<ILAC_BILGISI> ILAC_BILGISI = new List<ILAC_BILGISI>();
                

//            }
//            public class ILAC_BILGISI {
//                public ILAC_BARKODU ILAC_BARKODU = new ILAC_BARKODU();
//                public ILAC_ADI ILAC_ADI = new ILAC_ADI();
//                public KUTU_ADETI KUTU_ADETI = new KUTU_ADETI();
//                public ILAC_KULLANIM_SEKLI ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI();
//                public ILAC_KULLANIM_SAYISI ILAC_KULLANIM_SAYISI = new ILAC_KULLANIM_SAYISI();
//                public ILAC_KULLANIM_DOZU ILAC_KULLANIM_DOZU = new ILAC_KULLANIM_DOZU();
//                public ILAC_KULLANIM_PERIYODU ILAC_KULLANIM_PERIYODU = new ILAC_KULLANIM_PERIYODU();
//                public ILAC_KULLANIM_PERIYODU_BIRIMI ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI();
//                public ILAC_ACIKLAMA ILAC_ACIKLAMA = new ILAC_ACIKLAMA();
                
//            }

//            public class HASTA_RAPOR_BILGILERI
//            {
//                [System.Xml.Serialization.XmlElement("RAPOR_BILGISI", Type = typeof(RAPOR_BILGISI))]
//                public List<RAPOR_BILGISI> RAPOR_BILGISI = new List<RAPOR_BILGISI>();
//            }

//            public class RAPOR_BILGISI
//            {
//                public RAPOR_TARIHI RAPOR_TARIHI = new RAPOR_TARIHI();
//                public RAPOR_NUMARASI RAPOR_NUMARASI = new RAPOR_NUMARASI();
//                public RAPOR_TURU RAPOR_TURU = new RAPOR_TURU();
//                public RAPOR_BASLANGIC_TARIHI RAPOR_BASLANGIC_TARIHI = new RAPOR_BASLANGIC_TARIHI();
//                public RAPOR_BITIS_TARIHI RAPOR_BITIS_TARIHI = new RAPOR_BITIS_TARIHI();
//                public RAPOR_TAKIP_NUMARASI RAPOR_TAKIP_NUMARASI = new RAPOR_TAKIP_NUMARASI();
//                public RAPOR_PDF_BILGISI RAPOR_PDF_BILGISI = new RAPOR_PDF_BILGISI();
//                [System.Xml.Serialization.XmlElement("RAPOR_HEKIM_BILGISI", Type = typeof(RAPOR_HEKIM_BILGISI))]
//                public List<RAPOR_HEKIM_BILGISI> RAPOR_HEKIM_BILGISI = new List<RAPOR_HEKIM_BILGISI>();
//            }
//            public class RAPOR_HEKIM_BILGISI
//            {
//                public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
//            }

//            public class MUAYENE_BILGILERI
//            {
//                [System.Xml.Serialization.XmlElement("EPIKRIZ_BILGISI", Type = typeof(EPIKRIZ_BILGISI))]
//                public List<EPIKRIZ_BILGISI> EPIKRIZ_BILGISI = new List<EPIKRIZ_BILGISI>();
//                [System.Xml.Serialization.XmlElement("TANI_BILGISI", Type = typeof(TANI_BILGISI))]
//                public List<TANI_BILGISI> TANI_BILGISI = new List<TANI_BILGISI>();
//            }

//            public class EPIKRIZ_BILGISI
//            {
//                public EPIKRIZ_BILGISI_BASLIK EPIKRIZ_BILGISI_BASLIK = new EPIKRIZ_BILGISI_BASLIK();
//                public EPIKRIZ_BILGISI_ACIKLAMA EPIKRIZ_BILGISI_ACIKLAMA = new EPIKRIZ_BILGISI_ACIKLAMA();
//            }
//            public class TANI_BILGISI
//            {
//                public ICD10 ICD10 = new ICD10();
//            }
//            public class RECETE_TARIHI : ValueBase
//            {
//                public RECETE_TARIHI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RECETE_NUMARASI : ValueBase
//            {
//                public RECETE_NUMARASI()
//                {
//                    value = "0";
//                }
//            }
//            public class HEKIM_KIMLIK_NUMARASI : ValueBase
//            {
//                public HEKIM_KIMLIK_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ILAC_BARKODU : ValueBase
//            {
//                public ILAC_BARKODU()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ILAC_ADI : ValueBase
//            {
//                public ILAC_ADI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class KUTU_ADETI : ValueBase
//            {
//                public KUTU_ADETI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ILAC_KULLANIM_SAYISI : ValueBase
//            {
//                public ILAC_KULLANIM_SAYISI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ILAC_KULLANIM_DOZU : ValueBase
//            {
//                public ILAC_KULLANIM_DOZU()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ILAC_KULLANIM_PERIYODU : ValueBase
//            {
//                public ILAC_KULLANIM_PERIYODU()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ILAC_ACIKLAMA : ValueBase
//            {
//                public ILAC_ACIKLAMA()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPOR_TARIHI: ValueBase
//            {
//                public RAPOR_TARIHI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPOR_NUMARASI : ValueBase
//            {
//                public RAPOR_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPOR_BASLANGIC_TARIHI : ValueBase
//            {
//                public RAPOR_BASLANGIC_TARIHI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPOR_BITIS_TARIHI : ValueBase
//            {
//                public RAPOR_BITIS_TARIHI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPOR_TAKIP_NUMARASI : ValueBase
//            {
//                public RAPOR_TAKIP_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPOR_PDF_BILGISI : ValueBase
//            {
//                public RAPOR_PDF_BILGISI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class EPIKRIZ_BILGISI_BASLIK : ValueBase
//            {
//                public EPIKRIZ_BILGISI_BASLIK()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class EPIKRIZ_BILGISI_ACIKLAMA : ValueBase
//            {
//                public EPIKRIZ_BILGISI_ACIKLAMA()
//                {
//                    value = string.Empty;
//                }
//            }
            
//            public static SYSMessage Get(Guid InternalObjectGuid,string InternalObjectDefName)
//            {
//                //InternalObjectGuid bu paket için SubEpisodedur
//                TTObjectContext objectContext = new TTObjectContext(true);
//                SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);
//                if (subEpisode == null)
//                    throw new Exception("'103' peketini göndermek için '" + InternalObjectGuid + "' ObjectId'li "+ InternalObjectDefName +" Objesi bulunamadı");

//                recordData _recordData = new recordData();

//                //HASTA_TAKIP_BILGISI
//                _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
//                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subEpisode.SYSTakipNo;

//                //HASTA_RECETE_BILGILERI
                
//                BindingList<OutPatientPrescription> OutPatientPrescriptionList = OutPatientPrescription.GetBySubEpisode(objectContext,subEpisode.ObjectID);
//                BindingList<InpatientPrescription> InPatientPrescriptionList = InpatientPrescription.GetBySubEpisode(objectContext,subEpisode.ObjectID);
//                //if(OutPatientPrescriptionList.Count > 0 || InPatientPrescriptionList.Count > 0) //TODO yatan hasta reçetesi eklenince böyle olacak.
//                if(OutPatientPrescriptionList.Count > 0)
//                {
//                    _recordData.HASTA_RECETE_BILGILERI = new HASTA_RECETE_BILGILERI();
//                    foreach (OutPatientPrescription outPatientPrescription in OutPatientPrescriptionList)
//                    {
//                        RECETE_BILGISI RECETE_BILGISI = new RECETE_BILGISI();
                        
//                        RECETE_BILGISI.RECETE_TARIHI.value = outPatientPrescription.ActionDate.Value.ToString("yyyyMMddHHmm");
//                        if(!(String.IsNullOrEmpty(outPatientPrescription.EReceteNo)) || outPatientPrescription.PrescriptionNO != null)
//                            RECETE_BILGISI.RECETE_NUMARASI.value =  (String.IsNullOrEmpty(outPatientPrescription.EReceteNo) ? outPatientPrescription.PrescriptionNO : outPatientPrescription.EReceteNo);
//                        else
//                            RECETE_BILGISI.RECETE_NUMARASI.value = outPatientPrescription.ID.ToString();
                        
//                        BaseSKRSDefinition _SKRSReceteTuru = null;
//                        if(outPatientPrescription.PrescriptionType != null)
//                            _SKRSReceteTuru = SKRSReceteTuru.GetByEnumValue("SKRSReceteTuru",Convert.ToInt16(outPatientPrescription.PrescriptionType.Value));
//                        if(_SKRSReceteTuru != null)
//                            RECETE_BILGISI.RECETE_TURU = new RECETE_TURU(((SKRSReceteTuru)_SKRSReceteTuru).KODU, ((SKRSReceteTuru)_SKRSReceteTuru).ADI);
//                        else
//                            RECETE_BILGISI.RECETE_TURU = new RECETE_TURU("1","NORMAL");
                        
//                        if(outPatientPrescription.ProcedureDoctor != null && outPatientPrescription.ProcedureDoctor.Person != null && outPatientPrescription.ProcedureDoctor.Person.UniqueRefNo != null)
//                            RECETE_BILGISI.HEKIM_KIMLIK_NUMARASI.value = outPatientPrescription.ProcedureDoctor.Person.UniqueRefNo.ToString();
                        
//                        foreach(OutPatientDrugOrder outPatientDrugOrder in outPatientPrescription.OutPatientDrugOrders)
//                        {
//                            ILAC_BILGISI ILAC_BILGISI = new ILAC_BILGISI();
//                            TerminologyManagerDef _SKRSIlac = outPatientDrugOrder.PhysicianDrug.GetSKRSDefinition();
//                            if (_SKRSIlac != null)
//                            {
//                                ILAC_BILGISI.ILAC_BARKODU.value = ((SKRSIlac)_SKRSIlac).BARKODU;
//                                ILAC_BILGISI.ILAC_ADI.value = ((SKRSIlac)_SKRSIlac).ADI;
//                            }
//                            else
//                            {
//                                ILAC_BILGISI.ILAC_BARKODU.value = outPatientDrugOrder.PhysicianDrug.Barcode;
//                                ILAC_BILGISI.ILAC_ADI.value = outPatientDrugOrder.PhysicianDrug.Name;
//                            }
//                            ILAC_BILGISI.KUTU_ADETI.value =  outPatientDrugOrder.PackageAmount != null ? outPatientDrugOrder.PackageAmount.ToString() : string.Empty;
//                            BaseSKRSDefinition _SKRSIlacKullanimSekli = null;
//                            if(outPatientDrugOrder.DrugUsageType.HasValue)
//                                _SKRSIlacKullanimSekli = SKRSIlacKullanimSekli.GetByEnumValue("SKRSIlacKullanimSekli",Convert.ToInt16(outPatientDrugOrder.DrugUsageType.Value));
//                            if(_SKRSIlacKullanimSekli != null)
//                                ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI(((SKRSIlacKullanimSekli)_SKRSIlacKullanimSekli).KODU,((SKRSIlacKullanimSekli)_SKRSIlacKullanimSekli).ADI);
//                            else
//                                ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI("1","AĞIZDAN (ORAL)");
                            
//                            ILAC_BILGISI.ILAC_KULLANIM_SAYISI.value =  outPatientDrugOrder.PackageAmount != null ? outPatientDrugOrder.PackageAmount.ToString() : string.Empty;//TODO ??
//                            ILAC_BILGISI.ILAC_KULLANIM_DOZU.value = outPatientDrugOrder.DoseAmount != null ? outPatientDrugOrder.DoseAmount.ToString() : string.Empty;
//                            ILAC_BILGISI.ILAC_KULLANIM_PERIYODU.value = outPatientDrugOrder.Day != null ? outPatientDrugOrder.Day.ToString() : string.Empty;
                            
//                            BaseSKRSDefinition _SKRSIlacKullanimPeriyoduBirimi = null;
//                            if(outPatientDrugOrder.PeriodUnitType.HasValue)
//                                _SKRSIlacKullanimPeriyoduBirimi = SKRSIlacKullanimPeriyoduBirimi.GetByEnumValue("SKRSIlacKullanimPeriyoduBirimi",Convert.ToInt16(outPatientDrugOrder.PeriodUnitType.Value));
//                            if(_SKRSIlacKullanimPeriyoduBirimi != null)
//                                ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI(((SKRSIlacKullanimPeriyoduBirimi)_SKRSIlacKullanimPeriyoduBirimi).KODU, ((SKRSIlacKullanimPeriyoduBirimi)_SKRSIlacKullanimPeriyoduBirimi).ADI);
//                            else
//                                ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI("5","AY");
                            
//                            if(outPatientDrugOrder.Description != null)
//                                ILAC_BILGISI.ILAC_ACIKLAMA.value = outPatientDrugOrder.Description;
//                            RECETE_BILGISI.ILAC_BILGISI.Add(ILAC_BILGISI);
//                        }
                        
//                        _recordData.HASTA_RECETE_BILGILERI.RECETE_BILGISI.Add(RECETE_BILGISI);
//                    }

//                    //Paketten sonra açılacak.Şimdilik kapatıldı.
//                    /*foreach (InpatientPrescription inPatientPrescription in InPatientPrescriptionList)
//                    {
//                        RECETE_BILGISI RECETE_BILGISI = new RECETE_BILGISI();

//                        RECETE_BILGISI.RECETE_TARIHI.value = inPatientPrescription.ActionDate.Value.ToString("yyyyMMddHHmm");
//                        if (!(String.IsNullOrEmpty(inPatientPrescription.EReceteNo)) || inPatientPrescription.PrescriptionNO != null)
//                            RECETE_BILGISI.RECETE_NUMARASI.value = (String.IsNullOrEmpty(inPatientPrescription.EReceteNo) ? inPatientPrescription.PrescriptionNO : inPatientPrescription.EReceteNo);
//                        else
//                            RECETE_BILGISI.RECETE_NUMARASI.value = inPatientPrescription.ID.ToString();

//                        BaseSKRSDefinition _SKRSReceteTuru = null;
//                        if (inPatientPrescription.PrescriptionType != null)
//                            _SKRSReceteTuru = SKRSReceteTuru.GetByEnumValue("SKRSReceteTuru", Convert.ToInt16(inPatientPrescription.PrescriptionType.Value));
//                        if (_SKRSReceteTuru != null)
//                            RECETE_BILGISI.RECETE_TURU = new RECETE_TURU(((SKRSReceteTuru)_SKRSReceteTuru).KODU, ((SKRSReceteTuru)_SKRSReceteTuru).ADI);
//                        else
//                            RECETE_BILGISI.RECETE_TURU = new RECETE_TURU("1", "NORMAL");

//                        if(inPatientPrescription.ProcedureDoctor != null && inPatientPrescription.ProcedureDoctor.Person != null && inPatientPrescription.ProcedureDoctor.Person.UniqueRefNo != null)
//                            RECETE_BILGISI.HEKIM_KIMLIK_NUMARASI.value = inPatientPrescription.ProcedureDoctor.Person.UniqueRefNo.ToString();

//                        foreach (InpatientDrugOrder inPatientDrugOrder in inPatientPrescription.InpatientDrugOrders)
//                        {
//                            ILAC_BILGISI ILAC_BILGISI = new ILAC_BILGISI();
//                            TerminologyManagerDef _SKRSIlac = inPatientDrugOrder.Material.GetSKRSDefinition();
//                            if (_SKRSIlac != null)
//                            {
//                                ILAC_BILGISI.ILAC_BARKODU.value = ((SKRSIlac)_SKRSIlac).BARKODU;
//                                ILAC_BILGISI.ILAC_ADI.value = ((SKRSIlac)_SKRSIlac).ADI;
//                            }
//                            else
//                            {
//                                ILAC_BILGISI.ILAC_BARKODU.value = inPatientDrugOrder.Material.Barcode;
//                                ILAC_BILGISI.ILAC_ADI.value = inPatientDrugOrder.Material.Name;
//                            }
//                            ILAC_BILGISI.KUTU_ADETI.value = inPatientDrugOrder.PackageAmount != null ? inPatientDrugOrder.PackageAmount.ToString() : string.Empty;
                            
//                            BaseSKRSDefinition sKRSIlacKullanimSekli = BaseSKRSDefinition.GetMyDefault("SKRSIlacKullanimSekli");
//                            if(sKRSIlacKullanimSekli != null)
//                                ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI(((SKRSIlacKullanimSekli)sKRSIlacKullanimSekli).KODU, ((SKRSIlacKullanimSekli)sKRSIlacKullanimSekli).ADI);
//                            else
//                                ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI("1", "AĞIZDAN (ORAL)");

//                            ILAC_BILGISI.ILAC_KULLANIM_SAYISI.value = inPatientDrugOrder.PackageAmount != null ? inPatientDrugOrder.PackageAmount.ToString() : string.Empty;//TODO ??
//                            ILAC_BILGISI.ILAC_KULLANIM_DOZU.value = inPatientDrugOrder.DoseAmount != null ? inPatientDrugOrder.DoseAmount.ToString() : string.Empty;
//                            ILAC_BILGISI.ILAC_KULLANIM_PERIYODU.value = inPatientDrugOrder.Day != null ? inPatientDrugOrder.Day.ToString() : string.Empty;

//                            BaseSKRSDefinition sKRSIlacKullanimPeriyoduBirimi = BaseSKRSDefinition.GetMyDefault("SKRSIlacKullanimPeriyoduBirimi");
//                            if (sKRSIlacKullanimPeriyoduBirimi != null)
//                                ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI(((SKRSIlacKullanimPeriyoduBirimi)sKRSIlacKullanimPeriyoduBirimi).KODU, ((SKRSIlacKullanimPeriyoduBirimi)sKRSIlacKullanimPeriyoduBirimi).ADI);
//                            else
//                                ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI("5", "AY");

//                            if (inPatientDrugOrder.Description != null)
//                                ILAC_BILGISI.ILAC_ACIKLAMA.value = inPatientDrugOrder.Description;
//                            RECETE_BILGISI.ILAC_BILGISI.Add(ILAC_BILGISI);
//                        }

//                        _recordData.HASTA_RECETE_BILGILERI.RECETE_BILGISI.Add(RECETE_BILGISI);
//                    }*/
//                }
                
//                //HASTA_RAPOR_BILGILERI
                
//                BindingList<ParticipatnFreeDrugReport> ParticipatnFreeDrugReportList = ParticipatnFreeDrugReport.GetCompletedBySubEpisode(objectContext,subEpisode.ObjectID);
//                if(ParticipatnFreeDrugReportList.Count > 0)
//                {
//                    foreach(ParticipatnFreeDrugReport participatnFreeDrugReport in ParticipatnFreeDrugReportList)
//                    {
//                        RAPOR_BILGISI RAPOR_BILGISI = new RAPOR_BILGISI();
//                        RAPOR_BILGISI.RAPOR_TARIHI.value = participatnFreeDrugReport.ActionDate.HasValue ? participatnFreeDrugReport.ActionDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
//                        RAPOR_BILGISI.RAPOR_NUMARASI.value = participatnFreeDrugReport.ID.Value.ToString();
                        
//                        BindingList<SKRSRaporTuru> SKRSRaporTuruList = SKRSRaporTuru.GetByKodu(objectContext,"10");
//                        if(SKRSRaporTuruList.Count > 0)
//                            RAPOR_BILGISI.RAPOR_TURU = new RAPOR_TURU(SKRSRaporTuruList[0].KODU,SKRSRaporTuruList[0].ADI);
//                        else
//                            RAPOR_BILGISI.RAPOR_TURU = new RAPOR_TURU("10","İLAÇ KULLANIM");
                        
//                        RAPOR_BILGISI.RAPOR_BASLANGIC_TARIHI.value = participatnFreeDrugReport.ReportStartDate.HasValue ? participatnFreeDrugReport.ReportStartDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
//                        RAPOR_BILGISI.RAPOR_BITIS_TARIHI.value = participatnFreeDrugReport.ReportEndDate.HasValue ? participatnFreeDrugReport.ReportEndDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
//                        BindingList<MedulaReportResult> MedulaReportResultList = MedulaReportResult.GetByParticipatnFreeDrugReport(objectContext, participatnFreeDrugReport.ObjectID);
//                        if(MedulaReportResultList.Count>0)
//                            RAPOR_BILGISI.RAPOR_TAKIP_NUMARASI.value = MedulaReportResultList[0].ReportChasingNo;
//                        else
//                            RAPOR_BILGISI.RAPOR_TAKIP_NUMARASI.value = "";
//                        RAPOR_BILGISI.RAPOR_PDF_BILGISI.value = String.Empty;// ilaç raporları için yazılmıyormuş.
//                        RAPOR_HEKIM_BILGISI RAPOR_HEKIM_BILGISI = new RAPOR_HEKIM_BILGISI();
//                        if(participatnFreeDrugReport.ProcedureDoctor != null && participatnFreeDrugReport.ProcedureDoctor.Person != null && participatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo != null)
//                            RAPOR_HEKIM_BILGISI.HEKIM_KIMLIK_NUMARASI.value = participatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.ToString();
//                        RAPOR_BILGISI.RAPOR_HEKIM_BILGISI.Add(RAPOR_HEKIM_BILGISI);
//                        if(participatnFreeDrugReport.SecondDoctor != null)
//                        {
//                            RAPOR_HEKIM_BILGISI RAPOR_HEKIM_BILGISI2 = new RAPOR_HEKIM_BILGISI();
//                            if(participatnFreeDrugReport.SecondDoctor.Person != null && participatnFreeDrugReport.SecondDoctor.Person.UniqueRefNo != null)
//                                RAPOR_HEKIM_BILGISI2.HEKIM_KIMLIK_NUMARASI.value =participatnFreeDrugReport.SecondDoctor.Person.UniqueRefNo.ToString();
//                            RAPOR_BILGISI.RAPOR_HEKIM_BILGISI.Add(RAPOR_HEKIM_BILGISI2);
//                        }
//                        if(participatnFreeDrugReport.ThirdDoctor != null)
//                        {
//                            RAPOR_HEKIM_BILGISI RAPOR_HEKIM_BILGISI3 = new RAPOR_HEKIM_BILGISI();
//                            if (participatnFreeDrugReport.ThirdDoctor.Person != null && participatnFreeDrugReport.ThirdDoctor.Person.UniqueRefNo != null)
//                                RAPOR_HEKIM_BILGISI3.HEKIM_KIMLIK_NUMARASI.value = participatnFreeDrugReport.ThirdDoctor.Person.UniqueRefNo.ToString();
//                            RAPOR_BILGISI.RAPOR_HEKIM_BILGISI.Add(RAPOR_HEKIM_BILGISI3);
//                        }
//                        _recordData.HASTA_RAPOR_BILGILERI = new HASTA_RAPOR_BILGILERI();
//                        _recordData.HASTA_RAPOR_BILGILERI.RAPOR_BILGISI.Add(RAPOR_BILGISI);
//                    }
                    
//                    //TODO BirthReport
//                    //TODO Unbound MedulaRaporIslemleri formundan yazılan raporlar için MedulaReportResults gibi bir tabloya kayıt atılması sağlanıp bu tablodakilerin gönderilmesi lazım.
                    
//                }

//                //MUAYENE_BILGILERI
//                if(subEpisode.Episode.PatientHistory != null || subEpisode.Episode.Complaint != null || subEpisode.Episode.PhysicalExamination != null || subEpisode.HasDiagnosis == true)
//                {
//                    _recordData.MUAYENE_BILGILERI = new MUAYENE_BILGILERI();
//                    if(subEpisode.Episode.PatientHistory != null)
//                    {
//                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
//                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "HİKAYESİ";
//                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.PatientHistory.ToString());
//                        _recordData.MUAYENE_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
//                    }
//                    if (subEpisode.Episode.Complaint != null)
//                    {
//                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
//                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "ŞİKAYETİ";
//                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.Complaint.ToString());
//                        _recordData.MUAYENE_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
//                    }
//                    if (subEpisode.Episode.PhysicalExamination != null)
//                    {
//                        EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
//                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "FİZİK MUAYENESİ";
//                        EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.PhysicalExamination.ToString());
//                        _recordData.MUAYENE_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
//                    }

//                    BindingList<DiagnosisGrid> subEpisodeDiagnosisList = DiagnosisGrid.GetDiagnosisBySubEpisode_OQ(objectContext, subEpisode.ObjectID.ToString());
//                    if (subEpisodeDiagnosisList.Count > 0)
//                    {
//                        foreach (DiagnosisGrid dg in subEpisodeDiagnosisList)
//                        {
//                            TANI_BILGISI TANI_BILGISI = new TANI_BILGISI();
//                            TerminologyManagerDef skrsDiagnose = dg.Diagnose.GetSKRSDefinition();
//                            if (skrsDiagnose != null)
//                            {
//                                TANI_BILGISI.ICD10 = new ICD10(((SKRSICD)skrsDiagnose).KODU, ((SKRSICD)skrsDiagnose).ADI);
//                                _recordData.MUAYENE_BILGILERI.TANI_BILGISI.Add(TANI_BILGISI);
//                            }
//                        }
//                    }
//                }
//                SYSMessage _SYSMessage = new SYSMessage();
//                _SYSMessage.recordData = _recordData;
//                return _SYSMessage;
                
//            }
//        }
        
//#endregion Methods

    }
}