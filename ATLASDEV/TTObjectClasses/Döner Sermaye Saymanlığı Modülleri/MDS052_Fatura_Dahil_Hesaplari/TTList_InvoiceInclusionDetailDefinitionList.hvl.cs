
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
    /// Fatura Dahillik Detay Tanımları
    /// </summary>
    public partial class TTList_InvoiceInclusionDetailDefinitionList : TTList
    {
        public TTList_InvoiceInclusionDetailDefinitionList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_InvoiceInclusionDetailDefinitionList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        BindingList<InvoiceInclusionDetail.GetInvoiceInclusionDetail_Class> _listOfDefinition;
    
        public override int RunListNql(string injectionNQL)
        {
            _listOfDefinition = InvoiceInclusionDetail.GetInvoiceInclusionDetail(injectionNQL);
            return _listOfDefinition.Count;
        }

        public override Guid FillRow(int rowIndex, object[] values)
        {
            InvoiceInclusionDetail.GetInvoiceInclusionDetail_Class definition = _listOfDefinition[rowIndex];
            values[2] = definition.Code;

            if (definition.Type != null)
                values[0] = GetEnumDisplayText("InvoiceInclusionDetailTypeEnum",(int)definition.Type);
            values[1] = definition.Value;
            values[3] = definition.IsActive;
            return ConnectionManager.FromDBGuid(definition["OBJECTID"]);
        }

        public override Dictionary<int, Type> GetColumnDataTypes()
        {
            Dictionary<int, Type> columnDataTypes = new Dictionary<int, Type>();
            columnDataTypes.Add(2, typeof(string));
            columnDataTypes.Add(0, typeof(InvoiceInclusionDetailTypeEnum));
            columnDataTypes.Add(1, typeof(string));
            columnDataTypes.Add(3, typeof(Boolean));

            return columnDataTypes;
        }

        public override Dictionary<int, String> GetColumnNames()
        {
            Dictionary<int, String> columnNames = new Dictionary<int, String>();
            columnNames.Add(2, "CODE");
            columnNames.Add(0, "TYPE");
            columnNames.Add(1, "VALUE");
            columnNames.Add(3, "ISACTIVE");

            return columnNames;
        }
    }
}