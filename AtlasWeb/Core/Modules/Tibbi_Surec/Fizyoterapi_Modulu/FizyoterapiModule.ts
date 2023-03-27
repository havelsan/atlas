//$E7531184
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PhysiotherapyRequestForm } from './PhysiotherapyRequestForm';
import { PhysiotherapyOrderPlanningForm } from './PhysiotherapyOrderPlanningForm';
import { PhysiotherapyRequestPlanningForm } from './PhysiotherapyRequestPlanningForm';
import { PhysiotherapyPlanningForm } from './PhysiotherapyPlanningForm';
import { PhysiotherapyPlannedOrdersForm } from './PhysiotherapyPlannedOrdersForm';
import { ElectrodiagnosticTestsForm } from './ElectrodiagnosticTestsForm';
import { MuscleTestFormForm } from './MuscleTestFormForm';
import { AmputeeAssessmentFormForm } from './AmputeeAssessmentFormForm';
import { SensoryPerceptionAssessmentFormForm } from './SensoryPerceptionAssessmentFormForm';
import { DailyActivityTestsFormForm } from './DailyActivityTestsFormForm';
import { MuscleStrengthMeasuringFormForm } from './MuscleStrengthMeasuringFormForm';
import { RangeOfMotionMeasurementFormForm } from './RangeOfMotionMeasurementFormForm';
import { OccupationalAssessmentFormForm } from './OccupationalAssessmentFormForm';
import { ManualDexterityTestsFormForm } from './ManualDexterityTestsFormForm';
import { NeurophysiologicalAssessmentFormForm } from './NeurophysiologicalAssessmentFormForm';
import { PostureAnalysisFormForm } from './PostureAnalysisFormForm';
import { ScoliosisAssessmentFormForm } from './ScoliosisAssessmentFormForm';
import { GaitAnalysisFormForm } from './GaitAnalysisFormForm';
import { GaitAnalysisComputerBasedFormForm } from './GaitAnalysisComputerBasedFormForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { PhysiotherapyOrderRequestForm } from './PhysiotherapyOrderRequestForm';
import { IsokineticTestFormForm } from './IsokineticTestFormForm';
import { BalanceCoordinationTestsFormForm } from './BalanceCoordinationTestsFormForm';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { FormEditorModule } from 'app/FormEditor/form-editor.module';
import { ProcedureRequestModule } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
import { PhysiotherapyRequestPlannedForm } from './PhysiotherapyRequestPlannedForm';
import { PhysiotherapyOrderPlannedForm } from './PhysiotherapyOrderPlannedForm';
import { PhysiotherapyTreatmentNoteForm } from './PhysiotherapyTreatmentNoteForm';

const routes: Routes = [
	{
		path: '',
		component: PhysiotherapyPlanningForm, //PhysiotherapyPlanForm
	},
];

@NgModule({
	imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, PatientHistoryModule, FormEditorModule, TreatmentMaterialModule, ProcedureRequestModule,
		RouterModule.forChild(routes)],
	declarations: [PhysiotherapyPlanningForm, PhysiotherapyPlannedOrdersForm, PhysiotherapyRequestForm, PhysiotherapyOrderRequestForm, MuscleTestFormForm, AmputeeAssessmentFormForm, IsokineticTestFormForm, BalanceCoordinationTestsFormForm, ElectrodiagnosticTestsForm,
		DailyActivityTestsFormForm, MuscleStrengthMeasuringFormForm, OccupationalAssessmentFormForm,
		SensoryPerceptionAssessmentFormForm, RangeOfMotionMeasurementFormForm, ManualDexterityTestsFormForm, PhysiotherapyOrderPlannedForm, PhysiotherapyRequestPlannedForm, PhysiotherapyTreatmentNoteForm,
		NeurophysiologicalAssessmentFormForm, PostureAnalysisFormForm, ScoliosisAssessmentFormForm, PhysiotherapyOrderPlanningForm, PhysiotherapyRequestPlanningForm,
		GaitAnalysisFormForm, GaitAnalysisComputerBasedFormForm],
	exports: [PhysiotherapyPlanningForm, PhysiotherapyPlannedOrdersForm, PhysiotherapyRequestForm, PhysiotherapyOrderRequestForm, MuscleTestFormForm, AmputeeAssessmentFormForm, IsokineticTestFormForm, BalanceCoordinationTestsFormForm, ElectrodiagnosticTestsForm,
		DailyActivityTestsFormForm, MuscleStrengthMeasuringFormForm, OccupationalAssessmentFormForm,
		SensoryPerceptionAssessmentFormForm, RangeOfMotionMeasurementFormForm, ManualDexterityTestsFormForm, PhysiotherapyOrderPlannedForm, PhysiotherapyRequestPlannedForm, PhysiotherapyTreatmentNoteForm,
		NeurophysiologicalAssessmentFormForm, PostureAnalysisFormForm, ScoliosisAssessmentFormForm, PhysiotherapyOrderPlanningForm, PhysiotherapyRequestPlanningForm,
		GaitAnalysisFormForm, GaitAnalysisComputerBasedFormForm
	],
	entryComponents: [PhysiotherapyPlanningForm, PhysiotherapyPlannedOrdersForm, PhysiotherapyRequestForm, PhysiotherapyOrderRequestForm, MuscleTestFormForm, AmputeeAssessmentFormForm, IsokineticTestFormForm, BalanceCoordinationTestsFormForm, ElectrodiagnosticTestsForm,
		DailyActivityTestsFormForm, MuscleStrengthMeasuringFormForm, OccupationalAssessmentFormForm,
		SensoryPerceptionAssessmentFormForm, RangeOfMotionMeasurementFormForm, ManualDexterityTestsFormForm, PhysiotherapyOrderPlannedForm, PhysiotherapyRequestPlannedForm, PhysiotherapyTreatmentNoteForm,
		NeurophysiologicalAssessmentFormForm, PostureAnalysisFormForm, ScoliosisAssessmentFormForm, PhysiotherapyOrderPlanningForm, PhysiotherapyRequestPlanningForm,
		GaitAnalysisFormForm, GaitAnalysisComputerBasedFormForm
	]
})
export class FizyoterapiModule {
	static dynamicComponentsMap = {
		PhysiotherapyPlanningForm,
		PhysiotherapyPlannedOrdersForm,
		PhysiotherapyRequestForm,
		PhysiotherapyOrderRequestForm,
		MuscleTestFormForm,
		AmputeeAssessmentFormForm,
		IsokineticTestFormForm,
		BalanceCoordinationTestsFormForm,
		ElectrodiagnosticTestsForm,
		DailyActivityTestsFormForm,
		MuscleStrengthMeasuringFormForm,
		OccupationalAssessmentFormForm,
		SensoryPerceptionAssessmentFormForm,
		RangeOfMotionMeasurementFormForm,
		ManualDexterityTestsFormForm,
		PhysiotherapyOrderPlannedForm,
		PhysiotherapyRequestPlannedForm,
		NeurophysiologicalAssessmentFormForm,
		PostureAnalysisFormForm,
		ScoliosisAssessmentFormForm,
		PhysiotherapyOrderPlanningForm,
		PhysiotherapyRequestPlanningForm,
		GaitAnalysisFormForm,
		GaitAnalysisComputerBasedFormForm,
		PhysiotherapyTreatmentNoteForm
	};
}

