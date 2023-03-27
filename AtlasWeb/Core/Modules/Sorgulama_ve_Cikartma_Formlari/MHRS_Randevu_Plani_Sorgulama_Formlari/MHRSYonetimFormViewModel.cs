//$F448E246
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Controllers
{
    public partial class MHRSYonetimServiceController
    {
        [HttpGet]
        public PoliklinikMHRSKlinikKoduEslestirmeListModel[] setMHRSClinicCode()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetAllPoliclinics(objectContext);
                List<PoliklinikMHRSKlinikKoduEslestirmeListModel> klinikKoduEslestirmeList = new List<PoliklinikMHRSKlinikKoduEslestirmeListModel>();
                foreach (ResPoliclinic policlinic in policlinicList)
                {
                    if (policlinic.IsActive == true && policlinic.ResourceSpecialities != null && policlinic.ResourceSpecialities.Count > 0)
                    {
                        if (policlinic.ResourceSpecialities[0].Speciality != null && policlinic.ResourceSpecialities[0].Speciality.IsMHRSClinic == true && policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik != null)
                        {
                            policlinic.MHRSCode = Convert.ToInt32(policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU);

                            PoliklinikMHRSKlinikKoduEslestirmeListModel klinikKoduEslestirme = new PoliklinikMHRSKlinikKoduEslestirmeListModel();
                            klinikKoduEslestirme.Poliklinik = policlinic;
                            klinikKoduEslestirme.PoliklinikName = policlinic.Name;
                            klinikKoduEslestirme.MHRSKlinik = policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU + " : " + policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik.ADI; ;
                            klinikKoduEslestirme.Ekle = true;
                            klinikKoduEslestirmeList.Add(klinikKoduEslestirme);
                        }
                    }
                }
                objectContext.Save();
                return klinikKoduEslestirmeList.ToArray();
            }
        }

        [HttpPost]
        public MHRSKlinikEkleListModel[] addClinic(List<PoliklinikMHRSKlinikKoduEslestirmeListModel> MHRSKlinikEslesmeList)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
                string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");

                List<MHRSKlinikEkleListModel> eklenenKlinikList = new List<MHRSKlinikEkleListModel>();

                if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                {
                    foreach (PoliklinikMHRSKlinikKoduEslestirmeListModel item in MHRSKlinikEslesmeList)
                    {
                        if (item.Poliklinik.IsActive == true && item.Poliklinik.MHRSCode != null && item.Poliklinik.MHRSAltKlinikKodu == null && item.Ekle)
                        {
                            if (userName != null && password != null && MHRSKurumKodu != null)
                            {
                                MHRSServis.KurumKlinikEklemeTalepType kurumKlinikEklemeTalep = new MHRSServis.KurumKlinikEklemeTalepType();
                                MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                                MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                                MHRSServis.KurumKlinikEklemeCevapType kurumKlinikEklemeCevap = new MHRSServis.KurumKlinikEklemeCevapType();

                                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                kurumBilgileri.KurumKoduSpecified = true;
                                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                                kurumKlinikEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                kurumKlinikEklemeTalep.KurumBilgileri = kurumBilgileri;

                                kurumKlinikEklemeTalep.KlinikKodu = Convert.ToInt32(item.Poliklinik.MHRSCode);

                                kurumKlinikEklemeCevap = MHRSServis.WebMethods.KurumKlinikEklemeSync(Sites.SiteLocalHost, kurumKlinikEklemeTalep);
                                if (kurumKlinikEklemeCevap != null && kurumKlinikEklemeCevap.TemelCevapBilgileri != null)
                                {
                                    MHRSKlinikEkleListModel eklenenKlinik = new MHRSKlinikEkleListModel();

                                    if (kurumKlinikEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                    {
                                        eklenenKlinik.Poliklinik = item.Poliklinik;
                                        eklenenKlinik.PoliklinikName = item.Poliklinik.Name;
                                        eklenenKlinik.Eklendi = "Eklendi";
                                    }
                                    else
                                    {
                                        eklenenKlinik.Poliklinik = item.Poliklinik;
                                        eklenenKlinik.PoliklinikName = item.Poliklinik.Name;
                                        eklenenKlinik.Eklendi = kurumKlinikEklemeCevap.TemelCevapBilgileri.Aciklama;
                                    }
                                    eklenenKlinikList.Add(eklenenKlinik);
                                }
                                System.Threading.Thread.Sleep(1000);
                            }
                        }
                    }
                }
                else
                {
                    foreach (PoliklinikMHRSKlinikKoduEslestirmeListModel item in MHRSKlinikEslesmeList)
                    {
                        if (item.Poliklinik.IsActive == true && item.Poliklinik.MHRSCode != null && item.Poliklinik.MHRSAltKlinikKodu == null && item.Ekle)
                        {
                            if (MHRSKurumKodu != null)
                            {
                                KurumKlinikEklemeTalep talepDto = new KurumKlinikEklemeTalep();
                                talepDto.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                talepDto.islemYapanTcKimlikNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                                talepDto.klinikKodu = Convert.ToInt32(item.Poliklinik.MHRSCode);

                                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");
                                string serializedObj = JsonConvert.SerializeObject(talepDto);


                                Schedule sch = new Schedule();
                                string accessToken = sch.LoginForMHRS();
                                if (accessToken == null)
                                    return null;

                                Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/kurum-klinik/kurum-klinik-ekle");

                                var client = new RestClient(uri);

                                RestRequest request = new RestRequest();
                                request.Method = Method.POST;
                                request.Parameters.Clear();

                                string bearerToken = "Bearer " + accessToken;
                                request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                                request.AddHeader("Accept", "application/json");
                                request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                                IRestResponse response = sch.PostCallForMHRS(client, request);
                                //IRestResponse response = client.Execute(request);

                                MHRSKlinikEkleListModel eklenenKlinik = new MHRSKlinikEkleListModel();

                                if (response.IsSuccessful)
                                {
                                    eklenenKlinik.Poliklinik = item.Poliklinik;
                                    eklenenKlinik.PoliklinikName = item.Poliklinik.Name;
                                    eklenenKlinik.Eklendi = "Eklendi";
                                }
                                else
                                {
                                    var errorMessage = response.Content;
                                    var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                                    string detailedError = "";

                                    if (errorObject != null)
                                    {
                                        var error = errorObject.Value<JArray>("errors");

                                        foreach (Newtonsoft.Json.Linq.JObject itemObj in error)
                                        {
                                            detailedError += itemObj.Value<string>("mesaj").ToString();
                                        }
                                        //var detailedError = errorObject.Value<string>("message");
                                        //errorMessage = error.ToString();
                                    }

                                    eklenenKlinik.Poliklinik = item.Poliklinik;
                                    eklenenKlinik.PoliklinikName = item.Poliklinik.Name;
                                    eklenenKlinik.Eklendi = detailedError;
                                }
                                eklenenKlinikList.Add(eklenenKlinik);
                            }
                        }
                    }
                }
                return eklenenKlinikList.ToArray();
            }
        }
        [HttpPost]
        public MHRSAltKlinikEkleListModel[] addPoliclinic(List<MHRSKlinikEkleListModel> klinikList)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                List<MHRSAltKlinikEkleListModel> eklenenAltKlinikList = new List<MHRSAltKlinikEkleListModel>();

                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");

                if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                {

                    string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                    string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");

                    string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");



                    foreach (MHRSKlinikEkleListModel item in klinikList)
                    {
                        if (item.Poliklinik.IsActive == true && item.Poliklinik.MHRSCode != null && item.Poliklinik.MHRSAltKlinikKodu == null)
                        {
                            if (userName != null && password != null && MHRSKurumKodu != null)
                            {
                                MHRSServis.KurumAltKlinikEklemeTalepType kurumAltKlinikEklemeTalep = new MHRSServis.KurumAltKlinikEklemeTalepType();
                                MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                                MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                                MHRSServis.KurumAltKlinikEklemeCevapType kurumAltKlinikEklemeCevap = new MHRSServis.KurumAltKlinikEklemeCevapType();

                                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                kurumBilgileri.KurumKoduSpecified = true;
                                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                                kurumAltKlinikEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                kurumAltKlinikEklemeTalep.KurumBilgileri = kurumBilgileri;

                                kurumAltKlinikEklemeTalep.KlinikKodu = Convert.ToInt32(item.Poliklinik.MHRSCode);
                                kurumAltKlinikEklemeTalep.AltKlinikAdi = item.Poliklinik.Name + ((item.Poliklinik.IsGoruntuluRandevu != null && item.Poliklinik.IsGoruntuluRandevu.Value == true) ? " (GÖRÜNTÜLÜ GÖRÜÞME)" : "1");
                                kurumAltKlinikEklemeTalep.GoruntuluRandevu = item.Poliklinik.IsGoruntuluRandevu != null ? item.Poliklinik.IsGoruntuluRandevu.Value : false;

                                kurumAltKlinikEklemeCevap = MHRSServis.WebMethods.KurumAltKlinikEklemeSync(Sites.SiteLocalHost, kurumAltKlinikEklemeTalep);
                                if (kurumAltKlinikEklemeCevap != null && kurumAltKlinikEklemeCevap.TemelCevapBilgileri != null)
                                {
                                    MHRSAltKlinikEkleListModel eklenenAltKlinik = new MHRSAltKlinikEkleListModel();

                                    if (kurumAltKlinikEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                    {
                                        ResPoliclinic policlinic = objectContext.GetObject<ResPoliclinic>(item.Poliklinik.ObjectID);
                                        if (policlinic != null)
                                            policlinic.MHRSAltKlinikKodu = kurumAltKlinikEklemeCevap.AltKlinikKodu;
                                        eklenenAltKlinik.Poliklinik = item.Poliklinik;
                                        eklenenAltKlinik.PoliklinikName = item.Poliklinik.Name;
                                        eklenenAltKlinik.Eklendi = "Eklendi";
                                    }
                                    else
                                    {
                                        eklenenAltKlinik.Poliklinik = item.Poliklinik;
                                        eklenenAltKlinik.PoliklinikName = item.Poliklinik.Name;
                                        eklenenAltKlinik.Eklendi = kurumAltKlinikEklemeCevap.TemelCevapBilgileri.Aciklama;
                                    }
                                    eklenenAltKlinikList.Add(eklenenAltKlinik);
                                }
                                System.Threading.Thread.Sleep(1000);
                            }
                        }
                    }
                }
                else
                {
                    foreach (MHRSKlinikEkleListModel item in klinikList)
                    {
                        if (item.Poliklinik.IsActive == true && item.Poliklinik.MHRSCode != null && item.Poliklinik.MHRSAltKlinikKodu == null)
                        {
                            if (MHRSKurumKodu != null)
                            {
                                MuayeneYeriEkleTalep talepDto = new MuayeneYeriEkleTalep();
                                talepDto.islemYapanTcKimlikNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                                talepDto.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                talepDto.klinikKodu = Convert.ToInt32(item.Poliklinik.MHRSCode);
                                talepDto.muayeneYeriAdi = item.Poliklinik.Name + ((item.Poliklinik.IsGoruntuluRandevu != null && item.Poliklinik.IsGoruntuluRandevu.Value == true) ? " (GÖRÜNTÜLÜ GÖRÜÞME)" : "1");

                                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");
                                string serializedObj = JsonConvert.SerializeObject(talepDto);


                                Schedule sch = new Schedule();
                                string accessToken = sch.LoginForMHRS();
                                if (accessToken == null)
                                    return null;

                                Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/muayene-yeri/ekle");

                                var client = new RestClient(uri);

                                RestRequest request = new RestRequest();
                                request.Method = Method.POST;
                                request.Parameters.Clear();

                                string bearerToken = "Bearer " + accessToken;
                                request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                                request.AddHeader("Accept", "application/json");
                                request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                                IRestResponse response = sch.PostCallForMHRS(client, request);
                                //IRestResponse response = client.Execute(request);


                                MHRSAltKlinikEkleListModel eklenenAltKlinik = new MHRSAltKlinikEkleListModel();

                                if (response.IsSuccessful)
                                {
                                    var perfResult = JsonConvert.DeserializeObject<MuayeneYeriResponse>(response.Content);
                                    if (perfResult != null && perfResult.data.muayeneYeriId != null)
                                    {


                                        ResPoliclinic policlinic = objectContext.GetObject<ResPoliclinic>(item.Poliklinik.ObjectID);
                                        if (policlinic != null)
                                            policlinic.MHRSAltKlinikKodu = perfResult.data.muayeneYeriId;
                                        eklenenAltKlinik.Poliklinik = item.Poliklinik;
                                        eklenenAltKlinik.PoliklinikName = item.Poliklinik.Name;
                                        eklenenAltKlinik.Eklendi = "Eklendi";
                                    }

                                }
                                else
                                {
                                    {
                                        var errorMessage = response.Content;
                                        var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                                        string detailedError = "";

                                        if (errorObject != null)
                                        {
                                            var error = errorObject.Value<JArray>("errors");

                                            foreach (Newtonsoft.Json.Linq.JObject itemObj in error)
                                            {
                                                detailedError += itemObj.Value<string>("mesaj").ToString();
                                            }
                                            //var detailedError = errorObject.Value<string>("message");
                                            //errorMessage = error.ToString();
                                        }

                                        eklenenAltKlinik.Poliklinik = item.Poliklinik;
                                        eklenenAltKlinik.PoliklinikName = item.Poliklinik.Name;
                                        eklenenAltKlinik.Eklendi = detailedError;
                                    }
                                    eklenenAltKlinikList.Add(eklenenAltKlinik);
                                }

                            }
                        }
                    }
                }
                objectContext.Save();
                return eklenenAltKlinikList.ToArray();
            }
        }
        [HttpGet]
        public DoktorEkleListModel[] addDoctor()
        {
            bool isNewMHRS = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE"));
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

            List<DoktorEkleListModel> eklenenDoktorList = new List<DoktorEkleListModel>();

            if (isNewMHRS)
            {

                using (var objectContext = new TTObjectContext(false))
                {




                    BindingList<ResUser.GetdoctorsForMHRS_Class> doctorList = ResUser.GetdoctorsForMHRS();

                    foreach (ResUser.GetdoctorsForMHRS_Class doctor in doctorList)
                    {
                        if (doctor.Tc != null)
                        {
                            KlinikHekimEkle_Input input = new KlinikHekimEkle_Input();
                            input.hekimTcKimlikNo = Convert.ToInt64(doctor.Tc);
                            input.klinikKodu = Convert.ToInt32(doctor.Mhrskodu);
                            input.lgeciciGorevli = false;
                            input.lhekimOncelikSirasi = false;
                            input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);

                            string serializedObj = JsonConvert.SerializeObject(input);

                            Schedule schedule = new Schedule();
                            string accessToken = schedule.LoginForMHRS();

                            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/klinik-hekim/ekle");

                            var client = new RestClient(uri);

                            var request = new RestSharp.RestRequest();
                            request.Method = Method.POST;
                            request.Parameters.Clear();

                            string bearerToken = "Bearer " + accessToken;
                            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                            request.AddHeader("Accept", "application/json");
                            request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                            //IRestResponse response = client.Execute(request);
                            IRestResponse response = schedule.PostCallForMHRS(client, request);

                            DoktorEkleListModel eklenenDoktor = new DoktorEkleListModel();
                            if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                            {
                                var errorMessage = response.Content;
                                var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                                string detailedError = "";

                                if (errorObject != null)
                                {
                                    var error = errorObject.Value<JArray>("errors");

                                    foreach (Newtonsoft.Json.Linq.JObject item in error)
                                    {
                                        detailedError += item.ToString();
                                    }

                                }

                                eklenenDoktor.Uzmanlik = doctor.Uzmanlikdali;
                                eklenenDoktor.Doktor = doctor.Doktoradi;
                                eklenenDoktor.Eklendi = detailedError;

                            }

                            if (response.IsSuccessful)
                            {
                                eklenenDoktor.Uzmanlik = doctor.Uzmanlikdali;
                                eklenenDoktor.Doktor = doctor.Doktoradi;
                                eklenenDoktor.Eklendi = "Eklendi";
                            }

                            eklenenDoktorList.Add(eklenenDoktor);
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                }


              }
            else { 

                using (var objectContext = new TTObjectContext(false))
                {


         

                    BindingList<ResUser.GetdoctorsForMHRS_Class> doctorList = ResUser.GetdoctorsForMHRS();

                    foreach (ResUser.GetdoctorsForMHRS_Class doctor in doctorList)
                    {
                        if (doctor.Tc != null)
                        {
                            if (userName != null && password != null && MHRSKurumKodu != null)
                            {
                                MHRSServis.KurumHekimEklemeTalepType kurumHekimEklemeTalep = new MHRSServis.KurumHekimEklemeTalepType();
                                MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                                MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                                MHRSServis.KurumHekimEklemeCevapType kurumHekimEklemeCevap = new MHRSServis.KurumHekimEklemeCevapType();

                                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                kurumBilgileri.KurumKoduSpecified = true;
                                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                                kurumHekimEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                kurumHekimEklemeTalep.KurumBilgileri = kurumBilgileri;

                                kurumHekimEklemeTalep.KlinikKodu = Convert.ToInt32(doctor.Mhrskodu);
                                kurumHekimEklemeTalep.HekimKodu = doctor.Tc.ToString();

                                kurumHekimEklemeCevap = MHRSServis.WebMethods.KurumHekimEklemeSync(Sites.SiteLocalHost, kurumHekimEklemeTalep);
                                if (kurumHekimEklemeCevap != null && kurumHekimEklemeCevap.TemelCevapBilgileri != null)
                                {
                                    DoktorEkleListModel eklenenDoktor = new DoktorEkleListModel();

                                    if (kurumHekimEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                    {
                                        eklenenDoktor.Uzmanlik = doctor.Uzmanlikdali;
                                        eklenenDoktor.Doktor = doctor.Doktoradi;
                                        eklenenDoktor.Eklendi = "Eklendi";
                                    }
                                    else
                                    {
                                        eklenenDoktor.Uzmanlik = doctor.Uzmanlikdali;
                                        eklenenDoktor.Doktor = doctor.Doktoradi;
                                        eklenenDoktor.Eklendi = kurumHekimEklemeCevap.TemelCevapBilgileri.Aciklama;
                                    }
                                    eklenenDoktorList.Add(eklenenDoktor);
                                }
                            }
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                   
                }
            }

            return eklenenDoktorList.ToArray();
        }

        [HttpPost]
        public ScheduleListModel[] getAllSchedule(MHRSYonetimFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<ScheduleListModel> scheduleList = new List<ScheduleListModel>();

                BindingList<Schedule> schedules;
                if (viewModel.Policlinic == null && viewModel.Doctor == null)
                    schedules = Schedule.GetScheduleForMHRS(objectContext, viewModel.BaslangicTarihi.Date, viewModel.BitisTarihi.Date.AddDays(1).AddMilliseconds(-1), Guid.Empty, Guid.Empty);
                else if (viewModel.Policlinic != null && viewModel.Doctor == null)
                    schedules = Schedule.GetScheduleForMHRS(objectContext, viewModel.BaslangicTarihi.Date, viewModel.BitisTarihi.Date.AddDays(1).AddMilliseconds(-1), viewModel.Policlinic.ObjectID, Guid.Empty);
                else if (viewModel.Policlinic == null && viewModel.Doctor != null)
                    schedules = Schedule.GetScheduleForMHRS(objectContext, viewModel.BaslangicTarihi.Date, viewModel.BitisTarihi.Date.AddDays(1).AddMilliseconds(-1), Guid.Empty, viewModel.Doctor.ObjectID);
                else
                    schedules = Schedule.GetScheduleForMHRS(objectContext, viewModel.BaslangicTarihi.Date, viewModel.BitisTarihi, viewModel.Policlinic.ObjectID, viewModel.Doctor.ObjectID);

                foreach (Schedule item in schedules)
                {
                    ScheduleListModel schedule = new ScheduleListModel();
                    if (viewModel.Kesinlesmis == true)
                    {
                        schedule.PoliklinikName = item.MasterResource != null ? item.MasterResource.Name : null;
                        schedule.Doktor = item.Resource != null ? item.Resource.Name : null;
                        schedule.BaslangicTarihi = item.StartTime != null ? item.StartTime.Value.ToString() : null;
                        schedule.BitisTarihi = item.EndTime != null ? item.EndTime.Value.ToString() : null;
                        schedule.Kesinlesti = item.MHRSKesinCetvelID != null ? true : false;
                        schedule.KesinlesmeHatasi = item.ErrorOfMHRSApprove;

                        scheduleList.Add(schedule);
                    }
                    else
                    {
                        if (item.MHRSKesinCetvelID == null)
                        {
                            schedule.PoliklinikName = item.MasterResource != null ? item.MasterResource.Name : null;
                            schedule.Doktor = item.Resource != null ? item.Resource.Name : null;
                            schedule.BaslangicTarihi = item.StartTime != null ? item.StartTime.Value.ToString() : null;
                            schedule.BitisTarihi = item.EndTime != null ? item.EndTime.Value.ToString() : null;
                            schedule.Kesinlesti = item.MHRSKesinCetvelID != null ? true : false;
                            schedule.KesinlesmeHatasi = item.ErrorOfMHRSApprove;

                            scheduleList.Add(schedule);
                        }
                    }
                }
                return scheduleList.ToArray();
            }
        }
        [HttpGet]
        public BransListModel[] GetBransofPoliclinic(Guid policlinicObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<BransListModel> bransList = new List<BransListModel>();
                if (policlinicObjectID != null)
                {
                    ResPoliclinic policlinic = objectContext.GetObject<ResPoliclinic>(policlinicObjectID);
                    foreach (ResourceSpecialityGrid item in policlinic.ResourceSpecialities)
                    {
                        BransListModel brans = new BransListModel();
                        brans.BransKodu = item.Speciality.Code;
                        bransList.Add(brans);
                    }
                }
                return bransList.ToArray();
            }
        }

        [HttpPost]
        public List<CetvelSorgulamaReturnData> MHRSCetvelSorgula(CetvelSorgulaViewModel model, string StartTime = null, string EndTime = null)
        {
            List<CetvelSorgulamaReturnData> list = new List<CetvelSorgulamaReturnData>();
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");
            if (MHRSKurumKodu == null)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25817", "XXXXXX MHRS bildirime kapalı!"));

            }
            else
            {

                CetvelSorgulama_Input input = new CetvelSorgulama_Input();

                using (var objectContext = new TTObjectContext(false))
                {
                    ResUser resuser = null;
                    ResPoliclinic policlinic = null;


                    if (StartTime == null && EndTime == null)
                    {
                        input.baslangicZamani = Convert.ToDateTime(model.StartDate).ToString("yyyy-MM-dd 00:00:00");
                        input.bitisZamani = Convert.ToDateTime(model.EndDate).ToString("yyyy-MM-dd 23:59:59");
                    }
                    else
                    {
                        input.baslangicZamani = Convert.ToDateTime(model.StartDate).ToString("yyyy-MM-dd " + StartTime);
                        input.bitisZamani = Convert.ToDateTime(model.EndDate).ToString("yyyy-MM-dd " + EndTime);
                    }

                    if (model.SearchType == 0) //hekim
                    {
                        resuser = objectContext.GetObject(model.Doctor.ObjectID, typeof(ResUser)) as ResUser;
                        input.cetvelTipi = 1;
                        input.hekimTcKimlikNo = Convert.ToInt64(resuser.UniqueNo);
                        input.klinikKodu = Convert.ToInt32(resuser.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU);
                        input.muayeneYeriId = -1;
                        input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                        input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
                    }
                    else if (model.SearchType == 1) //Bölüm
                    {
                        policlinic = objectContext.GetObject(model.Birim.ObjectID, typeof(ResPoliclinic)) as ResPoliclinic;
                        input.cetvelTipi = 2;
                        input.hekimTcKimlikNo = null;
                        input.klinikKodu = Convert.ToInt32(policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU);
                        input.muayeneYeriId = policlinic.MHRSAltKlinikKodu == null ? 0 : Convert.ToInt32(policlinic.MHRSAltKlinikKodu);
                        input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                        input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
                    }

                    string serializedObj = JsonConvert.SerializeObject(input);

                    Schedule schedule = new Schedule();
                    string accessToken = schedule.LoginForMHRS();

                    Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/cetvel/search");

                    var client = new RestClient(uri);

                    var request = new RestSharp.RestRequest();
                    request.Method = Method.POST;
                    request.Parameters.Clear();

                    string bearerToken = "Bearer " + accessToken;
                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                    request.AddHeader("Accept", "application/json");
                    request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                    IRestResponse response = schedule.PostCallForMHRS(client, request);

                    //IRestResponse response = client.Execute(request);
                    if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                    {
                        var errorMessage = response.Content;
                        var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                        string detailedError = "";

                        if (errorObject != null)
                        {
                            var error = errorObject.Value<JArray>("errors");

                            foreach (Newtonsoft.Json.Linq.JObject item in error)
                            {
                                detailedError += item.ToString();
                            }

                        }
                        throw new TTException(detailedError);
                    }

                    if (response.IsSuccessful)
                    {
                        var output = JsonConvert.DeserializeObject<CetvelSorgulama_Output>(response.Content);
                        string detailedError = "";
                        if (output.errors.Count > 0)
                        {
                            foreach (Newtonsoft.Json.Linq.JObject item in output.errors)
                            {
                                detailedError += item.ToString();
                            }
                            throw new TTException(detailedError);
                        }

                        foreach (CetvelSorgulama_Data data in output.data)
                        {
                            CetvelSorgulamaReturnData c = new CetvelSorgulamaReturnData();
                            c.cetvelId = data.cetvelId;
                            c.cetvelTipi = data.cetvelTipi.valText;
                            c.cetvelTipiValue = data.cetvelTipi.val.ToString();
                            c.aksiyonId = data.aksiyonId;
                            c.baslangicZamani = data.baslangicZamani;
                            c.bitisZamani = data.bitisZamani;
                            c.klinikKodu = data.klinikKodu;
                            c.klinikAdi = data.klinikAdi;
                            c.muayeneYeriId = data.muayeneYeriId;
                            c.muayeneYeriAdi = data.muayeneYeriAdi;
                            c.randevuSuresi = data.randevuSuresi;
                            c.slotHastaSayisi = data.slotHastaSayisi;
                            c.cetvelDurumu = data.cetvelDurumu.valText;
                            c.cetvelDurumuValue = data.cetvelDurumu.val.ToString();
                            if (model.SearchType == 0) //hekim
                            {
                                c.resUserID = resuser.ObjectID.ToString(); 
                            }else if (model.SearchType == 1)//Birime göre sorgulanıyorsa eğer hekim tc gelmiyor.
                            {
                                c.resUserID = "";
                            }
                            //c.ikOzelDurum = data.ikOzelDurum.;

                            if (data.cetvelDurumu.val == 2)
                            {
                                BindingList<Schedule> scheduleList = Schedule.GrtScheduleByMHRSKesinCetvelID(objectContext, data.cetvelId);
                                if (scheduleList.Count == 0)
                                {
                                    c.hasSchedule = false;
                                    c.CetvelKayitliMi = "Kayıtlı Değil.";
                                }
                                else
                                {
                                    c.hasSchedule = true;
                                    c.CetvelKayitliMi = "Kayıtlı.";
                                }
                            }
                            else if (data.cetvelDurumu.val == 1)
                            {

                                BindingList<Schedule> scheduleList = Schedule.GrtScheduleByMHRSTaslakID(objectContext, data.cetvelId);
                                if (scheduleList.Count == 0)
                                {
                                    c.hasSchedule = false;
                                    c.CetvelKayitliMi = "Kayıtlı Değil.";
                                }
                                else
                                {
                                    c.hasSchedule = true;
                                    c.CetvelKayitliMi = "Kayıtlı.";
                                }
                            }

                            list.Add(c);

                        }
                    }
                }
            }

            return list;

        }
        [HttpPost]
        public void SaveSchedule(CetvelSorgulamaReturnData data)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetByMHRSKlinikVeAltKlinikKodu(objectContext, data.klinikKodu, Convert.ToInt32(data.muayeneYeriId));
                ResUser resuser = null;
              
                Schedule newSchedule = (Schedule)objectContext.CreateObject("Schedule");


                if (data.cetvelTipiValue == "1")//Hekim
                { 
                    resuser = objectContext.GetObject(new Guid(data.resUserID), typeof(ResUser)) as ResUser;
                    newSchedule.CetvelTipiValue = CetvelTipiEnum.Hekim;
                }
                else//Cetvel tipi birim ise o birim ile ilişkilendirilmiş doktor set ediliyor.
                {
                    newSchedule.CetvelTipiValue = CetvelTipiEnum.Bolum;
                    string _doctorfilter = " AND this.ISACTIVE = 1 AND USERRESOURCES.RESOURCE ='" + policlinicList[0].ObjectID + "'";

                    BindingList<ResUser.SpecialistDoctorListNQL_Class> DoctorListFromQuery = ResUser.SpecialistDoctorListNQL(_doctorfilter);
                    if (DoctorListFromQuery.Count > 0)
                        resuser = objectContext.GetObject(new Guid(DoctorListFromQuery[0].ObjectID.ToString()), typeof(ResUser)) as ResUser;


                }

                newSchedule.MasterResource = policlinicList[0];

                newSchedule.Resource = resuser;

                BindingList<AppointmentDefinition> appointmentDefinitionList = AppointmentDefinition.GetAppointmentDefinitionByName(objectContext, AppointmentDefinitionEnum.PatientExamination);
                if (appointmentDefinitionList.Count > 0)
                    newSchedule.AppointmentDefinition = appointmentDefinitionList[0];

                newSchedule.ScheduleDate = Convert.ToDateTime(data.baslangicZamani).Date;
                newSchedule.Duration = Convert.ToInt32(data.randevuSuresi);

                newSchedule.StartTime = Convert.ToDateTime(data.baslangicZamani);
                newSchedule.EndTime = Convert.ToDateTime(data.bitisZamani);
                newSchedule.IsWorkHour = true;
                newSchedule.ScheduleType = ScheduleTypeEnum.Timely;
            

                BindingList<MHRSActionTypeDefinition> actionTypeList = MHRSActionTypeDefinition.GetMHRSActionTypeDefByActionCode(objectContext, data.aksiyonId.ToString());
                if (actionTypeList.Count > 0)
                    newSchedule.MHRSActionTypeDefinition = actionTypeList[0];

                newSchedule.SentToMHRS = true;

                if (data.cetvelDurumuValue == "2")
                    newSchedule.MHRSKesinCetvelID = data.cetvelId;

                if (data.cetvelDurumuValue == "1")
                    newSchedule.MHRSTaslakCetvelID = data.cetvelId.ToString();

                
                //1 taslak 2 kesin 
                objectContext.Save();
            }

        }
    }
}


