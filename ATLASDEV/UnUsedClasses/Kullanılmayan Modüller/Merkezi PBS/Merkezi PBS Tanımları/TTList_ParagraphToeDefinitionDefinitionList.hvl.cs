
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
    public partial class TTList_ParagraphToeDefinitionDefinitionList : TTList
    {
        public TTList_ParagraphToeDefinitionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ParagraphToeDefinitionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<ParagraphToeDefinition.GetParagraphToeDefinitionList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = ParagraphToeDefinition.GetParagraphToeDefinitionList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            ParagraphToeDefinition.GetParagraphToeDefinitionList_Class definition = _listOfDefinition[rowIndex];
            values[3] = definition.PARAGRAPHTOECODE;
            values[0] = definition.MAINTOECODE;
            values[1] = definition.Unitenclosurename;
            values[2] = definition.Unitname;
            values[4] = definition.Officename;
            values[5] = definition.Sectionname;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(3, "PARAGRAPHTOECODE");
            columnNames.Add(0, "MAINTOEID.MAINTOECODE");
            columnNames.Add(1, "MAINTOEID.UNITID.UNITENCLOSUREID.NAME");
            columnNames.Add(2, "MAINTOEID.UNITID.NAME");
            columnNames.Add(4, "OFFICEID.NAME");
            columnNames.Add(5, "SECTIONID.NAME");

            return columnNames;
        }
    }
}