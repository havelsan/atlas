
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
    public partial class TTList_BankAccountDefinitionList : TTList
    {
        public TTList_BankAccountDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_BankAccountDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<BankAccountDefinition.GetBankAccountDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = BankAccountDefinition.GetBankAccountDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            BankAccountDefinition.GetBankAccountDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Bankname;
            values[1] = definition.Branchcode;
            values[2] = definition.Branchname;
            values[3] = definition.AccountNo;
            values[4] = definition.IBAN;
            values[5] = definition.AccountCode;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(long));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "BANKBRANCH.BANK.NAME");
            columnNames.Add(1, "BANKBRANCH.CODE");
            columnNames.Add(2, "BANKBRANCH.NAME");
            columnNames.Add(3, "ACCOUNTNO");
            columnNames.Add(4, "IBAN");
            columnNames.Add(5, "ACCOUNTCODE");

            return columnNames;
        }
    }
}