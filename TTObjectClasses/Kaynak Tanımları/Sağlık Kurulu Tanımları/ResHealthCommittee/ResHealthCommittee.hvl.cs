
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResHealthCommittee")] 

    /// <summary>
    /// Sağlık Kurulu
    /// </summary>
    public  partial class ResHealthCommittee : ResSection
    {
        public class ResHealthCommitteeList : TTObjectCollection<ResHealthCommittee> { }
                    
        public class ChildResHealthCommitteeCollection : TTObject.TTChildObjectCollection<ResHealthCommittee>
        {
            public ChildResHealthCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResHealthCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResHealthCommittee_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_ResHealthCommittee_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResHealthCommittee_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResHealthCommittee_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveResHCs_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveResHCs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveResHCs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveResHCs_Class() : base() { }
        }

        public static BindingList<ResHealthCommittee.OLAP_ResHealthCommittee_Class> OLAP_ResHealthCommittee(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].QueryDefs["OLAP_ResHealthCommittee"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHealthCommittee.OLAP_ResHealthCommittee_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResHealthCommittee.OLAP_ResHealthCommittee_Class> OLAP_ResHealthCommittee(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].QueryDefs["OLAP_ResHealthCommittee"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHealthCommittee.OLAP_ResHealthCommittee_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResHealthCommittee.GetActiveResHCs_Class> GetActiveResHCs(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].QueryDefs["GetActiveResHCs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHealthCommittee.GetActiveResHCs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResHealthCommittee.GetActiveResHCs_Class> GetActiveResHCs(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHEALTHCOMMITTEE"].QueryDefs["GetActiveResHCs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHealthCommittee.GetActiveResHCs_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResHealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResHealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResHealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResHealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResHealthCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESHEALTHCOMMITTEE", dataRow) { }
        protected ResHealthCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESHEALTHCOMMITTEE", dataRow, isImported) { }
        public ResHealthCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResHealthCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResHealthCommittee() : base() { }

    }
}