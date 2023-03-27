
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
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Threading;

namespace TTObjectClasses
{
    public partial class ResendReqandReportTeletip : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "ResendReqandReportTeletip Has Started : " + Common.RecTime();
            try
            {

                List<RadiologyTest.GetAllRadiologyWithFilter_Class> radiologyTestList = new List<RadiologyTest.GetAllRadiologyWithFilter_Class>();

                int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("RESENDREQANDREPORTTELETIPXDAYS", "10"));
                string _filter = " WHERE ISMESSAGEINTELETIP = 0 AND ACCESSIONNO IS NOT NULL AND ISMESSAGEINPACS = 1 " +
                                 //" AND ACCESSIONNO=92588 "+
                                 " AND REQUESTDATE BETWEEN TODATE('" + Convert.ToDateTime(Common.RecTime().Date.AddDays(-dateLimit)).ToString("yyyy-MM-dd HH:mm:ss") + "') " +
                                 " AND TODATE('" + Convert.ToDateTime(Common.RecTime().Date.AddDays(1)).ToString("yyyy-MM-dd HH:mm:ss") + "')" +
                                 " ORDER BY REQUESTDATE DESC";

                radiologyTestList = RadiologyTest.GetAllRadiologyWithFilter(_filter).ToList();

                List<string> _list = radiologyTestList.Select(x => x.AccessionNo.ToString()).ToList<string>();

                foreach (RadiologyTest.GetAllRadiologyWithFilter_Class rt in radiologyTestList)
                {
                    try
                    {
                        using (TTObjectContext objectContext = new TTObjectContext(false))
                        {
                            //for (int i = 0; i <= radiologyTestList.Count / 10; i++)
                            //for (int i = 0; i <= radiologyTestList.Count; i++)
                            //{

                            //List<OrderStatusForAccessionNumber_Output> accessionNumber_Outputs = GetResponse(_list);//.Skip(i * 10).Take(10)
                            List<OrderStatusForAccessionNumber_Output> accessionNumber_Outputs = GetResponse(rt.AccessionNo);
                            foreach (OrderStatusForAccessionNumber_Output item in accessionNumber_Outputs)
                            {
                                try
                                {
                                    //var objectID = radiologyTestList.Where(x => x.AccessionNo.Value.ToString() == item.AccessionNumber);
                                    List<Guid> appIDs = new List<Guid>();
                                    //Guid objectIDGuid = new Guid(rt.ObjectID.ToString());
                                    appIDs.Add(rt.ObjectID.Value);
                                    RadiologyTest rTest = (RadiologyTest)objectContext.GetObject(rt.ObjectID.Value, "RADIOLOGYTEST");

                                    if (rTest.ExternalServiceRequests.Count <= 0)
                                    {
                                        string logInfo = "ObjectID = " + rt.ObjectID + "Accessionno = " + rt.AccessionNo + " i�in ";

                                        if (item.TeletipStatusId == "3")
                                        {
                                            var resultTeletip = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(appIDs, "O01", "TELETIP");
                                            rTest.IsMessageInTELETIP = resultTeletip.Item1;
                                            rTest.ACKMessageTELETIP = resultTeletip.Item2;

                                            logInfo += " O01 mesaj� rTest.IsMessageInTELETIP =" + rTest.IsMessageInTELETIP + " rTest.ACKMessageTELETIP=" + rTest.ACKMessageTELETIP;

                                            if (resultTeletip.Item1 == true && rTest.CurrentStateDefID == RadiologyTest.States.Reported)
                                            {
                                                var resultTeletip1 = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(appIDs, "R01", "TELETIP");
                                                rTest.IsMessageInTELETIP = resultTeletip1.Item1;
                                                rTest.ACKMessageTELETIP = resultTeletip1.Item2;

                                                logInfo += " R01 mesaj� rTest.IsMessageInTELETIP =" + rTest.IsMessageInTELETIP + " rTest.ACKMessageTELETIP=" + rTest.ACKMessageTELETIP;
                                            }


                                        }
                                        else if (item.ReportStatusId == "2")//Rapor gelmedi
                                        {
                                            if (rTest.CurrentStateDefID == RadiologyTest.States.Reported)
                                            {
                                                var resultTeletip1 = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(appIDs, "R01", "TELETIP");
                                                rTest.IsMessageInTELETIP = resultTeletip1.Item1;
                                                rTest.ACKMessageTELETIP = resultTeletip1.Item2;

                                                logInfo += " R01 mesaj� rTest.IsMessageInTELETIP =" + rTest.IsMessageInTELETIP + " rTest.ACKMessageTELETIP=" + rTest.ACKMessageTELETIP;
                                            }
                                        }

                                        
                                        AddLog(logInfo);
                                    }

                                }
                                catch (Exception e)
                                {
                                    string _error = "ObjectID = " + rt.ObjectID + "Accessionno = " + rt.AccessionNo + " " + e.Message + (e.InnerException != null ? e.InnerException.Message : "");
                                    //logTxt = p.ObjectID + "id'li ve " + p.UniqueRefNo + " kimlik numaral� hasta i�in 101 paketi at�lamad�. Al�nan hata: " + _error;
                                    AddLog(_error);
                                }
                                finally
                                {
                                    objectContext.Save();
                                }
                                Thread.Sleep(100);

                            }

                            //}

                        }
                    }

                    catch (Exception e)
                    {
                        string _error = "ObjectID = " + rt.ObjectID + "Accessionno = " + rt.AccessionNo + " " + e.Message + (e.InnerException != null ? e.InnerException.Message : "");
                        //logTxt = p.ObjectID + "id'li ve " + p.UniqueRefNo + " kimlik numaral� hasta i�in 101 paketi at�lamad�. Al�nan hata: " + _error;
                        AddLog(_error);
                    }
                }

