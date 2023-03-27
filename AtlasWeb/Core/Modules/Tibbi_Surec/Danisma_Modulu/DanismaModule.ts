//$6DDF2587
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { HospitalInformationForm } from './HospitalInformationForm';
import { HospitalInformationPatientSearchModule } from './HospitalInformationPatientSearch/HospitalInformationPatientSearchModule';


const routes: Routes = [
    {
        path: '',
        component: HospitalInformationForm
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, HospitalInformationPatientSearchModule, RouterModule.forChild(routes)],
    declarations: [
        HospitalInformationForm
    ],
    exports: [
        HospitalInformationForm
    ],
    entryComponents: [
        HospitalInformationForm
    ]
})
export class DanismaModule {
	static dynamicComponentsMap = {
		HospitalInformationForm
	};
 }

