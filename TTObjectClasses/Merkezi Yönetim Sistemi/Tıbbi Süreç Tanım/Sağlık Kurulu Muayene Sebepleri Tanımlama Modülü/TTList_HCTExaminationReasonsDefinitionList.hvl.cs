
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
    public partial class TTList_HCTExaminationReasonsDefinitionList : TTList
    {
        public TTList_HCTExaminationReasonsDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_HCTExaminationReasonsDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<HCTReasonForExaminationDefinition.GetHCTRFExaminationDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = HCTReasonForExaminationDefinition.GetHCTRFExaminationDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            HCTReasonForExaminationDefinition.GetHCTRFExaminationDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ExaminationReason;

            if (definition.ReportType != null)
                values[1] = GetEnumDisplayText("HCThreeSpecialistReportTypeEnum",(int)definition.ReportType);

            if (definition.SpecialistCount != null)
                values[2] = GetEnumDisplayText("HCTSpecialistCountEnum",(int)definition.SpecialistCount);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(HCThreeSpecialistReportTypeEnum));
            columnDataTypes.Add(2, typeof(HCTSpecialistCountEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "EXAMINATIONREASON");
            columnNames.Add(1, "REPORTTYPE");
            columnNames.Add(2, "SPECIALISTCOUNT");

            return columnNames;
        }
    }
}