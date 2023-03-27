
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
    /// Gebelik Takvimi Tanımları
    /// </summary>
    public partial class TTList_PregnancyCalendarDefinitionList : TTList
    {
        public TTList_PregnancyCalendarDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PregnancyCalendarDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.PeriodName;
            values[3] = definition.StartDate;
            values[1] = definition.FinishDate;

            if (definition.PregnancyType != null)
                values[2] = GetEnumDisplayText("PregnancyTypeEnum",(int)definition.PregnancyType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(3, typeof(int));
            columnDataTypes.Add(1, typeof(int));
            columnDataTypes.Add(2, typeof(PregnancyTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "PERIODNAME");
            columnNames.Add(3, "STARTDATE");
            columnNames.Add(1, "FINISHDATE");
            columnNames.Add(2, "PREGNANCYTYPE");

            return columnNames;
        }
    }
}