                logTxt += " - Has Finished Succesfully : " + Common.RecTime();

            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
                AddLog(logTxt);
            }
        }

        #region TELETIP SORGULAMA SERVI�S�
        public string getTokenForTeletip()
        {
            string clientId = "HBYSPACSViewerClient";
            string clientSecret = "HbPatT!180430#KnYLm";
            string identityServerBaseUri = "http://xxxxxx.com";
            RestClient client = new RestClient(identityServerBaseUri + "/connect/token");
            client.UserAgent = " ";
            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            request.AddParameter("grant_type", "password", ParameterType.GetOrPost);
            request.AddParameter("USERNAME", "XXXXXX", ParameterType.GetOrPost);
            request.AddParameter("PASSWORD", "XXXXXX", ParameterType.GetOrPost);
            request.AddParameter("scope", "openid profile custom.profile AuthorizationWebApi Common.WebApi GYM.Authentication.WebApiCore", ParameterType.GetOrPost);
            string basicAuthorizationHeaderContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret));
            request.AddParameter("Authorization", string.Format("Basic " + basicAuthorizationHeaderContent), ParameterType.HttpHeader);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                JObject tokenResponse = JsonConvert.DeserializeObject(response.Content) as JObject;
                return (string)tokenResponse.Property("access_token").Value;
            }
            return "";
        }

        //public List<OrderStatusForAccessionNumber_Output> GetResponse(List<string> accesionList)
        public List<OrderStatusForAccessionNumber_Output> GetResponse(string accessionno)
        {
            string returnValue = string.Empty;
            string accessToken = getTokenForTeletip();

            List<string> accesionList = new List<string>();
            accesionList.Add(accessionno);

            List<OrderStatusForAccessionNumber_Output> accessionNumber_Outputs = new List<OrderStatusForAccessionNumber_Output>();

            ParameterClass parameter = new ParameterClass();
            parameter.MedulaInstitutionId = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX")); ;
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

                    //teletipResult_Output.PerformedDate = item["PerformedDate"] != null ? (string)item["PerformedDate"] :"";
                    //teletipResult_Output.RequestedProcedureDescription = (string)item["RequestedProcedureDescription"];
                    //teletipResult_Output.IsStudyExist = (bool)item["IsStudyExist"];
                    //teletipResult_Output.IsReportExist = (bool)item["IsReportExist"];

                    accessionNumber_Outputs.Add(teletipResult_Output);


                }
            }
            return accessionNumber_Outputs;
            //if (!string.IsNullOrEmpty(returnValue))
            //{

            //    //txtSonuc.Text += returnValue;
            //    //string fileName = " Sonuc_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss" + ".txt");
            //    //using (FileStream fs = File.Create(fileName))
            //    //{
            //    //    byte[] title = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(returnValue);
            //    //    fs.Write(title, 0, title.Length);
            //    //    //byte[] author = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("Mahesh Chand");
            //    //    //fs.Write(author, 0, author.Length);
            //    //}
            //}
        }
        #endregion

        #region CLASSES
        public class OrderStatusForAccessionNumber_Output
        {
            public string AccessionNumber { get; set; }
            public string CitizenId { get; set; }
            public string TeletipStatus { get; set; }
            public string TeletipStatusId { get; set; }// 1 (E�le�ti), 2 (E�le�medi), 3 (Kay�t Bulunamad�)
            public string WadoStatus { get; set; }
            public string WadoStatusId { get; set; }//1 (G�r�nt� �ndirildi),2 (G�r�nt� �ndirilemedi),3 (G�r�nt� Tekrar�)
            public string MedulaStatus { get; set; }
            public string MedulaStatusId { get; set; }//1 (Medulaya G�nderildi), 2 (Medulaya G�nderilmedi)
            public string MedulaInstitutionId { get; set; }
            public string SutCode { get; set; }
            public string LastMedulaSendDate { get; set; }
            public string MedulaResponseCode { get; set; }
            public string MedulaResponseMessage { get; set; }
            public string ReportStatus { get; set; }
            public string ReportStatusId { get; set; }//1 (Rapor Geldi), 2 (Rapor Gelmedi)
            public string ScheduleDate { get; set; }
            public string PerformedDate { get; set; }
            public string Error { get; set; }//"�stem geldi - Tetkik gelmedi yada e�le�medi / Tetkik geldi - �stem gelmedi yada e�le�medi / �stem ve tetkik bilgisi bulunamad��
        }

        public class ParameterClass
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
        #endregion
    }
}