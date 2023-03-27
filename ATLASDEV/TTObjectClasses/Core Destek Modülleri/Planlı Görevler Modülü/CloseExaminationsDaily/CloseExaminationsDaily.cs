
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
    public partial class CloseExaminationsDaily : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEXAMINATIONSDAILY", "TRUE") == "FALSE")
                return;

            TTObjectContext context;
            TTObjectContext roContext = new TTObjectContext(true);

            double LimitDay = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEXAMINATIONSDAYLIMIT", "0"));
            LimitDay = (-1 * LimitDay);
            double completeLimitDay = -10;
            double cancelEmergencyDayLimit = -2;

            DateTime LimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(LimitDay).Date;
            DateTime completeLimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(completeLimitDay).Date;
            DateTime cancelEmergencyLimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(cancelEmergencyDayLimit).Date;

            string objectDetails = "";

            IList list = PatientExamination.GetDailyOpenPatientExaminations(roContext, LimitLastUpdateDate);
            foreach (PatientExamination patientExamination in list)
            {
                //sağlık kurulu türündeki muayeneler otomatik tamamlanmasın.
                if (patientExamination.PatientExaminationType == PatientExaminationEnum.HealthCommittee || patientExamination.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                    continue;
                try
                {
                    bool cancelProvision = false;
                    bool completeExamination = false;
                    if (patientExamination.CurrentStateDefID == PatientExamination.States.Examination || patientExamination.CurrentStateDefID == PatientExamination.States.ExaminationCompleted || patientExamination.CurrentStateDefID == PatientExamination.States.ProcedureRequested)
                    {
                        context = new TTObjectContext(false);
                        if (patientExamination.ObjectID != null)
                            objectDetails = "Kabul No = " + patientExamination.SubEpisode.ProtocolNo + " - PatientExamination.ObjectID = " + patientExamination.ObjectID.ToString();

                        PatientExamination peToBeCompleted = (PatientExamination)context.GetObject(patientExamination.ObjectID, patientExamination.ObjectDef);
                        peToBeCompleted.IgnoreEpisodeStateOnUpdate = true;// Complete olduktan sonra worklistdateinin değişmemesi için
                        if (peToBeCompleted.TreatmentMaterials.Count == 0)
                            peToBeCompleted.IsTreatmentMaterialEmpty = true;

                        if (peToBeCompleted.CurrentStateDefID == PatientExamination.States.Examination)
                        {
                            if (peToBeCompleted.SubEpisode.IsDiagnosisExists())
                            {
                                if (peToBeCompleted.RequestDate <= completeLimitLastUpdateDate)
                                {
                                    if (peToBeCompleted.ProcessDate.HasValue == false)
                                    {
                                        peToBeCompleted.ProcessDate = peToBeCompleted.RequestDate.Value.AddMinutes(5);
                                    }
                                    peToBeCompleted.CurrentStateDefID = PatientExamination.States.Completed;
                                    completeExamination = true;
                                }
                            }
                            else
                            {
                                if (peToBeCompleted.SubEpisode.PatientAdmission.PAStatus == PAStatusEnum.Sirada)
                                {
                                    if (peToBeCompleted.PatientExaminationType == PatientExaminationEnum.Emergency)
                                    {
                                        if (peToBeCompleted.RequestDate <= cancelEmergencyLimitLastUpdateDate)
                                        {
                                            if(peToBeCompleted.EmergencyIntervention != null)
                                                peToBeCompleted.EmergencyIntervention.Cancel();
                                            PatientAdmission.DeletePatientAdmission(peToBeCompleted.SubEpisode.PatientAdmission);
                                            if (peToBeCompleted.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
                                            {
                                                peToBeCompleted.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
                                            }
                                            cancelProvision = true;
                                            //objectDetails += " muayeneye gelmedi. Bağlı kabulü iptal edildi. Takibi silindi.";
                                        }
                                    }
                                    else
                                    {
                                        PatientAdmission.DeletePatientAdmission(peToBeCompleted.SubEpisode.PatientAdmission);
                                        if (peToBeCompleted.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.SaglikKurulu)
                                        {
                                            peToBeCompleted.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
                                        }
                                        cancelProvision = true;
                                        //objectDetails += " muayeneye gelmedi. Bağlı kabulü iptal edildi. Takibi silindi.";
                                    }
                                }
                                else
                                    AddLog(objectDetails + " - Hasta Kabul durumu Sırada değil.");
                            }
                        }
                        else
                        {
                            if (peToBeCompleted.RequestDate <= completeLimitLastUpdateDate)
                            {
                                peToBeCompleted.CurrentStateDefID = PatientExamination.States.Completed;
                                completeExamination = true;
                            }
                        }

                        if (cancelProvision) //  && peToBeCompleted.Episode.IsMedulaEpisode() kontrolü vardı kaldırıldı (MDZ)
                        {
                            peToBeCompleted.SubEpisode.CancelSubEpisodeProtocols();
                            //objectDetails += " SubEpisodeProtocol' leri iptal edildi.";
                        }
                        else if (completeExamination)
                        {
                            peToBeCompleted.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
                            //objectDetails += " tamamlandı. Hasta kabul durumu Muayenesi Sonlandı olarak değiştirildi.";
                        }
                        else
                            continue;

                        context.Save();
                        //this.AddLog(objectDetails);
                    }
                }
                catch (Exception ex)
                {
                    AddLog(ex.Message + " " + objectDetails);
                }
            }

            IList dentalList = DentalExamination.GetDailyOpenDentalExaminations(roContext, LimitLastUpdateDate);
            foreach (DentalExamination dentalExamination in dentalList)
            {
                //Hasta kabul sağlık kurulu türünde alındıysa otomatik tamamlanmasın.
                if (dentalExamination.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                    continue;
                try
                {
                    bool cancelProvision = false;
                    bool completeExamination = false;
                    if (dentalExamination.CurrentStateDefID == DentalExamination.States.Examination || dentalExamination.CurrentStateDefID == DentalExamination.States.ExaminationCompleted || dentalExamination.CurrentStateDefID == DentalExamination.States.ProcedureRequested)
                    {
                        context = new TTObjectContext(false);
                        if (dentalExamination.ObjectID != null)
                            objectDetails = "Kabul No = " + dentalExamination.SubEpisode.ProtocolNo + " - DentalExamination.ObjectID = " + dentalExamination.ObjectID.ToString();

                        DentalExamination deToBeCompleted = (DentalExamination)context.GetObject(dentalExamination.ObjectID, dentalExamination.ObjectDef);
                        deToBeCompleted.IgnoreEpisodeStateOnUpdate = true;// Complete olduktan sonra worklistdateinin değişmemesi için
                        if (deToBeCompleted.TreatmentMaterials.Count == 0)
                            deToBeCompleted.IsTreatmentMaterialEmpty = true;

                        if (deToBeCompleted.CurrentStateDefID == DentalExamination.States.Examination)
                        {
                            if (deToBeCompleted.SubEpisode.IsDiagnosisExists())
                            {
                                if (deToBeCompleted.RequestDate <= completeLimitLastUpdateDate)
                                {
                                    if (deToBeCompleted.ProcessDate.HasValue == false)
                                    {
                                        deToBeCompleted.ProcessDate = deToBeCompleted.RequestDate.Value.AddMinutes(5);
                                    }
                                    deToBeCompleted.CurrentStateDefID = DentalExamination.States.Completed;
                                    completeExamination = true;
                                }
                            }
                            else
                            {
                                if (deToBeCompleted.SubEpisode.PatientAdmission.PAStatus == PAStatusEnum.Sirada)
                                {
                                    PatientAdmission.DeletePatientAdmission(deToBeCompleted.SubEpisode.PatientAdmission);
                                    deToBeCompleted.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
                                    cancelProvision = true;
                                    //objectDetails += " muayeneye gelmedi. Bağlı kabulü iptal edildi. Takibi silindi.";
                                }
                                //Yatan hastaya diş kabulü yapıldıysa ve 10 gün boyunca işlem yapılmadıysa iptal edilsin, provizyonu silinsin. Hasta kabul silinmedi çünkü kendine ait bir hasta kabulü yok. İlk ayaktan kabülü gösteriyor.
                                else if(deToBeCompleted.SubEpisode.OldSubEpisode != null && deToBeCompleted.SubEpisode.OldSubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                                {
                                    deToBeCompleted.CurrentStateDefID = DentalExamination.States.Cancelled;
                                    cancelProvision = true;
                                    //objectDetails += " muayeneye gelmedi. Takibi silindi.(Yatan hastaya yapılan diş kabulü)";
                                }
                                else
                                    AddLog(objectDetails + " - Hasta Kabul durumu Sırada değil.");
                            }
                        }
                        else
                        {
                            if (deToBeCompleted.RequestDate <= completeLimitLastUpdateDate)
                            {
                                deToBeCompleted.CurrentStateDefID = DentalExamination.States.Completed;
                                completeExamination = true;
                            }
                        }

                        if (cancelProvision) //  && peToBeCompleted.Episode.IsMedulaEpisode() kontrolü vardı kaldırıldı (MDZ)
                        {
                            deToBeCompleted.SubEpisode.CancelSubEpisodeProtocols();
                            //objectDetails += " SubEpisodeProtocol' leri iptal edildi.";
                        }
                        else if (completeExamination)
                        {
                            deToBeCompleted.SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
                            //objectDetails += " tamamlandı. Hasta kabul durumu Muayenesi Sonlandı olarak değiştirildi.";
                        }
                        else
                            continue;
                        context.Save();
                        //this.AddLog(objectDetails);
                    }
                }
                catch (Exception ex)
                {
                    AddLog(ex.Message + " " + objectDetails);
                }
            }
        }

        #endregion Methods

    }
}