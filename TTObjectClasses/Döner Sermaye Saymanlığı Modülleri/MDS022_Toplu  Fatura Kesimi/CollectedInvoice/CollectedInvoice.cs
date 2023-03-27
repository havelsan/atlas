
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
    /// Toplu Fatura İşlemi
    /// </summary>
    public  partial class CollectedInvoice : AccountAction, IWorkListBaseAction
    {
        public partial class CollectedInvoiceProcedureDetailReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CollectedInvoicePreReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CollectedInvoiceReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CITotalPriceByDate_Class : TTReportNqlObject 
        {
        }

        public partial class CICountByDate_Class : TTReportNqlObject 
        {
        }

        public partial class CollectedInvoiceListReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CIBranchCountByDate_Class : TTReportNqlObject 
        {
        }

        public partial class CIPatientListByDate_Class : TTReportNqlObject 
        {
        }

        public partial class CIEpisodeCountByDate_Class : TTReportNqlObject 
        {
        }

        public partial class CIReportQuery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "COLLECTEDINVOICEDOCUMENT":
                    {
                        CollectedInvoiceDocument value = (CollectedInvoiceDocument)newValue;
#region COLLECTEDINVOICEDOCUMENT_SetParentScript
                        value.AccountAction = this;
#endregion COLLECTEDINVOICEDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();

#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();

#endregion PostUpdate
        }

        protected void PostTransition_CollectedInvoiced2Cancelled()
        {
            // From State : CollectedInvoiced   To State : Cancelled
#region PostTransition_CollectedInvoiced2Cancelled
            Cancel();
#endregion PostTransition_CollectedInvoiced2Cancelled
        }

        protected void UndoTransition_CollectedInvoiced2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : CollectedInvoiced   To State : Cancelled
#region UndoTransition_CollectedInvoiced2Cancelled
            NoBackStateBack();
#endregion UndoTransition_CollectedInvoiced2Cancelled
        }

        protected void PostTransition_New2CollectedInvoiced()
        {
            // From State : New   To State : CollectedInvoiced
            #region PostTransition_New2CollectedInvoiced

            //            IList accTrxInsidePackageList = null;
            //            CollectedInvoiceDocument invDoc = null;
            //            CollectedInvoiceDocumentGroup invDocGroup = null;
            //            int counter = 0;
            //            //bool procedureOrMaterialExists = false;
            //            //bool packageExists = false;
            //            string invoiceType = "";
            //            IList accTrxList = null;
            //            EpisodeProtocol myEP = null;
            //
            //            ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            //            CashierLog _myCashierLog = null;
            //            if (_myResUser != null)
            //                _myCashierLog = (CashierLog)_myResUser.GetOpenCashCashierLog();
            //
            //            if (this.Payer == null)
            //                throw new TTUtils.TTException(SystemMessage.GetMessage(222));
            //
            //            invDocGroup = new CollectedInvoiceDocumentGroup(this.ObjectContext);
            //            invDocGroup.GroupCode = "T";
            //            invDocGroup.GroupDescription = "Hizmet Malzemeler";
            //
            //            CollectedInvoiceDocumentDetail invDocDet = new CollectedInvoiceDocumentDetail(this.ObjectContext);
            //            invDocDet.Amount = 1;
            //            invDocDet.UnitPrice = this.TotalPrice;
            //            invDocDet.CurrentStateDefID = CollectedInvoiceDocumentDetail.States.Send;
            //
            //            foreach (CollectedPatientList patientList in this.CollectedPatients)
            //            {
            //                if (patientList.Invoiced == true)
            //                {
            //                    // AccTrx leri bağlama işini listelemeden buraya aldık
            //                    if (patientList.PayerInvoice != null)
            //                    {
            //                        patientList.PayerInvoice.CurrentStateDefID = PayerInvoice.States.CollectedInvoiced;
            //                        /*
            //                        accTrxList = AccountTransaction.GetTransactionsByPayerInvoice(this.ObjectContext, patientList.PayerInvoice.ObjectID.ToString());
            //                        foreach (AccountTransaction accTrx in accTrxList)
            //                        {
            //                            patientList.AccountTransactions.Add(accTrx);
            //                            accTrx.CurrentStateDefID = AccountTransaction.States.Send;
            //                            
            //                            // Paket ise paket içindeki AccTrx ler de Send durumuna alınır
            //                            if (accTrx.SubActionProcedure != null)
            //                            {
            //                                if (accTrx.SubActionProcedure.PackageDefinition != null)
            //                                {
            //                                    accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
            //                                    foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
            //                                    {
            //                                        accTrxInPack.CurrentStateDefID = AccountTransaction.States.Send;
            //                                    }
            //                                    packageExists = true;
            //                                }
            //                                else
            //                                    procedureOrMaterialExists = true;
            //                            }
            //                            else if (accTrx.SubActionMaterial != null)
            //                                procedureOrMaterialExists = true;
            //                        }
            //                         */
            //                    }
            //                    else
            //                    {
            //                        foreach (AccountTransaction accTrx in patientList.AccountTransactions)
            //                        {
            //                            //AccountTrxDocument accTrxDoc = new AccountTrxDocument(this.ObjectContext);
            //                            //accTrxDoc.AccountDocumentDetail = invDocDet;
            //                            //accTrxDoc.AccountTransaction = accTrx;
            //                            accTrx.CurrentStateDefID = AccountTransaction.States.Send;
            //
            //                            // Paket ise paket içindeki AccTrx ler de Send durumuna alınır
            //                            if (accTrx.SubActionProcedure != null)
            //                            {
            //                                if (accTrx.SubActionProcedure.PackageDefinition != null)
            //                                {
            //                                    accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
            //                                    foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
            //                                    {
            //                                        accTrxInPack.CurrentStateDefID = AccountTransaction.States.Send;
            //                                    }
            //                                    //packageExists = true;
            //                                }
            //                                //else
            //                                //    procedureOrMaterialExists = true;
            //                            }
            //                            
            //                            //else if (accTrx.SubActionMaterial != null)
            //                            //    procedureOrMaterialExists = true;
            //
            //                            //if (patientList.PayerInvoice == null)
            //
            //                            //accTrx.EpisodeProtocol.CurrentStateDefID = EpisodeProtocol.States.CLOSED;
            //
            //                            myEP = accTrx.EpisodeProtocol;
            //                        }
            //
            //                        //Anlaşmada Yeni durumunda AccountTransaction kalmamışsa kapatılacak
            //                        //if (myEP.GetTransactionsForInvoice(AccountTransaction.States.New, myEP.Payer.MyAPR()).Count == 0)
            //                        //    myEP.CurrentStateDefID = EpisodeProtocol.States.CLOSED;
            //                    }
            //                    counter++;
            //                }
            //            }
            //
            //            if (counter == 0)
            //                throw new TTUtils.TTException(SystemMessage.GetMessage(223));
            //
            //            /*
            //            if (packageExists)
            //            {
            //                if (procedureOrMaterialExists)
            //                    this.CollectedInvoiceDocument.InvoiceType = InvoicePostingInvoiceTypeEnum.ProcedureAndPackage;
            //                else
            //                    this.CollectedInvoiceDocument.InvoiceType = InvoicePostingInvoiceTypeEnum.Package;
            //            }
            //            else
            //            {
            //                if (procedureOrMaterialExists)
            //                    this.CollectedInvoiceDocument.InvoiceType = InvoicePostingInvoiceTypeEnum.Procedure;
            //            }
            //             */
            //
            //            //if (this.CollectedInvoiceDocument.InvoiceType != null)
            //            //    invoiceType = Common.GetEnumValueDefOfEnumValue(this.CollectedInvoiceDocument.InvoiceType).DisplayText;
            //
            //            if (this.PROCEDUREGROUP != null)
            //                invoiceType = Common.GetEnumValueDefOfEnumValue(this.PROCEDUREGROUP).DisplayText;
            //
            //            invDocDet.Description = Convert.ToDateTime(this.STARTDATE).Date.ToShortDateString() + "  " + Convert.ToDateTime(this.ENDDATE).Date.ToShortDateString() + " Tarihleri Arasındaki " + counter.ToString() + " Adet Hastanın " + invoiceType + " Faturasıdır";
            //
            //            invDocGroup.CollectedInvoiceDocumentDetails.Add(invDocDet);
            //            this.CollectedInvoiceDocument.CollectedInvoiceDocumentGroups.Add(invDocGroup);
            //            this.CollectedInvoiceDocument.CurrentStateDefID = CollectedInvoiceDocument.States.Send;
            //            this.CollectedInvoiceDocument.Payer = this.Payer;
            //            this.CollectedInvoiceDocument.TotalPrice = this.TotalPrice;
            //            this.Payer.ControlAndCreateAPR();
            //            this.CollectedInvoiceDocument.AddAPRTransaction((AccountPayableReceivable)this.Payer.MyAPR(), (double)(-1 * this.TotalPrice), (APRTrxType)APRTrxType.GetByType(this.ObjectContext, 4)[0]);
            //            this.CollectedInvoiceDocument.SendToAccounting = false;
            //
            //            if (this.CollectedInvoiceDocument.DocumentNo != null)
            //                this.WorkListDescription = "Fatura No: " + this.CollectedInvoiceDocument.DocumentNo;


            #endregion PostTransition_New2CollectedInvoiced
        }

        protected void UndoTransition_New2CollectedInvoiced(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : CollectedInvoiced
#region UndoTransition_New2CollectedInvoiced
            NoBackStateBack();
#endregion UndoTransition_New2CollectedInvoiced
        }

