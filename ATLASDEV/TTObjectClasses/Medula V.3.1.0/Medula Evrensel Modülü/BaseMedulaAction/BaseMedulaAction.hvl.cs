
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedulaAction")] 

    public  abstract  partial class BaseMedulaAction : BaseMedulaWLAction
    {
        public class BaseMedulaActionList : TTObjectCollection<BaseMedulaAction> { }
                    
        public class ChildBaseMedulaActionCollection : TTObject.TTChildObjectCollection<BaseMedulaAction>
        {
            public ChildBaseMedulaActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedulaActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBaseMedulaActionForMedulaTransfer_RQ_Class : TTReportNqlObject 
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

            public String Objectdefinitionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFINITIONNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objectdefinitiondisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFINITIONDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objectdefinitiondescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFINITIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Currentstatedisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATEDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetBaseMedulaActionForMedulaTransfer_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBaseMedulaActionForMedulaTransfer_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBaseMedulaActionForMedulaTransfer_RQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid SentMedula { get { return new Guid("5853a5d1-eced-4a74-8612-8ef52e99f6a6"); } }
            public static Guid New { get { return new Guid("8a5d8f68-7a40-4611-9c33-3575cf4a45a4"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("bec40edb-77f6-4769-a121-f51db3bc0239"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("ca3a1a23-9ef1-4fba-b024-8e7551324059"); } }
            public static Guid Cancelled { get { return new Guid("5bde074e-fcba-4fd9-bef1-1d68f93c826e"); } }
            public static Guid SentServer { get { return new Guid("d99d3a60-06af-4331-ac30-a10c275ef8bd"); } }
        }

        public static BindingList<BaseMedulaAction> GetBaseMedulaActionForMedulaTransfer(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAACTION"].QueryDefs["GetBaseMedulaActionForMedulaTransfer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseMedulaAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<BaseMedulaAction.GetBaseMedulaActionForMedulaTransfer_RQ_Class> GetBaseMedulaActionForMedulaTransfer_RQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAACTION"].QueryDefs["GetBaseMedulaActionForMedulaTransfer_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseMedulaAction.GetBaseMedulaActionForMedulaTransfer_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseMedulaAction.GetBaseMedulaActionForMedulaTransfer_RQ_Class> GetBaseMedulaActionForMedulaTransfer_RQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAACTION"].QueryDefs["GetBaseMedulaActionForMedulaTransfer_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseMedulaAction.GetBaseMedulaActionForMedulaTransfer_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public MedulaTransfer MedulaTransfer
        {
            get { return (MedulaTransfer)((ITTObject)this).GetParent("MEDULATRANSFER"); }
            set { this["MEDULATRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseMedulaAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedulaAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedulaAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedulaAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedulaAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDULAACTION", dataRow) { }
        protected BaseMedulaAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDULAACTION", dataRow, isImported) { }
        public BaseMedulaAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedulaAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedulaAction() : base() { }

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