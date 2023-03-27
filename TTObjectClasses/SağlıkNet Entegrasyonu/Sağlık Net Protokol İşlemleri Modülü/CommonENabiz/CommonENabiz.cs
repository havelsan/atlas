
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
    public  partial class CommonENabiz : TTObject
    {/*
#region Methods
        /// Poc.SaglikNetHelper
        public class SaglikNetHelper
        {
            public static string XMLSerialize(object objToXml)
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer;

                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                ns.Add("", "");

                xmlSerializer = new System.Xml.Serialization.XmlSerializer(objToXml.GetType());
                System.IO.StringWriter sw = new Utf8StringWriter();

                System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
                XmlWriter xmlWriter = XmlWriter.Create(sw, settings);

                xmlSerializer.Serialize(xmlWriter, objToXml, ns);
                // xmlSerializer.Serialize(xmlWriter, objToXml, ns);
                //buffer = Encoding.UTF8.GetString(ms.ToArray());
                return sw.ToString();
            }

            public static string GetNodeValue(XmlDocument xdoc, string nodeName)
            {
                XmlNodeList nl = xdoc.GetElementsByTagName(nodeName);
                if (nl.Count != 0)
                    return nl[0].Attributes[0].Value;
                else
                    return "";
            }

            public static bool IsDate(Object obj)
            {
                if (obj == null) { return false; }
                string strDate = obj.ToString();
                try
                {
                    DateTime dt = DateTime.Parse(strDate);
                    if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                        return true;
                    return false;
                }
                catch
                {
                    return false;
                }
            }

        }
        /// Poc.SaglikNetHelper

        /// ClassHelper
        public class Utf8StringWriter : System.IO.StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
        public class messageGuid : ValueBase
        {
            public messageGuid()
            {
                value = Guid.NewGuid().ToString();
            }
        }

        public class documentGenerationTime : ValueBase
        {
            public documentGenerationTime()
            {
                value = DateTime.Now.ToString("yyyyMMddHHmm");
            }
        }
        public class author
        {
            public healthcareProvider healthcareProvider;
            public author()
            {
                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                healthcareProvider = new healthcareProvider(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
            }

        }

        public class firmaKodu : ValueBase
        {
            public firmaKodu()
            {

                value = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX").ToString(); //"C740D0288F1DC45FE0407C0A04162BDD" test XXXXXX

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

        public class ValueBase
        {
            [System.Xml.Serialization.XmlAttribute("value")]
            public string value { get; set; }

            public ValueBase()
            {
                value = "";
            }
        }

        public enum ISLEMTURU
        {
            ISLEM = 1,
            ILAC = 2,
            MALZEME = 3
        }
        /// ClassHelper

        /// SKRSObject

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

        public class healthcareProvider : CodeBase
        {
            public healthcareProvider()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }

            public healthcareProvider(string Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code;
                value = Value;

            }
        }

        public class SYSTakipNo : ValueBase
        {
            public SYSTakipNo()
            {

            }
            public SYSTakipNo(string Value)
            {
                value = Value;
            }
        }



        public class CINSIYET : CodeBase
        {
            public CINSIYET()
            {
                codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
                version = "1";
            }
            public CINSIYET(string Code, string Value)
            {
                codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
                version = "1";
                code = Code.ToString();
                value = Value;

            }
        }

        public class YATISIN_ACILIYETI : CodeBase
        {
            public YATISIN_ACILIYETI()
            {
                codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
                version = "1";
                code = "99";
                value = "BELİRTİLMEDİ";

            }
            public YATISIN_ACILIYETI(string Code, string Value)
            {
                codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
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

            public UYRUK(string Code, string Value)
            {
                codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
                version = "1";
                code = Code;
                value = Value;

            }
        }

        public class ADRES_KODU_SEVIYESI : CodeBase
        {
            public ADRES_KODU_SEVIYESI()
            {
                codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
                version = "1";

            }

            public ADRES_KODU_SEVIYESI(string Code, string Value)
            {
                codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
                version = "1";
                code = Code;
                value = Value;
            }

        }

        public class KAYIT_YERI : CodeBase
        {
            public KAYIT_YERI()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }
            public KAYIT_YERI(string Code, string Value)
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
            public HIZMET_SUNUCU(string Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class KLINIK_KODU : CodeBase
        {
            public KLINIK_KODU()
            {
                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
                version = "1";
                code = string.Empty;
                value = string.Empty;

            }
            public KLINIK_KODU(string Code, string Value)
            {
                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
                version = "1";
                code = Code;
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
            public SOSYAL_GUVENCE_DURUMU(string Code, string Value)
            {
                codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class VAKA_TURU : CodeBase
        {
            public VAKA_TURU()
            {
                codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
                version = "1";

            }
            public VAKA_TURU(string Code, string Value)
            {
                codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class RECETE_TURU : CodeBase
        {
            public RECETE_TURU()
            {
                codeSystemGuid = "c2fbe9bb-f6b3-4cb5-8670-47890ed7ed4b";
                version = "1";

            }
            public RECETE_TURU(string Code, string Value)
            {
                codeSystemGuid = "c2fbe9bb-f6b3-4cb5-8670-47890ed7ed4b";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }


        public class ILAC_KULLANIM_SEKLI : CodeBase
        {
            public ILAC_KULLANIM_SEKLI()
            {
                codeSystemGuid = "32d57611-4928-46da-afac-624aaaa388d8";
                version = "1";

            }
            public ILAC_KULLANIM_SEKLI(string Code, string Value)
            {
                codeSystemGuid = "32d57611-4928-46da-afac-624aaaa388d8";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class ISLEM_TURU : CodeBase
        {
            public ISLEM_TURU()
            {
                codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
                version = "1";

            }
            public ISLEM_TURU(string Code, string Value)
            {
                codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
                version = "1";
                code = Code;
                value = Value;
            }
            public ISLEM_TURU(ISLEMTURU it)
            {
                codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
                version = "1";
                code = Convert.ToInt32(it).ToString();

                if (it == ISLEMTURU.ISLEM)
                    value = "DIĞER (SUT, VAKA BAŞI VEYA PAKET IŞLEMLER)";
                else if (it == ISLEMTURU.ILAC)
                    value = "İLAÇ";
                else if (it == ISLEMTURU.MALZEME)
                    value = "MALZEME";


            }
        }
        public class ILAC_KULLANIM_PERIYODU_BIRIMI : CodeBase
        {
            public ILAC_KULLANIM_PERIYODU_BIRIMI()
            {
                codeSystemGuid = "64408499-b82a-4e64-805e-e821aa0c64c9";
                version = "1";

            }
            public ILAC_KULLANIM_PERIYODU_BIRIMI(string Code, string Value)
            {
                codeSystemGuid = "64408499-b82a-4e64-805e-e821aa0c64c9";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }
        public class RAPOR_TURU : CodeBase
        {
            public RAPOR_TURU()
            {
                codeSystemGuid = "3fb672ac-0675-44ef-9f91-86856dc79370";
                version = "1";

            }
            public RAPOR_TURU(string Code, string Value)
            {
                codeSystemGuid = "3fb672ac-0675-44ef-9f91-86856dc79370";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }
        public class ICD10 : CodeBase
        {
            public ICD10()
            {
                codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
                version = "1";

            }
            public ICD10(string Code, string Value)
            {
                codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class CIKIS_SEKLI : CodeBase
        {
            public CIKIS_SEKLI()
            {
                codeSystemGuid = "e8fba324-ae10-49a9-9178-e2c5ad0b57e9";
                version = "1";

            }
            public CIKIS_SEKLI(string Code, string Value)
            {
                codeSystemGuid = "e8fba324-ae10-49a9-9178-e2c5ad0b57e9";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class IZLEMIN_YAPILDIGI_YER : CodeBase
        {
            public IZLEMIN_YAPILDIGI_YER()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }
            public IZLEMIN_YAPILDIGI_YER(string Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }


        public class ASI : CodeBase
        {
            public ASI()
            {
                codeSystemGuid = "c3dbbb53-3b59-06e1-e043-14031b0a9fe6";
                version = "1";

            }
            public ASI(string Code, string Value)
            {
                codeSystemGuid = "c3dbbb53-3b59-06e1-e043-14031b0a9fe6";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class ASI_DOZU : CodeBase
        {
            public ASI_DOZU()
            {
                codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
                version = "1";

            }
            public ASI_DOZU(string Code, string Value)
            {
                codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
                version = "1";
                code = Code;
                value = Value;
            }
        }
        public class ASININ_UYGULAMA_SEKLI : CodeBase
        {
            public ASININ_UYGULAMA_SEKLI()
            {
                codeSystemGuid = "f20210e0-d780-4961-87eb-3323000b7dbb";
                version = "1";

            }
            public ASININ_UYGULAMA_SEKLI(string Code, string Value)
            {
                codeSystemGuid = "f20210e0-d780-4961-87eb-3323000b7dbb";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class ASININ_SAGLANDIGI_KAYNAK : CodeBase
        {
            public ASININ_SAGLANDIGI_KAYNAK()
            {
                codeSystemGuid = "15068142-6853-4dab-86e1-e45e6e93b150";
                version = "1";

            }
            public ASININ_SAGLANDIGI_KAYNAK(string Code, string Value)
            {
                codeSystemGuid = "15068142-6853-4dab-86e1-e45e6e93b150";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class ASININ_UYGULAMA_YERI : CodeBase
        {
            public ASININ_UYGULAMA_YERI()
            {
                codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
                version = "1";

            }
            public ASININ_UYGULAMA_YERI(int Code, string Value)
            {
                codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }
        public class YatakTuru : CodeBase
        {
            public YatakTuru()
            {
                codeSystemGuid = "51c26737-62f1-4072-8ab8-41caa7bd11da";
                version = "1";

            }
            public YatakTuru(string Code, string Value)
            {
                codeSystemGuid = "51c26737-62f1-4072-8ab8-41caa7bd11da";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class ISTEM_YAPILAN_KLINIK : CodeBase
        {
            public ISTEM_YAPILAN_KLINIK()
            {
                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
                version = "1";

            }
            public ISTEM_YAPILAN_KLINIK(string Code, string Value)
            {
                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI : CodeBase
        {
            public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI()
            {
                codeSystemGuid = "cf34c46d-c31f-4922-9b74-68cc69412cfc";
                version = "1";

            }
            public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI(string Code, string Value)
            {
                codeSystemGuid = "cf34c46d-c31f-4922-9b74-68cc69412cfc";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class NUMUNE_ALINMA_SEKLI : CodeBase
        {
            public NUMUNE_ALINMA_SEKLI()
            {
                codeSystemGuid = "051c2db0-f724-457a-ac46-7d3a741b7ae2";
                version = "1";

            }
            public NUMUNE_ALINMA_SEKLI(string Code, string Value)
            {
                codeSystemGuid = "051c2db0-f724-457a-ac46-7d3a741b7ae2";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class PREPARAT_DURUMU : CodeBase
        {
            public PREPARAT_DURUMU()
            {
                codeSystemGuid = "4016f2d2-9b44-43e1-834d-d1c045419fea";
                version = "1";

            }
            public PREPARAT_DURUMU(string Code, string Value)
            {
                codeSystemGuid = "4016f2d2-9b44-43e1-834d-d1c045419fea";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class YERLESIM_YERI : CodeBase
        {
            public YERLESIM_YERI()
            {
                codeSystemGuid = "fc24f548-c383-4855-be0b-0f1d23599bba";
                version = "1";

            }
            public YERLESIM_YERI(string Code, string Value)
            {
                codeSystemGuid = "fc24f548-c383-4855-be0b-0f1d23599bba";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class MORFOLOJI_KODU : CodeBase
        {
            public MORFOLOJI_KODU()
            {
                codeSystemGuid = "40220f50-1c9c-43c9-9bbd-45794d5cc7b2";
                version = "1";

            }
            public MORFOLOJI_KODU(string Code, string Value)
            {
                codeSystemGuid = "40220f50-1c9c-43c9-9bbd-45794d5cc7b2";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class VAKA_TIPI : CodeBase
        {
            public VAKA_TIPI()
            {
                codeSystemGuid = "663db642-20db-4160-bd77-c9be99c7f496";
                version = "1";

            }
            public VAKA_TIPI(string Code, string Value)
            {
                codeSystemGuid = "663db642-20db-4160-bd77-c9be99c7f496";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class ADRES_TIPI : CodeBase
        {
            public ADRES_TIPI()
            {
                codeSystemGuid = "35f4968a-3e72-41ce-9ae4-f4d22f90ea2e";
                version = "1";

            }
            public ADRES_TIPI(string Code, string Value)
            {
                codeSystemGuid = "35f4968a-3e72-41ce-9ae4-f4d22f90ea2e";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }

        public class ILCE_KODU : CodeBase
        {
            public ILCE_KODU()
            {
                codeSystemGuid = "96184a9e-537c-4a70-8b3a-27a7a170355b";
                version = "1";

            }
            public ILCE_KODU(string Code, string Value)
            {
                codeSystemGuid = "96184a9e-537c-4a70-8b3a-27a7a170355b";
                version = "1";
                code = Code;
                value = Value;
            }
        }

        public class IL_KODU : CodeBase
        {
            public IL_KODU()
            {
                codeSystemGuid = "5bc508fa-782a-4d75-831f-34948e350e72";
                version = "1";

            }
            public IL_KODU(string Code, string Value)
            {
                codeSystemGuid = "5bc508fa-782a-4d75-831f-34948e350e72";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }


        public class TELEFON_TIPI : CodeBase
        {
            public TELEFON_TIPI()
            {
                codeSystemGuid = "e387c902-9062-4406-85ef-63e085754f9e";
                version = "1";

            }
            public TELEFON_TIPI(string Code, string Value)
            {
                codeSystemGuid = "e387c902-9062-4406-85ef-63e085754f9e";
                version = "1";
                code = Code.ToString();
                value = Value;
            }
        }


        public class HASTA_KIMLIK_NUMARASI : ValueBase
        {
            public HASTA_KIMLIK_NUMARASI()
            {
                value = string.Empty;
            }
        }
        public class AD : ValueBase
        {
            public AD()
            {
                value = string.Empty;
            }
        }
        public class SOYAD : ValueBase
        {
            public SOYAD()
            {
                value = string.Empty;
            }
        }
        public class DOGUM_TARIHI : ValueBase
        {
            public DOGUM_TARIHI()
            {
                value = string.Empty;
            }
        }


        public class ANNE_KIMLIK_NUMARASI : ValueBase
        {
            public ANNE_KIMLIK_NUMARASI()
            {
                value = string.Empty;
            }
        }

        public class DOGUM_SIRASI : ValueBase
        {
            public DOGUM_SIRASI()
            {
                value = string.Empty;
            }
        }

        public class YABANCI_HASTA_KIMLIK_NUMARASI : ValueBase
        {
            public YABANCI_HASTA_KIMLIK_NUMARASI()
            {
                value = string.Empty;
            }
        }
        public class PASAPORT_NO : ValueBase
        {
            public PASAPORT_NO()
            {
                value = string.Empty;
            }
        }
        public class KIMLIKSIZ_HASTA_BILGISI : ValueBase
        {
            public KIMLIKSIZ_HASTA_BILGISI()
            {
                value = string.Empty;
            }
        }

        /// SKRSObject

        /// Class Tanımları

        public class HastaKayit
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
                    messageType.code = "101";
                    messageType.value = "Hasta Kayıt";
                }
            }

            public class recordData
            {
                public HASTA_KIMLIK_BILGILERI HASTA_KIMLIK_BILGILERI = new HASTA_KIMLIK_BILGILERI();
                public HASTA_BASVURU_BILGILERI HASTA_BASVURU_BILGILERI = new HASTA_BASVURU_BILGILERI();
            }
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
            public class AMBULANS_TAKIP_NUMARASI : ValueBase { }


            public class PROTOKOL_NUMARASI : ValueBase
            {
                public PROTOKOL_NUMARASI()
                {
                    value = string.Empty;
                }
            }
            public class XXXXXX_REFERANS_NUMARASI : ValueBase
            {
                public XXXXXX_REFERANS_NUMARASI()
                {
                    value = "0";
                }
            }
            public class SGK_TAKIP_NUMARASI : ValueBase
            {
                public SGK_TAKIP_NUMARASI()
                {
                    value = string.Empty;
                }
            }
            public class KABUL_ZAMANI : ValueBase
            {
                public KABUL_ZAMANI()
                {
                    value = string.Empty;
                }
            }


            public class HEKIM_KIMLIK_NUMARASI : ValueBase
            {
                public HEKIM_KIMLIK_NUMARASI()
                {
                    value = string.Empty;
                }
            }

            public class MHRS_RANDEVU_NUMARASI : ValueBase
            {
                public MHRS_RANDEVU_NUMARASI()
                {
                    value = string.Empty;
                }
            }
            public class TRIAJ : ValueBase
            {
                public TRIAJ()
                {
                    value = string.Empty;
                }
            }
            public class YATIS_BILGISI
            {
                public YATIS_KABUL_ZAMANI YATIS_KABUL_ZAMANI = new YATIS_KABUL_ZAMANI();
                public YATAK_NO YATAK_NO = new YATAK_NO();
                public YATIS_GUNUBIRLIK_MI YATIS_GUNUBIRLIK_MI = new YATIS_GUNUBIRLIK_MI();
                public YATISIN_ACILIYETI YATISIN_ACILIYETI = new YATISIN_ACILIYETI();
            }
            public class YATIS_KABUL_ZAMANI : ValueBase
            {
                public YATIS_KABUL_ZAMANI()
                {
                    value = string.Empty;
                }
            }
            public class YATAK_NO : ValueBase
            {
                public YATAK_NO()
                {
                    value = string.Empty;
                }
            }
            public class YATIS_GUNUBIRLIK_MI : ValueBase
            {
                public YATIS_GUNUBIRLIK_MI()
                {
                    value = string.Empty;
                }
            }

            public class SYSTakipNo : ValueBase
            {
                public SYSTakipNo()
                {
                    value = string.Empty;
                }
            }
            

            public class ADRES_BILGISI
            {
                public ADRES_KODU_SEVIYESI ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI();
                public ADRES_KODU ADRES_KODU = new ADRES_KODU();
                public ACIK_ADRES ACIK_ADRES = new ACIK_ADRES();
                public ACIK_ADRES_IL ACIK_ADRES_IL = new ACIK_ADRES_IL();
                public ACIK_ADRES_ILCE ACIK_ADRES_ILCE = new ACIK_ADRES_ILCE();
            }

            public class ADRES_KODU : ValueBase
            {
                public ADRES_KODU()
                {
                    value = string.Empty;
                }
            }
            public class ACIK_ADRES : ValueBase
            {
                public ACIK_ADRES()
                {
                    value = string.Empty;
                }
            }
            public class ACIK_ADRES_IL : ValueBase
            {
                public ACIK_ADRES_IL()
                {
                    value = string.Empty;
                }
            }
            public class ACIK_ADRES_ILCE : ValueBase
            {
                public ACIK_ADRES_ILCE()
                {
                    value = string.Empty;
                }
            }


            public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
            {
                //InternalObjectGuid bu objec için SubEpisodedur
                TTObjectContext objectContext = new TTObjectContext(true);
                SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(InternalObjectId, InternalObjectDefName);
                if (subEpisode == null)
                    throw new Exception("'101' peketini göndermek için " + InternalObjectId + " ObjectId'li SubEpisode Objesi bulunamadı");



                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

                if (myTesisSKRSKurumlarDefinition == null)
                {
                    throw new Exception("SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin");
                }


                recordData _recordData = new recordData();

                Episode episode = subEpisode.Episode;
                PatientAdmission patientAdmission = episode.PatientAdmission;
                Patient patient = episode.Patient;

                //HASTA_KIMLIK_BILGILERI
                _recordData.HASTA_KIMLIK_BILGILERI.HASTA_KIMLIK_NUMARASI.value = patient.UniqueRefNo != null ? patient.UniqueRefNo.ToString() : string.Empty;// Boş olursa karşısı hata verir
                _recordData.HASTA_KIMLIK_BILGILERI.AD.value = patient.Name;
                _recordData.HASTA_KIMLIK_BILGILERI.SOYAD.value = patient.Surname;
                _recordData.HASTA_KIMLIK_BILGILERI.DOGUM_TARIHI.value = patient.BirthDate.HasValue ? patient.BirthDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                if (patient.Sex != null)
                {
                    var sKRSCinsiyet = BaseSKRSDefinition.GetByEnumValue("SKRSCinsiyet", Convert.ToInt16(patient.Sex));
                    if (sKRSCinsiyet != null)
                        _recordData.HASTA_KIMLIK_BILGILERI.CINSIYET = new CINSIYET(((SKRSCinsiyet)sKRSCinsiyet).KODU, (((SKRSCinsiyet)sKRSCinsiyet)).ADI);
                }


                if (patient.Nationality != null)
                {
                    _recordData.HASTA_KIMLIK_BILGILERI.UYRUK = new UYRUK(patient.Nationality.MernisKodu, patient.Nationality.Adi);
                }
                else// eski hastalarda Nationality yoksa diye
                {
                    if (patient.CountryOfBirth != null)
                    {
                        var sKRSUlkeKodlari = patient.CountryOfBirth.GetSKRSDefinition();
                        if (sKRSUlkeKodlari != null)
                            _recordData.HASTA_KIMLIK_BILGILERI.UYRUK = new UYRUK(((SKRSUlkeKodlari)sKRSUlkeKodlari).Kodu, (((SKRSUlkeKodlari)sKRSUlkeKodlari)).Adi);
                    }
                }


                if (patient.Foreign == true || patient.UnIdentified == true)
                {
                    bool found = false;
                    if (patient.ForeignUniqueRefNo != null)// Yabacı Hasta No yoksa
                    {
                        _recordData.HASTA_KIMLIK_BILGILERI.YABANCI_HASTA_KIMLIK_NUMARASI.value = patient.ForeignUniqueRefNo.ToString();
                        found = true;
                    }
                    if (patient.PassportNo != null)
                    {
                        _recordData.HASTA_KIMLIK_BILGILERI.PASAPORT_NO.value = patient.PassportNo.ToString();
                        found = true;
                    }
                    if (!found)
                    {
                        if (myTesisSKRSKurumlarDefinition != null)
                            _recordData.HASTA_KIMLIK_BILGILERI.KIMLIKSIZ_HASTA_BILGISI.value = myTesisSKRSKurumlarDefinition.KODU + "_" + patient.ID.ToString();
                    }
                }



                if (patient.IsNewBorn == true) // yeni doğanın adresi annesinden alınır
                {
                    _recordData.HASTA_KIMLIK_BILGILERI.DOGUM_SIRASI.value = patient.BirthOrder != null ? Convert.ToInt32(patient.BirthOrder.Value).ToString() : string.Empty;
                    var mother = patient.Mother;
                    if (mother != null)
                    {
                        _recordData.HASTA_KIMLIK_BILGILERI.ANNE_KIMLIK_NUMARASI.value = mother.UniqueRefNo != null ? mother.UniqueRefNo.ToString() : string.Empty;

                        _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES.value = mother.HomeAddress ?? string.Empty;
                        _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES_ILCE.value = mother.SKRSAcikAdresIlce ?? string.Empty;
                        _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU.value = mother.SKRSAdresKodu ?? string.Empty;  /// TEST İÇİ:"1585604570"

                        if (mother.SKRSAdresKoduSeviyesi != null)
                            _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI(mother.SKRSAdresKoduSeviyesi.KODU, mother.SKRSAdresKoduSeviyesi.KODTIPIADI);
                        else
                            _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI("8", "İÇ KAPI");/// Default Değer // MERNISDEN GELMEZSE
                    }
                }
                else
                {
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES.value = patientAdmission.HomeAddress ?? string.Empty;
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES_ILCE.value = patientAdmission.SKRSAcikAdresIlce ?? string.Empty;
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU.value = patientAdmission.SKRSAdresKodu ?? string.Empty;  /// TEST İÇİ:"1585604570"

                    if (patientAdmission.SKRSAdresKoduSeviyesi != null)
                        _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI(patientAdmission.SKRSAdresKoduSeviyesi.KODU, patientAdmission.SKRSAdresKoduSeviyesi.KODTIPIADI);
                    else
                        _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI("8", "İÇ KAPI");/// Default Değer // MERNISDEN GELMEZSE
                }



                //HASTA_BASVURU_BILGILERI
                if (myTesisSKRSKurumlarDefinition != null)
                {
                    _recordData.HASTA_BASVURU_BILGILERI.HIZMET_SUNUCU = new HIZMET_SUNUCU(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
                    _recordData.HASTA_BASVURU_BILGILERI.KAYIT_YERI = new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);//?? Semp Policlinikleri için düzenlenmeli
                }
                _recordData.HASTA_BASVURU_BILGILERI.PROTOKOL_NUMARASI.value = episode.HospitalProtocolNo.ToString();
                _recordData.HASTA_BASVURU_BILGILERI.XXXXXX_REFERANS_NUMARASI.value = subEpisode.ObjectID.ToString();

                SubEpisodeProtocol sep = subEpisode.SGKSEP;
                if (sep != null && sep.MedulaTakipNo != null)
                    _recordData.HASTA_BASVURU_BILGILERI.SGK_TAKIP_NUMARASI.value = sep.MedulaTakipNo;

                _recordData.HASTA_BASVURU_BILGILERI.KABUL_ZAMANI.value = subEpisode.OpeningDate.Value.ToString("yyyyMMddHHmm");

                if (subEpisode.ResSection != null)
                {
                    SKRSKlinikler mySKRSKlinikler = subEpisode.ResSection.GetMySKRSKlinikler();
                    if (mySKRSKlinikler != null)
                        _recordData.HASTA_BASVURU_BILGILERI.KLINIK_KODU = new KLINIK_KODU(mySKRSKlinikler.KODU, mySKRSKlinikler.ADI);
                }

                var sKRSSosyalGuvenceDurumu = episode.LastSubEpisodeProtocol.Payer.Type.GetSKRSDefinition();
                if (sKRSSosyalGuvenceDurumu != null)
                    _recordData.HASTA_BASVURU_BILGILERI.SOSYAL_GUVENCE_DURUMU = new SOSYAL_GUVENCE_DURUMU(((SKRSSosyalGuvenceDurumu)sKRSSosyalGuvenceDurumu).KODU, ((SKRSSosyalGuvenceDurumu)sKRSSosyalGuvenceDurumu).ADI);
                var starterEpisodeAction = subEpisode.StarterEpisodeAction;
                if (starterEpisodeAction != null)
                {

                    var procedureDoctor = starterEpisodeAction.ProcedureDoctor;
                    if (procedureDoctor != null && procedureDoctor.Person != null)
                        _recordData.HASTA_BASVURU_BILGILERI.HEKIM_KIMLIK_NUMARASI.value = procedureDoctor.Person.UniqueRefNo != null ? procedureDoctor.Person.UniqueRefNo.ToString() : string.Empty;



                    if (starterEpisodeAction.PatientAdmission != null && starterEpisodeAction.PatientAdmission.AdmissionAppointment != null)
                    {
                        foreach (Appointment appointment in starterEpisodeAction.PatientAdmission.AdmissionAppointment.Appointments)
                        {
                            if (!string.IsNullOrEmpty(appointment.MHRSRandevuHrn))
                            {
                                _recordData.HASTA_BASVURU_BILGILERI.MHRS_RANDEVU_NUMARASI.value = appointment.MHRSRandevuHrn;
                                break;
                            }
                        }
                    }

                    if (starterEpisodeAction is EmergencyIntervention)
                    {
                        EmergencyIntervention emergencyIntervention = (EmergencyIntervention)starterEpisodeAction;
                        _recordData.HASTA_BASVURU_BILGILERI.TRIAJ.value = emergencyIntervention.GetTriajForENabiz();
                        if (emergencyIntervention.Emergency112RefNo != null)
                            _recordData.HASTA_BASVURU_BILGILERI.AMBULANS_TAKIP_NUMARASI.value = emergencyIntervention.Emergency112RefNo;
                    }

                    if (starterEpisodeAction is InPatientTreatmentClinicApplication)
                    {
                        InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)starterEpisodeAction;
                        _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATIS_KABUL_ZAMANI.value = inPatientTreatmentClinicApplication.ClinicInpatientDate.HasValue ? inPatientTreatmentClinicApplication.ClinicInpatientDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
                        if (inPatientTreatmentClinicApplication.BaseInpatientAdmission != null)
                        {
                            if (inPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed != null)
                                _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATAK_NO.value = inPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Name;


                            SKRSYatisinAciliyeti sKRSYatisinAciliyeti = SKRSYatisinAciliyeti.GetSKRSYatisinAciliyetiByEmergencyValue(objectContext, inPatientTreatmentClinicApplication.BaseInpatientAdmission.Emergency);
                            if (sKRSYatisinAciliyeti != null)
                                _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATISIN_ACILIYETI = new YATISIN_ACILIYETI(sKRSYatisinAciliyeti.KODU, sKRSYatisinAciliyeti.ADI);

                        }
                    }

                    _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATIS_GUNUBIRLIK_MI.value = subEpisode.GetPatientStatusForENabiz();

                }
                if (episode.PatientAdmission.SKRSVakaTuru != null)
                    _recordData.HASTA_BASVURU_BILGILERI.VAKA_TURU = new VAKA_TURU(episode.PatientAdmission.SKRSVakaTuru.KODU, episode.PatientAdmission.SKRSVakaTuru.ADI);
                else
                    _recordData.HASTA_BASVURU_BILGILERI.VAKA_TURU = new VAKA_TURU("1", "NORMAL");
                _recordData.HASTA_BASVURU_BILGILERI.SYSTakipNo.value = subEpisode.SYSTakipNo ?? String.Empty;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        }




        //214 Bulaşıcı hastalık Bildirimi
        public class BulasiciHastalikBildirim
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
                    messageType.code = "214";
                    messageType.value = "Bulasici Hastalik Bildirim Veri Seti";
                }

            }

            public class recordData
            {

                public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
                public BULASICI_HASTALIK_BILDIRIM BULASICI_HASTALIK_BILDIRIM = new BULASICI_HASTALIK_BILDIRIM();

            }

            public class HASTA_TAKIP_BILGISI
            {
                public SYSTakipNo SYSTakipNo = new SYSTakipNo();

            }

            public class BULASICI_HASTALIK_BILDIRIM
            {
                public VAKA_TIPI VAKA_TIPI = new VAKA_TIPI();
                public KLINIK_BELIRTILERIN_BASLADIGI_TARIH KLINIK_BELIRTILERIN_BASLADIGI_TARIH = new KLINIK_BELIRTILERIN_BASLADIGI_TARIH();
                public List<BILDIRIM_ADRES_BILGISI> BILDIRIM_ADRES_BILGISI;
                public List<TELEFON_BILGISI> TELEFON_BILGISI;
                public BILDIRIM_KIMLIK_BILGISI BILDIRIM_KIMLIK_BILGISI;
            }

            public class BILDIRIM_ADRES_BILGISI
            {
                public ADRES_TIPI ADRES_TIPI;
                public BUCAK_KODU BUCAK_KODU;
                public CSBM_KODU CSBM_KODU;
                public DIS_KAPI DIS_KAPI;
                public IC_KAPI IC_KAPI;
                public ILCE_KODU ILCE_KODU;
                public IL_KODU IL_KODU;
                public KOY_KODU KOY_KODU;
                public MAHALLE_KODU MAHALLE_KODU;
            }

            public class TELEFON_BILGISI
            {
                public TELEFON_NUMARASI TELEFON_NUMARASI;
                public TELEFON_TIPI TELEFON_TIPI;

            }
            public class BILDIRIM_KIMLIK_BILGISI
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
            }

            public class KLINIK_BELIRTILERIN_BASLADIGI_TARIH : ValueBase { }
            public class BUCAK_KODU : ValueBase { }
            public class CSBM_KODU : ValueBase { }
            public class DIS_KAPI : ValueBase { }
            public class IC_KAPI : ValueBase { }
            public class KOY_KODU : ValueBase { }
            public class MAHALLE_KODU : ValueBase { }
            public class TELEFON_NUMARASI : ValueBase { }






            public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
            {
                //InternalObjectGuid bu objec için SubEpisodedur
                TTObjectContext objectContext = new TTObjectContext(true);
                DiagnosisGrid diagnosisGrid = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as DiagnosisGrid;
                if (diagnosisGrid == null)
                    throw new Exception("'214' peketini göndermek için " + InternalObjectId + " ObjectId'li DiagnosisGrid Objesi bulunamadı");

                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

                if (myTesisSKRSKurumlarDefinition == null)
                {
                    throw new Exception("SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin");
                }

                recordData _recordData = new recordData();

                Patient patient = diagnosisGrid.Episode.Patient;

                //BULASICI_HASTALIK_BILDIRIM
                if (diagnosisGrid.SKRSVakaTipi != null)
                    _recordData.BULASICI_HASTALIK_BILDIRIM.VAKA_TIPI = new TTObjectClasses.CommonENabiz.VAKA_TIPI(diagnosisGrid.SKRSVakaTipi.KODU, diagnosisGrid.SKRSVakaTipi.ADI);
                _recordData.BULASICI_HASTALIK_BILDIRIM.KLINIK_BELIRTILERIN_BASLADIGI_TARIH.value = diagnosisGrid.StartTimeOfInfectious.HasValue ? diagnosisGrid.StartTimeOfInfectious.Value.ToString("yyyyMMddHHmm") : string.Empty;


                BILDIRIM_ADRES_BILGISI bildirimAdresBilgisi = new BILDIRIM_ADRES_BILGISI();

                if (patient.SKRSAdresTipi != null)
                    bildirimAdresBilgisi.ADRES_TIPI = new ADRES_TIPI(patient.SKRSAdresTipi.KODU, patient.SKRSAdresTipi.ADI);
                bildirimAdresBilgisi.BUCAK_KODU.value = patient.BucakKodu == null ? string.Empty : patient.BucakKodu.ToString();
                bildirimAdresBilgisi.CSBM_KODU.value = patient.CsbmKodu == null ? string.Empty : patient.CsbmKodu.ToString();
                bildirimAdresBilgisi.DIS_KAPI.value = patient.DisKapi == null ? string.Empty : patient.DisKapi.ToString();
                bildirimAdresBilgisi.IC_KAPI.value = patient.IcKapi == null ? string.Empty : patient.IcKapi.ToString();
                if (patient.SKRSIlceKodlari != null)
                    bildirimAdresBilgisi.ILCE_KODU = new ILCE_KODU(patient.SKRSIlceKodlari.KODU.ToString(), patient.SKRSIlceKodlari.ADI);
                if (patient.SKRSILKodlari != null)
                    bildirimAdresBilgisi.IL_KODU = new IL_KODU(patient.SKRSILKodlari.KODU.ToString(), patient.SKRSILKodlari.ADI);
                bildirimAdresBilgisi.KOY_KODU.value = patient.SKRSKoyKodlari == null ? string.Empty : patient.SKRSKoyKodlari.KODU.ToString(); ;
                bildirimAdresBilgisi.MAHALLE_KODU.value = patient.SKRSMahalleKodlari == null ? string.Empty : patient.SKRSMahalleKodlari.KODU.ToString(); ;
                _recordData.BULASICI_HASTALIK_BILDIRIM.BILDIRIM_ADRES_BILGISI.Add(bildirimAdresBilgisi);


                foreach (AdditionalAdress additionalAdress in patient.AdditionalAdresses)
                {
                    bildirimAdresBilgisi = new BILDIRIM_ADRES_BILGISI();

                    if (additionalAdress.SKRSAdresTipi != null)
                        bildirimAdresBilgisi.ADRES_TIPI = new ADRES_TIPI(additionalAdress.SKRSAdresTipi.KODU, additionalAdress.SKRSAdresTipi.ADI);
                    bildirimAdresBilgisi.BUCAK_KODU.value = additionalAdress.SKRSBucakKodlari == null ? string.Empty : additionalAdress.SKRSBucakKodlari.KODU.ToString();
                    bildirimAdresBilgisi.CSBM_KODU.value = additionalAdress.CSBMKodu == null ? string.Empty : additionalAdress.CSBMKodu.ToString();
                    bildirimAdresBilgisi.DIS_KAPI.value = additionalAdress.DisKapi == null ? string.Empty : additionalAdress.DisKapi.ToString();
                    bildirimAdresBilgisi.IC_KAPI.value = additionalAdress.IcKapi == null ? string.Empty : additionalAdress.IcKapi.ToString();
                    if (patient.SKRSIlceKodlari != null)
                        bildirimAdresBilgisi.ILCE_KODU = new ILCE_KODU(additionalAdress.SKRSIlce.KODU.ToString(), additionalAdress.SKRSIlce.ADI);
                    if (patient.SKRSILKodlari != null)
                        bildirimAdresBilgisi.IL_KODU = new IL_KODU(additionalAdress.SKRSIl.KODU.ToString(), additionalAdress.SKRSIl.ADI);
                    bildirimAdresBilgisi.KOY_KODU.value = additionalAdress.SKRSKoyKodlari == null ? string.Empty : additionalAdress.SKRSKoyKodlari.KODU.ToString(); ;
                    bildirimAdresBilgisi.MAHALLE_KODU.value = additionalAdress.SKRSMahalleKodlari == null ? string.Empty : additionalAdress.SKRSMahalleKodlari.KODU.ToString(); ;
                    _recordData.BULASICI_HASTALIK_BILDIRIM.BILDIRIM_ADRES_BILGISI.Add(bildirimAdresBilgisi);
                }

                if (!string.IsNullOrEmpty(patient.MobilePhone))
                {
                    TELEFON_BILGISI telefonBilgisi = new TELEFON_BILGISI();
                    var sKRSTelefonTipiList = SKRSTelefonTipi.GetByKodu(objectContext, "1");//İŞ
                    if (sKRSTelefonTipiList.Count > 0)
                        telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI(sKRSTelefonTipiList[0].KODU, sKRSTelefonTipiList[0].ADI);
                    telefonBilgisi.TELEFON_NUMARASI.value = patient.MobilePhone;
                    _recordData.BULASICI_HASTALIK_BILDIRIM.TELEFON_BILGISI.Add(telefonBilgisi);
                }

                if (!string.IsNullOrEmpty(patient.HomePhone))
                {
                    TELEFON_BILGISI telefonBilgisi = new TELEFON_BILGISI();
                    var sKRSTelefonTipiList = SKRSTelefonTipi.GetByKodu(objectContext, "2");//Ev
                    if (sKRSTelefonTipiList.Count > 0)
                        telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI(sKRSTelefonTipiList[0].KODU, sKRSTelefonTipiList[0].ADI);
                    telefonBilgisi.TELEFON_NUMARASI.value = patient.HomePhone;
                    _recordData.BULASICI_HASTALIK_BILDIRIM.TELEFON_BILGISI.Add(telefonBilgisi);
                }

                if (!string.IsNullOrEmpty(patient.WorkPhone))
                {
                    TELEFON_BILGISI telefonBilgisi = new TELEFON_BILGISI();
                    var sKRSTelefonTipiList = SKRSTelefonTipi.GetByKodu(objectContext, "3");//İŞ
                    if (sKRSTelefonTipiList.Count > 0)
                        telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI(sKRSTelefonTipiList[0].KODU, sKRSTelefonTipiList[0].ADI);
                    telefonBilgisi.TELEFON_NUMARASI.value = patient.WorkPhone;
                    _recordData.BULASICI_HASTALIK_BILDIRIM.TELEFON_BILGISI.Add(telefonBilgisi);
                }


                foreach (AdditionalPhone additionalPhone in patient.AdditionalPhones)
                {
                    TELEFON_BILGISI telefonBilgisi = new TELEFON_BILGISI();
                    telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI(additionalPhone.SKRSTelefonTipi.KODU, additionalPhone.SKRSTelefonTipi.ADI);
                    telefonBilgisi.TELEFON_NUMARASI.value = additionalPhone.PhoneNumber.ToString();
                    _recordData.BULASICI_HASTALIK_BILDIRIM.TELEFON_BILGISI.Add(telefonBilgisi);
                }


                BILDIRIM_KIMLIK_BILGISI bildirimKimlikBilgisi = new BILDIRIM_KIMLIK_BILGISI();

                bildirimKimlikBilgisi.HASTA_KIMLIK_NUMARASI.value = patient.UniqueRefNo != null ? patient.UniqueRefNo.ToString() : string.Empty;// Boş olursa karşısı hata verir
                bildirimKimlikBilgisi.AD.value = patient.Name;
                bildirimKimlikBilgisi.SOYAD.value = patient.Surname;
                bildirimKimlikBilgisi.DOGUM_TARIHI.value = patient.BirthDate.HasValue ? patient.BirthDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                if (patient.Sex != null)
                {
                    var sKRSCinsiyet = BaseSKRSDefinition.GetByEnumValue("SKRSCinsiyet", Convert.ToInt16(patient.Sex));
                    if (sKRSCinsiyet != null)
                        bildirimKimlikBilgisi.CINSIYET = new CINSIYET(((SKRSCinsiyet)sKRSCinsiyet).KODU, (((SKRSCinsiyet)sKRSCinsiyet)).ADI);
                }
                if (patient.Nationality != null)
                {
                    bildirimKimlikBilgisi.UYRUK = new UYRUK(patient.Nationality.MernisKodu, patient.Nationality.Adi);
                }
                else// eski hastalarda Nationality yoksa diye
                {
                    if (patient.CountryOfBirth != null)
                    {
                        var sKRSUlkeKodlari = patient.CountryOfBirth.GetSKRSDefinition();
                        if (sKRSUlkeKodlari != null)
                            bildirimKimlikBilgisi.UYRUK = new UYRUK(((SKRSUlkeKodlari)sKRSUlkeKodlari).Kodu, (((SKRSUlkeKodlari)sKRSUlkeKodlari)).Adi);
                    }
                }


                if (patient.Foreign == true || patient.UnIdentified == true)
                {
                    bool found = false;
                    if (patient.ForeignUniqueRefNo != null)// Yabacı Hasta No yoksa
                    {
                        bildirimKimlikBilgisi.YABANCI_HASTA_KIMLIK_NUMARASI.value = patient.ForeignUniqueRefNo.ToString();
                        found = true;
                    }
                    if (patient.PassportNo != null)
                    {
                        bildirimKimlikBilgisi.PASAPORT_NO.value = patient.PassportNo.ToString();
                        found = true;
                    }
                    if (!found)
                    {
                        if (myTesisSKRSKurumlarDefinition != null)
                            bildirimKimlikBilgisi.KIMLIKSIZ_HASTA_BILGISI.value = myTesisSKRSKurumlarDefinition.KODU + "_" + patient.ID.ToString();
                    }
                }

                if (patient.IsNewBorn == true) // yeni doğanın adresi annesinden alınır
                {
                    bildirimKimlikBilgisi.DOGUM_SIRASI.value = patient.BirthOrder != null ? Convert.ToInt32(patient.BirthOrder.Value).ToString() : string.Empty;
                    var mother = patient.Mother;
                    if (mother != null)
                    {
                        bildirimKimlikBilgisi.ANNE_KIMLIK_NUMARASI.value = mother.UniqueRefNo != null ? mother.UniqueRefNo.ToString() : string.Empty;
                    }
                }
               
                _recordData.BULASICI_HASTALIK_BILDIRIM.BILDIRIM_KIMLIK_BILGISI = bildirimKimlikBilgisi;

                if (diagnosisGrid.EpisodeAction.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = diagnosisGrid.EpisodeAction.SubEpisode.SYSTakipNo;


                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        
    }
        
#endregion Methods
 */
    }
   
}