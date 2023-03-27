//$700F5B64
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { EarlyChildGrowthEvalForm } from './EarlyChildGrowthEvalForm';
import { IQIntelligenceTestReportForm } from './IQIntelligenceTestReportForm';
import { VerbalAndPerformanceTestsForm } from './VerbalAndPerformanceTestsForm';
import { CognitiveEvaluationForm } from './CognitiveEvaluationForm';
import { PsychologicEvaluationForm } from './PsychologicEvaluationForm';
import { PsychologicExaminationForm } from './PsychologicExaminationForm';
import { PsychologyBasedObjectForm } from './PsychologyBasedObjectForm';
import { FormEditorModule } from 'app/FormEditor/form-editor.module'; //<atlas-form-editor  i�in
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';


const routes: Routes = [
    {
        path: '',
        component: PsychologicExaminationForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, PatientDemographicsModule, ReactiveFormsModule, HttpModule, FormEditorModule, DevExtremeModule, FwModule, RouterModule.forChild(routes)],
declarations: [
    EarlyChildGrowthEvalForm, IQIntelligenceTestReportForm, PsychologicExaminationForm,
VerbalAndPerformanceTestsForm, CognitiveEvaluationForm,
     PsychologicEvaluationForm, PsychologyBasedObjectForm
 ],
 exports: [
     EarlyChildGrowthEvalForm, IQIntelligenceTestReportForm, PsychologicExaminationForm,
 VerbalAndPerformanceTestsForm, CognitiveEvaluationForm,
     PsychologicEvaluationForm, PsychologyBasedObjectForm
 ],
 entryComponents: [
     EarlyChildGrowthEvalForm, IQIntelligenceTestReportForm, PsychologicExaminationForm,
 VerbalAndPerformanceTestsForm, CognitiveEvaluationForm,
     PsychologicEvaluationForm, PsychologyBasedObjectForm
 ]
})
export class PsikologModule {
	static dynamicComponentsMap = {
		EarlyChildGrowthEvalForm, 
		IQIntelligenceTestReportForm, 
		PsychologicExaminationForm, 
		VerbalAndPerformanceTestsForm, 
		CognitiveEvaluationForm, 
		PsychologicEvaluationForm, 
		PsychologyBasedObjectForm
	};
 }

