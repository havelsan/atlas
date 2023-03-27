
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { HemodialysisWorkListForm } from './HemodialysisWorkListForm';
import { PatientSearchModule } from '../../PatientSearch/PatientSearchModule';
import { SimpleTimer } from 'ng2-simple-timer';
import { UpdateEquipmentForm } from './UpdateEquipmentForm';

const routes: Routes = [
    {
        path: '',
        component: HemodialysisWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        HemodialysisWorkListForm, UpdateEquipmentForm
    ],
    exports: [
        HemodialysisWorkListForm, UpdateEquipmentForm
    ],
    entryComponents: [
        HemodialysisWorkListForm, UpdateEquipmentForm
    ],
    providers: [SimpleTimer]
})
export class HemodialysisWorkListModule {
	static dynamicComponentsMap = {
        HemodialysisWorkListForm,
        UpdateEquipmentForm
	};
 }

