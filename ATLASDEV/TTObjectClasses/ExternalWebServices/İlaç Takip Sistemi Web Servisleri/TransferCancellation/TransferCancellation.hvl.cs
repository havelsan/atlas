
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TransferCancellation")] 

    public  partial class TransferCancellation : TTObject
    {
        public class TransferCancellationList : TTObjectCollection<TransferCancellation> { }
                    
        public class ChildTransferCancellationCollection : TTObject.TTChildObjectCollection<TransferCancellation>
        {
            public ChildTransferCancellationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransferCancellationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage sendTransferCancellationASync(Guid siteID, IWebMethodCallback callerObject, ItsPlainRequest TransferCancellationRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TransferCancellation+WebMethods, TTObjectClasses","sendTransferCancellationASync_ServerSide", new Guid("d4fb847d-06b1-43d9-b5d6-39466fcfed8c"), callerObject, TransferCancellationRequest);
            }

            private static ItsResponse sendTransferCancellationASync_ServerSide(IWebMethodCallback callerObject, ItsPlainRequest TransferCancellationRequest)
            {

#region sendTransferCancellationASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TransferCancellation";
                    header.ServiceId = "28f1ce51-8f6c-4428-8d36-3fef16f413a7";
                    header.MethodName = "sendTransferCancellation";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("TransferCancellationRequest", (object)TransferCancellationRequest),
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
                            thr = callerObject.WebMethodCallback(cevap, new object[] { TransferCancellationRequest }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { TransferCancellationRequest }, null);

                    return cevap;
                

#endregion sendTransferCancellationASync_Body

            }

            public static ItsResponse sendTransferCancellationSync(Guid siteID, ItsPlainRequest TransferCancellationRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ItsResponse) TTMessageFactory.SyncCall(siteID, new Guid("b30fae56-92ac-4769-8f3f-faee509065a2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TransferCancellation+WebMethods, TTObjectClasses","sendTransferCancellationSync_ServerSide", TransferCancellationRequest);
            }


            private static ItsResponse sendTransferCancellationSync_ServerSide(ItsPlainRequest TransferCancellationRequest)
            {

#region sendTransferCancellationSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TransferCancellation";
                    header.ServiceId = "28f1ce51-8f6c-4428-8d36-3fef16f413a7";
                    header.MethodName = "sendTransferCancellation";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("TransferCancellationRequest", (object)TransferCancellationRequest),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");

                    ItsResponse cevap = default(ItsResponse);
                    cevap = (ItsResponse)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sendTransferCancellationSync_Body

            }

        }
                    
        protected TransferCancellation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TransferCancellation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TransferCancellation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TransferCancellation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TransferCancellation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSFERCANCELLATION", dataRow) { }
        protected TransferCancellation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSFERCANCELLATION", dataRow, isImported) { }
        public TransferCancellation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TransferCancellation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TransferCancellation() : base() { }

    }
}