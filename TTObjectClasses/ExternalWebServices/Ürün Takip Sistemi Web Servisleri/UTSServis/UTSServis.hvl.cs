
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UTSServis")] 

    public  partial class UTSServis : TTObject, IRestServiceObject
    {
        public class UTSServisList : TTObjectCollection<UTSServis> { }
                    
        public class ChildUTSServisCollection : TTObject.TTChildObjectCollection<UTSServis>
        {
            public ChildUTSServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUTSServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static List<UrunDetay> ButunUrunleriSorgulaSync(Guid siteID, ButunUrunleriSorgulaIstek butunUrunleriSorgulaIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (List<UrunDetay>) TTMessageFactory.SyncCall(siteID, new Guid("e61eb4f1-0c67-4098-9713-4af7d6c35321"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","ButunUrunleriSorgulaSync_ServerSide", butunUrunleriSorgulaIstek);
            }


            private static List<UrunDetay> ButunUrunleriSorgulaSync_ServerSide(ButunUrunleriSorgulaIstek butunUrunleriSorgulaIstek)
            {

#region ButunUrunleriSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "tibbiCihaz/tibbiCihazSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("butunUrunleriSorgulaIstek", (object)butunUrunleriSorgulaIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    List<UrunDetay> cevap = default(List<UrunDetay>);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UrunDetay>>(cevapJson);
                    return cevap;

#endregion ButunUrunleriSorgulaSync_Body

            }

            public static KabulEdilecekTekilUrunSorgulaCevap KabulEdilecekTekilUrunSorgulaSync(Guid siteID, KabulEdilecekTekilUrunSorgulaIstek kabulEdilecekTekilUrunSorgulaIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KabulEdilecekTekilUrunSorgulaCevap) TTMessageFactory.SyncCall(siteID, new Guid("1a3fb29c-95ea-4600-8289-d43bc86739c5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","KabulEdilecekTekilUrunSorgulaSync_ServerSide", kabulEdilecekTekilUrunSorgulaIstek);
            }


            private static KabulEdilecekTekilUrunSorgulaCevap KabulEdilecekTekilUrunSorgulaSync_ServerSide(KabulEdilecekTekilUrunSorgulaIstek kabulEdilecekTekilUrunSorgulaIstek)
            {

#region KabulEdilecekTekilUrunSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "bildirim/alma/bekleyenler/sorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kabulEdilecekTekilUrunSorgulaIstek", (object)kabulEdilecekTekilUrunSorgulaIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    KabulEdilecekTekilUrunSorgulaCevap cevap = default(KabulEdilecekTekilUrunSorgulaCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<KabulEdilecekTekilUrunSorgulaCevap>(cevapJson);
                    return cevap;

#endregion KabulEdilecekTekilUrunSorgulaSync_Body

            }

            /// <summary>
            /// Kullanım Bildirimi
            /// </summary>
            public static BildirimCevap KullanimBildirimiSync(Guid siteID, KullanimBildirimiIstek kullanimBildirimiIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (BildirimCevap) TTMessageFactory.SyncCall(siteID, new Guid("956e7a33-f8ba-4a76-a2ac-70270135e0e5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","KullanımBildirimiSync_ServerSide", kullanimBildirimiIstek);
            }


            private static BildirimCevap KullanımBildirimiSync_ServerSide(KullanimBildirimiIstek kullanimBildirimiIstek)
            {

#region KullanımBildirimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "bildirim/kullanim/ekle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kullanimBildirimiIstek", (object)kullanimBildirimiIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    BildirimCevap cevap = default(BildirimCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<BildirimCevap>(cevapJson);
                    return cevap;

#endregion KullanımBildirimiSync_Body

            }

            /// <summary>
            /// Kullanım İptal
            /// </summary>
            public static BildirimCevap KullanimIptalBildirimiSync(Guid siteID, KullanimIptalBildirimiIstek kullanimIptalBildirimiIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (BildirimCevap) TTMessageFactory.SyncCall(siteID, new Guid("d8ff7c03-7c73-4359-878b-31fdb5e2497b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","KullanımIptalBildirimiSync_ServerSide", kullanimIptalBildirimiIstek);
            }


            private static BildirimCevap KullanımIptalBildirimiSync_ServerSide(KullanimIptalBildirimiIstek kullanimIptalBildirimiIstek)
            {

#region KullanımIptalBildirimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "bildirim/kullanim/iptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kullanimIptalBildirimiIstek", (object)kullanimIptalBildirimiIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    BildirimCevap cevap = default(BildirimCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<BildirimCevap>(cevapJson);
                    return cevap;

#endregion KullanımIptalBildirimiSync_Body

            }

            public static SayiIleKabulEdilecekTekilUrunSorgulaCevap SayiIleKabulEdilecekTekilUrunSorgulaSync(Guid siteID, SayiIleKabulEdilecekTekilUrunSorgulaIstek sayiIleKabulEdilecekTekilUrunSorgulaIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (SayiIleKabulEdilecekTekilUrunSorgulaCevap) TTMessageFactory.SyncCall(siteID, new Guid("ab65cfc3-d171-4903-afd4-f9ce2a6fc162"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","SayiIleKabulEdilecekTekilUrunSorgulaSync_ServerSide", sayiIleKabulEdilecekTekilUrunSorgulaIstek);
            }


            private static SayiIleKabulEdilecekTekilUrunSorgulaCevap SayiIleKabulEdilecekTekilUrunSorgulaSync_ServerSide(SayiIleKabulEdilecekTekilUrunSorgulaIstek sayiIleKabulEdilecekTekilUrunSorgulaIstek)
            {

#region SayiIleKabulEdilecekTekilUrunSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "bildirim/alma/bekleyenler/sorgula/offset";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sayiIleKabulEdilecekTekilUrunSorgulaIstek", (object)sayiIleKabulEdilecekTekilUrunSorgulaIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    SayiIleKabulEdilecekTekilUrunSorgulaCevap cevap = default(SayiIleKabulEdilecekTekilUrunSorgulaCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<SayiIleKabulEdilecekTekilUrunSorgulaCevap>(cevapJson);
                    return cevap;

#endregion SayiIleKabulEdilecekTekilUrunSorgulaSync_Body

            }

            /// <summary>
            /// Ürün No'su ile Alma Bildirimi
            /// </summary>
            public static BildirimCevap UNOAlmaBildirimiSync(Guid siteID, UnoAlmaBildirimiIstek unoAlmaBildirimiIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (BildirimCevap) TTMessageFactory.SyncCall(siteID, new Guid("e6470660-d000-43f3-8e30-ab866f9b5e72"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","UNOAlmaBildirimiSync_ServerSide", unoAlmaBildirimiIstek);
            }


            private static BildirimCevap UNOAlmaBildirimiSync_ServerSide(UnoAlmaBildirimiIstek unoAlmaBildirimiIstek)
            {

#region UNOAlmaBildirimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "bildirim/alma/ekle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("unoAlmaBildirimiIstek", (object)unoAlmaBildirimiIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    BildirimCevap cevap = default(BildirimCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<BildirimCevap>(cevapJson);
                    return cevap;

#endregion UNOAlmaBildirimiSync_Body

            }

            /// <summary>
            /// Ürün Sorgulama Çağrısı
            /// </summary>
            public static UrunSorgulaCevap UrunSorgulaSync(Guid siteID, UrunSorgulaIstek urunSorgulaIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (UrunSorgulaCevap) TTMessageFactory.SyncCall(siteID, new Guid("edabf333-192b-4d52-afe9-fb876875fd24"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","UrunSorgulaSync_ServerSide", urunSorgulaIstek);
            }


            private static UrunSorgulaCevap UrunSorgulaSync_ServerSide(UrunSorgulaIstek urunSorgulaIstek)
            {

#region UrunSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "tibbiCihaz/urunSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("urunSorgulaIstek", (object)urunSorgulaIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    UrunSorgulaCevap cevap = default(UrunSorgulaCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<UrunSorgulaCevap>(cevapJson);
                    return cevap;

#endregion UrunSorgulaSync_Body

            }

            public static BildirimCevap VermeBildirimiSync(Guid siteID, VermeBildirimiIstek vermeBildirimiIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (BildirimCevap) TTMessageFactory.SyncCall(siteID, new Guid("4fcde7a7-fb00-4448-91ea-6eabe35c16d7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","VermeBildirimiSync_ServerSide", vermeBildirimiIstek);
            }


            private static BildirimCevap VermeBildirimiSync_ServerSide(VermeBildirimiIstek vermeBildirimiIstek)
            {

#region VermeBildirimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "bildirim/verme/ekle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("vermeBildirimiIstek", (object)vermeBildirimiIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    BildirimCevap cevap = default(BildirimCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<BildirimCevap>(cevapJson);
                    return cevap;

#endregion VermeBildirimiSync_Body

            }

            /// <summary>
            /// Verme Bildirimi ID'si ile Alma Bildirimi
            /// </summary>
            public static BildirimCevap VIDAlmaBildirimiSync(Guid siteID, VidAlmaBildirimiIstek vidAlmaBildirimiIstek)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (BildirimCevap) TTMessageFactory.SyncCall(siteID, new Guid("3b2e74cc-3b62-404a-b2cd-e2d6580f683d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.UTSServis+WebMethods, TTObjectClasses","VIDAlmaBildirimiSync_ServerSide", vidAlmaBildirimiIstek);
            }


            private static BildirimCevap VIDAlmaBildirimiSync_ServerSide(VidAlmaBildirimiIstek vidAlmaBildirimiIstek)
            {

#region VIDAlmaBildirimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.UTSServis";
                    header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                    header.MethodName = "bildirim/alma/ekle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("vidAlmaBildirimiIstek", (object)vidAlmaBildirimiIstek),
                    };

                    var classInstance = new UTSServis();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    BildirimCevap cevap = default(BildirimCevap);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<BildirimCevap>(cevapJson);
                    return cevap;

#endregion VIDAlmaBildirimiSync_Body

            }

        }
                    
        protected UTSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UTSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UTSServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UTSServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UTSServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UTSSERVIS", dataRow) { }
        protected UTSServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UTSSERVIS", dataRow, isImported) { }
        public UTSServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UTSServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UTSServis() : base() { }

    }
}