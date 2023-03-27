//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { InPatientWorkListForm } from './InPatientWorkListForm';
import { PatientSearchModule } from '../../PatientSearch/PatientSearchModule';
import { SimpleTimer } from 'ng2-simple-timer';
import { InpatientStatisticReport } from './InpatientStatisticReport';
const routes: Routes = [
    {
        path: '',
        component: InPatientWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        InPatientWorkListForm, InpatientStatisticReport
    ],
    exports: [
        InPatientWorkListForm, InpatientStatisticReport
    ],
    entryComponents: [
        InPatientWorkListForm, InpatientStatisticReport
    ],
    providers: [SimpleTimer]
})
export class InPatientWorkListModule {
	static dynamicComponentsMap = {
        InPatientWorkListForm,
        InpatientStatisticReport
	};
 }

