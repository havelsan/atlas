
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InfluenzaServis")] 

    public  partial class InfluenzaServis : TTObject, IRestServiceObject
    {
        public class InfluenzaServisList : TTObjectCollection<InfluenzaServis> { }
                    
        public class ChildInfluenzaServisCollection : TTObject.TTChildObjectCollection<InfluenzaServis>
        {
            public ChildInfluenzaServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfluenzaServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static ServiceResult SaveInfluenzaTaniTestSync(Guid siteID, InfluenzaTaniBilgisi influenzaTaniBilgisi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ServiceResult) TTMessageFactory.SyncCall(siteID, new Guid("0a90b1c1-8f4f-4324-8d66-6bb3f3a500fe"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.InfluenzaServis+WebMethods, TTObjectClasses","SaveInfluenzaTaniTestSync_ServerSide", influenzaTaniBilgisi);
            }


            private static ServiceResult SaveInfluenzaTaniTestSync_ServerSide(InfluenzaTaniBilgisi influenzaTaniBilgisi)
            {

#region SaveInfluenzaTaniTestSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.InfluenzaServis";
                    header.ServiceId = "8d90eb51-e46d-4fc9-b558-b706fb132918";
                    header.MethodName = "SaveInfluenzaTaniTest";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("influenzaTaniBilgisi", (object)influenzaTaniBilgisi),
                    };

                    var classInstance = new InfluenzaServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    ServiceResult cevap = default(ServiceResult);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceResult>(cevapJson);
                    return cevap;

#endregion SaveInfluenzaTaniTestSync_Body

            }

        }
                    
        protected InfluenzaServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InfluenzaServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InfluenzaServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InfluenzaServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InfluenzaServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFLUENZASERVIS", dataRow) { }
        protected InfluenzaServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFLUENZASERVIS", dataRow, isImported) { }
        public InfluenzaServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InfluenzaServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InfluenzaServis() : base() { }

    }
}