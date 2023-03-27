
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
    public partial class TTList_ProcedureActionSuggestionDefinitionList : TTList
    {
        public TTList_ProcedureActionSuggestionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ProcedureActionSuggestionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ProcedureActionSuggestion.GetProcedureActionSuggestionList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ProcedureActionSuggestion.GetProcedureActionSuggestionList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ProcedureActionSuggestion.GetProcedureActionSuggestionList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Message;

            if (definition.ActionType != null)
                values[1] = GetEnumDisplayText("ActionTypeEnum",(int)definition.ActionType);
            values[2] = definition.Suggestedprocedurename;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(ActionTypeEnum));
            columnDataTypes.Add(2, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "THIS.MESSAGE");
            columnNames.Add(1, "ACTIONTYPE");
            columnNames.Add(2, "THIS.SUGGESTEDPROCEDUREDEFINITION.NAME");

            return columnNames;
        }
    }
}