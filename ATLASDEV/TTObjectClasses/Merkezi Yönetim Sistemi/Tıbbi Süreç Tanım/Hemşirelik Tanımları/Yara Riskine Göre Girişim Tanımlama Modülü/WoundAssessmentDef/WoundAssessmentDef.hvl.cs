
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WoundAssessmentDef")] 

    public  partial class WoundAssessmentDef : TerminologyManagerDef
    {
        public class WoundAssessmentDefList : TTObjectCollection<WoundAssessmentDef> { }
                    
        public class ChildWoundAssessmentDefCollection : TTObject.TTChildObjectCollection<WoundAssessmentDef>
        {
            public ChildWoundAssessmentDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWoundAssessmentDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWoundAssessmentDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDASSESSMENTDEF"].AllPropertyDefs["DEFINITION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDASSESSMENTDEF"].AllPropertyDefs["PLUSTENRISKCHECKED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDASSESSMENTDEF"].AllPropertyDefs["PLUSFIFTEENRISKCHECKED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDASSESSMENTDEF"].AllPropertyDefs["PLUSTWENTYRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetWoundAssessmentDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWoundAssessmentDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWoundAssessmentDef_Class() : base() { }
        }

        public static BindingList<WoundAssessmentDef.GetWoundAssessmentDef_Class> GetWoundAssessmentDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDASSESSMENTDEF"].QueryDefs["GetWoundAssessmentDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundAssessmentDef.GetWoundAssessmentDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WoundAssessmentDef.GetWoundAssessmentDef_Class> GetWoundAssessmentDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDASSESSMENTDEF"].QueryDefs["GetWoundAssessmentDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundAssessmentDef.GetWoundAssessmentDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WoundAssessmentDef> GetWoundAssessmentDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDASSESSMENTDEF"].QueryDefs["GetWoundAssessmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<WoundAssessmentDef>(queryDef, paramList, injectionSQL);
        }

        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

        public bool? PlusTenRiskChecked
        {
            get { return (bool?)this["PLUSTENRISKCHECKED"]; }
            set { this["PLUSTENRISKCHECKED"] = value; }
        }

        public bool? PlusFifteenRiskChecked
        {
            get { return (bool?)this["PLUSFIFTEENRISKCHECKED"]; }
            set { this["PLUSFIFTEENRISKCHECKED"] = value; }
        }

        public bool? PlusTwentyRiskChecked
        {
            get { return (bool?)this["PLUSTWENTYRISKCHECKED"]; }
            set { this["PLUSTWENTYRISKCHECKED"] = value; }
        }

        protected WoundAssessmentDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WoundAssessmentDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WoundAssessmentDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WoundAssessmentDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WoundAssessmentDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WOUNDASSESSMENTDEF", dataRow) { }
        protected WoundAssessmentDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WOUNDASSESSMENTDEF", dataRow, isImported) { }
        public WoundAssessmentDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WoundAssessmentDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WoundAssessmentDef() : base() { }

    }
}