
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
    /// Fiyat Grubu Listesi
    /// </summary>
    public partial class TTList_PricingListGroupDefinitionList : TTList
    {
        public TTList_PricingListGroupDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PricingListGroupDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PricingListGroupDefinition.GetPricingListGroupDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PricingListGroupDefinition.GetPricingListGroupDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PricingListGroupDefinition.GetPricingListGroupDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ExternalCode;
            values[1] = definition.Description;
            values[3] = definition.Pricinglistgroupdescription;
            values[2] = definition.Pricinglistname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(Object));
            columnDataTypes.Add(2, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "EXTERNALCODE");
            columnNames.Add(1, "DESCRIPTION");
            columnNames.Add(3, "PARENTPRICINGLISTGROUPID.EXTERNALCODE | ' ' | PARENTPRICINGLISTGROUPID.DESCRIPTION AS PRICINGLISTGROUPDESCRIPTION");
            columnNames.Add(2, "PRICINGLIST.NAME");

            return columnNames;
        }
    }
}