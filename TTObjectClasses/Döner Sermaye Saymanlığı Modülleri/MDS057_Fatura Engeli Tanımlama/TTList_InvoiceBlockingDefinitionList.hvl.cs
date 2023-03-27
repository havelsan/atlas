
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
    /// Fatura Engeli Tanımlama
    /// </summary>
    public partial class TTList_InvoiceBlockingDefinitionList : TTList
    {
        public TTList_InvoiceBlockingDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_InvoiceBlockingDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<InvoiceBlockingDefinition.GetInvoiceBlockingDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = InvoiceBlockingDefinition.GetInvoiceBlockingDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            InvoiceBlockingDefinition.GetInvoiceBlockingDefinition_Class definition = _listOfDefinition[rowIndex];
            values[6] = definition.IsActive;
            values[3] = definition.StateDefId;

            if (definition.Type != null)
                values[0] = GetEnumDisplayText("EAorSPEnum",(int)definition.Type);
            values[1] = definition.ObjectName;
            values[2] = definition.StateName;
            values[4] = definition.InvoiceBlock;
            values[5] = definition.CashOfficeBlock;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(6, typeof(Boolean));
            columnDataTypes.Add(3, typeof(Guid));
            columnDataTypes.Add(0, typeof(EAorSPEnum));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(4, typeof(bool));
            columnDataTypes.Add(5, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(6, "ISACTIVE");
            columnNames.Add(3, "STATEDEFID");
            columnNames.Add(0, "TYPE");
            columnNames.Add(1, "OBJECTNAME");
            columnNames.Add(2, "STATENAME");
            columnNames.Add(4, "INVOICEBLOCK");
            columnNames.Add(5, "CASHOFFICEBLOCK");

            return columnNames;
        }
    }
}