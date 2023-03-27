using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class EDurumBildirirKurulServiceController
    {
        public static string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");
        public static long CreateEDurumBildirirKurulApplication(EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj, TTObjectContext objectContext, HealthCommittee healthCommittee = null)
        {
            string token = EDisabledReportServiceController.GetToken();
            AddPatientApplicationDto patientApplication = new AddPatientApplicationDto();
            HealthCommittee hcExaminationObject = null;
            if (healthCommittee == null)
            {
                hcExaminationObject = (HealthCommittee)eStatusNotRepCommitteeObj.HCExaminationComponent[0].PatientExamination[0].MasterAction;
            }
            else
            {
                hcExaminationObject = healthCommittee;
            }
            patientApplication.AppDate = (DateTime)hcExaminationObject.SubEpisode.OpeningDate;
            patientApplication.ApplicationType = (EDurumBildirirKurulAppType)eStatusNotRepCommitteeObj.ApplicationType;
            patientApplication.PatientId = (long)hcExaminationObject.Episode.Patient.UniqueRefNo;
            patientApplication.ReportRequestReason = hcExaminationObject.HCRequestReason.ReasonName;

            var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApplication);
            HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //[HttpPost("AddPatientApplication")]
            var response = httpClient.PostAsync(parameterUrl + "externalapi/api/HealthStatusCouncil/AddPatientApplication", httpContent).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResponseObject<long>>(responseString);
            var patientAppId = result.Data;
            if (patientAppId != 0)
            {
                eStatusNotRepCommitteeObj.PatientApplicationID = patientAppId.ToString();
            }
            else
            {
                throw new Exception("Entegrasyon servisinden alınan hata : " + result.Message);
            }
            objectContext.Save();
            return patientAppId;

        }

        public static bool DeleteEDurumBildirirKurulApplication(EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj, TTObjectContext objectContext)
        {
            objectContext.Save();
            var committeeObject = objectContext.LocalQuery<EStatusNotRepCommitteeObj>().Where(t => t.ObjectID == eStatusNotRepCommitteeObj.ObjectID).FirstOrDefault();
            if (committeeObject != null && committeeObject.PatientApplicationID != null)
            {
                string token = EDisabledReportServiceController.GetToken();
                DeletePatientApplicationDto patientApplication = new DeletePatientApplicationDto();

                var hcExaminationObject = (HealthCommittee)eStatusNotRepCommitteeObj.HCExaminationComponent[0].PatientExamination[0].MasterAction;
                patientApplication.PatientApplicationId = Convert.ToInt32(committeeObject.PatientApplicationID);
                patientApplication.PatientId = (long)hcExaminationObject.Episode.Patient.UniqueRefNo;


                var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApplication);

                HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //[HttpPost("AddPatientApplication")]
                var response = httpClient.PostAsync(parameterUrl + "externalapi/api/HealthStatusCouncil/DeletePatientApplication", httpContent).GetAwaiter().GetResult();
                var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResponseObject<bool>>(responseString);
                var IsDeleted = result.Data;
                if (IsDeleted == false)
                {
                    throw new Exception("E-Durum Bildirir Kurul Entegrasyonundan alınan mesaj : " + result.Message);
                }
                else
                {
                    committeeObject.PatientApplicationID = null;
                    objectContext.Save();
                }
                return IsDeleted;
            }
            return true;
        }

        public static AddPatientExaminationDto getExaminationDtoObject(PatientExamination patientExamination, EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj)
        {
            AddPatientExaminationDto patientExaminationDto = new AddPatientExaminationDto();

            patientExaminationDto.PatientApplicationId = Convert.ToInt32(eStatusNotRepCommitteeObj.PatientApplicationID);
            patientExaminationDto.ClinicCode = Convert.ToInt32(patientExamination.MasterResource.GetMySKRSKlinikler().KODU);
            patientExaminationDto.DoctorId =   Convert.ToInt64(patientExamination.ProcedureDoctor.UniqueNo);
            patientExaminationDto.PatientId = Convert.ToInt64(patientExamination.Episode.Patient.UniqueRefNo);

            List<string> icdList = new List<string>();
            List<string> physicalFindingsList = new List<string>();

            foreach (var diagnose in patientExamination.Diagnosis)
            {
                icdList.Add(diagnose.Diagnose.Code);
            }
            patientExaminationDto.ExaminationICD10Dto = icdList;

            if (patientExamination.HCExaminationComponent.OfferOfDecision != null)
            {
                physicalFindingsList.Add(patientExamination.HCExaminationComponent.OfferOfDecision.ToString());
            }
            patientExaminationDto.ExaminationPhysicalFindingsDto = physicalFindingsList;


            return patientExaminationDto;
        }

        public static long SendEDurumBildirirKurulExamination(PatientExamination patientExamination, EStatusNotRepCommitteeObj committeeObject, TTObjectContext objectContext)
        {
            string token = EDisabledReportServiceController.GetToken();
            AddPatientExaminationDto patientApplication = getExaminationDtoObject(patientExamination, committeeObject);

            var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApplication);

            HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //[HttpPost("AddPatientApplication")]
            var response = httpClient.PostAsync(parameterUrl + "externalapi/api/HealthStatusCouncil/AddPatientExamination", httpContent).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResponseObject<long>>(responseString);
            var ExaminationId = result.Data;
            if (ExaminationId == 0)
            {
                throw new Exception("E-Durum Bildirir Kurul Entegrasyonundan alınan mesaj : " + result.Message);
            }
            else
            {
                patientExamination.HCExaminationComponent.EDurumBildirirMuayeneId = ExaminationId.ToString();
                objectContext.Save();
            }
            return ExaminationId;
        }

        public static bool SendPatientToEDurumBildirirCouncil(string patientUniqueRefNo, EStatusNotRepCommitteeObj committeeObject, TTObjectContext objectContext)
        {
            string token = EDisabledReportServiceController.GetToken();

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //[HttpPost("AddPatientApplication")]
            var response = httpClient.GetAsync(parameterUrl + "externalapi/api/HealthStatusCouncil/SendToCouncilPool/"+committeeObject.PatientApplicationID+"/"+ patientUniqueRefNo).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResponseObject<bool>>(responseString);
            var ReqResponse = result.Data;
            if (ReqResponse == false)
            {
                throw new Exception("E-Durum Bildirir Kurul Entegrasyonundan alınan mesaj : " + result.Message);
            }
            else
            {
                committeeObject.ApplicationCouncilSituation = EDurumBildirirKurulAppStatus.SendToCouncilPool;
                objectContext.Save();
            }
            return ReqResponse;
        }

        [HttpGet]
        public string OpenEDurumBildirirReportIndex()
        {
            string url = parameterUrl + "HealthStatusCouncilWeb/HealthStatusCouncil/SecretaryIndex";

            var token = EDisabledReportServiceController.GetToken();
            if (!String.IsNullOrEmpty(token))
            {
                return url + "?authorization=" + token;
            }
            return url;
        }

        [HttpGet]
        public string OpenEDurumBildirirReportCouncil()
        {
            string url = parameterUrl + "CouncilWeb/Council/CouncilPatientSelect";

            var token = EDisabledReportServiceController.GetToken();
            if (!String.IsNullOrEmpty(token))
            {
                return url + "?authorization=" + token;
            }
            return url;
        }

        [HttpGet]
        public string OpenEDurumBildirirReportCreateApplication()
        {
            string url = parameterUrl + "CouncilWeb/Council/CouncilPatientSelect";

            var token = EDisabledReportServiceController.GetToken();
            if (!String.IsNullOrEmpty(token))
            {
                return url + "?authorization=" + token;
            }
            return url;
        }

        [HttpGet]
        public string OpenEDurumBildirirReportCouncilIndex()
        {
            string url = parameterUrl + "CouncilWeb/Council/CouncilDescription";

            var token = EDisabledReportServiceController.GetToken();
            if (!String.IsNullOrEmpty(token))
            {
                return url + "?authorization=" + token;
            }
            return url;
        }
    }
}

