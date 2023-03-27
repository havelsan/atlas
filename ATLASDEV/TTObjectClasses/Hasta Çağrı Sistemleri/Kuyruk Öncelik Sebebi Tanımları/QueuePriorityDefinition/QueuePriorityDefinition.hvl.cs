
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QueuePriorityDefinition")] 

    /// <summary>
    /// Kuyruk Öncelik Sebebi Tanımlar
    /// </summary>
    public  partial class QueuePriorityDefinition : TTDefinitionSet
    {
        public class QueuePriorityDefinitionList : TTObjectCollection<QueuePriorityDefinition> { }
                    
        public class ChildQueuePriorityDefinitionCollection : TTObject.TTChildObjectCollection<QueuePriorityDefinition>
        {
            public ChildQueuePriorityDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQueuePriorityDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetQueuePriorityDefNQL_Class : TTReportNqlObject 
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

            public string PriorityName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUEUEPRIORITYDEFINITION"].AllPropertyDefs["PRIORITYNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetQueuePriorityDefNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetQueuePriorityDefNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetQueuePriorityDefNQL_Class() : base() { }
        }

        public static BindingList<QueuePriorityDefinition.GetQueuePriorityDefNQL_Class> GetQueuePriorityDefNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUEPRIORITYDEFINITION"].QueryDefs["GetQueuePriorityDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QueuePriorityDefinition.GetQueuePriorityDefNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<QueuePriorityDefinition.GetQueuePriorityDefNQL_Class> GetQueuePriorityDefNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUEPRIORITYDEFINITION"].QueryDefs["GetQueuePriorityDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QueuePriorityDefinition.GetQueuePriorityDefNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Öncelik Sebebi
    /// </summary>
        public string PriorityName
        {
            get { return (string)this["PRIORITYNAME"]; }
            set { this["PRIORITYNAME"] = value; }
        }

        protected QueuePriorityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QueuePriorityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QueuePriorityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QueuePriorityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QueuePriorityDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QUEUEPRIORITYDEFINITION", dataRow) { }
        protected QueuePriorityDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QUEUEPRIORITYDEFINITION", dataRow, isImported) { }
        public QueuePriorityDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QueuePriorityDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QueuePriorityDefinition() : base() { }

    }
}