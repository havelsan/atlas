
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DenemeClass")] 

    public  partial class DenemeClass : TTObject
    {
        public class DenemeClassList : TTObjectCollection<DenemeClass> { }
                    
        public class ChildDenemeClassCollection : TTObject.TTChildObjectCollection<DenemeClass>
        {
            public ChildDenemeClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDenemeClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class EvrakQ_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENEMECLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENEMECLASS"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public EvrakQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public EvrakQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected EvrakQ_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("d42d4ca0-55e5-4130-9918-8c751ae0eb5e"); } }
            public static Guid Approove { get { return new Guid("9dc6bf5e-59fa-49b6-9dc2-6d74cbb9b92d"); } }
            public static Guid Print { get { return new Guid("48c864c4-60f7-49d9-9672-184fdb79e076"); } }
            public static Guid Completed { get { return new Guid("0f264eea-8c76-4fec-92cf-37e5426a1a5d"); } }
            public static Guid Cancel { get { return new Guid("0d549367-471c-4de1-889b-0778e30688a8"); } }
            public static Guid Reject { get { return new Guid("e0fc0277-9184-4eca-8695-6b9decf5fe03"); } }
        }

        public static BindingList<DenemeClass> Evrak(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENEMECLASS"].QueryDefs["Evrak"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DenemeClass>(queryDef, paramList);
        }

        public static BindingList<DenemeClass.EvrakQ_Class> EvrakQ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENEMECLASS"].QueryDefs["EvrakQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DenemeClass.EvrakQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DenemeClass.EvrakQ_Class> EvrakQ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENEMECLASS"].QueryDefs["EvrakQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DenemeClass.EvrakQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

        public int? No
        {
            get { return (int?)this["NO"]; }
            set { this["NO"] = value; }
        }

        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DenemeClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DenemeClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DenemeClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DenemeClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DenemeClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENEMECLASS", dataRow) { }
        protected DenemeClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENEMECLASS", dataRow, isImported) { }
        public DenemeClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DenemeClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DenemeClass() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}