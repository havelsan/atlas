
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
    /// Kurum Faturası İşlemi
    /// </summary>
    public partial class PayerInvoice : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public partial class CollectedInvoiceProcDetPreviewReportQuery1_Class : TTReportNqlObject
        {
        }

        public partial class CollectedInvoiceProcDetPreviewReportQuery3_Class : TTReportNqlObject
        {
        }

        public partial class GetDetailsByPatientID_Class : TTReportNqlObject
        {
        }

        public partial class PayerInvoiceReportInfoQuery_Class : TTReportNqlObject
        {
        }

        public partial class PayerInvoiceReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class CollectedInvoiceProcDetPreviewReportQuery2_Class : TTReportNqlObject
        {
        }

        public partial class CollectedInvoiceProcDetPreviewReportQuery4_Class : TTReportNqlObject
        {
        }

        public partial class GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class : TTReportNqlObject
        {
        }

        public partial class PatientSummaryByDepartmentReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetReadyPayerInvoiceForCollectedInvoice_SE_Class : TTReportNqlObject
        {
        }

        public partial class GetReadyPayerInvoiceForCollectedInvoice_Class : TTReportNqlObject
        {
        }

        public partial class PIReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetReadyToCollectedInvoicePatientListReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetInvoicedProcsForItemizedRevenue_Class : TTReportNqlObject
        {
        }

        public partial class GetInvoicedMatsForItemizedRevenue_Class : TTReportNqlObject
        {
        }

        public partial class GetPayerInvoiceByPayer_Class : TTReportNqlObject
        {
        }

        public partial class GetReadyAndColInvByEpisodeAndPISubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetReadyAndColInvByEpisode_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PAYERINVOICEDOCUMENT":
                    {
                        PayerInvoiceDocument value = (PayerInvoiceDocument)newValue;
                        #region PAYERINVOICEDOCUMENT_SetParentScript
                        value.EpisodeAccountAction = this;
                        #endregion PAYERINVOICEDOCUMENT_SetParentScript
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

        protected void PostTransition_New2Invoiced()
        {
            // From State : New   To State : Invoiced
            #region PostTransition_New2Invoiced


            double totalPrice = 0;
            bool groupExists = false;
            bool invoicedExists = false;
            string groupCode = string.Empty;
            string groupDescription = string.Empty;
            EpisodeProtocol myEpisodeProtocol = null;

            // INC013553 nolu Windesk iş isteği üzerine eklenmiştir
            if (IsTenDaysPastFromEpisodeOpeningDate() == false)
                throw new TTUtils.TTException("Ayaktan hastaya fatura kesilebilmesi için vaka açılış tarihinden itibaren 10 gün geçmesi gerekmektedir.");

            if (GeneralTotalPrice == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            /*   //
            foreach (EpisodeProtocol ep in this.Episode.EpisodeProtocols)
            {
                if (ep.Payer == this.Payer && ep.Protocol == this.Protocol && ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
                {
                    myEpisodeProtocol = ep;
                    break;
                }
            }
            */

            if (myEpisodeProtocol == null)
                throw new TTUtils.TTException(SystemMessage.GetMessage(217));
            else
                EpisodeProtocols.Add(myEpisodeProtocol);

            if (PayerInvoiceProcedures.Count > 0)
            {
                PayerInvoiceDocumentGroup procTempGroup = null;

                foreach (PayerInvoiceProcedure invproc in PayerInvoiceProcedures)
                {
                    groupExists = false;
                    groupCode = string.Empty;
                    groupDescription = string.Empty;

                    if (invproc.Paid == true)
                    {
                        PayerInvoiceDocumentDetail invdd = new PayerInvoiceDocumentDetail(ObjectContext);
                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);

                        invdd.ExternalCode = invproc.ExternalCode;
                        invdd.Description = invproc.Description;
                        invdd.Amount = invproc.Amount;
                        invdd.UnitPrice = invproc.UnitPrice;
                        invdd.TotalDiscountPrice = invproc.TotalDiscountPrice;
                        invdd.TotalDiscountedPrice = invproc.TotalDiscountedPrice;
                        //invdd.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Invoiced;

                        accTrxDoc.AccountDocumentDetail = invdd;
                        accTrxDoc.AccountTransaction = invproc.AccountTransaction[0];
                        accTrxDoc.AccountTransaction.TotalDiscountPrice = invproc.TotalDiscountPrice;
                        accTrxDoc.AccountTransaction.CurrentStateDefID = AccountTransaction.States.Invoiced;

                        if (invproc.AccountTransaction[0].PricingDetail != null && invproc.AccountTransaction[0].PricingDetail.PricingListGroup != null)
                        {
                            groupCode = invproc.AccountTransaction[0].PricingDetail.PricingListGroup.ExternalCode;
                            groupDescription = invproc.AccountTransaction[0].PricingDetail.PricingListGroup.Description;
                        }
                        else if (invproc.AccountTransaction[0].SubActionProcedure != null && invproc.AccountTransaction[0].SubActionProcedure.ProcedureObject != null && invproc.AccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree != null)
                        {
                            groupCode = invproc.AccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree.ExternalCode;
                            groupDescription = invproc.AccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree.Description;
                        }

                        if (string.IsNullOrEmpty(groupCode))
                            groupCode = "-";
                        if (string.IsNullOrEmpty(groupDescription))
                            groupDescription = "DİĞER";

                        foreach (PayerInvoiceDocumentGroup pg in PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                        {
                            if (pg.GroupCode == groupCode && pg.GroupDescription == groupDescription)
                            {
                                groupExists = true;
                                procTempGroup = pg;
                                break;
                            }
                        }

                        if (groupExists == false)
                        {
                            PayerInvoiceDocumentGroup invdg = new PayerInvoiceDocumentGroup(ObjectContext);
                            invdg.GroupCode = groupCode;
                            invdg.GroupDescription = groupDescription;
                            invdg.PayerInvoiceDocumentDetails.Add(invdd);
                            invdg.AccountDocument = PayerInvoiceDocument; //murat
                        }
                        else
                            procTempGroup.PayerInvoiceDocumentDetails.Add(invdd);

                        totalPrice = totalPrice + (double)invproc.TotalPrice;
                        invoicedExists = true;
                    }
                    else
                        invproc.AccountTransaction.Remove(invproc.AccountTransaction[0]);
                }
            }

            if (PayerInvoiceMaterials.Count > 0)
            {
                PayerInvoiceDocumentGroup matTempGroup = null;

                foreach (PayerInvoiceMaterial invmat in PayerInvoiceMaterials)
                {
                    groupExists = false;
                    groupCode = string.Empty;
                    groupDescription = string.Empty;

                    if (invmat.Paid == true)
                    {
                        PayerInvoiceDocumentDetail invdd = new PayerInvoiceDocumentDetail(ObjectContext);
                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);

                        invdd.ExternalCode = invmat.ExternalCode;
                        invdd.Description = invmat.Description;
                        invdd.Amount = invmat.Amount;
                        invdd.UnitPrice = invmat.UnitPrice;
                        invdd.TotalDiscountPrice = invmat.TotalDiscountPrice;
                        invdd.TotalDiscountedPrice = invmat.TotalDiscountedPrice;
                        //invdd.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Invoiced;

                        accTrxDoc.AccountDocumentDetail = invdd;
                        accTrxDoc.AccountTransaction = invmat.AccountTransaction[0];
                        accTrxDoc.AccountTransaction.TotalDiscountPrice = invmat.TotalDiscountPrice;
                        accTrxDoc.AccountTransaction.CurrentStateDefID = AccountTransaction.States.Invoiced;

                        if (invmat.AccountTransaction[0].PricingDetail != null && invmat.AccountTransaction[0].PricingDetail.PricingListGroup != null)
                        {
                            groupCode = invmat.AccountTransaction[0].PricingDetail.PricingListGroup.ExternalCode;
                            groupDescription = invmat.AccountTransaction[0].PricingDetail.PricingListGroup.Description;
                        }
                        else if (invmat.AccountTransaction[0].SubActionMaterial != null && invmat.AccountTransaction[0].SubActionMaterial.Material != null && invmat.AccountTransaction[0].SubActionMaterial.Material.MaterialTree != null)
                        {
                            groupCode = "-";
                            groupDescription = invmat.AccountTransaction[0].SubActionMaterial.Material.MaterialTree.Name;
                        }

                        if (string.IsNullOrEmpty(groupCode))
                            groupCode = "-";
                        if (string.IsNullOrEmpty(groupDescription))
                            groupDescription = "DİĞER";

                        foreach (PayerInvoiceDocumentGroup pg in PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                        {
                            if (pg.GroupCode == groupCode && pg.GroupDescription == groupDescription)
                            {
                                groupExists = true;
                                matTempGroup = pg;
                                break;
                            }
                        }

                        if (groupExists == false)
                        {
                            PayerInvoiceDocumentGroup invdg = new PayerInvoiceDocumentGroup(ObjectContext);
                            invdg.GroupCode = groupCode;
                            invdg.GroupDescription = groupDescription;
                            invdg.PayerInvoiceDocumentDetails.Add(invdd);
                            invdg.AccountDocument = PayerInvoiceDocument; //murat
                        }
                        else
                            matTempGroup.PayerInvoiceDocumentDetails.Add(invdd);

                        totalPrice = totalPrice + (double)invmat.TotalPrice;
                        invoicedExists = true;
                    }
                    else
                        invmat.AccountTransaction.Remove(invmat.AccountTransaction[0]);
                }
            }

            if (PayerInvoicePackages.Count > 0)
            {
                PayerInvoiceDocumentGroup packTempGroup = null;

                foreach (PayerInvoicePackage invpack in PayerInvoicePackages)
                {
                    groupExists = false;
                    groupCode = string.Empty;
                    groupDescription = string.Empty;

                    if (invpack.Paid == true)
                    {
                        PayerInvoiceDocumentDetail invdd = new PayerInvoiceDocumentDetail(ObjectContext);
                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);

                        invdd.ExternalCode = invpack.PackageCode;
                        invdd.Description = invpack.PackageName;
                        invdd.Amount = invpack.Amount;
                        invdd.UnitPrice = invpack.PackagePrice;
                        invdd.TotalDiscountPrice = invpack.TotalDiscountPrice;
                        invdd.TotalDiscountedPrice = invpack.TotalDiscountedPrice;
                        //invdd.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Invoiced;

                        accTrxDoc.AccountDocumentDetail = invdd;
                        accTrxDoc.AccountTransaction = invpack.PackageAccountTransaction[0];
                        accTrxDoc.AccountTransaction.TotalDiscountPrice = invpack.TotalDiscountPrice;
                        accTrxDoc.AccountTransaction.CurrentStateDefID = AccountTransaction.States.Invoiced;

                        //paket hızmet kapsamındakı detayların da durumlarını update et
                        foreach (AccountTransaction accTrx in invpack.GetIncludedAccountTransactions(EpisodeProtocols[0]))
                        {
                            if (accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew) // Tahakkuk durumunda ise önce Yeni durumuna alınır
                            {
                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
                                accTrx.Update();
                            }
                            accTrx.CurrentStateDefID = AccountTransaction.States.Invoiced;
                        }

                        if (invpack.PackageAccountTransaction[0].PricingDetail != null && invpack.PackageAccountTransaction[0].PricingDetail.PricingListGroup != null)
                        {
                            groupCode = invpack.PackageAccountTransaction[0].PricingDetail.PricingListGroup.ExternalCode;
                            groupDescription = invpack.PackageAccountTransaction[0].PricingDetail.PricingListGroup.Description;
                        }
                        else if (invpack.PackageAccountTransaction[0].SubActionProcedure != null && invpack.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject != null && invpack.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree != null)
                        {
                            groupCode = invpack.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree.ExternalCode;
                            groupDescription = invpack.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree.Description;
                        }

                        if (string.IsNullOrEmpty(groupCode))
                            groupCode = "-";
                        if (string.IsNullOrEmpty(groupDescription))
                            groupDescription = "DİĞER";

                        foreach (PayerInvoiceDocumentGroup pg in PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                        {
                            if (pg.GroupCode == groupCode && pg.GroupDescription == groupDescription)
                            {
                                groupExists = true;
                                packTempGroup = pg;
                                break;
                            }
                        }

                        if (groupExists == false)
                        {
                            PayerInvoiceDocumentGroup invdg = new PayerInvoiceDocumentGroup(ObjectContext);
                            invdg.GroupCode = groupCode;
                            invdg.GroupDescription = groupDescription;
                            invdg.PayerInvoiceDocumentDetails.Add(invdd);
                            invdg.AccountDocument = PayerInvoiceDocument; //murat
                        }
                        else
                            packTempGroup.PayerInvoiceDocumentDetails.Add(invdd);

                        totalPrice = totalPrice + (double)invpack.TotalPrice;
                        invoicedExists = true;
                    }
                    else
                        invpack.PackageAccountTransaction.Remove(invpack.PackageAccountTransaction[0]);
                }
            }

            if (!invoicedExists)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            // Fatura Göndermede kullanılacak Fatura Tipi filtresi set edilir
            if (PayerInvoicePackages.Count > 0)
            {
                if (PayerInvoiceProcedures.Count > 0 || PayerInvoiceMaterials.Count > 0)
                    PayerInvoiceDocument.InvoicePostingInvoiceType = InvoicePostingInvoiceTypeEnum.ProcedureAndPackage;
                else
                    PayerInvoiceDocument.InvoicePostingInvoiceType = InvoicePostingInvoiceTypeEnum.Package;
            }
            else
                PayerInvoiceDocument.InvoicePostingInvoiceType = InvoicePostingInvoiceTypeEnum.Procedure;

            PayerInvoiceDocument.TotalPrice = totalPrice;
            PayerInvoiceDocument.GeneralTotalPrice = GeneralTotalPrice;
            PayerInvoiceDocument.TotalDiscountPrice = TotalDiscountPrice;
            PayerInvoiceDocument.AddAPRTransaction((AccountPayableReceivable)Payer.MyAPR(), (double)(-1 * GeneralTotalPrice), (APRTrxType)APRTrxType.GetByType(ObjectContext, 4)[0]);
            PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.Invoiced;
            PayerInvoiceDocument.SendToAccounting = false;

            InvoiceCashOfficeDefinition myInvoiceCashOffice = InvoiceCashOfficeDefinition.GetByCashOffice(ObjectContext, PayerInvoiceDocument.CashierLog.CashOffice.ObjectID.ToString())[0];
            PayerInvoiceDocument.DocumentNo = InvoiceCashOfficeDefinition.GetCurrentInvoiceNumber(myInvoiceCashOffice);
            InvoiceCashOfficeDefinition.SetNextInvoiceNumber(myInvoiceCashOffice);

            //Anlaşmada Yeni durumunda AccountTransaction kalmamışsa kapatılacak
            //TODO:SEP
            //if(myEpisodeProtocol.GetTransactionsForInvoice(AccountTransaction.States.New, myEpisodeProtocol.Payer.MyAPR()).Count == 0)
            //    myEpisodeProtocol.CurrentStateDefID = EpisodeProtocol.States.CLOSED;

            if (Episode.PatientStatus == PatientStatusEnum.Outpatient)
                PayerInvoiceDocument.PatientStatus = OutPatientInPatientBothEnum.OutPatient;
            else
                PayerInvoiceDocument.PatientStatus = OutPatientInPatientBothEnum.InPatient;

            #endregion PostTransition_New2Invoiced
        }

        protected void UndoTransition_New2Invoiced(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Invoiced
            #region UndoTransition_New2Invoiced
            NoBackStateBack();
            #endregion UndoTransition_New2Invoiced
        }

        protected void PostTransition_New2ReadyToCollectedInvoice()
        {
            // From State : New   To State : ReadyToCollectedInvoice
            #region PostTransition_New2ReadyToCollectedInvoice

            bool invoicedExists = false;

            // INC013553 nolu Windesk iş isteği üzerine eklenmiştir
            if (IsTenDaysPastFromEpisodeOpeningDate() == false)
                throw new TTUtils.TTException("Ayaktan hastayı toplu faturaya hazıra getirebilmek için vaka açılış tarihinden itibaren 10 gün geçmesi gerekmektedir.");

            if (GeneralTotalPrice == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            // Hasta Durumu Kontrolü
            if (SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "FALSE" && PATIENTSTATUS == null)
                throw new TTUtils.TTException(SystemMessage.GetMessage(628));

            // Alt Vaka Kontrolü
            if (SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE" && PISubEpisode == null && PROCEDUREGROUP != CollectedInvoiceProcedureGroupEnum.Tooth)
                throw new TTUtils.TTException(SystemMessage.GetMessage(629));

            // Aynı altvakanın sadece 1 kez Toplu Faturalanabilmesi için kontrol
            if (SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE" && PISubEpisode != null)
            {
                IList PIList = PayerInvoice.GetReadyAndCollectedInvoicedByPISubEpisode(ObjectContext, PISubEpisode.ObjectID.ToString());
                foreach (PayerInvoice payerInv in PIList)
                {
                    if (payerInv.ObjectID != ObjectID)
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(630, payerInv.ID.ToString()));
                }
            }

            EpisodeProtocol myEP = null;
            IList epList = null; // EpisodeProtocol.GetByEpisodePayerProtocolAndStatus(this.ObjectContext, this.Episode.ObjectID.ToString(), this.Payer.ObjectID.ToString(), this.Protocol.ObjectID.ToString(), EpisodeProtocol.States.OPEN.ToString());
            if (epList.Count > 0)
            {
                myEP = (EpisodeProtocol)epList[0];
                //myEP.CurrentStateDefID = EpisodeProtocol.States.READY;
                myEP.InvoiceGroup = PROCEDUREGROUP;
                EpisodeProtocols.Add(myEP);
                PayerInvoiceDocument.DocumentNo = null;

                foreach (PayerInvoiceProcedure invproc in PayerInvoiceProcedures)
                {
                    if (invproc.Paid == true)
                    {
                        //invproc.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.Ready;
                        invproc.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.Send;
                        invoicedExists = true;
                    }
                }

                foreach (PayerInvoiceMaterial invmat in PayerInvoiceMaterials)
                {
                    if (invmat.Paid == true)
                    {
                        //invmat.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.Ready;
                        invmat.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.Send;
                        invoicedExists = true;
                    }
                }

                foreach (PayerInvoicePackage invpack in PayerInvoicePackages)
                {
                    if (invpack.Paid == true)
                    {
                        //invpack.PackageAccountTransaction[0].CurrentStateDefID = AccountTransaction.States.Ready;
                        invpack.PackageAccountTransaction[0].CurrentStateDefID = AccountTransaction.States.Send;
                        invoicedExists = true;

                        // Paket içindeki AccountTransaction ların durumunu Send yapar
                        /* TODO:SEP
                        foreach(AccountTransaction accTrx in invpack.GetIncludedAccountTransactions(invpack.PackageAccountTransaction[0].EpisodeProtocol))
                        {
                            if(accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew) // Tahakkuk durumunda ise önce Yeni durumuna alınır
                            {
                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
                                accTrx.Update();
                            }
                            accTrx.CurrentStateDefID = AccountTransaction.States.Send;
                        }
                        */
                    }
                }

                //Anlaşmada Yeni durumunda AccountTransaction kalmamışsa kapatılacak
                //TODO:SEP
                //if(myEP.GetTransactionsForInvoice(AccountTransaction.States.New, myEP.Payer.MyAPR()).Count == 0)
                //    myEP.CurrentStateDefID = EpisodeProtocol.States.CLOSED;
            }
            else
                throw new TTUtils.TTException(SystemMessage.GetMessage(217));

            if (!invoicedExists)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            //Epsisode da tamamlanmamış Fizik Tedavi, Ortez-Protez veya KanÜrünü İstek işlemi varsa state geçişi engellenecek
            foreach (SubActionProcedure sp in Episode.SubActionProcedures)
            {
                if (sp is OrthesisProsthesisProcedure)
                {
                    if (((OrthesisProsthesisRequest)sp.EpisodeAction).CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(812));
                }
                else if (sp is PhysiotherapyOrderDetail)
                    if (sp.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(813));

                if (sp is BloodBankBloodProducts)
                {
                    if (sp.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26179", "İşlem ilerletilemez!  \n")+ sp.EpisodeAction.ID
                                                      + " islem numaralı 'Kan Ürünü İstek' işleminde tamamlanmamış kan ürünü mevcuttur.");
                }
            }

            #endregion PostTransition_New2ReadyToCollectedInvoice
        }

        protected void UndoTransition_New2ReadyToCollectedInvoice(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : ReadyToCollectedInvoice
            #region UndoTransition_New2ReadyToCollectedInvoice
            NoBackStateBack();
            #endregion UndoTransition_New2ReadyToCollectedInvoice
        }

        protected void UndoTransition_CollectedInvoiced2ReadyToCollectedInvoice(TTObjectStateTransitionDef transitionDef)
        {
            // From State : CollectedInvoiced   To State : ReadyToCollectedInvoice
            #region UndoTransition_CollectedInvoiced2ReadyToCollectedInvoice
            NoBackStateBack();
            #endregion UndoTransition_CollectedInvoiced2ReadyToCollectedInvoice
        }

        protected void UndoTransition_ReadyToCollectedInvoice2CollectedInvoiced(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ReadyToCollectedInvoice   To State : CollectedInvoiced
            #region UndoTransition_ReadyToCollectedInvoice2CollectedInvoiced
            NoBackStateBack();
            #endregion UndoTransition_ReadyToCollectedInvoice2CollectedInvoiced
        }

        protected void PostTransition_ReadyToCollectedInvoice2Cancelled()
        {
            // From State : ReadyToCollectedInvoice   To State : Cancelled
            #region PostTransition_ReadyToCollectedInvoice2Cancelled
            CancelReadyToCollectedInvoiced();
            #endregion PostTransition_ReadyToCollectedInvoice2Cancelled
        }

        protected void UndoTransition_ReadyToCollectedInvoice2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ReadyToCollectedInvoice   To State : Cancelled
            #region UndoTransition_ReadyToCollectedInvoice2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_ReadyToCollectedInvoice2Cancelled
        }

        protected void PostTransition_Invoiced2Cancelled()
        {
            // From State : Invoiced   To State : Cancelled
            #region PostTransition_Invoiced2Cancelled
            CancelInvoiced();
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
        /*
        public override void Cancel()
        {
            //Toplu Fatura Hazır asamasında ıptalde farklı kod calısacak
            if (this.CurrentStateDefID == PayerInvoice.States.ReadyToCollectedInvoice )
            {
                EpisodeProtocol myEP = GetMyEpisodeProtocol();
                if (myEP != null)
                {
                    myEP = (EpisodeProtocol) epList[0];
                    myEP.CurrentStateDefID = EpisodeProtocol.States.OPEN;
                    myEP.InvoiceGroup = null;
                }
                else
                    throw new TTUtils.TTException(SystemMessage.GetMessage(217));
            }

            //Faturalandı asamasında calısacak kod
            if (this.CurrentStateDefID == PayerInvoice.States.Invoiced)
            {
                base.Cancel();
                
                if (this.PayerInvoiceDocument.CurrentStateDefID == PayerInvoiceDocument.States.Send)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(218, new string[] {"Gönderme"}));
                else if (this.PayerInvoiceDocument.CurrentStateDefID == PayerInvoiceDocument.States.Paid)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(218, new string[] {"Tahsilat"}));
                else
                    this.PayerInvoiceDocument.Cancel();
            }
        }
         */

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }

        public bool IsTenDaysPastFromEpisodeOpeningDate()
        {
            if (Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                int limit = 10;
                DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * (limit)).Date;
                if (Episode.OpeningDate.Value.Date >= dateLimit)
                    return false;
            }
            return true;
        }

        public override bool NotUpdateEpisodeAction
        {
            get { return true; }
            set
            {
            }
        }

        public EpisodeProtocol GetMyEpisodeProtocol()
        {
            EpisodeProtocol myEP = null;
            IList epList = null; // EpisodeProtocol.GetByEpisodeAndPayerAndProtocol(this.ObjectContext, this.Episode.ObjectID.ToString(), this.Payer.ObjectID.ToString(), this.Protocol.ObjectID.ToString());

            if (epList.Count > 0)
                myEP = (EpisodeProtocol)epList[0];

            return myEP;
        }

        public void CancelInvoiced()
        {
            base.Cancel();

            //if (this.PayerInvoiceDocument.CurrentStateDefID == PayerInvoiceDocument.States.Paid)
            //    throw new TTUtils.TTException(SystemMessage.GetMessageV3(218, new string[] { "Tahsilat" }));
            //else
            //{
            //    EpisodeProtocol ep = GetMyEpisodeProtocol();
            //    if (ep != null)
            //    {
            //        //if (this.PayerInvoiceDocument.CurrentStateDefID == PayerInvoiceDocument.States.Send)
            //        //    this.PayerInvoiceDocument.CancelSend(ep); // Gönderildi durumundakileri iptal eder
            //        //else
            //        //    this.PayerInvoiceDocument.Cancel(ep);     // Faturalandı durumundakileri iptal eder

            //        ep.CurrentStateDefID = EpisodeProtocol.States.OPEN;
            //        ep.PayerInvoice = null;
            //    }
            //    else
            //        throw new TTUtils.TTException(SystemMessage.GetMessage(217));
            //}
        }

        public void CancelReadyToCollectedInvoiced()
        {
            EpisodeProtocol ep = GetMyEpisodeProtocol();

            CashierLog myCashierLog = PayerInvoiceDocument.CashierLog;
            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            if (myCashierLog.ResUser.ObjectID != currentResUser.ObjectID)
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(113, new string[] { TTUtils.CultureService.GetText("M27112", "Toplu Faturaya Hazır")}));

            if (ep != null)
            {
                //ep = this.EpisodeProtocols[0];
                ep.CurrentStateDefID = EpisodeProtocol.States.OPEN;
                ep.InvoiceGroup = null;
                ep.PayerInvoice = null;

                foreach (PayerInvoiceProcedure invproc in PayerInvoiceProcedures)
                {
                    if (invproc.Paid == true)
                    {
                        if (invproc.AccountTransaction.Count > 0)
                        {
                            //if(invproc.AccountTransaction[0].SubActionProcedure != null && invproc.AccountTransaction[0].SubActionProcedure is OrthesisProsthesisProcedure)
                            //{
                            //    if(this.Episode.IsMedulaEpisode()) // SGK'lı hasta ise Ortez-Protez işlemi Medulaya Gönderilmeyecek durumuna alınır
                            //        invproc.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                            //    else
                            //        invproc.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.New;
                            //}
                            //else
                            invproc.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.New;
                        }
                    }
                }

                foreach (PayerInvoiceMaterial invmat in PayerInvoiceMaterials)
                {
                    if (invmat.Paid == true)
                    {
                        if (invmat.AccountTransaction.Count > 0)
                            invmat.AccountTransaction[0].CurrentStateDefID = AccountTransaction.States.New;
                    }
                }

                foreach (PayerInvoicePackage invpack in PayerInvoicePackages)
                {
                    if (invpack.Paid == true)
                    {
                        if (invpack.PackageAccountTransaction.Count > 0)
                        {
                            /* //TODO:SEP
                             invpack.PackageAccountTransaction[0].CurrentStateDefID = AccountTransaction.States.New;

                             // Paket içindeki AccountTransaction ların durumunu New e döndürür
                             EpisodeProtocol packageEP = invpack.PackageAccountTransaction[0].EpisodeProtocol;
                             IList accTrxList = packageEP.GetTransactionsForInvoice(AccountTransaction.States.Send, packageEP.Payer.MyAPR());

                             foreach (AccountTransaction accTrx in accTrxList)
                             {
                                 if (accTrx.PackageDefinition != null)
                                 {
                                     if (accTrx.PackageDefinition == invpack.PackageAccountTransaction[0].SubActionProcedure.PackageDefinition)
                                         accTrx.CurrentStateDefID = AccountTransaction.States.New;
                                 }
                             }
                             */
                        }
                    }
                }
            }
            else
                throw new TTUtils.TTException(SystemMessage.GetMessage(217));
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PayerInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PayerInvoice.States.New && toState == PayerInvoice.States.Invoiced)
                PostTransition_New2Invoiced();
            else if (fromState == PayerInvoice.States.New && toState == PayerInvoice.States.ReadyToCollectedInvoice)
                PostTransition_New2ReadyToCollectedInvoice();
            else if (fromState == PayerInvoice.States.ReadyToCollectedInvoice && toState == PayerInvoice.States.Cancelled)
                PostTransition_ReadyToCollectedInvoice2Cancelled();
            else if (fromState == PayerInvoice.States.Invoiced && toState == PayerInvoice.States.Cancelled)
                PostTransition_Invoiced2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PayerInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PayerInvoice.States.New && toState == PayerInvoice.States.Invoiced)
                UndoTransition_New2Invoiced(transDef);
            else if (fromState == PayerInvoice.States.New && toState == PayerInvoice.States.ReadyToCollectedInvoice)
                UndoTransition_New2ReadyToCollectedInvoice(transDef);
            else if (fromState == PayerInvoice.States.CollectedInvoiced && toState == PayerInvoice.States.ReadyToCollectedInvoice)
                UndoTransition_CollectedInvoiced2ReadyToCollectedInvoice(transDef);
            else if (fromState == PayerInvoice.States.ReadyToCollectedInvoice && toState == PayerInvoice.States.CollectedInvoiced)
                UndoTransition_ReadyToCollectedInvoice2CollectedInvoiced(transDef);
            else if (fromState == PayerInvoice.States.ReadyToCollectedInvoice && toState == PayerInvoice.States.Cancelled)
                UndoTransition_ReadyToCollectedInvoice2Cancelled(transDef);
            else if (fromState == PayerInvoice.States.Invoiced && toState == PayerInvoice.States.Cancelled)
                UndoTransition_Invoiced2Cancelled(transDef);
        }

    }
}