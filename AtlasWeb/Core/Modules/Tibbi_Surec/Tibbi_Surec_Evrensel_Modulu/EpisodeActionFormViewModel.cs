//$A9F4315F
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Helpers;

using Infrastructure.Filters;
using TTUtils;
using TTStorageManager.Security;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using static TTObjectClasses.HealthCommittee;
using RestSharp;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Core.Controllers
{
    public partial class EpisodeActionServiceController : Controller
    {
        [HttpGet]
        public EpisodeActionFormViewModel EpisodeActionForm(Guid? id)
        {
            var FormDefID = Guid.Parse("170f4d9c-d94c-4428-b90d-5e3cd435d2fa");
            var ObjectDefID = Guid.Parse("a9754f35-2998-48c7-80f3-5194f9e678a7");
            var viewModel = new EpisodeActionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._EpisodeAction = objectContext.GetObject(id.Value, ObjectDefID) as EpisodeAction;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                //using (var objectContext = new TTObjectContext(false))
                //{
                //    viewModel._EpisodeAction = new EpisodeAction(objectContext);
                //}
            }

            return viewModel;
        }

        [HttpPost]
        public void EpisodeActionForm(EpisodeActionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(viewModel._EpisodeAction);
                objectContext.Save();
            }
        }

        [HttpGet]
        public DynamicComponentInfoDVO GetDynamicComponentManipulationFormBaseObjectInfo([FromQuery] string EpisodeActionObjectId) //manipulasyonda hizmete özel formlar için
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var episodeAction = objectContext.GetObject(new Guid(EpisodeActionObjectId), typeof(EpisodeAction));
                if (episodeAction is Manipulation)
                {
                    Manipulation manipulation = (Manipulation)episodeAction;
                    if (manipulation.ManipulationFormBaseObject.Count > 0)
                    {
                        ManipulationFormBaseObject manipulationFormBaseObject = manipulation.ManipulationFormBaseObject[0];
                        var subFolders = Common.GetParentFolders(manipulationFormBaseObject.ObjectDef.ModuleDef);
                        var folderPath = "Tibbi_Surec/Manipulasyon_Modulu";
                        var moduleName = "ManipulasyonModule";
                        if (manipulationFormBaseObject is EkokardiografiFormObject)
                        {
                            moduleName = "ManipulasyonModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                            dynamicComponentInfo.ComponentName = "EkokardiografiForm"; // obj.CurrentStateDef.FormDef.CodeName;
                        }
                        else if (manipulationFormBaseObject is AudiologyObject)
                        {
                            moduleName = "ManipulasyonModule";
                            dynamicComponentInfo.ComponentName = "AudiologyForm";
                        }

                        if (!string.IsNullOrEmpty(folderPath))
                        {
                            var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                            dynamicComponentInfo.ModuleName = moduleName;
                            dynamicComponentInfo.ModulePath = modulePath;
                            dynamicComponentInfo.objectID = manipulationFormBaseObject.ObjectID.ToString();
                            objectContext.FullPartialllyLoadedObjects();
                        }
                    }
                }

                return dynamicComponentInfo;
            }
        }

        [HttpGet]
        public DynamicComponentInfoDVO GetDynamicComponentSpecialityBasedObjectInfo([FromQuery] string EpisodeActionObjectId) //Uzmanlık için
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var episodeAction = objectContext.GetObject(new Guid(EpisodeActionObjectId), typeof(EpisodeAction));
                if (episodeAction is PhysicianApplication)
                {
                    PhysicianApplication physicianApplication = (PhysicianApplication)episodeAction;
                    if (physicianApplication.SpecialityBasedObject.Count > 0)
                    {
                        SpecialityBasedObject specialityBasedObject = physicianApplication.SpecialityBasedObject[0];
                        var subFolders = Common.GetParentFolders(specialityBasedObject.ObjectDef.ModuleDef);
                        var folderPath = string.Empty;
                        var moduleName = string.Empty;
                        if (specialityBasedObject is ChildGrowthStandards)
                        {
                            folderPath = "Tibbi_Surec/Cocuk_Takip_Modulu";
                            moduleName = "CocukTakipModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                            dynamicComponentInfo.ComponentName = "ChildGrowthStandardsForm"; // obj.CurrentStateDef.FormDef.CodeName;
                        }
                        else if (specialityBasedObject is EyeExamination)
                        {
                            folderPath = "Tibbi_Surec/Goz_Muayene_Modulu";
                            moduleName = "GozMuayeneModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                            dynamicComponentInfo.ComponentName = "Eye_Examination"; // obj.CurrentStateDef.FormDef.CodeName;
                        }
                        else if (specialityBasedObject is WomanSpecialityObject)
                        {
                            folderPath = "Tibbi_Surec/Kadin_Dogum_Modulu";
                            moduleName = "KadinDogumModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                            dynamicComponentInfo.ComponentName = "WomanSpecialityForm"; // obj.CurrentStateDef.FormDef.CodeName;
                        }
                        else if (specialityBasedObject is EmergencySpecialityObject)
                        {
                            folderPath = "Tibbi_Surec/Acil_Modulu";
                            moduleName = "AcilModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                            dynamicComponentInfo.ComponentName = "EmergencySpecialityObjectForm"; // obj.CurrentStateDef.FormDef.CodeName;
                        }

                        else if (specialityBasedObject is IntensiveCareSpecialityObj)
                        {
                            folderPath = "Tibbi_Surec/Yogun_Bakim_Modulu";
                            moduleName = "YogunBakimModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                            dynamicComponentInfo.ComponentName = "IntensiveCareSpecialityObjForm"; // obj.CurrentStateDef.FormDef.CodeName;
                        }

                        //else if (specialityBasedObject is NewBornIntensiveCare)
                        //{
                        //    folderPath = "Tibbi_Surec/Yeni_Dogan_Yogun_Bakim_Modulu";
                        //    moduleName = "YeniDoganYogunBakimModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                        //    dynamicComponentInfo.ComponentName = "NewBornIntensiveCareForm"; // obj.CurrentStateDef.FormDef.CodeName;
                        //}
                        else if (specialityBasedObject is TraditionalMedicine)
                        {
                            folderPath = "Tibbi_Surec/Geleneksel_Alternatif_Tamamlayici_Uygulamalar_Modulu";
                            moduleName = "GelenekselAlternatifTamamlayiciUygulamalarModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                            dynamicComponentInfo.ComponentName = "GetatExaminationForm"; // obj.CurrentStateDef.FormDef.CodeName;
                        }

                        else if (specialityBasedObject is MedicalOncology)
                        {
                            folderPath = "Tibbi_Surec/Onkoloji_Modulu";
                            moduleName = "OnkolojiModule";
                            dynamicComponentInfo.ComponentName = "MedicalOncologySpecialityForm";
                        }
                        if (!string.IsNullOrEmpty(folderPath))
                        {
                            var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                            dynamicComponentInfo.ModuleName = moduleName;
                            dynamicComponentInfo.ModulePath = modulePath;
                            dynamicComponentInfo.objectID = specialityBasedObject.ObjectID.ToString();
                            objectContext.FullPartialllyLoadedObjects();
                        }
                    }
                }

                return dynamicComponentInfo;
            }
        }

        [HttpGet]
        public ActionTypeEnum GetActionType([FromQuery] string EpisodeActionObjectID, [FromQuery] string EpisodeActionObjectDefID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                ActionTypeEnum actType = ActionTypeEnum.UnDefinedAction;
                IBindingList eaList = EpisodeAction.GetEpisodeActionByObjectID(objectContext, new Guid(EpisodeActionObjectID));
                if (eaList.Count > 0)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(EpisodeActionObjectID));
                    actType = episodeAction.ActionType;
                }
                else
                {
                    EpisodeAction episodeAction = (EpisodeAction)objectContext.CreateObject(new Guid(EpisodeActionObjectDefID));
                    actType = ((EpisodeAction)episodeAction).ActionType;
                }
                return actType;
            }
        }

        [HttpGet]
        public InpatientAdmission GetInpatientAdmissionBayActiveEpisodeAction(Guid episodeActionObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid? selectedEpisodeActionObjectID = episodeActionObjectID;
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = null;
                    if (episodeAction is InPatientPhysicianApplication)
                    {
                        inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                    }
                    else if (episodeAction is NursingApplication)
                    {
                        inPatientTreatmentClinicApp = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
                    }
                    else if (episodeAction is InPatientTreatmentClinicApplication)
                    {
                        inPatientTreatmentClinicApp = ((InPatientTreatmentClinicApplication)episodeAction);
                    }

                    if (inPatientTreatmentClinicApp != null)
                    {
                        InpatientAdmission inpatientAdmission = (InpatientAdmission)inPatientTreatmentClinicApp.BaseInpatientAdmission;
                        objectContext.FullPartialllyLoadedObjects();
                        return inpatientAdmission;
                    }
                }
            }

            return null;
        }

        [HttpGet]
        public InPatientTreatmentClinicApplication GetInPatientTreatmentClinicAppByActiveEpisodeAction(Guid episodeActionObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid? selectedEpisodeActionObjectID = episodeActionObjectID;
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = null;
                    if (episodeAction is InPatientPhysicianApplication)
                    {
                        inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                    }
                    else if (episodeAction is NursingApplication)
                    {
                        inPatientTreatmentClinicApp = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
                    }

                    if (inPatientTreatmentClinicApp != null)
                    {
                        objectContext.FullPartialllyLoadedObjects();
                        return inPatientTreatmentClinicApp;
                    }
                }
            }

            return null;
        }

        [HttpGet]
        public bool ValidateSUTRules(string EpisodeActionObjectId)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectId), "EpisodeAction");
            TTUtils.Entities.RuleValidateResultDto validateResult = episodeAction.CheckSutRules(false);
            // SUT kural doğrulama sonucu hiç bir mesaj dönmedi
            if (validateResult == null || !EnumerableHelper.Any(validateResult.Messages))
                return true;
            //TTFormClasses.SutRuleCheckResultsForm form = new TTFormClasses.SutRuleCheckResultsForm();
            //form.BlockRequest = false;
            //form.RuleViolateMessages = validateResult.Messages;
            //form.BlockRequest = validateResult.BlockRequest;
            //DialogResult result = form.ShowDialog((IWin32Window)owner);
            bool returnValue = false;
            // Doktor devam seçeneğini kullanıyor
            //if (result == DialogResult.Ignore)
            //{
            //    this.SetSutRulesIgnored(validateResult.Messages);
            //    returnValue = true;
            //}
            string resultXml = SerializationHelper.XmlSerializeObject(validateResult.Messages);
            string resultText = resultXml;
            if (resultText.Length > 4000)
            {
                resultText = resultText.Substring(0, 4000);
            }

            TTObjectContext context = new TTObjectContext(false);
            SUTRuleCheckResult sutCheckResult = new SUTRuleCheckResult(context);
            sutCheckResult.ProcessDate = DateTime.Now;
            sutCheckResult.ResUser = TTUser.CurrentUser.UserObject as ResUser;
            sutCheckResult.Results = resultText;
            sutCheckResult.Status = SUTRuleCheckResultStatus.Rejected;
            sutCheckResult.Episode = episodeAction.Episode;
            sutCheckResult.CheckResults = resultXml;
            //if (result == DialogResult.Ignore)
            //{
            //    sutCheckResult.Status = SUTRuleCheckResultStatus.Ignored;
            //}
            context.Save();
            // SUT kural doğrulama başarısız oldu işleme devam edilmeyecek
            return returnValue;
        }

        [HttpPost]
        public bool ValidateSUTRules2(SUTRuleEngineInputViewModel inputDVO)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            objContext.AddObject(inputDVO.episodeAction);
            foreach (SubActionProcedure sp in inputDVO.subActionProcedures)
            {
                objContext.AddObject(sp);
            }


            EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(inputDVO.episodeAction.ObjectID, "EpisodeAction");
            foreach (SubActionProcedure sp in inputDVO.subActionProcedures)
            {
                //TODO: Nesne sadece okunur hatası verıyor ??
                //episodeAction.SubactionProcedures.Add(sp);
            }


            TTUtils.Entities.RuleValidateResultDto validateResult = episodeAction.CheckSutRules(false);
            // SUT kural doğrulama sonucu hiç bir mesaj dönmedi
            if (validateResult == null || !EnumerableHelper.Any(validateResult.Messages))
                return true;
            //TTFormClasses.SutRuleCheckResultsForm form = new TTFormClasses.SutRuleCheckResultsForm();
            //form.BlockRequest = false;
            //form.RuleViolateMessages = validateResult.Messages;
            //form.BlockRequest = validateResult.BlockRequest;
            //DialogResult result = form.ShowDialog((IWin32Window)owner);
            bool returnValue = false;
            // Doktor devam seçeneğini kullanıyor
            //if (result == DialogResult.Ignore)
            //{
            //    this.SetSutRulesIgnored(validateResult.Messages);
            //    returnValue = true;
            //}
            string resultXml = SerializationHelper.XmlSerializeObject(validateResult.Messages);
            string resultText = resultXml;
            if (resultText.Length > 4000)
            {
                resultText = resultText.Substring(0, 4000);
            }

            TTObjectContext context = new TTObjectContext(false);
            SUTRuleCheckResult sutCheckResult = new SUTRuleCheckResult(context);
            sutCheckResult.ProcessDate = DateTime.Now;
            sutCheckResult.ResUser = TTUser.CurrentUser.UserObject as ResUser;
            sutCheckResult.Results = resultText;
            sutCheckResult.Status = SUTRuleCheckResultStatus.Rejected;
            sutCheckResult.Episode = episodeAction.Episode;
            sutCheckResult.CheckResults = resultXml;
            //if (result == DialogResult.Ignore)
            //{
            //    sutCheckResult.Status = SUTRuleCheckResultStatus.Ignored;
            //}
            context.Save();
            // SUT kural doğrulama başarısız oldu işleme devam edilmeyecek
            return returnValue;
        }

        [HttpGet]
        public string WarningMessage(string EpisodeActionObjectId)
        {
            string warningMessage = String.Empty;
            using (var objectContext = new TTObjectContext(true))
            {
                Guid id = new Guid(EpisodeActionObjectId);
                var episodeActionList = EpisodeAction.GetByObjectID(objectContext, id);
                if (episodeActionList.Count > 0)
                {
                    EpisodeAction episodeAction = episodeActionList[0];

                    warningMessage += episodeAction.SubEpisode.isolationInformation();
                    //if(episodeAction.Episode.Patient.IsPatientAllergic())
                    //    warningMessage += "HASTANIN ALERJİSİ VAR !" + "\r\n";

                    if (episodeAction.SubEpisode.PatientAdmission.ImportantPAInfo != null)
                        warningMessage += episodeAction.SubEpisode.PatientAdmission.ImportantPAInfo.ToString() + "\r\n";

                    if (episodeAction.SubEpisode.PatientAdmission.AdmissionType.provizyonTipiKodu == "V")
                        warningMessage += "Adli Vaka" + "\r\n";

                    if (episodeAction.SubEpisode.HasPaidPayerTypeSEPExists)
                        warningMessage += "Ücretli Hasta" + "\r\n";

                    if (episodeAction.Episode.Patient.Nationality != null && episodeAction.Episode.Patient.Nationality.Kodu == "SY")
                        warningMessage += "Suriyeli Hasta" + "\r\n";

                    if (episodeAction.SubEpisode.SGKSEP != null && String.IsNullOrEmpty(episodeAction.SubEpisode.SGKSEP.MedulaTakipNo))
                        warningMessage += "Provizyon Alınmamış Hasta" + "\r\n";

                    if (episodeAction.SubEpisode.InpatientStatus != null && episodeAction.SubEpisode.InpatientStatus == InpatientStatusEnum.Discharged)
                        warningMessage += "Taburcu Olmuş Hasta" + "\r\n";

                    if (episodeAction.SubEpisode.IsInvoicedCompletely)
                        warningMessage += "Faturası Kesilmiş Hasta" + "\r\n";
                }
            }
            if (!String.IsNullOrEmpty(warningMessage))
                InfoMessageService.Instance.ShowMessage(warningMessage);
            return warningMessage;
        }


        [HttpGet]
        public EReportIndexAuthorizations GetEReportIndexAuthorizations()
        {
            EReportIndexAuthorizations eReportIndexAuthorizations = new EReportIndexAuthorizations();

            eReportIndexAuthorizations.isAuthorizedForEAthlete = GetEAthleteReportIndexAuthorization();
            eReportIndexAuthorizations.isAuthorizedForEDogum = GetEDogumReportIndexAuthorization();
            eReportIndexAuthorizations.isAuthorizedForEDriver = GetEDriverReportIndexAuthorization();
            eReportIndexAuthorizations.isAuthorizedForEPsychotecnics = GetEPsychotecnicReportIndexAuthorization();
            eReportIndexAuthorizations.isAuthorizedForEDisabled = GetEDisabledReportIndexAuthorization();
            return eReportIndexAuthorizations;
        }

        public bool GetEDisabledReportIndexAuthorization()
        {
            bool authorization = false;
            TTUser currentUser = Common.CurrentUser;
            if (currentUser.HasRole(TTRoleNames.Tabip))
            {
                authorization = true;
            }

            return authorization;
        }

        public bool GetEDogumReportIndexAuthorization()
        {
            bool authorization = false;
            if (!Common.CurrentUser.HasRole(TTRoleNames.E_Dogum_Raporu_Listeleme))
                return authorization;

            ResUser currentResource = Common.CurrentResource;

            List<ResUser.GetUserSpecialityByCodeAndUser_Class> specialities = ResUser.GetUserSpecialityByCodeAndUser(currentResource.ObjectID, "3000").ToList();

            if (specialities != null && specialities.Count > 0)
            {
                authorization = true;
            }
            /*foreach (UserResource section in currentResource.UserResources)
            {
                if (section.Resource.ResourceSpecialities != null)
                {
                    foreach (ResourceSpecialityGrid speciality in section.Resource.ResourceSpecialities)
                    {
                        if (speciality.Speciality.Code == "3000")
                        {
                            break;
                        }
                    }
                }
                if (authorization == true)
                    break;
            }*/

            return authorization;
        }
        public static bool GetEPsychotecnicReportIndexAuthorization()
        {
            bool authorization = false;
            if (!Common.CurrentUser.HasRole(TTRoleNames.E_Psikoteknik_Raporu_Listeleme))
                return authorization;

            ResUser currentResource = Common.CurrentResource;

            foreach (UserResource section in currentResource.UserResources)
            {
                if (section.Resource.ResourceSpecialities != null)
                {
                    foreach (ResourceSpecialityGrid speciality in section.Resource.ResourceSpecialities)
                    {
                        if (speciality.Speciality.Code == "1400")
                        {
                            authorization = true;
                            break;
                        }
                    }
                }
                if (authorization == true)
                    break;
            }

            if (authorization == false)
            {
                if (currentResource.UserType == UserTypeEnum.Psychologist)
                    authorization = true;
            }

            return authorization;
        }
        public bool GetEAthleteReportIndexAuthorization()
        {
            bool authorization = false;
            if (!Common.CurrentUser.HasRole(TTRoleNames.E_Sporcu_Raporu_Listeleme))
                return authorization;
            else
                authorization = true;


            return authorization;
        }
        public bool GetEDriverReportIndexAuthorization()
        {
            bool authorization = false;
            if (!Common.CurrentUser.HasRole(TTRoleNames.E_Surucu_Raporu_Listeleme))
                return authorization;
            else
                authorization = true;


            return authorization;
        }
        [HttpGet]
        public bool GetEAthleteCreateReportAuthorization()
        {
            bool authorization = false;
            if (!Common.CurrentUser.HasRole(TTRoleNames.E_Sporcu_Raporu_Yazma))
                return authorization;
            else
                authorization = true;


            return authorization;
        }

        [HttpGet]
        public bool GetEDriverCreateReportAuthorization()
        {
            bool authorization = false;
            if (!Common.CurrentUser.HasRole(TTRoleNames.E_Surucu_Raporu_Yazma))
                return authorization;
            else
                authorization = true;


            return authorization;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Sporcu_Raporu_Listeleme)]
        public string OpenAthleteReportIndex()
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
                url = "http://xxxxxx.com/AthleteWeb/Athlete/SecIndex";
            }
            else if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/AthleteWeb/Athlete/HospitalDoctorIndex";
            }


            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı. Hata:" + result.Content);
            }
            return url;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Surucu_Raporu_Listeleme)]
        public string OpenEDriverReportIndex()
        {
            string url = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/driverweb/SpecialistDoctor/DoctorIndex";
            }


            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı.");
            }
            return url;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Psikoteknik_Raporu_Listeleme)]
        public string OpenEPsychotechnicsReportIndex()
        {
            string url = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/PsychotechnicsWeb/Psychiatrist/index";
            }


            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı.");
            }
            return url;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Dogum_Raporu_Listeleme)]
        public string OpenEDogumReportIndex()
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
                url = "http://xxxxxx.com/DogumWeb/Dogum/SecIndex";
            }
            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/DogumWeb/Dogum/DoctorIndex";
            }
            if (user.HasRole(TTRoleNames.Bastabip))
            {
                role = "417A9319-6430-490C";
                url = "http://xxxxxx.com/DogumWeb/Dogum/HeadDoc";
            }
            if (role == "")
            {
                role = "7AE271CC-5C57-4A77";    //HBYS
                url = "http://xxxxxx.com/DogumWeb/Dogum/Index";
            }
            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı.");
            }
            return url;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Sporcu_Raporu_Yazma)]
        public string OpenAthleteCreateReport()
        {
            string url = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;

            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/AthleteWeb/Athlete/CreateReportHospital";
            }
            else
            {
                throw new Exception("E_Sprocu Raporu Yazma yetkiniz bulunmamaktadır!");
            }

            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı. Hata:" + result.Content);
            }
            return url;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Surucu_Raporu_Yazma)]
        public string OpenDriverCreateReport()
        {
            string url = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;

            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/driverweb/SpecialistDoctor/CreateReport";
            }
            else
            {
                throw new Exception("E-Sürücü Raporu Yazma yetkiniz bulunmamaktadır!");
            }

            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı.");
            }
            return url;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Psikoteknik_Raporu_Yazma)]
        public string OpenPsychotecnicsCreateReport()
        {
            string url = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;

            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/PsychotechnicsWeb/Psychiatrist/createreport";
            }
            else
            {
                throw new Exception("E-Psikoteknik Raporu Yazma yetkiniz bulunmamaktadır!");
            }

            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı.");
            }
            return url;
        }

        #region YATAN HASTA DİŞ KABULÜ

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public List<ResPoliclinic> GetDentistResource()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ResPoliclinic.GetDentalPoliclinic(objectContext).ToList<ResPoliclinic>();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public List<ResUser.SpecialistDoctorListNQL_Class> GetDentist(string ResourceID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ResUser.SpecialistDoctorListNQL(" AND THIS.USERRESOURCES.RESOURCE='" + ResourceID + "' AND ISACTIVE = 1").ToList<ResUser.SpecialistDoctorListNQL_Class>();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public bool CreateDentalExamFromInpatient(string ResourceID, string DoctorID, string MasterActionID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                new DentalExamination(objectContext, new Guid(MasterActionID.Replace("'", "")), new Guid(ResourceID.Replace("'", "")), new Guid(DoctorID.Replace("'", "")));
                objectContext.Save();
                return true;
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public void CreateHCFromInpatient(HealthCommittee.InpatientHC_Class inpatientHC_Class)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid? selectedEpisodeActionObjectID = inpatientHC_Class.episodeActionObjectID;
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);

                if (selectedEpisodeActionObjectID.HasValue)
                {
                    if (episodeAction is InPatientPhysicianApplication)
                        episodeAction = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                    else if (episodeAction is NursingApplication)
                        episodeAction = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
                    else if (!(episodeAction is InPatientTreatmentClinicApplication))
                        throw new Exception("blabla");
                }

                //todo set SEP
                HealthCommittee healthCommittee = new HealthCommittee(objectContext, (InPatientTreatmentClinicApplication)episodeAction, inpatientHC_Class);

                //new DentalExamination(objectContext, new Guid(MasterActionID.Replace("'", "")), new Guid(ResourceID.Replace("'", "")), new Guid(DoctorID.Replace("'", "")));



                //Yatan E-Durum bildirir kurul entegrasyon
                var eStatusNotfReportObj = objectContext.LocalQuery<EStatusNotRepCommitteeObj>().ToList().FirstOrDefault();

                string entegrasyonAktif = TTObjectClasses.SystemParameter.GetParameterValue("EDURUMBILDIRIRKURULENTAKTIF", "FALSE");
                if (entegrasyonAktif == "TRUE" && eStatusNotfReportObj != null && healthCommittee.HCRequestReason?.ReasonForExamination?.IntegratedReporting == true)
                {
                    EDurumBildirirKurulServiceController.CreateEDurumBildirirKurulApplication(eStatusNotfReportObj, objectContext, healthCommittee);
                }
                objectContext.Save();
            }
        }

        #endregion

        #region SAĞLIK KURULU

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public HealthCommitteandReqReason GetHealthCommitteandReqReason(string episodeActionId)
        {
            HealthCommitteandReqReason healthCommitteandReqReason = new HealthCommitteandReqReason();

            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(episodeActionId));

                if (episodeAction is InPatientPhysicianApplication && ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp != null)
                {
                    List<HealthCommittee> healtCommittees = HealthCommittee.GetByWLFilterExpression(objectContext, " AND MasterAction='" + ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp.ObjectID + "'").ToList<HealthCommittee>();

                    foreach (HealthCommittee healthCommittee in healtCommittees)
                    {
                        ShortHcInfo shortHc = new ShortHcInfo();

                        shortHc.HCReportName = healthCommittee.HCRequestReason.ReasonName + " - " + healthCommittee.RequestDate?.ToString("dd.MM.yyyy");
                        shortHc.ObjectID = healthCommittee.ObjectID;

                        healthCommitteandReqReason.shortHealthCommittees.Add(shortHc);
                    }
                }

                healthCommitteandReqReason.hCRequestReasons = HCRequestReason.GetHCRequestReason(objectContext).Where(z => z.IsActive != false).ToList<HCRequestReason>();

                return healthCommitteandReqReason;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public OldHealthCommitte GetOldHealthCommitteByID(string hcID)
        {
            OldHealthCommitte oldHealthCommitte = new OldHealthCommitte();

            oldHealthCommitte.HospitalsUnits = new List<HCHospitalUnit>();

            using (TTObjectContext context = new TTObjectContext(false))
            {
                HealthCommittee healthCommittee = context.GetObject<HealthCommittee>(new Guid(hcID));

                oldHealthCommitte.ObjectID = healthCommittee.ObjectID;
                oldHealthCommitte.ReasonForExamination = healthCommittee.HCRequestReason.ReasonForExamination;
                oldHealthCommitte.HCReasonID = healthCommittee.HCRequestReason.ObjectID.ToString();
                oldHealthCommitte.HCStateID = healthCommittee.CurrentStateDefID.Value;

                if (healthCommittee.WhoPays.HasValue)
                    oldHealthCommitte.HCModeOfPayment = healthCommittee.WhoPays.Value;

                foreach (var hospitalUnit in healthCommittee.HospitalsUnits)
                {
                    HCHospitalUnit hcHospitalUnit = new HCHospitalUnit();
                    hcHospitalUnit.HospitalsUnit = null;
                    hcHospitalUnit.Policlinic = (ResPoliclinic)hospitalUnit.Unit;
                    hcHospitalUnit.ProcedureDoctor = hospitalUnit.Doctor;
                    hcHospitalUnit.Speciality = hospitalUnit.Speciality;
                    oldHealthCommitte.HospitalsUnits.Add(hcHospitalUnit);
                }

                foreach (var examination in healthCommittee.LinkedActions)
                {
                    if (examination is PatientExamination)
                    {
                        if (((PatientExamination)examination).HCExaminationComponent.EDisabledReport != null)
                        {
                            oldHealthCommitte.EDisabledReport = ((PatientExamination)examination).HCExaminationComponent.EDisabledReport;
                            break;
                        }
                        else if (((PatientExamination)examination).HCExaminationComponent.EStatusNotRepCommitteeObj != null)
                        {
                            oldHealthCommitte.eStatusNotfReportObj = ((PatientExamination)examination).HCExaminationComponent.EStatusNotRepCommitteeObj;
                            break;
                        }

                    }
                }


                context.FullPartialllyLoadedObjects();
            }

            return oldHealthCommitte;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public void UpdateHCFromInpatient(InpatientHC_Class inpatientHC_Class)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                //objectContext.AddToRawObjectList(inpatientHC_Class.resourcesToBeReferredList);
                //objectContext.ProcessRawObjects();
                EDisabledReport eDisabledReportObj = null;
                EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj = null;
                if (inpatientHC_Class.eDisabledReport != null)
                {
                    eDisabledReportObj = inpatientHC_Class.eDisabledReport;
                    objectContext.AddObject(eDisabledReportObj);
                    //objectContext.AddToRawObjectList(inpatientHC_Class.eDisabledReport);
                }
                if (inpatientHC_Class.eStatusNotfReportObj != null)
                {
                    eStatusNotRepCommitteeObj = inpatientHC_Class.eStatusNotfReportObj;
                    objectContext.AddObject(eStatusNotRepCommitteeObj);
                    //objectContext.AddToRawObjectList(inpatientHC_Class.eDisabledReport);
                }
                HealthCommittee healthCommittee = objectContext.GetObject<HealthCommittee>(inpatientHC_Class.episodeActionObjectID);
                objectContext.FullPartialllyLoadedObjects();

                List<EpisodeAction> arrList = GetLinkedEpisodeActionList(healthCommittee);

                BaseHealthCommittee_HospitalsUnitsGrid[] newList = new BaseHealthCommittee_HospitalsUnitsGrid[healthCommittee.HospitalsUnits.Count];
                healthCommittee.HospitalsUnits.CopyTo(newList, 0);

                foreach (BaseHealthCommittee_HospitalsUnitsGrid pAResourcesToBeReferred in newList)
                {

                    var _hUnit = inpatientHC_Class.resourcesToBeReferredList.Where(z => z["RESOURCE"].ToString() == pAResourcesToBeReferred.Unit.ObjectID.ToString()
                        && z["PROCEDUREDOCTORTOBEREFERRED"].ToString() == pAResourcesToBeReferred.Doctor.ObjectID.ToString()).FirstOrDefault();

                    if (_hUnit == null)
                    {
                        EpisodeAction _deletedHCExamination = arrList.Where(z => z.MasterResource.ObjectID == pAResourcesToBeReferred.Unit.ObjectID
                        && z.ProcedureDoctor.ObjectID == pAResourcesToBeReferred.Doctor.ObjectID).FirstOrDefault();

                        if (_deletedHCExamination is PatientExamination)
                        {
                            if (_deletedHCExamination.CurrentStateDefID != PatientExamination.States.Examination)
                                throw new TTUtils.TTException("Muayeneye başlanmış bir polikliniğe ait veriyi silemezsiniz");
                            else
                            {
                                _deletedHCExamination.CurrentStateDefID = PatientExamination.States.Cancelled;

                                BaseHealthCommittee_HospitalsUnitsGrid yy = healthCommittee.HospitalsUnits.Where(x => x.ObjectID == pAResourcesToBeReferred.ObjectID).FirstOrDefault();

                                yy.Explanation = "Silinen ID=" + pAResourcesToBeReferred.BaseHealthCommittee.ObjectID + " Silen=" + Common.CurrentUser.FullName;
                                yy.BaseHealthCommittee = null;
                            }
                        }

                    }


                }

                foreach (PatientAdmissionResourcesToBeReferred pAResourcesToBeReferred in inpatientHC_Class.resourcesToBeReferredList)
                {

                    var _hUnit = healthCommittee.HospitalsUnits.Where(z => z.Unit.ObjectID == (Guid)pAResourcesToBeReferred["RESOURCE"]
                        && z.Doctor.ObjectID == (Guid)pAResourcesToBeReferred["PROCEDUREDOCTORTOBEREFERRED"]).FirstOrDefault();

                    if (_hUnit == null)
                    {

                        BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnitsGrid = new BaseHealthCommittee_HospitalsUnitsGrid(healthCommittee.ObjectContext);
                        hospitalsUnitsGrid.Unit = objectContext.GetObject<ResSection>((Guid)pAResourcesToBeReferred["RESOURCE"]);
                        hospitalsUnitsGrid.Doctor = objectContext.GetObject<ResUser>((Guid)pAResourcesToBeReferred["PROCEDUREDOCTORTOBEREFERRED"]);

                        if (pAResourcesToBeReferred["SPECIALITY"] != null)
                            hospitalsUnitsGrid.Speciality = objectContext.GetObject<SpecialityDefinition>((Guid)pAResourcesToBeReferred["SPECIALITY"]);

                        healthCommittee.HospitalsUnits.Add(hospitalsUnitsGrid);

                        EpisodeAction.ForkHealthCommitteeExamination((HospitalsUnitsGrid)hospitalsUnitsGrid, healthCommittee, eDisabledReportObj, eStatusNotRepCommitteeObj);
                    }


                }

                objectContext.Save();

            }
        }

        public List<EpisodeAction> GetLinkedEpisodeActionList(EpisodeAction episodeActionParam)
        {

            List<EpisodeAction> actionList = new List<EpisodeAction>();

            foreach (EpisodeAction episodeAction in episodeActionParam.Episode.EpisodeActions)
            {

                if (episodeAction.MasterAction != null)
                {
                    if (episodeAction.MasterAction.ID == episodeActionParam.ID)
                    {
                        actionList.Add(episodeAction);
                    }
                }
            }
            return actionList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public InpatientHC_Class GetOldHealthCommitteByID_eski(string hcID)
        {

            HealthCommittee.InpatientHC_Class inpatientHC_Class = new InpatientHC_Class();
            inpatientHC_Class.resourcesToBeReferredList = new List<PatientAdmissionResourcesToBeReferred>();

            using (var objectContext = new TTObjectContext(false))
            {
                HealthCommittee healthCommittee = objectContext.GetObject<HealthCommittee>(new Guid(hcID));
                objectContext.FullPartialllyLoadedObjects();

                if (healthCommittee != null)
                {
                    inpatientHC_Class = new InpatientHC_Class();
                    inpatientHC_Class._hcReasonID = healthCommittee.HCRequestReason.ObjectID.ToString();
                    inpatientHC_Class.reasonForExaminationDefinition = healthCommittee.HCRequestReason.ReasonForExamination;

                    if (healthCommittee.WhoPays.HasValue)
                        inpatientHC_Class.HCModeOfPayment = healthCommittee.WhoPays.Value;

                    if (healthCommittee.HospitalsUnits != null && healthCommittee.HospitalsUnits.Count > 0)
                    {
                        foreach (var hospitalsUnitsDef in healthCommittee.HospitalsUnits)
                        {
                            PatientAdmissionResourcesToBeReferred patientAdmissionResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred(objectContext);
                            patientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferred = hospitalsUnitsDef.Doctor;
                            patientAdmissionResourcesToBeReferred.Resource = hospitalsUnitsDef.Unit;
                            patientAdmissionResourcesToBeReferred.Speciality = hospitalsUnitsDef.Speciality;

                            inpatientHC_Class.resourcesToBeReferredList.Add(patientAdmissionResourcesToBeReferred);
                        }
                    }

                }


                return inpatientHC_Class;
            }
        }

        #endregion

        #region TELETIP
        /// <summary>
        /// Teletıp üzerinden hsataya daha önce istenmiş MR ve BT isteklerini sorgulamaya yarayan method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<TeletipResult_Output> ControlTeletip(string EpisodeID, string SUTCode, string ProcedureDoctor)
        {
            string url = string.Empty;
            Episode episode = null;
            string UniqueNo, IdentityNumber = string.Empty;
            ResUser resUser = null;
            int[] doctorType = new int[3] { 0, 2, 17 };

            List<TeletipResult_Output> teletipResult_OutputList = new List<TeletipResult_Output>();

            #region LogInfo
            var userIDKey = HttpContext.GetUserIDKey();
            var workstationIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            string requestPath = HttpContext.Request.Path;
            string description = string.Empty;
            #endregion

            using (var objectContext = new TTObjectContext(false))
            {
                episode = objectContext.GetObject<Episode>(new Guid(EpisodeID));
                UniqueNo = episode.Patient.UniqueRefNo != null ? episode.Patient.UniqueRefNo.ToString() : "";

                resUser = objectContext.GetObject<ResUser>(new Guid(ProcedureDoctor));
                IdentityNumber = doctorType.Contains((int)Common.CurrentResource.UserType) ? Common.CurrentResource.UniqueNo : resUser.UniqueNo.ToString();
            }
            try
            {
                if (UniqueNo != "")
                {
                    string MedulaTesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");

                    description = EpisodeID + " Episode ID'li ve " + UniqueNo + " Kimlik Numaralı Hasta İçin " + SUTCode + " lu işleme ait mükerrerlik sorgulaması başladı.\n";

                    url = "http://xxxxxx.com/Common.WebApi/api/Integration/GetPreviousStudies?parameter=";
                    string accessToken = getTokenForTeletip();

                    Teletip_Input teletip_Input = new Teletip_Input();
                    teletip_Input.MedulaInstitutionId = MedulaTesisKodu;// "11069941";
                    teletip_Input.PatientCitizenId = UniqueNo;// 10000000000;
                    teletip_Input.SutCode = SUTCode;// "803570";
                    teletip_Input.DoctorCitizenId = IdentityNumber;//10000000000;

                    //teletip_Input.MedulaInstitutionId = "11060019";
                    //teletip_Input.PatientCitizenId = "10000000000";// 10000000000;
                    //teletip_Input.SutCode = "803910";// "803570";
                    //teletip_Input.DoctorCitizenId = "10000000000";//10000000000;

                    string ss = JsonConvert.SerializeObject(teletip_Input);

                    var uri = new Uri("http://xxxxxx.com/Common.WebApi/api/Integration/GetPreviousStudies?parameter=" + ss);


                    var client = new RestClient(uri);


                    var request = new RestSharp.RestRequest();
                    request.Method = Method.GET;
                    var bearerToken = $"Bearer {accessToken}";
                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);

                    var result = client.Execute(request);
                    if (result.StatusCode.ToString() == "OK")
                    {
                        var token = (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(result.Content));//[0] as Newtonsoft.Json.Linq.JObject)["OrderId"];

                        foreach (Newtonsoft.Json.Linq.JObject item in token)
                        {
                            TeletipResult_Output teletipResult_Output = new TeletipResult_Output();
                            teletipResult_Output.OrderId = (string)item["OrderId"];
                            teletipResult_Output.InstitutionName = (string)item["InstitutionName"];
                            teletipResult_Output.SKRS = (string)item["SKRS"];
                            teletipResult_Output.AccessionNumber = (string)item["AccessionNumber"];
                            teletipResult_Output.ScheduleDate = item["ScheduleDate"] != null ? (string)item["ScheduleDate"] : "";
                            teletipResult_Output.PerformedDate = item["PerformedDate"] != null ? (string)item["PerformedDate"] : "";
                            teletipResult_Output.RequestedProcedureDescription = (string)item["RequestedProcedureDescription"];
                            teletipResult_Output.IsStudyExist = (bool)item["IsStudyExist"];
                            teletipResult_Output.IsReportExist = (bool)item["IsReportExist"];

                            teletipResult_OutputList.Add(teletipResult_Output);

                        }

                        description += " mükerrerlik sorgulaması başarı ile tamamlandı. Gelen Veri Sayısı:" + token.Count;

                        InsertServiceLogInfo(requestPath, result.StatusCode.ToString(), workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                        //TeletipResult_Output teletipResult_Output = new TeletipResult_Output();
                        //teletipResult_Output.OrderId = "2";
                        //teletipResult_Output.InstitutionName = "ismail";
                        //teletipResult_Output.SKRS = "10157";
                        //teletipResult_Output.AccessionNumber = "123";
                        //teletipResult_Output.ScheduleDate = DateTime.Now.AddDays(-2);
                        //teletipResult_Output.PerformedDate = DateTime.Now.AddDays(2);
                        //teletipResult_Output.RequestedProcedureDescription = "deneme yapıos";
                        //teletipResult_Output.IsStudyExist = true;
                        //teletipResult_Output.IsReportExist = false;

                        //teletipResult_OutputList.Add(teletipResult_Output);


                    }
                    else
                    {
                        string _error = (string.IsNullOrEmpty(result.Content) ? "" : (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)).Value<string>("Message")) + result.ErrorMessage;

                        description += " Mükerrerlik sorgusu sırasında bir hata oluştu. Hata Detayı: " + _error;

                        InsertServiceLogInfo(requestPath, result.StatusCode.ToString(), workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                        throw new Exception("Sorgulama yapılırken bir hata ile karşılaşıldı. Hata:" + _error);
                    }

                }
                else
                {
                    description = EpisodeID + " Episode ID'li hastaya ait kimlik numarası alınamadığı için " + SUTCode + " lu işleme ait mükerrerlik sorgulaması yapılamadı";
                    InsertServiceLogInfo(requestPath, "error", workstationIpAddress, description, ServiceLogTypeEnum.Teletip);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().StartsWith("Sorgulama"))
                    throw new Exception(ex.Message.ToString());
                else
                {
                    InsertServiceLogInfo(requestPath, "error", workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                    throw new Exception("Mükerrerlik Servislerine Ulaşılamadı. Hata:" + ex.Message.ToString());
                }
            }
            return teletipResult_OutputList;

        }

        public void InsertServiceLogInfo(string requestPath, string statusCode, string workstationIp, string description, ServiceLogTypeEnum logType)
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    ServiceLogInfo serviceLog = new ServiceLogInfo(objectContext);

                    serviceLog.LOGID = Guid.NewGuid();
                    serviceLog.RequestPath = requestPath;
                    serviceLog.StatusCode = statusCode;
                    serviceLog.CallDate = DateTime.Now;
                    serviceLog.WorkstationIp = workstationIp;
                    serviceLog.Description = description.Length >= 2000 ? description.Substring(0, 1999) : description;
                    serviceLog.UserID = Common.CurrentResource.ObjectID;
                    serviceLog.LogType = logType;
                    objectContext.Save();
                }
            }
            catch (Exception ex)
            {
                //bişey yapma
            }


        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string OpenTeletipReport(string OrderID, string PatientCitizenId)
        {
            #region LogInfo
            var userIDKey = HttpContext.GetUserIDKey();
            var workstationIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            string requestPath = HttpContext.Request.Path;
            string description = string.Empty;
            #endregion

            string accessToken = getTokenForTeletip();

            Paramm aa = new Paramm();
            aa.OrderID = OrderID;
            string ss = JsonConvert.SerializeObject(aa);

            var uri = new Uri("http://xxxxxx.com/Common.WebApi/api/Integration/GetReport?parameter=" + ss);

            var request = new RestSharp.RestRequest();
            request.Method = Method.GET;
            var bearerToken = $"Bearer {accessToken}";
            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);

            var client = new RestClient(uri);

            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var tokenResponse = JsonConvert.DeserializeObject(result.Content) as Newtonsoft.Json.Linq.JObject;

                description = PatientCitizenId + " hastası için " + OrderID + " order id'li rapor görüntülendi";
                InsertServiceLogInfo(requestPath, "", workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                return (string)tokenResponse.Property("Report").Value;
            }
            else
            {
                description = PatientCitizenId + " hastası için rapor görüntüle butonuna basıldı. " + OrderID;
                InsertServiceLogInfo(requestPath, "", workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                return "";
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string OpenTeletipImaj(TeletipImaj_Input teletipImaj_Input)
        {
            TeletipImaj_Input _output = new TeletipImaj_Input();

            #region LogInfo
            var userIDKey = HttpContext.GetUserIDKey();
            var workstationIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            string requestPath = HttpContext.Request.Path;
            string description = string.Empty;
            #endregion

            //teletipImaj_Input.DoctorCitizenId = "10000000000";
            //teletipImaj_Input.PatientCitizenId = "10000000000";

            string IdentityNumber = Common.CurrentResource.UniqueNo;

            _output.AccessToken = getTokenForTeletip();
            _output.DoctorCitizenId = Uri.EscapeDataString(EncryptStringToBase64_Aes(IdentityNumber));
            _output.AccessionNumber = Uri.EscapeDataString(EncryptStringToBase64_Aes(teletipImaj_Input.AccessionNumber));
            _output.PatientCitizenId = Uri.EscapeDataString(EncryptStringToBase64_Aes(teletipImaj_Input.PatientCitizenId));

            string _url = "http://xxxxxx.com/home/newguidservice?requestedCitizenId=" + _output.PatientCitizenId + "&accessionNo=" + _output.AccessionNumber +
                "&requestingCitizenId=" + _output.DoctorCitizenId + "&accessToken=" + _output.AccessToken;

            description = teletipImaj_Input.PatientCitizenId + " hastası için " + teletipImaj_Input.AccessionNumber + " accession numarasına ait görüntü url oluşturuldu. Url" + _url;

            InsertServiceLogInfo(requestPath, "", workstationIpAddress, description, ServiceLogTypeEnum.Teletip);
            return _url;

        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool? GetPreviousStudiesSearchDetail(string EpisodeID, string SUTCode)
        {
            string url = string.Empty;
            Episode episode = null;
            string UniqueNo, IdentityNumber = string.Empty;

            GetPreviousStudiesForSutCodeList_OutPut_Class teletipResult_Output = new GetPreviousStudiesForSutCodeList_OutPut_Class();

            #region LogInfo
            var userIDKey = HttpContext.GetUserIDKey();
            var workstationIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            string requestPath = HttpContext.Request.Path;
            string description = string.Empty;
            #endregion

            using (var objectContext = new TTObjectContext(false))
            {
                episode = objectContext.GetObject<Episode>(new Guid(EpisodeID));
                UniqueNo = episode.Patient.UniqueRefNo != null ? episode.Patient.UniqueRefNo.ToString() : "";

            }
            try
            {
                if (UniqueNo != "")
                {
                    string MedulaTesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");

                    description = EpisodeID + " Episode ID'li ve " + UniqueNo + " Kimlik Numaralı Hasta İçin " + SUTCode + " lu işleme ait rapor açılmış mı sorgulaması başladı.\n";

                    string accessToken = getTokenForTeletip();

                    GetPreviousStudiesForSutCodeList_Class parameter = new GetPreviousStudiesForSutCodeList_Class();
                    parameter.MedulaInstitutionId = Convert.ToInt32(MedulaTesisKodu);
                    parameter.PatientCitizenId = UniqueNo;
                    parameter.SutCodeList = new List<string>() { SUTCode };

                    string ss = JsonConvert.SerializeObject(parameter);

                    Uri uri = new Uri("http://xxxxxx.com/Common.WebApi/api/Integration/GetPreviousStudiesSearchDetail?parameter=" + ss);


                    var client = new RestClient(uri);


                    var request = new RestSharp.RestRequest();
                    request.Method = Method.GET;
                    var bearerToken = $"Bearer {accessToken}";
                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);

                    var result = client.Execute(request);

                    if (result.StatusCode.ToString() == "OK")
                    {
                        var token = (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(result.Content));//[0] as Newtonsoft.Json.Linq.JObject)["OrderId"];

                        foreach (Newtonsoft.Json.Linq.JObject item in token)
                        {
                            teletipResult_Output.SutCode = (string)item["SutCode"];
                            teletipResult_Output.Result = (bool)item["Result"];

                        }

                        description += " rapor açılmış mı sorgulaması başarı ile tamamlandı. Sonuç:" + teletipResult_Output.Result;

                        InsertServiceLogInfo(requestPath, result.StatusCode.ToString(), workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                    }
                    else
                    {
                        string _error = (string.IsNullOrEmpty(result.Content) ? "" : (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)).Value<string>("Message")) + result.ErrorMessage;

                        description += " rapor açılmış mı sorgusu sırasında bir hata oluştu. Hata Detayı: " + _error;

                        InsertServiceLogInfo(requestPath, result.StatusCode.ToString(), workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                        throw new Exception("rapor açılmış mı yapılırken bir hata ile karşılaşıldı. Hata:" + _error);
                    }

                }
                else
                {
                    description = EpisodeID + " Episode ID'li hastaya ait kimlik numarası alınamadığı için " + SUTCode + " lu işleme ait mükerrerlik sorgulaması yapılamadı";
                    InsertServiceLogInfo(requestPath, "error", workstationIpAddress, description, ServiceLogTypeEnum.Teletip);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().StartsWith("Sorgulama"))
                    throw new Exception(ex.Message.ToString());
                else
                {
                    InsertServiceLogInfo(requestPath, "error", workstationIpAddress, description, ServiceLogTypeEnum.Teletip);

                    throw new Exception("rapor açılmış mı Servislerine Ulaşılamadı. Hata:" + ex.Message.ToString());
                }
            }
            return teletipResult_Output.Result;

        }
        public string getTokenForTeletip()
        {

            var clientId = "HBYSPACSViewerClient";
            var clientSecret = "HbPatT!180430#KnYLm";

            var requestUri = $"/api/authenticate";
            string identityServerBaseUri = "http://xxxxxx.com";
            var client = new RestClient($"{identityServerBaseUri}/connect/token");
            client.UserAgent = " ";
            var request = new RestRequest();
            request.Method = Method.POST;
            request.AddParameter("grant_type", "password", ParameterType.GetOrPost);
            request.AddParameter("USERNAME", "XXXXXX", ParameterType.GetOrPost);
            //request.AddParameter("PASSWORD", "XXXXXX", ParameterType.GetOrPost);
            request.AddParameter("PASSWORD", "XXXXXX", ParameterType.GetOrPost);
            //request.AddParameter("scope", "openid profile custom.profile Common.WebApi", ParameterType.GetOrPost);
            request.AddParameter("scope", "openid profile custom.profile AuthorizationWebApi Common.WebApi GYM.Authentication.WebApiCore", ParameterType.GetOrPost);
            var basicAuthorizationHeaderContent = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            request.AddParameter("Authorization", string.Format($"Basic {basicAuthorizationHeaderContent}"), ParameterType.HttpHeader);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var tokenResponse = JsonConvert.DeserializeObject(response.Content) as Newtonsoft.Json.Linq.JObject;
                return (string)tokenResponse.Property("access_token").Value;
            }
            else
                return "";

        }

        private string EncryptStringToBase64_Aes(string plainText)
        {
            string myKey = "265266556A586D3272357538322F413F4428472B4B6250612668566A5970337336763979244226452948404D145136546A576E5A7134743777217B25432A462D";
            byte[] passwordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(myKey));
            byte[] iv = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(myKey));
            byte[] encrypted;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = passwordBytes;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            string sonuc = Convert.ToBase64String(encrypted);
            return sonuc;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<TeletipResult_Output> GetTeletipHistoryWithSutCode(TeletipInput_DVO inputDvo)
        {
            string url = string.Empty;

            string UniqueNo, IdentityNumber = string.Empty;
            int[] doctorType = new int[3] { 0, 2, 17 };

            List<TeletipResult_Output> teletipResult_OutputList = new List<TeletipResult_Output>();


            using (var objectContext = new TTObjectContext(false))
            {
                IdentityNumber = doctorType.Contains((int)Common.CurrentResource.UserType) ? Common.CurrentResource.UniqueNo : "";
            }
            try
            {
                if (string.IsNullOrEmpty(IdentityNumber))
                {
                    throw new Exception("Bu servisi sadece doktor rolune sahip kullanıcılar kullanabilmektedir.");
                }

                if (inputDvo.PatientCitizenId != "")
                {
                    string MedulaTesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");

                    string accessToken = getTokenForTeletip();

                    TeletipInput_DVO teletip_Input = new TeletipInput_DVO();
                    teletip_Input.MedulaInstitutionId = MedulaTesisKodu;// "11069941";
                    teletip_Input.PatientCitizenId = inputDvo.PatientCitizenId;// 10000000000;
                    teletip_Input.SUTCodeList = inputDvo.SUTCodeList;// "803570";
                    teletip_Input.DoctorCitizenId = IdentityNumber;//10000000000;

                    //teletip_Input.MedulaInstitutionId = "11060019";
                    //teletip_Input.PatientCitizenId = "10000000000";// 10000000000;
                    //teletip_Input.SutCode = "803910";// "803570";
                    //teletip_Input.DoctorCitizenId = "10000000000";//10000000000;

                    string ss = JsonConvert.SerializeObject(teletip_Input);

                    var uri = new Uri("http://xxxxxx.com/Common.WebApi/api/Integration/GetPreviousStudiesForSutCodeList?parameter=" + ss);


                    var client = new RestClient(uri);


                    var request = new RestSharp.RestRequest();
                    request.Method = Method.GET;
                    var bearerToken = $"Bearer {accessToken}";
                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);

                    var result = client.Execute(request);
                    if (result.StatusCode.ToString() == "OK")
                    {
                        var token = (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(result.Content));//[0] as Newtonsoft.Json.Linq.JObject)["OrderId"];

                        foreach (Newtonsoft.Json.Linq.JObject item in token)
                        {
                            TeletipResult_Output teletipResult_Output = new TeletipResult_Output();
                            teletipResult_Output.OrderId = (string)item["OrderId"];
                            teletipResult_Output.InstitutionName = (string)item["InstitutionName"];
                            teletipResult_Output.SKRS = (string)item["SKRS"];
                            teletipResult_Output.AccessionNumber = (string)item["AccessionNumber"];
                            teletipResult_Output.ScheduleDate = item["ScheduleDate"] != null ? (string)item["ScheduleDate"] : "";
                            teletipResult_Output.PerformedDate = item["PerformedDate"] != null ? (string)item["PerformedDate"] : "";
                            teletipResult_Output.RequestedProcedureDescription = (string)item["RequestedProcedureDescription"];
                            teletipResult_Output.IsStudyExist = (bool)item["IsStudyExist"];
                            teletipResult_Output.IsReportExist = (bool)item["IsReportExist"];

                            teletipResult_OutputList.Add(teletipResult_Output);

                        }

                        //TeletipResult_Output teletipResult_Output = new TeletipResult_Output();
                        //teletipResult_Output.OrderId = "2";
                        //teletipResult_Output.InstitutionName = "ismail";
                        //teletipResult_Output.SKRS = "10157";
                        //teletipResult_Output.AccessionNumber = "123";
                        //teletipResult_Output.ScheduleDate = DateTime.Now.AddDays(-2);
                        //teletipResult_Output.PerformedDate = DateTime.Now.AddDays(2);
                        //teletipResult_Output.RequestedProcedureDescription = "deneme yapıos";
                        //teletipResult_Output.IsStudyExist = true;
                        //teletipResult_Output.IsReportExist = false;

                        //teletipResult_OutputList.Add(teletipResult_Output);


                    }
                    else
                    {
                        string _error = (string.IsNullOrEmpty(result.Content) ? "" : (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)).Value<string>("Message")) + result.ErrorMessage;

                        throw new Exception("Sorgulama yapılırken bir hata ile karşılaşıldı. Hata:" + _error);
                    }

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().StartsWith("Sorgulama"))
                    throw new Exception(ex.Message.ToString());
                else
                {
                    throw new Exception("Mükerrerlik Servislerine Ulaşılamadı. Hata:" + ex.Message.ToString());
                }
            }
            return teletipResult_OutputList;

        }

        #endregion

        #region BOŞ YATAK RAPORU
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<ResClinic> GetActiveClinicsForReport()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var res = ResClinic.GetAllActiveClinics(objectContext).OrderBy(x => x.Name).ToList<ResClinic>();
                objectContext.FullPartialllyLoadedObjects();
                return res;
            }
        }
        #endregion

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ControlVitaminDResult ControlVitaminD(string EpisodeActionID, string ProcedureObjectDefID)
        {
            ControlVitaminDResult result = new ControlVitaminDResult();
            using (var objectContext = new TTObjectContext(true))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(EpisodeActionID));

                ProcedureDefinition procedureDefinition = (ProcedureDefinition)objectContext.GetObject(new Guid(ProcedureObjectDefID), "ProcedureDefinition");

                ResUser user = new ResUser();
                int[] doctorType = new int[3] { 0, 2, 17 };

                if (Common.CurrentResource.TakesPerformanceScore == true && doctorType.Contains((int)Common.CurrentResource.UserType))
                {
                    user = Common.CurrentResource;
                }
                else
                {
                    user = episodeAction.ProcedureDoctor;
                }

                string AuthorizedBranches = "";
                //Yetkili Branş kontrolü
                bool flag = false;
                if (procedureDefinition is LaboratoryTestDefinition && ((LaboratoryTestDefinition)procedureDefinition).Branchs != null && ((LaboratoryTestDefinition)procedureDefinition).Branchs.Count > 0)
                {

                    foreach (var item in user.ResourceSpecialities)
                    {
                        foreach (var item2 in ((LaboratoryTestDefinition)procedureDefinition).Branchs)
                        {
                            if (AuthorizedBranches == String.Empty)
                                AuthorizedBranches = item2.SpecialityDefiniton.SKRSKlinik.ADI;
                            else
                                AuthorizedBranches += "," + item2.SpecialityDefiniton.SKRSKlinik.ADI;

                            if (item.Speciality.SKRSKlinik != null && item.Speciality.SKRSKlinik.KODU == item2.SpecialityDefiniton.SKRSKlinik.KODU)
                            {

                                //branş izni var demektir
                                flag = true;
                                break;
                            }
                        }

                    }
                }
                else
                    flag = true;
                result.VitaminD_Response = VitaminDRepetitionQuery(episodeAction, procedureDefinition);
                if (!flag)
                {
                    //Branş yetkili değilse bile varsa mükerrerlik servisinden dönen sonucu gösterilecek
                    result.hasPermissionToRequest = false;
                    result.Alert = AuthorizedBranches + " uzmanlıkları tarafından istenebilen bir tetkiktir. Bu tetkiğin çalışılabilmesi için belirtilen uzmanlık dallarına konsültasyon hizmeti başlatabilirsiniz.";

                }
                else
                {
                    result.Alert = "";
                    if (result.VitaminD_Response.sonuc != null && result.VitaminD_Response.sonuc.tetkikSonuc != null && result.VitaminD_Response.sonuc.tetkikSonuc.Count > 0 && result.VitaminD_Response.sonuc.tetkikSonuc[0].sonucKodu == 0) //Sadece 0 dönenler ekleyebilecek
                        result.hasPermissionToRequest = true;
                    else
                        result.hasPermissionToRequest = false;
                }


            }

            return result;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public TetkikMukerrerOutput VitaminDRepetitionQuery(EpisodeAction episodeAction, ProcedureDefinition procedureDefinition)
        {

            #region LogInfo
            var userIDKey = HttpContext.GetUserIDKey();
            var workstationIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            string requestPath = HttpContext.Request.Path;
            string description = string.Empty;
            #endregion

            TetkikMukerrerOutput response = new TetkikMukerrerOutput();
            using (var objectContext = new TTObjectContext(true))
            {
                SpecialityDefinition Speciality;
                string resBrans = "";
                resBrans = episodeAction.GetBranchCodeForMedula();
                string KlinikKodu = "";
                if (resBrans != null)
                {
                    IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                    if (specialtyList.Count > 0)
                        Speciality = (SpecialityDefinition)specialtyList[0];
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                    if (Speciality.SKRSKlinik != null)
                        KlinikKodu = Speciality.SKRSKlinik.KODU;
                    else
                        throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");
                }


                string SutKodu = procedureDefinition.SUTCode;
                string HastaKimlikBilgisi = episodeAction.Episode.Patient.UniqueRefNo.ToString();
                string HekimKimlikBilgisi = "";


                int[] doctorType = new int[3] { 0, 2, 17 };

                if (Common.CurrentResource.TakesPerformanceScore == true && doctorType.Contains((int)Common.CurrentResource.UserType))
                {
                    HekimKimlikBilgisi = Common.CurrentResource.UniqueNo;
                }
                else
                {
                    HekimKimlikBilgisi = episodeAction.ProcedureDoctor.UniqueNo;
                }

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

                TetkikMukerrerInput input = new TetkikMukerrerInput();
                input.KlinikKodu = KlinikKodu;
                input.HastaKimlikBilgisi = HastaKimlikBilgisi;
                input.HekimKimlikBilgisi = HekimKimlikBilgisi;
                List<string> sutKoduList = new List<string>();
                sutKoduList.Add(SutKodu);
                input.SutKodu = new string[sutKoduList.Count];
                input.SutKodu = sutKoduList.ToArray();

                description = episodeAction.SubEpisode.ObjectID.ToString() + " SubepisodeID'li hasta için mükerrerlik sorgulaması başladı.(KlinikKodu:" + KlinikKodu + " SutKodu:" + SutKodu + " HastaKimlikBilgisi:" + HastaKimlikBilgisi + " HekimKimlikBilgisi:" + HekimKimlikBilgisi + ")\n";



                string input_s = JsonConvert.SerializeObject(input);

                HttpContent httpContent = new StringContent(input_s, Encoding.UTF8, "application/json");

                HttpResponseMessage message = client.PostAsync("http://xxxxxx.com/api/TetkikSonuc/TetkikMukerrerSorgulama", httpContent).GetAwaiter().GetResult();

                if (message.IsSuccessStatusCode)
                {
                    string result = message.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<TetkikMukerrerOutput>(result);
                    //sonucKodu = 0 ->SGK bildirimi yapılacak. 
                    //sonucKodu = 1 ->İlgili Sut Kodu için mükerrer tetkik kontrolü yapılamaz. 
                    //sonucKodu = 2 ->Son 90 gün içerisinde yapılan tetkik bulunmaktadır, bu sebeple SGK bildirimi yapılmayacaktır.
                    //sonucKodu = 3 ->İlgili hekim branşına ait tetkikler için SGK bildirimi yapılmayacaktır.
                    description += "Mükerrerlik sorgusu tamamlandı. Cevap:" + result;
                    InsertServiceLogInfo(requestPath, "success", workstationIpAddress, description, ServiceLogTypeEnum.Dvit);

                }
                else
                {
                    description += "Mükerrerlik sorgusu tamamlanamadı.";
                    InsertServiceLogInfo(requestPath, "error", workstationIpAddress, description, ServiceLogTypeEnum.Dvit);
                }

                return response;

            }
        }

        #region HASTA TAKİP METODLARI
        [HttpPost]
        public bool TrackPatientByType(FollowingPatients input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input != null)
                {
                    FollowingPatients followingPatients = new FollowingPatients(objectContext);

                    followingPatients.CurrentStateDefID = FollowingPatients.States.OnTracking;
                    followingPatients.Follower = TTUser.CurrentUser.UserObject.ObjectID;
                    followingPatients.FollowingType = input.FollowingType;
                    followingPatients.Subepisode = input.Subepisode;
                    followingPatients.Paitent = input.Paitent;
                    followingPatients.StartDate = Common.RecTime();

                    try
                    {
                        objectContext.Save();
                    }
                    catch (Exception)
                    {

                        return false;
                    }

                }

                return true;
            }
        }

        public void FindTrackingFollowers(Guid patient, Guid subepisode, bool sendSMS, bool sendNotification, string smsMessage, string NotificationMessage, SMSTypeEnum type)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<string> followerlist = new List<string>();
                string _filter = " WHERE PAITENT = '" + patient + "' AND CURRENTSTATEDEFID='" + FollowingPatients.States.OnTracking + "'";
                List<FollowingPatients> patients = FollowingPatients.GetTrackingPatientsByFilter(objectContext, _filter).ToList();

                List<FollowingPatients> kabulBazli = patients.Where(x => x.Subepisode == subepisode && x.FollowingType == PatientFollowingTypeEnum.BySubEpisode).ToList();
                List<FollowingPatients> hastaBazli = patients.Where(x => x.Paitent == patient && x.FollowingType == PatientFollowingTypeEnum.ByPatientID).ToList();

                if (sendSMS)
                {
                    foreach (var item in kabulBazli)
                    {
                        SendSMSForTrackingPaitent(item.Follower.Value, smsMessage, objectContext, type);
                    }

                    foreach (var item in hastaBazli)
                    {
                        SendSMSForTrackingPaitent(item.Follower.Value, smsMessage, objectContext, type);
                    }

                }

                if (sendNotification)
                {
                    foreach (var item in kabulBazli)
                    {
                        followerlist.Add(item.Follower.Value.ToString());
                    }

                    foreach (var item in hastaBazli)
                    {
                        followerlist.Add(item.Follower.Value.ToString());
                    }

                    SendNotificationForTrackingPaitent(NotificationMessage, followerlist);

                }

            }
        }

        protected void SendSMSForTrackingPaitent(Guid follower, string message, TTObjectContext objectContext, SMSTypeEnum type)
        {
            UserMessage userMessage = new UserMessage();
            string messageText = string.Empty;

            string hospitalShortName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "");
            bool sendSMS = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SENDSMSFORTRACKINGPATIENT", "FALSE"));

            ResUser _follower = objectContext.GetObject<ResUser>(follower);

            try
            {
                if (_follower.PhoneNumber != null && sendSMS)
                {
                    List<ResUser> users = new List<ResUser> { _follower };
                    userMessage.SendSMSPerson(users, message, type);
                }
            }
            catch (Exception)
            {

            }

        }

        protected void SendNotificationForTrackingPaitent(string message, List<string> followerlist)
        {
            bool sendNotification = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SENDNOTIFICATIONFORTRACKINGPATIENT", "FALSE"));
            if (sendNotification)
            {
                TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                atlasNotification.users = followerlist;
                atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                atlasNotification.contentType = TTUtils.AtlasContentType.Notification;

                atlasNotification.content = message;
                string notificationStr = JsonConvert.SerializeObject(atlasNotification);

                TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
            }

        }

        #endregion
    }
}

