
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
    /// Diyet Öğünlerinin Hastalara Verilme Saatleri
    /// </summary>
    public partial class TTList_MealTypeTimeDefinitionDefinitionList : TTList
    {
        public TTList_MealTypeTimeDefinitionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MealTypeTimeDefinitionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MealTypeTimeDefinition.GetMealTypeTimeDefinitionList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MealTypeTimeDefinition.GetMealTypeTimeDefinitionList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MealTypeTimeDefinition.GetMealTypeTimeDefinitionList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Breakfast;
            values[1] = definition.Lunch;
            values[2] = definition.Dinner;
            values[3] = definition.NightBreakfast;
            values[4] = definition.Snack1;
            values[5] = definition.Snack2;
            values[6] = definition.Snack3;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(DateTime));
            columnDataTypes.Add(1, typeof(DateTime));
            columnDataTypes.Add(2, typeof(DateTime));
            columnDataTypes.Add(3, typeof(DateTime));
            columnDataTypes.Add(4, typeof(DateTime));
            columnDataTypes.Add(5, typeof(DateTime));
            columnDataTypes.Add(6, typeof(DateTime));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "BREAKFAST");
            columnNames.Add(1, "LUNCH");
            columnNames.Add(2, "DINNER");
            columnNames.Add(3, "NIGHTBREAKFAST");
            columnNames.Add(4, "SNACK1");
            columnNames.Add(5, "SNACK2");
            columnNames.Add(6, "SNACK3");

            return columnNames;
        }
    }
}