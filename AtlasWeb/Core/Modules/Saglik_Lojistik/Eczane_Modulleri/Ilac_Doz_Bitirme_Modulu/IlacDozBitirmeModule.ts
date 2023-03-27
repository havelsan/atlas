//$3BE1A585
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugDoseCompletionForm } from './DrugDoseCompletionForm';

const routes: Routes = [
    {
        path: '',
        component: DrugDoseCompletionForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
DrugDoseCompletionForm
 ],
exports: [
DrugDoseCompletionForm
 ],
 entryComponents: [
    DrugDoseCompletionForm
     ]
    
})
export class IlacDozBitirmeModule {
	static dynamicComponentsMap = {
		DrugDoseCompletionForm
	};
 }

