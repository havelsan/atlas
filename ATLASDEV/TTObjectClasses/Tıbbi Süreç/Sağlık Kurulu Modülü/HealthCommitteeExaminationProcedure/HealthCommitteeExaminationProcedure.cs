
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
    /// Sağlık Kurulu Muayenesi Hizmeti
    /// </summary>
    public  partial class HealthCommitteeExaminationProcedure : SubActionProcedure
    {
#region Methods
        public HealthCommitteeExaminationProcedure(HealthCommitteeExamination pExamination,string guid):this(pExamination.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            
            ProcedureObject = (ProcedureDefinition)pExamination.ObjectContext.GetObject(procedureGuid,"PROCEDUREDEFINITION");
            PerformedDate = Common.RecTime();
            pExamination.HealthCommitteeExaminationProcedures.Add (this);
        }
        public HealthCommitteeExaminationProcedure(PatientExamination pExamination, string guid) : this(pExamination.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);

            ProcedureObject = (ProcedureDefinition)pExamination.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            PerformedDate = Common.RecTime();
            pExamination.HealthCommitteeExaminationProcedure.Add(this);
        }
       
        public override string GetDVOMuayeneTarihi(AccountTransaction accTrx)
        {
            return accTrx.MedulaTransactionDate;
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (accTrx != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override void SetPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            if (CreationDate == null || (CreationDate != null && PatientExamination.ProcessDate != null && CreationDate > PatientExamination.ProcessDate))
                CreationDate = PatientExamination.ProcessDate;
            if (PerformedDate == null && PatientExamination.ProcessEndDate != null)
                PerformedDate = PatientExamination.ProcessEndDate;
            if (PerformedDate != null && CreationDate != null && CreationDate >= PerformedDate)
                PerformedDate = CreationDate.Value.AddMinutes(1);
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == HealthCommitteeExaminationProcedure.States.Completed)
                return true;
            return isNewInserted;
        }
        #endregion Methods

    }
}