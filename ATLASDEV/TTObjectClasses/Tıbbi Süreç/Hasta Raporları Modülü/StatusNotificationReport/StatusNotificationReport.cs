
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
    /// Durum Bildirir Raporu
    /// </summary>
    public partial class StatusNotificationReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        protected void PostTransition_Completed2Save()
        {
            #region PostTransition_Completed2Save
            if (!ReportNo.Value.HasValue)
            {
                //Taburcu olmuş hastaların raporları geri alınamaz
                if (SubEpisode != null && SubEpisode.InpatientStatus != null && SubEpisode.InpatientStatus == InpatientStatusEnum.Discharged)
                {
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26975", "Taburcu olan hastaların raporları geri alınamaz."));
                }

                //Faturası kesilmiş hastaların raporları geri alınamaz
                if (Episode != null && Episode.IsInvoicedCompletely)
                {
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25675", "Faturası kesilmiş hastaların raporları geri alınamaz."));
                }
            }
            #endregion PostTransition_Completed2Save
        }

        protected void PostTransition_New2Completed()
        {
            #region PostTransition_New2Completed
            if (!ReportNo.Value.HasValue)
            {
                string raporGrubu = HCRequestReason.ReasonForExamination.HCReportTypeDefinition.ReportGroupName;
                ReportNo.GetNextValue(raporGrubu, Common.RecTime().Year);
            }

            CreateHCReportProcedure();

            #endregion PostTransition_New2Completed
        }

        protected void PostTransition_NewOrCompleted2Cancelled()
        {
            #region PostTransition_NewOrCompleted2Cancelled
            if (SubEpisode != null && SubEpisode.InpatientStatus != null && SubEpisode.InpatientStatus == InpatientStatusEnum.Discharged)
            {
                throw new TTUtils.TTException("Taburcu olan hastaların raporları iptal edilemez.");
            }

            if (Episode != null && Episode.IsInvoicedCompletely)
            {
                throw new TTUtils.TTException("Faturası kesilmiş hastaların raporları iptal edilemez.");
            }

            //tanı bağlantısını kopart
            if (ReportDiagnosis != null)
            {
                foreach (ReportDiagnosis reportDiagnosis in ReportDiagnosis.ToList())
                {
                    ((ITTObject)reportDiagnosis).Delete();
                }
            }

            #endregion PostTransition_NewOrCompleted2Cancelled
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StatusNotificationReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if ((fromState == StatusNotificationReport.States.Saved || fromState == StatusNotificationReport.States.New) && toState == StatusNotificationReport.States.Completed)
                PostTransition_New2Completed();

            if (fromState == StatusNotificationReport.States.Completed && toState == StatusNotificationReport.States.Saved)
                PostTransition_Completed2Save();

            if ((fromState == StatusNotificationReport.States.Saved || fromState == StatusNotificationReport.States.Completed || fromState == StatusNotificationReport.States.New) && toState == StatusNotificationReport.States.Cancelled)
                PostTransition_NewOrCompleted2Cancelled();
        }

        // Sağlık Kurulu Rapor hizmetini oluşturur
        public void CreateHCReportProcedure()
        {
            Guid procedureCode = ProcedureDefinition.HCReportProcedureObjectId;

            if (StatusNotificationReportHCProcedures.Any(x => x.CurrentStateDefID != SubActionProcedure.States.Cancelled && x.ProcedureObject.ObjectID.Equals(procedureCode)))
                return;

            HealthCommitteeProcedure pProcedure = new HealthCommitteeProcedure(this, procedureCode.ToString());
            pProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
            pProcedure.PerformedDate = Common.RecTime();
        }

       
    }
}