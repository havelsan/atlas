
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
    /// Fatura Dahillik Sorgu Tanımları
    /// </summary>
    public partial class TTList_InvoiceInclusionNQLDefinitionList : TTList
    {
        public TTList_InvoiceInclusionNQLDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_InvoiceInclusionNQLDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<InvoiceInclusionNQL.GetInvoiceInclusionNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = InvoiceInclusionNQL.GetInvoiceInclusionNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            InvoiceInclusionNQL.GetInvoiceInclusionNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;
            values[1] = definition.NQL;
            values[2] = definition.OrderNo;

            if (definition.ProcedureMaterialType != null)
                values[3] = GetEnumDisplayText("ProcedureMaterialEnum",(int)definition.ProcedureMaterialType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(3, typeof(ProcedureMaterialEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "NAME");
            columnNames.Add(1, "NQL");
            columnNames.Add(2, "ORDERNO");
            columnNames.Add(3, "PROCEDUREMATERIALTYPE");

            return columnNames;
        }
    }
}