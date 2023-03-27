
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureFollow")] 

    /// <summary>
    /// Senet Takip İşlemi
    /// </summary>
    public  partial class DebentureFollow : AccountAction, IWorkListBaseAction
    {
        public class DebentureFollowList : TTObjectCollection<DebentureFollow> { }
                    
        public class ChildDebentureFollowCollection : TTObject.TTChildObjectCollection<DebentureFollow>
        {
            public ChildDebentureFollowCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureFollowCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DebentureFollowPaymentOrderReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Debenture
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEBENTURE"]);
                }
            }

            public DebentureFollowPaymentOrderReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DebentureFollowPaymentOrderReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DebentureFollowPaymentOrderReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class DebentureFollowExecutionReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Debenture
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEBENTURE"]);
                }
            }

            public DateTime? ExecutionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXECUTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREFOLLOWEXECUTIONLIST"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DebentureFollowManagementOfficeEnum? ManagementOffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANAGEMENTOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREFOLLOWEXECUTIONLIST"].AllPropertyDefs["MANAGEMENTOFFICE"].DataType;
                    return (DebentureFollowManagementOfficeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? City
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CITY"]);
                }
            }

            public Guid? Town
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TOWN"]);
                }
            }

            public DebentureFollowExecutionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DebentureFollowExecutionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DebentureFollowExecutionReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d340a716-d85e-435b-b207-740615334d52"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("5da75c3c-3ea0-4f8e-97b6-cf8a0bb06f9d"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c06dd24e-494f-4cce-bb3a-979e484e9d42"); } }
        }

        public static BindingList<DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class> DebentureFollowPaymentOrderReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREFOLLOW"].QueryDefs["DebentureFollowPaymentOrderReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class> DebentureFollowPaymentOrderReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREFOLLOW"].QueryDefs["DebentureFollowPaymentOrderReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DebentureFollow.DebentureFollowExecutionReportQuery_Class> DebentureFollowExecutionReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREFOLLOW"].QueryDefs["DebentureFollowExecutionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<DebentureFollow.DebentureFollowExecutionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DebentureFollow.DebentureFollowExecutionReportQuery_Class> DebentureFollowExecutionReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREFOLLOW"].QueryDefs["DebentureFollowExecutionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<DebentureFollow.DebentureFollowExecutionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Senet Sayısı
    /// </summary>
        public int? DebentureAmount
        {
            get { return (int?)this["DEBENTUREAMOUNT"]; }
            set { this["DEBENTUREAMOUNT"] = value; }
        }

        virtual protected void CreateExecutionListCollection()
        {
            _ExecutionList = new DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection(this, new Guid("431e25c9-088e-43fa-abfe-4e4c41ccf60f"));
            ((ITTChildObjectCollection)_ExecutionList).GetChildren();
        }

        protected DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection _ExecutionList = null;
    /// <summary>
    /// Child collection for Senet Takip İşlemiyle İlişkisi
    /// </summary>
        public DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection ExecutionList
        {
            get
            {
                if (_ExecutionList == null)
                    CreateExecutionListCollection();
                return _ExecutionList;
            }
        }

        virtual protected void CreatePaymentOrderListCollection()
        {
            _PaymentOrderList = new DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection(this, new Guid("834544d9-7308-454b-b2e1-1f7f968328eb"));
            ((ITTChildObjectCollection)_PaymentOrderList).GetChildren();
        }

        protected DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection _PaymentOrderList = null;
    /// <summary>
    /// Child collection for Senet Takip İşlemiyle İlişkisi
    /// </summary>
        public DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection PaymentOrderList
        {
            get
            {
                if (_PaymentOrderList == null)
                    CreatePaymentOrderListCollection();
                return _PaymentOrderList;
            }
        }

        protected DebentureFollow(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureFollow(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureFollow(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureFollow(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureFollow(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREFOLLOW", dataRow) { }
        protected DebentureFollow(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREFOLLOW", dataRow, isImported) { }
        public DebentureFollow(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureFollow(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureFollow() : base() { }

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