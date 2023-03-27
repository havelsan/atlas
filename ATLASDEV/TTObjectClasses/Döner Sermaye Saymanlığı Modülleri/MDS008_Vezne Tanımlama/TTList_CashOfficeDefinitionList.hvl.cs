
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
    /// Vezne Listesi
    /// </summary>
    public partial class TTList_CashOfficeDefinitionList : TTList
    {
        public TTList_CashOfficeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_CashOfficeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<CashOfficeDefinition.GetCashOfficeDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = CashOfficeDefinition.GetCashOfficeDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            CashOfficeDefinition.GetCashOfficeDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Qref;
            values[1] = definition.Name;

            if (definition.Type != null)
                values[2] = GetEnumDisplayText("CashOfficeTypeEnum",(int)definition.Type);
            values[3] = definition.IsActive;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(CashOfficeTypeEnum));
            columnDataTypes.Add(3, typeof(Boolean));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "QREF");
            columnNames.Add(1, "NAME");
            columnNames.Add(2, "TYPE");
            columnNames.Add(3, "ISACTIVE");

            return columnNames;
        }
    }
}