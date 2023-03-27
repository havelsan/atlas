
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvrakDokumanIslemleri")] 

    public  partial class EvrakDokumanIslemleri : TTObject
    {
        public class EvrakDokumanIslemleriList : TTObjectCollection<EvrakDokumanIslemleri> { }
                    
        public class ChildEvrakDokumanIslemleriCollection : TTObject.TTChildObjectCollection<EvrakDokumanIslemleri>
        {
            public ChildEvrakDokumanIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvrakDokumanIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage dokumanKaydetASync(Guid siteID, IWebMethodCallback callerObject, evrakDokumanKayitDVO dokumanKaydetGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.EvrakDokumanIslemleri+WebMethods, TTObjectClasses","dokumanKaydetASync_ServerSide", new Guid("d6971fa9-5fdc-43dd-a14a-807582a33b1a"), callerObject, dokumanKaydetGiris);
            }

            private static evrakDokumanKayitCevapDVO dokumanKaydetASync_ServerSide(IWebMethodCallback callerObject, evrakDokumanKayitDVO dokumanKaydetGiris)
            {

#region dokumanKaydetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EvrakDokumanIslemleri";
                    header.ServiceId = "c8480278-3666-42e1-a07b-7fee94da292c";
                    header.MethodName = "dokumanKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("dokumanKaydetGiris", (object)dokumanKaydetGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    evrakDokumanKayitCevapDVO cevap = default(evrakDokumanKayitCevapDVO);
                    
                    try
                    {
                        cevap = (evrakDokumanKayitCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { dokumanKaydetGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { dokumanKaydetGiris }, null);

                    return cevap;
                

#endregion dokumanKaydetASync_Body

            }

            public static evrakDokumanKayitCevapDVO dokumanKaydetSync(Guid siteID, evrakDokumanKayitDVO dokumanKaydetGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (evrakDokumanKayitCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("be0c2e43-5db3-4b83-954d-845cec1c22fd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EvrakDokumanIslemleri+WebMethods, TTObjectClasses","dokumanKaydetSync_ServerSide", dokumanKaydetGiris);
            }


            private static evrakDokumanKayitCevapDVO dokumanKaydetSync_ServerSide(evrakDokumanKayitDVO dokumanKaydetGiris)
            {

#region dokumanKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EvrakDokumanIslemleri";
                    header.ServiceId = "c8480278-3666-42e1-a07b-7fee94da292c";
                    header.MethodName = "dokumanKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("dokumanKaydetGiris", (object)dokumanKaydetGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    evrakDokumanKayitCevapDVO cevap = default(evrakDokumanKayitCevapDVO);
                    cevap = (evrakDokumanKayitCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion dokumanKaydetSync_Body

            }

            public static TTMessage dokumanSilASync(Guid siteID, IWebMethodCallback callerObject, evrakDokumanSilDVO dokumanSilGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.EvrakDokumanIslemleri+WebMethods, TTObjectClasses","dokumanSilASync_ServerSide", new Guid("b4ad90a7-6615-46a0-bd6b-aa641b687332"), callerObject, dokumanSilGiris);
            }

            private static evrakDokumanSilCevapDVO dokumanSilASync_ServerSide(IWebMethodCallback callerObject, evrakDokumanSilDVO dokumanSilGiris)
            {

#region dokumanSilASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EvrakDokumanIslemleri";
                    header.ServiceId = "c8480278-3666-42e1-a07b-7fee94da292c";
                    header.MethodName = "dokumanSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("dokumanSilGiris", (object)dokumanSilGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    evrakDokumanSilCevapDVO cevap = default(evrakDokumanSilCevapDVO);
                    
                    try
                    {
                        cevap = (evrakDokumanSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { dokumanSilGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { dokumanSilGiris }, null);

                    return cevap;
                

#endregion dokumanSilASync_Body

            }

            public static evrakDokumanSilCevapDVO dokumanSilSync(Guid siteID, evrakDokumanSilDVO dokumanSilGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (evrakDokumanSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e0e55b09-42ce-4ca1-9439-3e9b9d5288c9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EvrakDokumanIslemleri+WebMethods, TTObjectClasses","dokumanSilSync_ServerSide", dokumanSilGiris);
            }


            private static evrakDokumanSilCevapDVO dokumanSilSync_ServerSide(evrakDokumanSilDVO dokumanSilGiris)
            {

#region dokumanSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EvrakDokumanIslemleri";
                    header.ServiceId = "c8480278-3666-42e1-a07b-7fee94da292c";
                    header.MethodName = "dokumanSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("dokumanSilGiris", (object)dokumanSilGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    evrakDokumanSilCevapDVO cevap = default(evrakDokumanSilCevapDVO);
                    cevap = (evrakDokumanSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion dokumanSilSync_Body

            }

            public static TTMessage takipDokumanListesiASync(Guid siteID, IWebMethodCallback callerObject, evrakDokumanListesiDVO takipDokumanListesiGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.EvrakDokumanIslemleri+WebMethods, TTObjectClasses","takipDokumanListesiASync_ServerSide", new Guid("17734554-41e2-41ba-97b1-62d51f673109"), callerObject, takipDokumanListesiGiris);
            }

            private static evrakDokumanListesiCevapDVO takipDokumanListesiASync_ServerSide(IWebMethodCallback callerObject, evrakDokumanListesiDVO takipDokumanListesiGiris)
            {

#region takipDokumanListesiASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EvrakDokumanIslemleri";
                    header.ServiceId = "c8480278-3666-42e1-a07b-7fee94da292c";
                    header.MethodName = "takipDokumanListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipDokumanListesiGiris", (object)takipDokumanListesiGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    evrakDokumanListesiCevapDVO cevap = default(evrakDokumanListesiCevapDVO);
                    
                    try
                    {
                        cevap = (evrakDokumanListesiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { takipDokumanListesiGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { takipDokumanListesiGiris }, null);

                    return cevap;
                

#endregion takipDokumanListesiASync_Body

            }

            public static evrakDokumanListesiCevapDVO takipDokumanListesiSync(Guid siteID, evrakDokumanListesiDVO takipDokumanListesiGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (evrakDokumanListesiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("5b6dbf9b-bf45-44d5-b5f9-2ceb2ae5b0c5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.EvrakDokumanIslemleri+WebMethods, TTObjectClasses","takipDokumanListesiSync_ServerSide", takipDokumanListesiGiris);
            }


            private static evrakDokumanListesiCevapDVO takipDokumanListesiSync_ServerSide(evrakDokumanListesiDVO takipDokumanListesiGiris)
            {

#region takipDokumanListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.EvrakDokumanIslemleri";
                    header.ServiceId = "c8480278-3666-42e1-a07b-7fee94da292c";
                    header.MethodName = "takipDokumanListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipDokumanListesiGiris", (object)takipDokumanListesiGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    evrakDokumanListesiCevapDVO cevap = default(evrakDokumanListesiCevapDVO);
                    cevap = (evrakDokumanListesiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion takipDokumanListesiSync_Body

            }

        }
                    
        protected EvrakDokumanIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvrakDokumanIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvrakDokumanIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvrakDokumanIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvrakDokumanIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVRAKDOKUMANISLEMLERI", dataRow) { }
        protected EvrakDokumanIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVRAKDOKUMANISLEMLERI", dataRow, isImported) { }
        public EvrakDokumanIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvrakDokumanIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvrakDokumanIslemleri() : base() { }

    }
}