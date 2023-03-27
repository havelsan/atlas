using AtlasDataModel;
using Core.Models;
using Core.Security;
using Core.Services;
using Infrastructure.Filters;
using Infrastructure.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Expressions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.UriParser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Controllers
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericControllerNameConventionAttribute : Attribute, IControllerModelConvention
    {

        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.GetGenericTypeDefinition() !=
                typeof(CustomODataController<>))
            {
                // Not a GenericController, ignore.
                return;
            }

            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = entityType.Name;
        }
    }

    [Route("odata/[controller]")]
    [Produces("application/json")]
    [GenericControllerNameConvention]
    public class CustomODataController<T> : ODataController where T : class
    {
        private DbSet<T> _storage;

        public CustomODataController()
        {
            var context = AtlasContextFactory.Instance.CreateContext();
            _storage = context.GetType().GetProperty(typeof(T).Name).GetValue(context) as DbSet<T>;


        }

        [HttpGet]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxAnyAllExpressionDepth = 2)]
        public IActionResult Get(ODataQueryOptions<T> query)
        {
            try
            {
                var data = (_storage.AsQueryable());

                var value = query.ApplyTo(data);
                var count = query.Count?.GetEntityCount(query.Filter?.ApplyTo(data, new ODataQuerySettings()) ?? data);

                var obj = new ODataResult { value = value, count = count };
                return Ok(obj);
            }
            catch (Exception)
            {

                return Ok();
            }
    
        }



        public class ODataResult
        {
            [JsonProperty("@odata.count")]
            public object count { get; set; }

            public object value { get; set; }
        }
        //[EnableQuery]
        //public SingleResult<T> Get([FromODataUri] int key)
        //{
        //    return SingleResult.Create(_storage.Where(n => n.Id == key).AsQueryable());
        //}

        //[HttpPost]
        //[EnableQuery]
        //public IActionResult Post([FromBody]T value)
        //{
        //    _storage.AddOrUpdate(value.Id, value);
        //    return Created(value);
        //}


        //[HttpPut]
        //[EnableQuery]
        //public IActionResult Put([FromODataUri] int key, [FromBody]T value)
        //{
        //    _storage.AddOrUpdate(key, value);
        //    return Updated(value);
        //}


        //[HttpPatch]
        //[EnableQuery]
        //public IActionResult Patch([FromODataUri] int key, [FromBody] Delta<T> value)
        //{
        //    var existing = _storage.GetById(key);
        //    if (existing == null)
        //    {
        //        return NotFound();
        //    }
        //    value.Patch(existing);
        //    _storage.AddOrUpdate(key, existing);
        //    return Updated(existing);
        //}


        //[HttpDelete]
        //[EnableQuery]
        //public IActionResult Delete([FromODataUri] int key)
        //{
        //    _storage.Delete(key);
        //    return NoContent();
        //}



    }

    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;
            //var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

            var items = typeof(AtlasContext).GetProperties().Where(p => p.PropertyType.Name == "DbSet`1").Select(p => new
            {
                name = p.Name,
                type = p.PropertyType.GetGenericArguments().FirstOrDefault()

            }).ToList();
            foreach (var candidate in items)
            {

                feature.Controllers.Add(typeof(CustomODataController<>).MakeGenericType(candidate.type).GetTypeInfo());

            }
        }
    }
    public class ODataController : Microsoft.AspNet.OData.ODataController
    {
        private List<string> IgnoredTypes = new List<string> { "ICollection`1" };

        [HttpGet]
        [AllowAnonymous]
        [Route("api/[controller]/[action]")]
        [HvlResult]
        public List<ModelDto> GetModelList([FromQuery]string parentId, [FromQuery] string filterValue, [FromQuery] string parentPath)
        {
            var context = AtlasContextFactory.Instance.CreateContext();

            var className = parentId?.Split('_')?.LastOrDefault();
            var result = new List<ModelDto>();
            if (string.IsNullOrEmpty(parentId))
            {
                result = context.GetType().GetProperties().Where(p => p.PropertyType.Name == "DbSet`1").Select(p => new ModelDto()
                {
                    text = p.Name,
                    hasItems = !p.GetType().IsPrimitive,
                    parentId = "",
                    className = p.Name,
                    id = p.Name + "_" + p.Name,
                    path = p.Name
                }).Where(p => string.IsNullOrEmpty(filterValue) || p.className.StartsWith(filterValue)).ToList();
            }
            else
            {
                result = context.GetType().GetProperty(className).GetValue(context).GetType().GetGenericArguments()[0].GetProperties().Where(p => !IgnoredTypes.Contains(p.PropertyType.Name)).Select(p => new ModelDto()
                {
                    text = p.Name,
                    hasItems = !IsPrimitive(p.PropertyType),
                    parentId = parentId,
                    className = p.PropertyType.Name,
                    id = parentPath + "/" + p.Name + "_" + (!IsPrimitive(p.PropertyType) ? p.PropertyType.Name : p.Name),
                    path = parentPath + "/" + p.Name,
                    type = p.PropertyType.GenericTypeArguments.Length > 0 ? p.PropertyType.GenericTypeArguments[0].Name : p.PropertyType.Name
                }).ToList();
            }
            return result.OrderBy(p => p.text).ToList();
        }


        public bool IsPrimitive(Type type)
        {
            var types = new List<Type>()
            {
                typeof(Decimal), typeof(Nullable<Decimal>) , typeof(String), typeof(Guid), typeof(Nullable<Guid>), typeof(DateTime), typeof(Nullable<DateTime>),
                typeof(Nullable<bool>), typeof(Nullable<int>), typeof(Nullable<long>), typeof(Nullable<decimal>)
            };
            if (type.IsPrimitive || type.IsEnum || types.Contains(type) || type.IsValueType)
            {
                return true;
            }
            return false;
        }
    }

    public class ModelDto
    {
        public string path { get; set; }
        public string id { get; set; }
        public string parentId { get; set; }
        public string text { get; set; }
        public bool hasItems { get; set; }
        public string className { get; set; }
        public string type { get; set; }
    }
}