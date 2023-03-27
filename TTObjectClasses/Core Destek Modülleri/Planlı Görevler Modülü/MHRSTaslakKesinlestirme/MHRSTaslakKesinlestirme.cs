
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


namespace TTObjectClasses
{
    public  partial class MHRSTaslakKesinlestirme : BaseScheduledTask
    {
#region Methods
        public override  void TaskScript()
        {
            string log = string.Empty;
            try
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                    string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                    string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                    string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
                    int MHRSTaslakKesinlestirmeGunSayisi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSTASLAKKESINLESTIRMEGUNSAYISI", "22"));
                    BindingList<Guid> resorceList = new BindingList<Guid>();
                    bool control = true;
                    bool firstContol = true;
                    
                    TTObjectContext context = new TTObjectContext(false);
                    
                    DateTime endDate = DateTime.Now.AddDays(30);
                    if(endDate.DayOfWeek == DayOfWeek.Monday)
                        endDate = endDate.AddDays(4);
                    if(endDate.DayOfWeek == DayOfWeek.Tuesday)
                        endDate =  endDate.AddDays(3);
                    if(endDate.DayOfWeek == DayOfWeek.Wednesday)
                        endDate = endDate.AddDays(2);
                    if(endDate.DayOfWeek == DayOfWeek.Thursday)
                        endDate = endDate.AddDays(1);
                    
                    BindingList<Schedule> MHRSList = Schedule.GetSchedulaForMHRSTask(context, DateTime.Now.AddDays(1).Date ,endDate.Date);

                    foreach (Schedule schedule in MHRSList)
                    {
                        firstContol = false;
                        if(resorceList.Count == 0)
                        {
                            resorceList.Add(schedule.Resource.ObjectID);
                            firstContol = true;
                        }
                        if (!resorceList.Contains(schedule.Resource.ObjectID))
                        {
                            resorceList.Add(schedule.Resource.ObjectID);
                            control = true;
                        }
                        else
                            control = false;
                        if (firstContol || control)
                        {
                            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                            MHRSServis.HekimBilgileriType hekimBilgileri = new MHRSServis.HekimBilgileriType();
                            MHRSServis.KurumTaslakCetvelKesinlestirmeTalepType kurumTaslakCetvelKesinlestirme = new MHRSServis.KurumTaslakCetvelKesinlestirmeTalepType();
                            MHRSServis.TarihBilgileriType kesinlestirmeTarihBilgileri = new MHRSServis.TarihBilgileriType();
                            MHRSServis.KurumTaslakCetvelKesinlestirmeCevapType kurumTaslakCetvelKesinlestirmeCevap = new MHRSServis.KurumTaslakCetvelKesinlestirmeCevapType();

                            if (userName != null && password != null && MHRSKurumKodu != null)
                            {
                                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                                yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi

                                if (schedule.Resource is ResUser)
                                {
                                    hekimBilgileri.Ad = schedule.Resource.Name;
                                    hekimBilgileri.Soyad = ((ResUser)schedule.Resource).Person.Surname;
                                    hekimBilgileri.HekimKodu = ((ResUser)schedule.Resource).UniqueNo;

                                    kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(((ResUser)schedule.Resource).UniqueNo);
                                }

                                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                kurumBilgileri.KurumKoduSpecified = true;
                                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                                kurumTaslakCetvelKesinlestirme.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                kurumTaslakCetvelKesinlestirme.HekimBilgileri = hekimBilgileri;
                                kurumTaslakCetvelKesinlestirme.KurumBilgileri = kurumBilgileri;

                                kesinlestirmeTarihBilgileri.BaslangicTarihi = DateTime.Now.AddDays(1).ToShortDateString();
                                kesinlestirmeTarihBilgileri.BitisTarihi = DateTime.Now.AddDays(MHRSTaslakKesinlestirmeGunSayisi).ToShortDateString(); //endDate; bu tarih de gelebilir
                                kurumTaslakCetvelKesinlestirme.TarihBilgileri = kesinlestirmeTarihBilgileri;
                                if (schedule.MasterResource != null && schedule.MasterResource is ResPoliclinic)
                                {
                                    if (((ResPoliclinic)schedule.MasterResource).MHRSCode != null)
                                    {
                                        kurumTaslakCetvelKesinlestirme.KlinikKoduSpecified = true;
                                        kurumTaslakCetvelKesinlestirme.KlinikKodu = Convert.ToInt32(((ResPoliclinic)schedule.MasterResource).MHRSCode);
                                    }
                                }

                                kurumTaslakCetvelKesinlestirmeCevap = MHRSServis.WebMethods.KurumTaslakCetvelKesinlestirmeSync(Sites.SiteLocalHost, kurumTaslakCetvelKesinlestirme);

                                if (kurumTaslakCetvelKesinlestirmeCevap != null && kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri != null)
                                {
                                    if (kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.ServisBasarisi == true && kurumTaslakCetvelKesinlestirmeCevap.taslakKesinMap != null && kurumTaslakCetvelKesinlestirmeCevap.taslakKesinMap.Length > 0)
                                    {
                                        foreach (MHRSServis.taslakKesinMapType taslakKesinMap in kurumTaslakCetvelKesinlestirmeCevap.taslakKesinMap)
                                        {
                                            BindingList<Schedule> ScheduleMHRSByTaslakId = Schedule.GrtScheduleByMHRSTaslakID(context, taslakKesinMap.TaslakCetvelId);
                                            if (ScheduleMHRSByTaslakId.Count > 0)
                                            {
                                                Schedule sch = (Schedule)context.GetObject(ScheduleMHRSByTaslakId[0].ObjectID, typeof(Schedule));
                                                sch.MHRSKesinCetvelID = taslakKesinMap.KesinCetvelId;
                                                sch.MHRSTaslakCetvelID = null;
                                                sch.ErrorOfMHRSApprove = null;
                                                context.Save();
                                            }
                                        }
                                    }
                                    else if (kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.ServisBasarisi == false)
                                    {
                                        foreach (Schedule scheduleItem in MHRSList)
                                        {
                                            if(resorceList.Contains(scheduleItem.Resource.ObjectID))
                                            {
                                                scheduleItem.ErrorOfMHRSApprove =  kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.Aciklama;
                                            }
                                        }
                                        context.Save();
                                        //throw new TTException("MHRS Bildirim Hatası : " + kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.Aciklama);
                                    }
                                }
                            }
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