
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXXXXIHEWS")] 

    public  partial class XXXXXXIHEWS : TTObject
    {
        public class XXXXXXIHEWSList : TTObjectCollection<XXXXXXIHEWS> { }
                    
        public class ChildXXXXXXIHEWSCollection : TTObject.TTChildObjectCollection<XXXXXXIHEWS>
        {
            public ChildXXXXXXIHEWSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXXXXIHEWSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static string AlisSonucLinkBulSync(Guid siteID, string VENUSER, string VENPASS, string PATIENT_ID, string VISIT_NUMBER, string SPECIMEN_ID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("bf149179-67aa-46e3-9b6a-d6e08ccf4482"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","AlisSonucLinkBulSync_ServerSide", VENUSER, VENPASS, PATIENT_ID, VISIT_NUMBER, SPECIMEN_ID);
            }


            private static string AlisSonucLinkBulSync_ServerSide(string VENUSER, string VENPASS, string PATIENT_ID, string VISIT_NUMBER, string SPECIMEN_ID)
            {

#region AlisSonucLinkBulSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "AlisSonucLinkBul";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("VENUSER", (object)VENUSER),
                        Tuple.Create("VENPASS", (object)VENPASS),
                        Tuple.Create("PATIENT_ID", (object)PATIENT_ID),
                        Tuple.Create("VISIT_NUMBER", (object)VISIT_NUMBER),
                        Tuple.Create("SPECIMEN_ID", (object)SPECIMEN_ID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion AlisSonucLinkBulSync_Body

            }

            public static HastaKanIstemler HastaKanIstemGetirSync(Guid siteID, string AramaKr1, string AramaKr1Tip, string AramaKr2, string AramaKr2Tip, string AramaKr3, string AramaKr3Tip)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HastaKanIstemler) TTMessageFactory.SyncCall(siteID, new Guid("b8d01fb0-819a-4ba9-a307-a45db930aca1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","HastaKanIstemGetirSync_ServerSide", AramaKr1, AramaKr1Tip, AramaKr2, AramaKr2Tip, AramaKr3, AramaKr3Tip);
            }


            private static HastaKanIstemler HastaKanIstemGetirSync_ServerSide(string AramaKr1, string AramaKr1Tip, string AramaKr2, string AramaKr2Tip, string AramaKr3, string AramaKr3Tip)
            {

#region HastaKanIstemGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "HastaKanIstemGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("AramaKr1", (object)AramaKr1),
                        Tuple.Create("AramaKr1Tip", (object)AramaKr1Tip),
                        Tuple.Create("AramaKr2", (object)AramaKr2),
                        Tuple.Create("AramaKr2Tip", (object)AramaKr2Tip),
                        Tuple.Create("AramaKr3", (object)AramaKr3),
                        Tuple.Create("AramaKr3Tip", (object)AramaKr3Tip),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    HastaKanIstemler cevap = default(HastaKanIstemler);
                    cevap = (HastaKanIstemler)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HastaKanIstemGetirSync_Body

            }

            public static HazirOrnekler HazirOrnekleriGetirDisLabSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HazirOrnekler) TTMessageFactory.SyncCall(siteID, new Guid("a898faea-3ee8-45d7-ab2b-63c785daf7e4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","HazirOrnekleriGetirDisLabSync_ServerSide");
            }


            private static HazirOrnekler HazirOrnekleriGetirDisLabSync_ServerSide()
            {

#region HazirOrnekleriGetirDisLabSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "HazirOrnekleriGetirDisLab";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    HazirOrnekler cevap = default(HazirOrnekler);
                    cevap = (HazirOrnekler)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HazirOrnekleriGetirDisLabSync_Body

            }

            public static HazirOrnekler HazirOrnekleriGetirLabSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HazirOrnekler) TTMessageFactory.SyncCall(siteID, new Guid("7e2dbee2-aea2-4d5e-8f2b-46c4cb63b0e8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","HazirOrnekleriGetirLabSync_ServerSide");
            }


            private static HazirOrnekler HazirOrnekleriGetirLabSync_ServerSide()
            {

#region HazirOrnekleriGetirLabSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "HazirOrnekleriGetirLab";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    HazirOrnekler cevap = default(HazirOrnekler);
                    cevap = (HazirOrnekler)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HazirOrnekleriGetirLabSync_Body

            }

            public static HazirOrnekler HazirOrnekleriGetirSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HazirOrnekler) TTMessageFactory.SyncCall(siteID, new Guid("f2b45a1c-ee07-44ef-a229-00fa8094de29"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","HazirOrnekleriGetirSync_ServerSide");
            }


            private static HazirOrnekler HazirOrnekleriGetirSync_ServerSide()
            {

#region HazirOrnekleriGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "HazirOrnekleriGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    HazirOrnekler cevap = default(HazirOrnekler);
                    cevap = (HazirOrnekler)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HazirOrnekleriGetirSync_Body

            }

            public static HazirUrunler HazirUrunleriGetirSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HazirUrunler) TTMessageFactory.SyncCall(siteID, new Guid("769eb47e-83fb-4b28-8435-b0757c20911c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","HazirUrunleriGetirSync_ServerSide");
            }


            private static HazirUrunler HazirUrunleriGetirSync_ServerSide()
            {

#region HazirUrunleriGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "HazirUrunleriGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    HazirUrunler cevap = default(HazirUrunler);
                    cevap = (HazirUrunler)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HazirUrunleriGetirSync_Body

            }

            public static int HazirUrunListedenKaldirSync(Guid siteID, HazirUrun hu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("015398cb-cf12-48dc-85c3-28d8de98d558"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","HazirUrunListedenKaldirSync_ServerSide", hu);
            }


            private static int HazirUrunListedenKaldirSync_ServerSide(HazirUrun hu)
            {

#region HazirUrunListedenKaldirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "HazirUrunListedenKaldir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hu", (object)hu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HazirUrunListedenKaldirSync_Body

            }

            public static string KurumOrnekGetirSync(Guid siteID, string UserName, string PassWord, string KurumKodu, string CalisKurumKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("df20c7b2-8d83-4394-a529-d9fed4d59e42"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","KurumOrnekGetirSync_ServerSide", UserName, PassWord, KurumKodu, CalisKurumKodu);
            }


            private static string KurumOrnekGetirSync_ServerSide(string UserName, string PassWord, string KurumKodu, string CalisKurumKodu)
            {

#region KurumOrnekGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "KurumOrnekGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("KurumKodu", (object)KurumKodu),
                        Tuple.Create("CalisKurumKodu", (object)CalisKurumKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumOrnekGetirSync_Body

            }

            public static string KurumOrnekSorgulandi_YeniSync(Guid siteID, string UserName, string PassWord, string barkodno, string KurumKodu, string CalisKurumKodu, int basarili)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("23382c0a-f0ba-4e0b-921a-aeadb21633c6"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","KurumOrnekSorgulandi_YeniSync_ServerSide", UserName, PassWord, barkodno, KurumKodu, CalisKurumKodu, basarili);
            }


            private static string KurumOrnekSorgulandi_YeniSync_ServerSide(string UserName, string PassWord, string barkodno, string KurumKodu, string CalisKurumKodu, int basarili)
            {

#region KurumOrnekSorgulandi_YeniSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "KurumOrnekSorgulandi_Yeni";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("barkodno", (object)barkodno),
                        Tuple.Create("KurumKodu", (object)KurumKodu),
                        Tuple.Create("CalisKurumKodu", (object)CalisKurumKodu),
                        Tuple.Create("basarili", (object)basarili),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumOrnekSorgulandi_YeniSync_Body

            }

            public static string KurumOrnekSorgulandiSync(Guid siteID, string UserName, string PassWord, string barkodno, string KurumKodu, string CalisKurumKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("2d36da38-285d-4a1c-a9a6-50a4a6474d74"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","KurumOrnekSorgulandiSync_ServerSide", UserName, PassWord, barkodno, KurumKodu, CalisKurumKodu);
            }


            private static string KurumOrnekSorgulandiSync_ServerSide(string UserName, string PassWord, string barkodno, string KurumKodu, string CalisKurumKodu)
            {

#region KurumOrnekSorgulandiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "KurumOrnekSorgulandi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("barkodno", (object)barkodno),
                        Tuple.Create("KurumKodu", (object)KurumKodu),
                        Tuple.Create("CalisKurumKodu", (object)CalisKurumKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumOrnekSorgulandiSync_Body

            }

            public static int LabMesajAlindiSync(Guid siteID, string UserName, string PassWord, string MesajNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("fa86c3e6-4b27-4fbd-bca9-facb5d1854dd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","LabMesajAlindiSync_ServerSide", UserName, PassWord, MesajNo);
            }


            private static int LabMesajAlindiSync_ServerSide(string UserName, string PassWord, string MesajNo)
            {

#region LabMesajAlindiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "LabMesajAlindi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("MesajNo", (object)MesajNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion LabMesajAlindiSync_Body

            }

            public static Mesajlar LabMesajGetirSync(Guid siteID, string UserName, string PassWord, string KurumKodu, string MesajTuru, string OrnekNo, string BasTarih, string BitTarih)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (Mesajlar) TTMessageFactory.SyncCall(siteID, new Guid("3bb4b7ee-4f36-4dbc-92d4-8ce3462174af"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","LabMesajGetirSync_ServerSide", UserName, PassWord, KurumKodu, MesajTuru, OrnekNo, BasTarih, BitTarih);
            }


            private static Mesajlar LabMesajGetirSync_ServerSide(string UserName, string PassWord, string KurumKodu, string MesajTuru, string OrnekNo, string BasTarih, string BitTarih)
            {

#region LabMesajGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "LabMesajGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("KurumKodu", (object)KurumKodu),
                        Tuple.Create("MesajTuru", (object)MesajTuru),
                        Tuple.Create("OrnekNo", (object)OrnekNo),
                        Tuple.Create("BasTarih", (object)BasTarih),
                        Tuple.Create("BitTarih", (object)BitTarih),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    Mesajlar cevap = default(Mesajlar);
                    cevap = (Mesajlar)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion LabMesajGetirSync_Body

            }

            public static int LabMesajGonderSync(Guid siteID, string UserName, string PassWord, Mesaj mesaj)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("09e940b6-2f3c-46d6-a1e3-a16a9bce9389"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","LabMesajGonderSync_ServerSide", UserName, PassWord, mesaj);
            }


            private static int LabMesajGonderSync_ServerSide(string UserName, string PassWord, Mesaj mesaj)
            {

#region LabMesajGonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "LabMesajGonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("mesaj", (object)mesaj),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion LabMesajGonderSync_Body

            }

            public static OrnekDosyaList MerkezdenDosyaSorgulaSync(Guid siteID, string VENUSER, string VENPASS, int OrnekNo, string EntegGrup)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (OrnekDosyaList) TTMessageFactory.SyncCall(siteID, new Guid("9d40c1d3-886b-43fe-9003-4e05c24695f7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","MerkezdenDosyaSorgulaSync_ServerSide", VENUSER, VENPASS, OrnekNo, EntegGrup);
            }


            private static OrnekDosyaList MerkezdenDosyaSorgulaSync_ServerSide(string VENUSER, string VENPASS, int OrnekNo, string EntegGrup)
            {

#region MerkezdenDosyaSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "MerkezdenDosyaSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("VENUSER", (object)VENUSER),
                        Tuple.Create("VENPASS", (object)VENPASS),
                        Tuple.Create("OrnekNo", (object)OrnekNo),
                        Tuple.Create("EntegGrup", (object)EntegGrup),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    OrnekDosyaList cevap = default(OrnekDosyaList);
                    cevap = (OrnekDosyaList)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MerkezdenDosyaSorgulaSync_Body

            }

            public static string MerkezdenSorgulaSync(Guid siteID, string UserName, string PassWord, string KurumKodu, string ornekno, string barkodno)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("6d973368-f022-4711-b051-ca3450780da8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","MerkezdenSorgulaSync_ServerSide", UserName, PassWord, KurumKodu, ornekno, barkodno);
            }


            private static string MerkezdenSorgulaSync_ServerSide(string UserName, string PassWord, string KurumKodu, string ornekno, string barkodno)
            {

#region MerkezdenSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "MerkezdenSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("KurumKodu", (object)KurumKodu),
                        Tuple.Create("ornekno", (object)ornekno),
                        Tuple.Create("barkodno", (object)barkodno),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MerkezdenSorgulaSync_Body

            }

            public static int MerkezeAktarSync(Guid siteID, string UserName, string PassWord, string IHEStr)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("c65af733-1e33-41bc-b447-f01ed8385590"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","MerkezeAktarSync_ServerSide", UserName, PassWord, IHEStr);
            }


            private static int MerkezeAktarSync_ServerSide(string UserName, string PassWord, string IHEStr)
            {

#region MerkezeAktarSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "MerkezeAktar";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("UserName", (object)UserName),
                        Tuple.Create("PassWord", (object)PassWord),
                        Tuple.Create("IHEStr", (object)IHEStr),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MerkezeAktarSync_Body

            }

            public static string MerkezeDosyaAktarSync(Guid siteID, string VENUSER, string VENPASS, int OrnekNo, string LoincKodu, string hexStr)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("d87c2be4-65a6-4ac7-97e1-3ca4a96451b7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","MerkezeDosyaAktarSync_ServerSide", VENUSER, VENPASS, OrnekNo, LoincKodu, hexStr);
            }


            private static string MerkezeDosyaAktarSync_ServerSide(string VENUSER, string VENPASS, int OrnekNo, string LoincKodu, string hexStr)
            {

#region MerkezeDosyaAktarSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "MerkezeDosyaAktar";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("VENUSER", (object)VENUSER),
                        Tuple.Create("VENPASS", (object)VENPASS),
                        Tuple.Create("OrnekNo", (object)OrnekNo),
                        Tuple.Create("LoincKodu", (object)LoincKodu),
                        Tuple.Create("hexStr", (object)hexStr),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MerkezeDosyaAktarSync_Body

            }

            public static ORL34 OML33ToORL34Sync(Guid siteID, OML33 Oml33)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ORL34) TTMessageFactory.SyncCall(siteID, new Guid("9b0e5423-ec21-47f3-ae09-d81adbe55625"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","OML33ToORL34Sync_ServerSide", Oml33);
            }


            private static ORL34 OML33ToORL34Sync_ServerSide(OML33 Oml33)
            {

#region OML33ToORL34Sync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "OML33ToORL34";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Oml33", (object)Oml33),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    ORL34 cevap = default(ORL34);
                    cevap = (ORL34)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OML33ToORL34Sync_Body

            }

            public static int OrnekHazirMiSync(Guid siteID, string SpecimenId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("6d72a5c5-cd48-405c-b569-75f582db0522"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","OrnekHazirMiSync_ServerSide", SpecimenId);
            }


            private static int OrnekHazirMiSync_ServerSide(string SpecimenId)
            {

#region OrnekHazirMiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "OrnekHazirMi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("SpecimenId", (object)SpecimenId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OrnekHazirMiSync_Body

            }

            public static int OrnekIslemTarihBildirSync(Guid siteID, int OrnekNo, string BarkodNo, int Islem, string Tarih, string IslemYapan)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("a17652aa-3c31-44d3-9f48-7742343ef6ee"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","OrnekIslemTarihBildirSync_ServerSide", OrnekNo, BarkodNo, Islem, Tarih, IslemYapan);
            }


            private static int OrnekIslemTarihBildirSync_ServerSide(int OrnekNo, string BarkodNo, int Islem, string Tarih, string IslemYapan)
            {

#region OrnekIslemTarihBildirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "OrnekIslemTarihBildir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("OrnekNo", (object)OrnekNo),
                        Tuple.Create("BarkodNo", (object)BarkodNo),
                        Tuple.Create("Islem", (object)Islem),
                        Tuple.Create("Tarih", (object)Tarih),
                        Tuple.Create("IslemYapan", (object)IslemYapan),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OrnekIslemTarihBildirSync_Body

            }

            public static int OrnekSonucAlindiSync(Guid siteID, HazirOrnek ho)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (int) TTMessageFactory.SyncCall(siteID, new Guid("bfeb1d8a-9d8d-4507-be5f-c75c9993569e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","OrnekSonucAlindiSync_ServerSide", ho);
            }


            private static int OrnekSonucAlindiSync_ServerSide(HazirOrnek ho)
            {

#region OrnekSonucAlindiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "OrnekSonucAlindi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ho", (object)ho),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    int cevap = default(int);
                    cevap = (int)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OrnekSonucAlindiSync_Body

            }

            public static string OrnekTetkikSilSync(Guid siteID, string SpecimenId, string PlacerOrderNumber, string FillerOrderNumber)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("8f051ba3-64fb-47ec-90a9-d79638b184be"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","OrnekTetkikSilSync_ServerSide", SpecimenId, PlacerOrderNumber, FillerOrderNumber);
            }


            private static string OrnekTetkikSilSync_ServerSide(string SpecimenId, string PlacerOrderNumber, string FillerOrderNumber)
            {

#region OrnekTetkikSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "OrnekTetkikSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("SpecimenId", (object)SpecimenId),
                        Tuple.Create("PlacerOrderNumber", (object)PlacerOrderNumber),
                        Tuple.Create("FillerOrderNumber", (object)FillerOrderNumber),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OrnekTetkikSilSync_Body

            }

            public static ACK OUL22ToACKSync(Guid siteID, OUL22 Oul22)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ACK) TTMessageFactory.SyncCall(siteID, new Guid("c11ed29c-fa95-4615-81f2-b52a1d2819c0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","OUL22ToACKSync_ServerSide", Oul22);
            }


            private static ACK OUL22ToACKSync_ServerSide(OUL22 Oul22)
            {

#region OUL22ToACKSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "OUL22ToACK";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Oul22", (object)Oul22),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    ACK cevap = default(ACK);
                    cevap = (ACK)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OUL22ToACKSync_Body

            }

            public static ORL34 OUL22ToORL34Sync(Guid siteID, OUL22 Oul22)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ORL34) TTMessageFactory.SyncCall(siteID, new Guid("7e1df6ee-1789-467a-96c6-09ee65e5e736"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","OUL22ToORL34Sync_ServerSide", Oul22);
            }


            private static ORL34 OUL22ToORL34Sync_ServerSide(OUL22 Oul22)
            {

#region OUL22ToORL34Sync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "OUL22ToORL34";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Oul22", (object)Oul22),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    ORL34 cevap = default(ORL34);
                    cevap = (ORL34)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion OUL22ToORL34Sync_Body

            }

            public static RSP11 QBP11ToRSP11Sync(Guid siteID, QBP11 Qbp11)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (RSP11) TTMessageFactory.SyncCall(siteID, new Guid("f1b2504a-a9e8-4dc1-b8b4-0d1cea5e783b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","QBP11ToRSP11Sync_ServerSide", Qbp11);
            }


            private static RSP11 QBP11ToRSP11Sync_ServerSide(QBP11 Qbp11)
            {

#region QBP11ToRSP11Sync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "QBP11ToRSP11";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Qbp11", (object)Qbp11),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    RSP11 cevap = default(RSP11);
                    cevap = (RSP11)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion QBP11ToRSP11Sync_Body

            }

            public static TestCalisSayiArr TestCalisIstGetirSync(Guid siteID, string TarihKriter1_Bas, string TarihKriter1_Bit, string TarihKriter2_Bas, string TarihKriter2_Bit, string TarihKriter3_Bas, string TarihKriter3_Bit)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (TestCalisSayiArr) TTMessageFactory.SyncCall(siteID, new Guid("228c0c15-9290-4f75-b282-e96dffb0e112"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","TestCalisIstGetirSync_ServerSide", TarihKriter1_Bas, TarihKriter1_Bit, TarihKriter2_Bas, TarihKriter2_Bit, TarihKriter3_Bas, TarihKriter3_Bit);
            }


            private static TestCalisSayiArr TestCalisIstGetirSync_ServerSide(string TarihKriter1_Bas, string TarihKriter1_Bit, string TarihKriter2_Bas, string TarihKriter2_Bit, string TarihKriter3_Bas, string TarihKriter3_Bit)
            {

#region TestCalisIstGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "TestCalisIstGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("TarihKriter1_Bas", (object)TarihKriter1_Bas),
                        Tuple.Create("TarihKriter1_Bit", (object)TarihKriter1_Bit),
                        Tuple.Create("TarihKriter2_Bas", (object)TarihKriter2_Bas),
                        Tuple.Create("TarihKriter2_Bit", (object)TarihKriter2_Bit),
                        Tuple.Create("TarihKriter3_Bas", (object)TarihKriter3_Bas),
                        Tuple.Create("TarihKriter3_Bit", (object)TarihKriter3_Bit),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    TestCalisSayiArr cevap = default(TestCalisSayiArr);
                    cevap = (TestCalisSayiArr)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TestCalisIstGetirSync_Body

            }

            public static TetkikBilgiListe TetkikBilgiGetirSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (TetkikBilgiListe) TTMessageFactory.SyncCall(siteID, new Guid("872b5494-25df-495a-a1fe-acfe379fd5fd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","TetkikBilgiGetirSync_ServerSide");
            }


            private static TetkikBilgiListe TetkikBilgiGetirSync_ServerSide()
            {

#region TetkikBilgiGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "TetkikBilgiGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    TetkikBilgiListe cevap = default(TetkikBilgiListe);
                    cevap = (TetkikBilgiListe)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TetkikBilgiGetirSync_Body

            }

            public static ORL34 TetkiksizOML33ToORL34Sync(Guid siteID, OML33 Oml33)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (ORL34) TTMessageFactory.SyncCall(siteID, new Guid("f5e05eb4-a976-4a67-be14-dd78e007abfa"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXIHEWS+WebMethods, TTObjectClasses","TetkiksizOML33ToORL34Sync_ServerSide", Oml33);
            }


            private static ORL34 TetkiksizOML33ToORL34Sync_ServerSide(OML33 Oml33)
            {

#region TetkiksizOML33ToORL34Sync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXIHEWS";
                    header.ServiceId = "6b4c3939-39ed-438f-b921-dcd48110ff7b";
                    header.MethodName = "TetkiksizOML33ToORL34";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Oml33", (object)Oml33),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXPASSWORD","");

                    ORL34 cevap = default(ORL34);
                    cevap = (ORL34)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TetkiksizOML33ToORL34Sync_Body

            }

        }
                    
        protected XXXXXXIHEWS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXXXXIHEWS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXXXXIHEWS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXXXXIHEWS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXXXXIHEWS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXXXXIHEWS", dataRow) { }
        protected XXXXXXIHEWS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXXXXIHEWS", dataRow, isImported) { }
        public XXXXXXIHEWS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXXXXIHEWS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXXXXIHEWS() : base() { }

    }
}