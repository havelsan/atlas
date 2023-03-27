
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';


import { VitalSingsForm } from './VitalSingsForm';


const routes: Routes = [
    {
        path: '',
        component: VitalSingsForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
    RouterModule.forChild(routes)],
declarations: [VitalSingsForm],
exports: [VitalSingsForm],
entryComponents: [VitalSingsForm]
})

export class VitalSingsModule {
	static dynamicComponentsMap = {
		VitalSingsForm
	};
 }

