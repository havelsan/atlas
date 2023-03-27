
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
    /// MHRS Aksiyon Tipi Tanımları
    /// </summary>
    public partial class TTList_MHRSActionTypeDefinitionList : TTList
    {
        public TTList_MHRSActionTypeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MHRSActionTypeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MHRSActionTypeDefinition.GetMHRSActionTypeDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MHRSActionTypeDefinition.GetMHRSActionTypeDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MHRSActionTypeDefinition.GetMHRSActionTypeDefinition_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.ActionCode;
            values[1] = definition.ActionName;
            values[2] = definition.IsDocumentRequired;
            values[3] = definition.IsIstisnaType;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(bool));
            columnDataTypes.Add(3, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "ACTIONCODE");
            columnNames.Add(1, "ACTIONNAME");
            columnNames.Add(2, "ISDOCUMENTREQUIRED");
            columnNames.Add(3, "ISISTISNATYPE");

            return columnNames;
        }
    }
}