
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaKabulIslemleri")] 

    /// <summary>
    /// MEDULA Hasta Kabul İşlemleri
    /// </summary>
    public  abstract  partial class HastaKabulIslemleri : TTObject
    {
        public class HastaKabulIslemleriList : TTObjectCollection<HastaKabulIslemleri> { }
                    
        public class ChildHastaKabulIslemleriCollection : TTObject.TTChildObjectCollection<HastaKabulIslemleri>
        {
            public ChildHastaKabulIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaKabulIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage basvuruTakipOkuASync(Guid siteID, IWebMethodCallback callerObject, basvuruTakipOkuDVO basvuruTakipOkuDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","basvuruTakipOkuASync_ServerSide", new Guid("6d83381b-a7a4-4aaf-ad58-dca833480bd0"), callerObject, basvuruTakipOkuDVO);
            }

            private static basvuruTakipOkuCevapDVO basvuruTakipOkuASync_ServerSide(IWebMethodCallback callerObject, basvuruTakipOkuDVO basvuruTakipOkuDVO)
            {

#region basvuruTakipOkuASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "basvuruTakipOku";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("basvuruTakipOkuDVO", (object)basvuruTakipOkuDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    basvuruTakipOkuCevapDVO cevap = default(basvuruTakipOkuCevapDVO);
                    
                    try
                    {
                        cevap = (basvuruTakipOkuCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { basvuruTakipOkuDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { basvuruTakipOkuDVO }, null);

                    return cevap;
                

#endregion basvuruTakipOkuASync_Body

            }

            public static basvuruTakipOkuCevapDVO basvuruTakipOkuSync(Guid siteID, basvuruTakipOkuDVO basvuruTakipOkuDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (basvuruTakipOkuCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9f4ff8f8-0df9-4022-b807-1c1bb0ca588f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","basvuruTakipOkuSync_ServerSide", basvuruTakipOkuDVO);
            }


            private static basvuruTakipOkuCevapDVO basvuruTakipOkuSync_ServerSide(basvuruTakipOkuDVO basvuruTakipOkuDVO)
            {

#region basvuruTakipOkuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "basvuruTakipOku";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("basvuruTakipOkuDVO", (object)basvuruTakipOkuDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    basvuruTakipOkuCevapDVO cevap = default(basvuruTakipOkuCevapDVO);
                    cevap = (basvuruTakipOkuCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion basvuruTakipOkuSync_Body

            }

            public static mustehaklikCevapDVO getMustehaklikKapsamKoduSync(Guid siteID, mustehaklikGirisDVO mustehaklikGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (mustehaklikCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2f501364-1f8c-4fe0-870a-840235a986ec"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","getMustehaklikKapsamKoduSync_ServerSide", mustehaklikGirisDVO);
            }


            private static mustehaklikCevapDVO getMustehaklikKapsamKoduSync_ServerSide(mustehaklikGirisDVO mustehaklikGirisDVO)
            {

#region getMustehaklikKapsamKoduSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "getMustehaklikKapsamKodu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("mustehaklikGirisDVO", (object)mustehaklikGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    mustehaklikCevapDVO cevap = default(mustehaklikCevapDVO);
                    cevap = (mustehaklikCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion getMustehaklikKapsamKoduSync_Body

            }

            public static yesilKartliSevkliHastaCevapDVO getYesilKartliSevkliHastaSync(Guid siteID, yesilKartliSevkliHastaGirisDVO yesilKartliSevkliHastaGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (yesilKartliSevkliHastaCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("104f6ae3-e016-4bd9-af26-374fb1a8f90c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","getYesilKartliSevkliHastaSync_ServerSide", yesilKartliSevkliHastaGiris);
            }


            private static yesilKartliSevkliHastaCevapDVO getYesilKartliSevkliHastaSync_ServerSide(yesilKartliSevkliHastaGirisDVO yesilKartliSevkliHastaGiris)
            {

#region getYesilKartliSevkliHastaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "getYesilKartliSevkliHasta";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("yesilKartliSevkliHastaGiris", (object)yesilKartliSevkliHastaGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    yesilKartliSevkliHastaCevapDVO cevap = default(yesilKartliSevkliHastaCevapDVO);
                    cevap = (yesilKartliSevkliHastaCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion getYesilKartliSevkliHastaSync_Body

            }

            public static hastaCikisCevapDVO hastaCikisIptalSync(Guid siteID, hastaCikisIptalDVO hastaCikisIptal)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (hastaCikisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("75ac7e6a-31bc-4fb3-85d2-924728ee9edb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaCikisIptalSync_ServerSide", hastaCikisIptal);
            }


            private static hastaCikisCevapDVO hastaCikisIptalSync_ServerSide(hastaCikisIptalDVO hastaCikisIptal)
            {

#region hastaCikisIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaCikisIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hastaCikisIptal", (object)hastaCikisIptal),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    hastaCikisCevapDVO cevap = default(hastaCikisCevapDVO);
                    cevap = (hastaCikisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hastaCikisIptalSync_Body

            }

            public static hastaCikisCevapDVO hastaCikisKayitSync(Guid siteID, hastaCikisDVO hastaCikis)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (hastaCikisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("3dacdf01-b680-4f60-8d8e-4faeadeb223c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaCikisKayitSync_ServerSide", hastaCikis);
            }


            private static hastaCikisCevapDVO hastaCikisKayitSync_ServerSide(hastaCikisDVO hastaCikis)
            {

#region hastaCikisKayitSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaCikisKayit";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hastaCikis", (object)hastaCikis),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    hastaCikisCevapDVO cevap = default(hastaCikisCevapDVO);
                    cevap = (hastaCikisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hastaCikisKayitSync_Body

            }

            public static TTMessage hastaKabulASync(Guid siteID, IWebMethodCallback callerObject, provizyonGirisDVO provizyonGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaKabulASync_ServerSide", new Guid("09aa24f6-b816-4238-8ba2-fb62c4e7be60"), callerObject, provizyonGiris);
            }

            private static provizyonCevapDVO hastaKabulASync_ServerSide(IWebMethodCallback callerObject, provizyonGirisDVO provizyonGiris)
            {

#region hastaKabulASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaKabul";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("provizyonGiris", (object)provizyonGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    provizyonCevapDVO cevap = default(provizyonCevapDVO);
                    
                    try
                    {
                        cevap = (provizyonCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { provizyonGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { provizyonGiris }, null);

                    return cevap;
                

#endregion hastaKabulASync_Body

            }

            public static takipSilCevapDVO hastaKabulIptalSync(Guid siteID, takipSilGirisDVO takipSilGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("df2f42d4-f801-4a15-9467-cd27e14616a3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaKabulIptalSync_ServerSide", takipSilGiris);
            }


            private static takipSilCevapDVO hastaKabulIptalSync_ServerSide(takipSilGirisDVO takipSilGiris)
            {

#region hastaKabulIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaKabulIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipSilGiris", (object)takipSilGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipSilCevapDVO cevap = default(takipSilCevapDVO);
                    cevap = (takipSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hastaKabulIptalSync_Body

            }

            public static provizyonCevapDVO hastaKabulKimlikDogrulamaSync(Guid siteID, provizyonGirisDVO provizyonGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (provizyonCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9a6a5cec-2e82-44d4-898d-0b517fcadcad"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaKabulKimlikDogrulamaSync_ServerSide", provizyonGiris);
            }


            private static provizyonCevapDVO hastaKabulKimlikDogrulamaSync_ServerSide(provizyonGirisDVO provizyonGiris)
            {

#region hastaKabulKimlikDogrulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaKabulKimlikDogrulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("provizyonGiris", (object)provizyonGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    provizyonCevapDVO cevap = default(provizyonCevapDVO);
                    cevap = (provizyonCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hastaKabulKimlikDogrulamaSync_Body

            }

            public static TTMessage hastaKabulOkuASync(Guid siteID, IWebMethodCallback callerObject, takipOkuGirisDVO takipOkuGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaKabulOkuASync_ServerSide", new Guid("de1c4eec-aa51-4010-81f8-9d23b746bf78"), callerObject, takipOkuGirisDVO);
            }

            private static takipDVO hastaKabulOkuASync_ServerSide(IWebMethodCallback callerObject, takipOkuGirisDVO takipOkuGirisDVO)
            {

#region hastaKabulOkuASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaKabulOku";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipOkuGirisDVO", (object)takipOkuGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    takipDVO cevap = default(takipDVO);
                    
                    try
                    {
                        cevap = (takipDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { takipOkuGirisDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { takipOkuGirisDVO }, null);

                    return cevap;
                

#endregion hastaKabulOkuASync_Body

            }

            public static takipDVO hastaKabulOkuSync(Guid siteID, takipOkuGirisDVO takipOkuGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipDVO) TTMessageFactory.SyncCall(siteID, new Guid("43ba138c-9ff5-404b-aefc-dda9c39641dc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaKabulOkuSync_ServerSide", takipOkuGirisDVO);
            }


            private static takipDVO hastaKabulOkuSync_ServerSide(takipOkuGirisDVO takipOkuGirisDVO)
            {

#region hastaKabulOkuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaKabulOku";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipOkuGirisDVO", (object)takipOkuGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipDVO cevap = default(takipDVO);
                    cevap = (takipDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hastaKabulOkuSync_Body

            }

            public static provizyonCevapDVO hastaKabulSync(Guid siteID, provizyonGirisDVO provizyonGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (provizyonCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("8639d015-1c29-4035-b56d-5b253737638c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaKabulSync_ServerSide", provizyonGiris);
            }


            private static provizyonCevapDVO hastaKabulSync_ServerSide(provizyonGirisDVO provizyonGiris)
            {

#region hastaKabulSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaKabul";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("provizyonGiris", (object)provizyonGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    provizyonCevapDVO cevap = default(provizyonCevapDVO);
                    cevap = (provizyonCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hastaKabulSync_Body

            }

            public static hastaYatisOkuCevapDVO hastaYatisOkuSync(Guid siteID, hastaYatisOkuDVO hastaYatisOkuDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (hastaYatisOkuCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("5b5692cd-5714-46fb-ae99-df032318f433"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","hastaYatisOkuSync_ServerSide", hastaYatisOkuDVO);
            }


            private static hastaYatisOkuCevapDVO hastaYatisOkuSync_ServerSide(hastaYatisOkuDVO hastaYatisOkuDVO)
            {

#region hastaYatisOkuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "hastaYatisOku";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hastaYatisOkuDVO", (object)hastaYatisOkuDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    hastaYatisOkuCevapDVO cevap = default(hastaYatisOkuCevapDVO);
                    cevap = (hastaYatisOkuCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hastaYatisOkuSync_Body

            }

            public static sevkBildirSonucDVO sevkBildirSync(Guid siteID, sevkBildirGirisDVO sevkBildirGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sevkBildirSonucDVO) TTMessageFactory.SyncCall(siteID, new Guid("668f3582-c565-4e8c-9eb5-c7f4b319f5e3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","sevkBildirSync_ServerSide", sevkBildirGiris);
            }


            private static sevkBildirSonucDVO sevkBildirSync_ServerSide(sevkBildirGirisDVO sevkBildirGiris)
            {

#region sevkBildirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "sevkBildir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sevkBildirGiris", (object)sevkBildirGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    sevkBildirSonucDVO cevap = default(sevkBildirSonucDVO);
                    cevap = (sevkBildirSonucDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sevkBildirSync_Body

            }

            public static TTMessage updateProvizyonTipiASync(Guid siteID, IWebMethodCallback callerObject, provizyonDegistirGirisDVO provizyonDegistirGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateProvizyonTipiASync_ServerSide", new Guid("64334ac7-110c-4605-ae6f-584a5c2cab51"), callerObject, provizyonDegistirGirisDVO);
            }

            private static provizyonDegistirCevapDVO updateProvizyonTipiASync_ServerSide(IWebMethodCallback callerObject, provizyonDegistirGirisDVO provizyonDegistirGirisDVO)
            {

#region updateProvizyonTipiASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateProvizyonTipi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("provizyonDegistirGirisDVO", (object)provizyonDegistirGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    provizyonDegistirCevapDVO cevap = default(provizyonDegistirCevapDVO);
                    
                    try
                    {
                        cevap = (provizyonDegistirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { provizyonDegistirGirisDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { provizyonDegistirGirisDVO }, null);

                    return cevap;
                

#endregion updateProvizyonTipiASync_Body

            }

            public static provizyonDegistirCevapDVO updateProvizyonTipiSync(Guid siteID, provizyonDegistirGirisDVO provizyonDegistirDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (provizyonDegistirCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1b895d2b-0779-4d9b-88bc-8c402222d545"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateProvizyonTipiSync_ServerSide", provizyonDegistirDVO);
            }


            private static provizyonDegistirCevapDVO updateProvizyonTipiSync_ServerSide(provizyonDegistirGirisDVO provizyonDegistirDVO)
            {

#region updateProvizyonTipiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateProvizyonTipi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("provizyonDegistirDVO", (object)provizyonDegistirDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    provizyonDegistirCevapDVO cevap = default(provizyonDegistirCevapDVO);
                    cevap = (provizyonDegistirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion updateProvizyonTipiSync_Body

            }

            public static TTMessage updateTakipTipiASync(Guid siteID, IWebMethodCallback callerObject, takipTipiDegistirGirisDVO takipTipiDegistirGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateTakipTipiASync_ServerSide", new Guid("a7f6d9c9-13c3-4cb3-8fb5-f0a874046ee9"), callerObject, takipTipiDegistirGirisDVO);
            }

            private static takipTipiDegistirCevapDVO updateTakipTipiASync_ServerSide(IWebMethodCallback callerObject, takipTipiDegistirGirisDVO takipTipiDegistirGirisDVO)
            {

#region updateTakipTipiASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateTakipTipi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipTipiDegistirGirisDVO", (object)takipTipiDegistirGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    takipTipiDegistirCevapDVO cevap = default(takipTipiDegistirCevapDVO);
                    
                    try
                    {
                        cevap = (takipTipiDegistirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { takipTipiDegistirGirisDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { takipTipiDegistirGirisDVO }, null);

                    return cevap;
                

#endregion updateTakipTipiASync_Body

            }

            public static takipTipiDegistirCevapDVO updateTakipTipiSync(Guid siteID, takipTipiDegistirGirisDVO takipTipiDegistirDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipTipiDegistirCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("46cfd4ab-fbaf-462a-8c1d-45988ef3386d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateTakipTipiSync_ServerSide", takipTipiDegistirDVO);
            }


            private static takipTipiDegistirCevapDVO updateTakipTipiSync_ServerSide(takipTipiDegistirGirisDVO takipTipiDegistirDVO)
            {

#region updateTakipTipiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateTakipTipi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipTipiDegistirDVO", (object)takipTipiDegistirDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipTipiDegistirCevapDVO cevap = default(takipTipiDegistirCevapDVO);
                    cevap = (takipTipiDegistirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion updateTakipTipiSync_Body

            }

            public static TTMessage updateTedaviTipiASync(Guid siteID, IWebMethodCallback callerObject, takipOkuGirisDVO takipOkuGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateTedaviTipiASync_ServerSide", new Guid("8ab8eec4-b2dd-404a-b981-c06640f454b7"), callerObject, takipOkuGirisDVO);
            }

            private static takipDVO updateTedaviTipiASync_ServerSide(IWebMethodCallback callerObject, takipOkuGirisDVO takipOkuGirisDVO)
            {

#region updateTedaviTipiASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateTedaviTipi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipOkuGirisDVO", (object)takipOkuGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    takipDVO cevap = default(takipDVO);
                    
                    try
                    {
                        cevap = (takipDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { takipOkuGirisDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { takipOkuGirisDVO }, null);

                    return cevap;
                

#endregion updateTedaviTipiASync_Body

            }

            public static takipDVO updateTedaviTipiSync(Guid siteID, takipOkuGirisDVO takipOkuDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipDVO) TTMessageFactory.SyncCall(siteID, new Guid("e90f328b-4394-4b2c-a88d-17fde88c1a89"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateTedaviTipiSync_ServerSide", takipOkuDVO);
            }


            private static takipDVO updateTedaviTipiSync_ServerSide(takipOkuGirisDVO takipOkuDVO)
            {

#region updateTedaviTipiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateTedaviTipi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipOkuDVO", (object)takipOkuDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipDVO cevap = default(takipDVO);
                    cevap = (takipDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion updateTedaviTipiSync_Body

            }

            public static TTMessage updateTedaviTuruASync(Guid siteID, IWebMethodCallback callerObject, tedaviTuruDegistirGirisDVO tedaviTuruDegistirDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateTedaviTuruASync_ServerSide", new Guid("b3c15df5-d2bb-4227-8b95-01b89b4ae0cf"), callerObject, tedaviTuruDegistirDVO);
            }

            private static tedaviTuruDegistirCevapDVO updateTedaviTuruASync_ServerSide(IWebMethodCallback callerObject, tedaviTuruDegistirGirisDVO tedaviTuruDegistirDVO)
            {

#region updateTedaviTuruASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateTedaviTuru";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tedaviTuruDegistirDVO", (object)tedaviTuruDegistirDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    tedaviTuruDegistirCevapDVO cevap = default(tedaviTuruDegistirCevapDVO);
                    
                    try
                    {
                        cevap = (tedaviTuruDegistirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { tedaviTuruDegistirDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { tedaviTuruDegistirDVO }, null);

                    return cevap;
                

#endregion updateTedaviTuruASync_Body

            }

            public static tedaviTuruDegistirCevapDVO updateTedaviTuruSync(Guid siteID, tedaviTuruDegistirGirisDVO tedaviTuruDegistirDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (tedaviTuruDegistirCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e3ba74b9-fc5a-427f-9dc9-64560cfba31e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HastaKabulIslemleri+WebMethods, TTObjectClasses","updateTedaviTuruSync_ServerSide", tedaviTuruDegistirDVO);
            }


            private static tedaviTuruDegistirCevapDVO updateTedaviTuruSync_ServerSide(tedaviTuruDegistirGirisDVO tedaviTuruDegistirDVO)
            {

#region updateTedaviTuruSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
                    header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
                    header.MethodName = "updateTedaviTuru";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tedaviTuruDegistirDVO", (object)tedaviTuruDegistirDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    tedaviTuruDegistirCevapDVO cevap = default(tedaviTuruDegistirCevapDVO);
                    cevap = (tedaviTuruDegistirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion updateTedaviTuruSync_Body

            }

        }
                    
        protected HastaKabulIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaKabulIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaKabulIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaKabulIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaKabulIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAKABULISLEMLERI", dataRow) { }
        protected HastaKabulIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAKABULISLEMLERI", dataRow, isImported) { }
        public HastaKabulIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaKabulIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaKabulIslemleri() : base() { }

    }
}