
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
    /// Tanıya Göre Hizmet Öneri Tanımları
    /// </summary>
    public partial class TTList_DiagnosisActionSuggestionDefinitionList : TTList
    {
        public TTList_DiagnosisActionSuggestionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_DiagnosisActionSuggestionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<DiagnosisActionSuggestion.GetDiagnosisActionSuggestionDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = DiagnosisActionSuggestion.GetDiagnosisActionSuggestionDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            DiagnosisActionSuggestion.GetDiagnosisActionSuggestionDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Diagnosename;
            values[2] = definition.Procedurename;

            if (definition.ActionType != null)
                values[1] = GetEnumDisplayText("ActionTypeEnum",(int)definition.ActionType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(1, typeof(ActionTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "THIS.DIAGNOSISDEFINITION.NAME");
            columnNames.Add(2, "THIS.PROCEDUREDEFINITION.NAME");
            columnNames.Add(1, "ACTIONTYPE");

            return columnNames;
        }
    }
}