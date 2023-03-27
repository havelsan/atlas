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
    public class ChemoRadiotherapyWorkListServiceController : Controller
    {
        [HttpGet]
        public ChemoRadiotherapyWorkListFormViewModel ChemoRadiotherapyWorkList()
        {
            var viewModel = new ChemoRadiotherapyWorkListFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.ChemoRadiotherapyActionList = new List<ChemoRadiotherapyWorkListItemModel>();

                viewModel._ChemoRadiotherapyWorkListSearchCriteria = new ChemoRadiotherapyWorkListSearchCriteria();
                viewModel._ChemoRadiotherapyWorkListSearchCriteria.WorkListStartDate = Common.RecTime();
                viewModel._ChemoRadiotherapyWorkListSearchCriteria.WorkListEndDate = Common.RecTime();

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
                    viewModel._ChemoRadiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit = new List<ResTreatmentDiagnosisUnit>();
                    foreach (var unit in usersUnits)
                    {
                        viewModel._ChemoRadiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit.Add((ResTreatmentDiagnosisUnit)unit.Resource);
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

                viewModel._ChemoRadiotherapyWorkListSearchCriteria.Patienttype = -1;

                #endregion


                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        public List<ChemoRadiotherapyWorkListItemModel> GetChemoRadiotherapyActionWorkList(ChemoRadiotherapyWorkListSearchCriteria criteria)
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
                    if (criteria.ChemoRadioTherapyState != null && criteria.ChemoRadioTherapyState.Count > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        string comma = "";
                        _tempString.Append(" AND THIS.CURRENTSTATEDEFID IN (");

                        for (int i = 0; i < criteria.ChemoRadioTherapyState.Count; i++)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + criteria.ChemoRadioTherapyState[i].StateDefID + "'");
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
                        _tempString.Append(" AND THIS.FromResource IN (");

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
                    //joinwhereCriteria = whereCriteria.Replace("THIS.PhysiotherapyRequest", "THIS");

                    if (criteria.WorkListStartDate != null)
                    {
                        whereCriteria += " AND THIS.RequestDate >= TODATE('" + Convert.ToDateTime(criteria.WorkListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    if (criteria.WorkListEndDate != null)
                    {
                        whereCriteria += " AND THIS.RequestDate <= TODATE('" + Convert.ToDateTime(criteria.WorkListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    //Tedavi Ünitesi
                    /*if (criteria.TreatmentDiagnosisUnit != null && criteria.TreatmentDiagnosisUnit.Count > 0)
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
                    }*/

                    

                }

                BindingList<ChemotherapyRadiotherapy.GetChemoRadiotherapyForWL_Class> workList = ChemotherapyRadiotherapy.GetChemoRadiotherapyForWL(whereCriteria);
                
                List<ChemoRadiotherapyWorkListItemModel> _ChemoRadiotherapyList = new List<ChemoRadiotherapyWorkListItemModel>();

                foreach (var item in workList)
                {

                    
                    

                    string _patientStatusText = "";
                    if (item.PatientStatus != 0)
                    {
                        if (item.PatientStatus == SubEpisodeStatusEnum.Daily) _patientStatusText = "-Günübirlik";
                        if (item.PatientStatus == SubEpisodeStatusEnum.Inpatient) _patientStatusText = "-Yatan";
                        if (item.PatientStatus == SubEpisodeStatusEnum.Outpatient) _patientStatusText = "-Ayaktan";

                    }

                    ChemoRadiotherapyWorkListItemModel _ChemoRadioTherapyItem = new ChemoRadiotherapyWorkListItemModel
                    {
                        ObjectID = item.ObjectID.Value,
                        ObjectDefID = item.ObjectDefID.Value,
                        ObjectDefName = item.ObjectDefName,

                        AdmissionNumber = item.Kabulno,
                        PatientRefNo = item.UniqueRefNo != null ? item.UniqueRefNo.ToString() : "",
                        PatientNameSurname = item.Patientnamesurname.ToString(),
                        PatientStatus = item.PatientStatus == 0 ? "Ayaktan" : "Yatan" + _patientStatusText,
                        //StartDate = startDate,
                        //FinishDate = finishDate,
                        ChemoRadiotherapyState = item.Statename,
                        //IsReportRequired = isReportRequired,
                        FromResource = item.Fromresource,
                        ProcedureDoctor = item.Doctorname,
                        //IsPatientDischarged = item.PatientStatus.Value
                    };
                    _ChemoRadiotherapyList.Add(_ChemoRadioTherapyItem);
                }

                

                return _ChemoRadiotherapyList;
            }
        }

        
        

    }
}

namespace Core.Models
{
    public partial class ChemoRadiotherapyWorkListFormViewModel
    {
        public List<ChemoRadiotherapyWorkListItemModel> ChemoRadiotherapyActionList;
        public ChemoRadiotherapyWorkListSearchCriteria _ChemoRadiotherapyWorkListSearchCriteria { get; set; }

        public List<ResTreatmentDiagnosisUnit> TreatmentDiagnosisUnitList { get; set; }
        public List<ResSection> FromResourceList { get; set; }

    }

    public class ChemoRadiotherapyWorkListItemModel
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
        public string ChemoRadiotherapyState { get; set; }//Seans Durumu

        public PatientStatusEnum IsPatientDischarged { get; set; }

        public string IsReportRequired { get; set; }//Raporsuz işlem var mı?
        public string FromResource { get; set; }//İstek Yapan Birim
        public string ProcedureDoctor { get; set; }//İstek Yapan Doktor
    }

    public class ChemoRadiotherapyWorkListSearchCriteria
    {
        public DateTime WorkListStartDate { get; set; }//Başlangıç Tarihi

        public DateTime WorkListEndDate { get; set; }//Bitiş Tarihi

        public String AdmissionNumber { get; set; }//Kabul Numarası

        public String RefNo { get; set; }//Kimlik Numarası

        public List<ResTreatmentDiagnosisUnit> TreatmentDiagnosisUnit { get; set; }//Tanı Tedavi Ünitesi

        public List<EpisodeActionWorkListStateItem> ChemoRadioTherapyState { get; set; }//Seans Durumu: İstek oluşturma, planlama yapıldı, tamamlandı, tümü vb.

        public List<ResSection> FromResource { get; set; }//İstek Yapan Birim (poliklinik ve klinik birimler)

        public int Patienttype { get; set; }//Hastanın durumu: Ayaktan/Yatan

        public string PatientObjectID { get; set; }

    }

}