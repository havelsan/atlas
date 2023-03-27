
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
    public partial class NuclearMedicineTest : SubActionProcedure
    {
        public partial class NuclearMedicineTestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetNuclearMedicineTestBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetNuclearMedicineTestByEpisode_Class : TTReportNqlObject
        {
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            EpisodeAction.DescriptionForWorkList = ProcedureObject != null ? ProcedureObject.Name : String.Empty;
            base.PostUpdate();
            #endregion PostUpdate
        }

        #region Methods

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (NuclearMedicine != null && NuclearMedicine.ResponsibleDoctor != null && !(EpisodeAction.MasterAction is InternalProcedureRequest))
                return NuclearMedicine.ResponsibleDoctor.DiplomaRegisterNo;

            if (NuclearMedicine != null && NuclearMedicine.RequestDoctor != null)
                return NuclearMedicine.RequestDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVOBirim()
        {
            return NuclearMedicine?.birim;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (NuclearMedicine != null && NuclearMedicine.Report != null)
            {
                string rtfString = Common.GetTextOfRTFString(NuclearMedicine.Report.ToString());
                if (!string.IsNullOrEmpty(rtfString))
                {
                    if (rtfString.Length > 199) // açıklama max 199 karakter olabiliyor
                        return rtfString.Substring(0, 199);

                    return rtfString;
                }
            }

            return null;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return NuclearMedicine?.AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        //public override string GetDVOSagSol()
        //{
        //    if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
        //        return NuclearMedicine?.SagSol?.sagSolKodu;

        //    return NuclearMedicine?.SagSol?.getSagSol_LR();
        //}

        public override string GetDVOAccession()
        {
            return AccessionNo?.ToString();
        }

        public override string GetDVOModality()
        {
            return "M";
        }

        public override void SetPerformedDate()
        {
            if (PerformedDate == null)
                PerformedDate = Common.RecTime();

        }
        #endregion Methods

    }
}