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
using System.Threading;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class TeletipWorkListServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<OrderStatusForAccessionNumber_Output> GetTeletipActionWorkList(TeletipWorkListSearchCriteria dwlssc)
        {
            BindingList<RadiologyTest> accessionist = null;

            List<OrderStatusForAccessionNumber_Output> dwlList = new List<OrderStatusForAccessionNumber_Output>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                string filter = string.Empty;
                bool dateSelected = false;

                if (!string.IsNullOrEmpty(dwlssc.accessionno))
                {
                    BindingList<RadiologyTest> radiologyTests = objectContext.QueryObjects<RadiologyTest>("AccessionNo = '" + dwlssc.accessionno + "'");
                    accessionist = new BindingList<RadiologyTest>();

                    if (radiologyTests.Count > 0)
                        accessionist.Add(radiologyTests[0]);
                }
                else
                {
                    filter = " AND AccessionNo IS NOT NULL ";

                    if (!string.IsNullOrEmpty(dwlssc.uniqueRefNo))
                    {
                        filter += " AND THIS.Episode.Patient.UniqueRefNo = '" + dwlssc.uniqueRefNo + "'";                        
                    }

                    if (dwlssc.workListStartDate != null)
                    {
                        filter += " AND THIS.RequestDate >= TODATE('" + Convert.ToDateTime(dwlssc.workListStartDate.Value.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        dateSelected = true;
                    }

                    if (dwlssc.workListEndDate != null)
                    {
                        filter += " AND THIS.RequestDate <= TODATE('" + Convert.ToDateTime(dwlssc.workListEndDate.Value.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        dateSelected = true;
                    }

                    if (dateSelected)
                    {
                        if (dwlssc.workListEndDate.Value.Subtract(dwlssc.workListStartDate.Value).Days > 31)
                        {
                            throw new Exception("En fazla 31 günlük sorgulama yapabilirsiniz");
                        }
                        filter += " AND (ISMESSAGEINTELETIP IS NULL OR ISMESSAGEINTELETIP = 0) ";//sadece hatalılar veya gitmeyenler
                        filter += " AND THIS.CURRENTSTATEDEFID IN('" + RadiologyTest.States.Approve + "','" + RadiologyTest.States.Completed + "','" + RadiologyTest.States.Procedure + "','" 
                                + RadiologyTest.States.Reported + "','" + RadiologyTest.States.ResultEntry + "')";
                    }

                    accessionist = RadiologyTest.GetByWLFilterExpression(objectContext, filter);

                }
                

                string MedulaTesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");

                if (accessionist != null && accessionist.Count > 0)
                {
                    List<string> _aList = accessionist.Select(x => x.AccessionNo).ToList();

                    for (int i = 0; i <= _aList.Count / 10; i++)
                    {
                        dwlList.AddRange(GetResponse(MedulaTesisKodu, _aList.Skip(i * 10).Take(10).ToList<string>()));
                        Thread.Sleep(100);
                    }

                }
            }

            return dwlList;

        }

        public List<OrderStatusForAccessionNumber_Output> GetResponse(string medulaTesisKodu, List<string> accesionList)
        {
            string returnValue = string.Empty;
            EpisodeActionServiceController eas = new EpisodeActionServiceController();

            string accessToken = eas.getTokenForTeletip();

            eas.Dispose();

            List<OrderStatusForAccessionNumber_Output> accessionNumber_Outputs = new List<OrderStatusForAccessionNumber_Output>();

            ParameterClass parameter = new ParameterClass();
            parameter.MedulaInstitutionId = medulaTesisKodu;
            parameter.AccessionNumberList = accesionList.ToArray();

            string ss = JsonConvert.SerializeObject(parameter);
            Uri uri = new Uri("http://xxxxxx.com/Common.WebApi/api/Integration/GetOrderStatusForAccessionNumberList?parameter=" + ss);

            RestClient client = new RestClient(uri);
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            string bearerToken = "Bearer " + accessToken;
            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
            IRestResponse result = client.Execute(request);

            if (result.StatusCode.ToString() == "OK")
            {
                JArray token = JsonConvert.DeserializeObject<JArray>(result.Content);

                //var token = (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(result.Content));
                foreach (JObject item in token)
                {
                    returnValue = returnValue + item + "\r\n";

                   //var token = (JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(result.Content));//[0] as Newtonsoft.Json.Linq.JObject)["OrderId"];

                    OrderStatusForAccessionNumber_Output teletipResult_Output = new OrderStatusForAccessionNumber_Output();

                    teletipResult_Output.AccessionNumber = (string)item["AccessionNumber"];
                    teletipResult_Output.CitizenId = (string)item["CitizenId"];
                    teletipResult_Output.TeletipStatus = (string)item["TeletipStatus"];
                    teletipResult_Output.TeletipStatusId = (string)item["TeletipStatusId"];
                    teletipResult_Output.WadoStatus = (string)item["WadoStatus"];
                    teletipResult_Output.WadoStatusId = (string)item["WadoStatusId"];
                    teletipResult_Output.MedulaStatus = (string)item["MedulaStatus"];
                    teletipResult_Output.MedulaStatusId = (string)item["MedulaStatusId"];
                    teletipResult_Output.MedulaInstitutionId = (string)item["MedulaInstitutionId"];
                    teletipResult_Output.SutCode = (string)item["SutCode"];
                    teletipResult_Output.LastMedulaSendDate = (string)item["LastMedulaSendDate"];
                    teletipResult_Output.MedulaResponseCode = (string)item["MedulaResponseCode"];
                    teletipResult_Output.MedulaResponseMessage = (string)item["MedulaResponseMessage"];
                    teletipResult_Output.ReportStatus = (string)item["ReportStatus"];
                    teletipResult_Output.ReportStatusId = (string)item["ReportStatusId"];
                    teletipResult_Output.ScheduleDate = (string)item["ScheduleDate"];
                    teletipResult_Output.PerformedDate = (string)item["PerformedDate"];
                    teletipResult_Output.Error = (string)item["Error"];
                    teletipResult_Output.PatientHistorySearchStatus = (string)item["PatientHistorySearchStatus"];
                    teletipResult_Output.PatientHistorySearchStatusId = (string)item["PatientHistorySearchStatusId"];

                    accessionNumber_Outputs.Add(teletipResult_Output);

                }
                return accessionNumber_Outputs;

            }

            return null;
        }


    }
}

