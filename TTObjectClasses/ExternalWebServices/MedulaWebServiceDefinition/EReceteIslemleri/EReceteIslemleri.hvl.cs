
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EReceteIslemleri")] 

    public  abstract  partial class EReceteIslemleri : TTObject
    {
        public class EReceteIslemleriList : TTObjectCollection<EReceteIslemleri> { }
                    
        public class ChildEReceteIslemleriCollection : TTObject.TTChildObjectCollection<EReceteIslemleri>
        {
            public ChildEReceteIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEReceteIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static EReceteIslemleri.ereceteAciklamaEkleCevapDVO ereceteAciklamaEkle(Guid siteID, string userName, string password, EReceteIslemleri.ereceteAciklamaEkleIstekDVO ereceteAciklamaEkleIstekDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (EReceteIslemleri.ereceteAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("163d4b0b-e5e5-42e0-b155-d36abc9186e8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteAciklamaEkle_ServerSide", userName, password, ereceteAciklamaEkleIstekDVO);
            }


            private static EReceteIslemleri.ereceteAciklamaEkleCevapDVO ereceteAciklamaEkle_ServerSide(string userName, string password, EReceteIslemleri.ereceteAciklamaEkleIstekDVO ereceteAciklamaEkleIstekDVO)
            {

#region ereceteAciklamaEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteAciklamaEkleIstekDVO", (object)ereceteAciklamaEkleIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    EReceteIslemleri.ereceteAciklamaEkleCevapDVO cevap = default(EReceteIslemleri.ereceteAciklamaEkleCevapDVO);
                    cevap = (EReceteIslemleri.ereceteAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteAciklamaEkle_Body

            }

            public static ereceteEhuOnayiCevapDVO ereceteEhuOnayi(Guid siteID, string userName, string password, ereceteEhuOnayiIstekDVO ereceteEhuOnayiIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteEhuOnayiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9993175a-9e8c-478c-9ebe-8e173e4a7d8c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteEhuOnayi_ServerSide", userName, password, ereceteEhuOnayiIstekDVO);
            }


            private static ereceteEhuOnayiCevapDVO ereceteEhuOnayi_ServerSide(string userName, string password, ereceteEhuOnayiIstekDVO ereceteEhuOnayiIstekDVO)
            {

#region ereceteEhuOnayi_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteEhuOnayi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteEhuOnayiIstekDVO", (object)ereceteEhuOnayiIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteEhuOnayiCevapDVO cevap = default(ereceteEhuOnayiCevapDVO);
                    cevap = (ereceteEhuOnayiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteEhuOnayi_Body

            }

            public static TTMessage ereceteEhuOnayiIptal(Guid siteID, string userName, string password, IWebMethodCallback callerObject, ereceteEhuOnayiIptalIstekDVO ereceteEhuOnayiIptalIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteEhuOnayiIptal_ServerSide", new Guid("f426502f-f895-4716-87a9-0cf9a82ccadb"), userName, password, callerObject, ereceteEhuOnayiIptalIstekDVO);
            }

            private static ereceteEhuOnayiIptalCevapDVO ereceteEhuOnayiIptal_ServerSide(string userName, string password, IWebMethodCallback callerObject, ereceteEhuOnayiIptalIstekDVO ereceteEhuOnayiIptalIstekDVO)
            {

#region ereceteEhuOnayiIptal_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteEhuOnayiIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteEhuOnayiIptalIstekDVO", (object)ereceteEhuOnayiIptalIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    ereceteEhuOnayiIptalCevapDVO cevap = default(ereceteEhuOnayiIptalCevapDVO);
                    
                    try
                    {
                        cevap = (ereceteEhuOnayiIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { ereceteEhuOnayiIptalIstekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { ereceteEhuOnayiIptalIstekDVO }, null);

                    return cevap;
                

#endregion ereceteEhuOnayiIptal_Body

            }

            public static TTMessage ereceteGiris(Guid siteID, string userName, string password, IWebMethodCallback callerObject, EReceteIslemleri.ereceteGirisIstekDVO  ereceteGirisIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteGiris_ServerSide", new Guid("e24e9a1d-5881-442f-af41-3eb4e0a0237a"), userName, password, callerObject, ereceteGirisIstekDVO);
            }

            private static EReceteIslemleri.ereceteGirisCevapDVO ereceteGiris_ServerSide(string userName, string password, IWebMethodCallback callerObject, EReceteIslemleri.ereceteGirisIstekDVO  ereceteGirisIstekDVO)
            {

#region ereceteGiris_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteGirisIstekDVO", (object)ereceteGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    EReceteIslemleri.ereceteGirisCevapDVO cevap = default(EReceteIslemleri.ereceteGirisCevapDVO);
                    
                    try
                    {
                        cevap = (EReceteIslemleri.ereceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { ereceteGirisIstekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { ereceteGirisIstekDVO }, null);

                    return cevap;
                

#endregion ereceteGiris_Body

            }

            public static EReceteIslemleri.ereceteGirisCevapDVO ereceteGirisSynCall(Guid siteID, string userName, string password, EReceteIslemleri.ereceteGirisIstekDVO  ereceteGirisIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (EReceteIslemleri.ereceteGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("86914b96-3054-411d-8189-f288f15f17c7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteGirisSynCall_ServerSide", userName, password, ereceteGirisIstekDVO);
            }


            private static EReceteIslemleri.ereceteGirisCevapDVO ereceteGirisSynCall_ServerSide(string userName, string password, EReceteIslemleri.ereceteGirisIstekDVO  ereceteGirisIstekDVO)
            {

#region ereceteGirisSynCall_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteGirisIstekDVO", (object)ereceteGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    EReceteIslemleri.ereceteGirisCevapDVO cevap = default(EReceteIslemleri.ereceteGirisCevapDVO);
                    cevap = (EReceteIslemleri.ereceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteGirisSynCall_Body

            }

            public static ereceteIlacAciklamaEkleCevapDVO ereceteIlacAciklamaEkle(Guid siteID, string userName, string password, ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteIlacAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("33f1abc6-a83a-421a-b524-cc4dfbcf0158"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteIlacAciklamaEkle_ServerSide", userName, password, ereceteIlacAciklamaEkleIstekDVO);
            }


            private static ereceteIlacAciklamaEkleCevapDVO ereceteIlacAciklamaEkle_ServerSide(string userName, string password, ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO)
            {

#region ereceteIlacAciklamaEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteIlacAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteIlacAciklamaEkleIstekDVO", (object)ereceteIlacAciklamaEkleIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteIlacAciklamaEkleCevapDVO cevap = default(ereceteIlacAciklamaEkleCevapDVO);
                    cevap = (ereceteIlacAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteIlacAciklamaEkle_Body

            }

            public static ereceteListeSorguCevapDVO ereceteListeSorgulaSync(Guid siteID, string userName, string password, ereceteListeSorguIstekDVO ereceteListeSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("70f24688-ed78-4964-bb52-c751859dbbaf"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteListeSorgulaSync_ServerSide", userName, password, ereceteListeSorguIstekDVO);
            }


            private static ereceteListeSorguCevapDVO ereceteListeSorgulaSync_ServerSide(string userName, string password, ereceteListeSorguIstekDVO ereceteListeSorguIstekDVO)
            {

#region ereceteListeSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteListeSorguIstekDVO", (object)ereceteListeSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteListeSorguCevapDVO cevap = default(ereceteListeSorguCevapDVO);
                    cevap = (ereceteListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteListeSorgulaSync_Body

            }

            public static ereceteOnayCevapDVO ereceteOnay(Guid siteID, string userName, string password, ereceteOnayIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f3f8f0c5-9710-4512-8e7d-ed37f3c5c6ce"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteOnay_ServerSide", userName, password, istekDVO);
            }


            private static ereceteOnayCevapDVO ereceteOnay_ServerSide(string userName, string password, ereceteOnayIstekDVO istekDVO)
            {

#region ereceteOnay_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteOnayCevapDVO cevap = default(ereceteOnayCevapDVO);
                    cevap = (ereceteOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteOnay_Body

            }

            public static TTMessage ereceteOnayIptal(Guid siteID, string userName, string password, IWebMethodCallback callerObject, ereceteOnayIptalIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteOnayIptal_ServerSide", new Guid("d549e088-7f7d-409a-bb25-3bea30242a20"), userName, password, callerObject, istekDVO);
            }

            private static ereceteOnayIptalCevapDVO ereceteOnayIptal_ServerSide(string userName, string password, IWebMethodCallback callerObject, ereceteOnayIptalIstekDVO istekDVO)
            {

#region ereceteOnayIptal_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteOnayIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    ereceteOnayIptalCevapDVO cevap = default(ereceteOnayIptalCevapDVO);
                    
                    try
                    {
                        cevap = (ereceteOnayIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { istekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { istekDVO }, null);

                    return cevap;
                

#endregion ereceteOnayIptal_Body

            }

            public static EReceteIslemleri.ereceteSilCevapDVO ereceteSil(Guid siteID, string userName, string password, EReceteIslemleri.ereceteSilIstekDVO ereceteSilIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (EReceteIslemleri.ereceteSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("ac0944de-bd3f-4e80-96dd-aef9b6a79eb7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteSil_ServerSide", userName, password, ereceteSilIstekDVO);
            }


            private static EReceteIslemleri.ereceteSilCevapDVO ereceteSil_ServerSide(string userName, string password, EReceteIslemleri.ereceteSilIstekDVO ereceteSilIstekDVO)
            {

#region ereceteSil_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteSilIstekDVO", (object)ereceteSilIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    EReceteIslemleri.ereceteSilCevapDVO cevap = default(EReceteIslemleri.ereceteSilCevapDVO);
                    cevap = (EReceteIslemleri.ereceteSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteSil_Body

            }

            public static EReceteIslemleri.ereceteSorguCevapDVO ereceteSorgulaSync(Guid siteID, string userName, string password, EReceteIslemleri.ereceteSorguIstekDVO ereceteSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (EReceteIslemleri.ereceteSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("7d06a7b8-e699-4b9c-ab01-9b514594de4a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteSorgulaSync_ServerSide", userName, password, ereceteSorguIstekDVO);
            }


            private static EReceteIslemleri.ereceteSorguCevapDVO ereceteSorgulaSync_ServerSide(string userName, string password, EReceteIslemleri.ereceteSorguIstekDVO ereceteSorguIstekDVO)
            {

#region ereceteSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteSorguIstekDVO", (object)ereceteSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    EReceteIslemleri.ereceteSorguCevapDVO cevap = default(EReceteIslemleri.ereceteSorguCevapDVO);
                    cevap = (EReceteIslemleri.ereceteSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteSorgulaSync_Body

            }

            public static ereceteTaniEkleCevapDVO ereceteTaniEkle(Guid siteID, string userName, string password, ereceteTaniEkleIstekDVO ereceteTaniEkleIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("46e6e165-e7e3-4286-9cde-b4d09e5b35ea"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteTaniEkle_ServerSide", userName, password, ereceteTaniEkleIstekDVO);
            }


            private static ereceteTaniEkleCevapDVO ereceteTaniEkle_ServerSide(string userName, string password, ereceteTaniEkleIstekDVO ereceteTaniEkleIstekDVO)
            {

#region ereceteTaniEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteTaniEkleIstekDVO", (object)ereceteTaniEkleIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteTaniEkleCevapDVO cevap = default(ereceteTaniEkleCevapDVO);
                    cevap = (ereceteTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteTaniEkle_Body

            }

            public static ereceteYatanHastaOnayiCevapDVO ereceteYatanHastaOnayi(Guid siteID, string userName, string password, ereceteYatanHastaOnayiIstekDVO ereceteYatanHastaOnayiIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteYatanHastaOnayiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("4d7c1025-5136-4e80-80fb-3c54fd5899e9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteYatanHastaOnayi_ServerSide", userName, password, ereceteYatanHastaOnayiIstekDVO);
            }


            private static ereceteYatanHastaOnayiCevapDVO ereceteYatanHastaOnayi_ServerSide(string userName, string password, ereceteYatanHastaOnayiIstekDVO ereceteYatanHastaOnayiIstekDVO)
            {

#region ereceteYatanHastaOnayi_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteYatanHastaOnayi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteYatanHastaOnayiIstekDVO", (object)ereceteYatanHastaOnayiIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteYatanHastaOnayiCevapDVO cevap = default(ereceteYatanHastaOnayiCevapDVO);
                    cevap = (ereceteYatanHastaOnayiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteYatanHastaOnayi_Body

            }

            public static ereceteYatanHastaOnayiIptalCevapDVO ereceteYatanHastaOnayiIptal(Guid siteID, string userName, string password, ereceteYatanHastaOnayiIptalIstekDVO ereceteYatanHastaOnayiIptalIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteYatanHastaOnayiIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("32ca932f-7ab8-4eb4-90ee-f0040be841c4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","ereceteYatanHastaOnayiIptal_ServerSide", userName, password, ereceteYatanHastaOnayiIptalIstekDVO);
            }


            private static ereceteYatanHastaOnayiIptalCevapDVO ereceteYatanHastaOnayiIptal_ServerSide(string userName, string password, ereceteYatanHastaOnayiIptalIstekDVO ereceteYatanHastaOnayiIptalIstekDVO)
            {

#region ereceteYatanHastaOnayiIptal_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "ereceteYatanHastaOnayiIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteYatanHastaOnayiIptalIstekDVO", (object)ereceteYatanHastaOnayiIptalIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteYatanHastaOnayiIptalCevapDVO cevap = default(ereceteYatanHastaOnayiIptalCevapDVO);
                    cevap = (ereceteYatanHastaOnayiIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteYatanHastaOnayiIptal_Body

            }

            public static imzaliEreceteAciklamaEkleCevapDVO imzaliEreceteAciklamaEkleSync(Guid siteID, string userName, string password, imzaliEreceteAciklamaEkleIstekDVO imzaliEreceteAciklamaEkleIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("5dd61e79-022c-4d26-ba9d-28d7a5aa790d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteAciklamaEkleSync_ServerSide", userName, password, imzaliEreceteAciklamaEkleIstekDVO);
            }


            private static imzaliEreceteAciklamaEkleCevapDVO imzaliEreceteAciklamaEkleSync_ServerSide(string userName, string password, imzaliEreceteAciklamaEkleIstekDVO imzaliEreceteAciklamaEkleIstekDVO)
            {

#region imzaliEreceteAciklamaEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteAciklamaEkleIstekDVO", (object)imzaliEreceteAciklamaEkleIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteAciklamaEkleCevapDVO cevap = default(imzaliEreceteAciklamaEkleCevapDVO);
                    cevap = (imzaliEreceteAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteAciklamaEkleSync_Body

            }

            public static TTMessage imzaliEreceteGiris(Guid siteID, IWebMethodCallback callerObject, imzaliEreceteGirisIstekDVO imzaliEreceteGirisIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteGiris_ServerSide", new Guid("b67f1da2-7474-4285-9ddb-080856dd9c33"), callerObject, imzaliEreceteGirisIstekDVO);
            }

            private static imzaliEreceteGirisCevapDVO imzaliEreceteGiris_ServerSide(IWebMethodCallback callerObject, imzaliEreceteGirisIstekDVO imzaliEreceteGirisIstekDVO)
            {

#region imzaliEreceteGiris_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteGirisIstekDVO", (object)imzaliEreceteGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["UniqueNo"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["ERECETEPASSWORD"];


                    imzaliEreceteGirisCevapDVO cevap = default(imzaliEreceteGirisCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEreceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliEreceteGirisIstekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliEreceteGirisIstekDVO }, null);

                    return cevap;
                

#endregion imzaliEreceteGiris_Body

            }

            public static imzaliEreceteGirisCevapDVO imzaliEreceteGirisSync(Guid siteID, string userName, string password, imzaliEreceteGirisIstekDVO imzaliEreceteGirisIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("0aee39af-634f-4192-b88f-09b0259a139e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteGirisSync_ServerSide", userName, password, imzaliEreceteGirisIstekDVO);
            }


            private static imzaliEreceteGirisCevapDVO imzaliEreceteGirisSync_ServerSide(string userName, string password, imzaliEreceteGirisIstekDVO imzaliEreceteGirisIstekDVO)
            {

#region imzaliEreceteGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteGirisIstekDVO", (object)imzaliEreceteGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteGirisCevapDVO cevap = default(imzaliEreceteGirisCevapDVO);
                    cevap = (imzaliEreceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteGirisSync_Body

            }

            public static imzaliEreceteIlacAciklamaEkleCevapDVO imzaliEreceteIlacAciklamaEkleSync(Guid siteID, string userName, string password, imzaliEreceteIlacAciklamaEkleIstekDVO imzaliEreceteIlacAciklamaEkleIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteIlacAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9a8d84af-5864-46b3-b67e-01091d8b7e5f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteIlacAciklamaEkleSync_ServerSide", userName, password, imzaliEreceteIlacAciklamaEkleIstekDVO);
            }


            private static imzaliEreceteIlacAciklamaEkleCevapDVO imzaliEreceteIlacAciklamaEkleSync_ServerSide(string userName, string password, imzaliEreceteIlacAciklamaEkleIstekDVO imzaliEreceteIlacAciklamaEkleIstekDVO)
            {

#region imzaliEreceteIlacAciklamaEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteIlacAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteIlacAciklamaEkleIstekDVO", (object)imzaliEreceteIlacAciklamaEkleIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteIlacAciklamaEkleCevapDVO cevap = default(imzaliEreceteIlacAciklamaEkleCevapDVO);
                    cevap = (imzaliEreceteIlacAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteIlacAciklamaEkleSync_Body

            }

            public static imzaliEreceteListeSorguCevapDVO imzaliEreceteListeSorguSync(Guid siteID, string userName, string password, imzaliEreceteListeSorguIstekDVO imzaliEreceteListeSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("30d47608-b7b8-41ca-967f-def07b33a278"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteListeSorguSync_ServerSide", userName, password, imzaliEreceteListeSorguIstekDVO);
            }


            private static imzaliEreceteListeSorguCevapDVO imzaliEreceteListeSorguSync_ServerSide(string userName, string password, imzaliEreceteListeSorguIstekDVO imzaliEreceteListeSorguIstekDVO)
            {

#region imzaliEreceteListeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteListeSorguIstekDVO", (object)imzaliEreceteListeSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteListeSorguCevapDVO cevap = default(imzaliEreceteListeSorguCevapDVO);
                    cevap = (imzaliEreceteListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteListeSorguSync_Body

            }

            public static TTMessage imzaliEreceteOnayIptalAsync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEreceteOnayIptalIstekDVO imzaliEreceteOnayIptalIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteOnayIptalAsync_ServerSide", new Guid("5e8ad1e6-92ba-4f97-90ea-60ae2774b54a"), userName, password, callerObject, imzaliEreceteOnayIptalIstekDVO);
            }

            private static imzaliEreceteOnayIptalCevapDVO imzaliEreceteOnayIptalAsync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEreceteOnayIptalIstekDVO imzaliEreceteOnayIptalIstekDVO)
            {

#region imzaliEreceteOnayIptalAsync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteOnayIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteOnayIptalIstekDVO", (object)imzaliEreceteOnayIptalIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEreceteOnayIptalCevapDVO cevap = default(imzaliEreceteOnayIptalCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEreceteOnayIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliEreceteOnayIptalIstekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliEreceteOnayIptalIstekDVO }, null);

                    return cevap;
                

#endregion imzaliEreceteOnayIptalAsync_Body

            }

            public static imzaliEreceteOnayIptalCevapDVO imzaliEreceteOnayIptalSync(Guid siteID, string userName, string password, imzaliEreceteOnayIptalIstekDVO imzaliEreceteOnayIptalIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteOnayIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c8c5f848-6747-4ec8-bb39-2d4c68c34795"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteOnayIptalSync_ServerSide", userName, password, imzaliEreceteOnayIptalIstekDVO);
            }


            private static imzaliEreceteOnayIptalCevapDVO imzaliEreceteOnayIptalSync_ServerSide(string userName, string password, imzaliEreceteOnayIptalIstekDVO imzaliEreceteOnayIptalIstekDVO)
            {

#region imzaliEreceteOnayIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteOnayIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteOnayIptalIstekDVO", (object)imzaliEreceteOnayIptalIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteOnayIptalCevapDVO cevap = default(imzaliEreceteOnayIptalCevapDVO);
                    cevap = (imzaliEreceteOnayIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteOnayIptalSync_Body

            }

            public static imzaliEreceteOnayCevapDVO imzaliEreceteOnaySync(Guid siteID, string userName, string password, imzaliEreceteOnayIstekDVO imzaliEreceteOnayIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("5c68d087-2ea1-447e-b448-093277e4d3b2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteOnaySync_ServerSide", userName, password, imzaliEreceteOnayIstekDVO);
            }


            private static imzaliEreceteOnayCevapDVO imzaliEreceteOnaySync_ServerSide(string userName, string password, imzaliEreceteOnayIstekDVO imzaliEreceteOnayIstekDVO)
            {

#region imzaliEreceteOnaySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteOnayIstekDVO", (object)imzaliEreceteOnayIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteOnayCevapDVO cevap = default(imzaliEreceteOnayCevapDVO);
                    cevap = (imzaliEreceteOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteOnaySync_Body

            }

            public static imzaliEreceteSilCevapDVO imzaliEreceteSilSync(Guid siteID, string userName, string password, imzaliEreceteSilIstekDVO imzaliEreceteSilIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c45ca367-6080-4f70-9831-63efe4c87b15"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteSilSync_ServerSide", userName, password, imzaliEreceteSilIstekDVO);
            }


            private static imzaliEreceteSilCevapDVO imzaliEreceteSilSync_ServerSide(string userName, string password, imzaliEreceteSilIstekDVO imzaliEreceteSilIstekDVO)
            {

#region imzaliEreceteSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteSilIstekDVO", (object)imzaliEreceteSilIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteSilCevapDVO cevap = default(imzaliEreceteSilCevapDVO);
                    cevap = (imzaliEreceteSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteSilSync_Body

            }

            public static imzaliEreceteSorguCevapDVO imzaliEreceteSorguSync(Guid siteID, string userName, string password, imzaliEreceteSorguIstekDVO imzaliEreceteSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("04abb8af-0e14-44da-8ba6-ac5ccced573a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteSorguSync_ServerSide", userName, password, imzaliEreceteSorguIstekDVO);
            }


            private static imzaliEreceteSorguCevapDVO imzaliEreceteSorguSync_ServerSide(string userName, string password, imzaliEreceteSorguIstekDVO imzaliEreceteSorguIstekDVO)
            {

#region imzaliEreceteSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteSorguIstekDVO", (object)imzaliEreceteSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteSorguCevapDVO cevap = default(imzaliEreceteSorguCevapDVO);
                    cevap = (imzaliEreceteSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteSorguSync_Body

            }

            public static imzaliEreceteTaniEkleCevapDVO imzaliEreceteTaniEkleSync(Guid siteID, string userName, string password, imzaliEreceteTaniEkleIstekDVO imzaliEreceteTaniEkleIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (imzaliEreceteTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("49597ad6-f5d3-486b-9cd6-3a9d3366bac8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EReceteIslemleri+WebMethods, TTObjectClasses","imzaliEreceteTaniEkleSync_ServerSide", userName, password, imzaliEreceteTaniEkleIstekDVO);
            }


            private static imzaliEreceteTaniEkleCevapDVO imzaliEreceteTaniEkleSync_ServerSide(string userName, string password, imzaliEreceteTaniEkleIstekDVO imzaliEreceteTaniEkleIstekDVO)
            {

#region imzaliEreceteTaniEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EReceteIslemleri";
                    header.ServiceId = "237cfbb3-a0ed-4d54-af7e-49c8a27ba4ae";
                    header.MethodName = "imzaliEreceteTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEreceteTaniEkleIstekDVO", (object)imzaliEreceteTaniEkleIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEreceteTaniEkleCevapDVO cevap = default(imzaliEreceteTaniEkleCevapDVO);
                    cevap = (imzaliEreceteTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEreceteTaniEkleSync_Body

            }

        }
                    
        protected EReceteIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EReceteIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EReceteIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EReceteIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EReceteIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ERECETEISLEMLERI", dataRow) { }
        protected EReceteIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ERECETEISLEMLERI", dataRow, isImported) { }
        public EReceteIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EReceteIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EReceteIslemleri() : base() { }

    }
}