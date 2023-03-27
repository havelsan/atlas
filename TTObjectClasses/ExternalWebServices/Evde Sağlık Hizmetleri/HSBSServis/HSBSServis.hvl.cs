
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HSBSServis")] 

    public  partial class HSBSServis : TTObject
    {
        public class HSBSServisList : TTObjectCollection<HSBSServis> { }
                    
        public class ChildHSBSServisCollection : TTObject.TTChildObjectCollection<HSBSServis>
        {
            public ChildHSBSServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHSBSServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static AHB_STOK_GIRIS_LISTESI AHB_STOK_GIRISI_GETIRSync(Guid siteID, USER user, System.DateTime Tarih, bool TarihSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (AHB_STOK_GIRIS_LISTESI) TTMessageFactory.SyncCall(siteID, new Guid("0e31a2d2-bb61-4bc4-af09-0ce513dc726a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","AHB_STOK_GIRISI_GETIRSync_ServerSide", user, Tarih, TarihSpecified);
            }


            private static AHB_STOK_GIRIS_LISTESI AHB_STOK_GIRISI_GETIRSync_ServerSide(USER user, System.DateTime Tarih, bool TarihSpecified)
            {

#region AHB_STOK_GIRISI_GETIRSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "AHB_STOK_GIRISI_GETIR";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("Tarih", (object)Tarih),
                        Tuple.Create("TarihSpecified", (object)TarihSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    AHB_STOK_GIRIS_LISTESI cevap = default(AHB_STOK_GIRIS_LISTESI);
                    cevap = (AHB_STOK_GIRIS_LISTESI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion AHB_STOK_GIRISI_GETIRSync_Body

            }

            public static ASM_STOK_GIRIS_LISTESI ASM_STOK_GIRISI_GETIRSync(Guid siteID, USER user, System.DateTime Tarih, bool TarihSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ASM_STOK_GIRIS_LISTESI) TTMessageFactory.SyncCall(siteID, new Guid("30a7fe80-3558-4850-b6bd-09a32efe5c79"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","ASM_STOK_GIRISI_GETIRSync_ServerSide", user, Tarih, TarihSpecified);
            }


            private static ASM_STOK_GIRIS_LISTESI ASM_STOK_GIRISI_GETIRSync_ServerSide(USER user, System.DateTime Tarih, bool TarihSpecified)
            {

#region ASM_STOK_GIRISI_GETIRSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "ASM_STOK_GIRISI_GETIR";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("Tarih", (object)Tarih),
                        Tuple.Create("TarihSpecified", (object)TarihSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    ASM_STOK_GIRIS_LISTESI cevap = default(ASM_STOK_GIRIS_LISTESI);
                    cevap = (ASM_STOK_GIRIS_LISTESI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ASM_STOK_GIRISI_GETIRSync_Body

            }

            public static SONUC_EVDESAGLIK_ISLEMLER EvdeSaglikBasvuruKaydetSync(Guid siteID, EVDESAGLIK_BASVURUSU basvurukaydi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (SONUC_EVDESAGLIK_ISLEMLER) TTMessageFactory.SyncCall(siteID, new Guid("10a04235-4e44-4822-9258-0dbcae7d1efd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","EvdeSaglikBasvuruKaydetSync_ServerSide", basvurukaydi);
            }


            private static SONUC_EVDESAGLIK_ISLEMLER EvdeSaglikBasvuruKaydetSync_ServerSide(EVDESAGLIK_BASVURUSU basvurukaydi)
            {

#region EvdeSaglikBasvuruKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "EvdeSaglikBasvuruKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("basvurukaydi", (object)basvurukaydi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    SONUC_EVDESAGLIK_ISLEMLER cevap = default(SONUC_EVDESAGLIK_ISLEMLER);
                    cevap = (SONUC_EVDESAGLIK_ISLEMLER)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion EvdeSaglikBasvuruKaydetSync_Body

            }

            public static SONUC_EVDESAGLIK_ISLEMLER EvdeSaglikBasvuruSilSync(Guid siteID, USER user, int basvuruId, bool basvuruIdSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (SONUC_EVDESAGLIK_ISLEMLER) TTMessageFactory.SyncCall(siteID, new Guid("f49cff01-4dff-4f6e-9e7c-dcf99b3322cc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","EvdeSaglikBasvuruSilSync_ServerSide", user, basvuruId, basvuruIdSpecified);
            }


            private static SONUC_EVDESAGLIK_ISLEMLER EvdeSaglikBasvuruSilSync_ServerSide(USER user, int basvuruId, bool basvuruIdSpecified)
            {

#region EvdeSaglikBasvuruSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "EvdeSaglikBasvuruSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("basvuruId", (object)basvuruId),
                        Tuple.Create("basvuruIdSpecified", (object)basvuruIdSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    SONUC_EVDESAGLIK_ISLEMLER cevap = default(SONUC_EVDESAGLIK_ISLEMLER);
                    cevap = (SONUC_EVDESAGLIK_ISLEMLER)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion EvdeSaglikBasvuruSilSync_Body

            }

            public static SONUC_EVDESAGLIK_ISLEMLER EvdeSaglikBasvuruSorgulaSync(Guid siteID, USER user, int basvuruId, bool basvuruIdSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (SONUC_EVDESAGLIK_ISLEMLER) TTMessageFactory.SyncCall(siteID, new Guid("1095352b-99f0-4e2d-ba15-fbba388f4c35"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","EvdeSaglikBasvuruSorgulaSync_ServerSide", user, basvuruId, basvuruIdSpecified);
            }


            private static SONUC_EVDESAGLIK_ISLEMLER EvdeSaglikBasvuruSorgulaSync_ServerSide(USER user, int basvuruId, bool basvuruIdSpecified)
            {

#region EvdeSaglikBasvuruSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "EvdeSaglikBasvuruSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("basvuruId", (object)basvuruId),
                        Tuple.Create("basvuruIdSpecified", (object)basvuruIdSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    SONUC_EVDESAGLIK_ISLEMLER cevap = default(SONUC_EVDESAGLIK_ISLEMLER);
                    cevap = (SONUC_EVDESAGLIK_ISLEMLER)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion EvdeSaglikBasvuruSorgulaSync_Body

            }

            public static HIZMET_EMIRLERI EvdeSaglikHizmetEmirlerimSync(Guid siteID, USER user, System.DateTime emirSorgulamaBasTarihi, bool emirSorgulamaBasTarihiSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HIZMET_EMIRLERI) TTMessageFactory.SyncCall(siteID, new Guid("d538e170-db27-4435-b1d0-6fd1c48078eb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","EvdeSaglikHizmetEmirlerimSync_ServerSide", user, emirSorgulamaBasTarihi, emirSorgulamaBasTarihiSpecified);
            }


            private static HIZMET_EMIRLERI EvdeSaglikHizmetEmirlerimSync_ServerSide(USER user, System.DateTime emirSorgulamaBasTarihi, bool emirSorgulamaBasTarihiSpecified)
            {

#region EvdeSaglikHizmetEmirlerimSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "EvdeSaglikHizmetEmirlerim";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("emirSorgulamaBasTarihi", (object)emirSorgulamaBasTarihi),
                        Tuple.Create("emirSorgulamaBasTarihiSpecified", (object)emirSorgulamaBasTarihiSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    HIZMET_EMIRLERI cevap = default(HIZMET_EMIRLERI);
                    cevap = (HIZMET_EMIRLERI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion EvdeSaglikHizmetEmirlerimSync_Body

            }

            public static ISLEMSONUC HAC_UMRE_ADAYI_UPLOADSync(Guid siteID, USER Kullanici, string Donem, bool IS_Umre, bool IS_UmreSpecified, HACI_UMRE_ADAYI[] AdayListesi, int IsFirst, bool IsFirstSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ISLEMSONUC) TTMessageFactory.SyncCall(siteID, new Guid("cdc7b1fd-72e4-4af8-8653-54a0de1e4555"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","HAC_UMRE_ADAYI_UPLOADSync_ServerSide", Kullanici, Donem, IS_Umre, IS_UmreSpecified, AdayListesi, IsFirst, IsFirstSpecified);
            }


            private static ISLEMSONUC HAC_UMRE_ADAYI_UPLOADSync_ServerSide(USER Kullanici, string Donem, bool IS_Umre, bool IS_UmreSpecified, HACI_UMRE_ADAYI[] AdayListesi, int IsFirst, bool IsFirstSpecified)
            {

#region HAC_UMRE_ADAYI_UPLOADSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "HAC_UMRE_ADAYI_UPLOAD";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Kullanici", (object)Kullanici),
                        Tuple.Create("Donem", (object)Donem),
                        Tuple.Create("IS_Umre", (object)IS_Umre),
                        Tuple.Create("IS_UmreSpecified", (object)IS_UmreSpecified),
                        Tuple.Create("AdayListesi", (object)AdayListesi),
                        Tuple.Create("IsFirst", (object)IsFirst),
                        Tuple.Create("IsFirstSpecified", (object)IsFirstSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    ISLEMSONUC cevap = default(ISLEMSONUC);
                    cevap = (ISLEMSONUC)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HAC_UMRE_ADAYI_UPLOADSync_Body

            }

            public static KANSER_HEDEFLISTE Kanser_HedefListeGetirSync(Guid siteID, USER user, enKanserTaramaTuru kanserTuru, bool kanserTuruSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KANSER_HEDEFLISTE) TTMessageFactory.SyncCall(siteID, new Guid("d0b2941e-d379-4e23-bea4-0eb7ac5e1a27"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","Kanser_HedefListeGetirSync_ServerSide", user, kanserTuru, kanserTuruSpecified);
            }


            private static KANSER_HEDEFLISTE Kanser_HedefListeGetirSync_ServerSide(USER user, enKanserTaramaTuru kanserTuru, bool kanserTuruSpecified)
            {

#region Kanser_HedefListeGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "Kanser_HedefListeGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("kanserTuru", (object)kanserTuru),
                        Tuple.Create("kanserTuruSpecified", (object)kanserTuruSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    KANSER_HEDEFLISTE cevap = default(KANSER_HEDEFLISTE);
                    cevap = (KANSER_HEDEFLISTE)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion Kanser_HedefListeGetirSync_Body

            }

            public static KANSER_MAMOGRAFI_ISTEK_LISTESI Kanser_Mamografi_Isteklerini_GetirSync(Guid siteID, USER user, System.DateTime istekTarihi, bool istekTarihiSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KANSER_MAMOGRAFI_ISTEK_LISTESI) TTMessageFactory.SyncCall(siteID, new Guid("32003eda-8b12-4060-952a-e683d6df527e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","Kanser_Mamografi_Isteklerini_GetirSync_ServerSide", user, istekTarihi, istekTarihiSpecified);
            }


            private static KANSER_MAMOGRAFI_ISTEK_LISTESI Kanser_Mamografi_Isteklerini_GetirSync_ServerSide(USER user, System.DateTime istekTarihi, bool istekTarihiSpecified)
            {

#region Kanser_Mamografi_Isteklerini_GetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "Kanser_Mamografi_Isteklerini_Getir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("istekTarihi", (object)istekTarihi),
                        Tuple.Create("istekTarihiSpecified", (object)istekTarihiSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    KANSER_MAMOGRAFI_ISTEK_LISTESI cevap = default(KANSER_MAMOGRAFI_ISTEK_LISTESI);
                    cevap = (KANSER_MAMOGRAFI_ISTEK_LISTESI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion Kanser_Mamografi_Isteklerini_GetirSync_Body

            }

            public static ISLEMSONUC Kanser_Mamografi_Sonuc_KaydetSync(Guid siteID, USER user, KANSER_MAMOGRAFI_KAYIT_BILGILERI mamografiBilgileri)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ISLEMSONUC) TTMessageFactory.SyncCall(siteID, new Guid("0769cb8f-781b-4646-9064-3e81c06491eb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","Kanser_Mamografi_Sonuc_KaydetSync_ServerSide", user, mamografiBilgileri);
            }


            private static ISLEMSONUC Kanser_Mamografi_Sonuc_KaydetSync_ServerSide(USER user, KANSER_MAMOGRAFI_KAYIT_BILGILERI mamografiBilgileri)
            {

#region Kanser_Mamografi_Sonuc_KaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "Kanser_Mamografi_Sonuc_Kaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("mamografiBilgileri", (object)mamografiBilgileri),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    ISLEMSONUC cevap = default(ISLEMSONUC);
                    cevap = (ISLEMSONUC)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion Kanser_Mamografi_Sonuc_KaydetSync_Body

            }

            public static MISAFIR_ANNE_SUREC_BILGISI MISAFIR_ANNE_SUREC_SORGULASync(Guid siteID, USER user, string talepId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (MISAFIR_ANNE_SUREC_BILGISI) TTMessageFactory.SyncCall(siteID, new Guid("c6ed93d9-593a-4ed7-b3e8-cab21e449524"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","MISAFIR_ANNE_SUREC_SORGULASync_ServerSide", user, talepId);
            }


            private static MISAFIR_ANNE_SUREC_BILGISI MISAFIR_ANNE_SUREC_SORGULASync_ServerSide(USER user, string talepId)
            {

#region MISAFIR_ANNE_SUREC_SORGULASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "MISAFIR_ANNE_SUREC_SORGULA";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("talepId", (object)talepId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    MISAFIR_ANNE_SUREC_BILGISI cevap = default(MISAFIR_ANNE_SUREC_BILGISI);
                    cevap = (MISAFIR_ANNE_SUREC_BILGISI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MISAFIR_ANNE_SUREC_SORGULASync_Body

            }

            public static ISLEMSONUC MISAFIR_ANNE_TALEP_SILSync(Guid siteID, USER user, string talepId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ISLEMSONUC) TTMessageFactory.SyncCall(siteID, new Guid("20da6505-2310-48d8-b740-d04ffc185d85"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","MISAFIR_ANNE_TALEP_SILSync_ServerSide", user, talepId);
            }


            private static ISLEMSONUC MISAFIR_ANNE_TALEP_SILSync_ServerSide(USER user, string talepId)
            {

#region MISAFIR_ANNE_TALEP_SILSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "MISAFIR_ANNE_TALEP_SIL";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("talepId", (object)talepId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    ISLEMSONUC cevap = default(ISLEMSONUC);
                    cevap = (ISLEMSONUC)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MISAFIR_ANNE_TALEP_SILSync_Body

            }

            public static SONUC_MISAFIRANNE_TALEPKAYDET MISAFIRANNE_TALEPKAYDETSync(Guid siteID, USER user, MISAFIRANNE_TALEP_BILGISI TalepBilgisi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (SONUC_MISAFIRANNE_TALEPKAYDET) TTMessageFactory.SyncCall(siteID, new Guid("231eb5e1-ec32-4221-a593-1790964467a7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","MISAFIRANNE_TALEPKAYDETSync_ServerSide", user, TalepBilgisi);
            }


            private static SONUC_MISAFIRANNE_TALEPKAYDET MISAFIRANNE_TALEPKAYDETSync_ServerSide(USER user, MISAFIRANNE_TALEP_BILGISI TalepBilgisi)
            {

#region MISAFIRANNE_TALEPKAYDETSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "MISAFIRANNE_TALEPKAYDET";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("TalepBilgisi", (object)TalepBilgisi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    SONUC_MISAFIRANNE_TALEPKAYDET cevap = default(SONUC_MISAFIRANNE_TALEPKAYDET);
                    cevap = (SONUC_MISAFIRANNE_TALEPKAYDET)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MISAFIRANNE_TALEPKAYDETSync_Body

            }

            public static OLASI_MISAFIR_ANNE_LISTESI OLASI_MISAFIR_ANNELERI_GETIRSync(Guid siteID, USER user)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (OLASI_MISAFIR_ANNE_LISTESI) TTMessageFactory.SyncCall(siteID, new Guid("f7491a9c-d658-4fdd-9aaa-1a84b810f82b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","OLASI_MISAFIR_ANNELERI_GETIRSync_ServerSide", user);
            }


            private static OLASI_MISAFIR_ANNE_LISTESI OLASI_MISAFIR_ANNELERI_GETIRSync_ServerSide(USER user)
            {

#region OLASI_MISAFIR_ANNELERI_GETIRSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "OLASI_MISAFIR_ANNELERI_GETIR";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    OLASI_MISAFIR_ANNE_LISTESI cevap = default(OLASI_MISAFIR_ANNE_LISTESI);
                    cevap = (OLASI_MISAFIR_ANNE_LISTESI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OLASI_MISAFIR_ANNELERI_GETIRSync_Body

            }

            public static Riskli_Gebe_Surec_Durum Riskli_Gebe_Surec_BilgisiSync(Guid siteID, USER user, long Hasta_tc, bool Hasta_tcSpecified, System.DateTime sonadet_tarihi, bool sonadet_tarihiSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Riskli_Gebe_Surec_Durum) TTMessageFactory.SyncCall(siteID, new Guid("a8d53d05-6278-4536-9a77-b822b6e14d46"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","Riskli_Gebe_Surec_BilgisiSync_ServerSide", user, Hasta_tc, Hasta_tcSpecified, sonadet_tarihi, sonadet_tarihiSpecified);
            }


            private static Riskli_Gebe_Surec_Durum Riskli_Gebe_Surec_BilgisiSync_ServerSide(USER user, long Hasta_tc, bool Hasta_tcSpecified, System.DateTime sonadet_tarihi, bool sonadet_tarihiSpecified)
            {

#region Riskli_Gebe_Surec_BilgisiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "Riskli_Gebe_Surec_Bilgisi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("Hasta_tc", (object)Hasta_tc),
                        Tuple.Create("Hasta_tcSpecified", (object)Hasta_tcSpecified),
                        Tuple.Create("sonadet_tarihi", (object)sonadet_tarihi),
                        Tuple.Create("sonadet_tarihiSpecified", (object)sonadet_tarihiSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    Riskli_Gebe_Surec_Durum cevap = default(Riskli_Gebe_Surec_Durum);
                    cevap = (Riskli_Gebe_Surec_Durum)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion Riskli_Gebe_Surec_BilgisiSync_Body

            }

            public static ISLEMSONUC STOK_CIKIS_KAYDETSync(Guid siteID, USER user, enStokCikisYapanKurumTur KurumTuru, bool KurumTuruSpecified, STOK_BILGISI StokBilgisi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ISLEMSONUC) TTMessageFactory.SyncCall(siteID, new Guid("a3d96812-d710-4c19-882c-cda3878af2ce"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","STOK_CIKIS_KAYDETSync_ServerSide", user, KurumTuru, KurumTuruSpecified, StokBilgisi);
            }


            private static ISLEMSONUC STOK_CIKIS_KAYDETSync_ServerSide(USER user, enStokCikisYapanKurumTur KurumTuru, bool KurumTuruSpecified, STOK_BILGISI StokBilgisi)
            {

#region STOK_CIKIS_KAYDETSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "STOK_CIKIS_KAYDET";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("KurumTuru", (object)KurumTuru),
                        Tuple.Create("KurumTuruSpecified", (object)KurumTuruSpecified),
                        Tuple.Create("StokBilgisi", (object)StokBilgisi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    ISLEMSONUC cevap = default(ISLEMSONUC);
                    cevap = (ISLEMSONUC)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion STOK_CIKIS_KAYDETSync_Body

            }

            public static STOK_CIKIS_LISTESI STOK_CIKIS_LISTELESync(Guid siteID, USER user, enStokCikisYapanKurumTur KurumTuru, bool KurumTuruSpecified, System.DateTime Tarih, bool TarihSpecified, int AsmKodu, bool AsmKoduSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (STOK_CIKIS_LISTESI) TTMessageFactory.SyncCall(siteID, new Guid("63da2db8-cdc3-471b-9d73-8f13534cf0d4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","STOK_CIKIS_LISTELESync_ServerSide", user, KurumTuru, KurumTuruSpecified, Tarih, TarihSpecified, AsmKodu, AsmKoduSpecified);
            }


            private static STOK_CIKIS_LISTESI STOK_CIKIS_LISTELESync_ServerSide(USER user, enStokCikisYapanKurumTur KurumTuru, bool KurumTuruSpecified, System.DateTime Tarih, bool TarihSpecified, int AsmKodu, bool AsmKoduSpecified)
            {

#region STOK_CIKIS_LISTELESync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "STOK_CIKIS_LISTELE";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("KurumTuru", (object)KurumTuru),
                        Tuple.Create("KurumTuruSpecified", (object)KurumTuruSpecified),
                        Tuple.Create("Tarih", (object)Tarih),
                        Tuple.Create("TarihSpecified", (object)TarihSpecified),
                        Tuple.Create("AsmKodu", (object)AsmKodu),
                        Tuple.Create("AsmKoduSpecified", (object)AsmKoduSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    STOK_CIKIS_LISTESI cevap = default(STOK_CIKIS_LISTESI);
                    cevap = (STOK_CIKIS_LISTESI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion STOK_CIKIS_LISTELESync_Body

            }

            public static ISLEMSONUC STOK_CIKIS_SILSync(Guid siteID, USER user, enStokCikisYapanKurumTur KurumTuru, bool KurumTuruSpecified, STOK_BILGISI StokBilgisi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ISLEMSONUC) TTMessageFactory.SyncCall(siteID, new Guid("9fd20729-9965-4d1e-936a-811bc2baba35"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","STOK_CIKIS_SILSync_ServerSide", user, KurumTuru, KurumTuruSpecified, StokBilgisi);
            }


            private static ISLEMSONUC STOK_CIKIS_SILSync_ServerSide(USER user, enStokCikisYapanKurumTur KurumTuru, bool KurumTuruSpecified, STOK_BILGISI StokBilgisi)
            {

#region STOK_CIKIS_SILSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "STOK_CIKIS_SIL";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                        Tuple.Create("KurumTuru", (object)KurumTuru),
                        Tuple.Create("KurumTuruSpecified", (object)KurumTuruSpecified),
                        Tuple.Create("StokBilgisi", (object)StokBilgisi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    ISLEMSONUC cevap = default(ISLEMSONUC);
                    cevap = (ISLEMSONUC)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion STOK_CIKIS_SILSync_Body

            }

            public static STOK_GRUP_LISTESI STOK_GRUPLARI_GETIRSync(Guid siteID, USER user)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (STOK_GRUP_LISTESI) TTMessageFactory.SyncCall(siteID, new Guid("477afd47-9bad-4144-8fb1-0d13998e5464"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","STOK_GRUPLARI_GETIRSync_ServerSide", user);
            }


            private static STOK_GRUP_LISTESI STOK_GRUPLARI_GETIRSync_ServerSide(USER user)
            {

#region STOK_GRUPLARI_GETIRSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "STOK_GRUPLARI_GETIR";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    STOK_GRUP_LISTESI cevap = default(STOK_GRUP_LISTESI);
                    cevap = (STOK_GRUP_LISTESI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion STOK_GRUPLARI_GETIRSync_Body

            }

            public static STOK_KART_LISTESI STOK_KARTLARI_GETIRSync(Guid siteID, USER user)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (STOK_KART_LISTESI) TTMessageFactory.SyncCall(siteID, new Guid("81256618-71fb-4c53-a193-dc5c6bc73129"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","STOK_KARTLARI_GETIRSync_ServerSide", user);
            }


            private static STOK_KART_LISTESI STOK_KARTLARI_GETIRSync_ServerSide(USER user)
            {

#region STOK_KARTLARI_GETIRSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "STOK_KARTLARI_GETIR";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    STOK_KART_LISTESI cevap = default(STOK_KART_LISTESI);
                    cevap = (STOK_KART_LISTESI)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion STOK_KARTLARI_GETIRSync_Body

            }

            public static string Test_If_ALiveSync(Guid siteID, int value, bool valueSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("1a027f05-dbb6-413d-8fce-95712172f52c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","Test_If_ALiveSync_ServerSide", value, valueSpecified);
            }


            private static string Test_If_ALiveSync_ServerSide(int value, bool valueSpecified)
            {

#region Test_If_ALiveSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "Test_If_ALive";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("value", (object)value),
                        Tuple.Create("valueSpecified", (object)valueSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion Test_If_ALiveSync_Body

            }

            public static ISLEMSONUC UserKontrolSync(Guid siteID, USER user)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ISLEMSONUC) TTMessageFactory.SyncCall(siteID, new Guid("c69c27bf-b487-4833-851d-9e8d4188d4b5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HSBSServis+WebMethods, TTObjectClasses","UserKontrolSync_ServerSide", user);
            }


            private static ISLEMSONUC UserKontrolSync_ServerSide(USER user)
            {

#region UserKontrolSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HSBSServis";
                    header.ServiceId = "2ec6017c-4f5b-4ef8-832e-ff8d47b66c24";
                    header.MethodName = "UserKontrol";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("user", (object)user),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    ISLEMSONUC cevap = default(ISLEMSONUC);
                    cevap = (ISLEMSONUC)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion UserKontrolSync_Body

            }

        }
                    
        protected HSBSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HSBSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HSBSServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HSBSServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HSBSServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HSBSSERVIS", dataRow) { }
        protected HSBSServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HSBSSERVIS", dataRow, isImported) { }
        public HSBSServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HSBSServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HSBSServis() : base() { }

    }
}