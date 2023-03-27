
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
    /// Geçici Kabul ve Mal Alım Muayene için kullanılan temel sınıftır
    /// </summary>
    public  partial class PurchaseExamination : StockAction, IStockOutTransaction, IStockInTransaction
    {
        public partial class GetByObjcetID_Class : TTReportNqlObject 
        {
        }

        public partial class GetPurchaseExaminationRegistryReportQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            
            foreach(StockActionDetailIn sin in StockActionInDetails)
            {
                PurchaseExaminationDetail ped = (PurchaseExaminationDetail)sin;
                ped.PurchaseOrderDetail.Status = OrderDetailStatusEnum.MuayeneAsamasinda;
            }

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            
            if(CurrentStateDefID == PurchaseExamination.States.Completed || CurrentStateDefID == PurchaseExamination.States.Cancelled)
            {
                foreach(PurchaseExaminationDetail ped in PurchaseExaminationDetails)
                {
                    PurchaseExaminationDetailOut pod = new PurchaseExaminationDetailOut(ObjectContext);
                    pod.Amount = ped.Amount;
                    pod.Material = ped.Material;
                    pod.StockLevelType = ped.StockLevelType;
                    pod.StockAction = (StockAction)this;
                    PurchaseExaminationOutDetails.Add(pod);
                }
            }

#endregion PostUpdate
        }

        protected void PostTransition_RejectNotice2Completed()
        {
            // From State : RejectNotice   To State : Completed
#region PostTransition_RejectNotice2Completed
            
            foreach(StockActionDetailIn sin in StockActionInDetails)
            {
                PurchaseExaminationDetail ped = (PurchaseExaminationDetail)sin;
                if(ped.PurchaseExaminationDetStatus == PurchaseExaminationDetailStatusEnum.Accept)
                    ped.PurchaseOrderDetail.Status = OrderDetailStatusEnum.RedTebligiYazildi;
            }


#endregion PostTransition_RejectNotice2Completed
        }

        protected void PreTransition_InspectionMemorandumPreparing2TemporaryAdmissionRegistry()
        {
            // From State : InspectionMemorandumPreparing   To State : TemporaryAdmissionRegistry
#region PreTransition_InspectionMemorandumPreparing2TemporaryAdmissionRegistry
            

            if (PurchaseExaminationOutDetails.Count == 0)
            {
                foreach (PurchaseExaminationDetail purchaseExaminationDetail in PurchaseExaminationDetails)
                {
                    PurchaseExaminationDetailOut purchaseExaminationDetailOut = PurchaseExaminationOutDetails.AddNew();
                    purchaseExaminationDetailOut.Material = purchaseExaminationDetail.Material;
                    purchaseExaminationDetailOut.Amount = purchaseExaminationDetail.Amount;
                    purchaseExaminationDetailOut.StockLevelType = purchaseExaminationDetail.StockLevelType;
                }
            }

#endregion PreTransition_InspectionMemorandumPreparing2TemporaryAdmissionRegistry
        }

        protected void PostTransition_PhysicalExamination2RejectNotice()
        {
            // From State : PhysicalExamination   To State : RejectNotice
#region PostTransition_PhysicalExamination2RejectNotice
            
            foreach(StockActionDetailIn sin in StockActionInDetails)
            {
                PurchaseExaminationDetail ped = (PurchaseExaminationDetail)sin;
                ped.PurchaseOrderDetail.Status = OrderDetailStatusEnum.RedTebligiYapilacak;
            }

#endregion PostTransition_PhysicalExamination2RejectNotice
        }

        protected void PostTransition_PhysicalExamination2Completed()
        {
            // From State : PhysicalExamination   To State : Completed
#region PostTransition_PhysicalExamination2Completed
            
            foreach(StockActionDetailIn sin in StockActionInDetails)
            {
                PurchaseExaminationDetail ped = (PurchaseExaminationDetail)sin;
                if(ped.PurchaseExaminationDetStatus == PurchaseExaminationDetailStatusEnum.Accept)
                    ped.PurchaseOrderDetail.Status = OrderDetailStatusEnum.KurusluKesilecek;
                else if (ped.PurchaseExaminationDetStatus == PurchaseExaminationDetailStatusEnum.Reject)
                    ped.PurchaseOrderDetail.Status = OrderDetailStatusEnum.RedTebligiYapilacak;
            }

#endregion PostTransition_PhysicalExamination2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PurchaseExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PurchaseExamination.States.InspectionMemorandumPreparing && toState == PurchaseExamination.States.TemporaryAdmissionRegistry)
                PreTransition_InspectionMemorandumPreparing2TemporaryAdmissionRegistry();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PurchaseExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PurchaseExamination.States.RejectNotice && toState == PurchaseExamination.States.Completed)
                PostTransition_RejectNotice2Completed();
            else if (fromState == PurchaseExamination.States.PhysicalExamination && toState == PurchaseExamination.States.RejectNotice)
                PostTransition_PhysicalExamination2RejectNotice();
            else if (fromState == PurchaseExamination.States.PhysicalExamination && toState == PurchaseExamination.States.Completed)
                PostTransition_PhysicalExamination2Completed();
        }
        #region Methods
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #region IStockOutTransaction Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #endregion
    }
}