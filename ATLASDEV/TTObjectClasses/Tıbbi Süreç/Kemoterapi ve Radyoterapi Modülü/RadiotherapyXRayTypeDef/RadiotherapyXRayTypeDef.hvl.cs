
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiotherapyXRayTypeDef")] 

    public  partial class RadiotherapyXRayTypeDef : TerminologyManagerDef
    {
        public class RadiotherapyXRayTypeDefList : TTObjectCollection<RadiotherapyXRayTypeDef> { }
                    
        public class ChildRadiotherapyXRayTypeDefCollection : TTObject.TTChildObjectCollection<RadiotherapyXRayTypeDef>
        {
            public ChildRadiotherapyXRayTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiotherapyXRayTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiotherapyXRayTypeDefs_Class : TTReportNqlObject 
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOTHERAPYXRAYTYPEDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOTHERAPYXRAYTYPEDEF"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOTHERAPYXRAYTYPEDEF"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetRadiotherapyXRayTypeDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiotherapyXRayTypeDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiotherapyXRayTypeDefs_Class() : base() { }
        }

        public static BindingList<RadiotherapyXRayTypeDef.GetRadiotherapyXRayTypeDefs_Class> GetRadiotherapyXRayTypeDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOTHERAPYXRAYTYPEDEF"].QueryDefs["GetRadiotherapyXRayTypeDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiotherapyXRayTypeDef.GetRadiotherapyXRayTypeDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiotherapyXRayTypeDef.GetRadiotherapyXRayTypeDefs_Class> GetRadiotherapyXRayTypeDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOTHERAPYXRAYTYPEDEF"].QueryDefs["GetRadiotherapyXRayTypeDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiotherapyXRayTypeDef.GetRadiotherapyXRayTypeDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        protected RadiotherapyXRayTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiotherapyXRayTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiotherapyXRayTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiotherapyXRayTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiotherapyXRayTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOTHERAPYXRAYTYPEDEF", dataRow) { }
        protected RadiotherapyXRayTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOTHERAPYXRAYTYPEDEF", dataRow, isImported) { }
        public RadiotherapyXRayTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiotherapyXRayTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiotherapyXRayTypeDef() : base() { }

    }
}