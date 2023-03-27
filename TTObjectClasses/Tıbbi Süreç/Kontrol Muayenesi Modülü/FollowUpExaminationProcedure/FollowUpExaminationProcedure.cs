
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
    public partial class FollowUpExaminationProcedure : SubActionProcedure
    {
        #region Methods
        public FollowUpExaminationProcedure(FollowUpExamination followUpExamination, string guid) : this(followUpExamination.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            ProcedureObject = (ProcedureDefinition)followUpExamination.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            ProcedureDoctor = followUpExamination.ProcedureDoctor;
            ProcedureByUser = followUpExamination.ProcedureDoctor;
            PerformedDate = Common.RecTime();
            followUpExamination.FollowUpExaminationProcedures.Add(this);
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
            if (CreationDate == null || (CreationDate != null && FollowUpExamination.ProcessDate != null && CreationDate > FollowUpExamination.ProcessDate))
                CreationDate = FollowUpExamination.ProcessDate;
            if (PerformedDate == null && FollowUpExamination.ProcessEndDate != null)
                PerformedDate = FollowUpExamination.ProcessEndDate;
            if (PerformedDate != null && CreationDate != null && CreationDate >= PerformedDate)
                PerformedDate = CreationDate.Value.AddMinutes(1);
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == FollowUpExaminationProcedure.States.Completed)
                return true;
            return isNewInserted;
        }

        #endregion Methods

    }
}