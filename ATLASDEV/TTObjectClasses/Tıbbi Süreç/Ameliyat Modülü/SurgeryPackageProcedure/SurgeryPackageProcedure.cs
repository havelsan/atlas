
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
    public partial class SurgeryPackageProcedure : SubActionPackageProcedure
    {
        #region Methods

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == SurgeryPackageProcedure.States.Completed)
                return true;

            return false;

        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (SurgeryProcedure.Department != null)
            {
                foreach (ResourceSpecialityGrid resSpeciality in SurgeryProcedure.Department.ResourceSpecialities)
                {
                    if (resSpeciality.Speciality != null)
                        return resSpeciality.Speciality.Code;
                }
            }

            return null;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (Surgery != null && Surgery.SurgeryReport != null)
            {
                string rtfReport = Common.GetTextOfRTFString(Surgery.SurgeryReport.ToString());
                if (!string.IsNullOrEmpty(rtfReport))
                {
                    if (rtfReport.Length > 254)
                        return rtfReport.Substring(0, 254);

                    return rtfReport;
                }
            }

            return null;
        }

        public override string GetDVOAyniFarkliKesi(object DVO)
        {
            return SurgeryProcedure?.AyniFarkliKesi?.ayniFarkliKesiKodu;
        }

        public override string GetDVOSagSol()
        {
            if(SurgeryProcedure != null)
            {
                if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                    return SurgeryProcedure.MedulaSagSol;

                return MedulaSagSol_LR(SurgeryProcedure.Position);
            }

            return null;
        }

        public override string GetDVOEuroscore()
        {
            return SurgeryProcedure?.MedulaEuroScore;
        }

        public override void SetPerformedDate()
        {
            if (Surgery.SurgeryStartTime != null && Surgery.SurgeryStartTime < CreationDate)
                CreationDate = Surgery.SurgeryStartTime;
            PerformedDate = Surgery.SurgeryEndTime;
        }

        public void SetIncisionAndDateOfAccountTransactions()
        {
            if (SurgeryProcedure != null)
            {
                foreach (AccountTransaction at in AccountTransactions)
                {
                    if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || at.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
                    {
                        at.AyniFarkliKesi = SurgeryProcedure.AyniFarkliKesi;

                        if (SurgeryProcedure.Surgery != null && SurgeryProcedure.Surgery.SurgeryStartTime.HasValue)
                            at.TransactionDate = SurgeryProcedure.Surgery.SurgeryStartTime;
                    }
                }
            }
        }

        public override void AccountOperationAfterUpdate() { }

        #endregion Methods        
    }
}