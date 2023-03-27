
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
    /// Bağlı Birlik Depo Tanımları
    /// </summary>
    public partial class TTList_DependentStoreDefinitionList : TTList
    {
        public TTList_DependentStoreDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_DependentStoreDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<DependentStoreDefinition.GetDependentStoreDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = DependentStoreDefinition.GetDependentStoreDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            DependentStoreDefinition.GetDependentStoreDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.QREF;
            values[1] = definition.Name;

            if (definition.Status != null)
                values[3] = GetEnumDisplayText("OpenCloseEnum",(int)definition.Status);
            values[2] = definition.GoodsResponsible;
            values[4] = definition.Description;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(OpenCloseEnum));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(4, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "QREF");
            columnNames.Add(1, "NAME");
            columnNames.Add(3, "STATUS");
            columnNames.Add(2, "GOODSRESPONSIBLE");
            columnNames.Add(4, "DESCRIPTION");

            return columnNames;
        }
    }
}