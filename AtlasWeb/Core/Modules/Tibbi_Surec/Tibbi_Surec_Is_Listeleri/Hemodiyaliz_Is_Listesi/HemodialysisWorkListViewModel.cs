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
using TTDefinitionManagement;
using Newtonsoft.Json;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class HemodialysisWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        [HttpGet]
        public HemodialysisWorkListViewModel LoadHemodialysisWorkListViewModel()
        {
            var viewModel = new HemodialysisWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<HemodialysisWorkListItem>();

                viewModel._SearchCriteria = new HemodialysisWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.WorkListEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                viewModel._SearchCriteria.Patienttype = -1;

                #region Tedavi Üniteleri Listesi

                /****** Tedavi Üniteleri Listesi ******/
                var units = ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnits(objectContext, "");
                viewModel.TreatmentDiagnosisUnitList = new List<ResTreatmentDiagnosisUnit>();
                foreach (var unit in units)
                {
                    viewModel.TreatmentDiagnosisUnitList.Add(unit);
                }

                //ResUser user = (ResUser)Common.CurrentUser.UserObject;
                //var usersUnits = user.UserResources.Where(c => c.Resource.ObjectDef.Name == "RESTREATMENTDIAGNOSISUNIT");

                //if (usersUnits.Count() > 0)
                //{
                //    viewModel._SearchCriteria.TreatmentDiagnosisUnit = new List<ResTreatmentDiagnosisUnit>();
                //    foreach (var unit in usersUnits)
                //    {
                //        viewModel._SearchCriteria.TreatmentDiagnosisUnit.Add((ResTreatmentDiagnosisUnit)unit.Resource);
                //    }
                //}

                #endregion

                #region Cihaz Listesi

                /****** Tedavi Üniteleri Listesi ******/
                var equipments = ResEquipment.GetResEquipments(objectContext, "");
                viewModel.TreatmentEquipmentList = new List<ResEquipment>();
                foreach (var equipment in equipments)
                {
                    viewModel.TreatmentEquipmentList.Add(equipment);
                }
                #endregion


                #region  state sorguları

                viewModel._SearchCriteria.Request = false;
                viewModel._SearchCriteria.Plan = false;
                viewModel._SearchCriteria.Procedure = true;
                viewModel._SearchCriteria.Cancelled = false;
                viewModel._SearchCriteria.Completed = false;

                #endregion

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        public HemodialysisWorkListViewModel GetHemodialysisWorkList(HemodialysisWorkListSearchCriteria criteria)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                int workListMaxItemCount = Common.WorklistMaxItemCount();
                int counter = 0;

                // GENEL 
                var CurrentUser = Common.CurrentResource;
                var viewModel = new HemodialysisWorkListViewModel();
                viewModel.WorkList = new List<HemodialysisWorkListItem>();
                viewModel.maxWorklistItemCount = 0;
                //

                string whereCriteriaForOrder = "";
                string whereCriteriaForPlanOrder = "";
                string whereCriteriaForRequest = "";
                if (criteria != null)
                {
                    //Başlangıç Tarihi
                    if (criteria.WorkListStartDate != null)
                    {
                        whereCriteriaForRequest += " AND RequestDate >= TODATE('" + Convert.ToDateTime(criteria.WorkListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        whereCriteriaForPlanOrder += " AND TreatmentStartDateTime >= TODATE('" + Convert.ToDateTime(criteria.WorkListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        whereCriteriaForOrder += " AND HemodialysisOrderDetails.SessionDate >= TODATE('" + Convert.ToDateTime(criteria.WorkListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    //Bitiş Tarihi
                    if (criteria.WorkListEndDate != null)
                    {
                        whereCriteriaForRequest += " AND RequestDate <= TODATE('" + Convert.ToDateTime(criteria.WorkListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        whereCriteriaForPlanOrder += " AND TreatmentStartDateTime <= TODATE('" + Convert.ToDateTime(criteria.WorkListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        whereCriteriaForOrder += " AND HemodialysisOrderDetails.SessionDate <= TODATE('" + Convert.ToDateTime(criteria.WorkListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    //Tedavi Ünitesi
                    if (criteria.TreatmentDiagnosisUnit != null && criteria.TreatmentDiagnosisUnit.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND TreatmentDiagnosisUnit.OBJECTID IN (");

                        for (int i = 0; i < criteria.TreatmentDiagnosisUnit.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.TreatmentDiagnosisUnit[i].ObjectID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteriaForOrder += _tempString.ToString();
                        whereCriteriaForPlanOrder += _tempString.ToString();
                    }

                    //Tedavi Ünitesi
                    if (criteria.TreatmentEquipment != null && criteria.TreatmentEquipment.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND TreatmentEquipment.OBJECTID IN (");

                        for (int i = 0; i < criteria.TreatmentEquipment.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.TreatmentEquipment[i].ObjectID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteriaForOrder += _tempString.ToString();
                        whereCriteriaForPlanOrder += _tempString.ToString();
                    }

                    //Hastanın durumu: Ayaktan/Yatan
                    if (criteria.Patienttype == 0)//Ayaktan
                    {
                        whereCriteriaForOrder += " AND THIS.Episode.PatientStatus ='" + criteria.Patienttype + "'";
                        whereCriteriaForPlanOrder += " AND THIS.Episode.PatientStatus ='" + criteria.Patienttype + "'";
                    }
                    else if (criteria.Patienttype == 1) //Yatan
                    {
                        whereCriteriaForOrder += " AND THIS.Episode.PatientStatus IN (1,2,3)";
                        whereCriteriaForPlanOrder += " AND THIS.Episode.PatientStatus IN (1,2,3)";
                    }

                    //Hasta Arama
                    if (!String.IsNullOrEmpty(criteria.PatientObjectID))
                    {
                        whereCriteriaForOrder += " AND THIS.Episode.Patient.OBJECTID ='" + criteria.PatientObjectID.Trim() + "'";
                        whereCriteriaForPlanOrder += " AND THIS.Episode.Patient.OBJECTID ='" + criteria.PatientObjectID.Trim() + "'";
                    }

                    System.Text.StringBuilder _tempStringStatesForOrder = new System.Text.StringBuilder();
                    if (criteria.Request || criteria.Procedure || criteria.Cancelled || criteria.Completed)
                    {
                        string comma = "";
                        _tempStringStatesForOrder.Append(" AND THIS.HemodialysisRequest.CURRENTSTATEDEFID IN (");
                        if (criteria.Request)
                        {
                            _tempStringStatesForOrder.Append(comma);
                            _tempStringStatesForOrder.Append("STATES.Request");
                            comma = ",";
                        }
                        if (criteria.Procedure)
                        {
                            _tempStringStatesForOrder.Append(comma);
                            _tempStringStatesForOrder.Append("STATES.Procedure");
                            comma = ",";

                        }
                        if (criteria.Cancelled)
                        {
                            _tempStringStatesForOrder.Append(comma);
                            _tempStringStatesForOrder.Append("STATES.Cancelled");
                            comma = ",";

                        }
                        if (criteria.Completed)
                        {
                            _tempStringStatesForOrder.Append(comma);
                            _tempStringStatesForOrder.Append("STATES.Completed");
                            comma = ",";

                        }
                        _tempStringStatesForOrder.Append(") ");

                        whereCriteriaForOrder += _tempStringStatesForOrder.ToString();
                    }

                    whereCriteriaForOrder += " AND THIS.HemodialysisRequest.CURRENTSTATEDEFID NOT IN( STATES.Plan)";

                    System.Text.StringBuilder _tempStringStatesForPlanOrder = new System.Text.StringBuilder();
                    if (criteria.Plan)
                    {
                        string comma = "";
                        _tempStringStatesForPlanOrder.Append(" AND THIS.HemodialysisRequest.CURRENTSTATEDEFID IN (");
                        _tempStringStatesForPlanOrder.Append(comma);
                        _tempStringStatesForPlanOrder.Append("STATES.Plan");
                        comma = ",";
                        _tempStringStatesForPlanOrder.Append(") ");

                        whereCriteriaForPlanOrder += _tempStringStatesForPlanOrder.ToString();
                    }

                }

                List<HemodialysisWorkListItem> HemodialysisItemList = new List<HemodialysisWorkListItem>();

                if (criteria != null && criteria.Request == true)//Hemodiyaliz istek durumda olan objeler sorgulanıyor.
                {
                    var workListRequest = HemodialysisRequest.GetHemodialysisRequestForWorkList(whereCriteriaForRequest);
                    foreach (var item in workListRequest)
                    {
                        List<HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest_Class> detailList = HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest(item.ObjectID.ToString()).ToList();

                        string _patientStatusText = "";
                        if (item.PatientStatus != 0)
                        {
                            if (item.PatientStatus == PatientStatusEnum.Inpatient) _patientStatusText = "-Yatıyor";
                            if (item.PatientStatus == PatientStatusEnum.PreDischarge) _patientStatusText = "-Ön Taburcu";
                            if (item.PatientStatus == PatientStatusEnum.Discharge) _patientStatusText = "-Taburcu";
                        }

                        HemodialysisWorkListItem _hemodialysisItem = new HemodialysisWorkListItem
                        {
                            ObjectID = item.ObjectID.Value,
                            ObjectDefID = item.ObjectDefID.Value,
                            ObjectDefName = item.ObjectDefName,

                            PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                            AdmissionNumber = item.Admissionnumber,
                            ArchiveNumber = item.Archivenumber.ToString(),
                            UniqueRefno = item.UniqueRefNo.ToString(),
                            PatientStatus = item.PatientStatus == 0 ? "Ayaktan" : "Yatan" + _patientStatusText,
                            ProcedureDoctor = item.Proceduredoctor,
                            FromResource = item.Fromresource,
                            AdmissionDate = item.Admissiondate.Value,
                            StartDate = item.HemodialysisRequestDate.Value,
                            FinishDate = (DateTime?)null,
                            HemodialysisState = item.Currentstate,
                        };
                        viewModel.WorkList.Add(_hemodialysisItem);
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

                if (criteria != null && criteria.Plan == true)//Hemodiyaliz planlama aşamasında henüz detail'i olmayan işlemler sorgulanıyor.
                {
                    var workListRequest = HemodialysisOrder.GetHemodialysisOrderNewPlanForWorkList(whereCriteriaForPlanOrder);
                    foreach (var item in workListRequest)
                    {
                        List<HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest_Class> detailList = HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest(item.ObjectID.ToString()).ToList();

                        string _patientStatusText = "";
                        if (item.PatientStatus != 0)
                        {
                            if (item.PatientStatus == PatientStatusEnum.Inpatient) _patientStatusText = "-Yatıyor";
                            if (item.PatientStatus == PatientStatusEnum.PreDischarge) _patientStatusText = "-Ön Taburcu";
                            if (item.PatientStatus == PatientStatusEnum.Discharge) _patientStatusText = "-Taburcu";
                        }

                        HemodialysisWorkListItem _hemodialysisItem = new HemodialysisWorkListItem
                        {
                            ObjectID = item.ObjectID.Value,
                            ObjectDefID = item.ObjectDefID.Value,
                            ObjectDefName = item.ObjectDefName,

                            PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                            AdmissionNumber = item.Admissionnumber,
                            ArchiveNumber = item.Archivenumber.ToString(),
                            UniqueRefno = item.UniqueRefNo.ToString(),
                            PatientStatus = item.PatientStatus == 0 ? "Ayaktan" : "Yatan" + _patientStatusText,
                            ProcedureDoctor = item.Proceduredoctor,
                            FromResource = item.Fromresource,
                            AdmissionDate = item.Admissiondate.Value,
                            StartDate = item.Admissiondate.Value,
                            FinishDate = (DateTime?)null,
                            HemodialysisState = item.Currentstate,
                        };
                        viewModel.WorkList.Add(_hemodialysisItem);
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

                if (criteria != null && (criteria.Request == true || criteria.Procedure == true || criteria.Cancelled == true || criteria.Completed == true))
                {
                    BindingList<HemodialysisOrder.GetHemodialysisOrderForWorkList_Class> workListOrder = HemodialysisOrder.GetHemodialysisOrderForWorkList(whereCriteriaForOrder);
                    foreach (var item in workListOrder)
                    {
                        List<HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest_Class> detailList = HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest(item.ObjectID.ToString()).ToList();

                        string _patientStatusText = "";
                        if (item.PatientStatus != 0)
                        {
                            if (item.PatientStatus == PatientStatusEnum.Inpatient) _patientStatusText = "-Yatıyor";
                            if (item.PatientStatus == PatientStatusEnum.PreDischarge) _patientStatusText = "-Ön Taburcu";
                            if (item.PatientStatus == PatientStatusEnum.Discharge) _patientStatusText = "-Taburcu";
                        }

                        HemodialysisWorkListItem _hemodialysisItem = new HemodialysisWorkListItem
                        {
                            ObjectID = item.ObjectID.Value,
                            ObjectDefID = item.ObjectDefID.Value,
                            ObjectDefName = item.ObjectDefName,

                            PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                            AdmissionNumber = item.Admissionnumber,
                            ArchiveNumber = item.Archivenumber.ToString(),
                            UniqueRefno = item.UniqueRefNo.ToString(),
                            PatientStatus = item.PatientStatus == 0 ? "Ayaktan" : "Yatan" + _patientStatusText,
                            ProcedureDoctor = item.Proceduredoctor,
                            FromResource = item.Fromresource,
                            AdmissionDate = item.Admissiondate.Value,
                            StartDate = detailList.Count() > 0 ? (DateTime)detailList[0].Startdate : item.Admissiondate.Value,
                            FinishDate = detailList.Count() > 0 ? (DateTime)detailList[0].Finishdate : (DateTime?)null,
                            HemodialysisState = item.Currentstate,
                        };

                        viewModel.WorkList.Add(_hemodialysisItem);
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

                return viewModel;
            }
        }

        [HttpGet]
        public UpdateEquipmentViewModel LoadUpdateEquipmentViewModel()
        {
            UpdateEquipmentViewModel model = new UpdateEquipmentViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                var units = ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnits(objectContext, " WHERE THIS.ResourceSpecialities(this.Speciality.SKRSKlinik.KODU in ('128','157','166','197022','197010')).EXISTS");
                model.TreatmentDiagnosisUnitList = new List<ResTreatmentDiagnosisUnit>();
                foreach (var unit in units)
                {
                    model.TreatmentDiagnosisUnitList.Add(unit);
                }

                var equipments = ResEquipment.GetResEquipments(objectContext, "");
                model.TreatmentEquipmentList = new List<ResEquipment>();
                model.TransferAllCheck = false;
                model.TransferAppointmentsCheck = false;
                model.Description = "";
                model.Count = 1;
                model.CountType = 0;
                //foreach (var equipment in equipments)
                //{
                //    model.TreatmentEquipmentList.Add(equipment);
                //}
                objectContext.FullPartialllyLoadedObjects();
            }
            return model;
        }

        [HttpGet]
        public ResEquipment[] GetEquipmentList(string ObservationUnitID)
        {
            List<ResEquipment> equipmentList = new List<ResEquipment>();
            using (var objectContext = new TTObjectContext(false))
            {

                var equipments = ResEquipment.GetResEquipments(objectContext, "  WHERE THIS.TreatmentDiagnosisUnit.OBJECTID = " + ObservationUnitID);

                foreach (var equipment in equipments)
                {
                    equipmentList.Add(equipment);
                }
                objectContext.FullPartialllyLoadedObjects();
            }
            return equipmentList.ToArray();
        }

        [HttpGet]
        public ResEquipment[] GetNotAppointedEquipmentList(string ObservationUnitID, bool FromTransFerAll, int Count, int CountType)
        {
            List<ResEquipment> equipmentList = new List<ResEquipment>();
            using (var objectContext = new TTObjectContext(false))
            {
                string injectionSql = "";
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now;
                if (FromTransFerAll)
                {
                    injectionSql = "  AND THIS.TreatmentDiagnosisUnit.OBJECTID = " + ObservationUnitID + "AND NOT this.Appointments(this.AppDate >= TODATE('" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "')" + " AND this.CURRENTSTATEDEFID NOT IN(STATES.Cancelled)).EXISTS";
                }
                else
                {
                    if (CountType == 0)//Gün
                        endDate = startDate.AddDays(Count);
                    else if (CountType == 1)//Ay
                        endDate = startDate.AddMonths(Count);
                    else if (CountType == 2)
                        endDate = startDate.AddYears(Count);

                    injectionSql = "  AND THIS.TreatmentDiagnosisUnit.OBJECTID = " + ObservationUnitID + "AND NOT this.Appointments(this.AppDate >= TODATE('" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND this.AppDate <= TODATE('" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + " )" + " AND this.CURRENTSTATEDEFID NOT IN(STATES.Cancelled)).EXISTS";

                }


                var equipments = ResEquipment.GetNotAppointedEquipments(objectContext, injectionSql);

                foreach (var equipment in equipments)
                {
                    equipmentList.Add(equipment);
                }
                objectContext.FullPartialllyLoadedObjects();
            }
            return equipmentList.ToArray();
        }


    }

}
namespace Core.Models
{
    public partial class HemodialysisWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<HemodialysisWorkListItem> WorkList;
        public HemodialysisWorkListSearchCriteria _SearchCriteria { get; set; }

        public List<ResTreatmentDiagnosisUnit> TreatmentDiagnosisUnitList { get; set; }//Tanı Tedavi Ünitesi Listesi
        public List<ResEquipment> TreatmentEquipmentList { get; set; }//Cihaz Listesi

        public HemodialysisWorkListViewModel()
        {
            this._SearchCriteria = new HemodialysisWorkListSearchCriteria();
            this.WorkList = new List<HemodialysisWorkListItem>();
        }
    }

    [Serializable]
    public class HemodialysisWorkListSearchCriteria : BaseEpisodeActionWorkListSearchCriteria
    {
        public DateTime WorkListStartDate { get; set; }//Başlangıç Tarihi

        public DateTime WorkListEndDate { get; set; }//Bitiş Tarihi

        public List<ResTreatmentDiagnosisUnit> TreatmentDiagnosisUnit { get; set; }//Tanı Tedavi Ünitesi
        public List<ResEquipment> TreatmentEquipment { get; set; }//Cihaz

        public int Patienttype { get; set; }//Hastanın durumu: Ayaktan/Yatan

        public string PatientObjectID { get; set; }

        public bool Request { get; set; }// Kabul Yapılmış 
        public bool Plan { get; set; }// Seans Planlanan 
        public bool Procedure { get; set; }// Seans Devam Eden 
        public bool Cancelled { get; set; }// Seans İptal 
        public bool Completed { get; set; }// Seans Sonlandırılmış 
    }


    public class HemodialysisWorkListItem : BaseEpisodeActionWorkListItem
    {
        public Guid ObjectID { get; set; }
        public Guid ObjectDefID { get; set; }
        public string ObjectDefName { get; set; }

        public string PatientNameSurname { get; set; }//Hasta Adı Soyadı
        public string AdmissionNumber { get; set; }//Kabul No
        public string ArchiveNumber { get; set; }//Arşiv No
        public string UniqueRefno { get; set; }//Hasta TC
        public string PatientStatus { get; set; }//Hasta Türü ->Yatan Ayaktan
        public string ProcedureDoctor { get; set; }//İstek Yapan Doktor
        public string FromResource { get; set; }//İstek Yapan Birim
        public DateTime AdmissionDate { get; set; }//Kabul Tarihi

        public DateTime StartDate { get; set; }//Başlangıç Tarihi
        public DateTime? FinishDate { get; set; }//Bitiş Tarihi

        public string HemodialysisState { get; set; }//Seans Durumu

    }

    public class UpdateEquipmentViewModel
    {
        public List<ResTreatmentDiagnosisUnit> TreatmentDiagnosisUnitList { get; set; }//Tanı Tedavi Ünitesi Listesi
        public List<ResEquipment> TreatmentEquipmentList { get; set; }//Cihaz Listesi
        public bool TransferAllCheck { get; set; }
        public bool TransferAppointmentsCheck { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public ResEquipment SelectedEquipment { get; set; }
        public int SelectedEquipmentStatus { get; set; }
        public int CountType { get; set; }
        public ResTreatmentDiagnosisUnit TreatmentUnit { get; set; }
        public List<ResEquipment> NotAppointedEquipmentList { get; set; }
        public ResEquipment TransferedEquipment { get; set; }
    }
}
