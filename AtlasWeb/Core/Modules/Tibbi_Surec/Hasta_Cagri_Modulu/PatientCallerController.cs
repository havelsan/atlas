
using Microsoft.AspNetCore.Mvc;
using System;
using TTObjectClasses;
using TTStorageManager.Security;
using System.Security.Claims;
using System.Security.Principal;
using Infrastructure.Models;
using System.IdentityModel.Tokens.Jwt;
using static TTObjectClasses.Common;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;

namespace Core.Controllers
{
    [AllowAnonymous]
    public class PatientCallerController : Controller
    {

        public ActionResult HastaCagriForm2(Guid currentResUserID, Guid outPatientResID, bool includeCalleds, string doktorName)
        {
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

            var ret = Common.GetSortedQueue(outPatientResID, includeCalleds);
            ret.doctorName = doktorName;
            ret.hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hasta_Cagri_Modulu/HastaCagriForm.cshtml";
            return View(viewVirtualPath, ret);
        }
        public static int count;
        public static int index = 0;


        public ActionResult HastaGenelCagriForm(string outPatientResIDs, bool includeCalleds)
        {
            string[] outPatientResID = outPatientResIDs.Split(',');
            count = outPatientResID.Length;
            var ret = new Common.QueueItems();
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");
            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));
            if (index == count || index > count)
                index = 0;
            ret = Common.GetSortedQueue(Guid.Parse(outPatientResID[index]), includeCalleds);
            index++;
            if (index == count)
                index = 0;
            ret.doctorName = "";
            ret.hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hasta_Cagri_Modulu/HastaGenelCagriForm.cshtml";
            return View(viewVirtualPath, ret);
        }

        public ActionResult AmeliyatLcdForm()
        {
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

            BindingList<Surgery.GetSurgeryByStatusDefinitionDate_Class> patientSurgeryInfoList = Surgery.GetSurgeryByStatusDefinitionDate(Common.RecTime().Date, Common.RecTime().Date);
            SugeryModel model = new SugeryModel();
            //model.HospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
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
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hasta_Cagri_Modulu/AmeliyatLcdForm.cshtml";
            return View(viewVirtualPath, model);
        }

        public ActionResult GenelLcdForm()
        {
            const string viewVirtualPath = "~/Modules/Tibbi_Surec/Hasta_Cagri_Modulu/GenelLcdForm.cshtml";
            return View(viewVirtualPath);
        }

    }
}