//$179C2FF7
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ExtendExpDateNewForm } from './ExtendExpDateNewForm';
import { ExtendExpDateCancelForm } from './ExtendExpDateCancelForm';
import { ExtendExpDateApprovalForm } from './ExtendExpDateApprovalForm';
import { BaseExtendExpDateForm } from './BaseExtendExpDateForm';
import { ExtendExpDateCompletedForm } from './ExtendExpDateCompletedForm';

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
declarations: [
ExtendExpDateNewForm, ExtendExpDateCancelForm, ExtendExpDateApprovalForm, BaseExtendExpDateForm,
ExtendExpDateCompletedForm
 ],
 exports: [
 ExtendExpDateNewForm, ExtendExpDateCancelForm, ExtendExpDateApprovalForm, BaseExtendExpDateForm,
 ExtendExpDateCompletedForm
  ],
  entryComponents: [
  ExtendExpDateNewForm, ExtendExpDateCancelForm, ExtendExpDateApprovalForm, BaseExtendExpDateForm,
  ExtendExpDateCompletedForm
   ]
})
export class MiadUzatimModule {
	static dynamicComponentsMap = {
		ExtendExpDateNewForm, 
		ExtendExpDateCancelForm, 
		ExtendExpDateApprovalForm, 
		BaseExtendExpDateForm, 
		ExtendExpDateCompletedForm
	};
 }

