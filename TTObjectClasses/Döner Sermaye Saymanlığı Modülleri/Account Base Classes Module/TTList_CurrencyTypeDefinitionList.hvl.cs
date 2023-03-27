
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
    /// Para birimleri tanım Listesi
    /// </summary>
    public partial class TTList_CurrencyTypeDefinitionList : TTList
    {
        public TTList_CurrencyTypeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_CurrencyTypeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<CurrencyTypeDefinition.GetCurrencyTypeDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = CurrencyTypeDefinition.GetCurrencyTypeDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            CurrencyTypeDefinition.GetCurrencyTypeDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[3] = definition.IsActive;
            values[0] = definition.Code;
            values[2] = definition.Name;
            values[1] = definition.Qref;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(3, typeof(Boolean));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(1, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(3, "ISACTIVE");
            columnNames.Add(0, "CODE");
            columnNames.Add(2, "NAME");
            columnNames.Add(1, "QREF");

            return columnNames;
        }
    }
}