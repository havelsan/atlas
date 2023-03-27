
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
    public partial class TTList_HCDecisionDefinitionList : TTList
    {
        public TTList_HCDecisionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_HCDecisionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<HealthCommitteeDecisionDefinition.GetHCDecisionDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = HealthCommitteeDecisionDefinition.GetHCDecisionDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            HealthCommitteeDecisionDefinition.GetHCDecisionDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Code;
            values[1] = definition.Name;
            values[2] = definition.Category;
            values[3] = definition.RequiresTimeInfo;
            values[4] = definition.RequiresAdditionalDecision;
            values[5] = definition.ShowOnlyAddDecisionOnReports;
            values[6] = definition.UnsuitableForMilitaryService;
            values[7] = definition.IsActive;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(bool));
            columnDataTypes.Add(4, typeof(bool));
            columnDataTypes.Add(5, typeof(bool));
            columnDataTypes.Add(6, typeof(bool));
            columnDataTypes.Add(7, typeof(Boolean));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "CODE");
            columnNames.Add(1, "NAME");
            columnNames.Add(2, "CATEGORY.NAME");
            columnNames.Add(3, "REQUIRESTIMEINFO");
            columnNames.Add(4, "REQUIRESADDITIONALDECISION");
            columnNames.Add(5, "SHOWONLYADDDECISIONONREPORTS");
            columnNames.Add(6, "UNSUITABLEFORMILITARYSERVICE");
            columnNames.Add(7, "ISACTIVE");

            return columnNames;
        }
    }
}