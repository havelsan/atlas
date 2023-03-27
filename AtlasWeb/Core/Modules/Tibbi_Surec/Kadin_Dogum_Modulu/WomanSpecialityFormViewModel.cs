//$53746246
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.ComponentModel;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class WomanSpecialityObjectServiceController
    {
        partial void PreScript_WomanSpecialityForm(WomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTObjectContext objectContext)
        {
            viewModel._Patient = viewModel._WomanSpecialityObject.PhysicianApplication.Episode.Patient;
            viewModel.PregnancyCalendarDefList = new List<PregnancyCalendarDefinitionDVO>();

            if (viewModel._Patient.ActivePregnancy != null && viewModel._Patient.ActivePregnancy.PregnancyType != null && viewModel._Patient.ActivePregnancy.LastMenstrualPeriod != null)
            {
                viewModel.PregnancyWeek = GetPregnancyWeek(viewModel._Patient.ActivePregnancy.LastMenstrualPeriod);
                foreach (var item in PregnancyCalendarDefinition.GetAllNQL(objectContext, /*viewModel._Patient.ActivePregnancy.PregnancyType.Value*/ PregnancyTypeEnum.Singular, "").OrderBy(c => c.StartDate))
                {
                    PregnancyCalendarDefinitionDVO calendar = new PregnancyCalendarDefinitionDVO{FinishDate = item.FinishDate, PeriodName = item.PeriodName, PregnancyType = item.PregnancyType, StartDate = item.StartDate, CalculatedFinishDate = CalculateCalendarDate(item.FinishDate, viewModel._Patient.ActivePregnancy.LastMenstrualPeriod), CalculatedStartDate = CalculateCalendarDate(item.StartDate, viewModel._Patient.ActivePregnancy.LastMenstrualPeriod)};
                    viewModel.PregnancyCalendarDefList.Add(calendar);
                }
            }

            viewModel._WomanSpecialityObject = GetPregnancyStatistics(viewModel._WomanSpecialityObject, viewModel._Patient); //Parite Hesapları
            objectContext.FullPartialllyLoadedObjects();
        }
        partial void PostScript_WomanSpecialityForm(WomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

        }

        private DateTime CalculateCalendarDate(int? periodWeek, DateTime? lastMenstrualPeriod)
        {
            DateTime calculateCalendarDate = DateTime.Now;
            calculateCalendarDate = Convert.ToDateTime(lastMenstrualPeriod).AddDays(Convert.ToInt32(periodWeek * 7));
            return calculateCalendarDate;
        }

        public int GetPregnancyWeek(DateTime? lastMenstrualPeriod)
        {
            DateTime today = DateTime.Now;
            TimeSpan sub = today - Convert.ToDateTime(lastMenstrualPeriod);
            int week = sub.Days / 7;
            return week;
        }

        private WomanSpecialityObject GetPregnancyStatistics(WomanSpecialityObject womanSpecialityObject, Patient patient)
        {
            BindingList<Pregnancy.GetAllPregnanciesByPatient_Class> previousPregnancies = Pregnancy.GetAllPregnanciesByPatient(patient.ObjectID);
            womanSpecialityObject.NumberOfPregnancy = previousPregnancies.Count(); //Gebelik Sayısı
            womanSpecialityObject.Parity = previousPregnancies.Where(c => c.PregnancyPhysiology == PregnancyPhysiologyEnum.Normal).Count(); //Parite : Geçirilen Gebelik Sayısı(doğumla sonlanan)
            womanSpecialityObject.Abortion = previousPregnancies.Where(c => c.PregnancyPhysiology != PregnancyPhysiologyEnum.Normal).Count(); //Abortus : Hastanın geçirdiği düşük sayısı
            BindingList<PregnancyResult.GetAllPregnancyResultsByPatient_Class> pregnancyResults = PregnancyResult.GetAllPregnancyResultsByPatient(patient.ObjectID);
            womanSpecialityObject.LivingBabies = pregnancyResults.Where(c => c.BabyStatus == BirthReportBabyStatus.Alive).Count(); //Yaşayan : Hastanın yaşayan bebek sayısı
            womanSpecialityObject.DC = pregnancyResults.Where(c => c.BabyStatus == BirthReportBabyStatus.Dead).Count(); //D&C : Hastanın ölü bebek sayısı
            return womanSpecialityObject;
        }
    }
}

namespace Core.Models
{
    public partial class WomanSpecialityFormViewModel : ISpecialityBasedObjectViewModel
    {

        public TTObjectClasses.Patient _Patient
        {
            get;
            set;
        }
        //İnfertilite
        public InfertilityFormViewModel _InfertilityFormViewModel;
        public InfertilityPatientInformationFormViewModel _InfertilityPatientInformationFormViewModel;
        //Gebelik
        public PregnancyStartFormViewModel _PregnancyStartFormViewModel;
        public PreviousPregnancyFormViewModel _PreviousPregnancyFormViewModel;
        public PregnancyFollowFormViewModel _PregnancyFollowFormViewModel;
        public PregnancyResultFormViewModel _PregnancyResultFormViewModel;
        public PostpartumFollowUpFormViewModel _PostpartumFollowUpFormViewModel; 
        public bool _IsPregnancyStarted;
        public List<PregnancyCalendarDefinitionDVO> PregnancyCalendarDefList
        {
            get;
            set;
        }

