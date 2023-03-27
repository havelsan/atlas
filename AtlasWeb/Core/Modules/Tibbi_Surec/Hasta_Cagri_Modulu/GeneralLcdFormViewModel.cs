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
using System.Linq;
using System.Text;

namespace Core.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]/{id?}")]
    public class GeneralLcdFormController : Controller
    {
        public static int count;
        public static int index = 0;
        [HttpGet]
        public List<QueueItems> GetGeneralLcd(string outPatientResIDs)
        {
            string[] outPatientResID = outPatientResIDs.Split(',');
            count = outPatientResID.Length;
            List< QueueItems> models = new List<QueueItems>();

            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");
            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));
            for (int i = 0; i < outPatientResID.Length; i++)
            {
                QueueItems model = new QueueItems();
                var ret = Common.GetSortedQueue(Guid.Parse(outPatientResID[i]), false);

                model.doctorName = ret.doctorName;
                model.hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                model.polName = ret.polName;
                string LcdUpdateTime = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdUpdateTime", "");
                model.GeneralLcdUpdateTime = LcdUpdateTime == "" ? 20000 : Convert.ToInt32(LcdUpdateTime);
                model.CurrentDate = Common.RecTime().ToString("MM/dd/yyyy HH:mm");
                model.GeneralLcdNotification = TTObjectClasses.SystemParameter.GetParameterValue("PoliclinicLcdNotification", "");
                model.Count = ret.patient.Count;

                foreach (var item in ret.patient)
                {
                    QueuePatient qpatient = new QueuePatient();
                    qpatient.CallTime = item.CallTime;
                    qpatient.patientName = item.patientName;
                    if (item.OrderNO == null)
                        qpatient.OrderNO = item.OrderNO.ToString();
                    else
                        qpatient.OrderNO = item.OrderNO;
                    qpatient.PriorityReason = item.PriorityReason;
                    qpatient.Priority = item.Priority.ToString();
                    qpatient.QueueDate = item.QueueDate.ToString();
                    qpatient.DivertedTime = item.DivertedTime.ToString();
                    qpatient.IsEmergency = (Boolean)item.IsEmergency;
                    qpatient.Index = item.Index;
                    model.patient.Add(qpatient);

                    if (qpatient.Priority == "-1")
                    {
                        CallPatientItem callPatientItem = new CallPatientItem
                        {
                            patientName = qpatient.patientName,
                            policlinicName = model.polName
                        };
                        model.callPatients.Add(callPatientItem);
                    }


                }
                model.patient = model.patient.OrderBy(e => e.Index).ThenBy(e => e.CallTime).ToList();

                models.Add(model);
            }

            return models;
        }
    }


    public class QueuePatient
    {
        public string patientName
        {
            get;
            set;
        }

        public string OrderNO
        {
            get;
            set;
        }

        public string PriorityReason
        {
            get;
            set;
        }

        public string Priority
        {
            get;
            set;
        }

        public string QueueDate
        {
            get;
            set;
        }

        public DateTime? CallTime
        {
            get;
            set;
        }

        public string DivertedTime
        {
            get;
            set;
        }

        public string Doctor
        {
            get;
            set;
        }
        public int Index
        {
            get;
            set;
        }

        public Guid ObjectID
        {
            get;
            set;
        }

        public Boolean IsEmergency
        {
            get;
            set;
        }
        public Guid SubActionProcedureObjectID
        {
            get;
            set;
        }
    }


    public class Policlinic
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class QueueItems
    {
        public string CurrentDate { get; set; }
        public string doctorName
        {
            get;
            set;
        }

        public string polName
        {
            get;
            set;
        }

        public string hospitalName
        {
            get;
            set;
        }
        public int GeneralLcdUpdateTime
        {
            get;
            set;
        }
        public string GeneralLcdNotification
        {
            get;
            set;
        }
        public int Count
        {
            get;
            set;
        }
        public string LcdNotification
        {
            get;
            set;
        }

        public List<QueuePatient> patient = new List<QueuePatient>();

        public List<CallPatientItem> callPatients = new List<CallPatientItem>();
    }

    public class CallPatientItem
    {
        public string patientName { get; set; }
        public string policlinicName { get; set; }

    }
}