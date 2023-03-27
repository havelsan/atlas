import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientAdmissionSearchModule } from 'Modules/Tibbi_Surec/Kayit_Kabul_Modulu/PatientAdmissionSearch/PatientAdmissionSearchModule';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { PatientHistorySearchForm } from './PatientHistorySearchForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';


const routes: Routes = [
    {
        path: '',
        component: PatientHistorySearchForm,
    }

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, PatientAdmissionSearchModule, PatientHistoryModule, HttpModule, DevExtremeModule, PatientDemographicsModule, FwModule, RouterModule.forChild(routes)],
    declarations: [
        PatientHistorySearchForm
    ],
    exports: [
        PatientHistorySearchForm
    ],
    entryComponents: [
        PatientHistorySearchForm
    ]
})
export class PatientHistorySearchModule {
	static dynamicComponentsMap = {
		PatientHistorySearchForm
	};
 }

