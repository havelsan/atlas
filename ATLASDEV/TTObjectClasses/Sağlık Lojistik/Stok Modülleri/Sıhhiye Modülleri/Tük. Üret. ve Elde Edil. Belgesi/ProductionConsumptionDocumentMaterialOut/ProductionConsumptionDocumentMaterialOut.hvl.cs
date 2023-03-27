
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductionConsumptionDocumentMaterialOut")] 

    /// <summary>
    /// Sarf İmal İstihsal Belgesi Sarf Edilen malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ProductionConsumptionDocumentMaterialOut : StockActionDetailOut
    {
        public class ProductionConsumptionDocumentMaterialOutList : TTObjectCollection<ProductionConsumptionDocumentMaterialOut> { }
                    
        public class ChildProductionConsumptionDocumentMaterialOutCollection : TTObject.TTChildObjectCollection<ProductionConsumptionDocumentMaterialOut>
        {
            public ChildProductionConsumptionDocumentMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductionConsumptionDocumentMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ConsumableMaterialOutQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockacardid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACARDID"]);
                }
            }

            public string Nsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSN"]);
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

            public string Storeqref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOREQREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ConsumableMaterialOutQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsumableMaterialOutQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsumableMaterialOutQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalConsumptionByYear_Class : TTReportNqlObject 
        {
            public Object Consumabelamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONSUMABELAMOUNT"]);
                }
            }

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public GetTotalConsumptionByYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalConsumptionByYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalConsumptionByYear_Class() : base() { }
        }

        public static BindingList<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class> ConsumableMaterialOutQuery(string STOCKCARDCLASSID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONDOCUMENTMATERIALOUT"].QueryDefs["ConsumableMaterialOutQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class> ConsumableMaterialOutQuery(TTObjectContext objectContext, string STOCKCARDCLASSID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONDOCUMENTMATERIALOUT"].QueryDefs["ConsumableMaterialOutQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear_Class> GetTotalConsumptionByYear(string STOREID, string STOCKCARDCLASSID, string STOCKCARDID, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONDOCUMENTMATERIALOUT"].QueryDefs["GetTotalConsumptionByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear_Class> GetTotalConsumptionByYear(TTObjectContext objectContext, string STOREID, string STOCKCARDCLASSID, string STOCKCARDID, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONDOCUMENTMATERIALOUT"].QueryDefs["GetTotalConsumptionByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear_Class>(objectContext, queryDef, paramList, pi);
        }

        protected ProductionConsumptionDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductionConsumptionDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductionConsumptionDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductionConsumptionDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductionConsumptionDocumentMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTIONCONSUMPTIONDOCUMENTMATERIALOUT", dataRow) { }
        protected ProductionConsumptionDocumentMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTIONCONSUMPTIONDOCUMENTMATERIALOUT", dataRow, isImported) { }
        public ProductionConsumptionDocumentMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductionConsumptionDocumentMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductionConsumptionDocumentMaterialOut() : base() { }

    }
}