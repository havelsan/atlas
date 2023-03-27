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
using Core.Security;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PatientSearchServiceController : Controller
    {
        protected void ApplySecurity()
        {
            if (!TTUser.CurrentUser.HasRole(Common.SearchPatientRoleID))
                throw new Exception(SystemMessage.GetMessageV2(84, TTUtils.CultureService.GetText("M25778", "Hasta arama için yetkiniz yok.")));
        }

        static int _DefaultPageSize = 10;
        //  PatientSearchResultModel searchResult = new PatientSearchResultModel();
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PagedResult PatientSearchForm([FromQuery] string searchText)
        {
            ApplySecurity();
            var result = new PagedResult();
            if (searchText != null && searchText != "undefined")
            {
                using (var context = new TTObjectContext(false))
                {
                    // IBindingList historyPatientAdmission = null;
                    //IBindingList patientInfo = null;
                    BasePatientInfoListsModel patientInfoLists = new BasePatientInfoListsModel();
                    if (!String.IsNullOrEmpty(searchText))
                    {
                        IList patientSearchList = Patient.Search(searchText)?.FoundList;
                        if (patientSearchList != null && patientSearchList.Count > 0)
                        {
                            List<Guid> patientObjectIDs = new List<Guid>();
                            foreach (Patient patient in patientSearchList)
                            {
                                //    Guid patientId = patientObjectIDs[0];
                                //  TTObjectClasses.Patient patient2 = context.GetObject<TTObjectClasses.Patient>(patientId);
                                patientObjectIDs.Add(patient.ObjectID);
                                // PatientSearchResult searchResult = new PatientSearchResult();
                                PatientInfoDet patientInfoDet = new PatientInfoDet();
                                patientInfoDet.ObjectID = patient.ObjectID;
                                patientInfoDet.NameSurname = patient.Name + " " + patient.Surname;
                                patientInfoDet.Info = " Baba:" + patient.FatherName + " D.Tarihi:" + (patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToShortDateString() : null) + " D.Yeri:" + (patient.BirthPlace != null ? patient.BirthPlace : null);
                                patientInfoDet.FullInfo = patientInfoDet.NameSurname + "  " + patientInfoDet.Info;
                                patientInfoDet.FatherName = patient.FatherName;
                                patientInfoDet.Dob = (patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToShortDateString() : null);
                                patientInfoDet.CityOfBirth = (patient.BirthPlace != null ? patient.BirthPlace : null);
                                result.Data.Add(patientInfoDet);
                            }

                            if (patientObjectIDs.Count == 1)
                            {
                            }
                        }
                        else
                        {
                        }
                    /*
                        //todo bg : yavaşlığa sebep olmayacak sekilde düzenlenmeli
                        if (CheckUnpaidDebt())//Eğer hastanın borcu varsa,süreç engellenmeli - Acil kabuller hariç
                        {
                            //alert
                            //Sadece acil birimler yüklenmeli
                            return;
                        }*/
                    }
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PagedResult PatientSearchFormPaged([FromQuery] bool requireCount, [FromQuery] int skip, [FromQuery] int take, [FromQuery] string searchText)
        {
            ApplySecurity();
            if (take > _DefaultPageSize)
                take = _DefaultPageSize;
            PagedResult paged = new PagedResult();
            if (searchText != null && searchText != "undefined")
            {
                using (var context = new TTObjectContext(false))
                {
                    // IBindingList historyPatientAdmission = null;
                    //IBindingList patientInfo = null;
                    //BasePatientInfoListsModel patientInfoLists = new BasePatientInfoListsModel();
                    if (!String.IsNullOrEmpty(searchText))
                    {
                        IList patientSearchList = Patient.Search(searchText)?.FoundList;
                        if (patientSearchList != null && patientSearchList.Count > 0)
                        {
                            IList<Patient> patients = new List<Patient>(patientSearchList.Cast<Patient>());
                            patients = patients.Skip(skip).Take(take).ToList();

                            if (requireCount)
                                paged.RecordCount = patientSearchList.Count;
                            //List<Guid> patientObjectIDs = new List<Guid>();
                            foreach (Patient patient in patients)
                            {
                                //    Guid patientId = patientObjectIDs[0];
                                //  TTObjectClasses.Patient patient2 = context.GetObject<TTObjectClasses.Patient>(patientId);
                                //patientObjectIDs.Add(patient.ObjectID);
                                // PatientSearchResult searchResult = new PatientSearchResult();
                                PatientInfoDet patientInfoDet = new PatientInfoDet();
                                patientInfoDet.ObjectID = patient.ObjectID;
                                patientInfoDet.NameSurname = patient.Name + " " + patient.Surname;
                                patientInfoDet.Info = " Baba:" + patient.FatherName + " D.Tarihi:" + (patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToShortDateString() : null) + " D.Yeri:" + (patient.BirthPlace != null ? patient.BirthPlace : null);
                                patientInfoDet.FullInfo = patientInfoDet.NameSurname + "  " + patientInfoDet.Info;
                                patientInfoDet.FatherName = patient.FatherName;
                                patientInfoDet.Dob = (patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToShortDateString() : null);
                                patientInfoDet.CityOfBirth = (patient.BirthPlace != null ? patient.BirthPlace : null);
                                paged.Data.Add(patientInfoDet);
                            //patientInfoLists.PatientList.Add(patientInfoDet);
                            }
                        //if (patientObjectIDs.Count == 1)
                        //{
                        //}
                        }
                        else
                        {
                        }
                    /*
                        //todo bg : yavaşlığa sebep olmayacak sekilde düzenlenmeli
                        if (CheckUnpaidDebt())//Eğer hastanın borcu varsa,süreç engellenmeli - Acil kabuller hariç
                        {
                            //alert
                            //Sadece acil birimler yüklenmeli
                            return;
                        }*/
                    }
                //paged.Data = patientInfoLists;
                }
            }

            return paged;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public PatientSearchFormViewModel GetPatients([FromQuery] Guid patientObjectID)
        {
            ApplySecurity();
            List<Guid> patientObjectIDs = new List<Guid>();
            patientObjectIDs.Add(patientObjectID);
            TTObjectContext context = new TTObjectContext(false);
            var result = new PatientSearchFormViewModel();
            result.PatientSearchResult.PatientInfo = (Patient)context.GetObject(patientObjectID, "PATIENT");
            result.PatientSearchResult.PatientIDandFullName = result.PatientSearchResult.PatientInfo.PatientIDandFullName;
            result.PatientSearchResult.PatientRefNo = result.PatientSearchResult.PatientInfo.RefNo;
            if (result.PatientSearchResult.PatientInfo.PatientAddress != null)
                result.PatientSearchResult.PatientPhoneNumber = result.PatientSearchResult.PatientInfo.PatientAddress.MobilePhone;
            return result;
        }
    //[HttpPost]
    //public PatientSearchFormViewModel PatientSearchFormPaged(int skip, int take, [FromUri]string searchText)
    //{
    //    if (take > _DefaultPageSize)
    //        take = _DefaultPageSize;
    //    var result = this.PatientSearchForm(searchText);
    //    result.PatientInfoLists.PatientList = result.PatientInfoLists.PatientList.Skip(skip).Take(take).ToList();
    //    return result;
    //}
    //[HttpGet]
    //public int PatientSearchResultCount([FromUri]string searchText)
    //{
    //    return this.PatientSearchForm(searchText).PatientInfoLists.PatientList.Count();
    //}
    }
}