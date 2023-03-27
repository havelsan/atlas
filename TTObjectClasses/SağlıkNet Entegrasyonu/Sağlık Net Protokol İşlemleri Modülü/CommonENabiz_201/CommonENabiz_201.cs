
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
    public  partial class CommonENabiz_201 : TTObject
    {
//#region Methods
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
//                value = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX").ToString(); //"C740D0288F1DC45FE0407C0A04162BDD";

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
        
//         public class SYSTakipNo : ValueBase
//        {
//            public SYSTakipNo()
//            {
                
//            }
//            public SYSTakipNo(string Value)
//            {
//                value = Value;
//            }
//        }
         
//        public class PatolojiKayit
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
//                    messageType.code = "201";
//                    messageType.value = "Patoloji Kayıt";
//                }

//            }


//            /// SKRSObject

//            public class ISTEM_YAPILAN_KLINIK : CodeBase
//            {
//                public ISTEM_YAPILAN_KLINIK()
//                {
//                    codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
//                    version = "1";

//                }
//                public ISTEM_YAPILAN_KLINIK(string Code, string Value)
//                {
//                    codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
//                    version = "1";
//                    code = Code.ToString();
//                    value = Value;
//                }
//            }

//            public class NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI : CodeBase
//            {
//                public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI()
//                {
//                    codeSystemGuid = "cf34c46d-c31f-4922-9b74-68cc69412cfc";
//                    version = "1";

//                }
//                public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI(string Code, string Value)
//                {
//                    codeSystemGuid = "cf34c46d-c31f-4922-9b74-68cc69412cfc";
//                    version = "1";
//                    code = Code.ToString();
//                    value = Value;
//                }
//            }

//            public class NUMUNE_ALINMA_SEKLI : CodeBase
//            {
//                public NUMUNE_ALINMA_SEKLI()
//                {
//                    codeSystemGuid = "051c2db0-f724-457a-ac46-7d3a741b7ae2";
//                    version = "1";

//                }
//                public NUMUNE_ALINMA_SEKLI(string Code, string Value)
//                {
//                    codeSystemGuid = "051c2db0-f724-457a-ac46-7d3a741b7ae2";
//                    version = "1";
//                    code = Code.ToString();
//                    value = Value;
//                }
//            }

//            public class PREPARAT_DURUMU : CodeBase
//            {
//                public PREPARAT_DURUMU()
//                {
//                    codeSystemGuid = "4016f2d2-9b44-43e1-834d-d1c045419fea";
//                    version = "1";

//                }
//                public PREPARAT_DURUMU(string Code, string Value)
//                {
//                    codeSystemGuid = "4016f2d2-9b44-43e1-834d-d1c045419fea";
//                    version = "1";
//                    code = Code.ToString();
//                    value = Value;
//                }
//            }

//            public class YERLESIM_YERI : CodeBase
//            {
//                public YERLESIM_YERI()
//                {
//                    codeSystemGuid = "fc24f548-c383-4855-be0b-0f1d23599bba";
//                    version = "1";

//                }
//                public YERLESIM_YERI(int Code, string Value)
//                {
//                    codeSystemGuid = "fc24f548-c383-4855-be0b-0f1d23599bba";
//                    version = "1";
//                    code = Code.ToString();
//                    value = Value;
//                }
//            }

//            public class MORFOLOJI_KODU : CodeBase
//            {
//                public MORFOLOJI_KODU()
//                {
//                    codeSystemGuid = "40220f50-1c9c-43c9-9bbd-45794d5cc7b2";
//                    version = "1";

//                }
//                public MORFOLOJI_KODU(string Code, string Value)
//                {
//                    codeSystemGuid = "40220f50-1c9c-43c9-9bbd-45794d5cc7b2";
//                    version = "1";
//                    code = Code.ToString();
//                    value = Value;
//                }
//            }

//            /// SKRSObject

//            public class recordData
//            {

//                public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
//                public HASTA_PATOLOJI_BILGILERI HASTA_PATOLOJI_BILGILERI = new HASTA_PATOLOJI_BILGILERI();

//            }

//            public class HASTA_TAKIP_BILGISI
//            {
//                public SYSTakipNo SYSTakipNo = new SYSTakipNo();

//            }

//            public class HASTA_PATOLOJI_BILGILERI
//            {
//                [System.Xml.Serialization.XmlElement("PATOLOJI_BILGISI", Type = typeof(PATOLOJI_BILGISI))]
//                public List<PATOLOJI_BILGISI> PATOLOJI_BILGISI = new List<PATOLOJI_BILGISI>();
//            }


//            public class PATOLOJI_BILGISI
//            {
//                public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
//                public ISTEM_ZAMANI ISTEM_ZAMANI = new ISTEM_ZAMANI();
//                public ISTEM_YAPILAN_KLINIK ISTEM_YAPILAN_KLINIK = new ISTEM_YAPILAN_KLINIK();
//                public ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI = new ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI();
//                public RAPORLAMA_ZAMANI RAPORLAMA_ZAMANI = new RAPORLAMA_ZAMANI();
//                public RAPORLAYAN_HEKIM_KIMLIK_NUMARASI RAPORLAYAN_HEKIM_KIMLIK_NUMARASI = new RAPORLAYAN_HEKIM_KIMLIK_NUMARASI();
//                public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI = new NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI();
//                public NUMUNE_ALINMA_SEKLI NUMUNE_ALINMA_SEKLI = new NUMUNE_ALINMA_SEKLI();
//                public PREPARAT_DURUMU PREPARAT_DURUMU = new PREPARAT_DURUMU();
//                public YERLESIM_YERI YERLESIM_YERI = new YERLESIM_YERI();
//                public MORFOLOJI_KODU MORFOLOJI_KODU = new MORFOLOJI_KODU();
//                public TETKIK_SONUCU TETKIK_SONUCU = new TETKIK_SONUCU();


//            }

//            public class ISLEM_REFERANS_NUMARASI : ValueBase {
//                public ISLEM_REFERANS_NUMARASI()
//                {
//                    value = string.Empty;
//                }

//            }
//            public class ISTEM_ZAMANI : ValueBase
//            {
//                public ISTEM_ZAMANI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI : ValueBase
//            {
//                public ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPORLAMA_ZAMANI : ValueBase {
//                public RAPORLAMA_ZAMANI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class RAPORLAYAN_HEKIM_KIMLIK_NUMARASI : ValueBase {
//                public RAPORLAYAN_HEKIM_KIMLIK_NUMARASI()
//                {
//                    value = string.Empty;
//                }
//            }
//            public class TETKIK_SONUCU : ValueBase {
//                public TETKIK_SONUCU()
//                {
//                    value = string.Empty;
//                }
//            }

//            public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
//            {
//                recordData _recordData = new recordData();

//                TTObjectContext objectContext = new TTObjectContext(false);

//                PathologyTest sp = (PathologyTest)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);

//                if (sp != null)
//                {
//                    if (sp.SubEpisode.SYSTakipNo == null)
//                        throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
//                    else
//                        _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SubEpisode.SYSTakipNo;

//                    _recordData.HASTA_PATOLOJI_BILGILERI = new HASTA_PATOLOJI_BILGILERI();

//                    PATOLOJI_BILGISI PATOLOJI_BILGISI = new PATOLOJI_BILGISI();
//                    PATOLOJI_BILGISI.ISLEM_REFERANS_NUMARASI.value = sp.ObjectID.ToString();
//                    PATOLOJI_BILGISI.ISTEM_ZAMANI.value = sp.CreationDate.Value.ToString("yyyyMMddHHmm");
                  

//                    TTObjectClasses.SpecialityDefinition Speciality;
//                    string resBrans = sp.EpisodeAction.GetBranchCodeForMedula();
//                    if (resBrans != null)
//                    {
//                        IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
//                        if (specialtyList.Count > 0)
//                            Speciality = (SpecialityDefinition)specialtyList[0];
//                        else
//                            throw new Exception("Hizmetin verildiği uzmanlık dalı kodu bulunamadı.");

//                        if (Speciality.SKRSKlinik != null)
//                            PATOLOJI_BILGISI.ISTEM_YAPILAN_KLINIK = new ISTEM_YAPILAN_KLINIK(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI);
//                        else
//                            throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");
//                    }

//                    PATOLOJI_BILGISI.RAPORLAMA_ZAMANI.value = sp.ReportDate.Value.ToString("yyyyMMddHHmm");

//                    if (sp.ResponsibleDoctor != null)
//                    {
//                        if(sp.ResponsibleDoctor.Person != null)
//                            PATOLOJI_BILGISI.RAPORLAYAN_HEKIM_KIMLIK_NUMARASI.value = (sp.ResponsibleDoctor.Person.UniqueRefNo != null ? sp.ResponsibleDoctor.Person.UniqueRefNo.ToString() : string.Empty); 
//                        else
//                            PATOLOJI_BILGISI.RAPORLAYAN_HEKIM_KIMLIK_NUMARASI.value = "";
//                    }
//                    else
//                        PATOLOJI_BILGISI.RAPORLAYAN_HEKIM_KIMLIK_NUMARASI.value = "";


//                    PATOLOJI_BILGISI.NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI = new NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI(sp.PatolojiDokununTemelOzelligi.KODU, sp.PatolojiDokununTemelOzelligi.ADI);
//                    PATOLOJI_BILGISI.NUMUNE_ALINMA_SEKLI = new NUMUNE_ALINMA_SEKLI(sp.PatolojiNumuneAlinmaSekli.KODU, sp.PatolojiNumuneAlinmaSekli.ADI);
//                    PATOLOJI_BILGISI.PREPARAT_DURUMU = new PREPARAT_DURUMU(sp.PatolojiPreparatDurumu.KODU, sp.PatolojiPreparatDurumu.ADI);
//                    PATOLOJI_BILGISI.YERLESIM_YERI = new YERLESIM_YERI(sp.PatolojiICDOYerlesimYeri.SKRSKODU.Value,sp.PatolojiICDOYerlesimYeri.KODTANIMI);
//                    PATOLOJI_BILGISI.MORFOLOJI_KODU = new MORFOLOJI_KODU(sp.PatolojiMorfolojiKodu.MORFOLOJIKOD,sp.PatolojiMorfolojiKodu.MORFOLOJIKODTANIM);
//                    if (sp.ReportMacroscopi != null)
//                        PATOLOJI_BILGISI.TETKIK_SONUCU.value = sp.ReportMacroscopi.ToString();
//                    else if (sp.ReportMicroscopi != null)
//                        PATOLOJI_BILGISI.TETKIK_SONUCU.value = sp.ReportMicroscopi.ToString();
//                    else
//                        PATOLOJI_BILGISI.TETKIK_SONUCU.value = "";

//                    _recordData.HASTA_PATOLOJI_BILGILERI.PATOLOJI_BILGISI = new List<PATOLOJI_BILGISI>();
//                    _recordData.HASTA_PATOLOJI_BILGILERI.PATOLOJI_BILGISI.Add(PATOLOJI_BILGISI);

//                }

//                SYSMessage _sYSMessage = new SYSMessage();
//                _sYSMessage.recordData = _recordData;
//                return _sYSMessage;
//            }


//        }
        
//#endregion Methods

    }
}