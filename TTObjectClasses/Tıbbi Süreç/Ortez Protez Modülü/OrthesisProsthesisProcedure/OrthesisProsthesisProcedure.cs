
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
    public partial class OrthesisProsthesisProcedure : BaseOrthesisProsthesisProcedure
    {
        public partial class GetOrthesisProsthesisProcedureByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetOrthesisProsthesisProcedure_Class : TTReportNqlObject
        {
        }

        public partial class GetOrthesisProsthesisProcedureByAction_Class : TTReportNqlObject
        {
        }

        public partial class GetOrthesisProsthesisProcedureBySubEpisode_Class : TTReportNqlObject
        {
        }

        #region Methods
        //        public OrthesisProsthesisProcedure(OrthesisProsthesisRequest pRequest, string guid):this(pRequest.ObjectContext)
        //        {
        //            Guid procedureGuid = new Guid(guid);
        //
        //            this.ProcedureObject = (ProcedureDefinition)pRequest.ObjectContext.GetObject(procedureGuid,"PROCEDUREDEFINITION");
        //            pRequest.OrthesisProsthesisProcedures.Add (this);
        //        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject pObject = (ITTObject)this;
            if (pObject.IsNew && IsRequestReport == null)
            {
                IsRequestReport = true;
            }
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override string GetDVORaporTakipNo()
        {
            return RaporTakipNo;
        }


        public override void SetPerformedDate()
        {
            if (CreationDate == null || CreationDate > OrthesisProsthesisRequest.ProcessDate)
                CreationDate = OrthesisProsthesisRequest.ProcessDate;
            if (PerformedDate == null)
                PerformedDate = OrthesisProsthesisRequest.ProcessDate;
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();

            if (Eligible == null)
                Eligible = true;//ücretlendirilsin
            #endregion PreInsert
        }

        //public void AccountingOperationOld()
        //{
        //    // Ücretlendirme yapılır
        //    if (AccountTransactions.Count == 0)
        //        AccountOperation(AccountOperationTimeEnum.PREPOST);
        //    else
        //        ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);

        //    PayerTypeEnum? payerType = SubEpisode.OpenSubEpisodeProtocol.Payer.Type.PayerType;
        //    if (!payerType.HasValue)
        //        throw new TTException(TTUtils.CultureService.GetText("M27154", "Ücretlendirme sırasında hata oluştu. '") + SubEpisode.OpenSubEpisodeProtocol.Payer.Name + "' kurumunun tip bilgisine ulaşılamıyor.");

        //    if (payerType == PayerTypeEnum.Paid) // Ücretli hasta ise çıkılır
        //        return;

        //    if (PatientPay == true)
        //    {
        //        // Kurum Payı hasta payına çevrilir veya fiyatı hasta payının üstüne eklenip iptal edilir
        //        AccountTransaction payerAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).FirstOrDefault();
        //        AccountTransaction patientAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT).FirstOrDefault();

        //        if (payerAccTrx != null && patientAccTrx == null) // Sadece Kurum Payı varsa hasta payına çevrilir
        //            payerAccTrx.TurnToPatientShare(true);
        //        else if (payerAccTrx != null && patientAccTrx != null) // Kurum payı ve hasta payı varsa, kurum payı iptal edilip fiyatı hasta payının üstüne eklenir
        //        {
        //            //if (patientAccTrx.PricingDetail != null)  
        //            //    patientAccTrx.UnitPrice = patientAccTrx.PricingDetail.Price.Value;   // Fiyat direkt hasta payına da atılabilir ama indirim vs. varsa anlaşmada diye böyle yapılmadı
        //            patientAccTrx.UnitPrice = patientAccTrx.UnitPrice + payerAccTrx.UnitPrice;
        //            patientAccTrx.InvoiceInclusion = true;
        //            payerAccTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //        }
        //    }
        //    else
        //    {
        //        AccountTransaction payerAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).FirstOrDefault();
        //        AccountTransaction patientAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT).FirstOrDefault();
        //        if (payerAccTrx != null && patientAccTrx != null) // Katılım Payı ise (Kurum ve Hasta payı var)
        //        {
        //            BindingList<MinimumWageDefinition> minWageList = MinimumWageDefinition.GetByDate(ObjectContext, PricingDate.Value);

        //            if (minWageList.Count == 0)
        //                throw new TTException("Ücretlendirme sırasında hata oluştu. Asgari Ücret Tanım Ekranında " + PricingDate.Value.ToShortDateString() + " tarihi için geçerli fiyat bulunamadı.");
        //            else if (minWageList.Count > 1)
        //                throw new TTException("Ücretlendirme sırasında hata oluştu. Asgari Ücret Tanım Ekranında " + PricingDate.Value.ToShortDateString() + " tarihi için geçerli birden çok fiyat bulundu.");
        //            else if (minWageList.Count == 1)
        //            {
        //                if (patientAccTrx.UnitPrice > Math.Round((double)(minWageList[0].GrossWage * 0.75), 2)) // Hasta Payı Asgari Ücretin %75 inden fazla olamaz kontrolü
        //                    patientAccTrx.UnitPrice = Math.Round((double)(minWageList[0].GrossWage * 0.75), 2);
        //            }
        //        }
        //    }
        //}

        public void AccountingOperation(SubEpisodeProtocol pSEP)
        {
            DateTime pricingDate = Common.RecTime();
            if (PricingDate.HasValue) // PricingDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = PricingDate.Value;
            else if (ActionDate.HasValue) // PricingDate boş ActionDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = ActionDate.Value;

            ArrayList col = new ArrayList();
            col = pSEP.Protocol.CalculatePrice(ProcedureObject, EpisodeAction.Episode.PatientStatus, null, pricingDate, EpisodeAction.Episode.Patient.AgeCompleted);

            if (col.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(950, new string[] { ProcedureObject.Name }));

            foreach (ManipulatedPrice mpd in col)
            {
                if (PayRatio == OrthesisPayRatio.PatientPay)   // Hasta Öder
                {
                    mpd.PatientPrice = mpd.Price;
                    mpd.PayerPrice = 0;
                }
                else if (PayRatio == OrthesisPayRatio.PayerPay) // Kurum Öder
                {
                    mpd.PatientPrice = 0;
                    mpd.PayerPrice = mpd.Price;
                }
                else if (PayRatio == OrthesisPayRatio.Percent10) // Hasta %10 , Kurum %90 öder
                {
                    mpd.PatientPrice = mpd.Price * 0.1;
                    mpd.PayerPrice = mpd.Price - mpd.PatientPrice;

                }
                else if (PayRatio == OrthesisPayRatio.Percent20) // Hasta %20 , Kurum %80 öder
                {
                    mpd.PatientPrice = mpd.Price * 0.2;
                    mpd.PayerPrice = mpd.Price - mpd.PatientPrice;
                }

                // Hasta Payı Asgari Ücretin %75 inden fazla olamaz kontrolü
                if (mpd.PatientPrice > 0 && mpd.PayerPrice > 0)
                {
                    BindingList<MinimumWageDefinition> minWageList = MinimumWageDefinition.GetByDate(ObjectContext, pricingDate);

                    if (minWageList.Count == 0)
                        throw new TTException("Ücretlendirme sırasında hata oluştu. Asgari Ücret Tanım Ekranında " + pricingDate.ToShortDateString() + " tarihi için geçerli fiyat bulunamadı.");
                    else if (minWageList.Count > 1)
                        throw new TTException("Ücretlendirme sırasında hata oluştu. Asgari Ücret Tanım Ekranında " + pricingDate.ToShortDateString() + " tarihi için geçerli birden çok fiyat bulundu.");
                    else if (minWageList.Count == 1)
                    {
                        if (mpd.PatientPrice > (minWageList[0].GrossWage * 0.75))
                            mpd.PatientPrice = minWageList[0].GrossWage * 0.75;
                    }
                }

                if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                    pSEP.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PayerPrice > 0)
                    pSEP.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PatientPrice > 0)
                    pSEP.AddAccountTransaction(AccountOwnerType.PATIENT, this, mpd, null, AccountOperationTimeEnum.PRE);
            }
        }

        public override void AccountOperation(AccountOperationTimeEnum pPreAccounting = AccountOperationTimeEnum.PREPOST, SubEpisodeProtocol outSEP = null)
        {
            // Ücretlenmemesi gereken durumlar
            if (IsOldAction == true || Eligible != true || ProcedureObject == null || ProcedureObject.Chargable != true)
                return;

            // OrthesisProsthesisRequest ler split olduktan (değiştiktan) sonra tekrar ücretlenmemesi için 
            if (OrthesisProsthesisRequest != null && AccountTransactions.Any(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled))
            {
                TTObjectContext context = new TTObjectContext(true);
                OrthesisProsthesisProcedure orjOPP = context.GetObject(ObjectID, ObjectDef, false) as OrthesisProsthesisProcedure;
                if (orjOPP != null && orjOPP.OrthesisProsthesisRequest != null && orjOPP.OrthesisProsthesisRequest.ObjectID != OrthesisProsthesisRequest.ObjectID)
                    return;
            }

            if (PayRatio.HasValue == false)
            {
                base.AccountOperation(pPreAccounting, outSEP);
                return;
            }

            if (SubEpisode == null)
                throw new TTException("Ücretlendirilecek hizmetin altvaka bilgisine ulaşılamıyor. (Hizmet: " + ProcedureObject.Code + " " + ProcedureObject.Name + ")");

            SubEpisodeProtocol sep = null;
            if (outSEP != null)
                sep = outSEP;
            else
                sep = SubEpisode.OpenSubEpisodeProtocol;

            if (sep == null)
                throw new TTException(SystemMessage.GetMessage(663));

            CancelMyAccountTransactions();

            AccountingOperation(sep);
        }

        public override void ChangeMyProtocol(SubEpisodeProtocol pSEP)
        {
            if (PayRatio.HasValue == false)
            {
                base.ChangeMyProtocol(pSEP);
                return;
            }

            if (pSEP == null)
                throw new TTException(TTUtils.CultureService.GetText("M27247", "Yeniden fiyatlandırma yapılacak takip boş olamaz."));

            List<AccountTransaction> cancelledAtList = CancelMyAccountTransactions();   // CancelMyAccountTransactionsExceptPaid();

            AccountingOperation(pSEP);

            List<AccountTransaction> newAtList = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).ToList();
            AccountTransaction.ControlAndCopyAfterChangeMyProtocol(cancelledAtList, newAtList); // İptal edilen AccTrx ler üzerindeki bilgileri, yeni oluşturulan AccTrx lere kopyalar
        }

        public override void AccountOperationAfterUpdate()
        {
            TTObjectContext objContext = new TTObjectContext(true);
            OrthesisProsthesisProcedure originalOPP = objContext.GetObject(ObjectID, ObjectDef, false) as OrthesisProsthesisProcedure;
            if (originalOPP != null)
            {
                if (Eligible != true || CurrentStateDef.Status == StateStatusEnum.Cancelled) // Eligible false ise veya iptal durumunda bir adımda ise ücretler iptal edilip çıkılır
                {
                    CancelMyAccountTransactions();
                    return;
                }

                if (AccountTransactions.Count == 0) // Insert sırasında ücretlenmemişse burada ücretlensin
                    AccountOperation();
                
                else if ((PricingDate.HasValue && originalOPP.PricingDate.HasValue && PricingDate.Value.Date != originalOPP.PricingDate.Value.Date) || // PricingDate değişmiş
                    (Amount.HasValue && originalOPP.Amount.HasValue && Amount.Value != originalOPP.Amount.Value) || // Amount değişmiş
                    (Eligible == true && originalOPP.Eligible != true) || // Eligible true yapılmış
                    (ProcedureObject != null && originalOPP.ProcedureObject != null && ProcedureObject.ObjectID != originalOPP.ProcedureObject.ObjectID) || // ProcedureObject değişmiş
                    (SubEpisode != null && originalOPP.SubEpisode != null && SubEpisode.ObjectID != originalOPP.SubEpisode.ObjectID) || // SubEpisode değişmiş
                    (PayRatio.HasValue && originalOPP.PayRatio.HasValue == false) ||
                    (PayRatio.HasValue == false && originalOPP.PayRatio.HasValue) ||
                    (PayRatio.HasValue && originalOPP.PayRatio.HasValue && PayRatio.Value != originalOPP.PayRatio.Value))

                    ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);
            }
        }

        public override bool CheckSubepisodeClosingDate()
        {
            return false;
        }

        #endregion Methods
    }
}