
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
    /// Hizmet Fiyat Eşleştirme Tanımı
    /// </summary>
    public partial class TTList_ProcedurePriceListForDefinitionForm : TTList
    {
        public TTList_ProcedurePriceListForDefinitionForm(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ProcedurePriceListForDefinitionForm(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ProcedurePriceDefinition.ProcedurePriceListNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ProcedurePriceDefinition.ProcedurePriceListNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ProcedurePriceDefinition.ProcedurePriceListNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ID;
            values[1] = definition.Code;
            values[2] = definition.Name;
            values[3] = definition.ExternalCode;
            values[4] = definition.Description;
            values[7] = definition.DateEnd;
            values[6] = definition.DateStart;
            values[5] = definition.Price;
            values[8] = definition.Pricinglistname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(7, typeof(DateTime));
            columnDataTypes.Add(6, typeof(DateTime));
            columnDataTypes.Add(5, typeof(Currency));
            columnDataTypes.Add(8, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "PROCEDUREOBJECT.ID");
            columnNames.Add(1, "PROCEDUREOBJECT.CODE");
            columnNames.Add(2, "PROCEDUREOBJECT.NAME");
            columnNames.Add(3, "PRICINGDETAIL.EXTERNALCODE");
            columnNames.Add(4, "PRICINGDETAIL.DESCRIPTION");
            columnNames.Add(7, "PRICINGDETAIL.DATEEND");
            columnNames.Add(6, "PRICINGDETAIL.DATESTART");
            columnNames.Add(5, "PRICINGDETAIL.PRICE");
            columnNames.Add(8, "PRICINGDETAIL.PRICINGLIST.NAME");

            return columnNames;
        }
    }
}