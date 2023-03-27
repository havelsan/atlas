
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
    /// Uzunluk Yapısı
    /// </summary>
    public partial class TTList_FixedAssetDetailLengthDefDefinitionList : TTList
    {
        public TTList_FixedAssetDetailLengthDefDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_FixedAssetDetailLengthDefDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<FixedAssetDetailLengthDef.GetFixedAssetDetailLengthDefList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = FixedAssetDetailLengthDef.GetFixedAssetDetailLengthDefList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            FixedAssetDetailLengthDef.GetFixedAssetDetailLengthDefList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Length;
            values[1] = definition.EdgeName;
            values[3] = definition.MainClassName;
            values[2] = definition.BodyName;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(2, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "LENGTH");
            columnNames.Add(1, "FIXEDASSETDETAILEDGEDEF.EDGENAME");
            columnNames.Add(3, "FIXEDASSETDETAILEDGEDEF.FIXEDASSETDETAILBODYDEF.FIXEDASSETDETAILMAINCLASS.MAINCLASSNAME");
            columnNames.Add(2, "FIXEDASSETDETAILEDGEDEF.FIXEDASSETDETAILBODYDEF.BODYNAME");

            return columnNames;
        }
    }
}