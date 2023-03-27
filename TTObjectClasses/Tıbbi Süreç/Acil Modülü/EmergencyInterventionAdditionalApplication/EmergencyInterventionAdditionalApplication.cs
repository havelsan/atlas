
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
    public partial class EmergencyInterventionAdditionalApplication : BaseAdditionalApplication
    {
        #region Methods
      
        public override string GetDVODrTescilNo(string branchCode)
        {
            ResUser sorumluDoktor = Episode.GetPatientExaminationDoctor();
            if (sorumluDoktor != null && !string.IsNullOrEmpty(sorumluDoktor.DiplomaRegisterNo))
                return sorumluDoktor.DiplomaRegisterNo;

            //if (EpisodeAction != null && EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
            //    return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override string GetDVOEuroscore()
        {
            return MedulaEuroScore;
        }
              
        #endregion Methods

    }
}