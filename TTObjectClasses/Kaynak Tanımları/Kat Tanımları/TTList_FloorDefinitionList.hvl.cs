
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
    /// Kat Tanımları
    /// </summary>
    public partial class TTList_FloorDefinitionList : TTList
    {
        public TTList_FloorDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_FloorDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ResFloor.GetFloorDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ResFloor.GetFloorDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ResFloor.GetFloorDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;
            values[4] = definition.IsActive;
            values[2] = definition.FloorNumber;
            values[1] = definition.Buildingname;
            values[3] = definition.Wingname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(4, typeof(Boolean));
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "THIS.NAME");
            columnNames.Add(4, "THIS.ISACTIVE");
            columnNames.Add(2, "THIS.FLOORNUMBER");
            columnNames.Add(1, "THIS.RESBUILDING.NAME");
            columnNames.Add(3, "THIS.RESBUILDINGWING.NAME");

            return columnNames;
        }
    }
}