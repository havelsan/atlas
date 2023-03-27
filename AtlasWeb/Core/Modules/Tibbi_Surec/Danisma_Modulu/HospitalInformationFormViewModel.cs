//$8960EE59
using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class HospitalInformationServiceController
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Danisma_Islemleri)]
        public List<ResSectionLocationResults> LoadLocationGrid(LocationSearchModel model)
        {
            List<ResSectionLocationResults> results = new List<ResSectionLocationResults>();
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    string filterExpression = "";
                    if (model != null && model.Policlinic != null)
                    {
                        filterExpression = " AND ObjectID = '" + model.Policlinic + "' ";
                    }

                    BindingList<ResSection> allSections = ResSection.GetOnlyPoliclinics(context, filterExpression);
                    foreach (ResSection res in allSections)
                    {
                        ResSectionLocationResults resResult = new ResSectionLocationResults();

                        resResult.PoliclinicObjectId = res.ObjectID;
                        resResult.Policlinic = res.Name;
                        resResult.FloorInfo = res.ContactAddress;
                        resResult.Phone = res.DeskPhoneNumber;
                        resResult.LocationInfo = res.Location;

                        results.Add(resResult);

                    }

                    return results;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }




        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Personel_Arama)]
        public List<PersonnelSearchingResultModel> PersonnelSearchingWithDetailsForm(PersonnelSearchModel personnelSearchModel)
        {
            if (personnelSearchModel == null)
                return new List<PersonnelSearchingResultModel>();

            using (var context = new TTObjectContext(false))
            {
                try
                {
                    List<PersonnelSearchingResultModel> resultList = new List<PersonnelSearchingResultModel>();
                    string filterExpression = string.Empty;

                    filterExpression = "WHERE 1=1";

                    if(personnelSearchModel.DateOfJoin != null)
                    {
                        filterExpression += " AND DATEOFJOIN = TODATE('" + personnelSearchModel.DateOfJoin.Value.ToString("yyyy-MM-dd") + "')";
                    }
                    if (personnelSearchModel.DateOfLeave != null)
                    {
                        filterExpression += " AND DATEOFLEAVE = TODATE('" + personnelSearchModel.DateOfLeave.Value.ToString("yyyy-MM-dd") + "')";
                    }
                    if(personnelSearchModel.Mission != null)
                    {
                        filterExpression += " AND USERTYPE =  " + (Common.GetEnumValueDefOfEnumValue((UserTypeEnum)personnelSearchModel.Mission)).Value ;
                    }
                    if(personnelSearchModel.Title != null)
                    {
                        filterExpression += " AND TITLE = " + (Common.GetEnumValueDefOfEnumValue((UserTitleEnum)personnelSearchModel.Title)).Value ;
                    }
                    if(!String.IsNullOrEmpty(personnelSearchModel.Name))
                    {
                        filterExpression += " AND upper(PERSON.NAME) LIKE upper('" + personnelSearchModel.Name + "')"; 

                    }
                    if (!String.IsNullOrEmpty(personnelSearchModel.Surname))
                    {
                        filterExpression += " AND upper(PERSON.SURNAME) LIKE upper('" + personnelSearchModel.Surname + "')";
                    }
                    if(personnelSearchModel.Section != null)
                    {
                        filterExpression += " AND this.USERRESOURCES(RESOURCE.OBJECTID = '" + personnelSearchModel.Section.ObjectID + "').EXISTS";
                    }

                    if (personnelSearchModel.Department != null)
                    {
                        filterExpression += " AND this.ResourceSpecialities(Speciality.OBJECTID = '" + personnelSearchModel.Department.ObjectID + "').EXISTS";
                    }

                    if (filterExpression != "")
                    {
                        BindingList<ResUser> userList = ResUser.GetResUserByInjection(context, filterExpression);
                        foreach (ResUser resUser in userList)
                        {
                            PersonnelSearchingResultModel resultPersonnelModel = new PersonnelSearchingResultModel(resUser);
                            resultList.Add(resultPersonnelModel);
                        }
                    }
                    return resultList;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Sorgulama)]
        public List<AppointmentSearchingResultModel> AppointmentSearchingWithDetails(AppointmentSearchModel appointmentSearchModel)
        {
            if (appointmentSearchModel == null)
                return new List<AppointmentSearchingResultModel>();

            using (var context = new TTObjectContext(false))
            {
                //TODO DD: BirthCity , appointmentSearchModel.AdmissionNo
                var filter = Patient.GetFilterExpression(appointmentSearchModel.UnicRefNo, appointmentSearchModel.Name, appointmentSearchModel.Surname, appointmentSearchModel.FatherName, appointmentSearchModel.MotherName, appointmentSearchModel.BirthDate, null, null);

                BindingList<Patient.GetPatientByInjection_Class> list = Patient.GetPatientByInjection(context, filter);
                List<AppointmentSearchingResultModel> AppointmentsResults = new List<AppointmentSearchingResultModel>();

                if (list.Count != 0)
                {

                    foreach (Patient.GetPatientByInjection_Class patientByInjection in list)
                    {
                        BindingList<Appointment> Appointments = Appointment.GetByPatientAndDate(context, appointmentSearchModel.DateFirst, appointmentSearchModel.DateSecond, patientByInjection.ObjectID.ToString());
                        foreach (Appointment appointment in Appointments)
                        {
                            AppointmentSearchingResultModel AppointmentsResult = new AppointmentSearchingResultModel(appointment);
                            AppointmentsResults.Add(AppointmentsResult);
                        }
                    }
                }
                return AppointmentsResults;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Ziyaretci_Sorgulama)]
        public List<PatientVisitorResultModel> LoadPatientVisitors(VisitorSearchModel VisitorSearchModel)
        {
            if (VisitorSearchModel == null)
                return new List<PatientVisitorResultModel>();

            using (var context = new TTObjectContext(false))
            {
                BindingList<PatientVisitor> PatientVisitors = PatientVisitor.GetByDate(context, VisitorSearchModel.firstDate, VisitorSearchModel.secondDate);
                List<PatientVisitorResultModel> PatientVisitorResults = new List<PatientVisitorResultModel>();
                foreach (PatientVisitor pv in PatientVisitors)
                {
                    PatientVisitorResultModel PatientVisitorResult = new PatientVisitorResultModel(pv);
                    PatientVisitorResults.Add(PatientVisitorResult);
                }

                return PatientVisitorResults;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Ziyaretci_Kaydi)]
        public string SavePatientVisitor(PatientVisitor PatientVisitor)
        {
            if (PatientVisitor == null)
                throw new ArgumentNullException("NULL", "Ziyaretçi verisi anlamlı değil");
            var formDefID = Guid.Parse("98c20fcb-0536-4f33-a747-8d7b4bf0cf56");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(PatientVisitor);
                objectContext.ProcessRawObjects();
                var patientVisitor= (PatientVisitor)objectContext.GetLoadedObject(PatientVisitor.ObjectID);

                if (patientVisitor.Patient == null)
                    throw new ArgumentNullException("NULL", TTUtils.CultureService.GetText("M27274", "Ziyaretçi olunacak hasta verisi anlamlı değil"));

                try
                {

                    foreach (Episode episode in patientVisitor.Patient.Episodes)
                    {
                        foreach (SubEpisode se in episode.SubEpisodes)
                        {
                            if (!String.IsNullOrEmpty(se.isolationInformation()))
                                throw new Exception(TTUtils.CultureService.GetText("M26079", "İlgili hasta için ziyaretçi kabulü yapılamaz." + se.isolationInformation()));
                        }
                    }
                    objectContext.Save();
                }
                catch (Exception)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M27273", "Ziyaretçi Kaydı İşlemi Başarısızdır."));
                }
            }

            return "SUCCESS";
        }


        [HttpPost]
        public BindingList<ResSection> GetPoliclinicList()
        {
            using (var context = new TTObjectContext(false))
            {
                string filter = "AND THIS.ISACTIVE = 1";
                BindingList<ResSection> PoliclinicList = ResSection.GetOnlyPoliclinics(context, filter);
                context.FullPartialllyLoadedObjects();
                return PoliclinicList;
            }
        }

        [HttpPost]
        public BindingList<ResourceModel> GetResourceList()
        {
            using (
                var context = new TTObjectContext(false))
            {
                BindingList<ResSection.GetResSectionForHospitalInfo_Class> PoliclinicList = ResSection.GetResSectionForHospitalInfo("");
                BindingList<ResourceModel> resourceList = new BindingList<ResourceModel>();
                foreach (ResSection.GetResSectionForHospitalInfo_Class item in PoliclinicList)
                {
                    ResourceModel model = new ResourceModel();
                    model.Name = item.Name;
                    model.ID = item.ObjectID;
                    resourceList.Add(model);
                }
                return resourceList;
            }
        }

        [HttpPost]
        public BindingList<ResourceModel> GetResClinicList()
        {
            using (
                var context = new TTObjectContext(false))
            {
                BindingList<ResSection.GetResClinicForHospitalInfo_Class> ClinicList = ResSection.GetResClinicForHospitalInfo("");
                BindingList<ResourceModel> resourceList = new BindingList<ResourceModel>();
                foreach (ResSection.GetResClinicForHospitalInfo_Class item in ClinicList)
                {
                    ResourceModel model = new ResourceModel();
                    model.Name = item.Name;
                    model.ID = item.ObjectID;
                    resourceList.Add(model);
                }
                return resourceList;
            }
        }

        [HttpGet]
        public List<ExaminationSearchingResultModel> GetPatientExaminationList(Guid ResourceID)
        {
            using (var context = new TTObjectContext(false))
            {
                string whereCriteria_Examination = " AND this.MASTERRESOURCE = '" + ResourceID + "'";
                string examination_States = string.Empty;

                if (!string.IsNullOrEmpty(examination_States))
                    examination_States += ",";
                examination_States += "States.Examination";

                if (!string.IsNullOrEmpty(examination_States))
                    examination_States += ",";
                examination_States += "States.ProcedureRequested";

     
                whereCriteria_Examination += " AND this.REQUESTDATE BETWEEN " + "TODATE('" + Convert.ToDateTime(Common.RecTime().Date).ToString("yyyy-MM-dd HH:mm:ss") + "')" + " AND " + "TODATE('" + Convert.ToDateTime(Common.RecTime().Date.AddDays(1).AddSeconds(-1)).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                whereCriteria_Examination += " AND this.CURRENTSTATEDEFID IN(" + examination_States + ")";

                var examinationList = PatientExamination.GetPatientExaminationForWL(context, whereCriteria_Examination);
                List<ExaminationSearchingResultModel> examinationWorkListItems = new List<ExaminationSearchingResultModel>();
                PatientAdmissionServiceController pas = new PatientAdmissionServiceController();
                foreach (var examFWL in examinationList)
                {
                    PatientExamination patientExamination = (PatientExamination)context.GetObject((Guid)examFWL.ObjectID, "PatientExamination");
                    ExaminationSearchingResultModel workListItem = new ExaminationSearchingResultModel();

                    workListItem.StateName = examFWL.Statename == null ? "" : examFWL.Statename.ToString();
                    workListItem.DoctorName = examFWL.Doctorname == null ? "" : examFWL.Doctorname.ToString();
                    workListItem.ExaminationProtocolNo = examFWL.Examinationprotocolno == null ? "" : examFWL.Examinationprotocolno.ToString();
                    workListItem.PatientNameSurname = examFWL.Patientnamesurname.ToString();
                    workListItem.KabulNo = examFWL.Kabulno == null ? "" : examFWL.Kabulno.ToString();
                    workListItem.UniqueRefno = examFWL.UniqueRefNo == null ? "" : examFWL.UniqueRefNo.ToString();
                    workListItem.ExpectedExaminationTime = pas.ExpectedExaminationTime((Guid)examFWL.Patientadmission);
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
                        workListItem.AdmissionQueueNo = Common.GetFormattedAdmissionQueueNumber(patientExamination, patientExamination.SubEpisode.PatientAdmission, true, appointment == null);

                    }
                    examinationWorkListItems.Add(workListItem);
                }
                pas.Dispose();


                return examinationWorkListItems;
            }
        }
    }
}
    namespace Core.Models
    {
        public class PersonnelSearchModel
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public UserTypeEnum? Mission { get; set; } //görev
            public UserTitleEnum? Title { get; set; } //ünvan
            public ResSection Section { get; set; } //bölüm
            public SpecialityDefinition Department { get; set; } //branş?
            public DateTime? DateOfJoin { get; set; }
            public DateTime? DateOfLeave { get; set; }

            //public string GetFilterExpression()
            //{

            //    string filterExpression = "";


            //    ArrayList NameTokens = new ArrayList();
            //    ArrayList SurnameTokens = new ArrayList();

            //    string injection = "";
            //    string opr = "";

            //    if (this.Name != null && this.Name.Trim().Length > 0)
            //    {
            //        NameTokens = Common.Tokenize(this.Name.Trim(), true);
            //        for (int i = 0; i <= NameTokens.Count - 1; i++)
            //        {
            //            if (i > 0)
            //                injection += " OR (";

            //            string s = NameTokens[i].ToString();
            //            opr = "LIKE";

            //            injection += "(NAME_SHADOW " + opr + " '%" + s + "%' ";
            //        }

            //        injection += ") ";
            //    }
            //    if (this.Surname != null && this.Surname.Trim().Length > 0)
            //    {
            //        SurnameTokens = Common.Tokenize(this.Surname, true);
            //        for (int i = 0; i <= SurnameTokens.Count - 1; i++)
            //        {

            //            if (i > 0)
            //                injection += " OR ";
            //            else
            //                injection += " AND (";

            //            string s = SurnameTokens[i].ToString();
            //            opr = "LIKE";

            //            injection += "NAME_SHADOW " + opr + " '%" + s + "%' ";
            //        }

            //        injection += ") ";
            //    }
            //    filterExpression = injection;

            //    //UserTitle Prof, Doç
            //    //if (this.Department != null)
            //    //{
            //    //    string filter = "(CityOfBirthPerson = '" + this.Department + "')";
            //    //    if (filterExpression == null)
            //    //        filterExpression = "(" + filter + ")";
            //    //    else
            //    //        filterExpression += " AND (" + filter + ")";
            //    //}

            //    //UserTitle Prof, Doç
            //    if (this.Mission != null)
            //    {
            //        string filter = "(CKYSUSERTYPE = '" + this.Mission.ObjectID + "')";
            //        if (filterExpression == "")
            //            filterExpression = "(" + filter + ")";
            //        else
            //            filterExpression += " AND (" + filter + ")";
            //    }

            //    if (this.Title != -1)
            //    {
            //        string filter = "(Title = " + this.Title + ")";
            //        if (filterExpression == "")
            //            filterExpression = "(" + filter + ")";
            //        else
            //            filterExpression += " AND (" + filter + ")";
            //    }



            //    if (filterExpression != "")
            //        filterExpression = "WHERE " + filterExpression + " AND STATUS=1";
            //    return filterExpression;
            //}


        }

         
        public class VisitorSearchModel
        {
            public DateTime firstDate;
            public DateTime secondDate;
            public VisitorSearchModel()
            {
            }
        }


        public class LocationSearchModel
        {
            public string Building
            {
                get;
                set;
            }

            public string Policlinic
            {
                get;
                set;
            }

            public LocationSearchModel()
            {
            }
        }

        public class AppointmentSearchModel
        {
            public string ObjectID
            {
                get;
                set;
            }

            public string ObjectDefName
            {
                get;
                set;
            }

            public string UnicRefNo
            {
                get;
                set;
            }

            public string PassportNo
            {
                get;
                set;
            }

            public string Surname
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public string Doctor
            {
                get;
                set;
            }

            public int AdmissionNo
            {
                get;
                set;
            }

            public string MotherName
            {
                get;
                set;
            }

            public string FatherName
            {
                get;
                set;
            }

            public string BirthCity
            {
                get;
                set;
            }

            public DateTime BirthDate
            {
                get;
                set;
            }

            public DateTime DateFirst
            {
                get;
                set;
            }

            public DateTime DateSecond
            {
                get;
                set;
            }

            public AppointmentSearchModel()
            {
            }

        }

        public class ExaminationSearchModel
        {
            public Guid ResourceID { get; set; }
        }

        public class ExaminationSearchingResultModel
        {
            public string AdmissionQueueNo
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

            /*      public string EpisodeActionName
                  {
                      get;
                      set;
                  }
                  */

            public string StateName
            {
                get;
                set;
            }

           public string ExpectedExaminationTime { get; set; }

        }
        public partial class HospitalInformationFormViewModel
        {
            public LocationSearchModel _LocationSearchModel
            {
                get;
                set;
            }

            public PatientVisitor _RecordPatientVisitor
            {
                get;
                set;
            }

            public AppointmentSearchModel _AppointmentSearchModel
            {
                get;
                set;
            }
            public PersonnelSearchModel _PersonnelSearchModel
            {
                get;
                set;
            }

            public ExaminationSearchModel _ExaminationSearchModel
            {
                get; set;
            }

            public List<ResSection> ClinicList { get; set; }

    }



}
