
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
    /// <summary>
    /// Aylık Miktar Kural Tanımları
    /// </summary>
    public partial class TTList_MonthlyAmountRuleDefinitionList : TTList
    {
        public TTList_MonthlyAmountRuleDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MonthlyAmountRuleDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MonthlyAmountRule.GetMonthlyAmountRuleDefinitionQuery_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MonthlyAmountRule.GetMonthlyAmountRuleDefinitionQuery(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MonthlyAmountRule.GetMonthlyAmountRuleDefinitionQuery_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;

            if (definition.RulePriority != null)
                values[2] = GetEnumDisplayText("RulePriorityEnum",(int)definition.RulePriority);
            values[1] = definition.Amount;
            values[3] = definition.MonthCount;
            values[5] = definition.IsActive;
            values[4] = definition.Result;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(RulePriorityEnum));
            columnDataTypes.Add(1, typeof(int));
            columnDataTypes.Add(3, typeof(int));
            columnDataTypes.Add(5, typeof(Boolean));
            columnDataTypes.Add(4, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "NAME");
            columnNames.Add(2, "RULEPRIORITY");
            columnNames.Add(1, "AMOUNT");
            columnNames.Add(3, "MONTHCOUNT");
            columnNames.Add(5, "ISACTIVE");
            columnNames.Add(4, "RESULT");

            return columnNames;
        }
    }
}