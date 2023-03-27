
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReturnNotification")] 

    public  partial class ReturnNotification : TTObject
    {
        public class ReturnNotificationList : TTObjectCollection<ReturnNotification> { }
                    
        public class ChildReturnNotificationCollection : TTObject.TTChildObjectCollection<ReturnNotification>
        {
            public ChildReturnNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReturnNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage sendReturnNotificationASync(Guid siteID, IWebMethodCallback callerObject, ItsRequest ReturnRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.ReturnNotification+WebMethods, TTObjectClasses","sendReturnNotificationASync_ServerSide", new Guid("8f628220-b4b2-4f8d-a17d-7470a4525eb6"), callerObject, ReturnRequest);
            }

            private static ItsResponse sendReturnNotificationASync_ServerSide(IWebMethodCallback callerObject, ItsRequest ReturnRequest)
            {

#region sendReturnNotificationASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.ReturnNotification";
                    header.ServiceId = "161d0960-7de8-4294-8b92-223c67aaa802";
                    header.MethodName = "sendReturnNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ReturnRequest", (object)ReturnRequest),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");


                    ItsResponse cevap = default(ItsResponse);
                    
                    try
                    {
                        cevap = (ItsResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { ReturnRequest }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { ReturnRequest }, null);

                    return cevap;
                

#endregion sendReturnNotificationASync_Body

            }

            public static ItsResponse sendReturnNotificationSync(Guid siteID, ItsRequest ReturnRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ItsResponse) TTMessageFactory.SyncCall(siteID, new Guid("cd40df1a-d9b8-4aa1-af7f-d58fd6ee7b9c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.ReturnNotification+WebMethods, TTObjectClasses","sendReturnNotificationSync_ServerSide", ReturnRequest);
            }


            private static ItsResponse sendReturnNotificationSync_ServerSide(ItsRequest ReturnRequest)
            {

#region sendReturnNotificationSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.ReturnNotification";
                    header.ServiceId = "161d0960-7de8-4294-8b92-223c67aaa802";
                    header.MethodName = "sendReturnNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ReturnRequest", (object)ReturnRequest),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");

                    ItsResponse cevap = default(ItsResponse);
                    cevap = (ItsResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sendReturnNotificationSync_Body

            }

        }
                    
        protected ReturnNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReturnNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReturnNotification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReturnNotification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReturnNotification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RETURNNOTIFICATION", dataRow) { }
        protected ReturnNotification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RETURNNOTIFICATION", dataRow, isImported) { }
        public ReturnNotification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReturnNotification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReturnNotification() : base() { }

    }
}