//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { HealthCommitteeWorkListForm } from './HealthCommitteeWorkListForm';
import { PatientSearchModule } from '../../PatientSearch/PatientSearchModule';
import { SimpleTimer } from 'ng2-simple-timer';

const routes: Routes = [
    {
        path: '',
        component: HealthCommitteeWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        HealthCommitteeWorkListForm
    ],
    exports: [
        HealthCommitteeWorkListForm
    ],
    entryComponents: [
        HealthCommitteeWorkListForm
    ],
    providers: [SimpleTimer]
})
export class HealthCommitteeWorkListModule {
	static dynamicComponentsMap = {
		HealthCommitteeWorkListForm
	};
 }

