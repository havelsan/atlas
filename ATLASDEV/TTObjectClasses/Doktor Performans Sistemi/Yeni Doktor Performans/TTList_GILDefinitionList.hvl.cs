
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
    /// Girişimsel İşlem Listesi
    /// </summary>
    public partial class TTList_GILDefinitionList : TTList
    {
        public TTList_GILDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_GILDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<GILDefinition.GetGILDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = GILDefinition.GetGILDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            GILDefinition.GetGILDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.Name;
            values[0] = definition.Code;
            values[2] = definition.Point;
            values[4] = definition.Description;
            values[3] = definition.SurgeryGroup;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "NAME");
            columnNames.Add(0, "CODE");
            columnNames.Add(2, "POINT");
            columnNames.Add(4, "DESCRIPTION");
            columnNames.Add(3, "SURGERYGROUP");

            return columnNames;
        }
    }
}