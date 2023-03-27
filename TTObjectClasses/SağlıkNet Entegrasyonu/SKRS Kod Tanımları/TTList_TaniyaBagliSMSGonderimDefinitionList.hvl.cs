
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
    public partial class TTList_TaniyaBagliSMSGonderimDefinitionList : TTList
    {
        public TTList_TaniyaBagliSMSGonderimDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_TaniyaBagliSMSGonderimDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<TaniyaBagliSMSGonderim.TaniyaBagliSMSGonderimNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = TaniyaBagliSMSGonderim.TaniyaBagliSMSGonderimNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            TaniyaBagliSMSGonderim.TaniyaBagliSMSGonderimNQL_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.Diagnosisname;
            values[0] = definition.Diagnosiscode;
            values[2] = definition.Username;
            values[4] = definition.Inpatient;
            values[3] = definition.Outpatient;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(4, typeof(bool));
            columnDataTypes.Add(3, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "THIS.DIAGNOSIS.NAME");
            columnNames.Add(0, "THIS.DIAGNOSIS.CODE");
            columnNames.Add(2, "THIS.RESUSER.NAME");
            columnNames.Add(4, "THIS.INPATIENT");
            columnNames.Add(3, "THIS.OUTPATIENT");

            return columnNames;
        }
    }
}