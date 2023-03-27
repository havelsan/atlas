
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSSistemlerRest")] 

    /// <summary>
    /// Rest Api ile çalışan yeni versiyon
    /// </summary>
    public  partial class SKRSSistemlerRest : TTObject, IRestServiceObject
    {
        public class SKRSSistemlerRestList : TTObjectCollection<SKRSSistemlerRest> { }
                    
        public class ChildSKRSSistemlerRestCollection : TTObject.TTChildObjectCollection<SKRSSistemlerRest>
        {
            public ChildSKRSSistemlerRestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSSistemlerRestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static AddOlayAfetBilgisiResponse AddOlayAfetBilgisiSync(Guid siteID, AddOlayAfetBilgisiRequest addOlayAfetBilgisiRequest)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (AddOlayAfetBilgisiResponse) TTMessageFactory.SyncCall(siteID, new Guid("0018ce8a-245f-439e-854f-42cd37c571de"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","AddOlayAfetBilgisiSync_ServerSide", addOlayAfetBilgisiRequest);
            }


            private static AddOlayAfetBilgisiResponse AddOlayAfetBilgisiSync_ServerSide(AddOlayAfetBilgisiRequest addOlayAfetBilgisiRequest)
            {

#region AddOlayAfetBilgisiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "AddOlayAfetBilgisi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("addOlayAfetBilgisiRequest", (object)addOlayAfetBilgisiRequest),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    AddOlayAfetBilgisiResponse cevap = default(AddOlayAfetBilgisiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<AddOlayAfetBilgisiResponse>(cevapJson);
                    return cevap;

#endregion AddOlayAfetBilgisiSync_Body

            }

            public static GetASALHastalikResponse GetASALHastalikSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetASALHastalikResponse) TTMessageFactory.SyncCall(siteID, new Guid("4ba406d8-3a31-4426-8d29-4201f931d7ba"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetASALHastalikSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetASALHastalikResponse GetASALHastalikSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetASALHastalikSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetASALHastalikResponse cevap = default(GetASALHastalikResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetASALHastalikResponse>(cevapJson);
                    return cevap;

#endregion GetASALHastalikSync_Body

            }

            public static GetAsiTakvimiResponse GetAsiTakvimiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetAsiTakvimiResponse) TTMessageFactory.SyncCall(siteID, new Guid("db7d7357-673d-414a-b747-a9a02940dc2b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetAsiTakvimiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetAsiTakvimiResponse GetAsiTakvimiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetAsiTakvimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetAsiTakvimiResponse cevap = default(GetAsiTakvimiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAsiTakvimiResponse>(cevapJson);
                    return cevap;

#endregion GetAsiTakvimiSync_Body

            }

            public static GetBebekIzlemTakvimiResponse GetBebekIzlemTakvimiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetBebekIzlemTakvimiResponse) TTMessageFactory.SyncCall(siteID, new Guid("c38f3a31-234d-488a-be07-74744e1f8419"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetBebekIzlemTakvimiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetBebekIzlemTakvimiResponse GetBebekIzlemTakvimiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetBebekIzlemTakvimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetBebekIzlemTakvimiResponse cevap = default(GetBebekIzlemTakvimiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetBebekIzlemTakvimiResponse>(cevapJson);
                    return cevap;

#endregion GetBebekIzlemTakvimiSync_Body

            }

            public static GetBucakResponse GetBucakSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetBucakResponse) TTMessageFactory.SyncCall(siteID, new Guid("f6c190bf-d880-41bb-9d8a-fe3b9074af83"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetBucakSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetBucakResponse GetBucakSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetBucakSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetBucakResponse cevap = default(GetBucakResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetBucakResponse>(cevapJson);
                    return cevap;

#endregion GetBucakSync_Body

            }

            public static GetCocukIzlemTakvimiResponse GetCocukIzlemTakvimiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetCocukIzlemTakvimiResponse) TTMessageFactory.SyncCall(siteID, new Guid("19f02f73-7d17-463e-8e5c-008eb0c91c3e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetCocukIzlemTakvimiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetCocukIzlemTakvimiResponse GetCocukIzlemTakvimiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetCocukIzlemTakvimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetCocukIzlemTakvimiResponse cevap = default(GetCocukIzlemTakvimiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetCocukIzlemTakvimiResponse>(cevapJson);
                    return cevap;

#endregion GetCocukIzlemTakvimiSync_Body

            }

            public static GetEgitimKurumlariResponse GetEgitimKurumlariSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetEgitimKurumlariResponse) TTMessageFactory.SyncCall(siteID, new Guid("c9f37d71-b21d-4649-976a-8895313baf66"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetEgitimKurumlariSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetEgitimKurumlariResponse GetEgitimKurumlariSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetEgitimKurumlariSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetEgitimKurumlariResponse cevap = default(GetEgitimKurumlariResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetEgitimKurumlariResponse>(cevapJson);
                    return cevap;

#endregion GetEgitimKurumlariSync_Body

            }

            public static GetGebeIzlemTakvimiResponse GetGebeIzlemTakvimiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetGebeIzlemTakvimiResponse) TTMessageFactory.SyncCall(siteID, new Guid("34e9f6a8-edd8-4986-9e26-fe37d796dcc8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetGebeIzlemTakvimiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetGebeIzlemTakvimiResponse GetGebeIzlemTakvimiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetGebeIzlemTakvimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetGebeIzlemTakvimiResponse cevap = default(GetGebeIzlemTakvimiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetGebeIzlemTakvimiResponse>(cevapJson);
                    return cevap;

#endregion GetGebeIzlemTakvimiSync_Body

            }

            public static GetGETATUygulandigiDurumlarResponse GetGETATUygulandigiDurumlarSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetGETATUygulandigiDurumlarResponse) TTMessageFactory.SyncCall(siteID, new Guid("eb78423b-9c67-4822-a705-48f6d270124d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetGETATUygulandigiDurumlarSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetGETATUygulandigiDurumlarResponse GetGETATUygulandigiDurumlarSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetGETATUygulandigiDurumlarSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetGETATUygulandigiDurumlarResponse cevap = default(GetGETATUygulandigiDurumlarResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetGETATUygulandigiDurumlarResponse>(cevapJson);
                    return cevap;

#endregion GetGETATUygulandigiDurumlarSync_Body

            }

            public static GetGunSonuOzetAciklamaResponse GetGunSonuOzetAciklamaSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetGunSonuOzetAciklamaResponse) TTMessageFactory.SyncCall(siteID, new Guid("9e4c7446-a7bc-49b9-8a06-e991368c2198"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetGunSonuOzetAciklamaSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetGunSonuOzetAciklamaResponse GetGunSonuOzetAciklamaSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetGunSonuOzetAciklamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetGunSonuOzetAciklamaResponse cevap = default(GetGunSonuOzetAciklamaResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetGunSonuOzetAciklamaResponse>(cevapJson);
                    return cevap;

#endregion GetGunSonuOzetAciklamaSync_Body

            }

            public static GetICD10MSVSIliskisiResponse GetICD10MSVSIliskisiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetICD10MSVSIliskisiResponse) TTMessageFactory.SyncCall(siteID, new Guid("074460e5-8b86-443b-b3e6-86d539c96eae"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetICD10MSVSIliskisiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetICD10MSVSIliskisiResponse GetICD10MSVSIliskisiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetICD10MSVSIliskisiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetICD10MSVSIliskisiResponse cevap = default(GetICD10MSVSIliskisiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetICD10MSVSIliskisiResponse>(cevapJson);
                    return cevap;

#endregion GetICD10MSVSIliskisiSync_Body

            }

            public static GetICD10Response GetICD10Sync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetICD10Response) TTMessageFactory.SyncCall(siteID, new Guid("86e0211b-0477-4d78-af4d-f54b216cd8a7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetICD10Sync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetICD10Response GetICD10Sync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetICD10Sync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetICD10Response cevap = default(GetICD10Response);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetICD10Response>(cevapJson);
                    return cevap;

#endregion GetICD10Sync_Body

            }

            public static GetICDOMorfolojiKoduResponse GetICDOMorfolojiKoduSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetICDOMorfolojiKoduResponse) TTMessageFactory.SyncCall(siteID, new Guid("b657c88d-e254-4f98-bce2-4818407434ff"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetICDOMorfolojiKoduSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetICDOMorfolojiKoduResponse GetICDOMorfolojiKoduSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetICDOMorfolojiKoduSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetICDOMorfolojiKoduResponse cevap = default(GetICDOMorfolojiKoduResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetICDOMorfolojiKoduResponse>(cevapJson);
                    return cevap;

#endregion GetICDOMorfolojiKoduSync_Body

            }

            public static GetICDOResponse GetICDOSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetICDOResponse) TTMessageFactory.SyncCall(siteID, new Guid("1d6926d2-6f5b-4be1-b6f9-2d91cc035cfa"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetICDOSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetICDOResponse GetICDOSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetICDOSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetICDOResponse cevap = default(GetICDOResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetICDOResponse>(cevapJson);
                    return cevap;

#endregion GetICDOSync_Body

            }

            public static GetIlceResponse GetIlceSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetIlceResponse) TTMessageFactory.SyncCall(siteID, new Guid("1ab54b59-e6dc-44b3-8764-af5fef38c7cb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetIlceSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetIlceResponse GetIlceSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetIlceSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetIlceResponse cevap = default(GetIlceResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetIlceResponse>(cevapJson);
                    return cevap;

#endregion GetIlceSync_Body

            }

            public static GetKacinciLohusaIzlemResponse GetKacinciLohusaIzlemSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetKacinciLohusaIzlemResponse) TTMessageFactory.SyncCall(siteID, new Guid("3ac2187a-8239-4c4d-92e6-75f165e20ad9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetKacinciLohusaIzlemSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetKacinciLohusaIzlemResponse GetKacinciLohusaIzlemSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetKacinciLohusaIzlemSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetKacinciLohusaIzlemResponse cevap = default(GetKacinciLohusaIzlemResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetKacinciLohusaIzlemResponse>(cevapJson);
                    return cevap;

#endregion GetKacinciLohusaIzlemSync_Body

            }

            public static GetKoyResponse GetKoySync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetKoyResponse) TTMessageFactory.SyncCall(siteID, new Guid("cef8d4fe-078e-4a70-93a4-ac4042f3fb03"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetKoySync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetKoyResponse GetKoySync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetKoySync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetKoyResponse cevap = default(GetKoyResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetKoyResponse>(cevapJson);
                    return cevap;

#endregion GetKoySync_Body

            }

            public static GetKurumResponse GetKurumSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetKurumResponse) TTMessageFactory.SyncCall(siteID, new Guid("fa874e00-3a3f-4638-a0a5-a1d11cbacddf"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetKurumSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetKurumResponse GetKurumSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetKurumSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetKurumResponse cevap = default(GetKurumResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetKurumResponse>(cevapJson);
                    return cevap;

#endregion GetKurumSync_Body

            }

            public static GetLOINCResponse GetLOINCSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetLOINCResponse) TTMessageFactory.SyncCall(siteID, new Guid("94c4d27f-a847-4d05-989b-04589959201a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetLOINCSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetLOINCResponse GetLOINCSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetLOINCSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetLOINCResponse cevap = default(GetLOINCResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetLOINCResponse>(cevapJson);
                    return cevap;

#endregion GetLOINCSync_Body

            }

            public static GetMahalleResponse GetMahalleSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetMahalleResponse) TTMessageFactory.SyncCall(siteID, new Guid("29d0fa20-a4d8-417c-8144-b184e4a4b6ac"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetMahalleSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetMahalleResponse GetMahalleSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetMahalleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetMahalleResponse cevap = default(GetMahalleResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMahalleResponse>(cevapJson);
                    return cevap;

#endregion GetMahalleSync_Body

            }

            public static GetMeslekHastaliklariResponse GetMeslekHastaliklariSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetMeslekHastaliklariResponse) TTMessageFactory.SyncCall(siteID, new Guid("7a8e104f-8b56-4d76-b119-48eb3f85afcd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetMeslekHastaliklariSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetMeslekHastaliklariResponse GetMeslekHastaliklariSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetMeslekHastaliklariSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetMeslekHastaliklariResponse cevap = default(GetMeslekHastaliklariResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMeslekHastaliklariResponse>(cevapJson);
                    return cevap;

#endregion GetMeslekHastaliklariSync_Body

            }

            public static GetMesleklerResponse GetMesleklerSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetMesleklerResponse) TTMessageFactory.SyncCall(siteID, new Guid("84ab9f9c-c99f-4d3a-a2e6-0878a981fe02"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetMesleklerSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetMesleklerResponse GetMesleklerSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetMesleklerSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetMesleklerResponse cevap = default(GetMesleklerResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMesleklerResponse>(cevapJson);
                    return cevap;

#endregion GetMesleklerSync_Body

            }

            public static GetOkulCagiGenclikIzlemTakvimiResponse GetOkulCagiGenclikIzlemTakvimiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetOkulCagiGenclikIzlemTakvimiResponse) TTMessageFactory.SyncCall(siteID, new Guid("2ca7436f-d68c-4731-8a52-f343a901f89c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetOkulCagiGenclikIzlemTakvimiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetOkulCagiGenclikIzlemTakvimiResponse GetOkulCagiGenclikIzlemTakvimiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetOkulCagiGenclikIzlemTakvimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetOkulCagiGenclikIzlemTakvimiResponse cevap = default(GetOkulCagiGenclikIzlemTakvimiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetOkulCagiGenclikIzlemTakvimiResponse>(cevapJson);
                    return cevap;

#endregion GetOkulCagiGenclikIzlemTakvimiSync_Body

            }

            public static GetOlayAfetBilgisiResponse GetOlayAfetBilgisiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetOlayAfetBilgisiResponse) TTMessageFactory.SyncCall(siteID, new Guid("95132368-89e1-47ee-8463-7ce10a73e965"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetOlayAfetBilgisiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetOlayAfetBilgisiResponse GetOlayAfetBilgisiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetOlayAfetBilgisiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetOlayAfetBilgisiResponse cevap = default(GetOlayAfetBilgisiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetOlayAfetBilgisiResponse>(cevapJson);
                    return cevap;

#endregion GetOlayAfetBilgisiSync_Body

            }

            public static GetPersentilResponse GetPersentilSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetPersentilResponse) TTMessageFactory.SyncCall(siteID, new Guid("902ed93f-7cb7-4b47-aceb-55de73954bbe"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetPersentilSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetPersentilResponse GetPersentilSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetPersentilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetPersentilResponse cevap = default(GetPersentilResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPersentilResponse>(cevapJson);
                    return cevap;

#endregion GetPersentilSync_Body

            }

            public static GetSKRSIlacResponse GetSKRSIlacSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetSKRSIlacResponse) TTMessageFactory.SyncCall(siteID, new Guid("e990dab4-befa-409d-99bd-5c3665e487fa"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetSKRSIlacSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetSKRSIlacResponse GetSKRSIlacSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetSKRSIlacSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetSKRSIlacResponse cevap = default(GetSKRSIlacResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSKRSIlacResponse>(cevapJson);
                    return cevap;

#endregion GetSKRSIlacSync_Body

            }

            public static GetSkrsListResponse GetSkrsListSync(Guid siteID, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetSkrsListResponse) TTMessageFactory.SyncCall(siteID, new Guid("fae05a92-10ea-46ab-8458-4b07b96307d2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetSkrsListSync_ServerSide", baslangicTarihi);
            }


            private static GetSkrsListResponse GetSkrsListSync_ServerSide(DateTime baslangicTarihi)
            {

#region GetSkrsListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetSkrsListResponse cevap = default(GetSkrsListResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSkrsListResponse>(cevapJson);
                    return cevap;

#endregion GetSkrsListSync_Body

            }

            public static GetSkrsObjectResponse GetSkrsObjectSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetSkrsObjectResponse) TTMessageFactory.SyncCall(siteID, new Guid("4af73177-9efc-45af-bcf8-64b459270abb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetSkrsObjectSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetSkrsObjectResponse GetSkrsObjectSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetSkrsObjectSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetSkrsObjectResponse cevap = default(GetSkrsObjectResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSkrsObjectResponse>(cevapJson);
                    return cevap;

#endregion GetSkrsObjectSync_Body

            }

            public static GetSKRSSUTVSResponse GetSKRSSUTVSSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetSKRSSUTVSResponse) TTMessageFactory.SyncCall(siteID, new Guid("dfd5cdc7-1a4a-4bc9-b1ac-3daeeda1a3d3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetSKRSSUTVSSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetSKRSSUTVSResponse GetSKRSSUTVSSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetSKRSSUTVSSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetSKRSSUTVSResponse cevap = default(GetSKRSSUTVSResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSKRSSUTVSResponse>(cevapJson);
                    return cevap;

#endregion GetSKRSSUTVSSync_Body

            }

            public static GetSUTResponse GetSUTSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetSUTResponse) TTMessageFactory.SyncCall(siteID, new Guid("4a43aaef-709f-4b09-9f1a-ce36a33212fd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetSUTSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetSUTResponse GetSUTSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetSUTSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetSUTResponse cevap = default(GetSUTResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSUTResponse>(cevapJson);
                    return cevap;

#endregion GetSUTSync_Body

            }

            public static GetTeletipKurumOnekBilgileriResponse GetTeletipKurumOnekBilgileriSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetTeletipKurumOnekBilgileriResponse) TTMessageFactory.SyncCall(siteID, new Guid("776494ea-3b18-4df1-8473-2fde97537bc3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetTeletipKurumOnekBilgileriSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetTeletipKurumOnekBilgileriResponse GetTeletipKurumOnekBilgileriSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetTeletipKurumOnekBilgileriSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetTeletipKurumOnekBilgileriResponse cevap = default(GetTeletipKurumOnekBilgileriResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTeletipKurumOnekBilgileriResponse>(cevapJson);
                    return cevap;

#endregion GetTeletipKurumOnekBilgileriSync_Body

            }

            public static GetTibbiBiyokimyaAkilciTestIstemiListesiResponse GetTibbiBiyokimyaAkilciTestIstemiListesiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetTibbiBiyokimyaAkilciTestIstemiListesiResponse) TTMessageFactory.SyncCall(siteID, new Guid("002460c9-c005-4a84-8275-17e553e09f21"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetTibbiBiyokimyaAkilciTestIstemiListesiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetTibbiBiyokimyaAkilciTestIstemiListesiResponse GetTibbiBiyokimyaAkilciTestIstemiListesiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetTibbiBiyokimyaAkilciTestIstemiListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetTibbiBiyokimyaAkilciTestIstemiListesiResponse cevap = default(GetTibbiBiyokimyaAkilciTestIstemiListesiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTibbiBiyokimyaAkilciTestIstemiListesiResponse>(cevapJson);
                    return cevap;

#endregion GetTibbiBiyokimyaAkilciTestIstemiListesiSync_Body

            }

            public static GetTibbiIslemPuanBilgisiResponse GetTibbiIslemPuanBilgisiSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetTibbiIslemPuanBilgisiResponse) TTMessageFactory.SyncCall(siteID, new Guid("e63003c4-0e63-488e-8738-75a4d7504ef4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetTibbiIslemPuanBilgisiSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetTibbiIslemPuanBilgisiResponse GetTibbiIslemPuanBilgisiSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetTibbiIslemPuanBilgisiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetTibbiIslemPuanBilgisiResponse cevap = default(GetTibbiIslemPuanBilgisiResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTibbiIslemPuanBilgisiResponse>(cevapJson);
                    return cevap;

#endregion GetTibbiIslemPuanBilgisiSync_Body

            }

            public static GetUlkeResponse GetUlkeSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetUlkeResponse) TTMessageFactory.SyncCall(siteID, new Guid("af99b638-0c94-4702-8aa3-a46fe17c403d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetUlkeSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetUlkeResponse GetUlkeSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetUlkeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetUlkeResponse cevap = default(GetUlkeResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetUlkeResponse>(cevapJson);
                    return cevap;

#endregion GetUlkeSync_Body

            }

            public static GetYasGruplariResponse GetYasGruplariSync(Guid siteID, string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (GetYasGruplariResponse) TTMessageFactory.SyncCall(siteID, new Guid("e39f80f4-1fe1-4de3-a964-ca05429a246c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SKRSSistemlerRest+WebMethods, TTObjectClasses","GetYasGruplariSync_ServerSide", skrsCodeSystemGuid, page, baslangicTarihi);
            }


            private static GetYasGruplariResponse GetYasGruplariSync_ServerSide(string skrsCodeSystemGuid, int page, DateTime baslangicTarihi)
            {

#region GetYasGruplariSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SKRSSistemlerRest";
                    header.ServiceId = "05016131-4043-4346-85b4-f4526eeb1c08";
                    header.MethodName = "GetSkrsObject";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.REST;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("skrsCodeSystemGuid", (object)skrsCodeSystemGuid),
                        Tuple.Create("page", (object)page),
                        Tuple.Create("baslangicTarihi", (object)baslangicTarihi),
                    };

                    var classInstance = new SKRSSistemlerRest();
                    header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.GET);

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                    GetYasGruplariResponse cevap = default(GetYasGruplariResponse);
                    var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                    cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<GetYasGruplariResponse>(cevapJson);
                    return cevap;

#endregion GetYasGruplariSync_Body

            }

        }
                    
        protected SKRSSistemlerRest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSSistemlerRest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSSistemlerRest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSSistemlerRest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSSistemlerRest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSSISTEMLERREST", dataRow) { }
        protected SKRSSistemlerRest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSSISTEMLERREST", dataRow, isImported) { }
        public SKRSSistemlerRest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSSistemlerRest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSSistemlerRest() : base() { }

    }
}