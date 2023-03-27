
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CheckStatusNotification")] 

    public  partial class CheckStatusNotification : TTObject
    {
        public class CheckStatusNotificationList : TTObjectCollection<CheckStatusNotification> { }
                    
        public class ChildCheckStatusNotificationCollection : TTObject.TTChildObjectCollection<CheckStatusNotification>
        {
            public ChildCheckStatusNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCheckStatusNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage sendCheckStatusNotificationASync(Guid siteID, IWebMethodCallback callerObject, ItsPlainRequest QueryRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.CheckStatusNotification+WebMethods, TTObjectClasses","sendCheckStatusNotificationASync_ServerSide", new Guid("d6f015de-a6af-46d7-b103-067c24f47df7"), callerObject, QueryRequest);
            }

            private static ItsResponse sendCheckStatusNotificationASync_ServerSide(IWebMethodCallback callerObject, ItsPlainRequest QueryRequest)
            {

#region sendCheckStatusNotificationASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.CheckStatusNotification";
                    header.ServiceId = "450aaefa-748e-4ec3-8940-2caa678963cf";
                    header.MethodName = "sendCheckStatusNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("QueryRequest", (object)QueryRequest),
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
                            thr = callerObject.WebMethodCallback(cevap, new object[] { QueryRequest }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { QueryRequest }, null);

                    return cevap;
                

#endregion sendCheckStatusNotificationASync_Body

            }

            public static ItsResponse sendCheckStatusNotificationSync(Guid siteID, ItsPlainRequest QueryRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ItsResponse) TTMessageFactory.SyncCall(siteID, new Guid("2872a816-5844-4e41-9b61-4a81c6597e6d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.CheckStatusNotification+WebMethods, TTObjectClasses","sendCheckStatusNotificationSync_ServerSide", QueryRequest);
            }


            private static ItsResponse sendCheckStatusNotificationSync_ServerSide(ItsPlainRequest QueryRequest)
            {

#region sendCheckStatusNotificationSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.CheckStatusNotification";
                    header.ServiceId = "450aaefa-748e-4ec3-8940-2caa678963cf";
                    header.MethodName = "sendCheckStatusNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("QueryRequest", (object)QueryRequest),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");

                    ItsResponse cevap = default(ItsResponse);
                    cevap = (ItsResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sendCheckStatusNotificationSync_Body

            }

        }
                    
        protected CheckStatusNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CheckStatusNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CheckStatusNotification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CheckStatusNotification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CheckStatusNotification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHECKSTATUSNOTIFICATION", dataRow) { }
        protected CheckStatusNotification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHECKSTATUSNOTIFICATION", dataRow, isImported) { }
        public CheckStatusNotification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CheckStatusNotification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CheckStatusNotification() : base() { }

    }
}