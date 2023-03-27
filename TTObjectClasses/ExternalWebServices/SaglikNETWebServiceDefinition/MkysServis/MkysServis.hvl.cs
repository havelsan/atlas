
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MkysServis")] 

    public  partial class MkysServis : TTObject
    {
        public class MkysServisList : TTObjectCollection<MkysServis> { }
                    
        public class ChildMkysServisCollection : TTObject.TTChildObjectCollection<MkysServis>
        {
            public ChildMkysServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMkysServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static amortismanInsertSonuc amortismanInsertSync(Guid siteID, amortismanInsertItem item)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (amortismanInsertSonuc) TTMessageFactory.SyncCall(siteID, new Guid("5abd09a5-c726-421a-baa9-4d30e188194c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","amortismanInsertSync_ServerSide", item);
            }


            private static amortismanInsertSonuc amortismanInsertSync_ServerSide(amortismanInsertItem item)
            {

#region amortismanInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "amortismanInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("item", (object)item),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    amortismanInsertSonuc cevap = default(amortismanInsertSonuc);
                    cevap = (amortismanInsertSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion amortismanInsertSync_Body

            }

            public static aracInsertSonuc aracInsertSync(Guid siteID, aracInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (aracInsertSonuc) TTMessageFactory.SyncCall(siteID, new Guid("332039e6-50f2-401d-9655-879619804b2c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","aracInsertSync_ServerSide", insertItem);
            }


            private static aracInsertSonuc aracInsertSync_ServerSide(aracInsertItem insertItem)
            {

#region aracInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "aracInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    aracInsertSonuc cevap = default(aracInsertSonuc);
                    cevap = (aracInsertSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion aracInsertSync_Body

            }

            public static aracModelItem[] aracModelGetDataSync(Guid siteID, string markaID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (aracModelItem[]) TTMessageFactory.SyncCall(siteID, new Guid("2f1f38c6-8a80-45df-bec5-ac205c04e964"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","aracModelGetDataSync_ServerSide", markaID);
            }


            private static aracModelItem[] aracModelGetDataSync_ServerSide(string markaID)
            {

#region aracModelGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "aracModelGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("markaID", (object)markaID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    aracModelItem[] cevap = default(aracModelItem[]);
                    cevap = (aracModelItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion aracModelGetDataSync_Body

            }

            public static mkysSonuc barkodUpdateSync(Guid siteID, int stokHareketID, string barkod)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (mkysSonuc) TTMessageFactory.SyncCall(siteID, new Guid("b03f158b-72d4-4072-9ca4-95452161cd00"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","barkodUpdateSync_ServerSide", stokHareketID, barkod);
            }


            private static mkysSonuc barkodUpdateSync_ServerSide(int stokHareketID, string barkod)
            {

#region barkodUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "barkodUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("stokHareketID", (object)stokHareketID),
                        Tuple.Create("barkod", (object)barkod),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    mkysSonuc cevap = default(mkysSonuc);
                    cevap = (mkysSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion barkodUpdateSync_Body

            }

            public static birimItem[] birimBilgileriGetiriciSync(Guid siteID, int birimKayitID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimItem[]) TTMessageFactory.SyncCall(siteID, new Guid("38190d50-0dde-444a-a42d-702500537ebe"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","birimBilgileriGetiriciSync_ServerSide", birimKayitID);
            }


            private static birimItem[] birimBilgileriGetiriciSync_ServerSide(int birimKayitID)
            {

#region birimBilgileriGetiriciSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "birimBilgileriGetirici";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("birimKayitID", (object)birimKayitID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimItem[] cevap = default(birimItem[]);
                    cevap = (birimItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion birimBilgileriGetiriciSync_Body

            }

            public static birimDepoItem[] birimDepoGetDataSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimDepoItem[]) TTMessageFactory.SyncCall(siteID, new Guid("a8b8c1a7-284c-44ef-a2be-dff79a84d77c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","birimDepoGetDataSync_ServerSide");
            }


            private static birimDepoItem[] birimDepoGetDataSync_ServerSide()
            {

#region birimDepoGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "birimDepoGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimDepoItem[] cevap = default(birimDepoItem[]);
                    cevap = (birimDepoItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion birimDepoGetDataSync_Body

            }

            public static birimItem[] birimGetDataSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimItem[]) TTMessageFactory.SyncCall(siteID, new Guid("930aab81-60e2-4687-afc9-940a63da2d67"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","birimGetDataSync_ServerSide");
            }


            private static birimItem[] birimGetDataSync_ServerSide()
            {

#region birimGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "birimGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimItem[] cevap = default(birimItem[]);
                    cevap = (birimItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion birimGetDataSync_Body

            }

            public static birimKayitIslemleriSonuc birimInsertSync(Guid siteID, birimInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimKayitIslemleriSonuc) TTMessageFactory.SyncCall(siteID, new Guid("fc9a5b2a-b2c0-4155-acd8-11fcc7e8e1c3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","birimInsertSync_ServerSide", insertItem);
            }


            private static birimKayitIslemleriSonuc birimInsertSync_ServerSide(birimInsertItem insertItem)
            {

#region birimInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "birimInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimKayitIslemleriSonuc cevap = default(birimKayitIslemleriSonuc);
                    cevap = (birimKayitIslemleriSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion birimInsertSync_Body

            }

            public static birimKayitIslemleriSonuc birimUpdateSync(Guid siteID, birimUpdateItem updateItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimKayitIslemleriSonuc) TTMessageFactory.SyncCall(siteID, new Guid("74e78978-016c-4bea-8e55-b608af643fe4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","birimUpdateSync_ServerSide", updateItem);
            }


            private static birimKayitIslemleriSonuc birimUpdateSync_ServerSide(birimUpdateItem updateItem)
            {

#region birimUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "birimUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("updateItem", (object)updateItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimKayitIslemleriSonuc cevap = default(birimKayitIslemleriSonuc);
                    cevap = (birimKayitIslemleriSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion birimUpdateSync_Body

            }

            public static stokHareketYilSonuItem[] butceTuruFarkliOlanStoklarGetDataSync(Guid siteID, yilSonuKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketYilSonuItem[]) TTMessageFactory.SyncCall(siteID, new Guid("00c2f20f-98df-41d4-9c18-5e51ee636204"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","butceTuruFarkliOlanStoklarGetDataSync_ServerSide", kriter);
            }


            private static stokHareketYilSonuItem[] butceTuruFarkliOlanStoklarGetDataSync_ServerSide(yilSonuKriter kriter)
            {

#region butceTuruFarkliOlanStoklarGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "butceTuruFarkliOlanStoklarGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketYilSonuItem[] cevap = default(stokHareketYilSonuItem[]);
                    cevap = (stokHareketYilSonuItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion butceTuruFarkliOlanStoklarGetDataSync_Body

            }

            public static cikisFisDetayItem[] cikisFisDetayGetDataSync(Guid siteID, string userName, string password, int islemKayitNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (cikisFisDetayItem[]) TTMessageFactory.SyncCall(siteID, new Guid("30f784b2-8958-47f9-9311-fdc2c8c06f69"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","cikisFisDetayGetDataSync_ServerSide", userName, password, islemKayitNo);
            }


            private static cikisFisDetayItem[] cikisFisDetayGetDataSync_ServerSide(string userName, string password, int islemKayitNo)
            {

#region cikisFisDetayGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "cikisFisDetayGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("islemKayitNo", (object)islemKayitNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    cikisFisDetayItem[] cevap = default(cikisFisDetayItem[]);
                    cevap = (cikisFisDetayItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion cikisFisDetayGetDataSync_Body

            }

            public static cikisFisiItem[] cikisFisGetDataSync(Guid siteID, cikisFisleriKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (cikisFisiItem[]) TTMessageFactory.SyncCall(siteID, new Guid("9801ad27-2d49-481e-bdd3-1aea9dcd186b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","cikisFisGetDataSync_ServerSide", kriter);
            }


            private static cikisFisiItem[] cikisFisGetDataSync_ServerSide(cikisFisleriKriter kriter)
            {

#region cikisFisGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "cikisFisGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    cikisFisiItem[] cevap = default(cikisFisiItem[]);
                    cevap = (cikisFisiItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion cikisFisGetDataSync_Body

            }

            public static bool cikisFisiVarMiSync(Guid siteID, int islemKayitNo, string hbysID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (bool) TTMessageFactory.SyncCall(siteID, new Guid("ca2dae62-4a29-4df8-8e0c-0b4180d163a5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","cikisFisiVarMiSync_ServerSide", islemKayitNo, hbysID);
            }


            private static bool cikisFisiVarMiSync_ServerSide(int islemKayitNo, string hbysID)
            {

#region cikisFisiVarMiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "cikisFisiVarMi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("islemKayitNo", (object)islemKayitNo),
                        Tuple.Create("hbysID", (object)hbysID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    bool cevap = default(bool);
                    cevap = (bool)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion cikisFisiVarMiSync_Body

            }

            public static makbuzSilmeSonuc cikisMakbuzDeleteSync(Guid siteID, string userName, string password, int islemKayitNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzSilmeSonuc) TTMessageFactory.SyncCall(siteID, new Guid("1f94b236-4468-4e3d-b3b3-7ce15805c8d5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","cikisMakbuzDeleteSync_ServerSide", userName, password, islemKayitNo);
            }


            private static makbuzSilmeSonuc cikisMakbuzDeleteSync_ServerSide(string userName, string password, int islemKayitNo)
            {

#region cikisMakbuzDeleteSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "cikisMakbuzDelete";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("islemKayitNo", (object)islemKayitNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzSilmeSonuc cevap = default(makbuzSilmeSonuc);
                    cevap = (makbuzSilmeSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion cikisMakbuzDeleteSync_Body

            }

            public static makbuzUpdateSonuc covid19makbuzUpdateSync(Guid siteID, string userName, string password, makbuzUpdateItem updateItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzUpdateSonuc) TTMessageFactory.SyncCall(siteID, new Guid("95be3a42-f788-4d3d-81ff-672a9bd35136"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","covid19makbuzUpdateSync_ServerSide", userName, password, updateItem);
            }


            private static makbuzUpdateSonuc covid19makbuzUpdateSync_ServerSide(string userName, string password, makbuzUpdateItem updateItem)
            {

#region covid19makbuzUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "covid19makbuzUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("updateItem", (object)updateItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzUpdateSonuc cevap = default(makbuzUpdateSonuc);
                    cevap = (makbuzUpdateSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion covid19makbuzUpdateSync_Body

            }

            public static degerArtisiSonuc degerArtisiInsertSync(Guid siteID, degerArtisiInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (degerArtisiSonuc) TTMessageFactory.SyncCall(siteID, new Guid("b612304f-0ea9-4ab0-b2c9-aed949189810"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","degerArtisiInsertSync_ServerSide", insertItem);
            }


            private static degerArtisiSonuc degerArtisiInsertSync_ServerSide(degerArtisiInsertItem insertItem)
            {

#region degerArtisiInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "degerArtisiInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    degerArtisiSonuc cevap = default(degerArtisiSonuc);
                    cevap = (degerArtisiSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion degerArtisiInsertSync_Body

            }

            public static demirbasGetDataResult[] demirbasGetDataSync(Guid siteID, int depoKayitNo, int butceyili)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (demirbasGetDataResult[]) TTMessageFactory.SyncCall(siteID, new Guid("8e0c76d4-b678-4408-8352-c84a1c1ca4a2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","demirbasGetDataSync_ServerSide", depoKayitNo, butceyili);
            }


            private static demirbasGetDataResult[] demirbasGetDataSync_ServerSide(int depoKayitNo, int butceyili)
            {

#region demirbasGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "demirbasGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("depoKayitNo", (object)depoKayitNo),
                        Tuple.Create("butceyili", (object)butceyili),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    demirbasGetDataResult[] cevap = default(demirbasGetDataResult[]);
                    cevap = (demirbasGetDataResult[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion demirbasGetDataSync_Body

            }

            public static demirbasDevirSonuc demirbaslariDevretSync(Guid siteID, demirbasDevirItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (demirbasDevirSonuc) TTMessageFactory.SyncCall(siteID, new Guid("9ec0c38b-c213-48c2-b734-2f9dda11ed55"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","demirbaslariDevretSync_ServerSide", insertItem);
            }


            private static demirbasDevirSonuc demirbaslariDevretSync_ServerSide(demirbasDevirItem insertItem)
            {

#region demirbaslariDevretSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "demirbaslariDevret";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    demirbasDevirSonuc cevap = default(demirbasDevirSonuc);
                    cevap = (demirbasDevirSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion demirbaslariDevretSync_Body

            }

            public static cikisFisiItem[] depoCikisMakbuzGetDataSync(Guid siteID, cikisFisleriKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (cikisFisiItem[]) TTMessageFactory.SyncCall(siteID, new Guid("f3d1d6ac-0bf3-435b-854c-4843e6c3e47b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","depoCikisMakbuzGetDataSync_ServerSide", kriter);
            }


            private static cikisFisiItem[] depoCikisMakbuzGetDataSync_ServerSide(cikisFisleriKriter kriter)
            {

#region depoCikisMakbuzGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "depoCikisMakbuzGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    cikisFisiItem[] cevap = default(cikisFisiItem[]);
                    cevap = (cikisFisiItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion depoCikisMakbuzGetDataSync_Body

            }

            public static girisMakbuzItem[] depoGirisMakbuzGetDataSync(Guid siteID, depoGirisMakbuzGetKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (girisMakbuzItem[]) TTMessageFactory.SyncCall(siteID, new Guid("f9f0e1ea-4a5c-4737-a66d-344d4020bd79"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","depoGirisMakbuzGetDataSync_ServerSide", kriter);
            }


            private static girisMakbuzItem[] depoGirisMakbuzGetDataSync_ServerSide(depoGirisMakbuzGetKriter kriter)
            {

#region depoGirisMakbuzGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "depoGirisMakbuzGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    girisMakbuzItem[] cevap = default(girisMakbuzItem[]);
                    cevap = (girisMakbuzItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion depoGirisMakbuzGetDataSync_Body

            }

            public static depoKayitIslemleriSonuc depoInsertSync(Guid siteID, depoInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (depoKayitIslemleriSonuc) TTMessageFactory.SyncCall(siteID, new Guid("4ec7ee81-1a7c-4c06-82f2-7431efcd0bb4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","depoInsertSync_ServerSide", insertItem);
            }


            private static depoKayitIslemleriSonuc depoInsertSync_ServerSide(depoInsertItem insertItem)
            {

#region depoInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "depoInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    depoKayitIslemleriSonuc cevap = default(depoKayitIslemleriSonuc);
                    cevap = (depoKayitIslemleriSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion depoInsertSync_Body

            }

            public static stokHareketYilSonuItem[] deposuFarkliOlanStoklarGetDataSync(Guid siteID, yilSonuKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketYilSonuItem[]) TTMessageFactory.SyncCall(siteID, new Guid("1c824ae3-fa72-4fd8-a6f7-1406b7d515ef"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","deposuFarkliOlanStoklarGetDataSync_ServerSide", kriter);
            }


            private static stokHareketYilSonuItem[] deposuFarkliOlanStoklarGetDataSync_ServerSide(yilSonuKriter kriter)
            {

#region deposuFarkliOlanStoklarGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "deposuFarkliOlanStoklarGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketYilSonuItem[] cevap = default(stokHareketYilSonuItem[]);
                    cevap = (stokHareketYilSonuItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion deposuFarkliOlanStoklarGetDataSync_Body

            }

            public static depoKayitIslemleriSonuc depoUpdateSync(Guid siteID, depoUpdateItem updateItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (depoKayitIslemleriSonuc) TTMessageFactory.SyncCall(siteID, new Guid("a65f3320-a6cc-41f0-b67e-bd3f38ab6f82"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","depoUpdateSync_ServerSide", updateItem);
            }


            private static depoKayitIslemleriSonuc depoUpdateSync_ServerSide(depoUpdateItem updateItem)
            {

#region depoUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "depoUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("updateItem", (object)updateItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    depoKayitIslemleriSonuc cevap = default(depoKayitIslemleriSonuc);
                    cevap = (depoKayitIslemleriSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion depoUpdateSync_Body

            }

            public static depoYetkiKontrolSonuc depoYetkiKontrolSync(Guid siteID, depoYetkiKontrolItem kontrol)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (depoYetkiKontrolSonuc) TTMessageFactory.SyncCall(siteID, new Guid("aef0d777-f853-4cad-a5fe-5854ad67c061"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","depoYetkiKontrolSync_ServerSide", kontrol);
            }


            private static depoYetkiKontrolSonuc depoYetkiKontrolSync_ServerSide(depoYetkiKontrolItem kontrol)
            {

#region depoYetkiKontrolSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "depoYetkiKontrol";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kontrol", (object)kontrol),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    depoYetkiKontrolSonuc cevap = default(depoYetkiKontrolSonuc);
                    cevap = (depoYetkiKontrolSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion depoYetkiKontrolSync_Body

            }

            public static birimItem[] devirBirimleriGetDataSync(Guid siteID, string ilKodu, int bagliOlduguBirimKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimItem[]) TTMessageFactory.SyncCall(siteID, new Guid("e3e49264-8da5-44ab-aba6-e817e3beb080"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","devirBirimleriGetDataSync_ServerSide", ilKodu, bagliOlduguBirimKodu);
            }


            private static birimItem[] devirBirimleriGetDataSync_ServerSide(string ilKodu, int bagliOlduguBirimKodu)
            {

#region devirBirimleriGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "devirBirimleriGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilKodu", (object)ilKodu),
                        Tuple.Create("bagliOlduguBirimKodu", (object)bagliOlduguBirimKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimItem[] cevap = default(birimItem[]);
                    cevap = (birimItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion devirBirimleriGetDataSync_Body

            }

            public static devirFisiItem[] devirFisiGetSync(Guid siteID, string userName, string password, int islemKayitNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (devirFisiItem[]) TTMessageFactory.SyncCall(siteID, new Guid("d4d40ace-f5a9-46d8-94b2-e57fa00b9df5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","devirFisiGetSync_ServerSide", userName, password, islemKayitNo);
            }


            private static devirFisiItem[] devirFisiGetSync_ServerSide(string userName, string password, int islemKayitNo)
            {

#region devirFisiGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "devirFisiGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("islemKayitNo", (object)islemKayitNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    devirFisiItem[] cevap = default(devirFisiItem[]);
                    cevap = (devirFisiItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion devirFisiGetSync_Body

            }

            public static devirGerceklestiriciSonuc devirGerceklestiIptalSync(Guid siteID, devirGerceklestiYapItem[] devirListesi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (devirGerceklestiriciSonuc) TTMessageFactory.SyncCall(siteID, new Guid("597a4946-284c-4cb5-9247-a0500ad7b0cf"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","devirGerceklestiIptalSync_ServerSide", devirListesi);
            }


            private static devirGerceklestiriciSonuc devirGerceklestiIptalSync_ServerSide(devirGerceklestiYapItem[] devirListesi)
            {

#region devirGerceklestiIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "devirGerceklestiIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("devirListesi", (object)devirListesi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    devirGerceklestiriciSonuc cevap = default(devirGerceklestiriciSonuc);
                    cevap = (devirGerceklestiriciSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion devirGerceklestiIptalSync_Body

            }

            public static devirGerceklestiriciSonuc devirGerceklestiYapSync(Guid siteID, devirGerceklestiYapItem[] devirListesi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (devirGerceklestiriciSonuc) TTMessageFactory.SyncCall(siteID, new Guid("a7c09ddc-d535-40f3-b3ec-034f5d983b4e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","devirGerceklestiYapSync_ServerSide", devirListesi);
            }


            private static devirGerceklestiriciSonuc devirGerceklestiYapSync_ServerSide(devirGerceklestiYapItem[] devirListesi)
            {

#region devirGerceklestiYapSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "devirGerceklestiYap";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("devirListesi", (object)devirListesi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    devirGerceklestiriciSonuc cevap = default(devirGerceklestiriciSonuc);
                    cevap = (devirGerceklestiriciSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion devirGerceklestiYapSync_Body

            }

            public static birimItem[] disKurumlarListesiSync(Guid siteID, string ilKodu, int bagliOlduguBirimKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimItem[]) TTMessageFactory.SyncCall(siteID, new Guid("5aef9299-e00a-408f-bfbb-0d56c2fbae16"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","disKurumlarListesiSync_ServerSide", ilKodu, bagliOlduguBirimKodu);
            }


            private static birimItem[] disKurumlarListesiSync_ServerSide(string ilKodu, int bagliOlduguBirimKodu)
            {

#region disKurumlarListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "disKurumlarListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilKodu", (object)ilKodu),
                        Tuple.Create("bagliOlduguBirimKodu", (object)bagliOlduguBirimKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimItem[] cevap = default(birimItem[]);
                    cevap = (birimItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion disKurumlarListesiSync_Body

            }

            public static stokHareketYilSonuItem[] eksiBakiyeStoklarGetDataSync(Guid siteID, yilSonuKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketYilSonuItem[]) TTMessageFactory.SyncCall(siteID, new Guid("903c2e1c-9611-4534-95c1-cfb3a8e510ff"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","eksiBakiyeStoklarGetDataSync_ServerSide", kriter);
            }


            private static stokHareketYilSonuItem[] eksiBakiyeStoklarGetDataSync_ServerSide(yilSonuKriter kriter)
            {

#region eksiBakiyeStoklarGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "eksiBakiyeStoklarGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketYilSonuItem[] cevap = default(stokHareketYilSonuItem[]);
                    cevap = (stokHareketYilSonuItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eksiBakiyeStoklarGetDataSync_Body

            }

            public static firmaBilgileriGetItem[] firmaBilgileriGetSync(Guid siteID, int firmaKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (firmaBilgileriGetItem[]) TTMessageFactory.SyncCall(siteID, new Guid("cd74c033-aba5-4a99-8c4f-9c30742d7d98"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","firmaBilgileriGetSync_ServerSide", firmaKodu);
            }


            private static firmaBilgileriGetItem[] firmaBilgileriGetSync_ServerSide(int firmaKodu)
            {

#region firmaBilgileriGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "firmaBilgileriGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("firmaKodu", (object)firmaKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    firmaBilgileriGetItem[] cevap = default(firmaBilgileriGetItem[]);
                    cevap = (firmaBilgileriGetItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion firmaBilgileriGetSync_Body

            }

            public static firmaBilgileriGetTumuSonuc[] firmaBilgileriGetTumuSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (firmaBilgileriGetTumuSonuc[]) TTMessageFactory.SyncCall(siteID, new Guid("8a0fc3b5-c3de-40d6-bf0c-0ba117654db8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","firmaBilgileriGetTumuSync_ServerSide");
            }


            private static firmaBilgileriGetTumuSonuc[] firmaBilgileriGetTumuSync_ServerSide()
            {

#region firmaBilgileriGetTumuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "firmaBilgileriGetTumu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    firmaBilgileriGetTumuSonuc[] cevap = default(firmaBilgileriGetTumuSonuc[]);
                    cevap = (firmaBilgileriGetTumuSonuc[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion firmaBilgileriGetTumuSync_Body

            }

            public static firmaBilgileriGetVergiNoSonuc[] firmaBilgileriGetVergiNoSync(Guid siteID, string firmaVergiNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (firmaBilgileriGetVergiNoSonuc[]) TTMessageFactory.SyncCall(siteID, new Guid("51d04cb7-2ae3-4d35-a148-fccf77de5a14"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","firmaBilgileriGetVergiNoSync_ServerSide", firmaVergiNo);
            }


            private static firmaBilgileriGetVergiNoSonuc[] firmaBilgileriGetVergiNoSync_ServerSide(string firmaVergiNo)
            {

#region firmaBilgileriGetVergiNoSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "firmaBilgileriGetVergiNo";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("firmaVergiNo", (object)firmaVergiNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    firmaBilgileriGetVergiNoSonuc[] cevap = default(firmaBilgileriGetVergiNoSonuc[]);
                    cevap = (firmaBilgileriGetVergiNoSonuc[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion firmaBilgileriGetVergiNoSync_Body

            }

            public static sifreDegistirSonuc firmaSifreDegistirSync(Guid siteID, string kullaniciAdi, string eskiSifre, string yeniSifre)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (sifreDegistirSonuc) TTMessageFactory.SyncCall(siteID, new Guid("7abc5729-1acf-426e-8db2-059e91c00cb9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","firmaSifreDegistirSync_ServerSide", kullaniciAdi, eskiSifre, yeniSifre);
            }


            private static sifreDegistirSonuc firmaSifreDegistirSync_ServerSide(string kullaniciAdi, string eskiSifre, string yeniSifre)
            {

#region firmaSifreDegistirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "firmaSifreDegistir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kullaniciAdi", (object)kullaniciAdi),
                        Tuple.Create("eskiSifre", (object)eskiSifre),
                        Tuple.Create("yeniSifre", (object)yeniSifre),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    sifreDegistirSonuc cevap = default(sifreDegistirSonuc);
                    cevap = (sifreDegistirSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion firmaSifreDegistirSync_Body

            }

            public static stokHareketYilSonuItem[] fiyatiFarkliOlanStoklarGetDataSync(Guid siteID, yilSonuKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketYilSonuItem[]) TTMessageFactory.SyncCall(siteID, new Guid("ba7c5f94-8271-41e9-aedd-58e0482fe574"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","fiyatiFarkliOlanStoklarGetDataSync_ServerSide", kriter);
            }


            private static stokHareketYilSonuItem[] fiyatiFarkliOlanStoklarGetDataSync_ServerSide(yilSonuKriter kriter)
            {

#region fiyatiFarkliOlanStoklarGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "fiyatiFarkliOlanStoklarGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketYilSonuItem[] cevap = default(stokHareketYilSonuItem[]);
                    cevap = (stokHareketYilSonuItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion fiyatiFarkliOlanStoklarGetDataSync_Body

            }

            public static giriseAitCikislarResultItem[] giriseAitCikislarSync(Guid siteID, int stokHareketID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (giriseAitCikislarResultItem[]) TTMessageFactory.SyncCall(siteID, new Guid("ac2c4c8c-a34f-4028-af43-c201b87cd0d6"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","giriseAitCikislarSync_ServerSide", stokHareketID);
            }


            private static giriseAitCikislarResultItem[] giriseAitCikislarSync_ServerSide(int stokHareketID)
            {

#region giriseAitCikislarSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "giriseAitCikislar";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("stokHareketID", (object)stokHareketID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    giriseAitCikislarResultItem[] cevap = default(giriseAitCikislarResultItem[]);
                    cevap = (giriseAitCikislarResultItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion giriseAitCikislarSync_Body

            }

            public static girisiOlmayanCikislarItem[] girisiOlmayanCikislarSync(Guid siteID, int birimKayitID, int butceYili, int depoKayitNo, string butceTurID, string tasinirKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (girisiOlmayanCikislarItem[]) TTMessageFactory.SyncCall(siteID, new Guid("94eb9c2f-cab3-466e-a42c-30c2358a087f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","girisiOlmayanCikislarSync_ServerSide", birimKayitID, butceYili, depoKayitNo, butceTurID, tasinirKodu);
            }


            private static girisiOlmayanCikislarItem[] girisiOlmayanCikislarSync_ServerSide(int birimKayitID, int butceYili, int depoKayitNo, string butceTurID, string tasinirKodu)
            {

#region girisiOlmayanCikislarSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "girisiOlmayanCikislar";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("birimKayitID", (object)birimKayitID),
                        Tuple.Create("butceYili", (object)butceYili),
                        Tuple.Create("depoKayitNo", (object)depoKayitNo),
                        Tuple.Create("butceTurID", (object)butceTurID),
                        Tuple.Create("tasinirKodu", (object)tasinirKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    girisiOlmayanCikislarItem[] cevap = default(girisiOlmayanCikislarItem[]);
                    cevap = (girisiOlmayanCikislarItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion girisiOlmayanCikislarSync_Body

            }

            public static makbuzSilmeSonuc girisMakbuzDeleteSync(Guid siteID, string userName, string password, int ayniyatMakbuzID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzSilmeSonuc) TTMessageFactory.SyncCall(siteID, new Guid("3647eb40-4d0c-4d54-9e9a-6a30e5b63075"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","girisMakbuzDeleteSync_ServerSide", userName, password, ayniyatMakbuzID);
            }


            private static makbuzSilmeSonuc girisMakbuzDeleteSync_ServerSide(string userName, string password, int ayniyatMakbuzID)
            {

#region girisMakbuzDeleteSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "girisMakbuzDelete";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniyatMakbuzID", (object)ayniyatMakbuzID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzSilmeSonuc cevap = default(makbuzSilmeSonuc);
                    cevap = (makbuzSilmeSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion girisMakbuzDeleteSync_Body

            }

            public static makbuzIptalSonuc girisMakbuzIptalSync(Guid siteID, int ayniyatMakbuzID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzIptalSonuc) TTMessageFactory.SyncCall(siteID, new Guid("812176c5-030b-41dd-97c4-e0c158ae0963"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","girisMakbuzIptalSync_ServerSide", ayniyatMakbuzID);
            }


            private static makbuzIptalSonuc girisMakbuzIptalSync_ServerSide(int ayniyatMakbuzID)
            {

#region girisMakbuzIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "girisMakbuzIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniyatMakbuzID", (object)ayniyatMakbuzID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzIptalSonuc cevap = default(makbuzIptalSonuc);
                    cevap = (makbuzIptalSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion girisMakbuzIptalSync_Body

            }

            public static cikisKontrolSonuc girisMakbuzundanCikisYapilmisMi2Sync(Guid siteID, int stokHareketID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (cikisKontrolSonuc) TTMessageFactory.SyncCall(siteID, new Guid("99d52e85-5395-4ff3-b31e-88ba8198a6f2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","girisMakbuzundanCikisYapilmisMi2Sync_ServerSide", stokHareketID);
            }


            private static cikisKontrolSonuc girisMakbuzundanCikisYapilmisMi2Sync_ServerSide(int stokHareketID)
            {

#region girisMakbuzundanCikisYapilmisMi2Sync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "girisMakbuzundanCikisYapilmisMi2";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("stokHareketID", (object)stokHareketID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    cikisKontrolSonuc cevap = default(cikisKontrolSonuc);
                    cevap = (cikisKontrolSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion girisMakbuzundanCikisYapilmisMi2Sync_Body

            }

            public static cikisKontrolSonuc girisMakbuzundanCikisYapilmisMiSync(Guid siteID, int ayniyatMakbuzID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (cikisKontrolSonuc) TTMessageFactory.SyncCall(siteID, new Guid("5ddfbad5-1c5d-4d4b-a382-590e1cc1f5ba"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","girisMakbuzundanCikisYapilmisMiSync_ServerSide", ayniyatMakbuzID);
            }


            private static cikisKontrolSonuc girisMakbuzundanCikisYapilmisMiSync_ServerSide(int ayniyatMakbuzID)
            {

#region girisMakbuzundanCikisYapilmisMiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "girisMakbuzundanCikisYapilmisMi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniyatMakbuzID", (object)ayniyatMakbuzID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    cikisKontrolSonuc cevap = default(cikisKontrolSonuc);
                    cevap = (cikisKontrolSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion girisMakbuzundanCikisYapilmisMiSync_Body

            }

            public static stokHareketItem[] girisStokHareketGetSync(Guid siteID, int makbuzDetayID, int butceYili, EButceTurID butceTuru)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketItem[]) TTMessageFactory.SyncCall(siteID, new Guid("ed0ccd3c-5640-456b-b0be-07cc9ea7b22b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","girisStokHareketGetSync_ServerSide", makbuzDetayID, butceYili, butceTuru);
            }


            private static stokHareketItem[] girisStokHareketGetSync_ServerSide(int makbuzDetayID, int butceYili, EButceTurID butceTuru)
            {

#region girisStokHareketGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "girisStokHareketGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("makbuzDetayID", (object)makbuzDetayID),
                        Tuple.Create("butceYili", (object)butceYili),
                        Tuple.Create("butceTuru", (object)butceTuru),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketItem[] cevap = default(stokHareketItem[]);
                    cevap = (stokHareketItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion girisStokHareketGetSync_Body

            }

            public static malzemeItem[] guncelMalzemeGetDataSync(Guid siteID, System.DateTime guncellemeTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (malzemeItem[]) TTMessageFactory.SyncCall(siteID, new Guid("575de64e-7b48-4f13-971c-61c19eca12cb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","guncelMalzemeGetDataSync_ServerSide", guncellemeTarihi);
            }


            private static malzemeItem[] guncelMalzemeGetDataSync_ServerSide(System.DateTime guncellemeTarihi)
            {

#region guncelMalzemeGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "guncelMalzemeGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("guncellemeTarihi", (object)guncellemeTarihi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    malzemeItem[] cevap = default(malzemeItem[]);
                    cevap = (malzemeItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion guncelMalzemeGetDataSync_Body

            }

            public static ihaleTarihiUpdateResult ihaleTarihiVeNumarasiUpdateSync(Guid siteID, ihaleTarihiUpdateInsertItem item)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ihaleTarihiUpdateResult) TTMessageFactory.SyncCall(siteID, new Guid("9fab19fd-7e5a-4d06-afd8-6d974d87c77f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","ihaleTarihiVeNumarasiUpdateSync_ServerSide", item);
            }


            private static ihaleTarihiUpdateResult ihaleTarihiVeNumarasiUpdateSync_ServerSide(ihaleTarihiUpdateInsertItem item)
            {

#region ihaleTarihiVeNumarasiUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "ihaleTarihiVeNumarasiUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("item", (object)item),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    ihaleTarihiUpdateResult cevap = default(ihaleTarihiUpdateResult);
                    cevap = (ihaleTarihiUpdateResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ihaleTarihiVeNumarasiUpdateSync_Body

            }

            public static ihtiyacFazlasiItem[] ihtiyacFazlasiGetDataSync(Guid siteID, ihtiyacFazlasiKriterItem kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ihtiyacFazlasiItem[]) TTMessageFactory.SyncCall(siteID, new Guid("4380129f-4abc-4d80-bbea-609e788b0e29"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","ihtiyacFazlasiGetDataSync_ServerSide", kriter);
            }


            private static ihtiyacFazlasiItem[] ihtiyacFazlasiGetDataSync_ServerSide(ihtiyacFazlasiKriterItem kriter)
            {

#region ihtiyacFazlasiGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "ihtiyacFazlasiGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    ihtiyacFazlasiItem[] cevap = default(ihtiyacFazlasiItem[]);
                    cevap = (ihtiyacFazlasiItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ihtiyacFazlasiGetDataSync_Body

            }

            public static ihtiyacFazlasiSonuc ihtiyacFazlasiIadeSync(Guid siteID, ihtiyacFazlasiIadeItem iadeItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ihtiyacFazlasiSonuc) TTMessageFactory.SyncCall(siteID, new Guid("db473e28-30f1-4409-ac4d-3bcf17b64527"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","ihtiyacFazlasiIadeSync_ServerSide", iadeItem);
            }


            private static ihtiyacFazlasiSonuc ihtiyacFazlasiIadeSync_ServerSide(ihtiyacFazlasiIadeItem iadeItem)
            {

#region ihtiyacFazlasiIadeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "ihtiyacFazlasiIade";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("iadeItem", (object)iadeItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    ihtiyacFazlasiSonuc cevap = default(ihtiyacFazlasiSonuc);
                    cevap = (ihtiyacFazlasiSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ihtiyacFazlasiIadeSync_Body

            }

            public static ihtiyacFazlasiSonuc ihtiyacFazlasiInsertSync(Guid siteID, ihtiyacFazlasiInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ihtiyacFazlasiSonuc) TTMessageFactory.SyncCall(siteID, new Guid("b1db21ee-be53-4500-9a80-199435a08e0e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","ihtiyacFazlasiInsertSync_ServerSide", insertItem);
            }


            private static ihtiyacFazlasiSonuc ihtiyacFazlasiInsertSync_ServerSide(ihtiyacFazlasiInsertItem insertItem)
            {

#region ihtiyacFazlasiInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "ihtiyacFazlasiInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    ihtiyacFazlasiSonuc cevap = default(ihtiyacFazlasiSonuc);
                    cevap = (ihtiyacFazlasiSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ihtiyacFazlasiInsertSync_Body

            }

            public static ilacSorgulamaSonuc ilacSorgulaSync(Guid siteID, string barkod, string ilacAdi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ilacSorgulamaSonuc) TTMessageFactory.SyncCall(siteID, new Guid("0a1b192f-80cb-466f-949d-2ad392020921"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","ilacSorgulaSync_ServerSide", barkod, ilacAdi);
            }


            private static ilacSorgulamaSonuc ilacSorgulaSync_ServerSide(string barkod, string ilacAdi)
            {

#region ilacSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "ilacSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("barkod", (object)barkod),
                        Tuple.Create("ilacAdi", (object)ilacAdi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    ilacSorgulamaSonuc cevap = default(ilacSorgulamaSonuc);
                    cevap = (ilacSorgulamaSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ilacSorgulaSync_Body

            }

            public static kayittanDusmeSonuc kayittanDusmeInsertSync(Guid siteID, kayittanDusmeInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kayittanDusmeSonuc) TTMessageFactory.SyncCall(siteID, new Guid("1da248ec-a070-4b0f-af3d-1f35aa40fa66"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","kayittanDusmeInsertSync_ServerSide", insertItem);
            }


            private static kayittanDusmeSonuc kayittanDusmeInsertSync_ServerSide(kayittanDusmeInsertItem insertItem)
            {

#region kayittanDusmeInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "kayittanDusmeInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    kayittanDusmeSonuc cevap = default(kayittanDusmeSonuc);
                    cevap = (kayittanDusmeSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kayittanDusmeInsertSync_Body

            }

            public static kisiInsertSonuc kisiInsertSync(Guid siteID, kisiInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kisiInsertSonuc) TTMessageFactory.SyncCall(siteID, new Guid("f34a1f7c-293a-4b59-8d33-eaa2a838756b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","kisiInsertSync_ServerSide", insertItem);
            }


            private static kisiInsertSonuc kisiInsertSync_ServerSide(kisiInsertItem insertItem)
            {

#region kisiInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "kisiInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    kisiInsertSonuc cevap = default(kisiInsertSonuc);
                    cevap = (kisiInsertSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kisiInsertSync_Body

            }

            public static kisiKontrolSonuc kisiVarMiSync(Guid siteID, string kisiTCKimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kisiKontrolSonuc) TTMessageFactory.SyncCall(siteID, new Guid("ccef9e66-d5b2-403d-a8a4-eaa653315f89"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","kisiVarMiSync_ServerSide", kisiTCKimlikNo);
            }


            private static kisiKontrolSonuc kisiVarMiSync_ServerSide(string kisiTCKimlikNo)
            {

#region kisiVarMiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "kisiVarMi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kisiTCKimlikNo", (object)kisiTCKimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    kisiKontrolSonuc cevap = default(kisiKontrolSonuc);
                    cevap = (kisiKontrolSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kisiVarMiSync_Body

            }

            public static kitapInsertUpdateSonuc kitapInsertUpdateSync(Guid siteID, kitapInsertUpdateItem insertUpdateItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kitapInsertUpdateSonuc) TTMessageFactory.SyncCall(siteID, new Guid("48a40501-853c-431a-8617-e2eb8aba58d8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","kitapInsertUpdateSync_ServerSide", insertUpdateItem);
            }


            private static kitapInsertUpdateSonuc kitapInsertUpdateSync_ServerSide(kitapInsertUpdateItem insertUpdateItem)
            {

#region kitapInsertUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "kitapInsertUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertUpdateItem", (object)insertUpdateItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    kitapInsertUpdateSonuc cevap = default(kitapInsertUpdateSonuc);
                    cevap = (kitapInsertUpdateSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kitapInsertUpdateSync_Body

            }

            public static kurumlardanGelenDevirItem[] kurumlardanGelenDevirlerGetDataSync(Guid siteID, string userName, string password, kurumlardanGelenDevirKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kurumlardanGelenDevirItem[]) TTMessageFactory.SyncCall(siteID, new Guid("22d7bd53-d8a7-4032-8547-1fa9f8f9e8c0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","kurumlardanGelenDevirlerGetDataSync_ServerSide", userName, password, kriter);
            }


            private static kurumlardanGelenDevirItem[] kurumlardanGelenDevirlerGetDataSync_ServerSide(string userName, string password, kurumlardanGelenDevirKriter kriter)
            {

#region kurumlardanGelenDevirlerGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "kurumlardanGelenDevirlerGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    kurumlardanGelenDevirItem[] cevap = default(kurumlardanGelenDevirItem[]);
                    cevap = (kurumlardanGelenDevirItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kurumlardanGelenDevirlerGetDataSync_Body

            }

            public static girisMakbuzDetayItem[] makbuzDetayGetDataSync(Guid siteID, string userName, string password, int ayniyatMakbuzID, int butceYili, EButceTurID butceTuru)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (girisMakbuzDetayItem[]) TTMessageFactory.SyncCall(siteID, new Guid("55e29e87-c2c9-4b7d-aef1-d4eb2ae2fc59"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","makbuzDetayGetDataSync_ServerSide", userName, password, ayniyatMakbuzID, butceYili, butceTuru);
            }


            private static girisMakbuzDetayItem[] makbuzDetayGetDataSync_ServerSide(string userName, string password, int ayniyatMakbuzID, int butceYili, EButceTurID butceTuru)
            {

#region makbuzDetayGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "makbuzDetayGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniyatMakbuzID", (object)ayniyatMakbuzID),
                        Tuple.Create("butceYili", (object)butceYili),
                        Tuple.Create("butceTuru", (object)butceTuru),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    girisMakbuzDetayItem[] cevap = default(girisMakbuzDetayItem[]);
                    cevap = (girisMakbuzDetayItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion makbuzDetayGetDataSync_Body

            }

            public static makbuzDetayInsertGirisSonuc makbuzDetayInsertGirisSync(Guid siteID, makbuzDetayInsertGirisItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzDetayInsertGirisSonuc) TTMessageFactory.SyncCall(siteID, new Guid("85893253-516a-49a8-9bbc-fe38642a957d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","makbuzDetayInsertGirisSync_ServerSide", insertItem);
            }


            private static makbuzDetayInsertGirisSonuc makbuzDetayInsertGirisSync_ServerSide(makbuzDetayInsertGirisItem insertItem)
            {

#region makbuzDetayInsertGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "makbuzDetayInsertGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzDetayInsertGirisSonuc cevap = default(makbuzDetayInsertGirisSonuc);
                    cevap = (makbuzDetayInsertGirisSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion makbuzDetayInsertGirisSync_Body

            }

            public static makbuzInsertCikisSonuc makbuzInsertCikisSync(Guid siteID, string userName, string password, makbuzInsertCikisItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzInsertCikisSonuc) TTMessageFactory.SyncCall(siteID, new Guid("6923fdc5-853c-4d52-a7de-54ab36eedb27"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","makbuzInsertCikisSync_ServerSide", userName, password, insertItem);
            }


            private static makbuzInsertCikisSonuc makbuzInsertCikisSync_ServerSide(string userName, string password, makbuzInsertCikisItem insertItem)
            {

#region makbuzInsertCikisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "makbuzInsertCikis";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzInsertCikisSonuc cevap = default(makbuzInsertCikisSonuc);
                    cevap = (makbuzInsertCikisSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion makbuzInsertCikisSync_Body

            }

            public static makbuzInsertGirisSonuc makbuzInsertGirisSync(Guid siteID, string userName, string password, makbuzInsertGirisItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzInsertGirisSonuc) TTMessageFactory.SyncCall(siteID, new Guid("467aef9c-a7ed-47c6-8586-89dfc52e508a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","makbuzInsertGirisSync_ServerSide", userName, password, insertItem);
            }


            private static makbuzInsertGirisSonuc makbuzInsertGirisSync_ServerSide(string userName, string password, makbuzInsertGirisItem insertItem)
            {

#region makbuzInsertGirisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "makbuzInsertGiris";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzInsertGirisSonuc cevap = default(makbuzInsertGirisSonuc);
                    cevap = (makbuzInsertGirisSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion makbuzInsertGirisSync_Body

            }

            public static girisMakbuzItem makbuzSelectSync(Guid siteID, int ayniyatMakbuzID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (girisMakbuzItem) TTMessageFactory.SyncCall(siteID, new Guid("0033ada9-abe1-4551-b3c6-ac3ee040b43d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","makbuzSelectSync_ServerSide", ayniyatMakbuzID);
            }


            private static girisMakbuzItem makbuzSelectSync_ServerSide(int ayniyatMakbuzID)
            {

#region makbuzSelectSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "makbuzSelect";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniyatMakbuzID", (object)ayniyatMakbuzID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    girisMakbuzItem cevap = default(girisMakbuzItem);
                    cevap = (girisMakbuzItem)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion makbuzSelectSync_Body

            }

            public static mkysSonuc makbuzUpdateSync(Guid siteID, string userName, string password, ayniyatMakbuzuUpdateItem[] makbuz)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (mkysSonuc) TTMessageFactory.SyncCall(siteID, new Guid("d84e3625-5bf9-4cf8-bb01-1e5a94d2d995"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","makbuzUpdateSync_ServerSide", userName, password, makbuz);
            }


            private static mkysSonuc makbuzUpdateSync_ServerSide(string userName, string password, ayniyatMakbuzuUpdateItem[] makbuz)
            {

#region makbuzUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "makbuzUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("makbuz", (object)makbuz),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    mkysSonuc cevap = default(mkysSonuc);
                    cevap = (mkysSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion makbuzUpdateSync_Body

            }

            public static makbuzKontrolSonuc makbuzVarMiSync(Guid siteID, int ayniyatMakbuzID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (makbuzKontrolSonuc) TTMessageFactory.SyncCall(siteID, new Guid("d21841f7-40cf-44ee-b2e0-e36f505f3972"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","makbuzVarMiSync_ServerSide", ayniyatMakbuzID);
            }


            private static makbuzKontrolSonuc makbuzVarMiSync_ServerSide(int ayniyatMakbuzID)
            {

#region makbuzVarMiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "makbuzVarMi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniyatMakbuzID", (object)ayniyatMakbuzID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    makbuzKontrolSonuc cevap = default(makbuzKontrolSonuc);
                    cevap = (makbuzKontrolSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion makbuzVarMiSync_Body

            }

            public static mkysSonuc malzemeBilgileriUpdateSync(Guid siteID, malzemeBilgileriUpdateItem[] item)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (mkysSonuc) TTMessageFactory.SyncCall(siteID, new Guid("42af44a6-4aa1-485a-a920-6545da8fa127"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","malzemeBilgileriUpdateSync_ServerSide", item);
            }


            private static mkysSonuc malzemeBilgileriUpdateSync_ServerSide(malzemeBilgileriUpdateItem[] item)
            {

#region malzemeBilgileriUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "malzemeBilgileriUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("item", (object)item),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    mkysSonuc cevap = default(mkysSonuc);
                    cevap = (mkysSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion malzemeBilgileriUpdateSync_Body

            }

            public static malzemeItem[] malzemeGetDataSync(Guid siteID, System.DateTime gunlemeTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (malzemeItem[]) TTMessageFactory.SyncCall(siteID, new Guid("aae89710-694e-4bc4-9122-d98e5d561577"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","malzemeGetDataSync_ServerSide", gunlemeTarihi);
            }


            private static malzemeItem[] malzemeGetDataSync_ServerSide(System.DateTime gunlemeTarihi)
            {

#region malzemeGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "malzemeGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("gunlemeTarihi", (object)gunlemeTarihi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    malzemeItem[] cevap = default(malzemeItem[]);
                    cevap = (malzemeItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion malzemeGetDataSync_Body

            }

            public static stokHareketYilSonuItem[] malzemeIDFarkliStoklarGetDataSync(Guid siteID, yilSonuKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketYilSonuItem[]) TTMessageFactory.SyncCall(siteID, new Guid("18e98c95-bda7-43f9-8bbd-d0cf9a41ef76"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","malzemeIDFarkliStoklarGetDataSync_ServerSide", kriter);
            }


            private static stokHareketYilSonuItem[] malzemeIDFarkliStoklarGetDataSync_ServerSide(yilSonuKriter kriter)
            {

#region malzemeIDFarkliStoklarGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "malzemeIDFarkliStoklarGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketYilSonuItem[] cevap = default(stokHareketYilSonuItem[]);
                    cevap = (stokHareketYilSonuItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion malzemeIDFarkliStoklarGetDataSync_Body

            }

            public static malzemeSiniflandirmaItem[] malzemeSiniflandirmaGetDataSync(Guid siteID, System.DateTime degisiklikTarihi, EDepoTurId depoTuru)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (malzemeSiniflandirmaItem[]) TTMessageFactory.SyncCall(siteID, new Guid("16a69507-b883-4517-853b-7c1b77692265"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","malzemeSiniflandirmaGetDataSync_ServerSide", degisiklikTarihi, depoTuru);
            }


            private static malzemeSiniflandirmaItem[] malzemeSiniflandirmaGetDataSync_ServerSide(System.DateTime degisiklikTarihi, EDepoTurId depoTuru)
            {

#region malzemeSiniflandirmaGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "malzemeSiniflandirmaGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("degisiklikTarihi", (object)degisiklikTarihi),
                        Tuple.Create("depoTuru", (object)depoTuru),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    malzemeSiniflandirmaItem[] cevap = default(malzemeSiniflandirmaItem[]);
                    cevap = (malzemeSiniflandirmaItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion malzemeSiniflandirmaGetDataSync_Body

            }

            public static malzemeTibbiSarfItem[] malzemetibbiSarfGetDataSync(Guid siteID, string userName, string password, System.DateTime degisiklikTarihi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (malzemeTibbiSarfItem[]) TTMessageFactory.SyncCall(siteID, new Guid("ee2529d0-a311-4d3c-bc05-7747babc0ee5"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","malzemetibbiSarfGetDataSync_ServerSide", userName, password, degisiklikTarihi);
            }


            private static malzemeTibbiSarfItem[] malzemetibbiSarfGetDataSync_ServerSide(string userName, string password, System.DateTime degisiklikTarihi)
            {

#region malzemetibbiSarfGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "malzemetibbiSarfGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("degisiklikTarihi", (object)degisiklikTarihi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    malzemeTibbiSarfItem[] cevap = default(malzemeTibbiSarfItem[]);
                    cevap = (malzemeTibbiSarfItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion malzemetibbiSarfGetDataSync_Body

            }

            public static malzemeZimmetBilgisiResult[] malzemeZimmetBilgisiSync(Guid siteID, int depoKayitNo, int stokHareketID, int butceYili)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (malzemeZimmetBilgisiResult[]) TTMessageFactory.SyncCall(siteID, new Guid("01c8d777-a410-4cc7-bddd-83d685d5ebd9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","malzemeZimmetBilgisiSync_ServerSide", depoKayitNo, stokHareketID, butceYili);
            }


            private static malzemeZimmetBilgisiResult[] malzemeZimmetBilgisiSync_ServerSide(int depoKayitNo, int stokHareketID, int butceYili)
            {

#region malzemeZimmetBilgisiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "malzemeZimmetBilgisi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("depoKayitNo", (object)depoKayitNo),
                        Tuple.Create("stokHareketID", (object)stokHareketID),
                        Tuple.Create("butceYili", (object)butceYili),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    malzemeZimmetBilgisiResult[] cevap = default(malzemeZimmetBilgisiResult[]);
                    cevap = (malzemeZimmetBilgisiResult[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion malzemeZimmetBilgisiSync_Body

            }

            public static mukerrerStokHareketItem[] mukerrerCikisGetDataSync(Guid siteID, int butceYili, int depoKayitNo, string butceTurID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (mukerrerStokHareketItem[]) TTMessageFactory.SyncCall(siteID, new Guid("0efe1f51-3f94-470e-9bf7-3768fb399f8a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","mukerrerCikisGetDataSync_ServerSide", butceYili, depoKayitNo, butceTurID);
            }


            private static mukerrerStokHareketItem[] mukerrerCikisGetDataSync_ServerSide(int butceYili, int depoKayitNo, string butceTurID)
            {

#region mukerrerCikisGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "mukerrerCikisGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("butceYili", (object)butceYili),
                        Tuple.Create("depoKayitNo", (object)depoKayitNo),
                        Tuple.Create("butceTurID", (object)butceTurID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    mukerrerStokHareketItem[] cevap = default(mukerrerStokHareketItem[]);
                    cevap = (mukerrerStokHareketItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion mukerrerCikisGetDataSync_Body

            }

            public static ntKodItem[] ntKodGetDataSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ntKodItem[]) TTMessageFactory.SyncCall(siteID, new Guid("c36093d0-e52a-4e80-a08c-e4902539786a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","ntKodGetDataSync_ServerSide");
            }


            private static ntKodItem[] ntKodGetDataSync_ServerSide()
            {

#region ntKodGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "ntKodGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    ntKodItem[] cevap = default(ntKodItem[]);
                    cevap = (ntKodItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ntKodGetDataSync_Body

            }

            public static string saglik_Calisani_MiSync(Guid siteID, string kisiTCKimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("0f455652-56c5-4bba-bb24-08263f5b721c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","saglik_Calisani_MiSync_ServerSide", kisiTCKimlikNo);
            }


            private static string saglik_Calisani_MiSync_ServerSide(string kisiTCKimlikNo)
            {

#region saglik_Calisani_MiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "saglik_Calisani_Mi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kisiTCKimlikNo", (object)kisiTCKimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion saglik_Calisani_MiSync_Body

            }

            public static yetkiKontrolSonuc servisYetkiKontrolSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (yetkiKontrolSonuc) TTMessageFactory.SyncCall(siteID, new Guid("a408fea5-b0a3-4340-8c2d-7999732b0c94"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","servisYetkiKontrolSync_ServerSide");
            }


            private static yetkiKontrolSonuc servisYetkiKontrolSync_ServerSide()
            {

#region servisYetkiKontrolSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "servisYetkiKontrol";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    yetkiKontrolSonuc cevap = default(yetkiKontrolSonuc);
                    cevap = (yetkiKontrolSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion servisYetkiKontrolSync_Body

            }

            public static mkysSonuc sonKullanmaTarihiUpdateSync(Guid siteID, string userName, string password, sonKullanmaUpdateInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (mkysSonuc) TTMessageFactory.SyncCall(siteID, new Guid("63113caf-e710-4a33-837e-7364a480d4ce"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","sonKullanmaTarihiUpdateSync_ServerSide", userName, password, insertItem);
            }


            private static mkysSonuc sonKullanmaTarihiUpdateSync_ServerSide(string userName, string password, sonKullanmaUpdateInsertItem insertItem)
            {

#region sonKullanmaTarihiUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "sonKullanmaTarihiUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    mkysSonuc cevap = default(mkysSonuc);
                    cevap = (mkysSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sonKullanmaTarihiUpdateSync_Body

            }

            public static stokHareketYilSonuItem[] stokDurumGetDataSync(Guid siteID, yilSonuKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketYilSonuItem[]) TTMessageFactory.SyncCall(siteID, new Guid("4578b0fa-7373-4af6-826d-257ed3054ac2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokDurumGetDataSync_ServerSide", kriter);
            }


            private static stokHareketYilSonuItem[] stokDurumGetDataSync_ServerSide(yilSonuKriter kriter)
            {

#region stokDurumGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokDurumGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketYilSonuItem[] cevap = default(stokHareketYilSonuItem[]);
                    cevap = (stokHareketYilSonuItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokDurumGetDataSync_Body

            }

            public static stokHareketSilSonuc stokHareketDeleteSync(Guid siteID, int stokHareketID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketSilSonuc) TTMessageFactory.SyncCall(siteID, new Guid("89baaf93-4a0b-4675-a6bc-8a39b1021d11"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokHareketDeleteSync_ServerSide", stokHareketID);
            }


            private static stokHareketSilSonuc stokHareketDeleteSync_ServerSide(int stokHareketID)
            {

#region stokHareketDeleteSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokHareketDelete";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("stokHareketID", (object)stokHareketID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketSilSonuc cevap = default(stokHareketSilSonuc);
                    cevap = (stokHareketSilSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokHareketDeleteSync_Body

            }

            public static stokHareketItem[] stokHareketGetDataSync(Guid siteID, stokHareketKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketItem[]) TTMessageFactory.SyncCall(siteID, new Guid("98c5d580-ca84-4956-8564-db11152ac645"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokHareketGetDataSync_ServerSide", kriter);
            }


            private static stokHareketItem[] stokHareketGetDataSync_ServerSide(stokHareketKriter kriter)
            {

#region stokHareketGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokHareketGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketItem[] cevap = default(stokHareketItem[]);
                    cevap = (stokHareketItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokHareketGetDataSync_Body

            }

            public static stokHareketLogItem[] stokHareketGirisLogGetDataSync(Guid siteID, string userName, string password, int ayniatMakbuzID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketLogItem[]) TTMessageFactory.SyncCall(siteID, new Guid("e2415afe-df1b-40d8-8630-da5ec0e73a53"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokHareketGirisLogGetDataSync_ServerSide", userName, password, ayniatMakbuzID);
            }


            private static stokHareketLogItem[] stokHareketGirisLogGetDataSync_ServerSide(string userName, string password, int ayniatMakbuzID)
            {

#region stokHareketGirisLogGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokHareketGirisLogGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniatMakbuzID", (object)ayniatMakbuzID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketLogItem[] cevap = default(stokHareketLogItem[]);
                    cevap = (stokHareketLogItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokHareketGirisLogGetDataSync_Body

            }

            public static stokHareketLogItem[] stokHareketLogGetDataSync(Guid siteID, int stokHareketID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokHareketLogItem[]) TTMessageFactory.SyncCall(siteID, new Guid("fcd1f03c-ba15-48c9-98cd-d3b86617778b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokHareketLogGetDataSync_ServerSide", stokHareketID);
            }


            private static stokHareketLogItem[] stokHareketLogGetDataSync_ServerSide(int stokHareketID)
            {

#region stokHareketLogGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokHareketLogGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("stokHareketID", (object)stokHareketID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokHareketLogItem[] cevap = default(stokHareketLogItem[]);
                    cevap = (stokHareketLogItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokHareketLogGetDataSync_Body

            }

            public static mkysSonuc stokHareketUpdateSync(Guid siteID, string userName, string password, stokHareketUpdateItem[] stok)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (mkysSonuc) TTMessageFactory.SyncCall(siteID, new Guid("ca5aff4a-1a52-492b-829c-2d9065b94db0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokHareketUpdateSync_ServerSide", userName, password, stok);
            }


            private static mkysSonuc stokHareketUpdateSync_ServerSide(string userName, string password, stokHareketUpdateItem[] stok)
            {

#region stokHareketUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokHareketUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("stok", (object)stok),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    mkysSonuc cevap = default(mkysSonuc);
                    cevap = (mkysSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokHareketUpdateSync_Body

            }

            public static stokSeviyesiInsertSonuc stokSeviyesiInsertSync(Guid siteID, stokSeviyesiInsertItem item)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (stokSeviyesiInsertSonuc) TTMessageFactory.SyncCall(siteID, new Guid("9d92ab79-1247-4165-8461-5e0b74e889a9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokSeviyesiInsertSync_ServerSide", item);
            }


            private static stokSeviyesiInsertSonuc stokSeviyesiInsertSync_ServerSide(stokSeviyesiInsertItem item)
            {

#region stokSeviyesiInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokSeviyesiInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("item", (object)item),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    stokSeviyesiInsertSonuc cevap = default(stokSeviyesiInsertSonuc);
                    cevap = (stokSeviyesiInsertSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokSeviyesiInsertSync_Body

            }

            public static mkysSonuc stokTedarikTuruUpdateSync(Guid siteID, int ayniyatMakbuzID, ETedarikTurID tedarikTuru, EGirisStokHareketTurID stokHareketTuru)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (mkysSonuc) TTMessageFactory.SyncCall(siteID, new Guid("397068fe-1588-4812-9c86-a9b7d746648e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","stokTedarikTuruUpdateSync_ServerSide", ayniyatMakbuzID, tedarikTuru, stokHareketTuru);
            }


            private static mkysSonuc stokTedarikTuruUpdateSync_ServerSide(int ayniyatMakbuzID, ETedarikTurID tedarikTuru, EGirisStokHareketTurID stokHareketTuru)
            {

#region stokTedarikTuruUpdateSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "stokTedarikTuruUpdate";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ayniyatMakbuzID", (object)ayniyatMakbuzID),
                        Tuple.Create("tedarikTuru", (object)tedarikTuru),
                        Tuple.Create("stokHareketTuru", (object)stokHareketTuru),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    mkysSonuc cevap = default(mkysSonuc);
                    cevap = (mkysSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion stokTedarikTuruUpdateSync_Body

            }

            public static malzemeTeknikOzellikResult tibbiCihazTeknikOzellikInsertSync(Guid siteID, teknikOzellikInsertItem[] item, int birimDepoID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (malzemeTeknikOzellikResult) TTMessageFactory.SyncCall(siteID, new Guid("cd2b0673-3e19-4c7b-95c4-b54134138143"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","tibbiCihazTeknikOzellikInsertSync_ServerSide", item, birimDepoID);
            }


            private static malzemeTeknikOzellikResult tibbiCihazTeknikOzellikInsertSync_ServerSide(teknikOzellikInsertItem[] item, int birimDepoID)
            {

#region tibbiCihazTeknikOzellikInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "tibbiCihazTeknikOzellikInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("item", (object)item),
                        Tuple.Create("birimDepoID", (object)birimDepoID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    malzemeTeknikOzellikResult cevap = default(malzemeTeknikOzellikResult);
                    cevap = (malzemeTeknikOzellikResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion tibbiCihazTeknikOzellikInsertSync_Body

            }

            public static birimItem[] tumBirimlerGetDataSync(Guid siteID, string birimAdi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (birimItem[]) TTMessageFactory.SyncCall(siteID, new Guid("57467381-a736-436d-afca-8db5aea12088"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","tumBirimlerGetDataSync_ServerSide", birimAdi);
            }


            private static birimItem[] tumBirimlerGetDataSync_ServerSide(string birimAdi)
            {

#region tumBirimlerGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "tumBirimlerGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("birimAdi", (object)birimAdi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    birimItem[] cevap = default(birimItem[]);
                    cevap = (birimItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion tumBirimlerGetDataSync_Body

            }

            public static universiteXXXXXXleriSonucItem[] universiteXXXXXXleriGetDataSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (universiteXXXXXXleriSonucItem[]) TTMessageFactory.SyncCall(siteID, new Guid("382be6d1-e762-4e26-9362-5f681bf994a9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","universiteXXXXXXleriGetDataSync_ServerSide");
            }


            private static universiteXXXXXXleriSonucItem[] universiteXXXXXXleriGetDataSync_ServerSide()
            {

#region universiteXXXXXXleriGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "universiteXXXXXXleriGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    universiteXXXXXXleriSonucItem[] cevap = default(universiteXXXXXXleriSonucItem[]);
                    cevap = (universiteXXXXXXleriSonucItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion universiteXXXXXXleriGetDataSync_Body

            }

            public static unvanTurItem[] unvanTurGetDataSync(Guid siteID, string unvanAdi)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (unvanTurItem[]) TTMessageFactory.SyncCall(siteID, new Guid("c4c9e17e-2d31-4c81-9a6a-015999604bbe"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","unvanTurGetDataSync_ServerSide", unvanAdi);
            }


            private static unvanTurItem[] unvanTurGetDataSync_ServerSide(string unvanAdi)
            {

#region unvanTurGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "unvanTurGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("unvanAdi", (object)unvanAdi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    unvanTurItem[] cevap = default(unvanTurItem[]);
                    cevap = (unvanTurItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion unvanTurGetDataSync_Body

            }

            public static yilSonuDevriSonucItem[] yilSonuDevirDetayBilgileriSync(Guid siteID, yilSonuDevriItem item)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (yilSonuDevriSonucItem[]) TTMessageFactory.SyncCall(siteID, new Guid("00f8479e-1a6b-4232-b0fa-4af446c42cfe"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","yilSonuDevirDetayBilgileriSync_ServerSide", item);
            }


            private static yilSonuDevriSonucItem[] yilSonuDevirDetayBilgileriSync_ServerSide(yilSonuDevriItem item)
            {

#region yilSonuDevirDetayBilgileriSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "yilSonuDevirDetayBilgileri";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("item", (object)item),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    yilSonuDevriSonucItem[] cevap = default(yilSonuDevriSonucItem[]);
                    cevap = (yilSonuDevriSonucItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion yilSonuDevirDetayBilgileriSync_Body

            }

            public static yonetimHesabiCetveliItem[] yonetimHesabiCetveliGetDataSync(Guid siteID, string userName, string password, yonetimHesabiKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (yonetimHesabiCetveliItem[]) TTMessageFactory.SyncCall(siteID, new Guid("890b494f-1314-4b74-a78a-236356414962"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","yonetimHesabiCetveliGetDataSync_ServerSide", userName, password, kriter);
            }


            private static yonetimHesabiCetveliItem[] yonetimHesabiCetveliGetDataSync_ServerSide(string userName, string password, yonetimHesabiKriter kriter)
            {

#region yonetimHesabiCetveliGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "yonetimHesabiCetveliGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    yonetimHesabiCetveliItem[] cevap = default(yonetimHesabiCetveliItem[]);
                    cevap = (yonetimHesabiCetveliItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion yonetimHesabiCetveliGetDataSync_Body

            }

            public static zimmetInsertSonuc zimmetInsertSync(Guid siteID, zimmetInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (zimmetInsertSonuc) TTMessageFactory.SyncCall(siteID, new Guid("713c1f75-7987-47d1-b91a-973a42e929f2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","zimmetInsertSync_ServerSide", insertItem);
            }


            private static zimmetInsertSonuc zimmetInsertSync_ServerSide(zimmetInsertItem insertItem)
            {

#region zimmetInsertSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "zimmetInsert";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    zimmetInsertSonuc cevap = default(zimmetInsertSonuc);
                    cevap = (zimmetInsertSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion zimmetInsertSync_Body

            }

            public static zimmetListesiGetDataResultItem[] zimmetListesiDetayGetDataSync(Guid siteID, zimmetListesiGetItem item)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (zimmetListesiGetDataResultItem[]) TTMessageFactory.SyncCall(siteID, new Guid("ab0c75c9-e944-4e0f-b050-c1bf07d45c95"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","zimmetListesiDetayGetDataSync_ServerSide", item);
            }


            private static zimmetListesiGetDataResultItem[] zimmetListesiDetayGetDataSync_ServerSide(zimmetListesiGetItem item)
            {

#region zimmetListesiDetayGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "zimmetListesiDetayGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("item", (object)item),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    zimmetListesiGetDataResultItem[] cevap = default(zimmetListesiGetDataResultItem[]);
                    cevap = (zimmetListesiGetDataResultItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion zimmetListesiDetayGetDataSync_Body

            }

            public static zimmetItem[] zimmetListesiGetDataSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (zimmetItem[]) TTMessageFactory.SyncCall(siteID, new Guid("b1948c58-a863-40da-924e-710eed6f196a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","zimmetListesiGetDataSync_ServerSide");
            }


            private static zimmetItem[] zimmetListesiGetDataSync_ServerSide()
            {

#region zimmetListesiGetDataSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "zimmetListesiGetData";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    zimmetItem[] cevap = default(zimmetItem[]);
                    cevap = (zimmetItem[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion zimmetListesiGetDataSync_Body

            }

            public static zimmettenAlSonuc zimmettenAlSync(Guid siteID, zimmettenAlInsertItem insertItem)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (zimmettenAlSonuc) TTMessageFactory.SyncCall(siteID, new Guid("44bf1023-a908-484b-b05b-93311ae8f125"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MkysServis+WebMethods, TTObjectClasses","zimmettenAlSync_ServerSide", insertItem);
            }


            private static zimmettenAlSonuc zimmettenAlSync_ServerSide(zimmettenAlInsertItem insertItem)
            {

#region zimmettenAlSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MkysServis";
                    header.ServiceId = "ba514bb7-ca3d-4554-91af-222192a7d281";
                    header.MethodName = "zimmettenAl";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("insertItem", (object)insertItem),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["MKYSPASSWORD"];
                    credential.FirmUserName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMUSERNAME","");
                    credential.FirmPassword = TTObjectClasses.SystemParameter.GetParameterValue("MKYSFIRMPASSWORD","");

                    zimmettenAlSonuc cevap = default(zimmettenAlSonuc);
                    cevap = (zimmettenAlSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion zimmettenAlSync_Body

            }

        }
                    
        protected MkysServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MkysServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MkysServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MkysServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MkysServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MKYSSERVIS", dataRow) { }
        protected MkysServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MKYSSERVIS", dataRow, isImported) { }
        public MkysServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MkysServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MkysServis() : base() { }

    }
}