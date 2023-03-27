//$ECA52857
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { TermOpenCloseActionForm } from './TermOpenCloseActionForm';

const routes: Routes = [
    {
        path: '',
        component: TermOpenCloseActionForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
TermOpenCloseActionForm
 ],
 exports: [
 TermOpenCloseActionForm
  ],
  entryComponents: [
  TermOpenCloseActionForm
   ]
})
export class DonemAcmaKapatmaIslemiModule {
	static dynamicComponentsMap = {
		TermOpenCloseActionForm
	};
 }