#region Methods
        public void Cancel()
        {
            //İptal işlemini sadece ilgili işlemi gerçekleştiren kullanıcı yapabilir.            
//            CashierLog myCashierLog = this.CollectedInvoiceDocument.CashierLog;
//            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
//            if (myCashierLog.ResUser.ObjectID != currentResUser.ObjectID)
//                throw new TTUtils.TTException(SystemMessage.GetMessage(113, new string[] { "Toplu Faturalandı" }));
//
//            IList accTrxInsidePackageList = null;
//
//            if (this.CollectedInvoiceDocument.CurrentStateDefID == CollectedInvoiceDocument.States.Paid)
//                throw new TTUtils.TTException(SystemMessage.GetMessage(224));
//            else
//            {
//                base.Cancel();
//
//                // CollectedInvoiceDocument, CollectedInvoiceDocumentDetail iptal edilir AprTrx eklenir
//                this.CollectedInvoiceDocument.Cancel();
//
//                // AccTrx
//                foreach (CollectedPatientList patientList in this.CollectedPatients)
//                {
//                    if (patientList.Invoiced == true)
//                    {
//                        if (patientList.PayerInvoice != null)
//                            patientList.PayerInvoice.CurrentStateDefID = PayerInvoice.States.ReadyToCollectedInvoice;
//
//                        foreach (AccountTransaction accTrx in patientList.AccountTransactions)
//                        {
//                            if (patientList.PayerInvoice == null)
//                            {
//                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
//                                // AccTrx lerden EpisodeProtocol lere ulaşılarak durumları OPEN a set ediliyor
//                                if (accTrx.EpisodeProtocol.CurrentStateDefID != EpisodeProtocol.States.OPEN)
//                                    accTrx.EpisodeProtocol.CurrentStateDefID = EpisodeProtocol.States.OPEN;
//                            }
//                            /*
//                            else
//                            {
//                                //accTrx.CurrentStateDefID = AccountTransaction.States.Ready;
//                                
//                                // AccTrx lerden EpisodeProtocol lere ulaşılarak durumları READY a set ediliyor
//                                //if (accTrx.EpisodeProtocol.CurrentStateDefID != EpisodeProtocol.States.READY)
//                                //    accTrx.EpisodeProtocol.CurrentStateDefID = EpisodeProtocol.States.READY;
//                            }
//                             */
//
//                            // Paket ise paket içindeki AccTrx ler de New durumuna alınır
//                            if (accTrx.SubActionProcedure != null)
//                            {
//                                if (accTrx.SubActionProcedure.PackageDefinition != null)
//                                {
//                                    accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
//                                    foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
//                                    {
//                                        if (patientList.PayerInvoice == null)
//                                            accTrxInPack.CurrentStateDefID = AccountTransaction.States.New;
//                                        //else
//                                        //    accTrxInPack.CurrentStateDefID = AccountTransaction.States.Ready;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CollectedInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CollectedInvoice.States.CollectedInvoiced && toState == CollectedInvoice.States.Cancelled)
                PostTransition_CollectedInvoiced2Cancelled();
            else if (fromState == CollectedInvoice.States.New && toState == CollectedInvoice.States.CollectedInvoiced)
                PostTransition_New2CollectedInvoiced();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CollectedInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CollectedInvoice.States.CollectedInvoiced && toState == CollectedInvoice.States.Cancelled)
                UndoTransition_CollectedInvoiced2Cancelled(transDef);
            else if (fromState == CollectedInvoice.States.New && toState == CollectedInvoice.States.CollectedInvoiced)
                UndoTransition_New2CollectedInvoiced(transDef);
        }

    }
}