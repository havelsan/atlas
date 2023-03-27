//$78F72BFE
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SendMessageToPatientForm } from './SendMessageToPatientForm';

const routes: Routes = [
    {
        path: '',
        component: SendMessageToPatientForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
SendMessageToPatientForm
 ],
 exports: [
 SendMessageToPatientForm
  ],
entryComponents: [
  SendMessageToPatientForm
   ]
})
export class NabizHBYSModule {
	static dynamicComponentsMap = {
		SendMessageToPatientForm
	};
 }

