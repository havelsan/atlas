
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
    /// Ek Uygulamalar
    /// </summary>
    public partial class BaseAdditionalApplication : BaseSurgeryAndManipulationProcedure
    {
        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (EpisodeAction != null)
            {
                if (EpisodeAction is NursingApplication)  // Hemşirelik Hizmetleri ise
                {
                    if (((NursingApplication)EpisodeAction).EmergencyIntervention != null)
                    {
                        if (accTrx.SubEpisodeProtocol.Brans != null) // Takibin branşı (4400 : Acil Tıp) set edilir
                            return accTrx.SubEpisodeProtocol.Brans.Code;
                    }
                    else if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp != null)
                    {
                        if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource != null) // Tedavi gördüğü kliniğin branşı set edilir
                        {
                            if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource is ResClinic)
                            {
                                if (((ResClinic)(((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource)).Brans != null)
                                    return ((ResClinic)(((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource)).Brans.Code;
                            }
                        }
                    }
                }
                else // Hemşirelik Hizmetleri dışındaki işlemler için
                {
                    if (accTrx.SubEpisodeProtocol.Brans != null)
                        return accTrx.SubEpisodeProtocol.Brans.Code;
                }
            }

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (EpisodeAction != null)
            {
                if (EpisodeAction is NursingApplication)  // Hemşirelik Hizmetleri ise
                {   // Acil Hasta Müdahale'den oluşmuş Hemşirelik Hizmetleri işlemi ise, Acil Hasta Müdahale'nin Sorumlu Tabibinin drTescilNo alınır
                    if (((NursingApplication)EpisodeAction).EmergencyIntervention != null)
                    {
                        if (((NursingApplication)EpisodeAction).EmergencyIntervention.ResponsibleDoctor != null)
                        {
                            if (!string.IsNullOrEmpty(((NursingApplication)EpisodeAction).EmergencyIntervention.ResponsibleDoctor.DiplomaRegisterNo))
                                return ((NursingApplication)EpisodeAction).EmergencyIntervention.ResponsibleDoctor.DiplomaRegisterNo;
                        }
                    }
                    else if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp != null)
                    {   // Yatış'tan oluşmuş Hemşirelik Hizmetleri işlemi ise, Yatış işleminin Sorumlu Tabibinin drTescilNo alınır
                        if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.ProcedureDoctor != null)
                        {
                            if (!string.IsNullOrEmpty(((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo))
                                return ((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo;
                        }

                        if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.BaseInpatientAdmission != null)
                        {
                            if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.BaseInpatientAdmission.ProcedureDoctor != null)
                            {
                                if (!string.IsNullOrEmpty(((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.BaseInpatientAdmission.ProcedureDoctor.DiplomaRegisterNo))
                                    return ((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.BaseInpatientAdmission.ProcedureDoctor.DiplomaRegisterNo;
                            }
                        }

                        if (((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.BaseInpatientAdmission != null)
                        {
                            foreach (InPatientTreatmentClinicApplication clinicApp in ((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.BaseInpatientAdmission.InPatientTreatmentClinicApplications)
                            {
                                if (clinicApp.ProcedureDoctor != null && !string.IsNullOrEmpty(clinicApp.ProcedureDoctor.DiplomaRegisterNo))
                                    return clinicApp.ProcedureDoctor.DiplomaRegisterNo;
                            }
                        }
                    }
                }
                else // Hemşirelik Hizmetleri dışındaki işlemler için
                {
                    if (EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                        return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;
                }
            }

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVOEuroscore()
        {
            return MedulaEuroScore;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (BaseAdditionalInfoForm != null)
            {
                foreach (BaseAdditionalInfo baseAdditionalInfo in BaseAdditionalInfoForm)
                {
                    AdditionalReport additionalReport = baseAdditionalInfo as AdditionalReport;
                    if (additionalReport != null && additionalReport.Report != null)
                    {
                        string report = HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(additionalReport.Report.ToString());
                        if (report.Length > 199)
                            return report.Substring(0, 199);

                        return report;
                    }
                }
            }

            return null;
        }

        public override void SetPerformedDate()
        {
            if (CreationDate.HasValue)
            {
                PerformedDate = CreationDate.Value.AddMinutes(1);
            }
        }

    }
}