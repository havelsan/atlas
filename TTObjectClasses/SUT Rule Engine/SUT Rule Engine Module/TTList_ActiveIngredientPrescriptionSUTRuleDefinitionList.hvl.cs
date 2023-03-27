
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
    public partial class TTList_ActiveIngredientPrescriptionSUTRuleDefinitionList : TTList
    {
        public TTList_ActiveIngredientPrescriptionSUTRuleDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ActiveIngredientPrescriptionSUTRuleDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ActiveIngredientPrescriptionSUTRuleDef.GetActiveIngredientPrescriptionSUTRuleDefs_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ActiveIngredientPrescriptionSUTRuleDef.GetActiveIngredientPrescriptionSUTRuleDefs(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ActiveIngredientPrescriptionSUTRuleDef.GetActiveIngredientPrescriptionSUTRuleDefs_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.Formu;
            values[2] = definition.OdemeDurumu;
            values[3] = definition.ReceteEdebilenHekimler;
            values[4] = definition.OzelTeshis;
            values[5] = definition.Aciklamalar;
            values[0] = definition.etkinMaddeAdi;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(0, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "FORMU");
            columnNames.Add(2, "ODEMEDURUMU");
            columnNames.Add(3, "RECETEEDEBILENHEKIMLER");
            columnNames.Add(4, "OZELTESHIS");
            columnNames.Add(5, "ACIKLAMALAR");
            columnNames.Add(0, "ETKINMADDE.ETKINMADDEADI");

            return columnNames;
        }
    }
}