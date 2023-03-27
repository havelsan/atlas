//$08859470
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class CompanionApplicationServiceController
    {
        partial void PreScript_CompanionApplicationForm(CompanionApplicationFormViewModel viewModel, CompanionApplication companionApplication, TTObjectContext objectContext)
        {
            if (viewModel._CompanionApplication.Episode == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    viewModel._CompanionApplication.Episode = episodeAction.Episode;
                    viewModel._CompanionApplication.SetMyInpatientAdmission();
                    if (viewModel._CompanionApplication.MasterAction == null)
                    {
                        InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = null;
                        if (episodeAction is InPatientPhysicianApplication)
                        {
                            inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                        }
                        else if (episodeAction is NursingApplication)
                        {
                            inPatientTreatmentClinicApp = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
                        }
                        else if (episodeAction is InPatientTreatmentClinicApplication)
                        {
                            inPatientTreatmentClinicApp = ((InPatientTreatmentClinicApplication)episodeAction);
                        }
                        else
                            throw new Exception(episodeAction.ObjectDef.ApplicationName + " işlemi üzerinden  Refakatçi işlemi başlatılamaz");
                        viewModel._CompanionApplication.MasterAction = inPatientTreatmentClinicApp;
                    }
                //viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                }
                if (((InPatientTreatmentClinicApplication)viewModel._CompanionApplication.MasterAction).CurrentStateDefID == InPatientTreatmentClinicApplication.States.Procedure || ((InPatientTreatmentClinicApplication)viewModel._CompanionApplication.MasterAction).CurrentStateDefID == InPatientTreatmentClinicApplication.States.Discharged)
                    viewModel.minCompanionDate = ((DateTime)((InPatientTreatmentClinicApplication)viewModel._CompanionApplication.MasterAction).BaseInpatientAdmission.HospitalInPatientDate).ToString("MM.dd.yyyy");
                else
                    throw new Exception("Yatışı başlamamış hastalar için refakatçi eklenemez.");
            }
        }

        partial void PostScript_CompanionApplicationForm(CompanionApplicationFormViewModel viewModel, CompanionApplication companionApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
        }

        [HttpPost]
        public CompanionApplicationFormViewModel CheckMernisNumber(CompanionApplicationFormViewModel viewModel)
        {
            KPSV2.KpsServisSonucuBilesikKisiBilgisi response = KPSV2.WebMethods.BilesikKisiveAdresSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(viewModel._CompanionApplication.UniqueRefNo));
            viewModel._CompanionApplication.CompanionName = response.Sonuc.TCVatandasiKisiKutukleri.KisiBilgisi.TemelBilgisi.Ad + " " + response.Sonuc.TCVatandasiKisiKutukleri.KisiBilgisi.TemelBilgisi.Soyad;
            //viewModel._CompanionApplication.CompanionBirthDate =response.Sonuc.TCVatandasiKisiKutukleri.KisiBilgisi.TemelBilgisi.DogumTarih;
            viewModel._CompanionApplication.CompanionAddress = response.Sonuc.TCVatandasiKisiKutukleri.AdresBilgisi.AcikAdres;
            //viewModel._CompanionApplication.CompanionSex = response.Sonuc.TCVatandasiKisiKutukleri.KisiBilgisi.TemelBilgisi.Cinsiyet.Kod.ToString();
            return viewModel;
        }
    }
}

namespace Core.Models
{
    public partial class CompanionApplicationFormViewModel
    {
        public string minCompanionDate { get; set; }
    }
}