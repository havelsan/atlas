
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
    /// Anestezi Doktor Tescil No Listesi
    /// </summary>
    public partial class TTList_AnesteziDoktorTescilNoDefinitionList : TTList
    {
        public TTList_AnesteziDoktorTescilNoDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_AnesteziDoktorTescilNoDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<AnesteziDoktorTescilNo.GetAnesteziDoktorTescilNoDefinitionQuery_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = AnesteziDoktorTescilNo.GetAnesteziDoktorTescilNoDefinitionQuery(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            AnesteziDoktorTescilNo.GetAnesteziDoktorTescilNoDefinitionQuery_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.anesteziDoktorTescilNo;
            values[1] = definition.anesteziDoktorAdi;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "ANESTEZIDOKTORTESCILNO");
            columnNames.Add(1, "ANESTEZIDOKTORADI");

            return columnNames;
        }
    }
}