namespace Core.Models
{
    public partial class MHRSYonetimFormViewModel
    {
        public List<PoliklinikMHRSKlinikKoduEslestirmeListModel> PoliklinikMHRSKlinikKoduEslestirmeList{get;set;}
        public List<MHRSKlinikEkleListModel> MHRSKlinikEkleList { get; set; }
        public List<MHRSAltKlinikEkleListModel> MHRSAltKlinikEkleList { get; set; }
        public List<DoktorEkleListModel> DoktorEkleList { get; set; }
        public List<ScheduleListModel> ScheduleList { get; set; }
        public List<BransListModel> BransList { get; set; }
        public ResUser Doctor { get; set; }
        public ResPoliclinic Policlinic { get; set; }
        public bool Kesinlesmis { get; set; }
        public DateTime BaslangicTarihi
        {
            get;
            set;
        }
        public DateTime BitisTarihi
        {
            get;
            set;
        }
        public MHRSYonetimFormViewModel()
        {
            this.PoliklinikMHRSKlinikKoduEslestirmeList = new List<PoliklinikMHRSKlinikKoduEslestirmeListModel>();
            this.MHRSKlinikEkleList = new List<MHRSKlinikEkleListModel>();
            this.MHRSAltKlinikEkleList = new List<MHRSAltKlinikEkleListModel>();
            this.DoktorEkleList = new List<DoktorEkleListModel>();
            this.ScheduleList = new List<ScheduleListModel>();
            this.BransList = new List<BransListModel>();
            this.BaslangicTarihi = DateTime.Now;
            this.BitisTarihi = DateTime.Now;
        }
    }
    public class PoliklinikMHRSKlinikKoduEslestirmeListModel
    {
        public ResPoliclinic Poliklinik { get; set; }
        public string PoliklinikName { get; set; }
        public string MHRSKlinik { get; set; }
        public bool Ekle { get; set; }

    }
    public class MHRSKlinikEkleListModel
    {
        public ResPoliclinic Poliklinik { get; set; }
        public string PoliklinikName { get; set; }
        public string Eklendi { get; set; }
    }
    public class MHRSAltKlinikEkleListModel
    {
        public ResPoliclinic Poliklinik { get; set; }
        public string PoliklinikName { get; set; }
        public string Eklendi { get; set; }
    }
    public class DoktorEkleListModel
    {
        public string Uzmanlik { get; set; }
        public string Doktor { get; set; }
        public string Eklendi { get; set; }
    }
    public class ScheduleListModel
    {
        public string PoliklinikName { get; set; }
        public string Doktor { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public bool Kesinlesti { get; set; }
        public string KesinlesmeHatasi { get; set; }
    }
    public class BransListModel
    {
        public string BransKodu { get; set; }
    }

