
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaKayitIslemleri")] 

    public  abstract  partial class FaturaKayitIslemleri : TTObject
    {
        public class FaturaKayitIslemleriList : TTObjectCollection<FaturaKayitIslemleri> { }
                    
        public class ChildFaturaKayitIslemleriCollection : TTObject.TTChildObjectCollection<FaturaKayitIslemleri>
        {
            public ChildFaturaKayitIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaKayitIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static faturaIptalCevapDVO faturaIptalSync(Guid siteID, faturaIptalGirisDVO faturaIptalGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (faturaIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2987e5bd-4a7f-49db-b47b-832507532bc6"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","faturaIptalSync_ServerSide", faturaIptalGiris);
            }


            private static faturaIptalCevapDVO faturaIptalSync_ServerSide(faturaIptalGirisDVO faturaIptalGiris)
            {

#region faturaIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "faturaIptal";
                    header.CallTimeout = 600;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("faturaIptalGiris", (object)faturaIptalGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    faturaIptalCevapDVO cevap = default(faturaIptalCevapDVO);
                    cevap = (faturaIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion faturaIptalSync_Body

            }

            public static TTMessage faturaKayitASync(Guid siteID, IWebMethodCallback callerObject, faturaGirisDVO faturaGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","faturaKayitASync_ServerSide", new Guid("a60b2e6c-f62f-459f-b7f1-6c6de96c8948"), callerObject, faturaGiris);
            }

            private static faturaCevapDVO faturaKayitASync_ServerSide(IWebMethodCallback callerObject, faturaGirisDVO faturaGiris)
            {

#region faturaKayitASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "faturaKayit";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("faturaGiris", (object)faturaGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    faturaCevapDVO cevap = default(faturaCevapDVO);
                    
                    try
                    {
                        cevap = (faturaCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { faturaGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { faturaGiris }, null);

                    return cevap;
                

#endregion faturaKayitASync_Body

            }

            public static faturaCevapDVO faturaKayitSync(Guid siteID, faturaGirisDVO faturaGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (faturaCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("8b6cd427-8c3a-4748-81d8-b34f2f9843d8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","faturaKayitSync_ServerSide", faturaGiris);
            }


            private static faturaCevapDVO faturaKayitSync_ServerSide(faturaGirisDVO faturaGiris)
            {

#region faturaKayitSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "faturaKayit";
                    header.CallTimeout = 600;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("faturaGiris", (object)faturaGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    faturaCevapDVO cevap = default(faturaCevapDVO);
                    cevap = (faturaCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion faturaKayitSync_Body

            }

            public static faturaOkuCevapDVO faturaOkuSync(Guid siteID, faturaOkuGirisDVO faturaOkuGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (faturaOkuCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("ed0d8200-3335-4263-b6d4-839e2906ddf4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","faturaOkuSync_ServerSide", faturaOkuGiris);
            }


            private static faturaOkuCevapDVO faturaOkuSync_ServerSide(faturaOkuGirisDVO faturaOkuGiris)
            {

#region faturaOkuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "faturaOku";
                    header.CallTimeout = 600;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("faturaOkuGiris", (object)faturaOkuGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    faturaOkuCevapDVO cevap = default(faturaOkuCevapDVO);
                    cevap = (faturaOkuCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion faturaOkuSync_Body

            }

            public static faturaCevapDVO faturaTutarOkuSync(Guid siteID, faturaGirisDVO faturaOkuGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (faturaCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("4dbeb735-656c-413f-aff4-3ff920dda242"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","faturaTutarOkuSync_ServerSide", faturaOkuGiris);
            }


            private static faturaCevapDVO faturaTutarOkuSync_ServerSide(faturaGirisDVO faturaOkuGiris)
            {

#region faturaTutarOkuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "faturaTutarOku";
                    header.CallTimeout = 600;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("faturaOkuGiris", (object)faturaOkuGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    faturaCevapDVO cevap = default(faturaCevapDVO);
                    cevap = (faturaCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion faturaTutarOkuSync_Body

            }

            public static itsIslemCevapDVO itsIlacIslemSync(Guid siteID, itsIslemGirisDVO itsIlacIslemGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (itsIslemCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d20cf6a2-0fe9-42c5-807b-48364e82ebb2"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","itsIlacIslemSync_ServerSide", itsIlacIslemGiris);
            }


            private static itsIslemCevapDVO itsIlacIslemSync_ServerSide(itsIslemGirisDVO itsIlacIslemGiris)
            {

#region itsIlacIslemSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "itsIlacIslem";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("itsIlacIslemGiris", (object)itsIlacIslemGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    itsIslemCevapDVO cevap = default(itsIslemCevapDVO);
                    cevap = (itsIslemCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion itsIlacIslemSync_Body

            }

            public static utsKesinlestirmeIptalCevapDVO utsKullanimKesinlestirmeIptalSync(Guid siteID, utsKesinlestirmeIptalGirisDVO utsKullanimKesinlestirmeIptalGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (utsKesinlestirmeIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2f024e58-ae9b-4c60-b397-c3ce6f39d47c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","utsKullanimKesinlestirmeIptalSync_ServerSide", utsKullanimKesinlestirmeIptalGiris);
            }


            private static utsKesinlestirmeIptalCevapDVO utsKullanimKesinlestirmeIptalSync_ServerSide(utsKesinlestirmeIptalGirisDVO utsKullanimKesinlestirmeIptalGiris)
            {

#region utsKullanimKesinlestirmeIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "utsKullanimKesinlestirmeIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("utsKullanimKesinlestirmeIptalGiris", (object)utsKullanimKesinlestirmeIptalGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    utsKesinlestirmeIptalCevapDVO cevap = default(utsKesinlestirmeIptalCevapDVO);
                    cevap = (utsKesinlestirmeIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion utsKullanimKesinlestirmeIptalSync_Body

            }

            public static utsKesinlestirmeSorguCevapDVO utsKullanimKesinlestirmeSorguSync(Guid siteID, utsKesinlestirmeSorguGirisDVO utsKullanimKesinlestirmeSorguGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (utsKesinlestirmeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f442b000-4e2d-45c2-bae7-f6bbb515d4b8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","utsKullanimKesinlestirmeSorguSync_ServerSide", utsKullanimKesinlestirmeSorguGiris);
            }


            private static utsKesinlestirmeSorguCevapDVO utsKullanimKesinlestirmeSorguSync_ServerSide(utsKesinlestirmeSorguGirisDVO utsKullanimKesinlestirmeSorguGiris)
            {

#region utsKullanimKesinlestirmeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "utsKullanimKesinlestirmeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("utsKullanimKesinlestirmeSorguGiris", (object)utsKullanimKesinlestirmeSorguGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    utsKesinlestirmeSorguCevapDVO cevap = default(utsKesinlestirmeSorguCevapDVO);
                    cevap = (utsKesinlestirmeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion utsKullanimKesinlestirmeSorguSync_Body

            }

            public static utsKesinlestirmeKayitCevapDVO utsKullanimKesinlestirmeSync(Guid siteID, utsKesinlestirmeKayitGirisDVO utsKullanimKesinlestirmeGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (utsKesinlestirmeKayitCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("f7e2d4d1-0efe-4c8d-9d00-54afcea74318"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.FaturaKayitIslemleri+WebMethods, TTObjectClasses","utsKullanimKesinlestirmeSync_ServerSide", utsKullanimKesinlestirmeGiris);
            }


            private static utsKesinlestirmeKayitCevapDVO utsKullanimKesinlestirmeSync_ServerSide(utsKesinlestirmeKayitGirisDVO utsKullanimKesinlestirmeGiris)
            {

#region utsKullanimKesinlestirmeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.FaturaKayitIslemleri";
                    header.ServiceId = "2bdf3e11-2d93-4143-bb5a-ae76da71627a";
                    header.MethodName = "utsKullanimKesinlestirme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("utsKullanimKesinlestirmeGiris", (object)utsKullanimKesinlestirmeGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    utsKesinlestirmeKayitCevapDVO cevap = default(utsKesinlestirmeKayitCevapDVO);
                    cevap = (utsKesinlestirmeKayitCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion utsKullanimKesinlestirmeSync_Body

            }

        }
                    
        protected FaturaKayitIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaKayitIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaKayitIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaKayitIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaKayitIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAKAYITISLEMLERI", dataRow) { }
        protected FaturaKayitIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAKAYITISLEMLERI", dataRow, isImported) { }
        public FaturaKayitIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaKayitIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaKayitIslemleri() : base() { }

    }
}