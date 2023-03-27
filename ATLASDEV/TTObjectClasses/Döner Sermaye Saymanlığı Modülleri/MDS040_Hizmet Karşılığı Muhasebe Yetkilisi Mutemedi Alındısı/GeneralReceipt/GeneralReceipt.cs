
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
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı
    /// </summary>
    public  partial class GeneralReceipt : AccountAction, IWorkListBaseAction
    {
        public partial class GeneralReceiptReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GeneralReceiptDetailsQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GeneralReceiptCreditCardReportQuery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "GENERALRECEIPTDOCUMENT":
                    {
                        GeneralReceiptDocument value = (GeneralReceiptDocument)newValue;
#region GENERALRECEIPTDOCUMENT_SetParentScript
                        value.AccountAction=this;
#endregion GENERALRECEIPTDOCUMENT_SetParentScript
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
            
            int counter = 0;
            double totalPrice = 0;
            
            if (GeneralReceiptDocument.CashPayment.Count == 0 && GeneralReceiptDocument.CreditCardPayments.Count == 0)
                throw new TTException(SystemMessage.GetMessage(114));
            
            if (GeneralReceiptDocument.GetTotalPayment() != TotalPrice)
                throw new TTException(SystemMessage.GetMessage(115));
            
            GeneralReceiptDocumentGroup rdg = (GeneralReceiptDocumentGroup)GeneralReceiptDocument.AddDocumentGroup("H",TTUtils.CultureService.GetText("M15953", "Hizmetler"));
            
            if (GeneralReceiptProcedures.Count > 0)
            {
                foreach (GeneralReceiptProcedure recProc in GeneralReceiptProcedures)
                {
                    if(recProc.ActionDate == null)
                        throw new TTException(SystemMessage.GetMessageV3(477, new string[] { " " }));
                    
                    if(recProc.Procedure == null)
                        throw new TTException(SystemMessage.GetMessage(476));

                    if(recProc.Amount == null || recProc.Amount == 0)
                        throw new TTException(SystemMessage.GetMessageV3(478, new string[] { " " }));

                    if(recProc.UnitPrice == null || recProc.UnitPrice == 0)
                        throw new TTException(SystemMessage.GetMessage(479));

                    if(recProc.TotalPrice == null || recProc.TotalPrice == 0)
                        throw new TTException(SystemMessage.GetMessage(480));
                    
                    GeneralReceiptDocumentDetail rdd = new GeneralReceiptDocumentDetail(ObjectContext);
                    rdd.ExternalCode = recProc.Procedure.Code;
                    rdd.Description = recProc.Procedure.Name;
                    rdd.Amount = recProc.Amount;
                    rdd.UnitPrice = recProc.UnitPrice;
                    rdd.TotalDiscountedPrice = recProc.TotalPrice;
                    rdd.CurrentStateDefID = GeneralReceiptDocumentDetail.States.Paid;
                    rdg.GeneralReceiptDocumentDetails.Add(rdd);
                    
                    recProc.GeneralReceiptDocumentDetail = rdd;
                    
                    totalPrice = totalPrice + (double)recProc.TotalPrice;
                    counter += 1;
                }
            }
            
            if (counter == 0)
                throw new TTException(SystemMessage.GetMessage(482));
            
            GeneralReceiptDocument.TotalPrice = TotalPrice;
            GeneralReceiptDocument.CurrentStateDefID = GeneralReceiptDocument.States.Paid;
            GeneralReceiptDocument.SendToAccounting = false;
            
            ReceiptCashOfficeDefinition myReceiptCashOffice = ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, GeneralReceiptDocument.CashierLog.CashOffice.ObjectID.ToString())[0];
            if (GeneralReceiptDocument.CashPayment.Count > 0)
            {
                GeneralReceiptDocument.DocumentNo = (string)ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(myReceiptCashOffice);
                ReceiptCashOfficeDefinition.SetNextReceiptNumber(myReceiptCashOffice);
                GeneralReceiptDocument.SpecialNo.GetNextValue(GeneralReceiptDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
            }
            
            if (GeneralReceiptDocument.CreditCardPayments.Count > 0)
            {
                GeneralReceiptDocument.CreditCardDocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(myReceiptCashOffice);
                ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(myReceiptCashOffice);
                GeneralReceiptDocument.CreditCardSpecialNo.GetNextValue(GeneralReceiptDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
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
            
            CashierLog myCashierLog = GeneralReceiptDocument.CashierLog;
            if (myCashierLog == null)
                throw new TTException(SystemMessage.GetMessage(108));
            else
            {
                if (myCashierLog.ClosingDate != null)
                    throw new TTException(SystemMessage.GetMessage(110));
                else
                {
                    ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

                    if (myCashierLog.ResUser.ObjectID == currentResUser.ObjectID)
                        GeneralReceiptDocument.Cancel();
                    else
                        throw new TTException(SystemMessage.GetMessageV3(113, new string[] { TTUtils.CultureService.GetText("M26546", "Muhasebe Yetkilisi Mutemedi Alındısı")}));
                }
            }
        }
        
        public void AddGeneralReceiptProcedure(ProcedureDefinition pProcedure, int pAmount, DateTime pActionDate)
        {
            GeneralReceiptProcedure recProc = new GeneralReceiptProcedure(ObjectContext);
            
            recProc.Procedure = pProcedure;
            recProc.Amount = pAmount;
            recProc.ActionDate = pActionDate;
            GeneralReceiptProcedures.Add(recProc);
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralReceipt).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralReceipt.States.New && toState == GeneralReceipt.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == GeneralReceipt.States.Completed && toState == GeneralReceipt.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralReceipt).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralReceipt.States.New && toState == GeneralReceipt.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == GeneralReceipt.States.Completed && toState == GeneralReceipt.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}