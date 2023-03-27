
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
    /// Diyaliz Emrinin  Uygulanmasýný Saðlayan Nesnedir
    /// </summary>
    public  partial class HemodialysisOrderDetail : SubactionProcedureFlowable
    {
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


            //if (OrderObject.CurrentStateDefID == HemodialysisOrder.States.ApprovalForAbort)
            //    throw new Exception(SystemMessage.GetMessage(1242));
            #endregion PreTransition_Execution2Completed
        }

        protected void PostTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PostTransition_Execution2Completed

            SetPerformedDate();
            CompleteMyNewAppoinments();
            IfLastCompleteHemodialysisOrder();

            var activeSep = SubEpisode.LastActiveSubEpisodeProtocol;
            if (activeSep != null && activeSep.MedulaTedaviTuru.tedaviTuruKodu == "G")
            {
                if (activeSep.CloneType != SEPCloneTypeEnum.PatientInvoice && activeSep.SubEpisode?.PatientAdmission?.IsOldAction != true)
                {
                    TigEpisode.createNewTigObjectForTreatmentCure(activeSep, ObjectContext);
                }
            }
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
        public HemodialysisOrderDetail(HemodialysisOrder dialysisOrder, Appointment appointment) : this(dialysisOrder.ObjectContext)
        {
            TreatmentEquipment = (ResEquipment)appointment.Resource;
        }

        public HemodialysisOrderDetail(HemodialysisOrder dialysisOrder) : this(dialysisOrder.ObjectContext)
        {
            TreatmentEquipment = dialysisOrder.TreatmentEquipment;
        }



        public void IfLastCompleteHemodialysisOrder()
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
                if (((HemodialysisOrder)OrderObject).CurrentStateDefID == HemodialysisOrder.States.Therapy)
                    ((HemodialysisOrder)OrderObject).CurrentStateDefID = HemodialysisOrder.States.Completed;
            }
        }
        public override void Cancel()
        {
            base.Cancel();
            CancelMyNewAppoinments();
            IfLastCompleteHemodialysisOrder();
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            HemodialysisOrder dialysisOrder = (HemodialysisOrder)OrderObject;

            if (dialysisOrder != null && dialysisOrder.HemodialysisRequest != null && dialysisOrder.HemodialysisRequest.ProcedureDoctor != null)
                return dialysisOrder.HemodialysisRequest.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVORaporTakipNo()
        {
            HemodialysisOrder dialysisOrder = (HemodialysisOrder)OrderObject;

            //if (dialysisOrder != null && dialysisOrder.HemodialysisRequest != null)
            //    return dialysisOrder.HemodialysisRequest.MedulaRaporTakipNo;

            return null;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override void SetPerformedDate()// Ýþlemin yapýldýðý tarihi set edecek þekilde override edilmeli
        {
            PerformedDate = ActionDate;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HemodialysisOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == HemodialysisOrderDetail.States.Execution && toState == HemodialysisOrderDetail.States.Completed)
            //    PreTransition_Execution2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HemodialysisOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == HemodialysisOrderDetail.States.ApprovalForCancel && toState == HemodialysisOrderDetail.States.Cancelled)
            //    PostTransition_ApprovalForCancel2Cancelled();
            //else if (fromState == HemodialysisOrderDetail.States.Completed && toState == HemodialysisOrderDetail.States.Cancelled)
            //    PostTransition_Completed2Cancelled();
            //else if (fromState == HemodialysisOrderDetail.States.Execution && toState == HemodialysisOrderDetail.States.Completed)
            //    PostTransition_Execution2Completed();
            //else if (fromState == HemodialysisOrderDetail.States.Execution && toState == HemodialysisOrderDetail.States.Cancelled)
            //    PostTransition_Execution2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HemodialysisOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == HemodialysisOrderDetail.States.ApprovalForCancel && toState == HemodialysisOrderDetail.States.Cancelled)
            //    UndoTransition_ApprovalForCancel2Cancelled(transDef);
            //else if (fromState == HemodialysisOrderDetail.States.Completed && toState == HemodialysisOrderDetail.States.Cancelled)
            //    UndoTransition_Completed2Cancelled(transDef);
            //else if (fromState == HemodialysisOrderDetail.States.Execution && toState == HemodialysisOrderDetail.States.Cancelled)
            //    UndoTransition_Execution2Cancelled(transDef);
        }

    }
}