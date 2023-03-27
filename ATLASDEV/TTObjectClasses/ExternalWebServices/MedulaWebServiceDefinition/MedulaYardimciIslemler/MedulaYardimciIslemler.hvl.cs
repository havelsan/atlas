
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaYardimciIslemler")] 

    /// <summary>
    /// MEDULA YArd?mc? ??lemleri
    /// </summary>
    public  abstract  partial class MedulaYardimciIslemler : TTObject
    {
        public class MedulaYardimciIslemlerList : TTObjectCollection<MedulaYardimciIslemler> { }
                    
        public class ChildMedulaYardimciIslemlerCollection : TTObject.TTChildObjectCollection<MedulaYardimciIslemler>
        {
            public ChildMedulaYardimciIslemlerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaYardimciIslemlerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage barkodSutEslesmeSorguASync(Guid siteID, IWebMethodCallback callerObject, barkodSutEslesmeSorguGirisDVO barkodSutEslesmeSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","barkodSutEslesmeSorguASync_ServerSide", new Guid("5ddb3829-7625-4e39-8c77-c6d66d990457"), callerObject, barkodSutEslesmeSorguGiris);
            }

            private static barkodSutEslesmeSorguCevapDVO barkodSutEslesmeSorguASync_ServerSide(IWebMethodCallback callerObject, barkodSutEslesmeSorguGirisDVO barkodSutEslesmeSorguGiris)
            {

#region barkodSutEslesmeSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "barkodSutEslesmeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("barkodSutEslesmeSorguGiris", (object)barkodSutEslesmeSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    barkodSutEslesmeSorguCevapDVO cevap = default(barkodSutEslesmeSorguCevapDVO);
                    
                    try
                    {
                        cevap = (barkodSutEslesmeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { barkodSutEslesmeSorguGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { barkodSutEslesmeSorguGiris }, null);

                    return cevap;
                

#endregion barkodSutEslesmeSorguASync_Body

            }

            public static barkodSutEslesmeSorguCevapDVO barkodSutEslesmeSorguSync(Guid siteID, barkodSutEslesmeSorguGirisDVO barkodSutEslesmeSorguGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (barkodSutEslesmeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("61a2d84f-4419-465b-a59b-fe80fd098ef2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","barkodSutEslesmeSorguSync_ServerSide", barkodSutEslesmeSorguGiris);
            }


            private static barkodSutEslesmeSorguCevapDVO barkodSutEslesmeSorguSync_ServerSide(barkodSutEslesmeSorguGirisDVO barkodSutEslesmeSorguGiris)
            {

#region barkodSutEslesmeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "barkodSutEslesmeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("barkodSutEslesmeSorguGiris", (object)barkodSutEslesmeSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    barkodSutEslesmeSorguCevapDVO cevap = default(barkodSutEslesmeSorguCevapDVO);
                    cevap = (barkodSutEslesmeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion barkodSutEslesmeSorguSync_Body

            }

            public static TTMessage damarIziDogrulamaSorguASync(Guid siteID, IWebMethodCallback callerObject, damarIziDogrulamaSorguGirisDVO damarIziDogrulamaSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","damarIziDogrulamaSorguASync_ServerSide", new Guid("13173b20-82e1-4d60-adc5-adff193474db"), callerObject, damarIziDogrulamaSorguGiris);
            }

            private static damarIziDogrulamaSorguCevapDVO damarIziDogrulamaSorguASync_ServerSide(IWebMethodCallback callerObject, damarIziDogrulamaSorguGirisDVO damarIziDogrulamaSorguGiris)
            {

#region damarIziDogrulamaSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "damarIziDogrulamaSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("damarIziDogrulamaSorguGiris", (object)damarIziDogrulamaSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    damarIziDogrulamaSorguCevapDVO cevap = default(damarIziDogrulamaSorguCevapDVO);
                    
                    try
                    {
                        cevap = (damarIziDogrulamaSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { damarIziDogrulamaSorguGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { damarIziDogrulamaSorguGiris }, null);

                    return cevap;
                

#endregion damarIziDogrulamaSorguASync_Body

            }

            public static damarIziDogrulamaSorguCevapDVO damarIziDogrulamaSorguSync(Guid siteID, damarIziDogrulamaSorguGirisDVO damarIziDogrulamaSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (damarIziDogrulamaSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("38ad20fc-b5c5-4276-aa86-ca4960e4fb27"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","damarIziDogrulamaSorguSync_ServerSide", damarIziDogrulamaSorguGiris);
            }


            private static damarIziDogrulamaSorguCevapDVO damarIziDogrulamaSorguSync_ServerSide(damarIziDogrulamaSorguGirisDVO damarIziDogrulamaSorguGiris)
            {

#region damarIziDogrulamaSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "damarIziDogrulamaSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("damarIziDogrulamaSorguGiris", (object)damarIziDogrulamaSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    damarIziDogrulamaSorguCevapDVO cevap = default(damarIziDogrulamaSorguCevapDVO);
                    cevap = (damarIziDogrulamaSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion damarIziDogrulamaSorguSync_Body

            }

            public static TTMessage doktorAraASync(Guid siteID, IWebMethodCallback callerObject, doktorAraGirisDVO doktorAraGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","doktorAraASync_ServerSide", new Guid("0be0a81e-6105-4487-b965-fba1a578bd6c"), callerObject, doktorAraGiris);
            }

            private static doktorAraCevapDVO doktorAraASync_ServerSide(IWebMethodCallback callerObject, doktorAraGirisDVO doktorAraGiris)
            {

#region doktorAraASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "doktorAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("doktorAraGiris", (object)doktorAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    doktorAraCevapDVO cevap = default(doktorAraCevapDVO);
                    
                    try
                    {
                        cevap = (doktorAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { doktorAraGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { doktorAraGiris }, null);

                    return cevap;
                

#endregion doktorAraASync_Body

            }

            public static doktorAraCevapDVO doktorAraSync(Guid siteID, doktorAraGirisDVO doktorAraGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (doktorAraCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c928b070-2afc-4b56-97fc-69e37e76903e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","doktorAraSync_ServerSide", doktorAraGiris);
            }


            private static doktorAraCevapDVO doktorAraSync_ServerSide(doktorAraGirisDVO doktorAraGiris)
            {

#region doktorAraSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "doktorAra";
                    header.CallTimeout = 15;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("doktorAraGiris", (object)doktorAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    doktorAraCevapDVO cevap = default(doktorAraCevapDVO);
                    cevap = (doktorAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion doktorAraSync_Body

            }

            public static TTMessage eNabizBildirimSorguASync(Guid siteID, IWebMethodCallback callerObject, eNabizBildirimSorguGirisDVO eNabizBildirimSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","eNabizBildirimSorguASync_ServerSide", new Guid("576794f5-57e2-4730-8467-466054b8c389"), callerObject, eNabizBildirimSorguGiris);
            }

            private static eNabizBildirimSorguCevapDVO eNabizBildirimSorguASync_ServerSide(IWebMethodCallback callerObject, eNabizBildirimSorguGirisDVO eNabizBildirimSorguGiris)
            {

#region eNabizBildirimSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "eNabizBildirimSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eNabizBildirimSorguGiris", (object)eNabizBildirimSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    eNabizBildirimSorguCevapDVO cevap = default(eNabizBildirimSorguCevapDVO);
                    
                    try
                    {
                        cevap = (eNabizBildirimSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { eNabizBildirimSorguGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { eNabizBildirimSorguGiris }, null);

                    return cevap;
                

#endregion eNabizBildirimSorguASync_Body

            }

            public static eNabizBildirimSorguCevapDVO eNabizBildirimSorguSync(Guid siteID, eNabizBildirimSorguGirisDVO eNabizBildirimSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (eNabizBildirimSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d35f7496-8ae2-43e7-9085-2d64f0e01ff7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","eNabizBildirimSorguSync_ServerSide", eNabizBildirimSorguGiris);
            }


            private static eNabizBildirimSorguCevapDVO eNabizBildirimSorguSync_ServerSide(eNabizBildirimSorguGirisDVO eNabizBildirimSorguGiris)
            {

#region eNabizBildirimSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "eNabizBildirimSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("eNabizBildirimSorguGiris", (object)eNabizBildirimSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    eNabizBildirimSorguCevapDVO cevap = default(eNabizBildirimSorguCevapDVO);
                    cevap = (eNabizBildirimSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion eNabizBildirimSorguSync_Body

            }

            public static TTMessage evrakTakipGrupKodlariSorguASync(Guid siteID, IWebMethodCallback callerObject, evrakTakipGrupKoduSorguGirisDVO evrakTakipGrupKodlariSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","evrakTakipGrupKodlariSorguASync_ServerSide", new Guid("b9a87d32-6a8b-4712-af11-0ef85b7434e7"), callerObject, evrakTakipGrupKodlariSorguGiris);
            }

            private static evrakTakipGrupKoduSorguCevapDVO evrakTakipGrupKodlariSorguASync_ServerSide(IWebMethodCallback callerObject, evrakTakipGrupKoduSorguGirisDVO evrakTakipGrupKodlariSorguGiris)
            {

#region evrakTakipGrupKodlariSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "evrakTakipGrupKodlariSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("evrakTakipGrupKodlariSorguGiris", (object)evrakTakipGrupKodlariSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    evrakTakipGrupKoduSorguCevapDVO cevap = default(evrakTakipGrupKoduSorguCevapDVO);
                    
                    try
                    {
                        cevap = (evrakTakipGrupKoduSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { evrakTakipGrupKodlariSorguGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { evrakTakipGrupKodlariSorguGiris }, null);

                    return cevap;
                

#endregion evrakTakipGrupKodlariSorguASync_Body

            }

            public static evrakTakipGrupKoduSorguCevapDVO evrakTakipGrupKodlariSorguSync(Guid siteID, evrakTakipGrupKoduSorguGirisDVO evrakTakipGrupKodlariSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (evrakTakipGrupKoduSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("dd093233-9cba-4f22-9127-0ab32ccb78bd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","evrakTakipGrupKodlariSorguSync_ServerSide", evrakTakipGrupKodlariSorguGiris);
            }


            private static evrakTakipGrupKoduSorguCevapDVO evrakTakipGrupKodlariSorguSync_ServerSide(evrakTakipGrupKoduSorguGirisDVO evrakTakipGrupKodlariSorguGiris)
            {

#region evrakTakipGrupKodlariSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "evrakTakipGrupKodlariSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("evrakTakipGrupKodlariSorguGiris", (object)evrakTakipGrupKodlariSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    evrakTakipGrupKoduSorguCevapDVO cevap = default(evrakTakipGrupKoduSorguCevapDVO);
                    cevap = (evrakTakipGrupKoduSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion evrakTakipGrupKodlariSorguSync_Body

            }

            public static TTMessage getOrneklenmisTakiplerASync(Guid siteID, IWebMethodCallback callerObject, orneklenmisGirisDVO orneklenmisGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","getOrneklenmisTakiplerASync_ServerSide", new Guid("d21fd19c-9bd4-442e-a185-0bfaf224f092"), callerObject, orneklenmisGiris);
            }

            private static orneklenmisCevapDVO getOrneklenmisTakiplerASync_ServerSide(IWebMethodCallback callerObject, orneklenmisGirisDVO orneklenmisGiris)
            {

#region getOrneklenmisTakiplerASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "getOrneklenmisTakipler";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("orneklenmisGiris", (object)orneklenmisGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    orneklenmisCevapDVO cevap = default(orneklenmisCevapDVO);
                    
                    try
                    {
                        cevap = (orneklenmisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { orneklenmisGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { orneklenmisGiris }, null);

                    return cevap;
                

#endregion getOrneklenmisTakiplerASync_Body

            }

            public static orneklenmisCevapDVO getOrneklenmisTakiplerSync(Guid siteID, orneklenmisGirisDVO orneklenmisGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (orneklenmisCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("24132ea2-0a19-45ec-82a4-075e6412a8f3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","getOrneklenmisTakiplerSync_ServerSide", orneklenmisGirisDVO);
            }


            private static orneklenmisCevapDVO getOrneklenmisTakiplerSync_ServerSide(orneklenmisGirisDVO orneklenmisGirisDVO)
            {

#region getOrneklenmisTakiplerSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "getOrneklenmisTakipler";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("orneklenmisGirisDVO", (object)orneklenmisGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    orneklenmisCevapDVO cevap = default(orneklenmisCevapDVO);
                    cevap = (orneklenmisCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion getOrneklenmisTakiplerSync_Body

            }

            public static string getRemoteAddrSync(Guid siteID)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (string) TTMessageFactory.SyncCall(siteID, new Guid("3b35ecfa-b517-444c-a4cd-0b54f074558e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","getRemoteAddrSync_ServerSide");
            }


            private static string getRemoteAddrSync_ServerSide()
            {

#region getRemoteAddrSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "getRemoteAddr";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    string cevap = default(string);
                    cevap = (string)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion getRemoteAddrSync_Body

            }

            public static TTMessage guncelSutKodlariASync(Guid siteID, IWebMethodCallback callerObject, guncelSutSorguGirisDVO guncelSutSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","guncelSutKodlariASync_ServerSide", new Guid("3f6b3cb3-c91d-4000-b5b9-ab79801eb71d"), callerObject, guncelSutSorguGiris);
            }

            private static guncelSutSorguCevapDVO guncelSutKodlariASync_ServerSide(IWebMethodCallback callerObject, guncelSutSorguGirisDVO guncelSutSorguGiris)
            {

#region guncelSutKodlariASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "guncelSutKodlari";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("guncelSutSorguGiris", (object)guncelSutSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    guncelSutSorguCevapDVO cevap = default(guncelSutSorguCevapDVO);
                    
                    try
                    {
                        cevap = (guncelSutSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { guncelSutSorguGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { guncelSutSorguGiris }, null);

                    return cevap;
                

#endregion guncelSutKodlariASync_Body

            }

            public static guncelSutSorguCevapDVO guncelSutKodlariSync(Guid siteID, guncelSutSorguGirisDVO guncelSutSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (guncelSutSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("aa8f084a-9b31-41ad-adbb-db3ef1f6ed6b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","guncelSutKodlariSync_ServerSide", guncelSutSorguGiris);
            }


            private static guncelSutSorguCevapDVO guncelSutKodlariSync_ServerSide(guncelSutSorguGirisDVO guncelSutSorguGiris)
            {

#region guncelSutKodlariSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "guncelSutKodlari";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("guncelSutSorguGiris", (object)guncelSutSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    guncelSutSorguCevapDVO cevap = default(guncelSutSorguCevapDVO);
                    cevap = (guncelSutSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion guncelSutKodlariSync_Body

            }

            public static TTMessage ilacAraASync(Guid siteID, IWebMethodCallback callerObject, ilacAraGirisDVO ilacAraGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","ilacAraASync_ServerSide", new Guid("01cee18f-2241-47c9-a36c-1b8362e6a492"), callerObject, ilacAraGiris);
            }

            private static ilacAraCevapDVO ilacAraASync_ServerSide(IWebMethodCallback callerObject, ilacAraGirisDVO ilacAraGiris)
            {

#region ilacAraASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "ilacAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacAraGiris", (object)ilacAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    ilacAraCevapDVO cevap = default(ilacAraCevapDVO);
                    
                    try
                    {
                        cevap = (ilacAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { ilacAraGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { ilacAraGiris }, null);

                    return cevap;
                

#endregion ilacAraASync_Body

            }

            public static ilacAraCevapDVO ilacAraSync(Guid siteID, ilacAraGirisDVO ilacAraGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ilacAraCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("a894ec76-3262-46d1-a651-7fcb00333e20"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","ilacAraSync_ServerSide", ilacAraGiris);
            }


            private static ilacAraCevapDVO ilacAraSync_ServerSide(ilacAraGirisDVO ilacAraGiris)
            {

#region ilacAraSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "ilacAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ilacAraGiris", (object)ilacAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    ilacAraCevapDVO cevap = default(ilacAraCevapDVO);
                    cevap = (ilacAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ilacAraSync_Body

            }

            public static TTMessage katilimPayiUcretiASync(Guid siteID, IWebMethodCallback callerObject, katilimPayiGirisDVO katilimPayiGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","katilimPayiUcretiASync_ServerSide", new Guid("6595945e-d345-4887-b35c-ae5ea498391c"), callerObject, katilimPayiGiris);
            }

            private static katilimPayiCevapDVO katilimPayiUcretiASync_ServerSide(IWebMethodCallback callerObject, katilimPayiGirisDVO katilimPayiGiris)
            {

#region katilimPayiUcretiASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "katilimPayiUcreti";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("katilimPayiGiris", (object)katilimPayiGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    katilimPayiCevapDVO cevap = default(katilimPayiCevapDVO);
                    
                    try
                    {
                        cevap = (katilimPayiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { katilimPayiGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { katilimPayiGiris }, null);

                    return cevap;
                

#endregion katilimPayiUcretiASync_Body

            }

            public static katilimPayiCevapDVO katilimPayiUcretiSync(Guid siteID, katilimPayiGirisDVO katilimPayiGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (katilimPayiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b6afe23e-5428-46c9-8131-2a9a152bdb57"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","katilimPayiUcretiSync_ServerSide", katilimPayiGiris);
            }


            private static katilimPayiCevapDVO katilimPayiUcretiSync_ServerSide(katilimPayiGirisDVO katilimPayiGiris)
            {

#region katilimPayiUcretiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "katilimPayiUcreti";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("katilimPayiGiris", (object)katilimPayiGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    katilimPayiCevapDVO cevap = default(katilimPayiCevapDVO);
                    cevap = (katilimPayiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion katilimPayiUcretiSync_Body

            }

            public static TTMessage kesintiYapilmisIslemlerASync(Guid siteID, IWebMethodCallback callerObject, evrakKesintiGirisDVO evrakKesintiGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","kesintiYapilmisIslemlerASync_ServerSide", new Guid("246d6e43-71e5-4404-95aa-0bf79ca7c638"), callerObject, evrakKesintiGiris);
            }

            private static evrakKesintiCevapDVO kesintiYapilmisIslemlerASync_ServerSide(IWebMethodCallback callerObject, evrakKesintiGirisDVO evrakKesintiGiris)
            {

#region kesintiYapilmisIslemlerASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "kesintiYapilmisIslemler";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("evrakKesintiGiris", (object)evrakKesintiGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    evrakKesintiCevapDVO cevap = default(evrakKesintiCevapDVO);
                    
                    try
                    {
                        cevap = (evrakKesintiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { evrakKesintiGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { evrakKesintiGiris }, null);

                    return cevap;
                

#endregion kesintiYapilmisIslemlerASync_Body

            }

            public static evrakKesintiCevapDVO kesintiYapilmisIslemlerSync(Guid siteID, evrakKesintiGirisDVO evrakKesintiGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (evrakKesintiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d5ca5b57-67a3-4faa-b82c-85aabaa1fff7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","kesintiYapilmisIslemlerSync_ServerSide", evrakKesintiGiris);
            }


            private static evrakKesintiCevapDVO kesintiYapilmisIslemlerSync_ServerSide(evrakKesintiGirisDVO evrakKesintiGiris)
            {

#region kesintiYapilmisIslemlerSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "kesintiYapilmisIslemler";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("evrakKesintiGiris", (object)evrakKesintiGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    evrakKesintiCevapDVO cevap = default(evrakKesintiCevapDVO);
                    cevap = (evrakKesintiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kesintiYapilmisIslemlerSync_Body

            }

            public static TTMessage kisiGecmisIslemSorguASync(Guid siteID, IWebMethodCallback callerObject, kisiGecmisIslemlerGirisDVO kisiGecmisIslemlerGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","kisiGecmisIslemSorguASync_ServerSide", new Guid("a6028153-21ba-4d48-8599-ec0039a24159"), callerObject, kisiGecmisIslemlerGiris);
            }

            private static kisiGecmisIslemlerCevapDVO kisiGecmisIslemSorguASync_ServerSide(IWebMethodCallback callerObject, kisiGecmisIslemlerGirisDVO kisiGecmisIslemlerGiris)
            {

#region kisiGecmisIslemSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "kisiGecmisIslemSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kisiGecmisIslemlerGiris", (object)kisiGecmisIslemlerGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    kisiGecmisIslemlerCevapDVO cevap = default(kisiGecmisIslemlerCevapDVO);
                    
                    try
                    {
                        cevap = (kisiGecmisIslemlerCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { kisiGecmisIslemlerGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { kisiGecmisIslemlerGiris }, null);

                    return cevap;
                

#endregion kisiGecmisIslemSorguASync_Body

            }

            public static kisiGecmisIslemlerCevapDVO kisiGecmisIslemSorguSync(Guid siteID, kisiGecmisIslemlerGirisDVO kisiGecmisIslemlerGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (kisiGecmisIslemlerCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("56dd07d2-69fd-4e4f-947b-290f4050c52c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","kisiGecmisIslemSorguSync_ServerSide", kisiGecmisIslemlerGiris);
            }


            private static kisiGecmisIslemlerCevapDVO kisiGecmisIslemSorguSync_ServerSide(kisiGecmisIslemlerGirisDVO kisiGecmisIslemlerGiris)
            {

#region kisiGecmisIslemSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "kisiGecmisIslemSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kisiGecmisIslemlerGiris", (object)kisiGecmisIslemlerGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    kisiGecmisIslemlerCevapDVO cevap = default(kisiGecmisIslemlerCevapDVO);
                    cevap = (kisiGecmisIslemlerCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kisiGecmisIslemSorguSync_Body

            }

            public static kisiOlumKayitCevapDVO kisiVefatKayitSync(Guid siteID, kisiOlumKayitGirisDVO kisiOlumKayitGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (kisiOlumKayitCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d2858694-3c05-469f-900d-fea5b0d58fce"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","kisiVefatKayitSync_ServerSide", kisiOlumKayitGiris);
            }


            private static kisiOlumKayitCevapDVO kisiVefatKayitSync_ServerSide(kisiOlumKayitGirisDVO kisiOlumKayitGiris)
            {

#region kisiVefatKayitSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "kisiVefatKayit";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kisiOlumKayitGiris", (object)kisiOlumKayitGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    kisiOlumKayitCevapDVO cevap = default(kisiOlumKayitCevapDVO);
                    cevap = (kisiOlumKayitCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kisiVefatKayitSync_Body

            }

            public static kurumSevkTalepNoSorguCevapDVO kurumSevkTalepNoSorguSync(Guid siteID, kurumSevkTalepNoSorguGirisDVO kurumSevkTalepNoSorguGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (kurumSevkTalepNoSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("ae26af1b-29c5-4f13-85fc-586fe57aacdf"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","kurumSevkTalepNoSorguSync_ServerSide", kurumSevkTalepNoSorguGiris);
            }


            private static kurumSevkTalepNoSorguCevapDVO kurumSevkTalepNoSorguSync_ServerSide(kurumSevkTalepNoSorguGirisDVO kurumSevkTalepNoSorguGiris)
            {

#region kurumSevkTalepNoSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "kurumSevkTalepNoSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kurumSevkTalepNoSorguGiris", (object)kurumSevkTalepNoSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    kurumSevkTalepNoSorguCevapDVO cevap = default(kurumSevkTalepNoSorguCevapDVO);
                    cevap = (kurumSevkTalepNoSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion kurumSevkTalepNoSorguSync_Body

            }

            public static TTMessage saglikTesisiAraASync(Guid siteID, IWebMethodCallback callerObject, saglikTesisiAraGirisDVO saglikTesisiAraGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","saglikTesisiAraASync_ServerSide", new Guid("6dd06584-0e1d-41f7-9405-456fe6918c76"), callerObject, saglikTesisiAraGiris);
            }

            private static saglikTesisiAraCevapDVO saglikTesisiAraASync_ServerSide(IWebMethodCallback callerObject, saglikTesisiAraGirisDVO saglikTesisiAraGiris)
            {

#region saglikTesisiAraASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "saglikTesisiAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("saglikTesisiAraGiris", (object)saglikTesisiAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    saglikTesisiAraCevapDVO cevap = default(saglikTesisiAraCevapDVO);
                    
                    try
                    {
                        cevap = (saglikTesisiAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { saglikTesisiAraGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { saglikTesisiAraGiris }, null);

                    return cevap;
                

#endregion saglikTesisiAraASync_Body

            }

            public static saglikTesisiAraCevapDVO saglikTesisiAraSync(Guid siteID, saglikTesisiAraGirisDVO saglikTesisiAraGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (saglikTesisiAraCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("6bc8917e-48f6-4c3e-9b4e-315d05775b37"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","saglikTesisiAraSync_ServerSide", saglikTesisiAraGiris);
            }


            private static saglikTesisiAraCevapDVO saglikTesisiAraSync_ServerSide(saglikTesisiAraGirisDVO saglikTesisiAraGiris)
            {

#region saglikTesisiAraSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "saglikTesisiAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("saglikTesisiAraGiris", (object)saglikTesisiAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    saglikTesisiAraCevapDVO cevap = default(saglikTesisiAraCevapDVO);
                    cevap = (saglikTesisiAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion saglikTesisiAraSync_Body

            }

            public static TTMessage takipAraASync(Guid siteID, IWebMethodCallback callerObject, takipAraGirisDVO takipAraGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","takipAraASync_ServerSide", new Guid("c522d719-a763-4b8a-a8c4-163839d03e55"), callerObject, takipAraGiris);
            }

            private static takipAraCevapDVO takipAraASync_ServerSide(IWebMethodCallback callerObject, takipAraGirisDVO takipAraGiris)
            {

#region takipAraASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "takipAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipAraGiris", (object)takipAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    takipAraCevapDVO cevap = default(takipAraCevapDVO);
                    
                    try
                    {
                        cevap = (takipAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { takipAraGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { takipAraGiris }, null);

                    return cevap;
                

#endregion takipAraASync_Body

            }

            public static takipAraCevapDVO takipAraSync(Guid siteID, takipAraGirisDVO takipAraGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipAraCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("14ac7b7b-224b-4e37-a84b-a6dc20151274"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","takipAraSync_ServerSide", takipAraGiris);
            }


            private static takipAraCevapDVO takipAraSync_ServerSide(takipAraGirisDVO takipAraGiris)
            {

#region takipAraSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "takipAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipAraGiris", (object)takipAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipAraCevapDVO cevap = default(takipAraCevapDVO);
                    cevap = (takipAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion takipAraSync_Body

            }

            public static TTMessage takipBilgileriListesiASync(Guid siteID, IWebMethodCallback callerObject, takipBilgisiGirisDVO takipBilgisiGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","takipBilgileriListesiASync_ServerSide", new Guid("b1a9d8ac-41d8-42b0-833d-6d558260435e"), callerObject, takipBilgisiGiris);
            }

            private static takipBilgisiCevapDVO takipBilgileriListesiASync_ServerSide(IWebMethodCallback callerObject, takipBilgisiGirisDVO takipBilgisiGiris)
            {

#region takipBilgileriListesiASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "takipBilgileriListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipBilgisiGiris", (object)takipBilgisiGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    takipBilgisiCevapDVO cevap = default(takipBilgisiCevapDVO);
                    
                    try
                    {
                        cevap = (takipBilgisiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { takipBilgisiGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { takipBilgisiGiris }, null);

                    return cevap;
                

#endregion takipBilgileriListesiASync_Body

            }

            public static takipBilgisiCevapDVO takipBilgileriListesiSync(Guid siteID, takipBilgisiGirisDVO takipBilgisiGirisDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipBilgisiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f127eb4c-33de-45e6-bad0-6876ea13f80d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","takipBilgileriListesiSync_ServerSide", takipBilgisiGirisDVO);
            }


            private static takipBilgisiCevapDVO takipBilgileriListesiSync_ServerSide(takipBilgisiGirisDVO takipBilgisiGirisDVO)
            {

#region takipBilgileriListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "takipBilgileriListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipBilgisiGirisDVO", (object)takipBilgisiGirisDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipBilgisiCevapDVO cevap = default(takipBilgisiCevapDVO);
                    cevap = (takipBilgisiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion takipBilgileriListesiSync_Body

            }

            public static TTMessage taniAraASync(Guid siteID, IWebMethodCallback callerObject, taniAraGirisWSDVO taniAraGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","taniAraASync_ServerSide", new Guid("ac55913c-ccbe-49e0-83aa-7f64ab4588fe"), callerObject, taniAraGiris);
            }

            private static taniAraCevapDVO taniAraASync_ServerSide(IWebMethodCallback callerObject, taniAraGirisWSDVO taniAraGiris)
            {

#region taniAraASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "taniAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("taniAraGiris", (object)taniAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    taniAraCevapDVO cevap = default(taniAraCevapDVO);
                    
                    try
                    {
                        cevap = (taniAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { taniAraGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { taniAraGiris }, null);

                    return cevap;
                

#endregion taniAraASync_Body

            }

            public static taniAraCevapDVO taniAraSync(Guid siteID, taniAraGirisWSDVO taniAraGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (taniAraCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("0ef97196-f8dd-4199-a89b-9a86b40c3ba8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","taniAraSync_ServerSide", taniAraGiris);
            }


            private static taniAraCevapDVO taniAraSync_ServerSide(taniAraGirisWSDVO taniAraGiris)
            {

#region taniAraSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "taniAra";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("taniAraGiris", (object)taniAraGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    taniAraCevapDVO cevap = default(taniAraCevapDVO);
                    cevap = (taniAraCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion taniAraSync_Body

            }

            public static TTMessage tesisYatakSorguASync(Guid siteID, IWebMethodCallback callerObject, tesisYatakSorguGirisDVO tesisYatakSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","tesisYatakSorguASync_ServerSide", new Guid("682140fe-3502-43ba-b43d-b66e2644033c"), callerObject, tesisYatakSorguGiris);
            }

            private static tesisYatakSorguCevapDVO tesisYatakSorguASync_ServerSide(IWebMethodCallback callerObject, tesisYatakSorguGirisDVO tesisYatakSorguGiris)
            {

#region tesisYatakSorguASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "tesisYatakSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tesisYatakSorguGiris", (object)tesisYatakSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    tesisYatakSorguCevapDVO cevap = default(tesisYatakSorguCevapDVO);
                    
                    try
                    {
                        cevap = (tesisYatakSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { tesisYatakSorguGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { tesisYatakSorguGiris }, null);

                    return cevap;
                

#endregion tesisYatakSorguASync_Body

            }

            public static tesisYatakSorguCevapDVO tesisYatakSorguSync(Guid siteID, tesisYatakSorguGirisDVO tesisYatakSorguGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (tesisYatakSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("9272279b-f882-4dd1-abc3-99e130365781"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","tesisYatakSorguSync_ServerSide", tesisYatakSorguGiris);
            }


            private static tesisYatakSorguCevapDVO tesisYatakSorguSync_ServerSide(tesisYatakSorguGirisDVO tesisYatakSorguGiris)
            {

#region tesisYatakSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "tesisYatakSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tesisYatakSorguGiris", (object)tesisYatakSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    tesisYatakSorguCevapDVO cevap = default(tesisYatakSorguCevapDVO);
                    cevap = (tesisYatakSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion tesisYatakSorguSync_Body

            }

            public static TTMessage yurtDisiYardimHakkiGetirASync(Guid siteID, IWebMethodCallback callerObject, yurtDisiYardimHakkiGetirGirisDVO yurtDisiYardimHakkiGetirGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","yurtDisiYardimHakkiGetirASync_ServerSide", new Guid("8a35bc1c-ff5d-41c5-ac0d-98e001bdc084"), callerObject, yurtDisiYardimHakkiGetirGiris);
            }

            private static yurtDisiYardimHakkiGetirCevapDVO yurtDisiYardimHakkiGetirASync_ServerSide(IWebMethodCallback callerObject, yurtDisiYardimHakkiGetirGirisDVO yurtDisiYardimHakkiGetirGiris)
            {

#region yurtDisiYardimHakkiGetirASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "yurtDisiYardimHakkiGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("yurtDisiYardimHakkiGetirGiris", (object)yurtDisiYardimHakkiGetirGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    yurtDisiYardimHakkiGetirCevapDVO cevap = default(yurtDisiYardimHakkiGetirCevapDVO);
                    
                    try
                    {
                        cevap = (yurtDisiYardimHakkiGetirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { yurtDisiYardimHakkiGetirGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { yurtDisiYardimHakkiGetirGiris }, null);

                    return cevap;
                

#endregion yurtDisiYardimHakkiGetirASync_Body

            }

            public static yurtDisiYardimHakkiGetirCevapDVO yurtDisiYardimHakkiGetirSync(Guid siteID, yurtDisiYardimHakkiGetirGirisDVO yurtDisiYardimHakkiGetirGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (yurtDisiYardimHakkiGetirCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("bce5bca4-63bf-43d7-b0c5-f99f25d4fd47"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MedulaYardimciIslemler+WebMethods, TTObjectClasses","yurtDisiYardimHakkiGetirSync_ServerSide", yurtDisiYardimHakkiGetirGiris);
            }


            private static yurtDisiYardimHakkiGetirCevapDVO yurtDisiYardimHakkiGetirSync_ServerSide(yurtDisiYardimHakkiGetirGirisDVO yurtDisiYardimHakkiGetirGiris)
            {

#region yurtDisiYardimHakkiGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MedulaYardimciIslemler";
                    header.ServiceId = "d3a45847-3891-42fc-af67-94b7e865bbe4";
                    header.MethodName = "yurtDisiYardimHakkiGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("yurtDisiYardimHakkiGetirGiris", (object)yurtDisiYardimHakkiGetirGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    yurtDisiYardimHakkiGetirCevapDVO cevap = default(yurtDisiYardimHakkiGetirCevapDVO);
                    cevap = (yurtDisiYardimHakkiGetirCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion yurtDisiYardimHakkiGetirSync_Body

            }

        }
                    
        protected MedulaYardimciIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaYardimciIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaYardimciIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaYardimciIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaYardimciIslemler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAYARDIMCIISLEMLER", dataRow) { }
        protected MedulaYardimciIslemler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAYARDIMCIISLEMLER", dataRow, isImported) { }
        public MedulaYardimciIslemler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaYardimciIslemler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaYardimciIslemler() : base() { }

    }
}