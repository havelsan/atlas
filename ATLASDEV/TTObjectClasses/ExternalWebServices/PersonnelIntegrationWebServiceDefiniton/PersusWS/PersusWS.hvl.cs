
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PersusWS")] 

    /// <summary>
    /// Personnel Entegrasyonunda Sunulan WebServis Objesi
    /// </summary>
    public  partial class PersusWS : TTObject
    {
        public class PersusWSList : TTObjectCollection<PersusWS> { }
                    
        public class ChildPersusWSCollection : TTObject.TTChildObjectCollection<PersusWS>
        {
            public ChildPersusWSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPersusWSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static wsLoginResult loginSync(Guid siteID, string username, string password, string citizenid, wsRole[] roles)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (wsLoginResult) TTMessageFactory.SyncCall(siteID, new Guid("1b218810-a07a-4734-bc96-8ead26985c66"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.PersusWS+WebMethods, TTObjectClasses","loginSync_ServerSide", username, password, citizenid, roles);
            }


            private static wsLoginResult loginSync_ServerSide(string username, string password, string citizenid, wsRole[] roles)
            {

#region loginSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.PersusWS";
                    header.ServiceId = "0c482959-95e8-463c-b865-38bfc303c93b";
                    header.MethodName = "login";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("username", (object)username),
                        Tuple.Create("password", (object)password),
                        Tuple.Create("citizenid", (object)citizenid),
                        Tuple.Create("roles", (object)roles),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICISIFRESI","");

                    wsLoginResult cevap = default(wsLoginResult);
                    cevap = (wsLoginResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion loginSync_Body

            }

            public static wsIzinResult personLeavedSync(Guid siteID, string token, string citizenid, System.DateTime leaveday)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (wsIzinResult) TTMessageFactory.SyncCall(siteID, new Guid("fbdb7fd4-bace-494e-87bf-f80f13db27c9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.PersusWS+WebMethods, TTObjectClasses","personLeavedSync_ServerSide", token, citizenid, leaveday);
            }


            private static wsIzinResult personLeavedSync_ServerSide(string token, string citizenid, System.DateTime leaveday)
            {

#region personLeavedSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.PersusWS";
                    header.ServiceId = "0c482959-95e8-463c-b865-38bfc303c93b";
                    header.MethodName = "personLeaved";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("token", (object)token),
                        Tuple.Create("citizenid", (object)citizenid),
                        Tuple.Create("leaveday", (object)leaveday),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICISIFRESI","");

                    wsIzinResult cevap = default(wsIzinResult);
                    cevap = (wsIzinResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion personLeavedSync_Body

            }

            public static wsIzinResult personOutsideSync(Guid siteID, string token, string citizenid, System.DateTime leaveday)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (wsIzinResult) TTMessageFactory.SyncCall(siteID, new Guid("4839b868-5760-4278-a0e3-5696188e0d5e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.PersusWS+WebMethods, TTObjectClasses","personOutsideSync_ServerSide", token, citizenid, leaveday);
            }


            private static wsIzinResult personOutsideSync_ServerSide(string token, string citizenid, System.DateTime leaveday)
            {

#region personOutsideSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.PersusWS";
                    header.ServiceId = "0c482959-95e8-463c-b865-38bfc303c93b";
                    header.MethodName = "personOutside";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("token", (object)token),
                        Tuple.Create("citizenid", (object)citizenid),
                        Tuple.Create("leaveday", (object)leaveday),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICISIFRESI","");

                    wsIzinResult cevap = default(wsIzinResult);
                    cevap = (wsIzinResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion personOutsideSync_Body

            }

            public static wsPersonResult personSync(Guid siteID, string token, string citizenid)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (wsPersonResult) TTMessageFactory.SyncCall(siteID, new Guid("b30aa85b-5b7c-4c1e-9978-ae7450d4ca6b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.PersusWS+WebMethods, TTObjectClasses","personSync_ServerSide", token, citizenid);
            }


            private static wsPersonResult personSync_ServerSide(string token, string citizenid)
            {

#region personSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.PersusWS";
                    header.ServiceId = "0c482959-95e8-463c-b865-38bfc303c93b";
                    header.MethodName = "person";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("token", (object)token),
                        Tuple.Create("citizenid", (object)citizenid),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICISIFRESI","");

                    wsPersonResult cevap = default(wsPersonResult);
                    cevap = (wsPersonResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion personSync_Body

            }

            public static wsWorkPlanResult personWorkPlanSync(Guid siteID, string token, string citizenid, string type, System.DateTime startday, System.DateTime endday)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (wsWorkPlanResult) TTMessageFactory.SyncCall(siteID, new Guid("3ccaa6b6-564b-4f41-82f1-4fe4260e4834"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.PersusWS+WebMethods, TTObjectClasses","personWorkPlanSync_ServerSide", token, citizenid, type, startday, endday);
            }


            private static wsWorkPlanResult personWorkPlanSync_ServerSide(string token, string citizenid, string type, System.DateTime startday, System.DateTime endday)
            {

#region personWorkPlanSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.PersusWS";
                    header.ServiceId = "0c482959-95e8-463c-b865-38bfc303c93b";
                    header.MethodName = "personWorkPlan";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("token", (object)token),
                        Tuple.Create("citizenid", (object)citizenid),
                        Tuple.Create("type", (object)type),
                        Tuple.Create("startday", (object)startday),
                        Tuple.Create("endday", (object)endday),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICISIFRESI","");

                    wsWorkPlanResult cevap = default(wsWorkPlanResult);
                    cevap = (wsWorkPlanResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion personWorkPlanSync_Body

            }

            public static wsLoginResult windowopenSync(Guid siteID, string token, string windowid)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (wsLoginResult) TTMessageFactory.SyncCall(siteID, new Guid("a2495a7a-3694-4dc4-995f-b391227198ca"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.PersusWS+WebMethods, TTObjectClasses","windowopenSync_ServerSide", token, windowid);
            }


            private static wsLoginResult windowopenSync_ServerSide(string token, string windowid)
            {

#region windowopenSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.PersusWS";
                    header.ServiceId = "0c482959-95e8-463c-b865-38bfc303c93b";
                    header.MethodName = "windowopen";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("token", (object)token),
                        Tuple.Create("windowid", (object)windowid),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("PERSONELENTEGREKULLANICISIFRESI","");

                    wsLoginResult cevap = default(wsLoginResult);
                    cevap = (wsLoginResult)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion windowopenSync_Body

            }

        }
                    
        protected PersusWS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PersusWS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PersusWS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PersusWS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PersusWS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERSUSWS", dataRow) { }
        protected PersusWS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERSUSWS", dataRow, isImported) { }
        public PersusWS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PersusWS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PersusWS() : base() { }

    }
}