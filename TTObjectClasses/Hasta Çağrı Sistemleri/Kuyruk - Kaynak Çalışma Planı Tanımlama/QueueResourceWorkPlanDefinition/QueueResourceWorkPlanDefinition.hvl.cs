
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QueueResourceWorkPlanDefinition")] 

    public  partial class QueueResourceWorkPlanDefinition : TTDefinitionSet
    {
        public class QueueResourceWorkPlanDefinitionList : TTObjectCollection<QueueResourceWorkPlanDefinition> { }
                    
        public class ChildQueueResourceWorkPlanDefinitionCollection : TTObject.TTChildObjectCollection<QueueResourceWorkPlanDefinition>
        {
            public ChildQueueResourceWorkPlanDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQueueResourceWorkPlanDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class QueueResourceWorkPlanDefNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? LastCallTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCALLTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].AllPropertyDefs["LASTCALLTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].AllPropertyDefs["WORKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Resourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Queuename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUEUENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Workdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].AllPropertyDefs["WORKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Boolean? Isactive1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE1"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public string Notification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LCDNOTIFICATIONDEFINITION"].AllPropertyDefs["NOTIFICATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public QueueResourceWorkPlanDefNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public QueueResourceWorkPlanDefNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected QueueResourceWorkPlanDefNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaxWorkdateForQueue_Class : TTReportNqlObject 
        {
            public Object Maxworkdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAXWORKDATE"]);
                }
            }

            public GetMaxWorkdateForQueue_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaxWorkdateForQueue_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaxWorkdateForQueue_Class() : base() { }
        }

        public static BindingList<QueueResourceWorkPlanDefinition.QueueResourceWorkPlanDefNQL_Class> QueueResourceWorkPlanDefNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].QueryDefs["QueueResourceWorkPlanDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QueueResourceWorkPlanDefinition.QueueResourceWorkPlanDefNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<QueueResourceWorkPlanDefinition.QueueResourceWorkPlanDefNQL_Class> QueueResourceWorkPlanDefNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].QueryDefs["QueueResourceWorkPlanDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QueueResourceWorkPlanDefinition.QueueResourceWorkPlanDefNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class> GetMaxWorkdateForQueue(Guid QUEUE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].QueryDefs["GetMaxWorkdateForQueue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUE", QUEUE);

            return TTReportNqlObject.QueryObjects<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class>(queryDef, paramList, pi);
        }

        public static BindingList<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class> GetMaxWorkdateForQueue(TTObjectContext objectContext, Guid QUEUE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].QueryDefs["GetMaxWorkdateForQueue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUE", QUEUE);

            return TTReportNqlObject.QueryObjects<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<QueueResourceWorkPlanDefinition> GetAllQueuesOfResource(TTObjectContext objectContext, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].QueryDefs["GetAllQueuesOfResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<QueueResourceWorkPlanDefinition>(queryDef, paramList);
        }

        public static BindingList<QueueResourceWorkPlanDefinition> GetTodaysQueueOfResource(TTObjectContext objectContext, DateTime RECTIME, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].QueryDefs["GetTodaysQueueOfResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RECTIME", RECTIME);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<QueueResourceWorkPlanDefinition>(queryDef, paramList);
        }

        public static BindingList<QueueResourceWorkPlanDefinition> GetTodaysPlanByQueueByResource(TTObjectContext objectContext, DateTime RECTIME, Guid RESOURCE, Guid QUEUE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUERESOURCEWORKPLANDEFINITION"].QueryDefs["GetTodaysPlanByQueueByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RECTIME", RECTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("QUEUE", QUEUE);

            return ((ITTQuery)objectContext).QueryObjects<QueueResourceWorkPlanDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// En son hasta çağırma zamanı
    /// </summary>
        public DateTime? LastCallTime
        {
            get { return (DateTime?)this["LASTCALLTIME"]; }
            set { this["LASTCALLTIME"] = value; }
        }

        public DateTime? WorkDate
        {
            get { return (DateTime?)this["WORKDATE"]; }
            set { this["WORKDATE"] = value; }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExaminationQueueDefinition Queue
        {
            get { return (ExaminationQueueDefinition)((ITTObject)this).GetParent("QUEUE"); }
            set { this["QUEUE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// LCD Bilgilendirme Mesajı
    /// </summary>
        public LCDNotificationDefinition LCDNotification
        {
            get { return (LCDNotificationDefinition)((ITTObject)this).GetParent("LCDNOTIFICATION"); }
            set { this["LCDNOTIFICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected QueueResourceWorkPlanDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QueueResourceWorkPlanDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QueueResourceWorkPlanDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QueueResourceWorkPlanDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QueueResourceWorkPlanDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QUEUERESOURCEWORKPLANDEFINITION", dataRow) { }
        protected QueueResourceWorkPlanDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QUEUERESOURCEWORKPLANDEFINITION", dataRow, isImported) { }
        public QueueResourceWorkPlanDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QueueResourceWorkPlanDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QueueResourceWorkPlanDefinition() : base() { }

    }
}