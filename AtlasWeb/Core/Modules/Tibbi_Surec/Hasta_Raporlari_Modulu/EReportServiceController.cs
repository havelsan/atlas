//$B7C4A3D8
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using TTStorageManager.Security;
using System.Xml.Serialization;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class EReportServiceController : Controller
    {
        public static string eReportAddress = TTObjectClasses.SystemParameter.GetParameterValue("ERAPORERISIMADRESI", "http://xxxxxx.com/");

        public static string GetToken(string UniqueRefNo = null, string roleId = null)
        {
            //GetTokenParameters tokenParameters = new GetTokenParameters();

            //string parameterUrl = "http://xxxxxx.com/";
            string token = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string IdentityNumber = String.Empty;
            if (String.IsNullOrEmpty(UniqueRefNo))
                IdentityNumber = Common.CurrentResource.UniqueNo;
            else
                IdentityNumber = UniqueRefNo;
            string role = roleId;
            TTUser user = Common.CurrentUser;
            if (String.IsNullOrEmpty(role))
            {
                if (user.HasRole(TTRoleNames.Tabip))
                {
                    role = "6AAB18C7-B16B-4A04";
                }
                else
                {
                    role = "5DDEB487-A0C2-47D6";
                }
            }


            /*tokenParameters.username = UserName;
            tokenParameters.password = Password;
            tokenParameters.applicationCode = ApplicationCode;
            tokenParameters.identityNumber = IdentityNumber;
            tokenParameters.role = role;
            var response = ERaporService.WebMethods.GetTokenSync(Sites.SiteLocalHost, "", "", tokenParameters);*/
            var uri = new Uri(eReportAddress + "AuthApi/connect/token?username=" + UserName + "&password=" + Password +
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


        [HttpGet]
        public string openCreateEDurumBildirirReport(Guid episodeActionId)
        {
            var token = GetToken();
            string patientId = null;
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var episodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);
                if (episodeAction != null)
                {
                    patientId = episodeAction.Episode.Patient.UniqueRefNo.ToString();
                }
            }
            string connectionLink = eReportAddress + "healthstatusweb/singledoctor/createreport?authorization=" + token;
            if (patientId != null)
                connectionLink += "&patientId=" + patientId;
            return connectionLink;
        }

        [HttpGet]
        public string openEDurumBildirirReportIndex()
        {
            var token = GetToken();
            string connectionLink = eReportAddress + "healthstatusweb/singledoctor/doctorIndex?authorization=" + token;
            return connectionLink;
        }

        [HttpGet]
        public string openESurucuKurulRaporBasvuruOlusturma()
        {
            string role = String.Empty;
            var user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Bastabip))
            {
                role = "417A9319-6430-490C";
            }
            else if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
            }
            else
            {
                role = "5DDEB487-A0C2-47D6";
            }
            var token = GetToken(null,role);
            string connectionLink = eReportAddress + "driverweb/Council/SecretaryCreateApplication?authorization=" + token;
            return connectionLink;
        }
        [HttpGet]
        public string openESurucuKurulRaporSekreterIndex()
        {
            string role = String.Empty;
            var user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Bastabip))
            {
                role = "417A9319-6430-490C";
            }
            else if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
            }
            else
            {
                role = "5DDEB487-A0C2-47D6";
            }
            var token = GetToken(null, role);
            string connectionLink = eReportAddress + "driverweb/Council/SecretaryIndex?authorization=" + token;
            return connectionLink;
        }
        [HttpGet]
        public string openESurucuKurulDoktorMuayeneIndex()
        {
            string role = String.Empty;
            var user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Bastabip))
            {
                role = "417A9319-6430-490C";
            }
            else if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
            }
            else
            {
                role = "5DDEB487-A0C2-47D6";
            }
            var token = GetToken(null, role);
            string connectionLink = eReportAddress + "driverweb/Council/DoctorIndex?authorization=" + token;
            return connectionLink;
        }
        [HttpPost]
        public List<ERaporSorgulaResponseClass> getSGKReportsOnPatient(ERaporSorgulaRequest input)
        {
            List<int> reportTypeList = new List<int>();
            reportTypeList.Add(1);
            reportTypeList.Add(5);
            reportTypeList.Add(6);
            reportTypeList.Add(7);
            reportTypeList.Add(10);
            reportTypeList.Add(11);
            string patientId = null;
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var episodeAction = objectContext.GetObject<EpisodeAction>(input.actionId);
                if (episodeAction != null)
                {
                    patientId = episodeAction.Episode.Patient.UniqueRefNo.ToString();
                }

                RaporIslemleri.raporOkuTCKimlikNodanDVO raporOkuDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                raporOkuDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                raporOkuDVO.tckimlikNo = patientId;
                raporOkuDVO.raporTuru = "1";
                List<ERaporSorgulaResponseClass> reportList = new List<ERaporSorgulaResponseClass>();

                foreach (int i in reportTypeList)
                {
                    raporOkuDVO.raporTuru = i.ToString();
                    RaporIslemleri.raporCevapTCKimlikNodanDVO responseInner = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, raporOkuDVO);
                    if (responseInner.raporlar != null && responseInner.raporlar.Count() > 0)
                    {
                        foreach (var rapor in responseInner.raporlar)
                        {
                            ERaporSorgulaResponseClass responseObj = new ERaporSorgulaResponseClass();
                            responseObj.raporCevapDVO = rapor;
                            responseObj.reportXML = TTUtils.SaglikNetHelper.XMLSerialize(rapor);
                            responseObj.reportXML = responseObj.reportXML.Replace("p5:nil=\"true\" xmlns:p5=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            responseObj.reportXML = responseObj.reportXML.Replace("p4:nil=\"true\" xmlns:p4=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            responseObj.reportXML = responseObj.reportXML.Replace("p3:nil=\"true\" xmlns:p3=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            responseObj.reportXML = responseObj.reportXML.Replace("p2:nil=\"true\" xmlns:p2=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            responseObj.reportXML = responseObj.reportXML.Replace("p1:nil=\"true\" xmlns:p1=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            if (i == 1)
                            {
                                responseObj.reportType = "Tedavi Raporu";
                                if (rapor.tedaviRapor != null)
                                {
                                    responseObj.ReportStartDate = Convert.ToDateTime(rapor.tedaviRapor.raporDVO.baslangicTarihi);
                                    responseObj.ReportEndDate = Convert.ToDateTime(rapor.tedaviRapor.raporDVO.bitisTarihi);
                                    responseObj.reportDescription = rapor.tedaviRapor.raporDVO.aciklama;
                                    responseObj.raporTesis = rapor.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();

                                    if (rapor.tedaviRapor.islemler[0].diyalizRaporBilgisi != null)
                                    {
                                        responseObj.seansSayisi = rapor.tedaviRapor.islemler[0].diyalizRaporBilgisi.seansSayi.ToString();
                                        responseObj.reportType += "-Diyaliz";
                                    }
                                    else if (rapor.tedaviRapor.islemler[0].eswlRaporBilgisi != null)
                                    {
                                        responseObj.seansSayisi = rapor.tedaviRapor.islemler[0].eswlRaporBilgisi.eswlRaporuSeansSayisi.ToString();
                                        responseObj.reportType += "-ESWL";
                                    }
                                    else if (rapor.tedaviRapor.islemler[0].eswtRaporBilgisi != null)
                                    {
                                        responseObj.seansSayisi = rapor.tedaviRapor.islemler[0].eswtRaporBilgisi.seansSayi.ToString();
                                        responseObj.reportType += "-ESWT";
                                    }
                                    else if (rapor.tedaviRapor.islemler[0].evHemodiyaliziRaporBilgisi != null)
                                    {
                                        responseObj.seansSayisi = rapor.tedaviRapor.islemler[0].evHemodiyaliziRaporBilgisi.seansSayi.ToString();
                                        responseObj.reportType += "-Ev Hemodiyalizi";
                                    }
                                    else if (rapor.tedaviRapor.islemler[0].ftrRaporBilgisi != null)
                                    {
                                        responseObj.seansSayisi = rapor.tedaviRapor.islemler[0].ftrRaporBilgisi.seansSayi.ToString();
                                        responseObj.reportType += "-FTR";
                                    }
                                    else if (rapor.tedaviRapor.islemler[0].hotRaporBilgisi != null)
                                    {
                                        responseObj.seansSayisi = rapor.tedaviRapor.islemler[0].hotRaporBilgisi.seansSayi.ToString();
                                        responseObj.reportType += "-HOT";
                                    }

                                }
                            }
                            else if (i == 5)
                            {
                                if (rapor.dogumOncesiCalisabilirRapor != null)
                                {
                                    responseObj.ReportStartDate = Convert.ToDateTime(rapor.dogumOncesiCalisabilirRapor.raporDVO.baslangicTarihi);
                                    responseObj.ReportEndDate = Convert.ToDateTime(rapor.dogumOncesiCalisabilirRapor.raporDVO.bitisTarihi);
                                    responseObj.reportDescription = rapor.dogumOncesiCalisabilirRapor.raporDVO.aciklama;
                                    responseObj.raporTesis = rapor.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                    responseObj.reportType = "Doğum Öncesi Çalışabilir";
                                }
                            }
                            else if (i == 6)
                            {
                                if (rapor.analikRapor != null)
                                {
                                    responseObj.ReportStartDate = Convert.ToDateTime(rapor.analikRapor.raporDVO.baslangicTarihi);
                                    responseObj.ReportEndDate = Convert.ToDateTime(rapor.analikRapor.raporDVO.bitisTarihi);
                                    responseObj.reportDescription = rapor.analikRapor.raporDVO.aciklama;
                                    responseObj.raporTesis = rapor.analikRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                    responseObj.reportType = "Analık";
                                }
                            }
                            else if (i == 7)
                            {
                                if (rapor.dogumRapor != null)
                                {
                                    responseObj.ReportStartDate = Convert.ToDateTime(rapor.dogumRapor.raporDVO.baslangicTarihi);
                                    responseObj.ReportEndDate = Convert.ToDateTime(rapor.dogumRapor.raporDVO.bitisTarihi);
                                    responseObj.reportDescription = rapor.dogumRapor.raporDVO.aciklama;
                                    responseObj.raporTesis = rapor.dogumRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                    responseObj.reportType = "Doğum";
                                }
                            }
                            else if (i == 10 || i == 11)
                            {
                                if (rapor.ilacRapor != null)
                                {
                                    responseObj.ReportStartDate = Convert.ToDateTime(rapor.ilacRapor.raporDVO.baslangicTarihi);
                                    responseObj.ReportEndDate = Convert.ToDateTime(rapor.ilacRapor.raporDVO.bitisTarihi);
                                    responseObj.reportDescription = rapor.ilacRapor.raporDVO.aciklama;
                                    responseObj.raporTesis = rapor.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                    responseObj.reportType = "İlaç";
                                }
                            }

                            reportList.Add(responseObj);
                        }
                    }

                }

                var Input = TTUtils.SaglikNetHelper.XMLSerialize(reportList);
                return reportList;
            }

        }

    }

    public class ERaporSorgulaRequest
    {
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
        public Guid actionId { get; set; }
    }

    public class ERaporSorgulaResponseClass
    {
        public string raporTesis { get; set; }
        public DateTime ReportStartDate { get; set; }
        public DateTime ReportEndDate { get; set; }
        public string reportDescription { get; set; }
        public string seansSayisi { get; set; }
        public string reportType { get; set; }
        public RaporIslemleri.raporCevapDVO raporCevapDVO { get; set; }
        public string reportXML { get; set; }
    }
}