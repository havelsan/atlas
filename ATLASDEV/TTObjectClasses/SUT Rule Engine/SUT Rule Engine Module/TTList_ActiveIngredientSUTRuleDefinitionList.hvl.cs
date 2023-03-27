
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
    public partial class TTList_ActiveIngredientSUTRuleDefinitionList : TTList
    {
        public TTList_ActiveIngredientSUTRuleDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ActiveIngredientSUTRuleDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ActiveIngredientSUTRuleDef.GetActiveIngredientSUTRuleDefs_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ActiveIngredientSUTRuleDef.GetActiveIngredientSUTRuleDefs(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ActiveIngredientSUTRuleDef.GetActiveIngredientSUTRuleDefs_Class definition = _listOfDefinition[rowIndex];
            values[5] = definition.Icerik;
            values[6] = definition.Formu;
            values[8] = definition.Rapor_ICD10Kodu;
            values[7] = definition.Uzman_Heyet;
            values[9] = definition.Brans;
            values[4] = definition.MaksimumRaporSuresi;
            values[1] = definition.Cinsiyeti;
            values[2] = definition.MinimumYasi;
            values[3] = definition.MaksimumYasi;
            values[10] = definition.OzelAciklama;
            values[0] = definition.etkinMaddeAdi;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(6, typeof(string));
            columnDataTypes.Add(8, typeof(string));
            columnDataTypes.Add(7, typeof(string));
            columnDataTypes.Add(9, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(10, typeof(string));
            columnDataTypes.Add(0, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(5, "ICERIK");
            columnNames.Add(6, "FORMU");
            columnNames.Add(8, "RAPOR_ICD10KODU");
            columnNames.Add(7, "UZMAN_HEYET");
            columnNames.Add(9, "BRANS");
            columnNames.Add(4, "MAKSIMUMRAPORSURESI");
            columnNames.Add(1, "CINSIYETI");
            columnNames.Add(2, "MINIMUMYASI");
            columnNames.Add(3, "MAKSIMUMYASI");
            columnNames.Add(10, "OZELACIKLAMA");
            columnNames.Add(0, "ETKINMADDE.ETKINMADDEADI");

            return columnNames;
        }
    }
}