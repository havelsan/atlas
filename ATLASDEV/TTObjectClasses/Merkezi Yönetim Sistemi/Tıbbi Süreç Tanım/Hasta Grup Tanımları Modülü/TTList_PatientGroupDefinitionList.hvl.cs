
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
    /// Hasta Grubu Tanımları
    /// </summary>
    public partial class TTList_PatientGroupDefinitionList : TTList
    {
        public TTList_PatientGroupDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PatientGroupDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PatientGroupDefinition.GetPatientGroupDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PatientGroupDefinition.GetPatientGroupDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PatientGroupDefinition.GetPatientGroupDefinition_Class definition = _listOfDefinition[rowIndex];

            if (definition.PatientGroupEnum != null)
                values[1] = GetEnumDisplayText("PatientGroupEnum",(int)definition.PatientGroupEnum);

            if (definition.Beneficiary != null)
                values[3] = GetEnumDisplayText("BeneficiaryEnum",(int)definition.Beneficiary);
            values[0] = definition.OrderNo;

            if (definition.MainPatientGroupEnum != null)
                values[2] = GetEnumDisplayText("MainPatientGroupEnum",(int)definition.MainPatientGroupEnum);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(PatientGroupEnum));
            columnDataTypes.Add(3, typeof(BeneficiaryEnum));
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(2, typeof(MainPatientGroupEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "PATIENTGROUPENUM");
            columnNames.Add(3, "BENEFICIARY");
            columnNames.Add(0, "ORDERNO");
            columnNames.Add(2, "MAINPATIENTGROUP.MAINPATIENTGROUPENUM");

            return columnNames;
        }
    }
}