
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FsTasinirWebServis")] 

    public  partial class FsTasinirWebServis : TTObject
    {
        public class FsTasinirWebServisList : TTObjectCollection<FsTasinirWebServis> { }
                    
        public class ChildFsTasinirWebServisCollection : TTObject.TTChildObjectCollection<FsTasinirWebServis>
        {
            public ChildFsTasinirWebServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFsTasinirWebServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage FaturaKilitDurumKaydetASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int UygulamaId, int FaturaId, int KilitDurum)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","FaturaKilitDurumKaydetASync_ServerSide", new Guid("01831276-70bb-4915-92d1-51beebcdf780"), userName, password, callerObject, BIRIM_ID_STR, UygulamaId, FaturaId, KilitDurum);
            }

            private static KayitSonuc FaturaKilitDurumKaydetASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int UygulamaId, int FaturaId, int KilitDurum)
            {

#region FaturaKilitDurumKaydetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "FaturaKilitDurumKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("UygulamaId", (object)UygulamaId),
                        Tuple.Create("FaturaId", (object)FaturaId),
                        Tuple.Create("KilitDurum", (object)KilitDurum),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    KayitSonuc cevap = default(KayitSonuc);
                    
                    try
                    {
                        cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, UygulamaId, FaturaId, KilitDurum }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, UygulamaId, FaturaId, KilitDurum }, null);

                    return cevap;
                

#endregion FaturaKilitDurumKaydetASync_Body

            }

            public static KayitSonuc FaturaKilitDurumKaydetSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, int UygulamaId, int FaturaId, int KilitDurum)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KayitSonuc) TTMessageFactory.SyncCall(siteID, new Guid("dc6b5ecd-3595-4edf-a7f3-7c72443d6156"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","FaturaKilitDurumKaydetSync_ServerSide", userName, password, BIRIM_ID_STR, UygulamaId, FaturaId, KilitDurum);
            }


            private static KayitSonuc FaturaKilitDurumKaydetSync_ServerSide(string userName, string password, string BIRIM_ID_STR, int UygulamaId, int FaturaId, int KilitDurum)
            {

#region FaturaKilitDurumKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "FaturaKilitDurumKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("UygulamaId", (object)UygulamaId),
                        Tuple.Create("FaturaId", (object)FaturaId),
                        Tuple.Create("KilitDurum", (object)KilitDurum),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    KayitSonuc cevap = default(KayitSonuc);
                    cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion FaturaKilitDurumKaydetSync_Body

            }

            public static TTMessage FaturaKilitKontrolASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int UygulamaId, int FaturaId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","FaturaKilitKontrolASync_ServerSide", new Guid("285b535f-f4e2-4480-a0c0-b26096ec51f1"), userName, password, callerObject, BIRIM_ID_STR, UygulamaId, FaturaId);
            }

            private static KayitSonuc FaturaKilitKontrolASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int UygulamaId, int FaturaId)
            {

#region FaturaKilitKontrolASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "FaturaKilitKontrol";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("UygulamaId", (object)UygulamaId),
                        Tuple.Create("FaturaId", (object)FaturaId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    KayitSonuc cevap = default(KayitSonuc);
                    
                    try
                    {
                        cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, UygulamaId, FaturaId }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, UygulamaId, FaturaId }, null);

                    return cevap;
                

#endregion FaturaKilitKontrolASync_Body

            }

            public static KayitSonuc FaturaKilitKontrolSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, int UygulamaId, int FaturaId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KayitSonuc) TTMessageFactory.SyncCall(siteID, new Guid("7f94fef6-f105-4c6f-b3a1-381d24f6591c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","FaturaKilitKontrolSync_ServerSide", userName, password, BIRIM_ID_STR, UygulamaId, FaturaId);
            }


            private static KayitSonuc FaturaKilitKontrolSync_ServerSide(string userName, string password, string BIRIM_ID_STR, int UygulamaId, int FaturaId)
            {

#region FaturaKilitKontrolSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "FaturaKilitKontrol";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("UygulamaId", (object)UygulamaId),
                        Tuple.Create("FaturaId", (object)FaturaId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    KayitSonuc cevap = default(KayitSonuc);
                    cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion FaturaKilitKontrolSync_Body

            }

            public static TTMessage HBYSDepoDurumEkleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, HBYSDepoDurumInfo[] HBYSDepoDurumInfo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","HBYSDepoDurumEkleASync_ServerSide", new Guid("23a0b250-7b61-44d3-a9c4-1ba6310e5684"), userName, password, callerObject, BIRIM_ID_STR, HBYSDepoDurumInfo);
            }

            private static KayitSonuc HBYSDepoDurumEkleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, HBYSDepoDurumInfo[] HBYSDepoDurumInfo)
            {

#region HBYSDepoDurumEkleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "HBYSDepoDurumEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("HBYSDepoDurumInfo", (object)HBYSDepoDurumInfo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    KayitSonuc cevap = default(KayitSonuc);
                    
                    try
                    {
                        cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, HBYSDepoDurumInfo }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, HBYSDepoDurumInfo }, null);

                    return cevap;
                

