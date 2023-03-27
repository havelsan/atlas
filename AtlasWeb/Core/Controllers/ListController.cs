using Infrastructure.Filters;
using Core.Models;
using Core.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class ListController : Controller
    {
        private readonly ListService _listService;
        public ListController(ListService lookupService)
        {
            _listService = lookupService;
        }

        [HttpGet]
        public IQueryable<Core.Models.SystemParameter> SystemParameterList()
        {
            return _listService.SystemParameterList().AsQueryable();
        }

        public class GetQueryResultInput
        {
            public Guid? ObjectDefID { get; set; }
            public Guid? QueryDefID { get; set; }
            public string QueryName { get; set; }
            public IDictionary<string, IQueryParam> Parameters { get; set; }
            public string injectionNQL { get; set; }
        }

        [HttpPost]
        public GridQueryResult GetQueryResult(GetQueryResultInput input)
        {
            Dictionary<string, object> targetDictionary = null;
            if (input.Parameters != null)
            {
                targetDictionary = input.Parameters.ToDictionary(d => d.Key, d => d.Value.paramValue);
            }

            return _listService.GetQueryResult(input.ObjectDefID, input.QueryDefID, input.QueryName, targetDictionary, input.injectionNQL);
        }

        [HttpPost]
        public IEnumerable<QueryParameterInfo> GetQueryParameterInfoList(string queryName)
        {
            return _listService.GetQueryParameterInfoList(queryName);
        }

        [HttpGet]
        public GridQueryResult GetDefinitionObjectList([FromQuery]Guid formDefID)
        {
            return _listService.GetDefinitionObjectList(formDefID);
        }

    }
}