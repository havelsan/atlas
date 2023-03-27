
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResShelf")] 

    /// <summary>
    /// Dolap rafları için tanımlar
    /// </summary>
    public  partial class ResShelf : TTDefinitionSet
    {
        public class ResShelfList : TTObjectCollection<ResShelf> { }
                    
        public class ChildResShelfCollection : TTObject.TTChildObjectCollection<ResShelf>
        {
            public ChildResShelfCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResShelfCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ShelfListDefinitionNql_Class : TTReportNqlObject 
        {
            public string ShelfName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].AllPropertyDefs["SHELFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Cabinetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CABINETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].AllPropertyDefs["NAME"].DataType;
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

            public ShelfListDefinitionNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ShelfListDefinitionNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ShelfListDefinitionNql_Class() : base() { }
        }

        public static BindingList<ResShelf.ShelfListDefinitionNql_Class> ShelfListDefinitionNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].QueryDefs["ShelfListDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResShelf.ShelfListDefinitionNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResShelf.ShelfListDefinitionNql_Class> ShelfListDefinitionNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].QueryDefs["ShelfListDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResShelf.ShelfListDefinitionNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResShelf> GetShelfListNql(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].QueryDefs["GetShelfListNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResShelf>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string ShelfName
        {
            get { return (string)this["SHELFNAME"]; }
            set { this["SHELFNAME"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Rafın dosya kapasitesi
    /// </summary>
        public int? FileCapacity
        {
            get { return (int?)this["FILECAPACITY"]; }
            set { this["FILECAPACITY"] = value; }
        }

        public ResCabinet ResCabinet
        {
            get { return (ResCabinet)((ITTObject)this).GetParent("RESCABINET"); }
            set { this["RESCABINET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResShelf(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResShelf(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResShelf(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResShelf(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResShelf(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSHELF", dataRow) { }
        protected ResShelf(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSHELF", dataRow, isImported) { }
        public ResShelf(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResShelf(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResShelf() : base() { }

    }
}