
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

namespace TTObjectClasses
{
    public  partial class MHRSIstisnaSorgulamaSilme : BaseScheduledTask
    {
#region Methods
        public override  void TaskScript()
        {
            string log = string.Empty;
            try
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                        IstisnaSorgula();
                    else
                        IstisnaSorgula_V2();
                    
                }
                else
                    throw new TTException("MHRSBILDIR Parametresi FALSE");
            }
            catch (Exception ex)
            {
                log += ex.ToString();
            }
            finally
            {
                if (string.IsNullOrEmpty(log))
                    log = TTUtils.CultureService.GetText("M26698", "Planlı görev başarıyla tamamlanmıştır.");
                AddLog(log);
            }
        }

        public void IstisnaSorgula()
        {
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "0");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            BindingList<Guid> resorceList = new BindingList<Guid>();

            MHRSServis.KurumIstisnaSorgulamaTalepType kurumIstisnaSorgulamaTalep = new MHRSServis.KurumIstisnaSorgulamaTalepType();
            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
            MHRSServis.TarihBilgileriType tarihBilgileri = new MHRSServis.TarihBilgileriType();
            MHRSServis.KurumIstisnaSorgulamaCevapType kurumIstisnaSorgulamaCevap = new MHRSServis.KurumIstisnaSorgulamaCevapType();
            TTObjectContext objectContext = new TTObjectContext(false);

            if (userName != null && password != null && MHRSKurumKodu != null && MHRSIslemYapanKisiTC != null)
            {
                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi

                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);

                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                kurumBilgileri.KurumKoduSpecified = true;
                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                kurumIstisnaSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                kurumIstisnaSorgulamaTalep.KurumBilgileri = kurumBilgileri;

                tarihBilgileri.BaslangicTarihi = DateTime.Now.ToString();
                tarihBilgileri.BitisTarihi = DateTime.Now.AddDays(7).ToString();
                kurumIstisnaSorgulamaTalep.TarihBilgileri = tarihBilgileri;

                kurumIstisnaSorgulamaCevap = MHRSServis.WebMethods.KurumIstisnaSorgulamaSync(Sites.SiteLocalHost, kurumIstisnaSorgulamaTalep);

                if (kurumIstisnaSorgulamaCevap != null && kurumIstisnaSorgulamaCevap.TemelCevapBilgileri != null)
                {
                    if (kurumIstisnaSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true && string.IsNullOrEmpty(kurumIstisnaSorgulamaCevap.TemelCevapBilgileri.Aciklama) && kurumIstisnaSorgulamaCevap.IstisnaDetayBilgileri.Length > 0)
                    {
                        foreach (MHRSServis.IstisnaDetayBilgileriType istisnaDetayBilgileri in kurumIstisnaSorgulamaCevap.IstisnaDetayBilgileri)
                        {
                            if (istisnaDetayBilgileri.IstisnaDurumKodu != 1)
                            {
                                BindingList<Schedule> scheduleList = Schedule.GetScheduleByMHRSIstisnaID(objectContext, istisnaDetayBilgileri.IstisnaId);

                                if (scheduleList.Count > 0)
                                {
                                    if (istisnaDetayBilgileri.IstisnaDurumKodu == 3)//// istisna  reddedilmişse silinecek ve doktora tekrar bildirilmesi için mesaj gönderilecek
                                    {

                                        MHRSServis.KurumIstisnaSilmeTalepType kurumIstisnaSilmeTalep = new MHRSServis.KurumIstisnaSilmeTalepType();
                                        MHRSServis.KurumIstisnaSilmeCevapType kurumIstisnaSilmeCevap = new MHRSServis.KurumIstisnaSilmeCevapType();

                                        kurumIstisnaSilmeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                        kurumIstisnaSilmeTalep.KurumBilgileri = kurumBilgileri;
                                        kurumIstisnaSilmeTalep.IstisnaId = Convert.ToInt64(scheduleList[0].MHRSIstisnaID);

                                        kurumIstisnaSilmeCevap = MHRSServis.WebMethods.KurumIstisnaSilmeSync(Sites.SiteLocalHost, kurumIstisnaSilmeTalep);

                                        if (kurumIstisnaSilmeCevap != null && kurumIstisnaSilmeCevap.TemelCevapBilgileri != null)
                                        {
                                            if (kurumIstisnaSilmeCevap.TemelCevapBilgileri.ServisBasarisi == true && string.IsNullOrEmpty(kurumIstisnaSilmeCevap.TemelCevapBilgileri.Aciklama))
                                            {
                                                scheduleList[0].MHRSScheduleType = MHRSScheduleTypeEnum.Rejected;

                                                UserMessage message = new UserMessage(objectContext);
                                                //                                                        message.BaseAction = (BaseAction)this._PathologyTest.Pathology;
                                                //                                                        message.SubAction = (SubActionProcedure)this._PathologyTest;
                                                //                                                        message.Patient = this._PathologyTest.Episode.Patient;
                                                message.IsPanicMessage = false;
                                                message.IsSystemMessage = true;
                                                message.Sender = Common.CurrentResource;//(ResUser)Common.CurrentUser.UserObject;
                                                message.ToUser = scheduleList[0].Resource is ResUser ? (ResUser)scheduleList[0].Resource : null;
                                                //   message.Status = MessageStatusEnum.Sent;
                                                message.MessageDate = TTObjectDefManager.ServerTime;
                                                //  message.MessageFeedback = true;
                                                message.Subject = "MHRS İSTİSNA BİLDİRİMİ REDDİ";
                                                message.SetRTFBody("MHRS İstisna Bildiriminiz bakanlık tarafından reddedildi. Randevu planınınızı silmek istiyorsanız tekrar istisna bildirmeniz gerekmektedir.");
                                            }
                                            else if (kurumIstisnaSilmeCevap.TemelCevapBilgileri.ServisBasarisi == false || !string.IsNullOrEmpty(kurumIstisnaSilmeCevap.TemelCevapBilgileri.Aciklama))
                                                throw new TTException("MHRS Bildirim Hatası : " + kurumIstisnaSilmeCevap.TemelCevapBilgileri.Aciklama);
                                        }
                                    }
                                    if (istisnaDetayBilgileri.IstisnaDurumKodu == 2)/// İstisna Onaylanmışsa schedule ı silinecek
                                    {
                                        BindingList<Appointment> appointments = Appointment.GetBySchedule(objectContext, scheduleList[0].ObjectID.ToString());
                                        foreach (Appointment app in appointments)
                                        {
                                            if (app.CurrentStateDefID != Appointment.States.Cancelled)
                                            {
                                                app.CurrentStateDefID = Appointment.States.Cancelled;
                                                app.IsCancelledByMHRSIstisna = true;
                                                app.Notes = TTUtils.CultureService.GetText("M25916", "Hekim istisnası onaylandığı için iptal edildi.");
                                            }
                                        }
                                        ((ITTObject)scheduleList[0]).Delete();
                                    }
                                }
                                objectContext.Save();
                            }
                        }
                    }
                    else if (kurumIstisnaSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == false || !string.IsNullOrEmpty(kurumIstisnaSorgulamaCevap.TemelCevapBilgileri.Aciklama))
                        throw new TTException("MHRS Bildirim Hatası : " + kurumIstisnaSorgulamaCevap.TemelCevapBilgileri.Aciklama);
                }
            }
        }

        public void IstisnaSorgula_V2()
        {
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

            Istisna_Sorgula_Input istisna__Input = null;
            using (var objectContext = new TTObjectContext(false))
            {

                var scheduleList = Schedule.GetMHRSSchedules(Guid.Empty, Guid.Empty, DateTime.Now.Date, DateTime.Now.AddDays(7).Date).Select(x => new { x.MasterResource, x.Resource }).Distinct();

                Schedule schedule = new Schedule();
                string accessToken = schedule.LoginForMHRS();

                foreach (var item in scheduleList)
                {
                    istisna__Input = new Istisna_Sorgula_Input();


                    istisna__Input.baslangicZamani = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    istisna__Input.bitisZamani = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss");
                    istisna__Input.cetvelTipi = 1;

                    ResUser ru = objectContext.GetObject<ResUser>(item.Resource.Value, false);
                    istisna__Input.hekimTcKimlikNo = ru != null ? Convert.ToInt64(ru.UniqueNo) : 0;

                    //istisna__Input.istisnaDurumId

                    ResPoliclinic rp = objectContext.GetObject<ResPoliclinic>(item.MasterResource.Value, false);
                    istisna__Input.klinikKodu = rp != null && rp.MHRSCode != null ? Convert.ToInt32(rp.MHRSCode) : 0;
                    istisna__Input.muayeneYeriId = rp != null && rp.MHRSAltKlinikKodu != null ? Convert.ToInt32(rp.MHRSAltKlinikKodu) : 0;

                    istisna__Input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                    istisna__Input.islemYapanTcKimlikNo = Convert.ToInt64(MHRSIslemYapanKisiTC);

                    string serializedObj = JsonConvert.SerializeObject(istisna__Input);

                    Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/cetvel/ekle");

                    var client = new RestClient(uri);

                    RestRequest request = new RestRequest();
                    request.Method = Method.POST;
                    request.Parameters.Clear();

                    string bearerToken = "Bearer " + accessToken;
                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                    request.AddHeader("Accept", "application/json");
                    request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                    //IRestResponse response = client.Execute(request);
                    IRestResponse response = schedule.PostCallForMHRS(client, request);

                    if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                    {
                        var errorMessage = response.Content;
                        var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                        string detailedError = "";

                        if (errorObject != null)
                        {
                            var error = errorObject.Value<JArray>("errors");

                            foreach (Newtonsoft.Json.Linq.JObject item2 in error)
                            {
                                detailedError += item2.ToString();
                            }
                            //var detailedError = errorObject.Value<string>("message");
                            //errorMessage = error.ToString();
                        }
                        AddLog(detailedError);
                    }

                    if (response.IsSuccessful)
                    {
                        var perfResult = JsonConvert.DeserializeObject<List<Istisna_Sorgula_Output>>(response.Content);

                        if (perfResult[0].istisnaDurum.val != 1)
                        {

                            BindingList<Schedule> scheduleArray = Schedule.GetScheduleByMHRSIstisnaID(objectContext, perfResult[0].istisnaId);

                            if (perfResult[0].istisnaDurum.val == 3)
                            {
                                Delete_Input delete_Input = new Delete_Input();

                                delete_Input.istisnaId = perfResult[0].istisnaId;
                                delete_Input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                delete_Input.islemYapanTcKimlikNo = Convert.ToInt64(MHRSIslemYapanKisiTC);

                                string deletedSerialize = JsonConvert.SerializeObject(istisna__Input);

                                Uri uri_Delete = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/istisna/delete");

                                var client_Delete = new RestClient(uri_Delete);

                                RestRequest request_Delete = new RestRequest();
                                request.Method = Method.DELETE;
                                request.Parameters.Clear();

                                string bearerToken_Delete = "Bearer " + accessToken;
                                request.AddParameter("Authorization", bearerToken_Delete, ParameterType.HttpHeader);
                                request.AddHeader("Accept", "application/json");
                                request.AddParameter("application/json", deletedSerialize, ParameterType.RequestBody);


                                IRestResponse response_delete = client_Delete.Execute(request_Delete);

                                if (response_delete != null && response_delete.ResponseStatus == ResponseStatus.Completed && response_delete.IsSuccessful == false)
                                {
                                    var errorMessage = response_delete.Content;
                                    var errorObject = JsonConvert.DeserializeObject(response_delete.Content) as JObject;
                                    string detailedError = "";

                                    if (errorObject != null)
                                    {
                                        var error = errorObject.Value<JArray>("errorList");

                                        foreach (Newtonsoft.Json.Linq.JObject item2 in error)
                                        {
                                            detailedError += item2.ToString();
                                        }
                                        //var detailedError = errorObject.Value<string>("message");
                                        //errorMessage = error.ToString();
                                    }
                                    AddLog(detailedError);
                                }

                                if (response.IsSuccessful)
                                {
                                    var delete_Result = JsonConvert.DeserializeObject<List<Delete_Output>>(response.Content);

                                    scheduleArray[0].MHRSScheduleType = MHRSScheduleTypeEnum.Rejected;

                                    UserMessage message = new UserMessage(objectContext);
                                    message.IsPanicMessage = false;
                                    message.IsSystemMessage = true;
                                    message.Sender = Common.CurrentResource;//(ResUser)Common.CurrentUser.UserObject;
                                    message.ToUser = scheduleArray[0].Resource is ResUser ? (ResUser)scheduleArray[0].Resource : null;
                                    message.MessageDate = TTObjectDefManager.ServerTime;
                                    message.Subject = "MHRS İSTİSNA BİLDİRİMİ REDDİ";
                                    message.SetRTFBody("MHRS İstisna Bildiriminiz bakanlık tarafından reddedildi. Randevu planınınızı silmek istiyorsanız tekrar istisna bildirmeniz gerekmektedir.");
                                }

                            }
                            else if (perfResult[0].istisnaDurum.val == 2)/// İstisna Onaylanmışsa schedule ı silinecek
                            {
                                BindingList<Appointment> appointments = Appointment.GetBySchedule(objectContext, scheduleArray[0].ObjectID.ToString());
                                foreach (Appointment app in appointments)
                                {
                                    if (app.CurrentStateDefID != Appointment.States.Cancelled)
                                    {
                                        app.CurrentStateDefID = Appointment.States.Cancelled;
                                        app.IsCancelledByMHRSIstisna = true;
                                        app.Notes = TTUtils.CultureService.GetText("M25916", "Hekim istisnası onaylandığı için iptal edildi.");
                                    }
                                }
                                ((ITTObject)scheduleArray[0]).Delete();
                            }
                        }
                        objectContext.Save();

                    }
                }

            }
        }

        #endregion Methods

        #region CLASS
        public class Istisna_Sorgula_Input
        {
            public string baslangicZamani { get; set; }
            public string bitisZamani { get; set; }
            public int cetvelTipi { get; set; }
            public Int64 hekimTcKimlikNo { get; set; }
            public int istisnaDurumId { get; set; }
            public int klinikKodu { get; set; }
            public int muayeneYeriId { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }

        public class IstisnaDurum
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class Istisna_Sorgula_Output
        {
            public string aciklama { get; set; }
            public string aksiyonAdi { get; set; }
            public int aksiyonId { get; set; }
            public DateTime baslangicZamani { get; set; }
            public DateTime bitisZamani { get; set; }
            public int cetvelId { get; set; }
            public int hekimTcKimlikNo { get; set; }
            public int islemYapanKurumKodu { get; set; }
            public IstisnaDurum istisnaDurum { get; set; }
            public int istisnaId { get; set; }
            public int klinikKodu { get; set; }
            public int muayeneYeriId { get; set; }
        }

        public class Delete_Input
        {
            public int istisnaId { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }

        public class Data
        {
        }

        public class ErrorList
        {
            public string kodu { get; set; }
            public string mesaj { get; set; }
        }

        public class InfoList
        {
            public string kodu { get; set; }
            public string mesaj { get; set; }
        }

        public class WarningList
        {
            public string kodu { get; set; }
            public string mesaj { get; set; }
        }

        public class Delete_Output
        {
            public Data data { get; set; }
            public List<ErrorList> errorList { get; set; }
            public string httpStatus { get; set; }
            public List<InfoList> infoList { get; set; }
            public bool valid { get; set; }
            public List<WarningList> warningList { get; set; }
        }
        #endregion

    }
}