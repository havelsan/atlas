
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
    /// Veznenin bankaya yatırdığı hasılat
    /// </summary>
    public partial class BankPaymentDecount : AccountAction
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "BANKPAYMENTDECOUNTDOCUMENT":
                    {
                        BankPaymentDecountDocument value = (BankPaymentDecountDocument)newValue;
                        #region BANKPAYMENTDECOUNTDOCUMENT_SetParentScript
                        if (value != null)
                            value.AccountAction = this;
                        #endregion BANKPAYMENTDECOUNTDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        //Eskiden Relation zorululuğundan kurtulmak için yazıldı. auto.cs ile gerek kalmadı.
        //protected override void OnBeforeImportFromObject(DataRow dataRow)
        //{
        //    base.OnBeforeImport();
        //    dataRow["BANKPAYMENTDECOUNTDOCUMENT"] = DBNull.Value;
        //}

        public void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BankPaymentDecount).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == BankPaymentDecount.States.New && toState == BankPaymentDecount.States.Completed)
                PostTransition_New2Completed();
            if (fromState == BankPaymentDecount.States.Completed && toState == BankPaymentDecount.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void PostTransition_New2Completed()
        {
            if (TotalPrice == null || TotalPrice == 0)
                throw new TTException(TTUtils.CultureService.GetText("M26646", "Ödeme bilgisi girilmedi!"));

            if (BankPaymentDecountDocument.BankDecount.BankAccount == null)
                throw new TTUtils.TTException(SystemMessage.GetMessage(189));

            if (string.IsNullOrEmpty(BankPaymentDecountDocument.BankDecount.DecountNo))
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25234", "Bankadan Para Transferi için Dekont Numarası boş olamaz."));

            if (!BankPaymentDecountDocument.BankDecount.DecountDate.HasValue)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25235", "Bankadan Para Transferi için Dekont Tarihi boş olamaz."));

            BankPaymentDecountDocument.CurrentStateDefID = BankPaymentDecountDocument.States.Completed;
            BankPaymentDecountDocument.TotalPrice = TotalPrice;
            BankPaymentDecountDocument.BankDecount.Price = TotalPrice;

            //BankDecount bankDecount = new BankDecount(ObjectContext) { Price = TotalPrice, AccountDocument = BankPaymentDecountDocument, BankAccount = BankPaymentDecountDocument.BankDecount.BankAccount, DecountNo = BankPaymentDecountDocument.BankDecount.DecountNo };
            //BankPaymentDecountDocument.BankDecountPayments.Add(bankDecount);
        }

        protected void PostTransition_Completed2Cancelled()
        {
            BankPaymentDecountDocument.CurrentStateDefID = BankPaymentDecountDocument.States.Cancelled;
            BankPaymentDecountDocument.CancelDate = Common.RecTime();
        }

        public void PrepareBankPaymentDecount()
        {
            if (CurrentStateDefID == BankPaymentDecount.States.New)
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25323", "Bu kullanıcı için tanımlı bir vezne yok ya da Diğer Tahsilatları yapmaya yetikiniz bulunmamaktadır!"));

                BankPaymentDecountDocument = new BankPaymentDecountDocument(ObjectContext);
                BankPaymentDecountDocument.CashOffice = selectedCashOffice;
                BankPaymentDecountDocument.ResUser = resUser;
                BankPaymentDecountDocument.CurrentStateDefID = BankPaymentDecountDocument.States.New;
                BankPaymentDecountDocument.DocumentDate = Common.RecTime();
                BankPaymentDecountDocument.PaymentType = PaymentTypeEnum.Bank;

                BankPaymentDecountDocument.BankDecount = new BankDecount(ObjectContext);
                BankPaymentDecountDocument.BankDecount.AccountDocument = BankPaymentDecountDocument;
            }
        }
    }
}