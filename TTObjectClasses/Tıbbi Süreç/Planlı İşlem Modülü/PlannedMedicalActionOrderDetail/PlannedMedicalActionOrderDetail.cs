
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
    /// Planlı Tıbbi İşlem Uygulama
    /// </summary>
    public partial class PlannedMedicalActionOrderDetail : SubactionProcedureFlowable, IBaseAppointmentDef, IPatientWorkList, IReasonOfReject, ITreatmentMaterialCollection, IWorkListEpisodeAction
    {
        public partial class GetPlannedMedicalActionOrderDetails_Class : TTReportNqlObject
        {
        }

        public partial class GetPlannedMedicalActionOrderDetailsForPatient_Class : TTReportNqlObject
        {
        }

        public partial class GetPlannedMedicalActionOrderDetailsByOrderObject_Class : TTReportNqlObject
        {
        }

        public partial class PlannedMedicalActionOrderDetailEpic_Class : TTReportNqlObject
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

        protected void PreTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PreTransition_Execution2Completed

            if (OrderObject.CurrentStateDefID == PlannedMedicalActionOrder.States.ApprovalForAbort)
                throw new Exception(SystemMessage.GetMessage(1245));
            #endregion PreTransition_Execution2Completed
        }

        protected void PostTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PostTransition_Execution2Completed
            SetPerformedDate();
            CompleteMyNewAppoinments();
            IfLastCompletePlannedMedicalActionOrder();
            #endregion PostTransition_Execution2Completed
        }

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public PlannedMedicalActionOrderDetail(PlannedMedicalActionOrder PlannedMedicalActionOrder, Appointment appointment) : this(PlannedMedicalActionOrder.ObjectContext)
        {
            //this.TreatmentRoom=(ResTreatmentDiagnosisRoom)appointment.Resource;
        }

        public PlannedMedicalActionOrderDetail(PlannedMedicalActionOrder PlannedMedicalActionOrder) : this(PlannedMedicalActionOrder.ObjectContext)
        {
            //this.TreatmentRoom=PlannedMedicalActionOrder.TreatmentRoom;
        }

        public void IfLastCompletePlannedMedicalActionOrder()
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
                if (((PlannedMedicalActionOrder)OrderObject).CurrentStateDefID == PlannedMedicalActionOrder.States.Therapy)
                    ((PlannedMedicalActionOrder)OrderObject).CurrentStateDefID = PlannedMedicalActionOrder.States.Completed;
            }
        }



        public override void Cancel()
        {
            base.Cancel();
            CancelMyNewAppoinments();
            IfLastCompletePlannedMedicalActionOrder();
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (Note != null)
            {
                string rtfString = Common.GetTextOfRTFString(Note.ToString());
                if (!string.IsNullOrEmpty(rtfString))
                {
                    if (rtfString.Length > 254) // açıklama max 254 karakter olabiliyor
                        return rtfString.Substring(0, 254);

                    return rtfString;
                }
            }

            return null;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override string GetDVOEuroscore()
        {
            return ((int)MedulaEuroScoreEnum.Empty).ToString();
        }

        public override string GetDVORaporTakipNo()
        {
            return RaporTakipNo;
        }
        
        public override void SetPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            PerformedDate = ActionDate;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PlannedMedicalActionOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PlannedMedicalActionOrderDetail.States.Execution && toState == PlannedMedicalActionOrderDetail.States.Completed)
                PreTransition_Execution2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PlannedMedicalActionOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PlannedMedicalActionOrderDetail.States.ApprovalForCancel && toState == PlannedMedicalActionOrderDetail.States.Cancelled)
                PostTransition_ApprovalForCancel2Cancelled();
            else if (fromState == PlannedMedicalActionOrderDetail.States.Completed && toState == PlannedMedicalActionOrderDetail.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == PlannedMedicalActionOrderDetail.States.Execution && toState == PlannedMedicalActionOrderDetail.States.Cancelled)
                PostTransition_Execution2Cancelled();
            else if (fromState == PlannedMedicalActionOrderDetail.States.Execution && toState == PlannedMedicalActionOrderDetail.States.Completed)
                PostTransition_Execution2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PlannedMedicalActionOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PlannedMedicalActionOrderDetail.States.ApprovalForCancel && toState == PlannedMedicalActionOrderDetail.States.Cancelled)
                UndoTransition_ApprovalForCancel2Cancelled(transDef);
            else if (fromState == PlannedMedicalActionOrderDetail.States.Completed && toState == PlannedMedicalActionOrderDetail.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == PlannedMedicalActionOrderDetail.States.Execution && toState == PlannedMedicalActionOrderDetail.States.Cancelled)
                UndoTransition_Execution2Cancelled(transDef);
        }

    }
}