
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TibbiMalzemeERaporIslemleri")] 

    public  partial class TibbiMalzemeERaporIslemleri : TTObject
    {
        public class TibbiMalzemeERaporIslemleriList : TTObjectCollection<TibbiMalzemeERaporIslemleri> { }
                    
        public class ChildTibbiMalzemeERaporIslemleriCollection : TTObject.TTChildObjectCollection<TibbiMalzemeERaporIslemleri>
        {
            public ChildTibbiMalzemeERaporIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTibbiMalzemeERaporIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage bashekimERaporOnayVeIptalASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporOnayIstekDVO eRaporBashekimOnayIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","bashekimERaporOnayVeIptalASync_ServerSide", new Guid("584e88c3-9f90-43ba-b767-d8d711c10596"), userName, password, callerObject, eRaporBashekimOnayIstek);
            }

            private static eRaporOnayCevapDVO bashekimERaporOnayVeIptalASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporOnayIstekDVO eRaporBashekimOnayIstek)
            {

#region bashekimERaporOnayVeIptalASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "bashekimERaporOnayVeIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporBashekimOnayIstek", (object)eRaporBashekimOnayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporOnayCevapDVO cevap = default(eRaporOnayCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporBashekimOnayIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporBashekimOnayIstek }, null);

                    return cevap;
                

#endregion bashekimERaporOnayVeIptalASync_Body

            }

            public static eRaporOnayCevapDVO bashekimERaporOnayVeIptalSync(Guid siteID, string userName, string password, eRaporOnayIstekDVO eRaporBashekimOnayIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("55d6275a-a05a-48c0-bb23-3b6c7a3a34f3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","bashekimERaporOnayVeIptalSync_ServerSide", userName, password, eRaporBashekimOnayIstek);
            }


            private static eRaporOnayCevapDVO bashekimERaporOnayVeIptalSync_ServerSide(string userName, string password, eRaporOnayIstekDVO eRaporBashekimOnayIstek)
            {

#region bashekimERaporOnayVeIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "bashekimERaporOnayVeIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporBashekimOnayIstek", (object)eRaporBashekimOnayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporOnayCevapDVO cevap = default(eRaporOnayCevapDVO);
                    cevap = (eRaporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion bashekimERaporOnayVeIptalSync_Body

            }

            public static TTMessage bashekimOnayiBekleyenRaporlarASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, onayBekleyenRaporIstekDVO bashekimOnayiBekleyenRaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","bashekimOnayiBekleyenRaporlarASync_ServerSide", new Guid("a6ff6360-3edf-4177-86df-761f25bc5d78"), userName, password, callerObject, bashekimOnayiBekleyenRaporIstek);
            }

            private static onayBekleyenRaporCevapDVO bashekimOnayiBekleyenRaporlarASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, onayBekleyenRaporIstekDVO bashekimOnayiBekleyenRaporIstek)
            {

#region bashekimOnayiBekleyenRaporlarASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "bashekimOnayiBekleyenRaporlar";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("bashekimOnayiBekleyenRaporIstek", (object)bashekimOnayiBekleyenRaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    onayBekleyenRaporCevapDVO cevap = default(onayBekleyenRaporCevapDVO);
                    
                    try
                    {
                        cevap = (onayBekleyenRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { bashekimOnayiBekleyenRaporIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { bashekimOnayiBekleyenRaporIstek }, null);

                    return cevap;
                

#endregion bashekimOnayiBekleyenRaporlarASync_Body

            }

            public static onayBekleyenRaporCevapDVO bashekimOnayiBekleyenRaporlarSync(Guid siteID, string userName, string password, onayBekleyenRaporIstekDVO bashekimOnayiBekleyenRaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (onayBekleyenRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("fc5b5140-3dd1-41a2-ae22-88040848d3e1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","bashekimOnayiBekleyenRaporlarSync_ServerSide", userName, password, bashekimOnayiBekleyenRaporIstek);
            }


            private static onayBekleyenRaporCevapDVO bashekimOnayiBekleyenRaporlarSync_ServerSide(string userName, string password, onayBekleyenRaporIstekDVO bashekimOnayiBekleyenRaporIstek)
            {

#region bashekimOnayiBekleyenRaporlarSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "bashekimOnayiBekleyenRaporlar";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("bashekimOnayiBekleyenRaporIstek", (object)bashekimOnayiBekleyenRaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    onayBekleyenRaporCevapDVO cevap = default(onayBekleyenRaporCevapDVO);
                    cevap = (onayBekleyenRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion bashekimOnayiBekleyenRaporlarSync_Body

            }

            public static TTMessage doktorERaporOnayVeIptalASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporOnayIstekDVO eRaporDoktorOnayIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","doktorERaporOnayVeIptalASync_ServerSide", new Guid("2ab11e6d-bf04-4eeb-ad6b-ff838d6c02c3"), userName, password, callerObject, eRaporDoktorOnayIstek);
            }

            private static eRaporOnayCevapDVO doktorERaporOnayVeIptalASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporOnayIstekDVO eRaporDoktorOnayIstek)
            {

#region doktorERaporOnayVeIptalASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "doktorERaporOnayVeIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporDoktorOnayIstek", (object)eRaporDoktorOnayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporOnayCevapDVO cevap = default(eRaporOnayCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporDoktorOnayIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporDoktorOnayIstek }, null);

                    return cevap;
                

#endregion doktorERaporOnayVeIptalASync_Body

            }

            public static eRaporOnayCevapDVO doktorERaporOnayVeIptalSync(Guid siteID, string userName, string password, eRaporOnayIstekDVO eRaporDoktorOnayIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporOnayCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("fcbcf4b8-7404-49a7-ac26-5296fedbdcf0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","doktorERaporOnayVeIptalSync_ServerSide", userName, password, eRaporDoktorOnayIstek);
            }


            private static eRaporOnayCevapDVO doktorERaporOnayVeIptalSync_ServerSide(string userName, string password, eRaporOnayIstekDVO eRaporDoktorOnayIstek)
            {

#region doktorERaporOnayVeIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "doktorERaporOnayVeIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporDoktorOnayIstek", (object)eRaporDoktorOnayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporOnayCevapDVO cevap = default(eRaporOnayCevapDVO);
                    cevap = (eRaporOnayCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion doktorERaporOnayVeIptalSync_Body

            }

            public static TTMessage doktorOnayiBekleyenRaporlarDoktorBazliSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, onayBekleyenRaporIstekDVO doktorOnayiBekleyenRaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","doktorOnayiBekleyenRaporlarDoktorBazliSorgulaASync_ServerSide", new Guid("32f4b0dd-04ff-4400-a595-f60afea484ac"), userName, password, callerObject, doktorOnayiBekleyenRaporIstek);
            }

            private static onayBekleyenRaporCevapDVO doktorOnayiBekleyenRaporlarDoktorBazliSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, onayBekleyenRaporIstekDVO doktorOnayiBekleyenRaporIstek)
            {

#region doktorOnayiBekleyenRaporlarDoktorBazliSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "doktorOnayiBekleyenRaporlarDoktorBazliSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("doktorOnayiBekleyenRaporIstek", (object)doktorOnayiBekleyenRaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    onayBekleyenRaporCevapDVO cevap = default(onayBekleyenRaporCevapDVO);
                    
                    try
                    {
                        cevap = (onayBekleyenRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { doktorOnayiBekleyenRaporIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { doktorOnayiBekleyenRaporIstek }, null);

                    return cevap;
                

#endregion doktorOnayiBekleyenRaporlarDoktorBazliSorgulaASync_Body

            }

            public static onayBekleyenRaporCevapDVO doktorOnayiBekleyenRaporlarDoktorBazliSorgulaSync(Guid siteID, string userName, string password, onayBekleyenRaporIstekDVO doktorOnayiBekleyenRaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (onayBekleyenRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d95de521-fc4c-4cb0-996f-62057c1d6422"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","doktorOnayiBekleyenRaporlarDoktorBazliSorgulaSync_ServerSide", userName, password, doktorOnayiBekleyenRaporIstek);
            }


            private static onayBekleyenRaporCevapDVO doktorOnayiBekleyenRaporlarDoktorBazliSorgulaSync_ServerSide(string userName, string password, onayBekleyenRaporIstekDVO doktorOnayiBekleyenRaporIstek)
            {

#region doktorOnayiBekleyenRaporlarDoktorBazliSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "doktorOnayiBekleyenRaporlarDoktorBazliSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("doktorOnayiBekleyenRaporIstek", (object)doktorOnayiBekleyenRaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    onayBekleyenRaporCevapDVO cevap = default(onayBekleyenRaporCevapDVO);
                    cevap = (onayBekleyenRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion doktorOnayiBekleyenRaporlarDoktorBazliSorgulaSync_Body

            }

            public static TTMessage doktorOnayiBekleyenRaporlarTesisBazliSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, onayBekleyenRaporIstekDVO doktorOnayiBekleyenTesisRaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","doktorOnayiBekleyenRaporlarTesisBazliSorgulaASync_ServerSide", new Guid("78c309fd-b2dd-43f2-8d33-41e12e4b9a1e"), userName, password, callerObject, doktorOnayiBekleyenTesisRaporIstek);
            }

            private static onayBekleyenTesisRaporCevapDVO doktorOnayiBekleyenRaporlarTesisBazliSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, onayBekleyenRaporIstekDVO doktorOnayiBekleyenTesisRaporIstek)
            {

#region doktorOnayiBekleyenRaporlarTesisBazliSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "doktorOnayiBekleyenRaporlarTesisBazliSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("doktorOnayiBekleyenTesisRaporIstek", (object)doktorOnayiBekleyenTesisRaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    onayBekleyenTesisRaporCevapDVO cevap = default(onayBekleyenTesisRaporCevapDVO);
                    
                    try
                    {
                        cevap = (onayBekleyenTesisRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { doktorOnayiBekleyenTesisRaporIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { doktorOnayiBekleyenTesisRaporIstek }, null);

                    return cevap;
                

#endregion doktorOnayiBekleyenRaporlarTesisBazliSorgulaASync_Body

            }

            public static onayBekleyenTesisRaporCevapDVO doktorOnayiBekleyenRaporlarTesisBazliSorgulaSync(Guid siteID, string userName, string password, onayBekleyenRaporIstekDVO doktorOnayiBekleyenTesisRaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (onayBekleyenTesisRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c8b9c303-0c2c-4431-859b-30c1c1477464"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","doktorOnayiBekleyenRaporlarTesisBazliSorgulaSync_ServerSide", userName, password, doktorOnayiBekleyenTesisRaporIstek);
            }


            private static onayBekleyenTesisRaporCevapDVO doktorOnayiBekleyenRaporlarTesisBazliSorgulaSync_ServerSide(string userName, string password, onayBekleyenRaporIstekDVO doktorOnayiBekleyenTesisRaporIstek)
            {

#region doktorOnayiBekleyenRaporlarTesisBazliSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "doktorOnayiBekleyenRaporlarTesisBazliSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("doktorOnayiBekleyenTesisRaporIstek", (object)doktorOnayiBekleyenTesisRaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    onayBekleyenTesisRaporCevapDVO cevap = default(onayBekleyenTesisRaporCevapDVO);
                    cevap = (onayBekleyenTesisRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion doktorOnayiBekleyenRaporlarTesisBazliSorgulaSync_Body

            }

            public static TTMessage eRaporAciklamaGuncelleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporAciklamaGuncelleIstekDVO eRaporAciklamaGuncelleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporAciklamaGuncelleASync_ServerSide", new Guid("e2fbb337-3a1a-417d-abd2-196303839153"), userName, password, callerObject, eRaporAciklamaGuncelleIstek);
            }

            private static eRaporCevapDVO eRaporAciklamaGuncelleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporAciklamaGuncelleIstekDVO eRaporAciklamaGuncelleIstek)
            {

#region eRaporAciklamaGuncelleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporAciklamaGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporAciklamaGuncelleIstek", (object)eRaporAciklamaGuncelleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporAciklamaGuncelleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporAciklamaGuncelleIstek }, null);

                    return cevap;
                

#endregion eRaporAciklamaGuncelleASync_Body

            }

            public static eRaporCevapDVO eRaporAciklamaGuncelleSync(Guid siteID, string userName, string password, eRaporAciklamaGuncelleIstekDVO eRaporAciklamaGuncelleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1fd2f777-4201-42fd-9be0-b9ae321447fd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporAciklamaGuncelleSync_ServerSide", userName, password, eRaporAciklamaGuncelleIstek);
            }


            private static eRaporCevapDVO eRaporAciklamaGuncelleSync_ServerSide(string userName, string password, eRaporAciklamaGuncelleIstekDVO eRaporAciklamaGuncelleIstek)
            {

#region eRaporAciklamaGuncelleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporAciklamaGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporAciklamaGuncelleIstek", (object)eRaporAciklamaGuncelleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eRaporAciklamaGuncelleSync_Body

            }

            public static TTMessage eRaporGirisASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporGirisIstekDVO eRaporGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporGirisASync_ServerSide", new Guid("b3b36d13-2add-438b-8d8c-151a23be0cab"), userName, password, callerObject, eRaporGirisIstek);
            }

            private static eRaporGirisCevapDVO eRaporGirisASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporGirisIstekDVO eRaporGirisIstek)
            {

#region eRaporGirisASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporGirisIstek", (object)eRaporGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporGirisCevapDVO cevap = default(eRaporGirisCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporGirisIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporGirisIstek }, null);

                    return cevap;
                

#endregion eRaporGirisASync_Body

            }

            public static eRaporGirisCevapDVO eRaporGirisSync(Guid siteID, string userName, string password, eRaporGirisIstekDVO eRaporGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("6a6054d1-dfd8-4113-b749-3600b5a205b2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporGirisSync_ServerSide", userName, password, eRaporGirisIstek);
            }


            private static eRaporGirisCevapDVO eRaporGirisSync_ServerSide(string userName, string password, eRaporGirisIstekDVO eRaporGirisIstek)
            {

#region eRaporGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporGirisIstek", (object)eRaporGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporGirisCevapDVO cevap = default(eRaporGirisCevapDVO);
                    cevap = (eRaporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eRaporGirisSync_Body

            }

            public static TTMessage eRaporListeSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporListeSorguIstekDVO eRaporSorguIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporListeSorgulaASync_ServerSide", new Guid("c2a54b92-83ae-4ca2-b600-dcc608426978"), userName, password, callerObject, eRaporSorguIstek);
            }

            private static eRaporSorguCevapDVO eRaporListeSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporListeSorguIstekDVO eRaporSorguIstek)
            {

#region eRaporListeSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporSorguIstek", (object)eRaporSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporSorguCevapDVO cevap = default(eRaporSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporSorguIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporSorguIstek }, null);

                    return cevap;
                

#endregion eRaporListeSorgulaASync_Body

            }

            public static eRaporSorguCevapDVO eRaporListeSorgulaSync(Guid siteID, string userName, string password, eRaporListeSorguIstekDVO eRaporSorguIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1aaf0325-cc9b-4fcb-9da3-9823b83126f0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporListeSorgulaSync_ServerSide", userName, password, eRaporSorguIstek);
            }


            private static eRaporSorguCevapDVO eRaporListeSorgulaSync_ServerSide(string userName, string password, eRaporListeSorguIstekDVO eRaporSorguIstek)
            {

#region eRaporListeSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporListeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporSorguIstek", (object)eRaporSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporSorguCevapDVO cevap = default(eRaporSorguCevapDVO);
                    cevap = (eRaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eRaporListeSorgulaSync_Body

            }

            public static TTMessage eRaporMalzemeEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporMalzemeEkleIstekDVO eRaporMalzemeEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporMalzemeEkleASync_ServerSide", new Guid("aef83715-c383-4dcb-85fd-ed9622eaa5af"), userName, password, callerObject, eRaporMalzemeEkleIstek);
            }

            private static eRaporCevapDVO eRaporMalzemeEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporMalzemeEkleIstekDVO eRaporMalzemeEkleIstek)
            {

#region eRaporMalzemeEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporMalzemeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporMalzemeEkleIstek", (object)eRaporMalzemeEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporMalzemeEkleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporMalzemeEkleIstek }, null);

                    return cevap;
                

#endregion eRaporMalzemeEkleASync_Body

            }

            public static eRaporCevapDVO eRaporMalzemeEkleSync(Guid siteID, string userName, string password, eRaporMalzemeEkleIstekDVO eRaporMalzemeEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9cdf0e53-3e3d-4538-a10f-d8c0c035a099"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporMalzemeEkleSync_ServerSide", userName, password, eRaporMalzemeEkleIstek);
            }


            private static eRaporCevapDVO eRaporMalzemeEkleSync_ServerSide(string userName, string password, eRaporMalzemeEkleIstekDVO eRaporMalzemeEkleIstek)
            {

#region eRaporMalzemeEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporMalzemeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporMalzemeEkleIstek", (object)eRaporMalzemeEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eRaporMalzemeEkleSync_Body

            }

            public static TTMessage eRaporSilASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporSorguIstekDVO eRaporSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporSilASync_ServerSide", new Guid("3054f37c-c9b3-4d65-905f-2723cd28bed8"), userName, password, callerObject, eRaporSilIstek);
            }

            private static eRaporCevapDVO eRaporSilASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporSorguIstekDVO eRaporSilIstek)
            {

#region eRaporSilASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporSilIstek", (object)eRaporSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporSilIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporSilIstek }, null);

                    return cevap;
                

#endregion eRaporSilASync_Body

            }

            public static eRaporCevapDVO eRaporSilSync(Guid siteID, string userName, string password, eRaporSorguIstekDVO eRaporSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f2355396-fcf3-41c9-b752-938b2ec54d18"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporSilSync_ServerSide", userName, password, eRaporSilIstek);
            }


            private static eRaporCevapDVO eRaporSilSync_ServerSide(string userName, string password, eRaporSorguIstekDVO eRaporSilIstek)
            {

#region eRaporSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporSilIstek", (object)eRaporSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eRaporSilSync_Body

            }

            public static TTMessage eRaporSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporSorguIstekDVO eRaporSorguIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporSorgulaASync_ServerSide", new Guid("e5b1ca74-5fef-48b7-b791-544299eab14c"), userName, password, callerObject, eRaporSorguIstek);
            }

            private static eRaporSorguCevapDVO eRaporSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporSorguIstekDVO eRaporSorguIstek)
            {

#region eRaporSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporSorguIstek", (object)eRaporSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporSorguCevapDVO cevap = default(eRaporSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporSorguIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporSorguIstek }, null);

                    return cevap;
                

#endregion eRaporSorgulaASync_Body

            }

            public static eRaporSorguCevapDVO eRaporSorgulaSync(Guid siteID, string userName, string password, eRaporSorguIstekDVO eRaporSorguIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("424a3890-eb1d-461d-bacb-3dcd9d1e9fbf"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporSorgulaSync_ServerSide", userName, password, eRaporSorguIstek);
            }


            private static eRaporSorguCevapDVO eRaporSorgulaSync_ServerSide(string userName, string password, eRaporSorguIstekDVO eRaporSorguIstek)
            {

#region eRaporSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporSorguIstek", (object)eRaporSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporSorguCevapDVO cevap = default(eRaporSorguCevapDVO);
                    cevap = (eRaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eRaporSorgulaSync_Body

            }

            public static TTMessage eRaporTaniEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporTaniEkleIstekDVO eRaporTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporTaniEkleASync_ServerSide", new Guid("a6667d70-7ccd-4c40-8566-41ce9f89056b"), userName, password, callerObject, eRaporTaniEkleIstek);
            }

            private static eRaporCevapDVO eRaporTaniEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporTaniEkleIstekDVO eRaporTaniEkleIstek)
            {

#region eRaporTaniEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporTaniEkleIstek", (object)eRaporTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eRaporTaniEkleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eRaporTaniEkleIstek }, null);

                    return cevap;
                

#endregion eRaporTaniEkleASync_Body

            }

            public static eRaporCevapDVO eRaporTaniEkleSync(Guid siteID, string userName, string password, eRaporTaniEkleIstekDVO eRaporTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("4338eb61-3081-4a4c-b09b-c01b4fd3508c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","eRaporTaniEkleSync_ServerSide", userName, password, eRaporTaniEkleIstek);
            }


            private static eRaporCevapDVO eRaporTaniEkleSync_ServerSide(string userName, string password, eRaporTaniEkleIstekDVO eRaporTaniEkleIstek)
            {

#region eRaporTaniEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "eRaporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eRaporTaniEkleIstek", (object)eRaporTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporCevapDVO cevap = default(eRaporCevapDVO);
                    cevap = (eRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eRaporTaniEkleSync_Body

            }

            public static TTMessage imzaliERaporAciklamaGuncelleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliERaporAciklamaGuncelleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporAciklamaGuncelleASync_ServerSide", new Guid("884aca4e-7114-4007-a63b-a03a5664f1bc"), userName, password, callerObject, imzaliERaporAciklamaGuncelleIstek);
            }

            private static imzaliERaporAciklamaGuncelleCevapDVO imzaliERaporAciklamaGuncelleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliERaporAciklamaGuncelleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {

#region imzaliERaporAciklamaGuncelleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporAciklamaGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporAciklamaGuncelleIstek", (object)imzaliERaporAciklamaGuncelleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliERaporAciklamaGuncelleCevapDVO cevap = default(imzaliERaporAciklamaGuncelleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliERaporAciklamaGuncelleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporAciklamaGuncelleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporAciklamaGuncelleIstek }, null);

                    return cevap;
                

#endregion imzaliERaporAciklamaGuncelleASync_Body

            }

            public static imzaliERaporAciklamaGuncelleCevapDVO imzaliERaporAciklamaGuncelleSync(Guid siteID, string userName, string password, imzaliERaporAciklamaGuncelleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliERaporAciklamaGuncelleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("73507a85-bb38-4d92-954f-9359b5cf4d88"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporAciklamaGuncelleSync_ServerSide", userName, password, imzaliERaporAciklamaGuncelleIstek);
            }


            private static imzaliERaporAciklamaGuncelleCevapDVO imzaliERaporAciklamaGuncelleSync_ServerSide(string userName, string password, imzaliERaporAciklamaGuncelleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {

#region imzaliERaporAciklamaGuncelleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporAciklamaGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporAciklamaGuncelleIstek", (object)imzaliERaporAciklamaGuncelleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliERaporAciklamaGuncelleCevapDVO cevap = default(imzaliERaporAciklamaGuncelleCevapDVO);
                    cevap = (imzaliERaporAciklamaGuncelleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliERaporAciklamaGuncelleSync_Body

            }

            public static TTMessage imzaliERaporGirisASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliERaporGirisIstekDVO imzaliERaporGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporGirisASync_ServerSide", new Guid("7f72f669-fc44-4dbc-8c55-b573e5603ab6"), userName, password, callerObject, imzaliERaporGirisIstek);
            }

            private static imzaliERaporGirisCevapDVO imzaliERaporGirisASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliERaporGirisIstekDVO imzaliERaporGirisIstek)
            {

#region imzaliERaporGirisASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporGirisIstek", (object)imzaliERaporGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliERaporGirisCevapDVO cevap = default(imzaliERaporGirisCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliERaporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporGirisIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporGirisIstek }, null);

                    return cevap;
                

#endregion imzaliERaporGirisASync_Body

            }

            public static imzaliERaporGirisCevapDVO imzaliERaporGirisSync(Guid siteID, string userName, string password, imzaliERaporGirisIstekDVO imzaliERaporGirisIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliERaporGirisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d122c0af-b10d-46a5-b4c5-58bf04609c4d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporGirisSync_ServerSide", userName, password, imzaliERaporGirisIstek);
            }


            private static imzaliERaporGirisCevapDVO imzaliERaporGirisSync_ServerSide(string userName, string password, imzaliERaporGirisIstekDVO imzaliERaporGirisIstek)
            {

#region imzaliERaporGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporGirisIstek", (object)imzaliERaporGirisIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliERaporGirisCevapDVO cevap = default(imzaliERaporGirisCevapDVO);
                    cevap = (imzaliERaporGirisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliERaporGirisSync_Body

            }

            public static TTMessage imzaliERaporListeSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliERaporListeSorguIstekDVO imzaliERaporListeIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporListeSorguASync_ServerSide", new Guid("cbbe3cae-b43c-496d-9e09-99c2e7883848"), userName, password, callerObject, imzaliERaporListeIstek);
            }

            private static imzaliERaporSorguCevapDVO imzaliERaporListeSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliERaporListeSorguIstekDVO imzaliERaporListeIstek)
            {

#region imzaliERaporListeSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporListeIstek", (object)imzaliERaporListeIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliERaporSorguCevapDVO cevap = default(imzaliERaporSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliERaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporListeIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporListeIstek }, null);

                    return cevap;
                

#endregion imzaliERaporListeSorguASync_Body

            }

            public static imzaliERaporSorguCevapDVO imzaliERaporListeSorguSync(Guid siteID, string userName, string password, imzaliERaporListeSorguIstekDVO imzaliERaporListeIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliERaporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("4b801685-071a-4f2d-978d-40d417cb2ff2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporListeSorguSync_ServerSide", userName, password, imzaliERaporListeIstek);
            }


            private static imzaliERaporSorguCevapDVO imzaliERaporListeSorguSync_ServerSide(string userName, string password, imzaliERaporListeSorguIstekDVO imzaliERaporListeIstek)
            {

#region imzaliERaporListeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporListeIstek", (object)imzaliERaporListeIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliERaporSorguCevapDVO cevap = default(imzaliERaporSorguCevapDVO);
                    cevap = (imzaliERaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliERaporListeSorguSync_Body

            }

            public static TTMessage imzaliERaporMalzemeEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliERaporMalzemeEkleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporMalzemeEkleASync_ServerSide", new Guid("9386f918-e3e2-4173-8861-7d9bab7c08e5"), userName, password, callerObject, imzaliERaporAciklamaGuncelleIstek);
            }

            private static imzaliERaporMalzemeEkleCevapDVO imzaliERaporMalzemeEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliERaporMalzemeEkleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {

#region imzaliERaporMalzemeEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporMalzemeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporAciklamaGuncelleIstek", (object)imzaliERaporAciklamaGuncelleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliERaporMalzemeEkleCevapDVO cevap = default(imzaliERaporMalzemeEkleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliERaporMalzemeEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporAciklamaGuncelleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporAciklamaGuncelleIstek }, null);

                    return cevap;
                

#endregion imzaliERaporMalzemeEkleASync_Body

            }

            public static imzaliERaporMalzemeEkleCevapDVO imzaliERaporMalzemeEkleSync(Guid siteID, string userName, string password, imzaliERaporMalzemeEkleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliERaporMalzemeEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("ee1669f7-5e60-4e50-a3eb-d50c0dde615d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporMalzemeEkleSync_ServerSide", userName, password, imzaliERaporAciklamaGuncelleIstek);
            }


            private static imzaliERaporMalzemeEkleCevapDVO imzaliERaporMalzemeEkleSync_ServerSide(string userName, string password, imzaliERaporMalzemeEkleIstekDVO imzaliERaporAciklamaGuncelleIstek)
            {

#region imzaliERaporMalzemeEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporMalzemeEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporAciklamaGuncelleIstek", (object)imzaliERaporAciklamaGuncelleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliERaporMalzemeEkleCevapDVO cevap = default(imzaliERaporMalzemeEkleCevapDVO);
                    cevap = (imzaliERaporMalzemeEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliERaporMalzemeEkleSync_Body

            }

            public static TTMessage imzaliERaporSilASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliERaporSilIstekDVO imzaliERaporSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporSilASync_ServerSide", new Guid("272abb9b-192a-42aa-b1da-aaa4919cad20"), userName, password, callerObject, imzaliERaporSilIstek);
            }

            private static imzaliERaporSilCevapDVO imzaliERaporSilASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliERaporSilIstekDVO imzaliERaporSilIstek)
            {

#region imzaliERaporSilASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporSilIstek", (object)imzaliERaporSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliERaporSilCevapDVO cevap = default(imzaliERaporSilCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliERaporSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporSilIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporSilIstek }, null);

                    return cevap;
                

#endregion imzaliERaporSilASync_Body

            }

            public static imzaliERaporSilCevapDVO imzaliERaporSilSync(Guid siteID, string userName, string password, imzaliERaporSilIstekDVO imzaliERaporSilIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliERaporSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b8dc8d2b-7a4f-498b-ae6a-88b8605a4427"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporSilSync_ServerSide", userName, password, imzaliERaporSilIstek);
            }


            private static imzaliERaporSilCevapDVO imzaliERaporSilSync_ServerSide(string userName, string password, imzaliERaporSilIstekDVO imzaliERaporSilIstek)
            {

#region imzaliERaporSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporSilIstek", (object)imzaliERaporSilIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliERaporSilCevapDVO cevap = default(imzaliERaporSilCevapDVO);
                    cevap = (imzaliERaporSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliERaporSilSync_Body

            }

            public static TTMessage imzaliERaporSorguASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliERaporSorguIstekDVO imzaliERaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporSorguASync_ServerSide", new Guid("37c82be3-c40d-4f55-9b8c-e3b6dab978bf"), userName, password, callerObject, imzaliERaporIstek);
            }

            private static imzaliERaporSorguCevapDVO imzaliERaporSorguASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliERaporSorguIstekDVO imzaliERaporIstek)
            {

#region imzaliERaporSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporIstek", (object)imzaliERaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliERaporSorguCevapDVO cevap = default(imzaliERaporSorguCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliERaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporIstek }, null);

                    return cevap;
                

#endregion imzaliERaporSorguASync_Body

            }

            public static imzaliERaporSorguCevapDVO imzaliERaporSorguSync(Guid siteID, string userName, string password, imzaliERaporSorguIstekDVO imzaliERaporIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliERaporSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2a1c67a4-47c0-403d-87d2-afa485fa1fa1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporSorguSync_ServerSide", userName, password, imzaliERaporIstek);
            }


            private static imzaliERaporSorguCevapDVO imzaliERaporSorguSync_ServerSide(string userName, string password, imzaliERaporSorguIstekDVO imzaliERaporIstek)
            {

#region imzaliERaporSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporIstek", (object)imzaliERaporIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliERaporSorguCevapDVO cevap = default(imzaliERaporSorguCevapDVO);
                    cevap = (imzaliERaporSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliERaporSorguSync_Body

            }

            public static TTMessage imzaliERaporTaniEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, imzaliERaporTaniEkleIstekDVO imzaliERaporTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporTaniEkleASync_ServerSide", new Guid("3f127ae9-523b-4a8f-b046-c6f0dd10b41b"), userName, password, callerObject, imzaliERaporTaniEkleIstek);
            }

            private static imzaliERaporTaniEkleCevapDVO imzaliERaporTaniEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, imzaliERaporTaniEkleIstekDVO imzaliERaporTaniEkleIstek)
            {

#region imzaliERaporTaniEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporTaniEkleIstek", (object)imzaliERaporTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    imzaliERaporTaniEkleCevapDVO cevap = default(imzaliERaporTaniEkleCevapDVO);
                    
                    try
                    {
                        cevap = (imzaliERaporTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporTaniEkleIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { imzaliERaporTaniEkleIstek }, null);

                    return cevap;
                

#endregion imzaliERaporTaniEkleASync_Body

            }

            public static imzaliERaporTaniEkleCevapDVO imzaliERaporTaniEkleSync(Guid siteID, string userName, string password, imzaliERaporTaniEkleIstekDVO imzaliERaporTaniEkleIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (imzaliERaporTaniEkleCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("6ad0e954-d7f8-4a33-9b2b-72d83374fe39"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","imzaliERaporTaniEkleSync_ServerSide", userName, password, imzaliERaporTaniEkleIstek);
            }


            private static imzaliERaporTaniEkleCevapDVO imzaliERaporTaniEkleSync_ServerSide(string userName, string password, imzaliERaporTaniEkleIstekDVO imzaliERaporTaniEkleIstek)
            {

#region imzaliERaporTaniEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "imzaliERaporTaniEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("imzaliERaporTaniEkleIstek", (object)imzaliERaporTaniEkleIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    imzaliERaporTaniEkleCevapDVO cevap = default(imzaliERaporTaniEkleCevapDVO);
                    cevap = (imzaliERaporTaniEkleCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion imzaliERaporTaniEkleSync_Body

            }

            public static TTMessage raporOnayDetayiSorgulaASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, eRaporOnayBilgisiIstekDVO raporOnayDetayIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","raporOnayDetayiSorgulaASync_ServerSide", new Guid("a2d360a8-9e17-4518-b4a3-4e056108293e"), userName, password, callerObject, raporOnayDetayIstek);
            }

            private static eRaporOnayBilgisiCevapDVO raporOnayDetayiSorgulaASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, eRaporOnayBilgisiIstekDVO raporOnayDetayIstek)
            {

#region raporOnayDetayiSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "raporOnayDetayiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporOnayDetayIstek", (object)raporOnayDetayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    eRaporOnayBilgisiCevapDVO cevap = default(eRaporOnayBilgisiCevapDVO);
                    
                    try
                    {
                        cevap = (eRaporOnayBilgisiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { raporOnayDetayIstek }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { raporOnayDetayIstek }, null);

                    return cevap;
                

#endregion raporOnayDetayiSorgulaASync_Body

            }

            public static eRaporOnayBilgisiCevapDVO raporOnayDetayiSorgulaSync(Guid siteID, string userName, string password, eRaporOnayBilgisiIstekDVO raporOnayDetayIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eRaporOnayBilgisiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("02d22941-3cee-44c7-9831-a87a0a428ee5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeERaporIslemleri+WebMethods, TTObjectClasses","raporOnayDetayiSorgulaSync_ServerSide", userName, password, raporOnayDetayIstek);
            }


            private static eRaporOnayBilgisiCevapDVO raporOnayDetayiSorgulaSync_ServerSide(string userName, string password, eRaporOnayBilgisiIstekDVO raporOnayDetayIstek)
            {

#region raporOnayDetayiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeERaporIslemleri";
                    header.ServiceId = "dae0e1a0-5eac-4c31-838f-dc52c277623d";
                    header.MethodName = "raporOnayDetayiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporOnayDetayIstek", (object)raporOnayDetayIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    eRaporOnayBilgisiCevapDVO cevap = default(eRaporOnayBilgisiCevapDVO);
                    cevap = (eRaporOnayBilgisiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporOnayDetayiSorgulaSync_Body

            }

        }
                    
        protected TibbiMalzemeERaporIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TibbiMalzemeERaporIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TibbiMalzemeERaporIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TibbiMalzemeERaporIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TibbiMalzemeERaporIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TIBBIMALZEMEERAPORISLEMLERI", dataRow) { }
        protected TibbiMalzemeERaporIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TIBBIMALZEMEERAPORISLEMLERI", dataRow, isImported) { }
        public TibbiMalzemeERaporIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TibbiMalzemeERaporIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TibbiMalzemeERaporIslemleri() : base() { }

    }
}