#endregion HBYSDepoDurumEkleASync_Body

            }

            public static KayitSonuc HBYSDepoDurumEkleSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, HBYSDepoDurumInfo[] HBYSDepoDurumInfo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KayitSonuc) TTMessageFactory.SyncCall(siteID, new Guid("c2e8f0ae-0ce6-47da-a068-ea4aa36f14c4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","HBYSDepoDurumEkleSync_ServerSide", userName, password, BIRIM_ID_STR, HBYSDepoDurumInfo);
            }


            private static KayitSonuc HBYSDepoDurumEkleSync_ServerSide(string userName, string password, string BIRIM_ID_STR, HBYSDepoDurumInfo[] HBYSDepoDurumInfo)
            {

#region HBYSDepoDurumEkleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "HBYSDepoDurumEkle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("HBYSDepoDurumInfo", (object)HBYSDepoDurumInfo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    KayitSonuc cevap = default(KayitSonuc);
                    cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HBYSDepoDurumEkleSync_Body

            }

            public static TTMessage HBYSDepoEkleGuncelleASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, HbysDepoInfo HbysDepoInfo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","HBYSDepoEkleGuncelleASync_ServerSide", new Guid("92d19e4e-3146-4495-8d0c-5ea92da0d8f3"), userName, password, callerObject, BIRIM_ID_STR, HbysDepoInfo);
            }

            private static KayitSonuc HBYSDepoEkleGuncelleASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, HbysDepoInfo HbysDepoInfo)
            {

#region HBYSDepoEkleGuncelleASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "HBYSDepoEkleGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("HbysDepoInfo", (object)HbysDepoInfo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    KayitSonuc cevap = default(KayitSonuc);
                    
                    try
                    {
                        cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, HbysDepoInfo }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, HbysDepoInfo }, null);

                    return cevap;
                

