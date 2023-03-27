
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
    /// Eczane Ana Depo Tanımları
    /// </summary>
    public partial class TTList_PharmacyStoreDefinitionList : TTList
    {
        public TTList_PharmacyStoreDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_PharmacyStoreDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            PharmacyStoreDefinition o = ttObj as PharmacyStoreDefinition;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.Name;
        }

        BindingList<PharmacyStoreDefinition.GetPharmacyStore_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = PharmacyStoreDefinition.GetPharmacyStore(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            PharmacyStoreDefinition.GetPharmacyStore_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.QREF;
            values[1] = definition.Name;

            if (definition.PharmacyType != null)
                values[2] = GetEnumDisplayText("PharmacyTypeEnum",(int)definition.PharmacyType);

            if (definition.Status != null)
                values[3] = GetEnumDisplayText("OpenCloseEnum",(int)definition.Status);
            values[4] = definition.Description;
            values[5] = definition.Storeresponsiblename;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(PharmacyTypeEnum));
            columnDataTypes.Add(3, typeof(OpenCloseEnum));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "QREF");
            columnNames.Add(1, "NAME");
            columnNames.Add(2, "PHARMACYTYPE");
            columnNames.Add(3, "STATUS");
            columnNames.Add(4, "DESCRIPTION");
            columnNames.Add(5, "STORERESPONSIBLE.NAME");

            return columnNames;
        }
    }
}