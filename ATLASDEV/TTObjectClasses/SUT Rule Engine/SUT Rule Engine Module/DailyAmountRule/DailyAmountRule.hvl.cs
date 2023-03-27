
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyAmountRule")] 

    /// <summary>
    /// Günlük Miktar Kuralı
    /// </summary>
    public  partial class DailyAmountRule : AmountRuleBase
    {
        public class DailyAmountRuleList : TTObjectCollection<DailyAmountRule> { }
                    
        public class ChildDailyAmountRuleCollection : TTObject.TTChildObjectCollection<DailyAmountRule>
        {
            public ChildDailyAmountRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyAmountRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDailyAmountRuleDefinitionQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYAMOUNTRULE"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYAMOUNTRULE"].AllPropertyDefs["RULEPRIORITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYAMOUNTRULE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? DayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYAMOUNTRULE"].AllPropertyDefs["DAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYAMOUNTRULE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDailyAmountRuleDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDailyAmountRuleDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDailyAmountRuleDefinitionQuery_Class() : base() { }
        }

        public static BindingList<DailyAmountRule.GetDailyAmountRuleDefinitionQuery_Class> GetDailyAmountRuleDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYAMOUNTRULE"].QueryDefs["GetDailyAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DailyAmountRule.GetDailyAmountRuleDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DailyAmountRule.GetDailyAmountRuleDefinitionQuery_Class> GetDailyAmountRuleDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYAMOUNTRULE"].QueryDefs["GetDailyAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DailyAmountRule.GetDailyAmountRuleDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Gün
    /// </summary>
        public int? DayCount
        {
            get { return (int?)this["DAYCOUNT"]; }
            set { this["DAYCOUNT"] = value; }
        }

        protected DailyAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyAmountRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYAMOUNTRULE", dataRow) { }
        protected DailyAmountRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYAMOUNTRULE", dataRow, isImported) { }
        public DailyAmountRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyAmountRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyAmountRule() : base() { }

    }
}