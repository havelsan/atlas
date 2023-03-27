
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MonthlyAmountRule")] 

    /// <summary>
    /// Aylık Miktar Kuralı
    /// </summary>
    public  partial class MonthlyAmountRule : AmountRuleBase
    {
        public class MonthlyAmountRuleList : TTObjectCollection<MonthlyAmountRule> { }
                    
        public class ChildMonthlyAmountRuleCollection : TTObject.TTChildObjectCollection<MonthlyAmountRule>
        {
            public ChildMonthlyAmountRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMonthlyAmountRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMonthlyAmountRuleDefinitionQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MONTHLYAMOUNTRULE"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MONTHLYAMOUNTRULE"].AllPropertyDefs["RULEPRIORITY"].DataType;
                    return (RulePriorityEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MONTHLYAMOUNTRULE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MonthCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONTHCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MONTHLYAMOUNTRULE"].AllPropertyDefs["MONTHCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MONTHLYAMOUNTRULE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMonthlyAmountRuleDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMonthlyAmountRuleDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMonthlyAmountRuleDefinitionQuery_Class() : base() { }
        }

        public static BindingList<MonthlyAmountRule.GetMonthlyAmountRuleDefinitionQuery_Class> GetMonthlyAmountRuleDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MONTHLYAMOUNTRULE"].QueryDefs["GetMonthlyAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MonthlyAmountRule.GetMonthlyAmountRuleDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MonthlyAmountRule.GetMonthlyAmountRuleDefinitionQuery_Class> GetMonthlyAmountRuleDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MONTHLYAMOUNTRULE"].QueryDefs["GetMonthlyAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MonthlyAmountRule.GetMonthlyAmountRuleDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Ay
    /// </summary>
        public int? MonthCount
        {
            get { return (int?)this["MONTHCOUNT"]; }
            set { this["MONTHCOUNT"] = value; }
        }

        protected MonthlyAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MonthlyAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MonthlyAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MonthlyAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MonthlyAmountRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MONTHLYAMOUNTRULE", dataRow) { }
        protected MonthlyAmountRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MONTHLYAMOUNTRULE", dataRow, isImported) { }
        public MonthlyAmountRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MonthlyAmountRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MonthlyAmountRule() : base() { }

    }
}