#endregion HBYSDepoEkleGuncelleASync_Body

            }

            public static KayitSonuc HBYSDepoEkleGuncelleSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, HbysDepoInfo HbysDepoInfo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KayitSonuc) TTMessageFactory.SyncCall(siteID, new Guid("bb133f57-8f58-4a47-bbb5-c15d50e1f2c9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","HBYSDepoEkleGuncelleSync_ServerSide", userName, password, BIRIM_ID_STR, HbysDepoInfo);
            }


            private static KayitSonuc HBYSDepoEkleGuncelleSync_ServerSide(string userName, string password, string BIRIM_ID_STR, HbysDepoInfo HbysDepoInfo)
            {

#region HBYSDepoEkleGuncelleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "HBYSDepoEkleGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("HbysDepoInfo", (object)HbysDepoInfo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    KayitSonuc cevap = default(KayitSonuc);
                    cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HBYSDepoEkleGuncelleSync_Body

            }

            public static TTMessage MalzemeStokEslesmeGetASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","MalzemeStokEslesmeGetASync_ServerSide", new Guid("720e4f7f-ae9f-4beb-a5ff-aaac85b40b80"), userName, password, callerObject, BIRIM_ID_STR);
            }

            private static MalzemeStokEslesmeInfoWS[] MalzemeStokEslesmeGetASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR)
            {

#region MalzemeStokEslesmeGetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "MalzemeStokEslesmeGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    MalzemeStokEslesmeInfoWS[] cevap = default(MalzemeStokEslesmeInfoWS[]);
                    
                    try
                    {
                        cevap = (MalzemeStokEslesmeInfoWS[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR }, null);

                    return cevap;
                

#endregion MalzemeStokEslesmeGetASync_Body

            }

            public static MalzemeStokEslesmeInfoWS[] MalzemeStokEslesmeGetSync(Guid siteID, string userName, string password, string BIRIM_ID_STR)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (MalzemeStokEslesmeInfoWS[]) TTMessageFactory.SyncCall(siteID, new Guid("6ce38a9c-322a-4498-9033-5013aac99650"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","MalzemeStokEslesmeGetSync_ServerSide", userName, password, BIRIM_ID_STR);
            }


            private static MalzemeStokEslesmeInfoWS[] MalzemeStokEslesmeGetSync_ServerSide(string userName, string password, string BIRIM_ID_STR)
            {

#region MalzemeStokEslesmeGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "MalzemeStokEslesmeGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    MalzemeStokEslesmeInfoWS[] cevap = default(MalzemeStokEslesmeInfoWS[]);
                    cevap = (MalzemeStokEslesmeInfoWS[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MalzemeStokEslesmeGetSync_Body

            }

            public static TTMessage MuayeneFaturaGetASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, MuayeneFaturaAramaKriterInfoWS AramaKriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","MuayeneFaturaGetASync_ServerSide", new Guid("78f027c4-835c-4d1a-b076-a429492b6998"), userName, password, callerObject, BIRIM_ID_STR, AramaKriter);
            }

            private static MuayeneFaturaInfoWS[] MuayeneFaturaGetASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, MuayeneFaturaAramaKriterInfoWS AramaKriter)
            {

#region MuayeneFaturaGetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "MuayeneFaturaGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("AramaKriter", (object)AramaKriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    MuayeneFaturaInfoWS[] cevap = default(MuayeneFaturaInfoWS[]);
                    
                    try
                    {
                        cevap = (MuayeneFaturaInfoWS[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, AramaKriter }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, AramaKriter }, null);

                    return cevap;
                

#endregion MuayeneFaturaGetASync_Body

            }

            public static MuayeneFaturaInfoWS[] MuayeneFaturaGetSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, MuayeneFaturaAramaKriterInfoWS AramaKriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (MuayeneFaturaInfoWS[]) TTMessageFactory.SyncCall(siteID, new Guid("d9ea9bf0-0c7f-4c51-98ea-0330a9999f7a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","MuayeneFaturaGetSync_ServerSide", userName, password, BIRIM_ID_STR, AramaKriter);
            }


            private static MuayeneFaturaInfoWS[] MuayeneFaturaGetSync_ServerSide(string userName, string password, string BIRIM_ID_STR, MuayeneFaturaAramaKriterInfoWS AramaKriter)
            {

#region MuayeneFaturaGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "MuayeneFaturaGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("AramaKriter", (object)AramaKriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    MuayeneFaturaInfoWS[] cevap = default(MuayeneFaturaInfoWS[]);
                    cevap = (MuayeneFaturaInfoWS[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MuayeneFaturaGetSync_Body

            }

            public static TTMessage MuayeneFaturaTifKaydetASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, string TifNo, System.DateTime TifTarihi, int UygulamaId, int FaturaId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","MuayeneFaturaTifKaydetASync_ServerSide", new Guid("903d8acf-537e-47c1-92d0-f7c19708a98d"), userName, password, callerObject, BIRIM_ID_STR, TifNo, TifTarihi, UygulamaId, FaturaId);
            }

            private static KayitSonuc MuayeneFaturaTifKaydetASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, string TifNo, System.DateTime TifTarihi, int UygulamaId, int FaturaId)
            {

#region MuayeneFaturaTifKaydetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "MuayeneFaturaTifKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("TifNo", (object)TifNo),
                        Tuple.Create("TifTarihi", (object)TifTarihi),
                        Tuple.Create("UygulamaId", (object)UygulamaId),
                        Tuple.Create("FaturaId", (object)FaturaId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    KayitSonuc cevap = default(KayitSonuc);
                    
                    try
                    {
                        cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, TifNo, TifTarihi, UygulamaId, FaturaId }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, TifNo, TifTarihi, UygulamaId, FaturaId }, null);

                    return cevap;
                

#endregion MuayeneFaturaTifKaydetASync_Body

            }

            public static KayitSonuc MuayeneFaturaTifKaydetSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, string TifNo, System.DateTime TifTarihi, int UygulamaId, int FaturaId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KayitSonuc) TTMessageFactory.SyncCall(siteID, new Guid("4e386db7-81ca-48f0-aae8-c6243830715a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","MuayeneFaturaTifKaydetSync_ServerSide", userName, password, BIRIM_ID_STR, TifNo, TifTarihi, UygulamaId, FaturaId);
            }


            private static KayitSonuc MuayeneFaturaTifKaydetSync_ServerSide(string userName, string password, string BIRIM_ID_STR, string TifNo, System.DateTime TifTarihi, int UygulamaId, int FaturaId)
            {

#region MuayeneFaturaTifKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "MuayeneFaturaTifKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("TifNo", (object)TifNo),
                        Tuple.Create("TifTarihi", (object)TifTarihi),
                        Tuple.Create("UygulamaId", (object)UygulamaId),
                        Tuple.Create("FaturaId", (object)FaturaId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    KayitSonuc cevap = default(KayitSonuc);
                    cevap = (KayitSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion MuayeneFaturaTifKaydetSync_Body

            }

            public static TTMessage TalepTedarikAkisGetASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int TalepId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","TalepTedarikAkisGetASync_ServerSide", new Guid("fdd0940a-203e-4f10-909b-d9b0a45c5140"), userName, password, callerObject, BIRIM_ID_STR, TalepId);
            }

            private static TalepTedarikAkisSureInfo TalepTedarikAkisGetASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int TalepId)
            {

#region TalepTedarikAkisGetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "TalepTedarikAkisGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("TalepId", (object)TalepId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    TalepTedarikAkisSureInfo cevap = default(TalepTedarikAkisSureInfo);
                    
                    try
                    {
                        cevap = (TalepTedarikAkisSureInfo)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, TalepId }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, TalepId }, null);

                    return cevap;
                

