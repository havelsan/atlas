
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
    /// Hizmet Tanımlama Ekranı
    /// </summary>
    public partial class TTList_ProcedureDefinitionList : TTList
    {
        public TTList_ProcedureDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ProcedureDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ProcedureDefinition.GetProcedureDefinitionListDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ProcedureDefinition.GetProcedureDefinitionListDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ID;
            values[2] = definition.Code;
            values[1] = definition.Qref;
            values[3] = definition.Name;
            values[5] = definition.Description;
            values[4] = definition.Proctreedesc;
            values[6] = definition.QuickEntryAllowed;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(6, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "ID");
            columnNames.Add(2, "CODE");
            columnNames.Add(1, "QREF");
            columnNames.Add(3, "NAME");
            columnNames.Add(5, "THIS.DESCRIPTION");
            columnNames.Add(4, "PROCEDURETREE.DESCRIPTION");
            columnNames.Add(6, "QUICKENTRYALLOWED");

            return columnNames;
        }
    }
}