
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
    /// MKYS Servis Depolar
    /// </summary>
    public partial class TTList_MKYS_ServisDepoDefinitionList : TTList
    {
        public TTList_MKYS_ServisDepoDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_MKYS_ServisDepoDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<MKYS_ServisDepo.GetMKYS_ServisDepoList_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = MKYS_ServisDepo.GetMKYS_ServisDepoList(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            MKYS_ServisDepo.GetMKYS_ServisDepoList_Class definition = _listOfDefinition[rowIndex];
            values[0] = definition.bagliBirimID;
            values[1] = definition.birimAdi;
            values[2] = definition.birimKayitNo;
            values[3] = definition.birimKisaAdi;
            values[4] = definition.birimKodu;
            values[5] = definition.faaliyetDurumu;
            values[6] = definition.tur;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(int));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(2, typeof(int));
            columnDataTypes.Add(3, typeof(string));
            columnDataTypes.Add(4, typeof(string));
            columnDataTypes.Add(5, typeof(string));
            columnDataTypes.Add(6, typeof(string));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "BAGLIBIRIMID");
            columnNames.Add(1, "BIRIMADI");
            columnNames.Add(2, "BIRIMKAYITNO");
            columnNames.Add(3, "BIRIMKISAADI");
            columnNames.Add(4, "BIRIMKODU");
            columnNames.Add(5, "FAALIYETDURUMU");
            columnNames.Add(6, "TUR");

            return columnNames;
        }
    }
}