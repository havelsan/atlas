
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
    /// Avans İade İşlemi
    /// </summary>
    public partial class AdvanceBack : EpisodeAccountAction, IWorkListEpisodeAction
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            if (memberName != "SUBEPISODE")
                switch (memberName)
                {
                    case "ADVANCEBACKDOCUMENT":
                        {
                            AdvanceBackDocument value = (AdvanceBackDocument)newValue;
                            #region ADVANCEBACKDOCUMENT_SetParentScript
                            if (value != null)
                                value.EpisodeAccountAction = this;
                            #endregion ADVANCEBACKDOCUMENT_SetParentScript
                        }
                        break;

                    default:
                        base.RunSetMemberValueScript(memberName, newValue);
                        break;

                }
        }

        protected void PostTransition_New2Paid()
        {
            // From State : New   To State : Paid
            #region PostTransition_New2Paid

            AdvanceBackDocumentGroup adg = AdvanceBackDocument.AddDocumentGroup("I", TTUtils.CultureService.GetText("M25199", "Avans Iade"));
            AdvanceBackDocumentDetail addet = adg.AddDocumentDetail(TTUtils.CultureService.GetText("M11258", "Avans İade"), 1, (double)AdvanceBackDocument.TotalPrice);
            AdvanceBackDocument.AddAPRTransaction((AccountPayableReceivable)Episode.Patient.MyAPR(), -1 * (double)AdvanceBackDocument.TotalPrice, (APRTrxType)APRTrxType.GetByType(ObjectContext, 6)[0]);
            AdvanceBackDocument.CurrentStateDefID = AdvanceBackDocument.States.Paid;
            AdvanceBackDocument.TotalPrice = TotalPrice;
            AdvanceBackDocument.SendToAccounting = false;

            foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt())
            {
                // Odenmemis hizmetleri Avans ile kapat
                if (accTrx.RemainingPrice > 0)
                {
                    Currency accTrxRemainingPrice = accTrx.RemainingPrice;
                    foreach (Advance advance in Episode.Advances)
                    {
                        if (advance.RemainingPrice > 0 && !advance.IsCancelled)
                        {
                            AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);
                            accTrxDoc.AccountDocumentDetail = addet;
                            accTrxDoc.AccountTransaction = accTrx;

                            PatientPaymentDetail ppDetail = new PatientPaymentDetail(ObjectContext);
                            if (accTrxRemainingPrice <= advance.RemainingPrice)
                            {
                                ppDetail.CreatePPDetail(accTrx, advance.AdvanceDocument, accTrxRemainingPrice, PaymentTypeEnum.Advance);
                                accTrxRemainingPrice = 0;
                                accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                break;
                            }
                            else
                            {
                                accTrxRemainingPrice -= advance.RemainingPrice;
                                ppDetail.CreatePPDetail(accTrx, advance.AdvanceDocument, advance.RemainingPrice, PaymentTypeEnum.Advance);
                            }
                        }
                    }
                }
            }

            DateTime? advanceDate = null;

            foreach (Advance advance in Episode.Advances)
            {
                if (advance.IsCancelled == false)
                {
                    if (advance.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid && advance.AdvanceDocument.Used != true)
                    {
                        advance.AdvanceDocument.Used = true;
                        advance.AdvanceDocument.PatientPaymentDetail.FirstOrDefault(x => x.AccountTransaction == null).IsBack = true;

                        if (advance.AdvanceDocument.AccountVoucherDetails.Count > 0) // Avans işleminin AccountVoucherDetail i varsa
                        {
                            if (advanceDate == null || (advanceDate != null && advance.AdvanceDocument.DocumentDate.Value < advanceDate.Value)) // En küçük avans tarihi set edilir
                                advanceDate = advance.AdvanceDocument.DocumentDate.Value;
                        }
                    }
                }
            }

            CreateAccountVoucher(advanceDate);

            // Avans İade işlemi vezneden yapılıyorsa hemen muhasebeleştiriliyor,
            // muhasebe yetkilisi mutemedi tarafından yapılıyorsa hemen muhasebeleşmeyecek.
            /*
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (this.AdvanceBackDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.MainCashOffice)
                {
                    IList<AccountDocument.ReceiptInfo> ReceiptList = new List<AccountDocument.ReceiptInfo>();
                    AccountDocument.ReceiptInfo RI;
                    RI = this.AdvanceBackDocument.CreateReceiptInfoForAccounting();
                    RI.Description = "Hasta: " + this.Episode.Patient.ID.ToString() + " " + this.Episode.Patient.FullName.ToString() + " / H.Protokol No: " + this.Episode.HospitalProtocolNo + " / " + this.REASONOFRETURN;

                    if (RI != null)
                    {
                        ReceiptList.Add(RI);
                        this.AdvanceBackDocument.SendToAccounting = true;
                    }

                    if (ReceiptList.Count > 0)
                    {
                        TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                    }
                }
            }
            */
            #endregion PostTransition_New2Paid
        }

        protected void UndoTransition_New2Paid(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Paid
            #region UndoTransition_New2Paid
            NoBackStateBack();
            #endregion UndoTransition_New2Paid
        }

        #region Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AdvanceBack).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AdvanceBack.States.New && toState == AdvanceBack.States.Paid)
                PostTransition_New2Paid();
        }

        //Relation zorululuğunu ortadan kaldırmak için yapıldı. auto.cs ile gerek kalmadı.
        //protected override void OnBeforeImportFromObject(DataRow dataRow)
        //{
        //    base.OnBeforeImportFromObject(dataRow);

        //    dataRow["ADVANCEBACKDOCUMENT"] = DBNull.Value;
        //}

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AdvanceBack).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AdvanceBack.States.New && toState == AdvanceBack.States.Paid)
                UndoTransition_New2Paid(transDef);
        }

        public void PrepareNewAdvanceBack()
        {
            if (CurrentStateDefID == AdvanceBack.States.New)
            {
                Currency advanceTotal = 0;
                Currency receiptTotal = 0;
                Currency advanceBackTotal = 0;
                Currency receiptBackTotal = 0;
                Currency serviceTotal = 0;

                CashOfficeDefinition selectedCashOffice;

                ResUser resUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25322", "Bu kullanıcı için tanımlı bir vezne yok ya da Avans iade etmeye yetikiniz bulunmamaktadır!"));

                //this.cmdOK.Visible = false;

                //Episode da tamamlanmamis bir Avans Iade varsa yenisi baslatilmayacak
                foreach (AdvanceBack ea in Episode.AdvanceBacks)
                {
                    if (ea.IsCancelled == false)
                    {
                        if (ea.ObjectID != ObjectID && ea.CurrentStateDefID != AdvanceBack.States.Paid)
                            throw new TTUtils.TTException(SystemMessage.GetMessage(181));
                    }
                }

                //if ((advanceTotal + receiptTotal) - (advanceBackTotal + receiptBackTotal + serviceTotal) <= 0)
                //    throw new TTUtils.TTException(SystemMessage.GetMessage(177));
                //else
                //TotalPrice = (advanceTotal + receiptTotal) - (advanceBackTotal + receiptBackTotal + serviceTotal);

                CashOfficeName = selectedCashOffice.Name;

                AdvanceBackDocument = new AdvanceBackDocument(ObjectContext);
                AdvanceBackDocument.CashOffice = selectedCashOffice;
                AdvanceBackDocument.DocumentDate = DateTime.Now.Date;
                AdvanceBackDocument.PatientName = Episode.Patient.Name + " " + Episode.Patient.Surname;
                AdvanceBackDocument.PatientNo = Episode.Patient.ID.Value;
                AdvanceBackDocument.CurrentStateDefID = AdvanceBackDocument.States.New;
                AdvanceBackDocument.ResUser = resUser;

                PatientEpisodePaymentDetail pepd = Episode.CalculatePatientDebt(Episode, null, null);

                ADVANCETOTAL = pepd.AdvanceTotal;
                RECEIPTTOTAL = pepd.ReceiptTotal;
                ADVANCEBACKTOTAL = pepd.AdvanceBackTotal;
                RECEIPTBACKTOTAL = pepd.ReceiptBackTotal;
                SERVICETOTAL = pepd.ServiceTotal;
                BONDTOTAL = pepd.BondTotal;

                if (pepd.RemainingDebt >= 0)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(177));

                TotalPrice = 0 - pepd.RemainingDebt;
                AdvanceBackDocument.TotalPrice = TotalPrice;

                foreach (Advance advance in Episode.Advances)
                {
                    AdvanceBackAdvanceDetail advDetail = new AdvanceBackAdvanceDetail(ObjectContext);
                    advDetail.AdvanceDate = advance.AdvanceDocument.DocumentDate;
                    advDetail.AdvanceDocumentNo = advance.AdvanceDocument.DocumentNo;
                    advDetail.AdvanceCrCardDocumentNo = advance.AdvanceDocument.CreditCardDocumentNo;
                    advDetail.TotalPrice = advance.AdvanceDocument.TotalPrice;
                    advDetail.Status = advance.AdvanceDocument.CurrentStateDef.DisplayText;
                    AdvanceBackAdvanceDetail.Add(advDetail);

                    if (advance.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
                        advanceTotal = advanceTotal + advance.AdvanceDocument.TotalPrice.Value;
                }


                //    foreach (EpisodeAction ea in Episode.EpisodeActions)
                //    {
                //        if (ea.IsCancelled == false)
                //        {
                //            Advance advanceAct = ea as Advance;
                //            if (advanceAct != null)
                //            {
                //                AdvanceBackAdvanceDetail advDetail = new AdvanceBackAdvanceDetail(ObjectContext);
                //                advDetail.AdvanceDate = advanceAct.AdvanceDocument.DocumentDate;
                //                advDetail.AdvanceDocumentNo = advanceAct.AdvanceDocument.DocumentNo;
                //                advDetail.AdvanceCrCardDocumentNo = advanceAct.AdvanceDocument.CreditCardDocumentNo;
                //                advDetail.TotalPrice = advanceAct.AdvanceDocument.TotalPrice;
                //                advDetail.Status = advanceAct.AdvanceDocument.CurrentStateDef.DisplayText;
                //                AdvanceBackAdvanceDetail.Add(advDetail);
                //                if (advanceAct.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
                //                    advanceTotal = advanceTotal + advanceAct.AdvanceDocument.TotalPrice.Value;
                //            }
                //            Receipt receiptAct = ea as Receipt;
                //            if (receiptAct != null)
                //            {
                //                if (receiptAct.ReceiptDocument.CurrentStateDefID == ReceiptDocument.States.Paid)
                //                    receiptTotal = receiptTotal + receiptAct.TotalPayment.Value;
                //            }
                //            AdvanceBack advBackAct = ea as AdvanceBack;
                //            if (advBackAct != null)
                //            {
                //                if (advBackAct.AdvanceBackDocument.CurrentStateDefID == AdvanceBackDocument.States.Paid)
                //                    advanceBackTotal = advanceBackTotal + advBackAct.AdvanceBackDocument.TotalPrice.Value;
                //            }
                //            ReceiptBack ReceiptBackAct = ea as ReceiptBack;
                //            if (ReceiptBackAct != null)
                //            {
                //                if (ReceiptBackAct.ReceiptBackDocument.CurrentStateDefID == ReceiptBackDocument.States.Paid)
                //                    receiptBackTotal = receiptBackTotal + ReceiptBackAct.ReceiptBackDocument.TotalPrice.Value;
                //            }
                //        }
                //    }

                //    IList transactionsList = AccountTransaction.GetIncludedTrxsExceptCancelledByEpisode(ObjectContext, Episode.Patient.MyAPR().ObjectID, Episode.ObjectID);
                //    foreach (AccountTransaction accTrx in transactionsList)
                //    {
                //        if (accTrx.PackageDefinition == null && accTrx.InvoiceInclusion == true)  // Paket içi hizmet/malzemeler toplama dahil edilmez
                //            serviceTotal = serviceTotal + (accTrx.UnitPrice * accTrx.Amount).Value;
                //    }

                //}
            }
        }

        public void CreateAccountVoucher(DateTime? advanceDate)
        {
            if (!advanceDate.HasValue)
                return;

            if (SystemParameter.GetParameterValue("CREATEACCOUNTVOUCHERFORCASHOFFICE", "TRUE") == "TRUE")
            {
                const string code = "340.11.01"; // Avans İade için muhasebe kodu

                AccountPeriodDefinition accountPeriodDefinition = AccountPeriodDefinition.GetByDate(ObjectContext, advanceDate.Value);
                AccountVoucherCodeDefinition accountVoucherCodeDefinition = AccountVoucherCodeDefinition.GetByCode(ObjectContext, code);
                AccountVoucher accountVoucher = AccountVoucher.GetOrCreateForCashOffice(ObjectContext, accountPeriodDefinition, accountVoucherCodeDefinition);
                accountVoucher.AddDetail(TotalPrice * -1, AdvanceBackDocument);
            }
        }
    }
}