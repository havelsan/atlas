//$832C8D62
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SocialServicesPatientInterviewForm } from './SocialServicesPatientInterviewForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { AtlasReportModule } from 'app/Report/AtlasReportModule';
import { AtlasDynamicFormModule } from "app/DynamicForm/AtlasDynamicFormModule";
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
const routes: Routes = [
    {
        path: '',
        component: SocialServicesPatientInterviewForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, PatientDemographicsModule, HttpModule, DevExtremeModule, FwModule, AtlasReportModule, AtlasDynamicFormModule, PatientHistoryModule,
                RouterModule.forChild(routes)],
declarations: [
SocialServicesPatientInterviewForm
 ],
 exports: [
 SocialServicesPatientInterviewForm
  ],
  entryComponents: [
  SocialServicesPatientInterviewForm
   ]
})
export class SosyalHizmetlerModule {
	static dynamicComponentsMap = {
		SocialServicesPatientInterviewForm
	};
 }

