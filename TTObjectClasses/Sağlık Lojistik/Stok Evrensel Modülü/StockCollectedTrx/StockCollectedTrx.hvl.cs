
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockCollectedTrx")] 

    public  partial class StockCollectedTrx : TTObject
    {
        public class StockCollectedTrxList : TTObjectCollection<StockCollectedTrx> { }
                    
        public class ChildStockCollectedTrxCollection : TTObject.TTChildObjectCollection<StockCollectedTrx>
        {
            public ChildStockCollectedTrxCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCollectedTrxCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCollectedTrxByStockActionID_Class : TTReportNqlObject 
        {
            public Guid? StockTransaction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKTRANSACTION"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCollectedTrxByStockActionID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCollectedTrxByStockActionID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCollectedTrxByStockActionID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockTransactionByStockAction_Class : TTReportNqlObject 
        {
            public Guid? StockAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public GetStockTransactionByStockAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockTransactionByStockAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockTransactionByStockAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStocktrxbyStockAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? StockAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public GetStocktrxbyStockAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStocktrxbyStockAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStocktrxbyStockAction_Class() : base() { }
        }

        public static BindingList<StockCollectedTrx> GetStockCollectedTrx(TTObjectContext objectContext, IList<string> STOCKTRANSACTIONOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCOLLECTEDTRX"].QueryDefs["GetStockCollectedTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKTRANSACTIONOBJECTID", STOCKTRANSACTIONOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<StockCollectedTrx>(queryDef, paramList);
        }

        public static BindingList<StockCollectedTrx.GetCollectedTrxByStockActionID_Class> GetCollectedTrxByStockActionID(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCOLLECTEDTRX"].QueryDefs["GetCollectedTrxByStockActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCollectedTrx.GetCollectedTrxByStockActionID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCollectedTrx.GetCollectedTrxByStockActionID_Class> GetCollectedTrxByStockActionID(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCOLLECTEDTRX"].QueryDefs["GetCollectedTrxByStockActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCollectedTrx.GetCollectedTrxByStockActionID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCollectedTrx.GetStockTransactionByStockAction_Class> GetStockTransactionByStockAction(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCOLLECTEDTRX"].QueryDefs["GetStockTransactionByStockAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCollectedTrx.GetStockTransactionByStockAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCollectedTrx.GetStockTransactionByStockAction_Class> GetStockTransactionByStockAction(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCOLLECTEDTRX"].QueryDefs["GetStockTransactionByStockAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCollectedTrx.GetStockTransactionByStockAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCollectedTrx.GetStocktrxbyStockAction_Class> GetStocktrxbyStockAction(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCOLLECTEDTRX"].QueryDefs["GetStocktrxbyStockAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCollectedTrx.GetStocktrxbyStockAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCollectedTrx.GetStocktrxbyStockAction_Class> GetStocktrxbyStockAction(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCOLLECTEDTRX"].QueryDefs["GetStocktrxbyStockAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCollectedTrx.GetStocktrxbyStockAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockCollectedTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockCollectedTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockCollectedTrx(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockCollectedTrx(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockCollectedTrx(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCOLLECTEDTRX", dataRow) { }
        protected StockCollectedTrx(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCOLLECTEDTRX", dataRow, isImported) { }
        public StockCollectedTrx(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockCollectedTrx(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockCollectedTrx() : base() { }

    }
}