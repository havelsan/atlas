
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyJarTypeDef")] 

    /// <summary>
    /// Patoloji Kavanoz Tipi Tanımları
    /// </summary>
    public  partial class PathologyJarTypeDef : TerminologyManagerDef
    {
        public class PathologyJarTypeDefList : TTObjectCollection<PathologyJarTypeDef> { }
                    
        public class ChildPathologyJarTypeDefCollection : TTObject.TTChildObjectCollection<PathologyJarTypeDef>
        {
            public ChildPathologyJarTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyJarTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPathologyJarTypes_Class : TTReportNqlObject 
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

            public string JarType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JARTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYJARTYPEDEF"].AllPropertyDefs["JARTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYJARTYPEDEF"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologyJarTypes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyJarTypes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyJarTypes_Class() : base() { }
        }

        public static BindingList<PathologyJarTypeDef.GetPathologyJarTypes_Class> GetPathologyJarTypes(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYJARTYPEDEF"].QueryDefs["GetPathologyJarTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyJarTypeDef.GetPathologyJarTypes_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyJarTypeDef.GetPathologyJarTypes_Class> GetPathologyJarTypes(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYJARTYPEDEF"].QueryDefs["GetPathologyJarTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyJarTypeDef.GetPathologyJarTypes_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kavanoz Tipi
    /// </summary>
        public string JarType
        {
            get { return (string)this["JARTYPE"]; }
            set { this["JARTYPE"] = value; }
        }

    /// <summary>
    /// Kavanoz Tipi Adı
    /// </summary>
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected PathologyJarTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyJarTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyJarTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyJarTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyJarTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYJARTYPEDEF", dataRow) { }
        protected PathologyJarTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYJARTYPEDEF", dataRow, isImported) { }
        public PathologyJarTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyJarTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyJarTypeDef() : base() { }

    }
}