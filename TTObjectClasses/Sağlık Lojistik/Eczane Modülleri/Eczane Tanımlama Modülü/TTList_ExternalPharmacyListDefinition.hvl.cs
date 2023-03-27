
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
    public partial class TTList_ExternalPharmacyListDefinition : TTList
    {
        public TTList_ExternalPharmacyListDefinition(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ExternalPharmacyListDefinition(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ExternalPharmacy.GetExternalPharmacy_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ExternalPharmacy.GetExternalPharmacy(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ExternalPharmacy.GetExternalPharmacy_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;
            values[1] = definition.OpeningDate;

            if (definition.Status != null)
                values[2] = GetEnumDisplayText("ExternalPharmacyStatusEnum",(int)definition.Status);
            values[4] = definition.Address;
            values[5] = definition.Telephone1;
            values[6] = definition.Telephone2;
            values[7] = definition.Fax;
            values[3] = definition.AuthorizedPerson;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(DateTime));
            columnDataTypes.Add(2, typeof(ExternalPharmacyStatusEnum));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(6, typeof(string));
            columnDataTypes.Add(7, typeof(string));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "NAME");
            columnNames.Add(1, "OPENINGDATE");
            columnNames.Add(2, "STATUS");
            columnNames.Add(4, "ADDRESS");
            columnNames.Add(5, "TELEPHONE1");
            columnNames.Add(6, "TELEPHONE2");
            columnNames.Add(7, "FAX");
            columnNames.Add(3, "AUTHORIZEDPERSON");

            return columnNames;
        }
    }
}