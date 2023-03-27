using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InpatientAppWorkListServiceController : Controller
    {
        [HttpGet]
        public InpatientAppWorkListFormViewModel InpatientAppWorkList()
        {
            var viewModel = new InpatientAppWorkListFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.InpatientAppWorkList = new List<InpatientAppWorkListItemModel>();

                viewModel._inpatientAppWorkListSearchCriteria = new InpatientAppWorkListSearchCriteria();
                viewModel._inpatientAppWorkListSearchCriteria.WorkListStartDate = Common.RecTime();
                viewModel._inpatientAppWorkListSearchCriteria.WorkListEndDate = Common.RecTime();

                #region Servis Listesi

                /****** Servis Listesi ******/
                var _clinics = ResClinic.GetAllActiveClinics(objectContext);
                viewModel.ClinicList = new List<ResClinic>();
                foreach (var clinic in _clinics)
                {
                    viewModel.ClinicList.Add(clinic);
                }

                //ResUser user = (ResUser)Common.CurrentUser.UserObject;
                //var usersUnits = user.UserResources.Where(c => c.Resource.ObjectDef.Name == "RESWARD");

                //if (usersUnits.Count() > 0)
                //{
                //    viewModel._inpatientAppWorkListSearchCriteria.PhysicalStateClinic = new List<ResWard>();
                //    foreach (var unit in usersUnits)
                //    {
                //        viewModel._inpatientAppWorkListSearchCriteria.PhysicalStateClinic.Add((ResWard)unit.Resource);
                //    }
                //}

                #endregion

                #region Doktor Listesi

                /****** Doktor Listesi ******/

                var doctors = ResUser.GetClinicDoctorList(objectContext, "");
                viewModel.DoctorList = new List<ResUser>();
                foreach (var doctor in doctors)
                {
                    viewModel.DoctorList.Add(doctor);
                }

                #endregion

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        public List<InpatientAppWorkListItemModel> GetInpatientAppWorkList(InpatientAppWorkListSearchCriteria criteria)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string whereCriteriaForAppDate = "";//tarih ile arama
                string whereCriteriaForQueue = "";//sırada bekleyen hastalar/yatışa uygun hastalar
                string whereCriteriaForDatePast = "";//Randevu tarihi geçmiş hastalar

                if (criteria != null)
                {
                    //Servis
                    if (criteria.ClinicName != null && criteria.ClinicName.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND MasterResource.OBJECTID IN (");

                        for (int i = 0; i < criteria.ClinicName.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.ClinicName[i].ObjectID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteriaForAppDate += _tempString.ToString();
                    }

                    //Doktor
                    if (criteria.Doctor != null && criteria.Doctor.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND ResponsibleDoctor.OBJECTID IN (");

                        for (int i = 0; i < criteria.Doctor.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.Doctor[i].ObjectID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteriaForAppDate += _tempString.ToString();
                    }

                    //Kabul No
                    if (!String.IsNullOrEmpty(criteria.AdmissionNumber))
                    {
                        if (criteria.AdmissionNumber.Contains("-"))
                        {
                            whereCriteriaForAppDate += " AND SubEpisode.ProtocolNo='" + criteria.AdmissionNumber.Trim() + "'";
                        }
                        else
                        {
                            whereCriteriaForAppDate += " AND SubEpisode.ProtocolNo like '" + criteria.AdmissionNumber + "%'";

                        }
                    }

                    if (criteria.IsInpatientSuitable)//Yatışa Uygun Hastalar
                    {
                        whereCriteriaForQueue += whereCriteriaForAppDate;
                        whereCriteriaForQueue += " And IsQueue = 1 ";
                    }
                    whereCriteriaForAppDate += " And IsQueue = 0 ";//tarih verilmiş ha

                    if (criteria.IsAppDatePast)//Randevu tarihi geçmiş hastalar
                    {
                        whereCriteriaForDatePast += whereCriteriaForAppDate;
                        whereCriteriaForDatePast += " AND AppointmentDate <= TODATE('" + Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }
                    if (criteria.WorkListStartDate != null)
                    {
                        whereCriteriaForAppDate += " AND AppointmentDate >= TODATE('" + Convert.ToDateTime(criteria.WorkListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    if (criteria.WorkListEndDate != null)
                    {
                        whereCriteriaForAppDate += " AND AppointmentDate <= TODATE('" + Convert.ToDateTime(criteria.WorkListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }
                }
                List<InpatientAppWorkListItemModel> _InpatientAppItemList = new List<InpatientAppWorkListItemModel>();
                if (criteria != null && criteria.IsAppDatePast)
                {
                    BindingList<InpatientAppointment.GetInpatientAppointmentForWorkList_Class> workListDatePast = InpatientAppointment.GetInpatientAppointmentForWorkList(whereCriteriaForDatePast);
                    foreach (var item in workListDatePast)
                    {
                        InpatientAppWorkListItemModel _InpatientAppItem = new InpatientAppWorkListItemModel
                        {
                            ObjectID = item.ObjectID.Value,
                            ObjectDefID = item.ObjectDefID.Value,
                            ObjectDefName = item.ObjectDefName,

                            QueueNumber = 0,

                            PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                            PatientRefNo = item.UniqueRefNo != null ? item.UniqueRefNo.ToString() : "",

                            AdmissionNumber = item.Admissionnumber,
                            ClinicName = item.Clinicname,
                            ProcedureDoctor = item.Proceduredoctor,
                            InpatientDay = item.InpatientDay != null ? item.InpatientDay.Value.ToString() : "",
                            AppointmentDate = item.AppointmentDate != null ? item.AppointmentDate.Value : (DateTime?)null,
                            AppointmentDoctor = item.Appointmentdoctor,
                            InpatientAppState = item.Statename,
                            IsQueue = item.IsQueue.Value
                        };
                        _InpatientAppItemList.Add(_InpatientAppItem);
                    }
                }

                int count = 1;

                BindingList<InpatientAppointment.GetInpatientAppointmentForWorkList_Class> workListForAppDate = InpatientAppointment.GetInpatientAppointmentForWorkList(whereCriteriaForAppDate);
                foreach (var item in workListForAppDate)
                {
                    InpatientAppWorkListItemModel _InpatientAppItem = new InpatientAppWorkListItemModel
                    {
                        ObjectID = item.ObjectID.Value,
                        ObjectDefID = item.ObjectDefID.Value,
                        ObjectDefName = item.ObjectDefName,

                        QueueNumber = count,

                        PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                        PatientRefNo = item.UniqueRefNo != null ? item.UniqueRefNo.ToString() : "",

                        AdmissionNumber = item.Admissionnumber,
                        ClinicName = item.Clinicname,
                        ProcedureDoctor = item.Proceduredoctor,
                        InpatientDay = item.InpatientDay != null ? item.InpatientDay.Value.ToString() : "",
                        AppointmentDate = item.AppointmentDate != null ? item.AppointmentDate.Value : (DateTime?)null,
                        AppointmentDoctor = item.Appointmentdoctor,
                        InpatientAppState = item.Statename,
                        IsQueue = item.IsQueue.Value
                    };
                    _InpatientAppItemList.Add(_InpatientAppItem);
                    count++;
                }

                if (criteria != null && criteria.IsInpatientSuitable)
                {
                    BindingList<InpatientAppointment.GetInpatientAppointmentForWorkList_Class> workListForQueue = InpatientAppointment.GetInpatientAppointmentForWorkList(whereCriteriaForQueue);
                    foreach (var item in workListForQueue)
                    {
                        InpatientAppWorkListItemModel _InpatientAppItem = new InpatientAppWorkListItemModel
                        {
                            ObjectID = item.ObjectID.Value,
                            ObjectDefID = item.ObjectDefID.Value,
                            ObjectDefName = item.ObjectDefName,

                            QueueNumber = count,

                            PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                            PatientRefNo = item.UniqueRefNo != null ? item.UniqueRefNo.ToString() : "",

                            AdmissionNumber = item.Admissionnumber,
                            ClinicName = item.Clinicname,
                            ProcedureDoctor = item.Proceduredoctor,
                            InpatientDay = item.InpatientDay != null ? item.InpatientDay.Value.ToString() : "",
                            AppointmentDate = item.AppointmentDate != null ? item.AppointmentDate.Value : (DateTime?)null,
                            AppointmentDoctor = item.Appointmentdoctor,
                            InpatientAppState = item.Statename,
                            IsQueue = item.IsQueue.Value
                        };
                        _InpatientAppItemList.Add(_InpatientAppItem);
                        count++;
                    }
                }

                return _InpatientAppItemList;
            }
        }

    }
}

namespace Core.Models
{
    public partial class InpatientAppWorkListFormViewModel
    {
        public List<InpatientAppWorkListItemModel> InpatientAppWorkList;
        public InpatientAppWorkListSearchCriteria _inpatientAppWorkListSearchCriteria { get; set; }

        public List<ResClinic> ClinicList { get; set; }
        public List<ResUser> DoctorList { get; set; }

    }

    public class InpatientAppWorkListItemModel
    {
        public Guid ObjectID { get; set; }
        public Guid ObjectDefID { get; set; }
        public string ObjectDefName { get; set; }

        public int QueueNumber { get; set; }

        public string PatientNameSurname { get; set; }//Hasta Adı Soyadı
        public string PatientRefNo { get; set; }//Hasta TC


        public string AdmissionNumber { get; set; }//Kabul No
        public string ClinicName { get; set; }//Birim - Servis
        public string ProcedureDoctor { get; set; }//Doktor
        public string InpatientDay { get; set; }//Tahmini Yatış Süresi
        public DateTime? AppointmentDate { get; set; }//Randevu Tarihi
        public string AppointmentDoctor { get; set; }//Randevu Doktoru
        public string InpatientAppState { get; set; }//Statüsü
        public bool IsQueue { get; set; }//true->Hasta sırada , false-> tarih ile randevu verilmiş
    }

    public class InpatientAppWorkListSearchCriteria
    {
        public DateTime WorkListStartDate { get; set; }//Başlangıç Tarihi

        public DateTime WorkListEndDate { get; set; }//Bitiş Tarihi

        public String AdmissionNumber { get; set; }//Kabul Numarası

        public String RefNo { get; set; }//Kimlik Numarası

        public List<ResClinic> ClinicName { get; set; }//Servis

        public List<ResUser> Doctor { get; set; }//Doktor

        public string PatientObjectID { get; set; }

        public bool IsAppDatePast { get; set; }//Randevu Tarihi Geçmiş Hastalar

        public bool IsInpatientSuitable { get; set; }//Yatışa Uygun Hastalar

    }

}