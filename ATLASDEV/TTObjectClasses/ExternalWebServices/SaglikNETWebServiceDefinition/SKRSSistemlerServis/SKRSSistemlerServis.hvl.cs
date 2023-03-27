
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSSistemlerServis")] 

    /// <summary>
    /// SKRS Sistemler
    /// </summary>
    public  partial class SKRSSistemlerServis : TTObject
    {
        public class SKRSSistemlerServisList : TTObjectCollection<SKRSSistemlerServis> { }
                    
        public class ChildSKRSSistemlerServisCollection : TTObject.TTChildObjectCollection<SKRSSistemlerServis>
        {
            public ChildSKRSSistemlerServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSSistemlerServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage SistemKodlariASync(Guid siteID, IWebMethodCallback callerObject, string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, string kurumNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.SKRSSistemlerServis+WebMethods, TTObjectClasses","SistemKodlariASync_ServerSide", new Guid("f93caad2-ec86-416e-a475-4b60d2ab495a"), callerObject, sistemKoduInput, tarihInput, tarihInputSpecified, kurumNo);
            }

            private static kodDegerleriResponse SistemKodlariASync_ServerSide(IWebMethodCallback callerObject, string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, string kurumNo)
            {

#region SistemKodlariASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerServis";
                    header.ServiceId = "1cfd3e44-e63d-4b72-a90f-44998aa45c8e";
                    header.MethodName = "SistemKodlari";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sistemKoduInput", (object)sistemKoduInput),
                        Tuple.Create("tarihInput", (object)tarihInput),
                        Tuple.Create("tarihInputSpecified", (object)tarihInputSpecified),
                        Tuple.Create("kurumNo", (object)kurumNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");


                    kodDegerleriResponse cevap = default(kodDegerleriResponse);
                    
                    try
                    {
                        cevap = (kodDegerleriResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { sistemKoduInput, tarihInput, tarihInputSpecified, kurumNo }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { sistemKoduInput, tarihInput, tarihInputSpecified, kurumNo }, null);

                    return cevap;
                

#endregion SistemKodlariASync_Body

            }

            public static TTMessage SistemKodlariSayfaGetirASync(Guid siteID, IWebMethodCallback callerObject, string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, int skrsKod, bool skrsKodSpecified, string kurumNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.SKRSSistemlerServis+WebMethods, TTObjectClasses","SistemKodlariSayfaGetirASync_ServerSide", new Guid("6b1afb4b-90fc-48b2-85fb-416e0ffed55d"), callerObject, sistemKoduInput, tarihInput, tarihInputSpecified, skrsKod, skrsKodSpecified, kurumNo);
            }

            private static kodDegerleriResponse SistemKodlariSayfaGetirASync_ServerSide(IWebMethodCallback callerObject, string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, int skrsKod, bool skrsKodSpecified, string kurumNo)
            {

#region SistemKodlariSayfaGetirASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerServis";
                    header.ServiceId = "1cfd3e44-e63d-4b72-a90f-44998aa45c8e";
                    header.MethodName = "SistemKodlariSayfaGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sistemKoduInput", (object)sistemKoduInput),
                        Tuple.Create("tarihInput", (object)tarihInput),
                        Tuple.Create("tarihInputSpecified", (object)tarihInputSpecified),
                        Tuple.Create("skrsKod", (object)skrsKod),
                        Tuple.Create("skrsKodSpecified", (object)skrsKodSpecified),
                        Tuple.Create("kurumNo", (object)kurumNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");


                    kodDegerleriResponse cevap = default(kodDegerleriResponse);
                    
                    try
                    {
                        cevap = (kodDegerleriResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { sistemKoduInput, tarihInput, tarihInputSpecified, skrsKod, skrsKodSpecified, kurumNo }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { sistemKoduInput, tarihInput, tarihInputSpecified, skrsKod, skrsKodSpecified, kurumNo }, null);

                    return cevap;
                

#endregion SistemKodlariSayfaGetirASync_Body

            }

            public static kodDegerleriResponse SistemKodlariSayfaGetirSync(Guid siteID, string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, int skrsKod, bool skrsKodSpecified, string kurumNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kodDegerleriResponse) TTMessageFactory.SyncCall(siteID, new Guid("bc3f7ac3-a18b-468f-b382-814a3e8a74d3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerServis+WebMethods, TTObjectClasses","SistemKodlariSayfaGetirSync_ServerSide", sistemKoduInput, tarihInput, tarihInputSpecified, skrsKod, skrsKodSpecified, kurumNo);
            }


            private static kodDegerleriResponse SistemKodlariSayfaGetirSync_ServerSide(string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, int skrsKod, bool skrsKodSpecified, string kurumNo)
            {

#region SistemKodlariSayfaGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerServis";
                    header.ServiceId = "1cfd3e44-e63d-4b72-a90f-44998aa45c8e";
                    header.MethodName = "SistemKodlariSayfaGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sistemKoduInput", (object)sistemKoduInput),
                        Tuple.Create("tarihInput", (object)tarihInput),
                        Tuple.Create("tarihInputSpecified", (object)tarihInputSpecified),
                        Tuple.Create("skrsKod", (object)skrsKod),
                        Tuple.Create("skrsKodSpecified", (object)skrsKodSpecified),
                        Tuple.Create("kurumNo", (object)kurumNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    kodDegerleriResponse cevap = default(kodDegerleriResponse);
                    cevap = (kodDegerleriResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SistemKodlariSayfaGetirSync_Body

            }

            public static kodDegerleriResponse SistemKodlariSync(Guid siteID, string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, string kurumNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kodDegerleriResponse) TTMessageFactory.SyncCall(siteID, new Guid("77baa0ed-ab57-4b10-8329-6e6b3eef3e2a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerServis+WebMethods, TTObjectClasses","SistemKodlariSync_ServerSide", sistemKoduInput, tarihInput, tarihInputSpecified, kurumNo);
            }


            private static kodDegerleriResponse SistemKodlariSync_ServerSide(string sistemKoduInput, System.DateTime tarihInput, bool tarihInputSpecified, string kurumNo)
            {

#region SistemKodlariSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerServis";
                    header.ServiceId = "1cfd3e44-e63d-4b72-a90f-44998aa45c8e";
                    header.MethodName = "SistemKodlari";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sistemKoduInput", (object)sistemKoduInput),
                        Tuple.Create("tarihInput", (object)tarihInput),
                        Tuple.Create("tarihInputSpecified", (object)tarihInputSpecified),
                        Tuple.Create("kurumNo", (object)kurumNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    kodDegerleriResponse cevap = default(kodDegerleriResponse);
                    cevap = (kodDegerleriResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SistemKodlariSync_Body

            }

            public static TTMessage SistemlerASync(Guid siteID, IWebMethodCallback callerObject)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.SKRSSistemlerServis+WebMethods, TTObjectClasses","SistemlerASync_ServerSide", new Guid("eb1efdc2-f4cc-44be-b0ec-ac8f5813e42c"), callerObject);
            }

            private static wsskrsSistemlerResponse SistemlerASync_ServerSide(IWebMethodCallback callerObject)
            {

#region SistemlerASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerServis";
                    header.ServiceId = "1cfd3e44-e63d-4b72-a90f-44998aa45c8e";
                    header.MethodName = "Sistemler";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");


                    wsskrsSistemlerResponse cevap = default(wsskrsSistemlerResponse);
                    
                    try
                    {
                        cevap = (wsskrsSistemlerResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] {  }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] {  }, null);

                    return cevap;
                

#endregion SistemlerASync_Body

            }

            public static wsskrsSistemlerResponse SistemlerSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (wsskrsSistemlerResponse) TTMessageFactory.SyncCall(siteID, new Guid("23376562-a6d1-4e6e-930c-6f27a2e30ad9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerServis+WebMethods, TTObjectClasses","SistemlerSync_ServerSide");
            }


            private static wsskrsSistemlerResponse SistemlerSync_ServerSide()
            {

#region SistemlerSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerServis";
                    header.ServiceId = "1cfd3e44-e63d-4b72-a90f-44998aa45c8e";
                    header.MethodName = "Sistemler";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    wsskrsSistemlerResponse cevap = default(wsskrsSistemlerResponse);
                    cevap = (wsskrsSistemlerResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SistemlerSync_Body

            }

        }
                    
        protected SKRSSistemlerServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSSistemlerServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSSistemlerServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSSistemlerServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSSistemlerServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSSISTEMLERSERVIS", dataRow) { }
        protected SKRSSistemlerServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSSISTEMLERSERVIS", dataRow, isImported) { }
        public SKRSSistemlerServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSSistemlerServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSSistemlerServis() : base() { }

    }
}