using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Linq;
using System.ComponentModel;
using System.Text;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class ExaminationWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Ayaktan_Hasta_Listesi)]
        public ExaminationWorkListViewModel LoadExaminationWorkListViewModel()
        {
            var viewModel = new ExaminationWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<ExaminationWorkListItem>();

                viewModel._SearchCriteria = new ExaminationWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.WorkListEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");

                viewModel._SearchCriteria.policlinic_EA = true;
                viewModel._SearchCriteria.participatnFreeDrugReport_EA = false;
                viewModel._SearchCriteria.doNotListCalleds = false;

                viewModel.LCDNotificationList = new List<LCDNotificationDefinition>();
                BindingList<LCDNotificationDefinition> notificationDefinitions = objectContext.QueryObjects<LCDNotificationDefinition>("ISACTIVE = 1", "NOTIFICATION");
                foreach (var notificationDef in notificationDefinitions)
                {
                    //var notification = viewModel.LCDNotificationList.Where(t => t.ObjectID == notificationDef.ObjectID).FirstOrDefault();
                    //if (notification == null)
                    viewModel.LCDNotificationList.Add(notificationDef);
                }

                #region Birim Listesi

                /****** Klinik Birim Listesi ******/

                viewModel.ResourceList = new List<ResSection>();

                foreach (var useResource in Common.CurrentResource.UserResources)
                {
                    if (useResource.Resource != null && useResource.Resource is ResPoliclinic)
                    {
                        var resource = viewModel.ResourceList.Where(t => t.ObjectID == useResource.Resource.ObjectID).FirstOrDefault();
                        if (resource == null)
                            viewModel.ResourceList.Add(useResource.Resource);
                    }
                }

                viewModel.ResourceList = viewModel.ResourceList.Where(x => x.IsActive == true).OrderBy(x => x.Name).ToList<ResSection>();
                var CurrentResource = Common.CurrentResource;
                viewModel._SearchCriteria.Resources = new List<ResSection>();
                var selectedOutPatientResource = CurrentResource.SelectedOutPatientResource;
                if (selectedOutPatientResource != null && selectedOutPatientResource is ResPoliclinic)
                {
                    viewModel._SearchCriteria.Resources.Add(selectedOutPatientResource);
                }
                else if (selectedOutPatientResource != null && selectedOutPatientResource is ResDepartment)
                {

                    ResDepartment resDepartment = (ResDepartment)objectContext.GetObject(selectedOutPatientResource.ObjectID, "ResDepartment");
                    foreach (var sResource in resDepartment.Policlinics)
                    {
                        viewModel._SearchCriteria.Resources.Add(sResource);
                    }
                }

                #endregion

                #region EpisodeAction Tipi Se�imi


                #endregion

                #region  state sorgular�


                #endregion

                objectContext.FullPartialllyLoadedObjects();

                if (Common.CurrentUser.HasRole(TTRoleNames.Bastabip) || Common.CurrentUser.HasRole(TTRoleNames.Bastabip_Yardimcisi))
                    viewModel.hasHeadDoctorRole = true;
                else
                    viewModel.hasHeadDoctorRole = false;

                viewModel.isNewLcd = TTObjectClasses.SystemParameter.GetParameterValue("ISNEWLCD", "FALSE");
                return viewModel;
            }
        }

        [HttpGet]
        public ExaminationWorkListViewModel getHeadDoctorApproveReports(DateTime? startDate, DateTime? endDate)
        {
            DateTime WorkListStartDate = Common.RecTime();
            DateTime WorkListEndDate = Common.RecTime();
            if (startDate.HasValue)
                WorkListStartDate = Convert.ToDateTime(startDate.Value.ToShortDateString() + " " + "00:00:00");

            if (endDate.HasValue)
                WorkListEndDate = Convert.ToDateTime(endDate.Value.ToShortDateString() + " " + "23:59:59");

            string whereCriteria_For_ParticipatnFreeDrugReport = " AND this.REQUESTDATE BETWEEN " + GetDateAsString(WorkListStartDate) + " AND " + GetDateAsString(WorkListEndDate);
            string whereCriteria_For_MedicalStuffReport = " AND this.REQUESTDATE BETWEEN " + GetDateAsString(WorkListStartDate) + " AND " + GetDateAsString(WorkListEndDate);
            whereCriteria_For_ParticipatnFreeDrugReport += " AND this.CURRENTSTATEDEFID IN(States.Approval)";
            whereCriteria_For_MedicalStuffReport += " AND this.CURRENTSTATEDEFID IN(States.HeadDoctorApproval)";
            var viewModel = new ExaminationWorkListViewModel();

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var reportList = ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL(objectContext, whereCriteria_For_ParticipatnFreeDrugReport);
                foreach (var reportFWL in reportList)
                {
                    ParticipatnFreeDrugReport participatnFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "ParticipatnFreeDrugReport");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, participatnFreeDrugReport))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = participatnFreeDrugReport.Episode;
                        workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = "�la� Raporu";// reportFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)reportFWL.ObjectID;

                        // Ikon set etmece
                        string PriorityStatus = reportFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);
                        //
                        if (reportFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                        workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                        workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                        workListItem.ResourceName = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();

                        if (reportFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = reportFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }


                        viewModel.WorkList.Add(workListItem);
                        // GENEL                         
                        //
                    }
                }

                var stuffReportList = MedicalStuffReport.GetMedicalStuffReportForWL(objectContext, whereCriteria_For_MedicalStuffReport);
                foreach (var reportFWL in stuffReportList)
                {
                    MedicalStuffReport medicalStuffReport = (MedicalStuffReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "MedicalStuffReport");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, medicalStuffReport))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = medicalStuffReport.Episode;
                        workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = "T�bbi Malzeme Raporu";// reportFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)reportFWL.ObjectID;

                        // Ikon set etmece
                        string PriorityStatus = reportFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);
                        //
                        if (reportFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                        workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                        workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                        workListItem.ResourceName = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();

                        if (reportFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = reportFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }


                        viewModel.WorkList.Add(workListItem);
                    }
                }
                return viewModel;
            }
        }


        private ExaminationWorkListSearchCriteria sc
        {
            get;
            set;
        }

        private bool bekleyen
        {
            get
            {
                return sc.ActionStatus.Exists(x => x.TypeID == 0);
            }
        }

        private bool takipte
        {
            get
            {
                return sc.ActionStatus.Exists(x => x.TypeID == 1);
            }
        }

        private bool tamamlanan
        {
            get
            {
                return sc.ActionStatus.Exists(x => x.TypeID == 2);
            }
        }

        private bool reddedilen
        {
            get
            {
                return sc.ActionStatus.Exists(x => x.TypeID == 3);
            }
        }

        private bool showPatientCallStatus
        {
            get
            {
                return bekleyen;
            }
        }

        private ResUser CurrentUser
        {
            get
            {
                return Common.CurrentResource;
            }
        }
        string whereCriteria_For_PatientExamination = string.Empty;
        string whereCriteria_For_EmergencyIntervention = string.Empty;
        string whereCriteria_For_Consultation = string.Empty;
        string whereCriteria_For_Result = string.Empty;
        string whereCriteria_For_HCExamination = string.Empty;
        string whereCriteria_For_DentalExamination = string.Empty;
        string whereCriteria_For_ParticipatnFreeDrugReport = string.Empty;
        string whereCriteria_For_MedicalStuffReport = string.Empty;
        int workListMaxItemCount = Common.WorklistMaxItemCount();
        int counter = 0;

        private string generateWhereCriteriaForPatientExamination()
        {
            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_PatientExamination = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                    whereCriteria_For_PatientExamination += " AND this.PatientExaminationType <> " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                }
                else
                {
                    whereCriteria_For_PatientExamination = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                    whereCriteria_For_PatientExamination += " AND this.PatientExaminationType <> " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_PatientExamination = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_PatientExamination += " AND this.PatientExaminationType <> " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                }
                else if (sc.policlinic_EA == true)
                {
                    //Muayene i�in
                    if (sc.ActionNames.Exists(x => x.TypeID == 0))
                    {
                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                            whereCriteria_For_PatientExamination += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        string examination_States = string.Empty;

                        if (bekleyen)//Bekleyen
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Examination";
                        }
                        if (takipte)//Takipte
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.ExaminationCompleted,States.ProcedureRequested";
                        }
                        if (tamamlanan)//Tamamlanan
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Completed";
                        }

                        if (reddedilen)//Reddedilen
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Cancelled,States.PatientNoShown";
                        }

                        if (!string.IsNullOrEmpty(examination_States))
                        {
                            if (takipte || tamamlanan)
                                whereCriteria_For_PatientExamination += " AND (this.CURRENTSTATEDEFID IN(" + examination_States + ") OR this.EmergencyIntervention.InPatientPhysicianApplications(this.CURRENTSTATEDEFID <> States.Cancelled).EXISTS)";
                            else
                                whereCriteria_For_PatientExamination += " AND this.CURRENTSTATEDEFID IN(" + examination_States + ")";

                            // Birim ile ilgili sorgular 
                            string whereCriteria_Resource = string.Empty;
                            foreach (var resource in sc.Resources)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_Resource))
                                    whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                                whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                            }
                            if (!string.IsNullOrEmpty(whereCriteria_Resource))
                            {
                                whereCriteria_For_PatientExamination += whereCriteria_Resource + ") ";
                            }

                            // Yanl�z kendi Hastalar�m sorgusu 
                            if (sc.PatientType == 1)
                                whereCriteria_For_PatientExamination += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                            whereCriteria_For_PatientExamination += " AND this.PatientExaminationType <> " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                        }
                    }
                }
            }
            return whereCriteria_For_PatientExamination;
        }

        private string generateWhereCriteriaForEmergencyIntervention()
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("POLIKLINIKMODULUACILHASTAISLEMLERI", "FALSE") == "FALSE")
                return String.Empty;

            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_EmergencyIntervention = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                }
                else
                {
                    whereCriteria_For_EmergencyIntervention = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                }
            }
            else
            {

                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_EmergencyIntervention = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else if (sc.policlinic_EA == true)
                {
                    if (sc.ActionNames.Exists(x => x.TypeID == 0))
                    {
                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                        {
                            whereCriteria_For_EmergencyIntervention += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);
                        }
                        string emergency_States = string.Empty;

                        if (bekleyen)//Bekleyen
                        {
                            if (!string.IsNullOrEmpty(emergency_States))
                                emergency_States += ",";
                            emergency_States += "States.Triage";

                        }
                        if (takipte)//Takipte
                        {
                            if (!string.IsNullOrEmpty(emergency_States))
                                emergency_States += ",";
                            emergency_States += "States.Observation,States.InpatientObservation";
                        }
                        if (tamamlanan)//Tamamlanan
                        {
                            if (!string.IsNullOrEmpty(emergency_States))
                                emergency_States += ",";
                            emergency_States += "States.Completed";
                        }
                        if (reddedilen)//Reddedilen
                        {
                            if (!string.IsNullOrEmpty(emergency_States))
                                emergency_States += ",";
                            emergency_States += "States.Cancelled,States.Missing";
                        }

                        if (!string.IsNullOrEmpty(emergency_States))
                        {
                            whereCriteria_For_EmergencyIntervention += " AND this.CURRENTSTATEDEFID IN(" + emergency_States + ")";

                            // Birim ile ilgili sorgular 
                            string whereCriteria_Resource = string.Empty;
                            foreach (var resource in sc.Resources)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_Resource))
                                    whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                                whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                            }
                            if (!string.IsNullOrEmpty(whereCriteria_Resource))
                            {
                                whereCriteria_For_EmergencyIntervention += whereCriteria_Resource + ") ";
                            }

                            // Yanl�z kendi Hastalar�m sorgusu 
                            if (sc.PatientType == 1)
                                whereCriteria_For_EmergencyIntervention += " AND this.PatientExaminations(this.ProcedureDoctor = '" + CurrentUser.ObjectID + "').EXISTS";
                        }
                    }
                }
            }

            return whereCriteria_For_EmergencyIntervention;
        }

        private string generateWhereCriteriaForConsultation()
        {

            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_Consultation = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                }
                else
                {
                    whereCriteria_For_Consultation = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_Consultation = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else if (sc.policlinic_EA == true)
                {
                    //Kons�ltasyon i�in 
                    if (sc.ActionNames.Exists(x => x.TypeID == 1))
                    {

                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                            whereCriteria_For_Consultation += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        string cons_States = string.Empty;

                        if (bekleyen)//Bekleyen
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.NewRequest,States.Appointment,States.InsertedIntoQueue,States.RequestAcception";
                        }
                        if (takipte)//Takipte
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.Consultation";
                        }
                        if (tamamlanan)//Tamamlanan
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.Completed";
                        }
                        if (reddedilen)//Reddedilen
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.Cancelled,States.PatientNoShown";
                        }

                        string whereCriteria_For_ToMe_Consultation = string.Empty;
                        if (!string.IsNullOrEmpty(cons_States))
                        {
                            whereCriteria_For_ToMe_Consultation += " AND this.CURRENTSTATEDEFID IN(" + cons_States + ")";

                            // Birim ile ilgili sorgular 
                            string whereCriteria_Resource = string.Empty;
                            foreach (var resource in sc.Resources)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_Resource))
                                    whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                                whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                            }
                            if (!string.IsNullOrEmpty(whereCriteria_Resource))
                            {
                                whereCriteria_For_ToMe_Consultation += whereCriteria_Resource + ") ";
                            }

                            // Yanl�z kendi Hastalar�m sorgusu 
                            if (sc.PatientType == 1)
                                whereCriteria_For_ToMe_Consultation += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                        }

                        whereCriteria_For_Consultation += whereCriteria_For_ToMe_Consultation;
                    }
                }
            }

            return whereCriteria_For_Consultation;
        }

        private string generateWhereCriteriaForResult()
        {
            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_Result = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                }
                else
                {
                    whereCriteria_For_Result = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_Result = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else if (sc.policlinic_EA == true)
                {
                    //Sonu� i�in
                    if (sc.ActionNames.Exists(x => x.TypeID == 3))
                    {
                        // Ba�lang�� - Biti� Tarihi ile ilgili sorgu  Giden ve gelen i�in Ortak
                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                            whereCriteria_For_Result += " AND this.QueueItems(CALLTIME BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) + " AND ISRESULTEXAMINATION = 1 AND CURRENTSTATEDEFID IN (States.New,States.Diverted)).EXISTS ";

                        string not_in_examination_States = string.Empty;

                        if (!string.IsNullOrEmpty(not_in_examination_States))
                            not_in_examination_States += ",";
                        not_in_examination_States += "States.Cancelled,States.PatientNoShown";

                        if (!string.IsNullOrEmpty(not_in_examination_States))
                        {
                            whereCriteria_For_Result += " AND this.CURRENTSTATEDEFID NOT IN(" + not_in_examination_States + ")";

                            // Birim ile ilgili sorgular 
                            string whereCriteria_Resource = string.Empty;
                            foreach (var resource in sc.Resources)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_Resource))
                                    whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                                whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                            }
                            if (!string.IsNullOrEmpty(whereCriteria_Resource))
                            {
                                whereCriteria_For_Result += whereCriteria_Resource + ") ";
                            }

                            // Yanl�z kendi Hastalar�m sorgusu 
                            if (sc.PatientType == 1)
                                whereCriteria_For_Result += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                        }
                    }
                }
            }

            return whereCriteria_For_Result;
        }

        private string generateWhereCriteriaForHCExamination()
        {
            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_HCExamination = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                    whereCriteria_For_HCExamination += " AND this.PatientExaminationType = " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                }
                else
                {
                    whereCriteria_For_HCExamination = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                    whereCriteria_For_HCExamination += " AND this.PatientExaminationType = " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_HCExamination = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_HCExamination += " AND this.PatientExaminationType = " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                }
                else if (sc.policlinic_EA == true)
                {
                    //Sa�l�k Kurulu i�in
                    if (sc.ActionNames.Exists(x => x.TypeID == 2))
                    {
                        //Sa�l�k Kurulu Muayenesi
                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                            whereCriteria_For_HCExamination += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        string examination_States = string.Empty;
                        if (bekleyen)//Bekleyen
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Examination";
                        }
                        if (takipte)//Takipte
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.ExaminationCompleted,States.ProcedureRequested";
                        }
                        if (tamamlanan)//Tamamlanan
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Completed";
                        }
                        if (reddedilen)//Reddedilen
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Cancelled,States.PatientNoShown";
                        }

                        if (!string.IsNullOrEmpty(examination_States))
                        {
                            whereCriteria_For_HCExamination += " AND this.CURRENTSTATEDEFID IN(" + examination_States + ")";

                            // Birim ile ilgili sorgular 
                            string whereCriteria_Resource = string.Empty;
                            foreach (var resource in sc.Resources)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_Resource))
                                    whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                                whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                            }
                            if (!string.IsNullOrEmpty(whereCriteria_Resource))
                            {
                                whereCriteria_For_HCExamination += whereCriteria_Resource + ") ";
                            }

                            // Yanl�z kendi Hastalar�m sorgusu 
                            if (sc.PatientType == 1)
                                whereCriteria_For_HCExamination += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                            whereCriteria_For_HCExamination += " AND this.PatientExaminationType = " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
                        }
                    }
                }
            }
            return whereCriteria_For_HCExamination;
        }

        private string generateWhereCriteriaForDentalExamination()
        {
            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_DentalExamination = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                }
                else
                {
                    whereCriteria_For_DentalExamination = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_DentalExamination = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else if (sc.policlinic_EA == true)
                {
                    //Di� Muayene i�in
                    if (sc.ActionNames.Exists(x => x.TypeID == 4))
                    {
                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                            whereCriteria_For_DentalExamination += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        string examination_States = string.Empty;
                        //if (bekleyen && !takipte && !tamamlanan && !reddedilen)
                        //{
                        //    if (sc.doNotListCalleds)
                        //        whereCriteria_For_DentalExamination += " AND NOT this.QueueItems(CALLTIME BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) + " AND CALLCOUNT > 0 AND CURRENTSTATEDEFID IN (States.New,States.Diverted)).EXISTS ";
                        //}
                        if (bekleyen)//Bekleyen
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.New,States.Examination,States.Appointment,States.OrderedPatient";
                        }
                        if (takipte)//Takipte
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.ExaminationCompleted,States.ProcedureRequested";
                        }
                        if (tamamlanan)//Tamamlanan
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Completed";
                        }
                        if (reddedilen)//Reddedilen
                        {
                            if (!string.IsNullOrEmpty(examination_States))
                                examination_States += ",";
                            examination_States += "States.Cancelled,States.PatientNoShown";
                        }


                        if (!string.IsNullOrEmpty(examination_States))
                        {
                            whereCriteria_For_DentalExamination += " AND this.CURRENTSTATEDEFID IN(" + examination_States + ")";

                            // Birim ile ilgili sorgular 
                            string whereCriteria_Resource = string.Empty;
                            foreach (var resource in sc.Resources)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_Resource))
                                    whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                                whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                            }
                            if (!string.IsNullOrEmpty(whereCriteria_Resource))
                            {
                                whereCriteria_For_DentalExamination += whereCriteria_Resource + ") ";
                            }

                            // Yanl�z kendi Hastalar�m sorgusu 
                            if (sc.PatientType == 1)
                                whereCriteria_For_DentalExamination += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                        }
                    }
                }
            }
            return whereCriteria_For_DentalExamination;
        }

        private string generateWhereCriteriaForParticipatnFreeDrugReport()
        {
            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_ParticipatnFreeDrugReport = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                }
                else
                {
                    whereCriteria_For_ParticipatnFreeDrugReport = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_ParticipatnFreeDrugReport = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else if (sc.participatnFreeDrugReport_EA == true)
                {
                    //Hasta Kat�l�m Pay�ndan Muaf �la� Raporu
                    string report_States = string.Empty;
                    if (String.IsNullOrEmpty(sc.PatientObjectID))
                        whereCriteria_For_ParticipatnFreeDrugReport += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                    report_States = string.Empty;
                    if (sc.ReportStatus.Exists(x => x.TypeID == 0))//raporda
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.New,States.Report,States.Completed";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 1))//ikinci - ���nc� doktor onay�nda
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.SecondDoctorApproval,States.ThirdDoctorApproval";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 2))//Ba�hekim onay�nda
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.Approval";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 3))//Tamamlanan
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.ReportCompleted";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 4))//Reddedilen
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.Cancelled";
                    }

                    //Rapor takip numaras� girildiyse state e bak�lmas�n
                    if (!String.IsNullOrEmpty(sc.ReportChasingNo))
                        whereCriteria_For_ParticipatnFreeDrugReport += " AND THIS.MEDULAREPORTRESULTS(THIS.REPORTCHASINGNO = '" + sc.ReportChasingNo.Trim() + "').EXISTS ";
                    else if (!string.IsNullOrEmpty(report_States))
                    {
                        whereCriteria_For_ParticipatnFreeDrugReport += " AND this.CURRENTSTATEDEFID IN(" + report_States + ")";

                        bool isBasTabip = false;
                        if (ResUser.HasRole(CurrentUser, Common.BashekimRoleID) || ResUser.HasRole(CurrentUser, Common.NobetciBashekimRoleID))
                            isBasTabip = true;

                        // Yanl�z kendi Hastalar�m sorgusu 
                        //if (sc.PatientType == 1)
                        if (isBasTabip == false && Common.CurrentUser.IsSuperUser == false) //Ba�tabip de�ilse 1.,2. ve 3. doktora baks�n. sadece Onlar�n i� listesine gelsin.
                            whereCriteria_For_ParticipatnFreeDrugReport += " AND (this.ProcedureDoctor = '" + CurrentUser.ObjectID + "' OR this.SecondDoctor = '" + CurrentUser.ObjectID + "' OR this.ThirdDoctor = '" + CurrentUser.ObjectID + "' ) ";
                    }
                }
            }
            return whereCriteria_For_ParticipatnFreeDrugReport;
        }

        private string generateWhereCriteriaForMedicalStuffReport()
        {
            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                {
                    whereCriteria_For_MedicalStuffReport = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                }
                else
                {
                    whereCriteria_For_MedicalStuffReport = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_MedicalStuffReport = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else if (sc.participatnFreeDrugReport_EA == true)
                {
                    //T�bbi Malzeme Raporu
                    string report_States = string.Empty;

                    if (String.IsNullOrEmpty(sc.PatientObjectID))
                        whereCriteria_For_MedicalStuffReport += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                    report_States = string.Empty;
                    if (sc.ReportStatus.Exists(x => x.TypeID == 0))//Bekleyen
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.New";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 1))//Takipte
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.SecondDoctorApproval,States.ThirdDoctorApproval";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 2))//Ba�hekim onay�nda
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.HeadDoctorApproval";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 3))//Tamamlanan
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.Complete";
                    }
                    if (sc.ReportStatus.Exists(x => x.TypeID == 4))//Reddedilen
                    {
                        if (!string.IsNullOrEmpty(report_States))
                            report_States += ",";
                        report_States += "States.Cancel";
                    }

                    if (!String.IsNullOrEmpty(sc.ReportChasingNo))
                        whereCriteria_For_MedicalStuffReport += " AND THIS.RaporTakipNo = '" + sc.ReportChasingNo.Trim() + "' ";
                    else if (!string.IsNullOrEmpty(report_States))
                    {
                        whereCriteria_For_MedicalStuffReport += " AND this.CURRENTSTATEDEFID IN(" + report_States + ")";
                        bool isBasTabip = false;
                        if (ResUser.HasRole(CurrentUser, Common.BashekimRoleID) || ResUser.HasRole(CurrentUser, Common.NobetciBashekimRoleID))
                            isBasTabip = true;

                        // Yanl�z kendi Hastalar�m sorgusu 
                        //if (sc.PatientType == 1)
                        if (isBasTabip == false && Common.CurrentUser.IsSuperUser == false) //Ba�tabip de�ilse 1.,2. ve 3. doktora baks�n. sadece Onlar�n i� listesine gelsin.
                            whereCriteria_For_MedicalStuffReport += " AND (this.ProcedureDoctor = '" + CurrentUser.ObjectID + "' OR this.SecondDoctor = '" + CurrentUser.ObjectID + "' OR this.ThirdDoctor = '" + CurrentUser.ObjectID + "' ) ";
                    }
                }
            }
            return whereCriteria_For_MedicalStuffReport;
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Ayaktan_Hasta_Listesi)]
        public ExaminationWorkListViewModel GetExaminationWorkList(ExaminationWorkListSearchCriteria _sc)
        {
            if (_sc == null)
            {
                throw new Exception("Arama kriterleri girilmeden sorgulama yap�lamaz.");
            }

            if (_sc.WorkListStartDate == null || _sc.WorkListEndDate == null)
            {
                if (String.IsNullOrEmpty(_sc.PatientObjectID))
                    throw new Exception("Ba�lang�� - Biti� Tarihi girilmeden sorgulama yap�lamaz.");
            }
            if (_sc.WorkListStartDate.HasValue)
                _sc.WorkListStartDate = Convert.ToDateTime(_sc.WorkListStartDate.Value.ToShortDateString() + " " + "00:00:00");

            if (_sc.WorkListEndDate.HasValue)
                _sc.WorkListEndDate = Convert.ToDateTime(_sc.WorkListEndDate.Value.ToShortDateString() + " " + "23:59:59");

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                // GENEL 
                sc = _sc;
                var viewModel = new ExaminationWorkListViewModel();
                viewModel.WorkList = new List<ExaminationWorkListItem>();
                List<ExaminationWorkListItem> examinationWL = new List<ExaminationWorkListItem>();
                viewModel.maxWorklistItemCount = 0;
                //
                whereCriteria_For_PatientExamination = generateWhereCriteriaForPatientExamination();
                whereCriteria_For_EmergencyIntervention = generateWhereCriteriaForEmergencyIntervention();
                whereCriteria_For_Consultation = generateWhereCriteriaForConsultation();
                whereCriteria_For_Result = generateWhereCriteriaForResult();
                whereCriteria_For_HCExamination = generateWhereCriteriaForHCExamination();
                whereCriteria_For_DentalExamination = generateWhereCriteriaForDentalExamination();
                whereCriteria_For_ParticipatnFreeDrugReport = generateWhereCriteriaForParticipatnFreeDrugReport();
                whereCriteria_For_MedicalStuffReport = generateWhereCriteriaForMedicalStuffReport();

                Common.QueueItems queueItems = null;
                if (Common.CurrentResource.SelectedQueue != null)
                {
                    ExaminationQueueDefinition qDef = objectContext.GetObject<ExaminationQueueDefinition>(Common.CurrentResource.SelectedQueue.ObjectID);
                    if (qDef.ResSection != null)
                    {
                        if (qDef.ResSection.ExaminationQueueDefinitions.Where(q => q.IsActive != false).ToList().Count == 1)
                            queueItems = Common.GetSortedQueue(Common.CurrentResource.SelectedQueue.ObjectID, false);
                    }
                }

                #region SORGULAR
                List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
                //MUAYENE
                examinationWorkListItems = getPatientExaminationWorkListItems(objectContext, queueItems);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }

                //AC�L HASTA ��LEMLER�
                examinationWorkListItems = getEmergencyInterventionWorkListItems(objectContext, queueItems);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }

                //KONSULTASYON
                examinationWorkListItems = getConsultationWorkListItems(objectContext, queueItems);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }

                //SA�LIK KURULU MUAYENES�
                examinationWorkListItems = getHCExaminationWorkListItems(objectContext, queueItems);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }

                //SONU�
                examinationWorkListItems = getResultWorkListItems(objectContext, queueItems, examinationWL);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }

                //D�� MUAYENE
                examinationWorkListItems = getDentalExaminationWorkListItems(objectContext, queueItems);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }

                //Hasta Kat�l�m Pay�ndan Muaf �la� Raporu
                examinationWorkListItems = getParticipatnFreeDrugReportWorkListItems(objectContext, queueItems);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }

                ////T�bbi Malzeme Raporu
                examinationWorkListItems = getMedicalStuffReportWorkListItems(objectContext, queueItems);
                if (examinationWorkListItems.Count > 0)
                {
                    examinationWL.AddRange(examinationWorkListItems);
                    viewModel.maxWorklistItemCount += examinationWorkListItems.Count;
                }
                #endregion


                //viewModel.WorkList = examinationWL.OrderBy(e => Convert.ToDateTime(e.Date.ToShortDateString())).ThenBy(e => e.QueueNumberToSort).ToList();
                viewModel.WorkList = examinationWL.OrderBy(e => e.QueueNumberToSort).ThenBy(e => e.Date).ToList();
                return viewModel;
            }
        }

        private ExaminationWorkListItem getInterventionWorkListItem(TTObjectContext objectContext, PatientExamination patientExamination, PatientExamination.GetPatientExaminationForWL_Class examFWL, Common.QueueItems queueItems)
        {
            InPatientPhysicianApplication inPatientPhysicianApplication = null;
            ExaminationWorkListItem workListItem = null;
            if (patientExamination.EmergencyIntervention != null && patientExamination.EmergencyIntervention.InPatientPhysicianApplications != null && patientExamination.EmergencyIntervention.InPatientPhysicianApplications.Count > 0)
            {
                foreach (InPatientPhysicianApplication physicianApplication in patientExamination.EmergencyIntervention.InPatientPhysicianApplications)
                {
                    if (physicianApplication.IsCancelled != true)
                    {
                        InPatientPhysicianApplication _inPatientPhysicianApplication = physicianApplication;
                        if (this.HasWorkListWorkListRight(objectContext, _inPatientPhysicianApplication))
                        {
                            if (takipte && (_inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Application || _inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.PreDischarged))
                            {
                                inPatientPhysicianApplication = _inPatientPhysicianApplication;
                                break;
                            }
                            if (tamamlanan && _inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Discharged)
                            {
                                inPatientPhysicianApplication = _inPatientPhysicianApplication;
                                break;
                            }
                        }
                    }
                }
            }

            if (inPatientPhysicianApplication != null)
            {
                workListItem = new ExaminationWorkListItem();
                workListItem.ObjectDefID = inPatientPhysicianApplication.ObjectDef.ID.ToString();
                workListItem.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
                workListItem.ObjectID = inPatientPhysicianApplication.ObjectID;
                workListItem.Date = Convert.ToDateTime(inPatientPhysicianApplication.RequestDate);
                workListItem.EpisodeActionName = String.IsNullOrEmpty(inPatientPhysicianApplication.ObjectDef.DisplayText) ? inPatientPhysicianApplication.ObjectDef.Description : inPatientPhysicianApplication.ObjectDef.DisplayText;
                workListItem.StateName = inPatientPhysicianApplication.CurrentStateDef == null ? "" : inPatientPhysicianApplication.CurrentStateDef.DisplayText;
                workListItem.ResourceName = inPatientPhysicianApplication.MasterResource == null ? "" : inPatientPhysicianApplication.MasterResource.Name;
                workListItem.DoctorName = inPatientPhysicianApplication.ProcedureDoctor == null ? "" : inPatientPhysicianApplication.ProcedureDoctor.Name;
                workListItem.ExaminationProtocolNo = inPatientPhysicianApplication.ProtocolNo == null ? "" : inPatientPhysicianApplication.ProtocolNo.ToString();
                workListItem.isEmergency = true;
                foreach (var item in inPatientPhysicianApplication.SpecialityBasedObject)
                {
                    if (item != null && item is EmergencySpecialityObject)
                    {
                        workListItem.Triage = ((EmergencySpecialityObject)item).Triage != null ? ((EmergencySpecialityObject)item).Triage.ADI : "";
                    }
                }

                //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                var episode = patientExamination.Episode;
                // Ikon set etmece
                string PriorityStatus = examFWL.Prioritystatus;
                this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                    workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                else
                {
                    if (workListItem.isPatientDrugAllergic)
                        workListItem.MedicalInformation = "�la� Alerjisi Var";

                    if (workListItem.isPatientFoodAllergic)
                        workListItem.MedicalInformation = "G�da Alerjisi Var";
                }

                if (workListItem.isPatientOtherAllergic)
                    workListItem.MedicalInformation = "Di�er";



                workListItem.PatientNameSurname = examFWL.Patientnamesurname.ToString();

                if (workListItem.Triage == null || workListItem.Triage == "")
                    workListItem.Triage = examFWL.Triage;

                workListItem.KabulNo = examFWL.Kabulno == null ? "" : examFWL.Kabulno.ToString();
                workListItem.UniqueRefno = examFWL.UniqueRefNo == null ? "" : examFWL.UniqueRefNo.ToString();
                workListItem.ComingReason = examFWL.Admissiontype == null ? "" : examFWL.Admissiontype.ToString();  // Geli� Sebebi
                workListItem.PayerInfo = examFWL.Payername == null ? "" : examFWL.Payername.ToString();
                workListItem.PatientClassGroup = examFWL.Hastaturu == null ? "" : examFWL.Hastaturu.ToString();
                workListItem.ApplicationReason = examFWL.Basvuruturu == null ? "" : examFWL.Basvuruturu.ToString();
                if (examFWL.BirthDate != null)
                {
                    workListItem.BirthDate = examFWL.BirthDate.Value; // Do�um Tarihi
                    var FullAge = Common.CalculateAge(workListItem.BirthDate);
                    workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                }
                workListItem.FatherName = examFWL.FatherName == null ? "" : examFWL.FatherName.ToString();  // Baba ad�
                workListItem.PhoneNumber = examFWL.Telno == null ? "" : examFWL.Telno.ToString();  // Telefon Numaras�
                if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(patientExamination.Episode.Patient.ObjectID)))
                    workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(patientExamination.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                else
                    workListItem.QueueNumberToSort = 5000;

                Appointment appointment = null;
                if (patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment != null && patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                {
                    foreach (Appointment app in patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments)
                    {
                        if (app.MasterResource.ObjectID.Equals(patientExamination.MasterResource.ObjectID) && patientExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                        {
                            appointment = app;
                            break;
                        }
                    }
                }

                if (appointment != null)
                {
                    workListItem.AdmissionQueueNo = appointment.StartTime.Value.ToShortTimeString();
                }
                else
                {
                    if (patientExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                    {
                        if (patientExamination.WorkListDate.HasValue)
                            workListItem.Date = (DateTime)patientExamination.WorkListDate.Value;
                    }
                    workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(patientExamination, patientExamination.SubEpisode.PatientAdmission, true, appointment == null);

                }

                workListItem.Diagnosis = patientExamination.SubEpisode.GetDiagnosisAsStringForWorkList();
            }
            return workListItem;
        }

        private List<ExaminationWorkListItem> getPatientExaminationWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_PatientExamination))
            {
                var examinationList = PatientExamination.GetPatientExaminationForWL(objectContext, whereCriteria_For_PatientExamination);
                foreach (var examFWL in examinationList)
                {
                    PatientExamination patientExamination = (PatientExamination)objectContext.GetObject((Guid)examFWL.ObjectID, "PatientExamination");
                    //InPatientPhysicianApplication inPatientPhysicianApplication = null;
                    bool addWorkListItem = true;
                    if (bekleyen && sc.doNotListCalleds)
                    {
                        ExaminationQueueItem queueItem = patientExamination.GetActiveQueueItem(false);
                        if (queueItem != null)
                        {
                            if (queueItem.CallCount.HasValue && queueItem.CallCount.Value > 0)
                                addWorkListItem = false;
                        }
                    }
                    // GENEL 
                    if (addWorkListItem && this.HasWorkListWorkListRight(objectContext, patientExamination))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();

                        if (patientExamination.PatientExaminationType.HasValue)
                        {
                            workListItem.EpisodeActionName = Common.GetDisplayTextOfDataTypeEnum(patientExamination.PatientExaminationType.Value);
                            if (patientExamination.PatientExaminationType.Value == PatientExaminationEnum.Emergency)
                                workListItem.isEmergency = true;
                        }
                        else
                        {
                            foreach (ResourceSpecialityGrid resourceSpecialityGrid in patientExamination.MasterResource.ResourceSpecialities)
                            {
                                if (resourceSpecialityGrid.Speciality != null && resourceSpecialityGrid.Speciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.EmergencySpecialityObject)
                                {
                                    workListItem.EpisodeActionName = Common.GetDisplayTextOfDataTypeEnum(SpecialityBasedObjectEnum.EmergencySpecialityObject);
                                    workListItem.isEmergency = true;
                                    break;
                                }
                            }
                        }

                        if (workListItem.isEmergency == true)
                        {
                            ExaminationWorkListItem interventionWorkListItem = getInterventionWorkListItem(objectContext, patientExamination, examFWL, queueItems);
                            if (interventionWorkListItem != null)
                                examinationWorkListItems.Add(interventionWorkListItem);

                        }

                        workListItem.isEmergency = examFWL.Isemergency == true ? true : false;

                        if (takipte && !tamamlanan && patientExamination.CurrentStateDefID == PatientExamination.States.Completed)
                            addWorkListItem = false;
                        if (showPatientCallStatus)
                            workListItem.PatientCallStatus = getPatientCallStatus(patientExamination);
                        workListItem.ObjectDefID = examFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = examFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)examFWL.ObjectID;
                        if (examFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(examFWL.Date);
                        if (String.IsNullOrEmpty(workListItem.EpisodeActionName))
                            workListItem.EpisodeActionName = examFWL.Episodeactionname == null ? "" : examFWL.Episodeactionname.ToString();
                        workListItem.StateName = examFWL.Statename == null ? "" : examFWL.Statename.ToString();
                        workListItem.ResourceName = examFWL.Masterresource == null ? "" : examFWL.Masterresource.ToString();
                        workListItem.DoctorName = examFWL.Doctorname == null ? "" : examFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = examFWL.Examinationprotocolno == null ? "" : examFWL.Examinationprotocolno.ToString();


                        foreach (var item in patientExamination.SpecialityBasedObject)
                        {
                            if (item != null && item is EmergencySpecialityObject)
                            {
                                workListItem.Triage = ((EmergencySpecialityObject)item).Triage != null ? ((EmergencySpecialityObject)item).Triage.ADI : "";
                            }
                        }

                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = patientExamination.Episode;
                        // Ikon set etmece
                        string PriorityStatus = examFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                                workListItem.MedicalInformation = "�la� Alerjisi Var";

                            if (workListItem.isPatientFoodAllergic)
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                        }

                        if (workListItem.isPatientOtherAllergic)
                            workListItem.MedicalInformation = "Di�er";



                        workListItem.PatientNameSurname = examFWL.Patientnamesurname.ToString();

                        if (workListItem.Triage == null || workListItem.Triage == "")
                            workListItem.Triage = examFWL.Triage;

                        workListItem.KabulNo = examFWL.Kabulno == null ? "" : examFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = examFWL.UniqueRefNo == null ? "" : examFWL.UniqueRefNo.ToString();
                        workListItem.ComingReason = examFWL.Admissiontype == null ? "" : examFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = examFWL.Payername == null ? "" : examFWL.Payername.ToString();
                        workListItem.PatientClassGroup = examFWL.Hastaturu == null ? "" : examFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = examFWL.Basvuruturu == null ? "" : examFWL.Basvuruturu.ToString();
                        if (examFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = examFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = examFWL.FatherName == null ? "" : examFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = examFWL.Telno == null ? "" : examFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(patientExamination.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(patientExamination.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;

                        Appointment appointment = null;
                        if (patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment != null && patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                        {
                            foreach (Appointment app in patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments)
                            {
                                if (app.MasterResource.ObjectID.Equals(patientExamination.MasterResource.ObjectID) && patientExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                {
                                    appointment = app;
                                    break;
                                }
                            }
                        }

                        if (appointment != null)
                        {
                            workListItem.AdmissionQueueNo = appointment.StartTime.Value.ToShortTimeString();
                        }
                        else
                        {
                            if (patientExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                            {
                                if (patientExamination.WorkListDate.HasValue)
                                    workListItem.Date = (DateTime)patientExamination.WorkListDate.Value;
                            }
                            workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(patientExamination, patientExamination.SubEpisode.PatientAdmission, true, appointment == null);

                        }

                        workListItem.Diagnosis = patientExamination.SubEpisode.GetDiagnosisAsStringForWorkList();
                        if (addWorkListItem == true)
                        {
                            examinationWorkListItems.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                //viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private List<ExaminationWorkListItem> getEmergencyInterventionWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_EmergencyIntervention))
            {
                var emergencyList = EmergencyIntervention.GetEmergencyInterventionForWL(objectContext, whereCriteria_For_EmergencyIntervention);
                foreach (var emergencyFWL in emergencyList)
                {
                    EmergencyIntervention emergencyIntervention = (EmergencyIntervention)objectContext.GetObject((Guid)emergencyFWL.ObjectID, "EmergencyIntervention");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, emergencyIntervention))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = emergencyIntervention.Episode;
                        workListItem.ObjectDefID = emergencyFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = emergencyFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)emergencyFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = emergencyFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "�la� Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Di�er";
                        }

                        if (emergencyFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(emergencyFWL.Date);
                        workListItem.PatientNameSurname = emergencyFWL.Patientnamesurname.ToString();

                        //foreach (var item in patientExamination.SpecialityBasedObject)
                        //{
                        //    if (item is EmergencySpecialityObject && item != null)
                        //    {
                        //        //workListItem.Triage = examFWL.Triage != null ? examFWL.Triage : "";
                        //        workListItem.Triage = ((EmergencySpecialityObject)item).Triage != null ? ((EmergencySpecialityObject)item).Triage.ADI : "";
                        //    }
                        //}

                        workListItem.Triage = emergencyFWL.Triage != null ? emergencyFWL.Triage : "";
                        workListItem.KabulNo = emergencyFWL.Kabulno == null ? "" : emergencyFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = emergencyFWL.UniqueRefNo == null ? "" : emergencyFWL.UniqueRefNo.ToString();
                        workListItem.isEmergency = true;

                        if (String.IsNullOrEmpty(workListItem.EpisodeActionName))
                            workListItem.EpisodeActionName = emergencyFWL.Episodeactionname == null ? "" : emergencyFWL.Episodeactionname.ToString();

                        workListItem.StateName = emergencyFWL.Statename == null ? "" : emergencyFWL.Statename.ToString();
                        workListItem.ResourceName = emergencyFWL.Masterresource == null ? "" : emergencyFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = emergencyFWL.Doctorname == null ? "" : emergencyFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = emergencyFWL.Examinationprotocolno == null ? "" : emergencyFWL.Examinationprotocolno.ToString();
                        workListItem.ComingReason = emergencyFWL.Admissiontype == null ? "" : emergencyFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = emergencyFWL.Payername == null ? "" : emergencyFWL.Payername.ToString();
                        workListItem.PatientClassGroup = emergencyFWL.Hastaturu == null ? "" : emergencyFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = emergencyFWL.Basvuruturu == null ? "" : emergencyFWL.Basvuruturu.ToString();
                        if (emergencyFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = emergencyFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = emergencyFWL.FatherName == null ? "" : emergencyFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = emergencyFWL.Telno == null ? "" : emergencyFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(emergencyIntervention.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(emergencyIntervention.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;

                        if (emergencyIntervention.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                        {
                            if (emergencyIntervention.WorkListDate.HasValue)
                                workListItem.Date = (DateTime)emergencyIntervention.WorkListDate.Value;
                        }
                        workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(emergencyIntervention, emergencyIntervention.SubEpisode.PatientAdmission, true, true);



                        workListItem.Diagnosis = emergencyIntervention.SubEpisode.GetDiagnosisAsStringForWorkList();
                        examinationWorkListItems.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            //viewModel.maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private List<ExaminationWorkListItem> getConsultationWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_Consultation)) // KOns�ltasyon Hastalar� i�in Consultation �zerinden al�nan Sorgu
            {
                var consultationList = Consultation.GetOutPatientConsultationForWL(objectContext, whereCriteria_For_Consultation);
                foreach (var consFWL in consultationList)
                {
                    Consultation consultation = (Consultation)objectContext.GetObject((Guid)consFWL.ObjectID, "Consultation");
                    bool addWorkListItem = true;
                    if (bekleyen && sc.doNotListCalleds)
                    {
                        ExaminationQueueItem queueItem = consultation.GetActiveQueueItem(false);
                        if (queueItem != null)
                        {
                            if (queueItem.CallCount.HasValue && queueItem.CallCount.Value > 0)
                                addWorkListItem = false;
                        }
                    }
                    // GENEL 
                    if (addWorkListItem && this.HasWorkListWorkListRight(objectContext, consultation))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        if (showPatientCallStatus)
                            workListItem.PatientCallStatus = getPatientCallStatus(consultation);
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = consultation.Episode;
                        workListItem.ObjectDefID = consFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = consFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)consFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = consFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "�la� Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Di�er";
                        }


                        workListItem.isEmergency = consFWL.Isemergency == true ? true : false;
                        //

                        if (consFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(consFWL.Date);
                        workListItem.PatientNameSurname = consFWL.Patientnamesurname.ToString();
                        workListItem.Triage = "";
                        workListItem.KabulNo = consFWL.Kabulno == null ? "" : consFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = consFWL.UniqueRefNo == null ? "" : consFWL.UniqueRefNo.ToString();
                        workListItem.EpisodeActionName = consFWL.Episodeactionname == null ? "" : consFWL.Episodeactionname.ToString();
                        workListItem.StateName = consFWL.Statename == null ? "" : consFWL.Statename.ToString();
                        workListItem.ResourceName = consFWL.Masterresource == null ? "" : consFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = consFWL.Doctorname == null ? "" : consFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = consFWL.Examinationprotocolno == null ? "" : consFWL.Examinationprotocolno.ToString();
                        workListItem.ComingReason = consFWL.Admissiontype == null ? "" : consFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = consFWL.Payername == null ? "" : consFWL.Payername.ToString();
                        workListItem.PatientClassGroup = consFWL.Hastaturu == null ? "" : consFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = consFWL.Basvuruturu == null ? "" : consFWL.Basvuruturu.ToString();
                        if (consFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = consFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = consFWL.FatherName == null ? "" : consFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = consFWL.Telno == null ? "" : consFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(consultation.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(consultation.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;

                        Appointment appointment = null;
                        if (consultation.Appointments.Count > 0)
                        {
                            foreach (Appointment app in consultation.Appointments)
                            {
                                if (app.MasterResource.ObjectID.Equals(consultation.MasterResource.ObjectID) && consultation.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                {
                                    appointment = app;
                                    break;
                                }
                            }
                        }

                        if (appointment != null)
                        {
                            workListItem.AdmissionQueueNo = appointment.StartTime.Value.ToShortTimeString();
                            //workListItem.Date = appointment.StartTime.Value;
                        }
                        else
                        {
                            if (consultation.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                            {
                                if (consultation.WorkListDate.HasValue)
                                    workListItem.Date = (DateTime)consultation.WorkListDate.Value;
                            }
                            workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(consultation, consultation.SubEpisode.PatientAdmission, true, appointment == null);

                        }

                        workListItem.Diagnosis = consultation.SubEpisode.GetDiagnosisAsStringForWorkList();
                        examinationWorkListItems.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            //viewModel.maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private List<ExaminationWorkListItem> getHCExaminationWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_HCExamination))
            {
                var hcExaminationList = PatientExamination.GetPatientExaminationForWL(objectContext, whereCriteria_For_HCExamination);
                //var hcExaminationList = HealthCommitteeExamination.GetHCExaminationForWL(objectContext, whereCriteria_For_HCExamination);
                foreach (var hcExamFWL in hcExaminationList)
                {
                    PatientExamination hcExamination = (PatientExamination)objectContext.GetObject((Guid)hcExamFWL.ObjectID, "PatientExamination");
                    bool addWorkListItem = true;
                    if (bekleyen && sc.doNotListCalleds)
                    {
                        ExaminationQueueItem queueItem = hcExamination.GetActiveQueueItem(false);
                        if (queueItem != null)
                        {
                            if (queueItem.CallCount.HasValue && queueItem.CallCount.Value > 0)
                                addWorkListItem = false;
                        }
                    }
                    // GENEL 
                    if (addWorkListItem && this.HasWorkListWorkListRight(objectContext, hcExamination))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        if (showPatientCallStatus)
                            workListItem.PatientCallStatus = getPatientCallStatus(hcExamination);
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = hcExamination.Episode;
                        workListItem.ObjectDefID = hcExamFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = hcExamFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)hcExamFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = hcExamFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "�la� Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Di�er";
                        }

                        workListItem.isEmergency = hcExamFWL.Isemergency == true ? true : false;
                        //

                        if (hcExamFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(hcExamFWL.Date);
                        workListItem.PatientNameSurname = hcExamFWL.Patientnamesurname.ToString();
                        workListItem.Triage = "";
                        workListItem.KabulNo = hcExamFWL.Kabulno == null ? "" : hcExamFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = hcExamFWL.UniqueRefNo == null ? "" : hcExamFWL.UniqueRefNo.ToString();
                        if (hcExamination.PatientExaminationType.HasValue)
                            workListItem.EpisodeActionName = Common.GetDisplayTextOfDataTypeEnum(hcExamination.PatientExaminationType.Value);
                        //workListItem.EpisodeActionName = hcExamFWL.Episodeactionname == null ? "" : hcExamFWL.Episodeactionname.ToString();
                        workListItem.StateName = hcExamFWL.Statename == null ? "" : hcExamFWL.Statename.ToString();
                        workListItem.ResourceName = hcExamFWL.Masterresource == null ? "" : hcExamFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = hcExamFWL.Doctorname == null ? "" : hcExamFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = hcExamFWL.Examinationprotocolno == null ? "" : hcExamFWL.Examinationprotocolno.ToString();
                        workListItem.ComingReason = hcExamFWL.Admissiontype == null ? "" : hcExamFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = hcExamFWL.Payername == null ? "" : hcExamFWL.Payername.ToString();
                        workListItem.PatientClassGroup = hcExamFWL.Hastaturu == null ? "" : hcExamFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = hcExamFWL.Basvuruturu == null ? "" : hcExamFWL.Basvuruturu.ToString();
                        if (hcExamFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = hcExamFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = hcExamFWL.FatherName == null ? "" : hcExamFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = hcExamFWL.Telno == null ? "" : hcExamFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(hcExamination.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(hcExamination.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;
                        Appointment appointment = null;
                        if (hcExamination.SubEpisode.PatientAdmission.AdmissionAppointment != null && hcExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                        {
                            foreach (Appointment app in hcExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments)
                            {
                                if (app.MasterResource.ObjectID.Equals(hcExamination.MasterResource.ObjectID) && hcExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                {
                                    appointment = app;
                                    break;
                                }
                            }
                        }

                        if (appointment != null)
                        {
                            workListItem.AdmissionQueueNo = appointment.StartTime.Value.ToShortTimeString();
                            //workListItem.Date = appointment.StartTime.Value;
                        }
                        else
                        {
                            if (hcExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                            {
                                if (hcExamination.WorkListDate.HasValue)
                                    workListItem.Date = (DateTime)hcExamination.WorkListDate.Value;
                            }
                            workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(hcExamination, hcExamination.SubEpisode.PatientAdmission, true, appointment == null);

                        }

                        workListItem.Diagnosis = hcExamination.SubEpisode.GetDiagnosisAsStringForWorkList();
                        examinationWorkListItems.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            //viewModel.maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private List<ExaminationWorkListItem> getResultWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems, List<ExaminationWorkListItem> examinationWL)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_Result)) // KOns�ltasyon Hastalar� i�in Consultation �zerinden al�nan Sorgu
            {
                var examinationList = PatientExamination.GetPatientExaminationForWL(objectContext, whereCriteria_For_Result);
                foreach (var examFWL in examinationList)
                {
                    if (examinationWL.Exists(e => e.ObjectID.ToString().Equals(examFWL.ObjectID.ToString())))
                        continue;
                    PatientExamination patientExamination = (PatientExamination)objectContext.GetObject((Guid)examFWL.ObjectID, "PatientExamination");
                    bool addWorkListItem = true;
                    if (bekleyen && sc.doNotListCalleds)
                    {
                        ExaminationQueueItem queueItem = patientExamination.GetActiveQueueItem(false);
                        if (queueItem != null)
                        {
                            if (queueItem.CallCount.HasValue && queueItem.CallCount.Value > 0)
                                addWorkListItem = false;
                        }
                    }
                    // GENEL 
                    if (addWorkListItem && this.HasWorkListWorkListRight(objectContext, patientExamination))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        if (showPatientCallStatus)
                            workListItem.PatientCallStatus = getPatientCallStatus(patientExamination);
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = patientExamination.Episode;
                        workListItem.ObjectDefID = examFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = examFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)examFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = examFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);
                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "�la� Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Di�er";
                        }

                        workListItem.isEmergency = examFWL.Isemergency == true ? true : false;
                        //

                        if (examFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(examFWL.Date);
                        workListItem.PatientNameSurname = examFWL.Patientnamesurname.ToString();
                        workListItem.Triage = "";
                        workListItem.KabulNo = examFWL.Kabulno == null ? "" : examFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = examFWL.UniqueRefNo == null ? "" : examFWL.UniqueRefNo.ToString();
                        if (patientExamination.PatientExaminationType.HasValue)
                        {
                            workListItem.EpisodeActionName = Common.GetDisplayTextOfDataTypeEnum(patientExamination.PatientExaminationType.Value);
                            if (patientExamination.PatientExaminationType.Value == PatientExaminationEnum.Emergency)
                                workListItem.isEmergency = true;
                        }
                        else
                        {
                            foreach (ResourceSpecialityGrid resourceSpecialityGrid in patientExamination.MasterResource.ResourceSpecialities)
                            {
                                if (resourceSpecialityGrid.Speciality != null && resourceSpecialityGrid.Speciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.EmergencySpecialityObject)
                                {
                                    workListItem.EpisodeActionName = Common.GetDisplayTextOfDataTypeEnum(SpecialityBasedObjectEnum.EmergencySpecialityObject);
                                    workListItem.isEmergency = true;
                                    break;
                                }
                            }
                        }

                        if (String.IsNullOrEmpty(workListItem.EpisodeActionName))
                            workListItem.EpisodeActionName = examFWL.Episodeactionname == null ? "" : examFWL.Episodeactionname.ToString();

                        workListItem.StateName = examFWL.Statename == null ? "" : examFWL.Statename.ToString();
                        workListItem.ResourceName = examFWL.Masterresource == null ? "" : examFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = examFWL.Doctorname == null ? "" : examFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = examFWL.Examinationprotocolno == null ? "" : examFWL.Examinationprotocolno.ToString();
                        workListItem.ComingReason = examFWL.Admissiontype == null ? "" : examFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = examFWL.Payername == null ? "" : examFWL.Payername.ToString();
                        workListItem.PatientClassGroup = examFWL.Hastaturu == null ? "" : examFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = examFWL.Basvuruturu == null ? "" : examFWL.Basvuruturu.ToString();
                        if (examFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = examFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = examFWL.FatherName == null ? "" : examFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = examFWL.Telno == null ? "" : examFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(patientExamination.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(patientExamination.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;
                        Appointment appointment = null;
                        if (patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment != null && patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                        {
                            foreach (Appointment app in patientExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments)
                            {
                                if (app.MasterResource.ObjectID.Equals(patientExamination.MasterResource.ObjectID) && patientExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                {
                                    appointment = app;
                                    break;
                                }
                            }
                        }

                        if (appointment != null)
                        {
                            workListItem.AdmissionQueueNo = appointment.StartTime.Value.ToShortTimeString();
                            //workListItem.Date = appointment.StartTime.Value;
                        }
                        else
                        {
                            if (patientExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                            {
                                if (patientExamination.WorkListDate.HasValue)
                                    workListItem.Date = (DateTime)patientExamination.WorkListDate.Value;
                            }
                            workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(patientExamination, patientExamination.SubEpisode.PatientAdmission, true, appointment == null);

                        }

                        workListItem.Diagnosis = patientExamination.SubEpisode.GetDiagnosisAsStringForWorkList();
                        examinationWorkListItems.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            //viewModel.maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private List<ExaminationWorkListItem> getDentalExaminationWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_DentalExamination))
            {
                var examinationList = DentalExamination.GetDentalExaminationForWL(objectContext, whereCriteria_For_DentalExamination);
                foreach (var examFWL in examinationList)
                {
                    DentalExamination dentalExamination = (DentalExamination)objectContext.GetObject((Guid)examFWL.ObjectID, "DentalExamination");
                    bool addWorkListItem = true;
                    if (bekleyen && sc.doNotListCalleds)
                    {
                        ExaminationQueueItem queueItem = dentalExamination.GetActiveQueueItem(false);
                        if (queueItem != null)
                        {
                            if (queueItem.CallCount.HasValue && queueItem.CallCount.Value > 0)
                                addWorkListItem = false;
                        }
                    }
                    // GENEL 
                    if (addWorkListItem && this.HasWorkListWorkListRight(objectContext, dentalExamination))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        if (showPatientCallStatus)
                            workListItem.PatientCallStatus = getPatientCallStatus(dentalExamination);
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = dentalExamination.Episode;
                        workListItem.ObjectDefID = examFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = examFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)examFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = examFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "�la� Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Di�er";
                        }

                        workListItem.isEmergency = examFWL.Isemergency == true ? true : false;
                        //

                        if (examFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(examFWL.Date);
                        workListItem.PatientNameSurname = examFWL.Patientnamesurname.ToString();
                        workListItem.Triage = "";
                        workListItem.KabulNo = examFWL.Kabulno == null ? "" : examFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = examFWL.UniqueRefNo == null ? "" : examFWL.UniqueRefNo.ToString();

                        if (dentalExamination.IsConsultation == true)
                            workListItem.EpisodeActionName = TTUtils.CultureService.GetText("M25499", "Di� Kons�ltasyonu");
                        else
                            workListItem.EpisodeActionName = examFWL.Episodeactionname == null ? "" : examFWL.Episodeactionname.ToString();

                        workListItem.StateName = examFWL.Statename == null ? "" : examFWL.Statename.ToString();
                        workListItem.ResourceName = examFWL.Masterresource == null ? "" : examFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = examFWL.Doctorname == null ? "" : examFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = examFWL.Examinationprotocolno == null ? "" : examFWL.Examinationprotocolno.ToString();
                        workListItem.ComingReason = examFWL.Admissiontype == null ? "" : examFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = examFWL.Payername == null ? "" : examFWL.Payername.ToString();
                        workListItem.PatientClassGroup = examFWL.Hastaturu == null ? "" : examFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = examFWL.Basvuruturu == null ? "" : examFWL.Basvuruturu.ToString();
                        if (examFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = examFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = examFWL.FatherName == null ? "" : examFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = examFWL.Telno == null ? "" : examFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(dentalExamination.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(dentalExamination.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;
                        Appointment appointment = null;
                        if (dentalExamination.SubEpisode.PatientAdmission.AdmissionAppointment != null && dentalExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                        {
                            foreach (Appointment app in dentalExamination.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments)
                            {
                                if (app.MasterResource.ObjectID.Equals(dentalExamination.MasterResource.ObjectID) && dentalExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                {
                                    appointment = app;
                                    break;
                                }
                            }
                        }

                        if (appointment != null)
                        {
                            workListItem.AdmissionQueueNo = appointment.StartTime.Value.ToShortTimeString();
                            //workListItem.Date = appointment.StartTime.Value;
                        }
                        else
                        {
                            if (dentalExamination.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                            {
                                if (dentalExamination.WorkListDate.HasValue)
                                    workListItem.Date = (DateTime)dentalExamination.WorkListDate.Value;
                            }
                            workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(dentalExamination, dentalExamination.SubEpisode.PatientAdmission, true, appointment == null);

                        }

                        workListItem.Diagnosis = dentalExamination.SubEpisode.GetDiagnosisAsStringForWorkList();
                        examinationWorkListItems.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            //viewModel.maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private List<ExaminationWorkListItem> getParticipatnFreeDrugReportWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_ParticipatnFreeDrugReport))
            {
                var reportList = ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL(objectContext, whereCriteria_For_ParticipatnFreeDrugReport);
                foreach (var reportFWL in reportList)
                {
                    ParticipatnFreeDrugReport participatnFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "ParticipatnFreeDrugReport");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, participatnFreeDrugReport))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = participatnFreeDrugReport.Episode;
                        workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = reportFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)reportFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = reportFWL.Prioritystatus;
                        this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "�la� Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Di�er";
                        }

                        workListItem.isEmergency = reportFWL.Isemergency == true ? true : false;
                        //

                        if (reportFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                        workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                        workListItem.Triage = "";
                        workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                        workListItem.EpisodeActionName = reportFWL.Episodeactionname == null ? "" : reportFWL.Episodeactionname.ToString();
                        workListItem.StateName = reportFWL.Statename == null ? "" : reportFWL.Statename.ToString();
                        workListItem.ResourceName = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = "";
                        workListItem.ComingReason = reportFWL.Admissiontype == null ? "" : reportFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = reportFWL.Payername == null ? "" : reportFWL.Payername.ToString();
                        workListItem.PatientClassGroup = reportFWL.Hastaturu == null ? "" : reportFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = reportFWL.Basvuruturu == null ? "" : reportFWL.Basvuruturu.ToString();
                        if (reportFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = reportFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = reportFWL.FatherName == null ? "" : reportFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = reportFWL.Telno == null ? "" : reportFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(participatnFreeDrugReport.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(participatnFreeDrugReport.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;

                        if (participatnFreeDrugReport.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                        {
                            if (participatnFreeDrugReport.WorkListDate.HasValue)
                                workListItem.Date = (DateTime)participatnFreeDrugReport.WorkListDate.Value;
                        }
                        workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(participatnFreeDrugReport, participatnFreeDrugReport.SubEpisode.PatientAdmission, true, true);



                        workListItem.Diagnosis = participatnFreeDrugReport.SubEpisode.GetDiagnosisAsStringForWorkList();
                        examinationWorkListItems.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            //viewModel.maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private List<ExaminationWorkListItem> getMedicalStuffReportWorkListItems(TTObjectContext objectContext, Common.QueueItems queueItems)
        {
            List<ExaminationWorkListItem> examinationWorkListItems = new List<ExaminationWorkListItem>();
            if (!string.IsNullOrEmpty(whereCriteria_For_MedicalStuffReport))
            {
                var reportList = MedicalStuffReport.GetMedicalStuffReportForWL(objectContext, whereCriteria_For_MedicalStuffReport);
                foreach (var reportFWL in reportList)
                {
                    MedicalStuffReport medicalStuffReport = (MedicalStuffReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "MedicalStuffReport");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, medicalStuffReport))// BASEDEN KULLANILIYOR  
                    {
                        ExaminationWorkListItem workListItem = new ExaminationWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanlar�
                        var episode = medicalStuffReport.Episode;
                        workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = reportFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)reportFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = reportFWL.Prioritystatus;
                        this.setWorkListIkonPropertyies(PriorityStatus, episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "�la� ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "�la� Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "G�da Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Di�er";
                        }

                        workListItem.isEmergency = reportFWL.Isemergency == true ? true : false;
                        //

                        if (reportFWL.Date != null)
                            workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                        workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                        workListItem.Triage = "";
                        workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                        workListItem.EpisodeActionName = reportFWL.Episodeactionname == null ? "" : reportFWL.Episodeactionname.ToString();
                        workListItem.StateName = reportFWL.Statename == null ? "" : reportFWL.Statename.ToString();
                        workListItem.ResourceName = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                        workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();
                        workListItem.ExaminationProtocolNo = "";
                        workListItem.ComingReason = reportFWL.Admissiontype == null ? "" : reportFWL.Admissiontype.ToString();  // Geli� Sebebi
                        workListItem.PayerInfo = reportFWL.Payername == null ? "" : reportFWL.Payername.ToString();
                        workListItem.PatientClassGroup = reportFWL.Hastaturu == null ? "" : reportFWL.Hastaturu.ToString();
                        workListItem.ApplicationReason = reportFWL.Basvuruturu == null ? "" : reportFWL.Basvuruturu.ToString();
                        if (reportFWL.BirthDate != null)
                        {
                            workListItem.BirthDate = reportFWL.BirthDate.Value; // Do�um Tarihi
                            var FullAge = Common.CalculateAge(workListItem.BirthDate);
                            workListItem.Age = FullAge.Years + " Y�l " + FullAge.Months + " Ay ";
                        }
                        workListItem.FatherName = reportFWL.FatherName == null ? "" : reportFWL.FatherName.ToString();  // Baba ad�
                        workListItem.PhoneNumber = reportFWL.Telno == null ? "" : reportFWL.Telno.ToString();  // Telefon Numaras�
                        if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(medicalStuffReport.Episode.Patient.ObjectID)))
                            workListItem.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(medicalStuffReport.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                        else
                            workListItem.QueueNumberToSort = 5000;

                        if (medicalStuffReport.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                        {
                            if (medicalStuffReport.WorkListDate.HasValue)
                                workListItem.Date = (DateTime)medicalStuffReport.WorkListDate.Value;
                        }
                        workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(medicalStuffReport, medicalStuffReport.SubEpisode.PatientAdmission, true, true);

                        examinationWorkListItems.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            //viewModel.maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            return examinationWorkListItems;
        }
        private string getPatientCallStatus(EpisodeAction episodeAction)
        {
            ExaminationQueueItem queueItem = episodeAction.GetActiveQueueItem(false);
            if (queueItem != null)
            {
                int callCount = 1;
                if (queueItem.CallCount.HasValue)
                    callCount = queueItem.CallCount.Value;
                if (queueItem.Priority == -1)
                {
                    if (Common.RecTime().Subtract(queueItem.CallTime.Value).TotalMinutes < Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("ACILDETEKRARSIRAYAALMASURESI", "15")))
                        return "HASTA �A�IRILDI - �A�IRILMA SAYISI : " + callCount.ToString();
                    else
                        return "HASTA DAHA �NCE " + callCount.ToString() + " KEZ �A�IRILDI";
                }
                else
                {
                    if (callCount > 0)
                        return "HASTA DAHA �NCE " + callCount.ToString() + " KEZ �A�IRILDI";
                }
            }
            return String.Empty;
        }

        [HttpPost]
        public string PrepareSignedReportHeadDoctorApproveContent(SendWorklistSignedReportApproveModel approveModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.GetObject<ParticipatnFreeDrugReport>(approveModel.reportObjectId);
                MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.eraporBashekimOnayIstekDVO();
                    eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporBashekimOnayIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;
                    string uniqueRefNo = "";
                    string password = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((approveModel.medulaUsername != null && approveModel.medulaUsername != "") || (approveModel.medulaPassword != null && approveModel.medulaPassword != ""))
                        {
                            eraporBashekimOnayIstekDVO.doktorTcKimlikNo = approveModel.medulaUsername;
                            uniqueRefNo = approveModel.medulaUsername;
                            password = approveModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullan�c� ad� veya �ifre bo� olamaz!");
                        }
                    }
                    else
                    {
                        string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("KURUMSALYONETICI_OBJECTID", "XXXXXX");
                        BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                        if (basTabipList == null || basTabipList.Count == 0)
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M25242", "Ba� Tabip Bo� Olamaz !!!"));
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(basTabipList[0].ErecetePassword))
                                password = basTabipList[0].ErecetePassword;
                            else
                                throw new Exception("ERe�ete �ifresi Bo� Olamaz");
                            if (basTabipList[0].Tcno != null)
                            {
                                eraporBashekimOnayIstekDVO.doktorTcKimlikNo = basTabipList[0].Tcno.ToString();
                                uniqueRefNo = basTabipList[0].Tcno.ToString();
                            }
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M25249", "Ba�hekim TC Kimlik Numaras� Bo� Olamaz"));
                        }
                    }

                    string imzalanacakXml = Common.SerializeObjectToXml(eraporBashekimOnayIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("eraporBashekimOnayIstekDVO", "imzaliEraporBashekimOnayBilgisi");

                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                }

            }
            return output;
        }

        [HttpPost]
        public IlacRaporuServis.imzaliEraporBashekimOnayCevapDVO SendSignedReportHeadDoctorApproveContent(SendWorklistSignedReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.GetObject<ParticipatnFreeDrugReport>(approveModel.reportObjectId);
                MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                var signedData = Convert.FromBase64String(approveModel.signContent);
                string username = "";
                string password = "";
                string uniqueRefNo = "";
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.imzaliEraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.imzaliEraporBashekimOnayIstekDVO();
                    eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporBashekimOnayIstekDVO.imzaliEraporBashekimOnay = signedData;

                    eraporBashekimOnayIstekDVO.surumNumarasi = 1;


                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((approveModel.medulaUsername != null && approveModel.medulaUsername != "") || (approveModel.medulaPassword != null && approveModel.medulaPassword != ""))
                        {
                            eraporBashekimOnayIstekDVO.doktorTcKimlikNo = approveModel.medulaUsername;
                            uniqueRefNo = approveModel.medulaUsername;
                            password = approveModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullan�c� ad� veya �ifre bo� olamaz!");
                        }
                    }
                    else
                    {
                        string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("KURUMSALYONETICI_OBJECTID", "XXXXXX");
                        BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                        if (basTabipList == null || basTabipList.Count == 0)
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M25242", "Ba� Tabip Bo� Olamaz !!!"));
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(basTabipList[0].ErecetePassword))
                                password = basTabipList[0].ErecetePassword;
                            else
                                throw new Exception("ERe�ete �ifresi Bo� Olamaz");
                            if (basTabipList[0].Tcno != null)
                            {
                                eraporBashekimOnayIstekDVO.doktorTcKimlikNo = basTabipList[0].Tcno.ToString();
                                uniqueRefNo = basTabipList[0].Tcno.ToString();
                            }
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M25249", "Ba�hekim TC Kimlik Numaras� Bo� Olamaz"));
                        }
                    }
                    IlacRaporuServis.imzaliEraporBashekimOnayCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporBashekimOnaySync(Sites.SiteLocalHost, uniqueRefNo, password, eraporBashekimOnayIstekDVO);
                    if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                    {
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.HeadDoctorApprove;
                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.ReportCompleted;
                        participatnFreeDrugReportImported.HeadDoctorApproval = 1;
                        objectContext.Save();
                    }
                    else if (response != null && response.sonucKodu != null && response.sonucKodu == "RAP_0047")
                    {
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.HeadDoctorApprove;
                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.ReportCompleted;
                        participatnFreeDrugReportImported.HeadDoctorApproval = 1;
                        objectContext.Save();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.sonucMesaji) || !string.IsNullOrEmpty(response.uyariMesaji))
                        {
                            participatnFreeDrugReportImported.HeadDoctorApproval = 0;
                            objectContext.Save();
                        }
                    }

                    return response;
                }
            }
            return null;
        }

        [HttpPost]
        public TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO TibbiMalzemeRaporuBashekimOnay(SendWorklistSignedReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var medicalStuffReportObj = objectContext.GetObject<MedicalStuffReport>(approveModel.reportObjectId);
                    string password = "";
                    string uniqueRefNo = "";
                    if (medicalStuffReportObj.RaporTakipNo != null && medicalStuffReportObj.RaporTakipNo != "")
                    {
                        TibbiMalzemeERaporIslemleri.eRaporOnayIstekDVO eraporBashekimOnayIstekDVO = new TibbiMalzemeERaporIslemleri.eRaporOnayIstekDVO();
                        eraporBashekimOnayIstekDVO.tesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                        eraporBashekimOnayIstekDVO.raporTakipNo = medicalStuffReportObj.RaporTakipNo;
                        eraporBashekimOnayIstekDVO.onayKod = 2;
                        if (medicalStuffReportObj.CurrentStateDefID == MedicalStuffReport.States.HeadDoctorApproval)
                        {

                            var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                            if (MedulaPasswordCheck == "TRUE")
                            {
                                if ((approveModel.medulaUsername != null && approveModel.medulaUsername != "") || (approveModel.medulaPassword != null && approveModel.medulaPassword != ""))
                                {
                                    eraporBashekimOnayIstekDVO.doktorTcKimlikNo = approveModel.medulaUsername;
                                    uniqueRefNo = approveModel.medulaUsername;
                                    password = approveModel.medulaPassword;
                                }
                                else
                                {
                                    throw new TTUtils.TTException("Kullan�c� ad� veya �ifre bo� olamaz!");
                                }
                            }
                            else
                            {
                                string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("KURUMSALYONETICI_OBJECTID", "XXXXXX");
                                BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                                if (basTabipList == null || basTabipList.Count == 0)
                                {
                                    throw new Exception(TTUtils.CultureService.GetText("M25242", "Ba� Tabip Bo� Olamaz !!!"));
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(basTabipList[0].ErecetePassword))
                                        password = basTabipList[0].ErecetePassword;
                                    else
                                        throw new Exception("ERe�ete �ifresi Bo� Olamaz");
                                    if (basTabipList[0].Tcno != null)
                                    {
                                        eraporBashekimOnayIstekDVO.doktorTcKimlikNo = basTabipList[0].Tcno.ToString();
                                        uniqueRefNo = basTabipList[0].Tcno.ToString();
                                    }
                                    else
                                        throw new Exception(TTUtils.CultureService.GetText("M25249", "Ba�hekim TC Kimlik Numaras� Bo� Olamaz"));
                                }
                            }

                            try
                            {
                                TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.bashekimERaporOnayVeIptalSync(Sites.SiteLocalHost, uniqueRefNo, password, eraporBashekimOnayIstekDVO);
                                if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                                {
                                    medicalStuffReportObj.CurrentStateDefID = MedicalStuffReport.States.Complete;
                                    objectContext.Save();
                                    return response;
                                }
                                else
                                {
                                    return response;
                                }
                            }
                            catch (Exception ex)
                            {
                                string exceptionMessage = "Bir hata olu�tu : ";
                                if (ex.InnerException != null)
                                {
                                    if (ex.InnerException.InnerException != null)
                                    {
                                        exceptionMessage += " -> " + ex.InnerException.InnerException.Message;
                                    }
                                }
                                TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO responseObj = new TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO();
                                responseObj.sonucMesaji = exceptionMessage;
                                responseObj.sonucKodu = "Hata";
                                return responseObj;
                            }

                        }

                        return null;
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
namespace Core.Models
{
    public partial class ExaminationWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<ExaminationWorkListItem> WorkList;
        public List<ExaminationWorkListItem> ReportApproveWorkList;

        public ExaminationWorkListSearchCriteria _SearchCriteria
        {
            get;
            set;
        }

        public List<ResSection> ResourceList { get; set; }
        public List<LCDNotificationDefinition> LCDNotificationList { get; set; }
        public bool hasHeadDoctorRole { get; set; }
        public string isNewLcd { get; set; }
        public ExaminationWorkListViewModel()
        {
            this._SearchCriteria = new ExaminationWorkListSearchCriteria();
            this.WorkList = new List<ExaminationWorkListItem>();
            this.ReportApproveWorkList = new List<ExaminationWorkListItem>();
        }
    }

    [Serializable]
    public class ExaminationWorkListSearchCriteria : BaseEpisodeActionWorkListSearchCriteria
    {
        public List<ResSection> Resources { get; set; }
        public List<ListObject> ActionNames { get; set; }
        public List<ListObject> ActionStatus { get; set; }
        public List<ListObject> ReportStatus { get; set; }
        public int PatientType { get; set; }
        public string ProtocolNo { get; set; }
        public string ReportChasingNo { get; set; }
        public bool policlinic_EA
        {
            get;
            set;
        }

        public bool participatnFreeDrugReport_EA
        {
            get;
            set;
        }

        public bool doNotListCalleds
        {
            get;
            set;
        }
    }


    public class ExaminationWorkListItem : BaseEpisodeActionWorkListItem
    {
        public string AdmissionQueueNo
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string KabulNo
        {
            get;
            set;
        }

        public string UniqueRefno
        {
            get;
            set;
        }

        public string DoctorName
        {
            get;
            set;
        }

        public string ExaminationProtocolNo
        {
            get;
            set;
        }

        public string EpisodeActionName
        {
            get;
            set;
        }

        public string StateName
        {
            get;
            set;
        }

        public string ResourceName
        {
            get;
            set;
        }

        public long QueueNumberToSort
        {
            get;
            set;
        }

        #region HIDDEN COLUMN

        public string ComingReason { get; set; }
        public string PayerInfo { get; set; }
        public string PatientClassGroup { get; set; }
        public string ApplicationReason { get; set; }
        public DateTime BirthDate { get; set; }
        public string Age { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Diagnosis
        {
            get;
            set;
        }
        public string Triage { get; set; }

        #endregion
    }

    public class ListObject
    {
        public string TypeName
        {
            get;
            set;
        }

        public int TypeID
        {
            get;
            set;
        }
    }

    public class SendWorklistSignedReportApproveModel
    {
        public string signContent
        {
            get;
            set;
        }
        public Guid reportObjectId { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }
}
