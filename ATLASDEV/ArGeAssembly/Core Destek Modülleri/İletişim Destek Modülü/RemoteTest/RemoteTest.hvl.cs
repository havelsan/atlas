
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RemoteTest")] 

    public  partial class RemoteTest : TTObject
    {
        public class RemoteTestList : TTObjectCollection<RemoteTest> { }
                    
        public class ChildRemoteTestCollection : TTObject.TTChildObjectCollection<RemoteTest>
        {
            public ChildRemoteTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRemoteTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RemoteTestNql_Class : TTReportNqlObject 
        {
            public DateTime? BranchDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANCHDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public String Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? State
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STATE"]);
                }
            }

            public Guid? UserID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USERID"]);
                }
            }

            public String UserName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public RemoteTestNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RemoteTestNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RemoteTestNql_Class() : base() { }
        }

        public static class States
        {
            public static Guid TestState { get { return new Guid("51b814c2-7ebd-4efc-a57a-75b8d9e388ef"); } }
            public static Guid TestState2 { get { return new Guid("1a2c2b93-8fd7-45a2-89ea-9ab1fc917211"); } }
        }

        public static BindingList<RemoteTest.RemoteTestNql_Class> RemoteTestNql(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REMOTETEST"].QueryDefs["RemoteTestNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RemoteTest.RemoteTestNql_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RemoteTest.RemoteTestNql_Class> RemoteTestNql(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REMOTETEST"].QueryDefs["RemoteTestNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RemoteTest.RemoteTestNql_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// i
    /// </summary>
        public int? i
        {
            get { return (int?)this["I"]; }
            set { this["I"] = value; }
        }

        public EyeColorEnum? k
        {
            get { return (EyeColorEnum?)(int?)this["K"]; }
            set { this["K"] = value; }
        }

    /// <summary>
    /// j
    /// </summary>
        public int? j
        {
            get { return (int?)this["J"]; }
            set { this["J"] = value; }
        }

        protected RemoteTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RemoteTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RemoteTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RemoteTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RemoteTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REMOTETEST", dataRow) { }
        protected RemoteTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REMOTETEST", dataRow, isImported) { }
        public RemoteTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RemoteTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RemoteTest() : base() { }

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