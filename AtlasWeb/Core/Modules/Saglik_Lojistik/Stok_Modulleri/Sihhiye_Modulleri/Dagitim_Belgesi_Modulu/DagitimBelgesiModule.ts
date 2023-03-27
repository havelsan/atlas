//$05CC74F9
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseDistributionDocumentForm } from './BaseDistributionDocumentForm';
import { DistributionDocumentApprovalForm } from './DistributionDocumentApprovalForm';
import { DistributionDocumentCompletedForm } from './DistributionDocumentCompletedForm';
import { DistributionDocumentNewForm } from './DistributionDocumentNewForm';
import { MaterialMultiSelectModule } from '../../MaterialMultiSelect/MaterialMultiSelectModule';
import { LogisticFormsModule } from 'app/Logistic/LogisticFormsModule';


@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, MaterialMultiSelectModule, LogisticFormsModule],
declarations: [BaseDistributionDocumentForm, DistributionDocumentApprovalForm, DistributionDocumentCompletedForm,
DistributionDocumentNewForm],
exports: [BaseDistributionDocumentForm, DistributionDocumentApprovalForm, DistributionDocumentCompletedForm,
DistributionDocumentNewForm],
entryComponents: [BaseDistributionDocumentForm, DistributionDocumentApprovalForm, DistributionDocumentCompletedForm,
	DistributionDocumentNewForm]
	
})
export class DagitimBelgesiModule {
	static dynamicComponentsMap = {
		BaseDistributionDocumentForm, 
		DistributionDocumentApprovalForm, 
		DistributionDocumentCompletedForm, 
		DistributionDocumentNewForm
	};
 }

