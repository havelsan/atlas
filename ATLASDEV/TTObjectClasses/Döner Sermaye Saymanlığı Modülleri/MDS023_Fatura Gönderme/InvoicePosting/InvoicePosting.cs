
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
    /// Fatura Gönderme İşlemi
    /// </summary>
    public  partial class InvoicePosting : AccountAction, IWorkListBaseAction
    {
        public partial class InvoicePostingListReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class InvoicePostingPreReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class InvoicePostingPayerQuery_Class : TTReportNqlObject 
        {
        }

        public partial class InvoicePostingListQuery_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_InvoicePosted2Cancelled()
        {
            // From State : InvoicePosted   To State : Cancelled
#region PostTransition_InvoicePosted2Cancelled
            Cancel();
#endregion PostTransition_InvoicePosted2Cancelled
        }

        protected void UndoTransition_InvoicePosted2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : InvoicePosted   To State : Cancelled
#region UndoTransition_InvoicePosted2Cancelled
            NoBackStateBack();
#endregion UndoTransition_InvoicePosted2Cancelled
        }

        protected void PostTransition_New2InvoicePosted()
        {
            // From State : New   To State : InvoicePosted
#region PostTransition_New2InvoicePosted
            IList accTrxInsidePackageList = null;
            int counter = 0;
            
            foreach (InvoicePostDetail invPD in InvoicePostDetails)
            {
                //faturalarin, detayların ve acctrx lerin durumu Gönderildi yapiliyor.
                if (invPD.Send == true)
                {
                    foreach (PayerInvoiceDocumentGroup invGroup in invPD.PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                    {
                        foreach (PayerInvoiceDocumentDetail invDetail in invGroup.PayerInvoiceDocumentDetails)
                        {
                            //invDetail.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Send;
                            
                            AccountTransaction accTrx = invDetail.AccountTrxDocument[0].AccountTransaction;
                            accTrx.CurrentStateDefID = AccountTransaction.States.Send;
                            
                            // Paket ise paket içindeki AccTrx ler de Send durumuna alınır
                            /*
                            if (accTrx.SubActionProcedure != null)
                            {
                                if (accTrx.SubActionProcedure.PackageDefinition != null)
                                {
                                    accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
                                    foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
                                    {
                                        accTrxInPack.CurrentStateDefID = AccountTransaction.States.Send;
                                    }
                                }
                            }
                            */
                        }
                    }
                    //invPD.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.Send;
                    counter ++;
                }
            }

            if (counter == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(225));

#endregion PostTransition_New2InvoicePosted
        }

        protected void UndoTransition_New2InvoicePosted(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : InvoicePosted
#region UndoTransition_New2InvoicePosted
            NoBackStateBack();
#endregion UndoTransition_New2InvoicePosted
        }

#region Methods
        public override void Cancel()
        {
            IList accTrxInsidePackageList = null;
            
            base.Cancel();
            
            foreach (InvoicePostDetail invPD in InvoicePostDetails)
            {
                // Faturaların, detayların ve acctrx lerin durumu Faturalandı ya donduruluyor.
                if (invPD.Send == true)
                {
                    //if (invPD.PayerInvoiceDocument.CurrentStateDefID == PayerInvoiceDocument.States.Paid)
                    //    throw new TTUtils.TTException(SystemMessage.GetMessageV3(645, new string[] {invPD.PayerInvoiceDocument.DocumentNo}));
                    
                    foreach (PayerInvoiceDocumentGroup invGroup in invPD.PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                    {
                        foreach (PayerInvoiceDocumentDetail invDetail in invGroup.PayerInvoiceDocumentDetails)
                        {
                            //invDetail.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Invoiced;
                            
                            AccountTransaction accTrx = invDetail.AccountTrxDocument[0].AccountTransaction;
                            accTrx.CurrentStateDefID = AccountTransaction.States.Invoiced;
                            
                            // Paket ise paket içindeki AccTrx ler de Send durumuna alınır
                            /*
                            if (accTrx.SubActionProcedure != null)
                            {
                                if (accTrx.SubActionProcedure.PackageDefinition != null)
                                {
                                    accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
                                    foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
                                    {
                                        accTrxInPack.CurrentStateDefID = AccountTransaction.States.Invoiced;
                                    }
                                }
                            }
                            */
                        }
                    }
                    invPD.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.Invoiced;
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InvoicePosting).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InvoicePosting.States.InvoicePosted && toState == InvoicePosting.States.Cancelled)
                PostTransition_InvoicePosted2Cancelled();
            else if (fromState == InvoicePosting.States.New && toState == InvoicePosting.States.InvoicePosted)
                PostTransition_New2InvoicePosted();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InvoicePosting).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InvoicePosting.States.InvoicePosted && toState == InvoicePosting.States.Cancelled)
                UndoTransition_InvoicePosted2Cancelled(transDef);
            else if (fromState == InvoicePosting.States.New && toState == InvoicePosting.States.InvoicePosted)
                UndoTransition_New2InvoicePosted(transDef);
        }

    }
}