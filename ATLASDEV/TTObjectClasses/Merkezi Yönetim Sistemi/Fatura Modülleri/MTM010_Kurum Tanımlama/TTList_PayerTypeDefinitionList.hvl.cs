
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
    /// Kurum Türü Tanımlama
    /// </summary>
    public partial class TTList_PayerTypeDefinitionList : TTList
    {
        public TTList_PayerTypeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PayerTypeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PayerTypeDefinition.GetPayerTypeDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PayerTypeDefinition.GetPayerTypeDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PayerTypeDefinition.GetPayerTypeDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ID;
            values[1] = definition.Name;
            values[3] = definition.IsActive;

            if (definition.PayerType != null)
                values[2] = GetEnumDisplayText("PayerTypeEnum",(int)definition.PayerType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(Boolean));
            columnDataTypes.Add(2, typeof(PayerTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "ID");
            columnNames.Add(1, "NAME");
            columnNames.Add(3, "ISACTIVE");
            columnNames.Add(2, "PAYERTYPE");

            return columnNames;
        }
    }
}