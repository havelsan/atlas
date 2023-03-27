
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OptikRaporIslemleri")] 

    public  partial class OptikRaporIslemleri : TTObject
    {
        public class OptikRaporIslemleriList : TTObjectCollection<OptikRaporIslemleri> { }
                    
        public class ChildOptikRaporIslemleriCollection : TTObject.TTChildObjectCollection<OptikRaporIslemleri>
        {
            public ChildOptikRaporIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOptikRaporIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static eraporAciklamaEkleCevapDVO eraporAciklamaEkle(Guid siteID, string userName, string password, eraporAciklamaEkleIstekDVO eraporAciklamaEkleIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("96229098-ba75-49d4-85d6-58bf4d4f0312"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporAciklamaEkle_ServerSide", userName, password, eraporAciklamaEkleIstek);
            }


            private static eraporAciklamaEkleCevapDVO eraporAciklamaEkle_ServerSide(string userName, string password, eraporAciklamaEkleIstekDVO eraporAciklamaEkleIstek)
            {

#region eraporAciklamaEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporAciklamaEkleIstek", (object)eraporAciklamaEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporAciklamaEkleCevapDVO cevap = default(eraporAciklamaEkleCevapDVO);
                    cevap = (eraporAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporAciklamaEkle_Body

            }

            public static eraporBashekimOnayCevapDVO eraporBashekimOnay(Guid siteID, string userName, string password, eraporBashekimOnayIstekDVO eraporBashekimOnayIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1ea30eba-b144-4eea-a676-b1aaecbb7489"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporBashekimOnay_ServerSide", userName, password, eraporBashekimOnayIstek);
            }


            private static eraporBashekimOnayCevapDVO eraporBashekimOnay_ServerSide(string userName, string password, eraporBashekimOnayIstekDVO eraporBashekimOnayIstek)
            {

#region eraporBashekimOnay_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporBashekimOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporBashekimOnayIstek", (object)eraporBashekimOnayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporBashekimOnayCevapDVO cevap = default(eraporBashekimOnayCevapDVO);
                    cevap = (eraporBashekimOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnay_Body

            }

            public static eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorgu(Guid siteID, string userName, string password, eraporBashekimOnayBekleyenListeSorguIstekDVO eraporBashekimOnayBekleyenListeSorguIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("5e2f4db1-9b4b-4031-b9a0-b34181e34828"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporBashekimOnayBekleyenListeSorgu_ServerSide", userName, password, eraporBashekimOnayBekleyenListeSorguIstek);
            }


            private static eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorgu_ServerSide(string userName, string password, eraporBashekimOnayBekleyenListeSorguIstekDVO eraporBashekimOnayBekleyenListeSorguIstek)
            {

#region eraporBashekimOnayBekleyenListeSorgu_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporBashekimOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporBashekimOnayBekleyenListeSorguIstek", (object)eraporBashekimOnayBekleyenListeSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporBashekimOnayBekleyenListeSorguCevapDVO cevap = default(eraporBashekimOnayBekleyenListeSorguCevapDVO);
                    cevap = (eraporBashekimOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnayBekleyenListeSorgu_Body

            }

            public static eraporBashekimOnayRedCevapDVO eraporBashekimOnayRed(Guid siteID, string userName, string password, eraporBashekimOnayRedIstekDVO eraporBashekimOnayRedIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("3662f02a-5beb-4346-8aca-8858c68afc2c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporBashekimOnayRed_ServerSide", userName, password, eraporBashekimOnayRedIstek);
            }


            private static eraporBashekimOnayRedCevapDVO eraporBashekimOnayRed_ServerSide(string userName, string password, eraporBashekimOnayRedIstekDVO eraporBashekimOnayRedIstek)
            {

#region eraporBashekimOnayRed_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporBashekimOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporBashekimOnayRedIstek", (object)eraporBashekimOnayRedIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporBashekimOnayRedCevapDVO cevap = default(eraporBashekimOnayRedCevapDVO);
                    cevap = (eraporBashekimOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnayRed_Body

            }

            /// <summary>
            /// optik raporlarını kaydetmek için oluşturulmuştur.
            /// </summary>
            public static eRaporSonucDVO eraporGiris(Guid siteID, string userName, string password, raporTesisDVO raporTesis)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eRaporSonucDVO) TTMessageFactory.SyncCall(siteID, new Guid("ba175d99-4f2e-4c2b-a93a-21c0bd3d291c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporGiris_ServerSide", userName, password, raporTesis);
            }


            private static eRaporSonucDVO eraporGiris_ServerSide(string userName, string password, raporTesisDVO raporTesis)
            {

#region eraporGiris_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporTesis", (object)raporTesis),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporSonucDVO cevap = default(eRaporSonucDVO);
                    cevap = (eRaporSonucDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporGiris_Body

            }

            public static eraporListeSorguCevapDVO eraporListeSorgula(Guid siteID, string userName, string password, eraporListeSorguIstekDVO eraporListeSorguIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("a5769a15-ac97-45fd-bd9f-7161e34a72fd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporListeSorgula_ServerSide", userName, password, eraporListeSorguIstek);
            }


            private static eraporListeSorguCevapDVO eraporListeSorgula_ServerSide(string userName, string password, eraporListeSorguIstekDVO eraporListeSorguIstek)
            {

#region eraporListeSorgula_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporListeSorguIstek", (object)eraporListeSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporListeSorguCevapDVO cevap = default(eraporListeSorguCevapDVO);
                    cevap = (eraporListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporListeSorgula_Body

            }

            public static eraporOnayCevapDVO eraporOnay(Guid siteID, string userName, string password, eraporOnayIstekDVO eraporOnayIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("8bd9323e-a73d-4974-8e87-e4a68a3f72e8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporOnay_ServerSide", userName, password, eraporOnayIstek);
            }


            private static eraporOnayCevapDVO eraporOnay_ServerSide(string userName, string password, eraporOnayIstekDVO eraporOnayIstek)
            {

#region eraporOnay_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporOnayIstek", (object)eraporOnayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporOnayCevapDVO cevap = default(eraporOnayCevapDVO);
                    cevap = (eraporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnay_Body

            }

            public static eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorgu(Guid siteID, string userName, string password, eraporOnayBekleyenListeSorguIstekDVO eraporOnayBekleyenListeSorguIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2709479e-62dc-4c96-a156-66a0bfb3b46e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporOnayBekleyenListeSorgu_ServerSide", userName, password, eraporOnayBekleyenListeSorguIstek);
            }


            private static eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorgu_ServerSide(string userName, string password, eraporOnayBekleyenListeSorguIstekDVO eraporOnayBekleyenListeSorguIstek)
            {

#region eraporOnayBekleyenListeSorgu_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporOnayBekleyenListeSorguIstek", (object)eraporOnayBekleyenListeSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporOnayBekleyenListeSorguCevapDVO cevap = default(eraporOnayBekleyenListeSorguCevapDVO);
                    cevap = (eraporOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnayBekleyenListeSorgu_Body

            }

            public static eraporOnayRedCevapDVO eraporOnayRed(Guid siteID, string userName, string password, eraporOnayRedIstekDVO eraporOnayRedIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("aa7239cc-ddcd-445b-9cf8-47ddeb66607d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporOnayRed_ServerSide", userName, password, eraporOnayRedIstek);
            }


            private static eraporOnayRedCevapDVO eraporOnayRed_ServerSide(string userName, string password, eraporOnayRedIstekDVO eraporOnayRedIstek)
            {

#region eraporOnayRed_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporOnayRedIstek", (object)eraporOnayRedIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporOnayRedCevapDVO cevap = default(eraporOnayRedCevapDVO);
                    cevap = (eraporOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnayRed_Body

            }

            /// <summary>
            /// Optik raporlarını silmek için oluşturulmuştur.
            /// </summary>
            public static eRaporSonucDVO eraporSil(Guid siteID, string userName, string password, eraporSilDVO eraporSil)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eRaporSonucDVO) TTMessageFactory.SyncCall(siteID, new Guid("89b2534d-bf83-4aea-9e6c-53e1016d0503"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporSil_ServerSide", userName, password, eraporSil);
            }


            private static eRaporSonucDVO eraporSil_ServerSide(string userName, string password, eraporSilDVO eraporSil)
            {

#region eraporSil_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporSil", (object)eraporSil),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporSonucDVO cevap = default(eRaporSonucDVO);
                    cevap = (eRaporSonucDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporSil_Body

            }

            /// <summary>
            /// optik raporlarını sorgulamak için oluşturulmuştur
            /// </summary>
            public static eraporSorguCevapDVO eraporSorgula(Guid siteID, string userName, string password, eraporSorguIstekDVO eraporSorguIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("4557a5a4-5aca-4c5a-871c-963ae234011e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikRaporIslemleri+WebMethods, TTObjectClasses","eraporSorgula_ServerSide", userName, password, eraporSorguIstek);
            }


            private static eraporSorguCevapDVO eraporSorgula_ServerSide(string userName, string password, eraporSorguIstekDVO eraporSorguIstek)
            {

#region eraporSorgula_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikRaporIslemleri";
                    header.ServiceId = "3e7df395-36d0-4426-ba39-1d739c2e7ff5";
                    header.MethodName = "eraporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eraporSorguIstek", (object)eraporSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporSorguCevapDVO cevap = default(eraporSorguCevapDVO);
                    cevap = (eraporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporSorgula_Body

            }

        }
                    
        protected OptikRaporIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OptikRaporIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OptikRaporIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OptikRaporIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OptikRaporIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OPTIKRAPORISLEMLERI", dataRow) { }
        protected OptikRaporIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OPTIKRAPORISLEMLERI", dataRow, isImported) { }
        public OptikRaporIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OptikRaporIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OptikRaporIslemleri() : base() { }

    }
}