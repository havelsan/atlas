
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
    /// MYKS Malzeme Eşleştirme
    /// </summary>
    public partial class TTList_MalzemeGetDataDefinitionList : TTList
    {
        public TTList_MalzemeGetDataDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MalzemeGetDataDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MalzemeGetData.GetmalzemeGetDataList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MalzemeGetData.GetmalzemeGetDataList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MalzemeGetData.GetmalzemeGetDataList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.malzemeKayitID;
            values[1] = definition.malzemeKodu;
            values[2] = definition.malzemeAdi;
            values[3] = definition.degisiklikTarihi;
            values[4] = definition.olcuBirimiID;
            values[5] = definition.malzemeTurID;
            values[6] = definition.eskiMalzemeKodu;
            values[7] = definition.aktif;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(3, typeof(DateTime));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(6, typeof(string));
            columnDataTypes.Add(7, typeof(bool));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "MALZEMEKAYITID");
            columnNames.Add(1, "MALZEMEKODU");
            columnNames.Add(2, "MALZEMEADI");
            columnNames.Add(3, "DEGISIKLIKTARIHI");
            columnNames.Add(4, "OLCUBIRIMIID");
            columnNames.Add(5, "MALZEMETURID");
            columnNames.Add(6, "ESKIMALZEMEKODU");
            columnNames.Add(7, "AKTIF");

            return columnNames;
        }
    }
}