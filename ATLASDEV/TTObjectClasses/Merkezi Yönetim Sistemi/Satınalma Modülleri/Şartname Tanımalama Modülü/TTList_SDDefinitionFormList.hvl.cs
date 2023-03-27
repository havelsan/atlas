
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
    public partial class TTList_SDDefinitionFormList : TTList
    {
        public TTList_SDDefinitionFormList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SDDefinitionFormList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<SpecificationDefinition.SDDefinitionFormNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = SpecificationDefinition.SDDefinitionFormNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            SpecificationDefinition.SDDefinitionFormNQL_Class definition = _listOfDefinition[rowIndex];

            if (definition.Category != null)
                values[0] = GetEnumDisplayText("SpecificationCategoryEnum",(int)definition.Category);
            values[1] = definition.Code;
            values[2] = definition.Date;
            values[3] = definition.Name;
            values[4] = definition.No;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(SpecificationCategoryEnum));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(DateTime));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "CATEGORY");
            columnNames.Add(1, "CODE");
            columnNames.Add(2, "DATE");
            columnNames.Add(3, "NAME");
            columnNames.Add(4, "NO");

            return columnNames;
        }
    }
}