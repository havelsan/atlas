using Core.Models;

using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public interface IInvoicePaymentService
    {
        Guid NewInvoicePayment(InvoicePaymentFormModel model);
        void CancelInvoicePayment(Guid PIPObjectId, string CancelDesc);
    }

    public class InvoicePaymentService : Core.Services.IInvoicePaymentService
    {
        public Guid NewInvoicePayment(InvoicePaymentFormModel ipfm)
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                if (ipfm == null || ipfm.InvoicePayment == null || ipfm.InvoicePaymentDetailList == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25647", "Fatura tahsilat işlemi gerekli veri bulunamadı."));
                if (ipfm.InvoicePayment.Payer == null && !ipfm.InvoicePayment.Payer.ObjectID.HasValue)
                    throw new TTException(TTUtils.CultureService.GetText("M25652", "Fatura tahsilat işlemi için Kurum seçiniz."));
                if (ipfm.InvoicePayment.BankAccount == null || !ipfm.InvoicePayment.BankAccount.HasValue)
                    throw new TTException(TTUtils.CultureService.GetText("M25650", "Fatura tahsilat işlemi için Hesap seçiniz."));
                if (!ipfm.InvoicePayment.DecountDate.HasValue)
                    throw new TTException(TTUtils.CultureService.GetText("M25649", "Fatura tahsilat işlemi için Dekont Tarihi giriniz."));
                if (DateTime.Compare(ipfm.InvoicePayment.DecountDate.Value.Date, Common.RecTime().Date) > 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25402", "Dekont Tarihi bugünden ileri olamaz."));
                if (string.IsNullOrEmpty(ipfm.InvoicePayment.DecountNo))
                    throw new TTException(TTUtils.CultureService.GetText("M25648", "Fatura tahsilat işlemi için Dekont No giriniz."));
                if (ipfm.InvoicePayment.PaymentPrice == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25653", "Fatura tahsilat işlemi için Ödeme Tutarı giriniz."));
                if (ipfm.InvoicePaymentDetailList.Count == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25654", "Fatura tahsilat işlemi ierisinde en az bir fatura olmalıdır."));
                // Tahsilatın Ödeme Tutarı ile faturaların Ödeme Tutarı toplamı eşit mi kontrolü             
                Currency? detailPaymentTotal = 0;
                foreach (InvoicePaymentDetailModel ipdm in ipfm.InvoicePaymentDetailList)
                    detailPaymentTotal += ipdm.Payment;
                if (ipfm.InvoicePayment.PaymentPrice != detailPaymentTotal)
                    throw new TTException(TTUtils.CultureService.GetText("M26992", "Tahsilat işlemindeki Ödeme Tutarı ile faturaların Ödenen Tutar toplamı eşit olmalıdır."));
                // Tahsilatın Kesinti Tutarı ile faturaların Kesinti Tutarı toplamı eşit mi kontrolü
                if (ipfm.InvoicePayment.Deduction < 0)
                    ipfm.InvoicePayment.Deduction = 0;
                Currency? detailDeductionTotal = 0;
                foreach (InvoicePaymentDetailModel ipdm in ipfm.InvoicePaymentDetailList)
                    detailDeductionTotal += ipdm.Deduction;
                if (ipfm.InvoicePayment.Deduction != detailDeductionTotal)
                    throw new TTException(TTUtils.CultureService.GetText("M26991", "Tahsilat işlemindeki Kesinti Tutarı ile faturaların Kesinti Tutarı toplamı eşit olmalıdır."));
                // PayerInvoicePayment ve PayerInvoicePaymentDetail ler oluşturulur
                TTObjectContext objectContext = new TTObjectContext(false);
                PayerInvoicePayment pip = new PayerInvoicePayment(objectContext);
                pip.CurrentStateDefID = PayerInvoicePayment.States.Paid;
                BankDecount bankDecount = new BankDecount(objectContext);
                pip.BankDecount = bankDecount;
                pip.BankDecount.DecountNo = ipfm.InvoicePayment.DecountNo;
                pip.BankDecount.DecountDate = ipfm.InvoicePayment.DecountDate;
                pip.BankDecount.Price = ipfm.InvoicePayment.PaymentPrice;
                pip.BankDecount.BankAccount = objectContext.GetObject(ipfm.InvoicePayment.BankAccount.Value, typeof (BankAccountDefinition)) as BankAccountDefinition;
                pip.Payer = objectContext.GetObject(ipfm.InvoicePayment.Payer.ObjectID.Value, typeof (PayerDefinition)) as PayerDefinition;
                pip.ResUser = Common.CurrentResource;
                pip.CreateDate = Common.RecTime();
                pip.Description = ipfm.InvoicePayment.Description;
                pip.TotalPrice = ipfm.InvoicePayment.PaymentPrice;
                pip.Deduction = ipfm.InvoicePayment.Deduction;
                if (pip?.Payer?.Type.PayerType == PayerTypeEnum.Paid || pip?.Payer?.Type.PayerType == PayerTypeEnum.UnPaid)
                    throw new TTException(TTUtils.CultureService.GetText("M27159", "Ücretli veya Ücretsiz türündeki kurumlara fatura tahsilatı yapılamaz."));
                List<InvoiceCollection> ICList = new List<InvoiceCollection>();
                foreach (InvoicePaymentDetailModel ipdm in ipfm.InvoicePaymentDetailList)
                {
                    if (ipdm.Payment == 0)
                        throw new TTException(TTUtils.CultureService.GetText("M26987", "Tahsil edilecek Fatura için Ödenen Tutar girilmelidir."));
                    if (ipdm.Deduction < 0)
                        ipdm.Deduction = 0;
                    if ((ipdm.Payment + ipdm.Deduction) > ipdm.InvoiceRestPrice)
                        throw new TTException(TTUtils.CultureService.GetText("M26653", "Ödenen Tutar ve Kesinti Tutarının toplamı Kalan Tutardan fazla olmamalıdır."));
                    InvoiceCollectionDetail icd = objectContext.GetObject(ipdm.InvoiceCollectionDetailID, typeof (InvoiceCollectionDetail)) as InvoiceCollectionDetail;
                    if (icd == null)
                        throw new TTException("Tahsil edilecek fatura bilgisine ulaşılamadı. Fatura No : " + ipdm.InvoiceNo);
                    if (icd.CurrentStateDefID != InvoiceCollectionDetail.States.Invoiced && icd.CurrentStateDefID != InvoiceCollectionDetail.States.PartialPaid)
                        throw new TTException("Tahsil edilecek fatura 'Faturalandı' veya 'Kısmen Ödendi' durumda olmalıdır. Fatura Durumu : " + icd.CurrentStateDef.DisplayText + "Fatura No : " + icd?.PayerInvoiceDocument?.DocumentNo);
                    if (icd.InvoiceCollection.Payer.ObjectID != pip.Payer.ObjectID)
                        throw new TTException("Faturanın kurumu ile Fatura Tahsilat işleminin kurumu aynı olmalıdır. Fatura No : " + icd?.PayerInvoiceDocument?.DocumentNo);
                    if (icd.InvoiceCollection.InvoiceTerm == null)
                        throw new TTException("Tahsil edilecek faturanın dönem bilgisi dolu olmalıdır. Fatura No : " + icd?.PayerInvoiceDocument?.DocumentNo);
                    if (icd.InvoiceCollection.InvoiceTerm.CurrentStateDefID != InvoiceTerm.States.Closed)
                        throw new TTException("Tahsil edilecek faturanın dönemi 'Kapalı' durumda olmalıdır. Fatura No : " + icd?.PayerInvoiceDocument?.DocumentNo);
                    PayerInvoicePaymentDetail pipDetail = new PayerInvoicePaymentDetail(objectContext);
                    pipDetail.PIP = pip;
                    pipDetail.ICD = icd;
                    pipDetail.InvoiceDate = Convert.ToDateTime(ipdm.InvoiceDate);
                    pipDetail.InvoiceNo = ipdm.InvoiceNo;
                    pipDetail.InvoicePrice = ipdm.InvoicePrice;
                    pipDetail.InvoiceRestPrice = ipdm.InvoiceRestPrice;
                    pipDetail.Payment = ipdm.Payment;
                    pipDetail.Deduction = ipdm.Deduction;
                    icd.Payment = (icd.Payment.HasValue ? icd.Payment.Value : Currency.Parse("0")) + pipDetail.Payment;
                    icd.Deduction = (icd.Deduction.HasValue ? icd.Deduction.Value : Currency.Parse("0")) + pipDetail.Deduction;
                    if (icd.InvoiceRestPrice > 0)
                        icd.CurrentStateDefID = InvoiceCollectionDetail.States.PartialPaid;
                    else
                        icd.CurrentStateDefID = InvoiceCollectionDetail.States.Paid;
                    if (!ICList.Contains(icd.InvoiceCollection))
                        ICList.Add(icd.InvoiceCollection);
                }

                foreach (InvoiceCollection ic in ICList)
                    ic.SetStateAfterInvoicePayment();
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                return pip.ObjectID;
            }
        }

        public void CancelInvoicePayment(Guid PIPObjectId, string CancelDesc)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            if (string.IsNullOrEmpty(CancelDesc))
                throw new TTException(TTUtils.CultureService.GetText("M26085", "İptal açıklaması zorunludur lütfen açıklama alanını doldurunuz."));
            PayerInvoicePayment pip = objectContext.GetObject(PIPObjectId, typeof (PayerInvoicePayment)) as PayerInvoicePayment;
            if (pip == null)
                throw new TTException(TTUtils.CultureService.GetText("M26088", "İptal edilecek Fatura Tahsilat işlemi bulunamadı."));
            if (pip.CurrentStateDefID == PayerInvoicePayment.States.Cancelled)
                throw new TTException(TTUtils.CultureService.GetText("M25655", "Fatura Tahsilat işlemi zaten iptal durumdadır."));
            if (pip.ResUser != null && pip.ResUser.ObjectID != Common.CurrentResource.ObjectID)
                throw new TTException(TTUtils.CultureService.GetText("M25656", "Fatura Tahsilat işlemini yapan kullanıcı iptal edebilir."));
            pip.CurrentStateDefID = PayerInvoicePayment.States.Cancelled;
            pip.CancelDescription = CancelDesc;
            objectContext.Save();
            objectContext.FullPartialllyLoadedObjects();
        }
    }
}