
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResUserTakeOffFromWork")] 

    public  partial class ResUserTakeOffFromWork : TTObject
    {
        public class ResUserTakeOffFromWorkList : TTObjectCollection<ResUserTakeOffFromWork> { }
                    
        public class ChildResUserTakeOffFromWorkCollection : TTObject.TTChildObjectCollection<ResUserTakeOffFromWork>
        {
            public ChildResUserTakeOffFromWorkCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResUserTakeOffFromWorkCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ResUserTakeOffFromWork> GetByIntegrationID(TTObjectContext objectContext, string IntegrationIDParam)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSERTAKEOFFFROMWORK"].QueryDefs["GetByIntegrationID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTEGRATIONIDPARAM", IntegrationIDParam);

            return ((ITTQuery)objectContext).QueryObjects<ResUserTakeOffFromWork>(queryDef, paramList);
        }

        public static BindingList<ResUserTakeOffFromWork> GetTakeOffByDateByTime(TTObjectContext objectContext, DateTime DATETIMEPARAM, string RESUSER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSERTAKEOFFFROMWORK"].QueryDefs["GetTakeOffByDateByTime"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATETIMEPARAM", DATETIMEPARAM);
            paramList.Add("RESUSER", RESUSER);

            return ((ITTQuery)objectContext).QueryObjects<ResUserTakeOffFromWork>(queryDef, paramList);
        }

        public static BindingList<ResUserTakeOffFromWork> GetTakeOffByDateByTime2(TTObjectContext objectContext, DateTime DATETIMEPARAM, Guid RESUSER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSERTAKEOFFFROMWORK"].QueryDefs["GetTakeOffByDateByTime2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATETIMEPARAM", DATETIMEPARAM);
            paramList.Add("RESUSER", RESUSER);

            return ((ITTQuery)objectContext).QueryObjects<ResUserTakeOffFromWork>(queryDef, paramList);
        }

        public string UniqueRefNo
        {
            get { return (string)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

        public string IntegrationId
        {
            get { return (string)this["INTEGRATIONID"]; }
            set { this["INTEGRATIONID"] = value; }
        }

        public string IntegrationVersion
        {
            get { return (string)this["INTEGRATIONVERSION"]; }
            set { this["INTEGRATIONVERSION"] = value; }
        }

        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

        public bool? ResUserTakeOffFromWorkType
        {
            get { return (bool?)this["RESUSERTAKEOFFFROMWORKTYPE"]; }
            set { this["RESUSERTAKEOFFFROMWORKTYPE"] = value; }
        }

        public bool? IsActive
        {
            get { return (bool?)this["ISACTIVE"]; }
            set { this["ISACTIVE"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TakeOffDatetime StartDate
        {
            get { return (TakeOffDatetime)((ITTObject)this).GetParent("STARTDATE"); }
            set { this["STARTDATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TakeOffDatetime EndDate
        {
            get { return (TakeOffDatetime)((ITTObject)this).GetParent("ENDDATE"); }
            set { this["ENDDATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MHRSActionTypeDefinition MHRSActionType
        {
            get { return (MHRSActionTypeDefinition)((ITTObject)this).GetParent("MHRSACTIONTYPE"); }
            set { this["MHRSACTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResUserTakeOffFromWork(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResUserTakeOffFromWork(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResUserTakeOffFromWork(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResUserTakeOffFromWork(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResUserTakeOffFromWork(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESUSERTAKEOFFFROMWORK", dataRow) { }
        protected ResUserTakeOffFromWork(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESUSERTAKEOFFFROMWORK", dataRow, isImported) { }
        public ResUserTakeOffFromWork(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResUserTakeOffFromWork(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResUserTakeOffFromWork() : base() { }

    }
}