//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DietWorkListForm } from './DietWorkListForm';

const routes: Routes = [
    {
        path: '',
        component: DietWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routes)],
    declarations: [
        DietWorkListForm
    ],
    exports: [
        DietWorkListForm
    ],
    entryComponents: [
        DietWorkListForm
    ]
})
export class DiyetModule {
	static dynamicComponentsMap = {
		DietWorkListForm
	};
 }

