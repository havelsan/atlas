//$EDB69E19
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { GrantMaterialNewForm } from './GrantMaterialNewForm';
import { GrantMaterialCancelForm } from './GrantMaterialCancelForm';
import { GrantMaterialCompletedForm } from './GrantMaterialCompletedForm';
import { BaseGrantMaterialForm } from './BaseGrantMaterialForm';
import { GrantMaterialApprovalForm } from './GrantMaterialApprovalForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        GrantMaterialNewForm, GrantMaterialCancelForm, GrantMaterialCompletedForm, BaseGrantMaterialForm,
        GrantMaterialApprovalForm
    ],
    exports: [
        GrantMaterialNewForm, GrantMaterialCancelForm, GrantMaterialCompletedForm, BaseGrantMaterialForm,
        GrantMaterialApprovalForm
    ],
    entryComponents: [
        GrantMaterialNewForm, GrantMaterialCancelForm, GrantMaterialCompletedForm, BaseGrantMaterialForm,
        GrantMaterialApprovalForm
    ]
})
export class BagisYardimModule {
	static dynamicComponentsMap = {
		GrantMaterialNewForm, 
		GrantMaterialCancelForm, 
		GrantMaterialCompletedForm, 
		BaseGrantMaterialForm, 
		GrantMaterialApprovalForm
	};
 }

