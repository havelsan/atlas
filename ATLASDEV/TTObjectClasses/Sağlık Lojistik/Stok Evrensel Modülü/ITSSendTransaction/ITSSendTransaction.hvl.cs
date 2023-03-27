
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ITSSendTransaction")] 

    public  partial class ITSSendTransaction : TTObject
    {
        public class ITSSendTransactionList : TTObjectCollection<ITSSendTransaction> { }
                    
        public class ChildITSSendTransactionCollection : TTObject.TTChildObjectCollection<ITSSendTransaction>
        {
            public ChildITSSendTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildITSSendTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetITSTrx_Class : TTReportNqlObject 
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

            public string NotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITSSENDTRANSACTION"].AllPropertyDefs["NOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITSSENDTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetITSTrx_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetITSTrx_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetITSTrx_Class() : base() { }
        }

        [Serializable] 

        public partial class ITSComplatedTRXRQ_Class : TTReportNqlObject 
        {
            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LotNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["LOTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["SERIALNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITSSENDTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Stocktransaction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKTRANSACTION"]);
                }
            }

            public ITSComplatedTRXRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ITSComplatedTRXRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ITSComplatedTRXRQ_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Gönderildi
    /// </summary>
            public static Guid Send { get { return new Guid("3c05bfb7-85a6-4138-b1a4-4616ac4d6beb"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("8b44a88d-8fd6-4e87-b0d9-563836ef521c"); } }
        }

        public static BindingList<ITSSendTransaction.GetITSTrx_Class> GetITSTrx(Guid STOCKTRANSACTION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITSSENDTRANSACTION"].QueryDefs["GetITSTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKTRANSACTION", STOCKTRANSACTION);

            return TTReportNqlObject.QueryObjects<ITSSendTransaction.GetITSTrx_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ITSSendTransaction.GetITSTrx_Class> GetITSTrx(TTObjectContext objectContext, Guid STOCKTRANSACTION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITSSENDTRANSACTION"].QueryDefs["GetITSTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKTRANSACTION", STOCKTRANSACTION);

            return TTReportNqlObject.QueryObjects<ITSSendTransaction.GetITSTrx_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ITSSendTransaction.ITSComplatedTRXRQ_Class> ITSComplatedTRXRQ(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITSSENDTRANSACTION"].QueryDefs["ITSComplatedTRXRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<ITSSendTransaction.ITSComplatedTRXRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ITSSendTransaction.ITSComplatedTRXRQ_Class> ITSComplatedTRXRQ(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITSSENDTRANSACTION"].QueryDefs["ITSComplatedTRXRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<ITSSendTransaction.ITSComplatedTRXRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Bildirim ID
    /// </summary>
        public string NotificationID
        {
            get { return (string)this["NOTIFICATIONID"]; }
            set { this["NOTIFICATIONID"] = value; }
        }

    /// <summary>
    /// Bildirim Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ITSSendTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ITSSendTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ITSSendTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ITSSendTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ITSSendTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITSSENDTRANSACTION", dataRow) { }
        protected ITSSendTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITSSENDTRANSACTION", dataRow, isImported) { }
        public ITSSendTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ITSSendTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ITSSendTransaction() : base() { }

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