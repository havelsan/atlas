using System.Linq;
using Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using System.Data;
using Infrastructure.Helpers;
using System.Collections;

namespace Core.Services
{
    public class ListService
    {
        public IList<Core.Models.SystemParameter> SystemParameterList()
        {
            var systemParameterList = new List<Core.Models.SystemParameter>();
            using (TTObjectContext context = new TTObjectContext(true))
            {
                var list = context.QueryObjects("SystemParameter");
                foreach (TTObjectClasses.SystemParameter sysParam in list)
                {
                    var systemParameter = new Core.Models.SystemParameter();
                    systemParameter.ObjectID = sysParam.ObjectID;
                    systemParameter.Name = sysParam.Name;
                    systemParameter.Value = sysParam.Value;
                    systemParameter.Description = sysParam.Description;
                    systemParameter.SubType = sysParam.SubType;
                    systemParameter.IsEncrypted = sysParam.IsEncrypted;
                    systemParameter.CacheDurationInMinutes = systemParameter.CacheDurationInMinutes;
                    systemParameterList.Add(systemParameter);
                }
            }

            return systemParameterList;
        }

        private string GetColumnAlignment(DataColumn dataColumn)
        {
            return "left";
        }

        private bool GetColumnVisible(DataColumn dataColumn)
        {
            var defaultHiddenFieldNames = new HashSet<string>()
            {"OBJECTID", "OBJECTDEFID", "CURRENTSTATEDEFID", };
            if (defaultHiddenFieldNames.Contains(dataColumn.ColumnName))
                return false;
            return true;
        }

        public static bool IsNumericType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        private int GetColumnWidth(DataColumn dataColumn)
        {
            if (dataColumn.DataType == typeof(string))
            {
                if (dataColumn.MaxLength > 64)
                {
                    return 250;
                }
            }
            else if (IsNumericType(dataColumn.DataType))
            {
                return 120;
            }

            return 100;
        }

        private string GetColumnDataType(DataColumn dataColumn)
        {
            if (Type.GetTypeCode(dataColumn.DataType) == TypeCode.String)
            {
                return "string";
            }
            else if (Type.GetTypeCode(dataColumn.DataType) == TypeCode.Boolean)
            {
                return "boolean";
            }
            else if (Type.GetTypeCode(dataColumn.DataType) == TypeCode.DateTime)
            {
                return "date";
            }
            else if (IsNumericType(dataColumn.DataType))
            {
                return "number";
            }

            return "object";
        }

        public IEnumerable<QueryParameterInfo> GetQueryParameterInfoList(string queryName)
        {
            var queryDefinition =
                from o in TTObjectDefManager.Instance.ObjectDefs.Values
                from q in o.QueryDefs.Values
                where q.Name == queryName
                select q;
            var targetQueryDef = queryDefinition.FirstOrDefault();
            if (targetQueryDef == null)
                throw new ApplicationException($"{queryName} isimli sorgu bulunamadı");
            var query =
                from p in targetQueryDef.ParameterDefs.Values
                select new QueryParameterInfo { Name = p.Name, Description = p.Description, IsArray = p.IsArray, SqlTestValue = p.SqlTestValue, CodeType = p.CodeType, DataTypeName = p.DataType.Name };
            return query.ToArray();
        }

        public GridQueryResult GetQueryResult(Guid? objectDefID, Guid? queryDefID, string queryName, Dictionary<string, object> parameters, string injectionNQL)
        {
            var queryDefinition =
                from o in TTObjectDefManager.Instance.ObjectDefs.Values
                from q in o.QueryDefs.Values
                select q;
            if (objectDefID.HasValue)
            {
                queryDefinition = queryDefinition.Where(x => x.ObjectDefID == objectDefID.Value);
            }

            if (queryDefID.HasValue)
            {
                queryDefinition = queryDefinition.Where(x => x.QueryDefID == queryDefID.Value);
            }

            if (!string.IsNullOrWhiteSpace(queryName))
            {
                queryDefinition = queryDefinition.Where(x => x.Name == queryName);
            }

            var targetQueryDef = queryDefinition.FirstOrDefault();
            if (targetQueryDef == null)
                throw new ApplicationException($"{queryName} isimli sorgu bulunamadı");
            var gridQueryResult = new GridQueryResult();
            var dataTable = TTReportNqlObject.GetReportQueryResultSet(targetQueryDef, parameters, injectionNQL);
            var array = JArray.FromObject(dataTable, JsonSerializer.CreateDefault(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            gridQueryResult.QueryResult = array;
            var queryGridColumns =
                from dc in dataTable.Columns.OfType<DataColumn>()
                orderby dc.Ordinal
                select new GridColumnInfo { Caption = string.IsNullOrWhiteSpace(dc.Caption) ? dc.ColumnName : dc.Caption, DataField = dc.ColumnName, VisibleIndex = dc.Ordinal, Alignment = GetColumnAlignment(dc), Visible = GetColumnVisible(dc), DataType = GetColumnDataType(dc), Width = GetColumnWidth(dc) };
            gridQueryResult.QueryColumns = queryGridColumns.ToArray();
            return gridQueryResult;
        }

        private string GetColumnDataType(TTListColumnDef listColumnDef)
        {
            Type dataType = listColumnDef?.CodedPropertyDef?.DataType?.PrimitiveType?.Type;

            if (Type.GetTypeCode(dataType) == TypeCode.String)
            {
                return "string";
            }
            else if (Type.GetTypeCode(dataType) == TypeCode.Boolean)
            {
                return "boolean";
            }
            else if (Type.GetTypeCode(dataType) == TypeCode.DateTime)
            {
                return "date";
            }
            else if (IsNumericType(dataType))
            {
                return "number";
            }

            return "object";

        }

        private string GetColumnDataField(TTListColumnDef listColumnDef)
        {
            var codeName = listColumnDef?.PropertyDef?.CodeName;
            if (string.IsNullOrWhiteSpace(codeName) == false)
                return codeName;

            return listColumnDef.MemberName;
        }


        public GridQueryResult GetDefinitionObjectList(Guid formDefID)
        {
            var gridQueryResult = new GridQueryResult();
            var listDef = TTObjectDefManager.Instance.ListDefs.Values.FirstOrDefault(d => d.FormDefID == formDefID);
            if (listDef != null)
            {
                var ttList = TTList.NewList(listDef, string.Empty);
                ttList.GetObjectListByData("");
                var list = ttList.FoundList;

                IList result = new List<object>();

                for (int index = 0; index < list.Count; index++)
                {
                    var obj = ttList.GetTTObjectFromList(list, index);
                    dynamic expObj = obj.CreateExpandoFromObject(listDef.ListColumnDefs.Values.AsEnumerable());
                    expObj.GeneratedDisplayExpression = ttList.GetDisplayText(obj);
                    result.Add(expObj);
                }

                var query = from c in listDef.ListColumnDefs.Values
                            select new GridColumnInfo
                            {
                                Caption = c.Caption,
                                DataField = GetColumnDataField(c),
                                DataType = GetColumnDataType(c),
                                Visible = true,
                                VisibleIndex = c.ColumnOrder,
                                Width = c.ColumnWidth
                            };

                gridQueryResult.QueryResult = result;
                gridQueryResult.QueryColumns = query;
            }

            return gridQueryResult;
        }

    }
}