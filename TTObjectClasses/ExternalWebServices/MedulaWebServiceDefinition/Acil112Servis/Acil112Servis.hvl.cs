
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Acil112Servis")] 

    public  partial class Acil112Servis : TTObject
    {
        public class Acil112ServisList : TTObjectCollection<Acil112Servis> { }
                    
        public class ChildAcil112ServisCollection : TTObject.TTChildObjectCollection<Acil112Servis>
        {
            public ChildAcil112ServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAcil112ServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static int AdetleriGonder_ArraySync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, BolumBilgisi[] bolumler, string ipAddr)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("15568831-f884-4d51-853b-7ccf84c769b3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","AdetleriGonder_ArraySync_ServerSide", webServisUri, userName1, userPassword1, bolumler, ipAddr);
            }


            private static int AdetleriGonder_ArraySync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, BolumBilgisi[] bolumler, string ipAddr)
            {

#region AdetleriGonder_ArraySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "AdetleriGonder_Array";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("bolumler", (object)bolumler),
                        Tuple.Create("ipAddr", (object)ipAddr),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion AdetleriGonder_ArraySync_Body

            }

            public static int AdetleriGonderSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, BolumBilgileri acilEriskin, BolumBilgileri acilCocuk, BolumBilgileri ybKoroner, BolumBilgileri ybKalpDamar, BolumBilgileri ybAnestezi, BolumBilgileri ybNoroloji, BolumBilgileri ybBeyinCerrahi, BolumBilgileri ybGenelCerrahi, BolumBilgileri ybDahiliye, BolumBilgileri ybGogusHastaliklari, BolumBilgileri ybKadinDogum, BolumBilgileri ybPediatri, BolumBilgileri ybYenidogan, BolumBilgileri ybYanik, BolumBilgileri srvPediatri, BolumBilgileri srvDahiliye, BolumBilgileri srvKalpDamar, BolumBilgileri srvKadinDogum, BolumBilgileri srvGenelCerrahi, BolumBilgileri srvOrtopedi, BolumBilgileri srvKalpDamarCerrahi, BolumBilgileri srvBeyinCerrahi, BolumBilgileri srvYenidogan, BolumBilgileri srvDializ, BolumBilgileri srvDiger, BolumBilgileri ameliyathane, BolumBilgileri morg, string ipAddr)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("1012c6ac-54a3-4404-8cdb-3c21a0ad7268"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","AdetleriGonderSync_ServerSide", webServisUri, acilEriskin, acilCocuk, ybKoroner, ybKalpDamar, ybAnestezi, ybNoroloji, ybBeyinCerrahi, ybGenelCerrahi, ybDahiliye, ybGogusHastaliklari, ybKadinDogum, ybPediatri, ybYenidogan, ybYanik, srvPediatri, srvDahiliye, srvKalpDamar, srvKadinDogum, srvGenelCerrahi, srvOrtopedi, srvKalpDamarCerrahi, srvBeyinCerrahi, srvYenidogan, srvDializ, srvDiger, ameliyathane, morg, ipAddr);
            }


            private static int AdetleriGonderSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, BolumBilgileri acilEriskin, BolumBilgileri acilCocuk, BolumBilgileri ybKoroner, BolumBilgileri ybKalpDamar, BolumBilgileri ybAnestezi, BolumBilgileri ybNoroloji, BolumBilgileri ybBeyinCerrahi, BolumBilgileri ybGenelCerrahi, BolumBilgileri ybDahiliye, BolumBilgileri ybGogusHastaliklari, BolumBilgileri ybKadinDogum, BolumBilgileri ybPediatri, BolumBilgileri ybYenidogan, BolumBilgileri ybYanik, BolumBilgileri srvPediatri, BolumBilgileri srvDahiliye, BolumBilgileri srvKalpDamar, BolumBilgileri srvKadinDogum, BolumBilgileri srvGenelCerrahi, BolumBilgileri srvOrtopedi, BolumBilgileri srvKalpDamarCerrahi, BolumBilgileri srvBeyinCerrahi, BolumBilgileri srvYenidogan, BolumBilgileri srvDializ, BolumBilgileri srvDiger, BolumBilgileri ameliyathane, BolumBilgileri morg, string ipAddr)
            {

#region AdetleriGonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "AdetleriGonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("acilEriskin", (object)acilEriskin),
                        Tuple.Create("acilCocuk", (object)acilCocuk),
                        Tuple.Create("ybKoroner", (object)ybKoroner),
                        Tuple.Create("ybKalpDamar", (object)ybKalpDamar),
                        Tuple.Create("ybAnestezi", (object)ybAnestezi),
                        Tuple.Create("ybNoroloji", (object)ybNoroloji),
                        Tuple.Create("ybBeyinCerrahi", (object)ybBeyinCerrahi),
                        Tuple.Create("ybGenelCerrahi", (object)ybGenelCerrahi),
                        Tuple.Create("ybDahiliye", (object)ybDahiliye),
                        Tuple.Create("ybGogusHastaliklari", (object)ybGogusHastaliklari),
                        Tuple.Create("ybKadinDogum", (object)ybKadinDogum),
                        Tuple.Create("ybPediatri", (object)ybPediatri),
                        Tuple.Create("ybYenidogan", (object)ybYenidogan),
                        Tuple.Create("ybYanik", (object)ybYanik),
                        Tuple.Create("srvPediatri", (object)srvPediatri),
                        Tuple.Create("srvDahiliye", (object)srvDahiliye),
                        Tuple.Create("srvKalpDamar", (object)srvKalpDamar),
                        Tuple.Create("srvKadinDogum", (object)srvKadinDogum),
                        Tuple.Create("srvGenelCerrahi", (object)srvGenelCerrahi),
                        Tuple.Create("srvOrtopedi", (object)srvOrtopedi),
                        Tuple.Create("srvKalpDamarCerrahi", (object)srvKalpDamarCerrahi),
                        Tuple.Create("srvBeyinCerrahi", (object)srvBeyinCerrahi),
                        Tuple.Create("srvYenidogan", (object)srvYenidogan),
                        Tuple.Create("srvDializ", (object)srvDializ),
                        Tuple.Create("srvDiger", (object)srvDiger),
                        Tuple.Create("ameliyathane", (object)ameliyathane),
                        Tuple.Create("morg", (object)morg),
                        Tuple.Create("ipAddr", (object)ipAddr),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion AdetleriGonderSync_Body

            }

            public static TTMessage EUYSTaniGonderASync(Guid siteID, IWebMethodCallback callerObject, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, HastaBilgileri hasta, string ICD10Kodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","EUYSTaniGonderASync_ServerSide", new Guid("bcd82089-277a-4a05-a6fc-453d51419654"), callerObject, webServisUri, userName1, userPassword1, hasta, ICD10Kodu);
            }

            private static int? EUYSTaniGonderASync_ServerSide(IWebMethodCallback callerObject, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, HastaBilgileri hasta, string ICD10Kodu)
            {

#region EUYSTaniGonderASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "EUYSTaniGonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("hasta", (object)hasta),
                        Tuple.Create("ICD10Kodu", (object)ICD10Kodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");


                    int? cevap = default(int?);
                    
                    try
                    {
                        cevap = (int?)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { webServisUri, userName1, userPassword1, hasta, ICD10Kodu }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { webServisUri, userName1, userPassword1, hasta, ICD10Kodu }, null);

                    return cevap;
                

#endregion EUYSTaniGonderASync_Body

            }

            public static int EUYSTaniGonderSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, HastaBilgileri hasta, string ICD10Kodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("99b9fd3e-09fd-4b81-982d-26f5f1f05add"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","EUYSTaniGonderSync_ServerSide", webServisUri, userName1, userPassword1, hasta, ICD10Kodu);
            }


            private static int EUYSTaniGonderSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, HastaBilgileri hasta, string ICD10Kodu)
            {

#region EUYSTaniGonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "EUYSTaniGonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("hasta", (object)hasta),
                        Tuple.Create("ICD10Kodu", (object)ICD10Kodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion EUYSTaniGonderSync_Body

            }

            public static string GetVersionNoSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("9fabc9b1-3955-4afc-9ed8-d82bb242fc6b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","GetVersionNoSync_ServerSide", webServisUri);
            }


            private static string GetVersionNoSync_ServerSide(TTUtils.TTWebServiceUri webServisUri)
            {

#region GetVersionNoSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "GetVersionNo";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetVersionNoSync_Body

            }

            public static int XXXXXXPersoneliniDonderSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, PersonelBilgileri[] personelListesi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("d52ee4f6-7f13-4536-a10c-1b2740fccef7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","XXXXXXPersoneliniDonderSync_ServerSide", webServisUri, userName1, userPassword1, personelListesi);
            }


            private static int XXXXXXPersoneliniDonderSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, PersonelBilgileri[] personelListesi)
            {

#region XXXXXXPersoneliniDonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "XXXXXXPersoneliniDonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("personelListesi", (object)personelListesi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXPersoneliniDonderSync_Body

            }

            public static int KayitNoProtokolNoDonusumSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string kayitNo, string protokolNo, string sorguYili)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("4d22182d-5659-4f02-a766-741af9d69b98"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","KayitNoProtokolNoDonusumSync_ServerSide", webServisUri, kayitNo, protokolNo, sorguYili);
            }


            private static int KayitNoProtokolNoDonusumSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string kayitNo, string protokolNo, string sorguYili)
            {

#region KayitNoProtokolNoDonusumSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "KayitNoProtokolNoDonusum";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("kayitNo", (object)kayitNo),
                        Tuple.Create("protokolNo", (object)protokolNo),
                        Tuple.Create("sorguYili", (object)sorguYili),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KayitNoProtokolNoDonusumSync_Body

            }

            public static int NobetciPersonelGonder_ArraySync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, PersonelBilgileri[] personelListesi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("f098d263-2366-477b-a3a4-a46a3335e6bb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","NobetciPersonelGonder_ArraySync_ServerSide", webServisUri, userName1, userPassword1, personelListesi);
            }


            private static int NobetciPersonelGonder_ArraySync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, PersonelBilgileri[] personelListesi)
            {

#region NobetciPersonelGonder_ArraySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "NobetciPersonelGonder_Array";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("personelListesi", (object)personelListesi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion NobetciPersonelGonder_ArraySync_Body

            }

            public static int NobetciPersonelGondermeMetodu_ArraySync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, NobetciPersonelBilgileri[] nobetciler)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("1e86b267-d323-4d74-a0cc-10e9bc4b250a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","NobetciPersonelGondermeMetodu_ArraySync_ServerSide", webServisUri, userName1, userPassword1, nobetciler);
            }


            private static int NobetciPersonelGondermeMetodu_ArraySync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, NobetciPersonelBilgileri[] nobetciler)
            {

#region NobetciPersonelGondermeMetodu_ArraySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "NobetciPersonelGondermeMetodu_Array";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("nobetciler", (object)nobetciler),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion NobetciPersonelGondermeMetodu_ArraySync_Body

            }

            public static int NobetciPersonelGondermeMetoduSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, NobetciPersonelBilgileri nobetci)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("386f916a-5077-4e34-86f9-17ceb787c089"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","NobetciPersonelGondermeMetoduSync_ServerSide", webServisUri, nobetci);
            }


            private static int NobetciPersonelGondermeMetoduSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, NobetciPersonelBilgileri nobetci)
            {

#region NobetciPersonelGondermeMetoduSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "NobetciPersonelGondermeMetodu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("nobetci", (object)nobetci),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion NobetciPersonelGondermeMetoduSync_Body

            }

            public static int NobetciPersonelGonderSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, System.Data.DataSet personelListesi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("f7fbe72a-053f-4fd1-be19-098eb776e465"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","NobetciPersonelGonderSync_ServerSide", webServisUri, personelListesi);
            }


            private static int NobetciPersonelGonderSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, System.Data.DataSet personelListesi)
            {

#region NobetciPersonelGonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "NobetciPersonelGonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("personelListesi", (object)personelListesi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion NobetciPersonelGonderSync_Body

            }

            public static int ProtokolDetaylariDonderSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string protokolNo, string sene, string hastaAdiSoyadi, string TCKimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("3a297154-4cdf-4457-840c-dc186ec9478a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","ProtokolDetaylariDonderSync_ServerSide", webServisUri, protokolNo, sene, hastaAdiSoyadi, TCKimlikNo);
            }


            private static int ProtokolDetaylariDonderSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string protokolNo, string sene, string hastaAdiSoyadi, string TCKimlikNo)
            {

#region ProtokolDetaylariDonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "ProtokolDetaylariDonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("protokolNo", (object)protokolNo),
                        Tuple.Create("sene", (object)sene),
                        Tuple.Create("hastaAdiSoyadi", (object)hastaAdiSoyadi),
                        Tuple.Create("TCKimlikNo", (object)TCKimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ProtokolDetaylariDonderSync_Body

            }

            public static string ServiceTestSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("7c1127b7-c72d-46ad-b9d3-4bc9a8f5e508"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","ServiceTestSync_ServerSide", webServisUri);
            }


            private static string ServiceTestSync_ServerSide(TTUtils.TTWebServiceUri webServisUri)
            {

#region ServiceTestSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "ServiceTest";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ServiceTestSync_Body

            }

            public static int SonlandirilmamisVakalarListesiDetayliSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, VakaBilgileri[] acikVakalar)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("8a8e32a0-355f-4e51-bee0-54ad20e9e57a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","SonlandirilmamisVakalarListesiDetayliSync_ServerSide", webServisUri, acikVakalar);
            }


            private static int SonlandirilmamisVakalarListesiDetayliSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, VakaBilgileri[] acikVakalar)
            {

#region SonlandirilmamisVakalarListesiDetayliSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "SonlandirilmamisVakalarListesiDetayli";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("acikVakalar", (object)acikVakalar),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SonlandirilmamisVakalarListesiDetayliSync_Body

            }

            public static int SonlandirilmamisVakalarListesiSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, int[] protokoller)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("b59495f5-4fc6-4ef3-8c80-fee5bf24093d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","SonlandirilmamisVakalarListesiSync_ServerSide", webServisUri, protokoller);
            }


            private static int SonlandirilmamisVakalarListesiSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, int[] protokoller)
            {

#region SonlandirilmamisVakalarListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "SonlandirilmamisVakalarListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("protokoller", (object)protokoller),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SonlandirilmamisVakalarListesiSync_Body

            }

            public static int SosyalGuvenceKodlariDonderSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string[] kurumKodlari)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("f2889fe9-956a-45c6-a0f6-ca359cb1fecd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","SosyalGuvenceKodlariDonderSync_ServerSide", webServisUri, kurumKodlari);
            }


            private static int SosyalGuvenceKodlariDonderSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string[] kurumKodlari)
            {

#region SosyalGuvenceKodlariDonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "SosyalGuvenceKodlariDonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("kurumKodlari", (object)kurumKodlari),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SosyalGuvenceKodlariDonderSync_Body

            }

            public static int VakaGuncellemeMetoduSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, string protokolNo, string tarih, string XXXXXXKabulTarihi, string aciklama, string ip)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("8830d5ab-19d6-44ee-96d7-3c56045b3dbc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","VakaGuncellemeMetoduSync_ServerSide", webServisUri, userName1, userPassword1, protokolNo, tarih, XXXXXXKabulTarihi, aciklama, ip);
            }


            private static int VakaGuncellemeMetoduSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, string protokolNo, string tarih, string XXXXXXKabulTarihi, string aciklama, string ip)
            {

#region VakaGuncellemeMetoduSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "VakaGuncellemeMetodu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("protokolNo", (object)protokolNo),
                        Tuple.Create("tarih", (object)tarih),
                        Tuple.Create("XXXXXXKabulTarihi", (object)XXXXXXKabulTarihi),
                        Tuple.Create("aciklama", (object)aciklama),
                        Tuple.Create("ip", (object)ip),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion VakaGuncellemeMetoduSync_Body

            }

            public static TTMessage VakaSonlandirmaMetoduASync(Guid siteID, IWebMethodCallback callerObject, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, string protokolNo, string tarih, string hastaKabulTarihi, string hastaAyrilisTarihi, string vakaSonuc, string aciklama, string XXXXXXSonucTanisi, string sosyalGuvenlikKurumu, string sosyalGuvenlikNo, string tcKimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","VakaSonlandirmaMetoduASync_ServerSide", new Guid("a6e5f0f6-67f6-40fb-8bb4-e0cc44260d4c"), callerObject, webServisUri, userName1, userPassword1, protokolNo, tarih, hastaKabulTarihi, hastaAyrilisTarihi, vakaSonuc, aciklama, XXXXXXSonucTanisi, sosyalGuvenlikKurumu, sosyalGuvenlikNo, tcKimlikNo);
            }

            private static int? VakaSonlandirmaMetoduASync_ServerSide(IWebMethodCallback callerObject, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, string protokolNo, string tarih, string hastaKabulTarihi, string hastaAyrilisTarihi, string vakaSonuc, string aciklama, string XXXXXXSonucTanisi, string sosyalGuvenlikKurumu, string sosyalGuvenlikNo, string tcKimlikNo)
            {

#region VakaSonlandirmaMetoduASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "VakaSonlandirmaMetodu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("protokolNo", (object)protokolNo),
                        Tuple.Create("tarih", (object)tarih),
                        Tuple.Create("hastaKabulTarihi", (object)hastaKabulTarihi),
                        Tuple.Create("hastaAyrilisTarihi", (object)hastaAyrilisTarihi),
                        Tuple.Create("vakaSonuc", (object)vakaSonuc),
                        Tuple.Create("aciklama", (object)aciklama),
                        Tuple.Create("XXXXXXSonucTanisi", (object)XXXXXXSonucTanisi),
                        Tuple.Create("sosyalGuvenlikKurumu", (object)sosyalGuvenlikKurumu),
                        Tuple.Create("sosyalGuvenlikNo", (object)sosyalGuvenlikNo),
                        Tuple.Create("tcKimlikNo", (object)tcKimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");


                    int? cevap = default(int?);
                    
                    try
                    {
                        cevap = (int?)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { webServisUri, userName1, userPassword1, protokolNo, tarih, hastaKabulTarihi, hastaAyrilisTarihi, vakaSonuc, aciklama, XXXXXXSonucTanisi, sosyalGuvenlikKurumu, sosyalGuvenlikNo, tcKimlikNo }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { webServisUri, userName1, userPassword1, protokolNo, tarih, hastaKabulTarihi, hastaAyrilisTarihi, vakaSonuc, aciklama, XXXXXXSonucTanisi, sosyalGuvenlikKurumu, sosyalGuvenlikNo, tcKimlikNo }, null);

                    return cevap;
                

#endregion VakaSonlandirmaMetoduASync_Body

            }

            public static int VakaSonlandirmaMetoduSync(Guid siteID, TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, string protokolNo, string tarih, string hastaKabulTarihi, string hastaAyrilisTarihi, string vakaSonuc, string aciklama, string XXXXXXSonucTanisi, string sosyalGuvenlikKurumu, string sosyalGuvenlikNo, string tcKimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("7d56c6dc-c6a3-4f2e-b147-9a33c7ad682a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.Acil112Servis+WebMethods, TTObjectClasses","VakaSonlandirmaMetoduSync_ServerSide", webServisUri, userName1, userPassword1, protokolNo, tarih, hastaKabulTarihi, hastaAyrilisTarihi, vakaSonuc, aciklama, XXXXXXSonucTanisi, sosyalGuvenlikKurumu, sosyalGuvenlikNo, tcKimlikNo);
            }


            private static int VakaSonlandirmaMetoduSync_ServerSide(TTUtils.TTWebServiceUri webServisUri, string userName1, string userPassword1, string protokolNo, string tarih, string hastaKabulTarihi, string hastaAyrilisTarihi, string vakaSonuc, string aciklama, string XXXXXXSonucTanisi, string sosyalGuvenlikKurumu, string sosyalGuvenlikNo, string tcKimlikNo)
            {

#region VakaSonlandirmaMetoduSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.Acil112Servis";
                    header.ServiceId = "1faff00c-49f2-4caf-b113-4ab9c0fd54a3";
                    header.MethodName = "VakaSonlandirmaMetodu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("webServisUri", (object)webServisUri),
                        Tuple.Create("userName1", (object)userName1),
                        Tuple.Create("userPassword1", (object)userPassword1),
                        Tuple.Create("protokolNo", (object)protokolNo),
                        Tuple.Create("tarih", (object)tarih),
                        Tuple.Create("hastaKabulTarihi", (object)hastaKabulTarihi),
                        Tuple.Create("hastaAyrilisTarihi", (object)hastaAyrilisTarihi),
                        Tuple.Create("vakaSonuc", (object)vakaSonuc),
                        Tuple.Create("aciklama", (object)aciklama),
                        Tuple.Create("XXXXXXSonucTanisi", (object)XXXXXXSonucTanisi),
                        Tuple.Create("sosyalGuvenlikKurumu", (object)sosyalGuvenlikKurumu),
                        Tuple.Create("sosyalGuvenlikNo", (object)sosyalGuvenlikNo),
                        Tuple.Create("tcKimlikNo", (object)tcKimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion VakaSonlandirmaMetoduSync_Body

            }

        }
                    
        protected Acil112Servis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Acil112Servis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Acil112Servis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Acil112Servis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Acil112Servis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACIL112SERVIS", dataRow) { }
        protected Acil112Servis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACIL112SERVIS", dataRow, isImported) { }
        public Acil112Servis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Acil112Servis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Acil112Servis() : base() { }

    }
}