        public int PregnancyWeek
        {
            get;
            set;
        }

        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
            var womanSpecialityObject = (WomanSpecialityObject)objectContext.AddObject(this._WomanSpecialityObject);
            if (this.Gynecologys != null) //Jinekoloji
            {
                var gynecology = (Gynecology)objectContext.AddObject(this.Gynecologys[0]);
                womanSpecialityObject.Gynecology = gynecology;
            }

            if (this._InfertilityFormViewModel != null) //İnfertilite vizit bazlı
            {
                var infertility = (Infertility)objectContext.AddObject(this._InfertilityFormViewModel._Infertility);
                infertility.Patient = this._Patient;
                womanSpecialityObject.Infertility = infertility;
            }

            if (this._InfertilityPatientInformationFormViewModel != null) //İnfertilite hasta bazlı
            {
                var infertilityPatient = (InfertilityPatientInformation)objectContext.AddObject(this._InfertilityPatientInformationFormViewModel._InfertilityPatientInformation);
                womanSpecialityObject.PhysicianApplication.Episode.Patient.InfertilityPatientInformation = infertilityPatient;
            }

            if (this._PregnancyStartFormViewModel != null && this._IsPregnancyStarted == true) //Gebelik Başlatma
            {
                var pregnancyStart = (Pregnancy)objectContext.AddObject(this._PregnancyStartFormViewModel._Pregnancy);
                pregnancyStart.Patient = this._Patient;
                pregnancyStart.StarterWomanSpecialityObject = womanSpecialityObject; //Başlatıldığı Kadın Doğum Objesi
                womanSpecialityObject.PhysicianApplication.Episode.Patient.ActivePregnancy = pregnancyStart;
                if (this._PregnancyStartFormViewModel.PregnancyNotificationGridList != null) //Gebe Bilgilendirme ve Danışmanlık
                {
                    foreach (var item in this._PregnancyStartFormViewModel.PregnancyNotificationGridList)
                    {
                        var notification = (PregnancyNotification)objectContext.AddObject(item);
                        notification.Pregnancy = this._PregnancyStartFormViewModel._Pregnancy;
                    }
                }
            }

            if (this._PregnancyFollowFormViewModel != null) //Gebe İzlem
            {
                var pregnancyFollow = (PregnancyFollow)objectContext.AddObject(this._PregnancyFollowFormViewModel._PregnancyFollow);
                pregnancyFollow.Pregnancy = womanSpecialityObject.PhysicianApplication.Episode.Patient.ActivePregnancy;
                womanSpecialityObject.PregnancyFollow = pregnancyFollow;
                if (this._PregnancyFollowFormViewModel.FetusFollowGridList != null) //Bebek Gelişimi Takip
                {
                    foreach (var item in this._PregnancyFollowFormViewModel.FetusFollowGridList)
                    {
                        var fetusFollow = (FetusFollow)objectContext.AddObject(item);
                        fetusFollow.PregnancyFollow = this._PregnancyFollowFormViewModel._PregnancyFollow;
                    }
                }

                if (this._PregnancyFollowFormViewModel.PregnancyDangerSignGridList != null) //Gebelik Seyrinde Tehlike İşareti
                {
                    foreach (var item in this._PregnancyFollowFormViewModel.PregnancyDangerSignGridList)
                    {
                        var pregnancyDanger = (PregnancyDangerSign)objectContext.AddObject(item);
                        if (((ITTObject)pregnancyDanger).IsDeleted)
                            continue;
                        pregnancyDanger.PregnancyFollow = this._PregnancyFollowFormViewModel._PregnancyFollow;
                    }
                }

                if (this._PregnancyFollowFormViewModel.ObligedRiskFactorsGridList != null) //Bildirimi Zorunlu Risk Faktörleri
                {
                    foreach (var item in this._PregnancyFollowFormViewModel.ObligedRiskFactorsGridList)
                    {
                        var obligedRiskFactors = (ObligedRiskFactors)objectContext.AddObject(item);
                        if (((ITTObject)obligedRiskFactors).IsDeleted)
                            continue;
                        obligedRiskFactors.PregnancyFollow = this._PregnancyFollowFormViewModel._PregnancyFollow;
                    }
                }

                if (this._PregnancyFollowFormViewModel.PregnancyComplicationsGridList != null) //Gebelik Risk Faktörleri
                {
                    foreach (var item in this._PregnancyFollowFormViewModel.PregnancyComplicationsGridList)
                    {
                        var pregnancyComplications = (PregnancyComplications)objectContext.AddObject(item);
                        if (((ITTObject)pregnancyComplications).IsDeleted)
                            continue;
                        pregnancyComplications.PregnancyFollow = this._PregnancyFollowFormViewModel._PregnancyFollow;
                    }
                }
                
                //E-Nabız Gönderimi Yapılıyor
                new SendToENabiz(objectContext, womanSpecialityObject.PhysicianApplication.SubEpisode, this._PregnancyFollowFormViewModel._PregnancyFollow.ObjectID, this._PregnancyFollowFormViewModel._PregnancyFollow.ObjectDef.Name, "221", Common.RecTime());
            }

