
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockTransaction")] 

    /// <summary>
    /// Stok Hareketleri için kullanılan temel sınıftır. Ortak stok hareketi bilgilerini tutar.
    /// </summary>
    public  partial class StockTransaction : TTObject
    {
        public class StockTransactionList : TTObjectCollection<StockTransaction> { }
                    
        public class ChildStockTransactionCollection : TTObject.TTChildObjectCollection<StockTransaction>
        {
            public ChildStockTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSpendByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public Object Spendamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SPENDAMOUNT"]);
                }
            }

            public GetSpendByStoreIDForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSpendByStoreIDForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSpendByStoreIDForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMonthlyConsumptionReportQuery_Class : TTReportNqlObject 
        {
            public Object Consumptionamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSUMPTIONAMOUNT"]);
                }
            }

            public GetMonthlyConsumptionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMonthlyConsumptionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMonthlyConsumptionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ConsumableStockCardQuery_Class : TTReportNqlObject 
        {
            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public string Stockcardnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Stockcardorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockcarddistributiontype
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDDISTRIBUTIONTYPE"]);
                }
            }

            public string Stockcardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ConsumableStockCardQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsumableStockCardQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsumableStockCardQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class StockTransactionReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public string ShortDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["SHORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockactionstoreobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONSTOREOBJECTID"]);
                }
            }

            public string Store
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Destinationstoreobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DESTINATIONSTOREOBJECTID"]);
                }
            }

            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockTransactionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockTransactionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockTransactionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialConsumptionAmount_Class : TTReportNqlObject 
        {
            public Object Consumptionamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSUMPTIONAMOUNT"]);
                }
            }

            public GetMaterialConsumptionAmount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialConsumptionAmount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialConsumptionAmount_Class() : base() { }
        }

        [Serializable] 

        public partial class ConsumableMaterialForStoreQuery_Class : TTReportNqlObject 
        {
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public string Materialcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ConsumableMaterialForStoreQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsumableMaterialForStoreQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsumableMaterialForStoreQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStockCardForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetChequeDocumentForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Chequeamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CHEQUEAMOUNT"]);
                }
            }

            public GetChequeDocumentForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChequeDocumentForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChequeDocumentForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledStockTransactions_Old_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public OLAP_GetCancelledStockTransactions_Old_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledStockTransactions_Old_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledStockTransactions_Old_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMainFieldsForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public Object Consigned
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSIGNED"]);
                }
            }

            public Object Transactiondate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                }
            }

            public GetMainFieldsForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainFieldsForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainFieldsForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReturningDocumentForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Returningamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNINGAMOUNT"]);
                }
            }

            public GetReturningDocumentForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReturningDocumentForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReturningDocumentForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetConsumptionDocumentForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Consumptionamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSUMPTIONAMOUNT"]);
                }
            }

            public GetConsumptionDocumentForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConsumptionDocumentForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConsumptionDocumentForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDistributionDocumentForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Distributionamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DISTRIBUTIONAMOUNT"]);
                }
            }

            public GetDistributionDocumentForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistributionDocumentForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistributionDocumentForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOtherDocumentsForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Returningamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNINGAMOUNT"]);
                }
            }

            public GetOtherDocumentsForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOtherDocumentsForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOtherDocumentsForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class FIFOOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public FIFOOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FIFOOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FIFOOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSpendAmountForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public Object Spendamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SPENDAMOUNT"]);
                }
            }

            public GetSpendAmountForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSpendAmountForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSpendAmountForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialIDQuery_Class : TTReportNqlObject 
        {
            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public GetMaterialIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetStockTransactions_Class : TTReportNqlObject 
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

            public Guid? Storeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREOBJECTID"]);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public Guid? StockActionDetail
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAIL"]);
                }
            }

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? MaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public DateTime? Envtarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVTARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetStockTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetStockTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetStockTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTransactionsForCardPresentationReportQuery_Class : TTReportNqlObject 
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

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["SHORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? MaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public StockLevelTypeEnum? StockLevelTypeStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["STOCKLEVELTYPESTATUS"].DataType;
                    return (StockLevelTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Neworderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? AccountingTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTINGTERM"]);
                }
            }

            public GetTransactionsForCardPresentationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTransactionsForCardPresentationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTransactionsForCardPresentationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTransactionRestAmountRQ_Class : TTReportNqlObject 
        {
            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetTransactionRestAmountRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTransactionRestAmountRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTransactionRestAmountRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class LIFOOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public LIFOOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LIFOOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LIFOOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class RestFIFOStockTransactionsRQ_Class : TTReportNqlObject 
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

            public RestFIFOStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RestFIFOStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RestFIFOStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class RestLIFOStockTransactionsRQ_Class : TTReportNqlObject 
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

            public RestLIFOStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RestLIFOStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RestLIFOStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledStockTransactions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCancelledStockTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledStockTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledStockTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class ExpirationDateApproachingQuery_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stock
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCK"]);
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

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public ExpirationDateApproachingQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ExpirationDateApproachingQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ExpirationDateApproachingQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialExpirationScheduleReportQuery_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stock
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCK"]);
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

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetMaterialExpirationScheduleReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialExpirationScheduleReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialExpirationScheduleReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockTransactionsWithCollectedTRXRQ_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Trxamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TRXAMOUNT"]);
                }
            }

            public GetStockTransactionsWithCollectedTRXRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockTransactionsWithCollectedTRXRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockTransactionsWithCollectedTRXRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class LIFOLotOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public LIFOLotOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LIFOLotOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LIFOLotOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class LIFOExpirationOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public LIFOExpirationOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LIFOExpirationOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LIFOExpirationOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMinMaxLevelCalcQuery_Class : TTReportNqlObject 
        {
            public Guid? Stock
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCK"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MinimumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MINIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CriticalLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CRITICALLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["CRITICALLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MaximumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MAXIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Outamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OUTAMOUNT"]);
                }
            }

            public GetMinMaxLevelCalcQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMinMaxLevelCalcQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMinMaxLevelCalcQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class UnitePriceOfZero_Class : TTReportNqlObject 
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

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? MaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string ReceiveNotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVENOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["RECEIVENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IncomingDeliveryNotifID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCOMINGDELIVERYNOTIFID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INCOMINGDELIVERYNOTIFID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeliveryNotifictionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYNOTIFICTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["DELIVERYNOTIFICTIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UsageNotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["USAGENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UnitePriceOfZero_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UnitePriceOfZero_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UnitePriceOfZero_Class() : base() { }
        }

        [Serializable] 

        public partial class GetE1ReportQuery2_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetE1ReportQuery2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetE1ReportQuery2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetE1ReportQuery2_Class() : base() { }
        }

        [Serializable] 

        public partial class LOTOutableStockTransactions_Class : TTReportNqlObject 
        {
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

            public LOTOutableStockTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LOTOutableStockTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LOTOutableStockTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class LOTOutableStockTransactionsWithZeroPrice_Class : TTReportNqlObject 
        {
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

            public LOTOutableStockTransactionsWithZeroPrice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LOTOutableStockTransactionsWithZeroPrice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LOTOutableStockTransactionsWithZeroPrice_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialLotDetailRQ_Class : TTReportNqlObject 
        {
            public Guid? Store
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STORE"]);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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

            public MaterialLotDetailRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialLotDetailRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialLotDetailRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class FIFOLotOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public FIFOLotOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FIFOLotOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FIFOLotOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentSavingRegisterIncompletedReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Store
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Destinationstoreid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DESTINATIONSTOREID"]);
                }
            }

            public Guid? Storeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREID"]);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ShortDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["SHORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDocumentSavingRegisterIncompletedReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentSavingRegisterIncompletedReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentSavingRegisterIncompletedReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetE1ReportQuery_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetE1ReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetE1ReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetE1ReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalConsumptionAmountForAllStore_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public Object Totalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALAMOUNT"]);
                }
            }

            public GetTotalConsumptionAmountForAllStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalConsumptionAmountForAllStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalConsumptionAmountForAllStore_Class() : base() { }
        }

        [Serializable] 

        public partial class FIFOExpirationOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public FIFOExpirationOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FIFOExpirationOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FIFOExpirationOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class OutableStockTrasnactionByBudgetType_Class : TTReportNqlObject 
        {
            public Guid? BudgetTypeDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BUDGETTYPEDEFINITION"]);
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

            public OutableStockTrasnactionByBudgetType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OutableStockTrasnactionByBudgetType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OutableStockTrasnactionByBudgetType_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTransactionsForCensus_InventoryAccountReport_Class : TTReportNqlObject 
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

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["SHORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Trxdefinitiondescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXDEFINITIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockaction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? MaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public StockLevelTypeEnum? StockLevelTypeStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["STOCKLEVELTYPESTATUS"].DataType;
                    return (StockLevelTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? AccountingTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTINGTERM"]);
                }
            }

            public TransactionTypeEnum? Inout1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetTransactionsForCensus_InventoryAccountReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTransactionsForCensus_InventoryAccountReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTransactionsForCensus_InventoryAccountReport_Class() : base() { }
        }

        [Serializable] 

        public partial class LOTOutableStockTransactionsWithPrice_Class : TTReportNqlObject 
        {
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
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

            public LOTOutableStockTransactionsWithPrice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LOTOutableStockTransactionsWithPrice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LOTOutableStockTransactionsWithPrice_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMinTransactionDate_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetMinTransactionDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMinTransactionDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMinTransactionDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalConsumptionAmountByTransactionDate_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public Object Totalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALAMOUNT"]);
                }
            }

            public GetTotalConsumptionAmountByTransactionDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalConsumptionAmountByTransactionDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalConsumptionAmountByTransactionDate_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_STOK_HAREKET_Class : TTReportNqlObject 
        {
            public Guid? Stok_hareket_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOK_HAREKET_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Object Bagli_stok_hareket_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BAGLI_STOK_HAREKET_KODU"]);
                }
            }

            public Object Stok_fis_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STOK_FIS_KODU"]);
                }
            }

            public Guid? Stok_kart_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOK_KART_KODU"]);
                }
            }

            public Object Ubb_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UBB_KODU"]);
                }
            }

            public Object Firma_tanimlayici_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FIRMA_TANIMLAYICI_NUMARASI"]);
                }
            }

            public Object Malzeme_sut_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MALZEME_SUT_KODU"]);
                }
            }

            public Currency? Miktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Tasinir_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TASINIR_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? Fiyati
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIYATI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Olcu_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLCU_KODU"]);
                }
            }

            public Object Islemi_yapan_personel_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEMI_YAPAN_PERSONEL_KODU"]);
                }
            }

            public Object Kdv_orani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KDV_ORANI"]);
                }
            }

            public double? Iskonto_orani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISKONTO_ORANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DISCOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Son_kullanma_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SON_KULLANMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Mkys_stok_hareket_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_STOK_HAREKET_KODU"]);
                }
            }

            public Boolean? Iptal_durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IPTAL_DURUMU"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Object Mkys_stok_hareket_kodu_karsi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_STOK_HAREKET_KODU_KARSI"]);
                }
            }

            public int? Mkys_kunye_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_KUNYE_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Cihaz_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CIHAZ_KODU"]);
                }
            }

            public Object Ats_sorgu_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ATS_SORGU_NUMARASI"]);
                }
            }

            public Object Donor_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DONOR_KODU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public DateTime? Guncelleme_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_STOK_HAREKET_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_STOK_HAREKET_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_STOK_HAREKET_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllInStockTrasnactionRQ_Class : TTReportNqlObject 
        {
            public string Materialnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialbarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetAllInStockTrasnactionRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllInStockTrasnactionRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllInStockTrasnactionRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class StockTransactionDistRetunReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
                }
            }

            public string Stockleveltype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclasscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public int? ChattelDocDetailOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHATTELDOCDETAILORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].AllPropertyDefs["CHATTELDOCDETAILORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public StockTransactionDistRetunReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockTransactionDistRetunReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockTransactionDistRetunReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class LOTOutableStockTransactionsBudgetType_Class : TTReportNqlObject 
        {
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

            public LOTOutableStockTransactionsBudgetType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LOTOutableStockTransactionsBudgetType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LOTOutableStockTransactionsBudgetType_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllOutStockTrasnactionRQ_Class : TTReportNqlObject 
        {
            public string Materialnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialbarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetAllOutStockTrasnactionRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllOutStockTrasnactionRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllOutStockTrasnactionRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class StockTransactionInDetailsReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
                }
            }

            public string Stockleveltype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclasscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
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

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public int? ChattelDocDetailOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHATTELDOCDETAILORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].AllPropertyDefs["CHATTELDOCDETAILORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Teslimalan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESLIMALAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockTransactionInDetailsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockTransactionInDetailsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockTransactionInDetailsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class StockTransactionOutDetailsReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
                }
            }

            public string Stockleveltype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclasscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public int? ChattelDocDetailOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHATTELDOCDETAILORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].AllPropertyDefs["CHATTELDOCDETAILORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public StockTransactionOutDetailsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockTransactionOutDetailsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockTransactionOutDetailsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockTransactionFromReviewActionRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetStockTransactionFromReviewActionRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockTransactionFromReviewActionRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockTransactionFromReviewActionRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class StockTrasnactionByBudgetTypeStockInheld_Class : TTReportNqlObject 
        {
            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Stockcardnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barkod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Budgettypedefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPEDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public StockTrasnactionByBudgetTypeStockInheld_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockTrasnactionByBudgetTypeStockInheld_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockTrasnactionByBudgetTypeStockInheld_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSelectedMaterialInHeldStoreByExpirationDate_Class : TTReportNqlObject 
        {
            public Guid? Stocktransactionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKTRANSACTIONID"]);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
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

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetSelectedMaterialInHeldStoreByExpirationDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSelectedMaterialInHeldStoreByExpirationDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSelectedMaterialInHeldStoreByExpirationDate_Class() : base() { }
        }

        [Serializable] 

        public partial class ExpireDateOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public ExpireDateOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ExpireDateOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ExpireDateOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class ExpireDateLotOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public ExpireDateLotOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ExpireDateLotOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ExpireDateLotOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class ExpireDateExpirationOutableStockTransactionsRQ_Class : TTReportNqlObject 
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

            public ExpireDateExpirationOutableStockTransactionsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ExpireDateExpirationOutableStockTransactionsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ExpireDateExpirationOutableStockTransactionsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialInHeldStoreByExpirationDate_Class : TTReportNqlObject 
        {
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stock
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCK"]);
                }
            }

            public Guid? MaterialTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALTREE"]);
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

            public GetMaterialInHeldStoreByExpirationDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialInHeldStoreByExpirationDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialInHeldStoreByExpirationDate_Class() : base() { }
        }

        [Serializable] 

        public partial class StockInSumAmountRQ_Class : TTReportNqlObject 
        {
            public string Materialnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialbarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public StockInSumAmountRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockInSumAmountRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockInSumAmountRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMinMaxLevelCalcQueryWithMaterial_Class : TTReportNqlObject 
        {
            public Guid? Stock
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCK"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MinimumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MINIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CriticalLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CRITICALLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["CRITICALLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MaximumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MAXIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Outamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OUTAMOUNT"]);
                }
            }

            public GetMinMaxLevelCalcQueryWithMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMinMaxLevelCalcQueryWithMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMinMaxLevelCalcQueryWithMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialReservedForPatient_Class : TTReportNqlObject 
        {
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

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stock
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCK"]);
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

            public GetMaterialReservedForPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialReservedForPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialReservedForPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutStockTransaction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Budgettypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Currency? MinimumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MINIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MaximumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MAXIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Trxdefobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TRXDEFOBJECTID"]);
                }
            }

            public GetOutStockTransaction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutStockTransaction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutStockTransaction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInMaterialForMonthlyReport_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetInMaterialForMonthlyReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInMaterialForMonthlyReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInMaterialForMonthlyReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutMaterialForMonthlyReport_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOutMaterialForMonthlyReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutMaterialForMonthlyReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutMaterialForMonthlyReport_Class() : base() { }
        }

        [Serializable] 

        public partial class UTS_GetUnnotifiedStockTransactions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UTS_GetUnnotifiedStockTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UTS_GetUnnotifiedStockTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UTS_GetUnnotifiedStockTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPTSInByMaterial_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public GetPTSInByMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPTSInByMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPTSInByMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUsedMaterials_Class : TTReportNqlObject 
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

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? MaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string ReceiveNotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVENOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["RECEIVENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IncomingDeliveryNotifID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCOMINGDELIVERYNOTIFID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INCOMINGDELIVERYNOTIFID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeliveryNotifictionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYNOTIFICTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["DELIVERYNOTIFICTIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UsageNotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["USAGENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUsedMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUsedMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUsedMaterials_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalEquivalentMaterialConsumption_Class : TTReportNqlObject 
        {
            public Object Usedamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USEDAMOUNT"]);
                }
            }

            public GetTotalEquivalentMaterialConsumption_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalEquivalentMaterialConsumption_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalEquivalentMaterialConsumption_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialsForPrice_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialsForPrice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialsForPrice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialsForPrice_Class() : base() { }
        }

        [Serializable] 

        public partial class PTSStockTrxRQ_Class : TTReportNqlObject 
        {
            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Teslimalan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESLIMALAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PTSStockTrxRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PTSStockTrxRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PTSStockTrxRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class PTSStockTrxUnCompRQ_Class : TTReportNqlObject 
        {
            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Teslimalan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESLIMALAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PTSStockTrxUnCompRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PTSStockTrxUnCompRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PTSStockTrxUnCompRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class LogisticWorkListInTRX_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectdefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTDEFID"]);
                }
            }

            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Store
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? Tifnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIFNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public LogisticWorkListInTRX_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LogisticWorkListInTRX_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LogisticWorkListInTRX_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockTrxNullLotAndSeriNo_Class : TTReportNqlObject 
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

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? MaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string ReceiveNotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVENOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["RECEIVENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IncomingDeliveryNotifID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCOMINGDELIVERYNOTIFID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INCOMINGDELIVERYNOTIFID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeliveryNotifictionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYNOTIFICTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["DELIVERYNOTIFICTIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UsageNotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["USAGENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStockTrxNullLotAndSeriNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockTrxNullLotAndSeriNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockTrxNullLotAndSeriNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInStockTransactionLikeMKYS_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Budgettypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Currency? MinimumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MINIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MaximumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MAXIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Trxdefobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TRXDEFOBJECTID"]);
                }
            }

            public GetInStockTransactionLikeMKYS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInStockTransactionLikeMKYS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInStockTransactionLikeMKYS_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCensusStockTransactionLikeMKYS_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Censusamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CENSUSAMOUNT"]);
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

            public Currency? MinimumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MINIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MaximumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MAXIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Budgettypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Trxdefobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TRXDEFOBJECTID"]);
                }
            }

            public GetCensusStockTransactionLikeMKYS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusStockTransactionLikeMKYS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusStockTransactionLikeMKYS_Class() : base() { }
        }

        [Serializable] 

        public partial class StockOutSumAmountRQ_Class : TTReportNqlObject 
        {
            public string Materialnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialbarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public StockOutSumAmountRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockOutSumAmountRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockOutSumAmountRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutableInTrxForPTS_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
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

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
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

            public GetOutableInTrxForPTS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutableInTrxForPTS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutableInTrxForPTS_Class() : base() { }
        }

        [Serializable] 

        public partial class UserSelectedOutableTransactionRQ_Class : TTReportNqlObject 
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public UserSelectedOutableTransactionRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UserSelectedOutableTransactionRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UserSelectedOutableTransactionRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class StockInHeldByExpirationDateRQ_Class : TTReportNqlObject 
        {
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MaterialTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALTREE"]);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
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

            public StockInHeldByExpirationDateRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockInHeldByExpirationDateRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockInHeldByExpirationDateRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class ConsumedMaterialReportQuery_Class : TTReportNqlObject 
        {
            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclasscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Budgettypedefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPEDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Uniteprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITEPRICE"]);
                }
            }

            public ConsumedMaterialReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsumedMaterialReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsumedMaterialReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ExpirationDateApproachingTaskQuery_Class : TTReportNqlObject 
        {
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

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public ExpirationDateApproachingTaskQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ExpirationDateApproachingTaskQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ExpirationDateApproachingTaskQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInoutRemainingRQ_Class : TTReportNqlObject 
        {
            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetInoutRemainingRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInoutRemainingRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInoutRemainingRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockInheldReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Stockcardnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barkod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Budgettypedefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPEDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetStockInheldReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockInheldReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockInheldReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class TotalInOutStockReportQuery_Class : TTReportNqlObject 
        {
            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialbarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Budgettypedefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPEDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Guid? Materialobjectdefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTDEFID"]);
                }
            }

            public Guid? Stocktransactiondefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKTRANSACTIONDEFID"]);
                }
            }

            public string Stocktransactiondefname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKTRANSACTIONDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TotalInOutStockReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TotalInOutStockReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TotalInOutStockReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("41ef11f6-f61b-4292-a982-3eb2acd1dbb8"); } }
            public static Guid Completed { get { return new Guid("e083e11c-dee0-4b5f-bd28-54018cae34be"); } }
        }

        public static BindingList<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class> GetSpendByStoreIDForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetSpendByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class> GetSpendByStoreIDForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetSpendByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMonthlyConsumptionReportQuery_Class> GetMonthlyConsumptionReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMonthlyConsumptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMonthlyConsumptionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMonthlyConsumptionReportQuery_Class> GetMonthlyConsumptionReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMonthlyConsumptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMonthlyConsumptionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ConsumableStockCardQuery_Class> ConsumableStockCardQuery(string STOREID, string CLASSOBJECTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ConsumableStockCardQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("CLASSOBJECTID", CLASSOBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.ConsumableStockCardQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ConsumableStockCardQuery_Class> ConsumableStockCardQuery(TTObjectContext objectContext, string STOREID, string CLASSOBJECTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ConsumableStockCardQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("CLASSOBJECTID", CLASSOBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.ConsumableStockCardQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetStockTransactionsFromStock(TTObjectContext objectContext, IList<string> STOCKIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionsFromStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKIDS", STOCKIDS);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList);
        }

        public static BindingList<StockTransaction.StockTransactionReportQuery_Class> StockTransactionReportQuery(string STOREOBJECTID, string STOCKCARDOBJECTID, DateTime STARTDATE, DateTime ENDDATE, Guid BUTGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);
            paramList.Add("STOCKCARDOBJECTID", STOCKCARDOBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTransactionReportQuery_Class> StockTransactionReportQuery(TTObjectContext objectContext, string STOREOBJECTID, string STOCKCARDOBJECTID, DateTime STARTDATE, DateTime ENDDATE, Guid BUTGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);
            paramList.Add("STOCKCARDOBJECTID", STOCKCARDOBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMaterialConsumptionAmount_Class> GetMaterialConsumptionAmount(DateTime STARTDATE, DateTime ENDDATE, string MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialConsumptionAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialConsumptionAmount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMaterialConsumptionAmount_Class> GetMaterialConsumptionAmount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialConsumptionAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialConsumptionAmount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ConsumableMaterialForStoreQuery_Class> ConsumableMaterialForStoreQuery(string STOREID, string OBJECTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ConsumableMaterialForStoreQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.ConsumableMaterialForStoreQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ConsumableMaterialForStoreQuery_Class> ConsumableMaterialForStoreQuery(TTObjectContext objectContext, string STOREID, string OBJECTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ConsumableMaterialForStoreQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.ConsumableMaterialForStoreQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class> GetStockCardForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockCardForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class> GetStockCardForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockCardForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetStockTransactionToProductionConsumption(TTObjectContext objectContext, IList<Guid> CHECKEDSTOCKTRANSACTIONDEFS, DateTime FIRSTDATE, DateTime LASTDATE, Guid STOREID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionToProductionConsumption"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CHECKEDSTOCKTRANSACTIONDEFS", CHECKEDSTOCKTRANSACTIONDEFS);
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList);
        }

        public static BindingList<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class> GetChequeDocumentForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetChequeDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class> GetChequeDocumentForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetChequeDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.OLAP_GetCancelledStockTransactions_Old_Class> OLAP_GetCancelledStockTransactions_Old(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OLAP_GetCancelledStockTransactions_Old"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.OLAP_GetCancelledStockTransactions_Old_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.OLAP_GetCancelledStockTransactions_Old_Class> OLAP_GetCancelledStockTransactions_Old(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OLAP_GetCancelledStockTransactions_Old"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.OLAP_GetCancelledStockTransactions_Old_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMainFieldsForStatisticReportQuery_Class> GetMainFieldsForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMainFieldsForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMainFieldsForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMainFieldsForStatisticReportQuery_Class> GetMainFieldsForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMainFieldsForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMainFieldsForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class> GetReturningDocumentForStatisticReportQuery(string MATERIALID, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetReturningDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class> GetReturningDocumentForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetReturningDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class> GetConsumptionDocumentForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetConsumptionDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class> GetConsumptionDocumentForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetConsumptionDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class> GetDistributionDocumentForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetDistributionDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class> GetDistributionDocumentForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetDistributionDocumentForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class> GetOtherDocumentsForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOtherDocumentsForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class> GetOtherDocumentsForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOtherDocumentsForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.FIFOOutableStockTransactionsRQ_Class> FIFOOutableStockTransactionsRQ(Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["FIFOOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.FIFOOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.FIFOOutableStockTransactionsRQ_Class> FIFOOutableStockTransactionsRQ(TTObjectContext objectContext, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["FIFOOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.FIFOOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class> GetSpendAmountForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetSpendAmountForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class> GetSpendAmountForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetSpendAmountForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMaterialIDQuery_Class> GetMaterialIDQuery(DateTime STARTDATE, DateTime ENDDATE, string PARENTCLASSID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PARENTCLASSID", PARENTCLASSID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMaterialIDQuery_Class> GetMaterialIDQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string PARENTCLASSID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PARENTCLASSID", PARENTCLASSID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.OLAP_GetStockTransactions_Class> OLAP_GetStockTransactions(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OLAP_GetStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.OLAP_GetStockTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.OLAP_GetStockTransactions_Class> OLAP_GetStockTransactions(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OLAP_GetStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.OLAP_GetStockTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTransactionsForCardPresentationReportQuery_Class> GetTransactionsForCardPresentationReportQuery(Guid STOCKCARDID, Guid STOREID, Guid ACCOUNTINGTERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTransactionsForCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTransactionsForCardPresentationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTransactionsForCardPresentationReportQuery_Class> GetTransactionsForCardPresentationReportQuery(TTObjectContext objectContext, Guid STOCKCARDID, Guid STOREID, Guid ACCOUNTINGTERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTransactionsForCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTransactionsForCardPresentationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTransactionRestAmountRQ_Class> GetTransactionRestAmountRQ(Guid TRXOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTransactionRestAmountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TRXOBJECTID", TRXOBJECTID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTransactionRestAmountRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTransactionRestAmountRQ_Class> GetTransactionRestAmountRQ(TTObjectContext objectContext, Guid TRXOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTransactionRestAmountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TRXOBJECTID", TRXOBJECTID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTransactionRestAmountRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LIFOOutableStockTransactionsRQ_Class> LIFOOutableStockTransactionsRQ(Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LIFOOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LIFOOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.LIFOOutableStockTransactionsRQ_Class> LIFOOutableStockTransactionsRQ(TTObjectContext objectContext, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LIFOOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LIFOOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction> GetCompletedOUTStockTransactionsByStockActionDet(TTObjectContext objectContext, Guid STOCKACTIONDETAILID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedOUTStockTransactionsByStockActionDet"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONDETAILID", STOCKACTIONDETAILID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction> GetCompletedINStockTransactionsByStockActionDet(TTObjectContext objectContext, Guid STOCKACTIONDETAILID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedINStockTransactionsByStockActionDet"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONDETAILID", STOCKACTIONDETAILID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction> GetCompletedStockTransactions(TTObjectContext objectContext, Guid STOCKID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction> GetCompletedOUTStockTransactions(TTObjectContext objectContext, Guid STOCKID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedOUTStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction> GetCompletedINStockTransactions(TTObjectContext objectContext, Guid STOCKID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedINStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.RestFIFOStockTransactionsRQ_Class> RestFIFOStockTransactionsRQ(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["RestFIFOStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.RestFIFOStockTransactionsRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.RestFIFOStockTransactionsRQ_Class> RestFIFOStockTransactionsRQ(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["RestFIFOStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.RestFIFOStockTransactionsRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.RestLIFOStockTransactionsRQ_Class> RestLIFOStockTransactionsRQ(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["RestLIFOStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.RestLIFOStockTransactionsRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.RestLIFOStockTransactionsRQ_Class> RestLIFOStockTransactionsRQ(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["RestLIFOStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.RestLIFOStockTransactionsRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.OLAP_GetCancelledStockTransactions_Class> OLAP_GetCancelledStockTransactions(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OLAP_GetCancelledStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.OLAP_GetCancelledStockTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.OLAP_GetCancelledStockTransactions_Class> OLAP_GetCancelledStockTransactions(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OLAP_GetCancelledStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.OLAP_GetCancelledStockTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ExpirationDateApproachingQuery_Class> ExpirationDateApproachingQuery(Guid STOREID, DateTime EXPIRATIONDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpirationDateApproachingQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpirationDateApproachingQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ExpirationDateApproachingQuery_Class> ExpirationDateApproachingQuery(TTObjectContext objectContext, Guid STOREID, DateTime EXPIRATIONDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpirationDateApproachingQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpirationDateApproachingQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetCompletedINStockTransactionByDate(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid STOCKID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedINStockTransactionByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOCKID", STOCKID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList);
        }

        public static BindingList<StockTransaction> GetStockTransactionsByAccountingTerm(TTObjectContext objectContext, Guid TERM, Guid CARDDRAWER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionsByAccountingTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("CARDDRAWER", CARDDRAWER);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList);
        }

        public static BindingList<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class> GetMaterialExpirationScheduleReportQuery(Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialExpirationScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class> GetMaterialExpirationScheduleReportQuery(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialExpirationScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetStockTransactionsByStockAccountingTerm(TTObjectContext objectContext, Guid STOCKID, Guid ACCOUNTINGTERMID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionsByStockAccountingTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList);
        }

        public static BindingList<StockTransaction.GetStockTransactionsWithCollectedTRXRQ_Class> GetStockTransactionsWithCollectedTRXRQ(Guid STOREID, IList<Guid> CHECKEDSTOCKTRANSACTIONDEFS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionsWithCollectedTRXRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("CHECKEDSTOCKTRANSACTIONDEFS", CHECKEDSTOCKTRANSACTIONDEFS);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockTransactionsWithCollectedTRXRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetStockTransactionsWithCollectedTRXRQ_Class> GetStockTransactionsWithCollectedTRXRQ(TTObjectContext objectContext, Guid STOREID, IList<Guid> CHECKEDSTOCKTRANSACTIONDEFS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionsWithCollectedTRXRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("CHECKEDSTOCKTRANSACTIONDEFS", CHECKEDSTOCKTRANSACTIONDEFS);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockTransactionsWithCollectedTRXRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LIFOLotOutableStockTransactionsRQ_Class> LIFOLotOutableStockTransactionsRQ(IList<string> LOTNO, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LIFOLotOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LOTNO", LOTNO);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LIFOLotOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.LIFOLotOutableStockTransactionsRQ_Class> LIFOLotOutableStockTransactionsRQ(TTObjectContext objectContext, IList<string> LOTNO, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LIFOLotOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LOTNO", LOTNO);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LIFOLotOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.LIFOExpirationOutableStockTransactionsRQ_Class> LIFOExpirationOutableStockTransactionsRQ(IList<DateTime> EXPIRATIONDATE, Guid STOCKID, Guid STOCKLEVELTYPEID, int INCLUDENULL, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LIFOExpirationOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);
            paramList.Add("INCLUDENULL", INCLUDENULL);

            return TTReportNqlObject.QueryObjects<StockTransaction.LIFOExpirationOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.LIFOExpirationOutableStockTransactionsRQ_Class> LIFOExpirationOutableStockTransactionsRQ(TTObjectContext objectContext, IList<DateTime> EXPIRATIONDATE, Guid STOCKID, Guid STOCKLEVELTYPEID, int INCLUDENULL, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LIFOExpirationOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);
            paramList.Add("INCLUDENULL", INCLUDENULL);

            return TTReportNqlObject.QueryObjects<StockTransaction.LIFOExpirationOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction> GetCompletedStockTransactionsByTerm(TTObjectContext objectContext, Guid STOCKID, Guid ACCOUNTINGTERMID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedStockTransactionsByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.GetMinMaxLevelCalcQuery_Class> GetMinMaxLevelCalcQuery(Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMinMaxLevelCalcQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMinMaxLevelCalcQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMinMaxLevelCalcQuery_Class> GetMinMaxLevelCalcQuery(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMinMaxLevelCalcQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMinMaxLevelCalcQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.UnitePriceOfZero_Class> UnitePriceOfZero(string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["UnitePriceOfZero"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.UnitePriceOfZero_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.UnitePriceOfZero_Class> UnitePriceOfZero(TTObjectContext objectContext, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["UnitePriceOfZero"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.UnitePriceOfZero_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetE1ReportQuery2_Class> GetE1ReportQuery2(Guid STOREID, string BEGINDATE, string ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetE1ReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("BEGINDATE", BEGINDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetE1ReportQuery2_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetE1ReportQuery2_Class> GetE1ReportQuery2(TTObjectContext objectContext, Guid STOREID, string BEGINDATE, string ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetE1ReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("BEGINDATE", BEGINDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetE1ReportQuery2_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LOTOutableStockTransactions_Class> LOTOutableStockTransactions(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LOTOutableStockTransactions_Class> LOTOutableStockTransactions(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class> LOTOutableStockTransactionsWithZeroPrice(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactionsWithZeroPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class> LOTOutableStockTransactionsWithZeroPrice(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactionsWithZeroPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.MaterialLotDetailRQ_Class> MaterialLotDetailRQ(Guid STOREID, Guid STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["MaterialLotDetailRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockTransaction.MaterialLotDetailRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.MaterialLotDetailRQ_Class> MaterialLotDetailRQ(TTObjectContext objectContext, Guid STOREID, Guid STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["MaterialLotDetailRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockTransaction.MaterialLotDetailRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.FIFOLotOutableStockTransactionsRQ_Class> FIFOLotOutableStockTransactionsRQ(Guid STOCKID, Guid STOCKLEVELTYPEID, IList<string> LOTNO, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["FIFOLotOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);
            paramList.Add("LOTNO", LOTNO);

            return TTReportNqlObject.QueryObjects<StockTransaction.FIFOLotOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.FIFOLotOutableStockTransactionsRQ_Class> FIFOLotOutableStockTransactionsRQ(TTObjectContext objectContext, Guid STOCKID, Guid STOCKLEVELTYPEID, IList<string> LOTNO, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["FIFOLotOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);
            paramList.Add("LOTNO", LOTNO);

            return TTReportNqlObject.QueryObjects<StockTransaction.FIFOLotOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class> GetDocumentSavingRegisterIncompletedReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetDocumentSavingRegisterIncompletedReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class> GetDocumentSavingRegisterIncompletedReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetDocumentSavingRegisterIncompletedReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetE1ReportQuery_Class> GetE1ReportQuery(DateTime DATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetE1ReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetE1ReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetE1ReportQuery_Class> GetE1ReportQuery(TTObjectContext objectContext, DateTime DATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetE1ReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetE1ReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTotalConsumptionAmountForAllStore_Class> GetTotalConsumptionAmountForAllStore(int ALLCARDDRAWER, int ALLMATERIAL, Guid CARDDRAWER, DateTime ENDDATE, Guid MATERIAL, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTotalConsumptionAmountForAllStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ALLCARDDRAWER", ALLCARDDRAWER);
            paramList.Add("ALLMATERIAL", ALLMATERIAL);
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTotalConsumptionAmountForAllStore_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTotalConsumptionAmountForAllStore_Class> GetTotalConsumptionAmountForAllStore(TTObjectContext objectContext, int ALLCARDDRAWER, int ALLMATERIAL, Guid CARDDRAWER, DateTime ENDDATE, Guid MATERIAL, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTotalConsumptionAmountForAllStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ALLCARDDRAWER", ALLCARDDRAWER);
            paramList.Add("ALLMATERIAL", ALLMATERIAL);
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTotalConsumptionAmountForAllStore_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetCompletedOUTStockTransactionbyDate(TTObjectContext objectContext, Guid STOCKID, string STARTDATE, string ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompletedOUTStockTransactionbyDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.FIFOExpirationOutableStockTransactionsRQ_Class> FIFOExpirationOutableStockTransactionsRQ(Guid STOCKID, Guid STOCKLEVELTYPEID, IList<DateTime> EXPIRATIONDATE, int INCLUDENULL, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["FIFOExpirationOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("INCLUDENULL", INCLUDENULL);

            return TTReportNqlObject.QueryObjects<StockTransaction.FIFOExpirationOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.FIFOExpirationOutableStockTransactionsRQ_Class> FIFOExpirationOutableStockTransactionsRQ(TTObjectContext objectContext, Guid STOCKID, Guid STOCKLEVELTYPEID, IList<DateTime> EXPIRATIONDATE, int INCLUDENULL, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["FIFOExpirationOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("INCLUDENULL", INCLUDENULL);

            return TTReportNqlObject.QueryObjects<StockTransaction.FIFOExpirationOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.OutableStockTrasnactionByBudgetType_Class> OutableStockTrasnactionByBudgetType(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OutableStockTrasnactionByBudgetType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.OutableStockTrasnactionByBudgetType_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.OutableStockTrasnactionByBudgetType_Class> OutableStockTrasnactionByBudgetType(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["OutableStockTrasnactionByBudgetType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.OutableStockTrasnactionByBudgetType_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTransactionsForCensus_InventoryAccountReport_Class> GetTransactionsForCensus_InventoryAccountReport(string ACCOUNTINGTERM, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTransactionsForCensus_InventoryAccountReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTransactionsForCensus_InventoryAccountReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTransactionsForCensus_InventoryAccountReport_Class> GetTransactionsForCensus_InventoryAccountReport(TTObjectContext objectContext, string ACCOUNTINGTERM, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTransactionsForCensus_InventoryAccountReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTransactionsForCensus_InventoryAccountReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LOTOutableStockTransactionsWithPrice_Class> LOTOutableStockTransactionsWithPrice(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactionsWithPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactionsWithPrice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LOTOutableStockTransactionsWithPrice_Class> LOTOutableStockTransactionsWithPrice(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactionsWithPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactionsWithPrice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMinTransactionDate_Class> GetMinTransactionDate(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMinTransactionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMinTransactionDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMinTransactionDate_Class> GetMinTransactionDate(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMinTransactionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMinTransactionDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTotalConsumptionAmountByTransactionDate_Class> GetTotalConsumptionAmountByTransactionDate(DateTime STARTDATE, DateTime ENDDATE, Guid STORE, Guid CARDDRAWER, int ALLCARDDRAWER, Guid MATERIAL, int ALLMATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTotalConsumptionAmountByTransactionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("ALLCARDDRAWER", ALLCARDDRAWER);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("ALLMATERIAL", ALLMATERIAL);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTotalConsumptionAmountByTransactionDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTotalConsumptionAmountByTransactionDate_Class> GetTotalConsumptionAmountByTransactionDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STORE, Guid CARDDRAWER, int ALLCARDDRAWER, Guid MATERIAL, int ALLMATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTotalConsumptionAmountByTransactionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("ALLCARDDRAWER", ALLCARDDRAWER);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("ALLMATERIAL", ALLMATERIAL);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTotalConsumptionAmountByTransactionDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.VEM_STOK_HAREKET_Class> VEM_STOK_HAREKET(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["VEM_STOK_HAREKET"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransaction.VEM_STOK_HAREKET_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.VEM_STOK_HAREKET_Class> VEM_STOK_HAREKET(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["VEM_STOK_HAREKET"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransaction.VEM_STOK_HAREKET_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetAllInStockTrasnactionRQ_Class> GetAllInStockTrasnactionRQ(Guid BUDGETTYPEID, DateTime ENDDATE, DateTime STARTDATE, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetAllInStockTrasnactionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetAllInStockTrasnactionRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetAllInStockTrasnactionRQ_Class> GetAllInStockTrasnactionRQ(TTObjectContext objectContext, Guid BUDGETTYPEID, DateTime ENDDATE, DateTime STARTDATE, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetAllInStockTrasnactionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetAllInStockTrasnactionRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTransactionDistRetunReportQuery_Class> StockTransactionDistRetunReportQuery(Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionDistRetunReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionDistRetunReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTransactionDistRetunReportQuery_Class> StockTransactionDistRetunReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionDistRetunReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionDistRetunReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetCompTransByDatesAndStock(TTObjectContext objectContext, Guid STOCKID, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCompTransByDatesAndStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// LOTOutableStockTransactionsBudgetType
    /// </summary>
        public static BindingList<StockTransaction.LOTOutableStockTransactionsBudgetType_Class> LOTOutableStockTransactionsBudgetType(Guid STOCKID, Guid BUDGETTYPEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactionsBudgetType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactionsBudgetType_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// LOTOutableStockTransactionsBudgetType
    /// </summary>
        public static BindingList<StockTransaction.LOTOutableStockTransactionsBudgetType_Class> LOTOutableStockTransactionsBudgetType(TTObjectContext objectContext, Guid STOCKID, Guid BUDGETTYPEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LOTOutableStockTransactionsBudgetType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LOTOutableStockTransactionsBudgetType_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetStockTransactionFromReviewAction(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid STOCKTRANSACTIONDEFINITION, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionFromReviewAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOCKTRANSACTIONDEFINITION", STOCKTRANSACTIONDEFINITION);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.GetAllOutStockTrasnactionRQ_Class> GetAllOutStockTrasnactionRQ(Guid BUDGETTYPEID, DateTime STARTDATE, DateTime ENDDATE, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetAllOutStockTrasnactionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetAllOutStockTrasnactionRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetAllOutStockTrasnactionRQ_Class> GetAllOutStockTrasnactionRQ(TTObjectContext objectContext, Guid BUDGETTYPEID, DateTime STARTDATE, DateTime ENDDATE, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetAllOutStockTrasnactionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetAllOutStockTrasnactionRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTransactionInDetailsReportQuery_Class> StockTransactionInDetailsReportQuery(Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionInDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionInDetailsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTransactionInDetailsReportQuery_Class> StockTransactionInDetailsReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionInDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionInDetailsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTransactionOutDetailsReportQuery_Class> StockTransactionOutDetailsReportQuery(Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionOutDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionOutDetailsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTransactionOutDetailsReportQuery_Class> StockTransactionOutDetailsReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTransactionOutDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTransactionOutDetailsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetStockTransactionFromReviewActionRQ_Class> GetStockTransactionFromReviewActionRQ(DateTime ENDDATE, DateTime STARTDATE, Guid STOCKTRANSACTIONDEFINITION, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionFromReviewActionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOCKTRANSACTIONDEFINITION", STOCKTRANSACTIONDEFINITION);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockTransactionFromReviewActionRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetStockTransactionFromReviewActionRQ_Class> GetStockTransactionFromReviewActionRQ(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid STOCKTRANSACTIONDEFINITION, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionFromReviewActionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOCKTRANSACTIONDEFINITION", STOCKTRANSACTIONDEFINITION);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockTransactionFromReviewActionRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.StockTrasnactionByBudgetTypeStockInheld_Class> StockTrasnactionByBudgetTypeStockInheld(Guid STOREID, Guid BUTGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTrasnactionByBudgetTypeStockInheld"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTrasnactionByBudgetTypeStockInheld_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockTrasnactionByBudgetTypeStockInheld_Class> StockTrasnactionByBudgetTypeStockInheld(TTObjectContext objectContext, Guid STOREID, Guid BUTGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockTrasnactionByBudgetTypeStockInheld"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockTrasnactionByBudgetTypeStockInheld_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate_Class> GetSelectedMaterialInHeldStoreByExpirationDate(Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetSelectedMaterialInHeldStoreByExpirationDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate_Class> GetSelectedMaterialInHeldStoreByExpirationDate(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetSelectedMaterialInHeldStoreByExpirationDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction> GetStockTransactionsByAccountingTermOrderInOut(TTObjectContext objectContext, Guid ACCOUNTINGTERMID, Guid STOCKID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTransactionsByAccountingTermOrderInOut"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);
            paramList.Add("STOCKID", STOCKID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList);
        }

        public static BindingList<StockTransaction.ExpireDateOutableStockTransactionsRQ_Class> ExpireDateOutableStockTransactionsRQ(Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpireDateOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpireDateOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.ExpireDateOutableStockTransactionsRQ_Class> ExpireDateOutableStockTransactionsRQ(TTObjectContext objectContext, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpireDateOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpireDateOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.ExpireDateLotOutableStockTransactionsRQ_Class> ExpireDateLotOutableStockTransactionsRQ(IList<string> LOTNO, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpireDateLotOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LOTNO", LOTNO);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpireDateLotOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.ExpireDateLotOutableStockTransactionsRQ_Class> ExpireDateLotOutableStockTransactionsRQ(TTObjectContext objectContext, IList<string> LOTNO, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpireDateLotOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LOTNO", LOTNO);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpireDateLotOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.ExpireDateExpirationOutableStockTransactionsRQ_Class> ExpireDateExpirationOutableStockTransactionsRQ(IList<DateTime> EXPIRATIONDATE, int INCLUDENULL, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpireDateExpirationOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("INCLUDENULL", INCLUDENULL);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpireDateExpirationOutableStockTransactionsRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.ExpireDateExpirationOutableStockTransactionsRQ_Class> ExpireDateExpirationOutableStockTransactionsRQ(TTObjectContext objectContext, IList<DateTime> EXPIRATIONDATE, int INCLUDENULL, Guid STOCKID, Guid STOCKLEVELTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpireDateExpirationOutableStockTransactionsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("INCLUDENULL", INCLUDENULL);
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("STOCKLEVELTYPEID", STOCKLEVELTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpireDateExpirationOutableStockTransactionsRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetMaterialInHeldStoreByExpirationDate_Class> GetMaterialInHeldStoreByExpirationDate(Guid STOREID, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialInHeldStoreByExpirationDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialInHeldStoreByExpirationDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMaterialInHeldStoreByExpirationDate_Class> GetMaterialInHeldStoreByExpirationDate(TTObjectContext objectContext, Guid STOREID, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialInHeldStoreByExpirationDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialInHeldStoreByExpirationDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockInSumAmountRQ_Class> StockInSumAmountRQ(Guid BUDGETTYPEID, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockInSumAmountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockInSumAmountRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockInSumAmountRQ_Class> StockInSumAmountRQ(TTObjectContext objectContext, Guid BUDGETTYPEID, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockInSumAmountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockInSumAmountRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetInVouchers(TTObjectContext objectContext, Guid TRANSACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInVouchers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TRANSACTIONID", TRANSACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList);
        }

        public static BindingList<StockTransaction.GetMinMaxLevelCalcQueryWithMaterial_Class> GetMinMaxLevelCalcQueryWithMaterial(Guid STOREID, Guid MATERIAL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMinMaxLevelCalcQueryWithMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMinMaxLevelCalcQueryWithMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMinMaxLevelCalcQueryWithMaterial_Class> GetMinMaxLevelCalcQueryWithMaterial(TTObjectContext objectContext, Guid STOREID, Guid MATERIAL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMinMaxLevelCalcQueryWithMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMinMaxLevelCalcQueryWithMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetMaterialReservedForPatient_Class> GetMaterialReservedForPatient(Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialReservedForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialReservedForPatient_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetMaterialReservedForPatient_Class> GetMaterialReservedForPatient(TTObjectContext objectContext, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialReservedForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialReservedForPatient_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetOutStockTransaction_Class> GetOutStockTransaction(Guid STORE, DateTime STARTDATE, DateTime ENDDATE, Guid MATERIAL, Guid BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOutStockTransaction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOutStockTransaction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetOutStockTransaction_Class> GetOutStockTransaction(TTObjectContext objectContext, Guid STORE, DateTime STARTDATE, DateTime ENDDATE, Guid MATERIAL, Guid BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOutStockTransaction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOutStockTransaction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetInMaterialForMonthlyReport_Class> GetInMaterialForMonthlyReport(Guid MATERIAL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInMaterialForMonthlyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetInMaterialForMonthlyReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetInMaterialForMonthlyReport_Class> GetInMaterialForMonthlyReport(TTObjectContext objectContext, Guid MATERIAL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInMaterialForMonthlyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetInMaterialForMonthlyReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetOutMaterialForMonthlyReport_Class> GetOutMaterialForMonthlyReport(Guid MATERIAL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOutMaterialForMonthlyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOutMaterialForMonthlyReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetOutMaterialForMonthlyReport_Class> GetOutMaterialForMonthlyReport(TTObjectContext objectContext, Guid MATERIAL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOutMaterialForMonthlyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOutMaterialForMonthlyReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.UTS_GetUnnotifiedStockTransactions_Class> UTS_GetUnnotifiedStockTransactions(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["UTS_GetUnnotifiedStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransaction.UTS_GetUnnotifiedStockTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.UTS_GetUnnotifiedStockTransactions_Class> UTS_GetUnnotifiedStockTransactions(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["UTS_GetUnnotifiedStockTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransaction.UTS_GetUnnotifiedStockTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetPTSInByMaterial_Class> GetPTSInByMaterial(Guid MATERIAL, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetPTSInByMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetPTSInByMaterial_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetPTSInByMaterial_Class> GetPTSInByMaterial(TTObjectContext objectContext, Guid MATERIAL, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetPTSInByMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetPTSInByMaterial_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction> GetAllOutMaterialByDate(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetAllOutMaterialByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.GetUsedMaterials_Class> GetUsedMaterials(DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetUsedMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetUsedMaterials_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetUsedMaterials_Class> GetUsedMaterials(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetUsedMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetUsedMaterials_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction> GetAllOutMaterial(TTObjectContext objectContext, Guid STOREID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetAllOutMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction> GetInputMaterials(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInputMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.GetTotalEquivalentMaterialConsumption_Class> GetTotalEquivalentMaterialConsumption(Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTotalEquivalentMaterialConsumption"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTotalEquivalentMaterialConsumption_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetTotalEquivalentMaterialConsumption_Class> GetTotalEquivalentMaterialConsumption(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetTotalEquivalentMaterialConsumption"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetTotalEquivalentMaterialConsumption_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetOutputMaterials(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, Guid MATERIALID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOutputMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIALID", MATERIALID);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.GetMaterialsForPrice_Class> GetMaterialsForPrice(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialsForPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialsForPrice_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetMaterialsForPrice_Class> GetMaterialsForPrice(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMaterialsForPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransaction.GetMaterialsForPrice_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.PTSStockTrxRQ_Class> PTSStockTrxRQ(Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["PTSStockTrxRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.PTSStockTrxRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.PTSStockTrxRQ_Class> PTSStockTrxRQ(TTObjectContext objectContext, Guid TTOBJECTID, int BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["PTSStockTrxRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.PTSStockTrxRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlanmamış
    /// </summary>
        public static BindingList<StockTransaction.PTSStockTrxUnCompRQ_Class> PTSStockTrxUnCompRQ(int BUDGETTYPE, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["PTSStockTrxUnCompRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPE", BUDGETTYPE);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockTransaction.PTSStockTrxUnCompRQ_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlanmamış
    /// </summary>
        public static BindingList<StockTransaction.PTSStockTrxUnCompRQ_Class> PTSStockTrxUnCompRQ(TTObjectContext objectContext, int BUDGETTYPE, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["PTSStockTrxUnCompRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPE", BUDGETTYPE);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockTransaction.PTSStockTrxUnCompRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.LogisticWorkListInTRX_Class> LogisticWorkListInTRX(DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LogisticWorkListInTRX"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LogisticWorkListInTRX_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.LogisticWorkListInTRX_Class> LogisticWorkListInTRX(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["LogisticWorkListInTRX"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.LogisticWorkListInTRX_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetStockTrxNullLotAndSeriNo_Class> GetStockTrxNullLotAndSeriNo(IList<Guid> MATERIALOBJ, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTrxNullLotAndSeriNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJ", MATERIALOBJ);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockTrxNullLotAndSeriNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetStockTrxNullLotAndSeriNo_Class> GetStockTrxNullLotAndSeriNo(TTObjectContext objectContext, IList<Guid> MATERIALOBJ, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockTrxNullLotAndSeriNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJ", MATERIALOBJ);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockTrxNullLotAndSeriNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction> GetMovableOutVoucherTransaction(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetMovableOutVoucherTransaction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockTransaction.GetInStockTransactionLikeMKYS_Class> GetInStockTransactionLikeMKYS(Guid STORE, DateTime STARTDATE, DateTime ENDDATE, Guid MATERIAL, Guid BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInStockTransactionLikeMKYS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetInStockTransactionLikeMKYS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetInStockTransactionLikeMKYS_Class> GetInStockTransactionLikeMKYS(TTObjectContext objectContext, Guid STORE, DateTime STARTDATE, DateTime ENDDATE, Guid MATERIAL, Guid BUDGETTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInStockTransactionLikeMKYS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetInStockTransactionLikeMKYS_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> GetCensusStockTransactionLikeMKYS(IList<Guid> TRXIDs, Guid MATERIAL, Guid BUDGETTYPE, DateTime CENSUSDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCensusStockTransactionLikeMKYS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TRXIDS", TRXIDs);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);
            paramList.Add("CENSUSDATE", CENSUSDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetCensusStockTransactionLikeMKYS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> GetCensusStockTransactionLikeMKYS(TTObjectContext objectContext, IList<Guid> TRXIDs, Guid MATERIAL, Guid BUDGETTYPE, DateTime CENSUSDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetCensusStockTransactionLikeMKYS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TRXIDS", TRXIDs);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPE", BUDGETTYPE);
            paramList.Add("CENSUSDATE", CENSUSDATE);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetCensusStockTransactionLikeMKYS_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockOutSumAmountRQ_Class> StockOutSumAmountRQ(Guid BUDGETTYPEID, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockOutSumAmountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockOutSumAmountRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockOutSumAmountRQ_Class> StockOutSumAmountRQ(TTObjectContext objectContext, Guid BUDGETTYPEID, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockOutSumAmountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockOutSumAmountRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetOutableInTrxForPTS_Class> GetOutableInTrxForPTS(Guid STOCKID, Guid BUDGETTYPEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOutableInTrxForPTS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOutableInTrxForPTS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetOutableInTrxForPTS_Class> GetOutableInTrxForPTS(TTObjectContext objectContext, Guid STOCKID, Guid BUDGETTYPEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetOutableInTrxForPTS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetOutableInTrxForPTS_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.UserSelectedOutableTransactionRQ_Class> UserSelectedOutableTransactionRQ(Guid STOCKID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["UserSelectedOutableTransactionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.UserSelectedOutableTransactionRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.UserSelectedOutableTransactionRQ_Class> UserSelectedOutableTransactionRQ(TTObjectContext objectContext, Guid STOCKID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["UserSelectedOutableTransactionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<StockTransaction.UserSelectedOutableTransactionRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.StockInHeldByExpirationDateRQ_Class> StockInHeldByExpirationDateRQ(Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockInHeldByExpirationDateRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockInHeldByExpirationDateRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.StockInHeldByExpirationDateRQ_Class> StockInHeldByExpirationDateRQ(TTObjectContext objectContext, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["StockInHeldByExpirationDateRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.StockInHeldByExpirationDateRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ConsumedMaterialReportQuery_Class> ConsumedMaterialReportQuery(bool BUDGETTYPEFLAG, Guid BUTGETTYPE, DateTime ENDDATE, DateTime STARTDATE, IList<string> STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ConsumedMaterialReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEFLAG", BUDGETTYPEFLAG);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ConsumedMaterialReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ConsumedMaterialReportQuery_Class> ConsumedMaterialReportQuery(TTObjectContext objectContext, bool BUDGETTYPEFLAG, Guid BUTGETTYPE, DateTime ENDDATE, DateTime STARTDATE, IList<string> STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ConsumedMaterialReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEFLAG", BUDGETTYPEFLAG);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ConsumedMaterialReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.ExpirationDateApproachingTaskQuery_Class> ExpirationDateApproachingTaskQuery(DateTime EXPIRATIONDATE, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpirationDateApproachingTaskQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpirationDateApproachingTaskQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.ExpirationDateApproachingTaskQuery_Class> ExpirationDateApproachingTaskQuery(TTObjectContext objectContext, DateTime EXPIRATIONDATE, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["ExpirationDateApproachingTaskQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXPIRATIONDATE", EXPIRATIONDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockTransaction.ExpirationDateApproachingTaskQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetInoutRemainingRQ_Class> GetInoutRemainingRQ(Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, Guid BUDGETTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInoutRemainingRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetInoutRemainingRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetInoutRemainingRQ_Class> GetInoutRemainingRQ(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, Guid BUDGETTYPEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetInoutRemainingRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BUDGETTYPEID", BUDGETTYPEID);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetInoutRemainingRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.GetStockInheldReportQuery_Class> GetStockInheldReportQuery(Guid BUTGETTYPE, IList<string> STOREID, Guid MATERIAL, bool BUDGETTYPEFLAG, bool MATERIALFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockInheldReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUTGETTYPE", BUTGETTYPE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPEFLAG", BUDGETTYPEFLAG);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockInheldReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.GetStockInheldReportQuery_Class> GetStockInheldReportQuery(TTObjectContext objectContext, Guid BUTGETTYPE, IList<string> STOREID, Guid MATERIAL, bool BUDGETTYPEFLAG, bool MATERIALFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["GetStockInheldReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUTGETTYPE", BUTGETTYPE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("BUDGETTYPEFLAG", BUDGETTYPEFLAG);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);

            return TTReportNqlObject.QueryObjects<StockTransaction.GetStockInheldReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockTransaction.TotalInOutStockReportQuery_Class> TotalInOutStockReportQuery(bool BUDGETTYPEFLAG, Guid BUTGETTYPE, Guid MATERIAL, IList<string> STOREID, bool MATERIALFLAG, DateTime STARTDATE, DateTime ENDDATE, TransactionTypeEnum INOUT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["TotalInOutStockReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEFLAG", BUDGETTYPEFLAG);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("INOUT", (int)INOUT);

            return TTReportNqlObject.QueryObjects<StockTransaction.TotalInOutStockReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransaction.TotalInOutStockReportQuery_Class> TotalInOutStockReportQuery(TTObjectContext objectContext, bool BUDGETTYPEFLAG, Guid BUTGETTYPE, Guid MATERIAL, IList<string> STOREID, bool MATERIALFLAG, DateTime STARTDATE, DateTime ENDDATE, TransactionTypeEnum INOUT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].QueryDefs["TotalInOutStockReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BUDGETTYPEFLAG", BUDGETTYPEFLAG);
            paramList.Add("BUTGETTYPE", BUTGETTYPE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("INOUT", (int)INOUT);

            return TTReportNqlObject.QueryObjects<StockTransaction.TotalInOutStockReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Giriş/Çıkış
    /// </summary>
        public TransactionTypeEnum? InOut
        {
            get { return (TransactionTypeEnum?)(int?)this["INOUT"]; }
            set { this["INOUT"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// Birim Fiyatı
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// İşlem Kodu
    /// </summary>
        public MaintainLevelCodeEnum? MaintainLevelCode
        {
            get { return (MaintainLevelCodeEnum?)(int?)this["MAINTAINLEVELCODE"]; }
            set { this["MAINTAINLEVELCODE"] = value; }
        }

    /// <summary>
    /// KDV
    /// </summary>
        public long? VatRate
        {
            get { return (long?)this["VATRATE"]; }
            set { this["VATRATE"] = value; }
        }

    /// <summary>
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public int? MKYS_StokHareketID
        {
            get { return (int?)this["MKYS_STOKHAREKETID"]; }
            set { this["MKYS_STOKHAREKETID"] = value; }
        }

        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

        public string ReceiveNotificationID
        {
            get { return (string)this["RECEIVENOTIFICATIONID"]; }
            set { this["RECEIVENOTIFICATIONID"] = value; }
        }

        public string IncomingDeliveryNotifID
        {
            get { return (string)this["INCOMINGDELIVERYNOTIFID"]; }
            set { this["INCOMINGDELIVERYNOTIFID"] = value; }
        }

        public string DeliveryNotifictionID
        {
            get { return (string)this["DELIVERYNOTIFICTIONID"]; }
            set { this["DELIVERYNOTIFICTIONID"] = value; }
        }

        public string UsageNotificationID
        {
            get { return (string)this["USAGENOTIFICATIONID"]; }
            set { this["USAGENOTIFICATIONID"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransactionDefinition StockTransactionDefinition
        {
            get { return (StockTransactionDefinition)((ITTObject)this).GetParent("STOCKTRANSACTIONDEFINITION"); }
            set { this["STOCKTRANSACTIONDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockLevelType StockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("STOCKLEVELTYPE"); }
            set { this["STOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BudgetTypeDefinition BudgetTypeDefinition
        {
            get { return (BudgetTypeDefinition)((ITTObject)this).GetParent("BUDGETTYPEDEFINITION"); }
            set { this["BUDGETTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockTransactionDetailsCollection()
        {
            _StockTransactionDetails = new StockTransactionDetail.ChildStockTransactionDetailCollection(this, new Guid("f2a46bd0-1248-49e2-af90-8c9c2cec09ea"));
            ((ITTChildObjectCollection)_StockTransactionDetails).GetChildren();
        }

        protected StockTransactionDetail.ChildStockTransactionDetailCollection _StockTransactionDetails = null;
        public StockTransactionDetail.ChildStockTransactionDetailCollection StockTransactionDetails
        {
            get
            {
                if (_StockTransactionDetails == null)
                    CreateStockTransactionDetailsCollection();
                return _StockTransactionDetails;
            }
        }

        virtual protected void CreateFixedAssetTransactionsCollection()
        {
            _FixedAssetTransactions = new FixedAssetTransaction.ChildFixedAssetTransactionCollection(this, new Guid("7f52ae7f-4f8c-4188-91c6-a1bd2c9d2e30"));
            ((ITTChildObjectCollection)_FixedAssetTransactions).GetChildren();
        }

        protected FixedAssetTransaction.ChildFixedAssetTransactionCollection _FixedAssetTransactions = null;
    /// <summary>
    /// Child collection for Stok Hareketi-Demirbaş Hareketleri
    /// </summary>
        public FixedAssetTransaction.ChildFixedAssetTransactionCollection FixedAssetTransactions
        {
            get
            {
                if (_FixedAssetTransactions == null)
                    CreateFixedAssetTransactionsCollection();
                return _FixedAssetTransactions;
            }
        }

        virtual protected void CreateStockCollectedTrxsCollection()
        {
            _StockCollectedTrxs = new StockCollectedTrx.ChildStockCollectedTrxCollection(this, new Guid("cbf268c6-beb3-4908-b50a-cb0482ff3d54"));
            ((ITTChildObjectCollection)_StockCollectedTrxs).GetChildren();
        }

        protected StockCollectedTrx.ChildStockCollectedTrxCollection _StockCollectedTrxs = null;
        public StockCollectedTrx.ChildStockCollectedTrxCollection StockCollectedTrxs
        {
            get
            {
                if (_StockCollectedTrxs == null)
                    CreateStockCollectedTrxsCollection();
                return _StockCollectedTrxs;
            }
        }

        virtual protected void CreateOutStockTransactionDetailsCollection()
        {
            _OutStockTransactionDetails = new StockTransactionDetail.ChildStockTransactionDetailCollection(this, new Guid("6a2ccacf-78f8-415b-a313-f110e7ce572f"));
            ((ITTChildObjectCollection)_OutStockTransactionDetails).GetChildren();
        }

        protected StockTransactionDetail.ChildStockTransactionDetailCollection _OutStockTransactionDetails = null;
        public StockTransactionDetail.ChildStockTransactionDetailCollection OutStockTransactionDetails
        {
            get
            {
                if (_OutStockTransactionDetails == null)
                    CreateOutStockTransactionDetailsCollection();
                return _OutStockTransactionDetails;
            }
        }

        virtual protected void CreateQRCodeTransactionsCollection()
        {
            _QRCodeTransactions = new QRCodeTransaction.ChildQRCodeTransactionCollection(this, new Guid("4b9bfde0-1117-4b8b-aa38-ce5f62465dbe"));
            ((ITTChildObjectCollection)_QRCodeTransactions).GetChildren();
        }

        protected QRCodeTransaction.ChildQRCodeTransactionCollection _QRCodeTransactions = null;
        public QRCodeTransaction.ChildQRCodeTransactionCollection QRCodeTransactions
        {
            get
            {
                if (_QRCodeTransactions == null)
                    CreateQRCodeTransactionsCollection();
                return _QRCodeTransactions;
            }
        }

        virtual protected void CreateUTSNotificationDetailsCollection()
        {
            _UTSNotificationDetails = new UTSNotificationDetail.ChildUTSNotificationDetailCollection(this, new Guid("989c2276-2d9d-47dc-9d3c-6bd2d1171855"));
            ((ITTChildObjectCollection)_UTSNotificationDetails).GetChildren();
        }

        protected UTSNotificationDetail.ChildUTSNotificationDetailCollection _UTSNotificationDetails = null;
        public UTSNotificationDetail.ChildUTSNotificationDetailCollection UTSNotificationDetails
        {
            get
            {
                if (_UTSNotificationDetails == null)
                    CreateUTSNotificationDetailsCollection();
                return _UTSNotificationDetails;
            }
        }

        virtual protected void CreateAccountTransactionsCollection()
        {
            _AccountTransactions = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("d95a0d24-4b55-4e5a-9a13-f5ab0d039b76"));
            ((ITTChildObjectCollection)_AccountTransactions).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransactions = null;
        public AccountTransaction.ChildAccountTransactionCollection AccountTransactions
        {
            get
            {
                if (_AccountTransactions == null)
                    CreateAccountTransactionsCollection();
                return _AccountTransactions;
            }
        }

        protected StockTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKTRANSACTION", dataRow) { }
        protected StockTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKTRANSACTION", dataRow, isImported) { }
        public StockTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockTransaction() : base() { }

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