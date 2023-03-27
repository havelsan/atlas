
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
    /// Avans Alma İşlemi
    /// </summary>
    public partial class Advance : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public partial class AdvanceDocumentCreditCardReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetAdvanceDebentures_Class : TTReportNqlObject
        {
        }

        public partial class AdvanceDocumentCashReportQuery_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            if (memberName != "SUBEPISODE")
                switch (memberName)
                {
                    case "ADVANCEDOCUMENT":
                        {
                            AdvanceDocument value = (AdvanceDocument)newValue;
                            #region ADVANCEDOCUMENT_SetParentScript
                            if (value != null)
                                value.EpisodeAccountAction = this;
                            #endregion ADVANCEDOCUMENT_SetParentScript
                        }
                        break;

                    default:
                        base.RunSetMemberValueScript(memberName, newValue);
                        break;

                }
        }

        public Currency RemainingPrice
        {
            get
            {
                return TotalPrice.Value - UsedPrice;
            }
        }

        public Currency UsedPrice
        {
            get
            {
                if (AdvanceDocument.PatientPaymentDetail.Where(x => x.AccountTransaction != null) != null && AdvanceDocument.PatientPaymentDetail.Where(x => x.AccountTransaction != null).Count() > 0)
                    return AdvanceDocument.PatientPaymentDetail.Where(x => x.IsCancel == false && x.IsBack == false && x.AccountTransaction != null).Sum(x => (decimal)x.PaymentPrice);
                else
                    return 0;
            }
        }


        protected void PostTransition_New2Paid()
        {
            // From State : New   To State : Paid
            #region PostTransition_New2Paid

            if (TotalPrice == 0)
                throw new TTException(SystemMessage.GetMessage(2829));
            AdvanceDocument.CheckPaymentType<Advance>();
            //AdvanceDocumentGroup adg = this.AdvanceDocument.AddDocumentGroup("A", "Avans Alımı");
            //AdvanceDocumentDetail advDetail = new AdvanceDocumentDetail(this.ObjectContext);

            //advDetail.Description = "Avans Bedeli";
            //advDetail.Amount = 1;
            //advDetail.UnitPrice = (double)this.AdvanceDocument.TotalPrice;
            //advDetail.CurrentStateDefID = AdvanceDocumentDetail.States.Paid;
            //adg.AdvanceDocumentDetails.Add(advDetail);

            AdvanceDocument.AddAPRTransaction((AccountPayableReceivable)Episode.Patient.MyAPR(), (double)AdvanceDocument.TotalPrice, (APRTrxType)APRTrxType.GetByType(ObjectContext, 2)[0]);
            AdvanceDocument.CurrentStateDefID = AdvanceDocument.States.Paid;
            AdvanceDocument.TotalPrice = TotalPrice;
            AdvanceDocument.Used = false;
            AdvanceDocument.SendToAccounting = false;

            ReceiptCashOfficeDefinition receiptCashOfficeDef = ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, AdvanceDocument.CashOffice.ObjectID.ToString()).OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();

            if (receiptCashOfficeDef == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25347", "Bu vezne için tanımlanmış aktif bir vezne alındı numarası bulunamadı."));

            PatientPaymentDetail ppDetail = new PatientPaymentDetail(ObjectContext);
            ppDetail.CreatePPDetail(null, AdvanceDocument, TotalPrice.Value, PaymentTypeEnum.Advance);

            switch (AdvanceDocument.PaymentType)
            {
                case PaymentTypeEnum.Cash:
                    {
                        Cash cash = new Cash(ObjectContext) { Price = TotalPrice, CurrencyType = CurrencyTypeDefinition.GetByQref(ObjectContext, "TL")[0], AccountDocument = AdvanceDocument };
                        AdvanceDocument.CashPayment.Add(cash);
                        receiptCashOfficeDef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(receiptCashOfficeDef);
                        AdvanceDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(receiptCashOfficeDef);
                        ReceiptCashOfficeDefinition.SetNextReceiptNumber(receiptCashOfficeDef);
                        AdvanceDocument.SpecialNo.GetNextValue(AdvanceDocument.ResUser.ID.ToString(), Common.RecTime().Year);
                    }
                    break;
                case PaymentTypeEnum.CreditCard:
                    {
                        CreditCard creditCard = new CreditCard(ObjectContext) { Price = TotalPrice, AccountDocument = AdvanceDocument };
                        AdvanceDocument.CreditCardPayments.Add(creditCard);
                        receiptCashOfficeDef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(receiptCashOfficeDef);
                        AdvanceDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(receiptCashOfficeDef);
                        ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(receiptCashOfficeDef);
                        AdvanceDocument.SpecialNo.GetNextValue(AdvanceDocument.ResUser.ID.ToString(), Common.RecTime().Year);
                    }
                    break;
                default:
                    break;
            }

            //Hasta faturalama yonetemı PRE Accountıng olan hasta gruplarından Avans alındıgı takdırde SEP lerde CheckPaid kontrolu yapılmamalı
            foreach (SubEpisodeProtocol sep in Episode.AllSubEpisodeProtocols())
            {
                if (sep.CurrentStateDefID == SubEpisodeProtocol.States.Open)
                {
                    if ((sep.Protocol.InPatientPaymentType == AccountOperationTimeEnum.PRE && Episode.PatientStatus == PatientStatusEnum.Inpatient)
                        || (sep.Protocol.OutPatientPaymentType == AccountOperationTimeEnum.PRE && Episode.PatientStatus == PatientStatusEnum.Outpatient))
                        sep.CheckPaid = false;
                }
            }

            CreateAccountVoucher();

            #endregion PostTransition_New2Paid
        }

        //Eskiden Relation zorululuğundan kurtulmak için yazıldı. auto.cs ile gerek kalmadı.
        //protected override void OnBeforeImportFromObject(DataRow dataRow)
        //{
        //    base.OnBeforeImportFromObject(dataRow);

        //    dataRow["ADVANCEDOCUMENT"] = DBNull.Value;
        //}

        public void PrepareNewAdvance()
        {
            if (CurrentStateDefID == Advance.States.New)
            {
                CashOfficeDefinition selectedCashOffice;

                ResUser resUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

                selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25321", "Bu kullanıcı için tanımlı bir vezne yok ya da Avans almaya yetikiniz bulunmamaktadır!!"));

                List<ReceiptCashOfficeDefinition> receiptCashOfficeDefList = ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, selectedCashOffice.ObjectID.ToString()).ToList();

                //Aktif vezne alındı numarası tanımlanmamış
                if (receiptCashOfficeDefList.Where(x => x.IsActive == true).Count() == 0)
                {
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27194", "Vezne için aktif vezne alındı numarası bulunmamaktadır!"));
                }
                else
                {
                    ReceiptCashOfficeDefinition selectedRCODef = new ReceiptCashOfficeDefinition();
                    selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(ObjectContext, selectedCashOffice.ObjectID); /*receiptCashOfficeDefList.OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();*/

                    //this.cmdOK.Visible = false;
                    CashOfficeName = selectedCashOffice.Name;

                    if (AdvanceDocument == null)
                    {
                        AdvanceDocument = new AdvanceDocument(ObjectContext);
                        AdvanceDocument.PatientName = Episode.Patient.Name + " " + Episode.Patient.Surname;
                        AdvanceDocument.PatientNo = Episode.Patient.ID.Value;
                        AdvanceDocument.DocumentDate = Common.RecTime();
                        AdvanceDocument.PayeeName = Episode.Patient.FullName;
                        AdvanceDocument.ResUser = resUser;
                        AdvanceDocument.CashOffice = selectedCashOffice;
                        AdvanceDocument.PaymentType = PaymentTypeEnum.Cash;
                        AdvanceDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                    }
                }
            }
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

        public void ChangeReceiptActive(ReceiptCashOfficeDefinition receiptCODef, bool active)
        {
            receiptCODef.IsActive = active;
        }
        public override void Cancel()
        {
            base.Cancel();

            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            //TODO :CurrentUser Ana Vezne ise kontrol etmeden iptal edilecek.
            //if (currentResUser) ANA VEZNE
            //{
            //}

            //CashierLog myCashierLog = this.AdvanceDocument.CashierLog;
            //if (myCashierLog == null)
            //throw new TTUtils.TTException(SystemMessage.GetMessage(108));
            //else
            //{
            //if (myCashierLog.ClosingDate != null)
            //throw new TTUtils.TTException(SystemMessage.GetMessage(110));
            //else
            //{
            if (AdvanceDocument.ResUser.ObjectID == currentResUser.ObjectID)
            {
                AdvanceDocument.Cancel();

                foreach (SubEpisodeProtocol sep in Episode.AllSubEpisodeProtocols())
                {
                    if (sep.CurrentStateDefID == SubEpisodeProtocol.States.Open)
                    {
                        if ((sep.Protocol.InPatientPaymentType == AccountOperationTimeEnum.PRE && Episode.PatientStatus == PatientStatusEnum.Inpatient)
                            || (sep.Protocol.OutPatientPaymentType == AccountOperationTimeEnum.PRE && Episode.PatientStatus == PatientStatusEnum.Outpatient))
                            sep.CheckPaid = true;
                    }
                }
            }
            else
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(113, new string[] { TTUtils.CultureService.GetText("M11248", "Avans") }));

            CancelAccountVoucher();
            //}
            //}
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Advance).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Advance.States.New && toState == Advance.States.Paid)
                PostTransition_New2Paid();
            else if (fromState == Advance.States.Paid && toState == Advance.States.Cancelled)
                PostTransition_Paid2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Advance).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Advance.States.New && toState == Advance.States.Paid)
                UndoTransition_New2Paid(transDef);
            else if (fromState == Advance.States.Paid && toState == Advance.States.Cancelled)
                UndoTransition_Paid2Cancelled(transDef);
        }

        public void CreateAccountVoucher()
        {
            if (SystemParameter.GetParameterValue("CREATEACCOUNTVOUCHERFORCASHOFFICE", "TRUE") == "TRUE")
            {
                const string code = "340.11.01"; // Avans için muhasebe kodu

                AccountPeriodDefinition accountPeriodDefinition = AccountPeriodDefinition.GetByDate(ObjectContext, AdvanceDocument.DocumentDate.Value);
                AccountVoucherCodeDefinition accountVoucherCodeDefinition = AccountVoucherCodeDefinition.GetByCode(ObjectContext, code);
                AccountVoucher accountVoucher = AccountVoucher.GetOrCreateForCashOffice(ObjectContext, accountPeriodDefinition, accountVoucherCodeDefinition);
                accountVoucher.AddDetail(TotalPrice, AdvanceDocument);
            }
        }

        public void CancelAccountVoucher()
        {
            foreach (AccountVoucherDetail avDetail in AdvanceDocument.AccountVoucherDetails)
                avDetail.Cancel();
        }
    }
}