//$10551E24
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class EmergencyInterventionServiceController
    {
        // TODO Nida  Ateş Nabız Tansiyonu Component haline getir
        partial void PreScript_EmergencyTriageForm(EmergencyTriageFormViewModel viewModel, EmergencyIntervention emergencyIntervention, TTObjectContext objectContext)
        {
            if (emergencyIntervention.BloodPressures.Count > 0)
            {
                foreach (var item in emergencyIntervention.BloodPressures)
                {
                    viewModel.BloodPressure_Diastolik = item.Diastolik;
                    viewModel.BloodPressure_Sistolik = item.Sistolik;
                }
            }

            if (emergencyIntervention.Pulses.Count > 0)
            {
                foreach (var item in emergencyIntervention.Pulses)
                {
                    viewModel.Pulse_Value = item.Value;
                }
            }

            if (emergencyIntervention.Respirations.Count > 0)
            {
                foreach (var item in emergencyIntervention.Respirations)
                {
                    viewModel.Respiration_Value = item.Value;
                }
            }

            if (emergencyIntervention.Temperatures.Count > 0)
            {
                foreach (var item in emergencyIntervention.Temperatures)
                {
                    viewModel.Temperature_Value = item.Value;
                }
            }

            if (emergencyIntervention.SPO2s.Count > 0)
            {
                foreach (var item in emergencyIntervention.SPO2s)
                {
                    viewModel.SPO2_Value = item.Value;
                }
            }

            if (emergencyIntervention.InterventionStartTime == null)
            {
                emergencyIntervention.InterventionStartTime = Common.RecTime();
            }

            //if (emergencyIntervention.PatientAdmission != null && emergencyIntervention.PatientAdmission.EmergencyIntervention != null && emergencyIntervention.PatientAdmission.EmergencyIntervention.Triage == null && emergencyIntervention.PatientAdmission.Triage != null)
            //{
            //    emergencyIntervention.PatientAdmission.EmergencyIntervention.Triage = emergencyIntervention.PatientAdmission.Triage;
            //}

            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_EmergencyTriageForm(EmergencyTriageFormViewModel viewModel, EmergencyIntervention emergencyIntervention, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (emergencyIntervention.Triage == null)
                throw new TTUtils.TTException("'Triaj kodu' alanını seçiniz.");
            else if (emergencyIntervention.Triage.KODU == "0")
                throw new TTUtils.TTException("'Triaj kodu' alanı bu adımda 'Belirtilmemiş' olarak seçilemez.");

            if (emergencyIntervention.IsPregnant != true)
                emergencyIntervention.LastMenstrualPeriod = null;

            if (emergencyIntervention.Episode != null && emergencyIntervention.Episode.Patient != null && emergencyIntervention.Episode.Patient.Sex != null && emergencyIntervention.Episode.Patient.Sex.KODU == "1" && (emergencyIntervention.IsPregnant == true || emergencyIntervention.LastMenstrualPeriod != null))
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25602", "Erkek hastalar için Gebelik ya da son adet tarihi bilgisi girilemez."));
            }

            if (emergencyIntervention.IsPregnant == true && emergencyIntervention.LastMenstrualPeriod == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26913", "Son adet tarihi bilgisi giriniz."));

            if (emergencyIntervention.SubEpisode.OpeningDate != null && emergencyIntervention.SubEpisode.OpeningDate > emergencyIntervention.InterventionStartTime)
            {
                throw new TTUtils.TTException("Triaj Başlama Saati Kabul Tarihinden Önce Olamaz. Kabul Tarihi:" + emergencyIntervention.SubEpisode.OpeningDate?.ToString("dd.MM.yyy HH:mm"));
            }
            //if ((emergencyIntervention.IsPregnant == null || emergencyIntervention.IsPregnant == false) && emergencyIntervention.LastMenstrualPeriod != null)
            //    emergencyIntervention.IsPregnant = true;

            #region VitalSign
            if (viewModel.BloodPressure_Sistolik != null && viewModel.BloodPressure_Diastolik != null)
            {
                BloodPressure bloodPressure;
                if (emergencyIntervention.BloodPressures.Count == 0)
                {
                    bloodPressure = new BloodPressure(objectContext);
                    bloodPressure.ExecutionDate = Common.RecTime();
                }
                else
                {
                    bloodPressure = emergencyIntervention.BloodPressures[0];
                }

                if (viewModel.BloodPressure_Diastolik != null)
                    bloodPressure.Diastolik = Convert.ToInt32(viewModel.BloodPressure_Diastolik);
                if (viewModel.BloodPressure_Sistolik != null)
                    bloodPressure.Sistolik = Convert.ToInt32(viewModel.BloodPressure_Sistolik);
                bloodPressure.EpisodeAction = emergencyIntervention;
            }

            if (viewModel.Pulse_Value != null)
            {
                Pulse pulse;
                if (emergencyIntervention.Pulses.Count == 0)
                {
                    pulse = new Pulse(objectContext);
                    pulse.ExecutionDate = Common.RecTime();
                }
                else
                {
                    pulse = emergencyIntervention.Pulses[0];
                }

                pulse.Value = viewModel.Pulse_Value;
                pulse.EpisodeAction = emergencyIntervention;
            }

            if (viewModel.Respiration_Value != null)
            {
                Respiration respiration;
                if (emergencyIntervention.Respirations.Count == 0)
                {
                    respiration = new Respiration(objectContext);
                    respiration.ExecutionDate = Common.RecTime();
                }
                else
                {
                    respiration = emergencyIntervention.Respirations[0];
                }

                respiration.Value = viewModel.Respiration_Value;
                respiration.EpisodeAction = emergencyIntervention;
            }

            if (viewModel.Temperature_Value != null)
            {
                Temperature temperature;
                if (emergencyIntervention.Temperatures.Count == 0)
                {
                    temperature = new Temperature(objectContext);
                    temperature.ExecutionDate = Common.RecTime();
                }
                else
                {
                    temperature = emergencyIntervention.Temperatures[0];
                }

                temperature.Value = viewModel.Temperature_Value;
                temperature.EpisodeAction = emergencyIntervention;
            }

            if (viewModel.SPO2_Value != null)
            {
                SPO2 spo;
                if (emergencyIntervention.SPO2s.Count == 0)
                {
                    spo = new SPO2(objectContext);
                    spo.ExecutionDate = Common.RecTime();
                }
                else
                {
                    spo = emergencyIntervention.SPO2s[0];
                }

                spo.Value = viewModel.SPO2_Value;
                spo.EpisodeAction = emergencyIntervention;
            }

            #endregion
            //triaj bilgisi :kayıt  kabulü güncelle
            if (emergencyIntervention.Triage != null)
            {
                if (emergencyIntervention.HasMemberChanged("Triage"))//Yeşil alan muayene değişti ise cancel et
                {
                    if ((emergencyIntervention.Triage != null && emergencyIntervention.Triage.KODU == "1") || (((TTObjectClasses.EmergencyIntervention)((((TTInstanceManagement.ITTObject)emergencyIntervention).Original))).Triage != null) &&
                        ((TTObjectClasses.EmergencyIntervention)((((TTInstanceManagement.ITTObject)emergencyIntervention).Original))).Triage.KODU == "1")
                    {
                        foreach (var innerItem in emergencyIntervention.SubactionProcedures.Where(x => x.CurrentStateDefID != SubActionProcedure.States.Cancelled))
                        {
                            if (innerItem is EmergencyInterventionProcedure)
                            {
                                innerItem.ReasonOfCancel = "Triaj kod alanı değiştirildi.";
                                ((ITTObject)innerItem).Cancel();
                            }
                        }
                        ((EmergencyIntervention)emergencyIntervention).AddEmergencyInterventionProcedure();
                    }
                }

                emergencyIntervention.PatientAdmission.Triage = emergencyIntervention.Triage;
                foreach (var item in emergencyIntervention.PatientExaminations)
                {
                    if (item.EmergencyIntervention.Triage == null)
                        item.EmergencyIntervention.Triage = emergencyIntervention.Triage;
                }
                foreach (var item in emergencyIntervention.InPatientPhysicianApplications)
                {
                    if (item.EmergencyIntervention.Triage == null)
                        item.EmergencyIntervention.Triage = emergencyIntervention.Triage;
                }
            }

            if(emergencyIntervention.CurrentStateDefID == EmergencyIntervention.States.Triage)
                emergencyIntervention.CurrentStateDefID = EmergencyIntervention.States.Observation;

            objectContext.Update();

            emergencyIntervention.CurrentStateDefID = EmergencyIntervention.States.Completed;

            if (emergencyIntervention.InterventionEndTime == null)
            {
                emergencyIntervention.InterventionEndTime = Common.RecTime();
            }

            if (emergencyIntervention.InterventionEndTime < emergencyIntervention.InterventionStartTime)
            {
                throw new TTUtils.TTException("'Triaj Başlama Zamanı' 'Triaj Bitiş Zamanından' büyük olamaz.");
            }

            //todo bg
            //copy vital sign info to PE.EmergencyIntervention
            //foreach (var pe in emergencyIntervention.PatientExaminations)
            //{
            //    if (pe.CurrentStateDefID == PatientExamination.States.Examination || pe.CurrentStateDefID == PatientExamination.States.ExaminationCompleted)
            //    {
            //        foreach (var sbo in pe.SpecialityBasedObject)
            //        {
            //            if (sbo is EmergencySpecialityObject)
            //            {
            //                if (sbo.CurrentStateDefID != EmergencyIntervention.States.Cancelled)
            //                {
            //                    //if (sbo.PhysicianApplication.Pulses.Count == 0)
            //                    //    sbo.PhysicianApplication.Pulses[0] = ;
            //                    sbo.PhysicianApplication.Pulses[0] = emergencyIntervention.Pulses[0];
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        throw new TTUtils.TTException("Acil muayene statüsü " + pe.CurrentStateDefID + " olan hastaların triaj bilgileri değiştirilemez.");
            //    }
            //}
        }
    }
}

namespace Core.Models
{
    public partial class EmergencyTriageFormViewModel
    {
        public int? BloodPressure_Sistolik;
        public int? BloodPressure_Diastolik;
        public int? Pulse_Value;
        public int? Respiration_Value;
        public double? Temperature_Value;
        public int? SPO2_Value;
    }
}