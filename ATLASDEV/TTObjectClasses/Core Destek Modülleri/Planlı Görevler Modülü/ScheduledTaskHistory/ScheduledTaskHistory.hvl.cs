
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ScheduledTaskHistory")] 

    /// <summary>
    /// Planlı Görev Geçmişi
    /// </summary>
    public  partial class ScheduledTaskHistory : TTObject
    {
        public class ScheduledTaskHistoryList : TTObjectCollection<ScheduledTaskHistory> { }
                    
        public class ChildScheduledTaskHistoryCollection : TTObject.TTChildObjectCollection<ScheduledTaskHistory>
        {
            public ChildScheduledTaskHistoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildScheduledTaskHistoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ScheduledTaskHistory> GetScheduledTaskHistories(TTObjectContext objectContext, Guid SCHEDULEDTASK, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULEDTASKHISTORY"].QueryDefs["GetScheduledTaskHistories"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SCHEDULEDTASK", SCHEDULEDTASK);

            return ((ITTQuery)objectContext).QueryObjects<ScheduledTaskHistory>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Log
        {
            get { return (string)this["LOG"]; }
            set { this["LOG"] = value; }
        }

    /// <summary>
    /// Log Tarihi
    /// </summary>
        public DateTime? LogDate
        {
            get { return (DateTime?)this["LOGDATE"]; }
            set { this["LOGDATE"] = value; }
        }

        public BaseScheduledTask BaseScheduledTask
        {
            get { return (BaseScheduledTask)((ITTObject)this).GetParent("BASESCHEDULEDTASK"); }
            set { this["BASESCHEDULEDTASK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ScheduledTaskHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ScheduledTaskHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ScheduledTaskHistory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ScheduledTaskHistory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ScheduledTaskHistory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SCHEDULEDTASKHISTORY", dataRow) { }
        protected ScheduledTaskHistory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SCHEDULEDTASKHISTORY", dataRow, isImported) { }
        public ScheduledTaskHistory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ScheduledTaskHistory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ScheduledTaskHistory() : base() { }

    }
}