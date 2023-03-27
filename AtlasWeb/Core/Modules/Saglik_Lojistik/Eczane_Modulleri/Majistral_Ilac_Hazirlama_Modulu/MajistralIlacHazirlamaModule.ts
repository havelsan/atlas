//$E890B266
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MagistralPreparationActionForm } from './MagistralPreparationActionForm';
import { MagistralPreparationActionCompletedForm } from './MagistralPreparationActionCompletedForm';

const routes: Routes = [
    {
        path: '',

    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
MagistralPreparationActionForm, MagistralPreparationActionCompletedForm
 ],
 exports: [
 MagistralPreparationActionForm, MagistralPreparationActionCompletedForm
  ],
  entryComponents: [
  MagistralPreparationActionForm, MagistralPreparationActionCompletedForm
   ]
})
export class MajistralIlacHazirlamaModule {
	static dynamicComponentsMap = {
		MagistralPreparationActionForm, 
		MagistralPreparationActionCompletedForm
	};
 }

