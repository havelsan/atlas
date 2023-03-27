
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrderTransactionDetail")] 

    public  partial class DrugOrderTransactionDetail : TTObject
    {
        public class DrugOrderTransactionDetailList : TTObjectCollection<DrugOrderTransactionDetail> { }
                    
        public class ChildDrugOrderTransactionDetailCollection : TTObject.TTChildObjectCollection<DrugOrderTransactionDetail>
        {
            public ChildDrugOrderTransactionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderTransactionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugOrderTransactionDetailWithDeail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDrugOrderTransactionDetailWithDeail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderTransactionDetailWithDeail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderTransactionDetailWithDeail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderTransactionDetailWithFilter_Class : TTReportNqlObject 
        {
            public Object Hastaadi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAADI"]);
                }
            }

            public long? Tck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Ilac
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILAC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderTransactionDetailWithFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderTransactionDetailWithFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderTransactionDetailWithFilter_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("ab436905-a7a6-4291-9acf-ec41d395d1cf"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("5d243c56-564b-49d0-9707-798af379478d"); } }
        }

        public static BindingList<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithDeail_Class> GetDrugOrderTransactionDetailWithDeail(IList<Guid> DRUGORDERDETAILS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTIONDETAIL"].QueryDefs["GetDrugOrderTransactionDetailWithDeail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDERDETAILS", DRUGORDERDETAILS);

            return TTReportNqlObject.QueryObjects<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithDeail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithDeail_Class> GetDrugOrderTransactionDetailWithDeail(TTObjectContext objectContext, IList<Guid> DRUGORDERDETAILS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTIONDETAIL"].QueryDefs["GetDrugOrderTransactionDetailWithDeail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDERDETAILS", DRUGORDERDETAILS);

            return TTReportNqlObject.QueryObjects<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithDeail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransactionDetail> GetDrugOrderDetail(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTIONDETAIL"].QueryDefs["GetDrugOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderTransactionDetail>(queryDef, paramList);
        }

        public static BindingList<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithFilter_Class> GetDrugOrderTransactionDetailWithFilter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTIONDETAIL"].QueryDefs["GetDrugOrderTransactionDetailWithFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithFilter_Class> GetDrugOrderTransactionDetailWithFilter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTIONDETAIL"].QueryDefs["GetDrugOrderTransactionDetailWithFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrderTransactionDetail.GetDrugOrderTransactionDetailWithFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public bool? IsStockOperation
        {
            get { return (bool?)this["ISSTOCKOPERATION"]; }
            set { this["ISSTOCKOPERATION"] = value; }
        }

        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public DrugOrderTransaction DrugOrderTransaction
        {
            get { return (DrugOrderTransaction)((ITTObject)this).GetParent("DRUGORDERTRANSACTION"); }
            set { this["DRUGORDERTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderDetail DrugOrderDetail
        {
            get { return (DrugOrderDetail)((ITTObject)this).GetParent("DRUGORDERDETAIL"); }
            set { this["DRUGORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugOrderCollectedTrxCollection()
        {
            _DrugOrderCollectedTrx = new DrugOrderCollectedTrx.ChildDrugOrderCollectedTrxCollection(this, new Guid("a3e6094e-e0cc-433f-bb70-4c1f79d19ff7"));
            ((ITTChildObjectCollection)_DrugOrderCollectedTrx).GetChildren();
        }

        protected DrugOrderCollectedTrx.ChildDrugOrderCollectedTrxCollection _DrugOrderCollectedTrx = null;
        public DrugOrderCollectedTrx.ChildDrugOrderCollectedTrxCollection DrugOrderCollectedTrx
        {
            get
            {
                if (_DrugOrderCollectedTrx == null)
                    CreateDrugOrderCollectedTrxCollection();
                return _DrugOrderCollectedTrx;
            }
        }

        protected DrugOrderTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrderTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrderTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrderTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrderTransactionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDERTRANSACTIONDETAIL", dataRow) { }
        protected DrugOrderTransactionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDERTRANSACTIONDETAIL", dataRow, isImported) { }
        public DrugOrderTransactionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrderTransactionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrderTransactionDetail() : base() { }

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