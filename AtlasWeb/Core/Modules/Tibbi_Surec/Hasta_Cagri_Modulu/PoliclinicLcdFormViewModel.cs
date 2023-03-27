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
    public class PoliclinicLcdFormController : Controller
    {
        public static int count;
        public static int index = 0;


        public QueueItems GetPoliclinicLcd(string outPatientResID,string DrName,string DrObjectID)
        {

            QueueItems model = new QueueItems();
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");
            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

            var ret = Common.GetSortedQueue(Guid.Parse(outPatientResID), false);
            model.doctorName = DrName;
            model.hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
            model.polName = ret.polName;
            model.CurrentDate = Common.RecTime().ToString("MM/dd/yyyy HH:mm");
            string LcdUpdateTime = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdUpdateTime", "");
            model.GeneralLcdUpdateTime = LcdUpdateTime == "" ? 2 : Convert.ToInt32(LcdUpdateTime);

            model.GeneralLcdNotification = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdNotification", "");

            model.LcdNotification = Common.GetLcdNotificationString(Guid.Parse(outPatientResID), Guid.Parse(DrObjectID));
            model.Count = ret.patient.Count;
            foreach (var item in ret.patient)
            {
                QueuePatient qpatient = new QueuePatient();
                qpatient.CallTime = item.CallTime;
                qpatient.patientName = item.patientName;
                qpatient.OrderNO = item.OrderNO;
                qpatient.PriorityReason = item.PriorityReason;
                qpatient.Priority = item.Priority.ToString();
                qpatient.QueueDate = item.QueueDate.ToString();
                qpatient.DivertedTime = item.DivertedTime.ToString();
                qpatient.IsEmergency = (Boolean)item.IsEmergency;
                model.patient.Add(qpatient);
            }
            return model;
        }

        public QueueItems GetEmergencyLcd(string outPatientResID, string DrName, string DrObjectID)
        {

            QueueItems model = new QueueItems();
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");
            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

            var ret = Common.GetSortedQueue(Guid.Parse(outPatientResID), false);
            model.doctorName = DrName;
            model.hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
            model.polName = ret.polName;
            model.CurrentDate = Common.RecTime().ToString("MM/dd/yyyy HH:mm");
            string LcdUpdateTime = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdUpdateTime", "");
            model.GeneralLcdUpdateTime = LcdUpdateTime == "" ? 20000 : Convert.ToInt32(LcdUpdateTime);

            model.GeneralLcdNotification = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdNotification", "");
            model.LcdNotification = Common.GetLcdNotificationString(Guid.Parse(outPatientResID), Guid.Parse(DrObjectID));
            model.Count = ret.patient.Count;
            foreach (var item in ret.patient)
            {
                if (item.Priority == "-1")
                {
                    QueuePatient qpatient = new QueuePatient();
                    qpatient.CallTime = item.CallTime;
                    qpatient.patientName = item.patientName;
                    qpatient.OrderNO = item.OrderNO;
                    qpatient.PriorityReason = item.PriorityReason;
                    qpatient.Priority = item.Priority.ToString();
                    qpatient.QueueDate = item.QueueDate.ToString();
                    qpatient.DivertedTime = item.DivertedTime.ToString();
                    qpatient.IsEmergency = (Boolean)item.IsEmergency;
                    model.patient.Add(qpatient);
                    break;
                }
            }
            return model;
        }

        public QueueItems GetPolLcdOnlyCalledPatient(string outPatientResID, string DrName,string DrObjectID)
        {

            QueueItems model = new QueueItems();
            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");
            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

            var ret = Common.GetSortedQueue(Guid.Parse(outPatientResID), false);
            model.doctorName = DrName;
            model.hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
            model.polName = ret.polName;
            model.CurrentDate = Common.RecTime().ToString("MM/dd/yyyy HH:mm");
            string LcdUpdateTime = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdUpdateTime", "");
            model.GeneralLcdUpdateTime = LcdUpdateTime == "" ? 20000 : Convert.ToInt32(LcdUpdateTime);

            model.GeneralLcdNotification = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdNotification", "");
            model.LcdNotification = Common.GetLcdNotificationString(Guid.Parse(outPatientResID),Guid.Parse(DrObjectID));
            model.Count = ret.patient.Count;
            foreach (var item in ret.patient)
            {
                if (item.Priority == "-1")
                {
                    QueuePatient qpatient = new QueuePatient();
                    qpatient.CallTime = item.CallTime;
                    qpatient.patientName = item.patientName;
                    qpatient.OrderNO = item.OrderNO;
                    qpatient.PriorityReason = item.PriorityReason;
                    qpatient.Priority = item.Priority.ToString();
                    qpatient.QueueDate = item.QueueDate.ToString();
                    qpatient.DivertedTime = item.DivertedTime.ToString();
                    qpatient.IsEmergency = (Boolean)item.IsEmergency;
                    model.patient.Add(qpatient);
                    break;
                }
            }
            return model;
        }
    }

}