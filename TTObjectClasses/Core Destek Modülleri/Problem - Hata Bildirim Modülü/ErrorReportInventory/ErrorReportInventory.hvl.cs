
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ErrorReportInventory")] 

    /// <summary>
    /// Problem / Hata Envanter Tanımı
    /// </summary>
    public  partial class ErrorReportInventory : TTDefinitionSet
    {
        public class ErrorReportInventoryList : TTObjectCollection<ErrorReportInventory> { }
                    
        public class ChildErrorReportInventoryCollection : TTObject.TTChildObjectCollection<ErrorReportInventory>
        {
            public ChildErrorReportInventoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildErrorReportInventoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetErrorReportInventoryListQuery_Class : TTReportNqlObject 
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

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public int? No
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTINVENTORY"].AllPropertyDefs["NO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTINVENTORY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Details
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTINVENTORY"].AllPropertyDefs["DETAILS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetErrorReportInventoryListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetErrorReportInventoryListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetErrorReportInventoryListQuery_Class() : base() { }
        }

    /// <summary>
    /// Problem Hata Envanter Listesi Sorgusu
    /// </summary>
        public static BindingList<ErrorReportInventory.GetErrorReportInventoryListQuery_Class> GetErrorReportInventoryListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTINVENTORY"].QueryDefs["GetErrorReportInventoryListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ErrorReportInventory.GetErrorReportInventoryListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Problem Hata Envanter Listesi Sorgusu
    /// </summary>
        public static BindingList<ErrorReportInventory.GetErrorReportInventoryListQuery_Class> GetErrorReportInventoryListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTINVENTORY"].QueryDefs["GetErrorReportInventoryListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ErrorReportInventory.GetErrorReportInventoryListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Envanter Nu
    /// </summary>
        public int? No
        {
            get { return (int?)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Envanter Tanımı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Envanter Açıklaması
    /// </summary>
        public string Details
        {
            get { return (string)this["DETAILS"]; }
            set { this["DETAILS"] = value; }
        }

        protected ErrorReportInventory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ErrorReportInventory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ErrorReportInventory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ErrorReportInventory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ErrorReportInventory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ERRORREPORTINVENTORY", dataRow) { }
        protected ErrorReportInventory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ERRORREPORTINVENTORY", dataRow, isImported) { }
        public ErrorReportInventory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ErrorReportInventory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ErrorReportInventory() : base() { }

    }
}