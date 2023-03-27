
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
    /// CPT4 ve SUT Eşleştirme Tanımları
    /// </summary>
    public partial class TTList_MatchingCPT4AndSUTDefinitionsList : TTList
    {
        public TTList_MatchingCPT4AndSUTDefinitionsList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MatchingCPT4AndSUTDefinitionsList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MatchingCPT4AndSUTDefinitions.GetMatchingCPT4AndSUTDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MatchingCPT4AndSUTDefinitions.GetMatchingCPT4AndSUTDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MatchingCPT4AndSUTDefinitions.GetMatchingCPT4AndSUTDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.CPTCode;
            values[1] = definition.Cptoriginalname;
            values[2] = definition.Sutcode;
            values[3] = definition.Sutname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "CPT4DEFINITION.CPTCODE");
            columnNames.Add(1, "CPT4DEFINITION.ORIGINALNAME");
            columnNames.Add(2, "SUTDEFINITION.CODE");
            columnNames.Add(3, "SUTDEFINITION.NAME");

            return columnNames;
        }
    }
}