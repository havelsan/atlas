
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
    /// Kan Ãœrün Ek İşlem
    /// </summary>
    public partial class BloodBankSubProduct : SubactionProcedureFlowable
    {
        #region Methods

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.muayeneBilgisi)
            {
                if (accTrx != null)
                    return accTrx.SubEpisodeProtocol.Brans.Code;
            }

            return EpisodeAction.GetBranchCodeForMedula();
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (EpisodeAction != null)
            {
                if (EpisodeAction is BloodProductRequest)
                {
                    if (((BloodProductRequest)EpisodeAction).RequestDoctor != null)
                        return ((BloodProductRequest)EpisodeAction).RequestDoctor.DiplomaRegisterNo;
                }
                else if (EpisodeAction.ProcedureDoctor != null)
                    return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;
            }

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        #endregion Methods

    }
}