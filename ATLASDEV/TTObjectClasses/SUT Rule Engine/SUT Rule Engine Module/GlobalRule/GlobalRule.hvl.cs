
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GlobalRule")] 

    /// <summary>
    /// Evrensel Kural
    /// </summary>
    public  partial class GlobalRule : RuleBase
    {
        public class GlobalRuleList : TTObjectCollection<GlobalRule> { }
                    
        public class ChildGlobalRuleCollection : TTObject.TTChildObjectCollection<GlobalRule>
        {
            public ChildGlobalRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGlobalRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGlobalRuleDefinitionQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLOBALRULE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RulePriorityEnum? RulePriority
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULEPRIORITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLOBALRULE"].AllPropertyDefs["RULEPRIORITY"].DataType;
                    return (RulePriorityEnum?)(int)dataType.ConvertValue(val);
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

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLOBALRULE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetGlobalRuleDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGlobalRuleDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGlobalRuleDefinitionQuery_Class() : base() { }
        }

        public static BindingList<GlobalRule.GetGlobalRuleDefinitionQuery_Class> GetGlobalRuleDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLOBALRULE"].QueryDefs["GetGlobalRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GlobalRule.GetGlobalRuleDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GlobalRule.GetGlobalRuleDefinitionQuery_Class> GetGlobalRuleDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLOBALRULE"].QueryDefs["GetGlobalRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GlobalRule.GetGlobalRuleDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected GlobalRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GlobalRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GlobalRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GlobalRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GlobalRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GLOBALRULE", dataRow) { }
        protected GlobalRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GLOBALRULE", dataRow, isImported) { }
        public GlobalRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GlobalRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GlobalRule() : base() { }

    }
}