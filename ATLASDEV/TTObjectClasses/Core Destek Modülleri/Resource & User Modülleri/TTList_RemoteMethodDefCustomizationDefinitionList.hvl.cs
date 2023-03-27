
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
    public partial class TTList_RemoteMethodDefCustomizationDefinitionList : TTList
    {
        public TTList_RemoteMethodDefCustomizationDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_RemoteMethodDefCustomizationDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<RemoteMethodDefCustomization.GetRemoteMethodDefCustomizationDefinitionRQ_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = RemoteMethodDefCustomization.GetRemoteMethodDefCustomizationDefinitionRQ(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            RemoteMethodDefCustomization.GetRemoteMethodDefCustomizationDefinitionRQ_Class definition = _listOfDefinition[rowIndex];
            values[2] = definition.IsSendingStartStop;
            values[0] = definition.RemoteMethodDefID;
            values[1] = definition.RemoteMethodDefName;
            values[3] = definition.IsActive;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(2, typeof(bool));
            columnDataTypes.Add(0, typeof(Guid));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(Boolean));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(2, "ISSENDINGSTARTSTOP");
            columnNames.Add(0, "REMOTEMETHODDEFID");
            columnNames.Add(1, "REMOTEMETHODDEFNAME");
            columnNames.Add(3, "ISACTIVE");

            return columnNames;
        }
    }
}