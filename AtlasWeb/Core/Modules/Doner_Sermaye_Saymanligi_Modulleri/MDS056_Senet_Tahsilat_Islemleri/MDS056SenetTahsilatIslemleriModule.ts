//$97359CA8
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BondPaymentForm } from './BondPaymentForm';

const routes: Routes = [
    {
        path: '',
        component: BondPaymentForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
BondPaymentForm
 ],
exports: [
BondPaymentForm
 ],
 entryComponents: [
 BondPaymentForm
  ]
})
export class MDS056SenetTahsilatIslemleriModule {
	static dynamicComponentsMap = {
		BondPaymentForm
	};
 }

