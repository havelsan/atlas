
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
    public partial class TTList_PurchaseTypeDefFormList : TTList
    {
        public TTList_PurchaseTypeDefFormList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PurchaseTypeDefFormList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<PurchaseTypeDefinition.PurchaseTypeDefFormNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PurchaseTypeDefinition.PurchaseTypeDefFormNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PurchaseTypeDefinition.PurchaseTypeDefFormNQL_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.PurchaseTypeName;

            if (definition.PurchaseMainType != null)
                values[1] = GetEnumDisplayText("PurchaseMainTypeEnum",(int)definition.PurchaseMainType);
            values[2] = definition.NeedsAnnouncement;
            values[3] = definition.NeedsSufficiency;
            values[4] = definition.FirmInvite;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(PurchaseMainTypeEnum));
            columnDataTypes.Add(2, typeof(bool));
            columnDataTypes.Add(3, typeof(bool));
            columnDataTypes.Add(4, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "PURCHASETYPENAME");
            columnNames.Add(1, "PURCHASEMAINTYPE");
            columnNames.Add(2, "NEEDSANNOUNCEMENT");
            columnNames.Add(3, "NEEDSSUFFICIENCY");
            columnNames.Add(4, "FIRMINVITE");

            return columnNames;
        }
    }
}