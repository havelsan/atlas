
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
    public partial class TTList_ExternalPurchaseDefFormList : TTList
    {
        public TTList_ExternalPurchaseDefFormList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ExternalPurchaseDefFormList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ExternalPurchaseDefinition.ExternalPurchaseDefFormNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ExternalPurchaseDefinition.ExternalPurchaseDefFormNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ExternalPurchaseDefinition.ExternalPurchaseDefFormNQL_Class definition = _listOfDefinition[rowIndex];
            values[5] = definition.PurchaseDate;
            values[1] = definition.PurchasedBy;
            values[3] = definition.UnitPrice;
            values[2] = definition.Amount;
            values[0] = definition.Purchaseitemdef;
            values[4] = definition.Supplier;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(5, typeof(DateTime));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(BigCurrency));
            columnDataTypes.Add(2, typeof(Currency));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(4, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(5, "PURCHASEDATE");
            columnNames.Add(1, "PURCHASEDBY");
            columnNames.Add(3, "UNITPRICE");
            columnNames.Add(2, "AMOUNT");
            columnNames.Add(0, "PURCHASEITEMDEF.ITEMNAME");
            columnNames.Add(4, "SUPPLIER.NAME");

            return columnNames;
        }
    }
}