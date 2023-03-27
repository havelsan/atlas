
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
    /// Tedavi Kararı Kopya Sayısı Tanımları
    /// </summary>
    public partial class TTList_TreatmentDischargeByPatientGroupDefinitionList : TTList
    {
        public TTList_TreatmentDischargeByPatientGroupDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_TreatmentDischargeByPatientGroupDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition_Class definition = _listOfDefinition[rowIndex];

            if (definition.PatientGroup != null)
                values[0] = GetEnumDisplayText("PatientGroupEnum",(int)definition.PatientGroup);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(PatientGroupEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "PATIENTGROUP");

            return columnNames;
        }
    }
}