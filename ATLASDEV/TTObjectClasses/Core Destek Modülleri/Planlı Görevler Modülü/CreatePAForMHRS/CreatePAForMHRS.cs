
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
using Newtonsoft.Json.Linq;
using static TTObjectClasses.PatientAdmission;
using System.Data.Common;
using System.Threading;
using System.IO;
using static TTObjectClasses.HastaKabulIslemleri;

namespace TTObjectClasses
{
    /// <summary>
    /// MHRS Randevuları için otomatik kabul oluşturur
    /// </summary>
    public partial class CreatePAForMHRS : BaseScheduledTask
    {
        private readonly static string DefaultHospitalURL = "http://X.X.X.X/api/";
        public override void TaskScript()
        {
            string logTxt = "CreatePAForMHRS Has Started : " + Common.RecTime();

            try
            {
                using (var objectContext = new TTObjectContext(false))
                {

                    int time = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSKABULARALIGI", "10"));

                    List<Patient> pList = new List<Patient>();
                    string timefilter = " AND THIS.STARTTIME BETWEEN TODATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "') and TODATE('" + DateTime.Now.AddMinutes(time).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    List<Appointment> app = Appointment.GetActiveMHRSAppointmentsByDate(objectContext, DateTime.Now.Date, timefilter).ToList();


                    foreach (var item in app)
                    {
                        try
                        {
                            MHRS_PA_InputDTO _InputDTO = new MHRS_PA_InputDTO();

                            if (item.Patient != null)
                            {
                                _InputDTO.UniquerefNo = item.Patient.UniqueRefNo.Value;
                                //_InputDTO.DepartmentID = new Guid("3c886f14-fd01-4e88-8f3a-d4921c658dc8");
                                //_InputDTO.PoliclinicID = new Guid("405b4699-a45b-4508-b300-c151098bf685");
                                //_InputDTO.DoctorID = new Guid("abba26fc-afff-481a-be49-0c733b003ec8");
                                _InputDTO.AppointmentID = item.ObjectID;
                                _InputDTO.PoliclinicName = item.MasterResource.Name;
                                _InputDTO.DoctorName = item.Resource.Name;


                                var rr = getMustehaklikKapsamKoduSync(_InputDTO);

                                if (rr.sonucKodu == "0000")
                                {
                                    AddLog("AppointmentID = " + _InputDTO.AppointmentID + " Müstehaklık kontrolü başarılı");
                                    SaveAdmission(_InputDTO);
                                }
                                else
                                {
                                    AddLog("AppointmentID = " + _InputDTO.AppointmentID + " Müstehaklık kontrolü başarısız olduğu için işleme devam edilemiyor.sonuç kodu=" + rr.sonucKodu + " " + rr.sonucMesaji);
                                    SendSMS(_InputDTO.PoliclinicName + " Polikliniğindeki" + _InputDTO.DoctorName + " isimli doktora olan randevunuza ait müstehaklık sorgulaması başarısız oldu. Lütfen sekreterlik bankosuna başvurunuz.", _InputDTO.UniquerefNo, _InputDTO.AppointmentID, SMSTypeEnum.AppointmentInfoSMS);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
                            AddLog(logTxt);
                        }
                    }

                    logTxt += " - Has Finished Succesfully : " + Common.RecTime();
                    AddLog(logTxt);


                }
            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
                AddLog(logTxt);
            }
        }

        public string getToken()
        {
            string appUrl = TTObjectClasses.SystemParameter.GetParameterValue("ATLASSERVICEURL", DefaultHospitalURL);//DefaultHospitalURL;

            Uri uri = new Uri(appUrl + "account/authenticate");

            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST);
            var loginViewModel = new { username = "ttcomm", password = "" };
            request.AddJsonBody(loginViewModel);
            IRestResponse response = client.Execute(request);
            if (response != null && response.ResponseStatus == ResponseStatus.Completed)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var errorMessage = response.Content;
                    var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                    if (errorObject != null)
                    {
                        var error = errorObject.Value<string>("error");
                        var detailedError = errorObject.Value<string>("detailedError");
                        errorMessage = error;
                    }
                    throw new TTException($"{response.StatusCode}-{errorMessage}");
                }
            }

            var webApiErrorMessage = response.ErrorException != null ? response.ErrorException.ToString() : response.ErrorMessage;
            if (string.IsNullOrWhiteSpace(webApiErrorMessage) == false)
            {
                throw new TTException($"{response.StatusCode}-{webApiErrorMessage}");
            }

            var obj = JsonConvert.DeserializeObject(response.Content) as JObject;
            var valueObj = obj.GetValue("Value") as JObject;
            var accessToken = valueObj.Property("access_token");
            return (string)accessToken.Value;
        }

