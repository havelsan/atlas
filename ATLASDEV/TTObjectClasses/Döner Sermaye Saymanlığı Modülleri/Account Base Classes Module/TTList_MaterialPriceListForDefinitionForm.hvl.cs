
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
    /// Malzeme Fiyat Eşleştirme Tanımı
    /// </summary>
    public partial class TTList_MaterialPriceListForDefinitionForm : TTList
    {
        public TTList_MaterialPriceListForDefinitionForm(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MaterialPriceListForDefinitionForm(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MaterialPrice.MaterialPriceNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MaterialPrice.MaterialPriceNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MaterialPrice.MaterialPriceNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Code;
            values[1] = definition.Name;
            values[3] = definition.Description;
            values[5] = definition.DateEnd;
            values[4] = definition.DateStart;
            values[8] = definition.Price;
            values[6] = definition.Pricinglistname;
            values[2] = definition.Pricingcode;
            values[7] = definition.Pricinglistgroupdescription;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(5, typeof(DateTime));
            columnDataTypes.Add(4, typeof(DateTime));
            columnDataTypes.Add(8, typeof(Currency));
            columnDataTypes.Add(6, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(7, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "MATERIAL.CODE");
            columnNames.Add(1, "MATERIAL.NAME");
            columnNames.Add(3, "PRICINGDETAIL.DESCRIPTION");
            columnNames.Add(5, "PRICINGDETAIL.DATEEND");
            columnNames.Add(4, "PRICINGDETAIL.DATESTART");
            columnNames.Add(8, "PRICINGDETAIL.PRICE");
            columnNames.Add(6, "PRICINGDETAIL.PRICINGLIST.NAME");
            columnNames.Add(2, "PRICINGDETAIL.EXTERNALCODE");
            columnNames.Add(7, "PRICINGDETAIL.PRICINGLISTGROUP.DESCRIPTION");

            return columnNames;
        }
    }
}