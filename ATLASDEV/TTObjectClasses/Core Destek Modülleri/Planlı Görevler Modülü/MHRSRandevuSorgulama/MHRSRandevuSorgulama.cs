
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
    public partial class MHRSRandevuSorgulama : BaseScheduledTask
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
                    string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                    int randevuSorgulamaSuresi = Convert.ToInt32(SystemParameter.GetParameterValue("MHRSRANDEVUSORGULAMASURESI", "15"));// Default 15 günlük randevular çekilir.

                    if (userName != null && password != null && MHRSKurumKodu != null && MHRSIslemYapanKisiTC != null)
                    {
                        if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                        {
                            BindingList<Guid> resorceList = new BindingList<Guid>();

                            MHRSServis.KurumRandevuSorgulamaTalepType kurumRandevuSorgulamaTalep = new MHRSServis.KurumRandevuSorgulamaTalepType();
                            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                            MHRSServis.TarihBilgileriType tarihBilgileri = new MHRSServis.TarihBilgileriType();
                            MHRSServis.KurumRandevuSorgulamaObjCevapType kurumRandevuSorgulamaObjCevap = new MHRSServis.KurumRandevuSorgulamaObjCevapType();
                            TTObjectContext objectContext = new TTObjectContext(false);

                            yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                            yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                            yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi

                            kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);

                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                            kurumRandevuSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                            kurumRandevuSorgulamaTalep.KurumBilgileri = kurumBilgileri;

                            tarihBilgileri.BaslangicTarihi = DateTime.Now.AddDays(-1).ToString();
                            tarihBilgileri.BitisTarihi = DateTime.Now.AddDays(randevuSorgulamaSuresi).ToString();
                            kurumRandevuSorgulamaTalep.TarihBilgileri = tarihBilgileri;

                            BindingList<ResPoliclinic> MHRSPoliclinics = ResPoliclinic.GetMHRSPoliclinics(objectContext);
                            foreach (ResPoliclinic policlinic in MHRSPoliclinics)
                            {
                                try
                                {
                                    
                                        kurumRandevuSorgulamaTalep.KlinikKodu = Convert.ToInt32(policlinic.MHRSCode);

                                        kurumRandevuSorgulamaObjCevap = MHRSServis.WebMethods.KurumRandevuSorgulamaObjSync(Sites.SiteLocalHost, kurumRandevuSorgulamaTalep);

                                        if (kurumRandevuSorgulamaObjCevap != null && kurumRandevuSorgulamaObjCevap.TemelCevapBilgileri != null)
                                        {
                                            if (kurumRandevuSorgulamaObjCevap.TemelCevapBilgileri.ServisBasarisi == true && string.IsNullOrEmpty(kurumRandevuSorgulamaObjCevap.TemelCevapBilgileri.Aciklama) && kurumRandevuSorgulamaObjCevap.KurumRandevuBilgileri.Length > 0)
                                            {
                                                foreach (MHRSServis.KurumRandevuSorgulamaObjCevapTypeKurumRandevuBilgileri kurumRandevuBilgisi in kurumRandevuSorgulamaObjCevap.KurumRandevuBilgileri)
                                                {
                                                    try
                                                    {
                                                        BindingList<Appointment> appointmentList = Appointment.GetByMHRSRandevuHrn(objectContext, kurumRandevuBilgisi.RandevuHrn);
                                                        BindingList<MHRSAdmissionAppointment> admissionAppointmentList = MHRSAdmissionAppointment.GetMHRSAdmissionAppByRandevuHrm(objectContext, kurumRandevuBilgisi.RandevuHrn);

                                                        BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContext, kurumRandevuBilgisi.HekimKodu);
                                                        BindingList<Schedule> scheduleList = null;
                                                        if (userList.Count > 0)
                                                            scheduleList = Schedule.GetScheduleByResourceAndDate(objectContext, userList[0].ObjectID.ToString(), Convert.ToDateTime(kurumRandevuBilgisi.TarihBilgileri.BaslangicTarihi), Convert.ToDateTime(kurumRandevuBilgisi.TarihBilgileri.BitisTarihi), policlinic.ObjectID.ToString());
                                                        if (appointmentList.Count == 0 && admissionAppointmentList.Count == 0 && userList.Count > 0 && scheduleList.Count > 0)
                                                        {
                                                            if (policlinic.MHRSAltKlinikKodu.Value == kurumRandevuBilgisi.AltKlinikKodu)
                                                            {
                                                                TTObjectContext newContext = new TTObjectContext(false);
                                                                MHRSAdmissionAppointment newMHRSAdmissionAppointment = (MHRSAdmissionAppointment)newContext.CreateObject("MHRSAdmissionAppointment");
                                                                newMHRSAdmissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
                                                                newMHRSAdmissionAppointment.NotRequiredQuota = true;
                                                                newMHRSAdmissionAppointment.RandevuHrn = kurumRandevuBilgisi.RandevuHrn;

                                                                Appointment newAppointment = (Appointment)newContext.CreateObject("Appointment");

                                                                newAppointment.MasterResource = policlinic;

                                                                // BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContext, kurumRandevuBilgisi.HekimKodu);
                                                                if (userList.Count > 0)
                                                                    newAppointment.Resource = userList[0];

                                                                newAppointment.AppDate = Convert.ToDateTime(kurumRandevuBilgisi.TarihBilgileri.BaslangicTarihi).Date;
                                                                newAppointment.StartTime = Convert.ToDateTime(kurumRandevuBilgisi.TarihBilgileri.BaslangicTarihi);
                                                                newAppointment.EndTime = Convert.ToDateTime(kurumRandevuBilgisi.TarihBilgileri.BitisTarihi); ;
                                                                newAppointment.CurrentStateDefID = Appointment.States.New;
                                                                if (userList.Count > 0)
                                                                {
                                                                    // BindingList<Schedule> scheduleList = Schedule.GetScheduleByResourceAndDate(objectContext, userList[0].ObjectID.ToString(), Convert.ToDateTime(kurumRandevuBilgisi.TarihBilgileri.BaslangicTarihi), Convert.ToDateTime(kurumRandevuBilgisi.TarihBilgileri.BitisTarihi), policlinic.ObjectID.ToString());
                                                                    if (scheduleList.Count > 0)
                                                                    {
                                                                        newAppointment.Schedule = scheduleList[0];
                                                                        newAppointment.AppointmentDefinition = scheduleList[0].AppointmentDefinition;
                                                                        newMHRSAdmissionAppointment.AppointmentDefinition = scheduleList[0].AppointmentDefinition;
                                                                        if (scheduleList[0].AppointmentDefinition.AppointmentCarriers != null && scheduleList[0].AppointmentDefinition.AppointmentCarriers.Count > 0)
                                                                            newAppointment.AppointmentCarrier = scheduleList[0].AppointmentDefinition.AppointmentCarriers[0];
                                                                    }
                                                                }
                                                                newAppointment.BreakAppointment = false;
                                                                string note = string.Empty;
                                                                note = "MHRS Hastası.(";
                                                                note += kurumRandevuBilgisi.HastaTCKimlikNo;

                                                                if (kurumRandevuBilgisi.VatandasTelefonBilgileri != null && kurumRandevuBilgisi.VatandasTelefonBilgileri.Length > 0)
                                                                {
                                                                    for (int i = 0; i < kurumRandevuBilgisi.VatandasTelefonBilgileri.Length; i++)
                                                                    {
                                                                        newMHRSAdmissionAppointment.PatientPhone = kurumRandevuBilgisi.VatandasTelefonBilgileri[i].AlanKodu;
                                                                        newMHRSAdmissionAppointment.PatientPhone += kurumRandevuBilgisi.VatandasTelefonBilgileri[i].TelefonNo;
                                                                        if (kurumRandevuBilgisi.VatandasTelefonBilgileri[i].NumaraTipi == 0)
                                                                            newMHRSAdmissionAppointment.PhoneType = PhoneTypeEnum.Home;
                                                                        if (kurumRandevuBilgisi.VatandasTelefonBilgileri[i].NumaraTipi == 3)
                                                                            newMHRSAdmissionAppointment.PhoneType = PhoneTypeEnum.GSM;
                                                                        note += " , (";
                                                                        note += kurumRandevuBilgisi.VatandasTelefonBilgileri[i].AlanKodu;
                                                                        note += ") ";
                                                                        note += kurumRandevuBilgisi.VatandasTelefonBilgileri[i].TelefonNo;
                                                                    }
                                                                }

                                                                note += ")";
                                                                note += kurumRandevuBilgisi.Engelli ? "Engelli, " : null;
                                                                note += kurumRandevuBilgisi.YuksekRiskliGebe ? "Yüksek Riskli Gebe, " : null;
                                                                note += kurumRandevuBilgisi.RefakatciIstiyormu ? "Refakatçi istiyor, " : null;
                                                                note += kurumRandevuBilgisi.Kimsesiz ? "Kimsesiz. " : null;
                                                                newAppointment.Notes = note;
                                                                newAppointment.AppointmentType = AppointmentTypeEnum.Examination;
                                                                BindingList<Patient> patientList = Patient.GetPatientsByUniqueRefNo(newContext, kurumRandevuBilgisi.HastaTCKimlikNo);
                                                                if (patientList.Count > 0)
                                                                {
                                                                    newAppointment.Patient = patientList[0];
                                                                    newMHRSAdmissionAppointment.PatientName = patientList[0].Name;
                                                                    newMHRSAdmissionAppointment.PatientSurname = patientList[0].Surname;
                                                                    newMHRSAdmissionAppointment.PatientUniqueRefNo = patientList[0].UniqueRefNo;
                                                                    newMHRSAdmissionAppointment.SelectedPatient = patientList[0];
                                                                    newMHRSAdmissionAppointment.SelectedPatientFiltered = patientList[0].FullName;
                                                                }
                                                                else
                                                                {
                                                                    newMHRSAdmissionAppointment.PatientName = kurumRandevuBilgisi.HastaAdi;
                                                                    newMHRSAdmissionAppointment.PatientSurname = kurumRandevuBilgisi.HastaSoyadi;
                                                                    newMHRSAdmissionAppointment.PatientUniqueRefNo = kurumRandevuBilgisi.HastaTCKimlikNo;
                                                                }
                                                                newAppointment.Action = (BaseAction)newMHRSAdmissionAppointment;
                                                                //                                            BindingList<AppointmentDefinition> appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(objectContext, AppointmentDefinitionEnum.PatientExamination);
                                                                //                                            if(appDefList.Count > 0)
                                                                //                                                newAppointment.AppointmentDefinition = appDefList[0];
                                                                newAppointment.MHRSRandevuHrn = kurumRandevuBilgisi.RandevuHrn;
                                                                newMHRSAdmissionAppointment.IsDisabled = kurumRandevuBilgisi.Engelli ? true : false;
                                                                newMHRSAdmissionAppointment.IsForlorn = kurumRandevuBilgisi.Kimsesiz ? true : false;
                                                                newMHRSAdmissionAppointment.IsHighRiskPregnancy = kurumRandevuBilgisi.YuksekRiskliGebe ? true : false;
                                                                newMHRSAdmissionAppointment.IsVirtuleUniqueRefNo = kurumRandevuBilgisi.SanalTC ? true : false;
                                                                newMHRSAdmissionAppointment.IsWantedCompanion = kurumRandevuBilgisi.RefakatciIstiyormu ? true : false;
                                                                newContext.Update();
                                                                newMHRSAdmissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Appointment;
                                                                newContext.Save();
                                                            }
                                                        }

                                                        else if (kurumRandevuBilgisi.DurumKodu == 2)
                                                        {
                                                            foreach (Appointment appointment in appointmentList)
                                                            {
                                                                if (appointment.CurrentStateDefID != Appointment.States.Cancelled)
                                                                {
                                                                    appointment.CancelledMHRS = true;
                                                                    appointment.CurrentStateDefID = Appointment.States.Cancelled;
                                                                }
                                                            }
                                                            foreach (MHRSAdmissionAppointment admissionAppointment in admissionAppointmentList)
                                                            {
                                                                if (admissionAppointment.CurrentStateDefID != AdmissionAppointment.States.Cancelled)
                                                                    admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Cancelled;
                                                            }
                                                            objectContext.Save();
                                                        }

                                                    }

                                                    catch (Exception ex)
                                                    {
                                                        log += "Hasta Tc =" + kurumRandevuBilgisi.HastaTCKimlikNo.ToString() + ex.ToString();
                                                        //AddLog(log);
                                                        continue;
                                                    }
                                                }
                                            }
                                            else if (kurumRandevuSorgulamaObjCevap.TemelCevapBilgileri.ServisBasarisi == false || !string.IsNullOrEmpty(kurumRandevuSorgulamaObjCevap.TemelCevapBilgileri.Aciklama))
                                                throw new TTException("MHRS Bildirim Hatası : " + kurumRandevuSorgulamaObjCevap.TemelCevapBilgileri.Aciklama);
                                        }
                                    
                                }

                                catch (Exception ex)
                                {
                                    log += ex.ToString();
                                    //AddLog(log);
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            TTObjectContext objectContext = new TTObjectContext(false);
                            DateTime startDate = DateTime.Now.AddDays(-1);
                            DateTime endDate = DateTime.Now.AddDays(randevuSorgulamaSuresi);
                            BindingList<ResPoliclinic> MHRSPoliclinics = ResPoliclinic.GetMHRSPoliclinics(objectContext);
                            foreach(ResPoliclinic policlinic in MHRSPoliclinics)
                            {
                                MHRSRandevuSorgulamaInput input = new MHRSRandevuSorgulamaInput();
                                input.aksiyonId = null;
                                input.gerceklesmeDurumu = null;
                                input.hekimTcKimlikNo = null;
                                input.kayitDurumKodu = null;
                                input.klinikKodu = policlinic.MHRSCode != null ? Convert.ToInt32(policlinic.MHRSCode) : 0;
                                input.muayeneYeriId = null;
                                input.semtDahilMi = false;
                                input.strBaslangicZamani = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                                input.strBitisZamani = endDate.ToString("yyyy-MM-dd HH:mm:ss");
                                input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                input.islemYapanTcKimlikNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                                try
                                {
                                    string serializedObj = JsonConvert.SerializeObject(input);

                                    Schedule schedule = new Schedule();
                                    string accessToken = schedule.LoginForMHRS();

                                    Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/randevu/kurum-randevulari-sorgula");

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
                                                detailedError += " Kodu: " + item["kodu"] + "  Mesaj: " + item["mesaj"];
                                            }

                                        }
                                        throw new TTException(detailedError);

                                    }

                                    if (response.IsSuccessful)
                                    {
                                        var result = JsonConvert.DeserializeObject<MHRSRandevuSorgulamaResponse>(response.Content);

                                        foreach (MHRSRandevuSorgulamaData responseData in result.data)
                                        {
                                            try
                                            {
                                                BindingList<Appointment> appointmentList = Appointment.GetByMHRSRandevuHrn(objectContext, responseData.hrn);
                                                BindingList<MHRSAdmissionAppointment> admissionAppointmentList = MHRSAdmissionAppointment.GetMHRSAdmissionAppByRandevuHrm(objectContext, responseData.hrn);

                                                BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContext, responseData.hekimTcKimlikNo.ToString());
                                                BindingList<Schedule> scheduleList = null;
                                                if (userList.Count > 0)
                                                    scheduleList = Schedule.GetScheduleByResourceAndDate(objectContext, userList[0].ObjectID.ToString(), Convert.ToDateTime(responseData.baslangicZamani), Convert.ToDateTime(responseData.bitisZamani), policlinic.ObjectID.ToString());
                                                if (appointmentList.Count == 0 && admissionAppointmentList.Count == 0 && userList.Count > 0 && scheduleList.Count > 0)
                                                {
                                                    if (policlinic.MHRSAltKlinikKodu.Value == responseData.muayeneYeriId)
                                                    {
                                                        TTObjectContext newContext = new TTObjectContext(false);
                                                        MHRSAdmissionAppointment newMHRSAdmissionAppointment = (MHRSAdmissionAppointment)newContext.CreateObject("MHRSAdmissionAppointment");
                                                        newMHRSAdmissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
                                                        newMHRSAdmissionAppointment.NotRequiredQuota = true;
                                                        newMHRSAdmissionAppointment.RandevuHrn = responseData.hrn;

                                                        Appointment newAppointment = (Appointment)newContext.CreateObject("Appointment");

                                                        newAppointment.MasterResource = policlinic;

                                                        // BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContext, responseData.HekimKodu);
                                                        if (userList.Count > 0)
                                                            newAppointment.Resource = userList[0];

                                                        newAppointment.AppDate = Convert.ToDateTime(responseData.baslangicZamani).Date;
                                                        newAppointment.StartTime = Convert.ToDateTime(responseData.baslangicZamani);
                                                        newAppointment.EndTime = Convert.ToDateTime(responseData.bitisZamani); ;
                                                        newAppointment.CurrentStateDefID = Appointment.States.New;
                                                        if (userList.Count > 0)
                                                        {
                                                            // BindingList<Schedule> scheduleList = Schedule.GetScheduleByResourceAndDate(objectContext, userList[0].ObjectID.ToString(), Convert.ToDateTime(responseData.TarihBilgileri.BaslangicTarihi), Convert.ToDateTime(responseData.TarihBilgileri.BitisTarihi), policlinic.ObjectID.ToString());
                                                            if (scheduleList.Count > 0)
                                                            {
                                                                newAppointment.Schedule = scheduleList[0];
                                                                newAppointment.AppointmentDefinition = scheduleList[0].AppointmentDefinition;
                                                                newMHRSAdmissionAppointment.AppointmentDefinition = scheduleList[0].AppointmentDefinition;
                                                                if (scheduleList[0].AppointmentDefinition.AppointmentCarriers != null && scheduleList[0].AppointmentDefinition.AppointmentCarriers.Count > 0)
                                                                    newAppointment.AppointmentCarrier = scheduleList[0].AppointmentDefinition.AppointmentCarriers[0];
                                                            }
                                                        }
                                                        newAppointment.BreakAppointment = false;
                                                        string note = string.Empty;
                                                        note = "MHRS Hastası.(";
                                                        note += responseData.vatandasTcKimlikNo;

                                                        if (responseData.vatandasTelefonList != null && responseData.vatandasTelefonList.Length > 0)
                                                        {
                                                            for (int i = 0; i < responseData.vatandasTelefonList.Length; i++)
                                                            {
                                                                newMHRSAdmissionAppointment.PatientPhone = responseData.vatandasTelefonList[i].telefonNumarasi;
                                                                newMHRSAdmissionAppointment.PhoneType = responseData.vatandasTelefonList[i].telefonTipi.val == 4 ? PhoneTypeEnum.Home : PhoneTypeEnum.GSM;
                                                                note += responseData.vatandasTelefonList[i];
                                                            }
                                                        }

                                                        note += ")";
                                                        note += responseData.randevuNotu;
                                                        newAppointment.Notes = note;
                                                        newAppointment.AppointmentType = AppointmentTypeEnum.Examination;
                                                        BindingList<Patient> patientList = Patient.GetPatientsByUniqueRefNo(newContext, responseData.vatandasTcKimlikNo);
                                                        if (patientList.Count > 0)
                                                        {
                                                            newAppointment.Patient = patientList[0];
                                                            newMHRSAdmissionAppointment.PatientName = patientList[0].Name;
                                                            newMHRSAdmissionAppointment.PatientSurname = patientList[0].Surname;
                                                            newMHRSAdmissionAppointment.PatientUniqueRefNo = patientList[0].UniqueRefNo;
                                                            newMHRSAdmissionAppointment.SelectedPatient = patientList[0];
                                                            newMHRSAdmissionAppointment.SelectedPatientFiltered = patientList[0].FullName;
                                                        }
                                                        else
                                                        {
                                                            newMHRSAdmissionAppointment.PatientName = responseData.vatandasAdi;
                                                            newMHRSAdmissionAppointment.PatientSurname = responseData.vatandasSoyadi;
                                                            newMHRSAdmissionAppointment.PatientUniqueRefNo = responseData.vatandasTcKimlikNo;
                                                        }
                                                        newAppointment.Action = (BaseAction)newMHRSAdmissionAppointment;
                                                        //                                            BindingList<AppointmentDefinition> appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(objectContext, AppointmentDefinitionEnum.PatientExamination);
                                                        //                                            if(appDefList.Count > 0)
                                                        //                                                newAppointment.AppointmentDefinition = appDefList[0];
                                                        newAppointment.MHRSRandevuHrn = responseData.hrn;
                                                        newMHRSAdmissionAppointment.IsDisabled = responseData.randevuTuru.val == 4 ? true : false;
                                                        newMHRSAdmissionAppointment.IsForlorn = false;//responseData.randevuTuru içinde yok
                                                        newMHRSAdmissionAppointment.IsHighRiskPregnancy = responseData.randevuTuru.val == 6 ? true : false;
                                                        newMHRSAdmissionAppointment.IsVirtuleUniqueRefNo = false;//responseData.randevuTuru içinde yok
                                                        newMHRSAdmissionAppointment.IsWantedCompanion = false;//responseData.randevuTuru içinde yok
                                                        newContext.Update();
                                                        newMHRSAdmissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Appointment;
                                                        newContext.Save();
                                                    }
                                                }

                                                else if (responseData.randevuKayitDurumu.val == 2)
                                                {
                                                    foreach (Appointment appointment in appointmentList)
                                                    {
                                                        if (appointment.CurrentStateDefID != Appointment.States.Cancelled)
                                                        {
                                                            appointment.CancelledMHRS = true;
                                                            appointment.CurrentStateDefID = Appointment.States.Cancelled;
                                                        }
                                                    }
                                                    foreach (MHRSAdmissionAppointment admissionAppointment in admissionAppointmentList)
                                                    {
                                                        if (admissionAppointment.CurrentStateDefID != AdmissionAppointment.States.Cancelled)
                                                            admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Cancelled;
                                                    }
                                                    objectContext.Save();
                                                }

                                            }

                                            catch (Exception ex)
                                            {
                                                log += ex.ToString();
                                                //AddLog(log);
                                                continue;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log += ex.ToString();
                                    continue;
                                }
                            }
                        }
                    }
                    else
                        throw new TTException("MHRSBILDIR Parametresi FALSE");
                }
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


        public class MHRSRandevuSorgulamaInput
        {
            public int? aksiyonId { get; set; }
            public int? gerceklesmeDurumu { get; set; }
            public Int64? hekimTcKimlikNo { get; set; }
            public int? kayitDurumKodu { get; set; }
            public int klinikKodu { get; set; }
            public int? muayeneYeriId { get; set; }
            public bool semtDahilMi { get; set; }
            public string strBaslangicZamani { get; set; }
            public string strBitisZamani { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }

        public class MHRSRandevuSorgulamaResponse
        {
            public string lang { get; set; }
            public bool success { get; set; }
            public List<Info> infos { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public List<MHRSRandevuSorgulamaData> data { get; set; }
        }

        public class MHRSRandevuSorgulamaData
        {
            public string aksiyonAdi { get; set; }
            public int aksiyonId { get; set; }
            public int cetvelId { get; set; }
            public DateTime baslangicZamani { get; set; }
            public DateTime bitisZamani { get; set; }
            public string eskiMuayeneYeriAdi { get; set; }
            public int? eskiMuayeneYeriId { get; set; }
            public Gerceklesmedurumu gerceklesmeDurumu { get; set; }
            public bool gizliRandevu { get; set; }
            public string hekimAdSoyad { get; set; }
            public Int64 hekimTcKimlikNo { get; set; }
            public string hrn { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public string klinikAdi { get; set; }
            public int klinikKodu { get; set; }
            public string kurumAdi { get; set; }
            public string muayeneYeriAdi { get; set; }
            public int muayeneYeriId { get; set; }
            public DateTime randevuAlinmaZamani { get; set; }
            public int randevuKanali { get; set; }
            public Randevukayitdurumu randevuKayitDurumu { get; set; }
            public string randevuNotu { get; set; }
            public Randevuturu randevuTuru { get; set; }
            public string vatandasAdi { get; set; }
            public Vatandascinsiyet vatandasCinsiyet { get; set; }
            public string vatandasDogumTarihi { get; set; }
            public string vatandasSoyadi { get; set; }
            public Int64 vatandasTcKimlikNo { get; set; }
            public Vatandastelefonlist[] vatandasTelefonList { get; set; }
        }

        public class Gerceklesmedurumu
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class Randevukayitdurumu
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class Randevuturu
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class Vatandascinsiyet
        {
            public string val { get; set; }
            public string valText { get; set; }
        }

        public class Vatandastelefonlist
        {
            public string telefonNumarasi { get; set; }
            public Telefontipi telefonTipi { get; set; }
        }

        public class Telefontipi
        {
            public int sira { get; set; }
            public int val { get; set; }
            public string valText { get; set; }
        }

        #endregion Methods

    }
}