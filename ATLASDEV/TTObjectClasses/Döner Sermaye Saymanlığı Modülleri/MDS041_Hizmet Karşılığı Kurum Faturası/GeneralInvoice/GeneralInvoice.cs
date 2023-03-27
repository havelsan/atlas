
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
    /// Hizmet Karşılığı Kurum Faturası
    /// </summary>
    public partial class GeneralInvoice : AccountAction, IWorkListBaseAction
    {
        public partial class GeneralInvoiceReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GeneralInvoiceReportInfoQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetGeneralInvoiceByPayer_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "GENERALINVOICEDOCUMENT":
                    {
                        GeneralInvoiceDocument value = (GeneralInvoiceDocument)newValue;
                        #region GENERALINVOICEDOCUMENT_SetParentScript
                        value.AccountAction = this;
                        #endregion GENERALINVOICEDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_New2Invoiced()
        {
            // From State : New   To State : Invoiced
            #region PostTransition_New2Invoiced

            if (CommunityHealthRequest.Count > 0 && CommunityHealthPayer == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25766", "Halk Sağlığı Kurum Adı giriniz."));

            if (CommunityHealthRequest.Count == 0 && Payer == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26354", "Kurum Adı giriniz."));

            if (GeneralInvoiceProcedures.Count == 0)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27190", "Verilen hizmet bulunamadı!"));

            if (!TotalPrice.HasValue || TotalPrice == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            foreach (GeneralInvoiceProcedure invProc in GeneralInvoiceProcedures)
            {
                if (invProc.ActionDate == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(477, new string[] { " " }));

                if (invProc.Procedure == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(476));

                if (invProc.Amount == null || invProc.Amount == 0)
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(478, new string[] { " " }));

                if (invProc.UnitPrice == null || invProc.UnitPrice == 0)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(479));

                if (invProc.TotalPrice == null || invProc.TotalPrice == 0)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(480));
            }

            bool groupExists;
            string groupCode;
            string groupDescription;
            GeneralInvoiceDocumentGroup tempInvDocGroup = null;

            foreach (GeneralInvoiceProcedure invProc in GeneralInvoiceProcedures)
            {
                groupExists = false;
                groupCode = "-";
                groupDescription = "DİĞER";

                GeneralInvoiceDocumentDetail idd = new GeneralInvoiceDocumentDetail(ObjectContext);
                idd.ExternalCode = invProc.Procedure.Code;
                idd.Description = invProc.Procedure.Name;
                idd.Amount = invProc.Amount;
                idd.UnitPrice = invProc.UnitPrice;
                idd.TotalDiscountedPrice = invProc.TotalPrice;
                idd.CurrentStateDefID = GeneralInvoiceDocumentDetail.States.Send;
                invProc.GeneralInvoiceDocumentDetail = idd;

                if (invProc.Procedure.ProcedureTree != null)
                {
                    if (!string.IsNullOrEmpty(invProc.Procedure.ProcedureTree.ExternalCode))
                        groupCode = invProc.Procedure.ProcedureTree.ExternalCode;
                    if (!string.IsNullOrEmpty(invProc.Procedure.ProcedureTree.Description))
                        groupDescription = invProc.Procedure.ProcedureTree.Description;
                }

                foreach (GeneralInvoiceDocumentGroup invDocGrp in GeneralInvoiceDocument.GeneralInvoiceDocumentGroups)
                {
                    if (invDocGrp.GroupCode == groupCode && invDocGrp.GroupDescription == groupDescription)
                    {
                        groupExists = true;
                        tempInvDocGroup = invDocGrp;
                        break;
                    }
                }

                if (groupExists == false)
                {
                    GeneralInvoiceDocumentGroup idg = (GeneralInvoiceDocumentGroup)GeneralInvoiceDocument.AddDocumentGroup(groupCode, groupDescription);
                    idg.GeneralInvoiceDocumentDetails.Add(idd);
                }
                else
                    tempInvDocGroup.GeneralInvoiceDocumentDetails.Add(idd);
            }

            GeneralInvoiceDocument.TotalPrice = TotalPrice;
            GeneralInvoiceDocument.CurrentStateDefID = GeneralInvoiceDocument.States.Send;

            if (Payer != null)
                GeneralInvoiceDocument.AddAPRTransaction((AccountPayableReceivable)Payer.MyAPR(), (double)(-1 * TotalPrice), (APRTrxType)APRTrxType.GetByType(ObjectContext, 4)[0]);

            GeneralInvoiceDocument.SendToAccounting = false;

            InvoiceCashOfficeDefinition myInvoiceCashOffice = InvoiceCashOfficeDefinition.GetByCashOffice(ObjectContext, GeneralInvoiceDocument.CashierLog.CashOffice.ObjectID.ToString())[0];
            GeneralInvoiceDocument.DocumentNo = InvoiceCashOfficeDefinition.GetCurrentInvoiceNumber(myInvoiceCashOffice);
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

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled
            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void UndoTransition_New2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Cancelled
            #region UndoTransition_New2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_New2Cancelled
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
            if (GeneralInvoiceDocument != null && GeneralInvoiceDocument.CurrentStateDefID == GeneralInvoiceDocument.States.Paid)
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(218, new string[] { TTUtils.CultureService.GetText("M26990", "Tahsilat")}));
            else
            {
                base.Cancel();
                if (GeneralInvoiceDocument != null)
                    GeneralInvoiceDocument.Cancel();
            }
        }

        public void AddGeneralInvoiceProcedure(ProcedureDefinition pProcedure, int pAmount, DateTime pActionDate)
        {
            GeneralInvoiceProcedure invProc = new GeneralInvoiceProcedure(ObjectContext);

            invProc.Procedure = pProcedure;
            invProc.Amount = pAmount;
            invProc.ActionDate = pActionDate;
            GeneralInvoiceProcedures.Add(invProc);
        }

        public GeneralInvoice(TTObjectContext objectContext, CommunityHealthRequest communityHealthRequest) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            CurrentStateDefID = GeneralInvoice.States.New;
            CommunityHealthPayer = communityHealthRequest.CommunityHealthPayer;

            PricingListDefinition hospitalPricingList;
            IList pricingList = PricingListDefinition.GetByCode(ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALPRICINGLISTCODE", "0"));
            if (pricingList.Count == 0)
                throw new TTException(TTUtils.CultureService.GetText("M25815", "XXXXXX Cari Fiyat Listesi bulunamadı! Kontrol ediniz."));
            else
                hospitalPricingList = (PricingListDefinition)pricingList[0];
            double totalPrice = 0;

            foreach (var communityHealthProcedure in communityHealthRequest.Procedures)
            {
                var newGeneralInvoiceProcedure = new GeneralInvoiceProcedure(ObjectContext);
                newGeneralInvoiceProcedure.Procedure = communityHealthProcedure.ProcedureObject;
                newGeneralInvoiceProcedure.ActionDate = DateTime.Now;
                newGeneralInvoiceProcedure.Amount = communityHealthProcedure.Amount;

                // Hizmetin Cari Fiyat Listesindeki fiyatı bulunur ve UnitPrice olarak set edilir.
                ArrayList pricingDetailList = new ArrayList();
                pricingDetailList = newGeneralInvoiceProcedure.Procedure.GetProcedurePricingDetail(hospitalPricingList, newGeneralInvoiceProcedure.ActionDate);
                if (pricingDetailList.Count > 0)
                    newGeneralInvoiceProcedure.UnitPrice = ((PricingDetailDefinition)pricingDetailList[0]).Price;
                else
                    throw new TTException(newGeneralInvoiceProcedure.Procedure.Name + " isimli hizmetin Cari Fiyat Listesinde aktif fiyatı bulunamadı! Kontrol ediniz.");

                newGeneralInvoiceProcedure.TotalPrice = newGeneralInvoiceProcedure.UnitPrice * newGeneralInvoiceProcedure.Amount;
                GeneralInvoiceProcedures.Add(newGeneralInvoiceProcedure);
                totalPrice += (double)newGeneralInvoiceProcedure.TotalPrice;
            }

            TotalPrice = totalPrice;
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralInvoice.States.New && toState == GeneralInvoice.States.Invoiced)
                PostTransition_New2Invoiced();
            else if (fromState == GeneralInvoice.States.New && toState == GeneralInvoice.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == GeneralInvoice.States.Invoiced && toState == GeneralInvoice.States.Cancelled)
                PostTransition_Invoiced2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralInvoice).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralInvoice.States.New && toState == GeneralInvoice.States.Invoiced)
                UndoTransition_New2Invoiced(transDef);
            else if (fromState == GeneralInvoice.States.New && toState == GeneralInvoice.States.Cancelled)
                UndoTransition_New2Cancelled(transDef);
            else if (fromState == GeneralInvoice.States.Invoiced && toState == GeneralInvoice.States.Cancelled)
                UndoTransition_Invoiced2Cancelled(transDef);
        }

    }
}