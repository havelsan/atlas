//$A9D55642
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Modules.Tibbi_Surec.Personel_Entegrasyon_Modulu;
using TTStorageManager.Security;
using Core.Security;

namespace Core.Controllers
{
    public partial class PersonnelIntegrationServiceController
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public PersonnelREsultModel PersonnelLogin()
        {
            PersonnelREsultModel model = new PersonnelREsultModel(TTUtils.CultureService.GetText("M26895", "Sistemsel Hata"), -1, "");

            try
            {
                PersusWS.wsRole[] roles = new PersusWS.wsRole[1];
                model.ErrorCode = -3;
                var user = TTUser.CurrentUser;
                PersusWS.wsLoginResult loginResult = PersusWS.WebMethods.loginSync(Sites.SiteLocalHost, "atlas", "321persus", user.UniqueRefNo.ToString(), roles);
                model.ErrorCode = -4;
                if (loginResult.errorCode == 0)
                {
                    loginResult = PersusWS.WebMethods.windowopenSync(Sites.SiteLocalHost, loginResult.token, "menu.portal");
                    if (loginResult.errorCode == 0)
                    {
                        String PersusURL = TTObjectClasses.SystemParameter.GetParameterValue("PERSUSURL", "");
                        model = new PersonnelREsultModel(loginResult.errorMsg, loginResult.errorCode, PersusURL + loginResult.token);
                    }
                    else
                    {
                        model = new PersonnelREsultModel(loginResult.errorMsg, loginResult.errorCode, loginResult.token);
                    }

                }
                else
                {
                     model = new PersonnelREsultModel(loginResult.errorMsg, loginResult.errorCode, loginResult.token);
                }
            }
            catch (Exception e)
            {
                model.ErrorMsg = e.Message;
                if (e.InnerException != null)
                    model.ErrorMsg = model.ErrorMsg + " Inner : " + e.InnerException.Message;
            }

            return model;
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Personel_Izin_Sorgulama)]
        public PersusWS.wsWorkPlanResult PersonnelWorkPlan(PersonnelWorkPlanSearchingModel personnelWorkPlanSearchingModel)
        {
            try
            {
                DateTime date = DateTime.Now;
                date = date.AddYears(-1);
                var user = TTUser.CurrentUser;
                PersusWS.wsRole[] roles = new PersusWS.wsRole[1];
                PersusWS.wsLoginResult loginResult = PersusWS.WebMethods.loginSync(Sites.SiteLocalHost, "atlas", "321persus", user.UniqueRefNo.ToString(), roles);
                PersusWS.wsWorkPlanResult wsWorkPlanResult = PersusWS.WebMethods.personWorkPlanSync(Sites.SiteLocalHost, loginResult.token, personnelWorkPlanSearchingModel.CitizenId, personnelWorkPlanSearchingModel.Type, personnelWorkPlanSearchingModel.StartTime, personnelWorkPlanSearchingModel.EndTime);

                return wsWorkPlanResult;
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

    public   class PersonnelREsultModel
    {
        public string ErrorMsg { get; set; }
        public int ErrorCode { get; set; }
        public string URL { get; set; }

        public PersonnelREsultModel(string msg, int code, string url)
        {
            URL = url;
            ErrorMsg = msg;
            ErrorCode = code;
        }
    }

    public partial class PersonnelIntegrationFormViewModel
    {
       
    }
}