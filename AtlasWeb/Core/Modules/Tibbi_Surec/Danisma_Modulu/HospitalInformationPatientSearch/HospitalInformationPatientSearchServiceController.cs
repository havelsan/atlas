using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections;
using Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel;
using static TTObjectClasses.InPatientTreatmentClinicApplication;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
    public partial class HospitalInformationPatientSearchServiceController : Controller
    {
        [HttpPost]
        public List<OutPatientSearchingModel> OutPatientSearchWithDetailsForm(HospitalInformationPatientSearchFormViewModel patientSearchModel)
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    //TODO DD : Birth city, admission number
                    var filter = Patient.GetFilterExpression(patientSearchModel.UnicRefNo, patientSearchModel.Name, patientSearchModel.Surname, patientSearchModel.FatherName, patientSearchModel.MotherName, patientSearchModel.BirthDate, patientSearchModel.BirthCity, null);
                    var clinicFilter = string.Empty;

                    if (patientSearchModel.OutpatientResources != null && patientSearchModel.OutpatientResources.Count > 0)
                    {
                        clinicFilter = " AND THIS.Policlinic.OBJECTID IN (";
                        foreach (ResourceModel item in patientSearchModel.OutpatientResources)
                        {
                            clinicFilter += "'" + item.ID + "', ";
                        }
                        clinicFilter = clinicFilter.Remove(clinicFilter.LastIndexOf(", ")) + ")";
                    }
                    PatientInfoListsModel patientInfoLists = new PatientInfoListsModel();
                    List<PatientAdmission> patientSearchList = Common.OutPatientSearchWithFilterExpression(patientSearchModel.AdmissionDateFirst, patientSearchModel.AdmissionDateSecond, filter, clinicFilter);
                    List<OutPatientSearchingModel> resultList = new List<OutPatientSearchingModel>();
                    foreach (PatientAdmission patientAdmission in patientSearchList)
                    {
                        OutPatientSearchingModel outPatientSearchingModel = new OutPatientSearchingModel(patientAdmission);
                        resultList.Add(outPatientSearchingModel);
                    }

                    return resultList;
                }
                catch (Exception e)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25206", "Ayaktan Hasta Listesi Sorgulamada Hata Oluştu!"),e);
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public List<InPatientSearchingModel> InPatientSearchWithDetailsForm(HospitalInformationPatientSearchFormViewModel patientSearchModel)
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    //TODO DD : Birth city, admission number
                    var filter = Patient.GetFilterExpression(patientSearchModel.UnicRefNo, patientSearchModel.Name, patientSearchModel.Surname, patientSearchModel.FatherName, patientSearchModel.MotherName, patientSearchModel.BirthDate, patientSearchModel.BirthCity, null, patientSearchModel.Sex);
                    var clinicFilter = string.Empty;

                    if(patientSearchModel.InpatientResources != null && patientSearchModel.InpatientResources.Count > 0)
                    {
                        clinicFilter = " THIS.MasterResource.OBJECTID IN (";
                        foreach (ResourceModel item in patientSearchModel.InpatientResources)
                        {
                            clinicFilter += "'" + item.ID + "', ";
                        }
                        clinicFilter = clinicFilter.Remove(clinicFilter.LastIndexOf(", "))+ ")";
                    }
                    //if(filter.Equals("Where 1=0"))
                    //{
                    //    filter = "Where 1=1";
                    //}
                    //if (!string.IsNullOrEmpty(patientSearchModel.Name))
                    //    filter += " AND upper(THIS.NAME) LIKE upper('%" + patientSearchModel.Name + "%') ORDER BY NAME";
                    //if (!string.IsNullOrEmpty(patientSearchModel.Surname))
                    //    filter += " AND upper(THIS.SURNAME) LIKE upper('%" + patientSearchModel.Surname + "%') ORDER BY SURNAME";

                    PatientInfoListsModel patientInfoLists = new PatientInfoListsModel();
                    List<GetInPatientInfoByPatients_Class> patientSearchList = Common.InPatientSearchWithFilterExpression(patientSearchModel.AdmissionDateFirst, patientSearchModel.AdmissionDateSecond, filter, clinicFilter);
                    List<InPatientSearchingModel> resultList = new List<InPatientSearchingModel>();
                    foreach (GetInPatientInfoByPatients_Class inPatientInfo in patientSearchList) 
                    {
                        Patient patient = (Patient)context.GetObject((Guid)inPatientInfo.Patient, "PATIENT");
                        InPatientSearchingModel inPatientSearchingModel = new InPatientSearchingModel(inPatientInfo, patient);
                        resultList.Add(inPatientSearchingModel);
                    }

                    return resultList;
                }
                catch (Exception e)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25206", "Yatan Hasta Listesi Sorgulamada Hata Oluştu!"), e);
                }
            }
        }

        partial void PreScript_HospitalInformationForm(HospitalInformationPatientSearchFormViewModel viewModel);
        partial void PostScript_HospitalInformationForm(HospitalInformationPatientSearchFormViewModel viewModel, TTDefinitionManagement.TTObjectStateTransitionDef transDef);
        partial void AfterContextSaveScript_HospitalInformationForm(HospitalInformationPatientSearchFormViewModel viewModel);
        void ContextToViewModel(HospitalInformationPatientSearchFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}