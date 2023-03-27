
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
    public partial class TTList_FixedAssetMaterialDefFormList : TTList
    {
        public TTList_FixedAssetMaterialDefFormList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_FixedAssetMaterialDefFormList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<FixedAssetMaterialDefinition.FixedAssetMaterialDefFormNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = FixedAssetMaterialDefinition.FixedAssetMaterialDefFormNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            FixedAssetMaterialDefinition.FixedAssetMaterialDefFormNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;
            values[1] = definition.Mark;
            values[2] = definition.Model;
            values[3] = definition.FixedAssetNO;

            if (definition.Status != null)
                values[4] = GetEnumDisplayText("FixedAssetStatusEnum",(int)definition.Status);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(FixedAssetStatusEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "FIXEDASSETDEFINITION.NAME");
            columnNames.Add(1, "MARK");
            columnNames.Add(2, "MODEL");
            columnNames.Add(3, "FIXEDASSETNO");
            columnNames.Add(4, "STATUS");

            return columnNames;
        }
    }
}