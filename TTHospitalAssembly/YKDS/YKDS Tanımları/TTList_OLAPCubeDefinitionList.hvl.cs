
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
    /// YKDS Küp Tanımları
    /// </summary>
    public partial class TTList_OLAPCubeDefinitionList : TTList
    {
        public TTList_OLAPCubeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_OLAPCubeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<OLAPCube.GetOLAPCubes_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = OLAPCube.GetOLAPCubes(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            OLAPCube.GetOLAPCubes_Class definition = _listOfDefinition[rowIndex];
            values[2] = definition.Caption;
            values[3] = definition.Description;
            values[1] = definition.Name;
            values[0] = definition.OrderNO;
            values[4] = definition.Parentmenu;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(4, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(2, "CAPTION");
            columnNames.Add(3, "DESCRIPTION");
            columnNames.Add(1, "NAME");
            columnNames.Add(0, "ORDERNO");
            columnNames.Add(4, "OLAPMENU.CAPTION");

            return columnNames;
        }
    }
}