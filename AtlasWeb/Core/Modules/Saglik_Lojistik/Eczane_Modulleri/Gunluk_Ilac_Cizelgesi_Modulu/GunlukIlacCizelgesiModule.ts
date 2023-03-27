//$773AF1D1
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { KScheduleForm } from './KScheduleForm';
import { KScheduleApprovalForm } from './KScheduleApprovalForm';
import { KScheduleCompletedForm } from './KScheduleCompletedForm';
import { BaseDailyDrugScheduleForm } from './BaseDailyDrugScheduleForm';
import { DailyDrugScheduleNewForm } from './DailyDrugScheduleNewForm';
import { DailyDrugScheduleCompletedForm } from './DailyDrugScheduleCompletedForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { PatientHistoryModule } from 'Modules/Tibbi_Surec/Hasta_Gecmisi/PatientHistoryModule';
import { RadyolojiModule } from 'Modules/Tibbi_Surec/Radyoloji_Modulu/RadyolojiModule';

const routes: Routes = [
    {
        path: '',

    },
];

@NgModule({
	imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,
		PatientHistoryModule, RadyolojiModule,
                RouterModule.forChild(routes)],
declarations: [
KScheduleForm,
KScheduleApprovalForm, KScheduleCompletedForm, BaseDailyDrugScheduleForm,
    DailyDrugScheduleNewForm, DailyDrugScheduleCompletedForm
 ],
exports: [
KScheduleForm,
KScheduleApprovalForm, KScheduleCompletedForm, BaseDailyDrugScheduleForm,
    DailyDrugScheduleNewForm, DailyDrugScheduleCompletedForm
 ],
 entryComponents: [
	KScheduleForm,
	KScheduleApprovalForm, KScheduleCompletedForm, BaseDailyDrugScheduleForm,
		DailyDrugScheduleNewForm, DailyDrugScheduleCompletedForm
	 ]
	
})
export class GunlukIlacCizelgesiModule {
	static dynamicComponentsMap = {
		KScheduleForm, 
		KScheduleApprovalForm, 
		KScheduleCompletedForm, 
		BaseDailyDrugScheduleForm, 
		DailyDrugScheduleNewForm, 
		DailyDrugScheduleCompletedForm
	};
 }

