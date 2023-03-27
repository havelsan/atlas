
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
    /// Randevu Tanımları
    /// </summary>
    public partial class TTList_AppointmentDefinitionList : TTList
    {
        public TTList_AppointmentDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_AppointmentDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<AppointmentDefinition.GetAppointmentDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = AppointmentDefinition.GetAppointmentDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            AppointmentDefinition.GetAppointmentDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.AppointmentDefinitionID;

            if (definition.AppointmentDefinitionName != null)
                values[1] = GetEnumDisplayText("AppointmentDefinitionEnum",(int)definition.AppointmentDefinitionName);
            values[2] = definition.StateOnly;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(AppointmentDefinitionEnum));
            columnDataTypes.Add(2, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "APPOINTMENTDEFINITIONID");
            columnNames.Add(1, "APPOINTMENTDEFINITIONNAME");
            columnNames.Add(2, "STATEONLY");

            return columnNames;
        }
    }
}