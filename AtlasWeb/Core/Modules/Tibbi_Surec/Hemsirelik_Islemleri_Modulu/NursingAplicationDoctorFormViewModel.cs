//$009D688A
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
    public partial class NursingApplicationServiceController
    {
        partial void PreScript_NursingAplicationDoctorForm(NursingAplicationDoctorFormViewModel viewModel, NursingApplication nursingApplication, TTObjectContext objectContext)
        {
            int summaryLimitCount = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("NURSINGSUMMARYLIMITCOUNT", "5"));

            viewModel.NursingAppProgressSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.Progresses.ToList<BaseNursingDataEntry>());
            viewModel.NursingGlaskowComaScaleSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.GlaskowComaScales.ToList<BaseNursingDataEntry>());
            viewModel.NursingPupilSymptomsSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.PupilSymptoms.ToList<BaseNursingDataEntry>());
            viewModel.NursingPainScaleSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.PainScales.ToList<BaseNursingDataEntry>());
            viewModel.NursingSpiritualSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.SpiritualEvaluations.ToList<BaseNursingDataEntry>());
            viewModel.NursingNutritionAssessmentSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.NutritionAssessments.ToList<BaseNursingDataEntry>());
            viewModel.NursingFunctionalLifeActivitySummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.DailyLifeActivities.ToList<BaseNursingDataEntry>());
            viewModel.NursingPatientAndFamilyInstructionSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingPatientAndFamilyInstructions.ToList<BaseNursingDataEntry>());
            viewModel.NursingCareSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.NursingCares.ToList<BaseNursingDataEntry>());
            viewModel.NursingSystemInterrogationSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingSystemInterrogations.ToList<BaseNursingDataEntry>());
            viewModel.NursingDischargingInstructionPlanSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingDischargingInstructionPlans.ToList<BaseNursingDataEntry>());
            viewModel.NursingFallingDownRiskSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingFallingDownRisks.ToList<BaseNursingDataEntry>());
            viewModel.NursingWoundAssessmentScaleInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.WoundAssessmentScales.ToList<BaseNursingDataEntry>());
            viewModel.NursingLegMeasurementInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.LegMeasurements.ToList<BaseNursingDataEntry>());
            viewModel.NursingNutritionalRiskAssessmentInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.NursingNutritionalRiskAssessments.ToList<BaseNursingDataEntry>());
            viewModel.NursingWoundedAssessmentInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.WoundAssesments.ToList<BaseNursingDataEntry>());
            this.ArrangeButtons(viewModel);
        }

        public void ArrangeButtons(NursingAplicationDoctorFormViewModel viewModel)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == NursingApplication.States.Cancelled)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == NursingApplication.States.PreDischarged)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == NursingApplication.States.Discharged && viewModel._NursingApplication.EmergencyIntervention == null)
                    removedOutgoingTransitions.Add(trans);
            }
            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }
    }
}

namespace Core.Models
{
    public partial class NursingAplicationDoctorFormViewModel :BaseViewModel
    {
        public List<NursingDynamicComponent_SummaryInfo> NursingAppProgressSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingGlaskowComaScaleSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingPupilSymptomsSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingPainScaleSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingSpiritualSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingNutritionAssessmentSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingFunctionalLifeActivitySummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingPatientAndFamilyInstructionSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingCareSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingSystemInterrogationSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingDischargingInstructionPlanSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingFallingDownRiskSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingWoundAssessmentScaleInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingLegMeasurementInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingNutritionalRiskAssessmentInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingWoundedAssessmentInfoList
        {
            get;
            set;
        }

    }
}