namespace Core.Models
{
    public partial class TeletipWorkListViewModel
    {
        public List<OrderStatusForAccessionNumber_Output> TeletipActionList;
        public TeletipWorkListSearchCriteria _sterilizationWorkListSearchCriteria
        {
            get;
            set;
        }

        public TeletipWorkListViewModel()
        {
            this._sterilizationWorkListSearchCriteria = new TeletipWorkListSearchCriteria();
            this.TeletipActionList = new List<OrderStatusForAccessionNumber_Output>();
        }
    }

    [Serializable]
    public class TeletipWorkListSearchCriteria
    {
        public string uniqueRefNo
        {
            get;
            set;
        }

        public string accessionno
        {
            get;
            set;
        }

        public DateTime? workListStartDate { get; set; }
        public DateTime? workListEndDate { get; set; }

        public TeletipWorkListSearchCriteria()
        {
        }
    }
       
    public class OrderStatusForAccessionNumber_Output
    {
        public string AccessionNumber { get; set; }
        public string CitizenId { get; set; }
        public string TeletipStatus { get; set; }
        public string TeletipStatusId { get; set; }// 1 (Eşleşti), 2 (Eşleşmedi), 3 (Kayıt Bulunamadı)
        public string WadoStatus { get; set; }
        public string WadoStatusId { get; set; }//1 (Görüntü İndirildi),2 (Görüntü İndirilemedi),3 (Görüntü Tekrarı)
        public string MedulaStatus { get; set; }
        public string MedulaStatusId { get; set; }//1 (Medulaya Gönderildi), 2 (Medulaya Gönderilmedi)
        public string MedulaInstitutionId { get; set; }
        public string SutCode { get; set; }
        public string LastMedulaSendDate { get; set; }
        public string MedulaResponseCode { get; set; }
        public string MedulaResponseMessage { get; set; }
        public string ReportStatus { get; set; }
        public string ReportStatusId { get; set; }//1 (Rapor Geldi), 2 (Rapor Gelmedi)
        public string ScheduleDate { get; set; }
        public string PerformedDate { get; set; }
        public string Error { get; set; }//"İstem geldi - Tetkik gelmedi yada eşleşmedi / Tetkik geldi - İstem gelmedi yada eşleşmedi / İstem ve tetkik bilgisi bulunamadı”
        public string PatientHistorySearchStatus { get; set; }
        public string PatientHistorySearchStatusId { get; set; }
    }

    class ParameterClass
    {
        public string MedulaInstitutionId
        {
            get;
            set;
        }

        public Array AccessionNumberList
        {
            get;
            set;
        }
    }

}