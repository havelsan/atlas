
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
    /// Reçete Tipi / Malzeme Eşleştirme
    /// </summary>
    public partial class TTList_PresTypeMaterialMatchDefDefinitionList : TTList
    {
        public TTList_PresTypeMaterialMatchDefDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PresTypeMaterialMatchDefDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PresTypeMaterialMatchDef.GetPresTypeMaterialMatchDefList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PresTypeMaterialMatchDef.GetPresTypeMaterialMatchDefList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PresTypeMaterialMatchDef.GetPresTypeMaterialMatchDefList_Class definition = _listOfDefinition[rowIndex];

            if (definition.PrescriptionType != null)
                values[0] = GetEnumDisplayText("PrescriptionTypeEnum",(int)definition.PrescriptionType);
            values[1] = definition.Materialname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(PrescriptionTypeEnum));
            columnDataTypes.Add(1, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "PRESCRIPTIONTYPE");
            columnNames.Add(1, "MATERIAL.NAME");

            return columnNames;
        }
    }
}