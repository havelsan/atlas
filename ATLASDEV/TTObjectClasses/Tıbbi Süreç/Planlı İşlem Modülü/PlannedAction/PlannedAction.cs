
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
    /// Planlı Prosedür
    /// </summary>
    public  abstract  partial class PlannedAction : EpisodeActionWithDiagnosis
    {
        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();

#endregion PostUpdate
        }

#region Methods

        public virtual Resource GetDefaultAppointmentResource()
        {
            return null;
        }
        public virtual SubactionProcedureFlowable CreateOrderDetail(Appointment appointment)
        {
            //Bu metod PlannedActiondan türetilmiş tüm classlarda override edilmeli
            return new SubactionProcedureFlowable(ObjectContext);
        }
        
        public virtual SubactionProcedureFlowable CreateOrderDetail()
        {
            //Bu metod PlannedActiondan türetilmiş tüm classlarda override edilmeli
            return new SubactionProcedureFlowable(ObjectContext);
        }
        
        public virtual void CreateAppointmentForOrderDetail(SubactionProcedureFlowable orderDetail)
        {
            
        }
        
        public void CreateOrderDetails()
        {
            //                    for (int i = 1; i <= Amount; i++)
            //                    {
            //                        SubactionProcedureFlowable orderDetail = CreateOrderDetail();
            //                        OrderDetails.Add(orderDetail);
            //                    }
        }
        
        public virtual void SetCurrentStateToTherapy()
        {
            throw new Exception(SystemMessage.GetMessage(976));
        }
        
        //IPlanPlanedAction için kullanılacak

        public PlannedAction GetMyPlannedAction()
        {
            return (PlannedAction)this; 
            
        }

        public void SetMyPlannedAction(PlannedAction value)
        {
        }

        public static bool HasOrderDetailOnGivenState(Guid stateDefId, PlannedAction plannedAction)
        {
            if(plannedAction is DialysisOrder)
            {
                DialysisOrder myDialysisOrder = (DialysisOrder)plannedAction;
                foreach (DialysisOrderDetail orderDetail in myDialysisOrder.OrderDetails)
                {
                    if(orderDetail.CurrentStateDefID == stateDefId)
                        return true;
                }
            }
            else if(plannedAction is HyperbaricOxygenTreatmentOrder)
            {
                HyperbaricOxygenTreatmentOrder myHyperbaricOxygenTreatmentOrder = (HyperbaricOxygenTreatmentOrder)plannedAction;
                foreach (HyperbarikOxygenTreatmentOrderDetail orderDetail in myHyperbaricOxygenTreatmentOrder.OrderDetails)
                {
                    if(orderDetail.CurrentStateDefID == stateDefId)
                        return true;
                }
            }
            else if(plannedAction is PhysiotherapyOrder)
            {
                PhysiotherapyOrder myPhysiotherapyOrder = (PhysiotherapyOrder)plannedAction;
                foreach (PhysiotherapyOrderDetail orderDetail in myPhysiotherapyOrder.OrderDetails)
                {
                    if(orderDetail.CurrentStateDefID == stateDefId)
                        return true;
                }
            }
            else if(plannedAction is PlannedMedicalActionOrder)
            {
                PlannedMedicalActionOrder myPlannedMedicalActionOrder = (PlannedMedicalActionOrder)plannedAction;
                foreach (PlannedMedicalActionOrderDetail orderDetail in myPlannedMedicalActionOrder.OrderDetails)
                {
                    if(orderDetail.CurrentStateDefID == stateDefId)
                        return true;
                }
            }
            return false;
        }
        
#endregion Methods

    }
}