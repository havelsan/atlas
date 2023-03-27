
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
    /// Uç Yapısı Tanımı
    /// </summary>
    public partial class TTList_FixedAssetDetailEdgeDefinitionList : TTList
    {
        public TTList_FixedAssetDetailEdgeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_FixedAssetDetailEdgeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<FixedAssetDetailEdgeDef.GetFixedAssetDetailEdgeDefList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = FixedAssetDetailEdgeDef.GetFixedAssetDetailEdgeDefList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            FixedAssetDetailEdgeDef.GetFixedAssetDetailEdgeDefList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.EdgeName;
            values[2] = definition.MainClassName;
            values[1] = definition.BodyName;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(1, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "EDGENAME");
            columnNames.Add(2, "FIXEDASSETDETAILBODYDEF.FIXEDASSETDETAILMAINCLASS.MAINCLASSNAME");
            columnNames.Add(1, "FIXEDASSETDETAILBODYDEF.BODYNAME");

            return columnNames;
        }
    }
}