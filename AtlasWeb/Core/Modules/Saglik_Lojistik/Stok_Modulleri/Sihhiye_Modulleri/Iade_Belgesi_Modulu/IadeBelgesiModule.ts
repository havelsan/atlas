//$74C4D722
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseReturningDocumentForm } from './BaseReturningDocumentForm';
import { ReturningDocumentCompletedForm } from './ReturningDocumentCompletedForm';
import { ReturningDocumentApprovalForm } from './ReturningDocumentApprovalForm';
import { ReturningDocumentForm } from './ReturningDocumentForm';
import { LogisticFormsModule } from 'app/Logistic/LogisticFormsModule';

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,LogisticFormsModule],
declarations: [
BaseReturningDocumentForm, ReturningDocumentCompletedForm, ReturningDocumentApprovalForm,
ReturningDocumentForm
 ],
 exports: [
 BaseReturningDocumentForm, ReturningDocumentCompletedForm, ReturningDocumentApprovalForm,
 ReturningDocumentForm
  ],
entryComponents: [
  BaseReturningDocumentForm, ReturningDocumentCompletedForm, ReturningDocumentApprovalForm,
  ReturningDocumentForm
   ]
})
export class IadeBelgesiModule {
	static dynamicComponentsMap = {
		BaseReturningDocumentForm, 
		ReturningDocumentCompletedForm, 
		ReturningDocumentApprovalForm, 
		ReturningDocumentForm
	};
 }

