
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
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace TTObjectClasses
{
    /// <summary>
    /// MHRS Randevu Durum Güncelleme
    /// </summary>
    public partial class MHRSRandevuDurumGuncelleme : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            string log = string.Empty;
            try
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                    string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                    string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                    string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");
                    string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

                    if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                    {
                        BindingList<Guid> resorceList = new BindingList<Guid>();

                        MHRSServis.RandevuDurumGuncelleTalepType randevuDurumGuncelleTalep = new MHRSServis.RandevuDurumGuncelleTalepType();
                        MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                        MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                        MHRSServis.RandevuDurumGuncelleCevapType randevuDurumGuncelleCevap = new MHRSServis.RandevuDurumGuncelleCevapType();

                        TTObjectContext objectContext = new TTObjectContext(false);

                        if (userName != null && password != null && MHRSKurumKodu != null && MHRSIslemYapanKisiTC != null)
                        {

                            yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                            yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                            yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi
                            randevuDurumGuncelleTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;

                            kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);

                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                            randevuDurumGuncelleTalep.KurumBilgileri = kurumBilgileri;

                            BindingList<Appointment> appointmentList = Appointment.GetPatientComeToMHRSAppointment(objectContext, System.DateTime.Now.Date);
                            BindingList<Appointment> appointmentList2 = new BindingList<Appointment>();//Appointment.GetPatientComeToMHRSApp(objectContext);
                            BindingList<MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri> appArrayList = new BindingList<MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri>();

                            foreach (Appointment appointment in appointmentList)
                            {
                                if (appointment.CurrentStateDefID != Appointment.States.Completed)
                                {
                                    MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri randevuHrnVeDurumKodu = new MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri();

                                    randevuHrnVeDurumKodu.DurumKodu = 2;
                                    randevuHrnVeDurumKodu.RandevuHrn = appointment.MHRSRandevuHrn;
                                    appArrayList.Add(randevuHrnVeDurumKodu);
                                    //randevuDurumGuncelleTalep.RandevuBilgileri[i] = randevuHrnVeDurumKodu;
                                    //i++;
                                }
                                else if (appointment.CurrentStateDefID == Appointment.States.Completed)
                                {
                                    appointmentList2.Add(appointment);
                                }
                            }

                            if (randevuDurumGuncelleTalep.RandevuBilgileri == null)
                            {
                                int appCount = appArrayList.Count + appointmentList2.Count;
                                randevuDurumGuncelleTalep.RandevuBilgileri = new MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri[appCount];
                            }

                            // MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri[] appArrayList2 = new MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri[appointmentList2];
                            int i = 0;
                            foreach (Appointment appointment in appointmentList2)
                            {
                                MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri randevuHrnVeDurumKodu = new MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri();

                                randevuHrnVeDurumKodu.DurumKodu = 1;
                                randevuHrnVeDurumKodu.GelisZamani = appointment.AppDate != null ? appointment.AppDate.ToString() : null;
                                randevuHrnVeDurumKodu.RandevuGerceklesmeZamani = appointment.AppDate != null ? appointment.AppDate.ToString() : null;

                                randevuHrnVeDurumKodu.RandevuHrn = appointment.MHRSRandevuHrn;
                                //appArray[i]= randevuHrnVeDurumKodu;
                                randevuDurumGuncelleTalep.RandevuBilgileri[i] = randevuHrnVeDurumKodu;
                                i++;
                            }
                            foreach (MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri appArray in appArrayList)
                            {
                                randevuDurumGuncelleTalep.RandevuBilgileri[i] = appArray;
                                i++;
                            }


                            randevuDurumGuncelleCevap = MHRSServis.WebMethods.RandevuDurumGuncelleSync(Sites.SiteLocalHost, randevuDurumGuncelleTalep);

                            if (randevuDurumGuncelleCevap != null && randevuDurumGuncelleCevap.TemelCevapBilgileri != null)
                            {
                                if (randevuDurumGuncelleCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                {
                                    foreach (Appointment app in appointmentList)
                                    {
                                        MHRSServis.RandevuDurumSonucType randevuDurumSonuc = randevuDurumGuncelleCevap.RandevuDurumSonuc.Where(t => t.RandevuHrn == app.MHRSRandevuHrn && t.GuncellemeBasarisi == true).FirstOrDefault();
                                        if (randevuDurumSonuc != null && app.CurrentStateDefID != Appointment.States.Completed)
                                            app.MHRSHastaGeldi = false;
                                    }
                                    foreach (Appointment app in appointmentList2)
                                    {
                                        MHRSServis.RandevuDurumSonucType randevuDurumSonuc = randevuDurumGuncelleCevap.RandevuDurumSonuc.Where(t => t.RandevuHrn == app.MHRSRandevuHrn && t.GuncellemeBasarisi == true).FirstOrDefault();
                                        if (randevuDurumSonuc != null)
                                            app.MHRSHastaGeldi = true;
                                    }

                                    objectContext.Save();
                                }
                                //else if (randevuDurumGuncelleCevap.TemelCevapBilgileri != null)
                                //{
                                string hata = string.Empty;
                                if (!string.IsNullOrEmpty(randevuDurumGuncelleCevap.TemelCevapBilgileri.Aciklama))
                                    hata = randevuDurumGuncelleCevap.TemelCevapBilgileri.Aciklama;

                                if (randevuDurumGuncelleCevap.RandevuDurumSonuc != null)
                                {
                                    MHRSServis.RandevuDurumSonucType hataVar = randevuDurumGuncelleCevap.RandevuDurumSonuc.Where(t => t.GuncellemeBasarisi == false).FirstOrDefault();
                                    if (hataVar != null)
                                    {
                                        hata += "(";
                                        foreach (MHRSServis.RandevuDurumSonucType randevuDurumSonuc in randevuDurumGuncelleCevap.RandevuDurumSonuc)
                                        {
                                            if (!randevuDurumSonuc.GuncellemeBasarisi)
                                            {
                                                BindingList<Appointment> app = Appointment.GetByMHRSRandevuHrn(objectContext, randevuDurumSonuc.RandevuHrn);
                                                if (app.Count > 0)
                                                {
                                                    if (randevuDurumSonuc.Aciklama == "Randevunun durumu zaten 2 olduğu için değiştirilmedi.")
                                                        app[0].MHRSHastaGeldi = false;
                                                    else if (randevuDurumSonuc.Aciklama == "Randevunun durumu zaten 1 olduğu için değiştirilmedi.")
                                                        app[0].MHRSHastaGeldi = true;
                                                    else if (randevuDurumSonuc.Aciklama == "Randevu iptal edildiği için geldi/gelmedi bilgisi güncellenemez.")
                                                        app[0].MHRSHastaGeldi = false;
                                                    else
                                                        app[0].MHRSHastaGeldi = null;
                                                    hata += randevuDurumSonuc.RandevuHrn;
                                                    hata += randevuDurumSonuc.Aciklama;
                                                }
                                            }
                                        }
                                        hata += ")";
                                    }
                                }

                                objectContext.Save();
                                if (!string.IsNullOrEmpty(hata))
                                    throw new TTException("MHRS Bildirim Hatası : " + hata);
                                //}
                            }
                            else
                                throw new TTException("MHRS'ye bildirilirken hata oluştu !");
                        }
                    }
                    else
                    {
                        if (MHRSKurumKodu != null && MHRSIslemYapanKisiTC != null)
                        {
                            TTObjectContext objectContext = new TTObjectContext(false);
                            Appointment.HbysRandevuGerceklesmeBilgisiTalep hbysRandevuGerceklesmeBilgisiTalep = new Appointment.HbysRandevuGerceklesmeBilgisiTalep();
                            hbysRandevuGerceklesmeBilgisiTalep.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            hbysRandevuGerceklesmeBilgisiTalep.islemYapanTcKimlikNo = Convert.ToInt64(MHRSIslemYapanKisiTC);

                            BindingList<Appointment> appointmentList = Appointment.GetPatientComeToMHRSAppointment(objectContext, System.DateTime.Now.Date);
                            BindingList<Appointment> appointmentList2 = new BindingList<Appointment>();//Appointment.GetPatientComeToMHRSApp(objectContext);
                            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");
                            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/randevu/randevu-gerceklesme-bilgisi");

                            var client = new RestClient(uri);


                            foreach (Appointment appointment in appointmentList)
                            {
                                hbysRandevuGerceklesmeBilgisiTalep.randevuGerceklesmeBilgisiEklemeTalepList = new List<Appointment.HbysRandevuGerceklesmeBilgisiEklemeTalep>();
                                Appointment.HbysRandevuGerceklesmeBilgisiEklemeTalep tempEklemeTalep = new Appointment.HbysRandevuGerceklesmeBilgisiEklemeTalep();
                                tempEklemeTalep.hastaRandevuNumarasi = appointment.MHRSRandevuHrn;
                                
                                if (appointment.CurrentStateDefID == Appointment.States.Completed)
                                {
                                    if (appointment.EpisodeAction != null && appointment.EpisodeAction is PatientExamination)
                                    {
                                        tempEklemeTalep.hastaGelisZamani = ((PatientExamination)appointment.EpisodeAction).RequestDate.HasValue ? ((PatientExamination)appointment.EpisodeAction).RequestDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                                        tempEklemeTalep.randevuGerceklesmeZamani = ((PatientExamination)appointment.EpisodeAction).ProcessDate.HasValue ? ((PatientExamination)appointment.EpisodeAction).ProcessDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                                    }

                                    //tempEklemeTalep.hastaGelisZamani = appointment.AppDate != null ? appointment.AppDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                                    //tempEklemeTalep.randevuGerceklesmeZamani = appointment.AppDate != null ? appointment.AppDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                                    tempEklemeTalep.randevuGerceklesmeBilgisi = 1;
                                }
                                else if (appointment.CurrentStateDefID != Appointment.States.Completed)
                                {
                                    tempEklemeTalep.randevuGerceklesmeBilgisi = 0;
                                }

                                 hbysRandevuGerceklesmeBilgisiTalep.randevuGerceklesmeBilgisiEklemeTalepList.Add(tempEklemeTalep);

                                string serializedObj = JsonConvert.SerializeObject(hbysRandevuGerceklesmeBilgisiTalep, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


                                Schedule sch = new Schedule();
                                string accessToken = sch.LoginForMHRS();

                                RestRequest request = new RestRequest();
                                request.Method = Method.POST;
                                request.Parameters.Clear();

                                string bearerToken = "Bearer " + accessToken;
                                request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                                request.AddHeader("Accept", "application/json");
                                request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);


                                //IRestResponse response = client.Execute(request);
                                IRestResponse response = sch.PostCallForMHRS(client, request);

                                if (response.IsSuccessful)
                                {
                                    var perfResult = JsonConvert.DeserializeObject<Appointment.RandevuGerceklesme_Output>(response.Content);
                                    if (perfResult.infos != null)
                                    {
                                        if (perfResult.infos[0].mesaj == "Güncelleme işlemi başarıyla gerçekleştirilmiştir." || perfResult.infos[0].kodu == "RND6032")
                                        {
                                            if (tempEklemeTalep.randevuGerceklesmeBilgisi == 1)
                                                appointment.MHRSHastaGeldi = true;
                                            else if (tempEklemeTalep.randevuGerceklesmeBilgisi == 0)
                                                appointment.MHRSHastaGeldi = false;
                                            else
                                                appointment.MHRSHastaGeldi = null;
                                        }
                                    }
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

                                    if (detailedError == "Randevunun durumu zaten 0 olduğu için değiştirilmedi.")
                                        appointment.MHRSHastaGeldi = false;
                                    else if (detailedError == "Randevunun durumu zaten 1 olduğu için değiştirilmedi.")
                                        appointment.MHRSHastaGeldi = true;
                                    else if (detailedError == "Randevu iptal edildiği için geldi/gelmedi bilgisi güncellenemez.")
                                        appointment.MHRSHastaGeldi = false;
                                    else
                                        appointment.MHRSHastaGeldi = null;

                                    AddLog(appointment.ObjectID + " " + appointment.MHRSRandevuHrn + " " + detailedError);

                                }
                            }
                            objectContext.Save();
                        }
                    }
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

        #endregion Methods

    }
}