
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyPanicReasonDef")] 

    /// <summary>
    /// Patoloji Panik Tanı Tanımları
    /// </summary>
    public  partial class PathologyPanicReasonDef : TerminologyManagerDef
    {
        public class PathologyPanicReasonDefList : TTObjectCollection<PathologyPanicReasonDef> { }
                    
        public class ChildPathologyPanicReasonDefCollection : TTObject.TTChildObjectCollection<PathologyPanicReasonDef>
        {
            public ChildPathologyPanicReasonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyPanicReasonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPathologyPanicReasons_Class : TTReportNqlObject 
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

            public string ReasonName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYPANICREASONDEF"].AllPropertyDefs["REASONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYPANICREASONDEF"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologyPanicReasons_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyPanicReasons_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyPanicReasons_Class() : base() { }
        }

        public static BindingList<PathologyPanicReasonDef.GetPathologyPanicReasons_Class> GetPathologyPanicReasons(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYPANICREASONDEF"].QueryDefs["GetPathologyPanicReasons"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyPanicReasonDef.GetPathologyPanicReasons_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyPanicReasonDef.GetPathologyPanicReasons_Class> GetPathologyPanicReasons(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYPANICREASONDEF"].QueryDefs["GetPathologyPanicReasons"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyPanicReasonDef.GetPathologyPanicReasons_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Panik Tanı Neden Adı
    /// </summary>
        public string ReasonName
        {
            get { return (string)this["REASONNAME"]; }
            set { this["REASONNAME"] = value; }
        }

    /// <summary>
    /// Neden Adı
    /// </summary>
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected PathologyPanicReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyPanicReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyPanicReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyPanicReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyPanicReasonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYPANICREASONDEF", dataRow) { }
        protected PathologyPanicReasonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYPANICREASONDEF", dataRow, isImported) { }
        public PathologyPanicReasonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyPanicReasonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyPanicReasonDef() : base() { }

    }
}