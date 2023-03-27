
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
    /// 22F Doğrudan Temin İşlemi
    /// </summary>
    public  partial class DirectPurchaseAction : BasePurchaseAction, I22FDirectPurchaseWorkList
    {
        public partial class MaterielInspectionAndReceivingFirmInfoNQL_Class : TTReportNqlObject 
        {
        }

        public partial class DirectPurchaseApprovalFormInfotNQL_Class : TTReportNqlObject 
        {
        }

        public partial class DirectPurchaseApprovalCoordinatorInfoNQL_Class : TTReportNqlObject 
        {
        }

        public partial class DirectPurchaseApprovalFormReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class MaterialRequestFormReportNewNQL_Class : TTReportNqlObject 
        {
        }

        public partial class MaterielInspectionAndReceivingPatientInfoNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetPiyasaArastirmaTutanagiNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetWorkListByDateReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetWorkListByFilterExpressionReport_Class : TTReportNqlObject 
        {
        }

        public partial class MaterialRequestFormReportBackUpNQL_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_FirmOfferEntry2Completed()
        {
            // From State : FirmOfferEntry   To State : Completed
#region PostTransition_FirmOfferEntry2Completed
            
            /* foreach(DirectPurchaseActionDetail directPurchaseActionDetail in this.DirectPurchaseActionDetails)
            {
                foreach(DPADetailFirmPriceOffer dpaDetailFirmPriceOffer in directPurchaseActionDetail.FirmPriceOffers)
                {
                    if(dpaDetailFirmPriceOffer.Approved.HasValue == true && dpaDetailFirmPriceOffer.Approved.Value ==true)
                    {
                        directPurchaseActionDetail.SUTCode = dpaDetailFirmPriceOffer.OfferedSUTCode;
                    }
                }
            }*/
            if(TenderNumber.Value == null)
                TenderNumber.GetNextValue(Common.RecTime().Year);
#endregion PostTransition_FirmOfferEntry2Completed
        }

        protected void UndoTransition_FirmOfferEntry2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FirmOfferEntry   To State : Completed
#region UndoTransition_FirmOfferEntry2Completed
            
            foreach(DirectPurchaseActionDetail dpaDetail in DirectPurchaseActionDetails)
            {
                if(dpaDetail.Cancelled.HasValue == true && dpaDetail.Cancelled.Value != true)
                    if(dpaDetail.HasUsed.HasValue == true && dpaDetail.HasUsed.Value == true)
                    throw new Exception(TTUtils.CultureService.GetText("M25883", "Hastaya kullanılmış malzeme bulunduğundan işlem geri alınamaz."));
            }
#endregion UndoTransition_FirmOfferEntry2Completed
        }

        protected void PostTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
#region PostTransition_Approval2Cancelled
            
            bool doNotCancel = false;
            foreach(DirectPurchaseActionDetail dpaDetail in DirectPurchaseActionDetails)
            {
                if(dpaDetail.HasUsed.HasValue == true && dpaDetail.HasUsed.Value == true)
                    doNotCancel = true;
            }
            if(doNotCancel)
                throw new Exception(TTUtils.CultureService.GetText("M25884", "Hastaya kullanılmış malzeme bulunduğundan işlem iptal edilemez."));
            else
            {
                foreach(DirectPurchaseActionDetail dpaDetail in DirectPurchaseActionDetails)
                {
                    dpaDetail.Cancelled = true;
                }
            }
#endregion PostTransition_Approval2Cancelled
        }

        protected void UndoTransition_Approval2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approval   To State : Cancelled
#region UndoTransition_Approval2Cancelled
            
            NoBackStateBack();
#endregion UndoTransition_Approval2Cancelled
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DirectPurchaseAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DirectPurchaseAction.States.FirmOfferEntry && toState == DirectPurchaseAction.States.Completed)
                PostTransition_FirmOfferEntry2Completed();
            else if (fromState == DirectPurchaseAction.States.Approval && toState == DirectPurchaseAction.States.Cancelled)
                PostTransition_Approval2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DirectPurchaseAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DirectPurchaseAction.States.FirmOfferEntry && toState == DirectPurchaseAction.States.Completed)
                UndoTransition_FirmOfferEntry2Completed(transDef);
            else if (fromState == DirectPurchaseAction.States.Approval && toState == DirectPurchaseAction.States.Cancelled)
                UndoTransition_Approval2Cancelled(transDef);
        }

    }
}