
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
    /// Muhasebe Satış Hesabı Kırınım Tanımlama
    /// </summary>
    public partial class TTList_RevenueSubAccountCodeDefinitionList : TTList
    {
        public TTList_RevenueSubAccountCodeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_RevenueSubAccountCodeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<RevenueSubAccountCodeDefinition.GetRevenueSubAccountCodeDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = RevenueSubAccountCodeDefinition.GetRevenueSubAccountCodeDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            RevenueSubAccountCodeDefinition.GetRevenueSubAccountCodeDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.AccountCode;
            values[0] = definition.Description;
            values[2] = definition.Masteraccount;
            values[5] = definition.Relatedaccount;

            if (definition.SubAccountType != null)
                values[4] = GetEnumDisplayText("RevenueSubAccountTypeEnum",(int)definition.SubAccountType);

            if (definition.AccountType != null)
                values[3] = GetEnumDisplayText("AccountEntegrationAccountTypeEnum",(int)definition.AccountType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(Object));
            columnDataTypes.Add(5, typeof(Object));
            columnDataTypes.Add(4, typeof(RevenueSubAccountTypeEnum));
            columnDataTypes.Add(3, typeof(AccountEntegrationAccountTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "ACCOUNTCODE");
            columnNames.Add(0, "DESCRIPTION");
            columnNames.Add(2, "(MASTERREVENUESUBACCOUNT.AccountCode | ' - ' | MASTERREVENUESUBACCOUNT.Description) AS MASTERACCOUNT");
            columnNames.Add(5, "(RELATEDREVENUESUBACCOUNT.AccountCode | ' - ' | RELATEDREVENUESUBACCOUNT.Description) AS RELATEDACCOUNT");
            columnNames.Add(4, "SUBACCOUNTTYPE");
            columnNames.Add(3, "ACCOUNTTYPE");

            return columnNames;
        }
    }
}