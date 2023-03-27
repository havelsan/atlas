
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
    public  partial class CommonENabiz_102 : TTObject
    {
        
//        protected override void PostInsert()
//        {
//#region PostInsert
//            base.PostInsert();

//#endregion PostInsert
//        }

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
//                value = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX").ToString(); //"C740D0288F1DC45FE0407C0A04162BDD" test XXXXXX
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

        
        
//        public enum ISLEMTURU
//        {
//            ISLEM = 1,
//            ILAC = 2,
//            MALZEME = 3
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
//            public CINSIYET(int Code, string Value)
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

//            }
//            public YATISIN_ACILIYETI(int Code, string Value)
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

//            public UYRUK(int Code, string Value)
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

//            public ADRES_KODU_SEVIYESI(int Code, string Value)
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
//            public KAYIT_YERI(int Code, string Value)
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";
//                code = Code.ToString();
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
//            public HIZMET_SUNUCU(int Code, string Value)
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//        }

//        public class KLINIK_KODU : CodeBase
//        {
//            public KLINIK_KODU()
//            {
//                codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
//                version = "1";

                
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
//            public SOSYAL_GUVENCE_DURUMU(int Code, string Value)
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
//            public VAKA_TURU(int Code, string Value)
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
//            public RECETE_TURU(int Code, string Value)
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
//            public ILAC_KULLANIM_SEKLI(int Code, string Value)
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
//            public ISLEM_TURU(int Code, string Value)
//            {
//                codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
//            public ISLEM_TURU(ISLEMTURU it)
//            {
//                codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
//                version = "1";
//                code = Convert.ToInt32(it).ToString();

//                if (it == ISLEMTURU.ISLEM)
//                    value = "DIĞER (SUT, VAKA BAŞI VEYA PAKET IŞLEMLER)";
//                else if (it == ISLEMTURU.ILAC)
//                    value = "İLAÇ";
//                else if (it == ISLEMTURU.MALZEME)
//                    value = "MALZEME";


//            }
//        }
//        public class ILAC_KULLANIM_PERIYODU_BIRIMI : CodeBase
//        {
//            public ILAC_KULLANIM_PERIYODU_BIRIMI()
//            {
//                codeSystemGuid = "64408499-b82a-4e64-805e-e821aa0c64c9";
//                version = "1";

//            }
//            public ILAC_KULLANIM_PERIYODU_BIRIMI(int Code, string Value)
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
//            public RAPOR_TURU(int Code, string Value)
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
//            public ICD10(int Code, string Value)
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
//            public CIKIS_SEKLI(int Code, string Value)
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
//            public IZLEMIN_YAPILDIGI_YER(int Code, string Value)
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
//            public ASI(int Code, string Value)
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
//            public ASI_DOZU(int Code, string Value)
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
//            public ASININ_UYGULAMA_SEKLI(int Code, string Value)
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
//            public ASININ_SAGLANDIGI_KAYNAK(int Code, string Value)
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
//            public ASININ_UYGULAMA_YERI(int Code, string Value)
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
//            public YatakTuru(int Code, string Value)
//            {
//                codeSystemGuid = "51c26737-62f1-4072-8ab8-41caa7bd11da";
//                version = "1";
//                code = Code.ToString();
//                value = Value;
//            }
            
//        }
        
        
//        /// SKRSObject
        
        
        
//        /// Class Tanımları
//        public class HizmetIlacMalzemeBilgisiKayit
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
//                    messageType.code = "102";
//                    messageType.value = "Hizmet/Ilaç/Malzeme Bilgisi Kayıt";
//                }
//            }

//            public class recordData
//            {
//                public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
//                public HASTA_ISLEM_BILGILERI HASTA_ISLEM_BILGILERI;
                
//            }
//            public class HASTA_TAKIP_BILGISI
//            {
//                public SYSTakipNo SYSTakipNo = new SYSTakipNo();
//            }

//            public class HASTA_ISLEM_BILGILERI
//            {
//                [System.Xml.Serialization.XmlElement("ISLEM_BILGISI", Type = typeof(ISLEM_BILGISI))]
//                public List<ISLEM_BILGISI> ISLEM_BILGISI = new List<ISLEM_BILGISI>();
//            }

//            public class ISLEM_BILGISI
//            {
//                public KLINIK_KODU KLINIK_KODU = new KLINIK_KODU();
//                public GERCEKLESME_ZAMANI GERCEKLESME_ZAMANI = new GERCEKLESME_ZAMANI();
//                public ISLEM_TURU ISLEM_TURU = new ISLEM_TURU();
//                public ISLEM_KODU ISLEM_KODU = new ISLEM_KODU();
//                public ISLEM_ADI ISLEM_ADI = new ISLEM_ADI();
//                public GIRISIMSEL_ISLEM_KODU GIRISIMSEL_ISLEM_KODU = new GIRISIMSEL_ISLEM_KODU();
//                public ISLEM_ZAMANI ISLEM_ZAMANI = new ISLEM_ZAMANI();
//                public ADET ADET = new ADET();
//                public HASTA_TUTARI HASTA_TUTARI = new HASTA_TUTARI();
//                public KURUM_TUTARI KURUM_TUTARI = new KURUM_TUTARI();
//                public RANDEVU_ZAMANI RANDEVU_ZAMANI = new RANDEVU_ZAMANI();
//                public KULLANICI_KIMLIK_NUMARASI KULLANICI_KIMLIK_NUMARASI = new KULLANICI_KIMLIK_NUMARASI();
//                public CIHAZ_NUMARASI CIHAZ_NUMARASI = new CIHAZ_NUMARASI();
//                public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();

//                [System.Xml.Serialization.XmlElement("ISLEM_PUAN_BILGISI", Type = typeof(ISLEM_PUAN_BILGISI))]
//                public List<ISLEM_PUAN_BILGISI> ISLEM_PUAN_BILGISI = new List<ISLEM_PUAN_BILGISI>();

//            }

            
//            public class GERCEKLESME_ZAMANI :ValueBase
//            {
//                public GERCEKLESME_ZAMANI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ISLEM_KODU : ValueBase
//            {
//                public ISLEM_KODU()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ISLEM_ADI : ValueBase
//            {
//                public ISLEM_ADI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class GIRISIMSEL_ISLEM_KODU : ValueBase
//            {
//                public GIRISIMSEL_ISLEM_KODU()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ISLEM_ZAMANI : ValueBase
//            {
//                public ISLEM_ZAMANI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ADET : ValueBase
//            {
//                public ADET()
//                {
//                    value = "1";
//                }
//            }
//            public class HASTA_TUTARI : ValueBase
//            {
//                public HASTA_TUTARI()
//                {
//                    value = "0";
//                }
//            }
//            public class KURUM_TUTARI : ValueBase
//            {
//                public KURUM_TUTARI()
//                {
//                    value = "0";
//                }
//            }
//            public class RANDEVU_ZAMANI : ValueBase
//            {
//                public RANDEVU_ZAMANI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class KULLANICI_KIMLIK_NUMARASI : ValueBase
//            {
//                public KULLANICI_KIMLIK_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class CIHAZ_NUMARASI : ValueBase
//            {
//                public CIHAZ_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ISLEM_REFERANS_NUMARASI : ValueBase
//            {
//                public ISLEM_REFERANS_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ISLEM_PUAN_BILGISI
//            {
//                public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
//                public ISLEM_PUANI ISLEM_PUANI = new ISLEM_PUANI();
//                public PUAN_HAKEDIS_ZAMANI PUAN_HAKEDIS_ZAMANI = new PUAN_HAKEDIS_ZAMANI();

//            }
//            public class HEKIM_KIMLIK_NUMARASI : ValueBase
//            {
//                public HEKIM_KIMLIK_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ISLEM_PUANI : ValueBase
//            {
//                public ISLEM_PUANI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class PUAN_HAKEDIS_ZAMANI : ValueBase
//            {
//                public PUAN_HAKEDIS_ZAMANI()
//                {
//                    value = string.Empty;
//                }
//            }

//            public static SYSMessage Get(Guid  InternalObjectGuid, string InternalObjectDefName)
//            {
//                //InternalObjectGuid bu object için SubEpisodeID olacak
//                recordData _recordData = new recordData();

//                //internalobjectguid e subactionprocedure veya subactionmaterial gelecek, onlar secilerek bilgileri doldurulacak
//                TTObjectContext objectContext = new TTObjectContext(false);
                
//                SubActionProcedure sp = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubActionProcedure;
//                if (sp != null)
//                {
//                    if (!sp.IsCancelled)
//                    {
//                        if (sp.SubEpisode.SYSTakipNo == null)
//                            throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
//                        else
//                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SubEpisode.SYSTakipNo;
                        
//                        _recordData.HASTA_ISLEM_BILGILERI = new HASTA_ISLEM_BILGILERI();
                        
//                        ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
//                        SpecialityDefinition Speciality;
//                        string resBrans ="";
//                        resBrans = sp.EpisodeAction.GetBranchCodeForMedula();
//                        if (resBrans != null)
//                        {
//                            IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
//                            if (specialtyList.Count > 0)
//                                Speciality = (SpecialityDefinition)specialtyList[0];
//                            else
//                                throw new Exception("Hizmetin verildiği uzmanlık dalı kodu bulunamadı.");
                            
//                            if (Speciality.SKRSKlinik != null )
//                                ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
//                            else
//                                throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");
                            
//                            ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;
//                            ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ISLEM);
//                            ISLEM_BILGISI.ISLEM_KODU.value = (sp.ProcedureObject.Code != null ? sp.ProcedureObject.Code.ToString().Replace(".","").ToString().Replace("-","").ToString().Replace(",","") : string.Empty); //TODO: code un sut daki kod alanından gelecek.
//                            ISLEM_BILGISI.ISLEM_ADI.value = (sp.ProcedureObject.Name != null ? sp.ProcedureObject.Name : string.Empty);  //TODO: ismi sut daki ısım alanından gelecek.

//                            ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = ISLEM_BILGISI.ISLEM_KODU.value; //TODO:code ile ayni olması kararlastırıldı

//                            DateTime updatedDate =  Convert.ToDateTime("01/01/1900");
//                            if (sp.CreationDate != null)
//                            {
//                                updatedDate = (DateTime)sp.CreationDate;
//                                if ( (DateTime)sp.CreationDate <=  (DateTime)sp.SubEpisode.OpeningDate )
//                                {
//                                    updatedDate = (DateTime)Convert.ToDateTime(sp.SubEpisode.OpeningDate).AddMinutes(1);
//                                    ISLEM_BILGISI.ISLEM_ZAMANI.value = updatedDate.ToString("yyyyMMddHHmm");
//                                }
//                                else
//                                    ISLEM_BILGISI.ISLEM_ZAMANI.value = sp.CreationDate.Value.ToString("yyyyMMddHHmm");
//                            }
//                            else
//                                ISLEM_BILGISI.ISLEM_ZAMANI.value = string.Empty;
                            
                            
//                            ISLEM_BILGISI.ADET.value = (sp.Amount != null ? sp.Amount.ToString() : "1");
                            
//                            double hastaTutar = 0;
//                            double kurumTutar = 0;
//                            foreach (AccountTransaction at in sp.AccountTransactions)
//                            {
//                                if (!at.IsCancelled)
//                                {
//                                    if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PATIENT)
//                                        hastaTutar = hastaTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
//                                    if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PAYER)
//                                        kurumTutar = kurumTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                    
//                                    if (  (DateTime)at.TransactionDate <= (DateTime)updatedDate  )
//                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = updatedDate.AddMinutes(1).ToString("yyyyMMddHHmm");
//                                    else
//                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (at.TransactionDate != null ? at.TransactionDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
//                                }
//                            }
//                            if (hastaTutar > 0)
//                                ISLEM_BILGISI.HASTA_TUTARI.value = hastaTutar.ToString().Replace(",",".");
//                            if (kurumTutar > 0)
//                                ISLEM_BILGISI.KURUM_TUTARI.value = kurumTutar.ToString().Replace(",",".");
                            
//                            if (sp.MyCompletedAppointments.Count > 0)
//                                ISLEM_BILGISI.RANDEVU_ZAMANI.value = ( sp.MyCompletedAppointments[0].AppDate != null ? sp.MyCompletedAppointments[0].AppDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
//                            else
//                                ISLEM_BILGISI.RANDEVU_ZAMANI.value =  "";
                            
                            
//                            if (sp.RequestedByUser != null)
//                            {
//                                if (sp.RequestedByUser.Person != null)
//                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (sp.RequestedByUser.Person.UniqueRefNo != null ? sp.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
//                                else
//                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
//                            }
//                            else
//                                ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                            
//                            ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
//                            ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = sp.ObjectID.ToString() ;

//                            // performans tutulmuyor.
//                            /*   ISLEM_PUAN_BILGISI ISLEM_PUAN_BILGISI = new ISLEM_PUAN_BILGISI();
//                                    ISLEM_PUAN_BILGISI.HEKIM_KIMLIK_NUMARASI.value = "";
//                                    ISLEM_PUAN_BILGISI.ISLEM_PUANI.value = "";
//                                    ISLEM_PUAN_BILGISI.PUAN_HAKEDIS_ZAMANI.value = "";
                                
//                                    ISLEM_BILGISI.ISLEM_PUAN_BILGISI = new List<ISLEM_PUAN_BILGISI>();
//                                    ISLEM_BILGISI.ISLEM_PUAN_BILGISI.Add(ISLEM_PUAN_BILGISI);
//                             */
//                            _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI = new List<ISLEM_BILGISI>();
//                            _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
//                        }
//                        else
//                            throw new Exception("Hizmetin verildiği bölümün branş kodu bulunamadı.");
//                    }
//                    else
//                        throw new Exception("SubactionProcedure iptal edilmiş.");
//                }
//                else
//                {
//                    SubActionMaterial sm = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubActionMaterial;
//                    if (sm != null)
//                    {
//                        if (!sm.IsCancelled)
//                        {
//                            if (sm.SubEpisode.SYSTakipNo == null)
//                                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
//                            else
//                                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sm.SubEpisode.SYSTakipNo;
                            
//                            _recordData.HASTA_ISLEM_BILGILERI = new HASTA_ISLEM_BILGILERI();
                            
//                            ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
//                            SpecialityDefinition Speciality;
//                            string resBrans ="";
                            
//                            if (sm.EpisodeAction != null)
//                                resBrans = sm.EpisodeAction.GetBranchCodeForMedula();
//                            else
//                                resBrans = sm.SubactionProcedureFlowable.GetBranchCodeForMedula();
                            
//                            if (resBrans != null)
//                            {
//                                IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
//                                if (specialtyList.Count > 0)
//                                    Speciality = (SpecialityDefinition)specialtyList[0];
//                                else
//                                    throw new Exception("Hizmetin verildiği uzmanlık dalı kodu bulunamadı.");
                                
//                                if (Speciality.SKRSKlinik != null )
//                                    ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
//                                else
//                                    throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");
                                
//                                ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;
                                
//                                if (sm.Material is Material)
//                                    ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.MALZEME);
//                                else if (sm.Material is DrugDefinition)
//                                    ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ILAC);
                                
//                                ISLEM_BILGISI.ISLEM_KODU.value = (sm.Material.Barcode != null ? sm.Material.Barcode : string.Empty);
//                                ISLEM_BILGISI.ISLEM_ADI.value = (sm.Material.Name != null ? sm.Material.Name : string.Empty);

//                                ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = "";

//                                ISLEM_BILGISI.ISLEM_ZAMANI.value = (sm.CreationDate != null ? sm.CreationDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
//                                ISLEM_BILGISI.ADET.value = (sm.Amount != null ? sm.Amount.ToString() : "1");
                                
//                                double hastaTutar = 0;
//                                double kurumTutar = 0;
//                                foreach (AccountTransaction at in sm.AccountTransactions)
//                                {
//                                    if (!at.IsCancelled)
//                                    {
//                                        if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PATIENT)
//                                            hastaTutar = hastaTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
//                                        if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PAYER)
//                                            kurumTutar = kurumTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                        
//                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (at.TransactionDate != null ? at.TransactionDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
//                                    }
//                                }
//                                if (hastaTutar > 0)
//                                    ISLEM_BILGISI.HASTA_TUTARI.value = hastaTutar.ToString().Replace(",",".");
//                                if (kurumTutar > 0)
//                                    ISLEM_BILGISI.KURUM_TUTARI.value = kurumTutar.ToString().Replace(",",".");
                                

//                                ISLEM_BILGISI.RANDEVU_ZAMANI.value =  "";
                                
//                                if (sm.RequestedByUser != null)
//                                {
//                                    if (sm.RequestedByUser.Person != null)
//                                        ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (sm.RequestedByUser.Person.UniqueRefNo != null ? sm.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
//                                    else
//                                        ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
//                                }
//                                else
//                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                                
//                                ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
//                                ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = sm.ObjectID.ToString() ;
                                
//                                _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI = new List<ISLEM_BILGISI>();
//                                _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
//                            }
//                            else
//                                throw new Exception("Hizmetin verildiği bölümün branş kodu bulunamadı.");
//                        }
//                        else
//                            throw new Exception("SubactionMaterial iptal edilmiş.");
//                    }

//                }

//                SYSMessage _sYSMessage = new SYSMessage();
//                _sYSMessage.recordData = _recordData;
//                return _sYSMessage;
                
//            }
//        }
        
//#endregion Methods
    
    }
}