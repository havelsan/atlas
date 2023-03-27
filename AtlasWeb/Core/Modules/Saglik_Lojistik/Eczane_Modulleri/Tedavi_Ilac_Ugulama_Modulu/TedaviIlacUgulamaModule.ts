//$5297519A
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugOrderDetailForm } from './DrugOrderDetailForm';

const routes: Routes = [
    {
        path: '',
        component: DrugOrderDetailForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
DrugOrderDetailForm/*,DrugOrderForm,DrugEquivalentForm*/
 ],
 exports: [
 DrugOrderDetailForm /*,DrugOrderForm,DrugEquivalentForm*/
  ],
  entryComponents: [
  DrugOrderDetailForm /*,DrugOrderForm,DrugEquivalentForm*/
   ]
})
export class TedaviIlacUgulamaModule {
	static dynamicComponentsMap = {
		DrugOrderDetailForm /*, 
		DrugOrderForm, 
		DrugEquivalentForm*/
	};
 }

