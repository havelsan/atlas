
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
    public partial class TTList_StockCardAccountancyDefinitionList : TTList
    {
        public TTList_StockCardAccountancyDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_StockCardAccountancyDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<StockCard.GetStockCard_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = StockCard.GetStockCard(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            StockCard.GetStockCard_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.CardOrderNO;
            values[2] = definition.NATOStockNO;
            values[1] = definition.Name;

            if (definition.Status != null)
                values[3] = GetEnumDisplayText("StockCardStatusEnum",(int)definition.Status);
            values[4] = definition.Stockcardclassname;
            values[5] = definition.DistributionType;
            values[7] = definition.Carddrawername;

            if (definition.StockMethod != null)
                values[6] = GetEnumDisplayText("StockMethodEnum",(int)definition.StockMethod);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(long));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(StockCardStatusEnum));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(7, typeof(string));
            columnDataTypes.Add(6, typeof(StockMethodEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "CARDORDERNO");
            columnNames.Add(2, "NATOSTOCKNO");
            columnNames.Add(1, "NAME");
            columnNames.Add(3, "STATUS");
            columnNames.Add(4, "STOCKCARDCLASS.NAME");
            columnNames.Add(5, "DISTRIBUTIONTYPE.DISTRIBUTIONTYPE");
            columnNames.Add(7, "CARDDRAWER.NAME");
            columnNames.Add(6, "STOCKMETHOD");

            return columnNames;
        }
    }
}