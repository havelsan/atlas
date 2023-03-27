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
using Core.Security;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class SosyalHizmetlerWorkListServiceController : Controller
    {

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ComboModel[] GetDoctor()
        {
            ComboModel[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResUser.DoctorListNQL(objectContext, "");
                var query =
                    from i in ttList
                    orderby i.Name
                    select new ComboModel
                    {
                        value = ((Guid)i.ObjectID),
                        Text = i.Name,
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ComboModel[] GetClinics()
        {
            ComboModel[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResSection.GetPoliclinicAndClinics(objectContext);
                var query =
                    from i in ttList
                    orderby i.Name
                    select new ComboModel
                    {
                        value = ((Guid)i.ObjectID),
                        Text = i.Name,
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }


        public string createFilterExpression(SosyalHizmetlerWorkListFormSearchCriteria searchCriteria)
        {
            string filterExpression = "";

            if (!string.IsNullOrEmpty(searchCriteria.kabulNo))
            {
                filterExpression += "AND this.SubEpisode.ProtocolNo = '" + searchCriteria.kabulNo + "' ";
            }
            if (!string.IsNullOrEmpty(searchCriteria.patientObjectID))
            {
                filterExpression += "AND this.Episode.Patient ='" + searchCriteria.patientObjectID + "' ";
            }
            if (!string.IsNullOrEmpty(searchCriteria.uniqueRefno))
            {
                filterExpression += "AND this.Episode.Patient.UniqueRefNo='" + searchCriteria.uniqueRefno + "' ";
            }
            if(searchCriteria.ProcedureByUser != null)
            {
                filterExpression += "AND this.ProcedureByUser = '" + searchCriteria.ProcedureByUser.ObjectID + "' ";
            }

            if (searchCriteria.workListStartDate.HasValue == false)
            {
                if (searchCriteria.workListEndDate.HasValue == false)
                    filterExpression += " AND (this.WorkListDate BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59')) ";
                else
                    filterExpression += " AND (  this.WorkListDate BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchCriteria.workListEndDate.Value.Year, searchCriteria.workListEndDate.Value.Month, searchCriteria.workListEndDate.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') ) ";
            }
            else
            {
                if (searchCriteria.workListEndDate.HasValue == false)
                    filterExpression += " AND (  this.WorkListDate BETWEEN TODATE('" + (new DateTime(searchCriteria.workListStartDate.Value.Year, searchCriteria.workListStartDate.Value.Month, searchCriteria.workListStartDate.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59')) ";
                else
                    filterExpression += " AND (  this.WorkListDate BETWEEN TODATE('" + (new DateTime(searchCriteria.workListStartDate.Value.Year, searchCriteria.workListStartDate.Value.Month, searchCriteria.workListStartDate.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchCriteria.workListEndDate.Value.Year, searchCriteria.workListEndDate.Value.Month, searchCriteria.workListEndDate.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') ) ";
            }

            if(searchCriteria.SosyalHizmetlerWorkListStateItem!= null && searchCriteria.SosyalHizmetlerWorkListStateItem.Count > 0)
            {
                filterExpression += "AND this.Currentstatedefid in (";

                foreach(ComboModel item in searchCriteria.SosyalHizmetlerWorkListStateItem)
                {
                    filterExpression += "'" + item.value + "',";
                }

                filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                filterExpression += ") ";
            }

            if (searchCriteria.FromResourceList != null && searchCriteria.FromResourceList.Count > 0)
            {
                filterExpression += "AND this.FromResource in (";

                foreach (ComboModel item in searchCriteria.FromResourceList)
                {
                    filterExpression += "'" + item.value + "',";
                }

                filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                filterExpression += ") ";
            }

            if (searchCriteria.RequesterDoctorList != null && searchCriteria.RequesterDoctorList.Count > 0)
            {
                filterExpression += "AND this.RequestedBy in (";

                foreach (ComboModel item in searchCriteria.RequesterDoctorList)
                {
                    filterExpression += "'" + item.value + "',";
                }

                filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                filterExpression += ") ";
            }

            if (searchCriteria.SosyalHizmetlerWorkListStateItem != null && searchCriteria.SosyalHizmetlerWorkListStateItem.Count > 0)
            {
                filterExpression += "AND this.CURRENTSTATEDEFID in (";

                foreach (ComboModel item in searchCriteria.SosyalHizmetlerWorkListStateItem)
                {
                    filterExpression += "'" + item.value + "',";
                }

                filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                filterExpression += ") ";
            }

            if(searchCriteria.PatientType == 0)
            {
                filterExpression += "AND this.Episode.PatientStatus='0' ";
            }else if (searchCriteria.PatientType == 1)
            {
                filterExpression += "AND this.Episode.PatientStatus in (1,2,3) ";
            }

            return filterExpression;
        }


        [HttpPost]
        //[AtlasRequiredRoles(TTRoleNames.Ortez_Protez_Is_Listesi)]
        public List<SosyalHizmetlerWorkListFormItemModel> GetSocialServicesActionsWorkList(SosyalHizmetlerWorkListFormSearchCriteria searchCriteria)
        {
            string filterExpression = createFilterExpression(searchCriteria);
            List<SosyalHizmetlerWorkListFormItemModel> ReturnActions = new List<SosyalHizmetlerWorkListFormItemModel>();

            var ActionList = PatientInterviewForm.GetPatientInterviewFormsWL(filterExpression);

            foreach (PatientInterviewForm.GetPatientInterviewFormsWL_Class action in ActionList)
            {
                SosyalHizmetlerWorkListFormItemModel sosyalHizmetlerWorkListFormItemModel = new SosyalHizmetlerWorkListFormItemModel();
                sosyalHizmetlerWorkListFormItemModel.BedNo = action.Bedname != null ? action.Bedname : "";
                sosyalHizmetlerWorkListFormItemModel.FromResource = action.Fromresource != null ? action.Fromresource : "";
                sosyalHizmetlerWorkListFormItemModel.ObjectID = action.ObjectID.ToString();
                sosyalHizmetlerWorkListFormItemModel.PatientNameSurname = action.Patientname + " " + action.Patientsurname;
                sosyalHizmetlerWorkListFormItemModel.PatientType = action.PatientStatus == PatientStatusEnum.Outpatient ? "AYAKTAN" : "YATAN";
                sosyalHizmetlerWorkListFormItemModel.ProcedureByUser = action.Procedurebyuser != null ? action.Procedurebyuser : "";
                sosyalHizmetlerWorkListFormItemModel.ProtocolNo = action.ProtocolNo != null ? action.ProtocolNo : "";
                sosyalHizmetlerWorkListFormItemModel.RequestDate = ((DateTime)action.RequestDate);
                sosyalHizmetlerWorkListFormItemModel.RoomNo = action.Roomname != null ? action.Roomname : "";
                sosyalHizmetlerWorkListFormItemModel.State = action.Currentstatetext;
                sosyalHizmetlerWorkListFormItemModel.UniqueRefno = action.Patientuniquerefno != null ? action.Patientuniquerefno.ToString() : "";
                using(var objectContext = new TTObjectContext(true))
                {
                    SubEpisode se = objectContext.GetObject<SubEpisode>(((Guid)action.Subepisode));
                    if(se != null)
                    {

                        var admissionSEP = se.SubEpisodeProtocols.Where(t => t.PatientAdmission != null && t.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).OrderBy(t=>t.CreationDate).FirstOrDefault();

                        if(admissionSEP != null)
                        {
                            sosyalHizmetlerWorkListFormItemModel.Payer = admissionSEP.Payer != null ? admissionSEP.Payer.Name : "";
                            sosyalHizmetlerWorkListFormItemModel.WorkStatus = admissionSEP.PatientAdmission.MedulaSigortaliTuru != null ? admissionSEP.PatientAdmission.MedulaSigortaliTuru.sigortaliTuruAdi : "";
                            sosyalHizmetlerWorkListFormItemModel.AdmissionType = admissionSEP.PatientAdmission.ApplicationReason!=null? Common.GetDisplayTextOfDataTypeEnum(admissionSEP.PatientAdmission.ApplicationReason) : "";
                            sosyalHizmetlerWorkListFormItemModel.PatientStatus = admissionSEP.PatientAdmission.PatientClassGroup != null ? Common.GetDisplayTextOfDataTypeEnum(admissionSEP.PatientAdmission.PatientClassGroup) : "";
                            sosyalHizmetlerWorkListFormItemModel.ComingReason = admissionSEP.PatientAdmission.AdmissionType != null ? admissionSEP.PatientAdmission.AdmissionType.provizyonTipiAdi : "";

                        }
                    }

                }
                if(action.CurrentStateDefID == PatientInterviewForm.States.Completed)
                {
                    sosyalHizmetlerWorkListFormItemModel.CompleteDate = ((DateTime)action.ActionDate);
                }else
                {
                    sosyalHizmetlerWorkListFormItemModel.CompleteDate = null;
                }
                ReturnActions.Add(sosyalHizmetlerWorkListFormItemModel);
            }



            return ReturnActions;
        }




        protected virtual WorkListDefinition getWorkListDefinition()
        {
            //TODO BB, worklistdef i şimdilik böyle çektim. Değişecek
            TTObjectContext objectContext = new TTObjectContext(true);
            WorkListDefinition _workListDefinition = (WorkListDefinition)objectContext.GetObject(new Guid("e0444b60-fa7f-40bc-ba42-8f06556aee7c"), "WorkListDefinition");
            return _workListDefinition;
        }

    }
}

namespace Core.Models
{
    public partial class SosyalHizmetlerWorkListViewModel
    {
        public List<SosyalHizmetlerWorkListFormItemModel> SosyalHizmetlerActionList;
        public SosyalHizmetlerWorkListFormSearchCriteria _sosyalHizmetlerWorkListFormSearchCriteria
        {
            get;
            set;
        }

        public SosyalHizmetlerWorkListViewModel()
        {
            this._sosyalHizmetlerWorkListFormSearchCriteria = new SosyalHizmetlerWorkListFormSearchCriteria();
            this.SosyalHizmetlerActionList = new List<SosyalHizmetlerWorkListFormItemModel>();
        }
    }

    public class SosyalHizmetlerWorkListFormItemModel
    {
        public string ObjectID { get; set; }
        public string UniqueRefno { get; set; }
        public string PatientNameSurname { get; set; }
        public string FromResource { get; set; }
        public string RoomNo { get; set; }
        public string BedNo { get; set; }
        public string ProcedureByUser { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CompleteDate { get; set; } // Sosyal Hizmet Uzmanının Tamamlama Tarihi ?
        public string ProtocolNo { get; set; }  //Kabul No
        public string Payer { get; set; }  //Sosyal Güvence   
        public string WorkStatus { get; set; } //Çalışma Durumu
        public string AdmissionType { get; set; } // Başvuru Türü
        public string PatientStatus { get; set; } // Hasta Türü
        public string ComingReason { get; set; } //Geliş Sebebi
        public string State { get; set; }
        public string PatientType { get; set; } //Hasta Tipi ----- Ayaktan*Yatan

    }

    [Serializable]
    public class SosyalHizmetlerWorkListFormSearchCriteria
    {
        public DateTime? workListStartDate
        {
            get;
            set;
        }

        public DateTime? workListEndDate
        {
            get;
            set;
        }

        public int PatientType
        {
            get;
            set;
        }

        public List<ComboModel> FromResourceList
        {
            get;
            set;
        }

        public List<ComboModel> SosyalHizmetlerWorkListStateItem
        {
            get;
            set;
        }

        public string uniqueRefno
        {
            get;
            set;
        }

        public string patientObjectID
        {
            get;
            set;
        }

        public string kabulNo
        {
            get;
            set;
        }

        public List<ComboModel> RequesterDoctorList
        {
            get;
            set;
        }

        public ResUser ProcedureByUser
        {
            get;
            set;
        }


    }

    public class ComboModel
    {

        public string Text { get; set; }
        public Guid value { get; set; }

    }

}