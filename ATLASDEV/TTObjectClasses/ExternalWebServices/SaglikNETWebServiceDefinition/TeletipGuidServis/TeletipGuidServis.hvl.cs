
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TeletipGuidServis")] 

    public  partial class TeletipGuidServis : TTObject
    {
        public class TeletipGuidServisList : TTObjectCollection<TeletipGuidServis> { }
                    
        public class ChildTeletipGuidServisCollection : TTObject.TTChildObjectCollection<TeletipGuidServis>
        {
            public ChildTeletipGuidServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeletipGuidServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static string CreateGuidWithTcNoAndAccNoSync(Guid siteID, string userName, string password, string requestingUserTcNo, string patientTcNo, string AccNo, string applicationCode)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("3651548b-4111-4a42-84fb-f4e9256cbe04"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TeletipGuidServis+WebMethods, TTObjectClasses","CreateGuidWithTcNoAndAccNoSync_ServerSide", userName, password, requestingUserTcNo, patientTcNo, AccNo, applicationCode);
            }


            private static string CreateGuidWithTcNoAndAccNoSync_ServerSide(string userName, string password, string requestingUserTcNo, string patientTcNo, string AccNo, string applicationCode)
            {

#region CreateGuidWithTcNoAndAccNoSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TeletipGuidServis";
                    header.ServiceId = "34a17710-75bf-418f-a2c9-cc5a2e2ee5f7";
                    header.MethodName = "CreateGuidWithTcNoAndAccNo";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("userName", (object)userName),
                        Tuple.Create("password", (object)password),
                        Tuple.Create("requestingUserTcNo", (object)requestingUserTcNo),
                        Tuple.Create("patientTcNo", (object)patientTcNo),
                        Tuple.Create("AccNo", (object)AccNo),
                        Tuple.Create("applicationCode", (object)applicationCode),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("TELETIPSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("TELETIPSERVISPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion CreateGuidWithTcNoAndAccNoSync_Body

            }

            public static string CreateGuidWithTcNoSync(Guid siteID, string userName, string password, string requestingUserTcNo, string patientTcNo, int numberOfUse, bool numberOfUseSpecified)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("55edeff3-8ed3-465b-ba60-9c9c244b5f6c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TeletipGuidServis+WebMethods, TTObjectClasses","CreateGuidWithTcNoSync_ServerSide", userName, password, requestingUserTcNo, patientTcNo, numberOfUse, numberOfUseSpecified);
            }


            private static string CreateGuidWithTcNoSync_ServerSide(string userName, string password, string requestingUserTcNo, string patientTcNo, int numberOfUse, bool numberOfUseSpecified)
            {

#region CreateGuidWithTcNoSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TeletipGuidServis";
                    header.ServiceId = "34a17710-75bf-418f-a2c9-cc5a2e2ee5f7";
                    header.MethodName = "CreateGuidWithTcNo";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("userName", (object)userName),
                        Tuple.Create("password", (object)password),
                        Tuple.Create("requestingUserTcNo", (object)requestingUserTcNo),
                        Tuple.Create("patientTcNo", (object)patientTcNo),
                        Tuple.Create("numberOfUse", (object)numberOfUse),
                        Tuple.Create("numberOfUseSpecified", (object)numberOfUseSpecified),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("TELETIPSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("TELETIPSERVISPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion CreateGuidWithTcNoSync_Body

            }

        }
                    
        protected TeletipGuidServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TeletipGuidServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TeletipGuidServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TeletipGuidServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TeletipGuidServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TELETIPGUIDSERVIS", dataRow) { }
        protected TeletipGuidServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TELETIPGUIDSERVIS", dataRow, isImported) { }
        public TeletipGuidServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TeletipGuidServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TeletipGuidServis() : base() { }

    }
}