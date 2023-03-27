
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
    public partial class BaseBedProcedure : BedProcedureWithoutBed
    {
        public partial class OLAP_GetLastUsedBedByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetEpisodeFromUsedBed_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetUsedBedByDate_Class : TTReportNqlObject
        {
        }

        public partial class VEM_HASTA_YATAK_Class : TTReportNqlObject
        {
        }

        public partial class VEM_ANLIK_YATAN_HASTA_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// Medula yatış başlangıç tarihi
        /// </summary>
        public string yatisBaslangicTarihi
        {
            get
            {
                try
                {
                    #region yatisBaslangicTarihi_GetScript                    
                    if (BedInPatientDate != null)
                        return ((DateTime)BedInPatientDate).ToString("dd.MM.yyyy");
                    else
                        return null;
                    #endregion yatisBaslangicTarihi_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "yatisBaslangicTarihi") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula yatış bitiş tarihi
        /// </summary>
        public string yatisBitisTarihi
        {
            get
            {
                try
                {
                    #region yatisBitisTarihi_GetScript                    
                    if (BedDischargeDate != null)
                        return ((DateTime)BedDischargeDate).ToString("dd.MM.yyyy");
                    else
                        return null;
                    #endregion yatisBitisTarihi_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "yatisBitisTarihi") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "BEDDISCHARGEDATE":
                    {
                        DateTime? value = (DateTime?)newValue;
                        #region BEDDISCHARGEDATE_SetScript
                        if (value != null)
                        {
                            Amount = Common.DateDiff(0, Convert.ToDateTime(value).Date, Convert.ToDateTime(BedInPatientDate).Date);

                            if (Amount == 0)
                                Eligible = false;
                            else
                                Eligible = true;
                        }
                        #endregion BEDDISCHARGEDATE_SetScript
                    }
                    break;
                case "BEDINPATIENTDATE":
                    {
                        DateTime? value = (DateTime?)newValue;
                        #region BEDINPATIENTDATE_SetScript
                        if (value.HasValue)
                            PricingDate = value;
                        #endregion BEDINPATIENTDATE_SetScript
                    }
                    break;
                case "USEDSTATUS":
                    {
                        UsedStatusEnum? value = (UsedStatusEnum?)(int?)newValue;
                        #region USEDSTATUS_SetScript
                        if (value != UsedStatus)
                        {
                            if (UsedStatus == UsedStatusEnum.Used && value == UsedStatusEnum.WasReserved)
                            {
                                value = UsedStatusEnum.NotUsed;
                            }
                            if (UsedStatus == UsedStatusEnum.ReservedToUse && value == UsedStatusEnum.NotUsed)
                            {
                                value = UsedStatusEnum.WasReserved;
                            }
                            if (BedDischargeDate != null && value != UsedStatusEnum.NotUsed)
                            {
                                throw new Exception(SystemMessage.GetMessage(636));
                            }

                            if (BedDischargeDate != null && value != UsedStatusEnum.WasReserved)
                            {
                                throw new Exception(SystemMessage.GetMessage(637));
                            }

                            if (value == UsedStatusEnum.NotUsed || value == UsedStatusEnum.WasReserved)
                            {
                                if (Bed.UsedByBedProcedure != null && Bed.UsedByBedProcedure.ObjectID == ObjectID)// o yatağa başkası yatırıldıysa onu boşaltmasın diye
                                    Bed.UsedByBedProcedure = null;
                                BedDischargeDate = Common.RecTime();
                                Bed.IsClean = false;
                            }
                            else
                            {
                                if (SystemParameter.GetParameterValue("ISCLEANINGMODULEACTIVE", "FALSE") == "TRUE" && Bed.IsClean.HasValue && !Bed.IsClean.Value)
                                    throw new Exception("Yatırmaya çalıştığınız yatak henüz temizlenmedi, lütfen temiz bir yatak seçiniz.");

                                Bed.UsedByBedProcedure = this;
                                
                                
                                // Son Yatağının 
                                var bedInPatientDate = Common.RecTime();
                                foreach (var bp in BaseInpatientAdmission.BedProcedures.OrderByDescending(dr => dr.BedDischargeDate))
                                {
                                    if (!bp.IsCancelled && bp.BedDischargeDate != null)
                                    {
                                        bedInPatientDate = (DateTime)bp.BedDischargeDate;
                                        break;
                                    }
                                }

                                BedInPatientDate = bedInPatientDate;
                            }
                            //if (value == UsedStatusEnum.Used)  // artılk Bed Bilgisi InpatientAdmissionda tutuluyor
                            //    this.BaseInpatientAdmission.Episode.Bed = this.Bed;

                            if ((value == UsedStatusEnum.Used || value == UsedStatusEnum.NotUsed) && Amount > 0)
                            {
                                Eligible = true;
                            }
                            else
                            {
                                Eligible = false;
                            }
                        }
                        #endregion USEDSTATUS_SetScript
                    }
                    break;
                case "BED":
                    {
                        ResBed value = (ResBed)newValue;
                        #region BED_SetParentScript
                        ProcedureObject = value.BedProcedure;
                        #endregion BED_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            SetPerformedDate();

            if (Eligible == true && CurrentStateDefID != SubActionProcedure.States.Cancelled && IsNewPricingType == true)
                AddBedProcedure(BedInPatientDate);

            #endregion PostInsert
        }

        #region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true && BedInPatientDate == null)
            {
                BedInPatientDate = Common.RecTime();
            }

            //      BindingList<BaseBedProcedure>  baseBedProcedure = BaseBedProcedure.GetByInpatientProcedure(_BaseBedProcedure.ObjectContext,);
        }
        override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            //if (relDef.ParentObjectDefID == new Guid("f18cbf08-9ee2-40de-8029-c3f7e739c3a4"))// SubEpisode
            //    return false;

            //if (this.Amount > 0 && relDef.ParentObjectDef.IsOfType(typeof(ProcedureDefinition).Name.ToUpperInvariant()))//ProcedureObject
            //    return IsAccountOperationDone();
            //else
            return false;
        }

        override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            //if (this.Amount > 0 && propDef.PropertyDefID == new Guid("6b793fd3-ac25-46cd-a28a-89d23f0daab5"))//Amount
            //    return IsAccountOperationDone();
            //else
            return false;
        }

        //public override bool CheckSubepisodeClosingDate() // True ise Hizmet Bağlı olduğu SubEpisodeun Opening ve Closing  tarihleri arasında uygulanmak zorundadır.
        //{
        //    return false;
        //}

        public override void Cancel()
        {
            base.Cancel();
            if (UsedStatus == UsedStatusEnum.Used)
            {
                UsedStatus = UsedStatusEnum.NotUsed;
            }
            if (UsedStatus == UsedStatusEnum.ReservedToUse)
            {
                UsedStatus = UsedStatusEnum.WasReserved;
            }

            CancelMyBedProcedures();
        }

        public override void AccountOperation(AccountOperationTimeEnum pPreAccounting = AccountOperationTimeEnum.PREPOST, SubEpisodeProtocol outSEP = null)
        {
            if (IsNewPricingType == true)
                return;

            base.AccountOperation(pPreAccounting, outSEP);
        }

        public override void ChangeMyProtocol(SubEpisodeProtocol pSEP)
        {
            if (IsNewPricingType == true)
                return;

            base.ChangeMyProtocol(pSEP);
        }

        // BedProcedure leri iptel eder
        public void CancelMyBedProcedures()
        {
            foreach (BedProcedure bedProcedure in BedProcedures)
            {
                if (!bedProcedure.IsCancelled)
                    ((ITTObject)bedProcedure).Cancel();
            }
        }

        public void ChangeMyBedProceduresProtocol(SubEpisodeProtocol pSEP)
        {
            foreach (BedProcedure bedProcedure in BedProcedures)
            {
                if (!bedProcedure.IsCancelled)
                    bedProcedure.ChangeMyProtocol(pSEP);
            }
        }

        // BedProcedure oluşturur
        public void AddBedProcedure(DateTime? date)
        {
            if (this?.InPatientTreatmentClinicApp?.IsDailyOperation == true) // Günübirlik yatış ise BedProcedure oluşturulmaz
                return;

            if (IsNewPricingType != true)
                throw new TTException("Yatak hizmeti (BedProcedure) sadece yeni yatak ücretlenme yapısında oluşturulur.");

            if (Bed == null)
                throw new TTException("Yatak hizmeti oluşturulurken yatak bilgisi boş olamaz.");

            if (Bed.BedProcedure == null)
                throw new TTException("Yatak hizmeti oluşturulurken yatak tanımındaki hizmet bilgisi boş olamaz.");

            DateTime pricingDate;

            if (date.HasValue)
                pricingDate = date.Value;
            else
                pricingDate = Common.RecTime();

            BedProcedure bedProcedure = new BedProcedure(ObjectContext);
            bedProcedure.PricingDate = pricingDate;
            bedProcedure.PerformedDate = pricingDate;

            if (bedProcedure.CreationDate > bedProcedure.PerformedDate)
                bedProcedure.PerformedDate = bedProcedure.CreationDate;

            bedProcedure.EpisodeAction = EpisodeAction;
            bedProcedure.CurrentStateDefID = SubActionProcedure.States.Completed;
            bedProcedure.BaseBedProcedure = this;
            bedProcedure.ProcedureObject = Bed.BedProcedure;

            bool isPandemic = false;

            InPatientPhysicianApplication inPatientPhysicianApp = InPatientTreatmentClinicApp.InPatientPhysicianApplication.FirstOrDefault();
            if (inPatientPhysicianApp?.IsPandemic == YesNoEnum.Yes)
                isPandemic = true;

            // Yoğun Bakımın ilk günü için hizmet olarak "510090 Yoğun bakım" hizmeti atılsın, yatak tanımındaki hizmet değil !
            // Yeni takip alınıyorsa ilk gün için 510090 atılır, yeni takip alınmıyorsa (aynı klinikte yatak değişiyorsa mesela) yatak tanımındaki hizmet atılır.
            if (Bed.Room.RoomGroup.Ward.IsIntensiveCare == true)
            {
                if (pricingDate.Date.Equals(BedInPatientDate.Value.Date)) // İlk gün için oluşturulacak yatak hizmeti ise
                {
                    Guid intensiveCareProcObjectID = ProcedureDefinition.IntensiveCareProcedureObjectID;

                    if (SubEpisode.SubActionProcedures.Any(x => x is BedProcedure && !x.IsCancelled && ((BedProcedure)x).BaseBedProcedure.Eligible == true && x.ProcedureObject.ObjectID.Equals(intensiveCareProcObjectID)) == false)
                    {
                        bedProcedure.ProcedureObject = ObjectContext.GetObject<ProcedureDefinition>(intensiveCareProcObjectID);
                        isPandemic = true; // "510090 Yoğun bakım" hizmeti için her zaman Pandemi hizmeti oluşmalı
                    }
                }

                //Yoğun Bakım İzlem Paketi
                new SendToENabiz(ObjectContext, SubEpisode, bedProcedure.ObjectID, bedProcedure.ObjectDef.Name, "502", Common.RecTime());
            }

            if (isPandemic)
                bedProcedure.CreatePandemicProcedure();
        }

        public override void AccountOperationAfterUpdate()
        {
            TTObjectContext objContext = new TTObjectContext(true);
            BaseBedProcedure originalBP = objContext.GetObject<BaseBedProcedure>(ObjectID, false);
            if (originalBP != null)
            {
                if (IsNewPricingType == true) // Yeni yapıda BaseBedProcedure ün kendisi ücretlenmz, BedProcedure leri ayarlanır
                {
                    if (Eligible != true || CurrentStateDef.Status == StateStatusEnum.Cancelled) // Eligible false ise veya iptal durumunda bir adımda ise ücretler iptal edilip çıkılır
                    {
                        CancelMyBedProcedures();
                        return;
                    }

                    if ((Eligible == true && originalBP.Eligible != true) || // Eligible true yapılmış
                        (ProcedureObject != null && originalBP.ProcedureObject != null && ProcedureObject.ObjectID != originalBP.ProcedureObject.ObjectID) || // ProcedureObject değişmiş
                        (SubEpisode != null && originalBP.SubEpisode != null && SubEpisode.ObjectID != originalBP.SubEpisode.ObjectID)) // SubEpisode değişmiş

                        ChangeMyBedProceduresProtocol(SubEpisode.OpenSubEpisodeProtocol);

                    else if ((Amount.HasValue && originalBP.Amount.HasValue && Amount.Value != originalBP.Amount.Value) ||  // Amount veya BedInPatientDate değişmiş
                             (BedInPatientDate.HasValue && originalBP.BedInPatientDate.HasValue && BedInPatientDate.Value != originalBP.BedInPatientDate.Value))
                        ArrangeMyBedProcedures();
                }
                else // Kendisi ücretlenen BaseBedProcedure ler için duruyor bu blok, 6 ay sonra kaldırılabilir.  - 25.06.2019) 
                {
                    if (Eligible != true || CurrentStateDef.Status == StateStatusEnum.Cancelled) // Eligible false ise veya iptal durumunda bir adımda ise ücretler iptal edilip çıkılır
                    {
                        CancelMyAccountTransactions();
                        return;
                    }

                    if (AccountTransactions.Count == 0) // Insert sırasında ücretlenmemişse burada ücretlensin
                        AccountOperation();

                    else if ((Eligible == true && originalBP.Eligible != true) || // Eligible true yapılmış
                        (ProcedureObject != null && originalBP.ProcedureObject != null && ProcedureObject.ObjectID != originalBP.ProcedureObject.ObjectID) || // ProcedureObject değişmiş
                        (SubEpisode != null && originalBP.SubEpisode != null && SubEpisode.ObjectID != originalBP.SubEpisode.ObjectID)) // SubEpisode değişmiş

                        ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);

                    else if (Amount.HasValue && originalBP.Amount.HasValue && Amount.Value != originalBP.Amount.Value) // Amount değişmiş
                        AccountOperationAfterAmountUpdate();
                }
            }
        }

        // Yatak hizmetinin miktarı değiştiği zaman BedProcedure lerini düzenleyen metod
        public void ArrangeMyBedProcedures()
        {
            if (this?.InPatientTreatmentClinicApp?.IsDailyOperation == true) // Günübirlik yatış ise BedProcedure ler ile ilgili bir işlem yapılmaz
                return;

            DateTime tempDate = BedInPatientDate.Value;
            DateTime firstDate = BedInPatientDate.Value;
            DateTime lastDate = BedInPatientDate.Value.AddDays(Convert.ToDouble(Amount));

            // Eksik günler için BedProcedure oluşturulur
            while (tempDate < lastDate)
            {
                if (BedProcedures.Any(x => x.PricingDate.Value.Date.Equals(tempDate.Date) && !x.IsCancelled) == false)
                    AddBedProcedure(tempDate);

                tempDate = tempDate.AddDays(1);
            }

            // Fazla BedProcedure varsa (tarihler dışında) iptal edilir
            foreach (BedProcedure bedProcedure in BedProcedures.Where(x => (x.PricingDate.Value.Date < firstDate.Date || x.PricingDate.Value.Date > lastDate.Date.AddDays(-1)) && !x.IsCancelled))
            {
                ((ITTObject)bedProcedure).Cancel();
            }
        }

        // Yatak hizmetinin miktarı değiştiği zaman fatura kalemlerini düzenleyen metod
        public void AccountOperationAfterAmountUpdate()
        {
            if (BedInPatientDate.HasValue == false)  // BedInPatientDate boş ise en azından mevcut amount a göre tekrar ücretlendirme yapılması için
                ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);
            else
            {
                // TODO: resmi ve hasta payları için bu şekilde değil, amount update etme şeklinde olacak ..

                SubEpisodeProtocol sep = SubEpisode.OpenSubEpisodeProtocol;
                DateTime tempDate = BedInPatientDate.Value.Date;
                DateTime firstDate = BedInPatientDate.Value.Date;
                DateTime lastDate = BedInPatientDate.Value.Date.AddDays(Convert.ToDouble(Amount));

                // Eksik günler için yatak hizmeti AccountTransaction ı oluşturulur
                while (tempDate < lastDate)
                {
                    if (AccountTransactions.Any(x => x.TransactionDate.Value.Date.Equals(tempDate) && x.CurrentStateDefID != AccountTransaction.States.Cancelled) == false)
                    {
                        if (sep == null)
                            throw new TTException(SystemMessage.GetMessage(663));

                        ArrayList col = new ArrayList();
                        col = sep.Protocol.CalculatePrice(ProcedureObject, EpisodeAction.Episode.PatientStatus, null, tempDate, EpisodeAction.Episode.Patient.AgeCompleted);

                        if (col.Count == 0)
                            throw new TTException(SystemMessage.GetMessageV3(950, new string[] { ProcedureObject.Name }));

                        foreach (ManipulatedPrice mpd in col)
                        {
                            SubEpisodeProtocol.AddAccountTransactionParameter addAccountTransactionParameter = new SubEpisodeProtocol.AddAccountTransactionParameter(1, tempDate);

                            if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                                sep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE, addAccountTransactionParameter);

                            if (mpd.PayerPrice > 0)
                                sep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE, addAccountTransactionParameter);

                            if (mpd.PatientPrice > 0)
                                sep.AddAccountTransaction(AccountOwnerType.PATIENT, this, mpd, null, AccountOperationTimeEnum.PRE, addAccountTransactionParameter);
                        }
                    }

                    tempDate = tempDate.AddDays(1);
                }

                // Fazla günler için yatak hizmeti AccountTransaction ı varsa iptal edilir (Taburcu tarihini geriye çekme gibi durumlar için)
                foreach (AccountTransaction accTrx in AccountTransactions.Where(x => (x.TransactionDate.Value.Date < firstDate || x.TransactionDate.Value.Date > lastDate.AddDays(-1)) && x.CurrentStateDefID != AccountTransaction.States.Cancelled))
                {
                    if (accTrx.IsAllowedToCancel == false)
                        throw new TTException(TTUtils.CultureService.GetText("M26178", "İşlem hareketi '") + accTrx.CurrentStateDef.DisplayText + "' durumunda olduğu için iptal edilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Hizmet : " + accTrx.ExternalCode + " " + accTrx.Description);

                    accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                }
            }
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (EpisodeAction.ProcedureSpeciality != null)
                return EpisodeAction.ProcedureSpeciality.Code;

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (InPatientTreatmentClinicApp != null)
            {
                if (InPatientTreatmentClinicApp.ProcedureDoctor != null && !string.IsNullOrEmpty(InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo))
                    return InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo;
            }

            if (EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVORefakatciGunSayisi(AccountTransaction accTrx, string yatisBaslangicTarihi = null, string yatisBitisTarihi = null)
        {
            DateTime baslangicTarihi;
            DateTime bitisTarihi;

            if (!string.IsNullOrEmpty(yatisBaslangicTarihi))
                baslangicTarihi = Convert.ToDateTime(yatisBaslangicTarihi);
            else
                baslangicTarihi = Convert.ToDateTime(GetDVOYatisBaslangicTarihi(accTrx));

            if (!string.IsNullOrEmpty(yatisBitisTarihi))
                bitisTarihi = Convert.ToDateTime(yatisBitisTarihi);
            else
                bitisTarihi = Convert.ToDateTime(GetDVOYatisBitisTarihi(accTrx));

            return BaseBedProcedure.GetCompanionDayCount(accTrx, baslangicTarihi, bitisTarihi);
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            return Aciklama;
        }

        public override string GetDVOYatakKodu()
        {
            return Bed?.BedCodeForMedula;
        }

        // CompanionProcedure lerden refakatçi gün sayısı bulunur
        public static string GetCompanionDayCount(AccountTransaction AccTrx, DateTime yatisBaslangicTarihi, DateTime yatisBitisTarihi)
        {
            if (AccTrx.Amount == 1) // Yatak tarihi ile aynı gün refakatçi hizmeti varsa 1 döndürülür
            {
                foreach (AccountTransaction accTrx in AccTrx.SubEpisodeProtocol.AccountTransactions.Select("").Where(x => x.SubActionProcedure != null && !string.IsNullOrEmpty(x.ExternalCode) && x.ExternalCode.Equals("510121") && x.TransactionDate.Value.Date.Equals(AccTrx.TransactionDate.Value.Date)).ToList())
                {
                    if (!accTrx.IsCancelled && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                        return "1";
                }
            }
            else // Toplam refakatçi gün sayısı döndürülür
            {
                int refakatciGunSayi = 0;
                foreach (AccountTransaction accTrx in AccTrx.SubEpisodeProtocol.AccountTransactions.Select("").Where(x => x.SubActionProcedure != null && !string.IsNullOrEmpty(x.ExternalCode) && x.ExternalCode.Equals("510121")).ToList())
                {
                    if (!accTrx.IsCancelled && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                        // Burası ATLAS ta eklendi, XXXXXX ta yoktu. Yatış başlangıç ve Bitiş tarihleri arasındaki refakatçi hizmetleri toplama dahil ediliyor. (MDZ)
                        if (accTrx.TransactionDate.Value.Date >= yatisBaslangicTarihi && accTrx.TransactionDate.Value.Date < yatisBitisTarihi)
                            refakatciGunSayi += Convert.ToInt32(accTrx.Amount);
                }

                if (refakatciGunSayi > 0)
                {
                    int yatisGunSayi = Common.DateDiff(Common.DateIntervalEnum.Day, Convert.ToDateTime(yatisBitisTarihi).Date, Convert.ToDateTime(yatisBaslangicTarihi).Date);
                    if (refakatciGunSayi > yatisGunSayi)
                        refakatciGunSayi = yatisGunSayi;

                    return refakatciGunSayi.ToString();
                }
            }

            return null;
        }

        override public bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;

            if (IsNewPricingType == true)
                return false;

            // MasterSubActionProcedure den kontrol etme kısmı, fatura ekranındaki NabizYatakDuzenle metodu için eklendi. İleride NabizYatakDuzenle ye gerek kalmazsa kaldırılabilir. ) 
            if (UsedStatus.Value == UsedStatusEnum.Used || MasterSubActionProcedure is BaseBedProcedure)
                return true;
            else
                return false;
        }

        public override void SetPerformedDate()
        {
            if (CreationDate > BedInPatientDate)
                CreationDate = BedInPatientDate;
            PerformedDate = BedInPatientDate;
        }

        #endregion Methods

    }
}