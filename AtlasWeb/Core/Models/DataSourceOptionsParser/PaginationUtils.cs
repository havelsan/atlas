using Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTConnectionManager;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;

namespace Core.Models.DataSourceOptionsParser
{
    public class PaginationUtils
    {
        private static IEnumerable<Type> _ttObjectAssembly;
        private static IEnumerable<Type> TTObjectAssemblyList
        {
            get
            {
                if (_ttObjectAssembly == null)
                {
                    _ttObjectAssembly = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(x => x.Name.Contains("TTObjectClasses")).Select(System.Reflection.Assembly.Load).SelectMany(x => x.DefinedTypes)
                        .ToList();
                }
                return _ttObjectAssembly;
            }

        }

        private static string FindTargetTypePropertyName(string search, PropertyInfo[] properties)
        {
            var property = properties.FirstOrDefault(x => x.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) == 0 && x.Name.Length == search.Length);
            if (property != null)
            {
                return property.Name;
            }
            else
            {
                return search;
            }
        }

        public static Type GetReturnType(TTQueryDef queryDef)
        {
            Type targetType = null;
            if (queryDef.Subtype == QueryDefSubTypeEnum.Object)
            {
                targetType = TTObjectAssemblyList.Where(x => x.Name == queryDef.FunctionReturnType).FirstOrDefault();
            }
            else if (queryDef.Subtype == QueryDefSubTypeEnum.Report)
            {
                var targetTypeList = TTObjectAssemblyList.Where(x => x.Name == queryDef.ClassName);

                if (targetTypeList.Count() > 0)
                    targetType = TTObjectAssemblyList.FirstOrDefault(x => x.Name == queryDef.ClassName && queryDef.FullClassName == (x.DeclaringType.Name + "." + x.Name));
                else
                    targetType = targetTypeList.FirstOrDefault();
            }

            return targetType;
        }

        public static List<object> TableToObject(DataTable resultSet, TTQueryDef queryDef, string key, bool isGroup = false)
        {
            Type targetType = GetReturnType(queryDef);

            List<object> retList = new List<object>();
            if (isGroup)
            {
                foreach (DataRow dataRow in resultSet.Rows)
                {
                    object newObj = null;

                    //var propertyType = targetType.GetProperties().Select(x => x.PropertyType).FirstOrDefault(x => x.Name == key);
                    var propertyType = targetType.GetProperties().Where(x => x.Name == key).Select(x => x.PropertyType).FirstOrDefault();
                    if (propertyType != null && (propertyType.Equals(typeof(bool)) || propertyType.Equals(typeof(bool?))))
                    {
                        bool? boolRes = null;

                        if (dataRow["key"] != null)
                            boolRes = Convert.ToBoolean(dataRow["key"]);

                        newObj = new { key = boolRes, count = dataRow["count"], items = dataRow["items"] };
                    }
                    else
                        newObj = new { key = dataRow["key"], count = dataRow["count"], items = dataRow["items"] };
                    retList.Add(newObj);
                }
            }
            else
            {
                ConstructorInfo ci = null;
                if (queryDef.Subtype == QueryDefSubTypeEnum.Object)
                {
                    var properties = targetType.GetProperties();
                    var allowedProperties = properties.Select(x => x.Name).ToList();

                    var data = resultSet.Select().Select(x => x.ItemArray.Select((a, i) => new { Name = FindTargetTypePropertyName(resultSet.Columns[i].ColumnName, properties), Value = a }).Where(y => allowedProperties.Contains(y.Name)).ToDictionary(a => a.Name, a => a.Value == DBNull.Value ? null : a.Value)).ToList();

                    return data.Select(x => x.ToExpando()).Cast<object>().ToList();
                }
                else if (queryDef.Subtype == QueryDefSubTypeEnum.Report)
                {
                    ci = targetType.GetConstructor(new Type[] { typeof(TTObjectContext), typeof(string), typeof(DataRow) });

                    foreach (DataRow dataRow in resultSet.Rows)
                    {
                        var newObj = ci.Invoke(new object[] { null, queryDef.ObjectDef.Name, dataRow });
                        retList.Add(newObj);
                    }
                }
            }
            return retList;
        }

        public static List<dynamic> TableToObject(DataTable resultSet)
        {
            return resultSet.Select().Select(x => x.ItemArray.Select((a, i) => new { Name = resultSet.Columns[i].ColumnName, Value = a }).ToDictionary(a => a.Name, a => a.Value == DBNull.Value ? null : a.Value)).ToList<dynamic>();
        }



        public static string GetSqlLiteral(string value, DBProviderTypeEnum providerType)
        {
            DateTime? dt;
            if (DateTimeType.TryConvertFrom(value, false, out dt) && dt.HasValue)
            {
                switch (providerType)
                {
                    case DBProviderTypeEnum.MSSqlServer:
                        return "'" + dt.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                    case DBProviderTypeEnum.Oracle:
                        return "TO_DATE('" + dt.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')";
                    case DBProviderTypeEnum.PostgreSql:
                        return "TO_TIMESTAMP('" + dt.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')";
                    case DBProviderTypeEnum.DB2:
                        return "date(TO_DATE('" + dt.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH:MI:SS'))";
                    default:
                        throw new UnsupportedProviderType(providerType);
                }
            }
            return null;
        }

        public static string GetSqlBoolLiteral(string value, DBProviderTypeEnum providerType)
        {
            if (value == "True")
                return "1";
            else if (value == "False")
                return "0";
            else if (string.IsNullOrEmpty(value))
                return "IS NULL";
            else
                return value;

            //return "";
        }
    }
}
