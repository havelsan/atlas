
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
    public partial class TTList_SitesDefinitionList : TTList
    {
        public TTList_SitesDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SitesDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<Sites.GetSiteDefinition_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = Sites.GetSiteDefinition(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            Sites.GetSiteDefinition_Class definition = _listOfDefinition[rowIndex];
            values[3] = definition.IP;
            values[1] = definition.DatabaseName;
            values[4] = definition.IsPatientExist;
            values[2] = definition.ASyncTCPPort;
            values[0] = definition.Name;

            if (definition.SiteType != null)
                values[5] = GetEnumDisplayText("SiteTypeEnum",(int)definition.SiteType);
            values[6] = definition.SyncTCPPort;
            values[7] = definition.ShortName;
            values[8] = definition.Description;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(4, typeof(bool));
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(0, typeof(string));
            columnDataTypes.Add(5, typeof(SiteTypeEnum));
            columnDataTypes.Add(6, typeof(int));
            columnDataTypes.Add(7, typeof(string));
            columnDataTypes.Add(8, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(3, "IP");
            columnNames.Add(1, "DATABASENAME");
            columnNames.Add(4, "ISPATIENTEXIST");
            columnNames.Add(2, "ASYNCTCPPORT");
            columnNames.Add(0, "NAME");
            columnNames.Add(5, "SITETYPE");
            columnNames.Add(6, "SYNCTCPPORT");
            columnNames.Add(7, "SHORTNAME");
            columnNames.Add(8, "DESCRIPTION");

            return columnNames;
        }
    }
}