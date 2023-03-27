using Core.Models.DataSourceOptionsParser;
using Core.Models.DataSourceOptionsParser.FilterParser;
using Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTConnectionManager;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTUtils;

namespace Core.Models
{
    public class DevexpressLoader
    {
        /// <summary>
        /// TTQuery Pagination Private Fetch Function
        /// </summary>
        private static LoadResult FetchData(TTObjectContext objectContext, TTQueryDef queryDef, Dictionary<string, object> paramList, string injection, string gridFilter, List<SortParser> sortParser, GroupParser groupParser, PaginationInfo pi, DataSourceLoadOptions loadOptions)
        {
            LoadResult result = new LoadResult();
            DataTable resultSet;
            DataTable countResultSet;
            int totalCount = 0;

            using (DbConnection cn = ConnectionManager.CreateConnection())
            {
                cn.Open();
                DbCommand command = null;
                DbCommand countCommand = null;
                command = queryDef.GetDbCommand(TTObjectDefManager.Instance, cn, queryDef.ObjectDef, paramList, injection);


                command = FilterParser.Parse(command, gridFilter);
                command = GroupParser.Parse(command, groupParser);

                if ((loadOptions.RequireTotalCount || loadOptions.RequireGroupCount) || (loadOptions.TotalSummary != null && loadOptions.TotalSummary.Count() > 0))
                {
                    countCommand = queryDef.GetDbCommand(TTObjectDefManager.Instance, cn, queryDef.ObjectDef, paramList, injection);
                    countCommand = FilterParser.Parse(countCommand, gridFilter);
                    countCommand = SummaryParser.Parse(countCommand, loadOptions);
                }

                if (groupParser == null)
                {
                    command = SortParser.Parse(command, sortParser);
                }

                if (loadOptions.Take != 0 && loadOptions.IsLoadingAll != true)
                {
                    command = PaginationParser.Parse(command, pi, cn);
                }

                DbDataAdapter adap = ConnectionManager.CreateDataAdapter(command);
                using (resultSet = new DataTable())
                {
                    try
                    {
                        adap.Fill(resultSet);

                        if (countCommand != null)
                        {
                            DbDataAdapter countAdapter = ConnectionManager.CreateDataAdapter(countCommand);
                            using (countResultSet = new DataTable())
                            {
                                countAdapter.Fill(countResultSet);

                                result = SummaryParser.SummaryResultParser(countResultSet, result);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var a = ex.ToString();
                        throw;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
            if (groupParser != null)
            {
                resultSet.Columns["KEY"].ColumnName = "key";
                resultSet.Columns["COUNT"].ColumnName = "count";
                resultSet.Columns.Add("items");
            }
            List<object> retList;
            if (groupParser == null)
            {
                retList = PaginationUtils.TableToObject(resultSet, queryDef, null, false);
            }
            else
            {
                retList = PaginationUtils.TableToObject(resultSet, queryDef, groupParser.Key, true);
            }
            result.data = retList;
            if (loadOptions.RequireGroupCount)
            {
                result.groupCount = totalCount;
            }
            return result;
        }

        /// <summary>
        /// TTList Pagination Private Fetch Function
        /// </summary>
        private static LoadResult FetchData(TTObjectContext objectContext, List<MultipleQueryDto> queryDefs, string gridFilter, List<SortParser> sortParser, GroupParser groupParser, PaginationInfo pi, DataSourceLoadOptions loadOptions)
        {
            LoadResult result = new LoadResult();
            DataTable resultSet;
            int totalCount = 0;
            List<DbParameter> allParams = new List<DbParameter>();
            using (DbConnection cn = ConnectionManager.CreateConnection())
            {
                cn.Open();
                //Main Command - Injection parser will be added later
                DbCommand command = null;

                string resultQuery = "SELECT * FROM (";
                for (int i = 0; i < queryDefs.Count; i++)
                {
                    var multipleQueryItem = queryDefs[i];

                    if (i <= queryDefs.Count - 1)
                    {
                        var localCommand = multipleQueryItem.QueryDef.GetDbCommand(TTObjectDefManager.Instance, cn, multipleQueryItem.QueryDef.ObjectDef, multipleQueryItem.ParamList, multipleQueryItem.Injection);
                        resultQuery += localCommand.CommandText;

                        if (localCommand.Parameters != null)
                        {
                            foreach (var param in localCommand.Parameters)
                            {
                                var dbParam = param as DbParameter;

                                if (allParams.FirstOrDefault(x => x.ParameterName == dbParam.ParameterName) == null)
                                {
                                    allParams.Add(dbParam);
                                }

                            }
                        }
                    }

                    if (i == queryDefs.Count - 1)
                    {
                        resultQuery += ")";
                    }
                    else
                    {
                        resultQuery += " UNION ";
                    }
                }

                if (!string.IsNullOrEmpty(gridFilter))
                {
                    resultQuery += " WHERE " + gridFilter;
                }

                command = PaginationParser.ParseSQL(resultQuery, allParams, cn);
                DbCommand countCommand = null;
                command = GroupParser.Parse(command, groupParser);
                if ((loadOptions.RequireTotalCount || loadOptions.RequireGroupCount) || (loadOptions.TotalSummary != null && loadOptions.TotalSummary.Count() > 0))
                {
                    countCommand = PaginationParser.ParseSQL(resultQuery, allParams, cn);
                    countCommand = SummaryParser.Parse(countCommand, loadOptions);
                }
                if (groupParser == null)
                {
                    command = SortParser.Parse(command, sortParser);
                }
                if (loadOptions.Take != 0 && loadOptions.IsLoadingAll != true)
                {
                    command = PaginationParser.Parse(command, pi, cn);
                }

                DbDataAdapter adap = ConnectionManager.CreateDataAdapter(command);
                using (resultSet = new DataTable())
                {
                    try
                    {
                        adap.Fill(resultSet);
                        if (countCommand != null)
                        {
                            DataTable countResultSet;
                            DbDataAdapter countAdapter = ConnectionManager.CreateDataAdapter(countCommand);
                            using (countResultSet = new DataTable())
                            {
                                countAdapter.Fill(countResultSet);

                                result = SummaryParser.SummaryResultParser(countResultSet, result);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var a = ex.ToString();
                        throw;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }

            if (groupParser != null)
            {
                resultSet.Columns["KEY"].ColumnName = "key";
                resultSet.Columns["COUNT"].ColumnName = "count";
                resultSet.Columns.Add("items");
            }
            List<object> retList;
            if (groupParser == null)
            {
                retList = PaginationUtils.TableToObject(resultSet, queryDefs.FirstOrDefault().QueryDef, null, false);
            }
            else
            {
                retList = PaginationUtils.TableToObject(resultSet, queryDefs.FirstOrDefault().QueryDef, groupParser.Key, true);
            }

            result.data = retList;
            if (loadOptions.RequireGroupCount)
            {
                result.groupCount = totalCount;
            }
            return result;
        }

        /// <summary>
        /// TTList Pagination Public OverLoad Function no Injection
        /// </summary>
        public static LoadResult Load(TTObjectContext objectContext, TTList ttList, DataSourceLoadOptions loadOptions, Dictionary<string, object> paramList, string searchText, string orderInjection = "")
        {

            var gridFilter = FilterParser.DevexpressFilterParser(loadOptions, ttList.ListDef.QueryDef);
            var pi = PaginationParser.DevexpressPaginationParser(loadOptions);
            var sortParser = SortParser.DevexpressSortParser(loadOptions, orderInjection);
            string whereClause = DevexpressSQLHelper.InjectFilters(ttList, searchText);
            var groupParser = GroupParser.DevexpressGroupParser(loadOptions);
            return FetchData(objectContext, ttList.ListDef.QueryDef, paramList, whereClause, gridFilter, sortParser, groupParser, pi, loadOptions);

        }

        /// <summary>
        /// TTList Pagination Public OverLoad Function with Injection
        /// </summary>
        public static LoadResult Load(TTObjectContext objectContext, TTList ttList, DataSourceLoadOptions loadOptions, Dictionary<string, object> paramList, string searchText, string injection, string orderInjection = "")
        {
            var gridFilter = FilterParser.DevexpressFilterParser(loadOptions, ttList.ListDef.QueryDef);
            var pi = PaginationParser.DevexpressPaginationParser(loadOptions);
            var sortParser = SortParser.DevexpressSortParser(loadOptions, orderInjection);
            string whereClause = DevexpressSQLHelper.InjectFilters(ttList, searchText);
            if (!string.IsNullOrEmpty(whereClause))
            {
                if (!string.IsNullOrEmpty(injection))
                    whereClause += " AND ";

                whereClause += injection;
            }
            else
                whereClause += DevexpressSQLHelper.InjectFilters(ttList.ListDef.QueryDef, injection);
            var groupParser = GroupParser.DevexpressGroupParser(loadOptions);
            return FetchData(objectContext, ttList.ListDef.QueryDef, paramList, whereClause, gridFilter, sortParser, groupParser, pi, loadOptions);

        }

        /// <summary>
        /// TTQuery Pagination Public OverLoad Function
        /// </summary>
        public static LoadResult Load(TTObjectContext objectContext, TTQueryDef queryDef, DataSourceLoadOptions loadOptions, Dictionary<string, object> paramList, string injection, string orderInjection = "")
        {
            var gridFilter = FilterParser.DevexpressFilterParser(loadOptions, queryDef);
            var pi = PaginationParser.DevexpressPaginationParser(loadOptions);
            var sortParser = SortParser.DevexpressSortParser(loadOptions, orderInjection);
            string whereClause = DevexpressSQLHelper.InjectFilters(queryDef, injection);
            var groupParser = GroupParser.DevexpressGroupParser(loadOptions);
            return FetchData(objectContext, queryDef, paramList, whereClause, gridFilter, sortParser, groupParser, pi, loadOptions);
        }

        /// <summary>
        /// TTQuery (Multiple) Pagination Public OverLoad Function
        /// 2 farkli NQL Querysini Union ile birlestirip, Paging ile cekmek icin kullaniliir. NQL'lerin Select Statementlari ayni olmali, order by olmamali.
        /// </summary>
        /// <returns></returns>
        public static LoadResult Load(TTObjectContext objectContext, List<MultipleQueryDto> multipleQueries, DataSourceLoadOptions loadOptions, string orderInjection = "")
        {
            var gridFilter = FilterParser.DevexpressFilterParser(loadOptions, multipleQueries.FirstOrDefault().QueryDef);
            var pi = PaginationParser.DevexpressPaginationParser(loadOptions);
            List<SortParser> sortParser = SortParser.DevexpressSortParser(loadOptions, orderInjection);

            foreach (var queryDef in multipleQueries)
            {
                queryDef.Injection = DevexpressSQLHelper.InjectFilters(queryDef.QueryDef, queryDef.Injection);
            }

            var groupParser = GroupParser.DevexpressGroupParser(loadOptions);

            return FetchData(objectContext, multipleQueries, gridFilter, sortParser, groupParser, pi, loadOptions);

        }


    }
}
