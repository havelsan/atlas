
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
    /// Hasta Faturası İşlemi
    /// </summary>
    public partial class PatientInvoice : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public partial class PatientInvoiceReportInfoQuery_Class : TTReportNqlObject
        {
        }

        public partial class PatientInvoiceReportQuery_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PATIENTINVOICEDOCUMENT":
                    {
                        PatientInvoiceDocument value = (PatientInvoiceDocument)newValue;
                        #region PATIENTINVOICEDOCUMENT_SetParentScript
                        value.EpisodeAccountAction = this;
                        #endregion PATIENTINVOICEDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
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

        protected void PostTransition_New2Invoiced()
        {
            // From State : New   To State : Invoiced
            #region PostTransition_New2Invoiced
            bool groupExists = false;
            string groupCode = "";
            string groupDescription = "";
            bool invoicedExists = false;
            
            if (PatientInvoiceProcedures.Count == 0 && PatientInvoiceMaterials.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            if (PatientInvoiceProcedures.Count > 0)
            {
                PatientInvoiceDocumentGroup procTempGroup = null;

                foreach (PatientInvoiceProcedure invproc in PatientInvoiceProcedures)
                {
                    groupExists = false;
                    groupCode = "";
                    groupDescription = "";

                    if (invproc.Paid == true)
                    {
                        PatientInvoiceDocumentDetail invdd = new PatientInvoiceDocumentDetail(ObjectContext);
                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);

                        invdd.ExternalCode = invproc.ExternalCode;
                        invdd.Description = invproc.Description;
                        invdd.Amount = invproc.Amount;
                        invdd.UnitPrice = invproc.UnitPrice;
                        invdd.CurrentStateDefID = PatientInvoiceDocumentDetail.States.Invoiced;

                        accTrxDoc.AccountDocumentDetail = invdd;
                        accTrxDoc.AccountTransaction = invproc.AccountTransaction[0];
                        accTrxDoc.AccountTransaction.CurrentStateDefID = AccountTransaction.States.Invoiced;

                        // Paketin içindeki AccTrx leri de Faturalandı durumuna almak için
                        if (accTrxDoc.AccountTransaction.SubActionProcedure.PackageDefinition != null)
                        {
                            foreach (AccountTransaction accTrx in accTrxDoc.AccountTransaction.SubEpisodeProtocol.GetTransactionsInsidePackage(accTrxDoc.AccountTransaction.SubActionProcedure.PackageDefinition, Episode.Patient.MyAPR()))
                            {
                                if (accTrx.CurrentStateDefID == AccountTransaction.States.Paid)
                                    accTrx.CurrentStateDefID = AccountTransaction.States.Invoiced;
                            }
                        }

                        if (invproc.AccountTransaction[0].PricingDetail != null)
                        {
                            groupCode = invproc.AccountTransaction[0].PricingDetail.PricingListGroup.ExternalCode;
                            groupDescription = invproc.AccountTransaction[0].PricingDetail.PricingListGroup.Description;
                        }
                        else
                        {
                            groupCode = invproc.AccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree.ExternalCode;
                            groupDescription = invproc.AccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree.Description;
                        }

                        foreach (PatientInvoiceDocumentGroup pg in PatientInvoiceDocument.PatientInvoiceDocumentGroups)
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
                            PatientInvoiceDocumentGroup invdg = new PatientInvoiceDocumentGroup(ObjectContext);
                            invdg.GroupCode = groupCode;
                            invdg.GroupDescription = groupDescription;
                            invdg.PatientInvoiceDocumentDetails.Add(invdd);
                            invdg.AccountDocument = PatientInvoiceDocument; //murat
                        }
                        else
                            procTempGroup.PatientInvoiceDocumentDetails.Add(invdd);

                        invoicedExists = true;
                    }
                    else
                        invproc.AccountTransaction.Remove(invproc.AccountTransaction[0]);
                }
            }

            if (PatientInvoiceMaterials.Count > 0)
            {
                PatientInvoiceDocumentGroup matTempGroup = null;

                foreach (PatientInvoiceMaterial invmat in PatientInvoiceMaterials)
                {
                    groupExists = false;
                    groupCode = "";
                    groupDescription = "";

                    if (invmat.Paid == true)
                    {
                        PatientInvoiceDocumentDetail invdd = new PatientInvoiceDocumentDetail(ObjectContext);
                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);

                        invdd.ExternalCode = invmat.ExternalCode;
                        invdd.Description = invmat.Description;
                        invdd.Amount = invmat.Amount;
                        invdd.UnitPrice = invmat.UnitPrice;
                        invdd.CurrentStateDefID = PatientInvoiceDocumentDetail.States.Invoiced;

                        accTrxDoc.AccountDocumentDetail = invdd;
                        accTrxDoc.AccountTransaction = invmat.AccountTransaction[0];
                        accTrxDoc.AccountTransaction.CurrentStateDefID = AccountTransaction.States.Invoiced;

                        if (invmat.AccountTransaction[0].PricingDetail != null)
                        {
                            groupCode = invmat.AccountTransaction[0].PricingDetail.PricingListGroup.ExternalCode;
                            groupDescription = invmat.AccountTransaction[0].PricingDetail.PricingListGroup.Description;
                        }
                        else
                        {
                            //malzeme gruplarının kodu olmadığı için sadece grup adı dikkate alınıyor
                            groupDescription = invmat.AccountTransaction[0].SubActionMaterial.Material.MaterialTree.Name;
                        }

                        foreach (PatientInvoiceDocumentGroup pg in PatientInvoiceDocument.PatientInvoiceDocumentGroups)
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
                            PatientInvoiceDocumentGroup invdg = new PatientInvoiceDocumentGroup(ObjectContext);
                            invdg.GroupCode = groupCode;
                            invdg.GroupDescription = groupDescription;
                            invdg.PatientInvoiceDocumentDetails.Add(invdd);
                            invdg.AccountDocument = PatientInvoiceDocument; //murat
                        }
                        else
                            matTempGroup.PatientInvoiceDocumentDetails.Add(invdd);

                        invoicedExists = true;
                    }
                    else
                        invmat.AccountTransaction.Remove(invmat.AccountTransaction[0]);
                }
            }

            if (!invoicedExists)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            PatientInvoiceDocument.CurrentStateDefID = PatientInvoiceDocument.States.Invoiced;

            InvoiceCashOfficeDefinition myInvoiceCashOffice = InvoiceCashOfficeDefinition.GetByCashOffice(ObjectContext, PatientInvoiceDocument.CashOffice.ObjectID.ToString())[0];
            PatientInvoiceDocument.DocumentNo = (string)InvoiceCashOfficeDefinition.GetCurrentInvoiceNumber(myInvoiceCashOffice);
            InvoiceCashOfficeDefinition.SetNextInvoiceNumber(myInvoiceCashOffice);

            #endregion PostTransition_New2Invoiced
        }

        protected void UndoTransition_New2Invoiced(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Invoiced
            #region UndoTransition_New2Invoiced
            NoBackStateBack();
            #endregion UndoTransition_New2Invoiced
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
            PatientInvoiceDocument.Cancel();
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientInvoice.States.Invoiced && toState == PatientInvoice.States.Cancelled)
                PostTransition_Invoiced2Cancelled();
            else if (fromState == PatientInvoice.States.New && toState == PatientInvoice.States.Invoiced)
                PostTransition_New2Invoiced();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientInvoice.States.Invoiced && toState == PatientInvoice.States.Cancelled)
                UndoTransition_Invoiced2Cancelled(transDef);
            else if (fromState == PatientInvoice.States.New && toState == PatientInvoice.States.Invoiced)
                UndoTransition_New2Invoiced(transDef);
        }

    }
}