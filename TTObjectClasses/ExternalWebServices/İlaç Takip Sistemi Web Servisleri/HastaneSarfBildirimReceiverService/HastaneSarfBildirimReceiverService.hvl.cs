
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXXXXSarfBildirimReceiverService")] 

    /// <summary>
    /// XXXXXXSarfBildirimReceiverService
    /// </summary>
    public  partial class XXXXXXSarfBildirimReceiverService : TTObject
    {
        public class XXXXXXSarfBildirimReceiverServiceList : TTObjectCollection<XXXXXXSarfBildirimReceiverService> { }
                    
        public class ChildXXXXXXSarfBildirimReceiverServiceCollection : TTObject.TTChildObjectCollection<XXXXXXSarfBildirimReceiverService>
        {
            public ChildXXXXXXSarfBildirimReceiverServiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXXXXSarfBildirimReceiverServiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage XXXXXXSarfBildirASync(Guid siteID, IWebMethodCallback callerObject, XXXXXXSarfType XXXXXXSarfBildirim)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.XXXXXXSarfBildirimReceiverService+WebMethods, TTObjectClasses","XXXXXXSarfBildirASync_ServerSide", new Guid("52ae1dad-f6e2-4f28-8117-e3a811d6030e"), callerObject, XXXXXXSarfBildirim);
            }

            private static XXXXXXSarfCevapType XXXXXXSarfBildirASync_ServerSide(IWebMethodCallback callerObject, XXXXXXSarfType XXXXXXSarfBildirim)
            {

#region XXXXXXSarfBildirASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXSarfBildirimReceiverService";
                    header.ServiceId = "17534936-6cce-496d-ba1c-ed676bc56bcd";
                    header.MethodName = "XXXXXXSarfBildir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("XXXXXXSarfBildirim", (object)XXXXXXSarfBildirim),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");


                    XXXXXXSarfCevapType cevap = default(XXXXXXSarfCevapType);
                    
                    try
                    {
                        cevap = (XXXXXXSarfCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { XXXXXXSarfBildirim }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { XXXXXXSarfBildirim }, null);

                    return cevap;
                

#endregion XXXXXXSarfBildirASync_Body

            }

            public static XXXXXXSarfCevapType XXXXXXSarfBildirSync(Guid siteID, XXXXXXSarfType XXXXXXSarfBildirim)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (XXXXXXSarfCevapType) TTMessageFactory.SyncCall(siteID, new Guid("6954c449-f224-48a0-a381-df093d5284d6"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXSarfBildirimReceiverService+WebMethods, TTObjectClasses","XXXXXXSarfBildirSync_ServerSide", XXXXXXSarfBildirim);
            }


            private static XXXXXXSarfCevapType XXXXXXSarfBildirSync_ServerSide(XXXXXXSarfType XXXXXXSarfBildirim)
            {

#region XXXXXXSarfBildirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXSarfBildirimReceiverService";
                    header.ServiceId = "17534936-6cce-496d-ba1c-ed676bc56bcd";
                    header.MethodName = "XXXXXXSarfBildir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("XXXXXXSarfBildirim", (object)XXXXXXSarfBildirim),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");

                    XXXXXXSarfCevapType cevap = default(XXXXXXSarfCevapType);
                    cevap = (XXXXXXSarfCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXSarfBildirSync_Body

            }

        }
                    
        protected XXXXXXSarfBildirimReceiverService(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXXXXSarfBildirimReceiverService(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXXXXSarfBildirimReceiverService(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXXXXSarfBildirimReceiverService(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXXXXSarfBildirimReceiverService(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXXXXSARFBILDIRIMRECEIVERSERVICE", dataRow) { }
        protected XXXXXXSarfBildirimReceiverService(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXXXXSARFBILDIRIMRECEIVERSERVICE", dataRow, isImported) { }
        public XXXXXXSarfBildirimReceiverService(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXXXXSarfBildirimReceiverService(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXXXXSarfBildirimReceiverService() : base() { }

    }
}