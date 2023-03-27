
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
    /// Para Birimleri Kur Alış Satış Tipi
    /// </summary>
    public partial class TTList_CurrencyRateTypeDefinitionList : TTList
    {
        public TTList_CurrencyRateTypeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_CurrencyRateTypeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<CurrencyRateTypeDefinition.GetCurrencyRateTypeDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = CurrencyRateTypeDefinition.GetCurrencyRateTypeDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            CurrencyRateTypeDefinition.GetCurrencyRateTypeDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Code;
            values[1] = definition.Name;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "CODE");
            columnNames.Add(1, "NAME");

            return columnNames;
        }
    }
}