
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugServis")] 

    public  partial class DrugServis : TTObject
    {
        public class DrugServisList : TTObjectCollection<DrugServis> { }
                    
        public class ChildDrugServisCollection : TTObject.TTChildObjectCollection<DrugServis>
        {
            public ChildDrugServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static ATC[] XXXXXXGetAtcListSync(Guid siteID, string userName, string password, System.Nullable<int> AtcId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ATC[]) TTMessageFactory.SyncCall(siteID, new Guid("cda8c212-4bb5-49b5-93d7-7e54f35b3f28"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetAtcListSync_ServerSide", userName, password, AtcId);
            }


            private static ATC[] XXXXXXGetAtcListSync_ServerSide(string userName, string password, System.Nullable<int> AtcId)
            {

#region XXXXXXGetAtcListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetAtcList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("AtcId", (object)AtcId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ATC[] cevap = default(ATC[]);
                    cevap = (ATC[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetAtcListSync_Body

            }

            public static Etken_Madde[] XXXXXXGetEtkenMaddeListSync(Guid siteID, string userName, string password, System.Nullable<int> EtkenMaddeId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Etken_Madde[]) TTMessageFactory.SyncCall(siteID, new Guid("98254d2f-2995-4897-94bd-b9b804624f65"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetEtkenMaddeListSync_ServerSide", userName, password, EtkenMaddeId);
            }


            private static Etken_Madde[] XXXXXXGetEtkenMaddeListSync_ServerSide(string userName, string password, System.Nullable<int> EtkenMaddeId)
            {

#region XXXXXXGetEtkenMaddeListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetEtkenMaddeList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("EtkenMaddeId", (object)EtkenMaddeId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    Etken_Madde[] cevap = default(Etken_Madde[]);
                    cevap = (Etken_Madde[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetEtkenMaddeListSync_Body

            }

            public static FarmasotikSekil[] XXXXXXGetFarmasotikSekilListSync(Guid siteID, string userName, string password, System.Nullable<int> FarmasotikSekilId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (FarmasotikSekil[]) TTMessageFactory.SyncCall(siteID, new Guid("afe33340-83b6-4eea-8793-a0628dee9a9f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetFarmasotikSekilListSync_ServerSide", userName, password, FarmasotikSekilId);
            }


            private static FarmasotikSekil[] XXXXXXGetFarmasotikSekilListSync_ServerSide(string userName, string password, System.Nullable<int> FarmasotikSekilId)
            {

#region XXXXXXGetFarmasotikSekilListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetFarmasotikSekilList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("FarmasotikSekilId", (object)FarmasotikSekilId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    FarmasotikSekil[] cevap = default(FarmasotikSekil[]);
                    cevap = (FarmasotikSekil[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetFarmasotikSekilListSync_Body

            }

            public static Listeler[] XXXXXXGetListelerListSync(Guid siteID, string userName, string password, System.Nullable<long> ListelerId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Listeler[]) TTMessageFactory.SyncCall(siteID, new Guid("95b65559-7d3b-4673-8259-accea54a1c70"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetListelerListSync_ServerSide", userName, password, ListelerId);
            }


            private static Listeler[] XXXXXXGetListelerListSync_ServerSide(string userName, string password, System.Nullable<long> ListelerId)
            {

#region XXXXXXGetListelerListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetListelerList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ListelerId", (object)ListelerId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    Listeler[] cevap = default(Listeler[]);
                    cevap = (Listeler[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetListelerListSync_Body

            }

            public static Urun_Bilgisi[] XXXXXXGetUrun_BilgisiListSync(Guid siteID, string userName, string password, System.Nullable<long> Urun_Bilgisi_ID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Urun_Bilgisi[]) TTMessageFactory.SyncCall(siteID, new Guid("1b786a09-d580-4693-848a-40798dedaa03"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetUrun_BilgisiListSync_ServerSide", userName, password, Urun_Bilgisi_ID);
            }


            private static Urun_Bilgisi[] XXXXXXGetUrun_BilgisiListSync_ServerSide(string userName, string password, System.Nullable<long> Urun_Bilgisi_ID)
            {

#region XXXXXXGetUrun_BilgisiListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetUrun_BilgisiList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Urun_Bilgisi_ID", (object)Urun_Bilgisi_ID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    Urun_Bilgisi[] cevap = default(Urun_Bilgisi[]);
                    cevap = (Urun_Bilgisi[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetUrun_BilgisiListSync_Body

            }

            public static Urun_EtkenMadde[] XXXXXXGetUrun_EtkenMaddeListSync(Guid siteID, string userName, string password, System.Nullable<long> Urun_Bilgisi_ID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Urun_EtkenMadde[]) TTMessageFactory.SyncCall(siteID, new Guid("269d799f-4e46-45eb-bd9c-27b2b68bcb1e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetUrun_EtkenMaddeListSync_ServerSide", userName, password, Urun_Bilgisi_ID);
            }


            private static Urun_EtkenMadde[] XXXXXXGetUrun_EtkenMaddeListSync_ServerSide(string userName, string password, System.Nullable<long> Urun_Bilgisi_ID)
            {

#region XXXXXXGetUrun_EtkenMaddeListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetUrun_EtkenMaddeList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Urun_Bilgisi_ID", (object)Urun_Bilgisi_ID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    Urun_EtkenMadde[] cevap = default(Urun_EtkenMadde[]);
                    cevap = (Urun_EtkenMadde[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetUrun_EtkenMaddeListSync_Body

            }

            public static Urun_Fiyat[] XXXXXXGetUrunFiyatiListSync(Guid siteID, string userName, string password, string barkod)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Urun_Fiyat[]) TTMessageFactory.SyncCall(siteID, new Guid("1a6685db-d103-47db-8584-934a20be15f8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetUrunFiyatiListSync_ServerSide", userName, password, barkod);
            }


            private static Urun_Fiyat[] XXXXXXGetUrunFiyatiListSync_ServerSide(string userName, string password, string barkod)
            {

#region XXXXXXGetUrunFiyatiListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetUrunFiyatiList";
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

                    Urun_Fiyat[] cevap = default(Urun_Fiyat[]);
                    cevap = (Urun_Fiyat[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetUrunFiyatiListSync_Body

            }

            public static UygulamaKodlari[] XXXXXXGetUygulamaKodlariListSync(Guid siteID, string userName, string password, System.Nullable<int> Uygulama_ID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (UygulamaKodlari[]) TTMessageFactory.SyncCall(siteID, new Guid("89f22423-c2fc-4ede-8f61-05d80d49500f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGetUygulamaKodlariListSync_ServerSide", userName, password, Uygulama_ID);
            }


            private static UygulamaKodlari[] XXXXXXGetUygulamaKodlariListSync_ServerSide(string userName, string password, System.Nullable<int> Uygulama_ID)
            {

#region XXXXXXGetUygulamaKodlariListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGetUygulamaKodlariList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Uygulama_ID", (object)Uygulama_ID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    UygulamaKodlari[] cevap = default(UygulamaKodlari[]);
                    cevap = (UygulamaKodlari[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGetUygulamaKodlariListSync_Body

            }

            public static Urun_Atc[] XXXXXXGeUrunAtcListSync(Guid siteID, string userName, string password, System.Nullable<decimal> UrunId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Urun_Atc[]) TTMessageFactory.SyncCall(siteID, new Guid("0cd1c076-10a3-434f-972a-b6d56f5cc169"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","XXXXXXGeUrunAtcListSync_ServerSide", userName, password, UrunId);
            }


            private static Urun_Atc[] XXXXXXGeUrunAtcListSync_ServerSide(string userName, string password, System.Nullable<decimal> UrunId)
            {

#region XXXXXXGeUrunAtcListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "XXXXXXGeUrunAtcList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UrunId", (object)UrunId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    Urun_Atc[] cevap = default(Urun_Atc[]);
                    cevap = (Urun_Atc[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion XXXXXXGeUrunAtcListSync_Body

            }

            public static AuditRow[] GetDataFromBarkodSync(Guid siteID, string userName, string password, string barkod)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (AuditRow[]) TTMessageFactory.SyncCall(siteID, new Guid("c2acd9af-d64e-4a3a-92ee-32551801d538"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","GetDataFromBarkodSync_ServerSide", userName, password, barkod);
            }


            private static AuditRow[] GetDataFromBarkodSync_ServerSide(string userName, string password, string barkod)
            {

#region GetDataFromBarkodSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "GetDataFromBarkod";
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

                    AuditRow[] cevap = default(AuditRow[]);
                    cevap = (AuditRow[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetDataFromBarkodSync_Body

            }

            public static AuditRow[] GetLastAuditsXXXXXXSync(Guid siteID, string userName, string password, string LastRowId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (AuditRow[]) TTMessageFactory.SyncCall(siteID, new Guid("0274267d-8f26-44bc-930b-1bae3772841c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","GetLastAuditsXXXXXXSync_ServerSide", userName, password, LastRowId);
            }


            private static AuditRow[] GetLastAuditsXXXXXXSync_ServerSide(string userName, string password, string LastRowId)
            {

#region GetLastAuditsXXXXXXSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "GetLastAuditsXXXXXX";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("LastRowId", (object)LastRowId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    AuditRow[] cevap = default(AuditRow[]);
                    cevap = (AuditRow[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetLastAuditsXXXXXXSync_Body

            }

            public static AuditRow[] GetLastAuditsSync(Guid siteID, string userName, string password, string LastRowId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (AuditRow[]) TTMessageFactory.SyncCall(siteID, new Guid("a8ef3bea-c886-4da0-bc73-82247d01da77"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.DrugServis+WebMethods, TTObjectClasses","GetLastAuditsSync_ServerSide", userName, password, LastRowId);
            }


            private static AuditRow[] GetLastAuditsSync_ServerSide(string userName, string password, string LastRowId)
            {

#region GetLastAuditsSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.DrugServis";
                    header.ServiceId = "affc3acd-f2ca-4a45-9a51-ef5bff4bfe4f";
                    header.MethodName = "GetLastAudits";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("LastRowId", (object)LastRowId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    AuditRow[] cevap = default(AuditRow[]);
                    cevap = (AuditRow[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetLastAuditsSync_Body

            }

        }
                    
        protected DrugServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGSERVIS", dataRow) { }
        protected DrugServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGSERVIS", dataRow, isImported) { }
        public DrugServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugServis() : base() { }

    }
}