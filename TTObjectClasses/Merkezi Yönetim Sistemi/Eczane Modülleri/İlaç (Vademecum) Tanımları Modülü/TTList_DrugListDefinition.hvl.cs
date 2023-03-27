
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
    /// İlaç (Vademecum) Tanımları
    /// </summary>
    public partial class TTList_DrugListDefinition : TTList
    {
        public TTList_DrugListDefinition(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_DrugListDefinition(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<DrugDefinition.GetDrugDefinitions_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = DrugDefinition.GetDrugDefinitions(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            DrugDefinition.GetDrugDefinitions_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Barcode;
            values[1] = definition.Code;
            values[2] = definition.Name;
            values[4] = definition.IsActive;

            if (definition.PrescriptionType != null)
                values[5] = GetEnumDisplayText("PrescriptionTypeEnum",(int)definition.PrescriptionType);
            values[3] = definition.NATOStockNO;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(4, typeof(Boolean));
            columnDataTypes.Add(5, typeof(PrescriptionTypeEnum));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "BARCODE");
            columnNames.Add(1, "CODE");
            columnNames.Add(2, "NAME");
            columnNames.Add(4, "ISACTIVE");
            columnNames.Add(5, "PRESCRIPTIONTYPE");
            columnNames.Add(3, "STOCKCARD.NATOSTOCKNO");

            return columnNames;
        }
    }
}