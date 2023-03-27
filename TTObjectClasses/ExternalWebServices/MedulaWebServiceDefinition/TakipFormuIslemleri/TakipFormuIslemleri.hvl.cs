
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipFormuIslemleri")] 

    public  abstract  partial class TakipFormuIslemleri : TTObject
    {
        public class TakipFormuIslemleriList : TTObjectCollection<TakipFormuIslemleri> { }
                    
        public class ChildTakipFormuIslemleriCollection : TTObject.TTChildObjectCollection<TakipFormuIslemleri>
        {
            public ChildTakipFormuIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipFormuIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static takipFormuKaydetCevapDVO takipFormuKaydet(Guid siteID, takipFormuKaydetGirisDVO takipFormuGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipFormuKaydetCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e4c2bca0-7424-44ee-afe5-eefe9130bccc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TakipFormuIslemleri+WebMethods, TTObjectClasses","takipFormuKaydet_ServerSide", takipFormuGiris);
            }


            private static takipFormuKaydetCevapDVO takipFormuKaydet_ServerSide(takipFormuKaydetGirisDVO takipFormuGiris)
            {

#region takipFormuKaydet_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TakipFormuIslemleri";
                    header.ServiceId = "2348fd4c-e18d-4df5-b774-863206761913";
                    header.MethodName = "takipFormuKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipFormuGiris", (object)takipFormuGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipFormuKaydetCevapDVO cevap = default(takipFormuKaydetCevapDVO);
                    cevap = (takipFormuKaydetCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion takipFormuKaydet_Body

            }

            public static takipFormuOkuCevapDVO takipFormuOku(Guid siteID, takipFormuOkuGirisDVO takipFormuOkuGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipFormuOkuCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("abd5c9a8-7e89-4936-bb00-c3931c00980f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TakipFormuIslemleri+WebMethods, TTObjectClasses","takipFormuOku_ServerSide", takipFormuOkuGiris);
            }


            private static takipFormuOkuCevapDVO takipFormuOku_ServerSide(takipFormuOkuGirisDVO takipFormuOkuGiris)
            {

#region takipFormuOku_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TakipFormuIslemleri";
                    header.ServiceId = "2348fd4c-e18d-4df5-b774-863206761913";
                    header.MethodName = "takipFormuOku";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipFormuOkuGiris", (object)takipFormuOkuGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipFormuOkuCevapDVO cevap = default(takipFormuOkuCevapDVO);
                    cevap = (takipFormuOkuCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion takipFormuOku_Body

            }

            public static takipFormuSilCevapDVO takipFormuSil(Guid siteID, takipFormuSilGirisDVO takipFormuSilGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (takipFormuSilCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e80afce1-29ce-42b6-8912-7eaaafe3cfda"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TakipFormuIslemleri+WebMethods, TTObjectClasses","takipFormuSil_ServerSide", takipFormuSilGiris);
            }


            private static takipFormuSilCevapDVO takipFormuSil_ServerSide(takipFormuSilGirisDVO takipFormuSilGiris)
            {

#region takipFormuSil_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TakipFormuIslemleri";
                    header.ServiceId = "2348fd4c-e18d-4df5-b774-863206761913";
                    header.MethodName = "takipFormuSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("takipFormuSilGiris", (object)takipFormuSilGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    takipFormuSilCevapDVO cevap = default(takipFormuSilCevapDVO);
                    cevap = (takipFormuSilCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion takipFormuSil_Body

            }

        }
                    
        protected TakipFormuIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipFormuIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipFormuIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipFormuIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipFormuIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPFORMUISLEMLERI", dataRow) { }
        protected TakipFormuIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPFORMUISLEMLERI", dataRow, isImported) { }
        public TakipFormuIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipFormuIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipFormuIslemleri() : base() { }

    }
}