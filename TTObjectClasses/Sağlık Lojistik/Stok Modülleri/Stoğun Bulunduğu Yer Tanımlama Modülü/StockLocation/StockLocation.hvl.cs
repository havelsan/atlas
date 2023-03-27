
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockLocation")] 

    /// <summary>
    /// Malzemenin Bulunduğu Yer Tanımları
    /// </summary>
    public  partial class StockLocation : TTObject
    {
        public class StockLocationList : TTObjectCollection<StockLocation> { }
                    
        public class ChildStockLocationCollection : TTObject.TTChildObjectCollection<StockLocation>
        {
            public ChildStockLocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockLocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockLocation_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLOCATION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLOCATION"].AllPropertyDefs["ISGROUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Parentstocklocationname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTSTOCKLOCATIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLOCATION"].AllPropertyDefs["NAME"].DataType;
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

            public GetStockLocation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockLocation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockLocation_Class() : base() { }
        }

        public static BindingList<StockLocation.GetStockLocation_Class> GetStockLocation(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKLOCATION"].QueryDefs["GetStockLocation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockLocation.GetStockLocation_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockLocation.GetStockLocation_Class> GetStockLocation(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKLOCATION"].QueryDefs["GetStockLocation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockLocation.GetStockLocation_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Ana Grup
    /// </summary>
        public bool? IsGroup
        {
            get { return (bool?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Stock Location Tree Relation
    /// </summary>
        public StockLocation ParentStockLocation
        {
            get { return (StockLocation)((ITTObject)this).GetParent("PARENTSTOCKLOCATION"); }
            set { this["PARENTSTOCKLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockLocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockLocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockLocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKLOCATION", dataRow) { }
        protected StockLocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKLOCATION", dataRow, isImported) { }
        public StockLocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockLocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockLocation() : base() { }

    }
}