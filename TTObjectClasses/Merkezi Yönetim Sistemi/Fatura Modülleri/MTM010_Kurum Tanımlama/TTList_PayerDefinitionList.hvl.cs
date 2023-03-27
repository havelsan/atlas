
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
    /// Kurum Listesi
    /// </summary>
    public partial class TTList_PayerDefinitionList : TTList
    {
        public TTList_PayerDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PayerDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            PayerDefinition o = ttObj as PayerDefinition;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.Code + "-" + o.Name;
        }

        BindingList<PayerDefinition.GetPayerDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PayerDefinition.GetPayerDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PayerDefinition.GetPayerDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ID;
            values[1] = definition.Code;
            values[2] = definition.Name;
            values[3] = definition.IsActive;
            values[4] = definition.Address;
            values[5] = definition.DayOfSent;
            values[7] = definition.FaxNumber;
            values[6] = definition.LimitOfInvoiceSummaryList;
            values[8] = definition.PhoneNumber;
            values[9] = definition.TaxNumber;
            values[10] = definition.TaxOffice;
            values[11] = definition.ZipCode;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(1, typeof(long));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(Boolean));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(int));
            columnDataTypes.Add(7, typeof(string));
            columnDataTypes.Add(6, typeof(int));
            columnDataTypes.Add(8, typeof(string));
            columnDataTypes.Add(9, typeof(string));
            columnDataTypes.Add(10, typeof(string));
            columnDataTypes.Add(11, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "ID");
            columnNames.Add(1, "CODE");
            columnNames.Add(2, "NAME");
            columnNames.Add(3, "ISACTIVE");
            columnNames.Add(4, "ADDRESS");
            columnNames.Add(5, "DAYOFSENT");
            columnNames.Add(7, "FAXNUMBER");
            columnNames.Add(6, "LIMITOFINVOICESUMMARYLIST");
            columnNames.Add(8, "PHONENUMBER");
            columnNames.Add(9, "TAXNUMBER");
            columnNames.Add(10, "TAXOFFICE");
            columnNames.Add(11, "ZIPCODE");

            return columnNames;
        }
    }
}