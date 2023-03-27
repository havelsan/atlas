//$265B0661
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseCostActionForm } from './BaseCostActionForm';
import { CostActionApprovalForm } from './CostActionApprovalForm';
import { CostActionNewForm } from './CostActionNewForm';
import { CostActionComplatedForm } from './CostActionComplatedForm';

const routes: Routes = [
    {
        path: '',
        component: BaseCostActionForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
BaseCostActionForm, CostActionApprovalForm, CostActionNewForm, CostActionComplatedForm
 ],
exports: [
BaseCostActionForm, CostActionApprovalForm, CostActionNewForm, CostActionComplatedForm
 ],
 entryComponents: [
 BaseCostActionForm, CostActionApprovalForm, CostActionNewForm, CostActionComplatedForm
  ]
})
export class AylikMaliyetAnaliziModule {
	static dynamicComponentsMap = {
		BaseCostActionForm, 
		CostActionApprovalForm, 
		CostActionNewForm, 
		CostActionComplatedForm
	};
 }

