
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
    /// Set Malzeme Tanım Ekranı
    /// </summary>
    public partial class TTList_SetMaterialDefinitionList : TTList
    {
        public TTList_SetMaterialDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SetMaterialDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<SetMaterialDefinition.GetSetMaterialDefListDef_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = SetMaterialDefinition.GetSetMaterialDefListDef(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            SetMaterialDefinition.GetSetMaterialDefListDef_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ExternalCode;
            values[1] = definition.Description;
            values[5] = definition.Price;
            values[4] = definition.DateEnd;
            values[3] = definition.DateStart;
            values[2] = definition.Pricinglistname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(5, typeof(Currency));
            columnDataTypes.Add(4, typeof(DateTime));
            columnDataTypes.Add(3, typeof(DateTime));
            columnDataTypes.Add(2, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "SETMATERIALPRICINGDETAIL.EXTERNALCODE");
            columnNames.Add(1, "SETMATERIALPRICINGDETAIL.DESCRIPTION");
            columnNames.Add(5, "SETMATERIALPRICINGDETAIL.PRICE");
            columnNames.Add(4, "SETMATERIALPRICINGDETAIL.DATEEND");
            columnNames.Add(3, "SETMATERIALPRICINGDETAIL.DATESTART");
            columnNames.Add(2, "SETMATERIALPRICINGDETAIL.PRICINGLIST.NAME");

            return columnNames;
        }
    }
}