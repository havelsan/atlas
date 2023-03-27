
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
    /// Diyaliz Emrinin  Uygulanmasını Sağlayan Nesnedir
    /// </summary>
    public partial class DialysisOrderDetail : BaseDialysisOrderDetail, IBaseAppointmentDef, IPatientWorkList, IReasonOfReject, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public partial class GetDialysisOrderDetailsForPatient_Class : TTReportNqlObject
        {
        }

        public partial class GetDialysisOrderDetails_Class : TTReportNqlObject
        {
        }

        public partial class GetDialysisOrderDetailsByOrderObject_Class : TTReportNqlObject
        {
        }

        protected override void PostUpdate()
        {
            #region PostUpdate


            base.PostUpdate();

            #endregion PostUpdate
        }

        protected void PostTransition_ApprovalForCancel2Cancelled()
        {
            // From State : ApprovalForCancel   To State : Cancelled
            #region PostTransition_ApprovalForCancel2Cancelled


            Cancel();
            #endregion PostTransition_ApprovalForCancel2Cancelled
        }

        protected void UndoTransition_ApprovalForCancel2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ApprovalForCancel   To State : Cancelled
            #region UndoTransition_ApprovalForCancel2Cancelled

            NoBackStateBack();
            #endregion UndoTransition_ApprovalForCancel2Cancelled
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

        protected void PreTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PreTransition_Execution2Completed


            if (OrderObject.CurrentStateDefID == DialysisOrder.States.ApprovalForAbort)
                throw new Exception(SystemMessage.GetMessage(1242));
            #endregion PreTransition_Execution2Completed
        }

        protected void PostTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PostTransition_Execution2Completed

            SetPerformedDate();
            CompleteMyNewAppoinments();
            IfLastCompleteDialysisOrder();

            #endregion PostTransition_Execution2Completed
        }

        protected void PostTransition_Execution2Cancelled()
        {
            // From State : Execution   To State : Cancelled
            #region PostTransition_Execution2Cancelled

            Cancel();
            #endregion PostTransition_Execution2Cancelled
        }

        protected void UndoTransition_Execution2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Execution   To State : Cancelled
            #region UndoTransition_Execution2Cancelled

            NoBackStateBack();
            #endregion UndoTransition_Execution2Cancelled
        }

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public DialysisOrderDetail(DialysisOrder dialysisOrder, Appointment appointment) : this(dialysisOrder.ObjectContext)
        {
            TreatmentEquipment = (ResEquipment)appointment.Resource;
        }

        public DialysisOrderDetail(DialysisOrder dialysisOrder) : this(dialysisOrder.ObjectContext)
        {
            TreatmentEquipment = dialysisOrder.TreatmentEquipment;
        }



        public void IfLastCompleteDialysisOrder()
        {
            bool allComplete = true;
            foreach (SubActionProcedure orderDetail in OrderObject.OrderDetails)
            {
                if (orderDetail.CurrentStateDef.Status == StateStatusEnum.Uncompleted && orderDetail.ObjectID != ObjectID)
                {
                    allComplete = false;
                }
            }
            if (allComplete)
            {
                if (((DialysisOrder)OrderObject).CurrentStateDefID == DialysisOrder.States.Therapy)
                    ((DialysisOrder)OrderObject).CurrentStateDefID = DialysisOrder.States.Completed;
            }
        }
        public override void Cancel()
        {
            base.Cancel();
            CancelMyNewAppoinments();
            IfLastCompleteDialysisOrder();
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            DialysisOrder dialysisOrder = (DialysisOrder)OrderObject;

            if (dialysisOrder != null && dialysisOrder.DialysisRequest != null && dialysisOrder.DialysisRequest.ProcedureDoctor != null)
                return dialysisOrder.DialysisRequest.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVORaporTakipNo()
        {
            DialysisOrder dialysisOrder = (DialysisOrder)OrderObject;

            if (dialysisOrder != null && dialysisOrder.DialysisRequest != null)
                return dialysisOrder.DialysisRequest.MedulaRaporTakipNo;

            return null;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override void SetPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            PerformedDate = ActionDate;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DialysisOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DialysisOrderDetail.States.Execution && toState == DialysisOrderDetail.States.Completed)
                PreTransition_Execution2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DialysisOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DialysisOrderDetail.States.ApprovalForCancel && toState == DialysisOrderDetail.States.Cancelled)
                PostTransition_ApprovalForCancel2Cancelled();
            else if (fromState == DialysisOrderDetail.States.Completed && toState == DialysisOrderDetail.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == DialysisOrderDetail.States.Execution && toState == DialysisOrderDetail.States.Completed)
                PostTransition_Execution2Completed();
            else if (fromState == DialysisOrderDetail.States.Execution && toState == DialysisOrderDetail.States.Cancelled)
                PostTransition_Execution2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DialysisOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DialysisOrderDetail.States.ApprovalForCancel && toState == DialysisOrderDetail.States.Cancelled)
                UndoTransition_ApprovalForCancel2Cancelled(transDef);
            else if (fromState == DialysisOrderDetail.States.Completed && toState == DialysisOrderDetail.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == DialysisOrderDetail.States.Execution && toState == DialysisOrderDetail.States.Cancelled)
                UndoTransition_Execution2Cancelled(transDef);
        }

    }
}