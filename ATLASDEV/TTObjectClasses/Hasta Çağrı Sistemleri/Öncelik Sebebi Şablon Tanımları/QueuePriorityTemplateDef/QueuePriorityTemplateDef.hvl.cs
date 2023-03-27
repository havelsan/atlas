
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QueuePriorityTemplateDef")] 

    public  partial class QueuePriorityTemplateDef : TTDefinitionSet
    {
        public class QueuePriorityTemplateDefList : TTObjectCollection<QueuePriorityTemplateDef> { }
                    
        public class ChildQueuePriorityTemplateDefCollection : TTObject.TTChildObjectCollection<QueuePriorityTemplateDef>
        {
            public ChildQueuePriorityTemplateDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQueuePriorityTemplateDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class QueuePriorityTemplateDefNQL_Class : TTReportNqlObject 
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

            public string TemplateName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPLATENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUEUEPRIORITYTEMPLATEDEF"].AllPropertyDefs["TEMPLATENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public QueuePriorityTemplateDefNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public QueuePriorityTemplateDefNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected QueuePriorityTemplateDefNQL_Class() : base() { }
        }

        public static BindingList<QueuePriorityTemplateDef.QueuePriorityTemplateDefNQL_Class> QueuePriorityTemplateDefNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUEPRIORITYTEMPLATEDEF"].QueryDefs["QueuePriorityTemplateDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QueuePriorityTemplateDef.QueuePriorityTemplateDefNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<QueuePriorityTemplateDef.QueuePriorityTemplateDefNQL_Class> QueuePriorityTemplateDefNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUEUEPRIORITYTEMPLATEDEF"].QueryDefs["QueuePriorityTemplateDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QueuePriorityTemplateDef.QueuePriorityTemplateDefNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Şablon Adı
    /// </summary>
        public string TemplateName
        {
            get { return (string)this["TEMPLATENAME"]; }
            set { this["TEMPLATENAME"] = value; }
        }

        virtual protected void CreateQueueTemplatePriorityGridObjectsCollection()
        {
            _QueueTemplatePriorityGridObjects = new QueueTemplatePriorityGridObject.ChildQueueTemplatePriorityGridObjectCollection(this, new Guid("973e4b49-e8a1-4d94-8f8a-1563eab752ce"));
            ((ITTChildObjectCollection)_QueueTemplatePriorityGridObjects).GetChildren();
        }

        protected QueueTemplatePriorityGridObject.ChildQueueTemplatePriorityGridObjectCollection _QueueTemplatePriorityGridObjects = null;
        public QueueTemplatePriorityGridObject.ChildQueueTemplatePriorityGridObjectCollection QueueTemplatePriorityGridObjects
        {
            get
            {
                if (_QueueTemplatePriorityGridObjects == null)
                    CreateQueueTemplatePriorityGridObjectsCollection();
                return _QueueTemplatePriorityGridObjects;
            }
        }

        protected QueuePriorityTemplateDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QueuePriorityTemplateDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QueuePriorityTemplateDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QueuePriorityTemplateDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QueuePriorityTemplateDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QUEUEPRIORITYTEMPLATEDEF", dataRow) { }
        protected QueuePriorityTemplateDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QUEUEPRIORITYTEMPLATEDEF", dataRow, isImported) { }
        public QueuePriorityTemplateDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QueuePriorityTemplateDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QueuePriorityTemplateDef() : base() { }

    }
}