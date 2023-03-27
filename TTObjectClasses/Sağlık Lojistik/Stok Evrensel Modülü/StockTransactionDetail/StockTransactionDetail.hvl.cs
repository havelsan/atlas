
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockTransactionDetail")] 

    /// <summary>
    /// Stok hareketlerinde temel olarak kullanılan StockTransaction sınıfının malzeme detayları için kullanılan sınıftır
    /// </summary>
    public  partial class StockTransactionDetail : TTObject
    {
        public class StockTransactionDetailList : TTObjectCollection<StockTransactionDetail> { }
                    
        public class ChildStockTransactionDetailCollection : TTObject.TTChildObjectCollection<StockTransactionDetail>
        {
            public ChildStockTransactionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockTransactionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOutStockTransactions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public TransactionTypeEnum? TransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["TRANSACTIONTYPE"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetOutStockTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutStockTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutStockTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInStockActionID_Class : TTReportNqlObject 
        {
            public Guid? StockAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public GetInStockActionID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInStockActionID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInStockActionID_Class() : base() { }
        }

        public static BindingList<StockTransactionDetail> GetInTransactionVoucherForInMaterials(TTObjectContext objectContext, Guid INTRANSACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDETAIL"].QueryDefs["GetInTransactionVoucherForInMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTRANSACTIONID", INTRANSACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransactionDetail>(queryDef, paramList);
        }

        public static BindingList<StockTransactionDetail.GetOutStockTransactions_Class> GetOutStockTransactions(Guid INTRANSACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDETAIL"].QueryDefs["GetOutStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTRANSACTIONID", INTRANSACTIONID);

            return TTReportNqlObject.QueryObjects<StockTransactionDetail.GetOutStockTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransactionDetail.GetOutStockTransactions_Class> GetOutStockTransactions(TTObjectContext objectContext, Guid INTRANSACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDETAIL"].QueryDefs["GetOutStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTRANSACTIONID", INTRANSACTIONID);

            return TTReportNqlObject.QueryObjects<StockTransactionDetail.GetOutStockTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransactionDetail.GetInStockActionID_Class> GetInStockActionID(Guid OUTTRANSACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDETAIL"].QueryDefs["GetInStockActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OUTTRANSACTIONID", OUTTRANSACTIONID);

            return TTReportNqlObject.QueryObjects<StockTransactionDetail.GetInStockActionID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransactionDetail.GetInStockActionID_Class> GetInStockActionID(TTObjectContext objectContext, Guid OUTTRANSACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDETAIL"].QueryDefs["GetInStockActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OUTTRANSACTIONID", OUTTRANSACTIONID);

            return TTReportNqlObject.QueryObjects<StockTransactionDetail.GetInStockActionID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransactionDetail> GetInTransactionVoucherForOutMaterials(TTObjectContext objectContext, Guid OUTTRANSACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDETAIL"].QueryDefs["GetInTransactionVoucherForOutMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OUTTRANSACTIONID", OUTTRANSACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransactionDetail>(queryDef, paramList);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public StockTransaction InStockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("INSTOCKTRANSACTION"); }
            set { this["INSTOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransaction OutStockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("OUTSTOCKTRANSACTION"); }
            set { this["OUTSTOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockTransactionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKTRANSACTIONDETAIL", dataRow) { }
        protected StockTransactionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKTRANSACTIONDETAIL", dataRow, isImported) { }
        public StockTransactionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockTransactionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockTransactionDetail() : base() { }

    }
}