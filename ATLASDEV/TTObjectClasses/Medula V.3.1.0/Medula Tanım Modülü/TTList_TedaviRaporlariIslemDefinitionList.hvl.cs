
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
    /// Tedavi Raporları İşlem Kodları Tanımlama
    /// </summary>
    public partial class TTList_TedaviRaporlariIslemDefinitionList : TTList
    {
        public TTList_TedaviRaporlariIslemDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_TedaviRaporlariIslemDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<TedaviRaporiIslemKodlari.GetTedaviTuruRaporuIslemiQuery_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = TedaviRaporiIslemKodlari.GetTedaviTuruRaporuIslemiQuery(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            TedaviRaporiIslemKodlari.GetTedaviTuruRaporuIslemiQuery_Class definition = _listOfDefinition[rowIndex];
            values[2] = definition.TedaviRaporuTuruKodu;
            values[3] = definition.TedaviRaporuTuru;
            values[1] = definition.TedaviRaporuIslemi;
            values[0] = definition.TedaviRaporuIslemKodu;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(2, "TEDAVIRAPORUTURUKODU");
            columnNames.Add(3, "TEDAVIRAPORUTURU");
            columnNames.Add(1, "TEDAVIRAPORUISLEMI");
            columnNames.Add(0, "TEDAVIRAPORUISLEMKODU");

            return columnNames;
        }
    }
}