
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonForPathologyRejection")] 

    /// <summary>
    /// Patoloji Red Sebebi
    /// </summary>
    public  partial class ReasonForPathologyRejection : TTDefinitionSet
    {
        public class ReasonForPathologyRejectionList : TTObjectCollection<ReasonForPathologyRejection> { }
                    
        public class ChildReasonForPathologyRejectionCollection : TTObject.TTChildObjectCollection<ReasonForPathologyRejection>
        {
            public ChildReasonForPathologyRejectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonForPathologyRejectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologyRejectReasonDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORPATHOLOGYREJECTION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORPATHOLOGYREJECTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public PathologyRejectReasonDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyRejectReasonDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyRejectReasonDefFormNQL_Class() : base() { }
        }

        public static BindingList<ReasonForPathologyRejection> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORPATHOLOGYREJECTION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ReasonForPathologyRejection>(queryDef, paramList);
        }

        public static BindingList<ReasonForPathologyRejection.PathologyRejectReasonDefFormNQL_Class> PathologyRejectReasonDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORPATHOLOGYREJECTION"].QueryDefs["PathologyRejectReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForPathologyRejection.PathologyRejectReasonDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReasonForPathologyRejection.PathologyRejectReasonDefFormNQL_Class> PathologyRejectReasonDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORPATHOLOGYREJECTION"].QueryDefs["PathologyRejectReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForPathologyRejection.PathologyRejectReasonDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected ReasonForPathologyRejection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonForPathologyRejection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonForPathologyRejection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonForPathologyRejection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonForPathologyRejection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONFORPATHOLOGYREJECTION", dataRow) { }
        protected ReasonForPathologyRejection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONFORPATHOLOGYREJECTION", dataRow, isImported) { }
        public ReasonForPathologyRejection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonForPathologyRejection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonForPathologyRejection() : base() { }

    }
}