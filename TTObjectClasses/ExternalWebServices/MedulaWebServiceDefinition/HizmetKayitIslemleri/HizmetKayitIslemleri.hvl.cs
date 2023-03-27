
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetKayitIslemleri")] 

    /// <summary>
    /// MEDULA Hizmet Kayıt İşlemleri
    /// </summary>
    public  abstract  partial class HizmetKayitIslemleri : TTObject
    {
        public class HizmetKayitIslemleriList : TTObjectCollection<HizmetKayitIslemleri> { }
                    
        public class ChildHizmetKayitIslemleriCollection : TTObject.TTChildObjectCollection<HizmetKayitIslemleri>
        {
            public ChildHizmetKayitIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetKayitIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static hizmetIptalCevapDVO hizmetIptalSync(Guid siteID, hizmetIptalGirisDVO hizmetIptalGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (hizmetIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("11dbf29b-b994-4dc3-b06f-630a86e5957e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HizmetKayitIslemleri+WebMethods, TTObjectClasses","hizmetIptalSync_ServerSide", hizmetIptalGiris);
            }


            private static hizmetIptalCevapDVO hizmetIptalSync_ServerSide(hizmetIptalGirisDVO hizmetIptalGiris)
            {

#region hizmetIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HizmetKayitIslemleri";
                    header.ServiceId = "9f87a702-17e9-4709-9d50-e6a5771ec87d";
                    header.MethodName = "hizmetIptal";
                    header.CallTimeout = 600;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hizmetIptalGiris", (object)hizmetIptalGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    hizmetIptalCevapDVO cevap = default(hizmetIptalCevapDVO);
                    cevap = (hizmetIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hizmetIptalSync_Body

            }

            public static TTMessage hizmetKayitASync(Guid siteID, Guid? procedureObjectID, IWebMethodCallback callerObject, hizmetKayitGirisDVO hizmetKayitGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.HighPriority ,"TTObjectClasses","TTObjectClasses.HizmetKayitIslemleri+WebMethods, TTObjectClasses","hizmetKayitASync_ServerSide", new Guid("694c01ac-b14b-4ec6-ad02-a3a6dcb1be50"), callerObject, hizmetKayitGiris);
            }

            private static hizmetKayitCevapDVO hizmetKayitASync_ServerSide(IWebMethodCallback callerObject, hizmetKayitGirisDVO hizmetKayitGiris)
            {

#region hizmetKayitASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HizmetKayitIslemleri";
                    header.ServiceId = "9f87a702-17e9-4709-9d50-e6a5771ec87d";
                    header.MethodName = "hizmetKayit";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hizmetKayitGiris", (object)hizmetKayitGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    hizmetKayitCevapDVO cevap = default(hizmetKayitCevapDVO);
                    
                    try
                    {
                        cevap = (hizmetKayitCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { hizmetKayitGiris }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { hizmetKayitGiris }, null);

                    return cevap;
                

#endregion hizmetKayitASync_Body

            }

            public static hizmetKayitCevapDVO hizmetKayitSync(Guid siteID, Guid? procedureObjectID, hizmetKayitGirisDVO hizmetKayitGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
return (hizmetKayitCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1c699c17-4d2f-4a00-bf60-54d9a1d2b2d4"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HizmetKayitIslemleri+WebMethods, TTObjectClasses","hizmetKayitSync_ServerSide", hizmetKayitGiris);
            }


            private static hizmetKayitCevapDVO hizmetKayitSync_ServerSide(hizmetKayitGirisDVO hizmetKayitGiris)
            {

#region hizmetKayitSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HizmetKayitIslemleri";
                    header.ServiceId = "9f87a702-17e9-4709-9d50-e6a5771ec87d";
                    header.MethodName = "hizmetKayit";
                    header.CallTimeout = 600;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hizmetKayitGiris", (object)hizmetKayitGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    hizmetKayitCevapDVO cevap = default(hizmetKayitCevapDVO);
                    cevap = (hizmetKayitCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hizmetKayitSync_Body

            }

            public static hizmetOkuCevapDVO hizmetOkuSync(Guid siteID, hizmetOkuGirisDVO hizmetOkuGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (hizmetOkuCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("66e1c4af-93fc-4349-80a4-29d4c60486c8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HizmetKayitIslemleri+WebMethods, TTObjectClasses","hizmetOkuSync_ServerSide", hizmetOkuGiris);
            }


            private static hizmetOkuCevapDVO hizmetOkuSync_ServerSide(hizmetOkuGirisDVO hizmetOkuGiris)
            {

#region hizmetOkuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HizmetKayitIslemleri";
                    header.ServiceId = "9f87a702-17e9-4709-9d50-e6a5771ec87d";
                    header.MethodName = "hizmetOku";
                    header.CallTimeout = 600;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("hizmetOkuGiris", (object)hizmetOkuGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    hizmetOkuCevapDVO cevap = default(hizmetOkuCevapDVO);
                    cevap = (hizmetOkuCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion hizmetOkuSync_Body

            }

            public static utsKesinlestirmeIptalCevapDVO utsKullanimKesinlestirmeIptalSync(Guid siteID, utsKesinlestirmeIptalGirisDVO utsKullanimKesinlestirmeIptalGiris)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (utsKesinlestirmeIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("272fe312-41bf-4369-9413-b6c8e2e19025"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HizmetKayitIslemleri+WebMethods, TTObjectClasses","utsKullanimKesinlestirmeIptalSync_ServerSide", utsKullanimKesinlestirmeIptalGiris);
            }


            private static utsKesinlestirmeIptalCevapDVO utsKullanimKesinlestirmeIptalSync_ServerSide(utsKesinlestirmeIptalGirisDVO utsKullanimKesinlestirmeIptalGiris)
            {

#region utsKullanimKesinlestirmeIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HizmetKayitIslemleri";
                    header.ServiceId = "9f87a702-17e9-4709-9d50-e6a5771ec87d";
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
return (utsKesinlestirmeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b16c1b28-fd60-4ed3-b248-ebc17e78fce0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HizmetKayitIslemleri+WebMethods, TTObjectClasses","utsKullanimKesinlestirmeSorguSync_ServerSide", utsKullanimKesinlestirmeSorguGiris);
            }


            private static utsKesinlestirmeSorguCevapDVO utsKullanimKesinlestirmeSorguSync_ServerSide(utsKesinlestirmeSorguGirisDVO utsKullanimKesinlestirmeSorguGiris)
            {

#region utsKullanimKesinlestirmeSorguSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HizmetKayitIslemleri";
                    header.ServiceId = "9f87a702-17e9-4709-9d50-e6a5771ec87d";
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
return (utsKesinlestirmeKayitCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("67010cbb-c65b-4029-af8e-47e8e922470c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.HizmetKayitIslemleri+WebMethods, TTObjectClasses","utsKullanimKesinlestirmeSync_ServerSide", utsKullanimKesinlestirmeGiris);
            }


            private static utsKesinlestirmeKayitCevapDVO utsKullanimKesinlestirmeSync_ServerSide(utsKesinlestirmeKayitGirisDVO utsKullanimKesinlestirmeGiris)
            {

#region utsKullanimKesinlestirmeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.HizmetKayitIslemleri";
                    header.ServiceId = "9f87a702-17e9-4709-9d50-e6a5771ec87d";
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
                    
        protected HizmetKayitIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetKayitIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetKayitIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetKayitIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetKayitIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETKAYITISLEMLERI", dataRow) { }
        protected HizmetKayitIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETKAYITISLEMLERI", dataRow, isImported) { }
        public HizmetKayitIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetKayitIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetKayitIslemleri() : base() { }

    }
}