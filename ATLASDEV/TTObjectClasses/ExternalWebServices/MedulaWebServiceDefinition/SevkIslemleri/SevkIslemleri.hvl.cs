
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkIslemleri")] 

    /// <summary>
    /// E- Sevk İşlemleri
    /// </summary>
    public  abstract  partial class SevkIslemleri : TTObject
    {
        public class SevkIslemleriList : TTObjectCollection<SevkIslemleri> { }
                    
        public class ChildSevkIslemleriCollection : TTObject.TTChildObjectCollection<SevkIslemleri>
        {
            public ChildSevkIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static mutatDisiRaporCevapDVO mutatDisiAracRaporKaydetSync(Guid siteID, mutatDisiRaporDVO mutatDisiRaporDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (mutatDisiRaporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("0ed0db68-0afd-4f8a-b7f6-286b6d2e8b54"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SevkIslemleri+WebMethods, TTObjectClasses","mutatDisiAracRaporKaydetSync_ServerSide", mutatDisiRaporDVO);
            }


            private static mutatDisiRaporCevapDVO mutatDisiAracRaporKaydetSync_ServerSide(mutatDisiRaporDVO mutatDisiRaporDVO)
            {

#region mutatDisiAracRaporKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SevkIslemleri";
                    header.ServiceId = "7ff06b16-6d72-4bd8-b61b-ab4cbb149da6";
                    header.MethodName = "mutatDisiAracRaporKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("mutatDisiRaporDVO", (object)mutatDisiRaporDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    mutatDisiRaporCevapDVO cevap = default(mutatDisiRaporCevapDVO);
                    cevap = (mutatDisiRaporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion mutatDisiAracRaporKaydetSync_Body

            }

            public static mutatDisiIptalCevapDVO mutatDisiAracRaporSilSync(Guid siteID, mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (mutatDisiIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("33bb4969-2ba9-44b9-aa57-2e954ae6ee9f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SevkIslemleri+WebMethods, TTObjectClasses","mutatDisiAracRaporSilSync_ServerSide", mutatDisiRaporIptalDVO);
            }


            private static mutatDisiIptalCevapDVO mutatDisiAracRaporSilSync_ServerSide(mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO)
            {

#region mutatDisiAracRaporSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SevkIslemleri";
                    header.ServiceId = "7ff06b16-6d72-4bd8-b61b-ab4cbb149da6";
                    header.MethodName = "mutatDisiAracRaporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("mutatDisiRaporIptalDVO", (object)mutatDisiRaporIptalDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    mutatDisiIptalCevapDVO cevap = default(mutatDisiIptalCevapDVO);
                    cevap = (mutatDisiIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion mutatDisiAracRaporSilSync_Body

            }

            public static sevkIptalCevapDVO sevkBildirimIptalSync(Guid siteID, sevkBildirimIptalDVO sevkBildirimIptalDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sevkIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("04cb753e-fe9d-4c75-97e8-d32ec779d55c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SevkIslemleri+WebMethods, TTObjectClasses","sevkBildirimIptalSync_ServerSide", sevkBildirimIptalDVO);
            }


            private static sevkIptalCevapDVO sevkBildirimIptalSync_ServerSide(sevkBildirimIptalDVO sevkBildirimIptalDVO)
            {

#region sevkBildirimIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SevkIslemleri";
                    header.ServiceId = "7ff06b16-6d72-4bd8-b61b-ab4cbb149da6";
                    header.MethodName = "sevkBildirimIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sevkBildirimIptalDVO", (object)sevkBildirimIptalDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    sevkIptalCevapDVO cevap = default(sevkIptalCevapDVO);
                    cevap = (sevkIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sevkBildirimIptalSync_Body

            }

            public static sevkCevapDVO sevkBildirSync(Guid siteID, sevkBildirimDVO sevkBildirimDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sevkCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b227195d-88b1-4da6-92da-3d734a00b835"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SevkIslemleri+WebMethods, TTObjectClasses","sevkBildirSync_ServerSide", sevkBildirimDVO);
            }


            private static sevkCevapDVO sevkBildirSync_ServerSide(sevkBildirimDVO sevkBildirimDVO)
            {

#region sevkBildirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SevkIslemleri";
                    header.ServiceId = "7ff06b16-6d72-4bd8-b61b-ab4cbb149da6";
                    header.MethodName = "sevkBildirim";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sevkBildirimDVO", (object)sevkBildirimDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    sevkCevapDVO cevap = default(sevkCevapDVO);
                    cevap = (sevkCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sevkBildirSync_Body

            }

            public static sevkIptalCevapDVO sevkKayitIptalSync(Guid siteID, sevkKayitIptalDVO sevkKayitIptalDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sevkIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("1487773f-3163-4db4-96f6-1a622e282d22"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SevkIslemleri+WebMethods, TTObjectClasses","sevkKayitIptalSync_ServerSide", sevkKayitIptalDVO);
            }


            private static sevkIptalCevapDVO sevkKayitIptalSync_ServerSide(sevkKayitIptalDVO sevkKayitIptalDVO)
            {

#region sevkKayitIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SevkIslemleri";
                    header.ServiceId = "7ff06b16-6d72-4bd8-b61b-ab4cbb149da6";
                    header.MethodName = "sevkKayitIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sevkKayitIptalDVO", (object)sevkKayitIptalDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    sevkIptalCevapDVO cevap = default(sevkIptalCevapDVO);
                    cevap = (sevkIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sevkKayitIptalSync_Body

            }

            public static sevkCevapDVO sevkKayitSync(Guid siteID, sevkKayitDVO sevkKayitDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sevkCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("030e0439-e597-49f4-9e42-f123cf1df37a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SevkIslemleri+WebMethods, TTObjectClasses","sevkKayitSync_ServerSide", sevkKayitDVO);
            }


            private static sevkCevapDVO sevkKayitSync_ServerSide(sevkKayitDVO sevkKayitDVO)
            {

#region sevkKayitSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SevkIslemleri";
                    header.ServiceId = "7ff06b16-6d72-4bd8-b61b-ab4cbb149da6";
                    header.MethodName = "sevkKayit";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sevkKayitDVO", (object)sevkKayitDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    sevkCevapDVO cevap = default(sevkCevapDVO);
                    cevap = (sevkCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sevkKayitSync_Body

            }

            public static sevkListeCevapDVO sevkListeleSync(Guid siteID, sevkListeDVO sevkListeDVO)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sevkListeCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("aa3db111-879e-441d-9f06-3435363be998"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.SevkIslemleri+WebMethods, TTObjectClasses","sevkListeleSync_ServerSide", sevkListeDVO);
            }


            private static sevkListeCevapDVO sevkListeleSync_ServerSide(sevkListeDVO sevkListeDVO)
            {

#region sevkListeleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.SevkIslemleri";
                    header.ServiceId = "7ff06b16-6d72-4bd8-b61b-ab4cbb149da6";
                    header.MethodName = "sevkListele";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("sevkListeDVO", (object)sevkListeDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    sevkListeCevapDVO cevap = default(sevkListeCevapDVO);
                    cevap = (sevkListeCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sevkListeleSync_Body

            }

        }
                    
        protected SevkIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKISLEMLERI", dataRow) { }
        protected SevkIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKISLEMLERI", dataRow, isImported) { }
        public SevkIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkIslemleri() : base() { }

    }
}