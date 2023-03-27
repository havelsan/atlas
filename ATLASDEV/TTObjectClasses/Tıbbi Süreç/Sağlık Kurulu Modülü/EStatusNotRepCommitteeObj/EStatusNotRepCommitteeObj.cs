
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TTObjectClasses
{
    /// <summary>
    /// E-Durum Bildirir Sağlık Kurulu Rapor Entegrasyonu için kullanılacak nesne,
    /// </summary>
    public partial class EStatusNotRepCommitteeObj : TTObject
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
                IdentityNumber = "10000000000";
                role = "6AAB18C7-B16B-4A04";
            }
            else
            {
                role = "5DDEB487-A0C2-47D6";
            }

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

        /*E-Durum Bildirir Raporu*/
        public static string parameterUrl = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/") + "ExternalApi/api/disexamination/";


        public static bool DeleteEDurumBildirirKurulExamination(PatientExamination patientExamination, EStatusNotRepCommitteeObj committeeObject, TTObjectContext objectContext)
        {
            objectContext.Save();
            string token = GetToken();
            
            DeletePatientExaminationDto patientApplication = new DeletePatientExaminationDto();

            patientApplication.PatientApplicationId = Convert.ToInt32(committeeObject.PatientApplicationID);
            patientApplication.PatientId = (long)patientExamination.Episode.Patient.UniqueRefNo;
            patientApplication.PatientExaminationId = Convert.ToInt64(patientExamination.HCExaminationComponent.EDurumBildirirMuayeneId);


            var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(patientApplication);

            HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //[HttpPost("AddPatientApplication")]
            var response = httpClient.PostAsync(parameterUrl + "externalapi/api/HealthStatusCouncil/DeletePatientExamination", httpContent).GetAwaiter().GetResult();
            var response2 = httpClient.PostAsync(parameterUrl + "api/HealthStatusCouncil/DeletePatientExamination", httpContent).GetAwaiter().GetResult();

            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject<bool>>(responseString);
            var IsDeleted = result.Data;
            if (IsDeleted == false)
            {
                throw new Exception("E-Durum Bildirir Kurul Entegrasyonundan alınan mesaj : " + result.Message);
            }
            else
            {
                patientExamination.HCExaminationComponent.EDurumBildirirMuayeneId = null;
            }
            return IsDeleted;
        }
    }

    public class DeletePatientExaminationDto        //Başvurudaki Muayeneyi silmek için kullanılan nesne
    {
        public long PatientExaminationId { get; set; }       //Hasta Muayene Id
        public long PatientApplicationId { get; set; }       //Başvuru Id
        public long PatientId { get; set; }          //Hasta Id
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