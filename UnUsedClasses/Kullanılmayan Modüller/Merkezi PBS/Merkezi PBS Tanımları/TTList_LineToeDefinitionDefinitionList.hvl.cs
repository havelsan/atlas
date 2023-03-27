
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
    public partial class TTList_LineToeDefinitionDefinitionList : TTList
    {
        public TTList_LineToeDefinitionDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_LineToeDefinitionDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<LineToeDefinition.GetLineToeDefinitionList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = LineToeDefinition.GetLineToeDefinitionList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            LineToeDefinition.GetLineToeDefinitionList_Class definition = _listOfDefinition[rowIndex];
            values[2] = definition.LINETOECODE;
            values[0] = definition.Maintmkdescr;
            values[3] = definition.Missionname;
            values[1] = definition.Paragtmkdescr;
            values[6] = definition.Officename;
            values[7] = definition.Sectionname;
            values[5] = definition.Unitname;
            values[4] = definition.Unitenclosurename;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(0, typeof(Object));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(6, typeof(string));
            columnDataTypes.Add(7, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(4, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(2, "LINETOECODE");
            columnNames.Add(0, "SectionId.OFFICEID.UNITID.MAINTOECODE |' '| SectionId.OFFICEID.UNITID.NAME AS MAINTMKDESCR");
            columnNames.Add(3, "MISSIONID.NAME");
            columnNames.Add(1, "SECTIONID.PARAGRAPHTOECODE");
            columnNames.Add(6, "SECTIONID.OFFICEID.NAME");
            columnNames.Add(7, "SECTIONID.NAME");
            columnNames.Add(5, "SECTIONID.OFFICEID.UNITID.NAME");
            columnNames.Add(4, "SECTIONID.OFFICEID.UNITID.UNITENCLOSUREID.NAME");

            return columnNames;
        }
    }
}