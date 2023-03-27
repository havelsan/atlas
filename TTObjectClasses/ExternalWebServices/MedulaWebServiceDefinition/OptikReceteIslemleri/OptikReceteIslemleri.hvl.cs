
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OptikReceteIslemleri")] 

    public  partial class OptikReceteIslemleri : TTObject
    {
        public class OptikReceteIslemleriList : TTObjectCollection<OptikReceteIslemleri> { }
                    
        public class ChildOptikReceteIslemleriCollection : TTObject.TTChildObjectCollection<OptikReceteIslemleri>
        {
            public ChildOptikReceteIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOptikReceteIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            /// <summary>
            /// Optik E-Reçete Kaydetme
            /// </summary>
            public static sonucDVO ereceteKaydet(Guid siteID, string userName, string password, receteTesisDVO receteTesis)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sonucDVO) TTMessageFactory.SyncCall(siteID, new Guid("ad54419f-1a9e-4081-b209-b48774f6c01a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikReceteIslemleri+WebMethods, TTObjectClasses","ereceteKaydet_ServerSide", userName, password, receteTesis);
            }


            private static sonucDVO ereceteKaydet_ServerSide(string userName, string password, receteTesisDVO receteTesis)
            {

#region ereceteKaydet_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikReceteIslemleri";
                    header.ServiceId = "56fd1041-cec6-40cb-989d-9b1fbaaf652e";
                    header.MethodName = "ereceteKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("receteTesis", (object)receteTesis),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    sonucDVO cevap = default(sonucDVO);
                    cevap = (sonucDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteKaydet_Body

            }

            /// <summary>
            /// Optik E-Reçete Liste Sorgulama
            /// </summary>
            public static ereceteListeSorguCevapDVO ereceteListeSorgu(Guid siteID, string userName, string password, ereceteListeSorguIstekDVO ereceteListeSorguIstek)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (ereceteListeSorguCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e8a616bb-5210-4b0b-a1d7-cfaba23589b7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikReceteIslemleri+WebMethods, TTObjectClasses","ereceteListeSorgu_ServerSide", userName, password, ereceteListeSorguIstek);
            }


            private static ereceteListeSorguCevapDVO ereceteListeSorgu_ServerSide(string userName, string password, ereceteListeSorguIstekDVO ereceteListeSorguIstek)
            {

#region ereceteListeSorgu_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikReceteIslemleri";
                    header.ServiceId = "56fd1041-cec6-40cb-989d-9b1fbaaf652e";
                    header.MethodName = "ereceteListeSorgu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteListeSorguIstek", (object)ereceteListeSorguIstek),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    ereceteListeSorguCevapDVO cevap = default(ereceteListeSorguCevapDVO);
                    cevap = (ereceteListeSorguCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteListeSorgu_Body

            }

            /// <summary>
            /// Optik E-Reçete Silme
            /// </summary>
            public static sonucDVO ereceteSil(Guid siteID, string userName, string password, ereceteSilDVO ereceteSil)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (sonucDVO) TTMessageFactory.SyncCall(siteID, new Guid("c12dee58-ac3a-483f-8279-1ab91c1f0cfc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.OptikReceteIslemleri+WebMethods, TTObjectClasses","ereceteSil_ServerSide", userName, password, ereceteSil);
            }


            private static sonucDVO ereceteSil_ServerSide(string userName, string password, ereceteSilDVO ereceteSil)
            {

#region ereceteSil_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.OptikReceteIslemleri";
                    header.ServiceId = "56fd1041-cec6-40cb-989d-9b1fbaaf652e";
                    header.MethodName = "ereceteSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("ereceteSil", (object)ereceteSil),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = userName;
                    credential.Password = password;

                    sonucDVO cevap = default(sonucDVO);
                    cevap = (sonucDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ereceteSil_Body

            }

        }
                    
        protected OptikReceteIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OptikReceteIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OptikReceteIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OptikReceteIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OptikReceteIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OPTIKRECETEISLEMLERI", dataRow) { }
        protected OptikReceteIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OPTIKRECETEISLEMLERI", dataRow, isImported) { }
        public OptikReceteIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OptikReceteIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OptikReceteIslemleri() : base() { }

    }
}