
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
    /// Madde/Dilim/Fıkra Tanımlama
    /// </summary>
    public partial class TTList_HCMatterSliceAnectodeDefinitionList : TTList
    {
        public TTList_HCMatterSliceAnectodeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_HCMatterSliceAnectodeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<HCMatterSliceAnectodeDefinition.GetHCMatterSliceAnectodeDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = HCMatterSliceAnectodeDefinition.GetHCMatterSliceAnectodeDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            HCMatterSliceAnectodeDefinition.GetHCMatterSliceAnectodeDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Matter;

            if (definition.Slice != null)
                values[1] = GetEnumDisplayText("SliceEnum",(int)definition.Slice);
            values[2] = definition.Anectode;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(SliceEnum));
            columnDataTypes.Add(2, typeof(int));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "MATTER");
            columnNames.Add(1, "SLICE");
            columnNames.Add(2, "ANECTODE");

            return columnNames;
        }
    }
}