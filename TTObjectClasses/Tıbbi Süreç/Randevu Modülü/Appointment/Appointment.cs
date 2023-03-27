
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
    /// Randevu
    /// </summary>
    public partial class Appointment : TTObject, IAppointmentPermission
    {
        public partial class GetAppointmentListReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetAppointmentByPatientExaminationID_Class : TTReportNqlObject
        {
        }

        public partial class GetAppointmentsForAppViewer_Class : TTReportNqlObject
        {
        }

        public partial class GetMinNumaratorAppointmentResource_Class : TTReportNqlObject
        {
        }

        public partial class GetAppointmentByResourceAndPatient_Class : TTReportNqlObject
        {
        }

        public partial class GetMHRSAppointment_Class : TTReportNqlObject
        {
        }

        public partial class GetBreakAppointmentListReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetAppointmentBySchedule_Class : TTReportNqlObject
        {
        }

        public partial class VEM_RANDEVU_Class : TTReportNqlObject
        {
        }

        #region IAppointmentPermission Members

        public Resource GetMasterResource()
        {
            return MasterResource;
        }

        public void SetMasterResource(Resource value)
        {
            MasterResource = value;
        }
        #endregion

        protected override void PreInsert()
        {
            #region PreInsert



            base.PreInsert();


            if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE" && !(Action is MHRSAdmissionAppointment) && Schedule != null && Schedule.SentToMHRS == true)
            {
                if (Schedule.MHRSKesinCetvelID != null && Schedule.MHRSActionTypeDefinition.OpenMHRS == true)
                {
                    try
                    {
                        if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                        {
                            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "");
                            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

                            MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                            MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();


                            if (userName != null && password != null && MHRSKurumKodu != null)
                            {
                                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                                if (Resource is ResUser)
                                {
                                    kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(((ResUser)Resource).UniqueNo);
                                }

                                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                kurumBilgileri.KurumKoduSpecified = true;
                                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                                MHRSRandevuEkleme(yetkilendirmeGirisBilgileri, kurumBilgileri);
                            }
                        }
                        else
                        {
                            MHRSRandevuEkleme_V2();
                        }
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }

                }
                if (Schedule != null && Schedule.MHRSKesinCetvelID == null && Schedule.MHRSTaslakCetvelID != null)
                    throw new TTException(TTUtils.CultureService.GetText("M26730", "Randevu planı MHRS'ye bildirilmiş ama kesinleştirilmemiş, randevu veremezsiniz!"));
            }

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            bool createQueueItem = false;
            if (AppointmentDefinition.GiveToMaster.HasValue == true && AppointmentDefinition.GiveToMaster.Value == true)
            {
                if (Resource != null)
                {
                    if (Resource is ResPoliclinic && ((ResPoliclinic)Resource).PatientCallSystemInUse == true)
                        createQueueItem = true;
                    else if (Resource is ResHealthCommittee && ((ResHealthCommittee)Resource).PCSInUse == true)
                        createQueueItem = true;
                    else if (Resource is ResSection && ((ResSection)Resource).PCSInUse == true)
                        createQueueItem = true;
                }
            }
            else
            {
                if (MasterResource != null)
                {
                    if (MasterResource is ResPoliclinic && ((ResPoliclinic)MasterResource).PatientCallSystemInUse == true)
                        createQueueItem = true;
                    else if (MasterResource is ResHealthCommittee && ((ResHealthCommittee)MasterResource).PCSInUse == true)
                        createQueueItem = true;
                    else if (MasterResource is ResSection && ((ResSection)MasterResource).PCSInUse == true)
                        createQueueItem = true;
                }
            }

            if (createQueueItem)
            {
                if (ExaminationQueueItem.Count <= 0)
                {
                    if (EpisodeAction != null && EpisodeAction.HasActiveQueueItem())
                    {
                        ExaminationQueueItem queueItem = EpisodeAction.GetActiveQueueItem(true);
                        if (queueItem != null)
                            CreateOrUpdateExaminationQueueItem(queueItem);
                        else
                            CreateOrUpdateExaminationQueueItem(null);
                    }
                    else
                    {
                        CreateOrUpdateExaminationQueueItem(null);
                    }
                }
                else
                    CreateOrUpdateExaminationQueueItem((ExaminationQueueItem)ExaminationQueueItem[0]);
            }
            ////Randevu notlarına randevu verilen işlemin hizmet adı eklenir.
            //if(this.SubActionProcedure != null && this.SubActionProcedure.ProcedureObject != null)
            //{
            //    this.Notes += "İşlem : " + this.SubActionProcedure.ProcedureObject.Name;
            //}

            //Kullanılmıyor
            //#region Radyoloji Randevu SMS
            //if (AppointmentDefinition.AppointmentDefinitionID == 4)//Radyoloji için randevu işlemlerinde SMS
            //{
            //    try
            //    {
            //        TTObjectContext objContext = new TTObjectContext(false);

            //        string messageText = "";

            //        RadiologyTest radiologyTest = (RadiologyTest)objContext.GetObject((Guid)SubActionProcedure.ObjectID, SubActionProcedure.ObjectDef);
            //        RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)radiologyTest.ProcedureObject;
            //        if (radTestDef.RadiologyTestDescriptions.Count > 0)
            //        {
            //            string procedureInst = "";
            //            foreach (RadiologyGridTestDescriptionDefinition RadGridTestDef in radTestDef.RadiologyTestDescriptions)
            //            {
            //                procedureInst = procedureInst + RadGridTestDef.TestDescription?.Description?.ToString() + "\n";
            //            }

            //            messageText += procedureInst;
            //        }
            //        UserMessage userMessage = new UserMessage();
            //        if (!string.IsNullOrEmpty(messageText))
            //            userMessage.SendSMSPatient(Patient, messageText);

            //    }
            //    catch (Exception)
            //    {

            //    }
            //}
            //#endregion


            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate





            base.PreUpdate();

            if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE" && Schedule != null && Schedule.SentToMHRS == true)
            {
                string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "");
                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

                if ((TransDef == null && AppointmentUpdate == true) || (TransDef != null && TransDef.ToStateDefID == Appointment.States.Cancelled && CancelledMHRS != true))
                {
                    MHRSServis.RandevuIptalTalepType randevuIptalTalep = new MHRSServis.RandevuIptalTalepType();
                    MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                    MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                    MHRSServis.RandevuIptalCevapType randevuIptalCevap = new MHRSServis.RandevuIptalCevapType();

                    try
                    {
                        if (userName != null && password != null && MHRSKurumKodu != null && MHRSRandevuHrn != null)
                        {
                            if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                            {
                            yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                            yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                            yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi
                            randevuIptalTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;

                            if (Resource is ResUser)
                            {
                                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(((ResUser)Resource).UniqueNo);
                            }

                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                            randevuIptalTalep.KurumBilgileri = kurumBilgileri;

                            randevuIptalTalep.RandevuHrn = MHRSRandevuHrn;

                            randevuIptalCevap = MHRSServis.WebMethods.RandevuIptalSync(Sites.SiteLocalHost, randevuIptalTalep);

                            if (randevuIptalCevap != null && randevuIptalCevap.TemelCevapBilgileri != null)
                            {
                                if (randevuIptalCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                {
                                    MHRSRandevuHrn = null;
                                    MHRSHastaGeldi = false;
                                    if (AppointmentUpdate == true)
                                    {

                                        MHRSServis.RandevuEklemeTalepType randevuEklemeTalep = new MHRSServis.RandevuEklemeTalepType();
                                        MHRSServis.RandevuZamanBilgisiType randevuZamanBilgisi = new MHRSServis.RandevuZamanBilgisiType();
                                        MHRSServis.VatandasBilgileriType vatandasBilgileri = new MHRSServis.VatandasBilgileriType();
                                        MHRSServis.VatandasIletisimBilgileriType vatandasIletisimBilgileri = new MHRSServis.VatandasIletisimBilgileriType();
                                        MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri1 = new MHRSServis.TelefonIletisimBilgileriType();
                                        MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri2 = new MHRSServis.TelefonIletisimBilgileriType();
                                        MHRSServis.RandevuEklemeCevapType randevuEklemeCevap = new MHRSServis.RandevuEklemeCevapType();

                                        randevuEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                                        randevuEklemeTalep.KurumBilgileri = kurumBilgileri;

                                        randevuZamanBilgisi.RandevuBaslangicZamani = StartTime.ToString();
                                        randevuZamanBilgisi.RandevuBitisZamani = EndTime.ToString();
                                        randevuEklemeTalep.RandevuZamanBilgisi = randevuZamanBilgisi;

                                        randevuEklemeTalep.KesinCetvelId = Schedule.MHRSKesinCetvelID != null ? Convert.ToInt64(Schedule.MHRSKesinCetvelID) : 0;

                                        if (vatandasIletisimBilgileri.TelefonIletisimBilgileri == null)
                                            vatandasIletisimBilgileri.TelefonIletisimBilgileri = new MHRSServis.TelefonIletisimBilgileriType[1];

                                        if (Patient != null)
                                        {
                                            if (Patient.PatientAddress.HomePhone != null)
                                            {
                                                if (Patient.PatientAddress.HomePhone.Length == 10)
                                                {
                                                    telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.HomePhone.Substring(0, 3);
                                                    telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.HomePhone.Substring(3, 7);
                                                }
                                                else if (Patient.PatientAddress.HomePhone.Length == 11)
                                                {
                                                    telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.HomePhone.Substring(0, 3);
                                                    telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.HomePhone.Substring(4, 7);
                                                }
                                                else if (Patient.PatientAddress.HomePhone.Length == 12)
                                                {
                                                    telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.HomePhone.Substring(1, 3);
                                                    telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.HomePhone.Substring(5, 7);
                                                }

                                                BindingList<MobilePhoneCodeDefinition> mobilePhoneCodeDefList = MobilePhoneCodeDefinition.MobilePhoneCodeDefByCode(ObjectContext, telefonIletisimBilgileri2.AlanKodu);
                                                if (mobilePhoneCodeDefList.Count == 0)
                                                    telefonIletisimBilgileri2.NumaraTipi = 1;
                                                else
                                                    telefonIletisimBilgileri2.NumaraTipi = 3;

                                                vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;

                                            }

                                            if ((vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo)) && Patient.PatientAddress.MobilePhone != null)
                                            {
                                                if (Patient.PatientAddress.MobilePhone.Length == 10)
                                                {
                                                    telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.MobilePhone.Substring(0, 3);
                                                    telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.MobilePhone.Substring(3, 7);
                                                }
                                                else if (Patient.PatientAddress.MobilePhone.Length == 11)
                                                {

                                                    telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.MobilePhone.Substring(0, 3);
                                                    telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.MobilePhone.Substring(4, 7);
                                                }
                                                else if (Patient.PatientAddress.MobilePhone.Length == 12)
                                                {
                                                    telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.MobilePhone.Substring(1, 3);
                                                    telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.MobilePhone.Substring(5, 7);
                                                }

                                                BindingList<MobilePhoneCodeDefinition> mobilePhoneCodeDefList = MobilePhoneCodeDefinition.MobilePhoneCodeDefByCode(ObjectContext, telefonIletisimBilgileri2.AlanKodu);
                                                if (mobilePhoneCodeDefList.Count == 0)
                                                    telefonIletisimBilgileri2.NumaraTipi = 1;
                                                else
                                                    telefonIletisimBilgileri2.NumaraTipi = 3;

                                                vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;

                                            }

                                            if (vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo))
                                            {
                                                if (Action is AdmissionAppointment)
                                                {
                                                    if (((AdmissionAppointment)Action).PatientPhone != null)
                                                    {
                                                        if (((AdmissionAppointment)Action).PatientPhone.Length == 10)
                                                        {
                                                            telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                                            telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(3, 7);
                                                        }
                                                        else if (((AdmissionAppointment)Action).PatientPhone.Length == 11)
                                                        {
                                                            telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                                            telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(4, 7);
                                                        }
                                                        else if (((AdmissionAppointment)Action).PatientPhone.Length == 12)
                                                        {
                                                            telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(1, 3);
                                                            telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(5, 7);
                                                        }

                                                        if (((AdmissionAppointment)Action).PhoneType == PhoneTypeEnum.Home)
                                                            telefonIletisimBilgileri2.NumaraTipi = 1;
                                                        else
                                                            telefonIletisimBilgileri2.NumaraTipi = 3;

                                                        vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;
                                                    }
                                                }
                                            }

                                            if (vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo))
                                                throw new TTException(TTUtils.CultureService.GetText("M25837", "Hastanın telefon bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!"));

                                            vatandasIletisimBilgileri.Email = Patient.EMail;
                                            vatandasBilgileri.VatandasIletisimBilgileri = vatandasIletisimBilgileri;

                                            vatandasBilgileri.Ad = Patient.Name;
                                            vatandasBilgileri.Soyad = Patient.Surname;
                                            vatandasBilgileri.TCKimlikNo = Patient.UniqueRefNo != null ? Patient.UniqueRefNo.ToString() : null;
                                            vatandasBilgileri.DogumTarihi = Patient.BirthDate != null ? Patient.BirthDate.Value.ToShortDateString() : null;
                                            vatandasBilgileri.DogumYeri = Patient.BirthPlace != null ? Patient.BirthPlace : null;
                                            vatandasIletisimBilgileri.Email = Patient.EMail;
                                        }
                                        else
                                        {

                                            if (Action is AdmissionAppointment)
                                            {
                                                if (((AdmissionAppointment)Action).PatientPhone != null)
                                                {
                                                    if (((AdmissionAppointment)Action).PatientPhone.Length == 10)
                                                    {
                                                        telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                                        telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(3, 7);
                                                    }
                                                    else if (((AdmissionAppointment)Action).PatientPhone.Length == 11)
                                                    {
                                                        telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                                        telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(4, 7);
                                                    }
                                                    else if (((AdmissionAppointment)Action).PatientPhone.Length == 12)
                                                    {
                                                        telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(1, 3);
                                                        telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(5, 7);
                                                    }

                                                    if (((AdmissionAppointment)Action).PhoneType == PhoneTypeEnum.Home)
                                                        telefonIletisimBilgileri2.NumaraTipi = 1;
                                                    else
                                                        telefonIletisimBilgileri2.NumaraTipi = 3;

                                                    vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;
                                                }

                                                vatandasBilgileri.VatandasIletisimBilgileri = vatandasIletisimBilgileri;

                                                vatandasBilgileri.Ad = ((AdmissionAppointment)Action).PatientName;
                                                vatandasBilgileri.Soyad = ((AdmissionAppointment)Action).PatientSurname;
                                                vatandasBilgileri.TCKimlikNo = ((AdmissionAppointment)Action).PatientUniqueRefNo != null ? ((AdmissionAppointment)Action).PatientUniqueRefNo.ToString() : null;
                                                //vatandasBilgileri.DogumTarihi = (Patient != null && Patient.BirthDate != null) ? Patient.BirthDate.Value.ToShortDateString() : null;
                                                //vatandasBilgileri.DogumYeri = (Patient != null && Patient.BirthPlace != null) ? Patient.BirthPlace : null;
                                            }

                                            if (vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo))
                                                throw new TTException(TTUtils.CultureService.GetText("M25837", "Hastanın telefon bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!"));
                                        }
                                        randevuEklemeTalep.VatandasBilgileri = vatandasBilgileri;

                                        randevuEklemeCevap = MHRSServis.WebMethods.RandevuEklemeSync(Sites.SiteLocalHost, randevuEklemeTalep);

                                        if (randevuEklemeCevap != null && randevuEklemeCevap.TemelCevapBilgileri != null)
                                        {
                                            if (randevuEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                            {

                                                MHRSRandevuHrn = randevuEklemeCevap.RandevuHrn;
                                            }
                                            else if (randevuEklemeCevap.TemelCevapBilgileri != null)
                                            {
                                                string hata = string.Empty;
                                                hata = randevuEklemeCevap.TemelCevapBilgileri.Aciklama;
                                                TTUtils.InfoMessageService.Instance.ShowMessage("MHRS Bildirim Hatası : " + hata + TTUtils.CultureService.GetText("M26727", "Randevu MHRS'den silindi ama yenisi alınamadı. Yeni randevu veriniz!"));
                                                CurrentStateDefID = Appointment.States.Cancelled;
                                            }
                                        }
                                        else
                                        {
                                            TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26523", "MHRS'ye bildirilirken hata oluştu ! Randevu MHRS'den silindi ama yenisi alınamadı. Yeni randevu veriniz!"));
                                            CurrentStateDefID = Appointment.States.Cancelled;
                                        }
                                        //MHRSRandevuEkleme(yetkilendirmeGirisBilgileri,kurumBilgileri );


                                    }
                                    else
                                        Schedule = null;
                                }
                                else if (randevuIptalCevap.TemelCevapBilgileri != null)
                                {
                                    string hata = string.Empty;
                                    hata = randevuIptalCevap.TemelCevapBilgileri.Aciklama;

                                    throw new TTException("MHRS Bildirim Hatası : " + hata);
                                }
                            }
                            else
                                throw new TTException("MHRS'ye bildirilirken hata oluştu !");

                            AppointmentUpdate = false;
                        }
                        else
                        {

                                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                                MHRSRandevuIptal_Input randevu_Iptal = new MHRSRandevuIptal_Input();
                                randevu_Iptal.hastaRandevuNumarasi = MHRSRandevuHrn;
                                randevu_Iptal.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                randevu_Iptal.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);

                                string serializedObj = JsonConvert.SerializeObject(randevu_Iptal);

                                Schedule schedule = new Schedule();
                                string accessToken = schedule.LoginForMHRS();

                                Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/randevu/randevu-iptal");

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

                                if (response.IsSuccessful)
                                {
                                    var result = JsonConvert.DeserializeObject<MHRSRandevuIptal_Output>(response.Content);
                                    MHRSRandevuHrn = null;
                                    MHRSHastaGeldi = false;
                                    if (AppointmentUpdate == true)
                                    {
                                        MHRSRandevuEkleme_V2();
                                    }
                                    else
                                        Schedule = null;
                                }
                                else if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
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

                                AppointmentUpdate = false;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // InfoBox.Show(ex);
                        throw;
                    }
                }

                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSHASTAGELDIKABULDEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    if (TransDef != null && TransDef.ToStateDefID == Appointment.States.Completed)
                    {
                        MHRSServis.RandevuDurumGuncelleTalepType randevuDurumGuncelleTalep = new MHRSServis.RandevuDurumGuncelleTalepType();
                        MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                        MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                        MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri randevuBilgileri = new MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri();
                        MHRSServis.RandevuDurumGuncelleCevapType randevuDurumGuncelleCevap = new MHRSServis.RandevuDurumGuncelleCevapType();

                        if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
                        {
                            try
                            {
                                if (userName != null && password != null && MHRSKurumKodu != null)
                                {
                                    yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                                    yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                                    yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi
                                    randevuDurumGuncelleTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;

                                    if (Resource is ResUser)
                                    {
                                        kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(((ResUser)Resource).UniqueNo);
                                    }

                                    kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                                    kurumBilgileri.KurumKoduSpecified = true;
                                    kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                                    randevuDurumGuncelleTalep.KurumBilgileri = kurumBilgileri;

                                    randevuBilgileri.RandevuHrn = MHRSRandevuHrn;
                                    randevuBilgileri.GelisZamani = DateTime.Now.ToString();
                                    randevuBilgileri.RandevuGerceklesmeZamani = DateTime.Now.ToString();
                                    randevuBilgileri.DurumKodu = 1;
                                    if (randevuDurumGuncelleTalep.RandevuBilgileri == null)
                                        randevuDurumGuncelleTalep.RandevuBilgileri = new MHRSServis.RandevuDurumGuncelleTalepTypeRandevuBilgileri[1];

                                    randevuDurumGuncelleTalep.RandevuBilgileri[0] = randevuBilgileri;

                                    randevuDurumGuncelleCevap = MHRSServis.WebMethods.RandevuDurumGuncelleSync(Sites.SiteLocalHost, randevuDurumGuncelleTalep);

                                    if (randevuDurumGuncelleCevap != null && randevuDurumGuncelleCevap.TemelCevapBilgileri != null)
                                    {
                                        if (randevuDurumGuncelleCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                            MHRSHastaGeldi = true;

                                        if (randevuDurumGuncelleCevap.RandevuDurumSonuc != null)
                                        {
                                            MHRSServis.RandevuDurumSonucType hataVar = randevuDurumGuncelleCevap.RandevuDurumSonuc.Where(t => t.GuncellemeBasarisi == false).FirstOrDefault();
                                            if (hataVar != null)
                                            {

                                                foreach (MHRSServis.RandevuDurumSonucType randevuDurumSonuc in randevuDurumGuncelleCevap.RandevuDurumSonuc)
                                                {
                                                    if (!randevuDurumSonuc.GuncellemeBasarisi)
                                                    {
                                                        if (randevuDurumSonuc.Aciklama == "Randevunun durumu zaten 2 olduğu için değiştirilmedi.")
                                                            MHRSHastaGeldi = false;
                                                        else if (randevuDurumSonuc.Aciklama == "Randevunun durumu zaten 1 olduğu için değiştirilmedi.")
                                                            MHRSHastaGeldi = true;
                                                        else if (randevuDurumSonuc.Aciklama == "Randevu iptal edildiği için geldi/gelmedi bilgisi güncellenemez.")
                                                            MHRSHastaGeldi = false;
                                                        else
                                                            MHRSHastaGeldi = null;
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    else if (randevuDurumGuncelleCevap.TemelCevapBilgileri != null)
                                    {
                                        string hata = string.Empty;
                                        hata = randevuDurumGuncelleCevap.TemelCevapBilgileri.Aciklama;

                                        throw new TTException("MHRS Bildirim Hatası : " + hata);
                                    }
                                }
                                else
                                    throw new TTException("MHRS'ye bildirilirken hata oluştu !");
                            }
                            catch (Exception ex)
                            {
                                // InfoBox.Show(ex);
                                throw;
                            }
                        }
                        else
                        {
                            HbysRandevuGerceklesmeBilgisiTalep hbysRandevuGerceklesmeBilgisiTalep = new HbysRandevuGerceklesmeBilgisiTalep();
                            hbysRandevuGerceklesmeBilgisiTalep.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            hbysRandevuGerceklesmeBilgisiTalep.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);

                            hbysRandevuGerceklesmeBilgisiTalep.randevuGerceklesmeBilgisiEklemeTalepList = new List<HbysRandevuGerceklesmeBilgisiEklemeTalep>();
                            HbysRandevuGerceklesmeBilgisiEklemeTalep tempEklemeTalep = new HbysRandevuGerceklesmeBilgisiEklemeTalep();
                            tempEklemeTalep.hastaRandevuNumarasi = MHRSRandevuHrn;
                            tempEklemeTalep.hastaGelisZamani = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            tempEklemeTalep.randevuGerceklesmeZamani = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            tempEklemeTalep.randevuGerceklesmeBilgisi = 1;

                            hbysRandevuGerceklesmeBilgisiTalep.randevuGerceklesmeBilgisiEklemeTalepList.Add(tempEklemeTalep);

                            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");
                            string serializedObj = JsonConvert.SerializeObject(hbysRandevuGerceklesmeBilgisiTalep);


                            Schedule sch = new Schedule();
                            string accessToken = sch.LoginForMHRS();

                            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/randevu/randevu-gerceklesme-bilgisi");

                            var client = new RestClient(uri);

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
                                var perfResult = JsonConvert.DeserializeObject<RandevuGerceklesme_Output>(response.Content);
                                if (perfResult.infos != null)
                                {
                                    if (perfResult.infos[0].mesaj == "Güncelleme işlemi başarıyla gerçekleştirilmiştir." || perfResult.infos[0].kodu == "RND6032")
                                    {
                                        if (tempEklemeTalep.randevuGerceklesmeBilgisi == 1)
                                            MHRSHastaGeldi = true;
                                        else if (tempEklemeTalep.randevuGerceklesmeBilgisi == 0)
                                            MHRSHastaGeldi = false;
                                        else
                                            MHRSHastaGeldi = null;
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
                                    MHRSHastaGeldi = false;
                                else if (detailedError == "Randevunun durumu zaten 1 olduğu için değiştirilmedi.")
                                    MHRSHastaGeldi = true;
                                else if (detailedError == "Randevu iptal edildiği için geldi/gelmedi bilgisi güncellenemez.")
                                    MHRSHastaGeldi = false;
                                else
                                    MHRSHastaGeldi = null;
                            }
                        }
                    }
                }
            }

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();

            bool createQueueItem = false;
            if (AppointmentDefinition.GiveToMaster.HasValue == true && AppointmentDefinition.GiveToMaster.Value == true)
            {
                if (Resource != null)
                {
                    if (Resource is ResPoliclinic && ((ResPoliclinic)Resource).PatientCallSystemInUse == true)
                        createQueueItem = true;
                    else if (Resource is ResHealthCommittee && ((ResHealthCommittee)Resource).PCSInUse == true)
                        createQueueItem = true;
                    else if (Resource is ResSection && ((ResSection)Resource).PCSInUse == true)
                        createQueueItem = true;
                }
            }
            else
            {
                if (MasterResource != null)
                {
                    if (MasterResource is ResPoliclinic && ((ResPoliclinic)MasterResource).PatientCallSystemInUse == true)
                        createQueueItem = true;
                    else if (MasterResource is ResHealthCommittee && ((ResHealthCommittee)MasterResource).PCSInUse == true)
                        createQueueItem = true;
                    else if (MasterResource is ResSection && ((ResSection)MasterResource).PCSInUse == true)
                        createQueueItem = true;
                }
            }

            if (createQueueItem)
            {
                if (ExaminationQueueItem.Count <= 0)
                {
                    if (EpisodeAction != null && EpisodeAction.HasActiveQueueItem())
                    {
                        ExaminationQueueItem queueItem = EpisodeAction.GetActiveQueueItem(true);
                        if (queueItem != null)
                            CreateOrUpdateExaminationQueueItem(queueItem);
                        else
                            CreateOrUpdateExaminationQueueItem(null);
                    }
                    else
                    {
                        if (TransDef == null || (TransDef != null && TransDef.ToStateDefID != Appointment.States.Cancelled))
                            CreateOrUpdateExaminationQueueItem(null);
                    }
                }
                else
                    CreateOrUpdateExaminationQueueItem((ExaminationQueueItem)ExaminationQueueItem[0]);
            }

            //UpdateQuota();
            #endregion PostUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete
            base.PreDelete();
            #endregion PreDelete
        }

        protected override void PostDelete()
        {
            #region PostDelete
            base.PostDelete();

            //UpdateQuota();
            #endregion PostDelete
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PostTransition_New2Completed

            //this.CompleteMyExaminationQueueItems();
            #endregion PostTransition_New2Completed
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled

            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_NotApproved2Completed()
        {
            // From State : NotApproved   To State : Completed
            #region PostTransition_NotApproved2Completed

            //this.CompleteMyExaminationQueueItems();
            #endregion PostTransition_NotApproved2Completed
        }

        protected void PostTransition_NotApproved2Cancelled()
        {
            // From State : NotApproved   To State : Cancelled
            #region PostTransition_NotApproved2Cancelled

            Cancel();
            #endregion PostTransition_NotApproved2Cancelled
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Appointment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Appointment.States.Completed && toState == Appointment.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == Appointment.States.New && toState == Appointment.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == Appointment.States.New && toState == Appointment.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == Appointment.States.NotApproved && toState == Appointment.States.Completed)
                PostTransition_NotApproved2Completed();
            else if (fromState == Appointment.States.NotApproved && toState == Appointment.States.Cancelled)
                PostTransition_NotApproved2Cancelled();
        }

        #region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            //ITTObject ttObject = (ITTObject)this;
            //if(ttObject.IsNew)
            //{
            //    this.AppointmentID.GetNextValue();
            //}
            //if(this.IsNumarator==null)
            //    this.IsNumarator=false;
        }

        public void CreateOrUpdateExaminationQueueItem(ExaminationQueueItem examQueueItem)
        {
            if (Patient != null)
            {
                ExaminationQueueItem queueItem = null;
                if (examQueueItem == null)
                {
                    queueItem = (ExaminationQueueItem)ObjectContext.CreateObject(typeof(ExaminationQueueItem).Name);
                    queueItem.Appointment = this;
                    queueItem.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.New;
                    queueItem.Patient = Patient;
                    queueItem.Priority = 0;
                    queueItem.ExaminationQueueDefinition = null;
                    queueItem.CallCount = 0;
                }
                else
                {
                    if (examQueueItem.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        queueItem = examQueueItem;
                }
                if (queueItem != null)
                {
                    queueItem.Appointment = this;
                    queueItem.Priority = 0;
                    queueItem.CallCount = 0;
                    if (Action != null && Action is EpisodeAction)
                        queueItem.EpisodeAction = (EpisodeAction)Action;
                    else
                        queueItem.EpisodeAction = EpisodeAction;
                    if (SubActionProcedure != null && SubActionProcedure is SubactionProcedureFlowable)
                    {
                        queueItem.SubactionProcedureFlowable = (SubactionProcedureFlowable)SubActionProcedure;
                        queueItem.EpisodeAction = SubActionProcedure.EpisodeAction;
                    }
                    queueItem.QueueDate = AppDate;
                    queueItem.CallTime = StartTime;
                    queueItem.DivertedTime = StartTime;
                    if (Resource != null && Resource is ResUser)
                        queueItem.Doctor = (ResUser)Resource;
                    else
                    {
                        if (SubActionProcedure != null && ((SubActionProcedure)SubActionProcedure).ProcedureDoctor != null)
                        {
                            queueItem.Doctor = ((SubActionProcedure)SubActionProcedure).ProcedureDoctor;
                        }
                        else if (EpisodeAction != null && EpisodeAction.ProcedureDoctor != null)
                            queueItem.Doctor = EpisodeAction.ProcedureDoctor;
                    }
                }
            }
        }

        protected QuotaHistory CheckIfQuotaUsedBefore()
        {
            if (Action != null && Action is AdmissionAppointment)
            {
                AdmissionAppointment admissionAppointment = (AdmissionAppointment)Action;
                BindingList<QuotaHistory> quotaHistory = QuotaHistory.GetByAdmissionAppointment(ObjectContext, admissionAppointment.ObjectID);
                if (quotaHistory.Count > 0)
                    return quotaHistory[0];
            }
            return null;
        }

        protected void UpdateQuota()
        {
            if (((ITTObject)this).HasOriginal == true)
            {
                Appointment originalApp = originalApp = (Appointment)(((ITTObject)this).Original);

                ResSection masterResource = null;
                bool hasChanged = false;
                bool onlyDeleteQuota = false;

                if (originalApp.AppDate.Value.Date != AppDate.Value.Date)
                    hasChanged = true;
                if (originalApp.MasterResource != null && MasterResource != null)
                {
                    masterResource = (ResSection)MasterResource;
                    if (originalApp.MasterResource.ObjectID != MasterResource.ObjectID)
                        hasChanged = true;
                }
                else
                {
                    if (originalApp.Resource is ResSection)
                    {
                        masterResource = (ResSection)Resource;
                        if (originalApp.Resource.ObjectID != Resource.ObjectID)
                            hasChanged = true;
                    }
                }

                if (CurrentStateDefID == Appointment.States.Cancelled)
                {
                    hasChanged = true;
                    onlyDeleteQuota = true;
                }
                if (hasChanged == true)
                {
                    //Sivil hasta kontenjanı PPP lerde olmayacağı için kapatıldı
                    //if(masterResource != null)
                    //{
                    //    if(this.Action != null && this.Action is AdmissionAppointment)
                    //    {
                    //        QuotaHistory quotaHistory = CheckIfQuotaUsedBefore();
                    //        if(onlyDeleteQuota != true)
                    //        {
                    //            this.Action.WorkListDate = this.AppDate;
                    //            masterResource.DecreaseRemainingDailyQuota((AdmissionAppointment)this.Action);
                    //        }
                    //        if(quotaHistory != null)
                    //        {
                    //            ((ITTObject)quotaHistory).Delete();
                    //            masterResource.DailyQuota++;
                    //            masterResource.MonthlyQuota++;
                    //        }
                    //    }
                    //}
                }
            }
        }

        public void CancelMyExaminationQueueItems()
        {
            IList<ExaminationQueueItem> itemList = TTObjectClasses.ExaminationQueueItem.GetByAppointment(ObjectContext, ObjectID);
            if (itemList.Count > 0)
            {
                foreach (ExaminationQueueItem item in itemList)
                {
                    if (item.CurrentStateDefID != null && item.CurrentStateDefID != TTObjectClasses.ExaminationQueueItem.States.Completed && item.CurrentStateDefID != TTObjectClasses.ExaminationQueueItem.States.Cancelled)
                        item.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.Cancelled;
                }
            }
        }

        public void CompleteMyExaminationQueueItems()
        {
            IList<ExaminationQueueItem> itemList = TTObjectClasses.ExaminationQueueItem.GetByAppointment(ObjectContext, ObjectID);
            if (itemList.Count > 0)
            {
                foreach (ExaminationQueueItem item in itemList)
                {
                    if (item.CurrentStateDefID != TTObjectClasses.ExaminationQueueItem.States.Completed && item.CurrentStateDefID != TTObjectClasses.ExaminationQueueItem.States.Cancelled)
                        item.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.Completed;
                }
            }
        }

        public void Cancel()
        {
            Schedule = null;
            CancelMyExaminationQueueItems();
        }

        public void MHRSRandevuEkleme(MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri, MHRSServis.KurumBilgileriType kurumBilgileri)
        {
            try
            {
                MHRSServis.RandevuEklemeTalepType randevuEklemeTalep = new MHRSServis.RandevuEklemeTalepType();
                MHRSServis.RandevuZamanBilgisiType randevuZamanBilgisi = new MHRSServis.RandevuZamanBilgisiType();
                MHRSServis.VatandasBilgileriType vatandasBilgileri = new MHRSServis.VatandasBilgileriType();
                MHRSServis.VatandasIletisimBilgileriType vatandasIletisimBilgileri = new MHRSServis.VatandasIletisimBilgileriType();
                MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri1 = new MHRSServis.TelefonIletisimBilgileriType();
                MHRSServis.TelefonIletisimBilgileriType telefonIletisimBilgileri2 = new MHRSServis.TelefonIletisimBilgileriType();
                MHRSServis.RandevuEklemeCevapType randevuEklemeCevap = new MHRSServis.RandevuEklemeCevapType();

                randevuEklemeTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                randevuEklemeTalep.KurumBilgileri = kurumBilgileri;

                randevuZamanBilgisi.RandevuBaslangicZamani = StartTime.ToString();
                randevuZamanBilgisi.RandevuBitisZamani = EndTime.ToString();
                randevuEklemeTalep.RandevuZamanBilgisi = randevuZamanBilgisi;

                randevuEklemeTalep.KesinCetvelId = Schedule.MHRSKesinCetvelID != null ? Convert.ToInt64(Schedule.MHRSKesinCetvelID) : 0;

                if (vatandasIletisimBilgileri.TelefonIletisimBilgileri == null)
                    vatandasIletisimBilgileri.TelefonIletisimBilgileri = new MHRSServis.TelefonIletisimBilgileriType[1];
                if (Patient != null)
                {
                    if (Patient.PatientAddress.HomePhone != null)
                    {
                        if (Patient.PatientAddress.HomePhone.Length == 10)
                        {
                            telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.HomePhone.Substring(0, 3);
                            telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.HomePhone.Substring(3, 7);
                        }
                        else if (Patient.PatientAddress.HomePhone.Length == 11)
                        {
                            telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.HomePhone.Substring(0, 3);
                            telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.HomePhone.Substring(4, 7);
                        }
                        else if (Patient.PatientAddress.HomePhone.Length == 12)
                        {
                            telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.HomePhone.Substring(1, 3);
                            telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.HomePhone.Substring(5, 7);
                        }

                        BindingList<MobilePhoneCodeDefinition> mobilePhoneCodeDefList = MobilePhoneCodeDefinition.MobilePhoneCodeDefByCode(ObjectContext, telefonIletisimBilgileri2.AlanKodu);
                        if (mobilePhoneCodeDefList.Count == 0)
                            telefonIletisimBilgileri2.NumaraTipi = 1;
                        else
                            telefonIletisimBilgileri2.NumaraTipi = 3;

                        vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;

                    }

                    if ((vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo)) && Patient.PatientAddress.MobilePhone != null)
                    {
                        if (Patient.PatientAddress.MobilePhone.Length == 10)
                        {
                            telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.MobilePhone.Substring(0, 3);
                            telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.MobilePhone.Substring(3, 7);
                        }
                        else if (Patient.PatientAddress.MobilePhone.Length == 11)
                        {

                            telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.MobilePhone.Substring(0, 3);
                            telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.MobilePhone.Substring(4, 7);
                        }
                        else if (Patient.PatientAddress.MobilePhone.Length == 12)
                        {
                            telefonIletisimBilgileri2.AlanKodu = Patient.PatientAddress.MobilePhone.Substring(1, 3);
                            telefonIletisimBilgileri2.TelefonNo = Patient.PatientAddress.MobilePhone.Substring(5, 7);
                        }

                        BindingList<MobilePhoneCodeDefinition> mobilePhoneCodeDefList = MobilePhoneCodeDefinition.MobilePhoneCodeDefByCode(ObjectContext, telefonIletisimBilgileri2.AlanKodu);
                        if (mobilePhoneCodeDefList.Count == 0)
                            telefonIletisimBilgileri2.NumaraTipi = 1;
                        else
                            telefonIletisimBilgileri2.NumaraTipi = 3;

                        vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;

                    }

                    if (vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo))
                    {
                        if (Action is AdmissionAppointment)
                        {
                            if (((AdmissionAppointment)Action).PatientPhone != null)
                            {
                                if (((AdmissionAppointment)Action).PatientPhone.Length == 10)
                                {
                                    telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                    telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(3, 7);
                                }
                                else if (((AdmissionAppointment)Action).PatientPhone.Length == 11)
                                {
                                    telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                    telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(4, 7);
                                }
                                else if (((AdmissionAppointment)Action).PatientPhone.Length == 12)
                                {
                                    telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(1, 3);
                                    telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(5, 7);
                                }

                                if (((AdmissionAppointment)Action).PhoneType == PhoneTypeEnum.Home)
                                    telefonIletisimBilgileri2.NumaraTipi = 1;
                                else
                                    telefonIletisimBilgileri2.NumaraTipi = 3;

                                vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;
                            }
                        }
                    }

                    if (vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo))
                        throw new TTException(TTUtils.CultureService.GetText("M25837", "Hastanın telefon bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!"));

                    vatandasIletisimBilgileri.Email = Patient.EMail;
                    vatandasBilgileri.VatandasIletisimBilgileri = vatandasIletisimBilgileri;

                    vatandasBilgileri.Ad = Patient.Name;
                    vatandasBilgileri.Soyad = Patient.Surname;
                    vatandasBilgileri.TCKimlikNo = Patient.UniqueRefNo != null ? Patient.UniqueRefNo.ToString() : null;
                    vatandasBilgileri.DogumTarihi = Patient.BirthDate != null ? Patient.BirthDate.Value.ToShortDateString() : null;
                    vatandasBilgileri.DogumYeri = Patient.BirthPlace != null ? Patient.BirthPlace : null;
                }
                else
                {
                    if (Action is AdmissionAppointment)
                    {
                        if (((AdmissionAppointment)Action).PatientPhone != null)
                        {
                            if (((AdmissionAppointment)Action).PatientPhone.Length == 10)
                            {
                                telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(3, 7);
                            }
                            else if (((AdmissionAppointment)Action).PatientPhone.Length == 11)
                            {
                                telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(0, 3);
                                telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(4, 7);
                            }
                            else if (((AdmissionAppointment)Action).PatientPhone.Length == 12)
                            {
                                telefonIletisimBilgileri2.AlanKodu = ((AdmissionAppointment)Action).PatientPhone.Substring(1, 3);
                                telefonIletisimBilgileri2.TelefonNo = ((AdmissionAppointment)Action).PatientPhone.Substring(5, 7);
                            }
                        }
                        if (((AdmissionAppointment)Action).PhoneType == PhoneTypeEnum.Home)
                            telefonIletisimBilgileri2.NumaraTipi = 1;
                        else
                            telefonIletisimBilgileri2.NumaraTipi = 3;

                        vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] = telefonIletisimBilgileri2;

                        vatandasBilgileri.VatandasIletisimBilgileri = vatandasIletisimBilgileri;

                        vatandasBilgileri.Ad = ((AdmissionAppointment)Action).PatientName;
                        vatandasBilgileri.Soyad = ((AdmissionAppointment)Action).PatientSurname;
                        vatandasBilgileri.TCKimlikNo = ((AdmissionAppointment)Action).PatientUniqueRefNo != null ? ((AdmissionAppointment)Action).PatientUniqueRefNo.ToString() : null;
                        vatandasBilgileri.DogumTarihi = (Patient != null && Patient.BirthDate != null) ? Patient.BirthDate.Value.ToShortDateString() : null;
                        vatandasBilgileri.DogumYeri = (Patient != null && Patient.BirthPlace != null) ? Patient.BirthPlace : null;
                    }

                    if (vatandasIletisimBilgileri.TelefonIletisimBilgileri[0] == null || String.IsNullOrEmpty(vatandasIletisimBilgileri.TelefonIletisimBilgileri[0].TelefonNo))
                        throw new TTException(TTUtils.CultureService.GetText("M25837", "Hastanın telefon bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!"));
                }

                randevuEklemeTalep.VatandasBilgileri = vatandasBilgileri;

                randevuEklemeCevap = MHRSServis.WebMethods.RandevuEklemeSync(Sites.SiteLocalHost, randevuEklemeTalep);

                if (randevuEklemeCevap != null && randevuEklemeCevap.TemelCevapBilgileri != null)
                {
                    if (randevuEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                    {
                        MHRSRandevuHrn = randevuEklemeCevap.RandevuHrn;
                        string aciklama = string.Empty;
                        aciklama = randevuZamanBilgisi.RandevuBaslangicZamani;
                        aciklama += " - ";
                        aciklama += randevuZamanBilgisi.RandevuBitisZamani;
                        aciklama += " Randuvu MHRS'ye başarıyla bildirildi.";
                        TTUtils.InfoMessageService.Instance.ShowMessage(aciklama);
                    }
                    else if (randevuEklemeCevap.TemelCevapBilgileri != null)
                    {
                        string hata = string.Empty;
                        hata = randevuEklemeCevap.TemelCevapBilgileri.Aciklama;

                        throw new TTException("MHRS Bildirim Hatası : " + hata);
                    }
                }
                else
                    throw new TTException("MHRS'ye bildirilirken hata oluştu !");
            }
            catch (Exception ex)
            {
                // InfoBox.Alert(ex);
                throw;
            }
        }

        public void MHRSRandevuEkleme_V2()
        {
            MhrsRandevuDetaySorgulamaData randevuDetayResult = MHRSRandevuDetaySorgulama_V2();

            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

            MhrsRandevuEklemeInput mhrsRandevuEklemeInput = new MhrsRandevuEklemeInput();
            mhrsRandevuEklemeInput.randevuNotu = Notes != null ? Notes : null;
            mhrsRandevuEklemeInput.slotID = randevuDetayResult.slotId;
            mhrsRandevuEklemeInput.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
            mhrsRandevuEklemeInput.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
            if (Patient != null)
            {
                if (((AdmissionAppointment)Action).PatientUniqueRefNo != null)
                {
                    mhrsRandevuEklemeInput.hastaTCKimlikNo = Convert.ToInt64(Patient.UniqueRefNo.Value);
                }
                else
                {
                    throw new TTException("Hastanın kimlik bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!");
                }
                if (Patient.PatientAddress.MobilePhone != null)
                {
                    mhrsRandevuEklemeInput.telefonNo = Convert.ToInt64(Patient.PatientAddress.MobilePhone.Replace(" ", String.Empty));
                    mhrsRandevuEklemeInput.telefonTipi = 1;
                }
                else if (Patient.PatientAddress.HomePhone != null)
                {
                    mhrsRandevuEklemeInput.telefonNo = Convert.ToInt64(Patient.PatientAddress.HomePhone.Replace(" ", String.Empty));
                    mhrsRandevuEklemeInput.telefonTipi = 4;
                }
                else if (Patient.PatientAddress.RelativeMobilePhone != null)
                {
                    mhrsRandevuEklemeInput.telefonNo = Convert.ToInt64(Patient.PatientAddress.RelativeMobilePhone.Replace(" ", String.Empty));
                    mhrsRandevuEklemeInput.telefonTipi = 2;
                }
                else
                {
                    if (Action is AdmissionAppointment)
                    {
                        if (((AdmissionAppointment)Action).PatientPhone != null)
                        {
                            mhrsRandevuEklemeInput.telefonNo = Convert.ToInt64(((AdmissionAppointment)Action).PatientPhone.Replace(" ", String.Empty));

                            if (((AdmissionAppointment)Action).PhoneType == PhoneTypeEnum.Home)
                                mhrsRandevuEklemeInput.telefonTipi = 4;
                            else
                                mhrsRandevuEklemeInput.telefonTipi = 1;
                        }
                    }
                }

                if (mhrsRandevuEklemeInput.telefonNo == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25837", "Hastanın telefon bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!"));
            }
            else
            {
                if (Action is AdmissionAppointment)
                {
                    if (((AdmissionAppointment)Action).PatientUniqueRefNo != null)
                    {
                        mhrsRandevuEklemeInput.hastaTCKimlikNo = ((AdmissionAppointment)Action).PatientUniqueRefNo.Value;
                    }
                    else
                    {
                        throw new TTException("Hastanın kimlik bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!");
                    }
                    if (((AdmissionAppointment)Action).PatientPhone != null)
                    {
                        mhrsRandevuEklemeInput.telefonNo = Convert.ToInt64(((AdmissionAppointment)Action).PatientPhone.Replace(" ", String.Empty));

                        if (((AdmissionAppointment)Action).PhoneType == PhoneTypeEnum.Home)
                            mhrsRandevuEklemeInput.telefonTipi = 4;
                        else
                            mhrsRandevuEklemeInput.telefonTipi = 1;
                    }
                }

                if (mhrsRandevuEklemeInput.telefonNo == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25837", "Hastanın telefon bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!"));
            }

            string serializedObj = JsonConvert.SerializeObject(mhrsRandevuEklemeInput);

            Schedule schedule = new Schedule();
            string accessToken = schedule.LoginForMHRS();

            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/randevu/randevu-ekle");

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

                    foreach (Newtonsoft.Json.Linq.JObject item in error)
                    {
                        detailedError += item.ToString();
                    }
                }
                throw new TTException(detailedError);
            }

            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<MhrsRandevuEklemeResponse>(response.Content);
                MHRSRandevuHrn = result.data.hastaRandevuNumarasi;
            }
        }

        public MhrsRandevuDetaySorgulamaData MHRSRandevuDetaySorgulama_V2()
        {
            try
            {
                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                MhrsRandevuDetaySorgulamaInput input = new MhrsRandevuDetaySorgulamaInput();
                input.aksiyonId = Schedule.MHRSActionTypeDefinition != null ? Convert.ToInt32(Schedule.MHRSActionTypeDefinition.ActionCode) : 0;

                if (Patient != null)
                {
                    if (((AdmissionAppointment)Action).PatientUniqueRefNo != null)
                    {
                        input.hastaTcKimlikNo = Convert.ToInt64(Patient.UniqueRefNo.Value);
                    }
                    else
                    {
                        throw new TTException("Hastanın kimlik bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!");
                    }
                }
                else
                {
                    if (Action is AdmissionAppointment)
                    {
                        if (((AdmissionAppointment)Action).PatientUniqueRefNo != null)
                        {
                            input.hastaTcKimlikNo = ((AdmissionAppointment)Action).PatientUniqueRefNo.Value;
                        }
                        else
                        {
                            throw new TTException("Hastanın kimlik bilgileri eksiktir. Tamamlamadan randevu veremezsiniz!");
                        }
                    }
                }

                if (Schedule.Resource != null && Schedule.Resource is ResUser)
                {
                    input.hekimTcKimlikNo = Convert.ToInt64(((ResUser)Schedule.Resource).UniqueNo);
                }

                input.klinikKodu = ((ResPoliclinic)Schedule.MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)Schedule.MasterResource).MHRSCode) : 0;
                input.muayeneYeriId = ((ResPoliclinic)Schedule.MasterResource).MHRSAltKlinikKodu != null ? Convert.ToInt32(((ResPoliclinic)Schedule.MasterResource).MHRSAltKlinikKodu) : 0;
                input.strBaslangicZamani = StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                input.strBitisZamani = StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");// EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                input.vatandasaUygunMu = true;
                input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);

                string serializedObj = JsonConvert.SerializeObject(input);

                Schedule schedule = new Schedule();
                string accessToken = schedule.LoginForMHRS();

                Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/randevu/detay-sorgula");

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

                MhrsRandevuDetaySorgulamaData result = new MhrsRandevuDetaySorgulamaData();
                result.durum = false;

                if (response.IsSuccessful)
                {
                    var responseData = JsonConvert.DeserializeObject<MhrsRandevuDetaySorgulamaResponse>(response.Content);
                    result = responseData.data.FirstOrDefault();
                    if (result.durum == false)
                    {
                        throw new Exception("Seçilen Slot Dolu");
                    }
                    else if (result.vatandasaUygun == false)
                    {
                        throw new Exception("Seçilen Slot Vatandaşa uygun değil!");
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public class MhrsRandevuEklemeInput
        {
            public Int64 hastaTCKimlikNo { get; set; }
            public string randevuNotu { get; set; }
            public Int64 slotID { get; set; }
            public Int64 telefonNo { get; set; }
            public int telefonTipi { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }
        public class MhrsRandevuEklemeResponse
        {
            public string lang { get; set; }
            public bool success { get; set; }
            public List<Info> infos { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public MhrsRandevuEklemeData data { get; set; }
        }
        public class MhrsRandevuEklemeData
        {
            public string hastaRandevuNumarasi { get; set; }
            public string hekimAdiSoyadi { get; set; }
            public string klinikAdi { get; set; }
            public string kurumAdi { get; set; }
            public string muayeneYeriAdi { get; set; }
            public string randevuUyarisi { get; set; }
            public DateTime randevuZamani { get; set; }
        }

        public class MhrsRandevuDetaySorgulamaInput
        {
            public int aksiyonId { get; set; }
            public Int64 hastaTcKimlikNo { get; set; }
            public Int64 hekimTcKimlikNo { get; set; }
            public int klinikKodu { get; set; }
            public int muayeneYeriId { get; set; }
            public string strBaslangicZamani { get; set; }
            public string strBitisZamani { get; set; }
            public bool vatandasaUygunMu { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }
        public class MhrsRandevuDetaySorgulamaResponse
        {
            public string lang { get; set; }
            public bool success { get; set; }
            public List<Info> infos { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public List<MhrsRandevuDetaySorgulamaData> data { get; set; }
        }
        public class MhrsRandevuDetaySorgulamaData
        {
            public Int64 cetvelId { get; set; }
            public int muayeneYeriId { get; set; }
            public string muayeneYeriAdi { get; set; }
            public int aksiyonId { get; set; }
            public Int64 slotId { get; set; }
            public DateTime saat { get; set; }
            public DateTime baslangicZamani { get; set; }
            public DateTime bitisZamani { get; set; }
            public bool durum { get; set; }
            public bool vatandasaUygun { get; set; }
            public object enbuyukyas { get; set; }
            public object enkucukyas { get; set; }
            public string cinsiyet { get; set; }
            public string ozellikler { get; set; }
            public bool ekMi { get; set; }
        }

        public class MHRSRandevuIptal_Input
        {
            public string hastaRandevuNumarasi { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }

        public class RandevuIptalResult
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

        public class MHRSRandevuIptal_Output
        {
            public RandevuIptalResult data { get; set; }
            public List<ErrorList> errorList { get; set; }
            public string httpStatus { get; set; }
            public List<InfoList> infoList { get; set; }
            public bool valid { get; set; }
            public List<WarningList> warningList { get; set; }
        }


        #endregion Methods

        public class HbysRandevuGerceklesmeBilgisiTalep
        {
            public List<HbysRandevuGerceklesmeBilgisiEklemeTalep> randevuGerceklesmeBilgisiEklemeTalepList { get; set; }
            public int islemYapilanKurumKodu { get; set; }
            public Int64 islemYapanTcKimlikNo { get; set; }
        }

        public class HbysRandevuGerceklesmeBilgisiEklemeTalep
        {
            public string hastaGelisZamani { get; set; }
            public string hastaRandevuNumarasi { get; set; }
            public int randevuGerceklesmeBilgisi { get; set; }
            public string randevuGerceklesmeZamani { get; set; }
        }

        public class RandevuGerceklesmeBilgisi
        {
            public int val { get; set; }
            public string valText { get; set; }
        }

        public class RandevuGerceklesme_Output
        {
            public string lang { get; set; }
            public bool success { get; set; }
            public List<Schedule.Info> infos { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public object data { get; set; }
        }

        public class RandevuGerceklesme_Data
        {
            public string hastaRandevuNumarası { get; set; }
        }
    }
}