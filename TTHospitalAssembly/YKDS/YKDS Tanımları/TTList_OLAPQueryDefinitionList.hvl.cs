
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
    /// YKDS Sorgu Tanımları
    /// </summary>
    public partial class TTList_OLAPQueryDefinitionList : TTList
    {
        public TTList_OLAPQueryDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_OLAPQueryDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<OLAPQuery.GetOLAPQueries_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = OLAPQuery.GetOLAPQueries(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            OLAPQuery.GetOLAPQueries_Class definition = _listOfDefinition[rowIndex];
            values[2] = definition.Description;
            values[1] = definition.Caption;
            values[0] = definition.OrderNo;
            values[5] = definition.Query;
            values[4] = definition.Parentmenu;
            values[3] = definition.Cube;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(5, typeof(object));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(2, "DESCRIPTION");
            columnNames.Add(1, "CAPTION");
            columnNames.Add(0, "ORDERNO");
            columnNames.Add(5, "QUERY");
            columnNames.Add(4, "OLAPMENU.CAPTION");
            columnNames.Add(3, "OLAPCUBE.CAPTION");

            return columnNames;
        }
    }
}