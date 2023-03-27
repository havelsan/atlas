//$EC36EE52
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { WomanSpecialityForm } from './WomanSpecialityForm';
import { InfertilityPatientInformationForm } from './InfertilityPatientInformationForm';
import { GynecologyForm } from './GynecologyForm';
import { InfertilityForm } from './InfertilityForm';
import { PregnancyFollowForm } from './PregnancyFollowForm';
import { PregnancyStartForm } from './PregnancyStartForm';
import { PreviousPregnancyForm } from './PreviousPregnancyForm';
import { PregnancyResultForm } from './PregnancyResultForm';
import { FormEditorModule } from 'app/FormEditor/form-editor.module'; //<atlas-form-editor  i�in
import { PostpartumFollowUpForm } from './PostpartumFollowUpForm'; 


const routes: Routes = [
    {
        path: '',
        component: InfertilityPatientInformationForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, FormEditorModule,
        RouterModule.forChild(routes)],
    declarations: [
        InfertilityPatientInformationForm, WomanSpecialityForm, GynecologyForm, InfertilityForm,PostpartumFollowUpForm,
        PregnancyFollowForm, PregnancyStartForm, PreviousPregnancyForm, PregnancyResultForm
    ],
    exports: [
        InfertilityPatientInformationForm, WomanSpecialityForm, GynecologyForm, InfertilityForm,PostpartumFollowUpForm,
        PregnancyFollowForm, PregnancyStartForm, PreviousPregnancyForm, PregnancyResultForm
    ],
    entryComponents: [
        InfertilityPatientInformationForm, WomanSpecialityForm, GynecologyForm, InfertilityForm,
        PregnancyFollowForm, PregnancyStartForm, PreviousPregnancyForm, PregnancyResultForm
    ]
})
export class KadinDogumModule {
	static dynamicComponentsMap = {
		InfertilityPatientInformationForm, 
		WomanSpecialityForm, 
		GynecologyForm, 
		InfertilityForm, 
		PregnancyFollowForm, 
		PregnancyStartForm, 
		PreviousPregnancyForm, 
        PregnancyResultForm,
        PostpartumFollowUpForm
	};
 }

