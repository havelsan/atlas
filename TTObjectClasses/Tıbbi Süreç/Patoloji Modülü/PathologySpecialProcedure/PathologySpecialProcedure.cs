
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
    public partial class PathologySpecialProcedure : SubActionProcedure
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
            base.PostInsert();

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            base.PreUpdate();

            #endregion PreUpdate
        }

        #region Methods
        public PathologySpecialProcedure(Pathology pathologyTest)
            : this(pathologyTest.ObjectContext)
        {

        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (Pathology != null && Pathology.ResponsibleDoctor != null)
                return Pathology.ResponsibleDoctor.DiplomaRegisterNo;

            if (Pathology != null && Pathology.SpecialDoctor != null)
                return Pathology.SpecialDoctor.DiplomaRegisterNo;

            if (EpisodeAction != null)
            {
                if (EpisodeAction is PathologyRequest)
                {
                    if (((PathologyRequest)EpisodeAction).RequestDoctor != null)
                        return ((PathologyRequest)EpisodeAction).RequestDoctor.DiplomaRegisterNo;
                    if (((PathologyRequest)EpisodeAction).ResponsibleDoctor != null)
                        return ((PathologyRequest)EpisodeAction).ResponsibleDoctor.DiplomaRegisterNo;
                    if (((PathologyRequest)EpisodeAction).SpecialDoctor != null)
                        return ((PathologyRequest)EpisodeAction).SpecialDoctor.DiplomaRegisterNo;
                }
                else
                {
                    if (EpisodeAction.ProcedureDoctor != null)
                        return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;
                }
            }

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVOBirim()
        {
            return Pathology?.birim;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return Pathology?.AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        //public override string GetDVOSagSol()
        //{
        //    if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
        //        return Pathology?.SagSol?.sagSolKodu;

        //    return Pathology?.SagSol?.getSagSol_LR();
        //}

        public override string GetDVORaporTakipNo()
        {
            return Pathology?.raporTakipNo;
        }

        #endregion Methods

    }
}