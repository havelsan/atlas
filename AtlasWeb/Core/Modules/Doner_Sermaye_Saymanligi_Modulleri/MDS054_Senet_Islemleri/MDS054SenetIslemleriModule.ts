//$D25593F8
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BondForm } from './BondForm';

const routes: Routes = [
    {
        path: '',
        component: BondForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
BondForm
 ],
exports: [
BondForm
 ],
 entryComponents: [
BondForm
 ]
})
export class MDS054SenetIslemleriModule {
	static dynamicComponentsMap = {
		BondForm
	};
 }

