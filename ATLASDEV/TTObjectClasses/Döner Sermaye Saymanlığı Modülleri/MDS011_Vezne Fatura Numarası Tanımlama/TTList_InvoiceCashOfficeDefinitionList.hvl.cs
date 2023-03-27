
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
    /// Vezne / Fatura Servisi Fatura Numarası Tanımlama
    /// </summary>
    public partial class TTList_InvoiceCashOfficeDefinitionList : TTList
    {
        public TTList_InvoiceCashOfficeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_InvoiceCashOfficeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<InvoiceCashOfficeDefinition.GetInvoiceCashOfficeDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = InvoiceCashOfficeDefinition.GetInvoiceCashOfficeDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            InvoiceCashOfficeDefinition.GetInvoiceCashOfficeDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;
            values[4] = definition.CurrentInvoiceNumber;
            values[3] = definition.InvoiceEndNumber;
            values[1] = definition.InvoiceSeriesNo;
            values[2] = definition.InvoiceStartNumber;
            values[5] = definition.IsActive;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(4, typeof(long));
            columnDataTypes.Add(3, typeof(long));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(long));
            columnDataTypes.Add(5, typeof(Boolean));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "CASHOFFICE.NAME");
            columnNames.Add(4, "CURRENTINVOICENUMBER");
            columnNames.Add(3, "INVOICEENDNUMBER");
            columnNames.Add(1, "INVOICESERIESNO");
            columnNames.Add(2, "INVOICESTARTNUMBER");
            columnNames.Add(5, "ISACTIVE");

            return columnNames;
        }
    }
}