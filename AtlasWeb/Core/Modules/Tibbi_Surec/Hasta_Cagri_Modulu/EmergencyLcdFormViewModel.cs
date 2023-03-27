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
using TTInstanceManagement;

namespace Core.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]/{id?}")]
    public class EmergencyLcdController : Controller
    {
        [HttpGet]
        public EmergencyModel GetEmergencyLcd()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

                this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));

                string EmergencyLcdShowTime = TTObjectClasses.SystemParameter.GetParameterValue("EmergencyLcdShowTime", "");
                int LcdShowTime = EmergencyLcdShowTime == "" ? 24 : Convert.ToInt32(EmergencyLcdShowTime);

                EmergencyModel model = new EmergencyModel();
                model.CurrentDate = Common.RecTime().ToString("MM/dd/yyyy HH:mm");
                DateTime startDate = Common.RecTime().AddHours(-LcdShowTime);
                DateTime endDate = Common.RecTime();

                var activeEmergencyQueueList = ExaminationQueueDefinition.GetActiveEmergencyQueues();
                List<Guid> doctorList = new List<Guid>();
                List<Guid> resourceList = new List<Guid>();
                List<Guid> episodeActionIdList = new List<Guid>();

                #region doctorList
                foreach (ExaminationQueueDefinition.GetActiveEmergencyQueues_Class queue in activeEmergencyQueueList)
                {
                    resourceList.Add(queue.Ressectionid.Value);
                    var doctors = ResUser.GetSpecialistDoctorByResource(objectContext, queue.Ressectionid.Value);
                    foreach (var doctorItem in doctors)
                    {
                        doctorList.Add(doctorItem.ObjectID);
                    }
                }
                #endregion doctorList
                #region episodeAction
                string whereCriteria = "";
                whereCriteria += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(startDate) + " AND " + GetDateAsString(endDate);
                whereCriteria += "AND this.CURRENTSTATEDEFID IN(States.Examination)";
                string whereCriteria_Resource = string.Empty;
                foreach (var resourceId in resourceList)
                {
                    if (string.IsNullOrEmpty(whereCriteria_Resource))
                        whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                    whereCriteria_Resource += ",'" + resourceId + "'";
                }
                if (!string.IsNullOrEmpty(whereCriteria_Resource))
                {
                    whereCriteria += whereCriteria_Resource + ") ";
                }
                whereCriteria += " AND this.PatientExaminationType <> " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                episodeActionIdList = PatientExamination.GetPatientExaminationForEmergencyLcd(objectContext, whereCriteria).Select(c => c.ObjectID.Value).ToList();
                #endregion episodeAction
                var examinationQueueItemList = ExaminationQueueItem.GetEmergencyActiveQueByDate(endDate, startDate, doctorList, episodeActionIdList);

                List<PatientEmergencyInfo> _PatientEmergencyInfoList = new List<PatientEmergencyInfo>();
                foreach (var examinationQueueItem in examinationQueueItemList.OrderBy(c => c.Admissiontime))
                {
                    PatientEmergencyInfo _patientEmergencyInfo = new PatientEmergencyInfo();
                    _patientEmergencyInfo.PatientNameSurname = (examinationQueueItem.Patientname != null ? examinationQueueItem.Patientname : "") + " " + (examinationQueueItem.Patientsurname != null ? examinationQueueItem.Patientsurname : "");
                    _patientEmergencyInfo.AdmissionTime = examinationQueueItem.Admissiontime.Value.ToString("HH:mm");
                    _patientEmergencyInfo.Clinic = examinationQueueItem.Masterresource != null ? examinationQueueItem.Masterresource : "";
                    _patientEmergencyInfo.IsPatientCalled = (examinationQueueItem.Priority.Value.ToString() == "-1") ? true : false;
                    var emergencyObj = objectContext.GetObject(examinationQueueItem.ObjectID.Value, examinationQueueItem.ObjectDefID.Value);
                    _patientEmergencyInfo.Triage = "";
                    if (emergencyObj is EmergencyIntervention)
                    {
                        var _emergencyIntervention = (EmergencyIntervention)emergencyObj;
                        _patientEmergencyInfo.Triage = _emergencyIntervention.Triage != null ? _emergencyIntervention.Triage.ADI : "";
                    }
                    if (emergencyObj is PatientExamination)
                    {
                        var _patientExamination = (PatientExamination)emergencyObj;
                        _patientEmergencyInfo.Triage = (_patientExamination.EmergencyIntervention != null && _patientExamination.EmergencyIntervention.Triage != null) ? _patientExamination.EmergencyIntervention.Triage.ADI : "";
                    }

                    _PatientEmergencyInfoList.Add(_patientEmergencyInfo);
                }
                model.PatientEmergencyInfo.AddRange(_PatientEmergencyInfoList.Where(c => c.IsPatientCalled == true));
                model.PatientEmergencyInfo.AddRange(_PatientEmergencyInfoList.Where(c => c.IsPatientCalled == false));

                return model;
            }
        }

        [HttpGet]
        public EmergencyPageInfo GetEmergencyLcdPageInfo()
        {

            Guid userID = Guid.Parse("99ba3714-bebd-412f-b782-bac4c5037252");

            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(userID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, userID.ToString())
                    }));
            EmergencyPageInfo model = new EmergencyPageInfo();

            model.HospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");

            string EmergencyLcdUpdateTime = TTObjectClasses.SystemParameter.GetParameterValue("EmergencyLcdUpdateTime", "");
            model.EmergencyLcdUpdateTime = EmergencyLcdUpdateTime == "" ? 20000 : Convert.ToInt32(EmergencyLcdUpdateTime);

            model.EmergencyLcdNotification = TTObjectClasses.SystemParameter.GetParameterValue("EmergencyLcdNotification", "");

            return model;
        }

        public string GetDateAsString(DateTime dateTime)
        {
            return "TODATE('" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

    }


    public class EmergencyModel
    {
        public string CurrentDate { get; set; }
        public List<PatientEmergencyInfo> PatientEmergencyInfo = new List<PatientEmergencyInfo>();
    }

    public class EmergencyPageInfo
    {
        public string HospitalName { get; set; }
        public int EmergencyLcdUpdateTime { get; set; }
        public string EmergencyLcdNotification { get; set; }
    }
    public class PatientEmergencyInfo
    {
        public string PatientNameSurname { get; set; }
        public string Clinic { get; set; }
        public string Triage { get; set; }
        public string AdmissionTime { get; set; }
        public bool IsPatientCalled { get; set; }
    }
}