
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
    /// Manuel Kurum Faturası
    /// </summary>
    public  partial class ManualInvoice : AccountAction, IWorkListBaseAction
    {
        public partial class GetManualInvoiceByPayer_Class : TTReportNqlObject 
        {
        }

        public partial class GetProceduresByMedulaInvoice_Class : TTReportNqlObject 
        {
        }

        public partial class ManualInvoiceReportInfoQuery_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_New2Invoiced()
        {
            // From State : New   To State : Invoiced
#region PostTransition_New2Invoiced
            
            double totalPrice = 0;

            if (ManualInvoiceProcedures.Count > 0)
            {
                
                foreach (ManualInvoiceProcedure invProc in ManualInvoiceProcedures)
                {
                    
                    if(invProc.ActionDate == null)
                        throw new TTException(SystemMessage.GetMessageV3(477, new string[] { " " }));
                    
                    if(invProc.Procedure == null)
                        throw new TTException(SystemMessage.GetMessage(476));

                    if(invProc.Amount == null || invProc.Amount == 0)
                        throw new TTException(SystemMessage.GetMessageV3(478, new string[] { " " }));

                    if(invProc.UnitPrice == null || invProc.UnitPrice == 0)
                        throw new TTException(SystemMessage.GetMessage(479));

                    if(invProc.TotalPrice == null || invProc.TotalPrice == 0)
                        throw new TTException(SystemMessage.GetMessage(480));
                    
                    
                    totalPrice = totalPrice + (double)invProc.TotalPrice;
                }
            }
            
            if (totalPrice == 0)
                throw new TTException(SystemMessage.GetMessage(216));
            
            ManualInvoiceDocument.TotalPrice = TotalPrice;
            ManualInvoiceDocument.CurrentStateDefID = ManualInvoiceDocument.States.Send;
            ManualInvoiceDocument.AddAPRTransaction((AccountPayableReceivable)Payer.MyAPR(), (double)(-1 * TotalPrice), (APRTrxType)APRTrxType.GetByType(ObjectContext, 4)[0]);
            ManualInvoiceDocument.SendToAccounting = false;

#endregion PostTransition_New2Invoiced
        }

        protected void UndoTransition_New2Invoiced(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Invoiced
#region UndoTransition_New2Invoiced
            NoBackStateBack();
#endregion UndoTransition_New2Invoiced
        }

        protected void PostTransition_Invoiced2Cancelled()
        {
            // From State : Invoiced   To State : Cancelled
#region PostTransition_Invoiced2Cancelled
            Cancel();
#endregion PostTransition_Invoiced2Cancelled
        }

        protected void UndoTransition_Invoiced2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Invoiced   To State : Cancelled
#region UndoTransition_Invoiced2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Invoiced2Cancelled
        }

#region Methods
        public override void Cancel()
        {
            if (ManualInvoiceDocument.CurrentStateDefID == ManualInvoiceDocument.States.Paid)
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(218, new string[] {TTUtils.CultureService.GetText("M26990", "Tahsilat")}));
            else
            {
                base.Cancel();
                ManualInvoiceDocument.Cancel();
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ManualInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ManualInvoice.States.New && toState == ManualInvoice.States.Invoiced)
                PostTransition_New2Invoiced();
            else if (fromState == ManualInvoice.States.Invoiced && toState == ManualInvoice.States.Cancelled)
                PostTransition_Invoiced2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ManualInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ManualInvoice.States.New && toState == ManualInvoice.States.Invoiced)
                UndoTransition_New2Invoiced(transDef);
            else if (fromState == ManualInvoice.States.Invoiced && toState == ManualInvoice.States.Cancelled)
                UndoTransition_Invoiced2Cancelled(transDef);
        }

    }
}