
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonForDeathDefinition")] 

    /// <summary>
    /// Ölüm Sebebi Tanımları
    /// </summary>
    public  partial class ReasonForDeathDefinition : TerminologyManagerDef
    {
        public class ReasonForDeathDefinitionList : TTObjectCollection<ReasonForDeathDefinition> { }
                    
        public class ChildReasonForDeathDefinitionCollection : TTObject.TTChildObjectCollection<ReasonForDeathDefinition>
        {
            public ChildReasonForDeathDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonForDeathDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ReasonForDeath_Class : TTReportNqlObject 
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

            public string ReasonForDeath
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORDEATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORDEATHDEFINITION"].AllPropertyDefs["REASONFORDEATH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_ReasonForDeath_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ReasonForDeath_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ReasonForDeath_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReasonForDeathDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ReasonForDeath
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORDEATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORDEATHDEFINITION"].AllPropertyDefs["REASONFORDEATH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetReasonForDeathDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReasonForDeathDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReasonForDeathDefinition_Class() : base() { }
        }

        public static BindingList<ReasonForDeathDefinition.OLAP_ReasonForDeath_Class> OLAP_ReasonForDeath(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORDEATHDEFINITION"].QueryDefs["OLAP_ReasonForDeath"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForDeathDefinition.OLAP_ReasonForDeath_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReasonForDeathDefinition.OLAP_ReasonForDeath_Class> OLAP_ReasonForDeath(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORDEATHDEFINITION"].QueryDefs["OLAP_ReasonForDeath"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForDeathDefinition.OLAP_ReasonForDeath_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReasonForDeathDefinition.GetReasonForDeathDefinition_Class> GetReasonForDeathDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORDEATHDEFINITION"].QueryDefs["GetReasonForDeathDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForDeathDefinition.GetReasonForDeathDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReasonForDeathDefinition.GetReasonForDeathDefinition_Class> GetReasonForDeathDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORDEATHDEFINITION"].QueryDefs["GetReasonForDeathDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForDeathDefinition.GetReasonForDeathDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReasonForDeathDefinition> GetReasonForDeathDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORDEATHDEFINITION"].QueryDefs["GetReasonForDeathDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ReasonForDeathDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Ölüm Sebebi
    /// </summary>
        public string ReasonForDeath
        {
            get { return (string)this["REASONFORDEATH"]; }
            set { this["REASONFORDEATH"] = value; }
        }

        protected ReasonForDeathDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonForDeathDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonForDeathDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonForDeathDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonForDeathDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONFORDEATHDEFINITION", dataRow) { }
        protected ReasonForDeathDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONFORDEATHDEFINITION", dataRow, isImported) { }
        protected ReasonForDeathDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonForDeathDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonForDeathDefinition() : base() { }

    }
}