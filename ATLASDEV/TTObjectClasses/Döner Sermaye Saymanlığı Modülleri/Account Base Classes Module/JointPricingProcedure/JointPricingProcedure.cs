
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
    /// Birlikte Ãœcretlendirilecek Hizmet
    /// </summary>
    public partial class JointPricingProcedure : SubActionProcedure
    {
        #region Methods
       
        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (MasterSubActionProcedure != null)
                return MasterSubActionProcedure.GetDVOBransKodu(accTrx);

            if (accTrx != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (MasterSubActionProcedure != null)
                return MasterSubActionProcedure.GetDVODrTescilNo(branchCode);

            ResUser doctor = GetDoctorFromEpisodeForDVO();
            if (doctor != null && !string.IsNullOrEmpty(doctor.DiplomaRegisterNo))
                return doctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public ResUser GetDoctorFromEpisodeForDVO()
        {
            if (EpisodeAction != null && EpisodeAction.Episode != null)
            {
                // Diyaliz işlemi varsa onun doktoru alınır
                foreach (DialysisRequest dialysisRequest in EpisodeAction.Episode.DialysisRequests)
                {
                    if (dialysisRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (dialysisRequest.ProcedureDoctor != null && !string.IsNullOrEmpty(dialysisRequest.ProcedureDoctor.DiplomaRegisterNo))
                            return dialysisRequest.ProcedureDoctor;
                    }
                }
                // Fizyoterapi işlemi varsa onun doktoru alınır
                foreach (PhysiotherapyRequest physiotherapyRequest in EpisodeAction.Episode.PhysiotherapyRequests)
                {
                    if (physiotherapyRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (physiotherapyRequest.ProcedureDoctor != null && !string.IsNullOrEmpty(physiotherapyRequest.ProcedureDoctor.DiplomaRegisterNo))
                            return physiotherapyRequest.ProcedureDoctor;
                    }
                }
                // Hiperbarik Oksijen Tedavisi işlemi varsa onun doktoru alınır
                foreach (HyperbarikOxygenTreatmentRequest hyperbaricRequest in EpisodeAction.Episode.HyperbarikOxygenTreatmentRequests)
                {
                    if (hyperbaricRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (hyperbaricRequest.ProcedureDoctor != null && !string.IsNullOrEmpty(hyperbaricRequest.ProcedureDoctor.DiplomaRegisterNo))
                            return hyperbaricRequest.ProcedureDoctor;
                    }
                }
                // Tıbbi Cerrahi Uygulama işlemi varsa onun doktoru alınır
                foreach (Manipulation manipulation in EpisodeAction.Episode.Manipulations)
                {
                    if (manipulation.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (manipulation.SorumluDoktor != null && !string.IsNullOrEmpty(manipulation.SorumluDoktor.DiplomaRegisterNo))
                            return manipulation.SorumluDoktor;
                    }
                }
                // Ameliyat işlemi varsa onun doktoru alınır
                foreach (Surgery surgery in EpisodeAction.Episode.Surgeries)
                {
                    if (surgery.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (surgery.ProcedureDoctor != null && !string.IsNullOrEmpty(surgery.ProcedureDoctor.DiplomaRegisterNo))
                            return surgery.ProcedureDoctor;
                    }
                }
                // Hasta Muayenesi işlemi varsa onun doktoru alınır
                foreach (PatientExamination patientExamination in EpisodeAction.Episode.PatientExaminations)
                {
                    if (patientExamination.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (patientExamination.ProcedureDoctor != null && !string.IsNullOrEmpty(patientExamination.ProcedureDoctor.DiplomaRegisterNo))
                            return patientExamination.ProcedureDoctor;
                    }
                }
                // ProcedureDoctor u dolu olan herhangi bir EpisodeAction ın doktoru alınır
                foreach (EpisodeAction episodeAction in EpisodeAction.Episode.EpisodeActions)
                {
                    if (episodeAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (episodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(episodeAction.ProcedureDoctor.DiplomaRegisterNo))
                            return episodeAction.ProcedureDoctor;
                    }
                }
                // ProcedureDoctor u dolu olan herhangi bir SubactionProcedure ün doktoru alınır
                foreach (SubActionProcedure subactionProcedure in EpisodeAction.Episode.SubActionProcedures)
                {
                    if (subactionProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (subactionProcedure.ProcedureDoctor != null && !string.IsNullOrEmpty(subactionProcedure.ProcedureDoctor.DiplomaRegisterNo))
                            return subactionProcedure.ProcedureDoctor;
                    }
                }
            }

            return null;
        }

        public override void SetPerformedDate()
        {
            if (CreationDate.HasValue)
            {
                PerformedDate = CreationDate.Value.AddMinutes(1);
            }
        }
        protected override void PostInsert()
        {
            SetPerformedDate();
            base.PostInsert();
        }

        protected override void PostUpdate()
        {
            SetPerformedDate();
            base.PostUpdate();
        }

        #endregion Methods

    }
}