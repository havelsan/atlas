using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
//using static TTObjectClasses.Patient;
using System.Collections;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PatientAdmissionSearchServiceController : Controller
    {
        static int _DefaultPageSize = 10;
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PatientAdmissionSearchFormViewModel PatientAdmissionSearchForm([FromQuery] string searchText)
        {
            var result = new PatientAdmissionSearchFormViewModel();
            if (searchText != null && searchText != "undefined")
            {
                using (var context = new TTObjectContext(false))
                {
              
                    PatientInfoListsModel patientInfoLists = new PatientInfoListsModel();
                    if (!String.IsNullOrEmpty(searchText))
                    {                       
                        IList patientSearchList = Patient.Search(searchText)?.FoundList;
                        if (patientSearchList != null && patientSearchList.Count > 0)
                        {
                            patientInfoLists = this.SetPatientInfoListsModel(patientSearchList);
                        }
                        else if (searchText.Length == 11 && Common.IsNumeric(searchText))//Gizli hasta için kontrol et
                        {
                            patientSearchList = Patient.PrivacySearch(searchText);
                            if (patientSearchList != null && patientSearchList.Count > 0)
                            {
                                patientInfoLists = this.SetPatientInfoListsModel(patientSearchList);   
                            }
                        }                  
                    }

                    patientInfoLists.hasGizliHastaKabulRoleID = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
                    result.PatientInfoLists = patientInfoLists;
                }
            }

            return result;

        }
        private PatientInfoListsModel SetPatientInfoListsModel(IList patientSearchList)
        {
            PatientInfoListsModel patientInfoLists = new PatientInfoListsModel();
            List<Guid> patientObjectIDs = new List<Guid>();
            foreach (Patient patient in patientSearchList)
            {
                //    Guid patientId = patientObjectIDs[0];
                //  TTObjectClasses.Patient patient2 = context.GetObject<TTObjectClasses.Patient>(patientId);
                if (patient.MergedToPatient == null)
                {
                    patientObjectIDs.Add(patient.ObjectID);
                    // PatientSearchResult searchResult = new PatientSearchResult();
                    PatientInfoDet patientInfoDet = new PatientInfoDet();
                    patientInfoDet.ObjectID = patient.ObjectID;
                    patientInfoDet.NameSurname = patient.Name + " " + patient.Surname;
                    patientInfoDet.Info = " Baba:" + patient.FatherName + " D.Tarihi:" + (patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToShortDateString() : null) + " D.Yeri:" + (patient.CityOfBirth != null ? patient.CityOfBirth.ADI : null);
                    patientInfoDet.FullInfo = patientInfoDet.NameSurname + "  " + patientInfoDet.Info;
                    patientInfoDet.FatherName = patient.FatherName;
                    patientInfoDet.Dob = (patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToShortDateString() : null);
                    patientInfoDet.CityOfBirth = (patient.BirthPlace != null ? patient.BirthPlace : null);
                    patientInfoDet.Privacy = patient.Privacy;
                    patientInfoLists.PatientList.Add(patientInfoDet);
                }
            }
            return patientInfoLists;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PagedResult PatientAdmissionSearchFormPaged([FromQuery] bool requireCount, [FromQuery] int skip, [FromQuery] int take, [FromQuery] string searchText = "")
        {
            //todo veritabani sayfalama olmalidir bu gecicidir
            if (take > _DefaultPageSize)
                take = _DefaultPageSize;
            var result = this.PatientAdmissionSearchForm(searchText);
            PagedResult paged = new PagedResult();
            paged.Data = result.PatientInfoLists.PatientList.Skip(skip).Take(take).ToList<object>();
            if (requireCount)
                paged.RecordCount = result.PatientInfoLists.PatientList.Count();
            return paged;
        }

        //[HttpGet]
        //public int PatientAdmissionSearchResultCount([FromUri]string searchText)
        //{
        //    return this.PatientAdmissionSearchForm(searchText).PatientInfoLists.PatientList.Count();
        //}
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PatientAdmissionSearchFormViewModel GetPatientAdmissions([FromQuery] Guid patientObjectID)
        {
            //HASTA GEÇMİŞİ     
            //string filterExpression = null;
            List<Guid> patientObjectIDs = new List<Guid>();
            patientObjectIDs.Add(patientObjectID);
            TTObjectContext context = new TTObjectContext(false);
            //PatientSearchResultModel searchResult = new PatientSearchResultModel();
            var result = new PatientAdmissionSearchFormViewModel();
            //  result.PatientInfoLists.PatientList.Add(patientInfoDet);
            result.PatientSearchResult.PatientInfo = (Patient)context.GetObject(patientObjectID, "PATIENT");
            /*  filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, "PATIENT", patientObjectIDs);
            BindingList<PatientAdmission.GetPatientAdmissionBySearchPatient_Class> historyPatientAdmission = PatientAdmission.GetPatientAdmissionBySearchPatient("WHERE " + filterExpression);
            foreach (PatientAdmission.GetPatientAdmissionBySearchPatient_Class patientAdmissionSearch in historyPatientAdmission)
            {
                var patientAdmission = context.GetObject<PatientAdmission>(patientAdmissionSearch.ObjectID.Value);
                PatientAdmissionInfoDet paInfoDet = new PatientAdmissionInfoDet();
                paInfoDet.ObjectID = patientAdmission.ObjectID;
                paInfoDet.ActionDate = patientAdmission.ActionDate != null ? ((DateTime)patientAdmission.ActionDate).ToShortDateString() : null;
                paInfoDet.Info = patientAdmission.Speciality != null ? patientAdmission.Speciality.Name : null;

                result.PatientInfoLists.PatientAdmissionList.Add(paInfoDet);
               
            }*/
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PatientAdmission GetSelectionAdmission([FromQuery] Guid admissionObjectID)
        {
            TTObjectContext context = new TTObjectContext(false);
            PatientAdmission patientAdmission = context.GetObject<PatientAdmission>(admissionObjectID);
            // result.PatientSearchResult.PatientAdmissionInfo = patientAdmission;
            return patientAdmission;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PatientAdmissionSearchFormViewModel CreateEmptyPatientFORKPS([FromQuery] long uniqueRefNo)
        {
            //HASTA GEÇMİŞİ     
            //string filterExpression = null;
            TTObjectContext context = new TTObjectContext(false);
            //PatientSearchResultModel searchResult = new PatientSearchResultModel();
            var result = new PatientAdmissionSearchFormViewModel();
            //  result.PatientInfoLists.PatientList.Add(patientInfoDet);
            result.PatientSearchResult.PatientInfo = new Patient(context);
            result.PatientSearchResult.PatientInfo.UniqueRefNo = uniqueRefNo;
            /*  filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, "PATIENT", patientObjectIDs);
              BindingList<PatientAdmission.GetPatientAdmissionBySearchPatient_Class> historyPatientAdmission = PatientAdmission.GetPatientAdmissionBySearchPatient("WHERE " + filterExpression);
              foreach (PatientAdmission.GetPatientAdmissionBySearchPatient_Class patientAdmissionSearch in historyPatientAdmission)
              {
                  var patientAdmission = context.GetObject<PatientAdmission>(patientAdmissionSearch.ObjectID.Value);
                  PatientAdmissionInfoDet paInfoDet = new PatientAdmissionInfoDet();
                  paInfoDet.ObjectID = patientAdmission.ObjectID;
                  paInfoDet.ActionDate = patientAdmission.ActionDate != null ? ((DateTime)patientAdmission.ActionDate).ToShortDateString() : null;
                  paInfoDet.Info = patientAdmission.Speciality != null ? patientAdmission.Speciality.Name : null;

                  result.PatientInfoLists.PatientAdmissionList.Add(paInfoDet);

              }*/
            return result;
        }
    }
}