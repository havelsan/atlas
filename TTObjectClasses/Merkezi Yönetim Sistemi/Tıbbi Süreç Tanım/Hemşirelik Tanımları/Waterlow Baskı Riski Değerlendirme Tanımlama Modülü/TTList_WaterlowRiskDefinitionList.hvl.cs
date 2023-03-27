
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
    /// Hemşirelik Uygulamaları ? Waterlow Risk Listesi
    /// </summary>
    public partial class TTList_WaterlowRiskDefinitionList : TTList
    {
        public TTList_WaterlowRiskDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_WaterlowRiskDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<WaterlowRiskDefinition.GetWaterlowRiskDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = WaterlowRiskDefinition.GetWaterlowRiskDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            WaterlowRiskDefinition.GetWaterlowRiskDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;
            values[1] = definition.Score;

            if (definition.WaterlowType != null)
                values[2] = GetEnumDisplayText("WaterlowTypeEnum",(int)definition.WaterlowType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(int));
            columnDataTypes.Add(2, typeof(WaterlowTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "NAME");
            columnNames.Add(1, "SCORE");
            columnNames.Add(2, "WATERLOWTYPE");

            return columnNames;
        }
    }
}