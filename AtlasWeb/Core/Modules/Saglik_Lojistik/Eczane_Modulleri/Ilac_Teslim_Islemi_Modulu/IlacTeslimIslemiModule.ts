//$8977FCDF
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugDeliveryActionNewForm } from './DrugDeliveryActionNewForm';

const routes: Routes = [
    {
        path: '',
        component: DrugDeliveryActionNewForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
DrugDeliveryActionNewForm
 ],
exports: [
DrugDeliveryActionNewForm
 ],
 entryComponents: [
    DrugDeliveryActionNewForm
     ]
    
})
export class IlacTeslimIslemiModule {
	static dynamicComponentsMap = {
		DrugDeliveryActionNewForm
	};
 }

