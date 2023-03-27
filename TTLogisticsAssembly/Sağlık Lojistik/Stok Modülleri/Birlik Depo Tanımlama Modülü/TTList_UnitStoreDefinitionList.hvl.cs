
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
    /// Birlik Depo Tanımları
    /// </summary>
    public partial class TTList_UnitStoreDefinitionList : TTList
    {
        public TTList_UnitStoreDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_UnitStoreDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            UnitStoreDefinition o = ttObj as UnitStoreDefinition;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.Name;
        }

        BindingList<UnitStoreDefinition.GetUnitStoreDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = UnitStoreDefinition.GetUnitStoreDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            UnitStoreDefinition.GetUnitStoreDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.QREF;
            values[1] = definition.Name;

            if (definition.Status != null)
                values[2] = GetEnumDisplayText("OpenCloseEnum",(int)definition.Status);
            values[3] = definition.IsActive;
            values[4] = definition.Description;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(OpenCloseEnum));
            columnDataTypes.Add(3, typeof(Boolean));
            columnDataTypes.Add(4, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "QREF");
            columnNames.Add(1, "NAME");
            columnNames.Add(2, "STATUS");
            columnNames.Add(3, "ISACTIVE");
            columnNames.Add(4, "DESCRIPTION");

            return columnNames;
        }
    }
}