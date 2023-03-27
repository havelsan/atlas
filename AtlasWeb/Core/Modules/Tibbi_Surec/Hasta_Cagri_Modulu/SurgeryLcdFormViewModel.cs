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
    public class SurgeryLcdController : Controller
    {
        [HttpGet]
        public SugeryModel GetSurgeryLcd()
        {
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

            string SurgeryLcdShowTime = TTObjectClasses.SystemParameter.GetParameterValue("SurgeryLcdShowTime", "");
            int LcdShowTime = SurgeryLcdShowTime == "" ? 24 : Convert.ToInt32(SurgeryLcdShowTime);

            BindingList<Surgery.GetSurgeryByStatusDefinitionDate_Class> patientSurgeryInfoList = Surgery.GetSurgeryByStatusDefinitionDate(Common.RecTime().AddHours(-LcdShowTime), Common.RecTime());

            SugeryModel model = new SugeryModel();
            model.CurrentDate = Common.RecTime().ToString("MM/dd/yyyy HH:mm");
            foreach (var patientSurgeryInfoItem in patientSurgeryInfoList)
            {
                PatientSurgeryInfo _patientSurgeryInfo = new PatientSurgeryInfo();
                _patientSurgeryInfo.PatientNameSurname = (patientSurgeryInfoItem.Patientname != null ? patientSurgeryInfoItem.Patientname : "") + " " + (patientSurgeryInfoItem.Patientsurname != null ? patientSurgeryInfoItem.Patientsurname : "");
                _patientSurgeryInfo.Clinic = patientSurgeryInfoItem.Fromresourcename != null ? patientSurgeryInfoItem.Fromresourcename : "";
                _patientSurgeryInfo.DoctorName = patientSurgeryInfoItem.Proceduredoctorname != null ? patientSurgeryInfoItem.Proceduredoctorname : "";
                _patientSurgeryInfo.SurgeryStatus = patientSurgeryInfoItem.Surgerystatusdefinitionname;
                _patientSurgeryInfo.UpdateTime = patientSurgeryInfoItem.SurgeryStatusDefinitionTime.Value.ToString("H:mm");

                model.PatientSurgeryInfo.Add(_patientSurgeryInfo);

            }

            return model;
        }

        [HttpGet]
        public SurgeryPageInfo GetSurgeryLcdPageInfo()
        {

            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));
            SurgeryPageInfo model = new SurgeryPageInfo();

            model.HospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");

            string SurgeryLcdUpdateTime = TTObjectClasses.SystemParameter.GetParameterValue("SurgeryLcdUpdateTime", "");
            model.SurgeryLcdUpdateTime = SurgeryLcdUpdateTime == "" ? 20000 : Convert.ToInt32(SurgeryLcdUpdateTime);

            model.SurgeryLcdNotification = TTObjectClasses.SystemParameter.GetParameterValue("SurgeryLcdNotification", "");

            return model;
        }
    }


    public class SugeryModel
    {
        public string CurrentDate { get; set; }
        public List<PatientSurgeryInfo> PatientSurgeryInfo = new List<PatientSurgeryInfo>();
    }

    public class SurgeryPageInfo
    {
        public string HospitalName { get; set; }
        public int SurgeryLcdUpdateTime { get; set; }
        public string SurgeryLcdNotification { get; set; }
    }
    public class PatientSurgeryInfo
    {
        public string PatientNameSurname { get; set; }
        public string Clinic { get; set; }
        public string DoctorName { get; set; }
        public string SurgeryStatus { get; set; }
        public string UpdateTime { get; set; }
    }
}