//$DF03A063
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class MorgueServiceController
    {
        partial void PreScript_MorgueProcedureForm(MorgueProcedureFormViewModel viewModel, Morgue morgue, TTObjectContext objectContext)
        {
            var episode = viewModel._Morgue.Episode;
            var patient = viewModel._Morgue.Episode.Patient;
            //var deliveredBy = viewModel._Morgue.DeliveredBy;
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.OBSZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("OBSZORLA", "TRUE"));
            /*viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
            viewModel.SKRSIlceKodlaris = objectContext.LocalQuery<SKRSIlceKodlari>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSILKodlariList", viewModel.SKRSILKodlaris);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlceKodlariList", viewModel.SKRSIlceKodlaris);*/
        }

        partial void PostScript_MorgueProcedureForm(MorgueProcedureFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            morgue.Episode.Patient.DeathReportNo = viewModel._Morgue.DeathReportNo;
            morgue.Episode.Patient.ExDate = viewModel._Morgue.DateTimeOfDeath;
            objectContext.AddToRawObjectList(viewModel.Episodes);
        }

        [HttpPost]
        public string OpenOBSWebPage(ObsInput input)
        {
            #region SAB�TLER
            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string baseUrl = TTObjectClasses.SystemParameter.GetParameterValue("OBSBASEURL", "");
            string baseUrlApi = TTObjectClasses.SystemParameter.GetParameterValue("OBSBASEURLAPI", "");
            string returnURL = string.Empty;
            #endregion

            //ObsInput model = new ObsInput();

            if (String.IsNullOrEmpty(baseUrl) || String.IsNullOrEmpty(baseUrlApi))
                throw new Exception("Servis bildirimi yapabilmek i�in gerekli adres tan�mlar� eksik");

            if (input.FixedDoctorUniqueID == null)
            {
                using (var objContext = new TTObjectContext(false))
                {
                    BindingList<ResUser.GetResUser_Class> resUser = null;

                    resUser = ResUser.GetResUser(objContext, " AND THIS.OBJECTID='" + input.FixedDoctorObjectID + "'");
                    input.FixedDoctorUniqueID = resUser[0].UniqueRefNo.Value.ToString();
                }
            }


            input.DogumTarihi= input.DogumTarihi != null ? Convert.ToDateTime(input.DogumTarihi).ToString("dd.MM.yyyy") : "";//tarih format� s�k�nt� ��karm�� client'da

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrlApi);
            httpClient.DefaultRequestHeaders.Add("UserName", UserName);
            httpClient.DefaultRequestHeaders.Add("Password", Password);
            httpClient.DefaultRequestHeaders.Add("ApplicationCode", ApplicationCode);
            httpClient.DefaultRequestHeaders.Add("Hash", "");

            var response = httpClient.GetAsync("API/OBS/HbysServis/GetOlumBildirim?SaglikKurulusuReferansNo=" + input.SaglikKurulusuReferansNo).Result;
            var data = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServisSonucu<OlumBildirimBasicHbysDto>>(data.Result);
           
            //if (result.State == ServisSonucDurumu.HATA)
            //    throw new Exception(result.Message);
            //else 
            if (result.State != ServisSonucDurumu.BASARILI)//daha �nce kaydedilmedi ise �rnek uygulama bu �ekilde yapm��
            {
                var jsonstr = JsonConvert.SerializeObject(input)
                                            .Replace("{", "%7B")
                                            .Replace("}", "%7D")
                                            .Replace(":", "%3A")
                                            .Replace("\"", "%22")
                                            .Replace(" ", "%20");


                //Process.Start("chrome",
                //    string.Format("{0}/ObsWeb/OlumBildirimEkleWeb?Authorization={1}&Param={2}", baseUrl, GetToken(baseUrl,UserName,Password,ApplicationCode), jsonstr));

                returnURL = string.Format("{0}/ObsWeb/OlumBildirimEkleWeb?Authorization={1}&Param={2}", baseUrl, GetToken(baseUrl, UserName, Password, ApplicationCode,input.FixedDoctorUniqueID), jsonstr);
                return returnURL;

            }
            else
            {
                //Process.Start("chrome",
                //               string.Format("{0}/ObsWeb/OlumBildirimGoruntuleWeb?Authorization={1}&SaglikKurulusuReferansNo={2}", baseUrl, GetToken(baseUrl, UserName, Password,ApplicationCode), model.SaglikKurulusuReferansNo));
                returnURL = string.Format("{0}/ObsWeb/OlumBildirimGoruntuleWeb?Authorization={1}&SaglikKurulusuReferansNo={2}", baseUrl, GetToken(baseUrl, UserName, Password, ApplicationCode, input.FixedDoctorUniqueID), input.SaglikKurulusuReferansNo);
                return returnURL;
            }

        }

        private string GetToken(string baseUrl, string username, string password, string ApplicationCode,string FixedDoctorUniqueID)
        {

            var client = new RestClient(baseUrl);
            string IdentityNumber = "10000000000";// Common.CurrentResource.UniqueNo;//
            //FixedDoctorUniqueID = "10000000000";
            var request = new RestSharp.RestRequest("/AuthApi/connect/token");
            request.Method = Method.POST;
            request.AddParameter("username", username, ParameterType.GetOrPost);
            request.AddParameter("password", password, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "password", ParameterType.GetOrPost);
            request.AddParameter("Rol", "Kurum", ParameterType.GetOrPost);
            request.AddParameter("ApplicationCode", ApplicationCode, ParameterType.GetOrPost);
            request.AddParameter("IdentyNumber", FixedDoctorUniqueID, ParameterType.GetOrPost);
            request.AddParameter("hash", String.Empty, ParameterType.GetOrPost);
            //request.AddHeader("content-type", "application/x-www-form-urlencoded");

            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Token token = new Token();
                token = JsonConvert.DeserializeObject<Token>(response.Content); //JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(response.Content)["data"]["access_token"];
                return token.access_token.ToString();
            }
            else
            {
                OBSError _error = new OBSError();
                _error = JsonConvert.DeserializeObject<OBSError>(response.Content);
                throw new Exception(_error.error_description);
            }

        }

    }
}

