//$BE3093A4
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientOwnDrugEntryForm } from './PatientOwnDrugEntryForm';
import { PatientOwnDrugEntryApprovalForm } from './PatientOwnDrugEntryApprovalForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';

const routes: Routes = [
    {
        path: '',
        component: PatientOwnDrugEntryForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,
        RouterModule.forChild(routes)],
    declarations: [
        PatientOwnDrugEntryForm, PatientOwnDrugEntryApprovalForm
    ],
    exports: [
        PatientOwnDrugEntryForm, PatientOwnDrugEntryApprovalForm
    ],
    entryComponents: [
        PatientOwnDrugEntryForm, PatientOwnDrugEntryApprovalForm
    ]
})
export class HastaninIlaclariGirisModule {
	static dynamicComponentsMap = {
		PatientOwnDrugEntryForm, 
		PatientOwnDrugEntryApprovalForm
	};
 }

