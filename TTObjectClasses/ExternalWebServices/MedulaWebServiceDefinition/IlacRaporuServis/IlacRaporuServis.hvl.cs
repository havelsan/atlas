
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacRaporuServis")] 

    public  partial class IlacRaporuServis : TTObject
    {
        public class IlacRaporuServisList : TTObjectCollection<IlacRaporuServis> { }
                    
        public class ChildIlacRaporuServisCollection : TTObject.TTChildObjectCollection<IlacRaporuServis>
        {
            public ChildIlacRaporuServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacRaporuServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static eraporAciklamaEkleCevapDVO eraporAciklamaEkle(Guid siteID, string userName, string password, eraporAciklamaEkleIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("7a321b78-6f59-4d72-afcf-680eb11bdb59"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporAciklamaEkle_ServerSide", userName, password, istekDVO);
            }


            private static eraporAciklamaEkleCevapDVO eraporAciklamaEkle_ServerSide(string userName, string password, eraporAciklamaEkleIstekDVO istekDVO)
            {

#region eraporAciklamaEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporAciklamaEkle";
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

                    eraporAciklamaEkleCevapDVO cevap = default(eraporAciklamaEkleCevapDVO);
                    cevap = (eraporAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporAciklamaEkle_Body

            }

            public static TTMessage eraporAciklamaEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporAciklamaEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporAciklamaEkleASync_ServerSide", new Guid("c84f55e8-3a56-4476-990f-2d174577fe0a"), userName, password, callerObject, arg0);
            }

            private static eraporAciklamaEkleCevapDVO eraporAciklamaEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporAciklamaEkleIstekDVO arg0)
            {

#region eraporAciklamaEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporAciklamaEkleCevapDVO cevap = default(eraporAciklamaEkleCevapDVO);
                    
                    try
                    {
                        cevap = (eraporAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporAciklamaEkleASync_Body

            }

            public static eraporAciklamaEkleCevapDVO eraporAciklamaEkleSync(Guid siteID, string userName, string password, eraporAciklamaEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("48d3906e-c78e-47a6-9211-d45ccf3ecf86"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporAciklamaEkleSync_ServerSide", userName, password, arg0);
            }


            private static eraporAciklamaEkleCevapDVO eraporAciklamaEkleSync_ServerSide(string userName, string password, eraporAciklamaEkleIstekDVO arg0)
            {

#region eraporAciklamaEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporAciklamaEkleCevapDVO cevap = default(eraporAciklamaEkleCevapDVO);
                    cevap = (eraporAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporAciklamaEkleSync_Body

            }

            public static eraporBashekimOnayCevapDVO eraporBashekimOnay(Guid siteID, string userName, string password, eraporBashekimOnayIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f0646d4b-e150-4674-8e2c-29316c9aa501"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnay_ServerSide", userName, password, istekDVO);
            }


            private static eraporBashekimOnayCevapDVO eraporBashekimOnay_ServerSide(string userName, string password, eraporBashekimOnayIstekDVO istekDVO)
            {

#region eraporBashekimOnay_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnay";
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

                    eraporBashekimOnayCevapDVO cevap = default(eraporBashekimOnayCevapDVO);
                    cevap = (eraporBashekimOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnay_Body

            }

            public static TTMessage eraporBashekimOnayASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporBashekimOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnayASync_ServerSide", new Guid("6516d281-20d8-4781-80fe-cd6e60f4766b"), userName, password, callerObject, arg0);
            }

            private static eraporBashekimOnayCevapDVO eraporBashekimOnayASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporBashekimOnayIstekDVO arg0)
            {

#region eraporBashekimOnayASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporBashekimOnayCevapDVO cevap = default(eraporBashekimOnayCevapDVO);
                    
                    try
                    {
                        cevap = (eraporBashekimOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporBashekimOnayASync_Body

            }

            public static eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorgu(Guid siteID, eraporBashekimOnayBekleyenListeSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("59f5e301-1108-4731-87e2-e7afbd72fde1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnayBekleyenListeSorgu_ServerSide", istekDVO);
            }


            private static eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorgu_ServerSide(eraporBashekimOnayBekleyenListeSorguIstekDVO istekDVO)
            {

#region eraporBashekimOnayBekleyenListeSorgu_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    eraporBashekimOnayBekleyenListeSorguCevapDVO cevap = default(eraporBashekimOnayBekleyenListeSorguCevapDVO);
                    cevap = (eraporBashekimOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnayBekleyenListeSorgu_Body

            }

            public static TTMessage eraporBashekimOnayBekleyenListeSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnayBekleyenListeSorguASync_ServerSide", new Guid("aa5c7c89-cd68-4595-a27f-1bfd3f78e9ff"), userName, password, callerObject, arg0);
            }

            private static eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {

#region eraporBashekimOnayBekleyenListeSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporBashekimOnayBekleyenListeSorguCevapDVO cevap = default(eraporBashekimOnayBekleyenListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eraporBashekimOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporBashekimOnayBekleyenListeSorguASync_Body

            }

            public static eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorguSync(Guid siteID, string userName, string password, eraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("3cec98e3-155a-4850-896e-1c183ea77d39"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnayBekleyenListeSorguSync_ServerSide", userName, password, arg0);
            }


            private static eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorguSync_ServerSide(string userName, string password, eraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {

#region eraporBashekimOnayBekleyenListeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporBashekimOnayBekleyenListeSorguCevapDVO cevap = default(eraporBashekimOnayBekleyenListeSorguCevapDVO);
                    cevap = (eraporBashekimOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnayBekleyenListeSorguSync_Body

            }

            public static eraporBashekimOnayRedCevapDVO eraporBashekimOnayRed(Guid siteID, eraporBashekimOnayRedIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("45058a23-af8a-4e6a-b438-da5ef32481f8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnayRed_ServerSide", istekDVO);
            }


            private static eraporBashekimOnayRedCevapDVO eraporBashekimOnayRed_ServerSide(eraporBashekimOnayRedIstekDVO istekDVO)
            {

#region eraporBashekimOnayRed_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    eraporBashekimOnayRedCevapDVO cevap = default(eraporBashekimOnayRedCevapDVO);
                    cevap = (eraporBashekimOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnayRed_Body

            }

            public static TTMessage eraporBashekimOnayRedASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporBashekimOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnayRedASync_ServerSide", new Guid("654399ca-068c-473f-b6d6-591c2283048b"), userName, password, callerObject, arg0);
            }

            private static eraporBashekimOnayRedCevapDVO eraporBashekimOnayRedASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporBashekimOnayRedIstekDVO arg0)
            {

#region eraporBashekimOnayRedASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporBashekimOnayRedCevapDVO cevap = default(eraporBashekimOnayRedCevapDVO);
                    
                    try
                    {
                        cevap = (eraporBashekimOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporBashekimOnayRedASync_Body

            }

            public static eraporBashekimOnayRedCevapDVO eraporBashekimOnayRedSync(Guid siteID, string userName, string password, eraporBashekimOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9933cd6b-d07d-4451-9a4f-69d57fcc9963"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnayRedSync_ServerSide", userName, password, arg0);
            }


            private static eraporBashekimOnayRedCevapDVO eraporBashekimOnayRedSync_ServerSide(string userName, string password, eraporBashekimOnayRedIstekDVO arg0)
            {

#region eraporBashekimOnayRedSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporBashekimOnayRedCevapDVO cevap = default(eraporBashekimOnayRedCevapDVO);
                    cevap = (eraporBashekimOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnayRedSync_Body

            }

            public static eraporBashekimOnayCevapDVO eraporBashekimOnaySync(Guid siteID, string userName, string password, eraporBashekimOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporBashekimOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("6cb403bb-ac9c-496f-8c34-a2e105191163"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporBashekimOnaySync_ServerSide", userName, password, arg0);
            }


            private static eraporBashekimOnayCevapDVO eraporBashekimOnaySync_ServerSide(string userName, string password, eraporBashekimOnayIstekDVO arg0)
            {

#region eraporBashekimOnaySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporBashekimOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporBashekimOnayCevapDVO cevap = default(eraporBashekimOnayCevapDVO);
                    cevap = (eraporBashekimOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporBashekimOnaySync_Body

            }

            public static eraporEtkinMaddeEkleCevapDVO eraporEtkinMaddeEkle(Guid siteID, string userName, string password, eraporEtkinMaddeEkleIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporEtkinMaddeEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2ba5baba-8d6a-4686-8835-3d286b74f666"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporEtkinMaddeEkle_ServerSide", userName, password, istekDVO);
            }


            private static eraporEtkinMaddeEkleCevapDVO eraporEtkinMaddeEkle_ServerSide(string userName, string password, eraporEtkinMaddeEkleIstekDVO istekDVO)
            {

#region eraporEtkinMaddeEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporEtkinMaddeEkle";
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

                    eraporEtkinMaddeEkleCevapDVO cevap = default(eraporEtkinMaddeEkleCevapDVO);
                    cevap = (eraporEtkinMaddeEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporEtkinMaddeEkle_Body

            }

            public static TTMessage eraporEtkinMaddeEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporEtkinMaddeEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporEtkinMaddeEkleASync_ServerSide", new Guid("41aaf4a2-c673-4fcd-8721-ef11298908ae"), userName, password, callerObject, arg0);
            }

            private static eraporEtkinMaddeEkleCevapDVO eraporEtkinMaddeEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporEtkinMaddeEkleIstekDVO arg0)
            {

#region eraporEtkinMaddeEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporEtkinMaddeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporEtkinMaddeEkleCevapDVO cevap = default(eraporEtkinMaddeEkleCevapDVO);
                    
                    try
                    {
                        cevap = (eraporEtkinMaddeEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporEtkinMaddeEkleASync_Body

            }

            public static eraporEtkinMaddeEkleCevapDVO eraporEtkinMaddeEkleSync(Guid siteID, string userName, string password, eraporEtkinMaddeEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporEtkinMaddeEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c25b4a6a-03af-4400-a061-041f0b912181"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporEtkinMaddeEkleSync_ServerSide", userName, password, arg0);
            }


            private static eraporEtkinMaddeEkleCevapDVO eraporEtkinMaddeEkleSync_ServerSide(string userName, string password, eraporEtkinMaddeEkleIstekDVO arg0)
            {

#region eraporEtkinMaddeEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporEtkinMaddeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporEtkinMaddeEkleCevapDVO cevap = default(eraporEtkinMaddeEkleCevapDVO);
                    cevap = (eraporEtkinMaddeEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporEtkinMaddeEkleSync_Body

            }

            public static eraporGirisCevapDVO eraporGiris(Guid siteID, string userName, string password, eraporGirisIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f4d0c14c-a9d5-439f-93b0-80e8bfb691b9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporGiris_ServerSide", userName, password, istekDVO);
            }


            private static eraporGirisCevapDVO eraporGiris_ServerSide(string userName, string password, eraporGirisIstekDVO istekDVO)
            {

#region eraporGiris_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporGiris";
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

                    eraporGirisCevapDVO cevap = default(eraporGirisCevapDVO);
                    cevap = (eraporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporGiris_Body

            }

            public static TTMessage eraporGirisASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporGirisIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporGirisASync_ServerSide", new Guid("41c94e0b-b060-4931-8fbb-c762031f53e1"), userName, password, callerObject, arg0);
            }

            private static eraporGirisCevapDVO eraporGirisASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporGirisIstekDVO arg0)
            {

#region eraporGirisASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporGirisCevapDVO cevap = default(eraporGirisCevapDVO);
                    
                    try
                    {
                        cevap = (eraporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporGirisASync_Body

            }

            public static eraporGirisCevapDVO eraporGirisSync(Guid siteID, string userName, string password, eraporGirisIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("cff1e14e-859a-4af3-97d2-2755fd1df3cc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporGirisSync_ServerSide", userName, password, arg0);
            }


            private static eraporGirisCevapDVO eraporGirisSync_ServerSide(string userName, string password, eraporGirisIstekDVO arg0)
            {

#region eraporGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporGirisCevapDVO cevap = default(eraporGirisCevapDVO);
                    cevap = (eraporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporGirisSync_Body

            }

            public static TTMessage eraporIlaveDegerEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporIlaveDegerEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporIlaveDegerEkleASync_ServerSide", new Guid("d92a6cad-2d7a-4dd4-a73d-8440dacdaffc"), userName, password, callerObject, arg0);
            }

            private static eraporIlaveDegerEkleCevapDVO eraporIlaveDegerEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporIlaveDegerEkleIstekDVO arg0)
            {

#region eraporIlaveDegerEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporIlaveDegerEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporIlaveDegerEkleCevapDVO cevap = default(eraporIlaveDegerEkleCevapDVO);
                    
                    try
                    {
                        cevap = (eraporIlaveDegerEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporIlaveDegerEkleASync_Body

            }

            public static eraporIlaveDegerEkleCevapDVO eraporIlaveDegerEkleSync(Guid siteID, string userName, string password, eraporIlaveDegerEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporIlaveDegerEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("4e53b9ad-2172-4b61-a05c-cfa6925cf29b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporIlaveDegerEkleSync_ServerSide", userName, password, arg0);
            }


            private static eraporIlaveDegerEkleCevapDVO eraporIlaveDegerEkleSync_ServerSide(string userName, string password, eraporIlaveDegerEkleIstekDVO arg0)
            {

#region eraporIlaveDegerEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporIlaveDegerEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporIlaveDegerEkleCevapDVO cevap = default(eraporIlaveDegerEkleCevapDVO);
                    cevap = (eraporIlaveDegerEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporIlaveDegerEkleSync_Body

            }

            public static eraporListeSorguCevapDVO eraporListeSorgula(Guid siteID, string userName, string password, eraporListeSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("a7a65e31-d1f4-4ed1-98ad-29f4d5e168f5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporListeSorgula_ServerSide", userName, password, istekDVO);
            }


            private static eraporListeSorguCevapDVO eraporListeSorgula_ServerSide(string userName, string password, eraporListeSorguIstekDVO istekDVO)
            {

#region eraporListeSorgula_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporListeSorgula";
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

                    eraporListeSorguCevapDVO cevap = default(eraporListeSorguCevapDVO);
                    cevap = (eraporListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporListeSorgula_Body

            }

            public static TTMessage eraporListeSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporListeSorgulaASync_ServerSide", new Guid("cfcc847e-f6a3-4933-8f13-6f2eafef6e93"), userName, password, callerObject, arg0);
            }

            private static eraporListeSorguCevapDVO eraporListeSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporListeSorguIstekDVO arg0)
            {

#region eraporListeSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporListeSorguCevapDVO cevap = default(eraporListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eraporListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporListeSorgulaASync_Body

            }

            public static eraporListeSorguCevapDVO eraporListeSorgulaSync(Guid siteID, string userName, string password, eraporListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("08ef16dd-2bbe-41c3-ab1e-08d379286ac2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporListeSorgulaSync_ServerSide", userName, password, arg0);
            }


            private static eraporListeSorguCevapDVO eraporListeSorgulaSync_ServerSide(string userName, string password, eraporListeSorguIstekDVO arg0)
            {

#region eraporListeSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporListeSorguCevapDVO cevap = default(eraporListeSorguCevapDVO);
                    cevap = (eraporListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporListeSorgulaSync_Body

            }

            public static eraporOnayCevapDVO eraporOnay(Guid siteID, string userName, string password, eraporOnayIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b6888ec8-b16a-4f0f-876b-3da22fb64489"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnay_ServerSide", userName, password, istekDVO);
            }


            private static eraporOnayCevapDVO eraporOnay_ServerSide(string userName, string password, eraporOnayIstekDVO istekDVO)
            {

#region eraporOnay_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnay";
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

                    eraporOnayCevapDVO cevap = default(eraporOnayCevapDVO);
                    cevap = (eraporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnay_Body

            }

            public static TTMessage eraporOnayASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnayASync_ServerSide", new Guid("21fb29c6-2764-4eff-8905-2f056a1623b4"), userName, password, callerObject, arg0);
            }

            private static eraporOnayCevapDVO eraporOnayASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporOnayIstekDVO arg0)
            {

#region eraporOnayASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporOnayCevapDVO cevap = default(eraporOnayCevapDVO);
                    
                    try
                    {
                        cevap = (eraporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporOnayASync_Body

            }

            public static eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorgu(Guid siteID, eraporOnayBekleyenListeSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b4550f3f-1c80-4727-99af-3b65134227e4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnayBekleyenListeSorgu_ServerSide", istekDVO);
            }


            private static eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorgu_ServerSide(eraporOnayBekleyenListeSorguIstekDVO istekDVO)
            {

#region eraporOnayBekleyenListeSorgu_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    eraporOnayBekleyenListeSorguCevapDVO cevap = default(eraporOnayBekleyenListeSorguCevapDVO);
                    cevap = (eraporOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnayBekleyenListeSorgu_Body

            }

            public static TTMessage eraporOnayBekleyenListeSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnayBekleyenListeSorguASync_ServerSide", new Guid("f6514a85-772e-4fb8-ab39-8994984be8e2"), userName, password, callerObject, arg0);
            }

            private static eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporOnayBekleyenListeSorguIstekDVO arg0)
            {

#region eraporOnayBekleyenListeSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporOnayBekleyenListeSorguCevapDVO cevap = default(eraporOnayBekleyenListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eraporOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporOnayBekleyenListeSorguASync_Body

            }

            public static eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorguSync(Guid siteID, string userName, string password, eraporOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e0501deb-e83d-448c-89b3-cc01b4f3f2ae"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnayBekleyenListeSorguSync_ServerSide", userName, password, arg0);
            }


            private static eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorguSync_ServerSide(string userName, string password, eraporOnayBekleyenListeSorguIstekDVO arg0)
            {

#region eraporOnayBekleyenListeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporOnayBekleyenListeSorguCevapDVO cevap = default(eraporOnayBekleyenListeSorguCevapDVO);
                    cevap = (eraporOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnayBekleyenListeSorguSync_Body

            }

            public static eraporOnayRedCevapDVO eraporOnayRed(Guid siteID, string userName, string password, eraporOnayRedIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9e51054d-eb18-47a6-999a-ba466c6522ad"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnayRed_ServerSide", userName, password, istekDVO);
            }


            private static eraporOnayRedCevapDVO eraporOnayRed_ServerSide(string userName, string password, eraporOnayRedIstekDVO istekDVO)
            {

#region eraporOnayRed_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnayRed";
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

                    eraporOnayRedCevapDVO cevap = default(eraporOnayRedCevapDVO);
                    cevap = (eraporOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnayRed_Body

            }

            public static TTMessage eraporOnayRedASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnayRedASync_ServerSide", new Guid("d3964b57-74c8-49e6-8061-a45bc5f7b1ae"), userName, password, callerObject, arg0);
            }

            private static eraporOnayRedCevapDVO eraporOnayRedASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporOnayRedIstekDVO arg0)
            {

#region eraporOnayRedASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporOnayRedCevapDVO cevap = default(eraporOnayRedCevapDVO);
                    
                    try
                    {
                        cevap = (eraporOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporOnayRedASync_Body

            }

            public static eraporOnayRedCevapDVO eraporOnayRedSync(Guid siteID, string userName, string password, eraporOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c551e15e-8ca2-4f6b-a06f-46c7cddae98d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnayRedSync_ServerSide", userName, password, arg0);
            }


            private static eraporOnayRedCevapDVO eraporOnayRedSync_ServerSide(string userName, string password, eraporOnayRedIstekDVO arg0)
            {

#region eraporOnayRedSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporOnayRedCevapDVO cevap = default(eraporOnayRedCevapDVO);
                    cevap = (eraporOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnayRedSync_Body

            }

            public static eraporOnayCevapDVO eraporOnaySync(Guid siteID, string userName, string password, eraporOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("63a007f8-f491-439f-9f0f-8aa0db7b7d29"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporOnaySync_ServerSide", userName, password, arg0);
            }


            private static eraporOnayCevapDVO eraporOnaySync_ServerSide(string userName, string password, eraporOnayIstekDVO arg0)
            {

#region eraporOnaySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporOnayCevapDVO cevap = default(eraporOnayCevapDVO);
                    cevap = (eraporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporOnaySync_Body

            }

            public static eraporSilCevapDVO eraporSil(Guid siteID, string userName, string password, eraporSilIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("0298f3e2-6f85-46d4-97aa-6cbb0594e9d6"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporSil_ServerSide", userName, password, istekDVO);
            }


            private static eraporSilCevapDVO eraporSil_ServerSide(string userName, string password, eraporSilIstekDVO istekDVO)
            {

#region eraporSil_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporSil";
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

                    eraporSilCevapDVO cevap = default(eraporSilCevapDVO);
                    cevap = (eraporSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporSil_Body

            }

            public static TTMessage eraporSilASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporSilIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporSilASync_ServerSide", new Guid("500704fa-0431-445d-8cb9-e56abff65684"), userName, password, callerObject, arg0);
            }

            private static eraporSilCevapDVO eraporSilASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporSilIstekDVO arg0)
            {

#region eraporSilASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporSilCevapDVO cevap = default(eraporSilCevapDVO);
                    
                    try
                    {
                        cevap = (eraporSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporSilASync_Body

            }

            public static eraporSilCevapDVO eraporSilSync(Guid siteID, string userName, string password, eraporSilIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("bae70e48-0bc2-4768-bc01-2f1b7388a977"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporSilSync_ServerSide", userName, password, arg0);
            }


            private static eraporSilCevapDVO eraporSilSync_ServerSide(string userName, string password, eraporSilIstekDVO arg0)
            {

#region eraporSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporSilCevapDVO cevap = default(eraporSilCevapDVO);
                    cevap = (eraporSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporSilSync_Body

            }

            public static eraporSorguCevapDVO eraporSorgula(Guid siteID, eraporSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("dbd79765-df2b-479c-9543-dfcaf0876ae2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporSorgula_ServerSide", istekDVO);
            }


            private static eraporSorguCevapDVO eraporSorgula_ServerSide(eraporSorguIstekDVO istekDVO)
            {

#region eraporSorgula_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    eraporSorguCevapDVO cevap = default(eraporSorguCevapDVO);
                    cevap = (eraporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporSorgula_Body

            }

            public static TTMessage eraporSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporSorgulaASync_ServerSide", new Guid("6fc10383-36af-44a2-837a-e680672c9000"), userName, password, callerObject, arg0);
            }

            private static eraporSorguCevapDVO eraporSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporSorguIstekDVO arg0)
            {

#region eraporSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporSorguCevapDVO cevap = default(eraporSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eraporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporSorgulaASync_Body

            }

            public static eraporSorguCevapDVO eraporSorgulaSync(Guid siteID, string userName, string password, eraporSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("cd70f99f-03ca-4850-a31b-e39797912a41"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporSorgulaSync_ServerSide", userName, password, arg0);
            }


            private static eraporSorguCevapDVO eraporSorgulaSync_ServerSide(string userName, string password, eraporSorguIstekDVO arg0)
            {

#region eraporSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporSorguCevapDVO cevap = default(eraporSorguCevapDVO);
                    cevap = (eraporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporSorgulaSync_Body

            }

            public static eraporTaniEkleCevapDVO eraporTaniEkle(Guid siteID, string userName, string password, eraporTaniEkleIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("630ed0ef-f890-4bd1-b724-393a7b3c3fce"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporTaniEkle_ServerSide", userName, password, istekDVO);
            }


            private static eraporTaniEkleCevapDVO eraporTaniEkle_ServerSide(string userName, string password, eraporTaniEkleIstekDVO istekDVO)
            {

#region eraporTaniEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporTaniEkle";
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

                    eraporTaniEkleCevapDVO cevap = default(eraporTaniEkleCevapDVO);
                    cevap = (eraporTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporTaniEkle_Body

            }

            public static TTMessage eraporTaniEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporTaniEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporTaniEkleASync_ServerSide", new Guid("db48ae1a-156e-43b3-8a75-5c5ec117b148"), userName, password, callerObject, arg0);
            }

            private static eraporTaniEkleCevapDVO eraporTaniEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporTaniEkleIstekDVO arg0)
            {

#region eraporTaniEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporTaniEkleCevapDVO cevap = default(eraporTaniEkleCevapDVO);
                    
                    try
                    {
                        cevap = (eraporTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporTaniEkleASync_Body

            }

            public static eraporTaniEkleCevapDVO eraporTaniEkleSync(Guid siteID, string userName, string password, eraporTaniEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("a0907aa1-ed64-439b-9506-d8decbfb402f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporTaniEkleSync_ServerSide", userName, password, arg0);
            }


            private static eraporTaniEkleCevapDVO eraporTaniEkleSync_ServerSide(string userName, string password, eraporTaniEkleIstekDVO arg0)
            {

#region eraporTaniEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporTaniEkleCevapDVO cevap = default(eraporTaniEkleCevapDVO);
                    cevap = (eraporTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporTaniEkleSync_Body

            }

            public static eraporTeshisEkleCevapDVO eraporTeshisEkle(Guid siteID, string userName, string password, eraporTeshisEkleIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (eraporTeshisEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c9b3f871-3b06-463f-906e-e2ad1c765bef"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporTeshisEkle_ServerSide", userName, password, istekDVO);
            }


            private static eraporTeshisEkleCevapDVO eraporTeshisEkle_ServerSide(string userName, string password, eraporTeshisEkleIstekDVO istekDVO)
            {

#region eraporTeshisEkle_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporTeshisEkle";
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

                    eraporTeshisEkleCevapDVO cevap = default(eraporTeshisEkleCevapDVO);
                    cevap = (eraporTeshisEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporTeshisEkle_Body

            }

            public static TTMessage eraporTeshisEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eraporTeshisEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporTeshisEkleASync_ServerSide", new Guid("98c207d5-aadd-4539-a4e9-667802f1b8ef"), userName, password, callerObject, arg0);
            }

            private static eraporTeshisEkleCevapDVO eraporTeshisEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eraporTeshisEkleIstekDVO arg0)
            {

#region eraporTeshisEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporTeshisEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eraporTeshisEkleCevapDVO cevap = default(eraporTeshisEkleCevapDVO);
                    
                    try
                    {
                        cevap = (eraporTeshisEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion eraporTeshisEkleASync_Body

            }

            public static eraporTeshisEkleCevapDVO eraporTeshisEkleSync(Guid siteID, string userName, string password, eraporTeshisEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eraporTeshisEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("552f1fdf-039e-42dd-b779-64dae208a5db"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","eraporTeshisEkleSync_ServerSide", userName, password, arg0);
            }


            private static eraporTeshisEkleCevapDVO eraporTeshisEkleSync_ServerSide(string userName, string password, eraporTeshisEkleIstekDVO arg0)
            {

#region eraporTeshisEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "eraporTeshisEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eraporTeshisEkleCevapDVO cevap = default(eraporTeshisEkleCevapDVO);
                    cevap = (eraporTeshisEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eraporTeshisEkleSync_Body

            }

            public static TTMessage imzaliEraporAciklamaEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporAciklamaEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporAciklamaEkleASync_ServerSide", new Guid("dd91873d-25f6-42c1-924a-81fcb8657aaf"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporAciklamaEkleCevapDVO imzaliEraporAciklamaEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporAciklamaEkleIstekDVO arg0)
            {

#region imzaliEraporAciklamaEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporAciklamaEkleCevapDVO cevap = default(imzaliEraporAciklamaEkleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporAciklamaEkleASync_Body

            }

            public static imzaliEraporAciklamaEkleCevapDVO imzaliEraporAciklamaEkleSync(Guid siteID, string userName, string password, imzaliEraporAciklamaEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporAciklamaEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d4adc557-7af5-478c-94b6-889c2e8edef5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporAciklamaEkleSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporAciklamaEkleCevapDVO imzaliEraporAciklamaEkleSync_ServerSide(string userName, string password, imzaliEraporAciklamaEkleIstekDVO arg0)
            {

#region imzaliEraporAciklamaEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporAciklamaEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporAciklamaEkleCevapDVO cevap = default(imzaliEraporAciklamaEkleCevapDVO);
                    cevap = (imzaliEraporAciklamaEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporAciklamaEkleSync_Body

            }

            public static TTMessage imzaliEraporBashekimOnayASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporBashekimOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporBashekimOnayASync_ServerSide", new Guid("ce25ac3b-50d7-419f-a484-4036fbe883e0"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporBashekimOnayCevapDVO imzaliEraporBashekimOnayASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporBashekimOnayIstekDVO arg0)
            {

#region imzaliEraporBashekimOnayASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporBashekimOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporBashekimOnayCevapDVO cevap = default(imzaliEraporBashekimOnayCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporBashekimOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporBashekimOnayASync_Body

            }

            public static TTMessage imzaliEraporBashekimOnayBekleyenListeSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporBashekimOnayBekleyenListeSorguASync_ServerSide", new Guid("9359309e-5cf8-46fc-9447-0c0306f66f0b"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO imzaliEraporBashekimOnayBekleyenListeSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {

#region imzaliEraporBashekimOnayBekleyenListeSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporBashekimOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO cevap = default(imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporBashekimOnayBekleyenListeSorguASync_Body

            }

            public static imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO imzaliEraporBashekimOnayBekleyenListeSorguSync(Guid siteID, string userName, string password, imzaliEraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("3fcd3190-19ea-408f-85fa-4ac8608292f5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporBashekimOnayBekleyenListeSorguSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO imzaliEraporBashekimOnayBekleyenListeSorguSync_ServerSide(string userName, string password, imzaliEraporBashekimOnayBekleyenListeSorguIstekDVO arg0)
            {

#region imzaliEraporBashekimOnayBekleyenListeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporBashekimOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO cevap = default(imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO);
                    cevap = (imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporBashekimOnayBekleyenListeSorguSync_Body

            }

            public static TTMessage imzaliEraporBashekimOnayRedASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporBashekimOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporBashekimOnayRedASync_ServerSide", new Guid("d8e658c5-386b-4391-8030-f31ebd3ef238"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporBashekimOnayRedCevapDVO imzaliEraporBashekimOnayRedASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporBashekimOnayRedIstekDVO arg0)
            {

#region imzaliEraporBashekimOnayRedASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporBashekimOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporBashekimOnayRedCevapDVO cevap = default(imzaliEraporBashekimOnayRedCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporBashekimOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporBashekimOnayRedASync_Body

            }

            public static imzaliEraporBashekimOnayRedCevapDVO imzaliEraporBashekimOnayRedSync(Guid siteID, string userName, string password, imzaliEraporBashekimOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporBashekimOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("31724bd7-ae60-429b-9939-68b0573e867d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporBashekimOnayRedSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporBashekimOnayRedCevapDVO imzaliEraporBashekimOnayRedSync_ServerSide(string userName, string password, imzaliEraporBashekimOnayRedIstekDVO arg0)
            {

#region imzaliEraporBashekimOnayRedSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporBashekimOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporBashekimOnayRedCevapDVO cevap = default(imzaliEraporBashekimOnayRedCevapDVO);
                    cevap = (imzaliEraporBashekimOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporBashekimOnayRedSync_Body

            }

            public static imzaliEraporBashekimOnayCevapDVO imzaliEraporBashekimOnaySync(Guid siteID, string userName, string password, imzaliEraporBashekimOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporBashekimOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("ad74d41e-09f8-4dd7-96dd-af4eb7d06069"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporBashekimOnaySync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporBashekimOnayCevapDVO imzaliEraporBashekimOnaySync_ServerSide(string userName, string password, imzaliEraporBashekimOnayIstekDVO arg0)
            {

#region imzaliEraporBashekimOnaySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporBashekimOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporBashekimOnayCevapDVO cevap = default(imzaliEraporBashekimOnayCevapDVO);
                    cevap = (imzaliEraporBashekimOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporBashekimOnaySync_Body

            }

            public static TTMessage imzaliEraporEtkinMaddeEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporEtkinMaddeEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporEtkinMaddeEkleASync_ServerSide", new Guid("63ef3874-c3bd-47e0-856c-909e5a8b7b0a"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporEtkinMaddeEkleCevapDVO imzaliEraporEtkinMaddeEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporEtkinMaddeEkleIstekDVO arg0)
            {

#region imzaliEraporEtkinMaddeEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporEtkinMaddeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporEtkinMaddeEkleCevapDVO cevap = default(imzaliEraporEtkinMaddeEkleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporEtkinMaddeEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporEtkinMaddeEkleASync_Body

            }

            public static imzaliEraporEtkinMaddeEkleCevapDVO imzaliEraporEtkinMaddeEkleSync(Guid siteID, string userName, string password, imzaliEraporEtkinMaddeEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporEtkinMaddeEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("83e47059-00de-457c-acb2-4de4533aacc8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporEtkinMaddeEkleSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporEtkinMaddeEkleCevapDVO imzaliEraporEtkinMaddeEkleSync_ServerSide(string userName, string password, imzaliEraporEtkinMaddeEkleIstekDVO arg0)
            {

#region imzaliEraporEtkinMaddeEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporEtkinMaddeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporEtkinMaddeEkleCevapDVO cevap = default(imzaliEraporEtkinMaddeEkleCevapDVO);
                    cevap = (imzaliEraporEtkinMaddeEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporEtkinMaddeEkleSync_Body

            }

            public static TTMessage imzaliEraporGirisASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporGirisIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporGirisASync_ServerSide", new Guid("1045ac7d-e86a-441b-9a27-5dd45c5a5da0"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporGirisCevapDVO imzaliEraporGirisASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporGirisIstekDVO arg0)
            {

#region imzaliEraporGirisASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporGirisCevapDVO cevap = default(imzaliEraporGirisCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporGirisASync_Body

            }

            public static imzaliEraporGirisCevapDVO imzaliEraporGirisSync(Guid siteID, string userName, string password, imzaliEraporGirisIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("624efb7a-7080-4646-a14d-07020f433e6f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporGirisSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporGirisCevapDVO imzaliEraporGirisSync_ServerSide(string userName, string password, imzaliEraporGirisIstekDVO arg0)
            {

#region imzaliEraporGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporGirisCevapDVO cevap = default(imzaliEraporGirisCevapDVO);
                    cevap = (imzaliEraporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporGirisSync_Body

            }

            public static TTMessage imzaliEraporIlaveDegerEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporIlaveDegerEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporIlaveDegerEkleASync_ServerSide", new Guid("b2d25abc-4a14-4a42-9116-dcce2c61239c"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporIlaveDegerEkleCevapDVO imzaliEraporIlaveDegerEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporIlaveDegerEkleIstekDVO arg0)
            {

#region imzaliEraporIlaveDegerEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporIlaveDegerEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporIlaveDegerEkleCevapDVO cevap = default(imzaliEraporIlaveDegerEkleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporIlaveDegerEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporIlaveDegerEkleASync_Body

            }

            public static imzaliEraporIlaveDegerEkleCevapDVO imzaliEraporIlaveDegerEkleSync(Guid siteID, string userName, string password, imzaliEraporIlaveDegerEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporIlaveDegerEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("db549339-bb05-4f7f-89db-9f878e42f034"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporIlaveDegerEkleSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporIlaveDegerEkleCevapDVO imzaliEraporIlaveDegerEkleSync_ServerSide(string userName, string password, imzaliEraporIlaveDegerEkleIstekDVO arg0)
            {

#region imzaliEraporIlaveDegerEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporIlaveDegerEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporIlaveDegerEkleCevapDVO cevap = default(imzaliEraporIlaveDegerEkleCevapDVO);
                    cevap = (imzaliEraporIlaveDegerEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporIlaveDegerEkleSync_Body

            }

            public static TTMessage imzaliEraporListeSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporListeSorgulaASync_ServerSide", new Guid("37632bfb-3db6-4ce8-a4cb-f1906af9bec4"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporListeSorguCevapDVO imzaliEraporListeSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporListeSorguIstekDVO arg0)
            {

#region imzaliEraporListeSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporListeSorguCevapDVO cevap = default(imzaliEraporListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporListeSorgulaASync_Body

            }

            public static imzaliEraporListeSorguCevapDVO imzaliEraporListeSorgulaSync(Guid siteID, string userName, string password, imzaliEraporListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b752ab2a-a00c-4dfd-9661-a66bb62b0507"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporListeSorgulaSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporListeSorguCevapDVO imzaliEraporListeSorgulaSync_ServerSide(string userName, string password, imzaliEraporListeSorguIstekDVO arg0)
            {

#region imzaliEraporListeSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporListeSorguCevapDVO cevap = default(imzaliEraporListeSorguCevapDVO);
                    cevap = (imzaliEraporListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporListeSorgulaSync_Body

            }

            public static TTMessage imzaliEraporOnayASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporOnayASync_ServerSide", new Guid("b3da8c9a-241f-4d6f-9636-a248d4034eb6"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporOnayCevapDVO imzaliEraporOnayASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporOnayIstekDVO arg0)
            {

#region imzaliEraporOnayASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporOnayCevapDVO cevap = default(imzaliEraporOnayCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporOnayASync_Body

            }

            public static TTMessage imzaliEraporOnayBekleyenListeSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporOnayBekleyenListeSorguASync_ServerSide", new Guid("516c388f-e4d5-41ec-bfc0-db90836a4489"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporOnayBekleyenListeSorguCevapDVO imzaliEraporOnayBekleyenListeSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporOnayBekleyenListeSorguIstekDVO arg0)
            {

#region imzaliEraporOnayBekleyenListeSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporOnayBekleyenListeSorguCevapDVO cevap = default(imzaliEraporOnayBekleyenListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporOnayBekleyenListeSorguASync_Body

            }

            public static imzaliEraporOnayBekleyenListeSorguCevapDVO imzaliEraporOnayBekleyenListeSorguSync(Guid siteID, string userName, string password, imzaliEraporOnayBekleyenListeSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporOnayBekleyenListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("cf7739fa-1298-437a-8929-1b4650c8e937"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporOnayBekleyenListeSorguSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporOnayBekleyenListeSorguCevapDVO imzaliEraporOnayBekleyenListeSorguSync_ServerSide(string userName, string password, imzaliEraporOnayBekleyenListeSorguIstekDVO arg0)
            {

#region imzaliEraporOnayBekleyenListeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporOnayBekleyenListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporOnayBekleyenListeSorguCevapDVO cevap = default(imzaliEraporOnayBekleyenListeSorguCevapDVO);
                    cevap = (imzaliEraporOnayBekleyenListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporOnayBekleyenListeSorguSync_Body

            }

            public static TTMessage imzaliEraporOnayRedASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporOnayRedASync_ServerSide", new Guid("2da0a0fe-0737-4e92-bdbb-fa665df9b945"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporOnayRedCevapDVO imzaliEraporOnayRedASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporOnayRedIstekDVO arg0)
            {

#region imzaliEraporOnayRedASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporOnayRedCevapDVO cevap = default(imzaliEraporOnayRedCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporOnayRedASync_Body

            }

            public static imzaliEraporOnayRedCevapDVO imzaliEraporOnayRedSync(Guid siteID, string userName, string password, imzaliEraporOnayRedIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporOnayRedCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c607ca41-450a-4ee5-b82a-18ad2e139a67"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporOnayRedSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporOnayRedCevapDVO imzaliEraporOnayRedSync_ServerSide(string userName, string password, imzaliEraporOnayRedIstekDVO arg0)
            {

#region imzaliEraporOnayRedSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporOnayRed";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporOnayRedCevapDVO cevap = default(imzaliEraporOnayRedCevapDVO);
                    cevap = (imzaliEraporOnayRedCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporOnayRedSync_Body

            }

            public static imzaliEraporOnayCevapDVO imzaliEraporOnaySync(Guid siteID, string userName, string password, imzaliEraporOnayIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2bfeaf50-5dd5-4579-8dfa-2ed09e6cd93f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporOnaySync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporOnayCevapDVO imzaliEraporOnaySync_ServerSide(string userName, string password, imzaliEraporOnayIstekDVO arg0)
            {

#region imzaliEraporOnaySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporOnay";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporOnayCevapDVO cevap = default(imzaliEraporOnayCevapDVO);
                    cevap = (imzaliEraporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporOnaySync_Body

            }

            public static TTMessage imzaliEraporSilASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporSilIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporSilASync_ServerSide", new Guid("c1c41640-db95-46d6-9563-68db441ecb14"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporSilCevapDVO imzaliEraporSilASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporSilIstekDVO arg0)
            {

#region imzaliEraporSilASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporSilCevapDVO cevap = default(imzaliEraporSilCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporSilASync_Body

            }

            public static imzaliEraporSilCevapDVO imzaliEraporSilSync(Guid siteID, string userName, string password, imzaliEraporSilIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("6c913c0f-1464-4fbb-8caa-887072b4f169"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporSilSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporSilCevapDVO imzaliEraporSilSync_ServerSide(string userName, string password, imzaliEraporSilIstekDVO arg0)
            {

#region imzaliEraporSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporSilCevapDVO cevap = default(imzaliEraporSilCevapDVO);
                    cevap = (imzaliEraporSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporSilSync_Body

            }

            public static TTMessage imzaliEraporSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporSorgulaASync_ServerSide", new Guid("c87f0abd-2166-4dbe-9dbb-27d72161a4e2"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporSorguCevapDVO imzaliEraporSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporSorguIstekDVO arg0)
            {

#region imzaliEraporSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporSorguCevapDVO cevap = default(imzaliEraporSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporSorgulaASync_Body

            }

            public static imzaliEraporSorguCevapDVO imzaliEraporSorgulaSync(Guid siteID, string userName, string password, imzaliEraporSorguIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("ae34f36c-b48e-4b6c-b5f5-ee60b347e795"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporSorgulaSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporSorguCevapDVO imzaliEraporSorgulaSync_ServerSide(string userName, string password, imzaliEraporSorguIstekDVO arg0)
            {

#region imzaliEraporSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporSorguCevapDVO cevap = default(imzaliEraporSorguCevapDVO);
                    cevap = (imzaliEraporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporSorgulaSync_Body

            }

            public static TTMessage imzaliEraporTaniEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporTaniEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporTaniEkleASync_ServerSide", new Guid("efd538d9-9a9d-45cb-a8d6-849a4e2c00c6"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporTaniEkleCevapDVO imzaliEraporTaniEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporTaniEkleIstekDVO arg0)
            {

#region imzaliEraporTaniEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporTaniEkleCevapDVO cevap = default(imzaliEraporTaniEkleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporTaniEkleASync_Body

            }

            public static imzaliEraporTaniEkleCevapDVO imzaliEraporTaniEkleSync(Guid siteID, string userName, string password, imzaliEraporTaniEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1d56ea0a-2ad8-449b-9aba-662b88de3bb4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporTaniEkleSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporTaniEkleCevapDVO imzaliEraporTaniEkleSync_ServerSide(string userName, string password, imzaliEraporTaniEkleIstekDVO arg0)
            {

#region imzaliEraporTaniEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporTaniEkleCevapDVO cevap = default(imzaliEraporTaniEkleCevapDVO);
                    cevap = (imzaliEraporTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporTaniEkleSync_Body

            }

            public static TTMessage imzaliEraporTeshisEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEraporTeshisEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporTeshisEkleASync_ServerSide", new Guid("82eb6a9e-80e2-41f3-b04c-8c6112c85570"), userName, password, callerObject, arg0);
            }

            private static imzaliEraporTeshisEkleCevapDVO imzaliEraporTeshisEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEraporTeshisEkleIstekDVO arg0)
            {

#region imzaliEraporTeshisEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporTeshisEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEraporTeshisEkleCevapDVO cevap = default(imzaliEraporTeshisEkleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEraporTeshisEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { arg0 }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { arg0 }, null);

                    return cevap;
                

#endregion imzaliEraporTeshisEkleASync_Body

            }

            public static imzaliEraporTeshisEkleCevapDVO imzaliEraporTeshisEkleSync(Guid siteID, string userName, string password, imzaliEraporTeshisEkleIstekDVO arg0)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEraporTeshisEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e1152282-a3ef-4afd-a1ea-76a0811cd750"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IlacRaporuServis+WebMethods, TTObjectClasses","imzaliEraporTeshisEkleSync_ServerSide", userName, password, arg0);
            }


            private static imzaliEraporTeshisEkleCevapDVO imzaliEraporTeshisEkleSync_ServerSide(string userName, string password, imzaliEraporTeshisEkleIstekDVO arg0)
            {

#region imzaliEraporTeshisEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IlacRaporuServis";
                    header.ServiceId = "8b509241-4790-4c51-af5b-b64551ba0c6d";
                    header.MethodName = "imzaliEraporTeshisEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("arg0", (object)arg0),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEraporTeshisEkleCevapDVO cevap = default(imzaliEraporTeshisEkleCevapDVO);
                    cevap = (imzaliEraporTeshisEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEraporTeshisEkleSync_Body

            }

        }
                    
        protected IlacRaporuServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacRaporuServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacRaporuServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacRaporuServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacRaporuServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACRAPORUSERVIS", dataRow) { }
        protected IlacRaporuServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACRAPORUSERVIS", dataRow, isImported) { }
        public IlacRaporuServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacRaporuServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacRaporuServis() : base() { }

    }
}