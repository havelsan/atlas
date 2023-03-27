
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EducationDef")] 

    public  partial class EducationDef : TerminologyManagerDef
    {
        public class EducationDefList : TTObjectCollection<EducationDef> { }
                    
        public class ChildEducationDefCollection : TTObject.TTChildObjectCollection<EducationDef>
        {
            public ChildEducationDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEducationDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEducationApproachDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONDEF"].AllPropertyDefs["DEFINITION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONDEF"].AllPropertyDefs["PLUSTENRISKCHECKED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONDEF"].AllPropertyDefs["PLUSFIFTEENRISKCHECKED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONDEF"].AllPropertyDefs["PLUSTWENTYRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetEducationApproachDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEducationApproachDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEducationApproachDef_Class() : base() { }
        }

        public static BindingList<EducationDef.GetEducationApproachDef_Class> GetEducationApproachDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONDEF"].QueryDefs["GetEducationApproachDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EducationDef.GetEducationApproachDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EducationDef.GetEducationApproachDef_Class> GetEducationApproachDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONDEF"].QueryDefs["GetEducationApproachDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EducationDef.GetEducationApproachDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EducationDef> GetEducationApproachDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONDEF"].QueryDefs["GetEducationApproachDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<EducationDef>(queryDef, paramList, injectionSQL);
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

        protected EducationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EducationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EducationDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EducationDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EducationDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EDUCATIONDEF", dataRow) { }
        protected EducationDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EDUCATIONDEF", dataRow, isImported) { }
        public EducationDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EducationDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EducationDef() : base() { }

    }
}