
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
    /// Muhasebe Yetkilisi Mutemedi Alındısı işlemi
    /// </summary>
    public partial class Receipt : EpisodeAccountAction, IWorkListEpisodeAction
    {
        [TTStorageManager.Attributes.TTSerializeProperty]
        public string DocumentNo { get; set; }
        [TTStorageManager.Attributes.TTSerializeProperty]
        public Guid CurrencyType { get; set; }

        public partial class ReceiptReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class EmergentPatientRecordFormQuery_Class : TTReportNqlObject
        {
        }

        public partial class ReceiptCreditCardReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class ReceiptDetailsQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetReceiptDebentures_Class : TTReportNqlObject
        {
        }

        public partial class OrthesisToothIVFPatientParticipationReport_Class : TTReportNqlObject
        {
        }

        public partial class GetForeignSgkPatientParticipationByDate_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            if (memberName != "SUBEPISODE")
                switch (memberName)
                {
                    case "RECEIPTDOCUMENT":
                        {
                            ReceiptDocument value = (ReceiptDocument)newValue;
                            #region RECEIPTDOCUMENT_SetParentScript
                            if (value != null)
                                value.EpisodeAccountAction = this;
                            #endregion RECEIPTDOCUMENT_SetParentScript
                        }
                        break;

                    default:
                        base.RunSetMemberValueScript(memberName, newValue);
                        break;

                }
        }

        protected void PostTransition_New2Paid()
        {
            ReceiptCashOfficeDefinition selectedRCODef = ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, ReceiptDocument.CashOffice.ObjectID.ToString()).OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();

            if (selectedRCODef == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25347", "Bu vezne için tanımlanmış aktif bir vezne alındı numarası bulunamadı."));

            // From State : New   To State : Paid
            #region PostTransition_New2Paid
            int paidCounter = 0;

            if (TotalPayment <= 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(114));
            ReceiptDocument.CheckPaymentType<Receipt>();
            Currency amountToBePaidReceiptProcedures = 0;
            Currency amountToBePaidReceiptMaterials = 0;
            if (ReceiptProcedures.Count > 0)
                amountToBePaidReceiptProcedures = ReceiptProcedures.Where(x => x.Paid == true).Sum(x => (decimal)x.PaymentPrice);
            //if (ReceiptMaterials.Count > 0)
            //    amountToBePaidReceiptMaterials = ReceiptMaterials.Where(x => x.Paid == true).Sum(x => (decimal)x.PaymentPrice);

            Currency? totalAmountToBePaid = amountToBePaidReceiptProcedures + amountToBePaidReceiptMaterials;

            if (TotalPayment > totalAmountToBePaid)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26652", "Ödenen Tutar Hizmet ve Malzeme toplam fiyatını geçemez!"));

            Currency _totalPayment = TotalPayment.Value;

            if (ReceiptProcedures.Count > 0)
            {
                ReceiptDocumentGroup rdg = new ReceiptDocumentGroup(ObjectContext);
                rdg.GroupCode = "H";
                rdg.GroupDescription = TTUtils.CultureService.GetText("M15953", "Hizmetler");
                rdg.AccountDocument = ReceiptDocument;

                List<AccountTransaction> trxList = AccountTransaction.GetTransactionsForReceiptByEpisode(ObjectContext, AccountTransaction.States.New, Episode.ObjectID, Episode.Patient.MyAPR().ObjectID).ToList<AccountTransaction>();

                foreach (ReceiptProcedure recProc in ReceiptProcedures)
                {
                    AccountTransaction accTrx = trxList.FirstOrDefault(x => x.ObjectID == recProc.AccountTransactionObjectID);

                    if (accTrx == null)
                        throw new TTException("PostTransition_New2Paid: Satır: 135 - Hizmet bulunamadı.");
                    else
                        recProc.AccountTransaction.Add(accTrx);
                    if (recProc.Paid == true && _totalPayment > 0 && recProc.PaymentPrice > 0)
                    {
                        bool? isParticipationShare = recProc.AccountTransaction[0].IsPatientParticipationShare();

                        ReceiptDocumentDetail rdd = new ReceiptDocumentDetail(ObjectContext);
                        rdd.ExternalCode = recProc.ExternalCode;
                        rdd.Description = recProc.Description;
                        rdd.Amount = recProc.Amount;
                        rdd.UnitPrice = recProc.UnitPrice;
                        rdd.PaymentPrice = 0;
                        //rdd.TotalDiscountPrice = recProc.TotalDiscountPrice;
                        //rdd.TotalDiscountedPrice = recProc.TotalDiscountedPrice;
                        rdd.CurrentStateDefID = ReceiptDocumentDetail.States.Paid;
                        rdd.IsParticipationShare = isParticipationShare;

                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);
                        accTrxDoc.AccountDocumentDetail = rdd;
                        accTrxDoc.AccountTransaction = recProc.AccountTransaction[0];
                        //accTrxDoc.AccountTransaction.TotalDiscountPrice = rdd.TotalDiscountPrice;

                        // Alınmış avans var ise önce avans için PatientPaymentDetail ler oluşturulur
                        Currency remainingPaymentOfRecProc = recProc.PaymentPrice.Value;
                        foreach (AdvanceDocument advanceDoc in ReceiptDocument.AdvanceDocuments)
                        {
                            Advance advance = advanceDoc.Advance[0];
                            if (advance.RemainingPrice > 0)
                            {
                                if (!rdd.PaymentPriceByAdvance.HasValue)
                                    rdd.PaymentPriceByAdvance = 0;

                                PatientPaymentDetail ppDetail = new PatientPaymentDetail(ObjectContext);
                                if (remainingPaymentOfRecProc <= advance.RemainingPrice)
                                {
                                    ppDetail.CreatePPDetail(recProc.AccountTransaction[0], advance.AdvanceDocument, remainingPaymentOfRecProc, PaymentTypeEnum.Advance, isParticipationShare);
                                    rdd.PaymentPrice += remainingPaymentOfRecProc;
                                    rdd.PaymentPriceByAdvance += remainingPaymentOfRecProc; // Avans ile ödenen tutar varsa ReceiptDocumentDetail üzerinde tutulur
                                    remainingPaymentOfRecProc = 0;
                                    break;
                                }
                                else
                                {
                                    rdd.PaymentPrice += advance.RemainingPrice;
                                    rdd.PaymentPriceByAdvance += advance.RemainingPrice; // Avans ile ödenen tutar varsa ReceiptDocumentDetail üzerinde tutulur
                                    remainingPaymentOfRecProc -= advance.RemainingPrice;
                                    ppDetail.CreatePPDetail(recProc.AccountTransaction[0], advance.AdvanceDocument, advance.RemainingPrice, PaymentTypeEnum.Advance, isParticipationShare);
                                }
                            }
                        }

                        // Makbuz için PatientPaymentDetail ler oluşturulur 
                        if (remainingPaymentOfRecProc > 0 && _totalPayment > 0)
                        {
                            PatientPaymentDetail ppDetail = new PatientPaymentDetail(ObjectContext);
                            if (remainingPaymentOfRecProc <= _totalPayment)
                            {
                                ppDetail.CreatePPDetail(recProc.AccountTransaction[0], ReceiptDocument, remainingPaymentOfRecProc, ReceiptDocument.PaymentType.Value, isParticipationShare);
                                rdd.PaymentPrice += remainingPaymentOfRecProc;
                                _totalPayment -= remainingPaymentOfRecProc;
                                remainingPaymentOfRecProc = 0;
                            }
                            else
                            {
                                rdd.PaymentPrice += _totalPayment;
                                remainingPaymentOfRecProc -= _totalPayment;
                                ppDetail.CreatePPDetail(recProc.AccountTransaction[0], ReceiptDocument, _totalPayment, ReceiptDocument.PaymentType.Value, isParticipationShare);
                                _totalPayment = 0;
                            }
                        }

                        if ((accTrxDoc.AccountTransaction.ExternalCode == "520030" || accTrxDoc.AccountTransaction.ExternalCode == "S520030") && accTrxDoc.AccountTransaction.SubActionProcedure is PatientExaminationProcedure && accTrxDoc.AccountTransaction.SubActionProcedure.EpisodeAction != null && accTrxDoc.AccountTransaction.SubActionProcedure.EpisodeAction.MasterResource != null && accTrxDoc.AccountTransaction.SubActionProcedure.EpisodeAction.MasterResource.Name != null)
                            rdd.Description = TTUtils.CultureService.GetText("M26585", "Normal pol. muayenesi (") + accTrxDoc.AccountTransaction.SubActionProcedure.EpisodeAction.MasterResource.Name + ")";

                        if (accTrxDoc.AccountTransaction.RemainingPrice == 0)
                            accTrxDoc.AccountTransaction.CurrentStateDefID = AccountTransaction.States.Paid;

                        /*
                        if (accTrxDoc.AccountTransaction.RemainingPrice == 0 && accTrxDoc.AccountTransaction.SubActionProcedure != null)
                        {
                            // Paketin içindeki AccTrx leri de Ödendi durumuna almak için (Paket Tanımı olan durumda)
                            if (accTrxDoc.AccountTransaction.SubActionProcedure.PackageDefinition != null)
                            {
                                foreach (AccountTransaction accTrx in accTrxDoc.AccountTransaction.SubEpisodeProtocol.GetTransactionsInsidePackage(accTrxDoc.AccountTransaction.SubActionProcedure.PackageDefinition, Episode.Patient.MyAPR()))
                                {
                                    if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
                                        accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                }
                            } // Paket hizmet ise : SUbEpisodeProtocol deki InvoiceInclusion ı false ve Yeni durumundaki hizmetler Paket içi olduğu düşünülüp Ödendi durumuna alınır
                            else if (accTrxDoc.AccountTransaction.SubActionProcedure.ProcedureObject is PackageProcedureDefinition)
                            {
                                foreach (AccountTransaction accTrx in accTrxDoc.AccountTransaction.SubEpisodeProtocol.GetNotInvoiceIncludedTransactions(Episode.Patient.MyAPR()))
                                {
                                    if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
                                        accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                }
                            }
                        }
                        */

                        rdg.ReceiptDocumentDetails.Add(rdd);
                        paidCounter += 1;
                    }
                    else
                    {
                        recProc.Paid = false;
                    }
                }
            }


            foreach (AdvanceDocument advanceDoc in ReceiptDocument.AdvanceDocuments)
            {
                advanceDoc.Used = true;
            }
            /*if (paidCounter == 0)
            {
                String message = SystemMessage.GetMessage(114);
                throw new TTUtils.TTException(message);
            }

            if (paidCounter > 10 && this.UnDetailedReport == false)
            {
                String message = SystemMessage.GetMessage(117);
                throw new TTUtils.TTException(message);
            }*/

            ReceiptDocument.TotalPrice = TotalPayment;

            //this.ReceiptDocument.GeneralTotalPrice = this.GeneralTotalPrice;
            //this.ReceiptDocument.TotalDiscountPrice = this.TotalDiscountPrice;

            ReceiptDocument.AddAPRTransaction((AccountPayableReceivable)Episode.Patient.MyAPR(), -1 * (ReceiptDocument.TotalPrice /*- (double)this.ReceiptDocument.TotalDiscountPrice)*/), (APRTrxType)APRTrxType.GetByType(ObjectContext, 8)[0]);  // Hasta Makbuz Tahakkuk
            ReceiptDocument.AddAPRTransaction((AccountPayableReceivable)Episode.Patient.MyAPR(), ReceiptDocument.TotalPrice, (APRTrxType)APRTrxType.GetByType(ObjectContext, 1)[0]);  // Hasta Makbuz Tahsili
            /*this.ReceiptDocument.AddAPRTransaction((AccountPayableReceivable)this.Episode.Patient.MyAPR(), (double)this.ReceiptDocument.GeneralTotalPrice, (APRTrxType)APRTrxType.GetByType(this.ObjectContext, 1)[0]);  // Hasta Makbuz Tahsili*/

            ReceiptDocument.CurrentStateDefID = ReceiptDocument.States.Paid;
            ReceiptDocument.SendToAccounting = false;
            ReceiptDocument.DocumentDate = Common.RecTime();

            switch (ReceiptDocument.PaymentType)
            {
                case PaymentTypeEnum.Cash:
                    {
                        Cash cash = new Cash(ObjectContext) { Price = TotalPayment, AccountDocument = ReceiptDocument };
                        cash["CURRENCYTYPE"] = this.CurrencyType;
                        selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                        ReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                        ReceiptCashOfficeDefinition.SetNextReceiptNumber(selectedRCODef);
                        ReceiptDocument.SpecialNo.GetNextValue(ReceiptDocument.ResUser.ID.ToString(), Common.RecTime().Year);
                    }
                    break;
                case PaymentTypeEnum.CreditCard:
                    {
                        CreditCard creditCard = new CreditCard(ObjectContext) { Price = TotalPayment, AccountDocument = ReceiptDocument };
                        selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                        ReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(selectedRCODef);
                        ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(selectedRCODef);
                        ReceiptDocument.SpecialNo.GetNextValue(ReceiptDocument.ResUser.ID.ToString(), Common.RecTime().Year);
                    }
                    break;
                default:
                    break;
            }

            CreateAccountVoucher();

            #endregion PostTransition_New2Paid
        }

        protected void UndoTransition_New2Paid(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Paid
            #region UndoTransition_New2Paid
            NoBackStateBack();
            #endregion UndoTransition_New2Paid
        }

        protected void PostTransition_Paid2Cancelled()
        {
            // From State : Paid   To State : Cancelled
            #region PostTransition_Paid2Cancelled
            Cancel();
            #endregion PostTransition_Paid2Cancelled
        }

        protected void UndoTransition_Paid2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Paid   To State : Cancelled
            #region UndoTransition_Paid2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Paid2Cancelled
        }

        #region Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }

        public override void Cancel()
        {
            base.Cancel();

            //CashierLog myCashierLog = this.ReceiptDocument.CashierLog;
            //if (myCashierLog == null)
            //{
            //    String message = SystemMessage.GetMessage(108);
            //    throw new TTUtils.TTException(message);
            //}

            //else
            //{
            //if (myCashierLog.ClosingDate != null)
            //{
            //    String message = SystemMessage.GetMessage(110);
            //    throw new TTUtils.TTException(message);
            //}
            //else
            //{
            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            if (ReceiptDocument.ResUser.ObjectID == currentResUser.ObjectID)
                ReceiptDocument.Cancel();
            else
                throw new TTException(TTUtils.CultureService.GetText("M26393", "Makbuzu yalnızca oluşturan kullanıcı iptal edebilir!"));

            CancelAccountVoucher();

            //if (myCashierLog.ResUser.ObjectID == currentResUser.ObjectID)
            //{
            //this.ReceiptDocument.Cancel();
            //}
            //else
            //{
            //throw new TTUtils.TTException(SystemMessage.GetMessage(113, new string[] { "Muhasebe Yetkilisi Mutemedi Alındısı" }));
            //}
            //}
            //}
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Receipt).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Receipt.States.New && toState == Receipt.States.Paid)
                PostTransition_New2Paid();
            else if (fromState == Receipt.States.Paid && toState == Receipt.States.Cancelled)
                PostTransition_Paid2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Receipt).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Receipt.States.New && toState == Receipt.States.Paid)
                UndoTransition_New2Paid(transDef);
            else if (fromState == Receipt.States.Paid && toState == Receipt.States.Cancelled)
                UndoTransition_Paid2Cancelled(transDef);
        }

        //protected override void OnBeforeImportFromObject(DataRow dataRow)
        //{
        //    base.OnBeforeImportFromObject(dataRow);

        //    dataRow["RECEIPTDOCUMENT"] = DBNull.Value;
        //}

        public void PrepareNewReceipt()
        {
            if (CurrentStateDefID == Receipt.States.New)
            {
                Currency totalRemainingPrice = 0;

                ResUser _myResUser = Common.CurrentResource;
                CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, _myResUser);

                if (selectedCashOffice == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25324", "Bu kullanıcı için tanımlı bir vezne yok ya da Hastadan Tahsilat yapmaya yetikiniz bulunmamaktadır!"));

                ReceiptCashOfficeDefinition selectedRCODef = new ReceiptCashOfficeDefinition();
                selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(ObjectContext, selectedCashOffice.ObjectID);

                CashOfficeName = selectedCashOffice.Name;//_myCashierLog.CashOffice.Name;

                if (ReceiptDocument == null)
                {
                    ReceiptDocument = new ReceiptDocument(ObjectContext);
                    ReceiptDocument.DocumentDate = Common.RecTime();

                    // ACCtrx leri doldurma Islemi

                    ReceiptDocument.PayeeName = Episode.Patient.FullName;
                    ReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                    ReceiptDocument.ResUser = _myResUser;
                    ReceiptDocument.CashOffice = selectedCashOffice;
                    ReceiptDocument.PaymentType = PaymentTypeEnum.Cash;

                    var accTrxList = Episode.GetTransactionsForReceiptV2();

                    //var query = from accTrx in result
                    //            where accTrx.Isbackppdetail == false && accTrx.Iscancelppdetail == false && accTrx.Totalprice - accTrx.
                    //            select 
                    //            ;

                    foreach (var accTrx in accTrxList)
                    {
                        decimal remainingPrice;                   

                        remainingPrice = Convert.ToDecimal(accTrx.Totalprice) - Convert.ToDecimal(accTrx.Paymentprice);

                        if (remainingPrice > 0)
                        {
                            ReceiptProcedure rp = new ReceiptProcedure(ObjectContext);
                            rp.ActionDate = accTrx.TransactionDate.Value;
                            rp.ExternalCode = accTrx.ExternalCode;

                            string Description = accTrx.Description;

                            if (!string.IsNullOrEmpty(accTrx.ExternalCode))
                            {
                                if (accTrx.ExternalCode == "520010" && string.IsNullOrEmpty(accTrx.Procedurespecialityname))
                                {
                                    if (accTrx.Description.IndexOf(accTrx.Procedurespecialityname) == -1)
                                        Description += " (" + accTrx.Procedurespecialityname + ")";
                                }
                            }

                            rp.Description = Description;

                            //if (accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode() != null)
                            //rp.RevenueType = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode().Description;

                            rp.Amount = (int)accTrx.Amount;
                            rp.UnitPrice = accTrx.UnitPrice;
                            rp.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
                            rp.PaymentPrice = remainingPrice;
                            rp.RemainingPrice = remainingPrice;
                            rp.Paid = true;
                            rp.AccountTransactionObjectID = accTrx.ObjectID.Value;

                            totalRemainingPrice += rp.RemainingPrice.Value;
                            ReceiptProcedures.Add(rp);
                        }
                    }

                    //foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt())
                    //{
                    //    if ((accTrx.SubActionProcedure != null || accTrx.SubActionMaterial != null) && accTrx.RemainingPrice > 0)
                    //    {
                    //        ReceiptProcedure rp = new ReceiptProcedure(ObjectContext);
                    //        rp.ActionDate = accTrx.TransactionDate.Value;
                    //        rp.ExternalCode = accTrx.ExternalCode;

                    //        if (accTrx.ExternalCode != null)
                    //        {
                    //            if (accTrx.ExternalCode == "520010" && accTrx.SubActionProcedure.ProcedureSpeciality != null)
                    //            {
                    //                if (accTrx.Description.IndexOf(accTrx.SubActionProcedure.ProcedureSpeciality.Name) == -1)
                    //                    accTrx.Description += " (" + accTrx.SubActionProcedure.ProcedureSpeciality.Name + ")";
                    //            }
                    //        }

                    //        rp.Description = accTrx.Description;

                    //        //if (accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode() != null)
                    //        //rp.RevenueType = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode().Description;

                    //        rp.Amount = (int)accTrx.Amount;
                    //        rp.UnitPrice = accTrx.UnitPrice;
                    //        rp.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
                    //        rp.PaymentPrice = accTrx.RemainingPrice;
                    //        rp.RemainingPrice = accTrx.RemainingPrice;
                    //        rp.Paid = true;
                    //        rp.AccountTransaction.Add(accTrx);

                    //        totalRemainingPrice += rp.RemainingPrice.Value;
                    //        ReceiptProcedures.Add(rp);
                    //    }

                    //    //if (accTrx.SubActionMaterial != null && accTrx.RemainingPrice > 0)
                    //    //{
                    //    //    ReceiptMaterial rm = new ReceiptMaterial(ObjectContext);
                    //    //    rm.ActionDate = (DateTime)accTrx.TransactionDate;
                    //    //    rm.Description = accTrx.Description;
                    //    //    rm.ExternalCode = accTrx.ExternalCode;
                    //    //    rm.Amount = accTrx.Amount;
                    //    //    rm.UnitPrice = accTrx.UnitPrice;
                    //    //    rm.TotalPrice = (double)(accTrx.Amount * accTrx.UnitPrice);
                    //    //    rm.RemainingPrice = accTrx.RemainingPrice;
                    //    //    rm.PaymentPrice = accTrx.RemainingPrice;
                    //    //    rm.Paid = true;
                    //    //    rm.AccountTransaction.Add(accTrx);
                    //    //    totalRemainingPrice += rm.RemainingPrice.Value;
                    //    //    ReceiptMaterials.Add(rm);
                    //    //}
                    //}

                    UnDetailedReport = false;
                    //TotalDiscountPrice = 0;
                    //GeneralTotalPrice = totalPrice;
                    //TotalDiscountEntry = 0;
                    ReceiptDocument.PatientName = Episode.Patient.Name + " " + Episode.Patient.Surname;
                    ReceiptDocument.PatientNo = Episode.Patient.ID.Value;
                    //ReceiptDocument.TotalDiscountPrice = 0;
                    //ReceiptDocument.GeneralTotalPrice = 0;
                    ReceiptDocument.CurrentStateDefID = ReceiptDocument.States.New;

                    double totalAdvanceTaken = 0;


                    foreach (Advance advance in Episode.Advances)
                    {
                        if (advance.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid && advance.AdvanceDocument.Used.Value == false)
                        {
                            totalAdvanceTaken += advance.TotalPrice.Value;
                            //advance.AdvanceDocument.Used = true;
                            ReceiptDocument.AdvanceDocuments.Add(advance.AdvanceDocument);
                        }
                    }

                    //IsChildHasUnpaidCharge();

                    AdvanceTaken = totalAdvanceTaken;
                    TotalPrice = totalRemainingPrice;
                    if (TotalPrice > Convert.ToDouble(AdvanceTaken))
                    {
                        TotalPrice -= AdvanceTaken.Value;
                        TotalPayment = TotalPrice;
                    }
                    else
                    {
                        totalRemainingPrice = 0;
                        TotalPayment = 0;
                        //throw new TTException("Hastadan alınan avans miktarı, ödenmemiş hizmet/malzeme toplamından fazladır. Makbuz kesme işlemini tamamlayamazsınız. Seçilmeyen hizmet/malzeme varsa seçiniz ya da daha az bir miktar giriniz!");
                    }
                    ReceiptDocument.TotalPrice = TotalPrice;
                }
            }
        }

        public void CreateAccountVoucher()
        {
            if (SystemParameter.GetParameterValue("CREATEACCOUNTVOUCHERFORCASHOFFICE", "TRUE") == "TRUE")
            {
                AccountPeriodDefinition accountPeriodDefinition = AccountPeriodDefinition.GetByDate(ObjectContext, ReceiptDocument.DocumentDate.Value);
                List<AccountVoucher> accountVoucherList = ObjectContext.QueryObjects<AccountVoucher>("ISAUTOGENERATED = 1 AND ISDEPT = 0 AND VOUCHERTYPE = 3 AND CURRENTSTATEDEFID = '" + AccountVoucher.States.Completed + "' AND ACCOUNTPERIOD = '" + accountPeriodDefinition.ObjectID + "'").ToList();

                const string other = "600.01.99";
                const string BKKPrimBorcuOlanlar = "600.01.94";
                const string PrvAlinanSGKKatılımPayı = "336.06.01";
                const string PrvAlinmayanSGKKatılımPayı = "336.06.02";
                const string IlacGelirleri = "600.01.08.01";
                const string SarfMalzemeGelirleri = "600.01.08.02";
                string code;

                foreach (ReceiptDocumentGroup recGroup in ReceiptDocument.ReceiptDocumentGroups)
                {
                    foreach (ReceiptDocumentDetail receiptDetail in recGroup.ReceiptDocumentDetails)
                    {
                        code = other;
                        AccountTransaction accTrx = receiptDetail.AccountTrxDocument[0].AccountTransaction;

                        PayerTypeEnum payerType = accTrx.SubEpisodeProtocol.Payer.Type.PayerType.Value;

                        if (accTrx.SubActionProcedure != null && accTrx.SubActionProcedure.ProcedureObject != null)
                        {   // SGK lı hastadan alınmış katılım payı ise
                            if ((payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual) && (receiptDetail.IsParticipationShare == true || accTrx.SubActionProcedure.ProcedureObject.ParticipationProcedure == true))
                            {
                                if (!string.IsNullOrEmpty(accTrx.SubEpisodeProtocol.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                                {
                                    if (accTrx.SubEpisodeProtocol?.MedulaIstisnaiHal?.Kodu == "9")  // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                        code = BKKPrimBorcuOlanlar;
                                    else
                                        code = PrvAlinanSGKKatılımPayı;
                                }
                                else
                                    code = PrvAlinmayanSGKKatılımPayı;
                            }
                            else
                            {
                                RevenueSubAccountCodeDefinition revenueCodeDef = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                                if (revenueCodeDef != null)
                                {
                                    code = revenueCodeDef.AccountCode;

                                    if (code.Equals("600.01.01") || code.Equals("600.01.02") || code.Equals("600.01.03") || code.Equals("600.01.04") || code.Equals("600.01.05"))
                                    {
                                        if (accTrx.SubEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu.Equals("A"))
                                            code += ".01";
                                        else
                                            code += ".02";
                                    }
                                    else if (code.Equals("600.01.06") || code.Equals("600.01.07"))
                                        code += ".01";
                                }
                            }
                        }
                        else if (accTrx.SubActionMaterial != null)
                        {
                            if ((payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual) && receiptDetail.IsParticipationShare == true)
                            {
                                if (!string.IsNullOrEmpty(accTrx.SubEpisodeProtocol.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                                {
                                    if (accTrx.SubEpisodeProtocol?.MedulaIstisnaiHal?.Kodu == "9")  // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                        code = BKKPrimBorcuOlanlar;
                                    else
                                        code = PrvAlinanSGKKatılımPayı;
                                }
                                else
                                    code = PrvAlinmayanSGKKatılımPayı;
                            }
                            else if (accTrx.SubActionMaterial.Material is DrugDefinition || accTrx.SubActionMaterial.Material is MagistralPreparationDefinition)
                                code = IlacGelirleri;
                            else
                                code = SarfMalzemeGelirleri;
                        }

                        // Kurum Sağlık Turizmi ise
                        if (accTrx.SubEpisodeProtocol.Payer.HealthTourism == true)
                        {
                            if (code.StartsWith("600.") && code != BKKPrimBorcuOlanlar)  // Sağlık Turizmi için hesap kodunun başı 601 olarak değiştirilir
                                code = "601." + code.Substring(4, code.Length - 4);
                        }

                        AccountVoucherCodeDefinition avCodeDef = AccountVoucherCodeDefinition.GetByCode(ObjectContext, code);

                        AccountVoucher accountVoucher = accountVoucherList.FirstOrDefault(x => x.AccountVoucherCodeDefinition.ObjectID == avCodeDef.ObjectID);
                        if (accountVoucher == null)
                        {
                            accountVoucher = AccountVoucher.CreateForCashOffice(ObjectContext, accountPeriodDefinition, avCodeDef);
                            accountVoucherList.Add(accountVoucher);
                        }

                        accountVoucher.AddDetail(receiptDetail.PaymentPrice, ReceiptDocument, receiptDetail);
                    }
                }
            }
        }

        public void CancelAccountVoucher()
        {
            foreach (AccountVoucherDetail avDetail in ReceiptDocument.AccountVoucherDetails)
                avDetail.Cancel();
        }
    }
}