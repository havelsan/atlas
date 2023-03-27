using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Linq;
using static TTObjectClasses.TreatmentDischarge;
using System.ComponentModel;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InPatientWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        private object renderer;

        [HttpGet]
        public InPatientWorkListViewModel LoadInPatientWorkListViewModel()
        {
            var viewModel = new InPatientWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<InPatientWorkListItem>();

                viewModel._SearchCriteria = new InPatientWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.WorkListEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                #region Birim Listesi

                /****** Klinik Birim Listesi ******/

                viewModel.ResourceList = new List<ResSection>();
                var CurrentResource = Common.CurrentResource;
                foreach (var useResource in CurrentResource.UserResources)
                {
                    if (useResource.Resource is ResWard)
                    {
                        var resource = viewModel.ResourceList.Where(t => t.ObjectID == useResource.Resource.ObjectID).FirstOrDefault();
                        if (resource == null)
                            viewModel.ResourceList.Add(useResource.Resource);
                    }

                }

                viewModel.ResourceList = viewModel.ResourceList.Where(x => x.IsActive == true).OrderBy(x => x.Name).ToList<ResSection>();
                viewModel._SearchCriteria.Resources = new List<ResSection>();
                var selectedInPatientResource = CurrentResource.SelectedInPatientResource;
                if (selectedInPatientResource != null && selectedInPatientResource is ResWard)
                {
                    viewModel._SearchCriteria.Resources.Add(selectedInPatientResource);
                }
                else if (selectedInPatientResource != null && selectedInPatientResource is ResDepartment)
                {

                    ResDepartment resDepartment = (ResDepartment)objectContext.GetObject(selectedInPatientResource.ObjectID, "ResDepartment");
                    foreach (var sResource in resDepartment.Clinics)
                    {
                        viewModel._SearchCriteria.Resources.Add(sResource);
                    }
                }

                #endregion

                #region EpisodeAction Tipi Seçimi

                viewModel._SearchCriteria.inPatientPhysicianApplication_EA = true;
                viewModel._SearchCriteria.consultation_EA = false;
                viewModel._SearchCriteria.participatnFreeDrugReport_EA = false;

                #endregion

                #region  state sorguları

                viewModel._SearchCriteria.acception = false; // default
                viewModel._SearchCriteria.inpatient = true;
                viewModel._SearchCriteria.predischarge = false;
                viewModel._SearchCriteria.discharge = false;
                viewModel._SearchCriteria.dailyInpatient = false;


                viewModel._SearchCriteria.waiting_consultation = true;// default
                viewModel._SearchCriteria.in_consultation = false;
                viewModel._SearchCriteria.closed_consultation = false;
                viewModel._SearchCriteria.rejected_consultation = false;
                viewModel._SearchCriteria.send_consultation = false;

                viewModel._SearchCriteria.report = true;// default
                viewModel._SearchCriteria.waiting_doctor = false;// default
                viewModel._SearchCriteria.waiting_headdoctor = false;// default
                viewModel._SearchCriteria.completed_report = false;
                viewModel._SearchCriteria.rejected_report = false;

                #endregion
                viewModel._SearchCriteria.OnlyOwnPatient = false;
                viewModel._SearchCriteria.HasSurgery = false;
                viewModel._SearchCriteria.HasVacation = false;

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Listesi)]
        public InPatientWorkListViewModel GetInPatientWorkList(InPatientWorkListSearchCriteria sc)
        {

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                int workListMaxItemCount = Common.WorklistMaxItemCount();
                int counter = 0;

                // GENEL 
                var CurrentUser = Common.CurrentResource;
                var viewModel = new InPatientWorkListViewModel();
                viewModel.WorkList = new List<InPatientWorkListItem>();
                viewModel.maxWorklistItemCount = 0;
                //
                string whereCriteria = string.Empty;
                string whereCriteria_For_InPatientTreatmentClinicApplication = string.Empty;
                string whereCriteria_For_InPatientPhysicianApplication = string.Empty;
                string whereCriteria_For_TreatmentDischarge = string.Empty;
                string whereCriteria_For_Consultation = string.Empty;
                string whereCriteria_For_ParticipatnFreeDrugReport = string.Empty;
                string whereCriteria_For_MedicalStuffReport = string.Empty;
                string whereCriteria_For_DailyInpatient = string.Empty;

                if (sc.WorkListStartDate == null || sc.WorkListEndDate == null)
                {
                    if (sc.consultation_EA || sc.acception || sc.discharge || sc.predischarge) // yanlız inpatient sorgulaması yapılıyorsa dateler boş olabilir 
                        throw new Exception("Başlangıç Bitiş Tarihi girilmeden sorgulama yapılamaz");
                }

                if (sc.WorkListStartDate.HasValue)
                    sc.WorkListStartDate = Convert.ToDateTime(sc.WorkListStartDate.Value.ToShortDateString() + " " + "00:00:00");

                if (sc.WorkListEndDate.HasValue)
                    sc.WorkListEndDate = Convert.ToDateTime(sc.WorkListEndDate.Value.ToShortDateString() + " " + "23:59:59");

                // Hasta seçildi ise diğer sorgular kale alınmayacak Konsültasyon , inPatientPhysicianApplication
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_InPatientTreatmentClinicApplication = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_InPatientPhysicianApplication = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_TreatmentDischarge = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_Consultation = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_ParticipatnFreeDrugReport = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_MedicalStuffReport = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_DailyInpatient = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else if (!String.IsNullOrEmpty(sc.ProtocolNo))
                {
                    string protocolNoCriteria = "";
                    if (sc.ProtocolNo.Contains("-"))
                        protocolNoCriteria = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                    else
                    {
                        protocolNoCriteria = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";

                    }

                    whereCriteria_For_InPatientTreatmentClinicApplication = protocolNoCriteria;
                    whereCriteria_For_InPatientPhysicianApplication = protocolNoCriteria;
                    whereCriteria_For_TreatmentDischarge = protocolNoCriteria;
                    whereCriteria_For_Consultation = protocolNoCriteria;
                    whereCriteria_For_ParticipatnFreeDrugReport = protocolNoCriteria;
                    whereCriteria_For_MedicalStuffReport = protocolNoCriteria;
                    whereCriteria_For_DailyInpatient = protocolNoCriteria;
                }
                else
                {
                    if (sc.Resources == null || sc.Resources.Count == 0)
                        throw new Exception("En az bir birim seçilmeden sorgulama yapılamaz");

                    // Yatan Hasta için 
                    if (sc.inPatientPhysicianApplication_EA == true)
                    {
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
                            whereCriteria += whereCriteria_Resource + ") ";
                        }

                        // Ameliyat Olan Hastalar Sorgusu
                        if (sc.HasSurgery == true)
                            whereCriteria += " AND this.SubEpisode.Surgeries(this.CURRENTSTATEDEFID <> States.Cancelled).EXISTS ";

                        //Yatış Bekleyen Hasta
                        if (sc.acception == true)
                        {
                            // Yatışı Bekleyen Hastalar için InPatientTreatmentClinicApplication üzerinden alınan  Sorgu

                            // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                            whereCriteria_For_InPatientTreatmentClinicApplication += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                            // Yanlız kendi Hastalarım sorgusu
                            if (sc.OnlyOwnPatient == true)
                                whereCriteria_For_InPatientTreatmentClinicApplication += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";

                            whereCriteria_For_InPatientTreatmentClinicApplication += whereCriteria;

                        }
                        //Yatan Hasta ve Taburcu
                        if (sc.inpatient == true || sc.discharge == true)
                        {
                            // Yatan Ve taburcu olmuş Hastalar için InPatientPhysicianApplication üzerinden alınan Sorgu

                            // Yanlız kendi Hastalarım sorgusu

                            if (sc.OnlyOwnPatient == true)
                                whereCriteria_For_InPatientPhysicianApplication += " AND this.InPatientTreatmentClinicApp.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";


                            if (sc.inpatient == true && sc.discharge == true)//Yatan Hasta ve Taburcu
                            {
                                // Başlangış - Bitiş Tarihi ile ilgili sorgular 

                                if (sc.HasVacation == true)
                                {
                                    whereCriteria_For_InPatientPhysicianApplication += " AND (" +
                                                                                             "(this.CURRENTSTATEDEFID = States.Application OR Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS)" +
                                                                                             " OR " +
                                                                                             "(this.CURRENTSTATEDEFID = States.Discharged AND NOT Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS" +
                                                                                             " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) + ")" +
                                                                                         ") ";
                                }
                                else
                                {
                                    whereCriteria_For_InPatientPhysicianApplication += " AND (" +
                                                                                            "(this.CURRENTSTATEDEFID = States.Application AND NOT Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS)" +
                                                                                            " OR " +
                                                                                            "(this.CURRENTSTATEDEFID = States.Discharged AND NOT Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS" +
                                                                                            " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) + ")" +
                                                                                        ") ";
                                }
                            }

                            else if (sc.inpatient == true)
                            {
                                // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                                if (sc.HasVacation == true)
                                {
                                    whereCriteria_For_InPatientPhysicianApplication += " AND (this.CURRENTSTATEDEFID = States.Application OR Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS)";
                                }
                                else
                                {
                                    whereCriteria_For_InPatientPhysicianApplication += " AND this.CURRENTSTATEDEFID = States.Application AND NOT Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS";
                                }
                            }
                            else if (sc.discharge == true)
                            {
                                if (sc.HasVacation == true)
                                {
                                    whereCriteria_For_InPatientPhysicianApplication += " AND (" +
                                                                                            " (this.CURRENTSTATEDEFID = States.Discharged AND NOT Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS" +
                                                                                            " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) + ")" +
                                                                                            " OR (this.CURRENTSTATEDEFID = States.Application AND Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS)" +
                                                                                        " )";
                                }
                                else
                                {
                                    whereCriteria_For_InPatientPhysicianApplication += " AND this.CURRENTSTATEDEFID = States.Discharged AND NOT Patientvacations(THIS.CURRENTSTATEDEFID = STATES.OnVacation).EXISTS" +
                                                                                       " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);
                                }

                            }




                            whereCriteria_For_InPatientPhysicianApplication += whereCriteria;
                        }

                        //Ön Taburcu
                        if (sc.predischarge == true)
                        {
                            // ön taburcu olmuş Hastalar için TreatmentDischarge üzerinden alınan Sorgu

                            // Yanlız kendi Hastalarım sorgusu
                            if (sc.OnlyOwnPatient == true)
                                whereCriteria_For_TreatmentDischarge += " AND this.InPatientTreatmentClinicApp.ProcedureDoctor = '" + CurrentUser.ObjectID + "' ";

                            whereCriteria_For_TreatmentDischarge += " AND this.CURRENTSTATEDEFID = States.PreDischarge ";
                            // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                            whereCriteria_For_TreatmentDischarge += " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                            whereCriteria_For_TreatmentDischarge += whereCriteria;
                        }

                        if (sc.dailyInpatient == true)
                        {
                            whereCriteria_For_DailyInpatient += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);
                            whereCriteria_For_DailyInpatient += " AND this.InPatientTreatmentClinicApp.IsDailyOperation = 1";

                            if (sc.OnlyOwnPatient == true)
                                whereCriteria_For_DailyInpatient += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";

                            whereCriteria_For_DailyInpatient += whereCriteria;

                        }


                    }

                    // Konsültasyon için 
                    if (sc.consultation_EA == true)
                    {

                        //GELEN GİDEN ORTAK

                        // Başlangış - Bitiş Tarihi ile ilgili sorgu  Giden ve gelen için Ortak
                        whereCriteria_For_Consultation += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        // Ameliyat Olan Hastalar Sorgusu  Giden ve gelen için Ortak
                        if (sc.HasSurgery == true)
                            whereCriteria_For_Consultation += " AND this.SubEpisode.Surgeries(this.CURRENTSTATEDEFID <> States.Cancelled).EXISTS ";


                        // GELEN
                        //  Gelen Konsültsyonların Stateleri
                        string cons_States = string.Empty;
                        if (sc.waiting_consultation)
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.NewRequest,States.Appointment,States.InsertedIntoQueue,States.RequestAcception";
                        }
                        if (sc.in_consultation)
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.Consultation";
                        }
                        if (sc.closed_consultation)
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.Completed";
                        }
                        if (sc.rejected_consultation)
                        {
                            if (!string.IsNullOrEmpty(cons_States))
                                cons_States += ",";
                            cons_States += "States.Cancelled,States.PatientNoShown";
                        }

                        string whereCriteria_For_ToMe_Consultation = string.Empty;
                        if (!string.IsNullOrEmpty(cons_States))// Gelen KOnsülyasyonlar için Sorgu vardır
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

                            // Yanlız kendi Hastalarım sorgusu 
                            if (sc.OnlyOwnPatient == true)
                                whereCriteria_For_ToMe_Consultation += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                        }

                        // GIDEN
                        string whereCriteria_For_FromMe_Consultation = string.Empty;
                        if (sc.send_consultation) // Giden Konsülyasyonlar için Sorgu vardır
                        {
                            // Birim ile ilgili sorgular 
                            string whereCriteria_Resource = string.Empty;
                            foreach (var resource in sc.Resources)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_Resource))
                                    whereCriteria_Resource = " AND this.FROMRESOURCE IN (''";
                                whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                            }
                            if (!string.IsNullOrEmpty(whereCriteria_Resource))
                            {
                                whereCriteria_For_FromMe_Consultation += whereCriteria_Resource + ") ";
                            }

                            // Yanlız kendi Hastalarım sorgusu  
                            if (sc.OnlyOwnPatient == true)
                                whereCriteria_For_FromMe_Consultation += " AND this.RequesterDoctor = '" + CurrentUser.ObjectID + "'";
                        }


                        // hem geleni hem gideni sorguladıysa 
                        if (!string.IsNullOrEmpty(whereCriteria_For_ToMe_Consultation) && !string.IsNullOrEmpty(whereCriteria_For_FromMe_Consultation)) // iki sorgu da varsa 
                        {
                            whereCriteria_For_Consultation += "AND (( 1=1 " + whereCriteria_For_ToMe_Consultation + ") OR ( 1=1 " + whereCriteria_For_FromMe_Consultation + "))";
                        }
                        else if (!string.IsNullOrEmpty(whereCriteria_For_ToMe_Consultation)) // geleni sorguladıysa 
                        {
                            whereCriteria_For_Consultation += whereCriteria_For_ToMe_Consultation;

                        }
                        else if (!string.IsNullOrEmpty(whereCriteria_For_FromMe_Consultation))// gideni sorguladıysa 
                        {
                            whereCriteria_For_Consultation += whereCriteria_For_FromMe_Consultation;
                        }

                    }

                    //Raporlar için
                    if (sc.participatnFreeDrugReport_EA == true)
                    {
                        string report_States = string.Empty;

                        //Hasta Katılım Payından Muaf İlaç Raporu
                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                            whereCriteria_For_ParticipatnFreeDrugReport += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        report_States = string.Empty;
                        if (sc.report)//Bekleyen
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.New,States.Report,States.Completed";
                        }
                        if (sc.waiting_doctor)
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.SecondDoctorApproval,States.ThirdDoctorApproval";
                        }
                        if (sc.waiting_headdoctor)
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.Approval";
                        }
                        if (sc.completed_report)//Tamamlanan
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.ReportCompleted";
                        }
                        if (sc.rejected_report)//Reddedilen
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.Cancelled";
                        }

                        //Rapor takip numarası girildiyse state e bakılmasın
                        if (!String.IsNullOrEmpty(sc.ReportChasingNo))
                            whereCriteria_For_ParticipatnFreeDrugReport += " AND THIS.MEDULAREPORTRESULTS(THIS.REPORTCHASINGNO = '" + sc.ReportChasingNo.Trim() + "').EXISTS ";
                        else if (!string.IsNullOrEmpty(report_States))
                        {
                            whereCriteria_For_ParticipatnFreeDrugReport += " AND this.CURRENTSTATEDEFID IN(" + report_States + ")";

                            bool isBasTabip = false;
                            if (ResUser.HasRole(CurrentUser, Common.BashekimRoleID) || ResUser.HasRole(CurrentUser, Common.NobetciBashekimRoleID))
                                isBasTabip = true;

                            // Yanlız kendi Hastalarım sorgusu 
                            //if (sc.PatientType == 1)
                            if (isBasTabip == false && Common.CurrentUser.IsSuperUser == false) //Baştabip değilse 1.,2. ve 3. doktora baksın. sadece Onların iş listesine gelsin.
                                whereCriteria_For_ParticipatnFreeDrugReport += " AND (this.ProcedureDoctor = '" + CurrentUser.ObjectID + "' OR this.SecondDoctor = '" + CurrentUser.ObjectID + "' OR this.ThirdDoctor = '" + CurrentUser.ObjectID + "' ) ";
                        }


                        //Tıbbi Malzeme Raporu
                        if (String.IsNullOrEmpty(sc.PatientObjectID))
                            whereCriteria_For_MedicalStuffReport += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        report_States = string.Empty;
                        if (sc.report)//Bekleyen
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.New";
                        }
                        if (sc.waiting_doctor)//Takipte
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.SecondDoctorApproval,States.ThirdDoctorApproval";
                        }
                        if (sc.waiting_headdoctor)//Başhekim onayında
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.HeadDoctorApproval";
                        }
                        if (sc.completed_report)//Tamamlanan
                        {
                            if (!string.IsNullOrEmpty(report_States))
                                report_States += ",";
                            report_States += "States.Complete";
                        }
                        if (sc.rejected_report)//Reddedilen
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

                            // Yanlız kendi Hastalarım sorgusu 
                            //if (sc.PatientType == 1)
                            if (isBasTabip == false && Common.CurrentUser.IsSuperUser == false) //Baştabip değilse 1.,2. ve 3. doktora baksın. sadece Onların iş listesine gelsin.
                                whereCriteria_For_MedicalStuffReport += " AND (this.ProcedureDoctor = '" + CurrentUser.ObjectID + "' OR this.SecondDoctor = '" + CurrentUser.ObjectID + "' OR this.ThirdDoctor = '" + CurrentUser.ObjectID + "' ) ";
                        }


                    }
                }
                if (string.IsNullOrEmpty(sc.PatientObjectID) && String.IsNullOrEmpty(sc.ProtocolNo))
                {

                    if (!string.IsNullOrEmpty(whereCriteria_For_DailyInpatient)) // gUNUBİRLİK
                    {
                        var dailyInpatientList = InPatientPhysicianApplication.GetInPatientPhysicianApplicationForWL(objectContext, whereCriteria_For_DailyInpatient);
                        foreach (var inPPAppFWL in dailyInpatientList)
                        {
                            InPatientPhysicianApplication inPatientPhysicianApplication = (InPatientPhysicianApplication)objectContext.GetObject((Guid)inPPAppFWL.ObjectID, "InPatientPhysicianApplication");
                            // GENEL 
                            if (this.HasWorkListWorkListRight(objectContext, inPatientPhysicianApplication))// BASEDEN KULLANILIYOR  
                            {
                                InPatientWorkListItem workListItem = new InPatientWorkListItem();
                                //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                                var episode = inPatientPhysicianApplication.Episode;
                                var subepisode = inPatientPhysicianApplication.SubEpisode;

                                workListItem.ObjectDefID = inPPAppFWL.ObjectDefID.ToString();
                                workListItem.ObjectDefName = inPPAppFWL.ObjectDefName;
                                workListItem.ObjectID = (Guid)inPPAppFWL.ObjectID;
                                // Ikon set etmece
                                string PriorityStatus = inPPAppFWL.Prioritystatus;
                                this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                                if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                                }
                                else
                                {
                                    if (workListItem.isPatientDrugAllergic)
                                    {
                                        workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                    }

                                    if (workListItem.isPatientFoodAllergic)
                                    {
                                        workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                    }
                                }

                                if (workListItem.isPatientOtherAllergic)
                                {
                                    workListItem.MedicalInformation = "Diğer";
                                }

                                if (workListItem.Pandemic)
                                {
                                    workListItem.MedicalInformation = "Pandemic Hasta";
                                }

                                workListItem.isEmergency = inPPAppFWL.Isemergency == true ? true : false;
                                workListItem.OrderNumber = 40;
                                //

                                workListItem.HasTightContactIsolation = inPPAppFWL.HasTightContactIsolation == true ? true : false;
                                workListItem.HasFallingRisk = inPPAppFWL.HasFallingRisk == true ? true : false;
                                workListItem.HasDropletIsolation = inPPAppFWL.HasDropletIsolation == true ? true : false;
                                workListItem.HasAirborneContactIsolation = inPPAppFWL.HasAirborneContactIsolation == true ? true : false;
                                workListItem.HasContactIsolation = inPPAppFWL.HasContactIsolation == true ? true : false;

                                if (inPPAppFWL.Date != null)
                                    workListItem.Date = Convert.ToDateTime(inPPAppFWL.Date);

                                if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate != null && inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                                {
                                    workListItem.InpatientDay = (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate.Value - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                                }
                                else if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                                {
                                    workListItem.InpatientDay = (Common.RecTime() - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                                }
                                else
                                {
                                    workListItem.InpatientDay = "";
                                }

                                workListItem.PatientNameSurname = inPPAppFWL.Patientnamesurname.ToString();
                                workListItem.KabulNo = inPPAppFWL.Kabulno == null ? "" : inPPAppFWL.Kabulno.ToString();
                                workListItem.UniqueRefno = inPPAppFWL.UniqueRefNo == null ? "" : inPPAppFWL.UniqueRefNo.ToString();
                                workListItem.EpisodeActionName = inPPAppFWL.Episodeactionname == null ? "" : inPPAppFWL.Episodeactionname.ToString();
                                workListItem.StateName = inPPAppFWL.Statename == null ? "" : inPPAppFWL.Statename.ToString();
                                workListItem.MasterResource = inPPAppFWL.Masterresource == null ? "" : inPPAppFWL.Masterresource.ToString(); ;
                                workListItem.RoomBed = inPPAppFWL.Roombed == null ? "" : inPPAppFWL.Roombed.ToString();
                                workListItem.DoctorName = inPPAppFWL.Doctorname == null ? "" : inPPAppFWL.Doctorname.ToString();

                                workListItem.NurseName = inPPAppFWL.Nursename == null ? "" : inPPAppFWL.Nursename.ToString();  //Hemşire Adı
                                workListItem.AdmissionType = inPPAppFWL.Admissiontype == null ? "" : inPPAppFWL.Admissiontype.ToString();  // Geliş Sebebi
                                workListItem.PayerName = inPPAppFWL.Payername == null ? "" : inPPAppFWL.Payername.ToString();
                                if (inPPAppFWL.BirthDate != null)
                                {
                                    workListItem.BirthDate = inPPAppFWL.BirthDate;// Doğum Tarihi
                                    var FullAge = Common.CalculateAge(workListItem.BirthDate.Value);
                                    workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                                }
                                workListItem.FatherName = inPPAppFWL.FatherName == null ? "" : inPPAppFWL.FatherName.ToString();  // Baba adı
                                workListItem.TelNo = inPPAppFWL.Telno == null ? "" : inPPAppFWL.Telno.ToString();  // Telefon Numarası

                                workListItem.HastaTuru = inPPAppFWL.Hastaturu == null ? "" : inPPAppFWL.Hastaturu.ToString();
                                workListItem.BasvuruTuru = inPPAppFWL.Basvuruturu == null ? "" : inPPAppFWL.Basvuruturu.ToString();
                                workListItem.OncelikDurumu = inPPAppFWL.Oncelikdurumu == null ? "" : inPPAppFWL.Oncelikdurumu.ToString();

                                // NQL le çekilemeyenler
                                workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();
                                if (episode != null)
                                {
                                    CompanionApplication _companion = episode.GetActiveCompanionApplication();
                                    workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                                }

                                viewModel.WorkList.Add(workListItem);
                                // GENEL 
                                counter++;
                                if (counter > workListMaxItemCount)
                                {
                                    viewModel.maxWorklistItemCount += counter;
                                    break;
                                }
                                //
                            }
                        }
                    }

                }
                // SORGULAR
                if (!string.IsNullOrEmpty(whereCriteria_For_InPatientTreatmentClinicApplication)) // Yatışı Bekleyen Hastalar için InPatientTreatmentClinicApplication üzerinden alınan  Sorgu
                {
                    var inPatientTreatmentClinicApplicationList = InPatientTreatmentClinicApplication.GetInPatientTreatClinicAppInAcceptionStateForWL(objectContext, whereCriteria_For_InPatientTreatmentClinicApplication);
                    foreach (var treatClinicApp in inPatientTreatmentClinicApplicationList)
                    {
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, treatClinicApp))// BASEDEN KULLANILIYOR  
                        {
                            InPatientWorkListItem workListItem = new InPatientWorkListItem();

                            var episode = treatClinicApp.Episode;
                            var subepisode = treatClinicApp.SubEpisode;
                            var inpatientAdmission = treatClinicApp.BaseInpatientAdmission;
                            var patient = treatClinicApp.Episode.Patient;
                            var patientAdress = treatClinicApp.SubEpisode.PatientAdmission;
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            workListItem.ObjectDefID = treatClinicApp.ObjectDef.ID.ToString();
                            workListItem.ObjectDefName = treatClinicApp.ObjectDef.Name.ToString();
                            workListItem.ObjectID = treatClinicApp.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = "";
                            if (patientAdress != null)
                            {
                                if (patientAdress.PriorityStatus != null)
                                {
                                    PriorityStatus = patientAdress.PriorityStatus.Code;
                                    workListItem.OncelikDurumu = patientAdress.PriorityStatus.Name;
                                }
                                workListItem.HastaTuru = patientAdress.PatientClassGroup == null ? "" : patientAdress.PatientClassGroup.ToString();
                                workListItem.BasvuruTuru = patientAdress.ApplicationReason == null ? "" : patientAdress.ApplicationReason.ToString();
                            }
                            this.editedSetWorkListIkonProperties(PriorityStatus, patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }

                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                            if (workListItem.Pandemic)
                            {
                                workListItem.MedicalInformation = "Pandemic Hasta";
                            }

                            workListItem.isEmergency = inpatientAdmission.Emergency == true ? true : false;

                            workListItem.OrderNumber = treatClinicApp.InpatientAcceptionType != null ? Convert.ToInt32(treatClinicApp.InpatientAcceptionType.Value) : 40;
                            var InpatientAcceptionTypeInfo = "";
                            if (treatClinicApp.InpatientAcceptionType != null)
                            {
                                if (treatClinicApp.InpatientAcceptionType == InpatientAcceptionTypeEnum.EmergencyInpatient)
                                {
                                    InpatientAcceptionTypeInfo = "-Acilden Sevk Edilen Hasta";
                                }
                                else if (treatClinicApp.InpatientAcceptionType == InpatientAcceptionTypeEnum.IntensiveCareTransfer)
                                {
                                    InpatientAcceptionTypeInfo = "-Yoğun Bakımdan Sevk Edilen Hasta";
                                }
                            }
                            // (treatClinicApp.InpatientAcceptionType != null && treatClinicApp.InpatientAcceptionType == InpatientAcceptionTypeEnum.IntensiveCareTransfer) ? "-Yoğun Bakımdan Sevk Edilen Hasta" : "";
                            //

                            workListItem.HasTightContactIsolation = (Boolean)(inpatientAdmission.HasTightContactIsolation == null ? false : inpatientAdmission.HasTightContactIsolation);
                            workListItem.HasFallingRisk = (Boolean)(inpatientAdmission.HasFallingRisk == null ? false : inpatientAdmission.HasFallingRisk);
                            workListItem.HasDropletIsolation = (Boolean)(inpatientAdmission.HasDropletIsolation == null ? false : inpatientAdmission.HasDropletIsolation);
                            workListItem.HasAirborneContactIsolation = (Boolean)(inpatientAdmission.HasAirborneContactIsolation == null ? false : inpatientAdmission.HasAirborneContactIsolation);
                            workListItem.HasContactIsolation = (Boolean)(inpatientAdmission.HasContactIsolation == null ? false : inpatientAdmission.HasContactIsolation);

                            if (treatClinicApp.RequestDate.HasValue)
                                workListItem.Date = treatClinicApp.RequestDate.Value;
                            workListItem.PatientNameSurname = patient.FullName;
                            workListItem.KabulNo = treatClinicApp.SubEpisode == null ? "" : treatClinicApp.SubEpisode.ProtocolNo;
                            workListItem.UniqueRefno = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = treatClinicApp.ObjectDef.ApplicationName;
                            workListItem.StateName = treatClinicApp.InpatientAcceptionType != null ? "Yatış Bekliyor" + InpatientAcceptionTypeInfo : "Klinik Kabul";
                            workListItem.MasterResource = treatClinicApp.MasterResource.Name;
                            workListItem.RoomBed = inpatientAdmission.Room == null ? "" : inpatientAdmission.Room.Name + "-" + inpatientAdmission.Bed == null ? "" : inpatientAdmission.Bed.Name;
                            workListItem.DoctorName = treatClinicApp.ProcedureDoctor == null ? "" : treatClinicApp.ProcedureDoctor.Name;
                            workListItem.InpatientDay = "";

                            workListItem.NurseName = treatClinicApp.ResponsibleNurse == null ? "" : treatClinicApp.ResponsibleNurse.Name;//Hemşire Adı

                            if (treatClinicApp.SubEpisode != null && treatClinicApp.SubEpisode.PatientAdmission != null && treatClinicApp.SubEpisode.PatientAdmission.AdmissionType != null)
                            {
                                workListItem.AdmissionType = treatClinicApp.SubEpisode.PatientAdmission.AdmissionType.provizyonTipiAdi;// Geliş Sebebi
                            }
                            if (treatClinicApp.Episode != null && treatClinicApp.Episode.Payer != null)
                                workListItem.PayerName = treatClinicApp.Episode.Payer.Name;
                            workListItem.BirthDate = patient.BirthDate.HasValue ? patient.BirthDate : null;// Doğum Tarihi

                            if (patient.BirthDate.HasValue)
                            {
                                var FullAge = Common.CalculateAge(workListItem.BirthDate.Value);
                                workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                            }

                            workListItem.FatherName = patient.FatherName;// Baba adı
                            if (patient.PatientAddress != null)
                                workListItem.TelNo = patient.PatientAddress.MobilePhone;// Telefon Numarası




                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();
                            if (episode != null)
                            {
                                CompanionApplication _companion = episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }
                if (!string.IsNullOrEmpty(whereCriteria_For_InPatientPhysicianApplication)) // Yatan Ve taburcu olmuş Hastalar için InPatientPhysicianApplication üzerinden alınan Sorgu
                {
                    var inPatientPhysicianApplicationList = InPatientPhysicianApplication.GetInPatientPhysicianApplicationForWL(objectContext, whereCriteria_For_InPatientPhysicianApplication);
                    foreach (var inPPAppFWL in inPatientPhysicianApplicationList)
                    {
                        InPatientPhysicianApplication inPatientPhysicianApplication = (InPatientPhysicianApplication)objectContext.GetObject((Guid)inPPAppFWL.ObjectID, "InPatientPhysicianApplication");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, inPatientPhysicianApplication))// BASEDEN KULLANILIYOR  
                        {
                            InPatientWorkListItem workListItem = new InPatientWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = inPatientPhysicianApplication.Episode;
                            var subepisode = inPatientPhysicianApplication.SubEpisode;

                            workListItem.ObjectDefID = inPPAppFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = inPPAppFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)inPPAppFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = inPPAppFWL.Prioritystatus;
                            this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }

                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                            if (workListItem.Pandemic)
                            {
                                workListItem.MedicalInformation = "Pandemic Hasta";
                            }

                            workListItem.isEmergency = inPPAppFWL.Isemergency == true ? true : false;
                            workListItem.OrderNumber = 40;
                            //

                            workListItem.HasTightContactIsolation = inPPAppFWL.HasTightContactIsolation == true ? true : false;
                            workListItem.HasFallingRisk = inPPAppFWL.HasFallingRisk == true ? true : false;
                            workListItem.HasDropletIsolation = inPPAppFWL.HasDropletIsolation == true ? true : false;
                            workListItem.HasAirborneContactIsolation = inPPAppFWL.HasAirborneContactIsolation == true ? true : false;
                            workListItem.HasContactIsolation = inPPAppFWL.HasContactIsolation == true ? true : false;

                            if (inPPAppFWL.Date != null)
                                workListItem.Date = Convert.ToDateTime(inPPAppFWL.Date);

                            if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate != null && inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                            {
                                workListItem.InpatientDay = (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate.Value - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                            }
                            else if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                            {
                                workListItem.InpatientDay = (Common.RecTime() - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                            }
                            else
                            {
                                workListItem.InpatientDay = "";
                            }

                            workListItem.PatientNameSurname = inPPAppFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = inPPAppFWL.Kabulno == null ? "" : inPPAppFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = inPPAppFWL.UniqueRefNo == null ? "" : inPPAppFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = inPPAppFWL.Episodeactionname == null ? "" : inPPAppFWL.Episodeactionname.ToString();
                            workListItem.StateName = inPPAppFWL.Statename == null ? "" : inPPAppFWL.Statename.ToString();
                            workListItem.MasterResource = inPPAppFWL.Masterresource == null ? "" : inPPAppFWL.Masterresource.ToString(); ;
                            workListItem.RoomBed = inPPAppFWL.Roombed == null ? "" : inPPAppFWL.Roombed.ToString();
                            workListItem.DoctorName = inPPAppFWL.Doctorname == null ? "" : inPPAppFWL.Doctorname.ToString();

                            workListItem.NurseName = inPPAppFWL.Nursename == null ? "" : inPPAppFWL.Nursename.ToString();  //Hemşire Adı
                            workListItem.AdmissionType = inPPAppFWL.Admissiontype == null ? "" : inPPAppFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = inPPAppFWL.Payername == null ? "" : inPPAppFWL.Payername.ToString();
                            if (inPPAppFWL.BirthDate != null)
                            {
                                workListItem.BirthDate = inPPAppFWL.BirthDate;// Doğum Tarihi
                                var FullAge = Common.CalculateAge(workListItem.BirthDate.Value);
                                workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                            }
                            workListItem.FatherName = inPPAppFWL.FatherName == null ? "" : inPPAppFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = inPPAppFWL.Telno == null ? "" : inPPAppFWL.Telno.ToString();  // Telefon Numarası

                            workListItem.HastaTuru = inPPAppFWL.Hastaturu == null ? "" : inPPAppFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = inPPAppFWL.Basvuruturu == null ? "" : inPPAppFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = inPPAppFWL.Oncelikdurumu == null ? "" : inPPAppFWL.Oncelikdurumu.ToString();
                            if (inPPAppFWL.Inpatientdate != null && (inPPAppFWL.CurrentStateDefID == InPatientPhysicianApplication.States.Discharged || inPPAppFWL.CurrentStateDefID == InPatientPhysicianApplication.States.PreDischarged))
                                workListItem.InpatientDate = Convert.ToDateTime(inPPAppFWL.Inpatientdate);
                            else
                                workListItem.InpatientDate = null;

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();
                            if (episode != null)
                            {
                                CompanionApplication _companion = episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }
                if (!string.IsNullOrEmpty(whereCriteria_For_TreatmentDischarge))// ön taburcu olmuş Hastalar için TreatmentDischarge üzerinden alınan Sorgu
                {
                    var treatmentDischargeList = TreatmentDischarge.GetTreatmentDischargeForWL(objectContext, whereCriteria_For_TreatmentDischarge);
                    foreach (var tdFWL in treatmentDischargeList)
                    {
                        TreatmentDischarge treatmentDischarge = (TreatmentDischarge)objectContext.GetObject((Guid)tdFWL.ObjectID, "TreatmentDischarge");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, treatmentDischarge))// BASEDEN KULLANILIYOR  
                        {
                            InPatientWorkListItem workListItem = new InPatientWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları

                            var episode = treatmentDischarge.Episode;
                            var subepisode = treatmentDischarge.SubEpisode;

                            workListItem.ObjectDefID = tdFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = tdFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)tdFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = tdFWL.Prioritystatus;
                            this.editedSetWorkListIkonProperties(PriorityStatus, treatmentDischarge.Episode.Patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }

                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                            if (workListItem.Pandemic)
                            {
                                workListItem.MedicalInformation = "Pandemic Hasta";
                            }

                            workListItem.isEmergency = tdFWL.Isemergency == true ? true : false;
                            workListItem.OrderNumber = 40;
                            //

                            workListItem.HasTightContactIsolation = tdFWL.HasTightContactIsolation == true ? true : false;
                            workListItem.HasFallingRisk = tdFWL.HasFallingRisk == true ? true : false;
                            workListItem.HasDropletIsolation = tdFWL.HasDropletIsolation == true ? true : false;
                            workListItem.HasAirborneContactIsolation = tdFWL.HasAirborneContactIsolation == true ? true : false;
                            workListItem.HasContactIsolation = tdFWL.HasContactIsolation == true ? true : false;

                            if (tdFWL.Date != null)
                                workListItem.Date = Convert.ToDateTime(tdFWL.Date);


                            if (treatmentDischarge.InPatientTreatmentClinicApp.ClinicDischargeDate != null && treatmentDischarge.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                            {
                                workListItem.InpatientDay = (treatmentDischarge.InPatientTreatmentClinicApp.ClinicDischargeDate.Value - treatmentDischarge.InPatientTreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                            }
                            else if (treatmentDischarge.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                            {
                                workListItem.InpatientDay = (Common.RecTime() - treatmentDischarge.InPatientTreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                            }
                            else
                            {
                                workListItem.InpatientDay = "";
                            }

                            workListItem.PatientNameSurname = tdFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = tdFWL.Kabulno == null ? "" : tdFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = tdFWL.UniqueRefNo == null ? "" : tdFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = tdFWL.Episodeactionname == null ? "" : tdFWL.Episodeactionname.ToString();
                            workListItem.StateName = tdFWL.Statename == null ? "" : tdFWL.Statename.ToString();
                            workListItem.MasterResource = tdFWL.Masterresource == null ? "" : tdFWL.Masterresource.ToString(); ;
                            workListItem.RoomBed = tdFWL.Roombed == null ? "" : tdFWL.Roombed.ToString();
                            workListItem.DoctorName = tdFWL.Doctorname == null ? "" : tdFWL.Doctorname.ToString();

                            workListItem.NurseName = tdFWL.Nursename == null ? "" : tdFWL.Nursename.ToString();  //Hemşire Adı
                            workListItem.AdmissionType = tdFWL.Admissiontype == null ? "" : tdFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = tdFWL.Payername == null ? "" : tdFWL.Payername.ToString();
                            if (tdFWL.BirthDate != null)
                            {
                                workListItem.BirthDate = tdFWL.BirthDate;// Doğum Tarihi
                                var FullAge = Common.CalculateAge(workListItem.BirthDate.Value);
                                workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                            }
                            workListItem.FatherName = tdFWL.FatherName == null ? "" : tdFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = tdFWL.Telno == null ? "" : tdFWL.Telno.ToString();  // Telefon Numarası

                            workListItem.HastaTuru = tdFWL.Hastaturu == null ? "" : tdFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = tdFWL.Basvuruturu == null ? "" : tdFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = tdFWL.Oncelikdurumu == null ? "" : tdFWL.Oncelikdurumu.ToString();
                            if (tdFWL.Inpatientdate != null && (tdFWL.CurrentStateDefID == TreatmentDischarge.States.PreDischarge || tdFWL.CurrentStateDefID == TreatmentDischarge.States.Discharged))
                                workListItem.InpatientDate = Convert.ToDateTime(tdFWL.Inpatientdate);
                            else
                            {
                                workListItem.InpatientDate = null;
                            }

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();
                            if (episode != null)
                            {
                                CompanionApplication _companion = episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }

                            //Taburcu işlemi açıldığında default olarak InPatientPhysicianApplication açılsın diye
                            foreach (var inPatientPhysicianApplication in treatmentDischarge.InPatientTreatmentClinicApp.InPatientPhysicianApplication)
                            {
                                TreatmentDischarge.TreatmentDischargeDefaultActionViewModel defaultActionViewModel = new TreatmentDischarge.TreatmentDischargeDefaultActionViewModel();
                                defaultActionViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
                                defaultActionViewModel.ApplicationName = inPatientPhysicianApplication.ObjectDef.ApplicationName;
                                defaultActionViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
                                workListItem.CompComponetOpeningInputParam = defaultActionViewModel;
                                break;
                            }

                            viewModel.WorkList.Add(workListItem);

                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }
                if (!string.IsNullOrEmpty(whereCriteria_For_Consultation)) // KOnsültasyon Hastaları için Consultation üzerinden alınan Sorgu
                {
                    var consultationList = Consultation.GetInPatientConsultationForWL(objectContext, whereCriteria_For_Consultation);
                    foreach (var consFWL in consultationList)
                    {
                        Consultation consultation = (Consultation)objectContext.GetObject((Guid)consFWL.ObjectID, "Consultation");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, consultation))// BASEDEN KULLANILIYOR  
                        {
                            InPatientWorkListItem workListItem = new InPatientWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = consultation.Episode;
                            var subepisode = consultation.SubEpisode;
                            workListItem.ObjectDefID = consFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = consFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)consFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = consFWL.Prioritystatus;

                            this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }

                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                            if (workListItem.Pandemic)
                            {
                                workListItem.MedicalInformation = "Pandemic Hasta";
                            }

                            workListItem.isEmergency = consFWL.Isemergency == true ? true : false;
                            workListItem.OrderNumber = 40;
                            //

                            if (consFWL.Date != null)
                                workListItem.Date = Convert.ToDateTime(consFWL.Date);
                            workListItem.PatientNameSurname = consFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = consFWL.Kabulno == null ? "" : consFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = consFWL.UniqueRefNo == null ? "" : consFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = consFWL.Episodeactionname == null ? "" : consFWL.Episodeactionname.ToString();
                            workListItem.StateName = consFWL.Statename == null ? "" : consFWL.Statename.ToString();
                            workListItem.MasterResource = consFWL.Masterresource == null ? "" : consFWL.Masterresource.ToString(); ;
                            workListItem.DoctorName = consFWL.Doctorname == null ? "" : consFWL.Doctorname.ToString();
                            workListItem.InpatientDay = "";
                            workListItem.AdmissionType = consFWL.Admissiontype == null ? "" : consFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = consFWL.Payername == null ? "" : consFWL.Payername.ToString();
                            if (consFWL.BirthDate != null)
                            {
                                workListItem.BirthDate = consFWL.BirthDate;// Doğum Tarihi
                                var FullAge = Common.CalculateAge(workListItem.BirthDate.Value);
                                workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                            }
                            workListItem.FatherName = consFWL.FatherName == null ? "" : consFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = consFWL.Telno == null ? "" : consFWL.Telno.ToString();  // Telefon Numarası

                            workListItem.HastaTuru = consFWL.Hastaturu == null ? "" : consFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = consFWL.Basvuruturu == null ? "" : consFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = consFWL.Oncelikdurumu == null ? "" : consFWL.Oncelikdurumu.ToString();

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();
                            if (episode != null)
                            {
                                CompanionApplication _companion = episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }

                            foreach (var inpatientAdmission in episode.InpatientAdmissions)
                            {
                                if (inpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure) // aynı anda iki tane aktif yatan hasta işlemi olamaz
                                {
                                    workListItem.HasTightContactIsolation = inpatientAdmission.HasTightContactIsolation == true ? true : false;
                                    workListItem.HasFallingRisk = inpatientAdmission.HasFallingRisk == true ? true : false;
                                    workListItem.HasDropletIsolation = inpatientAdmission.HasDropletIsolation == true ? true : false;
                                    workListItem.HasAirborneContactIsolation = inpatientAdmission.HasAirborneContactIsolation == true ? true : false;
                                    workListItem.HasContactIsolation = inpatientAdmission.HasContactIsolation == true ? true : false;
                                    workListItem.RoomBed = inpatientAdmission.Room == null ? "" : inpatientAdmission.Room.Name + "-" + inpatientAdmission.Bed == null ? "" : inpatientAdmission.Bed.Name;

                                    workListItem.NurseName = "";  //Hemşire Adı gerkli bişey değil boşuna yavaşlatmayalım
                                    break;
                                }
                            }

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }
                //Hasta Katılım Payından Muaf İlaç Raporu
                if (!string.IsNullOrEmpty(whereCriteria_For_ParticipatnFreeDrugReport))
                {
                    var reportList = ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL(objectContext, whereCriteria_For_ParticipatnFreeDrugReport);
                    foreach (var reportFWL in reportList)
                    {
                        ParticipatnFreeDrugReport participatnFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "ParticipatnFreeDrugReport");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, participatnFreeDrugReport))// BASEDEN KULLANILIYOR  
                        {
                            InPatientWorkListItem workListItem = new InPatientWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = participatnFreeDrugReport.Episode;
                            var subepisode = participatnFreeDrugReport.SubEpisode;
                            workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = reportFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)reportFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = reportFWL.Prioritystatus;
                            this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }

                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                            if (workListItem.Pandemic)
                            {
                                workListItem.MedicalInformation = "Pandemic Hasta";
                            }

                            workListItem.isEmergency = reportFWL.Isemergency == true ? true : false;
                            workListItem.OrderNumber = 40;
                            //

                            if (reportFWL.Date != null)
                                workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                            workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = reportFWL.Episodeactionname == null ? "" : reportFWL.Episodeactionname.ToString();
                            workListItem.StateName = reportFWL.Statename == null ? "" : reportFWL.Statename.ToString();
                            workListItem.MasterResource = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                            workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();
                            workListItem.InpatientDay = "";
                            workListItem.AdmissionType = reportFWL.Admissiontype == null ? "" : reportFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = reportFWL.Payername == null ? "" : reportFWL.Payername.ToString();
                            if (reportFWL.BirthDate != null)
                            {
                                workListItem.BirthDate = reportFWL.BirthDate;// Doğum Tarihi
                                var FullAge = Common.CalculateAge(workListItem.BirthDate.Value);
                                workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                            }
                            workListItem.FatherName = reportFWL.FatherName == null ? "" : reportFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = reportFWL.Telno == null ? "" : reportFWL.Telno.ToString();  // Telefon Numarası

                            workListItem.HastaTuru = reportFWL.Hastaturu == null ? "" : reportFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = reportFWL.Basvuruturu == null ? "" : reportFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = reportFWL.Oncelikdurumu == null ? "" : reportFWL.Oncelikdurumu.ToString();

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();
                            if (episode != null)
                            {
                                CompanionApplication _companion = episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }

                            foreach (var inpatientAdmission in episode.InpatientAdmissions)
                            {
                                if (inpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure) // aynı anda iki tane aktif yatan hasta işlemi olamaz
                                {
                                    workListItem.HasTightContactIsolation = inpatientAdmission.HasTightContactIsolation == true ? true : false;
                                    workListItem.HasFallingRisk = inpatientAdmission.HasFallingRisk == true ? true : false;
                                    workListItem.HasDropletIsolation = inpatientAdmission.HasDropletIsolation == true ? true : false;
                                    workListItem.HasAirborneContactIsolation = inpatientAdmission.HasAirborneContactIsolation == true ? true : false;
                                    workListItem.HasContactIsolation = inpatientAdmission.HasContactIsolation == true ? true : false;
                                    workListItem.RoomBed = inpatientAdmission.Room == null ? "" : inpatientAdmission.Room.Name + "-" + inpatientAdmission.Bed == null ? "" : inpatientAdmission.Bed.Name;

                                    workListItem.NurseName = "";  //Hemşire Adı gerkli bişey değil boşuna yavaşlatmayalım
                                    break;
                                }
                            }
                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }

                ////Tıbbi Malzeme Raporu
                if (!string.IsNullOrEmpty(whereCriteria_For_MedicalStuffReport))
                {
                    var reportList = MedicalStuffReport.GetMedicalStuffReportForWL(objectContext, whereCriteria_For_MedicalStuffReport);
                    foreach (var reportFWL in reportList)
                    {
                        MedicalStuffReport medicalStuffReport = (MedicalStuffReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "MedicalStuffReport");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, medicalStuffReport))// BASEDEN KULLANILIYOR  
                        {
                            InPatientWorkListItem workListItem = new InPatientWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = medicalStuffReport.Episode;
                            var subepisode = medicalStuffReport.SubEpisode;

                            workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = reportFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)reportFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = reportFWL.Prioritystatus;
                            this.setWorkListIkonPropertyies(PriorityStatus, episode.Patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }

                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                            if (workListItem.Pandemic)
                            {
                                workListItem.MedicalInformation = "Pandemic Hasta";
                            }

                            workListItem.isEmergency = reportFWL.Isemergency == true ? true : false;
                            workListItem.OrderNumber = 40;
                            //

                            if (reportFWL.Date != null)
                                workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                            workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = reportFWL.Episodeactionname == null ? "" : reportFWL.Episodeactionname.ToString();
                            workListItem.StateName = reportFWL.Statename == null ? "" : reportFWL.Statename.ToString();
                            workListItem.MasterResource = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                            workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();
                            workListItem.InpatientDay = "";
                            workListItem.AdmissionType = reportFWL.Admissiontype == null ? "" : reportFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = reportFWL.Payername == null ? "" : reportFWL.Payername.ToString();
                            if (reportFWL.BirthDate != null)
                            {
                                workListItem.BirthDate = reportFWL.BirthDate;// Doğum Tarihi
                                var FullAge = Common.CalculateAge(workListItem.BirthDate.Value);
                                workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                            }
                            workListItem.FatherName = reportFWL.FatherName == null ? "" : reportFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = reportFWL.Telno == null ? "" : reportFWL.Telno.ToString();  // Telefon Numarası


                            workListItem.HastaTuru = reportFWL.Hastaturu == null ? "" : reportFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = reportFWL.Basvuruturu == null ? "" : reportFWL.Basvuruturu.ToString();
                            // workListItem.OncelikDurumu = reportFWL.Oncelikdurumu == null ? "" : reportFWL.Oncelikdurumu.ToString();

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();
                            if (episode != null)
                            {
                                CompanionApplication _companion = episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }

                            foreach (var inpatientAdmission in episode.InpatientAdmissions)
                            {
                                if (inpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure) // aynı anda iki tane aktif yatan hasta işlemi olamaz
                                {
                                    workListItem.HasTightContactIsolation = inpatientAdmission.HasTightContactIsolation == true ? true : false;
                                    workListItem.HasFallingRisk = inpatientAdmission.HasFallingRisk == true ? true : false;
                                    workListItem.HasDropletIsolation = inpatientAdmission.HasDropletIsolation == true ? true : false;
                                    workListItem.HasAirborneContactIsolation = inpatientAdmission.HasAirborneContactIsolation == true ? true : false;
                                    workListItem.HasContactIsolation = inpatientAdmission.HasContactIsolation == true ? true : false;
                                    workListItem.RoomBed = inpatientAdmission.Room == null ? "" : inpatientAdmission.Room.Name + "-" + inpatientAdmission.Bed == null ? "" : inpatientAdmission.Bed.Name;

                                    workListItem.NurseName = "";  //Hemşire Adı gerkli bişey değil boşuna yavaşlatmayalım
                                    break;
                                }
                            }

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }
                viewModel.WorkList = viewModel.WorkList.OrderByDescending(dr => dr.Date).OrderBy(c => c.OrderNumber).ToList();
                return viewModel;
            }
        }

        [HttpGet]
        public InpatientStatisticReportViewModel LoadInpatientReportViewModel()
        {
            InpatientStatisticReportViewModel model = new InpatientStatisticReportViewModel();
            using (var objectContext = new TTObjectContext(false))
            {

                model.ClinicList = new List<ReportBaseModel>();
                model.SpecialityList = new List<ReportBaseModel>();
                BindingList<ResClinic.GetActiveClinics_Class> clinics = ResClinic.GetActiveClinics();
                foreach (ResClinic.GetActiveClinics_Class clinic in clinics)
                {
                    ReportBaseModel m = new ReportBaseModel();
                    m.ObjectID = new Guid(clinic.ObjectID.ToString());
                    m.Name = clinic.Name;
                    model.ClinicList.Add(m);
                }
                BindingList<SpecialityDefinition.GetAllSpecialityDefinition_Class> specialityList = SpecialityDefinition.GetAllSpecialityDefinition(" WHERE ISACTIVE = 1 ORDER BY NAME ASC");
                foreach (SpecialityDefinition.GetAllSpecialityDefinition_Class speciality in specialityList)
                {
                    ReportBaseModel m = new ReportBaseModel();
                    m.ObjectID = new Guid(speciality.ObjectID.ToString());
                    m.Name = speciality.Name;
                    model.SpecialityList.Add(m);
                }

                model.ReportDate = DateTime.Now;
                model.InpatientStartDate = DateTime.Now;
                model.InpatientEndDate = DateTime.Now;
                model.DischargeStartDate = DateTime.Now;
                model.DischargeEndDate = DateTime.Now;


            }
            return model;
        }

        [HttpPost]
        public InPatientListForStatisticReport[] ListInpatientsForStatisticReport(ListInput input)
        {
            List<InPatientListForStatisticReport> resultList = new List<InPatientListForStatisticReport>();

            using (var objectContext = new TTObjectContext(false))
            {
                List<Guid> clinicList = new List<Guid>();
                List<Guid> diagnosisParamList = new List<Guid>();
                List<Guid> procedureList = new List<Guid>();
                foreach (ReportBaseModel clinic in input.SelectedClinics)
                {
                    clinicList.Add(clinic.ObjectID);
                }

                foreach (DiagnosisAndProcedureBaseModel diagnosis in input.DiagnosisList)
                {
                    diagnosisParamList.Add(diagnosis.ObjectID);
                }

                foreach (DiagnosisAndProcedureBaseModel procedure in input.ProcedureList)
                {
                    procedureList.Add(procedure.ObjectID);
                }

                string injectionSql = "";
                if (input.InpatientStartDate != null && input.InpatientEndDate != null)
                {
                    injectionSql += " AND THIS.InPatientTreatmentClinicApp.ClinicInpatientDate BETWEEN " + GetDateAsString(input.InpatientStartDate) + " AND " + GetDateAsString(input.InpatientStartDate);
                }

                if (input.DischargeStartDate != null && input.DischargeEndDate != null)
                {
                    injectionSql += " AND THIS.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(input.DischargeStartDate) + " AND " + GetDateAsString(input.DischargeEndDate);

                }
                BindingList<InPatientPhysicianApplication.GetInpatientsByClinic_Class> inpatientList = InPatientPhysicianApplication.GetInpatientsByClinic(clinicList, diagnosisParamList, procedureList, injectionSql);
                foreach (var inpatient in inpatientList)
                {
                    InPatientListForStatisticReport i = new InPatientListForStatisticReport();
                    i.PatientNameSurame = inpatient.Patientname + " " + inpatient.Patientsurname;
                    i.UniqueRefNo = inpatient.UniqueRefNo == null ? "" : inpatient.UniqueRefNo.ToString();
                    i.ClinicInpatientDate = inpatient.ClinicInpatientDate == null ? "" : Convert.ToDateTime(inpatient.ClinicInpatientDate).ToString("dd.MM.yyyy HH:mm");
                    i.ClinicDischargeDate = inpatient.ClinicDischargeDate == null ? "" : Convert.ToDateTime(inpatient.ClinicDischargeDate).ToString("dd.MM.yyyy HH:mm");
                    i.SubepisodeID = inpatient.Subepisodeid.ToString();
                    i.EpisodeID = inpatient.Episodeid.ToString();
                    string injectionSqlTreatmentMaterial = string.Empty;
                    injectionSqlTreatmentMaterial = " AND MATERIAL.OBJECTDEFID='65a2337c-bc3c-4c6b-9575-ad47fa7a9a89'  AND EPISODEACTION.SUBEPISODE= '" + inpatient.Subepisodeid.ToString() + "'";
                    BindingList<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class> baseTreatmentList = BaseTreatmentMaterial.GetTreatmentMatByParameter(injectionSqlTreatmentMaterial);
                    foreach (BaseTreatmentMaterial.GetTreatmentMatByParameter_Class medicine in baseTreatmentList)
                    {
                        i.Medicines = medicine.Drugname.ToString() + "\n";

                    }

                    var radiologyTestList = RadiologyTest.GetRadTestBySubEpisode(objectContext, new Guid(inpatient.Subepisodeid.ToString()), inpatient.Episodeid.ToString());
                    i.RadiologyTests = new List<RadiologyTestInfo>();
                    foreach (var test in radiologyTestList)
                    {
                        if (((RadiologyTestDefinition)test.ProcedureObject).TestType.Name == "CT")
                        {
                            RadiologyTestInfo info = new RadiologyTestInfo();
                            info.ObjectID = test.ObjectID.ToString();
                            info.Code = test.ProcedureObject.Code;
                            info.Name = test.ProcedureObject.Name;
                            info.CurrentStateID = test.CurrentStateDefID.ToString();
                            info.CurrentStateName = test.CurrentStateDef.DisplayText;
                            i.RadiologyTests.Add(info);
                        }
                    }

                    var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, inpatient.Subepisodeid.ToString());
                    i.Diagnosis = "";
                    foreach (DiagnosisGrid d in diagnosisList)
                    {
                        if (i.Diagnosis == "")
                            i.Diagnosis = d.Diagnose.Code + "-" + d.Diagnose.Name;
                        else
                            i.Diagnosis += ", " + d.Diagnose.Code + "-" + d.Diagnose.Name;

                    }



                    resultList.Add(i);
                }
            }

            return resultList.ToArray();
        }

        public List<ReportBaseModel> FilterClinicsBySelectedSpecialities(FilterInput input)
        {
            List<ReportBaseModel> clinicList = new List<ReportBaseModel>();
            List<Guid> specialityObjectIDList = new List<Guid>();
            foreach (ReportBaseModel speciality in input.SelectedSpecialities)
            {
                specialityObjectIDList.Add(speciality.ObjectID);
            }
            BindingList<ResClinic.GetActiveClinicsBySpeciality_Class> clinics = ResClinic.GetActiveClinicsBySpeciality(specialityObjectIDList, null);
            foreach (ResClinic.GetActiveClinicsBySpeciality_Class clinic in clinics)
            {
                ReportBaseModel m = new ReportBaseModel();
                m.ObjectID = new Guid(clinic.ObjectID.ToString());
                m.Name = clinic.Name;
                clinicList.Add(m);
            }

            return clinicList;
        }

    }
}
namespace Core.Models
{
    public partial class InPatientWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<InPatientWorkListItem> WorkList;
        public InPatientWorkListSearchCriteria _SearchCriteria
        {
            get;
            set;
        }

