//$B148195A
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugReturnActionApprovalForm } from './DrugReturnActionApprovalForm';
import { DrugReturnActionCompletedForm } from './DrugReturnActionCompletedForm';
import { DrugReturnActionNewForm } from './DrugReturnActionNewForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';

const routes: Routes = [
    {
        path: '',
        component: DrugReturnActionApprovalForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,
        RouterModule.forChild(routes)],
    declarations: [
        DrugReturnActionApprovalForm, DrugReturnActionCompletedForm, DrugReturnActionNewForm
    ],
    exports: [
        DrugReturnActionApprovalForm, DrugReturnActionCompletedForm, DrugReturnActionNewForm
    ],
    entryComponents: [
        DrugReturnActionApprovalForm, DrugReturnActionCompletedForm, DrugReturnActionNewForm
    ]
})
export class EczaneyeIlacIadeModule {
	static dynamicComponentsMap = {
		DrugReturnActionApprovalForm, 
		DrugReturnActionCompletedForm, 
		DrugReturnActionNewForm
	};
 }

