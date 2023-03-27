
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

using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Data.Common;
using System.Threading;
using System.IO;

namespace TTObjectClasses
{
    /// <summary>
    /// Teletıp Yeniden Eşleştir
    /// </summary>
    public  partial class ReProcessStudy : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "ReProcessStudy Has Started : " + Common.RecTime();

            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    string medulaTesisKodu = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("REPROCESSSTUDYSTARTDAYLIMIT", "5"));// x gün öncendinden
                    int dateLimit2 = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("REPROCESSSTUDYENDDAYLIMIT", "0"));//x gün öncesine kdar olan aralık

                    //int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("REPROCESSSTUDYSTARTDAYLIMIT", "59"));// x gün öncendinden
                    //int dateLimit2 = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("REPROCESSSTUDYENDDAYLIMIT", "35"));//x gün öncesine kdar olan aralık

                    for (int j = 0; j < dateLimit - dateLimit2; j++)
                    {
                        List<string> returnValue = GetNonMatchingOrder(medulaTesisKodu, (dateLimit - j), (dateLimit - (j + 1)));//gün gün çeksin çok vri gelirse sınır var
                        List<string> mainAccessionList = new List<string>();

                        string filter = " where accessıonnumber IN ( '1'";

                        if (returnValue != null && returnValue.Count > 0)
                        {
                            foreach (string item in returnValue)
                            {
                                filter += ",'" + item + "'";
                            }

                            filter += ")";

                            DbConnection dbConnection = ConnectionManager.CreateConnection();
                            dbConnection.Open();

                            try
                            {
                                string sql = " Select mainaccessionnumber from pacsulus.studyaccnum@hbys " + filter;

                                DbCommand cmd = ConnectionManager.CreateCommand(sql, dbConnection);
                                DbDataAdapter adap = ConnectionManager.CreateDataAdapter(cmd);
                                DataSet ds = new DataSet("DataSet");
                                adap.Fill(ds);
                                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                                {
                                    string emptyLog = filter + " numaralı accessionlar için mainaccessionno bulunamadığı için metod çalıştırılamadı";
                                    AddLog(emptyLog);
                                }
                                else
                                {
                                    string mainAccessionLog = "Dönen MainAccession Listesi";
                                    foreach (DataRow row in ds.Tables[0].Rows)
                                    {
                                        mainAccessionList.Add(row[0].ToString());
                                        mainAccessionLog += row[0].ToString() + ",";
                                    }
                                    AddLog(mainAccessionLog);
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                dbConnection.Close();
                                dbConnection.Dispose();
                            }

                            if (mainAccessionList.Count > 0)
                            {
                                for (int i = 0; i < mainAccessionList.Count; i++)
                                {

                                    ReprocessStudy(medulaTesisKodu, mainAccessionList[i]);
                                    Thread.Sleep(100);

                                }
                            }

                        }
                    }

                }

                logTxt += " - Has Finished Succesfully : " + Common.RecTime();
                AddLog(logTxt);
            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
                AddLog(logTxt);
            }
        }

        #region TELETIP SERVİSLERİ
        public List<string> GetNonMatchingOrder(string medulaTesisKodu,int startDate , int endDate)
        {
            List<string> returnValue = new List<string>();
            string logTxt = "Eşleşmeyen accessionNO Listesi =";
            ResendReqandReportTeletip resend = new ResendReqandReportTeletip();

            DateTime tempStart= DateTime.Now.AddDays(startDate * (-1));
            DateTime tempEnd = DateTime.Now.AddDays(endDate * (-1));


            string accessToken = resend.getTokenForTeletip();

            NonMatchingOrder parameter = new NonMatchingOrder();
            parameter.MedulaInstitutionId = medulaTesisKodu;
            parameter.Modality = null;
            parameter.StartDateTime = new DateTime(tempStart.Year, tempStart.Month, tempStart.Day);
            parameter.EndDateTime = new DateTime(tempEnd.Year, tempEnd.Month, tempEnd.Day);

            logTxt += " Tarih Aralığı =" + parameter.StartDateTime.ToShortDateString() + " - " + parameter.EndDateTime.ToShortDateString() + "- ";

            string ss = JsonConvert.SerializeObject(parameter);
            Uri uri = new Uri("http://xxxxxx.com/Common.WebApi/api/Integration/GetNonMatchingOrderList?nonMatchingParameter=" + ss);

            RestClient client = new RestClient(uri);
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            string bearerToken = "Bearer " + accessToken;
            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
            IRestResponse result = client.Execute(request);

            if (result.StatusCode.ToString() == "OK")
            {
                JArray token = JsonConvert.DeserializeObject<JArray>(result.Content);
                foreach (JValue item in token)
                {
                    returnValue.Add(item.Value.ToString());
                    logTxt += item.Value.ToString() + ",";
                }

            }

            AddLog(logTxt);
            return returnValue;
        }

        public string ReprocessStudy(string medulaTesisKodu, string accesionList)
        {
            string returnValue = string.Empty;
            ResendReqandReportTeletip resend = new ResendReqandReportTeletip();
            string accessToken = resend.getTokenForTeletip();

            ReprocessStudyClass parameter = new ReprocessStudyClass();
            parameter.MedulaInstitutionId = Convert.ToInt32(medulaTesisKodu);
            parameter.AccessionNumber = accesionList;

            string ss = JsonConvert.SerializeObject(parameter);
            Uri uri = new Uri("http://xxxxxx.com/Common.WebApi/api/Integration/ReProcessStudy");

            RestClient client = new RestClient(uri);
            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            string bearerToken = "Bearer " + accessToken;
            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
            request.AddParameter("MedulaInstitutionId", medulaTesisKodu, ParameterType.GetOrPost);
            request.AddParameter("AccessionNumber", accesionList, ParameterType.GetOrPost);
            IRestResponse result = client.Post(request);

            if (result.StatusCode.ToString() == "OK")
            {
                JArray token = JsonConvert.DeserializeObject<JArray>(result.Content);
                //returnValue = token.ToString();
                foreach (JValue item in token)
                {
                    returnValue = returnValue + item + "\r\n";

                }

            }
            else
            {
                returnValue += JsonConvert.DeserializeObject<JObject>(result.Content)["Message"] + " => " + accesionList + "\r\n";
            }

            returnValue += "---------------\r\n";

            if (!string.IsNullOrEmpty(returnValue))
            {
                AddLog("MainAcession=" + accesionList);
                AddLog(returnValue);
            }
            return "";
        }

        public void AddLog2(string log)
        {
            string path = @"D:\TeletipLog.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(log);
                sw.WriteLine("----------------------------------------------------------------------------------------------------");
            }
        }
        #endregion

        #region CLASSES

        class NonMatchingOrder
        {
            public string MedulaInstitutionId { get; set; }
            public string Modality { get; set; }
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
        }

        class ReprocessStudyClass
        {
            public int MedulaInstitutionId
            {
                get;
                set;
            }

            public string AccessionNumber { get; set; }
        }
        #endregion
    }
}