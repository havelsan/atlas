
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SurgeryWorkListForm } from './SurgeryWorkListForm';
import { PatientSearchModule } from '../../PatientSearch/PatientSearchModule';
import { SimpleTimer } from 'ng2-simple-timer';
import { SafeSurgeryChecklistWorkListForm } from './SafeSurgeryCheckListWorkListForm';

const routes: Routes = [
    {
        path: 'ameliyatveanesteziislistesi',
        component: SurgeryWorkListForm,
    },
    {
        path: 'cerrahikontrolislistesi',
        component: SafeSurgeryChecklistWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        SurgeryWorkListForm, SafeSurgeryChecklistWorkListForm
    ],
    exports: [
        SurgeryWorkListForm,SafeSurgeryChecklistWorkListForm
    ],
    entryComponents: [
        SurgeryWorkListForm
    ],
    providers: [SimpleTimer]
})
export class SurgeryWorkListModule {
	static dynamicComponentsMap = {
		SurgeryWorkListForm
	};
 }

