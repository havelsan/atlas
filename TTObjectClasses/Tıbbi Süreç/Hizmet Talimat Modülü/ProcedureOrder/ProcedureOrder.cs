
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
    /// Hizmet Talimat/İstek
    /// </summary>
    public  partial class ProcedureOrder : BaseProcedureOrder, IWorkListEpisodeAction
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "ANESTHESIAANDREANIMATION":
                    {
                        AnesthesiaAndReanimation value = (AnesthesiaAndReanimation)newValue;
#region ANESTHESIAANDREANIMATION_SetParentScript
                        if (value!=null)
            {
                FromResource=value.FromResource;
                MasterResource=value.MasterResource;
                Episode=value.Episode;
                Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                AmountForPeriod = 1;
                RecurrenceDayAmount = 1;
                CurrentStateDefID = ProcedureOrder.States.New;
            }
#endregion ANESTHESIAANDREANIMATION_SetParentScript
                    }
                    break;
                case "PROCEDUREORDERDETAIL":
                    {
                        ProcedureOrderDetail value = (ProcedureOrderDetail)newValue;
#region PROCEDUREORDERDETAIL_SetParentScript
                        if (value!=null)
            {
                //this.FromResource=value.FromResource;
                //this.MasterResource=value.MasterResource;
                //this.Episode=value.Episode;
                Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                AmountForPeriod = 1;
                RecurrenceDayAmount = 1;
                //this.CurrentStateDefID = ProcedureOrder.States.New;                
            }
#endregion PROCEDUREORDERDETAIL_SetParentScript
                    }
                    break;
                case "PATIENTEXAMINATION":
                    {
                        PatientExamination value = (PatientExamination)newValue;
#region PATIENTEXAMINATION_SetParentScript
                        if (value!=null)
            {
                FromResource=value.FromResource;
                MasterResource=value.MasterResource;
                Episode=value.Episode;
                Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                AmountForPeriod = 1;
                RecurrenceDayAmount = 1;
                CurrentStateDefID = ProcedureOrder.States.New;                
            }
#endregion PATIENTEXAMINATION_SetParentScript
                    }
                    break;
                case "INPATIENTPHYSICIANAPPLICATION":
                    {
                        InPatientPhysicianApplication value = (InPatientPhysicianApplication)newValue;
#region INPATIENTPHYSICIANAPPLICATION_SetParentScript
                        if (value!=null)
            {
                FromResource=value.FromResource;
                MasterResource=value.MasterResource;
                Episode=value.Episode;
                Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                AmountForPeriod = 1;
                RecurrenceDayAmount = 1;
                CurrentStateDefID = ProcedureOrder.States.New;                
            }
#endregion INPATIENTPHYSICIANAPPLICATION_SetParentScript
                    }
                    break;
                case "FOLLOWUPEXAMINATION":
                    {
                        FollowUpExamination value = (FollowUpExamination)newValue;
#region FOLLOWUPEXAMINATION_SetParentScript
                        if (value!=null)
            {
                FromResource=value.FromResource;
                MasterResource=value.MasterResource;
                Episode=value.Episode;
                Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                AmountForPeriod = 1;
                RecurrenceDayAmount = 1;
                CurrentStateDefID = ProcedureOrder.States.New;                
            }
#endregion FOLLOWUPEXAMINATION_SetParentScript
                    }
                    break;
                case "CONSULTATION":
                    {
                        Consultation value = (Consultation)newValue;
#region CONSULTATION_SetParentScript
                        if (value!=null)
            {
                FromResource=value.FromResource;
                MasterResource=value.MasterResource;
                Episode=value.Episode;
                Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                AmountForPeriod = 1;
                RecurrenceDayAmount = 1;
                CurrentStateDefID = ProcedureOrder.States.New;
            }
#endregion CONSULTATION_SetParentScript
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
            CurrentStateDefID = ProcedureOrder.States.New;

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            
             if(PeriodStartTime != null)
                WorkListDate = PeriodStartTime;
            if(ProcedureObject != null)
                DescriptionForWorkList = ProcedureObject.Name;
#endregion PostInsert
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();

#endregion PreDelete
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PostTransition_New2Cancelled
            
            Cancel();
#endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_New2Planned()
        {
            // From State : New   To State : Planned
#region PostTransition_New2Planned
            
            CreateOrderDetails();
#endregion PostTransition_New2Planned
        }

        protected void PostTransition_Planned2Cancelled()
        {
            // From State : Planned   To State : Cancelled
#region PostTransition_Planned2Cancelled
            
            Cancel();
#endregion PostTransition_Planned2Cancelled
        }

#region Methods
        public override PeriodicOrderDetail CreateOrderDetail()
        {
            return  (PeriodicOrderDetail) (new ProcedureOrderDetail(this));
        }
        public override void CreateOrderDetails()
        {
            base.CreateOrderDetails();
        }
        public override void Cancel()
        {
            base.Cancel();
            CurrentStateDefID = ProcedureOrder.States.Cancelled;
        }
        
        
        override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            //if(((ITTObject)this).IsNew==true)
            if(CurrentStateDef == null || CurrentStateDefID==ProcedureOrder.States.New)
                return false;
            
            if(propDef.PropertyDefID!=new Guid("b1642876-6311-4467-9442-3942a89474c1") && propDef.PropertyDefID!=new Guid("506f86d7-780a-40d5-87b0-0443e3c646b3") && propDef.PropertyDefID!=new Guid("04abbf28-747a-4b49-9cf0-4b4601f1e311") && propDef.PropertyDefID!=new Guid("ef9dab05-aab7-47a8-9666-1876a1a68a50"))
                return true;
            return false;
        }
        override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            //            //if(((ITTObject)this).IsNew==true)
            //            if(this.CurrentStateDef == null || this.CurrentStateDefID==ProcedureOrder.States.New)
            //                return false;
     
            return false;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProcedureOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProcedureOrder.States.New && toState == ProcedureOrder.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == ProcedureOrder.States.New && toState == ProcedureOrder.States.Planned)
                PostTransition_New2Planned();
            else if (fromState == ProcedureOrder.States.Planned && toState == ProcedureOrder.States.Cancelled)
                PostTransition_Planned2Cancelled();
        }

    }
}