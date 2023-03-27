
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
    /// Hizmet Talimat/İstek Detayı
    /// </summary>
    public  partial class ProcedureOrderDetail : BaseProcedureOrderDetail, ITreatmentMaterialCollection, IWorkListEpisodeAction
    {
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(ProcedureOrder,ProcedureOrder.MasterResource,ProcedureOrder.FromResource,this);
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            FromResource=ProcedureOrder.FromResource;
            MasterResource=ProcedureOrder.MasterResource; //((ProcedureOrderDefinition)(this.ProcedureOrder.ProcedureObject)).ProcedureOrderResource;
#endregion PreUpdate
        }

        protected void PostTransition_Execution2Cancelled()
        {
            // From State : Execution   To State : Cancelled
#region PostTransition_Execution2Cancelled
            
            Cancel();
#endregion PostTransition_Execution2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public ProcedureOrderDetail(ProcedureOrder procedureOrder): this(procedureOrder.ObjectContext)
        {
            Episode = procedureOrder.Episode;
            CurrentStateDefID = ProcedureOrderDetail.States.Execution;
            ProcedureObject = procedureOrder.ProcedureObject;
            ActionDate = Common.RecTime().Date;
            MasterResource = (ResSection)(((ProcedureOrderDefinition)procedureOrder.ProcedureObject).ProcedureOrderResource);
            FromResource = (ResSection)procedureOrder.FromResource;
            //this.Episode = (Episode)procedureOrder.Episode;
            EpisodeAction = (EpisodeAction)procedureOrder;
//            this.PatientExamination = procedureOrder.PatientExamination;
           // this.FollowUpExamination = procedureOrder.FollowUpExamination;
//            this.InPatientPhysicianApplication = procedureOrder.InPatientPhysicianApplication;
//            this.ConsultationProcedure = procedureOrder.ConsultationProcedure;
            ProcedureOrder = procedureOrder;
            ProcedureOrder.ProcedureOrderDetail = this;
        }
        public override void Cancel()
        {
            CancelOrderDetail();
            base.Cancel();
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProcedureOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProcedureOrderDetail.States.Execution && toState == ProcedureOrderDetail.States.Cancelled)
                PostTransition_Execution2Cancelled();
            else if (fromState == ProcedureOrderDetail.States.Completed && toState == ProcedureOrderDetail.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}