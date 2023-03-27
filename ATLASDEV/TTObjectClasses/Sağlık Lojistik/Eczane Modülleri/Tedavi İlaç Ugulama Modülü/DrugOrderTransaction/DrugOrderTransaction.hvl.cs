
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrderTransaction")] 

    public  partial class DrugOrderTransaction : TTObject
    {
        public class DrugOrderTransactionList : TTObjectCollection<DrugOrderTransaction> { }
                    
        public class ChildDrugOrderTransactionCollection : TTObject.TTChildObjectCollection<DrugOrderTransaction>
        {
            public ChildDrugOrderTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOuttableDrugOrderTransactions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Usedamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USEDAMOUNT"]);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetOuttableDrugOrderTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOuttableDrugOrderTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOuttableDrugOrderTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderTransactionByEpisodeRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Drugorder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDER"]);
                }
            }

            public Guid? Drugdefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public GetDrugOrderTransactionByEpisodeRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderTransactionByEpisodeRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderTransactionByEpisodeRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReturnableDrugOrderTrx_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Drugorder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDER"]);
                }
            }

            public Guid? Drugdefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetReturnableDrugOrderTrx_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReturnableDrugOrderTrx_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReturnableDrugOrderTrx_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOuttableDrugOrderTrxEpisode_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Usedamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USEDAMOUNT"]);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetOuttableDrugOrderTrxEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOuttableDrugOrderTrxEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOuttableDrugOrderTrxEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReturnableDrugOrderTrxBySubEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Drugorder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDER"]);
                }
            }

            public Guid? Drugdefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetReturnableDrugOrderTrxBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReturnableDrugOrderTrxBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReturnableDrugOrderTrxBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutableTrxByDrugOrder_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Usedamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USEDAMOUNT"]);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetOutableTrxByDrugOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutableTrxByDrugOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutableTrxByDrugOrder_Class() : base() { }
        }

        public static BindingList<DrugOrderTransaction> GetDrugOrderTransactions(TTObjectContext objectContext, string DRUGORDEREPISODE, string DRUGORDERMATERIAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetDrugOrderTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);
            paramList.Add("DRUGORDERMATERIAL", DRUGORDERMATERIAL);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderTransaction>(queryDef, paramList);
        }

        public static BindingList<DrugOrderTransaction> GetDrugOrderTransactionByEpisode(TTObjectContext objectContext, Guid DRUGORDEREPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetDrugOrderTransactionByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderTransaction>(queryDef, paramList);
        }

        public static BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> GetOuttableDrugOrderTransactions(string DRUGORDEREPISODE, string DRUGORDERMATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetOuttableDrugOrderTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);
            paramList.Add("DRUGORDERMATERIAL", DRUGORDERMATERIAL);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> GetOuttableDrugOrderTransactions(TTObjectContext objectContext, string DRUGORDEREPISODE, string DRUGORDERMATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetOuttableDrugOrderTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);
            paramList.Add("DRUGORDERMATERIAL", DRUGORDERMATERIAL);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> GetDrugOrderTransactionByEpisodeRQ(Guid DRUGORDEREPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetDrugOrderTransactionByEpisodeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> GetDrugOrderTransactionByEpisodeRQ(TTObjectContext objectContext, Guid DRUGORDEREPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetDrugOrderTransactionByEpisodeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction> GetUsableTransactions(TTObjectContext objectContext, string DRUGORDEREPISODE, string DRUGORDERMATERIAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetUsableTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);
            paramList.Add("DRUGORDERMATERIAL", DRUGORDERMATERIAL);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderTransaction>(queryDef, paramList);
        }

        public static BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrx_Class> GetReturnableDrugOrderTrx(Guid DRUGORDEREPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetReturnableDrugOrderTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetReturnableDrugOrderTrx_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrx_Class> GetReturnableDrugOrderTrx(TTObjectContext objectContext, Guid DRUGORDEREPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetReturnableDrugOrderTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetReturnableDrugOrderTrx_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class> GetOuttableDrugOrderTrxEpisode(string DRUGORDEREPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetOuttableDrugOrderTrxEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class> GetOuttableDrugOrderTrxEpisode(TTObjectContext objectContext, string DRUGORDEREPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetOuttableDrugOrderTrxEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDEREPISODE", DRUGORDEREPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class> GetReturnableDrugOrderTrxBySubEpisode(Guid DRUGORDERSUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetReturnableDrugOrderTrxBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDERSUBEPISODE", DRUGORDERSUBEPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class> GetReturnableDrugOrderTrxBySubEpisode(TTObjectContext objectContext, Guid DRUGORDERSUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetReturnableDrugOrderTrxBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDERSUBEPISODE", DRUGORDERSUBEPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetReturnableDrugOrderTrxBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetOutableTrxByDrugOrder_Class> GetOutableTrxByDrugOrder(Guid DRUGORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetOutableTrxByDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDER", DRUGORDER);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetOutableTrxByDrugOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderTransaction.GetOutableTrxByDrugOrder_Class> GetOutableTrxByDrugOrder(TTObjectContext objectContext, Guid DRUGORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].QueryDefs["GetOutableTrxByDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDER", DRUGORDER);

            return TTReportNqlObject.QueryObjects<DrugOrderTransaction.GetOutableTrxByDrugOrder_Class>(objectContext, queryDef, paramList, pi);
        }

        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KScheduleMaterial KScheduleMaterial
        {
            get { return (KScheduleMaterial)((ITTObject)this).GetParent("KSCHEDULEMATERIAL"); }
            set { this["KSCHEDULEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugOrderTransactionDetailsCollection()
        {
            _DrugOrderTransactionDetails = new DrugOrderTransactionDetail.ChildDrugOrderTransactionDetailCollection(this, new Guid("c43bc830-bd02-4277-b614-6f38f2ec7db0"));
            ((ITTChildObjectCollection)_DrugOrderTransactionDetails).GetChildren();
        }

        protected DrugOrderTransactionDetail.ChildDrugOrderTransactionDetailCollection _DrugOrderTransactionDetails = null;
        public DrugOrderTransactionDetail.ChildDrugOrderTransactionDetailCollection DrugOrderTransactionDetails
        {
            get
            {
                if (_DrugOrderTransactionDetails == null)
                    CreateDrugOrderTransactionDetailsCollection();
                return _DrugOrderTransactionDetails;
            }
        }

        protected DrugOrderTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrderTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrderTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrderTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrderTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDERTRANSACTION", dataRow) { }
        protected DrugOrderTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDERTRANSACTION", dataRow, isImported) { }
        public DrugOrderTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrderTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrderTransaction() : base() { }

    }
}