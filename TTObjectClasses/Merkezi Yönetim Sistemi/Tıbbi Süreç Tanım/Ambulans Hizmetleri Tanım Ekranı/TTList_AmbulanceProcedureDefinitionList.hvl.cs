
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
    /// Ambulans Hizmetleri Tanımı
    /// </summary>
    public partial class TTList_AmbulanceProcedureDefinitionList : TTList
    {
        public TTList_AmbulanceProcedureDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_AmbulanceProcedureDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<AmbulanceProcedureDefinition.GetAmbulanceProcedureDefiniton_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = AmbulanceProcedureDefinition.GetAmbulanceProcedureDefiniton(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            AmbulanceProcedureDefinition.GetAmbulanceProcedureDefiniton_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.Code;
            values[2] = definition.Qref;
            values[0] = definition.ID;
            values[5] = definition.IsActive;
            values[3] = definition.Name;
            values[4] = definition.Proceduretreedesc;
            values[6] = definition.Description;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(5, typeof(Boolean));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(6, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "CODE");
            columnNames.Add(2, "QREF");
            columnNames.Add(0, "ID");
            columnNames.Add(5, "ISACTIVE");
            columnNames.Add(3, "NAME");
            columnNames.Add(4, "PROCEDURETREE.DESCRIPTION");
            columnNames.Add(6, "DESCRIPTION");

            return columnNames;
        }
    }
}