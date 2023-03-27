
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class MHRSRandevuPlanSorgulamaFormu : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnExcel.Click += new TTControlEventDelegate(btnExcel_Click);
            lstPoliclinic.SelectedObjectChanged += new TTControlEventDelegate(lstPoliclinic_SelectedObjectChanged);
            btnAllSchedule.Click += new TTControlEventDelegate(btnAllSchedule_Click);
            btnUncertainedSchedule.Click += new TTControlEventDelegate(btnUncertainedSchedule_Click);
            btnEntegre.Click += new TTControlEventDelegate(btnEntegre_Click);
            btnListele.Click += new TTControlEventDelegate(btnListele_Click);
            btnAltKlinikSorgula.Click += new TTControlEventDelegate(btnAltKlinikSorgula_Click);
            btnHekimEkle.Click += new TTControlEventDelegate(btnHekimEkle_Click);
            btnKlinikEkle.Click += new TTControlEventDelegate(btnKlinikEkle_Click);
            btnAltKlinikEkle.Click += new TTControlEventDelegate(btnAltKlinikEkle_Click);
            btnSetMHRSClinicCode.Click += new TTControlEventDelegate(btnSetMHRSClinicCode_Click);
            btnAltKlinikAktar.Click += new TTControlEventDelegate(btnAltKlinikAktar_Click); 
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnExcel.Click -= new TTControlEventDelegate(btnExcel_Click);
            lstPoliclinic.SelectedObjectChanged -= new TTControlEventDelegate(lstPoliclinic_SelectedObjectChanged);
            btnAllSchedule.Click -= new TTControlEventDelegate(btnAllSchedule_Click);
            btnUncertainedSchedule.Click -= new TTControlEventDelegate(btnUncertainedSchedule_Click);
            btnEntegre.Click -= new TTControlEventDelegate(btnEntegre_Click);
            btnListele.Click -= new TTControlEventDelegate(btnListele_Click);
            btnAltKlinikSorgula.Click -= new TTControlEventDelegate(btnAltKlinikSorgula_Click);
            btnHekimEkle.Click -= new TTControlEventDelegate(btnHekimEkle_Click);
            btnKlinikEkle.Click -= new TTControlEventDelegate(btnKlinikEkle_Click);
            btnAltKlinikEkle.Click -= new TTControlEventDelegate(btnAltKlinikEkle_Click);
            btnSetMHRSClinicCode.Click -= new TTControlEventDelegate(btnSetMHRSClinicCode_Click);
            btnAltKlinikAktar.Click -= new TTControlEventDelegate(btnAltKlinikAktar_Click);
            base.UnBindControlEvents();
        }

        private void btnExcel_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnExcel_Click
   try
            {
                if (gridSchedule.Rows.Count == 0)
                {
                    InfoBox.Show("Excele aktarmak için hasta grubu seçiniz.");
                    return;
                }

                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.Filter = "Excel 97-2003 Workbook (*.xls)|*.xls";
                //saveFileDialog.DefaultExt = "xls";
                //saveFileDialog.RestoreDirectory = true;

                //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
                //if (dialogResult == DialogResult.OK)
                //{
                //    this.gridSchedule.ExportGridToExcel(saveFileDialog.FileName, false);
                //}
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnExcel_Click
        }

        private void lstPoliclinic_SelectedObjectChanged()
        {
#region MHRSRandevuPlanSorgulamaFormu_lstPoliclinic_SelectedObjectChanged
   string doctorList = null;
            doctorList = "SENTTOMHRS='1' AND USERRESOURCES.RESOURCE.OBJECTID IN('" + ((Resource)((TTListBox)this.lstPoliclinic).SelectedObject).ObjectID + "')";
            
            listDoctor.ControlValue =null ;
            listDoctor.ListFilterExpression =  doctorList;
#endregion MHRSRandevuPlanSorgulamaFormu_lstPoliclinic_SelectedObjectChanged
        }

        private void btnAllSchedule_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnAllSchedule_Click
   gridSchedule.Rows.Clear();
            TTObjectContext context = new TTObjectContext(true);
            if (startTime == null)
            {
                InfoBox.Show("Başlangıç Tarihi Boş Geçilemez ! ");
                return;
            }
            if (endTime == null)
            {
                InfoBox.Show("Başlangıç Tarihi Boş Geçilemez ! ");
                return;
            }
            if (Convert.ToDateTime((endTime.NullableValue)) <= Convert.ToDateTime(startTime.NullableValue))
            {
                InfoBox.Show("Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! ");
                return;
            }
            BindingList<Schedule> scheduleList ;          
            if (lstPoliclinic.SelectedValue == null && listDoctor.SelectedValue == null)
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,(Convert.ToDateTime(endTime.NullableValue)).Date.AddDays(1).AddMilliseconds(-1),Guid.Empty, Guid.Empty);
            else if(lstPoliclinic.SelectedValue != null && listDoctor.SelectedValue == null)
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,(Convert.ToDateTime(endTime.NullableValue)).Date.AddDays(1).AddMilliseconds(-1),((Resource)((TTListBox)this.lstPoliclinic).SelectedObject).ObjectID, Guid.Empty);            
            else if(lstPoliclinic.SelectedValue == null && listDoctor.SelectedValue != null)
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,(Convert.ToDateTime(endTime.NullableValue)).Date.AddDays(1).AddMilliseconds(-1), Guid.Empty, ((ResUser)((TTListBox)this.listDoctor).SelectedObject).ObjectID);
            else
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,Convert.ToDateTime(endTime.NullableValue),((Resource)((TTListBox)this.lstPoliclinic).SelectedObject).ObjectID,((ResUser)((TTListBox)this.listDoctor).SelectedObject).ObjectID);
            
            foreach(Schedule item in scheduleList)
            {
                ITTGridRow newRow = gridSchedule.Rows.Add();
                newRow.Cells[txtPoliclinic.Name].Value = item.MasterResource != null ? item.MasterResource.Name : null;
                newRow.Cells[txtDoktor.Name].Value = item.Resource != null ? item.Resource.Name : null;
                newRow.Cells[txtBaslangicTarihi.Name].Value = item.StartTime != null ? item.StartTime.Value.ToString() : null;
                newRow.Cells[txtBitisTarihi.Name].Value = item.EndTime != null ? item.EndTime.Value.ToString() : null;
                newRow.Cells[chkKesinlesti.Name].Value = item.MHRSKesinCetvelID != null ? true : false;
                newRow.Cells[txtKesinlesmeHatasi.Name].Value = item.ErrorOfMHRSApprove != null ? Globals.StringToRTF( item.ErrorOfMHRSApprove) : null;
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnAllSchedule_Click
        }

        private void btnUncertainedSchedule_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnUncertainedSchedule_Click
   gridSchedule.Rows.Clear();
            TTObjectContext context = new TTObjectContext(true);
            if (startTime == null)
            {
                InfoBox.Show("Başlangıç Tarihi Boş Geçilemez ! ");
                return;
            }
            if (endTime == null)
            {
                InfoBox.Show("Başlangıç Tarihi Boş Geçilemez ! ");
                return;
            }
            if (Convert.ToDateTime((endTime.NullableValue)) <= Convert.ToDateTime(startTime.NullableValue))
            {
                InfoBox.Show("Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! ");
                return;
            }
            BindingList<Schedule> scheduleList ;
             if (lstPoliclinic.SelectedValue == null && listDoctor.SelectedValue == null)
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,(Convert.ToDateTime(endTime.NullableValue)).Date.AddDays(1).AddMilliseconds(-1),Guid.Empty, Guid.Empty);
            else if(lstPoliclinic.SelectedValue != null && listDoctor.SelectedValue == null)
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,(Convert.ToDateTime(endTime.NullableValue)).Date.AddDays(1).AddMilliseconds(-1),((Resource)((TTListBox)this.lstPoliclinic).SelectedObject).ObjectID, Guid.Empty);            
            else if(lstPoliclinic.SelectedValue == null && listDoctor.SelectedValue != null)
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,(Convert.ToDateTime(endTime.NullableValue)).Date.AddDays(1).AddMilliseconds(-1), Guid.Empty, ((ResUser)((TTListBox)this.listDoctor).SelectedObject).ObjectID);
            else
                scheduleList = Schedule.GetScheduleForMHRS(context, Convert.ToDateTime(startTime.NullableValue).Date,Convert.ToDateTime(endTime.NullableValue),((Resource)((TTListBox)this.lstPoliclinic).SelectedObject).ObjectID,((ResUser)((TTListBox)this.listDoctor).SelectedObject).ObjectID);
            
            foreach(Schedule item in scheduleList)
            {
                if(item.MHRSKesinCetvelID == null)
                {
                    ITTGridRow newRow = gridSchedule.Rows.Add();
                    newRow.Cells[txtPoliclinic.Name].Value = item.MasterResource != null ? item.MasterResource.Name : null;
                    newRow.Cells[txtDoktor.Name].Value = item.Resource != null ? item.Resource.Name : null;
                    newRow.Cells[txtBaslangicTarihi.Name].Value = item.StartTime != null ? item.StartTime.Value.ToString() : null;
                    newRow.Cells[txtBitisTarihi.Name].Value = item.EndTime != null ? item.EndTime.Value.ToString() : null;
                    newRow.Cells[chkKesinlesti.Name].Value = item.MHRSKesinCetvelID != null ? true : false;
                    newRow.Cells[txtKesinlesmeHatasi.Name].Value = item.ErrorOfMHRSApprove != null ? Globals.StringToRTF(item.ErrorOfMHRSApprove) : null;
                }
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnUncertainedSchedule_Click
        }

        private void btnEntegre_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnEntegre_Click
   if (gridMHRSPlanlari.Rows.Count == 0)
            {
                InfoBox.Show("Entegre edilecek veri bulunamadı ! ");
                return;
            }
            
            TTObjectContext objectContext = new TTObjectContext(false);
            
            foreach (ITTGridRow item in gridMHRSPlanlari.Rows)
            {
                if((item.Cells[txtXXXXXXDurumu.Name].Value).ToString() == "XXXXXX'da bulunamadı")
                {
                    BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetByMHRSKlinikVeAltKlinikKodu(objectContext, Convert.ToInt32(item.Cells[txtKlinikKodu.Name].Value.ToString()), Convert.ToInt32(item.Cells[txtAltKlinikKodu.Name].Value.ToString()));
                    if(policlinicList.Count > 0)
                    {
                        BindingList<Schedule> scheduleList = Schedule.GetScheduleByResourceAndDate(objectContext,((ResUser)((TTListBox)this.listEntegrasyonDoktor).SelectedObject).ToString(),Convert.ToDateTime(item.Cells[txtMHRSBaslangicTarihi.Name].Value),Convert.ToDateTime(item.Cells[txtMHRSBitisTarihi.Name].Value),policlinicList[0].ToString());
                        if(scheduleList.Count > 0)
                        {
                            if(item.Cells[txtTaslakID.Name].Value != null)
                            {
                                BindingList<Schedule> scheduleByTaslakIDList = Schedule.GrtScheduleByMHRSTaslakID(objectContext, Convert.ToInt64(item.Cells[txtTaslakID.Name].Value));
                                if(scheduleByTaslakIDList.Count > 0 && item.Cells[txtKesinCetvelID.Name].Value != null)
                                {
                                    scheduleByTaslakIDList[0].MHRSKesinCetvelID = Convert.ToInt64(item.Cells[txtKesinCetvelID.Name].Value);
                                    scheduleByTaslakIDList[0].MHRSTaslakCetvelID = null;
                                    objectContext.Save();
                                }
                                else
                                    InfoBox.Show(item.Cells[txtMHRSBaslangicTarihi.Name].Value.ToString() + "Tarihinde hekimin çakışan planı var !");
                            }
                        }
                        else
                        {
                            Schedule newSchedule = (Schedule)objectContext.CreateObject("Schedule");

                            newSchedule.MasterResource = policlinicList[0];
                            
                            newSchedule.Resource = ((ResUser)((TTListBox)this.listEntegrasyonDoktor).SelectedObject);

                            BindingList<AppointmentDefinition> appointmentDefinitionList = AppointmentDefinition.GetAppointmentDefinitionByName(objectContext, AppointmentDefinitionEnum.PatientExamination);
                            if (appointmentDefinitionList.Count > 0)
                                newSchedule.AppointmentDefinition = appointmentDefinitionList[0];

                            newSchedule.ScheduleDate =  Convert.ToDateTime(item.Cells[txtMHRSBaslangicTarihi.Name].Value).Date;
                            //   newSchedule.CountLimit = this.schCountLimit;
                            newSchedule.Duration = Convert.ToInt32( item.Cells[txtTedaviSuresi.Name].Value) ;
                            
                            newSchedule.StartTime =  Convert.ToDateTime(item.Cells[txtMHRSBaslangicTarihi.Name].Value) ;
                            newSchedule.EndTime =  Convert.ToDateTime(item.Cells[txtMHRSBitisTarihi.Name].Value) ;
                          
                            
                            
                            BindingList<MHRSActionTypeDefinition> actionTypeList = MHRSActionTypeDefinition.GetMHRSActionTypeDefByActionCode(objectContext,item.Cells[txtAksiyonKodu.Name].Value.ToString());
                            if(actionTypeList.Count > 0)
                                newSchedule.MHRSActionTypeDefinition = actionTypeList[0];

                            if (newSchedule.MHRSActionTypeDefinition.IsWorkingHour == true && newSchedule.MHRSActionTypeDefinition.OpenMHRS == true)
                            {
                                newSchedule.IsWorkHour = true;
                                newSchedule.ScheduleType = ScheduleTypeEnum.Timely;
                            }
                            else
                            {
                                newSchedule.IsWorkHour = false;
                                newSchedule.ScheduleType = ScheduleTypeEnum.NonWorkingHour;
                            }
                            newSchedule.SentToMHRS = true;

                            ScheduleAppointmentType type1 = (ScheduleAppointmentType)objectContext.CreateObject("ScheduleAppointmentType");
                            type1.AppointmentType = AppointmentTypeEnum.Consultation;
                            type1.Schedule = newSchedule;
                            
                            ScheduleAppointmentType type2 = (ScheduleAppointmentType)objectContext.CreateObject("ScheduleAppointmentType");
                            type2.AppointmentType = AppointmentTypeEnum.Examination;
                            type2.Schedule = newSchedule;
                            
                            ScheduleAppointmentType type3 = (ScheduleAppointmentType)objectContext.CreateObject("ScheduleAppointmentType");
                            type3.AppointmentType = AppointmentTypeEnum.ControlExamination;
                            type3.Schedule = newSchedule;

                            if (item.Cells[txtKesinCetvelID.Name].Value != null)
                                newSchedule.MHRSKesinCetvelID = Convert.ToInt64(item.Cells[txtKesinCetvelID.Name].Value);
                            
                            if(item.Cells[txtTalakCetvelID.Name].Value != null)
                                newSchedule.MHRSTaslakCetvelID = item.Cells[txtTalakCetvelID.Name].Value.ToString();
                            
                            objectContext.Save();
                        }
                    }
                }
                
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnEntegre_Click
        }

        private void btnListele_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnListele_Click
   gridMHRSPlanlari.Rows.Clear();
           // TTObjectContext context = new TTObjectContext(true);
            if (entegrasyonBaslangicTarihi == null)
            {
                InfoBox.Show("Başlangıç Tarihi Boş Geçilemez ! ");
                return;
            }
            if (entegrasyonBitisTarihi == null)
            {
                InfoBox.Show("Başlangıç Tarihi Boş Geçilemez ! ");
                return;
            }
            if (Convert.ToDateTime((entegrasyonBitisTarihi.NullableValue)) <= Convert.ToDateTime(entegrasyonBaslangicTarihi.NullableValue))
            {
                InfoBox.Show("Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! ");
                return;
            }
            
            if (listEntegrasyonDoktor.SelectedValue == null)
            {
                InfoBox.Show("Doktor Seçmediniz ! ");
                return;
            }
            
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            
            MHRSServis.KurumTaslakCetvelSorgulamaTalepType kurumTaslakCetvelSorgulamaTalep = new MHRSServis.KurumTaslakCetvelSorgulamaTalepType();
            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
            MHRSServis.TarihBilgileriType tarihBilgileri = new MHRSServis.TarihBilgileriType();
            MHRSServis.HekimBilgileriType hekimBilgileri = new MHRSServis.HekimBilgileriType();
            MHRSServis.KurumTaslakCetvelSorgulamaCevapType kurumTaslakCetvelSorgulamaCevap = new MHRSServis.KurumTaslakCetvelSorgulamaCevapType();

            MHRSServis.KurumKesinCetvelSorgulamaTalepType kurumKesinCetvelSorgulamaTalep = new MHRSServis.KurumKesinCetvelSorgulamaTalepType();
            MHRSServis.KurumKesinCetvelSorgulamaCevapType kurumKesinCetvelSorgulamaCevap = new MHRSServis.KurumKesinCetvelSorgulamaCevapType();

            TTObjectContext objectContext = new TTObjectContext(false);

            if (userName != null && password != null && MHRSKurumKodu != null)
            {
                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64((Common.CurrentUser.UniqueRefNo));
                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                kurumBilgileri.KurumKoduSpecified = true;
                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                kurumTaslakCetvelSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                kurumTaslakCetvelSorgulamaTalep.KurumBilgileri = kurumBilgileri;

                tarihBilgileri.BaslangicTarihi = Convert.ToDateTime(entegrasyonBaslangicTarihi.NullableValue).Date.ToString();
                tarihBilgileri.BitisTarihi = Convert.ToDateTime(entegrasyonBitisTarihi.NullableValue).Date.ToString();
                kurumTaslakCetvelSorgulamaTalep.TarihBilgileri = tarihBilgileri;

                hekimBilgileri.HekimKodu = ((ResUser)((TTListBox)this.listEntegrasyonDoktor).SelectedObject).UniqueNo;
                kurumTaslakCetvelSorgulamaTalep.HekimBilgileri = hekimBilgileri;

                kurumTaslakCetvelSorgulamaCevap = MHRSServis.WebMethods.KurumTaslakCetvelSorgulamaSync(Sites.SiteLocalHost, kurumTaslakCetvelSorgulamaTalep);
                if (kurumTaslakCetvelSorgulamaCevap != null && kurumTaslakCetvelSorgulamaCevap.TemelCevapBilgileri != null)
                {
                    if (kurumTaslakCetvelSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true && string.IsNullOrEmpty(kurumTaslakCetvelSorgulamaCevap.TemelCevapBilgileri.Aciklama) && kurumTaslakCetvelSorgulamaCevap.TaslakCetvelDetayBilgileri != null && kurumTaslakCetvelSorgulamaCevap.TaslakCetvelDetayBilgileri.Length > 0)
                    {
                        foreach (MHRSServis.KurumTaslakCetvelSorgulamaCevapTypeTaslakCetvelDetayBilgileri taslakCetvelDetayBilgileri in kurumTaslakCetvelSorgulamaCevap.TaslakCetvelDetayBilgileri)
                        {

                            BindingList<Schedule> scheduleList = Schedule.GrtScheduleByMHRSTaslakID(objectContext, taslakCetvelDetayBilgileri.TaslakCetvelId);

                            if (scheduleList.Count == 0)
                            {
                                ITTGridRow newRow = gridMHRSPlanlari.Rows.Add();
                                newRow.Cells[txtMHRSPoliklinik.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikAdi : null;
                                newRow.Cells[txtMHRSBaslangicTarihi.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BaslangicTarihi : null;
                                newRow.Cells[txtMHRSBitisTarihi.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BitisTarihi : null;
                                newRow.Cells[txtXXXXXXDurumu.Name].Value = "XXXXXX'da bulunamadı";
                                newRow.Cells[txtEntegrasyonDurumu.Name].Value = null;
                                newRow.Cells[txtTalakCetvelID.Name].Value = taslakCetvelDetayBilgileri.TaslakCetvelId;
                                newRow.Cells[txtKesinCetvelID.Name].Value = null;
                                newRow.Cells[txtKlinikKodu.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikKodu : 0;
                                newRow.Cells[txtAltKlinikKodu.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri.AltKlinikKodu : 0;
                                newRow.Cells[txtAksiyonKodu.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.AksiyonKodu : 0;
                                newRow.Cells[txtTedaviSuresi.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TedaviSuresi : 0;
                                newRow.Cells[txtTaslakID.Name].Value = null;
                                
                            }
                            else
                            {
                                ITTGridRow newRow = gridMHRSPlanlari.Rows.Add();
                                newRow.Cells[txtMHRSPoliklinik.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikAdi : null;
                                newRow.Cells[txtMHRSBaslangicTarihi.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BaslangicTarihi : null;
                                newRow.Cells[txtMHRSBitisTarihi.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BitisTarihi : null;
                                newRow.Cells[txtXXXXXXDurumu.Name].Value = "XXXXXX'da var";
                                newRow.Cells[txtEntegrasyonDurumu.Name].Value = null;
                                newRow.Cells[txtTalakCetvelID.Name].Value = taslakCetvelDetayBilgileri.TaslakCetvelId;
                                newRow.Cells[txtKesinCetvelID.Name].Value = null;
                                newRow.Cells[txtKlinikKodu.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikKodu : 0;
                                newRow.Cells[txtAltKlinikKodu.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null && taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri.AltKlinikKodu : 0;
                                newRow.Cells[txtAksiyonKodu.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.AksiyonKodu : 0;
                                newRow.Cells[txtTedaviSuresi.Name].Value = taslakCetvelDetayBilgileri.CetvelDetayBilgileri != null ? taslakCetvelDetayBilgileri.CetvelDetayBilgileri.TedaviSuresi : 0;
                                newRow.Cells[txtTaslakID.Name].Value = null;
                                
                            }
                        }
                    }
                    else
                        InfoBox.Show(kurumTaslakCetvelSorgulamaCevap.TemelCevapBilgileri.Aciklama);
                }



                kurumKesinCetvelSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                kurumKesinCetvelSorgulamaTalep.KurumBilgileri = kurumBilgileri;
                kurumKesinCetvelSorgulamaTalep.HekimBilgileri = hekimBilgileri;
                kurumKesinCetvelSorgulamaTalep.TarihBilgileri = tarihBilgileri;

                kurumKesinCetvelSorgulamaCevap = MHRSServis.WebMethods.KurumKesinCetvelSorgulamaSync(Sites.SiteLocalHost, kurumKesinCetvelSorgulamaTalep);
                if (kurumKesinCetvelSorgulamaCevap != null && kurumKesinCetvelSorgulamaCevap.TemelCevapBilgileri != null)
                {
                    if (kurumKesinCetvelSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true && string.IsNullOrEmpty(kurumKesinCetvelSorgulamaCevap.TemelCevapBilgileri.Aciklama) && kurumKesinCetvelSorgulamaCevap.KesinCetvelDetayBilgileri != null && kurumKesinCetvelSorgulamaCevap.KesinCetvelDetayBilgileri.Length > 0)
                    {
                        foreach (MHRSServis.KurumKesinCetvelSorgulamaCevapTypeKesinCetvelDetayBilgileri kesinCetvelDetayBilgileri in kurumKesinCetvelSorgulamaCevap.KesinCetvelDetayBilgileri)
                        {

                            BindingList<Schedule> scheduleList = Schedule.GrtScheduleByMHRSKesinCetvelID(objectContext, kesinCetvelDetayBilgileri.KesinCetvelId);

                            if (scheduleList.Count == 0)
                            {
                                ITTGridRow newRow = gridMHRSPlanlari.Rows.Add();
                                newRow.Cells[txtMHRSPoliklinik.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikAdi : null;
                                newRow.Cells[txtMHRSBaslangicTarihi.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BaslangicTarihi : null;
                                newRow.Cells[txtMHRSBitisTarihi.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BitisTarihi : null;
                                newRow.Cells[txtXXXXXXDurumu.Name].Value = "XXXXXX'da bulunamadı";
                                newRow.Cells[txtEntegrasyonDurumu.Name].Value = null;
                                newRow.Cells[txtTalakCetvelID.Name].Value = null;
                                newRow.Cells[txtKesinCetvelID.Name].Value = kesinCetvelDetayBilgileri.KesinCetvelId;
                                newRow.Cells[txtKlinikKodu.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikKodu : 0;
                                newRow.Cells[txtAltKlinikKodu.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri.AltKlinikKodu : 0;
                                newRow.Cells[txtAksiyonKodu.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.AksiyonKodu : 0;
                                newRow.Cells[txtTedaviSuresi.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TedaviSuresi : 0;
                                newRow.Cells[txtTaslakID.Name].Value = kesinCetvelDetayBilgileri.TaslakCetvelId != 0 ? kesinCetvelDetayBilgileri.TaslakCetvelId : 0;
                                
                            }
                            else
                            {
                                ITTGridRow newRow = gridMHRSPlanlari.Rows.Add();
                                newRow.Cells[txtMHRSPoliklinik.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikAdi : null;
                                newRow.Cells[txtMHRSBaslangicTarihi.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BaslangicTarihi : null;
                                newRow.Cells[txtMHRSBitisTarihi.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TarihBilgileri.BitisTarihi : null;
                                newRow.Cells[txtXXXXXXDurumu.Name].Value = "XXXXXX'da var";
                                newRow.Cells[txtEntegrasyonDurumu.Name].Value = null;
                                newRow.Cells[txtTalakCetvelID.Name].Value = null;
                                newRow.Cells[txtKesinCetvelID.Name].Value = kesinCetvelDetayBilgileri.KesinCetvelId;
                                newRow.Cells[txtKlinikKodu.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.KlinikKodu : 0;
                                newRow.Cells[txtAltKlinikKodu.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri != null && kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri != null? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.HekimKlinikBilgileri.AltKlinikBilgileri.AltKlinikKodu : 0;
                                newRow.Cells[txtAksiyonKodu.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.AksiyonKodu : 0;
                                newRow.Cells[txtTedaviSuresi.Name].Value = kesinCetvelDetayBilgileri.CetvelDetayBilgileri != null ? kesinCetvelDetayBilgileri.CetvelDetayBilgileri.TedaviSuresi : 0;
                                newRow.Cells[txtTaslakID.Name].Value = null;
                               
                            }
                        }
                    }
                    else
                        InfoBox.Show(kurumKesinCetvelSorgulamaCevap.TemelCevapBilgileri.Aciklama);
                }
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnListele_Click
        }

        private void btnAltKlinikSorgula_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnAltKlinikSorgula_Click
   gridAltKlinik.Rows.Clear();
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            
            MHRSServis.KurumKlinikSorgulamaTalepType kurumKlinikSorgulamaTalep = new MHRSServis.KurumKlinikSorgulamaTalepType();
            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
            MHRSServis.KurumKlinikSorgulamaCevapType kurumKlinikSorgulamaCevap = new MHRSServis.KurumKlinikSorgulamaCevapType();

            MHRSServis.KurumAltKlinikSorgulamaTalepType kurumAltKlinikSorgulamaTalep = new MHRSServis.KurumAltKlinikSorgulamaTalepType();
            MHRSServis.KurumAltKlinikSorgulamaCevapType kurumAltKlinikSorgulamaCevap = new MHRSServis.KurumAltKlinikSorgulamaCevapType();

            TTObjectContext objectContext = new TTObjectContext(false);

            if (userName != null && password != null && MHRSKurumKodu != null)
            {
                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64((Common.CurrentUser.UniqueRefNo));
                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                kurumBilgileri.KurumKoduSpecified = true;
                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                kurumKlinikSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                kurumKlinikSorgulamaTalep.KurumBilgileri = kurumBilgileri;

                kurumKlinikSorgulamaCevap = MHRSServis.WebMethods.KurumKlinikSorgulamaSync(Sites.SiteLocalHost, kurumKlinikSorgulamaTalep);
                if (kurumKlinikSorgulamaCevap != null && kurumKlinikSorgulamaCevap.TemelCevapBilgileri != null)
                {
                    if (kurumKlinikSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true && string.IsNullOrEmpty(kurumKlinikSorgulamaCevap.TemelCevapBilgileri.Aciklama) && kurumKlinikSorgulamaCevap.KlinikBilgileri != null && kurumKlinikSorgulamaCevap.KlinikBilgileri.Length > 0)
                    {
                        foreach (MHRSServis.KlinikBilgileriType klinikBilgileri in kurumKlinikSorgulamaCevap.KlinikBilgileri)
                        {
                            kurumAltKlinikSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                            kurumAltKlinikSorgulamaTalep.KurumBilgileri = kurumBilgileri;

                            kurumAltKlinikSorgulamaTalep.KlinikKodu = klinikBilgileri.KlinikKodu;

                            kurumAltKlinikSorgulamaCevap = MHRSServis.WebMethods.KurumAltKlinikSorgulamaSync(Sites.SiteLocalHost, kurumAltKlinikSorgulamaTalep);
                            if (kurumAltKlinikSorgulamaCevap != null && kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri != null)
                            {
                                if (kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true && string.IsNullOrEmpty(kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri.Aciklama) && kurumAltKlinikSorgulamaCevap.AltKlinikBilgileri != null && kurumAltKlinikSorgulamaCevap.AltKlinikBilgileri.Length > 0)
                                {
                                    foreach (MHRSServis.AltKlinikBilgileriType altKlinikBilgileri in kurumAltKlinikSorgulamaCevap.AltKlinikBilgileri)
                                    {
                                        ITTGridRow newRow = gridAltKlinik.Rows.Add();
                                        newRow.Cells[txtAltKlinikKlinik.Name].Value = "(" + klinikBilgileri.KlinikKodu + ")" + klinikBilgileri.KlinikAdi;
                                        newRow.Cells[txtAltKlinikAltKlinik.Name].Value = "(" + altKlinikBilgileri.AltKlinikKodu + ")" + altKlinikBilgileri.AltKlinikAdi;
                                    }
                                }
                                else
                                    InfoBox.Show(kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri.Aciklama);
                            }
                        }
                    }
                    else
                        InfoBox.Show(kurumKlinikSorgulamaCevap.TemelCevapBilgileri.Aciklama);
                }
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnAltKlinikSorgula_Click
        }

        private void btnHekimEkle_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnHekimEkle_Click
   string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");

            TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<ResUser.GetdoctorsForMHRS_Class> doctorList = ResUser.GetdoctorsForMHRS();
            
            foreach(ResUser.GetdoctorsForMHRS_Class doctor in doctorList)
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

                        kurumBilgileri.IslemYapanKisiTCNo =  Convert.ToInt64(MHRSIslemYapanKisiTC);
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
                            ITTGridRow newRow = gridMHRSHekim.Rows.Add();

                            if (kurumHekimEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                            {
                                newRow.Cells[txtHekimEklePoliklinik.Name].Value = doctor.Uzmanlikdali;
                                newRow.Cells[txtHekimEkleHekim.Name].Value = doctor.Doktoradi;
                                newRow.Cells[txtHekimEkleBilgi.Name].Value = "Eklendi";
                            }
                            else
                            {
                                newRow.Cells[txtHekimEklePoliklinik.Name].Value = doctor.Uzmanlikdali;
                                newRow.Cells[txtHekimEkleHekim.Name].Value = doctor.Doktoradi;
                                newRow.Cells[txtHekimEkleBilgi.Name].Value = kurumHekimEklemeCevap.TemelCevapBilgileri.Aciklama;
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnHekimEkle_Click
        }

        private void btnKlinikEkle_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnKlinikEkle_Click
   string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");


            TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetAllPoliclinics(objectContext);
            
            bool ekle = false;
            foreach(ResPoliclinic policlinic in policlinicList)
            {
                if(policlinic.IsActive == true && policlinic.MHRSCode != null && policlinic.MHRSAltKlinikKodu == null && gridMHRSPoliklinic.Rows.Count > 0)
                {
                    ekle = false;
                    foreach(ITTGridRow item in gridMHRSPoliklinic.Rows)
                    {
                        if(policlinic.Name == item.Cells[txtMHRSPoliklinic.Name].Value.ToString())
                        {
                            if (item.Cells[ckcMHRSyeGonder.Name].Value != null && Convert.ToBoolean(item.Cells[ckcMHRSyeGonder.Name].Value) == true)
                            {
                                ekle = true;
                                break;
                            }
                        }
                    }
                    
                    //ckcMHRSyeGonder
                    
                    if(ekle)
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

                            kurumBilgileri.IslemYapanKisiTCNo =  Convert.ToInt64(MHRSIslemYapanKisiTC);
                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                            kurumKlinikEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                            kurumKlinikEklemeTalep.KurumBilgileri = kurumBilgileri;
                            
                            kurumKlinikEklemeTalep.KlinikKodu = Convert.ToInt32(policlinic.MHRSCode);

                            kurumKlinikEklemeCevap = MHRSServis.WebMethods.KurumKlinikEklemeSync(Sites.SiteLocalHost, kurumKlinikEklemeTalep);
                            if (kurumKlinikEklemeCevap != null && kurumKlinikEklemeCevap.TemelCevapBilgileri != null)
                            {
                                ITTGridRow newRow = gridMHRSyeEklenenPoliklinikler.Rows.Add();
                                
                                if (kurumKlinikEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                {
                                    newRow.Cells[txtMHRSyeEklenenPoliklinic.Name].Value = policlinic.Name;
                                    newRow.Cells[txtMHRSyeEklendi.Name].Value = "Eklendi";
                                }
                                else
                                {
                                    newRow.Cells[txtMHRSyeEklenenPoliklinic.Name].Value = policlinic.Name;
                                    newRow.Cells[txtMHRSyeEklendi.Name].Value = kurumKlinikEklemeCevap.TemelCevapBilgileri.Aciklama;
                                }
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
#endregion MHRSRandevuPlanSorgulamaFormu_btnKlinikEkle_Click
        }

        private void btnAltKlinikEkle_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnAltKlinikEkle_Click
   string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");

            TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetAllPoliclinics(objectContext);
            
            foreach(ResPoliclinic policlinic in policlinicList)
            {
                if(policlinic.IsActive == true && policlinic.MHRSCode != null && policlinic.MHRSAltKlinikKodu == null && gridMHRSPoliklinic.Rows.Count > 0)
                {
                    bool ekle = true;
                    foreach(ITTGridRow item in gridMHRSPoliklinic.Rows)
                    {
                        if(policlinic.Name == item.Cells[txtMHRSPoliklinic.Name].Value.ToString() )
                        {
                            if (item.Cells[ckcMHRSyeGonder.Name].Value.ToString() == "true")
                            {
                                ekle = false;
                                break;
                            }
                        }
                    }
                    
                    
                    if(ekle)
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

                            kurumBilgileri.IslemYapanKisiTCNo =  Convert.ToInt64(MHRSIslemYapanKisiTC);
                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                            kurumAltKlinikEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                            kurumAltKlinikEklemeTalep.KurumBilgileri = kurumBilgileri;
                            
                            kurumAltKlinikEklemeTalep.KlinikKodu = Convert.ToInt32(policlinic.MHRSCode);
                            kurumAltKlinikEklemeTalep.AltKlinikAdi = policlinic.Name + "1";

                            kurumAltKlinikEklemeCevap = MHRSServis.WebMethods.KurumAltKlinikEklemeSync(Sites.SiteLocalHost, kurumAltKlinikEklemeTalep);
                            if (kurumAltKlinikEklemeCevap != null && kurumAltKlinikEklemeCevap.TemelCevapBilgileri != null)
                            {
                                ITTGridRow newRow = gridMHRSyeEklenenAltPoliklinikler.Rows.Add();
                                if (kurumAltKlinikEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true )
                                {
                                    policlinic.MHRSAltKlinikKodu = kurumAltKlinikEklemeCevap.AltKlinikKodu;
                                    
                                    newRow.Cells[txtMHRSyeEklenenAltPoliklinic.Name].Value = policlinic.Name;
                                    newRow.Cells[txtMHRSyeEklendiAltKlinik.Name].Value = "Eklendi";
                                }
                                else
                                {
                                    newRow.Cells[txtMHRSyeEklenenAltPoliklinic.Name].Value = policlinic.Name;
                                    newRow.Cells[txtMHRSyeEklendiAltKlinik.Name].Value = kurumAltKlinikEklemeCevap.TemelCevapBilgileri.Aciklama;
                                }
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
            
            objectContext.Save();
#endregion MHRSRandevuPlanSorgulamaFormu_btnAltKlinikEkle_Click
        }

        private void btnSetMHRSClinicCode_Click()
        {
#region MHRSRandevuPlanSorgulamaFormu_btnSetMHRSClinicCode_Click
   TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetAllPoliclinics(objectContext);
            
            foreach(ResPoliclinic policlinic in policlinicList)
            {
                if(policlinic.IsActive == true && policlinic.ResourceSpecialities != null && policlinic.ResourceSpecialities.Count > 0 )
                {
                    if( policlinic.ResourceSpecialities[0].Speciality != null &&  policlinic.ResourceSpecialities[0].Speciality.IsMHRSClinic == true &&  policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik != null)
                    {
                        policlinic.MHRSCode = Convert.ToInt32(policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU);
                        
                        ITTGridRow newRow = gridMHRSPoliklinic.Rows.Add();
                        newRow.Cells[txtMHRSPoliklinic.Name].Value = policlinic.Name;
                        newRow.Cells[txtMHRSPoliklinicMHRSClinic.Name].Value = policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU + " : " + policlinic.ResourceSpecialities[0].Speciality.SKRSKlinik.ADI;
                        newRow.Cells[ckcMHRSyeGonder.Name].Value = true;
                    }
                }
            }
            objectContext.Save();
#endregion MHRSRandevuPlanSorgulamaFormu_btnSetMHRSClinicCode_Click
        }

        private void btnAltKlinikAktar_Click()
        {
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");

            if (userName != null && password != null && MHRSKurumKodu != null)
            {
                MHRSServis.KurumAltKlinikSorgulamaTalepType kurumAltKlinikSorgulamaTalep = new MHRSServis.KurumAltKlinikSorgulamaTalepType();
                MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                MHRSServis.KurumAltKlinikSorgulamaCevapType kurumAltKlinikSorgulamaCevap = new MHRSServis.KurumAltKlinikSorgulamaCevapType();

                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                kurumBilgileri.KurumKoduSpecified = true;
                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                kurumAltKlinikSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                kurumAltKlinikSorgulamaTalep.KurumBilgileri = kurumBilgileri;

                TTObjectContext objectContext = new TTObjectContext(false);
                BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetAllPoliclinics(objectContext);

                foreach (ResPoliclinic policlinic in policlinicList)
                {
                    if (policlinic.IsActive == true && policlinic.MHRSCode != null && policlinic.MHRSAltKlinikKodu == null)
                    {
                        kurumAltKlinikSorgulamaTalep.KlinikKodu = Convert.ToInt32(policlinic.MHRSCode);

                        kurumAltKlinikSorgulamaCevap = MHRSServis.WebMethods.KurumAltKlinikSorgulamaSync(Sites.SiteLocalHost, kurumAltKlinikSorgulamaTalep);
                        if (kurumAltKlinikSorgulamaCevap != null && kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri != null)
                        {
                            if (kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true && kurumAltKlinikSorgulamaCevap.AltKlinikBilgileri != null)
                            {
                                policlinic.MHRSAltKlinikKodu = kurumAltKlinikSorgulamaCevap.AltKlinikBilgileri[0].AltKlinikKodu;
                            }
                        }
                    }
                }
                objectContext.Save();
            }
        }

    }
}