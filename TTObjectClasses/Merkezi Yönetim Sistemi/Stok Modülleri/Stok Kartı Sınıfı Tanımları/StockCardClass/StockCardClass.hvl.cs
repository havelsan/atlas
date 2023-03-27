
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockCardClass")] 

    /// <summary>
    /// Stok Kartı Sınıfı Tanımları
    /// </summary>
    public  partial class StockCardClass : TerminologyManagerDef, ITTListObject
    {
        public class StockCardClassList : TTObjectCollection<StockCardClass> { }
                    
        public class ChildStockCardClassCollection : TTObject.TTChildObjectCollection<StockCardClass>
        {
            public ChildStockCardClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCardClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockCardClass_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["ISGROUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["QREF"].DataType;
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

            public GetStockCardClass_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardClass_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardClass_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_StockCardClass_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentStockCardClass
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTSTOCKCARDCLASS"]);
                }
            }

            public OLAP_StockCardClass_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_StockCardClass_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_StockCardClass_Class() : base() { }
        }

        public static BindingList<StockCardClass.GetStockCardClass_Class> GetStockCardClass(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].QueryDefs["GetStockCardClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCardClass.GetStockCardClass_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockCardClass.GetStockCardClass_Class> GetStockCardClass(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].QueryDefs["GetStockCardClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCardClass.GetStockCardClass_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockCardClass.OLAP_StockCardClass_Class> OLAP_StockCardClass(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].QueryDefs["OLAP_StockCardClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCardClass.OLAP_StockCardClass_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCardClass.OLAP_StockCardClass_Class> OLAP_StockCardClass(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].QueryDefs["OLAP_StockCardClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCardClass.OLAP_StockCardClass_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCardClass> GetStockCardClassDefinitionByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].QueryDefs["GetStockCardClassDefinitionByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockCardClass>(queryDef, paramList);
        }

    /// <summary>
    /// Grup
    /// </summary>
        public bool? IsGroup
        {
            get { return (bool?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
        }

    /// <summary>
    /// Teknik Ana Sınıf Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Stok Kartı Sınıfı Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Hızlı Referans
    /// </summary>
        public string QREF
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public StockCardClass ParentStockCardClass
        {
            get { return (StockCardClass)((ITTObject)this).GetParent("PARENTSTOCKCARDCLASS"); }
            set { this["PARENTSTOCKCARDCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockCardClassesCollection()
        {
            _StockCardClasses = new StockCardClass.ChildStockCardClassCollection(this, new Guid("ff5f1b24-938c-4e5f-a1b1-3acae65a80b0"));
            ((ITTChildObjectCollection)_StockCardClasses).GetChildren();
        }

        protected StockCardClass.ChildStockCardClassCollection _StockCardClasses = null;
        public StockCardClass.ChildStockCardClassCollection StockCardClasses
        {
            get
            {
                if (_StockCardClasses == null)
                    CreateStockCardClassesCollection();
                return _StockCardClasses;
            }
        }

        virtual protected void CreateStockCensusCollection()
        {
            _StockCensus = new StockCensus.ChildStockCensusCollection(this, new Guid("775bff69-80eb-4adb-ae92-456357a9d5ce"));
            ((ITTChildObjectCollection)_StockCensus).GetChildren();
        }

        protected StockCensus.ChildStockCensusCollection _StockCensus = null;
        public StockCensus.ChildStockCensusCollection StockCensus
        {
            get
            {
                if (_StockCensus == null)
                    CreateStockCensusCollection();
                return _StockCensus;
            }
        }

        protected StockCardClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockCardClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockCardClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockCardClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockCardClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCARDCLASS", dataRow) { }
        protected StockCardClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCARDCLASS", dataRow, isImported) { }
        public StockCardClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockCardClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockCardClass() : base() { }

    }
}