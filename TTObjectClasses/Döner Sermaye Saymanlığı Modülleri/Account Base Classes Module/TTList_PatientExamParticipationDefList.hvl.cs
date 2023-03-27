
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
    /// Katılım Payı Alınmayacak Hal, Sağlık Hizmeti ve Kişi Tanımları
    /// </summary>
    public partial class TTList_PatientExamParticipationDefList : TTList
    {
        public TTList_PatientExamParticipationDefList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PatientExamParticipationDefList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PatientExamParticipationDefinition.GetPatientParticipationDefs_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PatientExamParticipationDefinition.GetPatientParticipationDefs(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PatientExamParticipationDefinition.GetPatientParticipationDefs_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ExternalCode;
            values[1] = definition.Description;

            if (definition.Type != null)
                values[2] = GetEnumDisplayText("ExcludeParticipationTypeEnum",(int)definition.Type);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(ExcludeParticipationTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "EXTERNALCODE");
            columnNames.Add(1, "DESCRIPTION");
            columnNames.Add(2, "TYPE");

            return columnNames;
        }
    }
}