        public List<ResSection> ResourceList { get; set; }

        public InPatientWorkListViewModel()
        {
            this._SearchCriteria = new InPatientWorkListSearchCriteria();
            this.WorkList = new List<InPatientWorkListItem>();
        }
    }

    [Serializable]
    public class InPatientWorkListSearchCriteria : BaseEpisodeActionWorkListSearchCriteria
    {
        //Getirilecek EpisodeAction Tipi
        public bool inPatientPhysicianApplication_EA
        {
            get;
            set;
        }

        public bool consultation_EA
        {
            get;
            set;
        }

        public bool participatnFreeDrugReport_EA
        {
            get;
            set;
        }

        // inPatientPhysicianApplication_EA ise state sorguları

        public bool acception // Önkabulde  bekleyenler 
        {
            get;
            set;
        }

        public bool inpatient // Aktif olarak Yatanlar
        {
            get;
            set;
        }

        public bool predischarge // Ön Taburcu olanlar
        {
            get;
            set;
        }
        public bool discharge // Taburcu olanlar
        {
            get;
            set;
        }

        public bool dailyInpatient // Gunubirlik Yatis
        {
            get;
            set;
        }

        // consultation_EA ise state sorguları

        public bool waiting_consultation // bekleyenler 
        {
            get;
            set;
        }

        public bool in_consultation// Takipde
        {
            get;
            set;
        }

        public bool closed_consultation // Bitirilenler
        {
            get;
            set;
        }
        public bool rejected_consultation // Reddedilenler
        {
            get;
            set;
        }

        public bool send_consultation // Gönderilenler
        {
            get;
            set;
        }

        // participatnFreeDrugReport_EA ise state sorguları

        public bool report //Rapor adımında
        {
            get;
            set;
        }

        public bool waiting_doctor //ikinci-üçüncü doktor adımında
        {
            get;
            set;
        }

        public bool waiting_headdoctor //başhekim adımında
        {
            get;
            set;
        }

        public bool completed_report//Tamamlanan (Rapor onayı tamamlanan hastalar)
        {
            get;
            set;
        }

        public bool rejected_report // Bekleyen(Rapor onayı bekleyen hastalar)
        {
            get;
            set;
        }


        public bool OnlyOwnPatient // Yalnız Kendi Hastaları
        {
            get;
            set;
        }

        public bool HasSurgery // Ameliyat İstemi olan Hastalar
        {
            get;
            set;
        }

        public List<ResSection> Resources
        {
            get;
            set;
        }

        public string ProtocolNo { get; set; }

        public string ReportChasingNo { get; set; }
        public bool HasVacation { get; set; }
    }

    public class InPatientWorkListItem : BaseEpisodeActionWorkListItem
    {
        public int OrderNumber { get; set; }//Yatış bekleyen hastaları en üstte göstermek için sıralama numarası

        // Yatan hasta ikonları için 
        public bool HasTightContactIsolation
        {
            get;
            set;
        }

        public bool HasFallingRisk
        {
            get;
            set;
        }

        public bool HasDropletIsolation
        {
            get;
            set;
        }

        public bool HasAirborneContactIsolation
        {
            get;
            set;
        }

        public bool HasContactIsolation
        {
            get;
            set;
        }

        // Kolonları İçin 
        public DateTime Date //Tarih
        {
            get;
            set;
        }
        public string PatientNameSurname //Adı Soyadı
        {
            get;
            set;
        }

        public string EpisodeActionName //İşlem
        {
            get;
            set;
        }
        public string StateName //Durumu
        {
            get;
            set;
        }
        public string MasterResource //  Birim 
        {
            get;
            set;
        }
        public string RoomBed //Oda / Yatak
        {
            get;
            set;
        }
        public string DoctorName //Doktor Adı
        {
            get;
            set;
        }
        public string InpatientDay//hastanın yattığı gün bilgisi
        {
            get;
            set;
        }

        // Gizli Kolonları için

        public string UniqueRefno // Kimlik No
        {
            get;
            set;
        }

        public string KabulNo //Kabul No
        {
            get;
            set;
        }
        public string NurseName //Hemşire Adı
        {
            get;
            set;
        }

        public string AdmissionType // Geliş Sebebi
        {
            get;
            set;
        }
        public string PayerName // Kurumu
        {
            get;
            set;
        }
        public DateTime? BirthDate // Doğum Tarihi
        {
            get;
            set;
        }
        public string Age { get; set; }

        public string FatherName // Baba adı
        {
            get;
            set;
        }

        public string TelNo // Telefon Numarası
        {
            get;
            set;
        }

        public string HastaTuru
        {
            get;
            set;
        }
        public string BasvuruTuru
        {
            get;
            set;
        }

        public string OncelikDurumu
        {
            get;
            set;
        }
        public string Diagnosis
        {
            get;
            set;
        }

        public string Companion
        {
            get;
            set;
        }


        public DateTime? InpatientDate
        {
            get;
            set;
        }

    }
    public class InpatientStatisticReportViewModel
    {
        public List<ReportBaseModel> ClinicList { get; set; }
        public List<ReportBaseModel> SpecialityList { get; set; }
        public DateTime ReportDate;
        public DateTime InpatientStartDate;
        public DateTime InpatientEndDate;
        public DateTime DischargeStartDate;
        public DateTime DischargeEndDate;

    }

    public class InPatientListForStatisticReport
    {
        public string PatientNameSurame { get; set; }
        public string UniqueRefNo { get; set; }
        public string ClinicInpatientDate { get; set; }
        public string ClinicDischargeDate { get; set; }
        public string SubepisodeID { get; set; }
        public string EpisodeID { get; set; }
        public string Medicines { get; set; }
        public string Diagnosis { get; set; }
        public List<RadiologyTestInfo> RadiologyTests { get; set; }

    }

    public class RadiologyTestInfo
    {
        public string ObjectID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CurrentStateID { get; set; }
        public string CurrentStateName { get; set; }

    }

    public class ReportBaseModel
    {
        public Guid ObjectID;
        public string Name;
    }

    public class ListInput
    {
        public DateTime InpatientStartDate
        {
            get;
            set;
        }
        public DateTime InpatientEndDate
        {
            get;
            set;
        }

        public DateTime DischargeStartDate
        {
            get;
            set;
        }
        public DateTime DischargeEndDate
        {
            get;
            set;
        }

        public List<ReportBaseModel> SelectedClinics;

        public List<DiagnosisAndProcedureBaseModel> DiagnosisList;
        public List<DiagnosisAndProcedureBaseModel> ProcedureList;

    }

    public class FilterInput
    {
        public List<ReportBaseModel> SelectedSpecialities { get; set; }

    }

    public class DiagnosisAndProcedureBaseModel
    {
        public Guid ObjectID;
        public string Code;
        public string Name;
    }

}
