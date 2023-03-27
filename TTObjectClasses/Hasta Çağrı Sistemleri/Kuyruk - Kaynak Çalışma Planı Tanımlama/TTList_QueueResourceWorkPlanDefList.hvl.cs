
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
    public partial class TTList_QueueResourceWorkPlanDefList : TTList
    {
        public TTList_QueueResourceWorkPlanDefList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_QueueResourceWorkPlanDefList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<QueueResourceWorkPlanDefinition.QueueResourceWorkPlanDefNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = QueueResourceWorkPlanDefinition.QueueResourceWorkPlanDefNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            QueueResourceWorkPlanDefinition.QueueResourceWorkPlanDefNQL_Class definition = _listOfDefinition[rowIndex];
            values[4] = definition.IsActive;
            values[2] = definition.WorkDate;
            values[0] = definition.Resourcename;
            values[1] = definition.Queuename;
            values[3] = definition.Notification;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(4, typeof(Boolean));
            columnDataTypes.Add(2, typeof(DateTime));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(4, "ISACTIVE");
            columnNames.Add(2, "WORKDATE");
            columnNames.Add(0, "RESOURCE.NAME");
            columnNames.Add(1, "QUEUE.NAME");
            columnNames.Add(3, "LCDNOTIFICATION.NOTIFICATION");

            return columnNames;
        }
    }
}