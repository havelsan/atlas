
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtokolIslemleri")] 

    /// <summary>
    /// Sağlık Net Protokol İşlemleri
    /// </summary>
    public  abstract  partial class ProtokolIslemleri : TTObject
    {
        public class ProtokolIslemleriList : TTObjectCollection<ProtokolIslemleri> { }
                    
        public class ChildProtokolIslemleriCollection : TTObject.TTChildObjectCollection<ProtokolIslemleri>
        {
            public ChildProtokolIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtokolIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static protokolListesiCevap protokolListesiSync(Guid siteID, kullanici kullaniciBilgisi, int kurum, DateTime tarih)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (protokolListesiCevap) TTMessageFactory.SyncCall(siteID, new Guid("5ba4bd4e-f7d3-4ff5-8d6d-d800a240d900"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.ProtokolIslemleri+WebMethods, TTObjectClasses","protokolListesiSync_ServerSide", kullaniciBilgisi, kurum, tarih);
            }


            private static protokolListesiCevap protokolListesiSync_ServerSide(kullanici kullaniciBilgisi, int kurum, DateTime tarih)
            {

#region protokolListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.ProtokolIslemleri";
                    header.ServiceId = "abdde29f-cc1a-49d2-bef5-86e9b13dac01";
                    header.MethodName = "protokolListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kullaniciBilgisi", (object)kullaniciBilgisi),
                        Tuple.Create("kurum", (object)kurum),
                        Tuple.Create("tarih", (object)tarih),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MEDULAUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MEDULAPASSWORD"];

                    protokolListesiCevap cevap = default(protokolListesiCevap);
                    cevap = (protokolListesiCevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion protokolListesiSync_Body

            }

            public static cevap protokolSilSync(Guid siteID, string protokolNo, int silmeNedeni, kullanici kullanici)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (cevap) TTMessageFactory.SyncCall(siteID, new Guid("28c1b47b-a86b-4b2a-820b-48133ac1599e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.ProtokolIslemleri+WebMethods, TTObjectClasses","protokolSilSync_ServerSide", protokolNo, silmeNedeni, kullanici);
            }


            private static cevap protokolSilSync_ServerSide(string protokolNo, int silmeNedeni, kullanici kullanici)
            {

#region protokolSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.ProtokolIslemleri";
                    header.ServiceId = "abdde29f-cc1a-49d2-bef5-86e9b13dac01";
                    header.MethodName = "protokolSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("protokolNo", (object)protokolNo),
                        Tuple.Create("silmeNedeni", (object)silmeNedeni),
                        Tuple.Create("kullanici", (object)kullanici),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MEDULAUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MEDULAPASSWORD"];

                    cevap cevap = default(cevap);
                    cevap = (cevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion protokolSilSync_Body

            }

            public static cevap protokolVerSync(Guid siteID, kullanici kullanici, protokol protokol)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (cevap) TTMessageFactory.SyncCall(siteID, new Guid("d8c5f98e-994c-4b39-8881-dc972683febb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.ProtokolIslemleri+WebMethods, TTObjectClasses","protokolVerSync_ServerSide", kullanici, protokol);
            }


            private static cevap protokolVerSync_ServerSide(kullanici kullanici, protokol protokol)
            {

#region protokolVerSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.ProtokolIslemleri";
                    header.ServiceId = "abdde29f-cc1a-49d2-bef5-86e9b13dac01";
                    header.MethodName = "protokolVer";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kullanici", (object)kullanici),
                        Tuple.Create("protokol", (object)protokol),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["SAGLIKNETKULLANICIADI"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["SAGLIKNETKULLANICISIFRESI"];

                    cevap cevap = default(cevap);
                    cevap = (cevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion protokolVerSync_Body

            }

        }
                    
        protected ProtokolIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtokolIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtokolIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtokolIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtokolIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOKOLISLEMLERI", dataRow) { }
        protected ProtokolIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOKOLISLEMLERI", dataRow, isImported) { }
        public ProtokolIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtokolIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtokolIslemleri() : base() { }

    }
}