            if (this._PreviousPregnancyFormViewModel != null)
            {
                var previousPregnancyFormViewModel = (Pregnancy)objectContext.AddObject(this._PreviousPregnancyFormViewModel._Pregnancy);
                previousPregnancyFormViewModel.Patient = womanSpecialityObject.PhysicianApplication.Episode.Patient;
                if (this._PreviousPregnancyFormViewModel.IndicationReasonsGridList != null)
                {
                    foreach (var item in this._PreviousPregnancyFormViewModel.IndicationReasonsGridList)
                    {
                        var indicationReason = (IndicationReason)objectContext.AddObject(item);
                        indicationReason.Pregnancy = this._PreviousPregnancyFormViewModel._Pregnancy;
                    }
                }

                if (this._PreviousPregnancyFormViewModel.PregnancyComplicationsGridList != null)
                {
                    foreach (var item in this._PreviousPregnancyFormViewModel.PregnancyComplicationsGridList)
                    {
                        var pregnancyComplication = (PregnancyComplications)objectContext.AddObject(item);
                        pregnancyComplication.Pregnancy = this._PreviousPregnancyFormViewModel._Pregnancy;
                    }
                }
            }

            if (this._Patient != null)
            {
                var patient = (Patient)objectContext.AddObject(this._Patient);
                if (this._IsPregnancyStarted == false) //Gebelik Sonucu
                {
                    patient.ActivePregnancy = null;
                }

                if (this._InfertilityPatientInformationFormViewModel != null) //İnfertilite hasta bazlı
                {
                    var infertilityPatient = (InfertilityPatientInformation)objectContext.GetObject(this._InfertilityPatientInformationFormViewModel._InfertilityPatientInformation.ObjectID, this._InfertilityPatientInformationFormViewModel._InfertilityPatientInformation.ObjectDef);
                    patient.InfertilityPatientInformation = infertilityPatient;
                }
            }

            if (this._PostpartumFollowUpFormViewModel != null) //Lohusa İzlem
            {
                var postpartumFollow = (PostpartumFollowUp)objectContext.AddObject(this._PostpartumFollowUpFormViewModel._PostpartumFollowUp);
                womanSpecialityObject.PostpartumFollowUp = postpartumFollow;

                if (this._PostpartumFollowUpFormViewModel.ComplicationDiagnosisGridList != null) 
                {
                    foreach (var item in this._PostpartumFollowUpFormViewModel.ComplicationDiagnosisGridList)
                    {
                        var complicationDiagnose = (ComplicationDiagnosis)objectContext.AddObject(item);
                        if (((ITTObject)complicationDiagnose).IsDeleted)
                            continue;
                        complicationDiagnose.PostpartumFollowUp = this._PostpartumFollowUpFormViewModel._PostpartumFollowUp;
                    }
                }

                if (this._PostpartumFollowUpFormViewModel.DangerSignsGridList != null) //Lohusalık Seyrinde Tehlike İşareti
                {
                    foreach (var item in this._PostpartumFollowUpFormViewModel.DangerSignsGridList)
                    {
                        var dangerSign = (PostpartumDangerSigns)objectContext.AddObject(item);
                        if (((ITTObject)dangerSign).IsDeleted)
                            continue;
                        dangerSign.PostpartumFollowUp = this._PostpartumFollowUpFormViewModel._PostpartumFollowUp;
                    }
                }

                if (this._PostpartumFollowUpFormViewModel.WomanHealthOperationsGridList != null) 
                {
                    foreach (var item in this._PostpartumFollowUpFormViewModel.WomanHealthOperationsGridList)
                    {
                        var healthOperation = (WomanHealthOperations)objectContext.AddObject(item);
                        if (((ITTObject)healthOperation).IsDeleted)
                            continue;
                        healthOperation.PostpartumFollowUp = this._PostpartumFollowUpFormViewModel._PostpartumFollowUp;
                    }
                }

                //E-Nabız Gönderimi Yapılıyor
               // new SendToENabiz(objectContext, womanSpecialityObject.PhysicianApplication.SubEpisode, this._PregnancyFollowFormViewModel._PregnancyFollow.ObjectID, this._PregnancyFollowFormViewModel._PregnancyFollow.ObjectDef.Name, "221", Common.RecTime());
            }
        }
    }

    public class PregnancyCalendarDefinitionDVO
    {
        public int? StartDate
        {
            get;
            set;
        }

        public int? FinishDate
        {
            get;
            set;
        }

        public string PeriodName
        {
            get;
            set;
        }

        public PregnancyTypeEnum? PregnancyType
        {
            get;
            set;
        }

        public DateTime CalculatedStartDate
        {
            get;
            set;
        }

        public DateTime CalculatedFinishDate
        {
            get;
            set;
        }
    }
}