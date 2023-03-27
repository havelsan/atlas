//$928F8A3A
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { VaccineFollowUpForm } from './VaccineFollowUpForm';
import { VaccineApplicationForm } from './VaccineApplicationForm';

const routes: Routes = [
    {
        path: '',
        component: VaccineFollowUpForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routes)],
    declarations: [
        VaccineFollowUpForm, VaccineApplicationForm
    ],
    exports: [
        VaccineFollowUpForm, VaccineApplicationForm
    ],
    entryComponents: [
        VaccineFollowUpForm, VaccineApplicationForm
    ]
})
export class AsiTakipModule {
	static dynamicComponentsMap = {
		VaccineFollowUpForm, 
		VaccineApplicationForm
	};
 }