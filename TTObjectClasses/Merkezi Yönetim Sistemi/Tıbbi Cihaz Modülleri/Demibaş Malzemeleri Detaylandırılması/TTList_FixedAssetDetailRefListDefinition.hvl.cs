
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
    /// Referans Numarası Tanımlama
    /// </summary>
    public partial class TTList_FixedAssetDetailRefListDefinition : TTList
    {
        public TTList_FixedAssetDetailRefListDefinition(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_FixedAssetDetailRefListDefinition(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<FixedAssetDetailRefDef.GetFixedAssetDetailRefDefList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = FixedAssetDetailRefDef.GetFixedAssetDetailRefDefList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            FixedAssetDetailRefDef.GetFixedAssetDetailRefDefList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Referance;
            values[1] = definition.MainClassName;
            values[2] = definition.ModelName;
            values[3] = definition.MarkName;
            values[4] = definition.Edgedef;
            values[5] = definition.BodyName;
            values[6] = definition.Length;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(6, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "REFERANCE");
            columnNames.Add(1, "FIXEDASSETDETAILMAINCLASS.MAINCLASSNAME");
            columnNames.Add(2, "FIXEDASSETDETAILMODELDEF.MODELNAME");
            columnNames.Add(3, "FIXEDASSETDETAILMODELDEF.FIXEDASSETDETAILMARKDEF.MARKNAME");
            columnNames.Add(4, "FIXEDASSETDETAILEDGEDEF.EDGENAME");
            columnNames.Add(5, "FIXEDASSETDETAILBODYDEF.BODYNAME");
            columnNames.Add(6, "FIXEDASSETDETAILLENGTHDEF.LENGTH");

            return columnNames;
        }
    }
}