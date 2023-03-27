
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
    /// Ünvan ve Özel Muayene Hizmeti Eşleştirme Tanımı
    /// </summary>
    public partial class TTList_TitleParticipationProcDefList : TTList
    {
        public TTList_TitleParticipationProcDefList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_TitleParticipationProcDefList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<TitleParticipationProcDef.GetTitleParticipationProcDefs_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = TitleParticipationProcDef.GetTitleParticipationProcDefs(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            TitleParticipationProcDef.GetTitleParticipationProcDefs_Class definition = _listOfDefinition[rowIndex];

            if (definition.Title != null)
                values[0] = GetEnumDisplayText("UserTitleEnum",(int)definition.Title);
            values[1] = definition.Procedure;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(0, typeof(UserTitleEnum));
            columnDataTypes.Add(1, typeof(Object));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(0, "TITLE");
            columnNames.Add(1, "PROCEDUREOBJECT.CODE | ' ' | PROCEDUREOBJECT.NAME AS PROCEDURE");

            return columnNames;
        }
    }
}