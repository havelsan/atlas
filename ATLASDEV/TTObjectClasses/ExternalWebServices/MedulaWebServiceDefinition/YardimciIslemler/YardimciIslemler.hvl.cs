
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="YardimciIslemler")] 

    public  abstract  partial class YardimciIslemler : TTObject
    {
        public class YardimciIslemlerList : TTObjectCollection<YardimciIslemler> { }
                    
        public class ChildYardimciIslemlerCollection : TTObject.TTChildObjectCollection<YardimciIslemler>
        {
            public ChildYardimciIslemlerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildYardimciIslemlerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static ilacListesiSorguCevapDVO aktifIlacListesiSorgulaSync(Guid siteID, string userName, string password, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("43a23b45-fdc2-4022-adf8-273a6a34c77a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","aktifIlacListesiSorgulaSync_ServerSide", userName, password, ilacListesiSorguIstekDVO);
            }


            private static ilacListesiSorguCevapDVO aktifIlacListesiSorgulaSync_ServerSide(string userName, string password, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {

#region aktifIlacListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "aktifIlacListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacListesiSorguIstekDVO", (object)ilacListesiSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ilacListesiSorguCevapDVO cevap = default(ilacListesiSorguCevapDVO);
                    cevap = (ilacListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion aktifIlacListesiSorgulaSync_Body

            }

            public static TTMessage etkinMaddeListesiSorgula(Guid siteID, IWebMethodCallback callerObject, etkinMaddeListesiSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","etkinMaddeListesiSorgula_ServerSide", new Guid("e36965c0-442f-401b-ab1e-1542744dce0f"), callerObject, istekDVO);
            }

            private static etkinMaddeListesiSorguCevapDVO etkinMaddeListesiSorgula_ServerSide(IWebMethodCallback callerObject, etkinMaddeListesiSorguIstekDVO istekDVO)
            {

#region etkinMaddeListesiSorgula_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "etkinMaddeListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");


                    etkinMaddeListesiSorguCevapDVO cevap = default(etkinMaddeListesiSorguCevapDVO);
                    
                    try
                    {
                        cevap = (etkinMaddeListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
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
                

#endregion etkinMaddeListesiSorgula_Body

            }

            public static etkinMaddeListesiSorguCevapDVO etkinMaddeListesiSorgulaSync(Guid siteID, etkinMaddeListesiSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (etkinMaddeListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("456d0e58-a717-4dd9-a558-e946407e3b24"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","etkinMaddeListesiSorgulaSync_ServerSide", istekDVO);
            }


            private static etkinMaddeListesiSorguCevapDVO etkinMaddeListesiSorgulaSync_ServerSide(etkinMaddeListesiSorguIstekDVO istekDVO)
            {

#region etkinMaddeListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "etkinMaddeListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    etkinMaddeListesiSorguCevapDVO cevap = default(etkinMaddeListesiSorguCevapDVO);
                    cevap = (etkinMaddeListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion etkinMaddeListesiSorgulaSync_Body

            }

            public static etkinMaddeSutListesiSorguCevapDVO etkinMaddeSutListesiSorgulaSync(Guid siteID, etkinMaddeSutListesiSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (etkinMaddeSutListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f15f9c9a-8bb7-4ffa-afd8-b504f0e7a6d8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","etkinMaddeSutListesiSorgulaSync_ServerSide", istekDVO);
            }


            private static etkinMaddeSutListesiSorguCevapDVO etkinMaddeSutListesiSorgulaSync_ServerSide(etkinMaddeSutListesiSorguIstekDVO istekDVO)
            {

#region etkinMaddeSutListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "etkinMaddeSutListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    etkinMaddeSutListesiSorguCevapDVO cevap = default(etkinMaddeSutListesiSorguCevapDVO);
                    cevap = (etkinMaddeSutListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion etkinMaddeSutListesiSorgulaSync_Body

            }

            public static ilacListesiSorguCevapDVO kirmiziReceteIlacListesiSorgulaSync(Guid siteID, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e509c657-48c5-434e-b23d-1a66b8231dd9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","kirmiziReceteIlacListesiSorgulaSync_ServerSide", ilacListesiSorguIstekDVO);
            }


            private static ilacListesiSorguCevapDVO kirmiziReceteIlacListesiSorgulaSync_ServerSide(ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {

#region kirmiziReceteIlacListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "kirmiziReceteIlacListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacListesiSorguIstekDVO", (object)ilacListesiSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    ilacListesiSorguCevapDVO cevap = default(ilacListesiSorguCevapDVO);
                    cevap = (ilacListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kirmiziReceteIlacListesiSorgulaSync_Body

            }

            public static ilacListesiSorguCevapDVO morReceteIlacListesiSorgulaSync(Guid siteID, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1bbe327b-ac57-4cc3-b8b7-cae61e1e6bda"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","morReceteIlacListesiSorgulaSync_ServerSide", ilacListesiSorguIstekDVO);
            }


            private static ilacListesiSorguCevapDVO morReceteIlacListesiSorgulaSync_ServerSide(ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {

#region morReceteIlacListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "morReceteIlacListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacListesiSorguIstekDVO", (object)ilacListesiSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    ilacListesiSorguCevapDVO cevap = default(ilacListesiSorguCevapDVO);
                    cevap = (ilacListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion morReceteIlacListesiSorgulaSync_Body

            }

            public static ilacListesiSorguCevapDVO normalReceteIlacListesiSorgulaSync(Guid siteID, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("94cb8e2e-afd0-4019-945a-07d733e97b08"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","normalReceteIlacListesiSorgulaSync_ServerSide", ilacListesiSorguIstekDVO);
            }


            private static ilacListesiSorguCevapDVO normalReceteIlacListesiSorgulaSync_ServerSide(ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {

#region normalReceteIlacListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "normalReceteIlacListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacListesiSorguIstekDVO", (object)ilacListesiSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    ilacListesiSorguCevapDVO cevap = default(ilacListesiSorguCevapDVO);
                    cevap = (ilacListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion normalReceteIlacListesiSorgulaSync_Body

            }

            public static ilacListesiSorguCevapDVO pasifIlacListesiSorgulaSync(Guid siteID, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("26d240e0-5eb3-45a3-9473-ecab294e8b18"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","pasifIlacListesiSorgulaSync_ServerSide", ilacListesiSorguIstekDVO);
            }


            private static ilacListesiSorguCevapDVO pasifIlacListesiSorgulaSync_ServerSide(ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {

#region pasifIlacListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "pasifIlacListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacListesiSorguIstekDVO", (object)ilacListesiSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    ilacListesiSorguCevapDVO cevap = default(ilacListesiSorguCevapDVO);
                    cevap = (ilacListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion pasifIlacListesiSorgulaSync_Body

            }

            public static TTMessage raporTeshisListesiSorgula(Guid siteID, IWebMethodCallback callerObject, raporTeshisListesiSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","raporTeshisListesiSorgula_ServerSide", new Guid("ac045077-8d82-4e5d-89f4-0e7522c94596"), callerObject, istekDVO);
            }

            private static raporTeshisListesiSorguCevapDVO raporTeshisListesiSorgula_ServerSide(IWebMethodCallback callerObject, raporTeshisListesiSorguIstekDVO istekDVO)
            {

#region raporTeshisListesiSorgula_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "raporTeshisListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");


                    raporTeshisListesiSorguCevapDVO cevap = default(raporTeshisListesiSorguCevapDVO);
                    
                    try
                    {
                        cevap = (raporTeshisListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
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
                

#endregion raporTeshisListesiSorgula_Body

            }

            public static raporTeshisListesiSorguCevapDVO raporTeshisListesiSorgulaSync(Guid siteID, raporTeshisListesiSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporTeshisListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b8b098f3-1527-4fb8-b9bc-8b73c6aba559"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","raporTeshisListesiSorgulaSync_ServerSide", istekDVO);
            }


            private static raporTeshisListesiSorguCevapDVO raporTeshisListesiSorgulaSync_ServerSide(raporTeshisListesiSorguIstekDVO istekDVO)
            {

#region raporTeshisListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "raporTeshisListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    raporTeshisListesiSorguCevapDVO cevap = default(raporTeshisListesiSorguCevapDVO);
                    cevap = (raporTeshisListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporTeshisListesiSorgulaSync_Body

            }

            public static ilacListesiSorguCevapDVO turuncuReceteIlacListesiSorgulaSync(Guid siteID, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("adfe1782-6855-4cdd-915d-795981268787"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","turuncuReceteIlacListesiSorgulaSync_ServerSide", ilacListesiSorguIstekDVO);
            }


            private static ilacListesiSorguCevapDVO turuncuReceteIlacListesiSorgulaSync_ServerSide(ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {

#region turuncuReceteIlacListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "turuncuReceteIlacListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacListesiSorguIstekDVO", (object)ilacListesiSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    ilacListesiSorguCevapDVO cevap = default(ilacListesiSorguCevapDVO);
                    cevap = (ilacListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion turuncuReceteIlacListesiSorgulaSync_Body

            }

            public static ilacListesiSorguCevapDVO yesilReceteIlacListesiSorgulaSync(Guid siteID, ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b1d09a9d-f23f-493f-bcb6-512a3f4e5cbb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","yesilReceteIlacListesiSorgulaSync_ServerSide", ilacListesiSorguIstekDVO);
            }


            private static ilacListesiSorguCevapDVO yesilReceteIlacListesiSorgulaSync_ServerSide(ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO)
            {

#region yesilReceteIlacListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "yesilReceteIlacListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacListesiSorguIstekDVO", (object)ilacListesiSorguIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    ilacListesiSorguCevapDVO cevap = default(ilacListesiSorguCevapDVO);
                    cevap = (ilacListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion yesilReceteIlacListesiSorgulaSync_Body

            }

            public static etkinMaddeListesiSorguCevapDVO yurtdisiIlacEtkinMaddeListesiSorgulaSync(Guid siteID, etkinMaddeListesiSorguIstekDVO istekDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (etkinMaddeListesiSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("68d47344-f36d-4ea1-9544-7caacf011836"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.YardimciIslemler+WebMethods, TTObjectClasses","yurtdisiIlacEtkinMaddeListesiSorgulaSync_ServerSide", istekDVO);
            }


            private static etkinMaddeListesiSorguCevapDVO yurtdisiIlacEtkinMaddeListesiSorgulaSync_ServerSide(etkinMaddeListesiSorguIstekDVO istekDVO)
            {

#region yurtdisiIlacEtkinMaddeListesiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.YardimciIslemler";
                    header.ServiceId = "aa521d7a-20bf-43ff-8290-4658ff5984e0";
                    header.MethodName = "yurtdisiIlacEtkinMaddeListesiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istekDVO", (object)istekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEPASSWORD","");

                    etkinMaddeListesiSorguCevapDVO cevap = default(etkinMaddeListesiSorguCevapDVO);
                    cevap = (etkinMaddeListesiSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion yurtdisiIlacEtkinMaddeListesiSorgulaSync_Body

            }

        }
                    
        protected YardimciIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected YardimciIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected YardimciIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected YardimciIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected YardimciIslemler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "YARDIMCIISLEMLER", dataRow) { }
        protected YardimciIslemler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "YARDIMCIISLEMLER", dataRow, isImported) { }
        public YardimciIslemler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public YardimciIslemler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public YardimciIslemler() : base() { }

    }
}