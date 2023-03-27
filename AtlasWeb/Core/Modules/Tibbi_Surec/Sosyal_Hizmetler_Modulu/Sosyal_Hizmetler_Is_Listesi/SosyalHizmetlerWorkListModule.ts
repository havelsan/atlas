//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SosyalHizmetlerWorkListForm } from './SosyalHizmetlerWorkListForm';
import { PatientSearchModule } from '../../PatientSearch/PatientSearchModule';

const routes: Routes = [
    {
        path: '',
        component: SosyalHizmetlerWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
        RouterModule.forChild(routes)],
    declarations: [
        SosyalHizmetlerWorkListForm
    ],
    exports: [
        SosyalHizmetlerWorkListForm
    ],
    entryComponents: [
        SosyalHizmetlerWorkListForm
    ]
})
export class SosyalHizmetlerWorkListModule {
	static dynamicComponentsMap = {
		SosyalHizmetlerWorkListForm
	};
 }