        public void SaveAdmission(MHRS_PA_InputDTO _InputDTO)
        {
            try
            {
                string AppUrl = TTObjectClasses.SystemParameter.GetParameterValue("ATLASSERVICEURL", DefaultHospitalURL);//DefaultHospitalURL;
                string accessToken = string.Empty;

                try
                {
                    accessToken = getToken();

                }
                catch (Exception ex)
                {
                    AddLog("Token alınırken bir hata ile karşılaşıldı." + ex.Message.ToString());
                }

                //Patient p = Patient.GetPatientsByUniqueRefNo(objectContext, 10000000000).FirstOrDefault();
                //if (p == null)
                //{
                //    p = new Patient(objectContext);
                //    p.UniqueRefNo = 10000000000;
                //}


                string ss = JsonConvert.SerializeObject(_InputDTO);
                Uri uri = new Uri(AppUrl + "PatientAdmissionService/SavePAByMHRSInfo");

                RestClient client = new RestClient(uri);
                RestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.Parameters.Clear();
                string bearerToken = "Bearer " + accessToken;
                request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", ss, ParameterType.RequestBody);
                //request.AddParameter("p", p, ParameterType.GetOrPost);
                //request.AddJsonBody(p);

                IRestResponse result = client.Execute(request);

                var perfResult = JsonConvert.DeserializeObject<JObject>(result.Content);

                if (result.IsSuccessful)
                {
                    if ((bool)perfResult["IsSuccess"] == true)
                    {
                        if (perfResult["Result"]["MedulaErrorMessage"] != null && perfResult["Result"]["MedulaErrorMessage"].ToString() == "ProvisionError")
                        {
                            string objID = "";
                            foreach (JToken item in perfResult["Result"]["UpdatedObjects"])
                            {
                                if ((string)item["ObjectDefID"] == "417114a6-5caa-4613-ab25-7ef4b28f5f82")
                                {
                                    objID = (string)item["ObjectID"];
                                    break;
                                }
                            }

                            PatientAdmission pa = JsonConvert.DeserializeObject<PatientAdmission>(result.Content);

                            //try
                            //{
                            //    Guid aa = new Guid(objID);
                            //    DeletePA(aa);

                            AddLog("AppointmentID = " + _InputDTO.AppointmentID + " Provizyon alınamadı. - " + perfResult["Result"]["MedulaErrorMessage"].ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    AddLog("AppointmentID = " + _InputDTO.AppointmentID + " Provizyon alınamayan kabul silinirken hata alındı. - " + ex.Message);
                            //}

                            SendSMS(_InputDTO.PoliclinicName + " Polikliniğindeki" + _InputDTO.DoctorName + " isimli doktora olan randevunuz ile ilgili provizyon işlemlerinde problem oluşmuştur.Lütfen sekreter bankosuna başvurunuz.", _InputDTO.UniquerefNo, _InputDTO.AppointmentID, SMSTypeEnum.AppointmentInfoSMS);

                        }
                        else
                        {
                            AddLog("AppointmentID = " + _InputDTO.AppointmentID + " Başarılı bir şekilde kabul oluşturuldu.");
                            SendSMS(_InputDTO.PoliclinicName + " Polikliniğindeki" + _InputDTO.DoctorName + " isimli doktora olan randevunuz onaylanmıştır, lütfen randevu saatinizde " + _InputDTO.PoliclinicName + " polikliniğinde önünde olunuz.", _InputDTO.UniquerefNo, _InputDTO.AppointmentID, SMSTypeEnum.AppointmentInfoSMS);
                        }
                    }
                    else
                    {
                        AddLog("AppointmentID = " + _InputDTO.AppointmentID + "Kabul alma sırasında bir hata ile karşılaşıldı. - " + perfResult["Message"].ToString());
                        SendSMS(_InputDTO.PoliclinicName + " Polikliniğindeki" + _InputDTO.DoctorName + " isimli doktora kabul alma işlemi sırasında hata oluştu. Lütfen sekreterlik bankosuna başvurunuz.", _InputDTO.UniquerefNo, _InputDTO.AppointmentID, SMSTypeEnum.AppointmentInfoSMS);
                    }


                    //if (perfResult["Result"]["Message"] != null)
                    //{
                    //    AddLog("KAbul alma sırasında bir hata ile karşılaşıldı.AppointmentID=" + _InputDTO.AppointmentID + " - " + perfResult["Result"]["Message"].ToString());
                    //    SendSMS(_InputDTO.PoliclinicName + " Polikliniğindeki" + _InputDTO.DoctorName + " isimli doktora olan muayenenizin kaydı için muayene saatinizden 30 dakika önce sekreter bankosuna başvurmanız gerekmektedir.", _InputDTO.UniquerefNo);
                    //}

                }
                else
                {
                    AddLog("AppointmentID = " + _InputDTO.AppointmentID + "Servis çağrımı sırasında bir hata ile karşılaşıldı." + result.ErrorMessage);
                    //sendsms
                }
            }
            catch (Exception ex)
            {
                AddLog("AppointmentID = " + _InputDTO.AppointmentID + "Servis çağrımı sırasında bir hata ile karşılaşıldı." + ex.Message);
                //throw;
            }
        }

        public mustehaklikCevapDVO getMustehaklikKapsamKoduSync(MHRS_PA_InputDTO _InputDTO)
        {
            //var result = HastaKabulIslemleri.WebMethods.getMustehaklikKapsamKoduSync(new Guid("2f501364-1f8c-4fe0-870a-840235a986ec"), input);
            try
            {
                mustehaklikGirisDVO dVO = new mustehaklikGirisDVO();
                dVO.tarih = DateTime.Now.ToString("dd.MM.yyyy");
                dVO.tcKimlikNo = _InputDTO.UniquerefNo;
                dVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                var result = getMustehaklikKapsamKoduSync_ServerSide(dVO);
                return result;
            }
            catch (Exception ex)
            {

               var result = new mustehaklikCevapDVO();
                result.sonucKodu = "HVL_1234";
                result.sonucMesaji = "Müstehaklık servisi hatası =" + ex.Message;

                return result;
            }
            
        }

        private static mustehaklikCevapDVO getMustehaklikKapsamKoduSync_ServerSide(mustehaklikGirisDVO mustehaklikGirisDVO)
        {

            #region getMustehaklikKapsamKoduSync_Body
            TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
            header.Namespace = "TTObjectClasses.HastaKabulIslemleri";
            header.ServiceId = "fa647881-43b8-41fd-b695-bb96ea30f112";
            header.MethodName = "getMustehaklikKapsamKodu";
            header.CallTimeout = 30;
            header.CallerId = TTUser.CurrentUser.UniqueRefNo;
            header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
            header.ServiceType = ServiceType.SOAP;
            IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("mustehaklikGirisDVO", (object)mustehaklikGirisDVO),
                    };

            TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
            credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME", "XXXXXX");
            credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD", "XXXXXX");

            mustehaklikCevapDVO cevap = default(mustehaklikCevapDVO);
            cevap = (mustehaklikCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
            return cevap;

            #endregion getMustehaklikKapsamKoduSync_Body

        }

        public void SendSMS(string message, long uniqueRefNo, Guid appointmentID, SMSTypeEnum smsType)
        {
            bool sendSMS = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SENDSMSFORMHRS", "TRUE"));

            if (sendSMS)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    UserMessage userMessage = new UserMessage();
                    bool success = false;
                    string phone = "";
                    Patient p = Patient.GetPatientsByUniqueRefNo(objectContext, uniqueRefNo).FirstOrDefault();

                    try
                    {
                        if (p != null)
                        {
                            List<Patient> patients = new List<Patient> { p };
                            success = userMessage.SendSMSPatient(patients, message, smsType);
                            phone = p.PatientAddress != null ? p.PatientAddress.MobilePhone : "";
                        }

                        if (success)
                        {
                            AddLog("AppointmentID = " + appointmentID + " " + p.FullName + " isimli hastanın " + phone + " numaralı telefonuna sms gönderilmiştir.SMS detayı=" + message);
                        }
                        else
                            AddLog("AppointmentID = " + appointmentID + " " + p.FullName + " isimli hastanın " + phone + " numaralı telefonuna sms gönderilememiştir.SMS detayı=" + message);

                    }
                    catch (Exception ex)
                    {
                        AddLog("AppointmentID = " + appointmentID + " " + p.FullName + " isimli hastanın " + phone + " numaralı telefonuna sms gönderilememiştir.SMS detayı=" + message + " - " + ex.Message);
                    }

                }
            }

        }

        public void DeletePA(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmission pa = objectContext.GetObject<PatientAdmission>(ObjectID, false) as PatientAdmission;
                if (pa != null)
                {
                    PatientAdmission.DeletePatientAdmission(pa);
                    objectContext.Save();
                }
            }
        }

        public void AddLog3(string log)
        {
            string path = @"D:\MHRS.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(log);
                sw.WriteLine("----------------------------------------------------------------------------------------------------");
            }
        }

        #region ESKİ token
        //private string getToken1()
        //{
        //    string AppUrl = TTObjectClasses.SystemParameter.GetParameterValue("ATLASSERVICEURL", DefaultHospitalURL);//DefaultHospitalURL;
        //    string userName = "ttcomm";
        //    string password = "1";

        //    var requestUri = $"account/authenticate";
        //    var client = new RestClient($"{AppUrl}/{requestUri}");
        //    var request = new RestRequest();

        //    request.Method = Method.POST;
        //    request.AddParameter("username", userName, ParameterType.GetOrPost);
        //    request.AddParameter("password", password, ParameterType.GetOrPost);
        //    request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //    IRestResponse response = client.Execute(request);
        //    if (string.IsNullOrEmpty(response.Content))
        //        return null;
        //    var obj = JsonConvert.DeserializeObject(response.Content) as JObject;
        //    //Token alınamadı hatasının LOG'u SCHEDULEDTASKHISTORY tablsundan bakılacak
        //    if (obj == null)
        //        return "";
        //    var accessToken = obj.Property("access_token");
        //    string returnValue = (string)accessToken.Value;

        //    return returnValue;
        //}
        #endregion

        #region CLASS
        public class ResultDTO
        {
            public Guid ObjectID
            {
                get;
                set;
            }

            public string Message
            {
                get;
                set;
            }
            public string MedulaErrorMessage
            {
                get;
                set;
            }
            //public MedulaTransferredPayerWarningDTO medulaTransferredPayerWarningDTO { get; set; } = new MedulaTransferredPayerWarningDTO();
        }


        #endregion
    }
}