namespace Core.Models
{
    public partial class MorgueProcedureFormViewModel
    {
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public bool OBSZorla { get; set; }
    }

    #region OL�M B�LD�R�M
    [Serializable]
    public class ObsInput
    {
        public long TcKimlikNo { get; set; }
        public int UyrukKodu { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string BabaAdi { get; set; }
        public string AnaAdi { get; set; }

        //dd.mm.yyyy format�nda
        public string DogumTarihi { get; set; }
        public string DogumYeri { get; set; }

        //SKRS Sistem Kodu :	784d0f4f-0603-4425-937f-1a3941fc3a1f
        //Sistem Ad� :	Cinsiyet
        public int Cinsiyet { get; set; }

        //SKRS Sistem Kodu :	5bc508fa-782a-4d75-831f-34948e350e72
        //Sistem Ad� :	�l
        public int AdresIl { get; set; }

        // Sistem Kodu :	96184a9e-537c-4a70-8b3a-27a7a170355b
        //Sistem Ad� :	�l�e
        public int AdresIlce { get; set; }
        public string KoyMahalleAdi { get; set; }
        public string BulvarCaddeSokakAdi { get; set; }
        public string SiteBlokAdi { get; set; }
        public string DisKapiNo { get; set; }
        public string IcKapiNo { get; set; }

        //dd.mm.yyyy hh24:mi format�nda
        public string OlumZamani { get; set; }

        //Sistem Kodu :	a4a991c6-70fa-4e40-9ffe-aaea2150faf2
        // Sistem Ad� :	�l�m Yeri
        public int OlumYeri { get; set; }

        //Sistem Kodu :	2ae7bfff-3f84-4d21-a9d9-8cdbfe693f08
        //Sistem Ad� :	�l�m �ekli
        public int OlumSekli { get; set; }

        //Sistem Kodu :	16073eac-a3f9-4efb-91ac-a08442c240a4
        //Sistem Ad� :	Anne �l�m Zaman�
        public int AnneOlumZamani { get; set; }

        //1:�l� Do�um, 2: Bebek �l�m�
        public int BebekOlumSekli { get; set; }

        //hh24:mi format�nda
        public string DogumSaati { get; set; }
        public long AnneTc { get; set; }
        public int AnneYas { get; set; }
        public int DogumSirasi { get; set; }

        //Hafta
        public int GebelikSuresi { get; set; }

        //Gram
        public int DogumAgirligi { get; set; }

        //Birden fazla varsa virg�l ile yaz�lacak
        public string OlumNedenleri { get; set; }
        public string SysTakipNo { get; set; }
        public string SaglikKurulusuReferansNo { get; set; }

        public string FixedDoctorUniqueID { get; set; }//�l�m� tespit eden doktor, token almak i�in
        public Guid FixedDoctorObjectID { get; set; }// doktor combosundan se�ildi ise Tc'yi �ekebilmek i�in
    }

    public class OlumBildirimBasicHbysDto
    {
        public string FormNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string BabaAdi { get; set; }
        public string AnaAdi { get; set; }
        public DateTime? OlumTarihi { get; set; }
        public string OlumSaati { get; set; }
        public string OlumDakikasi { get; set; }
        public int? OlumYeriId { get; set; }
        public string OlumYeri { get; set; }
        public int? OlumSekliID { get; set; }
        public string OlumSekli { get; set; }
        public string OlumNedeniICD1 { get; set; }
        public string OlumNedeniICD2 { get; set; }
        public string OlumNedeniICD3 { get; set; }
        public string OlumNedeniICD4 { get; set; }
        public bool? OluDogummu { get; set; }
        public bool? BebekOlumu { get; set; }
        public string BebekDogumSaati { get; set; }
        public string BebekDogumDakikasi { get; set; }
        public string AnneTCKimlikNo { get; set; }
        public int? AnneYasi { get; set; }
        public int? BebekDogumSirasi { get; set; }
        public int? GebelikSuresi { get; set; }
        public int? DogumAgirligi { get; set; }
        public int? AnneOlumNedeniId { get; set; }
        public string AnneOlumNedeni { get; set; }
    }

    public class ServisSonucu<T>
    {
        public ServisSonucDurumu State { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }

    public enum ServisSonucDurumu
    {
        HATA = 0,
        BASARILI = 1,
        UYARI = 2
    }

    public class OBSError
    {
        public string error { get; set; }
        public string error_description { get; set; }
    }
    #endregion
}