namespace Core.Models
{
    public class EpisodeActionFormViewModel
    {
        public TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get;
            set;
        }
    }

    public class SUTRuleResultViewModel
    {
        public Boolean validateResult
        {
            get;
            set;
        }

        public List<string> messageList = new List<string>();
    }

    public class SUTRuleEngineInputViewModel
    {
        public EpisodeAction episodeAction;
        public List<SubActionProcedure> subActionProcedures = new List<SubActionProcedure>();
    }

    public class EReportIndexAuthorizations
    {
        public bool isAuthorizedForEDogum { get; set; }
        public bool isAuthorizedForEAthlete { get; set; }
        public bool isAuthorizedForEDriver { get; set; }
        public bool isAuthorizedForEPsychotecnics { get; set; }
        public bool isAuthorizedForEDisabled { get; set; }
    }

    #region TELETIP
    public class Teletip_Input
    {
        public string MedulaInstitutionId { get; set; }
        public string PatientCitizenId { get; set; }
        public string SutCode { get; set; }
        public string DoctorCitizenId { get; set; }
    }

    public class TeletipInput_DVO
    {
        public string MedulaInstitutionId { get; set; }
        public string PatientCitizenId { get; set; }
        public List<string> SUTCodeList { get; set; }
        public string DoctorCitizenId { get; set; }
    }

    public class TeletipResult_Output
    {
        public string OrderId { get; set; }
        public string InstitutionName { get; set; }
        public string SKRS { get; set; }
        public string AccessionNumber { get; set; }
        public string ScheduleDate { get; set; }
        public string PerformedDate { get; set; }
        public string RequestedProcedureDescription { get; set; }
        public bool IsStudyExist { get; set; }
        public bool IsReportExist { get; set; }
    }

    public class TetkikMukerrerInput
    {
        public string KlinikKodu { get; set; }
        public string HastaKimlikBilgisi { get; set; }
        public string HekimKimlikBilgisi { get; set; }
        public string[] SutKodu { get; set; }

    }

    public class ControlVitaminDResult
    {
        public TetkikMukerrerOutput VitaminD_Response { get; set; }
        public bool hasPermissionToRequest { get; set; }
        public string Alert;

    }

    public class TetkikMukerrerOutput
    {
        public int durum { get; set; }

        public TetkikMukerrerSonuc sonuc { get; set; }

        public string mesaj { get; set; }
    }

    class GetPreviousStudiesForSutCodeList_Class
    {
        public int MedulaInstitutionId { get; set; }
        public string PatientCitizenId { get; set; }
        public List<string> SutCodeList { get; set; }
        public string DoctorCitizenId { get; set; }
    }

    public class GetPreviousStudiesForSutCodeList_OutPut_Class
    {
        public string SutCode { get; set; }
        public bool? Result { get; set; }
    }
    #endregion
    public class TetkikSonucDetaylari
    {
        public string loincKodu { get; set; }
        public string tetkikSonucParametreAdi { get; set; }
        public string tetkikSonucu { get; set; }
        public string tetkikSonucuBirimi { get; set; }
        public string tetkikSonucuReferansDegeri { get; set; }
        public string tetkikSonucuReferansDegerAraligindaMi { get; set; }
    }

    public class TetkikSonucBilgileri
    {
        public string XXXXXXAdi { get; set; }
        public string klinikAdi { get; set; }
        public string gerceklesmeZamani { get; set; }
        public string tetkikSonucTarihi { get; set; }
        public List<TetkikSonucDetaylari> tetkikSonucDetaylari { get; set; }
    }

    public class TetkikSonuc
    {
        public string sutKodu { get; set; }
        public int sonucKodu { get; set; }
        public string sonucMesaji { get; set; }
        public List<TetkikSonucBilgileri> tetkikSonucBilgileri { get; set; }
    }

    public class TetkikMukerrerSonuc
    {
        public List<TetkikSonuc> tetkikSonuc { get; set; }
    }




    public class TeletipImaj_Input
    {
        public string AccessionNumber { get; set; }
        public string PatientCitizenId { get; set; }
        public string DoctorCitizenId { get; set; }
        public string AccessToken { get; set; }
    }

    public class Paramm
    { public string OrderID { get; set; } }

    public class DailyInpatientInfoModel
    {
        public bool HasDailyInpatient { get; set; }
        public string DailyInpatientProtocolNo { get; set; }
        public bool HasNormalInpatient { get; set; }
    }

    public class HealthCommitteandReqReason
    {
        public List<HCRequestReason> hCRequestReasons = new List<HCRequestReason>();
        public List<ShortHcInfo> shortHealthCommittees = new List<ShortHcInfo>();
    }

    public class ShortHcInfo
    {
        public Guid ObjectID { get; set; }
        public string HCReportName { get; set; }
    }

    public class BirthTypeModel
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
    }

    public class SurgeryChecklistModel
    {
        public Guid? ChecklistID { get; set; }
        public string Procedures { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}