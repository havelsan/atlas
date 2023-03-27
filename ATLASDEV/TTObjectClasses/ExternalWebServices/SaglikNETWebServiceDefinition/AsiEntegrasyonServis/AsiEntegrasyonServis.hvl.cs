
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AsiEntegrasyonServis")] 

    public  partial class AsiEntegrasyonServis : TTObject
    {
        public class AsiEntegrasyonServisList : TTObjectCollection<AsiEntegrasyonServis> { }
                    
        public class ChildAsiEntegrasyonServisCollection : TTObject.TTChildObjectCollection<AsiEntegrasyonServis>
        {
            public ChildAsiEntegrasyonServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAsiEntegrasyonServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static AsiKullanilabilirlikSorgusuCikti AsiKullanilabilirlikSorgusuSync(Guid siteID, AsiKullanilabilirlikSorgusuGirdi asiKullanilabilirlikSorgusuGirdi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (AsiKullanilabilirlikSorgusuCikti) TTMessageFactory.SyncCall(siteID, new Guid("35d54a5b-9239-445d-8e36-b90aba9bccd5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.AsiEntegrasyonServis+WebMethods, TTObjectClasses","AsiKullanilabilirlikSorgusuSync_ServerSide", asiKullanilabilirlikSorgusuGirdi);
            }


            private static AsiKullanilabilirlikSorgusuCikti AsiKullanilabilirlikSorgusuSync_ServerSide(AsiKullanilabilirlikSorgusuGirdi asiKullanilabilirlikSorgusuGirdi)
            {

#region AsiKullanilabilirlikSorgusuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.AsiEntegrasyonServis";
                    header.ServiceId = "1ca4adb0-9a45-4bdd-b4d4-02acdee13f5c";
                    header.MethodName = "AsiKullanilabilirlikSorgusu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("asiKullanilabilirlikSorgusuGirdi", (object)asiKullanilabilirlikSorgusuGirdi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ASIENTEGRASYONSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ASIENTEGRASYONSERVISPASSWORD","");

                    AsiKullanilabilirlikSorgusuCikti cevap = default(AsiKullanilabilirlikSorgusuCikti);
                    cevap = (AsiKullanilabilirlikSorgusuCikti)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion AsiKullanilabilirlikSorgusuSync_Body

            }

            public static AsiUygulamaCikti AsiUygulamaSync(Guid siteID, AsiUygulamaParametre istek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (AsiUygulamaCikti) TTMessageFactory.SyncCall(siteID, new Guid("6cadd2bf-1eb3-4a2c-a6f3-7c98c7daaf39"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.AsiEntegrasyonServis+WebMethods, TTObjectClasses","AsiUygulamaSync_ServerSide", istek);
            }


            private static AsiUygulamaCikti AsiUygulamaSync_ServerSide(AsiUygulamaParametre istek)
            {

#region AsiUygulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.AsiEntegrasyonServis";
                    header.ServiceId = "1ca4adb0-9a45-4bdd-b4d4-02acdee13f5c";
                    header.MethodName = "AsiUygulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("istek", (object)istek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ASIENTEGRASYONSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ASIENTEGRASYONSERVISPASSWORD","");

                    AsiUygulamaCikti cevap = default(AsiUygulamaCikti);
                    cevap = (AsiUygulamaCikti)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion AsiUygulamaSync_Body

            }

            public static UygulamaSorgusuCikti UygulamaSorgusuSync(Guid siteID, string SorguNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (UygulamaSorgusuCikti) TTMessageFactory.SyncCall(siteID, new Guid("06f29b54-5d4f-465e-8065-2ac0ffb39072"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.AsiEntegrasyonServis+WebMethods, TTObjectClasses","UygulamaSorgusuSync_ServerSide", SorguNo);
            }


            private static UygulamaSorgusuCikti UygulamaSorgusuSync_ServerSide(string SorguNo)
            {

#region UygulamaSorgusuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.AsiEntegrasyonServis";
                    header.ServiceId = "1ca4adb0-9a45-4bdd-b4d4-02acdee13f5c";
                    header.MethodName = "UygulamaSorgusu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("SorguNo", (object)SorguNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("ASIENTEGRASYONSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("ASIENTEGRASYONSERVISPASSWORD","");

                    UygulamaSorgusuCikti cevap = default(UygulamaSorgusuCikti);
                    cevap = (UygulamaSorgusuCikti)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion UygulamaSorgusuSync_Body

            }

        }
                    
        protected AsiEntegrasyonServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AsiEntegrasyonServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AsiEntegrasyonServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AsiEntegrasyonServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AsiEntegrasyonServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ASIENTEGRASYONSERVIS", dataRow) { }
        protected AsiEntegrasyonServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ASIENTEGRASYONSERVIS", dataRow, isImported) { }
        public AsiEntegrasyonServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AsiEntegrasyonServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AsiEntegrasyonServis() : base() { }

    }
}