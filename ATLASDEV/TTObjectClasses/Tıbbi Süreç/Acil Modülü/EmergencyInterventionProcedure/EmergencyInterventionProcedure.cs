
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
    public  partial class EmergencyInterventionProcedure : SubActionProcedure
    {
#region Methods
        public EmergencyInterventionProcedure(EmergencyIntervention emergencyIntervention,string guid):this(emergencyIntervention.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)emergencyIntervention.ObjectContext.GetObject(procedureGuid,"PROCEDUREDEFINITION");
            PerformedDate = Common.RecTime();
            emergencyIntervention.EmergencyInterventionProcedures.Add (this);
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (accTrx != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (EpisodeAction != null)
            {
                if (EpisodeAction is EmergencyIntervention) // acil müdahele ise muayeneyi yapan doktorun doktor tescil no su gönderilecek.
                {
                    //if(((EmergencyIntervention)this.EpisodeAction).ResponsibleDoctor != null && !string.IsNullOrEmpty(((EmergencyIntervention)this.EpisodeAction).ResponsibleDoctor.DiplomaRegisterNo))
                    //muayeneBilgisiDVO.drTescilNo = ((EmergencyIntervention)this.EpisodeAction).ResponsibleDoctor.DiplomaRegisterNo;
                    ResUser sorumluDoktor = Episode.GetPatientExaminationDoctor();
                    if (sorumluDoktor != null && !string.IsNullOrEmpty(sorumluDoktor.DiplomaRegisterNo))
                        return sorumluDoktor.DiplomaRegisterNo;
                }
                else if (EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                    return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;
            }

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override void SetPerformedDate()
        {
            if(PerformedDate == null)
                PerformedDate = Common.RecTime();
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == EmergencyInterventionProcedure.States.Completed)
                return true;
            return isNewInserted;
        }
        #endregion Methods

    }
}