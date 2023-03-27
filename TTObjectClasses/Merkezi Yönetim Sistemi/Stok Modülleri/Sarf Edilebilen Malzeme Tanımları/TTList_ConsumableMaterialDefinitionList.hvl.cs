
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
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
    public partial class TTList_ConsumableMaterialDefinitionList : TTList
    {
        public TTList_ConsumableMaterialDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ConsumableMaterialDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            ConsumableMaterialDefinition o = ttObj as ConsumableMaterialDefinition;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.Name;
        }

        BindingList<ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ConsumableMaterialDefinition.GetConsumableMaterialDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class definition = _listOfDefinition[rowIndex];
            values[7] = definition.IsActive;
            values[0] = definition.Barcode;
            values[1] = definition.MaterialCodeSequence;
            values[2] = definition.Name;
            values[4] = definition.Materialtreename;
            values[6] = definition.Stockcardname;
            values[5] = definition.AllowToGivePatient;
            values[3] = definition.NATOStockNO;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(7, typeof(Boolean));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(long));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(6, typeof(string));
            columnDataTypes.Add(5, typeof(bool));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(7, "ISACTIVE");
            columnNames.Add(0, "BARCODE");
            columnNames.Add(1, "MATERIALCODESEQUENCE");
            columnNames.Add(2, "NAME");
            columnNames.Add(4, "MATERIALTREE.NAME");
            columnNames.Add(6, "STOCKCARD.NAME");
            columnNames.Add(5, "ALLOWTOGIVEPATIENT");
            columnNames.Add(3, "STOCKCARD.NATOSTOCKNO");

            return columnNames;
        }
    }
}