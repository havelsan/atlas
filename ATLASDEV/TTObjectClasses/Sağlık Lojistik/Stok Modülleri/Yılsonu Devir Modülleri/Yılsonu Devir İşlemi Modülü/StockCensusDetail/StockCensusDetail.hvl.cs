
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockCensusDetail")] 

    /// <summary>
    /// Yılsonu Devir Detayları Sekmesi
    /// </summary>
    public  partial class StockCensusDetail : TTObject
    {
        public class StockCensusDetailList : TTObjectCollection<StockCensusDetail> { }
                    
        public class ChildStockCensusDetailCollection : TTObject.TTChildObjectCollection<StockCensusDetail>
        {
            public ChildStockCensusDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCensusDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOldInfoForMaterialAccountingReportQuery_Class : TTReportNqlObject 
        {
            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public Object Used
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USED"]);
                }
            }

            public Object Consigned
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSIGNED"]);
                }
            }

            public GetOldInfoForMaterialAccountingReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForMaterialAccountingReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForMaterialAccountingReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialAccountingScheduleReportQuery_Class : TTReportNqlObject 
        {
            public long? Newcardorder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWCARDORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Oldorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public Currency? YearCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YEARCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["YEARCENSUS"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalIn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALIN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["TOTALIN"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["TOTALOUT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalInHeld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["TOTALINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Consigned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSIGNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CONSIGNED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialAccountingScheduleReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialAccountingScheduleReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialAccountingScheduleReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetObjectIDForMaterialAccountingReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public GetObjectIDForMaterialAccountingReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetObjectIDForMaterialAccountingReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetObjectIDForMaterialAccountingReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDetailsForMaterialAccountingScheduleReportQuery_Class : TTReportNqlObject 
        {
            public string Actioncode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["SHORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Documentno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
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

            public GetDetailsForMaterialAccountingScheduleReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDetailsForMaterialAccountingScheduleReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDetailsForMaterialAccountingScheduleReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDetailsForStockCardPresentationReportQuery_Class : TTReportNqlObject 
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

            public GetDetailsForStockCardPresentationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDetailsForStockCardPresentationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDetailsForStockCardPresentationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCencusByStockcardStatus_Class : TTReportNqlObject 
        {
            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public long? OldCardOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDCARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["OLDCARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetStockCencusByStockcardStatus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCencusByStockcardStatus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCencusByStockcardStatus_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForStockCardPresentationReportQuery_Class : TTReportNqlObject 
        {
            public Currency? Oldinheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Oldused
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["USED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Oldconsigned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDCONSIGNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CONSIGNED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForStockCardPresentationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForStockCardPresentationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForStockCardPresentationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCensusForStockCardPresentationReportQuery_Class : TTReportNqlObject 
        {
            public Currency? Oldinheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Oldused
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["USED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Oldconsigned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDCONSIGNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CONSIGNED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetCensusForStockCardPresentationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusForStockCardPresentationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusForStockCardPresentationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_InventoryAccount_Class : TTReportNqlObject 
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

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public long? CardOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? OldCardOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDCARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["OLDCARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Yearcensus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEARCENSUS"]);
                }
            }

            public Object Totalinheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINHELD"]);
                }
            }

            public CensusReportNQL_InventoryAccount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_InventoryAccount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_InventoryAccount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardPresentationReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Mainclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Classname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
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

            public long? Oldorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetStockCardPresentationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardPresentationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardPresentationReportQuery_Class() : base() { }
        }

        public static BindingList<StockCensusDetail> GetCensusDetail(TTObjectContext objectContext, Guid TERM, Guid STOCK)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetCensusDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("STOCK", STOCK);

            return ((ITTQuery)objectContext).QueryObjects<StockCensusDetail>(queryDef, paramList);
        }

        public static BindingList<StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class> GetOldInfoForMaterialAccountingReportQuery(string MATERIALID, DateTime BEFORETERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetOldInfoForMaterialAccountingReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("BEFORETERM", BEFORETERM);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class> GetOldInfoForMaterialAccountingReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime BEFORETERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetOldInfoForMaterialAccountingReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("BEFORETERM", BEFORETERM);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class> GetMaterialAccountingScheduleReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetMaterialAccountingScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class> GetMaterialAccountingScheduleReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetMaterialAccountingScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery_Class> GetObjectIDForMaterialAccountingReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetObjectIDForMaterialAccountingReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery_Class> GetObjectIDForMaterialAccountingReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetObjectIDForMaterialAccountingReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery_Class> GetDetailsForMaterialAccountingScheduleReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetDetailsForMaterialAccountingScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery_Class> GetDetailsForMaterialAccountingScheduleReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetDetailsForMaterialAccountingScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetDetailsForStockCardPresentationReportQuery_Class> GetDetailsForStockCardPresentationReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetDetailsForStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetDetailsForStockCardPresentationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetDetailsForStockCardPresentationReportQuery_Class> GetDetailsForStockCardPresentationReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetDetailsForStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetDetailsForStockCardPresentationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetStockCencusByStockcardStatus_Class> GetStockCencusByStockcardStatus(Guid STOREID, Guid TERMID, StockCardStatusEnum STATUS, Guid CARDDRAWERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetStockCencusByStockcardStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);
            paramList.Add("STATUS", (int)STATUS);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetStockCencusByStockcardStatus_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetStockCencusByStockcardStatus_Class> GetStockCencusByStockcardStatus(TTObjectContext objectContext, Guid STOREID, Guid TERMID, StockCardStatusEnum STATUS, Guid CARDDRAWERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetStockCencusByStockcardStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);
            paramList.Add("STATUS", (int)STATUS);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetStockCencusByStockcardStatus_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetOldInfoForStockCardPresentationReportQuery_Class> GetOldInfoForStockCardPresentationReportQuery(string STOCKCARDID, string STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetOldInfoForStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetOldInfoForStockCardPresentationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetOldInfoForStockCardPresentationReportQuery_Class> GetOldInfoForStockCardPresentationReportQuery(TTObjectContext objectContext, string STOCKCARDID, string STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetOldInfoForStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetOldInfoForStockCardPresentationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetCensusForStockCardPresentationReportQuery_Class> GetCensusForStockCardPresentationReportQuery(string STOCKCARDID, string STOREID, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetCensusForStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetCensusForStockCardPresentationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetCensusForStockCardPresentationReportQuery_Class> GetCensusForStockCardPresentationReportQuery(TTObjectContext objectContext, string STOCKCARDID, string STOREID, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetCensusForStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetCensusForStockCardPresentationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.CensusReportNQL_InventoryAccount_Class> CensusReportNQL_InventoryAccount(string CARDDRAWERID, string STOREID, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["CensusReportNQL_InventoryAccount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.CensusReportNQL_InventoryAccount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.CensusReportNQL_InventoryAccount_Class> CensusReportNQL_InventoryAccount(TTObjectContext objectContext, string CARDDRAWERID, string STOREID, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["CensusReportNQL_InventoryAccount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.CensusReportNQL_InventoryAccount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetStockCardPresentationReportQuery_Class> GetStockCardPresentationReportQuery(string STOCKCARDID, string STOREID, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetStockCardPresentationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensusDetail.GetStockCardPresentationReportQuery_Class> GetStockCardPresentationReportQuery(TTObjectContext objectContext, string STOCKCARDID, string STOREID, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].QueryDefs["GetStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensusDetail.GetStockCardPresentationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplam Mevcut
    /// </summary>
        public Currency? TotalInHeld
        {
            get { return (Currency?)this["TOTALINHELD"]; }
            set { this["TOTALINHELD"] = value; }
        }

    /// <summary>
    /// Toplam Giren Tutar
    /// </summary>
        public BigCurrency? TotalInPrice
        {
            get { return (BigCurrency?)this["TOTALINPRICE"]; }
            set { this["TOTALINPRICE"] = value; }
        }

    /// <summary>
    /// Kart Sıra No
    /// </summary>
        public long? CardOrderNo
        {
            get { return (long?)this["CARDORDERNO"]; }
            set { this["CARDORDERNO"] = value; }
        }

    /// <summary>
    /// Toplam Giren
    /// </summary>
        public Currency? TotalIn
        {
            get { return (Currency?)this["TOTALIN"]; }
            set { this["TOTALIN"] = value; }
        }

    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Inheld
        {
            get { return (Currency?)this["INHELD"]; }
            set { this["INHELD"] = value; }
        }

    /// <summary>
    /// Muvakkat
    /// </summary>
        public Currency? Consigned
        {
            get { return (Currency?)this["CONSIGNED"]; }
            set { this["CONSIGNED"] = value; }
        }

    /// <summary>
    /// Bu Yıla Devreden
    /// </summary>
        public Currency? YearCensus
        {
            get { return (Currency?)this["YEARCENSUS"]; }
            set { this["YEARCENSUS"] = value; }
        }

        public StockCardStatusEnum? OldStockCardStatus
        {
            get { return (StockCardStatusEnum?)(int?)this["OLDSTOCKCARDSTATUS"]; }
            set { this["OLDSTOCKCARDSTATUS"] = value; }
        }

    /// <summary>
    /// Kullanılmış
    /// </summary>
        public Currency? Used
        {
            get { return (Currency?)this["USED"]; }
            set { this["USED"] = value; }
        }

    /// <summary>
    /// Toplam Çıkan 
    /// </summary>
        public Currency? TotalOut
        {
            get { return (Currency?)this["TOTALOUT"]; }
            set { this["TOTALOUT"] = value; }
        }

    /// <summary>
    /// Toplam Çıkan Tutar
    /// </summary>
        public BigCurrency? TotalOutPrice
        {
            get { return (BigCurrency?)this["TOTALOUTPRICE"]; }
            set { this["TOTALOUTPRICE"] = value; }
        }

    /// <summary>
    /// Kart Sıra No
    /// </summary>
        public long? OldCardOrderNo
        {
            get { return (long?)this["OLDCARDORDERNO"]; }
            set { this["OLDCARDORDERNO"] = value; }
        }

    /// <summary>
    /// Bu Yıla Devreden Tutar
    /// </summary>
        public BigCurrency? YearCensusPrice
        {
            get { return (BigCurrency?)this["YEARCENSUSPRICE"]; }
            set { this["YEARCENSUSPRICE"] = value; }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCensus StockCensus
        {
            get { return (StockCensus)((ITTObject)this).GetParent("STOCKCENSUS"); }
            set { this["STOCKCENSUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountingTerm AccountingTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("ACCOUNTINGTERM"); }
            set { this["ACCOUNTINGTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockCensusLevelsCollection()
        {
            _StockCensusLevels = new StockCensusLevel.ChildStockCensusLevelCollection(this, new Guid("de50042a-a6ed-47cb-b809-b7c9d49c353b"));
            ((ITTChildObjectCollection)_StockCensusLevels).GetChildren();
        }

        protected StockCensusLevel.ChildStockCensusLevelCollection _StockCensusLevels = null;
        public StockCensusLevel.ChildStockCensusLevelCollection StockCensusLevels
        {
            get
            {
                if (_StockCensusLevels == null)
                    CreateStockCensusLevelsCollection();
                return _StockCensusLevels;
            }
        }

        protected StockCensusDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockCensusDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockCensusDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockCensusDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockCensusDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCENSUSDETAIL", dataRow) { }
        protected StockCensusDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCENSUSDETAIL", dataRow, isImported) { }
        public StockCensusDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockCensusDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockCensusDetail() : base() { }

    }
}