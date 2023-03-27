//$7ED3C78A
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using TTStorageManager.Security;
using Core.Security;

namespace Core.Controllers
{
    public partial class RegularObstetricServiceController
    {
        partial void PreScript_RegularObstetricNewForm(RegularObstetricNewFormViewModel viewModel, RegularObstetric regularObstetric, TTObjectContext objectContext)
        {
            if (((ITTObject)regularObstetric).IsNew)
            {
                Guid? activeEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (activeEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction activeEpisodeAction = objectContext.GetObject<EpisodeAction>(activeEpisodeActionObjectID.Value);

                    regularObstetric.SetMandatoryEpisodeActionProperties(activeEpisodeAction, activeEpisodeAction.MasterResource, true);
                    if (activeEpisodeAction.SubEpisode.StarterEpisodeAction != null && activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                        regularObstetric.ProcedureDoctor = activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor;
                    else if (activeEpisodeAction.ProcedureDoctor != null)
                        regularObstetric.ProcedureDoctor = activeEpisodeAction.ProcedureDoctor;

                    regularObstetric.Episode = activeEpisodeAction.Episode;
                    regularObstetric.Patient = activeEpisodeAction.Episode.Patient;
                    regularObstetric.MotherAge = activeEpisodeAction.Episode.Patient.Age != null ? activeEpisodeAction.Episode.Patient.Age : null;
                    viewModel.InpatientDate = ((InPatientPhysicianApplication)activeEpisodeAction).InPatientTreatmentClinicApp.ClinicInpatientDate;
                }
                if (regularObstetric.Patient.ActivePregnancy != null)
                {
                    regularObstetric.Pregnancy = regularObstetric.Patient.ActivePregnancy;                    
                }
                else
                {
                    Pregnancy pregnancy = new Pregnancy(objectContext);
                    regularObstetric.Pregnancy = pregnancy;
                }

                PregnantInformation information = new PregnantInformation(objectContext);
                regularObstetric.PregnantInformation = information;
            }


            if(regularObstetric.PregnantInformation == null)
            {
                PregnantInformation information = new PregnantInformation(objectContext);
                regularObstetric.PregnantInformation = information;
            }

            viewModel.PregnantInfo = regularObstetric.PregnantInformation;
            viewModel.NumberofNewborns = regularObstetric.Pregnancy.NumberOfNewborns;
            viewModel.NumberOfStillbornBabies = regularObstetric.Pregnancy.NumberOfStillbornBabies;
            viewModel.MotherName = regularObstetric.Patient.Name + " " + regularObstetric.Patient.Surname;
            if(regularObstetric.Patient.SKRSMaritalStatus != null)
                viewModel.MaritalStatus = regularObstetric.Patient.SKRSMaritalStatus.ADI;
            viewModel.MotherAge = regularObstetric.Patient.Age;
            viewModel.InpatientDate = ((InPatientPhysicianApplication)regularObstetric.MasterAction).InPatientTreatmentClinicApp.ClinicInpatientDate;
            string result = "";
            PatientIdentityAndAddress address = regularObstetric.Patient.PatientAddress;
            if (address != null)
            {
                if (address.HomeAddress != null)
                {
                    result += address.HomeAddress;
                }

                if (address.SKRSMahalleKodlari != null )
                {
                    result += " " + address.SKRSMahalleKodlari.ADI;
                }

                if (address.BuildingBlockName != null )
                {
                    result += " " + address.BuildingBlockName;
                }
                if (address.DisKapi != null)
                {
                    result += " BLOK NO:" + address.DisKapi;
                }
                if (address.IcKapi != null )
                {
                    result += " �� KAPI NO:" + address.IcKapi;
                }
                if (address.HomePostcode != null)
                {
                    result += " " + address.HomePostcode;
                }
                if (address.HomePhone != null )
                {
                    result += " " + address.HomePhone;
                }

                if (address.SKRSKoyKodlari != null)
                {
                    result += " " + address.SKRSKoyKodlari.ADI;
                }

                if (address.SKRSIlceKodlari != null)
                {
                    result += " " + address.SKRSIlceKodlari.ADI;
                }

                if (address.SKRSILKodlari != null)
                {
                    result += " /" + address.SKRSILKodlari.ADI;
                }
        

            }

           viewModel.Address = result;

            if (regularObstetric.Patient.Sex.ADI == "ERKEK")
            {
                throw new Exception("Bu i�lemi erkek hastalara ba�latamazs�n�z!"); 
            }


            viewModel.BabyInfoList = new List<BabyInfo>();
            foreach (var baby in regularObstetric.BabyObstetricInformation)
            {
                string _summary = "";
                if (baby.BabyStatus == BirthReportBabyStatus.Alive)
                {
                    _summary = "Ya�ayan ;  " //Ya�am Durumu
                        + (baby.Name != null ? baby.Name : baby.Patient.Name) + " " + baby.Surname
                        + " Anne Ad�:" +
                        ((baby.MotherPatient != null && baby.MotherPatient.Name != null) ? baby.MotherPatient.Name : "") //Anne Ad�
                        + " " +
                        ((baby.MotherPatient != null && baby.MotherPatient.Surname != null) ? baby.MotherPatient.Surname : "") //Anne Soyad�
                        + " Do�um Tarihi:" +
                        (baby.BirthDateTime != null ? baby.BirthDateTime.ToString() : "") //Do�um Tarihi
                        + " Kilo:" +
                        (baby.Weigth != null ? baby.Weigth.ToString() + "(gr)" : ""); //Kilo
                }
                if (baby.BabyStatus == BirthReportBabyStatus.Dead)
                {
                    _summary = "�l� bebek;  " //Ya�am Durumu
                        + " Anne Ad�:" +
                        ((baby.MotherPatient != null && baby.MotherPatient.Name != null) ? baby.MotherPatient.Name : "") //Anne Ad�
                        + " " +
                        ((baby.MotherPatient != null && baby.MotherPatient.Surname != null) ? baby.MotherPatient.Surname : "") //Anne Soyad�
                        + " �l�m Tarihi:" +
                        (baby.DatetimeOfDeath != null ? baby.DatetimeOfDeath.ToString() : "") //�l�m Tarihi
                        + " �l�m Sebebi:" +
                        (baby.CauseOfDeath != null ? baby.CauseOfDeath.ADI : ""); //�l�m Sebebi
                }

                BabyInfo babyInfo = new BabyInfo
                {
                    objectDefName = baby.ObjectDef.Name,
                    objectId = baby.ObjectID,
                    summary = _summary
                };

                viewModel.BabyInfoList.Add(babyInfo);
            }

            viewModel.PreviousPregnancyInfo = new PreviousPregnancyInfo();
            viewModel.PreviousPregnancyInfo = GetPregnancyStatistics(viewModel.PreviousPregnancyInfo, regularObstetric.Patient);

            var list = regularObstetric.IndicationReasons;
            foreach(var item in list)
            {
                var a = item.Indications;
            }

            ContextToViewModel(viewModel, objectContext);


            objectContext.FullPartialllyLoadedObjects();
            //ContextToViewModel den sonra �a��r�lmal� //TANI i�in
            viewModel.GridEpisodeDiagnosisGridList = regularObstetric.DiagnosisGrid_PreScript();
            // Bu form Popupda yeni a��ld���ndan  DiagnosisDefinitions bo� geliyor
            if (viewModel.DiagnosisDefinitions.Count() == 0)
            {
                var DiagnosisDefinitionList = new List<DiagnosisDefinition>();
                foreach (var gridEpisodeDiagnosis in viewModel.GridEpisodeDiagnosisGridList)
                {
                    if (!DiagnosisDefinitionList.Contains(gridEpisodeDiagnosis.Diagnose))
                        DiagnosisDefinitionList.Add(gridEpisodeDiagnosis.Diagnose);
                }
                viewModel.DiagnosisDefinitions = DiagnosisDefinitionList.ToArray();
            }


        }

        partial void PostScript_RegularObstetricNewForm(RegularObstetricNewFormViewModel viewModel, RegularObstetric regularObstetric, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //TODO Merve
            regularObstetric.DiagnosisGrid_PostScript(viewModel.GridEpisodeDiagnosisGridList);

            int babyCount = 1;
            foreach (var _babyInfo in viewModel.BabyInfoList)
            {
                if (_babyInfo._babyInformationFormViewModel != null)
                {//Bebek Bilgilerini kaydetme
                    _babyInfo._babyInformationFormViewModel._RegularObstetric = regularObstetric;
                    _babyInfo._babyInformationFormViewModel.babyCount = babyCount;

                    //_babyInfo._babyInformationFormViewModel._BabyObstetricInformation.RegularObstetric = regularObstetric;
                    BabyObstetricInformationServiceController.AddViewModelToContext(objectContext, _babyInfo._babyInformationFormViewModel);
                    babyCount++;
                }
            }

            if (viewModel.IsPregnancyEnded == true)
            {
                objectContext.Update();
                foreach (var babyInfo in regularObstetric.BabyObstetricInformation)//Gebelik Sonucu Olu�turuluyor -> PregnancyResult
                {
                    SexEnum _gender = Convert.ToInt32(babyInfo.Gender.KODU) == 1 ? SexEnum.Male : (Convert.ToInt32(babyInfo.Gender.KODU) == 2 ? SexEnum.Female : SexEnum.Unidentified);
                    PregnancyResult result = new PregnancyResult(objectContext);

                    //Do�um Sonlanma Tarihi, Do�umun ger�ekle�ti�i yer
                    result.BabyStatus = babyInfo.BabyStatus;
                    result.BirthResult = regularObstetric.BirthResult;
                    result.BirthType = babyInfo.BirthType;
                    result.BirthWeight = babyInfo.Weigth;
                    result.Gender = _gender;
                    result.Pregnancy = regularObstetric.Pregnancy;


                    regularObstetric.Pregnancy.PregnancyResults.Add(result);
                }
                regularObstetric.CurrentStateDefID = RegularObstetric.States.Completed;
                regularObstetric.Patient.ActivePregnancy = null;
            }

            regularObstetric.PregnantInformation = viewModel.PregnantInfo;
            regularObstetric.Pregnancy.NumberOfNewborns = viewModel.NumberofNewborns; //yeni do�an bebek say�s�
            regularObstetric.Pregnancy.NumberOfStillbornBabies = viewModel.NumberOfStillbornBabies; //�l� do�an bebek say�s�
        }

        public PreviousPregnancyInfo GetPregnancyStatistics(PreviousPregnancyInfo PreviousPregnancyInfo, Patient patient)
        {
            BindingList<Pregnancy.GetAllPregnanciesByPatient_Class> previousPregnancies = Pregnancy.GetAllPregnanciesByPatient(patient.ObjectID);
            PreviousPregnancyInfo.NumberOfPregnancy = previousPregnancies.Count(); //Gebelik Say�s�
            PreviousPregnancyInfo.Parity = previousPregnancies.Where(c => c.PregnancyPhysiology == PregnancyPhysiologyEnum.Normal).Count(); //Parite : Ge�irilen Gebelik Say�s�(do�umla sonlanan)
            PreviousPregnancyInfo.Abortion = previousPregnancies.Where(c => c.PregnancyPhysiology != PregnancyPhysiologyEnum.Normal).Count(); //Abortus : Hastan�n ge�irdi�i d���k say�s�
            BindingList<PregnancyResult.GetAllPregnancyResultsByPatient_Class> pregnancyResults = PregnancyResult.GetAllPregnancyResultsByPatient(patient.ObjectID);
            PreviousPregnancyInfo.LivingBabies = pregnancyResults.Where(c => c.BabyStatus == BirthReportBabyStatus.Alive).Count(); //Ya�ayan : Hastan�n ya�ayan bebek say�s�
            PreviousPregnancyInfo.DC = pregnancyResults.Where(c => c.BabyStatus == BirthReportBabyStatus.Dead).Count(); //D&C : Hastan�n �l� bebek say�s�
            return PreviousPregnancyInfo;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Dogum_Raporu_Yazma)]
        public string OpenEDogumReport(Guid babyObstetricInformation)
        {
            string url = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Sekreter))
            {
                role = "5DDEB487-A0C2-47D6";
            }
            else if (user.HasRole(TTRoleNames.Bastabip))
            {
                role = "417A9319-6430-490C";
            }
            else if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
            }

            else
            {
                role = "7AE271CC-5C57-4A77";    //HBYS
            }
            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            //request.Resource = "/api/receteapi/tokenolustur";
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                using (var context = new TTObjectContext(true))
                {
                    BabyObstetricInformation obstetricInformation = context.GetObject<BabyObstetricInformation>(babyObstetricInformation);
                    if (obstetricInformation != null)
                    {
                        Patient patient = obstetricInformation.RegularObstetric.Episode.Patient;

                        if (user.HasRole(TTRoleNames.Tabip) || user.HasRole(TTRoleNames.Bastabip))
                        {
                            if (patient.Nationality != null && patient.Nationality.Kodu == "TR")
                            {
                                url = "http://xxxxxx.com/DogumWeb/Dogum/Create?Authorization=" + token +
                                    "&patientId=" + patient.UniqueRefNo.ToString() + "&isCitizen=true";
                                string urlAppendence = this.getAdditionalParametersForUrl(obstetricInformation, context);
                                if (urlAppendence != String.Empty)
                                    url += "&" + urlAppendence;
                            }
                            else
                            {
                                bool found = false;
                                if (patient.UniqueRefNo != null)// Yabac� Hasta No yoksa
                                {
                                    url = "http://xxxxxx.com/DogumWeb/Dogum/CreateNonCitizen?Authorization=" + token +
                                   "&patientId=" + patient.UniqueRefNo.ToString() + "&isCitizen=false";
                                    found = true;
                                    string urlAppendence = this.getAdditionalParametersForUrl(obstetricInformation, context);
                                    if (urlAppendence != String.Empty)
                                        url += "&" + urlAppendence;
                                }
                                if (patient.PassportNo != null)
                                {
                                    url = "http://xxxxxx.com/DogumWeb/Dogum/CreateNonCitizen?Authorization=" + token +
                                  "&patientId=" + patient.PassportNo.ToString() + "&isCitizen=false";
                                    found = true;
                                    string urlAppendence = this.getAdditionalParametersForUrl(obstetricInformation, context);
                                    if (urlAppendence != String.Empty)
                                        url += "&" + urlAppendence;
                                }
                                if (!found)
                                {
                                    url += "http://xxxxxx.com/DogumWeb/Dogum/Index?Authorization=" + token;
                                }
                            }
                        }
                        else
                        {
                            url = "http://xxxxxx.com/DogumWeb/Dogum/Index?Authorization=" + token;
                        }


                    }
                }
            }
            else
            {
                //throw new Exception($"{renkliReceteResult.SonucKodu} - {renkliReceteResult.SonucAciklama}");
            }
            return url;
        }



        public string getAdditionalParametersForUrl(BabyObstetricInformation babyObstetricInformation, TTObjectContext objectContext)
        {
            string urlAppendence = String.Empty;


            if (babyObstetricInformation != null)
            {
                if (babyObstetricInformation.BabyStatus != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&obstetricResult=";
                    else
                        urlAppendence += "obstetricResult=";
                    if (babyObstetricInformation.BabyStatus == BirthReportBabyStatus.Alive)
                        urlAppendence += "1";
                    else
                        urlAppendence += "0";
                }

                if (babyObstetricInformation.PregnancyWeek != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&gestationalWeek=";
                    else
                        urlAppendence += "gestationalWeek=";
                    urlAppendence += babyObstetricInformation.PregnancyWeek.ToString();
                }

                if (babyObstetricInformation.RegularObstetric.Pregnancy != null)
                {
                    /*if (babyObstetricInformation.RegularObstetric.Pregnancy.LastMenstrualPeriod != null)
                    {
                        if (urlAppendence != String.Empty)
                            urlAppendence += "&lastMenstruationDate=";
                        else
                            urlAppendence += "lastMenstruationDate=";
                        urlAppendence += ((DateTime)babyObstetricInformation.RegularObstetric.Pregnancy.LastMenstrualPeriod).ToString("dd.MM.yyyy");
                    }*/
                }

                if (babyObstetricInformation.PresentationType != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&babyArrivalType=";
                    else
                        urlAppendence += "babyArrivalType=";
                    if (babyObstetricInformation.PresentationType == PresentationTypeEnum.HeadPresentation)
                        urlAppendence += "1";
                    else if (babyObstetricInformation.PresentationType == PresentationTypeEnum.BreechPresentation)
                        urlAppendence += "2";
                    else
                        urlAppendence += "3";
                }

                if (babyObstetricInformation.BirthDateTime != null)
                {
                    /*if (urlAppendence != String.Empty)
                        urlAppendence += "&babyBirthDate=";
                    else
                        urlAppendence += "babyBirthDate=";
                    urlAppendence += ((DateTime)babyObstetricInformation.BirthDateTime).ToString("dd.MM.yyyy");*/
                }

                if (babyObstetricInformation.Height != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&babyLength=";
                    else
                        urlAppendence += "babyLength=";
                    urlAppendence += babyObstetricInformation.Height.ToString();
                }

                if (babyObstetricInformation.HeadCircumference != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&headCircumference=";
                    else
                        urlAppendence += "headCircumference=";
                    urlAppendence += babyObstetricInformation.HeadCircumference.ToString();
                }

                if (babyObstetricInformation.Weigth != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&babyWeight=";
                    else
                        urlAppendence += "babyWeight=";
                    urlAppendence += babyObstetricInformation.Weigth.ToString();
                }

                if (babyObstetricInformation.HepatitisB != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&isHepatitBVaccinated=";
                    else
                        urlAppendence += "isHepatitBVaccinated=";
                    urlAppendence += babyObstetricInformation.HepatitisB.ToString();
                }

                if (babyObstetricInformation.VitaminKApplied != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&isVitaminK=";
                    else
                        urlAppendence += "isVitaminK=";
                    urlAppendence += babyObstetricInformation.VitaminKApplied.ToString();
                }

                if (babyObstetricInformation.HearingScreening != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&isAudioTest=";
                    else
                        urlAppendence += "isAudioTest=";
                    urlAppendence += babyObstetricInformation.HearingScreening.ToString();
                }

                /*if (babyObstetricInformation.Name != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&babyName=";
                    else
                        urlAppendence += "babyName=";
                    urlAppendence += babyObstetricInformation.Name.ToString();
                }*/

                if (babyObstetricInformation.FatherName != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&fatherName=";
                    else
                        urlAppendence += "fatherName=";
                    urlAppendence += babyObstetricInformation.FatherName.ToString();
                }

                if (babyObstetricInformation.BirthType != null)
                {
                    if (urlAppendence != String.Empty)
                        urlAppendence += "&obstetricMethod=";
                    else
                        urlAppendence += "obstetricMethod=";
                    if (babyObstetricInformation.BirthType.KODU == "1")
                        urlAppendence += "1";
                    else
                        urlAppendence += "2";
                }
                return urlAppendence;



            }

            return urlAppendence;
        }

        public InPatientPhysicianApplication getEpisodeActionById(string objectId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var tyy = typeof(EpisodeAction);
                InPatientPhysicianApplication inPatientPhysicianApplication = objectContext.GetObject<InPatientPhysicianApplication>(new Guid(objectId));

                EpisodeAction episodeAction = inPatientPhysicianApplication as EpisodeAction;
                return inPatientPhysicianApplication;
            }
        }

        public Guid DeleteBabyObject(Guid BabyObjectID, string BabyObjectDefName)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var baby = objectContext.GetObject(BabyObjectID, BabyObjectDefName);
                ((ITTObject)baby).Delete();
                objectContext.Save();
                return BabyObjectID;
            }
        }

        [HttpGet]
        public BabyMotherMatchBarcodeInfo GetBabyMotherMatchBarcodeInfo(Guid babyObstetricInformation, Guid motherSubepisode)
        {
            BabyMotherMatchBarcodeInfo babyMotherMatchBarcodeInfo = new BabyMotherMatchBarcodeInfo();

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                SubEpisode subepisode = objectContext.GetObject<SubEpisode>(motherSubepisode);
                BabyObstetricInformation obstetricInformation = objectContext.GetObject<BabyObstetricInformation>(babyObstetricInformation);
                babyMotherMatchBarcodeInfo.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));
                Patient babyPatient = null;
                if (obstetricInformation.Patient != null)
                {
                    babyPatient = obstetricInformation.Patient;
                }
                else
                {
                    var BabyPatient = Patient.GetPatientObjectsByInjection(objectContext, " WHERE MOTHER.OBJECTID=''").ToList();
                    if (BabyPatient.Count == 1)
                    {
                        babyPatient = BabyPatient[0];
                    }
                    else if (BabyPatient.Count > 1)
                    {
                        babyPatient = BabyPatient.Where(y => y.Name == obstetricInformation.Name).FirstOrDefault();
                    }
                }

                if (babyPatient != null)
                {
                    babyMotherMatchBarcodeInfo.PatientName = obstetricInformation.Name.ToUpper() + obstetricInformation.Surname.ToUpper();
                    babyMotherMatchBarcodeInfo.FatherName = babyPatient.FatherName.ToUpper() + " " + babyPatient.Surname.ToUpper();
                    babyMotherMatchBarcodeInfo.MotherName = babyPatient.MotherName.ToUpper() + " " + babyPatient.Surname.ToUpper();
                    var babyEpisode = babyPatient.Episodes.Where(t => t.CurrentStateDefID == Episode.States.Open).FirstOrDefault();
                    if (babyEpisode != null)
                    {
                        var babySubEpisode = babyEpisode.LastSubEpisode;
                        if (babySubEpisode != null)
                        {
                            babyMotherMatchBarcodeInfo.AdmissionNo = babySubEpisode.ProtocolNo;
                        }
                    }
                }
                else
                {
                    babyMotherMatchBarcodeInfo.FatherName = obstetricInformation.FatherName != null ? obstetricInformation.FatherName.ToUpper() + obstetricInformation.Surname.ToUpper() :"" ;
                    babyMotherMatchBarcodeInfo.MotherName = obstetricInformation.MotherPatient.Name + obstetricInformation.MotherPatient.Surname;
                    babyMotherMatchBarcodeInfo.PatientName = obstetricInformation.Name.ToUpper() + obstetricInformation.Surname.ToUpper();
                }

                if (String.IsNullOrEmpty(babyMotherMatchBarcodeInfo.AdmissionNo))
                {
                    babyMotherMatchBarcodeInfo.AdmissionNo = subepisode.ProtocolNo;
                }
            }
            return babyMotherMatchBarcodeInfo;
        }
    }
}

