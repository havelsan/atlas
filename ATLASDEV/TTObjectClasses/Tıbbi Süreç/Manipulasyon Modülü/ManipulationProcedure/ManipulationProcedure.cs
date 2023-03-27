
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
    /// Manipülasyon Sekmesi
    /// </summary>
    public partial class ManipulationProcedure : BaseSurgeryAndManipulationProcedure
    {
        public partial class GetManipulationReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetManipulationRequestReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetManipulationProceduresByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetManipulation_Class : TTReportNqlObject
        {
        }

        public partial class Olap_GetCancelledManipulation_Class : TTReportNqlObject
        {
        }

        public partial class GetManipulationProceduresBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetManipulationProcedureDefinition_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MANIPULATIONREQUEST":
                    {
                        ManipulationRequest value = (ManipulationRequest)newValue;
                        #region MANIPULATIONREQUEST_SetParentScript
                        EpisodeAction = (EpisodeAction)value;
                        #endregion MANIPULATIONREQUEST_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            CancelPatientAccTrxsIfHealthCommittee();
            if (Manipulation != null)
            {
                Manipulation.CreateManipulationFormBaseObject();
                SurgeryDefinition manipulationProcedureDef = (SurgeryDefinition)(ProcedureObject);
                if (manipulationProcedureDef.ManipulationStartState != null)
                {
                    if (Manipulation.CurrentStateDefID == Manipulation.States.RequestAcception)
                    {
                        if (manipulationProcedureDef.ManipulationStartState == ManipulationStartStateEnum.DoctorProcedure)
                            Manipulation.CurrentStateDefID = Manipulation.States.DoctorProcedure;
                        else if (manipulationProcedureDef.ManipulationStartState == ManipulationStartStateEnum.TechnicianProcedure)
                            Manipulation.CurrentStateDefID = Manipulation.States.TechnicianProcedure;
                        else if (manipulationProcedureDef.ManipulationStartState == ManipulationStartStateEnum.NursingProcedure)
                            Manipulation.CurrentStateDefID = Manipulation.States.NursingProcedure;
                    }
                }
            }
            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();
            CancelPatientAccTrxsIfHealthCommittee();

            #endregion PostUpdate
        }

        #region Methods
        public ManipulationProcedure(ManipulationProcedure manipulationProcedure) : this(manipulationProcedure.ObjectContext)
        {
            //YAPILACAKLAR// Appointment Yapıldığında Appointment zamanı atanacak
            Emergency = manipulationProcedure.Emergency;
            ProcedureDepartment = manipulationProcedure.ProcedureDepartment;
            ProcedureDoctor = manipulationProcedure.ProcedureDoctor;
            ProcedureObject = manipulationProcedure.ProcedureObject;
            Description = manipulationProcedure.Description;
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.muayeneBilgisi)
            {
                if (accTrx != null)
                    return accTrx.SubEpisodeProtocol.Brans.Code;
            }

            return EpisodeAction.GetBranchCodeForMedula();
        }

        public override string GetDVOBirim()
        {
            return Birim;
        }

        public override string GetDVOSonuc()
        {
            return Sonuc;
        }

        public override ResUser GetDVOIstemYapanDr()
        {
            if (Manipulation != null && Manipulation.RequestedByUser != null)
                return Manipulation.RequestedByUser;

            return base.GetDVOIstemYapanDr();
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            string rtfString = null;
            if (Manipulation != null && Manipulation.Report != null)
                rtfString = Common.GetTextOfRTFString(Manipulation.Report.ToString());
            else if (RegularObstetric != null && RegularObstetric.Note != null)
                rtfString = Common.GetTextOfRTFString(RegularObstetric.Note.ToString());

            if (!string.IsNullOrEmpty(rtfString))
            {
                if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri)
                {
                    if (rtfString.Length > 199) // açıklama max 199 karakter olabiliyor
                        return rtfString.Substring(0, 199);
                }
                else if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                {
                    if (rtfString.Length > 254) // açıklama max 254 karakter olabiliyor
                        return rtfString.Substring(0, 254);
                }
            }

            return null;
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

        public override string GetDVOEuroscore()
        {
            return MedulaEuroScore;
        }

        public override string GetDVORaporTakipNo()
        {
            return RaporTakipNo;
        }

        public override void SetPerformedDate()
        {
            if (PerformedDate == null)
                PerformedDate = Common.RecTime();

        }

        public override bool EmergencyPropertySetWithAction()
        {
            return false;
        }
        #endregion Methods

    }
}