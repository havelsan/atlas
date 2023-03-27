
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
    /// Geleneksel Alternatif Tamamlayıcı Uygulama İşlemleri
    /// </summary>
    public  partial class TraditionalAlternative : EpisodeActionWithDiagnosis, IReasonOfReject, IWorkListEpisodeAction
    {
        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();

#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            CheckIfSubEpisodeDiagnosisExists();
#endregion PostUpdate
        }

        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
#region PostTransition_Request2Cancelled
            Cancel();
#endregion PostTransition_Request2Cancelled
        }

        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
#region PostTransition_Procedure2Cancelled
            // <-- Automatically generated part.
Cancel();
#endregion PostTransition_Procedure2Cancelled
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            //            if (theObj.IsNew)
            //            {
            //                this.ReportNo.GetNextValue();
            //            }
        }

        //        public void TurnMyAccountTransactionsToPatientShare()
        //        {
        //            if(this.Episode.Patient.APR.Count > 0)
        //            {
        //                foreach (TraditionalAlternativeProcedure traditionalAlternativeProcedure in this.TraditionalAlternativeProcedures)
        //                {
        //                    foreach (AccountTransaction at in traditionalAlternativeProcedure.AccountTransactions)
        //                    {
        //                        if (at.CurrentStateDefID == AccountTransaction.States.ToBeNew || at.CurrentStateDefID == AccountTransaction.States.New)
        //                        {
        //                            at.CurrentStateDefID = AccountTransaction.States.New;
        //                            at.AccountPayableReceivable = (AccountPayableReceivable)this.Episode.Patient.MyAPR();
        //                        }
        //                    }
        //                }
        //            }
        //        }

        public bool PaymentControl()
        {
            bool odemeDurumu =  true;
            foreach (TraditionalAlternativeProcedure traditionalAlternativeProcedure in TraditionalAlternativeProcedures)
            {
                if (!((SubActionProcedure)traditionalAlternativeProcedure).Paid())
                    odemeDurumu = false;
            }
            return odemeDurumu;
        }
        /// <summary>
        /// Kullan?c? Doktor ise ??lemi Yapan Doktor Olarak Atar
        /// </summary>
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if(CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if(ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    IList userResources = UserResource.GetByUserAndResource(ObjectContext,Common.CurrentResource.ObjectID,MasterResource.ObjectID);
                    if(userResources.Count>0)
                        ProcedureDoctor = Common.CurrentResource;
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TraditionalAlternative).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TraditionalAlternative.States.Request && toState == TraditionalAlternative.States.Cancelled)
                PostTransition_Request2Cancelled();
            else if (fromState == TraditionalAlternative.States.Procedure && toState == TraditionalAlternative.States.Cancelled)
                PostTransition_Procedure2Cancelled();
        }

    }
}