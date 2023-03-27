
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
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TTObjectClasses
{
    /// <summary>
    /// Randevu Planı
    /// </summary>
    public partial class Schedule : TTObject
    {
        public partial class GetWorkingResourcesForAsal_Class : TTReportNqlObject
        {
        }

        public partial class GetMHRSSchedules_Class : TTReportNqlObject
        {
        }

        #region MHRS_V2 2020_11_10
        public class MHRS_Login_Input
        {
            public Int64 kullaniciAdi { get; set; }
            public string parola { get; set; }
            public Int32 kurumKodu { get; set; }
            public string uygulamaKodu { get; set; }
        }

        #region LOGIN_OUTPUT
        public class Info
        {
            public string kodu { get; set; }
            public string mesaj { get; set; }
        }

        public class KullaniciTipi
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class GirisTipi
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class LoginData
        {
            public string uuid { get; set; }
            public string jwt { get; set; }
            public string kullaniciUuid { get; set; }
            public string kullaniciAdi { get; set; }
            public string kullaniciSoyadi { get; set; }
            public KullaniciTipi kullaniciTipi { get; set; }
            public string islemKanali { get; set; }
            public GirisTipi girisTipi { get; set; }
        }

        public class LoginRoot
        {
            public string lang { get; set; }
            public bool success { get; set; }
            public List<Info> infos { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public LoginData data { get; set; }
        }
        #endregion

        #region MHRS_TASLAK_CETVEL
        public class MHRS_TASLAK_CETVEL_INPUT
        {
            public int aksiyonId { get; set; }
            public string baslangicZamani { get; set; }
            public string bitisZamani { get; set; }
            public int cetvelTipi { get; set; }
            public string cinsiyet { get; set; }
            public int? enBuyukYas { get; set; }
            public string enBuyukYasTipi { get; set; }
            public int? enKucukYas { get; set; }
            public string enKucukYasTipi { get; set; }
            public Int64? hekimTcKimlikNo { get; set; }
            public List<int> ikOzelDurumList { get; set; }
            public int klinikKodu { get; set; }
            public int? muayeneYeriId { get; set; }
            public int randevuSuresi { get; set; }
            public int slotHastaSayisi { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }

        public class MHRS_TASLAK_ROOT
        {
            public string lang { get; set; }
            public bool success { get; set; }
            public List<Info> infos { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public List<TaslakData> data { get; set; }
        }

        public class TaslakData
        {
            public string cetvelId { get; set; }
        }

        public class CetvelDurumu
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class CetvelTipi
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class Cinsiyet
        {
            public string val { get; set; }
            public string valText { get; set; }
        }

        public class IkOzelDurum2
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class IkOzelDurum
        {
            public IkOzelDurum2 ikOzelDurum { get; set; }
        }

        public class Taslak_Array
        {
            public int aksiyonId { get; set; }
            public DateTime baslangicZamani { get; set; }
            public DateTime bitisZamani { get; set; }
            public CetvelDurumu cetvelDurumu { get; set; }
            public Int64 cetvelId { get; set; }
            public CetvelTipi cetvelTipi { get; set; }
            public Cinsiyet cinsiyet { get; set; }
            public int enBuyukYas { get; set; }
            public string enBuyukYasTipi { get; set; }
            public int enKucukYas { get; set; }
            public string enKucukYasTipi { get; set; }
            public int? hekimTcKimlikNo { get; set; }
            public List<IkOzelDurum> ikOzelDurum { get; set; }
            public string klinikAdi { get; set; }
            public int klinikKodu { get; set; }
            public int kurumKodu { get; set; }
            public string muayeneYeriAdi { get; set; }
            public int muayeneYeriId { get; set; }
            public int randevuSuresi { get; set; }
            public int slotHastaSayisi { get; set; }
        }

        public class MHRS_TASLAK_OUTPUT
        {
            public List<Taslak_Array> TaslakArray { get; set; }
        }

        public class MHRS_ISTISNA_INPUT
        {
            public string aciklama { get; set; }
            public int aksiyonId { get; set; }
            public string baslangicTarihSaati { get; set; }
            public string bitisTarihSaati { get; set; }
            public int cetvelTipi { get; set; }
            public string eposta { get; set; }
            public string hekimTcKimlikNoList { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
            public string istisnaBelgeAdi { get; set; }
            public string istisnaBelgesi { get; set; }
            public int klinikKodu { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public string muayeneYeriIdList { get; set; }
            public Int64 telefonNo { get; set; }
        }

        public class MHRS_ISTISNA_OUTPUT
        {
            public int aksiyonId { get; set; }
            public DateTime baslangicZamani { get; set; }
            public DateTime bitisZamani { get; set; }
            public int cetvelTipi { get; set; }
            public int? hekimTcKimlikNo { get; set; }
            public int islemYapanKurumKodu { get; set; }
            public int istisnaId { get; set; }
            public int klinikKodu { get; set; }
            public string muayeneYeriAdi { get; set; }
        }

        #endregion

        #region AKSIYONINFO
        public class AksiyonIslemTuru
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class KosulIkiGrup
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class AksiyonList
        {
            public string aciklama { get; set; }
            public bool aksiyonAcik { get; set; }
            public string aksiyonAdi { get; set; }
            public int aksiyonId { get; set; }
            public AksiyonIslemTuru aksiyonIslemTuru { get; set; }
            public CetvelTipi cetvelTipi { get; set; }
            public bool esnek { get; set; }
            public bool istisnaBelge { get; set; }
            public bool kosulBirDahil { get; set; }
            public KosulIkiGrup kosulIkiGrup { get; set; }
        }

        public class Aksiyon_Root_Input
        {
            public string lang { get; set; }
            public bool success { get; set; }
            public List<Info> infos { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public List<AksiyonList> data { get; set; }
        }
        #endregion

        #endregion


        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            //planlama yapılacak kaynak tabip ya da diş tabibi değilse MHRS işlemleri yapılmasın
            if (Resource is ResUser && (ResUser.HasRole((ResUser)Resource, new Guid(TTRoleNames.Tabip)) || ResUser.HasRole((ResUser)Resource, new Guid(TTRoleNames.Dis_Tabibi))))
            {
                if (((ResUser)Resource).SentToMHRS.HasValue && ((ResUser)Resource).SentToMHRS.Value == true)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE" && SentToMHRS == true && MHRSKesinCetvelID == null && MHRSTaslakCetvelID == null)
                    {
                        try
                        {
                            if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                                MHRSTaslakCetvelEkle();
                            else
                                MHRSTaslakCetvelEkle_V2();
                        }
                        catch (Exception ex)
                        {

                            throw new Exception(ex.Message);
                        }

                    }
                }
            }
            #endregion PreInsert
        }

        public class HbysCetvelSilmeTalep
        {
            public Int64 cetvelId { get; set; }
            public Int32 islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }

        }

        protected override void PreDelete()
        {
            #region PreDelete
            base.PreDelete();
            //planlama yapılacak kaynak tabip ya da diş tabibi değilse MHRS işlemleri yapılmasın
            if (Resource is ResUser && (ResUser.HasRole((ResUser)Resource, new Guid(TTRoleNames.Tabip)) || ResUser.HasRole((ResUser)Resource, new Guid(TTRoleNames.Dis_Tabibi))))
            {
                if (((ResUser)Resource).SentToMHRS.HasValue && ((ResUser)Resource).SentToMHRS.Value == true)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                    {
                        if (MHRSIstisnaID == null)
                        {
                            //NE Source'da scheduleForm 'a taşındı

                            //                   bool isThereAnyAppointment = false;
                            //                   BindingList<Appointment> appointmentList = Appointment.GetBySchedule(this.ObjectContext, this.ObjectID.ToString());
                            //                   foreach (Appointment appointment in appointmentList)
                            //                    {
                            //                        if (appointment.MHRSRandevuHrn != null)
                            //                            isThereAnyAppointment = true;
                            //                    }
                            //                    if (isThereAnyAppointment)
                            //                    {
                            //                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Bu planlamanızda MHRS den alınmış bir randevu bulunmaktadır. Silmek istediğinize emin misiniz?") == "H")
                            //                            throw new TTUtils.TTException("İşlemden vazgeçildi.");
                            //                    }

                            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

                            MHRSServis.KurumTaslakCetvelSilmeTalepType kurumTaslakCetvelSilme = new MHRSServis.KurumTaslakCetvelSilmeTalepType();
                            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();

                            if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                            {
                                try
                                {

                                    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(MHRSKurumKodu))
                                    {
                                        MHRSServis.KurumKesinCetvelSilmeTalepType kurumKesinCetvelSilme = new MHRSServis.KurumKesinCetvelSilmeTalepType();
                                        MHRSServis.KurumKesinCetvelSilmeCevapType kurumKesinCetvelSilmeCevap = new MHRSServis.KurumKesinCetvelSilmeCevapType();

                                        yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                                        yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                                        yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi

                                        kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(((ResUser)Resource).UniqueNo); //Convert.ToInt64(Common.CurrentResource.UniqueNo);
                                        kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                        kurumBilgileri.KurumKoduSpecified = true;
                                        kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                                        kurumKesinCetvelSilme.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                        kurumKesinCetvelSilme.KurumBilgileri = kurumBilgileri;

                                        if (MHRSKesinCetvelID != null)
                                        {

                                            if (kurumKesinCetvelSilme.KesinCetvelId == null)
                                                kurumKesinCetvelSilme.KesinCetvelId = new long[1];
                                            kurumKesinCetvelSilme.KesinCetvelId[0] = Convert.ToInt64(MHRSKesinCetvelID);

                                            kurumKesinCetvelSilmeCevap = MHRSServis.WebMethods.KurumKesinCetvelSilmeSync(Sites.SiteLocalHost, kurumKesinCetvelSilme);

                                            if (kurumKesinCetvelSilmeCevap != null && kurumKesinCetvelSilmeCevap.TemelCevapBilgileri != null)
                                            {
                                                //MHRS zaten silinmiş olan planlama için bir hata kodu dönmediğinden aşağıdaki şekilde kontrol edilmek zorunda kalındı. BB
                                                if (kurumKesinCetvelSilmeCevap.TemelCevapBilgileri.ServisBasarisi == true || (string.IsNullOrEmpty(kurumKesinCetvelSilmeCevap.TemelCevapBilgileri.Aciklama) == false
                                                    && (kurumKesinCetvelSilmeCevap.TemelCevapBilgileri.Aciklama.Contains("Üzerinde işlem yapmaya çalıştığınız cetvel daha önce silinmiştir") || kurumKesinCetvelSilmeCevap.TemelCevapBilgileri.Aciklama.Contains("Üzerinde işlem yapmaya çalıştığınız cetvel silinmiştir"))))
                                                {
                                                    MHRSKesinCetvelID = null;
                                                    string aciklama = string.Empty;
                                                    aciklama = StartTime.ToString();
                                                    aciklama += " - ";
                                                    aciklama += EndTime.ToString();
                                                    aciklama += " Randuvu planı MHRS'den başarıyla silindi.";
                                                    if (TTUtils.InfoMessageService.Instance != null)
                                                        TTUtils.InfoMessageService.Instance.ShowMessage(aciklama);

                                                    //                                    kurumTaslakCetvelSilme.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                                    //                                    kurumTaslakCetvelSilme.KurumBilgileri = kurumBilgileri;
                                                    //
                                                    //                                    if (kurumTaslakCetvelSilme.TaslakCetvelId == null)
                                                    //                                        kurumTaslakCetvelSilme.TaslakCetvelId = new long[1];
                                                    //                                    kurumTaslakCetvelSilme.TaslakCetvelId[0] = Convert.ToInt64(this.MHRSTaslakCetvelID);
                                                    //
                                                    //                                    MHRSTaslakSilme(kurumTaslakCetvelSilme);
                                                }
                                                else
                                                {
                                                    string mesaj = "MHRS Açıklama : ";
                                                    if (!String.IsNullOrEmpty(kurumKesinCetvelSilmeCevap.TemelCevapBilgileri.Aciklama))
                                                        mesaj += kurumKesinCetvelSilmeCevap.TemelCevapBilgileri.Aciklama;
                                                    mesaj += "\r\n MHRS den planlama Silinemediği için Randevu Planınınızı Silemezsiniz !";
                                                    throw new TTUtils.TTException(mesaj);
                                                }
                                            }
                                        }

                                        if (MHRSKesinCetvelID == null && MHRSTaslakCetvelID != null)
                                        {
                                            kurumTaslakCetvelSilme.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                            kurumTaslakCetvelSilme.KurumBilgileri = kurumBilgileri;

                                            if (kurumTaslakCetvelSilme.TaslakCetvelId == null)
                                                kurumTaslakCetvelSilme.TaslakCetvelId = new long[1];
                                            kurumTaslakCetvelSilme.TaslakCetvelId[0] = Convert.ToInt64(MHRSTaslakCetvelID);

                                            MHRSTaslakSilme(kurumTaslakCetvelSilme);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                            else
                            {
                                if (MHRSKesinCetvelID == null && MHRSTaslakCetvelID != null)
                                {

                                    string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                                    HbysCetvelSilmeTalep hbysCetvelSilmeTalep = new HbysCetvelSilmeTalep();
                                    hbysCetvelSilmeTalep.cetvelId = Convert.ToInt64(MHRSTaslakCetvelID);
                                    hbysCetvelSilmeTalep.islemYapanTcKimlikNo = Convert.ToInt64(((ResUser)Resource).UniqueNo);
                                    hbysCetvelSilmeTalep.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);

                                    string serializedObj = JsonConvert.SerializeObject(hbysCetvelSilmeTalep);


                                    string accessToken = LoginForMHRS();

                                    Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/cetvel");

                                    var client = new RestClient(uri);

                                    RestRequest request = new RestRequest();
                                    request.Method = Method.DELETE;
                                    request.Parameters.Clear();

                                    string bearerToken = "Bearer " + accessToken;
                                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                                    request.AddHeader("Accept", "application/json");
                                    request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);


                                    //IRestResponse response = client.Execute(request);
                                    IRestResponse response = PostCallForMHRS(client, request);

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
                                            //var detailedError = errorObject.Value<string>("message");
                                            //errorMessage = error.ToString();
                                        }
                                        throw new TTException(detailedError);
                                    }

                                    if (response.IsSuccessful)
                                    {
                                        var perfResult = JsonConvert.DeserializeObject<MHRS_TASLAK_ROOT>(response.Content);
                                        //MHRSTaslakCetvelID = kurumTaslakCetvelEkleCevap.TaslakCetvelCevap != null && kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId != null && kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId.Length > 0 ? kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId[0].ToString() : null;
                                        //MHRSTaslakCetvelID = perfResult.data.Count > 0 ? perfResult.data[0].cetvelId : null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion PreDelete
        }

        #region Methods
        public bool MHRSTaslakKesinlestirme(MHRSServis.KurumTaslakCetvelKesinlestirmeTalepType kurumTaslakCetvelKesinlestirme)
        {

            //kurumTaslakCetvelKesinlestirmeCevap = MHRSServis.WebMethods.KurumTaslakCetvelKesinlestirmeSync(Sites.SiteLocalHost, kurumTaslakCetvelKesinlestirme);
            return true;
        }
        public void MHRSTaslakSilme(MHRSServis.KurumTaslakCetvelSilmeTalepType kurumTaslakCetvelSilme)
        {
            MHRSServis.KurumTaslakCetvelSilmeCevapType kurumTaslakCetvelSilmeCevap = new MHRSServis.KurumTaslakCetvelSilmeCevapType();

            kurumTaslakCetvelSilmeCevap = MHRSServis.WebMethods.KurumTaslakCetvelSilmeSync(Sites.SiteLocalHost, kurumTaslakCetvelSilme);

            if (kurumTaslakCetvelSilmeCevap != null && kurumTaslakCetvelSilmeCevap.TemelCevapBilgileri != null)
            {
                //MHRS zaten silinmiş olan planlama için bir hata kodu dönmediğinden aşağıdaki şekilde kontrol edilmek zorunda kalındı. BB
                if (kurumTaslakCetvelSilmeCevap.TemelCevapBilgileri.ServisBasarisi == true || (string.IsNullOrEmpty(kurumTaslakCetvelSilmeCevap.TemelCevapBilgileri.Aciklama) == false 
                    && (kurumTaslakCetvelSilmeCevap.TemelCevapBilgileri.Aciklama.Contains("Üzerinde işlem yapmaya çalıştığınız cetvel daha önce silinmiştir") || kurumTaslakCetvelSilmeCevap.TemelCevapBilgileri.Aciklama.Contains("Üzerinde işlem yapmaya çalıştığınız cetvel silinmiştir"))))
                {
                    MHRSTaslakCetvelID = null;
                }
                else
                {
                    throw new TTException("MHRS den planlama Silinemediği için Randevu Planınınızı Silemezsiniz ! MHRS Açıklama :" + kurumTaslakCetvelSilmeCevap.TemelCevapBilgileri.Aciklama);
                }
            }
        }

        public void MHRSTaslakCetvelEkle()
        {
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

            MHRSServis.KurumTaslakCetvelEklemeTalepType kurumTaslakCetvelEkle = new MHRSServis.KurumTaslakCetvelEklemeTalepType();
            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
            MHRSServis.TaslakCetvelBilgileriType taslakCetvelBilgileri = new MHRSServis.TaslakCetvelBilgileriType();
            MHRSServis.CetvelDetayBilgileriType cetvelDetayBilgileri = new MHRSServis.CetvelDetayBilgileriType();
            MHRSServis.HekimKlinikBilgileriType hekimKlinikBilgileri = new MHRSServis.HekimKlinikBilgileriType();
            MHRSServis.HekimBilgileriType hekimBilgileri = new MHRSServis.HekimBilgileriType();
            MHRSServis.AltKlinikBilgileriType altKlinikBilgileri = new MHRSServis.AltKlinikBilgileriType();
            MHRSServis.TarihBilgileriType tarihBilgileri = new MHRSServis.TarihBilgileriType();
            MHRSServis.KurumTaslakCetvelEklemeCevapType kurumTaslakCetvelEkleCevap = new MHRSServis.KurumTaslakCetvelEklemeCevapType();


            try
            {
                if (userName != null && password != null && MHRSKurumKodu != null)
                {
                    yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                    yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                    yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi
                    kurumTaslakCetvelEkle.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;

                    if (MasterResource is ResPoliclinic)
                    {
                        hekimKlinikBilgileri.KlinikKodu = ((ResPoliclinic)MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSCode) : 0;
                        hekimKlinikBilgileri.KlinikAdi = ((ResPoliclinic)MasterResource).Name;
                        altKlinikBilgileri.AltKlinikKodu = ((ResPoliclinic)MasterResource).MHRSAltKlinikKodu != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSAltKlinikKodu) : 0;
                        hekimKlinikBilgileri.AltKlinikBilgileri = altKlinikBilgileri;
                    }

                    if (Resource is ResUser)
                    {
                        hekimBilgileri.Ad = Resource.Name;
                        hekimBilgileri.Soyad = ((ResUser)Resource).Person.Surname;
                        hekimBilgileri.HekimKodu = ((ResUser)Resource).UniqueNo;
                        hekimKlinikBilgileri.HekimBilgileri = hekimBilgileri;

                        kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(((ResUser)Resource).UniqueNo);
                    }

                    kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                    kurumBilgileri.KurumKoduSpecified = true;
                    kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                    kurumTaslakCetvelEkle.KurumBilgileri = kurumBilgileri;

                    tarihBilgileri.BaslangicTarihi = StartTime.ToString();
                    tarihBilgileri.BitisTarihi = EndTime.ToString();
                    cetvelDetayBilgileri.TarihBilgileri = tarihBilgileri;

                    cetvelDetayBilgileri.AksiyonKodu = MHRSActionTypeDefinition != null ? Convert.ToInt32(MHRSActionTypeDefinition.ActionCode) : 0;
                    cetvelDetayBilgileri.HekimKlinikBilgileri = hekimKlinikBilgileri;
                    cetvelDetayBilgileri.TedaviSuresi = Duration != null ? Convert.ToInt32(Duration) : 0;
                    cetvelDetayBilgileri.TedaviSuresiSpecified = true;
                    cetvelDetayBilgileri.SlotBasinaDusenHastaSayisi = 1;
                    cetvelDetayBilgileri.SlotBasinaDusenHastaSayisiSpecified = true;

                    taslakCetvelBilgileri.CetvelDetayBilgileri = cetvelDetayBilgileri;
                    taslakCetvelBilgileri.ReferansNo = ObjectID.ToString();

                    if (kurumTaslakCetvelEkle.TaslakCetvelBilgileri == null)
                        kurumTaslakCetvelEkle.TaslakCetvelBilgileri = new MHRSServis.TaslakCetvelBilgileriType[1];

                    kurumTaslakCetvelEkle.TaslakCetvelBilgileri[0] = taslakCetvelBilgileri;

                    kurumTaslakCetvelEkleCevap = MHRSServis.WebMethods.KurumTaslakCetvelEklemeSync(Sites.SiteLocalHost, kurumTaslakCetvelEkle);

                    if (kurumTaslakCetvelEkleCevap != null && kurumTaslakCetvelEkleCevap.TemelCevapBilgileri != null)
                    {
                        if (kurumTaslakCetvelEkleCevap.TemelCevapBilgileri.ServisBasarisi == true)
                        {
                            MHRSTaslakCetvelID = kurumTaslakCetvelEkleCevap.TaslakCetvelCevap != null && kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId != null && kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId.Length > 0 ? kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId[0].ToString() : null;
                            //Cetvele özel iş kuralı tanımlamak için MHRS tarafında bir servis mevcut değilmiş. KurumIsKuralıEkleme servisi bu işi yapmıyor. Aşağıdaki kod servis açtıklarında değiştirilecek. Parametrenin değeri şu anda FALSE olduğu için aşağıdaki koda zaten girmeyecek.
                            if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("MHRSISKURALIEKLEME", "FALSE")))
                            {
                                if (ScheduleJobRules != null && ScheduleJobRules.Count > 0)
                                {
                                    MHRSServis.IsKuraliTipiType isKuraliTipi = new MHRSServis.IsKuraliTipiType();
                                    MHRSServis.KurumIsKuraliEklemeTalepType kurumIsKuraliEklemeTalep = new MHRSServis.KurumIsKuraliEklemeTalepType();
                                    MHRSServis.KurumIsKuraliEklemeCevapType kurumIsKuraliEklemeCevap = new MHRSServis.KurumIsKuraliEklemeCevapType();
                                    foreach (ScheduleJobRule scheduleJobRule in ScheduleJobRules)
                                    {
                                        kurumIsKuraliEklemeTalep.KurumBilgileri = kurumBilgileri;
                                        kurumIsKuraliEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                        kurumIsKuraliEklemeTalep.KlinikKodu = ((ResPoliclinic)MasterResource).MHRSAltKlinikKodu != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSAltKlinikKodu) : 0; //((ResPoliclinic)this.MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)this.MasterResource).MHRSCode) : 0;
                                        kurumIsKuraliEklemeTalep.HekimKodu = ((ResUser)Resource).UniqueNo;
                                        if (scheduleJobRule.RuleType.HasValue)
                                            kurumIsKuraliEklemeTalep.IsKuraliTipiKodu = Common.GetEnumValueDefOfEnumValue(scheduleJobRule.RuleType.Value).Value;
                                        if (scheduleJobRule.TimeCriteria.HasValue)
                                            kurumIsKuraliEklemeTalep.ZamanKriteri = Common.GetEnumValueDefOfEnumValue(scheduleJobRule.TimeCriteria.Value).Value;
                                        if (scheduleJobRule.RuleValue.HasValue)
                                            kurumIsKuraliEklemeTalep.Deger = scheduleJobRule.RuleValue.Value.ToString();
                                        kurumIsKuraliEklemeCevap = MHRSServis.WebMethods.KurumIsKuraliEklemeSync(Sites.SiteLocalHost, kurumIsKuraliEklemeTalep);
                                        if (kurumIsKuraliEklemeCevap != null && kurumIsKuraliEklemeCevap.TemelCevapBilgileri != null)
                                        {
                                            if (kurumIsKuraliEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                            {
                                                scheduleJobRule.IsKuraliId = kurumIsKuraliEklemeCevap.IsKuraliId;
                                            }
                                            else
                                            {
                                                string hata = string.Empty;
                                                hata = kurumIsKuraliEklemeCevap.TemelCevapBilgileri != null ? kurumIsKuraliEklemeCevap.TemelCevapBilgileri.Aciklama : null;
                                                throw new TTException("MHRS Bildirim Hatası : " + hata);
                                            }
                                        }
                                    }
                                }
                            }
                            //string aciklama = string.Empty;
                            //aciklama =  tarihBilgileri.BaslangicTarihi;
                            //aciklama += " - ";
                            //aciklama +=  tarihBilgileri.BitisTarihi;
                            //aciklama += " Randuvu planı MHRS'ye başarıyla bildirildi.";
                            //TTUtils.InfoMessageService.Instance.ShowMessage(aciklama);
                            //InfoBox.Alert(aciklama);
                        }
                        else if (kurumTaslakCetvelEkleCevap.TemelCevapBilgileri != null)
                        {
                            string hata = string.Empty;
                            hata = kurumTaslakCetvelEkleCevap.TemelCevapBilgileri != null ? kurumTaslakCetvelEkleCevap.TemelCevapBilgileri.Aciklama : null;

                            if (kurumTaslakCetvelEkleCevap.TaslakCetvelCevap != null)
                            {
                                for (int i = 0; i < kurumTaslakCetvelEkleCevap.TaslakCetvelCevap.Length; i++)
                                    hata += kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[i].Aciklama;
                            }
                            // TTUtils.InfoMessageService.Instance.ShowMessage("MHRS Bildirim Hatası : " + hata);
                            throw new TTException("MHRS Bildirim Hatası : " + hata);
                        }
                    }
                    else
                        throw new TTException("MHRS'ye bildirilirken hata oluştu !");
                }
            }
            catch (Exception ex)
            {
                // InfoBox.Alert(ex);
                throw;
            }
        }

        public bool MHRSIstisnaEkle(string email, string istisnaAciklama, MHRSServis.IstisnaDokumanType istisnaDokuman, MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri, Schedule schedule, MHRSActionTypeDefinition actionType)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "TRUE")
            {
                return MHRSIstisnaEkle_V2(email, istisnaAciklama, istisnaDokuman, telefonIletisimBilgileri, schedule, actionType);
            }
            else
            {
                return MHRSIstisnaEkle_Old(email, istisnaAciklama, istisnaDokuman, telefonIletisimBilgileri, schedule, actionType);
            }
        }

        public bool MHRSIstisnaEkle_Old(string email, string istisnaAciklama, MHRSServis.IstisnaDokumanType istisnaDokuman, MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri, Schedule schedule, MHRSActionTypeDefinition actionType)
        {
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();

            yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
            yetkilendirmeGirisBilgileri.KullaniciSifre = password;
            yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi

            kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
            kurumBilgileri.KurumKoduSpecified = true;
            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

            MHRSServis.KurumIstisnaEklemeTalepType kurumIstisnaEklemeTalep = new MHRSServis.KurumIstisnaEklemeTalepType();
            MHRSServis.KurumIstisnaEklemeCevapType kurumIstisnaEklemeCevap = new MHRSServis.KurumIstisnaEklemeCevapType();
            MHRSServis.TarihBilgileriType tarihBilgileri = new MHRSServis.TarihBilgileriType();

            kurumIstisnaEklemeTalep.KurumBilgileri = kurumBilgileri;
            kurumIstisnaEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
            if (Resource is ResUser)
                kurumIstisnaEklemeTalep.HekimKodu = ((ResUser)schedule.Resource).UniqueNo;
            if (MasterResource is ResPoliclinic)
                kurumIstisnaEklemeTalep.KlinikKodu = ((ResPoliclinic)schedule.MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)schedule.MasterResource).MHRSCode) : 0;
            kurumIstisnaEklemeTalep.AksiyonKodu = actionType != null ? Convert.ToInt32(actionType.ActionCode) : 0;
            kurumIstisnaEklemeTalep.Email = email;
            kurumIstisnaEklemeTalep.Aciklama = istisnaAciklama;
            kurumIstisnaEklemeTalep.TelefonIletisimBilgileri = telefonIletisimBilgileri;
            kurumIstisnaEklemeTalep.IstisnaDokumanBilgileri = istisnaDokuman;
            tarihBilgileri.BaslangicTarihi = schedule.StartTime.ToString();
            tarihBilgileri.BitisTarihi = schedule.EndTime.ToString();
            kurumIstisnaEklemeTalep.TarihBilgileri = tarihBilgileri;

            kurumIstisnaEklemeCevap = MHRSServis.WebMethods.KurumIstisnaEklemeSync(Sites.SiteLocalHost, kurumIstisnaEklemeTalep);

            if (kurumIstisnaEklemeCevap != null && kurumIstisnaEklemeCevap.TemelCevapBilgileri != null)
            {
                if (kurumIstisnaEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                {
                    foreach (MHRSServis.IstisnaDetayBilgileriType istisnaDetayBilgileri in kurumIstisnaEklemeCevap.IstisnaDetayBilgileri)
                    {
                        MHRSIstisnaID = istisnaDetayBilgileri.IstisnaId;
                    }

                    string aciklama = string.Empty;
                    aciklama = StartTime.ToString();
                    aciklama += " - ";
                    aciklama += EndTime.ToString();
                    aciklama += " İstisna durumu MHRS'ye başarıyla bildirildi.";
                    TTUtils.InfoMessageService.Instance.ShowMessage(aciklama);
                    return true;
                }
                else
                {
                    string mesaj = "MHRS Açıklama : ";
                    mesaj += kurumIstisnaEklemeCevap.TemelCevapBilgileri.Aciklama;
                    TTUtils.InfoMessageService.Instance.ShowMessage(mesaj);
                    return false;
                }
                //return false;
            }
            return false;
        }

        public bool isRemovable()
        {
            BindingList<Appointment.GetAppointmentBySchedule_Class> appointmentsWithSch = Appointment.GetAppointmentBySchedule(ObjectContext, ObjectID);
            if (appointmentsWithSch.Count > 0)
            {
                foreach (Appointment.GetAppointmentBySchedule_Class appSch_Class in appointmentsWithSch)
                {
                    Appointment appSch = (Appointment)ObjectContext.GetObject(appSch_Class.ObjectID.Value, typeof(Appointment));
                    if (appSch.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        throw new Exception("Personelin izin almak istediği tarih aralığında randevusu mevcut. Randevu ObjID : " + appSch.ObjectID.ToString());
                    }
                }
            }

            if (MHRSKesinCetvelID != null || MHRSTaslakCetvelID != null)
                SentToMHRS = true;
            if (MHRSKesinCetvelID != null && MHRSScheduleType != MHRSScheduleTypeEnum.WaitingApproval)
            {
                int istisnasuresi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSISTISNASURESI", "0"));
                if (Convert.ToDateTime(StartTime).AddHours(-istisnasuresi) <= DateTime.Now)
                {
                    if (MHRSActionTypeDefinition != null && MHRSActionTypeDefinition.OpenMHRS == true)
                    {
                        //TODO Necmiye
                        //InfoBox.Show("Silinmek istenen planlamaya " + istisnasuresi + " saatten az kaldığı için plan silinemez! İstisna bildirmek için bilgilerinizi giriniz");
                        if (appointmentsWithSch.Count > 0)
                            throw new Exception("Silinmek istenen planlamaya " + istisnasuresi + " saatten az kaldığı için plan silinemez! İstisna bildirmek için bilgilerinizi giriniz. Planlama ObjID : " + ObjectID.ToString());
                        //MHRSExceptionalForm mHRSExceptionalForm = MHRSExceptionalForm.MHRSExceptionalFormInstance;
                        //DialogResult result = mHRSExceptionalForm.ShowDialog(this, delSch, objectContext);
                    }
                }
            }

            if (MHRSScheduleType == MHRSScheduleTypeEnum.WaitingApproval)
            {
                if (appointmentsWithSch.Count > 0)
                    throw new Exception("Personelin izin almak istediği tarih aralığında randevusu mevcut");
            }
            return true;
        }

        public static void CreateScheduleForNonWorkingHour(DateTime startDateTime, DateTime endDateTime,MHRSActionTypeDefinition MHRSActionType, Resource resUser)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                int dayCount = endDateTime.Subtract(startDateTime).Days;
                int i = 0;
                while (i <= dayCount)
                {
                    Schedule sch = new Schedule(context);
                    sch.ScheduleDate = startDateTime.Date.AddDays(i);
                    sch.StartTime = startDateTime.AddDays(i);
                    if (startDateTime.Hour < 6)
                        sch.StartTime = new DateTime(sch.StartTime.Value.Year, sch.StartTime.Value.Month, sch.StartTime.Value.Day, 06, 00, 00);

                    if (dayCount == 0 || i == dayCount)
                        sch.EndTime = endDateTime.AddDays(i);
                    else
                        sch.EndTime = new DateTime(sch.StartTime.Value.Year, sch.StartTime.Value.Month, sch.StartTime.Value.Day, 23, 59, 59);
                    sch.CountLimit = null;
                    sch.Duration = 0;
                    sch.ScheduleType = ScheduleTypeEnum.NonWorkingHour;
                    sch.IsWorkHour = false;
                    sch.Notes = "Personel sisteminden gelen izin talebi ile oluşturulmuştur.";
                    sch.Resource = resUser;
                    sch.MasterResource = null;
                    //planlama yapılacak kaynak tabip ya da diş tabibi değilse MHRS işlemleri yapılmasın
                    if (sch.Resource is ResUser && (ResUser.HasRole((ResUser)sch.Resource, new Guid(TTRoleNames.Tabip)) || ResUser.HasRole((ResUser)sch.Resource, new Guid(TTRoleNames.Dis_Tabibi))))
                        if (((ResUser)sch.Resource).SentToMHRS.HasValue && ((ResUser)sch.Resource).SentToMHRS.Value == true)
                            sch.SentToMHRS = true;
                        else
                            sch.SentToMHRS = false;
                    else
                        sch.SentToMHRS = false;
                    sch.AppointmentDefinition = context.GetObject<AppointmentDefinition>(new Guid(SystemParameter.GetParameterValue("POLICLINICAPPOINTMENTOBJID", "655918ef-ca8e-4b7f-81b0-35262639e6fe")));
                    //Kullanıcının  bağlı olduğu polikliklerden ilki MasterResource olarak set edilir.
                    BindingList<UserResource> userResources = UserResource.GetByUser(context, resUser.ObjectID);
                    foreach (UserResource userResource in userResources)
                    {
                        if (userResource.Resource != null && userResource.Resource is ResPoliclinic)
                        {
                            sch.MasterResource = userResource.Resource;
                            break;
                        }
                    }
                    if (MHRSActionType != null)
                        sch.MHRSActionTypeDefinition = MHRSActionType;
                    else
                        //TODO: MHRSActionTypeDefinition personel sisteminden alınabiliyor mu diye araştırılacak. Şimdilik Yıllık İzin gönderiliyor.
                        sch.MHRSActionTypeDefinition = context.GetObject<MHRSActionTypeDefinition>(new Guid(SystemParameter.GetParameterValue("MHRSACTIONTYPEYILLIKIZINOBJID", "45b7f588-7a5f-49e2-b253-dd9765520384")));
                    sch.MHRSScheduleType = MHRSScheduleTypeEnum.WaitingApproval;
                    i++;
                }
                context.Save();
            }
        }

        #region MHRS_V2

        private readonly object _tokenLock = new object();
        //public AuthTokenData _authTokenData;

        public string LoginForMHRS(bool? getNewToken = null)
        {
            lock (_tokenLock)
            {
                using (var objectContext = new TTObjectContext(false))
                {

                    var MHRSToken = objectContext.QueryObjects<SystemParameter>("NAME='MHRSTOKEN'"); //SystemParameter.GetParameterValue("VADEMECUMTOKEN", string.Empty);
                    if (getNewToken != true && MHRSToken.Count > 0 && string.IsNullOrWhiteSpace(MHRSToken.FirstOrDefault().Value) == false)
                    {
                        string authTokenData = (MHRSToken.FirstOrDefault().Value);
                        // veri tabanında var ama expire olmuş olabilir
                        if (TokenExpired(authTokenData) == false)
                        {
                            //_authTokenData = authTokenData;
                            return authTokenData;
                        }
                    }

                    var tokenSystemParameter = MHRSToken.FirstOrDefault();
                    if (tokenSystemParameter == null)
                    {
                        tokenSystemParameter = new SystemParameter(objectContext);
                        tokenSystemParameter.Name = "MHRSTOKEN";
                    }

                    string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                    Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/login");

                    var client = new RestClient(uri);

                    MHRS_Login_Input login = new MHRS_Login_Input();
                    login.kullaniciAdi = Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX"));
                    login.parola = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                    login.kurumKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX"));
                    login.uygulamaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");


                    var request = new RestSharp.RestRequest();
                    request.Method = Method.POST;

                    request.AddJsonBody(login);
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
                        else if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                        {
                            throw new TTException("'Servis Geçici Olarak Hizmet Dışı' olduğu için işleme devam edilemiyor");
                        }
                    }

                    if (response.IsSuccessful)
                    {
                        LoginRoot tokenResponse = JsonConvert.DeserializeObject<LoginRoot>(response.Content);

                        tokenSystemParameter.Value = tokenResponse.data.jwt;
                        tokenSystemParameter.Description = "Token Alma Zamanı =" + DateTime.Now.ToString();
                        tokenSystemParameter.SubType = SystemParameterSubTypeEnum.System;//sistem parametresi
                        objectContext.Save();

                        return tokenResponse.data.jwt;
                    }
                    else
                    {
                        LoginRoot tokenResponse = JsonConvert.DeserializeObject<LoginRoot>(response.Content);

                        string errorMessage = string.Empty;

                        if (tokenResponse.errors != null)
                        {
                            if (tokenResponse.errors.Count == 1)
                            {
                                throw new Exception(tokenResponse.errors[0].ToString());
                            }
                            else
                            {
                                foreach (var error in tokenResponse.errors)
                                {
                                    errorMessage += error + "\n";
                                }

                                throw new Exception(errorMessage);
                            }
                        }
                        else
                            throw new Exception("Token Alınamadı");

                    }
                }
            }
        }

        public IRestResponse PostCallForMHRS(RestClient client, RestRequest request)
        {
            // POSTMAN gibi dış bir program ile login olunduğu zaman VT'de kayıtlı token geçersiz oluyor
            // bu yüzden eğer unauthorized hatası alınır ise tekrar login olup yeni token ile tekrar deneniyor

            IRestResponse response = client.Execute(request);

            if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                string accessToken = LoginForMHRS(true);

                string bearerToken = "Bearer " + accessToken;

                if (request.Parameters.Any(param => param.Name == "Authorization"))
                {
                    var parameter = request.Parameters.First(param => param.Name == "Authorization");
                    request.Parameters.Remove(parameter);
                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                }

                response = client.Execute(request);

            }
                return response;
        }

        public long GetExpDateFromToken(string _token)
        {
            string a = _token.Split('.')[1];
                //tokenResponse.data.jwt.Substring(tokenResponse.data.jwt.IndexOf('.') + 1, tokenResponse.data.jwt.Length - tokenResponse.data.jwt.IndexOf('.') - 1);
            a += "==";

            byte[] data = Convert.FromBase64String(a);
            string decodedString = Encoding.UTF8.GetString(data);

            var jObject = JsonConvert.DeserializeObject(decodedString) as JObject;

            long expdate = jObject.Value<long>("exp");
            return expdate;
        }

        public bool TokenExpired(string _token)
        {
            long unixTimeStamp = GetExpDateFromToken(_token);

            DateTime tokenExpiryDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            tokenExpiryDateTime = tokenExpiryDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            DateTime currentDateTime = DateTime.Now;
            return DateTime.Compare(tokenExpiryDateTime, currentDateTime) <= 0;
        }

        public void MHRSTaslakCetvelEkle_V2()
        {
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

            MHRS_TASLAK_CETVEL_INPUT mHRS_TASLAK = new MHRS_TASLAK_CETVEL_INPUT();

            mHRS_TASLAK.aksiyonId = MHRSActionTypeDefinition != null ? Convert.ToInt32(MHRSActionTypeDefinition.ActionCode) : 0;
            mHRS_TASLAK.baslangicZamani = StartTime.HasValue ? StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
            mHRS_TASLAK.bitisZamani = EndTime.HasValue ? EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";

            if (CetvelTipiValue.HasValue && CetvelTipiValue.Value == CetvelTipiEnum.Bolum)
            {
                mHRS_TASLAK.cetvelTipi = 2;//bölüm
                mHRS_TASLAK.hekimTcKimlikNo = null;
            }
            else
            {
                mHRS_TASLAK.cetvelTipi = 1;//doktor

                if (Resource is ResUser)
                {
                    mHRS_TASLAK.hekimTcKimlikNo = Convert.ToInt64(((ResUser)Resource).UniqueNo);
                }

            }

            mHRS_TASLAK.randevuSuresi = Duration != null ? Convert.ToInt32(Duration) : 0;
            
            mHRS_TASLAK.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
            mHRS_TASLAK.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);


            if (MHRSActionTypeDefinition != null && MHRSActionTypeDefinition.OpenMHRS == false)
            {
                if (MasterResource is ResPoliclinic)
                {
                    mHRS_TASLAK.klinikKodu = ((ResPoliclinic)MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSCode) : 0;
                    if(mHRS_TASLAK.cetvelTipi == 1) //doktor
                        mHRS_TASLAK.muayeneYeriId = null;
                    else
                        mHRS_TASLAK.muayeneYeriId = ((ResPoliclinic)MasterResource).MHRSAltKlinikKodu != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSAltKlinikKodu) : 0;
                }

                mHRS_TASLAK.slotHastaSayisi = 0;
                mHRS_TASLAK.enKucukYas = null;
                mHRS_TASLAK.enBuyukYas = null;

            }
            else
            {
                mHRS_TASLAK.enBuyukYasTipi = "Y";
                mHRS_TASLAK.enKucukYasTipi = "Y";
                mHRS_TASLAK.enKucukYas = 1;
                mHRS_TASLAK.enBuyukYas = 120;
                mHRS_TASLAK.slotHastaSayisi = 1;

                if (MasterResource is ResPoliclinic)
                {
                    mHRS_TASLAK.klinikKodu = ((ResPoliclinic)MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSCode) : 0;
                    //hekimKlinikBilgileri.KlinikAdi = ((ResPoliclinic)MasterResource).Name;
                    mHRS_TASLAK.muayeneYeriId = ((ResPoliclinic)MasterResource).MHRSAltKlinikKodu != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSAltKlinikKodu) : 0;
                    //hekimKlinikBilgileri.AltKlinikBilgileri = altKlinikBilgileri;
                }


            }


            string serializedObj = JsonConvert.SerializeObject(mHRS_TASLAK,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});


            string accessToken = LoginForMHRS();

            Uri uri = new Uri("https://"+ MHRSBASEURL + "/api/rs/hbys/cetvel/ekle");

            var client = new RestClient(uri);

            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            request.Parameters.Clear();

            string bearerToken = "Bearer " + accessToken;
            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);


            //IRestResponse response = client.Execute(request);
            IRestResponse response = PostCallForMHRS(client, request);

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
                    //var detailedError = errorObject.Value<string>("message");
                    //errorMessage = error.ToString();
                }
                throw new TTException(detailedError);
            }

            if (response.IsSuccessful)
            {
                var perfResult = JsonConvert.DeserializeObject<MHRS_TASLAK_ROOT>(response.Content);
                //MHRSTaslakCetvelID = kurumTaslakCetvelEkleCevap.TaslakCetvelCevap != null && kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId != null && kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId.Length > 0 ? kurumTaslakCetvelEkleCevap.TaslakCetvelCevap[0].TaslakCetvelId[0].ToString() : null;
                MHRSTaslakCetvelID = perfResult.data.Count > 0 ? perfResult.data[0].cetvelId : null;
            }

        }

        public bool MHRSIstisnaEkle_V2(string email, string istisnaAciklama, MHRSServis.IstisnaDokumanType istisnaDokuman, MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri, Schedule schedule, MHRSActionTypeDefinition actionType)
        {
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

            string accessToken = LoginForMHRS();

            string url = "https://" + MHRSBASEURL + "/api/rs/hbys/istisna";

            MHRS_ISTISNA_INPUT istisna_input = new MHRS_ISTISNA_INPUT();
            //HttpWebRequest

            istisna_input.aciklama = istisnaAciklama;
            istisna_input.aksiyonId = actionType != null ? Convert.ToInt32(actionType.ActionCode) : 0;
            istisna_input.baslangicTarihSaati = schedule.StartTime.ToString();
            istisna_input.bitisTarihSaati = schedule.EndTime.ToString();
            istisna_input.cetvelTipi = 1;
            istisna_input.eposta = email;
            if (Resource is ResUser)
                istisna_input.hekimTcKimlikNoList =((ResUser)schedule.Resource).UniqueNo;

            #region bilo

            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
            var bearerToken = $"Bearer {accessToken}";
            httpClient.DefaultRequestHeaders.Add("Authorization", bearerToken);

            int aksiyonId = actionType != null ? Convert.ToInt32(actionType.ActionCode) : 0;

            form.Add(new StringContent(istisnaAciklama), "aciklama");
            form.Add(new StringContent(aksiyonId.ToString()), "aksiyonId");
            form.Add(new StringContent(schedule.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss")), "baslangicTarihSaati");
            form.Add(new StringContent(schedule.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss")), "bitisTarihSaati");

            if (schedule.CetvelTipiValue == CetvelTipiEnum.Bolum)
            {
                form.Add(new StringContent("2"), "cetvelTipi");
                int muayeneYeriId = ((ResPoliclinic)schedule.MasterResource).MHRSAltKlinikKodu != null ? Convert.ToInt32(((ResPoliclinic)schedule.MasterResource).MHRSAltKlinikKodu) : 0;
                form.Add(new StringContent(muayeneYeriId.ToString()), "muayeneYeriIdList");
            }
            else
            {
                form.Add(new StringContent("1"), "cetvelTipi");
                form.Add(new StringContent("-1"), "muayeneYeriIdList");
                if (Resource is ResUser)
                    form.Add(new StringContent(((ResUser)schedule.Resource).UniqueNo), "hekimTcKimlikNoList");
            }
            
            form.Add(new StringContent(email), "eposta");

            form.Add(new StringContent(Common.CurrentResource.UniqueNo), "islemYapanTcKimlikNo");
            form.Add(new StringContent(MHRSKurumKodu), "islemYapilanKurumKodu");
            form.Add(new StringContent(istisnaDokuman.IstisnaDokumanAdi), "istisnaBelgeAdi");
            form.Add(new ByteArrayContent(istisnaDokuman.IstisnaDokuman, 0, istisnaDokuman.IstisnaDokuman.Length), "istisnaBelgesi", istisnaDokuman.IstisnaDokumanAdi);

            if (MasterResource is ResPoliclinic)
            {
                int klinikkodu = ((ResPoliclinic)schedule.MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)schedule.MasterResource).MHRSCode) : 0;
                form.Add(new StringContent(klinikkodu.ToString()), "klinikKodu");
            }
                
            
            form.Add(new StringContent(telefonIletisimBilgileri.AlanKodu + "" + telefonIletisimBilgileri.TelefonNo), "telefonNo");

            HttpResponseMessage response = httpClient.PostAsync(url, form).GetAwaiter().GetResult(); 

            httpClient.Dispose();
            //string result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                MHRS_ISTISNA_OUTPUT responseMessage = JsonConvert.DeserializeObject<MHRS_ISTISNA_OUTPUT>(result);
                
                MHRSIstisnaID = responseMessage.istisnaId;

                string aciklama = string.Empty;
                aciklama = StartTime.ToString();
                aciklama += " - ";
                aciklama += EndTime.ToString();
                aciklama += " İstisna durumu MHRS'ye başarıyla bildirildi.";
                TTUtils.InfoMessageService.Instance.ShowMessage(aciklama);

                return true;

            }
            else
            {
                //var errorMessage = response.Content;
                string result = response.Content.ReadAsStringAsync().Result;
                var errorObject = JsonConvert.DeserializeObject(result) as JObject;
                string detailedError = "";

                if (errorObject != null)
                {
                    var error = errorObject.Value<JArray>("errors");

                    foreach (Newtonsoft.Json.Linq.JObject item in error)
                    {
                        detailedError += item.ToString();
                    }
                    //var detailedError = errorObject.Value<string>("message");
                    //errorMessage = error.ToString();
                }
                throw new TTException(detailedError);
                //TTUtils.InfoMessageService.Instance.ShowMessage(detailedError);

            }
            #endregion

            #region iso
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            //parameters.Add("aciklama", istisnaAciklama);
            //parameters.Add("FullName", FullName);
            //parameters.Add("Phone", Phone);
            //parameters.Add("CNIC", CNIC);
            //parameters.Add("address", address);
            //parameters.Add("Email", Email);
            //parameters.Add("dateofbirth", dateofbirth.ToShortDateString());
            //parameters.Add("Gender", Gender);
            //parameters.Add("PaymentMethod", PaymentMethod);
            //parameters.Add("Title", Title);
            //parameters.Add("PhramaList", medList);



            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44391/");
            //MultipartFormDataContent form = new MultipartFormDataContent();
            //HttpContent content = new StringContent("fileToUpload");
            //HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
            //form.Add(content, "fileToUpload");
            //form.Add(DictionaryItems, "medicineOrder");
            //var stream = PostedPrescription.InputStream;
            //content = new StreamContent(stream);
            //content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            //{
            //    Name = "fileToUpload",
            //    FileName = PostedPrescription.FileName
            //};
            //form.Add(content);

            //var response = await client.PostAsync("/api/Payment/AddMedicineOrder", form);
            //var k = response.Content.ReadAsStringAsync().Result;
            #endregion


            //using (var httpClient = new System.Net.Http.HttpClient())
            //{
            //    using (var form = new System.Net.Http.MultipartFormDataContent())
            //    {
            //        using (var fileContent = new System.Net.Http.ByteArrayContent(istisnaDokuman.IstisnaDokuman))
            //        {
            //            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            //            // "file" parameter name should be the same as the server side input parameter name
            //            form.Add(fileContent, "file", istisnaDokuman.IstisnaDokumanAdi);
            //            HttpResponseMessage response =  httpClient.PostAsync(url, form).GetAwaiter().GetResult();

            //        }
            //    }
            //}


            return false;

        }


        public void UpdateInsertMHRSActionType()
        {
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

            string accessToken = LoginForMHRS();

            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/cetvel/aksiyon-bilgileri");

            var client = new RestClient(uri);

            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.Parameters.Clear();

            string bearerToken = "Bearer " + accessToken;
            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
            request.AddHeader("Accept", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var perfResult = JsonConvert.DeserializeObject<Aksiyon_Root_Input>(response.Content);

                foreach (AksiyonList item in perfResult.data)
                {
                    using (TTObjectContext objContext = new TTObjectContext(false))
                    {
                        BindingList<MHRSActionTypeDefinition.GetMHRSActionTypeDefinition_Class> list = MHRSActionTypeDefinition.GetMHRSActionTypeDefinition(" WHERE ACTIONNAME='" + item.aksiyonAdi + "'");

                        if (list != null && list.Count > 0)
                        {
                            MHRSActionTypeDefinition appSch = (MHRSActionTypeDefinition)objContext.GetObject(list[0].ObjectID.Value, typeof(MHRSActionTypeDefinition));

                            appSch.Day = Convert.ToInt32(appSch.ActionCode);//eski değeri day alanına attım şimdilik
                            appSch.ActionCode = item.aksiyonId.ToString();
                            appSch.OpenMHRS = item.aksiyonAcik;

                            objContext.Save();
                        }
                        else
                        {
                            MHRSActionTypeDefinition appSch = new MHRSActionTypeDefinition(objContext);

                            appSch.ActionName = item.aksiyonAdi;
                            appSch.ActionCode = item.aksiyonId.ToString();
                            appSch.OpenMHRS = item.aksiyonAcik;
                            appSch.Mustesna = true;
                            appSch.IsWorkingHour = item.aksiyonAcik;
                            appSch.Day = 30;
                            appSch.IsDocumentRequired = null;
                            appSch.IsIstisnaType = item.aksiyonIslemTuru.val == 1 ? false : true;
                            appSch.IsDocumentRequired = item.istisnaBelge;
                            objContext.Save();

                        }
                    }
                }
                
            }
        }
        #endregion

        #endregion Methods

    }
}