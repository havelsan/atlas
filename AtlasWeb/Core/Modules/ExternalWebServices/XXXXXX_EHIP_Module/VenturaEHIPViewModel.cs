//$87D82461
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;

namespace Core.Controllers
{
    public class XXXXXXEhipResult
    {
        public TTObjectClasses.XXXXXXEHIP.IslemSonuc XXXXXXResult;
        public string XXXXXXUrl;
        public string UniqueRefNo;
        public XXXXXXEhipResult(string url, string refNo, TTObjectClasses.XXXXXXEHIP.IslemSonuc result)
        {
            this.XXXXXXUrl = url;
            this.UniqueRefNo = refNo;
            this.XXXXXXResult = result;
        }
    }


    public partial class XXXXXXEHIPServiceController
    {
        [HttpPost]
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Everyone)]
        public XXXXXXEhipResult XXXXXXEHIPUrl()
        {

            try
            {
                string Url = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPURL", "http://X.X.X.X/ehip/Default.aspx?");
                string bolumID = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "n5Fu5YGT7G6TEQXT9pMIIQ==");
                string userName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPUSERNAME", "XXXXXX");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPPASSWORD", "XXXXXX");
                string UniqueRefNo = TTUser.CurrentUser.UniqueRefNo.ToString();
                TTObjectClasses.XXXXXXEHIP.IslemSonuc result = TTObjectClasses.XXXXXXEHIP.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, bolumID, userName, password);
                if (result.IslemBasarili)
                    return new XXXXXXEhipResult(Url, UniqueRefNo, result);
                else
                    throw new Exception(result.Mesaj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

namespace Core.Models
{
    public partial class XXXXXXEHIPViewModel
    {
    }
}