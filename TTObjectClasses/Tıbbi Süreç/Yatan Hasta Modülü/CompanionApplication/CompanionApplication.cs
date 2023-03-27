
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
    /// <summary>
    /// Refakatçi İşlemleri
    /// </summary>
    public partial class CompanionApplication : EpisodeAction
    {
        public partial class GetCompanionApplicationByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetCompanionApplicationBySubEpisode_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            if (RequestDate == null)
                throw new Exception(TTUtils.CultureService.GetText("M26150", "İstek Tarihi boş olamaz!"));
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            if (InpatientAdmission == null)
            {
                SetMyInpatientAdmission();
            }

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            #endregion PostUpdate
        }

        protected void PostTransition_Active2Cancelled()
        {
            // From State : Active   To State : Cancelled
            #region PostTransition_Active2Cancelled
            Cancel();
            #endregion PostTransition_Active2Cancelled
        }


        protected void PostTransition_ExCompanion2Cancelled()
        {
            // From State : ExCompanion   To State : Cancelled
            #region PostTransition_ExCompanion2Cancelled
            Cancel();
            #endregion PostTransition_ExCompanion2Cancelled
        }




        protected void PostTransition_Active2ExCompanion()
        {
            // From State : Active   To State : ExCompanion

            #region PostTransition_Active2ExCompanion
            // Buradaki kodlar InPatientTreatmentClinicApplication.CreateAndArrangeCompanionApplicationAccTrxs den geç çalışdığı için her şey InPatientTreatmentClinicApplication da yapılıypr
            //CheckRulesToCompleteCompanion();
            #endregion PostTransition_Active2ExCompanion
        }


        protected void UndoTransition_Active2ExCompanion(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Active  To State : ExCompanion
            #region UndoTransition_Active2ExCompanion
            // Buradaki kodlar geç çalışdığı için her şey InPatientTreatmentClinicApplication da yapılıypr
            // Oluşturulmuş Refakatçi Ücretleri İptal Edilir (Completed state ine geçişte yenileri oluşturulacağı için)
            //CancelMySubactionProcedures();


            //Taburcu iptalinde engelliyordu kapatıldı
           // if(this.Episode.PatientStatus == PatientStatusEnum.Discharge || this.Episode.PatientStatus == PatientStatusEnum.PreDischarge)
           //     throw new Exception("Taburcu olmauş Vakada Refakatçi işlemleri geri alınamaz!");

            #endregion UndoTransition_Active2ExCompanion
        }


        #region Methods

        public void SetMySubEpisodeByMasterAction()
        {
            if(CurrentStateDef.Status != StateStatusEnum.Cancelled && MasterAction!= null && MasterAction is EpisodeAction)
            {
                if (SubEpisode != ((EpisodeAction)MasterAction).SubEpisode)
                    SubEpisode = ((EpisodeAction)MasterAction).SubEpisode;
            }
        }

        public override void Cancel()
        {
            base.Cancel();
        }


        public void AddingAccountOperation()
        {
            CheckRulesToCompleteCompanion();
            // Bu metod başka yerden çağırılıp ücretlendirme yapılmışsa (yani zaten ücretlenmişse), state geçişinde tekrar çalışıp ücretlendirmemesi için bu kontrol eklendi
            if (CompanionProcedures.Where(x => !x.IsCancelled).Count() > 0)
                return;

            //Refakatçi Ücretinin Otomatik Olarak Eklenmesi
            if (StayingDateCount != null && StayingDateCount >= 1)
            {
                ProcedureDefinition companionAppProcedure = ObjectContext.GetObject<ProcedureDefinition>(ProcedureDefinition.CompanionProcedureObjectId);

                // Vakada çok refakatçi hizmeti ve çok paket olduğu durumlardaki yavaşlığı önlemek için;
                // Vakada Refakatçi hizmetinin içine girebileceği uygun paket SubActionProcedure var mı diye kontrol edilir
                // Bulunursa AccountOperation metoduna parametre olarak geçilir (Hızlandırma amaçlı - Mustafa)

                /* Paket yapısı değiştiği için kapatıldı )
                SubActionProcedure packageSP = null;
                SubEpisodeProtocol sep = this.SubEpisode.OpenSubEpisodeProtocol;
                if (sep != null)
                {
                    IList packageSubActionProcedures = sep.GetPackageSubActionProcedures(true);
                    foreach (SubActionProcedure sp in packageSubActionProcedures)
                    {
                        if (sp.PackageDefinition.IsIncluded(companionAppProcedure, (Int16)TTObjectDefManager.ServerTime.Subtract(sp.PricingDate.Value).Days) == true)
                        {
                            packageSP = sp;
                            break;
                        }
                    }
                }
                */

                for (int i = 0; i < StayingDateCount; i++)
                {
                    CompanionProcedure companionProc = new CompanionProcedure(ObjectContext);
                    DateTime entrydate = Convert.ToDateTime(RequestDate).AddDays(Convert.ToDouble(i)); // ilk gün ise 00:00 değil tam olarak yatış tarihi alınır
                    if (i > 0)
                        entrydate = entrydate.Date; // işlem tarihi taburcu tarihinden herzaman küçük olsun diye saati 00:00 alınır
                    companionProc.CreationDate = entrydate;
                    companionProc.ActionDate = entrydate;
                    companionProc.PricingDate = entrydate;
                    companionProc.Amount = 1;
                    companionProc.CurrentStateDefID = CompanionProcedure.States.Completed;
                    companionProc.ProcedureObject = companionAppProcedure;
                    CompanionProcedures.Add(companionProc);
                    companionProc.SetPerformedDate();
                    companionProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
                }
            }
        }

        public void CancelMySubactionProcedures()
        {
            // Oluşturulmuş Refakatçi Ücretleri İptal Edilir (Completed state ine geçişte yenileri oluşturulacağı için)
            foreach (SubActionProcedure subactionProcedure in SubactionProcedures.Where(x => !x.IsCancelled))
                ((ITTObject)subactionProcedure).Cancel();
        }

        //ServerSide prede çağır
        public void SetMyInpatientAdmission()
        {
            foreach (InpatientAdmission ia in Episode.InpatientAdmissions.OrderByDescending(x=>x.HospitalInPatientDate))
            {
                if (ia.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    InpatientAdmission = ia;
                    break;
                }
            }
        }



         protected DateTime GetEndDate()
        {
            // EndDate Kullanıcı tarafından ddolu değilse Clinic taburcu tarihi alınır 
            if (MasterAction != null && MasterAction is InPatientTreatmentClinicApplication )
            {
                var clinicEndDate = ((InPatientTreatmentClinicApplication)MasterAction).ClinicDischargeDate;
                if (clinicEndDate != null)
                    return clinicEndDate.Value.Date;
            }
            else if (SubEpisode != null && SubEpisode.StarterEpisodeAction != null && SubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
            {
                var clinicEndDate = ((InPatientTreatmentClinicApplication)SubEpisode.StarterEpisodeAction).ClinicDischargeDate;
                if (clinicEndDate != null)
                    return clinicEndDate.Value.Date;
            }
            return Common.RecTime().Date;

        }

        public void ClearEndDate()
        {
            if (EndDate != null)
            {
                if (EndDate.Value.Date == GetEndDate().Date)
                    EndDate = null;
            }
        }

        public void CheckRulesToCompleteCompanion()
        {
            if (RequestDate == null)
                throw new Exception(TTUtils.CultureService.GetText("M26261", "Kalma Başlangıç Tarihi,boş olamaz!"));

            var endDate = GetEndDate();

            if (EndDate == null)
            {
                EndDate = endDate;
            } else if (!EndDate.HasValue || EndDate.Value.Date > endDate)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(CompanionName + " Adlı Refakatçinin " + EndDate.Value.Date.ToShortDateString() + " olan Kalma Bitiş Tarihi, " + endDate.ToShortDateString() +" olarak değiştirilmiştir.");
                EndDate = endDate;
            }
            if (Common.DateDiffV2(0, RequestDate.Value.Date, EndDate.Value.Date, true) < 0)
                throw new Exception(CompanionName + " Adlı Refakatçinin Kalma Bitiş Tarihi,  Kalma Başlangıç Tarihinden büyük olmalıdır!");

            if (SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.Date >= RequestDate.Value.Date)
                RequestDate = SubEpisode.InpatientAdmission.HospitalInPatientDate;

            StayingDateCount = Common.DateDiffV2(0, RequestDate.Value.Date, EndDate.Value.Date, true);

        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CompanionApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

         if (fromState == CompanionApplication.States.Active && toState == CompanionApplication.States.ExCompanion)
                PostTransition_Active2ExCompanion();
            else if (fromState == CompanionApplication.States.Active && toState == CompanionApplication.States.Cancelled)
                PostTransition_Active2Cancelled();
            else if (fromState == CompanionApplication.States.ExCompanion && toState == CompanionApplication.States.Cancelled)
                PostTransition_ExCompanion2Cancelled();



        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CompanionApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CompanionApplication.States.Active && toState == CompanionApplication.States.ExCompanion)
                UndoTransition_Active2ExCompanion(transDef);
        }

  
    }
}