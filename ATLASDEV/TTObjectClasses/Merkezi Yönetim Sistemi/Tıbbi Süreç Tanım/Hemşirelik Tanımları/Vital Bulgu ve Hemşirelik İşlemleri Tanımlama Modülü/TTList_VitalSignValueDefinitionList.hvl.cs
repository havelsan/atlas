
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
    public partial class TTList_VitalSignValueDefinitionList : TTList
    {
        public TTList_VitalSignValueDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_VitalSignValueDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<VitalSignValueDefinition.GetVitalSignValueDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = VitalSignValueDefinition.GetVitalSignValueDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            VitalSignValueDefinition.GetVitalSignValueDefinition_Class definition = _listOfDefinition[rowIndex];

            if (definition.VitalSignType != null)
                values[0] = GetEnumDisplayText("VitalSignType",(int)definition.VitalSignType);
            values[2] = definition.MaxAge;
            values[1] = definition.MinAge;
            values[4] = definition.MaxValue;
            values[3] = definition.MinValue;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(VitalSignType));
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(1, typeof(int));
            columnDataTypes.Add(4, typeof(double));
            columnDataTypes.Add(3, typeof(double));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "VITALSIGNTYPE");
            columnNames.Add(2, "MAXAGE");
            columnNames.Add(1, "MINAGE");
            columnNames.Add(4, "MAXVALUE");
            columnNames.Add(3, "MINVALUE");

            return columnNames;
        }
    }
}