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

using static TTObjectClasses.InPatientTreatmentClinicApplication;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static TTConnectionManager.ConnectionManager;
using Microsoft.VisualBasic;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace TTObjectClasses
{
    public abstract partial class Common : TTObject
    {


        #region Methods
        private static Dictionary<string, string> GetNameSpaceServiceMap()
        {
            Dictionary<string, string> nameSpaceServiceMap = new Dictionary<string, string>();
            nameSpaceServiceMap.Add("TTObjectClasses.HizmetKayitIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.IlacRaporuServis", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.SevkIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.FaturaKayitIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.HastaKabulIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.EReceteIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.YardimciIslemler", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.IsGormezlikServis", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.RaporIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.MedulaYardimciIslemler", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.TaahhutIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.TakipFormuIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.OrtodontiIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.KanUrunYonetim", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.KanBagisiServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.PTSPackageReceiverServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.ITSUrunDogrulamaServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.ITSSarfBildirimServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.ITSReceiptNotification", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.ITSCheckStatusNotification", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.ITSDeaktivasyonServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.ITSStakeHolderServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.Acil112Servis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.MernisServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.OptikRaporIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.OptikReceteIslemleri", "Medula");
            nameSpaceServiceMap.Add("TTObjectClasses.KPSKimlikNoSorgulaAdresServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.KPSKisiSorgulaKimlikNoServis", "Internet");
            nameSpaceServiceMap.Add("TTObjectClasses.SKRSSistemlerServis", "Internet");
            return nameSpaceServiceMap;
        }

        private readonly static Dictionary<string, DateTime> _failedOrchestratorNodeList = new Dictionary<string, DateTime>();
        private readonly static object _padLockFailedOrchestratorNodeList = new object();
        private volatile static bool _failedOrchestratorNodeCheckStarted;
        private static long _failedOrchestratorNodeLastCheckTime = 0;
        private static void SetOrchestratorNodeFailDate(string nodeAddress, DateTime failDate)
        {
            lock (_padLockFailedOrchestratorNodeList)
            {
                if (!_failedOrchestratorNodeList.ContainsKey(nodeAddress))
                {
                    _failedOrchestratorNodeList[nodeAddress] = failDate;
                }
            }
        }

        private static void RemoveOrchestratorFailDate(string nodeAddress)
        {
            lock (_padLockFailedOrchestratorNodeList)
            {
                _failedOrchestratorNodeList.Remove(nodeAddress);
            }
        }

        private readonly static string EchoMessage = "OK";

        private static bool CheckOrchestratorAccessible(string address)
        {
            try
            {
                var client = new RestClient(address);
                var request = new RestRequest("api/Orchestrator/WebMethodCall", RestSharp.Method.POST);
                request.AddHeader("Accept", "application/json");
                if (TTUtils.ActiveUserService.Instance == null)
                    throw new TTException("Aktif kullanıcı servisi atanmamış. Kullanıcı erişim anahtarı olmadan Orchestrator servisi çağrılamaz.");
                var accessToken = TTUtils.ActiveUserService.Instance.GetAccessToken();
                if (string.IsNullOrWhiteSpace(accessToken) == true)
                    throw new Exception("Kullanıcı erişim anahtarı boş olarak döndü, Orchestrator servis çarısı gerçekleştirilemeyecek.");
                request.AddParameter("Authorization", string.Format("Bearer " + accessToken), ParameterType.HttpHeader);

                var input = new
                {
                    Message = EchoMessage,
                };
                var jsonContent = JsonConvert.SerializeObject(input, JsonSerializerSettingsForWriting);
                request.AddParameter("application/json", jsonContent, ParameterType.RequestBody);
                var response = client.Execute(request);
                if (response != null && response.ResponseStatus == ResponseStatus.Completed)
                {
                    if (response.Content.ToString() == EchoMessage)
                        return true;
                }
            }
            catch (Exception ex)
            {
                TTUtils.Logger.WriteException(ex);
            }

            return false;
        }

        private static void CheckFailedOrchestratorNode(object param)
        {
            try
            {
                Dictionary<string, DateTime> failedNodeList = param as Dictionary<string, DateTime>;
                if (failedNodeList.Count == 0)
                    return;
                foreach (KeyValuePair<string, DateTime> failedNode in failedNodeList)
                {
                    try
                    {
                        // TODO: Call web method doesn't contain method echo
                        // TTutil checkout edilecek
                        if (CheckOrchestratorAccessible(failedNode.Key))
                        {
                            lock (_padLockFailedOrchestratorNodeList)
                            {
                                _failedOrchestratorNodeList.Remove(failedNode.Key);
                            }
                        }
                    }
                    catch
                    {
                        // zaten çalışmıyor olan orchestratora tekrar devreye girdimi diye çağrı yapıyoruz
                        // exception gelmesi (açılmadı ise) kuvvetle muhtemel
                        // exception gözardı edilecek
                    }
                }
            }
            finally
            {
                _failedOrchestratorNodeCheckStarted = false;
                System.Threading.Interlocked.Exchange(ref _failedOrchestratorNodeLastCheckTime, DateTime.Now.Ticks);
            }
        }

        private static void CheckFailedOrchestratorNode()
        {
            Dictionary<string, DateTime> failedNodeList = new Dictionary<string, DateTime>();
            lock (_padLockFailedOrchestratorNodeList)
            {
                foreach (KeyValuePair<string, DateTime> item in _failedOrchestratorNodeList)
                    failedNodeList.Add(item.Key, item.Value);
            }

            if (failedNodeList.Count == 0)
                return;
            TimeSpan diff = DateTime.Now - new DateTime(_failedOrchestratorNodeLastCheckTime);
            if (diff.TotalMilliseconds > 15000)
            {
                _failedOrchestratorNodeCheckStarted = true;
                System.Threading.Thread nodeCheckThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(CheckFailedOrchestratorNode));
                nodeCheckThread.Start(failedNodeList);
            }
        }

        private static string[] GetOrchestratorServerAddressList(string[] addressList)
        {
            List<string> serverAddressList = new List<string>();
            // Zaten 1 orchestrator varsa fail olsa bile kullanılacak
            if (addressList.Length == 1)
            {
                serverAddressList.AddRange(addressList);
                return serverAddressList.ToArray();
            }

            foreach (string address in addressList)
            {
                lock (_padLockFailedOrchestratorNodeList)
                {
                    if (!_failedOrchestratorNodeList.ContainsKey(address))
                    {
                        serverAddressList.Add(address);
                    }
                }
            }

            return serverAddressList.ToArray();
        }

        private static void HandleOrchestratorException(string nodeAddress, string methodName, Exception ex)
        {
            if (methodName == "ereceteGiris")
            {
                System.Net.WebException webException = TTUtils.Helpers.ExceptionHelper.GetExeception<System.Net.WebException>(ex);
                if (webException != null)
                {
                    if (webException.Status == System.Net.WebExceptionStatus.ProtocolError)
                    {
                        System.Net.HttpWebResponse response = webException.Response as System.Net.HttpWebResponse;
                        if (response != null && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            throw new TTUtils.TTException("E-reçete doktor şifresi hatalı, lütfen şifreyi kontrol ediniz");
                        }
                    }
                }

                if (ex.InnerException != null && ex.InnerException.Message.Contains("HTTP status 401: Unauthorized"))
                {
                    throw new TTUtils.TTException("E-reçete doktor şifresi hatalı, lütfen şifreyi kontrol ediniz");
                }
            }
        }

        public static object CallWebMethod(string ns, string methodName, params object[] parameters)
        {
            TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
            header.Namespace = ns;
            header.MethodName = methodName;
            header.SiteId = TTSite.CurrentSite.ID.ToString();
            header.CallerId = CurrentUser.UniqueRefNo;
            TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
            credential.UserName = string.Empty;
            credential.Password = string.Empty;
            return CallWebMethodWithHeader(header, credential, parameters);
        }

        public static object CallWebMethodV3(string ns, string methodName, string siteId, string username, string password, params object[] parameters)
        {
            TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
            header.Namespace = ns;
            header.MethodName = methodName;
            header.SiteId = siteId;
            header.CallerId = CurrentUser.UniqueRefNo;
            TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
            credential.UserName = username;
            credential.Password = password;
            return CallWebMethodWithHeader(header, credential, parameters);
        }

        public static object CallWebMethod(string ns, string methodName, string siteId, IWebMethodCredential credential, params object[] parameters)
        {
            TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
            header.Namespace = ns;
            header.MethodName = methodName;
            header.SiteId = siteId;
            header.CallerId = CurrentUser.UniqueRefNo;
            return CallWebMethodWithHeader(header, credential, parameters);
        }


        public static object CallWebMethodWithHeader(IWebMethodCallHeader header, IWebMethodCredential credential, params object[] parameters)
        {
            IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>();

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    callParameters.Add(Tuple.Create(i.ToString(), parameters[i]));
                }
            }

            return CallWebMethodWithHeader(header, credential, callParameters);
        }

        private static readonly string LogicalDataKey = "__HttpContext_Current__" + AppDomain.CurrentDomain.Id;


        public class TTWebMethodParameterConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(TTWebMethodParameter));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jsonObject = JObject.Load(reader);
                var typeName = jsonObject["TypeName"].ToString();
                var xml = jsonObject["_xml"].ToString();
                var webMethodParameter = new TTWebMethodParameter(typeName, xml);
                var compressed = jsonObject["_compressed"].ToObject<byte[]>();
                if (compressed != null)
                {
                    webMethodParameter._compressed = compressed;
                }
                return webMethodParameter;
            }

            public override bool CanWrite => false;

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        private readonly static Common.TTWebMethodParameterConverter WebMethodParameterConverter = new Common.TTWebMethodParameterConverter();
        private readonly static JsonSerializerSettings JsonSerializerSettingsForReading = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Converters = new JsonConverter[] { WebMethodParameterConverter },
        };
        private readonly static JsonSerializerSettings JsonSerializerSettingsForWriting = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
        };

        //_WebApi
        public static object CallWebMethodWithHeader(IWebMethodCallHeader header, IWebMethodCredential credential, IList<Tuple<string, object>> parameters)
        {
            string settingName = "INTERNETORCHESTRATORIP";
            Dictionary<string, string> nameSpaceServiceMap = GetNameSpaceServiceMap();
            if (nameSpaceServiceMap.ContainsKey(header.Namespace))
            {
                if (nameSpaceServiceMap[header.Namespace] == "Medula")
                {
                    settingName = "SGKORCHESTRATORIP";
                }
            }

            var callTimeout = header.CallTimeout;
            if (callTimeout > 0)
            {
                callTimeout = header.CallTimeout + 1;
            }

            string serverAddress = TTObjectClasses.SystemParameter.GetParameterValue(settingName, string.Empty);
            string[] orchestratorAddressList = GetOrchestratorServerAddressList(serverAddress.Split(';'));
            TTWebMethodParameter[] newParams;
            if (parameters == null || parameters.Count == 0)
                newParams = null;
            else
            {
                if (header.ServiceType == ServiceType.SOAP)
                {
                    newParams = new TTWebMethodParameter[parameters.Count];
                    for (int i = 0; i < parameters.Count; i++)
                        newParams[i] = new TTWebMethodParameter(parameters[i].Item1, parameters[i].Item2);

                }
                else if (header.ServiceType == ServiceType.REST)
                {
                    var method = header?.RestCallParameters?.HttpVerb ?? HttpVerbMethod.POST;
                    if (method == HttpVerbMethod.POST)
                    {
                        newParams = new TTWebMethodParameter[parameters.Count];
                        for (int i = 0; i < parameters.Count; i++)
                        {
                            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(parameters[i].Item2);
                            newParams[i] = new TTWebMethodParameter(parameters[i].Item1, (object)jsonContent);
                        }
                    }
                    else if (method == HttpVerbMethod.GET)
                    {
                        newParams = new TTWebMethodParameter[parameters.Count];
                        for (int i = 0; i < parameters.Count; i++)
                        {
                            newParams[i] = new TTWebMethodParameter(parameters[i].Item1, parameters[i].Item2);
                        }
                    }
                    else
                    {
                        throw new TTException("Unsupported http verb method type");
                    }
                }
                else
                {
                    throw new TTException("Unsupported service type");
                }
            }

            string nodeAddress = orchestratorAddressList.FirstOrDefault();

            var modifiednodeAddress = nodeAddress;
            bool localOrchestratorEnabled = System.Diagnostics.Debugger.IsAttached;//false; saha kullanımı için
            // A.Ş. Local orchestrator Open/ Close
            if (localOrchestratorEnabled)
                modifiednodeAddress = "http://localhost:5200";

            try
            {
                var client = new RestClient(modifiednodeAddress);
                var request = new RestRequest("api/Orchestrator/WebMethodCall", RestSharp.Method.POST);
                request.AddHeader("Accept", "application/json");
                if (TTUtils.ActiveUserService.Instance == null)
                    throw new TTException("Aktif kullanıcı servisi atanmamış. Kullanıcı erişim anahtarı olmadan Orchestrator servisi çağrılamaz.");
                var accessToken = TTUtils.ActiveUserService.Instance.GetAccessToken();
                if (string.IsNullOrWhiteSpace(accessToken) == true)
                    throw new Exception("Kullanıcı erişim anahtarı boş olarak döndü, Orchestrator servis çarısı gerçekleştirilemeyecek.");
                request.AddParameter("Authorization", string.Format("Bearer " + accessToken), ParameterType.HttpHeader);

                var input = new CallWebMethodInput()
                {
                    Header = header,
                    Credential = credential,
                    Parameters = newParams,
                };
                var jsonContent = JsonConvert.SerializeObject(input, JsonSerializerSettingsForWriting);
                request.AddParameter("application/json", jsonContent, ParameterType.RequestBody);
                var response = client.Execute(request);
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

                    var output = JsonConvert.DeserializeObject<CallWebMethodOutput>(response.Content, JsonSerializerSettingsForReading);
                    if (output != null && output.ReturnValue != null)
                    {
                        return output.ReturnValue.Deserialize(typeof(Common).Assembly, header.Namespace);
                    }
                }

                var webApiErrorMessage = response.ErrorException != null ? response.ErrorException.ToString() : response.ErrorMessage;
                if (string.IsNullOrWhiteSpace(webApiErrorMessage) == true)
                {
                    webApiErrorMessage = response.StatusDescription;
                }

                throw new TTException($"{response.StatusCode}-{webApiErrorMessage}");
            }
            catch (Exception ex)
            {
                // TODO: Asp.net core 2.0 geçişinde sadece aşağıdaki satır kaldırılacak
                HandleOrchestratorException(modifiednodeAddress, header.MethodName, ex);
                throw;

            }

        }

        public static Guid BashekimRoleID
        { //Başhekim
            get
            {
                return new Guid("d6694fe4-91cd-4a69-8166-e7362b3e2cd0");
            }
        }

        public static Guid NobetciBashekimRoleID
        { //Nöbetçi Başhekim
            get
            {
                return new Guid("8ab79e67-c544-403f-a13b-1ed529ac98fc");
            }
        }
        public static Dictionary<Guid, System.Threading.Thread> aliveScheduledTaskThreads = new Dictionary<Guid, System.Threading.Thread>();
        //Aktif Planlı Göre Threadleri
        public static Guid CreateGeneralTemplateRoleID
        { //Genel Şablon Tanımlama
            get
            {
                return new Guid("897CA5D9-0795-4E18-A6E8-94A457399008");
            }
        }

        public static Guid AuditQueryRoleID
        { //İz Kaydı Sorgulama
            get
            {
                return new Guid("AF73D69E-7E88-4EDC-AECC-13F73F4E3431");
            }
        }

        public static Guid ChangePhysicalStateClinicRoleID
        { //Klinikler arası nakil sorgulama
            get
            {
                return new Guid("599E0F24-BBF7-48F3-AAC1-088A0025677A");
            }
        }

        public static Guid PurchaseItemDemandRequestRoleID
        { //Satınalma Kalemi Talep-İstek
            get
            {
                return new Guid("1E155D88-631E-49C8-A1F9-8914FE3F8889");
            }
        }

        public static Guid PurchaseItemDemandApproveRoleID
        { //Satınalma Kalemi Talep-Onay
            get
            {
                return new Guid("E05F5FDE-0F86-4B1B-9E96-E1F032D74165");
            }
        }

        public static Guid InsertPatientIntoQueueRoleID
        { //Hastayı Sıraya Ekle
            get
            {
                return new Guid("BD53518A-85E5-42FA-8C97-590D9287AE18");
            }
        }

        public static Guid CallPatientRoleID
        { //Hasta Çağırma Sistemi
            get
            {
                return new Guid("2ED69179-EEAB-4613-857C-ECE07101CD75");
            }
        }

        public static Guid ExaminationQueueManagementRoleID
        { //Muayene Kuyruğu Düzenleme
            get
            {
                return new Guid("BD23334A-1332-44B8-A8B3-6E56F7B01C4A");
            }
        }

        public static Guid SendUBBDataRequestRoleID
        { //UBB Veri Girişi
            get
            {
                return new Guid("C15A2671-9C0D-41B9-AD5A-9550609CF402");
            }
        }

        public static Guid ManualDateTimeEntryRoleID
        { //Manuel Tarih Girişi
            get
            {
                return new Guid("4B58D970-25D0-4B4B-A86B-43CD63A210E7");
            }
        }

        public static Guid MedulaKareKodOkuRoleID
        { //Medula Kare Kod Oku
            get
            {
                return new Guid("C0087D03-78A6-4798-A6D0-65853F4A21F2");
            }
        }

        public static Guid MedulaDosyadanOkuRoleID
        { //Medula Dosyadan Oku
            get
            {
                return new Guid("2DB94643-C74D-41B3-8B51-FB2706D3FAF7");
            }
        }

        public static Guid MedulaDisketOkuRoleID
        { //Medula Disket Oku
            get
            {
                return new Guid("98E95D04-42DE-45AF-A896-2CDAFE8EEDAC");
            }
        }

        public static Guid MedulaDisketHazirlaRoleID
        { //Medula Disket Hazırla
            get
            {
                return new Guid("9312BC71-B6EA-4688-ACFE-7C2E770B3BDB");
            }
        }

        public static Guid CreateCentralFixedAssetRoleID
        { //Merkezi Yeni Demirbaş İstek
            get
            {
                return new Guid("41486532-9890-4805-A3C9-8E621560B1F8");
            }
        }

        public static Guid SearchDocumentRegistryRoleID
        { //Belge Kayıt Defteri
            get
            {
                return new Guid("7A7850E6-E944-4606-9D52-7689807E6A71");
            }
        }

        public static Guid SearchDocumentRecordLogRoleID
        { //Belge Kayıt Kütüğü
            get
            {
                return new Guid("F2ACE986-605D-4364-93B5-56F19BA9DC20");
            }
        }

        public static Guid SearchGABActionRoleID
        { //GAB Arama
            get
            {
                return new Guid("3DAA269C-5C03-4FC7-9230-A38014232DD8");
            }
        }

        public static Guid OpenStockCardFolderRoleID
        { //Stok Kartı Dosyası Açma
            get
            {
                return new Guid("C34D61FA-0BD4-489F-BE70-0737172AB2DE");
            }
        }

        public static Guid SearchStockCardRoleID
        { //Stok Kartı Arama
            get
            {
                return new Guid("250DC1F7-C6C1-4560-9D22-C6B025979DB4");
            }
        }

        public static Guid SearchCentralStockCardRoleID
        { //Merkezi Stok Kartı Arama
            get
            {
                return new Guid("1B2459B2-BBCC-4D7D-BB4D-FDF58F322022");
            }
        }

        public static Guid CreateCentralStockCardRoleID
        { //Merkezi Stok Kartı İstek
            get
            {
                return new Guid("7D403A50-4343-4D89-AC4C-144441A8FD01");
            }
        }

        public static Guid SearchPatientRoleID
        { //Hasta Arama
            get
            {
                return new Guid("D0936412A99B4E498713F79BEBD52835");
            }
        }

        public static Guid NewPatientRoleID
        { //Yeni Hasta Kayıt
            get
            {
                return new Guid("0521478F1A1347FC8E5E7FE48869B073");
            }
        }

        public static Guid ReadPatientInfoRoleID
        { //Kimlik Bilgileri Görme
            get
            {
                return new Guid("949A51381C884688936B6AB55FC3199C");
            }
        }

        public static Guid UpdatePatientInfoRoleID
        { //Kimlik Bilgileri Düzeltme
            get
            {
                return new Guid("3C1D488E57114ADF8832546BE34192A1");
            }
        }

        public static Guid ModifyPatientInfoRoleID
        { //Kimlik Bilgileri Değiştirme
            get
            {
                return new Guid("398FD822F52A4B1C95A2F93CCC4BC807");
            }
        }

        public static Guid PatientAdmissionRoleID
        { //Hasta Kabul
            get
            {
                return new Guid("0D472F8BE39F40BFA449B702B99D3192");
            }
        }

        public static Guid ReadPatientAdmissionRoleID
        { //Hasta Kabul Bilgileri Görme
            get
            {
                return new Guid("03C5814890104CFC9081F2CA5BFAC6D9");
            }
        }

        public static Guid MergePatientsRoleID
        { //Hasta Dosyası Birleştirme
            get
            {
                return new Guid("3F3201C04D1841C0A5F5AE633FC983A0");
            }
        }

        public static Guid OpenPatientFolderRoleID
        { //Hasta Dosyası Açma
            get
            {
                return new Guid("130DF3F7D45340FDAD4FF3D837F5E540");
            }
        }

        public static Guid OldActionRoleID
        { //Eski İşlemler
            get
            {
                return new Guid("56DCD23A2347478089F60647BD3F05AD");
            }
        }

        public static Guid AdmissionAppointmentRoleID
        { //Randevu Verme
            get
            {
                return new Guid("17EE2F82F689484FB71D1BDCA2E7AA7C");
            }
        }

        public static Guid ScheduleRoleID
        { //Randevu Planlama
            get
            {
                return new Guid("B78893EE7FA64A79BA031522B4FECEE0");
            }
        }

        public static Guid RoleTransferRoleID
        { //Yetki Aktarma
            get
            {
                return new Guid("43A77E6B799A46E3BBE514EDBF73A27C");
            }
        }

        public static Guid PatientAllergiesRoleID
        { //Veri Panel-Alerji Bilgileri
            get
            {
                return new Guid("CF825C6E-B4BE-4BC4-A957-E64C46C208F5");
            }
        }

        public static Guid PatientVaccinationRoleID
        { //Veri Panel-Aşı Bilgileri
            get
            {
                return new Guid("1D410E86-C76C-474D-AC57-686363A94EF9");
            }
        }

        public static Guid PatientHistoryRoleID
        { //Veri Panel-Öyküsü
            get
            {
                return new Guid("A04E986D-1B10-452A-B561-91895FB344AE");
            }
        }

        public static Guid PatientDiagnosisRoleID
        { //Veri Panel-Tanılar
            get
            {
                return new Guid("E984B4B1-479C-48EB-8798-CB233D55097A");
            }
        }

        public static Guid PatientOrdersRoleID
        { //Veri Panel-Tetkikler
            get
            {
                return new Guid("7E09B008-CCD5-4B47-BD80-A65DFA437498");
            }
        }

        public static Guid AppointmentUpdateRoleID
        { //Randevu Güncelleme
            get
            {
                return new Guid("0ED91F63-F6D1-44E2-AC48-2D7A39472F22");
            }
        }

        public static Guid SpecialistDoctorRoleID
        { //Uzman Tabip
            get
            {
                return new Guid("9431a69c-1a2a-4dcf-b1d3-6b1368318f89");
            }
        }

        public static Guid HeadDoctorRoleID
        { //Baştabip
            get
            {
                return new Guid("d6694fe4-91cd-4a69-8166-e7362b3e2cd0");
            }
        }

        public static Guid HealthCommitteeWithThreeSpecialistReportRoleID
        { //Üç Uzman Tabip İmzalı Sağlık Raporu Alma
            get
            {
                return new Guid("0089b972-1d2e-4b01-9427-60f95644bc00");
            }
        }

        public static Guid PANotSpecialityControlRoleID
        { //Hasta Kabul [Uzmanlık Dalı Kontrolsüz]
            get
            {
                return new Guid("401bdad9-76d2-4a21-8941-f192dea384df");
            }
        }

        public static Guid RadiologyPANotSpecialityControlRoleID
        { //Radyoloji Hasta Kabul[Uzmanlık Dalı Kontrolsüz]
            get
            {
                return new Guid("739b711d-bd32-49e1-841c-00742f1de85a");
            }
        }

        public static Guid SetAsNotRequiredQuotaRoleID
        { //Kontenjan Dışı Kabul Kararı Verme
            get
            {
                return new Guid("55422400-efd7-4624-b008-9de83ddd9a40");
            }
        }

        public static Guid PatientAdmissionCorrectionForClosedEpisodeRoleID
        { //Hasta Kabul Düzeltme(Kapalı Vakalarda)
            get
            {
                return new Guid("1bdcf9db-006b-4d00-86a0-ea82ed523551");
            }
        }

        public static Guid PatientAdmissionCorrectionRoleID
        { //Hasta Kabul Düzeltme
            get
            {
                return new Guid("6abb2d6d-ad79-4cad-bcf7-7a1d53eff69e");
            }
        }

        public static Guid CheckMernisRoleID
        { //Hasta Kabul Düzeltme
            get
            {
                return new Guid("890b5288-f690-4cd2-9864-d02e5814434a");
            }
        }

        public static Guid LimitedMedulaInvoiceUserRoleID
        { //Medula Fatura Kullanıcısı (Kısıtlı Yetkili)
            get
            {
                return new Guid("abedac20-cf94-4b2a-88d0-f7db6b985c3d");
            }
        }

        public static Guid UnlimitedMedulaInvoiceUserRoleID
        { //Medula Fatura Kullanıcısı (Tam Yetkili)
            get
            {
                return new Guid("2672b9fc-cc05-4f2d-aea8-56b8cfadfb10");
            }
        }

        public static Guid DoctorPerformanceApproveUserRoleID
        { //Doktor Performans Onay Kullanıcısı
            get
            {
                return new Guid("554ee97f-a2ff-41cf-8f78-7a5635be6898");
            }
        }

        public static Guid WorkingCapitalManagerRoleID
        { //Döner Sermaye İşletme Müdürü
            get
            {
                return new Guid("0f761137-ddf7-4553-aa07-3e6aa1e2c8e8");
            }
        }

        public static Guid ExaminationQueueWatchRoleID
        { //Sıra İzleme Kullanıcısı
            get
            {
                return new Guid("7a1994ba-b64d-4f03-a4af-4f6372faf561");
            }
        }

        public static Guid TibbiKayitMemuruRoleID
        { //Tıbbi Kayıt Memuru
            get
            {
                return new Guid("3c9ac6c0-344e-4afe-83b7-852ebbe30a96");
            }
        }

        public static Guid IslemIptalEtmeRoleID
        { //İşlem İptal Etme
            get
            {
                return new Guid("4f1be836-e6d4-412f-a002-45e14de874c5");
            }
        }

        public static Guid IslemGeriAlmaRoleID
        { //İşlem Geri Alma
            get
            {
                return new Guid("322a45dc-4130-4814-855e-b2c7d28b80d0");
            }
        }

        public static Guid IzoleHastaKayitRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("a06aab8d-f8d2-4977-b9fc-e8c26aaefd59");
            }
        }

        public static Guid GizliHastaKabulRoleID
        {
            get
            {
                return new Guid("00916139-d655-4ae3-aa19-b65ecdda7d31");
            }
        }

        public static Guid TakipSilmeKisitliYetkiRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("0e2261e5-7f7b-4c2f-a5a1-b24649c94664");
            }
        }

        public static Guid TakipSilmeTamYetkiRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("ed474f25-189d-48ef-821b-138bdb340a04");
            }
        }

        public static Guid VezneTahsilatYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("14a88c45-650c-4bee-89cc-810095979d9d");
            }
        }

        public static Guid BankaOdemeFisiYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("233d0721-2f22-45d5-83d7-e165a5ffd5ff");
            }
        }

        public static Guid MushasebeYetkilisiMutemediAlındısıYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("462e5064-3121-462a-bad2-86c21b6393e4");
            }
        }

        public static Guid MushasebeYetkilisiMutemediAlındısıIadeYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("9552973b-cfb9-48bc-9eee-588f46cad377");
            }
        }

        public static Guid AvansAlmaYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("62fbcaf6-c3e7-42ab-9d8a-d43cfecdf9c6");
            }
        }

        public static Guid AvansIadeYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("c3911698-7b25-4e40-96d7-5963c9e27793");
            }
        }

        public static Guid SenetYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("d4bef0ad-1e0d-4682-883b-9cb14b11d9b7");
            }
        }

        public static Guid SenetTahsilatYeniRoleID
        { //Izole Hasta Kayıt Memuru
            get
            {
                return new Guid("361f9ebe-bc4c-4ed0-9100-544fff81c143");
            }
        }

        public static Guid HizmetİstemSatırSilmeRoleID
        {
            get
            {
                return new Guid("77bc8ccd-3aad-4b9e-a6b5-e8431d3ef43a");
            }
        }

        public static Guid RadyolojiTestImajGoruntulemeRoleID
        {
            get
            {
                return new Guid("f92e830b-fc84-4de5-932d-48d0613c8122");
            }
        }
        public static Guid HizmetİstemMiktarDegistirmeRoleID
        {
            get
            {
                return new Guid("acf35283-fc82-410e-aeac-d265abf34ef1");
            }
        }

        public static Guid VezneMemuruRoleID
        {
            get
            {
                return new Guid("713fecdf-604e-443c-a451-e42a21b0fe69");
            }
        }
        public static Guid KimlikBilgileriDuzeltmeRoleID
        {
            get
            {
                return new Guid("3c1d488e-5711-4adf-8832-546be34192a1");
            }
        }
        private static int _appointmentReadFormRightDefID = 50;
        public static int AppointmentReadFormRightDefID
        { //Read Form
            get
            {
                return _appointmentReadFormRightDefID;
            }
        }

        private static int _appointmentUpdateFormRightDefID = 51;
        public static int AppointmentUpdateFormRightDefID
        { //Update Form
            get
            {
                return _appointmentUpdateFormRightDefID;
            }
        }

        private static int _appointmentApproveRightDefID = 2000;
        public static int AppointmentApproveRightDefID
        { //Onay
            get
            {
                return _appointmentApproveRightDefID;
            }
        }

        private static int _appointmentCancelRightDefID = 2001;
        public static int AppointmentCancelRightDefID
        { //İptal
            get
            {
                return _appointmentCancelRightDefID;
            }
        }

        private static int _appointmentAddRightDefID = 2002;
        public static int AppointmentAddRightDefID
        { //Ekle
            get
            {
                return _appointmentAddRightDefID;
            }
        }

        private static int _appointmentCreateRightDefID = 2003;
        public static int AppointmentCreateRightDefID
        { //Create
            get
            {
                return _appointmentCreateRightDefID;
            }
        }

        private static int _appointmentPrintRightDefID = 2004;
        public static int AppointmentPrintRightDefID
        { //Yazdır
            get
            {
                return _appointmentPrintRightDefID;
            }
        }

        private static int _appointmentDeleteRightDefID = 2005;
        public static int AppointmentDeleteRightDefID
        { //Sil
            get
            {
                return _appointmentDeleteRightDefID;
            }
        }

        private static int _appointmentWorkListRightDefID = 2006;
        public static int AppointmentWorkListRightDefID
        { //iş Listesi
            get
            {
                return _appointmentWorkListRightDefID;
            }
        }

        private static int _appointmentBreakRightDefID = 2007;
        public static int AppointmentBreakRightDefID
        { //Saatsiz randevu
            get
            {
                return _appointmentBreakRightDefID;
            }
        }

        static Common()
        {
            CurrentResource.FillUserResources();
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class CommonResUser
        {
            public string ExternalID;
            public string Name;
            public string SurName;
            public long UniqueRefNo;
            public UserTitleEnum Title; //ünvan
            public string FatherName;
            public string MotherName;
            public DateTime? BirthDate;
            public Guid CountryOfBirth; //ülke
            public Guid CityOfBirth; //doğduğu il
            public Guid TownOfBirth; //doğduğu ilçe
            public SKRSCinsiyet Sex;
            public Guid CityOfRegistry; //kayıtlı olduğu il
            public Guid TownOfRegistry; //kayıtlı olduğu ilçe
            public string VillageOfRegistry; //kayıtlı olduğu mahalle/köy
            public Guid MilitaryClass; //XXXXXXi sınıf
            public DateTime DateOfJoin; //XXXXXXe giriş tarihi
            public DateTime? DateOfLeave; //XXXXXXden ayrılış tarihi
            public Guid Rank; //rütbe
            public DateTime? DateOfPromotion; //terfi tarihi
            public string DiplomaNo;
            public string EmploymentRecordid; //sicil no
            public string JobTitle; //görevi
            public UserTypeEnum UserType;
            public string SpecialityRegistryNo; //Uzmanlık Tescil No
            public bool StaffOfficer; //Kurmay
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class DiagnosisInfo
        {
            public Int64 ID;
            public Int64 ParentID;
            public string Name;
            public string Code;
            public int IsGroup;
            public string SearchName;
            public string EnglishName;
            public DateTime LastUpdateDate;
        }

        public static void SaveDiagnosisInfo(Common.DiagnosisInfo obj)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                SPTSDiagnosisInfo sptsDiagnosisInfo = null;
                System.ComponentModel.BindingList<TTObjectClasses.SPTSDiagnosisInfo> SPTSIDList = SPTSDiagnosisInfo.GetDiagnosisInfoBySPTSIDs(objectContext, obj.ID);
                if (SPTSIDList != null)
                {
                    if (SPTSIDList.Count > 0)
                    {
                        sptsDiagnosisInfo = SPTSIDList[0];
                    }
                }

                if (sptsDiagnosisInfo == null)
                {
                    sptsDiagnosisInfo = new SPTSDiagnosisInfo(objectContext);
                }

                //if (obj.ID != null)
                sptsDiagnosisInfo.ID = obj.ID;
                //if (obj.ParentID != null)
                sptsDiagnosisInfo.ParentID = obj.ParentID;
                if (obj.Name != null)
                    sptsDiagnosisInfo.Name = obj.Name;
                if (obj.Code != null)
                    sptsDiagnosisInfo.Code = obj.Code;
                //if (obj.IsGroup != null)
                sptsDiagnosisInfo.IsGroup = obj.IsGroup;
                if (obj.SearchName != null)
                    sptsDiagnosisInfo.SearchName = obj.SearchName;
                if (obj.EnglishName != null)
                    sptsDiagnosisInfo.EnglishName = obj.EnglishName;
                if (obj.LastUpdateDate != null)
                    sptsDiagnosisInfo.LastUpdateDate = obj.LastUpdateDate;
                objectContext.Save();
            }
            catch (Exception ex)
            {
                throw new TTException("Error while DiagnosisInfo insert: " + ex.Message, ex);
            }
            finally
            {
                objectContext.Dispose();
            }
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class LabResultInfo
        {
            public Guid SubActionID;
            public Guid ActionID;
            public Guid TestID;
            public string Result;
            public string Reference;
            public string OzelReference;
            public string Aciklama;
            public string Birim;
            public HighLowEnum Warning;
            public Guid TeknisyenID;
            public DateTime TeknisyenOnayTarihi;
            public Guid OnayUzmani;
            public DateTime UzmanOnayTarihi;
            public string UzunRapor;
            public bool Antibiyogram;
            public bool IsLastTest;
        }

        public static void SaveLabResult(Common.LabResultInfo labResult)
        {
            TTObjectContext context = new TTObjectContext(false);
            if (labResult.SubActionID == Guid.Empty) // Laboratuvarda eklenmiş veya tam kan sayımı gibi panel'in alt testi
            {
                LaboratoryProcedure addLabProcedure = new LaboratoryProcedure(context);
                //aşağıdaki gibi bir kod yazılmalı
                LaboratoryTestDefinition labReqTestDef = (LaboratoryTestDefinition)context.GetObject(labResult.TestID, "LaboratoryTestDefinition");
                addLabProcedure.MasterResource = labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
                addLabProcedure.FromResource = addLabProcedure.MasterResource; //lab'tan istenmiş
                addLabProcedure.ProcedureObject = labReqTestDef;
                LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(labResult.ActionID, "LABORATORYREQUEST");
                addLabProcedure.EpisodeAction = labRequest;
                addLabProcedure.Amount = labReqTestDef.PriceCoefficient == null ? 1 : labReqTestDef.PriceCoefficient;
                addLabProcedure.Result = labResult.Result;
                addLabProcedure.Reference = labResult.Reference;
                addLabProcedure.Unit = labResult.Birim;
                addLabProcedure.Warning = labResult.Warning;
                addLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.New;
                addLabProcedure.ResultDate = Common.RecTime();
                context.Save();
                addLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                labRequest.LaboratoryProcedures.Add(addLabProcedure);
                //State ilerletme ile ilgili kısım yazılacak
                if (labResult.IsLastTest && addLabProcedure.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                    addLabProcedure.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
                //context.Save();
            }
            else
            {
                SubactionProcedureFlowable baseProc = (SubactionProcedureFlowable)context.GetObject(labResult.SubActionID, "SUBACTIONPROCEDUREFLOWABLE");
                if (baseProc is LaboratoryProcedure)
                {
                    LaboratoryProcedure labProc = (LaboratoryProcedure)baseProc;
                    labProc.Result = labResult.Result;
                    labProc.Reference = labResult.Reference;
                    labProc.Unit = labResult.Birim;
                    labProc.Warning = labResult.Warning;
                    labProc.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                    labProc.ResultDate = Common.RecTime();
                    if (labResult.IsLastTest && labProc.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                        labProc.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
                }
                else if (baseProc is LaboratorySubProcedure)
                {
                    LaboratorySubProcedure labSubProc = (LaboratorySubProcedure)baseProc;
                    labSubProc.Result = labResult.Result;
                    labSubProc.Reference = labResult.Reference;
                    labSubProc.Unit = labResult.Birim;
                    labSubProc.Warning = labResult.Warning;
                    labSubProc.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                    //labSubProc.ResultDate = Common.RecTime();
                    if (labResult.IsLastTest && labSubProc.LaboratoryProcedure.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                        labSubProc.LaboratoryProcedure.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
                }
            }

            context.Save();
        }

        public static void SendPACSPrinterControlMessage(string message)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            // SITEID parametresine gore control mesaji gonderiliyordu, istenirse sistem parametresine bagli olarak gonderilebilir. 
            System.ComponentModel.BindingList<TTObjectClasses.ResUser> resList = null;
            resList = ResUser.GetResUserByObjectID(objectContext, "abba26fc-afff-481a-be49-0c733b003ec8"); // System Admin
            UserMessage.SendMessageV2(objectContext, resList, TTUtils.CultureService.GetText("M26678", "PACS Printer Kontrol Mesajı"), message, true);
            objectContext.Save();
            objectContext.Dispose();
        }

        public static DateTime? EliminateIllegalDate(DateTime? date)
        {
            if (date != null && date > Convert.ToDateTime("01.01.1800"))
                return (DateTime?)date;
            return null;
        }

        public string[] ChildRelationToStrArray(TTObject obj, string childRelDef, string PropertyDefName)
        {
            string[] strArray = null;
            TTObjectRelationDef relationDef = null;
            foreach (TTObjectRelationDef relDef in obj.ObjectDef.AllChildRelationDefs)
            {
                if (relDef.ChildrenName == childRelDef)
                    relationDef = relDef;
            }

            if (relationDef == null)
                return null;
            object childCollection = obj.GetType().GetProperty(relationDef.ChildrenName).GetValue(this, null);
            ITTChildObjectCollection cc = childCollection as ITTChildObjectCollection;
            int i = 0;
            foreach (TTObject childobject in cc)
            {
                if (childobject[GetIdentifierName(PropertyDefName)] != null)
                {
                    strArray[i] = childobject[GetIdentifierName(PropertyDefName)].ToString();
                    i++;
                }
            }

            return strArray;
        }

        #region XXXXXX IDARI
        /// <summary>
        /// Web servisi için Kullanılacak Personel class ı
        /// </summary>
        public class PersonelItem
        {
            public Guid ObjectID;
            public string Name;
            public string Surname;
            public DateTime? BirthDate;
            public SexEnum? Sex;
            public string FatherName;
            public Guid? TownId;
            public Guid? CityId;
            public string Dogumyeri;
            public DateTime? ExDate;
        }

        public static Common.PersonelItem GetPersonelItem(long uniqRefNo)
        {
            try
            {
                KPSKisiSorgulaKimlikNoServis.KisiSorgulaTCKimlikNoSorguKriteri kriter = new KPSKisiSorgulaKimlikNoServis.KisiSorgulaTCKimlikNoSorguKriteri();
                kriter.TCKimlikNo = uniqRefNo;
                Common.PersonelItem personelItem = new Common.PersonelItem();
                KPSKisiSorgulaKimlikNoServis.KisiBilgisiSonucu sonuc = KPSKisiSorgulaKimlikNoServis.WebMethods.ListeleCokluSync(Sites.SiteLocalHost, kriter);
                KPSKisiSorgulaKimlikNoServis.KisiBilgisi kisiBilgisi = sonuc.SorguSonucu[0];
                if (kisiBilgisi == null)
                {
                    // InfoBox.Show("Kişinin MERNİS bilgilerine ulaşılamadı.");
                    return null;
                }
                else
                {
                    if (kisiBilgisi.TemelBilgisi != null)
                    {
                        personelItem.FatherName = kisiBilgisi.TemelBilgisi.BabaAd;
                        personelItem.Name = kisiBilgisi.TemelBilgisi.Ad;
                        personelItem.Surname = kisiBilgisi.TemelBilgisi.Soyad;
                        if (kisiBilgisi.TemelBilgisi.Cinsiyet != null && kisiBilgisi.TemelBilgisi.Cinsiyet.Kod != null && kisiBilgisi.TemelBilgisi.Cinsiyet.Kod == 1)
                            personelItem.Sex = SexEnum.Male;
                        else
                            personelItem.Sex = SexEnum.Female;
                        personelItem.BirthDate = new DateTime(kisiBilgisi.TemelBilgisi.DogumTarih.Yil ?? 0, kisiBilgisi.TemelBilgisi.DogumTarih.Ay ?? 1, kisiBilgisi.TemelBilgisi.DogumTarih.Gun ?? 1);
                        personelItem.Dogumyeri = kisiBilgisi.TemelBilgisi.DogumYer;
                    }

                    // BirthDate.Text = _Patient.BirthDate.Value.ToString("dd/MM/yyyy");
                    if (kisiBilgisi.KayitYeriBilgisi != null && kisiBilgisi.KayitYeriBilgisi.Ilce != null)
                    {
                        TTObjectContext context = new TTObjectContext(true);
                        IBindingList townsOfRegistry = context.QueryObjects(typeof(TownDefinitions).Name, "MERNISCODE = " + kisiBilgisi.KayitYeriBilgisi.Ilce.Kod);
                        if (townsOfRegistry.Count == 1)
                        {
                            TownDefinitions townOfRegistry = (TownDefinitions)townsOfRegistry[0];
                            personelItem.TownId = townOfRegistry.ObjectID;
                            if (townOfRegistry.City != null)
                                personelItem.CityId = townOfRegistry.City.ObjectID;
                        }
                    }

                    if (kisiBilgisi.DurumBilgisi != null && kisiBilgisi.DurumBilgisi.OlumTarih != null)
                    {
                        if (kisiBilgisi.DurumBilgisi.OlumTarih.Gun != null && kisiBilgisi.DurumBilgisi.OlumTarih.Ay != null && kisiBilgisi.DurumBilgisi.OlumTarih.Yil != null)
                            personelItem.ExDate = Convert.ToDateTime(kisiBilgisi.DurumBilgisi.OlumTarih.Gun.ToString() + "." + kisiBilgisi.DurumBilgisi.OlumTarih.Ay.ToString() + "." + kisiBilgisi.DurumBilgisi.OlumTarih.Yil.ToString());
                    }
                }

                return personelItem;
            }
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
                //return null;
            }
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class PersonnelIntegration
        {
            public string ObjectId;
            public string Sam;
            public string Name;
            public string Surname;
            public string MaidenSurname;
            public DateTime SeveranceDate;
            public string SeveranceType;
            public string SeveranceRemark;
            public string UnitEnclosureXXXXXX;
            public string Mission;
            public string MainCodeStr;
            public string ParagCodeStr;
            public string LineCodeStr;
            public string LineUnitDefStr;
            public string LineOfficeDefStr;
            public string LineSectionDefStr;
            public string LineUnitEnclDefStr;
            public string LineUnitDefId;
            public string LineOfficeDefId;
            public string LineSectionDefId;
            public string LineUnitEnclDefId;
            public string Rank;
            public string Class;
            public string ArmedForce;
            public string IdentityNumber;
            public string MotherName;
            public string FatherName;
            public DateTime BirthDate;
            public string Honorific;
            public string RegistryNumber;
            public string WMission;
            public string WMainCodeStr;
            public string WParagCodeStr;
            public string WLineCodeStr;
            public string WLineUnitDefStr;
            public string WLineOfficeDefStr;
            public string WLineSectionDefStr;
            public string wLineUnitEnclDefStr;
            public bool IsGeneral;
            public string WorkPhone;
            public string Email;
            public int GuestPersonnel;
            public string WorkLineToe;
            public bool Active;
            public bool IsContractPerson;
            public bool IsTrainer;
            public bool IstisnaiMemur;
            public bool NameIndicates;
            public bool SurnameIndicates;
            public bool MaidenSurnameIndicates;
            public bool RegistryNumberIndicates;
            public string LineToe;
        }

        public static void SaveResUser(Common.CommonResUser obj)
        {
            /*
             * Guid mySiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
             * 
            if (Sites.SiteXXXXXX06XXXXXX == mySiteGuid)
            {
                try
                {
                    TTMessageFactory.SyncCall(Sites.SiteLocalHost, "NimbusDataTaker", "NimbusDataTaker", "ProcessUser", obj);
                }
                catch (Exception ex)
                {
                    throw new TTException("Error while sending ResUser to NimbusDataTaker dll: " + ex.Message, ex);
                }
            }*/
            try
            {
                ResUser r = null;
                TTObjectContext objectContext = new TTObjectContext(false);
                // System.Reflection.FieldInfo ExtarnalIdInfo = obj.GetType().GetField("ExternalID");
                string ExternalID = obj.ExternalID.ToString();
                if (ExternalID == null)
                    throw new Exception(SystemMessage.GetMessage(647));
                System.ComponentModel.BindingList<TTObjectClasses.ResUser> reslist = null;
                reslist = ResUser.GetResUserByExternalID(objectContext, ExternalID.ToString());
                if (reslist != null)
                {
                    if (reslist.Count > 0)
                    {
                        r = reslist[0];
                    }
                }

                if (r == null && obj.UniqueRefNo != 0)
                {
                    reslist = ResUser.GetResUserByUniqeRefNo(objectContext, obj.UniqueRefNo.ToString());
                    if (reslist != null)
                    {
                        if (reslist.Count > 0)
                        {
                            r = reslist[0];
                        }
                    }

                    if (r == null)
                    {
                        r = new ResUser(objectContext);
                        Person p = new Person(objectContext);
                        r.Person = p;
                        r.IsActive = true;
                    }
                }

                r.SpecialityRegistryNo = obj.SpecialityRegistryNo;
                r.StaffOfficer = obj.StaffOfficer;
                r.ExternalID = ExternalID.ToString();
                if (obj.Name != null)
                    r.Person.Name = obj.Name;
                if (obj.SurName != null)
                    r.Person.Surname = obj.SurName;
                if (obj.UniqueRefNo != 0)
                    r.Person.UniqueRefNo = (long)obj.UniqueRefNo;
                //if (obj.Title != null)
                r.Title = (UserTitleEnum)obj.Title;
                //else
                //    r.Title = null;
                //if (obj.UserType != null)
                r.UserType = (UserTypeEnum)obj.UserType;
                //  else
                //      r.UserType = null; //null eklemek için personel tablosunun usertype bilgisi XXXXXXdan alınmalı
                if (obj.FatherName != null)
                    r.Person.FatherName = obj.FatherName;
                if (obj.MotherName != null)
                    r.Person.MotherName = obj.MotherName;
                if (obj.BirthDate != null)
                    r.Person.BirthDate = Common.EliminateIllegalDate(obj.BirthDate);
                Country country = null;
                Guid CountryOfBirthObjectId = obj.CountryOfBirth;
                if (!CountryOfBirthObjectId.Equals(new Guid()))
                {
                    System.ComponentModel.BindingList<TTObjectClasses.Country> countryList = Country.GetCountryDefinitionByObjectID(objectContext, CountryOfBirthObjectId.ToString());
                    if (countryList.Count >= 1)
                    {
                        // country = (Country)countryList[0];
                        // r.Person.CountryOfBirth = country;
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessageV2(648, CountryOfBirthObjectId.ToString()));
                    }
                }

                //if (obj.Sex != null)
                r.Person.Sex = (SKRSCinsiyet)obj.Sex;
                SKRSILKodlari city = null;
                Guid CityOfRegistryObjectId = obj.CityOfRegistry;
                if (!CityOfRegistryObjectId.Equals(new Guid()))
                {
                    r.Person.CityOfRegistry = objectContext.GetObject<SKRSILKodlari>(CityOfRegistryObjectId);
                    //throw new Exception(SystemMessage.GetMessageV2(649, CityOfRegistryObjectId.ToString()));
                }

                TownDefinitions town = null;
                Guid TownOfRegistryObjectID = obj.TownOfRegistry;
                if (!TownOfRegistryObjectID.Equals(new Guid()))
                {
                    System.ComponentModel.BindingList<TTObjectClasses.TownDefinitions> TownList = TownDefinitions.GetTownDefinitionByObjectId(objectContext, TownOfRegistryObjectID.ToString());
                    if (TownList.Count >= 1)
                    {
                        town = (TownDefinitions)TownList[0];
                        r.Person.TownOfRegistry = town;
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessageV2(650, TownOfRegistryObjectID.ToString()));
                    }
                }

                if (obj.VillageOfRegistry != null)
                    r.Person.VillageOfRegistry = obj.VillageOfRegistry;
                MilitaryClassDefinitions MilitaryClass = null;
                Guid MilitaryClassObjectID = obj.MilitaryClass;
                if (!MilitaryClassObjectID.Equals(new Guid()))
                {
                    System.ComponentModel.BindingList<TTObjectClasses.MilitaryClassDefinitions> MilitaryClassList = MilitaryClassDefinitions.GetMilitaryClassByObjectID(objectContext, MilitaryClassObjectID.ToString());
                    if (MilitaryClassList.Count >= 1)
                    {
                        MilitaryClass = (MilitaryClassDefinitions)MilitaryClassList[0];
                        r.MilitaryClass = MilitaryClass;
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessageV2(651, MilitaryClassObjectID.ToString()));
                    }
                }

                if (obj.DateOfJoin != null)
                    r.DateOfJoin = Common.EliminateIllegalDate(obj.DateOfJoin);
                DateTime? DateOfLeave = Common.EliminateIllegalDate(obj.DateOfLeave);
                if (DateOfLeave.HasValue)
                    r.DateOfLeave = DateOfLeave.Value;
                RankDefinitions rank = null;
                Guid RankObjectID = obj.Rank;
                if (!RankObjectID.Equals(new Guid()))
                {
                    System.ComponentModel.BindingList<TTObjectClasses.RankDefinitions> RankList = RankDefinitions.GetRankDefinitionsByObjectId(objectContext, RankObjectID.ToString());
                    if (RankList.Count >= 1)
                    {
                        rank = (RankDefinitions)RankList[0];
                        r.Rank = rank;
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessageV2(652, RankObjectID.ToString()));
                    }
                }

                if (obj.DateOfPromotion != null)
                    r.DateOfPromotion = Common.EliminateIllegalDate(obj.DateOfPromotion);
                if (obj.DiplomaNo != null)
                    r.DiplomaNo = obj.DiplomaNo;
                if (obj.EmploymentRecordid != null)
                    r.EmploymentRecordID = obj.EmploymentRecordid;
                if (obj.JobTitle != null)
                    r.Work = obj.JobTitle;
                //                JobTitleDefinition JobTitle = null;
                //                Guid JobTitleObjectID = obj.JobTitle;
                //                if (!JobTitleObjectID.Equals(new Guid()))
                //                {
                //                    System.ComponentModel.BindingList<TTObjectClasses.JobTitleDefinition> JobTitleFieldList = JobTitleDefinition.GetJobTitleByObjectID(objectContext, JobTitleObjectID.ToString());
                //                    if (JobTitleFieldList.Count >= 1)
                //                    {
                //                        JobTitle = (JobTitleDefinition)JobTitleFieldList[0];
                //                        r.Work = JobTitle.Name.ToString();
                //                    }
                //                    else
                //                    {
                //                        throw new Exception("Sistemde kayıtlı olmayan görev bilgisi girdiniz!ObjectId=" + JobTitleObjectID);
                //                    }
                //                }
                r.Name = r.Person.Name + " " + r.Person.Surname;
                if (r.ResourceSpecialities.Count == 1)
                {
                    r.ResourceSpecialities[0].MainSpeciality = true;
                }
                else if (r.ResourceSpecialities.Count > 1)
                {
                    int main = 0;
                    foreach (ResourceSpecialityGrid resSepeciality in r.ResourceSpecialities)
                    {
                        if (resSepeciality.MainSpeciality == true)
                        {
                            main++;
                        }
                    }

                    if (main == 0)
                    {
                        throw new Exception(SystemMessage.GetMessage(653));
                    }
                    else if (main > 1)
                    {
                        throw new Exception(SystemMessage.GetMessage(654));
                    }
                }

                //r.CurrentStateDefID = ResUser.States.New;
                objectContext.Save();
            }
            catch (Exception ex)
            {
                throw new TTException("Error while ResUser insert: " + ex.Message, ex);
            }
            //                System.Reflection.FieldInfo surnameField = obj.GetType().GetField("SurName");
            //                if (surnameField != null)
            //                    r.Person.Surname = surnameField.GetValue(obj).ToString();
            //                System.Reflection.FieldInfo CountryOfBirthField = obj.GetType().GetField("CountryOfBirth");
            //                if (CountryOfBirthField != null)
            //                {
            //                    Country country=null;
            //                    string CountryOfBirthObjectId = CountryOfBirthField.GetValue(obj).ToString();
            //                    System.ComponentModel.BindingList<TTObjectClasses.Country> countryList= Country.GetCountryDefinitionByObjectID(objectContext,CountryOfBirthObjectId);
            //                    if(countryList.Count>=1)
            //                    {
            //                        country=(Country)countryList[0];
            //                        r.Person.CountryOfBirth   = country;
            //                    }
            //                    else
            //                    {
            //                        throw new Exception("Sistemde kayıtlı olmayan doğduğu ülke bilgisi girdiniz!ObjectId=" + CountryOfBirthObjectId);
            //                    }
            //                }
            //
        }

        #endregion
        public static ResHospital GetCurrentHospital(TTObjectContext objectContext)
        {
            Guid guid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", ""));
            ResHospital hospital = (ResHospital)objectContext.GetObject(guid, "RESHOSPITAL");
            return hospital;
        }

        public static HospitalEmblemDefinition GetCurrentHospitalLogoV2(TTObjectContext objectContext)
        {
            string sLogoObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALLOGO", "");
            if (TTUtils.Globals.IsGuid(sLogoObjectID) == false)
                return null;
            Guid emblemObjectID = new Guid(sLogoObjectID);
            HospitalEmblemDefinition hospitalEmblem = objectContext.GetObject(emblemObjectID, TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"], false) as HospitalEmblemDefinition;
            return hospitalEmblem;
        }

        public static string GetCurrentHospitalLogo()
        {
            string sLogoObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALLOGO", "");
            return sLogoObjectID;
        }

        public static MilitaryUnit GetCurrentMilitaryUnit(TTObjectContext objContext)
        {
            ResHospital hospital = GetCurrentHospital(objContext);
            return hospital.MilitaryUnit;
        }

        public static DateTime MinDateTime()
        {
            return Convert.ToDateTime("01.01.1800 00:00:00");
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Radyoloji_Test_Istek_Kabul, TTRoleNames.Radyoloji_Test_R)]
        public static DateTime RecTime()
        {
            return TTObjectDefManager.ServerTime;
        }

        /// <summary>
        /// Sistem için genel useroption kaydetmek için
        /// </summary>
        /// <param name = "OptionType"></param>
        /// <returns></returns>
        public static void SaveSystemOption(UserOptionType optionType, string value)
        {
            UserOption uo = null;
            TTObjectContext objectContext = new TTObjectContext(false);
            foreach (UserOption userOption in UserOption.GetSystemOption(objectContext, optionType))
            {
                uo = userOption;
                break;
            }

            if (uo == null)
            {
                uo = new UserOption(objectContext);
                uo.OptionType = optionType;
                uo.Value = value;
            }
            else
            {
                uo.Value = value;
            }

            objectContext.Save();
        }

        /// <summary>
        /// Sistem için genel useroptionı getirmek için
        /// </summary>
        /// <param name = "OptionType"></param>
        /// <returns></returns>
        public static UserOption GetSystemOption(UserOptionType optionType)
        {
            UserOption uo = null;
            TTObjectContext objectContext = new TTObjectContext(false);
            foreach (UserOption userOption in UserOption.GetSystemOption(objectContext, optionType))
            {
                uo = userOption;
                break;
            }

            return uo;
        }

        public static string GetUserOptionValue(TTObjectContext context, ResUser user, UserOptionType optionType)
        {
            BindingList<UserOption> userOptList = UserOption.GetOption(context, user.ObjectID.ToString(), optionType);
            if (userOptList.Count == 0 || (userOptList.Count > 0 && userOptList[0].Value == null))
                userOptList = UserOption.GetSystemOption(context, optionType);
            if (userOptList.Count > 0)
                return userOptList[0].Value.ToString();
            return null;
        }

        public static List<SpecialityDefinition> CurrentResourceSpecialities()
        {
            List<SpecialityDefinition> specialityList = new List<SpecialityDefinition>();
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                foreach (ResourceSpecialityGrid specialityGrid in userResource.Resource.ResourceSpecialities)
                {
                    if (specialityGrid.Speciality != null)
                    {
                        specialityList.Add(specialityGrid.Speciality);
                    }
                }
            }

            return specialityList;
        }

        public static ResUser CurrentResource
        {
            get
            {
                if (CurrentUser.UserObject == null)
                    throw new Exception(SystemMessage.GetMessageV2(655, CurrentUser.Name.ToString()));
                return (ResUser)CurrentUser.UserObject;
            }
        }

        public static ResUser CurrentDoctor
        {
            get
            {
                if (CurrentUser.UserObject == null)
                    throw new Exception(SystemMessage.GetMessageV2(655, CurrentUser.Name.ToString()));
                ResUser resUser = (ResUser)CurrentUser.UserObject;
                if (resUser.UserType == UserTypeEnum.Doctor || resUser.UserType == UserTypeEnum.Dentist || resUser.UserType == UserTypeEnum.InternDoctor)
                    return (ResUser)CurrentUser.UserObject;
                else
                    return null;
            }
        }

        public static TTUser CurrentUser
        {
            get
            {
                return TTUser.CurrentUser;
            }
        }

        /// <summary>
        /// Double değerlerini sıralamaya yarar.
        /// </summary>

        #region TTDoubleSortableList
        public class TTDoubleSortableList
        {
            private object _ID;
            private double _Value;
            public TTDoubleSortableList()
            {
            }

            public TTDoubleSortableList(object ID, double Value)
            {
                _ID = ID;
                _Value = Value;
            }

            public object ID
            {
                get
                {
                    return _ID;
                }

                set
                {
                    _ID = value;
                }
            }

            public double Value
            {
                get
                {
                    return _Value;
                }

                set
                {
                    _Value = value;
                }
            }
        }

        private class TTDoubleSortableListComparer : IComparer<Common.TTDoubleSortableList>
        {
            public int Compare(Common.TTDoubleSortableList x, Common.TTDoubleSortableList y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }

        public static List<Common.TTDoubleSortableList> SortedDoubleItems(Hashtable unSortedList)
        {
            List<Common.TTDoubleSortableList> retval = new List<Common.TTDoubleSortableList>();
            if (unSortedList != null)
            {
                foreach (Common.TTDoubleSortableList listItem in unSortedList.Values)
                {
                    retval.Add(listItem);
                }
            }

            retval.Sort(new Common.TTDoubleSortableListComparer());
            return retval;
        }

        #endregion
        /// <summary>
        /// String değerlerini sıralamaya yarar.
        /// </summary>

        #region TTStringSortableList
        public class TTStringSortableList
        {
            private object _ID;
            private string _Value;
            public TTStringSortableList()
            {
            }

            public TTStringSortableList(object ID, string Value)
            {
                _ID = ID;
                _Value = Value;
            }

            public object ID
            {
                get
                {
                    return _ID;
                }

                set
                {
                    _ID = value;
                }
            }

            public string Value
            {
                get
                {
                    return _Value;
                }

                set
                {
                    _Value = value;
                }
            }
        }

        private class TTStringSortableListComparer : IComparer<Common.TTStringSortableList>
        {
            public int Compare(Common.TTStringSortableList x, Common.TTStringSortableList y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }

        public static List<Common.TTStringSortableList> SortedStringItems(Hashtable unSortedList)
        {
            List<Common.TTStringSortableList> retval = new List<Common.TTStringSortableList>();
            if (unSortedList != null)
            {
                foreach (Common.TTStringSortableList listItem in unSortedList.Values)
                {
                    retval.Add(listItem);
                }
            }

            retval.Sort(new Common.TTStringSortableListComparer());
            return retval;
        }

        #endregion
        /// <summary>
        /// Date değerlerini sıralamaya yarar.
        /// </summary>

        #region TTDateSortableList
        public class TTDateSortableList
        {
            private object _ID;
            private DateTime _Value;
            public TTDateSortableList()
            {
            }

            public TTDateSortableList(object ID, DateTime Value)
            {
                _ID = ID;
                _Value = Value;
            }

            public object ID
            {
                get
                {
                    return _ID;
                }

                set
                {
                    _ID = value;
                }
            }

            public DateTime Value
            {
                get
                {
                    return _Value;
                }

                set
                {
                    _Value = value;
                }
            }
        }

        private class TTDateSortableListComparer : IComparer<Common.TTDateSortableList>
        {
            public int Compare(Common.TTDateSortableList x, Common.TTDateSortableList y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }

        public static List<Common.TTDateSortableList> SortedDateItems(Hashtable unSortedList)
        {
            List<Common.TTDateSortableList> retval = new List<Common.TTDateSortableList>();
            if (unSortedList != null)
            {
                foreach (Common.TTDateSortableList listItem in unSortedList.Values)
                {
                    retval.Add(listItem);
                }
            }

            retval.Sort(new Common.TTDateSortableListComparer());
            return retval;
        }

        #endregion
        /// <summary>
        /// DateDiff fonksiyonunun kullandığı enum değerlerini içerir.
        /// </summary>
        public enum DateIntervalEnum : int
        {
            Day = 0, //İki tarih arasındaki toplam gün sayısını döndürür.
            Month = 1, //İki tarih arasındaki toplam ay sayısını döndürür.
            Year = 2, //İki tarih arasındaki yıl sayısını döndürür.
            DayLeftOver = 3, //İki tarih arasındaki artık gün sayısını döndürür.
            MonthLeftOver = 4, //İki tarih arasındaki artık ay sayısını döndürür.
            YearCompleted = 5 //İki tarih arasındaki tamamlanmış yıl sayısını döndürür.
        }

        /// <summary>
        /// iki tarih arasındaki farkın mutlak değerini DateIntervalEnum değerlerine göre integer olarak döndürür.
        /// </summary>
        /// <param name = "dateIntervalEnum"></param>
        /// <param name = "Date1"></param>
        /// <param name = "Date2"></param>
        /// <returns></returns>
        public static int DateDiff(DateIntervalEnum dateIntervalEnum, DateTime Date1, DateTime Date2)
        {
            if (Date1 < Date2)
            {
                DateTime tempDate = Date1;
                Date1 = Date2;
                Date2 = tempDate;
            }

            int _years = (int)(Date1.Year - Date2.Year);
            int _months = (int)(Date1.Month - Date2.Month);
            int _days = (int)(Date1.Day - Date2.Day);
            int _date1Year = Date1.Year;
            int _date1Month = Date1.Month;
            while (_days < 0)
            {
                _months--;
                _days += DateTime.DaysInMonth(_date1Year, _date1Month);
                _date1Month--;
                if (_date1Month < 1)
                {
                    _date1Month = 12;
                    _date1Year--;
                }
            }

            while (_months < 0)
            {
                _years--;
                _months += 12;
            }

            switch (dateIntervalEnum)
            {
                case DateIntervalEnum.Day:
                    System.TimeSpan ts = Date1.Subtract(Date2);
                    return (int)ts.TotalDays;
                case DateIntervalEnum.Month:
                    return (_years * 12) + _months;
                case DateIntervalEnum.Year:
                    return (int)(Date1.Year - Date2.Year);
                case DateIntervalEnum.DayLeftOver:
                    return _days;
                case DateIntervalEnum.MonthLeftOver:
                    return _months;
                case DateIntervalEnum.YearCompleted:
                    return _years;
                default:
                    throw new TTException(SystemMessage.GetMessage(656));
                    //return 0;
            }
        }

        /// <summary>
        /// iki tarih arasındaki farkın DateIntervalEnum değerlerine göre integer olarak döndürür.
        /// </summary>
        /// <param name = "dateIntervalEnum">0= gün /1= ay /2= yıl/3=artık gün /4=artık ay / 5 = tamamlanmış yıl</param>
        /// <param name = "Date1">Büyük tarih değeri</param>
        /// <param name = "Date2">Küçük tarih değeri</param>
        /// <param name = "abs">'false' değeri aldığında Date2 Date1 den büyükse iki tarih arası fark negatif çıkar.'true' olursa direk büyük olan tarihden küçüğü çıkarılır ve her zaman pozitif değer çıkar </param>
        /// <returns></returns>
        public static int DateDiffV2(DateIntervalEnum dateIntervalEnum, DateTime Date1, DateTime Date2, bool abs)
        {
            if (abs == false && (Date1 < Date2))
            {
                return (-1) * (DateDiff(dateIntervalEnum, Date1, Date2));
            }
            else
            {
                return DateDiff(dateIntervalEnum, Date1, Date2);
            }
        }



        public static string ArrayListToString(ArrayList arrayList)
        {
            string text = "";
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (i == 0)
                {
                    text = arrayList[i].ToString();
                }
                else
                {
                    text = text + " , " + arrayList[i].ToString();
                }
            }

            return text;
        }

        /// <summary>
        /// Parametre olarak verilen MainPatientGroupEnum'a a sahip MainPatientGroupDefinitionı döndürür
        /// </summary>
        /// <param name = "objectContext"></param>
        /// <param name = "patientGroupEnum"></param>
        /// <returns>NainPatientGroupDefinition</returns>
        public static MainPatientGroupDefinition MainPatientGroupDefinitionByEnum(TTObjectContext objectContext, MainPatientGroupEnum mainPatientGroupEnum)
        {
            IList mainPatientGroupDefinitionList = MainPatientGroupDefinition.GetByMainPatientGroupEnum(objectContext, mainPatientGroupEnum);
            foreach (MainPatientGroupDefinition mpatientGroupDefinition in mainPatientGroupDefinitionList)
            {
                return mpatientGroupDefinition;
            }

            return null;
        }

        /// <summary>
        /// Parametre olarak verilen patientGroupEnum'a a sahip PatientGroupDefinitionı döndürür
        /// </summary>
        /// <param name = "objectContext"></param>
        /// <param name = "patientGroupEnum"></param>
        /// <returns>PatientGroupDefinition</returns>
        public static PatientGroupDefinition PatientGroupDefinitionByEnum(TTObjectContext objectContext, PatientGroupEnum patientGroupEnum)
        {
            IList patientGroupDefinitionList = PatientGroupDefinition.GetPatientGroupDefinitionID(patientGroupEnum);
            if (patientGroupDefinitionList.Count > 0)
                return (PatientGroupDefinition)objectContext.GetObject(((PatientGroupDefinition.GetPatientGroupDefinitionID_Class)patientGroupDefinitionList[0]).ObjectID.Value, typeof(PatientGroupDefinition));
            return null;
        }

        /// <summary>
        /// Parametre olarak verilen MainPatientGroupEnum'a a sahip MainPatientGroupDefinitionı döndürür
        /// </summary>
        /// <param name = "objectContext"></param>
        /// <param name = "patientGroupEnum"></param>
        /// <returns>NainPatientGroupDefinition</returns>
        public static MainPatientGroupDefinition ActiveMainPatientGroupDefinitionByEnum(TTObjectContext objectContext, MainPatientGroupEnum mainPatientGroupEnum)
        {
            IList mainPatientGroupDefinitionList = MainPatientGroupDefinition.GetActiveByMainPatientGroupEnum(objectContext, mainPatientGroupEnum);
            foreach (MainPatientGroupDefinition mpatientGroupDefinition in mainPatientGroupDefinitionList)
            {
                return mpatientGroupDefinition;
            }

            return null;
        }

        /// <summary>
        /// Parametre olarak verilen patientGroupEnum'a a sahip PatientGroupDefinitionı döndürür
        /// </summary>
        /// <param name = "objectContext"></param>
        /// <param name = "patientGroupEnum"></param>
        /// <returns>PatientGroupDefinition</returns>
        public static PatientGroupDefinition ActivePatientGroupDefinitionByEnum(TTObjectContext objectContext, PatientGroupEnum patientGroupEnum)
        {
            IList patientGroupDefinitionList = PatientGroupDefinition.GetPatientGroupDefinitionID(patientGroupEnum);
            if (patientGroupDefinitionList.Count > 0)
            {
                PatientGroupDefinition pa = (PatientGroupDefinition)objectContext.GetObject(((PatientGroupDefinition.GetPatientGroupDefinitionID_Class)patientGroupDefinitionList[0]).ObjectID.Value, typeof(PatientGroupDefinition));
                if (pa.IsActive == null || pa.IsActive == true)
                    return pa;
            }

            return null;
        }

        /// <summary>
        /// Parametre olarak verilen reasonForExaminationType a sahip ReasonForExaminationDefinitionı döndürür
        /// </summary>
        /// <param name = "objectContext"></param>
        /// <param name = "reasonForExaminationType"></param>
        /// <returns>ReasonForExaminationDefiniton</returns>
        public static ReasonForExaminationDefinition ReasonForExaminationByType(TTObjectContext objectContext, ReasonForExaminationTypeEnum reasonForExaminationType)
        {
            IList reasonForExaminationList = objectContext.QueryObjects("ReasonForExaminationDefinition", "REASONFOREXAMINATIONTYPE = " + reasonForExaminationType.GetHashCode().ToString());
            foreach (ReasonForExaminationDefinition reasonForExamination in reasonForExaminationList)
            {
                return reasonForExamination;
            }

            return null;
        }

        /// <summary>
        /// Parametre olarak verilen Code a sahip ReasonForExaminationDefinitionı döndürür
        /// </summary>
        /// <param name = "objectContext"></param>
        /// <param name = "Code"></param>
        /// <returns>ReasonForExaminationDefiniton</returns>
        public static ReasonForExaminationDefinition ReasonForExaminationByCode(TTObjectContext objectContext, long Code)
        {
            IList reasonForExaminationList = objectContext.QueryObjects("ReasonForExaminationDefinition", "CODE = " + Code.ToString());
            foreach (ReasonForExaminationDefinition reasonForExamination in reasonForExaminationList)
            {
                return reasonForExamination;
            }

            return null;
        }

        /// <summary>
        /// ttObject olarak verilen parametre içinde propertyName isminde propert var ise true yok ise false döner
        /// </summary>
        /// <param name = "ttObject">Property'nin aranacağı ttobject</param>
        /// <param name = "propertyName">aranan propertyname</param>
        /// <returns>bool</returns>
        public static bool IsPropertyExist(TTObject ttObject, string propertyName)
        {
            if (ttObject == null)
            {
                return false;
            }
            else
            {
                if (ttObject.GetType().GetProperty(propertyName) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// ttObject olarak verilen parametre içinde propertyName isminde property valuesunu Object olarak döndürür.
        /// </summary>
        /// <param name = "ttObject">Property'nin aranacağı ttobject</param>
        /// <param name = "propertyName">aranan propertyname</param>
        /// <returns>Object</returns>
        public static Object PropertyValue(TTObject ttObject, string propertyName)
        {
            if (Common.IsPropertyExist(ttObject, propertyName))
            {
                return ttObject.GetType().GetProperty(propertyName).GetValue(ttObject, null);
            }
            else
            {
                return null;
            }
        }

        public static bool IsAttributeExists(string atributeName, TTObject ttobject)
        {
            bool found = false;
            if (ttobject.ObjectDef.AllAttributes.ContainsKey(atributeName))
            {
                found = true;
            }

            return found;
        }

        public static bool IsAttributeExists(System.Type AttributeType, TTObject ttobject)
        {
            bool found = false;
            if (ttobject.ObjectDef.AllAttributes.ContainsKey(AttributeType.Name.ToString()))
            {
                found = true;
            }

            return found;
        }

        public static bool IsAttributeExistsV2(System.Type AttributeType, TTObjectDef objectDef)
        {
            bool found = false;
            if (objectDef.AllAttributes.ContainsKey(AttributeType.Name.ToString()))
            {
                found = true;
            }

            return found;
        }

        public static bool IsTransitionAttributeExists(System.Type AttributeType, TTObjectStateTransitionDef transDef)
        {
            bool found = false;
            if (transDef != null)
            {
                if (transDef.AllAttributes.ContainsKey(AttributeType.Name.ToString()))
                {
                    found = true;
                }
            }

            return found;
        }

        public static bool IsTransitionAttributeExistsByAttName(string attributeName, TTObjectStateTransitionDef transDef)
        {
            bool found = false;
            if (transDef != null)
            {
                if (transDef.AllAttributes.ContainsKey(attributeName))
                {
                    found = true;
                }
            }

            return found;
        }


        public static List<TTObjectStateDef> GetAllObjectStateDefs(string ObjectDefName)
        {

            var objectStateDefList = new List<TTObjectStateDef>();

            var ttObjectDefCollection = TTObjectDefManager.Instance.ObjectDefs[ObjectDefName];
            foreach (TTObjectStateDef stateDef in ttObjectDefCollection.StateDefs)
            {
                objectStateDefList.Add(stateDef);
            }
            return objectStateDefList;
        }

        public static List<TTObjectStateDef> GetNextStateDefs(TTObjectStateDef ttObjectStateDef)
        {

            var objectStateDefList = new List<TTObjectStateDef>();
            if (ttObjectStateDef != null)
            {
                foreach (TTObjectStateTransitionDef transDef in ttObjectStateDef.OutgoingTransitions)
                {

                    objectStateDefList.Add(transDef.ToStateDef);
                }
            }
            return objectStateDefList;
        }


        public static bool IsStateAttributeExists(System.Type AttributeType, TTObjectStateDef stateDef)
        {
            bool found = false;
            if (stateDef != null)
            {
                if (stateDef.AllAttributes.ContainsKey(AttributeType.Name.ToString()))
                {
                    found = true;
                }
            }

            return found;
        }

        public static bool IsStateAttributeExistsByAttName(string attributeName, TTObjectStateDef stateDef)
        {
            bool found = false;
            if (stateDef != null)
            {
                if (stateDef.AllAttributes.ContainsKey(attributeName))
                {
                    found = true;
                }
            }

            return found;
        }

        public static UserTitleEnum GetUserTitleEnumByValue(int value)
        {
            foreach (TTDataDictionary.EnumValueDef r in TTObjectDefManager.Instance.DataTypes["UserTitleEnum"].EnumValueDefs.Values)
            {
                if ((int)r.Value == value)
                {
                    return (TTObjectClasses.UserTitleEnum)r.EnumValue;
                }
            }

            throw new Exception(SystemMessage.GetMessageV2(657, value.ToString()));
        }

        public static UserTypeEnum GetUserTypeEnumByValue(int value)
        {
            foreach (TTDataDictionary.EnumValueDef r in TTObjectDefManager.Instance.DataTypes["UserTypeEnum"].EnumValueDefs.Values)
            {
                if ((int)r.Value == value)
                {
                    return (TTObjectClasses.UserTypeEnum)r.EnumValue;
                }
            }

            throw new Exception(SystemMessage.GetMessageV2(657, value.ToString()));
        }

        public static TTDataDictionary.EnumValueDef GetUserTypeEnumValueDefByValue(int value)
        {
            foreach (TTDataDictionary.EnumValueDef r in TTObjectDefManager.Instance.DataTypes["UserTypeEnum"].EnumValueDefs.Values)
            {
                if ((int)r.Value == value)
                {
                    return r;
                }
            }

            throw new Exception(SystemMessage.GetMessageV2(657, value.ToString()));
        }

        public static int GetNumberOfEmptyBedsV2(TTObjectContext objectContext)
        {
            IList emptyBedList = ResBed.GetWithNullUsedBy(objectContext);
            return emptyBedList.Count;
        }

        public static int GetNumberOfEmptyBedsV3(TTObjectContext objectContext, Boolean withoutIntensiveCareBeds)
        {
            if (withoutIntensiveCareBeds)
            {
                IList emptyBedList = ResBed.GetEmptyBedsWithoutIntensiveCare();
                return emptyBedList.Count;
            }
            else
            {
                IList emptyBedList = ResBed.GetWithNullUsedBy(objectContext);
                return emptyBedList.Count;
            }
        }

        public static int GetNumberOfEmptyBeds(Guid ward)
        {
            IList emptyBedList = ResBed.GetEmptyBedsByClinic(Convert.ToString(ward));
            return emptyBedList.Count;
        }

        public static ResBed GetFirstfEmptyBed()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            IList emptyBedList = ResBed.GetWithNullUsedBy(objectContext);
            if (emptyBedList.Count > 0)
                return (ResBed)emptyBedList[0];
            return null;
        }

        public static ResBed GetFirstfEmptyBedV2(Guid ward)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            if (ward == null)
                return GetFirstfEmptyBed();
            IList emptyBedList = ResBed.GetWithNullUsedByAndClinic(objectContext, Convert.ToString(ward));
            if (emptyBedList.Count > 0)
                return (ResBed)emptyBedList[0];
            return null;
        }

        public static ResBed GetFirstfEmptyBedV3(Guid ward, Guid roomGroup)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            if (roomGroup == null)
                return GetFirstfEmptyBedV2(ward);
            IList emptyBedList = ResBed.GetWithNullUsedByAndRoomGroup(objectContext, Convert.ToString(roomGroup));
            if (emptyBedList.Count > 0)
                return (ResBed)emptyBedList[0];
            return null;
        }

        public static ResBed GetFirstfEmptyBedV4(Guid ward, Guid roomGroup, Guid room)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            if (room == null)
                return GetFirstfEmptyBedV3(ward, roomGroup);
            IList emptyBedList = ResBed.GetWithNullUsedByAndRoom(objectContext, Convert.ToString(room));
            if (emptyBedList.Count > 0)
                return (ResBed)emptyBedList[0];
            return null;
        }

        public static bool IsMilitaryPersonnel(TTObjectContext objectContext, PatientGroupEnum patientGroupEnum)
        {
            PatientGroupDefinition pGroupDefinition = Common.PatientGroupDefinitionByEnum(objectContext, patientGroupEnum);
            if (pGroupDefinition.MilitaryPersonnel == null)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(pGroupDefinition.MilitaryPersonnel.Value);
            }
        }

        // belirli periodlarla çaly?tyrylacak kodlaryn ba?yna "Periodic" ekleyelim
        public static void PeriodicCancelUnacceptedInpatientAdmissions(TTObjectContext objectContext)
        {
            double LimitHour = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("UNACCEPTEDINPATIENTADMISSIONLIMIT", "2"));
            LimitHour = (-1 * LimitHour);
            DateTime LimitRequestDate = Convert.ToDateTime(Common.RecTime()).AddHours(LimitHour);
            IList list = InpatientAdmission.GetUnacceptedInLimitedTime(objectContext, LimitRequestDate);
            foreach (InpatientAdmission inpatientAdmission in list)
            {
                if (inpatientAdmission.InPatientTreatmentClinicApplications.Count < 1)
                {
                    try
                    {
                        ((ITTObject)inpatientAdmission).Cancel();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        public static void PeriodicCancelOldUnCompletedEAs(TTObjectContext objectContext)
        {
            IList resSectionList = ResSection.GetIfHasActionCancelledTime(objectContext);
            foreach (ResSection r in resSectionList)
            {
                double limit = (-1 * Convert.ToDouble(r.ActionCancelledTime == null ? 0 : r.ActionCancelledTime));
                if (limit != 0)
                {
                    DateTime LimitDay = Convert.ToDateTime(Common.RecTime()).AddDays(limit);
                    IList list = EpisodeAction.GetUnCompletedEAByActiondate(objectContext, LimitDay, r.ObjectDef.ID.ToString());
                    foreach (EpisodeAction ea in list)
                    {
                        try
                        {
                            ((ITTObject)ea).Cancel();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }

        public static void PeriodicCloseToNewOldEpisodes(TTObjectContext objectContext)
        {
            double LimitDay = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEPISODELASTUPDATEDAYLIMIT", "10"));
            LimitDay = (-1 * LimitDay);
            DateTime LimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddHours(LimitDay);
            IList list = Episode.GetByLastUpdateDate(objectContext, LimitLastUpdateDate);
            foreach (Episode episode in list)
            {
                try
                {
                    episode.CloseEpisodeToNew();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static string GetCurrentUserComputerName()
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            return System.Environment.MachineName.ToUpper(cultureInfo);
        }

        public static string GetCurrentWindowsUserName()
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            return System.Environment.UserName;
        }

        public static TTObjectDef GetObjectDefByPatientGroup(TTObjectContext objectContext, PatientGroupEnum? patientGroupEnum)
        {
            if (patientGroupEnum != null)
            {
                BindingList<PatientGroupDefinition> patientGroupDefList = PatientGroupDefinition.GetByPatientGroup(objectContext, (PatientGroupEnum)patientGroupEnum);
                if (patientGroupDefList.Count > 0)
                {
                    PatientGroupDefinition patientGroupDef = patientGroupDefList[0];
                    if (patientGroupDef.IsActive == null || patientGroupDef.IsActive == true)
                    {
                        string objectDefName = "PA_" + patientGroupEnum.ToString().ToUpperInvariant().Trim();
                        if (TTObjectDefManager.Instance.ObjectDefs.ContainsKey(objectDefName) == true)
                            return TTObjectDefManager.Instance.ObjectDefs[objectDefName];
                    }
                }
            }

            return null;
        }

        public static TTObjectDef GetObjectDefByActionType(ActionTypeEnum actionType)
        {
            string objectDefName = actionType.ToString().ToUpperInvariant();
            if (TTObjectDefManager.Instance.ObjectDefs.ContainsKey(objectDefName) == false)
            {
                // MessageBox.Show(this.ReasonForAdmission + " kabul sebebi için başlatılmak istenen " +  objectDefName + " isimli işlem tanımlanmamıştır.");
                return null;
            }

            return TTObjectDefManager.Instance.ObjectDefs[objectDefName];
        }

        public static string GetDisplayTextOfDataTypeEnum(Enum enumValue)
        {
            string sDisplayText = "";
            try
            {
                sDisplayText = TTObjectDefManager.Instance.DataTypes[enumValue.GetType().Name].EnumValueDefs[enumValue.ToString()].DisplayText;
            }
            catch (Exception e)
            {
                throw e;
            }

            return sDisplayText;
        }

        public static string GetDisplayTextOfEnumValue(string name, int value)
        {
            string displayText = null;
            try
            {
                displayText = TTObjectDefManager.Instance.DataTypes[name].EnumValueDefs[value].DisplayText;
            }
            catch (Exception e)
            {
            }

            return displayText;
        }

        public static string GetDescriptionOfDataTypeEnum(Enum enumValue)
        {
            string description = null;
            try
            {
                description = TTObjectDefManager.Instance.DataTypes[enumValue.GetType().Name].EnumValueDefs[enumValue.ToString()].Description;
            }
            catch (Exception e)
            {
            }

            return description;
        }

        public static TTDataDictionary.EnumValueDef GetEnumValueDefOfEnumValue(Enum enumValue)
        {
            return TTObjectDefManager.Instance.DataTypes[enumValue.GetType().Name].EnumValueDefs[enumValue.ToString()];
        }

        public static TTDataDictionary.EnumValueDef GetEnumValueDefOfEnumValueV2(string name, int value)
        {
            TTDataDictionary.EnumValueDef enumValueDef = null;
            try
            {
                enumValueDef = TTObjectDefManager.Instance.DataTypes[name].EnumValueDefs[value];
            }
            catch (Exception e)
            {
            }

            return enumValueDef;
        }

        public static string ConvertHourToString(int hour)
        {
            string hourShow = "";
            if (hour == 24)
            {
                hourShow = "00";
            }
            else
            {
                if (hour < 10)
                {
                    hourShow = "0";
                }

                hourShow = hourShow + hour;
            }

            hourShow = hourShow + ":00";
            return hourShow;
        }

        public static bool LatinAlphabetUsed = true;
        public static string CUCase(string s, bool saveTurkish, bool alphaOnly)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            string src = null;
            char subChar;
            if (s != null)
            {
                if (!LatinAlphabetUsed)
                    return s.ToUpper();
                for (int i = 0; i <= s.Length - 1; i++)
                {
                    subChar = s.Substring(i, 1).ToCharArray()[0];
                    switch (subChar.ToString())
                    {
                        case "Ğ":
                        case "ğ":
                            src += saveTurkish ? "Ğ" : "G";
                            break;
                        case "Ü":
                        case "ü":
                            src += saveTurkish ? "Ü" : "U";
                            break;
                        case "Ş":
                        case "ş":
                            src += saveTurkish ? "Ş" : "S";
                            break;
                        case "Ö":
                        case "ö":
                            src += saveTurkish ? "Ö" : "O";
                            break;
                        case "Ç":
                        case "ç":
                            src += saveTurkish ? "Ç" : "C";
                            break;
                        case "İ":
                        case "i":
                            src += saveTurkish ? "İ" : "I";
                            break;
                        case "ı":
                            src += saveTurkish ? "I" : "I";
                            break;
                        default:
                            if (Char.ToUpper(subChar) >= 'A' && Char.ToUpper(subChar) <= 'Z')
                                src += Char.ToUpper(subChar).ToString();
                            else
                            {
                                if (Char.ToUpper(subChar) == ' ')
                                    src += " ";
                                else
                                {
                                    if (!alphaOnly)
                                        src += subChar.ToString();
                                }
                            }

                            break;
                    }
                }
            }

            return src;
        }

        public static ArrayList Tokenize(string s, bool wildCard)
        {
            string ts;
            string tmpToken = "";
            char subChar;
            ArrayList Tokens = new ArrayList();
            if (s != null)
            {
                ts = CUCase(s, false, false);
                for (int i = 0; i <= ts.Length - 1; i++)
                {
                    subChar = ts.Substring(i, 1).ToCharArray(0, 1)[0];
                    if (LatinAlphabetUsed && ((subChar >= 'A' && subChar <= 'Z') || (subChar >= 'a' && subChar <= 'z')))
                        tmpToken += subChar.ToString();
                    else if (!LatinAlphabetUsed && subChar != ' ')
                        tmpToken += subChar.ToString();
                    else if (wildCard && subChar == '%')
                        tmpToken += subChar.ToString();
                    else
                    {
                        if (tmpToken.Length > 0)
                            Tokens.Add(tmpToken);
                        tmpToken = "";
                    }
                }

                if (tmpToken.Length > 0)
                    Tokens.Add(tmpToken);
            }

            return Tokens;
        }

        public static bool IsNumeric(string s)
        {
            long temp = 0;
            return long.TryParse(s, out temp);
        }

        [Serializable]
        public class RemotingResultClass
        {
            public string resultCode;
            public string resultMessage;
            public string targetActionObjectID;
        }

        public static string TTObjectStatus(TTObject ob)
        {
            if (ob.CurrentStateDef != null)
            {
                if (ob.IsCancelled)
                {
                    return TTUtils.CultureService.GetText("M26086", "İptal Edildi");
                }
                else if (ob.CurrentStateDef.IsEntry == true)
                {
                    return TTUtils.CultureService.GetText("M24515", "Yeni");
                }
                else if (ob.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    return TTUtils.CultureService.GetText("M25428", "Devam Ediyor");
                }
                else if (ob.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                {
                    return TTUtils.CultureService.GetText("M27028", "Tamamlandı");
                }
                else if (ob.CurrentStateDef.Status == StateStatusEnum.CompletedUnsuccessfully)
                {
                    return TTUtils.CultureService.GetText("M25246", "Başarısız Tamamlandı");
                }

                return "";
            }
            else
            {
                return "";
            }
        }

        //Asagidaki 2 method CommonForm Clientsidemethodlarindan kullanilacak. Cok yerden kullnildigi icin simdilik ici bosaltildi.
        public static string GetTextOfRTFString(string RtfString)
        {
            string returnRtfString = String.Empty;

           // returnRtfString = TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(RtfString);
           // returnRtfString = returnRtfString.Replace("&emsp;", " ");

            /*System.Windows.Forms.RichTextBox rtfControl = new System.Windows.Forms.RichTextBox();
            try
            {
                rtfControl.Rtf = RtfString;
            }
            catch(ArgumentException)
            {
                return RtfString;
            }
            return rtfControl.Text;*/
             
            return RtfString;
        }

        public static string GetRTFOfTextString(string TextString)
        {
            /*
            System.Windows.Forms.RichTextBox rtfControl = new System.Windows.Forms.RichTextBox();
            rtfControl.Text = TextString;
            return rtfControl.Rtf;
             */
            return TextString;
        }

        public static string ReturnObjectAsString(object obj)
        {
            if (obj == null)
                return "-";
            if (obj is DateTime)
            {
                return ((DateTime)obj).ToShortDateString();
            }

            if (obj is Enum)
            {
                TTDataDictionary.EnumValueDef enumValueDef = Common.GetEnumValueDefOfEnumValue((Enum)obj);
                return enumValueDef.ToString();
            }

            if (obj is Boolean)
            {
                if ((Boolean)obj)
                    return TTUtils.CultureService.GetText("M14018", "Evet");
                else
                    return TTUtils.CultureService.GetText("M15570", "Hayır");
            }

            if (obj is String)
            {
                bool isRTF = true;
                string RTFText = "";
                try
                {
                    RTFText = Common.GetTextOfRTFString(obj.ToString());
                }
                catch (Exception e)
                {
                    isRTF = false;
                }

                if (isRTF)
                {
                    if (String.IsNullOrEmpty(RTFText))
                        RTFText = "-";
                    return RTFText;
                }
            }

            return obj.ToString();
        }

        public static string OldActionsStyles()
        {
            //            string style="<head><style type='text/css'>";
            //            style+="p {color:black ;font-size:9pt ; font-family:Arial ; margin-top:0px ;margin-left:0px}";
            //            style+="h1 {color:blue ; font-size:9pt ; font-family:Arial ; font-weight:bold; margin-top:0px ;margin-left:0px}";
            //            style+="</style></head>";
            //            return style;
            return "";
        }

        public static string FormatAsOldActionTitle(string value, string tdString)
        {
            if (String.IsNullOrEmpty(tdString))
                tdString = "";
            return "<td width='150' " + tdString + " ><font color='blue' face='arial' size='2'><b>" + value + "</b></font></td>";
        }

        public static string FormatAsOldActionTitleV2(string value, string tdString, bool autoWidth)
        {
            if (String.IsNullOrEmpty(tdString))
                tdString = "";
            if (autoWidth)
                return "<td " + tdString + " ><font color='blue' face='arial' size='2'><b>" + value + "</b></font></td>";
            else
                return FormatAsOldActionTitle(value, tdString);
        }

        public static string FormatAsOldActionValue(string value, string tdString)
        {
            if (String.IsNullOrEmpty(tdString))
                tdString = "";
            return "<td " + tdString + " ><font color='black' face='arial' size='2'>" + value + "</font></td>";
        }

        public static ArrayList ParseString(string parseString, char item)
        {
            int placeHolder;
            string objIDString;
            ArrayList parsedItems = new ArrayList();
            while (parseString.IndexOf(item) > 0)
            {
                placeHolder = parseString.IndexOf(item);
                objIDString = parseString.Substring(0, (placeHolder));
                parseString = parseString.Substring((placeHolder + 1), (parseString.Length - (placeHolder + 1)));
                parsedItems.Add(objIDString);
            }

            return parsedItems;
        }

        public static string GetDescriptionOfDataTypeEnumV2(string name, int value)
        {
            string description = null;
            try
            {
                description = TTObjectDefManager.Instance.DataTypes[name].EnumValueDefs[value].Description;
            }
            catch (Exception e)
            {
            }

            return description;
        }

        public static BindingList<UserOption> GetAllSystemOptions()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            return UserOption.GetAllSystemOptions(objectContext);
        }

        public static string MergeRTFs(string RTF1, string RTF2)
        {
            if (string.IsNullOrEmpty(RTF1) && string.IsNullOrEmpty(RTF2))
                return null;
            if (string.IsNullOrEmpty(RTF1))
                return RTF2;
            if (string.IsNullOrEmpty(RTF2))
                return RTF1;
            string rtf1 = RTF1;
            string rtf2 = RTF2;
            rtf1 = rtf1.Substring(0, (rtf1.LastIndexOf("}")) - 1);
            rtf2 = rtf2.Substring(1);
            return rtf1 + "\n" + rtf2;
        }

        public static void RemoveDeadScheduledTaskThreads()
        {
            if (aliveScheduledTaskThreads == null)
                return;
            List<Guid> deleteList = new List<Guid>();
            foreach (KeyValuePair<Guid, System.Threading.Thread> kv in aliveScheduledTaskThreads)
            {
                if (((System.Threading.Thread)kv.Value).IsAlive == false)
                    deleteList.Add(kv.Key);
            }

            foreach (Guid guid in deleteList)
            {
                aliveScheduledTaskThreads.Remove(guid);
            }
        }

        public static void RunTaskScript(object bs)
        {
            BaseScheduledTask parambs = (BaseScheduledTask)bs;
            TTObjectContext ctx = new TTObjectContext(false);
            BaseScheduledTask baseScheduledTask = (BaseScheduledTask)ctx.GetObject(parambs.ObjectID, parambs.ObjectDef);
            try
            {
                baseScheduledTask.TaskScript();
            }
            catch (Exception ex)
            {
                baseScheduledTask.AddLog(ex.ToString());
            }
        }

        public static void AutoScript()
        {
            ArrayList taskCol = new ArrayList();
            ArrayList dateCol = new ArrayList();
            int hour;
            int minute;
            bool STAvailableToRun = true;
            TTObjectContext objectContext = new TTObjectContext(false);
            foreach (BaseScheduledTask baseScheduledTask in BaseScheduledTask.GetAvailableTasks(objectContext))
            {
                STAvailableToRun = true;
                if (baseScheduledTask.StartDate > Common.RecTime().Date)
                    STAvailableToRun = false;
                if (baseScheduledTask.WorkHour != null)
                {
                    hour = Common.RecTime().Hour;
                    if (baseScheduledTask.WorkHour != hour)
                        STAvailableToRun = false;
                    else
                    {
                        if (baseScheduledTask.WorkMinute != null)
                        {
                            minute = Common.RecTime().Minute;
                            if (baseScheduledTask.WorkMinute != minute)
                                STAvailableToRun = false;
                        }
                    }
                }

                if (baseScheduledTask.Recurrency != null)
                {
                    if ((int)baseScheduledTask.Recurrency == (int)baseScheduledTask.ExecutionCount)
                        STAvailableToRun = false;
                }

                if (baseScheduledTask.LastExecutionDate != null && STAvailableToRun == true)
                {
                    DateTime lastExecution = Convert.ToDateTime(baseScheduledTask.LastExecutionDate);
                    DateTime curDate = Common.RecTime();
                    switch (baseScheduledTask.Period)
                    {
                        case ScheduledTaskPeriodEnum.OneTime:
                            break;
                        case ScheduledTaskPeriodEnum.Daily:
                            if (curDate < lastExecution.AddDays(1))
                                STAvailableToRun = false;
                            break;
                        case ScheduledTaskPeriodEnum.Weekly:
                            if (curDate < lastExecution.AddDays(7))
                                STAvailableToRun = false;
                            break;
                        case ScheduledTaskPeriodEnum.Monthly:
                            if (curDate < lastExecution.AddMonths(1))
                                STAvailableToRun = false;
                            break;
                        case ScheduledTaskPeriodEnum.Hourly:
                            if (curDate < lastExecution.AddHours(1))
                                STAvailableToRun = false;
                            break;
                        default:
                            break;
                    }
                }

                if (STAvailableToRun)
                    taskCol.Add(baseScheduledTask);
            }

            RemoveDeadScheduledTaskThreads();
            foreach (object obj in taskCol)
            {
                BaseScheduledTask bs = (BaseScheduledTask)obj;
                if (aliveScheduledTaskThreads.ContainsKey(bs.ObjectID) == false)
                {
                    try
                    {
                        System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(RunTaskScript));
                        thread.Name = bs.ObjectID.ToString();
                        aliveScheduledTaskThreads.Add(bs.ObjectID, thread);
                        bs.ExecutionCount += 1;
                        bs.LastExecutionDate = Common.RecTime();
                        objectContext.Save();
                        thread.Start(bs);
                    }
                    catch (Exception ex)
                    {
                        ((BaseScheduledTask)obj).AddLog(ex.Message.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// filterExpression'da IN ile bakılacak item'ların sayısı > 1000 ise 1000'erli olarak OR'lar
        /// </summary>
        /// <param name = "filterExpression"></param>
        /// <param name = "GuidList"></param>
        /// <returns></returns>
        public static string CreateFilterExpressionOfGuidList(string filterExpression, string nqlAttribute, List<Guid> GuidList)
        {
            List<StringBuilder> criteriaList = new List<StringBuilder>();
            StringBuilder sbObjIDs = new StringBuilder();
            int i = 0;
            foreach (Guid ID in GuidList)
            {
                i++;
                if (sbObjIDs.Length > 0)
                    sbObjIDs.Append(',');
                sbObjIDs.Append(ConnectionManager.GuidToString(ID));
                if (i == 1000)
                {
                    i = 0;
                    criteriaList.Add(sbObjIDs);
                    sbObjIDs = new StringBuilder();
                }
            }

            if (i > 0 && i < 1000)
                criteriaList.Add(sbObjIDs);
            if (!string.IsNullOrEmpty(filterExpression))
                filterExpression += " AND ";
            i = 1;
            foreach (StringBuilder ids in criteriaList)
            {
                if (i == 1)
                    filterExpression += "(";
                if (String.IsNullOrEmpty(nqlAttribute))
                    filterExpression += "OBJECTID IN (" + ids + ")";
                else
                    filterExpression += nqlAttribute + " IN (" + ids + ")";
                if (i < criteriaList.Count)
                    filterExpression += " OR ";
                if (i == criteriaList.Count)
                    filterExpression += ")";
                i++;
            }

            return filterExpression;
        }

        public static string CreateFilterExpressionOfStringList(string nqlAttribute, List<string> stringList)
        {
            string filterExpression = nqlAttribute + " IN (";
            foreach (string procCode in stringList)
            {
                filterExpression += "'" + procCode + "',";
            }
            filterExpression = filterExpression.Remove(filterExpression.Length - 1);
            filterExpression += ")";

            return filterExpression;
        }

        /// <summary>
        /// Belirtilen tipte, Xml'e serialize edilebilen objeyi Xml string'e çevirir.
        /// </summary>
        /// <typeparam name="T">Serializable Xml class</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeToString<T>(T value)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamespaces);
                return stream.ToString();
            }
        }

        public static string CreateFilterExpressionOfIntegerList(string filterExpression, string nqlAttribute, List<int> IntegerList)
        {
            List<StringBuilder> criteriaList = new List<StringBuilder>();
            StringBuilder sbObjIDs = new StringBuilder();
            int i = 0;
            foreach (int ID in IntegerList)
            {
                i++;
                if (sbObjIDs.Length > 0)
                    sbObjIDs.Append(',');
                sbObjIDs.Append(ID.ToString());
                if (i == 1000)
                {
                    i = 0;
                    criteriaList.Add(sbObjIDs);
                    sbObjIDs = new StringBuilder();
                }
            }

            if (i > 0 && i < 1000)
                criteriaList.Add(sbObjIDs);
            if (!string.IsNullOrEmpty(filterExpression))
                filterExpression += " AND ";
            i = 1;
            foreach (StringBuilder ids in criteriaList)
            {
                if (i == 1)
                    filterExpression += "(";
                if (String.IsNullOrEmpty(nqlAttribute))
                    filterExpression += "D IN (" + ids + ")";
                else
                    filterExpression += nqlAttribute + " IN (" + ids + ")";
                if (i < criteriaList.Count)
                    filterExpression += " OR ";
                if (i == criteriaList.Count)
                    filterExpression += ")";
                i++;
            }

            return filterExpression;
        }

        public static bool CheckProcedureDefinitionIsActive(ProcedureDefinition procedureDefinition)
        {
            return procedureDefinition.IsActive.HasValue == true ? procedureDefinition.IsActive.Value : false;
        }

        public static bool IsBaseOfInheritedObject(TTObjectDef inheritedObjectDef, TTObjectDef baseObjectDef)
        {
            if (inheritedObjectDef.ID == baseObjectDef.ID)
                return true;
            if (inheritedObjectDef.BaseObjectDef == null)
                return false;
            return Common.IsBaseOfInheritedObject((TTObjectDef)inheritedObjectDef.BaseObjectDef, baseObjectDef);
        }

        public static PatientGroupEnum GetPatientGroupEnumByValue(int value)
        {
            foreach (TTDataDictionary.EnumValueDef r in TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs.Values)
            {
                if ((int)r.Value == value)
                {
                    return (TTObjectClasses.PatientGroupEnum)r.EnumValue;
                }
            }

            throw new Exception(SystemMessage.GetMessageV2(658, value.ToString()));
        }

        public static DateTime GetLastDayOfMounth(DateTime date)
        {
            if (date == null)
                date = DateTime.MinValue;
            DateTime firstDay = new DateTime(date.Year, date.Month, 1);
            DateTime lastday = firstDay.AddMonths(1).AddDays(-1);
            return lastday;
        }

        public static string PrepareBarcode(string barcode)
        {
            string prepareBarcode = string.Empty;
            if (barcode.Length > 25)
            {
                const char SEPERATOR = (char)221;
                if (barcode.IndexOf(SEPERATOR) > 0)
                {
                    string sParca1 = string.Empty;
                    string sParca2 = string.Empty;
                    sParca1 = barcode.Substring(2, barcode.IndexOf(SEPERATOR) - 2);
                    sParca2 = barcode.Substring(barcode.IndexOf(SEPERATOR) + 1, barcode.Length - barcode.IndexOf(SEPERATOR) - 1);
                    prepareBarcode = sParca1.Substring(0, 14);
                }
                else
                    prepareBarcode = barcode.Substring(2, 14);
            }
            else
                prepareBarcode = barcode.Replace("½", "+");
            return prepareBarcode;
        }

        public static string LatinToRomen(int latinSayi)
        {
            char[] romenChar = { 'I', 'V', 'X', 'L', 'C', 'D', 'M', 'K', 'O', 'B' };
            string str = string.Empty;
            string strLatinSayi = latinSayi.ToString();
            int j = strLatinSayi.Length;
            int i;
            for (int k = 0; k < strLatinSayi.Length; k++)
            {
                i = 2 * j - 2;
                j--;
                switch (strLatinSayi[k])
                {
                    case '1':
                        str += romenChar[i].ToString();
                        break;
                    case '2':
                        str += romenChar[i].ToString() + romenChar[i].ToString();
                        break;
                    case '3':
                        str += romenChar[i].ToString() + romenChar[i].ToString() + romenChar[i].ToString();
                        break;
                    case '4':
                        str += romenChar[i].ToString() + romenChar[i + 1].ToString();
                        break;
                    case '5':
                        str += romenChar[i + 1].ToString();
                        break;
                    case '6':
                        str += romenChar[i + 1].ToString() + romenChar[i].ToString();
                        break;
                    case '7':
                        str += romenChar[i + 1].ToString() + romenChar[i].ToString() + romenChar[i].ToString();
                        break;
                    case '8':
                        str += romenChar[i + 1].ToString() + romenChar[i].ToString() + romenChar[i].ToString() + romenChar[i].ToString();
                        break;
                    case '9':
                        str += romenChar[i].ToString() + romenChar[i + 2].ToString();
                        break;
                }
            }

            return str;
        }

        public static ExaminationQueueItem CallNextPatient(TTObjectContext objectContext, ResSection resSection, Guid currentResourceID)
        {
            ResSection selectedOutPatientResource = resSection;
            bool doIt = false;
            if (selectedOutPatientResource != null)
            {
                if (selectedOutPatientResource is ResDepartment)
                {
                    foreach (ResPoliclinic pol in ((ResDepartment)selectedOutPatientResource).Policlinics)
                    {
                        if (pol.PatientCallSystemInUse == true)
                        {
                            doIt = true;
                            break;
                        }
                    }

                    foreach (ResClinic clinic in ((ResDepartment)selectedOutPatientResource).Clinics)
                    {
                        doIt = true;
                        break;
                    }
                }
                else if (selectedOutPatientResource is ResPoliclinic)
                {
                    if (((ResPoliclinic)selectedOutPatientResource).PatientCallSystemInUse == true)
                        doIt = true;
                }
                else if (selectedOutPatientResource is ResClinic)
                {
                    if (((ResClinic)selectedOutPatientResource).PCSInUse == true)
                        doIt = true;
                }
                else if (selectedOutPatientResource is ResHealthCommittee)
                {
                    if (((ResHealthCommittee)selectedOutPatientResource).PCSInUse == true)
                        doIt = true;
                }
            }

            if (doIt == true)
            {
                if (Common.CurrentResource.SelectedQueue == null)
                    throw new TTException(SystemMessage.GetMessage(659));
                ExaminationQueueItem queueItem = null;
                Dictionary<Guid, Common.SortedExaminationQueueItems> sortedQueueItems = Common.GetSortedQueueItems(objectContext, Common.CurrentResource.SelectedQueue);
                Common.SortedExaminationQueueItems items;
                if (sortedQueueItems.ContainsKey(Common.CurrentResource.ObjectID))
                {
                    items = sortedQueueItems[currentResourceID];
                    long itemsCount = items.ExaminationQueueItemList.Count;
                    long allItemsCount = 0;
                    foreach (KeyValuePair<Guid, Common.SortedExaminationQueueItems> kp in sortedQueueItems)
                    {
                        allItemsCount += kp.Value.ExaminationQueueItemList.Count;
                    }

                    if (allItemsCount > 0)
                    {
                        foreach (ExaminationQueueItem examQueueItem in items.ExaminationQueueItemList)
                        {
                            if (examQueueItem.EpisodeAction != null || examQueueItem.SubactionProcedureFlowable != null)
                            {
                                queueItem = examQueueItem;
                                queueItem.ExaminationQueueDefinition = Common.CurrentResource.SelectedQueue;
                                queueItem.DestinationResource = Common.CurrentResource.CurrentExaminationRoom;
                                queueItem.NextItemsCount = allItemsCount - 1;
                                queueItem.CurrentStateDefID = ExaminationQueueItem.States.Called;
                                return queueItem;
                            }
                        }
                    }
                }
            }
            else
                throw new TTException(SystemMessage.GetMessage(660));
            return null;
        }

        //Doktorun kuyruğunda hasta tükendiğinde başka bir kuyruktan hasta seçebilmesi için yazıldı.
        public static ExaminationQueueItem GetNextItemByQueue(TTObjectContext objectContext, ExaminationQueueDefinition examinationQueueDef)
        {
            if (examinationQueueDef != null)
            {
                ExaminationQueueItem queueItem = null;
                Dictionary<Guid, Common.SortedExaminationQueueItems> sortedQueueItems = Common.GetSortedQueueItems(objectContext, examinationQueueDef);
                List<ExaminationQueueItem> allExaminationQueueItems = new List<ExaminationQueueItem>();
                long allItemsCount = 0;
                foreach (KeyValuePair<Guid, Common.SortedExaminationQueueItems> kp in sortedQueueItems)
                {
                    allItemsCount += kp.Value.ExaminationQueueItemList.Count;
                    foreach (ExaminationQueueItem eQueueItem in kp.Value.ExaminationQueueItemList)
                    {
                        allExaminationQueueItems.Add(eQueueItem);
                    }
                }

                if (allItemsCount > 0)
                {
                    foreach (ExaminationQueueItem examQueueItem in allExaminationQueueItems)
                    {
                        if (examQueueItem.Doctor == null)
                        {
                            if (examQueueItem.EpisodeAction != null || examQueueItem.SubactionProcedureFlowable != null)
                            {
                                queueItem = examQueueItem;
                                queueItem.ExaminationQueueDefinition = Common.CurrentResource.SelectedQueue;
                                queueItem.DestinationResource = Common.CurrentResource.CurrentExaminationRoom;
                                queueItem.NextItemsCount = allItemsCount - 1;
                                return queueItem;
                            }
                        }
                    }
                }
            }
            else
                throw new TTException(SystemMessage.GetMessage(2428)); //kuyruk seçmediniz hatası verilecek.
            return null;
        }

        [Serializable]
        public class SortedExaminationQueueItems
        {
            private Resource _resource;
            public Resource Resource
            {
                get
                {
                    return _resource;
                }
            }

            private List<ExaminationQueueItem> _examinationQueueItemList;
            public List<ExaminationQueueItem> ExaminationQueueItemList
            {
                get
                {
                    return _examinationQueueItemList;
                }
            }

            private int _slotDuration;
            private int _nextIndex;
            private DateTime _nextStartTime;
            public DateTime NextStartTime
            {
                get
                {
                    return _nextStartTime;
                }
            }

            public SortedExaminationQueueItems(Resource resource, int slotDuration)
            {
                _resource = resource;
                _examinationQueueItemList = new List<ExaminationQueueItem>();
                _nextStartTime = Common.RecTime();
                _slotDuration = slotDuration;
            }

            internal void AddAppointmentItem(ExaminationQueueItem item)
            {
                //Henüz kanbulü alınmamış MHRS randevularının kuyrukta gözükmemesi için eklendi.
                if (item.EpisodeAction != null || item.SubactionProcedureFlowable != null)
                {
                    _examinationQueueItemList.Add(item);
                    item.CalculatedEnteranceTime = item.CallTime.Value;
                }
            }

            internal void InitForNonAppointedItems()
            {
                //TODO: randevu duration dikkate alınsa iyi olur
                _nextStartTime = Common.RecTime();
                _nextIndex = 0;
                foreach (ExaminationQueueItem item in _examinationQueueItemList)
                {
                    if (item.DivertedTime.Value < Common.RecTime())
                        _nextStartTime = _nextStartTime.AddMinutes(_slotDuration);
                    else
                    {
                        if (Math.Abs(item.DivertedTime.Value.Subtract(_nextStartTime).TotalMinutes) < _slotDuration)
                            _nextStartTime = item.DivertedTime.Value.AddMinutes(_slotDuration);
                        else
                            break;
                    }

                    _nextIndex++;
                }
            }

            internal void AddNonAppointmentItem(ExaminationQueueItem item)
            {
                if (_nextIndex >= _examinationQueueItemList.Count)
                {
                    item.CalculatedEnteranceTime = _nextStartTime;
                    _examinationQueueItemList.Add(item);
                    _nextIndex++;
                    _nextStartTime = _nextStartTime.AddMinutes(_slotDuration);
                }
                else
                {
                    item.CalculatedEnteranceTime = _nextStartTime;
                    _examinationQueueItemList.Insert(_nextIndex, item);
                    _nextIndex++;
                    _nextStartTime = _nextStartTime.AddMinutes(_slotDuration);
                    for (int i = _nextIndex; i < _examinationQueueItemList.Count; i++)
                    {
                        ExaminationQueueItem appointmentItem = _examinationQueueItemList[i];
                        if (Math.Abs(appointmentItem.DivertedTime.Value.Subtract(_nextStartTime).TotalMinutes) < _slotDuration)
                            _nextStartTime = appointmentItem.DivertedTime.Value.AddMinutes(_slotDuration);
                        else
                            break;
                        _nextIndex++;
                    }
                }
            }
        }

        public static Dictionary<Guid, Common.SortedExaminationQueueItems> GetSortedQueueItems(TTObjectContext context, ExaminationQueueDefinition queue)
        {
            Dictionary<Guid, Common.SortedExaminationQueueItems> matrix = new Dictionary<Guid, Common.SortedExaminationQueueItems>();
            matrix = GetSortedQueueItemsV2(context, queue, false);
            return matrix;
        }

        public static string GetSortedQueueItemsByQueueID(Guid queueID, bool includeCalleds)
        {
            TTObjectContext context = new TTObjectContext(false);
            ExaminationQueueDefinition exQueueDef = (ExaminationQueueDefinition)context.GetObject(queueID, typeof(ExaminationQueueDefinition).Name);
            Dictionary<Guid, Common.SortedExaminationQueueItems> matrix = new Dictionary<Guid, Common.SortedExaminationQueueItems>();
            matrix = GetSortedQueueItemsV2(context, exQueueDef, includeCalleds);
            StringBuilder strb = new StringBuilder();
            foreach (KeyValuePair<Guid, Common.SortedExaminationQueueItems> kp in matrix)
            {
                Resource resource = (Resource)context.GetObject(kp.Key, typeof(Resource).Name);
                strb.AppendLine(resource.ObjectID.ToString() + "_Resource");
                foreach (ExaminationQueueItem item in kp.Value.ExaminationQueueItemList)
                {
                    if (item["APPOINTMENT"] == null)
                        strb.AppendLine("_Appointment");
                    else
                        strb.AppendLine(item["APPOINTMENT"].ToString() + "_Appointment");
                    strb.AppendLine(item.CallTime.ToString() + "_CallTime");
                    strb.AppendLine(item.CurrentStateDefID.ToString() + "_CurrentStateDefID");
                    strb.AppendLine(item.Patient.FullName + "_FullName");
                    strb.AppendLine(item.OrderNO.ToString() + "_OrderNo");
                    if (item["EPISODEACTION"] == null)
                        strb.AppendLine("_EpisodeAction");
                    else
                        strb.AppendLine(item.EpisodeAction.ObjectID.ToString() + "_EpisodeAction");
                    if (item.DivertedTime != null)
                        strb.AppendLine(item.DivertedTime.ToString() + "_DivertedTime");
                    strb.AppendLine(item.LastState.BranchDate.ToString() + "_LastBranchDate");
                    strb.AppendLine(item.Priority.ToString() + "_Priority");
                    if (item.PriorityReason != null)
                        strb.AppendLine(item.PriorityReason.ToString() + "_PrReason");
                    if (item.DestinationResource == null)
                        strb.AppendLine("_DestinationResource");
                    else
                        strb.AppendLine(item.DestinationResource.Name + "_DestinationResource");
                    if (item.IsEmergency != null)
                        strb.AppendLine(item.IsEmergency.ToString() + "_IsEmergency");
                }
            }

            return strb.ToString();
        }

        public class QueuePatient
        {
            public string patientName
            {
                get;
                set;
            }

            public Guid patientObjectID
            {
                get;
                set;
            }

            public string OrderNO
            {
                get;
                set;
            }

            public string PriorityReason
            {
                get;
                set;
            }

            public string Priority
            {
                get;
                set;
            }

            public string QueueDate
            {
                get;
                set;
            }

            public DateTime? CallTime
            {
                get;
                set;
            }

            public string DivertedTime
            {
                get;
                set;
            }

            public string Doctor
            {
                get;
                set;
            }
            public int Index
            {
                get;
                set;
            }
            public Guid ObjectID
            {
                get;
                set;
            }

            public Boolean IsEmergency
            {
                get;
                set;
            }
            public Guid SubActionProcedureObjectID
            {
                get;
                set;
            }
        }

        public class QueueItems
        {
            public string doctorName
            {
                get;
                set;
            }

            public string polName
            {
                get;
                set;
            }

            public string hospitalName
            {
                get;
                set;
            }

            public List<Common.QueuePatient> patient = new List<Common.QueuePatient>();
        }

        public static string GetLcdNotificationString(Guid queueID, Guid DrObjectID)
        {
            TTObjectContext context = new TTObjectContext(true);
            BindingList<QueueResourceWorkPlanDefinition> currentResourceWorkPlanDefs = QueueResourceWorkPlanDefinition.GetTodaysPlanByQueueByResource(context, Common.RecTime().Date, DrObjectID, queueID);
            foreach (QueueResourceWorkPlanDefinition currentResourceWorkPlanDef in currentResourceWorkPlanDefs)
            {
                if (currentResourceWorkPlanDef.LCDNotification != null)
                    return currentResourceWorkPlanDef.LCDNotification.Notification;
            }
            return string.Empty;
        }

        public static LCDNotificationDefinition GetLCDNotification(Guid queueID, Guid DrObjectID)
        {
            TTObjectContext context = new TTObjectContext(true);
            BindingList<QueueResourceWorkPlanDefinition> currentResourceWorkPlanDefs = QueueResourceWorkPlanDefinition.GetTodaysPlanByQueueByResource(context, Common.RecTime().Date, DrObjectID, queueID);
            foreach (QueueResourceWorkPlanDefinition currentResourceWorkPlanDef in currentResourceWorkPlanDefs)
            {
                if (currentResourceWorkPlanDef.LCDNotification != null)
                    return currentResourceWorkPlanDef.LCDNotification;
            }
            return null;
        }

        public static void SetLCDNotification(Guid queueID, LCDNotificationDefinition lcdNotification)
        {
            TTObjectContext context = new TTObjectContext(false);
            BindingList<QueueResourceWorkPlanDefinition> currentResourceWorkPlanDefs = QueueResourceWorkPlanDefinition.GetTodaysPlanByQueueByResource(context, Common.RecTime().Date, Common.CurrentResource.ObjectID, queueID);
            foreach (QueueResourceWorkPlanDefinition currentResourceWorkPlanDef in currentResourceWorkPlanDefs)
            {
                currentResourceWorkPlanDef.LCDNotification = lcdNotification;
            }
            context.Save();
        }

        public static Common.QueueItems GetSortedQueue(Guid queueID, bool includeCalleds)
        {
            TTObjectContext context = new TTObjectContext(false);
            ExaminationQueueDefinition exQueueDef = (ExaminationQueueDefinition)context.GetObject(queueID, typeof(ExaminationQueueDefinition).Name);
            Dictionary<Guid, Common.SortedExaminationQueueItems> matrix = new Dictionary<Guid, Common.SortedExaminationQueueItems>();
            matrix = GetSortedQueueItemsV2(context, exQueueDef, includeCalleds);
            Common.QueueItems items = new Common.QueueItems();
            StringBuilder strb = new StringBuilder();
            foreach (KeyValuePair<Guid, Common.SortedExaminationQueueItems> kp in matrix)
            {
                Resource resource = (Resource)context.GetObject(kp.Key, typeof(Resource).Name);
                strb.AppendLine(resource.ObjectID.ToString() + "_Resource");
                //Kuyruk tanımının birimi poliklinikse, ama dönen kuyruk sıra nesnesinin resource u, doktor, diş hekimi ya da intern doktor değilse, kaynak kuyruk çalışma planında tanımlı doktoru LCD de göstersin
                if(exQueueDef.ResSection is ResPoliclinic && resource is ResUser && ((ResUser)resource).UserType != UserTypeEnum.Doctor && ((ResUser)resource).UserType != UserTypeEnum.Dentist && ((ResUser)resource).UserType != UserTypeEnum.InternDoctor)
                {
                    BindingList<Resource> doctorList = exQueueDef.GetWorkingDoctorResources(context);
                    if (doctorList != null && doctorList.Count > 0)
                        items.doctorName = doctorList[0].Name.ToString();
                    else
                        items.doctorName = "";
                }
                else
                    items.doctorName = resource.Name.ToString();
                items.polName = exQueueDef.Name.ToString();
                int i = 0;
                foreach (ExaminationQueueItem item in kp.Value.ExaminationQueueItemList)
                {
                    bool addToItems = true;
                    i++;
                    ////Eğer randevulu hasta ise ve randevu verilen dokto, kuyruğun doktoru değilse LCD de göstermesin. Sadece randevu verilen doktorun LCD sinde gözüksün.
                    //if (item.Appointment != null && item.Doctor.ObjectID.Equals(resource.ObjectID) == false)
                    //    addToItems = false;
                    if (addToItems)
                    {
                        Common.QueuePatient qpatient = new Common.QueuePatient();
                        qpatient.CallTime = item.CallTime;
                        qpatient.patientName = item.Patient.FullName;
                        qpatient.patientObjectID = item.Patient.ObjectID;
                        if (item.OrderNo == null)
                            qpatient.OrderNO = item.OrderNO.ToString();
                        else
                        {
                            if (item.OrderNo == "0" && item.Appointment != null)
                                qpatient.CallTime = item.Appointment.StartTime;
                            qpatient.OrderNO = item.OrderNo;
                        }
                        if (item.EpisodeAction != null)
                            qpatient.ObjectID = item.EpisodeAction.ObjectID;
                        if (item.SubactionProcedureFlowable != null)
                            qpatient.SubActionProcedureObjectID = item.SubactionProcedureFlowable.ObjectID;
                        qpatient.PriorityReason = item.PriorityReason;
                        qpatient.Priority = item.Priority.ToString();
                        qpatient.QueueDate = item.QueueDate.ToString();
                        qpatient.DivertedTime = item.DivertedTime.ToString();
                        qpatient.IsEmergency = (Boolean)item.IsEmergency;
                        qpatient.Index = i;
                        items.patient.Add(qpatient);
                    }
                }
            }

            return items;
        }

        private static DateTime FindMinDateTimeOfNextQueueItems(Dictionary<Guid, Common.SortedExaminationQueueItems> matrix, out Common.SortedExaminationQueueItems queueItems)
        {
            DateTime minDateTime = DateTime.MaxValue;
            minDateTime = DateTime.MaxValue;
            queueItems = null;
            foreach (KeyValuePair<Guid, Common.SortedExaminationQueueItems> items in matrix)
            {
                if (items.Value.NextStartTime < minDateTime)
                {
                    minDateTime = items.Value.NextStartTime;
                    queueItems = items.Value;
                }
            }

            return minDateTime;
        }

        private static void InsertNextQueueItem(ExaminationQueueItem nextItem, Dictionary<Guid, Common.SortedExaminationQueueItems> matrix)
        {
            Common.SortedExaminationQueueItems queueItems = null;
            if (nextItem.Doctor != null && matrix.TryGetValue(nextItem.Doctor.ObjectID, out queueItems))
            {
                queueItems.AddNonAppointmentItem(nextItem);
            }
            else
            {
                FindMinDateTimeOfNextQueueItems(matrix, out queueItems);
                if (queueItems != null)
                    queueItems.AddNonAppointmentItem(nextItem);
            }
        }


        public static string GetFormattedAdmissionQueueNumber(EpisodeAction episodeAction, PatientAdmission pa, bool ignoreAppointment = true, bool IsAppointmentNull = true)
        {

            if (pa.ResultQueueNumber.Value.HasValue)
            {
                if (pa.ResultQueueNumber.Value.Value < 10)
                    return "S-00" + pa.ResultQueueNumber.Value.Value.ToString();
                else if (pa.ResultQueueNumber.Value.Value < 100)
                    return "S-0" + pa.ResultQueueNumber.Value.Value.ToString();
                else
                    return "S-" + pa.ResultQueueNumber.Value.Value.ToString();
            }
            else if (ignoreAppointment || IsAppointmentNull)
            {
                if (episodeAction != null && episodeAction.AdmissionQueueNumber.Value.HasValue)// Sağlık Kurulu  ve Konsültasyon 
                {
                    if (episodeAction.AdmissionQueueNumber.Value < 10)
                        return "00" + episodeAction.AdmissionQueueNumber.Value.ToString();
                    else if (episodeAction.AdmissionQueueNumber.Value < 100)
                        return "0" + episodeAction.AdmissionQueueNumber.Value.ToString();
                    else
                        return episodeAction.AdmissionQueueNumber.Value.ToString();
                }
                else if (pa.AdmissionQueueNumber.Value.HasValue)
                {
                    if (pa.AdmissionQueueNumber.Value.Value < 10)
                        return "00" + pa.AdmissionQueueNumber.Value.Value.ToString();
                    else if (pa.AdmissionQueueNumber.Value.Value < 100)
                        return "0" + pa.AdmissionQueueNumber.Value.Value.ToString();
                    else
                        return pa.AdmissionQueueNumber.Value.Value.ToString();
                }

            }
            return "";
        }
        public static Dictionary<Guid, Common.SortedExaminationQueueItems> GetSortedQueueItemsV2(TTObjectContext context, ExaminationQueueDefinition queue, bool includeCalleds)
        {
            IList<Resource> doctors = queue.GetWorkingResources(context);
            int slotDuration = 15;
            if (queue.DisplayPeriod.HasValue)
                slotDuration = queue.DisplayPeriod.Value;
            List<Guid> doctorGUIDs = new List<Guid>();
            Dictionary<Guid, Common.SortedExaminationQueueItems> matrix = new Dictionary<Guid, Common.SortedExaminationQueueItems>();
            foreach (ResUser doctor in doctors)
            {
                if (doctor.ObjectID == Common.CurrentResource.ObjectID)
                {
                    doctorGUIDs.Add(doctor.ObjectID);
                    matrix.Add(doctor.ObjectID, new Common.SortedExaminationQueueItems(doctor, slotDuration));
                }
            }

            foreach (ResUser doctor in doctors)
            {
                if (doctor.ObjectID != Common.CurrentResource.ObjectID)
                {
                    doctorGUIDs.Add(doctor.ObjectID);
                    matrix.Add(doctor.ObjectID, new Common.SortedExaminationQueueItems(doctor, slotDuration));
                }
            }

            if (doctorGUIDs.Count == 0)
                doctorGUIDs.Add(Guid.Empty);
            BindingList<ExaminationQueueItem> nextItems;
            //            DateTime startDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 08:00");
            //            DateTime endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59");
            //            if(includeCalleds)
            //                nextItems = ExaminationQueueItem.GetActiveQueueItemsByQueueByDate(context, doctorGUIDs, queue.ObjectID, Common.RecTime().Date.AddDays(1), Common.RecTime().Date);
            //            else
            int poliklinikOrtalamaBeklemeSuresi = Convert.ToInt32(SystemParameter.GetParameterValue("POLIKLINIKORTALAMABEKLEMESURESI", "3"));
            nextItems = ExaminationQueueItem.GetNextItemsByQueueByDate(context, queue.ObjectID, Common.RecTime().Date.AddHours(-poliklinikOrtalamaBeklemeSuresi), Common.RecTime().Date.AddHours(23).AddMinutes(59).AddSeconds(59), doctorGUIDs);
            List<ExaminationQueueItem> randevusuzList = new List<ExaminationQueueItem>();
            List<ExaminationQueueItem> divertedList = new List<ExaminationQueueItem>();
            foreach (ExaminationQueueItem item in nextItems)
            {
                if (item.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                {
                    divertedList.Add(item);
                    if (item.EpisodeAction != null)
                    {
                        //if (item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                        //{
                        //    if (item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "S-00" + item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else if (item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "S-0" + item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = "S-" + item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //}
                        //else if (item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.HasValue && item["APPOINTMENT"] == null)
                        //{
                        //    if (item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "00" + item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else if (item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "0" + item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //}
                        //else if(item["APPOINTMENT"] != null)
                        //    item.OrderNo = "0";
                        item.OrderNo = Common.GetFormattedAdmissionQueueNumber(item.EpisodeAction, item.EpisodeAction.SubEpisode.PatientAdmission, false, item["APPOINTMENT"] == null);
                        if (String.IsNullOrEmpty(item.OrderNo) && item["APPOINTMENT"] != null)
                        {
                            item.OrderNo = "0";
                        }
                    }
                    else if (item.SubactionProcedureFlowable != null)
                    {
                        //if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                        //{
                        //    if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "S-00" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "S-0" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = "S-" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //}
                        //else if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.HasValue && item["APPOINTMENT"] == null)
                        //{
                        //    if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "00" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "0" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //}
                        //else if (item["APPOINTMENT"] != null)
                        //    item.OrderNo = "0";
                        item.OrderNo = Common.GetFormattedAdmissionQueueNumber(null, item.SubactionProcedureFlowable.SubEpisode.PatientAdmission, false, item["APPOINTMENT"] == null);
                        if (String.IsNullOrEmpty(item.OrderNo) && item["APPOINTMENT"] != null)
                        {
                            item.OrderNo = "0";
                        }
                    }
                    item.OrderNO = divertedList.Count;
                }
                else if (item["APPOINTMENT"] == null)
                {
                    randevusuzList.Add(item);
                    if (item.EpisodeAction != null)
                    {
                        //if (item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                        //{
                        //    if (item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "S-00" + item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else if (item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "S-0" + item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = "S-" + item.EpisodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //}
                        //else if (item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.HasValue)
                        //{
                        //    if (item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "00" + item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else if (item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "0" + item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = item.EpisodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //}

                        item.OrderNo = Common.GetFormattedAdmissionQueueNumber(item.EpisodeAction, item.EpisodeAction.SubEpisode.PatientAdmission, true);

                    }
                    else if (item.SubactionProcedureFlowable != null)
                    {
                        //if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                        //{
                        //    if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "S-00" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "S-0" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = "S-" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                        //}
                        //else if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.HasValue)
                        //{
                        //    if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 10)
                        //        item.OrderNo = "00" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else if (item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 100)
                        //        item.OrderNo = "0" + item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //    else
                        //        item.OrderNo = item.SubactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                        //}
                        item.OrderNo = Common.GetFormattedAdmissionQueueNumber(null, item.SubactionProcedureFlowable.SubEpisode.PatientAdmission, true);

                    }
                    item.OrderNO = randevusuzList.Count;
                }
                else
                {
                    Common.SortedExaminationQueueItems sortedItems;
                    if (item.Doctor != null && matrix.TryGetValue(item.Doctor.ObjectID, out sortedItems))
                    {
                        sortedItems.AddAppointmentItem(item);
                    }
                }
            }

            foreach (Common.SortedExaminationQueueItems items in matrix.Values)
            {
                items.InitForNonAppointedItems();
            }

            //ertelenmişleri erteleme saatine göre sırala.
            while (true)
            {
                bool exchanged = false;
                for (int i = 0; i < divertedList.Count - 1; i++)
                {
                    if (divertedList[i].DivertedTime > divertedList[i + 1].DivertedTime)
                    {
                        ExaminationQueueItem item = divertedList[i];
                        divertedList[i] = divertedList[i + 1];
                        divertedList[i + 1] = item;
                        exchanged = true;
                        break;
                    }
                }

                if (exchanged == false)
                    break;
            }

            while (randevusuzList.Count > 0 || divertedList.Count > 0)
            {
                Common.SortedExaminationQueueItems queueItems = null;
                //ilk önce doktoru belli olan ertelenmişleri kontrol et, saati geçmişleri yerleştir.
                int ind = 0;
                ExaminationQueueItem divertedItem = null;
                while (ind < divertedList.Count)
                {
                    ExaminationQueueItem item = divertedList[ind];
                    ind++;
                    if (item.Doctor != null && matrix.TryGetValue(item.Doctor.ObjectID, out queueItems))
                    {
                        if (item.DivertedTime < queueItems.NextStartTime)
                        {
                            queueItems.AddNonAppointmentItem(item);
                            ind--;
                            divertedList.RemoveAt(ind);
                        }
                    }
                    else if (divertedItem == null)
                        divertedItem = item; //doktorsuz ilk ertelenmiş
                }

                if (divertedItem == null && divertedList.Count > 0)
                    divertedItem = divertedList[0];
                ExaminationQueueItem randevusuzItem = null;
                if (randevusuzList.Count > 0)
                    randevusuzItem = randevusuzList[0];
                if (divertedItem == null)
                {
                    if (randevusuzItem == null)
                        break;
                    InsertNextQueueItem(randevusuzItem, matrix);
                    randevusuzList.Remove(randevusuzItem);
                }
                else if (randevusuzItem == null)
                {
                    InsertNextQueueItem(divertedItem, matrix);
                    divertedList.Remove(divertedItem);
                }
                else
                {
                    //diverteditem doctoru varsa bekleme saati gelmemiştir. Gelmiş olsa yukarıdaki döngüde yerleştirilirdi.
                    //Ayrıca doktoru olan diverted item'a sıra gelmiş ise doktorsuz diverted item kalmamış demektir.
                    //Bu durumda randevusuz yerleş
                    if (divertedItem.Doctor != null && matrix.TryGetValue(divertedItem.Doctor.ObjectID, out queueItems))
                    {
                        InsertNextQueueItem(randevusuzItem, matrix);
                        randevusuzList.Remove(randevusuzItem);
                    }
                    else
                    {
                        //diverted item için zaman gelmiş mi kontrolü yapmak gerekiyor.
                        DateTime minDateTime = FindMinDateTimeOfNextQueueItems(matrix, out queueItems);
                        if (divertedItem.DivertedTime < minDateTime)
                        {
                            InsertNextQueueItem(divertedItem, matrix);
                            divertedList.Remove(divertedItem);
                        }
                        else
                        {
                            InsertNextQueueItem(randevusuzItem, matrix);
                            randevusuzList.Remove(randevusuzItem);
                        }
                    }
                }
            }

            return matrix;
        }

        //Parametre olarak verilen kaynağın uzmanlık dalları ile kullanıcının bağlı olduğu birimlerin uzmanlık dalları eşleşirse True döner, Eşleşmezse False Döner.
        //Super User a hep True döner.
        public static bool IsCurrentUserReferredToTheResource(Resource resource)
        {
            if (Common.CurrentUser.IsPowerUser == false && Common.CurrentUser.IsSuperUser == false)
            {
                if (resource != null)
                {
                    bool found = false;
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        foreach (ResourceSpecialityGrid speciality1 in userResource.Resource.ResourceSpecialities)
                        {
                            foreach (ResourceSpecialityGrid speciality2 in resource.ResourceSpecialities)
                            {
                                if (speciality1.Speciality.ObjectID == speciality2.Speciality.ObjectID)
                                {
                                    return true;
                                }
                            }
                        }
                    }

                    if (!found)
                        return false;
                }
            }
            else
                return true;
            return false;
        }

        private static Dictionary<Guid, TTRemoteMethodDef> _clientAsynsRemoteMethodDefs = null;
        public static Dictionary<Guid, TTRemoteMethodDef> ClientAsyncRemoteMethodDefs
        {
            get
            {
                if (_clientAsynsRemoteMethodDefs == null)
                {
                    foreach (TTObjectDef objectDef in TTObjectDefManager.Instance.ObjectDefs)
                    {
                        if (objectDef.RemoteMethodDefs.Count > 0)
                        {
                            if (_clientAsynsRemoteMethodDefs == null)
                                _clientAsynsRemoteMethodDefs = new Dictionary<Guid, TTRemoteMethodDef>();
                            foreach (TTRemoteMethodDef remoteMethodDef in objectDef.RemoteMethodDefs)
                                if (remoteMethodDef.CallMode == RemoteMethodCallModeEnum.ASyncCall)
                                    _clientAsynsRemoteMethodDefs.Add(remoteMethodDef.RemoteMethodDefID, remoteMethodDef);
                        }
                    }
                }

                return _clientAsynsRemoteMethodDefs;
            }
        }

        public static DentalPositionEnum SetDentalPosition(int toothnumber)
        {
            switch (toothnumber)
            {
                case 51:
                    return DentalPositionEnum.RightUpperJaw;
                case 52:
                    return DentalPositionEnum.RightUpperJaw;
                case 53:
                    return DentalPositionEnum.RightUpperJaw;
                case 54:
                    return DentalPositionEnum.RightUpperJaw;
                case 55:
                    return DentalPositionEnum.RightUpperJaw;
                case 11:
                    return DentalPositionEnum.RightUpperJaw;
                case 12:
                    return DentalPositionEnum.RightUpperJaw;
                case 13:
                    return DentalPositionEnum.RightUpperJaw;
                case 14:
                    return DentalPositionEnum.RightUpperJaw;
                case 15:
                    return DentalPositionEnum.RightUpperJaw;
                case 16:
                    return DentalPositionEnum.RightUpperJaw;
                case 17:
                    return DentalPositionEnum.RightUpperJaw;
                case 18:
                    return DentalPositionEnum.RightUpperJaw;
                case 61:
                    return DentalPositionEnum.LeftUpperJaw;
                case 62:
                    return DentalPositionEnum.LeftUpperJaw;
                case 63:
                    return DentalPositionEnum.LeftUpperJaw;
                case 64:
                    return DentalPositionEnum.LeftUpperJaw;
                case 65:
                    return DentalPositionEnum.LeftUpperJaw;
                case 21:
                    return DentalPositionEnum.LeftUpperJaw;
                case 22:
                    return DentalPositionEnum.LeftUpperJaw;
                case 23:
                    return DentalPositionEnum.LeftUpperJaw;
                case 24:
                    return DentalPositionEnum.LeftUpperJaw;
                case 25:
                    return DentalPositionEnum.LeftUpperJaw;
                case 26:
                    return DentalPositionEnum.LeftUpperJaw;
                case 27:
                    return DentalPositionEnum.LeftUpperJaw;
                case 28:
                    return DentalPositionEnum.LeftUpperJaw;
                case 41:
                    return DentalPositionEnum.RightLowerJaw;
                case 42:
                    return DentalPositionEnum.RightLowerJaw;
                case 43:
                    return DentalPositionEnum.RightLowerJaw;
                case 44:
                    return DentalPositionEnum.RightLowerJaw;
                case 45:
                    return DentalPositionEnum.RightLowerJaw;
                case 46:
                    return DentalPositionEnum.RightLowerJaw;
                case 47:
                    return DentalPositionEnum.RightLowerJaw;
                case 48:
                    return DentalPositionEnum.RightLowerJaw;
                case 81:
                    return DentalPositionEnum.RightLowerJaw;
                case 82:
                    return DentalPositionEnum.RightLowerJaw;
                case 83:
                    return DentalPositionEnum.RightLowerJaw;
                case 84:
                    return DentalPositionEnum.RightLowerJaw;
                case 85:
                    return DentalPositionEnum.RightLowerJaw;
                case 31:
                    return DentalPositionEnum.RightLowerJaw;
                case 32:
                    return DentalPositionEnum.LeftLowerJaw;
                case 33:
                    return DentalPositionEnum.LeftLowerJaw;
                case 34:
                    return DentalPositionEnum.LeftLowerJaw;
                case 35:
                    return DentalPositionEnum.LeftLowerJaw;
                case 36:
                    return DentalPositionEnum.LeftLowerJaw;
                case 37:
                    return DentalPositionEnum.LeftLowerJaw;
                case 38:
                    return DentalPositionEnum.LeftLowerJaw;
                case 71:
                    return DentalPositionEnum.LeftLowerJaw;
                case 72:
                    return DentalPositionEnum.LeftLowerJaw;
                case 73:
                    return DentalPositionEnum.LeftLowerJaw;
                case 74:
                    return DentalPositionEnum.LeftLowerJaw;
                case 75:
                    return DentalPositionEnum.LeftLowerJaw;
                case 1:
                    return DentalPositionEnum.AllJaw;
                case 2:
                    return DentalPositionEnum.UpperJaw;
                case 3:
                    return DentalPositionEnum.LowerJaw;
                case 4:
                    return DentalPositionEnum.RightUpperJaw;
                case 5:
                    return DentalPositionEnum.LeftUpperJaw;
                case 6:
                    return DentalPositionEnum.RightLowerJaw;
                case 7:
                    return DentalPositionEnum.LeftLowerJaw;
                case 91:
                    return DentalPositionEnum.RightUpperJaw;
                case 92:
                    return DentalPositionEnum.LeftUpperJaw;
                case 93:
                    return DentalPositionEnum.RightLowerJaw;
                case 94:
                    return DentalPositionEnum.LeftLowerJaw;
            }

            return DentalPositionEnum.AllJaw;
        }

        public static bool OverridePrintRoles(TTUser ttUser)
        {
            foreach (TTUserRole role in ttUser.Roles)
            {
                if (role.RoleID.ToString() == "2d6d2cdf-5d46-439e-ba75-2e8f9598742e") //Genel Rapor Görevlisi
                    return true;
            }

            return false;
        }

        public static DateTime FindDueDate(int WorkDayCount, DateTime startDate)
        {
            TTObjectContext context = new TTObjectContext(true);
            BindingList<WorkDayExceptionDef> list = WorkDayExceptionDef.GetWorkDaysStartsFrom(context, startDate);
            List<DateTime> holidays = new List<DateTime>();
            foreach (WorkDayExceptionDef wde in list)
                holidays.Add((DateTime)wde.Date);
            DateTime checkDate = startDate;
            while (WorkDayCount > 0)
            {
                if (checkDate.DayOfWeek != DayOfWeek.Saturday && checkDate.DayOfWeek != DayOfWeek.Sunday && holidays.Contains(checkDate) == false)
                    WorkDayCount--;
                checkDate = checkDate.AddDays(1);
            }

            return checkDate;
        }

        /// <summary>
        /// TC Kimlik Numarasının Mernis standartlarına uygunluğunu test eder
        /// </summary>
        /// <returns>bool</returns>
        public static bool CheckMernisNumber(long uniqueRefNo)
        {
            String _uniqueRefNo = Convert.ToString(uniqueRefNo);
            while (_uniqueRefNo.Length < 11)
                _uniqueRefNo = "0" + _uniqueRefNo;
            bool retVal = false;
            Int32 checkSum = Convert.ToInt32(_uniqueRefNo.Substring(9, 2));
            Int32 oddDigSum = Convert.ToInt32(_uniqueRefNo.Substring(8, 1)) + Convert.ToInt32(_uniqueRefNo.Substring(6, 1)) + Convert.ToInt32(_uniqueRefNo.Substring(4, 1)) + Convert.ToInt32(_uniqueRefNo.Substring(2, 1)) + Convert.ToInt32(_uniqueRefNo.Substring(0, 1));
            Int32 oddDigSum_temp = oddDigSum;
            Int32 evenDigSum = Convert.ToInt32(_uniqueRefNo.Substring(7, 1)) + Convert.ToInt32(_uniqueRefNo.Substring(5, 1)) + Convert.ToInt32(_uniqueRefNo.Substring(3, 1)) + Convert.ToInt32(_uniqueRefNo.Substring(1, 1));
            Int32 total = oddDigSum * 3 + evenDigSum;
            Int32 addTo1 = (10 - (total % 10)) % 10;
            oddDigSum = addTo1 + evenDigSum;
            evenDigSum = oddDigSum_temp;
            total = oddDigSum * 3 + evenDigSum;
            Int32 addTo2 = (10 - (total % 10)) % 10;
            total = addTo1 * 10 + addTo2;
            if (total == checkSum)
                retVal = true;
            return retVal;
        }

        public static List<string> DiagnosesForMedula(List<string> diagnoseList)
        {
            List<string> diagnoses = new List<string>();
            foreach (string item in diagnoseList)
            {
                if (item.Length > 5)
                    diagnoses.Add(item.Substring(0, 5));
                else
                    diagnoses.Add(item);
            }

            return diagnoses;
        }

        // Medula Branş Doktor Eşleştirme Tanım Ekranından Doktor Tescil Numarasını döndürür
        public static string GetDoctorRegisterNoByBranchCode(string branchCode)
        {
            if (!string.IsNullOrEmpty(branchCode))
            {
                TTObjectContext context = new TTObjectContext(true);
                IList matchList = MedulaBranchDoctorMatchDef.GetByBrachCode(context, branchCode);
                if (matchList.Count > 0)
                {
                    MedulaBranchDoctorMatchDef branchDoctorMatch = (MedulaBranchDoctorMatchDef)matchList[0];
                    if (branchDoctorMatch.Doctor != null)
                        return branchDoctorMatch.Doctor.DiplomaRegisterNo;
                }
            }

            return null;
        }

        public static string GetSaglikTesisleri(string tesisKodu)
        {
            string tesisAdi = "";
            MedulaYardimciIslemler.saglikTesisiAraGirisDVO saglikTesisiAraGirisDVO = new MedulaYardimciIslemler.saglikTesisiAraGirisDVO();
            if (string.IsNullOrEmpty(tesisKodu) == false)
                saglikTesisiAraGirisDVO.tesisKodu = tesisKodu;
            saglikTesisiAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            MedulaYardimciIslemler.saglikTesisiAraCevapDVO saglikTesisiAraCevapDVO = MedulaYardimciIslemler.WebMethods.saglikTesisiAraSync(TTObjectClasses.Sites.SiteLocalHost, saglikTesisiAraGirisDVO);
            if (saglikTesisiAraCevapDVO != null)
            {
                if (string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucKodu) == false)
                {
                    if (saglikTesisiAraCevapDVO.sonucKodu.Equals("0000") == true)
                    {
                        for (int i = 0; i < saglikTesisiAraCevapDVO.tesisler.Length; i++)
                        {
                            MedulaYardimciIslemler.saglikTesisiListDVO saglikTesisiListDVO = saglikTesisiAraCevapDVO.tesisler[i];
                            tesisAdi = saglikTesisiListDVO.tesisAdi;
                        }
                    }
                }
            }

            return tesisAdi;
        }

        public static bool IsDental(String bransKodu)
        {
            String[] disBransKodlari = { "5100", "5200", "5300", "5400", "5500", "5600", "5700" };
            for (int i = 0; i < disBransKodlari.Length; i++)
            {
                if (disBransKodlari[i].Equals(bransKodu))
                    return true;
            }

            return false;
        }

        public static void SaveUserMessageForUndefinedDiagnosis()
        {
            if (CurrentDoctor == null)
                return;
            TTObjectContext ctx = new TTObjectContext(false);
            string bodyRTF = "";
            BindingList<PatientExamination> lst = PatientExamination.GetPatientExaminationByResponsibleDoctor(ctx, CurrentDoctor.ObjectID.ToString(), (DateTime)Common.RecTime());
            foreach (PatientExamination pe in lst)
            {
                if (pe.PatientAdmission != null)
                {
                    if (pe.Diagnosis.Count <= 0 && IsLastDayExamination((DateTime)pe.ActionDate) && pe.CurrentStateDefID == PatientExamination.States.Examination)
                        bodyRTF = (bodyRTF + pe.PatientAdmission.Episode.Patient.UniqueRefNo.ToString() + "\n");
                }
            }

            if (bodyRTF != "")
            {
                // Doktora ait yeni bir mesaj oluşturulur
                UserMessage newMessage = new UserMessage(ctx);
                newMessage.MessageDate = Common.RecTime();
                newMessage.InitializeSentMessage();
                newMessage.ToUser = CurrentDoctor;
                newMessage.Subject = TTUtils.CultureService.GetText("M26673", "Önceki Günden Tanısı Girilmemiş Hasta");
                bodyRTF = TTUtils.Globals.StringToRTF("Dün muayenelerinizden \r\n" + bodyRTF + " TC Kimlik No'lu hastaların tanı bilgisi girilmemiştir.");
                newMessage.MessageBody = bodyRTF;
                newMessage.IsSystemMessage = true;
                newMessage.ValidateFields();
                newMessage.CheckErrorsEx();
                ctx.Save();
            }
        }

        public static bool IsLastDayExamination(DateTime examinationDate)
        {
            if (examinationDate != null)
            {
                //Pazartesi ise önceki gün Cuma olacak şekilde kontrol yapılır.
                if (Common.RecTime().DayOfWeek.Equals(System.DayOfWeek.Monday))
                {
                    if (DateDiffV2(DateIntervalEnum.Day, Common.RecTime(), examinationDate, false) == 3)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DateDiffV2(DateIntervalEnum.Day, Common.RecTime(), examinationDate, false) == 1)
                        return true;
                    else
                        return false;
                }
            }
            else
                return false;
        }

        //public static SortExaminationQueueItems()
        //{
        //    Dictionary<Guid, SortedExaminationQueueItems> sourceList = new Dictionary<Guid, SortedExaminationQueueItems>();
        //    int i = 0;
        //    while (true)
        //    {
        //        bool added = false;
        //        foreach (KeyValuePair<Guid, LocalSortedExaminationQueueItems> kp in list)
        //        {
        //            LocalSortedExaminationQueueItems sqItems = kp.Value;
        //            List<LocalExaminationQueueItem> itemList = sqItems.ExaminationQueueItemList;
        //            if (i < itemList.Count)
        //            {
        //                retList.Add(itemList[i]);
        //                added = true;
        //            }
        //        }
        //        if (added == false)
        //            break;
        //        i++;
        //    }
        //}
        public static void CheckWorklistDayLimit(DateTime dtStart, DateTime dtEnd)
        {
            int maxDayCount = 7;
            string maxDayCountString = TTObjectClasses.SystemParameter.GetParameterValue("WorkListMaxDayToSearch", "7");
            if (!int.TryParse(maxDayCountString, out maxDayCount))
                maxDayCount = 7;
            if (maxDayCount > 0)
            {
                if (Common.DateDiff(Common.DateIntervalEnum.Day, dtEnd, dtStart) > maxDayCount)
                    throw new Exception("İş Listesi Kriterlerinden 'Başlangıç Tarihi' ve  'Bitiş Tarihi' arasında " + maxDayCount.ToString() + " günden fazla iken sorgulama yapılamaz.");
            }
        }

        public static int WorklistDayLimit()
        {
            int maxDayCount = 7;
            string maxDayCountString = TTObjectClasses.SystemParameter.GetParameterValue("WorkListMaxDayToSearch", "7");
            if (!int.TryParse(maxDayCountString, out maxDayCount))
                maxDayCount = 7;
            return maxDayCount;
        }

        public static int WorklistMaxItemCount()
        {
            int maxItemCount = 1000;
            string maxItemCountString = TTObjectClasses.SystemParameter.GetParameterValue("WORKLISTMAXITEMCOUNT", "1000");
            if (!int.TryParse(maxItemCountString, out maxItemCount))
                maxItemCount = 1000;
            return maxItemCount;
        }
        public static string SerializeObjectToXml(object instance)
        {
            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
            {
                System.Xml.XmlWriterSettings writerSettings = new System.Xml.XmlWriterSettings();
                writerSettings.OmitXmlDeclaration = true;
                writerSettings.ConformanceLevel = System.Xml.ConformanceLevel.Auto;
                writerSettings.Indent = true;
                StringBuilder stringBuilder = new StringBuilder();
                using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlWriter.Create(stringBuilder, writerSettings))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(instance.GetType());
                    System.Xml.Serialization.XmlSerializerNamespaces nameSpaces = new System.Xml.Serialization.XmlSerializerNamespaces();
                    nameSpaces.Add(string.Empty, string.Empty);
                    serializer.Serialize(xmlWriter, instance, nameSpaces);
                    return stringBuilder.ToString();
                }
            }
        }

        #region patientSearch
        ///// <summary>
        ///// Filtrenin hazırlanmasını sağlar.
        ///// </summary>
        ///// <param name="searchString">Tetiklendiği andaki searchString değeri.</param>
        ///// <returns>Geriye hazırlanan filtre döner.</returns>
        //private static string GetForeignUniqueRefNoExpression(string searchString)
        //{
        //    string filterExpression = null;
        //    if (filterExpression != null)
        //        filterExpression += " AND ";
        //    filterExpression += "(FOREIGNUNIQUEREFNO = " + searchString + " )";
        //    return filterExpression;
        //}
        ///// <summary>
        ///// Filtrenin hazırlanmasını sağlar.
        ///// </summary>
        ///// <param name="searchString">Tetiklendiği andaki searchString değeri.</param>
        ///// <returns>Geriye hazırlanan filtre döner.</returns>
        //private static string GetUniqueRefNoExpression(string searchString)
        //{
        //    string filterExpression = null;
        //    if (filterExpression != null)
        //        filterExpression += " AND ";
        //    filterExpression += "(UNIQUEREFNO = " + searchString + " )";
        //    return filterExpression;
        //}
        ///// <summary>
        ///// Filtrenin hazırlanmasını sağlar.
        ///// </summary>
        ///// <param name="searchString">Tetiklendiği andaki searchString değeri.</param>
        ///// <returns>Geriye hazırlanan filtre döner.</returns>
        //private static string GetYuPassNoExpression(string searchString)
        //{
        //    string filterExpression = null;
        //    if (Common.IsNumeric(searchString))
        //        filterExpression = "(YUPASSNO = " + searchString + " )";
        //    return filterExpression;
        //}
        ///// <summary>
        ///// Filtrenin hazırlanmasını sağlar.
        ///// </summary>
        ///// <param name="searchString">Tetiklendiği andaki searchString değeri.</param>
        ///// <returns>>Geriye hazırlanan filtre döner.</returns>
        //private static string GetPatientObjectIDExpression(string searchString)
        //{
        //    string filterExpression = null;
        //    if (Common.IsNumeric(searchString))
        //        filterExpression = "(ID = " + searchString + ")";
        //    return filterExpression;
        //}
        ///// <summary>
        ///// Filtrenin hazırlanmasını sağlar.
        ///// </summary>
        ///// <param name="searchString">Tetiklendiği andaki searchString değeri.</param>
        ///// <returns>>Geriye hazırlanan filtre döner.</returns>
        //public static string GetPatientFullNameExpression(string searchString)
        //{
        //    List<Guid> PatientObjectIDs = new List<Guid>();
        //    Dictionary<Guid, int> Duplicates = new Dictionary<Guid, int>();
        //    List<Guid> MatchedIDs = new List<Guid>();
        //    string filterExpression = null;
        //    string opr = null;
        //    string injection = null;
        //    ArrayList NameTokens = new ArrayList();
        //    NameTokens = Common.Tokenize(searchString, true);
        //    #region Tek Kelime ile Arama Kaldırıldı
        //    /*
        //    if (NameTokens.Count == 1)
        //    {
        //        injection += " AND (";
        //        string s = NameTokens[0].ToString();
        //        if (s.IndexOf('%') != -1)
        //        {
        //            injection += "TOKEN LIKE '" + s + "' ";
        //            injection += ")AND TOKENTYPE IN (0,1)";
        //        }
        //        else
        //        {
        //            injection += "TOKEN = '" + s + "' ";
        //            injection += ")AND TOKENTYPE IN (0,1)";
        //        }
        //        if (injection != null)
        //        {
        //            BindingList<PatientToken.GetByInjection_Class> tokenList = PatientToken.GetByInjection(injection);
        //            foreach (PatientToken.GetByInjection_Class t in tokenList)
        //            {
        //                if (t.Patientobjectid.HasValue)
        //                {
        //                    if (PatientObjectIDs.Contains(t.Patientobjectid.Value) == false)
        //                        PatientObjectIDs.Add(t.Patientobjectid.Value);
        //                    else
        //                        MatchedIDs.Add(t.Patientobjectid.Value);
        //                }
        //            }
        //            if (PatientObjectIDs.Count > 0)
        //            {
        //                filterExpression = CreateFilterExpressionOfGuidList(filterExpression, PatientObjectIDs);
        //            }
        //        }
        //    }
        //     */
        //    #endregion
        //    if (NameTokens.Count > 1)
        //    {
        //        for (int i = 0; i <= NameTokens.Count - 1; i++)
        //        {
        //            string s = NameTokens[i].ToString();
        //            if (i > 0)
        //            {
        //                injection += " OR (";
        //                if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
        //                {
        //                    opr = "LIKE";
        //                    s += "%";
        //                }
        //                else
        //                    opr = "=";
        //                injection += "TOKEN " + opr + " '" + s + "' ";
        //                if (i == NameTokens.Count - 1)
        //                    injection += "AND TOKENTYPE = 1)";
        //                else
        //                    injection += "AND TOKENTYPE = 0)";
        //            }
        //            else
        //            {
        //                injection += " AND ((";
        //                if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
        //                {
        //                    opr = "LIKE";
        //                    s += "%";
        //                }
        //                else
        //                    opr = "=";
        //                injection += "TOKEN " + opr + " '" + s + "' ";
        //                injection += "AND TOKENTYPE = 0)";
        //            }
        //        }
        //        injection += ") GROUP BY PATIENT HAVING Count(*) >= " + NameTokens.Count.ToString();
        //        if (injection != null)
        //        {
        //            BindingList<PatientToken.GetPatientByInjection_Class> tokenList = PatientToken.GetPatientByInjection(injection);
        //            foreach (PatientToken.GetPatientByInjection_Class t in tokenList)
        //            {
        //                MatchedIDs.Add(t.Patient.Value);
        //            }
        //            if (MatchedIDs.Count > 0)
        //            {
        //                filterExpression = CreateFilterExpressionOfGuidList(filterExpression, String.Empty, MatchedIDs);
        //            }
        //        }
        //    }
        //    return filterExpression;
        //}
        ///// <summary>
        ///// Aramanın yapılmasını sağlar.
        ///// </summary>
        ///// <param name="searchString">Tetiklendiği andaki searchString değeri.</param>
        ///// <returns>Geriye arama sonuçları döner.</returns>
        //public static IList PatientSearch(string searchString)
        //{
        //    //Cursor current = Cursor.Current;
        //    //Cursor.Current = Cursors.WaitCursor;
        //    TTList _ttList = TTList.NewList("PatientSearchList", null);
        //    TTList tempPatientList = TTList.NewList("PatientSearchList", null);
        //    string _patientSearchExpression = String.Empty;
        //    bool dontSearchByPatientID = TTObjectClasses.SystemParameter.GetParameterValue("SEARCHPATIENBYPATIENTID", "TRUE").Trim() == "FALSE";
        //    try
        //    {
        //        IList list = null;
        //        if (searchString.Length == 11 && Common.IsNumeric(searchString))
        //        {
        //            if (dontSearchByPatientID)
        //                _ttList = NestedSearch(_ttList, list, GetUniqueRefNoExpression(searchString), GetForeignUniqueRefNoExpression(searchString), GetYuPassNoExpression(searchString));
        //            else
        //                _ttList = NestedSearch(_ttList, list, GetUniqueRefNoExpression(searchString), GetPatientObjectIDExpression(searchString), GetForeignUniqueRefNoExpression(searchString));
        //        }
        //        else if (searchString.Length != 11 && Common.IsNumeric(searchString))
        //        {
        //            if (dontSearchByPatientID)
        //                _ttList = NestedSearch(_ttList, list, GetForeignUniqueRefNoExpression(searchString), GetYuPassNoExpression(searchString), null);
        //            else
        //                _ttList = NestedSearch(_ttList, list, GetPatientObjectIDExpression(searchString), GetForeignUniqueRefNoExpression(searchString), GetYuPassNoExpression(searchString));
        //            //Hasta No'dan ara
        //        }
        //        else
        //        {
        //            if (searchString.Length == 0)
        //            {
        //                return null;
        //            }
        //            if (Common.IsNumeric(searchString))
        //            {
        //                if (dontSearchByPatientID)
        //                    _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), GetUniqueRefNoExpression(searchString), GetForeignUniqueRefNoExpression(searchString));
        //                else
        //                    _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), GetPatientObjectIDExpression(searchString), GetUniqueRefNoExpression(searchString));
        //            }
        //            else
        //            {
        //                if (dontSearchByPatientID)
        //                    _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), null, null);
        //                else
        //                    _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpression(searchString), GetPatientObjectIDExpression(searchString), null);
        //            }
        //            //Hasta Adı Soyadı
        //        }
        //        return _ttList?.FoundList;
        //    }
        //    //catch (Exception ex)
        //    //{
        //    //    InfoBox.Alert(ex);
        //    //}
        //    finally
        //    {
        //        //Cursor.Current = current;
        //    }
        //    //return _ttList.FoundList;
        //}
        //private static string GetPatientFullNameExpressionWithFatherName(string name, string surname, string fatherName, string motherName, string cityOfBirth, string age)
        //{
        //    //TO DO Bibi
        //    List<Guid> PatientObjectIDs = new List<Guid>();
        //    Dictionary<Guid, int> Duplicates = new Dictionary<Guid, int>();
        //    List<Guid> MatchedIDs = new List<Guid>();
        //    string filterExpression = null;
        //    string opr = null;
        //    string injection = null;
        //    string searchString = name + " " + surname;// geçici çözüm
        //    ArrayList NameTokens = new ArrayList();
        //    NameTokens = Common.Tokenize(searchString, true);
        //    if (NameTokens.Count > 1)
        //    {
        //        for (int i = 0; i <= NameTokens.Count - 1; i++)
        //        {
        //            string s = NameTokens[i].ToString();
        //            if (i > 0)
        //            {
        //                injection += " OR (";
        //                if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
        //                {
        //                    opr = "LIKE";
        //                    s += "%";
        //                }
        //                else
        //                    opr = "=";
        //                injection += "TOKEN " + opr + " '" + s + "' ";
        //                if (i == NameTokens.Count - 1)
        //                    injection += "AND TOKENTYPE = 1)";
        //                else
        //                    injection += "AND TOKENTYPE = 0)";
        //            }
        //            else
        //            {
        //                injection += " AND ((";
        //                if (s.IndexOf('%') != -1 || (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "True").ToUpper() == "TRUE"))
        //                {
        //                    opr = "LIKE";
        //                    s += "%";
        //                }
        //                else
        //                    opr = "=";
        //                injection += "TOKEN " + opr + " '" + s + "' ";
        //                injection += "AND TOKENTYPE = 0)";
        //            }
        //        }
        //        injection += ") GROUP BY PATIENT HAVING Count(*) >= " + NameTokens.Count.ToString();
        //        if (injection != null)
        //        {
        //            BindingList<PatientToken.GetPatientByInjection_Class> tokenList = PatientToken.GetPatientByInjection(injection);
        //            foreach (PatientToken.GetPatientByInjection_Class t in tokenList)
        //            {
        //                MatchedIDs.Add(t.Patient.Value);
        //            }
        //            if (MatchedIDs.Count > 0)
        //            {
        //                filterExpression = CreateFilterExpressionOfGuidList(filterExpression, String.Empty, MatchedIDs);
        //            }
        //        }
        //    }
        //    return filterExpression;
        //}
        //public static IList PatientSearchWithDetails(string Name, string surname, string fatherName, string motherName, string cityOfBirth, string age)
        //{
        //    //Cursor current = Cursor.Current;
        //    //Cursor.Current = Cursors.WaitCursor;
        //    TTList _ttList = TTList.NewList("PatientSearchList", null);
        //    TTList tempPatientList = TTList.NewList("PatientSearchList", null);
        //    string searchString = null;
        //    bool dontSearchByPatientID = TTObjectClasses.SystemParameter.GetParameterValue("SEARCHPATIENBYPATIENTID", "TRUE").Trim() == "FALSE";
        //    IList list = null;
        //    _ttList = NestedSearch(_ttList, list, GetPatientFullNameExpressionWithFatherName(Name, surname, fatherName, motherName, cityOfBirth, age), GetPatientObjectIDExpression(searchString), null);
        //    return _ttList?.FoundList;
        //}
        public static List<PatientAdmission> OutPatientSearchWithFilterExpression(DateTime startDate, DateTime endDate, string filterExpression, string clinicFilter)
        {
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                BindingList<Patient.GetPatientObjectIDByInjection_Class> patientObjectIDs = Patient.GetPatientObjectIDByInjection(context, filterExpression);
                List<Guid> patientGuidList = new List<Guid>();
                foreach (Patient.GetPatientObjectIDByInjection_Class patient in patientObjectIDs)
                {
                    Guid patientGuidObject = new Guid(patient.ObjectID.ToString());
                    patientGuidList.Add(patientGuidObject);
                }
                List<PatientAdmission> patientAdmissionList = null;
                List<PatientAdmission> allPatientAdmissionList = new List<PatientAdmission>();
                 string patientFilter = string.Empty;

               if(patientGuidList == null || patientGuidList.Count == 0)
                {
                    allPatientAdmissionList = PatientAdmission.GetDataForHospitalInformation(context, startDate, endDate, clinicFilter).ToList();
                } 

               else if (patientGuidList.Count > 1000)
                {
                    int pageCount = patientGuidList.Count / 1000;
                    int pageSize = 1000;
                    for (int i = 1; i <= pageCount; i++)
                    {
                        List<Guid> patientGuidPart = patientGuidList.Take(pageSize).ToList();
                        patientAdmissionList = PatientAdmission.GetByDateAndPatients(context, startDate, endDate, patientGuidPart, clinicFilter).ToList();
                        allPatientAdmissionList = (allPatientAdmissionList.Union(patientAdmissionList)).ToList();
                        patientGuidList.RemoveRange(0, pageSize);
                    }

                    if (patientGuidList.Count > 0)
                    {
                        patientAdmissionList = PatientAdmission.GetByDateAndPatients(context, startDate, endDate, patientGuidList, clinicFilter).ToList();
                        allPatientAdmissionList = (allPatientAdmissionList.Union(patientAdmissionList)).ToList();

                    }
                }
                else
                {
                    allPatientAdmissionList = PatientAdmission.GetByDateAndPatients(context, startDate, endDate, patientGuidList, clinicFilter).ToList();
                }

                //BindingList<PatientAdmission> patientAdmissionList = PatientAdmission.GetByDateAndPatients(context, startDate, endDate, patientGuidList);
                return allPatientAdmissionList;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<GetInPatientInfoByPatients_Class> InPatientSearchWithFilterExpression(DateTime startDate, DateTime endDate, string filterExpression, string clinicFilter)
        {
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                BindingList<Patient.GetPatientObjectIDByInjection_Class> patientObjectIDs = Patient.GetPatientObjectIDByInjection(context, filterExpression);
                List<Guid> patientGuidList = new List<Guid>();
                foreach (Patient.GetPatientObjectIDByInjection_Class patient in patientObjectIDs)
                {
                    Guid patientGuidObject = new Guid(patient.ObjectID.ToString());
                    patientGuidList.Add(patientGuidObject);
                }

                List<GetInPatientInfoByPatients_Class> inPatientInfoList = null;
                List<GetInPatientInfoByPatients_Class> allInpatientInfoList = new List<GetInPatientInfoByPatients_Class>();

                if(patientGuidList == null || patientGuidList.Count == 0)
                {
                    if (!String.IsNullOrEmpty(clinicFilter))
                    {
                        clinicFilter = " OR" + clinicFilter;
                    }
                    allInpatientInfoList = InPatientTreatmentClinicApplication.GetInPatientInfoByPatients(patientGuidList, clinicFilter).ToList();
                }

                else if (patientGuidList.Count > 1000)
                {
                    int pageCount = patientGuidList.Count / 1000;
                    int pageSize = 1000;
                    for (int i = 1; i<= pageCount; i++)
                    {
                        if (!String.IsNullOrEmpty(clinicFilter))
                        {
                            clinicFilter = " AND" + clinicFilter;
                        }
                        List<Guid> patientGuidPart = patientGuidList.Take(pageSize).ToList();
                        inPatientInfoList = InPatientTreatmentClinicApplication.GetInPatientInfoByPatients(patientGuidPart, clinicFilter).ToList();
                        allInpatientInfoList = (allInpatientInfoList.Union(inPatientInfoList)).ToList();
                        patientGuidList.RemoveRange(0, pageSize);
                    }

                    if(patientGuidList.Count > 0)
                    {
                        if (!String.IsNullOrEmpty(clinicFilter))
                        {
                            clinicFilter = " AND" + clinicFilter;
                        }
                        inPatientInfoList = InPatientTreatmentClinicApplication.GetInPatientInfoByPatients(patientGuidList, clinicFilter).ToList();
                        allInpatientInfoList = (allInpatientInfoList.Union(inPatientInfoList)).ToList();

                    }

                }
                else
                {
                    if (!String.IsNullOrEmpty(clinicFilter))
                    {
                        clinicFilter = " AND" + clinicFilter;
                    }
                    allInpatientInfoList = InPatientTreatmentClinicApplication.GetInPatientInfoByPatients(patientGuidList, clinicFilter).ToList();
                }
                // inPatientInfoList = InPatientTreatmentClinicApplication.GetInPatientInfoByPatients(patientGuidList);
                return allInpatientInfoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///// <summary>
        ///// İç içe aramanın yapılmasını sağlar.
        ///// </summary>
        ///// <param name="ttList">Tetiklendiği andaki TTList değeri.</param>
        ///// <param name="list">Tetiklendiği andaki list değeri.</param>
        ///// <param name="exp1">Tetiklendiği andaki exp1 değeri.</param>
        ///// <param name="exp2">Tetiklendiği andaki exp2 değeri.</param>
        ///// <param name="exp3">Tetiklendiği andaki exp3 değeri.</param>
        ///// <returns>Geriye arama sonuçları döner.</returns>
        //private static TTList NestedSearch(TTList ttList, IList list, string exp1, string exp2, string exp3)
        //{
        //    if (exp1 != null)
        //        list = ttList.GetObjectListByExpression(exp1);
        //    if (list == null || list.Count < 1)
        //    {
        //        if (exp2 != null)
        //            list = ttList.GetObjectListByExpression(exp2);
        //        if (list == null || list.Count < 1)
        //        {
        //            if (exp3 != null)
        //                list = ttList.GetObjectListByExpression(exp3);
        //            if (list == null || list.Count < 1)
        //            {
        //                return null;
        //            }
        //            return ttList;
        //        }
        //        return ttList;
        //    }
        //    return ttList;
        //}
        #endregion
        [Serializable]
        public class Age
        {
            public int Years
            {
                get;
                set;
            }

            public int Months
            {
                get;
                set;
            }

            public int Weeks
            {
                get;
                set;
            }

            public int Days
            {
                get;
                set;
            }
        }

        public static Common.Age CalculateAge(DateTime birthDate)
        {
            Common.Age age = new Common.Age();
            DateTime today = DateTime.Today;
            int months = today.Month - birthDate.Month;
            int years = today.Year - birthDate.Year;
            if (today.Day < birthDate.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - birthDate.AddMonths((years * 12) + months)).Days;
            age.Years = years;
            age.Months = months;
            age.Days = days;
            return age;
        }

        public static double CalculateBMI(double weight, double height)
        {
            double bmi = Math.Round((weight / ((height / 100) * (height / 100))), 2);
            return bmi;
        }

        public static double CalculateBodySurfaceArea(double weight, double height)
        {
            double bodySurfaceArea = Math.Round((Math.Sqrt((height * weight) / 3600)), 2);
            return bodySurfaceArea;
        }

        //Buna subepisode gelmeli ve elden geçmeli.
        //public static string PatientAdmissionInfo(Patient patient, Episode episode)
        //{
        //    string _patientAdmissionInfo = String.Empty;
        //    if (patient != null)
        //    {
        //        Age patientAge = null;
        //        if (patient.BirthDate != null)
        //            patientAge = Common.CalculateAge(Convert.ToDateTime(patient.BirthDate));
        //        _patientAdmissionInfo += patient.FullName + " - ";
        //        if (patientAge != null)
        //            _patientAdmissionInfo += patientAge.Years.ToString() + "Y/" + patientAge.Months.ToString() + "M/" + patientAge.Days.ToString() + "D - ";
        //        _patientAdmissionInfo += patient.RefNo + " - " + patient.FatherName;
        //        if (patient.Payer != null)
        //            _patientAdmissionInfo += " - " + patient.Payer.Name;
        //        _patientAdmissionInfo += "\r\n";
        //    }
        //    if (episode != null)
        //    {
        //        _patientAdmissionInfo += episode.PatientAdmission.Policlinic.Name + " - ";
        //        if (episode.PatientAdmission.AdmissionStatus.HasValue)
        //            _patientAdmissionInfo += Common.GetDisplayTextOfDataTypeEnum(episode.PatientAdmission.AdmissionStatus.Value) + " - ";
        //        if (!String.IsNullOrEmpty(episode.PatientAdmission.ProvisionNo))
        //            _patientAdmissionInfo += episode.PatientAdmission.ProvisionNo + " - ";
        //        if (episode.PatientAdmission.AdmissionType.HasValue)
        //            _patientAdmissionInfo += Common.GetDisplayTextOfDataTypeEnum(episode.PatientAdmission.AdmissionType.Value) + " - ";
        //        if (episode.HospitalProtocolNo != null)
        //            _patientAdmissionInfo += episode.HospitalProtocolNo.ToString() + " - ";
        //    }
        //    return _patientAdmissionInfo;
        //}
        public static IEnumerable<string> GetParentFolders(TTModuleDef moduleDef)
        {
            yield return TTUtils.Globals.GetModuleName(moduleDef.Name);
            Guid? folderDefId = moduleDef.FolderDefID;
            while (folderDefId != null)
            {
                TTFolderDef folderDef = null;
                if (TTObjectDefManager.Instance.FolderDefs.ContainsKey(folderDefId))
                {
                    folderDef = TTObjectDefManager.Instance.FolderDefs[folderDefId];
                    yield return TTUtils.Globals.GetModuleName(folderDef.CodeName);
                    folderDefId = folderDef.ParentFolderDefID;
                }

                if (!folderDefId.HasValue)
                    yield break;
            }
        }

        public static string BinaryToString(Guid dataId) //RTF(binary) için text döndüren method 
        {
            byte[] byteArray = TTBinaryData.GetBinaryData(dataId);
            string result = Encoding.UTF8.GetString(byteArray.ToArray());
            return result;
        }

        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }

        public static string kirmiziRenk
        {
            get
            {
                return "rgb(224, 107, 107)";
            }
        }

        public static bool PersonelIzinKontrol(string resUserID, DateTime checkDate, TTObjectContext objectContext)
        {
            //DateTime checkDate = DateTime.Now;
            
            string[] mHRSActionCodes = SystemParameter.GetParameterValue("MHRSACTIONCODESFORIZIN", "3,5,13,14,16,21,30,57,58,62,73,77").Split(',');

            List<ResUserTakeOffFromWork> takeOffFromWorksList = ResUserTakeOffFromWork.GetTakeOffByDateByTime(objectContext, checkDate, resUserID).Where(x => x.IsActive == true && mHRSActionCodes.Contains(x.MHRSActionType.ActionCode)).ToList();

            foreach (ResUserTakeOffFromWork item in takeOffFromWorksList)
            {
                if (item.IsActive.HasValue && item.IsActive.Value)
                {
                    if (item.StartDate.StartTime.Value.TimeOfDay <= checkDate.TimeOfDay && item.EndDate.EndTime.Value.TimeOfDay >= checkDate.TimeOfDay)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Eğer yeni bir kural tanımladı ise kural motorunun kuralları baştan çekmesi için kullanılan alan;
        /// </summary>
        /// <param name="objectContext"></param>
        public static void SohaRuleRuleRepositoryChanged(TTObjectContext objectContext, SohaRuleRepoTypeEnum ruleType)
        {
            SohaRuleRepoUpdate ruleRepoUpdate = objectContext.QueryObjects<SohaRuleRepoUpdate>("REPOSITORYTYPE = " + (int)ruleType).FirstOrDefault();
            if (ruleRepoUpdate != null)
                ruleRepoUpdate.UpdateDate = DateTime.Now;
        }

        public static string GenerateSearchTextForShadowProperty(string value)
        {
            bool inStart = true;
            StringBuilder sb = new StringBuilder();
            StringBuilder sTemp = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];
                if (ch == ' ' || ch == '\t' || ch == '\r' || ch == '\n')
                    sTemp.Append(ch);
                else
                {

                    switch (ch)
                    {
                        case 'ğ': ch = 'g'; break;
                        case 'Ğ': ch = 'G'; break;
                        case 'ü': ch = 'u'; break;
                        case 'Ü': ch = 'U'; break;
                        case 'ş': ch = 's'; break;
                        case 'Ş': ch = 'S'; break;
                        case 'ı': ch = 'i'; break;
                        case 'İ': ch = 'I'; break;
                        case 'ö': ch = 'o'; break;
                        case 'Ö': ch = 'O'; break;
                        case 'ç': ch = 'c'; break;
                        case 'Ç': ch = 'C'; break;
                    }


                    if (ch == 'i')
                        ch = 'I';
                    else
                        ch = char.ToUpper(ch);

                    sb.Append(sTemp);
                    sb.Append(ch);
                    sTemp = new StringBuilder();
                }
            }

            return sb.ToString();
        }

        public static string HTMLToText(string HTMLCode)
        {
            // Remove new lines since they are not visible in HTML
            HTMLCode = HTMLCode.Replace("\n", " ");

            // Remove tab spaces
            HTMLCode = HTMLCode.Replace("\t", " ");

            // Remove multiple white spaces from HTML
            HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

            // Remove HEAD tag
            HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Remove any JavaScript
            HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Replace special characters like &, <, >, " etc.
            StringBuilder sbHTML = new StringBuilder(HTMLCode);
            // Note: There are many more special characters, these are just
            // most common. You can add new characters in this arrays if needed
            string[] OldWords = { "&nbsp;", "&amp;", "&quot;", "&lt;", "&gt;", "&reg;", "&copy;", "&bull;", "&trade;", "&#39;" };
            string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢", "\'" };
            for (int i = 0; i < OldWords.Length; i++)
            {
                sbHTML.Replace(OldWords[i], NewWords[i]);
            }

            // Check if there are line breaks (<br>) or paragraph (<p>)
            sbHTML.Replace("<br>", "\n<br>");
            sbHTML.Replace("<br ", "\n<br ");
            sbHTML.Replace("<p ", "\n<p ");

            // Finally, remove all HTML tags and return plain text
            return Regex.Replace(sbHTML.ToString(), "<[^>]*>", "");
        }

        #endregion Methods
    }
}