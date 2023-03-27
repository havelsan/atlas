
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
    /// Sağlık Kurulu Rapor Tanımları
    /// </summary>
    public partial class TTList_ReasonForExaminationDefinitionList : TTList
    {
        public TTList_ReasonForExaminationDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ReasonForExaminationDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ReasonForExaminationDefinition.GetReasonForExaminationDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ReasonForExaminationDefinition.GetReasonForExaminationDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ReasonForExaminationDefinition.GetReasonForExaminationDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Code;
            values[1] = definition.Reason;
            values[4] = definition.IsActive;

            if (definition.ExaminationType != null)
                values[3] = GetEnumDisplayText("ExaminationTypeEnum",(int)definition.ExaminationType);

            if (definition.HealthCommitteeType != null)
                values[2] = GetEnumDisplayText("HealthCommitteeTypeEnum",(int)definition.HealthCommitteeType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(4, typeof(Boolean));
            columnDataTypes.Add(3, typeof(ExaminationTypeEnum));
            columnDataTypes.Add(2, typeof(HealthCommitteeTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "CODE");
            columnNames.Add(1, "REASON");
            columnNames.Add(4, "ISACTIVE");
            columnNames.Add(3, "EXAMINATIONTYPE");
            columnNames.Add(2, "HEALTHCOMMITTEETYPE");

            return columnNames;
        }
    }
}