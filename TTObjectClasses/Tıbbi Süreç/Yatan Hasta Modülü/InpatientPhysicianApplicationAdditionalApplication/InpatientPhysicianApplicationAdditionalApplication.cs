
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
    public partial class InpatientPhysicianApplicationAdditionalApplication : BaseAdditionalApplication
    {
        #region Methods
      
        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (EpisodeAction is InPatientPhysicianApplication)
            {
                if (((InPatientPhysicianApplication)EpisodeAction).EmergencyIntervention != null)
                {  // Acil Hasta Müdahale'den oluşmuş Klinik Doktor işlemi ise takibin branşı (4400 : Acil Tıp) set edilir
                    if (accTrx.SubEpisodeProtocol.Brans != null)
                        return accTrx.SubEpisodeProtocol.Brans.Code;
                }
                else if (((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp != null)
                {
                    if (((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource != null) // Tedavi gördüğü kliniğin branşı set edilir
                    {
                        if (((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource is ResClinic)
                        {
                            if (((ResClinic)(((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource)).Brans != null)
                                return ((ResClinic)(((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource)).Brans.Code;
                        }
                    }
                }
            }
            else
            {
                if (accTrx.SubEpisodeProtocol.Brans != null)
                    return accTrx.SubEpisodeProtocol.Brans.Code;
            }

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (ProcedureDoctor != null && !string.IsNullOrEmpty(ProcedureDoctor.DiplomaRegisterNo))
                return ProcedureDoctor.DiplomaRegisterNo;

            if (EpisodeAction is InPatientPhysicianApplication)
            {
                if (((InPatientPhysicianApplication)EpisodeAction).EmergencyIntervention != null)
                {  // Acil Hasta Müdahale'den oluşmuş Klinik Doktor işlemi ise
                    if (((InPatientPhysicianApplication)EpisodeAction).EmergencyIntervention.ResponsibleDoctor != null)
                    {
                        if (!string.IsNullOrEmpty(((InPatientPhysicianApplication)EpisodeAction).EmergencyIntervention.ResponsibleDoctor.DiplomaRegisterNo))
                            return ((InPatientPhysicianApplication)EpisodeAction).EmergencyIntervention.ResponsibleDoctor.DiplomaRegisterNo;
                    }
                }
                else if (((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp != null)
                {   // Yatış'tan oluşmuş Klinik Doktor işlemi ise, Yatış işleminin Sorumlu Tabibinin drTescilNo alınır
                    if (((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp.ProcedureDoctor != null)
                    {
                        if (!string.IsNullOrEmpty(((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo))
                            return ((InPatientPhysicianApplication)EpisodeAction).InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo;
                    }
                }
            }
            else
            {
                if (EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                    return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;
            }

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
            if (PerformedDate == null && CreationDate != null)
                PerformedDate = CreationDate.Value.AddMinutes(1);
            if (PerformedDate != null && CreationDate != null && CreationDate >= PerformedDate)
                PerformedDate = CreationDate.Value.AddMinutes(1);
            //Geçmişe dönük hizmet girildiğinde saat - dakika farkıyla subepisode un açılış tarihinden önceye hizmet girilemesin diye eklendi.
            if (PerformedDate != null && PerformedDate <= SubEpisode.OpeningDate)
            {
                CreationDate = SubEpisode.OpeningDate.Value.AddMinutes(1);
                PerformedDate = SubEpisode.OpeningDate.Value.AddMinutes(2);
            }
        }

        protected override void PostInsert()
        {
            SetPerformedDate();
            base.PostInsert();
        }

        protected override void PostUpdate()
        {
            SetPerformedDate();
            base.PostUpdate();
        }

        #endregion Methods

    }
}