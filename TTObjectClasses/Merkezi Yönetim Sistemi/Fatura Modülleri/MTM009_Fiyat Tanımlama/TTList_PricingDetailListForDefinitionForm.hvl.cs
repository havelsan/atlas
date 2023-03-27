
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
    /// Fiyat Tanımlama
    /// </summary>
    public partial class TTList_PricingDetailListForDefinitionForm : TTList
    {
        public TTList_PricingDetailListForDefinitionForm(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PricingDetailListForDefinitionForm(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PricingDetailDefinition.GetPricingDetailDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PricingDetailDefinition.GetPricingDetailDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PricingDetailDefinition.GetPricingDetailDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ExternalCode;
            values[1] = definition.Description;
            values[6] = definition.Price;
            values[4] = definition.DateStart;
            values[5] = definition.DateEnd;
            values[2] = definition.Pricinglistname;
            values[3] = definition.Pricinglistgroupdescription;
            values[7] = definition.Currencytypename;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(6, typeof(Currency));
            columnDataTypes.Add(4, typeof(DateTime));
            columnDataTypes.Add(5, typeof(DateTime));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(7, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "EXTERNALCODE");
            columnNames.Add(1, "DESCRIPTION");
            columnNames.Add(6, "PRICE");
            columnNames.Add(4, "DATESTART");
            columnNames.Add(5, "DATEEND");
            columnNames.Add(2, "PRICINGLIST.NAME");
            columnNames.Add(3, "PRICINGLISTGROUP.DESCRIPTION");
            columnNames.Add(7, "CURRENCYTYPE.NAME");

            return columnNames;
        }
    }
}