
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
    /// Beklenen Fetus Gelişimi
    /// </summary>
    public partial class TTList_FetusGrowingDefinitionList : TTList
    {
        public TTList_FetusGrowingDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_FetusGrowingDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = FetusGrowingDefinition.FetusGrowingDefinitionNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.PregnancyWeek;
            values[1] = definition.Length;
            values[2] = definition.Weight;
            values[3] = definition.BiparietalDiameter;
            values[4] = definition.HeadCircumference;
            values[5] = definition.AbdominalCircumference;
            values[6] = definition.FemurLength;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(int));
            columnDataTypes.Add(2, typeof(double));
            columnDataTypes.Add(3, typeof(int));
            columnDataTypes.Add(4, typeof(int));
            columnDataTypes.Add(5, typeof(int));
            columnDataTypes.Add(6, typeof(int));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "PREGNANCYWEEK");
            columnNames.Add(1, "LENGTH");
            columnNames.Add(2, "WEIGHT");
            columnNames.Add(3, "BIPARIETALDIAMETER");
            columnNames.Add(4, "HEADCIRCUMFERENCE");
            columnNames.Add(5, "ABDOMINALCIRCUMFERENCE");
            columnNames.Add(6, "FEMURLENGTH");

            return columnNames;
        }
    }
}