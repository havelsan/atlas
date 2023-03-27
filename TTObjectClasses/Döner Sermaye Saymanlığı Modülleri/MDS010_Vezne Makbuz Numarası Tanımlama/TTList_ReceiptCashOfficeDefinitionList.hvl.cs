
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
    /// Vezne Alındı Numarası Tanımlama
    /// </summary>
    public partial class TTList_ReceiptCashOfficeDefinitionList : TTList
    {
        public TTList_ReceiptCashOfficeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ReceiptCashOfficeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[4] = definition.CurrentReceiptNumber;
            values[3] = definition.ReceiptEndNumber;
            values[1] = definition.ReceiptSeriesNo;
            values[2] = definition.ReceiptStartNumber;
            values[0] = definition.Name;
            values[5] = definition.IsActive;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(4, typeof(long));
            columnDataTypes.Add(3, typeof(long));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(long));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(5, typeof(Boolean));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(4, "CURRENTRECEIPTNUMBER");
            columnNames.Add(3, "RECEIPTENDNUMBER");
            columnNames.Add(1, "RECEIPTSERIESNO");
            columnNames.Add(2, "RECEIPTSTARTNUMBER");
            columnNames.Add(0, "CASHOFFICE.NAME");
            columnNames.Add(5, "ISACTIVE");

            return columnNames;
        }
    }
}