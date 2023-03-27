
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtodontiIslemleri")] 

    public  partial class OrtodontiIslemleri : TTObject
    {
        public class OrtodontiIslemleriList : TTObjectCollection<OrtodontiIslemleri> { }
                    
        public class ChildOrtodontiIslemleriCollection : TTObject.TTChildObjectCollection<OrtodontiIslemleri>
        {
            public ChildOrtodontiIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtodontiIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static ortodontiFormuIptalCevapDVO ortodontiFormuIptalSync(Guid siteID, ortodontiFormuIptalGirisDVO ortodontiFormuIptalGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ortodontiFormuIptalCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("20920440-6cff-46e9-85d8-b5cdc042ae82"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OrtodontiIslemleri+WebMethods, TTObjectClasses","ortodontiFormuIptalSync_ServerSide", ortodontiFormuIptalGiris);
            }


            private static ortodontiFormuIptalCevapDVO ortodontiFormuIptalSync_ServerSide(ortodontiFormuIptalGirisDVO ortodontiFormuIptalGiris)
            {

#region ortodontiFormuIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OrtodontiIslemleri";
                    header.ServiceId = "63161e66-93b6-4348-895e-08893b4319c4";
                    header.MethodName = "ortodontiFormuIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ortodontiFormuIptalGiris", (object)ortodontiFormuIptalGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    ortodontiFormuIptalCevapDVO cevap = default(ortodontiFormuIptalCevapDVO);
                    cevap = (ortodontiFormuIptalCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ortodontiFormuIptalSync_Body

            }

            public static ortodontiFormuKaydetCevapDVO ortodontiFormuKaydetSync(Guid siteID, ortodontiFormuKaydetGirisDVO ortodontiFormuKaydetGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ortodontiFormuKaydetCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("249620fd-a3cf-4a21-875b-edda90dd534c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OrtodontiIslemleri+WebMethods, TTObjectClasses","ortodontiFormuKaydetSync_ServerSide", ortodontiFormuKaydetGiris);
            }


            private static ortodontiFormuKaydetCevapDVO ortodontiFormuKaydetSync_ServerSide(ortodontiFormuKaydetGirisDVO ortodontiFormuKaydetGiris)
            {

#region ortodontiFormuKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OrtodontiIslemleri";
                    header.ServiceId = "63161e66-93b6-4348-895e-08893b4319c4";
                    header.MethodName = "ortodontiFormuKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ortodontiFormuKaydetGiris", (object)ortodontiFormuKaydetGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    ortodontiFormuKaydetCevapDVO cevap = default(ortodontiFormuKaydetCevapDVO);
                    cevap = (ortodontiFormuKaydetCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ortodontiFormuKaydetSync_Body

            }

            public static ortodontiFormuOkuCevapDVO ortodontiFormuOkuSync(Guid siteID, ortodontiFormuOkuGirisDVO ortodontiFormuOkuGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ortodontiFormuOkuCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("98614520-d59f-4f00-87fe-aceebfd97f54"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OrtodontiIslemleri+WebMethods, TTObjectClasses","ortodontiFormuOkuSync_ServerSide", ortodontiFormuOkuGiris);
            }


            private static ortodontiFormuOkuCevapDVO ortodontiFormuOkuSync_ServerSide(ortodontiFormuOkuGirisDVO ortodontiFormuOkuGiris)
            {

#region ortodontiFormuOkuSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OrtodontiIslemleri";
                    header.ServiceId = "63161e66-93b6-4348-895e-08893b4319c4";
                    header.MethodName = "ortodontiFormuOku";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ortodontiFormuOkuGiris", (object)ortodontiFormuOkuGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    ortodontiFormuOkuCevapDVO cevap = default(ortodontiFormuOkuCevapDVO);
                    cevap = (ortodontiFormuOkuCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ortodontiFormuOkuSync_Body

            }

        }
                    
        protected OrtodontiIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtodontiIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtodontiIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtodontiIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtodontiIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTODONTIISLEMLERI", dataRow) { }
        protected OrtodontiIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTODONTIISLEMLERI", dataRow, isImported) { }
        public OrtodontiIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtodontiIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtodontiIslemleri() : base() { }

    }
}