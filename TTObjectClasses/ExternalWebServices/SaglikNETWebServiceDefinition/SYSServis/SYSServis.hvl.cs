
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SYSServis")] 

    public  partial class SYSServis : TTObject
    {
        public class SYSServisList : TTObjectCollection<SYSServis> { }
                    
        public class ChildSYSServisCollection : TTObject.TTChildObjectCollection<SYSServis>
        {
            public ChildSYSServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSYSServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            /// <summary>
            /// Sağlık.Net SYS Servisi mesaj gönderim çağrısı
            /// </summary>
            public static string SYSSendMessageSync(Guid siteID, string input)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("75b23bdb-25a7-49da-a926-ae32b1e44365"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SYSServis+WebMethods, TTObjectClasses","SYSSendMessageSync_ServerSide", input);
            }


            private static string SYSSendMessageSync_ServerSide(string input)
            {

#region SYSSendMessageSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SYSServis";
                    header.ServiceId = "942f2bef-0e2a-4993-94af-7122e37e4cee";
                    header.MethodName = "SYSSendMessage";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("input", (object)input),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SYSSendMessageSync_Body

            }

        }
                    
        protected SYSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SYSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SYSServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SYSServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SYSServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYSSERVIS", dataRow) { }
        protected SYSServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYSSERVIS", dataRow, isImported) { }
        public SYSServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SYSServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SYSServis() : base() { }

    }
}