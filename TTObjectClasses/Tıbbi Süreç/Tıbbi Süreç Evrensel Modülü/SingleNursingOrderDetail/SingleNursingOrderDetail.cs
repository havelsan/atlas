
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
    /// Hemşire Takip Gözlem Uygulaması (Ayaktan Hasta)
    /// </summary>
    public  partial class SingleNursingOrderDetail : BaseNursingOrderDetails, ITreatmentMaterialCollection, IWorkListEpisodeAction
    {

        protected override void PreInsert()
        {
            #region PreInsert

            //this.Eligible = false;
            base.PreInsert();
            SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(EpisodeAction, EpisodeAction.MasterResource, EpisodeAction.FromResource,this);
            
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            base.PreUpdate();
            FromResource = EpisodeAction.FromResource;
            MasterResource = EpisodeAction.MasterResource;

            #endregion PreUpdate
        }


        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_Execution2Cancelled()
        {
            // From State : Execution   To State : Cancelled
#region PostTransition_Execution2Cancelled
            Cancel();
#endregion PostTransition_Execution2Cancelled
        }

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public SingleNursingOrderDetail(SingleNursingOrder nursingOrder) : this(nursingOrder.ObjectContext)
        {
            Episode = nursingOrder.Episode;
            CurrentStateDefID = SingleNursingOrderDetail.States.Execution;
            ProcedureObject = nursingOrder.ProcedureObject;
            ActionDate = Common.RecTime().Date;
            MasterResource = (ResSection)nursingOrder.MasterResource;
            FromResource = (ResSection)nursingOrder.FromResource;
            Episode = (Episode)nursingOrder.Episode;
            EpisodeAction = nursingOrder.PhysicianApplication;
            SingleNursingOrder = nursingOrder;
            nursingOrder.SingleNursingOrderDetail = this;
            CreateMyVitalSign();
        }
        
       

        public override void Cancel()
        {
            CancelOrderDetail();
            base.Cancel();
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SingleNursingOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SingleNursingOrderDetail.States.Completed && toState == SingleNursingOrderDetail.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == SingleNursingOrderDetail.States.Execution && toState == SingleNursingOrderDetail.States.Cancelled)
                PostTransition_Execution2Cancelled();
        }

    }
}