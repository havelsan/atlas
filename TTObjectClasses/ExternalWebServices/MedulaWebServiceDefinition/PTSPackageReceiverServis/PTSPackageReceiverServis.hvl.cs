
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PTSPackageReceiverServis")] 

    public  partial class PTSPackageReceiverServis : TTObject
    {
        public class PTSPackageReceiverServisList : TTObjectCollection<PTSPackageReceiverServis> { }
                    
        public class ChildPTSPackageReceiverServisCollection : TTObject.TTChildObjectCollection<PTSPackageReceiverServis>
        {
            public ChildPTSPackageReceiverServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPTSPackageReceiverServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static Byte[] receiveFileStream(Guid siteID, receiveFileParametersType receiveFilePT)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (Byte[]) TTMessageFactory.SyncCall(siteID, new Guid("d037354a-8b06-4ef5-88a0-9f1eb4459967"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.PTSPackageReceiverServis+WebMethods, TTObjectClasses","receiveFileStream_ServerSide", receiveFilePT);
            }


            private static Byte[] receiveFileStream_ServerSide(receiveFileParametersType receiveFilePT)
            {

#region receiveFileStream_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.PTSPackageReceiverServis";
                    header.ServiceId = "64587228-452b-4503-864c-32cc8f1596fb";
                    header.MethodName = "receiveFileStream";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("receiveFilePT", (object)receiveFilePT),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ITSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ITSPASSWORD","");

                    Byte[] cevap = default(Byte[]);
                    cevap = (Byte[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion receiveFileStream_Body

            }

        }
                    
        protected PTSPackageReceiverServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PTSPackageReceiverServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PTSPackageReceiverServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PTSPackageReceiverServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PTSPackageReceiverServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PTSPACKAGERECEIVERSERVIS", dataRow) { }
        protected PTSPackageReceiverServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PTSPACKAGERECEIVERSERVIS", dataRow, isImported) { }
        public PTSPackageReceiverServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PTSPackageReceiverServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PTSPackageReceiverServis() : base() { }

    }
}