using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TTObjectClasses;
using System.Security.Claims;
using System.Security.Principal;
using Infrastructure.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;
using Infrastructure.Filters;

namespace Core.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]/{id?}")]
    public class NewBornLcdController : Controller
    {
        [HttpGet]
        public NewBornModel GetNewBornLcd()
        {
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

            string NewBornLcdShowTime = TTObjectClasses.SystemParameter.GetParameterValue("NewBornLcdShowTime", "");
            int LcdShowTime = NewBornLcdShowTime == "" ? 24 : Convert.ToInt32(NewBornLcdShowTime);//default son 24 saatteki doğumlar görüntülenecek


            //BindingList<BabyObstetricInformation.GetAliveNewBornInfoByDate_Class> newBornInfoList = BabyObstetricInformation.GetAliveNewBornInfoByDate(Common.RecTime().AddHours(-LcdShowTime), Common.RecTime());
            BindingList<BabyObstetricInformation.GetAliveNewBornInfoByDate_Class> newBornInfoList = BabyObstetricInformation.GetAliveNewBornInfoByDate(Common.RecTime().AddDays(-600), Common.RecTime());

            NewBornModel model = new NewBornModel();
            model.CurrentDate = Common.RecTime().ToString("MM/dd/yyyy HH:mm");
            foreach (var newBornInfoItem in newBornInfoList)
            {
                PatientNewBornInfo _patientNewBornInfo = new PatientNewBornInfo();
                _patientNewBornInfo.PatientNameSurname = (newBornInfoItem.Mothername != null ? newBornInfoItem.Mothername : "") + " " + (newBornInfoItem.Mothersurname != null ? newBornInfoItem.Mothersurname : "");
                _patientNewBornInfo.Clinic = "";
                _patientNewBornInfo.Gender = newBornInfoItem.Gender != null ? newBornInfoItem.Gender : "";
                _patientNewBornInfo.GenderKodu = newBornInfoItem.Genderkodu != null ? newBornInfoItem.Genderkodu : "";
                _patientNewBornInfo.BirthTime = newBornInfoItem.BirthDateTime != null ? newBornInfoItem.BirthDateTime.Value.ToString("HH:mm") : "";
                _patientNewBornInfo.BirthWeight = newBornInfoItem.Weigth != null ? newBornInfoItem.Weigth.ToString() + " gr" : "";
                _patientNewBornInfo.Clinic = newBornInfoItem.Resourcename;

                model.PatientNewBornInfo.Add(_patientNewBornInfo);

            }

            return model;
        }

        [HttpGet]
        public NewBornPageInfo GetNewBornLcdPageInfo()
        {

            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));
            NewBornPageInfo model = new NewBornPageInfo();

            model.HospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");

            string NewBornLcdUpdateTime = TTObjectClasses.SystemParameter.GetParameterValue("NewBornLcdUpdateTime", "");
            model.NewBornLcdUpdateTime = NewBornLcdUpdateTime == "" ? 20000 : Convert.ToInt32(NewBornLcdUpdateTime);

            model.NewBornLcdNotification = TTObjectClasses.SystemParameter.GetParameterValue("NewBornLcdNotification", "");

            return model;
        }
    }

    public class NewBornModel
    {
        public string CurrentDate { get; set; }
        public List<PatientNewBornInfo> PatientNewBornInfo = new List<PatientNewBornInfo>();
    }

    public class NewBornPageInfo
    {
        public string HospitalName { get; set; }
        public int NewBornLcdUpdateTime { get; set; }
        public string NewBornLcdNotification { get; set; }
    }
    public class PatientNewBornInfo
    {
        public string PatientNameSurname { get; set; }//Anne Adı
        public string Clinic { get; set; }//Birim
        public string Gender { get; set; }//Cinsiyet
        public string GenderKodu { get; set; }//Cinsiyet
        public string BirthTime { get; set; }//Doğum Saati
        public string BirthWeight { get; set; }
    }
}