//$E8707149
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PrescriptionBaseForm } from './PrescriptionBaseForm';



const routes: Routes = [
    {
        path: '',

    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
PrescriptionBaseForm
 ],
exports: [
PrescriptionBaseForm
 ],
 entryComponents: [
    PrescriptionBaseForm
     ]
    
})
export class EczaneEvrenselModule {
	static dynamicComponentsMap = {
		PrescriptionBaseForm
	};
 }

