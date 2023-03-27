
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
    /// Hiperbarik Oksijen Tedavisi Emrinin  Uygulamasının Gerçekleştirildiği Nesnedir
    /// </summary>
    public partial class HyperbarikOxygenTreatmentOrderDetail : BaseHyperbarikOxygenTreatmentOrderDetail, IPatientWorkList, IReasonOfReject, IWorkListEpisodeAction, ITreatmentMaterialCollection, IBaseAppointmentDef
    {
        public partial class GetHyperbaricOrderDetailsByOrderObject_Class : TTReportNqlObject
        {
        }

        public partial class GetHyperbaricOrderDetailsForPatient_Class : TTReportNqlObject
        {
        }

        public partial class GetHyperbaricOrderDetails_Class : TTReportNqlObject
        {
        }

        protected override void PostUpdate()
        {
            #region PostUpdate


            base.PostUpdate();

            #endregion PostUpdate
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

        protected void PostTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PostTransition_Execution2Completed


            CompleteMyNewAppoinments();
            ApplicationDate = Common.RecTime();
            IfLastCompleteHyperbaricOxygenTreatmentOrder();
            SetPerformedDate();
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
        public HyperbarikOxygenTreatmentOrderDetail(HyperbaricOxygenTreatmentOrder hyperbarikOxygenTreatmentOrder, Appointment appointment) : this(hyperbarikOxygenTreatmentOrder.ObjectContext)
        {
            //this.TreatmentEquipment=(ResEquipment)appointment.Resource;
        }

        public HyperbarikOxygenTreatmentOrderDetail(HyperbaricOxygenTreatmentOrder hyperbarikOxygenTreatmentOrder) : this(hyperbarikOxygenTreatmentOrder.ObjectContext)
        {
            TreatmentEquipment = hyperbarikOxygenTreatmentOrder.TreatmentEquipment;
        }


        public void IfLastCompleteHyperbaricOxygenTreatmentOrder()
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
                if (((HyperbaricOxygenTreatmentOrder)OrderObject).CurrentStateDefID == HyperbaricOxygenTreatmentOrder.States.Therapy)
                    ((HyperbaricOxygenTreatmentOrder)OrderObject).CurrentStateDefID = HyperbaricOxygenTreatmentOrder.States.Completed;
            }
        }
        public override void Cancel()
        {
            base.Cancel();
            CancelMyNewAppoinments();
            IfLastCompleteHyperbaricOxygenTreatmentOrder();
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            HyperbaricOxygenTreatmentOrder hypOxyTrtmntOrder = OrderObject as HyperbaricOxygenTreatmentOrder;

            if (hypOxyTrtmntOrder?.HyperOxygenTreatmentRequest?.ProcedureDoctor != null)
                return hypOxyTrtmntOrder?.HyperOxygenTreatmentRequest?.ProcedureDoctor?.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override string GetDVORaporTakipNo()
        {
            HyperbaricOxygenTreatmentOrder hypOxyTrtmntOrder = (HyperbaricOxygenTreatmentOrder)OrderObject;

            if (hypOxyTrtmntOrder != null && hypOxyTrtmntOrder.MedulaReportResults != null && hypOxyTrtmntOrder.MedulaReportResults.Count > 0)
            {
                MedulaReportResult medRepRes = (MedulaReportResult)hypOxyTrtmntOrder.MedulaReportResults[0];
                if (!string.IsNullOrEmpty(medRepRes.ReportChasingNo))
                {
                    if (!ObjectContext.IsReadOnly)
                        RaporTakipNo = medRepRes.ReportChasingNo;

                    return medRepRes.ReportChasingNo;
                }
            }

            return null;
        }

        public override void SetPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            PerformedDate = ActionDate;
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HyperbarikOxygenTreatmentOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HyperbarikOxygenTreatmentOrderDetail.States.Completed && toState == HyperbarikOxygenTreatmentOrderDetail.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == HyperbarikOxygenTreatmentOrderDetail.States.Execution && toState == HyperbarikOxygenTreatmentOrderDetail.States.Completed)
                PostTransition_Execution2Completed();
            else if (fromState == HyperbarikOxygenTreatmentOrderDetail.States.Execution && toState == HyperbarikOxygenTreatmentOrderDetail.States.Cancelled)
                PostTransition_Execution2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HyperbarikOxygenTreatmentOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HyperbarikOxygenTreatmentOrderDetail.States.Completed && toState == HyperbarikOxygenTreatmentOrderDetail.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == HyperbarikOxygenTreatmentOrderDetail.States.Execution && toState == HyperbarikOxygenTreatmentOrderDetail.States.Cancelled)
                UndoTransition_Execution2Cancelled(transDef);
        }

    }
}