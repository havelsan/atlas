using System;
using TTInstanceManagement;
using Core.Models;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TTDefinitionManagement;

using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class UserMainServiceController : Controller
    {
        [HttpGet]
        public UserMainFormViewModel UserMain()
        {
            var viewModel = new UserMainFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }


        [HttpPost]
        public LoadResult GetResUserDefinitionList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUser"];
                Dictionary<string, object> paramList = new Dictionary<string, object>();

                loadOptions.Sort = new SortingInfo[1];
                loadOptions.Sort[0] = new SortingInfo();
                loadOptions.Sort[0].Desc = false;
                loadOptions.Sort[0].Selector = "Name";

                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, string.Empty);
                var items = result.GetAsDynamic(result.data);

                foreach (var item in items)
                {
                    var user = TTUser.GetUserByOBJECTID(new Guid(item.ObjectID.ToString()));
                    if (user != null && user.Name != null)
                    {
                        item.UserLogonName = user.Name;
                    }
                }
                result.data = items;
            }
            return result;
        }
    }
}

namespace Core.Models
{
    public partial class UserMainFormViewModel
    {
        public List<ResUserInfo> ResUserInfoList { get; set; }
    }
    public class LoadUserResult
    {
        public List<ResUserInfo> data;
        public int totalCount;
        public int groupCount;
        public object[] summary;
    }
    public class ResUserInfo
    {
        public Guid ObjectID { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public long UniqueRefNo { get; set; }
        public string LogonName { get; set; }
    }
}