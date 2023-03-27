using Core.Services;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Core.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]/{id?}")]
    public class LookupController : Controller
    {
        private readonly LookupService _lookupService;
        public LookupController(LookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet]
        public IList<EnumLookupItem> EnumList(string id)
        {
            return _lookupService.EnumList(id);
        }

        [HttpGet]
        public IQueryable<LookupItem> ListDefList([FromQuery] string listDefName, [FromQuery] string listFilterExpression, [FromQuery] string linkFilterExpression)
        {
            return _lookupService.ListDefList(listDefName, listFilterExpression, linkFilterExpression).AsQueryable();
        }
    }
}