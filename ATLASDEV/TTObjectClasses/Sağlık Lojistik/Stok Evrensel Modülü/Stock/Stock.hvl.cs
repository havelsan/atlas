
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Stock")] 

    /// <summary>
    /// Bir deponun bir stok kartı ile ilgili mevcut, kritik seviye, maksimum seviye ve benzeri bilgilerini tutan sınıftır
    /// </summary>
    public  partial class Stock : TTDefinitionSet
    {
        public class StockList : TTObjectCollection<Stock> { }
                    
        public class ChildStockCollection : TTObject.TTChildObjectCollection<Stock>
        {
            public ChildStockCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTotalInHeldByYear_Class : TTReportNqlObject 
        {
            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public GetTotalInHeldByYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalInHeldByYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalInHeldByYear_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockForStore_Class : TTReportNqlObject 
        {
            public Guid? Stockcardclassobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASSOBJECTID"]);
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

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                }
            }

            public GetStockForStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockForStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockForStore_Class() : base() { }
        }

        [Serializable] 

        public partial class SearchStocks_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Currency? Consigned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSIGNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["CONSIGNED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Currency? SafetyLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAFETYLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["SAFETYLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Guid? Materialtreeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALTREEOBJECTID"]);
                }
            }

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Storeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREOBJECTID"]);
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

            public string Carddrawername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDDRAWERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCARDDRAWER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCYSTOCKCARD"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Gmdncode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GMDNCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].AllPropertyDefs["NAME_TR"].DataType;
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

            public SearchStocks_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SearchStocks_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SearchStocks_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockForStockCard_Class : TTReportNqlObject 
        {
            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public Guid? Stockobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKOBJECTID"]);
                }
            }

            public Currency? Consigned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSIGNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["CONSIGNED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Guid? Storeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREOBJECTID"]);
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

            public GetStockForStockCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockForStockCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockForStockCard_Class() : base() { }
        }

        [Serializable] 

        public partial class MinMaxForStockCardQuery_Class : TTReportNqlObject 
        {
            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public Object Maxlevel
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAXLEVEL"]);
                }
            }

            public Object Minlevel
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MINLEVEL"]);
                }
            }

            public Object Safetylevel
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAFETYLEVEL"]);
                }
            }

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public MinMaxForStockCardQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MinMaxForStockCardQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MinMaxForStockCardQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockDefinitions_Class : TTReportNqlObject 
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

            public string Stockcardclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStockDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalInOutStockByYear_Class : TTReportNqlObject 
        {
            public Object Totalin
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALIN"]);
                }
            }

            public Object Totalout
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUT"]);
                }
            }

            public Object Totalinprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINPRICE"]);
                }
            }

            public Object Totaloutprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUTPRICE"]);
                }
            }

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public GetTotalInOutStockByYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalInOutStockByYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalInOutStockByYear_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalInOutStock_Class : TTReportNqlObject 
        {
            public Object Totalin
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALIN"]);
                }
            }

            public Object Totalout
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUT"]);
                }
            }

            public Object Totalinprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINPRICE"]);
                }
            }

            public Object Totaloutprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALOUTPRICE"]);
                }
            }

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public GetTotalInOutStock_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalInOutStock_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalInOutStock_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockFromStoreAndMaterial_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetStockFromStoreAndMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockFromStoreAndMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockFromStoreAndMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockForStoreByTree_Class : TTReportNqlObject 
        {
            public Guid? Stockcardclassobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASSOBJECTID"]);
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

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                }
            }

            public GetStockForStoreByTree_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockForStoreByTree_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockForStoreByTree_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockForStoreByCardDrawer_Class : TTReportNqlObject 
        {
            public Guid? Stockcardclassobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASSOBJECTID"]);
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

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                }
            }

            public Object Toplammuvakkat
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMUVAKKAT"]);
                }
            }

            public GetStockForStoreByCardDrawer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockForStoreByCardDrawer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockForStoreByCardDrawer_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockForStoreByCardDrawerGMDNGroup_Class : TTReportNqlObject 
        {
            public Guid? Stockcardclassobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASSOBJECTID"]);
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

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public Guid? Gmdn
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GMDN"]);
                }
            }

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                }
            }

            public Object Toplammuvakkat
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMUVAKKAT"]);
                }
            }

            public GetStockForStoreByCardDrawerGMDNGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockForStoreByCardDrawerGMDNGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockForStoreByCardDrawerGMDNGroup_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockForStoreByCardDrawerNSNGroup_Class : TTReportNqlObject 
        {
            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public Currency? Toplammiktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Toplammuvakkat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAMMUVAKKAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["CONSIGNED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetStockForStoreByCardDrawerNSNGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockForStoreByCardDrawerNSNGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockForStoreByCardDrawerNSNGroup_Class() : base() { }
        }

        [Serializable] 

        public partial class UnitePriceOfReportQueryNew_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public UnitePriceOfReportQueryNew_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UnitePriceOfReportQueryNew_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UnitePriceOfReportQueryNew_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockByInheldMaterial_Class : TTReportNqlObject 
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

            public int? MkysMalzemeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSMALZEMEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetStockByInheldMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockByInheldMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockByInheldMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockForStoreByCardDrawerWithLevel_Class : TTReportNqlObject 
        {
            public Guid? Stockcardclassobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASSOBJECTID"]);
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

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public Guid? StockLevelType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKLEVELTYPE"]);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                }
            }

            public Object Toplammuvakkat
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMUVAKKAT"]);
                }
            }

            public GetStockForStoreByCardDrawerWithLevel_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockForStoreByCardDrawerWithLevel_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockForStoreByCardDrawerWithLevel_Class() : base() { }
        }

        [Serializable] 

        public partial class NoMatchOldMaterailQuery_Class : TTReportNqlObject 
        {
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

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public NoMatchOldMaterailQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NoMatchOldMaterailQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NoMatchOldMaterailQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialDistributeReportQuery_Class : TTReportNqlObject 
        {
            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
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

            public GetMaterialDistributeReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialDistributeReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialDistributeReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockInheldForStoreReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Mat_tree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAT_TREE"]);
                }
            }

            public Guid? Stockcardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDOBJECTID"]);
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

            public Boolean? Aktifpasif
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIFPASIF"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                }
            }

            public Object Toplammuvakkat
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMUVAKKAT"]);
                }
            }

            public GetStockInheldForStoreReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockInheldForStoreReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockInheldForStoreReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_STOK_DURUM_Class : TTReportNqlObject 
        {
            public Guid? Stok_durum_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOK_DURUM_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Depo_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPO_KODU"]);
                }
            }

            public Guid? Stok_kart_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOK_KART_KODU"]);
                }
            }

            public Currency? Maksimum_stok
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKSIMUM_STOK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MAXIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Minimum_stok
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUM_STOK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MINIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Kritik_stok
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KRITIK_STOK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["SAFETYLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Birim_fiyati
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BIRIM_FIYATI"]);
                }
            }

            public Guid? Olcu_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLCU_KODU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_STOK_DURUM_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_STOK_DURUM_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_STOK_DURUM_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCriticalStockLevelsNQL_Class : TTReportNqlObject 
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

            public GetCriticalStockLevelsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCriticalStockLevelsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCriticalStockLevelsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialForOutVoucherForm_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public GetMaterialForOutVoucherForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialForOutVoucherForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialForOutVoucherForm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHospitalInventoryFromStoreAndMaterial_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public String Storetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORETYPE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetHospitalInventoryFromStoreAndMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHospitalInventoryFromStoreAndMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHospitalInventoryFromStoreAndMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnusedStockWithDay_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetUnusedStockWithDay_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnusedStockWithDay_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnusedStockWithDay_Class() : base() { }
        }

        [Serializable] 

        public partial class StockInheldByStoreAndMaterial_Class : TTReportNqlObject 
        {
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

            public StockInheldByStoreAndMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockInheldByStoreAndMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockInheldByStoreAndMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockInheldByMaterialTreeRQ_Class : TTReportNqlObject 
        {
            public Guid? Stockobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKOBJECTID"]);
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

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public Object Toplammiktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                }
            }

            public GetStockInheldByMaterialTreeRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockInheldByMaterialTreeRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockInheldByMaterialTreeRQ_Class() : base() { }
        }

        public static BindingList<Stock.GetTotalInHeldByYear_Class> GetTotalInHeldByYear(string STOREID, int YEAR, string STOCKCARDOBJECTID, string STOCKCARDCLASSOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetTotalInHeldByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("YEAR", YEAR);
            paramList.Add("STOCKCARDOBJECTID", STOCKCARDOBJECTID);
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);

            return TTReportNqlObject.QueryObjects<Stock.GetTotalInHeldByYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetTotalInHeldByYear_Class> GetTotalInHeldByYear(TTObjectContext objectContext, string STOREID, int YEAR, string STOCKCARDOBJECTID, string STOCKCARDCLASSOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetTotalInHeldByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("YEAR", YEAR);
            paramList.Add("STOCKCARDOBJECTID", STOCKCARDOBJECTID);
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);

            return TTReportNqlObject.QueryObjects<Stock.GetTotalInHeldByYear_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStore_Class> GetStockForStore(string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStore_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStore_Class> GetStockForStore(TTObjectContext objectContext, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStore_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.SearchStocks_Class> SearchStocks(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["SearchStocks"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.SearchStocks_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock.SearchStocks_Class> SearchStocks(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["SearchStocks"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.SearchStocks_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock.GetStockForStockCard_Class> GetStockForStockCard(string STOREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStockCard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStockCard_Class> GetStockForStockCard(TTObjectContext objectContext, string STOREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStockCard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock> GetStoreMaterial(TTObjectContext objectContext, Guid STORE, Guid MATERIAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStoreMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("MATERIAL", MATERIAL);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList);
        }

        public static BindingList<Stock.MinMaxForStockCardQuery_Class> MinMaxForStockCardQuery(string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["MinMaxForStockCardQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.MinMaxForStockCardQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.MinMaxForStockCardQuery_Class> MinMaxForStockCardQuery(TTObjectContext objectContext, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["MinMaxForStockCardQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.MinMaxForStockCardQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockDefinitions_Class> GetStockDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.GetStockDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock.GetStockDefinitions_Class> GetStockDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.GetStockDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock> GetCensusOrderStocks(TTObjectContext objectContext, Guid STOREID, Guid CARDDRAWERID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetCensusOrderStocks"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Stock.GetTotalInOutStockByYear_Class> GetTotalInOutStockByYear(Guid STOCKCARDCLASSOBJECTID, Guid STOREID, Guid ACCOUNTINGTERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetTotalInOutStockByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);

            return TTReportNqlObject.QueryObjects<Stock.GetTotalInOutStockByYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetTotalInOutStockByYear_Class> GetTotalInOutStockByYear(TTObjectContext objectContext, Guid STOCKCARDCLASSOBJECTID, Guid STOREID, Guid ACCOUNTINGTERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetTotalInOutStockByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);

            return TTReportNqlObject.QueryObjects<Stock.GetTotalInOutStockByYear_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock> GetStock(TTObjectContext objectContext, string MATERIAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList);
        }

        public static BindingList<Stock.GetTotalInOutStock_Class> GetTotalInOutStock(string STOREID, string STOCKCARDCLASSOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetTotalInOutStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);

            return TTReportNqlObject.QueryObjects<Stock.GetTotalInOutStock_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetTotalInOutStock_Class> GetTotalInOutStock(TTObjectContext objectContext, string STOREID, string STOCKCARDCLASSOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetTotalInOutStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);

            return TTReportNqlObject.QueryObjects<Stock.GetTotalInOutStock_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock> GetStockForStoreStockCard(TTObjectContext objectContext, string STORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList);
        }

        public static BindingList<Stock> GetStockByStockCardClass(TTObjectContext objectContext, string STORE, IList<string> CLASSES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockByStockCardClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("CLASSES", CLASSES);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList);
        }

        public static BindingList<Stock.GetStockFromStoreAndMaterial_Class> GetStockFromStoreAndMaterial(Guid MATERIAL, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockFromStoreAndMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<Stock.GetStockFromStoreAndMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockFromStoreAndMaterial_Class> GetStockFromStoreAndMaterial(TTObjectContext objectContext, Guid MATERIAL, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockFromStoreAndMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<Stock.GetStockFromStoreAndMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock> GetStockByCardDrawer(TTObjectContext objectContext, string STORE, string CARDDRAWER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockByCardDrawer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("CARDDRAWER", CARDDRAWER);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList);
        }

        public static BindingList<Stock.GetStockForStoreByTree_Class> GetStockForStoreByTree(string STOREID, string MATERIALTREE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIALTREE", MATERIALTREE);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByTree_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByTree_Class> GetStockForStoreByTree(TTObjectContext objectContext, string STOREID, string MATERIALTREE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIALTREE", MATERIALTREE);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByTree_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawer_Class> GetStockForStoreByCardDrawer(Guid STOREID, Guid CARDDRAWERID, bool INCLUDEZEROAMOUNTS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawer_Class> GetStockForStoreByCardDrawer(TTObjectContext objectContext, Guid STOREID, Guid CARDDRAWERID, bool INCLUDEZEROAMOUNTS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawer_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawerGMDNGroup_Class> GetStockForStoreByCardDrawerGMDNGroup(Guid CARDDRAWERID, bool INCLUDEZEROAMOUNTS, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawerGMDNGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawerGMDNGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawerGMDNGroup_Class> GetStockForStoreByCardDrawerGMDNGroup(TTObjectContext objectContext, Guid CARDDRAWERID, bool INCLUDEZEROAMOUNTS, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawerGMDNGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawerGMDNGroup_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawerNSNGroup_Class> GetStockForStoreByCardDrawerNSNGroup(Guid CARDDRAWERID, bool INCLUDEZEROAMOUNTS, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawerNSNGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawerNSNGroup_Class> GetStockForStoreByCardDrawerNSNGroup(TTObjectContext objectContext, Guid CARDDRAWERID, bool INCLUDEZEROAMOUNTS, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawerNSNGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock> GetCensusOrderStocksByStore(TTObjectContext objectContext, Guid STOREID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetCensusOrderStocksByStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Stock.UnitePriceOfReportQueryNew_Class> UnitePriceOfReportQueryNew(string STOREID, Guid MATERIAL, int MATERIALFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["UnitePriceOfReportQueryNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);

            return TTReportNqlObject.QueryObjects<Stock.UnitePriceOfReportQueryNew_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.UnitePriceOfReportQueryNew_Class> UnitePriceOfReportQueryNew(TTObjectContext objectContext, string STOREID, Guid MATERIAL, int MATERIALFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["UnitePriceOfReportQueryNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);

            return TTReportNqlObject.QueryObjects<Stock.UnitePriceOfReportQueryNew_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock> GetStockByCardDrawerForZeroCensus(TTObjectContext objectContext, string CARDDRAWER, string STORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockByCardDrawerForZeroCensus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("STORE", STORE);

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList);
        }

        public static BindingList<Stock.GetStockByInheldMaterial_Class> GetStockByInheldMaterial(string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockByInheldMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockByInheldMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockByInheldMaterial_Class> GetStockByInheldMaterial(TTObjectContext objectContext, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockByInheldMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockByInheldMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawerWithLevel_Class> GetStockForStoreByCardDrawerWithLevel(Guid CARDDRAWERID, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawerWithLevel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawerWithLevel_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockForStoreByCardDrawerWithLevel_Class> GetStockForStoreByCardDrawerWithLevel(TTObjectContext objectContext, Guid CARDDRAWERID, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockForStoreByCardDrawerWithLevel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWERID", CARDDRAWERID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockForStoreByCardDrawerWithLevel_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.NoMatchOldMaterailQuery_Class> NoMatchOldMaterailQuery(Guid STORE, string ALL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["NoMatchOldMaterailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("ALL", ALL);

            return TTReportNqlObject.QueryObjects<Stock.NoMatchOldMaterailQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.NoMatchOldMaterailQuery_Class> NoMatchOldMaterailQuery(TTObjectContext objectContext, Guid STORE, string ALL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["NoMatchOldMaterailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("ALL", ALL);

            return TTReportNqlObject.QueryObjects<Stock.NoMatchOldMaterailQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetMaterialDistributeReportQuery_Class> GetMaterialDistributeReportQuery(Guid MATERIAL, int ALL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetMaterialDistributeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("ALL", ALL);

            return TTReportNqlObject.QueryObjects<Stock.GetMaterialDistributeReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetMaterialDistributeReportQuery_Class> GetMaterialDistributeReportQuery(TTObjectContext objectContext, Guid MATERIAL, int ALL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetMaterialDistributeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("ALL", ALL);

            return TTReportNqlObject.QueryObjects<Stock.GetMaterialDistributeReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockInheldForStoreReportQuery_Class> GetStockInheldForStoreReportQuery(bool INCLUDEZEROAMOUNTS, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockInheldForStoreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockInheldForStoreReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockInheldForStoreReportQuery_Class> GetStockInheldForStoreReportQuery(TTObjectContext objectContext, bool INCLUDEZEROAMOUNTS, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockInheldForStoreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INCLUDEZEROAMOUNTS", INCLUDEZEROAMOUNTS);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockInheldForStoreReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.VEM_STOK_DURUM_Class> VEM_STOK_DURUM(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["VEM_STOK_DURUM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.VEM_STOK_DURUM_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.VEM_STOK_DURUM_Class> VEM_STOK_DURUM(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["VEM_STOK_DURUM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.VEM_STOK_DURUM_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetCriticalStockLevelsNQL_Class> GetCriticalStockLevelsNQL(Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetCriticalStockLevelsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetCriticalStockLevelsNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock.GetCriticalStockLevelsNQL_Class> GetCriticalStockLevelsNQL(TTObjectContext objectContext, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetCriticalStockLevelsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetCriticalStockLevelsNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock.GetMaterialForOutVoucherForm_Class> GetMaterialForOutVoucherForm(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetMaterialForOutVoucherForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.GetMaterialForOutVoucherForm_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock.GetMaterialForOutVoucherForm_Class> GetMaterialForOutVoucherForm(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetMaterialForOutVoucherForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Stock.GetMaterialForOutVoucherForm_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Stock> GetMaterialsForOutReports(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetMaterialsForOutReports"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Stock>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Stock.GetHospitalInventoryFromStoreAndMaterial_Class> GetHospitalInventoryFromStoreAndMaterial(Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetHospitalInventoryFromStoreAndMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<Stock.GetHospitalInventoryFromStoreAndMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetHospitalInventoryFromStoreAndMaterial_Class> GetHospitalInventoryFromStoreAndMaterial(TTObjectContext objectContext, Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetHospitalInventoryFromStoreAndMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<Stock.GetHospitalInventoryFromStoreAndMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetUnusedStockWithDay_Class> GetUnusedStockWithDay(Guid STORE, DateTime STARTDATE, DateTime ENDDATE, int AMOUNT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetUnusedStockWithDay"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("AMOUNT", AMOUNT);

            return TTReportNqlObject.QueryObjects<Stock.GetUnusedStockWithDay_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetUnusedStockWithDay_Class> GetUnusedStockWithDay(TTObjectContext objectContext, Guid STORE, DateTime STARTDATE, DateTime ENDDATE, int AMOUNT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetUnusedStockWithDay"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("AMOUNT", AMOUNT);

            return TTReportNqlObject.QueryObjects<Stock.GetUnusedStockWithDay_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.StockInheldByStoreAndMaterial_Class> StockInheldByStoreAndMaterial(string STOREID, string MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["StockInheldByStoreAndMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<Stock.StockInheldByStoreAndMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.StockInheldByStoreAndMaterial_Class> StockInheldByStoreAndMaterial(TTObjectContext objectContext, string STOREID, string MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["StockInheldByStoreAndMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<Stock.StockInheldByStoreAndMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockInheldByMaterialTreeRQ_Class> GetStockInheldByMaterialTreeRQ(Guid MATERIALTREE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockInheldByMaterialTreeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALTREE", MATERIALTREE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockInheldByMaterialTreeRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Stock.GetStockInheldByMaterialTreeRQ_Class> GetStockInheldByMaterialTreeRQ(TTObjectContext objectContext, Guid MATERIALTREE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCK"].QueryDefs["GetStockInheldByMaterialTreeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALTREE", MATERIALTREE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Stock.GetStockInheldByMaterialTreeRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplam Çıkan Fiyatı
    /// </summary>
        public BigCurrency? TotalOutPrice
        {
            get { return (BigCurrency?)this["TOTALOUTPRICE"]; }
            set { this["TOTALOUTPRICE"] = value; }
        }

    /// <summary>
    /// Minimum Seviye
    /// </summary>
        public Currency? MinimumLevel
        {
            get { return (Currency?)this["MINIMUMLEVEL"]; }
            set { this["MINIMUMLEVEL"] = value; }
        }

    /// <summary>
    /// Toplam Giren Fiyatı
    /// </summary>
        public BigCurrency? TotalInPrice
        {
            get { return (BigCurrency?)this["TOTALINPRICE"]; }
            set { this["TOTALINPRICE"] = value; }
        }

    /// <summary>
    /// Toplam Çıkan Miktar
    /// </summary>
        public Currency? TotalOut
        {
            get { return (Currency?)this["TOTALOUT"]; }
            set { this["TOTALOUT"] = value; }
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
    /// Mevcut
    /// </summary>
        public Currency? Inheld
        {
            get { return (Currency?)this["INHELD"]; }
            set { this["INHELD"] = value; }
        }

    /// <summary>
    /// Toplam Giren Miktar
    /// </summary>
        public Currency? TotalIn
        {
            get { return (Currency?)this["TOTALIN"]; }
            set { this["TOTALIN"] = value; }
        }

    /// <summary>
    /// Güvenlik Seviyesi
    /// </summary>
        public Currency? SafetyLevel
        {
            get { return (Currency?)this["SAFETYLEVEL"]; }
            set { this["SAFETYLEVEL"] = value; }
        }

    /// <summary>
    /// Sarf Edilebilir
    /// </summary>
        public bool? Expendable
        {
            get { return (bool?)this["EXPENDABLE"]; }
            set { this["EXPENDABLE"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Maksimum Seviye
    /// </summary>
        public Currency? MaximumLevel
        {
            get { return (Currency?)this["MAXIMUMLEVEL"]; }
            set { this["MAXIMUMLEVEL"] = value; }
        }

    /// <summary>
    /// Kritik Seviye
    /// </summary>
        public Currency? CriticalLevel
        {
            get { return (Currency?)this["CRITICALLEVEL"]; }
            set { this["CRITICALLEVEL"] = value; }
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public int? Row
        {
            get { return (int?)this["ROW"]; }
            set { this["ROW"] = value; }
        }

    /// <summary>
    /// Raf
    /// </summary>
        public int? Shelf
        {
            get { return (int?)this["SHELF"]; }
            set { this["SHELF"] = value; }
        }

    /// <summary>
    /// Depo-Stoklar
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFixedAssetMaterialDefinitionsCollection()
        {
            _FixedAssetMaterialDefinitions = new FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection(this, new Guid("1387d63e-dc25-4943-b6e0-0edced9a5055"));
            ((ITTChildObjectCollection)_FixedAssetMaterialDefinitions).GetChildren();
        }

        protected FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection _FixedAssetMaterialDefinitions = null;
        public FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection FixedAssetMaterialDefinitions
        {
            get
            {
                if (_FixedAssetMaterialDefinitions == null)
                    CreateFixedAssetMaterialDefinitionsCollection();
                return _FixedAssetMaterialDefinitions;
            }
        }

        virtual protected void CreateStockReservationsCollection()
        {
            _StockReservations = new StockReservation.ChildStockReservationCollection(this, new Guid("2d36334c-d324-4656-a88b-181118634887"));
            ((ITTChildObjectCollection)_StockReservations).GetChildren();
        }

        protected StockReservation.ChildStockReservationCollection _StockReservations = null;
        public StockReservation.ChildStockReservationCollection StockReservations
        {
            get
            {
                if (_StockReservations == null)
                    CreateStockReservationsCollection();
                return _StockReservations;
            }
        }

        virtual protected void CreateStockTransactionsCollection()
        {
            _StockTransactions = new StockTransaction.ChildStockTransactionCollection(this, new Guid("8c94119d-3a3d-4a57-997d-18b2ee4cd471"));
            ((ITTChildObjectCollection)_StockTransactions).GetChildren();
        }

        protected StockTransaction.ChildStockTransactionCollection _StockTransactions = null;
        public StockTransaction.ChildStockTransactionCollection StockTransactions
        {
            get
            {
                if (_StockTransactions == null)
                    CreateStockTransactionsCollection();
                return _StockTransactions;
            }
        }

        virtual protected void CreateStockLevelsCollection()
        {
            _StockLevels = new StockLevel.ChildStockLevelCollection(this, new Guid("946fdee1-2a70-4a9c-a2ff-26784be60dc0"));
            ((ITTChildObjectCollection)_StockLevels).GetChildren();
        }

        protected StockLevel.ChildStockLevelCollection _StockLevels = null;
        public StockLevel.ChildStockLevelCollection StockLevels
        {
            get
            {
                if (_StockLevels == null)
                    CreateStockLevelsCollection();
                return _StockLevels;
            }
        }

        virtual protected void CreateStockLotDetailsCollection()
        {
            _StockLotDetails = new StockLotDetail.ChildStockLotDetailCollection(this, new Guid("31464eb8-f805-497f-9b9d-d8eb8e704bad"));
            ((ITTChildObjectCollection)_StockLotDetails).GetChildren();
        }

        protected StockLotDetail.ChildStockLotDetailCollection _StockLotDetails = null;
        public StockLotDetail.ChildStockLotDetailCollection StockLotDetails
        {
            get
            {
                if (_StockLotDetails == null)
                    CreateStockLotDetailsCollection();
                return _StockLotDetails;
            }
        }

        virtual protected void CreateStoreLocationsCollection()
        {
            _StoreLocations = new StoreLocation.ChildStoreLocationCollection(this, new Guid("cf062a0d-f36e-41c9-9da4-9f8bbfa41b3a"));
            ((ITTChildObjectCollection)_StoreLocations).GetChildren();
        }

        protected StoreLocation.ChildStoreLocationCollection _StoreLocations = null;
        public StoreLocation.ChildStoreLocationCollection StoreLocations
        {
            get
            {
                if (_StoreLocations == null)
                    CreateStoreLocationsCollection();
                return _StoreLocations;
            }
        }

        virtual protected void CreateStockPrescriptionDetailsCollection()
        {
            _StockPrescriptionDetails = new StockPrescriptionDetail.ChildStockPrescriptionDetailCollection(this, new Guid("445ae932-00e0-4cfd-8ca1-d87782b9eab8"));
            ((ITTChildObjectCollection)_StockPrescriptionDetails).GetChildren();
        }

        protected StockPrescriptionDetail.ChildStockPrescriptionDetailCollection _StockPrescriptionDetails = null;
        public StockPrescriptionDetail.ChildStockPrescriptionDetailCollection StockPrescriptionDetails
        {
            get
            {
                if (_StockPrescriptionDetails == null)
                    CreateStockPrescriptionDetailsCollection();
                return _StockPrescriptionDetails;
            }
        }

        virtual protected void CreateStockExpendableDetailsCollection()
        {
            _StockExpendableDetails = new StockExpendableDetail.ChildStockExpendableDetailCollection(this, new Guid("76659910-9b90-4229-b7a6-256140bdfb95"));
            ((ITTChildObjectCollection)_StockExpendableDetails).GetChildren();
        }

        protected StockExpendableDetail.ChildStockExpendableDetailCollection _StockExpendableDetails = null;
        public StockExpendableDetail.ChildStockExpendableDetailCollection StockExpendableDetails
        {
            get
            {
                if (_StockExpendableDetails == null)
                    CreateStockExpendableDetailsCollection();
                return _StockExpendableDetails;
            }
        }

        protected Stock(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Stock(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Stock(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Stock(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Stock(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCK", dataRow) { }
        protected Stock(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCK", dataRow, isImported) { }
        protected Stock(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Stock(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Stock() : base() { }

    }
}