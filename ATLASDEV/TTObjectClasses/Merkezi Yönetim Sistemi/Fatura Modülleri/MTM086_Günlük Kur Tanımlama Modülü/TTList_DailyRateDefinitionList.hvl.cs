
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
    /// Günlük Kur Tanımlama
    /// </summary>
    public partial class TTList_DailyRateDefinitionList : TTList
    {
        public TTList_DailyRateDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_DailyRateDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<DailyRateDefinition.GetDailyRateDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = DailyRateDefinition.GetDailyRateDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            DailyRateDefinition.GetDailyRateDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[4] = definition.DailyRate;
            values[0] = definition.RateDate;
            values[2] = definition.Currencytypename;
            values[1] = definition.Qref;
            values[3] = definition.Currencyratetypename;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(4, typeof(Currency));
            columnDataTypes.Add(0, typeof(DateTime));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(4, "DAILYRATE");
            columnNames.Add(0, "RATEDATE");
            columnNames.Add(2, "CURRENCYTYPE.NAME");
            columnNames.Add(1, "CURRENCYTYPE.QREF");
            columnNames.Add(3, "CURRENCYRATETYPE.NAME");

            return columnNames;
        }
    }
}