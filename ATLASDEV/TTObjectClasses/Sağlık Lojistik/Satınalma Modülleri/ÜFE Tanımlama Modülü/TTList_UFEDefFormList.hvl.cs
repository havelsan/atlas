
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
    /// ÜFE Tanımlama
    /// </summary>
    public partial class TTList_UFEDefFormList : TTList
    {
        public TTList_UFEDefFormList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_UFEDefFormList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<UFEDefinition.UFEDefFormNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = UFEDefinition.UFEDefFormNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            UFEDefinition.UFEDefFormNQL_Class definition = _listOfDefinition[rowIndex];
            values[2] = definition.UFEYear;

            if (definition.UFEMonth != null)
                values[1] = GetEnumDisplayText("MonthsEnum",(int)definition.UFEMonth);
            values[3] = definition.UFEIndex;
            values[0] = definition.Ufesectordefname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(1, typeof(MonthsEnum));
            columnDataTypes.Add(3, typeof(double));
            columnDataTypes.Add(0, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(2, "UFEYEAR");
            columnNames.Add(1, "UFEMONTH");
            columnNames.Add(3, "UFEINDEX");
            columnNames.Add(0, "UFESECTORDEFINITION.NAME");

            return columnNames;
        }
    }
}