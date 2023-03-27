
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockLevelType")] 

    /// <summary>
    /// Malzeme Durumu
    /// </summary>
    public  partial class StockLevelType : TerminologyManagerDef
    {
        public class StockLevelTypeList : TTObjectCollection<StockLevelType> { }
                    
        public class ChildStockLevelTypeCollection : TTObject.TTChildObjectCollection<StockLevelType>
        {
            public ChildStockLevelTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockLevelTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockLevelTypeList_Class : TTReportNqlObject 
        {
            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetStockLevelTypeList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockLevelTypeList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockLevelTypeList_Class() : base() { }
        }

        public static BindingList<StockLevelType.GetStockLevelTypeList_Class> GetStockLevelTypeList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].QueryDefs["GetStockLevelTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockLevelType.GetStockLevelTypeList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockLevelType.GetStockLevelTypeList_Class> GetStockLevelTypeList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].QueryDefs["GetStockLevelTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockLevelType.GetStockLevelTypeList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockLevelType> GetStockLevelType(TTObjectContext objectContext, StockLevelTypeEnum STOCKLEVELTYPESTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].QueryDefs["GetStockLevelType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKLEVELTYPESTATUS", (int)STOCKLEVELTYPESTATUS);

            return ((ITTQuery)objectContext).QueryObjects<StockLevelType>(queryDef, paramList);
        }

        public static BindingList<StockLevelType> GetStockLevelTypeDefByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].QueryDefs["GetStockLevelTypeDefByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockLevelType>(queryDef, paramList);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Malın Durumu
    /// </summary>
        public StockLevelTypeEnum? StockLevelTypeStatus
        {
            get { return (StockLevelTypeEnum?)(int?)this["STOCKLEVELTYPESTATUS"]; }
            set { this["STOCKLEVELTYPESTATUS"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

        public StockLevelType ParentLevel
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("PARENTLEVEL"); }
            set { this["PARENTLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockLevelType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockLevelType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockLevelType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockLevelType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockLevelType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKLEVELTYPE", dataRow) { }
        protected StockLevelType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKLEVELTYPE", dataRow, isImported) { }
        public StockLevelType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockLevelType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockLevelType() : base() { }

    }
}