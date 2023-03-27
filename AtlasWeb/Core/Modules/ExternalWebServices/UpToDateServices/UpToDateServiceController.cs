//$4D78F54C
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;

namespace Core.Modules.ExternalWebServices.UpToDateServices
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class UpToDateServiceController : Controller
    {
        public string GetUpToDateServiceUrl(string searchString)
        {

            string unique_user_id = TTUser.CurrentUser.UniqueRefNo.ToString();
            string assigned_system_id = TTObjectClasses.SystemParameter.GetParameterValue("UPTODATESYSTEMID", "HMGR420480GAZFIZIK");
            string URL = "http://xxxxxx.com/contents/search?unid="+unique_user_id+"&srcsys="+assigned_system_id+"&search=";

            return URL;


        }
        public bool UpToDateAccess()
        {

            TTUser currentUser = TTUser.CurrentUser;
            if (currentUser.UserType == (int)UserTypeEnum.Doctor || currentUser.IsSuperUser)
                return true;

            return false;
        }
    }
}