namespace Core.Models
{
    public partial class RegularObstetricNewFormViewModel : BaseViewModel
    {

        public bool IsPregnancyEnded { get; set; }//Gebelik Sonland�r�ls�n m�?

        public List<BabyInfo> BabyInfoList { get; set; }

        public PreviousPregnancyInfo PreviousPregnancyInfo { get; set; }

        public WomanSpecialityObject WomanSpecialityObject { get; set; }
        public PregnantInformation PregnantInfo { get; set; }
        public int? NumberofNewborns { get; set; }
        public int? NumberOfStillbornBabies { get;set; }

        //Anne Bilgileri
        public string MotherName { get; set; }
        public DateTime? InpatientDate { get; set; }
        public string MaritalStatus { get; set; }
        public int? MotherAge { get; set; }
        public string Address { get; set; }
        public List<IndicationReason> IndicationReasons { get; set; }
    }
    public class BabyInfo
    {
        public Guid objectId { get; set; }
        public string objectDefName { get; set; }
        public string summary { get; set; }
        public BabyInformationFormViewModel _babyInformationFormViewModel { get; set; }
    }

    public class PreviousPregnancyInfo
    {
        public int NumberOfPregnancy { get; set; }
        public int Parity { get; set; }
        public int Abortion { get; set; }
        public int LivingBabies { get; set; }
        public int DC { get; set; }
    }

    public class BabyMotherMatchBarcodeInfo
    {
        public string HospitalName { get; set; }
        public string MotherName { get; set; }
        public string AdmissionNo { get; set; }
        public string FatherName { get; set; }
        public string PatientName { get; set; }
    }
}
