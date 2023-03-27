
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PreventionAndMonitoringPlanDef")] 

    public  partial class PreventionAndMonitoringPlanDef : TerminologyManagerDef
    {
        public class PreventionAndMonitoringPlanDefList : TTObjectCollection<PreventionAndMonitoringPlanDef> { }
                    
        public class ChildPreventionAndMonitoringPlanDefCollection : TTObject.TTChildObjectCollection<PreventionAndMonitoringPlanDef>
        {
            public ChildPreventionAndMonitoringPlanDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPreventionAndMonitoringPlanDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPreventionAndMonitoringPlanDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Definition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREVENTIONANDMONITORINGPLANDEF"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? PlusTenRiskChecked
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLUSTENRISKCHECKED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREVENTIONANDMONITORINGPLANDEF"].AllPropertyDefs["PLUSTENRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PlusFifteenRiskChecked
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLUSFIFTEENRISKCHECKED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREVENTIONANDMONITORINGPLANDEF"].AllPropertyDefs["PLUSFIFTEENRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PlusTwentyRiskChecked
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLUSTWENTYRISKCHECKED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREVENTIONANDMONITORINGPLANDEF"].AllPropertyDefs["PLUSTWENTYRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPreventionAndMonitoringPlanDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPreventionAndMonitoringPlanDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPreventionAndMonitoringPlanDef_Class() : base() { }
        }

        public static BindingList<PreventionAndMonitoringPlanDef> GetPreventionAndMonitoringPlanDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREVENTIONANDMONITORINGPLANDEF"].QueryDefs["GetPreventionAndMonitoringPlanDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PreventionAndMonitoringPlanDef>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PreventionAndMonitoringPlanDef.GetPreventionAndMonitoringPlanDef_Class> GetPreventionAndMonitoringPlanDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREVENTIONANDMONITORINGPLANDEF"].QueryDefs["GetPreventionAndMonitoringPlanDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PreventionAndMonitoringPlanDef.GetPreventionAndMonitoringPlanDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PreventionAndMonitoringPlanDef.GetPreventionAndMonitoringPlanDef_Class> GetPreventionAndMonitoringPlanDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREVENTIONANDMONITORINGPLANDEF"].QueryDefs["GetPreventionAndMonitoringPlanDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PreventionAndMonitoringPlanDef.GetPreventionAndMonitoringPlanDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Plan Tanımı
    /// </summary>
        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

    /// <summary>
    /// 10 Üzeri Risk İçin Geçerli
    /// </summary>
        public bool? PlusTenRiskChecked
        {
            get { return (bool?)this["PLUSTENRISKCHECKED"]; }
            set { this["PLUSTENRISKCHECKED"] = value; }
        }

    /// <summary>
    /// 15 Üzeri Risk İçin Geçerli
    /// </summary>
        public bool? PlusFifteenRiskChecked
        {
            get { return (bool?)this["PLUSFIFTEENRISKCHECKED"]; }
            set { this["PLUSFIFTEENRISKCHECKED"] = value; }
        }

    /// <summary>
    /// 20 Üzeri Risk İçin Geçerli
    /// </summary>
        public bool? PlusTwentyRiskChecked
        {
            get { return (bool?)this["PLUSTWENTYRISKCHECKED"]; }
            set { this["PLUSTWENTYRISKCHECKED"] = value; }
        }

        protected PreventionAndMonitoringPlanDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PreventionAndMonitoringPlanDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PreventionAndMonitoringPlanDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PreventionAndMonitoringPlanDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PreventionAndMonitoringPlanDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREVENTIONANDMONITORINGPLANDEF", dataRow) { }
        protected PreventionAndMonitoringPlanDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREVENTIONANDMONITORINGPLANDEF", dataRow, isImported) { }
        public PreventionAndMonitoringPlanDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PreventionAndMonitoringPlanDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PreventionAndMonitoringPlanDef() : base() { }

    }
}