
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
    public partial class CloseToNewOldEpisodes : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            //TODO BG :DÃœZELT  ler elden geçmeli önce.
            throw new NotImplementedException();
            /*
            TTObjectContext context = new TTObjectContext(false);
            TTObjectContext roContext = new TTObjectContext(true);

            double LimitDay = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEPISODELASTUPDATEDAYLIMIT", "10"));
            LimitDay = (-1 * LimitDay);
            DateTime LimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(LimitDay).Date;
            BindingList<PatientGroupDefinition> pgdList = PatientGroupDefinition.GetAll(roContext);
            DateTime LimitDateForHealthCommitteeAdmission = (Common.RecTime()).AddDays(-60).Date;// Sağlık Kurulu Kabüllerinde 60 gün episode açık kalır.
            DateTime LimitDateForHealthCommitteeExamination = (Common.RecTime()).AddDays(-30).Date;// Sağlık Kurulu ve periyodik muayenelerde 30 gün episode açık kalır.
            string objectDetails = "";
            foreach (PatientGroupDefinition pgd in pgdList)
            {
                IList list;
                if (pgd.EpisodeClosingDayLimit == 0 || pgd.EpisodeClosingDayLimit == null)
                {
                    // Açılış Tarihinden limit kadar gün geçmiş ayaktan vakaların kapatılması için
                    list = Episode.GetOpenedOutPatientByDate(roContext, LimitLastUpdateDate);
                }
                else
                {
                    DateTime LocalLimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * Convert.ToDouble(pgd.EpisodeClosingDayLimit)).Date;
                    list = Episode.GetOpenedOutPatientByDate(roContext, LocalLimitLastUpdateDate);
                }

                foreach (Episode episode in list)
                {
                    if (episode.ObjectID != null)
                        objectDetails = "Episode.ObjectID = " + episode.ObjectID.ToString();
                    try
                    {
                        if (episode.InpatientAdmissions.Count > 0) //Yatanlara karışmasın
                            continue;

                        //TODO:DÃœZELT
                        //if (episode.PatientAdmission != null && episode.PatientAdmission.Sevkli != null && episode.PatientAdmission.Sevkli == true) //E-Sevk sonuçlarını bilemeyiz. Karışmasın.
                        //    continue;

                        //if (episode.PatientExaminations.Count > 0)
                        //{
                        //    PatientExamination patientExamination = (PatientExamination)episode.PatientExaminations[0];
                        //    if (patientExamination.Diagnosis.Count == 0)
                        //        continue;
                        //}

                        //TODO:DÃœZELT
                        //if (episode.PatientAdmission.AdmissionType == AdmissionTypeEnum.HealthCommitteeOfProffesors ||
                        //episode.PatientAdmission.AdmissionType == AdmissionTypeEnum.PortorExamination ||
                        //    episode.PatientAdmission.AdmissionType == AdmissionTypeEnum.HealthCommitteeExamination ||
                        //    episode.PatientAdmission.AdmissionType == AdmissionTypeEnum.HealthCommiteeFromOtherHospitalRequest)
                        //{
                        //    if (episode.OpeningDate > LimitDateForHealthCommitteeAdmission)
                        //        continue;
                        //}

                        if (episode.HasAnyEpisodeHealthCommitteeOrHCExamination() == true)
                        {
                            if (episode.OpeningDate > LimitDateForHealthCommitteeExamination)
                                continue;
                        }

                        if (episode.MainSpeciality != null && episode.MainSpeciality.EpisodeClosingDayLimit != null && episode.MainSpeciality.EpisodeClosingDayLimit > 0)
                        {
                            // Kabulü bu uzmanlık dalına yapılan episodelar verilen limit dolana kadar kapatılmaz
                            if ((Common.RecTime().AddDays(-1 * Convert.ToDouble(episode.MainSpeciality.EpisodeClosingDayLimit)).Date) < episode.OpeningDate)
                                continue;
                        }

                        bool calcelProvision = false;
                        foreach (PatientExamination pe in episode.PatientExaminations) // Episode Kapatılırken Muayenesi de tamamlanır
                        {
                            //if (pe.Diagnosis.Count == 0)
                            //    continue;
                            calcelProvision = false;
                            //if (pe.CurrentStateDefID == PatientExamination.States.Examination || pe.CurrentStateDefID == PatientExamination.States.New)
                            if (pe.CurrentStateDefID == PatientExamination.States.Examination)
                            {
                                if (pe.ObjectID != null)
                                    objectDetails = "PatientExamination.ObjectID = " + pe.ObjectID.ToString();

                                TTObjectContext pecontext = new TTObjectContext(false);

                                PatientExamination peToBeCompleted = (PatientExamination)pecontext.GetObject(pe.ObjectID, pe.ObjectDef);
                                peToBeCompleted.IgnoreEpisodeStateOnUpdate = true;// Complet olduktan sonra worklistdateinin değişmemesi için
                                if (peToBeCompleted.TreatmentMaterials.Count == 0)
                                    peToBeCompleted.IsTreatmentMaterialEmpty = true;

                                if (peToBeCompleted.CurrentStateDefID == PatientExamination.States.Examination)
                                {
                                    if (peToBeCompleted.Diagnosis.Count > 0)
                                        peToBeCompleted.CurrentStateDefID = PatientExamination.States.Completed;
                                    else
                                    {
                                        peToBeCompleted.CurrentStateDefID = PatientExamination.States.Cancelled;
                                        calcelProvision = true;
                                    }
                                }
                                //else if (peToBeCompleted.CurrentStateDefID == PatientExamination.States.New)
                                //{
                                //    peToBeCompleted.CurrentStateDefID = PatientExamination.States.PatientNoShown;
                                //    calcelProvision = true;
                                //}

                                if (calcelProvision) //  && peToBeCompleted.Episode.IsMedulaEpisode() kontrolü vardı kaldırıldı (MDZ)
                                    peToBeCompleted.SubEpisode.CancelSubEpisodeProtocols();

                                pecontext.Save();
                            }
                        }

                        context = new TTObjectContext(false);
                        Episode episodeToBeClosed = (Episode)context.GetObject(episode.ObjectID, episode.ObjectDef);
                        episodeToBeClosed.CloseEpisodeToNew();
                        context.Save();
                    }
                    catch (Exception ex)
                    {
                        this.AddLog(ex.Message + " " + objectDetails);
                    }
                    context = new TTObjectContext(false);
                }

            }

            // eski Kapalı vakalarda açık kalan Muayeneleri kapatır
            BindingList<PatientExamination> peList = PatientExamination.GetUnCompletedExaminationForClosedEpisode(roContext);
            foreach (PatientExamination pe in peList)
            {
                if (pe.ObjectID != null)
                    objectDetails = "PatientExamination.ObjectID = " + pe.ObjectID.ToString();
                try
                {
                    context = new TTObjectContext(false);
                    PatientExamination patientExamination = (PatientExamination)context.GetObject(pe.ObjectID, pe.ObjectDef);
                    if (patientExamination.Diagnosis.Count > 0)
                    {
                        patientExamination.IgnoreEpisodeStateOnUpdate = true;// Complet olduktan sonra worklistdateinin değişmemesi için
                        if (patientExamination.TreatmentMaterials.Count == 0)
                            patientExamination.IsTreatmentMaterialEmpty = true;
                        patientExamination.CurrentStateDefID = PatientExamination.States.Completed;
                        context.Save();
                    }
                }
                catch (Exception ex)
                {
                    this.AddLog(ex.Message + " " + objectDetails);
                }
            }
            */
        }

        #endregion Methods

    }
}