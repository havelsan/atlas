using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class EDisabledReportServiceController : Controller
    {
        public static string GetToken()
        {
            //GetTokenParameters tokenParameters = new GetTokenParameters();
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string token = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;

            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
            }
            else
            {
                role = "5DDEB487-A0C2-47D6";
            }

            /* tokenParameters.username = UserName;
             tokenParameters.password = Password;
             tokenParameters.applicationCode = ApplicationCode;
             tokenParameters.identityNumber = IdentityNumber;
             tokenParameters.role = role;
             var response = ERaporService.WebMethods.GetTokenSync(Sites.SiteLocalHost, "", "", tokenParameters);*/
            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"].ToString();

            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı. Hata:" + result.Content);
            }
            return token;
        }

        /*Engelli Raporu*/
        public static string eReportAddress = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/") + "ExternalApi/api/disexamination/";


        public static DisPatientApp GetDisPatientApp(EDisabledReport eDisabledReport, bool isCreatedNew, TTObjectContext objectContext)
        {

            var patientApp = new DisPatientApp
            {
                AppDate = DateTime.Now,
                ApplicationExplanation = eDisabledReport.ApplicationExplanation,
                ApplicationReason = (EngelliRaporuMuracaatNedeniEnum)eDisabledReport.ApplicationReason,
                PatientPhoto = "",
                PatientAppCouncilSituation = EngelliRaporuMuayeneAdimiEnum.PatientAppCreated,
            };
            if (isCreatedNew == true)
                patientApp.PatientAppCouncilSituation = EngelliRaporuMuayeneAdimiEnum.PatientAppCreated;
            else
                patientApp.PatientAppCouncilSituation = eDisabledReport.ApplicationCouncilSituation;
            patientApp.PatientId = (long)eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.UniqueRefNo;
            patientApp.PatientAppId = eDisabledReport.PatientAppId != null ? Convert.ToInt32(eDisabledReport.PatientAppId) : 0;
            if (eDisabledReport.ApplicationReason != null && eDisabledReport.ApplicationReason == EngelliRaporuMuracaatNedeniEnum.EngelliRaporu)
            {
                if (eDisabledReport.ApplicationType != null)
                {
                    patientApp.DisabledReportApplicationType = eDisabledReport.ApplicationType;
                    if (eDisabledReport.ApplicationType == EngelliRaporuMuracaatTipiEnum.KisiselMuracaat)
                    {
                        if (eDisabledReport.PersonalApplicationType != null)
                            patientApp.DisabledReportPersonalAppTypes = eDisabledReport.PersonalApplicationType;
                    }
                    else if (eDisabledReport.ApplicationType == EngelliRaporuMuracaatTipiEnum.KurumsalMuracaat)
                    {
                        if (eDisabledReport.CorporateApplicationType != null)
                            patientApp.DisabledReportCorporateAppTypes = eDisabledReport.CorporateApplicationType;
                    }
                }
            }
            else if (eDisabledReport.ApplicationReason != null && eDisabledReport.ApplicationReason == EngelliRaporuMuracaatNedeniEnum.TerorKazaYaralanma)
            {
                if (eDisabledReport.TerrorAccidentInjuryAppType != null)
                {
                    patientApp.TerrorAccidentInjuryAppTypes = eDisabledReport.TerrorAccidentInjuryAppType;
                }
                if (eDisabledReport.TerrorAccidentInjuryAppReason != null)
                {
                    patientApp.TerrorAccidentInjuryAppReason = eDisabledReport.TerrorAccidentInjuryAppReason;
                }
            }

            if (eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.Photo != null)
                patientApp.PatientPhoto = "data:image/jpeg;base64," + eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.Photo.ToString();// eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.Photo.ToString();   //PatientAdmission Üzerinden alınacak
            else
                throw new Exception("Hastaya Fotoğraf Yüklenmeden Entegrasyon verisi gönderilemez.!");

            patientApp.DisabledExaminations = new List<DisabledExaminationDto>();
            foreach (HCExaminationComponent hCExaminationComponent in eDisabledReport.HCExaminationComponent)
            {
                PatientExamination pe = hCExaminationComponent.PatientExamination[0];
                if (pe.PatientExaminationType == PatientExaminationEnum.HealthCommittee && pe.CurrentStateDefID == PatientExamination.States.Completed && pe.TreatmentResult != null)
                {
                    DisabledExaminationDto disabledExaminationDto = getDisabledExaminationDto(pe, objectContext);
                    patientApp.DisabledExaminations.Add(disabledExaminationDto);
                }


            }
            return patientApp;
        }
        public static DisabledExaminationDto getDisabledExaminationDto(PatientExamination patientExamination, TTObjectContext objectContext)
        {
            List<string> diagnosisList = new List<string>();

            if (patientExamination.Diagnosis != null && patientExamination.Diagnosis.Count > 0)
            {

                foreach (DiagnosisGrid diagnosis in patientExamination.Diagnosis)
                {
                    diagnosisList.Add(diagnosis.DiagnoseCode);
                }
            }


            var disap = new DisabledExaminationDto()
            {
                Appendix2QuestionandRatio = new List<Appendix2QuestionandRatioDto>
                {
                    new Appendix2QuestionandRatioDto{

                    }
                },
                ICD10List = diagnosisList,
                DoctorId = Convert.ToInt64(patientExamination.ProcedureDoctor.UniqueNo)
            };
            if (patientExamination.HCExaminationComponent.EngelliRaporuMuayeneId != null)
            {
                disap.ExaminationId = Convert.ToInt32(patientExamination.HCExaminationComponent.EngelliRaporuMuayeneId);
            }

            var klinik = patientExamination.MasterResource.GetMySKRSKlinikler();
            if (klinik != null)
            {
                disap.PolyclinicId = Convert.ToInt64(klinik.KODU);
            }


            if (patientExamination.HCExaminationComponent.DisabledRatio != null)
            {
                disap.Appendix2QuestionandRatio = new List<Appendix2QuestionandRatioDto>();
                disap.Appendix2QuestionandRatio.Add(new Appendix2QuestionandRatioDto
                {
                    IsActive = true,
                    Question = patientExamination.HCExaminationComponent.OfferOfDecision,  //Sorulacak
                    Ratio = (patientExamination.HCExaminationComponent.DisabledRatio != null || patientExamination.HCExaminationComponent.DisabledRatio.ToString() != "") ? Convert.ToInt32(patientExamination.HCExaminationComponent.DisabledRatio) : 0
                });
            }

            return disap;
        }
        public static int CreateEReportApplication(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            DisPatientApp patientApp = GetDisPatientApp(eDisabledReport, true, objectContext);
            var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApp);
            HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.PostAsync(eReportAddress + "CreateApplication", httpContent).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseString);
            var patientAppId = result["data"];
            if (result["data"] != 0)
            {
                eDisabledReport.PatientAppId = result["data"];
                objectContext.Save();
            }
            else
            {
                throw new Exception("Engelli Rapor Entegrasyonundan Alınan Hata : " + result["message"]);
            }
            return patientAppId; //Dönüş degeri önemli update ve diger işlemlerde kullanılacak
        }
        public static bool UpdateEReportApplication(EDisabledReport eDisabledReport, EngelliRaporuMuayeneAdimiEnum patientAppCouncilSituation, TTObjectContext objectContext)
        {
            string token = GetToken();
            DisPatientApp patientApp = GetDisPatientApp(eDisabledReport, false, objectContext);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // update işlemi;

            patientApp.PatientAppCouncilSituation = patientAppCouncilSituation;


            var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApp);

            HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");
            var responseFromUpdate = httpClient.PostAsync(eReportAddress + "UpdateApplication", httpContent).GetAwaiter().GetResult();
            var responseStringFromUpdate = responseFromUpdate.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseStringFromUpdate);

            if (Convert.ToBoolean(resultUpdate["result"]) == false)
            {
                throw new Exception("E-Rapor entegrasyonundan alınan hata: " + resultUpdate["message"]);
            }
            return Convert.ToBoolean(resultUpdate["result"]);
        }
        public static bool DeleteEReportApplication(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.GetAsync(eReportAddress + "DeleteApplication/" + eDisabledReport.PatientAppId).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var apiresult = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult>(responseString); //veriyi çekme işlemi
            var patientApp = apiresult.Result;
            if (apiresult.Result == true)
            {
                eDisabledReport.PatientAppId = null;
                objectContext.Save();
            }
            return patientApp;
        }
        public static bool SendToCouncil(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.GetAsync(eReportAddress + "SendToCouncil/" + eDisabledReport.PatientAppId).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var apiresult = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<bool>>(responseString); //veriyi çekme işlemi
            var patientApp = apiresult.Result;
            if (apiresult.Result == true)
            {
                eDisabledReport.ApplicationCouncilSituation = EngelliRaporuMuayeneAdimiEnum.SendToCouncil;
                objectContext.Save();
            }
            return patientApp;
        }

        public static bool SendCozgerToCouncil(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.GetAsync(cozgerAddress + "SendToCouncil/" + eDisabledReport.PatientAppId).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var apiresult = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<bool>>(responseString); //veriyi çekme işlemi
            var patientApp = apiresult.Result;
            if (apiresult.Result == true)
            {
                eDisabledReport.ApplicationCouncilSituation = EngelliRaporuMuayeneAdimiEnum.SendToCouncil;
                objectContext.Save();
            }
            return patientApp;
        }
        public static void GetEReportPatientApp(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.GetAsync(eReportAddress + "GetApplicationWithPatientAppId/" + eDisabledReport.PatientAppId).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var apiresult = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<DisPatientApp>>(responseString); //veriyi çekme işlemi
            var patientApp = apiresult.Data;
            if (patientApp != null)
            {
                foreach (DisabledExaminationDto disabledExamination in patientApp.DisabledExaminations)
                {
                    foreach (HCExaminationComponent hcExaminationComponent in eDisabledReport.HCExaminationComponent)
                    {
                        if (hcExaminationComponent.EngelliRaporuMuayeneId == null)
                        {
                            if (disabledExamination.PolyclinicId.ToString() == hcExaminationComponent.PatientExamination[0].MasterResource.GetMySKRSKlinikler().KODU)
                            {
                                hcExaminationComponent.EngelliRaporuMuayeneId = disabledExamination.ExaminationId.ToString();
                            }
                        }

                    }
                    objectContext.Save();
                }

                eDisabledReport.ApplicationCouncilSituation = patientApp.PatientAppCouncilSituation;
                objectContext.Save();
            }
        }

        [HttpGet]
        public string ReSendEReportApplication(Guid healthCommitteeOjbectId)
        {
            string resultMessage = "";
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                HealthCommittee healthCommittee = objectContext.GetObject<HealthCommittee>(healthCommitteeOjbectId);

                if (healthCommittee != null)
                {
                    if (healthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                    {
                        foreach (var firedAction in healthCommittee.LinkedActions)
                        {
                            if (firedAction is PatientExamination)
                            {
                                var eDisabledReport = ((PatientExamination)firedAction).HCExaminationComponent.EDisabledReport;
                                if (eDisabledReport != null)
                                {
                                    if (eDisabledReport.PatientAppId == null)
                                    {
                                        CreateEReportApplication(eDisabledReport, objectContext);
                                        resultMessage = "Entegrasyon Başarılı.";
                                    }
                                    else
                                    {
                                        UpdateEReportApplication(eDisabledReport, EngelliRaporuMuayeneAdimiEnum.PatientAppCreated, objectContext);
                                        resultMessage = "Entegrasyon verisi başarı ile güncellendi.";
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return resultMessage;
        }

        [HttpGet]
        public string OpenEDisabledReportIndex()
        {
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string url = parameterUrl + "DisabledWeb/Dis/SecIndex";

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            role = "5DDEB487-A0C2-47D6";


            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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
        public string OpenEDisabledCouncilIndex()
        {
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string url = parameterUrl + "CouncilWeb/Council/CouncilDescription";

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            role = "5DDEB487-A0C2-47D6";


            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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
        public string OpenEDisabledCouncilProcess()
        {
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string url = parameterUrl + "CouncilWeb/Council/CouncilPatientSelect";

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            role = "6AAB18C7-B16B-4A04";

            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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
        public string OpenCozgerReportCreateApplication()
        {
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string url = parameterUrl + "ChildDisabledWeb/Dis/PatientApplication";

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            role = "5DDEB487-A0C2-47D6";


            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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
        public string OpenEDisabledReportCreateApplication()
        {
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string url = parameterUrl + "DisabledWeb/Dis/PatientApplication";

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            role = "5DDEB487-A0C2-47D6";


            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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
        public string OpenEDisabledReportCouncil()
        {
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string url = parameterUrl + "CouncilWeb/Council/CouncilPatientSelect";

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
            else if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
            }


            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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
        /*Engelli Raporu*/

        /*ÇÖZGER Raporu*/

        public static string cozgerAddress = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/")+"ExternalApi/api/CozgerExamination/";

        public static CozgerPatientApplicationDto GetCozgerPatientApplicationDto(EDisabledReport eDisabledReport, bool isCreatedNew, TTObjectContext objectContext)
        {

            var patientApp = new CozgerPatientApplicationDto
            {
                AppDate = DateTime.Now,
                ApplicationExplanation = eDisabledReport.ApplicationExplanation,
                ApplicationReason = (EngelliRaporuMuracaatNedeniEnum)eDisabledReport.ApplicationReason,
                PatientPhoto = "",
                PatientAppCouncilSituation = EngelliRaporuMuayeneAdimiEnum.PatientAppCreated,
            };
            if (eDisabledReport.PatientAppId != null || eDisabledReport.PatientAppId != "0")
                patientApp.PatientAppId = Convert.ToInt64(eDisabledReport.PatientAppId);
            if (isCreatedNew == true)
                patientApp.PatientAppCouncilSituation = EngelliRaporuMuayeneAdimiEnum.PatientAppCreated;
            else
                patientApp.PatientAppCouncilSituation = eDisabledReport.ApplicationCouncilSituation;
            patientApp.PatientId = (long)eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.UniqueRefNo;

            if (eDisabledReport.ApplicationReason != null && eDisabledReport.ApplicationReason == EngelliRaporuMuracaatNedeniEnum.EngelliRaporu)
            {
                if (eDisabledReport.ApplicationType != null)
                {
                    patientApp.DisabledReportApplicationType = eDisabledReport.ApplicationType;
                    if (eDisabledReport.ApplicationType == EngelliRaporuMuracaatTipiEnum.KisiselMuracaat)
                    {
                        if (eDisabledReport.PersonalApplicationType != null)
                            patientApp.DisabledReportPersonalAppTypes = eDisabledReport.PersonalApplicationType;
                    }
                    else if (eDisabledReport.ApplicationType == EngelliRaporuMuracaatTipiEnum.KurumsalMuracaat)
                    {
                        if (eDisabledReport.CorporateApplicationType != null)
                            patientApp.DisabledReportCorporateAppTypes = eDisabledReport.CorporateApplicationType;
                    }
                }
            }
            else if (eDisabledReport.ApplicationReason != null && eDisabledReport.ApplicationReason == EngelliRaporuMuracaatNedeniEnum.TerorKazaYaralanma)
            {
                if (eDisabledReport.TerrorAccidentInjuryAppType != null)
                {
                    patientApp.TerrorAccidentInjuryAppTypes = eDisabledReport.TerrorAccidentInjuryAppType;
                }
                if (eDisabledReport.TerrorAccidentInjuryAppReason != null)
                {
                    patientApp.TerrorAccidentInjuryAppReason = eDisabledReport.TerrorAccidentInjuryAppReason;
                }
            }
            if (eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.Photo != null)
                patientApp.PatientPhoto = "data:image/jpeg;base64," + eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.Photo.ToString();// eDisabledReport.HCExaminationComponent[0].PatientExamination[0].Episode.Patient.Photo.ToString();   //PatientAdmission Üzerinden alınacak
            else
                throw new Exception("Hastaya Fotoğraf Yüklenmeden Entegrasyon verisi gönderilemez.!");

            //PatientAdmission Üzerinden alınacak
            patientApp.PatientAppSRADto = new List<CozgerPatientAppSRADto>();
            foreach (HCExaminationComponent hCExaminationComponent in eDisabledReport.HCExaminationComponent)
            {
                PatientExamination pe = hCExaminationComponent.PatientExamination[0];
                if (pe.PatientExaminationType == PatientExaminationEnum.HealthCommittee && pe.CurrentStateDefID == PatientExamination.States.Completed && pe.TreatmentResult != null)
                {
                    CozgerPatientAppSRADto cozgerPatientAppSRADto = getPatientAppSRADto(pe, objectContext);
                    patientApp.PatientAppSRADto.Add(cozgerPatientAppSRADto);
                }


            }


            return patientApp;
        }
        public static CozgerPatientAppSRADto getPatientAppSRADto(PatientExamination patientExamination, TTObjectContext objectContext)
        {
            List<string> diagnosisList = new List<string>();


            if (patientExamination.Diagnosis != null && patientExamination.Diagnosis.Count > 0)
            {

                foreach (DiagnosisGrid diagnosis in patientExamination.Diagnosis)
                {
                    diagnosisList.Add(diagnosis.DiagnoseCode);
                }
            }


            var disap = new CozgerPatientAppSRADto()
            {
                ICD10List = diagnosisList,
                PatientAppSRAChildDto = new List<CozgerPatientAppSRAChildDto>()
                {
                    /*new CozgerPatientAppSRAChildDto()
                    {
                        Id = 5,
                        SRAChildName = "Genetik İmmün Yetmezlikler"
                    }*/
                }
            };

            if (patientExamination.HCExaminationComponent.OfferOfDecision != null)
            {
                disap.PatientAppSRAChildDto = new List<CozgerPatientAppSRAChildDto>();
                disap.PatientAppSRAChildDto.Add(new CozgerPatientAppSRAChildDto() { SRAChildName = patientExamination.HCExaminationComponent.OfferOfDecision });
            }
            if (patientExamination.HCExaminationComponent.CozgerSpecReqArea != null)
                disap.SRAId = Convert.ToInt32(patientExamination.HCExaminationComponent.CozgerSpecReqArea.Id);

            if (patientExamination.HCExaminationComponent.CozgerSpecReqLevel != null)
                disap.SRLId = Convert.ToInt32(patientExamination.HCExaminationComponent.CozgerSpecReqLevel.Id);

            if (patientExamination.HCExaminationComponent != null && !String.IsNullOrEmpty(patientExamination.HCExaminationComponent.EngelliRaporuMuayeneId))
            {
                var SplittedText = patientExamination.HCExaminationComponent.EngelliRaporuMuayeneId.Split('-');
                disap.PatientAppSRAId = Convert.ToInt64(SplittedText[0]);
               /* if (SplittedText.Length > 1)
                    disap.PatientAppSRAChildDto[0].Id = Convert.ToInt64(SplittedText[1]);*/
            }
            return disap;
        }

        public static int CreateCozgerApplication(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            CozgerPatientApplicationDto patientApp = GetCozgerPatientApplicationDto(eDisabledReport, true, objectContext);
            var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApp);
            HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.PostAsync(cozgerAddress + "CreateApplication", httpContent).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseString);
            var patientAppId = result["data"];
            if (result["data"] != null)
            {
                eDisabledReport.PatientAppId = result["data"];
                objectContext.Save();
            }
            return patientAppId; //Dönüş degeri önemli update ve diger işlemlerde kullanılacak
        }

        public static bool UpdateCozgerApplication(EDisabledReport eDisabledReport, EngelliRaporuMuayeneAdimiEnum patientAppCouncilSituation, TTObjectContext objectContext)
        {
            string token = GetToken();
            CozgerPatientApplicationDto patientApp = GetCozgerPatientApplicationDto(eDisabledReport, false, objectContext);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // update işlemi;

            patientApp.PatientAppCouncilSituation = patientAppCouncilSituation;


            var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApp);

            HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");
            var responseFromUpdate = httpClient.PostAsync(cozgerAddress + "UpdateApplication", httpContent).GetAwaiter().GetResult();
            var responseStringFromUpdate = responseFromUpdate.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseStringFromUpdate);
            if (Convert.ToBoolean(resultUpdate["result"]) == false)
            {
                throw new Exception("E-Rapor entegrasyonundan alınan hata: " + resultUpdate["message"]);
            }
            return Convert.ToBoolean(resultUpdate["result"]);
        }

        public static bool DeleteCozgerApplication(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.GetAsync(cozgerAddress + "DeleteApplication/" + eDisabledReport.PatientAppId).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var apiresult = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult>(responseString); //veriyi çekme işlemi
            var patientApp = apiresult.Result;
            if (apiresult.Result == true)
            {
                eDisabledReport.PatientAppId = null;
                objectContext.Save();
            }
            return patientApp;
        }

        public static void GetCozgerReportPatientApp(EDisabledReport eDisabledReport, TTObjectContext objectContext)
        {
            string token = GetToken();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.GetAsync(cozgerAddress + "GetApplicationWithPatientAppId/" + eDisabledReport.PatientAppId).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var apiresult = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<CozgerPatientApplicationDto>>(responseString); //veriyi çekme işlemi
            var patientApp = apiresult.Data;
            if (patientApp != null)
            {
                foreach (CozgerPatientAppSRADto disabledExamination in patientApp.PatientAppSRADto)
                {
                    foreach (HCExaminationComponent hcExaminationComponent in eDisabledReport.HCExaminationComponent)
                    {
                        if (String.IsNullOrEmpty(hcExaminationComponent.EngelliRaporuMuayeneId))
                        {
                            if (hcExaminationComponent.CozgerSpecReqArea != null && disabledExamination.SRAId.ToString() == hcExaminationComponent.CozgerSpecReqArea.Id)
                            {
                                hcExaminationComponent.EngelliRaporuMuayeneId = disabledExamination.PatientAppSRAId.ToString() + "-" + disabledExamination.PatientAppSRAChildDto[0].Id.ToString();
                            }
                        }

                    }
                }

                eDisabledReport.ApplicationCouncilSituation = patientApp.PatientAppCouncilSituation;
                objectContext.Save();
            }
        }


        public string OpenCozgerReportIndex()
        {
            string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
            string url = parameterUrl + "ChildDisabledWeb/Dis/SecIndex";

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            role = "5DDEB487-A0C2-47D6";


            var uri = new Uri(parameterUrl + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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

        public string OpenCozgerReportCouncil()
        {
            string url = "http://xxxxxx.com/CouncilWeb/Council/CouncilPatientSelect";

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            UserName = "";// TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            Password = ".";// TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            ApplicationCode = "";// TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Sekreter))
            {
                role = "5DDEB487-A0C2-47D6";
            }
            else if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
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
        /*ÇÖZGER Raporu*/


        [HttpGet]
        public string GetSecretaryIndexLink(Guid healthCommitteeOjbectId)
        {
            string secretaryIndex = "";
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                HealthCommittee healthCommittee = objectContext.GetObject<HealthCommittee>(healthCommitteeOjbectId);

                if (healthCommittee != null)
                {
                    if (healthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                    {
                        foreach (var firedAction in healthCommittee.LinkedActions)
                        {
                            if (firedAction is PatientExamination)
                            {
                                var eDisabledReport = ((PatientExamination)firedAction).HCExaminationComponent.EDisabledReport;
                                if (eDisabledReport != null)
                                {
                                    if (eDisabledReport.IsCozgerReport.HasValue)
                                    {
                                        if (eDisabledReport.IsCozgerReport == true)
                                            secretaryIndex = OpenCozgerReportIndex();
                                        else
                                            secretaryIndex = OpenEDisabledReportIndex();
                                    }
                                    else
                                        secretaryIndex = OpenEDisabledReportIndex();

                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return secretaryIndex;
        }

        [HttpGet]
        public string GetCouncilLink(Guid healthCommitteeOjbectId)
        {
            string councilLink = "";
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                HealthCommittee healthCommittee = objectContext.GetObject<HealthCommittee>(healthCommitteeOjbectId);

                if (healthCommittee != null)
                {
                    if (healthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                    {
                        foreach (var firedAction in healthCommittee.LinkedActions)
                        {
                            if (firedAction is PatientExamination)
                            {
                                var eDisabledReport = ((PatientExamination)firedAction).HCExaminationComponent.EDisabledReport;
                                if (eDisabledReport != null)
                                {
                                    if (eDisabledReport.IsCozgerReport.HasValue)
                                    {
                                        if (eDisabledReport.IsCozgerReport == true)
                                            councilLink = OpenCozgerReportCouncil();
                                        else
                                            councilLink = OpenEDisabledReportCouncil();
                                    }
                                    else
                                        councilLink = OpenEDisabledReportCouncil();

                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return councilLink;
        }


    }
}

namespace Core.Models
{
    public class DisPatientApp
    {
        // Identity alanı               
        public long? PatientAppId { get; set; }

        // Hasta Id (TC Kimlik No)    
        public long PatientId { get; set; }

        // Hasta Resim Bilgisi (base64 image string olarak)
        public string PatientPhoto { get; set; }

        // Başvuru tarihi
        public DateTime AppDate { get; set; }

        // Başvuru açıklaması
        public string ApplicationExplanation { get; set; }
        public EngelliRaporuMuracaatNedeniEnum ApplicationReason { get; set; }        //ApplicationReason
        //Muracaat Şekli Engelli Saglık Kurulu İse Seçilecekler
        public EngelliRaporuMuracaatTipiEnum? DisabledReportApplicationType { get; set; }       //DisabledReportApplicationType
        public EngelliRaporuKurumsalMuracaatTuruEnum? DisabledReportCorporateAppTypes { get; set; }       //DisabledReportCorporateAppTypes
        public EngelliRaporuKisiselMuracaatTuruEnum? DisabledReportPersonalAppTypes { get; set; }         //DisabledReportPersonalAppTypes
        //Müracaat Şekli Terör Kaza yaralanma ise
        public EngelliRaporuTerorKazaMuracaatTipiEnum? TerrorAccidentInjuryAppTypes { get; set; }         //TerrorAccidentInjuryAppTypes
        public EngelliRaporuTerorKazaMuracaatNedeniEnum? TerrorAccidentInjuryAppReason { get; set; }         //TerrorAccidentInjuryAppReason
        public EngelliRaporuMuayeneAdimiEnum? PatientAppCouncilSituation { get; set; }     //PatientAppCouncilSituation
        public List<DisabledExaminationDto> DisabledExaminations { get; set; }
    }
    public class DisabledExaminationDto
    {
        public long? ExaminationId { get; set; }
        public long DoctorId { get; set; }
        public long PolyclinicId { get; set; }
        public List<string> ICD10List { get; set; }
        public List<Appendix2QuestionandRatioDto> Appendix2QuestionandRatio { get; set; }
    }
    public class Appendix2QuestionandRatioDto
    {
        //Other Disablity Id as 
        public long Id { get; set; }
        public string Question { get; set; }
        public double Ratio { get; set; }
        public bool IsActive { get; set; }
    }
    public class CozgerPatientApplicationDto
    {
        // Identity alanı               
        public long? PatientAppId { get; set; }

        // Hasta Id (TC Kimlik No)    
        public long PatientId { get; set; }

        // Hasta Resim Bilgisi (base64 image string olarak)
        public string PatientPhoto { get; set; }

        // Başvuru tarihi
        public DateTime AppDate { get; set; }

        // Başvuru açıklaması
        public string ApplicationExplanation { get; set; }

        public EngelliRaporuMuracaatNedeniEnum ApplicationReason { get; set; }        //ApplicationReason
        //Muracaat Şekli Engelli Saglık Kurulu İse Seçilecekler
        public EngelliRaporuMuracaatTipiEnum? DisabledReportApplicationType { get; set; }       //DisabledReportApplicationType
        public EngelliRaporuKurumsalMuracaatTuruEnum? DisabledReportCorporateAppTypes { get; set; }       //DisabledReportCorporateAppTypes
        public EngelliRaporuKisiselMuracaatTuruEnum? DisabledReportPersonalAppTypes { get; set; }         //DisabledReportPersonalAppTypes
        //Müracaat Şekli Terör Kaza yaralanma ise
        public EngelliRaporuTerorKazaMuracaatTipiEnum? TerrorAccidentInjuryAppTypes { get; set; }         //TerrorAccidentInjuryAppTypes
        public EngelliRaporuTerorKazaMuracaatNedeniEnum? TerrorAccidentInjuryAppReason { get; set; }         //TerrorAccidentInjuryAppReason
        public EngelliRaporuMuayeneAdimiEnum? PatientAppCouncilSituation { get; set; }     //PatientAppCouncilSituation


        // Liste SRA (Special Requirement Area - Özel gereksinim Alanı)
        public List<CozgerPatientAppSRADto> PatientAppSRADto { get; set; }
    }


    public class CozgerPatientAppSRADto
    {
        // Identity alanı      
        public long PatientAppSRAId { get; set; }

        // Projedeki "SRA ID - SRL ID Listesi.txt" dosyasında Id'leri ve açıklamalarını bulabilirsiniz
        public long SRAId { get; set; }

        // Projedeki "SRA ID - SRL ID Listesi.txt" dosyasında Id'leri ve açıklamalarını bulabilirsiniz
        public long SRLId { get; set; }

        // ICD10 kod listesi
        public List<string> ICD10List { get; set; }

        // Liste SRA Child - SRA Alt Bilgisi (Special Requirement Area - Özel gereksinim Alanı)
        public List<CozgerPatientAppSRAChildDto> PatientAppSRAChildDto { get; set; }
    }

    public class CozgerPatientAppSRAChildDto
    {
        // Identity alanı   
        public long Id { get; set; }
        public string SRAChildName { get; set; }
    }

    public class ApiResult
    {
        public ApiResult()
        {
        }
        public ApiResult(bool _Result, string _Message)
        {
            Result = _Result;
            Message = _Message;
        }
        public ApiResult(bool _Result, string _Message, int _HttpStatusCode)
        {
            Result = _Result;
            Message = _Message;
            HttpStatusCode = _HttpStatusCode;

        }
        public ApiResult(bool _Result, string _Message, int _HttpStatusCode, string _ExceptionCode, object _Data = null)
        {
            Result = _Result;
            Message = _Message;
            HttpStatusCode = _HttpStatusCode;
            ExceptionCode = _ExceptionCode;
        }
        public bool Result { get; set; }
        public string Message { get; set; }

        public int? HttpStatusCode { get; set; }
        public string ExceptionCode { get; set; }
    }
    public class ApiResult<T> : ApiResult
    {

        public ApiResult()
        {

        }
        public ApiResult(bool _Result, string _Message, T _Data = default(T))
        {
            Result = _Result;
            Message = _Message;
            Data = _Data;
        }
        public ApiResult(bool _Result, T _Data = default(T))
        {
            Result = _Result;
            Data = _Data;
        }

        public bool Result { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

    }
}
