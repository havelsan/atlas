//$67D8840C
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SubStoreConsumptionApprovalForm } from './SubStoreConsumptionApprovalForm';
import { SubStoreConsumptionCompForm } from './SubStoreConsumptionCompForm';
import { BaseSubStoreConsumptionActionForm } from './BaseSubStoreConsumptionActionForm';
import { SubStoreConsumptionNewForm } from './SubStoreConsumptionNewForm';
import { MaterialMultiSelectModule } from '../../MaterialMultiSelect/MaterialMultiSelectModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, MaterialMultiSelectModule],
    declarations: [
        SubStoreConsumptionApprovalForm, SubStoreConsumptionCompForm,
        BaseSubStoreConsumptionActionForm, SubStoreConsumptionNewForm
    ],
    exports: [
        SubStoreConsumptionApprovalForm, SubStoreConsumptionCompForm,
        BaseSubStoreConsumptionActionForm, SubStoreConsumptionNewForm
    ],
    entryComponents: [
        SubStoreConsumptionApprovalForm, SubStoreConsumptionCompForm,
        BaseSubStoreConsumptionActionForm, SubStoreConsumptionNewForm
    ]
})
export class DepodanSarfIslemiModule {
	static dynamicComponentsMap = {
		SubStoreConsumptionApprovalForm, 
		SubStoreConsumptionCompForm, 
		BaseSubStoreConsumptionActionForm, 
		SubStoreConsumptionNewForm
	};
 }

