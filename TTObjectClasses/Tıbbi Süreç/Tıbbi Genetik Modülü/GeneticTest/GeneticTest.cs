
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
    public partial class GeneticTest : SubActionProcedure
    {
        public partial class GeneticTestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetGeneticTestBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetGeneticTestByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledGenetic_Class : TTReportNqlObject
        {
        }

        public partial class Olap_GetGeneticTestGenetic_Class : TTReportNqlObject
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
            if (Genetic != null && Genetic.ApprovedBy != null && !(EpisodeAction.MasterAction is InternalProcedureRequest))
                return Genetic.ApprovedBy.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override ResUser GetDVOIstemYapanDr()
        {
            if (Genetic != null && Genetic.RequestDoctor != null)
                return Genetic.RequestDoctor;

            return base.GetDVOIstemYapanDr();
        }

        public override string GetDVOBirim()
        {
            return birim;
        }

        public override string GetDVOSonuc()
        {
            return Genetic?.sonuc;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        //public override string GetDVOSagSol()
        //{
        //    if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
        //        return SagSol?.sagSolKodu;

        //    return SagSol?.getSagSol_LR();
        //}

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (Genetic != null && !string.IsNullOrEmpty(Genetic.Description))
            {
                if (Genetic.Description.Length > 199)
                    return Genetic.Description.Substring(0, 199);

                return Genetic.Description;
            }

            return null;
        }

        public override void SetPerformedDate()
        {
            if (PerformedDate == null)
                PerformedDate = Common.RecTime();

        }
        #endregion Methods

    }
}