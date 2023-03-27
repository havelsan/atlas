
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
    public partial class TTList_SurPlusNeedDefFormList : TTList
    {
        public TTList_SurPlusNeedDefFormList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SurPlusNeedDefFormList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<SurPlusNeedDefinition.SurPlusNeedDefFormNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = SurPlusNeedDefinition.SurPlusNeedDefFormNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            SurPlusNeedDefinition.SurPlusNeedDefFormNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Material;
            values[1] = definition.Accountancy;
            values[2] = definition.Amount;
            values[3] = definition.ExpirationDate;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(double));
            columnDataTypes.Add(3, typeof(DateTime));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "MATERIAL.NAME");
            columnNames.Add(1, "ACCOUNTANCY.NAME");
            columnNames.Add(2, "AMOUNT");
            columnNames.Add(3, "EXPIRATIONDATE");

            return columnNames;
        }
    }
}