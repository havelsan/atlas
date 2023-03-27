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
using Newtonsoft.Json;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PhysiotherapyWorkListServiceController : Controller
    {
        [HttpGet]
        public PhysiotherapyWorkListFormViewModel PhysiotherapyWorkList()
        {
            var viewModel = new PhysiotherapyWorkListFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.PhysiotherapyActionList = new List<PhysiotherapyWorkListItemModel>();

                viewModel._physiotherapyWorkListSearchCriteria = new PhysiotherapyWorkListSearchCriteria();
                viewModel._physiotherapyWorkListSearchCriteria.WorkListStartDate = Common.RecTime();
                viewModel._physiotherapyWorkListSearchCriteria.WorkListEndDate = Common.RecTime();

                #region Tedavi Üniteleri Listesi

                /****** Tedavi Üniteleri Listesi ******/
                var units = ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnits(objectContext, "");
                viewModel.TreatmentDiagnosisUnitList = new List<ResTreatmentDiagnosisUnit>();
                foreach (var unit in units)
                {
                    viewModel.TreatmentDiagnosisUnitList.Add(unit);
                }

                ResUser user = (ResUser)Common.CurrentUser.UserObject;
                var usersUnits = user.UserResources.Where(c => c.Resource.ObjectDef.Name == "RESTREATMENTDIAGNOSISUNIT");

                if (usersUnits.Count() > 0)
                {
                    viewModel._physiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit = new List<ResTreatmentDiagnosisUnit>();
                    foreach (var unit in usersUnits)
                    {
                        viewModel._physiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit.Add((ResTreatmentDiagnosisUnit)unit.Resource);
                    }
                }

                #endregion

                #region İstek Yapan Birim Listesi

                /****** İstek Yapan Birim Listesi ******/

                var resources = ResSection.GetPoliclinicAndClinics(objectContext);
                viewModel.FromResourceList = new List<ResSection>();
                foreach (var resource in resources)
                {
                    viewModel.FromResourceList.Add(resource);
                }


                #endregion

                #region Hasta Durumu

                viewModel._physiotherapyWorkListSearchCriteria.Patienttype = -1;

                #endregion


                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        public List<PhysiotherapyWorkListItemModel> GetPhysiotherapyActionWorkList(PhysiotherapyWorkListSearchCriteria criteria)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                //string whereCriteria = " WHERE 1=1";
                string whereCriteria = "";
                string joinwhereCriteria = "";
                if (criteria != null)
                {

                    if (!String.IsNullOrEmpty(criteria.AdmissionNumber))//Kabul No
                    {
                        if (criteria.AdmissionNumber.Contains("-"))
                        {
                            whereCriteria += " AND THIS.SubEpisode.ProtocolNo='" + criteria.AdmissionNumber.Trim() + "'";
                        }
                        else
                        {
                            whereCriteria += " AND THIS.SubEpisode.ProtocolNo like '" + criteria.AdmissionNumber + "%'";

                        }
                    }

                    if (!String.IsNullOrEmpty(criteria.RefNo))//TC Kimlik No
                    {
                        whereCriteria += " AND THIS.Episode.Patient.UniqueRefNo='" + criteria.RefNo.Trim() + "'";
                    }


                    if (!String.IsNullOrEmpty(criteria.PatientObjectID))//Hasta Arama
                    {
                        whereCriteria += " AND THIS.Episode.Patient.OBJECTID ='" + criteria.PatientObjectID.Trim() + "'";
                    }


                    //Seans Durumu
                    if (criteria.PhysiotherapyState != null && criteria.PhysiotherapyState.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND THIS.PhysiotherapyRequest.CURRENTSTATEDEFID IN (");

                        for (int i = 0; i < criteria.PhysiotherapyState.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.PhysiotherapyState[i].StateDefID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteria += _tempString.ToString();
                    }

                    //İstek Yapan Birim 
                    if (criteria.FromResource != null && criteria.FromResource.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND THIS.PhysiotherapyRequest.FromResource IN (");

                        for (int i = 0; i < criteria.FromResource.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.FromResource[i].ObjectID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteria += _tempString.ToString();
                    }

                    if (criteria.Patienttype == 0)//Ayaktan
                    {
                        whereCriteria += " AND THIS.Episode.PatientStatus ='" + criteria.Patienttype + "'";
                    }
                    else if (criteria.Patienttype == 1) //Yatan
                        whereCriteria += " AND THIS.Episode.PatientStatus IN (1,2,3)";

                    //eğer "İstek Oluşturma" aşamasında işlem seçiliyse ya da tüm işlemler seçiliyse o işlem için ayrı NQL yazılacak --> planlama vb yapılmış ama orderDetail'i olmayan işlemler için
                    joinwhereCriteria = whereCriteria.Replace("THIS.PhysiotherapyRequest", "THIS");

                    if (criteria.WorkListStartDate != null)
                    {
                        joinwhereCriteria += " AND PhysiotherapyRequestDate >= TODATE('" + Convert.ToDateTime(criteria.WorkListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    if (criteria.WorkListEndDate != null)
                    {
                        joinwhereCriteria += " AND PhysiotherapyRequestDate <= TODATE('" + Convert.ToDateTime(criteria.WorkListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    //Tedavi Ünitesi
                    if (criteria.TreatmentDiagnosisUnit != null && criteria.TreatmentDiagnosisUnit.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND THIS.TreatmentDiagnosisUnit.OBJECTID IN (");

                        for (int i = 0; i < criteria.TreatmentDiagnosisUnit.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.TreatmentDiagnosisUnit[i].ObjectID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteria += _tempString.ToString();
                    }

                    if (criteria.WorkListStartDate != null)
                    {
                        whereCriteria += " AND THIS.PhysiotherapyOrderDetails.PlannedDate >= TODATE('" + Convert.ToDateTime(criteria.WorkListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    if (criteria.WorkListEndDate != null)
                    {
                        whereCriteria += " AND THIS.PhysiotherapyOrderDetails.PlannedDate <= TODATE('" + Convert.ToDateTime(criteria.WorkListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                }

                BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderForWorkList_Class> workList = PhysiotherapyOrder.GetPhysiotherapyOrderForWorkList(whereCriteria);
                BindingList<PhysiotherapyRequest.GetPhysiotherapyRequestForPhysiotherapyWorkList_Class> workList2 = null;
                if (!String.IsNullOrEmpty(joinwhereCriteria))
                {
                    workList2 = PhysiotherapyRequest.GetPhysiotherapyRequestForPhysiotherapyWorkList(joinwhereCriteria);
                }
                List<PhysiotherapyWorkListItemModel> _PhysiotherapyItemList = new List<PhysiotherapyWorkListItemModel>();

                foreach (var item in workList)
                {
                    List<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByRequestObject_Class> orderDetailList = PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByRequestObject(item.ObjectID.ToString()).ToList();
                    List<PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject_Class> reportList = PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject(item.ObjectID.ToString()).ToList();

                    DateTime startDate = (DateTime)orderDetailList[0].Startdate;
                    DateTime finishDate = (DateTime)orderDetailList[0].Finishdate;
                    string isReportRequired = "var";
                    if (reportList != null && reportList.Count > 0)
                    {
                        var cnt = Convert.ToInt16(reportList[0].Cnt);
                        if (cnt > 0)
                            isReportRequired = "yok";
                    }

                    string _patientStatusText = "";
                    if (item.PatientStatus != 0)
                    {
                        if (item.PatientStatus == PatientStatusEnum.Inpatient) _patientStatusText = "-Yatıyor";
                        if (item.PatientStatus == PatientStatusEnum.PreDischarge) _patientStatusText = "-Ön Taburcu";
                        if (item.PatientStatus == PatientStatusEnum.Discharge) _patientStatusText = "-Taburcu";

                    }

                    PhysiotherapyWorkListItemModel _PhysiotherapyItem = new PhysiotherapyWorkListItemModel
                    {
                        ObjectID = item.ObjectID.Value,
                        ObjectDefID = item.ObjectDefID.Value,
                        ObjectDefName = item.Defname,

                        AdmissionNumber = item.Admissionnumber,
                        PatientRefNo = item.UniqueRefNo != null ? item.UniqueRefNo.ToString() : item.YUPASSNO.ToString(),
                        PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                        PatientStatus = item.PatientStatus == 0 ? "Ayaktan" : "Yatan" + _patientStatusText,
                        StartDate = startDate,
                        FinishDate = finishDate,
                        PhysiotherapyState = item.Currentstate,
                        IsReportRequired = isReportRequired,
                        FromResource = item.Fromresource,
                        ProcedureDoctor = item.Proceduredoctor,
                        IsPatientDischarged = item.PatientStatus.Value
                    };
                    _PhysiotherapyItemList.Add(_PhysiotherapyItem);
                }

                if (workList2 != null)
                {
                    foreach (var item in workList2)
                    {
                        if (_PhysiotherapyItemList.Where(c => c.ObjectID == item.ObjectID).Count() == 0)
                        {
                            List<PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject_Class> reportList = PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject(item.ObjectID.ToString()).ToList();

                            string isReportRequired = "var";
                            if (reportList != null && reportList.Count > 0)
                            {
                                var cnt = Convert.ToInt16(reportList[0].Cnt);
                                if (cnt > 0)
                                    isReportRequired = "yok";
                            }

                            string _patientStatusText = "";
                            if (item.PatientStatus != 0)
                            {
                                if (item.PatientStatus == PatientStatusEnum.Inpatient) _patientStatusText = "-Yatıyor";
                                if (item.PatientStatus == PatientStatusEnum.PreDischarge) _patientStatusText = "-Ön Taburcu";
                                if (item.PatientStatus == PatientStatusEnum.Discharge) _patientStatusText = "-Taburcu";

                            }

                            PhysiotherapyWorkListItemModel _PhysiotherapyItem = new PhysiotherapyWorkListItemModel
                            {
                                ObjectID = item.ObjectID.Value,
                                ObjectDefID = item.ObjectDefID.Value,
                                ObjectDefName = item.Defname,

                                AdmissionNumber = item.Admissionnumber,
                                PatientRefNo = item.UniqueRefNo != null ? item.UniqueRefNo.ToString() : item.YUPASSNO.ToString(),
                                PatientNameSurname = item.Patientname + " " + item.Patientsurname,
                                PatientStatus = item.PatientStatus == 0 ? "Ayaktan" : "Yatan" + _patientStatusText,
                                StartDate = item.PhysiotherapyRequestDate.Value,
                                FinishDate = (DateTime?)null,
                                PhysiotherapyState = item.Currentstate,
                                IsReportRequired = isReportRequired,
                                FromResource = item.Fromresource,
                                ProcedureDoctor = item.Proceduredoctor,
                                IsPatientDischarged = item.PatientStatus.Value
                            };
                            _PhysiotherapyItemList.Add(_PhysiotherapyItem);
                        }
                    }
                }

                return _PhysiotherapyItemList;
            }
        }

        [HttpPost]
        public void CompleteSelectedPhysiotherapyRecordsByID(List<PhysiotherapyWorkListItemModel> model)
        {
            //using (var objectContext = new TTObjectContext(false))
            //{
            //    for (int i = 0; i < model.Count; i++)
            //    {
            //        PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(new Guid(model[i].ObjectID), model[i].ObjectDefName) as PhysiotherapyOrderDetail;
            //        if (orderDetail.PhysiotherapyState == PhysiotherapyStateEnum.New)
            //        {
            //            orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Complated;
            //        }
            //        if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
            //        {
            //            orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Completed;
            //        }

            //        ResUser currentResUser = objectContext.GetObject<ResUser>(model[i].CurrentUserObjectId);

            //        if (orderDetail.StarterResUser == null)
            //        {
            //            orderDetail.StarterResUser = currentResUser;
            //        }
            //        orderDetail.FinisherResUser = currentResUser;
            //    }

            //    objectContext.Save();
            //}
        }


        [HttpPost]
        public void NotComeSelectedPhysiotherapyRecordsByID(List<PhysiotherapyWorkListItemModel> model)
        {
            //using (var objectContext = new TTObjectContext(false))
            //{
            //    for (int i = 0; i < model.Count; i++)
            //    {
            //        PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(new Guid(model[i].ObjectID), model[i].ObjectDefName) as PhysiotherapyOrderDetail;
            //        if (orderDetail.PhysiotherapyState == PhysiotherapyStateEnum.New)
            //        {
            //            orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.NotCome;
            //        }

            //        ResUser currentResUser = objectContext.GetObject<ResUser>(model[i].CurrentUserObjectId);

            //        if (orderDetail.StarterResUser == null)
            //        {
            //            orderDetail.StarterResUser = currentResUser;
            //        }
            //        orderDetail.FinisherResUser = currentResUser;
            //    }

            //    objectContext.Save();
            //}
        }

        [HttpGet]
        public HastaTemasDurumuResultModel CheckPatientContactStatus(Guid PhysiotherapyRequestID)
        {
            var objectContext = new TTObjectContext(false);
            HastaTemasDurumuResultModel result = new HastaTemasDurumuResultModel();

            PhysiotherapyRequest request = objectContext.GetObject(PhysiotherapyRequestID, typeof(PhysiotherapyRequest)) as PhysiotherapyRequest;

            long patientTC = 0, doctorTC = 0;
            Guid? selectedPatientID = request.Episode.Patient.ObjectID; ;
            if (selectedPatientID.HasValue)
            {
                Patient patient = objectContext.GetObject<Patient>(selectedPatientID.Value, false);
                if (patient != null && patient.UniqueRefNo != null)
                    patientTC = Convert.ToInt64(patient.UniqueRefNo);
            }

            Guid? selectedDoctorID = request.ProcedureDoctor.ObjectID;
            if (selectedDoctorID.HasValue)
            {
                ResUser doctor = objectContext.GetObject<ResUser>(selectedDoctorID.Value, false);
                if (doctor != null && doctor.Person != null && doctor.Person.UniqueRefNo != null)
                    doctorTC = Convert.ToInt64(doctor.Person.UniqueRefNo);
            }

            if (patientTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25801", "Hasta TC Kimlik No Bulunamadı."));
            if (doctorTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25525", "Doktor TC Kimlik No Bulunamadı."));

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

            client.DefaultRequestHeaders.Add("KullaniciAdi", username);
            client.DefaultRequestHeaders.Add("Sifre", password);
            client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

            HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/OzellikliIzlem/GetHastaTemasDurumu?TcKimlikNo=" + patientTC + "&HekimKimlikNo=" + doctorTC).GetAwaiter().GetResult();

            if (message.IsSuccessStatusCode)
            {
                string responseResult = message.Content.ReadAsStringAsync().Result;
                HastaTemasDurumuResponse response = JsonConvert.DeserializeObject<HastaTemasDurumuResponse>(responseResult);
                if (response.durum == 1)//hata dönmediyse
                {
                    result.isResponseSuccess = true;
                    if (response.sonuc == null)
                        result.responseMessage = string.Empty;
                    else
                    {
                        result.responseMessage = response.sonuc.durum + " Temas Riski Başlama Zamanı : " + response.sonuc.temasRiskiBaslamaZamani.ToString() + " Temas Riski Bitiş Zamanı : " + response.sonuc.temasRiskiBitisZamani.ToString();
                    }
                }
                else
                {
                    result.isResponseSuccess = false;
                    result.responseMessage = "Hasta temas riski sorgulanırken hata oluştu.";
                }
            }
            return result;
        }

        [HttpGet]
        public HastaTemasDurumuResultModel CheckPatientContactStatusFromSideMenu(Guid doctorObjectID, string UniqueRefNo)
        {
            var objectContext = new TTObjectContext(false);
            HastaTemasDurumuResultModel result = new HastaTemasDurumuResultModel();
            long patientTC = Convert.ToInt64(UniqueRefNo), doctorTC = 0;
           

            Guid? selectedDoctorID = doctorObjectID;
            if (selectedDoctorID.HasValue)
            {
                ResUser doctor = objectContext.GetObject<ResUser>(selectedDoctorID.Value, false);
                if (doctor != null && doctor.Person != null && doctor.Person.UniqueRefNo != null)
                    doctorTC = Convert.ToInt64(doctor.Person.UniqueRefNo);
            }

            if (patientTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25801", "Hasta TC Kimlik No Bulunamadı."));
            if (doctorTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25525", "Doktor TC Kimlik No Bulunamadı."));

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

            client.DefaultRequestHeaders.Add("KullaniciAdi", username);
            client.DefaultRequestHeaders.Add("Sifre", password);
            client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

            HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/OzellikliIzlem/GetHastaTemasDurumu?TcKimlikNo=" + patientTC + "&HekimKimlikNo=" + doctorTC).GetAwaiter().GetResult();

            if (message.IsSuccessStatusCode)
            {
                string responseResult = message.Content.ReadAsStringAsync().Result;
                HastaTemasDurumuResponse response = JsonConvert.DeserializeObject<HastaTemasDurumuResponse>(responseResult);
                if (response.durum == 1)//hata dönmediyse
                {
                    result.isResponseSuccess = true;
                    if (response.sonuc == null)
                        result.responseMessage = string.Empty;
                    else
                    {
                        result.responseMessage = response.sonuc.durum + " Temas Riski Başlama Zamanı : " + response.sonuc.temasRiskiBaslamaZamani.ToString() + " Temas Riski Bitiş Zamanı : " + response.sonuc.temasRiskiBitisZamani.ToString();
                    }
                }
                else
                {
                    result.isResponseSuccess = false;
                    result.responseMessage = "Hasta temas riski sorgulanırken hata oluştu.";
                }
            }
            return result;
        }

    }
}

namespace Core.Models
{
    public partial class PhysiotherapyWorkListFormViewModel
    {
        public List<PhysiotherapyWorkListItemModel> PhysiotherapyActionList;
        public PhysiotherapyWorkListSearchCriteria _physiotherapyWorkListSearchCriteria { get; set; }

        public List<ResTreatmentDiagnosisUnit> TreatmentDiagnosisUnitList { get; set; }
        public List<ResSection> FromResourceList { get; set; }

    }

    public class PhysiotherapyWorkListItemModel
    {
        public Guid ObjectID { get; set; }
        public Guid ObjectDefID { get; set; }
        public string ObjectDefName { get; set; }


        public string PatientNameSurname { get; set; }//Hasta Adı Soyadı
        public string PatientRefNo { get; set; }//Hasta TC
        public string PatientStatus { get; set; }//Hasta Türü ->Yatan Ayaktan


        public DateTime StartDate { get; set; }//Başlangıç Tarihi
        public DateTime? FinishDate { get; set; }//Bitiş Tarihi

        public string AdmissionNumber { get; set; }//Kabul No
        public string PhysiotherapyState { get; set; }//Seans Durumu

        public PatientStatusEnum IsPatientDischarged { get; set; }

        public string IsReportRequired { get; set; }//Raporsuz işlem var mı?
        public string FromResource { get; set; }//İstek Yapan Birim
        public string ProcedureDoctor { get; set; }//İstek Yapan Doktor
    }

    public class PhysiotherapyWorkListSearchCriteria
    {
        public DateTime WorkListStartDate { get; set; }//Başlangıç Tarihi

        public DateTime WorkListEndDate { get; set; }//Bitiş Tarihi

        public String AdmissionNumber { get; set; }//Kabul Numarası

        public String RefNo { get; set; }//Kimlik Numarası

        public List<ResTreatmentDiagnosisUnit> TreatmentDiagnosisUnit { get; set; }//Tanı Tedavi Ünitesi

        public List<EpisodeActionWorkListStateItem> PhysiotherapyState { get; set; }//Seans Durumu: İstek oluşturma, planlama yapıldı, tamamlandı, tümü vb.

        public List<ResSection> FromResource { get; set; }//İstek Yapan Birim (poliklinik ve klinik birimler)

        public int Patienttype { get; set; }//Hastanın durumu: Ayaktan/Yatan

        public string PatientObjectID { get; set; }

    }

}