
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
    public partial class TTList_DocumentDefinitionDefinitionList : TTList
    {
        public TTList_DocumentDefinitionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_DocumentDefinitionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<DocumentDefinition.GetDocumentDefinitionList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = DocumentDefinition.GetDocumentDefinitionList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            DocumentDefinition.GetDocumentDefinitionList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.Name;
            values[1] = definition.IsGroup;
            values[2] = definition.IsMainGroup;
            values[3] = definition.Parentdocumentdefinition;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(bool));
            columnDataTypes.Add(2, typeof(bool));
            columnDataTypes.Add(3, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "NAME");
            columnNames.Add(1, "ISGROUP");
            columnNames.Add(2, "ISMAINGROUP");
            columnNames.Add(3, "PARENTDOCUMENTDEFINITION.NAME");

            return columnNames;
        }
    }
}