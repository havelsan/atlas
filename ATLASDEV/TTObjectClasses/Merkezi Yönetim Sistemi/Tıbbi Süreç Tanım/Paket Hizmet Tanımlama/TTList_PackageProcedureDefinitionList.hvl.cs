
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
    /// Paket Hizmet Listesi
    /// </summary>
    public partial class TTList_PackageProcedureDefinitionList : TTList
    {
        public TTList_PackageProcedureDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PackageProcedureDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PackageProcedureDefinition.GetPackageProcedureDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PackageProcedureDefinition.GetPackageProcedureDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PackageProcedureDefinition.GetPackageProcedureDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ID;
            values[1] = definition.Code;
            values[2] = definition.Qref;
            values[3] = definition.Name;
            values[4] = definition.Proceduretreedesc;
            values[5] = definition.IsActive;

            if (definition.Type != null)
                values[6] = GetEnumDisplayText("PackageProcedureTypeEnum",(int)definition.Type);
            values[7] = definition.HolidaysIncluded;
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
            columnDataTypes.Add(5, typeof(Boolean));
            columnDataTypes.Add(6, typeof(PackageProcedureTypeEnum));
            columnDataTypes.Add(7, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "ID");
            columnNames.Add(1, "CODE");
            columnNames.Add(2, "QREF");
            columnNames.Add(3, "NAME");
            columnNames.Add(4, "PROCEDURETREE.DESCRIPTION");
            columnNames.Add(5, "ISACTIVE");
            columnNames.Add(6, "TYPE");
            columnNames.Add(7, "HOLIDAYSINCLUDED");

            return columnNames;
        }
    }
}