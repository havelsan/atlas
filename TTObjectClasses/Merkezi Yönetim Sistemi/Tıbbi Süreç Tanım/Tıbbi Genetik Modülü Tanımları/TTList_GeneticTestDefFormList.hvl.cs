
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
    public partial class TTList_GeneticTestDefFormList : TTList
    {
        public TTList_GeneticTestDefFormList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_GeneticTestDefFormList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<GeneticTestDefinition.GeneticTestDefFormNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = GeneticTestDefinition.GeneticTestDefFormNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            GeneticTestDefinition.GeneticTestDefFormNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Code;
            values[1] = definition.Name;
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
            columnNames.Add(0, "CODE");
            columnNames.Add(1, "NAME");

            return columnNames;
        }
    }
}