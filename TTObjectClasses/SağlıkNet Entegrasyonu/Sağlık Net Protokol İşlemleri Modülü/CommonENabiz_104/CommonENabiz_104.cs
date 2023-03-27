
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
    public  partial class CommonENabiz_104 : TTObject
    {
//#region Methods
//        /// ClassHelper
//        public class Utf8StringWriter : System.IO.StringWriter
//        {
//            public override Encoding Encoding { get { return Encoding.UTF8; } }
//        }
//        public class messageGuid : ValueBase
//        {
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
//            public healthcareProvider healthcareProvider = new healthcareProvider(999997, "TEST DEVLET XXXXXXSİ");
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

//            public healthcareProvider(int Code, string Value)
//            {
//                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
//                version = "1";
//                code = Code.ToString();
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
//            public KLINIK_KODU(int Code, string Value)
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
//        public class FaturaBilgisiKayit
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
//                    messageType.code = "104";
//                    messageType.value = "Fatura Bilgisi Kayit";
//                }
//            }

//            public class recordData
//            {
//                public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
//                //public HASTA_FATURA_BILGILERI HASTA_FATURA_BILGILERI = new HASTA_FATURA_BILGILERI();
//                public FATURA_BILGILERI FATURA_BILGILERI = new FATURA_BILGILERI();

//            }

//            public class HASTA_TAKIP_BILGISI
//            {
//                public SYSTakipNo SYSTakipNo = new SYSTakipNo();
//            }

//            public class HASTA_FATURA_BILGILERI
//            {
//                public FATURA_TARIHI FATURA_TARIHI = new FATURA_TARIHI();
//                public FATURA_TUTARI FATURA_TUTARI = new FATURA_TUTARI();
//                public MEDULA_TESLIM_NUMARASI MEDULA_TESLIM_NUMARASI = new MEDULA_TESLIM_NUMARASI();

//                [System.Xml.Serialization.XmlElement("ISLEM_FATURA_BILGISI", Type = typeof(ISLEM_FATURA_BILGISI))]
//                public List<ISLEM_FATURA_BILGISI> ISLEM_FATURA_BILGISI = new List<ISLEM_FATURA_BILGISI>();
//            }
            
//            public class FATURA_TARIHI : ValueBase { }
//            public class FATURA_TUTARI : ValueBase { }
//            public class MEDULA_TESLIM_NUMARASI : ValueBase { }
//            public class ISLEM_FATURA_BILGISI
//            {
//                public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
//                public ISLEM_FATURA_TUTARI ISLEM_FATURA_TUTARI = new ISLEM_FATURA_TUTARI();
//            }

//            public class ISLEM_REFERANS_NUMARASI : ValueBase { }
//            public class ISLEM_FATURA_TUTARI : ValueBase { }

//            public class FATURA_BILGILERI
//            {
//                [System.Xml.Serialization.XmlElement("FATURA_BILGISI", Type = typeof(FATURA_BILGISI))]
//                public List<FATURA_BILGISI> FATURA_BILGISI = new List<FATURA_BILGISI>();
//            }

//            public class FATURA_BILGISI
//            {
//                public FATURA_TARIHI FATURA_TARIHI = new FATURA_TARIHI();
//                public FATURA_TUTARI FATURA_TUTARI = new FATURA_TUTARI();
//                public MEDULA_TESLIM_NUMARASI MEDULA_TESLIM_NUMARASI = new MEDULA_TESLIM_NUMARASI();
//                public FATURA_NUMARASI FATURA_NUMARASI = new FATURA_NUMARASI();

//                [System.Xml.Serialization.XmlElement("ISLEM_FATURA_BILGISI", Type = typeof(ISLEM_FATURA_BILGISI))]
//                public List<ISLEM_FATURA_BILGISI> ISLEM_FATURA_BILGISI = new List<ISLEM_FATURA_BILGISI>();
//            }

//            public class FATURA_NUMARASI : ValueBase { }

            
//            public static SYSMessage Get(Guid InternalObjectID, string InternalObjectDefName)
//            {
//                SYSMessage _SYSMessage = new SYSMessage();
                
//                if(InternalObjectDefName.Equals("MEDULAPROVISION"))
//                {
//                    TTObjectContext objectContext = new TTObjectContext(true);
                    
//                    MedulaProvision medulaProvision = objectContext.GetObject(InternalObjectID, InternalObjectDefName) as MedulaProvision;
//                    if (medulaProvision == null)
//                        throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli MedulaProvision objesi bulunamadı.");
                    
//                    if (medulaProvision.SubEpisode == null)
//                        throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli SubEpisode objesi bulunamadı.");

//                    if (medulaProvision.MedulaInvoice == null)
//                        throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli MedulaInvoice objesi bulunamadı.");
                    
//                    if(string.IsNullOrEmpty(medulaProvision.SubEpisode.SYSTakipNo))
//                        throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli SYSTakipNo bulunamadı.");
                    
//                    _SYSMessage.recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = medulaProvision.SubEpisode.SYSTakipNo;
                    
//                    FATURA_BILGISI faturaBilgisi = new FATURA_BILGISI();

//                    if (medulaProvision.MedulaInvoice.InvoiceDate.HasValue)
//                        faturaBilgisi.FATURA_TARIHI.value = medulaProvision.MedulaInvoice.InvoiceDate.Value.ToString("yyyyMMddHHmm");

//                    if (medulaProvision.InvoicePrice.HasValue)
//                        faturaBilgisi.FATURA_TUTARI.value = medulaProvision.InvoicePrice.Value.ToString().Replace(',','.');

//                    faturaBilgisi.MEDULA_TESLIM_NUMARASI.value = medulaProvision.MedulaInvoice.InvoiceDeliveryNo;
//                    faturaBilgisi.FATURA_NUMARASI.value = medulaProvision.MedulaInvoice.InvoiceReferenceNo.ToString();

//                    // Takip içindeki medulaya kaydedilmiş Hizmet Malzeme ve İlaç Bilgileri ISLEM_FATURA_BILGISI ne eklenir
//                    List<Guid> subEpisodeList = new List<Guid>();
//                    subEpisodeList.Add(medulaProvision.SubEpisode.ObjectID);
//                    // TODO:SEP
//                    IList<AccountTransaction> accTrxList = null; // AccountTransaction.GetTransactionsWithMedulaProcessNoBySEP(objectContext, subEpisodeList);
                    
//                    foreach(AccountTransaction accTrx in accTrxList)
//                    {
//                        if(accTrx.SubActionProcedure != null || accTrx.SubActionMaterial != null)
//                        {
//                            ISLEM_FATURA_BILGISI islemFaturaBilgisi = new ISLEM_FATURA_BILGISI();
                            
//                            if(accTrx.SubActionProcedure != null)
//                                islemFaturaBilgisi.ISLEM_REFERANS_NUMARASI.value = accTrx.SubActionProcedure.ObjectID.ToString();
//                            else if(accTrx.SubActionMaterial != null)
//                                islemFaturaBilgisi.ISLEM_REFERANS_NUMARASI.value = accTrx.SubActionMaterial.ObjectID.ToString();
                            
//                            if(accTrx.MedulaPrice.HasValue)
//                                islemFaturaBilgisi.ISLEM_FATURA_TUTARI.value = accTrx.MedulaPrice.Value.ToString().Replace(',','.');

//                            faturaBilgisi.ISLEM_FATURA_BILGISI.Add(islemFaturaBilgisi);
//                        }
//                    }

//                    _SYSMessage.recordData.FATURA_BILGILERI.FATURA_BILGISI.Add(faturaBilgisi);
//                }

//                return _SYSMessage;
//            }
//        }
        
//#endregion Methods

    }
}