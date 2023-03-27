
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
    /// HİZMET PROTOKOL KABUL NESNESİ
    /// </summary>
    public partial class DispatchExamination : PhysicianApplication
    {
        public SubEpisodeStatusEnum SubEpisodePatientStatus;

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();


            #endregion PostInsert
        }
        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            if (TransDef != null)
            {
                if (TransDef.ToStateDefID == DispatchExamination.States.Cancelled)
                {
                    Cancel();
                }
            }

            #endregion PostUpdate
        }
        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();

            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_ProcedureRequested2Completed()
        {
            // From State : ProcedureRequested   To State : Completed
            #region PostTransition_ProcedureRequested2Completed

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;

            #endregion PostTransition_ProcedureRequested2Completed
        }
        protected void PostTransition_ProcedureRequested2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PostTransition_ProcedureRequested2Cancelled

            Cancel();

            #endregion PostTransition_ProcedureRequested2Cancelled
        }
        protected void PostTransition_Completed2ProcedureRequested()
        {
            // From State : Examination   To State : Cancelled
            #region PostTransition_ProcedureRequested2Cancelled

            SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.TetkikIstemDevam;

            Cancel();

            #endregion PostTransition_ProcedureRequested2Cancelled
        }
        protected void PostTransition_FromExamination()
        {
            // From State : Examination   
            #region PostTransition_FromExamination

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
            {
                if (CurrentStateDefID == DispatchExamination.States.Completed)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
                else if (CurrentStateDefID == DispatchExamination.States.ProcedureRequested)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.TetkikIstemDevam;
                else if (CurrentStateDefID == DispatchExamination.States.ProcedureRequested)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.Muayenede;
            }

            #endregion PostTransition_FromExamination
        }
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DispatchExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DispatchExamination.States.Completed && toState == DispatchExamination.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == DispatchExamination.States.ProcedureRequested && toState == DispatchExamination.States.ProcedureRequested)
                PostTransition_Completed2ProcedureRequested();
            else if (fromState == DispatchExamination.States.ProcedureRequested && toState == DispatchExamination.States.Completed)
                PostTransition_ProcedureRequested2Completed();
            else if (fromState == DispatchExamination.States.ProcedureRequested)
            {
                if (toState == DispatchExamination.States.Cancelled)
                    PostTransition_ProcedureRequested2Cancelled();
                else
                    PostTransition_FromExamination();
            }

        }
        public override void Cancel()
        {
            base.Cancel();

            QuotaHistory quota = CheckIfQuotaReturn();
            if (quota != null)
            {
                ((ITTObject)quota).Delete();
                MasterResource.DailyQuota++;
                MasterResource.MonthlyQuota++;
            }
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
        }

        public override BaseAdditionalApplication CreateBaseAdditionalApplication()
        {
            return new DispatchExaminationAdditionalApplication(ObjectContext);
        }

        public override void SetSubEpisodePatientStatus(SubEpisodeStatusEnum value)
        {
            SubEpisodePatientStatus = value;
        }

        public void SetDispatchEpisodeActionProperties(PatientAdmission pa)
        {
            FromResource = Common.CurrentResource.SelectedResources[0];
            MasterResource = Common.CurrentResource.SelectedResources[0];
            Episode = pa.Episode;
            PatientAdmission = pa;
            SubEpisode = pa.FirstSubEpisode;
            IsOldAction = false;
            MasterAction = this;
            SetSubEpisodePatientStatus(SubEpisodeStatusEnum.Outpatient);

            if (((ITTObject)pa).IsNew)
            {
                RequestDate = Common.RecTime();
                ActionDate = Common.RecTime();
            }

        }
    }
}