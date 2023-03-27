//$7749219F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientOwnDrugReturnForm } from './PatientOwnDrugReturnForm';
import { PatientOwnDrugReturnCompForm } from './PatientOwnDrugReturnCompForm';

const routes: Routes = [
    {
        path: '',
        component: PatientOwnDrugReturnForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routes)],
    declarations: [
        PatientOwnDrugReturnForm, PatientOwnDrugReturnCompForm
    ],
    exports: [
        PatientOwnDrugReturnForm, PatientOwnDrugReturnCompForm
    ],
    entryComponents: [
        PatientOwnDrugReturnForm, PatientOwnDrugReturnCompForm
    ]
})
export class HastaninIlaclariIadeModule {
	static dynamicComponentsMap = {
		PatientOwnDrugReturnForm, 
		PatientOwnDrugReturnCompForm
	};
 }

