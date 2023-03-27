
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
    public partial class TTList_SectionDefinitionDefinitionList : TTList
    {
        public TTList_SectionDefinitionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SectionDefinitionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<SectionDefinition.GetSectionDefinitionList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = SectionDefinition.GetSectionDefinitionList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            SectionDefinition.GetSectionDefinitionList_Class definition = _listOfDefinition[rowIndex];
            values[3] = definition.NAME;
            values[1] = definition.Unitname;
            values[2] = definition.Officename;
            values[0] = definition.Unitenclosurename;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(0, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(3, "NAME");
            columnNames.Add(1, "UNITID.NAME");
            columnNames.Add(2, "OFFICEID.NAME");
            columnNames.Add(0, "UNITID.UNITENCLOSUREID.NAME");

            return columnNames;
        }
    }
}