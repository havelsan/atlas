
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
    /// Evrensel Kural Tanımları
    /// </summary>
    public partial class TTList_GlobalRuleDefinitionList : TTList
    {
        public TTList_GlobalRuleDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_GlobalRuleDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<GlobalRule.GetGlobalRuleDefinitionQuery_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = GlobalRule.GetGlobalRuleDefinitionQuery(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            GlobalRule.GetGlobalRuleDefinitionQuery_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;

            if (definition.RulePriority != null)
                values[1] = GetEnumDisplayText("RulePriorityEnum",(int)definition.RulePriority);
            values[3] = definition.IsActive;
            values[2] = definition.Result;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(RulePriorityEnum));
            columnDataTypes.Add(3, typeof(Boolean));
            columnDataTypes.Add(2, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "NAME");
            columnNames.Add(1, "RULEPRIORITY");
            columnNames.Add(3, "ISACTIVE");
            columnNames.Add(2, "RESULT");

            return columnNames;
        }
    }
}