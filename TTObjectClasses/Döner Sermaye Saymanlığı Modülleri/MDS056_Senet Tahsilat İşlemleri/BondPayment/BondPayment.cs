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
    /// Senet Tahsilat
    /// </summary>
    public partial class BondPayment : EpisodeAccountAction
    {

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            if (memberName != "SUBEPISODE")
                switch (memberName)
                {
                    case "BONDPAYMENTDOCUMENT":
                        {
                            BondPaymentDocument value = (BondPaymentDocument)newValue;
                            #region BONDPAYMENTDOCUMENT_SetParentScript
                            if (value != null)
                                value.EpisodeAccountAction = this;
                            #endregion BONDPAYMENTDOCUMENT_SetParentScript
                        }
                        break;

                    default:
                        base.RunSetMemberValueScript(memberName, newValue);
                        break;
                }
        }
        public void PostTransition_2Paid()
        {
            if (PaymentPrice.HasValue == false && PaymentPrice == 0)
                throw new TTException(TTUtils.CultureService.GetText("M26876", "Sıfır tutarında bir ödeme yapılamaz!"));

            if (BondPaymentDetails.Where(x => x.Paid == true).Count() == 0)
                throw new TTException(TTUtils.CultureService.GetText("M26651", "Ödenecek vade seçilmedi!"));

            BondPaymentDocument.CheckPaymentType<BondPayment>();

            if (BondPaymentDocument.PaymentType == PaymentTypeEnum.Bank)
            {
                if (BondPaymentDocument.BankDecount.BankAccount == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(189));

                if (string.IsNullOrEmpty(BondPaymentDocument.BankDecount.DecountNo))
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25234", "Bankadan Para Transferi için Dekont Numarası boş olamaz."));

                if (!BondPaymentDocument.BankDecount.DecountDate.HasValue)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25235", "Bankadan Para Transferi için Dekont Tarihi boş olamaz."));
            }

            BondPaymentDocument.TotalPrice = PaymentPrice;

            if (BondPaymentDocument.PaymentType != PaymentTypeEnum.Bank)
            {
                ReceiptCashOfficeDefinition selectedRCODef = ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, BondPaymentDocument.CashOffice.ObjectID.ToString()).OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();

                if (selectedRCODef == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25347", "Bu vezne için tanımlanmış aktif bir vezne alındı numarası bulunamadı."));

                ((ITTObject)BondPaymentDocument.BankDecount).Delete();
                BondPaymentDocument.BankDecount = null;

                switch (BondPaymentDocument.PaymentType)
                {
                    case PaymentTypeEnum.Cash:
                        {
                            Cash cash = new Cash(ObjectContext) { Price = TotalPrice, CurrencyType = CurrencyTypeDefinition.GetByQref(ObjectContext, "TL")[0], AccountDocument = BondPaymentDocument };
                            BondPaymentDocument.CashPayment.Add(cash);
                            selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                            BondPaymentDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                            ReceiptCashOfficeDefinition.SetNextReceiptNumber(selectedRCODef);
                            BondPaymentDocument.SpecialNo.GetNextValue(BondPaymentDocument.ResUser.ID.ToString(), Common.RecTime().Year);
                        }
                        break;
                    case PaymentTypeEnum.CreditCard:
                        {
                            CreditCard creditCard = new CreditCard(ObjectContext) { Price = TotalPrice, AccountDocument = BondPaymentDocument };
                            BondPaymentDocument.CreditCardPayments.Add(creditCard);
                            selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                            BondPaymentDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(selectedRCODef);
                            ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(selectedRCODef);
                            BondPaymentDocument.SpecialNo.GetNextValue(BondPaymentDocument.ResUser.ID.ToString(), Common.RecTime().Year);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                BondPaymentDocument.BankDecount.Price = PaymentPrice;
            }

            List<Bond> bonds = new List<Bond>();
            foreach (BondPaymentDetail bondPaymentDet in BondPaymentDetails.Where(x => x.Paid == true))
            {
                bondPaymentDet.BondDetail.CurrentStateDefID = BondDetail.States.Paid;
                if (BondPaymentDocument.BankDecount != null && BondPaymentDocument.BankDecount.DecountDate.HasValue)
                    bondPaymentDet.BondDetail.PaymentDate = BondPaymentDocument.BankDecount.DecountDate;
                else
                    bondPaymentDet.BondDetail.PaymentDate = BondPaymentDocument.DocumentDate;

                if (!bonds.Contains(bondPaymentDet.BondDetail.Bond))
                    bonds.Add(bondPaymentDet.BondDetail.Bond);
            }

            RemoveUnCheckedPaymetsFromContext();

            foreach (Bond bond in bonds)
            {
                bond.SetStateAfterPayment();
            }
            BondPaymentDocument.CurrentStateDefID = BondPaymentDocument.States.Paid;

            CreateAccountVoucher();
        }

        public void RemoveUnCheckedPaymetsFromContext()
        {
            //Remove unselected bondpaymentdetails from objectContext
            List<BondPaymentDetail> details = BondPaymentDetails.Where(x => x.Paid == false).ToList();
            foreach (BondPaymentDetail bondPaymentDetail in details)
            {
                ITTObject removeItem = BondPaymentDetails.FirstOrDefault(x => x.ObjectID == bondPaymentDetail.ObjectID);
                removeItem.Delete();
                removeItem = null;
            }
        }

        public void PostTransition_2Cancelled()
        {
            List<Bond> bonds = new List<Bond>();
            foreach (BondPaymentDetail bondPaymentDet in BondPaymentDetails)
            {
                if (bondPaymentDet.Paid == true)
                {
                    if (bondPaymentDet.BondDetail.Bond.CurrentStateDefID == Bond.States.Restructured)
                        throw new TTException(TTUtils.CultureService.GetText("M27208", "Yapılandırıldı durumundaki Senet işleminin Senet Tahsilatı iptal edilemez."));

                    bondPaymentDet.BondDetail.CurrentStateDefID = BondDetail.States.New;
                    bondPaymentDet.BondDetail.PaymentDate = null;

                    if (!bonds.Contains(bondPaymentDet.BondDetail.Bond))
                        bonds.Add(bondPaymentDet.BondDetail.Bond);
                }
            }
            foreach (Bond bond in bonds)
            {
                bond.SetStateAfterPayment();
            }
            BondPaymentDocument.CurrentStateDefID = BondPaymentDocument.States.Cancelled;
            BondPaymentDocument.CancelDate = Common.RecTime();

            CancelAccountVoucher();
        }

        public void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BondPayment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (toState == BondPayment.States.Paid)
                PostTransition_2Paid();
            if (toState == BondPayment.States.Cancelled)
                PostTransition_2Cancelled();
        }

        public void PrepareNewBondpayment()
        {
            ResUser _myResUser = Common.CurrentResource;
            CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, _myResUser);

            ReceiptCashOfficeDefinition selectedRCODef = null;
            if (selectedCashOffice != null)
            {
                selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(ObjectContext, selectedCashOffice.ObjectID);
                CashOfficeName = selectedCashOffice.Name;
            }

            if (Episode.Bonds.Count(x => x.CurrentStateDefID == Bond.States.UnPaid || x.CurrentStateDefID == Bond.States.PartialPaid) == 0)
                throw new TTException(TTUtils.CultureService.GetText("M25333", "Bu Protokol numarasına ait ödeme yapılabilecek bir Senet bulunmamaktadır."));

            if (BondPaymentDocument == null)
            {
                BondPaymentDocument = new BondPaymentDocument(ObjectContext);
                BondPaymentDocument.PayeeName = Episode.Patient.FullName;
                BondPaymentDocument.ResUser = _myResUser;
                BondPaymentDocument.CashOffice = selectedCashOffice;
                BondPaymentDocument.PaymentType = PaymentTypeEnum.Cash;
                BondPaymentDocument.DocumentDate = Common.RecTime();
                BondPaymentDocument.CurrentStateDefID = BondPaymentDocument.States.New;
                PaymentPrice = 0;
                TotalPrice = 0;

                if (selectedRCODef != null)
                    BondPaymentDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);

                foreach (Bond bond in Episode.Bonds.Where(x => x.CurrentStateDefID == Bond.States.UnPaid || x.CurrentStateDefID == Bond.States.PartialPaid))
                {
                    foreach (BondDetail bondDetail in bond.BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.New))
                    {
                        BondPaymentDetail bondPaymentDetail = new BondPaymentDetail(ObjectContext);
                        bondPaymentDetail.BondPayment = this;
                        bondPaymentDetail.BondDetail = bondDetail;
                        bondPaymentDetail.BondNo = bond.BondDocument.DocumentNo;
                        bondPaymentDetail.BondDetailDate = bondDetail.Date;
                        bondPaymentDetail.BondDetailPrice = bondDetail.Price;
                        TotalPrice += bondDetail.Price;
                    }
                }

                BondPaymentDocument.BankDecount = new BankDecount(ObjectContext);
                BondPaymentDocument.BankDecount.AccountDocument = BondPaymentDocument;
            }
        }

        public void CreateAccountVoucher()
        {
            if (SystemParameter.GetParameterValue("CREATEACCOUNTVOUCHERFORCASHOFFICE", "TRUE") == "TRUE")
            {
                const string code = "679.09.9099"; // Senet Tahsilat için muhasebe kodu

                AccountPeriodDefinition accountPeriodDefinition = AccountPeriodDefinition.GetByDate(ObjectContext, BondPaymentDocument.DocumentDate.Value);
                AccountVoucherCodeDefinition accountVoucherCodeDefinition = AccountVoucherCodeDefinition.GetByCode(ObjectContext, code);
                AccountVoucher accountVoucher = AccountVoucher.GetOrCreateForCashOffice(ObjectContext, accountPeriodDefinition, accountVoucherCodeDefinition);
                accountVoucher.AddDetail(PaymentPrice, BondPaymentDocument);
            }
        }

        public void CancelAccountVoucher()
        {
            foreach (AccountVoucherDetail avDetail in BondPaymentDocument.AccountVoucherDetails)
                avDetail.Cancel();
        }
    }
}