using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;
using Core.Controllers;
using System.Text;

namespace Core.Modules.Tibbi_Surec.Hasta_Demografik_Bilgileri
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PatientDemographicsServiceController : Controller
    {
        private void loadPatientDemographicsViewModelByPatient(PatientDemographicsViewModel model, Patient Patient)
        {
            if (Patient == null)
                return;
            model.IsPrivacyPatient = Patient.Privacy == true ? true : false;
            model.name = isNullOrEmpty(Patient.Name);
            model.surname = isNullOrEmpty(Patient.Surname);
            model.fatherName = model.IsPrivacyPatient == true ? "****" : isNullOrEmpty(Patient.FatherName);
            model.age = "";
            if (Patient.BirthDate.ToString() != null)
            {
                Common.Age patientAge = Common.CalculateAge(Convert.ToDateTime(Patient.BirthDate));
                model.age = patientAge.Years.ToString() + " Yıl " + patientAge.Months.ToString() + " Ay " + patientAge.Days.ToString() + " Gün";
            }

            if (Patient.BirthDate != null)
                model.BirthDate = model.IsPrivacyPatient == true ? "****" : isNullOrEmpty(Patient.BirthDate.Value.ToShortDateString().ToString());

            model.refNo = model.IsPrivacyPatient == true ? "****" : isNullOrEmpty(Patient.RefNo);
            model.gender = "";
            if (Patient.Sex != null)
            {
                model.gender = Patient.Sex.ADI;
            }

            model.profilPhotoPath = "";
            //model.profilPhotoPath = isNullOrEmpty(Patient.Photo.ToString());
            //if (Patient.Photo == null || Patient.Photo.ToString() == "")
            //{
            //    model.profilPhotoPath = avatarProfilPhotoPath(Patient);
            //}
            //else
            //{
            //    model.profilPhotoPath = profilPhotoPath;
            //}

            if (Patient.Photo != null)
            {
                if (Patient.Photo is string)
                {
                    model.profilPhotoPath = Patient.Photo.ToString();
                }
                else
                    model.profilPhotoPath = Convert.ToBase64String((byte[])Patient.Photo);
            }


            model.patientGuidID = isNullOrEmpty(Patient.ObjectID.ToString());
            model.hasMedicalInformation = Patient.hasMedicalInformation();
            model.medicalInformationGuidID = model.hasMedicalInformation == true ? Patient.MedicalInformation.ObjectID.ToString() : "";
            model.IsPatientAllergic = Patient.IsPatientAllergic();//Alerji bilgisi

            model.isPregnant = false;
            if (Patient.ActivePregnancy != null || (Patient.MedicalInformation != null && Patient.MedicalInformation.Pregnancy == true))
            {
                model.isPregnant = true;
                if (Patient.ActivePregnancy != null)
                {
                    WomanSpecialityObjectServiceController wmController = new WomanSpecialityObjectServiceController();
                    var pregnancyWeek = wmController.GetPregnancyWeek(Patient.ActivePregnancy.LastMenstrualPeriod.Value);
                    var weekInfoList = PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL("WHERE StartDate <= '" + pregnancyWeek + "' AND FinishDate > '" + pregnancyWeek + "'");
                    if (weekInfoList.Count() > 0)
                    {
                        foreach (var weekInfo in weekInfoList)
                        {
                            model.pregnancyWeekInfo += weekInfo.StartDate + ". - " + weekInfo.FinishDate + ". Haftalar Arası " + weekInfo.PeriodName + "\r\n";
                        }
                    }
                }
            }

            if (Patient.MedicalInformation != null)
            {
                if (Patient.MedicalInformation.HighRiskPregnancy == true)
                {
                    bool control = ControlHighPregnancyRisk(Patient);
                    if (control == false)
                        model.isHighRiskPregnant = true;
                    else
                        model.isHighRiskPregnant = false;
                }
                else if (Patient.MedicalInformation.Pandemic == true)
                {
                    model.Pandemic = true;
                }
            }



            //var isPhotoExist = isIncludeValue(model.refNo);
            //if (isPhotoExist)
            //{
            //    model.profilPhotoPath = "../../Content/PatientAdmission/" + model.refNo + ".jpg";
            //}
            //else
            //{
            //    model.profilPhotoPath = avatarProfilPhotoPath(Patient);
            //}

            if (Patient.ImportantPatientInfo != null)
                model.importantPatientInfo = isNullOrEmpty(Patient.ImportantPatientInfo.ToString());

            if (Patient.BloodGroupType != null)
            {
                model.bloodGroup = Patient.BloodGroupType.ADI;
            }

            model.archiveNo = Patient.ID.ToString();
        }


        private void loadPatientDemographicsViewModelByPatientAdmission(PatientDemographicsViewModel model, PatientAdmission PatientAdmission, bool isOutPatient)
        {
            if (PatientAdmission == null)
            {
                return;
            }

            if (PatientAdmission.Episode == null)
                throw new Exception(TTUtils.CultureService.GetText("M27175", "VAKASI bulunmayan Kabul!!!"));
            if (isOutPatient) //Ayaktan Hasta ise 
            {
                if (PatientAdmission != null)
                {
                    model.admissionDate = isNullOrEmpty(PatientAdmission.ActionDate.Value.ToShortDateString().ToString());
                    if (PatientAdmission.ProcedureDoctor != null)
                    {
                        model.admissionDoctor = PatientAdmission.ProcedureDoctor.Name;
                    }
                }
            }

            if (PatientAdmission.AdmissionType != null)
            {
                model.admissionType = PatientAdmission.AdmissionType.provizyonTipiAdi;
            }

            if (PatientAdmission.MedulaSigortaliTuru != null)
            {
                model.MedulaSigortaTuru = PatientAdmission.MedulaSigortaliTuru.sigortaliTuruAdi;
            }
        }

        [HttpGet]
        public PatientDemographicsViewModel GetMyPatientDemographicInfoByPatient([FromQuery] Guid patientObjectId)
        {
            PatientDemographicsViewModel model = new PatientDemographicsViewModel();
            if (patientObjectId == null)
                return model;
            TTObjectContext objContext = new TTObjectContext(false);
            try
            {
                Patient Patient = (Patient)objContext.GetObject(patientObjectId, "PATIENT", false);
                loadPatientDemographicsViewModelByPatient(model, Patient);
            }
            catch (Exception e)
            {
                throw e;
            }

            return model;
        }

        [HttpGet]
        public PatientDemographicsViewModel GetMyPatientDemographicInfoByPatientAdmission([FromQuery] Guid patientAdmissionObjectId)
        {
            PatientDemographicsViewModel model = new PatientDemographicsViewModel();
            if (patientAdmissionObjectId == null)
                return model;
            TTObjectContext objContext = new TTObjectContext(false);
            try
            {
                PatientAdmission PatientAdmission = (PatientAdmission)objContext.GetObject(patientAdmissionObjectId, "PATIENTADMISSION");
                loadPatientDemographicsViewModelByPatient(model, PatientAdmission.Episode.Patient);
                loadPatientDemographicsViewModelByPatientAdmission(model, PatientAdmission, true);
            }
            catch (Exception e)
            {
                throw e;
            }

            return model;
        }

        [HttpGet]
        public PatientDetailsViewModel GetMyPatientDetailsInfo([FromQuery] Guid actionId, bool _ShowFromResource)
        {
            PatientDetailsViewModel model = new PatientDetailsViewModel();
            if (actionId == null)
                return model;
            TTObjectContext objContext = new TTObjectContext(false);
            try
            {
                EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(actionId, "EPISODEACTION", false);
                if (episodeAction != null)
                {
                    if (episodeAction.PatientAdmission != null || episodeAction.ActionType == ActionTypeEnum.Consultation)
                    {
                        PatientAdmission admission;
                        if (episodeAction.ActionType == ActionTypeEnum.Consultation)
                        {
                            admission = episodeAction.Episode.PatientAdmissions[0];
                        }
                        else
                        {
                            admission = episodeAction.PatientAdmission;
                        }

                        model.IsPrivacyPatient = admission.Episode.Patient.Privacy == true ? true : false;
                        model.Address = model.IsPrivacyPatient == true ? "****" : (admission.Episode.Patient.PatientAddress != null ? admission.Episode.Patient.PatientAddress.HomeAddress : "");
                        model.BirthDate = model.IsPrivacyPatient == true ? "****" : isNullOrEmpty(admission.Episode.Patient.BirthDate.Value.ToShortDateString().ToString());
                        model.BirthPlace = model.IsPrivacyPatient == true ? "****" : admission.Episode.Patient.BirthPlace;
                        model.FatherName = model.IsPrivacyPatient == true ? "****" : admission.Episode.Patient.FatherName;
                        model.MotherName = model.IsPrivacyPatient == true ? "****" : admission.Episode.Patient.MotherName;
                        model.Sex = admission.Episode.Patient.Sex.ADI;

                        if (model.IsPrivacyPatient == true)
                            model.MobilePhone = "*** *** ** **";
                        else if (admission.PA_Address.MobilePhone != null)
                            model.MobilePhone = admission.PA_Address.MobilePhone.ToString();

                        model.PatientName = admission.Episode.Patient.Name;
                        model.PatientSurname = admission.Episode.Patient.Surname;
                        model.PatientIdentifier = model.IsPrivacyPatient == true ? "****" : admission.Episode.Patient.UniqueRefNo.ToString();
                        model.Nationality = admission.Episode.Patient.Nationality.Adi;
                        model.RelativeFullName = admission.PA_Address.RelativeFullName;
                        model.RelativeMobilePhone = admission.PA_Address.RelativeMobilePhone;
                    }
                    else if (episodeAction.Episode.InpatientAdmissions.Count > 0)
                    {
                        model.Address = model.IsPrivacyPatient == true ? "****" :( episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.PatientAddress != null ? episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.PatientAddress.HomeAddress : "");
                        model.BirthDate = model.IsPrivacyPatient == true ? "****" : isNullOrEmpty(episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.BirthDate.Value.ToShortDateString().ToString());
                        model.BirthPlace = model.IsPrivacyPatient == true ? "****" : episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.BirthPlace;
                        model.FatherName = model.IsPrivacyPatient == true ? "****" : episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.FatherName;
                        model.MotherName = model.IsPrivacyPatient == true ? "****" : episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.MotherName;
                        model.Sex = episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.Sex.ADI;

                        if (model.IsPrivacyPatient == true)
                            model.MobilePhone = "*** *** ** **";
                        else if (episodeAction.Episode.PatientAdmissions[0].PA_Address.MobilePhone != null)
                            model.MobilePhone =  episodeAction.Episode.PatientAdmissions[0].PA_Address.MobilePhone.ToString();

                        model.PatientName = episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.Name;
                        model.PatientSurname = episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.Surname;
                        model.PatientIdentifier = model.IsPrivacyPatient == true ? "****" : episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.UniqueRefNo.ToString();
                        model.Nationality = episodeAction.Episode.InpatientAdmissions[0].Episode.Patient.Nationality.Adi;
                        model.RelativeFullName = episodeAction.Episode.PatientAdmissions[0].PA_Address.RelativeFullName;
                        model.RelativeMobilePhone = episodeAction.Episode.PatientAdmissions[0].PA_Address.RelativeMobilePhone;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        [HttpGet]
        public PatientDemographicsViewModel GetMyPatientDemographicInfo([FromQuery] Guid actionId, bool _ShowFromResource)
        {
            PatientDemographicsViewModel model = new PatientDemographicsViewModel();
            if (actionId == null)
                return model;
            TTObjectContext objContext = new TTObjectContext(false);
            try
            {
                EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(actionId, "EPISODEACTION");
                if (episodeAction != null && episodeAction.Episode != null && episodeAction.Episode.Patient != null)
                    loadPatientDemographicsViewModelByPatient(model, episodeAction.Episode.Patient); // Hastaya Ait Bilgileri Load Eder.
                if (episodeAction != null && episodeAction.Episode != null && episodeAction.Episode.Payer != null)
                    model.payerName = isNullOrEmpty(episodeAction.Episode.Payer.Name);

                model.SubEpisodeProtocolNo = episodeAction.SubEpisode.ProtocolNo;
                EpisodeAction starterEpisodeAction = null;
                if (episodeAction.SubEpisode.StarterEpisodeAction != null)
                {
                    starterEpisodeAction = episodeAction.SubEpisode.StarterEpisodeAction;
                }
                else if (episodeAction.SubEpisode.StarterSubActionProcedure != null)
                {
                    starterEpisodeAction = episodeAction.SubEpisode.StarterSubActionProcedure.EpisodeAction;
                }

                //SubEpisode'u başlatanm işlemin Birimi 
                //sağlık kurulu muayenesi ise muayene masterresource unu almalı
                if (_ShowFromResource == true)
                {
                    model.policlinicName = this.getResourceName(starterEpisodeAction.FromResource);
                }
                else
                {
                    if (episodeAction.SubEpisode.PatientAdmission != null && episodeAction.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                    {
                        model.policlinicName = this.getResourceName(episodeAction.MasterResource);
                    }
                    else
                    {
                        if (episodeAction.SubEpisode.ResSection != null)
                            model.policlinicName = this.getResourceName(episodeAction.SubEpisode.ResSection);
                        else
                        {
                            model.policlinicName = this.getResourceName(starterEpisodeAction.MasterResource);
                        }
                    }
                }

                model.admissionDate = "";
                model.admissionType = "";
                model.admissionDoctor = "";
                bool isInPatient = starterEpisodeAction is InPatientTreatmentClinicApplication;
                if (isInPatient) // yatan hasta ise
                {
                    var TreatmentClinicApp = (InPatientTreatmentClinicApplication)starterEpisodeAction;
                    if (episodeAction is InPatientPhysicianApplication || episodeAction is NursingApplication)
                    {
                        model.ShowType = 2; //2-> Yatan Hasta Yatış Modülleri
                        if (TreatmentClinicApp.ProtocolNo != null)
                            model.ClinicProtocolNo = TreatmentClinicApp.ProtocolNo.ToString();
                        if (TreatmentClinicApp.BaseInpatientAdmission.RoomGroup != null)
                            model.RoomGroup = TreatmentClinicApp.BaseInpatientAdmission.RoomGroup.Name;
                        if (TreatmentClinicApp.BaseInpatientAdmission.Room != null)
                            model.Room = TreatmentClinicApp.BaseInpatientAdmission.Room.Name;
                        if (TreatmentClinicApp.BaseInpatientAdmission.Bed != null)
                            model.Bed = TreatmentClinicApp.BaseInpatientAdmission.Bed.Name;
                    }
                    else
                    {
                        model.ShowType = 3; //3-> Yatan Hasta Diğer Modüller   
                    }

                    if (TreatmentClinicApp.ClinicInpatientDate != null)
                    {
                        model.inpatientClinicDate = TreatmentClinicApp.ClinicInpatientDate.Value.ToShortDateString().ToString();
                    }

                    if (TreatmentClinicApp.ClinicDischargeDate != null)
                    {
                        model.InpatientClinicDischargeDate = TreatmentClinicApp.ClinicDischargeDate.Value.ToShortDateString().ToString();
                    }

                    if (episodeAction.SubEpisode.InpatientStatus != null)
                    {
                        model.InpatientType = Common.GetDisplayTextOfEnumValue("InpatientStatusEnum", (int)episodeAction.SubEpisode.InpatientStatus);
                        if (episodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Discharged)
                        {
                            //hasta taburcu olmuş ise
                            model.IsInpatientTypeDischarge = true;
                            if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                            {
                                model.InpatientDay = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                            }
                        }
                        else if (episodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Predischarged)
                        {
                            //hasta ön taburcu ise
                            if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                            {
                                model.InpatientDay = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                            }
                        }
                        else if (episodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Inpatient)
                        {
                            //hasta yatan hasta ise
                            if (TreatmentClinicApp.ClinicInpatientDate != null && TreatmentClinicApp.IsDailyOperation != true)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                            {
                                model.InpatientDay = ((Common.RecTime() - TreatmentClinicApp.ClinicInpatientDate.Value).Days + 1).ToString();
                            }

                            else if (TreatmentClinicApp.IsDailyOperation == true)
                            {
                                if (TreatmentClinicApp.ClinicDischargeDate != null)
                                    model.InpatientDay = ((TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days + 1).ToString();
                                else
                                    model.InpatientDay = "0";
                            }
                        }
                    }
                    else
                    {// SubEpisode'un InpatientSatus  boşsa 
                        if (TreatmentClinicApp.TreatmentDischarge != null && TreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.Discharged)
                        {
                            if (TreatmentClinicApp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Transferred)
                            {
                                model.InpatientType = TTUtils.CultureService.GetText("M18069", "Kurum İçi Sevk");

                                if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                                {
                                    model.InpatientDay = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                                }
                            }
                            else
                            {
                                model.InpatientType = TTUtils.CultureService.GetText("M22549", "Taburcu");
                                model.IsInpatientTypeDischarge = true;//hasta taburcu olmuş ise
                                if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                                {
                                    model.InpatientDay = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                                }
                            }
                        }
                        else if (TreatmentClinicApp.TreatmentDischarge != null && TreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.PreDischarge)
                        {
                            model.InpatientType = TTUtils.CultureService.GetText("M26675", "ÖnTaburcu");
                            if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                            {
                                model.InpatientDay = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days.ToString();
                            }
                        }
                        else
                        {
                            model.InpatientType = TTUtils.CultureService.GetText("M24377", "Yatan");
                            if (TreatmentClinicApp.ClinicInpatientDate != null)//yatış tarihi var ise yatış gün sayısı hesaplama
                            {
                                model.InpatientDay = ((Common.RecTime() - TreatmentClinicApp.ClinicInpatientDate.Value).Days + 1).ToString();
                            }
                        }
                    }

                    if (TreatmentClinicApp.ProcedureDoctor != null)
                        model.admissionDoctor = TreatmentClinicApp.ProcedureDoctor.Name;
                    if (TreatmentClinicApp.ResponsibleNurse != null)
                        model.responsibleNurse = TreatmentClinicApp.ResponsibleNurse.Name;
                }
                else
                {
                    if (starterEpisodeAction is PatientExamination)
                    {
                        var patientExamination = (PatientExamination)starterEpisodeAction;
                        model.PoliclinicProtocolNo = patientExamination.ProtocolNo.ToString();

                        model.ExaminationProcessAndEndDate = "";

                        if (patientExamination.ProcessDate.HasValue)
                            model.ExaminationProcessAndEndDate = patientExamination.ProcessDate.Value.ToString("dd.MM.yyyy HH:mm");

                        if (patientExamination.ProcessEndDate.HasValue)
                            model.ExaminationProcessAndEndDate += "    /  " + patientExamination.ProcessEndDate.Value.ToString("dd.MM.yyyy HH:mm");

                        if (patientExamination.RequestDate.HasValue)
                        {
                            model.formattedRequestDate += "" + patientExamination.RequestDate.Value.ToString("dd.MM.yyyy HH:mm");
                        }
                    }

                    model.ShowType = 1; //1-> Ayaktan Hasta 
                }

                loadPatientDemographicsViewModelByPatientAdmission(model, episodeAction.SubEpisode.PatientAdmission, (!isInPatient));
                //sağlık kurulu muayenesi ise muayene doktorunu unu almalı()
                if (episodeAction is PatientExamination && episodeAction.SubEpisode.PatientAdmission != null && episodeAction.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                    model.admissionDoctor = episodeAction.ProcedureDoctor.ToString();
                if (episodeAction.SubEpisode.LastActiveSubEpisodeProtocolByCloneType != null)
                    model.provisionNo = isNullOrEmpty(episodeAction.SubEpisode.LastActiveSubEpisodeProtocolByCloneType.MedulaTakipNo); //isNullOrEmpty(episodeAction.SubEpisode.PatientAdmission.ProvisionNo);
                model.archiveNo = episodeAction.SubEpisode.Episode.Patient.ID.ToString();
                model.hospitalProtocolNo = isNullOrEmpty(episodeAction.Episode.HospitalProtocolNo.ToString());

                if (episodeAction.SubEpisode.PatientStatus.HasValue)
                    model.PatientType = Common.GetDisplayTextOfEnumValue("SubEpisodeStatusEnum", Convert.ToInt32(episodeAction.SubEpisode.PatientStatus));

                if (episodeAction.SubEpisode.PatientAdmission != null)
                {
                    if (episodeAction.SubEpisode.PatientAdmission.ApplicationReason != null)
                        model.ApplicationReason = Common.GetDisplayTextOfEnumValue("ApplicationReasonEnum", Convert.ToInt32(episodeAction.SubEpisode.PatientAdmission.ApplicationReason));
                    if (episodeAction.SubEpisode.PatientAdmission.PatientClassGroup != null)
                        model.PatientClassGroup = Common.GetDisplayTextOfEnumValue("PatientClassTypeEnum", Convert.ToInt32(episodeAction.SubEpisode.PatientAdmission.PatientClassGroup));
                    if (episodeAction.SubEpisode.PatientAdmission.MedulaSigortaliTuru != null)
                        model.MedulaSigortaTuru = episodeAction.SubEpisode.PatientAdmission.MedulaSigortaliTuru.sigortaliTuruAdi;

                }
                model.HasAirborneContactIsolation = episodeAction.SubEpisode.HasAirborneContactIsolation;
                model.HasContactIsolation = episodeAction.SubEpisode.HasContactIsolation;
                model.HasDropletIsolation = episodeAction.SubEpisode.HasDropletIsolation;
                model.HasFallingRisk = episodeAction.SubEpisode.HasFallingRisk;
                model.HasTightContactIsolation = episodeAction.SubEpisode.HasTightContactIsolation;

            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        private string isNullOrEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            else
            {
                return input;
            }
        }

        private string getResourceName(Resource resource)
        {
            //if (resource.Qref != null)
            //    return resource.Qref.ToString();
            return resource.Name.ToString();
        }
        private string avatarProfilPhotoPath(Patient patient)
        {
            if (patient != null && patient.Sex != null)
            {
                if (patient.Sex.KODU == "1")
                {
                    return "../../Content/PatientAdmission/avatar_men.png";
                }
                else
                {
                    return "../../Content/PatientAdmission/avatar_women.png";
                }
            }
            else
            {
                return "../../Content/PatientAdmission/avatar_unknown.png";
            }
        }

        private bool isIncludeValue(string refNo)
        {
            string[] IncludedPhotoList = { "10000000000" };
            if (IncludedPhotoList.Contains(refNo) && refNo != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        public DynamicComponentInfoDVO GetDynamicComponentPatientInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                EpisodeAction obj = (EpisodeAction)objectContext.GetObject(new Guid(ObjectId), typeof(EpisodeAction));
                //var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = "Tibbi_Surec/Hasta_Demografik_Bilgileri"; //string.Join("/", subFolders.Reverse());
                var moduleName = "PatientDemographicsModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = "PatientDemographicsForm"; // obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                dynamicComponentInfo.episodeObjectID = obj.Episode.ObjectID;
                dynamicComponentInfo.patientObjectID = obj.Episode.Patient.ObjectID;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }

        [HttpGet]
        public AllergyTypesDetails loadPatientAllergyDetail(string patientObjectId)
        {

            AllergyTypesDetails model = new AllergyTypesDetails();
            TTObjectContext objContext = new TTObjectContext(false);
            try
            {

                Patient patient = (Patient)objContext.GetObject(new Guid(patientObjectId), "PATIENT", false);
                if (patient.MedicalInformation.MedicalInfoAllergies != null)
                {

                    if (patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies != null && patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies.Count != 0)
                    {
                        foreach (MedicalInfoFoodAllergies allergy in patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies)
                        {
                            model.foodAllergies += allergy.DietMaterial.MaterialName + ", ";
                        }

                        model.foodAllergies = model.foodAllergies.Remove(model.foodAllergies.LastIndexOf(","));

                    }


                    if (patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies != null && patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Count != 0)
                    {
                        foreach (MedicalInfoDrugAllergies allergy in patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies)
                        {
                            model.drugAllergies += allergy.ActiveIngredient.Name + ", ";
                        }

                        model.drugAllergies = model.drugAllergies.Remove(model.drugAllergies.LastIndexOf(","));
                    }

                }

                return model;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetMedicalInformationId(string patientID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Patient patient = objectContext.GetObject<Patient>(new Guid(patientID));
                if (patient.MedicalInformation != null)
                {
                    return patient.MedicalInformation.ObjectID.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public bool ControlHighPregnancyRisk(Patient Patient)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (Patient.MedicalInformation.HighRiskPregnancyDate != null)
                {
                    if (Common.RecTime().Month - ((DateTime)Patient.MedicalInformation.HighRiskPregnancyDate).Month + 12 * (Common.RecTime().Year - ((DateTime)Patient.MedicalInformation.HighRiskPregnancyDate).Year) >= 9)
                    {
                        Patient.MedicalInformation.HighRiskPregnancy = false;
                        objectContext.Save();
                        return true;
                    }
                }

                return false;
            }
        }
    }
}