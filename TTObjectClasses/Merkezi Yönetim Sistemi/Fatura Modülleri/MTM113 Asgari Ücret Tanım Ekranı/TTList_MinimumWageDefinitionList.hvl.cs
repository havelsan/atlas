
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
    /// Asgari Ücret Tanım Ekranı
    /// </summary>
    public partial class TTList_MinimumWageDefinitionList : TTList
    {
        public TTList_MinimumWageDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MinimumWageDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MinimumWageDefinition.GetMinimumWageDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MinimumWageDefinition.GetMinimumWageDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MinimumWageDefinition.GetMinimumWageDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.GrossWage;
            values[1] = definition.Startdate;
            values[2] = definition.Enddate;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(Currency));
            columnDataTypes.Add(1, typeof(Object));
            columnDataTypes.Add(2, typeof(Object));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "GROSSWAGE");
            columnNames.Add(1, "TOSTRING(STARTDATE) STARTDATE");
            columnNames.Add(2, "TOSTRING(ENDDATE) ENDDATE");

            return columnNames;
        }
    }
}