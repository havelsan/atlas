
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="YearlyAmountRule")] 

    /// <summary>
    /// Yıllık Miktar Kuralı
    /// </summary>
    public  partial class YearlyAmountRule : AmountRuleBase
    {
        public class YearlyAmountRuleList : TTObjectCollection<YearlyAmountRule> { }
                    
        public class ChildYearlyAmountRuleCollection : TTObject.TTChildObjectCollection<YearlyAmountRule>
        {
            public ChildYearlyAmountRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildYearlyAmountRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetYearlyAmountRuleDefinitionQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["YEARLYAMOUNTRULE"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["YEARLYAMOUNTRULE"].AllPropertyDefs["RULEPRIORITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["YEARLYAMOUNTRULE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? YearCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YEARCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["YEARLYAMOUNTRULE"].AllPropertyDefs["YEARCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["YEARLYAMOUNTRULE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetYearlyAmountRuleDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetYearlyAmountRuleDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetYearlyAmountRuleDefinitionQuery_Class() : base() { }
        }

        public static BindingList<YearlyAmountRule.GetYearlyAmountRuleDefinitionQuery_Class> GetYearlyAmountRuleDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YEARLYAMOUNTRULE"].QueryDefs["GetYearlyAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<YearlyAmountRule.GetYearlyAmountRuleDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<YearlyAmountRule.GetYearlyAmountRuleDefinitionQuery_Class> GetYearlyAmountRuleDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YEARLYAMOUNTRULE"].QueryDefs["GetYearlyAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<YearlyAmountRule.GetYearlyAmountRuleDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public int? YearCount
        {
            get { return (int?)this["YEARCOUNT"]; }
            set { this["YEARCOUNT"] = value; }
        }

        protected YearlyAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected YearlyAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected YearlyAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected YearlyAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected YearlyAmountRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "YEARLYAMOUNTRULE", dataRow) { }
        protected YearlyAmountRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "YEARLYAMOUNTRULE", dataRow, isImported) { }
        public YearlyAmountRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public YearlyAmountRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public YearlyAmountRule() : base() { }

    }
}