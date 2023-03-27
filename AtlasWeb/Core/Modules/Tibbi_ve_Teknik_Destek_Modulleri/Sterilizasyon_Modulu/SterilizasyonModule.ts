//$08E074CC
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SterilizationRequestForm } from './SterilizationRequestForm';

const routes: Routes = [
    {
        path: '',
        component: SterilizationRequestForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
SterilizationRequestForm
 ],
 exports: [
 SterilizationRequestForm
  ],
  entryComponents: [
  SterilizationRequestForm
   ]
})
export class SterilizasyonModule {
	static dynamicComponentsMap = {
		SterilizationRequestForm
	};
 }

