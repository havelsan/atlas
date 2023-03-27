
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
    public partial class TTList_MedulaBranchDoctorMatchDefList : TTList
    {
        public TTList_MedulaBranchDoctorMatchDefList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MedulaBranchDoctorMatchDefList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MedulaBranchDoctorMatchDef.GetMedulaBranchDoctorMatchDefs_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MedulaBranchDoctorMatchDef.GetMedulaBranchDoctorMatchDefs(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MedulaBranchDoctorMatchDef.GetMedulaBranchDoctorMatchDefs_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Branchcode;
            values[1] = definition.Branchname;
            values[2] = definition.Doctor;
            values[3] = definition.DiplomaRegisterNo;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "BRANCH.CODE");
            columnNames.Add(1, "BRANCH.NAME");
            columnNames.Add(2, "DOCTOR.NAME");
            columnNames.Add(3, "DOCTOR.DIPLOMAREGISTERNO");

            return columnNames;
        }
    }
}