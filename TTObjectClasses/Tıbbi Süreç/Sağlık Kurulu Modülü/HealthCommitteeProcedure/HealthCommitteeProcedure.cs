
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
    /// Sağlık Kurulu Prosedürü
    /// </summary>
    public partial class HealthCommitteeProcedure : SubActionProcedure
    {
        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            ///
            base.PostInsert();

            //if (this.HealthCommittee != null)
            //{
            //    // Ãœcreti hasta öderse paket olacağı için, Sağlık Kurulu Rapor ücreti iptal edilir
            //    if (this.HealthCommittee.WhoPays == WhoPaysEnum.PatientPays)
            //    {
            //        if (this.CurrentStateDefID != SubActionProcedure.States.Cancelled && this.ProcedureObject.ObjectID.Equals(ProcedureDefinition.HCReportProcedureObjectId))
            //        {
            //            foreach (AccountTransaction at in this.AccountTransactions)
            //            {
            //                if (at.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
            //                    at.TurnToPatientShare();

            //                at.InvoiceInclusion = false;
            //            }
            //        }
            //    }
            //}

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            if (CurrentStateDefID != SubActionProcedure.States.Cancelled)
            {
                if (PerformedDate == null)
                    SetPerformedDate();
            }

            #endregion PostUpdate
        }

        #region Methods
        public HealthCommitteeProcedure(HealthCommittee pCommittee, string guid)
            : this(pCommittee.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)pCommittee.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            pCommittee.HealthCommitteeProcedures.Add(this);
        }

        public HealthCommitteeProcedure(HealthCommitteeWithThreeSpecialist pCommittee, string guid)
            : this(pCommittee.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)pCommittee.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            pCommittee.HCWithThreeSpecialistProcedures.Add(this);
        }

        public HealthCommitteeProcedure(ParticipatnFreeDrugReport participationFreeDrugReport, string guid)
           : this(participationFreeDrugReport.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)participationFreeDrugReport.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            participationFreeDrugReport.ParticipationFreeDrugReportHCProcedures.Add(this);
        }

        public HealthCommitteeProcedure(StatusNotificationReport statusNotificationReport, string guid)
         : this(statusNotificationReport.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)statusNotificationReport.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            statusNotificationReport.StatusNotificationReportHCProcedures.Add(this);
        }
    
        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (EpisodeAction is HealthCommittee)  // Sağlık Kurulu ise Sağlık Kurulu Başkanı'nın uzmanlığı gönderilir
            {
                if (((HealthCommittee)EpisodeAction).Members != null)
                {
                    foreach (MemberOfHealthCommiittee member in ((HealthCommittee)EpisodeAction).Members)
                    {
                        if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                        {
                            foreach (ResourceSpecialityGrid resSpeciality in member.MemberDoctor.ResourceSpecialities)
                            {
                                if (resSpeciality.Speciality != null)
                                    return resSpeciality.Speciality.Code;
                            }
                        }
                    }
                }
            }
            else if (EpisodeAction is HealthCommitteeWithThreeSpecialist) // Ãœç Uzman Tabip İmzalı Rapor ise Düzenleyen tabibin (1. Uzman Tabip) uzmanlığı gönderilir
            {
                foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid tsg in ((HealthCommitteeWithThreeSpecialist)EpisodeAction).Specialists)
                {
                    if (tsg.Specialist1 != null)
                    {
                        foreach (ResourceSpecialityGrid resSpeciality in tsg.Specialist1.ResourceSpecialities)
                        {
                            if (resSpeciality.Speciality != null)
                                return resSpeciality.Speciality.Code;
                        }
                    }
                }
            }

            if (accTrx.SubEpisodeProtocol.Brans != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (EpisodeAction is HealthCommittee)  // Sağlık Kurulu ise Sağlık Kurulu Başkanı'nın doktor tescil no gönderilir
            {
                if (((HealthCommittee)EpisodeAction).Members != null)
                {
                    foreach (MemberOfHealthCommiittee member in ((HealthCommittee)EpisodeAction).Members)
                    {
                        if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                        {
                            if (!string.IsNullOrEmpty(member.MemberDoctor.DiplomaRegisterNo))
                                return member.MemberDoctor.DiplomaRegisterNo;
                        }
                    }
                }
            }
            else if (EpisodeAction is HealthCommitteeWithThreeSpecialist) // Ãœç Uzman Tabip İmzalı Rapor ise Düzenleyen tabibin (1. Uzman Tabip) doktor tescil no gönderilir
            {
                foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid tsg in ((HealthCommitteeWithThreeSpecialist)EpisodeAction).Specialists)
                {
                    if (tsg.Specialist1 != null && !string.IsNullOrEmpty(tsg.Specialist1.DiplomaRegisterNo))
                        return tsg.Specialist1.DiplomaRegisterNo;
                }
            }

            if (EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }
        public override void SetPerformedDate() // İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            PerformedDate = Common.RecTime();
        }
        #endregion Methods

    }
}