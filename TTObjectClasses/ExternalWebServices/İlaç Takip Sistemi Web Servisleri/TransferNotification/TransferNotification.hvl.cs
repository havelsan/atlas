
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TransferNotification")] 

    public  partial class TransferNotification : TTObject
    {
        public class TransferNotificationList : TTObjectCollection<TransferNotification> { }
                    
        public class ChildTransferNotificationCollection : TTObject.TTChildObjectCollection<TransferNotification>
        {
            public ChildTransferNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransferNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage sendTransferNotificationASync(Guid siteID, IWebMethodCallback callerObject, ItsRequest TransferRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TransferNotification+WebMethods, TTObjectClasses","sendTransferNotificationASync_ServerSide", new Guid("5982f217-8f01-40f7-a132-be28c0716d3b"), callerObject, TransferRequest);
            }

            private static ItsResponse sendTransferNotificationASync_ServerSide(IWebMethodCallback callerObject, ItsRequest TransferRequest)
            {

#region sendTransferNotificationASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TransferNotification";
                    header.ServiceId = "1452b938-fd90-4ef7-80e1-1f7b9b08717f";
                    header.MethodName = "sendTransferNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("TransferRequest", (object)TransferRequest),
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
                            thr = callerObject.WebMethodCallback(cevap, new object[] { TransferRequest }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { TransferRequest }, null);

                    return cevap;
                

#endregion sendTransferNotificationASync_Body

            }

            public static ItsResponse sendTransferNotificationSync(Guid siteID, ItsRequest TransferRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ItsResponse) TTMessageFactory.SyncCall(siteID, new Guid("975f5b01-97a0-4f1a-9e97-c1ffb2186a97"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TransferNotification+WebMethods, TTObjectClasses","sendTransferNotificationSync_ServerSide", TransferRequest);
            }


            private static ItsResponse sendTransferNotificationSync_ServerSide(ItsRequest TransferRequest)
            {

#region sendTransferNotificationSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TransferNotification";
                    header.ServiceId = "1452b938-fd90-4ef7-80e1-1f7b9b08717f";
                    header.MethodName = "sendTransferNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("TransferRequest", (object)TransferRequest),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");

                    ItsResponse cevap = default(ItsResponse);
                    cevap = (ItsResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sendTransferNotificationSync_Body

            }

        }
                    
        protected TransferNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TransferNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TransferNotification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TransferNotification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TransferNotification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSFERNOTIFICATION", dataRow) { }
        protected TransferNotification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSFERNOTIFICATION", dataRow, isImported) { }
        public TransferNotification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TransferNotification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TransferNotification() : base() { }

    }
}