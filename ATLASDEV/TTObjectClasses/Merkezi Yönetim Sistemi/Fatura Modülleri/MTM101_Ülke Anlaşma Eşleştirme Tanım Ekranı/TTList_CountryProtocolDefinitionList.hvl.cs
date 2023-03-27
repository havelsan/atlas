
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
    /// Ülke Anlaşma Eşleştirme
    /// </summary>
    public partial class TTList_CountryProtocolDefinitionList : TTList
    {
        public TTList_CountryProtocolDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_CountryProtocolDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<CountryProtocolDefinition.GetCountryProtocolDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = CountryProtocolDefinition.GetCountryProtocolDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            CountryProtocolDefinition.GetCountryProtocolDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Country;

            if (definition.PatientType != null)
                values[1] = GetEnumDisplayText("PatientPayerEnum",(int)definition.PatientType);
            values[2] = definition.Protocol;
            values[3] = definition.Protocoluniversity;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(PatientPayerEnum));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "COUNTRY.NAME");
            columnNames.Add(1, "PATIENTTYPE");
            columnNames.Add(2, "PROTOCOL.NAME");
            columnNames.Add(3, "PROTOCOLUNIVERSITY.NAME");

            return columnNames;
        }
    }
}