//$5A58758C
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SupplyRequestCancelledForm } from './SupplyRequestCancelledForm';
import { SupplyRequestApprovalForm } from './SupplyRequestApprovalForm';
import { SupplyRequestNewForm } from './SupplyRequestNewForm';
import { BaseSupplyRequest } from './BaseSupplyRequest';
import { SupplyRequestCompletedForm } from './SupplyRequestCompletedForm';
import { SupplyRqstPlDetailForm } from './SupplyRqstPlDetailForm';
import { MKYSExcessForm } from './MKYSExcessForm';
import { SupplyRequestPoolApprovalForm } from './SupplyRequestPoolApprovalForm';
import { SupplyRequestPoolCompletedForm } from './SupplyRequestPoolCompletedForm';
import { SupplyRequestPoolNewForm } from './SupplyRequestPoolNewForm';
import { BaseSupplyRequestPoolForm } from './BaseSupplyRequestPoolForm';


const routes: Routes = [
    {
        path: '',
        component: SupplyRequestCancelledForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
SupplyRequestCancelledForm, SupplyRequestApprovalForm, SupplyRequestNewForm, BaseSupplyRequest,
SupplyRequestCompletedForm, SupplyRqstPlDetailForm, MKYSExcessForm, SupplyRequestPoolApprovalForm,
SupplyRequestPoolNewForm, BaseSupplyRequestPoolForm, SupplyRequestPoolCompletedForm
 ],
exports: [
SupplyRequestCancelledForm, SupplyRequestApprovalForm, SupplyRequestNewForm, BaseSupplyRequest,
SupplyRequestCompletedForm, SupplyRqstPlDetailForm, MKYSExcessForm, SupplyRequestPoolApprovalForm,
SupplyRequestPoolNewForm, BaseSupplyRequestPoolForm, SupplyRequestPoolCompletedForm
 ],
entryComponents: [
SupplyRequestCancelledForm, SupplyRequestApprovalForm, SupplyRequestNewForm, BaseSupplyRequest,
SupplyRequestCompletedForm, SupplyRqstPlDetailForm, MKYSExcessForm, SupplyRequestPoolApprovalForm,
SupplyRequestPoolNewForm, BaseSupplyRequestPoolForm, SupplyRequestPoolCompletedForm
 ]
})
export class SatinalmaIstekModule {
	static dynamicComponentsMap = {
		SupplyRequestCancelledForm, 
		SupplyRequestApprovalForm, 
		SupplyRequestNewForm, 
		BaseSupplyRequest, 
		SupplyRequestCompletedForm, 
		SupplyRqstPlDetailForm, 
		MKYSExcessForm, 
		SupplyRequestPoolApprovalForm, 
		SupplyRequestPoolNewForm, 
		BaseSupplyRequestPoolForm, 
		SupplyRequestPoolCompletedForm
	};
 }

