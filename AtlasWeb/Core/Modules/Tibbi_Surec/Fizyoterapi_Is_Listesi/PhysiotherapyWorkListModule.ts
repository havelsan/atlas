//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PhysiotherapyWorkListForm } from './PhysiotherapyWorkListForm';
import { PatientSearchModule } from 'Modules/Tibbi_Surec/PatientSearch/PatientSearchModule';

const routes: Routes = [
    {
        path: '',
        component: PhysiotherapyWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        PhysiotherapyWorkListForm
    ],
    exports: [
        PhysiotherapyWorkListForm
    ],
    entryComponents: [
        PhysiotherapyWorkListForm
    ]
})
export class PhysiotherapyWorkListModule {
	static dynamicComponentsMap = {
		PhysiotherapyWorkListForm
	};
 }

