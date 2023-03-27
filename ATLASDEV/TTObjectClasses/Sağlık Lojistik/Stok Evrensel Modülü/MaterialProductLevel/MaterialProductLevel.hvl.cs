
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialProductLevel")] 

    public  partial class MaterialProductLevel : TTDefinitionSet
    {
        public class MaterialProductLevelList : TTObjectCollection<MaterialProductLevel> { }
                    
        public class ChildMaterialProductLevelCollection : TTObject.TTChildObjectCollection<MaterialProductLevel>
        {
            public ChildMaterialProductLevelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialProductLevelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class NonBarcodeMatchQuery_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Guid? MatchReason
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATCHREASON"]);
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

            public NonBarcodeMatchQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NonBarcodeMatchQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NonBarcodeMatchQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class DoubleMatchProductQuery_Class : TTReportNqlObject 
        {
            public Guid? Product
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRODUCT"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
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

            public DoubleMatchProductQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DoubleMatchProductQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DoubleMatchProductQuery_Class() : base() { }
        }

        public static BindingList<MaterialProductLevel.NonBarcodeMatchQuery_Class> NonBarcodeMatchQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRODUCTLEVEL"].QueryDefs["NonBarcodeMatchQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialProductLevel.NonBarcodeMatchQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialProductLevel.NonBarcodeMatchQuery_Class> NonBarcodeMatchQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRODUCTLEVEL"].QueryDefs["NonBarcodeMatchQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialProductLevel.NonBarcodeMatchQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaterialProductLevel.DoubleMatchProductQuery_Class> DoubleMatchProductQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRODUCTLEVEL"].QueryDefs["DoubleMatchProductQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialProductLevel.DoubleMatchProductQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialProductLevel.DoubleMatchProductQuery_Class> DoubleMatchProductQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRODUCTLEVEL"].QueryDefs["DoubleMatchProductQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialProductLevel.DoubleMatchProductQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// TITUBB'da Bulunmayan Barkod
    /// </summary>
        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

        public ProductDefinition Product
        {
            get { return (ProductDefinition)((ITTObject)this).GetParent("PRODUCT"); }
            set { this["PRODUCT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MatchReasonDefinition MatchReason
        {
            get { return (MatchReasonDefinition)((ITTObject)this).GetParent("MATCHREASON"); }
            set { this["MATCHREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialProductLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialProductLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialProductLevel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialProductLevel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialProductLevel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALPRODUCTLEVEL", dataRow) { }
        protected MaterialProductLevel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALPRODUCTLEVEL", dataRow, isImported) { }
        public MaterialProductLevel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialProductLevel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialProductLevel() : base() { }

    }
}