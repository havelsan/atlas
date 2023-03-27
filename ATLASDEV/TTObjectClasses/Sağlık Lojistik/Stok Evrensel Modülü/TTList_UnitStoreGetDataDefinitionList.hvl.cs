
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
    /// MKYS Birim Depolar
    /// </summary>
    public partial class TTList_UnitStoreGetDataDefinitionList : TTList
    {
        public TTList_UnitStoreGetDataDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_UnitStoreGetDataDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<UnitStoreGetData.GetUnitStoreGetDataList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = UnitStoreGetData.GetUnitStoreGetDataList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            UnitStoreGetData.GetUnitStoreGetDataList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.StoreRecordNo;
            values[1] = definition.StoreCode;
            values[2] = definition.StoreDefinition;
            values[3] = definition.IntegrationScope;
            values[4] = definition.UnitRecordNo;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(int));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "STORERECORDNO");
            columnNames.Add(1, "STORECODE");
            columnNames.Add(2, "STOREDEFINITION");
            columnNames.Add(3, "INTEGRATIONSCOPE");
            columnNames.Add(4, "UNITRECORDNO");

            return columnNames;
        }
    }
}