
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
    /// Medula Taburcu Tipi Tanımlama
    /// </summary>
    public partial class TTList_MedulaDischargeTypeDefinitionList : TTList
    {
        public TTList_MedulaDischargeTypeDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MedulaDischargeTypeDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MedulaDischargeTypeDefinition.GetMedulaDisTypeDefQuery_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MedulaDischargeTypeDefinition.GetMedulaDisTypeDefQuery(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MedulaDischargeTypeDefinition.GetMedulaDisTypeDefQuery_Class definition = _listOfDefinition[rowIndex];
            values[1] = definition.taburcuKodu;
            values[2] = definition.taburcuKoduAdi;

            if (definition.XXXXXXDischargeType != null)
                values[0] = GetEnumDisplayText("DischargeTypeEnum",(int)definition.XXXXXXDischargeType);
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(0, typeof(DischargeTypeEnum));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(1, "MEDULADISCHARGECODE.TABURCUKODU");
            columnNames.Add(2, "MEDULADISCHARGECODE.TABURCUKODUADI");
            columnNames.Add(0, "XXXXXXDISCHARGETYPE");

            return columnNames;
        }
    }
}