    public class KlinikHekimEkle_Input
    {
        public Int64 hekimTcKimlikNo { get; set; }
        public int klinikKodu { get; set; }
        public bool lgeciciGorevli { get; set; }
        public bool lhekimOncelikSirasi { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
    }

    public class CetvelSorgulaViewModel
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ResUser Doctor { get; set; }

        public ResPoliclinic Birim { get; set; }

        public int SearchType { get; set; }
    }

    public class CetvelSorgulama_Input
    {
        public string baslangicZamani { get; set; }
        public string bitisZamani { get; set; }
        public int cetvelTipi { get; set; }
        public Int64? hekimTcKimlikNo { get; set; }
        public int klinikKodu { get; set; }
        public int muayeneYeriId { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo{ get; set; }
    }

    public class CetvelDurumu
    {
        public int val { get; set; }
        public string valText { get; set; }
    }

    public class CetvelTipi
    {
        public string valText { get; set; }
        public int val { get; set; }
    }

    public class CetvelSorgulama_Data
    {
        public int cetvelId { get; set; }
        public CetvelDurumu cetvelDurumu { get; set; }
        public CetvelTipi cetvelTipi { get; set; }
        public int aksiyonId { get; set; }
        public string baslangicZamani { get; set; }
        public string bitisZamani { get; set; }
        public int kurumKodu { get; set; }
        public int klinikKodu { get; set; }
        public string klinikAdi { get; set; }
        public int? muayeneYeriId { get; set; }
        public string muayeneYeriAdi { get; set; }
        public object hekimTcKimlikNo { get; set; }
        public int randevuSuresi { get; set; }
        public int slotHastaSayisi { get; set; }
        public int? enKucukYas { get; set; }
        public string enKucukYasTipi { get; set; }
        public int? enBuyukYas { get; set; }
        public string enBuyukYasTipi { get; set; }
        public object cinsiyet { get; set; }
        public object ikOzelDurum { get; set; }
    }

