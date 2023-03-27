
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
    /// Ek Uygulamalar Sekmesi
    /// </summary>
    public  partial class ManipulationAdditionalApplication : BaseAdditionalApplication
    {
#region Methods
        
        public override string GetDVODrTescilNo(string branchCode)
        {
            if (Manipulation != null && Manipulation.SorumluDoktor != null)
                return Manipulation.SorumluDoktor.DiplomaRegisterNo;

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

        public override void SetPerformedDate()
        {
            if (PerformedDate == null)
                PerformedDate = Common.RecTime();

        }

        #endregion Methods

    }
}