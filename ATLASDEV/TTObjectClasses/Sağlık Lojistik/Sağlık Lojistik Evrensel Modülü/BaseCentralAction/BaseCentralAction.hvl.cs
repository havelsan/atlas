
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseCentralAction")] 

    public  abstract  partial class BaseCentralAction : TTObject, ICentralActionWorkList
    {
        public class BaseCentralActionList : TTObjectCollection<BaseCentralAction> { }
                    
        public class ChildBaseCentralActionCollection : TTObject.TTChildObjectCollection<BaseCentralAction>
        {
            public ChildBaseCentralActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseCentralActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBaseCentralActionsCount_Class : TTReportNqlObject 
        {
            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetBaseCentralActionsCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBaseCentralActionsCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBaseCentralActionsCount_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("134f48ea-06eb-4428-8f63-1245f69e753d"); } }
            public static Guid Completed { get { return new Guid("406eeb6e-f701-4405-9f79-05853a20c03d"); } }
            public static Guid Cancelled { get { return new Guid("93bd94cd-ec9e-4e21-af7e-905fd5082088"); } }
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<BaseCentralAction.GetBaseCentralActionsCount_Class> GetBaseCentralActionsCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASECENTRALACTION"].QueryDefs["GetBaseCentralActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseCentralAction.GetBaseCentralActionsCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<BaseCentralAction.GetBaseCentralActionsCount_Class> GetBaseCentralActionsCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASECENTRALACTION"].QueryDefs["GetBaseCentralActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseCentralAction.GetBaseCentralActionsCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseCentralAction> CentralActionWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASECENTRALACTION"].QueryDefs["CentralActionWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<BaseCentralAction>(queryDef, paramList, injectionSQL);
        }

        public Guid? TTMessageObjectID
        {
            get { return (Guid?)this["TTMESSAGEOBJECTID"]; }
            set { this["TTMESSAGEOBJECTID"] = value; }
        }

        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

        public DateTime? WorkListDate
        {
            get { return (DateTime?)this["WORKLISTDATE"]; }
            set { this["WORKLISTDATE"] = value; }
        }

        public string WorkListDescription
        {
            get { return (string)this["WORKLISTDESCRIPTION"]; }
            set { this["WORKLISTDESCRIPTION"] = value; }
        }

        public Sites FromSite
        {
            get { return (Sites)((ITTObject)this).GetParent("FROMSITE"); }
            set { this["FROMSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites ToSite
        {
            get { return (Sites)((ITTObject)this).GetParent("TOSITE"); }
            set { this["TOSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseCentralAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseCentralAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseCentralAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseCentralAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseCentralAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASECENTRALACTION", dataRow) { }
        protected BaseCentralAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASECENTRALACTION", dataRow, isImported) { }
        public BaseCentralAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseCentralAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseCentralAction() : base() { }

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