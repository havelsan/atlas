
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXXXXTasinirMal")] 

    /// <summary>
    /// Tasinir Mal WEB SERVİS Entegrasyon Nesnesi.
    /// </summary>
    public  partial class XXXXXXTasinirMal : TTObject
    {
        public class XXXXXXTasinirMalList : TTObjectCollection<XXXXXXTasinirMal> { }
                    
        public class ChildXXXXXXTasinirMalCollection : TTObject.TTChildObjectCollection<XXXXXXTasinirMal>
        {
            public ChildXXXXXXTasinirMalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXXXXTasinirMalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static IslemSonuc GetEhipWsEntegreKeyByBolumIdSync(Guid siteID, string bolumId, string ehipWsUsername, string ehipWsPassword)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("1aaffaff-bb5e-448f-9ac3-25cc9de30c91"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","GetEhipWsEntegreKeyByBolumIdSync_ServerSide", bolumId, ehipWsUsername, ehipWsPassword);
            }


            private static IslemSonuc GetEhipWsEntegreKeyByBolumIdSync_ServerSide(string bolumId, string ehipWsUsername, string ehipWsPassword)
            {

#region GetEhipWsEntegreKeyByBolumIdSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "GetEhipWsEntegreKeyByBolumId";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("bolumId", (object)bolumId),
                        Tuple.Create("ehipWsUsername", (object)ehipWsUsername),
                        Tuple.Create("ehipWsPassword", (object)ehipWsPassword),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetEhipWsEntegreKeyByBolumIdSync_Body

            }

            public static VenAdvancedStokInfo[] GetStokAdvancedListSync(Guid siteID, string Guid, VenStokAramaKriterInfo aramaKriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (VenAdvancedStokInfo[]) TTMessageFactory.SyncCall(siteID, new Guid("53d4f53a-adbb-44ee-96c8-369fce822c6f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","GetStokAdvancedListSync_ServerSide", Guid, aramaKriter);
            }


            private static VenAdvancedStokInfo[] GetStokAdvancedListSync_ServerSide(string Guid, VenStokAramaKriterInfo aramaKriter)
            {

#region GetStokAdvancedListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "GetStokAdvancedList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                        Tuple.Create("aramaKriter", (object)aramaKriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    VenAdvancedStokInfo[] cevap = default(VenAdvancedStokInfo[]);
                    cevap = (VenAdvancedStokInfo[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetStokAdvancedListSync_Body

            }

            public static VenStokBirimTur[] GetStokbirimturSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (VenStokBirimTur[]) TTMessageFactory.SyncCall(siteID, new Guid("1823e873-5b4a-457b-b802-7e0299f6beea"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","GetStokbirimturSync_ServerSide");
            }


            private static VenStokBirimTur[] GetStokbirimturSync_ServerSide()
            {

#region GetStokbirimturSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "GetStokbirimtur";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    VenStokBirimTur[] cevap = default(VenStokBirimTur[]);
                    cevap = (VenStokBirimTur[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetStokbirimturSync_Body

            }

            public static VenStokIhtiyacTur[] GetStokIhtiyacTurSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (VenStokIhtiyacTur[]) TTMessageFactory.SyncCall(siteID, new Guid("09cd5d52-bc13-4452-9229-491bbb29e79f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","GetStokIhtiyacTurSync_ServerSide");
            }


            private static VenStokIhtiyacTur[] GetStokIhtiyacTurSync_ServerSide()
            {

#region GetStokIhtiyacTurSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "GetStokIhtiyacTur";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    VenStokIhtiyacTur[] cevap = default(VenStokIhtiyacTur[]);
                    cevap = (VenStokIhtiyacTur[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetStokIhtiyacTurSync_Body

            }

            public static VenStokInfo[] GetStokListSync(Guid siteID, string Guid, VenStokAramaKriterInfo aramaKriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (VenStokInfo[]) TTMessageFactory.SyncCall(siteID, new Guid("3c8b9f0a-3c9e-43c4-95cc-55f9d4ab17ec"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","GetStokListSync_ServerSide", Guid, aramaKriter);
            }


            private static VenStokInfo[] GetStokListSync_ServerSide(string Guid, VenStokAramaKriterInfo aramaKriter)
            {

#region GetStokListSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "GetStokList";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                        Tuple.Create("aramaKriter", (object)aramaKriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    VenStokInfo[] cevap = default(VenStokInfo[]);
                    cevap = (VenStokInfo[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetStokListSync_Body

            }

            public static VenStokTur[] GetStokTurSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (VenStokTur[]) TTMessageFactory.SyncCall(siteID, new Guid("0e7721cf-6716-4308-ac6e-03d45bdcc5f9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","GetStokTurSync_ServerSide");
            }


            private static VenStokTur[] GetStokTurSync_ServerSide()
            {

#region GetStokTurSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "GetStokTur";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    VenStokTur[] cevap = default(VenStokTur[]);
                    cevap = (VenStokTur[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetStokTurSync_Body

            }

            public static IslemSonuc HbysStokKayitlariGonderimSync(Guid siteID, HbysStokGonderimObje obje)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("6bf5aca9-c5d1-462e-8f39-eccb5f676ad1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","HbysStokKayitlariGonderimSync_ServerSide", obje);
            }


            private static IslemSonuc HbysStokKayitlariGonderimSync_ServerSide(HbysStokGonderimObje obje)
            {

#region HbysStokKayitlariGonderimSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "HbysStokKayitlariGonderim";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("obje", (object)obje),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HbysStokKayitlariGonderimSync_Body

            }

            public static WsResult LabDepoCikisSync(Guid siteID, long stokkartId, long cikisBolumId, double miktar, long stokHareketTurId, System.DateTime cikisTarih, long stokBirimTurId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (WsResult) TTMessageFactory.SyncCall(siteID, new Guid("2bc912b6-1c9f-430f-a9fd-8729458535e4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","LabDepoCikisSync_ServerSide", stokkartId, cikisBolumId, miktar, stokHareketTurId, cikisTarih, stokBirimTurId);
            }


            private static WsResult LabDepoCikisSync_ServerSide(long stokkartId, long cikisBolumId, double miktar, long stokHareketTurId, System.DateTime cikisTarih, long stokBirimTurId)
            {

#region LabDepoCikisSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "LabDepoCikis";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("stokkartId", (object)stokkartId),
                        Tuple.Create("cikisBolumId", (object)cikisBolumId),
                        Tuple.Create("miktar", (object)miktar),
                        Tuple.Create("stokHareketTurId", (object)stokHareketTurId),
                        Tuple.Create("cikisTarih", (object)cikisTarih),
                        Tuple.Create("stokBirimTurId", (object)stokBirimTurId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    WsResult cevap = default(WsResult);
                    cevap = (WsResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion LabDepoCikisSync_Body

            }

            public static MuayeneKabulInfoWS[] MuayeneKabulGetSync(Guid siteID, string Guid, MuayeneAramaKriterInfoWS AramaKriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (MuayeneKabulInfoWS[]) TTMessageFactory.SyncCall(siteID, new Guid("6f2fe86e-525a-4310-bd92-0b80e1e855a0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","MuayeneKabulGetSync_ServerSide", Guid, AramaKriter);
            }


            private static MuayeneKabulInfoWS[] MuayeneKabulGetSync_ServerSide(string Guid, MuayeneAramaKriterInfoWS AramaKriter)
            {

#region MuayeneKabulGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "MuayeneKabulGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                        Tuple.Create("AramaKriter", (object)AramaKriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    MuayeneKabulInfoWS[] cevap = default(MuayeneKabulInfoWS[]);
                    cevap = (MuayeneKabulInfoWS[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MuayeneKabulGetSync_Body

            }

            public static IslemSonuc MuayeneKabulTifKaydetSync(Guid siteID, string Guid, MuayeneKabulCevapInfoWS muayeneKabulCevapInfoWS)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("2157a049-e53f-46a3-a3c4-43c21c0d827e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","MuayeneKabulTifKaydetSync_ServerSide", Guid, muayeneKabulCevapInfoWS);
            }


            private static IslemSonuc MuayeneKabulTifKaydetSync_ServerSide(string Guid, MuayeneKabulCevapInfoWS muayeneKabulCevapInfoWS)
            {

#region MuayeneKabulTifKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "MuayeneKabulTifKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                        Tuple.Create("muayeneKabulCevapInfoWS", (object)muayeneKabulCevapInfoWS),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MuayeneKabulTifKaydetSync_Body

            }

            public static IslemSonuc StokEkleSync(Guid siteID, string Guid, string stokKodu, string stokAdi, string barkod, string olcuBirimId, int mkysId, int kdvOran)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("de9590e2-0924-438c-b961-a7f0bb2e57da"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","StokEkleSync_ServerSide", Guid, stokKodu, stokAdi, barkod, olcuBirimId, mkysId, kdvOran);
            }


            private static IslemSonuc StokEkleSync_ServerSide(string Guid, string stokKodu, string stokAdi, string barkod, string olcuBirimId, int mkysId, int kdvOran)
            {

#region StokEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "StokEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                        Tuple.Create("stokKodu", (object)stokKodu),
                        Tuple.Create("stokAdi", (object)stokAdi),
                        Tuple.Create("barkod", (object)barkod),
                        Tuple.Create("olcuBirimId", (object)olcuBirimId),
                        Tuple.Create("mkysId", (object)mkysId),
                        Tuple.Create("kdvOran", (object)kdvOran),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion StokEkleSync_Body

            }

            public static IslemSonuc TalepBildirSync(Guid siteID, string Guid, TalepBildirimInfoWS talep)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("d7c0b862-6d4b-431f-ab8c-83e3eaca279c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","TalepBildirSync_ServerSide", Guid, talep);
            }


            private static IslemSonuc TalepBildirSync_ServerSide(string Guid, TalepBildirimInfoWS talep)
            {

#region TalepBildirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "TalepBildir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                        Tuple.Create("talep", (object)talep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TalepBildirSync_Body

            }

            public static IslemSonuc TalepKontrolSync(Guid siteID, string Guid, string TalepId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("bf235744-b5b2-483c-8020-67ab09365de8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXTasinirMal+WebMethods, TTObjectClasses","TalepKontrolSync_ServerSide", Guid, TalepId);
            }


            private static IslemSonuc TalepKontrolSync_ServerSide(string Guid, string TalepId)
            {

#region TalepKontrolSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXTasinirMal";
                    header.ServiceId = "1c7914ad-205f-4b22-a990-afb9c7b69a42";
                    header.MethodName = "TalepKontrol";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                        Tuple.Create("TalepId", (object)TalepId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TalepKontrolSync_Body

            }

        }
                    
        protected XXXXXXTasinirMal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXXXXTasinirMal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXXXXTasinirMal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXXXXTasinirMal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXXXXTasinirMal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXXXXTASINIRMAL", dataRow) { }
        protected XXXXXXTasinirMal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXXXXTASINIRMAL", dataRow, isImported) { }
        public XXXXXXTasinirMal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXXXXTasinirMal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXXXXTasinirMal() : base() { }

    }
}