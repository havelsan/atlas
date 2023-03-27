//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SterilizationWorkListForm } from './SterilizationWorkListForm';
import { PatientSearchModule } from '../../../Tibbi_Surec/PatientSearch/PatientSearchModule';

const routes: Routes = [
    {
        path: '',
        component: SterilizationWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        SterilizationWorkListForm
    ],
    exports: [
        SterilizationWorkListForm
    ],
    entryComponents: [
        SterilizationWorkListForm
    ]
})
export class SterilizationIsModule {
	static dynamicComponentsMap = {
		SterilizationWorkListForm
	};
 }

