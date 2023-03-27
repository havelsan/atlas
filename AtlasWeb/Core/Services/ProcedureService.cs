using Core.Models;
using Infrastructure.Constants;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;

namespace Core.Services
{
    public class ProcedureService
    {
        private readonly IMemoryCache _memoryCache;

        public ProcedureService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private ProcedureList GetProcedureListInternal()
        {
            var viewModel = new ProcedureList();
            using (var objectContext = new TTObjectContext(true))
            {
                var query = from p in objectContext.QueryObjects<ProcedureDefinition>()
                            where p.IsActive ?? false
                            orderby p.Name
                            select new ProcedureDto
                            {
                                ObjectId = p.ObjectID,
                                Code = p.Code,
                                Name = p.Name,
                            };

                viewModel.Procedures = query.ToArray();
                viewModel.TotalCount = viewModel.Procedures.Count();
            }

            return viewModel;
        }

        public ProcedureList GetProcedureList()
        {
            if ( _memoryCache.TryGetValue(CacheKeys.ProcedureList, out ProcedureList procedureLİst))
            {
                return procedureLİst;
            }

            var procedureList = GetProcedureListInternal();
            
            _memoryCache.Set(CacheKeys.ProcedureList, procedureList, TimeSpan.FromMinutes(10));
            return procedureList;
        }

        public ProcedureList GetProcedureList(string procedureCode)
        {
            
            var fullProcedureList = GetProcedureList();
            if (string.IsNullOrWhiteSpace(procedureCode))
                return fullProcedureList;
            var query = from p in fullProcedureList.Procedures
                        where p.Code.StartsWith(procedureCode)
                        select p;
            var procedureList = new ProcedureList(query);
            return procedureList;

                
        }

        public ProcedureList GetProcedureList(DataSourceParams dataSourceParams)
        {
            var fullProcedureList = GetProcedureList();
            var searchValue = dataSourceParams.SearchValue;
            if (string.IsNullOrWhiteSpace(searchValue))
                return fullProcedureList;
            var query = from p in fullProcedureList.Procedures
                        where p.Code.StartsWith(searchValue)
                        select p;

            IEnumerable<ProcedureDto> filteredList = query;
            if ( dataSourceParams.Skip.HasValue && dataSourceParams.Take.HasValue)
            {
                filteredList = query.Skip(dataSourceParams.Skip.Value).Take(dataSourceParams.Take.Value);
            }

            if (string.IsNullOrWhiteSpace(dataSourceParams.Sort) == false)
            {
                Func<ProcedureDto, string> orderByFunc = null;
                if (dataSourceParams.Sort == nameof(ProcedureDto.Code))
                    orderByFunc = item => item.Code;
                else if (dataSourceParams.Sort == nameof(ProcedureDto.Name))
                    orderByFunc = item => item.Name;
                if (orderByFunc != null)
                {
                    filteredList = filteredList.OrderBy(orderByFunc);
                }
            }
            var procedureList = new ProcedureList(filteredList);
            return procedureList;
        }
/////////////////////////////////////
    }
}
