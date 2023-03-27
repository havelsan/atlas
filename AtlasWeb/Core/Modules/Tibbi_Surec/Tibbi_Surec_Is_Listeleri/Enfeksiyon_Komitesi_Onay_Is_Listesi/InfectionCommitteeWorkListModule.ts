//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { InfectionCommitteeWorkListForm } from './InfectionCommitteeWorkListForm';
import { PatientSearchModule } from '../../PatientSearch/PatientSearchModule';
import { SimpleTimer } from 'ng2-simple-timer';

const routes: Routes = [
    {
        path: '',
        component: InfectionCommitteeWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        InfectionCommitteeWorkListForm
    ],
    exports: [
        InfectionCommitteeWorkListForm
    ],
    entryComponents: [
        InfectionCommitteeWorkListForm
    ],
    providers: [SimpleTimer]
})
export class InfectionCommitteeWorkListModule {
	static dynamicComponentsMap = {
		InfectionCommitteeWorkListForm
	};
 }

