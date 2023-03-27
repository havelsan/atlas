
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
    /// Kuvvet XXXXXX Tanımlama 
    /// </summary>
    public partial class TTList_ForcesCommandDefinitionList : TTList
    {
        public TTList_ForcesCommandDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ForcesCommandDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ForcesCommand.GetForcesCommandNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ForcesCommand.GetForcesCommandNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ForcesCommand.GetForcesCommandNQL_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.Name;
            values[0] = definition.Code;
            values[2] = definition.ExternalCode;
            values[3] = definition.Active;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "NAME");
            columnNames.Add(0, "CODE");
            columnNames.Add(2, "EXTERNALCODE");
            columnNames.Add(3, "ACTIVE");

            return columnNames;
        }
    }
}