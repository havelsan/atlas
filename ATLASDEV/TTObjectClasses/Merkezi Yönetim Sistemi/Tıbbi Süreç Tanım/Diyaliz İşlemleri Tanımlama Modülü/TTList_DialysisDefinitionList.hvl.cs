
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
    public partial class TTList_DialysisDefinitionList : TTList
    {
        public TTList_DialysisDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_DialysisDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<DialysisDefinition.GetDialysisDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = DialysisDefinition.GetDialysisDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            DialysisDefinition.GetDialysisDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ID;
            values[1] = definition.Code;
            values[2] = definition.Name;
            values[3] = definition.EnglishName;
            values[4] = definition.Proceduretree;
            values[5] = definition.TreatmentDuration;
            values[6] = definition.Qref;
            values[7] = definition.Chargable;
            values[8] = definition.IsActive;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(int));
            columnDataTypes.Add(6, typeof(string));
            columnDataTypes.Add(7, typeof(bool));
            columnDataTypes.Add(8, typeof(Boolean));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "ID");
            columnNames.Add(1, "CODE");
            columnNames.Add(2, "NAME");
            columnNames.Add(3, "ENGLISHNAME");
            columnNames.Add(4, "PROCEDURETREE.DESCRIPTION");
            columnNames.Add(5, "TREATMENTDURATION");
            columnNames.Add(6, "QREF");
            columnNames.Add(7, "CHARGABLE");
            columnNames.Add(8, "ISACTIVE");

            return columnNames;
        }
    }
}