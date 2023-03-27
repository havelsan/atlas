
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockCensus")] 

    /// <summary>
    /// Yılsonu Devir İşlemi
    /// </summary>
    public  partial class StockCensus : BaseAction, IWorkListBaseAction
    {
        public class StockCensusList : TTObjectCollection<StockCensus> { }
                    
        public class ChildStockCensusCollection : TTObject.TTChildObjectCollection<StockCensus>
        {
            public ChildStockCensusCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCensusCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockCensusSKHReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? MaterialCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["MATERIALCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NewCardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWCARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NEWCARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NewMaterialCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWMATERIALCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NEWMATERIALCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NewZeroCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWZEROCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NEWZEROCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NormalCardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NORMALCARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NORMALCARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? OldMaterialCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDMATERIALCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["OLDMATERIALCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? OldZeroCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDZEROCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["OLDZEROCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? TotalCardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["TOTALCARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ZeroCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ZEROCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["ZEROCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialOldCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALOLDCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["MATERIALOLDCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ZeroOldCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ZEROOLDCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["ZEROOLDCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? CardDrawer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CARDDRAWER"]);
                }
            }

            public GetStockCensusSKHReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCensusSKHReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCensusSKHReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCensusScheduleReportQuery2_Class : TTReportNqlObject 
        {
            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public long? Oldorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["OLDCARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
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

            public Object Yearcensus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEARCENSUS"]);
                }
            }

            public Object Totalin
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALIN"]);
                }
            }

            public Object Totalinprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINPRICE"]);
                }
            }

            public Object Totalout
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUT"]);
                }
            }

            public Object Totaloutprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUTPRICE"]);
                }
            }

            public Object Totalinheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINHELD"]);
                }
            }

            public Object Consigned
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSIGNED"]);
                }
            }

            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public GetCensusScheduleReportQuery2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusScheduleReportQuery2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusScheduleReportQuery2_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCensusScheduleReportQuery_Class : TTReportNqlObject 
        {
            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public StockCardStatusEnum? OldStockCardStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDSTOCKCARDSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["OLDSTOCKCARDSTATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? Oldorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["OLDCARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Dagitim
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DAGITIM"]);
                }
            }

            public Object Yearcensus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEARCENSUS"]);
                }
            }

            public Object Yearcensusprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEARCENSUSPRICE"]);
                }
            }

            public Object Totalin
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALIN"]);
                }
            }

            public Object Totalinprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINPRICE"]);
                }
            }

            public Object Totalout
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUT"]);
                }
            }

            public Object Totaloutprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUTPRICE"]);
                }
            }

            public Object Totalinheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINHELD"]);
                }
            }

            public Object Consigned
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSIGNED"]);
                }
            }

            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public GetCensusScheduleReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusScheduleReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusScheduleReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCensus_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? MaterialCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["MATERIALCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NewCardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWCARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NEWCARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NewMaterialCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWMATERIALCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NEWMATERIALCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NewZeroCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWZEROCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NEWZEROCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NormalCardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NORMALCARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["NORMALCARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? OldMaterialCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDMATERIALCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["OLDMATERIALCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? OldZeroCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDZEROCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["OLDZEROCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? TotalCardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["TOTALCARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ZeroCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ZEROCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["ZEROCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialOldCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALOLDCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["MATERIALOLDCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ZeroOldCensus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ZEROOLDCENSUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["ZEROOLDCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Materialoldcensus1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALOLDCENSUS1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["MATERIALOLDCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Carddrawer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDDRAWER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].AllPropertyDefs["ZEROOLDCENSUS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetStockCensus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCensus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCensus_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("b8dccec8-fddc-495d-bd87-f0d702f727d7"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("02dcb855-73c9-455e-90f3-fd19b090f2c5"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("5d92a47e-b929-45e0-aa96-e988f1668156"); } }
    /// <summary>
    /// İptal Edildi.
    /// </summary>
            public static Guid Canceled { get { return new Guid("0983e06a-ccc7-436d-9015-73f56bf7e700"); } }
        }

        public static BindingList<StockCensus> GetStockCencusByStoreAndTerm(TTObjectContext objectContext, Guid STOREID, Guid TERMID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetStockCencusByStoreAndTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return ((ITTQuery)objectContext).QueryObjects<StockCensus>(queryDef, paramList);
        }

        public static BindingList<StockCensus.GetStockCensusSKHReport_Class> GetStockCensusSKHReport(Guid TERMID, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetStockCensusSKHReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetStockCensusSKHReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensus.GetStockCensusSKHReport_Class> GetStockCensusSKHReport(TTObjectContext objectContext, Guid TERMID, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetStockCensusSKHReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetStockCensusSKHReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensus.GetCensusScheduleReportQuery2_Class> GetCensusScheduleReportQuery2(Guid CARDDRAWERID, Guid STOREID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetCensusScheduleReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetCensusScheduleReportQuery2_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensus.GetCensusScheduleReportQuery2_Class> GetCensusScheduleReportQuery2(TTObjectContext objectContext, Guid CARDDRAWERID, Guid STOREID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetCensusScheduleReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetCensusScheduleReportQuery2_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensus.GetCensusScheduleReportQuery_Class> GetCensusScheduleReportQuery(Guid TERMID, Guid STOREID, Guid CARDDRAWERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetCensusScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetCensusScheduleReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensus.GetCensusScheduleReportQuery_Class> GetCensusScheduleReportQuery(TTObjectContext objectContext, Guid TERMID, Guid STOREID, Guid CARDDRAWERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetCensusScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetCensusScheduleReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCensus.GetStockCensus_Class> GetStockCensus(Guid STOREID, Guid TERMID, Guid CARDDRAWERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetStockCensus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetStockCensus_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCensus.GetStockCensus_Class> GetStockCensus(TTObjectContext objectContext, Guid STOREID, Guid TERMID, Guid CARDDRAWERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUS"].QueryDefs["GetStockCensus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);

            return TTReportNqlObject.QueryObjects<StockCensus.GetStockCensus_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yeni Sıfır Devirli
    /// </summary>
        public long? NewZeroCensus
        {
            get { return (long?)this["NEWZEROCENSUS"]; }
            set { this["NEWZEROCENSUS"] = value; }
        }

    /// <summary>
    /// Sıfır Devirli
    /// </summary>
        public long? ZeroCensus
        {
            get { return (long?)this["ZEROCENSUS"]; }
            set { this["ZEROCENSUS"] = value; }
        }

    /// <summary>
    /// Eski Sıfır Devirli
    /// </summary>
        public long? OldZeroCensus
        {
            get { return (long?)this["OLDZEROCENSUS"]; }
            set { this["OLDZEROCENSUS"] = value; }
        }

    /// <summary>
    /// Kart Sıra No
    /// </summary>
        public long? CardOrderNO
        {
            get { return (long?)this["CARDORDERNO"]; }
            set { this["CARDORDERNO"] = value; }
        }

    /// <summary>
    /// Stok Kartı Adı
    /// </summary>
        public string StockCardName
        {
            get { return (string)this["STOCKCARDNAME"]; }
            set { this["STOCKCARDNAME"] = value; }
        }

    /// <summary>
    /// Mal Devirli
    /// </summary>
        public long? MaterialCensus
        {
            get { return (long?)this["MATERIALCENSUS"]; }
            set { this["MATERIALCENSUS"] = value; }
        }

    /// <summary>
    /// Eski Mal Devirli
    /// </summary>
        public long? OldMaterialCensus
        {
            get { return (long?)this["OLDMATERIALCENSUS"]; }
            set { this["OLDMATERIALCENSUS"] = value; }
        }

    /// <summary>
    /// Yeni Mal Devirli
    /// </summary>
        public long? NewMaterialCensus
        {
            get { return (long?)this["NEWMATERIALCENSUS"]; }
            set { this["NEWMATERIALCENSUS"] = value; }
        }

    /// <summary>
    /// Yeni  Kart Sayısı
    /// </summary>
        public long? NewCardAmount
        {
            get { return (long?)this["NEWCARDAMOUNT"]; }
            set { this["NEWCARDAMOUNT"] = value; }
        }

    /// <summary>
    /// Normal Kart Sayısı
    /// </summary>
        public long? NormalCardAmount
        {
            get { return (long?)this["NORMALCARDAMOUNT"]; }
            set { this["NORMALCARDAMOUNT"] = value; }
        }

    /// <summary>
    /// Önceki Dönem Mal Devirli
    /// </summary>
        public long? MaterialOldCensus
        {
            get { return (long?)this["MATERIALOLDCENSUS"]; }
            set { this["MATERIALOLDCENSUS"] = value; }
        }

    /// <summary>
    /// Önceki Dönem Sıfır Devirli
    /// </summary>
        public long? ZeroOldCensus
        {
            get { return (long?)this["ZEROOLDCENSUS"]; }
            set { this["ZEROOLDCENSUS"] = value; }
        }

    /// <summary>
    /// Dağıtım Şekli
    /// </summary>
        public string DistributionType
        {
            get { return (string)this["DISTRIBUTIONTYPE"]; }
            set { this["DISTRIBUTIONTYPE"] = value; }
        }

    /// <summary>
    /// Toplam Kart Sayısı
    /// </summary>
        public long? TotalCardAmount
        {
            get { return (long?)this["TOTALCARDAMOUNT"]; }
            set { this["TOTALCARDAMOUNT"] = value; }
        }

        public StockCardClass StockCardClass
        {
            get { return (StockCardClass)((ITTObject)this).GetParent("STOCKCARDCLASS"); }
            set { this["STOCKCARDCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MainStoreDefinition Store
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountingTerm AccountingTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("ACCOUNTINGTERM"); }
            set { this["ACCOUNTINGTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockCensusDetailsCollection()
        {
            _StockCensusDetails = new StockCensusDetail.ChildStockCensusDetailCollection(this, new Guid("d45202d9-44b8-46df-9f01-629aad45eacc"));
            ((ITTChildObjectCollection)_StockCensusDetails).GetChildren();
        }

        protected StockCensusDetail.ChildStockCensusDetailCollection _StockCensusDetails = null;
        public StockCensusDetail.ChildStockCensusDetailCollection StockCensusDetails
        {
            get
            {
                if (_StockCensusDetails == null)
                    CreateStockCensusDetailsCollection();
                return _StockCensusDetails;
            }
        }

        virtual protected void CreateMkysCensusSyncDatasCollection()
        {
            _MkysCensusSyncDatas = new MkysCensusSyncData.ChildMkysCensusSyncDataCollection(this, new Guid("061281e3-f629-4def-a36b-1d126dbf533e"));
            ((ITTChildObjectCollection)_MkysCensusSyncDatas).GetChildren();
        }

        protected MkysCensusSyncData.ChildMkysCensusSyncDataCollection _MkysCensusSyncDatas = null;
        public MkysCensusSyncData.ChildMkysCensusSyncDataCollection MkysCensusSyncDatas
        {
            get
            {
                if (_MkysCensusSyncDatas == null)
                    CreateMkysCensusSyncDatasCollection();
                return _MkysCensusSyncDatas;
            }
        }

        protected StockCensus(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockCensus(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockCensus(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockCensus(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockCensus(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCENSUS", dataRow) { }
        protected StockCensus(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCENSUS", dataRow, isImported) { }
        public StockCensus(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockCensus(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockCensus() : base() { }

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