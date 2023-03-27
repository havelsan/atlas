
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TibbiMalzemeEReceteIslemleri")] 

    public  partial class TibbiMalzemeEReceteIslemleri : TTObject
    {
        public class TibbiMalzemeEReceteIslemleriList : TTObjectCollection<TibbiMalzemeEReceteIslemleri> { }
                    
        public class ChildTibbiMalzemeEReceteIslemleriCollection : TTObject.TTChildObjectCollection<TibbiMalzemeEReceteIslemleri>
        {
            public ChildTibbiMalzemeEReceteIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTibbiMalzemeEReceteIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage eReceteGirisASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eReceteGirisIstekDVO eReceteGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteGirisASync_ServerSide", new Guid("30dc3711-3ba7-4ea4-b88b-68bce993a85c"), userName, password, callerObject, eReceteGirisIstek);
            }

            private static eReceteGirisCevapDVO eReceteGirisASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eReceteGirisIstekDVO eReceteGirisIstek)
            {

#region eReceteGirisASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteGirisIstek", (object)eReceteGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eReceteGirisCevapDVO cevap = default(eReceteGirisCevapDVO);
                    
                    try
                    {
                        cevap = (eReceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eReceteGirisIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eReceteGirisIstek }, null);

                    return cevap;
                

#endregion eReceteGirisASync_Body

            }

            public static eReceteGirisCevapDVO eReceteGirisSync(Guid siteID, string userName, string password, eReceteGirisIstekDVO eReceteGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eReceteGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2c73a243-862b-4523-9402-098cc9f977bf"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteGirisSync_ServerSide", userName, password, eReceteGirisIstek);
            }


            private static eReceteGirisCevapDVO eReceteGirisSync_ServerSide(string userName, string password, eReceteGirisIstekDVO eReceteGirisIstek)
            {

#region eReceteGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteGirisIstek", (object)eReceteGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eReceteGirisCevapDVO cevap = default(eReceteGirisCevapDVO);
                    cevap = (eReceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eReceteGirisSync_Body

            }

            public static TTMessage eReceteListeSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eReceteListeSorguIstekDVO eReceteListeIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteListeSorgulaASync_ServerSide", new Guid("ca8deef7-b246-476d-b043-d88dd2c7e28e"), userName, password, callerObject, eReceteListeIstek);
            }

            private static eReceteListeSorguCevapDVO eReceteListeSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eReceteListeSorguIstekDVO eReceteListeIstek)
            {

#region eReceteListeSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteListeIstek", (object)eReceteListeIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eReceteListeSorguCevapDVO cevap = default(eReceteListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eReceteListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eReceteListeIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eReceteListeIstek }, null);

                    return cevap;
                

#endregion eReceteListeSorgulaASync_Body

            }

            public static eReceteListeSorguCevapDVO eReceteListeSorgulaSync(Guid siteID, string userName, string password, eReceteListeSorguIstekDVO eReceteListeIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eReceteListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("a6f150ee-4a22-4efc-9136-60dc79e762fc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteListeSorgulaSync_ServerSide", userName, password, eReceteListeIstek);
            }


            private static eReceteListeSorguCevapDVO eReceteListeSorgulaSync_ServerSide(string userName, string password, eReceteListeSorguIstekDVO eReceteListeIstek)
            {

#region eReceteListeSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteListeIstek", (object)eReceteListeIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eReceteListeSorguCevapDVO cevap = default(eReceteListeSorguCevapDVO);
                    cevap = (eReceteListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eReceteListeSorgulaSync_Body

            }

            public static TTMessage eReceteSilASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eReceteSorguIstekDVO eReceteSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteSilASync_ServerSide", new Guid("58f26cc1-6a13-4ad0-8337-7b1881ac8702"), userName, password, callerObject, eReceteSilIstek);
            }

            private static eReceteSilCevapDVO eReceteSilASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eReceteSorguIstekDVO eReceteSilIstek)
            {

#region eReceteSilASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteSilIstek", (object)eReceteSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eReceteSilCevapDVO cevap = default(eReceteSilCevapDVO);
                    
                    try
                    {
                        cevap = (eReceteSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eReceteSilIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eReceteSilIstek }, null);

                    return cevap;
                

#endregion eReceteSilASync_Body

            }

            public static eReceteSilCevapDVO eReceteSilSync(Guid siteID, string userName, string password, eReceteSorguIstekDVO eReceteSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eReceteSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("feabecca-6f72-4cdf-883e-541269ff4504"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteSilSync_ServerSide", userName, password, eReceteSilIstek);
            }


            private static eReceteSilCevapDVO eReceteSilSync_ServerSide(string userName, string password, eReceteSorguIstekDVO eReceteSilIstek)
            {

#region eReceteSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteSilIstek", (object)eReceteSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eReceteSilCevapDVO cevap = default(eReceteSilCevapDVO);
                    cevap = (eReceteSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eReceteSilSync_Body

            }

            public static TTMessage eReceteSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eReceteSorguIstekDVO eReceteIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteSorgulaASync_ServerSide", new Guid("8329814a-36c7-44e7-a895-835371142850"), userName, password, callerObject, eReceteIstek);
            }

            private static eReceteSorguCevapDVO eReceteSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eReceteSorguIstekDVO eReceteIstek)
            {

#region eReceteSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteIstek", (object)eReceteIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eReceteSorguCevapDVO cevap = default(eReceteSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eReceteSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eReceteIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eReceteIstek }, null);

                    return cevap;
                

#endregion eReceteSorgulaASync_Body

            }

            public static eReceteSorguCevapDVO eReceteSorgulaSync(Guid siteID, string userName, string password, eReceteSorguIstekDVO eReceteIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eReceteSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("a7e3fe93-ebba-4075-85f5-b08103221e41"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteSorgulaSync_ServerSide", userName, password, eReceteIstek);
            }


            private static eReceteSorguCevapDVO eReceteSorgulaSync_ServerSide(string userName, string password, eReceteSorguIstekDVO eReceteIstek)
            {

#region eReceteSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteIstek", (object)eReceteIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eReceteSorguCevapDVO cevap = default(eReceteSorguCevapDVO);
                    cevap = (eReceteSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eReceteSorgulaSync_Body

            }

            public static TTMessage eReceteTaniEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eReceteTaniEkleIstekDVO eReceteTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteTaniEkleASync_ServerSide", new Guid("99fb022b-9082-4d4f-89e4-c2ab823e92fc"), userName, password, callerObject, eReceteTaniEkleIstek);
            }

            private static eReceteTaniEkleCevapDVO eReceteTaniEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eReceteTaniEkleIstekDVO eReceteTaniEkleIstek)
            {

#region eReceteTaniEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteTaniEkleIstek", (object)eReceteTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eReceteTaniEkleCevapDVO cevap = default(eReceteTaniEkleCevapDVO);
                    
                    try
                    {
                        cevap = (eReceteTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eReceteTaniEkleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eReceteTaniEkleIstek }, null);

                    return cevap;
                

#endregion eReceteTaniEkleASync_Body

            }

            public static eReceteTaniEkleCevapDVO eReceteTaniEkleSync(Guid siteID, string userName, string password, eReceteTaniEkleIstekDVO eReceteTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eReceteTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("7c4c62f2-bb75-4faf-983f-19323bb8d628"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","eReceteTaniEkleSync_ServerSide", userName, password, eReceteTaniEkleIstek);
            }


            private static eReceteTaniEkleCevapDVO eReceteTaniEkleSync_ServerSide(string userName, string password, eReceteTaniEkleIstekDVO eReceteTaniEkleIstek)
            {

#region eReceteTaniEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "eReceteTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eReceteTaniEkleIstek", (object)eReceteTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eReceteTaniEkleCevapDVO cevap = default(eReceteTaniEkleCevapDVO);
                    cevap = (eReceteTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eReceteTaniEkleSync_Body

            }

            public static TTMessage imzaliEReceteGirisASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEReceteGirisIstekDVO imzaliEReceteGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteGirisASync_ServerSide", new Guid("c08e5fa7-5b1c-4bc1-ab0b-134ce9d15360"), userName, password, callerObject, imzaliEReceteGirisIstek);
            }

            private static imzaliEReceteGirisCevapDVO imzaliEReceteGirisASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEReceteGirisIstekDVO imzaliEReceteGirisIstek)
            {

#region imzaliEReceteGirisASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteGirisIstek", (object)imzaliEReceteGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEReceteGirisCevapDVO cevap = default(imzaliEReceteGirisCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEReceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteGirisIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteGirisIstek }, null);

                    return cevap;
                

#endregion imzaliEReceteGirisASync_Body

            }

            public static imzaliEReceteGirisCevapDVO imzaliEReceteGirisSync(Guid siteID, string userName, string password, imzaliEReceteGirisIstekDVO imzaliEReceteGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEReceteGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e6386737-80b5-4658-8e3c-4c910291a012"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteGirisSync_ServerSide", userName, password, imzaliEReceteGirisIstek);
            }


            private static imzaliEReceteGirisCevapDVO imzaliEReceteGirisSync_ServerSide(string userName, string password, imzaliEReceteGirisIstekDVO imzaliEReceteGirisIstek)
            {

#region imzaliEReceteGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteGirisIstek", (object)imzaliEReceteGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEReceteGirisCevapDVO cevap = default(imzaliEReceteGirisCevapDVO);
                    cevap = (imzaliEReceteGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEReceteGirisSync_Body

            }

            public static TTMessage imzaliEReceteListeSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEReceteListeSorguIstekDVO imzaliEReceteListeIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteListeSorguASync_ServerSide", new Guid("d9ba16af-c7f6-41ff-ab69-6a1a732c5587"), userName, password, callerObject, imzaliEReceteListeIstek);
            }

            private static imzaliEReceteListeSorguCevapDVO imzaliEReceteListeSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEReceteListeSorguIstekDVO imzaliEReceteListeIstek)
            {

#region imzaliEReceteListeSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteListeIstek", (object)imzaliEReceteListeIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEReceteListeSorguCevapDVO cevap = default(imzaliEReceteListeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEReceteListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteListeIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteListeIstek }, null);

                    return cevap;
                

#endregion imzaliEReceteListeSorguASync_Body

            }

            public static imzaliEReceteListeSorguCevapDVO imzaliEReceteListeSorguSync(Guid siteID, string userName, string password, imzaliEReceteListeSorguIstekDVO imzaliEReceteListeIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEReceteListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("62b1d08b-f92f-4a44-9070-fdb965fdd570"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteListeSorguSync_ServerSide", userName, password, imzaliEReceteListeIstek);
            }


            private static imzaliEReceteListeSorguCevapDVO imzaliEReceteListeSorguSync_ServerSide(string userName, string password, imzaliEReceteListeSorguIstekDVO imzaliEReceteListeIstek)
            {

#region imzaliEReceteListeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteListeIstek", (object)imzaliEReceteListeIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEReceteListeSorguCevapDVO cevap = default(imzaliEReceteListeSorguCevapDVO);
                    cevap = (imzaliEReceteListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEReceteListeSorguSync_Body

            }

            public static TTMessage imzaliEReceteSilASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEReceteSilIstekDVO imzaliEReceteSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteSilASync_ServerSide", new Guid("48b1db2c-3e3f-4a6e-9f8b-33ea2f37e780"), userName, password, callerObject, imzaliEReceteSilIstek);
            }

            private static imzaliEReceteSilCevapDVO imzaliEReceteSilASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEReceteSilIstekDVO imzaliEReceteSilIstek)
            {

#region imzaliEReceteSilASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteSilIstek", (object)imzaliEReceteSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEReceteSilCevapDVO cevap = default(imzaliEReceteSilCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEReceteSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteSilIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteSilIstek }, null);

                    return cevap;
                

#endregion imzaliEReceteSilASync_Body

            }

            public static imzaliEReceteSilCevapDVO imzaliEReceteSilSync(Guid siteID, string userName, string password, imzaliEReceteSilIstekDVO imzaliEReceteSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEReceteSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("85e5013c-a948-4d03-931a-0279589fe741"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteSilSync_ServerSide", userName, password, imzaliEReceteSilIstek);
            }


            private static imzaliEReceteSilCevapDVO imzaliEReceteSilSync_ServerSide(string userName, string password, imzaliEReceteSilIstekDVO imzaliEReceteSilIstek)
            {

#region imzaliEReceteSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteSilIstek", (object)imzaliEReceteSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEReceteSilCevapDVO cevap = default(imzaliEReceteSilCevapDVO);
                    cevap = (imzaliEReceteSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEReceteSilSync_Body

            }

            public static TTMessage imzaliEReceteSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEReceteSorguIstekDVO imzaliEReceteIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteSorguASync_ServerSide", new Guid("ae5bd1b7-3521-42f2-8b3b-2d6d9f841541"), userName, password, callerObject, imzaliEReceteIstek);
            }

            private static imzaliEReceteSorguCevapDVO imzaliEReceteSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEReceteSorguIstekDVO imzaliEReceteIstek)
            {

#region imzaliEReceteSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteIstek", (object)imzaliEReceteIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliEReceteSorguCevapDVO cevap = default(imzaliEReceteSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliEReceteSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteIstek }, null);

                    return cevap;
                

#endregion imzaliEReceteSorguASync_Body

            }

            public static imzaliEReceteSorguCevapDVO imzaliEReceteSorguSync(Guid siteID, string userName, string password, imzaliEReceteSorguIstekDVO imzaliEReceteIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliEReceteSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("13250d03-6ae6-4edb-8a70-8ad987ec8dfc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteSorguSync_ServerSide", userName, password, imzaliEReceteIstek);
            }


            private static imzaliEReceteSorguCevapDVO imzaliEReceteSorguSync_ServerSide(string userName, string password, imzaliEReceteSorguIstekDVO imzaliEReceteIstek)
            {

#region imzaliEReceteSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteIstek", (object)imzaliEReceteIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliEReceteSorguCevapDVO cevap = default(imzaliEReceteSorguCevapDVO);
                    cevap = (imzaliEReceteSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEReceteSorguSync_Body

            }

            public static TTMessage imzaliEReceteTaniEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliEReceteTaniEkleIstekDVO imzaliEReceteTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteTaniEkleASync_ServerSide", new Guid("5ec5c77b-6515-4551-bc9c-ef2c0729a2a6"), userName, password, callerObject, imzaliEReceteTaniEkleIstek);
            }

            private static eReceteTaniEkleCevapDVO imzaliEReceteTaniEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliEReceteTaniEkleIstekDVO imzaliEReceteTaniEkleIstek)
            {

#region imzaliEReceteTaniEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteTaniEkleIstek", (object)imzaliEReceteTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eReceteTaniEkleCevapDVO cevap = default(eReceteTaniEkleCevapDVO);
                    
                    try
                    {
                        cevap = (eReceteTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteTaniEkleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliEReceteTaniEkleIstek }, null);

                    return cevap;
                

#endregion imzaliEReceteTaniEkleASync_Body

            }

            public static eReceteTaniEkleCevapDVO imzaliEReceteTaniEkleSync(Guid siteID, string userName, string password, imzaliEReceteTaniEkleIstekDVO imzaliEReceteTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eReceteTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("661e589d-c3b9-462b-9db1-71fdf5b2313b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeEReceteIslemleri+WebMethods, TTObjectClasses","imzaliEReceteTaniEkleSync_ServerSide", userName, password, imzaliEReceteTaniEkleIstek);
            }


            private static eReceteTaniEkleCevapDVO imzaliEReceteTaniEkleSync_ServerSide(string userName, string password, imzaliEReceteTaniEkleIstekDVO imzaliEReceteTaniEkleIstek)
            {

#region imzaliEReceteTaniEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeEReceteIslemleri";
                    header.ServiceId = "ba47f290-8db4-418e-833d-0f06f35a1178";
                    header.MethodName = "imzaliEReceteTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliEReceteTaniEkleIstek", (object)imzaliEReceteTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eReceteTaniEkleCevapDVO cevap = default(eReceteTaniEkleCevapDVO);
                    cevap = (eReceteTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliEReceteTaniEkleSync_Body

            }

        }
                    
        protected TibbiMalzemeEReceteIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TibbiMalzemeEReceteIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TibbiMalzemeEReceteIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TibbiMalzemeEReceteIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TibbiMalzemeEReceteIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TIBBIMALZEMEERECETEISLEMLERI", dataRow) { }
        protected TibbiMalzemeEReceteIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TIBBIMALZEMEERECETEISLEMLERI", dataRow, isImported) { }
        public TibbiMalzemeEReceteIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TibbiMalzemeEReceteIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TibbiMalzemeEReceteIslemleri() : base() { }

    }
}