
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
    public partial class TTList_SurfaceSupportSystemsDefList : TTList
    {
        public TTList_SurfaceSupportSystemsDefList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SurfaceSupportSystemsDefList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<SurfaceSupportSystemsDef.GetSurfaceSupportSystemDef_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = SurfaceSupportSystemsDef.GetSurfaceSupportSystemDef(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            SurfaceSupportSystemsDef.GetSurfaceSupportSystemDef_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Definition;
            values[1] = definition.PlusTenRiskChecked;
            values[2] = definition.PlusFifteenRiskChecked;
            values[3] = definition.PlusTwentyRiskChecked;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(bool));
            columnDataTypes.Add(2, typeof(bool));
            columnDataTypes.Add(3, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "THIS.DEFINITION");
            columnNames.Add(1, "THIS.PLUSTENRISKCHECKED");
            columnNames.Add(2, "THIS.PLUSFIFTEENRISKCHECKED");
            columnNames.Add(3, "THIS.PLUSTWENTYRISKCHECKED");

            return columnNames;
        }
    }
}