namespace Core.Models
{
    public class AddPatientApplicationDto    //Başvuru oluşturulurken kullanılan nesne
    {
        public DateTime AppDate { get; set; }       //Başvuru Tarihi
        public long PatientId { get; set; }      //Hasta Kimlik No
        public string InstitutionAndRole { get; set; }      //Hasta Meslek
        public string PatientPhoneNumber { get; set; }      //Hasta Telefon Numarası
        public EDurumBildirirKurulAppType ApplicationType { get; set; }         //Hasta Başvuru Şekli
        public string ReportRequestReason { get; set; }     //Başvuru Nedeni
    }

    public class DeletePatientApplicationDto    //Başvuru Silmek için kullanılacak nesne
    {
        public int PatientApplicationId { get; set; }       //Entegrasyon Id
        public long PatientId { get; set; }              //Hasta Kimlik No
    }

    public class AddPatientExaminationDto     //Başvuruya Muayene Eklemek için kullanılan nesne
    {
        public int PatientApplicationId { get; set; }       //Hasta Başvuru Id
        public long PatientId { get; set; }          //Hasta Kimlik No
        public long DoctorId { get; set; }           //Doktor Kimlik No
        public int ClinicCode { get; set; }         //Poliklinik(Branş) Kodu
        public List<string> ExaminationICD10Dto { get; set; }       //Tanılar
        public List<string> ExaminationLabResultsDto { get; set; }  //Laboratuvar Sonuçları
        public List<string> ExaminationPhysicalFindingsDto { get; set; }    //Fiziksel Bulgular
    }

    public class DeletePatientExaminationDto        //Başvurudaki Muayeneyi silmek için kullanılan nesne
    {
        public int patientExaminationId { get; set; }       //Hasta Muayene Id
        public int patientApplicationId { get; set; }       //Başvuru Id
        public int patientId { get; set; }          //Hasta Id
    }

    public class ResponseObject<T>
    {
        public T Data { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public int? HttpStatusCode { get; set; }
        public string ExceptionCode { get; set; }
    }

}
