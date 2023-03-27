
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResQuarantine")] 

    /// <summary>
    /// Karantina
    /// </summary>
    public  partial class ResQuarantine : ResSection
    {
        public class ResQuarantineList : TTObjectCollection<ResQuarantine> { }
                    
        public class ChildResQuarantineCollection : TTObject.TTChildObjectCollection<ResQuarantine>
        {
            public ChildResQuarantineCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResQuarantineCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResQuarantine_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESQUARANTINE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESQUARANTINE"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_ResQuarantine_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResQuarantine_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResQuarantine_Class() : base() { }
        }

        public static BindingList<ResQuarantine.OLAP_ResQuarantine_Class> OLAP_ResQuarantine(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESQUARANTINE"].QueryDefs["OLAP_ResQuarantine"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResQuarantine.OLAP_ResQuarantine_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResQuarantine.OLAP_ResQuarantine_Class> OLAP_ResQuarantine(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESQUARANTINE"].QueryDefs["OLAP_ResQuarantine"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResQuarantine.OLAP_ResQuarantine_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResQuarantine> GetActiveQuarantines(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESQUARANTINE"].QueryDefs["GetActiveQuarantines"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResQuarantine>(queryDef, paramList);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResQuarantine(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResQuarantine(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResQuarantine(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResQuarantine(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResQuarantine(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESQUARANTINE", dataRow) { }
        protected ResQuarantine(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESQUARANTINE", dataRow, isImported) { }
        public ResQuarantine(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResQuarantine(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResQuarantine() : base() { }

    }
}