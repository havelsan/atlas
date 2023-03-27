
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptNotification")] 

    public  partial class ReceiptNotification : TTObject
    {
        public class ReceiptNotificationList : TTObjectCollection<ReceiptNotification> { }
                    
        public class ChildReceiptNotificationCollection : TTObject.TTChildObjectCollection<ReceiptNotification>
        {
            public ChildReceiptNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage sendReceiptNotificationASync(Guid siteID, IWebMethodCallback callerObject, ItsPlainRequest ReceiptRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.ReceiptNotification+WebMethods, TTObjectClasses","sendReceiptNotificationASync_ServerSide", new Guid("12ad7b3c-be3b-4a89-b5dc-bb1254784fba"), callerObject, ReceiptRequest);
            }

            private static ItsResponse sendReceiptNotificationASync_ServerSide(IWebMethodCallback callerObject, ItsPlainRequest ReceiptRequest)
            {

#region sendReceiptNotificationASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.ReceiptNotification";
                    header.ServiceId = "5da4dafe-a8f3-45df-b3be-497fde4a82c3";
                    header.MethodName = "sendReceiptNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ReceiptRequest", (object)ReceiptRequest),
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
                            thr = callerObject.WebMethodCallback(cevap, new object[] { ReceiptRequest }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { ReceiptRequest }, null);

                    return cevap;
                

#endregion sendReceiptNotificationASync_Body

            }

            public static ItsResponse sendReceiptNotificationSync(Guid siteID, ItsPlainRequest ReceiptRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ItsResponse) TTMessageFactory.SyncCall(siteID, new Guid("c673196b-954d-4457-a79f-f3ff161539d3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.ReceiptNotification+WebMethods, TTObjectClasses","sendReceiptNotificationSync_ServerSide", ReceiptRequest);
            }


            private static ItsResponse sendReceiptNotificationSync_ServerSide(ItsPlainRequest ReceiptRequest)
            {

#region sendReceiptNotificationSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.ReceiptNotification";
                    header.ServiceId = "5da4dafe-a8f3-45df-b3be-497fde4a82c3";
                    header.MethodName = "sendReceiptNotification";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ReceiptRequest", (object)ReceiptRequest),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");

                    ItsResponse cevap = default(ItsResponse);
                    cevap = (ItsResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sendReceiptNotificationSync_Body

            }

        }
                    
        protected ReceiptNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptNotification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptNotification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptNotification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTNOTIFICATION", dataRow) { }
        protected ReceiptNotification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTNOTIFICATION", dataRow, isImported) { }
        public ReceiptNotification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptNotification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptNotification() : base() { }

    }
}