#endregion TalepTedarikAkisGetASync_Body

            }

            public static TalepTedarikAkisSureInfo TalepTedarikAkisGetSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, int TalepId)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (TalepTedarikAkisSureInfo) TTMessageFactory.SyncCall(siteID, new Guid("543334ba-1b76-4cd6-844b-a49b17b48976"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","TalepTedarikAkisGetSync_ServerSide", userName, password, BIRIM_ID_STR, TalepId);
            }


            private static TalepTedarikAkisSureInfo TalepTedarikAkisGetSync_ServerSide(string userName, string password, string BIRIM_ID_STR, int TalepId)
            {

#region TalepTedarikAkisGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "TalepTedarikAkisGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("TalepId", (object)TalepId),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    TalepTedarikAkisSureInfo cevap = default(TalepTedarikAkisSureInfo);
                    cevap = (TalepTedarikAkisSureInfo)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TalepTedarikAkisGetSync_Body

            }

            public static TTMessage TopluAlimTalepListGetASync(Guid siteID, string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int IHALE_ID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","TopluAlimTalepListGetASync_ServerSide", new Guid("6d5b9dce-20aa-4253-a0b5-2836667e4b69"), userName, password, callerObject, BIRIM_ID_STR, IHALE_ID);
            }

            private static TopluAlimTalepInfoWS[] TopluAlimTalepListGetASync_ServerSide(string userName, string password, IWebMethodCallback callerObject, string BIRIM_ID_STR, int IHALE_ID)
            {

#region TopluAlimTalepListGetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "TopluAlimTalepListGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("IHALE_ID", (object)IHALE_ID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;


                    TopluAlimTalepInfoWS[] cevap = default(TopluAlimTalepInfoWS[]);
                    
                    try
                    {
                        cevap = (TopluAlimTalepInfoWS[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, IHALE_ID }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { BIRIM_ID_STR, IHALE_ID }, null);

                    return cevap;
                

#endregion TopluAlimTalepListGetASync_Body

            }

            public static TopluAlimTalepInfoWS[] TopluAlimTalepListGetSync(Guid siteID, string userName, string password, string BIRIM_ID_STR, int IHALE_ID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (TopluAlimTalepInfoWS[]) TTMessageFactory.SyncCall(siteID, new Guid("fb92c982-4229-42b9-9f4f-3dd035a9ea74"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FsTasinirWebServis+WebMethods, TTObjectClasses","TopluAlimTalepListGetSync_ServerSide", userName, password, BIRIM_ID_STR, IHALE_ID);
            }


            private static TopluAlimTalepInfoWS[] TopluAlimTalepListGetSync_ServerSide(string userName, string password, string BIRIM_ID_STR, int IHALE_ID)
            {

#region TopluAlimTalepListGetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FsTasinirWebServis";
                    header.ServiceId = "4e357f5f-6e06-47a7-b35e-90b956b6fb14";
                    header.MethodName = "TopluAlimTalepListGet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("BIRIM_ID_STR", (object)BIRIM_ID_STR),
                        Tuple.Create("IHALE_ID", (object)IHALE_ID),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    TopluAlimTalepInfoWS[] cevap = default(TopluAlimTalepInfoWS[]);
                    cevap = (TopluAlimTalepInfoWS[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TopluAlimTalepListGetSync_Body

            }

        }
                    
        protected FsTasinirWebServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FsTasinirWebServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FsTasinirWebServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FsTasinirWebServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FsTasinirWebServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FSTASINIRWEBSERVIS", dataRow) { }
        protected FsTasinirWebServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FSTASINIRWEBSERVIS", dataRow, isImported) { }
        public FsTasinirWebServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FsTasinirWebServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FsTasinirWebServis() : base() { }

    }
}