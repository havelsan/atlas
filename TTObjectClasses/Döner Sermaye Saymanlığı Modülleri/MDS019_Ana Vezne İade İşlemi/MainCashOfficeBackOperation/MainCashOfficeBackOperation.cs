
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
    /// Vezne İade İşlemi
    /// </summary>
    public  partial class MainCashOfficeBackOperation : AccountAction, IWorkListBaseAction
    {
        public partial class BankDeliveryReportQuery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MAINCASHOFFICEBACKDOCUMENT":
                    {
                        MainCashOfficeBackDocument value = (MainCashOfficeBackDocument)newValue;
#region MAINCASHOFFICEBACKDOCUMENT_SetParentScript
                        value.AccountAction=this;
#endregion MAINCASHOFFICEBACKDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            if (TotalPrice == null || TotalPrice == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(194));
            
            if (MainCashOfficeBackDocument.MoneyBackType.IsBankOperation == true)
            {
                if (MainCashOfficeBackDocument.DocumentNo == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(195));
                
                if (MainCashOfficeBackDocument.BankAccount == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(196));
                
//                ReceiptCashOfficeDefinition myReceiptCashOffice = (ReceiptCashOfficeDefinition)ReceiptCashOfficeDefinition.GetByCashOffice(this.ObjectContext, this.MainCashOfficeBackDocument.CashierLog.CashOffice.ObjectID.ToString())[0];
//                myReceiptCashOffice.SetNextBankDeliveryNumber();
                MainCashOfficeBackDocument.SpecialNo.GetNextValue(MainCashOfficeBackDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
            }
            
            MainCashOfficeBackDocumentGroup rdg = (MainCashOfficeBackDocumentGroup)MainCashOfficeBackDocument.AddDocumentGroup("I",TTUtils.CultureService.GetText("M27192", "Vezne İade"));
            rdg.AddDocumentDetail(Description, 1, (double)TotalPrice);
            rdg.AccountDocumentDetails[0].CurrentStateDefID = MainCashOfficeBackDocumentDetail.States.Paid;
            MainCashOfficeBackDocument.CurrentStateDefID = MainCashOfficeBackDocument.States.Paid;
            MainCashOfficeBackDocument.TotalPrice = TotalPrice;
            MainCashOfficeBackDocument.SendToAccounting = false;

            // Vezne İade işlemi hemen muhasebeleştiriliyor,
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if(MainCashOfficeBackDocument.MoneyBackType.IsBankOperation == true)
                {
                    IList<AccountDocument.BankDelivery> BankDeliveryList = new List<AccountDocument.BankDelivery>();
                    AccountDocument.BankDelivery BD;
                    BD = MainCashOfficeBackDocument.CreateBankDeliveryForAccounting();
                    
                    if (BD != null)
                    {
                        BankDeliveryList.Add(BD);
                        MainCashOfficeBackDocument.SendToAccounting = true;
                    }
                    
                    if (BankDeliveryList.Count > 0)
                    {
                        //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateBankDelivery", null, BankDeliveryList);
                    }
                }
                else
                {
                    IList<AccountDocument.ReceiptInfo> ReceiptList = new List<AccountDocument.ReceiptInfo>();
                    AccountDocument.ReceiptInfo RI;
                    RI = MainCashOfficeBackDocument.CreateReceiptInfoForAccounting();

                    if (RI != null)
                    {
                        ReceiptList.Add(RI);
                        MainCashOfficeBackDocument.SendToAccounting = true;
                    }
                    
                    if (ReceiptList.Count > 0)
                    {
                        //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                    }
                }
            }
#endregion PostTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            NoBackStateBack();
#endregion UndoTransition_New2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Completed2Cancelled
        }

#region Methods
        public override void Cancel()
        {
            base.Cancel();
            
            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            
            CashierLog myCashierLog = MainCashOfficeBackDocument.CashierLog;
            if (myCashierLog == null)
                throw new TTUtils.TTException(SystemMessage.GetMessage(191));
            else
            {
                if (myCashierLog.ClosingDate != null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(192));
                else
                {
                    if (myCashierLog.ResUser.ObjectID == currentResUser.ObjectID)
                        MainCashOfficeBackDocument.Cancel();
                    else
                        throw new TTUtils.TTException(SystemMessage.GetMessage(197));
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MainCashOfficeBackOperation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MainCashOfficeBackOperation.States.New && toState == MainCashOfficeBackOperation.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == MainCashOfficeBackOperation.States.Completed && toState == MainCashOfficeBackOperation.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MainCashOfficeBackOperation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MainCashOfficeBackOperation.States.New && toState == MainCashOfficeBackOperation.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == MainCashOfficeBackOperation.States.Completed && toState == MainCashOfficeBackOperation.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}