//$04836241
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseReviewActionForm } from './BaseReviewActionForm';
import { ReviewActionNewForm } from './ReviewActionNewForm';
import { ReviewActionApprovalForm } from './ReviewActionApprovalForm';
import { ReviewActionCompletedForm } from './ReviewActionCompletedForm';

const routes: Routes = [
    {
        path: '',
        component: BaseReviewActionForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
BaseReviewActionForm, ReviewActionNewForm, ReviewActionApprovalForm, ReviewActionCompletedForm
 ],
 exports: [
 BaseReviewActionForm, ReviewActionNewForm, ReviewActionApprovalForm, ReviewActionCompletedForm
  ],
entryComponents: [
  BaseReviewActionForm, ReviewActionNewForm, ReviewActionApprovalForm, ReviewActionCompletedForm
   ]
})
export class IcmalModule {
	static dynamicComponentsMap = {
		BaseReviewActionForm, 
		ReviewActionNewForm, 
		ReviewActionApprovalForm, 
		ReviewActionCompletedForm
	};
 }

