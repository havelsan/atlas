
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KPSServis")] 

    public  partial class KPSServis : TTObject
    {
        public class KPSServisList : TTObjectCollection<KPSServis> { }
                    
        public class ChildKPSServisCollection : TTObject.TTChildObjectCollection<KPSServis>
        {
            public ChildKPSServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKPSServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static KPSServisSonucuKimlikNoSonuc GenelKimlikNoIleKisiSorgulaSync(Guid siteID, long kimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuKimlikNoSonuc) TTMessageFactory.SyncCall(siteID, new Guid("eb75358a-4c8e-4d48-aa27-758893c01ecb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","GenelKimlikNoIleKisiSorgulaSync_ServerSide", kimlikNo);
            }


            private static KPSServisSonucuKimlikNoSonuc GenelKimlikNoIleKisiSorgulaSync_ServerSide(long kimlikNo)
            {

#region GenelKimlikNoIleKisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "GenelKimlikNoIleKisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kimlikNo", (object)kimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuKimlikNoSonuc cevap = default(KPSServisSonucuKimlikNoSonuc);
                    cevap = (KPSServisSonucuKimlikNoSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GenelKimlikNoIleKisiSorgulaSync_Body

            }

            public static KPSServisSonucuNkoSonuc GenelKimlikNoIleNufusKayitOrnegiSorgulaSync(Guid siteID, long kimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuNkoSonuc) TTMessageFactory.SyncCall(siteID, new Guid("71fae927-ff80-4aac-b7e8-376f86da1262"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","GenelKimlikNoIleNufusKayitOrnegiSorgulaSync_ServerSide", kimlikNo);
            }


            private static KPSServisSonucuNkoSonuc GenelKimlikNoIleNufusKayitOrnegiSorgulaSync_ServerSide(long kimlikNo)
            {

#region GenelKimlikNoIleNufusKayitOrnegiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "GenelKimlikNoIleNufusKayitOrnegiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kimlikNo", (object)kimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuNkoSonuc cevap = default(KPSServisSonucuNkoSonuc);
                    cevap = (KPSServisSonucuNkoSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GenelKimlikNoIleNufusKayitOrnegiSorgulaSync_Body

            }

            public static KPSServisSonucuArrayOfIlce IleAitIlceistesiSync(Guid siteID, int ilKod)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuArrayOfIlce) TTMessageFactory.SyncCall(siteID, new Guid("d254bde4-1281-4aa1-9428-18ea7641c1eb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","IleAitIlceistesiSync_ServerSide", ilKod);
            }


            private static KPSServisSonucuArrayOfIlce IleAitIlceistesiSync_ServerSide(int ilKod)
            {

#region IleAitIlceistesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "IleAitIlceistesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilKod", (object)ilKod),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuArrayOfIlce cevap = default(KPSServisSonucuArrayOfIlce);
                    cevap = (KPSServisSonucuArrayOfIlce)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion IleAitIlceistesiSync_Body

            }

            public static KPSServisSonucuArrayOfIl IlListesiSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuArrayOfIl) TTMessageFactory.SyncCall(siteID, new Guid("3d315643-94c6-4fa4-aaa4-fa969fb5906f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","IlListesiSync_ServerSide");
            }


            private static KPSServisSonucuArrayOfIl IlListesiSync_ServerSide()
            {

#region IlListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "IlListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuArrayOfIl cevap = default(KPSServisSonucuArrayOfIl);
                    cevap = (KPSServisSonucuArrayOfIl)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion IlListesiSync_Body

            }

            public static string IstekIpAdresSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("d5dc60a1-c95e-4a7e-9f9d-f199b0759340"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","IstekIpAdresSync_ServerSide");
            }


            private static string IstekIpAdresSync_ServerSide()
            {

#region IstekIpAdresSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "IstekIpAdres";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion IstekIpAdresSync_Body

            }

            public static KPSServisSonucuMaviKartKisiBilgisi KimlikNoIleMaviKartGetirSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuMaviKartKisiBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("fcd6aba5-dce0-4814-9357-5d0869d84438"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","KimlikNoIleMaviKartGetirSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuMaviKartKisiBilgisi KimlikNoIleMaviKartGetirSync_ServerSide(long tcNo)
            {

#region KimlikNoIleMaviKartGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "KimlikNoIleMaviKartGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuMaviKartKisiBilgisi cevap = default(KPSServisSonucuMaviKartKisiBilgisi);
                    cevap = (KPSServisSonucuMaviKartKisiBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KimlikNoIleMaviKartGetirSync_Body

            }

            public static string[] KullanilabilirMetodListesiSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (string[]) TTMessageFactory.SyncCall(siteID, new Guid("621ebdb2-9568-467d-b97e-3d53d93d9383"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","KullanilabilirMetodListesiSync_ServerSide");
            }


            private static string[] KullanilabilirMetodListesiSync_ServerSide()
            {

#region KullanilabilirMetodListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "KullanilabilirMetodListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    string[] cevap = default(string[]);
                    cevap = (string[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KullanilabilirMetodListesiSync_Body

            }

            public static KPSServisSonucuMaviKartDegisimListesi MaviKartAdresDegisenListeleSync(Guid siteID, System.DateTime tarih, System.Nullable<long> sayfa)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuMaviKartDegisimListesi) TTMessageFactory.SyncCall(siteID, new Guid("f15dd73f-bff9-4a1e-abac-5be066433e94"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","MaviKartAdresDegisenListeleSync_ServerSide", tarih, sayfa);
            }


            private static KPSServisSonucuMaviKartDegisimListesi MaviKartAdresDegisenListeleSync_ServerSide(System.DateTime tarih, System.Nullable<long> sayfa)
            {

#region MaviKartAdresDegisenListeleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "MaviKartAdresDegisenListele";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tarih", (object)tarih),
                        Tuple.Create("sayfa", (object)sayfa),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuMaviKartDegisimListesi cevap = default(KPSServisSonucuMaviKartDegisimListesi);
                    cevap = (KPSServisSonucuMaviKartDegisimListesi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MaviKartAdresDegisenListeleSync_Body

            }

            public static KPSServisSonucuMaviKartDegisimListesi MaviKartDegisenListeleSync(Guid siteID, System.DateTime tarih, System.Nullable<long> sayfa)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuMaviKartDegisimListesi) TTMessageFactory.SyncCall(siteID, new Guid("a2c524a3-6287-4203-929f-9342a2516584"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","MaviKartDegisenListeleSync_ServerSide", tarih, sayfa);
            }


            private static KPSServisSonucuMaviKartDegisimListesi MaviKartDegisenListeleSync_ServerSide(System.DateTime tarih, System.Nullable<long> sayfa)
            {

#region MaviKartDegisenListeleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "MaviKartDegisenListele";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tarih", (object)tarih),
                        Tuple.Create("sayfa", (object)sayfa),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuMaviKartDegisimListesi cevap = default(KPSServisSonucuMaviKartDegisimListesi);
                    cevap = (KPSServisSonucuMaviKartDegisimListesi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MaviKartDegisenListeleSync_Body

            }

            public static KPSServisSonucuMaviKartDegisimListesi MaviKartKisiDegisenListeleSync(Guid siteID, System.DateTime tarih, System.Nullable<long> sayfa)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuMaviKartDegisimListesi) TTMessageFactory.SyncCall(siteID, new Guid("a1b80d0f-45da-4519-96f2-c9c6c8b9ed1a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","MaviKartKisiDegisenListeleSync_ServerSide", tarih, sayfa);
            }


            private static KPSServisSonucuMaviKartDegisimListesi MaviKartKisiDegisenListeleSync_ServerSide(System.DateTime tarih, System.Nullable<long> sayfa)
            {

#region MaviKartKisiDegisenListeleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "MaviKartKisiDegisenListele";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tarih", (object)tarih),
                        Tuple.Create("sayfa", (object)sayfa),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuMaviKartDegisimListesi cevap = default(KPSServisSonucuMaviKartDegisimListesi);
                    cevap = (KPSServisSonucuMaviKartDegisimListesi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MaviKartKisiDegisenListeleSync_Body

            }

            public static System.DateTime ServisUTCZamaniSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (System.DateTime) TTMessageFactory.SyncCall(siteID, new Guid("b7a6030c-e0dd-41dc-8bb5-873b0c47e807"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","ServisUTCZamaniSync_ServerSide");
            }


            private static System.DateTime ServisUTCZamaniSync_ServerSide()
            {

#region ServisUTCZamaniSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "ServisUTCZamani";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    System.DateTime cevap = default(System.DateTime);
                    cevap = (System.DateTime)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ServisUTCZamaniSync_Body

            }

            public static KPSServisSonucuAdresTipi TcKimlikNoAdresTipiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuAdresTipi) TTMessageFactory.SyncCall(siteID, new Guid("f95933b1-5170-404b-b93a-3751bf96ae3c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoAdresTipiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuAdresTipi TcKimlikNoAdresTipiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoAdresTipiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoAdresTipiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuAdresTipi cevap = default(KPSServisSonucuAdresTipi);
                    cevap = (KPSServisSonucuAdresTipi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoAdresTipiSorgulaSync_Body

            }

            public static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleAdresBilgisiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuKisiAdresBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("7ad330b2-8483-4099-b528-241312f350fb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoIleAdresBilgisiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleAdresBilgisiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoIleAdresBilgisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoIleAdresBilgisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuKisiAdresBilgisi cevap = default(KPSServisSonucuKisiAdresBilgisi);
                    cevap = (KPSServisSonucuKisiAdresBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoIleAdresBilgisiSorgulaSync_Body

            }

            public static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleBeldeAdresBilgisiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuKisiAdresBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("d6eac221-f22e-45ec-98b0-114fd1a48b95"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoIleBeldeAdresBilgisiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleBeldeAdresBilgisiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoIleBeldeAdresBilgisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoIleBeldeAdresBilgisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuKisiAdresBilgisi cevap = default(KPSServisSonucuKisiAdresBilgisi);
                    cevap = (KPSServisSonucuKisiAdresBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoIleBeldeAdresBilgisiSorgulaSync_Body

            }

            public static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuKisiAdresBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("d24405f7-0a1f-4124-8bc6-bcf8e316a3ca"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoIleIlceMerkeziAdresBilgisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuKisiAdresBilgisi cevap = default(KPSServisSonucuKisiAdresBilgisi);
                    cevap = (KPSServisSonucuKisiAdresBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync_Body

            }

            public static KPSServisSonucuKisiTemelBilgisi TcKimlikNoIleKisiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuKisiTemelBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("56571b46-9875-40ff-9642-9db795f2d46b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoIleKisiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuKisiTemelBilgisi TcKimlikNoIleKisiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoIleKisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoIleKisiSorgula";
                    header.CallTimeout = 10;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuKisiTemelBilgisi cevap = default(KPSServisSonucuKisiTemelBilgisi);
                    cevap = (KPSServisSonucuKisiTemelBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoIleKisiSorgulaSync_Body

            }

            public static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleKoyAdresBilgisiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuKisiAdresBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("10659c64-070b-469a-8667-92efefb598da"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoIleKoyAdresBilgisiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleKoyAdresBilgisiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoIleKoyAdresBilgisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoIleKoyAdresBilgisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuKisiAdresBilgisi cevap = default(KPSServisSonucuKisiAdresBilgisi);
                    cevap = (KPSServisSonucuKisiAdresBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoIleKoyAdresBilgisiSorgulaSync_Body

            }

            public static KPSServisSonucuKisiCuzdanBilgisi TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuKisiCuzdanBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("81a0fa40-956c-44fc-8236-9668f716286a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuKisiCuzdanBilgisi TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoIleNufusCuzdanBilgisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuKisiCuzdanBilgisi cevap = default(KPSServisSonucuKisiCuzdanBilgisi);
                    cevap = (KPSServisSonucuKisiCuzdanBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync_Body

            }

            public static KPSServisSonucuNufusKayitOrnegi TcKimlikNoIleNufusKayitOrnegiSorgulaSync(Guid siteID, long tcNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuNufusKayitOrnegi) TTMessageFactory.SyncCall(siteID, new Guid("dae86d26-3e79-4dae-9038-798c3fe043f2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoIleNufusKayitOrnegiSorgulaSync_ServerSide", tcNo);
            }


            private static KPSServisSonucuNufusKayitOrnegi TcKimlikNoIleNufusKayitOrnegiSorgulaSync_ServerSide(long tcNo)
            {

#region TcKimlikNoIleNufusKayitOrnegiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoIleNufusKayitOrnegiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuNufusKayitOrnegi cevap = default(KPSServisSonucuNufusKayitOrnegi);
                    cevap = (KPSServisSonucuNufusKayitOrnegi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoIleNufusKayitOrnegiSorgulaSync_Body

            }

            public static KPSServisSonucuArrayOfKisiTemelBilgisi TcKimlikNoSorgulaSync(Guid siteID, string ad, string soyad, string babaAdi, string anaAdi, string dogumYeri, string dogumTarihi, string cinsiyet)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuArrayOfKisiTemelBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("ed0e6ee6-d5e4-468a-9e5e-244c2d15708a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","TcKimlikNoSorgulaSync_ServerSide", ad, soyad, babaAdi, anaAdi, dogumYeri, dogumTarihi, cinsiyet);
            }


            private static KPSServisSonucuArrayOfKisiTemelBilgisi TcKimlikNoSorgulaSync_ServerSide(string ad, string soyad, string babaAdi, string anaAdi, string dogumYeri, string dogumTarihi, string cinsiyet)
            {

#region TcKimlikNoSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "TcKimlikNoSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ad", (object)ad),
                        Tuple.Create("soyad", (object)soyad),
                        Tuple.Create("babaAdi", (object)babaAdi),
                        Tuple.Create("anaAdi", (object)anaAdi),
                        Tuple.Create("dogumYeri", (object)dogumYeri),
                        Tuple.Create("dogumTarihi", (object)dogumTarihi),
                        Tuple.Create("cinsiyet", (object)cinsiyet),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuArrayOfKisiTemelBilgisi cevap = default(KPSServisSonucuArrayOfKisiTemelBilgisi);
                    cevap = (KPSServisSonucuArrayOfKisiTemelBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoSorgulaSync_Body

            }

            public static KPSServisSonucuYabanciKisiBilgisi YabanciTcKimlikNoIleKisiSorgulaSync(Guid siteID, long yabaciKimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KPSServisSonucuYabanciKisiBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("e29402f0-f819-416f-84de-89b25cda804f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSServis+WebMethods, TTObjectClasses","YabanciTcKimlikNoIleKisiSorgulaSync_ServerSide", yabaciKimlikNo);
            }


            private static KPSServisSonucuYabanciKisiBilgisi YabanciTcKimlikNoIleKisiSorgulaSync_ServerSide(long yabaciKimlikNo)
            {

#region YabanciTcKimlikNoIleKisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSServis";
                    header.ServiceId = "2b7a2c6b-f979-4929-a4a0-981af0e7842d";
                    header.MethodName = "YabanciTcKimlikNoIleKisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("yabaciKimlikNo", (object)yabaciKimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("KPSSERVISPASSWORD","");

                    KPSServisSonucuYabanciKisiBilgisi cevap = default(KPSServisSonucuYabanciKisiBilgisi);
                    cevap = (KPSServisSonucuYabanciKisiBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion YabanciTcKimlikNoIleKisiSorgulaSync_Body

            }

        }
                    
        protected KPSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KPSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KPSServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KPSServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KPSServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KPSSERVIS", dataRow) { }
        protected KPSServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KPSSERVIS", dataRow, isImported) { }
        public KPSServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KPSServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KPSServis() : base() { }

    }
}