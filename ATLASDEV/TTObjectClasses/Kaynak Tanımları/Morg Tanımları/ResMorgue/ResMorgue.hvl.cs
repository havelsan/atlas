
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResMorgue")] 

    /// <summary>
    /// Morg
    /// </summary>
    public  partial class ResMorgue : ResSection
    {
        public class ResMorgueList : TTObjectCollection<ResMorgue> { }
                    
        public class ChildResMorgueCollection : TTObject.TTChildObjectCollection<ResMorgue>
        {
            public ChildResMorgueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResMorgueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResMorg_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESMORGUE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESMORGUE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? Hospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOSPITAL"]);
                }
            }

            public OLAP_ResMorg_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResMorg_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResMorg_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMorgueDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESMORGUE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMorgueDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMorgueDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMorgueDefinition_Class() : base() { }
        }

        public static BindingList<ResMorgue.OLAP_ResMorg_Class> OLAP_ResMorg(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESMORGUE"].QueryDefs["OLAP_ResMorg"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResMorgue.OLAP_ResMorg_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResMorgue.OLAP_ResMorg_Class> OLAP_ResMorg(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESMORGUE"].QueryDefs["OLAP_ResMorg"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResMorgue.OLAP_ResMorg_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResMorgue.GetMorgueDefinition_Class> GetMorgueDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESMORGUE"].QueryDefs["GetMorgueDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResMorgue.GetMorgueDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResMorgue.GetMorgueDefinition_Class> GetMorgueDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESMORGUE"].QueryDefs["GetMorgueDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResMorgue.GetMorgueDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResMorgue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResMorgue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResMorgue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResMorgue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResMorgue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESMORGUE", dataRow) { }
        protected ResMorgue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESMORGUE", dataRow, isImported) { }
        public ResMorgue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResMorgue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResMorgue() : base() { }

    }
}