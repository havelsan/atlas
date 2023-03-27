
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TITUBBUrunServis")] 

    public  partial class TITUBBUrunServis : TTObject
    {
        public class TITUBBUrunServisList : TTObjectCollection<TITUBBUrunServis> { }
                    
        public class ChildTITUBBUrunServisCollection : TTObject.TTChildObjectCollection<TITUBBUrunServis>
        {
            public ChildTITUBBUrunServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTITUBBUrunServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static ProductServiceResult GetUrunSync(Guid siteID, string userName, string password, string barkod)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ProductServiceResult) TTMessageFactory.SyncCall(siteID, new Guid("a7d81162-de58-4a41-ac60-90ca79ea0aa3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TITUBBUrunServis+WebMethods, TTObjectClasses","GetUrunSync_ServerSide", userName, password, barkod);
            }


            private static ProductServiceResult GetUrunSync_ServerSide(string userName, string password, string barkod)
            {

#region GetUrunSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TITUBBUrunServis";
                    header.ServiceId = "c764809d-3485-4073-8563-e0380d22ffe3";
                    header.MethodName = "GetUrun";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("barkod", (object)barkod),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ProductServiceResult cevap = default(ProductServiceResult);
                    cevap = (ProductServiceResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetUrunSync_Body

            }

        }
                    
        protected TITUBBUrunServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TITUBBUrunServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TITUBBUrunServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TITUBBUrunServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TITUBBUrunServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TITUBBURUNSERVIS", dataRow) { }
        protected TITUBBUrunServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TITUBBURUNSERVIS", dataRow, isImported) { }
        public TITUBBUrunServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TITUBBUrunServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TITUBBUrunServis() : base() { }

    }
}