    public class CetvelSorgulama_Output
    {
        public string lang { get; set; }
        public bool success { get; set; }
        public List<object> infos { get; set; }
        public List<object> warnings { get; set; }
        public List<object> errors { get; set; }
        public List<CetvelSorgulama_Data> data { get; set; }
    }

    public class CetvelSorgulamaReturnData
    {
        public int cetvelId { get; set; }
        public string cetvelDurumu { get; set; }
        public string cetvelDurumuValue { get; set; }
        
        public string cetvelTipi { get; set; }
        public string cetvelTipiValue { get; set; }
        public int aksiyonId { get; set; }
        public string baslangicZamani { get; set; }
        public string bitisZamani { get; set; }
        public int klinikKodu { get; set; }
        public string klinikAdi { get; set; }
        public int? muayeneYeriId { get; set; }
        public string muayeneYeriAdi { get; set; }
        public int randevuSuresi { get; set; }
        public int slotHastaSayisi { get; set; }
        public string ikOzelDurum { get; set; }
        public bool hasSchedule { get; set; }
        public string CetvelKayitliMi { get; set; }
        public string resUserID { get; set; }
    }
    public class MuayeneYeriEkleTalep
    {
        public int klinikKodu { get; set; }
        public string muayeneYeriAdi { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
    }


    public class MuayeneYeriResponse
    {
        public string lang { get; set; }
        public bool success { get; set; }
        public List<Info> infos { get; set; }
        public List<object> warnings { get; set; }
        public List<object> errors { get; set; }
        public MuayeneYeriCevap data { get; set; }
    }

    public class MuayeneYeriCevap
    {
        public int kurumKodu { get; set; }
        public string muayeneYeriAdi { get; set; }
        public int muayeneYeriId { get; set; }
    }

    public class KurumKlinikEklemeTalep
    {
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
        public int klinikKodu { get; set; }


    }
}
