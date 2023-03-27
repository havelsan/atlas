//$96259A49
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class InpatientAdmissionServiceController
    {
        partial void PreScript_InpatientAdmissionRequestForm(InpatientAdmissionRequestFormViewModel viewModel, InpatientAdmission inpatientAdmission, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._InpatientAdmission.FromResource = episodeAction.MasterResource;
                viewModel._InpatientAdmission.Episode = episodeAction.Episode;
                viewModel._InpatientAdmission.SubEpisode = episodeAction.SubEpisode;
                viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();


                // Kontroller
                if (inpatientAdmission.CurrentStateDefID == InpatientAdmission.States.Request)
                {
                    PatientExamination pe = episodeAction.Episode.PatientExaminations.FirstOrDefault(dr => dr.SubEpisode.OpeningDate > episodeAction.SubEpisode.OpeningDate && dr.IsCancelled == false && dr.PatientExaminationType == PatientExaminationEnum.Control);
                    if(pe != null)
                        throw new TTUtils.TTException("Hastanın, " +  pe.SubEpisode.ProtocolNo + " Nolu Kabulü altında " + pe.RequestDate.Value.ToShortDateString() + " tarihli Kontrol Muayenesi bulunmaktadır. Lütfen yatış işlemini Kontrol Muayenesi üzerinden başlatınız.");



                    DateTime? limitDate = null;
                    string errormsg = "Vaka açılış";
                    foreach (var subepisode in inpatientAdmission.Episode.SubEpisodes.OrderByDescending(dr => dr.OpeningDate))
                    {
                        if(subepisode.StarterEpisodeAction is InPatientTreatmentClinicApplication && ((InPatientTreatmentClinicApplication)subepisode.StarterEpisodeAction).ClinicDischargeDate != null)// Hasta Yattı çıkdı ise Son taburcu tarihinden sonra 10 gün içinde tekrar yatışı yapılabilir
                        {
                            limitDate = ((InPatientTreatmentClinicApplication)subepisode.StarterEpisodeAction).ClinicDischargeDate;
                            errormsg = "Son taburcu " ;
                            break;
                        }
                    }
                        
                    if(limitDate == null)
                        limitDate = inpatientAdmission.Episode.OpeningDate.Value;
                    DateTime today = Common.RecTime();
                    System.TimeSpan timeSpan = today.Subtract((DateTime)limitDate);
                    int dayDiff = (int)timeSpan.TotalDays;
                    if (dayDiff > 10)
                    {
                        throw new TTUtils.TTException(errormsg + " tarihi üzerinden 10 gün geçmiş vakalara yatış işlemi başlatamazsınız!");
                    }

                }
                if ( !(inpatientAdmission.SubEpisode.IsDiagnosisExists()))
                {
                    string[] hataParamList = new string[] { TTUtils.CultureService.GetText("M25809", "Hasta Yatış")};
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(157, hataParamList));
                    //throw new Exception("Vakaya, Ön Tanı  girilmeden '" + this._objectDef.Description + "' başlatılamaz .");
                }

                if (inpatientAdmission.Episode.PatientStatus != PatientStatusEnum.Outpatient)
                    throw new TTUtils.TTException("Yatan yada Taburcu durumundaki vakalarda yatış işlemi başlatamazsınız!");
                // Acil serviste muayeneleri YEŞİL ALAN olarak işaretlenen hastaların kliniklere yatışına Medulada ödeme kapsamında olmadığı için  izin verilmemektedir.
                if (inpatientAdmission.Episode != null)
                {
                    foreach (EmergencyIntervention ei in inpatientAdmission.Episode.EmergencyInterventions)
                    {
                        foreach (InPatientPhysicianApplication ippa in ei.InPatientPhysicianApplications)
                        {
                            //if (ippa.IsGreenAreaExamination != null)
                            {
                                if (ippa.IsGreenAreaExamination == true)
                                    throw new Exception(TTUtils.CultureService.GetText("M25095", "Acil serviste muayeneleri YEŞİL ALAN olan hastaların kliniklere yatışına izin verilmemektedir."));
                            }
                        }

                        foreach (PatientExamination pe in ei.PatientExaminations)
                        {
                            if (pe.IsGreenAreaExamination == true)
                                throw new Exception(TTUtils.CultureService.GetText("M27248", "Yeşil alan muayenelerinde hasta yatış işlemi başlatılamaz!"));
                        }
                    }

                    //Günübirlik Takip üzerinden yatış başlatılamaz
                    if (inpatientAdmission.SubEpisode.PatientAdmission != null)
                    {
                        // Hasta Kabul aynı Gün
                        if (inpatientAdmission.SubEpisode.PatientAdmission.ActionDate != null && Common.RecTime().Date == Convert.ToDateTime(inpatientAdmission.SubEpisode.PatientAdmission.ActionDate).Date)
                        {
                            // Kabul Sebebi Günübirlik
                            if (inpatientAdmission.SubEpisode.PatientAdmission.AdmissionType != null && inpatientAdmission.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == true)
                            {
                                throw new Exception("Hasta Kabul Sebebi 'Günübirlik' olduğundan Yatış başlatılamaz. Kabul Sebebi alanı hasta kabul düzeltmeden 'Normal Muayene' olacak şekilde güncellenerek yatış başlatılabilir.");
                            }
                            // Takip Tipi Günübirlik
                            else if (inpatientAdmission.SubEpisode.PatientAdmission.SEP != null && inpatientAdmission.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi != null && inpatientAdmission.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu != null && inpatientAdmission.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu.Equals("T") == true)
                            {
                                throw new Exception("Takip Tipi 'Tanı Amaçlı Günübirlik' olduğundan Yatış başlatılamaz. Hasta kabul düzeltme adımından Takip Tipi, 'Normal' olacak şekilde güncellenerek yatış başlatılabilir.");
                            }
                        }
                        //Hasta Kabul Farklı Gün
                        else
                        {
                            // Kabul Sebebi Günübirlik
                            if (inpatientAdmission.SubEpisode.PatientAdmission.AdmissionType != null && inpatientAdmission.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == true)
                            {
                                throw new Exception("Hasta Kabul Sebebi 'Günübirlik' olduğundan Yatış başlatılamaz.Kabul Sebebi, 'Normal Muayene' olacak şekilde yeni kabul yapılarak Yatış başlatılabilir.");
                            }
                            // Takip Tipi Günübirlik
                            else if (inpatientAdmission.SubEpisode.PatientAdmission.SEP != null && inpatientAdmission.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi != null && inpatientAdmission.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu != null && inpatientAdmission.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu.Equals("T") == true)
                            {
                                throw new Exception("Takip Tipi 'Tanı Amaçlı Günübirlik' olduğundan Yatış başlatılamaz.Takip Tipi, 'Normal' olacak şekilde yeni kabul yapılarak Yatış başlatılabilir.");
                            }
                        }

                        // Kabul Sebebi Sağlık Kurulu Muayenesi
                        if (inpatientAdmission.SubEpisode.PatientAdmission.AdmissionType != null && inpatientAdmission.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.HealthCommitteeExamination) == true)
                        {
                            throw new Exception("Hasta Kabul Sebebi 'Sağlık Kurulu Muayenesi' olan kabullerde Hasta Yatış işlemi başlatılamaz. Yatış işlemi için 'Normal Muayene' kaydı açınız.");
                        }
                    }
                }

                // Pre Dataların Set edilmesi
                Dictionary<ResClinic, bool> defaultTreatmentClinicList = GetDefaultTreatmentClinicList(inpatientAdmission);
                if (viewModel._InpatientAdmission.TreatmentClinic == null)
                {
                    var defaultTreatmentClinic = defaultTreatmentClinicList.FirstOrDefault(dr => dr.Value.Equals(false)).Key;
                    if (defaultTreatmentClinic != null)
                    {
                        viewModel._InpatientAdmission.TreatmentClinic = defaultTreatmentClinic;
                        //if (viewModel._InpatientAdmission.PhysicalStateClinic == null)
                        //{
                        //    var defaultTreatmentClinicEmptyBedList = ResBed.GetEmptyBedsByClinic(defaultTreatmentClinic.ObjectID.ToString()); // boş yatağı varsa Yatacağı klinik de Tedavi kliniği ile aynı set edilir
                        //    if (defaultTreatmentClinicEmptyBedList.Count > 0)
                        //        viewModel._InpatientAdmission.PhysicalStateClinic = defaultTreatmentClinic;
                        //}
                    }
                }

                if (viewModel._InpatientAdmission.TreatmentClinic != null)
                {
                    viewModel.DefaultBulding = viewModel._InpatientAdmission.TreatmentClinic.Department.Building;
                }
                bool isEmergency = false;
                if(episodeAction is PatientExamination && ((PatientExamination)episodeAction).EmergencyIntervention != null )
                    isEmergency = true;
                if(!isEmergency)
                viewModel.TreatmentClinicFilter = GetTreatmentClinicListFilter(defaultTreatmentClinicList);
                viewModel._InpatientAdmission.SetProcedureDoctorAsCurrentResource();

                if (viewModel._InpatientAdmission.ProcedureDoctor == null)
                    viewModel._InpatientAdmission.ProcedureDoctor = episodeAction.SubEpisode.GetSubEpisodeProcedureDoctor();

               

                if (viewModel._InpatientAdmission.RequestDate == null)
                    viewModel._InpatientAdmission.RequestDate = Common.RecTime();
                if (viewModel._InpatientAdmission.EstimatedInpatientDate == null)
                    viewModel._InpatientAdmission.EstimatedInpatientDate = viewModel._InpatientAdmission.RequestDate; // Default Değer olarak atanıyor
                if (viewModel._InpatientAdmission.NeedCompanion == null)
                    viewModel._InpatientAdmission.NeedCompanion = true;

                //default doktor izinli ise boş atsın
                if (viewModel._InpatientAdmission.ProcedureDoctor != null && Common.PersonelIzinKontrol(viewModel._InpatientAdmission.ProcedureDoctor.ObjectID.ToString(), viewModel._InpatientAdmission.EstimatedInpatientDate.Value, objectContext))
                    viewModel._InpatientAdmission.ProcedureDoctor = null;

                ContextToViewModel(viewModel, inpatientAdmission.ObjectContext);
            }
            else
            {
                throw new Exception("Yatış İşlemi ancak aktif bir hasta işlemi üzerinden başlatılabilir ");
            }
            if (inpatientAdmission.Episode.Patient.Sex != null)
                viewModel.PatientSex = inpatientAdmission.Episode.Patient.Sex.KODU;
            else
                viewModel.PatientSex = null;
        }

        partial void PostScript_InpatientAdmissionRequestForm(InpatientAdmissionRequestFormViewModel viewModel, InpatientAdmission inpatientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            var inPatientForBirthGuid = new Guid("8695c125-cc84-4391-9d2b-db2d84afe8cf");
            if (inpatientAdmission.InpatientReason != null && inpatientAdmission.InpatientReason.ObjectID == inPatientForBirthGuid && inpatientAdmission.Episode.Patient.Sex.ADI == "ERKEK")
                throw new TTException(TTUtils.CultureService.GetText("M25605", "Erkek hastaları doğum sebebi ile yatıramazsınız"));
        }

        protected string GetTreatmentClinicListFilter(Dictionary<ResClinic, bool> defaultTreatmentClinicList)
        {
            string filterString = string.Empty;
            if ((TTObjectClasses.SystemParameter.GetParameterValue("TREATMENTCLINICFILTER", "FALSE") == "TRUE"))
            {
                filterString = "OBJECTID IN (''";
                foreach (var defaultTreatmentClinic in defaultTreatmentClinicList)
                {
                    if (defaultTreatmentClinic.Value) // acil klinik varsa Filtre yoktur
                        return string.Empty;
                    filterString += " ,'" + defaultTreatmentClinic.Key.ObjectID.ToString() + "'";
                }

                filterString += ")";
            }

            return filterString;
        }

        protected Dictionary<ResClinic, bool> GetDefaultTreatmentClinicList(InpatientAdmission inpatientAdmission)
        {
            Dictionary<ResClinic, bool> defaultTreatmentClinicList = new Dictionary<ResClinic, bool>();
            bool isEmergency = false;
            if (inpatientAdmission.FromResource != null)
            {
                foreach (ResourceSpecialityGrid spg in inpatientAdmission.FromResource.ResourceSpecialities)
                {
                    if (spg.Speciality != null)
                    {
                        if (spg.Speciality.Code == TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE", "4400").ToString()) //Acil Tıp
                            isEmergency = true;
                        foreach (ResourceSpecialityGrid rsg in spg.Speciality.ResourceSpecialities)
                        {
                            if (rsg.Resource is ResClinic && rsg.Resource.IsActive == true)
                                defaultTreatmentClinicList.Add((ResClinic)rsg.Resource, isEmergency); // Acil Bölümü varsa Filtre olammalı
                        }
                    }
                }
            }

            return defaultTreatmentClinicList;
        }

        partial void AfterContextSaveScript_InpatientAdmissionRequestForm(InpatientAdmissionRequestFormViewModel viewModel, InpatientAdmission inpatientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (inpatientAdmission.CurrentStateDefID == InpatientAdmission.States.Request)
            {
                inpatientAdmission.CurrentStateDefID = InpatientAdmission.States.ClinicProcedure;
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class InpatientAdmissionRequestFormViewModel
    {
        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.ResRoom RoomOfBed
        {
            get;
            set;
        }

        public TTObjectClasses.ResRoomGroup RoomGroupOfRoom
        {
            get;
            set;
        }

        public TTObjectClasses.ResBuilding DefaultBulding
        {
            get;
            set;
        }

        public string TreatmentClinicFilter
        {
            get;
            set;
        }

        public String PatientSex
        {
            get;
            set;
        }
    }
}