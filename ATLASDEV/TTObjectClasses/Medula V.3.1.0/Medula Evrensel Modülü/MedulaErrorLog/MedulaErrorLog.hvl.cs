
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaErrorLog")] 

    public  partial class MedulaErrorLog : TTObject
    {
        public class MedulaErrorLogList : TTObjectCollection<MedulaErrorLog> { }
                    
        public class ChildMedulaErrorLogCollection : TTObject.TTChildObjectCollection<MedulaErrorLog>
        {
            public ChildMedulaErrorLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaErrorLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("106138a6-0a6f-49c9-b7ea-9541e62d28de"); } }
            public static Guid Cancelled { get { return new Guid("25ab6cbd-f0d3-4110-9415-26ed6c20ad95"); } }
            public static Guid New { get { return new Guid("434a9f5f-4166-43e9-a0f0-38194d694bdd"); } }
        }

        public static BindingList<MedulaErrorLog> MedulaErrorLogWorkListByMedulaActionID(TTObjectContext objectContext, int MEDULAACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORLOG"].QueryDefs["MedulaErrorLogWorkListByMedulaActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MEDULAACTIONID", MEDULAACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<MedulaErrorLog>(queryDef, paramList);
        }

        public static BindingList<MedulaErrorLog> MedulaErrorLogWorkList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORLOG"].QueryDefs["MedulaErrorLogWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaErrorLog>(queryDef, paramList, injectionSQL);
        }

        public object ErrorException
        {
            get { return (object)this["ERROREXCEPTION"]; }
            set { this["ERROREXCEPTION"] = value; }
        }

        public object ResponseXML
        {
            get { return (object)this["RESPONSEXML"]; }
            set { this["RESPONSEXML"] = value; }
        }

        public DateTime? ErrorDate
        {
            get { return (DateTime?)this["ERRORDATE"]; }
            set { this["ERRORDATE"] = value; }
        }

        public BaseMedulaWLAction BaseMedulaWLAction
        {
            get { return (BaseMedulaWLAction)((ITTObject)this).GetParent("BASEMEDULAWLACTION"); }
            set { this["BASEMEDULAWLACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaErrorLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaErrorLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaErrorLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaErrorLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaErrorLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAERRORLOG", dataRow) { }
        protected MedulaErrorLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAERRORLOG", dataRow, isImported) { }
        public MedulaErrorLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaErrorLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaErrorLog() : base() { }

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