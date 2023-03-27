//$B2C2D7C6
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class IntensiveCareSpecialityObjServiceController
    {
        partial void PreScript_IntensiveCareSpecialityObjForm(IntensiveCareSpecialityObjFormViewModel viewModel, IntensiveCareSpecialityObj intensiveCareSpecialityObj, TTObjectContext objectContext)
        {
            viewModel.physicianApplication = intensiveCareSpecialityObj.PhysicianApplication;


            var episodeActionObj = intensiveCareSpecialityObj.PhysicianApplication as InPatientPhysicianApplication;//
            viewModel.episodeActionId = episodeActionObj.ObjectID;
            viewModel.episodeId = episodeActionObj.Episode.ObjectID;
            viewModel.patientId = episodeActionObj.Episode.Patient.ObjectID;

            viewModel.InPatientTreatmentClinicObjectId = episodeActionObj.InPatientTreatmentClinicApp.ObjectID;
            viewModel.InPatientTreatmentClinicObjectDef = episodeActionObj.InPatientTreatmentClinicApp.ObjectDef.Name;

            if (intensiveCareSpecialityObj.IntensiveCareStep == null)//basamak bilgisi hen�z se�ilmedi ise yatan hastan�n yatak bilgisine g�re basamak bilgisi set edilir.
            {
                var yatan = intensiveCareSpecialityObj.PhysicianApplication as InPatientPhysicianApplication;
                var yatakHizmeti = yatan.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.BedProcedure.Code;

                switch (yatakHizmeti)
                {
                    case "P552001":
                        intensiveCareSpecialityObj.IntensiveCareStep = IntensiveCareStepEnum.One;
                        break;
                    case "P552002":
                        intensiveCareSpecialityObj.IntensiveCareStep = IntensiveCareStepEnum.Two;
                        break;
                    case "P552003":
                        intensiveCareSpecialityObj.IntensiveCareStep = IntensiveCareStepEnum.Three;
                        break;
                }
            }
            if (intensiveCareSpecialityObj.IntensiveCareType == null)
            {
                intensiveCareSpecialityObj.SetIntensiveCareType();
            }

            var newbornItem = NewBornIntensiveCare.GetNewBornIntensiveCare(intensiveCareSpecialityObj.ObjectID);
            if (newbornItem.Count() > 0)
            {
                viewModel.newbornIntensiveObjectId = newbornItem.FirstOrDefault().ObjectID.ToString();
            }


            // MultipleDataComponent i�in Eklendi�i formun presine eklenir
            int summaryLimitCount = 5;
            var baseMultipleDataEntryServiceController = new BaseMultipleDataEntryServiceController();
            viewModel.ApacheScoreSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.ApacheScores.ToList<BaseMultipleDataEntry>());
            viewModel.SapScoreSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.SapScores.ToList<BaseMultipleDataEntry>());
            viewModel.GlaskowScoreSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.GlaskowScores.ToList<BaseMultipleDataEntry>());
            viewModel.ApgarScoreSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.ApgarScores.ToList<BaseMultipleDataEntry>());
            viewModel.BallardNeuromuscularScoreSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.BallardNeuromuscularScores.ToList<BaseMultipleDataEntry>());
            viewModel.BallardPhysicalScoreSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.BallardPhysicalScores.ToList<BaseMultipleDataEntry>());
            viewModel.GeneralInformationSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.GeneralInformation.ToList<BaseMultipleDataEntry>());
            viewModel.PhototherapySummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.Phototherapy.ToList<BaseMultipleDataEntry>());
            viewModel.SnappeIIScoreSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.SnappeScores.ToList<BaseMultipleDataEntry>());
            viewModel.WeightChartSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.WeightChart.ToList<BaseMultipleDataEntry>());
            viewModel.PrismSummaryInfoList = baseMultipleDataEntryServiceController.GetBaseMultipleDataEntrySummaryInfoList(0, summaryLimitCount, intensiveCareSpecialityObj.PhysicianApplication.Prisms.ToList<BaseMultipleDataEntry>());
        }
        partial void PostScript_IntensiveCareSpecialityObjForm(IntensiveCareSpecialityObjFormViewModel viewModel, IntensiveCareSpecialityObj intensiveCareSpecialityObj, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            var yatan = intensiveCareSpecialityObj.PhysicianApplication as InPatientPhysicianApplication;
            var yatakHizmeti = yatan.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.BedProcedure.Code;
            int basamak = 0;
            switch (yatakHizmeti)
            {
                case "P552001":
                    basamak = 1;
                    break;
                case "P552002":
                    basamak = 2;
                    break;
                case "P552003":
                    basamak = 3;
                    break;
            }
            if (basamak != intensiveCareSpecialityObj.IntensiveCareStep.GetHashCode())//yo�un bak�m�n basamak bilgisi ile kay�t edilmi� yatak bilgisi e�le�miyorsa yo�un bak�m�n basamak bilgisi de�i�tirilmeli.
            {

            }

        }
        public int GetIntensiveCareStep(Guid InPatientTreatmentClinicObjectId, string InPatientTreatmentClinicObjectDef)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                InPatientTreatmentClinicApplication InPatientTreatmentClinicApp = objectContext.GetObject(InPatientTreatmentClinicObjectId, InPatientTreatmentClinicObjectDef) as InPatientTreatmentClinicApplication;

                var yatakHizmeti = InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.BedProcedure.Code;
                int IntensiveCareStep = 4;
                switch (yatakHizmeti)
                {
                    case "P552001":
                        IntensiveCareStep = 1;
                        break;
                    case "P552002":
                        IntensiveCareStep = 2;
                        break;
                    case "P552003":
                        IntensiveCareStep = 3;
                        break;
                }
                return IntensiveCareStep;
            }
        }
    }
}

namespace Core.Models
{
    public partial class IntensiveCareSpecialityObjFormViewModel : BaseViewModel, ISpecialityBasedObjectViewModel//Uzmanl�k i�in Base
    {
        public PhysicianApplication physicianApplication { get; set; }

        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
            var intensiveCareSpecialityObj = (IntensiveCareSpecialityObj)objectContext.AddObject(this._IntensiveCareSpecialityObj);//Uzmanl�k i�in
        }

        public List<MultipleDataComponent_SummaryInfo> ApacheScoreSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }

        public List<MultipleDataComponent_SummaryInfo> SapScoreSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }

        public List<MultipleDataComponent_SummaryInfo> GlaskowScoreSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> ApgarScoreSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> BallardNeuromuscularScoreSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> BallardPhysicalScoreSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> GeneralInformationSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> PhototherapySummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> SnappeIIScoreSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> WeightChartSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }
        public List<MultipleDataComponent_SummaryInfo> PrismSummaryInfoList  // MultipleDataComponent i�in
        {
            get;
            set;
        }

        public Guid InPatientTreatmentClinicObjectId { get; set; }
        public string InPatientTreatmentClinicObjectDef { get; set; }
        public Guid episodeActionId { get; set; }
        public Guid episodeId { get; set; }
        public Guid patientId { get; set; }
        public string newbornIntensiveObjectId { get; set; }
    }
}
