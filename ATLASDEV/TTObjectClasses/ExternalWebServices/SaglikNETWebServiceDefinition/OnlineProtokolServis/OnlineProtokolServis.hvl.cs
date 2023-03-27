
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OnlineProtokolServis")] 

    public  partial class OnlineProtokolServis : TTObject
    {
        public class OnlineProtokolServisList : TTObjectCollection<OnlineProtokolServis> { }
                    
        public class ChildOnlineProtokolServisCollection : TTObject.TTChildObjectCollection<OnlineProtokolServis>
        {
            public ChildOnlineProtokolServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOnlineProtokolServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static string getVersionSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("1acb3384-2779-4f4c-988a-ed39aba7c931"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OnlineProtokolServis+WebMethods, TTObjectClasses","getVersionSync_ServerSide");
            }


            private static string getVersionSync_ServerSide()
            {

#region getVersionSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OnlineProtokolServis";
                    header.ServiceId = "2aa3a5a8-215c-4271-939c-88e77a4d45b8";
                    header.MethodName = "getVersion";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion getVersionSync_Body

            }

            public static protokolListesiCevap protokolListesiSync(Guid siteID, kullanici kullaniciBilgisi, string kurum, string tarih, string otomasyonKayitID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (protokolListesiCevap) TTMessageFactory.SyncCall(siteID, new Guid("346fbd8b-2d35-44ac-bf29-65c7c5b15d2f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OnlineProtokolServis+WebMethods, TTObjectClasses","protokolListesiSync_ServerSide", kullaniciBilgisi, kurum, tarih, otomasyonKayitID);
            }


            private static protokolListesiCevap protokolListesiSync_ServerSide(kullanici kullaniciBilgisi, string kurum, string tarih, string otomasyonKayitID)
            {

#region protokolListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OnlineProtokolServis";
                    header.ServiceId = "2aa3a5a8-215c-4271-939c-88e77a4d45b8";
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
                        Tuple.Create("otomasyonKayitID", (object)otomasyonKayitID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISPASSWORD","");

                    protokolListesiCevap cevap = default(protokolListesiCevap);
                    cevap = (protokolListesiCevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion protokolListesiSync_Body

            }

            public static cevap protokolSilSync(Guid siteID, string protokolNo, int silmeNedeni, kullanici kullaniciBilgisi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (cevap) TTMessageFactory.SyncCall(siteID, new Guid("48853698-32cc-49dc-99dc-e2f04d3c32ad"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OnlineProtokolServis+WebMethods, TTObjectClasses","protokolSilSync_ServerSide", protokolNo, silmeNedeni, kullaniciBilgisi);
            }


            private static cevap protokolSilSync_ServerSide(string protokolNo, int silmeNedeni, kullanici kullaniciBilgisi)
            {

#region protokolSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OnlineProtokolServis";
                    header.ServiceId = "2aa3a5a8-215c-4271-939c-88e77a4d45b8";
                    header.MethodName = "protokolSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("protokolNo", (object)protokolNo),
                        Tuple.Create("silmeNedeni", (object)silmeNedeni),
                        Tuple.Create("kullaniciBilgisi", (object)kullaniciBilgisi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISPASSWORD","");

                    cevap cevap = default(cevap);
                    cevap = (cevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion protokolSilSync_Body

            }

            public static cevap protokolVerSync(Guid siteID, kullanici kullaniciBilgisi, protokol oProtokol)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (cevap) TTMessageFactory.SyncCall(siteID, new Guid("776f4bc1-3912-4043-b395-93541eb5ff92"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OnlineProtokolServis+WebMethods, TTObjectClasses","protokolVerSync_ServerSide", kullaniciBilgisi, oProtokol);
            }


            private static cevap protokolVerSync_ServerSide(kullanici kullaniciBilgisi, protokol oProtokol)
            {

#region protokolVerSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OnlineProtokolServis";
                    header.ServiceId = "2aa3a5a8-215c-4271-939c-88e77a4d45b8";
                    header.MethodName = "protokolVer";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kullaniciBilgisi", (object)kullaniciBilgisi),
                        Tuple.Create("oProtokol", (object)oProtokol),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ONLINEPROTOKOLSERVISPASSWORD","");

                    cevap cevap = default(cevap);
                    cevap = (cevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion protokolVerSync_Body

            }

        }
                    
        protected OnlineProtokolServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OnlineProtokolServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OnlineProtokolServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OnlineProtokolServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OnlineProtokolServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ONLINEPROTOKOLSERVIS", dataRow) { }
        protected OnlineProtokolServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ONLINEPROTOKOLSERVIS", dataRow, isImported) { }
        public OnlineProtokolServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OnlineProtokolServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OnlineProtokolServis() : base() { }

    }
}