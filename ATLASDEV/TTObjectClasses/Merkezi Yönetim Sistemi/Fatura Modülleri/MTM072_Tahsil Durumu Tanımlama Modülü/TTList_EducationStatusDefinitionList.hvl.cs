
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
    /// Eğitim Durumu Tanımlama
    /// </summary>
    public partial class TTList_EducationStatusDefinitionList : TTList
    {
        public TTList_EducationStatusDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_EducationStatusDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<EducationStatusDefinition.GetEducationStatusDefinitionNQL_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = EducationStatusDefinition.GetEducationStatusDefinitionNQL(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            EducationStatusDefinition.GetEducationStatusDefinitionNQL_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.ExternalCode;
            values[0] = definition.Name;
            values[2] = definition.ShortName;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(2, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "EXTERNALCODE");
            columnNames.Add(0, "NAME");
            columnNames.Add(2, "SHORTNAME");

            return columnNames;
        }
    }
}